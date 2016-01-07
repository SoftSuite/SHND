using System;
using System.Collections.Generic;
using System.Text;
using System.Data;
using SHND.DAL.Tables;
using SHND.DAL.Views;
using SHND.Data.Tables;
using SHND.Data.Views;
using SHND.DAL.Utilities;
using System.Collections;
//using DB = SHND.DAL.Utilities.OracleDB;
using zTran = SHND.DAL.Utilities.OracleTransactionDB;


/// <summary>
/// Supplier Class
/// Version 1.0
/// =========================================================================
/// Create by: Somsakoon
/// Create Date: 27 Jan 2009
/// -------------------------------------------------------------------------
/// Modify By: -
/// Modify From: -
/// Modify Date: -
/// -------------------------------------------------------------------------
/// Remark: -
/// Description:
///    Flow จัดการการทำงานของหน้า  Holiday 
/// Changes:
///    1.0 - สร้าง
/// -------------------------------------------------------------------------
/// =========================================================================
/// </summary>
/// 
namespace SHND.Flow.Inventory
{
   public  class HolidayFlow
    {
        string _error = "";
        public string ErrorMessage { get { return _error; } }

        public DataTable GetMasterList()
        {
            HolidayDAL vDAL = new HolidayDAL();
            return vDAL.GetDataList("", "", null);

        }

       public DataTable GetMasterList(DateTime DStart, DateTime DEnd,  string OrderText)
        {
            VHolidayDAL vDAL = new VHolidayDAL();
            return vDAL.GetDataListByCondition(DStart, DEnd, OrderText, null);

        }
       public bool chkDupData(DateTime cHoliday, double cLOID)
       {
           HolidayDAL vDAL = new HolidayDAL();
           return vDAL.chkDupData(cHoliday, cLOID, null);
       }



        public bool InsertData(VHolidayData ftData, string UserID)
      {

            HolidayDAL ftDAL = new HolidayDAL();
            HolidayData Holiday = new HolidayData();

            ftDAL.ACTIVE = (ftData.ACTIVE ? "1" : "0");
            ftDAL.CREATEBY = Holiday.CREATEBY;
            ftDAL.CREATEON = Holiday.CREATEON;
            ftDAL.HOLIDAY = ftData.HOLIDAY;
            ftDAL.LOID = ftData.LOID;
            ftDAL.NAME = ftData.NAME;
            ftDAL.UPDATEBY = Holiday.UPDATEBY;
            ftDAL.UPDATEON = Holiday.UPDATEON;
          
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



       public bool DeleteByLOID(ArrayList arrLOID)
       {
           zTran trans = new zTran();

           HolidayDAL fDAL = new HolidayDAL();
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

       public VHolidayData  GetDetails(double LOID)
       {
           VHolidayDAL fDAL = new VHolidayDAL();
           VHolidayData fData = new VHolidayData();
          
           fDAL.GetDataByLOID(LOID, null);
           if (fDAL.OnDB)
           {
               fData.ACTIVE = (fDAL.ACTIVE == "1");
               fData.HOLIDAY = fDAL.HOLIDAY;
               fData.LOID = fDAL.LOID;
               fData.NAME = fDAL.NAME;
           }
           else
               _error = Data.Common.Utilities.DataResources.MSGEV002;

           return fData;

       }

       public bool UpdateData(VHolidayData ftData, string UserID)
      {
          HolidayDAL ftDAL = new HolidayDAL();

          ftDAL.GetDataByLOID(ftData.LOID, null);
           ftDAL.NAME = ftData.NAME;
           ftDAL.HOLIDAY = ftData.HOLIDAY;
           ftDAL.ACTIVE = ftDAL.ACTIVE = (ftData.ACTIVE ? "1" : "0");



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
