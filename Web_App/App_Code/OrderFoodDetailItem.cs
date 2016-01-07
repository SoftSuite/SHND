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
using SHND.Data.Views;
using SHND.Data.Common.Utilities;
using SHND.Flow.Order;

/// <summary>
/// Summary description for OrderFoodDetailItem
/// </summary>
public class OrderFoodDetailItem
{
    private string sessionOrderDetailItem = "OrderDetailItem";

    public OrderFoodDetailItem()
    {
        //
        // TODO: Add constructor logic here
        //
    }

    public void ClearAllSession()
    {
        ClearOrderDetailItem();
    }

    public void ClearOrderDetailItem()
    {
        System.Web.HttpContext.Current.Session[sessionOrderDetailItem] = null;
    }

    public ArrayList GetOrderItemList()
    {
        ArrayList arrData = new ArrayList();
        DataTable dt = (DataTable)System.Web.HttpContext.Current.Session[sessionOrderDetailItem];
        for (int i = 0; i < dt.Rows.Count; ++i)
        {
            DataRow dRow = dt.Rows[i];
            VOrderDetailItemData item = new VOrderDetailItemData();
            item.DISEASECATEGORY = Convert.ToDouble(dRow["DISEASECATEGORY"]);
            item.ISHIGH = (dRow["ISHIGH"].ToString() == "Y");
            item.ISLOW = (dRow["ISLOW"].ToString() == "Y");
            item.ISNON = (dRow["ISNON"].ToString() == "Y");
            item.QTY = Convert.ToDouble(dRow["QTY"]);
            item.UNIT = Convert.ToDouble(dRow["UNIT"]);
            item.MEAL = dRow["MEAL"].ToString();

            arrData.Add(item);
        }
        return arrData;
    }

    [System.ComponentModel.DataObjectMethodAttribute(System.ComponentModel.DataObjectMethodType.Select, true)]
    public DataTable GetDiseaseCategoryList(double refLOID, string refTable)
    {
        if (System.Web.HttpContext.Current.Session[sessionOrderDetailItem] == null)
        {
            OrderFoodFlow fFlow = new OrderFoodFlow();
            System.Web.HttpContext.Current.Session[sessionOrderDetailItem] = fFlow.GetDiseaseCategoryList(refLOID, refTable);
        }
        return (DataTable)System.Web.HttpContext.Current.Session[sessionOrderDetailItem];
    }

    public bool InsertDiseaseCategory(double refLOID, string refTable, ArrayList arrData)
    {
        bool ret = true;
        try
        {
            DataTable dt = GetDiseaseCategoryList(refLOID, refTable);
            for (int i = 0; i < arrData.Count; ++i)
            {
                VDiseaseCategoryData VDiseaseCategory = (VDiseaseCategoryData)arrData[i];
                if (dt.Select("DISEASECATEGORY = " + VDiseaseCategory.LOID.ToString()).Length == 0)
                {
                    DataRow dRow = dt.NewRow();
                    dRow["DISEASECATEGORY"] = VDiseaseCategory.LOID;
                    dRow["DISEASECATEGORYNAME"] = VDiseaseCategory.ABBNAME;
                    dRow["QTY"] = VDiseaseCategory.QTY;
                    dRow["UNIT"] = VDiseaseCategory.UNIT;
                    dRow["UNITNAME"] = VDiseaseCategory.UNITNAME;
                    dRow["ISHIGH"] = VDiseaseCategory.ISHIGH;
                    dRow["ISLOW"] = VDiseaseCategory.ISLOW;
                    dRow["ISNON"] = VDiseaseCategory.ISNON;
                    dRow["MEAL"] = VDiseaseCategory.MEAL;
                    dRow["MEALNAME"] = VDiseaseCategory.MEALNAME;
                    dRow["ISSPIN"] = "N";
                    dt.Rows.Add(dRow);
                }
            }
            System.Web.HttpContext.Current.Session[sessionOrderDetailItem] = dt;
        }
        catch (Exception ex)
        {
            ex.ToString();
            ret = false;
        }
        return ret;
    }

    [System.ComponentModel.DataObjectMethodAttribute(System.ComponentModel.DataObjectMethodType.Delete, true)]
    public bool DeleteDiseaseCategory(double DISEASECATEGORY)
    {
        bool ret = true;
        try
        {
            DataTable dt = (DataTable)System.Web.HttpContext.Current.Session[sessionOrderDetailItem];
            DataRow[] dRow = dt.Select("DISEASECATEGORY = " + DISEASECATEGORY.ToString());
            if (dRow.Length == 1)
            {
                dt.Rows.Remove(dRow[0]);
            }
            System.Web.HttpContext.Current.Session[sessionOrderDetailItem] = dt;
        }
        catch (Exception ex)
        {
            ex.ToString();
            ret = false;
        }
        return ret;
    }

    public bool DeleteDiseaseCategory(ArrayList arrData)
    {
        bool ret = true;
        try
        {
            DataTable dt = (DataTable)System.Web.HttpContext.Current.Session[sessionOrderDetailItem];
            for (int i = 0; i < arrData.Count; ++i)
            {
                DataRow[] dRow = dt.Select("DISEASECATEGORY = " + arrData[i].ToString());
                if (dRow.Length == 1)
                {
                    dt.Rows.Remove(dRow[0]);
                }
            }
            System.Web.HttpContext.Current.Session[sessionOrderDetailItem] = dt;
        }
        catch (Exception ex)
        {
            ex.ToString();
            ret = false;
        }
        return ret;
    }
}
