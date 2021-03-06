using System;
using System.Collections.Generic;
using System.Text;
using System.Data;
using SHND.DAL.Views;
using SHND.DAL.Tables;
using SHND.Data.Views;
using SHND.Data.Tables;
using SHND.DAL.Utilities;
using System.Collections;
using zTran = SHND.DAL.Utilities.OracleTransactionDB;

/// <summary>
/// Supplier Class
/// Version 1.0
/// =========================================================================
/// Create by: Somsakoon
/// Create Date: 5 Feb 2009
/// -------------------------------------------------------------------------
/// Modify By: -
/// Modify From: -
/// Modify Date: -
/// -------------------------------------------------------------------------
/// Remark: -
/// Description:
///    Flow �Ѵ��á�÷ӧҹ�ͧ˹�� Nutrient 
/// Changes:
///    1.0 - ���ҧ
/// -------------------------------------------------------------------------
/// =========================================================================
/// </summary>
/// 


namespace SHND.Flow.Formula
{
  public class NutrientFlow
    {

      string _error = "";
      public string ErrorMessage { get { return _error; } }

      public DataTable GetMasterList()
        {
            VNutrientDAL vDAL = new VNutrientDAL();
            return vDAL.GetDataList("", "", null);

        }
      public DataTable GetMasterList(string Code, string OrderText)
        {
            VNutrientDAL vDAL = new VNutrientDAL();
            return vDAL.GetDataListByCondition(Code, OrderText, null);

        }
      public bool InsertData( NutrientData ftData, string UserID)
       {
           NutrientDAL ftDAL = new NutrientDAL();
         
              ftDAL.ACTIVE = (ftData.ACTIVE ? "1" : "0");
              ftDAL.CODE = ftData.CODE;
              ftDAL.NAME = ftData.NAME;
              ftDAL.UNIT = ftData.UNIT;
              
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

          NutrientDAL fDAL = new NutrientDAL();
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
      public bool UpdateData(NutrientData ftData, string UserID)
      {
          NutrientDAL ftDAL = new NutrientDAL();

          ftDAL.GetDataByLOID(ftData.LOID, null);
          ftDAL.ACTIVE = (ftData.ACTIVE ? "1" : "0");
          ftDAL.CODE = ftData.CODE;
          ftDAL.UNIT = ftData.UNIT;
          ftDAL.NAME = ftData.NAME;

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
      public NutrientData GetDetails(double LOID)
      {
          NutrientDAL fDAL = new NutrientDAL();
          NutrientData fData = new NutrientData();

          fDAL.GetDataByLOID(LOID, null);
          if (fDAL.OnDB)
          {
              
              fData.ACTIVE = (fDAL.ACTIVE == "1");
              fData.CODE = fDAL.CODE;
              fData.UNIT = fDAL.UNIT;
              fData.LOID = fDAL.LOID;
              fData.NAME = fDAL.NAME;
            

          }
          else
              _error = Data.Common.Utilities.DataResources.MSGEV002;

          return fData;

      }
      public bool CheckUniqCode(string cCODE, string cLOID)
      {
          NutrientDAL fDAL = new NutrientDAL();
          fDAL.GetDataByCODE(cCODE, null);
          return !fDAL.OnDB || (cLOID == fDAL.LOID.ToString());
      }
      public bool CheckUniqName(string cNAME, string cLOID)
       {
          NutrientDAL fDAL = new NutrientDAL();
          fDAL.GetDataByNAME(cNAME, null);
          return !fDAL.OnDB || (cLOID == fDAL.LOID.ToString());
       }
    }
}
