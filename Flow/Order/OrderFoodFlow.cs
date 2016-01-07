using System;
using System.Collections;
using System.Collections.Generic;
using System.Data;
using System.Data.OracleClient;
using System.Text;
using SHND.DAL.Order;
using SHND.DAL.Tables;
using SHND.DAL.Views;
using SHND.Data.Order;
using SHND.Data.Tables;
using SHND.Data.Views;
using zTran = SHND.DAL.Utilities.OracleTransactionDB;

/// <summary>
/// OrderFoodFlow Class
/// Version 1.0
/// =========================================================================
/// Create by: Teang
/// Create Date: 10 Mar 2009
/// -------------------------------------------------------------------------
/// Modify By: -
/// Modify From: -
/// Modify Date: -
/// -------------------------------------------------------------------------
/// Remark: -
/// Description:
///    Flow จัดการการทำงานของหน้า OrderFoodSearch และ OrderFoodDetail
/// Changes:
///    1.0 - สร้าง
/// -------------------------------------------------------------------------
/// =========================================================================
/// </summary>
/// 
namespace SHND.Flow.Order
{
    public class OrderFoodFlow
    {
        string _error = "";
        double _LOID = 0;
        public string ErrorMessage { get { return _error; } }
        public double LOID { get { return _LOID; } }

        public DataTable GetDiseaseCategoryList(double refLoid, string refTable)
        {
            if (refTable == "ORDERMILK")
            {
                VOrderMilkItemDAL vDAL = new VOrderMilkItemDAL();
                return vDAL.GetDataListByConditions(refLoid, "DISEASECATEGORYNAME", null);
            }
            else
            {
                VOrderDetailItemDAL vDAL = new VOrderDetailItemDAL();
                return vDAL.GetDataListByConditions(refLoid, refTable, "DISEASECATEGORYNAME", null);
            }
        }

        private bool UpdateOrderMedicalItem(string refTable, double refLOID, string userID, ArrayList arrData, OracleTransaction trans)
        {
            bool ret = true;
            string diseaseCategoryList = "";
            OrderMedicalItemDAL oDAL = new OrderMedicalItemDAL();
            for (int i = 0; i < arrData.Count; ++i)
            {
                VOrderDetailItemData item = (VOrderDetailItemData)arrData[i];
                diseaseCategoryList += (diseaseCategoryList == "" ? "" : ",") + item.DISEASECATEGORY.ToString();
            }
            oDAL.DeleteDataByConditions(refTable, refLOID, diseaseCategoryList, trans);

            for (int i = 0; i < arrData.Count; ++i)
            {
                VOrderDetailItemData item = (VOrderDetailItemData)arrData[i];
                oDAL = new OrderMedicalItemDAL();
                oDAL.GetDataByConditions(refTable, refLOID, item.DISEASECATEGORY, trans);
                oDAL.DISEASECATEGORY = item.DISEASECATEGORY;
                oDAL.QTY = item.QTY;
                oDAL.REFLOID = refLOID;
                oDAL.REFTABLE = refTable;
                oDAL.ISHIGH = (item.ISHIGH ? "Y" : "N");
                oDAL.ISLOW = (item.ISLOW ? "Y" : "N");
                oDAL.ISNON = (item.ISNON ? "Y" : "N");
                oDAL.UNIT = item.UNIT;
                oDAL.INCREASEMEAL = item.MEAL;
                if (oDAL.OnDB)
                    ret = oDAL.UpdateCurrentData(userID, trans);
                else
                    ret = oDAL.InsertCurrentData(userID, trans);

                if (!ret)
                {
                    _error = oDAL.ErrorMessage;
                    break;
                }
            }
            return ret;
        }

        private bool UpdateOrderNonMedicalItem(double orderNonMedicalID, string userID, ArrayList arrData, OracleTransaction trans)
        {
            bool ret = true;
            string diseaseCategoryList = "";
            OrderNonMedicalItemDAL oDAL = new OrderNonMedicalItemDAL();
            for (int i = 0; i < arrData.Count; ++i)
            {
                VOrderDetailItemData item = (VOrderDetailItemData)arrData[i];
                diseaseCategoryList += (diseaseCategoryList == "" ? "" : ",") + item.DISEASECATEGORY.ToString();
            }
            oDAL.DeleteDataByConditions(orderNonMedicalID, diseaseCategoryList, trans);

            for (int i = 0; i < arrData.Count; ++i)
            {
                VOrderDetailItemData item = (VOrderDetailItemData)arrData[i];
                oDAL = new OrderNonMedicalItemDAL();
                oDAL.GetDataByConditions(orderNonMedicalID, item.DISEASECATEGORY, trans);
                oDAL.DISEASECATEGORY = item.DISEASECATEGORY;
                oDAL.QTY = item.QTY;
                oDAL.ORDERNONMEDICALDIET = orderNonMedicalID;
                oDAL.ISHIGH = (item.ISHIGH ? "Y" : "N");
                oDAL.ISLOW = (item.ISLOW ? "Y" : "N");
                oDAL.ISNON = (item.ISNON ? "Y" : "N");
                oDAL.UNIT = item.UNIT;
                //oDAL.INCREASEMEAL = item.MEAL;
                if (oDAL.OnDB)
                    ret = oDAL.UpdateCurrentData(userID, trans);
                else
                    ret = oDAL.InsertCurrentData(userID, trans);

                if (!ret)
                {
                    _error = oDAL.ErrorMessage;
                    break;
                }
            }
            return ret;
        }

        public StdTimeTableData GetStdTimeTable(double mealQty, string useFor)
        {
            StdTimeTableData sData = new StdTimeTableData();
            StdTimeTableDAL sDAL = new StdTimeTableDAL();
            sDAL.GetDataByConditions(mealQty, useFor, null);
            sData.LOID = sDAL.LOID;
            sData.MEALQTY = sDAL.MEALQTY;
            sData.TIME1 = (sDAL.TIME1 == "Y");
            sData.TIME2 = (sDAL.TIME2 == "Y");
            sData.TIME3 = (sDAL.TIME3 == "Y");
            sData.TIME4 = (sDAL.TIME4 == "Y");
            sData.TIME5 = (sDAL.TIME5 == "Y");
            sData.TIME6 = (sDAL.TIME6 == "Y");
            sData.TIME7 = (sDAL.TIME7 == "Y");
            sData.TIME8 = (sDAL.TIME8 == "Y");
            sData.TIME9 = (sDAL.TIME9 == "Y");
            sData.TIME10 = (sDAL.TIME10 == "Y");
            sData.TIME11 = (sDAL.TIME11 == "Y");
            sData.TIME12 = (sDAL.TIME12 == "Y");
            sData.TIME13 = (sDAL.TIME13 == "Y");
            sData.TIME14 = (sDAL.TIME14 == "Y");
            sData.TIME15 = (sDAL.TIME15 == "Y");
            sData.TIME16 = (sDAL.TIME16 == "Y");
            sData.TIME17 = (sDAL.TIME17 == "Y");
            sData.TIME18 = (sDAL.TIME18 == "Y");
            sData.TIME19 = (sDAL.TIME19 == "Y");
            sData.TIME20 = (sDAL.TIME20 == "Y");
            sData.TIME21 = (sDAL.TIME21 == "Y");
            sData.TIME22 = (sDAL.TIME22 == "Y");
            sData.TIME23 = (sDAL.TIME23 == "Y");
            sData.TIME24 = (sDAL.TIME24 == "Y");
            sData.USEFOR = sDAL.USEFOR;
            return sData;
        }

        public bool HasNPOOrder(double orderMedicalSetID, double admitPatient, OracleTransaction trans)
        {
            bool ret = false;
            OrderMedicalSetDAL sDAL = new OrderMedicalSetDAL();
            ret = sDAL.HasNPOOrder(orderMedicalSetID, admitPatient, trans);
            if (ret) _error = "กรุณายกเลิกการงดอาหารก่อนทำรายการ";
            return ret;
        }
        public bool CheckANWard(double ward, double admitPatient, OracleTransaction trans)
        {
            bool ret = false;
            VOrderDetailDAL sDAL = new VOrderDetailDAL();
            ret = sDAL.CheckANWard(ward, admitPatient, trans);
            if (ret) _error = "บันทึกข้อมูลเรียบร้อย และพบข้อมูลการสั่งอาหารจากหอผู้ป่วย" + sDAL.ward;
            return ret;
        }

        #region OrderFoodDetail

        public DataTable GetMasterList(double ward, string wardName, DateTime admitDateFrom, DateTime admitDateTo, string HN, string AN, string patientName, bool isAdmitOnly, string statusFrom, string statusTo, double officerID, string officerGroup, string orderBy)
        {
            VOrderPatientDAL vDAL = new VOrderPatientDAL();
            return vDAL.GetDataListByConditions(DateTime.Today, ward, wardName, admitDateFrom, admitDateTo, HN, AN, patientName, statusFrom, statusTo, (isAdmitOnly ? "PATIENTSTATUS = 'AD'" : ""), officerID, officerGroup, orderBy, null);
        }
        public string GetLiquidCategory()
        {
            VOrderPatientDAL vDAL = new VOrderPatientDAL();
            return vDAL.GetLiquidCategory();
        }

        public CutOffTimeData GetCutOffTime(string usefor)
        {
            CutOffTimeDAL cDAL = new CutOffTimeDAL();
            return cDAL.GetCutOffTime(usefor);
        }

        public string GetCutOffTimeFM(string usefor,string time)
        {
            StdDeliveryTimeDAL cDAL = new StdDeliveryTimeDAL();
            return cDAL.GetCutOffTime(usefor,time);
        }

        public string GetMeal(string usefor, string time)
        {
            StdDeliveryTimeDAL cDAL = new StdDeliveryTimeDAL();
            return cDAL.GetMeal(usefor, time);
        }

        public string GetIsLock(double ward)
        {
            WardDAL wDAL = new WardDAL();
            return wDAL.GetIsLock(ward);
        }

        public VOrderPatientData GetDetail(double admitPatientID)
        {
            VOrderPatientData pData = new VOrderPatientData();
            VOrderPatientDAL pDAL = new VOrderPatientDAL();
            pDAL.GetDataByLOID(DateTime.Today, admitPatientID, null);
            pData.ADMITDATE = pDAL.ADMITDATE;
            pData.AGE = pDAL.AGE;
            pData.AN = pDAL.AN;
            pData.BEDNO = pDAL.BEDNO;
            pData.BIRTHDATE = pDAL.BIRTHDATE;
            pData.DIAGNOSIS = pDAL.DIAGNOSIS;
            pData.DRUGALLERGIC = pDAL.DRUGALLERGIC;
            pData.FOODALLERGIC = pDAL.FOODALLERGIC;
            pData.HEIGHT = pDAL.HEIGHT;
            pData.HN = pDAL.HN;
            pData.LOID = pDAL.LOID;
            pData.PATIENTNAME = pDAL.PATIENTNAME;
            pData.PATIENTSTATUS = pDAL.PATIENTSTATUS;
            pData.REMARK = pDAL.REMARK;
            pData.ROOMNO = pDAL.ROOMNO;
            pData.STATUSNAME = pDAL.STATUSNAME;
            pData.STATUSRANK = pDAL.STATUSRANK;
            pData.TITLE = pDAL.TITLE;
            pData.TITLENAME = pDAL.TITLENAME;
            pData.VN = pDAL.VN;
            pData.WARD = pDAL.WARD;
            pData.WARDNAME = pDAL.WARDNAME;
            pData.WEIGHT = pDAL.WEIGHT;
            pData.DEFAULTFOODTYPE = pDAL.DEFAULTFOODTYPE;
            VOrderDetailDAL vDAL = new VOrderDetailDAL();
            pData.OrderDetail = vDAL.GetDataListByConditions(pDAL.LOID, "TO_DATE(FIRSTDATE) DESC, ISDOCTORORDER DESC", null);
            return pData;
        }

        #endregion

        #region OrderMedical

        public bool DeleteOrderMedicalSet(double ID)
        {
            bool ret = true;
            zTran trans = new zTran();
            trans.CreateTransaction();
            try
            {
                OrderMedicalItemDAL itemDAL = new OrderMedicalItemDAL();
                OrderMedicalSetDAL oDAL = new OrderMedicalSetDAL();
                itemDAL.DeleteDataByConditions(oDAL.TableName, ID, "", trans.Trans);
                ret = oDAL.DeleteDataByLOID(ID, trans.Trans);
                if (!ret)
                    _error = oDAL.ErrorMessage;

                if (ret)
                    trans.CommitTransaction();
                else
                    trans.RollbackTransaction();

                _LOID = oDAL.LOID;
            }
            catch (Exception ex)
            {
                _error = ex.Message;
                ret = false;
                trans.RollbackTransaction();
            }
            return ret;
        }

        public bool DiscontinueOrderMedicalSet(double ID, string userID, DateTime endDate, string endMeal)
        {
            bool ret = true;
            zTran trans = new zTran();
            trans.CreateTransaction();
            try
            {
                OrderMedicalSetDAL oDAL = new OrderMedicalSetDAL();
                oDAL.GetDataByLOID(ID, trans.Trans);
                oDAL.ISREGISTER = "N";
                oDAL.STATUS = "DC";
                oDAL.ENDDATE = endDate;
                oDAL.ENDMEAL = endMeal;
                if (oDAL.OnDB)
                {
                    ret = oDAL.UpdateCurrentData(userID, trans.Trans);
                    if (!ret)
                        _error = oDAL.ErrorMessage;
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

                _LOID = oDAL.LOID;
            }
            catch (Exception ex)
            {
                _error = ex.Message;
                ret = false;
                trans.RollbackTransaction();
            }
            return ret;
        }

        private bool Discontinue(double ordermedicalSetID, double admitPatient, DateTime firstDate, DateTime endDate, OracleTransaction trans)
        {
            bool ret = true;
            OrderMedicalSetDAL setDAL = new OrderMedicalSetDAL();
            ret = setDAL.Discontinue(ordermedicalSetID, admitPatient, firstDate, endDate, trans);
            if (ret)
            {
                OrderMedicalFeedDAL feedDAL = new OrderMedicalFeedDAL();
                ret = feedDAL.Discontinue(admitPatient, firstDate, endDate, trans);
                if (ret)
                {
                    OrderMilkDAL milkDAL = new OrderMilkDAL();
                    ret = milkDAL.Discontinue(admitPatient, firstDate, endDate, trans);
                    if (ret)
                    {
                        OrderNonMedicalDAL nonMedDAL = new OrderNonMedicalDAL();
                        ret = nonMedDAL.Discontinue(admitPatient, firstDate, endDate, trans);
                        if (!ret) _error = nonMedDAL.ErrorMessage;
                    }
                    else
                        _error = milkDAL.ErrorMessage;
                }
                else
                    _error = feedDAL.ErrorMessage;
            }
            else
                _error = setDAL.ErrorMessage;
            return ret;
        }

        public bool UpdateOrderMedicalSet(OrderMedicalSetData oData, string userID)
        {
            bool ret = true;
            zTran trans = new zTran();
            trans.CreateTransaction();
            try
            {
                OrderMedicalSetDAL oDAL = new OrderMedicalSetDAL();
                oDAL.GetDataByLOID(oData.LOID, trans.Trans);
                oDAL.ADMITPATIENT = oData.ADMITPATIENT;
                oDAL.BREAKFAST = (oData.BREAKFAST ? 1 : 0);
                oDAL.DINNER = (oData.DINNER ? 1 : 0);
                oDAL.DOCTOR = oData.DOCTOR;
                oDAL.ENDDATE = oData.ENDDATE;
                oDAL.ENDMEAL = oData.ENDMEAL;
                oDAL.FIRSTDATE = oData.FIRSTDATE;
                oDAL.FIRSTMEAL = oData.FIRSTMEAL;
                oDAL.FOODCATEGORY = oData.FOODCATEGORY;
                oDAL.ISCALCULATE = (oData.ISCALCULATE ? "Y" : "N");
                oDAL.ISINCREASE = (oData.ISINCREASE ? "Y" : "N");
                oDAL.ISLIMIT = (oData.ISLIMIT ? "Y" : "N");
                oDAL.ISNPO = (oData.ISNPO ? "Y" : "N");
                oDAL.ISSPECIFIC = (oData.ISSPECIFIC ? "Y" : "N");
                oDAL.LUNCH = (oData.LUNCH ? 1 : 0);
                oDAL.NPOPERIOD = oData.NPOPERIOD;
                oDAL.NPOSTART = oData.NPOSTART;
                oDAL.REMARKS = oData.REMARKS;
                oDAL.STATUS = oData.STATUS;

                if (oDAL.OnDB)
                {
                    ret = oDAL.UpdateCurrentData(userID, trans.Trans);
                    if (!ret)
                        _error = oDAL.ErrorMessage;
                    else
                    {
                        ret = UpdateOrderMedicalItem(oDAL.TableName, oDAL.LOID, userID, oData.ORDERITEMLIST, trans.Trans);
                        if (oDAL.ISNPO == "Y" && ret) ret = Discontinue(oDAL.LOID, oDAL.ADMITPATIENT, oDAL.FIRSTDATE, oDAL.ENDDATE, trans.Trans);
                    }
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

                _LOID = oDAL.LOID;
            }
            catch (Exception ex)
            {
                _error = ex.Message;
                ret = false;
                trans.RollbackTransaction();
            }
            return ret;
        }

        public bool InsertOrderMedicalSet(OrderMedicalSetData oData, string userID)
        {
            bool ret = true;
            zTran trans = new zTran();
            trans.CreateTransaction();
            try
            {
                OrderMedicalSetDAL oDAL = new OrderMedicalSetDAL();
                oDAL.ADMITPATIENT = oData.ADMITPATIENT;
                oDAL.BREAKFAST = (oData.BREAKFAST ? 1 : 0);
                oDAL.DINNER = (oData.DINNER ? 1 : 0);
                oDAL.DOCTOR = oData.DOCTOR;
                oDAL.ENDDATE = oData.ENDDATE;
                oDAL.ENDMEAL = oData.ENDMEAL;
                oDAL.FIRSTDATE = oData.FIRSTDATE;
                oDAL.FIRSTMEAL = oData.FIRSTMEAL;
                oDAL.FOODCATEGORY = oData.FOODCATEGORY;
                oDAL.ISCALCULATE = (oData.ISCALCULATE ? "Y" : "N");
                oDAL.ISINCREASE = (oData.ISINCREASE ? "Y" : "N");
                oDAL.ISLIMIT = (oData.ISLIMIT ? "Y" : "N");
                oDAL.ISNPO = (oData.ISNPO ? "Y" : "N");
                oDAL.ISREGISTER = "N";
                oDAL.ISSPECIFIC = (oData.ISSPECIFIC ? "Y" : "N");
                oDAL.LUNCH = (oData.LUNCH ? 1 : 0);
                oDAL.NPOPERIOD = oData.NPOPERIOD;
                oDAL.NPOSTART = oData.NPOSTART;
                oDAL.ORDERDATE = DateTime.Now;
                oDAL.REMARKS = oData.REMARKS;
                oDAL.STATUS = oData.STATUS;

                ret = oDAL.InsertCurrentData(userID, trans.Trans);
                if (!ret)
                    _error = oDAL.ErrorMessage;
                else
                {
                    ret = UpdateOrderMedicalItem(oDAL.TableName, oDAL.LOID, userID, oData.ORDERITEMLIST, trans.Trans);
                    if (oDAL.ISNPO == "Y" && ret) ret = Discontinue(oDAL.LOID, oDAL.ADMITPATIENT, oDAL.FIRSTDATE, oDAL.ENDDATE, trans.Trans);
                }

                if (ret)
                    trans.CommitTransaction();
                else
                    trans.RollbackTransaction();

                _LOID = oDAL.LOID;
            }
            catch (Exception ex)
            {
                _error = ex.Message;
                ret = false;
                trans.RollbackTransaction();
            }
            return ret;
        }

        public OrderMedicalSetData GetOrderMedicalSet(double ID)
        {
            OrderMedicalSetData oData = new OrderMedicalSetData();
            OrderMedicalSetDAL oDAL = new OrderMedicalSetDAL();
            oDAL.GetDataByLOID(ID, null);
            oData.ADMITPATIENT = oDAL.ADMITPATIENT;
            oData.BREAKFAST = (oDAL.BREAKFAST == 1 || ID == 0);
            oData.DINNER = (oDAL.DINNER == 1 || ID == 0);
            oData.DOCTOR = oDAL.DOCTOR;
            oData.ENDDATE = oDAL.ENDDATE;
            oData.ENDMEAL = oDAL.ENDMEAL;
            oData.FIRSTDATE = oDAL.FIRSTDATE;
            oData.FIRSTDATEREGIS = oDAL.FIRSTDATEREGIS;
            oData.FIRSTMEAL = oDAL.FIRSTMEAL;
            oData.FIRSTMEALREGIS = oDAL.FIRSTMEALREGIS;
            oData.FOODCATEGORY = oDAL.FOODCATEGORY;
            oData.ISCALCULATE = (oDAL.ISCALCULATE == "Y");
            oData.ISINCREASE = (oDAL.ISINCREASE == "Y");
            oData.ISLIMIT = (oDAL.ISLIMIT == "Y");
            oData.ISNPO = (oDAL.ISNPO == "Y");
            oData.ISREGISTER = (oDAL.ISREGISTER == "Y");
            oData.ISSPECIFIC = (oDAL.ISSPECIFIC == "Y");
            oData.LOID = oDAL.LOID;
            oData.LUNCH = (oDAL.LUNCH == 1 || ID == 0);
            oData.NPOPERIOD = oDAL.NPOPERIOD;
            oData.NPOSTART = oDAL.NPOSTART;
            oData.ORDERDATE = oDAL.ORDERDATE;
            oData.REGISTERDATE = oDAL.REGISTERDATE;
            oData.REMARKS = oDAL.REMARKS;
            oData.STATUS = oDAL.STATUS;
            oData.UNREGISREASON = oDAL.UNREGISREASON;
            return oData;
        }

        #endregion

        #region OrderFeed

        public bool DeleteOrderMedicalFeed(double ID)
        {
            bool ret = true;
            zTran trans = new zTran();
            trans.CreateTransaction();
            try
            {
                OrderMedicalItemDAL itemDAL = new OrderMedicalItemDAL();
                OrderMedicalFeedDAL oDAL = new OrderMedicalFeedDAL();
                itemDAL.DeleteDataByConditions(oDAL.TableName, ID, "", trans.Trans);
                ret = oDAL.DeleteDataByLOID(ID, trans.Trans);
                if (!ret)
                    _error = oDAL.ErrorMessage;

                if (ret)
                    trans.CommitTransaction();
                else
                    trans.RollbackTransaction();

                _LOID = oDAL.LOID;
            }
            catch (Exception ex)
            {
                _error = ex.Message;
                ret = false;
                trans.RollbackTransaction();
            }
            return ret;
        }

        public bool DiscontinueOrderMedicalFeed(double ID, string userID, DateTime endDate, string endTime)
        {
            bool ret = true;
            zTran trans = new zTran();
            trans.CreateTransaction();
            try
            {
                OrderMedicalFeedDAL oDAL = new OrderMedicalFeedDAL();
                oDAL.GetDataByLOID(ID, trans.Trans);
                oDAL.ISREGISTER = "N";
                oDAL.STATUS = "DC";
                oDAL.ENDDATE = endDate;
                oDAL.ENDTIME = endTime;
                if (oDAL.OnDB)
                {
                    ret = oDAL.UpdateCurrentData(userID, trans.Trans);
                    if (!ret)
                        _error = oDAL.ErrorMessage;
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

                _LOID = oDAL.LOID;
            }
            catch (Exception ex)
            {
                _error = ex.Message;
                ret = false;
                trans.RollbackTransaction();
            }
            return ret;
        }

        public bool UpdateOrderMedicalFeed(OrderMedicalFeedData oData, string userID)
        {
            bool ret = true;
            zTran trans = new zTran();
            trans.CreateTransaction();
            try
            {
                OrderMedicalFeedDAL oDAL = new OrderMedicalFeedDAL();
                oDAL.GetDataByLOID(oData.LOID, trans.Trans);
                oDAL.ADMITPATIENT = oData.ADMITPATIENT;
                oDAL.CAPACITY = oData.CAPACITY;
                oDAL.CAPACITYRATE = oData.CAPACITYRATE;
                oDAL.EATMETHOD = oData.EATMETHOD;
                oDAL.ENDDATE = oData.ENDDATE;
                oDAL.ENDTIME = oData.ENDTIME;
                oDAL.ENERGY = oData.ENERGY;
                oDAL.ENERGYRATE = oData.ENERGYRATE;
                oDAL.FEEDCATEGORY = oData.FEEDCATEGORY;
                oDAL.FIRSTDATE = oData.FIRSTDATE;
                oDAL.FIRSTTIME = oData.FIRSTTIME;
                oDAL.FORMULAFEED = oData.FORMULAFEED;
                oDAL.ISCALCULATE = (oData.ISCALCULATE ? "Y" : "N");
                oDAL.ISINCREASE = (oData.ISINCREASE ? "Y" : "N");
                oDAL.ISLIMIT = (oData.ISLIMIT ? "Y" : "N");
                oDAL.ISSPECIFIC = (oData.ISSPECIFIC ? "Y" : "N");
                oDAL.MATERIALMASTER = oData.MATERIALMASTER;
                oDAL.ORDERBY = oData.ORDERBY;
                //oDAL.ORDERDATE = DateTime.Now;
                oDAL.REMARKS = oData.REMARKS;
                oDAL.STATUS = oData.STATUS;
                oDAL.TIME1 = (oData.TIME1 ? "Y" : "N");
                oDAL.TIME2 = (oData.TIME2 ? "Y" : "N");
                oDAL.TIME3 = (oData.TIME3 ? "Y" : "N");
                oDAL.TIME4 = (oData.TIME4 ? "Y" : "N");
                oDAL.TIME5 = (oData.TIME5 ? "Y" : "N");
                oDAL.TIME6 = (oData.TIME6 ? "Y" : "N");
                oDAL.TIME7 = (oData.TIME7 ? "Y" : "N");
                oDAL.TIME8 = (oData.TIME8 ? "Y" : "N");
                oDAL.TIME9 = (oData.TIME9 ? "Y" : "N");
                oDAL.TIME10 = (oData.TIME10 ? "Y" : "N");
                oDAL.TIME11 = (oData.TIME11 ? "Y" : "N");
                oDAL.TIME12 = (oData.TIME12 ? "Y" : "N");
                oDAL.TIME13 = (oData.TIME13 ? "Y" : "N");
                oDAL.TIME14 = (oData.TIME14 ? "Y" : "N");
                oDAL.TIME15 = (oData.TIME15 ? "Y" : "N");
                oDAL.TIME16 = (oData.TIME16 ? "Y" : "N");
                oDAL.TIME17 = (oData.TIME17 ? "Y" : "N");
                oDAL.TIME18 = (oData.TIME18 ? "Y" : "N");
                oDAL.TIME19 = (oData.TIME19 ? "Y" : "N");
                oDAL.TIME20 = (oData.TIME20 ? "Y" : "N");
                oDAL.TIME21 = (oData.TIME21 ? "Y" : "N");
                oDAL.TIME22 = (oData.TIME22 ? "Y" : "N");
                oDAL.TIME23 = (oData.TIME23 ? "Y" : "N");
                oDAL.TIME24 = (oData.TIME24 ? "Y" : "N");
                oDAL.REQTYPE = oData.REQTYPE;

                if (oDAL.OnDB)
                {
                    ret = oDAL.UpdateCurrentData(userID, trans.Trans);
                    if (!ret)
                        _error = oDAL.ErrorMessage;
                    else
                        ret = UpdateOrderMedicalItem(oDAL.TableName, oDAL.LOID, userID, oData.ORDERITEMLIST, trans.Trans);
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

                _LOID = oDAL.LOID;
            }
            catch (Exception ex)
            {
                _error = ex.Message;
                ret = false;
                trans.RollbackTransaction();
            }
            return ret;
        }

        public bool InsertOrderMedicalFeed(OrderMedicalFeedData oData, string userID)
        {
            bool ret = true;
            zTran trans = new zTran();
            trans.CreateTransaction();
            try
            {
                OrderMedicalFeedDAL oDAL = new OrderMedicalFeedDAL();
                oDAL.ADMITPATIENT = oData.ADMITPATIENT;
                oDAL.CAPACITY = oData.CAPACITY;
                oDAL.CAPACITYRATE = oData.CAPACITYRATE;
                oDAL.EATMETHOD = oData.EATMETHOD;
                oDAL.ENDDATE = oData.ENDDATE;
                oDAL.ENDTIME = oData.ENDTIME;
                oDAL.ENERGY = oData.ENERGY;
                oDAL.ENERGYRATE = oData.ENERGYRATE;
                oDAL.FEEDCATEGORY = oData.FEEDCATEGORY;
                oDAL.FIRSTDATE = oData.FIRSTDATE;
                oDAL.FIRSTTIME = oData.FIRSTTIME;
                oDAL.FORMULAFEED = oData.FORMULAFEED;
                oDAL.ISCALCULATE = (oData.ISCALCULATE ? "Y" : "N");
                oDAL.ISLIMIT = (oData.ISLIMIT ? "Y" : "N");
                oDAL.ISINCREASE = (oData.ISINCREASE ? "Y" : "N");
                oDAL.ISREGISTER = "N";
                oDAL.ISSPECIFIC = (oData.ISSPECIFIC ? "Y" : "N");
                oDAL.MATERIALMASTER = oData.MATERIALMASTER;
                oDAL.ORDERBY = oData.ORDERBY;
                oDAL.ORDERDATE = DateTime.Now;
                oDAL.REMARKS = oData.REMARKS;
                oDAL.STATUS = oData.STATUS;
                oDAL.TIME1 = (oData.TIME1 ? "Y" : "N");
                oDAL.TIME2 = (oData.TIME2 ? "Y" : "N");
                oDAL.TIME3 = (oData.TIME3 ? "Y" : "N");
                oDAL.TIME4 = (oData.TIME4 ? "Y" : "N");
                oDAL.TIME5 = (oData.TIME5 ? "Y" : "N");
                oDAL.TIME6 = (oData.TIME6 ? "Y" : "N");
                oDAL.TIME7 = (oData.TIME7 ? "Y" : "N");
                oDAL.TIME8 = (oData.TIME8 ? "Y" : "N");
                oDAL.TIME9 = (oData.TIME9 ? "Y" : "N");
                oDAL.TIME10 = (oData.TIME10 ? "Y" : "N");
                oDAL.TIME11 = (oData.TIME11 ? "Y" : "N");
                oDAL.TIME12 = (oData.TIME12 ? "Y" : "N");
                oDAL.TIME13 = (oData.TIME13 ? "Y" : "N");
                oDAL.TIME14 = (oData.TIME14 ? "Y" : "N");
                oDAL.TIME15 = (oData.TIME15 ? "Y" : "N");
                oDAL.TIME16 = (oData.TIME16 ? "Y" : "N");
                oDAL.TIME17 = (oData.TIME17 ? "Y" : "N");
                oDAL.TIME18 = (oData.TIME18 ? "Y" : "N");
                oDAL.TIME19 = (oData.TIME19 ? "Y" : "N");
                oDAL.TIME20 = (oData.TIME20 ? "Y" : "N");
                oDAL.TIME21 = (oData.TIME21 ? "Y" : "N");
                oDAL.TIME22 = (oData.TIME22 ? "Y" : "N");
                oDAL.TIME23 = (oData.TIME23 ? "Y" : "N");
                oDAL.TIME24 = (oData.TIME24 ? "Y" : "N");
                oDAL.REQTYPE = oData.REQTYPE;

                ret = oDAL.InsertCurrentData(userID, trans.Trans);
                if (!ret)
                    _error = oDAL.ErrorMessage;
                else
                    ret = UpdateOrderMedicalItem(oDAL.TableName, oDAL.LOID, userID, oData.ORDERITEMLIST, trans.Trans);

                if (ret)
                    trans.CommitTransaction();
                else
                    trans.RollbackTransaction();

                _LOID = oDAL.LOID;
            }
            catch (Exception ex)
            {
                _error = ex.Message;
                ret = false;
                trans.RollbackTransaction();
            }
            return ret;
        }

        public OrderMedicalFeedData GetOrderMedicalFeed(double ID)
        {
            OrderMedicalFeedData oData = new OrderMedicalFeedData();
            OrderMedicalFeedDAL oDAL = new OrderMedicalFeedDAL();
            oDAL.GetDataByLOID(ID, null);
            oData.ADMITPATIENT = oDAL.ADMITPATIENT;
            oData.CAPACITY = oDAL.CAPACITY;
            oData.CAPACITYRATE = oDAL.CAPACITYRATE;
            oData.EATMETHOD = oDAL.EATMETHOD;
            oData.ENDDATE = oDAL.ENDDATE;
            oData.ENDTIME = oDAL.ENDTIME;
            oData.ENERGY = oDAL.ENERGY;
            oData.ENERGYRATE = oDAL.ENERGYRATE;
            oData.FEEDCATEGORY = oDAL.FEEDCATEGORY;
            oData.FIRSTDATE = oDAL.FIRSTDATE;
            oData.FIRSTDATEREGIS = oDAL.FIRSTDATEREGIS;
            oData.FIRSTMEALREGIS = oDAL.FIRSTMEALREGIS;
            oData.FIRSTTIME = oDAL.FIRSTTIME;
            oData.FORMULAFEED = oDAL.FORMULAFEED;
            oData.ISCALCULATE = (oDAL.ISCALCULATE == "Y");
            oData.ISINCREASE = (oDAL.ISINCREASE == "Y");
            oData.ISREGISTER = (oDAL.ISREGISTER == "Y");
            oData.ISSPECIFIC = (oDAL.ISSPECIFIC == "Y");
            oData.ISLIMIT = (oDAL.ISLIMIT == "Y");
            oData.LOID = oDAL.LOID;
            oData.MATERIALMASTER = oDAL.MATERIALMASTER;
            oData.ORDERBY = oDAL.ORDERBY;
            oData.ORDERDATE = oDAL.ORDERDATE;
            oData.REGISTERDATE = oDAL.REGISTERDATE;
            oData.REMARKS = oDAL.REMARKS;
            oData.STATUS = oDAL.STATUS;
            oData.TIME1 = (oDAL.TIME1 == "Y");
            oData.TIME2 = (oDAL.TIME2 == "Y");
            oData.TIME3 = (oDAL.TIME3 == "Y");
            oData.TIME4 = (oDAL.TIME4 == "Y");
            oData.TIME5 = (oDAL.TIME5 == "Y");
            oData.TIME6 = (oDAL.TIME6 == "Y");
            oData.TIME7 = (oDAL.TIME7 == "Y");
            oData.TIME8 = (oDAL.TIME8 == "Y");
            oData.TIME9 = (oDAL.TIME9 == "Y");
            oData.TIME10 = (oDAL.TIME10 == "Y");
            oData.TIME11 = (oDAL.TIME11 == "Y");
            oData.TIME12 = (oDAL.TIME12 == "Y");
            oData.TIME13 = (oDAL.TIME13 == "Y");
            oData.TIME14 = (oDAL.TIME14 == "Y");
            oData.TIME15 = (oDAL.TIME15 == "Y");
            oData.TIME16 = (oDAL.TIME16 == "Y");
            oData.TIME17 = (oDAL.TIME17 == "Y");
            oData.TIME18 = (oDAL.TIME18 == "Y");
            oData.TIME19 = (oDAL.TIME19 == "Y");
            oData.TIME20 = (oDAL.TIME20 == "Y");
            oData.TIME21 = (oDAL.TIME21 == "Y");
            oData.TIME22 = (oDAL.TIME22 == "Y");
            oData.TIME23 = (oDAL.TIME23 == "Y");
            oData.TIME24 = (oDAL.TIME24 == "Y");
            oData.UNREGISREASON = oDAL.UNREGISREASON;
            oData.REQTYPE = oDAL.REQTYPE;
            return oData;
        }

        #endregion

        #region OrderMilk

        public bool DeleteOrderMilk(double ID)
        {
            bool ret = true;
            zTran trans = new zTran();
            trans.CreateTransaction();
            try
            {
                OrderMedicalItemDAL itemDAL = new OrderMedicalItemDAL();
                OrderMilkDAL oDAL = new OrderMilkDAL();
                itemDAL.DeleteDataByConditions(oDAL.TableName, ID, "", trans.Trans);
                ret = oDAL.DeleteDataByLOID(ID, trans.Trans);
                if (!ret)
                    _error = oDAL.ErrorMessage;

                if (ret)
                    trans.CommitTransaction();
                else
                    trans.RollbackTransaction();

                _LOID = oDAL.LOID;
            }
            catch (Exception ex)
            {
                _error = ex.Message;
                ret = false;
                trans.RollbackTransaction();
            }
            return ret;
        }

        public bool DiscontinueOrderMilk(double ID, string userID, DateTime endDate, string endTime)
        {
            bool ret = true;
            zTran trans = new zTran();
            trans.CreateTransaction();
            try
            {
                OrderMilkDAL oDAL = new OrderMilkDAL();
                oDAL.GetDataByLOID(ID, trans.Trans);
                oDAL.ISREGISTER = "N";
                oDAL.STATUS = "DC";
                oDAL.ENDDATE = endDate;
                oDAL.ENDTIME = endTime;
                if (oDAL.OnDB)
                {
                    ret = oDAL.UpdateCurrentData(userID, trans.Trans);
                    if (!ret)
                        _error = oDAL.ErrorMessage;
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

                _LOID = oDAL.LOID;
            }
            catch (Exception ex)
            {
                _error = ex.Message;
                ret = false;
                trans.RollbackTransaction();
            }
            return ret;
        }

        public bool UpdateOrderMilk(OrderMilkData oData, string userID)
        {
            bool ret = true;
            zTran trans = new zTran();
            trans.CreateTransaction();
            try
            {
                OrderMilkDAL oDAL = new OrderMilkDAL();
                AdmitPatientDAL aDAL = new AdmitPatientDAL();
                oDAL.GetDataByLOID(oData.LOID, trans.Trans);
                oDAL.ADMITPATIENT = oData.ADMITPATIENT;
                oDAL.ENDDATE = oData.ENDDATE;
                oDAL.ENDTIME = oData.ENDTIME;
                oDAL.ENERGY = oData.ENERGY;
                oDAL.FIRSTDATE = oData.FIRSTDATE;
                oDAL.FIRSTTIME = oData.FIRSTTIME;
                oDAL.ISINCREASE = (oData.ISINCREASE ? "Y" : "N");
                oDAL.ISSPIN = (oData.ISSPIN ? "Y" : "N");
                oDAL.MEALQTY = oData.MEALQTY;
                oDAL.MILKCATEGORY = oData.MILKCATEGORY;
                oDAL.ORDERBY = oData.ORDERBY;
                oDAL.OWNER = oData.OWNER;
                oDAL.OWNERTEXT = oData.OWNERTEXT;
                oDAL.REMARKS = oData.REMARKS;
                oDAL.STATUS = oData.STATUS;
                oDAL.TIME1 = (oData.TIME1 ? "Y" : "N");
                oDAL.TIME2 = (oData.TIME2 ? "Y" : "N");
                oDAL.TIME3 = (oData.TIME3 ? "Y" : "N");
                oDAL.TIME4 = (oData.TIME4 ? "Y" : "N");
                oDAL.TIME5 = (oData.TIME5 ? "Y" : "N");
                oDAL.TIME6 = (oData.TIME6 ? "Y" : "N");
                oDAL.TIME7 = (oData.TIME7 ? "Y" : "N");
                oDAL.TIME8 = (oData.TIME8 ? "Y" : "N");
                oDAL.TIME9 = (oData.TIME9 ? "Y" : "N");
                oDAL.TIME10 = (oData.TIME10 ? "Y" : "N");
                oDAL.TIME11 = (oData.TIME11 ? "Y" : "N");
                oDAL.TIME12 = (oData.TIME12 ? "Y" : "N");
                oDAL.TIME13 = (oData.TIME13 ? "Y" : "N");
                oDAL.TIME14 = (oData.TIME14 ? "Y" : "N");
                oDAL.TIME15 = (oData.TIME15 ? "Y" : "N");
                oDAL.TIME16 = (oData.TIME16 ? "Y" : "N");
                oDAL.TIME17 = (oData.TIME17 ? "Y" : "N");
                oDAL.TIME18 = (oData.TIME18 ? "Y" : "N");
                oDAL.TIME19 = (oData.TIME19 ? "Y" : "N");
                oDAL.TIME20 = (oData.TIME20 ? "Y" : "N");
                oDAL.TIME21 = (oData.TIME21 ? "Y" : "N");
                oDAL.TIME22 = (oData.TIME22 ? "Y" : "N");
                oDAL.TIME23 = (oData.TIME23 ? "Y" : "N");
                oDAL.TIME24 = (oData.TIME24 ? "Y" : "N");
                oDAL.VOLUMN = oData.VOLUMN;
                aDAL.GetDataByLOID(oData.ADMITPATIENT, trans.Trans);
                aDAL.WEIGHT = oData.WEIGHT;

                if (oDAL.OnDB)
                {
                    ret = oDAL.UpdateCurrentData(userID, trans.Trans);
                    if (!ret)
                        _error = oDAL.ErrorMessage;
                    else
                        ret = UpdateOrderMedicalItem(oDAL.TableName, oDAL.LOID, userID, oData.ORDERITEMLIST, trans.Trans);
                    if (ret)
                        ret = aDAL.UpdateCurrentData(userID, trans.Trans);
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

                _LOID = oDAL.LOID;
            }
            catch (Exception ex)
            {
                _error = ex.Message;
                ret = false;
                trans.RollbackTransaction();
            }
            return ret;
        }

        public bool InsertOrderMilk(OrderMilkData oData, string userID)
        {
            bool ret = true;
            zTran trans = new zTran();
            trans.CreateTransaction();
            try
            {
                OrderMilkDAL oDAL = new OrderMilkDAL();
                AdmitPatientDAL aDAL = new AdmitPatientDAL();
                oDAL.ADMITPATIENT = oData.ADMITPATIENT;
                oDAL.CAPACITYRATE = oData.CAPACITYRATE;
                oDAL.ENDDATE = oData.ENDDATE;
                oDAL.ENDTIME = oData.ENDTIME;
                oDAL.ENERGY = oData.ENERGY;
                oDAL.ENERGYRATE = oData.ENERGYRATE;
                oDAL.FIRSTDATE = oData.FIRSTDATE;
                oDAL.FIRSTTIME = oData.FIRSTTIME;
                oDAL.ISINCREASE = (oData.ISINCREASE ? "Y" : "N");
                oDAL.ISREGISTER = "N";
                oDAL.ISSPIN = (oData.ISSPIN ? "Y" : "N");
                oDAL.MEALQTY = oData.MEALQTY;
                oDAL.MILKCATEGORY = oData.MILKCATEGORY;
                oDAL.MILKCODE = oData.MILKCODE;
                oDAL.ORDERBY = oData.ORDERBY;
                oDAL.ORDERDATE = DateTime.Now;
                oDAL.OWNER = oData.OWNER;
                oDAL.OWNERTEXT = oData.OWNERTEXT;
                oDAL.REMARKS = oData.REMARKS;
                oDAL.STATUS = oData.STATUS;
                oDAL.TIME1 = (oData.TIME1 ? "Y" : "N");
                oDAL.TIME2 = (oData.TIME2 ? "Y" : "N");
                oDAL.TIME3 = (oData.TIME3 ? "Y" : "N");
                oDAL.TIME4 = (oData.TIME4 ? "Y" : "N");
                oDAL.TIME5 = (oData.TIME5 ? "Y" : "N");
                oDAL.TIME6 = (oData.TIME6 ? "Y" : "N");
                oDAL.TIME7 = (oData.TIME7 ? "Y" : "N");
                oDAL.TIME8 = (oData.TIME8 ? "Y" : "N");
                oDAL.TIME9 = (oData.TIME9 ? "Y" : "N");
                oDAL.TIME10 = (oData.TIME10 ? "Y" : "N");
                oDAL.TIME11 = (oData.TIME11 ? "Y" : "N");
                oDAL.TIME12 = (oData.TIME12 ? "Y" : "N");
                oDAL.TIME13 = (oData.TIME13 ? "Y" : "N");
                oDAL.TIME14 = (oData.TIME14 ? "Y" : "N");
                oDAL.TIME15 = (oData.TIME15 ? "Y" : "N");
                oDAL.TIME16 = (oData.TIME16 ? "Y" : "N");
                oDAL.TIME17 = (oData.TIME17 ? "Y" : "N");
                oDAL.TIME18 = (oData.TIME18 ? "Y" : "N");
                oDAL.TIME19 = (oData.TIME19 ? "Y" : "N");
                oDAL.TIME20 = (oData.TIME20 ? "Y" : "N");
                oDAL.TIME21 = (oData.TIME21 ? "Y" : "N");
                oDAL.TIME22 = (oData.TIME22 ? "Y" : "N");
                oDAL.TIME23 = (oData.TIME23 ? "Y" : "N");
                oDAL.TIME24 = (oData.TIME24 ? "Y" : "N");
                oDAL.VOLUMN = oData.VOLUMN;
                aDAL.GetDataByLOID(oData.ADMITPATIENT, trans.Trans);
                aDAL.WEIGHT = oData.WEIGHT;

                ret = oDAL.InsertCurrentData(userID, trans.Trans);
                if (!ret)
                    _error = oDAL.ErrorMessage;
                else
                    ret = UpdateOrderMedicalItem(oDAL.TableName, oDAL.LOID, userID, oData.ORDERITEMLIST, trans.Trans);

                if (ret)
                    ret = aDAL.UpdateCurrentData(userID, trans.Trans);

                if (ret)
                    trans.CommitTransaction();
                else
                    trans.RollbackTransaction();

                _LOID = oDAL.LOID;
            }
            catch (Exception ex)
            {
                _error = ex.Message;
                ret = false;
                trans.RollbackTransaction();
            }
            return ret;
        }

        public bool UpdateAdmitPateint(AdmitPateintData oData, string userID)
        {
            bool ret = true;
            zTran trans = new zTran();
            trans.CreateTransaction();

                AdmitPatientDAL aDAL = new AdmitPatientDAL();
                aDAL.GetDataByLOID(oData.LOID, trans.Trans);
                aDAL.ADMITDATE = oData.ADMITDATE;
                aDAL.AGE = oData.AGE;
                aDAL.AN = oData.AN;
                aDAL.BEDNO = oData.BEDNO;
                aDAL.BIRTHDATE = oData.BIRTHDATE;
                aDAL.DIAGNOSIS = oData.DIAGNOSIS;
                //aDAL.DISEASE = oData.d
                aDAL.DRUGALLERGIC = oData.DRUGALLERGIC;
                aDAL.FOODALLERGIC = oData.FOODALLERGIC;
                aDAL.HEIGHT = oData.HEIGHT;
                aDAL.HN = oData.HN;
                aDAL.PATIENTNAME = oData.PATIENTNAME;
                aDAL.ROOMNO = oData.ROOMNO;
                aDAL.SEX = oData.SEX;
                //aDAL.STATUS = oData.
                aDAL.TITLE = oData.TITLE;
                aDAL.VN = oData.VN;
                aDAL.WARD = oData.WARD;
                aDAL.WEIGHT = oData.WEIGHT;

            try
            {
                if (aDAL.OnDB)
                {
                    ret = aDAL.UpdateCurrentData(userID, null);
                    if (!ret) _error = aDAL.ErrorMessage;

                    return ret;
                }
                else
                {
                    _error = Data.Common.Utilities.DataResources.MSGEU002;
                    return false;
                }
            }
            catch (Exception ex)
            {
                _error = ex.Message;
                return false;
            }
        }

        public bool InsertAdmitPateint(AdmitPateintData oData, string UserID)
        {


            AdmitPatientDAL aDAL = new AdmitPatientDAL();
            //VOrderPatientData MaterialClass = new VOrderPatientData();
            aDAL.ADMITDATE = oData.ADMITDATE;
            aDAL.AGE = oData.AGE;
            aDAL.AN = oData.AN;
            aDAL.BEDNO = oData.BEDNO;
            aDAL.BIRTHDATE = oData.BIRTHDATE;
            aDAL.DIAGNOSIS = oData.DIAGNOSIS;
            //aDAL.DISEASE = oData.d
            aDAL.DRUGALLERGIC = oData.DRUGALLERGIC;
            aDAL.FOODALLERGIC = oData.FOODALLERGIC;
            aDAL.HEIGHT = oData.HEIGHT;
            aDAL.HN = oData.HN;
            aDAL.PATIENTNAME = oData.PATIENTNAME;
            aDAL.ROOMNO = oData.ROOMNO;
            aDAL.SEX = oData.SEX;
            //aDAL.STATUS = oData.
            aDAL.TITLE = oData.TITLE;
            aDAL.VN = oData.VN;
            aDAL.WARD = oData.WARD;
            aDAL.WEIGHT = oData.WEIGHT;


            bool ret = true;

            try
            {
                ret = aDAL.InsertCurrentData(UserID, null);
                if (!ret) _error = aDAL.ErrorMessage;
            }
            catch (Exception ex)
            {
                ret = false;
                _error = ex.Message;
            }

            return ret;
        }

        public OrderMilkData GetOrderMilk(double ID)
        {
            OrderMilkData oData = new OrderMilkData();
            OrderMilkDAL oDAL = new OrderMilkDAL();
            oDAL.GetDataByLOID(ID, null);
            oData.ADMITPATIENT = oDAL.ADMITPATIENT;
            oData.CAPACITYRATE = oDAL.CAPACITYRATE;
            oData.ENDDATE = oDAL.ENDDATE;
            oData.ENDTIME = oDAL.ENDTIME;
            oData.ENERGY = oDAL.ENERGY;
            oData.ENERGYRATE = oDAL.ENERGYRATE;
            oData.FIRSTDATE = oDAL.FIRSTDATE;
            oData.FIRSTDATEREGIS = oDAL.FIRSTDATEREGIS;
            oData.FIRSTMEALREGIS = oDAL.FIRSTMEALREGIS;
            oData.FIRSTTIME = oDAL.FIRSTTIME;
            oData.ISINCREASE = (oDAL.ISINCREASE == "Y" || oDAL.LOID == 0);
            oData.ISREGISTER = (oDAL.ISREGISTER == "Y");
            oData.ISSPIN = (oDAL.ISSPIN == "Y");
            oData.LOID = oDAL.LOID;
            oData.MEALQTY = oDAL.MEALQTY;
            oData.MILKCATEGORY = oDAL.MILKCATEGORY;
            oData.MILKCODE = oDAL.MILKCODE;
            oData.ORDERBY = oDAL.ORDERBY;
            oData.ORDERDATE = oDAL.ORDERDATE;
            oData.OWNER = oDAL.OWNER;
            oData.OWNERTEXT = oDAL.OWNERTEXT;
            oData.REGISTERDATE = oDAL.REGISTERDATE;
            oData.REMARKS = oDAL.REMARKS;
            oData.STATUS = oDAL.STATUS;
            oData.TIME1 = (oDAL.TIME1 == "Y");
            oData.TIME2 = (oDAL.TIME2 == "Y");
            oData.TIME3 = (oDAL.TIME3 == "Y");
            oData.TIME4 = (oDAL.TIME4 == "Y");
            oData.TIME5 = (oDAL.TIME5 == "Y");
            oData.TIME6 = (oDAL.TIME6 == "Y");
            oData.TIME7 = (oDAL.TIME7 == "Y");
            oData.TIME8 = (oDAL.TIME8 == "Y");
            oData.TIME9 = (oDAL.TIME9 == "Y");
            oData.TIME10 = (oDAL.TIME10 == "Y");
            oData.TIME11 = (oDAL.TIME11 == "Y");
            oData.TIME12 = (oDAL.TIME12 == "Y");
            oData.TIME13 = (oDAL.TIME13 == "Y");
            oData.TIME14 = (oDAL.TIME14 == "Y");
            oData.TIME15 = (oDAL.TIME15 == "Y");
            oData.TIME16 = (oDAL.TIME16 == "Y");
            oData.TIME17 = (oDAL.TIME17 == "Y");
            oData.TIME18 = (oDAL.TIME18 == "Y");
            oData.TIME19 = (oDAL.TIME19 == "Y");
            oData.TIME20 = (oDAL.TIME20 == "Y");
            oData.TIME21 = (oDAL.TIME21 == "Y");
            oData.TIME22 = (oDAL.TIME22 == "Y");
            oData.TIME23 = (oDAL.TIME23 == "Y");
            oData.TIME24 = (oDAL.TIME24 == "Y");
            oData.UNREGISREASON = oDAL.UNREGISREASON;
            oData.VOLUMN = oDAL.VOLUMN;
            return oData;
        }

        #endregion

        #region OrderNonMedical

        public bool DeleteOrderNonMedical(double ID)
        {
            bool ret = true;
            zTran trans = new zTran();
            trans.CreateTransaction();
            try
            {
                OrderNonMedicalItemDAL itemDAL = new OrderNonMedicalItemDAL();
                OrderNonMedicalDAL oDAL = new OrderNonMedicalDAL();
                itemDAL.DeleteDataByConditions(ID, "", trans.Trans);
                ret = oDAL.DeleteDataByLOID(ID, trans.Trans);
                if (!ret)
                    _error = oDAL.ErrorMessage;

                if (ret)
                    trans.CommitTransaction();
                else
                    trans.RollbackTransaction();

                _LOID = oDAL.LOID;
            }
            catch (Exception ex)
            {
                _error = ex.Message;
                ret = false;
                trans.RollbackTransaction();
            }
            return ret;
        }

        public bool DiscontinueOrderNonMedical(double ID, string userID, DateTime endDate, string endMeal)
        {
            bool ret = true;
            zTran trans = new zTran();
            trans.CreateTransaction();
            try
            {
                OrderNonMedicalDAL oDAL = new OrderNonMedicalDAL();
                oDAL.GetDataByLOID(ID, trans.Trans);
                oDAL.ISREGISTER = "N";
                oDAL.STATUS = "DC";
                oDAL.ENDDATE = endDate;
                oDAL.ENDMEAL = endMeal;
                if (oDAL.OnDB)
                {
                    ret = oDAL.UpdateCurrentData(userID, trans.Trans);
                    if (!ret)
                        _error = oDAL.ErrorMessage;
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

                _LOID = oDAL.LOID;
            }
            catch (Exception ex)
            {
                _error = ex.Message;
                ret = false;
                trans.RollbackTransaction();
            }
            return ret;
        }

        public bool UpdateOrderNonMedical(OrderNonMedicalData oData, string userID)
        {
            bool ret = true;
            zTran trans = new zTran();
            trans.CreateTransaction();
            try
            {
                OrderNonMedicalDAL oDAL = new OrderNonMedicalDAL();
                oDAL.GetDataByLOID(oData.LOID, trans.Trans);
                oDAL.ABSTAINOTHER = oData.ABSTAINOTHER;
                oDAL.ADMITPATIENT = oData.ADMITPATIENT;
                oDAL.BREAKFAST = oData.BREAKFAST;
                oDAL.DINNER = oData.DINNER;
                oDAL.ENDDATE = oData.ENDDATE;
                oDAL.FIRSTDATE = oData.FIRSTDATE;
                oDAL.FOODTYPE = oData.FOODTYPE;
                oDAL.ISABSTAIN = (oData.ISABSTAIN ? "Y" : "N");
                oDAL.ISFAMILY = (oData.ISFAMILY ? "Y" : "N");
                oDAL.ISNEED = (oData.ISNEED ? "Y" : "N");
                oDAL.ISREQUEST = (oData.ISREQUEST ? "Y" : "N");
                oDAL.LUNCH = oData.LUNCH;
                oDAL.NEEDOTHER = oData.NEEDOTHER;
                oDAL.NURSE = oData.NURSE;
                oDAL.REMARKS = oData.REMARKS;
                oDAL.STATUS = oData.STATUS;
                oDAL.VIPTYPE = oData.VIPTYPE;

                if (oDAL.OnDB)
                {
                    ret = oDAL.UpdateCurrentData(userID, trans.Trans);
                    if (!ret)
                        _error = oDAL.ErrorMessage;
                    else
                        ret = UpdateOrderMedicalItem(oDAL.TableName, oDAL.LOID, userID, oData.ORDERITEMLIST, trans.Trans);
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

                _LOID = oDAL.LOID;
            }
            catch (Exception ex)
            {
                _error = ex.Message;
                ret = false;
                trans.RollbackTransaction();
            }
            return ret;
        }

        public bool InsertOrderNonMedical(OrderNonMedicalData oData, string userID)
        {
            bool ret = true;
            zTran trans = new zTran();
            trans.CreateTransaction();
            try
            {
                OrderNonMedicalDAL oDAL = new OrderNonMedicalDAL();
                oDAL.ABSTAINOTHER = oData.ABSTAINOTHER;
                oDAL.ADMITPATIENT = oData.ADMITPATIENT;
                oDAL.BREAKFAST = oData.BREAKFAST;
                oDAL.DINNER = oData.DINNER;
                oDAL.ENDDATE = oData.ENDDATE;
                oDAL.ENDMEAL = oData.ENDMEAL;
                oDAL.FIRSTDATE = oData.FIRSTDATE;
                oDAL.FIRSTMEAL = oData.FIRSTMEAL;
                oDAL.FOODTYPE = oData.FOODTYPE;
                oDAL.ISABSTAIN = (oData.ISABSTAIN ? "Y" : "N");
                oDAL.ISFAMILY = (oData.ISFAMILY ? "Y" : "N");
                oDAL.ISNEED = (oData.ISNEED ? "Y" : "N");
                oDAL.ISREGISTER = "N";
                oDAL.ISREQUEST = (oData.ISREQUEST ? "Y" : "N");
                oDAL.LUNCH = oData.LUNCH;
                oDAL.NEEDOTHER = oData.NEEDOTHER;
                oDAL.NURSE = oData.NURSE;
                oDAL.ORDERDATE = DateTime.Now;
                oDAL.REMARKS = oData.REMARKS;
                oDAL.STATUS = oData.STATUS;
                oDAL.VIPTYPE = oData.VIPTYPE;

                ret = oDAL.InsertCurrentData(userID, trans.Trans);
                if (!ret)
                    _error = oDAL.ErrorMessage;
                else
                    ret = UpdateOrderMedicalItem(oDAL.TableName, oDAL.LOID, userID, oData.ORDERITEMLIST, trans.Trans);

                if (ret)
                    trans.CommitTransaction();
                else
                    trans.RollbackTransaction();

                _LOID = oDAL.LOID;
            }
            catch (Exception ex)
            {
                _error = ex.Message;
                ret = false;
                trans.RollbackTransaction();
            }
            return ret;
        }

        public OrderNonMedicalData GetOrderNonMedical(double ID)
        {
            OrderNonMedicalData oData = new OrderNonMedicalData();
            OrderNonMedicalDAL oDAL = new OrderNonMedicalDAL();
            oDAL.GetDataByLOID(ID, null);
            oData.ABSTAINOTHER = oDAL.ABSTAINOTHER;
            oData.ADMITPATIENT = oDAL.ADMITPATIENT;
            oData.BREAKFAST = (ID != 0 ? oDAL.BREAKFAST : 1);
            oData.DINNER = (ID != 0 ? oDAL.DINNER : 1);
            oData.ENDDATE = oDAL.ENDDATE;
            oData.ENDMEAL = oDAL.ENDMEAL;
            oData.FIRSTDATE = oDAL.FIRSTDATE;
            oData.FIRSTDATEREGIS = oDAL.FIRSTDATEREGIS;
            oData.FIRSTMEAL = oDAL.FIRSTMEAL;
            oData.FIRSTMEALREGIS = oDAL.FIRSTMEALREGIS;
            oData.FOODTYPE = oDAL.FOODTYPE;
            oData.ISABSTAIN = (oDAL.ISABSTAIN == "Y");
            oData.ISFAMILY = (oDAL.ISFAMILY == "Y");
            oData.ISNEED = (oDAL.ISNEED == "Y");
            oData.ISREGISTER = (oDAL.ISREGISTER == "Y");
            oData.ISREQUEST = (oDAL.ISREQUEST == "Y");
            oData.LOID = oDAL.LOID;
            oData.LUNCH = (ID != 0 ? oDAL.LUNCH : 1);
            oData.NEEDOTHER = oDAL.NEEDOTHER;
            oData.NURSE = oDAL.NURSE;
            oData.ORDERDATE = oDAL.ORDERDATE;
            oData.REGISTERDATE = oDAL.REGISTERDATE;
            oData.REMARKS = oDAL.REMARKS;
            oData.REQUESTOTHER = oDAL.REQUESTOTHER;
            oData.STATUS = oDAL.STATUS;
            oData.UNREGISREASON = oDAL.UNREGISREASON;
            oData.VIPTYPE = oDAL.VIPTYPE;
            return oData;
        }

        #endregion

    }
}
