using System;
using System.Data;
using System.Data.OracleClient;
using DB = SHND.DAL.Utilities.OracleDB;
using SHND.Data.Common.Utilities;

namespace SHND.DAL.Views
{
    /// <summary>
    /// Represents a transaction for V_WELFARERIGHT view.
    /// [Created by 127.0.0.1 on August,11 2009]
    /// </summary>
    public class VWelfareRightDAL
    {

        public VWelfareRightDAL()
        {
        }

        #region Constant

        /// <summary>V_WELFARERIGHT</summary>
        private const string viewName = "V_WELFARERIGHT";

        #endregion

        #region Private Variables

        string _error = "";
        string _information = "";
        bool _OnDB = false;
        double _LOID = 0;
        string _MONTHORDER = "";
        double _QTYDATE = 0;
        string _RIGHTMONTH = "";
        double _RIGHTYEAR = 0;

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
        public double LOID
        {
            get { return _LOID; }
            set { _LOID = value; }
        }
        public string MONTHORDER
        {
            get { return _MONTHORDER; }
            set { _MONTHORDER = value; }
        }
        public double QTYDATE
        {
            get { return _QTYDATE; }
            set { _QTYDATE = value; }
        }
        public string RIGHTMONTH
        {
            get { return _RIGHTMONTH; }
            set { _RIGHTMONTH = value; }
        }
        public double RIGHTYEAR
        {
            get { return _RIGHTYEAR; }
            set { _RIGHTYEAR = value; }
        }

        #endregion

        #region Clear Data

        /// <summary>
        /// Initialize data.
        /// </summary>
        private void ClearData()
        {
            _LOID = 0;
            _MONTHORDER = "";
            _QTYDATE = 0;
            _RIGHTMONTH = "";
            _RIGHTYEAR = 0;
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

        public bool GetDataByLOID(double cLOID, OracleTransaction trans)
        {
            return doGetdata("LOID = " + DB.SetDouble(cLOID) + " ", trans);
        }

        public DataTable GetDataListByCondition(string YEARFROM, string YEARTO, string orderBy, OracleTransaction trans)
        {
            //build where clause
            string whStr = "";
            if (YEARFROM != "") whStr += (whStr.Trim() == "" ? "" : " AND ") + " RIGHTYEAR >= '" + YEARFROM + "' ";
            if (YEARTO != "") whStr += (whStr.Trim() == "" ? "" : " AND ") + " RIGHTYEAR <= '" + YEARTO + "' ";

            return GetDataList(whStr, orderBy, trans);
        }

        #endregion

        #region SQL Statements

        /// <summary>
        /// Gets the select statement for V_WELFARERIGHT table.
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
        /// Returns an indication whether the record of V_WELFARERIGHT by specified condition is retrieved successfully.
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
                        if (!Convert.IsDBNull(zRdr["LOID"])) _LOID = Convert.ToDouble(zRdr["LOID"]);
                        if (!Convert.IsDBNull(zRdr["MONTHORDER"])) _MONTHORDER = zRdr["MONTHORDER"].ToString();
                        if (!Convert.IsDBNull(zRdr["QTYDATE"])) _QTYDATE = Convert.ToDouble(zRdr["QTYDATE"]);
                        if (!Convert.IsDBNull(zRdr["RIGHTMONTH"])) _RIGHTMONTH = zRdr["RIGHTMONTH"].ToString();
                        if (!Convert.IsDBNull(zRdr["RIGHTYEAR"])) _RIGHTYEAR = Convert.ToDouble(zRdr["RIGHTYEAR"]);
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

        public double GetHoliday(DateTime Startdate,DateTime EndDate)
        {
            string sql = "SELECT * FROM HOLIDAY WHERE HOLIDAY BETWEEN " + DB.SetDateTime(Startdate) + " AND " + DB.SetDateTime(EndDate);

            DataTable dt = DB.ExecuteTable(sql);
            double holiday = 0;
            holiday = dt.Rows.Count;
            return holiday;
        }

    }
}