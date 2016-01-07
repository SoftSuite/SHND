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
/// Create Date: 5 Jan 2009
/// -------------------------------------------------------------------------
/// Modify By: -
/// Modify From: -
/// Modify Date: -
/// -------------------------------------------------------------------------
/// Remark: -
/// Description:
///    Flow จัดการการทำงานของหน้า Supplier 
/// Changes:
///    1.0 - สร้าง
/// -------------------------------------------------------------------------
/// =========================================================================
/// </summary>
/// 

namespace SHND.Flow.Inventory
{
    public class SupplierFlow
    {
        string _error = "";
        public string ErrorMessage { get { return _error; } }

     public DataTable GetMasterList( string Code, string Name, string Division, string OrderText )
        {
           // SupplierDAL  vDAL = new SupplierDAL ();
            VSupplierDAL vDAL = new VSupplierDAL();
          return vDAL.GetDataListByCondition(Code, Name, Division, OrderText, null);
           
        }

        public DataTable GetMasterList()
        {
            VSupplierDAL vDAL = new VSupplierDAL();
            return vDAL.GetDataList("", "", null);
        }

       
        public DataTable GetMasterListByCondition(string Code, string Name, string Devision)
        {
            string whStr = "";
            // create where condition


            SupplierDAL  vDAL = new SupplierDAL ();
            return vDAL.GetDataList(whStr, "", null);
        }

        public DataTable GetMasterListSorted(string SortField, string SortDirection)
        {
            SupplierDAL  vDAL = new SupplierDAL ();
            return vDAL.GetDataList("", SortField + " " + SortDirection, null);
        }

        public bool InsertData(SupplierData  ftData, string UserID)
        {
            SupplierDAL  ftDAL = new SupplierDAL ();
       //     ftDAL.ACTIVE = ftData.ACTIVE;
            ftDAL.ACTIVE = (ftData.ACTIVE ? "1" : "0");
            ftDAL .ADDRESS = ftData .ADDRESS ;
            ftDAL.AMPHUR = ftData.AMPHUR;
            ftDAL.CODE = ftData.CODE;
            ftDAL.CONTACTNAME = ftData.CONTACTNAME;
            ftDAL.CREATEBY = ftData.CREATEBY;
            ftDAL.CREATEON = ftData.CREATEON;
            ftDAL.EMAIL = ftData.EMAIL;
            ftDAL.FAX = ftData.FAX;
            ftDAL.LOID = ftData.LOID;
            ftDAL.MOBILE = ftData.MOBILE;
            ftDAL.NAME = ftData.NAME;
            ftDAL.PROVINCE = ftData.PROVINCE;
            ftDAL.REMARKS = ftData.REMARKS;
            ftDAL.ROAD = ftData.ROAD;
            ftDAL.TAMBOL = ftData.TAMBOL;
            ftDAL.TEL = ftData.TEL;
            ftDAL.UPDATEBY = ftData.UPDATEBY;
            ftDAL.UPDATEON = ftData.UPDATEON;
            ftDAL.ZIPCODE = ftData.ZIPCODE;

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

        public bool UpdateData(SupplierData  ftData, string UserID)
        {
            SupplierDAL  ftDAL = new SupplierDAL ();
            ftDAL.GetDataByLOID(ftData.LOID, null);

          
               ftDAL.ACTIVE = (ftData.ACTIVE ? "1" : "0");
            ftDAL.ADDRESS = ftData.ADDRESS;
            ftDAL.AMPHUR = ftData.AMPHUR;
            ftDAL.CODE = ftData.CODE;
            ftDAL.CONTACTNAME = ftData.CONTACTNAME;
            ftDAL.CREATEBY = ftData.CREATEBY;
            ftDAL.CREATEON = ftData.CREATEON;
            ftDAL.EMAIL = ftData.EMAIL;
            ftDAL.FAX = ftData.FAX;
            ftDAL.LOID = ftData.LOID;
            ftDAL.MOBILE = ftData.MOBILE;
            ftDAL.NAME = ftData.NAME;
            ftDAL.PROVINCE = ftData.PROVINCE;
            ftDAL.REMARKS = ftData.REMARKS;
            ftDAL.ROAD = ftData.ROAD;
            ftDAL.TAMBOL = ftData.TAMBOL;
            ftDAL.TEL = ftData.TEL;
            ftDAL.UPDATEBY = ftData.UPDATEBY;
            ftDAL.UPDATEON = ftData.UPDATEON;
            ftDAL.ZIPCODE = ftData.ZIPCODE;
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

        public SupplierData  GetDetails(double LOID)
        {
            SupplierDAL  fDAL = new SupplierDAL ();
            SupplierData  fData = new SupplierData ();
            fDAL.GetDataByLOID(LOID, null);
            if (fDAL.OnDB)
            {

                fData.ACTIVE = (fDAL.ACTIVE == "1");
                fData.ADDRESS = fDAL.ADDRESS;
                fData.AMPHUR = fDAL.AMPHUR;
                fData.CODE = fDAL.CODE;
                fData.CONTACTNAME = fDAL.CONTACTNAME;
                fData.CREATEBY = fDAL.CREATEBY;
                fData.CREATEON = fDAL.CREATEON;
                fData.EMAIL = fDAL.EMAIL;
                fData.FAX = fDAL.FAX;
                fData.LOID = fDAL.LOID;
                fData.MOBILE = fDAL.MOBILE;
                fData.NAME = fDAL.NAME;
                fData.PROVINCE = fDAL.PROVINCE;
                fData.REMARKS = fDAL.REMARKS;
                fData.ROAD = fDAL.ROAD;
                fData.TAMBOL = fDAL.TAMBOL;
                fData.TEL = fDAL.TEL;
                fData.UPDATEBY = fDAL.UPDATEBY;
                fData.UPDATEON = fDAL.UPDATEON;
                fData.ZIPCODE = fDAL.ZIPCODE;


            }
            else
                _error = Data.Common.Utilities.DataResources.MSGEV002;

            return fData;

        }

        public bool DeleteByLOID(ArrayList arrLOID)
        {
            zTran trans = new zTran();

            SupplierDAL  fDAL = new SupplierDAL ();
            trans.CreateTransaction();
            bool ret = true;
            try
            {
                for (int i = 0; i < arrLOID.Count; i++)
                {
                   // fDAL.DeleteCurrentData(Convert .ToDouble (arrLOID [i]), trans.Trans);
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
            SupplierDAL  fDAL = new SupplierDAL ();
            fDAL.GetDataByNAME(cNAME, null);
          //  fDAL.GetDataByCODE(cCODE, null);
            return !fDAL.OnDB || (cLOID == fDAL.LOID.ToString());
        }

    }
}
