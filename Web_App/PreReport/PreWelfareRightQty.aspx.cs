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
/// PreWelFareRightQty Page Class
/// Version 1.0
/// =========================================================================
/// Create by: Nang
/// Create Date: 22 May 2009
/// -------------------------------------------------------------------------
/// Modify By: -
/// Modify From: -
/// Modify Date: -
/// -------------------------------------------------------------------------
/// Remark: -
/// Description:
///    หน้าการทำรายการข้อมูล PreWelFareRightQty
/// Changes:
///    1.0 - สร้าง
/// -------------------------------------------------------------------------
/// =========================================================================
/// </summary>
/// 

public partial class PreReport_PreWelfareRightQty : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {

    }

    protected override void OnInit(EventArgs e)
    {
        base.OnInit(e);
        Appz.BuildCombo(cmbDivision, "DIVISION", "NAME", "LOID", "ISNUTRIENT = 'Y'", "NAME", "ทั้งหมด", "0", false);
        ControlUtil.SetYearTextbox(this.txtMYearFrom);
        ControlUtil.SetYearTextbox(this.txtMYearFrom);
        ControlUtil.SetYearTextbox(this.txtYearFrom);
        ControlUtil.SetYearTextbox(this.txtYearTo);
        lbStatusMain.Text = "";
        lbStatusMain.EnableViewState = false;
        SetScript();
        SetCombo();
    }

    private void SetCombo()
    {
        string division = Appz.LoggedOnUser.DIVISION.ToString();
        cmbDivision.SelectedIndex = cmbDivision.Items.IndexOf(cmbDivision.Items.FindByValue(division));
        cmbDivision.Enabled = false;

        division = cmbDivision.SelectedItem.Value;
        Appz.BuildCombo(cmbReqDivision, "DIVISION", "NAME", "LOID", "ISWELFARE = 'Y'", "NAME", "ทั้งหมด", "0", false);
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

                string script = OpenReportScript(Constant.Reports.WelfareRightQtyDayReport, "paramfield1=division&paramvalue1=" + cmbDivision.SelectedItem.Value +
               "&paramfield2=reqdivision&paramvalue2=" + cmbReqDivision.SelectedItem.Value +
               "&paramfield3=datefrom&paramvalue3=" + strFrom +
               "&paramfield4=dateto&paramvalue4=" + strTo +
               "&paramfield5=datefromthai&paramvalue5=" + strFromTh +
               "&paramfield6=datetothai&paramvalue6=" + strToTh, false);

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

                string script = OpenReportScript(Constant.Reports.WelfareRightQtyMonthReport, "paramfield1=division&paramvalue1=" + cmbDivision.SelectedItem.Value +
               "&paramfield2=reqdivision&paramvalue2=" + cmbReqDivision.SelectedItem.Value +
               "&paramfield3=monthyearfrom&paramvalue3=" + monthyearfrom +
               "&paramfield4=monthyearto&paramvalue4=" + monthyearto +
               "&paramfield5=myfrom&paramvalue5=" + Server.UrlEncode(myfrom) +
               "&paramfield6=myto&paramvalue6=" + Server.UrlEncode(myto), false);

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
                string script = OpenReportScript(Constant.Reports.WelfareRightQtyYearReport, "paramfield1=division&paramvalue1=" + cmbDivision.SelectedItem.Value +
               "&paramfield2=reqdivision&paramvalue2=" + cmbReqDivision.SelectedItem.Value +
               "&paramfield3=yearfrom&paramvalue3=" + (txtYearFrom.Text.Trim() == "" ? "0" : txtYearFrom.Text.Trim()) +
               "&paramfield4=yearto&paramvalue4=" + (txtYearTo.Text.Trim() == "" ? "0" : txtYearTo.Text.Trim()), false);
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
