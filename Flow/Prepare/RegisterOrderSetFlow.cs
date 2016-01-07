using System;
using System.Collections;
using System.Collections.Generic;
using System.Data;
using System.Text;
using zTran = SHND.DAL.Utilities.OracleTransactionDB;
using SHND.DAL.Prepare;
using SHND.DAL.Tables;

/// <summary>
/// RegisterOrderSetFlow Class
/// Version 1.0
/// =========================================================================
/// Create by: Teang
/// Create Date: 2 Apr 2009
/// -------------------------------------------------------------------------
/// Modify By: -
/// Modify From: -
/// Modify Date: -
/// -------------------------------------------------------------------------
/// Remark: -
/// Description:
///    Flow จัดการการทำงานของหน้า Register การสั่งอาหารสำรับ
/// Changes:
///    1.0 - สร้าง
/// -------------------------------------------------------------------------
/// =========================================================================
/// </summary>
/// 
namespace SHND.Flow.Prepare
{
    public class RegisterOrderSetFlow
    {
        string _error = "";
        public string ErrorMessage { get { return _error; } }

        public DataTable GetRegisterList(DateTime date, double ward, double foodType, double foodCategory, string patientName, DateTime orderDateFrom, DateTime orderDateTo, string orderBy)
        {
            VRegisterOrderSetDAL sDAL = new VRegisterOrderSetDAL();
            return sDAL.GetDataListByConditions(date, ward, foodType, foodCategory, patientName, orderDateFrom, orderDateTo, orderBy, null);
        }

        public DataTable GetNonRegisterList(DateTime date, double ward, double foodType, double foodCategory, string patientName, DateTime orderDateFrom, DateTime orderDateTo, string orderBy)
        {
            VNonRegisterOrderSetDAL sDAL = new VNonRegisterOrderSetDAL();
            return sDAL.GetDataListByConditions(date, ward, foodType, foodCategory, patientName, orderDateFrom, orderDateTo, orderBy, null);
        }

        public bool Register(ArrayList arrData, string registerMeal, DateTime registerDate, string userID)
        {
            zTran trans = new zTran();
            bool ret = true;
            trans.CreateTransaction();
            try
            {
                for (int i = 0; i < arrData.Count; ++i)
                {
                    string[] arrLoid = arrData[i].ToString().Split('#');
                    OrderMedicalSetDAL mDAL = new OrderMedicalSetDAL();
                    mDAL.GetDataByLOID(Convert.ToDouble(arrLoid[0]), trans.Trans);
                    if (mDAL.OnDB)
                    {
                        if (mDAL.STATUS != "RG")
                        {
                            mDAL.STATUS = "RG";
                            mDAL.FIRSTMEALREGIS = registerMeal;
                            mDAL.FIRSTDATEREGIS = registerDate;
                        }
                        mDAL.ISREGISTER = "Y";
                        mDAL.REGISTERDATE = DateTime.Now;

                        ret = mDAL.UpdateCurrentData(userID, trans.Trans);
                    }
                    if (!ret)
                    {
                        _error = mDAL.ErrorMessage;
                        break;
                    }
                    OrderNonMedicalDAL nDAL = new OrderNonMedicalDAL();
                    nDAL.GetDataByLOID(Convert.ToDouble(arrLoid[1]), trans.Trans);
                    if (nDAL.OnDB)
                    {
                        if (nDAL.STATUS != "RG")
                        {
                            nDAL.STATUS = "RG";
                            nDAL.FIRSTMEALREGIS = registerMeal;
                            nDAL.FIRSTDATEREGIS = registerDate;
                        }
                        nDAL.ISREGISTER = "Y";
                        nDAL.REGISTERDATE = DateTime.Now;

                        ret = nDAL.UpdateCurrentData(userID, trans.Trans);
                    }
                    if (!ret)
                    {
                        _error = mDAL.ErrorMessage;
                        break;
                    }
                }
                if (ret)
                    trans.CommitTransaction();
                else
                    trans.RollbackTransaction();
            }
            catch (Exception ex)
            {
                ret = false;
                _error = ex.Message;
                trans.RollbackTransaction();
            }
            return ret;
        }

        public bool NonRegister(ArrayList arrData, string reason, string userID)
        {
            zTran trans = new zTran();
            bool ret = true;
            trans.CreateTransaction();
            try
            {
                for (int i = 0; i < arrData.Count; ++i)
                {
                    string[] arrLoid = arrData[i].ToString().Split('#');
                    OrderMedicalSetDAL mDAL = new OrderMedicalSetDAL();
                    mDAL.GetDataByLOID(Convert.ToDouble(arrLoid[0]), trans.Trans);
                    if (mDAL.OnDB)
                    {
                        mDAL.UNREGISREASON = reason;

                        ret = mDAL.UpdateCurrentData(userID, trans.Trans);
                    }
                    if (!ret)
                    {
                        _error = mDAL.ErrorMessage;
                        break;
                    }
                    OrderNonMedicalDAL nDAL = new OrderNonMedicalDAL();
                    nDAL.GetDataByLOID(Convert.ToDouble(arrLoid[1]), trans.Trans);
                    if (nDAL.OnDB)
                    {
                        nDAL.UNREGISREASON = reason;

                        ret = nDAL.UpdateCurrentData(userID, trans.Trans);
                    }
                    if (!ret)
                    {
                        _error = mDAL.ErrorMessage;
                        break;
                    }
                }
                if (ret)
                    trans.CommitTransaction();
                else
                    trans.RollbackTransaction();
            }
            catch (Exception ex)
            {
                ret = false;
                _error = ex.Message;
                trans.RollbackTransaction();
            }
            return ret;
        }

    }
}
