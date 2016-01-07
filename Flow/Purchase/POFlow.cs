using System;
using System.Collections.Generic;
using System.Data.OracleClient;
using System.Text;
using System.Data;
using SHND.DAL.Views;
using SHND.DAL.Tables;
using SHND.Data.Views;
using SHND.Data.Tables;
using SHND.Data.Purchase;
using SHND.Data.Inventory;
using SHND.DAL.Utilities;
using System.Collections;
//using DB = SHND.DAL.Utilities.OracleDB;
using zTran = SHND.DAL.Utilities.OracleTransactionDB;

/// <summary>
/// FoodTypeFlow Class
/// Version 1.0
/// =========================================================================
/// Create by: Tan
/// Create Date: 1 April 2009
/// -------------------------------------------------------------------------
/// Modify By: -
/// Modify From: -
/// Modify Date: -
/// -------------------------------------------------------------------------
/// Remark: -
/// Description:
///    Flow จัดการการทำงานของหน้า PO 
/// Changes:
///    1.0 - สร้าง
/// -------------------------------------------------------------------------
/// =========================================================================
/// </summary>
/// 
namespace SHND.Flow.Purchase
{
    public class POFlow
    {
        double _LOID = 0;
        string _error = "";
        public string ErrorMessage { get { return _error; } }

        public double LOID
        {
            get { return _LOID; }
        }

        public DataTable GetMasterList(POSearchData pData, string OrderText)
        {
            VPODAL vDAL = new VPODAL();
            return vDAL.GetDataListByCondition(pData, OrderText, null);
        }
        public DataTable GetMaterialItemList(double PrePO, string IsVat)
        {
            VPrePOReceiveDAL VDAL = new VPrePOReceiveDAL();
            DataTable dt = VDAL.GetDataListByPrePO(PrePO, IsVat, "MATERIALNAME", null);
            dt.Columns.Add("LOID", typeof(double));
            dt.Columns.Add("RANK", typeof(double));
            dt.Columns.Add("REMARKS", typeof(string));
            for (int i = 0; i < dt.Rows.Count; ++i)
            {
                dt.Rows[i]["RANK"] = i + 1;
                dt.Rows[i]["LOID"] = 0;
                dt.Rows[i]["REMARKS"] = "";
            }
            return dt;
        }
        public DataTable GetPOItemList(double PO)
        {
            VPOItemDAL vDAL = new VPOItemDAL();
            DataTable dt = vDAL.GetDataListByPO(PO, "MATERIALNAME", null);
            dt.Columns.Add("RANK", typeof(double));
            for (int i = 0; i < dt.Rows.Count; ++i)
            {
                dt.Rows[i]["RANK"] = i + 1;
            }
            return dt;
        }
        public DataTable GetMaterialList(string CodeFrom, string CodeTo, DateTime StartDate, DateTime EndDate, double Division, string statusFrom, string statusTo, string orderBy)
        {
            VStockOutDAL vDAL = new VStockOutDAL();
            return vDAL.GetDataListByConditions(0, 0, Division, CodeFrom, CodeTo, new DateTime(), new DateTime(), StartDate, EndDate, statusFrom, statusTo, orderBy, null);
        }
        public string GetVat()
        {
            VPODAL ffDAL = new VPODAL();
            return ffDAL.GetVat();
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

        public VPOData GetDetails(double LOID)
        {
            VPODAL fDAL = new VPODAL();
            VPOData fData = new VPOData();
            fDAL.GetDataByLOID(LOID, null);
            if (fDAL.OnDB)
            {
                fData.CODE = fDAL.CODE;
                fData.ADDRESS = fDAL.ADDRESS;
                fData.LOID = fDAL.LOID;
                fData.STATUS = fDAL.STATUS;
                fData.BPODATE = fDAL.BPODATE;
                fData.CLASSNAME = fDAL.CLASSNAME;
                fData.CNAME = fDAL.CNAME;
                fData.FAX = fDAL.FAX;
                fData.ISVAT = fDAL.ISVAT;
                fData.MATERIALCLASS = fDAL.MATERIALCLASS;
                fData.PODATE = fDAL.PODATE;
                fData.PREPO = fDAL.PREPO;
                fData.PREPOCODE = fDAL.PREPOCODE;
                fData.RECEIVECODE = fDAL.RECEIVECODE;
                fData.REFPOCODE = fDAL.REFPOCODE;
                fData.REMARKS = fDAL.REMARKS;
                fData.STATUS = fDAL.STATUS;
                fData.STATUSNAME = fDAL.STATUSNAME;
                fData.SUPPLIER = fDAL.SUPPLIER;
                fData.SUPPLIERCODE = fDAL.SUPPLIERCODE;
                fData.SUPPLIERNAME = fDAL.SUPPLIERNAME;
                fData.TEL = fDAL.TEL;
                fData.VATRATE = fDAL.VATRATE;
                fData.CONTRACTCODE = fDAL.CONTRACTCODE;
            }
            else
                _error = Data.Common.Utilities.DataResources.MSGEV002;

            return fData;

        }
        //public bool InsertData(RepairRequestData ftData, string UserID)
        //{
        //    StockOutDAL ftDAL = new StockOutDAL();
        //    ftDAL.CODE = ftData.CODE;
        //    ftDAL.STOCKOUTDATE = ftData.STOCKOUTDATE;
        //    ftDAL.WAREHOUSE = ftData.WAREHOUSE;
        //    ftDAL.DIVISION = ftData.DIVISION;
        //    ftDAL.PRIORITY = ftData.PRIORITY;
        //    ftDAL.STATUS = ftData.STATUS;
        //    ftDAL.DOCTYPE = 16;

        //    bool ret = true;

        //    if (ftDAL.OnDB)
        //        ret = ftDAL.UpdateCurrentData(UserID, null);
        //    else
        //        ret = ftDAL.InsertCurrentData(UserID, null);

        //    _LOID = ftDAL.LOID;

        //    if (!ret)
        //    {
        //        throw new ApplicationException(ftDAL.ErrorMessage);
        //    }

        //    StockoutitemDAL itemDAL = new StockoutitemDAL();
        //    itemDAL.LOID = ftData.SILOID;
        //    itemDAL.LOTNO = ftData.SILOTNO;
        //    itemDAL.QTY = ftData.SIQTY;
        //    itemDAL.UNIT = ftData.SIUNIT;
        //    itemDAL.FLOOR = ftData.FLOOR;
        //    itemDAL.REMARKS = ftData.REMARKS;
        //    itemDAL.REPAIRBY = ftData.REPAIRBY;
        //    itemDAL.ISMENU = "N";
        //    itemDAL.STATUS = "WA";
        //    itemDAL.REPAIRSTATUS = "Z";
        //    itemDAL.UNIT = ftData.SIUNIT;
        //    itemDAL.STOCKOUT = ftDAL.LOID;
        //    itemDAL.MATERIALMASTER = ftData.MATERIAL;

        //    itemDAL.OnDB = false;
        //    ret = itemDAL.InsertCurrentData(UserID, null);
        //    if (!ret) throw new ApplicationException(itemDAL.ErrorMessage);

        //    return ret;
        //}
        //public RepairRequestData GetData(double loid)
        //{
        //    StockOutDAL DALObj;
        //    DALObj = new StockOutDAL();
        //    RepairRequestData data = new RepairRequestData();
        //    if (DALObj.GetDataByLOID(loid, null))
        //    {
        //        data.LOID = DALObj.LOID;
        //        data.CODE = DALObj.CODE;
        //        data.STOCKOUTDATE = DALObj.STOCKOUTDATE;
        //        data.STATUS = DALObj.STATUS;
        //        data.DIVISION = DALObj.DIVISION;
        //    }
        //    return data;
        //}
        public bool InsertData(VPOData ffData, string UserID)
        {
            bool ret = true;
            zTran trans = new zTran();
            trans.CreateTransaction();

            PODAL ffDAL = new PODAL();

            ffDAL.ADDRESS = ffData.ADDRESS;
            ffDAL.CNAME = ffData.CNAME;
            ffDAL.REMARKS = ffData.REMARKS;
            ffDAL.ISVAT = ffData.ISVAT;
            ffDAL.PODATE = ffData.PODATE;
            ffDAL.PREPO = ffData.PREPO;
            ffDAL.STATUS = ffData.STATUS;
            ffDAL.TEL = ffData.TEL;
            ffDAL.FAX = ffData.FAX;
            ffDAL.VATRATE = ffData.VATRATE;

            try
            {
                ret = ffDAL.InsertCurrentData(UserID, trans.Trans);
                if (!ret)
                    _error = ffDAL.ErrorMessage;

                if (ret)
                    ret = InsertPOItem(ffData.POItem, UserID, ffDAL.LOID, trans.Trans);

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

        public bool UpdateData(VPOData ffData, string UserID)
        {
            bool ret = true;
            zTran trans = new zTran();
            trans.CreateTransaction();

            PODAL ffDAL = new PODAL();
            ffDAL.GetDataByLOID(ffData.LOID, trans.Trans);
            ffDAL.ADDRESS = ffData.ADDRESS;
            ffDAL.CNAME = ffData.CNAME;
            ffDAL.REMARKS = ffData.REMARKS;
            ffDAL.ISVAT = ffData.ISVAT;
            ffDAL.PODATE = ffData.PODATE;
            ffDAL.PREPO = ffData.PREPO;
            ffDAL.STATUS = ffData.STATUS;
            ffDAL.TEL = ffData.TEL;
            ffDAL.FAX = ffData.FAX;
            ffDAL.VATRATE = ffData.VATRATE;
            try
            {
                if (ffDAL.OnDB)
                {
                    ret = ffDAL.UpdateCurrentData(UserID, trans.Trans);
                    if (!ret)
                        _error = ffDAL.ErrorMessage;

                    if (ret)
                        ret = InsertPOItem(ffData.POItem, UserID, ffDAL.LOID, trans.Trans);

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
        private bool InsertPOItem(ArrayList arrPOItem, string userID, double PO, OracleTransaction trans)
        {
            bool ret = true;
            string materialMasterList = "";
            for (int i = 0; i < arrPOItem.Count; ++i)
            {
                POItemData datPOItem = (POItemData)arrPOItem[i];
                materialMasterList += (materialMasterList == "" ? "" : ",") + "'" + datPOItem.MATERIALMASTER.ToString() + "'";
            }
            POITEMDAL POItem = new POITEMDAL();
            if (materialMasterList != "") POItem.doDelete("PO = " + PO + " AND MATERIALMASTER NOT IN (" + materialMasterList + ") ", trans);

            for (int i = 0; i < arrPOItem.Count; ++i)
            {
                POItem = new POITEMDAL();
                POItemData datPOItem = (POItemData)arrPOItem[i];
                POItem.GetDataByUniqueKey(PO, datPOItem.MATERIALMASTER, trans);
                POItem.QTY = datPOItem.QTY;
                POItem.MATERIALMASTER = datPOItem.MATERIALMASTER;
                POItem.UNIT = datPOItem.UNIT;
                POItem.PO = PO;
                POItem.PRICE = datPOItem.PRICE;
                POItem.PLANREMAINQTY = datPOItem.PLANREMAINQTY;
                POItem.REMARKS = datPOItem.REMARKS;
                POItem.USEQTY = datPOItem.USEQTY;

                if (!POItem.OnDB)
                    ret = POItem.InsertCurrentData(userID, trans);
                else
                    ret = POItem.UpdateCurrentData(userID, trans);

                if (!ret)
                {
                    _error = POItem.ErrorMessage;
                    break;
                }
            }
            return ret;
        }

        public bool UpdateDataStockIn(VPOData ffData, string UserID)
        {
            bool ret = true;
            zTran trans = new zTran();
            trans.CreateTransaction();

            VPODAL ffDAL = new VPODAL();
            ffDAL.GetDataByLOID(ffData.LOID, trans.Trans);
            ffDAL.STATUS = ffData.STATUS;

            StockInDAL StDAL = new StockInDAL();
            StDAL.DOCTYPE = 2;
            StDAL.ISVAT = ffData.ISVAT;
            StDAL.PO = ffData.LOID;
            StDAL.REMARKS = ffData.REMARKS;
            StDAL.STATUS = "AP";
            StDAL.STOCKINDATE = DateTime.Today;
            StDAL.WAREHOUSE = 1;
            StDAL.PLANORDER = ffDAL.PLANORDER;

            try
            {
                if (ffDAL.OnDB)
                {
                    ret = ffDAL.UpdateCurrentData(UserID, trans.Trans);
                    if (!ret)
                        _error = ffDAL.ErrorMessage;

                    if (ret)
                        ret = StDAL.InsertCurrentData(UserID, trans.Trans);
                    if (!ret)
                        _error = StDAL.ErrorMessage;

                    if (ret)
                        ret = InsertPOItemReceive(ffData.POItem, UserID, ffDAL.LOID, StDAL.LOID, trans.Trans);

                    if (ret)
                        ret = StDAL.CutStock(StDAL.LOID, trans.Trans);
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

        private bool InsertPOItemReceive(ArrayList arrPOItem, string userID, double PO, double stockin, OracleTransaction trans)
        {
            bool ret = true;
            string materialMasterList = "";
            for (int i = 0; i < arrPOItem.Count; ++i)
            {
                POItemData datPOItem = (POItemData)arrPOItem[i];
                materialMasterList += (materialMasterList == "" ? "" : ",") + "'" + datPOItem.MATERIALMASTER.ToString() + "'";
            }
            POITEMDAL POItem = new POITEMDAL();
            if (materialMasterList != "") POItem.doDelete("PO = " + PO + " AND MATERIALMASTER NOT IN (" + materialMasterList + ") ", trans);

            for (int i = 0; i < arrPOItem.Count; ++i)
            {
                POItem = new POITEMDAL();
                POItemData datPOItem = (POItemData)arrPOItem[i];
                POItem.GetDataByUniqueKey(PO, datPOItem.MATERIALMASTER, trans);
                POItem.QTY = datPOItem.QTY;
                POItem.MATERIALMASTER = datPOItem.MATERIALMASTER;
                POItem.UNIT = datPOItem.UNIT;
                POItem.PO = PO;
                POItem.PRICE = datPOItem.PRICE;
                POItem.PLANREMAINQTY = datPOItem.PLANREMAINQTY;
                POItem.REMARKS = datPOItem.REMARKS;
                POItem.USEQTY = datPOItem.USEQTY;

                if (!POItem.OnDB)
                    ret = POItem.InsertCurrentData(userID, trans);
                else
                    ret = POItem.UpdateCurrentData(userID, trans);

                if (!ret)
                {
                    _error = POItem.ErrorMessage;
                    break;
                }
                else
                {
                    StockinItemDAL StItem = new StockinItemDAL();
                    StItem.MATERIALMASTER = datPOItem.MATERIALMASTER;
                    StItem.PLANREMAINQTY = datPOItem.PLANREMAINQTY;
                    StItem.PRICE = datPOItem.PRICE;
                    StItem.QTY = datPOItem.QTY;
                    StItem.REFLOID = POItem.LOID;
                    StItem.REFTABLE = "POITEM";
                    StItem.REMARKS = datPOItem.REMARKS;
                    StItem.STOCKIN = stockin;
                    StItem.UNIT = datPOItem.UNIT;
                    StItem.USEQTY = datPOItem.USEQTY;

                    ret = StItem.InsertCurrentData(userID, trans);

                    if (!ret)
                    {
                        _error = StItem.ErrorMessage;
                        break;
                    }
                }
            }
            return ret;
        }

    }
}
