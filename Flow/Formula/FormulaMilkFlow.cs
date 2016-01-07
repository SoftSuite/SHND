using System;
using System.Collections.Generic;
using System.Text;
using System.Data ;
using SHND.DAL.Views;
using SHND.DAL.Tables;
using SHND.Data.Tables;
using SHND.Data.Views;
using System.Collections;
using zTran = SHND.DAL.Utilities.OracleTransactionDB;

/// <summary>
/// FormulMilkFlow Class
/// Version 1.0
/// =========================================================================
/// Create by: Nang
/// Create Date: 16 Jan 2009
/// -------------------------------------------------------------------------
/// Modify By: -
/// Modify From: -
/// Modify Date: -
/// -------------------------------------------------------------------------
/// Remark: -
/// Description:
///    Flow จัดการการทำงานของหน้า FormularMilk 
/// Changes:
///    1.0 - สร้าง
/// -------------------------------------------------------------------------
/// =========================================================================
/// </summary>
/// 

namespace SHND.Flow.Formula
{
    public class FormulaMilkFlow
    {
        string _error = "";
        public string ErrorMessage { get { return _error; } }

        #region GetData 

        #region GetDataMain
        public DataTable GetFormulaMilkSearch(string energyFrom, string energyTo, string MilkType, string orderBy)
        {
            VFormulaMilkDAL vmDAL = new VFormulaMilkDAL();
            string wh = "";
            if (energyFrom.ToString() != "" && energyTo.ToString() != "")
                wh += (wh == "" ? "" : " AND ") + " ENERGY BETWEEN " + energyFrom + " AND " + energyTo + "";
            else if (energyFrom.ToString() != "")
                wh += (wh == "" ? "" : " AND ") + " ENERGY >= " + energyFrom + "";
            else if (energyTo.ToString() != "")
                wh += (wh == "" ? "" : " AND ") + " ENERGY <= " + energyTo + "";

            if (MilkType != "ทั้งหมด")
                wh += (wh == "" ? "" : " AND ") + " FORMULANAME LIKE '%" + MilkType + "%'";

            return vmDAL.GetDataList(wh, orderBy, null);
        }

        #endregion

        #region GetDataNew
        public DataTable GetMaterialMaster(double mcLoid)
        {
            MaterialMasterDAL mmDAL = new MaterialMasterDAL();
            return mmDAL.GetMaterialMilk("MILKCATEGORY = " + mcLoid + " AND UNIT.LOID= fn_getconfigvalue(16)", "", null);
        }

        public string GetSpecificMilk(string mloid)
        {
            MilkCategoryDAL mDAL = new MilkCategoryDAL();
            return mDAL.GetSpecificMilk("LOID = " + mloid + "", "", null);
        }

        public string GetMaterialMasterEnergy(string mloid)
        {
            MaterialMasterDAL mDAL = new MaterialMasterDAL();
            return mDAL.GetEnergyByMilk("MILKCATEGORY = "+ mloid +"", null);
        }
        public double GetNutrientRate(double mloid)
        {
            MaterialMasterDAL mDal = new MaterialMasterDAL();
            return mDal.GetNutrientRate(mloid, null);
        }

        public double GetFIenergy(double mloid)
        {
            MaterialMasterDAL mDAL = new MaterialMasterDAL();
            return Convert.ToDouble(mDAL.GetEnergy100G(mloid.ToString(), null));
        }


        #endregion

        #region GetDataPopup

        public FormulaMilkData GetFormulaMilkData(double fmLoid)
        {
            FormulaMilkDAL fmDAL = new FormulaMilkDAL();
            FormulaMilkData fmData = new FormulaMilkData();
            fmDAL.GetDataByLOID(fmLoid, null);
            if (fmDAL.OnDB)
            {
                fmData.MILKCATEGORY = fmDAL.MILKCATEGORY;
                fmData.MILKCAPACITY = fmDAL.MILKCAPACITY;
                fmData.ACTIVE = fmDAL.ACTIVE;
                fmData.LOID = fmDAL.LOID;
                fmData.ENERGY = fmDAL.ENERGY;
                fmData.NAME = fmDAL.NAME;
            }
            else
                _error = Data.Common.Utilities.DataResources.MSGEU002;

            return fmData;
        }

        public DataTable GetFormulaMilkItemData(double fmLoid)
        {
            VFormulaMilkListDAL VfmDAL = new VFormulaMilkListDAL();
            return VfmDAL.GetDataList("FMLOID = " + fmLoid, "FMILOID", null);
        }

        public DataTable GetWater()
        {
            MaterialMasterDAL mDAL = new MaterialMasterDAL();
            return mDAL.GetWater("MATERIALMASTER.NAME = 'น้ำ'", "", null);
        }

        public DataTable GetNutrient(double Floid)
        {
            VFormulaMilkNutrientDAL vDAL = new VFormulaMilkNutrientDAL();
            return vDAL.GetDataByField("LOID = " + Floid + "", "", null);
        }


        #endregion

        #endregion

        #region CheckUniqe
        public bool CheckUniqe(string strname,double cLOID)
        {
            FormulaMilkDAL fmDAL = new FormulaMilkDAL();
            fmDAL.GetDataByUniq("NAME = '" + strname + "'", null);
            return !fmDAL.OnDB || (cLOID.ToString() == fmDAL.LOID.ToString());
        }

        #endregion

        #region Event on FormulaMilk

        public double InsertFormulaMilk(FormulaMilkData fmData, string UserID)
        {
            double floid = 0;
            FormulaMilkDAL fmDAL = new FormulaMilkDAL();
            fmDAL.NAME = fmData.NAME;
            fmDAL.MILKCATEGORY = Convert.ToDouble(fmData.MILKCATEGORY);
            fmDAL.CAPACITY = Convert.ToDouble(fmData.CAPACITY);
            fmDAL.ENERGY = Convert.ToDouble(fmData.ENERGY);
            fmDAL.ACTIVE = fmData.ACTIVE;
            fmDAL.MILKCAPACITY = Convert.ToDouble(fmData.MILKCAPACITY);

            bool ret = true;

            try
            {
                ret = fmDAL.InsertCurrentData(UserID, null);
                if (!ret)
                    _error = fmDAL.ErrorMessage;
                else
                    floid = fmDAL.LOID;
            }
            catch (Exception ex)
            {
                _error = ex.Message;
            }

            return floid;
        }

        public double UpdateFormulaMilk(FormulaMilkData fmData, string UserID)
        {
            FormulaMilkDAL fmDAL = new FormulaMilkDAL();
            fmDAL.GetDataByLOID(fmData.LOID, null);

            fmDAL.NAME = fmData.NAME;
            fmDAL.MILKCATEGORY = Convert.ToDouble(fmData.MILKCATEGORY);
            fmDAL.CAPACITY = Convert.ToDouble(fmData.CAPACITY);
            fmDAL.ENERGY = Convert.ToDouble(fmData.ENERGY);
            fmDAL.ACTIVE = fmData.ACTIVE;
            fmDAL.MILKCAPACITY = Convert.ToDouble(fmData.MILKCAPACITY);


            bool ret = true;

            try
            {
                if (fmDAL.OnDB)
                {
                    ret = fmDAL.UpdateCurrentData(UserID, null);
                    if (!ret) _error = fmDAL.ErrorMessage;

                    return fmDAL.LOID;
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

        public bool DeleteFormulaMilkByLoid(double fLOID)
        {
            zTran trans = new zTran();

            FormulaMilkDAL fmDAL = new FormulaMilkDAL();
            trans.CreateTransaction();
            bool ret = true;
            try
            {
                if (DeleteFormulaMilkItemByLOID(Convert.ToDouble(fLOID), trans))
                {
                    if (fmDAL.DeleteDataByLOID(Convert.ToDouble(fLOID), trans.Trans))
                    {
                        trans.CommitTransaction();
                    }
                    else
                    {
                        _error = fmDAL.ErrorMessage;
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

        #region Event on FormulaMilkitem
        
        public bool InsertFormulaMilkItem(string UserID, DataTable tempTable, double fLoid)
        {
            zTran trans = new zTran();
            bool ret = true;

            try
            {
                trans.CreateTransaction();

                if (tempTable != null)
                {
                    if (DeleteFormulaMilkItem(tempTable, trans, fLoid))
                    {
                        for (int i = 0; i < tempTable.Rows.Count; i++)
                        {
                            FormulaMilkItemDAL fiDAL = new FormulaMilkItemDAL();
                            // เช็คว่ามี database หรือเปล่า
                            if (tempTable.Rows[i]["FMILOID"].ToString() != "" && tempTable.Rows[i]["FMILOID"].ToString() != "0")
                                fiDAL.GetDataByLOID(Convert.ToDouble(tempTable.Rows[i]["FMILOID"].ToString()), trans.Trans);

                            if (!fiDAL.OnDB)
                            {
                                //insert formulafeeditem
                                fiDAL.FORMULAMILK = fLoid;
                                fiDAL.MATERIALMASTER = Convert.ToDouble(tempTable.Rows[i]["MMLOID"].ToString());
                                fiDAL.QTY = Convert.ToDouble(tempTable.Rows[i]["QTY"].ToString());
                                fiDAL.ENERGY = Convert.ToDouble(tempTable.Rows[i]["ENERGY"].ToString());
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
                                FormulaMilkItemData fiData = new FormulaMilkItemData();
                                fiData.LOID = Convert.ToDouble(tempTable.Rows[i]["FMILOID"].ToString());
                                fiData.FORMULAMILK = fLoid;
                                fiData.MATERIALMASTER = Convert.ToDouble(tempTable.Rows[i]["MMLOID"].ToString());
                                fiData.QTY = Convert.ToDouble(tempTable.Rows[i]["QTY"].ToString());
                                fiData.ENERGY = Convert.ToDouble(tempTable.Rows[i]["ENERGY"].ToString());
                                fiData.UNIT = Convert.ToDouble(tempTable.Rows[i]["UULOID"].ToString());

                                UpdateFormulaMilkItem(fiData, trans, UserID);
                            }
                        }
                    }
                    else
                    {
                        trans.RollbackTransaction();
                        return false;
                    }

                }
                if (ret)
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

        private bool UpdateFormulaMilkItem(FormulaMilkItemData fiData, zTran trans, string UserID)
        {
            bool ret = true;
            FormulaMilkItemDAL fiDAL = new FormulaMilkItemDAL();
            fiDAL.GetDataByLOID(fiData.LOID, trans.Trans);
            fiDAL.FORMULAMILK = fiData.FORMULAMILK;
            fiDAL.MATERIALMASTER = fiData.MATERIALMASTER;
            fiDAL.QTY = fiData.QTY;
            fiDAL.ENERGY = fiData.ENERGY;
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

        public bool DeleteFormulaMilkItemByLOID_Grid(double fLoid)
        {
            zTran trans = new zTran();
            trans.CreateTransaction();
            if (DeleteFormulaMilkItemByLOID(fLoid, trans))
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

        public bool DeleteFormulaMilkItemByLOID(double fLoid, zTran trans)
        {
            FormulaMilkItemDAL fiDAL = new FormulaMilkItemDAL();
            bool ret = true;
            try
            {
                ret = fiDAL.DeleteByFormulaMilk(Convert.ToDouble(fLoid), trans.Trans);
            }
            catch (Exception ex)
            {
                ret = false;
                _error = ex.Message;
            }

            return ret;
        }

        public bool DeleteFormulaMilkItem(DataTable dt, zTran trans, double fLoid)
        {
            bool ret = true;
            string filoidList = "";
            FormulaMilkItemDAL fmDAL = new FormulaMilkItemDAL();
            try
            {
                for (int i = 0; i < dt.Rows.Count; i++)
                {
                    if (dt.Rows[i]["FMILOID"].ToString() != "" && dt.Rows[i]["FMILOID"] != null)
                    {
                        filoidList += (filoidList == "" ? "" : " , ") + dt.Rows[i]["FMILOID"].ToString();
                    }
                }

                if (filoidList != "")
                    ret = fmDAL.DeleteNotInLOIDList(filoidList, fLoid.ToString(), trans.Trans);
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
        public DataTable GetFormulaMilkItemDataCopy(double floid)
        {
            VFormulaMilkListDAL VfmDAL = new VFormulaMilkListDAL();
            return VfmDAL.GetDataCopy("FMLOID = " + floid + "", "FMILOID", null);
        }

        public FormulaMilkData GetFormulaMilkDataCopy(double floid)
        {
            FormulaMilkDAL fmDAL = new FormulaMilkDAL();
            FormulaMilkData fmData = new FormulaMilkData();
            fmDAL.GetDataByLOID(floid, null);
            if (fmDAL.OnDB)
            {
                fmData.NAME = fmDAL.NAME;
                fmData.MILKCATEGORY = Convert.ToDouble(fmDAL.MILKCATEGORY);
                fmData.CAPACITY = Convert.ToDouble(fmDAL.CAPACITY);
                fmData.ENERGY = Convert.ToDouble(fmDAL.ENERGY);
                fmData.ACTIVE = fmDAL.ACTIVE;
                fmData.MILKCAPACITY = Convert.ToDouble(fmDAL.MILKCAPACITY);
                fmData.LOID = 9999999;
            }
            else
                _error = Data.Common.Utilities.DataResources.MSGEU002;

            return fmData;
        }

        #endregion

    }
}
