using System;
using System.Collections;
using System.Collections.Generic;
using System.Data;
using System.Data.OracleClient;
using System.Text;
using SHND.DAL.Formula;
using SHND.DAL.Tables;
using SHND.DAL.Views;
using SHND.Data.Formula;
using SHND.Data.Tables;
using zTran = SHND.DAL.Utilities.OracleTransactionDB;

/// <summary>
/// Supplier Class
/// Version 1.0
/// =========================================================================
/// Create by: Somsakoon
/// Create Date: 13 Jan 2009
/// -------------------------------------------------------------------------
/// Modify By: -
/// Modify From: -
/// Modify Date: -
/// -------------------------------------------------------------------------
/// Remark: -
/// Description:
///    Flow จัดการการทำงานของหน้า OrderWelfareItem
/// Changes:
///    1.0 - สร้าง
/// -------------------------------------------------------------------------
/// =========================================================================
/// </summary>
/// 

namespace SHND.Flow.Inventory
{
    public class OrderWelfareItemFlow
    {
        string _error = "";
        public string ErrorMessage { get { return _error; } }

        public DataTable GetMasterList()
        {
            orderwelfaredetailDAL vDAL = new orderwelfaredetailDAL();
            return vDAL.GetDataList("", "", null);

        }
        public bool InsertData (OrderWelfareItemData ftData, string UserID)
        {
            OrderWelfareItemDAL ftDAL = new OrderWelfareItemDAL();
            ftDAL.ORDERWELFARE = ftData.ORDERWELFARE;
            ftDAL.CREATEBY = ftData.CREATEBY;
            ftDAL.CREATEON = ftData.CREATEON;
            ftDAL.LOID = ftData.LOID;
            ftDAL.QTY = ftData.QTY;
            ftDAL.SUBDIVISION = ftData.SUBDIVISION;
            ftDAL.UPDATEBY = ftData.UPDATEBY;
            ftDAL.UPDATEON = ftData.UPDATEON;
            bool ret = true;

            try
            {
                ret = ftDAL.InsertCurrentData(UserID, null);
                if (!ret) _error = ftDAL.ErrorMessage;
            }
            catch (Exception ex)
            { 
                ret = false;
                _error = ex.Message;
            }

            return ret;
        }

        public bool InsertDataItem(ArrayList arrItem, string userID, double SetID, OracleTransaction trans)
        {
            bool ret = true;
            OrderWelfareItemDAL sDAL = new OrderWelfareItemDAL();
            sDAL.DeleteDataByCondition("QTY", SetID,trans );
            

            for (int i = 0; i < arrItem .Count ; ++i)
            {
                sDAL = new OrderWelfareItemDAL();
                OrderWelfareItemData sData = (OrderWelfareItemData)arrItem[i];
                sDAL.QTY = Convert.ToDouble ("QTY");
                sDAL.LOID = SetID;
                sDAL.SUBDIVISION = sData.SUBDIVISION;
                sDAL.ORDERWELFARE = sData.ORDERWELFARE;


              /* FormulaDisease = new FormulaDiseaseDAL();
                FormulaDiseaseData datFormulaDisease = (FormulaDiseaseData)arrFormulaDisease[i];
                FormulaDisease.DISEASECATEGORY = datFormulaDisease.DISEASECATEGORY;
                FormulaDisease.REFLOID = FormulaSetID;
                FormulaDisease.REFTABLE = "FORMULASET";
                ret = FormulaDisease.InsertCurrentData(userID, trans);*/
                ret = sDAL.InsertCurrentData(userID, trans);
                if (!ret)
                {
                    _error = sDAL.ErrorMessage;
                   // _error = FormulaDisease.ErrorMessage;
                    break;
                }
            }
            return ret;
        }

    }
}
