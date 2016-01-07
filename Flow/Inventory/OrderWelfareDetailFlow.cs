using System;
using System.Collections.Generic;
using System.Text;
using System.Data;
using SHND.DAL.Tables;
using SHND.DAL.Views;
using SHND.Data.Tables;
using SHND.Data.Inventory;
using SHND.DAL.Utilities;
using System.Collections;
//using DB = SHND.DAL.Utilities.OracleDB;
using zTran = SHND.DAL.Utilities.OracleTransactionDB;

/// <summary>
/// Supplier Class
/// Version 1.0
/// =========================================================================
/// Create by: Somsakoon
/// Create Date: 13 Jan 2009
/// -------------------------------------------------------------------------
/// Modify By: -
/// Modify From: -
/// Modify Date: -
/// -------------------------------------------------------------------------
/// Remark: -
/// Description:
///    Flow จัดการการทำงานของหน้า OrderWelfareDetail 
/// Changes:
///    1.0 - สร้าง
/// -------------------------------------------------------------------------
/// =========================================================================
/// </summary>
/// 

namespace SHND.Flow.Inventory
{
   public class OrderWelfareDetailFlow
    {
        string _error = "";
        public string ErrorMessage { get { return _error; } }

        public DataTable GetMasterList()
        {
            orderwelfaredetailDAL vDAL = new orderwelfaredetailDAL();
            return vDAL.GetDataList("", "", null);

        }


       public bool InsertData(VOrderWelfareData  ftData, string UserID)
       {
           orderwelfaredetailDAL  ftDAL = new orderwelfaredetailDAL ();
           OrderWelfareDAL fDAL = new OrderWelfareDAL();
           ftDAL.BD1 = ftData.BD1;
           ftDAL.BD2 = ftData.BD2;
           ftDAL.BD3 = ftData.BD3;
           ftDAL.BD4 = ftData.BD4;
           ftDAL.BD5 = ftData.BD5;
           ftDAL.BD6 = ftData.BD6;
           ftDAL.BD7 = ftData.BD7;

           ftDAL.LD1 = ftData.LD1;
           ftDAL.LD2 = ftData.LD2;
           ftDAL.LD3 = ftData.LD3;
           ftDAL.LD4 = ftData.LD4;
           ftDAL.LD5 = ftData.LD5;
           ftDAL.LD6 = ftData.LD6;
           ftDAL.LD7 = ftData.LD7;

           ftDAL.DD1 = ftData.DD1;
           ftDAL.DD2 = ftData.DD2;
           ftDAL.DD3 = ftData.DD3;
           ftDAL.DD4 = ftData.DD4;
           ftDAL.DD5 = ftData.DD5;
           ftDAL.DD6 = ftData.DD6;
           ftDAL.DD7 = ftData.DD7;
          

           fDAL.CREATEBY = ftData.CREATEBY;
         
           fDAL.ORDERCODE = ftData.ORDERCODE;
           fDAL.ORDERDATE = ftData.ORDERDATE;
           fDAL.REFCODE = ftData.REFCODE;
           fDAL.REFDATE = ftData.REFDATE;
           fDAL.STARTDATE = ftData.STARTDATE;
           fDAL.STATUS = ftData.STATUS;
           
           
           
        
          





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

       public orderwelfaredetailData  GetDetails(double LOID)
       {
           orderwelfaredetailDAL  fDAL = new orderwelfaredetailDAL ();
           orderwelfaredetailData  fData = new orderwelfaredetailData ();

           fDAL.GetDataByLOID(LOID, null);
           if (fDAL.OnDB)
           {
               fData.BD1 = fDAL.BD1;
               fData.BD2 = fDAL.BD2;
               fData.BD3 = fDAL.BD3;
               fData.BD4 = fDAL.BD4;
               fData.BD5 = fDAL.BD5;
               fData.BD6 = fDAL.BD6;
               fData.BD7 = fDAL.BD7;

               fData.LD1 = fDAL.LD1;
               fData.LD2 = fDAL.LD2;
               fData.LD3 = fDAL.LD3;
               fData.LD4 = fDAL.LD4;
               fData.LD5 = fDAL.LD5;
               fData.LD6 = fDAL.LD6;
               fData.LD7 = fDAL.LD7;

               fData.DD1 = fDAL.DD1;
               fData.DD2 = fDAL.DD2;
               fData.DD3 = fDAL.DD3;
               fData.DD4 = fDAL.DD4;
               fData.DD5 = fDAL.DD5;
               fData.DD6 = fDAL.DD6;
               fData.DD7 = fDAL.DD7;

               fData.LOID = fDAL.LOID;
               fData.CREATEBY = fDAL.CREATEBY;
               fData.CREATEON = fDAL.CREATEON;
               fData.ORDERWELFARE = fDAL.ORDERWELFARE;
               fData.UPDATEBY = fDAL.UPDATEBY;
               fData.UPDATEON = fDAL.UPDATEON;


           }
           else
               _error = Data.Common.Utilities.DataResources.MSGEV002;

           return fData;

       }

    }
}
