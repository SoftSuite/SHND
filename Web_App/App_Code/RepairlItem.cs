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
using SHND.Data.Inventory;
using SHND.Data.Views;
using SHND.Flow.Inventory;
using SHND.DAL.Views;

/// <summary>
/// Summary description for RepairrequestItem
/// </summary>
public class RepairItem
{
    public RepairItem()
    {
        //
        // TODO: Add constructor logic here
        //
    }
    private string sessionName = "RepairDetailItem";
    string _error = "";
    private VStockoutItemDAL _flow;
    public VStockoutItemDAL FlowObj
    {
        get { if (_flow == null) _flow = new VStockoutItemDAL(); return _flow; }
    }

    public string ErrorMessage
    {
        get { return _error; }
    }

    public void ClearSession()
    {
        System.Web.HttpContext.Current.Session.Remove(sessionName);
    }
    public void CopyItem(DataTable dt)
    {
        System.Web.HttpContext.Current.Session[sessionName] = dt;
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
    public bool DeleteRepairItemAll()
    {
        bool ret = true;
        DataTable dt = (DataTable)System.Web.HttpContext.Current.Session[sessionName];
        if (dt != null)
        {
            dt.Rows.Clear();
            System.Web.HttpContext.Current.Session[sessionName] = dt;
        }
        else
            ret = false;
        return ret;
    }
    [System.ComponentModel.DataObjectMethodAttribute(System.ComponentModel.DataObjectMethodType.Select, true)]
    public DataTable GetRepairItem(double LOID)
    {
        DataTable dt = (DataTable)System.Web.HttpContext.Current.Session[sessionName];
        if (dt == null)
        {
            dt = FlowObj.GetRepairItem(LOID);
            System.Web.HttpContext.Current.Session[sessionName] = dt;
        }
        return dt;
    }

    [System.ComponentModel.DataObjectMethodAttribute(System.ComponentModel.DataObjectMethodType.Select, true)]
    public DataTable GetRepairItemBlank()
    {
        return FlowObj.GetRepairItemBlank();
    }

    [System.ComponentModel.DataObjectMethodAttribute(System.ComponentModel.DataObjectMethodType.Delete, true)]
    public bool DeleteRepairItem(double LOID)
    {
        bool ret = true;
        DataTable dt = (DataTable)System.Web.HttpContext.Current.Session[sessionName];
        if (dt != null)
        {
            DataRow[] dRow = dt.Select("LOID = " + LOID.ToString());
            dt.Rows.Remove(dRow[0]);
            ReOrder(dt);
            System.Web.HttpContext.Current.Session[sessionName] = dt;
        }
        else
            ret = false;
        return ret;
    }

    [System.ComponentModel.DataObjectMethodAttribute(System.ComponentModel.DataObjectMethodType.Update, true)]
    public bool UpdateRepairItem(decimal LOID, decimal RANK, DateTime REPAIRDATE, string DESCRIPTION)
    {
        RepairItemData data = new RepairItemData();
        data.LOID = Convert.ToDouble(LOID);
        //data.LOID = Convert.ToDouble(STOCKOUTITEM);
        data.REPAIRDATE = REPAIRDATE;
        data.DESCRIPTION = DESCRIPTION;

        bool ret = true;
        ret = VerifyData(data);
        if (ret)
        {
            DataTable dt = (DataTable)System.Web.HttpContext.Current.Session[sessionName];
            if (dt != null)
            {
                DataRow[] dRows = dt.Select("LOID = " + data.LOID.ToString());
                DataRow dRow = dRows[0];
                //dRow["STOCKOUTITEM"] = STOCKOUTITEM;
                dRow["REPAIRDATE"] = REPAIRDATE;
                dRow["DESCRIPTION"] = DESCRIPTION;   

                ReOrder(dt);
                System.Web.HttpContext.Current.Session[sessionName] = dt;
            }
        }
        else throw new ApplicationException(_error);
        return ret;
    }

    private bool VerifyData(RepairItemData data)
    {
        bool ret = true;
        if (data.REPAIRDATE.Year == 1)
        {
            ret = false;
            _error = string.Format(DataResources.MSGEI002, "วันที่");
        }
        else if (data.DESCRIPTION == "")
        {
            ret = false;
            _error = string.Format(DataResources.MSGEI001, "รายละเอียดการซ่อม");
        }
        else
        {
            
        }

        return ret;
    }

    //0 LOID, '' REPAIRDATE, '' DESCRIPTION, 0 STOCKOUTITEM
    public bool InsertRepairItem(RepairItemData data)
    {
        bool ret = true;
        ret = VerifyData(data);
        if (ret)
        {
            DataTable dt = (DataTable)System.Web.HttpContext.Current.Session[sessionName];
            if (dt != null)
            {
                ReOrder(dt);
                DataRow dRow = dt.NewRow();
                dRow["LOID"] = Convert.ToDouble(dt.Rows.Count) + 1;
                dRow["RANK"] = Convert.ToDouble(dRow["LOID"]);
                //dRow["STOCKOUTITEM"] = Convert.ToDouble(dRow["STOCKOUTITEM"]);
                dRow["REPAIRDATE"] = data.REPAIRDATE;
                dRow["DESCRIPTION"] = data.DESCRIPTION;

                dt.Rows.Add(dRow);
                System.Web.HttpContext.Current.Session[sessionName] = dt;
            }
        }
        return ret;
    }

    public ArrayList GetItemList()
    {
        DataTable dt = (DataTable)System.Web.HttpContext.Current.Session[sessionName];
        ArrayList arr = new ArrayList();
        if (dt != null)
        {
            foreach (DataRow dRow in dt.Rows)
            {
                RepairItemData data = new RepairItemData();
                data.REPAIRDATE = Convert.ToDateTime(dRow["REPAIRDATE"]);
                data.DESCRIPTION = dRow["DESCRIPTION"].ToString();
                arr.Add(data);
            }
        }
        return arr;
    }
}
