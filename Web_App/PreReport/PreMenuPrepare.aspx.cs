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
using SHND.Global;
using SHND.Data.Common.Utilities;

public partial class PreReport_PreMenuPrepare : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            ctMenuDate.DateValue = DateTime.Now;
            CheckMeal();
        }
    }

    protected override void OnInit(EventArgs e)
    {
        base.OnInit(e);
        Appz.BuildCombo(cmbDivision, "DIVISION", "NAME", "LOID", "ISFORMULA = 'Y' AND ACTIVE = '1'", "NAME", "ทั้งหมด", "0", false);    
        Appz.BuildCombo(cmbFoodCategory, "FOODCATEGORY", "NAME", "LOID", "ACTIVE='1'", "NAME", "ทั้งหมด", "0", false);
        SetCombo();

        this.tbPrint.ClientClick = "if (document.getElementById('" + this.txtPrintTimeFrom.ClientID + "').value != '') " +
        "{" +
        "if (parseFloat(document.getElementById('" + this.txtPrintTimeFrom.ClientID + "').value.split(':')[0]) >= 24 || parseFloat(document.getElementById('" + this.txtPrintTimeFrom.ClientID + "').value.split(':')[1]) > 59) " +
        "{ alert('รุปแบเวลาไม่ถูกต้อง (จำนวนชั่วโมงต้องน้อยกว่า 24 และนาทีต้องไม่เกิน 59)'); document.getElementById('" + this.txtPrintTimeFrom.ClientID + "').focus(); return false; } " +
        "} " +
        "if (document.getElementById('" + this.txtPrintTimeTo.ClientID + "').value != '') " +
        "{" +
        "if (parseFloat(document.getElementById('" + this.txtPrintTimeTo.ClientID + "').value.split(':')[0]) >= 24 || parseFloat(document.getElementById('" + this.txtPrintTimeTo.ClientID + "').value.split(':')[1]) > 59) " +
        "{ alert('รุปแบเวลาไม่ถูกต้อง (จำนวนชั่วโมงต้องน้อยกว่า 24 และนาทีต้องไม่เกิน 59)'); document.getElementById('" + this.txtPrintTimeTo.ClientID + "').focus(); return false; } " +
        "}";
    }

    private void SetCombo()
    {
        string division = Appz.LoggedOnUser.DIVISION.ToString();
        cmbDivision.SelectedIndex = cmbDivision.Items.IndexOf(cmbDivision.Items.FindByValue(division));
        //cmbDivision.Enabled = false;

        division = cmbDivision.SelectedItem.Value;
        Appz.BuildCombo(cmbMenu, "MENU", "NAME", "LOID", "DIVISION=" + division, "NAME", "ทั้งหมด", "0", false);
        Appz.BuildCombo(cmbFoodType, "FOODTYPE", "NAME", "LOID", "DIVISION=" + division + " AND ACTIVE='1'", "NAME", "ทั้งหมด", "0", false);
    }

    protected void tbPrintClick(object sender, EventArgs e)
    {
        string date = ctMenuDate.DateValue.Year.ToString() + ctMenuDate.DateValue.ToString("MMdd");
        string timefrom = (txtPrintTimeFrom.Text.Trim() == "" ? "0" : txtPrintTimeFrom.Text.Trim());
        string timeto = (txtPrintTimeTo.Text.Trim() == "" ? "0" : txtPrintTimeTo.Text.Trim());
        string meal = cmbMeal.SelectedItem.Value;
        string script = OpenReportScript(Constant.Reports.MenuPrepare, "paramfield1=division&paramvalue1=" + cmbDivision.SelectedItem.Value +
       "&paramfield2=menudate&paramvalue2=" + date +
       "&paramfield3=menuid&paramvalue3=" + cmbMenu.SelectedItem.Value +
       "&paramfield4=foodtypeid&paramvalue4=" + cmbFoodType.SelectedItem.Value +
       "&paramfield5=foodcategoryid&paramvalue5=" + cmbFoodCategory.SelectedItem.Value +
       "&paramfield6=timefrom&paramvalue6=" + timefrom +
       "&paramfield7=timeto&paramvalue7=" + timeto +
       "&paramfield8=meal&paramvalue8=" + meal, true);

        ScriptManager.RegisterStartupScript(Page, GetType(), "report", "<script language='javascript'>" + script + "</script>", false);
    }

    private string OpenReportScript(string reportName, string parameterString, bool isLandscape)
    {
        return "window.open('" + Constant.ReportWebUrl + "Default.aspx?landscape=" + (isLandscape ? "1" : "0") + "&" + Constant.QueryString.ReportName + "=" + reportName + (parameterString == "" ? "" : "&") + parameterString + "', 'zReport', 'status=yes, toolbar=no, scrollbars=yes, menubar=no, width=800, height=600, resizable=yes');";
    }

    protected void cmbMeal_SelectedIndexChanged(object sender, EventArgs e)
    {
        CheckMeal();
    }

    private void CheckMeal()
    {
        if (cmbMeal.SelectedItem.Value == "0")
        {
            txtPrintTimeFrom.Text = "";
            txtPrintTimeTo.Text = "";
            txtPrintTimeFrom.Enabled = false;
            txtPrintTimeTo.Enabled = false;
        }
        else
        {
            txtPrintTimeFrom.Enabled = true;
            txtPrintTimeTo.Enabled = true;
        }
    }
    protected void cmbDivision_SelectedIndexChanged(object sender, EventArgs e)
    {
        string division = cmbDivision.SelectedValue;
        Appz.BuildCombo(cmbMenu, "MENU", "NAME", "LOID", "DIVISION=" + division, "NAME", "ทั้งหมด", "0", false);
        Appz.BuildCombo(cmbFoodType, "FOODTYPE", "NAME", "LOID", "DIVISION=" + division + " AND ACTIVE='1'", "NAME", "ทั้งหมด", "0", false);
    }
}
