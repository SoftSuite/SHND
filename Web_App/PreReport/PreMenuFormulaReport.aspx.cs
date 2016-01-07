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

public partial class PreReport_PreMenuFormulaReport : System.Web.UI.Page
{
    private void SetReportScript()
    {
        if (cmbMeal.SelectedValue == "00")
        {
            txtTimeFrom.ReadOnly = true;
            txtTimeTo.ReadOnly = true;
            txtTimeFrom.CssClass = "zTextbox-View";
            txtTimeTo.CssClass = "zTextbox-View";

            string script = "paramfield1=division&paramvalue1=" + txtDivision.Text +
            "&paramfield2=timefrom&paramvalue2=" + "00:00" +
            "&paramfield3=timeto&paramvalue3=" + "24:00" +
            "&paramfield4=meal&paramvalue4=' + document.getElementById('" + this.cmbMeal.ClientID + "').value + '" +
            "&paramfield5=foodtype&paramvalue5=' + document.getElementById('" + this.cmbFoodType.ClientID + "').value + '" +
            "&paramfield6=foodcategory&paramvalue6=' + document.getElementById('" + this.cmbFoodCategory.ClientID + "').value + '" +
            "&paramfield7=menudate&paramvalue7=' + document.getElementById('" + this.ctlDate.CalendarClientID + "').value + '";

            this.tbPrint.ClientClick = "if (document.getElementById('" + this.ctlDate.CalendarClientID + "').value == '') " +
                "{ alert('" + string.Format(DataResources.MSGEI002, "วันที่") + "'); return false; } else { " + Appz.OpenReportScript(Constant.Reports.MenuFormulaReport, script, true) + "} ";

        }
        else
        {
            txtTimeFrom.ReadOnly = false;
            txtTimeTo.ReadOnly = false;
            txtTimeFrom.CssClass = "zTextbox";
            txtTimeTo.CssClass = "zTextbox";

            string script = "paramfield1=division&paramvalue1=" + txtDivision.Text +
            "&paramfield2=timefrom&paramvalue2=' + document.getElementById('" + this.txtTimeFrom.ClientID + "').value + '" +
            "&paramfield3=timeto&paramvalue3=' + document.getElementById('" + this.txtTimeTo.ClientID + "').value + '" +
            "&paramfield4=meal&paramvalue4=' + document.getElementById('" + this.cmbMeal.ClientID + "').value + '" +
            "&paramfield5=foodtype&paramvalue5=' + document.getElementById('" + this.cmbFoodType.ClientID + "').value + '" +
            "&paramfield6=foodcategory&paramvalue6=' + document.getElementById('" + this.cmbFoodCategory.ClientID + "').value + '" +
            "&paramfield7=menudate&paramvalue7=' + document.getElementById('" + this.ctlDate.CalendarClientID + "').value + '";

            this.tbPrint.ClientClick = "if (document.getElementById('" + this.ctlDate.CalendarClientID + "').value == '') " +
                "{ alert('" + string.Format(DataResources.MSGEI002, "วันที่") + "'); return false; } " +
                "else if (document.getElementById('" + this.txtTimeFrom.ClientID + "').value == '' || document.getElementById('" + this.txtTimeTo.ClientID + "').value == '') " +
                "{ alert('" + string.Format(DataResources.MSGEI001, "เวลา") + "'); return false; } " +
                "else { " + Appz.OpenReportScript(Constant.Reports.MenuFormulaReport, script, true) + "} ";

        }
    }

    protected override void OnInit(EventArgs e)
    {
        base.OnInit(e);
        this.txtDivision.Text = Appz.LoggedOnUser.DIVISION.ToString();
        this.txtDivisionName.Text = Appz.LoggedOnUser.DIVISIONNAME;
        Appz.BuildCombo(this.cmbFoodType, "FOODTYPE", "NAME", "LOID", " ACTIVE='1' AND DIVISION= " + Appz.LoggedOnUser.DIVISION.ToString()+" ", "NAME", "ทั้งหมด", "0", true);
        Appz.BuildCombo(this.cmbFoodCategory, "FOODCATEGORY", "NAME", "LOID", " ACTIVE='1' ", "NAME", "ทั้งหมด", "0", true);
        SetReportScript();
    }

    protected void Page_Load(object sender, EventArgs e)
    {
    }

    protected void cmbMeal_SelectedIndexChanged(object sender, EventArgs e)
    {
        SetReportScript();
    }
}
