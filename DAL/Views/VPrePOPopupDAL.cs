using System;
using System.Data;
using System.Data.OracleClient;
using DB = SHND.DAL.Utilities.OracleDB;
using SHND.Data.Common.Utilities;

namespace SHND.DAL.Views
{
    /// <summary>
    /// Represents a transaction for V_PREPO_POPUP view.
    /// [Created by 127.0.0.1 on April,2 2009]
    /// </summary>
    public class VPrePOPopupDAL
    {

        public VPrePOPopupDAL()
        {
        }

        #region Constant

        /// <summary>V_PREPO_POPUP</summary>
        private const string viewName = "V_PREPO_POPUP";

        #endregion

        #region Private Variables

        string _error = "";
        string _information = "";
        bool _OnDB = false;
        DateTime _BPODATE = new DateTime(1, 1, 1);
        string _CLASSNAME = "";
        string _CODE = "";
        double _LOID = 0;
        double _MATERIALCLASS = 0;
        double _SUPPLIER = 0;
        string _SUPPLIERCODE = "";
        string _SUPPLIERNAME = "";
        DateTime _USEDATE = new DateTime(1, 1, 1);

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
        public DateTime BPODATE
        {
            get { return _BPODATE; }
            set { _BPODATE = value; }
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
        public double LOID
        {
            get { return _LOID; }
            set { _LOID = value; }
        }
        public double MATERIALCLASS
        {
            get { return _MATERIALCLASS; }
            set { _MATERIALCLASS = value; }
        }
        public double SUPPLIER
        {
            get { return _SUPPLIER; }
            set { _SUPPLIER = value; }
        }
        public string SUPPLIERCODE
        {
            get { return _SUPPLIERCODE; }
            set { _SUPPLIERCODE = value; }
        }
        public string SUPPLIERNAME
        {
            get { return _SUPPLIERNAME; }
            set { _SUPPLIERNAME = value; }
        }
        public DateTime USEDATE
        {
            get { return _USEDATE; }
            set { _USEDATE = value; }
        }

        #endregion

        #region Clear Data

        /// <summary>
        /// Initialize data.
        /// </summary>
        private void ClearData()
        {
            _BPODATE = new DateTime(1, 1, 1);
            _CLASSNAME = "";
            _CODE = "";
            _LOID = 0;
            _MATERIALCLASS = 0;
            _SUPPLIER = 0;
            _SUPPLIERCODE = "";
            _SUPPLIERNAME = "";
            _USEDATE = new DateTime(1, 1, 1);
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

        public DataTable GetDataListByConditions(string codeFrom, string codeTo, DateTime dateFrom, DateTime dateTo, DateTime UsedateFrom, DateTime usedateTo,double materialclass, string orderBy, OracleTransaction trans)
        {
            string whStr = "";
            if (codeFrom != "") whStr += (whStr.Trim() == "" ? "" : " AND ") + " UPPER(CODE) > " + DB.SetString("%" + codeFrom.ToUpper() + "%") + " ";
            if (codeTo != "") whStr += (whStr.Trim() == "" ? "" : " AND ") + " UPPER(CODE) < " + DB.SetString("%" + codeTo.ToUpper() + "%") + " "; 
            if (dateFrom.Year > 1) whStr += (whStr.Trim() == "" ? "" : " AND ") + "  TO_DATE(BPODATE)  >=  " + DB.SetDate(dateFrom) + " ";
            if (dateTo.Year > 1) whStr += (whStr.Trim() == "" ? "" : " AND ") + "  TO_DATE(BPODATE)  <=  " + DB.SetDate(dateTo) + "  ";
            if (UsedateFrom.Year > 1) whStr += (whStr.Trim() == "" ? "" : " AND ") + "  TO_DATE(USEDATE)  >=  " + DB.SetDate(UsedateFrom) + " ";
            if (usedateTo.Year > 1) whStr += (whStr.Trim() == "" ? "" : " AND ") + "  TO_DATE(USEDATE)  <=  " + DB.SetDate(usedateTo) + "  ";
            if (materialclass != 0) whStr += (whStr.Trim() == "" ? "" : " AND ") + " MATERIALCLASS = " + DB.SetDouble(materialclass) + " ";
            return GetDataList(whStr, orderBy, trans);
        }

        #endregion

        #region SQL Statements

        /// <summary>
        /// Gets the select statement for V_PREPO_POPUP table.
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
        /// Returns an indication whether the record of V_PREPO_POPUP by specified condition is retrieved successfully.
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
                        if (!Convert.IsDBNull(zRdr["BPODATE"])) _BPODATE = Convert.ToDateTime(zRdr["BPODATE"]);
                        if (!Convert.IsDBNull(zRdr["CLASSNAME"])) _CLASSNAME = zRdr["CLASSNAME"].ToString();
                        if (!Convert.IsDBNull(zRdr["CODE"])) _CODE = zRdr["CODE"].ToString();
                        if (!Convert.IsDBNull(zRdr["LOID"])) _LOID = Convert.ToDouble(zRdr["LOID"]);
                        if (!Convert.IsDBNull(zRdr["MATERIALCLASS"])) _MATERIALCLASS = Convert.ToDouble(zRdr["MATERIALCLASS"]);
                        if (!Convert.IsDBNull(zRdr["SUPPLIER"])) _SUPPLIER = Convert.ToDouble(zRdr["SUPPLIER"]);
                        if (!Convert.IsDBNull(zRdr["SUPPLIERCODE"])) _SUPPLIERCODE = zRdr["SUPPLIERCODE"].ToString();
                        if (!Convert.IsDBNull(zRdr["SUPPLIERNAME"])) _SUPPLIERNAME = zRdr["SUPPLIERNAME"].ToString();
                        if (!Convert.IsDBNull(zRdr["USEDATE"])) _USEDATE = Convert.ToDateTime(zRdr["USEDATE"]);
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