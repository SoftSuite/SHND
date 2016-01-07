using System;
using System.Collections.Generic;
using System.Text;
using System.Data;
using SHND.DAL.Views;
using SHND.DAL.Tables;
using System.Data.OracleClient;
using zTran = SHND.DAL.Utilities.OracleTransactionDB;
using System.Collections;

/// <summary>
/// PrepareReturnFlow Class
/// Version 1.0
/// =========================================================================
/// Create by: Pom
/// Create Date: 12 Mar 2009
/// -------------------------------------------------------------------------
/// Modify By: -
/// Modify From: -
/// Modify Date: -
/// -------------------------------------------------------------------------
/// Remark: -
/// Description:
///    Flow จัดการการทำงานของหน้า PrepareReturn
/// Changes:
///    1.0 - สร้าง
/// -------------------------------------------------------------------------
/// =========================================================================
/// </summary>
/// 

namespace SHND.Flow.Prepare
{
    public class PrepareReturnFlow
    {
        string _error = "";
        public string ErrorMessage { get { return _error; } }
        double _loid = 0;
        public double LOID { get { return _loid; } }
        string _code = "";
        public string CODE { get { return _code; } }

        public DataTable GetPrepareReturnList(string codefrom, string codeto, string datefrom, string dateto, string division, string doctype, string materialclass, string statusfrom, string statusto, string orderstr)
        {
            VPrepareReturnDAL vDAL = new VPrepareReturnDAL();
            string whStr = "";

            if (codefrom != "" && codeto != "")
                whStr += (whStr.Trim() == "" ? "" : " AND ") + " CODE BETWEEN '" + codefrom + "' AND '" + codeto + "'";
            else if (codefrom != "")
                whStr += (whStr.Trim() == "" ? "" : " AND ") + " CODE >= '" + codefrom + "'";
            else if (codeto != "")
                whStr += (whStr.Trim() == "" ? "" : " AND ") + " CODE <= '" + codeto + "'";

            if (datefrom != "" && dateto != "")
                whStr += (whStr.Trim() == "" ? "" : " AND ") + " TO_CHAR(INFORMDATE,'YYYY/MM/DD') BETWEEN '" + datefrom + "' AND '" + dateto + "'";
            else if (datefrom != "")
                whStr += (whStr.Trim() == "" ? "" : " AND ") + " TO_CHAR(INFORMDATE,'YYYY/MM/DD') >= '" + datefrom + "'";
            else if (dateto != "")
                whStr += (whStr.Trim() == "" ? "" : " AND ") + " TO_CHAR(INFORMDATE,'YYYY/MM/DD') <= '" + dateto + "'";
            
            if (division != "0")
                whStr += (whStr.Trim() == "" ? "" : " AND ") + " DIVISION = " + division + " ";
            if (doctype != "0")
                whStr += (whStr.Trim() == "" ? "" : " AND ") + " DOCTYPE = " + doctype + " ";
            if (materialclass != "0")
                whStr += (whStr.Trim() == "" ? "" : " AND ") + " MATERIALCLASS = " + materialclass + " ";

            whStr += (whStr.Trim() == "" ? "" : " AND ") + " STATUSRANK BETWEEN FN_STATUSNAME('" + statusfrom + "', 'PREPARERETURN', 1) AND FN_STATUSNAME('" + statusto + "', 'PREPARERETURN', 1)";

            if (orderstr == "")
                orderstr = " CODE ASC";

            return vDAL.GetDataList(whStr, orderstr, null);
        }

        public bool UpdatePrepareReturnStatus(string code, string UserID)
        {
            PrepareReturnDAL pDAL = new PrepareReturnDAL();
            pDAL.GetDataByCODE(code, null);

            try
            {
                if (pDAL.OnDB)
                {
                    pDAL.STATUS = "FN";
                    if (pDAL.UpdateCurrentData(UserID, null) == true)
                        return true;
                    else
                    {
                        _error = pDAL.ErrorMessage;
                        return false;
                    }
                }
                else
                {
                    _error = Data.Common.Utilities.DataResources.MSGEU002;
                    return false;
                }
            }
            catch(Exception ex)
            {
                _error = ex.Message;
                return false;
            }  
        }

        public double GetStockOutQty(string division, string material, string unitloid)
        {
            PrepareReturnDAL pDAL = new PrepareReturnDAL();
            return pDAL.GetStockOutQty(division, material, unitloid);
        }

        public DataTable GetPrepareReturn(string code)
        {
            VPrepareReturnDAL pDAL = new VPrepareReturnDAL();
            string whStr = "";

            whStr += "CODE = '" + code + "'";
            return pDAL.GetDataList(whStr, "", null);
        }


        public DataTable GetPrepareReturnItemList(string code)
        {
            VPrepareReturnItemDAL pDAL = new VPrepareReturnItemDAL();
            string whStr = "";

            whStr += "PREPARERETURNCODE = '" + code + "'";
            return pDAL.GetDataList(whStr, "MATERIALNAME", null);
        }

        public bool InsertData(string division, string materialclass, string doctype, DataTable dtPrepareItemData, string UserID)
        {
            zTran trans = new zTran();
            PrepareReturnDAL pDAL = new PrepareReturnDAL();

            pDAL.INFORMDATE = DateTime.Now;
            pDAL.DOCTYPE = Convert.ToDouble(doctype);
            pDAL.DIVISION = Convert.ToDouble(division);
            pDAL.MATERIALCLASS = Convert.ToDouble(materialclass);
            pDAL.STATUS = "WA";

            bool ret = true;
            trans.CreateTransaction();

            try
            {
                ret = pDAL.InsertCurrentData(UserID, trans.Trans);
                if (!ret)
                {
                    trans.RollbackTransaction();
                    _error = pDAL.ErrorMessage;
                    ret = false;
                }
                else
                {
                    _loid = pDAL.LOID;
                    _code = pDAL.CODE;

                    if (dtPrepareItemData != null)
                    {
                        //insert ลง table PrepareReturnItem มี FK เป็น PrepareReturn
                        if (UpdatePrepareReturnItem(_loid, dtPrepareItemData, trans, UserID) == true)
                        {
                            trans.CommitTransaction();
                            ret = true;
                        }
                        else
                        {
                            trans.RollbackTransaction();
                            ret = false;
                        }
                    }
                    else
                    {
                        trans.CommitTransaction();
                        ret = true;
                    }
                }
            }
            catch (Exception ex)
            {
                ret = false;
                trans.RollbackTransaction();
                _error = ex.Message;
            }

            return ret;
        }

        private bool UpdatePrepareReturnItem(double preparereturn_loid, DataTable dtPrepareItemData, zTran trans, string UserID)
        {
            bool ret = true;
            string prloidlist = "";

            try
            {
                if (dtPrepareItemData.Rows.Count > 0)
                {
                    for (int i = 0; i < dtPrepareItemData.Rows.Count; i++)
                    {
                        if (dtPrepareItemData.Rows[i]["PILOID"].ToString() != "")
                            prloidlist += (prloidlist == "" ? "" : ",") + dtPrepareItemData.Rows[i]["PILOID"].ToString();
                    }
                }

                //ลบ preparereturnitem ที่ไม่ได้อยู่ใน list
                ret = DeletePrepareReturnItemNotInList(prloidlist, preparereturn_loid, trans);
                if (ret)
                {
                    ret = doUpdatePrepareReturnItem(preparereturn_loid, dtPrepareItemData, trans, UserID);
                    if (ret)
                    {
                        return true;
                    }
                    else
                    {
                        return false;
                    }
                }
                else
                {
                    return false;
                }
            }
            catch (Exception ex)
            {
                _error = ex.Message;
                ret = false;
            }

            return ret;
        }

        private bool DeletePrepareReturnItemNotInList(string prloidlist, double preparereturn_loid, zTran trans)
        {
            bool ret = true;
            PrepareReturnItemDAL piDAL = new PrepareReturnItemDAL();
            ret = piDAL.DeleteNotInLOIDList(prloidlist, preparereturn_loid.ToString(), trans.Trans);
            if (ret)
                return true;
            else
            {
                _error = piDAL.ErrorMessage;
                return false;
            }
        }

        private bool doUpdatePrepareReturnItem(double preparereturn_loid, DataTable dtPrepareItemData, zTran trans, string UserID)
        {
            bool ret = true;

            for (int i = 0; i < dtPrepareItemData.Rows.Count; i++)
            {
                if (dtPrepareItemData.Rows[i]["PILOID"].ToString() == "")
                {
                    PrepareReturnItemDAL piDAL = new PrepareReturnItemDAL();
                    piDAL.PREPARERETURN = preparereturn_loid;
                    piDAL.MATERIALMASTER = Convert.ToDouble(dtPrepareItemData.Rows[i]["MMLOID"]);
                    piDAL.UNIT = Convert.ToDouble(dtPrepareItemData.Rows[i]["UNITLOID"]);
                    piDAL.STOCKOUTQTY = Convert.ToDouble(dtPrepareItemData.Rows[i]["STOCKOUTQTY"]);
                    piDAL.QTY = Convert.ToDouble(dtPrepareItemData.Rows[i]["QTY"]);

                    ret = piDAL.InsertCurrentData(UserID, trans.Trans);

                    if (ret == false)
                    {
                        _error = piDAL.ErrorMessage;
                        return false;
                    }
                }
                else
                {
                    PrepareReturnItemDAL piDAL = new PrepareReturnItemDAL();
                    piDAL.GetDataByLOID(Convert.ToDouble(dtPrepareItemData.Rows[i]["PILOID"].ToString()), trans.Trans);
                    piDAL.PREPARERETURN = preparereturn_loid;
                    piDAL.MATERIALMASTER = Convert.ToDouble(dtPrepareItemData.Rows[i]["MMLOID"]);
                    piDAL.UNIT = Convert.ToDouble(dtPrepareItemData.Rows[i]["UNITLOID"]);
                    piDAL.STOCKOUTQTY = Convert.ToDouble(dtPrepareItemData.Rows[i]["STOCKOUTQTY"]);
                    piDAL.QTY = Convert.ToDouble(dtPrepareItemData.Rows[i]["QTY"]);

                    ret = piDAL.UpdateCurrentData(UserID, trans.Trans);

                    if (ret == false)
                    {
                        _error = piDAL.ErrorMessage;
                        return false;
                    }
                }
            }

            return true;
        }

        public bool UpdateData(string code, string division, string materialclass, string doctype, DataTable dtPrepareItemData, string UserID)
        {
            zTran trans = new zTran();
            PrepareReturnDAL pDAL = new PrepareReturnDAL();

            pDAL.GetDataByCODE(code, null);
            pDAL.DOCTYPE = Convert.ToDouble(doctype);
            pDAL.DIVISION = Convert.ToDouble(division);
            pDAL.MATERIALCLASS = Convert.ToDouble(materialclass);

            bool ret = true;
           
            try
            {
                if (pDAL.OnDB)
                {
                    trans.CreateTransaction();

                    ret = pDAL.UpdateCurrentData(UserID, trans.Trans);
                    if (!ret)
                    {
                        trans.RollbackTransaction();
                        _error = pDAL.ErrorMessage;
                        ret = false;
                    }
                    else
                    {
                        _loid = pDAL.LOID;
                        _code = pDAL.CODE;

                        if (dtPrepareItemData != null)
                        {
                            //insert ลง table PrepareReturnItem มี FK เป็น PrepareReturn
                            if (UpdatePrepareReturnItem(_loid, dtPrepareItemData, trans, UserID) == true)
                            {
                                trans.CommitTransaction();
                                ret = true;
                            }
                            else
                            {
                                trans.RollbackTransaction();
                                ret = false;
                            }
                        }
                        else
                        {
                            trans.CommitTransaction();
                            ret = true;
                        }
                    }
                }
                else
                {
                    _error = Data.Common.Utilities.DataResources.MSGEU002;
                    ret = false;
                }
            }
            catch (Exception ex)
            {
                ret = false;
                trans.RollbackTransaction();
                _error = ex.Message;
            }

            return ret;
        }

        public bool DeletePrepareReturnByLOID(ArrayList arrLOID)
        {
            zTran trans = new zTran();
            PrepareReturnDAL pDAL = new PrepareReturnDAL();
            PrepareReturnItemDAL piDAL = new PrepareReturnItemDAL();
            bool ret = true;
            string whrStr = "";

            try
            {
                trans.CreateTransaction();

                for (int i = 0; i < arrLOID.Count; i++)
                {
                    whrStr = " PREPARERETURN = " + arrLOID[i].ToString();
                    ret = piDAL.DeletePrepareReturnItem(whrStr, trans.Trans);
                    if (ret == true)
                    {
                        pDAL.GetDataByLOID(Convert.ToDouble(arrLOID[i]), trans.Trans);
                        if (pDAL.OnDB)
                        {
                            ret = pDAL.DeleteCurrentData(trans.Trans);
                            if (ret == false)
                            {
                                trans.RollbackTransaction();
                                _error = pDAL.ErrorMessage;
                                return false;
                            }
                        }
                        else
                        {
                            trans.RollbackTransaction();
                            _error = Data.Common.Utilities.DataResources.MSGEU002;
                            return false;
                        }
                    }
                    else
                    {
                        trans.RollbackTransaction();
                        _error = piDAL.ErrorMessage;
                        return false;
                    }
                }

                if (ret == true)
                {
                    trans.CommitTransaction();
                    return true;
                }
                else
                {
                    trans.RollbackTransaction();
                    return false;
                }
            }
            catch (Exception ex)
            {
                trans.RollbackTransaction();
                _error = ex.Message;
                return false;
            }
        }
    }
}
