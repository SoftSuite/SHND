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
/// Create by: Tan
/// Create Date: 1 April 2009
/// -------------------------------------------------------------------------
/// Modify By: -
/// Modify From: -
/// Modify Date: -
/// -------------------------------------------------------------------------
/// Remark: -
/// Description:
///    หน้าค้นหา ข้อมูลรายการวัสดุที่สั่งซื้อ (PO)
/// Changes:
///    1.0 - สร้าง
/// -------------------------------------------------------------------------
/// =========================================================================
/// </summary>
/// 

public partial class Search_POPopup : System.Web.UI.UserControl
{
    public delegate void SelectedIndexChangedEvent(object sender, EventArgs e, VPOData SelectedData);
    public event SelectedIndexChangedEvent SelectedIndexChanged;

    protected void Page_Load(object sender, EventArgs e)
    {

    }

    protected override void OnInit(EventArgs e)
    {
        base.OnInit(e);
        Appz.BuildCombo(this.cmbMaterialClass, "MATERIALCLASS", "NAME", "LOID","", "NAME", "ทั้งหมด", "0", false);
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
        popupPO.Show();
    }

    protected void imbReset_Click(object sender, ImageClickEventArgs e)
    {
        ClearSearch();
        gvMain.PageIndex = 0;
        doGetList();
        popupPO.Show();
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
        popupPO.Show();
    }

    #endregion

    #region Paging Event Handler

    protected void PageChange(object sender, EventArgs e)
    {
        gvMain.PageIndex = ((Templates_PageControl)sender).SelectedPageIndex;
        doGetList();
        pcBot.Update();
        pcTop.Update();
        popupPO.Show();
    }

    #endregion


    #region Controls Management Methods

    private void ClearSearch()
    {
        txtCodeFrom.Text = "";
        txtCodeTo.Text = "";
        ctlDateFrom.DateValue = new DateTime();
        ctlDateTo.DateValue = new DateTime();
        ctlUsedateFrom.DateValue = new DateTime();
        ctlUsedateTo.DateValue = new DateTime();
        cmbMaterialClass.SelectedValue = "0";
    }

    public void Show()
    {
        //this.txtExistKeyList.Text = existKeyList;
        ClearSearch();

        gvMain.PageIndex = 0;
        doGetList();
        popupPO.Show();
    }

    #endregion

    #region Working Method

    private VPOData GetSelectedData(int rowIndex)
    {
        VPOData sData = new VPOData();
        GridViewRow gRow = this.gvMain.Rows[rowIndex];
        sData.PREPO = Convert.ToDouble(gRow.Cells[0].Text);
        sData.PREPOCODE = gRow.Cells[3].Text;
        sData.USEDATE = Convert.ToDateTime(gRow.Cells[4].Text);
        sData.CLASSNAME = gRow.Cells[5].Text;
        sData.MATERIALCLASS = Convert.ToDouble(gRow.Cells[6].Text);
        sData.SUPPLIER = Convert.ToDouble(gRow.Cells[7].Text);
        sData.SUPPLIERCODE = gRow.Cells[8].Text;
        sData.SUPPLIERNAME = gRow.Cells[9].Text;

        return sData;
    }
    private void doGetList()
    {
        SearchFlow fFlow = new SearchFlow();

        // ตรวจสอบเงื่อนไขการค้นหาเพื่อแสดงปุ่ม reset การค้นหา
        imbReset.Visible = (cmbMaterialClass.SelectedValue != "0") || (txtCodeFrom.Text != "") || (txtCodeTo.Text != "") || (ctlDateFrom.DateValue.Year != 1) || (ctlDateTo.DateValue.Year != 1) || (ctlUsedateFrom.DateValue.Year != 1) || (ctlUsedateTo.DateValue.Year != 1);

        string orderStr = "";
        if (txhSortField.Text.Trim() != "")
            orderStr = " " + txhSortField.Text + " " + txhSortDir.Text;
        gvMain.DataSource = fFlow.GetPOPopupList(txtCodeFrom.Text,txtCodeTo.Text,ctlDateFrom.DateValue,ctlDateTo.DateValue,ctlUsedateFrom.DateValue,ctlUsedateTo.DateValue,Convert.ToDouble(cmbMaterialClass.SelectedValue), orderStr);
        gvMain.DataBind();
        pcBot.Update();
        pcTop.Update();
    }

    #endregion
}

