using System;
using System.Collections.Generic;
using System.Text;
using System.Data;
using SHND.DAL.Inventory;
using SHND.DAL.Views;

/// <summary>
/// SearchFlow Class
/// Version 1.0
/// =========================================================================
/// Create by: Pom
/// Create Date: 12 May 2009
/// -------------------------------------------------------------------------
/// Modify By: -
/// Modify From: -
/// Modify Date: -
/// -------------------------------------------------------------------------
/// Remark: -
/// Description:
///    Flow จัดการการทำงาน Search Popup หน้า PrepareReturn, PrepareWeightAfter
/// Changes:
///    1.0 - สร้าง
/// -------------------------------------------------------------------------
/// =========================================================================
/// </summary>
/// 

namespace SHND.Flow.Search
{
    public class MaterialPrepareFlow
    {
        public DataTable GetMaterialMasterList(string materialclass, string materialgroup, string materialname, string exceptKeyList, string orderstr)
        {
            V_MaterialMasterDAL vDAL = new V_MaterialMasterDAL();
            string whStr = "";

            whStr += "MASTERTYPE = 'FO' AND ACTIVE = 1";
            if (materialclass != "0") whStr += (whStr.Trim() == "" ? "" : " AND ") + " CLASSLOID = " + materialclass + " ";
            if (materialgroup != "0") whStr += (whStr.Trim() == "" ? "" : " AND ") + " GROUPLOID = " + materialgroup + " ";
            if (materialname != "") whStr += (whStr.Trim() == "" ? "" : " AND ") + " UPPER(MATERIALNAME) LIKE UPPER('%" + materialname + "%')";
            if (exceptKeyList != "") whStr += (whStr.Trim() == "" ? "" : " AND ") + "LOID NOT IN (" + exceptKeyList + ") ";

            if (orderstr == "")
                orderstr = "MATERIALNAME ASC";

            return vDAL.GetDataList(whStr, orderstr, null);
        }
    }
}
