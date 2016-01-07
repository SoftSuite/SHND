using System;
using System.Data;
using System.Data.OracleClient;
using DB = SHND.DAL.Utilities.OracleDB;
using SHND.Data.Common.Utilities;
using SHND.Data.Purchase;

namespace SHND.DAL.Views
{
    /// <summary>
    /// Represents a transaction for V_RECEIVE view.
    /// [Created by 127.0.0.1 on March,31 2009]
    /// </summary>
    public class VReceiveDAL
    {

        public VReceiveDAL()
        {
        }

        #region Constant

        /// <summary>V_RECEIVE</summary>
        private const string viewName = "V_RECEIVE";

        #endregion

        #region Private Variables

        string _error = "";
        string _information = "";
        bool _OnDB = false;
        string _CLASSNAME = "";
        string _CONTRACTCODE = "";
        string _CREATEBY = "";
        DateTime _CREATEON = new DateTime(1, 1, 1);
        string _FAX = "";
        double _LOID = 0;
        double _MATERIALCLASS = 0;
        double _PLANMATERIALCLASS = 0;
        double _PLANORDER = 0;
        DateTime _RECEIVEDATE = new DateTime(1, 1, 1);
        string _REMARKS = "";
        string _STATUS = "";
        string _STATUSNAME = "";
        string _STATUSRANK = "";
        double _SUPPLIER = 0;
        string _SUPPLIERCODE = "";
        string _SUPPLIERNAME = "";
        string _TEL = "";
        string _UPDATEBY = "";
        DateTime _UPDATEON = new DateTime(1, 1, 1);

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
        public string CLASSNAME
        {
            get { return _CLASSNAME; }
            set { _CLASSNAME = value; }
        }
        public string CONTRACTCODE
        {
            get { return _CONTRACTCODE; }
            set { _CONTRACTCODE = value; }
        }
        public string CREATEBY
        {
            get { return _CREATEBY; }
            set { _CREATEBY = value; }
        }
        public DateTime CREATEON
        {
            get { return _CREATEON; }
            set { _CREATEON = value; }
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
        public DateTime RECEIVEDATE
        {
            get { return _RECEIVEDATE; }
            set { _RECEIVEDATE = value; }
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
        public string UPDATEBY
        {
            get { return _UPDATEBY; }
            set { _UPDATEBY = value; }
        }
        public DateTime UPDATEON
        {
            get { return _UPDATEON; }
            set { _UPDATEON = value; }
        }

        #endregion

        #region Clear Data

        /// <summary>
        /// Initialize data.
        /// </summary>
        private void ClearData()
        {
            _CLASSNAME = "";
            _CONTRACTCODE = "";
            _CREATEBY = "";
            _CREATEON = new DateTime(1, 1, 1);
            _FAX = "";
            _LOID = 0;
            _MATERIALCLASS = 0;
            _PLANMATERIALCLASS = 0;
            _PLANORDER = 0;
            _RECEIVEDATE = new DateTime(1, 1, 1);
            _REMARKS = "";
            _STATUS = "";
            _STATUSNAME = "";
            _STATUSRANK = "";
            _SUPPLIER = 0;
            _SUPPLIERCODE = "";
            _SUPPLIERNAME = "";
            _TEL = "";
            _UPDATEBY = "";
            _UPDATEON = new DateTime(1, 1, 1);
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

        public DataTable GetDataListByCondition(ReceiveSearchData pData, string orderBy, OracleTransaction trans)
        {
            //build where clause
            string whStr = "";
            if (pData.RECEIVEDATEFROM.Year > 1) whStr += (whStr.Trim() == "" ? "" : " AND ") + "  TO_DATE(RECEIVEDATE)  >=  " + DB.SetDate(pData.RECEIVEDATEFROM) + " ";
            if (pData.RECEIVEDATETO.Year > 1) whStr += (whStr.Trim() == "" ? "" : " AND ") + "  TO_DATE(RECEIVEDATE)  <=  " + DB.SetDate(pData.RECEIVEDATETO) + "  ";
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
        /// Gets the select statement for V_RECEIVE table.
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
        /// Returns an indication whether the record of V_RECEIVE by specified condition is retrieved successfully.
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
                        if (!Convert.IsDBNull(zRdr["CLASSNAME"])) _CLASSNAME = zRdr["CLASSNAME"].ToString();
                        if (!Convert.IsDBNull(zRdr["CONTRACTCODE"])) _CONTRACTCODE = zRdr["CONTRACTCODE"].ToString();
                        if (!Convert.IsDBNull(zRdr["CREATEBY"])) _CREATEBY = zRdr["CREATEBY"].ToString();
                        if (!Convert.IsDBNull(zRdr["CREATEON"])) _CREATEON = Convert.ToDateTime(zRdr["CREATEON"]);
                        if (!Convert.IsDBNull(zRdr["FAX"])) _FAX = zRdr["FAX"].ToString();
                        if (!Convert.IsDBNull(zRdr["LOID"])) _LOID = Convert.ToDouble(zRdr["LOID"]);
                        if (!Convert.IsDBNull(zRdr["MATERIALCLASS"])) _MATERIALCLASS = Convert.ToDouble(zRdr["MATERIALCLASS"]);
                        if (!Convert.IsDBNull(zRdr["PLANMATERIALCLASS"])) _PLANMATERIALCLASS = Convert.ToDouble(zRdr["PLANMATERIALCLASS"]);
                        if (!Convert.IsDBNull(zRdr["PLANORDER"])) _PLANORDER = Convert.ToDouble(zRdr["PLANORDER"]);
                        if (!Convert.IsDBNull(zRdr["RECEIVEDATE"])) _RECEIVEDATE = Convert.ToDateTime(zRdr["RECEIVEDATE"]);
                        if (!Convert.IsDBNull(zRdr["REMARKS"])) _REMARKS = zRdr["REMARKS"].ToString();
                        if (!Convert.IsDBNull(zRdr["STATUS"])) _STATUS = zRdr["STATUS"].ToString();
                        if (!Convert.IsDBNull(zRdr["STATUSNAME"])) _STATUSNAME = zRdr["STATUSNAME"].ToString();
                        if (!Convert.IsDBNull(zRdr["STATUSRANK"])) _STATUSRANK = zRdr["STATUSRANK"].ToString();
                        if (!Convert.IsDBNull(zRdr["SUPPLIER"])) _SUPPLIER = Convert.ToDouble(zRdr["SUPPLIER"]);
                        if (!Convert.IsDBNull(zRdr["SUPPLIERCODE"])) _SUPPLIERCODE = zRdr["SUPPLIERCODE"].ToString();
                        if (!Convert.IsDBNull(zRdr["SUPPLIERNAME"])) _SUPPLIERNAME = zRdr["SUPPLIERNAME"].ToString();
                        if (!Convert.IsDBNull(zRdr["TEL"])) _TEL = zRdr["TEL"].ToString();
                        if (!Convert.IsDBNull(zRdr["UPDATEBY"])) _UPDATEBY = zRdr["UPDATEBY"].ToString();
                        if (!Convert.IsDBNull(zRdr["UPDATEON"])) _UPDATEON = Convert.ToDateTime(zRdr["UPDATEON"]);
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