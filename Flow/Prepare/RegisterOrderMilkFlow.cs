using System;
using System.Collections;
using System.Collections.Generic;
using System.Data;
using System.Text;
using zTran = SHND.DAL.Utilities.OracleTransactionDB;
using SHND.DAL.Prepare;
using SHND.DAL.Tables;

/// <summary>
/// RegisterOrderMilkFlow Class
/// Version 1.0
/// =========================================================================
/// Create by: Teang
/// Create Date: 10 Apr 2009
/// -------------------------------------------------------------------------
/// Modify By: -
/// Modify From: -
/// Modify Date: -
/// -------------------------------------------------------------------------
/// Remark: -
/// Description:
///    Flow จัดการการทำงานของหน้า Register การสั่งอาหารประเภทนม
/// Changes:
///    1.0 - สร้าง
/// -------------------------------------------------------------------------
/// =========================================================================
/// </summary>
/// 
namespace SHND.Flow.Prepare
{
    public class RegisterOrderMilkFlow
    {
        string _error = "";
        public string ErrorMessage { get { return _error; } }

        public DataTable GetRegisterList(DateTime date, double ward, double milkCategory, string patientName, DateTime orderDateFrom, DateTime orderDateTo, string orderBy)
        {
            VRegisterOrderMilkDAL sDAL = new VRegisterOrderMilkDAL();
            return sDAL.GetDataListByConditions(date, ward, milkCategory, patientName, orderDateFrom, orderDateTo, orderBy, null);
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
                    OrderMilkDAL mDAL = new OrderMilkDAL();
                    string[] arr = arrData[i].ToString().Split('#');
                    mDAL.GetDataByLOID(Convert.ToDouble(arr[0]), trans.Trans);
                    if (mDAL.OnDB)
                    {
                        if (mDAL.STATUS != "RG")
                        {
                            mDAL.STATUS = "RG";
                            mDAL.FIRSTMEALREGIS = registerMeal;
                            mDAL.FIRSTDATEREGIS = registerDate;
                        }
                        mDAL.MILKCODE = Convert.ToDouble(arr[1]);
                        mDAL.ISREGISTER = "Y";
                        mDAL.REGISTERDATE = DateTime.Now;

                        ret = mDAL.UpdateCurrentData(userID, trans.Trans);
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
