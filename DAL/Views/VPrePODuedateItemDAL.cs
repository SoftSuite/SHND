using System;
using System.Data;
using System.Data.OracleClient;
using DB = SHND.DAL.Utilities.OracleDB;
using SHND.Data.Common.Utilities;

namespace SHND.DAL.Views
{
    /// <summary>
    /// Represents a transaction for V_PREPODUEDATE_ITEM view.
    /// [Created by 127.0.0.1 on Febuary,23 2009]
    /// </summary>
    public class VPrePODuedateItemDAL
    {

        public VPrePODuedateItemDAL()
        {
        }

        #region Constant

        /// <summary>V_PREPODUEDATE_ITEM</summary>
        private const string viewName = "V_PREPODUEDATE_ITEM";

        #endregion

        #region Private Variables

        string _error = "";
        string _information = "";
        bool _OnDB = false;
        DateTime _DUEDATE = new DateTime(1, 1, 1);
        double _DUEQTY = 0;
        double _LOID = 0;
        double _PREPODIVISION = 0;
        double _PREPOITEM = 0;

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
        public DateTime DUEDATE
        {
            get { return _DUEDATE; }
            set { _DUEDATE = value; }
        }
        public double DUEQTY
        {
            get { return _DUEQTY; }
            set { _DUEQTY = value; }
        }
        public double LOID
        {
            get { return _LOID; }
            set { _LOID = value; }
        }
        public double PREPODIVISION
        {
            get { return _PREPODIVISION; }
            set { _PREPODIVISION = value; }
        }
        public double PREPOITEM
        {
            get { return _PREPOITEM; }
            set { _PREPOITEM = value; }
        }

        #endregion

        #region Clear Data

        /// <summary>
        /// Initialize data.
        /// </summary>
        private void ClearData()
        {
            _DUEDATE = new DateTime(1, 1, 1);
            _DUEQTY = 0;
            _LOID = 0;
            _PREPODIVISION = 0;
            _PREPOITEM = 0;
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

        public DataTable GetDataListByPrePO(double cPrePO, string orderBy, OracleTransaction trans)
        {
            return GetDataList("PREPODIVISION = " + DB.SetDouble(cPrePO), orderBy, trans);
        }

        public DataTable GetDataListBlank()
        {
            string sql = "SELECT 0 LOID, 0 PREPOITEM, '' DUEDATE, 0 DUEQTY, 0 PREPODIVISION, '' CODE ";
            sql += "FROM DUAL ";
            return DB.ExecuteTable(sql);
        }

        #endregion

        #region SQL Statements

        /// <summary>
        /// Gets the select statement for V_PREPODUEDATE_ITEM table.
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
        /// Returns an indication whether the record of V_PREPODUEDATE_ITEM by specified condition is retrieved successfully.
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
                        if (!Convert.IsDBNull(zRdr["DUEDATE"])) _DUEDATE = Convert.ToDateTime(zRdr["DUEDATE"]);
                        if (!Convert.IsDBNull(zRdr["DUEQTY"])) _DUEQTY = Convert.ToDouble(zRdr["DUEQTY"]);
                        if (!Convert.IsDBNull(zRdr["LOID"])) _LOID = Convert.ToDouble(zRdr["LOID"]);
                        if (!Convert.IsDBNull(zRdr["PREPODIVISION"])) _PREPODIVISION = Convert.ToDouble(zRdr["PREPODIVISION"]);
                        if (!Convert.IsDBNull(zRdr["PREPOITEM"])) _PREPOITEM = Convert.ToDouble(zRdr["PREPOITEM"]);
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