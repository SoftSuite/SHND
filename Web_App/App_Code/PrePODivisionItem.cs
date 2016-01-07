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
using SHND.Flow.Purchase;

/// <summary>
/// Summary description for PrePODivisionItem
/// </summary>
public class PrePODivisionItem
{
    private string sessionMaterialItem = "MaterialItem";
    private string sessionPODelivery = "PODelivery";
    string _error = "";
    public string ErrorMessage
    {
        get { return _error; }
    }

    public PrePODivisionItem()
    {
        //
        // TODO: Add constructor logic here
        //
    }

    public void ClearAllSession()
    {
        ClearMaterialItem();
        ClearPODelivery();
    }

    public void ClearMaterialItem()
    {
        System.Web.HttpContext.Current.Session[sessionMaterialItem] = null;
    }

    public void ClearPODelivery()
    {
        System.Web.HttpContext.Current.Session[sessionPODelivery] = null;
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

    #region MaterialItem

    //public ArrayList GetMaterialItemData()
    //{
    //    ArrayList arrData = new ArrayList();
    //    DataTable dt = (DataTable)System.Web.HttpContext.Current.Session[sessionMaterialItem];
    //    if (dt != null)
    //    {
    //        for (int i = 0; i < dt.Rows.Count; ++i)
    //        {
    //            FormularFeedItemData BlenderizeItem = new FormularFeedItemData();
    //            BlenderizeItem.ENERGY = Convert.ToDouble(dt.Rows[i]["ENERGY"]);
    //            BlenderizeItem.FORMULAFEED = Convert.ToDouble(dt.Rows[i]["FORMULAFEED"]);
    //            BlenderizeItem.LOID = Convert.ToDouble(dt.Rows[i]["LOID"]);
    //            BlenderizeItem.MATERIALMASTER = Convert.ToDouble(dt.Rows[i]["MATERIALMASTER"]);
    //           // BlenderizeItem.PREPARENAME = dt.Rows[i]["PREPARENAME"].ToString();
    //           // BlenderizeItem.REFFORMULA = 0;
    //            BlenderizeItem.QTY = Convert.ToDouble(dt.Rows[i]["QTY"]);
    //            BlenderizeItem.UNIT = Convert.ToDouble(dt.Rows[i]["UNIT"]);
    //            arrData.Add(BlenderizeItem);
    //        }
    //    }
    //    return arrData;
    //}

    public string getMaterialList()
    {
        string materialList = "";
        DataTable dt = (DataTable)System.Web.HttpContext.Current.Session[sessionMaterialItem];
        if (dt != null)
        {
            for (int i = 0; i < dt.Rows.Count; ++i)
            {
                materialList += (materialList == "" ? "" : ",") + "'" + dt.Rows[i]["CODE"].ToString() + "'";
            }
        }
        return materialList;
    }

    [System.ComponentModel.DataObjectMethodAttribute(System.ComponentModel.DataObjectMethodType.Select, true)]
    public DataTable GetPrePODivisiontemList(double PrePO)
    {
        if (System.Web.HttpContext.Current.Session[sessionMaterialItem] == null)
        {
            PrePODivisionItemFlow Formula = new PrePODivisionItemFlow();
            System.Web.HttpContext.Current.Session[sessionMaterialItem] = Formula.GetMaterialItemList(PrePO);
        }
        return (DataTable)System.Web.HttpContext.Current.Session[sessionMaterialItem];
    }


    public DataTable getMaterialListMenu(double plan, double division, DateTime usedate, double planMaterialClass)
    {
        PrePODivisionItemFlow Formula = new PrePODivisionItemFlow();
        System.Web.HttpContext.Current.Session[sessionMaterialItem] = Formula.GetMaterialItemListMenu(plan,division,usedate,planMaterialClass);
        return (DataTable)System.Web.HttpContext.Current.Session[sessionMaterialItem];
    }

    //public string VerifyData(double materialMaster, double qty)
    //{
    //    string ret = "";
    //    if (materialMaster == 0)
    //        ret = string.Format(DataResources.MSGEI002, "ส่วนผสม");
    //    else if (qty == 0)
    //        ret = string.Format(DataResources.MSGEI001, "น้ำหนักสุก");

    //    return ret;
    //}

    public bool InsertMaterialItem(double PrePO, double plan, double division, ArrayList arrData)
    {
        bool ret = true;
        try
        {
            DataTable dt = GetPrePODivisiontemList(PrePO);
            PrePODivisionItemFlow PrePOflow = new PrePODivisionItemFlow();
            for (int i = 0; i < arrData.Count; ++i)
            {
                VPrePOMaterialClassData VMaterialMaster = (VPrePOMaterialClassData)arrData[i];
                if (dt.Select("CODE = '" + VMaterialMaster.CODE.ToString() + "'").Length == 0)
                {
                    DataRow dRow = dt.NewRow();
                    dRow["RANK"] = dt.Rows.Count + 1;
                    dRow["LOID"] = dt.Rows.Count + 1;
                    dRow["PREPODIVISION"] = PrePO;
                    dRow["MATERIALMASTER"] = VMaterialMaster.MATERIALMASTER;
                    dRow["MATERIALNAME"] = VMaterialMaster.MATERIALNAME;
                    dRow["UNITLOID"] = VMaterialMaster.UNITLOID;
                    dRow["UNITNAME"] = VMaterialMaster.UNITNAME;
                    dRow["PRICE"] = VMaterialMaster.PRICE;
                    dRow["ISVAT"] = VMaterialMaster.ISVAT;
                    dRow["SAPCODE"] = VMaterialMaster.SAPCODE;
                    dRow["MENUQTY"] = 0;
                    dRow["ORDERQTY"] = 0;
                    dRow["PLANREMAINQTY"] = PrePOflow.GetRemain(plan, division, VMaterialMaster.MATERIALMASTER);
                    dRow["NETPRICE"] = 0;
                    dRow["REMARKS"] = "";
                    dRow["CODE"] = VMaterialMaster.CODE;
                    dRow["SPEC"] = VMaterialMaster.SPEC;
                    dt.Rows.Add(dRow);
                }
            }
            System.Web.HttpContext.Current.Session[sessionMaterialItem] = dt;
        }
        catch (Exception ex)
        {
            ex.ToString();
            ret = false;
        }
        return ret;
    }

    public bool UpdateMaterialItem(double PrePO, ArrayList arrData)
    {
        bool ret = true;
        try
        {
            DataTable dt = GetPrePODivisiontemList(PrePO);
            for (int i = 0; i < arrData.Count; ++i)
            {
                PrePOItemData MaterialItem = (PrePOItemData)arrData[i];
                DataRow[] dRows = dt.Select("CODE = '" + MaterialItem.CODE.ToString() + "'");
                if (dRows.Length == 1)
                {
                    dRows[0]["ORDERQTY"] = MaterialItem.ORDERQTY;
                    dRows[0]["REMARKS"] = MaterialItem.REMARKS;
                    dRows[0]["NETPRICE"] = MaterialItem.NETPRICE;
                }
            }
            System.Web.HttpContext.Current.Session[sessionMaterialItem] = dt;
        }
        catch (Exception ex)
        {
            ex.ToString();
            ret = false;
        }
        return ret;
    }


    public bool DeleteMaterialItem(ArrayList arrData)
    {
        bool ret = true;
        try
        {
            DataTable dt = (DataTable)System.Web.HttpContext.Current.Session[sessionMaterialItem];
            for (int i = 0; i < arrData.Count; ++i)
            {
                DataRow[] dRow = dt.Select("RANK = " + arrData[i].ToString());
                if (dRow.Length == 1)
                {
                    dt.Rows.Remove(dRow[0]);
                }
            }
            ReOrder(dt, "RANK");
            System.Web.HttpContext.Current.Session[sessionMaterialItem] = dt;
        }
        catch (Exception ex)
        {
            ex.ToString();
            ret = false;
        }
        return ret;
    }

    #endregion

    #region OrderMenu

    [System.ComponentModel.DataObjectMethodAttribute(System.ComponentModel.DataObjectMethodType.Select, true)]
    public DataTable GetOrderMenuList(DateTime usedate, double division)
    {
        PrePODivisionItemFlow Formula = new PrePODivisionItemFlow();
        return Formula.GetOrderMenuList(usedate,division);
    }

    #endregion

    #region Delivery

    public ArrayList GetMaterialDeliveryData()
    {
        ArrayList arrData = new ArrayList();
        PrePODuedateData mData;
        DataTable dt = (DataTable)System.Web.HttpContext.Current.Session[sessionPODelivery];
        if (dt != null)
        {
            for (int i = 0; i < dt.Rows.Count; ++i)
            {
                DataRow dRow = dt.Rows[i];
                mData = new PrePODuedateData();
                mData.DUEDATE = Convert.ToDateTime(dRow["DUEDATE"]);
                mData.DUEQTY = Convert.ToDouble(dRow["DUEQTY"]);
                mData.CODE = dRow["CODE"].ToString();

                arrData.Add(mData);
            }
        }
        return arrData;
    }

    private DataTable GetMaterialDeliveryLIst(double PrePO)
    {
        if (System.Web.HttpContext.Current.Session[sessionPODelivery] == null)
        {
            PrePODivisionItemFlow fFlow = new PrePODivisionItemFlow();
            System.Web.HttpContext.Current.Session[sessionPODelivery] = fFlow.GetMaterialDeliveryList(PrePO);
        }
        return (DataTable)System.Web.HttpContext.Current.Session[sessionPODelivery];
    }

    public DataTable GetMaterialDeliveryBlank()
    {
        PrePODivisionItemFlow fFlow = new PrePODivisionItemFlow();
        return fFlow.GetMaterialDeliveryBlank();
    }

    [System.ComponentModel.DataObjectMethodAttribute(System.ComponentModel.DataObjectMethodType.Select, true)]
    public DataTable GetMaterialDeliveryLIst(double PrePO, string CODE)
    {
        DataTable dt = GetMaterialDeliveryLIst(PrePO);

        DataTable dtTemp = dt.Clone();
        DataRow[] dRows = dt.Select("CODE = '" + CODE +"'");
        if (dRows != null)
        {
            for (int i = 0; i < dRows.Length; ++i)
            {
                DataRow dRow = dtTemp.NewRow();
                dRow["LOID"] = Convert.ToDouble(dRows[i]["LOID"]);
                dRow["PREPOITEM"] = Convert.ToDouble(dRows[i]["PREPOITEM"]);
                dRow["DUEDATE"] = Convert.ToDateTime(dRows[i]["DUEDATE"]);
                dRow["DUEQTY"] = Convert.ToDouble(dRows[i]["DUEQTY"]);
                dRow["CODE"] = dRows[i]["CODE"].ToString();
                dRow["RANK"] = Convert.ToDouble(dRows[i]["RANK"]);
                dtTemp.Rows.Add(dRow);
            }
        }
        return dtTemp;
    }

    public bool InsertDeliveryItem(DateTime date, double qty, string Code)
    {
        bool ret = true;
        ret = VerifyData(date,qty,0,Code);
        if (ret)
        {
            DataTable dt = (DataTable)System.Web.HttpContext.Current.Session[sessionPODelivery];
            if (dt != null)
            {
                ReOrder(dt);
                DataRow dRow = dt.NewRow();
                dRow["LOID"] = Convert.ToDouble(dt.Rows.Count) + 1;
                dRow["PREPOITEM"] = Convert.ToDouble(dRow["LOID"]);
                dRow["RANK"] = Convert.ToDouble(dRow["LOID"]);
                dRow["DUEDATE"] = date;
                dRow["DUEQTY"] = qty;
                dRow["CODE"] = Code;
                dt.Rows.Add(dRow);
                System.Web.HttpContext.Current.Session[sessionPODelivery] = dt;
            }
        }
        return ret;
    }

    [System.ComponentModel.DataObjectMethodAttribute(System.ComponentModel.DataObjectMethodType.Update, true)]
    public bool UpdateMaterialDelivery(double PrePO, double PREPOITEM, DateTime DUEDATE, double DUEQTY, string CODE, double LOID, double RANK)
    {
        bool ret = true;
        ret = VerifyData(DUEDATE, DUEQTY, RANK, CODE);
        if (ret)
        {
            DataTable dt = GetMaterialDeliveryLIst(PrePO);
            DataRow[] dRows = dt.Select("RANK = " + RANK.ToString());
            if (dRows != null)
            {
                if (dRows.Length == 1)
                {
                    dRows[0]["DUEDATE"] = DUEDATE;
                    dRows[0]["DUEQTY"] = DUEQTY;
                    System.Web.HttpContext.Current.Session[sessionPODelivery] = dt;
                }
            }
        }
        else
            throw new ApplicationException(_error);
        return ret;
    }

    public bool DeleteMaterialDelivery(double RANK)
    {
        bool ret = true;
        DataTable dt = (DataTable)System.Web.HttpContext.Current.Session[sessionPODelivery];
        if (dt != null)
        {
            DataRow[] dRow = dt.Select("RANK = " + RANK.ToString());
            dt.Rows.Remove(dRow[0]);
            ReOrder(dt);
            System.Web.HttpContext.Current.Session[sessionPODelivery] = dt;
        }
        else
            ret = false;
        return ret;
    }

    private bool VerifyData(DateTime date, double qty, double Rank, string Code)
    {
        bool ret = true;
        if (date.Year == 1)
        {
            ret = false;
            _error = string.Format(DataResources.MSGEI002, "วันที่");
        }
        else if (qty == 0)
        {
            ret = false;
            _error = string.Format(DataResources.MSGEI001, "จำนวน");
        }
        else
        {
            DataTable dt = (DataTable)System.Web.HttpContext.Current.Session[sessionPODelivery];
            foreach (DataRow dRow in dt.Rows)
            {
                if (Convert.ToDateTime(dRow["DUEDATE"]) == date && dRow["CODE"].ToString() == Code && Convert.ToDouble(dRow["RANK"]) != Rank)
                {
                    _error = string.Format(DataResources.MSGEI015, "วันที่", date.ToString(Constant.DateFormat));
                    //_error = "วันที่นี้มีอยู่ในรายการแล้ว";
                    ret = false;
                    break;
                }
            }
        }

        return ret;
    }

    private void ReOrder(DataTable dt)
    {
        int i = 1;
        foreach (DataRow dRow in dt.Rows)
        {
            dRow["RANK"] = i;
            dRow["LOID"] = i;
            i += 1;
        }
    }

    #endregion
}
