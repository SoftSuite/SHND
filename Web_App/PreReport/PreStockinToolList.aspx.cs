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
using SHND.Global;
using SHND.Data.Common.Utilities;

/// <summary>
/// PreMaterialRemain Page Class
/// Version 1.0
/// =========================================================================
/// Create by: Tan
/// Create Date: 23 May 2009
/// -------------------------------------------------------------------------
/// Modify By: -
/// Modify From: -
/// Modify Date: -
/// -------------------------------------------------------------------------
/// Remark: -
/// Description:
///    หน้าการทำรายการข้อมูล PreStockinToolList
/// Changes:
///    1.0 - สร้าง
/// -------------------------------------------------------------------------
/// =========================================================================
/// </summary>
/// 
public partial class PreReport_PreStockinToolList : System.Web.UI.Page
{
    protected override void OnInit(EventArgs e)
    {
        base.OnInit(e);
        Appz.BuildCombo(this.cmbType, "DOCTYPE", "DOCNAME", "LOID", " TYPE = 'L'", "DOCNAME", "ทั้งหมด", "0", true);
        Appz.BuildCombo(this.cmbMaterialClass, "MATERIALCLASS", "NAME", "LOID", " MASTERTYPE = 'FO' ", "NAME", "ทั้งหมด", "0", true);
        
        string script = "paramfield1=type&paramvalue1=' + document.getElementById('" + this.cmbType.ClientID + "').value +" +
            "'&paramfield2=class&paramvalue2=' + document.getElementById('" + this.cmbMaterialClass.ClientID + "').value +" +
            "'&paramfield3=datefrom&paramvalue3=' + document.getElementById('" + this.ctlStockOutDateFrom.CalendarClientID + "').value +" +
            "'&paramfield4=dateto&paramvalue4=' + document.getElementById('" + this.ctlStockOutDateTo.CalendarClientID + "').value + '";

        this.tbPrint.ClientClick = "if (document.getElementById('" + this.ctlStockOutDateFrom.CalendarClientID + "').value == '' || document.getElementById('" + this.ctlStockOutDateTo.CalendarClientID + "').value == '') " +
            "{ alert('" + string.Format(DataResources.MSGEI002, "วันที่") + "'); return false; } else { " + Appz.OpenReportScript(Constant.Reports.StockInToolList, script, true) + "} ";
    }

    protected void Page_Load(object sender, EventArgs e)
    {

    }
}
