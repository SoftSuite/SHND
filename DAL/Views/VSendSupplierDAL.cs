using System;
using System.Data;
using System.Data.OracleClient;
using DB = SHND.DAL.Utilities.OracleDB;
using SHND.Data.Common.Utilities;

namespace SHND.DAL.Views
{
    /// <summary>
    /// Represents a transaction for V_SENDSUPPLIER_SEARCH view.
    /// [Created by 127.0.0.1 on Febuary,27 2009]
    /// </summary>
    public class VSendSupplierDAL
    {

        public VSendSupplierDAL()
        {
        }

        #region Constant

        /// <summary>V_SENDSUPPLIER_SEARCH</summary>
        private const string viewName = "V_SENDSUPPLIER_SEARCH";

        #endregion

        #region Private Variables

        string _error = "";
        string _information = "";
        bool _OnDB = false;
        string _CODE = "";
        double _SOLOID = 0;
        double _SPLOID = 0;
        string _SPNAME = "";
        string _STATUSNAME = "";
        string _STATUSRANK = "";
        DateTime _STOCKOUTDATE = new DateTime(1, 1, 1);

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
        public string CODE
        {
            get { return _CODE; }
            set { _CODE = value; }
        }
        public double SOLOID
        {
            get { return _SOLOID; }
            set { _SOLOID = value; }
        }
        public double SPLOID
        {
            get { return _SPLOID; }
            set { _SPLOID = value; }
        }
        public string SPNAME
        {
            get { return _SPNAME; }
            set { _SPNAME = value; }
        }
        public string STATUSNAME
        {
            get { return _STATUSNAME; }
            set { _STATUSNAME = value; }
        }
        public string STATUSRANK
        {
            get { return _STATUSRANK; }
            set { _STATUSRANK = value; }
        }
        public DateTime STOCKOUTDATE
        {
            get { return _STOCKOUTDATE; }
            set { _STOCKOUTDATE = value; }
        }

        #endregion

        #region Clear Data

        /// <summary>
        /// Initialize data.
        /// </summary>
        private void ClearData()
        {
            _CODE = "";
            _SOLOID = 0;
            _SPLOID = 0;
            _SPNAME = "";
            _STATUSNAME = "";
            _STATUSRANK = "";
            _STOCKOUTDATE = new DateTime(1, 1, 1);
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

        public DataTable GetDistinctDataList(string whereClause, string orderBy, OracleTransaction trans)
        {
            return DB.ExecuteTable(sql_distinct + (whereClause == "" ? "" : "WHERE " + whereClause + " ") + (orderBy == "" ? "" : "ORDER BY " + DB.SetSortString(orderBy)), trans);
        }

        #endregion

        #region SQL Statements

        /// <summary>
        /// Gets the select statement for V_SENDSUPPLIER_SEARCH table.
        /// </summary>
        private string sql_select
        {
            get
            {
                string sql = "SELECT * FROM " + viewName + " ";
                return sql;
            }
        }

        private string sql_distinct
        {
            get
            {
                string sql = "SELECT DISTINCT  SOLOID,CODE, STATUSRANK, STATUSNAME, TO_CHAR(STOCKOUTDATE,'DD/MM/YYYY') STOCKOUTDATE, ";
                       sql += " SPNAME, SPLOID, STATUS  ";
                       sql += " FROM " + viewName + " ";
                return sql;
            }
        }

        #endregion

        #region Private Methods

        /// <summary>
        /// Returns an indication whether the record of V_SENDSUPPLIER_SEARCH by specified condition is retrieved successfully.
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
                        if (!Convert.IsDBNull(zRdr["CODE"])) _CODE = zRdr["CODE"].ToString();
                        if (!Convert.IsDBNull(zRdr["SOLOID"])) _SOLOID = Convert.ToDouble(zRdr["SOLOID"]);
                        if (!Convert.IsDBNull(zRdr["SPLOID"])) _SPLOID = Convert.ToDouble(zRdr["SPLOID"]);
                        if (!Convert.IsDBNull(zRdr["SPNAME"])) _SPNAME = zRdr["SPNAME"].ToString();
                        if (!Convert.IsDBNull(zRdr["STATUSNAME"])) _STATUSNAME = zRdr["STATUSNAME"].ToString();
                        if (!Convert.IsDBNull(zRdr["STATUSRANK"])) _STATUSRANK = zRdr["STATUSRANK"].ToString();
                        if (!Convert.IsDBNull(zRdr["STOCKOUTDATE"])) _STOCKOUTDATE = Convert.ToDateTime(zRdr["STOCKOUTDATE"]);
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