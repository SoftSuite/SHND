using System;
using System.Collections.Generic;
using System.Text;
using zTran = SHND.DAL.Utilities.OracleTransactionDB;
using System.Data;
using SHND.DAL.Views;
using SHND.Data.Views;
using SHND.DAL.Tables;
using SHND.Data.Tables;
using System.Collections;
/// <summary>
/// NpoOrderSetFlow Class
/// Version 1.0
/// =========================================================================
/// Create by: Nang
/// Create Date: 3 Apr 2009
/// -------------------------------------------------------------------------
/// Modify By: -
/// Modify From: -
/// Modify Date: -
/// -------------------------------------------------------------------------
/// Remark: -
/// Description:
///    Flow จัดการการทำงานของหน้า OrderPateintSet
/// Changes:
///    1.0 - สร้าง
/// -------------------------------------------------------------------------
/// =========================================================================
/// </summary>
/// 

namespace SHND.Flow.Prepare
{
    public class OrderPatientSetFlow
    {
        string _error = "";
        public string ErrorMessage { get { return _error; } }

        public DataTable GetOrderPatientList(string str, string ordstr)
        {
            VOrderWaitRegisterDAL vDAL = new VOrderWaitRegisterDAL();
            str = str + (str == "" ? " " : " AND ") + " STATUS = 'RG' AND ISREGISTER = 'Y' ";
            return vDAL.GetDataDistinct(str, ordstr, null);
        }

        public DataTable GetOrderPatientListCtl(string str, string ordstr)
        {
            VOrderWaitRegisterDAL vDAL = new VOrderWaitRegisterDAL();
            str = str + (str == "" ? " " : " AND ") + " STATUS = 'RG' AND ISREGISTER = 'Y' ";
            return vDAL.GetDataCtl(str, ordstr, null);
        }

        public DataTable GetOrderPatientData(string str, string ordstr)
        {
            VOrderWaitRegisterDAL vDAL = new VOrderWaitRegisterDAL();
            string wh = "";
            if (str != "")
                wh = (str == "" ? " " : " AND ") + " STATUS = 'RG' AND ISREGISTER = 'Y' ";
            return vDAL.GetDistinctDataList(wh, ordstr, null);
        }

        public string GetCutOfTime(string str)
        {
            CutOffTimeDAL  cDAL = new CutOffTimeDAL();
            return cDAL.GetTime(str);
        }

        //public bool CheckUniq(string str, string pLOID)
        //{
        //    PrepareTimeDAL pDAL = new PrepareTimeDAL();
        //    pDAL.GetDataUniq(str, null);
        //    return !pDAL.OnDB || (pLOID == pDAL.LOID.ToString());
        //}

        public bool InsertPrepareTime(PrepareTimeData pData, string UserID, DataTable tempTable)
        {
            zTran trans = new zTran();
            bool ret = true;

            try
            {
                trans.CreateTransaction();

                if (tempTable != null)
                {
                    for (int i = 0; i < tempTable.Rows.Count; i++)
                    {
                        PrepareTimeDAL pDAL = new PrepareTimeDAL();
                        pDAL.CHECKTIME = pData.CHECKTIME;
                        pDAL.PREPAREMEAL = pData.PREPAREMEAL;
                        pDAL.ISTRANSFER = pData.ISTRANSFER;
                        pDAL.REFNONMEDLOID = Convert.ToDouble(tempTable.Rows[i]["ORDERNONMEDICALID"].ToString());
                        pDAL.REFMEDLOID = Convert.ToDouble(tempTable.Rows[i]["ORDERMEDICALSETID"].ToString());
                        pDAL.REFTABLEMED = pData.REFTABLEMED;

                        if (!CheckUniq(pDAL))
                            ret = pDAL.InsertCurrentData(UserID, trans.Trans);
                        else
                            ret = pDAL.UpdateCurrentData(UserID, trans.Trans);

                        if (ret == false)
                        {
                            trans.RollbackTransaction();
                            _error = pDAL.ErrorMessage;
                            return false;
                        }
                    }

                }
                if (ret)
                    trans.CommitTransaction();

                else
                {
                    trans.RollbackTransaction();
                    return false;
                }
            }
            catch (Exception ex)
            {
                _error = ex.Message;
                ret = false;
                trans.RollbackTransaction();
            }

            return ret;
        }

        private bool CheckUniq(PrepareTimeDAL pData)
        {
            String str = "";
            PrepareTimeDAL ppDAL = new PrepareTimeDAL();
            string dd = pData.CHECKTIME.Date.Day.ToString("00") + '/' + pData.CHECKTIME.Date.Month.ToString("00") + '/' + Convert.ToString(pData.CHECKTIME.Date.Year);
            str = " REFTABLEMED = '" + pData.REFTABLEMED + "' AND REFMEDLOID = " + pData.REFMEDLOID + " ";
            str += " AND  REFNONMEDLOID = " + pData.REFNONMEDLOID + " AND TO_CHAR(CHECKTIME,'DD/MM/YYYY') = '" + dd + "' ";
            str += " AND PREPAREMEAL = " + pData.PREPAREMEAL + "";

            ppDAL.GetDataUniq(str, null);
            pData.LOID = ppDAL.LOID;
            pData.OnDB = ppDAL.OnDB;
            return ppDAL.OnDB;
        }
    }
}
