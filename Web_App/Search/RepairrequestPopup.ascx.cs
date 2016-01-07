using System;
using System.Data;
using System.Configuration;
using System.Collections;
using System.Web;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Web.UI.WebControls.WebParts;
using System.Web.UI.HtmlControls;
using SHND.Data.Search;
using SHND.Data.Views;
using SHND.Flow.Search;
using SHND.Global;

/// <summary>
/// RepairrequestPopup Page Class
/// Version 1.0
/// =========================================================================
/// Create by: Pro
/// Create Date: 11 Feb 2009
/// -------------------------------------------------------------------------
/// Modify By: -
/// Modify From: -
/// Modify Date: -
/// -------------------------------------------------------------------------
/// Remark: -
/// Description:
///    หน้าค้นหา ข้อมูลรายการวัสดุที่ส่งซ่อม (Repair)
/// Changes:
///    1.0 - สร้าง
/// -------------------------------------------------------------------------
/// =========================================================================
/// </summary>
/// 

public partial class Search_RepairrequestPopup : System.Web.UI.UserControl
{
    public delegate void SelectedIndexChangedEvent(object sender, EventArgs e, VStockRemainData SelectedData);
    public event SelectedIndexChangedEvent SelectedIndexChanged;

    protected void Page_Load(object sender, EventArgs e)
    {

    }

    protected override void OnInit(EventArgs e)
    {
        base.OnInit(e);
        Appz.BuildCombo(this.cmbWarehouse, "WAREHOUSE", "NAME", "LOID", "", "NAME", "ทั้งหมด", "0", false);
        Appz.BuildCombo(this.cmbSearchMaterial, "MATERIALGROUP", "NAME", "LOID", "ACTIVE = '1'", "NAME", "ทั้งหมด", "0", false);
        pcBot.SetMainGridView(gvMain);
        pcTop.SetMainGridView(gvMain);
    }

    #region Button Click Event Handler

    protected void tbBackClick(object sender, EventArgs e)
    {
    }

    protected void imbSearch_Click(object sender, ImageClickEventArgs e)
    {
        gvMain.PageIndex = 0;
        doGetList();
        popupRepairrequest.Show();
    }

    protected void imbReset_Click(object sender, ImageClickEventArgs e)
    {
        ClearSearch();
        gvMain.PageIndex = 0;
        doGetList();
        popupRepairrequest.Show();
    }

    protected void imbSelect_Click(object sender, ImageClickEventArgs e)
    {
        int rowIndex = ((GridViewRow)((ImageButton)sender).Parent.Parent).RowIndex;
        if (SelectedIndexChanged != null) SelectedIndexChanged(sender, e, GetSelectedData(rowIndex));
    }

    #endregion

    #region Gridview Event Handler
    protected void gvMain_RowDataBound(object sender, GridViewRowEventArgs e)
    {
        if (e.Row.RowType == DataControlRowType.DataRow)
        {
            e.Row.Cells[2].Text = ((e.Row.RowIndex + 1) + (gvMain.PageIndex * gvMain.PageSize)).ToString();
        }
    }
    protected void gvMain_Sorting(object sender, GridViewSortEventArgs e)
    {
        if (e.SortExpression == "DEFAULT")
        {
            txhSortDir.Text = "";
            txhSortField.Text = "";
        }
        else
        {
            if (txhSortField.Text == e.SortExpression)
                txhSortDir.Text = (txhSortDir.Text.Trim() == "" ? "DESC" : "");
            else
                txhSortField.Text = e.SortExpression;
        }
        doGetList();
        popupRepairrequest.Show();
    }

    #endregion

    #region Paging Event Handler

    protected void PageChange(object sender, EventArgs e)
    {
        gvMain.PageIndex = ((Templates_PageControl)sender).SelectedPageIndex;
        doGetList();
        pcBot.Update();
        pcTop.Update();
        popupRepairrequest.Show();
    }

    #endregion


    #region Controls Management Methods

    private void ClearSearch()
    {
        this.cmbSearchMaterial.SelectedIndex = 0;
        this.txtSearchMaterialName.Text = "";
    }

    public void Show()
    {
        //this.txtExistKeyList.Text = existKeyList;
        ClearSearch();

        gvMain.PageIndex = 0;
        doGetList();
        popupRepairrequest.Show();
    }

    public void Show(double warehouse)
    {
        //this.txtExistKeyList.Text = existKeyList;
        ClearSearch();
        this.cmbWarehouse.SelectedIndex = this.cmbWarehouse.Items.IndexOf(this.cmbWarehouse.Items.FindByValue(warehouse.ToString()));
        this.cmbWarehouse.Enabled = false;

        gvMain.PageIndex = 0;
        doGetList();
        popupRepairrequest.Show();
    }

    #endregion

    #region Working Method

    private VStockRemainData GetSelectedData(int rowIndex)
    {
        VStockRemainData sData = new VStockRemainData();
        GridViewRow gRow = this.gvMain.Rows[rowIndex];
        sData.BRAND = gRow.Cells[7].Text.Replace("&nbsp;", "");
        sData.CODE = gRow.Cells[3].Text;
        sData.LOID = Convert.ToDouble(gRow.Cells[0].Text);
        sData.LOTNO = gRow.Cells[4].Text.Replace("&nbsp;", "");
        sData.MATERIALMASTER = Convert.ToDouble(gRow.Cells[8].Text);
        sData.MATERIALNAME = gRow.Cells[5].Text.Replace("&quot;", "");
        sData.UNITNAME = gRow.Cells[6].Text;
        sData.UNIT = Convert.ToDouble(gRow.Cells[9].Text);
        return sData;
    }
    private void doGetList()
    {
        SearchFlow fFlow = new SearchFlow();

        // ตรวจสอบเงื่อนไขการค้นหาเพื่อแสดงปุ่ม reset การค้นหา
        imbReset.Visible = ((this.cmbWarehouse.Enabled && this.cmbWarehouse.SelectedIndex !=0) || this.cmbSearchMaterial.SelectedIndex != 0) || (txtSearchMaterialName.Text.Trim() != "");

        string orderStr = "";
        if (txhSortField.Text.Trim() != "")
            orderStr = " " + txhSortField.Text + " " + txhSortDir.Text;
        gvMain.DataSource = fFlow.GetStockRemainList(Convert.ToDouble(this.cmbWarehouse.SelectedItem.Value), this.txtSearchMaterialName.Text.Trim(), Convert.ToDouble(this.cmbSearchMaterial.SelectedItem.Value), this.txtExistKeyList.Text, orderStr);
        gvMain.DataBind();
        pcBot.Update();
        pcTop.Update();
    }

    #endregion
}

