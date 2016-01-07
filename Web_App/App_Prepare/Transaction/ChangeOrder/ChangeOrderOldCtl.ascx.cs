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
using SHND.Flow.Prepare;
using SHND.Global;

public partial class App_Prepare_Transaction_ChangeOrder_ChangeOrderOldCtl : System.Web.UI.UserControl
{

    protected void Page_Load(object sender, EventArgs e)
    {

    }

    public void GetChangeOrderOldList(string loid)
    {
        ChangeOrderFlow cFlow = new ChangeOrderFlow();
        DataTable dt = cFlow.GetOrderChangeOldCtlList((loid == ""?"":"ADMITPATIENT = " + loid + ""), "");
        rptChangeOrderOld.DataSource = dt;
        rptChangeOrderOld.DataBind();
    }
}
