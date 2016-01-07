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
    public class PrePOFlow
    {
        string _error = "";
        double _LOID = 0;
        double _PODIVISIONITEM = 0;
        public string ErrorMessage { get { return _error; } }
        public double LOID { get { return _LOID; } }
        public double PODIVISIONITEM { get { return _PODIVISIONITEM; } }

        public DataTable GetMasterList(PrePOSearchData pData, string OrderText)
        {
            VPrePODAL vDAL = new VPrePODAL();
            return vDAL.GetDataListByCondition(pData, OrderText, null);
        }

        public DataTable GetMaterialItemList(double PrePO)
        {
            VPrePOItemDAL VMaterialItem = new VPrePOItemDAL();
            DataTable dt = VMaterialItem.GetDataListByPrePO(PrePO, "LOID", null);
            dt.Columns.Add("RANK", typeof(double));
            for (int i = 0; i < dt.Rows.Count; ++i)
            {
                dt.Rows[i]["RANK"] = i + 1;
            }
            return dt;
        }

        public DataTable GetMaterialItemListMenu(double plan,double mclass, DateTime usedate)
        {
            VPrePODivisionSumDAL VMaterialItem = new VPrePODivisionSumDAL();
            DataTable dt = VMaterialItem.GetDataListByCondition(plan,mclass,usedate, "MATERIALMASTER", null);
            dt.Columns.Add("LOID", typeof(double));
            dt.Columns.Add("RANK", typeof(double));
            dt.Columns.Add("PREPODIVISION", typeof(double));
            for (int i = 0; i < dt.Rows.Count; ++i)
            {
                dt.Rows[i]["RANK"] = i + 1;
                dt.Rows[i]["LOID"] = 0;
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

        public PrePODivisionData GetDetails(double LOID)
        {
            VPrePODAL ffDAL = new VPrePODAL();
            PrePODivisionData ffData = new PrePODivisionData();
            ffDAL.GetDataByLOID(LOID, null);
            ffData.PLAN = ffDAL.PLANORDER;
            ffData.MATERIALCLASS = ffDAL.MATERIALCLASS;
            ffData.LOID = ffDAL.LOID;
            ffData.SUPPLIERCODE = ffDAL.SUPPLIERCODE;
            ffData.SUPPLIERNAME = ffDAL.SUPPLIERNAME;
            ffData.CODE = ffDAL.CODE;
            ffData.BPODATE = ffDAL.BPODATE;
            ffData.USEDATE = ffDAL.USEDATE;
            ffData.STATUS = ffDAL.STATUS;
            ffData.STATUSNAME = ffDAL.STATUSNAME;
            ffData.REMARKS = ffDAL.REMARKS;
            ffData.CNAME = ffDAL.CNAME;
            ffData.ADDRESS = ffDAL.ADDRESS;
            ffData.TEL = ffDAL.TEL;
            ffData.FAX = ffDAL.FAX;
            ffData.PLANMATERIALCLASS = ffDAL.PLANMATERIALCLASS;
            ffData.POVAT = ffDAL.POVAT;
            ffData.PONOVAT = ffDAL.PONOVAT;


            //if (ffDAL.OnDB && LOID != 0)
            //    _error = Data.Common.Utilities.DataResources.MSGEV002;

            return ffData;

        }

        public DataTable GetPOList(double PrePO)
        {
            VPrePOReceiveDAL VDAL = new VPrePOReceiveDAL();
            DataTable dt = VDAL.GetDataListByPrePO(PrePO, "MATERIALNAME", null);
            //dt.Columns.Add("LOID", typeof(double));
            //dt.Columns.Add("RANK", typeof(double));
            //dt.Columns.Add("REMARKS", typeof(string));
            //for (int i = 0; i < dt.Rows.Count; ++i)
            //{
            //    dt.Rows[i]["RANK"] = i + 1;
            //    dt.Rows[i]["LOID"] = 0;
            //    dt.Rows[i]["REMARKS"] = "";
            //}
            return dt;
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

        public DataTable GetOrderMenuList(DateTime usedate)
        {
            VPrePOMenuDAL Menu = new VPrePOMenuDAL();
            return Menu.GetDataListByDate(usedate, "MENUNAME", null);
        }

        public bool InsertData(PrePODivisionData ffData, string UserID)
        {
            bool ret = true;
            zTran trans = new zTran();
            trans.CreateTransaction();

            PrePODAL ffDAL = new PrePODAL();

            ffDAL.BPODATE = ffData.BPODATE;
            ffDAL.USEDATE = ffData.USEDATE;
            ffDAL.STATUS = ffData.STATUS;
            ffDAL.REMARKS = ffData.REMARKS;
            ffDAL.PLANMATERIALCLASS = ffData.PLANMATERIALCLASS;
            ffDAL.CNAME = ffData.CNAME;
            ffDAL.ADDRESS = ffData.ADDRESS;
            ffDAL.TEL = ffData.TEL;
            ffDAL.FAX = ffData.FAX;

            try
            {
                ret = ffDAL.InsertCurrentData(UserID, trans.Trans);
                if (!ret)
                    _error = ffDAL.ErrorMessage;

                if (ret)
                    ret = InsertPrePOItem(ffData.PrePODivisionItem, UserID, ffDAL.LOID,ffData.PLAN,ffData.PrePODuedate, trans.Trans);

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
        public bool UpdateFinishStatus(PrePODivisionData ffData, string UserID)
        {
            bool ret = true;
            zTran trans = new zTran();
            trans.CreateTransaction();

            PrePODAL ffDAL = new PrePODAL();
            ffDAL.GetDataByLOID(ffData.LOID, trans.Trans);
            ffDAL.STATUS = ffData.STATUS;

            PODAL PoDAL = new PODAL();
            PoDAL.ADDRESS = ffData.ADDRESS;
            PoDAL.CNAME = ffData.CNAME;
            PoDAL.REMARKS = ffData.REMARKS;
            PoDAL.ISVAT = "Y";
            PoDAL.PODATE = ffData.USEDATE;
            PoDAL.PREPO = ffData.LOID;
            PoDAL.STATUS = "AP";
            PoDAL.TEL = ffData.TEL;
            PoDAL.FAX = ffData.FAX;
            PoDAL.VATRATE = Convert.ToDouble(GetVat());

            PODAL PoDAL2 = new PODAL();
            PoDAL2.ADDRESS = ffData.ADDRESS;
            PoDAL2.CNAME = ffData.CNAME;
            PoDAL2.REMARKS = ffData.REMARKS;
            PoDAL2.ISVAT = "N";
            PoDAL2.PODATE = ffData.USEDATE;
            PoDAL2.PREPO = ffData.LOID;
            PoDAL2.STATUS = "AP";
            PoDAL2.TEL = ffData.TEL;
            PoDAL2.FAX = ffData.FAX;
            PoDAL2.VATRATE = 0;

            try
            {
                ret = PoDAL.InsertCurrentData(UserID, trans.Trans);
                if (!ret)
                    _error = PoDAL.ErrorMessage;

                if (ret)
                    ret = InsertPOItemVat(ffData.PrePODivisionItem, UserID, PoDAL.LOID, ffData.PLAN, trans.Trans);

                if (ret)
                {
                    ret = PoDAL2.InsertCurrentData(UserID, trans.Trans);
                    if (!ret)
                        _error = PoDAL2.ErrorMessage;

                    if (ret)
                        ret = InsertPOItem(ffData.PrePODivisionItem, UserID, PoDAL2.LOID, ffData.PLAN, trans.Trans);

                }

                if (ret & ffDAL.OnDB)
                {
                    ret = ffDAL.UpdateCurrentData(UserID, trans.Trans);
                    if (!ret)
                        _error = ffDAL.ErrorMessage;
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

        private bool InsertPOItemVat(ArrayList arrPOItem, string userID, double PO, double plan, OracleTransaction trans)
        {
            bool ret = true;
            string materialMasterList = "";
            for (int i = 0; i < arrPOItem.Count; ++i)
            {
                PrePOItemData datPOItem = (PrePOItemData)arrPOItem[i];
                materialMasterList += (materialMasterList == "" ? "" : ",") + "'" + datPOItem.MATERIALMASTER.ToString() + "'";
            }
            PrePOItemDAL PrePOItem = new PrePOItemDAL();
            POITEMDAL POItem = new POITEMDAL();

            for (int i = 0; i < arrPOItem.Count; ++i)
            {
                POItem = new POITEMDAL();
                PrePOItemData datPOItem = (PrePOItemData)arrPOItem[i];
                POItem.QTY = datPOItem.ORDERQTY;
                POItem.MATERIALMASTER = datPOItem.MATERIALMASTER;
                POItem.UNIT = datPOItem.UNIT;
                POItem.PO = PO;
                POItem.PRICE = datPOItem.PRICE;
                POItem.PLANREMAINQTY = datPOItem.PLANREMAINQTY;
                POItem.REMARKS = datPOItem.REMARKS;
                POItem.USEQTY = datPOItem.USEQTY;

                if (datPOItem.ISVAT == "Y")
                    ret = POItem.InsertCurrentData(userID, trans);

                if (!ret)
                {
                    _error = POItem.ErrorMessage;
                    break;
                }
            }
            return ret;
        }

        private bool InsertPOItem(ArrayList arrPOItem, string userID, double PO, double plan, OracleTransaction trans)
        {
            bool ret = true;
            string materialMasterList = "";
            for (int i = 0; i < arrPOItem.Count; ++i)
            {
                PrePOItemData datPOItem = (PrePOItemData)arrPOItem[i];
                materialMasterList += (materialMasterList == "" ? "" : ",") + "'" + datPOItem.MATERIALMASTER.ToString() + "'";
            }
            PrePOItemDAL PrePOItem = new PrePOItemDAL();
            POITEMDAL POItem = new POITEMDAL();

            for (int i = 0; i < arrPOItem.Count; ++i)
            {
                POItem = new POITEMDAL();
                PrePOItemData datPOItem = (PrePOItemData)arrPOItem[i];
                POItem.QTY = datPOItem.ORDERQTY;
                POItem.MATERIALMASTER = datPOItem.MATERIALMASTER;
                POItem.UNIT = datPOItem.UNIT;
                POItem.PO = PO;
                POItem.PRICE = datPOItem.PRICE;
                POItem.PLANREMAINQTY = datPOItem.PLANREMAINQTY;
                POItem.REMARKS = datPOItem.REMARKS;
                POItem.USEQTY = datPOItem.USEQTY;

                if (datPOItem.ISVAT == "N")
                    ret = POItem.InsertCurrentData(userID, trans);

                if (!ret)
                {
                    _error = POItem.ErrorMessage;
                    break;
                }
            }
            return ret;
        }
        public bool UpdateData(PrePODivisionData ffData, string UserID)
        {
            bool ret = true;
            zTran trans = new zTran();
            trans.CreateTransaction();

            PrePODAL ffDAL = new PrePODAL();
            ffDAL.GetDataByLOID(ffData.LOID, trans.Trans);
            ffDAL.BPODATE = ffData.BPODATE;
            ffDAL.USEDATE = ffData.USEDATE;
            ffDAL.STATUS = ffData.STATUS;
            ffDAL.REMARKS = ffData.REMARKS;
            ffDAL.CNAME = ffData.CNAME;
            ffDAL.ADDRESS = ffData.ADDRESS;
            ffDAL.TEL = ffData.TEL;
            ffDAL.FAX = ffData.FAX;
            ffDAL.PLANMATERIALCLASS = ffData.PLANMATERIALCLASS;
            try
            {
                if (ffDAL.OnDB)
                {
                    ret = ffDAL.UpdateCurrentData(UserID, trans.Trans);
                    if (!ret)
                        _error = ffDAL.ErrorMessage;

                    if (ret)
                        ret = UpdatePrePOItem(ffData.PrePODivisionItem, UserID, ffDAL.LOID, ffData.PLAN, ffData.PrePODuedate, trans.Trans);

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
        private bool UpdatePrePOItem(ArrayList arrPrePODivisionItem, string userID, double PrePODivision, double plan, ArrayList arrPrePODuedate, OracleTransaction trans)
        {
            PrePODuedateDAL PrePODuedate = new PrePODuedateDAL();
            //PrePODuedateDAL PrePODuedate = new PrePODuedateDAL();
            //    PrePODuedate.doDelete("PREPOITEM IN (SELECT LOID FROM PREPOITEM WHERE PREPO = " + PrePODivision + ") ", trans);

            bool ret = true;
            PrePOItemDAL PrePOItem = new PrePOItemDAL();

            for (int i = 0; i < arrPrePODivisionItem.Count; ++i)
            {

                PrePOItem = new PrePOItemDAL();
                PrePOItemData datPrePOItem = (PrePOItemData)arrPrePODivisionItem[i];
                PrePOItem.GetDataByUniqueKey(PrePODivision, datPrePOItem.MATERIALMASTER, datPrePOItem.UNIT, trans);
                PrePOItem.MENUQTY = datPrePOItem.MENUQTY;
                PrePOItem.ORDERQTY = datPrePOItem.ORDERQTY;
                PrePOItem.MATERIALMASTER = datPrePOItem.MATERIALMASTER;
                PrePOItem.PRICE = datPrePOItem.PRICE;
                PrePOItem.PLANREMAINQTY = datPrePOItem.PLANREMAINQTY;
                PrePOItem.ISVAT = datPrePOItem.ISVAT;
                PrePOItem.UNIT = datPrePOItem.UNIT;
                PrePOItem.PREPO = PrePODivision;
                PrePOItem.PLANREMAINQTY = datPrePOItem.PLANREMAINQTY;
                PrePOItem.REMARKS = datPrePOItem.REMARKS;
                PrePOItem.USEQTY = PrePOItem.GetUseQty(plan, datPrePOItem.MATERIALMASTER);

                if (!PrePOItem.OnDB)
                    ret = PrePOItem.InsertCurrentData(userID, trans);
                else
                    ret = PrePOItem.UpdateCurrentData(userID, trans);

                if (ret)
                {
                    //if (PrePOItem.ORDERQTY != PrePOItem.OLDORDERQTY)
                        ret = PrePODuedate.InsertDuedate(PrePOItem.LOID, userID, trans);
                    //else
                    //    ret = InsertPrePODuedate(arrPrePODuedate, userID, PrePOItem.LOID, datPrePOItem.CODE, trans);
                }
                else
                {
                    _error = PrePOItem.ErrorMessage;
                    break;
                }
            }
            return ret;
        }

        private bool InsertPrePOItem(ArrayList arrPrePODivisionItem, string userID, double PrePODivision, double plan, ArrayList arrPrePODuedate, OracleTransaction trans)
        {
            PrePODuedateDAL PrePODuedate = new PrePODuedateDAL();
            bool ret = true;
            PrePOItemDAL PrePOItem = new PrePOItemDAL();

            for (int i = 0; i < arrPrePODivisionItem.Count; ++i)
            {
                PrePOItem = new PrePOItemDAL();
                PrePOItemData datPrePOItem = (PrePOItemData)arrPrePODivisionItem[i];
                PrePOItem.GetDataByUniqueKey(PrePODivision, datPrePOItem.MATERIALMASTER, datPrePOItem.UNIT, trans);
                PrePOItem.MENUQTY = datPrePOItem.MENUQTY;
                PrePOItem.ORDERQTY = datPrePOItem.ORDERQTY;
                PrePOItem.MATERIALMASTER = datPrePOItem.MATERIALMASTER;
                PrePOItem.PRICE = datPrePOItem.PRICE;
                PrePOItem.PLANREMAINQTY = datPrePOItem.PLANREMAINQTY;
                PrePOItem.ISVAT = datPrePOItem.ISVAT;
                PrePOItem.UNIT = datPrePOItem.UNIT;
                PrePOItem.PREPO = PrePODivision;
                PrePOItem.PLANREMAINQTY = datPrePOItem.PLANREMAINQTY;
                PrePOItem.REMARKS = datPrePOItem.REMARKS;
                PrePOItem.USEQTY = PrePOItem.GetUseQty(plan, datPrePOItem.MATERIALMASTER);

                if (!PrePOItem.OnDB)
                    ret = PrePOItem.InsertCurrentData(userID, trans);
                else
                    ret = PrePOItem.UpdateCurrentData(userID, trans);

                if (ret)
                    ret = PrePODuedate.InsertDuedate(PrePOItem.LOID, userID, trans);
                else
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
                
                PrePODuedate.GetDataByLOID(datPrePODuedate.LOID, trans);
                if (datPrePODuedate.CODE == Code)
                {
                    PrePODuedate.DUEDATE = datPrePODuedate.DUEDATE;
                    PrePODuedate.DUEQTY = datPrePODuedate.DUEQTY;
                    PrePODuedate.PREPOITEM = PrePODivisionItem;

                    if (PrePODuedate.OnDB)
                        ret = PrePODuedate.UpdateCurrentData(userID, trans);
                    else
                        ret = PrePODuedate.InsertCurrentData(userID, trans);
                }

                if(!ret)
                {
                    _error = PrePODuedate.ErrorMessage;
                    break;
                }
            }
            return ret;
        }

        public bool CheckUniqueKey(double cLOID, double cPLANMATERIALCLASS, DateTime cUSEDATE)
        {
            PrePODAL fDAL = new PrePODAL();
            fDAL.GetDataByUniqueKey(cPLANMATERIALCLASS, cUSEDATE, null);
            return !fDAL.OnDB || (cLOID == fDAL.LOID);
        }

        public string GetVat()
        {
            VPODAL ffDAL = new VPODAL();
            return ffDAL.GetVat();
        }

        #region Work Nang

        public DataTable GetDivisionDataSearch(double planorder, double planmaterialclass, DateTime usedate,double dloid,double mloid, string mname)
        {
            VPrePoDivisionMaterialDAL vDAL = new VPrePoDivisionMaterialDAL();
            return vDAL.GetDataListByConditions(planorder, planmaterialclass, usedate, dloid, mloid, mname, "MATERIALNAME,DIVISIONNAME", null);
        }

        #endregion

    }
}
