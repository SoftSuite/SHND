using System;
using System.Collections;
using System.Collections.Generic;
using System.Data;
using System.Data.OracleClient;
using System.Text;
using SHND.DAL.Plan;
using SHND.DAL.Tables;
using SHND.DAL.Views;
using SHND.Data.Plan;
using SHND.Data.Tables;
using SHND.Data.Views;
using zTran = SHND.DAL.Utilities.OracleTransactionDB;

/// <summary>
/// PlanOrderFoodDivisionFlow Class
/// Version 1.0
/// =========================================================================
/// Create by: Teang
/// Create Date: 11 Feb 2009
/// -------------------------------------------------------------------------
/// Modify By: -
/// Modify From: -
/// Modify Date: -
/// -------------------------------------------------------------------------
/// Remark: -
/// Description:
///    Flow จัดการการทำงานของหน้า PlanOrderFoodDivisionSearch และ PlanOrderFoodDivision 
/// Changes:
///    1.0 - สร้าง
/// -------------------------------------------------------------------------
/// =========================================================================
/// </summary>
/// 
namespace SHND.Flow.Plan
{
    public class PlanOrderFoodDivisionFlow
    {
        string _error = "";
        double _LOID = 0;
        public string ErrorMessage { get { return _error; } }
        public double LOID { get { return _LOID; } }

        public DataTable GetMasterList(double division, string name, int phase, int budgetYear, string qtCode, string refPRSap, string statusFrom, string statusTo, string orderBy)
        {
            VPlanFoodDivisionSearchDAL vDAL = new VPlanFoodDivisionSearchDAL();
            return vDAL.GetDataListByConditions(division, name, phase, budgetYear, qtCode, refPRSap, statusFrom, statusTo, orderBy, null);
        }

        public DataTable GetCalculatedItem(double planOrderDivisionID, DateTime dateFrom, DateTime dateTo)
        {
            MenuDivisionDAL vDAL = new MenuDivisionDAL();
            return vDAL.CalculatedItem(planOrderDivisionID, dateFrom, dateTo, null);
        }

        public bool UpdateData(PlanFoodDivisionDetailData pData, string userID)
        {
            _LOID = pData.LOID;
            bool ret = true;
            zTran trans = new zTran();
            trans.CreateTransaction();
            try
            {
                if (pData.STATUS == "ST")
                {
                    PlanOrderDivisionDAL planOrderDivision = new PlanOrderDivisionDAL();
                    planOrderDivision.GetDataByLOID(pData.LOID, trans.Trans);
                    planOrderDivision.STATUS = pData.STATUS;
                    if (planOrderDivision.OnDB)
                        ret = planOrderDivision.UpdateCurrentData(userID, trans.Trans);
                    if (!ret) _error = planOrderDivision.ErrorMessage;
                }

                if (ret)
                {
                    PlanMaterialDivisionDAL mDAL;
                    for (int i = 0; i < pData.MaterialDivisionList.Count; ++i)
                    {
                        PlanMaterialDivisionData mData = (PlanMaterialDivisionData)pData.MaterialDivisionList[i];
                        mDAL = new PlanMaterialDivisionDAL();
                        mDAL.GetDataByLOID(mData.LOID, trans.Trans);
                        mDAL.MENUQTY = mData.MENUQTY;
                        mDAL.REQQTY = mData.REQQTY;
                        if (pData.STATUS == "ST")
                        {
                            mDAL.ADJQTY = mData.REQQTY;
                            mDAL.STATUS = pData.STATUS;
                        }
                        if (mDAL.OnDB)
                            ret = mDAL.UpdateCurrentData(userID, trans.Trans);

                        if (!ret)
                        {
                            _error = mDAL.ErrorMessage;
                            break;
                        }
                    }
                }

                if (ret)
                    trans.CommitTransaction();
                else
                    trans.RollbackTransaction();
            }
            catch (Exception ex)
            {
                _error = ex.Message;
                ret = false;
                trans.RollbackTransaction();
            }
            return ret;
        }

        public PlanFoodDivisionDetailData GetDetails(double LOID)
        {
            VPlanFoodDivisionSearchDAL pDAL = new VPlanFoodDivisionSearchDAL();
            PlanFoodDivisionDetailData vData = new PlanFoodDivisionDetailData();
            pDAL.GetDataByLOID(LOID, null);
            vData.BUDGETYEAR = pDAL.BUDGETYEAR;
            vData.CODE = pDAL.CODE;
            vData.DIVISION = pDAL.DIVISION;
            vData.DIVISIONNAME = pDAL.DIVISIONNAME;
            vData.ENDDATE = pDAL.ENDDATE;
            vData.ISPLANFOOD = (pDAL.ISPLANFOOD == "Y");
            vData.LOID = pDAL.LOID;
            vData.MATERIALCLASS = pDAL.MATERIALCLASS;
            vData.NAME = pDAL.NAME;
            vData.PERIODTIME = pDAL.PERIODTIME;
            vData.PHASE = pDAL.PHASE;
            vData.PLANDATE = pDAL.PLANDATE;
            vData.QTCODE = pDAL.QTCODE;
            vData.REFPRSAP = pDAL.REFPRSAP;
            vData.STARTDATE = pDAL.STARTDATE;
            vData.STATUS = pDAL.STATUS;
            vData.STATUSNAME = pDAL.STATUSNAME;
            if (pDAL.STATUS == "")
            {
                vData.STATUS = "WA";
                vData.STATUSNAME = "กำลังดำเนินการ";
            }

            MenuDivisionDAL mDAL = new MenuDivisionDAL();
            vData.MenuByDivision = mDAL.GetMenuByDivisionList(pDAL.DIVISION, pDAL.STARTDATE, pDAL.ENDDATE, null);

            VPlanFoodDivisionMaterialDAL fDAL = new VPlanFoodDivisionMaterialDAL();
            vData.MaterialDivision = fDAL.GetDataListByPlanOrderDivision(pDAL.LOID, "CLASSNAME, GROUPNAME, MATERIALNAME", null);

            return vData;
        }

    }
}
