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
/// StockCheckAuditFlow Class
/// Version 1.0
/// =========================================================================
/// Create by: Nang
/// Create Date: 16 Feb 2009
/// -------------------------------------------------------------------------
/// Modify By: -
/// Modify From: -
/// Modify Date: -
/// -------------------------------------------------------------------------
/// Remark: -
/// Description:
///    Flow จัดการการทำงานของหน้า StockCheckAudit
/// Changes:
///    1.0 - สร้าง
/// -------------------------------------------------------------------------
/// =========================================================================
/// </summary>
/// 


namespace SHND.Flow.Inventory
{
    public class StockCheckAuditFlow
    {
        string _error = "";
        public string ErrorMessage { get { return _error; } }

        #region GetData Main
        public DataTable GetStockCheckSearch(string wh, string orderstr)
        {
            VStockCheckCountDAL vDAL = new VStockCheckCountDAL();
            return vDAL.GetDataList(wh, orderstr, null);
        }

        #endregion

        #region Getdata Pop


        public StockCheckData GetStockCheckData(double sLoid)
        {
            StockCheckDAL sDAL = new StockCheckDAL();
            StockCheckData sData = new StockCheckData();
            sDAL.GetDataByLOID(sLoid, null);
            if (sDAL.OnDB)
            {
                sData.BATCHNO = sDAL.BATCHNO;
                sData.CHECKDATE = sDAL.CHECKDATE;
                sData.WAREHOUSE = sDAL.WAREHOUSE;
                sData.LOID = sDAL.LOID;
                sData.MATERIALCLASS = sDAL.MATERIALCLASS;
                sData.REMARKS = sDAL.REMARKS;
                sData.STATUS = sDAL.STATUS;
            }
            else
                _error = Data.Common.Utilities.DataResources.MSGEU002;

            return sData;
        }

        public DataTable GetStockCheckAuditList(double scloid)
        {
            VStockCheckAuditListDAL vDAL = new VStockCheckAuditListDAL();
            return vDAL.GetDataList("SCLOID =" + scloid + "", "SCILOID", null);
        }

        #endregion

        #region Event StockCheck

        public double UpdateStockCheck(StockCheckData sData, string UserID)
        {
            double sloid = 0;
            StockCheckDAL sDAL = new StockCheckDAL();
            sDAL.GetDataByLOID(sData.LOID, null);
            sDAL.WAREHOUSE = Convert.ToDouble(sData.WAREHOUSE);
            sDAL.BATCHNO = sData.BATCHNO.ToString();
            sDAL.CHECKDATE = Convert.ToDateTime(sData.CHECKDATE);
            sDAL.MATERIALCLASS = Convert.ToDouble(sData.MATERIALCLASS);
            sDAL.STATUS = sData.STATUS.ToString();
            sDAL.REMARKS = sData.REMARKS.ToString();

            bool ret = true;

            try
            {
                ret = sDAL.UpdateCurrentData(UserID, null);
                if (!ret)
                    _error = sDAL.ErrorMessage;
                else
                    sloid = sDAL.LOID;
            }
            catch (Exception ex)
            {
                _error = ex.Message;
            }

            return sloid;
        }

        public double UpdateApprove(double sloid, string UserID)
        {
            StockCheckDAL sDAL = new StockCheckDAL();
            sDAL.GetDataByLOID(sloid, null);

            sDAL.STATUS = "CO";

            bool ret = true;

            try
            {
                ret = sDAL.UpdateCurrentData(UserID, null);
                if (!ret)
                    _error = sDAL.ErrorMessage;
                else
                    sloid = sDAL.LOID;
            }
            catch (Exception ex)
            {
                _error = ex.Message;
            }

            return sloid;
        }

        public bool DeleteStockCheckByLoid(ArrayList arrLOID)
        {
            zTran trans = new zTran();

            StockCheckDAL sDAL = new StockCheckDAL();
            trans.CreateTransaction();
            bool ret = true;
            try
            {
                for (int i = 0; i < arrLOID.Count; i++)
                {
                    if (DeleteStockCheckItem_Trans(Convert.ToDouble(arrLOID[i]), trans))
                    {
                        sDAL.DeleteDataByLOID(Convert.ToDouble(arrLOID[i]), trans.Trans);
                    }
                    else
                    {
                        trans.RollbackTransaction();
                        ret = false;
                    }
                }
                trans.CommitTransaction();
            }
            catch (Exception ex)
            {
                _error = ex.Message;
                ret = false;
                trans.RollbackTransaction();
            }
            return ret;
        }

        public bool ApproveAllStockCheckByLoid(ArrayList arrLOID,string UserID)
        {
            zTran trans = new zTran();

            StockCheckDAL sDAL = new StockCheckDAL();
            trans.CreateTransaction();
            bool ret = true;
            try
            {
                for (int i = 0; i < arrLOID.Count; i++)
                {
                    if (sDAL.GetDataByLOID(Convert.ToDouble(arrLOID[i]),trans.Trans))
                    {
                        sDAL.STATUS = "CO";
                        ret = sDAL.UpdateCurrentData(UserID, trans.Trans);
                        if (!ret)
                        {
                            trans.RollbackTransaction();
                            return false;
                        }
                    }
                }
                trans.CommitTransaction();
            }
            catch (Exception ex)
            {
                _error = ex.Message;
                ret = false;
                trans.RollbackTransaction();
            }
            return ret;
        }

        //-------------------------------------------------------
        public bool CancelAllStockCheckByLoid(ArrayList arrLOID,string UserID)
        {
            zTran trans = new zTran();

            StockCheckDAL sDAL = new StockCheckDAL();
            trans.CreateTransaction();
            bool ret = true;
            try
            {
                for (int i = 0; i < arrLOID.Count; i++)
                {
                    if (sDAL.GetDataByLOID(Convert.ToDouble(arrLOID[i]),trans.Trans ))
                    {
                        sDAL.STATUS = "VO";
                        ret = sDAL.UpdateCurrentData(UserID, trans.Trans);
                        if (!ret)
                        {
                            trans.RollbackTransaction();
                            return false;
                        }
                    }
                }
                trans.CommitTransaction();
            }
            catch (Exception ex)
            {
                _error = ex.Message;
                ret = false;
                trans.RollbackTransaction();
            }
            return ret;
        }
        //--------------------------------------------------------

        #endregion

        #region Event StockCheckItem

        public bool DeleteStockCheckItem(double sLoid)
        {
            zTran trans = new zTran();

            StockCheckItemDAL siDAL = new StockCheckItemDAL();
            bool ret = true;
            try
            {
                ret = siDAL.DeleteByStockChek(Convert.ToDouble(sLoid), trans.Trans);
                if (ret)
                    trans.CommitTransaction();
                else
                    trans.RollbackTransaction();
            }
            catch (Exception ex)
            {
                ret = false;
                _error = ex.Message;
            }
            return ret;
        }

        public bool DeleteStockCheckItem_Trans(double sLoid, zTran trans)
        {
            StockCheckItemDAL siDAL = new StockCheckItemDAL();
            bool ret = true;
            try
            {
                ret = siDAL.DeleteByStockChek(Convert.ToDouble(sLoid), trans.Trans);
            }
            catch (Exception ex)
            {
                ret = false;
                _error = ex.Message;
            }
            return ret;
        }


        public bool UpdateStockCheckItem(DataTable dt, string UserID)
        {
            zTran trans = new zTran();
            bool ret = true;
            try
            {

                trans.CreateTransaction();
                for (int i = 0; i < dt.Rows.Count; i++)
                {
                    StockCheckItemDAL siDAL = new StockCheckItemDAL();
                    siDAL.GetDataByLOID(Convert.ToDouble(dt.Rows[i]["SCILOID"].ToString()), trans.Trans);
                    siDAL.ISIMPROVE = dt.Rows[i]["ISIMPROVE"].ToString();
                    siDAL.STOCKQTY = Convert.ToDouble(dt.Rows[i]["STOCKQTY"].ToString());
                    siDAL.IMPROVEQTY = Convert.ToDouble(dt.Rows[i]["IMPROVEQTY"].ToString());

                    ret = siDAL.UpdateCurrentData(UserID, trans.Trans);

                    if (ret == false)
                    {
                        trans.RollbackTransaction();
                        _error = siDAL.ErrorMessage;
                        ret = false;
                    }
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
            }
            return ret;
        }

        public bool CheckDataInStockCheckItem(double sLoid)
        {
            StockCheckItemDAL siDAL = new StockCheckItemDAL();
            return siDAL.GetDataByStockCheck(sLoid, null);
        }

        #endregion
    }
}
