using System;
using System.Collections.Generic;
using System.Text;
using System.Data;
using SHND.DAL.Tables;
using System.Data.OracleClient;
using SHND.DAL.Views;
using SHND.Data.Tables;
using SHND.Data.Views;
using SHND.Data.Inventory;
using SHND.Data.Common.Utilities;
using SHND.DAL.Utilities;
using System.Collections;
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
    public class RepairRequestFlow
    {
        double _LOID = 0;
        string _error = "";
        public string ErrorMessage { get { return _error; } }

        public double LOID
        {
            get { return _LOID; }
        }

        public DataTable GetMasterRepairList(string CodeFrom, string CodeTo, DateTime StartDate, DateTime EndDate, string statusFrom, string statusTo, string division, string orderBy)
        {
            VStockOutDAL vDAL = new VStockOutDAL();
            return vDAL.GetDataListByConditions(0, Convert.ToDouble(Constant.DocType.StockOutRepair.Loid), Convert.ToDouble(division), CodeFrom, CodeTo, new DateTime(), new DateTime(), StartDate, EndDate, statusFrom, statusTo, orderBy, null);
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
            return vDAL.GetDataListByConditions(0, Convert.ToDouble(Constant.DocType.StockOutRepair.Loid), Division, CodeFrom, CodeTo, new DateTime(), new DateTime(), StartDate, EndDate, statusFrom, statusTo, orderBy, null);
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
                   ret = fDAL.DeleteDataByLOID(Convert.ToDouble(arrLOID[i]), trans.Trans);
                   if (!ret)
                   {
                       throw new ApplicationException(fDAL.ErrorMessage);
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
                fData.SIQTY =itemDAL.QTY ;
                fData.SIUNIT = itemDAL.UNIT;
                fData.FLOOR =itemDAL.FLOOR ;
                fData.REMARKS =itemDAL.REMARKS ;
                fData.REPAIRBY = itemDAL.REPAIRBY;
                UnitDAL uDAL = new UnitDAL();
                uDAL.GetDataByLOID(itemDAL.UNIT, null);
                fData.UNITNAME = uDAL.THNAME;
                fDAL.LOID = itemDAL.STOCKOUT;
                fData.MATERIAL= itemDAL.MATERIALMASTER ;
                MaterialMasterDAL mmDAL = new MaterialMasterDAL();
                mmDAL.GetDataByLOID(itemDAL.MATERIALMASTER, null);
                fData.SICODE = mmDAL.SAPCODE;
                fData.MATERIALNAME = mmDAL.NAME;
                fData.SIBRAND = itemDAL.BRAND;
            }
            else
                _error = Data.Common.Utilities.DataResources.MSGEV002;

            return fData;

        }
        public bool InsertData(RepairRequestData ftData, string UserID)
        {
            StockOutDAL ftDAL = new StockOutDAL();
            ftDAL.CODE = ftData.CODE;
            ftDAL.STOCKOUTDATE = ftData.STOCKOUTDATE;
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

            StockoutitemDAL itemDAL = new StockoutitemDAL();
            itemDAL.LOID = ftData.SILOID;
            itemDAL.LOTNO = ftData.SILOTNO;
            itemDAL.QTY = ftData.SIQTY;
            itemDAL.UNIT = ftData.SIUNIT;
            itemDAL.FLOOR = ftData.FLOOR;
            itemDAL.REMARKS = ftData.REMARKS;
            itemDAL.REPAIRBY = ftData.REPAIRBY;
            itemDAL.ISMENU = "N";
            itemDAL.STATUS = "WA";
            itemDAL.REPAIRSTATUS = "Z";
            itemDAL.UNIT = ftData.SIUNIT;
            itemDAL.STOCKOUT = ftDAL.LOID;
            itemDAL.MATERIALMASTER = ftData.MATERIAL;
            itemDAL.BRAND = ftData.SIBRAND;

            itemDAL.OnDB = false;
            ret = itemDAL.InsertCurrentData(UserID, null);
            if (!ret) throw new ApplicationException(itemDAL.ErrorMessage);

            return ret;
        }
        public RepairRequestData GetData(double loid)
        {
            StockOutDAL DALObj;
            DALObj = new StockOutDAL();
            RepairRequestData data = new RepairRequestData();
            if (DALObj.GetDataByLOID(loid, null))
            {
                data.LOID = DALObj.LOID;
                data.CODE = DALObj.CODE;
                data.STOCKOUTDATE = DALObj.STOCKOUTDATE;
                data.STATUS = DALObj.STATUS;
                data.DIVISION = DALObj.DIVISION;
            }
            return data;
        }
        public string GetName(string user)
        {
            string name = "";
            OfficerDAL oDAL = new OfficerDAL();
            if (oDAL.GetDataByUserID(user))
            {
                name = oDAL.FIRSTNAME + " " + oDAL.LASTNAME;
            }
            return name;
        }
        public bool UpdateStatus(ArrayList arrData,string status, string userID)
        {
            StockOutDAL DALObj;
            bool ret = true;
            zTran trans = new zTran();
            DALObj = new StockOutDAL();
            DALObj.OnDB = true;
            trans.CreateTransaction();
            try
            {
                for (int i = 0; i < arrData.Count; i++)
                {
                    if (DALObj.GetStockItem(Convert.ToDouble(arrData[i])).Rows.Count == 0)
                    {
                        throw new ApplicationException("ไม่สามารถอนุมัติรายการได้ เนื่องจากบางรายการไม่ได้ระบุวัสดุที่ส่งซ่อม");
                    }
                    RepairRequestData data = GetData(Convert.ToDouble(arrData[i]));

                    DALObj.OnDB = false;
                    DALObj.GetDataByLOID(Convert.ToDouble(arrData[i]), null);
                    if (DALObj.STATUS == "WA")
                    {
                        DALObj.STATUS = status;
                        ret = DALObj.UpdateCurrentData(userID, null);
                        if (!ret) throw new ApplicationException(DALObj.ErrorMessage);
                    }
                }
                trans.CommitTransaction();
            }
            catch (Exception ex)
            {
                ret = false;
                _error = ex.Message;
                trans.RollbackTransaction();
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
                mDAL.STATUS = "SE";
                mDAL.REPAIRSTATUS = "Z";
                mDAL.UNIT = mData.SIUNIT;
                mDAL.STOCKOUT = mData.LOID;
                mDAL.BRAND = mData.SIBRAND;
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
                StockOrder.DIVISION = mData.DIVISION;
                StockOrder.PRIORITY = mData.PRIORITY;
                StockOrder.WAREHOUSE = mData.WAREHOUSE;
                StockOrder.STOCKOUTDATE = mData.STOCKOUTDATE;
                if (StockOrder.OnDB)
                    ret = StockOrder.UpdateCurrentData(userID, trans.Trans);

                if (!ret) _error = StockOrder.ErrorMessage;

                ret = UpdateStockitem(mData, userID, trans.Trans);
                

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
