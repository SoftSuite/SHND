using System;
using System.Collections.Generic;
using System.Text;
using zTran = SHND.DAL.Utilities.OracleTransactionDB;
using System.Data;
using SHND.DAL.Views;
using SHND.Data.Views;
using SHND.DAL.Tables;
using SHND.Data.Tables;
using System.Collections;

/// <summary>
/// NpoOrderSetFlow Class
/// Version 1.0
/// =========================================================================
/// Create by: Nang
/// Create Date: 31 Mar 2009
/// -------------------------------------------------------------------------
/// Modify By: -
/// Modify From: -
/// Modify Date: -
/// -------------------------------------------------------------------------
/// Remark: -
/// Description:
///    Flow จัดการการทำงานของหน้า NpoOrderSet
/// Changes:
///    1.0 - สร้าง
/// -------------------------------------------------------------------------
/// =========================================================================
/// </summary>
/// 

namespace SHND.Flow.Prepare
{
    public class NpoOrderSetFlow
    {
        public DataTable GetNpoOrderSetList(double ward, string pname, DateTime orderDateFrom, DateTime orderDateTo, string orderType,  string orderBy)
        {
            VOrderNpoDAL vDAL = new VOrderNpoDAL();

            return vDAL.GetDataListByConditions(ward, pname, orderDateFrom, orderDateTo, orderType, orderBy,null);
        }

    }
}
