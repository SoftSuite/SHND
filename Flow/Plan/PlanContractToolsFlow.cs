using System;
using System.Collections;
using System.Collections.Generic;
using System.Data;
using System.Data.OracleClient;
using System.Text;
using SHND.DAL.Tables;
using SHND.DAL.Views;
using SHND.Data.Plan;
using SHND.Data.Tables;
using SHND.Data.Views;
using zTran = SHND.DAL.Utilities.OracleTransactionDB;

/// <summary>
/// PlanContractToolsFlow Class
/// Version 1.0
/// =========================================================================
/// Create by: Teang
/// Create Date: 16 Feb 2009
/// -------------------------------------------------------------------------
/// Modify By: -
/// Modify From: -
/// Modify Date: -
/// -------------------------------------------------------------------------
/// Remark: -
/// Description:
///    Flow จัดการการทำงานของหน้า PlanContractToolsSearch และ PlanContractTools
/// Changes:
///    1.0 - สร้าง
/// -------------------------------------------------------------------------
/// =========================================================================
/// </summary>
/// 
namespace SHND.Flow.Plan
{
    public class PlanContractToolsFlow
    {
        string _error = "";
        double _LOID = 0;
        public string ErrorMessage { get { return _error; } }
        public double LOID { get { return _LOID; } }

        public DataTable GetMasterList(string name, int budgetYear, string qtCode, string refPRSap, string statusFrom, string statusTo, string orderBy)
        {
            VPlanToolsSearchDAL vDAL = new VPlanToolsSearchDAL();
            return vDAL.GetDataListByConditions(name, budgetYear, qtCode, refPRSap, statusFrom, statusTo, orderBy, null);
        }

        public bool UpdatePlanToolsItem(ArrayList arrData, string userID, OracleTransaction trans)
        {
            PlanToolsItemDAL mDAL;
            PlanToolsItemData mData;
            bool ret = true;
            for (int i = 0; i < arrData.Count; ++i)
            {
                mDAL = new PlanToolsItemDAL();
                mData = (PlanToolsItemData)arrData[i];

                mDAL.GetDataByLOID(mData.LOID, trans);
                mDAL.ISVAT = (mData.ISVAT ? "Y" : "N");
                mDAL.PRICE = mData.PRICE;
                mDAL.SPEC = mData.SPEC;
                mDAL.SUPPLIER = mData.SUPPLIER;
                mDAL.CONTRACTCODE = mData.CONTRACTCODE;

                if (mDAL.OnDB)
                    ret = mDAL.UpdateCurrentData(userID, trans);

                if (!ret)
                {
                    _error = mDAL.ErrorMessage;
                    break;
                }
            }
            return ret;
        }

        public bool UpdateData(PlanToolsDetailData mData, string userID)
        {
            bool ret = true;
            zTran trans = new zTran();
            trans.CreateTransaction();
            try
            {
                PlanOrderDAL planOrder = new PlanOrderDAL();
                planOrder.GetDataByLOID(mData.LOID, trans.Trans);
                planOrder.STATUS = mData.STATUS;
                if (planOrder.OnDB)
                    ret = planOrder.UpdateCurrentData(userID, trans.Trans);

                if (!ret) _error = planOrder.ErrorMessage;

                if (ret) ret = UpdatePlanToolsItem(mData.PlanToolsItem, userID, trans.Trans);
                if (ret && mData.STATUS == "FN")
                {
                    PlanOrderDivisionDAL planOrderDivision = new PlanOrderDivisionDAL();
                    ret = planOrderDivision.UpdateStatusByPlanOrder(mData.LOID, mData.STATUS, trans.Trans);
                    if (!ret) _error = planOrderDivision.ErrorMessage;

                    if (ret)
                    {
                        PlanToolsDivisionDAL planToolsDivision = new PlanToolsDivisionDAL();
                        ret = planToolsDivision.UpdateStatusByPlanOrder(mData.LOID, mData.STATUS, trans.Trans);
                        if (!ret) _error = planToolsDivision.ErrorMessage;
                    }
                }

                if (ret)
                    trans.CommitTransaction();
                else
                    trans.RollbackTransaction();

                _LOID = planOrder.LOID;
            }
            catch (Exception ex)
            {
                _error = ex.Message;
                ret = false;
                trans.RollbackTransaction();
            }
            return ret;
        }

        public PlanToolsDetailData GetDetail(double planOrderID)
        {
            VPlanToolsSearchDAL VPlanFoodSearch = new VPlanToolsSearchDAL();
            PlanToolsDetailData vData = new PlanToolsDetailData();
            VPlanFoodSearch.GetDataByLOID(planOrderID, null);
            vData.BUDGETYEAR = VPlanFoodSearch.BUDGETYEAR;
            vData.CODE = VPlanFoodSearch.CODE;
            vData.ENDDATE = VPlanFoodSearch.ENDDATE;
            vData.ISPLANFOOD = (VPlanFoodSearch.ISPLANFOOD == "Y");
            vData.LOID = VPlanFoodSearch.LOID;
            vData.MATERIALCLASS = VPlanFoodSearch.MATERIALCLASS;
            vData.NAME = VPlanFoodSearch.NAME;
            vData.PERIODTIME = VPlanFoodSearch.PERIODTIME;
            vData.PHASE = VPlanFoodSearch.PHASE;
            vData.PLANDATE = VPlanFoodSearch.PLANDATE;
            vData.QTCODE = VPlanFoodSearch.QTCODE;
            vData.REFPRSAP = VPlanFoodSearch.REFPRSAP;
            vData.STARTDATE = VPlanFoodSearch.STARTDATE;
            vData.STATUS = VPlanFoodSearch.STATUS;
            vData.STATUSNAME = VPlanFoodSearch.STATUSNAME;
            if (VPlanFoodSearch.STATUS == "")
            {
                vData.STATUS = "WA";
                vData.STATUSNAME = "กำลังดำเนินการ";
            }

            VPlanToolsMaterialDAL mDAL = new VPlanToolsMaterialDAL();
            vData.PlanToolsTable = mDAL.GetDataListByPlanOrder(vData.LOID, "MATERIALNAME", null);

            return vData;
        }

    }
}
