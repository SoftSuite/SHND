using System;
using System.Collections;
using System.Collections.Generic;
using System.Data;
using System.Data.OracleClient;
using System.Text;
using SHND.DAL.Tables;
using SHND.DAL.Views;
using SHND.Data.Tables;
using SHND.Data.Views;
using SHND.Data.Formula;
using zTran = SHND.DAL.Utilities.OracleTransactionDB;

/// <summary>
/// FoodTypeFlow Class
/// Version 1.0
/// =========================================================================
/// Create by: Teang
/// Create Date: 15 Jan 2009
/// -------------------------------------------------------------------------
/// Modify By: -
/// Modify From: -
/// Modify Date: -
/// -------------------------------------------------------------------------
/// Remark: -
/// Description:
///    Flow จัดการการทำงานของ ข้อมูลเมนูมาตรฐาน 
/// Changes:
///    1.0 - สร้าง
/// -------------------------------------------------------------------------
/// =========================================================================
/// </summary>
/// 
namespace SHND.Flow.Formula
{
    public class StandardMenuFlow
    {
        string _error = "";
        double _LOID = 0;
        public string ErrorMessage { get { return _error; } }
        public double LOID { get { return _LOID; } }

        public DataTable GetMasterList(double cDIVISION, string cNAME, double cFOODTYPE, double cFOODCATEGORY, string cISSPECIFIC, string cSTATUSFROM, string cSTATUSTO, string orderBy)
        {
            VStdMenuSearchDAL vDAL = new VStdMenuSearchDAL();
            return vDAL.GetDataListByCondition(cDIVISION,cNAME, cFOODTYPE, cFOODCATEGORY, cISSPECIFIC, cSTATUSFROM, cSTATUSTO, orderBy, null);
        }

        public DataTable GetStdMenuDiseaseList(double stdMenuID)
        {
            VStdMenuDiseaseDAL VStdMenuDisease = new VStdMenuDiseaseDAL();
            return VStdMenuDisease.GetDataListByStdMenu(stdMenuID, "DISEASECATEGORYNAME", null);
        }

        public DataTable GeStdMenuNutrientList(double stdMenuID, string meal, double menuDate)
        {
            VStdMenuNutrientDAL VStdMenuNutrient = new VStdMenuNutrientDAL();
            return VStdMenuNutrient.GetDataListByCondition(stdMenuID, meal, menuDate, "NUTRIENTNAME", null);
        }

        public DataTable GetFormulaSetItemList(double formulaSetID)
        {
            VFormulaSetItemDAL VFormulaSetItem = new VFormulaSetItemDAL();
            return VFormulaSetItem.GetDataListByFormulaSet(formulaSetID, "MATERIALNAME", null);
        }

        private bool InsertStdMenuDisease(ArrayList arrStdMenuDisease, string userID, double stdMenuID, OracleTransaction trans)
        {
            bool ret = true;
            string diseaseCategoryList = "";
            for (int i = 0; i < arrStdMenuDisease.Count; ++i)
            {
                StdMenuDiseaseData datStdMenuDisease = (StdMenuDiseaseData)arrStdMenuDisease[i];
                diseaseCategoryList += (diseaseCategoryList == "" ? "" : ",") + datStdMenuDisease.DISEASECATEGORY.ToString();
            }
            StdMenuDiseaseDAL StdMenuDisease = new StdMenuDiseaseDAL();
            StdMenuDisease.DeleteDataByStdMenu(stdMenuID, diseaseCategoryList, trans);

            for (int i = 0; i < arrStdMenuDisease.Count; ++i)
            {
                StdMenuDisease = new StdMenuDiseaseDAL();
                StdMenuDiseaseData datStdMenuDisease = (StdMenuDiseaseData)arrStdMenuDisease[i];
                StdMenuDisease.GetDataByConditions(stdMenuID, datStdMenuDisease.DISEASECATEGORY, trans);
                StdMenuDisease.DISEASECATEGORY = datStdMenuDisease.DISEASECATEGORY;
                StdMenuDisease.STDMENU = stdMenuID;
                StdMenuDisease.ISHIGH = (datStdMenuDisease.ISHIGH ? "Y" : "N");
                StdMenuDisease.ISLOW = (datStdMenuDisease.ISLOW ? "Y" : "N");
                StdMenuDisease.ISNON = (datStdMenuDisease.ISNON ? "Y" : "N");
                if (!StdMenuDisease.OnDB)
                    ret = StdMenuDisease.InsertCurrentData(userID, trans);
                else
                    ret = StdMenuDisease.UpdateCurrentData(userID, trans);

                if (!ret)
                {
                    _error = StdMenuDisease.ErrorMessage;
                    break;
                }
            }
            return ret;
        }

        private bool InsertStdMenuItem(ArrayList arrStdMenuItem, string userID, double stdMenuID, double day, string meal, OracleTransaction trans)
        {
            bool ret = true;
            
            StdMenuDateDAL StdMenuDate = new StdMenuDateDAL();
            StdMenuDate.GetDataByCondition(stdMenuID, day, trans);
            StdMenuDate.MENUDATE = day;
            StdMenuDate.STDMENU = stdMenuID;
            if (!StdMenuDate.OnDB)
                ret = StdMenuDate.InsertCurrentData(userID, trans);

            if (!ret) _error = StdMenuDate.ErrorMessage;

            if (ret)
            {
                StdMenuItemDAL StdMenuItem = new StdMenuItemDAL();
                StdMenuItem.DeleteDataByConditions(stdMenuID, meal, day, trans);

                for (int i = 0; i < arrStdMenuItem.Count; ++i)
                {
                    StdMenuItem = new StdMenuItemDAL();
                    StdMenuItemData datStdMenuItem = (StdMenuItemData)arrStdMenuItem[i];
                    StdMenuItem.FORMULASET = datStdMenuItem.FORMULASET;
                    StdMenuItem.GROUPTYPE = datStdMenuItem.GROUPTYPE;
                    StdMenuItem.MATERIALMASTER = datStdMenuItem.MATERIALMASTER;
                    StdMenuItem.MEAL = meal;
                    StdMenuItem.STDMENUDATE = StdMenuDate.LOID;
                    StdMenuItem.QTY = datStdMenuItem.QTY;
                    StdMenuItem.UNIT = datStdMenuItem.UNIT;
                    ret = StdMenuItem.InsertCurrentData(userID, trans);
                    if (!ret)
                    {
                        _error = StdMenuItem.ErrorMessage;
                        break;
                    }
                }
            }
            return ret;
        }

        public StdMenuItemControlData GetStdMenuItemData(double stdMenuID, int day, string meal, double foodType)
        {
            double energy = 0;
            StdMenuItemControlData itemData = new StdMenuItemControlData();
            VFormulaSetMenuDAL VFormulaSetMenu = new VFormulaSetMenuDAL();
            VStdMenuItemDAL VStdMenuItem = new VStdMenuItemDAL();
            DataTable dt;
            itemData.AllDrinks = VFormulaSetMenu.GetDataListSource(stdMenuID, meal, day, "BV", foodType, "FORMULANAME", null);
            dt = VStdMenuItem.GetDataListSelected(stdMenuID, meal, day, "BV", foodType, "FORMULANAME", null);
            for (int i = 0; i < dt.Rows.Count; ++i)
            {
                if (!Convert.IsDBNull(dt.Rows[i]["ENERGY"])) energy += Convert.ToDouble(dt.Rows[i]["ENERGY"]);
            }
            itemData.SelectedDrinks = dt;
            itemData.AllFruits = VFormulaSetMenu.GetDataListSource(stdMenuID, meal, day, "FR", foodType, "FORMULANAME", null);
            dt = VStdMenuItem.GetDataListSelected(stdMenuID, meal, day, "FR", foodType, "FORMULANAME", null);
            for (int i = 0; i < dt.Rows.Count; ++i)
            {
                if (!Convert.IsDBNull(dt.Rows[i]["ENERGY"])) energy += Convert.ToDouble(dt.Rows[i]["ENERGY"]);
            }
            itemData.SelectedFruits = dt;
            itemData.AllRice = VFormulaSetMenu.GetDataListSource(stdMenuID, meal, day, "OD", foodType, "FORMULANAME", null);
            dt = VStdMenuItem.GetDataListSelected(stdMenuID, meal, day, "OD", foodType, "FORMULANAME", null);
            for (int i = 0; i < dt.Rows.Count; ++i)
            {
                if (!Convert.IsDBNull(dt.Rows[i]["ENERGY"])) energy += Convert.ToDouble(dt.Rows[i]["ENERGY"]);
            }
            itemData.SelectedRice = dt;
            itemData.AllSavory = VFormulaSetMenu.GetDataListSource(stdMenuID, meal, day, "ND", foodType, "FORMULANAME", null);
            dt = VStdMenuItem.GetDataListSelected(stdMenuID, meal, day, "ND", foodType, "FORMULANAME", null);
            for (int i = 0; i < dt.Rows.Count; ++i)
            {
                if (!Convert.IsDBNull(dt.Rows[i]["ENERGY"])) energy += Convert.ToDouble(dt.Rows[i]["ENERGY"]);
            }
            itemData.SelectedSavory = dt;
            itemData.ENERGY = energy;
            return itemData;
        }

        public bool CopyData(double refStdMenu, string userID)
        {
            bool ret = true;
            zTran trans = new zTran();
            trans.CreateTransaction();
            StdMenuDAL StdMenu = new StdMenuDAL();
            StdMenuDAL newStdMenu = new StdMenuDAL();
            try
            {
                StdMenu.GetDataByLOID(refStdMenu, trans.Trans);
                if (StdMenu.OnDB)
                {
                    newStdMenu.ACTIVE = "1";
                    #region SetItemCount
                    newStdMenu.DAY0111 = StdMenu.DAY0111;
                    newStdMenu.DAY0121 = StdMenu.DAY0121;
                    newStdMenu.DAY0131 = StdMenu.DAY0131;
                    newStdMenu.DAY0211 = StdMenu.DAY0211;
                    newStdMenu.DAY0221 = StdMenu.DAY0221;
                    newStdMenu.DAY0231 = StdMenu.DAY0231;
                    newStdMenu.DAY0311 = StdMenu.DAY0311;
                    newStdMenu.DAY0321 = StdMenu.DAY0321;
                    newStdMenu.DAY0331 = StdMenu.DAY0331;
                    newStdMenu.DAY0411 = StdMenu.DAY0411;
                    newStdMenu.DAY0421 = StdMenu.DAY0421;
                    newStdMenu.DAY0431 = StdMenu.DAY0431;
                    newStdMenu.DAY0511 = StdMenu.DAY0511;
                    newStdMenu.DAY0521 = StdMenu.DAY0521;
                    newStdMenu.DAY0531 = StdMenu.DAY0531;
                    newStdMenu.DAY0611 = StdMenu.DAY0611;
                    newStdMenu.DAY0621 = StdMenu.DAY0621;
                    newStdMenu.DAY0631 = StdMenu.DAY0631;
                    newStdMenu.DAY0711 = StdMenu.DAY0711;
                    newStdMenu.DAY0721 = StdMenu.DAY0721;
                    newStdMenu.DAY0731 = StdMenu.DAY0731;
                    newStdMenu.DAY0811 = StdMenu.DAY0811;
                    newStdMenu.DAY0821 = StdMenu.DAY0821;
                    newStdMenu.DAY0831 = StdMenu.DAY0831;
                    newStdMenu.DAY0911 = StdMenu.DAY0911;
                    newStdMenu.DAY0921 = StdMenu.DAY0921;
                    newStdMenu.DAY0931 = StdMenu.DAY0931;
                    newStdMenu.DAY1011 = StdMenu.DAY1011;
                    newStdMenu.DAY1021 = StdMenu.DAY1021;
                    newStdMenu.DAY1031 = StdMenu.DAY1031;
                    newStdMenu.DAY1111 = StdMenu.DAY1111;
                    newStdMenu.DAY1121 = StdMenu.DAY1121;
                    newStdMenu.DAY1131 = StdMenu.DAY1131;
                    newStdMenu.DAY1211 = StdMenu.DAY1211;
                    newStdMenu.DAY1221 = StdMenu.DAY1221;
                    newStdMenu.DAY1231 = StdMenu.DAY1231;
                    newStdMenu.DAY1311 = StdMenu.DAY1311;
                    newStdMenu.DAY1321 = StdMenu.DAY1321;
                    newStdMenu.DAY1331 = StdMenu.DAY1331;
                    newStdMenu.DAY1411 = StdMenu.DAY1411;
                    newStdMenu.DAY1421 = StdMenu.DAY1421;
                    newStdMenu.DAY1431 = StdMenu.DAY1431;
                    newStdMenu.DAY1511 = StdMenu.DAY1511;
                    newStdMenu.DAY1521 = StdMenu.DAY1521;
                    newStdMenu.DAY1531 = StdMenu.DAY1531;
                    newStdMenu.DAY1611 = StdMenu.DAY1611;
                    newStdMenu.DAY1621 = StdMenu.DAY1621;
                    newStdMenu.DAY1631 = StdMenu.DAY1631;
                    newStdMenu.DAY1711 = StdMenu.DAY1711;
                    newStdMenu.DAY1721 = StdMenu.DAY1721;
                    newStdMenu.DAY1731 = StdMenu.DAY1731;
                    newStdMenu.DAY1811 = StdMenu.DAY1811;
                    newStdMenu.DAY1821 = StdMenu.DAY1821;
                    newStdMenu.DAY1831 = StdMenu.DAY1831;
                    newStdMenu.DAY1911 = StdMenu.DAY1911;
                    newStdMenu.DAY1921 = StdMenu.DAY1921;
                    newStdMenu.DAY1931 = StdMenu.DAY1931;
                    newStdMenu.DAY2011 = StdMenu.DAY2011;
                    newStdMenu.DAY2021 = StdMenu.DAY2021;
                    newStdMenu.DAY2031 = StdMenu.DAY2031;
                    newStdMenu.DAY2111 = StdMenu.DAY2111;
                    newStdMenu.DAY2121 = StdMenu.DAY2121;
                    newStdMenu.DAY2131 = StdMenu.DAY2131;
                    newStdMenu.DAY2211 = StdMenu.DAY2211;
                    newStdMenu.DAY2221 = StdMenu.DAY2221;
                    newStdMenu.DAY2231 = StdMenu.DAY2231;
                    newStdMenu.DAY2311 = StdMenu.DAY2311;
                    newStdMenu.DAY2321 = StdMenu.DAY2321;
                    newStdMenu.DAY2331 = StdMenu.DAY2331;
                    newStdMenu.DAY2411 = StdMenu.DAY2411;
                    newStdMenu.DAY2421 = StdMenu.DAY2421;
                    newStdMenu.DAY2431 = StdMenu.DAY2431;
                    newStdMenu.DAY2511 = StdMenu.DAY2511;
                    newStdMenu.DAY2521 = StdMenu.DAY2521;
                    newStdMenu.DAY2531 = StdMenu.DAY2531;
                    newStdMenu.DAY2611 = StdMenu.DAY2611;
                    newStdMenu.DAY2621 = StdMenu.DAY2621;
                    newStdMenu.DAY2631 = StdMenu.DAY2631;
                    newStdMenu.DAY2711 = StdMenu.DAY2711;
                    newStdMenu.DAY2721 = StdMenu.DAY2721;
                    newStdMenu.DAY2731 = StdMenu.DAY2731;
                    newStdMenu.DAY2811 = StdMenu.DAY2811;
                    newStdMenu.DAY2821 = StdMenu.DAY2821;
                    newStdMenu.DAY2831 = StdMenu.DAY2831;
                    newStdMenu.DAY2911 = StdMenu.DAY2911;
                    newStdMenu.DAY2921 = StdMenu.DAY2921;
                    newStdMenu.DAY2931 = StdMenu.DAY2931;
                    newStdMenu.DAY3011 = StdMenu.DAY3011;
                    newStdMenu.DAY3021 = StdMenu.DAY3021;
                    newStdMenu.DAY3031 = StdMenu.DAY3031;
                    newStdMenu.DAY3111 = StdMenu.DAY3111;
                    newStdMenu.DAY3121 = StdMenu.DAY3121;
                    newStdMenu.DAY3131 = StdMenu.DAY3131;
                    #endregion
                    newStdMenu.DIVISION = StdMenu.DIVISION;
                    newStdMenu.FOODCATEGORY = StdMenu.FOODCATEGORY;
                    newStdMenu.FOODTYPE = StdMenu.FOODTYPE;
                    newStdMenu.ISSPECIFIC = StdMenu.ISSPECIFIC;
                    newStdMenu.NAME = newStdMenu.GetRunningCopyName(StdMenu.NAME, trans.Trans);
                    newStdMenu.STATUS = "WA";
                    ret = newStdMenu.InsertCurrentData(userID, trans.Trans);
                    if (!ret) _error = newStdMenu.ErrorMessage;

                    if (ret)
                    {
                        StdMenuDiseaseDAL StdMenuDisease = new StdMenuDiseaseDAL();
                        StdMenuDiseaseDAL newStdMenuDisease;
                        DataTable dt = StdMenuDisease.GetDataList("STDMENU = " + StdMenu.LOID.ToString(), "", trans.Trans);
                        for (int i = 0; i < dt.Rows.Count; ++i)
                        {
                            newStdMenuDisease = new StdMenuDiseaseDAL();
                            newStdMenuDisease.DISEASECATEGORY = Convert.ToDouble(dt.Rows[i]["DISEASECATEGORY"]);
                            newStdMenuDisease.STDMENU = newStdMenu.LOID;
                            ret = newStdMenuDisease.InsertCurrentData(userID, trans.Trans);
                            if (!ret)
                            {
                                _error = newStdMenuDisease.ErrorMessage;
                                break;
                            }
                        }
                    }

                    if (ret)
                    {
                        StdMenuDateDAL StdMenuDate = new StdMenuDateDAL();
                        StdMenuDateDAL newStdMenuDate;
                        DataTable dt = StdMenuDate.GetDataList("STDMENU = " + StdMenu.LOID.ToString(), "", trans.Trans);
                        for (int i = 0; i < dt.Rows.Count; ++i)
                        {
                            newStdMenuDate = new StdMenuDateDAL();
                            newStdMenuDate.MENUDATE = Convert.ToDouble(dt.Rows[i]["MENUDATE"]);
                            newStdMenuDate.STDMENU = newStdMenu.LOID;
                            ret = newStdMenuDate.InsertCurrentData(userID, trans.Trans);
                            if (ret)
                            {
                                StdMenuItemDAL StdMenuItem = new StdMenuItemDAL();
                                StdMenuItemDAL newStdMenuItem;
                                DataTable dtItem = StdMenuItem.GetDataList("STDMENUDATE = " + dt.Rows[i]["LOID"].ToString(), "", trans.Trans);
                                for (int k = 0; k < dtItem.Rows.Count; ++k)
                                {
                                    newStdMenuItem = new StdMenuItemDAL();
                                    if (!Convert.IsDBNull(dtItem.Rows[k]["FORMULASET"])) newStdMenuItem.FORMULASET = Convert.ToDouble(dtItem.Rows[k]["FORMULASET"]);
                                    newStdMenuItem.GROUPTYPE = dtItem.Rows[k]["GROUPTYPE"].ToString();
                                    if (!Convert.IsDBNull(dtItem.Rows[k]["MATERIALMASTER"])) newStdMenuItem.MATERIALMASTER = Convert.ToDouble(dtItem.Rows[k]["MATERIALMASTER"]);
                                    newStdMenuItem.MEAL = dtItem.Rows[k]["MEAL"].ToString();
                                    newStdMenuItem.STDMENUDATE = newStdMenuDate.LOID;
                                    if (!Convert.IsDBNull(dtItem.Rows[k]["QTY"])) newStdMenuItem.QTY = Convert.ToDouble(dtItem.Rows[k]["QTY"]);
                                    if (!Convert.IsDBNull(dtItem.Rows[k]["UNIT"])) newStdMenuItem.UNIT = Convert.ToDouble(dtItem.Rows[k]["UNIT"]);
                                    ret = newStdMenuItem.InsertCurrentData(userID, trans.Trans);
                                    if (!ret)
                                    {
                                        _error = newStdMenuItem.ErrorMessage;
                                        break;
                                    }
                                }
                            }
                            if (!ret)
                            {
                                _error = newStdMenuDate.ErrorMessage;
                                break;
                            }
                        }
                    }
                }
                else
                {
                    ret = false;
                    _error = Data.Common.Utilities.DataResources.MSGEV002;
                }

                if (ret)
                {
                    _LOID = newStdMenu.LOID;
                    trans.CommitTransaction();
                }
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

        public bool ApproveData(double LOID, string userID)
        {
            bool ret = true;

            StdMenuDAL StdMenu = new StdMenuDAL();
            StdMenu.GetDataByLOID(LOID, null);
            if (StdMenu.OnDB)
            {
                StdMenu.STATUS = "AP";
                ret = StdMenu.UpdateCurrentData(userID, null);
                _LOID = StdMenu.LOID;
            }
            else
            {
                ret = false;
                _error = Data.Common.Utilities.DataResources.MSGEU002;
            }
            return ret;
        }

        public bool NotApproveData(double LOID, string userID)
        {
            bool ret = true;

            StdMenuDAL StdMenu = new StdMenuDAL();
            StdMenu.GetDataByLOID(LOID, null);
            if (StdMenu.OnDB)
            {
                StdMenu.STATUS = "NA";
                ret = StdMenu.UpdateCurrentData(userID, null);
                _LOID = StdMenu.LOID;
            }
            else
            {
                ret = false;
                _error = Data.Common.Utilities.DataResources.MSGEU002;
            }
            return ret;
        }

        public bool UpdateActive(double LOID, bool active, string userID)
        {
            bool ret = true;

            StdMenuDAL StdMenu = new StdMenuDAL();
            StdMenu.GetDataByLOID(LOID, null);
            if (StdMenu.OnDB)
            {
                StdMenu.ACTIVE = (active ? "1" : "0");
                ret = StdMenu.UpdateCurrentData(userID, null);
                _LOID = StdMenu.LOID;
            }
            else
            {
                ret = false;
                _error = Data.Common.Utilities.DataResources.MSGEU002;
            }
            return ret;
        }

        public StdMenuDetailData GetDetails(double LOID)
        {
            VStdMenuSearchDAL VStdMenuSearch = new VStdMenuSearchDAL();
            StdMenuDetailData StdMenuDetail = new StdMenuDetailData();
            VStdMenuSearch.GetDataByLOID(LOID, null);
            StdMenuDetail.ACTIVE = (VStdMenuSearch.ACTIVE == "1" || VStdMenuSearch.ACTIVE == "");
            #region SetItemCount
            StdMenuDetail.DAY0111 = VStdMenuSearch.DAY0111;
            StdMenuDetail.DAY0121 = VStdMenuSearch.DAY0121;
            StdMenuDetail.DAY0131 = VStdMenuSearch.DAY0131;
            StdMenuDetail.DAY0211 = VStdMenuSearch.DAY0211;
            StdMenuDetail.DAY0221 = VStdMenuSearch.DAY0221;
            StdMenuDetail.DAY0231 = VStdMenuSearch.DAY0231;
            StdMenuDetail.DAY0311 = VStdMenuSearch.DAY0311;
            StdMenuDetail.DAY0321 = VStdMenuSearch.DAY0321;
            StdMenuDetail.DAY0331 = VStdMenuSearch.DAY0331;
            StdMenuDetail.DAY0411 = VStdMenuSearch.DAY0411;
            StdMenuDetail.DAY0421 = VStdMenuSearch.DAY0421;
            StdMenuDetail.DAY0431 = VStdMenuSearch.DAY0431;
            StdMenuDetail.DAY0511 = VStdMenuSearch.DAY0511;
            StdMenuDetail.DAY0521 = VStdMenuSearch.DAY0521;
            StdMenuDetail.DAY0531 = VStdMenuSearch.DAY0531;
            StdMenuDetail.DAY0611 = VStdMenuSearch.DAY0611;
            StdMenuDetail.DAY0621 = VStdMenuSearch.DAY0621;
            StdMenuDetail.DAY0631 = VStdMenuSearch.DAY0631;
            StdMenuDetail.DAY0711 = VStdMenuSearch.DAY0711;
            StdMenuDetail.DAY0721 = VStdMenuSearch.DAY0721;
            StdMenuDetail.DAY0731 = VStdMenuSearch.DAY0731;
            StdMenuDetail.DAY0811 = VStdMenuSearch.DAY0811;
            StdMenuDetail.DAY0821 = VStdMenuSearch.DAY0821;
            StdMenuDetail.DAY0831 = VStdMenuSearch.DAY0831;
            StdMenuDetail.DAY0911 = VStdMenuSearch.DAY0911;
            StdMenuDetail.DAY0921 = VStdMenuSearch.DAY0921;
            StdMenuDetail.DAY0931 = VStdMenuSearch.DAY0931;
            StdMenuDetail.DAY1011 = VStdMenuSearch.DAY1011;
            StdMenuDetail.DAY1021 = VStdMenuSearch.DAY1021;
            StdMenuDetail.DAY1031 = VStdMenuSearch.DAY1031;
            StdMenuDetail.DAY1111 = VStdMenuSearch.DAY1111;
            StdMenuDetail.DAY1121 = VStdMenuSearch.DAY1121;
            StdMenuDetail.DAY1131 = VStdMenuSearch.DAY1131;
            StdMenuDetail.DAY1211 = VStdMenuSearch.DAY1211;
            StdMenuDetail.DAY1221 = VStdMenuSearch.DAY1221;
            StdMenuDetail.DAY1231 = VStdMenuSearch.DAY1231;
            StdMenuDetail.DAY1311 = VStdMenuSearch.DAY1311;
            StdMenuDetail.DAY1321 = VStdMenuSearch.DAY1321;
            StdMenuDetail.DAY1331 = VStdMenuSearch.DAY1331;
            StdMenuDetail.DAY1411 = VStdMenuSearch.DAY1411;
            StdMenuDetail.DAY1421 = VStdMenuSearch.DAY1421;
            StdMenuDetail.DAY1431 = VStdMenuSearch.DAY1431;
            StdMenuDetail.DAY1511 = VStdMenuSearch.DAY1511;
            StdMenuDetail.DAY1521 = VStdMenuSearch.DAY1521;
            StdMenuDetail.DAY1531 = VStdMenuSearch.DAY1531;
            StdMenuDetail.DAY1611 = VStdMenuSearch.DAY1611;
            StdMenuDetail.DAY1621 = VStdMenuSearch.DAY1621;
            StdMenuDetail.DAY1631 = VStdMenuSearch.DAY1631;
            StdMenuDetail.DAY1711 = VStdMenuSearch.DAY1711;
            StdMenuDetail.DAY1721 = VStdMenuSearch.DAY1721;
            StdMenuDetail.DAY1731 = VStdMenuSearch.DAY1731;
            StdMenuDetail.DAY1811 = VStdMenuSearch.DAY1811;
            StdMenuDetail.DAY1821 = VStdMenuSearch.DAY1821;
            StdMenuDetail.DAY1831 = VStdMenuSearch.DAY1831;
            StdMenuDetail.DAY1911 = VStdMenuSearch.DAY1911;
            StdMenuDetail.DAY1921 = VStdMenuSearch.DAY1921;
            StdMenuDetail.DAY1931 = VStdMenuSearch.DAY1931;
            StdMenuDetail.DAY2011 = VStdMenuSearch.DAY2011;
            StdMenuDetail.DAY2021 = VStdMenuSearch.DAY2021;
            StdMenuDetail.DAY2031 = VStdMenuSearch.DAY2031;
            StdMenuDetail.DAY2111 = VStdMenuSearch.DAY2111;
            StdMenuDetail.DAY2121 = VStdMenuSearch.DAY2121;
            StdMenuDetail.DAY2131 = VStdMenuSearch.DAY2131;
            StdMenuDetail.DAY2211 = VStdMenuSearch.DAY2211;
            StdMenuDetail.DAY2221 = VStdMenuSearch.DAY2221;
            StdMenuDetail.DAY2231 = VStdMenuSearch.DAY2231;
            StdMenuDetail.DAY2311 = VStdMenuSearch.DAY2311;
            StdMenuDetail.DAY2321 = VStdMenuSearch.DAY2321;
            StdMenuDetail.DAY2331 = VStdMenuSearch.DAY2331;
            StdMenuDetail.DAY2411 = VStdMenuSearch.DAY2411;
            StdMenuDetail.DAY2421 = VStdMenuSearch.DAY2421;
            StdMenuDetail.DAY2431 = VStdMenuSearch.DAY2431;
            StdMenuDetail.DAY2511 = VStdMenuSearch.DAY2511;
            StdMenuDetail.DAY2521 = VStdMenuSearch.DAY2521;
            StdMenuDetail.DAY2531 = VStdMenuSearch.DAY2531;
            StdMenuDetail.DAY2611 = VStdMenuSearch.DAY2611;
            StdMenuDetail.DAY2621 = VStdMenuSearch.DAY2621;
            StdMenuDetail.DAY2631 = VStdMenuSearch.DAY2631;
            StdMenuDetail.DAY2711 = VStdMenuSearch.DAY2711;
            StdMenuDetail.DAY2721 = VStdMenuSearch.DAY2721;
            StdMenuDetail.DAY2731 = VStdMenuSearch.DAY2731;
            StdMenuDetail.DAY2811 = VStdMenuSearch.DAY2811;
            StdMenuDetail.DAY2821 = VStdMenuSearch.DAY2821;
            StdMenuDetail.DAY2831 = VStdMenuSearch.DAY2831;
            StdMenuDetail.DAY2911 = VStdMenuSearch.DAY2911;
            StdMenuDetail.DAY2921 = VStdMenuSearch.DAY2921;
            StdMenuDetail.DAY2931 = VStdMenuSearch.DAY2931;
            StdMenuDetail.DAY3011 = VStdMenuSearch.DAY3011;
            StdMenuDetail.DAY3021 = VStdMenuSearch.DAY3021;
            StdMenuDetail.DAY3031 = VStdMenuSearch.DAY3031;
            StdMenuDetail.DAY3111 = VStdMenuSearch.DAY3111;
            StdMenuDetail.DAY3121 = VStdMenuSearch.DAY3121;
            StdMenuDetail.DAY3131 = VStdMenuSearch.DAY3131;
            #endregion
            StdMenuDetail.DIVISION = VStdMenuSearch.DIVISION;
            StdMenuDetail.DIVISIONNAME = VStdMenuSearch.DIVISIONNAME;
            StdMenuDetail.FOODCATEGORY = VStdMenuSearch.FOODCATEGORY;
            StdMenuDetail.FOODTYPE = VStdMenuSearch.FOODTYPE;
            StdMenuDetail.ISSPECIFIC = (VStdMenuSearch.ISSPECIFIC == "Y");
            StdMenuDetail.LOID = VStdMenuSearch.LOID;
            StdMenuDetail.NAME = VStdMenuSearch.NAME;
            StdMenuDetail.STATUS = VStdMenuSearch.STATUS;
            StdMenuDetail.STATUSNAME = VStdMenuSearch.STATUSNAME;
            if (StdMenuDetail.STATUS == "")
            {
                StdMenuDetail.STATUS = "WA";
                StdMenuDetail.STATUSNAME = "กำลังดำเนินการ";
            }

            return StdMenuDetail;

        }

        public bool InsertData(StdMenuDetailData StdMenuDetail, string UserID)
        {
            bool ret = true;
            zTran trans = new zTran();
            trans.CreateTransaction();

            StdMenuDAL StdMenu = new StdMenuDAL();
            StdMenu.ACTIVE = (StdMenuDetail.ACTIVE ? "1" : "0");
            StdMenu.DIVISION = StdMenuDetail.DIVISION;
            StdMenu.FOODCATEGORY = StdMenuDetail.FOODCATEGORY;
            StdMenu.FOODTYPE = StdMenuDetail.FOODTYPE;
            StdMenu.ISSPECIFIC = (StdMenuDetail.ISSPECIFIC ? "Y" : "N");
            StdMenu.NAME = StdMenuDetail.NAME;
            StdMenu.STATUS = StdMenuDetail.STATUS;
            double itemCount = StdMenuDetail.StdMenuItem.Count;

            try
            {
                #region SetItemCount

                switch (StdMenuDetail.MEAL)
                {
                    case "11" :
                        for (int i = 0; i < StdMenuDetail.SelectedDay.Count; ++i)
                        {
                            switch (StdMenuDetail.SelectedDay[i].ToString())
                            {
                                case "1": StdMenu.DAY0111 = itemCount; break;
                                case "2": StdMenu.DAY0211 = itemCount; break;
                                case "3": StdMenu.DAY0311 = itemCount; break;
                                case "4": StdMenu.DAY0411 = itemCount; break;
                                case "5": StdMenu.DAY0511 = itemCount; break;
                                case "6": StdMenu.DAY0611 = itemCount; break;
                                case "7": StdMenu.DAY0711 = itemCount; break;
                                case "8": StdMenu.DAY0811 = itemCount; break;
                                case "9": StdMenu.DAY0911 = itemCount; break;
                                case "10": StdMenu.DAY1011 = itemCount; break;
                                case "11": StdMenu.DAY1111 = itemCount; break;
                                case "12": StdMenu.DAY1211 = itemCount; break;
                                case "13": StdMenu.DAY1311 = itemCount; break;
                                case "14": StdMenu.DAY1411 = itemCount; break;
                                case "15": StdMenu.DAY1511 = itemCount; break;
                                case "16": StdMenu.DAY1611 = itemCount; break;
                                case "17": StdMenu.DAY1711 = itemCount; break;
                                case "18": StdMenu.DAY1811 = itemCount; break;
                                case "19": StdMenu.DAY1911 = itemCount; break;
                                case "20": StdMenu.DAY2011 = itemCount; break;
                                case "21": StdMenu.DAY2111 = itemCount; break;
                                case "22": StdMenu.DAY2211 = itemCount; break;
                                case "23": StdMenu.DAY2311 = itemCount; break;
                                case "24": StdMenu.DAY2411 = itemCount; break;
                                case "25": StdMenu.DAY2511 = itemCount; break;
                                case "26": StdMenu.DAY2611 = itemCount; break;
                                case "27": StdMenu.DAY2711 = itemCount; break;
                                case "28": StdMenu.DAY2811 = itemCount; break;
                                case "29": StdMenu.DAY2911 = itemCount; break;
                                case "30": StdMenu.DAY3011 = itemCount; break;
                                case "31": StdMenu.DAY3111 = itemCount; break;
                            }
                        }
                        break;
                    case "21":
                        for (int i = 0; i < StdMenuDetail.SelectedDay.Count; ++i)
                        {
                            switch (StdMenuDetail.SelectedDay[i].ToString())
                            {
                                case "1": StdMenu.DAY0121 = itemCount; break;
                                case "2": StdMenu.DAY0221 = itemCount; break;
                                case "3": StdMenu.DAY0321 = itemCount; break;
                                case "4": StdMenu.DAY0421 = itemCount; break;
                                case "5": StdMenu.DAY0521 = itemCount; break;
                                case "6": StdMenu.DAY0621 = itemCount; break;
                                case "7": StdMenu.DAY0721 = itemCount; break;
                                case "8": StdMenu.DAY0821 = itemCount; break;
                                case "9": StdMenu.DAY0921 = itemCount; break;
                                case "10": StdMenu.DAY1021 = itemCount; break;
                                case "11": StdMenu.DAY1121 = itemCount; break;
                                case "12": StdMenu.DAY1221 = itemCount; break;
                                case "13": StdMenu.DAY1321 = itemCount; break;
                                case "14": StdMenu.DAY1421 = itemCount; break;
                                case "15": StdMenu.DAY1521 = itemCount; break;
                                case "16": StdMenu.DAY1621 = itemCount; break;
                                case "17": StdMenu.DAY1721 = itemCount; break;
                                case "18": StdMenu.DAY1821 = itemCount; break;
                                case "19": StdMenu.DAY1921 = itemCount; break;
                                case "20": StdMenu.DAY2021 = itemCount; break;
                                case "21": StdMenu.DAY2121 = itemCount; break;
                                case "22": StdMenu.DAY2221 = itemCount; break;
                                case "23": StdMenu.DAY2321 = itemCount; break;
                                case "24": StdMenu.DAY2421 = itemCount; break;
                                case "25": StdMenu.DAY2521 = itemCount; break;
                                case "26": StdMenu.DAY2621 = itemCount; break;
                                case "27": StdMenu.DAY2721 = itemCount; break;
                                case "28": StdMenu.DAY2821 = itemCount; break;
                                case "29": StdMenu.DAY2921 = itemCount; break;
                                case "30": StdMenu.DAY3021 = itemCount; break;
                                case "31": StdMenu.DAY3121 = itemCount; break;
                            }
                        }
                        break;
                    case "31":
                        for (int i = 0; i < StdMenuDetail.SelectedDay.Count; ++i)
                        {
                            switch (StdMenuDetail.SelectedDay[i].ToString())
                            {
                                case "1": StdMenu.DAY0131 = itemCount; break;
                                case "2": StdMenu.DAY0231 = itemCount; break;
                                case "3": StdMenu.DAY0331 = itemCount; break;
                                case "4": StdMenu.DAY0431 = itemCount; break;
                                case "5": StdMenu.DAY0531 = itemCount; break;
                                case "6": StdMenu.DAY0631 = itemCount; break;
                                case "7": StdMenu.DAY0731 = itemCount; break;
                                case "8": StdMenu.DAY0831 = itemCount; break;
                                case "9": StdMenu.DAY0931 = itemCount; break;
                                case "10": StdMenu.DAY1031 = itemCount; break;
                                case "11": StdMenu.DAY1131 = itemCount; break;
                                case "12": StdMenu.DAY1231 = itemCount; break;
                                case "13": StdMenu.DAY1331 = itemCount; break;
                                case "14": StdMenu.DAY1431 = itemCount; break;
                                case "15": StdMenu.DAY1531 = itemCount; break;
                                case "16": StdMenu.DAY1631 = itemCount; break;
                                case "17": StdMenu.DAY1731 = itemCount; break;
                                case "18": StdMenu.DAY1831 = itemCount; break;
                                case "19": StdMenu.DAY1931 = itemCount; break;
                                case "20": StdMenu.DAY2031 = itemCount; break;
                                case "21": StdMenu.DAY2131 = itemCount; break;
                                case "22": StdMenu.DAY2231 = itemCount; break;
                                case "23": StdMenu.DAY2331 = itemCount; break;
                                case "24": StdMenu.DAY2431 = itemCount; break;
                                case "25": StdMenu.DAY2531 = itemCount; break;
                                case "26": StdMenu.DAY2631 = itemCount; break;
                                case "27": StdMenu.DAY2731 = itemCount; break;
                                case "28": StdMenu.DAY2831 = itemCount; break;
                                case "29": StdMenu.DAY2931 = itemCount; break;
                                case "30": StdMenu.DAY3031 = itemCount; break;
                                case "31": StdMenu.DAY3131 = itemCount; break;
                            }
                        }
                        break;
                }

                #endregion

                ret = StdMenu.InsertCurrentData(UserID, trans.Trans);
                if (!ret) _error = StdMenu.ErrorMessage;

                if (ret && StdMenuDetail.MEAL == "") ret = InsertStdMenuDisease(StdMenuDetail.StdMenuDisease, UserID, StdMenu.LOID, trans.Trans);

                if (ret && StdMenuDetail.MEAL != "")
                {
                    for (int i = 0; i < StdMenuDetail.SelectedDay.Count; ++i)
                    {
                        ret = InsertStdMenuItem(StdMenuDetail.StdMenuItem, UserID, StdMenu.LOID, Convert.ToInt32(StdMenuDetail.SelectedDay[i]), StdMenuDetail.MEAL, trans.Trans);
                        if (!ret) break;
                    }
                }

                if (ret)
                    trans.CommitTransaction();
                else
                    trans.RollbackTransaction();

                _LOID = StdMenu.LOID;
            }
            catch (Exception ex)
            {
                ret = false;
                _error = ex.Message;
                trans.RollbackTransaction();
            }

            return ret;
        }

        public bool UpdateData(StdMenuDetailData StdMenuDetail, string UserID)
        {
            bool ret = true;
            zTran trans = new zTran();
            trans.CreateTransaction();

            StdMenuDAL StdMenu = new StdMenuDAL();
            StdMenu.GetDataByLOID(StdMenuDetail.LOID, trans.Trans);
            StdMenu.ACTIVE = (StdMenuDetail.ACTIVE ? "1" : "0");
            StdMenu.DIVISION = StdMenuDetail.DIVISION;
            StdMenu.FOODCATEGORY = StdMenuDetail.FOODCATEGORY;
            StdMenu.FOODTYPE = StdMenuDetail.FOODTYPE;
            StdMenu.ISSPECIFIC = (StdMenuDetail.ISSPECIFIC ? "Y" : "N");
            StdMenu.NAME = StdMenuDetail.NAME;
            StdMenu.STATUS = StdMenuDetail.STATUS;
            double itemCount = StdMenuDetail.StdMenuItem.Count;

            try
            {
                if (StdMenu.OnDB)
                {
                    #region SetItemCount

                    switch (StdMenuDetail.MEAL)
                    {
                        case "11":
                            for (int i = 0; i < StdMenuDetail.SelectedDay.Count; ++i)
                            {
                                switch (StdMenuDetail.SelectedDay[i].ToString())
                                {
                                    case "1": StdMenu.DAY0111 = itemCount; break;
                                    case "2": StdMenu.DAY0211 = itemCount; break;
                                    case "3": StdMenu.DAY0311 = itemCount; break;
                                    case "4": StdMenu.DAY0411 = itemCount; break;
                                    case "5": StdMenu.DAY0511 = itemCount; break;
                                    case "6": StdMenu.DAY0611 = itemCount; break;
                                    case "7": StdMenu.DAY0711 = itemCount; break;
                                    case "8": StdMenu.DAY0811 = itemCount; break;
                                    case "9": StdMenu.DAY0911 = itemCount; break;
                                    case "10": StdMenu.DAY1011 = itemCount; break;
                                    case "11": StdMenu.DAY1111 = itemCount; break;
                                    case "12": StdMenu.DAY1211 = itemCount; break;
                                    case "13": StdMenu.DAY1311 = itemCount; break;
                                    case "14": StdMenu.DAY1411 = itemCount; break;
                                    case "15": StdMenu.DAY1511 = itemCount; break;
                                    case "16": StdMenu.DAY1611 = itemCount; break;
                                    case "17": StdMenu.DAY1711 = itemCount; break;
                                    case "18": StdMenu.DAY1811 = itemCount; break;
                                    case "19": StdMenu.DAY1911 = itemCount; break;
                                    case "20": StdMenu.DAY2011 = itemCount; break;
                                    case "21": StdMenu.DAY2111 = itemCount; break;
                                    case "22": StdMenu.DAY2211 = itemCount; break;
                                    case "23": StdMenu.DAY2311 = itemCount; break;
                                    case "24": StdMenu.DAY2411 = itemCount; break;
                                    case "25": StdMenu.DAY2511 = itemCount; break;
                                    case "26": StdMenu.DAY2611 = itemCount; break;
                                    case "27": StdMenu.DAY2711 = itemCount; break;
                                    case "28": StdMenu.DAY2811 = itemCount; break;
                                    case "29": StdMenu.DAY2911 = itemCount; break;
                                    case "30": StdMenu.DAY3011 = itemCount; break;
                                    case "31": StdMenu.DAY3111 = itemCount; break;
                                }
                            }
                            break;
                        case "21":
                            for (int i = 0; i < StdMenuDetail.SelectedDay.Count; ++i)
                            {
                                switch (StdMenuDetail.SelectedDay[i].ToString())
                                {
                                    case "1": StdMenu.DAY0121 = itemCount; break;
                                    case "2": StdMenu.DAY0221 = itemCount; break;
                                    case "3": StdMenu.DAY0321 = itemCount; break;
                                    case "4": StdMenu.DAY0421 = itemCount; break;
                                    case "5": StdMenu.DAY0521 = itemCount; break;
                                    case "6": StdMenu.DAY0621 = itemCount; break;
                                    case "7": StdMenu.DAY0721 = itemCount; break;
                                    case "8": StdMenu.DAY0821 = itemCount; break;
                                    case "9": StdMenu.DAY0921 = itemCount; break;
                                    case "10": StdMenu.DAY1021 = itemCount; break;
                                    case "11": StdMenu.DAY1121 = itemCount; break;
                                    case "12": StdMenu.DAY1221 = itemCount; break;
                                    case "13": StdMenu.DAY1321 = itemCount; break;
                                    case "14": StdMenu.DAY1421 = itemCount; break;
                                    case "15": StdMenu.DAY1521 = itemCount; break;
                                    case "16": StdMenu.DAY1621 = itemCount; break;
                                    case "17": StdMenu.DAY1721 = itemCount; break;
                                    case "18": StdMenu.DAY1821 = itemCount; break;
                                    case "19": StdMenu.DAY1921 = itemCount; break;
                                    case "20": StdMenu.DAY2021 = itemCount; break;
                                    case "21": StdMenu.DAY2121 = itemCount; break;
                                    case "22": StdMenu.DAY2221 = itemCount; break;
                                    case "23": StdMenu.DAY2321 = itemCount; break;
                                    case "24": StdMenu.DAY2421 = itemCount; break;
                                    case "25": StdMenu.DAY2521 = itemCount; break;
                                    case "26": StdMenu.DAY2621 = itemCount; break;
                                    case "27": StdMenu.DAY2721 = itemCount; break;
                                    case "28": StdMenu.DAY2821 = itemCount; break;
                                    case "29": StdMenu.DAY2921 = itemCount; break;
                                    case "30": StdMenu.DAY3021 = itemCount; break;
                                    case "31": StdMenu.DAY3121 = itemCount; break;
                                }
                            }
                            break;
                        case "31":
                            for (int i = 0; i < StdMenuDetail.SelectedDay.Count; ++i)
                            {
                                switch (StdMenuDetail.SelectedDay[i].ToString())
                                {
                                    case "1": StdMenu.DAY0131 = itemCount; break;
                                    case "2": StdMenu.DAY0231 = itemCount; break;
                                    case "3": StdMenu.DAY0331 = itemCount; break;
                                    case "4": StdMenu.DAY0431 = itemCount; break;
                                    case "5": StdMenu.DAY0531 = itemCount; break;
                                    case "6": StdMenu.DAY0631 = itemCount; break;
                                    case "7": StdMenu.DAY0731 = itemCount; break;
                                    case "8": StdMenu.DAY0831 = itemCount; break;
                                    case "9": StdMenu.DAY0931 = itemCount; break;
                                    case "10": StdMenu.DAY1031 = itemCount; break;
                                    case "11": StdMenu.DAY1131 = itemCount; break;
                                    case "12": StdMenu.DAY1231 = itemCount; break;
                                    case "13": StdMenu.DAY1331 = itemCount; break;
                                    case "14": StdMenu.DAY1431 = itemCount; break;
                                    case "15": StdMenu.DAY1531 = itemCount; break;
                                    case "16": StdMenu.DAY1631 = itemCount; break;
                                    case "17": StdMenu.DAY1731 = itemCount; break;
                                    case "18": StdMenu.DAY1831 = itemCount; break;
                                    case "19": StdMenu.DAY1931 = itemCount; break;
                                    case "20": StdMenu.DAY2031 = itemCount; break;
                                    case "21": StdMenu.DAY2131 = itemCount; break;
                                    case "22": StdMenu.DAY2231 = itemCount; break;
                                    case "23": StdMenu.DAY2331 = itemCount; break;
                                    case "24": StdMenu.DAY2431 = itemCount; break;
                                    case "25": StdMenu.DAY2531 = itemCount; break;
                                    case "26": StdMenu.DAY2631 = itemCount; break;
                                    case "27": StdMenu.DAY2731 = itemCount; break;
                                    case "28": StdMenu.DAY2831 = itemCount; break;
                                    case "29": StdMenu.DAY2931 = itemCount; break;
                                    case "30": StdMenu.DAY3031 = itemCount; break;
                                    case "31": StdMenu.DAY3131 = itemCount; break;
                                }
                            }
                            break;
                    }

                    #endregion

                    ret = StdMenu.UpdateCurrentData(UserID, trans.Trans);
                    if (!ret) _error = StdMenu.ErrorMessage;

                    if (ret && StdMenuDetail.MEAL == "") ret = InsertStdMenuDisease(StdMenuDetail.StdMenuDisease, UserID, StdMenu.LOID, trans.Trans);

                    if (ret && StdMenuDetail.MEAL != "")
                    {
                        for (int i = 0; i < StdMenuDetail.SelectedDay.Count; ++i)
                        {
                            ret = InsertStdMenuItem(StdMenuDetail.StdMenuItem, UserID, StdMenu.LOID, Convert.ToInt32(StdMenuDetail.SelectedDay[i]), StdMenuDetail.MEAL, trans.Trans);
                            if (!ret) break;
                        }
                    }
                }
                else
                {
                    ret = false;
                    _error = Data.Common.Utilities.DataResources.MSGEU002;
                }

                if (ret)
                    trans.CommitTransaction();
                else
                    trans.RollbackTransaction();

                _LOID = StdMenu.LOID;
            }
            catch (Exception ex)
            {
                ret = false;
                _error = ex.Message;
                trans.RollbackTransaction();
            }

            return ret;
        }

        public bool DeleteByLOID(double cLOID)
        {
            zTran trans = new zTran();
            StdMenuDAL StdMenu = new StdMenuDAL();
            StdMenuDateDAL StdMenuDate = new StdMenuDateDAL();
            StdMenuDiseaseDAL StdMenuDisease = new StdMenuDiseaseDAL();
            StdMenuItemDAL StdMenuItem = new StdMenuItemDAL();

            trans.CreateTransaction();
            bool ret = true;
            try
            {
                StdMenuItem.DeleteDataByStdMenu(cLOID, trans.Trans);
                StdMenuDate.DeleteDataByStdMenu(cLOID, trans.Trans);
                StdMenuDisease.DeleteDataByStdMenu(cLOID, "", trans.Trans);
                ret = StdMenu.DeleteDataByLOID(cLOID, trans.Trans);

                if (ret)
                    trans.CommitTransaction();
                else
                {
                    _error = StdMenu.ErrorMessage;
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

        public bool CheckUniqueKey(double cLOID, string cNAME, double cFOODTYPE, double cFOODCATEGORY)
        {
            StdMenuDAL fDAL = new StdMenuDAL();
            fDAL.GetDataByUniqueKey(cNAME, cFOODCATEGORY, cFOODTYPE, null);
            return !fDAL.OnDB || (cLOID == fDAL.LOID);
        }

    }
}
