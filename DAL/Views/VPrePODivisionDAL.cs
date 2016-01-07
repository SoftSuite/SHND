using System;
using System.Data;
using System.Data.OracleClient;
using DB = SHND.DAL.Utilities.OracleDB;
using SHND.Data.Common.Utilities;
using SHND.Data.Purchase;

namespace SHND.DAL.Views
{
    /// <summary>
    /// Represents a transaction for V_PREPODIVISION view.
    /// [Created by 127.0.0.1 on Febuary,26 2009]
    /// </summary>
    public class VPrePODivisionDAL
    {

        public VPrePODivisionDAL()
        {
        }

        #region Constant

        /// <summary>V_PREPODIVISION</summary>
        private const string viewName = "V_PREPODIVISION";

        #endregion

        #region Private Variables

        string _error = "";
        string _information = "";
        bool _OnDB = false;
        DateTime _BPODATE = new DateTime(1, 1, 1);
        string _CLASSNAME = "";
        string _CODE = "";
        string _CONTRACTCODE = "";
        double _DIVISION = 0;
        string _DIVISIONNAME = "";
        double _LOID = 0;
        double _MATERIALCLASS = 0;
        double _PLANMATERIALCLASS = 0;
        double _PLANORDER = 0;
        string _REMARKS = "";
        string _STATUS = "";
        string _STATUSNAME = "";
        string _STATUSRANK = "";
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
        public string CONTRACTCODE
        {
            get { return _CONTRACTCODE; }
            set { _CONTRACTCODE = value; }
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
        public double MATERIALCLASS
        {
            get { return _MATERIALCLASS; }
            set { _MATERIALCLASS = value; }
        }
        public double PLANMATERIALCLASS
        {
            get { return _PLANMATERIALCLASS; }
            set { _PLANMATERIALCLASS = value; }
        }
        public double PLANORDER
        {
            get { return _PLANORDER; }
            set { _PLANORDER = value; }
        }
        public string REMARKS
        {
            get { return _REMARKS; }
            set { _REMARKS = value; }
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
            _CONTRACTCODE = "";
            _DIVISION = 0;
            _DIVISIONNAME = "";
            _LOID = 0;
            _MATERIALCLASS = 0;
            _PLANMATERIALCLASS = 0;
            _PLANORDER = 0;
            _REMARKS = "";
            _STATUS = "";
            _STATUSNAME = "";
            _STATUSRANK = "";
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
        public bool GetDataByLOID(double cLOID, OracleTransaction trans)
        {
            return doGetdata("LOID = " + DB.SetDouble(cLOID) + " ", trans);
        }

        public bool GetDataByUniqueKey(double cDIVISION, double cPLANMATERIALCLASS, DateTime cUSEDATE, OracleTransaction trans)
        {
            return doGetdata("DIVISION = " + DB.SetDouble(cDIVISION) + " AND PLANMATERIALCLASS = " + DB.SetDouble(cPLANMATERIALCLASS) + " AND USEDATE = " + DB.SetDateTime(cUSEDATE), trans);
        }

        public DataTable GetDataListByCondition(PrePOSearchData pData, string orderBy, OracleTransaction trans)
        {
            //build where clause
            string whStr = " DIVISION = " + DB.SetDouble(pData.DIVISION) + " ";
            if (pData.CODEFROM != "") whStr += (whStr.Trim() == "" ? "" : " AND ") + " UPPER(CODE) >= " + DB.SetString(pData.CODEFROM.ToUpper()) + " ";
            if (pData.CODETO != "") whStr += (whStr.Trim() == "" ? "" : " AND ") + " UPPER(CODE) <= " + DB.SetString(pData.CODETO.ToUpper()) + " ";
            if (pData.PODATEFROM.Year > 1) whStr += (whStr.Trim() == "" ? "" : " AND ") + "  TO_DATE(BPODATE)  >=  " + DB.SetDate(pData.PODATEFROM) + " ";
            if (pData.PODATETO.Year > 1) whStr += (whStr.Trim() == "" ? "" : " AND ") + "  TO_DATE(BPODATE)  <=  " + DB.SetDate(pData.PODATETO) + "  ";
            if (pData.USEDATEFROM.Year > 1) whStr += (whStr.Trim() == "" ? "" : " AND ") + "  TO_DATE(USEDATE)  >=  " + DB.SetDate(pData.USEDATEFROM) + " ";
            if (pData.USEDATETO.Year > 1) whStr += (whStr.Trim() == "" ? "" : " AND ") + "  TO_DATE(USEDATE)  <=  " + DB.SetDate(pData.USEDATETO) + "  ";
            if (pData.MATERIALCLASS != 0) whStr += (whStr.Trim() == "" ? "" : " AND ") + " MATERIALCLASS = " + DB.SetDouble(pData.MATERIALCLASS) + " ";
            if (pData.CONTRACTCODE != "") whStr += (whStr.Trim() == "" ? "" : " AND ") + " UPPER(CONTRACTCODE) = " + DB.SetString(pData.CONTRACTCODE.ToUpper()) + " ";
            if (pData.SUPPLIERNAME != "") whStr += (whStr.Trim() == "" ? "" : " AND ") + " UPPER(SUPPLIERNAME) LIKE " + DB.SetString("%" + pData.SUPPLIERNAME.ToUpper() + "%") + " ";
            if (pData.PLAN != 0) whStr += (whStr.Trim() == "" ? "" : " AND ") + " PLANORDER = " + DB.SetDouble(pData.PLAN) + " ";
            if (pData.STATUSFROM != "") whStr += (whStr.Trim() == "" ? "" : " AND ") + " STATUSRANK >= " + DB.SetString(pData.STATUSFROM.ToUpper()) + " ";
            if (pData.STATUSTO != "") whStr += (whStr.Trim() == "" ? "" : " AND ") + " STATUSRANK <=  " + DB.SetString(pData.STATUSTO.ToUpper()) + " ";

            return GetDataList(whStr, orderBy, trans);
        }

        #endregion

        #region SQL Statements

        /// <summary>
        /// Gets the select statement for V_PREPODIVISION table.
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
        /// Returns an indication whether the record of V_PREPODIVISION by specified condition is retrieved successfully.
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
                        if (!Convert.IsDBNull(zRdr["CONTRACTCODE"])) _CONTRACTCODE = zRdr["CONTRACTCODE"].ToString();
                        if (!Convert.IsDBNull(zRdr["DIVISION"])) _DIVISION = Convert.ToDouble(zRdr["DIVISION"]);
                        if (!Convert.IsDBNull(zRdr["DIVISIONNAME"])) _DIVISIONNAME = zRdr["DIVISIONNAME"].ToString();
                        if (!Convert.IsDBNull(zRdr["LOID"])) _LOID = Convert.ToDouble(zRdr["LOID"]);
                        if (!Convert.IsDBNull(zRdr["MATERIALCLASS"])) _MATERIALCLASS = Convert.ToDouble(zRdr["MATERIALCLASS"]);
                        if (!Convert.IsDBNull(zRdr["PLANMATERIALCLASS"])) _PLANMATERIALCLASS = Convert.ToDouble(zRdr["PLANMATERIALCLASS"]);
                        if (!Convert.IsDBNull(zRdr["PLANORDER"])) _PLANORDER = Convert.ToDouble(zRdr["PLANORDER"]);
                        if (!Convert.IsDBNull(zRdr["REMARKS"])) _REMARKS = zRdr["REMARKS"].ToString();
                        if (!Convert.IsDBNull(zRdr["STATUS"])) _STATUS = zRdr["STATUS"].ToString();
                        if (!Convert.IsDBNull(zRdr["STATUSNAME"])) _STATUSNAME = zRdr["STATUSNAME"].ToString();
                        if (!Convert.IsDBNull(zRdr["STATUSRANK"])) _STATUSRANK = zRdr["STATUSRANK"].ToString();
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