using System;
using System.Collections.Generic;
using System.Text;
using System.Data;
using SHND.DAL.Utilities;
using System.Collections;
using SHND.DAL.Tables;
using SHND.Data.Tables;
using SHND.Data.Views;
using SHND.DAL.Views;
//using DB = SHND.DAL.Utilities.OracleDB;
using zTran = SHND.DAL.Utilities.OracleTransactionDB;

/// <summary>
/// Supplier Class
/// Version 1.0
/// =========================================================================
/// Create by: Somsakoon
/// Create Date: 10 Feb 2009
/// -------------------------------------------------------------------------
/// Modify By: -
/// Modify From: -
/// Modify Date: -
/// -------------------------------------------------------------------------
/// Remark: -
/// Description:
///    Flow จัดการการทำงานของหน้า  ToDoList 
/// Changes:
///    1.0 - สร้าง
/// -------------------------------------------------------------------------
/// =========================================================================
/// </summary>
/// 

namespace SHND.Flow.Inventory
{
  public class ToDoListFlow
    {
        string _error = "";
        public string ErrorMessage { get { return _error; } }

        public DataTable GetMasterList(string Code, string Codet, DateTime Date, DateTime Datet, string Status, string Statust, string OrderText)
        {
            VStockOutDAL vDAL = new VStockOutDAL();
//            return vDAL.GetDataListByConditions(0,0, 0, Code, Codet, Date, Datet, new DateTime(), new DateTime(), Status, Statust, OrderText, null);
            return vDAL.GetDataToDoList(Code, Codet, Date, Datet, Status, Statust, OrderText, null);
        }
        public DataTable GetMasterListMin(string Code , string  Warehouse, string OrderText)
        {
            VToDoListMinStockDAL vDAL = new VToDoListMinStockDAL();
          return vDAL.GetDataListByMinCondition(Code, Warehouse, OrderText, null);
        }

      






    }
}
