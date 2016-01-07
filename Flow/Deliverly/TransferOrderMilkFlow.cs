using System;
using System.Collections;
using System.Collections.Generic;
using System.Data;
using System.Text;
using zTran = SHND.DAL.Utilities.OracleTransactionDB;
using SHND.DAL.Delivery;
using SHND.DAL.Tables;

/// <summary>
/// TransferOrderMilkFlow Class
/// Version 1.0
/// =========================================================================
/// Create by: Teang
/// Create Date: 21 Apr 2009
/// -------------------------------------------------------------------------
/// Modify By: -
/// Modify From: -
/// Modify Date: -
/// -------------------------------------------------------------------------
/// Remark: -
/// Description:
///    Flow จัดการการทำงานของหน้า การจัดส่งนมผงสำหรับเด็ก
/// Changes:
///    1.0 - สร้าง
/// -------------------------------------------------------------------------
/// =========================================================================
/// </summary>
/// 
namespace SHND.Flow.Deliverly
{
    public class TransferOrderMilkFlow
    {
        string _error = "";
        public string ErrorMessage { get { return _error; } }

        public DataTable GetMasterList(double ward, string milkName, string patientName, string HN, string AN, string VN, DateTime orderDate, string prepareMeal, string owner, string orderBy)
        {
            VTransferOrderMilkDAL sDAL = new VTransferOrderMilkDAL();
            return sDAL.GetDataListByConditions(ward, milkName, patientName, HN, AN, VN, orderDate, prepareMeal, owner, "", orderBy, null);
        }

        public bool UpdateDeliverlyStatus(string userID, double ward, string milkName, string patientName, string HN, string AN, string VN, DateTime orderDate, string prepareMeal, string owner, string orderBy, ArrayList arrData)
        {
            bool ret = true;
            zTran trans = new zTran();
            trans.CreateTransaction();
            try
            {
                string admitPatientList = "";
                for (int i = 0; i < arrData.Count; ++i)
                {
                    admitPatientList += (admitPatientList == "" ? "" : ",") + arrData[i].ToString();
                }
                VTransferOrderMilkDAL sDAL = new VTransferOrderMilkDAL();
                DataTable dtPrepareTime = sDAL.GetDataListByConditions(ward, milkName, patientName, HN, AN, VN, orderDate, prepareMeal, owner, admitPatientList, orderBy, trans.Trans);
                string prepareTimeList = "";
                for (int i = 0; i < dtPrepareTime.Rows.Count; ++i)
                {
                    prepareTimeList += (prepareTimeList == "" ? "" : ",") + dtPrepareTime.Rows[i]["PREPARETIME"].ToString();
                }
                PrepareTimeDAL pDAL = new PrepareTimeDAL();
                if (prepareTimeList.Trim() != "") ret = pDAL.UpdateDeliverlyStatusByLOID(userID, "Y", prepareTimeList, trans.Trans);
                if (ret)
                    trans.CommitTransaction();
                else
                {
                    _error = pDAL.ErrorMessage;
                    trans.RollbackTransaction();
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
    }
}
