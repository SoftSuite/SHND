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
/// PlanOrderToolsDivisionFlow Class
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
///    Flow จัดการการทำงานของหน้า PlanOrderToolsDivisionSearch และ PlanOrderToolsDivision 
/// Changes:
///    1.0 - สร้าง
/// -------------------------------------------------------------------------
/// =========================================================================
/// </summary>
/// 
namespace SHND.Flow.Plan
{
    public class PlanOrderToolsDivisionFlow
    {
        string _error = "";
        double _LOID = 0;
        public string ErrorMessage { get { return _error; } }
        public double LOID { get { return _LOID; } }

        public DataTable GetMasterList(double division, string name, int budgetYear, string qtCode, string refPRSap, string statusFrom, string statusTo, string orderBy)
        {
            VPlanToolsDivisionSearchDAL vDAL = new VPlanToolsDivisionSearchDAL();
            return vDAL.GetDataListByConditions(division, name, budgetYear, qtCode, refPRSap, statusFrom, statusTo, orderBy, null);
        }

        public bool UpdateData(PlanToolsDivisionDetailData pData, string userID)
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
                    PlanToolsDivisionDAL mDAL;
                    for (int i = 0; i < pData.PlanToolsDivisionList.Count; ++i)
                    {
                        PlanToolsDivisionData mData = (PlanToolsDivisionData)pData.PlanToolsDivisionList[i];
                        mDAL = new PlanToolsDivisionDAL();
                        mDAL.GetDataByLOID(mData.LOID, trans.Trans);
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

        public PlanToolsDivisionDetailData GetDetails(double LOID)
        {
            VPlanToolsDivisionSearchDAL pDAL = new VPlanToolsDivisionSearchDAL();
            PlanToolsDivisionDetailData vData = new PlanToolsDivisionDetailData();
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

            VPlanToolsDivisionMaterialDAL fDAL = new VPlanToolsDivisionMaterialDAL();
            vData.PlanToolsDivisionTable = fDAL.GetDataListByPlanOrderDivision(pDAL.LOID, "MATERIALNAME", null);

            return vData;
        }

    }
}
