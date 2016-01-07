using System;
using System.Data;
using System.Data.OracleClient;
using DB = SHND.DAL.Utilities.OracleDB;
using SHND.Data.Common.Utilities;

namespace SHND.DAL.Views
{
    /// <summary>
    /// Represents a transaction for V_STDMENU_NUTRIENT view.
    /// [Created by 127.0.0.1 on January,20 2009]
    /// </summary>
    public class VStdMenuNutrientDAL
    {

        public VStdMenuNutrientDAL()
        {
        }

        #region Constant

        /// <summary>V_STDMENU_NUTRIENT</summary>
        private const string viewName = "V_STDMENU_NUTRIENT";

        #endregion

        #region Private Variables

        string _error = "";
        string _information = "";
        bool _OnDB = false;
        string _MEAL = "";
        double _MENUDATE = 0;
        string _NUTRIENTNAME = "";
        double _QTY = 0;
        double _STDMENU = 0;
        string _UNITNAME = "";

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
        public string MEAL
        {
            get { return _MEAL; }
            set { _MEAL = value; }
        }
        public double MENUDATE
        {
            get { return _MENUDATE; }
            set { _MENUDATE = value; }
        }
        public string NUTRIENTNAME
        {
            get { return _NUTRIENTNAME; }
            set { _NUTRIENTNAME = value; }
        }
        public double QTY
        {
            get { return _QTY; }
            set { _QTY = value; }
        }
        public double STDMENU
        {
            get { return _STDMENU; }
            set { _STDMENU = value; }
        }
        public string UNITNAME
        {
            get { return _UNITNAME; }
            set { _UNITNAME = value; }
        }

        #endregion

        #region Clear Data

        /// <summary>
        /// Initialize data.
        /// </summary>
        private void ClearData()
        {
            _MEAL = "";
            _MENUDATE = 0;
            _NUTRIENTNAME = "";
            _QTY = 0;
            _STDMENU = 0;
            _UNITNAME = "";
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
        /// Gets the select statement for V_STDMENU_NUTRIENT table.
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
        /// Returns an indication whether the record of V_STDMENU_NUTRIENT by specified condition is retrieved successfully.
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
                            if (!Convert.IsDBNull(zRdr["MEAL"])) _MEAL = zRdr["MEAL"].ToString();
                            if (!Convert.IsDBNull(zRdr["MENUDATE"])) _MENUDATE = Convert.ToDouble(zRdr["MENUDATE"]);
                            if (!Convert.IsDBNull(zRdr["NUTRIENTNAME"])) _NUTRIENTNAME = zRdr["NUTRIENTNAME"].ToString();
                            if (!Convert.IsDBNull(zRdr["QTY"])) _QTY = Convert.ToDouble(zRdr["QTY"]);
                            if (!Convert.IsDBNull(zRdr["STDMENU"])) _STDMENU = Convert.ToDouble(zRdr["STDMENU"]);
                            if (!Convert.IsDBNull(zRdr["UNITNAME"])) _UNITNAME = zRdr["UNITNAME"].ToString();
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

        public DataTable GetDataListByCondition(double cSTDMENU, string cMEAL, double cMENUDATE, string orderBy, OracleTransaction trans)
        {
            return GetDataList("STDMENU = " + DB.SetDouble(cSTDMENU) + " AND MEAL = " + DB.SetString(cMEAL) + " AND MENUDATE = " + DB.SetDouble(cMENUDATE), orderBy, trans);
        }
    }
}