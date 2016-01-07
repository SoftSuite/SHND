using System;
using System.Collections.Generic;
using System.Text;

/// <summary>
/// ErrorHandle Class
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
///    ไว้รองรับการเกิด Error ...  
/// Changes:
///    1.0 - สร้าง
/// -------------------------------------------------------------------------
/// =========================================================================
/// </summary>
/// 

namespace SHND.Flow.Common
{
    public class ErrorHandle
    {
        public static void RecordError(Exception ex)
        {
            // ยังไม่ได้คิด
            ex.Message.ToString();
        }
    }
}
