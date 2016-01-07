using System;
using System.Data;
using System.Data.OracleClient;
using DB = SHND.DAL.Utilities.OracleDB;
using SHND.Data.Common.Utilities;

namespace SHND.DAL.Views
{
    /// <summary>
    /// Represents a transaction for V_ORDERPARTYITEM view.
    /// [Created by 127.0.0.1 on Febuary,6 2009]
    /// </summary>
    public class VOrderPartyItemDAL
    {

        public VOrderPartyItemDAL()
        {
        }

        #region Constant

        /// <summary>V_ORDERPARTYITEM</summary>
        private const string viewName = "V_ORDERPARTYITEM";

        #endregion

        #region Private Variables

        string _error = "";
        string _information = "";
        bool _OnDB = false;
        double _FOODCOOKTYPE = 0;
        string _FOODCOOKTYPENAME = "";
        double _FOODTYPE = 0;
        string _FOODTYPENAME = "";
        double _FORMULASET = 0;
        string _FORMULASETNAME = "";
        double _LOID = 0;
        double _ORDERPARTY = 0;
        double _SERVICEQTY = 0;
        double _VISITORQTY = 0;

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
        public double FOODCOOKTYPE
        {
            get { return _FOODCOOKTYPE; }
            set { _FOODCOOKTYPE = value; }
        }
        public string FOODCOOKTYPENAME
        {
            get { return _FOODCOOKTYPENAME; }
            set { _FOODCOOKTYPENAME = value; }
        }
        public double FOODTYPE
        {
            get { return _FOODTYPE; }
            set { _FOODTYPE = value; }
        }
        public string FOODTYPENAME
        {
            get { return _FOODTYPENAME; }
            set { _FOODTYPENAME = value; }
        }
        public double FORMULASET
        {
            get { return _FORMULASET; }
            set { _FORMULASET = value; }
        }
        public string FORMULASETNAME
        {
            get { return _FORMULASETNAME; }
            set { _FORMULASETNAME = value; }
        }
        public double LOID
        {
            get { return _LOID; }
            set { _LOID = value; }
        }
        public double ORDERPARTY
        {
            get { return _ORDERPARTY; }
            set { _ORDERPARTY = value; }
        }
        public double SERVICEQTY
        {
            get { return _SERVICEQTY; }
            set { _SERVICEQTY = value; }
        }
        public double VISITORQTY
        {
            get { return _VISITORQTY; }
            set { _VISITORQTY = value; }
        }

        #endregion

        #region Clear Data

        /// <summary>
        /// Initialize data.
        /// </summary>
        private void ClearData()
        {
            _FOODCOOKTYPE = 0;
            _FOODCOOKTYPENAME = "";
            _FOODTYPE = 0;
            _FOODTYPENAME = "";
            _FORMULASET = 0;
            _FORMULASETNAME = "";
            _LOID = 0;
            _ORDERPARTY = 0;
            _SERVICEQTY = 0;
            _VISITORQTY = 0;
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

        public DataTable GetDataListByOrderParty(double cORDERPARTY, string orderBy, OracleTransaction trans)
        {
            return GetDataList("ORDERPARTY = " + DB.SetDouble(cORDERPARTY), orderBy, trans);
        }

        #endregion

        #region SQL Statements

        /// <summary>
        /// Gets the select statement for V_ORDERPARTYITEM table.
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
        /// Returns an indication whether the record of V_ORDERPARTYITEM by specified condition is retrieved successfully.
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
                        if (!Convert.IsDBNull(zRdr["FOODCOOKTYPE"])) _FOODCOOKTYPE = Convert.ToDouble(zRdr["FOODCOOKTYPE"]);
                        if (!Convert.IsDBNull(zRdr["FOODCOOKTYPENAME"])) _FOODCOOKTYPENAME = zRdr["FOODCOOKTYPENAME"].ToString();
                        if (!Convert.IsDBNull(zRdr["FOODTYPE"])) _FOODTYPE = Convert.ToDouble(zRdr["FOODTYPE"]);
                        if (!Convert.IsDBNull(zRdr["FOODTYPENAME"])) _FOODTYPENAME = zRdr["FOODTYPENAME"].ToString();
                        if (!Convert.IsDBNull(zRdr["FORMULASET"])) _FORMULASET = Convert.ToDouble(zRdr["FORMULASET"]);
                        if (!Convert.IsDBNull(zRdr["FORMULASETNAME"])) _FORMULASETNAME = zRdr["FORMULASETNAME"].ToString();
                        if (!Convert.IsDBNull(zRdr["LOID"])) _LOID = Convert.ToDouble(zRdr["LOID"]);
                        if (!Convert.IsDBNull(zRdr["ORDERPARTY"])) _ORDERPARTY = Convert.ToDouble(zRdr["ORDERPARTY"]);
                        if (!Convert.IsDBNull(zRdr["SERVICEQTY"])) _SERVICEQTY = Convert.ToDouble(zRdr["SERVICEQTY"]);
                        if (!Convert.IsDBNull(zRdr["VISITORQTY"])) _VISITORQTY = Convert.ToDouble(zRdr["VISITORQTY"]);
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