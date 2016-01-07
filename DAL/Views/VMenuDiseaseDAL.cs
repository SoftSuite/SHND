using System;
using System.Data;
using System.Data.OracleClient;
using DB = SHND.DAL.Utilities.OracleDB;
using SHND.Data.Common.Utilities;

namespace SHND.DAL.Views
{
    /// <summary>
    /// Represents a transaction for V_MENUDISEASE view.
    /// [Created by 127.0.0.1 on January,20 2009]
    /// </summary>
    public class VMenuDiseaseDAL
    {

        public VMenuDiseaseDAL()
        {
        }

        #region Constant

        /// <summary>V_MENUDISEASE</summary>
        private const string viewName = "V_MENUDISEASE";

        #endregion

        #region Private Variables

        string _error = "";
        string _information = "";
        bool _OnDB = false;
        double _DISEASECATEGORY = 0;
        string _DISEASECATEGORYNAME = "";
        string _ISHIGH = "";
        string _ISLOW = "";
        string _ISNON = "";
        double _LOID = 0;
        double _MENU = 0;

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
        public double DISEASECATEGORY
        {
            get { return _DISEASECATEGORY; }
            set { _DISEASECATEGORY = value; }
        }
        public string DISEASECATEGORYNAME
        {
            get { return _DISEASECATEGORYNAME; }
            set { _DISEASECATEGORYNAME = value; }
        }
        public string ISHIGH
        {
            get { return _ISHIGH; }
            set { _ISHIGH = value; }
        }
        public string ISLOW
        {
            get { return _ISLOW; }
            set { _ISLOW = value; }
        }
        public string ISNON
        {
            get { return _ISNON; }
            set { _ISNON = value; }
        }
        public double LOID
        {
            get { return _LOID; }
            set { _LOID = value; }
        }
        public double MENU
        {
            get { return _MENU; }
            set { _MENU = value; }
        }

        #endregion

        #region Clear Data

        /// <summary>
        /// Initialize data.
        /// </summary>
        private void ClearData()
        {
            _DISEASECATEGORY = 0;
            _DISEASECATEGORYNAME = "";
            _ISHIGH = "";
            _ISLOW = "";
            _ISNON = "";
            _LOID = 0;
            _MENU = 0;
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

        public DataTable GetDataListByMenu(double cMENU, string orderBy, OracleTransaction trans)
        {
            return GetDataList("MENU = " + DB.SetDouble(cMENU) + " ", orderBy, trans);
        }

        #endregion

        #region SQL Statements

        /// <summary>
        /// Gets the select statement for V_MENUDISEASE table.
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
        /// Returns an indication whether the record of V_MENUDISEASE by specified condition is retrieved successfully.
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
                        if (!Convert.IsDBNull(zRdr["DISEASECATEGORY"])) _DISEASECATEGORY = Convert.ToDouble(zRdr["DISEASECATEGORY"]);
                        if (!Convert.IsDBNull(zRdr["DISEASECATEGORYNAME"])) _DISEASECATEGORYNAME = zRdr["DISEASECATEGORYNAME"].ToString();
                        if (!Convert.IsDBNull(zRdr["ISHIGH"])) _ISHIGH = zRdr["ISHIGH"].ToString();
                        if (!Convert.IsDBNull(zRdr["ISLOW"])) _ISLOW = zRdr["ISLOW"].ToString();
                        if (!Convert.IsDBNull(zRdr["ISNON"])) _ISNON = zRdr["ISNON"].ToString();
                        if (!Convert.IsDBNull(zRdr["LOID"])) _LOID = Convert.ToDouble(zRdr["LOID"]);
                        if (!Convert.IsDBNull(zRdr["MENU"])) _MENU = Convert.ToDouble(zRdr["MENU"]);
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