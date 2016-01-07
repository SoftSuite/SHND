using System;
using System.Data;
using System.Data.OracleClient;
using DB = SHND.DAL.Utilities.OracleDB;
using SHND.Data.Common.Utilities;

namespace SHND.DAL.Views
{
    /// <summary>
    /// Represents a transaction for V_ZMENU_ROLE view.
    /// [Created by 127.0.0.1 on Febuary,3 2009]
    /// </summary>
    public class VZMenuRoleDAL
    {

        public VZMenuRoleDAL()
        {
        }

        #region Constant

        /// <summary>V_ZMENU_ROLE</summary>
        private const string viewName = "V_ZMENU_ROLE";

        #endregion

        #region Private Variables

        string _error = "";
        string _information = "";
        bool _OnDB = false;
        string _ENABLED = "";
        string _IMAGE = "";
        string _LINK = "";
        double _MENUGROUP = 0;
        string _MENUNAME = "";
        double _OFFICER = 0;
        double _PARENT = 0;
        double _SEQUENCE = 0;
        string _ZLEVEL = "";
        double _ZMENU = 0;
        double _ZROLE = 0;
        double _ZSYSTEM = 0;

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
        public string ENABLED
        {
            get { return _ENABLED; }
            set { _ENABLED = value; }
        }
        public string IMAGE
        {
            get { return _IMAGE; }
            set { _IMAGE = value; }
        }
        public string LINK
        {
            get { return _LINK; }
            set { _LINK = value; }
        }
        public double MENUGROUP
        {
            get { return _MENUGROUP; }
            set { _MENUGROUP = value; }
        }
        public string MENUNAME
        {
            get { return _MENUNAME; }
            set { _MENUNAME = value; }
        }
        public double OFFICER
        {
            get { return _OFFICER; }
            set { _OFFICER = value; }
        }
        public double PARENT
        {
            get { return _PARENT; }
            set { _PARENT = value; }
        }
        public double SEQUENCE
        {
            get { return _SEQUENCE; }
            set { _SEQUENCE = value; }
        }
        public string ZLEVEL
        {
            get { return _ZLEVEL; }
            set { _ZLEVEL = value; }
        }
        public double ZMENU
        {
            get { return _ZMENU; }
            set { _ZMENU = value; }
        }
        public double ZROLE
        {
            get { return _ZROLE; }
            set { _ZROLE = value; }
        }
        public double ZSYSTEM
        {
            get { return _ZSYSTEM; }
            set { _ZSYSTEM = value; }
        }

        #endregion

        #region Clear Data

        /// <summary>
        /// Initialize data.
        /// </summary>
        private void ClearData()
        {
            _ENABLED = "";
            _IMAGE = "";
            _LINK = "";
            _MENUGROUP = 0;
            _MENUNAME = "";
            _OFFICER = 0;
            _PARENT = 0;
            _SEQUENCE = 0;
            _ZLEVEL = "";
            _ZMENU = 0;
            _ZROLE = 0;
            _ZSYSTEM = 0;
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
        /// Gets the select statement for V_ZMENU_ROLE table.
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
        /// Returns an indication whether the record of V_ZMENU_ROLE by specified condition is retrieved successfully.
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
                        if (!Convert.IsDBNull(zRdr["ENABLED"])) _ENABLED = zRdr["ENABLED"].ToString();
                        if (!Convert.IsDBNull(zRdr["IMAGE"])) _IMAGE = zRdr["IMAGE"].ToString();
                        if (!Convert.IsDBNull(zRdr["LINK"])) _LINK = zRdr["LINK"].ToString();
                        if (!Convert.IsDBNull(zRdr["MENUGROUP"])) _MENUGROUP = Convert.ToDouble(zRdr["MENUGROUP"]);
                        if (!Convert.IsDBNull(zRdr["MENUNAME"])) _MENUNAME = zRdr["MENUNAME"].ToString();
                        if (!Convert.IsDBNull(zRdr["OFFICER"])) _OFFICER = Convert.ToDouble(zRdr["OFFICER"]);
                        if (!Convert.IsDBNull(zRdr["PARENT"])) _PARENT = Convert.ToDouble(zRdr["PARENT"]);
                        if (!Convert.IsDBNull(zRdr["SEQUENCE"])) _SEQUENCE = Convert.ToDouble(zRdr["SEQUENCE"]);
                        if (!Convert.IsDBNull(zRdr["ZLEVEL"])) _ZLEVEL = zRdr["ZLEVEL"].ToString();
                        if (!Convert.IsDBNull(zRdr["ZMENU"])) _ZMENU = Convert.ToDouble(zRdr["ZMENU"]);
                        if (!Convert.IsDBNull(zRdr["ZROLE"])) _ZROLE = Convert.ToDouble(zRdr["ZROLE"]);
                        if (!Convert.IsDBNull(zRdr["ZSYSTEM"])) _ZSYSTEM = Convert.ToDouble(zRdr["ZSYSTEM"]);
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