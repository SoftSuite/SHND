using System;
using System.Data;
using System.Data.OracleClient;
using DB = SHND.DAL.Utilities.OracleDB;
using SHND.Data.Common.Utilities;


namespace SHND.DAL.Views
{
    /// <summary>
    /// Represents a transaction for V_STOCKOUT view.
    /// [Created by 127.0.0.1 on Febuary,20 2009]
    /// </summary>
    public class VStockOutDAL
    {

        public VStockOutDAL()
        {
        }

        #region Constant

        /// <summary>V_STOCKOUT</summary>
        private const string viewName = "V_STOCKOUT";

        #endregion

        #region Private Variables

        string _error = "";
        string _information = "";
        bool _OnDB = false;
        string _CODE = "";
        double _DIVISION = 0;
        string _DIVISIONNAME = "";
        string _DOCNAME = "";
        double _DOCTYPE = 0;
        string _ISBREAKFAST = "";
        string _ISDINNER = "";
        string _ISLUNCH = "";
        string _ISREQUISITION = "";
        string _ISSTOCKIN = "";
        string _ISSTOCKOUT = "";
        double _LOID = 0;
        double _ORDERQTY = 0;
        double _PRIORITY = 0;
        string _REMARKS = "";
        string _STATUS = "";
        string _STATUSNAME = "";
        string _STATUSRANK = "";
        DateTime _STOCKOUTDATE = new DateTime(1, 1, 1);
        double _SUPPLIER = 0;
        string _TYPE = "";
        DateTime _USEDATE = new DateTime(1, 1, 1);
        double _WAREHOUSE = 0;
        string _WAREHOUSECODE = "";
        string _WAREHOUSENAME = "";

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
        public string ISBREAKFAST
        {
            get { return _ISBREAKFAST; }
            set { _ISBREAKFAST = value; }
        }
        public string ISDINNER
        {
            get { return _ISDINNER; }
            set { _ISDINNER = value; }
        }
        public string ISLUNCH
        {
            get { return _ISLUNCH; }
            set { _ISLUNCH = value; }
        }
        public string ISREQUISITION
        {
            get { return _ISREQUISITION; }
            set { _ISREQUISITION = value; }
        }
        public string ISSTOCKIN
        {
            get { return _ISSTOCKIN; }
            set { _ISSTOCKIN = value; }
        }
        public string ISSTOCKOUT
        {
            get { return _ISSTOCKOUT; }
            set { _ISSTOCKOUT = value; }
        }
        public double LOID
        {
            get { return _LOID; }
            set { _LOID = value; }
        }
        public double ORDERQTY
        {
            get { return _ORDERQTY; }
            set { _ORDERQTY = value; }
        }
        public double PRIORITY
        {
            get { return _PRIORITY; }
            set { _PRIORITY = value; }
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
        public DateTime STOCKOUTDATE
        {
            get { return _STOCKOUTDATE; }
            set { _STOCKOUTDATE = value; }
        }
        public double SUPPLIER
        {
            get { return _SUPPLIER; }
            set { _SUPPLIER = value; }
        }
        public string TYPE
        {
            get { return _TYPE; }
            set { _TYPE = value; }
        }
        public DateTime USEDATE
        {
            get { return _USEDATE; }
            set { _USEDATE = value; }
        }
        public double WAREHOUSE
        {
            get { return _WAREHOUSE; }
            set { _WAREHOUSE = value; }
        }
        public string WAREHOUSECODE
        {
            get { return _WAREHOUSECODE; }
            set { _WAREHOUSECODE = value; }
        }
        public string WAREHOUSENAME
        {
            get { return _WAREHOUSENAME; }
            set { _WAREHOUSENAME = value; }
        }

        #endregion

        #region Clear Data

        /// <summary>
        /// Initialize data.
        /// </summary>
        private void ClearData()
        {
            _CODE = "";
            _DIVISION = 0;
            _DIVISIONNAME = "";
            _DOCNAME = "";
            _DOCTYPE = 0;
            _ISBREAKFAST = "";
            _ISDINNER = "";
            _ISLUNCH = "";
            _ISREQUISITION = "";
            _ISSTOCKIN = "";
            _ISSTOCKOUT = "";
            _LOID = 0;
            _ORDERQTY = 0;
            _PRIORITY = 0;
            _REMARKS = "";
            _STATUS = "";
            _STATUSNAME = "";
            _STATUSRANK = "";
            _STOCKOUTDATE = new DateTime(1, 1, 1);
            _SUPPLIER = 0;
            _TYPE = "";
            _USEDATE = new DateTime(1, 1, 1);
            _WAREHOUSE = 0;
            _WAREHOUSECODE = "";
            _WAREHOUSENAME = "";
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
        /// Gets the select statement for V_STOCKOUT table.
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
        /// Returns an indication whether the record of V_STOCKOUT by specified condition is retrieved successfully.
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
                            if (!Convert.IsDBNull(zRdr["DIVISION"])) _DIVISION = Convert.ToDouble(zRdr["DIVISION"]);
                            if (!Convert.IsDBNull(zRdr["DIVISIONNAME"])) _DIVISIONNAME = zRdr["DIVISIONNAME"].ToString();
                            if (!Convert.IsDBNull(zRdr["DOCNAME"])) _DOCNAME = zRdr["DOCNAME"].ToString();
                            if (!Convert.IsDBNull(zRdr["DOCTYPE"])) _DOCTYPE = Convert.ToDouble(zRdr["DOCTYPE"]);
                            if (!Convert.IsDBNull(zRdr["ISBREAKFAST"])) _ISBREAKFAST = zRdr["ISBREAKFAST"].ToString();
                            if (!Convert.IsDBNull(zRdr["ISDINNER"])) _ISDINNER = zRdr["ISDINNER"].ToString();
                            if (!Convert.IsDBNull(zRdr["ISLUNCH"])) _ISLUNCH = zRdr["ISLUNCH"].ToString();
                            if (!Convert.IsDBNull(zRdr["ISREQUISITION"])) _ISREQUISITION = zRdr["ISREQUISITION"].ToString();
                            if (!Convert.IsDBNull(zRdr["ISSTOCKIN"])) _ISSTOCKIN = zRdr["ISSTOCKIN"].ToString();
                            if (!Convert.IsDBNull(zRdr["ISSTOCKOUT"])) _ISSTOCKOUT = zRdr["ISSTOCKOUT"].ToString();
                            if (!Convert.IsDBNull(zRdr["LOID"])) _LOID = Convert.ToDouble(zRdr["LOID"]);
                            if (!Convert.IsDBNull(zRdr["ORDERQTY"])) _ORDERQTY = Convert.ToDouble(zRdr["ORDERQTY"]);
                            if (!Convert.IsDBNull(zRdr["PRIORITY"])) _PRIORITY = Convert.ToDouble(zRdr["PRIORITY"]);
                            if (!Convert.IsDBNull(zRdr["REMARKS"])) _REMARKS = zRdr["REMARKS"].ToString();
                            if (!Convert.IsDBNull(zRdr["STATUS"])) _STATUS = zRdr["STATUS"].ToString();
                            if (!Convert.IsDBNull(zRdr["STATUSNAME"])) _STATUSNAME = zRdr["STATUSNAME"].ToString();
                            if (!Convert.IsDBNull(zRdr["STATUSRANK"])) _STATUSRANK = zRdr["STATUSRANK"].ToString();
                            if (!Convert.IsDBNull(zRdr["STOCKOUTDATE"])) _STOCKOUTDATE = Convert.ToDateTime(zRdr["STOCKOUTDATE"]);
                            if (!Convert.IsDBNull(zRdr["SUPPLIER"])) _SUPPLIER = Convert.ToDouble(zRdr["SUPPLIER"]);
                            if (!Convert.IsDBNull(zRdr["TYPE"])) _TYPE = zRdr["TYPE"].ToString();
                            if (!Convert.IsDBNull(zRdr["USEDATE"])) _USEDATE = Convert.ToDateTime(zRdr["USEDATE"]);
                            if (!Convert.IsDBNull(zRdr["WAREHOUSE"])) _WAREHOUSE = Convert.ToDouble(zRdr["WAREHOUSE"]);
                            if (!Convert.IsDBNull(zRdr["WAREHOUSECODE"])) _WAREHOUSECODE = zRdr["WAREHOUSECODE"].ToString();
                            if (!Convert.IsDBNull(zRdr["WAREHOUSENAME"])) _WAREHOUSENAME = zRdr["WAREHOUSENAME"].ToString();
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

        public DataTable GetDataListByConditions(double cWAREHOUSE, double cDOCTYPE, double cDIVISION, string cCODEFROM, string cCODETO, DateTime cUSEDATEFROM, DateTime cUSEDATETO,
            DateTime cSTOCKOUTDATEFROM, DateTime cSTOCKOUTDATETO, string cSTATUSRANKFROM, string cSTATUSRANKTO, string cISSTOCKIN, string cISSTOCKOUT, string orderBy, OracleTransaction trans)
        {
            string whText = "";
            if (cWAREHOUSE != 0) whText += (whText.Trim() == "" ? "" : "AND ") + "WAREHOUSE =  " + DB.SetDouble(cWAREHOUSE) + "  ";
            if (cDOCTYPE != 0) whText += (whText.Trim() == "" ? "" : "AND ") + "DOCTYPE = " + DB.SetDouble(cDOCTYPE) + "  ";
            if (cDIVISION != 0) whText += (whText.Trim() == "" ? "" : "AND ") + "DIVISION =  " + DB.SetDouble(cDIVISION) + "  ";
            if (cCODEFROM.Trim() != "") whText += (whText.Trim() == "" ? "" : "AND ") + "UPPER(CODE)  >=   " + DB.SetString(cCODEFROM.ToUpper()) + " ";
            if (cCODETO.Trim() != "") whText += (whText.Trim() == "" ? "" : "AND ") + "UPPER(CODE)  <=  " + DB.SetString(cCODETO.ToUpper()) + " ";
            if (cUSEDATEFROM.Year > 1) whText += (whText.Trim() == "" ? "" : "AND ") + "TO_DATE(USEDATE)  >=  " + DB.SetDate(cUSEDATEFROM) + " ";
            if (cUSEDATETO.Year > 1) whText += (whText.Trim() == "" ? "" : "AND ") + "TO_DATE(USEDATE)  <=  " + DB.SetDate(cUSEDATETO) + "  ";
            if (cSTOCKOUTDATEFROM.Year > 1) whText += (whText.Trim() == "" ? "" : "AND ") + "TO_DATE(STOCKOUTDATE)  >=  " + DB.SetDate(cSTOCKOUTDATEFROM) + " ";
            if (cSTOCKOUTDATETO.Year > 1) whText += (whText.Trim() == "" ? "" : "AND ") + "TO_DATE(STOCKOUTDATE)  <=  " + DB.SetDate(cSTOCKOUTDATETO) + "  ";
            if (cSTATUSRANKFROM.Trim() != "") whText += (whText.Trim() == "" ? "" : "AND ") + "STATUSRANK >= " + DB.SetString(cSTATUSRANKFROM.ToUpper()) + " ";
            if (cSTATUSRANKTO.Trim() != "") whText += (whText.Trim() == "" ? "" : "AND ") + "STATUSRANK <=  " + DB.SetString(cSTATUSRANKTO.ToUpper()) + " ";
            if (cISSTOCKIN.Trim() != "") whText += (whText.Trim() == "" ? "" : "AND ") + "UPPER(ISSTOCKIN)  =  " + DB.SetString(cISSTOCKIN.ToUpper()) + " ";
            if (cISSTOCKOUT.Trim() != "") whText += (whText.Trim() == "" ? "" : "AND ") + "UPPER(ISSTOCKOUT)  =  " + DB.SetString(cISSTOCKOUT.ToUpper()) + " ";

            return GetDataList(whText, orderBy, trans);
        }
        public DataTable GetDataListByConditions(double cWAREHOUSE, double cDOCTYPE, double cDIVISION, string cCODEFROM, string cCODETO, DateTime cUSEDATEFROM, DateTime cUSEDATETO, 
            DateTime cSTOCKOUTDATEFROM, DateTime cSTOCKOUTDATETO, string cSTATUSRANKFROM, string cSTATUSRANKTO, string orderBy, OracleTransaction trans)
        {
            return GetDataListByConditions(cWAREHOUSE, cDOCTYPE, cDIVISION, cCODEFROM, cCODETO, cUSEDATEFROM, cUSEDATETO, cSTOCKOUTDATEFROM, cSTOCKOUTDATETO,
                cSTATUSRANKFROM, cSTATUSRANKTO, "", "", orderBy, trans);
        }
        public DataTable GetDataToDoList(string cCODEFROM, string cCODETO, DateTime cUSEDATEFROM, DateTime cUSEDATETO, string cSTATUSRANKFROM, string cSTATUSRANKTO, string orderBy, OracleTransaction trans)
        {
            string whText = " ISSTOCKOUT='Y' ";
            if (cCODEFROM.Trim() != "") whText += (whText.Trim() == "" ? "" : "AND ") + "UPPER(CODE)  >=   " + DB.SetString(cCODEFROM.ToUpper()) + " ";
            if (cCODETO.Trim() != "") whText += (whText.Trim() == "" ? "" : "AND ") + "UPPER(CODE)  <=  " + DB.SetString(cCODETO.ToUpper()) + " ";
            if (cUSEDATEFROM.Year > 1) whText += (whText.Trim() == "" ? "" : "AND ") + "TO_DATE(USEDATE)  >=  " + DB.SetDate(cUSEDATEFROM) + " ";
            if (cUSEDATETO.Year > 1) whText += (whText.Trim() == "" ? "" : "AND ") + "TO_DATE(USEDATE)  <=  " + DB.SetDate(cUSEDATETO) + "  ";
            if (cSTATUSRANKFROM.Trim() != "") whText += (whText.Trim() == "" ? "" : "AND ") + "STATUSRANK >= " + DB.SetString(cSTATUSRANKFROM.ToUpper()) + " ";
            if (cSTATUSRANKTO.Trim() != "") whText += (whText.Trim() == "" ? "" : "AND ") + "STATUSRANK <=  " + DB.SetString(cSTATUSRANKTO.ToUpper()) + " ";
            return GetDataList(whText, orderBy, trans);
        }

        /// <summary>
        /// Returns an indication whether the record of STOCKOUTWASTE by specified LOID key is retrieved successfully.
        /// </summary>
        /// <param name="cLOID">The LOID key.</param>
        /// <param name="trans">The System.Data.OracleClient.OracleTransaction used by this System.Data.OracleClient.OracleCommand.</param>
        /// <returns>true if data is retrieved successfully; otherwise, false.</returns>
        public bool GetDataByLOID(double cLOID, OracleTransaction trans)
        {
            return doGetdata("LOID = " + DB.SetDouble(cLOID) + " ", trans);
        }
        public DataTable GetDataListByCondisionsSearch(double cWAREHOUSE, double cDOCTYPE, double cDIVISION, string cCODEFROM, string cCODETO, DateTime cSTOCKOUTDATEFROM, DateTime cSTOCKOUTDATETO, string cSTATUSRANKFROM, string cSTATUSRANKTO, string orderBy, OracleTransaction trans)
        {
            string whText = "";
            if (cWAREHOUSE != 0) whText += (whText.Trim() == "" ? "" : "AND ") + "WAREHOUSE =  " + DB.SetDouble(cWAREHOUSE) + "  ";
            if (cDOCTYPE != 0) whText += (whText.Trim() == "" ? "" : "AND ") + "DOCTYPE = " + DB.SetDouble(cDOCTYPE) + "  ";
            if (cDIVISION != 0) whText += (whText.Trim() == "" ? "" : "AND ") + "DIVISION =  " + DB.SetDouble(cDIVISION) + "  ";
            if (cCODEFROM.Trim() != "") whText += (whText.Trim() == "" ? "" : "AND ") + "UPPER(CODE)  >=   " + DB.SetString(cCODEFROM.ToUpper()) + " ";
            if (cCODETO.Trim() != "") whText += (whText.Trim() == "" ? "" : "AND ") + "UPPER(CODE)  <=  " + DB.SetString(cCODETO.ToUpper()) + " ";
            if (cSTOCKOUTDATEFROM.Year > 1) whText += (whText.Trim() == "" ? "" : "AND ") + "TO_DATE(STOCKOUTDATE)  >=  " + DB.SetDate(cSTOCKOUTDATEFROM) + " ";
            if (cSTOCKOUTDATETO.Year > 1) whText += (whText.Trim() == "" ? "" : "AND ") + "TO_DATE(STOCKOUTDATE)  <=  " + DB.SetDate(cSTOCKOUTDATETO) + "  ";
            if (cSTATUSRANKFROM.Trim() != "") whText += (whText.Trim() == "" ? "" : "AND ") + "STATUSRANK >= " + DB.SetString(cSTATUSRANKFROM.ToUpper()) + " ";
            if (cSTATUSRANKTO.Trim() != "") whText += (whText.Trim() == "" ? "" : "AND ") + "STATUSRANK <=  " + DB.SetString(cSTATUSRANKTO.ToUpper()) + " ";

            return GetDataList(whText, orderBy, trans);

        }
        
    }
    
}