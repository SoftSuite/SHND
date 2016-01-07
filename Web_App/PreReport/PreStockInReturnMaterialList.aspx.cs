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
/// PreStockInReturnMaterialList Class
/// Version 1.0
/// =========================================================================
/// Create by: Pom
/// Create Date: 27 May 2009
/// -------------------------------------------------------------------------
/// Modify By: -
/// Modify From: -
/// Modify Date: -
/// -------------------------------------------------------------------------
/// Remark: -
/// Description:
///    ˹�ҡ�÷���§ҹ StockInReturnMaterialList
/// Changes:
///    1.0 - ���ҧ
/// -------------------------------------------------------------------------
/// =========================================================================
/// </summary>
/// 

public partial class PreReport_PreStockInReturnMaterialList : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {

    }

    protected override void OnInit(EventArgs e)
    {
        base.OnInit(e);
        Appz.BuildCombo(cmbDivision, "DIVISION", "NAME", "LOID", "ISONLINEREQUEST='Y' AND ACTIVE='1'", "NAME", "������", "0", false);
        Appz.BuildCombo(cmbMaterialClass, "MATERIALCLASS", "NAME", "LOID", "MASTERTYPE='FO' AND ACTIVE='1'", "NAME", "������", "0", false);
    }

    protected void tbPrintClick(object sender, EventArgs e)
    {
        if (ValidateData() == true)
        {
            string datefrom = ctDateFrom.DateValue.Year.ToString() + ctDateFrom.DateValue.ToString("MMdd");
            string dateto = ctDateTo.DateValue.Year.ToString() + ctDateTo.DateValue.ToString("MMdd");
            string datefromthai = ctDateFrom.DateValue.ToString("dd/MM/") + Convert.ToString(ctDateFrom.DateValue.Year + 543);
            string datetothai = ctDateTo.DateValue.ToString("dd/MM/") + Convert.ToString(ctDateTo.DateValue.Year + 543);
            string division = cmbDivision.SelectedItem.Value;
            string materialclass = cmbMaterialClass.SelectedItem.Value;

            string script = OpenReportScript(Constant.Reports.StockInReturnMaterialList, "paramfield1=division&paramvalue1=" + division +
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
            lblStatus.Text = "��س��к��ѹ����������";
            return false;
        }
        else if (ctDateTo.DateValue.Year == 1)
        {
            lblStatus.Text = "��س��к��ѹ�������ش";
            return false;
        }

        return true;
    }
}
