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
/// Create Date: 26 Jan 2009
/// -------------------------------------------------------------------------
/// Modify By: -
/// Modify From: -
/// Modify Date: -
/// -------------------------------------------------------------------------
/// Remark: -
/// Description:
///    Flow จัดการการทำงานของหน้า DivisionSearch 
/// Changes:
///    1.0 - สร้าง
/// -------------------------------------------------------------------------
/// =========================================================================
/// </summary>
/// 



namespace SHND.Flow.Inventory
{
  public class DivisionSearchFlow
    {

        string _error = "";
        public string ErrorMessage { get { return _error; } }

        public DataTable GetMasterList()
        {
            VDivisionSeacrhDAL vDAL = new VDivisionSeacrhDAL();
            return vDAL.GetDataList("", "", null);

        }

        public DataTable GetMasterList(string Code, string OrderText)
        {
            VDivisionSeacrhDAL vDAL = new VDivisionSeacrhDAL();
            return vDAL.GetDataListByCondition(Code, OrderText, null);
           
        }


      public bool UpdateData(VDivisionSeacrhData ftData, string UserID)
      {
          DivisionDAL ftDAL = new DivisionDAL();
          
          ftDAL.GetDataByLOID(ftData.LOID, null);

          ftDAL.CODE = ftData.CODE;
          ftDAL.NAME = ftData.NAME;
          ftDAL.MAINDIVISION = ftData.MAINDIVISION;
          ftDAL.ACTIVE = (ftData.ACTIVE ? "1" : "0");

          ftDAL.ISDIRECTOR = (ftData.ISDIRECTOR ? "Y" : "N");
          ftDAL.ISFORMULA = (ftData.ISFORMULA ? "Y" : "N");
          ftDAL.ISNUTRIENT = (ftData.ISNUTRIENT ? "Y" : "N");
          ftDAL.ISONLINEREQUEST = (ftData.ISONLINEREQUEST ? "Y" : "N");
          ftDAL.ISPARTY = (ftData.ISPARTY ? "Y" : "N");
          ftDAL.ISPLAN =( ftData.ISPLAN ? "Y" : "N");
          ftDAL.ISSTOCKOUT = (ftData.ISSTOCKOUT ? "Y" : "N");
          ftDAL.ISSUBDIVISION = (ftData.ISSUBDIVISION ? "Y" : "N");
          ftDAL.ISWELFARE = (ftData.ISWELFARE ? "Y" : "N");
         

          

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


      public bool InsertData(VDivisionSeacrhData  ftData, string UserID)
      {
          bool ret = true;
          DivisionDAL ftDAL = new DivisionDAL();
          ftDAL.LOID = ftData.LOID;
          ftDAL.CODE = ftData.CODE;
          ftDAL.NAME = ftData.NAME;
          ftDAL.ACTIVE = (ftData.ACTIVE ? "1" : "0");
          ftDAL.ISDIRECTOR = (ftData.ISDIRECTOR ? "Y" : "N");
          ftDAL.ISFORMULA = (ftData.ISFORMULA ? "Y" : "N");
          ftDAL.ISNUTRIENT = (ftData.ISNUTRIENT ? "Y" : "N");
          ftDAL.ISONLINEREQUEST = (ftData.ISONLINEREQUEST ? "Y" : "N");
          ftDAL.ISPARTY = (ftData.ISPARTY ? "Y" : "N");
          ftDAL.ISPLAN = (ftData.ISPLAN ? "Y" : "N");
          ftDAL.ISSTOCKOUT = (ftData.ISSTOCKOUT ? "Y" : "N");
          ftDAL.ISSUBDIVISION = (ftData.ISSUBDIVISION ? "Y" : "N");
          ftDAL.ISWELFARE = (ftData.ISWELFARE ? "Y" : "N");
          ftDAL.MAINDIVISION = ftData.MAINDIVISION;

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

      public VDivisionSeacrhData GetDetails(double LOID)
      {
          VDivisionSeacrhDAL fDAL = new VDivisionSeacrhDAL();
          VDivisionSeacrhData fData = new VDivisionSeacrhData();
          fDAL.GetDataByLOID(LOID, null);
          if (fDAL.OnDB)
          {
              fData.ACTIVE = (fDAL.ACTIVE == "1");
              fData.CODE = fDAL.CODE;
              fData.DIACTIVE = (fDAL.DIACTIVE == "1");
              fData.ISDIRECTOR = (fDAL.ISDIRECTOR == "Y");
              fData.ISFORMULA = (fDAL.ISFORMULA == "Y");
              fData.ISNUTRIENT = (fDAL.ISNUTRIENT == "Y");
              fData.ISONLINEREQUEST = (fDAL.ISONLINEREQUEST == "Y");
              fData.ISPARTY = (fDAL.ISPARTY == "y");
              fData.ISPLAN = (fDAL.ISPLAN == "Y");
              fData.ISSTOCKOUT = (fDAL.ISSTOCKOUT == "Y");
              fData.ISSUBDIVISION = (fDAL.ISSUBDIVISION == "Y");
              fData.ISWELFARE = (fDAL.ISWELFARE == "Y"); 
              fData.LOID = fDAL.LOID;
              fData.MAINDIVISION = fDAL.MAINDIVISION;
              fData.MAINDIVISIONNAME = fDAL.MAINDIVISIONNAME;
              fData.NAME = fDAL.NAME;
          }
          else
              _error = Data.Common.Utilities.DataResources.MSGEV002;

          return fData;

      }



      public bool DeleteByLOID(ArrayList arrLOID)
      {
          zTran trans = new zTran();

          DivisionDAL   fDAL = new DivisionDAL();
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
          VDivisionSeacrhDAL fDAL = new VDivisionSeacrhDAL();
          fDAL.GetDataByNAME(cNAME, null);
          return !fDAL.OnDB || (cLOID == fDAL.LOID.ToString());
      }


    }
}
