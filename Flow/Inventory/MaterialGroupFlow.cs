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
/// Create Date: 23 Jan 2009
/// -------------------------------------------------------------------------
/// Modify By: -
/// Modify From: -
/// Modify Date: -
/// -------------------------------------------------------------------------
/// Remark: -
/// Description:
///    Flow จัดการการทำงานของหน้า MaterialGroup 
/// Changes:
///    1.0 - สร้าง
/// -------------------------------------------------------------------------
/// =========================================================================
/// </summary>
/// 
namespace SHND.Flow.Inventory
{
  public class MaterialGroupFlow
    {
        string _error = "";
        public string ErrorMessage { get { return _error; } }

        public DataTable GetMasterList()
        {
            VMaterialGroupDAL vDAL = new VMaterialGroupDAL();
            return vDAL.GetDataList("", "", null);

        }

        public DataTable GetMasterList(string Code,string Group, string OrderText)
        {
            VMaterialGroupDAL vDAL = new VMaterialGroupDAL();
            return vDAL.GetDataListByCondition(Code,Group, OrderText, null);
            //return new DataTable();
        }


      public bool UpdateData(VMaterialGroupData ftData, string UserID)
      {
          MaterialGroupDAL ftDAL = new MaterialGroupDAL();
          ftDAL.GetDataByLOID(ftData.LOID, null);

          ftDAL.CODE = ftData.CODE;
          ftDAL.NAME = ftData.NAME;
          ftDAL.ACTIVE = (ftData.ACTIVE ? "1" : "0");
          ftDAL.MATERIALCLASS = ftData.MATERIALCLASS;

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


      public bool InsertData(VMaterialGroupData  ftData, string UserID)
      {


          MaterialGroupDAL ftDAL = new MaterialGroupDAL();
          MaterialGroupData MaterialGroup = new MaterialGroupData();
          ftDAL.CODE = ftData.CODE;
          ftDAL.NAME = ftData.NAME;
          ftDAL.ACTIVE = (ftData .ACTIVE ? "1" : "0");
          ftDAL.MATERIALCLASS = ftData.MATERIALCLASS;

          ftDAL.UPDATEBY = MaterialGroup.UPDATEBY;
          ftDAL.UPDATEON = MaterialGroup.UPDATEON;
          ftDAL.CREATEBY = MaterialGroup.CREATEBY;
          ftDAL.CREATEON = MaterialGroup.CREATEON;


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




      public VMaterialGroupData  GetDetails(double LOID)
      {
          VMaterialGroupDAL fDAL = new VMaterialGroupDAL();
          VMaterialGroupData fData = new VMaterialGroupData();
          fDAL.GetDataByLOID(LOID, null);
          if (fDAL.OnDB)
          {
              fData.ACTIVE = (fDAL.ACTIVE == "1");
              fData.ACTIVENAME = fDAL.ACTIVENAME;
              fData.CODE = fDAL.CODE;
              fData.LOID = fDAL.LOID;
              fData.MATERIALCLASS = fDAL.MATERIALCLASS;
              fData.MATERIALCLASSNAME = fDAL.MATERIALCLASSNAME;
              fData.NAME = fDAL.NAME;
             
              
              

          }
          else
              _error = Data.Common.Utilities.DataResources.MSGEV002;

          return fData;

      }




      public bool DeleteByLOID(ArrayList arrLOID)
      {
          zTran trans = new zTran();

          MaterialGroupDAL fDAL = new MaterialGroupDAL();
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
          VMaterialGroupDAL fDAL = new VMaterialGroupDAL();
          fDAL.GetDataByNAME(cNAME, null);
          return !fDAL.OnDB || (cLOID == fDAL.LOID.ToString());
      }



    }
}
