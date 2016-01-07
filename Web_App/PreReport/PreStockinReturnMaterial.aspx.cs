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

public partial class PreReport_PreStockinReturnMaterial : System.Web.UI.Page
{
    private void SetUnit()
    {
        Appz.BuildCombo(this.cmbUnit, "V_MATERIALMASTER_UNIT", "UNITNAME", "UNIT", " MATERIALMASTER = " + cmbMaterial.SelectedValue, "UNITNAME", "เลือก", "0", false);
        cmbUnit.Enabled = (cmbMaterial.SelectedItem.Value != "0");
    }
    private void SetClass()
    {
        Appz.BuildCombo(this.cmbMaterial, "V_MATERIALMASTER", "MATERIALNAME", "LOID", " MASTERTYPE = 'FO' AND MATERIALCLASS = " + cmbClass.SelectedValue, "MATERIALNAME", "ทั้งหมด", "0", true);
    }
    private void SetReportScript()
    {
        string scriptD = "paramfield1=division&paramvalue1=' + document.getElementById('" + this.cmbDivision.ClientID + "').value + '" +
        "&paramfield2=datefrom&paramvalue2=' + document.getElementById('" + this.ctlDateFrom.CalendarClientID + "').value + '" +
        "&paramfield3=dateto&paramvalue3=' + document.getElementById('" + this.ctlDateTo.CalendarClientID + "').value + '" +
        "&paramfield4=unit&paramvalue4=' + document.getElementById('" + this.cmbUnit.ClientID + "').value + '" +
        "&paramfield5=class&paramvalue5=' + document.getElementById('" + this.cmbClass.ClientID + "').value + '" +
        "&paramfield6=materialmaster&paramvalue6=' + document.getElementById('" + this.cmbMaterial.ClientID + "').value + '";

        string scriptM = "paramfield1=division&paramvalue1=' + document.getElementById('" + this.cmbDivision.ClientID + "').value + '" +
            "&paramfield2=yearfrom&paramvalue2=' + document.getElementById('" + this.txtMYearFrom.ClientID + "').value + '" +
            "&paramfield3=yearto&paramvalue3=' + document.getElementById('" + this.txtMYearTo.ClientID + "').value + '" +
            "&paramfield4=monthfrom&paramvalue4=' + document.getElementById('" + this.cmbMonthFrom.ClientID + "').value + '" +
            "&paramfield5=monthto&paramvalue5=' + document.getElementById('" + this.cmbMonthTo.ClientID + "').value + '" +
            "&paramfield6=unit&paramvalue6=' + document.getElementById('" + this.cmbUnit.ClientID + "').value + '" +
            "&paramfield7=class&paramvalue7=' + document.getElementById('" + this.cmbClass.ClientID + "').value + '" +
            "&paramfield8=materialmaster&paramvalue8=' + document.getElementById('" + this.cmbMaterial.ClientID + "').value + '";

        string scriptY = "paramfield1=division&paramvalue1=' + document.getElementById('" + this.cmbDivision.ClientID + "').value + '" +
            "&paramfield2=yearfrom&paramvalue2=' + document.getElementById('" + this.txtYearFrom.ClientID + "').value + '" +
            "&paramfield3=yearto&paramvalue3=' + document.getElementById('" + this.txtYearTo.ClientID + "').value + '" +
            "&paramfield4=unit&paramvalue4=' + document.getElementById('" + this.cmbUnit.ClientID + "').value + '" +
            "&paramfield5=class&paramvalue5=' + document.getElementById('" + this.cmbClass.ClientID + "').value + '" +
            "&paramfield6=materialmaster&paramvalue6=' + document.getElementById('" + this.cmbMaterial.ClientID + "').value + '";

        if (rbtType.SelectedValue == "dd")
        {
            pnlDate.Visible = true;
            pnlMonth.Visible = false;
            PnlYear.Visible = false;

            this.tbPrint.ClientClick = "if (document.getElementById('" + this.ctlDateFrom.CalendarClientID + "').value == '' || document.getElementById('" + this.ctlDateTo.CalendarClientID + "').value == '') " +
            "{ alert('" + string.Format(DataResources.MSGEI002, "วันที่") + "'); return false; } " +
            "else if (document.getElementById('" + this.cmbMaterial.ClientID + "').value != '0' & document.getElementById('" + this.cmbUnit.ClientID + "').value == '0') " +
            "{ alert('" + string.Format(DataResources.MSGEI002, "หน่วย") + "'); return false; } " +
            "else { " + Appz.OpenReportScript(Constant.Reports.StockInReturnMaterialDate, scriptD, true) + "} ";

        }
        else if (rbtType.SelectedValue == "mm")
        {
            pnlDate.Visible = false;
            pnlMonth.Visible = true;
            PnlYear.Visible = false;

            this.tbPrint.ClientClick = "if (document.getElementById('" + this.txtMYearFrom.ClientID + "').value == '' || document.getElementById('" + this.txtMYearTo.ClientID + "').value == '' || document.getElementById('" + this.cmbMonthFrom.ClientID + "').value == '' || document.getElementById('" + this.cmbMonthTo.ClientID + "').value == '') " +
            "{ alert('" + string.Format(DataResources.MSGEI001, "เดือนและปี") + "'); return false; } " +
            "else if (document.getElementById('" + this.cmbMaterial.ClientID + "').value != '0' & document.getElementById('" + this.cmbUnit.ClientID + "').value == '0') " +
            "{ alert('" + string.Format(DataResources.MSGEI002, "หน่วย") + "'); return false; } " +
            "else { " + Appz.OpenReportScript(Constant.Reports.StockInReturnMaterialMonth, scriptM, true) + "} ";

        }
        else
        {
            pnlDate.Visible = false;
            pnlMonth.Visible = false;
            PnlYear.Visible = true;

            this.tbPrint.ClientClick = "if (document.getElementById('" + this.txtYearFrom.ClientID + "').value == '' || document.getElementById('" + this.txtYearTo.ClientID + "').value == '') " +
            "{ alert('" + string.Format(DataResources.MSGEI001, "ปี") + "'); return false; } " +
            "else if (document.getElementById('" + this.cmbMaterial.ClientID + "').value != '0' & document.getElementById('" + this.cmbUnit.ClientID + "').value == '0') " +
            "{ alert('" + string.Format(DataResources.MSGEI002, "หน่วย") + "'); return false; } " +
            "else { " + Appz.OpenReportScript(Constant.Reports.StockInReturnMaterialYear, scriptY, true) + "} ";

        }
    }
    protected override void OnInit(EventArgs e)
    {
        base.OnInit(e);
        this.txtDivision.Text = Appz.LoggedOnUser.DIVISION.ToString();
        Appz.BuildCombo(this.cmbDivision, "DIVISION", "NAME", "LOID", " ISONLINEREQUEST='Y' ", "NAME", "ทั้งหมด", "0", true);
        Appz.BuildCombo(this.cmbClass, "MATERIALCLASS", "NAME", "LOID", " MASTERTYPE = 'FO' ", "NAME", "ทั้งหมด", "0", true);
        Appz.BuildCombo(this.cmbMaterial, "V_MATERIALMASTER", "MATERIALNAME", "LOID", " MASTERTYPE = 'FO' ", "MATERIALNAME", "ทั้งหมด", "0", true);
        Appz.BuildCombo(this.cmbUnit, "UNIT", "THNAME", "LOID", "", "NAME", "เลือก", "0", false);
        ControlUtil.SetYearTextbox(this.txtMYearFrom);
        ControlUtil.SetYearTextbox(this.txtMYearTo);
        ControlUtil.SetYearTextbox(this.txtYearFrom);
        ControlUtil.SetYearTextbox(this.txtYearTo);
        SetReportScript();

    }
    protected void Page_Load(object sender, EventArgs e)
    {

    }
    protected void tbPrintClick(object sender, EventArgs e)
    {

    }

    protected void rbtType_SelectedIndexChanged(object sender, EventArgs e)
    {
        SetReportScript();
    }
    protected void cmbMaterial_SelectedIndexChanged(object sender, EventArgs e)
    {
        SetUnit();
    }
    protected void cmbClass_SelectedIndexChanged(object sender, EventArgs e)
    {
        SetClass();
    }
}
