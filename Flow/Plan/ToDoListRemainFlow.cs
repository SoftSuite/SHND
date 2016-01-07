using System;
using System.Collections.Generic;
using System.Data;
using System.Text;
using SHND.DAL.Tables;
using SHND.DAL.Views;

/// <summary>
/// ToDoListRemainFlow Class
/// Version 1.0
/// =========================================================================
/// Create by: Teang
/// Create Date: 17 Feb 2009
/// -------------------------------------------------------------------------
/// Modify By: -
/// Modify From: -
/// Modify Date: -
/// -------------------------------------------------------------------------
/// Remark: -
/// Description:
///    Flow จัดการการทำงานของหน้า ToDoListRemain
/// Changes:
///    1.0 - สร้าง
/// -------------------------------------------------------------------------
/// =========================================================================
/// </summary>
/// 
namespace SHND.Flow.Plan
{
    public class ToDoListRemainFlow
    {
        string _error = "";
        double _LOID = 0;
        public string ErrorMessage { get { return _error; } }
        public double LOID { get { return _LOID; } }

        public DataTable GetMasterList(double planorderID, double materialClassID, string materialName, string operatorType, double remainPercent, string orderBy)
        {
            VToDoListPlanRemainDAL vDAL = new VToDoListPlanRemainDAL();
            return vDAL.GetDataListByConditions(planorderID, materialClassID, materialName, operatorType, remainPercent, orderBy, null);
        }

        public bool UpdateSpec(double materialMasterID, string spec, string userID)
        {
            bool ret = true;
            MaterialMasterDAL mDAL = new MaterialMasterDAL();
            mDAL.GetDataByLOID(materialMasterID, null);
            if (mDAL.OnDB)
            {
                mDAL.SPEC = spec;
                ret = mDAL.UpdateCurrentData(userID, null);
                if (!ret)
                    _error = mDAL.ErrorMessage;
            }
            else
            {
                ret = false;
                _error = Data.Common.Utilities.DataResources.MSGEU002;
            }
            return ret;
        }
        public double GetDefaultPlan(DateTime currDate)
        {
            PlanOrderDAL pDAL = new PlanOrderDAL();
            return pDAL.GetDataByPeriod(currDate, null);
        }

    }
}
