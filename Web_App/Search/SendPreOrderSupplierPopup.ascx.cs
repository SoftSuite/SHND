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
/// SendPreOrderSupplier Page Class
/// Version 1.0
/// =========================================================================
/// Create by: Kug
/// Create Date: 26 May 2009
/// -------------------------------------------------------------------------
/// Modify By: -
/// Modify From: -
/// Modify Date: -
/// -------------------------------------------------------------------------
/// Remark: -
/// Description:
///    หน้าค้นหา รายการวัสดุอาหารที่ส่งคืนในขั้นตอนการสั่งซื้อล่วงหน้า
/// Changes:
///    1.0 - สร้าง
/// -------------------------------------------------------------------------
/// =========================================================================
/// </summary>
/// 



public partial class Search_SendPreOrderSupplierPopup : System.Web.UI.UserControl
{
    public delegate void SelectedIndexChangedEvent(object sender, EventArgs e, ArrayList SelectedData);
    public event SelectedIndexChangedEvent SelectedIndexChanged;

    public delegate void CancelEvent(object sender, EventArgs e);
    public event CancelEvent Cancel;

    public event EventHandler SearchClick;
    public event EventHandler ResetClick;

    protected void Page_Load(object sender, EventArgs e)
    {

    }

    protected override void OnInit(EventArgs e)
    {
        base.OnInit(e);
        SetCombo();
        pcBot.SetMainGridView(gvMain);
        pcTop.SetMainGridView(gvMain);
    }

    #region Button Click Event Handler

    protected void tbBackClick(object sender, EventArgs e)
    {
        if (Cancel != null) Cancel(sender, e);
    }

    protected void tbAddClick(object sender, EventArgs e)
    {
        if (SelectedIndexChanged != null) SelectedIndexChanged(sender, e, GetSelectedData());
    }

    protected void imbSearch_Click(object sender, ImageClickEventArgs e)
    {
        gvMain.PageIndex = 0;
        doGetList();
        popupMaterialMaster.Show();
    }

    protected void imbReset_Click(object sender, ImageClickEventArgs e)
    {
        ClearSearch();
        gvMain.PageIndex = 0;
        doGetList();
        popupMaterialMaster.Show();
    }

    #endregion

    #region Gridview Event Handler

    protected void gvMain_RowDataBound(object sender, GridViewRowEventArgs e)
    {
        if (e.Row.RowType == DataControlRowType.Header)
        {
            ((CheckBox)e.Row.Cells[1].FindControl("chkAll")).Attributes.Add("onclick", "chkAllBox(this, '" + this.gvMain.ClientID + "_ctl', '_chkSelect')");
        }
        else if (e.Row.RowType == DataControlRowType.DataRow)
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
        popupMaterialMaster.Show();
    }

    #endregion

    #region Paging Event Handler

    protected void PageChange(object sender, EventArgs e)
    {
        gvMain.PageIndex = ((Templates_PageControl)sender).SelectedPageIndex;
        doGetList();
        pcBot.Update();
        pcTop.Update();
        popupMaterialMaster.Show();
    }

    #endregion

    #region Misc. Methods

    private ArrayList GetSelectedData()
    {
        ArrayList arrChk = new ArrayList();
        for (int i = 0; i < gvMain.Rows.Count; i++)
        {
            if (i > -1 && gvMain.Rows[i].Cells[0].FindControl("chkSelect") != null)
            {
                GridViewRow gRow = gvMain.Rows[i];
                if (((CheckBox)gRow.Cells[1].FindControl("chkSelect")).Checked)
                {
                    VSendPreOrderSupplierPopupData VStockOut = new VSendPreOrderSupplierPopupData();
                    
                    VStockOut.MATERIALMASTER = Convert.ToDouble("0" + gRow.Cells[0].Text);
                    VStockOut.MATERIALCODE = gRow.Cells[3].Text;
                    VStockOut.MATERIALNAME = gRow.Cells[4].Text;
                    VStockOut.UNITNAME = gRow.Cells[5].Text;
                    VStockOut.UNIT = Convert.ToDouble("0" + gRow.Cells[6].Text);
                    VStockOut.CODE = gRow.Cells[7].Text;
                    VStockOut.SAPCODE = gRow.Cells[8].Text;
                    VStockOut.CLASSLOID = Convert.ToDouble("0" + gRow.Cells[9].Text);
                    VStockOut.GROUPLOID = Convert.ToDouble("0" + gRow.Cells[10].Text);
                    VStockOut.CLASSNAME = gRow.Cells[11].Text;
                    VStockOut.GROUPNAME = gRow.Cells[12].Text;
                    VStockOut.SPEC = gRow.Cells[13].Text;
                    VStockOut.PRICE = Convert.ToDouble(gRow.Cells[14].Text);
                    VStockOut.PLANORDER = Convert.ToDouble(gRow.Cells[15].Text);
                    VStockOut.PLANQTY = Convert.ToDouble(gRow.Cells[16].Text);
                    VStockOut.ORDERQTY = Convert.ToDouble(gRow.Cells[17].Text);
                    VStockOut.SUPPLIER = Convert.ToDouble("0" + gRow.Cells[18].Text);
                    VStockOut.SUPPLIERNAME = gRow.Cells[19].Text;
                    arrChk.Add(VStockOut);
                }
            }
        }
        return arrChk;
    }

    #endregion

    #region Controls Management Methods

    private void ClearSearch()
    {
        if (this.cmbSearchMasterGroup.Enabled) this.cmbSearchMasterGroup.SelectedIndex = 0;
        this.cmbSearchMaterialClass.SelectedIndex = 0;
        this.cmbSearchMasterGroup.SelectedIndex = 0;
        this.txtSearchName.Text = "";
    }

    public void Show()
    {
        VSendPreOrderSupplierPopupData condition = new VSendPreOrderSupplierPopupData();
        Show(condition);
    }

    public void Show(VSendPreOrderSupplierPopupData condition)
    {
        this.txtExistCodeList.Text = condition.CODE ;
        this.cmbSearchMaterialClass.SelectedValue = condition.CLASSLOID.ToString();
        this.txtSupplier.Text = condition.SUPPLIER.ToString();
        this.txtPlan.Text = condition.PLANORDER.ToString();

        //SetCombo();
        ClearSearch();

        gvMain.PageIndex = 0;
        doGetList();
        popupMaterialMaster.Show();
    }

    #endregion

    #region Working Method

    public void SetCombo()
    {
        Appz.BuildCombo(this.cmbSearchMaterialClass, "MATERIALCLASS", "NAME", "LOID", " ACTIVE = '1'", "NAME", "ทั้งหมด", "0", false);
        Appz.BuildCombo(this.cmbSearchMasterGroup, "MATERIALGROUP", "NAME", "LOID", " ACTIVE = '1'", "NAME", "ทั้งหมด", "0", false);

    }
    private void doGetList()
    {
        SearchFlow fFlow = new SearchFlow();

        // ตรวจสอบเงื่อนไขการค้นหาเพื่อแสดงปุ่ม reset การค้นหา
        imbReset.Visible = (this.cmbSearchMasterGroup.SelectedIndex != 0) || (this.cmbSearchMaterialClass.SelectedIndex != 0) || (this.cmbSearchMasterGroup.SelectedIndex != 0) || (txtSearchName.Text.Trim() != "");

        string orderStr = "";
        if (txhSortField.Text.Trim() != "")
            orderStr = " " + txhSortField.Text + " " + txhSortDir.Text;
        VSendPreOrderSupplierPopupData condition = new VSendPreOrderSupplierPopupData();
        condition.CLASSLOID = Convert.ToDouble(this.cmbSearchMaterialClass.SelectedItem.Value);
        condition.GROUPLOID = Convert.ToDouble(this.cmbSearchMasterGroup.SelectedItem.Value);
        condition.MATERIALNAME = this.txtSearchName.Text.Trim();
        condition.SUPPLIER = Convert.ToDouble(this.txtSupplier.Text.Trim());
        condition.PLANORDER = Convert.ToDouble(this.txtPlan.Text.Trim());
        condition.CODE = this.txtExistCodeList.Text;

        gvMain.DataSource = fFlow.GetSendPreOrderSupplierList(condition,  orderStr);
        gvMain.DataBind();
        pcBot.Update();
        pcTop.Update();
    }

    #endregion

}
