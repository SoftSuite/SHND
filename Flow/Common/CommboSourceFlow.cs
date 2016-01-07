using System;
using System.Collections.Generic;
using System.Text;
using System.Data;
using SHND.DAL.Common;

/// <summary>
/// ComboSourceFlow Class
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
///    Flow จัดการข้อมูลสำหรับใช้ทำ Datasource ของ ComboBox 
/// Changes:
///    1.0 - สร้าง
/// -------------------------------------------------------------------------
/// =========================================================================
/// </summary>
/// 
namespace SHND.Flow.Common
{
    public class CommboSourceFlow
    {
        public DataTable GetComboSource(string TableName, string DisplayField, string ValueField, string WhereString, string OrderString, bool doDistinct)
        {
            DataTable ret = null;
            ComboSourceDAL cDAL = new ComboSourceDAL();

            try
            {
                ret = cDAL.GetComboSource(TableName, DisplayField, ValueField, WhereString, OrderString, doDistinct);
            }
            catch (Exception ex)
            {
                ret = new DataTable();
                ErrorHandle.RecordError(ex);
            }

            return ret;
        }

    }
}
