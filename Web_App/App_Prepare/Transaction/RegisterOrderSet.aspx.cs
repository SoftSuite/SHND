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

public partial class App_Prepare_Transaction_RegisterOrderSet : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {

    }

    protected void tabRegister_ActiveTabChanged(object sender, EventArgs e)
    {
        this.tabRegister.ActiveTabIndex = this.tabRegister.ActiveTabIndex;
    }

}
