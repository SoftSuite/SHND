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

public partial class PreReport_PrePatientQtyFeed : System.Web.UI.Page
{
    private void SetReportScript()
    {
        string scriptD = "paramfield1=division&paramvalue1=" + Server.UrlEncode(txtDivisionName.Text) +
            "&paramfield2=datefrom&paramvalue2=' + document.getElementById('" + this.ctlDateFrom.CalendarClientID + "').value + '" +
            "&paramfield3=dateto&paramvalue3=' + document.getElementById('" + this.ctlDateTo.CalendarClientID + "').value + '" +
            "&paramfield4=formulafeed&paramvalue4=' + document.getElementById('" + this.cmbFeedName.ClientID + "').value + '" +
            "&paramfield5=control&paramvalue5=' + document.getElementById('" + this.txtControl.ClientID + "').value + '" +
            "&paramfield6=calorie&paramvalue6=' + document.getElementById('" + this.txtCalorie.ClientID + "').value + '" +
            "&paramfield7=limit&paramvalue7=' + document.getElementById('" + this.txtLimit.ClientID + "').value + '" +
            "&paramfield8=ward&paramvalue8=' + document.getElementById('" + this.cmbWard.ClientID + "').value + '" +
            "&paramfield9=increase&paramvalue9=' + document.getElementById('" + this.txtIncrease.ClientID + "').value + '";

        string scriptM = "paramfield1=division&paramvalue1=" + Server.UrlEncode(txtDivisionName.Text) +
            "&paramfield2=yearfrom&paramvalue2=' + document.getElementById('" + this.txtMYearFrom.ClientID + "').value + '" +
            "&paramfield3=yearto&paramvalue3=' + document.getElementById('" + this.txtMYearTo.ClientID + "').value + '" +
            "&paramfield4=monthfrom&paramvalue4=' + document.getElementById('" + this.cmbMonthFrom.ClientID + "').value + '" +
            "&paramfield5=monthto&paramvalue5=' + document.getElementById('" + this.cmbMonthTo.ClientID + "').value + '" +
            "&paramfield6=formulafeed&paramvalue6=' + document.getElementById('" + this.cmbFeedName.ClientID + "').value + '" +
            "&paramfield7=control&paramvalue7=' + document.getElementById('" + this.txtControl.ClientID + "').value + '" +
            "&paramfield8=calorie&paramvalue8=' + document.getElementById('" + this.txtCalorie.ClientID + "').value + '" +
            "&paramfield9=limit&paramvalue9=' + document.getElementById('" + this.txtLimit.ClientID + "').value + '" +
            "&paramfield10=ward&paramvalue10=' + document.getElementById('" + this.cmbWard.ClientID + "').value + '" +
            "&paramfield11=increase&paramvalue11=' + document.getElementById('" + this.txtIncrease.ClientID + "').value + '";

        string scriptY = "paramfield1=division&paramvalue1=" + Server.UrlEncode(txtDivisionName.Text) +
            "&paramfield2=yearfrom&paramvalue2=' + document.getElementById('" + this.txtYearFrom.ClientID + "').value + '" +
            "&paramfield3=yearto&paramvalue3=' + document.getElementById('" + this.txtYearTo.ClientID + "').value + '" +
            "&paramfield4=formulafeed&paramvalue4=' + document.getElementById('" + this.cmbFeedName.ClientID + "').value + '" +
            "&paramfield5=control&paramvalue5=' + document.getElementById('" + this.txtControl.ClientID + "').value + '" +
            "&paramfield6=calorie&paramvalue6=' + document.getElementById('" + this.txtCalorie.ClientID + "').value + '" +
            "&paramfield7=limit&paramvalue7=' + document.getElementById('" + this.txtLimit.ClientID + "').value + '" +
            "&paramfield8=ward&paramvalue8=' + document.getElementById('" + this.cmbWard.ClientID + "').value + '" +
            "&paramfield9=increase&paramvalue9=' + document.getElementById('" + this.txtIncrease.ClientID + "').value + '";


        if (rbtType.SelectedValue == "dd")
        {
            pnlDate.Visible = true;
            pnlMonth.Visible = false;
            PnlYear.Visible = false;

            this.tbPrint.ClientClick = "if (document.getElementById('" + this.ctlDateFrom.CalendarClientID + "').value == '' || document.getElementById('" + this.ctlDateTo.CalendarClientID + "').value == '') " +
             "{ alert('" + string.Format(DataResources.MSGEI002, "�ѹ���") + "'); return false; } else { " + Appz.OpenReportScript(Constant.Reports.PatientQtyFeedDate, scriptD, true) + "} ";

        }
        else if (rbtType.SelectedValue == "mm")
        {
            pnlDate.Visible = false;
            pnlMonth.Visible = true;
            PnlYear.Visible = false;

            this.tbPrint.ClientClick = "if (document.getElementById('" + this.txtMYearFrom.ClientID + "').value == '' || document.getElementById('" + this.txtMYearTo.ClientID + "').value == '' || document.getElementById('" + this.cmbMonthFrom.ClientID + "').value == '' || document.getElementById('" + this.cmbMonthTo.ClientID + "').value == '') " +
            "{ alert('" + string.Format(DataResources.MSGEI001, "��͹��л�") + "'); return false; } else { " + Appz.OpenReportScript(Constant.Reports.PatientQtyFeedMonth, scriptM, true) + "} ";

        }
        else
        {
            pnlDate.Visible = false;
            pnlMonth.Visible = false;
            PnlYear.Visible = true;

            this.tbPrint.ClientClick = "if (document.getElementById('" + this.txtYearFrom.ClientID + "').value == '' || document.getElementById('" + this.txtYearTo.ClientID + "').value == '') " +
            "{ alert('" + string.Format(DataResources.MSGEI001, "��") + "'); return false; } else { " + Appz.OpenReportScript(Constant.Reports.PatientQtyFeedYear, scriptY, true) + "} ";

        }
    }

    protected override void OnInit(EventArgs e)
    {
        base.OnInit(e);
        this.txtDivision.Text = Appz.LoggedOnUser.DIVISION.ToString();
        this.txtDivisionName.Text = Appz.LoggedOnUser.DIVISIONNAME;
        Appz.BuildCombo(this.cmbFeedName, "V_FORMULAFEED", "NAME", "MATERIALMASTER", " MATERIALMASTER IS NOT NULL ", "NAME", "������", "0", true);
        Appz.BuildCombo(this.cmbWard, "WARD", "NAME", "LOID", "ACTIVE = '1'", "NAME", "������", "0", false);
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
