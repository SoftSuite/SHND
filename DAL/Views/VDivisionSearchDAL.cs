using System;
using System.Data;
using System.Data.OracleClient;
using DB = SHND.DAL.Utilities.OracleDB;
using SHND.Data.Common.Utilities;

namespace SHND.DAL.Tables
{
    /// <summary>
    /// Represents a transaction for V_DIVISION_SEARCH view.
    /// [Created by 127.0.0.1 on January,26 2009]
    /// </summary>
    public class VDivisionSeacrhDAL
    {

        public VDivisionSeacrhDAL()
        {
        }

        #region Constant

        /// <summary>V_DIVISION_SEARCH</summary>
        private const string viewName = "V_DIVISION_SEARCH";

        #endregion

        #region Private Variables

        string _error = "";
        string _information = "";
        bool _OnDB = false;
        string _ACTIVE = "";
        string _CODE = "";
        string _DIACTIVE = "";
        string _ISDIRECTOR = "";
        string _ISFORMULA = "";
        string _ISNUTRIENT = "";
        string _ISONLINEREQUEST = "";
        string _ISPARTY = "";
        string _ISPLAN = "";
        string _ISSTOCKOUT = "";
        string _ISSUBDIVISION = "";
        string _ISWELFARE = "";
        double _LOID = 0;
        double _MAINDIVISION = 0;
        string _MAINDIVISIONNAME = "";
        string _NAME = "";

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
        public string ACTIVE
        {
            get { return _ACTIVE; }
            set { _ACTIVE = value; }
        }
        public string CODE
        {
            get { return _CODE; }
            set { _CODE = value; }
        }
        public string DIACTIVE
        {
            get { return _DIACTIVE; }
            set { _DIACTIVE = value; }
        }
        public string ISDIRECTOR
        {
            get { return _ISDIRECTOR; }
            set { _ISDIRECTOR = value; }
        }
        public string ISFORMULA
        {
            get { return _ISFORMULA; }
            set { _ISFORMULA = value; }
        }
        public string ISNUTRIENT
        {
            get { return _ISNUTRIENT; }
            set { _ISNUTRIENT = value; }
        }
        public string ISONLINEREQUEST
        {
            get { return _ISONLINEREQUEST; }
            set { _ISONLINEREQUEST = value; }
        }
        public string ISPARTY
        {
            get { return _ISPARTY; }
            set { _ISPARTY = value; }
        }
        public string ISPLAN
        {
            get { return _ISPLAN; }
            set { _ISPLAN = value; }
        }
        public string ISSTOCKOUT
        {
            get { return _ISSTOCKOUT; }
            set { _ISSTOCKOUT = value; }
        }
        public string ISSUBDIVISION
        {
            get { return _ISSUBDIVISION; }
            set { _ISSUBDIVISION = value; }
        }
        public string ISWELFARE
        {
            get { return _ISWELFARE; }
            set { _ISWELFARE = value; }
        }
        public double LOID
        {
            get { return _LOID; }
            set { _LOID = value; }
        }
        public double MAINDIVISION
        {
            get { return _MAINDIVISION; }
            set { _MAINDIVISION = value; }
        }
        public string MAINDIVISIONNAME
        {
            get { return _MAINDIVISIONNAME; }
            set { _MAINDIVISIONNAME = value; }
        }
        public string NAME
        {
            get { return _NAME; }
            set { _NAME = value; }
        }

        #endregion

        #region Clear Data

        /// <summary>
        /// Initialize data.
        /// </summary>
        private void ClearData()
        {
            _ACTIVE = "";
            _CODE = "";
            _DIACTIVE = "";
            _ISDIRECTOR = "";
            _ISFORMULA = "";
            _ISNUTRIENT = "";
            _ISONLINEREQUEST = "";
            _ISPARTY = "";
            _ISPLAN = "";
            _ISSTOCKOUT = "";
            _ISSUBDIVISION = "";
            _ISWELFARE = "";
            _LOID = 0;
            _MAINDIVISION = 0;
            _MAINDIVISIONNAME = "";
            _NAME = "";
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

        public DataTable GetDataByConditions(string exceptWardList, string orderby, OracleTransaction trans)
        {
            string whText = " ISWELFARE = 'Y' AND ISSUBDIVISION = 'N' AND ACTIVE = '1' ";
            if (exceptWardList != "") whText += (whText.Trim() == "" ? "" : " AND ") + "LOID NOT IN (" + exceptWardList + ") ";

            return GetDataList(whText, orderby, trans);
        }

        #endregion

        #region SQL Statements

        /// <summary>
        /// Gets the select statement for V_DIVISION_SEARCH table.
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
        /// Returns an indication whether the record of V_DIVISION_SEARCH by specified condition is retrieved successfully.
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
                        if (!Convert.IsDBNull(zRdr["ACTIVE"])) _ACTIVE = zRdr["ACTIVE"].ToString();
                        if (!Convert.IsDBNull(zRdr["CODE"])) _CODE = zRdr["CODE"].ToString();
                        if (!Convert.IsDBNull(zRdr["DIACTIVE"])) _DIACTIVE = zRdr["DIACTIVE"].ToString();
                        if (!Convert.IsDBNull(zRdr["ISDIRECTOR"])) _ISDIRECTOR = zRdr["ISDIRECTOR"].ToString();
                        if (!Convert.IsDBNull(zRdr["ISFORMULA"])) _ISFORMULA = zRdr["ISFORMULA"].ToString();
                        if (!Convert.IsDBNull(zRdr["ISNUTRIENT"])) _ISNUTRIENT = zRdr["ISNUTRIENT"].ToString();
                        if (!Convert.IsDBNull(zRdr["ISONLINEREQUEST"])) _ISONLINEREQUEST = zRdr["ISONLINEREQUEST"].ToString();
                        if (!Convert.IsDBNull(zRdr["ISPARTY"])) _ISPARTY = zRdr["ISPARTY"].ToString();
                        if (!Convert.IsDBNull(zRdr["ISPLAN"])) _ISPLAN = zRdr["ISPLAN"].ToString();
                        if (!Convert.IsDBNull(zRdr["ISSTOCKOUT"])) _ISSTOCKOUT = zRdr["ISSTOCKOUT"].ToString();
                        if (!Convert.IsDBNull(zRdr["ISSUBDIVISION"])) _ISSUBDIVISION = zRdr["ISSUBDIVISION"].ToString();
                        if (!Convert.IsDBNull(zRdr["ISWELFARE"])) _ISWELFARE = zRdr["ISWELFARE"].ToString();
                        if (!Convert.IsDBNull(zRdr["LOID"])) _LOID = Convert.ToDouble(zRdr["LOID"]);
                        if (!Convert.IsDBNull(zRdr["MAINDIVISION"])) _MAINDIVISION = Convert.ToDouble(zRdr["MAINDIVISION"]);
                        if (!Convert.IsDBNull(zRdr["MAINDIVISIONNAME"])) _MAINDIVISIONNAME = zRdr["MAINDIVISIONNAME"].ToString();
                        if (!Convert.IsDBNull(zRdr["NAME"])) _NAME = zRdr["NAME"].ToString();
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


        public DataTable GetDataListByCondition(string cCODE, string orderBy, OracleTransaction trans)
        {
            //build where clause
            string whStr = "";

            if (cCODE.Trim() != "") whStr += (whStr.Trim() == "" ? "" : " AND ") + " UPPER(NAME)  LIKE " + DB.SetString("%" + cCODE.ToUpper() + "%") + " ";
           

            return GetDataList(whStr, orderBy, trans);
        }

        /// <summary>
        /// Returns an indication whether the record of V_DIVISION_SEARCH by specified NAME key is retrieved successfully.
        /// </summary>
        /// <param name="cNAME">The NAME key.</param>
        /// <param name="trans">The System.Data.OracleClient.OracleTransaction used by this System.Data.OracleClient.OracleCommand.</param>
        /// <returns>true if data is retrieved successfully; otherwise, false.</returns>
        public bool GetDataByNAME(string cNAME, OracleTransaction trans)
        {
            return doGetdata("NAME = " + DB.SetString(cNAME) + " ", trans);
        }



        /// <summary>
        /// Returns an indication whether the record of V_DIVISION_SEARCH by specified LOID key is retrieved successfully.
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