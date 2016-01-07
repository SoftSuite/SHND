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

public partial class App_Prepare_PreReport_PatientNutrientPreReport : System.Web.UI.Page
{
    protected override void OnInit(EventArgs e)
    {
        base.OnInit(e);

            string script = "paramfield1=datefrom&paramvalue1=' + document.getElementById('" + this.ctlDateFrom.CalendarClientID + "').value + '" +
                "&paramfield2=dateto&paramvalue2=' + document.getElementById('" + this.ctlDateTo.CalendarClientID + "').value + '" +
                "&paramfield3=meal&paramvalue3=' + document.getElementById('" + this.cmbMeal.ClientID + "').value + '" +
                "&paramfield4=AN&paramvalue4=' + document.getElementById('" + this.txtAN.ClientID + "').value + '";


            this.tbPrint.ClientClick = "if (document.getElementById('" + this.txtAN.ClientID + "').value == '')" +
            "{ alert('" + string.Format(DataResources.MSGEI001, "AN") + "'); return false; } " +
            "else if (document.getElementById('" + this.ctlDateFrom.CalendarClientID + "').value == '' || document.getElementById('" + this.ctlDateTo.CalendarClientID + "').value == '')" +
            "{ alert('" + string.Format(DataResources.MSGEI002, "เมนูวันที่") + "'); return false; } " +
            "else { " + Appz.OpenReportScript(Constant.Reports.PatientNutrientReport, script, true) + "} ";

    }
    protected void Page_Load(object sender, EventArgs e)
    {

    }
}
