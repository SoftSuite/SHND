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
/// PlanContractFoodFlow Class
/// Version 1.0
/// =========================================================================
/// Create by: Teang
/// Create Date: 12 Feb 2009
/// -------------------------------------------------------------------------
/// Modify By: -
/// Modify From: -
/// Modify Date: -
/// -------------------------------------------------------------------------
/// Remark: -
/// Description:
///    Flow จัดการการทำงานของหน้า PlanContractFoodSearch และ PlanContractFood
/// Changes:
///    1.0 - สร้าง
/// -------------------------------------------------------------------------
/// =========================================================================
/// </summary>
/// 
namespace SHND.Flow.Plan
{
    public class PlanContractFoodFlow
    {
        string _error = "";
        double _LOID = 0;
        public string ErrorMessage { get { return _error; } }
        public double LOID { get { return _LOID; } }

        public DataTable GetMasterList(string name, int phase, int budgetYear, string qtCode, string refPRSap, string statusFrom, string statusTo, string orderBy)
        {
            VPlanFoodSearchDAL vDAL = new VPlanFoodSearchDAL();
            return vDAL.GetDataListByConditions(name, phase, budgetYear, qtCode, refPRSap, statusFrom, statusTo, orderBy, null);
        }

        public bool UpdatePlanMaterialItem(ArrayList arrData, string userID, OracleTransaction trans)
        {
            PlanMaterialItemDAL mDAL;
            PlanMaterialItemData mData;
            bool ret = true;
            for (int i = 0; i < arrData.Count; ++i)
            {
                mDAL = new PlanMaterialItemDAL();
                mData = (PlanMaterialItemData)arrData[i];

                mDAL.GetDataByLOID(mData.LOID, trans);
                mDAL.ISVAT = (mData.ISVAT ? "Y" : "N");
                mDAL.PRICE = mData.PRICE;
                mDAL.SPEC = mData.SPEC;
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

        public bool UpdatePlanMaterialClass(ArrayList arrData, string userID, OracleTransaction trans)
        {
            PlanMaterialClassDAL mDAL;
            PlanMaterialClassData mData;
            bool ret = true;
            for (int i = 0; i < arrData.Count; ++i)
            {
                mDAL = new PlanMaterialClassDAL();
                mData = (PlanMaterialClassData)arrData[i];

                mDAL.GetDataByLOID(mData.LOID, trans);
                mDAL.CONTRACTCODE = mData.CONTRACTCODE;
                mDAL.SUPPLIER = mData.SUPPLIER;

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

        public bool UpdateData(PlanFoodDetailData mData, string userID, string currentTab)
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

                if (ret && currentTab == "0") ret = UpdatePlanMaterialClass(mData.PlanMaterialClass, userID, trans.Trans);
                if (ret && currentTab == "1") ret = UpdatePlanMaterialItem(mData.ArrMaterialMaster, userID, trans.Trans);
                if (ret && mData.STATUS == "FN")
                {
                    PlanOrderDivisionDAL planOrderDivision = new PlanOrderDivisionDAL();
                    ret = planOrderDivision.UpdateStatusByPlanOrder(mData.LOID, mData.STATUS, trans.Trans);
                    if (!ret) _error = planOrderDivision.ErrorMessage;

                    if (ret)
                    {
                        PlanMaterialDivisionDAL planMaterialDivision = new PlanMaterialDivisionDAL();
                        ret = planMaterialDivision.UpdateStatusByPlanOrder(mData.LOID, mData.STATUS, trans.Trans);
                        if (!ret) _error = planMaterialDivision.ErrorMessage;
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

        public PlanFoodDetailData GetDetail(double planOrderID)
        {
            VPlanFoodSearchDAL VPlanFoodSearch = new VPlanFoodSearchDAL();
            PlanFoodDetailData vData = new PlanFoodDetailData();
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
            VPlanMaterialClassDAL cDAL = new VPlanMaterialClassDAL();
            vData.PlanMaterialClassTable = cDAL.GetDataByPlanOrder(vData.LOID, "CLASSNAME", null);

            VPlanFoodMaterialDAL mDAL = new VPlanFoodMaterialDAL();
            vData.PlanMaterialItemTable = mDAL.GetDataListByPlanOrder(vData.LOID, "CLASSNAME, GROUPNAME, MATERIALNAME", null);

            return vData;
        }

    }
}
