using System;
using System.Data;
using System.Data.OracleClient;
using DB = SHND.DAL.Utilities.OracleDB;
using SHND.Data.Common.Utilities;
using SHND.Data.Views;
using SHND.Data.Search;

namespace SHND.DAL.Views
{
    /// <summary>
    /// Represents a transaction for V_STOCKOUT_RETURN_POPUP view.
    /// [Created by 127.0.0.1 on March,2 2009]
    /// </summary>
    public class VStockoutReturenPopUpDAL
    {

        public VStockoutReturenPopUpDAL()
        {
        }

        #region Constant

        /// <summary>V_STOCKOUT_RETURN_POPUP</summary>
        private const string viewName = "V_STOCKOUT_RETURN_POPUP";

        #endregion

        #region Private Variables

        string _error = "";
        string _information = "";
        bool _OnDB = false;
        double _CLASSLOID = 0;
        string _CLASSNAME = "";
        string _CODE = "";
        double _GROUPLOID = 0;
        string _GROUPNAME = "";
        double _LOID = 0;
        string _MASTERTYPE = "";
        string _MASTERTYPENAME = "";
        string _MATERIALCODE = "";
        double _MATERIALMASTER = 0;
        string _MATERIALNAME = "";
        double _PLANORDER = 0;
        double _PLANQTY = 0;
        double _PLANREMAIN = 0;
        double _PRICE = 0;
        string _SAPCODE = "";
        string _SPEC = "";
        double _STOCKINQTY = 0;
        double _SUPPLIER = 0;
        string _SUPPLIERNAME = "";
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
        public double CLASSLOID
        {
            get { return _CLASSLOID; }
            set { _CLASSLOID = value; }
        }
        public string CLASSNAME
        {
            get { return _CLASSNAME; }
            set { _CLASSNAME = value; }
        }
        public string CODE
        {
            get { return _CODE; }
            set { _CODE = value; }
        }
        public double GROUPLOID
        {
            get { return _GROUPLOID; }
            set { _GROUPLOID = value; }
        }
        public string GROUPNAME
        {
            get { return _GROUPNAME; }
            set { _GROUPNAME = value; }
        }
        public double LOID
        {
            get { return _LOID; }
            set { _LOID = value; }
        }
        public string MASTERTYPE
        {
            get { return _MASTERTYPE; }
            set { _MASTERTYPE = value; }
        }
        public string MASTERTYPENAME
        {
            get { return _MASTERTYPENAME; }
            set { _MASTERTYPENAME = value; }
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
        public double PLANORDER
        {
            get { return _PLANORDER; }
            set { _PLANORDER = value; }
        }
        public double PLANQTY
        {
            get { return _PLANQTY; }
            set { _PLANQTY = value; }
        }
        public double PLANREMAIN
        {
            get { return _PLANREMAIN; }
            set { _PLANREMAIN = value; }
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
        public double STOCKINQTY
        {
            get { return _STOCKINQTY; }
            set { _STOCKINQTY = value; }
        }
        public double SUPPLIER
        {
            get { return _SUPPLIER; }
            set { _SUPPLIER = value; }
        }
        public string SUPPLIERNAME
        {
            get { return _SUPPLIERNAME; }
            set { _SUPPLIERNAME = value; }
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
            _CLASSLOID = 0;
            _CLASSNAME = "";
            _CODE = "";
            _GROUPLOID = 0;
            _GROUPNAME = "";
            _LOID = 0;
            _MASTERTYPE = "";
            _MASTERTYPENAME = "";
            _MATERIALCODE = "";
            _MATERIALMASTER = 0;
            _MATERIALNAME = "";
            _PLANORDER = 0;
            _PLANQTY = 0;
            _PLANREMAIN = 0;
            _PRICE = 0;
            _SAPCODE = "";
            _SPEC = "";
            _STOCKINQTY = 0;
            _SUPPLIER = 0;
            _SUPPLIERNAME = "";
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
        /// Gets the select statement for V_STOCKOUT_RETURN_POPUP table.
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
        /// Returns an indication whether the record of V_STOCKOUT_RETURN_POPUP by specified condition is retrieved successfully.
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
                        if (!Convert.IsDBNull(zRdr["CLASSLOID"])) _CLASSLOID = Convert.ToDouble(zRdr["CLASSLOID"]);
                        if (!Convert.IsDBNull(zRdr["CLASSNAME"])) _CLASSNAME = zRdr["CLASSNAME"].ToString();
                        if (!Convert.IsDBNull(zRdr["CODE"])) _CODE = zRdr["CODE"].ToString();
                        if (!Convert.IsDBNull(zRdr["GROUPLOID"])) _GROUPLOID = Convert.ToDouble(zRdr["GROUPLOID"]);
                        if (!Convert.IsDBNull(zRdr["GROUPNAME"])) _GROUPNAME = zRdr["GROUPNAME"].ToString();
                        if (!Convert.IsDBNull(zRdr["LOID"])) _LOID = Convert.ToDouble(zRdr["LOID"]);
                        if (!Convert.IsDBNull(zRdr["MASTERTYPE"])) _MASTERTYPE = zRdr["MASTERTYPE"].ToString();
                        if (!Convert.IsDBNull(zRdr["MASTERTYPENAME"])) _MASTERTYPENAME = zRdr["MASTERTYPENAME"].ToString();
                        if (!Convert.IsDBNull(zRdr["MATERIALCODE"])) _MATERIALCODE = zRdr["MATERIALCODE"].ToString();
                        if (!Convert.IsDBNull(zRdr["MATERIALMASTER"])) _MATERIALMASTER = Convert.ToDouble(zRdr["MATERIALMASTER"]);
                        if (!Convert.IsDBNull(zRdr["MATERIALNAME"])) _MATERIALNAME = zRdr["MATERIALNAME"].ToString();
                        if (!Convert.IsDBNull(zRdr["PLANORDER"])) _PLANORDER = Convert.ToDouble(zRdr["PLANORDER"]);
                        if (!Convert.IsDBNull(zRdr["PLANQTY"])) _PLANQTY = Convert.ToDouble(zRdr["PLANQTY"]);
                        if (!Convert.IsDBNull(zRdr["PLANREMAIN"])) _PLANREMAIN = Convert.ToDouble(zRdr["PLANREMAIN"]);
                        if (!Convert.IsDBNull(zRdr["PRICE"])) _PRICE = Convert.ToDouble(zRdr["PRICE"]);
                        if (!Convert.IsDBNull(zRdr["SAPCODE"])) _SAPCODE = zRdr["SAPCODE"].ToString();
                        if (!Convert.IsDBNull(zRdr["SPEC"])) _SPEC = zRdr["SPEC"].ToString();
                        if (!Convert.IsDBNull(zRdr["STOCKINQTY"])) _STOCKINQTY = Convert.ToDouble(zRdr["STOCKINQTY"]);
                        if (!Convert.IsDBNull(zRdr["SUPPLIER"])) _SUPPLIER = Convert.ToDouble(zRdr["SUPPLIER"]);
                        if (!Convert.IsDBNull(zRdr["SUPPLIERNAME"])) _SUPPLIERNAME = zRdr["SUPPLIERNAME"].ToString();
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

        #region My work Nang

        public DataTable GetDataListByCondition(VStockoutReturenPopUpData condition, string masterTypeList, string exceptKeyList, string orderBy, OracleTransaction trans)
        {
            string whStr = "";
            if (condition.GROUPLOID != 0) whStr += (whStr == "" ? "" : "AND ") + "GROUPLOID = " + DB.SetDouble(condition.GROUPLOID) + " ";
            if (condition.CLASSLOID != 0) whStr += (whStr == "" ? "" : "AND ") + "CLASSLOID = " + DB.SetDouble(condition.CLASSLOID) + " ";
            if (condition.SUPPLIER != 0) whStr += (whStr == "" ? "" : "AND ") + "SUPPLIER = " + DB.SetDouble(condition.SUPPLIER) + " ";
            if (condition.WAREHOUSE != 0) whStr += (whStr == "" ? "" : "AND ") + "WAREHOUSE = " + DB.SetDouble(condition.WAREHOUSE) + " ";
            if (condition.PLANORDER != 0) whStr += (whStr == "" ? "" : "AND ") + "PLANORDER = " + DB.SetDouble(condition.PLANORDER) + " ";
            if (condition.MATERIALNAME.Trim() != "") whStr += (whStr == "" ? "" : "AND ") + "UPPER(MATERIALNAME) LIKE " + DB.SetString("%" + condition.MATERIALNAME.ToUpper() + "%") + " ";
            if (exceptKeyList != "") whStr += (whStr.Trim() == "" ? "" : " AND ") + "LOID NOT IN (" + exceptKeyList + ") ";
            return GetDataList(whStr, orderBy, trans);
        }

        #endregion

        #endregion

    }
}