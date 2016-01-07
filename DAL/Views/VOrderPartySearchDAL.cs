using System;
using System.Data;
using System.Data.OracleClient;
using DB = SHND.DAL.Utilities.OracleDB;
using SHND.Data.Common.Utilities;

namespace SHND.DAL.Views
{
    /// <summary>
    /// Represents a transaction for V_ORDER_PARTY_SEARCH view.
    /// [Created by 127.0.0.1 on March,11 2009]
    /// </summary>
    public class VOrderPartySearchDAL
    {

        public VOrderPartySearchDAL()
        {
        }

        #region Constant

        /// <summary>V_ORDER_PARTY_SEARCH</summary>
        private const string viewName = "V_ORDER_PARTY_SEARCH";

        #endregion

        #region Private Variables

        string _error = "";
        string _information = "";
        bool _OnDB = false;
        double _DIVISIONID = 0;
        string _DIVISIONNAME = "";
        string _NDAPPROVE = "";
        double _OPLOID = 0;
        string _ORDERCODE = "";
        DateTime _ORDERDATE = new DateTime(1, 1, 1);
        DateTime _PARTYDATETIME = new DateTime(1, 1, 1);
        string _PARTYTYPE = "";
        double _PARTYTYPEID = 0;
        string _PLACE = "";
        string _STATUS = "";
        string _STATUSNAME = "";
        double _VISITORQTY = 0;
        DateTime _PARTYFULLDATETIME = new DateTime(1, 1, 1);

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
        public double DIVISIONID
        {
            get { return _DIVISIONID; }
            set { _DIVISIONID = value; }
        }
        public string DIVISIONNAME
        {
            get { return _DIVISIONNAME; }
            set { _DIVISIONNAME = value; }
        }
        public string NDAPPROVE
        {
            get { return _NDAPPROVE; }
            set { _NDAPPROVE = value; }
        }
        public double OPLOID
        {
            get { return _OPLOID; }
            set { _OPLOID = value; }
        }
        public string ORDERCODE
        {
            get { return _ORDERCODE; }
            set { _ORDERCODE = value; }
        }
        public DateTime ORDERDATE
        {
            get { return _ORDERDATE; }
            set { _ORDERDATE = value; }
        }
        public DateTime PARTYDATETIME
        {
            get { return _PARTYDATETIME; }
            set { _PARTYDATETIME = value; }
        }
        public string PARTYTYPE
        {
            get { return _PARTYTYPE; }
            set { _PARTYTYPE = value; }
        }
        public double PARTYTYPEID
        {
            get { return _PARTYTYPEID; }
            set { _PARTYTYPEID = value; }
        }
        public string PLACE
        {
            get { return _PLACE; }
            set { _PLACE = value; }
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
        public double VISITORQTY
        {
            get { return _VISITORQTY; }
            set { _VISITORQTY = value; }
        }

        public DateTime PARTYFULLDATETIME
        {
            get { return _PARTYFULLDATETIME; }
            set { _PARTYFULLDATETIME = value; }
        }
        #endregion

        #region Clear Data

        /// <summary>
        /// Initialize data.
        /// </summary>
        private void ClearData()
        {
            _DIVISIONID = 0;
            _DIVISIONNAME = "";
            _NDAPPROVE = "";
            _OPLOID = 0;
            _ORDERCODE = "";
            _ORDERDATE = new DateTime(1, 1, 1);
            _PARTYDATETIME = new DateTime(1, 1, 1);
            _PARTYTYPE = "";
            _PARTYTYPEID = 0;
            _PLACE = "";
            _STATUS = "";
            _STATUSNAME = "";
            _VISITORQTY = 0;
            _PARTYFULLDATETIME = new DateTime(1, 1, 1);
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
        /// Gets the select statement for V_ORDER_PARTY_SEARCH table.
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
        /// Returns an indication whether the record of V_ORDER_PARTY_SEARCH by specified condition is retrieved successfully.
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
                        if (!Convert.IsDBNull(zRdr["DIVISIONID"])) _DIVISIONID = Convert.ToDouble(zRdr["DIVISIONID"]);
                        if (!Convert.IsDBNull(zRdr["DIVISIONNAME"])) _DIVISIONNAME = zRdr["DIVISIONNAME"].ToString();
                        if (!Convert.IsDBNull(zRdr["NDAPPROVE"])) _NDAPPROVE = zRdr["NDAPPROVE"].ToString();
                        if (!Convert.IsDBNull(zRdr["OPLOID"])) _OPLOID = Convert.ToDouble(zRdr["OPLOID"]);
                        if (!Convert.IsDBNull(zRdr["ORDERCODE"])) _ORDERCODE = zRdr["ORDERCODE"].ToString();
                        if (!Convert.IsDBNull(zRdr["ORDERDATE"])) _ORDERDATE = Convert.ToDateTime(zRdr["ORDERDATE"]);
                        if (!Convert.IsDBNull(zRdr["PARTYDATETIME"])) _PARTYDATETIME = Convert.ToDateTime(zRdr["PARTYDATETIME"]);
                        if (!Convert.IsDBNull(zRdr["PARTYTYPE"])) _PARTYTYPE = zRdr["PARTYTYPE"].ToString();
                        if (!Convert.IsDBNull(zRdr["PARTYTYPEID"])) _PARTYTYPEID = Convert.ToDouble(zRdr["PARTYTYPEID"]);
                        if (!Convert.IsDBNull(zRdr["PLACE"])) _PLACE = zRdr["PLACE"].ToString();
                        if (!Convert.IsDBNull(zRdr["STATUS"])) _STATUS = zRdr["STATUS"].ToString();
                        if (!Convert.IsDBNull(zRdr["STATUSNAME"])) _STATUSNAME = zRdr["STATUSNAME"].ToString();
                        if (!Convert.IsDBNull(zRdr["VISITORQTY"])) _VISITORQTY = Convert.ToDouble(zRdr["VISITORQTY"]);
                        if (!Convert.IsDBNull(zRdr["PARTYFULLDATETIME"])) _PARTYFULLDATETIME = Convert.ToDateTime(zRdr["PARTYFULLDATETIME"]);
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