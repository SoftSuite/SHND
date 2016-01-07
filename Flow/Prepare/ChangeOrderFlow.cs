using System;
using System.Collections.Generic;
using System.Text;
using zTran = SHND.DAL.Utilities.OracleTransactionDB;
using System.Data;
using SHND.DAL.Views;
using SHND.Data.Views;
using SHND.DAL.Tables;
using SHND.Data.Tables;
using System.Collections;

/// <summary>
/// ChangOrderFlow Class
/// Version 1.0
/// =========================================================================
/// Create by: Nang
/// Create Date: 31 Mar 2009
/// -------------------------------------------------------------------------
/// Modify By: -
/// Modify From: -
/// Modify Date: -
/// -------------------------------------------------------------------------
/// Remark: -
/// Description:
///    Flow จัดการการทำงานของหน้า ChangeOrder,ChangeOrderNewCtl,ChangeOrderOldCtl
/// Changes:
///    1.0 - สร้าง
/// -------------------------------------------------------------------------
/// =========================================================================
/// </summary>
/// 

namespace SHND.Flow.Prepare
{
    public class ChangeOrderFlow
    {
        string _error = "";
        public string ErrorMessage { get { return _error; } }

        public DataTable GetOrderChangeList(string str, string ordstr)
        {
            VOrderChangeDAL vDAL = new VOrderChangeDAL();
            return vDAL.GetOrderChangeList(str, ordstr, null);
        }

        public DataTable GetOrderChangeNewCtlList(string str, string ordstr)
        {
            VOrderChangeDAL vDAL = new VOrderChangeDAL();
            return vDAL.GetOrderChangeNewCtlList(str, ordstr, null);
        }

        public DataTable GetOrderChangeOldCtlList(string str, string ordstr)
        {
            VOrderChangeDAL vDAL = new VOrderChangeDAL();
            return vDAL.GetOrderChangeOldCtlList(str, ordstr, null);
        }
        public bool UpdateRegister(string meal, string regdate, string UserID, DataTable dt)
        {
            zTran trans = new zTran();
            bool ret = true;

            try
            {
                trans.CreateTransaction();

                for(int i = 0; i < dt.Rows.Count; i++)
                {
                    if (dt.Rows[i]["REFMEDTABLE"].ToString() == "ORDERMEDICALSET")
                    {
                        double ordermedicalset = Convert.ToDouble(dt.Rows[i]["ORDERMEDID"].ToString());
                        ret = UpdateOrderMedicalSet(meal, Convert.ToDateTime(regdate), UserID, trans, ordermedicalset);
                    }
                    else if (dt.Rows[i]["REFMEDTABLE"].ToString() == "ORDERMEDICALFEED")
                    {
                        double ordermedicalfeed = Convert.ToDouble(dt.Rows[i]["ORDERMEDID"].ToString());
                        ret = UpdateOrderMedicalFeed(meal, Convert.ToDateTime(regdate), UserID, trans, ordermedicalfeed);
                    }

                    else if (dt.Rows[i]["REFMEDTABLE"].ToString() == "ORDERMILK")
                    {
                        double ordermilk = Convert.ToDouble(dt.Rows[i]["ORDERMEDID"].ToString());
                        ret = UpdateOrderMilk(meal, Convert.ToDateTime(regdate), UserID, trans, ordermilk);

                    }

                    double ordernonMed = Convert.ToDouble(dt.Rows[i]["ORDERNONMEDID"].ToString());
                    ret = UpdateOrderNonMedical(meal, Convert.ToDateTime(regdate), UserID, trans, ordernonMed);

                    if (ret == false)
                    {
                        trans.RollbackTransaction();
                        return false;
                    }
                }


                if (ret)
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
                _error = ex.Message;
                trans.RollbackTransaction();
                return false;
            }
        }

        private bool UpdateOrderMedicalSet(string  meal, DateTime regdate,  string UserID,zTran trans,double  loid)
        {
            bool ret = true;
            OrderMedicalSetDAL omDAL = new OrderMedicalSetDAL();
            omDAL.GetDataByOrderMedId(loid, trans.Trans);
            omDAL.FIRSTMEALREGIS = meal;
            omDAL.FIRSTDATEREGIS = regdate;
            omDAL.STATUS = "RG";
            omDAL.ISREGISTER = "Y";
            try
            {
                if (omDAL.OnDB)
                {
                    ret = omDAL.UpdateCurrentData(UserID, null);
                    if (!ret)
                    {
                        _error = omDAL.ErrorMessage;
                        return false;
                    }
                    else
                        return true;
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

        private bool UpdateOrderMedicalFeed(string meal, DateTime regdate, string UserID, zTran trans, double loid)
        {
            bool ret = true;
            OrderMedicalFeedDAL ofDAL = new OrderMedicalFeedDAL();
            ofDAL.GetDataByOrderMedId(loid, trans.Trans);
            ofDAL.FIRSTMEALREGIS = meal;
            ofDAL.FIRSTDATEREGIS = regdate;
            ofDAL.STATUS = "RG";
            ofDAL.ISREGISTER = "Y";

            try
            {
                if (ofDAL.OnDB)
                {
                    ret = ofDAL.UpdateCurrentData(UserID, null);
                    if (!ret)
                    {
                        _error = ofDAL.ErrorMessage;
                        return false;
                    }
                    else
                        return true;
                        
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

        private bool UpdateOrderMilk(string meal, DateTime regdate, string UserID, zTran trans, double loid)
        {
            bool ret = true;

            OrderMilkDAL omkDAL = new OrderMilkDAL();
            omkDAL.GetDataByOrderMedId(loid, trans.Trans);
            omkDAL.FIRSTMEALREGIS = meal;
            omkDAL.FIRSTDATEREGIS = regdate;
            omkDAL.STATUS = "RG";
            omkDAL.ISREGISTER = "Y";

            try
            {
                if (omkDAL.OnDB)
                {
                    ret = omkDAL.UpdateCurrentData(UserID, null);
                    if (!ret)
                    {
                        _error = omkDAL.ErrorMessage;
                        return ret;
                    }
                    else
                        return true;
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

        private bool UpdateOrderNonMedical(string meal, DateTime regdate, string UserID, zTran trans, double loid)
        {
            bool ret = true;
            OrderNonMedicalDAL onmDAL = new OrderNonMedicalDAL();
            onmDAL.GetDataByOrderNonMed(loid, trans.Trans);
            onmDAL.FIRSTMEALREGIS = meal;
            onmDAL.FIRSTDATEREGIS = regdate;
            onmDAL.STATUS = "RG";
            onmDAL.ISREGISTER = "Y";

            try
            {
                if (onmDAL.OnDB)
                {
                    ret = onmDAL.UpdateCurrentData(UserID, null);
                    if (!ret)
                    {
                        _error = onmDAL.ErrorMessage;
                        return false;
                    }
                    else
                        return true;
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
    }
}
