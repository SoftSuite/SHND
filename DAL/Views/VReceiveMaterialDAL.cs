using System;
using System.Data;
using System.Data.OracleClient;
using DB = SHND.DAL.Utilities.OracleDB;
using SHND.Data.Common.Utilities;

namespace SHND.DAL.Views
{
    /// <summary>
    /// Represents a transaction for V_RECEIVE_MATERIAL view.
    /// [Created by 127.0.0.1 on March,17 2009]
    /// </summary>
    public class VReceiveMaterialDAL
    {

        public VReceiveMaterialDAL()
        {
        }

        #region Constant

        /// <summary>V_RECEIVE_MATERIAL</summary>
        private const string viewName = "V_RECEIVE_MATERIAL";

        #endregion

        #region Private Variables

        string _error = "";
        string _information = "";
        bool _OnDB = false;
        string _CODE = "";
        DateTime _DUEDATE = new DateTime(1, 1, 1);
        DateTime _USEDATE = new DateTime(1, 1, 1);
        double _DUEQTY = 0;
        string _ISVAT = "";
        double _MATERIALCLASS = 0;
        string _MATERIALCLASSNAME = "";
        double _MATERIALMASTER = 0;
        string _MATERIALNAME = "";
        double _NETPRICE = 0;
        double _ORDERQTY = 0;
        double _PREPODUEDATE = 0;
        double _PRICE = 0;
        string _SAPCODE = "";
        string _SPEC = "";
        double _UNITLOID = 0;
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
        public DateTime DUEDATE
        {
            get { return _DUEDATE; }
            set { _DUEDATE = value; }
        }
        public DateTime USEDATE
        {
            get { return _USEDATE; }
            set { _USEDATE = value; }
        }
        public double DUEQTY
        {
            get { return _DUEQTY; }
            set { _DUEQTY = value; }
        }
        public string ISVAT
        {
            get { return _ISVAT; }
            set { _ISVAT = value; }
        }
        public double MATERIALCLASS
        {
            get { return _MATERIALCLASS; }
            set { _MATERIALCLASS = value; }
        }
        public string MATERIALCLASSNAME
        {
            get { return _MATERIALCLASSNAME; }
            set { _MATERIALCLASSNAME = value; }
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
        public double NETPRICE
        {
            get { return _NETPRICE; }
            set { _NETPRICE = value; }
        }
        public double ORDERQTY
        {
            get { return _ORDERQTY; }
            set { _ORDERQTY = value; }
        }
        public double PREPODUEDATE
        {
            get { return _PREPODUEDATE; }
            set { _PREPODUEDATE = value; }
        }
        public double PRICE
        {
            get { return _PRICE; }
            set { _PRICE = value; }
        }
        public string SAPCODE
        {
            get { return _SAPCODE; }
            set { _SAPCODE = value; }
        }
        public string SPEC
        {
            get { return _SPEC; }
            set { _SPEC = value; }
        }
        public double UNITLOID
        {
            get { return _UNITLOID; }
            set { _UNITLOID = value; }
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
            _DUEDATE = new DateTime(1, 1, 1);
            _DUEQTY = 0;
            _ISVAT = "";
            _MATERIALCLASS = 0;
            _MATERIALCLASSNAME = "";
            _MATERIALMASTER = 0;
            _MATERIALNAME = "";
            _NETPRICE = 0;
            _ORDERQTY = 0;
            _PREPODUEDATE = 0;
            _PRICE = 0;
            _SAPCODE = "";
            _SPEC = "";
            _UNITLOID = 0;
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

        public DataTable GetDataListByConditions(DateTime cDuedate, double cCLASS, string cMATERIALNAME, string exceptMaterialMasterList, string orderBy, OracleTransaction trans)
        {
            string whText = "";
            if (cDuedate.Year != 1) whText += (whText == "" ? "" : "AND ") + "DUEDATE = " + DB.SetDateTime(cDuedate) + " ";
            if (cCLASS != 0) whText += (whText == "" ? "" : "AND ") + "MATERIALCLASS = " + DB.SetDouble(cCLASS) + " ";
            if (cMATERIALNAME.Trim() != "") whText += (whText == "" ? "" : "AND ") + "UPPER(MATERIALNAME) LIKE " + DB.SetString("%" + cMATERIALNAME.Trim().ToUpper() + "%") + " ";
            if (exceptMaterialMasterList != "") whText += (whText.Trim() == "" ? "" : " AND ") + "CODE NOT IN (" + exceptMaterialMasterList + ") ";
            return GetDataList(whText, orderBy, trans);
        }

        #endregion

        #region SQL Statements

        /// <summary>
        /// Gets the select statement for V_RECEIVE_MATERIAL table.
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
        /// Returns an indication whether the record of V_RECEIVE_MATERIAL by specified condition is retrieved successfully.
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
                        if (!Convert.IsDBNull(zRdr["DUEDATE"])) _DUEDATE = Convert.ToDateTime(zRdr["DUEDATE"]);
                        if (!Convert.IsDBNull(zRdr["USEDATE"])) _USEDATE = Convert.ToDateTime(zRdr["USEDATE"]);
                        if (!Convert.IsDBNull(zRdr["DUEQTY"])) _DUEQTY = Convert.ToDouble(zRdr["DUEQTY"]);
                        if (!Convert.IsDBNull(zRdr["ISVAT"])) _ISVAT = zRdr["ISVAT"].ToString();
                        if (!Convert.IsDBNull(zRdr["MATERIALCLASS"])) _MATERIALCLASS = Convert.ToDouble(zRdr["MATERIALCLASS"]);
                        if (!Convert.IsDBNull(zRdr["MATERIALCLASSNAME"])) _MATERIALCLASSNAME = zRdr["MATERIALCLASSNAME"].ToString();
                        if (!Convert.IsDBNull(zRdr["MATERIALMASTER"])) _MATERIALMASTER = Convert.ToDouble(zRdr["MATERIALMASTER"]);
                        if (!Convert.IsDBNull(zRdr["MATERIALNAME"])) _MATERIALNAME = zRdr["MATERIALNAME"].ToString();
                        if (!Convert.IsDBNull(zRdr["NETPRICE"])) _NETPRICE = Convert.ToDouble(zRdr["NETPRICE"]);
                        if (!Convert.IsDBNull(zRdr["ORDERQTY"])) _ORDERQTY = Convert.ToDouble(zRdr["ORDERQTY"]);
                        if (!Convert.IsDBNull(zRdr["PREPODUEDATE"])) _PREPODUEDATE = Convert.ToDouble(zRdr["PREPODUEDATE"]);
                        if (!Convert.IsDBNull(zRdr["PRICE"])) _PRICE = Convert.ToDouble(zRdr["PRICE"]);
                        if (!Convert.IsDBNull(zRdr["SAPCODE"])) _SAPCODE = zRdr["SAPCODE"].ToString();
                        if (!Convert.IsDBNull(zRdr["SPEC"])) _SPEC = zRdr["SPEC"].ToString();
                        if (!Convert.IsDBNull(zRdr["UNITLOID"])) _UNITLOID = Convert.ToDouble(zRdr["UNITLOID"]);
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

    }
}