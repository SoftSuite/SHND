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
/// StockCheckHeadFlow Class
/// Version 1.0
/// =========================================================================
/// Create by: Nang
/// Create Date: 20 Feb 2009
/// -------------------------------------------------------------------------
/// Modify By: -
/// Modify From: -
/// Modify Date: -
/// -------------------------------------------------------------------------
/// Remark: -
/// Description:
///    Flow จัดการการทำงานของหน้า StockCheckHead
/// Changes:
///    1.0 - สร้าง
/// -------------------------------------------------------------------------
/// =========================================================================
/// </summary>
/// 

namespace SHND.Flow.Inventory
{
    public class StockCheckHeadFlow
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

        public DataTable GetStockCheckHeadList(double scloid)
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

        public double UpdateApprove(double sloid, string UserID,string str)
        {
            StockCheckDAL sDAL = new StockCheckDAL();
            sDAL.GetDataByLOID(sloid, null);

            sDAL.STATUS = str;

            bool ret = true;

            try
            {
                ret = sDAL.UpdateCurrentData(UserID, null);
                if (!ret)
                    _error = sDAL.ErrorMessage;
                else
                    sloid = sDAL.LOID;

                if (ret && sDAL.STATUS == "AP")
                    ret = sDAL.CutStock(sDAL.LOID, null);
            }
            catch (Exception ex)
            {
                _error = ex.Message;
            }

            return sloid;
        }

        public double UpdateCancel(double sloid, string UserID, string str)
        {
            StockCheckDAL sDAL = new StockCheckDAL();
            sDAL.GetDataByLOID(sloid, null);

            sDAL.STATUS = str;

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

        public bool ApproveStockCheckByLoid(ArrayList arrLOID, string UserID)
        {
            zTran trans = new zTran();

            trans.CreateTransaction();
            bool ret = true;
            try
            {
                if (!CheckStatus(arrLOID))
                {
                    return false;
                }
                else
                {
                    for (int i = 0; i < arrLOID.Count; i++)
                    {
                        StockCheckDAL sDAL = new StockCheckDAL();
                        sDAL.GetDataByLOID(Convert.ToDouble(arrLOID[i]), null);
                        sDAL.STATUS = "AP";

                        ret = sDAL.UpdateCurrentData(UserID, null);
                        if (!ret)
                        {
                            _error = sDAL.ErrorMessage;
                            trans.RollbackTransaction();
                            return false;
                        }
                    }
                    trans.CommitTransaction();
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

        public bool VoidStockCheckByLoid(ArrayList arrLOID, string UserID)
        {
            zTran trans = new zTran();

            trans.CreateTransaction();
            bool ret = true;
            try
            {
                if (!CheckStatus(arrLOID))
                {
                    return false;
                }
                else
                {
                    for (int i = 0; i < arrLOID.Count; i++)
                    {
                        StockCheckDAL sDAL = new StockCheckDAL();
                        sDAL.GetDataByLOID(Convert.ToDouble(arrLOID[i]), null);
                        sDAL.STATUS = "VO";

                        ret = sDAL.UpdateCurrentData(UserID, null);
                        if (!ret)
                        {
                            _error = sDAL.ErrorMessage;
                            trans.RollbackTransaction();
                            return false;
                        }
                    }
                    trans.CommitTransaction();
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

        #region Event StockCheckItem

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

        #endregion

        private bool CheckStatus(ArrayList arr)
        {
            StockCheckDAL sDAL = new StockCheckDAL();
            for (int i = 0; i < arr.Count; i++)
            {
                string str = "";
                str = sDAL.CheckStatus(Convert.ToDouble(arr[i]), null);
                if (str == "AP" && str != "VO")
                {
                    _error = "ไม่สามารถลบรายการได้ เนื่องจากมีการอนุมัติหรือยกเลิกรายการแล้ว";
                    return false;
                }
            }
            return true;
        }

    }
}
