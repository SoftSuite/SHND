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
/// PreStockInReturnToolsList Page Class
/// Version 1.0
/// =========================================================================
/// Create by: Teang
/// Create Date: 23 May 2009
/// -------------------------------------------------------------------------
/// Modify By: -
/// Modify From: -
/// Modify Date: -
/// -------------------------------------------------------------------------
/// Remark: -
/// Description:
///    หน้าการทำรายการข้อมูล PreStockInReturnToolsList
/// Changes:
///    1.0 - สร้าง
/// -------------------------------------------------------------------------
/// =========================================================================
/// </summary>
/// 
public partial class PreReport_PreStockInReturnToolsList : System.Web.UI.Page
{
    protected override void OnInit(EventArgs e)
    {
        base.OnInit(e);
        Appz.BuildCombo(this.cmbDivision, "V_STOCKINRETURNLIST_REPORT", "DIVISIONNAME", "DIVISION", "MASTERTYPE = 'TL'", "DIVISIONNAME", "ทั้งหมด", "0", true);
        Appz.BuildCombo(this.cmbMaterialClass, "V_STOCKINRETURNLIST_REPORT", "CLASSNAME", "MATERIALCLASS", "MASTERTYPE = 'TL'", "CLASSNAME", "ทั้งหมด", "0", true);
        string script = "paramfield1=DIVISION&paramvalue1=' + document.getElementById('" + this.cmbDivision.ClientID + "').value + " +
            "'&paramfield2=MATERIALCLASS&paramvalue2=' + document.getElementById('" + this.cmbMaterialClass.ClientID + "').value + " +
            "'&paramfield3=DATEFROM&paramvalue3=' + document.getElementById('" + this.ctlDateFrom.CalendarClientID + "').value + " +
            "'&paramfield4=DATETO&paramvalue4=' + document.getElementById('" + this.ctlDateTo.CalendarClientID + "').value + '";
        this.tbPrint.ClientClick = "if (document.getElementById('" + this.ctlDateFrom.CalendarClientID + "').value == '' || document.getElementById('" + this.ctlDateTo.CalendarClientID + "').value == '') " +
            "{ alert ('" + string.Format(DataResources.MSGEI002, "ช่วงวันที่") + "'); return false; } else {" + Appz.OpenReportScript(Constant.Reports.StockInReturnToolsList, script, false) + "}";
    }

    protected void Page_Load(object sender, EventArgs e)
    {

    }
}
