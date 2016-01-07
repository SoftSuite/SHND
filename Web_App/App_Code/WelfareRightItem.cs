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
/// Summary description for WelfareRightItem
/// </summary>
public class WelfareRightItem
{
    private string sessionWelfareRightItem = "WelfareRightItem";

    public WelfareRightItem()
    {
        //
        // TODO: Add constructor logic here
        //
    }

    public void ClearAllSession()
    {
        ClearWelfareRightItem();
    }

    public void ClearWelfareRightItem()
    {
        System.Web.HttpContext.Current.Session[sessionWelfareRightItem] = null;
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

    #region WelfareRightItem

    public ArrayList GetWelfareRightItemData()
    {
        ArrayList arrData = new ArrayList();
        DataTable dt = (DataTable)System.Web.HttpContext.Current.Session[sessionWelfareRightItem];
        if (dt != null)
        {
            for (int i = 0; i < dt.Rows.Count; ++i)
            {
                VWelfareRightItemData WelfareRightItem = new VWelfareRightItemData();
                WelfareRightItem.DIVISION = Convert.ToDouble(dt.Rows[i]["DIVISION"]);
                WelfareRightItem.DIVISIONNAME = dt.Rows[i]["DIVISIONNAME"].ToString();
                WelfareRightItem.LOID = Convert.ToDouble(dt.Rows[i]["LOID"]);
                WelfareRightItem.QTY = Convert.ToDouble(dt.Rows[i]["QTY"]);
                WelfareRightItem.QTYRIGHT = Convert.ToDouble(dt.Rows[i]["QTYRIGHT"]);
                WelfareRightItem.WELFARERIGHT = Convert.ToDouble(dt.Rows[i]["WELFARERIGHT"]);
                arrData.Add(WelfareRightItem);
            }
        }
        return arrData;
    }
    

    public string getDivision()
    {
        string division = "";
        DataTable dt = (DataTable)System.Web.HttpContext.Current.Session[sessionWelfareRightItem];
        if (dt != null)
        {
            for (int i = 0; i < dt.Rows.Count; ++i)
            {
                division += (division == "" ? "" : ",") + dt.Rows[i]["DIVISION"].ToString();
            }
        }
        return division;
    }

    [System.ComponentModel.DataObjectMethodAttribute(System.ComponentModel.DataObjectMethodType.Select, true)]
    public DataTable GetWelfareRightItemList(double welfare)
    {
        if (System.Web.HttpContext.Current.Session[sessionWelfareRightItem] == null)
        {
            WelfareRightFlow Formula = new WelfareRightFlow();
            System.Web.HttpContext.Current.Session[sessionWelfareRightItem] = Formula.GetWelfareRightItemList(welfare);
        }
        return (DataTable)System.Web.HttpContext.Current.Session[sessionWelfareRightItem];
    }


    public bool InsertWelfareRightItem(double welfare, ArrayList arrData)
    {
        bool ret = true;
        try
        {
            DataTable dt = GetWelfareRightItemList(welfare);
            for (int i = 0; i < arrData.Count; ++i)
            {
                VWelfareRightItemData VDivision = (VWelfareRightItemData)arrData[i];
                if (dt.Select("DIVISION = " + VDivision.DIVISION.ToString()).Length == 0)
                {
                    DataRow dRow = dt.NewRow();
                    dRow["RANK"] = dt.Rows.Count + 1;
                    dRow["LOID"] = dt.Rows.Count + 1;
                    dRow["WELFARERIGHT"] = welfare;
                    dRow["DIVISION"] = VDivision.DIVISION;
                    dRow["DIVISIONNAME"] = VDivision.DIVISIONNAME;
                    dRow["ISOVER"] = VDivision.ISOVER;
                    dRow["QTY"] = 0;
                    dRow["QTYRIGHT"] = 0;

                    dt.Rows.Add(dRow);
                }
            }
            System.Web.HttpContext.Current.Session[sessionWelfareRightItem] = dt;
        }
        catch (Exception ex)
        {
            ex.ToString();
            ret = false;
        }
        return ret;
    }

    public bool UpdateWelfareRightItem(double welfare, ArrayList arrData)
    {
        bool ret = true;
        try
        {
            DataTable dt = GetWelfareRightItemList(welfare);
            for (int i = 0; i < arrData.Count; ++i)
            {
                VWelfareRightItemData VDivision = (VWelfareRightItemData)arrData[i];
                DataRow[] dRows = dt.Select("DIVISION = " + VDivision.DIVISION.ToString());
                if (dRows.Length == 1)
                {
                    dRows[0]["QTY"] = VDivision.QTY;
                    dRows[0]["QTYRIGHT"] = VDivision.QTYRIGHT;
                    dRows[0]["ISOVER"] = VDivision.ISOVER;

                }
            }
            System.Web.HttpContext.Current.Session[sessionWelfareRightItem] = dt;
        }
        catch (Exception ex)
        {
            ex.ToString();
            ret = false;
        }
        return ret;
    }


    public bool DeleteWelfareRightItem(ArrayList arrData)
    {
        bool ret = true;
        try
        {
            DataTable dt = (DataTable)System.Web.HttpContext.Current.Session[sessionWelfareRightItem];
            for (int i = 0; i < arrData.Count; ++i)
            {
                DataRow[] dRow = dt.Select("RANK = " + arrData[i].ToString());
                if (dRow.Length == 1)
                {
                    dt.Rows.Remove(dRow[0]);
                }
            }
            ReOrder(dt, "RANK");
            System.Web.HttpContext.Current.Session[sessionWelfareRightItem] = dt;
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
