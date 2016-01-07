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
/// <summary>
/// PreRequisitionMaterial Page Class
/// Version 1.0
/// =========================================================================
/// Create by: Nang
/// Create Date: 26 May 2009
/// -------------------------------------------------------------------------
/// Modify By: -
/// Modify From: -
/// Modify Date: -
/// -------------------------------------------------------------------------
/// Remark: -
/// Description:
///    หน้าการทำรายการข้อมูล PreRequisitionMaterial
/// Changes:
///    1.0 - สร้าง
/// -------------------------------------------------------------------------
/// =========================================================================
/// </summary>
/// 

public partial class PreReport_PreRequisitionMaterial : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {

    }

    protected override void OnInit(EventArgs e)
    {
        base.OnInit(e);
        Appz.BuildCombo(cmbDivision, "DIVISION", "DOCNAME", "LOID", "ISONLINEREQUEST = 'Y'", "NAME", "ทั้งหมด", "0", true);
        Appz.BuildCombo(cmbMaterialClass, "MATERIALCLASS", "NAME", "LOID", "MASTERTYPE = 'FO'", "NAME", "ทั้งหมด", "0", true);
        Appz.BuildCombo(cmbMaterialMaster, "V_MATERIALMASTER", "MATERIALNAME", "LOID", "MASTERTYPE = 'FO' AND CLASSLOID = " + cmbMaterialClass.SelectedItem.Value + "", "NAME", "ทั้งหมด", "0", true);
        Appz.BuildCombo(cmbUnit, "V_MATERIALMASTER_UNIT", "UNITNAME", "UNIT", "ISSTOCKOUT = 'Y'", "NAME", "ทั้งหมด", "0", true);
        ControlUtil.SetYearTextbox(this.txtMYearFrom);
        ControlUtil.SetYearTextbox(this.txtMYearFrom);
        ControlUtil.SetYearTextbox(this.txtYearFrom);
        ControlUtil.SetYearTextbox(this.txtYearTo);
        lbStatusMain.Text = "";
        lbStatusMain.EnableViewState = false;
        SetScript();
    }

    protected void cmbMaterialClass_SelectIndexChange(object sender, EventArgs e)
    {
        Appz.BuildCombo(cmbMaterialMaster, "V_MATERIALMASTER", "MATERIALNAME", "LOID", "MASTERTYPE = 'FO' AND CLASSLOID = " + cmbMaterialClass.SelectedItem.Value + "", "NAME", "ทั้งหมด", "0", true);
    }
    private void SetScript()
    {
        string script = "if(document.getElementById('" + rdDay.ClientID + @"').checked)
                         {
                            document.getElementById('" + trDay.ClientID + @"').style.display = 'block';
                            document.getElementById('" + trMonth.ClientID + @"').style.display = 'none';
                            document.getElementById('" + trYear.ClientID + @"').style.display = 'none';
                            document.getElementById('" + lbStatusMain.ClientID + @"').style.display = 'none';
                         }
                         else if(document.getElementById('" + rdMonth.ClientID + @"').checked)
                         {
                            document.getElementById('" + trDay.ClientID + @"').style.display = 'none';
                            document.getElementById('" + trMonth.ClientID + @"').style.display = 'block';
                            document.getElementById('" + trYear.ClientID + @"').style.display = 'none';
                            document.getElementById('" + lbStatusMain.ClientID + @"').style.display = 'none';
                         }
                         else if(document.getElementById('" + rdYear.ClientID + @"').checked)
                         {
                            document.getElementById('" + trDay.ClientID + @"').style.display = 'none';
                            document.getElementById('" + trMonth.ClientID + @"').style.display = 'none';
                            document.getElementById('" + trYear.ClientID + @"').style.display = 'block';
                            document.getElementById('" + lbStatusMain.ClientID + @"').style.display = 'none';
                         }";

        rdDay.Attributes.Add("onclick", script);
        rdMonth.Attributes.Add("onclick", script);
        rdYear.Attributes.Add("onclick", script);
    }

    protected void tbPrintClick(object sender, EventArgs e)
    {

        if (rdDay.Checked)
        {
            if (ctlDateFrom.DateValue.Year.ToString() == "1" || ctlDateTo.DateValue.Year.ToString() == "1")
            {
                lbStatusMain.Text = string.Format(DataResources.MSGEI002, "ช่วงวันที่");
                lbStatusMain.ForeColor = Constant.StatusColor.Error;
                CheckRadio();
                return;
            }
            else
            {
                DateTime strDateFrom = new DateTime(ctlDateFrom.DateValue.Year, ctlDateFrom.DateValue.Month, ctlDateFrom.DateValue.Day);
                DateTime strDateTo = new DateTime(ctlDateTo.DateValue.Year, ctlDateTo.DateValue.Month, ctlDateTo.DateValue.Day);

                string strFrom = Convert.ToString(strDateFrom.Year + 543) + '-' + strDateFrom.Month.ToString("00") + '-' + strDateFrom.Day.ToString("00");
                string strTo = Convert.ToString(strDateTo.Year + 543) + '-' + strDateTo.Month.ToString("00") + '-' + strDateTo.Day.ToString("00");

                string strFromTh = strDateFrom.Day.ToString("00") + '/' + strDateFrom.Month.ToString("00") + '/' + Convert.ToString(strDateFrom.Year + 543);
                string strToTh = strDateTo.Day.ToString("00") + '/' + strDateTo.Month.ToString("00") + '/' + Convert.ToString(strDateTo.Year + 543);

                string script = OpenReportScript(Constant.Reports.RequisitionMaterialDayReport, "paramfield1=class&paramvalue1=" + cmbMaterialClass.SelectedItem.Value +
               "&paramfield2=division&paramvalue2=" + cmbDivision.SelectedItem.Value +
               "&paramfield3=v_unit&paramvalue3=" + cmbUnit.SelectedItem.Value +
               "&paramfield4=datefrom&paramvalue4=" + strFrom +
               "&paramfield5=dateto&paramvalue5=" + strTo +
               "&paramfield6=datefromthai&paramvalue6=" + strFromTh +
               "&paramfield7=datetothai&paramvalue7=" + strToTh +
               "&paramfield8=material&paramvalue8=" + cmbMaterialMaster.SelectedItem.Value, false);

                ScriptManager.RegisterStartupScript(Page, GetType(), "report", "<script language='javascript'>" + script + "</script>", false);
            }
        }
        else if (rdMonth.Checked)
        {
            if (cmbMonthFrom.SelectedItem.Value.ToString() == "0" || cmbMonthTo.SelectedItem.Value.ToString() == "0")
            {
                lbStatusMain.Text = string.Format(DataResources.MSGEI002, "ช่วงเดือน");
                lbStatusMain.ForeColor = Constant.StatusColor.Error;
                CheckRadio();
                return;
            }
            else if (txtMYearFrom.Text.Trim() == "" || txtMYearTo.Text.Trim() == "")
            {
                lbStatusMain.Text = string.Format(DataResources.MSGEI001, "ช่วงปี");
                lbStatusMain.ForeColor = Constant.StatusColor.Error;
                CheckRadio();
                return;
            }
            else if (cmbMonthFrom.SelectedItem.Value.ToString() == "0" || cmbMonthTo.SelectedItem.Value.ToString() == "0" || txtMYearFrom.Text.Trim() == "" || txtMYearTo.Text.Trim() == "")
            {
                lbStatusMain.Text = string.Format(DataResources.MSGEI002, "ช่วงเดือนและปี");
                lbStatusMain.ForeColor = Constant.StatusColor.Error;
                CheckRadio();
                return;
            }

            else
            {
                string myfrom = cmbMonthFrom.SelectedItem.ToString() + ' ' + txtMYearFrom.Text.Trim();
                string myto = cmbMonthTo.SelectedItem.ToString() + ' ' + txtMYearTo.Text.Trim();
                string monthyearfrom = cmbMonthFrom.SelectedValue.ToString() + (txtMYearFrom.Text.Trim() == "" ? "9999" : Convert.ToString(Convert.ToDouble(txtMYearFrom.Text.Trim()) - 543));
                string monthyearto = cmbMonthTo.SelectedValue.ToString() + (txtMYearTo.Text.Trim() == "" ? "9999" : Convert.ToString(Convert.ToDouble(txtMYearTo.Text.Trim()) - 543));


                string script = OpenReportScript(Constant.Reports.RequisitionMaterialMonthReport, "paramfield1=class&paramvalue1=" + cmbMaterialClass.SelectedItem.Value +
               "&paramfield2=division&paramvalue2=" + cmbDivision.SelectedItem.Value +
               "&paramfield3=v_unit&paramvalue3=" + cmbUnit.SelectedItem.Value +
               "&paramfield4=monthyearfrom&paramvalue4=" + monthyearfrom +
               "&paramfield5=monthyearto&paramvalue5=" + monthyearto +
               "&paramfield6=myfrom&paramvalue6=" + Server.UrlEncode(myfrom) +
               "&paramfield7=myto&paramvalue7=" + Server.UrlEncode(myto) +
               "&paramfield8=material&paramvalue8=" + cmbMaterialMaster.SelectedItem.Value , false);

                ScriptManager.RegisterStartupScript(Page, GetType(), "report", "<script language='javascript'>" + script + "</script>", false);
            }
        }
        else if (rdYear.Checked)
        {
            if (txtYearFrom.Text.Trim() == "" || txtYearTo.Text.Trim() == "")
            {
                lbStatusMain.Text = string.Format(DataResources.MSGEI001, "ช่วงปี");
                lbStatusMain.ForeColor = Constant.StatusColor.Error;
                CheckRadio();
                return;
            }
            else
            {
                CheckRadio();
                string script = OpenReportScript(Constant.Reports.RequisitionMaterialYearReport, "paramfield1=class&paramvalue1=" + cmbMaterialClass.SelectedItem.Value +
               "&paramfield2=division&paramvalue2=" +cmbDivision.SelectedItem.Value +
               "&paramfield3=v_unit&paramvalue3=" + cmbUnit.SelectedItem.Value +
               "&paramfield4=yearfrom&paramvalue4=" + (txtYearFrom.Text.Trim() == "" ? "0" : txtYearFrom.Text.Trim()) +
               "&paramfield5=yearto&paramvalue5=" + (txtYearTo.Text.Trim() == "" ? "0" : txtYearTo.Text.Trim()) +
               "&paramfield6=material&paramvalue6= " + cmbMaterialMaster.SelectedItem.Value , false);
                
                ScriptManager.RegisterStartupScript(Page, GetType(), "report", "<script language='javascript'>" + script + "</script>", false);
            }
        }

        CheckRadio();
    }

    private void CheckRadio()
    {
        if (rdDay.Checked)
        {
            trDay.Style["display"] = "block";
            trMonth.Style["display"] = "none";
            trYear.Style["display"] = "none";
            lbStatusMain.EnableViewState = false;
        }
        else if (rdMonth.Checked)
        {
            trDay.Style["display"] = "none";
            trMonth.Style["display"] = "block";
            trYear.Style["display"] = "none";
            lbStatusMain.EnableViewState = false;
        }
        else if (rdYear.Checked)
        {
            trDay.Style["display"] = "none";
            trMonth.Style["display"] = "none";
            trYear.Style["display"] = "block";
            lbStatusMain.EnableViewState = false;
        }
    }


    private string OpenReportScript(string reportName, string parameterString, bool isLandscape)
    {
        return "window.open('" + Constant.ReportWebUrl + "Default.aspx?landscape=" + (isLandscape ? "1" : "0") + "&" + Constant.QueryString.ReportName + "=" + reportName + (parameterString == "" ? "" : "&") + parameterString + "', 'zReport', 'status=yes, toolbar=no, scrollbars=yes, menubar=no, width=800, height=600, resizable=yes');";
    }
}
