using System;
using System.Collections.Generic;
using System.Text;
using System.Data;
using SHND.DAL.Views;
using SHND.Data.Views;
using SHND.DAL.Utilities;
using SHND.DAL.Formula ;
using System.Collections;
//using DB = SHND.DAL.Utilities.OracleDB;
using zTran = SHND.DAL.Utilities.OracleTransactionDB;

/// <summary>
/// FoodTypeFlow Class
/// Version 1.0
/// =========================================================================
/// Create by: Somsakoon
/// Create Date: 27 Mar 2009
/// -------------------------------------------------------------------------
/// Modify By: -
/// Modify From: -
/// Modify Date: -
/// -------------------------------------------------------------------------
/// Remark: -
/// Description:
///    Flow จัดการการทำงานของหน้า FoodTypePrice 
/// Changes:
///    1.0 - สร้าง
/// -------------------------------------------------------------------------
/// =========================================================================
/// </summary>
/// 

namespace SHND.Flow.Formula
{
   public class FoodTypePriceFlow
    {
        string _error = "";
        public string ErrorMessage { get { return _error; } }


        public DataTable GetMasterList(string Name, string Division, string OrderText)
        {
            VFoodTypePriceDAL vDAL = new VFoodTypePriceDAL();
            return vDAL.GetDataListByCondition(Name, Division, OrderText, null);
        }

       public VFoodTypePriceData GetDetails(double LOID)
       {
           VFoodTypePriceDAL fDAL = new VFoodTypePriceDAL();
           VFoodTypePriceData fData = new VFoodTypePriceData();
           fDAL.GetDataByLOID(LOID, null);
           if (fDAL.OnDB)
           {
               fData.CODE = fDAL.CODE;
               fData.NAME = fDAL.NAME;
               
               fData.DIVISIONNAME = fDAL.DIVISIONNAME;
               fData.ACTIVE = fDAL.ACTIVE;
               fData.LOID = fDAL.LOID;
               fData.PRICE = fDAL.PRICE;
               fData.PRICETYPE = fDAL.PRICETYPE;
           }
           else
               _error = Data.Common.Utilities.DataResources.MSGEV002;

           return fData;

       }
       public bool UpdateData(ArrayList arrData, string UserID)
       {
           zTran trans = new zTran();
           trans.CreateTransaction();
           bool ret = true;
           FoodTypeDAL ftDAL = new FoodTypeDAL();
         
           try
           {
               for (int i = 0; i < arrData.Count; i++)
               {
                   VFoodTypePriceData VFoodTypePrice = (VFoodTypePriceData)arrData[i];
                  // FoodTypePriceList += (FoodTypePriceList == "" ? "" : ",") + "'" + VFoodTypePrice.LOID + "'";
                   ftDAL.GetDataByLOID(VFoodTypePrice.LOID, trans.Trans);
                   ftDAL.PRICE = VFoodTypePrice.PRICE;
                   ftDAL.PRICETYPE = VFoodTypePrice.PRICETYPE;

                   ret = ftDAL.UpdateCurrentData(UserID, trans.Trans);
                   if (!ret)
                   {
                       _error = ftDAL.ErrorMessage;
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
               ret = false;
               trans.RollbackTransaction();
               _error = ex.Message;
           }
           return ret;
       }



    }
}
