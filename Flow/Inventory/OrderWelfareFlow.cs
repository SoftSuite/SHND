using System;
using System.Collections.Generic;
using System.Text;
using System.Data;
using SHND.DAL.Tables;
using SHND.DAL.Views;
using SHND.Data.Inventory;
using SHND.Data.Tables;
using SHND.DAL.Utilities;
using System.Collections;
//using DB = SHND.DAL.Utilities.OracleDB;
using zTran = SHND.DAL.Utilities.OracleTransactionDB;


/// <summary>
/// Supplier Class
/// Version 1.0
/// =========================================================================
/// Create by: Somsakoon
/// Create Date: 9 Jan 2009
/// -------------------------------------------------------------------------
/// Modify By: -
/// Modify From: -
/// Modify Date: -
/// -------------------------------------------------------------------------
/// Remark: -
/// Description:
///    Flow จัดการการทำงานของหน้า OrderWelfare 
/// Changes:
///    1.0 - สร้าง
/// -------------------------------------------------------------------------
/// =========================================================================
/// </summary>
/// 

namespace SHND.Flow.Inventory
{
   public  class OrderWelfareFlow
    {

        string _error = "";
        public string ErrorMessage { get { return _error; } }

        public DataTable GetMasterList(string Code, string Codet,DateTime  Date,DateTime  Datet,string Status,string Statust ,string OrderText)
        {
            VOrderWelfareDAL vDAL = new VOrderWelfareDAL();
            return vDAL.GetDataListByCondition(Code, Codet, Date, Datet, Status ,Statust, OrderText, null);
        }

        public DataTable GetMasterList()
        {
            VOrderWelfareDAL vDAL = new VOrderWelfareDAL();
            return vDAL.GetDataList("", "", null);
            
        }

       public DataTable GetMasterListByDivision(double mainDivision)
        {
            VDivisionDAL vDAL = new VDivisionDAL();
            DataTable dt = vDAL.GetDataListByDivision(mainDivision, "Y", "NAME", null);
            dt.Columns.Add("SUBDIVISION", typeof(double));
            dt.Columns.Add("QTY", typeof(double));
            for (int i = 0; i < dt.Rows.Count; ++i)
            {
                dt.Rows[i]["SUBDIVISION"] = Convert.ToDouble(dt.Rows[i]["LOID"]);
            }
            return dt;
        }

        public DataTable GetMasterListByCondition(string Code, string Name, string Devision)
        {
            string whStr = "";
            // create where condition

            OrderWelfareDAL vDAL = new OrderWelfareDAL();
         
            return vDAL.GetDataList(whStr, "", null);
        }

        public DataTable GetMasterListSorted(string SortField, string SortDirection)
        {
            OrderWelfareDAL vDAL = new OrderWelfareDAL();
           
            return vDAL.GetDataList("", SortField + " " + SortDirection, null);
        }

        public bool InsertData(VOrderWelfareData  ftData, string UserID)
        {
            zTran trans = new zTran();
            trans.CreateTransaction();

            bool ret = true;

            try
            {
                OrderWelfareDAL ftDAL = new OrderWelfareDAL();
                ftDAL.STATUS = ftData.STATUS;
                ftDAL.COUPON = ftData.COUPON;
                ftDAL.DIVISION = ftData.DIVISION;
                ftDAL.FINISHDATE = ftData.FINISHDATE;
                ftDAL.ORDERCODE = ftData.ORDERCODE;
                ftDAL.ORDERDATE = ftData.ORDERDATE;
                ftDAL.REFCODE = ftData.REFCODE;
                ftDAL.REFDATE = ftData.REFDATE;
                ftDAL.STARTDATE = ftData.STARTDATE;
                ftDAL.AMOUNT = ftData.AMOUNT;

                orderwelfaredetailDAL orderwelfaredetail = new orderwelfaredetailDAL();
                orderwelfaredetail.BD1 = ftData.BD1;
                orderwelfaredetail.BD2 = ftData.BD2;
                orderwelfaredetail.BD3 = ftData.BD3;
                orderwelfaredetail.BD4 = ftData.BD4;
                orderwelfaredetail.BD5 = ftData.BD5;
                orderwelfaredetail.BD6 = ftData.BD6;
                orderwelfaredetail.BD7 = ftData.BD7;

                orderwelfaredetail.LD1 = ftData.LD1;
                orderwelfaredetail.LD2 = ftData.LD2;
                orderwelfaredetail.LD3 = ftData.LD3;
                orderwelfaredetail.LD4 = ftData.LD4;
                orderwelfaredetail.LD5 = ftData.LD5;
                orderwelfaredetail.LD6 = ftData.LD6;
                orderwelfaredetail.LD7 = ftData.LD7;

                orderwelfaredetail.DD1 = ftData.DD1;
                orderwelfaredetail.DD2 = ftData.DD2;
                orderwelfaredetail.DD3 = ftData.DD3;
                orderwelfaredetail.DD4 = ftData.DD4;
                orderwelfaredetail.DD5 = ftData.DD5;
                orderwelfaredetail.DD6 = ftData.DD6;
                orderwelfaredetail.DD7 = ftData.DD7;

                ret = ftDAL.InsertCurrentData(UserID, trans.Trans);
                if (!ret) _error = ftDAL.ErrorMessage;

                if (ret)
                {
                    orderwelfaredetail.ORDERWELFARE = ftDAL.LOID;
                    ret = orderwelfaredetail.InsertCurrentData(UserID, trans.Trans);
                    if (!ret) _error = orderwelfaredetail.ErrorMessage;
                }

                if (ret)
                {
                    OrderWelfareItemDAL OrderWelfareItem;
                    for (int i = 0; i < ftData.OrderWelfareItemList.Count; ++i)
                    {
                        OrderWelfareItemData itemData = (OrderWelfareItemData)ftData.OrderWelfareItemList[i];
                        OrderWelfareItem = new OrderWelfareItemDAL();
                        OrderWelfareItem.ORDERWELFARE = ftDAL.LOID;
                        OrderWelfareItem.QTY  = itemData.QTY;
                        OrderWelfareItem.SUBDIVISION = itemData.SUBDIVISION;
                        ret = OrderWelfareItem.InsertCurrentData(UserID, trans.Trans);
                        if (!ret)
                        {
                            _error = OrderWelfareItem.ErrorMessage;
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

        public bool UpdateData(VOrderWelfareData ftData, string UserID)
        {
            zTran trans = new zTran();
            trans.CreateTransaction();

            bool ret = true;

            try
            {
                OrderWelfareDAL ftDAL = new OrderWelfareDAL();
                
                ftDAL.GetDataByLOID(ftData.LOID, trans.Trans);
               
                ftDAL.STATUS = ftData.STATUS;
                ftDAL.COUPON = ftData.COUPON;
                ftDAL.DIVISION = ftData.DIVISION;
                ftDAL.FINISHDATE = ftData.FINISHDATE;
                //ftDAL.ORDERCODE = ftData.ORDERCODE;
                //ftDAL.ORDERDATE = ftData.ORDERDATE;
                ftDAL.REFCODE = ftData.REFCODE;
                ftDAL.REFDATE = ftData.REFDATE;
                ftDAL.STARTDATE = ftData.STARTDATE;
                //ftDAL.LOID = ftData.LOID;
                ftDAL.AMOUNT = ftData.AMOUNT;

                orderwelfaredetailDAL orderwelfaredetail = new orderwelfaredetailDAL();
                orderwelfaredetail.GetDataByORDERWELFARE(ftData.LOID, trans.Trans);
                orderwelfaredetail.BD1 = ftData.BD1;
                orderwelfaredetail.BD2 = ftData.BD2;
                orderwelfaredetail.BD3 = ftData.BD3;
                orderwelfaredetail.BD4 = ftData.BD4;
                orderwelfaredetail.BD5 = ftData.BD5;
                orderwelfaredetail.BD6 = ftData.BD6;
                orderwelfaredetail.BD7 = ftData.BD7;

                orderwelfaredetail.LD1 = ftData.LD1;
                orderwelfaredetail.LD2 = ftData.LD2;
                orderwelfaredetail.LD3 = ftData.LD3;
                orderwelfaredetail.LD4 = ftData.LD4;
                orderwelfaredetail.LD5 = ftData.LD5;
                orderwelfaredetail.LD6 = ftData.LD6;
                orderwelfaredetail.LD7 = ftData.LD7;

                orderwelfaredetail.DD1 = ftData.DD1;
                orderwelfaredetail.DD2 = ftData.DD2;
                orderwelfaredetail.DD3 = ftData.DD3;
                orderwelfaredetail.DD4 = ftData.DD4;
                orderwelfaredetail.DD5 = ftData.DD5;
                orderwelfaredetail.DD6 = ftData.DD6;
                orderwelfaredetail.DD7 = ftData.DD7;

                if (ftDAL.OnDB)
                {
                    ret = ftDAL.UpdateCurrentData(UserID, trans.Trans);
                    if (!ret) _error = ftDAL.ErrorMessage;

                    if (ret)
                    {
                        ret = orderwelfaredetail.UpdateCurrentData(UserID, trans.Trans);
                        if (!ret) _error = orderwelfaredetail.ErrorMessage;
                    }

                    if (ret)
                    {
                        OrderWelfareItemDAL OrderWelfareItem = new OrderWelfareItemDAL();
                        OrderWelfareItem.DeleteDataByORDERWELFARE(ftDAL.LOID, trans.Trans);
                        for (int i = 0; i < ftData.OrderWelfareItemList.Count; ++i)
                        {
                            OrderWelfareItemData itemData = (OrderWelfareItemData)ftData.OrderWelfareItemList[i];
                            OrderWelfareItem = new OrderWelfareItemDAL();
                            OrderWelfareItem.ORDERWELFARE = ftDAL.LOID;
                            OrderWelfareItem.QTY = itemData.QTY;
                            OrderWelfareItem.SUBDIVISION = itemData.SUBDIVISION;
                            ret = OrderWelfareItem.InsertCurrentData(UserID, trans.Trans);
                            if (!ret)
                            {
                                _error = OrderWelfareItem.ErrorMessage;
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
                ret= false;
            }
            return ret;
        }


       public VOrderWelfareData GetDetails(double LOID)
        {

            VOrderWelfareDAL fDAL = new VOrderWelfareDAL();
            VOrderWelfareData fData = new VOrderWelfareData();
            VOrderWelfareItemDAL VOrderWelfareItem = new VOrderWelfareItemDAL();
            
            fDAL.GetDataByLOID(LOID, null);
            if (fDAL.OnDB)
            {
                fData.BD1 = fDAL.BD1;
                fData.BD2 = fDAL.BD2;
                fData.BD3 = fDAL.BD3;
                fData.BD4 = fDAL.BD4;
                fData.BD5 = fDAL.BD5;
                fData.BD6 = fDAL.BD6;
                fData.BD7 = fDAL.BD7;

                fData.LD1 = fDAL.LD1;
                fData.LD2 = fDAL.LD2;
                fData.LD3 = fDAL.LD3;
                fData.LD4 = fDAL.LD4;
                fData.LD5 = fDAL.LD5;
                fData.LD6 = fDAL.LD6;
                fData.LD7 = fDAL.LD7;

                fData.DD1 = fDAL.DD1;
                fData.DD2 = fDAL.DD5;
                fData.DD3 = fDAL.DD3;
                fData.DD4 = fDAL.DD4;
                fData.DD5 = fDAL.DD5;
                fData.DD6 = fDAL.DD6;
                fData.DD7 = fDAL.DD7;

                fData.LOID = fDAL.LOID;
                fData.COUPON = fDAL.COUPON;
                fData.CREATEBY = fDAL.CREATEBY;
                fData.DIVISION = fDAL.DIVISION;
                fData.FINISHDATE = fDAL.FINISHDATE;
                fData.ISSUBDIVISION = fDAL.ISSUBDIVISION;
                fData.MAINDIVISION = fDAL.MAINDIVISION;
                fData.NAME = fDAL.ORDERCODE;
                fData.ORDERCODE = fDAL.ORDERCODE;
                fData.ORDERDATE = fDAL.ORDERDATE;
                fData.REFCODE = fDAL.REFCODE;
                fData.REFDATE = fDAL.REFDATE;
                fData.STARTDATE = fDAL.STARTDATE;
                fData.STATUS = fDAL.STATUS;
                fData.STATUSNAME = fDAL.STATUSNAME;
                fData.STATUSRANK = fDAL.STATUSRANK;
                fData.SUMQTY = fDAL.SUMQTY;
                fData.AMOUNT = fDAL.SUMQTY;

                fData.OrderWelfareItemTable = VOrderWelfareItem.GetDataListByOrderWelfare(LOID, "NAME", null);

            }
            else
                _error = Data.Common.Utilities.DataResources.MSGEV002;

            return fData;

        }
       public bool DeleteByLOID(ArrayList arrLOID)
       {
           zTran trans = new zTran();
           OrderWelfareItemDAL OrderWelfareItem = new OrderWelfareItemDAL();
           orderwelfaredetailDAL orderwelfaredetail = new orderwelfaredetailDAL();
           OrderWelfareDAL fDAL = new OrderWelfareDAL();
          // SupplierDAL fDAL = new SupplierDAL();
           trans.CreateTransaction();
           bool ret = true;
           try
           {
               for (int i = 0; i < arrLOID.Count; i++)
               {
                   OrderWelfareItem.DeleteDataByORDERWELFARE(Convert.ToDouble(arrLOID[i]), trans.Trans);
                   orderwelfaredetail.DeleteDataByORDERWELFARE(Convert.ToDouble(arrLOID[i]), trans.Trans);
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

       public bool UpdateByLOID(string userID, ArrayList arrLOID)
       {
           zTran trans = new zTran();
           trans.CreateTransaction();
           bool ret = true;
           try
           {
               OrderWelfareDAL OrderWelfare = new OrderWelfareDAL();
               for (int i = 0; i < arrLOID.Count; i++)
               {
                   OrderWelfare.GetDataByLOID(Convert.ToDouble(arrLOID[i]), trans.Trans);
                   if (OrderWelfare.OnDB && OrderWelfare.STATUS == "WA")
                   {
                       OrderWelfare.STATUS = "RG";
                       ret = OrderWelfare.UpdateCurrentData(userID, trans.Trans);

                       if (!ret)
                       {
                           _error = OrderWelfare.ErrorMessage;
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
       public bool CheckUniqCode(string cCODE, string cLOID)
       {
           SupplierDAL fDAL = new SupplierDAL();
           
            fDAL.GetDataByCODE(cCODE, null);
           return !fDAL.OnDB || (cLOID == fDAL.LOID.ToString());
       }

    }
}
