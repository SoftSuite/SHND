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
/// StockOutFlow Class
/// Version 1.0
/// =========================================================================
/// Create by: Teang
/// Create Date: 2 Mar 2009
/// -------------------------------------------------------------------------
/// Modify By: -
/// Modify From: -
/// Modify Date: -
/// -------------------------------------------------------------------------
/// Remark: -
/// Description:
///    Flow จัดการการทำงานของหน้า StockOutSearch และ StockOut
/// Changes:
///    1.0 - สร้าง
/// -------------------------------------------------------------------------
/// =========================================================================
/// </summary>
/// 
namespace SHND.Flow.Inventory
{
    public class StockOutFlow
    {
        string _error = "";
        double _LOID = 0;
        public string ErrorMessage { get { return _error; } }
        public double LOID { get { return _LOID; } }

        public DataTable GetMasterList(string codeFrom, string codeTo, DateTime useDataFrom, DateTime useDateTo, string statusFrom, string statusTo, string orderBy)
        {
            VStockOutDAL vDAL = new VStockOutDAL();
            return vDAL.GetDataListByConditions(0, 0, 0, codeFrom, codeTo, useDataFrom, useDateTo, new DateTime(), new DateTime(), statusFrom, statusTo, "N", "Y", orderBy, null);
        }

        private bool UpdateStockOutItem(ArrayList arrData, string statusStockout, string userID, OracleTransaction trans)
        {
            bool ret = true;
            StockoutitemDAL itemDAL;
            for (int i = 0; i < arrData.Count; ++i)
            {
                itemDAL = new StockoutitemDAL();
                StockoutitemData dat = (StockoutitemData)arrData[i];
                itemDAL.GetDataByLOID(dat.LOID, trans);
                itemDAL.QTY = dat.QTY;
                itemDAL.REQQTY = dat.REQQTY;
                itemDAL.STATUS = dat.STATUS;
               // if (statusStockout == "AP")
               //     itemDAL.STATUS = dat.STATUS;
               // else
               //     itemDAL.STATUS = statusStockout;

                if (itemDAL.OnDB)
                    ret = itemDAL.UpdateCurrentData(userID, trans);

                if (!ret)
                {
                    _error = itemDAL.ErrorMessage;
                    break;
                }
            }
            return ret;
        }

        public bool UpdateData(StockOutDetailData dat, string userID)
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
                        ret = UpdateStockOutItem(dat.StockOutItemList, sDAL.STATUS, userID, trans.Trans);

                    _LOID = sDAL.LOID;
                }
                else
                {
                    ret = false;
                    _error = Data.Common.Utilities.DataResources.MSGEU002;
                }
                 
                if (ret && sDAL.STATUS=="AP")
                    ret = sDAL.CutStock(sDAL.LOID, trans.Trans);

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

        public StockOutDetailData GetDetail(double stockOutID)
        {
            StockOutDetailData dat = new StockOutDetailData();
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
            VStockOutRequestDAL vDAL = new VStockOutRequestDAL();
            dat.StockOutItemTable = vDAL.GetDataListByStockOut(stockOutID, "MATERIALNAME, UNITNAME", null);

            return dat;
        }

    }
}
