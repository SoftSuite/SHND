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
/// FormulaFeedLDFlow Class
/// Version 1.0
/// =========================================================================
/// Create by: Pom
/// Create Date: 13 Jan 2009
/// -------------------------------------------------------------------------
/// Modify By: -
/// Modify From: -
/// Modify Date: -
/// -------------------------------------------------------------------------
/// Remark: -
/// Description:
///    Flow จัดการการทำงานของหน้า FormulaFeedLDSearch 
/// Changes:
///    1.0 - สร้าง
/// -------------------------------------------------------------------------
/// =========================================================================
/// </summary>
/// 

namespace SHND.Flow.Formula
{
    public class FormulaFeedLDFlow
    {
        string _error = "";
        public string ErrorMessage { get { return _error; } }
        double _loid = 0;
        public double LOID { get { return _loid; } }

        public DataTable GetFormulaFeedLDList(string name, double energyfrom, double energyto, double capacityfrom, double capacityto, string orderstr)
        {
            VFormulaFeedLDDAL vDAL = new VFormulaFeedLDDAL();
            string whStr = "";

            if (name != "") whStr += (whStr.Trim() == "" ? "" : " AND ") + " UPPER(NAME) LIKE UPPER('%" + name + "%') ";
            
            if (energyfrom != 0 && energyto != 0)
                whStr += (whStr.Trim() == "" ? "" : " AND ") + " ENERGY BETWEEN " + energyfrom + " AND " + energyto + " ";
            else if (energyfrom != 0)
                whStr += (whStr.Trim() == "" ? "" : " AND ") + " ENERGY >= " + energyfrom.ToString() + " ";
            else if (energyto != 0)
                whStr += (whStr.Trim() == "" ? "" : " AND ") + " ENERGY <= " + energyto.ToString() + " ";

            if (capacityfrom != 0 && capacityto != 0)
                whStr += (whStr.Trim() == "" ? "" : " AND ") + " CAPACITY BETWEEN " + capacityfrom + " AND " + capacityto + " ";
            else if (capacityfrom != 0)
                whStr += (whStr.Trim() == "" ? "" : " AND ") + " CAPACITY >= " + capacityfrom.ToString() + " ";
            else if (capacityto != 0)
                whStr += (whStr.Trim() == "" ? "" : " AND ") + " CAPACITY <= " + capacityto.ToString() + " ";

            if (orderstr == "")
                orderstr = "LOID";
            return vDAL.GetDataList(whStr, orderstr, null);
        }

        public DataTable GetFormulaFeedData(double ffloid)
        {
            FormulaFeedDAL fDAL = new FormulaFeedDAL();
            string whStr = "";

            whStr += "LOID = " + ffloid;
            return fDAL.GetDataList(whStr, "", null);
        }

        public DataTable GetFormulaFeedItemList(string ffloid, string orderStr)
        {
            FormularFeedItemDAL fDAL = new FormularFeedItemDAL();
            string whStr = "";
            whStr += "FORMULAFEED = " + ffloid;
            return fDAL.GetFormulaFeedItem(whStr, orderStr, null);
        }

        public DataTable GetFormulaDiseaseList(string REFLOID, string REFTABLE, string orderStr)
        {
            VFormulaDiseaseDAL vDAL = new VFormulaDiseaseDAL();
            string whStr = "";
            whStr += "REFLOID = " + REFLOID + " AND REFTABLE = '" + REFTABLE + "'";
            return vDAL.GetDataList(whStr, orderStr, null);
        }

        public DataTable GetFormulaNutrientList(string ffloid, string orderStr)
        {
            VFormulafeedNutrientDAL vDAL = new VFormulafeedNutrientDAL();
            string whStr = "";
            whStr += "LOID = " + ffloid;
            return vDAL.GetDataList(whStr, orderStr, null);
        }

        public string GetMaterialMasterName(string mmloid)
        {
            MaterialMasterDAL mmDAL = new MaterialMasterDAL();
            mmDAL.GetDataByLOID(Convert.ToDouble(mmloid), null);
            if (mmDAL.OnDB)
                return mmDAL.NAME;
            else
                return "";
        }

        public DataTable GetDiseaseCategoryByLOID(string dcloid)
        {
            DiseaseCategoryDAL dcDAL = new DiseaseCategoryDAL();
            return dcDAL.GetDataList("LOID = " + dcloid, "", null);
        }
        public string getLiquidCategory()
        {
            VFormulaFeedLDDAL cLiquid = new VFormulaFeedLDDAL();
            return cLiquid.getLiquidCategory();
        }

        public bool InsertData(FormulaFeedData ffData, DataTable dtFiData, string UserID)
        {
            zTran trans = new zTran();
            FormulaFeedDAL ffDAL = new FormulaFeedDAL();

            ffDAL.NAME = ffData.NAME;
            ffDAL.FEEDCATEGORY = ffData.FEEDCATEGORY;
            ffDAL.CAPACITY = ffData.CAPACITY;
            ffDAL.ENERGY = ffData.ENERGY;
            ffDAL.PORTION = ffData.PORTION;
            ffDAL.ACTIVE = (ffData.ACTIVE == true ? "1" : "0"); 
            
            bool ret = true;
            trans.CreateTransaction();

            try
            {
                ret = ffDAL.InsertDataNoMaterialMaster(UserID, trans.Trans);
                if (!ret)
                {
                    trans.RollbackTransaction();
                    _error = ffDAL.ErrorMessage;
                }
                else
                {
                    _loid = ffDAL.LOID;

                    if (dtFiData != null)
                    {
                        //insert ลง table FormulaFeedItem มี FK เป็น FormulaFeed
                        if (UpdateFormulaFeedItem(_loid, dtFiData, trans, UserID) == true)
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
                        trans.CommitTransaction();
                        ret = true;
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

        private bool UpdateFormulaFeedItem(double ff_loid, DataTable dtFiData, zTran trans, string UserID)
        {
            bool ret = true;
            string ffiloidlist = "";

            try
            {
                if (dtFiData.Rows.Count > 0)
                {
                    for (int i = 0; i < dtFiData.Rows.Count; i++)
                    {
                        if (dtFiData.Rows[i]["FFILOID"].ToString() != "")
                            ffiloidlist += (ffiloidlist == "" ? "" : ",") + dtFiData.Rows[i]["FFILOID"].ToString();
                    }
                }

                //ลบ formulafeeditem ที่ไม่ได้อยู่ใน list
                ret = DeleteFormulaFeedItemNotInList(ffiloidlist, ff_loid, trans);
                if (ret)
                {
                    ret = doUpdateFormulaFeedItem(ff_loid, dtFiData, trans, UserID);
                    if (ret)
                    {
                        return true;
                    }
                    else
                    {
                        return false;
                    }
                }
                else
                {
                    return false;
                }
            }
            catch (Exception ex)
            {
                _error = ex.Message;
                ret = false;
            }

            return ret;
        }

        private bool DeleteFormulaFeedItemNotInList(string ffiloidlist, double ff_loid, zTran trans)
        {
            bool ret = true;
            FormularFeedItemDAL fiDAL = new FormularFeedItemDAL();
            ret = fiDAL.DeleteNotInLOIDList(ffiloidlist, ff_loid.ToString(), trans.Trans);
            if (ret)
                return true;
            else
            {
                _error = fiDAL.ErrorMessage;
                return false;
            }
        }

        private bool doUpdateFormulaFeedItem(double ff_loid, DataTable dtFiData, zTran trans, string UserID)
        {
            bool ret = true;

            for (int i = 0; i < dtFiData.Rows.Count; i++)
            {
                if (dtFiData.Rows[i]["FFILOID"].ToString() == "")
                {
                    FormularFeedItemDAL fiDAL = new FormularFeedItemDAL();
                    fiDAL.FORMULAFEED = ff_loid;
                    fiDAL.MATERIALMASTER = Convert.ToDouble(dtFiData.Rows[i]["MMLOID"]);
                    fiDAL.QTY = Convert.ToDouble(dtFiData.Rows[i]["QTY"]);
                    fiDAL.ENERGY = Convert.ToDouble(dtFiData.Rows[i]["ENERGY"]);
                    fiDAL.UNIT = Convert.ToDouble(dtFiData.Rows[i]["UNITLOID"]);

                    ret = fiDAL.InsertCurrentData(UserID, trans.Trans);

                    if (ret == false)
                    {
                        _error = fiDAL.ErrorMessage;
                        return false;
                    }
                }
                else
                {
                    FormularFeedItemDAL fiDAL = new FormularFeedItemDAL();
                    fiDAL.GetDataByLOID(Convert.ToDouble(dtFiData.Rows[i]["FFILOID"].ToString()), trans.Trans);
                    fiDAL.FORMULAFEED = ff_loid;
                    fiDAL.MATERIALMASTER = Convert.ToDouble(dtFiData.Rows[i]["MMLOID"]);
                    fiDAL.QTY = Convert.ToDouble(dtFiData.Rows[i]["QTY"]);
                    fiDAL.ENERGY = Convert.ToDouble(dtFiData.Rows[i]["ENERGY"]);
                    fiDAL.UNIT = Convert.ToDouble(dtFiData.Rows[i]["UNITLOID"]);

                    ret = fiDAL.UpdateCurrentData(UserID, trans.Trans);

                    if (ret == false)
                    {
                        _error = fiDAL.ErrorMessage;
                        return false;
                    }
                }  
            }

            return true;
        }

        public bool UpdateData(FormulaFeedData ffData, DataTable dtFiData, string UserID)
        {
            zTran trans = new zTran();
            FormulaFeedDAL ffDAL = new FormulaFeedDAL();
            ffDAL.GetDataByLOID(ffData.LOID, null);

            ffDAL.NAME = ffData.NAME;
            ffDAL.FEEDCATEGORY = ffData.FEEDCATEGORY;
            ffDAL.CAPACITY = ffData.CAPACITY;
            ffDAL.ENERGY = ffData.ENERGY;
            ffDAL.PORTION = ffData.PORTION;
            ffDAL.ACTIVE = (ffData.ACTIVE == true ? "1" : "0"); 

            bool ret = true;

            try
            {
                if (ffDAL.OnDB)
                {
                    trans.CreateTransaction();

                    ret = ffDAL.UpdateDataNoMaterialMaster(UserID, trans.Trans);
                    if (!ret)
                    {
                        trans.RollbackTransaction();
                        _error = ffDAL.ErrorMessage;
                    }
                    else
                    {
                        _loid = ffDAL.LOID;
                        if (dtFiData != null)
                        {
                            // update table FormulaFeedItem มี FK เป็น FormulaFeed
                            if (UpdateFormulaFeedItem(_loid, dtFiData, trans, UserID) == true)
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
                            trans.CommitTransaction();
                            ret = true;
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

        public DataTable GetFormulaFeedItemNutrient(string material_master_loid, string unitloid)
        {
            VFormulaItemNutrientDAL vDAL = new VFormulaItemNutrientDAL();
            string whrStr = "MATERIALMASTER = " + material_master_loid + " AND UNIT = " + unitloid;
            return vDAL.GetDataList(whrStr, "", null);
        }

        public bool InsertDataTabDisease(FormulaFeedData ffData, DataTable dtflDisease, string UserID)
        {
            zTran trans = new zTran();
            FormulaFeedDAL ffDAL = new FormulaFeedDAL();

            ffDAL.NAME = ffData.NAME;
            ffDAL.FEEDCATEGORY = ffData.FEEDCATEGORY;
            ffDAL.CAPACITY = ffData.CAPACITY;
            ffDAL.ENERGY = ffData.ENERGY;
            ffDAL.PORTION = ffData.PORTION;
            ffDAL.ACTIVE = (ffData.ACTIVE == true ? "1" : "0");

            bool ret = true;
            trans.CreateTransaction();

            try
            {
                ret = ffDAL.InsertDataNoMaterialMaster(UserID, trans.Trans);
                if (!ret)
                {
                    trans.RollbackTransaction();
                    _error = ffDAL.ErrorMessage;
                }
                else
                {
                    _loid = ffDAL.LOID;

                    if (dtflDisease != null)
                    {
                        //insert ลง table FormulaDisease
                        if (UpdateFormulaDisease(_loid, dtflDisease, trans, UserID) == true)
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
                        trans.CommitTransaction();
                        ret = true;
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

        private bool UpdateFormulaDisease(double ff_loid, DataTable dtflDisease, zTran trans, string UserID)
        {
            bool ret = true;
            string fd_loidlist = "";

            try
            {
                if (dtflDisease.Rows.Count > 0)
                {
                    for (int i = 0; i < dtflDisease.Rows.Count; i++)
                    {
                        if (dtflDisease.Rows[i]["FDLOID"].ToString() != "")
                            fd_loidlist += (fd_loidlist == "" ? "" : ",") + dtflDisease.Rows[i]["FDLOID"].ToString();
                    }
                }

                //ลบ formulaDisease ที่ไม่ได้อยู่ใน list
                ret = DeleteFormulaDiseaseNotInList(fd_loidlist, ff_loid, trans);
                if (ret)
                {
                    ret = doUpdateFormulaDisease(ff_loid, dtflDisease, trans, UserID);
                }
            }
            catch (Exception ex)
            {
                _error = ex.Message;
                ret = false;
            }

            return ret;
        }

        private bool DeleteFormulaDiseaseNotInList(string fd_loidlist, double ff_loid, zTran trans)
        {
            bool ret = true;
            FormulaDiseaseDAL fDAL = new FormulaDiseaseDAL();
            ret = fDAL.DeleteNotInLOIDList(fd_loidlist, ff_loid.ToString(), "FORMULAFEED", trans.Trans);
            if (ret)
                return true;
            else
            {
                _error = fDAL.ErrorMessage;
                return false;
            }
        }

        private bool doUpdateFormulaDisease(double ff_loid, DataTable dtflDisease, zTran trans, string UserID)
        {
            bool ret = true;

            for (int i = 0; i < dtflDisease.Rows.Count; i++)
            {
                if (dtflDisease.Rows[i]["FDLOID"].ToString() == "")
                {
                    FormulaDiseaseDAL fDAL = new FormulaDiseaseDAL();
                    fDAL.REFTABLE = "FORMULAFEED";
                    fDAL.REFLOID = ff_loid;
                    fDAL.DISEASECATEGORY = Convert.ToDouble(dtflDisease.Rows[i]["DCLOID"]);
                    fDAL.ISHIGH = dtflDisease.Rows[i]["FDISHIGH"].ToString();
                    fDAL.ISLOW = dtflDisease.Rows[i]["FDISLOW"].ToString();
                    fDAL.ISNON = dtflDisease.Rows[i]["FDISNON"].ToString();

                    ret = fDAL.InsertCurrentData(UserID, trans.Trans);

                    if (ret == false)
                    {
                        _error = fDAL.ErrorMessage;
                        return false;
                    }
                }
                else
                {
                    FormulaDiseaseDAL fDAL = new FormulaDiseaseDAL();
                    fDAL.GetDataByLOID(Convert.ToDouble(dtflDisease.Rows[i]["FDLOID"].ToString()), trans.Trans);
                    fDAL.REFTABLE = "FORMULAFEED";
                    fDAL.REFLOID = ff_loid;
                    fDAL.DISEASECATEGORY = Convert.ToDouble(dtflDisease.Rows[i]["DCLOID"]);
                    fDAL.ISHIGH = dtflDisease.Rows[i]["FDISHIGH"].ToString();
                    fDAL.ISLOW = dtflDisease.Rows[i]["FDISLOW"].ToString();
                    fDAL.ISNON = dtflDisease.Rows[i]["FDISNON"].ToString();

                    ret = fDAL.UpdateCurrentData(UserID, trans.Trans);

                    if (ret == false)
                    {
                        _error = fDAL.ErrorMessage;
                        return false;
                    }
                }
            }

            return true;
        }

        public bool UpdateDataTabDisease(FormulaFeedData ffData, DataTable dtflDisease, string UserID)
        {
            zTran trans = new zTran();
            FormulaFeedDAL ffDAL = new FormulaFeedDAL();
            ffDAL.GetDataByLOID(ffData.LOID, null);

            ffDAL.NAME = ffData.NAME;
            ffDAL.FEEDCATEGORY = ffData.FEEDCATEGORY;
            ffDAL.CAPACITY = ffData.CAPACITY;
            ffDAL.ENERGY = ffData.ENERGY;
            ffDAL.PORTION = ffData.PORTION;
            ffDAL.ACTIVE = (ffData.ACTIVE == true ? "1" : "0");

            bool ret = true;

            try
            {
                if (ffDAL.OnDB)
                {
                    trans.CreateTransaction();

                    ret = ffDAL.UpdateDataNoMaterialMaster(UserID, trans.Trans);
                    if (!ret)
                    {
                        trans.RollbackTransaction();
                        _error = ffDAL.ErrorMessage;
                    }
                    else
                    {
                        _loid = ffDAL.LOID;
                        if (dtflDisease != null)
                        {
                            // update table FormulaDisease
                            if (UpdateFormulaDisease(_loid, dtflDisease, trans, UserID) == true)
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
                            trans.CommitTransaction();
                            ret = true;
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

        public bool DeleteByFormulaFeedLOID(string ffloid)
        {
            zTran trans = new zTran();
            string whrStr = "";
            FormulaFeedDAL ffDAL = new FormulaFeedDAL();
            FormularFeedItemDAL ffiDAL = new FormularFeedItemDAL();
            FormulaDiseaseDAL fdDAL = new FormulaDiseaseDAL();

            bool ret = true;
            try
            {
                trans.CreateTransaction();

                //ลบข้อมูลที่ table FORMULADISEASE ที่ REFTABLE = 'FORMULAFEED' AND REFLOID = " + ffloid
                whrStr = " REFTABLE = 'FORMULAFEED' AND REFLOID = " + ffloid;
                ret = fdDAL.DeleteFormulaDisease(whrStr, trans.Trans);

                if (ret)
                {
                    //ลบข้อมูลที่ table FORMULAFEEDITEM ที่ FORMULAFEED = ffloid
                    whrStr = " FORMULAFEED = " + ffloid;
                    ret = ffiDAL.DeleteFormulaFeedItem(whrStr, trans.Trans);
                    if (ret)
                    {
                        //ลบข้อมูลที่ table FORMULAFEED ที่ LOID = ffloid
                        whrStr = " LOID = " + ffloid;
                        ret = ffDAL.DeleteFormulaFeed(whrStr, trans.Trans);
                        if (!ret)
                        {
                            _error = ffDAL.ErrorMessage;
                        }
                    }
                    else
                    {
                        _error = ffiDAL.ErrorMessage;
                    }
                }
                else
                {
                    _error = fdDAL.ErrorMessage;
                }

                if (ret)
                {
                    trans.CommitTransaction();
                }
                else
                    trans.RollbackTransaction();
            }
            catch (Exception ex)
            {
                trans.RollbackTransaction();
                _error = ex.Message;
                ret = false;
            }

            return ret;
        }

    }
}
