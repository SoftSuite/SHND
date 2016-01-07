using System;
using System.Data;
using System.Configuration;
using System.Web;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Web.UI.WebControls.WebParts;
using System.Web.UI.HtmlControls;
using System.Collections;
using SHND.Data.Views;
using SHND.Data.Tables;
using SHND.Data.Common.Utilities;
using SHND.Flow.Inventory;
using SHND.Global;
using SHND.DAL.Functions;

/// <summary>
/// Summary description for StockInDetailItem
/// </summary>
public class StockInDetailItem
{
    private string sessionStockIn = "StockIn";

    public StockInDetailItem()
    {
        //
        // TODO: Add constructor logic here
        //
    }

    public void ClearAllSession()
    {
        ClearStockInWaste();
    }

    public void ClearStockInWaste()
    {
        System.Web.HttpContext.Current.Session[sessionStockIn] = null;
    }

    public void ClearData()
    {
        DataTable dt = (DataTable)System.Web.HttpContext.Current.Session[sessionStockIn];
        if (dt != null)
        {
            dt.Rows.Clear();
        }
    }

    private void ReOrder(DataTable dt, string filedName)
    {
        int i = 1;
        foreach (DataRow dRow in dt.Rows)
        {
            dRow[filedName] = i;
            i += 1;
        }
    }

    public string GetMaeralMasterList()
    {
        string materialList = "";
        DataTable dt = (DataTable)System.Web.HttpContext.Current.Session[sessionStockIn];
        if (dt != null)
        {
            for (int i=0; i<dt.Rows.Count; ++i)
            {
                materialList += (materialList == "" ? "" : ",") + "'" + dt.Rows[i]["MATERIALMASTER"].ToString() + "#" + dt.Rows[i]["UNIT"].ToString() + "'";
            }
        }
        return materialList;
    }

    public ArrayList GetStockInData()
    {
        ArrayList arrData = new ArrayList();
        DataTable dt = (DataTable)System.Web.HttpContext.Current.Session[sessionStockIn];
        if (dt != null)
        {
            for (int i = 0; i < dt.Rows.Count; ++i)
            {
                VStockinToolsPopupData VStockinToolsPopup = new VStockinToolsPopupData();

                VStockinToolsPopup.MATERIALCODE = dt.Rows[i]["MATERIALCODE"].ToString();
                VStockinToolsPopup.MATERIALNAME = dt.Rows[i]["MATERIALNAME"].ToString();
                VStockinToolsPopup.UNITNAME = dt.Rows[i]["UNITNAME"].ToString();


                arrData.Add(VStockinToolsPopup);
            }
        }
        return arrData;
    }

    public string GetStockInList()
    {
        string StockIn = "";
        DataTable dt = (DataTable)System.Web.HttpContext.Current.Session[sessionStockIn];
        if (dt != null)
        {
            for (int i = 0; i < dt.Rows.Count; ++i)
            {
                StockIn += (StockIn == "" ? "" : ",") + dt.Rows[i]["LOID"].ToString();
            }
        }
        return StockIn;
    }

    [System.ComponentModel.DataObjectMethodAttribute(System.ComponentModel.DataObjectMethodType.Select, true)]
    public DataTable GetStockInItemList(double StockInID)
    {
        if (System.Web.HttpContext.Current.Session[sessionStockIn] == null)
        {
            StockInFlow StockIn = new StockInFlow();
            System.Web.HttpContext.Current.Session[sessionStockIn] = StockIn.GetStockInList(StockInID);
        }
        return (DataTable)System.Web.HttpContext.Current.Session[sessionStockIn];
    }

    

    public bool InsertStockInItem(double PlanOrderID ,double StockInID, ArrayList arrData)
    {
        bool ret = true;
        try
        {
            DataTable dt = GetStockInItemList(StockInID);
            for (int i = 0; i < arrData.Count; ++i)
            {
                VStockinToolsPopupData VStockinToolsPopup = (VStockinToolsPopupData)arrData[i];
                if (dt.Select("MATERIALMASTER = " + VStockinToolsPopup.LOID.ToString()).Length == 0)
                {
                    DataRow dRow = dt.NewRow();
                    FunctionDAL CalQTY = new FunctionDAL();
                    dRow["LOID"] = dt.Rows.Count + 1;
                    dRow["MATERIALCODE"] = VStockinToolsPopup.MATERIALCODE;
                    dRow["MATERIALNAME"] = VStockinToolsPopup.MATERIALNAME;
                    dRow["UNITNAME"] = VStockinToolsPopup.UNITNAME;
                    dRow["UNIT"] = VStockinToolsPopup.UNIT;
                    dRow["MATERIALMASTER"] = VStockinToolsPopup.MATERIALMASTER;
                    dRow["PRICE"] = VStockinToolsPopup.PRICE;
                    dRow["REMAINQTY"] = CalQTY.CalplantoolsQTY(PlanOrderID, VStockinToolsPopup.MATERIALMASTER, 0, null)-CalQTY.CalPlanToolsStockin(PlanOrderID,VStockinToolsPopup.MATERIALMASTER,VStockinToolsPopup.UNIT,null);
                    dRow["PLANQTY"] = CalQTY.CalplantoolsQTY(PlanOrderID, VStockinToolsPopup.MATERIALMASTER, 0, null);

                    
                    dt.Rows.Add(dRow);
                }
            }
            System.Web.HttpContext.Current.Session[sessionStockIn] = dt;
        }
        catch (Exception ex)
        {
            ex.ToString();
            ret = false;
        }
        return ret;
    }

    public bool InsertStockInFoodItem(double PlanOrderID, double StockInID, ArrayList arrData)
    {
        bool ret = true;
        try
        {
            DataTable dt = GetStockInItemList(StockInID);
            for (int i = 0; i < arrData.Count; ++i)
            {
                VStockinFoodPopupData VStockinFoodPopup = (VStockinFoodPopupData)arrData[i];
                if (dt.Select("MATERIALMASTER = " + VStockinFoodPopup.LOID.ToString()).Length == 0)
                {
                    DataRow dRow = dt.NewRow();
                    FunctionDAL CalQTY = new FunctionDAL();
                    dRow["LOID"] = dt.Rows.Count + 1;
                    dRow["MATERIALCODE"] = VStockinFoodPopup.MATERIALCODE;
                    dRow["MATERIALNAME"] = VStockinFoodPopup.MATERIALNAME;
                    dRow["UNITNAME"] = VStockinFoodPopup.UNITNAME;
                    dRow["UNIT"] = VStockinFoodPopup.UNIT;
                    dRow["MATERIALMASTER"] = VStockinFoodPopup.MATERIALMASTER;
                    dRow["PRICE"] = VStockinFoodPopup.PRICE;
                    dRow["REMAINQTY"] = "0";
                    dRow["PLANQTY"] = CalQTY.CalPlanFoodQTY(PlanOrderID, VStockinFoodPopup.MATERIALMASTER, null);
                    dRow["SAPPOCODE"] = VStockinFoodPopup.SAPPOCODE;
                    dRow["SAPPODATE"] = VStockinFoodPopup.SAPPODATE;

                    dt.Rows.Add(dRow);
                }
            }
            System.Web.HttpContext.Current.Session[sessionStockIn] = dt;
        }
        catch (Exception ex)
        {
            ex.ToString();
            ret = false;
        }
        return ret;
    }

    public bool UpdateStockInItem(double StockInID, ArrayList arrData)
    {
        bool ret = true;
        try
        {
            DataTable dt = GetStockInItemList(StockInID);
            for (int i = 0; i < arrData.Count; ++i)
            {
                StockinItemData item = (StockinItemData)arrData[i];
                DataRow[] dRows = dt.Select("MATERIALMASTER = " + item.MATERIALMASTER.ToString());
                if (dRows.Length == 1)
                {
                    dRows[0]["QTY"] = item.QTY;
                    dRows[0]["LOTNO"] = item.LOTNO;
                    dRows[0]["GUARANTEE"] = item.GUARANTEE;
                    dRows[0]["SAPPODATE"] = item.SAPPODATE;
                    dRows[0]["SAPPOCODE"] = item.SAPPOCODE;
                }
            }
            System.Web.HttpContext.Current.Session[sessionStockIn] = dt;
        }
        catch (Exception ex)
        {
            ex.ToString();
            ret = false;
        }
        return ret;
    }
    public bool DeleteStockInItem(ArrayList arrLOID)
    {
        bool ret = true;
        try
        {
            DataTable dt = (DataTable)System.Web.HttpContext.Current.Session[sessionStockIn];
            for (int i = 0; i < arrLOID.Count; ++i)
            {
                DataRow[] dRow = dt.Select("LOID = " + arrLOID[i].ToString());
                if (dRow.Length == 1)
                {
                    dt.Rows.Remove(dRow[0]);
                }
            }
            ReOrder(dt, "LOID");
            System.Web.HttpContext.Current.Session[sessionStockIn] = dt;
        }
        catch (Exception ex)
        {
            ex.ToString();
            ret = false;
        }
        return ret;
    }

   


}
