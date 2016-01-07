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
/// Summary description for ReturnRequestDetailItem
/// </summary>
public class ReturnRequestDetailItem
{
    private string sessionReturnRequestItem = "ReturnRequest";
    private string _error = "";

    public ReturnRequestDetailItem()
    {
        //
        // TODO: Add constructor logic here
        //
    }
    public void ClearAllSession()
    {
        ClearReturnRequest();
    }
    public void ClearReturnRequest()
    {
        System.Web.HttpContext.Current.Session[sessionReturnRequestItem] = null;
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
    public ArrayList GetReturnRequestData()
    {
        ArrayList arrData = new ArrayList();
        DataTable dt = (DataTable)System.Web.HttpContext.Current.Session[sessionReturnRequestItem];
        if (dt != null)
        {
            for (int i = 0; i < dt.Rows.Count; ++i)
            {
                VRetrunRequestPopupData VRetrunRequestPopup = new VRetrunRequestPopupData();
                VRetrunRequestPopup.UNITNAME = dt.Rows[i]["UNITNAME"].ToString();
                arrData.Add(VRetrunRequestPopup);
            }
        }
        return arrData;
    }
    public string GetReturnRequestList()
    {
        string StockIn = "";
        DataTable dt = (DataTable)System.Web.HttpContext.Current.Session[sessionReturnRequestItem];
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
    public DataTable GetReturnRequestItemList(double StockInID)
    {
        if (System.Web.HttpContext.Current.Session[sessionReturnRequestItem] == null)
        {
            ReturnRequestFlow ReturnRequest = new ReturnRequestFlow();
            System.Web.HttpContext.Current.Session[sessionReturnRequestItem] = ReturnRequest.GetStockInList(StockInID);
        }
        return (DataTable)System.Web.HttpContext.Current.Session[sessionReturnRequestItem];
    }



    public bool InsertReturnRequestItem( double StockInID, ArrayList arrData)
    {
        bool ret = true;
        try
        {
            DataTable dt = GetReturnRequestItemList(StockInID);
            for (int i = 0; i < arrData.Count; ++i)
            {
                VRetrunRequestPopupData VReturnRequestPopup = (VRetrunRequestPopupData)arrData[i];
                if (dt.Select("MATERIALMASTER = " + VReturnRequestPopup.MATERIALMASTER .ToString()).Length == 0)
                {
                    DataRow dRow = dt.NewRow();
                    dRow["MATERIALCODE"] = VReturnRequestPopup.MATERIALCODE;
                    dRow["MATERIALNAME"] = VReturnRequestPopup.MATERIALNAME;
                    dRow["UNITNAME"] = VReturnRequestPopup.UNITNAME;
                    dRow["UNIT"] = VReturnRequestPopup.UNIT;
                    dRow["MATERIALMASTER"] = VReturnRequestPopup.MATERIALMASTER;
                    dRow["QTY"] = VReturnRequestPopup.QTY;
                    dRow["STOCKOUTQTY"] = VReturnRequestPopup.QTY;

                    dt.Rows.Add(dRow);
                }
            }
            System.Web.HttpContext.Current.Session[sessionReturnRequestItem] = dt;
        }
        catch (Exception ex)
        {
            ex.ToString();
            ret = false;
        }
        return ret;
    }


    public bool DeleteReturnRequestItem(ArrayList arrLOID)
    {
        bool ret = true;
        try
        {
            DataTable dt = (DataTable)System.Web.HttpContext.Current.Session[sessionReturnRequestItem];
            for (int i = 0; i < arrLOID.Count; ++i)
            {
                DataRow[] dRow = dt.Select("MATERIALMASTER = " + arrLOID[i].ToString());
                if (dRow.Length == 1)
                {
                    dt.Rows.Remove(dRow[0]);
                }
            }
            //ReOrder(dt, "MATERIALMASTER");
            System.Web.HttpContext.Current.Session[sessionReturnRequestItem] = dt;
        }
        catch (Exception ex)
        {
            ex.ToString();
            ret = false;
        }
        return ret;
    }
    public bool UpdateReturnRequestItem(double StockInID, ArrayList arrData)
    {
        bool ret = true;
        try
        {
            DataTable dt = GetReturnRequestItemList(StockInID);
            for (int i = 0; i < arrData.Count; ++i)
            {
                //VRetrunRequestPopupData VReturnRequestPopup = (VRetrunRequestPopupData)arrData[i];
                StockinItemData VReturnRequestPopup = (StockinItemData)arrData[i];
                DataRow[] dRows = dt.Select("MATERIALMASTER = " + VReturnRequestPopup.MATERIALMASTER.ToString());
                if (dRows.Length == 1)
                {
                    dRows[0]["QTY"] = VReturnRequestPopup.QTY;
                    dRows[0]["WASTEQTY"] = VReturnRequestPopup.WASTEQTY;
                    dRows[0]["UNIT"] = VReturnRequestPopup.UNIT;
                    dRows[0]["UNITNAME"] = VReturnRequestPopup.UNITNAME;
                }
            }
            System.Web.HttpContext.Current.Session[sessionReturnRequestItem] = dt;
        }
        catch (Exception ex)
        {
            _error = ex.Message;
            ret = false;
        }
        return ret;
    }
    

}
