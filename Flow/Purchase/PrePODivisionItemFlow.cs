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
/// FoodTypeFlow Class
/// Version 1.0
/// =========================================================================
/// Create by: Tan
/// Create Date: 19 Feb 2009
/// -------------------------------------------------------------------------
/// Modify By: -
/// Modify From: -
/// Modify Date: -
/// -------------------------------------------------------------------------
/// Remark: -
/// Description:
///    Flow จัดการการทำงานของหน้า PrePODivision 
/// Changes:
///    1.0 - สร้าง
/// -------------------------------------------------------------------------
/// =========================================================================
/// </summary>
/// 
namespace SHND.Flow.Purchase
{
    public class PrePODivisionItemFlow
    {
        string _error = "";
        double _LOID = 0;
        double _PODIVISIONITEM = 0;
        public string ErrorMessage { get { return _error; } }
        public double LOID { get { return _LOID; } }
        public double PODIVISIONITEM { get { return _PODIVISIONITEM; } }

        public DataTable GetMasterList(PrePOSearchData pData, string OrderText)
        {
            VPrePODivisionDAL vDAL = new VPrePODivisionDAL();
            return vDAL.GetDataListByCondition(pData, OrderText, null);
        }

        public DataTable GetMaterialItemList(double PrePO)
        {
            VPrePODivisionItemDAL VMaterialItem = new VPrePODivisionItemDAL();
            DataTable dt = VMaterialItem.GetDataListByPrePO(PrePO, "LOID", null);
            dt.Columns.Add("RANK", typeof(double));
            for (int i = 0; i < dt.Rows.Count; ++i)
            {
                dt.Rows[i]["RANK"] = i + 1;
            }
            return dt;
        }

        public DataTable GetMaterialItemListMenu(double plan, double division, DateTime usedate, double planMaterialClass)
        {
            VPrePODivisionItemMenuDAL VMaterialItem = new VPrePODivisionItemMenuDAL();
            DataTable dt = VMaterialItem.GetDataListByCondition(division,usedate, planMaterialClass, "MATERIALMASTER", null);
            dt.Columns.Add("LOID", typeof(double));
            dt.Columns.Add("RANK", typeof(double));
            dt.Columns.Add("ORDERQTY", typeof(double));
            dt.Columns.Add("NETPRICE", typeof(double));
            dt.Columns.Add("REMARKS", typeof(string));
            dt.Columns.Add("PREPODIVISION", typeof(double));
            dt.Columns.Add("PLANREMAINQTY", typeof(double));
            for (int i = 0; i < dt.Rows.Count; ++i)
            {
                dt.Rows[i]["RANK"] = i + 1;
                dt.Rows[i]["LOID"] = i + 1;
                dt.Rows[i]["ORDERQTY"] = dt.Rows[i]["MENUQTY"];
                dt.Rows[i]["NETPRICE"] = Convert.ToDouble(dt.Rows[i]["MENUQTY"]) * Convert.ToDouble(dt.Rows[i]["PRICE"]);
                dt.Rows[i]["REMARKS"] = "";
                dt.Rows[i]["PREPODIVISION"] = 0;
                dt.Rows[i]["PLANREMAINQTY"] = GetRemain(plan,Convert.ToDouble(dt.Rows[i]["MATERIALMASTER"]), division);

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

        public PrePODivisionData GetDetails(double LOID)
        {
            VPrePODivisionDAL ffDAL = new VPrePODivisionDAL();
            PrePODivisionData ffData = new PrePODivisionData();
            ffDAL.GetDataByLOID(LOID, null);
            ffData.PLAN = ffDAL.PLANORDER;
            ffData.PLANMATERIALCLASS = ffDAL.PLANMATERIALCLASS;
            ffData.MATERIALCLASS = ffDAL.MATERIALCLASS;
            ffData.LOID = ffDAL.LOID;
            ffData.SUPPLIERCODE = ffDAL.SUPPLIERCODE;
            ffData.CONTACTCODE = ffDAL.CONTRACTCODE;
            ffData.SUPPLIERNAME = ffDAL.SUPPLIERNAME;
            ffData.CODE = ffDAL.CODE;
            ffData.BPODATE = ffDAL.BPODATE;
            ffData.USEDATE = ffDAL.USEDATE;
            ffData.STATUS = ffDAL.STATUS;
            ffData.STATUSNAME = ffDAL.STATUSNAME;
            ffData.REMARKS = ffDAL.REMARKS;
            ffData.DIVISION = ffDAL.DIVISION;
            ffData.DIVISIONNAME = ffDAL.DIVISIONNAME;


            //if (ffDAL.OnDB && LOID != 0)
            //    _error = Data.Common.Utilities.DataResources.MSGEV002;

            return ffData;

        }

        public SupplierData GetSupplier(double plan, double materialclass)
        {
            VPrePODivisionItemDAL ffDAL = new VPrePODivisionItemDAL();
            return ffDAL.GetDataSupplier(plan, materialclass);
        }

        public double GetRemain(double plan, double materialmaster, double division)
        {
            VPrePODivisionItemDAL ffDAL = new VPrePODivisionItemDAL();
            return ffDAL.GetRemainQty(plan, materialmaster, division);
        }

        public double GetRemainTotal(double plan, double materialclass)
        {
            VPrePODivisionItemDAL ffDAL = new VPrePODivisionItemDAL();
            return ffDAL.GetRemainTotal(plan, materialclass);
        }

        public DataTable GetOrderMenuList(DateTime usedate, double division)
        {
            VPrePOMenuDAL Menu = new VPrePOMenuDAL();
            return Menu.GetDataListByDate(usedate,division, "MENUNAME", null);
        }

        public bool InsertData(PrePODivisionData ffData, string UserID)
        {
            bool ret = true;
            zTran trans = new zTran();
            trans.CreateTransaction();

            PrePODivisionDAL ffDAL = new PrePODivisionDAL();

            ffDAL.BPODATE = ffData.BPODATE;
            ffDAL.USEDATE = ffData.USEDATE;
            ffDAL.DIVISION = ffData.DIVISION;
            ffDAL.STATUS = ffData.STATUS;
            ffDAL.REMARKS = ffData.REMARKS;
            ffDAL.PLANMATERIALCLASS = ffData.PLANMATERIALCLASS;

            try
            {
                ret = ffDAL.InsertCurrentData(UserID, trans.Trans);
                if (!ret)
                    _error = ffDAL.ErrorMessage;

                if (ret)
                    ret = InsertPrePODivisionItem(ffData.PrePODivisionItem, UserID, ffDAL.LOID,ffData.PLAN,ffData.DIVISION,ffData.PrePODuedate, trans.Trans);

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

        public bool UpdateData(PrePODivisionData ffData, string UserID)
        {
            bool ret = true;
            zTran trans = new zTran();
            trans.CreateTransaction();

            PrePODivisionDAL ffDAL = new PrePODivisionDAL();
            ffDAL.GetDataByLOID(ffData.LOID, trans.Trans);
            ffDAL.BPODATE = ffData.BPODATE;
            ffDAL.USEDATE = ffData.USEDATE;
            ffDAL.DIVISION = ffData.DIVISION;
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
                        ret = InsertPrePODivisionItem(ffData.PrePODivisionItem, UserID, ffDAL.LOID, ffData.PLAN, ffData.DIVISION, ffData.PrePODuedate, trans.Trans);

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
        private bool InsertPrePODivisionItem(ArrayList arrPrePODivisionItem, string userID, double PrePODivision, double plan, double division, ArrayList arrPrePODuedate, OracleTransaction trans)
        {
            bool ret = true;
            string materialMasterList = "";
            for (int i = 0; i < arrPrePODivisionItem.Count; ++i)
            {
                PrePOItemData datPrePOItem = (PrePOItemData)arrPrePODivisionItem[i];
                materialMasterList += (materialMasterList == "" ? "" : ",") + "'" + datPrePOItem.CODE.ToString() + "'";
            }
            PrePODivisionItemDAL PrePOItem = new PrePODivisionItemDAL();
            if (materialMasterList != "")  PrePOItem.doDelete("PREPODIVISION = " + PrePODivision + " AND MATERIALMASTER||'#'||UNIT NOT IN (" + materialMasterList + ") ", trans);

            for (int i = 0; i < arrPrePODivisionItem.Count; ++i)
            {
                PrePOItem = new PrePODivisionItemDAL();
                PrePOItemData datPrePOItem = (PrePOItemData)arrPrePODivisionItem[i];
                PrePOItem.GetDataByUniqueKey(PrePODivision, datPrePOItem.MATERIALMASTER, datPrePOItem.UNIT, trans);
                PrePOItem.MENUQTY = datPrePOItem.MENUQTY;
                PrePOItem.ORDERQTY = datPrePOItem.ORDERQTY;
                PrePOItem.MATERIALMASTER = datPrePOItem.MATERIALMASTER;
                PrePOItem.PRICE = datPrePOItem.PRICE;
                PrePOItem.PLANREMAINQTY = datPrePOItem.PLANREMAINQTY;
                PrePOItem.ISVAT = datPrePOItem.ISVAT;
                PrePOItem.UNIT = datPrePOItem.UNIT;
                PrePOItem.PREPODIVISION = PrePODivision;
                PrePOItem.PLANREMAINQTY = datPrePOItem.PLANREMAINQTY;
                PrePOItem.REMARKS = datPrePOItem.REMARKS;
                PrePOItem.USEQTY = PrePOItem.GetUseQty(plan, division, datPrePOItem.MATERIALMASTER);

                if (!PrePOItem.OnDB)
                    ret = PrePOItem.InsertCurrentData(userID, trans);
                else
                    ret = PrePOItem.UpdateCurrentData(userID, trans);

                if (!ret)
                    //ret = InsertPrePODuedate(arrPrePODuedate, userID, PrePOItem.LOID, datPrePOItem.CODE, trans);
                //else
                {
                    _error = PrePOItem.ErrorMessage;
                    break;
                }
            }
            return ret;
        }

        private bool InsertPrePODuedate(ArrayList arrPrePODuedate, string userID, double PrePODivisionItem, string Code, OracleTransaction trans)
        {
            PrePODuedateDAL PrePODuedate;
            bool ret = true;

            for (int i = 0; i < arrPrePODuedate.Count; ++i)
            {
                PrePODuedate = new PrePODuedateDAL();
                PrePODuedateData datPrePODuedate = (PrePODuedateData)arrPrePODuedate[i];
                PrePODuedate.DUEDATE = datPrePODuedate.DUEDATE;
                PrePODuedate.DUEQTY = datPrePODuedate.DUEQTY;
                PrePODuedate.PREPOITEM = PrePODivisionItem;

                if (datPrePODuedate.CODE == Code)
                    ret = PrePODuedate.InsertCurrentData(userID, trans);

                if(!ret)
                {
                    _error = PrePODuedate.ErrorMessage;
                    break;
                }
            }
            return ret;
        }

        public bool CheckUniqueKey(double cLOID, double cDIVISION, double cPLANMATERIALCLASS, DateTime cUSEDATE)
        {
            VPrePODivisionDAL fDAL = new VPrePODivisionDAL();
            fDAL.GetDataByUniqueKey(cDIVISION, cPLANMATERIALCLASS, cUSEDATE, null);
            return !fDAL.OnDB || (cLOID == fDAL.LOID);
        }

    }
}
