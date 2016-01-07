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

public partial class App_Prepare_Transaction_ChangeOrder_ChangeorderCtl : System.Web.UI.UserControl
{
   
    protected void Page_Load(object sender, EventArgs e)
    {
            
    }

    public string GetChangOrderCtl
    {
        set
        {
            string loid = value;
            ChangeOrderOldCtl.GetChangeOrderOldList(loid);
            ChangOrderNewCtl.GetChangeOrderNewList(loid);
        }
    }

    public bool GetCheckAllChangOrderCtl
    {
        set
        {
            bool chk = value;
            ChangOrderNewCtl.GetCheckboxAllNew(chk);
        }
    }

    public DataTable GetLoidNewList
    {
        get
        {
            DataTable dt = new DataTable();
            dt = ChangOrderNewCtl.GetLoidNew;
            return dt;
        }
       
    }
}
