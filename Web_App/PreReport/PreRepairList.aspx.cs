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
/// PreRepairList Page Class
/// Version 1.0
/// =========================================================================
/// Create by: Teang
/// Create Date: 14 May 2009
/// -------------------------------------------------------------------------
/// Modify By: -
/// Modify From: -
/// Modify Date: -
/// -------------------------------------------------------------------------
/// Remark: -
/// Description:
///    หน้าการทำรายการข้อมูล PreRepairList
/// Changes:
///    1.0 - สร้าง
/// -------------------------------------------------------------------------
/// =========================================================================
/// </summary>
/// 
public partial class PreReport_PreRepairList : System.Web.UI.Page
{
    protected override void OnInit(EventArgs e)
    {
        base.OnInit(e);
        if (Appz.LoggedOnUser.DIVISION.ToString() == Appz.GetConfigValue(24))
            Appz.BuildCombo(this.cmbDivision, "V_REPAIRLIST_REPORT", "DIVISIONNAME", "DIVISION", "", "DIVISIONNAME", "ทั้งหมด", "0", true);
        else
        {
            Appz.BuildCombo(this.cmbDivision, "DIVISION", "NAME", "LOID", "LOID = " + Appz.LoggedOnUser.DIVISION.ToString(), "NAME", null, null, true);
            this.cmbDivision.Enabled = false;
        }
        //Appz.BuildCombo(this.cmbDivision, "V_REPAIRLIST_REPORT", "DIVISIONNAME", "DIVISION", "", "DIVISIONNAME", "ทั้งหมด", "0", true);
        this.rblRepairStatus.SelectedIndex = 0;
        Appz.BuildCombo(this.cmbMaterialClass, "V_REPAIRLIST_REPORT", "CLASSNAME", "MATERIALCLASS", "", "CLASSNAME", "ทั้งหมด", "0", true);
        Appz.BuildCombo(this.cmbMaterialMaster, "V_REPAIRLIST_REPORT", "MATERIALNAME", "MATERIALMASTER", "", "MATERIALNAME", "ทั้งหมด", "0", true);
        this.cmbStatusTo.SelectedIndex = (this.cmbStatusTo.Items.Count - 1);

        string script = "paramfield1=DIVISION&paramvalue1=' + document.getElementById('" + this.cmbDivision.ClientID + "').value +" +
            "'&paramfield2=MATERIALCLASS&paramvalue2=' + document.getElementById('" + this.cmbMaterialClass.ClientID + "').value +" +
            "'&paramfield3=MATERIALMASTER&paramvalue3=' + document.getElementById('" + this.cmbMaterialMaster.ClientID + "').value +" +
            "'&paramfield4=DATEFROM&paramvalue4=' + document.getElementById('" + this.ctlStockOutDateFrom.CalendarClientID + "').value +" +
            "'&paramfield5=DATETO&paramvalue5=' + document.getElementById('" + this.ctlStockOutDateTo.CalendarClientID + "').value +" +
            "'&paramfield6=REPAIRSTATUS&paramvalue6=' + (document.getElementById('" + this.rblRepairStatus.ClientID + "_1').checked ? document.getElementById('" + this.rblRepairStatus.ClientID + "_1').value : " +
            "(document.getElementById('" + this.rblRepairStatus.ClientID + "_2').checked ? document.getElementById('" + this.rblRepairStatus.ClientID + "_2').value : '')) + " +
            "'&paramfield7=RANKFROM&paramvalue7=' + document.getElementById('" + this.cmbStatusFrom.ClientID + "').value +" +
            "'&paramfield8=RANKTO&paramvalue8=' + document.getElementById('" + this.cmbStatusTo.ClientID + "').value +'";
        this.tbPrint.ClientClick = "if (document.getElementById('" + this.ctlStockOutDateFrom.CalendarClientID + "').value == '' || document.getElementById('" + this.ctlStockOutDateTo.CalendarClientID + "').value == '') " +
            "{ alert ('" + string.Format(DataResources.MSGEI002, "ช่วงวันที่") + "'); return false; } else {" + Appz.OpenReportScript(Constant.Reports.RepairList, script, true) + "}";
    }

    protected void Page_Load(object sender, EventArgs e)
    {

    }
}
