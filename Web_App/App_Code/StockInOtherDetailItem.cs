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
using SHND.Data.Tables;
using SHND.Data.Views;
using SHND.Data.Common.Utilities;
using SHND.Flow.Inventory;
using SHND.Global;
using SHND.DAL.Functions;

/// <summary>
/// Summary description for StockInOtherDetailItem
/// </summary>
public class StockInOtherDetailItem
{
    private string sessionStockInotherItem = "StockInOther";

    public StockInOtherDetailItem()
    {
        //
        // TODO: Add constructor logic here
        //
    }

    public void ClearAllSession()
    {
        ClearStockInotherWaste();
    }

    public void ClearStockInotherWaste()
    {
        System.Web.HttpContext.Current.Session[sessionStockInotherItem] = null;
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

    public ArrayList GetStockInOtherData()
    {
        ArrayList arrData = new ArrayList();
        DataTable dt = (DataTable)System.Web.HttpContext.Current.Session[sessionStockInotherItem];
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

    public string GetMaterialMasterList()
    {
        string materialList = "";
        DataTable dt = (DataTable)System.Web.HttpContext.Current.Session[sessionStockInotherItem]; if (dt != null)
        {
            for (int i = 0; i < dt.Rows.Count; ++i)
            {
                materialList += (materialList == "" ? "" : ",") + dt.Rows[i]["MATERIALMASTER"].ToString();
            }
        }
        return materialList;
    }

    //public string GetStockInOtherList()
    //{
    //    string StockInOther = "";
    //    DataTable dt = (DataTable)System.Web.HttpContext.Current.Session[sessionStockInotherItem];
    //    if (dt != null)
    //    {
    //        for (int i = 0; i < dt.Rows.Count; ++i)
    //        {
    //            StockInOther += (StockInOther == "" ? "" : ",") + dt.Rows[i]["LOID"].ToString();
    //        }
    //    }
    //    return StockInOther;
    //}


    [System.ComponentModel.DataObjectMethodAttribute(System.ComponentModel.DataObjectMethodType.Select, true)]
    public DataTable GetStockInOtherItemList(double StockInID)
    {
        if (System.Web.HttpContext.Current.Session[sessionStockInotherItem] == null)
        {
            StockInOtherFlow StockInOther = new StockInOtherFlow();
            System.Web.HttpContext.Current.Session[sessionStockInotherItem] = StockInOther.GetStockInOtherList(StockInID); 
        }
        return (DataTable)System.Web.HttpContext.Current.Session[sessionStockInotherItem];
    }

    public bool InsertStockInOtherItem(double StockInID, ArrayList arrData)
    {
        bool ret = true;
        try
        {
            DataTable dt = GetStockInOtherItemList(StockInID);
            for (int i = 0; i < arrData.Count; ++i)
            {

                VMaterialMasterUnitData VMaterialMasterUnit = (VMaterialMasterUnitData)arrData[i];
                if (dt.Select("MATERIALMASTER = " + VMaterialMasterUnit.LOID.ToString()).Length == 0)
                {
                    DataRow dRow = dt.NewRow();
                    dRow["LOID"] = dt.Rows.Count + 1;
                    dRow["MATERIALCODE"] = VMaterialMasterUnit.MATERIALCODE;
                    dRow["MATERIALNAME"] = VMaterialMasterUnit.MATERIALNAME;
                    dRow["UNITNAME"] = VMaterialMasterUnit.UNITNAME;
                    dRow["UNIT"] = VMaterialMasterUnit.UNIT;
                    dRow["MATERIALMASTER"] = VMaterialMasterUnit.MATERIALMASTER;
                    dRow["PRICE"] = VMaterialMasterUnit.PRICE;

                    dt.Rows.Add(dRow);
                }
            }
            System.Web.HttpContext.Current.Session[sessionStockInotherItem] = dt;
        }
        catch (Exception ex)
        {
            ex.ToString();
            ret = false;
        }
        return ret;
    }
    public bool UpdateStockInOtherItem(double StockInID, ArrayList arrData)
    {
        bool ret = true;
        try
        {
            DataTable dt = GetStockInOtherItemList(StockInID);
            for (int i = 0; i < arrData.Count; ++i)
            {
                StockinItemData item = (StockinItemData)arrData[i];
                DataRow[] dRows = dt.Select("MATERIALMASTER = " + item.MATERIALMASTER.ToString());
                if (dRows.Length == 1)
                {
                    dRows[0]["QTY"] = item.QTY;
                    dRows[0]["LOTNO"] = item.LOTNO;
                    dRows[0]["GUARANTEE"] = item.GUARANTEE;
                    dRows[0]["BRAND"] = item.BRAND;
                }
            }
            System.Web.HttpContext.Current.Session[sessionStockInotherItem] = dt;
        }
        catch (Exception ex)
        {
            ex.ToString();
            ret = false;
        }
        return ret;
    }

    public bool DeleteStockInOtherItem(ArrayList arrLOID)
    {
        bool ret = true;
        try
        {
            DataTable dt = (DataTable)System.Web.HttpContext.Current.Session[sessionStockInotherItem];
            for (int i = 0; i < arrLOID.Count; ++i)
            {
                DataRow[] dRow = dt.Select("LOID = " + arrLOID[i].ToString());
                if (dRow.Length == 1)
                {
                    dt.Rows.Remove(dRow[0]);
                }
            }
            ReOrder(dt, "LOID");
            System.Web.HttpContext.Current.Session[sessionStockInotherItem] = dt;
        }
        catch (Exception ex)
        {
            ex.ToString();
            ret = false;
        }
        return ret;
    }


}
