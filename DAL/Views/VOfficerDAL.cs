using System;
using System.Data;
using System.Data.OracleClient;
using DB = SHND.DAL.Utilities.OracleDB;
using SHND.Data.Common.Utilities;

namespace SHND.DAL.Views
{
    /// <summary>
    /// Represents a transaction for V_OFFICER view.
    /// [Created by 127.0.0.1 on Febuary,3 2009]
    /// </summary>
    public class VOfficerDAL
    {

        public VOfficerDAL()
        {
        }

        #region Constant

        /// <summary>V_OFFICER</summary>
        private const string viewName = "V_OFFICER";

        #endregion

        #region Private Variables

        string _error = "";
        string _information = "";
        bool _OnDB = false;
        string _ACTIVE = "";
        string _ACTIVENAME = "";
        double _DIVISION = 0;
        string _DIVISIONNAME = "";
        string _EMAIL = "";
        string _FIRSTNAME = "";
        DateTime _LASTLOGON = new DateTime(1, 1, 1);
        string _LASTNAME = "";
        double _LOID = 0;
        string _OFFICERGROUP = "";
        string _OFFICERGROUPNAME = "";
        string _OFFICERNAME = "";
        string _PASSWD = "";
        string _TEL = "";
        double _TITLE = 0;
        string _USERNAME = "";

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
        public string ACTIVENAME
        {
            get { return _ACTIVENAME; }
            set { _ACTIVENAME = value; }
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
        public string EMAIL
        {
            get { return _EMAIL; }
            set { _EMAIL = value; }
        }
        public string FIRSTNAME
        {
            get { return _FIRSTNAME; }
            set { _FIRSTNAME = value; }
        }
        public DateTime LASTLOGON
        {
            get { return _LASTLOGON; }
            set { _LASTLOGON = value; }
        }
        public string LASTNAME
        {
            get { return _LASTNAME; }
            set { _LASTNAME = value; }
        }
        public double LOID
        {
            get { return _LOID; }
            set { _LOID = value; }
        }
        public string OFFICERGROUP
        {
            get { return _OFFICERGROUP; }
            set { _OFFICERGROUP = value; }
        }
        public string OFFICERGROUPNAME
        {
            get { return _OFFICERGROUPNAME; }
            set { _OFFICERGROUPNAME = value; }
        }
        public string OFFICERNAME
        {
            get { return _OFFICERNAME; }
            set { _OFFICERNAME = value; }
        }
        public string PASSWD
        {
            get { return _PASSWD; }
            set { _PASSWD = value; }
        }
        public string TEL
        {
            get { return _TEL; }
            set { _TEL = value; }
        }
        public double TITLE
        {
            get { return _TITLE; }
            set { _TITLE = value; }
        }
        public string USERNAME
        {
            get { return _USERNAME; }
            set { _USERNAME = value; }
        }

        #endregion

        #region Clear Data

        /// <summary>
        /// Initialize data.
        /// </summary>
        private void ClearData()
        {
            _ACTIVE = "";
            _ACTIVENAME = "";
            _DIVISION = 0;
            _DIVISIONNAME = "";
            _EMAIL = "";
            _FIRSTNAME = "";
            _LASTLOGON = new DateTime(1, 1, 1);
            _LASTNAME = "";
            _LOID = 0;
            _OFFICERGROUP = "";
            _OFFICERGROUPNAME = "";
            _OFFICERNAME = "";
            _PASSWD = "";
            _TEL = "";
            _TITLE = 0;
            _USERNAME = "";
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
        /// Gets the select statement for V_OFFICER table.
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
        /// Returns an indication whether the record of V_OFFICER by specified condition is retrieved successfully.
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
                        if (!Convert.IsDBNull(zRdr["ACTIVENAME"])) _ACTIVENAME = zRdr["ACTIVENAME"].ToString();
                        if (!Convert.IsDBNull(zRdr["DIVISION"])) _DIVISION = Convert.ToDouble(zRdr["DIVISION"]);
                        if (!Convert.IsDBNull(zRdr["DIVISIONNAME"])) _DIVISIONNAME = zRdr["DIVISIONNAME"].ToString();
                        if (!Convert.IsDBNull(zRdr["EMAIL"])) _EMAIL = zRdr["EMAIL"].ToString();
                        if (!Convert.IsDBNull(zRdr["FIRSTNAME"])) _FIRSTNAME = zRdr["FIRSTNAME"].ToString();
                        if (!Convert.IsDBNull(zRdr["LASTLOGON"])) _LASTLOGON = Convert.ToDateTime(zRdr["LASTLOGON"]);
                        if (!Convert.IsDBNull(zRdr["LASTNAME"])) _LASTNAME = zRdr["LASTNAME"].ToString();
                        if (!Convert.IsDBNull(zRdr["LOID"])) _LOID = Convert.ToDouble(zRdr["LOID"]);
                        if (!Convert.IsDBNull(zRdr["OFFICERGROUP"])) _OFFICERGROUP = zRdr["OFFICERGROUP"].ToString();
                        if (!Convert.IsDBNull(zRdr["OFFICERGROUPNAME"])) _OFFICERGROUPNAME = zRdr["OFFICERGROUPNAME"].ToString();
                        if (!Convert.IsDBNull(zRdr["OFFICERNAME"])) _OFFICERNAME = zRdr["OFFICERNAME"].ToString();
                        if (!Convert.IsDBNull(zRdr["PASSWD"])) _PASSWD = zRdr["PASSWD"].ToString();
                        if (!Convert.IsDBNull(zRdr["TEL"])) _TEL = zRdr["TEL"].ToString();
                        if (!Convert.IsDBNull(zRdr["TITLE"])) _TITLE = Convert.ToDouble(zRdr["TITLE"]);
                        if (!Convert.IsDBNull(zRdr["USERNAME"])) _USERNAME = zRdr["USERNAME"].ToString();
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

        public DataTable GetDataListByConditions(string cOFFICERNAME, double cDIVISION, string exceptionList, string orderBy, OracleTransaction trans)
        {
            string whText = "";
            if (cOFFICERNAME.Trim() != "") whText += (whText == "" ? "" : "AND ") + "UPPER(OFFICERNAME) LIKE " + DB.SetString("%" + cOFFICERNAME.Trim().ToUpper() + "%") + " ";
            if (cDIVISION != 0) whText += (whText == "" ? "" : "AND ") + "DIVISION = " + DB.SetDouble(cDIVISION) + " ";
            if (exceptionList != "") whText += (whText == "" ? "" : "AND ") + "LOID NOT IN (" + exceptionList + ") ";
            return GetDataList(whText, orderBy, trans);
        }

    }
}