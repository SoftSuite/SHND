using System;
using System.Collections.Generic;
using System.Text;
using System.Data;
using SHND.DAL.Tables;
using SHND.DAL.Views;
using SHND.Data.Tables;
using SHND.DAL.Utilities;
using System.Collections;
//using DB = SHND.DAL.Utilities.OracleDB;
using zTran = SHND.DAL.Utilities.OracleTransactionDB;

/// <summary>
/// FoodTypeFlow Class
/// Version 1.0
/// =========================================================================
/// Create by: Tan
/// Create Date: 25 Dec 2008
/// -------------------------------------------------------------------------
/// Modify By: -
/// Modify From: -
/// Modify Date: -
/// -------------------------------------------------------------------------
/// Remark: -
/// Description:
///    Flow จัดการการทำงานของหน้า MilkCategory 
/// Changes:
///    1.0 - สร้าง
/// -------------------------------------------------------------------------
/// =========================================================================
/// </summary>
/// 

namespace SHND.Flow.Formula
{
    public class MilkCategoryFlow
    {
        string _error = "";
        public string ErrorMessage { get { return _error; } }

        public DataTable GetMasterList()
        {
            VMilkCategoryDAL vDAL = new VMilkCategoryDAL();
            return vDAL.GetDataList("", "", null);
        }

        public DataTable GetMasterList(string Name, string Code,string OrderText)
        {
            VMilkCategoryDAL vDAL = new VMilkCategoryDAL();
            return vDAL.GetDataListByCondition(Name,Code,OrderText, null);
        }

        public DataTable GetMasterListByCondition(string Code, string Name, string Devision)
        {
            string whStr = "";
            // create where condition


            VMilkCategoryDAL vDAL = new VMilkCategoryDAL();
            return vDAL.GetDataList(whStr, "", null);
        }

        public DataTable GetMasterListSorted(string SortField, string SortDirection)
        {
            VMilkCategoryDAL vDAL = new VMilkCategoryDAL();
            return vDAL.GetDataList("", SortField + " " + SortDirection, null);
        }

        public bool InsertData(MilkCategoryData mcData, string UserID)
        {
            MilkCategoryDAL mcDAL = new MilkCategoryDAL();
            mcDAL.CODE = mcData.CODE;
            mcDAL.NAME = mcData.NAME;
            mcDAL.ISSPECIFIC = (mcData.ISSPECIFIC ? "Y" : "N");
            mcDAL.ACTIVE = (mcData.ACTIVE ? "1" : "0");

            bool ret = true;

            try
            {
                ret = mcDAL.InsertCurrentData(UserID, null);
                if (!ret) _error = mcDAL.ErrorMessage;
            }
            catch (Exception ex)
            {
                ret = false;
                _error = ex.Message;
            }

            return ret;
        }

        public bool UpdateData(MilkCategoryData mcData, string UserID)
        {
            MilkCategoryDAL mcDAL = new MilkCategoryDAL();
            mcDAL.GetDataByLOID(mcData.LOID, null);

            mcDAL.CODE = mcData.CODE;
            mcDAL.NAME = mcData.NAME;
            mcDAL.ISSPECIFIC = (mcData.ISSPECIFIC ? "Y" : "N");
            mcDAL.ACTIVE = (mcData.ACTIVE ? "1" : "0");
            bool ret = true;

            try
            {
                if (mcDAL.OnDB)
                {
                    ret = mcDAL.UpdateCurrentData(UserID, null);
                    if (!ret) _error = mcDAL.ErrorMessage;

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

        public MilkCategoryData GetDetails(double LOID)
        {
            MilkCategoryDAL mcDAL = new MilkCategoryDAL();
            MilkCategoryData mcData = new MilkCategoryData();
            mcDAL.GetDataByLOID(LOID, null);
            if (mcDAL.OnDB)
            {
                mcData.CODE = mcDAL.CODE;
                mcData.NAME = mcDAL.NAME;
                mcData.ISSPECIFIC = (mcDAL.ISSPECIFIC == "Y");
                mcData.ACTIVE = (mcDAL.ACTIVE == "1");
                mcData.LOID = mcDAL.LOID;
            }
            else
                _error = Data.Common.Utilities.DataResources.MSGEV002;

            return mcData;

        }

        public bool DeleteByLOID(ArrayList arrLOID)
        {
            zTran trans = new zTran();

            MilkCategoryDAL mcDAL = new MilkCategoryDAL();
            trans.CreateTransaction();
            bool ret = true;
            try
            {
                for (int i = 0; i < arrLOID.Count; i++)
                {
                    mcDAL.DeleteDataByLOID(Convert.ToDouble(arrLOID[i]), trans.Trans);
                }
                trans.CommitTransaction();
            }
            catch (Exception ex)
            {
                _error = ex.Message;
                ret = false;
                trans.RollbackTransaction();
            }

            return ret;

        }

        public bool CheckUniqCode(string cNAME, string cLOID)
        {
            MilkCategoryDAL mcDAL = new MilkCategoryDAL();
            mcDAL.GetDataByNAME(cNAME, null);
            return !mcDAL.OnDB || (cLOID == mcDAL.LOID.ToString());
        }

    }
}