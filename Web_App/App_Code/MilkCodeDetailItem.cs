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
using SHND.Flow.Inventory;

/// <summary>
/// Summary description for MilkCodeDetailItem
/// </summary>
public class MilkCodeDetailItem
{
    private string sessionStdMilKCodeDisease = "StdMilkCodeDisease";
    private string _error = "";

    public string ErrorMessage
    {
        get { return _error; }
    }
    public MilkCodeDetailItem()
    {
        //
        // TODO: Add constructor logic here
        //
    }

    public void ClearAllSession()
    {
        ClearStdMilkCodeDisease();
    }

    public void ClearStdMilkCodeDisease()
    {
        System.Web.HttpContext.Current.Session[sessionStdMilKCodeDisease] = null;
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

    #region MilkCodeDisease

    public ArrayList GetMilkCodeDiseaseData()
    {
        ArrayList arrData = new ArrayList();
        DataTable dt = (DataTable)System.Web.HttpContext.Current.Session[sessionStdMilKCodeDisease];
        if (dt != null)
        {
            for (int i = 0; i < dt.Rows.Count; ++i)
            {
                VMilkCodeData MilkCodeDisease = new VMilkCodeData();
                MilkCodeDisease.MILKCODE = dt.Rows[i]["MILKCODE"].ToString ();
                MilkCodeDisease.LOID = Convert.ToDouble(dt.Rows[i]["LOID"]);
                MilkCodeDisease.WARD = Convert.ToDouble(dt.Rows[i]["WARD"]);
             
                arrData.Add(MilkCodeDisease);
            }
        }
        return arrData;
    }

    public string GetDiseaseMilkCodeList()
    {
        string diseaseMilkCodeList = "";
        DataTable dt = (DataTable)System.Web.HttpContext.Current.Session[sessionStdMilKCodeDisease];
        if (dt != null)
        {
            for (int i = 0; i < dt.Rows.Count; ++i)
            {
                diseaseMilkCodeList += (diseaseMilkCodeList == "" ? "" : ",") + dt.Rows[i]["MILKCODE"].ToString();
            }
        }
        return diseaseMilkCodeList;
    }

    [System.ComponentModel.DataObjectMethodAttribute(System.ComponentModel.DataObjectMethodType.Select, true)]
    public DataTable GetMilkCodeDiseaseList(double  ward)
    {
        if (System.Web.HttpContext.Current.Session[sessionStdMilKCodeDisease] == null)
        {
            MilkCodeFlow MilkCodeMenu = new MilkCodeFlow();
            System.Web.HttpContext.Current.Session[sessionStdMilKCodeDisease] = MilkCodeMenu.GetMilkCodeDiseaseList(ward);
        }
        return (DataTable)System.Web.HttpContext.Current.Session[sessionStdMilKCodeDisease];
    }

    [System.ComponentModel.DataObjectMethodAttribute(System.ComponentModel.DataObjectMethodType.Update, true)]
    public bool UpdateMilkCode(double LOID, string milkCode)
    {
        bool ret = true;
        if (milkCode.Trim() == "")
            throw new ApplicationException(string.Format(DataResources.MSGEI001, "‡∫Õ√Ïπ¡"));

        DataTable dt = (DataTable)System.Web.HttpContext.Current.Session[sessionStdMilKCodeDisease];
        DataRow[] dRow = dt.Select("MILKCODE = '" + milkCode.Trim() + "' AND LOID <> " + LOID.ToString());
        if (dRow.Length == 0)
        {
            dRow = dt.Select("LOID = " + LOID.ToString());
            if (dRow.Length == 1)
            {
                dRow[0]["MILKCODE"] = (milkCode.Trim()).ToUpper();
            }
        }
        else
            throw new ApplicationException(string.Format(DataResources.MSGEI015, "‡∫Õ√Ïπ¡", milkCode));
        return ret;
    }

    [System.ComponentModel.DataObjectMethodAttribute(System.ComponentModel.DataObjectMethodType.Delete, true)]
    public bool DeleteMildCode(double LOID)
    {
        bool ret = true;
        DataTable dt = (DataTable)System.Web.HttpContext.Current.Session[sessionStdMilKCodeDisease];
        DataRow[] dRow = dt.Select("LOID = " + LOID.ToString());
        if (dRow.Length == 1)
        {
            dt.Rows.Remove(dRow[0]);
        }
        ReOrder(dt, "LOID");
        System.Web.HttpContext.Current.Session[sessionStdMilKCodeDisease] = dt;
        return ret;
    }

    public bool InsertMilkCodeDisease(double ward,string stdMilKCodeName)
    {
        bool ret = true;
        try
        {
            DataTable dt = GetMilkCodeDiseaseList(ward);
            if (dt.Select("MILKCODE = '" + stdMilKCodeName + "' ").Length == 0)
            {
                DataRow dRow = dt.NewRow();

                dRow["LOID"] = dt.Rows.Count + 1;
                dRow["WARD"] = ward;
                dRow["MILKCODE"] = stdMilKCodeName.ToUpper();

                dt.Rows.Add(dRow);
            }
            else
            {
                _error = string.Format(DataResources.MSGEI015, "‡∫Õ√Ïπ¡", stdMilKCodeName);
                ret = false;
            }
            System.Web.HttpContext.Current.Session[sessionStdMilKCodeDisease] = dt;
          
        }
        catch (Exception ex)
        {
            _error = ex.Message;
            ret = false;
        }
        return ret;
    }

    #endregion










   
}
