using System;
using System.Collections;
using System.Collections.Generic;
using System.Data;
using System.Data.OracleClient;
using System.Text;
using SHND.DAL.Functions;
using SHND.DAL.Inventory;
using SHND.DAL.Tables;
using SHND.DAL.Views;
using SHND.Data.Inventory;
using SHND.Data.Tables;
using zTran = SHND.DAL.Utilities.OracleTransactionDB;

/// <summary>
/// StockOutRequestFlow Class
/// Version 1.0
/// =========================================================================
/// Create by: Teang
/// Create Date: 20 Feb 2009
/// -------------------------------------------------------------------------
/// Modify By: -
/// Modify From: -
/// Modify Date: -
/// -------------------------------------------------------------------------
/// Remark: -
/// Description:
///    Flow จัดการการทำงานของหน้า StockOutRequestSearch และ StockOutRequest
/// Changes:
///    1.0 - สร้าง
/// -------------------------------------------------------------------------
/// =========================================================================
/// </summary>
/// 
namespace SHND.Flow.Inventory
{
    public class StockOutRequestFlow
    {
        string _error = "";
        double _LOID = 0;
        public string ErrorMessage { get { return _error; } }
        public double LOID { get { return _LOID; } }

        public double CalPatentQtyStockOut(double division, DateTime menuDate, bool isBreakfast, bool isLunch, bool isDinner)
        {
            FunctionDAL fDAL = new FunctionDAL();
            return fDAL.CalPatentQtyStockOut(division, menuDate, isBreakfast, isLunch, isDinner, null);
        }

        public double CalLastStockOut(double division, double materialMaster, DateTime useDate, double unit)
        {
            FunctionDAL fDAL = new FunctionDAL();
            return fDAL.CalLastStockOut(division, materialMaster, useDate, unit, null);
        }

        public VMenuStockOutData GetMenuData(double division, DateTime menuDate, bool isBreakfast, bool isLunch, bool isDinner, double materialMaster, double unit)
        {
            VMenuStockOutDAL mDAL = new VMenuStockOutDAL();
            VMenuStockOutData mData = new VMenuStockOutData();
            mDAL.GetDataByConditions(division, menuDate, isBreakfast, isLunch, isDinner, materialMaster, unit, null);
            if (mDAL.OnDB)
            {
                mData.CLASSLOID = mDAL.CLASSLOID;
                mData.CLASSNAME = mDAL.CLASSNAME;
                mData.CODE = mDAL.CODE;
                mData.COST = mDAL.COST;
                mData.DIVISION = mDAL.DIVISION;
                mData.DIVISIONNAME = mDAL.DIVISIONNAME;
                mData.FORMULAQTY = mDAL.FORMULAQTY;
                mData.MASTERTYPE = mDAL.MASTERTYPE;
                mData.MATERIALCODE = mDAL.MATERIALCODE;
                mData.MATERIALMASTER = mDAL.MATERIALMASTER;
                mData.MATERIALNAME = mDAL.MATERIALNAME;
                mData.MENUDATE = mDAL.MENUDATE;
                mData.PREQTY = mDAL.PREQTY;
                mData.PRICE = mDAL.PRICE;
                mData.UNIT = mDAL.UNIT;
                mData.UNITNAME = mDAL.UNITNAME;
            }
            return mData;
        }

        public DataTable GetMasterList(string codeFrom, string codeTo, DateTime useDataFrom, DateTime useDateTo, string statusFrom, string statusTo, double cDIVISION, string orderBy)
        {
            VStockOutDAL vDAL = new VStockOutDAL();
            return vDAL.GetDataListByConditions(0, 0,cDIVISION, codeFrom, codeTo, useDataFrom, useDateTo, new DateTime(), new DateTime(), statusFrom, statusTo, "N", "Y", orderBy, null);
        }

        public DataTable GetStockOutItem(double stockOutID)
        {
            VStockOutRequestDAL sDAL = new VStockOutRequestDAL();
            DataTable dt = sDAL.GetDataListByStockOut(stockOutID, "MATERIALNAME, UNITNAME", null);
            dt.Columns.Add("RANK", typeof(double));
            for (int i = 0; i < dt.Rows.Count; ++i)
            {
                dt.Rows[i]["RANK"] = i + 1;
            }
            return dt;
        }

        private bool InsertStockOutItem(ArrayList arrData, double stockOutID, string status, string userID, OracleTransaction trans)
        {
            bool ret = true;
            string loidList = "";
            StockoutitemDAL itemDAL = new StockoutitemDAL();
            for (int i = 0; i < arrData.Count; ++i)
            {
                StockoutitemData dat = (StockoutitemData)arrData[i];
                loidList += (loidList == "" ? "" : ",") + dat.LOID.ToString();
            }
            itemDAL.DeleteDataByStockout(stockOutID, loidList, trans);

            for (int i = 0; i < arrData.Count; ++i)
            {
                itemDAL = new StockoutitemDAL();
                StockoutitemData dat = (StockoutitemData)arrData[i];
                itemDAL.GetDataByLOID(dat.LOID, trans);
                itemDAL.ISMENU = dat.ISMENU;
                //itemDAL.ITEMNAME = dat.ITEMNAME;
                itemDAL.MATERIALMASTER = dat.MATERIALMASTER;
                itemDAL.PRICE = dat.PRICE;
                itemDAL.REQQTY = dat.REQQTY;
                itemDAL.STATUS = status;
                itemDAL.STOCKOUT = stockOutID;
                itemDAL.UNIT = dat.UNIT;
                if (itemDAL.OnDB)
                    ret = itemDAL.UpdateCurrentData(userID, trans);
                else
                {
                    itemDAL.REPAIRSTATUS = "Z";
                    ret = itemDAL.InsertCurrentData(userID, trans);
                }

                if (!ret)
                {
                    _error = itemDAL.ErrorMessage;
                    break;
                }
            }
            return ret;
        }

        public bool InsertData(StockOutRequestData dat, string userID)
        {
            bool ret = true;
            zTran trans = new zTran();
            trans.CreateTransaction();
            try
            {
                StockOutDAL sDAL = new StockOutDAL();
                sDAL.DIVISION = dat.DIVISION;
                sDAL.DOCTYPE = dat.DOCTYPE;
                sDAL.ISBREAKFAST = (dat.ISBREAKFAST ? "Y" : "N");
                sDAL.ISDINNER = (dat.ISDINNER ? "Y" : "N");
                sDAL.ISLUNCH = (dat.ISLUNCH ? "Y" : "N");
                sDAL.ORDERQTY = dat.ORDERQTY;
                sDAL.STATUS = dat.STATUS;
                sDAL.STOCKOUTDATE = dat.STOCKOUTDATE;
                sDAL.WAREHOUSE = dat.WAREHOUSE;
                sDAL.USEDATE = dat.USEDATE;
                ret = sDAL.InsertCurrentData(userID, trans.Trans);
                if (!ret)
                    _error = sDAL.ErrorMessage;
                else
                    ret = InsertStockOutItem(dat.StockOutItemList, sDAL.LOID, sDAL.STATUS, userID, trans.Trans);

                _LOID = sDAL.LOID;

                if (ret)
                    trans.CommitTransaction();
                else
                    trans.RollbackTransaction();
            }
            catch (Exception ex)
            {
                _error = ex.Message;
                ret = false;
                trans.RollbackTransaction();
            }
            return ret;
        }

        public bool UpdateData(StockOutRequestData dat, string userID)
        {
            bool ret = true;
            zTran trans = new zTran();
            trans.CreateTransaction();
            try
            {
                StockOutDAL sDAL = new StockOutDAL();
                sDAL.GetDataByLOID(dat.LOID, trans.Trans);
                if (sDAL.OnDB)
                {
                    sDAL.DIVISION = dat.DIVISION;
                    sDAL.DOCTYPE = dat.DOCTYPE;
                    sDAL.ISBREAKFAST = (dat.ISBREAKFAST ? "Y" : "N");
                    sDAL.ISDINNER = (dat.ISDINNER ? "Y" : "N");
                    sDAL.ISLUNCH = (dat.ISLUNCH ? "Y" : "N");
                    sDAL.ORDERQTY = dat.ORDERQTY;
                    sDAL.STATUS = dat.STATUS;
                    sDAL.STOCKOUTDATE = dat.STOCKOUTDATE;
                    sDAL.WAREHOUSE = dat.WAREHOUSE;
                    sDAL.USEDATE = dat.USEDATE;
                    ret = sDAL.UpdateCurrentData(userID, trans.Trans);
                    if (!ret)
                        _error = sDAL.ErrorMessage;
                    else
                        ret = InsertStockOutItem(dat.StockOutItemList, sDAL.LOID, sDAL.STATUS, userID, trans.Trans);

                    _LOID = sDAL.LOID;
                }
                else
                {
                    ret = false;
                    _error = Data.Common.Utilities.DataResources.MSGEU002;
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
                trans.RollbackTransaction();
            }
            return ret;
        }

        public StockOutRequestData GetDetail(double stockOutID)
        {
            StockOutRequestData dat = new StockOutRequestData();
            VStockOutDAL sDAL = new VStockOutDAL();
            sDAL.GetDataByLOID(stockOutID, null);
            dat.CODE = sDAL.CODE;
            dat.DIVISION = sDAL.DIVISION;
            dat.DIVISIONNAME = sDAL.DIVISIONNAME;
            dat.DOCNAME = sDAL.DOCNAME;
            dat.DOCTYPE = sDAL.DOCTYPE;
            dat.ISBREAKFAST = (sDAL.ISBREAKFAST == "Y");
            dat.ISDINNER = (sDAL.ISDINNER == "Y");
            dat.ISLUNCH = (sDAL.ISLUNCH == "Y");
            dat.ISREQUISITION = (sDAL.ISREQUISITION == "Y");
            dat.ISSTOCKIN = (sDAL.ISSTOCKIN == "Y");
            dat.ISSTOCKOUT = (sDAL.ISSTOCKOUT == "Y");
            dat.LOID = sDAL.LOID;
            dat.ORDERQTY = sDAL.ORDERQTY;
            dat.PRIORITY = sDAL.PRIORITY;
            dat.REMARKS = sDAL.REMARKS;
            dat.STATUS = (sDAL.STATUS == "" ? "WA" : sDAL.STATUS);
            dat.STATUSNAME = (sDAL.STATUSNAME == "" ? "ทำรายการ" : sDAL.STATUSNAME);
            dat.STATUSRANK = sDAL.STATUSRANK;
            dat.STOCKOUTDATE = (sDAL.STOCKOUTDATE.Year == 1 ? DateTime.Today : sDAL.STOCKOUTDATE);
            dat.SUPPLIER = sDAL.SUPPLIER;
            dat.TYPE = sDAL.TYPE;
            dat.USEDATE = sDAL.USEDATE;
            dat.WAREHOUSE = sDAL.WAREHOUSE;
            dat.WAREHOUSECODE = sDAL.WAREHOUSECODE;
            dat.WAREHOUSENAME = sDAL.WAREHOUSENAME;
            
            return dat;
        }

        public bool DoDelete(ArrayList arrData)
        {
            bool ret = true;
            zTran trans = new zTran();
            trans.CreateTransaction();
            try
            {
                for (int i=0; i<arrData.Count; ++i)
                {
                    StockoutitemDAL item = new StockoutitemDAL();
                    item.DeleteDataBySTOCKOUT(Convert.ToDouble(arrData[i]), trans.Trans);

                    StockOutDAL sDal = new StockOutDAL();
                    ret = sDal.DeleteDataByLOID(Convert.ToDouble(arrData[i]), trans.Trans);

                    if (!ret)
                    {
                        _error = sDal.ErrorMessage;
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
                trans.RollbackTransaction();
            }
            return ret;
        }

        public bool DoSend(ArrayList arrData, string userID)
        {
            bool ret = true;
            zTran trans = new zTran();
            trans.CreateTransaction();
            try
            {
                for (int i = 0; i < arrData.Count; ++i)
                {
                    StockOutDAL sDal = new StockOutDAL();sDal.GetDataByLOID(Convert.ToDouble(arrData[i]), trans.Trans);
                    if (sDal.OnDB && (sDal.STATUS == "WA" || sDal.STATUS == "NP"))
                    {
                        sDal.STATUS = "SE";
                        ret = sDal.UpdateCurrentData(userID, trans.Trans);

                        if (!ret)
                        {
                            _error = sDal.ErrorMessage;
                            break;
                        }
                        else
                        {
                            StockoutitemDAL item = new StockoutitemDAL();
                            ret = item.UpdateStatusByStockOut(Convert.ToDouble(arrData[i]), sDal.STATUS, userID, trans.Trans);
                            if (!ret)
                            {
                                _error = item.ErrorMessage;
                                break;
                            }
                        }
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
                trans.RollbackTransaction();
            }
            return ret;
        }

    }
}
