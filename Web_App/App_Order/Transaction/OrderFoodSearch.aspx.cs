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
using SHND.Data.Common.Utilities;
using SHND.Global;
using SHND.Flow.Order;

/// <summary>
/// OrderFoodSearch Page Class
/// Version 1.0
/// =========================================================================
/// Create by: Teang
/// Create Date: 10 Mar 2009
/// -------------------------------------------------------------------------
/// Modify By: -
/// Modify From: -
/// Modify Date: -
/// -------------------------------------------------------------------------
/// Remark: -
/// Description:
///    หน้าการทำรายการข้อมูล OrderFoodSearch
/// Changes:
///    1.0 - สร้าง
/// -------------------------------------------------------------------------
/// =========================================================================
/// </summary>
/// 
public partial class App_Order_Transaction_OrderFoodSearch : System.Web.UI.Page
{
    private void SetStatusCombo(DropDownList cmb)
    {
        cmb.Items.Clear();
        cmb.Items.Add(new ListItem("Not Applicable", "00"));
        cmb.Items.Add(new ListItem("Wait", "01"));
        cmb.Items.Add(new ListItem("Finish", "02"));
        cmb.Items.Add(new ListItem("Register", "03"));
        cmb.Items.Add(new ListItem("Non Register", "04"));
        cmb.Items.Add(new ListItem("Discontinue", "05"));
    }

    protected override void OnInit(EventArgs e)
    {
        base.OnInit(e);
        SetStatusCombo(this.cmbSearchStatusFrom);
        SetStatusCombo(this.cmbSearchStatusTo);

        if (Appz.LoggedOnUser.OFFICERGROUP == "A")
        {
            Appz.BuildCombo(this.cmbSearchWard, "WARD", "NAME", "LOID", "ACTIVE = '1'", "NAME", "ทั้งหมด", "0", false);
            this.cmbWardDefault.Items.Clear();
            this.cmbWardDefault.Items.Add(new ListItem("ทั้งหมด", "0"));
        }
        else
        {
            Appz.BuildCombo(this.cmbWardDefault, "V_WARDRESPONSE", "WARDNAME", "WARD", "OFFICER = " + Appz.LoggedOnUser.LOID.ToString() + " AND ISDEFAULT = '1'", "", null, null, false);
            Appz.BuildCombo(this.cmbSearchWard, "V_WARDRESPONSE", "WARDNAME", "WARD", "OFFICER = " + Appz.LoggedOnUser.LOID.ToString() + " AND ACTIVE = '1'", "PRIORITY", null, null, false);

        }

        pcTop.SetMainGridView(gvMain);
        pcBot.SetMainGridView(gvMain);
        pcTop.Visible = false;
        pcBot.Visible = false;
        ClearSearch();

    }

    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            if (this.cmbSearchWard.Items.Count == 0)
            {
                this.cmbSearchWard.Items.Clear();
                this.cmbSearchWard.Items.Add(new ListItem("เลือก", "-1"));
            }
            else
            {
                this.cmbSearchWard.SelectedValue = cmbWardDefault.SelectedValue;
            }

            if (Appz.LoggedOnUser.OFFICERGROUP != "A")
            {
                doGetList();
            }
            
        }
    }

    #region Button Click Event Handler

    protected void imbSearch_Click(object sender, ImageClickEventArgs e)
    {
        gvMain.PageIndex = 0;
        doGetList();

        if (gvMain.Rows.Count == 0)
        {
            pcTop.Visible = false;
            pcBot.Visible = false;
        }
    }

    protected void imbReset_Click(object sender, ImageClickEventArgs e)
    {
        ClearSearch();
        gvMain.PageIndex = 0;
        imbReset.Visible = false;
        gvMain.Visible = false;
        pcTop.Visible = false;
        pcBot.Visible = false;

        //doGetList();
    }

    protected void lnkAN_Click(object sender, EventArgs e)
    {
        Response.Redirect(Constant.HomeFolder + "App_Order/Transaction/OrderFood.aspx?loid=" + ((LinkButton)sender).CommandArgument);
    }

    #endregion

    #region Gridview Event Handler

    protected void gvMain_RowDataBound(object sender, GridViewRowEventArgs e)
    {
        if (e.Row.RowIndex > -1)
        {
            e.Row.Cells[2].Text = ((e.Row.RowIndex + 1) + (gvMain.PageIndex * gvMain.PageSize)).ToString();
        }
        if (e.Row.RowType == DataControlRowType.DataRow)
        {
            DataRow drow = (DataRow)((DataRowView)e.Row.DataItem).Row;

            if (drow["STATUSRANK"].ToString() == "03")
                e.Row.Cells[1].BackColor = System.Drawing.Color.White;
            else if (drow["STATUSRANK"].ToString() == "02")
                e.Row.Cells[1].BackColor = System.Drawing.Color.LightGreen;
            else if (drow["STATUSRANK"].ToString() == "01")
                e.Row.Cells[1].BackColor = System.Drawing.Color.Gold;
            else if (drow["STATUSRANK"].ToString() == "00")
                e.Row.Cells[1].BackColor = System.Drawing.Color.Coral;

            if (drow["BIRTHDATE"].ToString() != "")
            {
                if (Convert.ToDateTime(drow["BIRTHDATE"]).ToString("MMdd") == DateTime.Today.AddDays(1).ToString("MMdd"))
                e.Row.Cells[10].BackColor = System.Drawing.Color.Gold;
            else if (Convert.ToDateTime(drow["BIRTHDATE"]).ToString("MMdd") == DateTime.Today.ToString("MMdd"))
                e.Row.Cells[10].ForeColor = System.Drawing.Color.Red;
            }


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
        //doGetList();
        gvMain.DataSource = Cache["OrderFoodSearch"];
        gvMain.DataBind();
        pcBot.Update();
        pcTop.Update();
    }
    #endregion

    #region Controls Management Methods

    private void ClearSearch()
    {
        // Clear searh data
        this.cmbSearchWard.SelectedValue = cmbWardDefault.SelectedValue;
        this.txtSearchWardName.Text = "";
        this.ctlSearchAdmitDateFrom.DateValue = new DateTime();
        this.ctlSearchAdmitDateTo.DateValue = new DateTime();
        this.txtSearchHN.Text = "";
        this.txtSearchAN.Text = "";
        this.txtSearchPatientName.Text = "";
        cmbSearchStatusFrom.SelectedIndex = 0;
        cmbSearchStatusTo.SelectedIndex = cmbSearchStatusTo.Items.Count - 1;
        this.chkIsAdmit.Checked = true;
        //gvMain.Visible = false;
        

    }

    #endregion

    #region Working Method

    private void doGetList()
    {
        OrderFoodFlow fFlow = new OrderFoodFlow();
        // ตรวจสอบเงื่อนไขการค้นหาเพื่อแสดงปุ่ม reset การค้นหา
        imbReset.Visible = (cmbSearchWard.SelectedValue != cmbWardDefault.SelectedValue) || (this.txtSearchWardName.Text.Trim() != "") || (this.ctlSearchAdmitDateFrom.DateValue.Year != 1) ||
            (this.ctlSearchAdmitDateTo.DateValue.Year != 1) || (txtSearchHN.Text.Trim() != "") || (this.txtSearchAN.Text.Trim() != "") || (this.txtSearchPatientName.Text.Trim() != "") ||
            (cmbSearchStatusFrom.SelectedIndex != 0) || (cmbSearchStatusTo.SelectedIndex != cmbSearchStatusTo.Items.Count - 1) || !this.chkIsAdmit.Checked;

        string orderStr = "";
        if (txhSortField.Text.Trim() != "")
            orderStr = " " + txhSortField.Text + " " + txhSortDir.Text;
        else
            orderStr = " STATUSRANK,ROOMNO,BEDNO";

        Cache["OrderFoodSearch"] = fFlow.GetMasterList(Convert.ToDouble(this.cmbSearchWard.SelectedItem.Value), this.txtSearchWardName.Text.Trim(), this.ctlSearchAdmitDateFrom.DateValue,
            this.ctlSearchAdmitDateTo.DateValue, this.txtSearchHN.Text.Trim(), this.txtSearchAN.Text.Trim(), this.txtSearchPatientName.Text.Trim(), this.chkIsAdmit.Checked,
            this.cmbSearchStatusFrom.SelectedItem.Value, this.cmbSearchStatusTo.SelectedItem.Value, Appz.LoggedOnUser.LOID, Appz.LoggedOnUser.OFFICERGROUP, orderStr);
        gvMain.DataSource = Cache["OrderFoodSearch"];
        gvMain.DataBind();
        gvMain.Visible = true;
        pcTop.Update();
        pcBot.Update();
        this.imbPrint.Visible = (this.gvMain.Rows.Count > 0);
        this.imbPrint.OnClientClick = Appz.OpenReportScript(Constant.Reports.OrderFoodReport, "paramfield1=STATUSRANKFROM&paramvalue1=" + this.cmbSearchStatusFrom.SelectedItem.Value +
            "&paramfield2=STATUSRANKTO&paramvalue2=" + this.cmbSearchStatusTo.SelectedItem.Value +
            "&paramfield3=WARD&paramvalue3=" + this.cmbSearchWard.SelectedItem.Value +
            "&paramfield4=WARDNAME&paramvalue4=" + this.txtSearchWardName.Text.Trim() +
            "&paramfield5=ADMITDATEFROM&paramvalue5=" + this.ctlSearchAdmitDateFrom.DateValue.Year.ToString("0000") + this.ctlSearchAdmitDateFrom.DateValue.ToString("MMdd") +
            "&paramfield6=ADMITDATETO&paramvalue6=" + this.ctlSearchAdmitDateTo.DateValue.Year.ToString("0000") + this.ctlSearchAdmitDateTo.DateValue.ToString("MMdd") +
            "&paramfield7=HN&paramvalue7=" + this.txtSearchHN.Text.Trim() +
            "&paramfield8=AN&paramvalue8=" + this.txtSearchAN.Text.Trim() +
            "&paramfield9=PATIENTNAME&paramvalue9=" + this.txtSearchPatientName.Text.Trim() +
            "&paramfield10=PATIENTSTATUS&paramvalue10=" + (this.chkIsAdmit.Checked ? "AD" : ""), true);
    }

    #endregion
}
