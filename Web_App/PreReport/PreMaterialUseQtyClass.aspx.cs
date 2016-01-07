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

public partial class PreReport_PreMaterialUseQtyClass : System.Web.UI.Page
{
    private void SetMaterialGroup()
    {
        Appz.BuildCombo(this.cmbGroup, "MATERIALGROUP", "NAME", "LOID", " ACTIVE = '1' AND MATERIALCLASS = " + cmbClass.SelectedValue, "NAME", "ทั้งหมด", "0", false);
    }

    protected override void OnInit(EventArgs e)
    {
        base.OnInit(e);
        this.txtDivision.Text = Appz.LoggedOnUser.DIVISION.ToString();
        this.txtDivisionName.Text = Appz.LoggedOnUser.DIVISIONNAME;
        Appz.BuildCombo(this.cmbClass, "MATERIALCLASS", "NAME", "LOID", " MASTERTYPE = 'FO' AND ACTIVE = '1' ", "NAME", "ทั้งหมด", "0", false);
        SetMaterialGroup();

        this.tbPrint.ClientClick = Appz.OpenReportScript(Constant.Reports.MaterialUseQtyClass, "paramfield1=division&paramvalue1=" + Server.UrlEncode(txtDivision.Text) +
            "&paramfield2=datefrom&paramvalue2=' + document.getElementById('" + this.ctlDateFrom.CalendarClientID + "').value + '" +
            "&paramfield3=dateto&paramvalue3=' + document.getElementById('" + this.ctlDateTo.CalendarClientID + "').value + '" +
            "&paramfield4=group&paramvalue4=' + document.getElementById('" + this.cmbGroup.ClientID + "').value + '" +
            "&paramfield5=type&paramvalue5=' + document.getElementById('" + this.cmbClass.ClientID + "').value + '", true);
    }

    protected void Page_Load(object sender, EventArgs e)
    {
    }

    protected void cmbClass_SelectedIndexChanged(object sender, EventArgs e)
    {
        SetMaterialGroup();
    }

}
