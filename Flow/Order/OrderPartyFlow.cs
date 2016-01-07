using System;
using System.Collections.Generic;
using System.Data.OracleClient;
using System.Text;
using System.Data;
using SHND.DAL.Views;
using SHND.DAL.Tables;
using SHND.Data.Views;
using SHND.Data.Tables;
using SHND.DAL.Utilities;
using System.Collections;
//using DB = SHND.DAL.Utilities.OracleDB;
using zTran = SHND.DAL.Utilities.OracleTransactionDB;

/// <summary>
/// FoodTypeFlow Class
/// Version 1.0
/// =========================================================================
/// Create by: Tan
/// Create Date: 1 Feb 2009
/// -------------------------------------------------------------------------
/// Modify By: -
/// Modify From: -
/// Modify Date: -
/// -------------------------------------------------------------------------
/// Remark: -
/// Description:
///    Flow จัดการการทำงานของหน้า Blenderize Diet 
/// Changes:
///    1.0 - สร้าง
/// -------------------------------------------------------------------------
/// =========================================================================
/// </summary>
/// 

namespace SHND.Flow.Order
{
    public class OrderPartyFlow
    {
        string _error = "";
        double _LOID = 0;
        public string ErrorMessage { get { return _error; } }
        public double LOID { get { return _LOID; } }

        public DataTable GetMasterList(string CodeFrom, string CodeTo, DateTime DateFrom, DateTime DateTo, string StatusFrom, string StatusTo, string OrderText)
        {
            VOrderPartyDAL vDAL = new VOrderPartyDAL();
            return vDAL.GetDataListByCondition(CodeFrom, CodeTo, DateFrom, DateTo, StatusFrom, StatusTo, OrderText, null);
        }
        public DataTable GetMasterListDirector(string CodeFrom, string CodeTo, DateTime DateFrom, DateTime DateTo, string StatusFrom, string StatusTo, string OrderText)
        {
            VOrderPartyDAL vDAL = new VOrderPartyDAL();
            return vDAL.GetDataListByDirector(CodeFrom, CodeTo, DateFrom, DateTo, StatusFrom, StatusTo, OrderText, null);
        }
        public DataTable GetMasterListOfficer(string CodeFrom, string CodeTo, DateTime DateFrom, DateTime DateTo, string StatusFrom, string StatusTo, string OrderText)
        {
            VOrderPartyDAL vDAL = new VOrderPartyDAL();
            return vDAL.GetDataListByOfficer(CodeFrom, CodeTo, DateFrom, DateTo, StatusFrom, StatusTo, OrderText, null);
        }
        public VOrderPartyData GetDetails(double LOID)
        {

            VOrderPartyDAL fDAL = new VOrderPartyDAL();
            VOrderPartyData fData = new VOrderPartyData();
        //    VOrderWelfareItemDAL VOrderWelfareItem = new VOrderWelfareItemDAL();

            fDAL.GetDataByLOID(LOID, null);
            if (fDAL.OnDB)
            {
                fData.LOID = fDAL.LOID;
                fData.DIVISION = fDAL.DIVISION;
                fData.DIVISIONNAME = fDAL.DIVISIONNAME;
                fData.CODE = fDAL.CODE;
                fData.ORDERDATE = fDAL.ORDERDATE;
                fData.OTITLE = fDAL.OTITLE;
                fData.ONAME = fDAL.ONAME;
                fData.OLASTNAME = fDAL.OLASTNAME;
                fData.OTEL = fDAL.OTEL;
                fData.PARTYDATETIME = fDAL.PARTYDATETIME;
                fData.PARTYTYPE = fDAL.PARTYTYPE;
                fData.VISITORQTY = fDAL.VISITORQTY;
                fData.PLACE = fDAL.PLACE;
                fData.STATUS = fDAL.STATUS;
                fData.STATUSNAME = fDAL.STATUSNAME;
                fData.DIRECTORAPPROVE = fDAL.DIRECTORAPPROVE;
                fData.DIRECTORCOMMENT = fDAL.DIRECTORCOMMENT;
                fData.NDAPPROVE = fDAL.NDAPPROVE;
                fData.NDCOMMENT = fDAL.NDCOMMENT;

                //fData.OrderWelfareItemTable = VOrderWelfareItem.GetDataListByOrderWelfare(LOID, "NAME", null);

            }
            else
                _error = Data.Common.Utilities.DataResources.MSGEV002;

            return fData;

        }

        public bool InsertData(VOrderPartyData ftData, string UserID)
        {
            zTran trans = new zTran();
            trans.CreateTransaction();

            bool ret = true;

            try
            {
                OrderPartyDAL ftDAL = new OrderPartyDAL();
              //  ftDAL.CODE = ftData.CODE;
                ftDAL.DIVISION = ftData.DIVISION;
                ftDAL.OTITLE = ftData.OTITLE;
                ftDAL.ONAME = ftData.ONAME;
                ftDAL.OLASTNAME = ftData.OLASTNAME;
                ftDAL.ORDERDATE = ftData.ORDERDATE;
                ftDAL.OTEL = ftData.OTEL;
                ftDAL.PLACE = ftData.PLACE;
                ftDAL.PARTYDATETIME = ftData.PARTYDATETIME;
                ftDAL.PARTYTYPE = ftData.PARTYTYPE;
                ftDAL.STATUS = ftData.STATUS;
                ftDAL.VISITORQTY = ftData.VISITORQTY;
                ftDAL.DIRECTORAPPROVE = ftData.DIRECTORAPPROVE;
                ftDAL.DIRECTORCOMMENT = ftData.DIRECTORCOMMENT;
                ftDAL.NDAPPROVE = ftData.NDAPPROVE;
                ftDAL.NDCOMMENT = ftData.NDCOMMENT;

                ret = ftDAL.InsertCurrentData(UserID, trans.Trans);
                if (!ret) _error = ftDAL.ErrorMessage;
                else
                {
                _LOID = ftDAL.LOID;
                    OrderPartyItemDAL OrderPartyItem;
                    for (int i = 0; i < ftData.OrderPartyItem.Count; ++i)
                    {
                        OrderPartyItemData itemData = (OrderPartyItemData)ftData.OrderPartyItem[i];
                        OrderPartyItem = new OrderPartyItemDAL();
                        OrderPartyItem.ORDERPARTY = _LOID;
                        OrderPartyItem.FORMULASET = itemData.FORMULASET;
                        OrderPartyItem.SERVICEQTY = itemData.SERVICEQTY;
                        OrderPartyItem.VISITORQTY = itemData.VISITORQTY;
                        ret = OrderPartyItem.InsertCurrentData(UserID, trans.Trans);
                        if (!ret)
                        {
                            _error = OrderPartyItem.ErrorMessage;
                            break;
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
                ret = false;
                _error = ex.Message;
            }

            return ret;
        }

        public bool UpdateData(VOrderPartyData ftData, string UserID)
        {
            zTran trans = new zTran();
            trans.CreateTransaction();

            bool ret = true;

            try
            {
                OrderPartyDAL ftDAL = new OrderPartyDAL();

                ftDAL.GetDataByLOID(ftData.LOID, trans.Trans);

                ftDAL.CODE = ftData.CODE;
                ftDAL.DIVISION = ftData.DIVISION;
                ftDAL.OTITLE = ftData.OTITLE;
                ftDAL.ONAME = ftData.ONAME;
                ftDAL.OLASTNAME = ftData.OLASTNAME;
                ftDAL.ORDERDATE = ftData.ORDERDATE;
                ftDAL.OTEL = ftData.OTEL;
                ftDAL.PARTYDATETIME = ftData.PARTYDATETIME;
                ftDAL.PARTYTYPE = ftData.PARTYTYPE;
                ftDAL.PLACE = ftData.PLACE;
                ftDAL.VISITORQTY = ftData.VISITORQTY;
                ftDAL.STATUS = ftData.STATUS;
                ftDAL.DIRECTORAPPROVE = ftData.DIRECTORAPPROVE;
                ftDAL.DIRECTORCOMMENT = ftData.DIRECTORCOMMENT;
                ftDAL.NDAPPROVE = ftData.NDAPPROVE;
                ftDAL.NDCOMMENT = ftData.NDCOMMENT;

                if (ftDAL.OnDB)
                {
                    ret = ftDAL.UpdateCurrentData(UserID, trans.Trans);
                    if (!ret) _error = ftDAL.ErrorMessage;

                    if (ret)
                    {
                        _LOID = ftDAL.LOID;
                        OrderPartyItemDAL OrderPartyItem = new OrderPartyItemDAL();
                        OrderPartyItem.DeleteDataByORDERPARTY(ftDAL.LOID, trans.Trans);
                        for (int i = 0; i < ftData.OrderPartyItem.Count; ++i)
                        {
                            OrderPartyItemData itemData = (OrderPartyItemData)ftData.OrderPartyItem[i];
                            OrderPartyItem = new OrderPartyItemDAL();
                            OrderPartyItem.ORDERPARTY = ftDAL.LOID;
                            OrderPartyItem.FORMULASET = itemData.FORMULASET;
                            OrderPartyItem.SERVICEQTY = itemData.SERVICEQTY;
                            OrderPartyItem.VISITORQTY = itemData.VISITORQTY;
                            ret = OrderPartyItem.InsertCurrentData(UserID, trans.Trans);
                            if (!ret)
                            {
                                _error = OrderPartyItem.ErrorMessage;
                                break;
                            }

                        }
                    }

                }
                else
                {
                    _error = Data.Common.Utilities.DataResources.MSGEU002;
                    ret = false;
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
            }
            return ret;
        }

        public bool UpdateDataOfficer(VOrderPartyData ftData, string UserID)
        {
            zTran trans = new zTran();
            trans.CreateTransaction();

            bool ret = true;

            try
            {
                OrderPartyDAL ftDAL = new OrderPartyDAL();

                ftDAL.GetDataByLOID(ftData.LOID, trans.Trans);

                ftDAL.NDAPPROVE = ftData.NDAPPROVE;
                ftDAL.NDCOMMENT = ftData.NDCOMMENT;
                ftDAL.STATUS = ftData.STATUS;

                if (ftDAL.OnDB)
                {
                    ret = ftDAL.UpdateCurrentData(UserID, trans.Trans);
                    if (!ret) _error = ftDAL.ErrorMessage;

                    if (ret)
                    {
                        _LOID = ftDAL.LOID;
                        OrderPartyItemDAL OrderPartyItem = new OrderPartyItemDAL();
                        OrderPartyItem.DeleteDataByORDERPARTY(ftDAL.LOID, trans.Trans);
                        for (int i = 0; i < ftData.OrderPartyItem.Count; ++i)
                        {
                            OrderPartyItemData itemData = (OrderPartyItemData)ftData.OrderPartyItem[i];
                            OrderPartyItem = new OrderPartyItemDAL();
                            OrderPartyItem.ORDERPARTY = ftDAL.LOID;
                            OrderPartyItem.FORMULASET = itemData.FORMULASET;
                            OrderPartyItem.SERVICEQTY = itemData.SERVICEQTY;
                            OrderPartyItem.VISITORQTY = itemData.VISITORQTY;
                            ret = OrderPartyItem.InsertCurrentData(UserID, trans.Trans);
                            if (!ret)
                            {
                                _error = OrderPartyItem.ErrorMessage;
                                break;
                            }

                        }
                    }

                }
                else
                {
                    _error = Data.Common.Utilities.DataResources.MSGEU002;
                    ret = false;
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
            }
            return ret;
        }


        public bool UpdateDataAP(VOrderPartyData ftData, string UserID)
        {
            zTran trans = new zTran();
            trans.CreateTransaction();

            bool ret = true;

            try
            {
                OrderPartyDAL ftDAL = new OrderPartyDAL();

                ftDAL.GetDataByLOID(ftData.LOID, trans.Trans);

                ftDAL.STATUS = ftData.STATUS;
                ftDAL.DIRECTORAPPROVE = ftData.DIRECTORAPPROVE;
                ftDAL.DIRECTORCOMMENT = ftData.DIRECTORCOMMENT;

                if (ftDAL.OnDB)
                {
                    ret = ftDAL.UpdateCurrentData(UserID, trans.Trans);
                    if (!ret) _error = ftDAL.ErrorMessage;
                    _LOID = ftDAL.LOID;
                }
                else
                {
                    _error = Data.Common.Utilities.DataResources.MSGEU002;
                    ret = false;
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
            }
            return ret;
        }

        public DataTable GetOrderPartyList(double OrderParty)
        {
            VOrderPartyItemDAL OrderPartyItem = new VOrderPartyItemDAL();
            DataTable dt = OrderPartyItem.GetDataListByOrderParty(OrderParty, "FORMULASET", null);
            dt.Columns.Add("RANK", typeof(double));
            for (int i = 0; i < dt.Rows.Count; ++i)
            {
                dt.Rows[i]["RANK"] = i + 1;
            }
            return dt;
        }

        public bool UpdateByLOID(string userID, string Status, ArrayList arrLOID)
        {
            zTran trans = new zTran();
            trans.CreateTransaction();
            bool ret = true;
            try
            {
                OrderPartyDAL OrderParty = new OrderPartyDAL();
                for (int i = 0; i < arrLOID.Count; i++)
                {
                    OrderParty.GetDataByLOID(Convert.ToDouble(arrLOID[i]), trans.Trans);
                    if (OrderParty.OnDB)
                    {
                            OrderParty.STATUS = Status;
                            ret = OrderParty.UpdateCurrentData(userID, trans.Trans);

                        if (!ret)
                        {
                            _error = OrderParty.ErrorMessage;
                            break;
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
                ret = false;
                trans.RollbackTransaction();
            }

            return ret;

        }

        public bool CommitByDirector(string userID, string Status, ArrayList arrLOID)
        {
            zTran trans = new zTran();
            trans.CreateTransaction();
            bool ret = true;
            try
            {
                OrderPartyDAL OrderParty = new OrderPartyDAL();
                for (int i = 0; i < arrLOID.Count; i++)
                {
                    OrderParty.GetDataByLOID(Convert.ToDouble(arrLOID[i]), trans.Trans);
                    if (OrderParty.OnDB)
                    {
                        if (OrderParty.DIRECTORAPPROVE == "" || OrderParty.DIRECTORAPPROVE == "Z")
                        {
                            ret = true;
                            _error = "มีบางรายการยังไม่เลือก อนุมัติ/ไม่อนุมัติ สั่งอาหาร";
                        }
                        else
                        {
                            OrderParty.STATUS = Status;
                           // OrderParty.DIRECTORAPPROVE = "Y";
                            ret = OrderParty.UpdateCurrentData(userID, trans.Trans);
                        }

                        if (!ret)
                        {
                            _error = OrderParty.ErrorMessage;
                            break;
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
                ret = false;
                trans.RollbackTransaction();
            }

            return ret;

        }

        public bool CommitByND(string userID, string Status, ArrayList arrLOID)
        {
            zTran trans = new zTran();
            trans.CreateTransaction();
            bool ret = true;
            try
            {
                OrderPartyDAL OrderParty = new OrderPartyDAL();
                for (int i = 0; i < arrLOID.Count; i++)
                {
                    OrderParty.GetDataByLOID(Convert.ToDouble(arrLOID[i]), trans.Trans);
                    if (OrderParty.OnDB)
                    {
                        if (OrderParty.NDAPPROVE == "" || OrderParty.NDAPPROVE == "Z")
                        {
                            ret = true;
                            _error = "มีบางรายการยังไม่เลือก รับ/ไม่รับ Order";
                        }
                        else
                        {
                            OrderParty.STATUS = Status;
                          //  OrderParty.NDAPPROVE = "Y";
                            ret = OrderParty.UpdateCurrentData(userID, trans.Trans);
                        }

                        if (!ret)
                        {
                            _error = OrderParty.ErrorMessage;
                            break;
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
                ret = false;
                trans.RollbackTransaction();
            }

            return ret;

        }

        public bool DeleteByLOID(ArrayList arrLOID)
        {
            zTran trans = new zTran();
            OrderPartyItemDAL OrderPartyItem = new OrderPartyItemDAL();
            OrderPartyDAL fDAL = new OrderPartyDAL();
            trans.CreateTransaction();
            bool ret = true;
            try
            {
                for (int i = 0; i < arrLOID.Count; i++)
                {
                    ret = OrderPartyItem.DeleteDataByORDERPARTY(Convert.ToDouble(arrLOID[i]), trans.Trans);
                    if(ret)
                        ret = fDAL.DeleteDataByLOID(Convert.ToDouble(arrLOID[i]), trans.Trans);
                    if (!ret)
                    {
                        _error = fDAL.ErrorMessage;
                        break;
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
                ret = false;
                trans.RollbackTransaction();
            }

            return ret;

        }

    }
}
