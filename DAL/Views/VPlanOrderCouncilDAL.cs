using System;
using System.Data;
using System.Data.OracleClient;
using DB = SHND.DAL.Utilities.OracleDB;
using SHND.Data.Common.Utilities;

namespace SHND.DAL.Views
{
    /// <summary>
    /// Represents a transaction for V_PLANORDERCOUNCIL view.
    /// [Created by 127.0.0.1 on Febuary,3 2009]
    /// </summary>
    public class VPlanOrderCouncilDAL
    {

        public VPlanOrderCouncilDAL()
        {
        }

        #region Constant

        /// <summary>V_PLANORDERCOUNCIL</summary>
        private const string viewName = "V_PLANORDERCOUNCIL";

        #endregion

        #region Private Variables

        string _error = "";
        string _information = "";
        bool _OnDB = false;
        double _DIVISION = 0;
        string _DIVISIONNAME = "";
        double _LOID = 0;
        string _M1 = "";
        string _M10 = "";
        string _M11 = "";
        string _M12 = "";
        string _M2 = "";
        string _M3 = "";
        string _M4 = "";
        string _M5 = "";
        string _M6 = "";
        string _M7 = "";
        string _M8 = "";
        string _M9 = "";
        double _OFFICER = 0;
        string _OFFICERNAME = "";
        double _PLANORDER = 0;
        string _POSITION = "";

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
        public string M1
        {
            get { return _M1; }
            set { _M1 = value; }
        }
        public string M10
        {
            get { return _M10; }
            set { _M10 = value; }
        }
        public string M11
        {
            get { return _M11; }
            set { _M11 = value; }
        }
        public string M12
        {
            get { return _M12; }
            set { _M12 = value; }
        }
        public string M2
        {
            get { return _M2; }
            set { _M2 = value; }
        }
        public string M3
        {
            get { return _M3; }
            set { _M3 = value; }
        }
        public string M4
        {
            get { return _M4; }
            set { _M4 = value; }
        }
        public string M5
        {
            get { return _M5; }
            set { _M5 = value; }
        }
        public string M6
        {
            get { return _M6; }
            set { _M6 = value; }
        }
        public string M7
        {
            get { return _M7; }
            set { _M7 = value; }
        }
        public string M8
        {
            get { return _M8; }
            set { _M8 = value; }
        }
        public string M9
        {
            get { return _M9; }
            set { _M9 = value; }
        }
        public double OFFICER
        {
            get { return _OFFICER; }
            set { _OFFICER = value; }
        }
        public string OFFICERNAME
        {
            get { return _OFFICERNAME; }
            set { _OFFICERNAME = value; }
        }
        public double PLANORDER
        {
            get { return _PLANORDER; }
            set { _PLANORDER = value; }
        }
        public string POSITION
        {
            get { return _POSITION; }
            set { _POSITION = value; }
        }

        #endregion

        #region Clear Data

        /// <summary>
        /// Initialize data.
        /// </summary>
        private void ClearData()
        {
            _DIVISION = 0;
            _DIVISIONNAME = "";
            _LOID = 0;
            _M1 = "";
            _M10 = "";
            _M11 = "";
            _M12 = "";
            _M2 = "";
            _M3 = "";
            _M4 = "";
            _M5 = "";
            _M6 = "";
            _M7 = "";
            _M8 = "";
            _M9 = "";
            _OFFICER = 0;
            _OFFICERNAME = "";
            _PLANORDER = 0;
            _POSITION = "";
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
        /// Gets the select statement for V_PLANORDERCOUNCIL table.
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
        /// Returns an indication whether the record of V_PLANORDERCOUNCIL by specified condition is retrieved successfully.
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
                        if (!Convert.IsDBNull(zRdr["DIVISION"])) _DIVISION = Convert.ToDouble(zRdr["DIVISION"]);
                        if (!Convert.IsDBNull(zRdr["DIVISIONNAME"])) _DIVISIONNAME = zRdr["DIVISIONNAME"].ToString();
                        if (!Convert.IsDBNull(zRdr["LOID"])) _LOID = Convert.ToDouble(zRdr["LOID"]);
                        if (!Convert.IsDBNull(zRdr["M1"])) _M1 = zRdr["M1"].ToString();
                        if (!Convert.IsDBNull(zRdr["M10"])) _M10 = zRdr["M10"].ToString();
                        if (!Convert.IsDBNull(zRdr["M11"])) _M11 = zRdr["M11"].ToString();
                        if (!Convert.IsDBNull(zRdr["M12"])) _M12 = zRdr["M12"].ToString();
                        if (!Convert.IsDBNull(zRdr["M2"])) _M2 = zRdr["M2"].ToString();
                        if (!Convert.IsDBNull(zRdr["M3"])) _M3 = zRdr["M3"].ToString();
                        if (!Convert.IsDBNull(zRdr["M4"])) _M4 = zRdr["M4"].ToString();
                        if (!Convert.IsDBNull(zRdr["M5"])) _M5 = zRdr["M5"].ToString();
                        if (!Convert.IsDBNull(zRdr["M6"])) _M6 = zRdr["M6"].ToString();
                        if (!Convert.IsDBNull(zRdr["M7"])) _M7 = zRdr["M7"].ToString();
                        if (!Convert.IsDBNull(zRdr["M8"])) _M8 = zRdr["M8"].ToString();
                        if (!Convert.IsDBNull(zRdr["M9"])) _M9 = zRdr["M9"].ToString();
                        if (!Convert.IsDBNull(zRdr["OFFICER"])) _OFFICER = Convert.ToDouble(zRdr["OFFICER"]);
                        if (!Convert.IsDBNull(zRdr["OFFICERNAME"])) _OFFICERNAME = zRdr["OFFICERNAME"].ToString();
                        if (!Convert.IsDBNull(zRdr["PLANORDER"])) _PLANORDER = Convert.ToDouble(zRdr["PLANORDER"]);
                        if (!Convert.IsDBNull(zRdr["POSITION"])) _POSITION = zRdr["POSITION"].ToString();
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

        public DataTable GetDataListByPlanOrder(double cPLANORDER, string orderBy, OracleTransaction trans)
        {
            return GetDataList("PLANORDER = " + DB.SetDouble(cPLANORDER), orderBy, trans);
        }
    }
}