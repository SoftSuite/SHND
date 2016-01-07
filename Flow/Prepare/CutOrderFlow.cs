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
/// CutOrderFlow Class
/// Version 1.0
/// =========================================================================
/// Create by: Nang
/// Create Date: 12 May 2009
/// -------------------------------------------------------------------------
/// Modify By: -
/// Modify From: -
/// Modify Date: -
/// -------------------------------------------------------------------------
/// Remark: -
/// Description:
///    Flow จัดการการทำงานของหน้า CutOrder
/// Changes:
///    1.0 - สร้าง
/// -------------------------------------------------------------------------
/// =========================================================================
/// </summary>
/// 


namespace SHND.Flow.Prepare
{
    public class CutOrderFlow
    {
        string _error = "";
        public string ErrorMessage { get { return _error; } }

        public DataTable GetCutOrderList(string str, string orderstr)
        {
            VCutOrderSearchDAL vDAL = new VCutOrderSearchDAL();
            return vDAL.GetDataList(str, orderstr, null);
        }

        public DataTable GetPatientCount(double loid)
        {
            VStockoutItemDAL vDAL = new VStockoutItemDAL();
            return vDAL.GetPatientCount(loid, "CODE,MATERIALNAME", null);
        }

     
        public StockOutData GetDataStockOut(double loid)
        {
            StockOutData sData = new StockOutData();
            StockOutDAL sDAL = new StockOutDAL();
            sDAL.GetDataByLOID(loid, null);
            if (sDAL.OnDB)
            {
                sData.LOID = sDAL.LOID;
                sData.CODE = sDAL.CODE;
                sData.STOCKOUTDATE = sDAL.STOCKOUTDATE;
                sData.DIVISION = sDAL.DIVISION;
                sData.WAREHOUSE = sDAL.WAREHOUSE;
                sData.DOCTYPE = sDAL.DOCTYPE;
                sData.ORDERQTY = sDAL.ORDERQTY;
                sData.USEDATE = sDAL.USEDATE;
                sData.ISBREAKFAST = sDAL.ISBREAKFAST;
                sData.ISLUNCH = sDAL.ISLUNCH;
                sData.ISDINNER = sDAL.ISDINNER;
                sData.STATUS = sDAL.STATUS;
            }
            else
                _error = Data.Common.Utilities.DataResources.MSGEU002;

            return sData;
        }

        public DataTable GetDataStockOutItem(double loid)
        {
            VStockoutItemDAL vDAL = new VStockoutItemDAL();
            return vDAL.GetCutOrderBySTOCKOUT(loid, "CODE,MATERIALNAME", null);
        }

        public bool UpdateStockoutItem(DataTable dt, string UserID)
        {
            zTran trans = new zTran();
            bool ret = true;

            try
            {
                trans.CreateTransaction();

                if (dt != null)
                {
                    for (int i = 0; i < dt.Rows.Count; i++)
                    {
                        StockoutitemDAL sDAL = new StockoutitemDAL();
                        sDAL.GetDataByLOID(Convert.ToDouble(dt.Rows[i]["LOID"].ToString()), trans.Trans);
                        sDAL.USEQTY = Convert.ToDouble(dt.Rows[i]["USEQTY"].ToString());


                        if (sDAL.OnDB)
                            ret = sDAL.UpdateCurrentData(UserID, trans.Trans);
                        else
                        {
                            trans.RollbackTransaction();
                            _error = "ไม่พบรายการ";
                            return false;
                        }

                        if (ret == false)
                        {
                            trans.RollbackTransaction();
                            _error = sDAL.ErrorMessage;
                            return false;
                        }
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

        public bool ApproveStockout(double Loid, string UserID)
        {
            zTran trans = new zTran();
            bool ret = true;

            try
            {
                trans.CreateTransaction();

                if (Loid.ToString() != "")
                {
                    StockOutDAL sDAL = new StockOutDAL();
                    sDAL.GetDataByLOID(Loid, trans.Trans);
                    sDAL.STATUS = "FN";


                    if (sDAL.OnDB)
                        ret = sDAL.UpdateCurrentData(UserID, trans.Trans);
                    else
                    {
                        trans.RollbackTransaction();
                        _error = "ไม่พบรายการ";
                        return false;
                    }

                    if (ret && sDAL.STATUS == "FN")
                        ret = sDAL.CutStockPrepare(Loid, trans.Trans);

                    if (ret == false)
                    {
                        trans.RollbackTransaction();
                        _error = sDAL.ErrorMessage;
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
    }
}
