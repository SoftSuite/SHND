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
using SHND.Flow.Formula;

/// <summary>
/// Summary description for BlenderizeItem
/// </summary>
public class BlenderizeItem
{
    private string sessionBlenderizeItem = "BlenderizeItem";
    private string sessionFormulaDisease = "FormulaDisease";

    public BlenderizeItem()
    {
        //
        // TODO: Add constructor logic here
        //
    }

    public void ClearAllSession()
    {
        ClearBlenderizeItem();
        ClearFormulaDisease();
    }

    public void ClearBlenderizeItem()
    {
        System.Web.HttpContext.Current.Session[sessionBlenderizeItem] = null;
    }

    public void ClearFormulaDisease()
    {
        System.Web.HttpContext.Current.Session[sessionFormulaDisease] = null;
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

    #region BlenderizeItem

    public ArrayList GetBlenderizeItemData()
    {
        ArrayList arrData = new ArrayList();
        DataTable dt = (DataTable)System.Web.HttpContext.Current.Session[sessionBlenderizeItem];
        if (dt != null)
        {
            for (int i = 0; i < dt.Rows.Count; ++i)
            {
                FormularFeedItemData BlenderizeItem = new FormularFeedItemData();
                BlenderizeItem.ENERGY = Convert.ToDouble(dt.Rows[i]["ENERGY"]);
                BlenderizeItem.FORMULAFEED = Convert.ToDouble(dt.Rows[i]["FORMULAFEED"]);
                BlenderizeItem.LOID = Convert.ToDouble(dt.Rows[i]["LOID"]);
                BlenderizeItem.MATERIALMASTER = Convert.ToDouble(dt.Rows[i]["MATERIALMASTER"]);
               // BlenderizeItem.PREPARENAME = dt.Rows[i]["PREPARENAME"].ToString();
               // BlenderizeItem.REFFORMULA = 0;
                BlenderizeItem.QTY = Convert.ToDouble(dt.Rows[i]["QTY"]);
                BlenderizeItem.UNIT = Convert.ToDouble(dt.Rows[i]["UNIT"]);
                arrData.Add(BlenderizeItem);
            }
        }
        return arrData;
    }
    

    public string getMaterialList()
    {
        string materialList = "";
        DataTable dt = (DataTable)System.Web.HttpContext.Current.Session[sessionBlenderizeItem];
        if (dt != null)
        {
            for (int i = 0; i < dt.Rows.Count; ++i)
            {
                materialList += (materialList == "" ? "" : ",") + dt.Rows[i]["MATERIALMASTER"].ToString();
            }
        }
        return materialList;
    }

    [System.ComponentModel.DataObjectMethodAttribute(System.ComponentModel.DataObjectMethodType.Select, true)]
    public DataTable GetBlenderizeItemList(double formulaFeedID)
    {
        if (System.Web.HttpContext.Current.Session[sessionBlenderizeItem] == null)
        {
            BlenderizeDietFlow Formula = new BlenderizeDietFlow();
            System.Web.HttpContext.Current.Session[sessionBlenderizeItem] = Formula.GetBlenderizeItemList(formulaFeedID);
        }
        return (DataTable)System.Web.HttpContext.Current.Session[sessionBlenderizeItem];
    }

    public string VerifyData(double materialMaster, double qty)
    {
        string ret = "";
        if (materialMaster == 0)
            ret = string.Format(DataResources.MSGEI002, "ส่วนผสม");
        else if (qty == 0)
            ret = string.Format(DataResources.MSGEI001, "น้ำหนักสุก");

        return ret;
    }

    public bool InsertFormulaFeedItem(double formulaFeedID, ArrayList arrData)
    {
        bool ret = true;
        try
        {
            DataTable dt = GetBlenderizeItemList(formulaFeedID);
            for (int i = 0; i < arrData.Count; ++i)
            {
                VMaterialMasterData VMaterialMaster = (VMaterialMasterData)arrData[i];
                if (dt.Select("MATERIALMASTER = " + VMaterialMaster.LOID.ToString()).Length == 0)
                {
                    DataRow dRow = dt.NewRow();
                    dRow["RANK"] = dt.Rows.Count + 1;
                    dRow["LOID"] = dt.Rows.Count + 1;
                    dRow["FORMULAFEED"] = formulaFeedID;
                    dRow["MATERIALMASTER"] = VMaterialMaster.LOID;
                    dRow["MATERIALNAME"] = VMaterialMaster.MATERIALNAME;
                    dRow["UNIT"] = VMaterialMaster.ULOID;
                    dRow["QTY"] = 0;
                    dRow["ENERGY"] = 0;
                    dRow["CARBOHYDRATE"] = 0;
                    dRow["PROTEIN"] = 0;
                    dRow["FAT"] = 0;
                    dRow["SODIUM"] = 0;
                    dRow["PHOSPHORUS"] = 0;
                    dRow["POTASSIUM"] = 0;
                    dRow["CALCIUM"] = 0;
                    dt.Rows.Add(dRow);
                }
            }
            System.Web.HttpContext.Current.Session[sessionBlenderizeItem] = dt;
        }
        catch (Exception ex)
        {
            ex.ToString();
            ret = false;
        }
        return ret;
    }

    public bool UpdateFormulaFeedItem(double formulaFeedID, ArrayList arrData)
    {
        bool ret = true;
        try
        {
            DataTable dt = GetBlenderizeItemList(formulaFeedID);
            for (int i = 0; i < arrData.Count; ++i)
            {
                FormularFeedItemData FormulaFeedItem = (FormularFeedItemData)arrData[i];
                DataRow[] dRows = dt.Select("MATERIALMASTER = " + FormulaFeedItem.MATERIALMASTER.ToString());
                if (dRows.Length == 1)
                {
                    dRows[0]["QTY"] = FormulaFeedItem.QTY;
                    dRows[0]["UNIT"] = FormulaFeedItem.UNIT;
                    dRows[0]["ENERGY"] = FormulaFeedItem.ENERGY;
                    dRows[0]["CARBOHYDRATE"] = FormulaFeedItem.CARBOHYDRATE;
                    dRows[0]["PROTEIN"] = FormulaFeedItem.PROTEIN;
                    dRows[0]["FAT"] = FormulaFeedItem.FAT;
                    dRows[0]["SODIUM"] = FormulaFeedItem.SODIUM;
                }
            }
            System.Web.HttpContext.Current.Session[sessionBlenderizeItem] = dt;
        }
        catch (Exception ex)
        {
            ex.ToString();
            ret = false;
        }
        return ret;
    }


    public bool DeleteFormulaFeedItem(ArrayList arrData)
    {
        bool ret = true;
        try
        {
            DataTable dt = (DataTable)System.Web.HttpContext.Current.Session[sessionBlenderizeItem];
            for (int i = 0; i < arrData.Count; ++i)
            {
                DataRow[] dRow = dt.Select("RANK = " + arrData[i].ToString());
                if (dRow.Length == 1)
                {
                    dt.Rows.Remove(dRow[0]);
                }
            }
            ReOrder(dt, "RANK");
            System.Web.HttpContext.Current.Session[sessionBlenderizeItem] = dt;
        }
        catch (Exception ex)
        {
            ex.ToString();
            ret = false;
        }
        return ret;
    }

    #endregion


    #region FormulaDisease

    public ArrayList GetformulaFeedDiseaseData()
    {
        ArrayList arrData = new ArrayList();
        DataTable dt = (DataTable)System.Web.HttpContext.Current.Session[sessionFormulaDisease];
        if (dt != null)
        {
            for (int i = 0; i < dt.Rows.Count; ++i)
            {
                FormulaDiseaseData FormulaDisease = new FormulaDiseaseData();
                FormulaDisease.DISEASECATEGORY = Convert.ToDouble(dt.Rows[i]["DISEASECATEGORY"]);
                FormulaDisease.REFLOID = Convert.ToDouble(dt.Rows[i]["REFLOID"]);
                FormulaDisease.REFTABLE = "FORMULAFEED";
                FormulaDisease.ISHIGH = dt.Rows[i]["ISHIGH"].ToString();
                FormulaDisease.ISLOW = dt.Rows[i]["ISLOW"].ToString();
                FormulaDisease.ISNON = dt.Rows[i]["ISNON"].ToString();
                arrData.Add(FormulaDisease);
            }
        }
        return arrData;
    }

    public string GetDiseaseCategoryList()
    {
        string diseaseCategoryList = "";
        DataTable dt = (DataTable)System.Web.HttpContext.Current.Session[sessionFormulaDisease];
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
    public DataTable GetFormulaDiseaseList(double formulaFeedID)
    {
        if (System.Web.HttpContext.Current.Session[sessionFormulaDisease] == null)
        {
            BlenderizeDietFlow Formula = new BlenderizeDietFlow();
            System.Web.HttpContext.Current.Session[sessionFormulaDisease] = Formula.GetFormulaDiseaseList(formulaFeedID);
        }
        return (DataTable)System.Web.HttpContext.Current.Session[sessionFormulaDisease];
    }

    public bool InsertFormulaDisease(double formulaFeedID, ArrayList arrData)
    {
        bool ret = true;
        try
        {
            DataTable dt = GetFormulaDiseaseList(formulaFeedID);
            for (int i = 0; i < arrData.Count; ++i)
            {
                VDiseaseCategoryData VDiseaseCategory = (VDiseaseCategoryData)arrData[i];
                if (dt.Select("DISEASECATEGORY = " + VDiseaseCategory.LOID.ToString()).Length == 0)
                {
                    BlenderizeDietFlow ftFlow = new BlenderizeDietFlow();
                    DataTable dtDC = ftFlow.GetDiseaseCategoryByLOID(VDiseaseCategory.LOID.ToString());

                    DataRow dRow = dt.NewRow();
                    dRow["LOID"] = dt.Rows.Count + 1;
                    dRow["DISEASECATEGORY"] = VDiseaseCategory.LOID;
                    dRow["REFLOID"] = formulaFeedID;
                    dRow["NAME"] = VDiseaseCategory.ABBNAME;
                    dRow["ISHIGH"] = VDiseaseCategory.ISHIGH;
                    dRow["ISLOW"] = VDiseaseCategory.ISLOW;
                    dRow["ISNON"] = VDiseaseCategory.ISNON;
                    dRow["ISHIGHVISIBLE"] = (dtDC.Rows[0]["ISHIGH"] != null ? dtDC.Rows[0]["ISHIGH"].ToString() : "");
                    dRow["ISLOWVISIBLE"] = (dtDC.Rows[0]["ISLOW"] != null ? dtDC.Rows[0]["ISLOW"].ToString() : "");
                    dRow["ISNONVISIBLE"] = (dtDC.Rows[0]["ISNON"] != null ? dtDC.Rows[0]["ISNON"].ToString() : "");

                    dt.Rows.Add(dRow);
                }
            }
            System.Web.HttpContext.Current.Session[sessionFormulaDisease] = dt;
        }
        catch (Exception ex)
        {
            ex.ToString();
            ret = false;
        }
        return ret;
    }

    public bool DeleteFormulaDisease(ArrayList arrData)
    {
        bool ret = true;
        try
        {
            DataTable dt = (DataTable)System.Web.HttpContext.Current.Session[sessionFormulaDisease];
            for (int i = 0; i < arrData.Count; ++i)
            {
                DataRow[] dRow = dt.Select("LOID = " + arrData[i].ToString());
                if (dRow.Length == 1)
                {
                    dt.Rows.Remove(dRow[0]);
                }
            }
            ReOrder(dt, "LOID");
            System.Web.HttpContext.Current.Session[sessionFormulaDisease] = dt;
        }
        catch (Exception ex)
        {
            ex.ToString();
            ret = false;
        }
        return ret;
    }

    #endregion

    #region formulaFeedNutrient

    [System.ComponentModel.DataObjectMethodAttribute(System.ComponentModel.DataObjectMethodType.Select, true)]
    public DataTable GetFormulaNutrientList(double formulaFeedID)
    {
        BlenderizeDietFlow Formula = new BlenderizeDietFlow();
        return Formula.GetFormulaNutrientList(formulaFeedID);
    }

    #endregion

}
