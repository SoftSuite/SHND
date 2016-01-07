using System;
using System.Collections.Generic;
using System.Text;
using System.Data;
using SHND.DAL.Tables;
using SHND.DAL.Views;
using SHND.Data.Tables;
using SHND.DAL.Utilities;
using System.Collections;
using SHND.Data.Views;
//using DB = SHND.DAL.Utilities.OracleDB;
using zTran = SHND.DAL.Utilities.OracleTransactionDB;


/// <summary>
/// Supplier Class
/// Version 1.0
/// =========================================================================
/// Create by: Somsakoon
/// Create Date: 2 Feb 2009
/// -------------------------------------------------------------------------
/// Modify By: -
/// Modify From: -
/// Modify Date: -
/// -------------------------------------------------------------------------
/// Remark: -
/// Description:
///    Flow จัดการการทำงานของหน้า SystemMenuSearch 
/// Changes:
///    1.0 - สร้าง
/// -------------------------------------------------------------------------
/// =========================================================================
/// </summary>
/// 

namespace SHND.Flow.Admin
{
  public class SystemMenuSearchFlow
    {
        string _error = "";
        public string ErrorMessage { get { return _error; } }

        public DataTable GetMasterList()
        {
            VSystemMenuSearchDAL vDAL = new VSystemMenuSearchDAL();
            return vDAL.GetDataList("", "", null);

        }

      public DataTable GetMasterList(double Name, string MenuName, double Group, string OrderText)
      {
          VSystemMenuSearchDAL vDAL = new VSystemMenuSearchDAL();
          return vDAL.GetDataListByCondition(Name, MenuName, Group, OrderText, null);
      }

      public bool InsertData(VSystemMenuSearchData  ftData, string UserID)
      {

          ZMenuDAL ftDAL = new ZMenuDAL();

          ftDAL.ENABLED = (ftData.ENABLED  ? "Y" : "N");
          ftDAL.DESCRIPTION = ftData.DESCRIPTION;
          ftDAL.LINK = ftData.LINK;
          ftDAL.LOID = ftData.LOID;
          ftDAL.MENUNAME = ftData.MENUNAME;
          ftDAL.ZSYSTEM = ftData.ZSYSTEM;
          ftDAL.PARENT = ftData.PARENT;
          ftDAL.MENUGROUP = ftData.MENUGROUP;
          ftDAL.SEQUENCE = ftData.SEQUENCE;

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

      public bool DeleteByLOID(double  LOID)
      {
          zTran trans = new zTran();

          ZMenuDAL fDAL = new ZMenuDAL();
          trans.CreateTransaction();
          bool ret = true;
          try
          {
              fDAL.DeleteDataByLOID(LOID, trans.Trans);
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

      public VSystemMenuSearchData  GetDetails(double LOID)
      {
          VSystemMenuSearchDAL fDAL = new VSystemMenuSearchDAL();
          VSystemMenuSearchData fData = new VSystemMenuSearchData();

          fDAL.GetDataByLOID(LOID, null);
          if (fDAL.OnDB)
          {
              fData.ENABLED = (fDAL.ENABLED == "Y");
              fData.DESCRIPTION = fDAL.DESCRIPTION;
              fData.LINK = fDAL.LINK;
              fData.MENUNAME = fDAL.MENUNAME;
              fData.SYSTEMNAME = fDAL.SYSTEMNAME;
              fData.LOID = fDAL.LOID;
              fData.SUBMENU = fDAL.SUBMENU;
              fData.ZSYSTEM = fDAL.ZSYSTEM;
              fData.PARENT = fDAL.PARENT;
              fData.MENUGROUP = fDAL.MENUGROUP;
              fData.SEQUENCE = fDAL.SEQUENCE;
          }
          else
              _error = Data.Common.Utilities.DataResources.MSGEV002;

          return fData;

      }

      public bool UpdateData(VSystemMenuSearchData ftData, string UserID)
      {
          ZMenuDAL ftDAL = new ZMenuDAL();

          ftDAL.GetDataByLOID(ftData.LOID, null);

          ftDAL.ENABLED = (ftData.ENABLED ? "Y" : "N");
          ftDAL.DESCRIPTION = ftData.DESCRIPTION;
          ftDAL.LINK = ftData.LINK;
          ftDAL.MENUNAME = ftData.MENUNAME;
          ftDAL.ZSYSTEM = ftData.ZSYSTEM;
          ftDAL.PARENT = ftData.PARENT;
          ftDAL.MENUGROUP = ftData.MENUGROUP;
          ftDAL.SEQUENCE = ftData.SEQUENCE;

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
