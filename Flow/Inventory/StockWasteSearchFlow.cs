using System;
using System.Collections.Generic;
using System.Text;
using System.Data;
//using DB = SHND.DAL.Utilities.OracleDB;
using zTran = SHND.DAL.Utilities.OracleTransactionDB;
using SHND.DAL.Views;
using SHND.DAL.Tables;
using SHND.Data.Views;
using System.Collections;


/// <summary>
/// Supplier Class
/// Version 1.0
/// =========================================================================
/// Create by: Somsakoon
/// Create Date: 12 Feb 2009
/// -------------------------------------------------------------------------
/// Modify By: -
/// Modify From: -
/// Modify Date: -
/// -------------------------------------------------------------------------
/// Remark: -
/// Description:
///    Flow จัดการการทำงานของหน้า StockWasteSearch 
/// Changes:
///    1.0 - สร้าง
/// -------------------------------------------------------------------------
/// =========================================================================
/// </summary>
/// 

namespace SHND.Flow.Inventory
{
    public class StockWasteSearchFlow
    {
        string _error = "";
        public string ErrorMessage { get { return _error; } }

        public DataTable GetMasterList(string Code, string Codet, DateTime Date, DateTime Datet, double WareHo, string Status, string Statust, double Doctype, string OrderText)
        {
            VStockOutDAL vDAL = new VStockOutDAL();
            return vDAL.GetDataListByCondisionsSearch (WareHo, Doctype, 0, Code, Codet, Date, Datet, Status, Statust, OrderText, null);
        }

        public bool DeleteByLOID(ArrayList arrLOID)
        {
            zTran trans = new zTran();

            StockOutDAL fDAL = new StockOutDAL();
            StockoutitemDAL Stockoutitem = new StockoutitemDAL();
            trans.CreateTransaction();
            bool ret = true;
            try
            {
                for (int i = 0; i < arrLOID.Count; i++)
                {
                    Stockoutitem.DeleteDataBySTOCKOUT(Convert.ToDouble(arrLOID[i]), trans.Trans);
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






    }
}
