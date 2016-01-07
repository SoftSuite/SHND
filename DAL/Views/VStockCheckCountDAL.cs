using System;
using System.Data;
using System.Data.OracleClient;
using DB = SHND.DAL.Utilities.OracleDB;
using SHND.Data.Common.Utilities;

namespace SHND.DAL.Views
{
    /// <summary>
    /// Represents a transaction for V_STOCKCHECKCOUNT_SEARCH view.
    /// [Created by 127.0.0.1 on Febuary,16 2009]
    /// </summary>
    public class VStockCheckCountDAL
    {

        public VStockCheckCountDAL()
        {
        }

        #region Constant

        /// <summary>V_STOCKCHECKCOUNT_SEARCH</summary>
        private const string viewName = "V_STOCKCHECKCOUNT_SEARCH";

        #endregion

        #region Private Variables

        string _error = "";
        string _information = "";
        bool _OnDB = false;
        string _BATCHNO = "";
        string _CHECKDATE = "";
        double _MATERIALCLASS = 0;
        double _MATERIALMASTER = 0;
        string _REMARKS = "";
        double _SCLOID = 0;
        double _SILOID = 0;
        string _STATUS = "";
        string _STATUSNAME = "";
        string _STATUSRANK = "";
        double _WHLOID = 0;
        string _WHNAME = "";

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
        public string BATCHNO
        {
            get { return _BATCHNO; }
            set { _BATCHNO = value; }
        }
        public string CHECKDATE
        {
            get { return _CHECKDATE; }
            set { _CHECKDATE = value; }
        }
        public double MATERIALCLASS
        {
            get { return _MATERIALCLASS; }
            set { _MATERIALCLASS = value; }
        }
        public double MATERIALMASTER
        {
            get { return _MATERIALMASTER; }
            set { _MATERIALMASTER = value; }
        }
        public string REMARKS
        {
            get { return _REMARKS; }
            set { _REMARKS = value; }
        }
        public double SCLOID
        {
            get { return _SCLOID; }
            set { _SCLOID = value; }
        }
        public double SILOID
        {
            get { return _SILOID; }
            set { _SILOID = value; }
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
        public string STATUSRANK
        {
            get { return _STATUSRANK; }
            set { _STATUSRANK = value; }
        }
        public double WHLOID
        {
            get { return _WHLOID; }
            set { _WHLOID = value; }
        }
        public string WHNAME
        {
            get { return _WHNAME; }
            set { _WHNAME = value; }
        }

        #endregion

        #region Clear Data

        /// <summary>
        /// Initialize data.
        /// </summary>
        private void ClearData()
        {
            _BATCHNO = "";
            _CHECKDATE = "";
            _MATERIALCLASS = 0;
            _MATERIALMASTER = 0;
            _REMARKS = "";
            _SCLOID = 0;
            _SILOID = 0;
            _STATUS = "";
            _STATUSNAME = "";
            _STATUSRANK = "";
            _WHLOID = 0;
            _WHNAME = "";
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

        #endregion

        #region SQL Statements

        /// <summary>
        /// Gets the select statement for V_STOCKCHECKCOUNT_SEARCH table.
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
        /// Returns an indication whether the record of V_STOCKCHECKCOUNT_SEARCH by specified condition is retrieved successfully.
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
                        if (!Convert.IsDBNull(zRdr["BATCHNO"])) _BATCHNO = zRdr["BATCHNO"].ToString();
                        if (!Convert.IsDBNull(zRdr["CHECKDATE"])) _CHECKDATE = zRdr["CHECKDATE"].ToString();
                        if (!Convert.IsDBNull(zRdr["MATERIALCLASS"])) _MATERIALCLASS = Convert.ToDouble(zRdr["MATERIALCLASS"]);
                        if (!Convert.IsDBNull(zRdr["MATERIALMASTER"])) _MATERIALMASTER = Convert.ToDouble(zRdr["MATERIALMASTER"]);
                        if (!Convert.IsDBNull(zRdr["REMARKS"])) _REMARKS = zRdr["REMARKS"].ToString();
                        if (!Convert.IsDBNull(zRdr["SCLOID"])) _SCLOID = Convert.ToDouble(zRdr["SCLOID"]);
                        if (!Convert.IsDBNull(zRdr["SILOID"])) _SILOID = Convert.ToDouble(zRdr["SILOID"]);
                        if (!Convert.IsDBNull(zRdr["STATUS"])) _STATUS = zRdr["STATUS"].ToString();
                        if (!Convert.IsDBNull(zRdr["STATUSNAME"])) _STATUSNAME = zRdr["STATUSNAME"].ToString();
                        if (!Convert.IsDBNull(zRdr["STATUSRANK"])) _STATUSRANK = zRdr["STATUSRANK"].ToString();
                        if (!Convert.IsDBNull(zRdr["WHLOID"])) _WHLOID = Convert.ToDouble(zRdr["WHLOID"]);
                        if (!Convert.IsDBNull(zRdr["WHNAME"])) _WHNAME = zRdr["WHNAME"].ToString();
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