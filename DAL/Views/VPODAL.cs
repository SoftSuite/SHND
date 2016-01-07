using System;
using System.Data;
using System.Data.OracleClient;
using DB = SHND.DAL.Utilities.OracleDB;
using SHND.Data.Common.Utilities;
using SHND.Data.Purchase;

namespace SHND.DAL.Views
{
    /// <summary>
    /// Represents a transaction for V_PO view.
    /// [Created by 127.0.0.1 on April,2 2009]
    /// </summary>
    public class VPODAL
    {

        public VPODAL()
        {
        }

        #region Constant

        /// <summary>V_PO</summary>
        private const string viewName = "V_PO";
        private const string tableName = "PO";

        #endregion

        #region Private Variables

        string _error = "";
        string _information = "";
        bool _OnDB = false;
        string _UPDATEBY = "";
        DateTime _UPDATEON = new DateTime(1, 1, 1);
        string _ADDRESS = "";
        DateTime _BPODATE = new DateTime(1, 1, 1);
        string _CLASSNAME = "";
        string _CNAME = "";
        string _CODE = "";
        string _FAX = "";
        string _ISVAT = "";
        double _LOID = 0;
        double _MATERIALCLASS = 0;
        DateTime _PODATE = new DateTime(1, 1, 1);
        double _PREPO = 0;
        double _PLANORDER = 0;
        string _PREPOCODE = "";
        string _RECEIVECODE = "";
        string _REFPOCODE = "";
        string _REMARKS = "";
        string _STATUS = "";
        string _STATUSNAME = "";
        string _STATUSRANK = "";
        double _SUPPLIER = 0;
        string _SUPPLIERCODE = "";
        string _SUPPLIERNAME = "";
        string _TEL = "";
        DateTime _USEDATE = new DateTime(1, 1, 1);
        double _VATRATE = 0;
        string _CONTRACTCODE = "";

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
        public string FAX
        {
            get { return _FAX; }
            set { _FAX = value; }
        }
        public string ISVAT
        {
            get { return _ISVAT; }
            set { _ISVAT = value; }
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
        public DateTime PODATE
        {
            get { return _PODATE; }
            set { _PODATE = value; }
        }
        public double PREPO
        {
            get { return _PREPO; }
            set { _PREPO = value; }
        }
        public double PLANORDER
        {
            get { return _PLANORDER; }
            set { _PLANORDER = value; }
        }
        public string PREPOCODE
        {
            get { return _PREPOCODE; }
            set { _PREPOCODE = value; }
        }
        public string RECEIVECODE
        {
            get { return _RECEIVECODE; }
            set { _RECEIVECODE = value; }
        }
        public string REFPOCODE
        {
            get { return _REFPOCODE; }
            set { _REFPOCODE = value; }
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
        public double VATRATE
        {
            get { return _VATRATE; }
            set { _VATRATE = value; }
        }
        public string CONTRACTCODE
        {
            get { return _CONTRACTCODE; }
            set { _CONTRACTCODE = value; }
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
            _FAX = "";
            _ISVAT = "";
            _LOID = 0;
            _MATERIALCLASS = 0;
            _PODATE = new DateTime(1, 1, 1);
            _PREPO = 0;
            _PREPOCODE = "";
            _RECEIVECODE = "";
            _REFPOCODE = "";
            _REMARKS = "";
            _STATUS = "";
            _STATUSNAME = "";
            _STATUSRANK = "";
            _SUPPLIER = 0;
            _SUPPLIERCODE = "";
            _SUPPLIERNAME = "";
            _TEL = "";
            _USEDATE = new DateTime(1, 1, 1);
            _VATRATE = 0;
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

        public DataTable GetDataListByCondition(POSearchData pData, string orderBy, OracleTransaction trans)
        {
            //build where clause
            string whStr = "";
            if (pData.POCODEFROM != "") whStr += (whStr.Trim() == "" ? "" : " AND ") + " UPPER(CODE) >= " + DB.SetString(pData.POCODEFROM.ToUpper()) + " ";
            if (pData.POCODETO != "") whStr += (whStr.Trim() == "" ? "" : " AND ") + " UPPER(CODE) <= " + DB.SetString(pData.POCODETO.ToUpper()) + " ";
            if (pData.PREPOCODEFROM != "") whStr += (whStr.Trim() == "" ? "" : " AND ") + " UPPER(PREPOCODE) >= " + DB.SetString(pData.PREPOCODEFROM.ToUpper()) + " ";
            if (pData.PREPOCODETO != "") whStr += (whStr.Trim() == "" ? "" : " AND ") + " UPPER(PREPOCODE) <= " + DB.SetString(pData.PREPOCODETO.ToUpper()) + " ";
            if (pData.PODATEFROM.Year > 1) whStr += (whStr.Trim() == "" ? "" : " AND ") + "  TO_DATE(PODATE)  >=  " + DB.SetDate(pData.PODATEFROM) + " ";
            if (pData.PODATETO.Year > 1) whStr += (whStr.Trim() == "" ? "" : " AND ") + "  TO_DATE(PODATE)  <=  " + DB.SetDate(pData.PODATETO) + "  ";
            if (pData.PREPODATEFROM.Year > 1) whStr += (whStr.Trim() == "" ? "" : " AND ") + "  TO_DATE(BPODATE)  >=  " + DB.SetDate(pData.PREPODATEFROM) + " ";
            if (pData.PREPODATETO.Year > 1) whStr += (whStr.Trim() == "" ? "" : " AND ") + "  TO_DATE(BPODATE)  <=  " + DB.SetDate(pData.PREPODATETO) + "  ";
            if (pData.MATERIALCLASS != 0) whStr += (whStr.Trim() == "" ? "" : " AND ") + " MATERIALCLASS = " + DB.SetDouble(pData.MATERIALCLASS) + " ";
            if (pData.CONTRACTCODE != "") whStr += (whStr.Trim() == "" ? "" : " AND ") + " UPPER(CONTRACTCODE) = " + DB.SetString(pData.CONTRACTCODE.ToUpper()) + " ";
            if (pData.SUPPLIERNAME != "") whStr += (whStr.Trim() == "" ? "" : " AND ") + " UPPER(SUPPLIERNAME) LIKE " + DB.SetString("%" + pData.SUPPLIERNAME.ToUpper() + "%") + " ";
            if (pData.STATUSFROM != "") whStr += (whStr.Trim() == "" ? "" : " AND ") + " STATUSRANK >= " + DB.SetString(pData.STATUSFROM.ToUpper()) + " ";
            if (pData.STATUSTO != "") whStr += (whStr.Trim() == "" ? "" : " AND ") + " STATUSRANK <=  " + DB.SetString(pData.STATUSTO.ToUpper()) + " ";

            return GetDataList(whStr, orderBy, trans);
        }

        public string GetVat()
        {
            string sql = "SELECT CONFIGVALUE FROM SYSCONFIG WHERE LOID = 1 ";

            DataTable dt = DB.ExecuteTable(sql);
            string vat = "";
            if (dt.Rows.Count > 0)
            {
                vat = dt.Rows[0]["CONFIGVALUE"].ToString();

            }

            return vat;
        }

        #endregion

        #region SQL Statements

        /// <summary>
        /// Gets the select statement for V_PO table.
        /// </summary>
        private string sql_select
        {
            get
            {
                string sql = "SELECT * FROM " + viewName + " ";
                return sql;
            }
        }

        /// <summary>
        /// Gets the update statement for PO table.
        /// </summary>
        private string sql_update
        {
            get
            {
                string sql = "UPDATE " + tableName + " SET ";
                sql += "ADDRESS = " + DB.SetString(_ADDRESS) + ", ";
                sql += "CNAME = " + DB.SetString(_CNAME) + ", ";
                sql += "CODE = " + DB.SetString(_CODE) + ", ";
                sql += "FAX = " + DB.SetString(_FAX) + ", ";
                sql += "ISVAT = " + DB.SetString(_ISVAT) + ", ";
                sql += "PODATE = " + DB.SetDateTime(_PODATE) + ", ";
                sql += "PREPO = " + DB.SetDouble(_PREPO) + ", ";
                sql += "RECEIVECODE = " + DB.SetString(_RECEIVECODE) + ", ";
                sql += "REFPOCODE = " + DB.SetString(_REFPOCODE) + ", ";
                sql += "REMARKS = " + DB.SetString(_REMARKS) + ", ";
                sql += "STATUS = " + DB.SetString(_STATUS) + ", ";
                sql += "TEL = " + DB.SetString(_TEL) + ", ";
                sql += "UPDATEBY = " + DB.SetString(_UPDATEBY) + ", ";
                sql += "UPDATEON = " + DB.SetDateTime(_UPDATEON) + ", ";
                sql += "VATRATE = " + DB.SetDouble(_VATRATE) + " ";
                return sql;
            }
        }
        #endregion

        #region Private Methods

        /// <summary>
        /// Returns an indication whether the record of V_PO by specified condition is retrieved successfully.
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
                        if (!Convert.IsDBNull(zRdr["FAX"])) _FAX = zRdr["FAX"].ToString();
                        if (!Convert.IsDBNull(zRdr["ISVAT"])) _ISVAT = zRdr["ISVAT"].ToString();
                        if (!Convert.IsDBNull(zRdr["LOID"])) _LOID = Convert.ToDouble(zRdr["LOID"]);
                        if (!Convert.IsDBNull(zRdr["MATERIALCLASS"])) _MATERIALCLASS = Convert.ToDouble(zRdr["MATERIALCLASS"]);
                        if (!Convert.IsDBNull(zRdr["PODATE"])) _PODATE = Convert.ToDateTime(zRdr["PODATE"]);
                        if (!Convert.IsDBNull(zRdr["PREPO"])) _PREPO = Convert.ToDouble(zRdr["PREPO"]);
                        if (!Convert.IsDBNull(zRdr["PLANORDER"])) _PLANORDER = Convert.ToDouble(zRdr["PLANORDER"]);
                        if (!Convert.IsDBNull(zRdr["PREPOCODE"])) _PREPOCODE = zRdr["PREPOCODE"].ToString();
                        if (!Convert.IsDBNull(zRdr["RECEIVECODE"])) _RECEIVECODE = zRdr["RECEIVECODE"].ToString();
                        if (!Convert.IsDBNull(zRdr["REFPOCODE"])) _REFPOCODE = zRdr["REFPOCODE"].ToString();
                        if (!Convert.IsDBNull(zRdr["REMARKS"])) _REMARKS = zRdr["REMARKS"].ToString();
                        if (!Convert.IsDBNull(zRdr["STATUS"])) _STATUS = zRdr["STATUS"].ToString();
                        if (!Convert.IsDBNull(zRdr["STATUSNAME"])) _STATUSNAME = zRdr["STATUSNAME"].ToString();
                        if (!Convert.IsDBNull(zRdr["STATUSRANK"])) _STATUSRANK = zRdr["STATUSRANK"].ToString();
                        if (!Convert.IsDBNull(zRdr["SUPPLIER"])) _SUPPLIER = Convert.ToDouble(zRdr["SUPPLIER"]);
                        if (!Convert.IsDBNull(zRdr["SUPPLIERCODE"])) _SUPPLIERCODE = zRdr["SUPPLIERCODE"].ToString();
                        if (!Convert.IsDBNull(zRdr["SUPPLIERNAME"])) _SUPPLIERNAME = zRdr["SUPPLIERNAME"].ToString();
                        if (!Convert.IsDBNull(zRdr["TEL"])) _TEL = zRdr["TEL"].ToString();
                        if (!Convert.IsDBNull(zRdr["USEDATE"])) _USEDATE = Convert.ToDateTime(zRdr["USEDATE"]);
                        if (!Convert.IsDBNull(zRdr["VATRATE"])) _VATRATE = Convert.ToDouble(zRdr["VATRATE"]);
                        if (!Convert.IsDBNull(zRdr["CONTRACTCODE"])) _CONTRACTCODE = zRdr["CONTRACTCODE"].ToString();
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
        public bool doUpdate(string whText, OracleTransaction trans)
        {
            bool ret = true;
            int affectedRow = 0;
            if (_OnDB)
            {
                if (whText.Trim() != "")
                {
                    string tmpWhere = "WHERE " + whText;
                    try
                    {
                        affectedRow = DB.ExecuteNonQuery(sql_update + tmpWhere, trans);
                        ret = (affectedRow > 0);
                        if (!ret) _error = DataResources.MSGEU001;
                        _information = DataResources.MSGIU001;
                    }
                    catch (DAL.Utilities.BaseDB.DatabaseException ex)
                    {
                        ret = false;
                        _error = ex.Message;
                    }
                    catch (Exception ex)
                    {
                        ex.ToString();
                        ret = false;
                        _error = DataResources.MSGEC102;
                    }
                }
                else
                {
                    ret = false;
                    _error = DataResources.MSGEU003;
                }
            }
            else
            {
                ret = false;
                _error = DataResources.MSGEU002;
            }
            return ret;
        }
        #endregion

        #region Public Methods
        /// <summary>
        /// Returns an indication whether the current data is updated to PO table successfully.
        /// </summary>
        /// <param name="userID">The current user.</param>
        /// <param name="trans">The System.Data.OracleClient.OracleTransaction used by this System.Data.OracleClient.OracleCommand.</param>
        /// <returns>true if update data successfully; otherwise, false.</returns>
        public bool UpdateCurrentData(string userID, OracleTransaction trans)
        {
            _UPDATEBY = userID;
            _UPDATEON = DateTime.Now;
            return doUpdate("LOID = " + DB.SetDouble(_LOID) + " ", trans);
        }
        #endregion
    }
}