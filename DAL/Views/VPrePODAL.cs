using System;
using System.Data;
using System.Data.OracleClient;
using DB = SHND.DAL.Utilities.OracleDB;
using SHND.Data.Common.Utilities;
using SHND.Data.Purchase;

namespace SHND.DAL.Views
{
    /// <summary>
    /// Represents a transaction for V_PREPO view.
    /// [Created by 127.0.0.1 on March,11 2009]
    /// </summary>
    public class VPrePODAL
    {

        public VPrePODAL()
        {
        }

        #region Constant

        /// <summary>V_PREPO</summary>
        private const string viewName = "V_PREPO";

        #endregion

        #region Private Variables

        string _error = "";
        string _information = "";
        bool _OnDB = false;
        string _ADDRESS = "";
        DateTime _BPODATE = new DateTime(1, 1, 1);
        string _CLASSNAME = "";
        string _CNAME = "";
        string _CODE = "";
        string _CONTRACTCODE = "";
        string _FAX = "";
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
        string _TEL = "";
        DateTime _USEDATE = new DateTime(1, 1, 1);
        double _POVAT = 0;
        double _PONOVAT = 0;

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
        public string ADDRESS
        {
            get { return _ADDRESS; }
            set { _ADDRESS = value; }
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
        public string CNAME
        {
            get { return _CNAME; }
            set { _CNAME = value; }
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
        public string FAX
        {
            get { return _FAX; }
            set { _FAX = value; }
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
        public string TEL
        {
            get { return _TEL; }
            set { _TEL = value; }
        }
        public DateTime USEDATE
        {
            get { return _USEDATE; }
            set { _USEDATE = value; }
        }
        public double POVAT
        {
            get { return _POVAT; }
            set { _POVAT = value; }
        }
        public double PONOVAT
        {
            get { return _PONOVAT; }
            set { _PONOVAT = value; }
        }

        #endregion

        #region Clear Data

        /// <summary>
        /// Initialize data.
        /// </summary>
        private void ClearData()
        {
            _ADDRESS = "";
            _BPODATE = new DateTime(1, 1, 1);
            _CLASSNAME = "";
            _CNAME = "";
            _CODE = "";
            _CONTRACTCODE = "";
            _FAX = "";
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
            _TEL = "";
            _USEDATE = new DateTime(1, 1, 1);
            _POVAT = 0;
            _PONOVAT = 0;
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

        public DataTable GetDataListByCondition(PrePOSearchData pData, string orderBy, OracleTransaction trans)
        {
            //build where clause
            string whStr = "";
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
        /// Gets the select statement for V_PREPO table.
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
        /// Returns an indication whether the record of V_PREPO by specified condition is retrieved successfully.
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
                        if (!Convert.IsDBNull(zRdr["ADDRESS"])) _ADDRESS = zRdr["ADDRESS"].ToString();
                        if (!Convert.IsDBNull(zRdr["BPODATE"])) _BPODATE = Convert.ToDateTime(zRdr["BPODATE"]);
                        if (!Convert.IsDBNull(zRdr["CLASSNAME"])) _CLASSNAME = zRdr["CLASSNAME"].ToString();
                        if (!Convert.IsDBNull(zRdr["CNAME"])) _CNAME = zRdr["CNAME"].ToString();
                        if (!Convert.IsDBNull(zRdr["CODE"])) _CODE = zRdr["CODE"].ToString();
                        if (!Convert.IsDBNull(zRdr["CONTRACTCODE"])) _CONTRACTCODE = zRdr["CONTRACTCODE"].ToString();
                        if (!Convert.IsDBNull(zRdr["FAX"])) _FAX = zRdr["FAX"].ToString();
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
                        if (!Convert.IsDBNull(zRdr["TEL"])) _TEL = zRdr["TEL"].ToString();
                        if (!Convert.IsDBNull(zRdr["USEDATE"])) _USEDATE = Convert.ToDateTime(zRdr["USEDATE"]);
                        if (!Convert.IsDBNull(zRdr["POVAT"])) _POVAT = Convert.ToDouble(zRdr["POVAT"]);
                        if (!Convert.IsDBNull(zRdr["PONOVAT"])) _PONOVAT = Convert.ToDouble(zRdr["PONOVAT"]);

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