using System;
using System.Collections;
using System.Data;
using System.Configuration;
using System.Web;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Web.UI.WebControls.WebParts;
using System.Web.UI.HtmlControls;
using SHND.Flow.Inventory;
using SHND.Data.Common.Utilities;
using SHND.Data.Inventory;
using SHND.Data.Tables;
using SHND.Data.Views;

/// <summary>
/// Summary description for StockOutRequestDetailItem
/// </summary>
public class StockOutRequestDetailItem
{
    private string sessionStockOutRequest = "StockOutRequest";
    private string _error = "";

    public string ErrorMessage
    {
        get { return _error; }
    }

    public void ClearAllSession()
    {
        System.Web.HttpContext.Current.Session[sessionStockOutRequest] = null;
    }

    public void ClearData()
    {
        ((DataTable)System.Web.HttpContext.Current.Session[sessionStockOutRequest]).Rows.Clear();
    }

    public StockOutRequestDetailItem()
    {
        //
        // TODO: Add constructor logic here
        //
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

    [System.ComponentModel.DataObjectMethodAttribute(System.ComponentModel.DataObjectMethodType.Select, true)]
    public DataTable GetStockOutItemList(double stockOutID)
    {
        if (System.Web.HttpContext.Current.Session[sessionStockOutRequest] == null)
        {
            StockOutRequestFlow fFlow = new StockOutRequestFlow();
            System.Web.HttpContext.Current.Session[sessionStockOutRequest] = fFlow.GetStockOutItem(stockOutID);
        }
        return (DataTable)System.Web.HttpContext.Current.Session[sessionStockOutRequest];
    }

    public bool InsertStockOutItemOrder(double stockOutID, ArrayList arrData)
    {
        bool ret = true;
        try
        {
            DataTable dt = GetStockOutItemList(stockOutID);
            for (int i = 0; i < arrData.Count; ++i)
            {
                VMenuStockOutData VMaterialList = (VMenuStockOutData)arrData[i];
                if (dt.Select("MATERIALMASTER = " + VMaterialList.MATERIALMASTER.ToString() + " AND UNIT = " + VMaterialList.UNIT.ToString()).Length == 0)
                {
                    DataRow dRow = dt.NewRow();
                    dRow["RANK"] = dt.Rows.Count + 1;
                    dRow["LOID"] = 0;
                    dRow["MATERIALMASTER"] = VMaterialList.MATERIALMASTER;
                    dRow["CODE"] = VMaterialList.MATERIALCODE;
                    dRow["MATERIALNAME"] = VMaterialList.MATERIALNAME;
                    dRow["UNIT"] = VMaterialList.UNIT;
                    dRow["UNITNAME"] = VMaterialList.UNITNAME;
                    dRow["FORMULAQTY"] = VMaterialList.FORMULAQTY;
                    dRow["PREQTY"] = VMaterialList.PREQTY;
                    dRow["LASTQTY"] = VMaterialList.LASTQTY;
                    dRow["REQQTY"] = VMaterialList.PREQTY;
                    dRow["QTY"] = 0;
                    dRow["PRICE"] = VMaterialList.COST;
                    dRow["REMAIN"] = 0;
                    dRow["REQTOTAL"] = 0;
                    dRow["ISMENU"] = "Y";
                    dRow["STATUS"] = "WA";
                    dRow["STATUSSTOCKOUT"] = "WA";
                    dRow["STATUSNAME"] = "照證癒疰";
                    dt.Rows.Add(dRow);
                }
            }
            System.Web.HttpContext.Current.Session[sessionStockOutRequest] = dt;
        }
        catch (Exception ex)
        {
            _error = ex.Message;
            ret = false;
        }
        return ret;
    }

    public bool InsertStockOutItemOther(double stockOutID, ArrayList arrData)
    {
        bool ret = true;
        try
        {
            DataTable dt = GetStockOutItemList(stockOutID);
            for (int i = 0; i < arrData.Count; ++i)
            {
                VMaterialMasterUnitData VMaterialList = (VMaterialMasterUnitData)arrData[i];
                if (dt.Select("MATERIALMASTER = " + VMaterialList.MATERIALMASTER.ToString() + " AND UNIT = " + VMaterialList.UNIT.ToString()).Length == 0)
                {
                    DataRow dRow = dt.NewRow();
                    dRow["RANK"] = dt.Rows.Count + 1;
                    dRow["LOID"] = 0;
                    dRow["MATERIALMASTER"] = VMaterialList.MATERIALMASTER;
                    dRow["CODE"] = VMaterialList.MATERIALCODE;
                    dRow["MATERIALNAME"] = VMaterialList.MATERIALNAME;
                    dRow["UNIT"] = VMaterialList.UNIT;
                    dRow["UNITNAME"] = VMaterialList.UNITNAME;
                    dRow["FORMULAQTY"] = 0;
                    dRow["PREQTY"] = 0;
                    dRow["LASTQTY"] = 0;
                    dRow["REQQTY"] = 0;
                    dRow["QTY"] = 0;
                    dRow["PRICE"] = VMaterialList.COST;
                    dRow["REMAIN"] = 0;
                    dRow["REQTOTAL"] = 0;
                    dRow["ISMENU"] = "N";
                    dRow["STATUS"] = "WA";
                    dRow["STATUSSTOCKOUT"] = "WA";
                    dRow["STATUSNAME"] = "照證癒疰";
                    dt.Rows.Add(dRow);
                }
            }
            System.Web.HttpContext.Current.Session[sessionStockOutRequest] = dt;
        }
        catch (Exception ex)
        {
            _error = ex.Message;
            ret = false;
        }
        return ret;
    }

    public bool UpdateStockOutItem(double stockOutID, ArrayList arrData)
    {
        bool ret = true;
        try
        {
            DataTable dt = GetStockOutItemList(stockOutID);
            for (int i = 0; i < arrData.Count; ++i)
            {
                StockoutitemData pData = (StockoutitemData)arrData[i];
                DataRow[] dRows = dt.Select("RANK = " + pData.RANK.ToString());
                if (dRows.Length == 1)
                {
                    dRows[0]["REQQTY"] = pData.REQQTY;
                    dRows[0]["REQTOTAL"] = pData.REQQTY * pData.PRICE;
                }
            }
            System.Web.HttpContext.Current.Session[sessionStockOutRequest] = dt;
        }
        catch (Exception ex)
        {
            _error = ex.Message;
            ret = false;
        }
        return ret;
    }

    public bool UpdateStockOutItem(double stockOutID, ArrayList arrData, double division, DateTime useDate, bool isBreakfast, bool isLunch, bool isDinner)
    {
        StockOutRequestFlow flow = new StockOutRequestFlow();
        bool ret = true;
        try
        {
            DataTable dt = GetStockOutItemList(stockOutID);
            for (int i = 0; i < arrData.Count; ++i)
            {
                StockoutitemData pData = (StockoutitemData)arrData[i];
                DataRow[] dRows = dt.Select("RANK = " + pData.RANK.ToString());
                if (dRows.Length == 1)
                {
                    if (useDate.Year != 1)
                        dRows[0]["LASTQTY"] = flow.CalLastStockOut(division, pData.MATERIALMASTER, useDate, pData.UNIT);
                    else
                        dRows[0]["LASTQTY"] = 0;

                    VMenuStockOutData tmp = flow.GetMenuData(division, useDate, isBreakfast, isLunch, isDinner, pData.MATERIALMASTER, pData.UNIT);
                    dRows[0]["FORMULAQTY"] = tmp.FORMULAQTY;
                    dRows[0]["PREQTY"] = tmp.PREQTY;
                    dRows[0]["ISMENU"] = (tmp.MATERIALMASTER != 0 ? "Y" : "N");

                    dRows[0]["REQQTY"] = pData.REQQTY;
                    dRows[0]["REQTOTAL"] = pData.REQQTY * pData.PRICE;
                }
            }
            System.Web.HttpContext.Current.Session[sessionStockOutRequest] = dt;
        }
        catch (Exception ex)
        {
            _error = ex.Message;
            ret = false;
        }
        return ret;
    }

    public bool DeleteStockOutItem(ArrayList arrData)
    {
        bool ret = true;
        try
        {
            DataTable dt = (DataTable)System.Web.HttpContext.Current.Session[sessionStockOutRequest];
            for (int i = 0; i < arrData.Count; ++i)
            {
                DataRow[] dRow = dt.Select("RANK = " + arrData[i].ToString());
                if (dRow.Length == 1)
                {
                    dt.Rows.Remove(dRow[0]);
                }
            }
            ReOrder(dt, "RANK");
            System.Web.HttpContext.Current.Session[sessionStockOutRequest] = dt;
        }
        catch (Exception ex)
        {
            _error = ex.Message;
            ret = false;
        }
        return ret;
    }

}
