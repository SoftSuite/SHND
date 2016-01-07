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
/// PlanOrderFoodFlow Class
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
///    Flow จัดการการทำงานของหน้า PlanOrderFoodSearch และ PlanOrderFood 
/// Changes:
///    1.0 - สร้าง
/// -------------------------------------------------------------------------
/// =========================================================================
/// </summary>
/// 
namespace SHND.Flow.Plan
{
    public class PlanOrderToolsFlow
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

        public DataTable GetToolsItemList(double planOrderID)
        {
            VPlanToolsMaterialDAL vDAL = new VPlanToolsMaterialDAL();
            return vDAL.GetDataListByPlanOrder(planOrderID, "MATERIALNAME", null);
        }

        public DataTable GetToolsDivisionList(double planOrderID)
        {
            VPlanToolsDivisionMaterialDAL vDAL = new VPlanToolsDivisionMaterialDAL();
            return vDAL.GetDataListByPlanOrderActive(planOrderID, "DIVISIONNAME, MATERIALNAME", null);
        }

        private bool UpdateToolsDivision(double planOrderID, ArrayList arrData, string userID, OracleTransaction trans)
        {
            bool ret = true;
            PlanToolsDivisionDAL mDAL;
            for (int i = 0; i < arrData.Count; ++i)
            {
                PlanToolsDivisionData mData = (PlanToolsDivisionData)arrData[i];
                mDAL = new PlanToolsDivisionDAL();
                mDAL.GetDataByConditions(mData.DIVISION, mData.PLANTOOLSITEM, trans);
                mDAL.ADJQTY = mData.ADJQTY;
                mDAL.STATUS = mData.STATUS;
                if (mDAL.OnDB)
                    ret = mDAL.UpdateCurrentData(userID, trans);

                if (!ret)
                {
                    _error = mDAL.ErrorMessage;
                    break;
                }

                if (mData.STATUS == "CO")
                {
                    PlanOrderDivisionDAL PlanOrderDivision = new PlanOrderDivisionDAL();
                    PlanOrderDivision.GetDataByConditions(planOrderID, mDAL.DIVISION, trans);
                    PlanOrderDivision.STATUS = mData.STATUS;
                    if (PlanOrderDivision.OnDB)
                        ret = PlanOrderDivision.UpdateCurrentData(userID, trans);

                    if (!ret)
                    {
                        _error = mDAL.ErrorMessage;
                        break;
                    }
                }
            }
            return ret;
        }

        public bool InsertPlanToolsItem(double planOrderID, ArrayList arrData, string userID, bool sendOrg, double adjPercent, OracleTransaction trans)
        {
            bool ret = true;
            string materialMasterList = "";
            for (int i = 0; i < arrData.Count; ++i)
            {
                PlanToolsItemData mData = (PlanToolsItemData)arrData[i];
                materialMasterList += (materialMasterList == "" ? "" : ",") + mData.MATERIALMASTER.ToString();
            }
            PlanToolsItemDAL planToolsItem = new PlanToolsItemDAL();
            planToolsItem.DeleteDataByConditions(planOrderID, materialMasterList, trans);

            PlanToolsDivisionDAL planToolsDivision;
            PlanOrderDivisionDAL planOrderDivision;
            DivisionDAL Division = new DivisionDAL();
            DataTable dt = Division.GetDataList("ISPLAN = 'Y'", "", trans);

            for (int i = 0; i < arrData.Count; ++i)
            {
                planToolsItem = new PlanToolsItemDAL();
                PlanToolsItemData mData = (PlanToolsItemData)arrData[i];
                planToolsItem.GetDataByConditions(planOrderID, mData.MATERIALMASTER, trans);
                planToolsItem.ISVAT = (mData.ISVAT ? "Y" : "N");
                planToolsItem.MATERIALMASTER = mData.MATERIALMASTER;
                planToolsItem.PLANORDER = planOrderID;
                planToolsItem.PLANQTY = mData.PLANQTY;
                planToolsItem.PRICE = mData.PRICE;
                planToolsItem.SPEC = mData.SPEC;
                planToolsItem.UNIT = mData.UNIT;
                if (planToolsItem.OnDB)
                    ret = planToolsItem.UpdateCurrentData(userID, trans);
                else
                    ret = planToolsItem.InsertCurrentData(userID, trans);

                if (ret)
                {
                    if (sendOrg) //ส่งให้หน่วยงาน
                    {
                        for (int k = 0; k < dt.Rows.Count; ++k)
                        {
                            planOrderDivision = new PlanOrderDivisionDAL();
                            planOrderDivision.GetDataByConditions(planOrderID, Convert.ToDouble(dt.Rows[k]["LOID"]), trans);
                            planOrderDivision.DIVISION = Convert.ToDouble(dt.Rows[k]["LOID"]);
                            planOrderDivision.PLANORDER = planOrderID;
                            planOrderDivision.STATUS = "CO";
                            if (!planOrderDivision.OnDB)
                                ret = planOrderDivision.InsertCurrentData(userID, trans);

                            if (!ret)
                            {
                                _error = planOrderDivision.ErrorMessage;
                                break;
                            }

                            planToolsDivision = new PlanToolsDivisionDAL();
                            planToolsDivision.GetDataByConditions(Convert.ToDouble(dt.Rows[k]["LOID"]), planToolsItem.LOID, trans);
                            planToolsDivision.DIVISION = Convert.ToDouble(dt.Rows[k]["LOID"]);
                            planToolsDivision.PLANTOOLSITEM = planToolsItem.LOID;
                            planToolsDivision.PLANORDERDIVISION = planOrderDivision.LOID;
                            planToolsDivision.STATUS = "CO";
                            if (!planToolsDivision.OnDB)
                            {
                                if (planOrderDivision.OnDB) ret = planOrderDivision.UpdateCurrentData(userID, trans);

                                if (!ret)
                                {
                                    _error = planOrderDivision.ErrorMessage;
                                    break;
                                }
                                else
                                    ret = planToolsDivision.InsertCurrentData(userID, trans);
                            }

                            if (!ret)
                            {
                                _error = planToolsDivision.ErrorMessage;
                                break;
                            }
                        }
                    }
                }
                else
                    _error = planToolsItem.ErrorMessage;

                if (!ret)
                {
                    break;
                }
            }
            return ret;
        }

        public bool InsertData(PlanToolsDetailData pData, string userID, bool sendOrg)
        {
            bool ret = true;
            zTran trans = new zTran();
            trans.CreateTransaction();
            try
            {
                PlanOrderDAL planOrder = new PlanOrderDAL();
                planOrder.CODE = planOrder.GetRunningCodeFood(trans.Trans);
                planOrder.BUDGETYEAR = pData.BUDGETYEAR;
                planOrder.ENDDATE = pData.ENDDATE;
                planOrder.ISPLANFOOD = "N";
                planOrder.MATERIALCLASS = pData.MATERIALCLASS;
                planOrder.NAME = pData.NAME;
                planOrder.PERIODTIME = pData.PERIODTIME;
                planOrder.PHASE = pData.PHASE;
                planOrder.PLANDATE = DateTime.Now;
                planOrder.QTCODE = pData.QTCODE;
                planOrder.REFPRSAP = pData.REFPRSAP;
                planOrder.STARTDATE = pData.STARTDATE;
                planOrder.STATUS = pData.STATUS;
                ret = planOrder.InsertCurrentData(userID, trans.Trans);
                if (!ret)
                    _error = planOrder.ErrorMessage;

                if (ret) ret = InsertPlanToolsItem(planOrder.LOID, pData.PlanToolsItem, userID, sendOrg, pData.AdjPercent, trans.Trans);

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

        public bool UpdateData(PlanToolsDetailData pData, string userID, bool sendOrg)
        {
            bool ret = true;
            zTran trans = new zTran();
            trans.CreateTransaction();
            try
            {
                PlanOrderDAL planOrder = new PlanOrderDAL();
                planOrder.GetDataByLOID(pData.LOID, trans.Trans);
                planOrder.BUDGETYEAR = pData.BUDGETYEAR;
                planOrder.ENDDATE = pData.ENDDATE;
                planOrder.MATERIALCLASS = pData.MATERIALCLASS;
                planOrder.NAME = pData.NAME;
                planOrder.PERIODTIME = pData.PERIODTIME;
                planOrder.PHASE = pData.PHASE;
                planOrder.QTCODE = pData.QTCODE;
                planOrder.REFPRSAP = pData.REFPRSAP;
                planOrder.STARTDATE = pData.STARTDATE;
                planOrder.STATUS = pData.STATUS;

                if (planOrder.OnDB)
                {
                    ret = planOrder.UpdateCurrentData(userID, trans.Trans);
                    if (!ret)
                        _error = planOrder.ErrorMessage;

                    if (ret)
                    {
                        ret = InsertPlanToolsItem(planOrder.LOID, pData.PlanToolsItem, userID, sendOrg, pData.AdjPercent, trans.Trans);
                        if (ret) ret = UpdateToolsDivision(planOrder.LOID, pData.PlanToolsDivision, userID, trans.Trans);
                    }
                    if (ret && pData.STATUS == "CF") ret = UpdateStatusItem(planOrder.LOID, pData.STATUS, userID, trans.Trans);
                }
                else
                {
                    ret = false;
                    _error = Data.Common.Utilities.DataResources.MSGEU002;
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

        private bool UpdateStatusItem(double planOrderID, string status, string userID, OracleTransaction trans)
        {
            bool ret = true;
            if (status != "WA" && status != "CO")
            {
                PlanToolsDivisionDAL mDAL = new PlanToolsDivisionDAL();
                ret = mDAL.UpdateStatusByPlanOrder(planOrderID, status, trans);
                if (!ret) _error = mDAL.ErrorMessage;

                if (ret)
                {
                    PlanOrderDivisionDAL planOrderDivision = new PlanOrderDivisionDAL();
                    ret = planOrderDivision.UpdateStatusByPlanOrder(planOrderID, status, trans);
                    if (!ret) _error = planOrderDivision.ErrorMessage;
                }
            }
            return ret;
        }

        public bool UpdateStatus(double planOrderID, string status, string qtCode, string refPRSap, string userID)
        {
            bool ret = true;
            zTran trans = new zTran();
            trans.CreateTransaction();
            try
            {
                PlanOrderDAL planOrder = new PlanOrderDAL();
                planOrder.GetDataByLOID(planOrderID, trans.Trans);
                planOrder.QTCODE = qtCode;
                planOrder.REFPRSAP = refPRSap;
                planOrder.STATUS = status;

                if (planOrder.OnDB)
                {
                    _LOID = planOrder.LOID;
                    ret = planOrder.UpdateCurrentData(userID, trans.Trans);
                    if (!ret)
                        _error = planOrder.ErrorMessage;
                    else
                    {
                        ret = UpdateStatusItem(planOrderID, status, userID, trans.Trans);
                    }
                }
                else
                {
                    ret = false;
                    _error = Data.Common.Utilities.DataResources.MSGEV002;
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

        public bool CopyData(double refPlanOrderFoodID, string userID)
        {
            bool ret = true;
            zTran trans = new zTran();
            trans.CreateTransaction();
            try
            {
                PlanOrderDAL PlanOrder = new PlanOrderDAL();
                PlanOrder.GetDataByLOID(refPlanOrderFoodID, trans.Trans);
                if (PlanOrder.OnDB)
                {
                    PlanOrderDAL newPlanOrder = new PlanOrderDAL();
                    newPlanOrder.BUDGETYEAR = PlanOrder.BUDGETYEAR;
                    newPlanOrder.ENDDATE = PlanOrder.ENDDATE;
                    newPlanOrder.ISPLANFOOD = PlanOrder.ISPLANFOOD;
                    newPlanOrder.MATERIALCLASS = PlanOrder.MATERIALCLASS;
                    newPlanOrder.NAME = newPlanOrder.GetRunningCopyNameFood(PlanOrder.NAME, trans.Trans);
                    newPlanOrder.PERIODTIME = PlanOrder.PERIODTIME;
                    newPlanOrder.PHASE = PlanOrder.PHASE;
                    newPlanOrder.PLANDATE = DateTime.Now;
                    newPlanOrder.QTCODE = "";
                    newPlanOrder.REFPRSAP = "";
                    newPlanOrder.STARTDATE = PlanOrder.STARTDATE;
                    newPlanOrder.STATUS = "WA";
                    newPlanOrder.CODE = newPlanOrder.GetRunningCodeFood(trans.Trans);
                    ret = newPlanOrder.InsertCurrentData(userID, trans.Trans);
                    _LOID = newPlanOrder.LOID;
                    if (!ret)
                        _error = newPlanOrder.ErrorMessage;

                    if (ret)
                    {
                        PlanToolsItemDAL planToolsItem = new PlanToolsItemDAL();
                        DataTable dtItem = planToolsItem.GetDataListByPlanOrder(PlanOrder.LOID, "", trans.Trans);
                        for (int k = 0; k < dtItem.Rows.Count; ++k)
                        {
                            planToolsItem = new PlanToolsItemDAL();
                            if (!Convert.IsDBNull(dtItem.Rows[k]["ISVAT"])) planToolsItem.ISVAT = dtItem.Rows[k]["ISVAT"].ToString();
                            planToolsItem.MATERIALMASTER = Convert.ToDouble(dtItem.Rows[k]["MATERIALMASTER"]);
                            planToolsItem.PLANORDER = newPlanOrder.LOID;
                            planToolsItem.PLANQTY = 0;
                            if (!Convert.IsDBNull(dtItem.Rows[k]["PRICE"])) planToolsItem.PRICE = Convert.ToDouble(dtItem.Rows[k]["PRICE"]);
                            if (!Convert.IsDBNull(dtItem.Rows[k]["SPEC"])) planToolsItem.SPEC = dtItem.Rows[k]["SPEC"].ToString();
                            planToolsItem.UNIT = Convert.ToDouble(dtItem.Rows[k]["UNIT"]);
                            ret = planToolsItem.InsertCurrentData(userID, trans.Trans);
                            if (!ret)
                            {
                                _error = planToolsItem.ErrorMessage;
                                break;
                            }
                        }
                    }
                }
                else
                {
                    ret = false;
                    _error = Data.Common.Utilities.DataResources.MSGEV002;
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

        public PlanToolsDetailData GetDetails(double LOID)
        {
            VPlanToolsSearchDAL VPlanFoodSearch = new VPlanToolsSearchDAL();
            PlanToolsDetailData vData = new PlanToolsDetailData();
            VPlanFoodSearch.GetDataByLOID(LOID, null);
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

            return vData;
        }

        public bool CheckUniqueKey(double planOrderID, string name)
        {
            PlanOrderDAL pDAL = new PlanOrderDAL();
            pDAL.GetDataByUniqueKey(name, null);
            return !pDAL.OnDB || (planOrderID == pDAL.LOID);
        }
        public bool CheckUniqueDate(double planOrderID, double cMaterialClass, DateTime startDate, DateTime endDate)
        {
            PlanOrderDAL pDAL = new PlanOrderDAL();
            pDAL.GetDataByUniqueDate(startDate, endDate,cMaterialClass, planOrderID,  null);
            return pDAL.OnDB;
        }
        public DataTable chkConfirmDiv(double planOrderID)
        {
            VPlanToolsDivisionSearchDAL pDAL = new VPlanToolsDivisionSearchDAL();
            return pDAL.GetDataListByPlanOrder(planOrderID, null);

        }
    }
}
