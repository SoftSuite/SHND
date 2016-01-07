using System;
using System.Data;
using System.Data.OracleClient;
using DB = SHND.DAL.Utilities.OracleDB;
using SHND.Data.Common.Utilities;

namespace SHND.DAL.Views
{
    /// <summary>
    /// Represents a transaction for V_FORMULAMILK_LIST view.
    /// [Created by 127.0.0.1 on Febuary,2 2009]
    /// </summary>
    public class VFormulaMilkListDAL
    {

        public VFormulaMilkListDAL()
        {
        }

        #region Constant

        /// <summary>V_FORMULAMILK_LIST</summary>
        private const string viewName = "V_FORMULAMILK_LIST";

        #endregion

        #region Private Variables

        string _error = "";
        string _information = "";
        bool _OnDB = false;
        double _ENERGY = 0;
        double _FMILOID = 0;
        double _FMLOID = 0;
        string _MATERIALNAME = "";
        double _MMLOID = 0;
        double _QTY = 0;
        string _UNITNAME = "";
        double _UULOID = 0;

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
        public double ENERGY
        {
            get { return _ENERGY; }
            set { _ENERGY = value; }
        }
        public double FMILOID
        {
            get { return _FMILOID; }
            set { _FMILOID = value; }
        }
        public double FMLOID
        {
            get { return _FMLOID; }
            set { _FMLOID = value; }
        }
        public string MATERIALNAME
        {
            get { return _MATERIALNAME; }
            set { _MATERIALNAME = value; }
        }
        public double MMLOID
        {
            get { return _MMLOID; }
            set { _MMLOID = value; }
        }
        public double QTY
        {
            get { return _QTY; }
            set { _QTY = value; }
        }
        public string UNITNAME
        {
            get { return _UNITNAME; }
            set { _UNITNAME = value; }
        }
        public double UULOID
        {
            get { return _UULOID; }
            set { _UULOID = value; }
        }

        #endregion

        #region Clear Data

        /// <summary>
        /// Initialize data.
        /// </summary>
        private void ClearData()
        {
            _ENERGY = 0;
            _FMILOID = 0;
            _FMLOID = 0;
            _MATERIALNAME = "";
            _MMLOID = 0;
            _QTY = 0;
            _UNITNAME = "";
            _UULOID = 0;
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
        /// Gets the select statement for V_FORMULAMILK_LIST table.
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
        /// Returns an indication whether the record of V_FORMULAMILK_LIST by specified condition is retrieved successfully.
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
                        if (!Convert.IsDBNull(zRdr["ENERGY"])) _ENERGY = Convert.ToDouble(zRdr["ENERGY"]);
                        if (!Convert.IsDBNull(zRdr["FMILOID"])) _FMILOID = Convert.ToDouble(zRdr["FMILOID"]);
                        if (!Convert.IsDBNull(zRdr["FMLOID"])) _FMLOID = Convert.ToDouble(zRdr["FMLOID"]);
                        if (!Convert.IsDBNull(zRdr["MATERIALNAME"])) _MATERIALNAME = zRdr["MATERIALNAME"].ToString();
                        if (!Convert.IsDBNull(zRdr["MMLOID"])) _MMLOID = Convert.ToDouble(zRdr["MMLOID"]);
                        if (!Convert.IsDBNull(zRdr["QTY"])) _QTY = Convert.ToDouble(zRdr["QTY"]);
                        if (!Convert.IsDBNull(zRdr["UNITNAME"])) _UNITNAME = zRdr["UNITNAME"].ToString();
                        if (!Convert.IsDBNull(zRdr["UULOID"])) _UULOID = Convert.ToDouble(zRdr["UULOID"]);
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

        #region My Work Nang

        private string sql_copy
        {
            get
            {
                string sql = "SELECT 0 AS FMLOID, 0 AS FMILOID, MATERIALNAME, MMLOID, UULOID, ";
                       sql += " UNITNAME, QTY, ENERGY ";
                       sql += " FROM " + viewName + " ";
                return sql;
            }
        }


        public DataTable GetDataCopy(string whereClause, string orderBy, OracleTransaction trans)
        {
            return DB.ExecuteTable(sql_copy + (whereClause == "" ? "" : "WHERE " + whereClause + " ") + (orderBy == "" ? "" : "ORDER BY " + DB.SetSortString(orderBy)), trans);
        }

        #endregion
        #endregion

    }
}