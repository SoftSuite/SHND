using System;
using System.Data;
using System.Data.OracleClient;
using DB = SHND.DAL.Utilities.OracleDB;
using SHND.Data.Common.Utilities;

namespace SHND.DAL.Tables
{
    /// <summary>
    /// Represents a transaction for V_MATERIALCLASS view.
    /// [Created by 127.0.0.1 on January,22 2009]
    /// </summary>
    public class VMaterialClassDAL
    {

        public VMaterialClassDAL()
        {
        }

        #region Constant

        /// <summary>V_MATERIALCLASS</summary>
        private const string viewName = "V_MATERIALCLASS";

        #endregion

        #region Private Variables

        string _error = "";
        string _information = "";
        bool _OnDB = false;
        string _ACTIVE = "";
        string _ACTIVENAME = "";
        string _CODE = "";
        double _LOID = 0;
        string _MASTERTYPE = "";
        string _MASTERTYPENAME = "";
        string _NAME = "";
        string _STOCKINTYPE = "";
        string _STOCKINTYPENAME = "";

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
        public string CODE
        {
            get { return _CODE; }
            set { _CODE = value; }
        }
        public double LOID
        {
            get { return _LOID; }
            set { _LOID = value; }
        }
        public string MASTERTYPE
        {
            get { return _MASTERTYPE; }
            set { _MASTERTYPE = value; }
        }
        public string MASTERTYPENAME
        {
            get { return _MASTERTYPENAME; }
            set { _MASTERTYPENAME = value; }
        }
        public string NAME
        {
            get { return _NAME; }
            set { _NAME = value; }
        }
        public string STOCKINTYPE
        {
            get { return _STOCKINTYPE; }
            set { _STOCKINTYPE = value; }
        }
        public string STOCKINTYPENAME
        {
            get { return _STOCKINTYPENAME; }
            set { _STOCKINTYPENAME = value; }
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
            _CODE = "";
            _LOID = 0;
            _MASTERTYPE = "";
            _MASTERTYPENAME = "";
            _NAME = "";
            _STOCKINTYPE = "";
            _STOCKINTYPENAME = "";
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

        /// <summary>
        /// Returns an indication whether the record of MATERIALCLASS by specified LOID key is retrieved successfully.
        /// </summary>
        /// <param name="cLOID">The LOID key.</param>
        /// <param name="trans">The System.Data.OracleClient.OracleTransaction used by this System.Data.OracleClient.OracleCommand.</param>
        /// <returns>true if data is retrieved successfully; otherwise, false.</returns>
        public bool GetDataByLOID(double cLOID, OracleTransaction trans)
        {
            return doGetdata("LOID = " + DB.SetDouble(cLOID) + " ", trans);
        }

        /// <summary>
        /// Returns an indication whether the record of MATERIALCLASS by specified NAME key is retrieved successfully.
        /// </summary>
        /// <param name="cNAME">The NAME key.</param>
        /// <param name="trans">The System.Data.OracleClient.OracleTransaction used by this System.Data.OracleClient.OracleCommand.</param>
        /// <returns>true if data is retrieved successfully; otherwise, false.</returns>
        public bool GetDataByNAME(string cNAME, OracleTransaction trans)
        {
            return doGetdata("NAME = " + DB.SetString(cNAME) + " ", trans);
        }

        /// <summary>
        /// Returns an indication whether the current data is inserted into MATERIALCLASS table successfully.
        /// </summary>
        /// <param name="userID">The current user.</param>
        /// <param name="trans">The System.Data.OracleClient.OracleTransaction used by this System.Data.OracleClient.OracleCommand.</param>
        /// <returns>true if insert data successfully; otherwise, false.</returns>
       
        #endregion

        #region SQL Statements

        /// <summary>
        /// Gets the select statement for V_MATERIALCLASS table.
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
        /// Returns an indication whether the record of V_MATERIALCLASS by specified condition is retrieved successfully.
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
                        if (!Convert.IsDBNull(zRdr["CODE"])) _CODE = zRdr["CODE"].ToString();
                        if (!Convert.IsDBNull(zRdr["LOID"])) _LOID = Convert.ToDouble(zRdr["LOID"]);
                        if (!Convert.IsDBNull(zRdr["MASTERTYPE"])) _MASTERTYPE = zRdr["MASTERTYPE"].ToString();
                        if (!Convert.IsDBNull(zRdr["MASTERTYPENAME"])) _MASTERTYPENAME = zRdr["MASTERTYPENAME"].ToString();
                        if (!Convert.IsDBNull(zRdr["NAME"])) _NAME = zRdr["NAME"].ToString();
                        if (!Convert.IsDBNull(zRdr["STOCKINTYPE"])) _STOCKINTYPE = zRdr["STOCKINTYPE"].ToString();
                        if (!Convert.IsDBNull(zRdr["STOCKINTYPENAME"])) _STOCKINTYPENAME = zRdr["STOCKINTYPENAME"].ToString();
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



        public DataTable GetDataListByCondition(string cCODE,string orderBy,OracleTransaction trans)
        {
            //build where clause
            string whStr = "";

            if (cCODE.Trim() != "") whStr += (whStr.Trim() == "" ? "" : " AND ") + " UPPER(NAME)  LIKE " + DB.SetString("%" + cCODE.ToUpper() + "%") + " ";
           

            return GetDataList(whStr, orderBy, trans);
        }


    }
}