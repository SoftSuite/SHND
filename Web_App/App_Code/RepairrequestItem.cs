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
using SHND.Flow.Inventory;
using SHND.DAL.Views;

/// <summary>
/// Summary description for RepairrequestItem
/// </summary>
public class RepairrequestItem
{
    private string sessionRepairrequestItem = "RepairrequestItem";

    public RepairrequestItem()
    {
        //
        // TODO: Add constructor logic here
        //
    }
    public void ClearAllSession()
    {
        ClearRepairrequestItem();
    }
    public void ClearRepairrequestItem()
    {
        System.Web.HttpContext.Current.Session[sessionRepairrequestItem] = null;
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
    #region RepairrequestItem

    public ArrayList GetRepairrequestData()
    {
        ArrayList arrData = new ArrayList();
        DataTable dt = (DataTable)System.Web.HttpContext.Current.Session[sessionRepairrequestItem];
        if (dt != null)
        {
            for (int i = 0; i < dt.Rows.Count; ++i)
            {
                VRepairrequestData VRepairrequest = new VRepairrequestData();
                VRepairrequest.SRLOID = Convert.ToDouble(dt.Rows[i]["SRLOID"]);
                VRepairrequest.MATERIALCODE = dt.Rows[i]["MATERIALCODE"].ToString();
                VRepairrequest.LOTNO = dt.Rows[i]["LOTNO"].ToString();
                VRepairrequest.MATERIALNAME = dt.Rows[i]["MATERIALNAME"].ToString();
                VRepairrequest.UNITNAME = dt.Rows[i]["UNITNAME"].ToString();
                arrData.Add(VRepairrequest);
            }
        }
        return arrData;
    }

    public string GetDiseaseCategoryList()
    {
        string diseaseCategoryList = "";
        DataTable dt = (DataTable)System.Web.HttpContext.Current.Session[sessionRepairrequestItem];
        if (dt != null)
        {
            for (int i = 0; i < dt.Rows.Count; ++i)
            {
                diseaseCategoryList += (diseaseCategoryList == "" ? "" : ",") + dt.Rows[i]["DISEASECATEGORY"].ToString();
            }
        }
        return diseaseCategoryList;
    }

    [System.ComponentModel.DataObjectMethodAttribute(System.ComponentModel.DataObjectMethodType.Select, true)]
    public DataTable GetRepairrequestList(double MenuID)
    {
        if (System.Web.HttpContext.Current.Session[sessionRepairrequestItem] == null)
        {
            RepairRequestFlow Menu = new RepairRequestFlow();
            System.Web.HttpContext.Current.Session[sessionRepairrequestItem] = Menu.GetRepairrequestItemList(MenuID);
        }
        return (DataTable)System.Web.HttpContext.Current.Session[sessionRepairrequestItem];
    }
    
    public bool InsertRepairrequest(double MenuID, ArrayList arrData)
    {
        bool ret = true;
        try
        {
            DataTable dt = GetRepairrequestList(MenuID);
            for (int i = 0; i < arrData.Count; ++i)
            {
                VRepairrequestData VRepairrequest = (VRepairrequestData)arrData[i];
                if (dt.Select("SRLOID = " + VRepairrequest.SRLOID.ToString()).Length == 0)
                {
                    DataRow dRow = dt.NewRow();
                    dRow["SRLOID"] = dt.Rows.Count + 1;
                    dRow["RANK"] = dt.Rows.Count + 1;
                    dRow["SRLOID"] = VRepairrequest.SRLOID;
                    dRow["MATERIALCODE"] = VRepairrequest.MATERIALCODE;
                    dRow["LOTNO"] = VRepairrequest.LOTNO;
                    dRow["MATERIALNAME"] = VRepairrequest.MATERIALNAME;
                    dRow["UNITNAME"] = VRepairrequest.UNITNAME;
                    dt.Rows.Add(dRow);
                }
            }
            System.Web.HttpContext.Current.Session[sessionRepairrequestItem] = dt;
        }
        catch (Exception ex)
        {
            ex.ToString();
            ret = false;
        }
        return ret;
    }

    public bool DeleteRepairrequest(ArrayList arrData)
    {
        bool ret = true;
        try
        {
            DataTable dt = (DataTable)System.Web.HttpContext.Current.Session[sessionRepairrequestItem];
            for (int i = 0; i < arrData.Count; ++i)
            {
                DataRow[] dRow = dt.Select("SRLOID = " + arrData[i].ToString());
                if (dRow.Length == 1)
                {
                    dt.Rows.Remove(dRow[0]);
                }
            }
            System.Web.HttpContext.Current.Session[sessionRepairrequestItem] = dt;
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