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

/// <summary>
/// PreStockOutTools Page Class
/// Version 1.0
/// =========================================================================
/// Create by: Teang
/// Create Date: 22 May 2009
/// -------------------------------------------------------------------------
/// Modify By: -
/// Modify From: -
/// Modify Date: -
/// -------------------------------------------------------------------------
/// Remark: -
/// Description:
///    หน้าการทำรายการข้อมูล PreStockOutTools
/// Changes:
///    1.0 - สร้าง
/// -------------------------------------------------------------------------
/// =========================================================================
/// </summary>
/// 
public partial class PreReport_PreStockOutTools : System.Web.UI.Page
{
    private void SetUnit()
    {
        Appz.BuildCombo(this.cmbUnit, "V_MATERIALMASTER_UNIT", "UNITNAME", "UNIT", " MATERIALMASTER = " + cmbMaterialMaster.SelectedValue, "UNITNAME", "เลือก", "0", false);
        cmbUnit.Enabled = (cmbMaterialMaster.SelectedItem.Value != "0");
    }

    private void SetScript(RadioButtonList rblType, HtmlTableRow trDate, HtmlTableRow trMonth, HtmlTableRow trYear)
    {
        string script = "document.getElementById('" + trDate.ClientID + "').style.display = (document.getElementById('" + this.rbtType.ClientID + "_0').checked ? 'block' : 'none'); " +
            "document.getElementById('" + trMonth.ClientID + "').style.display = (document.getElementById('" + this.rbtType.ClientID + "_1').checked ? 'block' : 'none'); " +
            "document.getElementById('" + trYear.ClientID + "').style.display = (document.getElementById('" + this.rbtType.ClientID + "_2').checked ? 'block' : 'none'); ";
        rblType.Attributes.Add("onclick", script);


        trDate.Style.Add(HtmlTextWriterStyle.Display, (rblType.SelectedItem.Value == "dd" ? "block" : "none"));
        trMonth.Style.Add(HtmlTextWriterStyle.Display, (rblType.SelectedItem.Value == "mm" ? "block" : "none"));
        trYear.Style.Add(HtmlTextWriterStyle.Display, (rblType.SelectedItem.Value == "yy" ? "block" : "none"));
    }

    private void SetReportScript(RadioButtonList rblType)
    {
        string scriptDay = "paramfield1=DIVISION&paramvalue1=' + document.getElementById('" + this.cmbDivision.ClientID + "').value + " +
            "'&paramfield2=MATERIALCLASS&paramvalue2=' + document.getElementById('" + this.cmbMaterialClass.ClientID + "').value + " +
            "'&paramfield3=MATERIALMASTER&paramvalue3=' + document.getElementById('" + this.cmbMaterialMaster.ClientID + "').value + " +
            "'&paramfield4=UNIT&paramvalue4=' + document.getElementById('" + this.cmbUnit.ClientID + "').value + " +
            "'&paramfield5=DATEFROM&paramvalue5=' + document.getElementById('" + this.ctlDateFrom.CalendarClientID + "').value + " +
            "'&paramfield6=DATETO&paramvalue6=' + document.getElementById('" + this.ctlDateTo.CalendarClientID + "').value + '";
        string scriptMonth = "paramfield1=DIVISION&paramvalue1=' + document.getElementById('" + this.cmbDivision.ClientID + "').value + " +
            "'&paramfield2=MATERIALCLASS&paramvalue2=' + document.getElementById('" + this.cmbMaterialClass.ClientID + "').value + " +
            "'&paramfield3=MATERIALMASTER&paramvalue3=' + document.getElementById('" + this.cmbMaterialMaster.ClientID + "').value + " +
            "'&paramfield4=UNIT&paramvalue4=' + document.getElementById('" + this.cmbUnit.ClientID + "').value + " +
            "'&paramfield5=MONTHFROM&paramvalue5=' + document.getElementById('" + this.txtMYearFrom.ClientID + "').value + document.getElementById('" + this.cmbMonthFrom.ClientID + "').value + " +
            "'&paramfield6=MONTHTO&paramvalue6=' + document.getElementById('" + this.txtMYearTo.ClientID + "').value + document.getElementById('" + this.cmbMonthTo.ClientID + "').value + '";
        string scriptYear = "paramfield1=DIVISION&paramvalue1=' + document.getElementById('" + this.cmbDivision.ClientID + "').value + " +
            "'&paramfield2=MATERIALCLASS&paramvalue2=' + document.getElementById('" + this.cmbMaterialClass.ClientID + "').value + " +
            "'&paramfield3=MATERIALMASTER&paramvalue3=' + document.getElementById('" + this.cmbMaterialMaster.ClientID + "').value + " +
            "'&paramfield4=UNIT&paramvalue4=' + document.getElementById('" + this.cmbUnit.ClientID + "').value + " +
            "'&paramfield5=YEARFROM&paramvalue5=' + document.getElementById('" + this.txtYearFrom.ClientID + "').value + " +
            "'&paramfield6=YEARTO&paramvalue6=' + document.getElementById('" + this.txtYearTo.ClientID + "').value + '";

        string script = "";
        script = "if (document.getElementById('" + this.rbtType.ClientID + "_0').checked) {" +
            "if (document.getElementById('" + this.ctlDateFrom.CalendarClientID + "').value == '' || document.getElementById('" + this.ctlDateTo.CalendarClientID + "').value == '') " +
            "{ alert ('" + string.Format(DataResources.MSGEI002, "ช่วงวันที่") + "'); return false; } else {" + Appz.OpenReportScript(Constant.Reports.StockOutToolsDay, scriptDay, false) + "} } " +
            "else if (document.getElementById('" + this.rbtType.ClientID + "_1').checked) {" +
            "if (document.getElementById('" + this.cmbMonthFrom.ClientID + "').value == '' || document.getElementById('" + this.txtMYearFrom.ClientID + "').value == '' || " +
            "document.getElementById('" + this.cmbMonthTo.ClientID + "').value == '' || document.getElementById('" + this.txtMYearTo.ClientID + "').value == '') " +
            "{ alert ('" + string.Format(DataResources.MSGEI002, "ช่วงเดือนและปี") + "'); return false; } else {" + Appz.OpenReportScript(Constant.Reports.StockOutToolsMonth, scriptMonth, false) + "} } " +
            "else {" +
            "if (document.getElementById('" + this.txtYearFrom.ClientID + "').value == '' || document.getElementById('" + this.txtYearTo.ClientID + "').value == '') " +
            "{ alert ('" + string.Format(DataResources.MSGEI002, "ช่วงปี") + "'); return false; } else {" + Appz.OpenReportScript(Constant.Reports.StockOutToolsYear, scriptYear, false) + "} } ";
        this.tbPrint.ClientClick = script;
    }

    protected override void OnInit(EventArgs e)
    {
        base.OnInit(e);
        Appz.BuildCombo(this.cmbDivision, "V_STOCKOUTTOOLS_REPORT", "DIVISIONNAME", "DIVISION", "", "DIVISIONNAME", "ทั้งหมด", "0", true);
        Appz.BuildCombo(this.cmbMaterialClass, "V_STOCKOUTTOOLS_REPORT", "CLASSNAME", "MATERIALCLASS", "", "CLASSNAME", "ทั้งหมด", "0", true);
        Appz.BuildCombo(this.cmbMaterialMaster, "V_STOCKOUTTOOLS_REPORT", "MATERIALNAME", "MATERIALMASTER", "", "MATERIALNAME", "ทั้งหมด", "0", true);
        ControlUtil.SetYearTextbox(this.txtMYearFrom);
        ControlUtil.SetYearTextbox(this.txtMYearTo);
        ControlUtil.SetYearTextbox(this.txtYearFrom);
        ControlUtil.SetYearTextbox(this.txtYearTo);
        SetUnit();
        SetReportScript(this.rbtType);
    }

    protected void Page_Load(object sender, EventArgs e)
    {
        SetScript(this.rbtType, pnlDate, pnlMonth, PnlYear);
    }

    protected void cmbMaterialMaster_SelectedIndexChanged(object sender, EventArgs e)
    {
        SetUnit();
    }
}
