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
using SHND.Flow.Common;
using SHND.Global;

public partial class SHNDMain : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            try
            {
                LoggedOnUserData uData = Appz.LoggedOnUser;
                lblUserID.Text = uData.USERNAME;
                lblName.Text = uData.FULLNAME;
                lblDivision.Text = uData.DIVISIONNAME;
                lblLastLogin.Text = uData.LASTLOGON.ToString("d MMM yyyy [HH:mm]");

                lblLevel.Text = UserFlow.GetRoleName(uData.UserRole);
            }
            catch (InvalidCastException ex)
            {
                ex.ToString();
                FormsAuthentication.SignOut();
                FormsAuthentication.RedirectToLoginPage();
            }
        }
    }
}
