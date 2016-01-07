using System;
using System.Collections;
using System.Collections.Generic;
using System.Data;
using System.Text;
using zTran = SHND.DAL.Utilities.OracleTransactionDB;
using SHND.DAL.Prepare;
using SHND.DAL.Tables;

/// <summary>
/// RegisterOrderFeedFlow Class
/// Version 1.0
/// =========================================================================
/// Create by: Teang
/// Create Date: 3 Apr 2009
/// -------------------------------------------------------------------------
/// Modify By: -
/// Modify From: -
/// Modify Date: -
/// -------------------------------------------------------------------------
/// Remark: -
/// Description:
///    Flow �Ѵ��á�÷ӧҹ�ͧ˹�� Register ����������÷ҧ���
/// Changes:
///    1.0 - ���ҧ
/// -------------------------------------------------------------------------
/// =========================================================================
/// </summary>
/// 
namespace SHND.Flow.Prepare
{
    public class RegisterOrderFeedFlow
    {
        string _error = "";
        public string ErrorMessage { get { return _error; } }

        public DataTable GetRegisterList(DateTime date, double ward, string foodName, string patientName, DateTime orderDateFrom, DateTime orderDateTo, string orderBy)
        {
            VRegisterOrderFeedDAL sDAL = new VRegisterOrderFeedDAL();
            return sDAL.GetDataListByConditions(date, ward, foodName, patientName, orderDateFrom, orderDateTo, orderBy, null);
        }

        public DataTable GetNonRegisterList(DateTime date, double ward, string foodName, string patientName, DateTime orderDateFrom, DateTime orderDateTo, string orderBy)
        {
            VNonRegisterOrderFeedDAL sDAL = new VNonRegisterOrderFeedDAL();
            return sDAL.GetDataListByConditions(date, ward, foodName, patientName, orderDateFrom, orderDateTo, orderBy, null);
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
                    OrderMedicalFeedDAL mDAL = new OrderMedicalFeedDAL();
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
                    OrderMedicalFeedDAL mDAL = new OrderMedicalFeedDAL();
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
