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

public partial class PreReport_PreMaterialMilk : System.Web.UI.Page
{
    private void SetReportScript()
    {
        if (cmbMeal.SelectedValue == "00")
        {
            txtTimeFrom.ReadOnly = true;
            txtTimeTo.ReadOnly = true;
            txtTimeFrom.CssClass = "zTextbox-View";
            txtTimeTo.CssClass = "zTextbox-View";

            string script = "paramfield1=material&paramvalue1=' + document.getElementById('" + this.cmbMilk.ClientID + "').value + '" +
            "&paramfield2=timefrom&paramvalue2=" + "00:00" +
            "&paramfield3=timeto&paramvalue3=" + "24:00" +
            "&paramfield4=meal&paramvalue4=' + document.getElementById('" + this.cmbMeal.ClientID + "').value + '" +
            "&paramfield5=date&paramvalue5=' + document.getElementById('" + this.ctlDate.CalendarClientID + "').value + '";

            this.tbPrint.ClientClick = "if (document.getElementById('" + this.cmbMilk.ClientID + "').value == '0') " +
                "{ alert('" + string.Format(DataResources.MSGEI002, "��Դ�����") + "'); return false; } " +
                "else if (document.getElementById('" + this.ctlDate.CalendarClientID + "').value == '' ) " +
                "{ alert('" + string.Format(DataResources.MSGEI002, "�ѹ���") + "'); return false; } " +
                "else { " + Appz.OpenReportScript(Constant.Reports.MaterialMilk, script, true) + "} ";

        }
        else
        {
            txtTimeFrom.ReadOnly = false;
            txtTimeTo.ReadOnly = false;
            txtTimeFrom.CssClass = "zTextbox";
            txtTimeTo.CssClass = "zTextbox";

            string script = "paramfield1=material&paramvalue1=' + document.getElementById('" + this.cmbMilk.ClientID + "').value + '" +
            "&paramfield2=timefrom&paramvalue2=' + document.getElementById('" + this.txtTimeFrom.ClientID + "').value + '" +
            "&paramfield3=timeto&paramvalue3=' + document.getElementById('" + this.txtTimeTo.ClientID + "').value + '" +
            "&paramfield4=meal&paramvalue4=' + document.getElementById('" + this.cmbMeal.ClientID + "').value + '" +
            "&paramfield5=date&paramvalue5=' + document.getElementById('" + this.ctlDate.CalendarClientID + "').value + '";

            this.tbPrint.ClientClick = "if (document.getElementById('" + this.cmbMilk.ClientID + "').value == '0') " +
            "{ alert('" + string.Format(DataResources.MSGEI002, "��Դ�����") + "'); return false; } " +
            "else if (document.getElementById('" + this.ctlDate.CalendarClientID + "').value == '' ) " +
            "{ alert('" + string.Format(DataResources.MSGEI002, "�ѹ���") + "'); return false; } " +
            "else if (document.getElementById('" + this.txtTimeFrom.ClientID + "').value == '' || document.getElementById('" + this.txtTimeTo.ClientID + "').value == '') " +
            "{ alert('" + string.Format(DataResources.MSGEI001, "����") + "'); return false; } " +
            "else { " + Appz.OpenReportScript(Constant.Reports.MaterialMilk, script, true) + "} ";

        }
    }

    protected override void OnInit(EventArgs e)
    {
        base.OnInit(e);
        Appz.BuildCombo(this.cmbMilk, "MILKCATEGORY", "NAME", "LOID", " ACTIVE='1' ", "NAME", "���͡", "0", true);
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
