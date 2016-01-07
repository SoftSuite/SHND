using System;
using System.Collections.Generic;
using System.Text;
using System.Data;
using SHND.DAL.Tables;
using SHND.DAL.Views;
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
/// Create Date: 29 Dec 2008
/// -------------------------------------------------------------------------
/// Modify By: -
/// Modify From: -
/// Modify Date: -
/// -------------------------------------------------------------------------
/// Remark: -
/// Description:
///    Flow จัดการการทำงานของหน้า DiseaseCategory 
/// Changes:
///    1.0 - สร้าง
/// -------------------------------------------------------------------------
/// =========================================================================
/// </summary>
/// 
namespace SHND.Flow.Formula
{
    public class DiseaseCategoryFlow
    {
        string _error = "";
        public string ErrorMessage { get { return _error; } }


        public DataTable GetMasterList(string Name, string Description, string Active, string cDiseaseCategory, string OrderText)
        {
            VDiseaseCategoryDAL vDAL = new VDiseaseCategoryDAL();
            return vDAL.GetDataListByCondition(Name, Description, Active, "", "", "", "", "", "", "",cDiseaseCategory, "", "", OrderText, null);
        }

        public DataTable GetMasterList()
        {
            VDiseaseCategoryDAL vDAL = new VDiseaseCategoryDAL();
            return vDAL.GetDataList("", "", null);
        }

        public DataTable GetMasterListByCondition(string Code, string Name, string Devision)
        {
            string whStr = "";
            // create where condition


            VDiseaseCategoryDAL vDAL = new VDiseaseCategoryDAL();
            return vDAL.GetDataList(whStr, "", null);
        }

        public DataTable GetMasterListSorted(string SortField, string SortDirection)
        {
            VDiseaseCategoryDAL vDAL = new VDiseaseCategoryDAL();
            return vDAL.GetDataList("", SortField + " " + SortDirection, null);
        }

        public bool InsertData(DiseaseCategoryData dcData, string UserID)
        {
            DiseaseCategoryDAL dcDAL = new DiseaseCategoryDAL();
            dcDAL.ABBNAME = dcData.ABBNAME;
            dcDAL.DESCRIPTION = dcData.DESCRIPTION;
            dcDAL.ACTIVE = (dcData.ACTIVE ? "1" : "0");
            dcDAL.ISREGULAR = (dcData.ISREGULAR ? "Y" : "N");
            dcDAL.ISSOFT = (dcData.ISSOFT ? "Y" : "N");
            dcDAL.ISMILK = (dcData.ISMILK ? "Y" : "N");
            dcDAL.ISLIGHT = (dcData.ISLIGHT ? "Y" : "N");
            dcDAL.ISLIQUID = (dcData.ISLIQUID ? "Y" : "N");
            dcDAL.ISSPECIAL = (dcData.ISSPECIAL ? "Y" : "N");
            dcDAL.ISLIMIT = (dcData.ISLIMIT ? "Y" : "N");
            dcDAL.ISCALCULATE = (dcData.ISCALCULATE ? "Y" : "N");
            dcDAL.ISINCREASE = (dcData.ISINCREASE ? "Y" : "N");
            dcDAL.ISNEED = (dcData.ISNEED ? "Y" : "N");
            dcDAL.ISABSTAIN = (dcData.ISABSTAIN ? "Y" : "N");
            dcDAL.ISREQUEST = (dcData.ISREQUEST ? "Y" : "N");
            dcDAL.ISHIGH = (dcData.ISHIGH ? "Y" : "N");
            dcDAL.ISLOW = (dcData.ISLOW ? "Y" : "N");
            dcDAL.ISNON = (dcData.ISNON ? "Y" : "N");
            dcDAL.UNIT = dcData.UNIT;
            bool ret = true;

            try
            {
                ret = dcDAL.InsertCurrentData(UserID, null);
                if (!ret) _error = dcDAL.ErrorMessage;
            }
            catch (Exception ex)
            {
                ret = false;
                _error = ex.Message;
            }

            return ret;
        }

        public bool UpdateData(DiseaseCategoryData dcData, string UserID)
        {
            DiseaseCategoryDAL dcDAL = new DiseaseCategoryDAL();
            dcDAL.GetDataByLOID(dcData.LOID, null);

            dcDAL.ABBNAME = dcData.ABBNAME;
            dcDAL.DESCRIPTION = dcData.DESCRIPTION;
            dcDAL.ACTIVE = (dcData.ACTIVE ? "1" : "0");
            dcDAL.ISREGULAR = (dcData.ISREGULAR ? "Y" : "N");
            dcDAL.ISSOFT = (dcData.ISSOFT ? "Y" : "N");
            dcDAL.ISMILK = (dcData.ISMILK ? "Y" : "N");
            dcDAL.ISLIGHT = (dcData.ISLIGHT ? "Y" : "N");
            dcDAL.ISLIQUID = (dcData.ISLIQUID ? "Y" : "N");
            dcDAL.ISSPECIAL = (dcData.ISSPECIAL ? "Y" : "N");
            dcDAL.ISLIMIT = (dcData.ISLIMIT ? "Y" : "N");
            dcDAL.ISCALCULATE = (dcData.ISCALCULATE ? "Y" : "N");
            dcDAL.ISINCREASE = (dcData.ISINCREASE ? "Y" : "N");
            dcDAL.ISNEED = (dcData.ISNEED ? "Y" : "N");
            dcDAL.ISABSTAIN = (dcData.ISABSTAIN ? "Y" : "N");
            dcDAL.ISREQUEST = (dcData.ISREQUEST ? "Y" : "N");
            dcDAL.ISHIGH = (dcData.ISHIGH ? "Y" : "N");
            dcDAL.ISLOW = (dcData.ISLOW ? "Y" : "N");
            dcDAL.ISNON = (dcData.ISNON ? "Y" : "N");
            dcDAL.UNIT = dcData.UNIT;
            bool ret = true;

            try
            {
                if (dcDAL.OnDB)
                {
                    ret = dcDAL.UpdateCurrentData(UserID, null);
                    if (!ret) _error = dcDAL.ErrorMessage;

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

        public DiseaseCategoryData GetDetails(double LOID)
        {
            DiseaseCategoryDAL dcDAL = new DiseaseCategoryDAL();
            DiseaseCategoryData dcData = new DiseaseCategoryData();
            dcDAL.GetDataByLOID(LOID, null);
            if (dcDAL.OnDB)
            {
                dcData.ABBNAME = dcDAL.ABBNAME;
                dcData.DESCRIPTION = dcDAL.DESCRIPTION;
                dcData.ACTIVE = (dcDAL.ACTIVE == "1");
                dcData.ISREGULAR = (dcDAL.ISREGULAR == "Y");
                dcData.ISSOFT = (dcDAL.ISSOFT == "Y");
                dcData.ISMILK = (dcDAL.ISMILK == "Y");
                dcData.ISLIGHT = (dcDAL.ISLIGHT == "Y");
                dcData.ISLIQUID = (dcDAL.ISLIQUID == "Y");
                dcData.ISSPECIAL = (dcDAL.ISSPECIAL == "Y");
                dcData.ISLIMIT = (dcDAL.ISLIMIT == "Y");
                dcData.ISCALCULATE = (dcDAL.ISCALCULATE == "Y");
                dcData.ISINCREASE = (dcDAL.ISINCREASE == "Y");
                dcData.ISABSTAIN = (dcDAL.ISABSTAIN == "Y");
                dcData.ISNEED = (dcDAL.ISNEED == "Y");
                dcData.ISREQUEST = (dcDAL.ISREQUEST == "Y");
                dcData.ISHIGH = (dcDAL.ISHIGH == "Y");
                dcData.ISLOW = (dcDAL.ISLOW == "Y");
                dcData.ISNON = (dcDAL.ISNON == "Y");
                dcData.LOID = dcDAL.LOID;
                dcData.UNIT = dcDAL.UNIT;
            }
            else
                _error = Data.Common.Utilities.DataResources.MSGEV002;

            return dcData;

        }

        public bool DeleteByLOID(ArrayList arrLOID)
        {
            zTran trans = new zTran();

            DiseaseCategoryDAL dcDAL = new DiseaseCategoryDAL();
            trans.CreateTransaction();
            bool ret = true;
            try
            {
                for (int i = 0; i < arrLOID.Count; i++)
                {
                    dcDAL.DeleteDataByLOID(Convert.ToDouble(arrLOID[i]), trans.Trans);
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

        public bool CheckUniqCode(string cName, string cLOID)
        {
            DiseaseCategoryDAL dcDAL = new DiseaseCategoryDAL();
            dcDAL.GetDataByABBNAME(cName, null);
            return !dcDAL.OnDB || (cLOID == dcDAL.LOID.ToString());
        }

    }
}
