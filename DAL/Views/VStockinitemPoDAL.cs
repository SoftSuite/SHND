using System;
using System.Data;
using System.Data.OracleClient;
using DB = SHND.DAL.Utilities.OracleDB;
using SHND.Data.Common.Utilities;

namespace SHND.DAL.Views
{
    /// <summary>
    /// Represents a transaction for V_STOCKINITEM_PO view.
    /// [Created by 127.0.0.1 on Febuary,19 2009]
    /// </summary>
    public class VStockinitemPoDAL
    {

        public VStockinitemPoDAL()
        {
        }

        #region Constant

        /// <summary>V_STOCKINITEM_PO</summary>
        private const string viewName = "V_STOCKINITEM_PO";

        #endregion

        #region Private Variables

        string _error = "";
        string _information = "";
        bool _OnDB = false;
        double _GUARANTEE = 0;
        double _LOID = 0;
        string _LOTNO = "";
        string _MATERIALCODE = "";
        double _MATERIALMASTER = 0;
        string _MATERIALNAME = "";
        double _PLANQTY = 0;
        double _PRICE = 0;
        double _QTY = 0;
        double _REMAINQTY = 0;
        string _SAPPOCODE = "";
        DateTime _SAPPODATE = new DateTime(1, 1, 1);
        double _SAPWAREHOUSE = 0;
        double _STOCKIN = 0;
        double _UNIT = 0;
        string _UNITNAME = "";
        string _WARECODE = "";
        string _WARENAME = "";

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
        public double GUARANTEE
        {
            get { return _GUARANTEE; }
            set { _GUARANTEE = value; }
        }
        public double LOID
        {
            get { return _LOID; }
            set { _LOID = value; }
        }
        public string LOTNO
        {
            get { return _LOTNO; }
            set { _LOTNO = value; }
        }
        public string MATERIALCODE
        {
            get { return _MATERIALCODE; }
            set { _MATERIALCODE = value; }
        }
        public double MATERIALMASTER
        {
            get { return _MATERIALMASTER; }
            set { _MATERIALMASTER = value; }
        }
        public string MATERIALNAME
        {
            get { return _MATERIALNAME; }
            set { _MATERIALNAME = value; }
        }
        public double PLANQTY
        {
            get { return _PLANQTY; }
            set { _PLANQTY = value; }
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
        public double REMAINQTY
        {
            get { return _REMAINQTY; }
            set { _REMAINQTY = value; }
        }
        public string SAPPOCODE
        {
            get { return _SAPPOCODE; }
            set { _SAPPOCODE = value; }
        }
        public DateTime SAPPODATE
        {
            get { return _SAPPODATE; }
            set { _SAPPODATE = value; }
        }
        public double SAPWAREHOUSE
        {
            get { return _SAPWAREHOUSE; }
            set { _SAPWAREHOUSE = value; }
        }
        public double STOCKIN
        {
            get { return _STOCKIN; }
            set { _STOCKIN = value; }
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
        public string WARECODE
        {
            get { return _WARECODE; }
            set { _WARECODE = value; }
        }
        public string WARENAME
        {
            get { return _WARENAME; }
            set { _WARENAME = value; }
        }

        #endregion

        #region Clear Data

        /// <summary>
        /// Initialize data.
        /// </summary>
        private void ClearData()
        {
            _GUARANTEE = 0;
            _LOID = 0;
            _LOTNO = "";
            _MATERIALCODE = "";
            _MATERIALMASTER = 0;
            _MATERIALNAME = "";
            _PLANQTY = 0;
            _PRICE = 0;
            _QTY = 0;
            _REMAINQTY = 0;
            _SAPPOCODE = "";
            _SAPPODATE = new DateTime(1, 1, 1);
            _SAPWAREHOUSE = 0;
            _STOCKIN = 0;
            _UNIT = 0;
            _UNITNAME = "";
            _WARECODE = "";
            _WARENAME = "";
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
        /// Gets the select statement for V_STOCKINITEM_PO table.
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
        /// Returns an indication whether the record of V_STOCKINITEM_PO by specified condition is retrieved successfully.
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
                        if (!Convert.IsDBNull(zRdr["GUARANTEE"])) _GUARANTEE = Convert.ToDouble(zRdr["GUARANTEE"]);
                        if (!Convert.IsDBNull(zRdr["LOID"])) _LOID = Convert.ToDouble(zRdr["LOID"]);
                        if (!Convert.IsDBNull(zRdr["LOTNO"])) _LOTNO = zRdr["LOTNO"].ToString();
                        if (!Convert.IsDBNull(zRdr["MATERIALCODE"])) _MATERIALCODE = zRdr["MATERIALCODE"].ToString();
                        if (!Convert.IsDBNull(zRdr["MATERIALMASTER"])) _MATERIALMASTER = Convert.ToDouble(zRdr["MATERIALMASTER"]);
                        if (!Convert.IsDBNull(zRdr["MATERIALNAME"])) _MATERIALNAME = zRdr["MATERIALNAME"].ToString();
                        if (!Convert.IsDBNull(zRdr["PLANQTY"])) _PLANQTY = Convert.ToDouble(zRdr["PLANQTY"]);
                        if (!Convert.IsDBNull(zRdr["PRICE"])) _PRICE = Convert.ToDouble(zRdr["PRICE"]);
                        if (!Convert.IsDBNull(zRdr["QTY"])) _QTY = Convert.ToDouble(zRdr["QTY"]);
                        if (!Convert.IsDBNull(zRdr["REMAINQTY"])) _REMAINQTY = Convert.ToDouble(zRdr["REMAINQTY"]);
                        if (!Convert.IsDBNull(zRdr["SAPPOCODE"])) _SAPPOCODE = zRdr["SAPPOCODE"].ToString();
                        if (!Convert.IsDBNull(zRdr["SAPPODATE"])) _SAPPODATE = Convert.ToDateTime(zRdr["SAPPODATE"]);
                        if (!Convert.IsDBNull(zRdr["SAPWAREHOUSE"])) _SAPWAREHOUSE = Convert.ToDouble(zRdr["SAPWAREHOUSE"]);
                        if (!Convert.IsDBNull(zRdr["STOCKIN"])) _STOCKIN = Convert.ToDouble(zRdr["STOCKIN"]);
                        if (!Convert.IsDBNull(zRdr["UNIT"])) _UNIT = Convert.ToDouble(zRdr["UNIT"]);
                        if (!Convert.IsDBNull(zRdr["UNITNAME"])) _UNITNAME = zRdr["UNITNAME"].ToString();
                        if (!Convert.IsDBNull(zRdr["WARECODE"])) _WARECODE = zRdr["WARECODE"].ToString();
                        if (!Convert.IsDBNull(zRdr["WARENAME"])) _WARENAME = zRdr["WARENAME"].ToString();
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

        public DataTable GetDataListBySTOCKIN(double cLOID, string orderBy, OracleTransaction trans)
        {
            return GetDataList("STOCKIN = " + DB.SetDouble(cLOID) + " ", orderBy, trans);
        }
        
    }
}