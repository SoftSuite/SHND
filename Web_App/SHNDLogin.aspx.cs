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
using System.Xml.Serialization;
using System.IO;
using System.Text;
using SHND.Flow.Common;
using SHND.Data.Common;
using SHND.Data.Common.Utilities;

/// SHNDLogin Class
/// Version 1.0
/// =========================================================================
/// Create by: TurBoZ
/// Create Date: 10 May 2009
/// -------------------------------------------------------------------------
/// Modify By: -
/// Modify From: -
/// Modify Date: -
/// -------------------------------------------------------------------------
/// Remark: -
/// Description:
///    Behide Code สำหรับหน้า Login
/// Changes:
///    1.0 - สร้าง
/// -------------------------------------------------------------------------
/// =========================================================================
/// </summary>
/// 
public partial class SHNDLogin : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {

    }
 
    private void ShowError(string error)
    {
        lblError.Text = error;
        tbError.Visible = true;
        zPop.Show();
    }
    protected void btnClose_Click(object sender, EventArgs e)
    {
        zPop.Hide();
    }
    protected void Login1_LoginError(object sender, EventArgs e)
    {

    }
    protected void Login1_LoggingIn(object sender, LoginCancelEventArgs e)
    {
        
    }
    string SerialUserData = "";

    protected void Login1_Authenticate(object sender, AuthenticateEventArgs e)
    {
        UserFlow uFlow = new UserFlow();
        e.Authenticated = uFlow.Login(Login1.UserName, Login1.Password);
        if (!e.Authenticated)
            ShowError(uFlow.ErrorMessage);
        else
        {

            SerialUserData = "";
            UserData uData = uFlow.GetUserData();

            LoggedOnUserData lData = new LoggedOnUserData();
            lData.DIVISION = uData.Division;
            lData.DIVISIONNAME = uData.DivisionName;
            //lData.FIRSTNAME = uData.FName;
            //lData.LASTNAME = uData.LName;
            lData.FULLNAME = uData.Name;
            lData.LOID = uData.UID;
            lData.USERNAME = uData.UserID;
            lData.OFFICERGROUP = uData.OfficerGroup;
            lData.LASTLOGON = uData.LastLogon;
            //lData.TITLENAME = uData.TitleName;
            lData.ForcePWChange = uData.ForcePWChange;
            //lData.Active = uData.Active;
            lData.UserRole = uData.Role;

            XmlSerializer sr = new XmlSerializer(typeof(LoggedOnUserData));
            MemoryStream st = new MemoryStream();
            sr.Serialize(st, lData);

            byte[] b = st.GetBuffer();

            SerialUserData = Convert.ToBase64String(b);

        }
    }

    protected void Login1_LoggedIn(object sender, EventArgs e)
    {
        HttpContext.Current.Response.Cookies.Clear();

        FormsAuthenticationTicket fat = new FormsAuthenticationTicket(1, Login1.UserName, DateTime.Now, DateTime.Now.AddDays(1), true, SerialUserData);
        HttpCookie ck = new HttpCookie(".SHNDSingleSignOn");
        ck.Value = FormsAuthentication.Encrypt(fat);
        ck.Expires = fat.Expiration;
        HttpContext.Current.Response.Cookies.Add(ck);


        if (Request["ReturnUrl"] == null || Request["ReturnUrl"] == "")
            Response.Redirect("SHNDMain.aspx");
        else
            Response.Redirect(Request["ReturnUrl"]);

    }
}
