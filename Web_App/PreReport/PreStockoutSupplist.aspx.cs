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
///    ˹�ҡ�÷���¡�â����� PreStockoutSupplist
/// Changes:
///    1.0 - ���ҧ
/// -------------------------------------------------------------------------
/// =========================================================================
/// </summary>
/// 
public partial class PreReport_PreStockoutSupplist : System.Web.UI.Page
{
    protected override void OnInit(EventArgs e)
    {
        base.OnInit(e);
        Appz.BuildCombo(this.cmbSupplier, "SUPPLIER", "NAME", "LOID", "", "NAME", "������", "0", true);
        Appz.BuildCombo(this.cmbMaterialClass, "MATERIALCLASS", "NAME", "LOID", " MASTERTYPE = 'FO' ", "NAME", "������", "0", true);
        
        string script = "paramfield1=supplier&paramvalue1=' + document.getElementById('" + this.cmbSupplier.ClientID + "').value +" +
            "'&paramfield2=class&paramvalue2=' + document.getElementById('" + this.cmbMaterialClass.ClientID + "').value +" +
            "'&paramfield3=datefrom&paramvalue3=' + document.getElementById('" + this.ctlStockOutDateFrom.CalendarClientID + "').value +" +
            "'&paramfield4=dateto&paramvalue4=' + document.getElementById('" + this.ctlStockOutDateTo.CalendarClientID + "').value + '";

        this.tbPrint.ClientClick = "if (document.getElementById('" + this.ctlStockOutDateFrom.CalendarClientID + "').value == '' || document.getElementById('" + this.ctlStockOutDateTo.CalendarClientID + "').value == '') " +
            "{ alert('" + string.Format(DataResources.MSGEI002, "�ѹ���") + "'); return false; } else { " + Appz.OpenReportScript(Constant.Reports.StockOutSupplist, script, true) + "} ";
    }

    protected void Page_Load(object sender, EventArgs e)
    {

    }
}
