using System;
using System.Collections.Generic;
using System.Data.OracleClient;
using System.Text;
using System.Data;
using SHND.DAL.Views;
using SHND.DAL.Tables;
using SHND.Data.Tables;
using SHND.Data.Views;
using SHND.DAL.Utilities;
using System.Collections;
//using DB = SHND.DAL.Utilities.OracleDB;
using zTran = SHND.DAL.Utilities.OracleTransactionDB;

/// <summary>
/// FoodTypeFlow Class
/// Version 1.0
/// =========================================================================
/// Create by: Tan
/// Create Date: 6 Jan 2009
/// -------------------------------------------------------------------------
/// Modify By: -
/// Modify From: -
/// Modify Date: -
/// -------------------------------------------------------------------------
/// Remark: -
/// Description:
///    Flow จัดการการทำงานของหน้า WelfareRight 
/// Changes:
///    1.0 - สร้าง
/// -------------------------------------------------------------------------
/// =========================================================================
/// </summary>
/// 

namespace SHND.Flow.Order
{
    public class WelfareRightFlow
    {
        string _error = "";
        double _LOID = 0;
        public string ErrorMessage { get { return _error; } }
        public double LOID { get { return _LOID; } }

        public DataTable GetMasterList(string YearFrom, string YearTo, string OrderText)
        {
            VWelfareRightDAL vDAL = new VWelfareRightDAL();
            return vDAL.GetDataListByCondition(YearFrom, YearTo, OrderText, null);
        }
        public double GetHoliday(DateTime Startdate, DateTime EndDate)
        {
            VWelfareRightDAL vDAL = new VWelfareRightDAL();
            return vDAL.GetHoliday(Startdate, EndDate);
        }
        public DataTable GetWelfareRightItemList(double welfare)
        {
            VWelfareRightItemDAL VFormulaItem = new VWelfareRightItemDAL();
            DataTable dt = VFormulaItem.GetDataListByWelfare(welfare, "DIVISIONNAME", null);
            dt.Columns.Add("RANK", typeof(double));
            for (int i = 0; i < dt.Rows.Count; ++i)
            {
                dt.Rows[i]["RANK"] = i + 1;
            }
            return dt;
        }

        public VWelfareRightData GetDetails(double LOID)
        {
            VWelfareRightDAL ffDAL = new VWelfareRightDAL();
            VWelfareRightData ffData = new VWelfareRightData();
            ffDAL.GetDataByLOID(LOID, null);
            ffData.LOID = ffDAL.LOID;
            ffData.QTYDATE = ffDAL.QTYDATE;
            ffData.RIGHTMONTH = ffDAL.RIGHTMONTH;
            ffData.RIGHTYEAR = ffDAL.RIGHTYEAR;

            if (ffDAL.OnDB && LOID != 0)
                _error = Data.Common.Utilities.DataResources.MSGEV002;

            return ffData;

        }

        public bool InsertData(VWelfareRightData ffData, string UserID)
        {
            bool ret = true;
            zTran trans = new zTran();
            trans.CreateTransaction();

            WelfareRightDAL ffDAL = new WelfareRightDAL();
            //ffDAL.GetDataByLOID(ffData.LOID, trans.Trans);
            ffDAL.RIGHTMONTH = ffData.RIGHTMONTH;
            ffDAL.RIGHTYEAR = ffData.RIGHTYEAR;
            ffDAL.QTYDATE = ffData.QTYDATE;

            try
            {
                ret = ffDAL.InsertCurrentData(UserID, trans.Trans);
                if (!ret)
                    _error = ffDAL.ErrorMessage;

                if (ret)
                    ret = InsertWelfareRightItem(ffData.WelfareRightItem, UserID, ffDAL.LOID, trans.Trans);

                if (ret)
                    trans.CommitTransaction();
                else
                    trans.RollbackTransaction();

                _LOID = ffDAL.LOID;
            }
            catch (Exception ex)
            {
                ret = false;
                _error = ex.Message;
                trans.RollbackTransaction();
            }

            return ret;
        }

        public bool UpdateData(VWelfareRightData ffData, string UserID)
        {
            bool ret = true;
            zTran trans = new zTran();
            trans.CreateTransaction();

            WelfareRightDAL ffDAL = new WelfareRightDAL();
            ffDAL.GetDataByLOID(ffData.LOID, trans.Trans);
            ffDAL.RIGHTMONTH = ffData.RIGHTMONTH;
            ffDAL.RIGHTYEAR = ffData.RIGHTYEAR;
            ffDAL.QTYDATE = ffData.QTYDATE;

            try
            {
                if (ffDAL.OnDB)
                {
                    ret = ffDAL.UpdateCurrentData(UserID, trans.Trans);
                    if (!ret)
                        _error = ffDAL.ErrorMessage;

                    if (ret)
                        ret = InsertWelfareRightItem(ffData.WelfareRightItem, UserID, ffDAL.LOID, trans.Trans);
                   
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

                _LOID = ffDAL.LOID;
            }
            catch (Exception ex)
            {
                ret = false;
                _error = ex.Message;
                trans.RollbackTransaction();
            }

            return ret;
        }

        private bool InsertWelfareRightItem(ArrayList arrWelfareRightItem, string userID, double WelfareRight, OracleTransaction trans)
        {
            bool ret = true;
            string divisionList = "";
            for (int i = 0; i < arrWelfareRightItem.Count; ++i)
            {
                VWelfareRightItemData datItem = (VWelfareRightItemData)arrWelfareRightItem[i];
                divisionList += (divisionList == "" ? "" : ",") + datItem.DIVISION.ToString();
            }
            WelfareRightItemDAL WelfareRightItem = new WelfareRightItemDAL();
            if (divisionList != "") WelfareRightItem.doDelete("WELFARERIGHT = " + WelfareRight + " AND DIVISION NOT IN (" + divisionList + ") ", trans);
            for (int i = 0; i < arrWelfareRightItem.Count; ++i)
            {
                WelfareRightItem = new WelfareRightItemDAL();
                VWelfareRightItemData datItem = (VWelfareRightItemData)arrWelfareRightItem[i];
                WelfareRightItem.GetDataByUniqueKey(datItem.WELFARERIGHT, datItem.DIVISION, trans);
                WelfareRightItem.ISOVER = datItem.ISOVER;
                WelfareRightItem.WELFARERIGHT = WelfareRight;
                WelfareRightItem.DIVISION = datItem.DIVISION;
                WelfareRightItem.QTY = datItem.QTY;

                if (!WelfareRightItem.OnDB)
                    ret = WelfareRightItem.InsertCurrentData(userID, trans);
                else
                    ret = WelfareRightItem.UpdateCurrentData(userID, trans);

                if (!ret)
                {
                    _error = WelfareRightItem.ErrorMessage;
                    break;
                }
            }
            return ret;
        }
    }
}
