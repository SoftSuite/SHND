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
using SHND.Data.Views;

public partial class App_Prepare_Transaction_ChangeOrder_ChangOrderNewCtl : System.Web.UI.UserControl
{
   

    protected void Page_Load(object sender, EventArgs e)
    {
        
    }

    public void GetChangeOrderNewList(string loid)
    {
        ChangeOrderFlow cFlow = new ChangeOrderFlow();
        DataTable dt = cFlow.GetOrderChangeNewCtlList((loid==""?"":"ADMITPATIENT = " + loid + ""), "");
        rptChangeOrderNew.DataSource = dt;
        rptChangeOrderNew.DataBind();
    }

    

    public void GetCheckboxAllNew(bool chk)
    {
        if (rptChangeOrderNew.Items.Count > 0)
        {
            for (int i = 0; i < rptChangeOrderNew.Items.Count; i++)
            {
                CheckBox checkbox1 = (CheckBox)rptChangeOrderNew.Items[i].FindControl("chkNew1");
                if (checkbox1 != null)
                    checkbox1.Checked = chk;

                CheckBox checkbox2 = (CheckBox)rptChangeOrderNew.Items[i].FindControl("chkNew2");
                if (checkbox2 != null)
                    checkbox2.Checked = chk;
            }
        }
    }

    public DataTable GetLoidNew
    {
        get
        {
            DataTable dt = new DataTable();
            DataColumn dcORDERMEDID = new DataColumn("ORDERMEDID");
            DataColumn dcREFMEDTABLE = new DataColumn("REFMEDTABLE");
            DataColumn dcORDERNONMEDID = new DataColumn("ORDERNONMEDID");

            dt.Columns.Add(dcORDERMEDID);
            dt.Columns.Add(dcREFMEDTABLE);
            dt.Columns.Add(dcORDERNONMEDID);

            for (int i = 0; i < rptChangeOrderNew.Items.Count; i++)
            {
                

                CheckBox checkbox1 = (CheckBox)rptChangeOrderNew.Items[i].FindControl("chkNew1");
                if (checkbox1 != null)
                {
                    if (checkbox1.Checked)
                    {
                        DataRow dr1 = dt.Rows.Add();

                        TextBox txtOrderMedID1 = (TextBox)rptChangeOrderNew.Items[i].FindControl("txtOrderMedID1");
                        TextBox txtRefMedTable1 = (TextBox)rptChangeOrderNew.Items[i].FindControl("txtRefMedTable1");
                        TextBox txtOrderNonMedID1 = (TextBox)rptChangeOrderNew.Items[i].FindControl("txtOrderNonMedID1");

                        dr1["ORDERMEDID"] = txtOrderMedID1.Text.Trim();
                        dr1["REFMEDTABLE"] = txtRefMedTable1.Text.Trim();
                        dr1["ORDERNONMEDID"] = txtOrderNonMedID1.Text.Trim();
                    }
                }

                CheckBox checkbox2 = (CheckBox)rptChangeOrderNew.Items[i].FindControl("chkNew2");
                if (checkbox2 != null)
                {
                    if (checkbox2.Checked)
                    {
                        DataRow dr2 = dt.Rows.Add();

                        TextBox txtOrderMedID2 = (TextBox)rptChangeOrderNew.Items[i].FindControl("txtOrderMedID2");
                        TextBox txtRefMedTable2 = (TextBox)rptChangeOrderNew.Items[i].FindControl("txtRefMedTable2");
                        TextBox txtOrderNonMedID2 = (TextBox)rptChangeOrderNew.Items[i].FindControl("txtOrderNonMedID2");

                        dr2["ORDERMEDID"] = txtOrderMedID2.Text.Trim();
                        dr2["REFMEDTABLE"] = txtRefMedTable2.Text.Trim();
                        dr2["ORDERNONMEDID"] = txtOrderNonMedID2.Text.Trim();
                    }
                }
            }

            return dt;
        }
    }

}
