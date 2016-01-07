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
/// SendSupplier Page Class
/// Version 1.0
/// =========================================================================
/// Create by: Nang
/// Create Date: 2 Mar 2009
/// -------------------------------------------------------------------------
/// Modify By: -
/// Modify From: -
/// Modify Date: -
/// -------------------------------------------------------------------------
/// Remark: -
/// Description:
///    หน้าค้นหา รายการที่ส่งคืนร้านค้า (Material Master)
/// Changes:
///    1.0 - สร้าง
/// -------------------------------------------------------------------------
/// =========================================================================
/// </summary>
/// 



public partial class Search_SendSupplierPopup : System.Web.UI.UserControl
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
        popupSendSupplier.Show();
        if (SearchClick != null) SearchClick(sender, e);
    }

    protected void imbReset_Click(object sender, ImageClickEventArgs e)
    {
        ClearSearch();
        gvMain.PageIndex = 0;
        doGetList();
        popupSendSupplier.Show();
        if (ResetClick != null) ResetClick(sender, e);
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
        popupSendSupplier.Show();
    }

    #endregion

    #region Paging Event Handler

    protected void PageChange(object sender, EventArgs e)
    {
        gvMain.PageIndex = ((Templates_PageControl)sender).SelectedPageIndex;
        doGetList();
        pcBot.Update();
        pcTop.Update();
        popupSendSupplier.Show();
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
                    VStockoutReturenPopUpData VStockOut = new VStockoutReturenPopUpData();
                    VStockOut.LOID = Convert.ToDouble("0" + gRow.Cells[0].Text);
                    VStockOut.MATERIALCODE = gRow.Cells[3].Text;
                    VStockOut.MATERIALNAME = gRow.Cells[4].Text;
                    VStockOut.UNITNAME = gRow.Cells[5].Text;
                    VStockOut.UNIT = Convert.ToDouble("0" + gRow.Cells[6].Text);
                    VStockOut.CODE = gRow.Cells[7].Text;
                    VStockOut.MATERIALMASTER = Convert.ToDouble("0" + gRow.Cells[8].Text);
                    VStockOut.SAPCODE = gRow.Cells[9].Text;
                    VStockOut.MASTERTYPE = gRow.Cells[10].Text;
                    VStockOut.MASTERTYPENAME = Convert.ToString(gRow.Cells[11].Text.Trim());
                    VStockOut.CLASSLOID = Convert.ToDouble("0" + gRow.Cells[12].Text);
                    VStockOut.GROUPLOID = Convert.ToDouble("0" + gRow.Cells[13].Text);
                    VStockOut.CLASSNAME = gRow.Cells[14].Text;
                    VStockOut.GROUPNAME = gRow.Cells[15].Text;
                    VStockOut.SPEC = gRow.Cells[16].Text;
                    VStockOut.PRICE = Convert.ToDouble(gRow.Cells[17].Text);
                    VStockOut.PLANORDER = Convert.ToDouble(gRow.Cells[18].Text);
                    VStockOut.PLANQTY = Convert.ToDouble(gRow.Cells[19].Text);
                    VStockOut.STOCKINQTY = Convert.ToDouble(gRow.Cells[20].Text);
                    VStockOut.PLANREMAIN = Convert.ToDouble(gRow.Cells[21].Text);
                    VStockOut.SUPPLIER = Convert.ToDouble("0" + gRow.Cells[22].Text);
                    VStockOut.SUPPLIERNAME = gRow.Cells[23].Text;
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
        Show("","","","");
    }

    public void ShowOnly()
    {
        popupSendSupplier.Show();
    }

    public void Show(string existKeyList,string exitSupplier, string warehouse, string planorder)
    {
        this.txtExistKeyList.Text = existKeyList;
        this.txtExitSupplier.Text = exitSupplier;
        this.txtWarehouse.Text = warehouse;
        this.txtPlan.Text = planorder;
        SetCombo();
        ClearSearch();

        gvMain.PageIndex = 0;
        doGetList();
        popupSendSupplier.Show();
    }

    #endregion

    #region Working Method

    public void SetCombo()
    {
        Appz.BuildCombo(this.cmbSearchMaterialClass, "V_PLANMATERIALCLASS", "CLASSNAME", "MATERIALCLASS", " PLANORDER = " + this.txtPlan.Text + "", "CLASSNAME", "ทั้งหมด", "0",true);
        Appz.BuildCombo(this.cmbSearchMasterGroup, "MATERIALGROUP", "NAME", "LOID", " ACTIVE = '1'  AND MATERIALCLASS IN (SELECT MATERIALCLASS FROM V_PLANMATERIALCLASS WHERE PLANORDER = " + this.txtPlan.Text + ")", "NAME", "ทั้งหมด", "0", true);

    }
    private void doGetList()
    {
        SearchFlow fFlow = new SearchFlow();

        // ตรวจสอบเงื่อนไขการค้นหาเพื่อแสดงปุ่ม reset การค้นหา
        imbReset.Visible = (this.cmbSearchMasterGroup.SelectedIndex != 0) || (this.cmbSearchMaterialClass.SelectedIndex != 0) || (this.cmbSearchMasterGroup.SelectedIndex != 0) || (txtSearchName.Text.Trim() != "");

        string orderStr = "";
        if (txhSortField.Text.Trim() != "")
            orderStr = " " + txhSortField.Text + " " + txhSortDir.Text;
        VStockoutReturenPopUpData condition = new VStockoutReturenPopUpData();
        condition.CLASSLOID = Convert.ToDouble(this.cmbSearchMaterialClass.SelectedItem.Value);
        condition.GROUPLOID = Convert.ToDouble(this.cmbSearchMasterGroup.SelectedItem.Value);
        condition.MATERIALNAME = this.txtSearchName.Text.Trim();
        condition.SUPPLIER = Convert.ToDouble("0"+this.txtExitSupplier.Text.Trim());
        condition.WAREHOUSE = Convert.ToDouble("0"+this.txtWarehouse.Text.Trim());
        condition.PLANORDER = Convert.ToDouble("0" + this.txtPlan.Text.Trim());

        gvMain.DataSource = fFlow.GetSendSupplierList(condition, "", this.txtExistKeyList.Text, orderStr);
        gvMain.DataBind();
        pcBot.Update();
        pcTop.Update();
    }

    #endregion
}
