using System;
using System.Collections.Generic;
using System.Text;
using System.Data;
//using DB = SHND.DAL.Utilities.OracleDB;
using zTran = SHND.DAL.Utilities.OracleTransactionDB;
using SHND.DAL.Views;
using SHND.DAL.Tables;
using SHND.Data.Tables;
using SHND.Data.Views;
using System.Collections;

/// <summary>
/// Supplier Class
/// Version 1.0
/// =========================================================================
/// Create by: Somsakoon
/// Create Date: 18 Feb 2009
/// -------------------------------------------------------------------------
/// Modify By: -
/// Modify From: -
/// Modify Date: -
/// -------------------------------------------------------------------------
/// Remark: -
/// Description:
///    Flow จัดการการทำงานของหน้า StockInSearch 
/// Changes:
///    1.0 - สร้าง
/// -------------------------------------------------------------------------
/// =========================================================================
/// </summary>
/// 


namespace SHND.Flow.Inventory
{
  public class StockInFlow
    {
      string _error = "";
      double _LOID = 0;

      public string ErrorMessage { get { return _error; } }
      public double LOID { get { return _LOID; } }

      public DataTable GetMasterList(string Code, string Codet, DateTime Date, DateTime Datet, string Doctype, string Status, string Statust, string OrderText)
        {
            VStockInDAL vDAL = new VStockInDAL();
            return vDAL.GetDataListByCondition(Code, Codet, Date, Datet, Doctype, Status, Statust, OrderText, null);
        }
      
      public bool DeleteByLOID(ArrayList arrLOID)
      {
          zTran trans = new zTran();

          StockInDAL fDAL = new StockInDAL();
          StockinItemDAL StockinItem = new StockinItemDAL();
          trans.CreateTransaction();
          bool ret = true;
          try
          {
              for (int i = 0; i < arrLOID.Count; i++)
              {
                  StockinItem.DeleteDataBySTOCKIN(Convert.ToDouble(arrLOID[i]), trans.Trans);
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

      public DataTable GetStockInList(double LOID)
      {
          VStockinitemPoDAL StockInItemPo = new VStockinitemPoDAL();
          DataTable dt = StockInItemPo.GetDataListBySTOCKIN (LOID,"MATERIALNAME", null);
           
          for (int i = 0; i < dt.Rows.Count; ++i)
          {
              dt.Rows[i]["LOID"] = i + 1;
          }
          return dt;
      }
      public bool InsertData(VStockInData ftData, string userID)
      {
          zTran trans = new zTran();
          trans.CreateTransaction();

          bool ret = true;

          try
          {
              StockInDAL ftDAL = new StockInDAL();
              ftDAL.DIVISION = ftData.DIVISION;
              ftDAL.DOCTYPE = ftData.DOCTYPE;
              ftDAL.STATUS = ftData.STATUS;
              ftDAL.STOCKINDATE = ftData.STOCKINDATE;
              ftDAL.WAREHOUSE = ftData.WAREHOUSE;
              ftDAL.PLANORDER = ftData.PLANORDER ;
              ftDAL.SAPWAREHOUSE = ftData.SAPWAREHOUSE;
              
              ret = ftDAL.InsertCurrentData(userID, trans.Trans);
              if (!ret) _error = ftDAL.ErrorMessage;

              if (ret)
              {
                  for (int i = 0; i < ftData.StockInList.Count; ++i)
                  {
                      StockinItemDAL Stockinitem = new StockinItemDAL();
                      StockinItemData StockinitemD = (StockinItemData)ftData.StockInList[i];
                      Stockinitem.STOCKIN = ftDAL.LOID;
                      Stockinitem.PRICE = StockinitemD.PRICE;
                      Stockinitem.QTY = StockinitemD.QTY;
                      Stockinitem.LOTNO = StockinitemD.LOTNO;
                      Stockinitem.SAPPOCODE = StockinitemD.SAPPOCODE;
                      Stockinitem.SAPPODATE = StockinitemD.SAPPODATE;
                      Stockinitem.PLANREMAINQTY = StockinitemD.PLANREMAINQTY;
                      Stockinitem.UNIT = StockinitemD.UNIT;
                      Stockinitem.USEQTY = StockinitemD.USEQTY;
                      Stockinitem.MATERIALMASTER = StockinitemD.MATERIALMASTER;
                      Stockinitem.GUARANTEE = StockinitemD.GUARANTEE;

                      ret = Stockinitem.InsertCurrentData(userID, trans.Trans);
                      if (!ret)
                      {
                          _error = Stockinitem.ErrorMessage;
                          break;
                      }
                  }

                  _LOID = ftDAL.LOID;
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

      public bool UpdateData(VStockInData ftData, string userID)
      {
          zTran trans = new zTran();
          trans.CreateTransaction();

          bool ret = true;

          try
          {
              StockInDAL ftDAL = new StockInDAL();
              ftDAL.GetDataByLOID(ftData.LOID, trans.Trans);
              ftDAL.DIVISION = ftData.DIVISION;
              ftDAL.DOCTYPE = ftData.DOCTYPE;
              ftDAL.STATUS = ftData.STATUS;
              ftDAL.STOCKINDATE = ftData.STOCKINDATE;
              ftDAL.WAREHOUSE = ftData.WAREHOUSE;
              ftData.PLANORDER = ftData.PLANORDER;
              ftDAL.SAPWAREHOUSE = ftData.SAPWAREHOUSE;
              ret = ftDAL.UpdateCurrentData(userID, trans.Trans);
              if (!ret) _error = ftDAL.ErrorMessage;

              if (ret)
              {
                  StockinItemDAL Stockinitem = new StockinItemDAL();
                  Stockinitem.DeleteDataBySTOCKIN(ftDAL.LOID, trans.Trans);
                  for (int i = 0; i < ftData.StockInList.Count; ++i)
                  {

                      StockinItemData StockinitemD = (StockinItemData)ftData.StockInList[i];

                      Stockinitem.STOCKIN = ftDAL.LOID;
                      Stockinitem.PRICE = StockinitemD.PRICE;
                      Stockinitem.QTY = StockinitemD.QTY;
                      Stockinitem.LOTNO = StockinitemD.LOTNO;
                      Stockinitem.SAPPOCODE = StockinitemD.SAPPOCODE;
                      Stockinitem.SAPPODATE = StockinitemD.SAPPODATE;
                      Stockinitem.PLANREMAINQTY = StockinitemD.PLANREMAINQTY;
                      Stockinitem.UNIT = StockinitemD.UNIT;
                      Stockinitem.USEQTY = StockinitemD.USEQTY;
                      Stockinitem.MATERIALMASTER = StockinitemD.MATERIALMASTER;
                      Stockinitem.GUARANTEE = StockinitemD.GUARANTEE;

                      ret = Stockinitem.InsertCurrentData(userID, trans.Trans);
                      if (!ret)
                      {
                          _error = Stockinitem.ErrorMessage;
                          break;
                      }
                  }
                  _LOID = ftDAL.LOID;
              }

              if (ftDAL.STATUS == "AP" && ret == true)
                  ret = ftDAL.CutStock(ftDAL.LOID, trans.Trans);

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

      public VStockInData GetDetails(double LOID)
        {
            VStockInDAL fDAL = new VStockInDAL();
            VStockInData fData = new VStockInData();
            VStockinitemPoDAL StockinItem = new VStockinitemPoDAL();
            fDAL.GetDataByLOID(LOID, null);
            if (fDAL.OnDB)
            {
                fData.LOID = fDAL.LOID;
                fData.CODE = fDAL.CODE;
                fData.WAREHOUSE = fDAL.WAREHOUSE; 
                fData.PLANORDER = fDAL.PLANORDER;
                fData.PLANMATERIALCLASS = fDAL.PLANMATERIALCLASS;
                fData.MATERIALCLASS = fDAL.MATERIALCLASS;
                fData.STATUS = fDAL.STATUS;
                fData.DOCTYPE = fDAL.DOCTYPE;
                fData.DOCLOID = fDAL.DOCLOID;
                fData.STOCKINDATE = fDAL.STOCKINDATE;
                fData.REFCODE = fDAL.REFCODE;
                fData.SAPWAREHOUSE = fDAL.SAPWAREHOUSE;
                fData.DOCNAME = fDAL.DOCNAME;
                fData.STATUSNAME = fDAL.STATUSNAME;

                fData.StockInTable = StockinItem.GetDataListBySTOCKIN(LOID, "LOID", null);


            }
            else
                _error = Data.Common.Utilities.DataResources.MSGEV002;

            return fData;

      }

    }


    
}
