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
/// PrepareWeightAfterFlow Class
/// Version 1.0
/// =========================================================================
/// Create by: Pom
/// Create Date: 14 Mar 2009
/// -------------------------------------------------------------------------
/// Modify By: -
/// Modify From: -
/// Modify Date: -
/// -------------------------------------------------------------------------
/// Remark: -
/// Description:
///    Flow จัดการการทำงานของหน้า PrepareWeightAfter
/// Changes:
///    1.0 - สร้าง
/// -------------------------------------------------------------------------
/// =========================================================================
/// </summary>
/// 

namespace SHND.Flow.Prepare
{
    public class PrepareWeightAfterFlow
    {
        string _error = "";
        public string ErrorMessage { get { return _error; } }
        double _loid = 0;
        public double LOID { get { return _loid; } }
        string _code = "";
        public string CODE { get { return _code; } }

        public DataTable GetPrepareWeightAfterList(string codefrom, string codeto, string datefrom, string dateto, string materialclass, string statusfrom, string statusto, string orderstr)
        {
            VPrepareWeightAfterDAL vDAL = new VPrepareWeightAfterDAL();
            string whStr = "";

            if (codefrom != "" && codeto != "")
                whStr += (whStr.Trim() == "" ? "" : " AND ") + " CODE BETWEEN '" + codefrom + "' AND '" + codeto + "'";
            else if (codefrom != "")
                whStr += (whStr.Trim() == "" ? "" : " AND ") + " CODE >= '" + codefrom + "'";
            else if (codeto != "")
                whStr += (whStr.Trim() == "" ? "" : " AND ") + " CODE <= '" + codeto + "'";

            if (datefrom != "" && dateto != "")
                whStr += (whStr.Trim() == "" ? "" : " AND ") + " TO_CHAR(PREPAREDATE,'YYYY/MM/DD') BETWEEN '" + datefrom + "' AND '" + dateto + "'";
            else if (datefrom != "")
                whStr += (whStr.Trim() == "" ? "" : " AND ") + " TO_CHAR(PREPAREDATE,'YYYY/MM/DD') >= '" + datefrom + "'";
            else if (dateto != "")
                whStr += (whStr.Trim() == "" ? "" : " AND ") + " TO_CHAR(PREPAREDATE,'YYYY/MM/DD') <= '" + dateto + "'";

            if (materialclass != "0")
                whStr += (whStr.Trim() == "" ? "" : " AND ") + " MATERIALCLASS = " + materialclass + " ";

            whStr += (whStr.Trim() == "" ? "" : " AND ") + " STATUSRANK BETWEEN FN_STATUSNAME('" + statusfrom + "', 'PREPAREWEIGHTAFTER', 1) AND FN_STATUSNAME('" + statusto + "', 'PREPAREWEIGHTAFTER', 1)";

            if (orderstr == "")
                orderstr = " CODE ASC";

            return vDAL.GetDataList(whStr, orderstr, null);
        }

        public bool UpdatePrepareWeightAfterStatus(string code, string UserID)
        {
            PrepareWeightAfterDAL pDAL = new PrepareWeightAfterDAL();
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
            catch (Exception ex)
            {
                _error = ex.Message;
                return false;
            }
        }

        public bool CheckExist(string materialclass, string date)
        {
            PrepareWeightAfterDAL pDAL = new PrepareWeightAfterDAL();
            return pDAL.CheckExist(materialclass, date);
        }

        public double GetStdWeight(string date, string materialclass, string type)
        {
            PrepareWeightAfterDAL pDAL = new PrepareWeightAfterDAL();
            return pDAL.GetStdWeight(date, materialclass, type);
        }

        public DataTable GetPrepareWeightAfter(string code)
        {
            VPrepareWeightAfterDAL pDAL = new VPrepareWeightAfterDAL();
            string whStr = "";

            whStr += "CODE = '" + code + "'";
            return pDAL.GetDataList(whStr, "", null);
        }

        public DataTable GetPrepareWeightAfterItemList(string code)
        {
            VPrepareWeightAfterItemDAL pDAL = new VPrepareWeightAfterItemDAL();
            string whStr = "";

            whStr += "PREPAREWEIGHTAFTERCODE = '" + code + "'";
            return pDAL.GetDataList(whStr, "MATERIALNAME", null);
        }

        public bool InsertData(string materialclass, DataTable dtPrepareItemData, string UserID)
        {
            zTran trans = new zTran();
            PrepareWeightAfterDAL pDAL = new PrepareWeightAfterDAL();

            pDAL.PREPAREDATE = DateTime.Now;
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
                        //insert ลง table PrepareWeightAfterItem มี FK เป็น PrepareReturn
                        if (UpdatePrepareWeightAfterItem(_loid, dtPrepareItemData, trans, UserID) == true)
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

        private bool UpdatePrepareWeightAfterItem(double prepare_weight_after_loid, DataTable dtPrepareItemData, zTran trans, string UserID)
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
                ret = DeletePrepareWeightAfterItemNotInList(prloidlist, prepare_weight_after_loid, trans);
                if (ret)
                {
                    ret = doUpdatePrepareWeightAfterItem(prepare_weight_after_loid, dtPrepareItemData, trans, UserID);
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

        private bool DeletePrepareWeightAfterItemNotInList(string prloidlist, double prepare_weight_after_loid, zTran trans)
        {
            bool ret = true;
            PrepareWeightAfterItemDAL piDAL = new PrepareWeightAfterItemDAL();
            ret = piDAL.DeleteNotInLOIDList(prloidlist, prepare_weight_after_loid.ToString(), trans.Trans);
            if (ret)
                return true;
            else
            {
                _error = piDAL.ErrorMessage;
                return false;
            }
        }

        private bool doUpdatePrepareWeightAfterItem(double prepare_weight_after_loid, DataTable dtPrepareItemData, zTran trans, string UserID)
        {
            bool ret = true;

            for (int i = 0; i < dtPrepareItemData.Rows.Count; i++)
            {
                if (dtPrepareItemData.Rows[i]["PILOID"].ToString() == "")
                {
                    PrepareWeightAfterItemDAL piDAL = new PrepareWeightAfterItemDAL();
                    piDAL.PREPAREWEIGHTAFTER = prepare_weight_after_loid;
                    piDAL.MATERIALMASTER = Convert.ToDouble(dtPrepareItemData.Rows[i]["MMLOID"]);
                    piDAL.UNIT = Convert.ToDouble(dtPrepareItemData.Rows[i]["UNITLOID"]);
                    piDAL.STDWEIGHTBEFORE = Convert.ToDouble(dtPrepareItemData.Rows[i]["STDWEIGHTBEFORE"]);
                    piDAL.USEWEIGHTBEFORE = Convert.ToDouble(dtPrepareItemData.Rows[i]["USEWEIGHTBEFORE"]);
                    piDAL.STDWEIGHTAFTER = Convert.ToDouble(dtPrepareItemData.Rows[i]["STDWEIGHTAFTER"]);
                    piDAL.USEWEIGHTAFTER = Convert.ToDouble(dtPrepareItemData.Rows[i]["USEWEIGHTAFTER"]);

                    ret = piDAL.InsertCurrentData(UserID, trans.Trans);

                    if (ret == false)
                    {
                        _error = piDAL.ErrorMessage;
                        return false;
                    }
                }
                else
                {
                    PrepareWeightAfterItemDAL piDAL = new PrepareWeightAfterItemDAL();
                    piDAL.GetDataByLOID(Convert.ToDouble(dtPrepareItemData.Rows[i]["PILOID"].ToString()), trans.Trans);
                    piDAL.PREPAREWEIGHTAFTER = prepare_weight_after_loid;
                    piDAL.MATERIALMASTER = Convert.ToDouble(dtPrepareItemData.Rows[i]["MMLOID"]);
                    piDAL.UNIT = Convert.ToDouble(dtPrepareItemData.Rows[i]["UNITLOID"]);
                    piDAL.STDWEIGHTBEFORE = Convert.ToDouble(dtPrepareItemData.Rows[i]["STDWEIGHTBEFORE"]);
                    piDAL.USEWEIGHTBEFORE = Convert.ToDouble(dtPrepareItemData.Rows[i]["USEWEIGHTBEFORE"]);
                    piDAL.STDWEIGHTAFTER = Convert.ToDouble(dtPrepareItemData.Rows[i]["STDWEIGHTAFTER"]);
                    piDAL.USEWEIGHTAFTER = Convert.ToDouble(dtPrepareItemData.Rows[i]["USEWEIGHTAFTER"]);

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

        public bool UpdateData(string code, string materialclass, DataTable dtPrepareItemData, string UserID)
        {
            zTran trans = new zTran();
            PrepareWeightAfterDAL pDAL = new PrepareWeightAfterDAL();

            pDAL.GetDataByCODE(code, null);
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
                            //insert ลง table PrepareWeightAfterItem มี FK เป็น PrepareReturn
                            if (UpdatePrepareWeightAfterItem(_loid, dtPrepareItemData, trans, UserID) == true)
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

        public bool DeletePrepareWeightAfterByLOID(ArrayList arrLOID)
        {
            zTran trans = new zTran();
            PrepareWeightAfterDAL pDAL = new PrepareWeightAfterDAL();
            PrepareWeightAfterItemDAL piDAL = new PrepareWeightAfterItemDAL();
            bool ret = true;
            string whrStr = "";

            try
            {
                trans.CreateTransaction();

                for (int i = 0; i < arrLOID.Count; i++)
                {
                    whrStr = " PREPAREWEIGHTAFTER = " + arrLOID[i].ToString();
                    ret = piDAL.DeletePrepareWeightAfterItem(whrStr, trans.Trans);
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
