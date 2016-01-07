using System;
using System.Collections;
using System.Collections.Generic;
using System.Data;
using System.Data.OracleClient;
using System.Text;
using SHND.DAL.Formula;
using SHND.DAL.Functions;
using SHND.DAL.Tables;
using SHND.DAL.Views;
using SHND.Data.Formula;
using SHND.Data.Tables;
using zTran = SHND.DAL.Utilities.OracleTransactionDB;

/// <summary>
/// FoodTypeFlow Class
/// Version 1.0
/// =========================================================================
/// Create by: Teang
/// Create Date: 5 Jan 2009
/// -------------------------------------------------------------------------
/// Modify By: -
/// Modify From: -
/// Modify Date: -
/// -------------------------------------------------------------------------
/// Remark: -
/// Description:
///    Flow จัดการการทำงานของหน้า FormulaSet 
/// Changes:
///    1.0 - สร้าง
/// -------------------------------------------------------------------------
/// =========================================================================
/// </summary>
/// 
namespace SHND.Flow.Formula
{
    public class FormulaSetFlow
    {
        string _error = "";
        double _LOID = 0;
        public string ErrorMessage { get { return _error; } }
        public double LOID { get { return _LOID; } }

        public double CalEnergyWeight(double materialMasterID, double weight)
        {
            FunctionDAL fDAL = new FunctionDAL();
            return fDAL.CalEnergyWeight(materialMasterID, weight, null);
        }
        public double GetWeightPrepare(double materialMasterID, double weight)
        {
            FormulaSetItemDAL FormulaSetItem = new FormulaSetItemDAL();
            return FormulaSetItem.GetWeightPrepare(materialMasterID, weight);
        }
        public double GetWeightStockout(double materialMasterID, double weight)
        {
            FormulaSetItemDAL FormulaSetItem = new FormulaSetItemDAL();
            return FormulaSetItem.GetWeightStockout(materialMasterID, weight);
        }
        public double GetWeightCook(double materialMasterID, double weight, double cookType)
        {
            FormulaSetItemDAL FormulaSetItem = new FormulaSetItemDAL();
            return FormulaSetItem.GetWeigntCook(materialMasterID, weight, cookType);
        }

        public DataTable GetMasterList(FormulaSetSearchData condition, string OrderBy)
        {
            VFormulaSetSearchDAL vDAL = new VFormulaSetSearchDAL();
            return vDAL.GetDataListByCondition(condition, OrderBy, null);
        }

        public DataTable GetFormulaSetItemList(double formulaSetID)
        {
            VFormulaSetItemDAL VFormulaSetItem = new VFormulaSetItemDAL();
            DataTable dt = VFormulaSetItem.GetDataListByFormulaSet(formulaSetID, 0, "MATERIALNAME", null);
            dt.Columns.Add("RANK", typeof(double));
            for (int i = 0; i < dt.Rows.Count; ++i)
            {
                dt.Rows[i]["RANK"] = i + 1;
            }
            return dt;
        }

        public DataTable GetRefFormulaSetList(double formulaSetID)
        {
            VRefFormulaSetDAL VRefFormulaSet = new VRefFormulaSetDAL();
            DataTable dt = VRefFormulaSet.GetDistinctRefFormulaSetDataList(formulaSetID, null);
            dt.Columns.Add("RANK", typeof(double));
            for (int i = 0; i < dt.Rows.Count; ++i)
            {
                dt.Rows[i]["RANK"] = i + 1;
            }
            return dt;
        }

        public DataTable GetRefFormulaSetItemList(double formulaSetID)
        {
            VRefFormulaSetDAL VRefFormulaSet = new VRefFormulaSetDAL();
            return VRefFormulaSet.GetDataListByFormulaSet(formulaSetID, null);
        }

        public DataTable GetFormulaServeList(double formulaSetID)
        {
            VFormulaServeDAL VFormulaServe = new VFormulaServeDAL();
            DataTable dt = VFormulaServe.GetDataListByFormulaSet(formulaSetID, "NAME", null);
            dt.Columns.Add("RANK", typeof(double));
            for (int i = 0; i < dt.Rows.Count; ++i)
            {
                dt.Rows[i]["RANK"] = i + 1;
            }
            return dt;
        }

        public DataTable GetFormulaDiseaseList(double formulaSetID)
        {
            VFormulaDiseaseDAL VFormulaDisease = new VFormulaDiseaseDAL();
            DataTable dt = VFormulaDisease.GetDataListByCondition("FORMULASET", formulaSetID, "NAME", null);
            for (int i = 0; i < dt.Rows.Count; ++i)
            {
                dt.Rows[i]["LOID"] = i + 1;
            }
            return dt;
        }

        public DataTable GetFormulaNutrientList(double formulaSetID)
        {
            VFormulaSetNutrientDAL VFormulaSetNutrient = new VFormulaSetNutrientDAL();
            return VFormulaSetNutrient.GetDataListByFormulaSet(formulaSetID, "NUTRIENTNAME", null);
        }
        private double GetFoodType(double fDIVISION)
        {
            FoodTypeDAL vDAL = new FoodTypeDAL();
            return vDAL.GetDataByDivision(fDIVISION, null);
        }
        private double GetDivisionFoodtype(double fFOODTYPE)
        {
            FoodTypeDAL vDAL = new FoodTypeDAL();
            return vDAL.GetDataByFoodtype(fFOODTYPE, null);
        }

        private bool InsertFormulaDisease(ArrayList arrFormulaDisease, string userID, double FormulaSetID, OracleTransaction trans)
        {
            bool ret = true;
            bool hasInsert = false;
            string existDiseaseCategory = "";
            FormulaDiseaseDAL FormulaDisease= new FormulaDiseaseDAL();
            DataTable dtTemp = FormulaDisease.GetDataList("REFTABLE = 'FORMULASET' AND REFLOID = " + FormulaSetID.ToString(), "", trans);
            for (int i = 0; i < arrFormulaDisease.Count; ++i)
            {
                existDiseaseCategory += (existDiseaseCategory == "" ? "" : ",") + ((FormulaDiseaseData)arrFormulaDisease[i]).DISEASECATEGORY.ToString();
            }
            FormulaDisease.DeleteDataByCondition("FORMULASET", FormulaSetID, existDiseaseCategory, trans);

            for (int i = 0; i < arrFormulaDisease.Count; ++i)
            {
                FormulaDisease = new FormulaDiseaseDAL();
                FormulaDiseaseData datFormulaDisease = (FormulaDiseaseData)arrFormulaDisease[i];
                FormulaDisease.GetDataByConditions("FORMULASET", FormulaSetID, datFormulaDisease.DISEASECATEGORY, trans);
                FormulaDisease.DISEASECATEGORY = datFormulaDisease.DISEASECATEGORY;
                FormulaDisease.REFLOID = FormulaSetID;
                FormulaDisease.REFTABLE = "FORMULASET";
                FormulaDisease.ISHIGH = datFormulaDisease.ISHIGH;
                FormulaDisease.ISLOW = datFormulaDisease.ISLOW;
                FormulaDisease.ISNON = datFormulaDisease.ISNON;
                if (FormulaDisease.OnDB)
                    ret = FormulaDisease.UpdateCurrentData(userID, trans);
                else
                {
                    hasInsert = true;
                    ret = FormulaDisease.InsertCurrentData(userID, trans);
                }
                if (!ret)
                {
                    _error = FormulaDisease.ErrorMessage;
                    break;
                }
            }

            if (ret && (hasInsert || dtTemp.Rows.Count != arrFormulaDisease.Count))
            {
                FormulaSetItemDAL fDAL = new FormulaSetItemDAL();
                fDAL.DeleteDataByRefFormulaSet(FormulaSetID, trans);
            }
            return ret;
        }

        private bool InsertFormulaServe(ArrayList arrFormulaServe, string userID, double FormulaSetID, OracleTransaction trans)
        {
            bool ret = true;
            FormulaServeDAL FormulaServe = new FormulaServeDAL();
            FormulaServe.DeleteDataByFormulaSet(FormulaSetID, trans);
            for (int i = 0; i < arrFormulaServe.Count; ++i)
            {
                FormulaServe = new FormulaServeDAL();
                FormulaServeData datFormulaServe = (FormulaServeData)arrFormulaServe[i];
                //FormulaServe.GetDataByLOID(datFormulaServe.LOID, trans);
                FormulaServe.FORMULASET = FormulaSetID;
                FormulaServe.NAME = datFormulaServe.NAME;
                //FormulaServe.REFLOID = datFormulaServe.REFLOID;
                //FormulaServe.REFTABLE = datFormulaServe.REFTABLE;
                FormulaServe.WEIGHTRAW = datFormulaServe.WEIGHTRAW;
                FormulaServe.WEIGHTRIPE = datFormulaServe.WEIGHTRIPE;
                if (!FormulaServe.OnDB)
                    ret = FormulaServe.InsertCurrentData(userID, trans);
                //else
                //    ret = FormulaServe.UpdateCurrentData(userID, trans);
                if (!ret)
                {
                    _error = FormulaServe.ErrorMessage;
                    break;
                }
            }
            return ret;
        }

        private bool InsertFormulaSetItem(ArrayList arrFormulaSetItem, string userID, double FormulaSetID, OracleTransaction trans)
        {
            bool ret = true;
            string materialMasterList = "";
            for (int i = 0; i < arrFormulaSetItem.Count; ++i)
            {
                FormulaSetItemData datFormulaSetItem = (FormulaSetItemData)arrFormulaSetItem[i];
                materialMasterList += (materialMasterList == "" ? "" : ",") + datFormulaSetItem.MATERIALMASTER.ToString();
            }
            FormulaSetItemDAL FormulaSetItem = new FormulaSetItemDAL();
            if (materialMasterList != "") FormulaSetItem.doDelete("FORMULASET = " + FormulaSetID + " AND REFFORMULA IS NULL AND MATERIALMASTER NOT IN (" + materialMasterList + ") ", trans);
            for (int i = 0; i < arrFormulaSetItem.Count; ++i)
            {
                FormulaSetItem = new FormulaSetItemDAL();
                FormulaSetItemData datFormulaSetItem = (FormulaSetItemData)arrFormulaSetItem[i];
                FormulaSetItem.GetDataByUniqueKey(FormulaSetID, datFormulaSetItem.MATERIALMASTER, datFormulaSetItem.REFFORMULA, trans);
                FormulaSetItem.ENERGY = datFormulaSetItem.ENERGY;
                FormulaSetItem.FORMULASET = FormulaSetID;
                FormulaSetItem.MATERIALMASTER = datFormulaSetItem.MATERIALMASTER;
                FormulaSetItem.PREPARENAME = datFormulaSetItem.PREPARENAME;
                FormulaSetItem.REFFORMULA = datFormulaSetItem.REFFORMULA;
                FormulaSetItem.WEIGHT = datFormulaSetItem.WEIGHT;
                FormulaSetItem.WEIGHTRAW = datFormulaSetItem.WEIGHTRAW;
                FormulaSetItem.WEIGHTRIPE = datFormulaSetItem.WEIGHTRIPE;
                if (!FormulaSetItem.OnDB)
                    ret = FormulaSetItem.InsertCurrentData(userID, trans);
                else
                    ret = FormulaSetItem.UpdateCurrentData(userID, trans);

                if (!ret)
                {
                    _error = FormulaSetItem.ErrorMessage;
                    break;
                }
            }
            return ret;
        }

        private bool InsertRefFormulaSetItem(ArrayList arrRefFormulaSetItem, string userID, double FormulaSetID, OracleTransaction trans)
        {
            bool ret = true;
            string refFormulaList = "0 ";
            FormulaSetItemDAL FormulaSetItem;
            for (int i = 0; i < arrRefFormulaSetItem.Count; ++i)
            {
                FormulaSetItemData datFormulaSetItem = (FormulaSetItemData)arrRefFormulaSetItem[i];
                refFormulaList += (refFormulaList == "" ? "" : ",") + datFormulaSetItem.REFFORMULA.ToString();
            }
            FormulaSetItem = new FormulaSetItemDAL();
            FormulaSetItem.doDelete("FORMULASET = " + FormulaSetID + " AND REFFORMULA IS NOT NULL " + (refFormulaList == "" ? "" : ("AND REFFORMULA NOT IN (" + refFormulaList + ") ")), trans);
            for (int i = 0; i < arrRefFormulaSetItem.Count; ++i)
            {
                FormulaSetItem = new FormulaSetItemDAL();
                FormulaSetItemData datFormulaSetItem = (FormulaSetItemData)arrRefFormulaSetItem[i];
                FormulaSetItem.GetDataByUniqueKey(FormulaSetID, datFormulaSetItem.MATERIALMASTER, datFormulaSetItem.REFFORMULA, trans);
                FormulaSetItem.ENERGY = datFormulaSetItem.ENERGY;
                FormulaSetItem.FORMULASET = FormulaSetID;
                FormulaSetItem.MATERIALMASTER = datFormulaSetItem.MATERIALMASTER;
                FormulaSetItem.PREPARENAME = datFormulaSetItem.PREPARENAME;
                FormulaSetItem.REFFORMULA = datFormulaSetItem.REFFORMULA;
                FormulaSetItem.WEIGHT = datFormulaSetItem.WEIGHT;
                FormulaSetItem.WEIGHTRAW = datFormulaSetItem.WEIGHTRAW;
                FormulaSetItem.WEIGHTRIPE = datFormulaSetItem.WEIGHTRIPE;
                if (!FormulaSetItem.OnDB)
                    ret = FormulaSetItem.InsertCurrentData(userID, trans);
                else
                    ret = FormulaSetItem.UpdateCurrentData(userID, trans);

                if (!ret)
                {
                    _error = FormulaSetItem.ErrorMessage;
                    break;
                }
            }
            //FormulaDiseaseDAL FormulaDisease = new FormulaDiseaseDAL();
            //if (ret && arrRefFormulaSetItem.Count >0 && FormulaDisease.GetDataList("REFTABLE = 'FORMULASET' AND REFLOID = " + FormulaSetID, "", trans).Rows.Count == 0)
            //{
            //    ret = CopyFormulaDisease(((FormulaSetItemData)arrRefFormulaSetItem[0]).REFFORMULA, FormulaSetID, userID, trans);
            //}
            return ret;
        }

        private bool CopyFormulaDisease(double refFormulaSetID, double newFormulaSetID, string userID, OracleTransaction trans)
        {
            bool ret = true;
            FormulaDiseaseDAL FormulaDisease = new FormulaDiseaseDAL();
            DataTable formulaDiseaseTable = FormulaDisease.GetDataList("REFTABLE = 'FORMULASET' AND REFLOID = " + refFormulaSetID, "", trans);
            for (int i = 0; i < formulaDiseaseTable.Rows.Count; ++i)
            {
                FormulaDisease = new FormulaDiseaseDAL();
                FormulaDisease.DISEASECATEGORY = Convert.ToDouble(formulaDiseaseTable.Rows[i]["DISEASECATEGORY"]);
                if (!Convert.IsDBNull(formulaDiseaseTable.Rows[i]["ISHIGH"])) FormulaDisease.ISHIGH = formulaDiseaseTable.Rows[i]["ISHIGH"].ToString();
                if (!Convert.IsDBNull(formulaDiseaseTable.Rows[i]["ISLOW"])) FormulaDisease.ISLOW = formulaDiseaseTable.Rows[i]["ISLOW"].ToString();
                if (!Convert.IsDBNull(formulaDiseaseTable.Rows[i]["ISNON"])) FormulaDisease.ISNON = formulaDiseaseTable.Rows[i]["ISNON"].ToString();
                FormulaDisease.REFLOID = newFormulaSetID;
                FormulaDisease.REFTABLE = "FORMULASET";
                ret = FormulaDisease.InsertCurrentData(userID, trans);
                if (!ret)
                {
                    _error = FormulaDisease.ErrorMessage;
                    break;
                }
            }
            return ret;
        }

        public bool CopyData(double refFormulaSetID, double fDIVISION, string userID)
        {
            bool ret = true;
            zTran trans = new zTran();
            trans.CreateTransaction();
            FormulaSetDAL FormulaSet = new FormulaSetDAL();
            FormulaSetDAL newFormulaSet = new FormulaSetDAL();
            try
            {
                FormulaSet.GetDataByLOID(refFormulaSetID, trans.Trans);
                if (FormulaSet.OnDB)
                {
                    newFormulaSet.ACTIVE = "1";
                    newFormulaSet.DISHESTYPE = FormulaSet.DISHESTYPE;
                    newFormulaSet.ENERGY = FormulaSet.ENERGY;
                    newFormulaSet.FOODCATEGORY = FormulaSet.FOODCATEGORY;
                    newFormulaSet.FOODCOOKTYPE = FormulaSet.FOODCOOKTYPE;
                    if (fDIVISION == GetDivisionFoodtype(FormulaSet.FOODTYPE))
                        newFormulaSet.FOODTYPE = FormulaSet.FOODTYPE;
                    else
                        newFormulaSet.FOODTYPE = GetFoodType(fDIVISION); //FormulaSet.FOODTYPE;
                    newFormulaSet.IMGPATH = FormulaSet.IMGPATH;
                    newFormulaSet.ISELEMENT = FormulaSet.ISELEMENT;
                    newFormulaSet.ISONEDISH = FormulaSet.ISONEDISH;
                    newFormulaSet.ISSPECIFIC = FormulaSet.ISSPECIFIC;
                    newFormulaSet.NAME = FormulaSet.GetRunningCopyName(FormulaSet.NAME, trans.Trans);
                    newFormulaSet.PACKAGE = FormulaSet.PACKAGE;
                    newFormulaSet.PORTION = FormulaSet.PORTION;
                    newFormulaSet.PREPARE = FormulaSet.PREPARE;
                    newFormulaSet.RECIPE = FormulaSet.RECIPE;
                    newFormulaSet.SERVEMETHOD = FormulaSet.SERVEMETHOD;
                    newFormulaSet.STATUS = "WA";
                    newFormulaSet.WEIGHTFORMULA = FormulaSet.WEIGHTFORMULA;
                    newFormulaSet.WEIGHTPORTION = FormulaSet.WEIGHTPORTION;

                    ret = newFormulaSet.InsertCurrentData(userID, trans.Trans);
                    if (!ret)
                        _error = FormulaSet.ErrorMessage;

                    if (ret)
                    {
                        FormulaSetItemDAL FormulaSetItem = new FormulaSetItemDAL();
                        DataTable formulaItemTable = FormulaSetItem.GetDataList("FORMULASET = " + FormulaSet.LOID, "", trans.Trans);
                        for (int i = 0; i < formulaItemTable.Rows.Count; ++i)
                        {
                            FormulaSetItem = new FormulaSetItemDAL();
                            FormulaSetItem.ENERGY = Convert.ToDouble(formulaItemTable.Rows[i]["ENERGY"]);
                            FormulaSetItem.FORMULASET = newFormulaSet.LOID;
                            FormulaSetItem.MATERIALMASTER = Convert.ToDouble(formulaItemTable.Rows[i]["MATERIALMASTER"]);
                            FormulaSetItem.PREPARENAME = formulaItemTable.Rows[i]["PREPARENAME"].ToString();
                            if (!Convert.IsDBNull(formulaItemTable.Rows[i]["REFFORMULA"])) FormulaSetItem.REFFORMULA = Convert.ToDouble(formulaItemTable.Rows[i]["REFFORMULA"]);
                            FormulaSetItem.WEIGHT = Convert.ToDouble(formulaItemTable.Rows[i]["WEIGHT"]);
                            FormulaSetItem.WEIGHTRAW = Convert.ToDouble(formulaItemTable.Rows[i]["WEIGHTRAW"]);
                            FormulaSetItem.WEIGHTRIPE = Convert.ToDouble(formulaItemTable.Rows[i]["WEIGHTRIPE"]);
                            ret = FormulaSetItem.InsertCurrentData(userID, trans.Trans);
                            if (!ret)
                            {
                                _error = FormulaSetItem.ErrorMessage;
                                break;
                            }
                        }
                    }
                    if (ret)
                    {
                        FormulaServeDAL FormulaServe = new FormulaServeDAL();
                        DataTable FormulaServeTable = FormulaServe.GetDataList("FORMULASET = " + FormulaSet.LOID, "", trans.Trans);
                        for (int i = 0; i < FormulaServeTable.Rows.Count; ++i)
                        {
                            FormulaServe = new FormulaServeDAL();
                            FormulaServe.GetDataByConditions(newFormulaSet.LOID, FormulaServeTable.Rows[i]["NAME"].ToString(), trans.Trans);
                            FormulaServe.FORMULASET = newFormulaSet.LOID;
                            FormulaServe.NAME = FormulaServeTable.Rows[i]["NAME"].ToString();
                            FormulaServe.WEIGHTRAW = Convert.ToDouble(FormulaServeTable.Rows[i]["WEIGHTRAW"]);
                            FormulaServe.WEIGHTRIPE = Convert.ToDouble(FormulaServeTable.Rows[i]["WEIGHTRIPE"]);
                            if (FormulaServe.OnDB)
                                ret = FormulaServe.UpdateCurrentData(userID, trans.Trans);
                            else
                                ret = FormulaServe.InsertCurrentData(userID, trans.Trans);
                            if (!ret)
                            {
                                _error = FormulaServe.ErrorMessage;
                                break;
                            }
                        }
                    }
                    if (ret)
                    {
                        ret = CopyFormulaDisease(FormulaSet.LOID, newFormulaSet.LOID, userID, trans.Trans);
                    }
                }
                if (ret)
                {
                    _LOID = newFormulaSet.LOID;
                    trans.CommitTransaction();
                }
                else
                    trans.RollbackTransaction();
            }
            catch (Exception ex)
            {
                ret = false;
                _error = ex.Message;
                _LOID = newFormulaSet.LOID;
                trans.CommitTransaction();
            }
            return ret;
        }

        public bool InsertData(FormulaSetDetailData FormulaSetDetail, string UserID, string CurrentTabIndex)
        {
            bool ret = true;
            zTran trans = new zTran();
            trans.CreateTransaction();

            FormulaSetDAL FormulaSet = new FormulaSetDAL();
            //FormulaSet.GetDataByLOID(FormulaSetDetail.LOID, trans.Trans);
            FormulaSet.ACTIVE = (FormulaSetDetail.ACTIVE ? "1" : "0");
            FormulaSet.DISHESTYPE = FormulaSetDetail.DISHESTYPE;
            FormulaSet.ENERGY = FormulaSetDetail.ENERGY;
            FormulaSet.FOODCATEGORY = FormulaSetDetail.FOODCATEGORY;
            FormulaSet.FOODCOOKTYPE = FormulaSetDetail.FOODCOOKTYPE;
            FormulaSet.FOODTYPE = FormulaSetDetail.FOODTYPE;
            FormulaSet.IMGPATH = FormulaSetDetail.IMGPATH;
            FormulaSet.ISELEMENT = (FormulaSetDetail.ISELEMENT ? "Y" : "N");
            FormulaSet.ISONEDISH = (FormulaSetDetail.ISONEDISH ? "Y" : "N");
            FormulaSet.ISSPECIFIC = (FormulaSetDetail.ISSPECIFIC ? "Y" : "N");
            FormulaSet.NAME = FormulaSetDetail.NAME;
            FormulaSet.PACKAGE = FormulaSetDetail.PACKAGE;
            FormulaSet.PORTION = FormulaSetDetail.PORTION;
            FormulaSet.PREPARE = FormulaSetDetail.PREPARE;
            FormulaSet.RECIPE = FormulaSetDetail.RECIPE;
            FormulaSet.SERVEMETHOD = FormulaSetDetail.SERVEMETHOD;
            FormulaSet.STATUS = FormulaSetDetail.STATUS;
            FormulaSet.WEIGHTFORMULA = FormulaSetDetail.WEIGHTFORMULA;
            FormulaSet.WEIGHTPORTION = FormulaSetDetail.WEIGHTPORTION;

            try
            {
                ret = FormulaSet.InsertCurrentData(UserID, trans.Trans);
                if (!ret)
                    _error = FormulaSet.ErrorMessage;

                if (ret && (CurrentTabIndex == "0" || CurrentTabIndex == ""))
                    ret = InsertFormulaSetItem(FormulaSetDetail.FormulaSetItem, UserID, FormulaSet.LOID, trans.Trans);

                if (ret && (CurrentTabIndex == "0" || CurrentTabIndex == ""))
                    ret = InsertRefFormulaSetItem(FormulaSetDetail.RefFormulaSet, UserID, FormulaSet.LOID, trans.Trans);

                if (ret && (CurrentTabIndex == "1" || CurrentTabIndex == ""))
                    ret = InsertFormulaServe(FormulaSetDetail.FormulaServe, UserID, FormulaSet.LOID, trans.Trans);

                if (ret && (CurrentTabIndex == "2" || CurrentTabIndex == ""))
                    ret = InsertFormulaDisease(FormulaSetDetail.FormulaDisease, UserID, FormulaSet.LOID, trans.Trans);

                if (ret)
                    trans.CommitTransaction();
                else
                    trans.RollbackTransaction();

                _LOID = FormulaSet.LOID;
            }
            catch (Exception ex)
            {
                ret = false;
                _error = ex.Message;
                trans.RollbackTransaction();
            }

            return ret;
        }

        public bool UpdateActive(double formulasetID, bool isActive, string userID)
        {
            bool ret = true;
            FormulaSetDAL FormulaSet = new FormulaSetDAL();
            FormulaSet.GetDataByLOID(formulasetID, null);
            FormulaSet.ACTIVE = (isActive ? "1" : "0");
            
            try
            {
                if (FormulaSet.OnDB)
                {
                    ret = FormulaSet.UpdateCurrentData(userID, null);
                    if (!ret)
                        _error = FormulaSet.ErrorMessage;
                }
                else
                {
                    ret = false;
                    _error = Data.Common.Utilities.DataResources.MSGEU002;
                }

                _LOID = FormulaSet.LOID;
            }
            catch (Exception ex)
            {
                ret = false;
                _error = ex.Message;
            }

            return ret;
        }

        public bool UpdateData(FormulaSetDetailData FormulaSetDetail, string UserID, string CurrentTabIndex)
        {
            bool ret = true;
            zTran trans = new zTran();
            trans.CreateTransaction();

            FormulaSetDAL FormulaSet = new FormulaSetDAL();
            FormulaSet.GetDataByLOID(FormulaSetDetail.LOID, trans.Trans);
            FormulaSet.ACTIVE = (FormulaSetDetail.ACTIVE ? "1" : "0");
            FormulaSet.DISHESTYPE = FormulaSetDetail.DISHESTYPE;
            FormulaSet.ENERGY = FormulaSetDetail.ENERGY;
            FormulaSet.FOODCATEGORY = FormulaSetDetail.FOODCATEGORY;
            FormulaSet.FOODCOOKTYPE = FormulaSetDetail.FOODCOOKTYPE;
            FormulaSet.FOODTYPE = FormulaSetDetail.FOODTYPE;
            FormulaSet.IMGPATH = FormulaSetDetail.IMGPATH;
            FormulaSet.ISELEMENT = (FormulaSetDetail.ISELEMENT ? "Y" : "N");
            FormulaSet.ISONEDISH = (FormulaSetDetail.ISONEDISH ? "Y" : "N");
            FormulaSet.ISSPECIFIC = (FormulaSetDetail.ISSPECIFIC ? "Y" : "N");
            FormulaSet.NAME = FormulaSetDetail.NAME;
            FormulaSet.PACKAGE = FormulaSetDetail.PACKAGE;
            FormulaSet.PORTION = FormulaSetDetail.PORTION;
            FormulaSet.PREPARE = FormulaSetDetail.PREPARE;
            FormulaSet.RECIPE = FormulaSetDetail.RECIPE;
            FormulaSet.SERVEMETHOD = FormulaSetDetail.SERVEMETHOD;
            FormulaSet.STATUS = FormulaSetDetail.STATUS;
            FormulaSet.WEIGHTFORMULA = FormulaSetDetail.WEIGHTFORMULA;
            FormulaSet.WEIGHTPORTION = FormulaSetDetail.WEIGHTPORTION;

            try
            {
                if (FormulaSet.OnDB)
                {
                    ret = FormulaSet.UpdateCurrentData(UserID, trans.Trans);
                    if (!ret)
                        _error = FormulaSet.ErrorMessage;

                    if (ret && (CurrentTabIndex == "0" || CurrentTabIndex == ""))
                        ret = InsertFormulaSetItem(FormulaSetDetail.FormulaSetItem, UserID, FormulaSet.LOID, trans.Trans);

                    if (ret && (CurrentTabIndex == "0" || CurrentTabIndex == ""))
                        ret = InsertRefFormulaSetItem(FormulaSetDetail.RefFormulaSet, UserID, FormulaSet.LOID, trans.Trans);

                    if (ret && (CurrentTabIndex == "1" || CurrentTabIndex == ""))
                        ret = InsertFormulaServe(FormulaSetDetail.FormulaServe, UserID, FormulaSet.LOID, trans.Trans);

                    if (ret && (CurrentTabIndex == "2" || CurrentTabIndex == ""))
                        ret = InsertFormulaDisease(FormulaSetDetail.FormulaDisease, UserID, FormulaSet.LOID, trans.Trans);

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

                _LOID = FormulaSet.LOID;
            }
            catch (Exception ex)
            {
                ret = false;
                _error = ex.Message;
                trans.RollbackTransaction();
            }

            return ret;
        }

        public FormulaSetDetailData GetDetails(double LOID)
        {
            FormulaSetDAL FormulaSet = new FormulaSetDAL();
            FormulaSetDetailData FormulaSetDetail = new FormulaSetDetailData();
            FormulaSet.GetDataByLOID(LOID, null);
            FormulaSetDetail.ACTIVE = (FormulaSet.ACTIVE == "1" || FormulaSet.ACTIVE == "");
            FormulaSetDetail.DISHESTYPE = FormulaSet.DISHESTYPE;
            FormulaSetDetail.ENERGY = FormulaSet.ENERGY;
            FormulaSetDetail.FOODCATEGORY = FormulaSet.FOODCATEGORY;
            FormulaSetDetail.FOODCOOKTYPE = FormulaSet.FOODCOOKTYPE;
            FormulaSetDetail.FOODTYPE = FormulaSet.FOODTYPE;
            FormulaSetDetail.IMGPATH = FormulaSet.IMGPATH;
            FormulaSetDetail.ISELEMENT = (FormulaSet.ISELEMENT == "Y");
            FormulaSetDetail.ISONEDISH = (FormulaSet.ISONEDISH == "Y");
            FormulaSetDetail.ISSPECIFIC = (FormulaSet.ISSPECIFIC == "Y");
            FormulaSetDetail.LOID = FormulaSet.LOID;
            FormulaSetDetail.NAME = FormulaSet.NAME;
            FormulaSetDetail.PACKAGE = FormulaSet.PACKAGE;
            FormulaSetDetail.PORTION = FormulaSet.PORTION;
            FormulaSetDetail.PREPARE = FormulaSet.PREPARE;
            FormulaSetDetail.RECIPE = FormulaSet.RECIPE;
            FormulaSetDetail.SERVEMETHOD = FormulaSet.SERVEMETHOD;
            FormulaSetDetail.STATUS = (FormulaSet.STATUS == "" ? "WA" : FormulaSet.STATUS);
            FormulaSetDetail.WEIGHTFORMULA = FormulaSet.WEIGHTFORMULA;
            FormulaSetDetail.WEIGHTPORTION = FormulaSet.WEIGHTPORTION;
            switch (FormulaSet.STATUS)
            {
                case "WA":
                    FormulaSetDetail.STATUSNAME = "กำลังดำเนินการ";
                    break;
                case "TE":
                    FormulaSetDetail.STATUSNAME = "ทดลอง";
                    break;
                case "AP":
                    FormulaSetDetail.STATUSNAME = "อนุมัติ";
                    break;
                case "NA":
                    FormulaSetDetail.STATUSNAME = "ไม่อนุมัติ";
                    break;
                default:
                    FormulaSetDetail.STATUSNAME = "กำลังดำเนินการ";
                    break;
            }

            if (FormulaSet.OnDB && LOID != 0)
                _error = Data.Common.Utilities.DataResources.MSGEV002;

            return FormulaSetDetail;

        }

        public bool DeleteByLOID(double cLOID)
        {
            zTran trans = new zTran();

            FormulaSetDAL FormulaSet = new FormulaSetDAL();
            FormulaSetItemDAL FormulaSetItem = new FormulaSetItemDAL();
            FormulaServeDAL FormulaServe = new FormulaServeDAL();
            FormulaDiseaseDAL FormulaDisease = new FormulaDiseaseDAL();
            trans.CreateTransaction();
            bool ret = true;
            try
            {
                FormulaSetItem.DeleteDataByFormulaSet(cLOID, trans.Trans);
                FormulaServe.DeleteDataByFormulaSet(cLOID, trans.Trans);
                FormulaDisease.DeleteDataByCondition("FORMULASET", cLOID, "", trans.Trans);
                ret = FormulaSet.DeleteDataByLOID(cLOID, trans.Trans);

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

        public bool CheckUniqueKey(double cLOID, string cNAME, double cFOODTYPE, double cFOODCATEGORY, double cPORTION)
        {
            FormulaSetDAL fDAL = new FormulaSetDAL();
            fDAL.GetDataByUniqueKey(cNAME, cFOODTYPE, cFOODCATEGORY, cPORTION, null);
            return !fDAL.OnDB || (cLOID == fDAL.LOID);
        }

        public double GetDivision(double LOID)
        {
            VFormulaSetSearchDAL vDAL = new VFormulaSetSearchDAL();
            return vDAL.GetDivision("LOID = " + LOID, "", null);
        }

    }
}
