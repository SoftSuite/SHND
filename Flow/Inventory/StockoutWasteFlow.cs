using System;
using System.Collections.Generic;
using System.Text;
using System.Data;
using System.Collections;
//using DB = SHND.DAL.Utilities.OracleDB;
using zTran = SHND.DAL.Utilities.OracleTransactionDB;
using SHND.DAL.Views;
using SHND.DAL.Tables;
using SHND.Data.Views;
using SHND.Data.Tables;
using SHND.Data.Common.Utilities;


/// <summary>
/// Supplier Class
/// Version 1.0
/// =========================================================================
/// Create by: Somsakoon
/// Create Date: 12 Feb 2009
/// -------------------------------------------------------------------------
/// Modify By: -
/// Modify From: -
/// Modify Date: -
/// -------------------------------------------------------------------------
/// Remark: -
/// Description:
///    Flow จัดการการทำงานของหน้า StockWaste
/// Changes:
///    1.0 - สร้าง
/// -------------------------------------------------------------------------
/// =========================================================================
/// </summary>
/// 

namespace SHND.Flow.Inventory
{
    public class StockWasteFlow
    {
        string _error = "";
        double _LOID = 0;

        public string ErrorMessage { get { return _error; } }
        public double LOID { get { return _LOID; } }

        public DataTable GetStockWasteList(double LOID)
        {
            VStockoutItemDAL StockoutItem = new VStockoutItemDAL();
            DataTable dt = StockoutItem.GetDataListBySTOCKOUT(LOID, "MATERIALNAME", null);

            for (int i = 0; i < dt.Rows.Count; ++i)
            {
                dt.Rows[i]["LOID"] = i + 1;
            }
            return dt;
        }

        public bool InsertData(VStockOutData ftData, string userID)
        {
            zTran trans = new zTran();
            trans.CreateTransaction();

            bool ret = true;

            try
            {
                StockOutDAL ftDAL = new StockOutDAL();
                ftDAL.DIVISION = ftData.DIVISION;
                ftDAL.DOCTYPE = Convert.ToDouble(Constant.DocType.StockOutWaste.Loid);
                ftDAL.STATUS = ftData.STATUS;
                ftDAL.STOCKOUTDATE = ftData.STOCKOUTDATE;
                ftDAL.WAREHOUSE = ftData.WAREHOUSE;
                ftDAL.REASON = ftData.REASON;
                
                ret = ftDAL.InsertCurrentData(userID, trans.Trans);
                if (!ret) _error = ftDAL.ErrorMessage;

                if (ret)
                {
                    for (int i = 0; i < ftData.StockoutWasteList.Count; ++i)
                    {
                        StockoutitemDAL Stockoutitem = new StockoutitemDAL();
                        StockoutitemData StockoutitemD = (StockoutitemData)ftData.StockoutWasteList[i];
                        Stockoutitem.STOCKOUT = ftDAL.LOID;
                        Stockoutitem.REQQTY = StockoutitemD.REQQTY;
                        Stockoutitem.QTY = StockoutitemD.QTY;
                        Stockoutitem.ISMENU = StockoutitemD.ISMENU;
                        Stockoutitem.STATUS = StockoutitemD.STATUS;
                        Stockoutitem.REPAIRSTATUS = StockoutitemD.REPAIRSTATUS;
                        Stockoutitem.UNIT = StockoutitemD.UNIT;
                        Stockoutitem.REMARKS = StockoutitemD.REMARKS;
                        Stockoutitem.MATERIALMASTER = StockoutitemD.MATERIALMASTER;

                        ret = Stockoutitem.InsertCurrentData(userID, trans.Trans);
                        if (!ret)
                        {
                            _error = Stockoutitem.ErrorMessage;
                            break;
                        }
                    }
                    _LOID = ftDAL.LOID;
                }

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

        public bool UpdateData(VStockOutData ftData, string userID)
        {
            zTran trans = new zTran();
            trans.CreateTransaction();

            bool ret = true;

            try
            {
                StockOutDAL ftDAL = new StockOutDAL();
                ftDAL.GetDataByLOID(ftData.LOID, trans.Trans);
                ftDAL.DIVISION = ftData.DIVISION;
                ftDAL.DOCTYPE = 1;
                ftDAL.STATUS = ftData.STATUS;
                ftDAL.STOCKOUTDATE = ftData.STOCKOUTDATE;
                ftDAL.WAREHOUSE = ftData.WAREHOUSE;
                ftDAL.REASON = ftData.REASON;

                ret = ftDAL.UpdateCurrentData(userID, trans.Trans);
                if (!ret) _error = ftDAL.ErrorMessage;

                if (ret)
                {
                    StockoutitemDAL Stockoutitem = new StockoutitemDAL();
                    Stockoutitem.DeleteDataBySTOCKOUT(ftDAL.LOID, trans.Trans);
                    for (int i = 0; i < ftData.StockoutWasteList.Count; ++i)
                    {
                        //  StockoutitemDAL Stockoutitem = new StockoutitemDAL();
                        StockoutitemData StockoutitemD = (StockoutitemData)ftData.StockoutWasteList[i];
                        //   Stockoutitem.GetDataBySTOCKOUT (ftData.LOID, trans.Trans);
                        Stockoutitem.STOCKOUT = ftDAL.LOID;
                        Stockoutitem.REQQTY = StockoutitemD.REQQTY;
                        Stockoutitem.QTY = StockoutitemD.QTY;
                        Stockoutitem.ISMENU = StockoutitemD.ISMENU;
                        Stockoutitem.STATUS = StockoutitemD.STATUS;
                        Stockoutitem.REPAIRSTATUS = StockoutitemD.REPAIRSTATUS;
                        Stockoutitem.UNIT = StockoutitemD.UNIT;
                        Stockoutitem.REMARKS = StockoutitemD.REMARKS;
                        Stockoutitem.MATERIALMASTER = StockoutitemD.MATERIALMASTER;

                        ret = Stockoutitem.InsertCurrentData(userID, trans.Trans);
                        if (!ret)
                        {
                            _error = Stockoutitem.ErrorMessage;
                            break;
                        }
                    }
                    _LOID = ftDAL.LOID;
                }

                if (ret & ftDAL.STATUS == "AP")
                    ret = ftDAL.CutStock(ftDAL.LOID, trans.Trans);

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

        public VStockOutData GetDetails(double LOID)
        {
            VStockOutDAL fDAL = new VStockOutDAL();
            VStockOutData fData = new VStockOutData();
            VStockoutItemDAL StockoutItem = new VStockoutItemDAL();
            fDAL.GetDataByLOID(LOID, null);
            if (fDAL.OnDB)
            {
                fData.LOID = fDAL.LOID;
                fData.CODE = fDAL.CODE;
                fData.DIVISION = fDAL.DIVISION;
                fData.STOCKOUTDATE = fDAL.STOCKOUTDATE;
                fData.WAREHOUSE = fDAL.WAREHOUSE;
                fData.STATUS = fDAL.STATUS;
                fData.STATUSNAME = fDAL.STATUSNAME;

                fData.StockoutWasteTable = StockoutItem.GetDataListBySTOCKOUT(LOID, "LOID", null);


            }
            else
                _error = Data.Common.Utilities.DataResources.MSGEV002;

            return fData;

        }

    }

}

