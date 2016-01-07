using System;
using System.Collections.Generic;
using System.Text;
using System.Data;
using SHND.DAL.Tables;
using SHND.DAL.Views;
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
/// Create Date: 12 Jan 2009
/// -------------------------------------------------------------------------
/// Modify By: -
/// Modify From: -
/// Modify Date: -
/// -------------------------------------------------------------------------
/// Remark: -
/// Description:
///    Flow จัดการการทำงานของหน้า MaterialFeed 
/// Changes:
///    1.0 - สร้าง
/// -------------------------------------------------------------------------
/// =========================================================================
/// </summary>
/// 

namespace SHND.Flow.Inventory
{
    public class MaterialToolFlow
    {
        string _error = "";
        public string ErrorMessage { get { return _error; } }
        double _loid = 0;
        public double LOID { get { return _loid; } }

        public DataTable GetMasterList()
        {
            V_MaterialMasterDAL vDAL = new V_MaterialMasterDAL();
            return vDAL.GetDataList("", "", null);
        }

        public DataTable GetMasterList(string Name, string Group, string OrderText)
        {
            V_MaterialMasterDAL vDAL = new V_MaterialMasterDAL();

            string whStr = " MASTERTYPE IN ('TL','OT')";
            if (Name != "") whStr += (whStr.Trim() == "" ? "" : " AND ") + " UPPER(MATERIALNAME) LIKE '%" + Name.ToUpper() + "%' ";
            if (Group != "") whStr += (whStr.Trim() == "" ? "" : " AND ") + " GROUPLOID = " + Convert.ToDouble(Group) + " ";

            return vDAL.GetDataList(whStr, OrderText, null);
        }

        public DataTable GetDataListForExcel(string materialgroup, string materialname, string masterType, string orderstr)
        {
            V_MaterialMasterDAL vDAL = new V_MaterialMasterDAL();
            return vDAL.GetDataListForExcel(0, Convert.ToDouble(materialgroup), materialname, masterType, orderstr, null);
        }

        public DataTable GetMasterListByCondition(string Code, string Name, string Devision)
        {
            string whStr = "";
            // create where condition


            V_MaterialMasterDAL vDAL = new V_MaterialMasterDAL();
            return vDAL.GetDataList(whStr, "", null);
        }

        public DataTable GetMasterListSorted(string SortField, string SortDirection)
        {
            V_MaterialMasterDAL vDAL = new V_MaterialMasterDAL();
            return vDAL.GetDataList("", SortField + " " + SortDirection, null);
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

        public MaterialMasterData GetFeedDetailData(double loid)
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
                msData.SAPWAREHOUSE = msDAL.SAPWAREHOUSE;
                msData.NAME = msDAL.NAME;
                msData.MATERIALGROUP = msDAL.MATERIALGROUP;
                msData.MILKCATEGORY = msDAL.MILKCATEGORY;
                msData.UNIT = msDAL.UNIT;
                msData.COST = msDAL.COST;
                msData.PRICE = msDAL.PRICE;
                msData.WEIGHT = msDAL.WEIGHT;
                msData.SPEC = msDAL.SPEC;
                msData.ORDERTYPE = msDAL.ORDERTYPE;
                msData.DIVISION = msDAL.DIVISION;
                msData.ISCOUNT = msDAL.ISCOUNT;
                msData.MINSTOCK = msDAL.MINSTOCK;
                msData.MAXSTOCK = msDAL.MAXSTOCK;
                msData.REMARKS = msDAL.REMARKS;
                msData.ARTICLECODE = msDAL.ARTICLECODE;
            }
            return msData;
        }
        public bool InsertData(MaterialMasterData msData, string UserID)
        {
            zTran trans = new zTran();
            MaterialMasterDAL msDAL = new MaterialMasterDAL();

            VMaterialGroupDAL mgDAL = new VMaterialGroupDAL();
            mgDAL.GetDataByLOID(msData.MATERIALGROUP, null);

            msDAL.ACTIVE = msData.ACTIVE;
            msDAL.SAPCODE = msData.SAPCODE;
            msDAL.SAPWAREHOUSE = msData.SAPWAREHOUSE;
            msDAL.NAME = msData.NAME;
            msDAL.MATERIALCLASS = mgDAL.MATERIALCLASS;
            msDAL.MATERIALGROUP = msData.MATERIALGROUP;
            msDAL.MILKCATEGORY = msData.MILKCATEGORY;
            msDAL.UNIT = msData.UNIT;
            msDAL.COST = msData.COST;
            msDAL.PRICE = msData.PRICE;
            msDAL.WEIGHT = msData.WEIGHT;
            msDAL.SPEC = msData.SPEC;
            msDAL.ORDERTYPE = msData.ORDERTYPE;
            msDAL.DIVISION = msData.DIVISION;
            msDAL.ISCOUNT = msData.ISCOUNT;
            msDAL.MINSTOCK = msData.MINSTOCK;
            msDAL.MAXSTOCK = msData.MAXSTOCK;
            msDAL.REMARKS = msData.REMARKS;
            msDAL.ARTICLECODE = msData.ARTICLECODE;
            msDAL.ISMENU = msData.ISMENU;

            bool ret = true;

            try
            {
                ret = msDAL.InsertCurrentData(UserID, null);
                if (!ret)
                {
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

            VMaterialGroupDAL mgDAL = new VMaterialGroupDAL();
            mgDAL.GetDataByLOID(msData.MATERIALGROUP, null);

            msDAL.ACTIVE = msData.ACTIVE;
            msDAL.SAPCODE = msData.SAPCODE;
            msDAL.SAPWAREHOUSE = msData.SAPWAREHOUSE;
            msDAL.NAME = msData.NAME;
            msDAL.MATERIALCLASS = mgDAL.MATERIALCLASS;
            msDAL.MATERIALGROUP = msData.MATERIALGROUP;
            msDAL.MILKCATEGORY = msData.MILKCATEGORY;
            msDAL.UNIT = msData.UNIT;
            msDAL.COST = msData.COST;
            msDAL.PRICE = msData.PRICE;
            msDAL.WEIGHT = msData.WEIGHT;
            msDAL.SPEC = msData.SPEC;
            msDAL.ORDERTYPE = msData.ORDERTYPE;
            msDAL.DIVISION = msData.DIVISION;
            msDAL.ISCOUNT = msData.ISCOUNT;
            msDAL.MINSTOCK = msData.MINSTOCK;
            msDAL.MAXSTOCK = msData.MAXSTOCK;
            msDAL.REMARKS = msData.REMARKS;
            msDAL.ARTICLECODE = msData.ARTICLECODE;

            bool ret = true;

            try
            {
                if (msDAL.OnDB)
                {
                    ret = msDAL.UpdateCurrentData(UserID, null);
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
                ret = muDAL.doDelete(whrStr, trans.Trans);

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

                    muDAL.InsertCurrentData(UserID, trans.Trans);
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

        public bool CheckUniqName(string cName, string cLOID)
        {
            MaterialMasterDAL msDAL = new MaterialMasterDAL();
            msDAL.GetDataByNAME(cName, null);
            return !msDAL.OnDB || (cLOID == msDAL.LOID.ToString());
        }
        public bool CheckUniqSapCode(string cName, string cLOID)
        {
            MaterialMasterDAL msDAL = new MaterialMasterDAL();
            msDAL.GetDataBySAPCODE(cName, null);
            return !msDAL.OnDB || (cLOID == msDAL.LOID.ToString());
        }
    }

}


