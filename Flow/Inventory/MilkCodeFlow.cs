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
/// Create Date: 28 Jan 2009
/// -------------------------------------------------------------------------
/// Modify By: -
/// Modify From: -
/// Modify Date: -
/// -------------------------------------------------------------------------
/// Remark: -
/// Description:
///    Flow จัดการการทำงานของหน้า  Milkcode 
/// Changes:
///    1.0 - สร้าง
/// -------------------------------------------------------------------------
/// =========================================================================
/// </summary>
/// 



namespace SHND.Flow.Inventory
{
  public class MilkCodeFlow
    {
        string _error = "";
        public string ErrorMessage { get { return _error; } }

      

        public DataTable GetMasterList()
        {
            MilkCodeDAL vDAL = new MilkCodeDAL();
            return vDAL.GetDataList("", "", null);

        }

       public DataTable GetMasterList(double Name, string OrderText)
        {
            VMilkCodeSearchDAL vDAL = new VMilkCodeSearchDAL();
            return vDAL.GetDataListByCondition(Name,OrderText, null);

        }

      public DataTable GetMilkCodeDiseaseList(double  ward)
      {
          VMilkCodeDAL VStdMenuDisease = new VMilkCodeDAL();
          DataTable dt = VStdMenuDisease.GetDataListByStdMenu(ward, "MILKCODE", null);
          for (int i = 0; i < dt.Rows.Count; ++i)
          {
              dt.Rows[i]["LOID"] = i + 1;
          }
          return dt;
      }

      public bool InsertData(double ward, ArrayList arrData, string userID)
      {
          string milkCOdeList = "";
          bool ret = true;
          zTran trans = new zTran();
          trans.CreateTransaction();

          MilkCodeDAL MilkItem = new MilkCodeDAL();
          try
          {
              for (int i = 0; i < arrData.Count; ++i)
              {
                  VMilkCodeData MilkData = (VMilkCodeData)arrData[i];
                  milkCOdeList += (milkCOdeList == "" ? "" : ",") + "'" + MilkData.MILKCODE + "'";
              }
              MilkItem.DeleteDataByConditions(ward, milkCOdeList, trans.Trans);
              for (int i = 0; i < arrData.Count; ++i)
              {
                  VMilkCodeData MilkData = (VMilkCodeData)arrData[i];
                  MilkItem = new MilkCodeDAL();
                  MilkItem.GetDataByConditions(ward, MilkData.MILKCODE, trans.Trans);
                  MilkItem.MILKCODE = MilkData.MILKCODE;
                  MilkItem.WARD = ward;
                  if (MilkItem.OnDB)
                      ret = MilkItem.UpdateCurrentData(userID, trans.Trans);
                  else
                      ret = MilkItem.InsertCurrentData(userID, trans.Trans);

                  if (!ret)
                  {
                      _error = MilkItem.ErrorMessage;
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
              ret = false;
              trans.RollbackTransaction();
              _error = ex.Message;
          }
          return ret;
      }

      public bool InsertData(VMilkCodeData ftData, string UserID)
      {
          zTran trans = new zTran();
            trans.CreateTransaction();

            bool ret = true;

            try
            {

          VMilkCodeDAL ftDAL = new VMilkCodeDAL();
          MilkCodeDAL MilkCode = new MilkCodeDAL();
          MilkCodeData MilkCodeD = new MilkCodeData();
          MilkCode.CREATEBY = MilkCodeD.CREATEBY;
          MilkCode.CREATEON = MilkCodeD.CREATEON;
          //MilkCode.WARD = MilkCodeD.WARD;
          MilkCode.UPDATEBY = MilkCodeD.UPDATEBY;
          MilkCode.UPDATEON = MilkCodeD.UPDATEON;
          ftDAL.WARD = ftData.WARD;

         

          if (ret)
          {
              MilkCodeDAL MilkItem;
              for (int i = 0; i < ftData.MilkCodeList.Count; ++i)
              {
                  VMilkCodeData MilkData = (VMilkCodeData)ftData.MilkCodeList[i];
                  MilkItem = new MilkCodeDAL();
                  MilkItem.LOID  = ftDAL.LOID;
                  MilkItem.MILKCODE = MilkData.MILKCODE;
                  MilkItem.WARD = MilkData.WARD;
                  
                  ret = MilkItem.InsertCurrentData(UserID, trans.Trans);
                  if (!ret)
                  {
                      _error = MilkItem.ErrorMessage;
                      break;
                  }

              }
          }

            if (ret)
                    trans.CommitTransaction();
                else
                    trans.RollbackTransaction();
          }
            catch (Exception ex)
            {
                ret = false;
                _error = ex.Message;
            }

            return ret;
        }

      public bool UpdateData(VMilkCodeData ftData, string UserID)
      { 
          zTran trans = new zTran();
            trans.CreateTransaction();

            bool ret = true;

            try
            {
                VMilkCodeDAL ftDAL = new VMilkCodeDAL();
                MilkCodeDAL MilkCode = new MilkCodeDAL();
                MilkCodeData MilkCodeD = new MilkCodeData();
                MilkCode.CREATEBY = MilkCodeD.CREATEBY;
                MilkCode.CREATEON = MilkCodeD.CREATEON;
                MilkCode.UPDATEBY = MilkCodeD.UPDATEBY;
                MilkCode.UPDATEON = MilkCodeD.UPDATEON;
                ftDAL.WARD = ftData.WARD;

                if (ret)
                {
                    MilkCodeDAL MilkItem;
                    for (int i = 0; i < ftData.MilkCodeList.Count; ++i)
                    {
                        VMilkCodeData MilkData = (VMilkCodeData)ftData.MilkCodeList[i];
                        MilkItem = new MilkCodeDAL();
                        MilkItem.LOID = ftDAL.LOID;
                        MilkItem.MILKCODE = MilkData.MILKCODE;
                        MilkItem.WARD = MilkData.WARD;

                        ret = MilkItem.UpdateCurrentData (UserID, trans.Trans);
                        if (!ret)
                        {
                            _error = MilkItem.ErrorMessage;
                            break;
                        }

                    }
                }

                if (ret)
                    trans.CommitTransaction();
                else
                    trans.RollbackTransaction();
            }
            catch (Exception ex)
            {
                ret = false;
                _error = ex.Message;
            }

            return ret;
      
      }

      public DataTable GetMasterListByWard(double Ward)
      {
          VMilkCodeDAL vDAL = new VMilkCodeDAL();
          DataTable dt = vDAL.GetDataListByWard(Ward, "LOID", null);
         
          for (int i = 0; i < dt.Rows.Count; ++i)
          {
              dt.Rows[i]["MILKCODE"] = Convert.ToDouble(dt.Rows[i]["LOID"]);
          }
          return dt;
      }


      public bool DeleteByLOID(ArrayList arrLOID)
      {
          zTran trans = new zTran();

          MilkCodeDAL fDAL = new MilkCodeDAL();
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
      public bool DeleteByWARD(ArrayList arrLOID)
      {
          zTran trans = new zTran();

          MilkCodeDAL fDAL = new MilkCodeDAL();
          trans.CreateTransaction();
          bool ret = true;
          try
          {
              for (int i = 0; i < arrLOID.Count; i++)
              {
                  fDAL.DeleteDataByWARD(Convert.ToDouble(arrLOID[i]), trans.Trans);
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

      public VMilkCodeData GetDetails(double LOID, double WARD)
      {
          VMilkCodeDAL fDAL = new VMilkCodeDAL();
          VMilkCodeData fData = new VMilkCodeData();

          fDAL.GetDataByLOID(LOID, null);
          if (fDAL.OnDB)
          {
              fData.LOID = Convert.ToDouble(fDAL.GetDataByLOID(LOID, null));
              fData.WARD = fDAL.WARD;
              
              fData.MILKCODE = fDAL.MILKCODE;
              fData.MilkCodeTable = fDAL.GetDataByWard(LOID,fData.WARD, "WARD", null);
          }
          else
              _error = Data.Common.Utilities.DataResources.MSGEV002;

          return fData;

      }
      

    }
}
