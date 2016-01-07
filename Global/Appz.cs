using System;
using System.Collections.Generic;
using System.Text;
using SHND.Data.Common.Utilities;
using SHND.Data.Common;
using SHND.Flow.Common;
using System.Xml.Serialization;
using System.IO;
using System.Web.Security;
using System.Web;

/// <summary>
/// Appz Class
/// Version 1.0
/// =========================================================================
/// Create by: TurBoZ
/// Create Date: 25 Dec 2008
/// -------------------------------------------------------------------------
/// Modify By: -
/// Modify From: -
/// Modify Date: -
/// -------------------------------------------------------------------------
/// Remark: -
/// Description:
///    ฟังก์ชันการทำงานส่วนกลาง 
/// Changes:
///    1.0 - สร้าง
/// -------------------------------------------------------------------------
/// =========================================================================
/// </summary>
/// 

namespace SHND.Global
{
    public class Appz
    {
        public static string CurrentUser
        {
            get { return HttpContext.Current.User.Identity.Name; }
        }


        public static bool NeedChangePassword
        {
            get
            {
                LoggedOnUserData uData = Appz.LoggedOnUser;
                return uData.ForcePWChange;
            }
        }

        public static LoggedOnUserData LoggedOnUser
        {
            get
            {
                LoggedOnUserData ret = new LoggedOnUserData();
                try
                {
                    FormsIdentity id = (FormsIdentity)HttpContext.Current.User.Identity;
                    FormsAuthenticationTicket tik = id.Ticket;

                    XmlSerializer sr = new XmlSerializer(typeof(LoggedOnUserData));
                    MemoryStream st = new MemoryStream(Convert.FromBase64String(tik.UserData));

                    ret = (LoggedOnUserData)sr.Deserialize(st);
                }
                catch { }
                return ret;
            }
        }

        public static string CurrentIP
        {
            get { return System.Web.HttpContext.Current.Request.UserHostAddress; }
        }

        public static void BuildCombo(System.Web.UI.WebControls.DropDownList comboBox, string TableName, string DisplayField, string ValueField, string WhereString, string OrderString, string BlankText, string BlankValue, bool doDistinct)
        {
            CommboSourceFlow cFlow = new CommboSourceFlow();
            comboBox.DataSource = cFlow.GetComboSource(TableName, DisplayField,ValueField, WhereString, OrderString, doDistinct);
            comboBox.DataTextField = "NAME";
            comboBox.DataValueField = "VALUE";
            comboBox.DataBind();
            if (BlankText != null && BlankValue != null)
            {
                comboBox.Items.Insert(0, new System.Web.UI.WebControls.ListItem(BlankText, BlankValue));
            }
        }

        public static string OpenReportScript(string reportName, string parameterString, bool isLandscape)
        {
            return "window.open('" + Constant.ReportWebUrl + "Default.aspx?landscape=" + (isLandscape ? "1" : "0") + "&" + Constant.QueryString.ReportName + "=" + reportName + (parameterString == "" ? "" : "&") + parameterString + "', 'zReport', 'status=yes, toolbar=no, scrollbars=yes, menubar=no, width=800, height=600, resizable=yes'); return false;";
        }

        public static string OpenReportScript(string reportName, double loid, bool isLandscape)
        {
            return OpenReportScript(reportName, "paramfield1=LOID&paramvalue1=" + loid.ToString(), isLandscape);
        }

        public static string GetConfigValue(double ID)
        {
            return AppFLow.GetConfigValue(ID);
        }

    }
}
