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
using SHND.Data.Formula;
using SHND.Data.Tables;
using SHND.Data.Views;
using SHND.Flow.Formula;

/// <summary>
/// Summary description for MenuDetailItem
/// </summary>
public class MenuDetailItem
{
    private string sessionMenuDisease = "MenuDisease";

    public MenuDetailItem()
    {
        //
        // TODO: Add constructor logic here
        //
    }
    public void ClearAllSession()
    {
        ClearMenuDisease();
    }

    public void ClearMenuDisease()
    {
        System.Web.HttpContext.Current.Session[sessionMenuDisease] = null;
    }

    #region MenuDisease

    public ArrayList GetMenuDiseaseData()
    {
        ArrayList arrData = new ArrayList();
        DataTable dt = (DataTable)System.Web.HttpContext.Current.Session[sessionMenuDisease];
        if (dt != null)
        {
            for (int i = 0; i < dt.Rows.Count; ++i)
            {
                MenuDiseaseData MenuDisease = new MenuDiseaseData();
                MenuDisease.DISEASECATEGORY = Convert.ToDouble(dt.Rows[i]["DISEASECATEGORY"]);
                MenuDisease.MENU = Convert.ToDouble(dt.Rows[i]["MENU"]);
                MenuDisease.ISHIGH = dt.Rows[i]["ISHIGH"].ToString();
                MenuDisease.ISLOW = dt.Rows[i]["ISLOW"].ToString();
                MenuDisease.ISNON = dt.Rows[i]["ISNON"].ToString();
                arrData.Add(MenuDisease);
            }
        }
        return arrData;
    }

    public string GetDiseaseCategoryList()
    {
        string diseaseCategoryList = "";
        DataTable dt = (DataTable)System.Web.HttpContext.Current.Session[sessionMenuDisease];
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
    public DataTable GetMenuDiseaseList(double MenuID)
    {
        if (System.Web.HttpContext.Current.Session[sessionMenuDisease] == null)
        {
            MenuFlow Menu = new MenuFlow();
            System.Web.HttpContext.Current.Session[sessionMenuDisease] = Menu.GetMenuDiseaseList(MenuID);
        }
        return (DataTable)System.Web.HttpContext.Current.Session[sessionMenuDisease];
    }

    public bool InsertMenuDisease(double MenuID, ArrayList arrData)
    {
        bool ret = true;
        try
        {
            DataTable dt = GetMenuDiseaseList(MenuID);
            for (int i = 0; i < arrData.Count; ++i)
            {
                VDiseaseCategoryData VDiseaseCategory = (VDiseaseCategoryData)arrData[i];
                if (dt.Select("DISEASECATEGORY = " + VDiseaseCategory.LOID.ToString()).Length == 0)
                {
                    DataRow dRow = dt.NewRow();
                    MenuFlow ftFlow = new MenuFlow();
                    DataTable dtDC = ftFlow.GetDiseaseCategoryByLOID(VDiseaseCategory.LOID.ToString());

                    dRow["DISEASECATEGORY"] = VDiseaseCategory.LOID;
                    dRow["MENU"] = MenuID;
                    dRow["DISEASECATEGORYNAME"] = VDiseaseCategory.ABBNAME;
                    dRow["ISHIGH"] = VDiseaseCategory.ISHIGH;
                    dRow["ISLOW"] = VDiseaseCategory.ISLOW;
                    dRow["ISNON"] = VDiseaseCategory.ISNON;
                    dRow["ISHIGHVISIBLE"] = (dtDC.Rows[0]["ISHIGH"] != null ? dtDC.Rows[0]["ISHIGH"].ToString() : "");
                    dRow["ISLOWVISIBLE"] = (dtDC.Rows[0]["ISLOW"] != null ? dtDC.Rows[0]["ISLOW"].ToString() : "");
                    dRow["ISNONVISIBLE"] = (dtDC.Rows[0]["ISNON"] != null ? dtDC.Rows[0]["ISNON"].ToString() : "");

                    dt.Rows.Add(dRow);
                }
            }
            System.Web.HttpContext.Current.Session[sessionMenuDisease] = dt;
        }
        catch (Exception ex)
        {
            ex.ToString();
            ret = false;
        }
        return ret;
    }

    public bool DeleteMenuDisease(ArrayList arrData)
    {
        bool ret = true;
        try
        {
            DataTable dt = (DataTable)System.Web.HttpContext.Current.Session[sessionMenuDisease];
            for (int i = 0; i < arrData.Count; ++i)
            {
                DataRow[] dRow = dt.Select("DISEASECATEGORY = " + arrData[i].ToString());
                if (dRow.Length == 1)
                {
                    dt.Rows.Remove(dRow[0]);
                }
            }
            System.Web.HttpContext.Current.Session[sessionMenuDisease] = dt;
        }
        catch (Exception ex)
        {
            ex.ToString();
            ret = false;
        }
        return ret;
    }
    #endregion

    #region FormulasetNutrient

    [System.ComponentModel.DataObjectMethodAttribute(System.ComponentModel.DataObjectMethodType.Select, true)]
    public DataTable GetMenuNutrientList(double MenuID, string meal, DateTime menuDate)
    {
        MenuFlow Menu = new MenuFlow();
        return Menu.GetMenuNutrientList(MenuID, meal, menuDate);
    }

        #endregion


    #region FormulasetNutrient

    [System.ComponentModel.DataObjectMethodAttribute(System.ComponentModel.DataObjectMethodType.Select, true)]
    public DataTable GetStdMenuList(double MenuID)
    {
        MenuFlow Menu = new MenuFlow();
        return Menu.GetStdMenuList(MenuID);
    }

    #endregion

    }

