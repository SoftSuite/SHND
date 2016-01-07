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
using SHND.Flow.Order;
using SHND.Data.Views;
using SHND.Global;
using SHND.Flow.Common;
using SHND.Data.Common.Utilities;

/// <summary>
/// FoodType Page Class
/// Version 1.0
/// =========================================================================
/// Create by: Tan
/// Create Date: 10 Feb 2009
/// -------------------------------------------------------------------------
/// Modify By: -
/// Modify From: -
/// Modify Date: -
/// -------------------------------------------------------------------------
/// Remark: -
/// Description:
///    หน้ากาารทำงานข้อมูล Order Party 
/// Changes:
///    1.0 - สร้าง
/// -------------------------------------------------------------------------
/// =========================================================================
/// </summary>
/// 

public partial class App_Order_Transaction_OrderPartyDirector : System.Web.UI.Page
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
        pcTop.SetMainGridView(gvMain);
        pcBot.SetMainGridView(gvMain);
        Appz.BuildCombo(ddlTitle, "TITLE", "NAME", "LOID", "ACTIVE='1'", "NAME", "เลือก", "0", false);
        Appz.BuildCombo(ddlPartyType, "PARTYTYPE", "NAME", "LOID", "ACTIVE='1'", "NAME", "เลือก", "0", false);
        SetStatusCombo(cmbStatusFrom);
        SetStatusCombo(cmbStatusTo);
        ClearSearch();
        // ControlUtil.SetIntTextBox(txtTel);
        ControlUtil.SetIntTextBox(txtQty);
    }

    #region Button Click Event Handler

    protected void linkCode_Click(object sender, EventArgs e)
    {
        doGetDetail(((LinkButton)sender).CommandArgument);
        zPop.Show();
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

    protected void tbCommitClick(object sender, EventArgs e)
    {
        doCommit();
    }
    protected void tbSaveClick(object sender, EventArgs e)
    {
        doSave();
    }
    protected void tbCancelClick(object sender, EventArgs e)
    {
        doGetDetail("0" + this.txtLOID.Text);
    }
    protected void tbBackClick(object sender, EventArgs e)
    {
        ClearSearch();
        gvMain.PageIndex = 0;
        doGetList();
    }
    //protected void tbPrintClick(object sender, EventArgs e)
    //{
    //}
    protected void tbApprovePOPClick(object sender, EventArgs e)
    {
        doApprove();
    }


    #endregion

    #region Gridview Event Handler

    protected void gvMain_RowDataBound(object sender, GridViewRowEventArgs e)
    {
        if (e.Row.RowIndex > -1)
            e.Row.Cells[2].Text = ((e.Row.RowIndex + 1) + (gvMain.PageIndex * gvMain.PageSize)).ToString();
        if (e.Row.RowType == DataControlRowType.DataRow)
        {
            DataRow drow = (DataRow)((DataRowView)e.Row.DataItem).Row;
            CheckBox chk = (CheckBox)e.Row.Cells[1].FindControl("chkSelect");
            chk.Enabled = (drow["STATUS"].ToString() != "AP");

            if (drow["STATUS"].ToString() == "WA")
                e.Row.BackColor = System.Drawing.Color.White;
            else if (drow["STATUS"].ToString() == "FN")
                e.Row.BackColor = System.Drawing.Color.Gold;
            else if ((drow["STATUS"].ToString() == "AP" & drow["DIRECTORAPPROVE"].ToString() == "Y") || (drow["STATUS"].ToString() == "RG" & drow["NDAPPROVE"].ToString() == "Y"))
                e.Row.BackColor = System.Drawing.Color.LightGreen;
            else if ((drow["STATUS"].ToString() == "AP" & drow["DIRECTORAPPROVE"].ToString() == "N") || (drow["STATUS"].ToString() == "RG" & drow["NDAPPROVE"].ToString() == "N") || drow["STATUS"].ToString() == "DC")
                e.Row.BackColor = System.Drawing.Color.Coral;
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
        txtCodeFrom.Text = "";
        txtCodeTo.Text = "";
        cmbStatusFrom.SelectedValue = "01";
        cmbStatusTo.SelectedValue = "01";

    }
    private void BindOrderParty()
    {
        this.gvItem.DataBind();
    }

    private void SetErrorStatusOrderPartyItem(string t)
    {
        lbStatusOrderPartyItem.Text = t;
        lbStatusOrderPartyItem.ForeColor = Constant.StatusColor.Error;
    }

    private void SetStatusOrderPartyItem(string t)
    {
        lbStatusOrderPartyItem.Text = t;
        lbStatusOrderPartyItem.ForeColor = Constant.StatusColor.Information;
    }

    private void SetStatus(string t)
    {
        lbStatus.Text = t;
        lbStatus.ForeColor = Constant.StatusColor.Information;
    }

    private void SetErrorStatus(string t)
    {
        lbStatus.Text = t;
        lbStatus.ForeColor = Constant.StatusColor.Error;
        zPop.Show();
    }

    private void SetStatusCombo(DropDownList cmbStatus)
    {
        cmbStatus.Items.Clear();
        cmbStatus.Items.Add(new ListItem("เสนอเพื่อโปรดพิจารณา", "01"));
        cmbStatus.Items.Add(new ListItem("ผู้อำนวยการอนุมัติ", "02"));
        cmbStatus.Items.Add(new ListItem("ผู้อำนวยการไม่อนุมัติ", "03"));
        cmbStatus.Items.Add(new ListItem("ฝ่ายโภชนาการรับ Order", "04"));
        cmbStatus.Items.Add(new ListItem("ฝ่ายโภชนาการไม่รับ Order", "05"));
        cmbStatus.Items.Add(new ListItem("ยกเลิกการสั่งอาหาร", "06"));
    }

    private VOrderPartyData GetData()
    {
        VOrderPartyData fsData = new VOrderPartyData();
        fsData.LOID = Convert.ToDouble(txtLOID.Text);
        fsData.DIRECTORAPPROVE = rblDirector.SelectedValue;
        fsData.DIRECTORCOMMENT = txtDirector.Text;
        fsData.STATUS = txtStatus.Text;

        return fsData;
    }

    private void SetData(VOrderPartyData fsData)
    {
        txtLOID.Text = fsData.LOID.ToString();
        txtStatus.Text = fsData.STATUS;
        txtStatusName.Text = fsData.STATUSNAME;
        txtDivision.Text = fsData.DIVISION.ToString();
        txtDivName.Text = fsData.DIVISIONNAME;
        txtCode.Text = fsData.CODE;
        ctlOrderDate.DateValue = fsData.ORDERDATE;
        ddlTitle.SelectedValue = fsData.OTITLE.ToString();
        txtName.Text = fsData.ONAME;
        txtLastName.Text = fsData.OLASTNAME;
        txtTel.Text = fsData.OTEL;
        ctlPartyDate.DateValue = fsData.PARTYDATETIME;
        ddlPartyTime.SelectedValue = fsData.PARTYDATETIME.Hour.ToString();
        ddlPartyType.SelectedValue = fsData.PARTYTYPE.ToString();
        txtQty.Text = fsData.VISITORQTY.ToString();
        txtPlace.Text = fsData.PLACE;
        txtDirector.Text = fsData.DIRECTORCOMMENT;
        txtOfficer.Text = fsData.NDCOMMENT;
        if (fsData.DIRECTORAPPROVE == "Z")
            rblDirector.SelectedIndex = -1;
        else
            rblDirector.SelectedValue = fsData.DIRECTORAPPROVE;
        if (fsData.NDAPPROVE == "Z")
            rblOfficer.SelectedIndex = -1;
        else
            rblOfficer.SelectedValue = fsData.NDAPPROVE;
        //  this.tbPrint.ClientClick = Appz.OpenReportScript(Constant.Reports.FormulaFeedBDReport, fsData.LOID, false);

        if (fsData.LOID == 0)
        {
            this.txtStatus.Text = "WA";
            this.txtStatusName.Text = "กำลังดำเนินการ";
            this.txtDivision.Text = Appz.LoggedOnUser.DIVISION.ToString();
            this.txtDivName.Text = Appz.LoggedOnUser.DIVISIONNAME;
        }
        if (fsData.STATUS == "AP")
        {
            tbSave.Visible = false;
            tbCancel.Visible = false;
            tbApprovePOP.Visible = false;
        }
        else
        {
            tbSave.Visible = true;
            tbCancel.Visible = true;
            tbApprovePOP.Visible = true;
        }

        OrderPartyItem fsItem = new OrderPartyItem();
        fsItem.ClearOrderPartyItem();
        BindOrderParty();

    }

    #endregion

    #region Working Method

    private void doGetList()
    {
        OrderPartyFlow fFlow = new OrderPartyFlow();

        // ตรวจสอบเงื่อนไขการค้นหาเพื่อแสดงปุ่ม reset การค้นหา
        imbReset.Visible = (txtCodeFrom.Text.Trim() != "") || (txtCodeTo.Text.Trim() != "") || (ctlDateFrom.DateValue.Year != 1) || (ctlDateTo.DateValue.Year != 1) || 
            (cmbStatusFrom.SelectedItem.Value != "01") || (cmbStatusTo.SelectedItem.Value != "01");

        string orderStr = "";
        if (txhSortField.Text.Trim() != "")
            orderStr = " " + txhSortField.Text + " " + txhSortDir.Text;

        gvMain.DataSource = fFlow.GetMasterListDirector(txtCodeFrom.Text, txtCodeTo.Text, ctlDateFrom.DateValue, ctlDateTo.DateValue, cmbStatusFrom.SelectedValue, cmbStatusTo.SelectedValue, orderStr);
        gvMain.DataBind();
        pcTop.Update();
        pcBot.Update();
    }

    private bool doGetDetail(string LOID)
    {
        OrderPartyFlow fFlow = new OrderPartyFlow();
        VOrderPartyData fData = fFlow.GetDetails(Convert.ToDouble(LOID));

        bool ret = true;
        SetData(fData);
        OrderPartyItem fsItem = new OrderPartyItem();
        fsItem.ClearOrderPartyItem();
        BindOrderParty();

        return ret;
    }
    private void doDelete()
    {
        OrderPartyFlow fFlow = new OrderPartyFlow();
        if (fFlow.DeleteByLOID(GetChecked()))
        {
            gvMain.PageIndex = 0;
            doGetList();
            lbStatusMain.Text = "";
        }
        else
        {
            lbStatusMain.Text = fFlow.ErrorMessage;
            lbStatusMain.ForeColor = System.Drawing.Color.Red;
        }

    }
    private void doCommit()
    {
        OrderPartyFlow sFlow = new OrderPartyFlow();
        if (sFlow.CommitByDirector(Appz.CurrentUser, "AP", GetChecked()))
        {
            gvMain.PageIndex = 0;
            doGetList();
            lbStatusMain.Text = sFlow.ErrorMessage;
            lbStatusMain.ForeColor = System.Drawing.Color.Red;
        }
        else
        {
            lbStatusMain.Text = sFlow.ErrorMessage;
            lbStatusMain.ForeColor = System.Drawing.Color.Red;
        }
    }

    private bool doSave()
    {
        //verify required field
        VOrderPartyData Order = GetData();

        OrderPartyFlow ftFlow = new OrderPartyFlow();
        bool ret = true;

        ret = ftFlow.UpdateDataAP(Order, Appz.CurrentUser);

        if (!ret)
            SetErrorStatus(ftFlow.ErrorMessage);
        else
        {
            doGetDetail(ftFlow.LOID.ToString());
            SetStatus(DataResources.MSGIU001);
        }

        zPop.Show();
        return ret;
    }

    private bool doApprove()
    {
        //verify required field
        VOrderPartyData Order = GetData();
        Order.STATUS = "AP";
        string error = VerifyData(Order);
        if (error != "")
        {
            SetErrorStatus(error);
            return false;
        }

        OrderPartyFlow ftFlow = new OrderPartyFlow();
        bool ret = true;

        // data correct go on saving...
        ret = ftFlow.UpdateDataAP(Order, Appz.CurrentUser);

        if (!ret)
            SetErrorStatus(ftFlow.ErrorMessage);
        else
        {
            doGetList();
        }

        return ret;
    }

    private string VerifyData(VOrderPartyData fData)
    {
        string ret = "";
        if (fData.DIRECTORAPPROVE == "Z" || fData.DIRECTORAPPROVE == "")
            ret = string.Format(DataResources.MSGEI001, "ผลการอนุมัติ");

        return ret;
    }
    #endregion
}
