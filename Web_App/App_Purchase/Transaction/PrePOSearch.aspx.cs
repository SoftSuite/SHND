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
using SHND.Flow.Purchase;
using SHND.Data.Views;
using SHND.Data.Purchase;
using SHND.Global;
using SHND.Flow.Common;
using SHND.Data.Common.Utilities;

/// <summary>
/// FoodType Page Class
/// Version 1.0
/// =========================================================================
/// Create by: Tan
/// Create Date: 6 March 2009
/// -------------------------------------------------------------------------
/// Modify By: -
/// Modify From: -
/// Modify Date: -
/// -------------------------------------------------------------------------
/// Remark: -
/// Description:
///    หน้ากาารทำงานข้อมูล PrePO Search 
/// Changes:
///    1.0 - สร้าง
/// -------------------------------------------------------------------------
/// =========================================================================
/// </summary>
/// 

public partial class App_Purchase_Transaction_PrePOSearch : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            doGetList();
        }
    }

    protected override void OnInit(EventArgs e)
    {
        base.OnInit(e);
        Appz.BuildCombo(this.cmbSearchMaterialClass, "MATERIALCLASS", "NAME", "LOID", "ACTIVE = '1'", "NAME", "ทั้งหมด", "0", false);
        Appz.BuildCombo(this.cmbSearchOrederPlan, "PLANORDER", "NAME", "LOID", "ISPLANFOOD = 'Y' AND STATUS = 'FN' ", "NAME", "เลือก", "0", false);

        SetStatusCombo(cmbSearchStatusFrom);
        SetStatusCombo(cmbSearchStatusTo);
        pcTop.SetMainGridView(gvMain);
        pcBot.SetMainGridView(gvMain);
    }

    #region Button Click Event Handler

    protected void tbAddClick(object sender, EventArgs e)
    {
        Response.Redirect(Constant.HomeFolder + "App_Purchase/Transaction/PrePO.aspx");
    }

    protected void linkCode_Click(object sender, EventArgs e)
    {
        Response.Redirect(Constant.HomeFolder + "App_Purchase/Transaction/PrePO.aspx?loid=" + ((LinkButton)sender).CommandArgument);
    }

    protected void imbSearch_Click(object sender, ImageClickEventArgs e)
    {
        gvMain.PageIndex = 0;
        doGetList();
    }

    protected void imbReset_Click(object sender, ImageClickEventArgs e)
    {
        ClearSearch();
        gvMain.PageIndex = 0;
        doGetList();
    }

    protected void tbDeleteClick(object sender, EventArgs e)
    {
        doDelete();
    }
    protected void tbCommitClick(object sender, EventArgs e)
    {
        doCommit();
    }


    #endregion

    #region Gridview Event Handler

    protected void gvMain_RowDataBound(object sender, GridViewRowEventArgs e)
    {
        if (e.Row.RowIndex > -1)
            e.Row.Cells[1].Text = ((e.Row.RowIndex + 1) + (gvMain.PageIndex * gvMain.PageSize)).ToString();
        if (e.Row.RowType == DataControlRowType.DataRow)
        {
            DataRow drow = (DataRow)((DataRowView)e.Row.DataItem).Row;
            //   CheckBox chk = (CheckBox)e.Row.Cells[1].FindControl("chkSelect");
            //   chk.Enabled = (drow["STATUS"].ToString() != "FN");
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

    }

    #endregion

    #region Paging Event Handler
    protected void PageChange(object sender, EventArgs e)
    {
        gvMain.PageIndex = ((Templates_PageControl)sender).SelectedPageIndex;
        doGetList();
        pcBot.Update();
        pcTop.Update();
    }
    #endregion

    #region Misc. Methods
    private ArrayList GetChecked()
    {
        ArrayList arrChk = new ArrayList();
        for (int i = 0; i < gvMain.Rows.Count; i++)
        {
            if (i > -1 && gvMain.Rows[i].Cells[0].FindControl("chkSelect") != null)
            {
                if (((CheckBox)gvMain.Rows[i].Cells[1].FindControl("chkSelect")).Checked)
                    arrChk.Add(gvMain.Rows[i].Cells[0].Text);
            }
        }

        return arrChk;
    }


    #endregion

    #region Controls Management Methods

    private void ClearSearch()
    {
        // Clear searh data
        txtSearchCodeFrom.Text = "";
        txtSearchCodeTo.Text = "";
        cmbSearchStatusFrom.SelectedValue = "00";
        cmbSearchStatusTo.SelectedValue = "00";
        cmbSearchMaterialClass.SelectedValue = "0";
        txtSearchContractCode.Text = "";
        txtSearchSupplier.Text = "";
        cmbSearchOrederPlan.SelectedValue = "0";
        ctlSearchPODateFrom.DateValue = new DateTime();
        ctlSearchPODateTo.DateValue = new DateTime();
        ctlSearchUseDateFrom.DateValue = new DateTime();
        ctlSearchUseDateTo.DateValue = new DateTime();

    }
    private void SetStatusCombo(DropDownList cmbStatus)
    {
        cmbStatus.Items.Clear();
        cmbStatus.Items.Add(new ListItem("กำลังดำเนินการ", "00"));
        cmbStatus.Items.Add(new ListItem("อนุมัติ", "01"));
        cmbStatus.Items.Add(new ListItem("เสร็จสิ้น", "02"));
    }

    #endregion

    #region Working Method

    private void doGetList()
    {
        PrePOFlow fFlow = new PrePOFlow();

        // ตรวจสอบเงื่อนไขการค้นหาเพื่อแสดงปุ่ม reset การค้นหา
        imbReset.Visible = (txtSearchCodeFrom.Text.Trim() != "") || (txtSearchCodeTo.Text.Trim() != "") ||
            (ctlSearchPODateFrom.DateValue.Year != 1) || (ctlSearchPODateTo.DateValue.Year != 1) ||
            (ctlSearchUseDateFrom.DateValue.Year != 1) || (this.ctlSearchUseDateTo.DateValue.Year != 1) ||
            (cmbSearchMaterialClass.SelectedIndex != 0) || (this.txtSearchContractCode.Text.Trim() != "") ||
            (this.txtSearchSupplier.Text.Trim() != "") || (this.cmbSearchOrederPlan.SelectedIndex != 0) ||
            (this.cmbSearchStatusFrom.SelectedIndex != 0) || (this.cmbSearchStatusTo.SelectedIndex != 0);

        PrePOSearchData pData = new PrePOSearchData();
        pData.CODEFROM = txtSearchCodeFrom.Text;
        pData.CODETO = txtSearchCodeTo.Text;
        pData.PODATEFROM = ctlSearchPODateFrom.DateValue;
        pData.PODATETO = ctlSearchPODateTo.DateValue;
        pData.USEDATEFROM = ctlSearchUseDateFrom.DateValue;
        pData.USEDATETO = ctlSearchUseDateTo.DateValue;
        pData.MATERIALCLASS = Convert.ToDouble(cmbSearchMaterialClass.SelectedValue);
        pData.CONTRACTCODE = txtSearchContractCode.Text;
        pData.SUPPLIERNAME = txtSearchSupplier.Text;
        pData.PLAN = Convert.ToDouble(cmbSearchOrederPlan.SelectedValue);
        pData.STATUSFROM = cmbSearchStatusFrom.SelectedValue;
        pData.STATUSTO = cmbSearchStatusTo.SelectedValue;

        string orderStr = "";
        if (txhSortField.Text.Trim() != "")
            orderStr = " " + txhSortField.Text + " " + txhSortDir.Text;

        gvMain.DataSource = fFlow.GetMasterList(pData, orderStr);
        gvMain.DataBind();
        pcTop.Update();
        pcBot.Update();
    }
    private void doDelete()
    {
        //OrderPartyFlow fFlow = new OrderPartyFlow();
        //if (fFlow.DeleteByLOID(GetChecked()))
        //{
        //    gvMain.PageIndex = 0;
        //    doGetList();
        //    lbStatusMain.Text = "";
        //}
        //else
        //{
        //    lbStatusMain.Text = fFlow.ErrorMessage;
        //    lbStatusMain.ForeColor = System.Drawing.Color.Red;
        //}

    }
    private void doCommit()
    {
        //OrderPartyFlow sFlow = new OrderPartyFlow();
        //if (sFlow.UpdateByLOID(Appz.CurrentUser, "FN", GetChecked()))
        //{
        //    gvMain.PageIndex = 0;
        //    doGetList();
        //    lbStatusMain.Text = "";
        //}
        //else
        //{
        //    lbStatusMain.Text = sFlow.ErrorMessage;
        //    lbStatusMain.ForeColor = System.Drawing.Color.Red;
        //}

    }

    #endregion
}

