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
/// PreStockOutHosMaterial Page Class
/// Version 1.0
/// =========================================================================
/// Create by: Teang
/// Create Date: 25 May 2009
/// -------------------------------------------------------------------------
/// Modify By: -
/// Modify From: -
/// Modify Date: -
/// -------------------------------------------------------------------------
/// Remark: -
/// Description:
///    หน้าการทำรายการข้อมูล PreStockOutHosMaterial
/// Changes:
///    1.0 - สร้าง
/// -------------------------------------------------------------------------
/// =========================================================================
/// </summary>
/// 
public partial class PreReport_PreStockOutHosMaterial : System.Web.UI.Page
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
        string scriptDay = "paramfield1=MATERIALCLASS&paramvalue1=' + document.getElementById('" + this.cmbMaterialClass.ClientID + "').value + " +
            "'&paramfield2=MATERIALMASTER&paramvalue2=' + document.getElementById('" + this.cmbMaterialMaster.ClientID + "').value + " +
            "'&paramfield3=UNIT&paramvalue3=' + document.getElementById('" + this.cmbUnit.ClientID + "').value + " +
            "'&paramfield4=DATEFROM&paramvalue4=' + document.getElementById('" + this.ctlDateFrom.CalendarClientID + "').value + " +
            "'&paramfield5=DATETO&paramvalue5=' + document.getElementById('" + this.ctlDateTo.CalendarClientID + "').value + '";
        string scriptMonth = "paramfield1=MATERIALCLASS&paramvalue1=' + document.getElementById('" + this.cmbMaterialClass.ClientID + "').value + " +
            "'&paramfield2=MATERIALMASTER&paramvalue2=' + document.getElementById('" + this.cmbMaterialMaster.ClientID + "').value + " +
            "'&paramfield3=UNIT&paramvalue3=' + document.getElementById('" + this.cmbUnit.ClientID + "').value + " +
            "'&paramfield4=MONTHFROM&paramvalue4=' + document.getElementById('" + this.txtMYearFrom.ClientID + "').value + document.getElementById('" + this.cmbMonthFrom.ClientID + "').value + " +
            "'&paramfield5=MONTHTO&paramvalue5=' + document.getElementById('" + this.txtMYearTo.ClientID + "').value + document.getElementById('" + this.cmbMonthTo.ClientID + "').value + '";
        string scriptYear = "paramfield1=MATERIALCLASS&paramvalue1=' + document.getElementById('" + this.cmbMaterialClass.ClientID + "').value + " +
            "'&paramfield2=MATERIALMASTER&paramvalue2=' + document.getElementById('" + this.cmbMaterialMaster.ClientID + "').value + " +
            "'&paramfield3=UNIT&paramvalue3=' + document.getElementById('" + this.cmbUnit.ClientID + "').value + " +
            "'&paramfield4=YEARFROM&paramvalue4=' + document.getElementById('" + this.txtYearFrom.ClientID + "').value + " +
            "'&paramfield5=YEARTO&paramvalue5=' + document.getElementById('" + this.txtYearTo.ClientID + "').value + '";

        string script = "";
        script = "if (document.getElementById('" + this.rbtType.ClientID + "_0').checked) {" +
            "if (document.getElementById('" + this.ctlDateFrom.CalendarClientID + "').value == '' || document.getElementById('" + this.ctlDateTo.CalendarClientID + "').value == '') " +
            "{ alert ('" + string.Format(DataResources.MSGEI002, "ช่วงวันที่") + "'); return false; } else {" + Appz.OpenReportScript(Constant.Reports.StockOutHosToolsDay, scriptDay, false) + "} } " +
            "else if (document.getElementById('" + this.rbtType.ClientID + "_1').checked) {" +
            "if (document.getElementById('" + this.cmbMonthFrom.ClientID + "').value == '' || document.getElementById('" + this.txtMYearFrom.ClientID + "').value == '' || " +
            "document.getElementById('" + this.cmbMonthTo.ClientID + "').value == '' || document.getElementById('" + this.txtMYearTo.ClientID + "').value == '') " +
            "{ alert ('" + string.Format(DataResources.MSGEI002, "ช่วงเดือนและปี") + "'); return false; } else {" + Appz.OpenReportScript(Constant.Reports.StockOutHosToolsMonth, scriptMonth, false) + "} } " +
            "else {" +
            "if (document.getElementById('" + this.txtYearFrom.ClientID + "').value == '' || document.getElementById('" + this.txtYearTo.ClientID + "').value == '') " +
            "{ alert ('" + string.Format(DataResources.MSGEI002, "ช่วงปี") + "'); return false; } else {" + Appz.OpenReportScript(Constant.Reports.StockOutHosToolsYear, scriptYear, false) + "} } ";
        this.tbPrint.ClientClick = script;
    }

    protected override void OnInit(EventArgs e)
    {
        base.OnInit(e);
        Appz.BuildCombo(this.cmbMaterialClass, "V_STOCKOUTHOSTOOLS_REPORT", "CLASSNAME", "MATERIALCLASS", "MASTERTYPE = 'TL'", "CLASSNAME", "ทั้งหมด", "0", true);
        Appz.BuildCombo(this.cmbMaterialMaster, "V_STOCKOUTHOSTOOLS_REPORT", "MATERIALNAME", "MATERIALMASTER", "MASTERTYPE = 'TL'", "MATERIALNAME", "ทั้งหมด", "0", true);
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
