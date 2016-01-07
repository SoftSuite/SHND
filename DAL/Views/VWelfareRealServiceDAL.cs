using System;
using System.Data;
using System.Data.OracleClient;
using DB = SHND.DAL.Utilities.OracleDB;
using SHND.Data.Common.Utilities;

namespace SHND.DAL.Views
{
    /// <summary>
    /// Represents a transaction for V_WELFARE_REAL_SERVICE view.
    /// [Created by 127.0.0.1 on June,22 2009]
    /// </summary>
    public class VWelfareRealServiceDAL
    {

        public VWelfareRealServiceDAL()
        {
        }

        #region Constant

        /// <summary>V_WELFARE_REAL_SERVICE</summary>
        private const string viewName = "V_WELFARE_REAL_SERVICE";

        #endregion

        #region Private Variables

        string _error = "";
        string _information = "";
        bool _OnDB = false;
        double _COUPON = 0;
        string _CREATEBY = "";
        DateTime _CREATEON = new DateTime(1, 1, 1);
        double _DIVISION = 0;
        string _DIVISIONNAME = "";
        double _LOID = 0;
        DateTime _SERVICEDATE = new DateTime(1, 1, 1);
        double _TIFFIN = 0;
        string _UPDATEBY = "";
        DateTime _UPDATEON = new DateTime(1, 1, 1);
        double _GETCOUPON = 0;
        double _GETTIFFIN = 0;

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
        public double COUPON
        {
            get { return _COUPON; }
            set { _COUPON = value; }
        }
        public string CREATEBY
        {
            get { return _CREATEBY; }
            set { _CREATEBY = value; }
        }
        public DateTime CREATEON
        {
            get { return _CREATEON; }
            set { _CREATEON = value; }
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
        public double LOID
        {
            get { return _LOID; }
            set { _LOID = value; }
        }
        public DateTime SERVICEDATE
        {
            get { return _SERVICEDATE; }
            set { _SERVICEDATE = value; }
        }
        public double TIFFIN
        {
            get { return _TIFFIN; }
            set { _TIFFIN = value; }
        }
        public string UPDATEBY
        {
            get { return _UPDATEBY; }
            set { _UPDATEBY = value; }
        }
        public DateTime UPDATEON
        {
            get { return _UPDATEON; }
            set { _UPDATEON = value; }
        }
        public double GETCOUPON
        {
            get { return _GETCOUPON; }
            set { _GETCOUPON = value; }
        }
        public double GETTIFFIN
        {
            get { return _GETTIFFIN; }
            set { _GETTIFFIN = value; }
        }

        #endregion

        #region Clear Data

        /// <summary>
        /// Initialize data.
        /// </summary>
        private void ClearData()
        {
            _COUPON = 0;
            _CREATEBY = "";
            _CREATEON = new DateTime(1, 1, 1);
            _DIVISION = 0;
            _DIVISIONNAME = "";
            _LOID = 0;
            _SERVICEDATE = new DateTime(1, 1, 1);
            _TIFFIN = 0;
            _UPDATEBY = "";
            _UPDATEON = new DateTime(1, 1, 1);
            _GETCOUPON = 0;
            _GETTIFFIN = 0;
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

        public DataTable GetDataListByCondition(DateTime cDATEFROM, DateTime cDATETO, string cDIVISION, string orderBy, OracleTransaction trans)
        {
            //build where clause
            string whStr = "";
            if (cDATEFROM.Year > 1) whStr += (whStr.Trim() == "" ? "" : " AND ") + " TO_DATE(SERVICEDATE) >= " + DB.SetDate(cDATEFROM) + " ";
            if (cDATETO.Year > 1) whStr += (whStr.Trim() == "" ? "" : " AND ") + " TO_DATE(SERVICEDATE) <= " + DB.SetDate(cDATETO) + " ";
            if (cDIVISION.ToString() != "") whStr += (whStr.Trim() == "" ? "" : " AND ") + " DIVISION = " + DB.SetDouble(Convert.ToDouble(cDIVISION)) + " ";

            return GetDataList(whStr, orderBy, trans);
        }
        public bool GetDataByLOID(double cLOID, OracleTransaction trans)
        {
            return doGetdata("LOID = " + DB.SetDouble(cLOID) + " ", trans);
        }

        #endregion

        #region SQL Statements

        /// <summary>
        /// Gets the select statement for V_WELFARE_REAL_SERVICE table.
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
        /// Returns an indication whether the record of V_WELFARE_REAL_SERVICE by specified condition is retrieved successfully.
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
                        if (!Convert.IsDBNull(zRdr["COUPON"])) _COUPON = Convert.ToDouble(zRdr["COUPON"]);
                        if (!Convert.IsDBNull(zRdr["CREATEBY"])) _CREATEBY = zRdr["CREATEBY"].ToString();
                        if (!Convert.IsDBNull(zRdr["CREATEON"])) _CREATEON = Convert.ToDateTime(zRdr["CREATEON"]);
                        if (!Convert.IsDBNull(zRdr["DIVISION"])) _DIVISION = Convert.ToDouble(zRdr["DIVISION"]);
                        if (!Convert.IsDBNull(zRdr["DIVISIONNAME"])) _DIVISIONNAME = zRdr["DIVISIONNAME"].ToString();
                        if (!Convert.IsDBNull(zRdr["LOID"])) _LOID = Convert.ToDouble(zRdr["LOID"]);
                        if (!Convert.IsDBNull(zRdr["SERVICEDATE"])) _SERVICEDATE = Convert.ToDateTime(zRdr["SERVICEDATE"]);
                        if (!Convert.IsDBNull(zRdr["TIFFIN"])) _TIFFIN = Convert.ToDouble(zRdr["TIFFIN"]);
                        if (!Convert.IsDBNull(zRdr["UPDATEBY"])) _UPDATEBY = zRdr["UPDATEBY"].ToString();
                        if (!Convert.IsDBNull(zRdr["UPDATEON"])) _UPDATEON = Convert.ToDateTime(zRdr["UPDATEON"]);
                        if (!Convert.IsDBNull(zRdr["GETCOUPON"])) _GETCOUPON = Convert.ToDouble(zRdr["GETCOUPON"]);
                        if (!Convert.IsDBNull(zRdr["GETTIFFIN"])) _GETTIFFIN = Convert.ToDouble(zRdr["GETTIFFIN"]);

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