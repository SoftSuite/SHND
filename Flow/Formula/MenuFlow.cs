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
/// Create by: Tan
/// Create Date: 20 Jan 2009
/// -------------------------------------------------------------------------
/// Modify By: -
/// Modify From: -
/// Modify Date: -
/// -------------------------------------------------------------------------
/// Remark: -
/// Description:
///    Flow จัดการการทำงานของ ข้อมูลเมนูประจำวัน 
/// Changes:
///    1.0 - สร้าง
/// -------------------------------------------------------------------------
/// =========================================================================
/// </summary>
/// 

namespace SHND.Flow.Formula
{
    public class MenuFlow
    {
        string _error = "";
        double _LOID = 0;
        public string ErrorMessage { get { return _error; } }
        public double LOID { get { return _LOID; } }

        public DataTable GetMasterList(double cDIVISION, string cNAME, double cFOODTYPE, double cFOODCATEGORY, string orderBy)
        {
            VMenuSearchDAL vDAL = new VMenuSearchDAL();
            return vDAL.GetDataListByCondition(cDIVISION, cNAME, cFOODTYPE, cFOODCATEGORY, orderBy, null);
        }

        public DataTable GetMenuDiseaseList(double MenuID)
        {
            VMenuDiseaseDAL VMenuDisease = new VMenuDiseaseDAL();
            return VMenuDisease.GetDataListByMenu(MenuID, "DISEASECATEGORYNAME", null);
        }

        public DataTable GetStdMenuDateList(double StdMenu)
        {
            VStdMenuItemDAL VStdMenu = new VStdMenuItemDAL();
            return VStdMenu.GetDataListByStdMenu(StdMenu, "MENUDATE", null);
        }

        public DataTable GetMenuDateList(int Month, int Year)
        {
            VMenuItemDAL VMenu = new VMenuItemDAL();
            return VMenu.GetDataListByMonth(Month, Year, "MENUDATE", null);
        }

        //public bool CheckExist(double Menu, string Phase, double Year)
        //{
        //    VMenuItemDAL VMenu = new VMenuItemDAL();
        //    DataTable dt = VMenu.GetDataListByMenu(Menu, Phase, Year, "MENUDATE", null);
        //    if (dt.Rows.Count == 0)
        //        return true;
        //    else
        //        return false;
        //}
        public DataTable GetDiseaseCategoryByLOID(string dcloid)
        {
            DiseaseCategoryDAL dcDAL = new DiseaseCategoryDAL();
            return dcDAL.GetDataList("LOID = " + dcloid, "", null);
        }

        public MenuChangeData GetMenuChange(double MenuID,DateTime Menudate, string Meal,double formula)
        {
            VMenuSearchDAL mDAL = new VMenuSearchDAL();
            return mDAL.GetMenuChange(MenuID,Menudate,Meal,formula);
        }

        public MenuChangeData GetMenuChangeM(double MenuID, DateTime Menudate, string Meal, double formula)
        {
            VMenuSearchDAL mDAL = new VMenuSearchDAL();
            return mDAL.GetMenuChangeM(MenuID, Menudate, Meal, formula);
        }

        public double GetPortion(double menu, string start, string end)
        {
            VMenuSearchDAL mDAL = new VMenuSearchDAL();
            return mDAL.GetPortion(menu,start,end);
        }

        public MenuDetailData GetDetails(double LOID)
        {
            VMenuSearchDAL VMenuSearch = new VMenuSearchDAL();
            MenuDetailData MenuDetail = new MenuDetailData();
            VMenuSearch.GetDataByLOID(LOID, null);
            MenuDetail.LOID = VMenuSearch.LOID;
            MenuDetail.DIVISION = VMenuSearch.DIVISION;
            MenuDetail.DIVISIONNAME = VMenuSearch.DIVISIONNAME;
            MenuDetail.FOODCATEGORY = VMenuSearch.FOODCATEGORY;
            MenuDetail.FOODTYPE = VMenuSearch.FOODTYPE;
            //MenuDetail.ISSPECIFIC = VMenuSearch.ISSPECIFIC;
            MenuDetail.NAME = VMenuSearch.MENUNAME;
            MenuDetail.PHASE = VMenuSearch.PHASE;
            MenuDetail.STARTDATE = VMenuSearch.STARTDATE;
            MenuDetail.STATUS = VMenuSearch.STATUS;
            MenuDetail.STATUSNAME = VMenuSearch.STATUSNAME;
            MenuDetail.ENDDATE = VMenuSearch.ENDDATE;
            MenuDetail.BUDGETYEAR = VMenuSearch.BUDGETYEAR;
            MenuDetail.ITEM = VMenuSearch.ITEM;

            return MenuDetail;

        }

        public StdMenuItemControlData GetMenuItemData(double MenuID, DateTime day, string meal, double foodType, double foodCategory)
        {
            double energy = 0;
            double portion = 0;
            StdMenuItemControlData itemData = new StdMenuItemControlData();
            VFormulaSetMenuDAL VFormulaSetMenu = new VFormulaSetMenuDAL();
            VMenuItemDAL VMenuItem = new VMenuItemDAL();
            DataTable dt;
            itemData.AllDrinks = VFormulaSetMenu.GetDataListSourceMenu(MenuID, meal, day, "BV", foodType, foodCategory, "FORMULANAME", null);
            dt = VMenuItem.GetDataListSelected(MenuID, meal, day, "BV", "FORMULANAME", null);
            for (int i = 0; i < dt.Rows.Count; ++i)
            {
                if (!Convert.IsDBNull(dt.Rows[i]["ENERGY"])) energy += Convert.ToDouble(dt.Rows[i]["ENERGY"]);
            }
            if (dt.Rows.Count > 0)
                portion = Convert.ToDouble(dt.Rows[0]["PORTION"]);

            itemData.SelectedDrinks = dt;
            itemData.AllFruits = VFormulaSetMenu.GetDataListSourceMenu(MenuID, meal, day, "FR", foodType, foodCategory, "FORMULANAME", null);
            dt = VMenuItem.GetDataListSelected(MenuID, meal, day, "FR", "FORMULANAME", null);
            for (int i = 0; i < dt.Rows.Count; ++i)
            {
                if (!Convert.IsDBNull(dt.Rows[i]["ENERGY"])) energy += Convert.ToDouble(dt.Rows[i]["ENERGY"]);
            }
            if (dt.Rows.Count > 0)
                portion = Convert.ToDouble(dt.Rows[0]["PORTION"]);

            itemData.SelectedFruits = dt;
            itemData.AllRice = VFormulaSetMenu.GetDataListSourceMenu(MenuID, meal, day, "OD", foodType, foodCategory, "FORMULANAME", null);
            dt = VMenuItem.GetDataListSelected(MenuID, meal, day, "OD", "FORMULANAME", null);
            for (int i = 0; i < dt.Rows.Count; ++i)
            {
                if (!Convert.IsDBNull(dt.Rows[i]["ENERGY"])) energy += Convert.ToDouble(dt.Rows[i]["ENERGY"]);
            }
            if (dt.Rows.Count > 0)
                portion = Convert.ToDouble(dt.Rows[0]["PORTION"]);

            itemData.SelectedRice = dt;
            itemData.AllSavory = VFormulaSetMenu.GetDataListSourceMenu(MenuID, meal, day, "ND", foodType, foodCategory, "FORMULANAME", null);
            dt = VMenuItem.GetDataListSelected(MenuID, meal, day, "ND", "FORMULANAME", null);
            for (int i = 0; i < dt.Rows.Count; ++i)
            {
                if (!Convert.IsDBNull(dt.Rows[i]["ENERGY"])) energy += Convert.ToDouble(dt.Rows[i]["ENERGY"]);
            }
            if (dt.Rows.Count > 0)
                portion = Convert.ToDouble(dt.Rows[0]["PORTION"]);

            itemData.SelectedSavory = dt;
            itemData.ENERGY = energy;
            itemData.PORTION = portion;
            return itemData;
        }

        public DataTable GetMenuNutrientList(double MenuID, string meal, DateTime menuDate)
        {
            VMenuNutrientDAL VMenuNutrient = new VMenuNutrientDAL();
            return VMenuNutrient.GetDataListByCondition(MenuID, meal, menuDate, "NUTRIENTNAME", null);
        }

        public DataTable GetStdMenuList(double MenuID)
        {
            VMenuStdMenuDAL VMenuStdMenu = new VMenuStdMenuDAL();
            return VMenuStdMenu.GetDataListByMenu(MenuID, "LOID", null);
        }

        public bool InsertData(MenuDetailData MenuDetail, string UserID)
        {
            bool ret = true;
            zTran trans = new zTran();
            trans.CreateTransaction();

            MenuDetailDAL Menu = new MenuDetailDAL();
            Menu.DIVISION = MenuDetail.DIVISION;
            Menu.FOODCATEGORY = MenuDetail.FOODCATEGORY;
            Menu.FOODTYPE = MenuDetail.FOODTYPE;
            //Menu.ISSPECIFIC = MenuDetail.ISSPECIFIC;
            Menu.NAME = MenuDetail.NAME;
            Menu.BUDGETYEAR = MenuDetail.BUDGETYEAR;
            Menu.PHASE = MenuDetail.PHASE;
            Menu.STARTDATE = MenuDetail.STARTDATE;
            Menu.ENDDATE = MenuDetail.ENDDATE;
            Menu.STATUS = MenuDetail.STATUS;
            
            try
            {
                ret = Menu.InsertCurrentData(UserID, trans.Trans);
                if (!ret) _error = Menu.ErrorMessage;
                if (ret) ret = InsertMenuStandard(UserID, Menu.LOID, Menu.PHASE, Menu.BUDGETYEAR, trans.Trans);
                if (ret) ret = InsertMenuDisease(MenuDetail.MenuDisease, UserID, Menu.LOID, trans.Trans);

                if (ret)
                    trans.CommitTransaction();
                else
                    trans.RollbackTransaction();

                _LOID = Menu.LOID;
            }
            catch (Exception ex)
            {
                ret = false;
                _error = ex.Message;
                trans.RollbackTransaction();
            }

            return ret;
        }

        private bool InsertMenuDisease(ArrayList arrMenuDisease, string userID, double MenuID, OracleTransaction trans)
        {
            bool ret = true;
            MenuDiseaseDAL MenuDisease = new MenuDiseaseDAL();
            MenuDisease.DeleteDataByMenu(MenuID, trans);

            for (int i = 0; i < arrMenuDisease.Count; ++i)
            {
                MenuDisease = new MenuDiseaseDAL();
                MenuDiseaseData datMenuDisease = (MenuDiseaseData)arrMenuDisease[i];
                MenuDisease.DISEASECATEGORY = datMenuDisease.DISEASECATEGORY;
                MenuDisease.MENU = MenuID;
                MenuDisease.ISHIGH = datMenuDisease.ISHIGH;
                MenuDisease.ISLOW = datMenuDisease.ISLOW;
                MenuDisease.ISNON = datMenuDisease.ISNON;
                ret = MenuDisease.InsertCurrentData(userID, trans);
                if (!ret)
                {
                    _error = MenuDisease.ErrorMessage;
                    break;
                }
            }
            return ret;
        }

        private bool InsertMenuStandard(string userID, double MenuID,string Phase,double Year, OracleTransaction trans)
        {
            bool ret = true;
            MenuStandardDAL MenuStd = new MenuStandardDAL();
            int month = 0;
            int monthto = 0;
            int j = 0;
            if (Phase == "1")
                month = 10;
            else
                month = 4;

            monthto = month + 6;

            for (int i = month; i < monthto; ++i)
            {
                j = i % 12;
                if (j == 0) 
                    j = 12;

                MenuStd = new MenuStandardDAL();
                MenuStd.MMONTH = j;
                if (j > 9)
                    MenuStd.MYEAR = Year-1;
                else
                    MenuStd.MYEAR = Year;

                MenuStd.MENU = MenuID;
                MenuStd.MENUSOURCE = "Z";
                MenuStd.BMONTH = 0;
                MenuStd.BYEAR = 0;
                MenuStd.PATIENTQTY = 0;
                MenuStd.PATIENTSOURCE = "Z";
                MenuStd.STDMENU = 0;


                ret = MenuStd.InsertCurrentData(userID, trans);
                if (!ret)
                {
                    _error = MenuStd.ErrorMessage;
                    break;
                }
            }
            return ret;
        }

        public bool InsertMenuStandard(ArrayList arrMenuStd, double MenuID, string userID, OracleTransaction trans)
        {
            
            bool ret = true;
            MenuStandardDAL MenuStd = new MenuStandardDAL();
            MenuStd.DeleteDataByMenu(MenuID, trans);

            for (int i = 0; i < arrMenuStd.Count; ++i)
            {
                MenuStd = new MenuStandardDAL();
                MenuStandardData datMenuStd = (MenuStandardData)arrMenuStd[i];
                MenuStd.BMONTH = datMenuStd.BMONTH;
                MenuStd.MMONTH = datMenuStd.MMONTH;
                MenuStd.MYEAR = datMenuStd.MYEAR;
                MenuStd.MENU = MenuID;
                MenuStd.MENUSOURCE = datMenuStd.MENUSOURCE;
                MenuStd.BYEAR = datMenuStd.BYEAR;
                MenuStd.PATIENTQTY = datMenuStd.PATIENTQTY;
                MenuStd.PATIENTSOURCE = datMenuStd.PATIENTSOURCE;
                MenuStd.STDMENU = datMenuStd.STDMENU;

                ret = MenuStd.InsertCurrentData(userID, trans);
                if (!ret)
                {
                    _error = MenuStd.ErrorMessage;
                    break;
                }
            }

            return ret;
        }

        public bool UpdateData(MenuDetailData MenuDetail, string tab, string UserID)
        {
            bool ret = true;
            zTran trans = new zTran();
            trans.CreateTransaction();

            MenuDetailDAL Menu = new MenuDetailDAL();
            Menu.GetDataByLOID(MenuDetail.LOID, trans.Trans);
            Menu.DIVISION = MenuDetail.DIVISION;
            Menu.FOODCATEGORY = MenuDetail.FOODCATEGORY;
            Menu.FOODTYPE = MenuDetail.FOODTYPE;
            //Menu.ISSPECIFIC = MenuDetail.ISSPECIFIC;
            Menu.NAME = MenuDetail.NAME;
            Menu.BUDGETYEAR = MenuDetail.BUDGETYEAR;
            Menu.PHASE = MenuDetail.PHASE;
            Menu.STARTDATE = MenuDetail.STARTDATE;
            Menu.ENDDATE = MenuDetail.ENDDATE;
            Menu.STATUS = MenuDetail.STATUS;

            try
            {
                if (Menu.OnDB)
                {
                    ret = Menu.UpdateCurrentData(UserID, trans.Trans);
                
                    if (!ret) 
                        _error = Menu.ErrorMessage;

                    if (tab != "1" & tab != "2")
                    {
                        if (ret && MenuDetail.MEAL == "") ret = InsertMenuDisease(MenuDetail.MenuDisease, UserID, Menu.LOID, trans.Trans);

                        if (ret && MenuDetail.MEAL != "")
                        {
                            ret = InsertMenuItem(MenuDetail.MenuItem, UserID, Menu.LOID, MenuDetail.MEAL, MenuDetail.DATE, MenuDetail.PORTION, trans.Trans);
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

                _LOID = Menu.LOID;
            }
            catch (Exception ex)
            {
                ret = false;
                _error = ex.Message;
                trans.RollbackTransaction();
            }

            return ret;
        }
        private bool InsertMenuItem(ArrayList arrMenuItem, string userID, double MenuID, string meal, DateTime Date, double Portion, OracleTransaction trans)
        {
            bool ret = true;

            MenuDateDAL MenuDate = new MenuDateDAL();
            MenuDate.GetDataByCondition(MenuID, Date, trans);
            MenuDate.MENUDATE = Date;
            MenuDate.MENU = MenuID;
            MenuDate.PORTION = Portion;
            if (!MenuDate.OnDB)
                ret = MenuDate.InsertCurrentData(userID, trans);
            else
                ret = MenuDate.UpdateCurrentData(userID, trans);

            if (!ret) _error = MenuDate.ErrorMessage;

            if (ret)
            {
                MenuItemDAL MenuItem = new MenuItemDAL();
                MenuItem.DeleteDataByConditions(MenuID, meal, Date, trans);

                for (int i = 0; i < arrMenuItem.Count; ++i)
                {
                    MenuItem = new MenuItemDAL();
                    StdMenuItemData datMenuItem = (StdMenuItemData)arrMenuItem[i];
                    MenuItem.FORMULASET = datMenuItem.FORMULASET;
                    MenuItem.GROUPTYPE = datMenuItem.GROUPTYPE;
                    MenuItem.MATERIALMASTER = datMenuItem.MATERIALMASTER;
                    MenuItem.MEAL = meal;
                    MenuItem.MENUDATE = MenuDate.LOID;
                    MenuItem.QTY = (datMenuItem.QTY == 0 ? 1 : datMenuItem.QTY);
                    MenuItem.UNIT = datMenuItem.UNIT;
                    ret = MenuItem.InsertCurrentData(userID, trans);
                    if (!ret)
                    {
                        _error = MenuItem.ErrorMessage;
                        break;
                    }
                }
            }
            return ret;
        }
        public bool InsertChange(MenuItemChangeData mData,double menuitem, string UserID)
        {
            bool ret = true;
            zTran trans = new zTran();
            trans.CreateTransaction();

            MenuItemChangeDAL Menu = new MenuItemChangeDAL();
            Menu.FORMULASET = mData.FORMULASET;
            Menu.FORMULASET_NEW = mData.FORMULASET_NEW;
            Menu.GROUPTYPE = mData.GROUPTYPE;
            Menu.MATERIALMASTER = mData.MATERIALMASTER;
            Menu.MATERIALMASTER_NEW = mData.MATERIALMASTER_NEW;
            Menu.MEAL = mData.MEAL;
            Menu.MENUDATE = mData.MENUDATE;
            Menu.UNIT = mData.UNIT;
            Menu.QTY = mData.QTY;

            try
            {
                ret = Menu.InsertCurrentData(UserID, trans.Trans);
                if (!ret) _error = Menu.ErrorMessage;

                if (ret)
                    ret = UpdateMenuItem(Menu.FORMULASET_NEW, Menu.MATERIALMASTER_NEW, UserID, menuitem, trans.Trans);

                if (ret)
                    trans.CommitTransaction();
                else
                    trans.RollbackTransaction();

                _LOID = Menu.LOID;
            }
            catch (Exception ex)
            {
                ret = false;
                _error = ex.Message;
                trans.RollbackTransaction();
            }

            return ret;
        }
        public bool UpdateMenuItem(double formula,double materialmaster, string UserID, double menuitem, OracleTransaction trans)
        {
            bool ret = true;

            MenuItemDAL Menu = new MenuItemDAL();
            Menu.GetDataByLOID(menuitem, trans);
            Menu.FORMULASET = formula;
            Menu.MATERIALMASTER = materialmaster;

                if (Menu.OnDB)
                {
                    ret = Menu.UpdateCurrentData(UserID, trans);

                    if (!ret)
                        _error = Menu.ErrorMessage;

                }
                else
                {
                    ret = false;
                    _error = Data.Common.Utilities.DataResources.MSGEU002;
                }

            return ret;
        }

        public bool UpdateMenuItemM(double formula, string UserID, double menuitem, OracleTransaction trans)
        {
            bool ret = true;

            MenuItemDAL Menu = new MenuItemDAL();
            Menu.GetDataByLOID(menuitem, trans);
            Menu.MATERIALMASTER = formula;

            if (Menu.OnDB)
            {
                ret = Menu.UpdateCurrentData(UserID, trans);

                if (!ret)
                    _error = Menu.ErrorMessage;

            }
            else
            {
                ret = false;
                _error = Data.Common.Utilities.DataResources.MSGEU002;
            }

            return ret;
        }

        public bool DeleteByLOID(double cLOID)
        {
            zTran trans = new zTran();
            MenuDetailDAL Menu = new MenuDetailDAL();
            MenuDateDAL MenuDate = new MenuDateDAL();
            MenuDiseaseDAL MenuDisease = new MenuDiseaseDAL();
            MenuItemDAL MenuItem = new MenuItemDAL();
            MenuStandardDAL MenuStandard = new MenuStandardDAL();

            trans.CreateTransaction();
            bool ret = true;
            try
            {
                MenuItem.DeleteDataByMenu(cLOID, trans.Trans);
                MenuDate.DeleteDataByMenu(cLOID, trans.Trans);
                MenuStandard.DeleteDataByMenu(cLOID, trans.Trans);
                MenuDisease.DeleteDataByMenu(cLOID, trans.Trans);
                ret = Menu.DeleteDataByLOID(cLOID, trans.Trans);

                if (ret)
                    trans.CommitTransaction();
                else
                {
                    _error = Menu.ErrorMessage;
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

        public bool ApproveData(double LOID, string userID)
        {
            bool ret = true;

            MenuDetailDAL Menu = new MenuDetailDAL();
            Menu.GetDataByLOID(LOID, null);
            if (Menu.OnDB)
            {
                Menu.STATUS = "AP";
                ret = Menu.UpdateCurrentData(userID, null);
            }
            else
            {
                ret = false;
                _error = Data.Common.Utilities.DataResources.MSGEU002;
            }
            _LOID = Menu.LOID;
            return ret;
        }

        public bool CheckUniqueKey(double cLOID, string cNAME, double cFOODTYPE, double cFOODCATEGORY, double cBUDGETYEAR, string cPHASE)
        {
            MenuDetailDAL fDAL = new MenuDetailDAL();
            fDAL.GetDataByUniqueKey(cNAME, cFOODCATEGORY, cFOODTYPE, cBUDGETYEAR, cPHASE, null);
            return !fDAL.OnDB || (cLOID == fDAL.LOID);
        }
        public bool DeleteMenuDate(double Menu)
        {
            bool ret = true;
            zTran trans = new zTran();
            trans.CreateTransaction();

            MenuDateDAL MenuDate = new MenuDateDAL();
            MenuItemDAL MenuItem = new MenuItemDAL();
            MenuItem.GetDataByMenu(Menu, trans.Trans);
            if(MenuItem.OnDB)
                ret = MenuItem.DeleteDataByMenu(Menu, trans.Trans);

            if (ret)
            {
                MenuDate.GetDataByMenu(Menu, trans.Trans);
                if (MenuDate.OnDB) 
                    ret = MenuDate.DeleteDataByMenu(Menu, trans.Trans);
            }

            if (ret)
                trans.CommitTransaction();
            else
            {
                _error = MenuDate.ErrorMessage;
                trans.RollbackTransaction();
            }

            return ret;

        }
        public bool CopyStandard(double Portion, double Menu,double stdMenu, DateTime StartDate, DateTime EndDate , string UserID)
        {
            bool ret = true;
            zTran trans = new zTran();
            trans.CreateTransaction();

            MenuDateDAL MenuDate = new MenuDateDAL();
            MenuItemDAL MenuItem = new MenuItemDAL();

                DataTable dtStdMenu = GetStdMenuDateList(stdMenu);

                TimeSpan Date = EndDate - StartDate;
                int Day = Date.Days;

                for (int iday = 0; iday <= Day; iday++)
                {
                    MenuDate.MENU = Menu;
                    MenuDate.MENUDATE = StartDate.AddDays(iday);
                    MenuDate.PORTION = Portion;
                    try
                    {
                        ret = MenuDate.InsertCurrentData(UserID, trans.Trans);
                        if (ret)
                        {
                            DataRow[] drMenu = dtStdMenu.Select("MENUDATE = " + MenuDate.MENUDATE.Day.ToString());
                            ret = InsertMenuItem(Portion,UserID, drMenu, MenuDate.MENUDATE.Day, MenuDate.LOID, trans.Trans);

                        }
                        else
                        {
                            _error = MenuDate.ErrorMessage;
                            break;
                        }

                    }
                    catch (Exception ex)
                    {
                        _error = ex.Message;
                        ret = false;
                    }
                }

            if (ret)
                trans.CommitTransaction();
            else
                trans.RollbackTransaction();

            return ret;
        }

        private bool InsertMenuItem(double Portion,string userID,DataRow[] dr, int StdMenuDate,double MenuDateLoid, OracleTransaction trans)
        {
            bool ret = true;
            

          //  MenuDisease.DeleteDataByMenu(MenuID, trans);

            for (int i = 0; i < dr.Length; i++)
            {
                MenuItemDAL MenuItem = new MenuItemDAL();
                if (!Convert.IsDBNull(dr[i]["FORMULASET"]))
                    MenuItem.FORMULASET = Convert.ToDouble(dr[i]["FORMULASET"]);
                MenuItem.GROUPTYPE = dr[i]["GROUPTYPE"].ToString();
                if (!Convert.IsDBNull(dr[i]["MATERIALMASTER"]))
                    MenuItem.MATERIALMASTER = Convert.ToDouble(dr[i]["MATERIALMASTER"]);
                MenuItem.MEAL = dr[i]["MEAL"].ToString();
                MenuItem.MENUDATE = MenuDateLoid;
                MenuItem.QTY = 1;
                if (!Convert.IsDBNull(dr[i]["UNIT"]))
                    MenuItem.UNIT = Convert.ToDouble(dr[i]["UNIT"]);

                ret = MenuItem.InsertCurrentData(userID, trans);
                if (!ret)
                {
                    _error = MenuItem.ErrorMessage;
                    break;
                }
            }
            return ret;
        }

        public bool CopyDiary(double Portion, double Menu, int Month, int Year, DateTime StartDate, DateTime EndDate, string UserID)
        {
            bool ret = true;
            DataTable dtStdMenu = GetMenuDateList(Month, Year);
            if (dtStdMenu.Rows.Count > 0)
            {
                zTran trans = new zTran();
                trans.CreateTransaction();
                MenuDateDAL MenuDate = new MenuDateDAL();
                MenuItemDAL MenuItem = new MenuItemDAL();

                    TimeSpan Date = EndDate - StartDate;
                    int Day = Date.Days;

                    for (int iday = 0; iday <= Day; iday++)
                    {
                        MenuDate.MENU = Menu;
                        MenuDate.MENUDATE = StartDate.AddDays(iday);
                        MenuDate.PORTION = Portion;
                        try
                        {
                            ret = MenuDate.InsertCurrentData(UserID, trans.Trans);
                            if (ret)
                            {
                                DataRow[] drMenu = dtStdMenu.Select("MENUDAY = " + MenuDate.MENUDATE.Day.ToString());
                                if (drMenu.Length == 0)
                                {
                                    drMenu = dtStdMenu.Select("MENUDAY = 1");
                                }
                                ret = InsertMenuItem(Portion,UserID, drMenu, MenuDate.MENUDATE.Day, MenuDate.LOID, trans.Trans);

                            }
                            else
                            {
                                _error = MenuDate.ErrorMessage;
                                break;
                            }

                        }
                        catch (Exception ex)
                        {
                            _error = ex.Message;
                            ret = false;
                        }
                    }

                if (ret)
                    trans.CommitTransaction();
                else
                    trans.RollbackTransaction();
            }
            else
            {
                ret = false;
                _error = "ไม่พบข้อมูล";
            }

                return ret;


            }

        #region Work Nang

        public DataTable GetMenuFormulaList(double menuloid, DateTime Datefrom, DateTime Dateto, double meal, string group, string name,string orderstr)
        {
            VMenuFormulaListDAL vDAL = new VMenuFormulaListDAL();
            return vDAL.GetDataListByCondition(menuloid, Datefrom, Dateto, meal, group, name, orderstr, null);
        }

        #endregion
        }
}
