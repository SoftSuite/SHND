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
using SHND.DAL.Prepare;

/// <summary>
/// OrderMilkSetFlow Class
/// Version 1.0
/// =========================================================================
/// Create by: Nang
/// Create Date: 12 May 2009
/// -------------------------------------------------------------------------
/// Modify By: -
/// Modify From: -
/// Modify Date: -
/// -------------------------------------------------------------------------
/// Remark: -
/// Description:
///    Flow จัดการการทำงานของหน้า OrderMilkSetCtl 
/// Changes:
///    1.0 - สร้าง
/// -------------------------------------------------------------------------
/// =========================================================================
/// </summary>
/// 

namespace SHND.Flow.Prepare
{
    public class OrderMilkSetFlow
    {

        string _error = "";
        public string ErrorMessage { get { return _error; } }

        public DataTable GetOrderMilkSetList(double ward, double milkcategory,string patientName, DateTime orderDateFrom, DateTime orderDateTo, DateTime RegDateFrom, DateTime RegDateTo,string MyMilk, string orderBy)
        {
            VOrderMilkWaitRegisterDAL sDAL = new VOrderMilkWaitRegisterDAL();
            return sDAL.GetDataListByConditions(ward, milkcategory, patientName, orderDateFrom, orderDateTo, RegDateFrom, RegDateTo,MyMilk, orderBy, null);
        }

        public string GetCutOfTime(string str)
        {
            CutOffTimeDAL cDAL = new CutOffTimeDAL();
            return cDAL.GetTime(str);
        }


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
                        pDAL.REFMEDLOID = Convert.ToDouble(tempTable.Rows[i]["ORDERNO"].ToString());
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
            str += "  AND TO_CHAR(CHECKTIME,'DD/MM/YYYY') = '" + dd + "' ";
            str += " AND PREPAREMEAL = " + pData.PREPAREMEAL + "";

            ppDAL.GetDataUniq(str, null);
            pData.LOID = ppDAL.LOID;
            pData.OnDB = ppDAL.OnDB;
            return ppDAL.OnDB;
        }
    }
}
