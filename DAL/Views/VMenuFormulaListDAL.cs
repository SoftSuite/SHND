using System;
using System.Data;
using System.Data.OracleClient;
using DB = SHND.DAL.Utilities.OracleDB;
using SHND.Data.Common.Utilities;

namespace SHND.DAL.Views
{
    /// <summary>
    /// Represents a transaction for V_MENU_FORMULA_LIST view.
    /// [Created by ::1 on July,9 2009]
    /// </summary>
    public class VMenuFormulaListDAL
    {

        public VMenuFormulaListDAL()
        {
        }

        #region Constant

        /// <summary>V_MENU_FORMULA_LIST</summary>
        private const string viewName = "V_MENU_FORMULA_LIST";

        #endregion

        #region Private Variables

        string _error = "";
        string _information = "";
        bool _OnDB = false;
        string _FORMULANAME = "";
        string _GROUPNAME = "";
        string _GROUPORDER = "";
        string _GROUPTYPE = "";
        string _MEAL = "";
        string _MEALNAME = "";
        double _MENU = 0;
        DateTime _MENUDATE = new DateTime(1, 1, 1);
        string _REFTYPE = "";

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
        public string FORMULANAME
        {
            get { return _FORMULANAME; }
            set { _FORMULANAME = value; }
        }
        public string GROUPNAME
        {
            get { return _GROUPNAME; }
            set { _GROUPNAME = value; }
        }
        public string GROUPORDER
        {
            get { return _GROUPORDER; }
            set { _GROUPORDER = value; }
        }
        public string GROUPTYPE
        {
            get { return _GROUPTYPE; }
            set { _GROUPTYPE = value; }
        }
        public string MEAL
        {
            get { return _MEAL; }
            set { _MEAL = value; }
        }
        public string MEALNAME
        {
            get { return _MEALNAME; }
            set { _MEALNAME = value; }
        }
        public double MENU
        {
            get { return _MENU; }
            set { _MENU = value; }
        }
        public DateTime MENUDATE
        {
            get { return _MENUDATE; }
            set { _MENUDATE = value; }
        }
        public string REFTYPE
        {
            get { return _REFTYPE; }
            set { _REFTYPE = value; }
        }

        #endregion

        #region Clear Data

        /// <summary>
        /// Initialize data.
        /// </summary>
        private void ClearData()
        {
            _FORMULANAME = "";
            _GROUPNAME = "";
            _GROUPORDER = "";
            _GROUPTYPE = "";
            _MEAL = "";
            _MEALNAME = "";
            _MENU = 0;
            _MENUDATE = new DateTime(1, 1, 1);
            _REFTYPE = "";
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
        /// Gets the select statement for V_MENU_FORMULA_LIST table.
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
        /// Returns an indication whether the record of V_MENU_FORMULA_LIST by specified condition is retrieved successfully.
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
                        if (!Convert.IsDBNull(zRdr["FORMULANAME"])) _FORMULANAME = zRdr["FORMULANAME"].ToString();
                        if (!Convert.IsDBNull(zRdr["GROUPNAME"])) _GROUPNAME = zRdr["GROUPNAME"].ToString();
                        if (!Convert.IsDBNull(zRdr["GROUPORDER"])) _GROUPORDER = zRdr["GROUPORDER"].ToString();
                        if (!Convert.IsDBNull(zRdr["GROUPTYPE"])) _GROUPTYPE = zRdr["GROUPTYPE"].ToString();
                        if (!Convert.IsDBNull(zRdr["MEAL"])) _MEAL = zRdr["MEAL"].ToString();
                        if (!Convert.IsDBNull(zRdr["MEALNAME"])) _MEALNAME = zRdr["MEALNAME"].ToString();
                        if (!Convert.IsDBNull(zRdr["MENU"])) _MENU = Convert.ToDouble(zRdr["MENU"]);
                        if (!Convert.IsDBNull(zRdr["MENUDATE"])) _MENUDATE = Convert.ToDateTime(zRdr["MENUDATE"]);
                        if (!Convert.IsDBNull(zRdr["REFTYPE"])) _REFTYPE = zRdr["REFTYPE"].ToString();
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


        #region My work Nang

        private string sql_rank
        {
            get
            {
                string sql = "SELECT CASE WHEN RANK() OVER(PARTITION BY MENUDATE ORDER BY MENUDATE,MEALNAME) = 1 THEN 1 ELSE 0 END RANK, A.* FROM " + viewName + " A ";
                return sql;
            }
        }

        public DataTable GetRankDataList(string whereClause, string orderBy, OracleTransaction trans)
        {
            DataTable dt = DB.ExecuteTable(sql_rank + (whereClause == "" ? "" : "WHERE " + whereClause + " ") + (orderBy == "" ? "" : "ORDER BY " + DB.SetSortString(orderBy)), trans);
            int index = 1;
            for (int i = 0; i < dt.Rows.Count; ++i)
            {
                if (Convert.ToDouble(dt.Rows[i]["RANK"]) == 1)
                {
                    dt.Rows[i]["RANK"] = index;
                    ++index;
                }
            }
            return dt;
        }

        public DataTable GetDataListByCondition (double menuloid, DateTime cDATEFROM, DateTime cDATETO, double cMEAL, string cGROUP, string cNAME, string orderBy, OracleTransaction trans)
        { 
            string whText = "MENU = " + DB.SetDouble(menuloid) + " ";

            if (cMEAL != 0) whText += (whText == "" ? "" : "AND ") + "MEAL = " + DB.SetDouble(cMEAL) + " ";
            if (cGROUP.Trim() != "0") whText += (whText == "" ? "" : "AND ") + "GROUPTYPE = " + DB.SetString(cGROUP) + " ";
            if (cNAME.Trim() != "") whText += (whText == "" ? "" : "AND ") + " UPPER(FORMULANAME) LIKE UPPER('%" + cNAME.Trim() + "%') ";

            if (cDATEFROM.Year != 1) whText += (whText == "" ? "" : "AND ") + "(MENUDATE >= " + DB.SetDateTime(cDATEFROM) + " OR MENUDATE >=" + DB.SetDateTime(cDATEFROM) + ") ";
            if (cDATETO.Year != 1) whText += (whText == "" ? "" : "AND ") + "(MENUDATE <= " + DB.SetDateTime(cDATETO) + " OR MENUDATE <=" + DB.SetDateTime(cDATETO) + ") ";

            return GetRankDataList(whText, orderBy, trans);
        }

        #endregion
    }
}