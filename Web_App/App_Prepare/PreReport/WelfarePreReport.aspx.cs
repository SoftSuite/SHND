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

public partial class App_Prepare_PreReport_WelfarePreReport : System.Web.UI.Page
{
    protected override void OnInit(EventArgs e)
    {
        base.OnInit(e);
        Appz.BuildCombo(this.cmbMenu, "MENU", "NAME", "LOID", " DIVISION=FN_GETCONFIGVALUEBYNAME('HRDIV') ", "NAME", "ทั้งหมด", "0", false);

    }
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            string script = "paramfield1=preparedate&paramvalue1=' + document.getElementById('" + this.ctlPrepareDate.CalendarClientID + "').value + '" +
    "&paramfield2=meal&paramvalue2=' + document.getElementById('" + this.cmbMeal.ClientID + "').value + '" +
    "&paramfield3=menu&paramvalue3=' + document.getElementById('" + this.cmbMenu.ClientID + "').value + '";

            this.tbPrint.ClientClick = "if (document.getElementById('" + this.ctlPrepareDate.CalendarClientID + "').value == '') " +
            "{ alert('" + string.Format(DataResources.MSGEI002, "วันที่เตรียม") + "'); return false; } else { " + Appz.OpenReportScript(Constant.Reports.MenuWelfareReport, script, true) + "} ";

            this.tbPrint2.ClientClick = "if (document.getElementById('" + this.ctlPrepareDate.CalendarClientID + "').value == '') " +
"{ alert('" + string.Format(DataResources.MSGEI002, "วันที่เตรียม") + "'); return false; } else { " + Appz.OpenReportScript(Constant.Reports.MaterialWelfareReport, script, true) + "} ";

        }
    }
}
