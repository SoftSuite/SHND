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
using SHND.Data.Tables;
using SHND.Data.Views;
using SHND.Flow.Plan;

/// <summary>
/// Summary description for PlanFoodDetailItem
/// </summary>
public class PlanFoodDetailItem
{
    private string sessionPlanFood = "PlanFoodDetail";
    private string sessionOfficer = "PlanOrderCouncil";
    private string sessionMaterialDivision = "PlanMaterialDivision";
    private string _error = "";

    public string ErrorMessage
    {
        get { return _error; }
    }

    public PlanFoodDetailItem()
    {
        //
        // TODO: Add constructor logic here
        //
    }

    public void ClearAllSession()
    {
        ClearMaterial();
        ClearOfficer();
        ClearDetail();
    }

    public void ClearMaterial()
    {
        System.Web.HttpContext.Current.Session[sessionPlanFood] = null;
    }

    public void ClearOfficer()
    {
        System.Web.HttpContext.Current.Session[sessionOfficer] = null;
    }

    public void ClearDetail()
    {
        System.Web.HttpContext.Current.Session[sessionMaterialDivision] = null;
    }

    #region MaterialItem

    [System.ComponentModel.DataObjectMethodAttribute(System.ComponentModel.DataObjectMethodType.Select, true)]
    public DataTable GetMaterialItemList(double planOrderID)
    {
        if (System.Web.HttpContext.Current.Session[sessionPlanFood] == null)
        {
            PlanOrderFoodFlow fFlow = new PlanOrderFoodFlow();
            System.Web.HttpContext.Current.Session[sessionPlanFood] = fFlow.GetMaterialItemList(planOrderID);
        }
        return (DataTable)System.Web.HttpContext.Current.Session[sessionPlanFood];
    }

    public bool InsertMaterialItem(double planOrderID, ArrayList arrData)
    {
        bool ret = true;
        try
        {
            DataTable dt = GetMaterialItemList(planOrderID);
            for (int i = 0; i < arrData.Count; ++i)
            {
                VMaterialMasterUnitData VMaterialList = (VMaterialMasterUnitData)arrData[i];
                if (dt.Select("MATERIALMASTER = " + VMaterialList.LOID.ToString()).Length == 0)
                {
                    DataRow dRow = dt.NewRow();
                    dRow["MATERIALMASTER"] = VMaterialList.MATERIALMASTER;
                    dRow["PLANORDER"] = planOrderID;
                    dRow["SPEC"] = VMaterialList.SPEC;
                    dRow["ISVAT"] = "Y";
                    dRow["UNIT"] = VMaterialList.UNIT;
                    dRow["SAPCODE"] = VMaterialList.SAPCODE;
                    dRow["MATERIALNAME"] = VMaterialList.MATERIALNAME;
                    dRow["UNITNAME"] = VMaterialList.UNITNAME;
                    dRow["CLASSNAME"] = VMaterialList.CLASSNAME;
                    dRow["CLASSLOID"] = VMaterialList.CLASSLOID;
                    dRow["STATUS"] = "WA";
                    dRow["PRICE"] = VMaterialList.COST;
                    dRow["PLANQTY"] = 0;
                    dRow["TOTALPRICE"] = 0;
                    dRow["MENUQTY"] = 0;
                    dRow["VAT"] = 0;
                    dt.Rows.Add(dRow);
                }
            }
            System.Web.HttpContext.Current.Session[sessionPlanFood] = dt;
        }
        catch (Exception ex)
        {
            _error = ex.Message;
            ret = false;
        }
        return ret;
    }

    public bool UpdateMaterialItem(double planOrderID, ArrayList arrData)
    {
        bool ret = true;
        try
        {
            DataTable dt = GetMaterialItemList(planOrderID);
            for (int i = 0; i < arrData.Count; ++i)
            {
                VPlanFoodMaterialData pData = (VPlanFoodMaterialData)arrData[i];
                DataRow[] dRows = dt.Select("MATERIALMASTER = " + pData.MATERIALMASTER.ToString());
                if (dRows.Length == 1)
                {
                    dRows[0]["SPEC"] = pData.SPEC;
                    dRows[0]["PRICE"] = pData.PRICE;
                    dRows[0]["VAT"] = (pData.ISVAT == "Y" ? (pData.PRICE*7/107) : 0);
                    dRows[0]["ISVAT"] = pData.ISVAT;
                    dRows[0]["PLANQTY"] = pData.PLANQTY;
                    dRows[0]["TOTALPRICE"] = pData.PLANQTY*pData.PRICE;
                }
            }
            System.Web.HttpContext.Current.Session[sessionPlanFood] = dt;
        }
        catch (Exception ex)
        {
            _error = ex.Message;
            ret = false;
        }
        return ret;
    }

    public bool DeleteMaterialItem(ArrayList arrData)
    {
        bool ret = true;
        try
        {
            DataTable dt = (DataTable)System.Web.HttpContext.Current.Session[sessionPlanFood];
            for (int i = 0; i < arrData.Count; ++i)
            {
                DataRow[] dRow = dt.Select("MATERIALMASTER = " + arrData[i].ToString());
                if (dRow.Length == 1)
                {
                    dt.Rows.Remove(dRow[0]);
                }
            }
            System.Web.HttpContext.Current.Session[sessionPlanFood] = dt;
        }
        catch (Exception ex)
        {
            _error = ex.Message;
            ret = false;
        }
        return ret;
    }

    #endregion

    #region Officer

    [System.ComponentModel.DataObjectMethodAttribute(System.ComponentModel.DataObjectMethodType.Select, true)]
    public DataTable GetOfficerList(double planOrderID)
    {
        if (System.Web.HttpContext.Current.Session[sessionOfficer] == null)
        {
            PlanOrderFoodFlow fFlow = new PlanOrderFoodFlow();
            System.Web.HttpContext.Current.Session[sessionOfficer] = fFlow.GetOfficerList(planOrderID);
        }
        return (DataTable)System.Web.HttpContext.Current.Session[sessionOfficer];
    }

    public bool InsertOfficer(double planOrderID, ArrayList arrData)
    {
        bool ret = true;
        try
        {
            DataTable dt = GetOfficerList(planOrderID);
            for (int i = 0; i < arrData.Count; ++i)
            {
                VOfficerData officer = (VOfficerData)arrData[i];
                if (dt.Select("OFFICER = " + officer.LOID.ToString()).Length == 0)
                {
                    DataRow dRow = dt.NewRow();
                    dRow["PLANORDER"] = planOrderID;
                    dRow["OFFICER"] = officer.LOID;
                    dRow["POSITION"] = "";
                    dRow["DIVISION"] = officer.DIVISION;
                    dRow["M1"] = "N";
                    dRow["M2"] = "N";
                    dRow["M3"] = "N";
                    dRow["M4"] = "N";
                    dRow["M5"] = "N";
                    dRow["M6"] = "N";
                    dRow["M7"] = "N";
                    dRow["M8"] = "N";
                    dRow["M9"] = "N";
                    dRow["M10"] = "N";
                    dRow["M11"] = "N";
                    dRow["M12"] = "N";
                    dRow["OFFICERNAME"] = officer.OFFICERNAME;
                    dRow["DIVISIONNAME"] = officer.DIVISIONNAME;
                    dRow["STATUS"] = "WA";
                    dt.Rows.Add(dRow);
                }
            }
            System.Web.HttpContext.Current.Session[sessionOfficer] = dt;
        }
        catch (Exception ex)
        {
            _error = ex.Message;
            ret = false;
        }
        return ret;
    }

    public bool UpdateOfficer(double planOrderID, ArrayList arrData)
    {
        bool ret = true;
        try
        {
            DataTable dt = GetOfficerList(planOrderID);
            for (int i = 0; i < arrData.Count; ++i)
            {
                PlanOrderCouncilData pData = (PlanOrderCouncilData)arrData[i];
                DataRow[] dRows = dt.Select("OFFICER = " + pData.OFFICER.ToString());
                if (dRows.Length == 1)
                {
                    dRows[0]["POSITION"] = pData.POSITION;
                    dRows[0]["M1"] = (pData.M1 ? "Y" : "N");
                    dRows[0]["M2"] = (pData.M2 ? "Y" : "N");
                    dRows[0]["M3"] = (pData.M3 ? "Y" : "N");
                    dRows[0]["M4"] = (pData.M4 ? "Y" : "N");
                    dRows[0]["M5"] = (pData.M5 ? "Y" : "N");
                    dRows[0]["M6"] = (pData.M6 ? "Y" : "N");
                    dRows[0]["M7"] = (pData.M7 ? "Y" : "N");
                    dRows[0]["M8"] = (pData.M8 ? "Y" : "N");
                    dRows[0]["M9"] = (pData.M9 ? "Y" : "N");
                    dRows[0]["M10"] = (pData.M10 ? "Y" : "N");
                    dRows[0]["M11"] = (pData.M11 ? "Y" : "N");
                    dRows[0]["M12"] = (pData.M12 ? "Y" : "N");
                }
            }
            System.Web.HttpContext.Current.Session[sessionOfficer] = dt;
        }
        catch (Exception ex)
        {
            _error = ex.Message;
            ret = false;
        }
        return ret;
    }

    public bool DeleteOfficer(ArrayList arrData)
    {
        bool ret = true;
        try
        {
            DataTable dt = (DataTable)System.Web.HttpContext.Current.Session[sessionOfficer];
            for (int i = 0; i < arrData.Count; ++i)
            {
                DataRow[] dRow = dt.Select("OFFICER = " + arrData[i].ToString());
                if (dRow.Length == 1)
                {
                    dt.Rows.Remove(dRow[0]);
                }
            }
            System.Web.HttpContext.Current.Session[sessionOfficer] = dt;
        }
        catch (Exception ex)
        {
            _error = ex.Message;
            ret = false;
        }
        return ret;
    }

    #endregion

    #region Detail

    public ArrayList GetMaterialDivisionData()
    {
        ArrayList arrData = new ArrayList();
        PlanMaterialDivisionData mData;
        DataTable dt = (DataTable)System.Web.HttpContext.Current.Session[sessionMaterialDivision];
        if (dt != null)
        {
            for (int i = 0; i < dt.Rows.Count; ++i)
            {
                DataRow dRow = dt.Rows[i];
                mData = new PlanMaterialDivisionData();
                mData.ADJQTY = Convert.ToDouble(dRow["ADJQTY"]);
                mData.DIVISION = Convert.ToDouble(dRow["DIVISION"]);
                mData.MENUQTY = Convert.ToDouble(dRow["MENUQTY"]);
                mData.PLANMATERIALITEM = Convert.ToDouble(dRow["PLANMATERIALITEM"]);
                mData.REQQTY = Convert.ToDouble(dRow["REQQTY"]);
                mData.STATUS = dRow["STATUS"].ToString();
                arrData.Add(mData);
            }
        }
        return arrData;
    }

    private DataTable GetMaterialDivisionLIst(double planOrderID)
    {
        if (System.Web.HttpContext.Current.Session[sessionMaterialDivision] == null)
        {
            PlanOrderFoodFlow fFlow = new PlanOrderFoodFlow();
            System.Web.HttpContext.Current.Session[sessionMaterialDivision] = fFlow.GetMaterialDivisionList(planOrderID);
        }
        return (DataTable)System.Web.HttpContext.Current.Session[sessionMaterialDivision];
    }

    [System.ComponentModel.DataObjectMethodAttribute(System.ComponentModel.DataObjectMethodType.Select, true)]
    public DataTable GetMaterialDivisionLIst(double planOrderID, double materialMaster)
    {
        PlanOrderFoodFlow fFlow = new PlanOrderFoodFlow();
        DataTable dt = fFlow.GetMaterialDivisionList(planOrderID, materialMaster);
        return dt;

        //DataTable dt = GetMaterialDivisionLIst(planOrderID);

        //DataTable dtTemp = dt.Clone();
        //DataRow[] dRows = dt.Select("MATERIALMASTER = " + materialMaster.ToString());

        //if (dRows != null)
        //{
        //    for (int i = 0; i < dRows.Length; ++i)
        //    {
        //        DataRow dRow = dtTemp.NewRow();
        //        dRow["LOID"] = Convert.ToDouble(dRows[i]["LOID"]);
        //        dRow["DIVISION"] = Convert.ToDouble(dRows[i]["DIVISION"]);
        //        dRow["PLANMATERIALITEM"] = Convert.ToDouble(dRows[i]["PLANMATERIALITEM"]);
        //        dRow["PLANORDER"] = Convert.ToDouble(dRows[i]["PLANORDER"]);
        //        dRow["PLANMATERIALCLASS"] = Convert.ToDouble(dRows[i]["PLANMATERIALCLASS"]);
        //        dRow["MENUQTY"] = Convert.ToDouble(dRows[i]["MENUQTY"]);
        //        dRow["REQQTY"] = Convert.ToDouble(dRows[i]["REQQTY"]);
        //        dRow["PLANQTY"] = Convert.ToDouble(dRows[i]["PLANQTY"]);
        //        dRow["ADJQTY"] = Convert.ToDouble(dRows[i]["ADJQTY"]);
        //        dRow["STATUS"] = dRows[i]["STATUS"].ToString();
        //        dRow["SPEC"] = dRows[i]["SPEC"].ToString();
        //        dRow["SAPCODE"] = dRows[i]["SAPCODE"].ToString();
        //        dRow["MATERIALNAME"] = dRows[i]["MATERIALNAME"].ToString();
        //        dRow["CLASSNAME"] = dRows[i]["CLASSNAME"].ToString();
        //        dRow["DIVISIONNAME"] = dRows[i]["DIVISIONNAME"].ToString();
        //        dRow["MATERIALMASTER"] = Convert.ToDouble(dRows[i]["MATERIALMASTER"]);

        //        dtTemp.Rows.Add(dRow);
        //    }
        //}
        //return dtTemp;
    }

    [System.ComponentModel.DataObjectMethodAttribute(System.ComponentModel.DataObjectMethodType.Select, true)]
    public bool UpdateMaterialDivision(double planOrderID, double MATERIALMASTER, double DIVISION, double ADJQTY, double PLANQTY, string STATUS)
    {
        bool ret = true;
        DataTable dt = GetMaterialDivisionLIst(planOrderID);
        DataRow[] dRows = dt.Select("MATERIALMASTER = " + MATERIALMASTER.ToString() + " AND DIVISION = " + DIVISION.ToString());
        if (dRows != null)
        {
            if (dRows.Length == 1)
            {
                dRows[0]["PLANQTY"] = ADJQTY;
                dRows[0]["ADJQTY"] = ADJQTY;
                System.Web.HttpContext.Current.Session[sessionMaterialDivision] = dt;
            }
        }
        return ret;
    }

    public bool UpdateMaterialDivision(double planOrderID, double MATERIALMASTER, double DIVISION, string STATUS)
    {
        bool ret = true;
        DataTable dt = GetMaterialDivisionLIst(planOrderID);
        DataRow[] dRows = dt.Select("MATERIALMASTER = " + MATERIALMASTER.ToString() + " AND DIVISION = " + DIVISION.ToString());
        if (dRows != null)
        {
            if (dRows.Length == 1)
            {
                dRows[0]["STATUS"] = STATUS;
                System.Web.HttpContext.Current.Session[sessionMaterialDivision] = dt;
            }
        }
        return ret;
    }

    public Hashtable GetAdjQty(double planOrderID, double adjPercent)
    {
        Hashtable ht = new Hashtable();
        DataTable dt = GetMaterialDivisionLIst(planOrderID);
        for (int i = 0; i < dt.Rows.Count; ++i)
        {
            dt.Rows[i]["ADJQTY"] = Convert.ToDouble(dt.Rows[i]["PLANQTY"]) + (Convert.ToDouble(dt.Rows[i]["PLANQTY"]) * adjPercent / 100);
            if (ht[dt.Rows[i]["MATERIALMASTER"].ToString()] == null)
                ht.Add(dt.Rows[i]["MATERIALMASTER"].ToString(), Convert.ToDouble(dt.Rows[i]["ADJQTY"]));
            else
                ht[dt.Rows[i]["MATERIALMASTER"].ToString()] = Convert.ToDouble(ht[dt.Rows[i]["MATERIALMASTER"].ToString()]) + Convert.ToDouble(dt.Rows[i]["ADJQTY"]);
        }
        return ht;
    }

    public double GetTotalAdjQty(double planOrderID, double materialMaster)
    {
        double totalAdjQty = 0;
        DataTable dt = GetMaterialDivisionLIst(planOrderID);
        DataRow[] dRows = dt.Select("MATERIALMASTER = " + materialMaster.ToString());
        if (dRows != null)
        {
            for (int i = 0; i < dRows.Length; ++i)
            {
                totalAdjQty += Convert.ToDouble(dRows[i]["ADJQTY"]);
            }
        }
        return totalAdjQty;
    }

    #endregion
}
