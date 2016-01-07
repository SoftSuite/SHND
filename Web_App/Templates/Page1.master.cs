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
using SHND.Data;
using SHND.Data.Common.Utilities;

/// SHNDLogin Class
/// Version 1.0
/// =========================================================================
/// Create by: TurBoZ
/// Create Date: 23 Dec 2008
/// -------------------------------------------------------------------------
/// Modify By: -
/// Modify From: -
/// Modify Date: -
/// -------------------------------------------------------------------------
/// Remark: -
/// Description:
///    Behide Code สำหรับหน้า  Page1 Master
/// Changes:
///    1.0 - สร้าง
/// -------------------------------------------------------------------------
/// =========================================================================
/// </summary>
/// 
public partial class Template_Page1 : System.Web.UI.MasterPage
{
    protected override void OnInit(EventArgs e)
    {
        base.OnInit(e);
        this.lblVersion.Text = "v." + VersionControl.VersionNumber;
        if (!IsPostBack)
        {
            try
            {
                if (Page.User.Identity.Name == "") FormsAuthentication.RedirectToLoginPage();
                else
                {
                    LoggedOnUserData uData = Appz.LoggedOnUser;
                    if (uData.ForcePWChange && !Request.Url.AbsolutePath.EndsWith("SHNDChangePassword.aspx"))
                    {
                        Response.Redirect(Request.ApplicationPath + "/SHNDChangePassword.aspx?force=yes&ReturnUrl=" + System.Web.HttpUtility.UrlEncode(Request.Url.PathAndQuery));
                    }
                    else
                        lblUser.Text = uData.FULLNAME + " [" + Page.User.Identity.Name + "]";
                }
            }
            catch (InvalidCastException ex)
            {
                ex.ToString();
                FormsAuthentication.SignOut();
                FormsAuthentication.RedirectToLoginPage();
            }
        }
    }

    protected void Page_Load(object sender, EventArgs e)
    {
        
    }

    protected void smApplication_AsyncPostBackError(object sender, AsyncPostBackErrorEventArgs e)
    {
        if (e.Exception != null && e.Exception.InnerException != null)
        {
            this.smApplication.AsyncPostBackErrorMessage = e.Exception.InnerException.Message + "\r\n" + e.Exception.InnerException.StackTrace;
        }
    }

}
