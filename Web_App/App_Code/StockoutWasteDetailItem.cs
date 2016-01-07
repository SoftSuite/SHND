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

/// <summary>
/// Summary description for StockoutWasteDetailItem
/// </summary>
public class StockoutWasteDetailItem
{
    private string sessionStockoutWaste = "StockoutWaste";

    public StockoutWasteDetailItem()
    {
        //
        // TODO: Add constructor logic here
        //
    }

    public void ClearAllSession()
    {
        ClearStockoutWaste();
    }

    public void ClearStockoutWaste()
    {
        System.Web.HttpContext.Current.Session[sessionStockoutWaste] = null;
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

    public ArrayList GetStockoutWasteData()
    {
        ArrayList arrData = new ArrayList();
        DataTable dt = (DataTable)System.Web.HttpContext.Current.Session[sessionStockoutWaste];
        if (dt != null)
        {
            for (int i = 0; i < dt.Rows.Count; ++i)
            {
                VMaterialMasterData MaterialMaster = new VMaterialMasterData();

                MaterialMaster.MATERIALCODE = dt.Rows[i]["MATERIALCODE"].ToString();
                MaterialMaster.MATERIALNAME = dt.Rows[i]["MATERIALNAME"].ToString();
                MaterialMaster.UNITNAME = dt.Rows[i]["UNITNAME"].ToString();

                arrData.Add(MaterialMaster);
            }
        }
        return arrData;
    }

    public string GetStockoutWasteList()
    {
        string StockoutWaste = "";
        DataTable dt = (DataTable)System.Web.HttpContext.Current.Session[sessionStockoutWaste];
        if (dt != null)
        {
            for (int i = 0; i < dt.Rows.Count; ++i)
            {
                StockoutWaste += (StockoutWaste == "" ? "" : ",") + dt.Rows[i]["LOID"].ToString();
            }
        }
        return StockoutWaste;
    }

    [System.ComponentModel.DataObjectMethodAttribute(System.ComponentModel.DataObjectMethodType.Select, true)]
    public DataTable GetStockoutWasteItemList(double StockoutWasteID)
    {
        if (System.Web.HttpContext.Current.Session[sessionStockoutWaste] == null)
        {
            StockWasteFlow StockWaste = new StockWasteFlow();
            System.Web.HttpContext.Current.Session[sessionStockoutWaste] = StockWaste.GetStockWasteList(StockoutWasteID);
        }
        return (DataTable)System.Web.HttpContext.Current.Session[sessionStockoutWaste];
    }

    public bool InsertStockoutWasteItem(double StockoutWasteID, ArrayList arrData)
    {
        bool ret = true;
        try
        {
            DataTable dt = GetStockoutWasteItemList(StockoutWasteID);
            for (int i = 0; i < arrData.Count; ++i)
            {
                VMaterialMasterData VMaterialMaster = (VMaterialMasterData)arrData[i];
                if (dt.Select("MATERIALMASTER = " + VMaterialMaster.LOID.ToString()).Length == 0)
                {
                    DataRow dRow = dt.NewRow();

                    dRow["LOID"] = dt.Rows.Count + 1;
                    dRow["SAPCODE"] = VMaterialMaster.SAPCODE;
                    dRow["MATERIALNAME"] = VMaterialMaster.MATERIALNAME;
                    dRow["UNITNAME"] = VMaterialMaster.THNAME;
                    dRow["UNIT"] = VMaterialMaster.ULOID;
                    dRow["MATERIALMASTER"] = VMaterialMaster.LOID;
                    dt.Rows.Add(dRow);
                }
            }
            System.Web.HttpContext.Current.Session[sessionStockoutWaste] = dt;
        }
        catch (Exception ex)
        {
            ex.ToString();
            ret = false;
        }
        return ret;
    }

    public bool UpdateStockInOtherItem(double StockOutID, ArrayList arrData)
    {
        bool ret = true;
        try
        {
            DataTable dt = GetStockoutWasteItemList(StockOutID);
            for (int i = 0; i < arrData.Count; ++i)
            {
                StockoutitemData item = (StockoutitemData)arrData[i];
                DataRow[] dRows = dt.Select("MATERIALMASTER = " + item.MATERIALMASTER.ToString());
                if (dRows.Length == 1)
                {
                    dRows[0]["QTY"] = item.QTY;
                    dRows[0]["LOTNO"] = item.LOTNO;
                    dRows[0]["REMARKS"] = item.REMARKS;
                }
            }
            System.Web.HttpContext.Current.Session[sessionStockoutWaste] = dt;
        }
        catch (Exception ex)
        {
            ex.ToString();
            ret = false;
        }
        return ret;
    }

    public bool DeleteStockoutWasteItem(ArrayList arrLOID)
    {
        bool ret = true;
        try
        {
            DataTable dt = (DataTable)System.Web.HttpContext.Current.Session[sessionStockoutWaste];
            for (int i = 0; i < arrLOID.Count; ++i)
            {
                DataRow[] dRow = dt.Select("LOID = " + arrLOID[i].ToString());
                if (dRow.Length == 1)
                {
                    dt.Rows.Remove(dRow[0]);
                }
            }
            ReOrder(dt, "LOID");
            System.Web.HttpContext.Current.Session[sessionStockoutWaste] = dt;
        }
        catch (Exception ex)
        {
            ex.ToString();
            ret = false;
        }
        return ret;
    }
}
