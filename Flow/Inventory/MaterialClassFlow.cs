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
/// Supplier Class
/// Version 1.0
/// =========================================================================
/// Create by: Somsakoon
/// Create Date: 22 Jan 2009
/// -------------------------------------------------------------------------
/// Modify By: -
/// Modify From: -
/// Modify Date: -
/// -------------------------------------------------------------------------
/// Remark: -
/// Description:
///    Flow จัดการการทำงานของหน้า MaterialClass 
/// Changes:
///    1.0 - สร้าง
/// -------------------------------------------------------------------------
/// =========================================================================
/// </summary>
/// 


namespace SHND.Flow.Inventory
{
    public class MaterialClassFlow
    {
        string _error = "";
        public string ErrorMessage { get { return _error; } }

        public DataTable GetMasterList()
        {
            VMaterialClassDAL vDAL = new VMaterialClassDAL();
            return vDAL.GetDataList("", "", null);

        }

        public DataTable GetMasterList(string Code, string OrderText)
        {
            VMaterialClassDAL  vDAL = new VMaterialClassDAL ();
            return vDAL.GetDataListByCondition(Code,OrderText, null);
        }



        public bool InsertData(VMaterialClassData ftData, string UserID)
        {
               

                MaterialClassDAL ftDAL = new MaterialClassDAL();
                MaterialClassData MaterialClass = new MaterialClassData ();
                ftDAL.CODE = MaterialClass.CODE;
                ftDAL.NAME = ftData.NAME;
                ftDAL.ACTIVE = (ftData.ACTIVE ? "1" : "0");
                ftDAL.MASTERTYPE = ftData.MASTERTYPE;
                ftDAL.STOCKINTYPE = ftData.STOCKINTYPE;
                ftDAL.UPDATEBY = MaterialClass.UPDATEBY;
                ftDAL.UPDATEON = MaterialClass.UPDATEON;
                ftDAL.CREATEBY = MaterialClass.CREATEBY;
                ftDAL.CREATEON = MaterialClass.CREATEON; 


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


        public bool UpdateData(VMaterialClassData ftData, string UserID)
        {
            MaterialClassDAL ftDAL = new MaterialClassDAL();
           ftDAL.GetDataByLOID(ftData.LOID, null);

            ftDAL.CODE = ftData.CODE;
            ftDAL.NAME = ftData.NAME;
            ftDAL.STOCKINTYPE = ftData.STOCKINTYPE;
            ftDAL.MASTERTYPE = ftData.MASTERTYPE;
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



        public VMaterialClassData  GetDetails(double LOID)
        {
            VMaterialClassDAL fDAL = new VMaterialClassDAL();
            VMaterialClassData fData = new VMaterialClassData();
            fDAL.GetDataByLOID(LOID, null);
            if (fDAL.OnDB)
            {

                fData.LOID = fDAL.LOID;
                fData.CODE = fDAL.CODE;
                fData.ACTIVE = (fDAL.ACTIVE == "1");
                fData.ACTIVENAME = fDAL.ACTIVENAME;
                fData.MASTERTYPE = fDAL.MASTERTYPE;
                fData.MASTERTYPENAME = fDAL.MASTERTYPENAME;
                fData.NAME = fDAL.NAME;
                fData.STOCKINTYPE = fDAL.STOCKINTYPE;
                fData.STOCKINTYPENAME = fDAL.STOCKINTYPENAME;
                
            }
            else
                _error = Data.Common.Utilities.DataResources.MSGEV002;

            return fData;

        }

        public bool DeleteByLOID(ArrayList arrLOID)
        {
            zTran trans = new zTran();

            MaterialClassDAL fDAL = new MaterialClassDAL();
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
            VMaterialClassDAL fDAL = new VMaterialClassDAL();
            fDAL.GetDataByNAME(cNAME, null); 
            return !fDAL.OnDB || (cLOID == fDAL.LOID.ToString());
        }

    }
}
