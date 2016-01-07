using System;
using System.Collections.Generic;
using System.Text;
using System.Data;
using SHND.DAL.Views;
using SHND.DAL.Tables;
using SHND.Data.Tables;
using SHND.Data.Views;
using System.Collections;
using zTran = SHND.DAL.Utilities.OracleTransactionDB;

/// <summary>
/// FormulaFeedMDFlow Class
/// Version 1.0
/// =========================================================================
/// Create by: Nang
/// Create Date: 6 Jan 2009
/// -------------------------------------------------------------------------
/// Modify By: -
/// Modify From: -
/// Modify Date: -
/// -------------------------------------------------------------------------
/// Remark: -
/// Description:
///    Flow จัดการการทำงานของหน้า FormularFeedMD 
/// Changes:
///    1.0 - สร้าง
/// -------------------------------------------------------------------------
/// =========================================================================
/// </summary>
/// 


namespace SHND.Flow.Formula
{

    public class FormulaFeedMDFlow
    {
        string _error = "";
        public string ErrorMessage { get { return _error; } }

        #region Get Data Search
        public DataTable GetFormulaFeedMDSearch(double foodtype, double energyfrom, double energyto, double capfrom, double capto, string orderstr)
        {
            VFormulaFeedMDDAL vDAL = new VFormulaFeedMDDAL();
            string wr = "";
            if (foodtype != 0 )
                wr = wr + (wr == "" ? " " : " AND ") + "MATERIALMASTER ="+ foodtype + "";
            //เช็คพลังงาน
            if (energyfrom != 0 && energyto != 0)
                wr = wr + (wr == "" ? " " : " AND ") + " ENERGY BETWEEN " + energyfrom + " AND " + energyto + "";
            else if (energyfrom != 0)
                wr = wr + (wr == "" ? " " : " AND ") + " ENERGY >= " + energyfrom + "";
            else if (energyto != 0)
                wr = wr + (wr == "" ? " " : " AND ") + " ENERGY <= " + energyto + "";

            //เช็คปริมาณ
            if (capfrom != 0 && capto != 0)
                wr = wr + (wr == "" ? " " : " AND ") + " CAPACITY BETWEEN " + capfrom + " AND " + capto + "";
            else if (capfrom != 0)
                wr = wr + (wr == "" ? " " : " AND ") + " CAPACITY >= " + capfrom + "";
            else if (capto != 0)
                wr = wr + (wr == "" ? " " : " AND ") + " CAPACITY <= " + capto + "";


            return vDAL.GetDataListField(wr, orderstr, null);
        }
        #endregion

        #region Get Data Popup

        public DataTable GetDataList()
        {
            V_MaterialMasterDAL vmDAL = new V_MaterialMasterDAL();
            return vmDAL.GetDataList("", "", null);
        }

        public double getFILoid(double mmloid)
        {
            V_MaterialMasterDAL vmDAL = new V_MaterialMasterDAL();
            double filoid = 0;
            filoid = vmDAL.GetFILoid("MM.LOID = " + mmloid + " AND FI.MATERIALMASTER <> " + mmloid + "", "", null);
            return filoid;
        }

        public DataTable GetNutrient(double Floid)
        {
            VFormulafeedNutrientDAL vDAL = new VFormulafeedNutrientDAL();
            return vDAL.GetDataByField("LOID = " + Floid + "", "NUTRIENTNAME", null);
        }

        public FormulaFeedData GetFormulaFeedData(double floid)
        {
            FormulaFeedDAL fDAL = new FormulaFeedDAL();
            FormulaFeedData fData = new FormulaFeedData();
            fDAL.GetDataByLOID(floid, null);
            if (fDAL.OnDB)
            {
                fData.CAPACITY = fDAL.CAPACITY;
                fData.CAPACITYRATE = fDAL.CAPACITYRATE;
                fData.ACTIVE = (fDAL.ACTIVE == "1");
                fData.LOID = fDAL.LOID;
                fData.CARBOHYDRATE = fDAL.CARBOHYDRATE;
                fData.ENERGY = fDAL.ENERGY;
                fData.ENERGYRATE = fDAL.ENERGYRATE;
                fData.MATERIALMASTER = fDAL.MATERIALMASTER;
            }
            else
                _error = Data.Common.Utilities.DataResources.MSGEU002;

            return fData;
        }

        public DataTable GetFormulaFeedItemData(double floid)
        {
            FormularFeedItemDAL fiDAL = new FormularFeedItemDAL();
            return fiDAL.GetDataByFormulaFeed("FF.LOID = " + floid + "", "VMM.MATERIALNAME", null);
        }

        public DataTable GetWater()
        {
            MaterialMasterDAL mDAL = new MaterialMasterDAL();
            return mDAL.GetWater("MATERIALMASTER.NAME = 'น้ำ'", "", null);
        }

        #endregion

        #region Calculator
        public DataTable CalculateInventory(double mmloid)
        {
            V_MaterialMasterDAL vmDAL = new V_MaterialMasterDAL();
            DataTable dt = new DataTable();
            dt = vmDAL.GetFormulaFeeMD("MM.LOID = " + mmloid + "", "", null);
            return dt;
        }

        public DataTable CalculateFormulaFeed(double mmloid)
        {
            FormularFeedItemDAL fiDAL = new FormularFeedItemDAL();
            DataTable dt = new DataTable();
            dt = fiDAL.GetCalFormulaFeedNew("VMM.LOID = " + mmloid + "", "", null);
            return dt;
        }

        public double CalculateEnergy(double cap, double capRate, double enerRate)
        {
            double str = 0;
            str = cap * enerRate;
            if (str == 0)
                return str;

            str = str / capRate;
            str = Convert.ToDouble(str.ToString());
            return str;
        }


        #endregion

        #region Event on Formulafeed

        public double InsertDataFormulaFeed(FormulaFeedData fData, string UserID)
        {
            double floid= 0;
            FormulaFeedDAL fDAL = new FormulaFeedDAL();
            fDAL.CAPACITY = Convert.ToDouble(fData.CAPACITY);
            fDAL.FEEDCATEGORY = "C";
            fDAL.MATERIALMASTER = Convert.ToDouble(fData.MATERIALMASTER);
            fDAL.ENERGY = Convert.ToDouble(fData.ENERGY);
            fDAL.CAPACITYRATE = Convert.ToDouble(fData.CAPACITYRATE);
            fDAL.ENERGYRATE = Convert.ToDouble(fData.ENERGYRATE);
            fDAL.ACTIVE = (fData.ACTIVE ? "1" : "0");

            bool ret = true;

            try
            {
                ret = fDAL.InsertCurrentData(UserID, null);
                if (!ret) 
                    _error = fDAL.ErrorMessage;
                else
                     floid = fDAL.LOID;
            }
            catch (Exception ex)
            {
                _error = ex.Message;
            }

            return floid;
        }

        public double UpdateDataFormulaFeed(FormulaFeedData fData, string UserID)
        {
            FormulaFeedDAL fDAL = new FormulaFeedDAL();
            fDAL.GetDataByLOID(fData.LOID, null);

            fDAL.CAPACITY = Convert.ToDouble(fData.CAPACITY);
            fDAL.FEEDCATEGORY = "C";
            fDAL.MATERIALMASTER = Convert.ToDouble(fData.MATERIALMASTER);
            fDAL.ENERGY = Convert.ToDouble(fData.ENERGY);
            fDAL.CAPACITYRATE = Convert.ToDouble(fData.CAPACITYRATE);
            fDAL.ENERGYRATE = Convert.ToDouble(fData.ENERGYRATE);
            fDAL.ACTIVE = (fData.ACTIVE ? "1" : "0");

            bool ret = true;

            try
            {
                if (fDAL.OnDB)
                {
                    ret = fDAL.UpdateCurrentData(UserID, null);
                    if (!ret) _error = fDAL.ErrorMessage;

                    return fDAL.LOID;
                }
                else
                {
                    _error = Data.Common.Utilities.DataResources.MSGEU002;
                    return 0;
                }
            }
            catch (Exception ex)
            {
                _error = ex.Message;
                return 0;
            }
        }

        public bool DeleteFormulaFeedByLoid(double fLOID)
        {
            zTran trans = new zTran();

            FormulaFeedDAL fDAL = new FormulaFeedDAL();
            trans.CreateTransaction();
            bool ret = true;
            try
            {
                if (DeleteFormulaFeedItemByLOID(Convert.ToDouble(fLOID), trans))
                {
                    if (fDAL.DeleteDataByLOID(Convert.ToDouble(fLOID), trans.Trans))
                    {
                        trans.CommitTransaction();
                    }
                    else
                    {
                        _error = fDAL.ErrorMessage;
                        ret = false;
                        trans.RollbackTransaction();
                    }
                }
                else
                {
                    ret = false;
                    trans.RollbackTransaction();
                }
            }
            catch (Exception ex)
            {
                _error = ex.Message;
                ret = false;
                trans.RollbackTransaction();
            }

            return ret;
        }

        #endregion

        #region Event on FormulfeedItem

        public bool InsertFormulaFeedItem(string UserID, DataTable tempTable, double fLoid)
        {
            zTran trans = new zTran();
            bool ret = true;        

            try
            {
                trans.CreateTransaction();
                
                if (tempTable != null)
                {
                    if(DeleteFormulFeedItem(tempTable,trans,fLoid))
                    {
                        for (int i = 0; i < tempTable.Rows.Count; i++)
                        {
                            FormularFeedItemDAL fiDAL = new FormularFeedItemDAL();
                            // เช็คว่ามี database หรือเปล่า
                            if (tempTable.Rows[i]["FILOID"].ToString() != "" && tempTable.Rows[i]["FILOID"].ToString() != "0")
                                fiDAL.GetDataByLOID(Convert.ToDouble(tempTable.Rows[i]["FILOID"].ToString()), trans.Trans);

                            if (!fiDAL.OnDB)
                            {
                                //insert formulafeeditem
                                fiDAL.FORMULAFEED = fLoid;
                                fiDAL.MATERIALMASTER = Convert.ToDouble(tempTable.Rows[i]["LOID"].ToString());
                                fiDAL.QTY = Convert.ToDouble(tempTable.Rows[i]["COST"].ToString());
                                fiDAL.UNIT = Convert.ToDouble(tempTable.Rows[i]["UULOID"].ToString());

                                ret = fiDAL.InsertCurrentData(UserID, trans.Trans);

                                if (ret == false)
                                {
                                    trans.RollbackTransaction();
                                    _error = fiDAL.ErrorMessage;
                                    return false;
                                }
                            }
                            else
                            {
                                //update formulafeeditem
                                FormularFeedItemData fiData = new FormularFeedItemData();
                                fiData.LOID = Convert.ToDouble(tempTable.Rows[i]["FILOID"].ToString());
                                fiData.FORMULAFEED = fLoid;
                                fiData.MATERIALMASTER = Convert.ToDouble(tempTable.Rows[i]["LOID"].ToString());
                                fiData.QTY = Convert.ToDouble(tempTable.Rows[i]["COST"].ToString());
                                fiData.UNIT = Convert.ToDouble(tempTable.Rows[i]["UULOID"].ToString());

                                UpdateFormulFeedItem(fiData, trans, UserID);
                            }
                        }
                    }
                    else 
                    {
                         trans.RollbackTransaction();
                         return false;
                    }

                }
                if(ret)
                    trans.CommitTransaction();
            
                else
                {
                    trans.RollbackTransaction();
                    return false;
                }   
            }
            catch (Exception ex)
            {
                _error = ex.Message;
                ret = false;
                trans.RollbackTransaction();
            }

            return ret;
        }

        private bool UpdateFormulFeedItem(FormularFeedItemData fiData,zTran trans,string UserID)
        {
             bool ret = true;
            FormularFeedItemDAL fiDAL = new FormularFeedItemDAL();
            fiDAL.GetDataByLOID(fiData.LOID, trans.Trans);
            fiDAL.FORMULAFEED = fiData.FORMULAFEED;
            fiDAL.MATERIALMASTER = fiData.MATERIALMASTER;
            fiDAL.QTY = fiData.QTY;
            fiDAL.UNIT = fiData.UNIT;
            try
            {

                if (fiDAL.OnDB)
                {
                    ret = fiDAL.UpdateCurrentData(UserID, null);
                    if (!ret) _error = fiDAL.ErrorMessage;

                    return ret;
                }
                else
                {
                    _error = Data.Common.Utilities.DataResources.MSGEU002;
                    return false;
                }
            }
            catch (Exception ex)
            {
                _error = ex.Message;
                return false;
            }
       }

        public bool DeleteFormulaFeedItemByLOID_Grid(double fLoid)
        {
            zTran trans = new zTran();
            trans.CreateTransaction();
            if (DeleteFormulaFeedItemByLOID(fLoid, trans))
            {
                trans.CommitTransaction();
                return true;
            }
            else
            {
                trans.RollbackTransaction();
                return false;
            }

        }

        public bool DeleteFormulaFeedItemByLOID(double fLoid,zTran trans)
        {
            FormularFeedItemDAL fiDAL = new FormularFeedItemDAL();
            bool ret = true;
            try
            {
                ret = fiDAL.DeleteDataByFormulaFeed(Convert.ToDouble(fLoid), trans.Trans);
            }
            catch (Exception ex)
            {
                ret = false;
                throw ex;  
            }

            return ret;
        }

        public bool DeleteFormulFeedItem(DataTable dt, zTran trans, double fLoid)
        {
            bool ret = true;
            string filoidList = "";
            FormularFeedItemDAL fiDAL = new FormularFeedItemDAL();
            try
            {
                for (int i = 0; i < dt.Rows.Count; i++)
                {
                    if (dt.Rows[i]["FILOID"].ToString() != "" && dt.Rows[i]["FILOID"] != null)
                    {
                        filoidList += (filoidList == "" ? "" : " , ") + dt.Rows[i]["FILOID"].ToString();
                    }
                }

                if(filoidList != "")
                    ret = fiDAL.DeleteNotInLOIDList(filoidList, fLoid.ToString(), trans.Trans);
            }

            catch (Exception ex)
            {
                _error = ex.Message;
                ret = false;
            }

            return ret;
        }


        #endregion

        #region Get Data Copy

        //get data case Copy Data
        public DataTable GetFormulaFeedItemDataCopy(double floid)
        {
            FormularFeedItemDAL fiDAL = new FormularFeedItemDAL();
            return fiDAL.GetDataByFormulaFeedCopy("FF.LOID = " + floid + "", "FI.LOID", null);
        }

        public FormulaFeedData GetFormulaFeedDataCopy(double floid)
        {
            FormulaFeedDAL fDAL = new FormulaFeedDAL();
            FormulaFeedData fData = new FormulaFeedData();
            fDAL.GetDataByLOID(floid, null);
            if (fDAL.OnDB)
            {
                fData.CAPACITY = fDAL.CAPACITY;
                fData.CAPACITYRATE = fDAL.CAPACITYRATE;
                fData.ACTIVE = (fDAL.ACTIVE == "1");
                fData.LOID = 9999999;
                fData.CARBOHYDRATE = fDAL.CARBOHYDRATE;
                fData.ENERGY = fDAL.ENERGY;
                fData.ENERGYRATE = fDAL.ENERGYRATE;
                fData.MATERIALMASTER = fDAL.MATERIALMASTER;
            }
            else
                _error = Data.Common.Utilities.DataResources.MSGEU002;

            return fData;
        }

        #endregion

        #region CheckUniq
        public bool CheckUniqMaterial(double mloid, double capactity, double energy, double floid)
        {
            FormulaFeedDAL fDAL = new FormulaFeedDAL();
            fDAL.GetDataByUniq("MATERIALMASTER = " + mloid + " AND CAPACITY = " + capactity + " AND ENERGY=" + energy + "", null);
            return !fDAL.OnDB || (floid.ToString() == fDAL.LOID.ToString());
        }

        #endregion

    }

}

