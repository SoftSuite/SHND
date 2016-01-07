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

public partial class PreReport_PreMenuPortionReport : System.Web.UI.Page
{
    protected override void OnInit(EventArgs e)
    {
        base.OnInit(e);
        this.txtDivision.Text = Appz.LoggedOnUser.DIVISION.ToString();
        this.txtDivisionName.Text = Appz.LoggedOnUser.DIVISIONNAME;
        Appz.BuildCombo(this.cmbFoodType, "FOODTYPE", "NAME", "LOID", " AND ACTIVE='1' AND DIVISION= " + Appz.LoggedOnUser.DIVISION.ToString() + " ", "NAME", "ทั้งหมด", "0", true);
        Appz.BuildCombo(this.cmbFoodCategory, "FOODCATEGORY", "NAME", "LOID", " AND ACTIVE='1' ", "NAME", "ทั้งหมด", "0", true);

        string script = "paramfield1=division&paramvalue1=" + txtDivision.Text +
"&paramfield2=meal&paramvalue2=' + document.getElementById('" + this.cmbMeal.ClientID + "').value + '" +
"&paramfield3=foodtype&paramvalue3=' + document.getElementById('" + this.cmbFoodType.ClientID + "').value + '" +
"&paramfield4=foodcategory&paramvalue4=' + document.getElementById('" + this.cmbFoodCategory.ClientID + "').value + '" +
"&paramfield5=menudate&paramvalue5=' + document.getElementById('" + this.ctlDate.CalendarClientID + "').value + '";

        this.tbPrint.ClientClick = "if (document.getElementById('" + this.ctlDate.CalendarClientID + "').value == '') " +
            "{ alert('" + string.Format(DataResources.MSGEI002, "วันที่") + "'); return false; } else { " + Appz.OpenReportScript(Constant.Reports.MenuPortionReport, script, true) + "} ";

    }

    protected void Page_Load(object sender, EventArgs e)
    {
    }

}
