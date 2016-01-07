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

public partial class PreReport_PrePatientSetQty : System.Web.UI.Page
{
    private void SetReportScript()
    {
        string scriptD = "paramfield1=division&paramvalue1=" + txtDivision.Text +
            "&paramfield2=datefrom&paramvalue2=' + document.getElementById('" + this.ctlDateFrom.CalendarClientID + "').value + '" +
            "&paramfield3=dateto&paramvalue3=' + document.getElementById('" + this.ctlDateTo.CalendarClientID + "').value + '" +
            "&paramfield4=foodtype&paramvalue4=' + document.getElementById('" + this.cmbFoodType.ClientID + "').value + '" +
            "&paramfield5=abstain&paramvalue5=' + document.getElementById('" + this.txtAbstain.ClientID + "').value + '" +
            "&paramfield6=need&paramvalue6=' + document.getElementById('" + this.txtNeed.ClientID + "').value + '" +
            "&paramfield7=request&paramvalue7=' + document.getElementById('" + this.txtRequest.ClientID + "').value + '" +
            "&paramfield8=ward&paramvalue8=' + document.getElementById('" + this.cmbWard.ClientID + "').value + '" +
            "&paramfield9=vip&paramvalue9=' + document.getElementById('" + this.cmbVip.ClientID + "').value + '" +
            "&paramfield10=increase&paramvalue10=' + document.getElementById('" + this.txtIncrease.ClientID + "').value + '";

        string scriptM = "paramfield1=division&paramvalue1=" + txtDivision.Text +
            "&paramfield2=yearfrom&paramvalue2=' + document.getElementById('" + this.txtMYearFrom.ClientID + "').value + '" +
            "&paramfield3=yearto&paramvalue3=' + document.getElementById('" + this.txtMYearTo.ClientID + "').value + '" +
            "&paramfield4=monthfrom&paramvalue4=' + document.getElementById('" + this.cmbMonthFrom.ClientID + "').value + '" +
            "&paramfield5=monthto&paramvalue5=' + document.getElementById('" + this.cmbMonthTo.ClientID + "').value + '" +
            "&paramfield6=foodtype&paramvalue6=' + document.getElementById('" + this.cmbFoodType.ClientID + "').value + '" +
            "&paramfield7=abstain&paramvalue7=' + document.getElementById('" + this.txtAbstain.ClientID + "').value + '" +
            "&paramfield8=need&paramvalue8=' + document.getElementById('" + this.txtNeed.ClientID + "').value + '" +
            "&paramfield9=request&paramvalue9=' + document.getElementById('" + this.txtRequest.ClientID + "').value + '" +
            "&paramfield10=ward&paramvalue10=' + document.getElementById('" + this.cmbWard.ClientID + "').value + '" +
            "&paramfield11=vip&paramvalue11=' + document.getElementById('" + this.cmbVip.ClientID + "').value + '" +
            "&paramfield12=increase&paramvalue12=' + document.getElementById('" + this.txtIncrease.ClientID + "').value + '";

        string scriptY = "paramfield1=division&paramvalue1=" + txtDivision.Text +
            "&paramfield2=yearfrom&paramvalue2=' + document.getElementById('" + this.txtYearFrom.ClientID + "').value + '" +
            "&paramfield3=yearto&paramvalue3=' + document.getElementById('" + this.txtYearTo.ClientID + "').value + '" +
            "&paramfield4=foodtype&paramvalue4=' + document.getElementById('" + this.cmbFoodType.ClientID + "').value + '" +
            "&paramfield5=abstain&paramvalue5=' + document.getElementById('" + this.txtAbstain.ClientID + "').value + '" +
            "&paramfield6=need&paramvalue6=' + document.getElementById('" + this.txtNeed.ClientID + "').value + '" +
            "&paramfield7=request&paramvalue7=' + document.getElementById('" + this.txtRequest.ClientID + "').value + '" +
            "&paramfield8=ward&paramvalue8=' + document.getElementById('" + this.cmbWard.ClientID + "').value + '" +
            "&paramfield9=vip&paramvalue9=' + document.getElementById('" + this.cmbVip.ClientID + "').value + '" +
            "&paramfield10=increase&paramvalue10=' + document.getElementById('" + this.txtIncrease.ClientID + "').value + '";

        if (rbtType.SelectedValue == "dd")
        {
            pnlDate.Visible = true;
            pnlMonth.Visible = false;
            PnlYear.Visible = false;

            this.tbPrint.ClientClick = "if (document.getElementById('" + this.ctlDateFrom.CalendarClientID + "').value == '' || document.getElementById('" + this.ctlDateTo.CalendarClientID + "').value == '') " +
            "{ alert('" + string.Format(DataResources.MSGEI002, "วันที่") + "'); return false; } else { " + Appz.OpenReportScript(Constant.Reports.PatientSetQtyDate, scriptD, true) + "} ";

        }
        else if (rbtType.SelectedValue == "mm")
        {
            pnlDate.Visible = false;
            pnlMonth.Visible = true;
            PnlYear.Visible = false;

            this.tbPrint.ClientClick = "if (document.getElementById('" + this.txtMYearFrom.ClientID + "').value == '' || document.getElementById('" + this.txtMYearTo.ClientID + "').value == '' || document.getElementById('" + this.cmbMonthFrom.ClientID + "').value == '' || document.getElementById('" + this.cmbMonthTo.ClientID + "').value == '') " +
            "{ alert('" + string.Format(DataResources.MSGEI001, "เดือนและปี") + "'); return false; } else { " + Appz.OpenReportScript(Constant.Reports.PatientSetQtyMonth, scriptM, true) + "} ";

        }
        else
        {
            pnlDate.Visible = false;
            pnlMonth.Visible = false;
            PnlYear.Visible = true;

            this.tbPrint.ClientClick = "if (document.getElementById('" + this.txtYearFrom.ClientID + "').value == '' || document.getElementById('" + this.txtYearTo.ClientID + "').value == '') " +
            "{ alert('" + string.Format(DataResources.MSGEI001, "ปี") + "'); return false; } else { " + Appz.OpenReportScript(Constant.Reports.PatientSetQtyYear, scriptY, true) + "} ";


        }
    }

    protected override void OnInit(EventArgs e)
    {
        base.OnInit(e);
        this.txtDivision.Text = Appz.LoggedOnUser.DIVISION.ToString();
        this.txtDivisionName.Text = Appz.LoggedOnUser.DIVISIONNAME;
        Appz.BuildCombo(this.cmbFoodType, "V_FOODTYPE", "NAME", "LOID", "DIVISION='" + Appz.LoggedOnUser.DIVISION + "' ", "NAME", "ทั้งหมด", "0", true);
        Appz.BuildCombo(this.cmbWard, "WARD", "NAME", "LOID", "ACTIVE = '1'", "NAME", "ทั้งหมด", "0", false);
        ControlUtil.SetYearTextbox(this.txtMYearFrom);
        ControlUtil.SetYearTextbox(this.txtMYearTo);
        ControlUtil.SetYearTextbox(this.txtYearFrom);
        ControlUtil.SetYearTextbox(this.txtYearTo);
        this.rbtType.SelectedIndex = 0;
        SetReportScript();
    }

    protected void Page_Load(object sender, EventArgs e)
    {
    }

    protected void rbtType_SelectedIndexChanged(object sender, EventArgs e)
    {
        SetReportScript();
    }
}
