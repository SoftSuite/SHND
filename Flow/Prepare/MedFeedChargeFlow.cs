using System;
using System.Collections.Generic;
using System.Text;
using zTran = SHND.DAL.Utilities.OracleTransactionDB;
using System.Data;
using SHND.DAL.Views;
using SHND.Data.Views;
using SHND.DAL.Tables;
using SHND.Data.Tables;
using System.Collections;

/// <summary>
/// MedFeedChargeFlow Class
/// Version 1.0
/// =========================================================================
/// Create by: Nang
/// Create Date: 31 Mar 2009
/// -------------------------------------------------------------------------
/// Modify By: -
/// Modify From: -
/// Modify Date: -
/// -------------------------------------------------------------------------
/// Remark: -
/// Description:
///    Flow จัดการการทำงานของหน้า MedFeedCharge
/// Changes:
///    1.0 - สร้าง
/// -------------------------------------------------------------------------
/// =========================================================================
/// </summary>
/// 

namespace SHND.Flow.Prepare
{
    public class MedFeedChargeFlow
    {

        string _error = "";
        public string ErrorMessage { get { return _error; } }


        public DataTable GetMedFeedChargeList(string cCodeFrom, string cCodeTo, DateTime cChargeDateFROM, DateTime cChargeDATETO, double cWard, string cStatusFrom, string cStatusTo, string orderBy)
        {
            VMedFeedChargeDAL vDAL = new VMedFeedChargeDAL();
            return vDAL.GetDataListByConditions(cCodeFrom, cCodeTo, cChargeDateFROM, cChargeDATETO, cWard, cStatusFrom, cStatusTo, orderBy, null);
        }

        public MedFeedChargeData GetMedFeedChargeData(double loid)
        {
            MedFeedChargeData mData = new MedFeedChargeData();
            MedFeedChargeDAL mDAL = new MedFeedChargeDAL();
            DataTable dt = mDAL.GetDataList("LOID = " + loid, "", null);
            if (dt.Rows.Count > 0)
            {
                for (int i = 0; i < dt.Rows.Count; ++i)
                {
                    mData.LOID = Convert.ToDouble(dt.Rows[i]["LOID"].ToString());
                    mData.WARD = Convert.ToDouble(dt.Rows[i]["WARD"].ToString());
                    mData.CODE = dt.Rows[i]["CODE"].ToString();
                    mData.CHARGEDATE = Convert.ToDateTime(dt.Rows[i]["CHARGEDATE"].ToString());
                    mData.STATUS = dt.Rows[i]["STATUS"].ToString();
                }
            }
            return mData;
        }

        public DataTable GetMedFeedChargeItemData(double mloid)
        {
            MedFeedChargeItemDAL miDAL = new MedFeedChargeItemDAL();
            return miDAL.GetFieldList(" VM.MASTERTYPE = 'MD' AND VM.UNIT = fn_getconfigvalue(23) AND MEDFEEDCHARGE = " + mloid, "", null);
        }


        #region Event On MedFeedCharge

        public double InsertMedFeedCharge(MedFeedChargeData mdata, DataTable dt,string UserID)
        {
            zTran trans = new zTran();
            bool ret = true;
            double mloid = 0;
            MedFeedChargeDAL mDAL = new MedFeedChargeDAL();
            mDAL.STATUS = mdata.STATUS;
            mDAL.WARD = mdata.WARD;
            mDAL.CHARGEDATE = mdata.CHARGEDATE;

            try
            {
                trans.CreateTransaction();
                ret = mDAL.InsertCurrentData(UserID, trans.Trans);
                if (!ret)
                    _error = mDAL.ErrorMessage;
                else
                {
                    mloid = mDAL.LOID;
                    ret = InsertMedFeedChargeItem(UserID, dt, mDAL.LOID, trans);
                    if (ret)
                        trans.CommitTransaction();
                    else
                        trans.RollbackTransaction();
                }
                   
            }
            catch (Exception ex)
            {
                _error = ex.Message;
            }

            return mloid;
        }

        public double UpdateMedFeedCharge(MedFeedChargeData mData,DataTable dt, string UserID)
        {
            double mloid = 0;
            zTran trans = new zTran();
            MedFeedChargeDAL mDAL = new MedFeedChargeDAL();
            mDAL.GetDataByLOID(mData.LOID, null);

            mDAL.STATUS = mData.STATUS.ToString();
            mDAL.WARD = Convert.ToDouble(mData.WARD.ToString());

            bool ret = true;

            try
            {
                trans.CreateTransaction();
                if (mDAL.OnDB)
                {
                    ret = mDAL.UpdateCurrentData(UserID, null);
                    if (!ret)
                        _error = mDAL.ErrorMessage;
                    else
                    {
                        mloid = mDAL.LOID;
                        ret = InsertMedFeedChargeItem(UserID, dt, mDAL.LOID, trans);
                        if (ret)
                            trans.CommitTransaction();
                        else
                            trans.RollbackTransaction();
                    }

                    return mloid;
                }
                else
                {
                    _error = Data.Common.Utilities.DataResources.MSGEU002;
                    return mloid;
                }
            }
            catch (Exception ex)
            {
                _error = ex.Message;
                return mloid;
            }
        }

        public bool ApproveMedFeedCharge(double mloid, string UserID)
        {
            zTran trans = new zTran();
            MedFeedChargeDAL mDAL = new MedFeedChargeDAL();
            mDAL.GetDataByLOID(mloid, null);

            mDAL.STATUS = "AP";

            bool ret = true;

            try
            {
                trans.CreateTransaction();
                if (mDAL.OnDB)
                {
                    ret = mDAL.UpdateCurrentData(UserID, null);
                    if (!ret)
                        _error = mDAL.ErrorMessage;  
                }
                else
                {
                    _error = Data.Common.Utilities.DataResources.MSGEU002;
                    ret = false;
                }

                if (ret)
                    trans.CommitTransaction();
                else
                    trans.RollbackTransaction();

            }
            catch (Exception ex)
            {
                _error = ex.Message;
                return ret;
            }
            return ret;
        }

        public bool UpdateMedFeedChargeMain(ArrayList arrLOID,string UserID,string status)
        {
            zTran trans = new zTran();
            bool ret = true;

            try
            {
                trans.CreateTransaction();

                for (int i = 0; i < arrLOID.Count; i++)
                {
                    MedFeedChargeDAL mcDAL = new MedFeedChargeDAL();
                    mcDAL.GetDataByLOID(Convert.ToDouble(arrLOID[i].ToString()), trans.Trans);

                    mcDAL.STATUS = status.ToString();
                    if (mcDAL.OnDB)
                    {
                        ret = mcDAL.UpdateCurrentData(UserID, trans.Trans);
                    }
                    else
                    {
                        _error = mcDAL.ErrorMessage;
                        trans.RollbackTransaction();
                        return false;
                    }
                    
                    if (ret == false)
                    {
                        trans.RollbackTransaction();
                        _error = mcDAL.ErrorMessage;
                        return false;
                    }
                }

                if (ret == true)
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
            catch (Exception ex)
            {
                trans.RollbackTransaction();
                _error = ex.Message;
                return false;
            }
        }

        #endregion

        #region Event On MedFeedChargeItem
        public bool InsertMedFeedChargeItem(string UserID, DataTable tempTable, double mloid,zTran trans)
        {
            bool ret = true;

            try
            {
                if (tempTable != null)
                {
                    if (DeleteMedFeedChargeItem(tempTable, trans, mloid))
                    {
                        for (int i = 0; i < tempTable.Rows.Count; i++)
                        {
                            MedFeedChargeItemDAL mciDAL = new MedFeedChargeItemDAL();
                            // เช็คว่ามี database หรือเปล่า
                            if (tempTable.Rows[i]["MCILOID"].ToString() != "" && tempTable.Rows[i]["MCILOID"].ToString() != "0")
                                mciDAL.GetDataByLOID(Convert.ToDouble(tempTable.Rows[i]["MCILOID"].ToString()), trans.Trans);

                            if (!mciDAL.OnDB)
                            {
                                //insert MedFeedChargeItem
                                mciDAL.MEDFEEDCHARGE = mloid;
                                mciDAL.ADMITPATIENT = Convert.ToDouble(tempTable.Rows[i]["LOID"].ToString());
                                mciDAL.REQDATE = Convert.ToDateTime(tempTable.Rows[i]["REQDATE"].ToString());
                                mciDAL.MATERIALMASTER = Convert.ToDouble(tempTable.Rows[i]["MMLOID"].ToString());
                                mciDAL.QTY = Convert.ToDouble(tempTable.Rows[i]["QTY"].ToString());
                                mciDAL.UNIT = Convert.ToDouble(tempTable.Rows[i]["UULOID"].ToString());
                                mciDAL.PRICE = Convert.ToDouble(tempTable.Rows[i]["PRICE"].ToString());
                                mciDAL.REMARKS = tempTable.Rows[i]["REMARKS"].ToString();

                                ret = mciDAL.InsertCurrentData(UserID, trans.Trans);

                                if (ret == false)
                                {
                                    //trans.RollbackTransaction();
                                    _error = mciDAL.ErrorMessage;
                                    return false;
                                }
                            }
                            else
                            {
                                //update MedFeedChargeItem
                                MedFeedChargeItemData mciData = new MedFeedChargeItemData();
                                mciData.LOID = Convert.ToDouble(tempTable.Rows[i]["MCILOID"].ToString());
                                mciData.ADMITPATIENT = Convert.ToDouble(tempTable.Rows[i]["LOID"].ToString());
                                mciData.REQDATE = Convert.ToDateTime(tempTable.Rows[i]["REQDATE"].ToString());
                                mciData.MATERIALMASTER = Convert.ToDouble(tempTable.Rows[i]["MMLOID"].ToString());
                                mciData.QTY = Convert.ToDouble(tempTable.Rows[i]["QTY"].ToString());
                                mciData.UNIT = Convert.ToDouble(tempTable.Rows[i]["UULOID"].ToString());
                                mciData.PRICE = Convert.ToDouble(tempTable.Rows[i]["PRICE"].ToString());
                                mciData.REMARKS = tempTable.Rows[i]["REMARKS"].ToString();

                                ret = UpdateMedFeedChargeItem(mciData, trans, UserID);
                            }
                        }
                    }
                    else
                    {
                        ret =  false;
                    }
                }
            }
            catch (Exception ex)
            {
                _error = ex.Message;
                ret = false;
            }

            return ret;
        }


        public bool DeleteMedFeedChargeItem(DataTable dt, zTran trans, double mLoid)
        {
            bool ret = true;
            string mciloidList = "";
            MedFeedChargeItemDAL mciDAL = new MedFeedChargeItemDAL();
            try
            {
                for (int i = 0; i < dt.Rows.Count; i++)
                {
                    if (dt.Rows[i]["MCILOID"].ToString() != "" && dt.Rows[i]["MCILOID"] != null)
                    {
                        mciloidList += (mciloidList == "" ? "" : " , ") + dt.Rows[i]["MCILOID"].ToString();
                    }
                }
                
                ret = mciDAL.DeleteNotInLOIDList(mciloidList, mLoid.ToString(), trans.Trans);
            }

            catch (Exception ex)
            {
                _error = ex.Message;
                ret = false;
            }

            return ret;
        }

        private bool UpdateMedFeedChargeItem(MedFeedChargeItemData mciData, zTran trans, string UserID)
        {
            bool ret = true;
            MedFeedChargeItemDAL mciDAL = new MedFeedChargeItemDAL();
            mciDAL.GetDataByLOID(mciData.LOID, trans.Trans);
            mciDAL.ADMITPATIENT = mciData.ADMITPATIENT;
            mciDAL.REQDATE = mciData.REQDATE;
            mciDAL.MATERIALMASTER = mciData.MATERIALMASTER;
            mciDAL.QTY = mciData.QTY;
            mciDAL.UNIT = mciData.UNIT;
            mciDAL.PRICE = mciData.PRICE;
            mciDAL.REMARKS = mciData.REMARKS;

            try
            {

                if (mciDAL.OnDB)
                {
                    ret = mciDAL.UpdateCurrentData(UserID, null);
                    if (!ret) _error = mciDAL.ErrorMessage;

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

        #endregion

 

      

        

        
        
    }
}
