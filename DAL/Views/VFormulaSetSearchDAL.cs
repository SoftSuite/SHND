using System;
using System.Data;
using System.Data.OracleClient;
using DB = SHND.DAL.Utilities.OracleDB;
using SHND.Data.Common.Utilities;
using SHND.Data.Formula;

namespace SHND.DAL.Views
{
    /// <summary>
    /// Represents a transaction for V_FORMULASET_SEARCH view.
    /// [Created by 127.0.0.1 on January,12 2009]
    /// </summary>
    public class VFormulaSetSearchDAL
    {

        public VFormulaSetSearchDAL()
        {
        }

        #region Constant

        /// <summary>V_FORMULASET_SEARCH</summary>
        private const string viewName = "V_FORMULASET_SEARCH";

        #endregion

        #region Private Variables

        string _error = "";
        string _information = "";
        bool _OnDB = false;
        string _ACTIVENAME = "";
        double _ENERGY = 0;
        double _FOODCATEGORYLOID = 0;
        string _FOODCATEGORYNAME = "";
        double _FOODTYPELOID = 0;
        string _FOODTYPENAME = "";
        string _FORMULANAME = "";
        string _ISELEMENT = "";
        string _ISSPECIFIC = "";
        double _LOID = 0;
        double _PORTION = 0;
        string _SPECIALTYPE = "";
        string _STATUS = "";
        string _STATUSNAME = "";
        string _STATUSRANK = "";
        double _WEIGHT = 0;
        string _DIVISIONNAME = "";

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
        public string ACTIVENAME
        {
            get { return _ACTIVENAME; }
            set { _ACTIVENAME = value; }
        }
        public double ENERGY
        {
            get { return _ENERGY; }
            set { _ENERGY = value; }
        }
        public double FOODCATEGORYLOID
        {
            get { return _FOODCATEGORYLOID; }
            set { _FOODCATEGORYLOID = value; }
        }
        public string FOODCATEGORYNAME
        {
            get { return _FOODCATEGORYNAME; }
            set { _FOODCATEGORYNAME = value; }
        }
        public double FOODTYPELOID
        {
            get { return _FOODTYPELOID; }
            set { _FOODTYPELOID = value; }
        }
        public string FOODTYPENAME
        {
            get { return _FOODTYPENAME; }
            set { _FOODTYPENAME = value; }
        }
        public string FORMULANAME
        {
            get { return _FORMULANAME; }
            set { _FORMULANAME = value; }
        }
        public string ISELEMENT
        {
            get { return _ISELEMENT; }
            set { _ISELEMENT = value; }
        }
        public string ISSPECIFIC
        {
            get { return _ISSPECIFIC; }
            set { _ISSPECIFIC = value; }
        }
        public double LOID
        {
            get { return _LOID; }
            set { _LOID = value; }
        }
        public double PORTION
        {
            get { return _PORTION; }
            set { _PORTION = value; }
        }
        public string SPECIALTYPE
        {
            get { return _SPECIALTYPE; }
            set { _SPECIALTYPE = value; }
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
        public double WEIGHT
        {
            get { return _WEIGHT; }
            set { _WEIGHT = value; }
        }

        public string DIVISIONNAME
        {
            get { return _DIVISIONNAME; }
            set { _DIVISIONNAME = value; }
        }
        #endregion

        #region Clear Data

        /// <summary>
        /// Initialize data.
        /// </summary>
        private void ClearData()
        {
            _ACTIVENAME = "";
            _ENERGY = 0;
            _FOODCATEGORYLOID = 0;
            _FOODCATEGORYNAME = "";
            _FOODTYPELOID = 0;
            _FOODTYPENAME = "";
            _FORMULANAME = "";
            _ISELEMENT = "";
            _ISSPECIFIC = "";
            _LOID = 0;
            _PORTION = 0;
            _SPECIALTYPE = "";
            _STATUS = "";
            _STATUSNAME = "";
            _STATUSRANK = "";
            _WEIGHT = 0;
            _DIVISIONNAME = "";
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
        /// Gets the select statement for V_FORMULASET_SEARCH table.
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
        /// Returns an indication whether the record of V_FORMULASET_SEARCH by specified condition is retrieved successfully.
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
                            if (!Convert.IsDBNull(zRdr["ACTIVENAME"])) _ACTIVENAME = zRdr["ACTIVENAME"].ToString();
                            if (!Convert.IsDBNull(zRdr["ENERGY"])) _ENERGY = Convert.ToDouble(zRdr["ENERGY"]);
                            if (!Convert.IsDBNull(zRdr["FOODCATEGORYLOID"])) _FOODCATEGORYLOID = Convert.ToDouble(zRdr["FOODCATEGORYLOID"]);
                            if (!Convert.IsDBNull(zRdr["FOODCATEGORYNAME"])) _FOODCATEGORYNAME = zRdr["FOODCATEGORYNAME"].ToString();
                            if (!Convert.IsDBNull(zRdr["FOODTYPELOID"])) _FOODTYPELOID = Convert.ToDouble(zRdr["FOODTYPELOID"]);
                            if (!Convert.IsDBNull(zRdr["FOODTYPENAME"])) _FOODTYPENAME = zRdr["FOODTYPENAME"].ToString();
                            if (!Convert.IsDBNull(zRdr["FORMULANAME"])) _FORMULANAME = zRdr["FORMULANAME"].ToString();
                            if (!Convert.IsDBNull(zRdr["ISELEMENT"])) _ISELEMENT = zRdr["ISELEMENT"].ToString();
                            if (!Convert.IsDBNull(zRdr["ISSPECIFIC"])) _ISSPECIFIC = zRdr["ISSPECIFIC"].ToString();
                            if (!Convert.IsDBNull(zRdr["LOID"])) _LOID = Convert.ToDouble(zRdr["LOID"]);
                            if (!Convert.IsDBNull(zRdr["PORTION"])) _PORTION = Convert.ToDouble(zRdr["PORTION"]);
                            if (!Convert.IsDBNull(zRdr["SPECIALTYPE"])) _SPECIALTYPE = zRdr["SPECIALTYPE"].ToString();
                            if (!Convert.IsDBNull(zRdr["STATUS"])) _STATUS = zRdr["STATUS"].ToString();
                            if (!Convert.IsDBNull(zRdr["STATUSNAME"])) _STATUSNAME = zRdr["STATUSNAME"].ToString();
                            if (!Convert.IsDBNull(zRdr["STATUSRANK"])) _STATUSRANK = zRdr["STATUSRANK"].ToString();
                            if (!Convert.IsDBNull(zRdr["WEIGHT"])) _WEIGHT = Convert.ToDouble(zRdr["WEIGHT"]);
                            if (!Convert.IsDBNull(zRdr["DIVISIONNAME"])) _DIVISIONNAME = zRdr["DIVISIONNAME"].ToString();
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

        public DataTable GetDataListByCondition(FormulaSetSearchData condition, string orderBy, OracleTransaction trans)
        {
            //build where clause
            string whStr = "";
            if (condition.DIVISION != 0) whStr += (whStr.Trim() == "" ? "" : " AND ") + "DIVISION = " + DB.SetDouble(condition.DIVISION) + " ";
            if (condition.FoodCategory != 0) whStr += (whStr.Trim() == "" ? "" : " AND ") + "FOODCATEGORYLOID = " + DB.SetDouble(condition.FoodCategory) + " ";
            if (condition.FoodType != 0) whStr += (whStr.Trim() == "" ? "" : " AND ") + "FOODTYPELOID = " + DB.SetDouble(condition.FoodType) + " ";
            if (condition.FormulaSetName.Trim() != "") whStr += (whStr.Trim() == "" ? "" : " AND ") + " UPPER(FORMULANAME) LIKE " + DB.SetString("%" + condition.FormulaSetName.ToUpper() + "%") + " ";
            if (condition.IsSpecific.Trim() != "") whStr += (whStr.Trim() == "" ? "" : " AND ") + " ISSPECIFIC = " + DB.SetString(condition.IsSpecific) + " ";
            if (condition.Active.Trim() != "") whStr += (whStr.Trim() == "" ? "" : " AND ") + " ACTIVE = " + DB.SetString(condition.Active) + " ";
            if (condition.StatusRankFrom.Trim() != "") whStr += (whStr.Trim() == "" ? "" : " AND ") + " STATUSRANK >= " + DB.SetString(condition.StatusRankFrom) + " ";
            if (condition.StatusRankTo.Trim() != "") whStr += (whStr.Trim() == "" ? "" : " AND ") + " STATUSRANK <= " + DB.SetString(condition.StatusRankTo) + " ";

            return GetDataList(whStr, orderBy, trans);
        }

        public DataTable GetDataListByCondition(double cREFFORMULASET, double cFOODTYPE, double cFOODCATEGORY, string cNAME, string cISELEMENT, string cSTATUS, string exceptKeyList, string orderBy, OracleTransaction trans)
        {
            //build where clause
            string whStr = "";

            if (cREFFORMULASET != 0) whStr += (whStr.Trim() == "" ? "" : " AND ") + "NVL(FN_GETFORMULADISEASE(LOID, 'SET'),'-') = NVL(FN_GETFORMULADISEASE(" + DB.SetDouble(cREFFORMULASET) + ", 'SET'),'-') ";
            if (cFOODCATEGORY != 0) whStr += (whStr.Trim() == "" ? "" : " AND ") + "FOODCATEGORYLOID = " + DB.SetDouble(cFOODCATEGORY) + " ";
            if (cFOODTYPE != 0) whStr += (whStr.Trim() == "" ? "" : " AND ") + "FOODTYPELOID = " + DB.SetDouble(cFOODTYPE) + " ";
            if (cNAME.Trim() != "") whStr += (whStr.Trim() == "" ? "" : " AND ") + " UPPER(FORMULANAME) LIKE " + DB.SetString("%" + cNAME.ToUpper() + "%") + " ";
            if (cISELEMENT.Trim() != "") whStr += (whStr.Trim() == "" ? "" : " AND ") + " ISELEMENT = " + DB.SetString(cISELEMENT) + " ";
            //if (cActive.Trim() != "") whStr += (whStr.Trim() == "" ? "" : " AND ") + " ACTIVE = " + DB.SetString(cActive) + " ";
            if (cSTATUS.Trim() != "") whStr += (whStr.Trim() == "" ? "" : " AND ") + " STATUS = " + DB.SetString(cSTATUS) + " ";
            if (exceptKeyList != "") whStr += (whStr.Trim() == "" ? "" : " AND ") + "LOID NOT IN (" + exceptKeyList + ") ";

            return GetDataList(whStr, orderBy, trans);
        }

        #region Work Nang

        private string sql_division
        {
            get
            {
                string sql = "SELECT DIVISION FROM " + viewName + " ";
                return sql;
            }
        }

        public double GetDivision(string whereClause, string orderBy, OracleTransaction trans)
        {
            DataTable dt = new DataTable();
            dt = DB.ExecuteTable(sql_division + (whereClause == "" ? "" : "WHERE " + whereClause + " ") + (orderBy == "" ? "" : "ORDER BY " + DB.SetSortString(orderBy)), trans);
            if(dt.Rows.Count > 0)
                return Convert.ToDouble(DB.ExecuteScalar(sql_division + (whereClause == "" ? "" : "WHERE " + whereClause + " ") + (orderBy == "" ? "" : "ORDER BY " + DB.SetSortString(orderBy)), trans));
            else
                return Convert.ToDouble("0");
        }
        #endregion
    }
}