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
/// PreStockOutHosList Page Class
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
///    หน้าการทำรายการข้อมูล PreStockOutHosList
/// Changes:
///    1.0 - สร้าง
/// -------------------------------------------------------------------------
/// =========================================================================
/// </summary>
/// 
public partial class PreReport_PreStockOutHosList : System.Web.UI.Page
{
    protected override void OnInit(EventArgs e)
    {
        base.OnInit(e);
        Appz.BuildCombo(this.cmbMaterialClass, "V_STOCKOUTHOSLIST_REPORT", "CLASSNAME", "MATERIALCLASS", "", "CLASSNAME", "ทั้งหมด", "0", true);
        string script = "paramfield1=MATERIALCLASS&paramvalue1=' + document.getElementById('" + this.cmbMaterialClass.ClientID + "').value + " +
            "'&paramfield2=DATEFROM&paramvalue2=' + document.getElementById('" + this.ctlDateFrom.CalendarClientID + "').value + " +
            "'&paramfield3=DATETO&paramvalue3=' + document.getElementById('" + this.ctlDateTo.CalendarClientID + "').value + '";
        this.tbPrint.ClientClick = "if (document.getElementById('" + this.ctlDateFrom.CalendarClientID + "').value == '' || document.getElementById('" + this.ctlDateTo.CalendarClientID + "').value == '') " +
            "{ alert ('" + string.Format(DataResources.MSGEI002, "ช่วงวันที่") + "'); return false; } else {" + Appz.OpenReportScript(Constant.Reports.StockOutHosList, script, false) + "}";
    }

    protected void Page_Load(object sender, EventArgs e)
    {

    }
}
