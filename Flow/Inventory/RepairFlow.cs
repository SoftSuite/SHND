using System;
using System.Collections.Generic;
using System.Text;
using System.Data;
using SHND.DAL.Tables;
using SHND.DAL.Views;
using SHND.Data.Tables;
using SHND.Data.Views;
using SHND.Data.Inventory;
using SHND.DAL.Utilities;
using System.Collections;
using System.Data.OracleClient;
using zTran = SHND.DAL.Utilities.OracleTransactionDB;
/// <summary>
/// RepairRequestFlow Class
/// Version 1.0
/// =========================================================================
/// Create by: Pro
/// Create Date: 10 FEB 2009
/// -------------------------------------------------------------------------
/// Modify By: -
/// Modify From: -
/// Modify Date: -
/// -------------------------------------------------------------------------
/// Remark: -
/// Description:
///    Flow จัดการการทำงานของหน้า RepairRequest
/// Changes:
///    1.0 - สร้าง
/// -------------------------------------------------------------------------
/// =========================================================================
/// </summary>
/// 
namespace SHND.Flow.Inventory
{
    public class RepairFlow
    {
        double _LOID = 0;
        string _error = "";
        public string ErrorMessage { get { return _error; } }

        public double LOID
        {
            get { return _LOID; }
        }

        public DataTable GetMasterRepairList(string CodeFrom, string CodeTo, DateTime StartDate, DateTime EndDate, string statusFrom, string statusTo, string orderBy)
        {
            VStockOutDAL vDAL = new VStockOutDAL();
            return vDAL.GetDataListByConditions(0, 0, 0, CodeFrom, CodeTo, new DateTime(), new DateTime(),  StartDate, EndDate, statusFrom, statusTo, orderBy, null);
        }
        public DataTable GetRepairrequestItemList(double ID)
        {
            VRepairrequestDAL VRepairItem = new VRepairrequestDAL();
            DataTable dt = VRepairItem.GetDataListByRepair(ID, "MATERIALNAME", null);
            dt.Columns.Add("RANK", typeof(double));
            for (int i = 0; i < dt.Rows.Count; ++i)
            {
                dt.Rows[i]["RANK"] = i + 1;
            }
            return dt;
        }
        public DataTable GetRepairList(double loid, string orderBy)
        {
            RepairstatusDAL vDAL = new RepairstatusDAL();
            return vDAL.GetGetRepairListByCondition(loid, orderBy, null);
        }
        public DataTable GetMaterialList(string CodeFrom, string CodeTo, DateTime StartDate, DateTime EndDate, double Division, string statusFrom, string statusTo, string orderBy)
        {
            VStockOutDAL vDAL = new VStockOutDAL();
            return vDAL.GetDataListByConditions(0, 0, Division, CodeFrom, CodeTo, new DateTime(), new DateTime(),  StartDate, EndDate, statusFrom, statusTo, orderBy, null);
        }
        public DataTable GetStockoutData(double ffloid)
        {
            StockOutDAL fDAL = new StockOutDAL();
            string whStr = "";

            whStr += "LOID = " + ffloid;
            return fDAL.GetDataList(whStr, "", null);
        }
        public bool DeleteByLOID(ArrayList arrLOID)
        {
            zTran trans = new zTran();

            StockOutDAL fDAL = new StockOutDAL();
            trans.CreateTransaction();
            bool ret = true;
            try
            {
                for (int i = 0; i < arrLOID.Count; i++)
                {
                    fDAL.DeleteDataByLOID(Convert.ToDouble(arrLOID[i]), trans.Trans);
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
        public bool SentByLOID(ArrayList arrLOID)
        {
            zTran trans = new zTran();

            StockOutDAL fDAL = new StockOutDAL();
            trans.CreateTransaction();
            bool ret = true;
            try
            {
                for (int i = 0; i < arrLOID.Count; i++)
                {
                    fDAL.SentDataByLOID(Convert.ToDouble(arrLOID[i]), trans.Trans);
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
        public RepairRequestData GetDetails(double LOID)
        {
            StockOutDAL fDAL = new StockOutDAL();
            RepairRequestData fData = new RepairRequestData();
            fDAL.GetDataByLOID(LOID, null);
            if (fDAL.OnDB)
            {
                fData.CODE = fDAL.CODE;
                fData.DIVISION = fDAL.DIVISION;
                fData.LOID = fDAL.LOID;
                fData.STATUS = fDAL.STATUS;
                fData.PRIORITY = fDAL.PRIORITY;
                fData.STOCKOUTDATE = fDAL.STOCKOUTDATE;
                fData.WAREHOUSE = fDAL.WAREHOUSE;
                fData.CREATEBY = fDAL.CREATEBY;

                StockoutitemDAL itemDAL = new StockoutitemDAL();
                itemDAL.GetDataBySTOCKOUT(fData.LOID, null);
                fData.SILOTNO= itemDAL.LOTNO ;
                fData.SILOID = itemDAL.LOID;
                fData.SIQTY =itemDAL.QTY ;
                fData.SIUNIT = itemDAL.UNIT;
                fData.FLOOR =itemDAL.FLOOR ;
                fData.REMARKS =itemDAL.REMARKS ;
                fData.REPAIRBY = itemDAL.REPAIRBY;
                fData.REPAIRREMARKS = itemDAL.REPAIRREMARKS;
                fData.REPAIRSTATUS = itemDAL.REPAIRSTATUS;
                fData.SIBRAND = itemDAL.BRAND;
                UnitDAL uDAL = new UnitDAL();
                uDAL.GetDataByLOID(itemDAL.UNIT, null);
                fData.UNITNAME = uDAL.THNAME;
                fDAL.LOID = itemDAL.STOCKOUT;
                fData.MATERIAL= itemDAL.MATERIALMASTER ;
                MaterialMasterDAL mmDAL = new MaterialMasterDAL();
                mmDAL.GetDataByLOID(itemDAL.MATERIALMASTER, null);
                fData.SICODE = mmDAL.SAPCODE;
                fData.MATERIALNAME = mmDAL.NAME;
            }
            else
                _error = Data.Common.Utilities.DataResources.MSGEV002;

            return fData;

        }
        public bool InsertData(RepairRequestData ftData, string UserID)
        {
            StockOutDAL ftDAL = new StockOutDAL();
            ftDAL.CODE = ftData.CODE;
            if (ftData.STOCKOUTDATE.Year != 1)
            {
                ftDAL.STOCKOUTDATE = ftData.STOCKOUTDATE;
            }
            ftDAL.WAREHOUSE = ftData.WAREHOUSE;
            ftDAL.DIVISION = ftData.DIVISION;
            ftDAL.PRIORITY = ftData.PRIORITY;
            ftDAL.STATUS = ftData.STATUS;
            ftDAL.DOCTYPE = 16;

            bool ret = true;

            if (ftDAL.OnDB)
                ret = ftDAL.UpdateCurrentData(UserID, null);
            else
                ret = ftDAL.InsertCurrentData(UserID, null);

            _LOID = ftDAL.LOID;

            if (!ret)
            {
                throw new ApplicationException(ftDAL.ErrorMessage);
            }

            StockoutitemDAL siDAL = new StockoutitemDAL();
            siDAL.LOID = ftData.SILOID;
            siDAL.LOTNO = ftData.SILOTNO;
            siDAL.QTY = ftData.SIQTY;
            siDAL.UNIT = ftData.SIUNIT;
            siDAL.FLOOR = ftData.FLOOR;
            siDAL.REMARKS = ftData.REMARKS;
            siDAL.REPAIRBY = ftData.REPAIRBY;
            siDAL.ISMENU = "N";
            siDAL.STATUS = "WA";
            siDAL.REPAIRSTATUS = ftData.REPAIRSTATUS;
            siDAL.REPAIRREMARKS = ftData.REPAIRREMARKS;
            siDAL.UNIT = ftData.SIUNIT;
            siDAL.STOCKOUT = ftDAL.LOID;
            siDAL.MATERIALMASTER = ftData.MATERIAL;

            siDAL.OnDB = false;
            ret = siDAL.InsertCurrentData(UserID, null);
            if (!ret) throw new ApplicationException(siDAL.ErrorMessage);

            RepairstatusDAL itemDAL = new RepairstatusDAL();
            itemDAL.DeleteDataByRepair(ftData.LOID, null);
            for (Int16 i = 0; i < ftData.ITEM.Count; ++i)
            {
                RepairItemData item = (RepairItemData)ftData.ITEM[i];
                itemDAL.LOID = ftDAL.LOID;
                itemDAL.REPAIRDATE = item.REPAIRDATE;
                itemDAL.DESCRIPTION = item.DESCRIPTION;
                itemDAL.STOCKOUTITEM = item.STOCKOUTITEM;

                itemDAL.OnDB = false;
                ret = itemDAL.InsertCurrentData(UserID, null);
                if (!ret) throw new ApplicationException(itemDAL.ErrorMessage);
            }  

            return ret;
        }

       
        public bool UpdateStockitem(RepairRequestData mData, string userID, OracleTransaction trans)
        {
            StockoutitemDAL mDAL;
            bool ret = true;

            mDAL = new StockoutitemDAL();
            mDAL.OnDB = true;
            //mDAL.GetDataByLOID(mData.SILOID, trans);
            mDAL.LOTNO = mData.SILOTNO;
            mDAL.QTY = mData.SIQTY;
            mDAL.UNIT = mData.SIUNIT;
            mDAL.FLOOR = mData.FLOOR;
            mDAL.REMARKS = mData.REMARKS;
            mDAL.REPAIRBY = mData.REPAIRBY;
            mDAL.REPAIRREMARKS = mData.REPAIRREMARKS;
            mDAL.REPAIRSTATUS = mData.REPAIRSTATUS;
            mDAL.ISMENU = "N";
            mDAL.STATUS = mData.STATUS;
            mDAL.UNIT = mData.SIUNIT;
            mDAL.BRAND = mData.SIBRAND;
            mDAL.STOCKOUT = mData.LOID;
            StockoutitemDAL mmDAL = new StockoutitemDAL();
            mmDAL.GetDataBySTOCKOUT(mDAL.STOCKOUT, null);
            mDAL.LOID = mmDAL.LOID;

            mDAL.MATERIALMASTER = mData.MATERIAL;
            if (mDAL.OnDB)
                ret = mDAL.UpdateCurrentData(userID, trans);

            if (!ret)
            {
                _error = mDAL.ErrorMessage;
                //break;
            }

            return ret;
        }
        public bool UpdateData(RepairRequestData mData, string userID)
        {
            bool ret = true;
            zTran trans = new zTran();
            trans.CreateTransaction();
            try
            {
                StockOutDAL StockOrder = new StockOutDAL();
                StockOrder.GetDataByLOID(mData.LOID, trans.Trans);
                StockOrder.STATUS = mData.STATUS;
                if (StockOrder.OnDB)
                    ret = StockOrder.UpdateCurrentData(userID, trans.Trans);

                if (!ret) _error = StockOrder.ErrorMessage;


                ret = UpdateStockitem(mData, userID, trans.Trans);

                RepairstatusDAL itemDAL = new RepairstatusDAL();
                StockoutitemDAL StockitemDAL = new StockoutitemDAL();
                StockitemDAL.GetDataBySTOCKOUT(mData.LOID, null);
                mData.SILOID = StockitemDAL.LOID;
                mData.REPAIRREMARKS = StockitemDAL.REPAIRREMARKS;
                mData.REPAIRSTATUS = StockitemDAL.REPAIRSTATUS;
                mData.SIBRAND = StockitemDAL.BRAND;
                mData.SILOTNO = StockitemDAL.LOTNO;
                itemDAL.DeleteDataByRepair(mData.SILOID, trans.Trans);
                for (Int16 i = 0; i < mData.ITEM.Count; ++i)
                {
                    RepairItemData item = (RepairItemData)mData.ITEM[i];
                    itemDAL.STOCKOUTITEM = mData.SILOID;
                    itemDAL.REPAIRDATE = item.REPAIRDATE;
                    itemDAL.DESCRIPTION = item.DESCRIPTION;

                    itemDAL.OnDB = false;
                    ret = itemDAL.InsertCurrentData(userID, trans.Trans);
                    if (!ret) throw new ApplicationException(itemDAL.ErrorMessage);
                }

                if (ret && (StockOrder.STATUS == "AP" || StockOrder.STATUS=="FN"))
                    ret = StockOrder.CutStockRepair(StockOrder.LOID, trans.Trans);

                if (ret)
                    trans.CommitTransaction();
                else
                    trans.RollbackTransaction();

                _LOID = StockOrder.LOID;
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
