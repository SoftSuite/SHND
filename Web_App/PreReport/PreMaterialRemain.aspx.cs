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
/// Create by: Teang
/// Create Date: 14 May 2009
/// -------------------------------------------------------------------------
/// Modify By: -
/// Modify From: -
/// Modify Date: -
/// -------------------------------------------------------------------------
/// Remark: -
/// Description:
///    ˹�ҡ�÷���¡�â����� PreMaterialRemain
/// Changes:
///    1.0 - ���ҧ
/// -------------------------------------------------------------------------
/// =========================================================================
/// </summary>
/// 
public partial class PreReport_PreMaterialRemain : System.Web.UI.Page
{
    protected override void OnInit(EventArgs e)
    {
        base.OnInit(e);
        Appz.BuildCombo(this.cmbPlan, "V_MATERIALREMAIN_REPORT", "PLANNAME", "LOID", "", "PLANNAME", "������", "0", true);
        Appz.BuildCombo(this.cmbMaterialClass, "V_MATERIALREMAIN_REPORT", "CLASSNAME", "MATERIALCLASS", "", "CLASSNAME", "������", "0", true);
        string script = "paramfield1=PLAN&paramvalue1=' + document.getElementById('" + this.cmbPlan.ClientID + "').value +" +
            "'&paramfield2=MATERIALCLASS&paramvalue2=' + document.getElementById('" + this.cmbMaterialClass.ClientID + "').value +" +
            "'&paramfield3=DATEFROM&paramvalue3=' + document.getElementById('" + this.ctlStockOutDateFrom.CalendarClientID + "').value +" +
            "'&paramfield4=DATETO&paramvalue4=' + document.getElementById('" + this.ctlStockOutDateTo.CalendarClientID + "').value + '";

        this.tbPrint.ClientClick = "if (document.getElementById('" + this.ctlStockOutDateFrom.CalendarClientID + "').value == '' || document.getElementById('" + this.ctlStockOutDateTo.CalendarClientID + "').value == '') " +
            "{ alert('" + string.Format(DataResources.MSGEI002, "��ǧ�ѹ���") + "'); return false; } else { " + Appz.OpenReportScript(Constant.Reports.MaterialRemain, script, true) + "} ";
    }

    protected void Page_Load(object sender, EventArgs e)
    {

    }
}
