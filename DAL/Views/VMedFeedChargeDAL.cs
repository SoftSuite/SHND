using System;
using System.Data;
using System.Data.OracleClient;
using DB = SHND.DAL.Utilities.OracleDB;
using SHND.Data.Common.Utilities;

namespace SHND.DAL.Views
{
    /// <summary>
    /// Represents a transaction for V_MEDFEEDCHARGE_SEARCH view.
    /// [Created by 127.0.0.1 on May,11 2009]
    /// </summary>
    public class VMedFeedChargeDAL
    {

        public VMedFeedChargeDAL()
        {
        }

        #region Constant

        /// <summary>V_MEDFEEDCHARGE_SEARCH</summary>
        private const string viewName = "V_MEDFEEDCHARGE_SEARCH";

        #endregion

        #region Private Variables

        string _error = "";
        string _information = "";
        bool _OnDB = false;
        DateTime _CHARGEDATE = new DateTime(1, 1, 1);
        string _CODE = "";
        double _LOID = 0;
        string _STATUS = "";
        string _STATUSNAME = "";
        string _STATUSRANK = "";
        double _WARD = 0;
        string _WARDNAME = "";

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
        public DateTime CHARGEDATE
        {
            get { return _CHARGEDATE; }
            set { _CHARGEDATE = value; }
        }
        public string CODE
        {
            get { return _CODE; }
            set { _CODE = value; }
        }
        public double LOID
        {
            get { return _LOID; }
            set { _LOID = value; }
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
        public double WARD
        {
            get { return _WARD; }
            set { _WARD = value; }
        }
        public string WARDNAME
        {
            get { return _WARDNAME; }
            set { _WARDNAME = value; }
        }

        #endregion

        #region Clear Data

        /// <summary>
        /// Initialize data.
        /// </summary>
        private void ClearData()
        {
            _CHARGEDATE = new DateTime(1, 1, 1);
            _CODE = "";
            _LOID = 0;
            _STATUS = "";
            _STATUSNAME = "";
            _STATUSRANK = "";
            _WARD = 0;
            _WARDNAME = "";
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
        /// Gets the select statement for V_MEDFEEDCHARGE_SEARCH table.
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
        /// Returns an indication whether the record of V_MEDFEEDCHARGE_SEARCH by specified condition is retrieved successfully.
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
                            if (!Convert.IsDBNull(zRdr["CHARGEDATE"])) _CHARGEDATE = Convert.ToDateTime(zRdr["CHARGEDATE"]);
                            if (!Convert.IsDBNull(zRdr["CODE"])) _CODE = zRdr["CODE"].ToString();
                            if (!Convert.IsDBNull(zRdr["LOID"])) _LOID = Convert.ToDouble(zRdr["LOID"]);
                            if (!Convert.IsDBNull(zRdr["STATUS"])) _STATUS = zRdr["STATUS"].ToString();
                            if (!Convert.IsDBNull(zRdr["STATUSNAME"])) _STATUSNAME = zRdr["STATUSNAME"].ToString();
                            if (!Convert.IsDBNull(zRdr["STATUSRANK"])) _STATUSRANK = zRdr["STATUSRANK"].ToString();
                            if (!Convert.IsDBNull(zRdr["WARD"])) _WARD = Convert.ToDouble(zRdr["WARD"]);
                            if (!Convert.IsDBNull(zRdr["WARDNAME"])) _WARDNAME = zRdr["WARDNAME"].ToString();
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

        #region My work Nang

        private string sql_rank
        {
            get
            {
                string sql = "SELECT CASE WHEN RANK() OVER(PARTITION BY CODE ORDER BY CODE, CHARGEDATE) = 1 THEN 1 ELSE 0 END RANK, A.* FROM " + viewName + " A ";
                return sql;
            }
        }

        public DataTable GetRankDataList(string whereClause, string orderBy, OracleTransaction trans)
        {
            DataTable dt = DB.ExecuteTable(sql_rank + (whereClause == "" ? "" : "WHERE " + whereClause + " ") + (orderBy == "" ? "" : "ORDER BY " + DB.SetSortString(orderBy)), trans);
            int index = 1;
            for (int i = 0; i < dt.Rows.Count; ++i)
            {
                if (Convert.ToDouble(dt.Rows[i]["RANK"]) == 1)
                {
                    dt.Rows[i]["RANK"] = index;
                    ++index;
                }
            }
            return dt;
        }

        public DataTable GetDataListByConditions(string cCodeFrom, string cCodeTo, DateTime cChargeDateFROM, DateTime cChargeDateTO, double cWARD, string cStatusFrom, string cStatusTo, string orderBy, OracleTransaction trans)
        {
            string whText = "";

            if (cWARD != 0) whText += (whText == "" ? "" : "AND ") + "WARD = " + DB.SetDouble(cWARD) + " ";
            if (cCodeFrom.Trim() != "") whText += (whText == "" ? "" : "AND ") + " UPPER(CODE) >= UPPER(" + DB.SetString(cCodeFrom.Trim())+ ") ";
            if (cCodeTo.Trim() != "") whText += (whText == "" ? "" : "AND ") + " UPPER(CODE) <= UPPER(" + DB.SetString(cCodeTo.Trim()) + ") ";

            if (cChargeDateFROM.Year != 1) whText += (whText == "" ? "" : "AND ") + "(CHARGEDATE >= " + DB.SetDateTime(cChargeDateFROM) + " OR CHARGEDATE >=" + DB.SetDateTime(cChargeDateFROM) + ") ";
            if (cChargeDateTO.Year != 1) whText += (whText == "" ? "" : "AND ") + "(CHARGEDATE <= " + DB.SetDateTime(cChargeDateTO) + " OR CHARGEDATE <=" + DB.SetDateTime(cChargeDateTO) + ") ";
            if (cStatusFrom.Trim() != "") whText += (whText == "" ? "" : "AND ") + "(STATUSRANK >= " + DB.SetString(cStatusFrom) + " OR STATUSRANK >=" + DB.SetString(cStatusFrom) + ") ";
            if (cStatusTo.Trim() != "") whText += (whText == "" ? "" : "AND ") + "(STATUSRANK <= " + DB.SetString(cStatusTo) + " OR STATUSRANK <=" + DB.SetString(cStatusTo) + ") ";

            return GetRankDataList(whText, orderBy, trans);
        }

        #endregion

    }
}