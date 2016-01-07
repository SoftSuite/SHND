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
/// Summary description for FormulaSetDetailItem
/// </summary>
public class FormulaSetDetailItem
{
    private string sessionFormulaSetItem = "FormulaSetItem";
    private string sessionRefFormulaSet = "RefFormulaSet";
    private string sessionRefFormulaSetItem = "RefFormulaSetItem";
    private string sessionFormulaServe = "FormulaServe";
    private string sessionFormulaDisease = "FormulaDisease";
    private double totalRefEnergy = 0;
    private double totalRefWeightFormula = 0;

    public FormulaSetDetailItem()
    {
        //
        // TODO: Add constructor logic here
        //
    }

    public double TotalRefEnergy
    {
        get { return totalRefEnergy; }
    }
    public double TotalRefWeightRipe
    {
        get { return totalRefWeightFormula; }
    }

    public void ClearAllSession()
    {
        ClearFormulaSetItem();
        ClearRefFormulaSet();
        ClearFormulaServe();
        ClearFormulaDisease();
    }

    public void ClearFormulaSetItem()
    {
        System.Web.HttpContext.Current.Session[sessionFormulaSetItem] = null;
    }

    public void ClearRefFormulaSet()
    {
        System.Web.HttpContext.Current.Session[sessionRefFormulaSet] = null;
        System.Web.HttpContext.Current.Session[sessionRefFormulaSetItem] = null;
    }

    public void DeleteRefFormulaSet()
    {
        if (System.Web.HttpContext.Current.Session[sessionRefFormulaSet] != null) ((DataTable)System.Web.HttpContext.Current.Session[sessionRefFormulaSet]).Rows.Clear();
        if (System.Web.HttpContext.Current.Session[sessionRefFormulaSetItem] != null) ((DataTable)System.Web.HttpContext.Current.Session[sessionRefFormulaSetItem]).Rows.Clear();
    }

    public void ClearFormulaServe()
    {
        System.Web.HttpContext.Current.Session[sessionFormulaServe] = null;
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

    #region FormulaSetItem

    public ArrayList GetFormulasetItemData()
    {
        ArrayList arrData = new ArrayList();
        DataTable dt = (DataTable)System.Web.HttpContext.Current.Session[sessionFormulaSetItem];
        if (dt != null)
        {
            for (int i = 0; i < dt.Rows.Count; ++i)
            {
                FormulaSetItemData FormulaSetItem = new FormulaSetItemData();
                FormulaSetItem.ENERGY = Convert.ToDouble(dt.Rows[i]["ENERGY"]);
                FormulaSetItem.FORMULASET = Convert.ToDouble(dt.Rows[i]["FORMULASET"]);
                FormulaSetItem.LOID = Convert.ToDouble(dt.Rows[i]["LOID"]);
                FormulaSetItem.MATERIALMASTER = Convert.ToDouble(dt.Rows[i]["MATERIALMASTER"]);
                FormulaSetItem.PREPARENAME = dt.Rows[i]["PREPARENAME"].ToString();
                FormulaSetItem.REFFORMULA = 0;
                FormulaSetItem.WEIGHT = Convert.ToDouble(dt.Rows[i]["WEIGHT"]);
                FormulaSetItem.WEIGHTRAW = Convert.ToDouble(dt.Rows[i]["WEIGHTRAW"]);
                FormulaSetItem.WEIGHTRIPE = Convert.ToDouble(dt.Rows[i]["WEIGHTRIPE"]);
                arrData.Add(FormulaSetItem);
            }
        }
        return arrData;
    }

    public string getMaterialList()
    {
        string materialList = "";
        DataTable dt = (DataTable)System.Web.HttpContext.Current.Session[sessionFormulaSetItem];
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
    public DataTable GetFormulaSetItemList(double formulaSetID)
    {
        if (System.Web.HttpContext.Current.Session[sessionFormulaSetItem] == null)
        {
            FormulaSetFlow Formula = new FormulaSetFlow();
            System.Web.HttpContext.Current.Session[sessionFormulaSetItem] = Formula.GetFormulaSetItemList(formulaSetID);
        }
        return (DataTable)System.Web.HttpContext.Current.Session[sessionFormulaSetItem];
    }

    public bool InsertFormulaSetItem(double formulaSetID, ArrayList arrData)
    {
        bool ret = true;
        try
        {
            DataTable dt = GetFormulaSetItemList(formulaSetID);
            for (int i = 0; i < arrData.Count; ++i)
            {
                VMaterialMasterData VMaterialMaster = (VMaterialMasterData)arrData[i];
                if (dt.Select("MATERIALMASTER = " + VMaterialMaster.LOID.ToString()).Length == 0)
                {
                    DataRow dRow = dt.NewRow();
                    dRow["RANK"] = dt.Rows.Count + 1;
                    dRow["LOID"] = dt.Rows.Count + 1;
                    dRow["FORMULASET"] = formulaSetID;
                    dRow["MATERIALMASTER"] = VMaterialMaster.LOID;
                    dRow["PREPARENAME"] = VMaterialMaster.MATERIALNAME;
                    dRow["WEIGHT"] = 0;
                    dRow["WEIGHTRIPE"] = 0;
                    dRow["WEIGHTRAW"] = 0;
                    dRow["ENERGY"] = VMaterialMaster.ENERGYBYUNIT;
                    dRow["REFFORMULA"] = 0;
                    dRow["MATERIALNAME"] = VMaterialMaster.MATERIALNAME;
                    dRow["CARBOHYDRATE"] = VMaterialMaster.CARBOHYDRATE;
                    dRow["PROTEIN"] = VMaterialMaster.PROTEIN;
                    dRow["FAT"] = VMaterialMaster.FAT;
                    dRow["SODIUM"] = VMaterialMaster.SODIUM;
                    dRow["MATERIALWEIGHT"] = VMaterialMaster.WEIGHT;
                    dRow["WEIGHTCOOK"] = VMaterialMaster.WEIGHTCOOK;
                    dRow["PHOSPHORUS"] = VMaterialMaster.PHOSPHORUS;
                    dRow["POTASSIUM"] = VMaterialMaster.POTASSIUM;
                    dRow["CALCIUM"] = VMaterialMaster.CALCIUM;
                    dt.Rows.Add(dRow);
                }
            }
            System.Web.HttpContext.Current.Session[sessionFormulaSetItem] = dt;
        }
        catch (Exception ex)
        {
            ex.ToString();
            ret = false;
        }
        return ret;
    }

    public bool UpdateFormulaSetItem(double formulaSetID, ArrayList arrData)
    {
        bool ret = true;
        try
        {
            DataTable dt = GetFormulaSetItemList(formulaSetID);
            for (int i = 0; i < arrData.Count; ++i)
            {
                FormulaSetItemData FormulaSetItem = (FormulaSetItemData)arrData[i];
                DataRow[] dRows = dt.Select("MATERIALMASTER = " + FormulaSetItem.MATERIALMASTER.ToString());
                if (dRows.Length == 1)
                {
                    dRows[0]["PREPARENAME"] = FormulaSetItem.PREPARENAME;
                    dRows[0]["WEIGHT"] = FormulaSetItem.WEIGHT;
                    dRows[0]["WEIGHTRIPE"] = FormulaSetItem.WEIGHTRIPE;
                    dRows[0]["WEIGHTRAW"] = FormulaSetItem.WEIGHTRAW;
                }
            }
            System.Web.HttpContext.Current.Session[sessionFormulaSetItem] = dt;
        }
        catch (Exception ex)
        {
            ex.ToString();
            ret = false;
        }
        return ret;
    }

    public bool UpdateRefFormulaSetItem(double formulaSetID,double portion, ArrayList arrData)
    {
        bool ret = true;
        try
        {
            DataTable dt = (DataTable)System.Web.HttpContext.Current.Session[sessionRefFormulaSetItem];
            for (int i = 0; i < arrData.Count; ++i)
            {
                FormulaSetItemData FormulaSetItem = (FormulaSetItemData)arrData[i];
                DataRow[] dRows = dt.Select("MATERIALMASTER = " + FormulaSetItem.MATERIALMASTER.ToString());
                if (dRows.Length == 1)
                {
                    dRows[0]["WEIGHT"] = Convert.ToDouble(FormulaSetItem.WEIGHT1) * portion;
                    dRows[0]["WEIGHTRIPE"] = Convert.ToDouble(FormulaSetItem.WEIGHTRIPE1) * portion;
                    dRows[0]["WEIGHTRAW"] = Convert.ToDouble(FormulaSetItem.WEIGHTRAW1) * portion;
                    dRows[0]["ENERGY"] = Convert.ToDouble(FormulaSetItem.ENERGY1) * portion;

                }
            }
            System.Web.HttpContext.Current.Session[sessionRefFormulaSetItem] = dt;
        }
        catch (Exception ex)
        {
            ex.ToString();
            ret = false;
        }
        return ret;
    }

    public bool DeleteFormulaSetItem(ArrayList arrData)
    {
        bool ret = true;
        try
        {
            DataTable dt = (DataTable)System.Web.HttpContext.Current.Session[sessionFormulaSetItem];
            for (int i = 0; i < arrData.Count; ++i)
            {
                DataRow[] dRow = dt.Select("RANK = " + arrData[i].ToString());
                if (dRow.Length == 1)
                {
                    dt.Rows.Remove(dRow[0]);
                }
            }
            ReOrder(dt, "RANK");
            System.Web.HttpContext.Current.Session[sessionFormulaSetItem] = dt;
        }
        catch (Exception ex)
        {
            ex.ToString();
            ret = false;
        }
        return ret;
    }

    #endregion

    #region RefFormulaSet & Item

    public string GetRefFormulaList()
    {
        string refFormulaList = "";
        DataTable dt = (DataTable)System.Web.HttpContext.Current.Session[sessionRefFormulaSetItem];
        if (dt != null)
        {
            for (int i = 0; i < dt.Rows.Count; ++i)
            {
                refFormulaList += (refFormulaList == "" ? "" : ",") + dt.Rows[i]["REFFORMULA"].ToString();
            }
        }
        return refFormulaList;
    }

    public ArrayList GetRefFormulasetItemData()
    {
        ArrayList arrData = new ArrayList();
        DataTable dt = (DataTable)System.Web.HttpContext.Current.Session[sessionRefFormulaSetItem];
        if (dt != null)
        {
            for (int i = 0; i < dt.Rows.Count; ++i)
            {
                FormulaSetItemData FormulaSetItem = new FormulaSetItemData();
                FormulaSetItem.ENERGY = Convert.ToDouble(dt.Rows[i]["ENERGY"]);
                FormulaSetItem.FORMULASET = Convert.ToDouble(dt.Rows[i]["FORMULASET"]);
                //FormulaSetItem.LOID = Convert.ToDouble(dt.Rows[i]["LOID"]);
                FormulaSetItem.MATERIALMASTER = Convert.ToDouble(dt.Rows[i]["MATERIALMASTER"]);
                FormulaSetItem.PREPARENAME = dt.Rows[i]["PREPARENAME"].ToString();
                FormulaSetItem.REFFORMULA = Convert.ToDouble(dt.Rows[i]["REFFORMULA"]);
                FormulaSetItem.WEIGHT = Convert.ToDouble(dt.Rows[i]["WEIGHT"]);
                FormulaSetItem.WEIGHTRAW = Convert.ToDouble(dt.Rows[i]["WEIGHTRAW"]);
                FormulaSetItem.WEIGHTRIPE = Convert.ToDouble(dt.Rows[i]["WEIGHTRIPE"]);
                FormulaSetItem.WEIGHT1 = Convert.ToDouble(dt.Rows[i]["WEIGHT1"]);
                FormulaSetItem.WEIGHTRIPE1 = Convert.ToDouble(dt.Rows[i]["WEIGHTRIPE1"]);
                FormulaSetItem.WEIGHTRAW1 = Convert.ToDouble(dt.Rows[i]["WEIGHTRAW1"]);
                FormulaSetItem.ENERGY1 = Convert.ToDouble(dt.Rows[i]["ENERGY1"]);
                arrData.Add(FormulaSetItem);
                totalRefEnergy += FormulaSetItem.ENERGY;
                totalRefWeightFormula += FormulaSetItem.WEIGHTRIPE;
            }
        }
        return arrData;
    }

    [System.ComponentModel.DataObjectMethodAttribute(System.ComponentModel.DataObjectMethodType.Select, true)]
    public DataTable GetRefFormulaSetList(double formulaSetID)
    {
        if (System.Web.HttpContext.Current.Session[sessionRefFormulaSet] == null)
        {
            FormulaSetFlow Formula = new FormulaSetFlow();
            System.Web.HttpContext.Current.Session[sessionRefFormulaSet] = Formula.GetRefFormulaSetList(formulaSetID);
        }
        return (DataTable)System.Web.HttpContext.Current.Session[sessionRefFormulaSet];
    }

    public DataTable GetRefFormulaSetItemList(double formulaSetID, double refFormulaSetID)
    {
        if (System.Web.HttpContext.Current.Session[sessionRefFormulaSetItem] == null)
        {
            FormulaSetFlow Formula = new FormulaSetFlow();
            System.Web.HttpContext.Current.Session[sessionRefFormulaSetItem] = Formula.GetRefFormulaSetItemList(formulaSetID);
        }
        DataTable dt = ((DataTable)System.Web.HttpContext.Current.Session[sessionRefFormulaSetItem]);
        DataTable dtTemp = dt.Clone();
        DataRow[] dRows = ((DataTable)System.Web.HttpContext.Current.Session[sessionRefFormulaSetItem]).Select("REFFORMULA = " + refFormulaSetID.ToString());
        for (int i = 0; i < dRows.Length; ++i)
        {
            DataRow dRow = dtTemp.NewRow();
            dRow["FORMULASET"] = dRows[i]["FORMULASET"];
            dRow["MATERIALMASTER"] = dRows[i]["MATERIALMASTER"];
            dRow["PREPARENAME"] = dRows[i]["PREPARENAME"];
            dRow["WEIGHT"] = dRows[i]["WEIGHT"];
            dRow["WEIGHTRIPE"] = dRows[i]["WEIGHTRIPE"];
            dRow["WEIGHTRAW"] = dRows[i]["WEIGHTRAW"];
            dRow["ENERGY"] = dRows[i]["ENERGY"];
            dRow["REFFORMULA"] = refFormulaSetID;
            dRow["MATERIALNAME"] = dRows[i]["MATERIALNAME"];
            dRow["CARBOHYDRATE"] = dRows[i]["CARBOHYDRATE"];
            dRow["PROTEIN"] = dRows[i]["PROTEIN"];
            dRow["FAT"] = dRows[i]["FAT"];
            dRow["SODIUM"] = dRows[i]["SODIUM"];
            dRow["PHOSPHORUS"] = dRows[i]["PHOSPHORUS"];
            dRow["POTASSIUM"] = dRows[i]["POTASSIUM"];
            dRow["CALCIUM"] = dRows[i]["CALCIUM"];
            dRow["REFORMULASETNAME"] = dRows[i]["REFORMULASETNAME"];
            dRow["WEIGHT1"] = dRows[i]["WEIGHT1"];
            dRow["WEIGHTRIPE1"] = dRows[i]["WEIGHTRIPE1"];
            dRow["WEIGHTRAW1"] = dRows[i]["WEIGHTRAW1"];
            dRow["ENERGY1"] = dRows[i]["ENERGY1"];
            dtTemp.Rows.Add(dRow);
        }
        return dtTemp;
    }

    public bool InsertRefFormulaSet(double formulaSetID, double portion, ArrayList arrData)
    {
        bool ret = true;
        try
        {
            DataTable dt = GetRefFormulaSetList(formulaSetID);
            DataTable dtTemp;
            FormulaSetFlow Formula = new FormulaSetFlow();
            if (System.Web.HttpContext.Current.Session[sessionRefFormulaSetItem] == null)
                dtTemp = Formula.GetRefFormulaSetItemList(formulaSetID);
            else
                dtTemp = (DataTable)System.Web.HttpContext.Current.Session[sessionRefFormulaSetItem];

            for (int i = 0; i < arrData.Count; ++i)
            {
                VFormulaSetSearchData VFormulaSetSearch = (VFormulaSetSearchData)arrData[i];
                if (dt.Select("REFFORMULA = " + VFormulaSetSearch.LOID.ToString()).Length == 0)
                {
                    DataRow dRow = dt.NewRow();
                    dRow["RANK"] = dt.Rows.Count + 1;
                    dRow["FORMULASET"] = formulaSetID;
                    dRow["REFFORMULA"] = VFormulaSetSearch.LOID;
                    dRow["REFORMULASETNAME"] = VFormulaSetSearch.FORMULANAME;
                    dt.Rows.Add(dRow);
                    System.Web.HttpContext.Current.Session[sessionRefFormulaSet] = dt;

                    DataTable dt1 = Formula.GetFormulaSetItemList(VFormulaSetSearch.LOID);
                    for (int k = 0; k < dt1.Rows.Count; ++k)
                    {
                        dRow = dtTemp.NewRow();
                        dRow["FORMULASET"] = dt1.Rows[k]["FORMULASET"];
                        dRow["MATERIALMASTER"] = dt1.Rows[k]["MATERIALMASTER"];
                        dRow["PREPARENAME"] = dt1.Rows[k]["PREPARENAME"];
                        dRow["WEIGHT"] = Convert.ToDouble(dt1.Rows[k]["WEIGHT"]) * portion / VFormulaSetSearch.PORTION;
                        dRow["WEIGHTRIPE"] = Convert.ToDouble(dt1.Rows[k]["WEIGHTRIPE"])*portion / VFormulaSetSearch.PORTION;
                        dRow["WEIGHTRAW"] = Convert.ToDouble(dt1.Rows[k]["WEIGHTRAW"]) * portion / VFormulaSetSearch.PORTION;
                        dRow["ENERGY"] = Convert.ToDouble(dt1.Rows[k]["ENERGY"]) * portion / VFormulaSetSearch.PORTION;
                        dRow["REFFORMULA"] = VFormulaSetSearch.LOID;
                        dRow["MATERIALNAME"] = dt1.Rows[k]["MATERIALNAME"];
                        dRow["CARBOHYDRATE"] = dt1.Rows[k]["CARBOHYDRATE"];
                        dRow["PROTEIN"] = dt1.Rows[k]["PROTEIN"];
                        dRow["FAT"] = dt1.Rows[k]["FAT"];
                        dRow["SODIUM"] = dt1.Rows[k]["SODIUM"];
                        dRow["PHOSPHORUS"] = dt1.Rows[k]["PHOSPHORUS"];
                        dRow["POTASSIUM"] = dt1.Rows[k]["POTASSIUM"];
                        dRow["CALCIUM"] = dt1.Rows[k]["CALCIUM"];
                        dRow["REFORMULASETNAME"] = VFormulaSetSearch.FORMULANAME;
                        dRow["WEIGHT1"] = Convert.ToDouble(dt1.Rows[k]["WEIGHT"])/ VFormulaSetSearch.PORTION;
                        dRow["WEIGHTRIPE1"] = Convert.ToDouble(dt1.Rows[k]["WEIGHTRIPE"])/ VFormulaSetSearch.PORTION;
                        dRow["WEIGHTRAW1"] = Convert.ToDouble(dt1.Rows[k]["WEIGHTRAW"]) / VFormulaSetSearch.PORTION;
                        dRow["ENERGY1"] = Convert.ToDouble(dt1.Rows[k]["ENERGY"]) / VFormulaSetSearch.PORTION;


                        dtTemp.Rows.Add(dRow);
                    }
                }
            }
            System.Web.HttpContext.Current.Session[sessionRefFormulaSetItem] = dtTemp;
        }
        catch (Exception ex)
        {
            ex.ToString();
            ret = false;
        }
        return ret;
    }

    public bool DeleteRefFormulaSet(ArrayList arrData)
    {
        bool ret = true;
        try
        {
            DataTable dt = (DataTable)System.Web.HttpContext.Current.Session[sessionRefFormulaSet];
            DataTable dtTemp = (DataTable)System.Web.HttpContext.Current.Session[sessionRefFormulaSetItem];
            for (int i = 0; i < arrData.Count; ++i)
            {
                double rank = Convert.ToDouble(arrData[i]);
                double refFormulaSetID = 0;
                DataRow[] dRow = dt.Select("RANK = " + rank.ToString());
                if (dRow.Length == 1)
                {
                    refFormulaSetID = Convert.ToDouble(dRow[0]["REFFORMULA"]);
                    dt.Rows.Remove(dRow[0]);

                    dRow = dtTemp.Select("REFFORMULA = " + refFormulaSetID.ToString());
                    for (int k = 0; k < dRow.Length; ++k)
                    {
                        dtTemp.Rows.Remove(dRow[k]);
                    }
                }
            }
            ReOrder(dt, "RANK");
            System.Web.HttpContext.Current.Session[sessionRefFormulaSet] = dt;
            System.Web.HttpContext.Current.Session[sessionRefFormulaSetItem] = dtTemp;
        }
        catch (Exception ex)
        {
            ex.ToString();
            ret = false;
        }
        return ret;
    }

    #endregion

    #region FormulaServe

    [System.ComponentModel.DataObjectMethodAttribute(System.ComponentModel.DataObjectMethodType.Select, true)]
    public DataTable GetFormulaServeList(double formulaSetID)
    {
        if (System.Web.HttpContext.Current.Session[sessionFormulaServe] == null)
        {
            FormulaSetFlow Formula = new FormulaSetFlow();
            System.Web.HttpContext.Current.Session[sessionFormulaServe] = Formula.GetFormulaServeList(formulaSetID);
        }
        return (DataTable)System.Web.HttpContext.Current.Session[sessionFormulaServe];
    }

    public bool InsertFormulaServe(FormulaServeData formulaServe)
    {
        bool ret = true;
        DataTable dt = GetFormulaServeList(formulaServe.FORMULASET);
        if (dt.Select("NAME = '" + formulaServe.NAME + "' ").Length == 0)
        {
            DataRow dRow = dt.NewRow();
            dRow["RANK"] = dt.Rows.Count + 1;
            dRow["NAME"] = formulaServe.NAME;
            dRow["FORMULASET"] = formulaServe.FORMULASET;
            dRow["WEIGHTRAW"] = formulaServe.WEIGHTRAW;
            dRow["WEIGHTRIPE"] = formulaServe.WEIGHTRIPE;
            dt.Rows.Add(dRow);
            System.Web.HttpContext.Current.Session[sessionFormulaServe] = dt;
        }
        else
        {
            ret = false;
            throw new ApplicationException(string.Format(DataResources.MSGEI015, "ส่วนผสม", formulaServe.NAME));
        }
        return ret;
    }

    public bool UpdateFormulaServe(FormulaServeData formulaServe)
    {
        bool ret = true;
        DataTable dt = GetFormulaServeList(formulaServe.FORMULASET);
        int length = dt.Select("NAME = '" + formulaServe.NAME + "' AND RANK <> " + formulaServe.LOID.ToString()).Length;
        if (length == 0)
        {
            DataRow[] dRow = dt.Select("RANK = " + formulaServe.LOID.ToString());
            if (dRow.Length == 1)
            {
                dRow[0]["NAME"] = formulaServe.NAME;
                dRow[0]["WEIGHTRAW"] = formulaServe.WEIGHTRAW;
                dRow[0]["WEIGHTRIPE"] = formulaServe.WEIGHTRIPE;
                System.Web.HttpContext.Current.Session[sessionFormulaServe] = dt;
            }
        }
        else if (length > 0)
        {
            ret = false;
            throw new ApplicationException(string.Format(DataResources.MSGEI015, "ส่วนผสม", formulaServe.NAME));
        }
        return ret;
    }

    public bool DeleteFormulaServe(ArrayList arrData)
    {
        bool ret = true;
        try
        {
            DataTable dt = (DataTable)System.Web.HttpContext.Current.Session[sessionFormulaServe];
            for (int i = 0; i < arrData.Count; ++i)
            {
                DataRow[] dRow = dt.Select("RANK = " + arrData[i].ToString());
                if (dRow.Length == 1)
                {
                    dt.Rows.Remove(dRow[0]);
                }
            }
            ReOrder(dt, "RANK");
            System.Web.HttpContext.Current.Session[sessionFormulaServe] = dt;
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

    //public ArrayList GetFormulasetDiseaseData()
    //{
    //    ArrayList arrData = new ArrayList();
    //    DataTable dt = (DataTable)System.Web.HttpContext.Current.Session[sessionFormulaDisease];
    //    if (dt != null)
    //    {
    //        for (int i = 0; i < dt.Rows.Count; ++i)
    //        {
    //            FormulaDiseaseData FormulaDisease = new FormulaDiseaseData();
    //            FormulaDisease.DISEASECATEGORY = Convert.ToDouble(dt.Rows[i]["DISEASECATEGORY"]);
    //            FormulaDisease.REFLOID = Convert.ToDouble(dt.Rows[i]["REFLOID"]);
    //            FormulaDisease.REFTABLE = "FORMULASET";
    //            FormulaDisease.ISHIGH = dt.Rows[i]["ISHIGH"].ToString();
    //            FormulaDisease.ISLOW = dt.Rows[i]["ISLOW"].ToString();
    //            FormulaDisease.ISNON = dt.Rows[i]["ISNON"].ToString();
    //            arrData.Add(FormulaDisease);
    //        }
    //    }
    //    return arrData;
    //}

    public void UpdateDiseaseCategory(ArrayList arrData)
    {
        DataTable dt = (DataTable)System.Web.HttpContext.Current.Session[sessionFormulaDisease];
        if (dt != null)
        {
            for (int i = 0; i < arrData.Count; ++i)
            {
                FormulaDiseaseData FormulaDisease = (FormulaDiseaseData)arrData[i];
                DataRow[] dRow = dt.Select("DISEASECATEGORY = " + FormulaDisease.DISEASECATEGORY.ToString());
                if (dRow.Length == 1)
                {
                    dRow[0]["ISHIGH"] = FormulaDisease.ISHIGH;
                    dRow[0]["ISLOW"] = FormulaDisease.ISLOW;
                    dRow[0]["ISNON"] = FormulaDisease.ISNON;
                }
            }
            System.Web.HttpContext.Current.Session[sessionFormulaDisease] = dt;
        }
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
    public DataTable GetFormulaDiseaseList(double formulaSetID)
    {
        if (System.Web.HttpContext.Current.Session[sessionFormulaDisease] == null)
        {
            FormulaSetFlow Formula = new FormulaSetFlow();
            System.Web.HttpContext.Current.Session[sessionFormulaDisease] = Formula.GetFormulaDiseaseList(formulaSetID);
        }
        return (DataTable)System.Web.HttpContext.Current.Session[sessionFormulaDisease];
    }

    public bool InsertFormulaDisease(double formulaSetID, ArrayList arrData)
    {
        bool ret = true;
        try
        {
            DataTable dt = GetFormulaDiseaseList(formulaSetID);
            for (int i = 0; i < arrData.Count; ++i)
            {
                VDiseaseCategoryData VDiseaseCategory = (VDiseaseCategoryData)arrData[i];
                if (dt.Select("DISEASECATEGORY = " + VDiseaseCategory.LOID.ToString()).Length == 0)
                {
                    DiseaseCategoryFlow dFlow = new DiseaseCategoryFlow();
                    DiseaseCategoryData dat = dFlow.GetDetails(VDiseaseCategory.LOID);
                    DataRow dRow = dt.NewRow();
                    dRow["LOID"] = dt.Rows.Count + 1;
                    dRow["DISEASECATEGORY"] = VDiseaseCategory.LOID;
                    dRow["REFLOID"] = formulaSetID;
                    dRow["NAME"] = VDiseaseCategory.ABBNAME;
                    dRow["ISHIGH"] = VDiseaseCategory.ISHIGH;
                    dRow["ISLOW"] = VDiseaseCategory.ISLOW;
                    dRow["ISNON"] = VDiseaseCategory.ISNON;
                    dRow["ISHIGHVISIBLE"] = (dat.ISHIGH ? "Y" : "N");
                    dRow["ISLOWVISIBLE"] = (dat.ISLOW ? "Y" : "N");
                    dRow["ISNONVISIBLE"] = (dat.ISNON ? "Y" : "N");
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

    #region FormulasetNutrient

    [System.ComponentModel.DataObjectMethodAttribute(System.ComponentModel.DataObjectMethodType.Select, true)]
    public DataTable GetFormulaNutrientList(double formulaSetID)
    {
        FormulaSetFlow Formula = new FormulaSetFlow();
        return Formula.GetFormulaNutrientList(formulaSetID);
    }

    #endregion

}
