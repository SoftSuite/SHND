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
using SHND.DAL.Utilities;
using System.Collections;
//using DB = SHND.DAL.Utilities.OracleDB;
using zTran = SHND.DAL.Utilities.OracleTransactionDB;

/// <summary>
/// ReceiveFlow Class
/// Version 1.0
/// =========================================================================
/// Create by: Tan
/// Create Date: 16 March 2009
/// -------------------------------------------------------------------------
/// Modify By: -
/// Modify From: -
/// Modify Date: -
/// -------------------------------------------------------------------------
/// Remark: -
/// Description:
///    Flow จัดการการทำงานของหน้า Receive
/// Changes:
///    1.0 - สร้าง
/// -------------------------------------------------------------------------
/// =========================================================================
/// </summary>
/// 
namespace SHND.Flow.Purchase
{
    public class ReceiveFlow
    {
        string _error = "";
        double _LOID = 0;
        double _PODIVISIONITEM = 0;
        public string ErrorMessage { get { return _error; } }
        public double LOID { get { return _LOID; } }
        public double PODIVISIONITEM { get { return _PODIVISIONITEM; } }

        public DataTable GetMasterList(ReceiveSearchData pData, string OrderText)
        {
            VReceiveDAL vDAL = new VReceiveDAL();
            return vDAL.GetDataListByCondition(pData, OrderText, null);
        }

        public DataTable GetMaterialItemList(double Receive)
        {
            VReceiveItemDAL VMaterialItem = new VReceiveItemDAL();
            DataTable dt = VMaterialItem.GetDataListByReceive(Receive, "MATERIALNAME", null);
            dt.Columns.Add("RANK", typeof(double));
            for (int i = 0; i < dt.Rows.Count; ++i)
            {
                dt.Rows[i]["RANK"] = i + 1;
            }
            return dt;
        }

        public DataTable GetMaterialItemListMenu(double plan, double mclass, DateTime usedate)
        {
            VPrePODivisionSumDAL VMaterialItem = new VPrePODivisionSumDAL();
            DataTable dt = VMaterialItem.GetDataListByCondition(plan, mclass, usedate, "MATERIALMASTER", null);
            dt.Columns.Add("LOID", typeof(double));
            dt.Columns.Add("RANK", typeof(double));
            dt.Columns.Add("PREPODIVISION", typeof(double));
            for (int i = 0; i < dt.Rows.Count; ++i)
            {
                dt.Rows[i]["RANK"] = i + 1;
                dt.Rows[i]["LOID"] = i + 1;
                dt.Rows[i]["PREPODIVISION"] = 0;
            }
            return dt;
        }

        public DataTable GetMaterialDeliveryList(double PrePO)
        {
            VPrePODuedateItemDAL VMaterialItem = new VPrePODuedateItemDAL();
            DataTable dt = VMaterialItem.GetDataListByPrePO(PrePO, "DUEDATE", null);
            dt.Columns.Add("RANK", typeof(double));
            for (int i = 0; i < dt.Rows.Count; ++i)
            {
                dt.Rows[i]["RANK"] = i + 1;
            }
            return dt;
        }

        public DataTable GetMaterialDeliveryBlank()
        {
            VPrePODuedateItemDAL VMaterialItem = new VPrePODuedateItemDAL();
            DataTable dt = VMaterialItem.GetDataListBlank();
            dt.Columns.Add("RANK", typeof(double));
            for (int i = 0; i < dt.Rows.Count; ++i)
            {
                dt.Rows[i]["RANK"] = i + 1;
            }
            return dt;
        }

        public VReceiveData GetDetails(double LOID)
        {
            VReceiveDAL ffDAL = new VReceiveDAL();
            VReceiveData ffData = new VReceiveData();
            ffDAL.GetDataByLOID(LOID, null);
            ffData.PLANORDER = ffDAL.PLANORDER;
            ffData.MATERIALCLASS = ffDAL.MATERIALCLASS;
            ffData.PLANMATERIALCLASS = ffDAL.PLANMATERIALCLASS;
            ffData.LOID = ffDAL.LOID;
            ffData.SUPPLIERCODE = ffDAL.SUPPLIERCODE;
            ffData.CONTRACTCODE = ffDAL.CONTRACTCODE;
            ffData.SUPPLIERNAME = ffDAL.SUPPLIERNAME;
            ffData.RECEIVEDATE = ffDAL.RECEIVEDATE;
            ffData.STATUS = ffDAL.STATUS;
            ffData.STATUSNAME = ffDAL.STATUSNAME;
            ffData.REMARKS = ffDAL.REMARKS;
            //ffData.CNAME = ffDAL.CNAME;
            //ffData.ADDRESS = ffDAL.ADDRESS;
            ffData.TEL = ffDAL.TEL;
            ffData.FAX = ffDAL.FAX;


            //if (ffDAL.OnDB && LOID != 0)
            //    _error = Data.Common.Utilities.DataResources.MSGEV002;

            return ffData;

        }

        public SupplierData GetSupplier(double plan, double materialclass)
        {
            VPrePODivisionItemDAL ffDAL = new VPrePODivisionItemDAL();
            return ffDAL.GetDataSupplier(plan, materialclass);
        }

        public double GetRemain(double plan, double division, double materialmaster)
        {
            VPrePODivisionItemDAL ffDAL = new VPrePODivisionItemDAL();
            return ffDAL.GetRemainQty(plan, division, materialmaster);
        }
        public double GetCurrPlan(DateTime currDate)
        {
            PlanOrderDAL pDAL = new PlanOrderDAL();
            return pDAL.GetDataByPeriod(currDate, null);
        }

        public bool InsertData(ReceiveData ffData, string UserID)
        {
            bool ret = true;
            zTran trans = new zTran();
            trans.CreateTransaction();

            ReceiveDAL ffDAL = new ReceiveDAL();

            ffDAL.RECEIVEDATE = ffData.RECEIVEDATE;
            ffDAL.STATUS = ffData.STATUS;
            ffDAL.REMARKS = ffData.REMARKS;
            ffDAL.PLANMATERIALCLASS = ffData.PLANMATERIALCLASS;

            try
            {
                ret = ffDAL.InsertCurrentData(UserID, trans.Trans);
                if (!ret)
                    _error = ffDAL.ErrorMessage;

                if (ret)
                    ret = InsertReceiveItem(ffData.ReceiveItem, UserID, ffDAL.LOID, trans.Trans);

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

        public bool UpdateData(ReceiveData ffData, string UserID)
        {
            bool ret = true;
            zTran trans = new zTran();
            trans.CreateTransaction();

            ReceiveDAL ffDAL = new ReceiveDAL();
            ffDAL.GetDataByLOID(ffData.LOID, trans.Trans);
            ffDAL.RECEIVEDATE = ffData.RECEIVEDATE;
            ffDAL.STATUS = ffData.STATUS;
            ffDAL.REMARKS = ffData.REMARKS;
            ffDAL.PLANMATERIALCLASS = ffData.PLANMATERIALCLASS;
            try
            {
                if (ffDAL.OnDB)
                {
                    ret = ffDAL.UpdateCurrentData(UserID, trans.Trans);
                    if (!ret)
                        _error = ffDAL.ErrorMessage;

                    if (ret)
                        ret = InsertReceiveItem(ffData.ReceiveItem, UserID, ffDAL.LOID, trans.Trans);

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
        private bool InsertReceiveItem(ArrayList arrReceiveItem, string userID, double Receive, OracleTransaction trans)
        {
            bool ret = true;
            string materialMasterList = "";
            for (int i = 0; i < arrReceiveItem.Count; ++i)
            {
                VReceiveMaterialData datReceiveItem = (VReceiveMaterialData)arrReceiveItem[i];
                materialMasterList += (materialMasterList == "" ? "" : ",") + "'" + datReceiveItem.CODE.ToString() + "'";
            }
            ReceiveItemDAL ReceiveItem = new ReceiveItemDAL();
            if (materialMasterList != "") ReceiveItem.doDelete("RECEIVE = " + Receive + " AND MASTER||'#'||UNIT || '#' || PREPODUEDATE NOT IN (" + materialMasterList + ") ", trans);

            for (int i = 0; i < arrReceiveItem.Count; ++i)
            {
                ReceiveItem = new ReceiveItemDAL();
                VReceiveMaterialData datReceiveItem = (VReceiveMaterialData)arrReceiveItem[i];
                ReceiveItem.GetDataByUniqueKey(Receive, datReceiveItem.MATERIALMASTER, datReceiveItem.UNITLOID, datReceiveItem.PREPODUEDATE, trans);
                ReceiveItem.RECEIVEQTY = datReceiveItem.RECEIVEQTY;
                ReceiveItem.PREPODUEDATE = datReceiveItem.PREPODUEDATE;
                ReceiveItem.MATERIALMASTER = datReceiveItem.MATERIALMASTER;
             //   ReceiveItem.PRICE = datReceiveItem.PRICE;
             //   ReceiveItem.PLANREMAINQTY = datReceiveItem.PLANREMAINQTY;
             //   ReceiveItem.ISVAT = datReceiveItem.ISVAT;
                ReceiveItem.UNIT = datReceiveItem.UNITLOID;
                ReceiveItem.RECEIVE = Receive;
              //  ReceiveItem.PLANREMAINQTY = datReceiveItem.PLANREMAINQTY;
                ReceiveItem.REMARKS = datReceiveItem.REMARK;

                if (!ReceiveItem.OnDB)
                    ret = ReceiveItem.InsertCurrentData(userID, trans);
                else
                    ret = ReceiveItem.UpdateCurrentData(userID, trans);

                if (!ret)
                {
                    _error = ReceiveItem.ErrorMessage;
                    break;
                }
            }
            return ret;
        }

        public bool CheckUniqueKey(double cLOID, double cPLANMATERIALCLASS, DateTime cRECEIVEDATE)
        {
            ReceiveDAL fDAL = new ReceiveDAL();
            fDAL.GetDataByUniqueKey(cPLANMATERIALCLASS, cRECEIVEDATE, null);
            return !fDAL.OnDB || (cLOID == fDAL.LOID);
        }

    }
}
