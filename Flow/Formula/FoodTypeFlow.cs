using System;
using System.Collections.Generic;
using System.Text;
using System.Data;
using SHND.DAL.Formula;
using SHND.Data.Formula;
using SHND.DAL.Utilities;
using System.Collections;
//using DB = SHND.DAL.Utilities.OracleDB;
using zTran = SHND.DAL.Utilities.OracleTransactionDB;

/// <summary>
/// FoodTypeFlow Class
/// Version 1.0
/// =========================================================================
/// Create by: TurBoZ
/// Create Date: 25 Dec 2008
/// -------------------------------------------------------------------------
/// Modify By: -
/// Modify From: -
/// Modify Date: -
/// -------------------------------------------------------------------------
/// Remark: -
/// Description:
///    Flow จัดการการทำงานของหน้า FoodType 
/// Changes:
///    1.0 - สร้าง
/// -------------------------------------------------------------------------
/// =========================================================================
/// </summary>
/// 

namespace SHND.Flow.Formula
{
    public class FoodTypeFlow
    {

        string _error = "";
        public string ErrorMessage { get { return _error; } }


        public DataTable GetMasterList( string Code, string Name, string Division, string OrderText )
        {
            VFoodTypeDAL vDAL = new VFoodTypeDAL();
            return vDAL.GetDataListByCondition(Code, Name, Division, OrderText, null);
        }

        public DataTable GetMasterList()
        {
            VFoodTypeDAL vDAL = new VFoodTypeDAL();
            return vDAL.GetDataList("", "", null);
        }

        public DataTable GetMasterListByCondition(string Code, string Name, string Devision)
        {
            string whStr = "";
            // create where condition


            VFoodTypeDAL vDAL = new VFoodTypeDAL();
            return vDAL.GetDataList(whStr, "", null);
        }

        public DataTable GetMasterListSorted(string SortField, string SortDirection)
        {
            VFoodTypeDAL vDAL = new VFoodTypeDAL();
            return vDAL.GetDataList("", SortField + " " + SortDirection, null);
        }

        public bool InsertData(FoodTypeData ftData, string UserID)
        {
            FoodTypeDAL ftDAL = new FoodTypeDAL();
            ftDAL.CODE = ftData.CODE;
            ftDAL.NAME = ftData.NAME;
            ftDAL.DIVISION = ftData.DIVISION;
            ftDAL.ACTIVE = (ftData.ACTIVE ? "1" : "0");
            ftDAL.ISNURSE = (ftData.ISNURSE ? "Y" : "N");


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

        public bool UpdateData(FoodTypeData ftData, string UserID)
        {
            FoodTypeDAL ftDAL = new FoodTypeDAL();
            ftDAL.GetDataByLOID(ftData.LOID, null);

            ftDAL.CODE = ftData.CODE;
            ftDAL.NAME = ftData.NAME;
            ftDAL.DIVISION = ftData.DIVISION;
            ftDAL.ACTIVE = (ftData.ACTIVE ? "1" : "0");
            ftDAL.ISNURSE = (ftData.ISNURSE ? "Y" : "N");
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

        public FoodTypeData GetDetails(double LOID)
        {
            FoodTypeDAL fDAL = new FoodTypeDAL();
            FoodTypeData fData = new FoodTypeData();
            fDAL.GetDataByLOID(LOID, null);
            if (fDAL.OnDB)
            {
                fData.CODE = fDAL.CODE;
                fData.NAME = fDAL.NAME;
                fData.DIVISION = fDAL.DIVISION;
                fData.ACTIVE = (fDAL.ACTIVE == "1");
                fData.LOID = fDAL.LOID;
                fData.PRICE = fDAL.PRICE;
                fData.PRICETYPE = fDAL.PRICETYPE;
                fData.ISNURSE = (fDAL.ISNURSE == "Y");
            }
            else
                _error = Data.Common.Utilities.DataResources.MSGEV002;

            return fData;

        }

        public bool DeleteByLOID(ArrayList arrLOID)
        {
            zTran trans = new zTran();

            FoodTypeDAL fDAL = new FoodTypeDAL();
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

        public bool CheckUniqCode(string cCODE, string cLOID)
        {
            FoodTypeDAL fDAL = new FoodTypeDAL();
            fDAL.GetDataByCODE(cCODE, null);
            return !fDAL.OnDB || (cLOID == fDAL.LOID.ToString());
        }

        public bool CheckUniqName(string cNAME, string cLOID)
        {
            FoodTypeDAL fDAL = new FoodTypeDAL();
            fDAL.GetDataByNAME(cNAME, null);
            return !fDAL.OnDB || (cLOID == fDAL.LOID.ToString());
        }

    }
}
