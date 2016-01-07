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
/// Summary description for ReceiveItem
/// </summary>
public class ReceiveItem
{
    private string sessionMaterialItem = "MaterialItem";
    string _error = "";
    public string ErrorMessage
    {
        get { return _error; }
    }

    public ReceiveItem()
    {
        //
        // TODO: Add constructor logic here
        //
    }

    public void ClearAllSession()
    {
        ClearMaterialItem();
    }

    public void ClearMaterialItem()
    {
        System.Web.HttpContext.Current.Session[sessionMaterialItem] = null;
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
    public DataTable GetReceivetemList(double Receive)
    {
        if (System.Web.HttpContext.Current.Session[sessionMaterialItem] == null)
        {
            ReceiveFlow Formula = new ReceiveFlow();
            System.Web.HttpContext.Current.Session[sessionMaterialItem] = Formula.GetMaterialItemList(Receive);
        }
        return (DataTable)System.Web.HttpContext.Current.Session[sessionMaterialItem];
    }


    public DataTable getMaterialListMenu(double plan, double division, DateTime usedate)
    {
        ReceiveFlow Formula = new ReceiveFlow();
        System.Web.HttpContext.Current.Session[sessionMaterialItem] = Formula.GetMaterialItemListMenu(plan,division,usedate);
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

    public bool InsertMaterialItem(double Receive, double plan, double division, ArrayList arrData)
    {
        bool ret = true;
        try
        {
            DataTable dt = GetReceivetemList(Receive);
            ReceiveFlow PrePOflow = new ReceiveFlow();
            for (int i = 0; i < arrData.Count; ++i)
            {
                VReceiveMaterialData VMaterialMaster = (VReceiveMaterialData)arrData[i];
                if (dt.Select("CODE = '" + VMaterialMaster.CODE.ToString() + "'").Length == 0)
                {
                    DataRow dRow = dt.NewRow();
                    dRow["RANK"] = dt.Rows.Count + 1;
                    dRow["LOID"] = dt.Rows.Count + 1;
                    dRow["RECEIVE"] = Receive;
                    dRow["MATERIALMASTER"] = VMaterialMaster.MATERIALMASTER;
                    dRow["MATERIALNAME"] = VMaterialMaster.MATERIALNAME;
                    dRow["UNITLOID"] = VMaterialMaster.UNITLOID;
                    dRow["UNITNAME"] = VMaterialMaster.UNITNAME;
                    dRow["PRICE"] = VMaterialMaster.PRICE;
                    dRow["ISVAT"] = VMaterialMaster.ISVAT;
                    dRow["SAPCODE"] = VMaterialMaster.SAPCODE;
                    dRow["RECEIVEQTY"] = 0;
                    dRow["DUEQTY"] = VMaterialMaster.DUEQTY;
                    dRow["ORDERQTY"] = VMaterialMaster.ORDERQTY;
                    dRow["NETPRICE"] = 0; //VMaterialMaster.DUEQTY * VMaterialMaster.PRICE;
                    dRow["REMARKS"] = "";
                    dRow["CODE"] = VMaterialMaster.CODE;
                    dRow["SPEC"] = VMaterialMaster.SPEC;
                    dRow["PLANREMAINQTY"] = VMaterialMaster.PLANREMAINQTY;
                    dRow["PREPODUEDATE"] = VMaterialMaster.PREPODUEDATE;
                    dRow["DUEDATE"] = VMaterialMaster.DUEDATE;
                    dRow["USEDATE"] = VMaterialMaster.USEDATE;
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

    public bool UpdateMaterialItem(double Receive, ArrayList arrData)
    {
        bool ret = true;
        try
        {
            DataTable dt = GetReceivetemList(Receive);
            for (int i = 0; i < arrData.Count; ++i)
            {
                VReceiveMaterialData MaterialItem = (VReceiveMaterialData)arrData[i];
                DataRow[] dRows = dt.Select("CODE = '" + MaterialItem.CODE.ToString() + "'");
                if (dRows.Length == 1)
                {
                    dRows[0]["RECEIVEQTY"] = MaterialItem.RECEIVEQTY;
                    dRows[0]["REMARKS"] = MaterialItem.REMARK;
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

}
