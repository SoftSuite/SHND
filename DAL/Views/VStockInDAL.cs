using System;
using System.Data;
using System.Data.OracleClient;
using DB = SHND.DAL.Utilities.OracleDB;
using SHND.Data.Common.Utilities;

namespace SHND.DAL.Views
{
    /// <summary>
    /// Represents a transaction for V_STOCKIN view.
    /// [Created by 127.0.0.1 on Febuary,18 2009]
    /// </summary>
    public class VStockInDAL
    {

        public VStockInDAL()
        {
        }

        #region Constant

        /// <summary>V_STOCKIN</summary>
        private const string viewName = "V_STOCKIN";

        #endregion

        #region Private Variables

        string _error = "";
        string _information = "";
        bool _OnDB = false;
        string _CODE = "";
        string _CREATEBY = "";
        DateTime _CREATEON = new DateTime(1, 1, 1);
        double _DIVISION = 0;
        double _DOCLOID = 0;
        string _DOCNAME = "";
        double _DOCTYPE = 0;
        string _INVCODE = "";
        string _ISSTOCKIN = "";
        string _ISVAT = "";
        double _LOID = 0;
        double _PO = 0;
        double _PLANORDER = 0;
        double _PLANMATERIALCLASS = 0;
        double _MATERIALCLASS = 0;
        string _REFCODE = "";
        string _STATUS = "";
        string _STATUSNAME = "";
        string _STATUSRANK = "";
        double _SAPWAREHOUSE = 0;
        string _REMARKS = "";
        DateTime _STOCKINDATE = new DateTime(1, 1, 1);
        double _WAREHOUSE = 0;

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
        public double DIVISION
        {
            get { return _DIVISION; }
            set { _DIVISION = value; }
        }
        public double DOCLOID
        {
            get { return _DOCLOID; }
            set { _DOCLOID = value; }
        }
        public string DOCNAME
        {
            get { return _DOCNAME; }
            set { _DOCNAME = value; }
        }
        public double DOCTYPE
        {
            get { return _DOCTYPE; }
            set { _DOCTYPE = value; }
        }
        public string INVCODE
        {
            get { return _INVCODE; }
            set { _INVCODE = value; }
        }
        public string ISSTOCKIN
        {
            get { return _ISSTOCKIN; }
            set { _ISSTOCKIN = value; }
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
        public double PO
        {
            get { return _PO; }
            set { _PO = value; }
        }
        public double PLANORDER
        {
            get { return _PLANORDER; }
            set { _PLANORDER = value; }
        }
        public double PLANMATERIALCLASS
        {
            get { return _PLANMATERIALCLASS; }
            set { _PLANMATERIALCLASS = value; }
        }
        public double MATERIALCLASS
        {
            get { return _MATERIALCLASS; }
            set { _MATERIALCLASS = value; }
        }
        public string REFCODE
        {
            get { return _REFCODE; }
            set { _REFCODE = value; }
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
        public DateTime STOCKINDATE
        {
            get { return _STOCKINDATE; }
            set { _STOCKINDATE = value; }
        }
        public double WAREHOUSE
        {
            get { return _WAREHOUSE; }
            set { _WAREHOUSE = value; }
        }
        public double SAPWAREHOUSE
        {
            get { return _SAPWAREHOUSE; }
            set { _SAPWAREHOUSE = value; }
        }
        public string REMARKS
        {
            get { return _REMARKS; }
            set { _REMARKS  = value; }
        }

        #endregion

        #region Clear Data

        /// <summary>
        /// Initialize data.
        /// </summary>
        private void ClearData()
        {
            _CODE = "";
            _CREATEBY = "";
            _CREATEON = new DateTime(1, 1, 1);
            _DIVISION = 0;
            _DOCLOID = 0;
            _DOCNAME = "";
            _DOCTYPE = 0;
            _INVCODE = "";
            _ISSTOCKIN = "";
            _ISVAT = "";
            _LOID = 0;
            _PO = 0;
            _REFCODE = "";
            _STATUS = "";
            _STATUSNAME = "";
            _STATUSRANK = "";
            _STOCKINDATE = new DateTime(1, 1, 1);
            _WAREHOUSE = 0;
            _PLANORDER = 0;
            _SAPWAREHOUSE = 0;
            _REMARKS = "";

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
        /// Gets the select statement for V_STOCKIN table.
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
        /// Returns an indication whether the record of V_STOCKIN by specified condition is retrieved successfully.
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
                        if (!Convert.IsDBNull(zRdr["CREATEBY"])) _CREATEBY = zRdr["CREATEBY"].ToString();
                        if (!Convert.IsDBNull(zRdr["CREATEON"])) _CREATEON = Convert.ToDateTime(zRdr["CREATEON"]);
                        if (!Convert.IsDBNull(zRdr["DIVISION"])) _DIVISION = Convert.ToDouble(zRdr["DIVISION"]);
                        if (!Convert.IsDBNull(zRdr["DOCLOID"])) _DOCLOID = Convert.ToDouble(zRdr["DOCLOID"]);
                        if (!Convert.IsDBNull(zRdr["DOCNAME"])) _DOCNAME = zRdr["DOCNAME"].ToString();
                        if (!Convert.IsDBNull(zRdr["DOCTYPE"])) _DOCTYPE = Convert.ToDouble(zRdr["DOCTYPE"]);
                        if (!Convert.IsDBNull(zRdr["INVCODE"])) _INVCODE = zRdr["INVCODE"].ToString();
                        if (!Convert.IsDBNull(zRdr["ISSTOCKIN"])) _ISSTOCKIN = zRdr["ISSTOCKIN"].ToString();
                        if (!Convert.IsDBNull(zRdr["ISVAT"])) _ISVAT = zRdr["ISVAT"].ToString();
                        if (!Convert.IsDBNull(zRdr["LOID"])) _LOID = Convert.ToDouble(zRdr["LOID"]);
                        if (!Convert.IsDBNull(zRdr["PO"])) _PO = Convert.ToDouble(zRdr["PO"]);
                        if (!Convert.IsDBNull(zRdr["REFCODE"])) _REFCODE = zRdr["REFCODE"].ToString();
                        if (!Convert.IsDBNull(zRdr["STATUS"])) _STATUS = zRdr["STATUS"].ToString();
                        if (!Convert.IsDBNull(zRdr["STATUSNAME"])) _STATUSNAME = zRdr["STATUSNAME"].ToString();
                        if (!Convert.IsDBNull(zRdr["STATUSRANK"])) _STATUSRANK = zRdr["STATUSRANK"].ToString();
                        if (!Convert.IsDBNull(zRdr["STOCKINDATE"])) _STOCKINDATE = Convert.ToDateTime(zRdr["STOCKINDATE"]);
                        if (!Convert.IsDBNull(zRdr["WAREHOUSE"])) _WAREHOUSE = Convert.ToDouble(zRdr["WAREHOUSE"]);
                        if (!Convert.IsDBNull(zRdr["PLANORDER"])) _PLANORDER = Convert.ToDouble(zRdr["PLANORDER"]);
                        if (!Convert.IsDBNull(zRdr["PLANMATERIALCLASS"])) _PLANMATERIALCLASS = Convert.ToDouble(zRdr["PLANMATERIALCLASS"]);
                        if (!Convert.IsDBNull(zRdr["MATERIALCLASS"])) _MATERIALCLASS = Convert.ToDouble(zRdr["MATERIALCLASS"]);
                        if (!Convert.IsDBNull(zRdr["SAPWAREHOUSE"])) _SAPWAREHOUSE  = Convert.ToDouble(zRdr["SAPWAREHOUSE"]);
                        if (!Convert.IsDBNull(zRdr["REMARKS"])) _REMARKS = zRdr["REMARKS"].ToString();
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

        public DataTable GetDataListByCondition(string cCODE, string cCODET, DateTime cDATE, DateTime cDATET, string cDOCTYPE, string cSTATUS, string cSTATUST, string orderBy, OracleTransaction trans)
        {
            //build where clause
            string whStr = "ISSTOCKIN='Y' ";

            if (cCODE.Trim() != "") whStr += (whStr.Trim() == "" ? "" : " AND ") + " UPPER(CODE)  >=   " + DB.SetString(cCODE.ToUpper()) + " ";
            if (cCODET.Trim() != "") whStr += (whStr.Trim() == "" ? "" : " AND ") + " UPPER(CODE)  <=  " + DB.SetString(cCODET.ToUpper()) + " ";

            if (cDOCTYPE.Trim() != "0") whStr += (whStr.Trim() == "" ? "" : " AND ") + " DOCLOID  =  " + DB.SetString(cDOCTYPE) + "  ";

            if (cDATE.Year > 1) whStr += (whStr.Trim() == "" ? "" : " AND ") + "  TO_DATE(STOCKINDATE)  >=  " + DB.SetDate(cDATE) + " ";
            if (cDATET.Year > 1) whStr += (whStr.Trim() == "" ? "" : " AND ") + "  TO_DATE(STOCKINDATE)  <=  " + DB.SetDate(cDATET) + "  ";

            if (cSTATUS.Trim() != "") whStr += (whStr.Trim() == "" ? "" : " AND ") + " STATUSRANK >= " + DB.SetString(cSTATUS.ToUpper()) + " ";
            if (cSTATUST.Trim() != "") whStr += (whStr.Trim() == "" ? "" : " AND ") + " STATUSRANK <=  " + DB.SetString(cSTATUST.ToUpper()) + " ";


            return GetDataList(whStr, orderBy, trans);
        }


        public DataTable GetDataStockInReturnList(string cCODE, string cCODET, DateTime cDATE, DateTime cDATET, string cDOCTYPE, string cSTATUS, string cSTATUST, string orderBy, OracleTransaction trans)
        {
            //build where clause
            string whStr = "";

            if (cCODE.Trim() != "") whStr += (whStr.Trim() == "" ? "" : " AND ") + " UPPER(CODE)  >=   " + DB.SetString(cCODE.ToUpper()) + " ";
            if (cCODET.Trim() != "") whStr += (whStr.Trim() == "" ? "" : " AND ") + " UPPER(CODE)  <=  " + DB.SetString(cCODET.ToUpper()) + " ";

            if (cDOCTYPE.Trim() != "0") whStr += (whStr.Trim() == "" ? "" : " AND ") + " DOCLOID  =  " + DB.SetString(cDOCTYPE) + "  ";

            if (cDATE.Year > 1) whStr += (whStr.Trim() == "" ? "" : " AND ") + "  TO_DATE(STOCKINDATE)  >=  " + DB.SetDate(cDATE) + " ";
            if (cDATET.Year > 1) whStr += (whStr.Trim() == "" ? "" : " AND ") + "  TO_DATE(STOCKINDATE)  <=  " + DB.SetDate(cDATET) + "  ";

            if (cSTATUS.Trim() != "") whStr += (whStr.Trim() == "" ? "" : " AND ") + " STATUSRANK >= " + DB.SetString(cSTATUS.ToUpper()) + " ";
            if (cSTATUST.Trim() != "") whStr += (whStr.Trim() == "" ? "" : " AND ") + " STATUSRANK <=  " + DB.SetString(cSTATUST.ToUpper()) + " ";


            return GetDataList(whStr, orderBy, trans);
        }


        /// <summary>
        /// Returns an indication whether the record of STOCKIN by specified LOID key is retrieved successfully.
        /// </summary>
        /// <param name="cLOID">The LOID key.</param>
        /// <param name="trans">The System.Data.OracleClient.OracleTransaction used by this System.Data.OracleClient.OracleCommand.</param>
        /// <returns>true if data is retrieved successfully; otherwise, false.</returns>
        public bool GetDataByLOID(double cLOID, OracleTransaction trans)
        {
            return doGetdata("LOID = " + DB.SetDouble(cLOID) + " ", trans);
        }

       
    }
}