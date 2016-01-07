using System;
using System.Collections.Generic;
using System.Text;
using System.Data;
using SHND.DAL.Tables;
using SHND.Data.Tables;
using System.Collections;
using zTran = SHND.DAL.Utilities.OracleTransactionDB;

/// <summary>
/// FoodCategoryFlow Class
/// Version 1.0
/// =========================================================================
/// Create by: Nang
/// Create Date: 26 Dec 2008
/// -------------------------------------------------------------------------
/// Modify By: -
/// Modify From: -
/// Modify Date: -
/// -------------------------------------------------------------------------
/// Remark: -
/// Description:
///    Flow จัดการการทำงานของหน้า FoodCatagory 
/// Changes:
///    1.0 - สร้าง
/// -------------------------------------------------------------------------
/// =========================================================================
/// </summary>
/// 

namespace SHND.Flow.Formula
{
    public class FoodCategoryFlow
    {

        string _error = "";
        public string ErrorMessage { get { return _error; } }


        public DataTable GetCategorySearch(string type,string ordertext)
        {
            FoodCategoryDAL FDal = new FoodCategoryDAL();
            DataTable dt = new DataTable();
            string wr = "";
            if(type != "")
                wr = wr +" UPPER(NAME) LIKE UPPER('%" + type +"%')";

            dt = FDal.GetDataListByField(wr, ordertext, null);

            
            return dt;
        }

        public FoodCategoryData GetDetails(double LOID)
        {
            FoodCategoryDAL fDAL = new FoodCategoryDAL();
            FoodCategoryData fData = new FoodCategoryData();
            fDAL.GetDataByLOID(LOID, null);
            if (fDAL.OnDB)
            {
                fData.CODE = fDAL.CODE;
                fData.NAME = fDAL.NAME;
                fData.ACTIVE = (fDAL.ACTIVE == "1");
                fData.LOID = fDAL.LOID;
            }
            else
                _error = Data.Common.Utilities.DataResources.MSGEU002;

            return fData;

        }

        public bool DeleteByLOID(ArrayList arrLOID)
        {
            zTran trans = new zTran();

            FoodCategoryDAL fDAL = new FoodCategoryDAL();
            trans.CreateTransaction();
            bool ret = true;
            try
            {
                for (int i = 0; i < arrLOID.Count; i++)
                {
                    ret = fDAL.DeleteDataByLOID(Convert.ToDouble(arrLOID[i]), trans.Trans);
                    if (!ret)
                    {
                        ret = false;
                        _error = fDAL.ErrorMessage;
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
                _error = ex.Message;
                ret = false;
                trans.RollbackTransaction();
            }
            return ret;
        }

        public bool CheckUniqCode(string cCODE, string cLOID)
        {
            FoodCategoryDAL fDAL = new FoodCategoryDAL();
            fDAL.GetDataByCODE(cCODE, null);
            return !fDAL.OnDB || (cLOID == fDAL.LOID.ToString());
        }

        public bool CheckUniqName(string cName, string cLOID)
        {
            FoodCategoryDAL fDAL = new FoodCategoryDAL();
            fDAL.GetDataByNAME(cName, null);
            return !fDAL.OnDB || (cLOID == fDAL.LOID.ToString());
        }

        public bool InsertData(FoodCategoryData ftData, string UserID)
        {
            FoodCategoryDAL ftDAL = new FoodCategoryDAL();
            ftDAL.CODE = ftData.CODE;
            ftDAL.NAME = ftData.NAME;
            ftDAL.ACTIVE = (ftData.ACTIVE ? "1" : "0");

            bool ret = true;

            try
            {
                ret = ftDAL.InsertCurrentData(UserID, null);
                if (!ret) _error = ftDAL.ErrorMessage;
            }
            catch (Exception ex)
            {
                ret = false;
                _error = ex.Message;
            }

            return ret;
        }

        public bool UpdateData(FoodCategoryData ftData, string UserID)
        {
            FoodCategoryDAL ftDAL = new FoodCategoryDAL();
            ftDAL.GetDataByLOID(ftData.LOID, null);

            ftDAL.CODE = ftData.CODE;
            ftDAL.NAME = ftData.NAME;
            ftDAL.ACTIVE = (ftData.ACTIVE ? "1" : "0");
            bool ret = true;

            try
            {
                if (ftDAL.OnDB)
                {
                    ret = ftDAL.UpdateCurrentData(UserID, null);
                    if (!ret) _error = ftDAL.ErrorMessage;

                    return ret;
                }
                else
                {
                    _error = Data.Common.Utilities.DataResources.MSGEU002;
                    return false;
                }
            }
            catch (Exception ex)
            {
                _error = ex.Message;
                return false;
            }

        }
       

    }
}
