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
using SHND.Data.Common.Utilities;
using SHND.Data.Tables;
using SHND.Data.Views;
using SHND.Flow.Order;

/// <summary>
/// Summary description for OrderPartyItem
/// </summary>
public class OrderPartyItem
{
    private string sessionOrderPartyItem = "OrderPartyItem";

    public OrderPartyItem()
    {
        //
        // TODO: Add constructor logic here
        //
    }

    public void ClearOrderPartyItem()
    {
        System.Web.HttpContext.Current.Session[sessionOrderPartyItem] = null;
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

    #region OrderPartyItem

    public ArrayList GetOrderPartyItemData()
    {
        ArrayList arrData = new ArrayList();
        DataTable dt = (DataTable)System.Web.HttpContext.Current.Session[sessionOrderPartyItem];
        if (dt != null)
        {
            for (int i = 0; i < dt.Rows.Count; ++i)
            {
               // VOrderPartyData OrderPartyItem = new OrderPartyData();
               // OrderPartyItem.ENERGY = Convert.ToDouble(dt.Rows[i]["ENERGY"]);
               // OrderPartyItem.FORMULAFEED = Convert.ToDouble(dt.Rows[i]["FORMULAFEED"]);
               // OrderPartyItem.LOID = Convert.ToDouble(dt.Rows[i]["LOID"]);
               // OrderPartyItem.MATERIALMASTER = Convert.ToDouble(dt.Rows[i]["MATERIALMASTER"]);
               //// OrderPartyItem.PREPARENAME = dt.Rows[i]["PREPARENAME"].ToString();
               //// OrderPartyItem.REFFORMULA = 0;
               // OrderPartyItem.QTY = Convert.ToDouble(dt.Rows[i]["QTY"]);
               // OrderPartyItem.UNIT = Convert.ToDouble(dt.Rows[i]["UNIT"]);
               // arrData.Add(OrderPartyItem);
            }
        }
        return arrData;
    }

    public string getOrderList()
    {
        string OrderList = "";
        DataTable dt = (DataTable)System.Web.HttpContext.Current.Session[sessionOrderPartyItem];
        if (dt != null)
        {
            for (int i = 0; i < dt.Rows.Count; ++i)
            {
                OrderList += (OrderList == "" ? "" : ",") + dt.Rows[i]["FORMULASET"].ToString();
            }
        }
        return OrderList;
    }

    [System.ComponentModel.DataObjectMethodAttribute(System.ComponentModel.DataObjectMethodType.Select, true)]
    public DataTable GetOrderPartyItemList(double OrderParty)
    {
        if (System.Web.HttpContext.Current.Session[sessionOrderPartyItem] == null)
        {
            OrderPartyFlow Formula = new OrderPartyFlow();
            System.Web.HttpContext.Current.Session[sessionOrderPartyItem] = Formula.GetOrderPartyList(OrderParty);
        }
        return (DataTable)System.Web.HttpContext.Current.Session[sessionOrderPartyItem];
    }

    public string VerifyData(double qty)
    {
        string ret = "";
        if (qty == 0)
            ret = string.Format(DataResources.MSGEI001, "จำนวนที่เบิก");

        return ret;
    }

    public bool InsertOrderPartyItem(double OrderParty, ArrayList arrData)
    {
        bool ret = true;
        try
        {
            DataTable dt = GetOrderPartyItemList(OrderParty);
            for (int i = 0; i < arrData.Count; ++i)
            {
                VFormulaSetSearchData Formulaset = (VFormulaSetSearchData)arrData[i];
                if (dt.Select("LOID = " + Formulaset.LOID.ToString()).Length == 0)
                {
                    DataRow dRow = dt.NewRow();
                    dRow["RANK"] = dt.Rows.Count + 1;
                    dRow["LOID"] = dt.Rows.Count + 1;
                    dRow["ORDERPARTY"] = OrderParty;
                    dRow["FORMULASET"] = Formulaset.LOID;
                    dRow["FORMULASETNAME"] = Formulaset.FORMULANAME;
                    dRow["FOODCOOKTYPENAME"] = Formulaset.FOODCOOKTYPENAME;
                    dRow["VISITORQTY"] = 0;
                    dRow["SERVICEQTY"] = 0;

                    dt.Rows.Add(dRow);
                }
            }
            System.Web.HttpContext.Current.Session[sessionOrderPartyItem] = dt;
        }
        catch (Exception ex)
        {
            ex.ToString();
            ret = false;
        }
        return ret;
    }

    public bool UpdateOrderPartyItem(double OrderParty, ArrayList arrData)
    {
        bool ret = true;
        try
        {
            DataTable dt = GetOrderPartyItemList(OrderParty);
            for (int i = 0; i < arrData.Count; ++i)
            {
                OrderPartyItemData OrderPartyItem = (OrderPartyItemData)arrData[i];
                DataRow[] dRows = dt.Select("FORMULASET = " + OrderPartyItem.FORMULASET.ToString());
                if (dRows.Length == 1)
                {
                    dRows[0]["VISITORQTY"] = OrderPartyItem.VISITORQTY;
                    dRows[0]["SERVICEQTY"] = OrderPartyItem.SERVICEQTY;
                }
            }
            System.Web.HttpContext.Current.Session[sessionOrderPartyItem] = dt;
        }
        catch (Exception ex)
        {
            ex.ToString();
            ret = false;
        }
        return ret;
    }


    public bool DeleteOrderPartyItem(ArrayList arrData)
    {
        bool ret = true;
        try
        {
            DataTable dt = (DataTable)System.Web.HttpContext.Current.Session[sessionOrderPartyItem];
            for (int i = 0; i < arrData.Count; ++i)
            {
                DataRow[] dRow = dt.Select("RANK = " + arrData[i].ToString());
                if (dRow.Length == 1)
                {
                    dt.Rows.Remove(dRow[0]);
                }
            }
            ReOrder(dt, "RANK");
            System.Web.HttpContext.Current.Session[sessionOrderPartyItem] = dt;
        }
        catch (Exception ex)
        {
            ex.ToString();
            ret = false;
        }
        return ret;
    }

    #endregion




}
