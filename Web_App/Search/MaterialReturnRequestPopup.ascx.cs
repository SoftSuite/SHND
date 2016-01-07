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
/// MaterialStockInToolsPopup Page Class
/// Version 1.0
/// =========================================================================
/// Create by: Somsakoon
/// Create Date: 2 Mar 2009
/// -------------------------------------------------------------------------
/// Modify By: -
/// Modify From: -
/// Modify Date: -
/// -------------------------------------------------------------------------
/// Remark: -
/// Description:
///    หน้าค้นหา ข้อมูลวัสดุ (V_ReturnRequest_Popup)
/// Changes:
///    1.0 - สร้าง
/// -------------------------------------------------------------------------
/// =========================================================================
/// </summary>
/// 

public partial class Search_MaterialReturnRequestPopup : System.Web.UI.UserControl
{
    public delegate void SelectedIndexChangedEvent(object sender, EventArgs e, ArrayList SelectedData);
    public event SelectedIndexChangedEvent SelectedIndexChanged;

    protected void Page_Load(object sender, EventArgs e)
    {

    }

    protected override void OnInit(EventArgs e)
    {
        base.OnInit(e);
        Appz.BuildCombo(cmbDivision, "DIVISION", "NAME", "LOID", "", "NAME", "", "0", false);
        pcBot.SetMainGridView(gvMain);
        pcTop.SetMainGridView(gvMain);
    }

    #region Button Click Event Handler

    protected void tbBackClick(object sender, EventArgs e)
    {
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
            txhSortField.Text = "CLASSNAME, GROUPNAME, MATERIALNAME";
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
                    VRetrunRequestPopupData VRetrunRequestPopup = new VRetrunRequestPopupData();
                    VRetrunRequestPopup.MATERIALMASTER = Convert.ToDouble("0" + gRow.Cells[0].Text);
                    VRetrunRequestPopup.MATERIALCODE = gRow.Cells[3].Text;
                    VRetrunRequestPopup.MATERIALNAME = gRow.Cells[4].Text;
                    VRetrunRequestPopup.UNITNAME = gRow.Cells[5].Text;
                    VRetrunRequestPopup.QTY = Convert.ToDouble("0" + gRow.Cells[6].Text);
                    VRetrunRequestPopup.UNIT = Convert.ToDouble("0" + gRow.Cells[7].Text);
                    
                    arrChk.Add(VRetrunRequestPopup);
                }
            }
        }
        return arrChk;
    }

    #endregion

    #region Controls Management Methods

    private void ClearSearch()
    {
        this.txtDivision.Text = "";
        this.txtSearchName.Text = "";
        txhSortField.Text = "";
    }
    /// <summary>
    /// ค้นหาวัสดุอาหาร 
    /// </summary>
    /// <param name="existKeyList">MATERIALMASTER.LOID ที่มีอยู่</param>
    //public void Show(string existKeyList)
    //{
    //    Appz.BuildCombo(this.cmbSearchMaterialClass, "MATERIALCLASS", "NAME", "LOID", "MASTERTYPE='FO' AND ACTIVE = '1'", "NAME", "ทั้งหมด", "0", false);
    //    this.txtExistKeyList.Text = existKeyList;
    //    ClearSearch();

    //    gvMain.PageIndex = 0;
    //    doGetList();
    //    popupMaterialMaster.Show();
    //}

    /// <summary>
    /// ค้นหาวัสดุอื่นๆที่ไม่ใช่วัสดุอาหาร ตามหมวดหมู่ที่ระบุ
    /// </summary>
    /// <param name="materialClassID">หมวดหมู่วัสดุ</param>
    /// <param name="existKeyList">MATERIALMASTER.LOID ที่มีอยู่</param>
    //public void Show(double materialClassID, string existKeyList)
    //{
    //    Appz.BuildCombo(this.cmbSearchMaterialClass, "MATERIALCLASS", "NAME", "LOID", "MASTERTYPE<>'FO' AND ACTIVE = '1'", "NAME", "ทั้งหมด", "0", false);
    //    this.txtExistKeyList.Text = existKeyList;
    //    ClearSearch();
    //    this.cmbSearchMaterialClass.SelectedIndex = this.cmbSearchMaterialClass.Items.IndexOf(this.cmbSearchMaterialClass.Items.FindByValue(materialClassID.ToString()));
    //    this.cmbSearchMaterialClass.Enabled = false;

    //    gvMain.PageIndex = 0;
    //    doGetList();
    //    popupMaterialMaster.Show();
    //}

    public void Show(double division, double warehouse, string existCodeList)
    {
        this.txtDocType.Text = "";
        this.txtType.Text = "";
        if (division == 0) division = Appz.LoggedOnUser.DIVISION;
        this.txtDivision.Text = division.ToString ();
        this.txtSearchName.Text = "";
        this.cmbDivision.SelectedIndex = cmbDivision.Items.IndexOf(cmbDivision.Items.FindByValue(division.ToString()));
        this.txtExistCodeList.Text = existCodeList;
        this.txtWarehouse.Text = warehouse.ToString();
        //this.txtExistMaterialMasterList.Text = existMaterialMasterList;

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
        imbReset.Visible = (this.txtSearchName.Text != "");

        string orderStr = "";
        if (txhSortField.Text.Trim() != "")
            orderStr = " " + txhSortField.Text + " " + txhSortDir.Text;


        gvMain.DataSource = fFlow.GetMaterialReturnRequestList((Convert.ToDouble(this.cmbDivision.SelectedItem .Value)), Convert.ToDouble(this.txtWarehouse.Text), this.txtSearchName.Text.Trim(), this.txtExistCodeList.Text, orderStr);
        gvMain.DataBind();
        pcBot.Update();
        pcTop.Update();
    }

     #endregion

}
