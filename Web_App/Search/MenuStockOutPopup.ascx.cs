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
using SHND.Data.Inventory;
using SHND.Data.Views;
using SHND.Flow.Search;
using SHND.Global;

/// <summary>
/// MenuStockOutPopup Page Class
/// Version 1.0
/// =========================================================================
/// Create by: Teang
/// Create Date: 27 Feb 2009
/// -------------------------------------------------------------------------
/// Modify By: -
/// Modify From: -
/// Modify Date: -
/// -------------------------------------------------------------------------
/// Remark: -
/// Description:
///    หน้าค้นหา ข้อมูลวัสดุ (Material Master)
/// Changes:
///    1.0 - สร้าง
/// -------------------------------------------------------------------------
/// =========================================================================
/// </summary>
/// 
public partial class Search_MenuStockOutPopup : System.Web.UI.UserControl
{
    public delegate void SelectedIndexChangedEvent(object sender, EventArgs e, ArrayList SelectedData);
    public event SelectedIndexChangedEvent SelectedIndexChanged;

    public delegate void CancelEvent(object sender, EventArgs e);
    public event CancelEvent Cancel;

    protected void Page_Load(object sender, EventArgs e)
    {

    }

    protected override void OnInit(EventArgs e)
    {
        base.OnInit(e);
        Appz.BuildCombo(this.cmbSearchDivision, "DIVISION", "NAME", "LOID", "ACTIVE='1'", "NAME", "ทั้งหมด", "0", false);
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
                    VMenuStockOutData vMaterial = new VMenuStockOutData();
                    vMaterial.CLASSLOID = Convert.ToDouble("0" + gRow.Cells[10].Text);
                    vMaterial.CLASSNAME = gRow.Cells[7].Text;
                    vMaterial.CODE = "";
                    vMaterial.COST = Convert.ToDouble("0" + gRow.Cells[6].Text);
                    vMaterial.DIVISION = Convert.ToDouble("0" + gRow.Cells[11].Text);
                    vMaterial.DIVISIONNAME = gRow.Cells[8].Text;
                    vMaterial.FORMULAQTY = Convert.ToDouble("0" + gRow.Cells[13].Text);
                    vMaterial.LASTQTY = Convert.ToDouble("0" + gRow.Cells[15].Text);
                    vMaterial.MATERIALCODE = gRow.Cells[3].Text;
                    vMaterial.MATERIALMASTER = Convert.ToDouble("0" + gRow.Cells[0].Text);
                    vMaterial.MATERIALNAME = gRow.Cells[4].Text;
                    vMaterial.PREQTY = Convert.ToDouble("0" + gRow.Cells[14].Text);
                    vMaterial.PRICE = Convert.ToDouble("0" + gRow.Cells[12].Text);
                    vMaterial.UNIT = Convert.ToDouble("0" + gRow.Cells[9].Text);
                    vMaterial.UNITNAME = gRow.Cells[5].Text;
                    arrChk.Add(vMaterial);
                }
            }
        }
        return arrChk;
    }

    #endregion

    #region Controls Management Methods

    private void ClearSearch()
    {
        if (this.cmbSearchDivision.Enabled) this.cmbSearchDivision.SelectedIndex = 0;
        if (this.cmbSearchMaterialClass.Enabled) this.cmbSearchMaterialClass.SelectedIndex = 0;
        if (this.ctlMenuDate.Enabled) this.ctlMenuDate.DateValue = new DateTime();
        if (this.chkIsBreakfast.Enabled) this.chkIsBreakfast.Checked = true;
        if (this.chkIsLunch.Enabled) this.chkIsLunch.Checked = true;
        if (this.chkIsDinner.Enabled) this.chkIsDinner.Checked = true;
        txhSortField.Text = "DIVISIONNAME, CLASSNAME, MATERIALNAME";
        this.txtSearchName.Text = "";
    }

    public void Show(double docType, double division, DateTime menuDate, bool isBreakfast, bool isLunch, bool isDinner, string existKeyList)
    {
        this.txtExistCodeList.Text = existKeyList;
        Appz.BuildCombo(this.cmbSearchMaterialClass, "MATERIALCLASS", "NAME", "LOID", "ACTIVE = '1' AND MASTERTYPE IN (SELECT MASTERTYPE FROM DOCTYPEMASTERTYPE WHERE DOCTYPE = " + docType.ToString() + ")", "NAME", "ทั้งหมด", "0", false);
        this.txtDocType.Text = docType.ToString();
        ClearSearch();
        this.ctlMenuDate.DateValue = menuDate;
        this.ctlMenuDate.Enabled = false;
        this.cmbSearchDivision.SelectedIndex = this.cmbSearchDivision.Items.IndexOf(this.cmbSearchDivision.Items.FindByValue(division.ToString()));
        this.cmbSearchDivision.Enabled = false;
        this.chkIsBreakfast.Checked = isBreakfast;
        this.chkIsLunch.Checked = isLunch;
        this.chkIsDinner.Checked = isDinner;
        this.chkIsBreakfast.Enabled = false;
        this.chkIsLunch.Enabled = false;
        this.chkIsDinner.Enabled = false;

        gvMain.PageIndex = 0;
        doGetList();
        popupMaterialMaster.Show();
    }

    #endregion

    #region Working Method

    private void doGetList()
    {
        SearchFlow fFlow = new SearchFlow();

        // ตรวจสอบเงื่อนไขการค้นหาเพื่อแสดงปุ่ม reset การค้นหา
        imbReset.Visible = (this.cmbSearchDivision.SelectedIndex != 0 && this.cmbSearchDivision.Enabled) || (this.cmbSearchMaterialClass.SelectedIndex != 0 && this.cmbSearchMaterialClass.Enabled)
            || (this.ctlMenuDate.DateValue.Year != 1 && this.ctlMenuDate.Enabled) || (!this.chkIsBreakfast.Checked && this.chkIsBreakfast.Enabled) || (!this.chkIsLunch.Checked && this.chkIsLunch.Enabled)
            || (!this.chkIsDinner.Checked && this.chkIsDinner.Enabled) || (this.txtSearchName.Text.Trim() != "");

        string orderStr = "";
        if (txhSortField.Text.Trim() != "")
            orderStr = " " + txhSortField.Text + " " + txhSortDir.Text;
        gvMain.DataSource = fFlow.GetMenuItemStockOut(Convert.ToDouble("0" + this.txtDocType.Text), Convert.ToDouble(this.cmbSearchDivision.SelectedItem.Value), 
            this.ctlMenuDate.DateValue, Convert.ToDouble(this.cmbSearchMaterialClass.SelectedItem.Value), this.txtSearchName.Text.Trim(), this.chkIsBreakfast.Checked, 
            this.chkIsLunch.Checked, this.chkIsDinner.Checked, this.txtExistCodeList.Text, orderStr);
        gvMain.DataBind();
        pcBot.Update();
        pcTop.Update();
    }

    #endregion

}

