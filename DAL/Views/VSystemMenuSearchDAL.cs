using System;
using System.Data;
using System.Data.OracleClient;
using DB = SHND.DAL.Utilities.OracleDB;
using SHND.Data.Common.Utilities;

namespace SHND.DAL.Views
{
    /// <summary>
    /// Represents a transaction for V_SYSTEMMENUSEARCH view.
    /// [Created by 127.0.0.1 on Febuary,2 2009]
    /// </summary>
    public class VSystemMenuSearchDAL
    {

        public VSystemMenuSearchDAL()
        {
        }

        #region Constant

        /// <summary>V_SYSTEMMENUSEARCH</summary>
        private const string viewName = "V_SYSTEMMENUSEARCH";

        #endregion

        #region Private Variables

        string _error = "";
        string _information = "";
        bool _OnDB = false;
        DateTime _CREATEON = new DateTime(1, 1, 1);
        string _DESCRIPTION = "";
        string _ENABLED = "";
        string _GNAME = "";
        string _LINK = "";
        double _LOID = 0;
        double _MENUGROUP = 0;
        string _MENUNAME = "";
        double _PARENT = 0;
        double _SEQUENCE = 0;
        double _SUBMENU = 0;
        string _SYSTEMNAME = "";
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
        public DateTime CREATEON
        {
            get { return _CREATEON; }
            set { _CREATEON = value; }
        }
        public string DESCRIPTION
        {
            get { return _DESCRIPTION; }
            set { _DESCRIPTION = value; }
        }
        public string ENABLED
        {
            get { return _ENABLED; }
            set { _ENABLED = value; }
        }
        public string GNAME
        {
            get { return _GNAME; }
            set { _GNAME = value; }
        }
        public string LINK
        {
            get { return _LINK; }
            set { _LINK = value; }
        }
        public double LOID
        {
            get { return _LOID; }
            set { _LOID = value; }
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
        public double SUBMENU
        {
            get { return _SUBMENU; }
            set { _SUBMENU = value; }
        }
        public string SYSTEMNAME
        {
            get { return _SYSTEMNAME; }
            set { _SYSTEMNAME = value; }
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
            _CREATEON = new DateTime(1, 1, 1);
            _DESCRIPTION = "";
            _ENABLED = "";
            _GNAME = "";
            _LINK = "";
            _LOID = 0;
            _MENUGROUP = 0;
            _MENUNAME = "";
            _PARENT = 0;
            _SEQUENCE = 0;
            _SUBMENU = 0;
            _SYSTEMNAME = "";
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
        /// Gets the select statement for V_SYSTEMMENUSEARCH table.
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
        /// Returns an indication whether the record of V_SYSTEMMENUSEARCH by specified condition is retrieved successfully.
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
                        if (!Convert.IsDBNull(zRdr["CREATEON"])) _CREATEON = Convert.ToDateTime(zRdr["CREATEON"]);
                        if (!Convert.IsDBNull(zRdr["DESCRIPTION"])) _DESCRIPTION = zRdr["DESCRIPTION"].ToString();
                        if (!Convert.IsDBNull(zRdr["ENABLED"])) _ENABLED = zRdr["ENABLED"].ToString();
                        if (!Convert.IsDBNull(zRdr["GNAME"])) _GNAME = zRdr["GNAME"].ToString();
                        if (!Convert.IsDBNull(zRdr["LINK"])) _LINK = zRdr["LINK"].ToString();
                        if (!Convert.IsDBNull(zRdr["LOID"])) _LOID = Convert.ToDouble(zRdr["LOID"]);
                        if (!Convert.IsDBNull(zRdr["MENUGROUP"])) _MENUGROUP = Convert.ToDouble(zRdr["MENUGROUP"]);
                        if (!Convert.IsDBNull(zRdr["MENUNAME"])) _MENUNAME = zRdr["MENUNAME"].ToString();
                        if (!Convert.IsDBNull(zRdr["PARENT"])) _PARENT = Convert.ToDouble(zRdr["PARENT"]);
                        if (!Convert.IsDBNull(zRdr["SEQUENCE"])) _SEQUENCE = Convert.ToDouble(zRdr["SEQUENCE"]);
                        if (!Convert.IsDBNull(zRdr["SUBMENU"])) _SUBMENU = Convert.ToDouble(zRdr["SUBMENU"]);
                        if (!Convert.IsDBNull(zRdr["SYSTEMNAME"])) _SYSTEMNAME = zRdr["SYSTEMNAME"].ToString();
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


        public DataTable GetDataListByCondition(double cNAME,string cMENUNAME, double cGROUP, string orderBy, OracleTransaction trans)
        {
            //build where clause
            string whStr = "";
            if (cNAME != 0) whStr += (whStr.Trim() == "" ? "" : " AND ") + "  ZSYSTEM  = " + DB.SetDouble(cNAME) + " ";
            if (cGROUP != -1) whStr += (whStr.Trim() == "" ? "" : " AND ") + " MENUGROUP = " + DB.SetDouble(cGROUP) + " ";
            if (cMENUNAME.ToString() != "") whStr += (whStr.Trim() == "" ? "" : " AND ") + "   UPPER(MENUNAME)  LIKE  " + DB.SetString("%" + cMENUNAME.ToUpper() + "%") + "  ";  
            return GetDataList(whStr, orderBy, trans);
        }

        /// <summary>
        /// Returns an indication whether the record of V_SYSTEMMENU_SEARCH by specified LOID key is retrieved successfully.
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