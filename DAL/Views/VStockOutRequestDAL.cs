using System;
using System.Data;
using System.Data.OracleClient;
using DB = SHND.DAL.Utilities.OracleDB;
using SHND.Data.Common.Utilities;

namespace SHND.DAL.Views
{
    /// <summary>
    /// Represents a transaction for V_STOCKOUTITEM_REQUEST view.
    /// [Created by 127.0.0.1 on Febuary,23 2009]
    /// </summary>
    public class VStockOutRequestDAL
    {

        public VStockOutRequestDAL()
        {
        }

        #region Constant

        /// <summary>V_STOCKOUTITEM_REQUEST</summary>
        private const string viewName = "V_STOCKOUTITEM_REQUEST";

        #endregion

        #region Private Variables

        string _error = "";
        string _information = "";
        bool _OnDB = false;
        string _CODE = "";
        double _FORMULAQTY = 0;
        string _ISMENU = "";
        double _LASTQTY = 0;
        double _LOID = 0;
        string _MATERIALNAME = "";
        double _PREQTY = 0;
        double _PRICE = 0;
        double _QTY = 0;
        double _REMAIN = 0;
        double _REQQTY = 0;
        string _STATUS = "";
        string _STATUSNAME = "";
        double _STOCKOUT = 0;
        double _TOTAL = 0;
        double _UNIT = 0;
        string _UNITNAME = "";

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
        public double FORMULAQTY
        {
            get { return _FORMULAQTY; }
            set { _FORMULAQTY = value; }
        }
        public string ISMENU
        {
            get { return _ISMENU; }
            set { _ISMENU = value; }
        }
        public double LASTQTY
        {
            get { return _LASTQTY; }
            set { _LASTQTY = value; }
        }
        public double LOID
        {
            get { return _LOID; }
            set { _LOID = value; }
        }
        public string MATERIALNAME
        {
            get { return _MATERIALNAME; }
            set { _MATERIALNAME = value; }
        }
        public double PREQTY
        {
            get { return _PREQTY; }
            set { _PREQTY = value; }
        }
        public double PRICE
        {
            get { return _PRICE; }
            set { _PRICE = value; }
        }
        public double QTY
        {
            get { return _QTY; }
            set { _QTY = value; }
        }
        public double REMAIN
        {
            get { return _REMAIN; }
            set { _REMAIN = value; }
        }
        public double REQQTY
        {
            get { return _REQQTY; }
            set { _REQQTY = value; }
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
        public double STOCKOUT
        {
            get { return _STOCKOUT; }
            set { _STOCKOUT = value; }
        }
        public double TOTAL
        {
            get { return _TOTAL; }
            set { _TOTAL = value; }
        }
        public double UNIT
        {
            get { return _UNIT; }
            set { _UNIT = value; }
        }
        public string UNITNAME
        {
            get { return _UNITNAME; }
            set { _UNITNAME = value; }
        }

        #endregion

        #region Clear Data

        /// <summary>
        /// Initialize data.
        /// </summary>
        private void ClearData()
        {
            _CODE = "";
            _FORMULAQTY = 0;
            _ISMENU = "";
            _LASTQTY = 0;
            _LOID = 0;
            _MATERIALNAME = "";
            _PREQTY = 0;
            _PRICE = 0;
            _QTY = 0;
            _REMAIN = 0;
            _REQQTY = 0;
            _STATUS = "";
            _STATUSNAME = "";
            _STOCKOUT = 0;
            _TOTAL = 0;
            _UNIT = 0;
            _UNITNAME = "";
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
        /// Gets the select statement for V_STOCKOUTITEM_REQUEST table.
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
        /// Returns an indication whether the record of V_STOCKOUTITEM_REQUEST by specified condition is retrieved successfully.
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
                        if (!Convert.IsDBNull(zRdr["FORMULAQTY"])) _FORMULAQTY = Convert.ToDouble(zRdr["FORMULAQTY"]);
                        if (!Convert.IsDBNull(zRdr["ISMENU"])) _ISMENU = zRdr["ISMENU"].ToString();
                        if (!Convert.IsDBNull(zRdr["LASTQTY"])) _LASTQTY = Convert.ToDouble(zRdr["LASTQTY"]);
                        if (!Convert.IsDBNull(zRdr["LOID"])) _LOID = Convert.ToDouble(zRdr["LOID"]);
                        if (!Convert.IsDBNull(zRdr["MATERIALNAME"])) _MATERIALNAME = zRdr["MATERIALNAME"].ToString();
                        if (!Convert.IsDBNull(zRdr["PREQTY"])) _PREQTY = Convert.ToDouble(zRdr["PREQTY"]);
                        if (!Convert.IsDBNull(zRdr["PRICE"])) _PRICE = Convert.ToDouble(zRdr["PRICE"]);
                        if (!Convert.IsDBNull(zRdr["QTY"])) _QTY = Convert.ToDouble(zRdr["QTY"]);
                        if (!Convert.IsDBNull(zRdr["REMAIN"])) _REMAIN = Convert.ToDouble(zRdr["REMAIN"]);
                        if (!Convert.IsDBNull(zRdr["REQQTY"])) _REQQTY = Convert.ToDouble(zRdr["REQQTY"]);
                        if (!Convert.IsDBNull(zRdr["STATUS"])) _STATUS = zRdr["STATUS"].ToString();
                        if (!Convert.IsDBNull(zRdr["STATUSNAME"])) _STATUSNAME = zRdr["STATUSNAME"].ToString();
                        if (!Convert.IsDBNull(zRdr["STOCKOUT"])) _STOCKOUT = Convert.ToDouble(zRdr["STOCKOUT"]);
                        if (!Convert.IsDBNull(zRdr["TOTAL"])) _TOTAL = Convert.ToDouble(zRdr["TOTAL"]);
                        if (!Convert.IsDBNull(zRdr["UNIT"])) _UNIT = Convert.ToDouble(zRdr["UNIT"]);
                        if (!Convert.IsDBNull(zRdr["UNITNAME"])) _UNITNAME = zRdr["UNITNAME"].ToString();
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

        public DataTable GetDataListByStockOut(double cSTOCKOUT, string orderBy, OracleTransaction trans)
        {
            return GetDataList("STOCKOUT = " + DB.SetDouble(cSTOCKOUT), orderBy, trans);
        }

    }
}