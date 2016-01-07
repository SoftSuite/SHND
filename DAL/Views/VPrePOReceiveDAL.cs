using System;
using System.Data;
using System.Data.OracleClient;
using DB = SHND.DAL.Utilities.OracleDB;
using SHND.Data.Common.Utilities;

namespace SHND.DAL.Views
{
    /// <summary>
    /// Represents a transaction for V_PREPO_RECEIVE view.
    /// [Created by 127.0.0.1 on April,2 2009]
    /// </summary>
    public class VPrePOReceiveDAL
    {

        public VPrePOReceiveDAL()
        {
        }

        #region Constant

        /// <summary>V_PREPO_RECEIVE</summary>
        private const string viewName = "V_PREPO_RECEIVE";

        #endregion

        #region Private Variables

        string _error = "";
        string _information = "";
        bool _OnDB = false;
        string _ISVAT = "";
        double _MATERIALMASTER = 0;
        string _MATERIALNAME = "";
        double _PLANREMAINQTY = 0;
        double _PREPO = 0;
        double _PRICE = 0;
        double _RECEIVEQTY = 0;
        string _SPEC = "";
        double _UNIT = 0;
        string _UNITNAME = "";
        double _USEDQTY = 0;

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
        public string ISVAT
        {
            get { return _ISVAT; }
            set { _ISVAT = value; }
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
        public double PLANREMAINQTY
        {
            get { return _PLANREMAINQTY; }
            set { _PLANREMAINQTY = value; }
        }
        public double PREPO
        {
            get { return _PREPO; }
            set { _PREPO = value; }
        }
        public double PRICE
        {
            get { return _PRICE; }
            set { _PRICE = value; }
        }
        public double RECEIVEQTY
        {
            get { return _RECEIVEQTY; }
            set { _RECEIVEQTY = value; }
        }
        public string SPEC
        {
            get { return _SPEC; }
            set { _SPEC = value; }
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
        public double USEDQTY
        {
            get { return _USEDQTY; }
            set { _USEDQTY = value; }
        }

        #endregion

        #region Clear Data

        /// <summary>
        /// Initialize data.
        /// </summary>
        private void ClearData()
        {
            _ISVAT = "";
            _MATERIALMASTER = 0;
            _MATERIALNAME = "";
            _PLANREMAINQTY = 0;
            _PREPO = 0;
            _PRICE = 0;
            _RECEIVEQTY = 0;
            _SPEC = "";
            _UNIT = 0;
            _UNITNAME = "";
            _USEDQTY = 0;
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

        public DataTable GetDataListByPrePO(double cPrePO, string cIsVat, string orderBy, OracleTransaction trans)
        {
            return GetDataList("PrePO = " + DB.SetDouble(cPrePO) + " AND ISVAT = " + DB.SetString(cIsVat), orderBy, trans);
        }

        public DataTable GetDataListByPrePO(double cPrePO, string orderBy, OracleTransaction trans)
        {
            return GetDataList("PrePO = " + DB.SetDouble(cPrePO) , orderBy, trans);
        }

        #endregion

        #region SQL Statements

        /// <summary>
        /// Gets the select statement for V_PREPO_RECEIVE table.
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
        /// Returns an indication whether the record of V_PREPO_RECEIVE by specified condition is retrieved successfully.
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
                        if (!Convert.IsDBNull(zRdr["ISVAT"])) _ISVAT = zRdr["ISVAT"].ToString();
                        if (!Convert.IsDBNull(zRdr["MATERIALMASTER"])) _MATERIALMASTER = Convert.ToDouble(zRdr["MATERIALMASTER"]);
                        if (!Convert.IsDBNull(zRdr["MATERIALNAME"])) _MATERIALNAME = zRdr["MATERIALNAME"].ToString();
                        if (!Convert.IsDBNull(zRdr["PLANREMAINQTY"])) _PLANREMAINQTY = Convert.ToDouble(zRdr["PLANREMAINQTY"]);
                        if (!Convert.IsDBNull(zRdr["PREPO"])) _PREPO = Convert.ToDouble(zRdr["PREPO"]);
                        if (!Convert.IsDBNull(zRdr["PRICE"])) _PRICE = Convert.ToDouble(zRdr["PRICE"]);
                        if (!Convert.IsDBNull(zRdr["RECEIVEQTY"])) _RECEIVEQTY = Convert.ToDouble(zRdr["RECEIVEQTY"]);
                        if (!Convert.IsDBNull(zRdr["SPEC"])) _SPEC = zRdr["SPEC"].ToString();
                        if (!Convert.IsDBNull(zRdr["UNIT"])) _UNIT = Convert.ToDouble(zRdr["UNIT"]);
                        if (!Convert.IsDBNull(zRdr["UNITNAME"])) _UNITNAME = zRdr["UNITNAME"].ToString();
                        if (!Convert.IsDBNull(zRdr["USEDQTY"])) _USEDQTY = Convert.ToDouble(zRdr["USEDQTY"]);
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