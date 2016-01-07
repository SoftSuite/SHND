using System;
using System.Collections.Generic;
using System.Text;
using System.Data;
using SHND.DAL.Tables;
using SHND.Data.Tables;
using System.Collections;
using zTran = SHND.DAL.Utilities.OracleTransactionDB;

/// <summary>
/// UnitFlow Class
/// Version 1.0
/// =========================================================================
/// Create by: Nang
/// Create Date: 5 Jan 2009
/// -------------------------------------------------------------------------
/// Modify By: -
/// Modify From: -
/// Modify Date: -
/// -------------------------------------------------------------------------
/// Remark: -
/// Description:
///    Flow จัดการการทำงานของหน้า Unit 
/// Changes:
///    1.0 - สร้าง
/// -------------------------------------------------------------------------
/// =========================================================================
/// </summary>
/// 


namespace SHND.Flow.Inventory
{
    public class UnitFlow
    {
        string _error = "";
        public string ErrorMessage { get { return _error; } }

        public DataTable GetUnitSearch(string thai, string eng, string ordertext)
        {
            UnitDAL UDal = new UnitDAL();
            string wr = "";
            if (thai != "")
                wr = wr + "UPPER(THNAME) LIKE UPPER('%"+ thai +"%')";

            if (eng != "")
                wr = wr + "UPPER(ENNAME) LIKE UPPER('%" + eng + "%')";

            return UDal.GetDataList_ByField(wr, ordertext, null);
        }

        public UnitData GetDetails(double LOID)
        {
            UnitDAL uDAL = new UnitDAL();
            UnitData uData = new UnitData();
            uDAL.GetDataByLOID(LOID, null);
            if (uDAL.OnDB)
            {
                uData.CODE = uDAL.CODE;
                uData.THNAME = uDAL.THNAME;
                uData.ENNAME = uDAL.ENNAME;
                uData.ACTIVE = (uDAL.ACTIVE == "1");
                uData.LOID = uDAL.LOID;
                uData.ABBNAME = uDAL.ABBNAME;
            }
            else
                _error = Data.Common.Utilities.DataResources.MSGEU002;

            return uData;
        }

        public bool CheckUniqThai(string cThai,string cLOID)
        {
            UnitDAL uDAL = new UnitDAL();
            uDAL.GetDataByTHNAME(cThai, null);
            return !uDAL.OnDB || (cLOID == uDAL.LOID.ToString());
        }

        public bool CheckUniqEng(string cEng, string cLOID)
        {
            UnitDAL uDAL = new UnitDAL();
            uDAL.GetDataByENNAME(cEng, null);
            return !uDAL.OnDB || (cLOID == uDAL.LOID.ToString());
        }

        public bool InsertData(UnitData  uData, string UserID)
        {
            UnitDAL uDAL = new UnitDAL();
            uDAL.THNAME = uData.THNAME;
            uDAL.ENNAME = uData.ENNAME;
            uDAL.ABBNAME = uData.ABBNAME;
            uDAL.ACTIVE = (uData.ACTIVE ? "1" : "0");

            bool ret = true;

            try
            {
                ret = uDAL.InsertCurrentData(UserID, null);
                if (!ret) _error = uDAL.ErrorMessage;
            }
            catch (Exception ex)
            {
                ret = false;
                _error = ex.Message;
            }

            return ret;
        }

        public bool UpdateData(UnitData  uData, string UserID)
        {
            UnitDAL uDAL = new UnitDAL();
            uDAL.GetDataByLOID(uData.LOID, null);

            uDAL.THNAME = uData.THNAME ;
            uDAL.ENNAME = uData.ENNAME ;
            uDAL.ABBNAME = uData.ABBNAME;
            uDAL.ACTIVE = (uData.ACTIVE ? "1" : "0");
            bool ret = true;

            try
            {
                if (uDAL.OnDB)
                {
                    ret = uDAL.UpdateCurrentData(UserID, null);
                    if (!ret) _error = uDAL.ErrorMessage;

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

        public bool DeleteByLOID(ArrayList arrLOID)
        {
            zTran trans = new zTran();

            UnitDAL uDAL = new UnitDAL();
            trans.CreateTransaction();
            bool ret = true;
            try
            {
                for (int i = 0; i < arrLOID.Count; i++)
                {
                    uDAL.DeleteDataByLOID(Convert.ToDouble(arrLOID[i]), trans.Trans);
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
