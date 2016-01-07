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

public partial class PreReport_PreContainerUseQty : System.Web.UI.Page
{
    private void SetUnit()
    {
        Appz.BuildCombo(this.cmbUnit, "V_MATERIALMASTER_UNIT", "UNITNAME", "UNIT", " MATERIALMASTER = " + cmbContainer.SelectedValue, "UNITNAME", "เลือก", "0", false);
        cmbUnit.Enabled = (cmbContainer.SelectedItem.Value != "0");
    }

    private void SetReportScript()
    {
        string scriptD = "paramfield1=division&paramvalue1=" + Server.UrlEncode(txtDivisionName.Text) +
            "&paramfield2=datefrom&paramvalue2=' + document.getElementById('" + this.ctlDateFrom.CalendarClientID + "').value + '" +
            "&paramfield3=dateto&paramvalue3=' + document.getElementById('" + this.ctlDateTo.CalendarClientID + "').value + '" +
            "&paramfield4=unit&paramvalue4=' + document.getElementById('" + this.cmbUnit.ClientID + "').value + '" +
            "&paramfield5=materialmaster&paramvalue5=' + document.getElementById('" + this.cmbContainer.ClientID + "').value + '";

        string scriptM = "paramfield1=division&paramvalue1=" + Server.UrlEncode(txtDivisionName.Text) +
            "&paramfield2=yearfrom&paramvalue2=' + document.getElementById('" + this.txtMYearFrom.ClientID + "').value + '" +
            "&paramfield3=yearto&paramvalue3=' + document.getElementById('" + this.txtMYearTo.ClientID + "').value + '" +
            "&paramfield4=monthfrom&paramvalue4=' + document.getElementById('" + this.cmbMonthFrom.ClientID + "').value + '" +
            "&paramfield5=monthto&paramvalue5=' + document.getElementById('" + this.cmbMonthTo.ClientID + "').value + '" +
            "&paramfield6=unit&paramvalue6=' + document.getElementById('" + this.cmbUnit.ClientID + "').value + '" +
            "&paramfield7=materialmaster&paramvalue7=' + document.getElementById('" + this.cmbContainer.ClientID + "').value + '";

        string scriptY = "paramfield1=division&paramvalue1=" + Server.UrlEncode(txtDivisionName.Text) +
            "&paramfield2=yearfrom&paramvalue2=' + document.getElementById('" + this.txtYearFrom.ClientID + "').value + '" +
            "&paramfield3=yearto&paramvalue3=' + document.getElementById('" + this.txtYearTo.ClientID + "').value + '" +
            "&paramfield4=unit&paramvalue4=' + document.getElementById('" + this.cmbUnit.ClientID + "').value + '" +
            "&paramfield5=materialmaster&paramvalue5=' + document.getElementById('" + this.cmbContainer.ClientID + "').value + '";

        if (rbtType.SelectedValue == "dd")
        {
            pnlDate.Visible = true;
            pnlMonth.Visible = false;
            PnlYear.Visible = false;

            this.tbPrint.ClientClick = "if (document.getElementById('" + this.ctlDateFrom.CalendarClientID + "').value == '' || document.getElementById('" + this.ctlDateTo.CalendarClientID + "').value == '') " +
            "{ alert('" + string.Format(DataResources.MSGEI002, "วันที่") + "'); return false; } else { " + Appz.OpenReportScript(Constant.Reports.ContainerUseQtyDate, scriptD, true) + "} ";

        }
        else if (rbtType.SelectedValue == "mm")
        {
            pnlDate.Visible = false;
            pnlMonth.Visible = true;
            PnlYear.Visible = false;

            this.tbPrint.ClientClick = "if (document.getElementById('" + this.txtMYearFrom.ClientID + "').value == '' || document.getElementById('" + this.txtMYearTo.ClientID + "').value == '' || document.getElementById('" + this.cmbMonthFrom.ClientID + "').value == '' || document.getElementById('" + this.cmbMonthTo.ClientID + "').value == '') " +
            "{ alert('" + string.Format(DataResources.MSGEI002, "เดือนและปี") + "'); return false; } else { " + Appz.OpenReportScript(Constant.Reports.ContainerUseQtyMonth, scriptM, true) + "} ";

        }
        else
        {
            pnlDate.Visible = false;
            pnlMonth.Visible = false;
            PnlYear.Visible = true;

            this.tbPrint.ClientClick = "if (document.getElementById('" + this.txtYearFrom.ClientID + "').value == '' || document.getElementById('" + this.txtYearTo.ClientID + "').value == '') " +
            "{ alert('" + string.Format(DataResources.MSGEI001, "ปี") + "'); return false; } else { " + Appz.OpenReportScript(Constant.Reports.ContainerUseQtyYear, scriptY, true) + "} ";

        }
    }

    protected override void OnInit(EventArgs e)
    {
        base.OnInit(e);
        this.txtDivision.Text = Appz.LoggedOnUser.DIVISION.ToString();
        this.txtDivisionName.Text = Appz.LoggedOnUser.DIVISIONNAME;
        Appz.BuildCombo(this.cmbContainer, "V_MATERIALMASTER", "MATERIALNAME", "LOID", " MASTERTYPE = 'TL' ", "MATERIALNAME", "ทั้งหมด", "0", true);
        SetUnit();
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

    protected void cmbContainer_SelectedIndexChanged(object sender, EventArgs e)
    {
        SetUnit();
    }
}
