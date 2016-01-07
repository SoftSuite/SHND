using System;
using System.Collections.Generic;
using System.Data.OracleClient;
using System.Text;
using System.Data;
using SHND.DAL.Views;
using SHND.DAL.Tables;
using SHND.Data.Tables;
using SHND.DAL.Utilities;
using System.Collections;
//using DB = SHND.DAL.Utilities.OracleDB;
using zTran = SHND.DAL.Utilities.OracleTransactionDB;

/// <summary>
/// FoodTypeFlow Class
/// Version 1.0
/// =========================================================================
/// Create by: Tan
/// Create Date: 6 Jan 2009
/// -------------------------------------------------------------------------
/// Modify By: -
/// Modify From: -
/// Modify Date: -
/// -------------------------------------------------------------------------
/// Remark: -
/// Description:
///    Flow จัดการการทำงานของหน้า Blenderize Diet 
/// Changes:
///    1.0 - สร้าง
/// -------------------------------------------------------------------------
/// =========================================================================
/// </summary>
/// 
namespace SHND.Flow.Formula
{
    public class BlenderizeDietFlow
    {
        string _error = "";
        double _LOID = 0;
        public string ErrorMessage { get { return _error; } }
        public double LOID { get { return _LOID; } }


        public DataTable GetMasterList(string Name, string CapFrom, string CapTo, string EnFrom, string EnTo, string OrderText)
        {
            VFormularFeedBDDAL vDAL = new VFormularFeedBDDAL();
            return vDAL.GetDataListByCondition(Name, CapFrom, CapTo, EnFrom, EnTo, OrderText, null);
        }

        public DataTable GetMasterList()
        {
            VFormularFeedBDDAL vDAL = new VFormularFeedBDDAL();
            return vDAL.GetDataList("", "", null);
        }

        public DataTable GetMasterListByCondition(string Code, string Name, string Devision)
        {
            string whStr = "";
            // create where condition


            VFormularFeedBDDAL vDAL = new VFormularFeedBDDAL();
            return vDAL.GetDataList(whStr, "", null);
        }

        public DataTable GetMasterListSorted(string SortField, string SortDirection)
        {
            VFormularFeedBDDAL vDAL = new VFormularFeedBDDAL();
            return vDAL.GetDataList("", SortField + " " + SortDirection, null);
        }

        public DataTable GetBlenderizeItemList(double formulaFeedID)
        {
            VFormulaFeedItemNutrientDAL VFormulaItem = new VFormulaFeedItemNutrientDAL();
            DataTable dt = VFormulaItem.GetDataListByFormulaFeed(formulaFeedID, "MATERIALNAME", null);
            dt.Columns.Add("RANK", typeof(double));
            for (int i = 0; i < dt.Rows.Count; ++i)
            {
                dt.Rows[i]["RANK"] = i + 1;
            }
            return dt;
        }

        public DataTable GetBlenderizeItemList()
        {
            FormularFeedItemDAL VFormulaItem = new FormularFeedItemDAL();
            DataTable dt = VFormulaItem.GetDataListByFormulaFeed(0, "", null);
            dt.Columns.Add("RANK", typeof(double));
            dt.Rows.Add(dt.NewRow());
            return dt;
        }

        public DataTable GetFormulaDiseaseList(double formulaFeedID)
        {
            VFormulaDiseaseDAL VFormulaDisease = new VFormulaDiseaseDAL();
            DataTable dt = VFormulaDisease.GetDataListByCondition("FORMULAFEED", formulaFeedID, "NAME", null);
            for (int i = 0; i < dt.Rows.Count; ++i)
            {
                dt.Rows[i]["LOID"] = i + 1;
            }
            return dt;
        }

        public DataTable GetDiseaseCategoryByLOID(string dcloid)
        {
            DiseaseCategoryDAL dcDAL = new DiseaseCategoryDAL();
            return dcDAL.GetDataList("LOID = " + dcloid, "", null);
        }
        public string GetLiquidCategory()
        {
            VFormularFeedBDDAL bdDAL = new VFormularFeedBDDAL();
            return bdDAL.getLiquidCategory();
        }

        public DataTable GetFormulaNutrientList(double formulaFeedID)
        {
            VFormulafeedNutrientDAL VFormulaSetNutrient = new VFormulafeedNutrientDAL();
            return VFormulaSetNutrient.GetDataListByFormulaFeed(formulaFeedID, "NUTRIENTNAME", null);
        }

        public DataTable GetEnergyByUnitList(double Master, double Unit)
        {
            VFormulaItemNutrientDAL VFormulaItem = new VFormulaItemNutrientDAL();
            DataTable dt = VFormulaItem.GetDataListByUnit(Master,Unit, "", null);
            dt.Columns.Add("RANK", typeof(double));
            dt.Rows.Add(dt.NewRow());
            return dt;
        }

        public FormulaFeedData GetDetails(double LOID)
        {
            FormulaFeedDAL ffDAL = new FormulaFeedDAL();
            FormulaFeedData ffData = new FormulaFeedData();
            ffDAL.GetDataByLOID(LOID, null);
            ffData.ACTIVE = (ffDAL.ACTIVE == "1" || ffDAL.ACTIVE == "");
            ffData.ENERGY = ffDAL.ENERGY;
            ffData.LOID = ffDAL.LOID;
            ffData.NAME = ffDAL.NAME;
            ffData.CAPACITY = ffDAL.CAPACITY;
            ffData.CAPACITYRATE = ffDAL.CAPACITYRATE;
            ffData.ENERGYRATE = ffDAL.ENERGYRATE;
            ffData.CARBOHYDRATE = ffDAL.CARBOHYDRATE;
            ffData.FAT = ffDAL.FAT;
            ffData.PROTEIN = ffDAL.PROTEIN;


            if (ffDAL.OnDB && LOID != 0)
                _error = Data.Common.Utilities.DataResources.MSGEV002;

            return ffData;

        }

        public bool InsertData(FormulaFeedData ffData, string UserID, string CurrentTabIndex)
        {
            bool ret = true;
            zTran trans = new zTran();
            trans.CreateTransaction();

            FormulaFeedDAL ffDAL = new FormulaFeedDAL();
            //ffDAL.GetDataByLOID(ffData.LOID, trans.Trans);
            ffDAL.ACTIVE = (ffData.ACTIVE ? "1" : "0");
            ffDAL.ENERGY = ffData.ENERGY;
            ffDAL.FEEDCATEGORY = ffData.FEEDCATEGORY;
            ffDAL.NAME = ffData.NAME;
            ffDAL.CAPACITY = ffData.CAPACITY;
            ffDAL.CAPACITYRATE = ffData.CAPACITYRATE;
            ffDAL.ENERGYRATE = ffData.ENERGYRATE;
            ffDAL.CARBOHYDRATE = ffData.CARBOHYDRATE;
            ffDAL.FAT = ffData.FAT;
            ffDAL.PROTEIN = ffData.PROTEIN;

            try
            {
                ret = ffDAL.InsertCurrentData(UserID, trans.Trans);
                if (!ret)
                    _error = ffDAL.ErrorMessage;

                if (ret && (CurrentTabIndex == "0" || CurrentTabIndex == ""))
                    ret = InsertFormulaFeedItem(ffData.FormulaFeedItem, UserID, ffDAL.LOID, trans.Trans);
                if (ret && (CurrentTabIndex == "1" || CurrentTabIndex == ""))
                    ret = InsertFormulaDisease(ffData.FormulaDisease, UserID, ffDAL.LOID, trans.Trans);
                if (ret)
                    trans.CommitTransaction();
                else
                    trans.RollbackTransaction();

                _LOID = ffDAL.LOID;
            }
            catch (Exception ex)
            {
                ret = false;
                _error = ex.Message;
                trans.RollbackTransaction();
            }

            return ret;
        }

        public bool UpdateData(FormulaFeedData ffData, string UserID, string CurrentTabIndex)
        {
            bool ret = true;
            zTran trans = new zTran();
            trans.CreateTransaction();

            FormulaFeedDAL ffDAL = new FormulaFeedDAL();
            ffDAL.GetDataByLOID(ffData.LOID, trans.Trans);
            ffDAL.ACTIVE = (ffData.ACTIVE ? "1" : "0");
            ffDAL.ENERGY = ffData.ENERGY;
            ffDAL.FEEDCATEGORY = ffData.FEEDCATEGORY;
            ffDAL.NAME = ffData.NAME;
            ffDAL.CAPACITY = ffData.CAPACITY;
            ffDAL.CAPACITYRATE = ffData.CAPACITYRATE;
            ffDAL.ENERGYRATE = ffData.ENERGYRATE;
            ffDAL.CARBOHYDRATE = ffData.CARBOHYDRATE;
            ffDAL.FAT = ffData.FAT;
            ffDAL.PROTEIN = ffData.PROTEIN;

            try
            {
                if (ffDAL.OnDB)
                {
                    ret = ffDAL.UpdateCurrentData(UserID, trans.Trans);
                    if (!ret)
                        _error = ffDAL.ErrorMessage;

                    if (ret && (CurrentTabIndex == "0" || CurrentTabIndex == ""))
                        ret = InsertFormulaFeedItem(ffData.FormulaFeedItem, UserID, ffDAL.LOID, trans.Trans);
                    if (ret && (CurrentTabIndex == "1" || CurrentTabIndex == ""))
                        ret = InsertFormulaDisease(ffData.FormulaDisease, UserID, ffDAL.LOID, trans.Trans);

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

                _LOID = ffDAL.LOID;
            }
            catch (Exception ex)
            {
                ret = false;
                _error = ex.Message;
                trans.RollbackTransaction();
            }

            return ret;
        }

        private bool InsertFormulaFeedItem(ArrayList arrFormulaFeedItem, string userID, double FormulaFeedID, OracleTransaction trans)
        {
            bool ret = true;
            string materialMasterList = "";
            for (int i = 0; i < arrFormulaFeedItem.Count; ++i)
            {
                FormularFeedItemData datFormulaFeedItem = (FormularFeedItemData)arrFormulaFeedItem[i];
                materialMasterList += (materialMasterList == "" ? "" : ",") + datFormulaFeedItem.MATERIALMASTER.ToString();
            }
            FormularFeedItemDAL FormulaFeedItem = new FormularFeedItemDAL();
            if (materialMasterList != "") FormulaFeedItem.doDelete("FORMULAFEED = " + FormulaFeedID + " AND MATERIALMASTER NOT IN (" + materialMasterList + ") ", trans);
            for (int i = 0; i < arrFormulaFeedItem.Count; ++i)
            {
                FormulaFeedItem = new FormularFeedItemDAL();
                FormularFeedItemData datFormulaFeedItem = (FormularFeedItemData)arrFormulaFeedItem[i];
                FormulaFeedItem.GetDataByUniqueKey(datFormulaFeedItem.FORMULAFEED, datFormulaFeedItem.MATERIALMASTER, trans);
                FormulaFeedItem.ENERGY = datFormulaFeedItem.ENERGY;
                FormulaFeedItem.FORMULAFEED = FormulaFeedID;
                FormulaFeedItem.MATERIALMASTER = datFormulaFeedItem.MATERIALMASTER;
             //   FormulaFeedItem.REFFORMULA = datFormulaFeedItem.REFFORMULA;
                FormulaFeedItem.QTY = datFormulaFeedItem.QTY;
                FormulaFeedItem.UNIT = datFormulaFeedItem.UNIT;

                if (!FormulaFeedItem.OnDB)
                    ret = FormulaFeedItem.InsertCurrentData(userID, trans);
                else
                    ret = FormulaFeedItem.UpdateCurrentData(userID, trans);

                if (!ret)
                {
                    _error = FormulaFeedItem.ErrorMessage;
                    break;
                }
            }
            return ret;
        }

        private bool InsertFormulaDisease(ArrayList arrFormulaDisease, string userID, double FormulaSetID, OracleTransaction trans)
        {
            bool ret = true;
            FormulaDiseaseDAL FormulaDisease = new FormulaDiseaseDAL();
            FormulaDisease.DeleteDataByCondition("FORMULAFEED", FormulaSetID, "", trans);

            for (int i = 0; i < arrFormulaDisease.Count; ++i)
            {
                FormulaDisease = new FormulaDiseaseDAL();
                FormulaDiseaseData datFormulaDisease = (FormulaDiseaseData)arrFormulaDisease[i];
                FormulaDisease.DISEASECATEGORY = datFormulaDisease.DISEASECATEGORY;
                FormulaDisease.REFLOID = FormulaSetID;
                FormulaDisease.REFTABLE = "FORMULAFEED";
                FormulaDisease.ISHIGH = datFormulaDisease.ISHIGH;
                FormulaDisease.ISLOW = datFormulaDisease.ISLOW;
                FormulaDisease.ISNON = datFormulaDisease.ISNON;
                ret = FormulaDisease.InsertCurrentData(userID, trans);
                if (!ret)
                {
                    _error = FormulaDisease.ErrorMessage;
                    break;
                }
            }
            return ret;
        }
        public bool DeleteByLOID(double cLOID)
        {
            zTran trans = new zTran();

            FormulaFeedDAL FormulaSet = new FormulaFeedDAL();
            FormularFeedItemDAL FormulaFeedItem = new FormularFeedItemDAL();
            FormulaDiseaseDAL FormulaDisease = new FormulaDiseaseDAL();
            trans.CreateTransaction();
            bool ret = true;
            try
            {
                FormulaFeedItem.DeleteDataByFormulaFeed(cLOID, trans.Trans);
                FormulaDisease.DeleteDataByCondition("FORMULAFEED", cLOID, "", trans.Trans);
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

        public bool CopyData(double refFormulaFeedID, string userID)
        {
            bool ret = true;
            zTran trans = new zTran();
            trans.CreateTransaction();
            FormulaFeedDAL FormulaFeed = new FormulaFeedDAL();
            FormulaFeedDAL newFormulaFeed = new FormulaFeedDAL();
            try
            {
                FormulaFeed.GetDataByLOID(refFormulaFeedID, trans.Trans);
                if (FormulaFeed.OnDB)
                {
                    newFormulaFeed.ACTIVE = "Y";
                    newFormulaFeed.ENERGY = FormulaFeed.ENERGY;
                    newFormulaFeed.NAME = FormulaFeed.GetRunningCopyName(FormulaFeed.NAME, trans.Trans);
                    newFormulaFeed.PORTION = FormulaFeed.PORTION;
                    newFormulaFeed.CAPACITY = FormulaFeed.CAPACITY;
                    newFormulaFeed.CAPACITYRATE = FormulaFeed.CAPACITYRATE;
                    newFormulaFeed.CARBOHYDRATE = FormulaFeed.CARBOHYDRATE;
                    newFormulaFeed.ENERGYRATE = FormulaFeed.ENERGYRATE;
                    newFormulaFeed.FEEDCATEGORY = FormulaFeed.FEEDCATEGORY;
                    newFormulaFeed.PROTEIN = FormulaFeed.PROTEIN;
                    newFormulaFeed.FAT = FormulaFeed.FAT;

                    ret = newFormulaFeed.InsertCurrentData(userID, trans.Trans);
                    if (!ret)
                        _error = FormulaFeed.ErrorMessage;

                    if (ret)
                    {
                        FormularFeedItemDAL FormulaFeedItem = new FormularFeedItemDAL();
                        DataTable formulaItemTable = FormulaFeedItem.GetDataList("FORMULAFEED = " + FormulaFeed.LOID, "", trans.Trans);
                        for (int i = 0; i < formulaItemTable.Rows.Count; ++i)
                        {
                            FormulaFeedItem.ENERGY = Convert.ToDouble(formulaItemTable.Rows[i]["ENERGY"]);
                            FormulaFeedItem.FORMULAFEED = newFormulaFeed.LOID;
                            FormulaFeedItem.MATERIALMASTER = Convert.ToDouble(formulaItemTable.Rows[i]["MATERIALMASTER"]);
                            FormulaFeedItem.QTY = Convert.ToDouble(formulaItemTable.Rows[i]["QTY"]);
                            FormulaFeedItem.UNIT = Convert.ToDouble(formulaItemTable.Rows[i]["UNIT"]);
                            FormulaFeedItem.ENERGY = Convert.ToDouble(formulaItemTable.Rows[i]["ENERGY"]);
                            ret = FormulaFeedItem.InsertCurrentData(userID, trans.Trans);
                            if (!ret)
                            {
                                _error = FormulaFeedItem.ErrorMessage;
                                break;
                            }
                        }
                    }
                    if (ret)
                    {
                        FormulaDiseaseDAL FormulaDisease = new FormulaDiseaseDAL();
                        DataTable formulaDiseaseTable = FormulaDisease.GetDataList("REFTABLE = 'FORMULAFEED' AND REFLOID = " + FormulaFeed.LOID, "", trans.Trans);
                        for (int i = 0; i < formulaDiseaseTable.Rows.Count; ++i)
                        {
                            FormulaDisease.DISEASECATEGORY = Convert.ToDouble(formulaDiseaseTable.Rows[i]["DISEASECATEGORY"]);
                            if (!Convert.IsDBNull(formulaDiseaseTable.Rows[i]["ISHIGH"])) FormulaDisease.ISHIGH = formulaDiseaseTable.Rows[i]["ISHIGH"].ToString();
                            if (!Convert.IsDBNull(formulaDiseaseTable.Rows[i]["ISLOW"])) FormulaDisease.ISLOW = formulaDiseaseTable.Rows[i]["ISLOW"].ToString();
                            if (!Convert.IsDBNull(formulaDiseaseTable.Rows[i]["ISNON"])) FormulaDisease.ISNON = formulaDiseaseTable.Rows[i]["ISNON"].ToString();
                            FormulaDisease.REFLOID = newFormulaFeed.LOID;
                            FormulaDisease.REFTABLE = "FORMULAFEED";
                            ret = FormulaDisease.InsertCurrentData(userID, trans.Trans);
                            if (!ret)
                            {
                                _error = FormulaDisease.ErrorMessage;
                                break;
                            }
                        }
                    }
                }
                if (ret)
                {
                    _LOID = newFormulaFeed.LOID;
                    trans.CommitTransaction();
                }
                else
                    trans.RollbackTransaction();
            }
            catch (Exception ex)
            {
                ret = false;
                _error = ex.Message;
                _LOID = newFormulaFeed.LOID;
                trans.CommitTransaction();
            }
            return ret;
        }

        public bool CheckUniqueKey(double cLOID, string cNAME)
        {
            FormulaFeedDAL fDAL = new FormulaFeedDAL();
            fDAL.GetDataByNAME(cNAME, null);
            return !fDAL.OnDB || (cLOID == fDAL.LOID);
        }

    }
}
