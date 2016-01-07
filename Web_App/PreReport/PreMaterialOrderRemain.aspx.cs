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

public partial class PreReport_PreMaterialOrderRemain : System.Web.UI.Page
{
    private void SetReportScript()
    {
        string script1 = "paramfield1=division&paramvalue1=' + document.getElementById('" + this.cmbDivision.ClientID + "').value + '" +
    "&paramfield2=class&paramvalue2=' + document.getElementById('" + this.cmbClass.ClientID + "').value + '" +
    "&paramfield3=plan&paramvalue3=' + document.getElementById('" + this.cmbPlan.ClientID + "').value + '";

        string script2 = "paramfield1=plan&paramvalue1=' + document.getElementById('" + this.cmbPlan.ClientID + "').value + '" +
            "&paramfield2=class&paramvalue2=' + document.getElementById('" + this.cmbClass.ClientID + "').value + '";

        if (rbtType.SelectedValue == "div")
        {
            this.tbPrint.ClientClick = "if (document.getElementById('" + this.cmbPlan.ClientID + "').value == '0') " +
    "{ alert('" + string.Format(DataResources.MSGEI002, "แผน") + "'); return false; } else { " + Appz.OpenReportScript(Constant.Reports.MaterialOrderRemainDivision, script1, true) + "} ";

        }
        else if (rbtType.SelectedValue == "sum")
        {
            this.tbPrint.ClientClick = "if (document.getElementById('" + this.cmbPlan.ClientID + "').value == '0') " +
    "{ alert('" + string.Format(DataResources.MSGEI002, "แผน") + "'); return false; } else { " + Appz.OpenReportScript(Constant.Reports.MaterialOrderRemainSum, script2, true) + "} ";
        }
    }

    protected override void OnInit(EventArgs e)
    {
        base.OnInit(e);

        Appz.BuildCombo(this.cmbPlan, "PLANORDER", "NAME", "LOID", " ISPLANFOOD = 'Y' ", "NAME", "เลือก", "0", true);
        Appz.BuildCombo(this.cmbClass, "MATERIALCLASS", "NAME", "LOID", " MASTERTYPE = 'FO' AND STOCKINTYPE = '1' ", "NAME", "ทั้งหมด", "0", false);
        Appz.BuildCombo(this.cmbDivision, "DIVISION", "NAME", "LOID", " ISPLAN='Y' ", "NAME", "ทั้งหมด", "999", false);
        SetReportScript();
    }

    protected void Page_Load(object sender, EventArgs e)
    {
    }

    protected void rbtType_SelectedIndexChanged(object sender, EventArgs e)
    {
        SetReportScript();
    }
    protected void cmbDivision_SelectedIndexChanged(object sender, EventArgs e)
    {
        if (cmbDivision.SelectedValue == "999")
            rbtType.Enabled = true;
        else
        {
            rbtType.Enabled = false;
            rbtType.SelectedValue = "div";
        }
    }
}
