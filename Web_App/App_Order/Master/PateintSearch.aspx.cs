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
using SHND.Data.Tables;
using SHND.Data.Order;

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
public partial class App_Order_Master_PateintSearch : System.Web.UI.Page
{
    private void SetStatusCombo(DropDownList cmb)
    {
        cmb.Items.Clear();
        cmb.Items.Add(new ListItem("Admit", "00"));
        cmb.Items.Add(new ListItem("DisCharge", "01"));
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
        doGetDetail(((LinkButton)sender).CommandArgument);
        zPop.Show();
    }

    protected void tbBackClick(object sender, EventArgs e)
    {
        ClearData();
    }

    protected void tbAddClick(object sender, EventArgs e)
    {
        zPop.Show();
    }

    protected void tbSave1Click(object sender, EventArgs e)
    {
        if (!doSave())
            zPop.Show();
        else
            ClearData();
    }
    protected void tbSave2Click(object sender, EventArgs e)
    {
        if (!doSave())
            zPop.Show();
        else
            ClearData();
        zPop.Show();
    }

    protected void tbCancelClick(object sender, EventArgs e)
    {
        if (txtLOID.Text.Trim() == "")
            ClearData();
        else
            doGetDetail(txtLOID.Text);

        zPop.Show();
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

    private void ClearData()
    {
        this.txtLOID.Text = "";
        //this.txtPatientStatus.Text = pData.PATIENTSTATUS;
        this.txtAge.Text = "";
        this.txtAllergic.Text = "";
        this.txtAN.Text = "";
        this.txtBedNo.Text = "";
        this.txtDiagnosis.Text = "";
        this.txtHeight.Text = "";
        this.txtHN.Text = "";
        this.txtPatientName.Text = "";
        this.txtRoomNo.Text = "";
        //this.txtStatusName.Text = "";
        // this.txtWard.Text = pData.WARD.ToString();
        this.txtWardName.Text = "";
        this.txtWeight.Text = "";
        this.ctlAdmitDate.DateValue = new DateTime();
        this.ctlBirthDate.DateValue = new DateTime();
        // this.cmbFoodType.SelectedValue = pData.DEFAULTFOODTYPE.ToString();

    }

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

        Cache["PateintSearch"] = fFlow.GetMasterList(Convert.ToDouble(this.cmbSearchWard.SelectedItem.Value), this.txtSearchWardName.Text.Trim(), this.ctlSearchAdmitDateFrom.DateValue,
            this.ctlSearchAdmitDateTo.DateValue, this.txtSearchHN.Text.Trim(), this.txtSearchAN.Text.Trim(), this.txtSearchPatientName.Text.Trim(), this.chkIsAdmit.Checked,
            this.cmbSearchStatusFrom.SelectedItem.Value, this.cmbSearchStatusTo.SelectedItem.Value, Appz.LoggedOnUser.LOID, Appz.LoggedOnUser.OFFICERGROUP, orderStr);
        gvMain.DataSource = Cache["PateintSearch"];
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

    private bool doGetDetail(string LOID)
    {
        OrderFoodFlow fFlow = new OrderFoodFlow();
        VOrderPatientData sData = fFlow.GetDetail(Convert.ToDouble(LOID));
        bool ret = true;

        if (sData.LOID != 0)
        {
            SetData(sData);
        }
        else
            ret = false;

        return ret;
    }

    private bool doSave()
    {
        // verify required field
        string error = VerifyData();
        if (error != "")
        {
            SetStatus(error,true);
            return false;
        }

        OrderFoodFlow stFlow = new OrderFoodFlow();
        bool ret = true;

        // verify uniq field

        //if (!stFlow.CheckUniqCode(txtName.Text.Trim(), txhID.Text.Trim()))
        //{
        //    SetErrorStatus(string.Format(DataResources.MSGEI015, "ชื่อหมวดวัสดุ", this.txtName.Text.Trim()));
        //    return false;
        //}

        // data correct go on saving...
        if (txtLOID.Text.Trim() == "")
        {

            //  save new
           // ret = stFlow.InsertData(GetData(), Appz.CurrentUser);
        }
        else
        {
            // save update
           // ret = stFlow.UpdateData(GetData(), Appz.CurrentUser);
        }

        if (!ret)
            SetStatus(stFlow.ErrorMessage,true);
        else
            doGetList();

        return ret;
    }

    private void SetStatus(string t, bool isError)
    {
        this.lbStatus.Text = t;
        this.lbStatus.ForeColor = (isError ? Constant.StatusColor.Error : Constant.StatusColor.Information);
    }

    private string VerifyData()
    {
        string ret = "";
        //AdmitPateintData sData = GetData();
        //if (sData.NAME.Trim() == "")
        //    ret = string.Format(DataResources.MSGEI001, "ชื่อหมวดวัสดุ");
        //else if (sData.STOCKINTYPE == "0")
        //    ret = string.Format(DataResources.MSGEI002, "วีธีการนำเข้า");
        //else if (sData.MASTERTYPE == "0")
        //    ret = string.Format(DataResources.MSGEI002, "ประเภทข้อมูลพื้นฐาน");

        return ret;
    }

    #endregion

    #region Controls Management Methods

    private void SetData(VOrderPatientData pData)
    {
        this.txtLOID.Text = pData.LOID.ToString();
        //this.txtPatientStatus.Text = pData.PATIENTSTATUS;
        this.txtAge.Text = pData.AGE.ToString();
        this.txtAllergic.Text = pData.DRUGALLERGIC + ", " + pData.FOODALLERGIC;
        this.txtAN.Text = pData.AN;
        this.txtBedNo.Text = pData.BEDNO;
        this.txtDiagnosis.Text = pData.DIAGNOSIS;
        this.txtHeight.Text = pData.HEIGHT.ToString();
        this.txtHN.Text = pData.HN;
        this.txtPatientName.Text = pData.PATIENTNAME;
        this.txtRoomNo.Text = pData.ROOMNO;
        //this.txtStatusName.Text = pData.STATUSNAME;
       // this.txtWard.Text = pData.WARD.ToString();
       // this.txtWardName.Text = pData.WARDNAME;
        this.txtWeight.Text = pData.WEIGHT.ToString(Constant.IntFormat);
        this.ctlAdmitDate.DateValue = pData.ADMITDATE;
        this.ctlBirthDate.DateValue = pData.BIRTHDATE;
       // this.cmbFoodType.SelectedValue = pData.DEFAULTFOODTYPE.ToString();

    }

    private AdmitPateintData GetData()
    {
        AdmitPateintData sData = new AdmitPateintData();
        //sData.LOID = Convert.ToDouble("0" + txhID.Text);
        //sData.CODE = txtCode.Text;
        //sData.NAME = txtName.Text;
        //sData.STOCKINTYPE = cmbStockInType.SelectedItem.Value;
        //sData.MASTERTYPE = cmbMasterType.SelectedItem.Value;

        //sData.ACTIVE = chkActive.Checked;
        return sData;
    }
    #endregion
}
