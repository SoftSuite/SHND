using System;
using System.Data;
using System.Data.OracleClient;
using DB = SHND.DAL.Utilities.OracleDB;
using SHND.Data.Common.Utilities;
using SHND.Data.Formula;

namespace SHND.DAL.Views
{
    /// <summary>
    /// Represents a transaction for V_MENU_SEARCH view.
    /// [Created by 127.0.0.1 on January,23 2009]
    /// </summary>
    public class VMenuSearchDAL
    {

        public VMenuSearchDAL()
        {
        }

        #region Constant

        /// <summary>V_MENU_SEARCH</summary>
        private const string viewName = "V_MENU_SEARCH";

        #endregion

        #region Private Variables

        string _error = "";
        string _information = "";
        bool _OnDB = false;
        double _BUDGETYEAR = 0;
        double _DIVISION = 0;
        string _DIVISIONNAME = "";
        DateTime _ENDDATE = new DateTime(1, 1, 1);
        double _FOODCATEGORY = 0;
        string _FOODCATEGORYNAME = "";
        double _FOODTYPE = 0;
        string _FOODTYPENAME = "";
        double _ITEM = 0;
        double _LOID = 0;
        string _MENUNAME = "";
        string _PHASE = "";
        DateTime _STARTDATE = new DateTime(1, 1, 1);
        string _STATUS = "";
        string _STATUSNAME = "";

        #endregion

        #region Public Properties

        public string ViewName
        {
            get { return viewName; }
        }
        public string ErrorMessage
        {
            get { return _error; }
        }
        public string InformationMessage
        {
            get { return _information; }
        }
        public bool OnDB
        {
            get { return _OnDB; }
            set { _OnDB = value; }
        }
        public double BUDGETYEAR
        {
            get { return _BUDGETYEAR; }
            set { _BUDGETYEAR = value; }
        }
        public double DIVISION
        {
            get { return _DIVISION; }
            set { _DIVISION = value; }
        }
        public string DIVISIONNAME
        {
            get { return _DIVISIONNAME; }
            set { _DIVISIONNAME = value; }
        }
        public DateTime ENDDATE
        {
            get { return _ENDDATE; }
            set { _ENDDATE = value; }
        }
        public double FOODCATEGORY
        {
            get { return _FOODCATEGORY; }
            set { _FOODCATEGORY = value; }
        }
        public string FOODCATEGORYNAME
        {
            get { return _FOODCATEGORYNAME; }
            set { _FOODCATEGORYNAME = value; }
        }
        public double FOODTYPE
        {
            get { return _FOODTYPE; }
            set { _FOODTYPE = value; }
        }
        public string FOODTYPENAME
        {
            get { return _FOODTYPENAME; }
            set { _FOODTYPENAME = value; }
        }
        public double ITEM
        {
            get { return _ITEM; }
            set { _ITEM = value; }
        }
        public double LOID
        {
            get { return _LOID; }
            set { _LOID = value; }
        }
        public string MENUNAME
        {
            get { return _MENUNAME; }
            set { _MENUNAME = value; }
        }
        public string PHASE
        {
            get { return _PHASE; }
            set { _PHASE = value; }
        }
        public DateTime STARTDATE
        {
            get { return _STARTDATE; }
            set { _STARTDATE = value; }
        }
        public string STATUS
        {
            get { return _STATUS; }
            set { _STATUS = value; }
        }
        public string STATUSNAME
        {
            get { return _STATUSNAME; }
            set { _STATUSNAME = value; }
        }

        #endregion

        #region Clear Data

        /// <summary>
        /// Initialize data.
        /// </summary>
        private void ClearData()
        {
            _BUDGETYEAR = 0;
            _DIVISION = 0;
            _DIVISIONNAME = "";
            _ENDDATE = new DateTime(1, 1, 1);
            _FOODCATEGORY = 0;
            _FOODCATEGORYNAME = "";
            _FOODTYPE = 0;
            _FOODTYPENAME = "";
            _ITEM = 0;
            _LOID = 0;
            _MENUNAME = "";
            _PHASE = "";
            _STARTDATE = new DateTime(1, 1, 1);
            _STATUS = "";
            _STATUSNAME = "";
        }

        #endregion

        #region Public Methods

        /// <summary>
        /// Executes the select statement with the specified condition and return a System.Data.DataTable.
        /// </summary>
        /// <param name="whereClause">The condition for execute select statement.</param>
        /// <param name="orderBy">The fields for sort data.</param>
        /// <param name="trans">The System.Data.OracleClient.OracleTransaction used by this System.Data.OracleClient.OracleCommand.</param>
        /// <returns>The System.Data.DataTable object for specified condition.</returns>
        public DataTable GetDataList(string whereClause, string orderBy, OracleTransaction trans)
        {
            return DB.ExecuteTable(sql_select + (whereClause == "" ? "" : "WHERE " + whereClause + " ") + (orderBy == "" ? "" : "ORDER BY " + DB.SetSortString(orderBy)), trans);
        }


        public DataTable GetDataListByCondition(double cDIVISION, string cNAME, double cFOODTYPE, double cFOODCATEGORY, string orderBy, OracleTransaction trans)
        {
            string whText = " DIVISION = " + DB.SetDouble(cDIVISION) + " ";
            if (cNAME.Trim() != "") whText += (whText == "" ? "" : "AND ") + "UPPER(MENUNAME) LIKE " + DB.SetString("%" + cNAME.ToUpper() + "%") + " ";
            if (cFOODTYPE != 0) whText += (whText == "" ? "" : "AND ") + "FOODTYPE = " + DB.SetDouble(cFOODTYPE) + " ";
            if (cFOODCATEGORY != 0) whText += (whText == "" ? "" : "AND ") + "FOODCATEGORY = " + DB.SetDouble(cFOODCATEGORY) + " ";
            return GetDataList(whText, orderBy, trans);
        }

        public bool GetDataByLOID(double cLOID, OracleTransaction trans)
        {
            return doGetdata("LOID = " + DB.SetDouble(cLOID), trans);
        }

        public MenuChangeData GetMenuChange(double MenuID,DateTime Menudate, string Meal,double formula)
        {
            string sql = "SELECT * FROM V_MENUITEM WHERE MENU = " + DB.SetDouble(MenuID) + " AND MENUDATE = " + DB.SetDate(Menudate) + " AND MEAL = " + DB.SetString(Meal) + " AND FORMULASET = " + DB.SetDouble(formula);
            DataTable dt = DB.ExecuteTable(sql);
            MenuChangeData mData = new MenuChangeData();
            if (dt.Rows.Count > 0)
            {
                mData.FOODCATEGORY = dt.Rows[0]["FOODCATEGORY"].ToString();
                mData.FOODTYPE = dt.Rows[0]["FOODTYPE"].ToString();
                mData.GROUPTYPE = dt.Rows[0]["GROUPTYPE"].ToString();
                mData.MATERIALNAME = dt.Rows[0]["FORMULANAME"].ToString();
                mData.MATERIALMASTER = Convert.ToDouble(dt.Rows[0]["FORMULASET"]);
                mData.MEAL = dt.Rows[0]["MEAL"].ToString();
                mData.MENUDATE = Convert.ToDateTime(dt.Rows[0]["MENUDATE"]);
                mData.MENUITEMLOID = Convert.ToDouble(dt.Rows[0]["MENUITEM"]);
                mData.MENULOID = Convert.ToDouble(dt.Rows[0]["MENU"]);
                mData.MENUNAME = dt.Rows[0]["MENUNAME"].ToString();
                mData.MENUDATELOID = Convert.ToDouble(dt.Rows[0]["MENUDATELOID"]);
                mData.QTY = Convert.ToDouble(dt.Rows[0]["QTY"]);
                mData.UNIT = dt.Rows[0]["UNIT"] == DBNull.Value ? 0 : Convert.ToDouble(dt.Rows[0]["UNIT"]);
            }

            return mData;
        }

        public MenuChangeData GetMenuChangeM(double MenuID, DateTime Menudate, string Meal, double formula)
        {
            string sql = "SELECT * FROM V_MENUITEM WHERE MENU = " + DB.SetDouble(MenuID) + " AND MENUDATE = " + DB.SetDate(Menudate) + " AND MEAL = " + DB.SetString(Meal) + " AND MATERIALMASTER = " + DB.SetDouble(formula);
            DataTable dt = DB.ExecuteTable(sql);
            MenuChangeData mData = new MenuChangeData();
            if (dt.Rows.Count > 0)
            {
                mData.FOODCATEGORY = dt.Rows[0]["FOODCATEGORY"].ToString();
                mData.FOODTYPE = dt.Rows[0]["FOODTYPE"].ToString();
                mData.GROUPTYPE = dt.Rows[0]["GROUPTYPE"].ToString();
                mData.MATERIALNAME = dt.Rows[0]["FORMULANAME"].ToString();
                mData.MATERIALMASTER = Convert.ToDouble(dt.Rows[0]["MATERIALMASTER"]);
                mData.MEAL = dt.Rows[0]["MEAL"].ToString();
                mData.MENUDATE = Convert.ToDateTime(dt.Rows[0]["MENUDATE"]);
                mData.MENUITEMLOID = Convert.ToDouble(dt.Rows[0]["MENUITEM"]);
                mData.MENULOID = Convert.ToDouble(dt.Rows[0]["MENU"]);
                mData.MENUNAME = dt.Rows[0]["MENUNAME"].ToString();
                mData.MENUDATELOID = Convert.ToDouble(dt.Rows[0]["MENUDATELOID"]);
                mData.QTY = Convert.ToDouble(dt.Rows[0]["QTY"]);
                mData.UNIT = dt.Rows[0]["UNIT"] == DBNull.Value ? 0 : Convert.ToDouble(dt.Rows[0]["UNIT"]);

            }

            return mData;
        }
        public double GetPortion(double menu, string start, string end)
        {
            string sql = "select PKE_PATIENT.FN_CALPATIENTQTYBYMONTH(" + DB.SetDouble(menu) + "," + DB.SetString(start) + "," + DB.SetString(end) + ") QTY from dual";
            DataTable dt = DB.ExecuteTable(sql);
            double portion = 0;
            if (dt.Rows.Count > 0)
            {
                portion = Convert.ToDouble(dt.Rows[0]["QTY"]);
            }

            return portion;
        }
        #endregion

        #region SQL Statements

        /// <summary>
        /// Gets the select statement for V_MENU_SEARCH table.
        /// </summary>
        private string sql_select
        {
            get
            {
                string sql = "SELECT * FROM " + viewName + " ";
                return sql;
            }
        }

        #endregion

        #region Private Methods

        /// <summary>
        /// Returns an indication whether the record of V_MENU_SEARCH by specified condition is retrieved successfully.
        /// </summary>
        /// <param name="whText">The condition specify the deleting record(s).</param>
        /// <param name="trans">The System.Data.OracleClient.OracleTransaction used by this System.Data.OracleClient.OracleCommand.</param>
        /// <returns>true if data is retrieved successfully; otherwise, false.</returns>
        public bool doGetdata(string whText, OracleTransaction trans)
        {
            bool ret = true;
            ClearData();
            _OnDB = false;
            if (whText.Trim() != "")
            {
                string tmpWhere = "WHERE " + whText;
                OracleDataReader zRdr = null;
                try
                {
                    zRdr = DB.ExecuteReader(sql_select + tmpWhere, trans);
                    if (zRdr.Read())
                    {
                        _OnDB = true;
                        if (!Convert.IsDBNull(zRdr["BUDGETYEAR"])) _BUDGETYEAR = Convert.ToDouble(zRdr["BUDGETYEAR"]);
                        if (!Convert.IsDBNull(zRdr["DIVISION"])) _DIVISION = Convert.ToDouble(zRdr["DIVISION"]);
                        if (!Convert.IsDBNull(zRdr["DIVISIONNAME"])) _DIVISIONNAME = zRdr["DIVISIONNAME"].ToString();
                        if (!Convert.IsDBNull(zRdr["ENDDATE"])) _ENDDATE = Convert.ToDateTime(zRdr["ENDDATE"]);
                        if (!Convert.IsDBNull(zRdr["FOODCATEGORY"])) _FOODCATEGORY = Convert.ToDouble(zRdr["FOODCATEGORY"]);
                        if (!Convert.IsDBNull(zRdr["FOODCATEGORYNAME"])) _FOODCATEGORYNAME = zRdr["FOODCATEGORYNAME"].ToString();
                        if (!Convert.IsDBNull(zRdr["FOODTYPE"])) _FOODTYPE = Convert.ToDouble(zRdr["FOODTYPE"]);
                        if (!Convert.IsDBNull(zRdr["FOODTYPENAME"])) _FOODTYPENAME = zRdr["FOODTYPENAME"].ToString();
                        if (!Convert.IsDBNull(zRdr["ITEM"])) _ITEM = Convert.ToDouble(zRdr["ITEM"]);
                        if (!Convert.IsDBNull(zRdr["LOID"])) _LOID = Convert.ToDouble(zRdr["LOID"]);
                        if (!Convert.IsDBNull(zRdr["MENUNAME"])) _MENUNAME = zRdr["MENUNAME"].ToString();
                        if (!Convert.IsDBNull(zRdr["PHASE"])) _PHASE = zRdr["PHASE"].ToString();
                        if (!Convert.IsDBNull(zRdr["STARTDATE"])) _STARTDATE = Convert.ToDateTime(zRdr["STARTDATE"]);
                        if (!Convert.IsDBNull(zRdr["STATUS"])) _STATUS = zRdr["STATUS"].ToString();
                        if (!Convert.IsDBNull(zRdr["STATUSNAME"])) _STATUSNAME = zRdr["STATUSNAME"].ToString();
                    }
                    else
                    {
                        ret = false;
                        _error = DataResources.MSGEV002;
                    }
                    zRdr.Close();
                }
                catch (Exception ex)
                {
                    ex.ToString();
                    ret = false;
                    _error = DataResources.MSGEC104;
                    if (zRdr != null && !zRdr.IsClosed)
                        zRdr.Close();
                }
            }
            else
            {
                ret = false;
                _error = DataResources.MSGEV001;
            }
            return ret;
        }

        #endregion

    }
}