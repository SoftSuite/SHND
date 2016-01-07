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
///    ����ͧ�Ѻ����Դ Error ...  
/// Changes:
///    1.0 - ���ҧ
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
            // �ѧ�����Դ
            ex.Message.ToString();
        }
    }
}
