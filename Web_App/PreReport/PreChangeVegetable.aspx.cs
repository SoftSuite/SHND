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

public partial class PreReport_PreChangeVegetable : System.Web.UI.Page
{
    protected override void OnInit(EventArgs e)
    {
        base.OnInit(e);
        this.txtDivision.Text = Appz.LoggedOnUser.DIVISION.ToString();
        Appz.BuildCombo(this.cmbClass, "MATERIALCLASS", "NAME", "LOID", " MASTER = 'FO' AND ACTIVE = '1' ", "NAME", "ทั้งหมด", "0", false);
        this.tbPrint.ClientClick = Appz.OpenReportScript(Constant.Reports.ChangeVegetable, "paramfield1=material&paramvalue1=' + document.getElementById('" + this.txtMaterial.ClientID + "').value + " +
            "'&paramfield2=datefrom&paramvalue2=' + document.getElementById('" + this.ctlDateFrom.CalendarClientID + "').value + " +
            "'&paramfield3=dateto&paramvalue3=' + document.getElementById('" + this.ctlDateTo.CalendarClientID + "').value + " +
            "'&paramfield4=class&paramvalue4=' + document.getElementById('" + this.cmbClass.ClientID + "').value + '", true);
    }

    protected void Page_Load(object sender, EventArgs e)
    {
    }

}
