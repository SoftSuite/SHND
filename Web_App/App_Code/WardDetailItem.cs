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
using SHND.Flow.Admin;

/// <summary>
/// Summary description for WardDetailItem
/// </summary>
public class WardDetailItem
{
    private string sessionWard = "WardDetail";
    public WardDetailItem()
    {
        //
        // TODO: Add constructor logic here
        //
    }

    public void ClearWard()
    {
        System.Web.HttpContext.Current.Session[sessionWard] = null;
    }

    #region Ward

        [System.ComponentModel.DataObjectMethodAttribute(System.ComponentModel.DataObjectMethodType.Select, true)]
    public DataTable GetWardList(double officer)
    {
        if (officer > 0)
        {
            if (System.Web.HttpContext.Current.Session[sessionWard] == null)
            {
                WardFlow fFlow = new WardFlow();
                System.Web.HttpContext.Current.Session[sessionWard] = fFlow.GetWardList(officer);
            }
        }
        return (DataTable)System.Web.HttpContext.Current.Session[sessionWard];


    }

    public string getWardExist()
    {
        string ward = "";
        DataTable dt = (DataTable)System.Web.HttpContext.Current.Session[sessionWard];
        if (dt != null)
        {
            for (int i = 0; i < dt.Rows.Count; ++i)
            {
                ward += (ward == "" ? "" : ",") + dt.Rows[i]["WARD"].ToString();
            }
        }
        return ward;
    }

    public bool InsertWard(double officer, ArrayList arrData)
    {
        bool ret = true;
        double maxNo = 0;
        try
        {
            DataTable dt = GetWardList(officer);
            for (int i = 0; i < arrData.Count; ++i)
            {
                VWardResponseData VWardList = (VWardResponseData)arrData[i];
                if (dt.Select("WARD = " + VWardList.WARD.ToString()).Length == 0)
                {
                    if (dt.Rows.Count > 0)
                        maxNo = Convert.ToDouble(dt.Compute("MAX(PRIORITY)", "").ToString());
                    DataRow dRow = dt.NewRow();
                    dRow["WARD"] = VWardList.WARD;
                    dRow["OFFICER"] = officer;
                    dRow["ACTIVE"] = VWardList.ACTIVE;
                    dRow["PRIORITY"] = maxNo+1;
                    dRow["ISDEFAULT"] = VWardList.ISDEFAULT;
                    dRow["WARDNAME"] = VWardList.WARDNAME;
                    dt.Rows.Add(dRow);
                }
            }
            System.Web.HttpContext.Current.Session[sessionWard] = dt;
        }
        catch (Exception ex)
        {
            ex.ToString();
            ret = false;
        }
        return ret;
    }

    public bool UpdateWard(double officer, ArrayList arrData)
    {
        bool ret = true;
        try
        {
            DataTable dt = GetWardList(officer);
            for (int i = 0; i < arrData.Count; ++i)
            {
                VWardResponseData pData = (VWardResponseData)arrData[i];
                DataRow[] dRows = dt.Select("WARD = " + pData.WARD.ToString());
                if (dRows.Length == 1)
                {
                    dRows[0]["ACTIVE"] = pData.ACTIVE;
                    dRows[0]["ISDEFAULT"] = pData.ISDEFAULT;
                    dRows[0]["PRIORITY"] = pData.PRIORITY;
                }
            }
            System.Web.HttpContext.Current.Session[sessionWard] = dt;
        }
        catch (Exception ex)
        {
            ex.ToString();
            ret = false;
        }
        return ret;
    }

    public bool DeleteWard(ArrayList arrData)
    {
        bool ret = true;
        try
        {
            DataTable dt = (DataTable)System.Web.HttpContext.Current.Session[sessionWard];
            for (int i = 0; i < arrData.Count; ++i)
            {
                DataRow[] dRow = dt.Select("WARD = " + arrData[i].ToString());
                if (dRow.Length == 1)
                {
                    dt.Rows.Remove(dRow[0]);
                }
            }
            System.Web.HttpContext.Current.Session[sessionWard] = dt;
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
