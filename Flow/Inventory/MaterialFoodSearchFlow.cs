using System;
using System.Collections.Generic;
using System.Text;
using SHND.DAL.Tables;
using SHND.Data.Tables;
using SHND.DAL.Utilities;
using System.Collections;
using System.Data;
using SHND.DAL.Views;
using zTran = SHND.DAL.Utilities.OracleTransactionDB;

/// <summary>
/// MaterialFoodSearchFlow Class
/// Version 1.0
/// =========================================================================
/// Create by: Pom
/// Create Date: 5 Jan 2009
/// -------------------------------------------------------------------------
/// Modify By: -
/// Modify From: -
/// Modify Date: -
/// -------------------------------------------------------------------------
/// Remark: -
/// Description:
///    Flow จัดการการทำงานของหน้า MaterialFoodSearch 
/// Changes:
///    1.0 - สร้าง
/// -------------------------------------------------------------------------
/// =========================================================================
/// </summary>
/// 

namespace SHND.Flow.Inventory
{
    public class MaterialFoodSearchFlow
    {
        string _error = "";
        public string ErrorMessage { get { return _error; } }
        double _loid = 0;
        public double LOID { get { return _loid; } }

        public DataTable GetMaterialMasterList(string materialclass, string materialgroup, string materialname, string orderstr)
        {
            V_MaterialMasterDAL vDAL = new V_MaterialMasterDAL();
            string whStr = "";

            whStr += "MASTERTYPE = 'FO'";
            if (materialclass != "0") whStr += (whStr.Trim() == "" ? "" : " AND ") + " CLASSLOID = " + materialclass + " ";
            if (materialgroup != "0") whStr += (whStr.Trim() == "" ? "" : " AND ") + " GROUPLOID = " + materialgroup + " ";
            if (materialname != "") whStr += (whStr.Trim() == "" ? "" : " AND ") + " UPPER(MATERIALNAME) LIKE UPPER('%" + materialname + "%')";

            return vDAL.GetDataList(whStr, orderstr, null);
        }

        public bool CheckNameExist(string material_name)
        {
            MaterialMasterDAL mDAL = new MaterialMasterDAL();
            mDAL.GetDataByNAME(material_name, null);
            if (mDAL.OnDB)
                return true;
            else
                return false;
        }

        public DataTable GetDataListForExcel(string materialclass, string materialgroup, string materialname, string masterType, string orderstr)
        {
            V_MaterialMasterDAL vDAL = new V_MaterialMasterDAL();
            return vDAL.GetDataListForExcel(Convert.ToDouble(materialclass), Convert.ToDouble(materialgroup), materialname, masterType, orderstr, null);
        }

        public DataTable GetMaterialMasterByLOID(string loid)
        {
            V_MaterialMasterDAL vDAL = new V_MaterialMasterDAL();
            string whStr = "";

            whStr += "LOID = " + loid;
            return vDAL.GetDataList(whStr, "", null);
        }

        public DataTable GetMaterialMasterUnit(string material_master_loid)
        {
            VMaterialMasterUnitDAL vDAL = new VMaterialMasterUnitDAL();

            return vDAL.GetDataListByMaterialMaster(material_master_loid);
        }

        public DataTable GetMaterialNutrient(string material_master_loid, string orderStr)
        {
            VMaterialNutrientDAL vDAL = new VMaterialNutrientDAL();

            return vDAL.GetDataListByMaterialMaster(material_master_loid, orderStr);
        }

        public DataTable GetMaterialSeason(string material_master_loid)
        {
            MaterialSeasonDAL msDAL = new MaterialSeasonDAL();

            return msDAL.GetDataByMaterialMasterLOID(material_master_loid);
        }

        public double GetEnergy(string material_master_loid)
        {
            MaterialMasterDAL vDAL = new MaterialMasterDAL();

            return vDAL.GetEnergy(material_master_loid);
        }

        public double GetEnergy100G(string material_master_loid, zTran trans)
        {
            MaterialMasterDAL vDAL = new MaterialMasterDAL();

            return vDAL.GetEnergy100G(material_master_loid, trans.Trans);
        }

        public MaterialMasterData GetFoodDetailData(double loid)
        {
            MaterialMasterDAL msDAL = new MaterialMasterDAL();
            MaterialMasterData msData = new MaterialMasterData();
            msDAL.GetDataByLOID(loid, null);

            if (msDAL.OnDB)
            {
                msData.LOID = msDAL.LOID;
                msData.CODE = msDAL.CODE;
                msData.ACTIVE = msDAL.ACTIVE;
                msData.SAPCODE = msDAL.SAPCODE;
                msData.NAME = msDAL.NAME;
                msData.MATERIALCLASS = msDAL.MATERIALCLASS;
                msData.MATERIALGROUP = msDAL.MATERIALGROUP;
                msData.UNIT = msDAL.UNIT;
                msData.COST = msDAL.COST;
                msData.PRICE = msDAL.PRICE;
                msData.WEIGHT = msDAL.WEIGHT;
                msData.WEIGHTCOOK = msDAL.WEIGHTCOOK;
                msData.WEIGHTPREPARE = msDAL.WEIGHTPREPARE;
                msData.WEIGHTCOOKBO = msDAL.WEIGHTCOOKBO;
                msData.WEIGHTCOOKFR = msDAL.WEIGHTCOOKFR;
                msData.WEIGHTCOOKRO = msDAL.WEIGHTCOOKRO;
                msData.WEIGHTCOOKFY = msDAL.WEIGHTCOOKFY;
                msData.WEIGHTCOOKST = msDAL.WEIGHTCOOKST;
                msData.WEIGHTCOOKNN = msDAL.WEIGHTCOOKNN;
                msData.WEIGHTCOOKPE = msDAL.WEIGHTCOOKPE;
                msData.OILFY = msDAL.OILFY;
                msData.OILFR = msDAL.OILFR;
                msData.SPEC = msDAL.SPEC;
                msData.ORDERTYPE = msDAL.ORDERTYPE;
                msData.DIVISION = msDAL.DIVISION;
                msData.STOCKOUTBREAKFAST = msDAL.STOCKOUTBREAKFAST;
                msData.STOCKOUTLUNCH = msDAL.STOCKOUTLUNCH;
                msData.STOCKOUTDINNER = msDAL.STOCKOUTDINNER;
                msData.ISCOUNT = msDAL.ISCOUNT;
                msData.ISMENU = msDAL.ISMENU;
                msData.MINSTOCK = msDAL.MINSTOCK;
                msData.MAXSTOCK = msDAL.MAXSTOCK;
                msData.REMARKS = msDAL.REMARKS;
                msData.NUTRIENTRATE = msDAL.NUTRIENTRATE;
            }
            return msData;
        }

        public bool InsertData(MaterialMasterData msData, string UserID)
        {
            zTran trans = new zTran();
            MaterialMasterDAL msDAL = new MaterialMasterDAL();

            msDAL.ACTIVE = msData.ACTIVE;
            msDAL.SAPCODE = msData.SAPCODE;
            msDAL.NAME = msData.NAME;
            msDAL.MATERIALCLASS = msData.MATERIALCLASS;
            msDAL.MATERIALGROUP = msData.MATERIALGROUP;
            msDAL.UNIT = msData.UNIT;
            msDAL.COST = msData.COST;
            msDAL.PRICE = msData.PRICE;
            msDAL.WEIGHT = msData.WEIGHT;
            msDAL.WEIGHTPREPARE = msData.WEIGHTPREPARE;
            msDAL.WEIGHTCOOK = msData.WEIGHTCOOK;
            msDAL.WEIGHTCOOKBO = msData.WEIGHTCOOKBO;
            msDAL.WEIGHTCOOKFR = msData.WEIGHTCOOKFR;
            msDAL.WEIGHTCOOKRO = msData.WEIGHTCOOKRO;
            msDAL.WEIGHTCOOKFY = msData.WEIGHTCOOKFY;
            msDAL.WEIGHTCOOKST = msData.WEIGHTCOOKST;
            msDAL.WEIGHTCOOKNN = msData.WEIGHTCOOKNN;
            msDAL.WEIGHTCOOKPE = msData.WEIGHTCOOKPE;
            msDAL.OILFR = msData.OILFR;
            msDAL.OILFY = msData.OILFY;
            msDAL.SPEC = msData.SPEC;
            msDAL.ORDERTYPE = msData.ORDERTYPE;
            msDAL.DIVISION = msData.DIVISION;
            msDAL.STOCKOUTBREAKFAST = msData.STOCKOUTBREAKFAST;
            msDAL.STOCKOUTLUNCH = msData.STOCKOUTLUNCH;
            msDAL.STOCKOUTDINNER = msData.STOCKOUTDINNER;
            msDAL.ISCOUNT = msData.ISCOUNT;
            msDAL.ISMENU = msData.ISMENU;
            msDAL.MINSTOCK = msData.MINSTOCK;
            msDAL.MAXSTOCK = msData.MAXSTOCK;
            msDAL.REMARKS = msData.REMARKS;

            bool ret = true;
            trans.CreateTransaction();

            try
            {
                ret = msDAL.InsertCurrentData(UserID, trans.Trans);
                if (!ret)
                {
                    trans.RollbackTransaction();
                    _error = msDAL.ErrorMessage;
                }
                else
                {
                    _loid = msDAL.LOID;
                    // insert ลง table MaterialUnit มี FK เป็น MaterialMater
                    if (InsertMaterialUnitMain(_loid, msData, trans, UserID) == true)
                    {
                        trans.CommitTransaction();
                        ret = true;
                    }
                    else
                    {
                        trans.RollbackTransaction();
                        ret = false;
                    }
                }
            }
            catch (Exception ex)
            {
                ret = false;
                trans.RollbackTransaction();
                _error = ex.Message;
            }

            return ret;
        }

        private bool InsertMaterialUnitMain(double material_master_loid, MaterialMasterData msData, zTran trans, string UserID)
        {
            bool ret = true;
            MaterialUnitDAL muDAL = new MaterialUnitDAL();

            muDAL.MATERIALMASTER = material_master_loid;
            muDAL.UNIT = msData.UNIT;
            muDAL.WEIGHT = msData.WEIGHT;
            muDAL.COST = msData.COST;
            muDAL.PRICE = msData.PRICE;
            muDAL.ISSTOCKIN = "Y";
            muDAL.ISSTOCKOUT = "Y";
            muDAL.ISFORMULA = "Y";
            muDAL.ACTIVE = "1";
            muDAL.MULTIPLY = 1;
            muDAL.ISMAIN = "Y";

            try
            {
                ret = muDAL.InsertCurrentData(UserID, trans.Trans);
                if (ret == false)
                {
                    _error = muDAL.ErrorMessage;
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }

            return ret;
        }

        public bool UpdateData(MaterialMasterData msData, string UserID)
        {
            zTran trans = new zTran();
            MaterialMasterDAL msDAL = new MaterialMasterDAL();
            msDAL.GetDataByLOID(msData.LOID, null);

            if (msDAL.NAME != msData.NAME)
            {
                if (CheckNameExist(msData.NAME) == true)
                {
                    _error = "มีชื่อวัสดุอาหาร " + msData.NAME + " ในระบบแล้ว";
                    return false;
                }
            }

            msDAL.ACTIVE = msData.ACTIVE;
            msDAL.SAPCODE = msData.SAPCODE;
            msDAL.NAME = msData.NAME;
            msDAL.MATERIALCLASS = msData.MATERIALCLASS;
            msDAL.MATERIALGROUP = msData.MATERIALGROUP;
            msDAL.UNIT = msData.UNIT;
            msDAL.COST = msData.COST;
            msDAL.PRICE = msData.PRICE;
            msDAL.WEIGHT = msData.WEIGHT;
            msDAL.WEIGHTPREPARE = msData.WEIGHTPREPARE;
            msDAL.WEIGHTCOOKBO = msData.WEIGHTCOOKBO;
            msDAL.WEIGHTCOOKFR = msData.WEIGHTCOOKFR;
            msDAL.WEIGHTCOOKRO = msData.WEIGHTCOOKRO;
            msDAL.WEIGHTCOOKFY = msData.WEIGHTCOOKFY;
            msDAL.WEIGHTCOOKST = msData.WEIGHTCOOKST;
            msDAL.WEIGHTCOOKNN = msData.WEIGHTCOOKNN;
            msDAL.WEIGHTCOOKPE = msData.WEIGHTCOOKPE;
            msDAL.WEIGHTCOOK = msData.WEIGHTCOOK;
            msDAL.OILFY = msData.OILFY;
            msDAL.OILFR = msData.OILFR;
            msDAL.SPEC = msData.SPEC;
            msDAL.ORDERTYPE = msData.ORDERTYPE;
            msDAL.DIVISION = msData.DIVISION;
            msDAL.STOCKOUTBREAKFAST = msData.STOCKOUTBREAKFAST;
            msDAL.STOCKOUTLUNCH = msData.STOCKOUTLUNCH;
            msDAL.STOCKOUTDINNER = msData.STOCKOUTDINNER;
            msDAL.ISCOUNT = msData.ISCOUNT;
            msDAL.ISMENU = msData.ISMENU;
            msDAL.MINSTOCK = msData.MINSTOCK;
            msDAL.MAXSTOCK = msData.MAXSTOCK;
            msDAL.REMARKS = msData.REMARKS;

            bool ret = true;
         
            try
            {
                if (msDAL.OnDB)
                {
                    trans.CreateTransaction();

                    ret = msDAL.UpdateCurrentData(UserID, trans.Trans);
                    if (!ret)
                    {
                        trans.RollbackTransaction();
                        _error = msDAL.ErrorMessage;
                    }
                    else
                    {
                        _loid = msDAL.LOID;
                        // update table MaterialUnit ที่ unit เป็นหน่วยหลัก ISMAIN = Y มี FK เป็น MaterialMater
                        if (UpdateMaterialUnitMain(_loid, msData, trans, UserID) == true)
                        {
                            trans.CommitTransaction();
                            ret = true;
                        }
                        else
                        {
                            trans.RollbackTransaction();
                            ret = false;
                        }
                    }
                }
                else
                {
                    _error = Data.Common.Utilities.DataResources.MSGEU002;
                    ret = false;
                }
            }
            catch (Exception ex)
            {
                trans.RollbackTransaction();
                _error = ex.Message;
                ret = false;
            }

            return ret;

        }

        private bool UpdateMaterialUnitMain(double material_master_loid, MaterialMasterData msData, zTran trans, string UserID)
        {
            bool ret = true;
            MaterialUnitDAL muDAL = new MaterialUnitDAL();

            try
            {
                ret = muDAL.UpdateCurrentDataUnitMain(UserID, trans.Trans, material_master_loid.ToString(), msData.UNIT.ToString(), msData.WEIGHT.ToString(), msData.COST.ToString(), msData.PRICE.ToString());
                if (ret == false)
                {
                    _error = muDAL.ErrorMessage;
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }

            return ret;
        }

        public bool DeleteByLOID(ArrayList arrLOID)
        {
            zTran trans = new zTran();
            string whrStr = "";
            MaterialMasterDAL msDAL = new MaterialMasterDAL();
            MaterialUnitDAL muDAL = new MaterialUnitDAL();
            MaterialNutrientDAL mnDAL = new MaterialNutrientDAL();
            MaterialSeasonDAL mssDAL = new MaterialSeasonDAL();

            bool ret = true;
            try
            {
                trans.CreateTransaction();

                for (int i = 0; i < arrLOID.Count; i++)
                {
                    whrStr = " MATERIALMASTER = " + arrLOID[i].ToString();
                    ret = muDAL.DeleteMaterialUnit(whrStr, trans.Trans);

                    if (ret)
                    {
                        ret = mnDAL.DeleteMaterialNutrient(whrStr, trans.Trans);
                        if (ret)
                        {
                            ret = mssDAL.DeleteMaterialSeason(whrStr, trans.Trans);
                            if (ret)
                            {
                                string tmpWhr = " LOID = " + arrLOID[i].ToString();
                                ret = msDAL.DeleteMaterialMaster(tmpWhr, trans.Trans);
                                if (ret == false)
                                {
                                    _error = msDAL.ErrorMessage;
                                    trans.RollbackTransaction();
                                    return false;
                                }
                            }
                            else
                            {
                                _error = mssDAL.ErrorMessage;
                                trans.RollbackTransaction();
                                return false;
                            }   
                        }
                        else
                        {
                            _error = mnDAL.ErrorMessage;
                            trans.RollbackTransaction();
                            return false;
                        }
                    }
                    else
                    {
                        _error = muDAL.ErrorMessage;
                        trans.RollbackTransaction();
                        return false;
                    }                  
                }

                if (ret == true)
                {
                    trans.CommitTransaction();
                    return true;
                }
            }
            catch (Exception ex)
            {
                trans.RollbackTransaction();
                _error = ex.Message;
                ret = false;             
            }

            return ret;
        }

        public bool UpdateMaterialUnit(DataTable dt, string material_master_loid, string UserID)
        {
            bool ret = true;
            string whrStr = "";
            zTran trans = new zTran();
            MaterialUnitDAL muDAL = new MaterialUnitDAL();

            try
            {
                trans.CreateTransaction();

                whrStr = " MATERIALMASTER = " + material_master_loid;
                // ลบ หน่วยทั้งหมดที่มีอยู่ของ MaterialMaster ที่ส่งเข้ามา
                ret = muDAL.DeleteMaterialUnit(whrStr, trans.Trans);

                if (ret)
                {
                    // insert หน่วยทั้งหมดเข้าสู่ตาราง MaterialUnit
                    if (InsertMaterialUnit(dt, material_master_loid, trans, UserID))
                    {
                        trans.CommitTransaction();
                        ret = true;
                    }
                    else
                    {
                        trans.RollbackTransaction();
                        ret = false;
                    }
                }
                else
                {
                    trans.RollbackTransaction();
                    _error = muDAL.ErrorMessage;
                    ret = false;
                }                
            }
            catch (Exception ex)
            {
                trans.RollbackTransaction();
                _error = ex.Message;
                ret = false;
            }

            return ret;
        }

        private bool InsertMaterialUnit(DataTable dt, string material_master_loid, zTran trans, string UserID)
        {
            bool ret = true;
            try
            {
                for (int i = 0; i < dt.Rows.Count; i++)
                { 
                    MaterialUnitDAL muDAL = new MaterialUnitDAL();
                    muDAL.MATERIALMASTER = Convert.ToDouble(material_master_loid);
                    muDAL.UNIT = Convert.ToDouble(dt.Rows[i]["UNITLOID"]);

                    if (dt.Rows[i]["WEIGHT"].ToString() != "")
                        muDAL.WEIGHT = Convert.ToDouble(dt.Rows[i]["WEIGHT"].ToString());
                    if (dt.Rows[i]["COST"].ToString() != "")
                        muDAL.COST = Convert.ToDouble(dt.Rows[i]["COST"].ToString());
                    if (dt.Rows[i]["PRICE"].ToString() != "")
                        muDAL.PRICE = Convert.ToDouble(dt.Rows[i]["PRICE"].ToString());
                    if (dt.Rows[i]["MULTIPLY"].ToString() != "")
                        muDAL.MULTIPLY = Convert.ToDouble(dt.Rows[i]["MULTIPLY"].ToString());

                    muDAL.ISSTOCKIN = dt.Rows[i]["ISSTOCKIN"].ToString();
                    muDAL.ISSTOCKOUT = dt.Rows[i]["ISSTOCKOUT"].ToString();
                    muDAL.ISFORMULA = dt.Rows[i]["ISFORMULA"].ToString();
                    muDAL.ACTIVE = dt.Rows[i]["ACTIVE"].ToString();
                    muDAL.ISMAIN = dt.Rows[i]["ISMAIN"].ToString();

                    ret = muDAL.InsertCurrentData(UserID, trans.Trans);

                    if (ret == false)
                        return false;
                }
                ret = true;
            }
            catch (Exception ex)
            {
                ret = false;
                throw ex;
            }

            return ret;
        }

        public bool UpdateMaterialNutrient(DataTable dt, string material_master_loid, string UserID)
        {
            bool ret = true;
            string whrStr = "";
            zTran trans = new zTran();
            MaterialNutrientDAL mnDAL = new MaterialNutrientDAL();

            try
            {
                trans.CreateTransaction();

                whrStr = " MATERIALMASTER = " + material_master_loid;
                // ลบ สารอาหารทั้งหมดที่มีอยู่ของ MaterialMaster ที่ส่งเข้ามา
                ret = mnDAL.DeleteMaterialNutrient(whrStr, trans.Trans);

                if (ret)
                {
                    // insert สาอาหารทั้งหมดเข้าสู่ตาราง MaterialNutrient
                    ret = InsertMaterialNutrient(dt, material_master_loid, trans, UserID);
                    //{
                        //if (UpdateEnergy(material_master_loid, UserID, trans))
                        //{
                        //    trans.CommitTransaction();
                        //    ret = true;
                        //}
                        //else
                        //{
                        //    trans.RollbackTransaction();
                        //    ret = false;
                        //}                 
                    //}
                    if (!ret)
                    {
                        trans.RollbackTransaction();
                        ret = false;
                    }
                    else
                        trans.CommitTransaction();

                }
                else
                {
                    trans.RollbackTransaction();
                    _error = mnDAL.ErrorMessage;
                    ret = false;
                }
            }
            catch (Exception ex)
            {
                trans.RollbackTransaction();
                _error = ex.Message;
                ret = false;
            }

            return ret;
        }

        private bool UpdateEnergy(string material_master_loid, string UserID, zTran trans)
        {
            bool ret = true;
            MaterialMasterDAL mDAL = new MaterialMasterDAL();

            try
            {
                double energy100g = GetEnergy100G(material_master_loid, trans);

                mDAL.GetDataByLOID(Convert.ToDouble(material_master_loid), trans.Trans);
                if (mDAL.OnDB)
                {
                    mDAL.ENERGY = energy100g;
                    ret = mDAL.UpdateCurrentData(UserID, trans.Trans);
                }
                else
                {
                    ret = false;
                }
            }
            catch(Exception ex)
            {
                ret = false;
                throw ex;
            }

            return ret;
        }

        public bool UpdateEnergy(string material_master_loid, double nutrient_rate)
        {
            bool ret = true;
            MaterialMasterDAL msDAL = new MaterialMasterDAL();
            msDAL.ENERGY = GetFunctionEnergy(material_master_loid);
            msDAL.NUTRIENTRATE = nutrient_rate;
            ret = msDAL.UpdateEnergy(material_master_loid);
            return ret;
        }

        public double GetFunctionEnergy(string material_master_loid)
        {
            MaterialMasterDAL vDAL = new MaterialMasterDAL();

            return vDAL.GetFunctionEnergy(material_master_loid);
        }

        private bool InsertMaterialNutrient(DataTable dt, string material_master_loid, zTran trans, string UserID)
        {
            bool ret = true;
            try
            {
                for (int i = 0; i < dt.Rows.Count; i++)
                {
                    MaterialNutrientDAL mnDAL = new MaterialNutrientDAL();
                    mnDAL.MATERIALMASTER = Convert.ToDouble(material_master_loid);

                    if (dt.Rows[i]["NUTRIENTLOID"].ToString() != "")
                        mnDAL.NUTRIENT = Convert.ToDouble(dt.Rows[i]["NUTRIENTLOID"].ToString());
                    if (dt.Rows[i]["QTY"].ToString() != "")
                        mnDAL.QTY = Convert.ToDouble(dt.Rows[i]["QTY"].ToString());

                    ret = mnDAL.InsertCurrentData(UserID, trans.Trans);

                    if (ret == false)
                        return false;
                }
                ret = true;
            }
            catch (Exception ex)
            {
                ret = false;
                throw ex;
            }

            return ret;
        }

        public string GetUnitNameByNutrientLOID(string nutrient_loid)
        {
            VNutrientDAL vDAL = new VNutrientDAL();
            string tmp = vDAL.GetUnitName(nutrient_loid);
            return tmp;
        }

        public bool UpdateMaterialSeason(MaterialSeasonData msData, string UserID)
        { 
            bool ret = true;
            MaterialSeasonDAL msDAL = new MaterialSeasonDAL();

            try
            {
                msDAL.GetDataByMATERIALMASTER(msData.MATERIALMASTER, null);

                msDAL.M1 = msData.M1;
                msDAL.M2 = msData.M2;
                msDAL.M3 = msData.M3;
                msDAL.M4 = msData.M4;
                msDAL.M5 = msData.M5;
                msDAL.M6 = msData.M6;
                msDAL.M7 = msData.M7;
                msDAL.M8 = msData.M8;
                msDAL.M9 = msData.M9;
                msDAL.M10 = msData.M10;
                msDAL.M11 = msData.M11;
                msDAL.M12 = msData.M12;

                if (msDAL.OnDB)
                {
                    ret = msDAL.UpdateCurrentData(UserID, null);
                }
                else
                {
                    msDAL.MATERIALMASTER = msData.MATERIALMASTER;
                    ret = msDAL.InsertCurrentData(UserID, null);
                }

                if (ret)
                    return true;
                else
                {
                    _error = msDAL.ErrorMessage;
                    return false;
                }

            }
            catch (Exception ex)
            {
                _error = ex.Message;
                return false;
            }          
        }
    }

}
