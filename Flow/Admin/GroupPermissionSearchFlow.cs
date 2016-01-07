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
/// Create Date: 3 Feb 2009
/// -------------------------------------------------------------------------
/// Modify By: -
/// Modify From: -
/// Modify Date: -
/// -------------------------------------------------------------------------
/// Remark: -
/// Description:
///    Flow จัดการการทำงานของหน้า GroupPermissionSearch 
/// Changes:
///    1.0 - สร้าง
/// -------------------------------------------------------------------------
/// =========================================================================
/// </summary>
/// 

namespace SHND.Flow.Admin
{
  public  class GroupPermissionSearchFlow
    {

        string _error = "";
        public string ErrorMessage { get { return _error; } }

        public DataTable GetMasterList()
        {
            VSystemMenuSearchDAL vDAL = new VSystemMenuSearchDAL();
            return vDAL.GetDataList("", "", null);

        }

        public DataTable GetMasterList(string Group , string OrderText)
        {
            VGroupPermissionsearchDAL vDAL = new VGroupPermissionsearchDAL();
            return vDAL.GetDataListByCondition(Group, OrderText, null);
        }

      public bool DeleteByLOID(double LOID)
      {
          zTran trans = new zTran();

          ZRoleDAL fDAL = new ZRoleDAL();
          ZRoleAssignDAL ZDAL = new ZRoleAssignDAL();
          trans.CreateTransaction();
          bool ret = true;
          try
          {
              ZDAL.DeleteDataByZROLE(LOID, trans.Trans);
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
      public bool InsertData(ZRoleData ftData, string UserID)
      {
          zTran trans = new zTran();
            trans.CreateTransaction();

            bool ret = true;

            try
            {

              ZRoleDAL ftDAL = new ZRoleDAL();
             
              ZMenuData  ZMenu = new ZMenuData ();
              ftDAL.LOID = ftData.LOID;
              ftDAL.CREATEBY = ftData.CREATEBY;
              ftDAL.CREATEON = ftData.CREATEON;
              ftDAL.DESCRIPTION = ftData.DESCRIPTION;
              ftDAL.OFFICER = ftData.OFFICER;
              ftDAL.ZLEVEL = ftData.ZLEVEL;
        
          
              ret = ftDAL.InsertCurrentData(UserID, trans.Trans);
               if (!ret) _error = ftDAL.ErrorMessage;
               if (ret)
               {
                   ZRoleAssignDAL ZRoleAssign;
                   for (int i = 0; i < ftData.RoleAssign.Count; ++i)
                   {
                      // ZRoleAssignData zData = (ZRoleAssignData)ftData.RoleAssign[i];
                       ZRoleAssign = new ZRoleAssignDAL();
                       ZRoleAssign.ZROLE = ftDAL.LOID;
                       ZRoleAssign.ZMENU = Convert.ToDouble(ftData.RoleAssign[i]);
                       ret = ZRoleAssign.InsertCurrentData(UserID, trans.Trans);
                       if (!ret)
                       {
                           _error = ZRoleAssign.ErrorMessage;
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
      public bool UpdateData(ZRoleData ftData, string UserID)
      {
          zTran trans = new zTran();
          trans.CreateTransaction();

          bool ret = true;

          try
          {

              ZRoleDAL ftDAL = new ZRoleDAL();
              ftDAL.GetDataByLOID(ftData.LOID, trans.Trans);
              ftDAL.DESCRIPTION = ftData.DESCRIPTION;
              ftDAL.OFFICER = ftData.OFFICER;
              ftDAL.ZLEVEL = ftData.ZLEVEL;


              ret = ftDAL.UpdateCurrentData(UserID, trans.Trans);
              if (!ret) _error = ftDAL.ErrorMessage;
              if (ret)
              {
                  ZRoleAssignDAL ZRoleAssign;
                  ZRoleAssign = new ZRoleAssignDAL();
                  ZRoleAssign.DeleteDataByZROLE(ftDAL.LOID, trans.Trans);
                  for (int i = 0; i < ftData.RoleAssign.Count; ++i)
                  {
                      
                      ZRoleAssign = new ZRoleAssignDAL();
                      ZRoleAssign.ZROLE = ftDAL.LOID;
                      ZRoleAssign.ZMENU = Convert.ToDouble(ftData.RoleAssign[i]);
                      ret = ZRoleAssign.InsertCurrentData(UserID, trans.Trans);
                      if (!ret)
                      {
                          _error = ZRoleAssign.ErrorMessage;
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
      public ZRoleData GetDetails(double LOID)
      {
           ZRoleDAL  fDAL = new ZRoleDAL();
           ZMenuDAL ZMenu = new ZMenuDAL();
           ZRoleData fData = new ZRoleData ();
           ZRoleAssignDAL zDAL = new ZRoleAssignDAL();
            fDAL.GetDataByLOID(LOID, null);
            fData.DESCRIPTION = fDAL.DESCRIPTION;
            fData.LOID = fDAL.LOID;
           
           
            return fData;

      }


    }
}
