using System;
using System.Data;
using System.Data.OracleClient;
using DB = SHND.DAL.Utilities.OracleDB;
using SHND.Data.Common.Utilities;

namespace SHND.DAL.Views
{
    /// <summary>
    /// Represents a transaction for V_MENUITEM view.
    /// [Created by 127.0.0.1 on January,23 2009]
    /// </summary>
    public class VMenuItemDAL
    {

        public VMenuItemDAL()
        {
        }

        #region Constant

        /// <summary>V_MENUITEM</summary>
        private const string viewName = "V_MENUITEM";

        #endregion

        #region Private Variables

        string _error = "";
        string _information = "";
        bool _OnDB = false;
        double _BUDGETYEAR = 0;
        string _CODE = "";
        string _CODEUNIT = "";
        double _ENERGY = 0;
        double _PORTION = 0;
        string _FORMULANAME = "";
        double _FORMULASET = 0;
        string _GROUPTYPE = "";
        double _MATERIALMASTER = 0;
        string _MEAL = "";
        double _MENU = 0;
        DateTime _MENUDATE = new DateTime(1, 1, 1);
        string _MENUDAY = "";
        string _MENUMONTH = "";
        string _MENUYEAR = "";
        string _PHASE = "";

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
        public string CODE
        {
            get { return _CODE; }
            set { _CODE = value; }
        }
        public string CODEUNIT
        {
            get { return _CODEUNIT; }
            set { _CODEUNIT = value; }
        }
        public double ENERGY
        {
            get { return _ENERGY; }
            set { _ENERGY = value; }
        }
        public double PORTION
        {
            get { return _PORTION; }
            set { _PORTION = value; }
        }
        public string FORMULANAME
        {
            get { return _FORMULANAME; }
            set { _FORMULANAME = value; }
        }
        public double FORMULASET
        {
            get { return _FORMULASET; }
            set { _FORMULASET = value; }
        }
        public string GROUPTYPE
        {
            get { return _GROUPTYPE; }
            set { _GROUPTYPE = value; }
        }
        public double MATERIALMASTER
        {
            get { return _MATERIALMASTER; }
            set { _MATERIALMASTER = value; }
        }
        public string MEAL
        {
            get { return _MEAL; }
            set { _MEAL = value; }
        }
        public double MENU
        {
            get { return _MENU; }
            set { _MENU = value; }
        }
        public DateTime MENUDATE
        {
            get { return _MENUDATE; }
            set { _MENUDATE = value; }
        }
        public string MENUDAY
        {
            get { return _MENUDAY; }
            set { _MENUDAY = value; }
        }
        public string MENUMONTH
        {
            get { return _MENUMONTH; }
            set { _MENUMONTH = value; }
        }
        public string MENUYEAR
        {
            get { return _MENUYEAR; }
            set { _MENUYEAR = value; }
        }
        public string PHASE
        {
            get { return _PHASE; }
            set { _PHASE = value; }
        }

        #endregion

        #region Clear Data

        /// <summary>
        /// Initialize data.
        /// </summary>
        private void ClearData()
        {
            _BUDGETYEAR = 0;
            _CODE = "";
            _CODEUNIT = "";
            _ENERGY = 0;
            _PORTION = 0;
            _FORMULANAME = "";
            _FORMULASET = 0;
            _GROUPTYPE = "";
            _MATERIALMASTER = 0;
            _MEAL = "";
            _MENU = 0;
            _MENUDATE = new DateTime(1, 1, 1);
            _MENUDAY = "";
            _MENUMONTH = "";
            _MENUYEAR = "";
            _PHASE = "";
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

        public DataTable GetDataListByMonth(int month, int year, string orderBy, OracleTransaction trans)
        {
            return GetDataList("MENUMONTH = " + DB.SetDouble(month) + " AND MENUYEAR = " + DB.SetDouble(year) + " ", orderBy, trans);
        }

        public DataTable GetDataListByMenu(double Menu, string Phase, double year, string orderBy, OracleTransaction trans)
        {
            return GetDataList("MENU = " + DB.SetDouble(Menu) + " AND PHASE = " + DB.SetString(Phase) + " AND BUDGETYEAR = " + DB.SetDouble(year) + " ", orderBy, trans);
        }
        public DataTable GetDataListSelected(double cMENU, string cMEAL, DateTime cMENUDATE, string cGROUPTYPE, string orderBy, OracleTransaction trans)
        {
            return GetDataList("MENU = " + DB.SetDouble(cMENU) + " AND MEAL = " + DB.SetString(cMEAL) + " AND MENUDATE = " + DB.SetDateTime(cMENUDATE) + " AND GROUPTYPE = " + DB.SetString(cGROUPTYPE), orderBy, trans);
        }
        #endregion

        #region SQL Statements

        /// <summary>
        /// Gets the select statement for V_MENUITEM table.
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
        /// Returns an indication whether the record of V_MENUITEM by specified condition is retrieved successfully.
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
                        if (!Convert.IsDBNull(zRdr["CODE"])) _CODE = zRdr["CODE"].ToString();
                        if (!Convert.IsDBNull(zRdr["CODEUNIT"])) _CODEUNIT = zRdr["CODEUNIT"].ToString();
                        if (!Convert.IsDBNull(zRdr["ENERGY"])) _ENERGY = Convert.ToDouble(zRdr["ENERGY"]);
                        if (!Convert.IsDBNull(zRdr["PORTION"])) _ENERGY = Convert.ToDouble(zRdr["PORTION"]);
                        if (!Convert.IsDBNull(zRdr["FORMULANAME"])) _FORMULANAME = zRdr["FORMULANAME"].ToString();
                        if (!Convert.IsDBNull(zRdr["FORMULASET"])) _FORMULASET = Convert.ToDouble(zRdr["FORMULASET"]);
                        if (!Convert.IsDBNull(zRdr["GROUPTYPE"])) _GROUPTYPE = zRdr["GROUPTYPE"].ToString();
                        if (!Convert.IsDBNull(zRdr["MATERIALMASTER"])) _MATERIALMASTER = Convert.ToDouble(zRdr["MATERIALMASTER"]);
                        if (!Convert.IsDBNull(zRdr["MEAL"])) _MEAL = zRdr["MEAL"].ToString();
                        if (!Convert.IsDBNull(zRdr["MENU"])) _MENU = Convert.ToDouble(zRdr["MENU"]);
                        if (!Convert.IsDBNull(zRdr["MENUDATE"])) _MENUDATE = Convert.ToDateTime(zRdr["MENUDATE"]);
                        if (!Convert.IsDBNull(zRdr["MENUDAY"])) _MENUDAY = zRdr["MENUDAY"].ToString();
                        if (!Convert.IsDBNull(zRdr["MENUMONTH"])) _MENUMONTH = zRdr["MENUMONTH"].ToString();
                        if (!Convert.IsDBNull(zRdr["MENUYEAR"])) _MENUYEAR = zRdr["MENUYEAR"].ToString();
                        if (!Convert.IsDBNull(zRdr["PHASE"])) _PHASE = zRdr["PHASE"].ToString();
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