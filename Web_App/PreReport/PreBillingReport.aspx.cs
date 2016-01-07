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

public partial class PreReport_PreBillingReport : System.Web.UI.Page
{
    private void SetReportScript()
    {
        string script = "paramfield1=ward&paramvalue1=' + document.getElementById('" + this.cmbWard.ClientID + "').value + '" +
                "&paramfield2=datefrom&paramvalue2=' + document.getElementById('" + this.ctlDateFrom.CalendarClientID + "').value + '" +
                "&paramfield3=dateto&paramvalue3=' + document.getElementById('" + this.ctlDateTo.CalendarClientID + "').value + '" +
                "&paramfield4=AN&paramvalue4=' + document.getElementById('" + this.txtAN.ClientID + "').value + '" +
                "&paramfield5=HN&paramvalue5=' + document.getElementById('" + this.txtHN.ClientID + "').value + '" +
                "&paramfield6=Name&paramvalue6=' + document.getElementById('" + this.txtName.ClientID + "').value + '";

                this.tbPrint.ClientClick = "if (document.getElementById('" + this.ctlDateFrom.CalendarClientID + "').value == '' || document.getElementById('" + this.ctlDateTo.CalendarClientID + "').value == '') " +
                "{ alert('" + string.Format(DataResources.MSGEI002, "วันที่ Admit") + "'); return false; } else { " + Appz.OpenReportScript(Constant.Reports.BillingReport, script, true) + "} ";

    }

    protected override void OnInit(EventArgs e)
    {
        base.OnInit(e);
        Appz.BuildCombo(this.cmbWard, "WARD", "NAME", "LOID", "ACTIVE = '1'", "NAME", "ทั้งหมด", "0", false);
        SetReportScript();
    }

    protected void Page_Load(object sender, EventArgs e)
    {

    }

}
