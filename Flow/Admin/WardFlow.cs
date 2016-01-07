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
/// Create Date: 30 Jan 2009
/// -------------------------------------------------------------------------
/// Modify By: -
/// Modify From: -
/// Modify Date: -
/// -------------------------------------------------------------------------
/// Remark: -
/// Description:
///    Flow จัดการการทำงานของหน้า Ward 
/// Changes:
///    1.0 - สร้าง
/// -------------------------------------------------------------------------
/// =========================================================================
/// </summary>
/// 


namespace SHND.Flow.Admin
{
  public class WardFlow
    {
        string _error = "";
        public string ErrorMessage { get { return _error; } }

        public DataTable GetMasterList()
        {
            VWardSearchDAL vDAL = new VWardSearchDAL();
            return vDAL.GetDataList("", "", null);

        }

        public DataTable GetMasterList(string Code, string OrderText)
        {
            VWardSearchDAL vDAL = new VWardSearchDAL();
            return vDAL.GetDataListByCondition(Code, OrderText, null);

        }

      public DataTable GetWardList(double officer)
      {
          VWardResponseDAL VWard = new VWardResponseDAL();
          DataTable dt = VWard.GetDataListByOfficer(officer, "PRIORITY", null);
          dt.Columns.Add("RANK", typeof(double));
          for (int i = 0; i < dt.Rows.Count; ++i)
          {
              dt.Rows[i]["RANK"] = i + 1;
          }
          return dt;
      }

      public bool InsertData(WardData  ftData, string UserID)
      {
          WardDAL ftDAL = new WardDAL();
          ftDAL .ABBNAME = ftData .ABBNAME ;
          ftDAL.ACTIVE = (ftData.ACTIVE ? "1" : "0");
          ftDAL.ISLOCKCUTOFFTIME = (ftData.ISLOCKCUTOFFTIME ? "Y" : "N");
          ftDAL.BEDQTY = ftData.BEDQTY;
          ftDAL.CODE = ftData.CODE;
          ftDAL.CREATEBY = ftData.CREATEBY;
          ftDAL.CREATEON = ftData.CREATEON;
          ftDAL.DEFAULTFOODTYPE = ftData.DEFAULTFOODTYPE;
          ftDAL.LOID = ftData.LOID;
          ftDAL.NAME = ftData.NAME;
          ftDAL.UPDATEBY = ftData.UPDATEBY;
          ftDAL.UPDATEON = ftData.UPDATEON;
          ftDAL.SAPCODE = ftData.SAPCODE;
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

          WardDAL fDAL = new WardDAL();
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

      public WardData GetDetails(double LOID)
      {
          WardDAL fDAL = new WardDAL();
          WardData fData = new WardData();
        
          fDAL.GetDataByLOID(LOID, null);
          if (fDAL.OnDB)
          {
              fData.ABBNAME = fDAL.ABBNAME;
              fData.ACTIVE = (fDAL.ACTIVE == "1");
              fData.ISLOCKCUTOFFTIME = (fDAL.ISLOCKCUTOFFTIME == "Y");
              fData.BEDQTY = fDAL.BEDQTY;
              fData.CODE = fDAL.CODE;
              fData.CREATEBY = fDAL.CREATEBY;
              fData.CREATEON = fDAL.CREATEON;
              fData.DEFAULTFOODTYPE = fDAL.DEFAULTFOODTYPE;
              fData.LOID = fDAL.LOID;
              fData.NAME = fDAL.NAME;
              fData.UPDATEBY = fDAL.UPDATEBY;
              fData.UPDATEON = fDAL.UPDATEON;
              fData.SAPCODE = fDAL.SAPCODE;

          }
          else
              _error = Data.Common.Utilities.DataResources.MSGEV002;

          return fData;

      }

      public bool UpdateData(WardData ftData, string UserID)
      {
          WardDAL ftDAL = new WardDAL();

          ftDAL.GetDataByLOID(ftData.LOID, null);
          ftDAL.ABBNAME = ftData.ABBNAME;
          ftDAL.ACTIVE = (ftData.ACTIVE ? "1" : "0");
          ftDAL.ISLOCKCUTOFFTIME = (ftData.ISLOCKCUTOFFTIME ? "Y" : "N");
          ftDAL.BEDQTY = ftData.BEDQTY;
          ftDAL.CODE = ftData.CODE;
          ftDAL.CREATEBY = ftData.CREATEBY;
          ftDAL.CREATEON = ftData.CREATEON;
          ftDAL.DEFAULTFOODTYPE = ftData.DEFAULTFOODTYPE;
          ftDAL.UPDATEBY = ftData.UPDATEBY;
          ftDAL.UPDATEON = ftData.UPDATEON;
          ftDAL.NAME = ftData.NAME;
          ftDAL.SAPCODE = ftData.SAPCODE;
        
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








      public bool CheckUniqCode(string cCODE, string cLOID)
      {
          WardDAL fDAL = new WardDAL();
          fDAL.GetDataByCODE(cCODE, null);
          return !fDAL.OnDB || (cLOID == fDAL.LOID.ToString());
      }
      public bool CheckUniqName(string cNAME, string cLOID)
      {
          WardDAL fDAL = new WardDAL();
          fDAL.GetDataByNAME(cNAME, null);
          return !fDAL.OnDB || (cLOID == fDAL.LOID.ToString());
      }
      public bool CheckUniqABBName(string cABBNAME, string cLOID)
      {
          WardDAL fDAL = new WardDAL();
          fDAL.GetDataByABBNAME(cABBNAME, null);
          return !fDAL.OnDB || (cLOID == fDAL.LOID.ToString());
      }

    }
}
