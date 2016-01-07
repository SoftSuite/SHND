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


public partial class App_Prepare_Control_OrderPatientSetCtl : System.Web.UI.UserControl
{
    protected void Page_Load(object sender, EventArgs e)
    {
       
    }

    private static string tmp = "";

    public static string StrWhr
    {
        set { tmp = value; }
    }

    public string GetOrderPatientSet
    {
        set
        {
            string loid = value;
            OrderPatientSetFlow oFlow = new OrderPatientSetFlow();
            string str = " ADMITPATIENT IN (" + loid + ") " + (tmp == "" ? "" : " AND " + tmp) + "";
            DataTable dt = oFlow.GetOrderPatientListCtl(str, "");
            rptOrderPatientSet.DataSource = dt;
            rptOrderPatientSet.DataBind();

        }
    }

   
}
