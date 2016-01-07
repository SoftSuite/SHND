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
/// Create Date: 26 Jan 2009
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
    public class PlanOrderFoodFlow
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

        public DataTable GetMaterialItemList(double planOrderID)
        {
            VPlanFoodMaterialDAL vDAL = new VPlanFoodMaterialDAL();
            return vDAL.GetDataListByPlanOrder(planOrderID, "CLASSNAME, GROUPNAME, MATERIALNAME", null);
        }

        public DataTable GetOfficerList(double planOrderID)
        {
            VPlanOrderCouncilDAL vDAL = new VPlanOrderCouncilDAL();
            return vDAL.GetDataListByPlanOrder(planOrderID, "OFFICERNAME", null);
        }

        public DataTable GetMaterialDivisionList(double planOrderID)
        {
            VPlanFoodDivisionMaterialDAL vDAL = new VPlanFoodDivisionMaterialDAL();
            return vDAL.GetDataListByPlanOrderActive(planOrderID, "DIVISIONNAME, MATERIALNAME", null);
        }
        public DataTable GetMaterialDivisionList(double planOrderID, double materialmaster)
        {
            VPlanFoodDivisionMaterialDAL vDAL = new VPlanFoodDivisionMaterialDAL();
            return vDAL.GetDataListByMaterial(planOrderID, materialmaster, "DIVISIONNAME, MATERIALNAME", null);
        }

        private bool InsertPlanOrderCouncil(double planOrderID, ArrayList arrData, string userID, bool sendOrg, OracleTransaction trans)
        {
            bool ret = true;
            string officerList = "";
            PlanOrderCouncilData pData;
            for (int i = 0; i < arrData.Count; ++i)
            {
                pData = (PlanOrderCouncilData)arrData[i];
                officerList += (officerList == "" ? "" : ",") + pData.OFFICER.ToString();
            }
            PlanOrderCouncilDAL pDAL = new PlanOrderCouncilDAL();
            pDAL.DeleteDataByConditions(planOrderID, officerList, trans);
            for (int i = 0; i < arrData.Count; ++i)
            {
                pData = (PlanOrderCouncilData)arrData[i];
                pDAL = new PlanOrderCouncilDAL();
                pDAL.GetDataByConditions(planOrderID, pData.OFFICER, trans);
                pDAL.M1 = (pData.M1 ? "Y" : "N");
                pDAL.M2 = (pData.M2 ? "Y" : "N");
                pDAL.M3 = (pData.M3 ? "Y" : "N");
                pDAL.M4 = (pData.M4 ? "Y" : "N");
                pDAL.M5 = (pData.M5 ? "Y" : "N");
                pDAL.M6 = (pData.M6 ? "Y" : "N");
                pDAL.M7 = (pData.M7 ? "Y" : "N");
                pDAL.M8 = (pData.M8 ? "Y" : "N");
                pDAL.M9 = (pData.M9 ? "Y" : "N");
                pDAL.M10 = (pData.M10 ? "Y" : "N");
                pDAL.M11 = (pData.M11 ? "Y" : "N");
                pDAL.M12 = (pData.M12 ? "Y" : "N");
                pDAL.OFFICER = pData.OFFICER;
                pDAL.PLANORDER = planOrderID;
                pDAL.POSITION = pData.POSITION;
                pDAL.DIVISION = pData.DIVISION;
                if (pDAL.OnDB)
                    ret = pDAL.UpdateCurrentData(userID, trans);
                else
                    ret = pDAL.InsertCurrentData(userID, trans);

                if (!ret)
                {
                    _error = pDAL.ErrorMessage;
                    break;
                }
            }

            if (sendOrg)
                ret = InsertPlanOrderDivision(planOrderID, userID, trans);
            
            return ret;
        }

        private bool UpdateMaterialDivision(double planOrderID, ArrayList arrData, string userID, OracleTransaction trans)
        {
            bool ret = true;
            PlanMaterialDivisionDAL mDAL;
            for (int i = 0; i < arrData.Count; ++i)
            {
                PlanMaterialDivisionData mData = (PlanMaterialDivisionData)arrData[i];
                mDAL = new PlanMaterialDivisionDAL();
                mDAL.GetDataByConditions(mData.DIVISION, mData.PLANMATERIALITEM, trans);
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
        public bool InsertPlanOrderDivision(double planOrderID, string userID, OracleTransaction trans)
        {
            bool ret = true;
            PlanMaterialDivisionDAL PlanMaterialDivision;
            PlanOrderDivisionDAL PlanOrderDivision;
            DivisionDAL Division = new DivisionDAL();
            DataTable dt = Division.GetDataList("ISPLAN = 'Y'", "", trans);

            for (int k = 0; k < dt.Rows.Count; ++k)
            {
                PlanOrderDivision = new PlanOrderDivisionDAL();
                PlanOrderDivision.GetDataByConditions(planOrderID, Convert.ToDouble(dt.Rows[k]["LOID"]), trans);
                PlanOrderDivision.DIVISION = Convert.ToDouble(dt.Rows[k]["LOID"]);
                PlanOrderDivision.PLANORDER = planOrderID;
                PlanOrderDivision.STATUS = "CO";
                if (!PlanOrderDivision.OnDB)
                    ret = PlanOrderDivision.InsertCurrentData(userID, trans);

                if (!ret)
                {
                    _error = PlanOrderDivision.ErrorMessage;
                    return false;
                }

                VPlanFoodMaterialDAL planFoodMaterial = new VPlanFoodMaterialDAL();
                DataTable dtMaterial = planFoodMaterial.GetDataListByPlanOrder(planOrderID, "", trans);

                for (int i = 0; i < dtMaterial.Rows.Count; ++i)
                {
                    PlanMaterialDivision = new PlanMaterialDivisionDAL();
                    PlanMaterialDivision.GetDataByConditions(Convert.ToDouble(dt.Rows[k]["LOID"]), Convert.ToDouble(dtMaterial.Rows[i]["LOID"]), trans);
                    PlanMaterialDivision.DIVISION = Convert.ToDouble(dt.Rows[k]["LOID"]);
                    PlanMaterialDivision.PLANMATERIALITEM = Convert.ToDouble(dtMaterial.Rows[i]["LOID"]);
                    PlanMaterialDivision.PLANORDERDIVISION = PlanOrderDivision.LOID;
                    PlanMaterialDivision.STATUS = "CO";
                    if (!PlanMaterialDivision.OnDB)
                    {
                        if (PlanOrderDivision.OnDB) ret = PlanOrderDivision.UpdateCurrentData(userID, trans);

                        if (!ret)
                        {
                            _error = PlanOrderDivision.ErrorMessage;
                            return false;
                        }
                        else
                            ret = PlanMaterialDivision.InsertCurrentData(userID, trans);
                    }

                    if (!ret)
                    {
                        _error = PlanMaterialDivision.ErrorMessage;
                        return false;
                    }
                }
            }
            return ret;
        }

        public bool InsertPlanMaterialClassAndItem(double planOrderID, ArrayList arrData, string userID, bool sendOrg, double adjPercent, OracleTransaction trans)
        {
            bool ret = true;
            string materialClassList = "";
            string materialMasterList = "";
            for (int i = 0; i < arrData.Count; ++i)
            {
                VPlanFoodMaterialData mData = (VPlanFoodMaterialData)arrData[i];
                materialClassList += (materialClassList == "" ? "" : ",") + mData.CLASSLOID.ToString();
                materialMasterList += (materialMasterList == "" ? "" : ",") + mData.MATERIALMASTER.ToString();
            }
            PlanMaterialItemDAL PlanMaterialItem = new PlanMaterialItemDAL();
            PlanMaterialItem.DeleteDataByConditions(planOrderID, materialMasterList, trans);

            PlanMaterialClassDAL PlanMaterialClass = new PlanMaterialClassDAL();
            PlanMaterialClass.DeleteDataByConditions(planOrderID, materialClassList, trans);

            PlanMaterialDivisionDAL PlanMaterialDivision;
            PlanOrderDivisionDAL PlanOrderDivision;
            DivisionDAL Division = new DivisionDAL();
            DataTable dt = Division.GetDataList("ISPLAN = 'Y'", "", trans);

            for (int i = 0; i < arrData.Count; ++i)
            {
                PlanMaterialClass = new PlanMaterialClassDAL();
                VPlanFoodMaterialData mData = (VPlanFoodMaterialData)arrData[i];
                PlanMaterialClass.GetDataByConditions(planOrderID, mData.CLASSLOID, trans);
                PlanMaterialClass.MATERIALCLASS = mData.CLASSLOID;
                PlanMaterialClass.PLANORDER = planOrderID;
                if (!PlanMaterialClass.OnDB)
                    ret = PlanMaterialClass.InsertCurrentData(userID, trans);

                if (ret)
                {
                    PlanMaterialItem = new PlanMaterialItemDAL();
                    PlanMaterialItem.GetDataByConditions(PlanMaterialClass.LOID, mData.MATERIALMASTER, trans);
                    PlanMaterialItem.ISVAT = mData.ISVAT;
                    PlanMaterialItem.MATERIALMASTER = mData.MATERIALMASTER;
                    PlanMaterialItem.PLANMATERIALCLASS = PlanMaterialClass.LOID;
                    PlanMaterialItem.PLANQTY = mData.PLANQTY;
                    PlanMaterialItem.PRICE = mData.PRICE;
                    PlanMaterialItem.SPEC = mData.SPEC;
                    PlanMaterialItem.UNIT = mData.UNIT;
                    if (PlanMaterialItem.OnDB)
                        ret = PlanMaterialItem.UpdateCurrentData(userID, trans);
                    else
                    {
                        ret = PlanMaterialItem.InsertCurrentData(userID, trans);
                    }

                    if (ret)
                    {
                        if (sendOrg) //ส่งให้หน่วยงาน
                        {
                            for (int k = 0; k < dt.Rows.Count; ++k)
                            {
                                PlanOrderDivision = new PlanOrderDivisionDAL();
                                PlanOrderDivision.GetDataByConditions(planOrderID, Convert.ToDouble(dt.Rows[k]["LOID"]), trans);
                                PlanOrderDivision.DIVISION = Convert.ToDouble(dt.Rows[k]["LOID"]);
                                PlanOrderDivision.PLANORDER = planOrderID;
                                PlanOrderDivision.STATUS = "CO";
                                if (!PlanOrderDivision.OnDB)
                                    ret = PlanOrderDivision.InsertCurrentData(userID, trans);

                                if (!ret)
                                {
                                    _error = PlanOrderDivision.ErrorMessage;
                                    break;
                                }

                                PlanMaterialDivision = new PlanMaterialDivisionDAL();
                                PlanMaterialDivision.GetDataByConditions(Convert.ToDouble(dt.Rows[k]["LOID"]), PlanMaterialItem.LOID, trans);
                                PlanMaterialDivision.DIVISION = Convert.ToDouble(dt.Rows[k]["LOID"]);
                                PlanMaterialDivision.PLANMATERIALITEM = PlanMaterialItem.LOID;
                                PlanMaterialDivision.PLANORDERDIVISION = PlanOrderDivision.LOID;
                                PlanMaterialDivision.STATUS = "CO";
                                if (!PlanMaterialDivision.OnDB)
                                {
                                    if (PlanOrderDivision.OnDB) ret = PlanOrderDivision.UpdateCurrentData(userID, trans);

                                    if (!ret)
                                    {
                                        _error = PlanOrderDivision.ErrorMessage;
                                        break;
                                    }
                                    else
                                        ret = PlanMaterialDivision.InsertCurrentData(userID, trans);
                                }

                                if (!ret)
                                {
                                    _error = PlanMaterialDivision.ErrorMessage;
                                    break;
                                }
                            }
                        }
                    }
                    else
                        _error = PlanMaterialItem.ErrorMessage;
                }
                else
                    _error = PlanMaterialClass.ErrorMessage;

                if (!ret)
                {
                    break;
                }
            }
            return ret;
        }

        public bool InsertData(PlanFoodDetailData pData, string userID, string currentTab, bool sendOrg)
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
                planOrder.ISPLANFOOD = "Y";
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

                if (ret && currentTab == "0") ret = InsertPlanMaterialClassAndItem(planOrder.LOID, pData.ArrMaterialMaster, userID, sendOrg, pData.AdjPercent, trans.Trans);
                if (ret && currentTab == "1") ret = InsertPlanOrderCouncil(planOrder.LOID, pData.ArrMaterialCouncil, userID, sendOrg, trans.Trans);

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

        public bool UpdateData(PlanFoodDetailData pData, string userID, string currentTab, bool sendOrg)
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

                    if (ret && currentTab == "0")
                    {
                        ret = InsertPlanMaterialClassAndItem(planOrder.LOID, pData.ArrMaterialMaster, userID, sendOrg, pData.AdjPercent, trans.Trans);
                        if (ret) ret = UpdateMaterialDivision(planOrder.LOID, pData.PlanMaterialDivision, userID, trans.Trans);
                    }
                    if (ret && currentTab == "1") ret = InsertPlanOrderCouncil(planOrder.LOID, pData.ArrMaterialCouncil, userID, sendOrg, trans.Trans);
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
                PlanMaterialDivisionDAL mDAL = new PlanMaterialDivisionDAL();
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
            DataTable dt;
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
                        PlanOrderCouncilDAL planOrderCouncil = new PlanOrderCouncilDAL();
                        dt = planOrderCouncil.GetDataList("PLANORDER = " + PlanOrder.LOID.ToString(), "", trans.Trans);
                        for (int i = 0; i < dt.Rows.Count; ++i)
                        {
                            planOrderCouncil = new PlanOrderCouncilDAL();
                            if (!Convert.IsDBNull(dt.Rows[i]["DIVISION"])) planOrderCouncil.DIVISION = Convert.ToDouble(dt.Rows[i]["DIVISION"]);
                            if (!Convert.IsDBNull(dt.Rows[i]["M1"])) planOrderCouncil.M1 = dt.Rows[i]["M1"].ToString();
                            if (!Convert.IsDBNull(dt.Rows[i]["M2"])) planOrderCouncil.M2 = dt.Rows[i]["M2"].ToString();
                            if (!Convert.IsDBNull(dt.Rows[i]["M3"])) planOrderCouncil.M3 = dt.Rows[i]["M3"].ToString();
                            if (!Convert.IsDBNull(dt.Rows[i]["M4"])) planOrderCouncil.M4 = dt.Rows[i]["M4"].ToString();
                            if (!Convert.IsDBNull(dt.Rows[i]["M5"])) planOrderCouncil.M5 = dt.Rows[i]["M5"].ToString();
                            if (!Convert.IsDBNull(dt.Rows[i]["M6"])) planOrderCouncil.M6 = dt.Rows[i]["M6"].ToString();
                            if (!Convert.IsDBNull(dt.Rows[i]["M7"])) planOrderCouncil.M7 = dt.Rows[i]["M7"].ToString();
                            if (!Convert.IsDBNull(dt.Rows[i]["M8"])) planOrderCouncil.M8 = dt.Rows[i]["M8"].ToString();
                            if (!Convert.IsDBNull(dt.Rows[i]["M9"])) planOrderCouncil.M9 = dt.Rows[i]["M9"].ToString();
                            if (!Convert.IsDBNull(dt.Rows[i]["M10"])) planOrderCouncil.M10 = dt.Rows[i]["M10"].ToString();
                            if (!Convert.IsDBNull(dt.Rows[i]["M11"])) planOrderCouncil.M11 = dt.Rows[i]["M11"].ToString();
                            if (!Convert.IsDBNull(dt.Rows[i]["M12"])) planOrderCouncil.M12 = dt.Rows[i]["M12"].ToString();
                            if (!Convert.IsDBNull(dt.Rows[i]["OFFICER"])) planOrderCouncil.OFFICER = Convert.ToDouble(dt.Rows[i]["OFFICER"]);
                            planOrderCouncil.PLANORDER = newPlanOrder.LOID;
                            if (!Convert.IsDBNull(dt.Rows[i]["POSITION"])) planOrderCouncil.POSITION = dt.Rows[i]["POSITION"].ToString();
                            ret = planOrderCouncil.InsertCurrentData(userID, trans.Trans);
                            if (!ret)
                            {
                                _error = planOrderCouncil.ErrorMessage;
                                break;
                            }
                        }
                    }

                    bool retItem = true;
                    if (ret)
                    {
                        DataTable dtItem;
                        PlanMaterialClassDAL planMaterialClass = new PlanMaterialClassDAL();
                        dt = planMaterialClass.GetDataList("PLANORDER = " + PlanOrder.LOID.ToString(), "", trans.Trans);
                        for (int i = 0; i < dt.Rows.Count; ++i)
                        {
                            retItem = true;
                            planMaterialClass = new PlanMaterialClassDAL();
                            planMaterialClass.CONTRACTCODE = "";
                            planMaterialClass.MATERIALCLASS = Convert.ToDouble(dt.Rows[i]["MATERIALCLASS"]);
                            planMaterialClass.PLANORDER = newPlanOrder.LOID;
                            if (!Convert.IsDBNull(dt.Rows[i]["REMARKS"])) planMaterialClass.REMARKS = dt.Rows[i]["REMARKS"].ToString();
                            planMaterialClass.SUPPLIER = 0;
                            ret = planMaterialClass.InsertCurrentData(userID, trans.Trans);
                            if (!ret)
                            {
                                _error = planMaterialClass.ErrorMessage;
                                break;
                            }

                            if (ret)
                            {
                                PlanMaterialItemDAL planMaterialItem = new PlanMaterialItemDAL();
                                dtItem = planMaterialItem.GetDataList("PLANMATERIALCLASS = " + dt.Rows[i]["LOID"].ToString(), "", trans.Trans);
                                for (int k = 0; k < dtItem.Rows.Count; ++k)
                                {
                                    planMaterialItem = new PlanMaterialItemDAL();
                                    if (!Convert.IsDBNull(dtItem.Rows[k]["ISVAT"])) planMaterialItem.ISVAT = dtItem.Rows[k]["ISVAT"].ToString();
                                    planMaterialItem.MATERIALMASTER = Convert.ToDouble(dtItem.Rows[k]["MATERIALMASTER"]);
                                    planMaterialItem.PLANMATERIALCLASS = planMaterialClass.LOID;
                                    planMaterialItem.PLANQTY = 0;
                                    if (!Convert.IsDBNull(dtItem.Rows[k]["PRICE"])) planMaterialItem.PRICE = Convert.ToDouble(dtItem.Rows[k]["PRICE"]);
                                    if (!Convert.IsDBNull(dtItem.Rows[k]["SPEC"])) planMaterialItem.SPEC = dtItem.Rows[k]["SPEC"].ToString();
                                    planMaterialItem.UNIT = Convert.ToDouble(dtItem.Rows[k]["UNIT"]);
                                    retItem = planMaterialItem.InsertCurrentData(userID, trans.Trans);
                                    if (!retItem)
                                    {
                                        _error = planMaterialItem.ErrorMessage;
                                        break;
                                    }
                                }
                            }

                            if (!ret || !retItem) break;
                        }
                    }
                }
                else
                    ret = false;
                _error = Data.Common.Utilities.DataResources.MSGEV002;

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

        public PlanFoodDetailData GetDetails(double LOID)
        {
            VPlanFoodSearchDAL VPlanFoodSearch = new VPlanFoodSearchDAL();
            PlanFoodDetailData vData = new PlanFoodDetailData();
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
        public bool CheckUniqueDate(double planOrderID, DateTime startDate, DateTime endDate)
        {
            PlanOrderDAL pDAL = new PlanOrderDAL();
            pDAL.GetDataByUniqueDate(startDate, endDate, planOrderID, null);
            return pDAL.OnDB;
        }
    }
}
