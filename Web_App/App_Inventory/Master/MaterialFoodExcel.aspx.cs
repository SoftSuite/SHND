using System;
using System.Data;
using System.Configuration;
using System.Collections;
using System.IO;
using System.Web;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Web.UI.WebControls.WebParts;
using System.Web.UI.HtmlControls;
using SHND.Flow.Inventory;

public partial class App_Inventory_Master_MaterialFoodExcel : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        string name = "";
        GridView gvTmp = new GridView();
        gvTmp.AutoGenerateColumns = true;
        switch (Request["type"])
        {
            case "FEED":
                name = "MaterialFeed";
                MaterialFeedFlow fdFlow = new MaterialFeedFlow();
                gvTmp.DataSource = fdFlow.GetDataListForExcel("0" + Request["materialgroup"], Request["materialname"], "'MD','MI','DO'", "MATERIALCODE");
                break;
            case "FOOD":
                name = "MaterialFood";
                MaterialFoodSearchFlow fFlow = new MaterialFoodSearchFlow();
                gvTmp.DataSource = fFlow.GetDataListForExcel("0" + Request["materialclass"], "0" + Request["materialgroup"], Request["materialname"], "'FO'", "MATERIALCODE");
                break;
            case "TOOLS":
                name = "MaterialTool";
                MaterialToolFlow ftFlow = new MaterialToolFlow();
                gvTmp.DataSource = ftFlow.GetDataListForExcel("0" + Request["materialgroup"], Request["materialname"], "'TL','OT'", "MATERIALCODE");
                break;
        }
        gvTmp.DataBind();
        gvTmp.ShowHeader = true;

        Response.Clear();
        Response.Charset = "TIS620";

        Response.ContentType = "Application/x-msexcel";
        //add the response headers
        Response.AddHeader("content-disposition", "attachment; filename=\"" + name + "_" + DateTime.Now.ToString("dd_MM_") + (DateTime.Now.Year+543).ToString("0000") + ".xls\"");

        StringWriter stW = new StringWriter();
        HtmlTextWriter htW = new HtmlTextWriter(stW);
        gvTmp.RenderControl(htW);
        Response.Write(stW.ToString());

        Response.End();
        Response.Clear();
    }
}
