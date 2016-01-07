using System;
using System.Data;
using System.Data.OracleClient;
using DB = SHND.DAL.Utilities.OracleDB;
using SHND.Data.Common.Utilities;

namespace SHND.DAL.Tables
{
    /// <summary>
    /// Represents a transaction for ZMENU table.
    /// [Created by 127.0.0.1 on Febuary,2 2009]
    /// </summary>
    public class ZMenuDAL
    {

        public ZMenuDAL()
        {
        }

        #region Constant

        /// <summary>ZMENU</summary>
        private const string tableName = "ZMENU";

        #endregion

        #region Private Variables

        int _deletedRow = 0;
        string _error = "";
        string _information = "";
        bool _OnDB = false;
        DateTime _CREATEON = new DateTime(1, 1, 1);
        string _DESCRIPTION = "";
        string _ENABLED = "";
        string _IMAGE = "";
        string _LINK = "";
        double _LOID = 0;
        double _MENUGROUP = 0;
        string _MENUNAME = "";
        double _PARENT = 0;
        double _SEQUENCE = 0;
        double _ZSYSTEM = 0;

        #endregion

        #region Public Properties

        public string TableName
        {
            get { return tableName; }
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
            _IMAGE = "";
            _LINK = "";
            _LOID = 0;
            _MENUGROUP = 0;
            _MENUNAME = "";
            _PARENT = 0;
            _SEQUENCE = 0;
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

        /// <summary>
        /// Returns an indication whether the current data is inserted into ZMENU table successfully.
        /// </summary>
        /// <param name="userID">The current user.</param>
        /// <param name="trans">The System.Data.OracleClient.OracleTransaction used by this System.Data.OracleClient.OracleCommand.</param>
        /// <returns>true if insert data successfully; otherwise, false.</returns>
        public bool InsertCurrentData(string userID, OracleTransaction trans)
        {
            _LOID = DB.GetNextID(TableName, trans);
          //  _CREATEBY = userID;
            _CREATEON = DateTime.Now;
            return doInsert(trans);
        }

        /// <summary>
        /// Returns an indication whether the current data is updated to ZMENU table successfully.
        /// </summary>
        /// <param name="userID">The current user.</param>
        /// <param name="trans">The System.Data.OracleClient.OracleTransaction used by this System.Data.OracleClient.OracleCommand.</param>
        /// <returns>true if update data successfully; otherwise, false.</returns>
        public bool UpdateCurrentData(string userID, OracleTransaction trans)
        {
          //  _UPDATEBY = userID;
           // _UPDATEON = DateTime.Now;
            return doUpdate("LOID = " + DB.SetDouble(_LOID) + " ", trans);
        }

        /// <summary>
        /// Returns an indication whether the current data is deleted from ZMENU table successfully.
        /// </summary>
        /// <param name="trans">The System.Data.OracleClient.OracleTransaction used by this System.Data.OracleClient.OracleCommand.</param>
        /// <returns>true if delete data successfully; otherwise, false.</returns>
        public bool DeleteCurrentData(OracleTransaction trans)
        {
            return doDelete("LOID = " + DB.SetDouble(_LOID) + " ", trans);
        }

        /// <summary>
        /// Returns an indication whether the record of ZMENU by specified LOID key is retrieved successfully.
        /// </summary>
        /// <param name="cLOID">The LOID key.</param>
        /// <param name="trans">The System.Data.OracleClient.OracleTransaction used by this System.Data.OracleClient.OracleCommand.</param>
        /// <returns>true if data is retrieved successfully; otherwise, false.</returns>
        public bool GetDataByLOID(double cLOID, OracleTransaction trans)
        {
            return doGetdata("LOID = " + DB.SetDouble(cLOID) + " ", trans);
        }

        #endregion

        #region SQL Statements

        /// <summary>
        /// Gets the insert statement for ZMENU table.
        /// </summary>
        private string sql_insert
        {
            get
            {
                string sql = "INSERT INTO " + tableName + "(CREATEON, DESCRIPTION, ENABLED, IMAGE, LINK, LOID, MENUGROUP, MENUNAME, PARENT, SEQUENCE, ZSYSTEM) ";
                sql += "VALUES (";
                sql += DB.SetDateTime(_CREATEON) + ", ";
                sql += DB.SetString(_DESCRIPTION) + ", ";
                sql += DB.SetString(_ENABLED) + ", ";
                sql += DB.SetString(_IMAGE) + ", ";
                sql += DB.SetString(_LINK) + ", ";
                sql += DB.SetDouble(_LOID) + ", ";
                sql += DB.SetDouble(_MENUGROUP) + ", ";
                sql += DB.SetString(_MENUNAME) + ", ";
                sql += DB.SetDouble(_PARENT) + ", ";
                sql += DB.SetDouble(_SEQUENCE) + ", ";
                sql += DB.SetDouble(_ZSYSTEM) + " ";
                sql += ")";
                return sql;
            }
        }

        /// <summary>
        /// Gets the update statement for ZMENU table.
        /// </summary>
        private string sql_update
        {
            get
            {
                string sql = "UPDATE " + tableName + " SET ";
                sql += "DESCRIPTION = " + DB.SetString(_DESCRIPTION) + ", ";
                sql += "ENABLED = " + DB.SetString(_ENABLED) + ", ";
                sql += "IMAGE = " + DB.SetString(_IMAGE) + ", ";
                sql += "LINK = " + DB.SetString(_LINK) + ", ";
                sql += "MENUGROUP = " + DB.SetDouble(_MENUGROUP) + ", ";
                sql += "MENUNAME = " + DB.SetString(_MENUNAME) + ", ";
                sql += "PARENT = " + DB.SetDouble(_PARENT) + ", ";
                sql += "SEQUENCE = " + DB.SetDouble(_SEQUENCE) + ", ";
                sql += "ZSYSTEM = " + DB.SetDouble(_ZSYSTEM) + " ";
                return sql;
            }
        }

        /// <summary>
        /// Gets the delete statement for ZMENU table.
        /// </summary>
        private string sql_delete
        {
            get
            {
                string sql = "DELETE FROM " + tableName + " ";
                return sql;
            }
        }

        /// <summary>
        /// Gets the select statement for ZMENU table.
        /// </summary>
        private string sql_select
        {
            get
            {
                string sql = "SELECT * FROM " + tableName + " ";
                return sql;
            }
        }

        #endregion

        #region Private Methods

        /// <summary>
        /// Returns an indication whether the current data is inserted into ZMENU table successfully.
        /// </summary>
        /// <param name="trans">The System.Data.OracleClient.OracleTransaction used by this System.Data.OracleClient.OracleCommand.</param>
        /// <returns>true if insert data successfully; otherwise, false.</returns>
        public bool doInsert(OracleTransaction trans)
        {
            bool ret = true;
            int affectedRow = 0;
            if (!_OnDB)
            {
                try
                {
                    affectedRow = DB.ExecuteNonQuery(sql_insert, trans);
                    ret = (affectedRow > 0);
                    if (!ret) _error = DataResources.MSGEN001;
                    _information = DataResources.MSGIN001;
                }
                catch (DAL.Utilities.BaseDB.DatabaseException ex)
                {
                    ret = false;
                    _error = ex.Message;
                }
                catch (Exception ex)
                {
                    ex.ToString();
                    ret = false;
                    _error = DataResources.MSGEC101;
                }
            }
            else
            {
                ret = false;
                _error = DataResources.MSGEN002;
            }
            return ret;
        }

        /// <summary>
        /// Returns an indication whether the current data is updated to ZMENU table successfully.
        /// </summary>
        /// <param name="whText">The condition specify the updating record(s).</param>
        /// <param name="trans">The System.Data.OracleClient.OracleTransaction used by this System.Data.OracleClient.OracleCommand.</param>
        /// <returns>true if update data successfully; otherwise, false.</returns>
        public bool doUpdate(string whText, OracleTransaction trans)
        {
            bool ret = true;
            int affectedRow = 0;
            if (_OnDB)
            {
                if (whText.Trim() != "")
                {
                    string tmpWhere = "WHERE " + whText;
                    try
                    {
                        affectedRow = DB.ExecuteNonQuery(sql_update + tmpWhere, trans);
                        ret = (affectedRow > 0);
                        if (!ret) _error = DataResources.MSGEU001;
                        _information = DataResources.MSGIU001;
                    }
                    catch (DAL.Utilities.BaseDB.DatabaseException ex)
                    {
                        ret = false;
                        _error = ex.Message;
                    }
                    catch (Exception ex)
                    {
                        ex.ToString();
                        ret = false;
                        _error = DataResources.MSGEC102;
                    }
                }
                else
                {
                    ret = false;
                    _error = DataResources.MSGEU003;
                }
            }
            else
            {
                ret = false;
                _error = DataResources.MSGEU002;
            }
            return ret;
        }

        /// <summary>
        /// Returns an indication whether the current data is deleted from ZMENU table successfully.
        /// </summary>
        /// <param name="whText">The condition specify the deleting record(s).</param>
        /// <param name="trans">The System.Data.OracleClient.OracleTransaction used by this System.Data.OracleClient.OracleCommand.</param>
        /// <returns>true if delete data successfully; otherwise, false.</returns>
        public bool doDelete(string whText, OracleTransaction trans)
        {
            bool ret = true;
            _deletedRow = 0;
            if (whText.Trim() != "")
            {
                string tmpWhere = "WHERE " + whText;
                try
                {
                    _deletedRow = DB.ExecuteNonQuery(sql_delete + tmpWhere, trans);
                    ret = (_deletedRow > 0);
                    if (!ret) _error = DataResources.MSGED001;
                    _information = DataResources.MSGID001;
                }
                catch (DAL.Utilities.BaseDB.DatabaseException ex)
                {
                    ret = false;
                    _error = ex.Message;
                }
                catch (Exception ex)
                {
                    ex.ToString();
                    ret = false;
                    _error = DataResources.MSGEC103;
                }
            }
            else
            {
                ret = false;
                _error = DataResources.MSGED003;
            }
            return ret;
        }

        /// <summary>
        /// Returns an indication whether the record of ZMENU by specified condition is retrieved successfully.
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
                        if (!Convert.IsDBNull(zRdr["IMAGE"])) _IMAGE = zRdr["IMAGE"].ToString();
                        if (!Convert.IsDBNull(zRdr["LINK"])) _LINK = zRdr["LINK"].ToString();
                        if (!Convert.IsDBNull(zRdr["LOID"])) _LOID = Convert.ToDouble(zRdr["LOID"]);
                        if (!Convert.IsDBNull(zRdr["MENUGROUP"])) _MENUGROUP = Convert.ToDouble(zRdr["MENUGROUP"]);
                        if (!Convert.IsDBNull(zRdr["MENUNAME"])) _MENUNAME = zRdr["MENUNAME"].ToString();
                        if (!Convert.IsDBNull(zRdr["PARENT"])) _PARENT = Convert.ToDouble(zRdr["PARENT"]);
                        if (!Convert.IsDBNull(zRdr["SEQUENCE"])) _SEQUENCE = Convert.ToDouble(zRdr["SEQUENCE"]);
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

        public bool DeleteDataByLOID(double  cLOID, OracleTransaction trans)
        {
            return doDelete(" LOID = " + DB.SetDouble(cLOID) + " ", trans);
        }
        
    }
}