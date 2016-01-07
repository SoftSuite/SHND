using System;
using System.Collections.Generic;
using System.Text;
using System.Data;
using SHND.DAL.Utilities;

/// <summary>
/// ComboSourceDAL Class
/// Version 1.0
/// =========================================================================
/// Create by: TurBoZ
/// Create Date: 25 Dec 2008
/// -------------------------------------------------------------------------
/// Modify By: -
/// Modify From: -
/// Modify Date: -
/// -------------------------------------------------------------------------
/// Remark: -
/// Description:
///    DAL จัดการข้อมูลสำหรับใช้ทำ Datasource ของ ComboBox 
/// Changes:
///    1.0 - สร้าง
/// -------------------------------------------------------------------------
/// =========================================================================
/// </summary>
/// 

namespace SHND.DAL.Common
{
    public class ComboSourceDAL
    {
        public DataTable GetComboSource(string TableName, string DisplayField, string ValueField, string WhereString, string OrderString, bool doDistinct)
        {
            string sqlz = " SELECT " + (doDistinct ? " DISTINCT " : "") + DisplayField + " as NAME, " + ValueField + " as VALUE FROM " + TableName + " ";
            if (WhereString.Trim() != "") sqlz += " WHERE " + WhereString + " ";
            if (OrderString.Trim() != "") sqlz += " ORDER BY " + OracleDB.SetSortString(OrderString) + " ";
            return OracleDB.ExecuteTable(sqlz);
        }
    }
}
