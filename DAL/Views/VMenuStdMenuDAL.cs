using System;
using System.Data;
using System.Data.OracleClient;
using DB = SHND.DAL.Utilities.OracleDB;
using SHND.Data.Common.Utilities;

namespace SHND.DAL.Views
{
    /// <summary>
    /// Represents a transaction for V_MENU_STDMENU view.
    /// [Created by 127.0.0.1 on June,24 2009]
    /// </summary>
    public class VMenuStdMenuDAL
    {

        public VMenuStdMenuDAL()
        {
        }

        #region Constant

        /// <summary>V_MENU_STDMENU</summary>
        private const string viewName = "V_MENU_STDMENU";

        #endregion

        #region Private Variables

        string _error = "";
        string _information = "";
        bool _OnDB = false;
        double _BMONTH = 0;
        double _BYEAR = 0;
        double _MENU = 0;
        string _MENUSOURCE = "";
        double _MMONTH = 0;
        string _MONTHYEAR = "";
        double _MYEAR = 0;
        double _PATIENTQTY = 0;
        string _PATIENTSOURCE = "";
        double _STDMENU = 0;

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
        public double BMONTH
        {
            get { return _BMONTH; }
            set { _BMONTH = value; }
        }
        public double BYEAR
        {
            get { return _BYEAR; }
            set { _BYEAR = value; }
        }
        public double MENU
        {
            get { return _MENU; }
            set { _MENU = value; }
        }
        public string MENUSOURCE
        {
            get { return _MENUSOURCE; }
            set { _MENUSOURCE = value; }
        }
        public double MMONTH
        {
            get { return _MMONTH; }
            set { _MMONTH = value; }
        }
        public string MONTHYEAR
        {
            get { return _MONTHYEAR; }
            set { _MONTHYEAR = value; }
        }
        public double MYEAR
        {
            get { return _MYEAR; }
            set { _MYEAR = value; }
        }
        public double PATIENTQTY
        {
            get { return _PATIENTQTY; }
            set { _PATIENTQTY = value; }
        }
        public string PATIENTSOURCE
        {
            get { return _PATIENTSOURCE; }
            set { _PATIENTSOURCE = value; }
        }
        public double STDMENU
        {
            get { return _STDMENU; }
            set { _STDMENU = value; }
        }

        #endregion

        #region Clear Data

        /// <summary>
        /// Initialize data.
        /// </summary>
        private void ClearData()
        {
            _BMONTH = 0;
            _BYEAR = 0;
            _MENU = 0;
            _MENUSOURCE = "";
            _MMONTH = 0;
            _MONTHYEAR = "";
            _MYEAR = 0;
            _PATIENTQTY = 0;
            _PATIENTSOURCE = "";
            _STDMENU = 0;
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
        /// Gets the select statement for V_MENU_STDMENU table.
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
        /// Returns an indication whether the record of V_MENU_STDMENU by specified condition is retrieved successfully.
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
                        if (!Convert.IsDBNull(zRdr["BMONTH"])) _BMONTH = Convert.ToDouble(zRdr["BMONTH"]);
                        if (!Convert.IsDBNull(zRdr["BYEAR"])) _BYEAR = Convert.ToDouble(zRdr["BYEAR"]);
                        if (!Convert.IsDBNull(zRdr["MENU"])) _MENU = Convert.ToDouble(zRdr["MENU"]);
                        if (!Convert.IsDBNull(zRdr["MENUSOURCE"])) _MENUSOURCE = zRdr["MENUSOURCE"].ToString();
                        if (!Convert.IsDBNull(zRdr["MMONTH"])) _MMONTH = Convert.ToDouble(zRdr["MMONTH"]);
                        if (!Convert.IsDBNull(zRdr["MONTHYEAR"])) _MONTHYEAR = zRdr["MONTHYEAR"].ToString();
                        if (!Convert.IsDBNull(zRdr["MYEAR"])) _MYEAR = Convert.ToDouble(zRdr["MYEAR"]);
                        if (!Convert.IsDBNull(zRdr["PATIENTQTY"])) _PATIENTQTY = Convert.ToDouble(zRdr["PATIENTQTY"]);
                        if (!Convert.IsDBNull(zRdr["PATIENTSOURCE"])) _PATIENTSOURCE = zRdr["PATIENTSOURCE"].ToString();
                        if (!Convert.IsDBNull(zRdr["STDMENU"])) _STDMENU = Convert.ToDouble(zRdr["STDMENU"]);
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