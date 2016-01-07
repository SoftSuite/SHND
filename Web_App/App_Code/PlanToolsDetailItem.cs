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
/// Summary description for PlanToolsDetailItem
/// </summary>
public class PlanToolsDetailItem
{
    private string sessionPlanTools = "PlanTools";
    private string sessionToolsDivision = "ToolsDivision";
    private string _error = "";

    public string ErrorMessage
    {
        get { return _error; }
    }

    public void ClearMaterial()
    {
        System.Web.HttpContext.Current.Session[sessionPlanTools] = null;
    }

    public void ClearToolsDivision()
    {
        System.Web.HttpContext.Current.Session[sessionToolsDivision] = null;
    }

    public void ClearAllSession()
    {
        ClearMaterial();
        ClearToolsDivision();
    }
    
    public void RemoveMaterial()
    {
        if (System.Web.HttpContext.Current.Session[sessionPlanTools] != null)
        {
            ((DataTable)System.Web.HttpContext.Current.Session[sessionPlanTools]).Rows.Clear();
        }
    }

    public PlanToolsDetailItem()
    {
        //
        // TODO: Add constructor logic here
        //
    }

    #region MaterialItem

    [System.ComponentModel.DataObjectMethodAttribute(System.ComponentModel.DataObjectMethodType.Select, true)]
    public DataTable GetToolsItemList(double planOrderID)
    {
        if (System.Web.HttpContext.Current.Session[sessionPlanTools] == null)
        {
            PlanOrderToolsFlow fFlow = new PlanOrderToolsFlow();
            System.Web.HttpContext.Current.Session[sessionPlanTools] = fFlow.GetToolsItemList(planOrderID);
        }
        return (DataTable)System.Web.HttpContext.Current.Session[sessionPlanTools];
    }

    public bool InsertToolsItem(double planOrderID, ArrayList arrData)
    {
        bool ret = true;
        try
        {
            DataTable dt = GetToolsItemList(planOrderID);
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
                    dRow["STATUS"] = "WA";
                    dRow["PRICE"] = VMaterialList.COST;
                    dRow["PLANQTY"] = 0;
                    dRow["TOTALPRICE"] = 0;
                    dRow["VAT"] = 0;
                    dt.Rows.Add(dRow);
                }
            }
            System.Web.HttpContext.Current.Session[sessionPlanTools] = dt;
        }
        catch (Exception ex)
        {
            _error = ex.Message;
            ret = false;
        }
        return ret;
    }

    public bool UpdateToolsItem(double planOrderID, ArrayList arrData)
    {
        bool ret = true;
        try
        {
            DataTable dt = GetToolsItemList(planOrderID);
            for (int i = 0; i < arrData.Count; ++i)
            {
                PlanToolsItemData pData = (PlanToolsItemData)arrData[i];
                DataRow[] dRows = dt.Select("MATERIALMASTER = " + pData.MATERIALMASTER.ToString());
                if (dRows.Length == 1)
                {
                    dRows[0]["SPEC"] = pData.SPEC;
                    dRows[0]["PRICE"] = pData.PRICE;
                    dRows[0]["VAT"] = (pData.ISVAT ? (pData.PRICE * 7 / 107) : 0);
                    dRows[0]["ISVAT"] = (pData.ISVAT ? "Y" : "N");
                    dRows[0]["PLANQTY"] = pData.PLANQTY;
                    dRows[0]["TOTALPRICE"] = pData.PLANQTY * pData.PRICE;
                }
            }
            System.Web.HttpContext.Current.Session[sessionPlanTools] = dt;
        }
        catch (Exception ex)
        {
            _error = ex.Message;
            ret = false;
        }
        return ret;
    }

    public bool DeleteToolsItem(ArrayList arrData)
    {
        bool ret = true;
        try
        {
            DataTable dt = (DataTable)System.Web.HttpContext.Current.Session[sessionPlanTools];
            for (int i = 0; i < arrData.Count; ++i)
            {
                DataRow[] dRow = dt.Select("MATERIALMASTER = " + arrData[i].ToString());
                if (dRow.Length == 1)
                {
                    dt.Rows.Remove(dRow[0]);
                }
            }
            System.Web.HttpContext.Current.Session[sessionPlanTools] = dt;
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

    public ArrayList GetToolsDivisionData()
    {
        ArrayList arrData = new ArrayList();
        PlanToolsDivisionData mData;
        DataTable dt = (DataTable)System.Web.HttpContext.Current.Session[sessionToolsDivision];
        if (dt != null)
        {
            for (int i = 0; i < dt.Rows.Count; ++i)
            {
                DataRow dRow = dt.Rows[i];
                mData = new PlanToolsDivisionData();
                mData.ADJQTY = Convert.ToDouble(dRow["ADJQTY"]);
                mData.DIVISION = Convert.ToDouble(dRow["DIVISION"]);
                mData.PLANTOOLSITEM = Convert.ToDouble(dRow["PLANTOOLSITEM"]);
                mData.REQQTY = Convert.ToDouble(dRow["REQQTY"]);
                mData.STATUS = dRow["STATUS"].ToString();
                arrData.Add(mData);
            }
        }
        return arrData;
    }

    private DataTable GetToolsDivisionLIst(double planOrderID)
    {
        if (System.Web.HttpContext.Current.Session[sessionToolsDivision] == null)
        {
            PlanOrderToolsFlow fFlow = new PlanOrderToolsFlow();
            System.Web.HttpContext.Current.Session[sessionToolsDivision] = fFlow.GetToolsDivisionList(planOrderID);
        }
        return (DataTable)System.Web.HttpContext.Current.Session[sessionToolsDivision];
    }

    [System.ComponentModel.DataObjectMethodAttribute(System.ComponentModel.DataObjectMethodType.Select, true)]
    public DataTable GetToolsDivisionLIst(double planOrderID, double materialMaster)
    {
        DataTable dt = GetToolsDivisionLIst(planOrderID);

        DataTable dtTemp = dt.Clone();
        DataRow[] dRows = dt.Select("MATERIALMASTER = " + materialMaster.ToString());
        if (dRows != null)
        {
            for (int i = 0; i < dRows.Length; ++i)
            {
                DataRow dRow = dtTemp.NewRow();
                dRow["LOID"] = Convert.ToDouble(dRows[i]["LOID"]);
                dRow["DIVISION"] = Convert.ToDouble(dRows[i]["DIVISION"]);
                dRow["PLANTOOLSITEM"] = Convert.ToDouble(dRows[i]["PLANTOOLSITEM"]);
                dRow["PLANORDER"] = Convert.ToDouble(dRows[i]["PLANORDER"]);
                dRow["REQQTY"] = Convert.ToDouble(dRows[i]["REQQTY"]);
                dRow["PLANQTY"] = Convert.ToDouble(dRows[i]["PLANQTY"]);
                dRow["ADJQTY"] = Convert.ToDouble(dRows[i]["ADJQTY"]);
                dRow["STATUS"] = dRows[i]["STATUS"].ToString();
                dRow["SPEC"] = dRows[i]["SPEC"].ToString();
                dRow["SAPCODE"] = dRows[i]["SAPCODE"].ToString();
                dRow["MATERIALNAME"] = dRows[i]["MATERIALNAME"].ToString();
                dRow["DIVISIONNAME"] = dRows[i]["DIVISIONNAME"].ToString();
                dRow["MATERIALMASTER"] = Convert.ToDouble(dRows[i]["MATERIALMASTER"]);

                dtTemp.Rows.Add(dRow);
            }
        }
        return dtTemp;
    }

    [System.ComponentModel.DataObjectMethodAttribute(System.ComponentModel.DataObjectMethodType.Select, true)]
    public bool UpdateToolsDivision(double planOrderID, double MATERIALMASTER, double DIVISION, double ADJQTY, double PLANQTY, string STATUS)
    {
        bool ret = true;
        DataTable dt = GetToolsDivisionLIst(planOrderID);
        DataRow[] dRows = dt.Select("MATERIALMASTER = " + MATERIALMASTER.ToString() + " AND DIVISION = " + DIVISION.ToString());
        if (dRows != null)
        {
            if (dRows.Length == 1)
            {
                dRows[0]["PLANQTY"] = ADJQTY;
                dRows[0]["ADJQTY"] = ADJQTY;
                System.Web.HttpContext.Current.Session[sessionToolsDivision] = dt;
            }
        }
        return ret;
    }

    public bool UpdateToolsDivision(double planOrderID, double MATERIALMASTER, double DIVISION, string STATUS)
    {
        bool ret = true;
        DataTable dt = GetToolsDivisionLIst(planOrderID);
        DataRow[] dRows = dt.Select("MATERIALMASTER = " + MATERIALMASTER.ToString() + " AND DIVISION = " + DIVISION.ToString());
        if (dRows != null)
        {
            if (dRows.Length == 1)
            {
                dRows[0]["STATUS"] = STATUS;
                System.Web.HttpContext.Current.Session[sessionToolsDivision] = dt;
            }
        }
        return ret;
    }

    public Hashtable GetAdjQty(double planOrderID, double adjPercent)
    {
        Hashtable ht = new Hashtable();
        DataTable dt = GetToolsDivisionLIst(planOrderID);
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
        DataTable dt = GetToolsDivisionLIst(planOrderID);
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
