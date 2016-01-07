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

public partial class App_Formula_PreReport_StdMenuPreReport : System.Web.UI.Page
{
    protected override void OnInit(EventArgs e)
    {
        base.OnInit(e);
        this.txtDivision.Text = Appz.LoggedOnUser.DIVISION.ToString();
        this.txtDivisionName.Text = Appz.LoggedOnUser.DIVISIONNAME;
        Appz.BuildCombo(this.cmbStdMenu, "STDMENU", "NAME", "LOID", "", "NAME", "ทั้งหมด", "0", false);
        Appz.BuildCombo(this.cmbFoodCategory, "FOODCATEGORY", "NAME", "LOID", "ACTIVE = '1'", "NAME", "ทั้งหมด", "0", false);
        Appz.BuildCombo(this.cmbFoodType, "FOODTYPE", "NAME", "LOID", "ACTIVE = '1'", "NAME", "ทั้งหมด", "0", false);
        ControlUtil.SetNumberTextbox(this.txtMenuDateFrom);
        ControlUtil.SetNumberTextbox(this.txtMenuDateTo);
    }
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            this.tbPrint.ClientClick = Appz.OpenReportScript(Constant.Reports.StdMenuReport_2, "paramfield1=DIVISION&paramvalue1=" + this.txtDivision.Text +
                "&paramfield2=FOODCATEGORY&paramvalue2=' + document.getElementById('" + this.cmbFoodCategory.ClientID + "').value + '" +
                "&paramfield3=FOODTYPE&paramvalue3=' + document.getElementById('" + this.cmbFoodType.ClientID + "').value + '" +
                "&paramfield4=STDMENU&paramvalue4=' +document.getElementById('" + this.cmbStdMenu.ClientID + "').value + '" +
                "&paramfield5=MENUDATEFROM&paramvalue5=0' + document.getElementById('" + this.txtMenuDateFrom.ClientID + "').value + '" +
                "&paramfield6=MENUDATETO&paramvalue6=0' + document.getElementById('" + this.txtMenuDateTo.ClientID + "').value + '", true);
        }
    }
}
