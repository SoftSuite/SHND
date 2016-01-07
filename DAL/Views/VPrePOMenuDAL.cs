using System;
using System.Data;
using System.Data.OracleClient;
using DB = SHND.DAL.Utilities.OracleDB;
using SHND.Data.Common.Utilities;

namespace SHND.DAL.Views
{
    /// <summary>
    /// Represents a transaction for V_PREPO_MENU view.
    /// [Created by 127.0.0.1 on Febuary,20 2009]
    /// </summary>
    public class VPrePOMenuDAL
    {

        public VPrePOMenuDAL()
        {
        }

        #region Constant

        /// <summary>V_PREPO_MENU</summary>
        private const string viewName = "V_PREPO_MENU";

        #endregion

        #region Private Variables

        string _error = "";
        string _information = "";
        bool _OnDB = false;
        double _BUDGETYEAR = 0;
        double _DIVISION = 0;
        double _LOID = 0;
        DateTime _MENUDATE = new DateTime(1, 1, 1);
        string _MENUNAME = "";
        string _PHASE = "";
        double _PORTIONMENU = 0;
        double _PORTIONNOW = 0;

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
        public double LOID
        {
            get { return _LOID; }
            set { _LOID = value; }
        }
        public DateTime MENUDATE
        {
            get { return _MENUDATE; }
            set { _MENUDATE = value; }
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
        public double PORTIONMENU
        {
            get { return _PORTIONMENU; }
            set { _PORTIONMENU = value; }
        }
        public double PORTIONNOW
        {
            get { return _PORTIONNOW; }
            set { _PORTIONNOW = value; }
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
            _LOID = 0;
            _MENUDATE = new DateTime(1, 1, 1);
            _MENUNAME = "";
            _PHASE = "";
            _PORTIONMENU = 0;
            _PORTIONNOW = 0;
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

        public DataTable GetDataListByDate(DateTime cMENUDATE, double cDIVISION, string orderBy, OracleTransaction trans)
        {
            return GetDataList("MENUDATE = " + DB.SetDate(cMENUDATE) + " AND DIVISION = " + DB.SetDouble(cDIVISION), orderBy, trans);
        }

        public DataTable GetDataListByDate(DateTime cMENUDATE, string orderBy, OracleTransaction trans)
        {
            return GetDataList("MENUDATE = " + DB.SetDate(cMENUDATE), orderBy, trans);
        }

        #endregion

        #region SQL Statements

        /// <summary>
        /// Gets the select statement for V_PREPO_MENU table.
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
        /// Returns an indication whether the record of V_PREPO_MENU by specified condition is retrieved successfully.
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
                        if (!Convert.IsDBNull(zRdr["LOID"])) _LOID = Convert.ToDouble(zRdr["LOID"]);
                        if (!Convert.IsDBNull(zRdr["MENUDATE"])) _MENUDATE = Convert.ToDateTime(zRdr["MENUDATE"]);
                        if (!Convert.IsDBNull(zRdr["MENUNAME"])) _MENUNAME = zRdr["MENUNAME"].ToString();
                        if (!Convert.IsDBNull(zRdr["PHASE"])) _PHASE = zRdr["PHASE"].ToString();
                        if (!Convert.IsDBNull(zRdr["PORTIONMENU"])) _PORTIONMENU = Convert.ToDouble(zRdr["PORTIONMENU"]);
                        if (!Convert.IsDBNull(zRdr["PORTIONNOW"])) _PORTIONNOW = Convert.ToDouble(zRdr["PORTIONNOW"]);
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