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
/// PreSrockinMaterialList Class
/// Version 1.0
/// =========================================================================
/// Create by: Pom
/// Create Date: 25 May 2009
/// -------------------------------------------------------------------------
/// Modify By: -
/// Modify From: -
/// Modify Date: -
/// -------------------------------------------------------------------------
/// Remark: -
/// Description:
///    หน้าการทำรายงาน PreSrockinMaterialList
/// Changes:
///    1.0 - สร้าง
/// -------------------------------------------------------------------------
/// =========================================================================
/// </summary>
/// 

public partial class PreReport_PreStockinMaterialList : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {

    }

    protected override void OnInit(EventArgs e)
    {
        base.OnInit(e);
        Appz.BuildCombo(cmbStockinType, "DOCTYPE", "DOCNAME", "LOID", "TYPE='I' AND ISSTOCKIN='Y'", "DOCNAME", "ทั้งหมด", "0", false);
        Appz.BuildCombo(cmbMaterialClass, "MATERIALCLASS", "NAME", "LOID", "MASTERTYPE='FO' AND ACTIVE='1'", "NAME", "ทั้งหมด", "0", false);
    }

    protected void tbPrintClick(object sender, EventArgs e)
    {
        if (ValidateData() == true)
        {
            string datefrom = ctDateFrom.DateValue.Year.ToString() + ctDateFrom.DateValue.ToString("MMdd");
            string dateto = ctDateTo.DateValue.Year.ToString() + ctDateTo.DateValue.ToString("MMdd");
            string datefromthai = ctDateFrom.DateValue.ToString("dd/MM/") + Convert.ToString(ctDateFrom.DateValue.Year + 543);
            string datetothai = ctDateTo.DateValue.ToString("dd/MM/") + Convert.ToString(ctDateTo.DateValue.Year + 543);
            string doctype = cmbStockinType.SelectedItem.Value;
            string materialclass = cmbMaterialClass.SelectedItem.Value;

            string script = OpenReportScript(Constant.Reports.StockInMaterialList, "paramfield1=doctype&paramvalue1=" + doctype +
           "&paramfield2=materialclass&paramvalue2=" + materialclass +
           "&paramfield3=datefrom&paramvalue3=" + datefrom +
           "&paramfield4=dateto&paramvalue4=" + dateto +
           "&paramfield5=datefromthai&paramvalue5=" + datefromthai +
           "&paramfield6=datetothai&paramvalue6=" + datetothai, false);

            ScriptManager.RegisterStartupScript(Page, GetType(), "report", "<script language='javascript'>" + script + "</script>", false);
            lblStatus.Text = "";
        }
    }

    private string OpenReportScript(string reportName, string parameterString, bool isLandscape)
    {
        return "window.open('" + Constant.ReportWebUrl + "Default.aspx?landscape=" + (isLandscape ? "1" : "0") + "&" + Constant.QueryString.ReportName + "=" + reportName + (parameterString == "" ? "" : "&") + parameterString + "', 'zReport', 'status=yes, toolbar=no, scrollbars=yes, menubar=no, width=800, height=600, resizable=yes');";
    }

    private bool ValidateData()
    {
        if (ctDateFrom.DateValue.Year == 1)
        {
            lblStatus.Text = string.Format(DataResources.MSGEI002, "วันที่เริ่มต้น");
            return false;
        }
        else if (ctDateTo.DateValue.Year == 1)
        {
            lblStatus.Text = string.Format(DataResources.MSGEI002, "วันที่สิ้นสุด");
            return false;
        }

        return true;
    }
}
