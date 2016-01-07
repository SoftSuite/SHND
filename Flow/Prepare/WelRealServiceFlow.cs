using System;
using System.Collections.Generic;
using System.Text;
using System.Data;
using SHND.DAL.Views;
using SHND.DAL.Tables;
using SHND.Data.Tables;
using SHND.DAL.Utilities;
using SHND.DAL.Functions;
using System.Collections;
//using DB = SHND.DAL.Utilities.OracleDB;
using zTran = SHND.DAL.Utilities.OracleTransactionDB;

/// <summary>
/// WelRealServiceFlow Class
/// Version 1.0
/// =========================================================================
/// Create by: Tan
/// Create Date: 22 Jun 2009
/// -------------------------------------------------------------------------
/// Modify By: -
/// Modify From: -
/// Modify Date: -
/// -------------------------------------------------------------------------
/// Remark: -
/// Description:
///    Flow จัดการการทำงานของหน้า WelRealService 
/// Changes:
///    1.0 - สร้าง
/// -------------------------------------------------------------------------
/// =========================================================================
/// </summary>
/// 

namespace SHND.Flow.Prepare
{
    public class WelRealServiceFlow
    {

        string _error = "";
        public string ErrorMessage { get { return _error; } }


        public DataTable GetMasterList( DateTime DateFrom, DateTime DateTo, string Division, string OrderText )
        {
            VWelfareRealServiceDAL vDAL = new VWelfareRealServiceDAL();
            return vDAL.GetDataListByCondition(DateFrom, DateTo, Division, OrderText, null);
        }

        //public DataTable GetMasterList()
        //{
        //    VFoodTypeDAL vDAL = new VFoodTypeDAL();
        //    return vDAL.GetDataList("", "", null);
        //}

        //public DataTable GetMasterListByCondition(string Code, string Name, string Devision)
        //{
        //    string whStr = "";
        //    // create where condition


        //    VFoodTypeDAL vDAL = new VFoodTypeDAL();
        //    return vDAL.GetDataList(whStr, "", null);
        //}

        //public DataTable GetMasterListSorted(string SortField, string SortDirection)
        //{
        //    VFoodTypeDAL vDAL = new VFoodTypeDAL();
        //    return vDAL.GetDataList("", SortField + " " + SortDirection, null);
        //}

        public bool InsertData(WelfareRealServiceData ftData, string UserID)
        {
            WelfareRealServiceDAL ftDAL = new WelfareRealServiceDAL();
            ftDAL.COUPON = ftData.COUPON;
            ftDAL.DIVISION = ftData.DIVISION;
            ftDAL.SERVICEDATE = ftData.SERVICEDATE;
            ftDAL.TIFFIN = ftData.TIFFIN;

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

        public bool UpdateData(WelfareRealServiceData ftData, string UserID)
        {
            WelfareRealServiceDAL ftDAL = new WelfareRealServiceDAL();
            ftDAL.GetDataByLOID(ftData.LOID, null);

            ftDAL.COUPON = ftData.COUPON;
            ftDAL.DIVISION = ftData.DIVISION;
            ftDAL.SERVICEDATE = ftData.SERVICEDATE;
            ftDAL.TIFFIN = ftData.TIFFIN;
           
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

        public WelfareRealServiceData GetDetails(double LOID)
        {
            VWelfareRealServiceDAL fDAL = new VWelfareRealServiceDAL();
            WelfareRealServiceData fData = new WelfareRealServiceData();
            fDAL.GetDataByLOID(LOID, null);
            if (fDAL.OnDB)
            {
                fData.COUPON = fDAL.COUPON;
                fData.DIVISION = fDAL.DIVISION;
                fData.SERVICEDATE = fDAL.SERVICEDATE;
                fData.LOID = fDAL.LOID;
                fData.TIFFIN = fDAL.TIFFIN;
                fData.GETCOUPON = fDAL.GETCOUPON;
                fData.GETTIFFIN = fDAL.GETTIFFIN;
            }
            else
                _error = Data.Common.Utilities.DataResources.MSGEV002;

            return fData;

        }

        public bool DeleteByLOID(ArrayList arrLOID)
        {
            zTran trans = new zTran();

            WelfareRealServiceDAL fDAL = new WelfareRealServiceDAL();
            trans.CreateTransaction();
            bool ret = true;
            try
            {
                for (int i = 0; i < arrLOID.Count; i++)
                {
                    fDAL.DeleteDataByLOID(Convert.ToDouble(arrLOID[i]), trans.Trans);
                }
                trans.CommitTransaction();
            }
            catch (Exception ex){
                _error = ex.Message;
                ret = false;
                trans.RollbackTransaction();
            }

            return ret;

        }

        public bool CheckUniqCode(DateTime cDate, string cDivision, string cLOID)
        {
            WelfareRealServiceDAL fDAL = new WelfareRealServiceDAL();
            fDAL.GetDataByUniq(cDate,cDivision, null);
            return !fDAL.OnDB || (cLOID == fDAL.LOID.ToString());
        }
        public double GetRightQty(DateTime vDate, double vDivision, string vTiffin)
        {
            FunctionDAL getRightQty = new FunctionDAL();
            return getRightQty.GetWelfareRightQty(vDate, vDivision, vTiffin, null);
        }


    }
}
