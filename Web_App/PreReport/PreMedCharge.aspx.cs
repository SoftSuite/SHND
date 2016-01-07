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

public partial class PreReport_PreMedCharge : System.Web.UI.Page
{
    private void SetReportScript()
    {
        string scriptD = "paramfield1=ward&paramvalue1=' + document.getElementById('" + this.cmbWard.ClientID + "').value + '" +
                "&paramfield2=datefrom&paramvalue2=' + document.getElementById('" + this.ctlDateFrom.CalendarClientID + "').value + '" +
                "&paramfield3=dateto&paramvalue3=' + document.getElementById('" + this.ctlDateTo.CalendarClientID + "').value + '" +
                "&paramfield4=materialmaster&paramvalue4=' + document.getElementById('" + this.cmbMaterial.ClientID + "').value + '";

        string scriptM = "paramfield1=ward&paramvalue1=' + document.getElementById('" + this.cmbWard.ClientID + "').value + '" +
                "&paramfield2=yearfrom&paramvalue2=' + document.getElementById('" + this.txtMYearFrom.ClientID + "').value + '" +
                "&paramfield3=yearto&paramvalue3=' + document.getElementById('" + this.txtMYearTo.ClientID + "').value + '" +
                "&paramfield4=monthfrom&paramvalue4=' + document.getElementById('" + this.cmbMonthFrom.ClientID + "').value + '" +
                "&paramfield5=monthto&paramvalue5=' + document.getElementById('" + this.cmbMonthTo.ClientID + "').value + '" +
                "&paramfield6=materialmaster&paramvalue6=' + document.getElementById('" + this.cmbMaterial.ClientID + "').value + '";

        string scriptY = "paramfield1=ward&paramvalue1=' + document.getElementById('" + this.cmbWard.ClientID + "').value + '" +
                "&paramfield2=yearfrom&paramvalue2=' + document.getElementById('" + this.txtYearFrom.ClientID + "').value + '" +
                "&paramfield3=yearto&paramvalue3=' + document.getElementById('" + this.txtYearTo.ClientID + "').value + '" +
                "&paramfield4=materialmaster&paramvalue4=' + document.getElementById('" + this.cmbMaterial.ClientID + "').value + '";

        if (rbtType.SelectedValue == "dd")
        {
            pnlDate.Visible = true;
            pnlMonth.Visible = false;
            PnlYear.Visible = false;
            if (rbtQty.SelectedValue == "1")
            {
                this.tbPrint.ClientClick = "if (document.getElementById('" + this.ctlDateFrom.CalendarClientID + "').value == '' || document.getElementById('" + this.ctlDateTo.CalendarClientID + "').value == '') " +
                "{ alert('" + string.Format(DataResources.MSGEI002, "วันที่") + "'); return false; } else { " + Appz.OpenReportScript(Constant.Reports.MedChargeDate, scriptD, true) + "} ";

            }
            else
            {
                this.tbPrint.ClientClick = "if (document.getElementById('" + this.ctlDateFrom.CalendarClientID + "').value == '' || document.getElementById('" + this.ctlDateTo.CalendarClientID + "').value == '') " +
                "{ alert('" + string.Format(DataResources.MSGEI002, "วันที่") + "'); return false; } else { " + Appz.OpenReportScript(Constant.Reports.MedChargeTotalDate, scriptD, true) + "} ";

            }
        }
        else if (rbtType.SelectedValue == "mm")
        {
            pnlDate.Visible = false;
            pnlMonth.Visible = true;
            PnlYear.Visible = false;
            if (rbtQty.SelectedValue == "1")
            {
                this.tbPrint.ClientClick = "if (document.getElementById('" + this.txtMYearFrom.ClientID + "').value == '' || document.getElementById('" + this.txtMYearTo.ClientID + "').value == '' || document.getElementById('" + this.cmbMonthFrom.ClientID + "').value == '' || document.getElementById('" + this.cmbMonthTo.ClientID + "').value == '') " +
                "{ alert('" + string.Format(DataResources.MSGEI001, "เดือนและปี") + "'); return false; } else { " + Appz.OpenReportScript(Constant.Reports.MedChargeMonth, scriptM, true) + "} ";
            }
            else
            {
                this.tbPrint.ClientClick = "if (document.getElementById('" + this.txtMYearFrom.ClientID + "').value == '' || document.getElementById('" + this.txtMYearTo.ClientID + "').value == '' || document.getElementById('" + this.cmbMonthFrom.ClientID + "').value == '' || document.getElementById('" + this.cmbMonthTo.ClientID + "').value == '') " +
                "{ alert('" + string.Format(DataResources.MSGEI001, "เดือนและปี") + "'); return false; } else { " + Appz.OpenReportScript(Constant.Reports.MedChargeTotalMonth, scriptM, true) + "} ";
            }
        }
        else
        {
            pnlDate.Visible = false;
            pnlMonth.Visible = false;
            PnlYear.Visible = true;
            if (rbtQty.SelectedValue == "1")
            {
                this.tbPrint.ClientClick = "if (document.getElementById('" + this.txtYearFrom.ClientID + "').value == '' || document.getElementById('" + this.txtYearTo.ClientID + "').value == '') " +
                "{ alert('" + string.Format(DataResources.MSGEI001, "ปี") + "'); return false; } else { " + Appz.OpenReportScript(Constant.Reports.MedChargeYear, scriptY, true) + "} ";

            }
            else
            {
                this.tbPrint.ClientClick = "if (document.getElementById('" + this.txtYearFrom.ClientID + "').value == '' || document.getElementById('" + this.txtYearTo.ClientID + "').value == '') " +
                "{ alert('" + string.Format(DataResources.MSGEI001, "ปี") + "'); return false; } else { " + Appz.OpenReportScript(Constant.Reports.MedChargeTotalYear, scriptY, true) + "} ";

            }
        }
    }

    protected override void OnInit(EventArgs e)
    {
        base.OnInit(e);
        this.txtDivision.Text = Appz.LoggedOnUser.DIVISION.ToString();
        this.txtDivisionName.Text = Appz.LoggedOnUser.DIVISIONNAME;
        Appz.BuildCombo(this.cmbMaterial, "V_MATERIALMASTER", "MATERIALNAME", "LOID", " MASTERTYPE = 'MD' ", "MATERIALNAME", "ทั้งหมด", "0", true);
        Appz.BuildCombo(this.cmbWard, "WARD", "NAME", "LOID", "ACTIVE = '1'", "NAME", "ทั้งหมด", "0", false);

        SetReportScript();
    }

    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
        }
    }

    protected void rbtType_SelectedIndexChanged(object sender, EventArgs e)
    {
        SetReportScript();
    }

    protected void rbtQty_SelectedIndexChanged(object sender, EventArgs e)
    {
        SetReportScript();
    }

    protected void cmbWard_SelectedIndexChanged(object sender, EventArgs e)
    {
        if (cmbWard.SelectedValue != "0")
        {
            rbtQty.SelectedValue = "1";
            rbtQty.Enabled = false;
        }
        else
        {
            rbtQty.Enabled = true;
        }
    }
}
