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
/// Summary description for StandardMenuDetailItem
/// </summary>
public class StandardMenuDetailItem
{
    private string sessionStdMenuDisease = "StdMenuDisease";

    public StandardMenuDetailItem()
    {
        //
        // TODO: Add constructor logic here
        //
    }

    public void ClearAllSession()
    {
        ClearStdMenuDisease();
    }

    public void ClearStdMenuDisease()
    {
        System.Web.HttpContext.Current.Session[sessionStdMenuDisease] = null;
    }

    #region StdMenuDisease

    public ArrayList GetStdMenuDiseaseData()
    {
        ArrayList arrData = new ArrayList();
        DataTable dt = (DataTable)System.Web.HttpContext.Current.Session[sessionStdMenuDisease];
        if (dt != null)
        {
            for (int i = 0; i < dt.Rows.Count; ++i)
            {
                StdMenuDiseaseData StdMenuDisease = new StdMenuDiseaseData();
                StdMenuDisease.DISEASECATEGORY = Convert.ToDouble(dt.Rows[i]["DISEASECATEGORY"]);
                StdMenuDisease.STDMENU = Convert.ToDouble(dt.Rows[i]["STDMENU"]);
                StdMenuDisease.ISHIGH = (dt.Rows[i]["ISHIGH"].ToString() == "Y");
                StdMenuDisease.ISLOW = (dt.Rows[i]["ISLOW"].ToString() == "Y");
                StdMenuDisease.ISNON = (dt.Rows[i]["ISNON"].ToString() == "Y");
                arrData.Add(StdMenuDisease);
            }
        }
        return arrData;
    }

    public string GetDiseaseCategoryList()
    {
        string diseaseCategoryList = "";
        DataTable dt = (DataTable)System.Web.HttpContext.Current.Session[sessionStdMenuDisease];
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
    public DataTable GetStdMenuDiseaseList(double stdMenuID)
    {
        if (System.Web.HttpContext.Current.Session[sessionStdMenuDisease] == null)
        {
            StandardMenuFlow StandardMenu = new StandardMenuFlow();
            System.Web.HttpContext.Current.Session[sessionStdMenuDisease] = StandardMenu.GetStdMenuDiseaseList(stdMenuID);
        }
        return (DataTable)System.Web.HttpContext.Current.Session[sessionStdMenuDisease];
    }

    public bool InsertStdMenuDisease(double stdMenuID, ArrayList arrData)
    {
        bool ret = true;
        try
        {
            DataTable dt = GetStdMenuDiseaseList(stdMenuID);
            for (int i = 0; i < arrData.Count; ++i)
            {
                VDiseaseCategoryData VDiseaseCategory = (VDiseaseCategoryData)arrData[i];
                if (dt.Select("DISEASECATEGORY = " + VDiseaseCategory.LOID.ToString()).Length == 0)
                {
                    DataRow dRow = dt.NewRow();
                    MenuFlow ftFlow = new MenuFlow();
                    DataTable dtDC = ftFlow.GetDiseaseCategoryByLOID(VDiseaseCategory.LOID.ToString());

                    dRow["DISEASECATEGORY"] = VDiseaseCategory.LOID;
                    dRow["STDMENU"] = stdMenuID;
                    dRow["DISEASECATEGORYNAME"] = VDiseaseCategory.ABBNAME;
                    dRow["ISHIGH"] = VDiseaseCategory.ISHIGH;
                    dRow["ISLOW"] = VDiseaseCategory.ISLOW;
                    dRow["ISNON"] = VDiseaseCategory.ISNON;
                    //dRow["ISHIGHVISIBLE"] = (dtDC.Rows[0]["ISHIGH"] != null ? dtDC.Rows[0]["ISHIGH"].ToString() : "");
                    //dRow["ISLOWVISIBLE"] = (dtDC.Rows[0]["ISLOW"] != null ? dtDC.Rows[0]["ISLOW"].ToString() : "");
                    //dRow["ISNONVISIBLE"] = (dtDC.Rows[0]["ISNON"] != null ? dtDC.Rows[0]["ISNON"].ToString() : "");
                    dRow["ISHIGH"] = (dtDC.Rows[0]["ISHIGH"] != null ? dtDC.Rows[0]["ISHIGH"].ToString() : "");
                    dRow["ISLOW"] = (dtDC.Rows[0]["ISLOW"] != null ? dtDC.Rows[0]["ISLOW"].ToString() : "");
                    dRow["ISNON"] = (dtDC.Rows[0]["ISNON"] != null ? dtDC.Rows[0]["ISNON"].ToString() : "");


                    dt.Rows.Add(dRow);
                }
            }
            System.Web.HttpContext.Current.Session[sessionStdMenuDisease] = dt;
        }
        catch (Exception ex)
        {
            ex.ToString();
            ret = false;
        }
        return ret;
    }

    public bool DeleteStdMenuDisease(ArrayList arrData)
    {
        bool ret = true;
        try
        {
            DataTable dt = (DataTable)System.Web.HttpContext.Current.Session[sessionStdMenuDisease];
            for (int i = 0; i < arrData.Count; ++i)
            {
                DataRow[] dRow = dt.Select("DISEASECATEGORY = " + arrData[i].ToString());
                if (dRow.Length == 1)
                {
                    dt.Rows.Remove(dRow[0]);
                }
            }
            System.Web.HttpContext.Current.Session[sessionStdMenuDisease] = dt;
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
    public DataTable GeStdMenuNutrientList(double stdMenuID, string meal, double menuDate)
    {
        StandardMenuFlow StandardMenu = new StandardMenuFlow();
        return StandardMenu.GeStdMenuNutrientList(stdMenuID, meal, menuDate);
    }

    #endregion

}
