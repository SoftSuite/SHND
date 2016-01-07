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
/// Create Date: 8 Jan 2009
/// -------------------------------------------------------------------------
/// Modify By: -
/// Modify From: -
/// Modify Date: -
/// -------------------------------------------------------------------------
/// Remark: -
/// Description:
///    Flow จัดการการทำงานของหน้า OrderWelfare 
/// Changes:
///    1.0 - สร้าง
/// -------------------------------------------------------------------------
/// =========================================================================
/// </summary>
/// 

namespace SHND.Flow.Inventory
{
    class OderWelfareFlow
    {

        string _error = "";
        public string ErrorMessage { get { return _error; } }

        public DataTable GetMasterList(string Code, string Name, string Division, string OrderText)
        {
            // SupplierDAL  vDAL = new SupplierDAL ();
            VSupplierDAL vDAL = new VSupplierDAL();
            return vDAL.GetDataListByCondition(Code, Name, Division, OrderText, null);

        }

        public DataTable GetMasterList()
        {
            VSupplierDAL vDAL = new VSupplierDAL();
            return vDAL.GetDataList("", "", null);
        }

    }
}
