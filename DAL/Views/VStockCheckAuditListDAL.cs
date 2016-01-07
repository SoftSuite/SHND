using System;
using System.Data;
using System.Data.OracleClient;
using DB = SHND.DAL.Utilities.OracleDB;
using SHND.Data.Common.Utilities;

namespace SHND.DAL.Views
{
    /// <summary>
    /// Represents a transaction for V_STOCKCHECKAUDIT_LIST view.
    /// [Created by 127.0.0.1 on Febuary,18 2009]
    /// </summary>
    public class VStockCheckAuditListDAL
    {

        public VStockCheckAuditListDAL()
        {
        }

        #region Constant

        /// <summary>V_STOCKCHECKAUDIT_LIST</summary>
        private const string viewName = "V_STOCKCHECKAUDIT_LIST";

        #endregion

        #region Private Variables

        string _error = "";
        string _information = "";
        bool _OnDB = false;
        double _COUNTQTY = 0;
        double _IMPROVEQTY = 0;
        string _ISIMPROVE = "";
        string _MMCODE = "";
        double _MMLOID = 0;
        string _MMNAME = "";
        double _SCILOID = 0;
        double _SCLOID = 0;
        string _STATUS = "";
        string _STATUSNAME = "";
        string _STATUSRANK = "";
        double _STOCKQTY = 0;
        string _THNAME = "";

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
        public double COUNTQTY
        {
            get { return _COUNTQTY; }
            set { _COUNTQTY = value; }
        }
        public double IMPROVEQTY
        {
            get { return _IMPROVEQTY; }
            set { _IMPROVEQTY = value; }
        }
        public string ISIMPROVE
        {
            get { return _ISIMPROVE; }
            set { _ISIMPROVE = value; }
        }
        public string MMCODE
        {
            get { return _MMCODE; }
            set { _MMCODE = value; }
        }
        public double MMLOID
        {
            get { return _MMLOID; }
            set { _MMLOID = value; }
        }
        public string MMNAME
        {
            get { return _MMNAME; }
            set { _MMNAME = value; }
        }
        public double SCILOID
        {
            get { return _SCILOID; }
            set { _SCILOID = value; }
        }
        public double SCLOID
        {
            get { return _SCLOID; }
            set { _SCLOID = value; }
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
        public double STOCKQTY
        {
            get { return _STOCKQTY; }
            set { _STOCKQTY = value; }
        }
        public string THNAME
        {
            get { return _THNAME; }
            set { _THNAME = value; }
        }

        #endregion

        #region Clear Data

        /// <summary>
        /// Initialize data.
        /// </summary>
        private void ClearData()
        {
            _COUNTQTY = 0;
            _IMPROVEQTY = 0;
            _ISIMPROVE = "";
            _MMCODE = "";
            _MMLOID = 0;
            _MMNAME = "";
            _SCILOID = 0;
            _SCLOID = 0;
            _STATUS = "";
            _STATUSNAME = "";
            _STATUSRANK = "";
            _STOCKQTY = 0;
            _THNAME = "";
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
        /// Gets the select statement for V_STOCKCHECKAUDIT_LIST table.
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
        /// Returns an indication whether the record of V_STOCKCHECKAUDIT_LIST by specified condition is retrieved successfully.
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
                        if (!Convert.IsDBNull(zRdr["COUNTQTY"])) _COUNTQTY = Convert.ToDouble(zRdr["COUNTQTY"]);
                        if (!Convert.IsDBNull(zRdr["IMPROVEQTY"])) _IMPROVEQTY = Convert.ToDouble(zRdr["IMPROVEQTY"]);
                        if (!Convert.IsDBNull(zRdr["ISIMPROVE"])) _ISIMPROVE = zRdr["ISIMPROVE"].ToString();
                        if (!Convert.IsDBNull(zRdr["MMCODE"])) _MMCODE = zRdr["MMCODE"].ToString();
                        if (!Convert.IsDBNull(zRdr["MMLOID"])) _MMLOID = Convert.ToDouble(zRdr["MMLOID"]);
                        if (!Convert.IsDBNull(zRdr["MMNAME"])) _MMNAME = zRdr["MMNAME"].ToString();
                        if (!Convert.IsDBNull(zRdr["SCILOID"])) _SCILOID = Convert.ToDouble(zRdr["SCILOID"]);
                        if (!Convert.IsDBNull(zRdr["SCLOID"])) _SCLOID = Convert.ToDouble(zRdr["SCLOID"]);
                        if (!Convert.IsDBNull(zRdr["STATUS"])) _STATUS = zRdr["STATUS"].ToString();
                        if (!Convert.IsDBNull(zRdr["STATUSNAME"])) _STATUSNAME = zRdr["STATUSNAME"].ToString();
                        if (!Convert.IsDBNull(zRdr["STATUSRANK"])) _STATUSRANK = zRdr["STATUSRANK"].ToString();
                        if (!Convert.IsDBNull(zRdr["STOCKQTY"])) _STOCKQTY = Convert.ToDouble(zRdr["STOCKQTY"]);
                        if (!Convert.IsDBNull(zRdr["THNAME"])) _THNAME = zRdr["THNAME"].ToString();
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