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
/// SendSupplierFlow Class
/// Version 1.0
/// =========================================================================
/// Create by: Nang
/// Create Date: 27 Feb 2009
/// -------------------------------------------------------------------------
/// Modify By: -
/// Modify From: -
/// Modify Date: -
/// -------------------------------------------------------------------------
/// Remark: -
/// Description:
///    Flow จัดการการทำงานของหน้า SendSupplier
/// Changes:
///    1.0 - สร้าง
/// -------------------------------------------------------------------------
/// =========================================================================
/// </summary>
/// 


namespace SHND.Flow.Inventory
{
    public class SendSupplierFlow
    {
        string _error = "";
        double _LOID = 0;
        public string ErrorMessage { get { return _error; } }
        public double LOID { get { return _LOID; } }

        #region Get Data Main

        public DataTable GetSendSupplierSearch(string wh,string orderstr)
        {
            VSendSupplierDAL vDAL = new VSendSupplierDAL();
            return vDAL.GetDistinctDataList(wh, orderstr, null);
        }
        
        #endregion

        #region Get Data Popup

        public StockOutData GetStockOutData(double sLoid)
        {
            StockOutDAL sDAL = new StockOutDAL();
            StockOutData sData = new StockOutData();
            sDAL.GetDataByLOID(sLoid, null);
            if (sDAL.OnDB)
            {
                sData.CODE = sDAL.CODE;
                sData.STOCKOUTDATE = sDAL.STOCKOUTDATE;
                sData.PLANORDER = sDAL.PLANORDER;
                sData.WAREHOUSE = sDAL.WAREHOUSE;
                sData.SUPPLIER = sDAL.SUPPLIER;
                sData.REMARKS = sDAL.REMARKS;
                sData.STATUS = sDAL.STATUS;
                sData.LOID = sDAL.LOID;
            }
            else
                _error = Data.Common.Utilities.DataResources.MSGEU002;

            return sData;
        }


        public DataTable GetStockOutItemData(double sLoid)
        {
            StockoutitemDAL siDAL = new StockoutitemDAL();
            return siDAL.GetDataByField("STOCKOUT = " + sLoid, "SOI.LOID", null);
        }
        #endregion

        #region Event On StockOut

        public bool InsertStockOut(StockOutData  sData, string UserID)
        {
            zTran trans = new zTran();
            trans.CreateTransaction();
            
            StockOutDAL sDAL = new StockOutDAL();
            sDAL.PLANORDER = Convert.ToDouble(sData.PLANORDER);
            sDAL.DIVISION = Convert.ToDouble(sData.DIVISION);
            sDAL.SUPPLIER = Convert.ToDouble(sData.SUPPLIER);
            sDAL.WAREHOUSE = Convert.ToDouble(sData.WAREHOUSE);
            sDAL.REMARKS = sData.REMARKS;
            sDAL.STOCKOUTDATE = Convert.ToDateTime(sData.STOCKOUTDATE);
            sDAL.STATUS = sData.STATUS;
            sDAL.DOCTYPE = Convert.ToDouble(sData.DOCTYPE);

            bool ret = true;

            try
            {
                ret = sDAL.InsertCurrentData(UserID, trans.Trans);
                if (!ret) _error = sDAL.ErrorMessage;
                
                if (ret)
                {
                    _LOID = sDAL.LOID;
                    trans.CommitTransaction();
                }
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

        public bool UpdateStockOut(StockOutData sData, string UserID)
        {
            zTran trans = new zTran();
            trans.CreateTransaction();

            StockOutDAL sDAL = new StockOutDAL();
            sDAL.GetDataByLOID(sData.LOID, null);
            sDAL.PLANORDER = Convert.ToDouble(sData.PLANORDER);
            sDAL.DIVISION = Convert.ToDouble(sData.DIVISION);
            sDAL.SUPPLIER = Convert.ToDouble(sData.SUPPLIER);
            sDAL.WAREHOUSE = Convert.ToDouble(sData.WAREHOUSE);
            sDAL.REMARKS = sData.REMARKS;
            sDAL.STOCKOUTDATE = Convert.ToDateTime(sData.STOCKOUTDATE);
            sDAL.STATUS = sData.STATUS;
            sDAL.DOCTYPE = Convert.ToDouble(sData.DOCTYPE);

            bool ret = true;

            try
            {
                if (sDAL.OnDB)
                {
                    ret = sDAL.UpdateCurrentData(UserID, trans.Trans);
                    if (!ret) _error = sDAL.ErrorMessage;

                    if (ret && sDAL.STATUS == "AP")
                        ret = sDAL.CutStockOutReturn(sDAL.LOID,trans.Trans);

                    _LOID = sDAL.LOID;

                    if (ret)
                        trans.CommitTransaction();
                    else
                        trans.RollbackTransaction();
                }
                else
                {
                    _error = Data.Common.Utilities.DataResources.MSGEU002;
                    ret = false;
                    trans.RollbackTransaction();
                }
            }
            catch (Exception ex)
            {
                _error = ex.Message;
                ret = false;
                trans.RollbackTransaction();
            }
            return ret;
        }

        public bool DeleteStockOutByLoid(ArrayList arrLOID)
        {
            zTran trans = new zTran();

            StockOutDAL sDAL = new StockOutDAL();
            trans.CreateTransaction();
            bool ret = true;
            try
            {
                if (!CheckDelete(arrLOID))
                {
                    return false;
                }
                else
                {
                    for (int i = 0; i < arrLOID.Count; i++)
                    {
                        if (DeleteStockItemByLOID(Convert.ToDouble(arrLOID[i]), trans))
                        {
                            sDAL.DeleteDataByLOID(Convert.ToDouble(arrLOID[i]), trans.Trans);
                        }
                        else
                        {
                            trans.RollbackTransaction();
                            return false;
                        }
                    }
                    trans.CommitTransaction();
                }

            }
            catch (Exception ex)
            {
                _error = ex.Message;
                ret = false;
                trans.RollbackTransaction();
            }
            return ret;
        }


        #endregion

        #region Event On StockOutItem

        public bool InsertStockOutItem(DataTable tempTable, double sLoid, string UserID)
        {
            zTran trans = new zTran();
            bool ret = true;

            try
            {
                trans.CreateTransaction();

                if (tempTable != null)
                {
                    if (DeleteStockOutItem(tempTable, trans, sLoid))
                    {
                        for (int i = 0; i < tempTable.Rows.Count; i++)
                        {
                            StockOutDAL sDAL = new StockOutDAL();
                            StockoutitemDAL siDAL = new StockoutitemDAL();

                            if (!siDAL.OnDB)
                            {
                                //insert StockOutitem
                                siDAL.STOCKOUT = sLoid;
                                string str = tempTable.Rows[i]["MMLOID"].ToString();
                                siDAL.MATERIALMASTER = Convert.ToDouble(tempTable.Rows[i]["MMLOID"].ToString());
                                siDAL.REQQTY = Convert.ToDouble("0");
                                siDAL.QTY = Convert.ToDouble(tempTable.Rows[i]["QTY"].ToString());
                                siDAL.ISMENU = "N";
                                siDAL.STATUS = sDAL.GetStatus(" LOID = "+ sLoid );
                                siDAL.REMARKS = tempTable.Rows[i]["REMARKS"].ToString();
                                siDAL.UNIT = Convert.ToDouble(tempTable.Rows[i]["UULOID"].ToString());
                                siDAL.REPAIRSTATUS = "Z";

                                ret = siDAL.InsertCurrentData(UserID, trans.Trans);

                                if (ret == false)
                                {
                                    trans.RollbackTransaction();
                                    _error = sDAL.ErrorMessage;
                                    return false;
                                }
                            }
                            else
                            {
                                //update StockOutitem
                                StockoutitemData siData = new StockoutitemData();
                                siData.LOID = Convert.ToDouble(tempTable.Rows[i]["SOILOID"].ToString());
                                siData.STOCKOUT = sLoid;
                                siData.MATERIALMASTER = Convert.ToDouble(tempTable.Rows[i]["MMLOID"].ToString());
                                siData.QTY = Convert.ToDouble(tempTable.Rows[i]["QTY"].ToString());
                                siData.STATUS = sDAL.GetStatus(" LOID = " + sLoid +" ");
                                siData.REMARKS = tempTable.Rows[i]["REMARKS"].ToString();
                                siData.UNIT = Convert.ToDouble(tempTable.Rows[i]["UULOID"].ToString());

                                UpdateStockItem(siData, trans, UserID);
                            }
                        }
                    }
                    else
                    {
                        trans.RollbackTransaction();
                        return false;
                    }

                }
                if (ret)
                    trans.CommitTransaction();

                else
                {
                    trans.RollbackTransaction();
                    return false;
                }
            }
            catch (Exception ex)
            {
                _error = ex.Message;
                ret = false;
                trans.RollbackTransaction();
            }

            return ret;
        }


        public bool UpdateStockOutItem(DataTable tempTable, double sLoid, string UserID)
        {
            zTran trans = new zTran();
            bool ret = true;

            try
            {
                trans.CreateTransaction();

                if (tempTable != null)
                {
                    if (DeleteStockItemByLOID(sLoid,trans))
                    {
                        for (int i = 0; i < tempTable.Rows.Count; i++)
                        {
                            StockOutDAL sDAL = new StockOutDAL();
                            StockoutitemDAL siDAL = new StockoutitemDAL();
                            // เช็คว่ามี database หรือเปล่า
                            if (tempTable.Rows[i]["SOILOID"].ToString() != "" && tempTable.Rows[i]["SOILOID"].ToString() != "0")
                                siDAL.GetDataByLOID(Convert.ToDouble(tempTable.Rows[i]["SOILOID"].ToString()), trans.Trans);

                            if (!siDAL.OnDB)
                            {
                                //insert StockOutitem
                                siDAL.STOCKOUT = sLoid;
                                string str = tempTable.Rows[i]["MMLOID"].ToString();
                                siDAL.MATERIALMASTER = Convert.ToDouble(tempTable.Rows[i]["MMLOID"].ToString());
                                siDAL.REQQTY = Convert.ToDouble("0");
                                siDAL.QTY = Convert.ToDouble(tempTable.Rows[i]["QTY"].ToString());
                                siDAL.ISMENU = "N";
                                siDAL.STATUS = sDAL.GetStatus(" LOID = " + sLoid);
                                siDAL.REMARKS = tempTable.Rows[i]["REMARKS"].ToString();
                                siDAL.UNIT = Convert.ToDouble(tempTable.Rows[i]["UULOID"].ToString());
                                siDAL.REPAIRSTATUS = "Z";

                                ret = siDAL.InsertCurrentData(UserID, trans.Trans);

                                if (ret == false)
                                {
                                    trans.RollbackTransaction();
                                    _error = sDAL.ErrorMessage;
                                    return false;
                                }
                            }
                            else
                            {
                                //update StockOutitem
                                StockoutitemData siData = new StockoutitemData();
                                siData.LOID = Convert.ToDouble(tempTable.Rows[i]["SOILOID"].ToString());
                                siData.STOCKOUT = sLoid;
                                siData.MATERIALMASTER = Convert.ToDouble(tempTable.Rows[i]["MMLOID"].ToString());
                                siData.QTY = Convert.ToDouble(tempTable.Rows[i]["QTY"].ToString());
                                siData.STATUS = sDAL.GetStatus(" LOID = " + sLoid + " ");
                                siData.REMARKS = tempTable.Rows[i]["REMARKS"].ToString();
                                siData.UNIT = Convert.ToDouble(tempTable.Rows[i]["UULOID"].ToString());

                                UpdateStockItem(siData, trans, UserID);
                            }
                        }
                    }
                    else
                    {
                        trans.RollbackTransaction();
                        return false;
                    }

                }
                if (ret)
                    trans.CommitTransaction();

                else
                {
                    trans.RollbackTransaction();
                    return false;
                }
            }
            catch (Exception ex)
            {
                _error = ex.Message;
                ret = false;
                trans.RollbackTransaction();
            }

            return ret;
        }


        private bool UpdateStockItem(StockoutitemData siData, zTran trans, string UserID)
        {
            bool ret = true;
            StockoutitemDAL siDAL = new StockoutitemDAL();

            siDAL.GetDataByLOID(siData.LOID, trans.Trans);
            siDAL.STOCKOUT = siData.STOCKOUT;
            siDAL.MATERIALMASTER = siData.MATERIALMASTER;
            siDAL.QTY = siData.QTY;
            siDAL.STATUS = siData.STATUS;
            siDAL.REMARKS = siData.REMARKS;
            siData.UNIT = siData.UNIT;

            try
            {
                if (siDAL.OnDB)
                {
                    ret = siDAL.UpdateCurrentData(UserID, null);
                    if (!ret)
                        _error = siDAL.ErrorMessage;
                }
                else
                {
                    _error = Data.Common.Utilities.DataResources.MSGEU002;
                    ret = false;
                }
            }
            catch (Exception ex)
            {
                _error = ex.Message;
                ret = false;
            }
            return ret;
        }

        public bool DeleteStockItemByLOID(double sLoid, zTran trans)
        {
            StockoutitemDAL siDAL = new StockoutitemDAL();
            bool ret = true;
            try
            {
                ret = siDAL.DeleteDataByStockOut(sLoid, trans.Trans);
            }

            catch (Exception ex)
            {
                _error = ex.Message;
                ret = false;
            }

            return ret;
        }

        public bool DeleteStockOutItem(DataTable dt, zTran trans, double sLoid)
        {
            bool ret = true;
            string soiloidList = "";
            StockoutitemDAL siDAL = new StockoutitemDAL();
            try
            {
                for (int i = 0; i < dt.Rows.Count; i++)
                {
                    if (dt.Rows[i]["SOILOID"].ToString() != "" && dt.Rows[i]["SOILOID"] != null)
                    {
                        soiloidList += (soiloidList == "" ? "" : " , ") + dt.Rows[i]["SOILOID"].ToString();
                    }
                }

                if (soiloidList != "")
                    ret = siDAL.DeleteNotInLOIDList(soiloidList, sLoid.ToString(), trans.Trans);
            }

            catch (Exception ex)
            {
                _error = ex.Message;
                ret = false;
            }

            return ret;
        }


        #endregion


        private bool CheckDelete(ArrayList arr)
        {
            StockOutDAL sDAL = new StockOutDAL();
            for (int i = 0; i < arr.Count; i++)
            {
                if (sDAL.GetStatus("LOID = "+ Convert.ToDouble(arr[i]) +"") != "WA")
                {
                    _error = "ไม่สามารถลบรายการได้ เนื่องจากไม่ใช่สถานะทำรายการ";
                    return false;
                }
            }
            return true;
        }
    }
}
