using System;
using System.Data;
using System.Data.OracleClient;
using DB = SHND.DAL.Utilities.OracleDB;
using SHND.Data.Common.Utilities;

namespace SHND.DAL.Tables
{
    /// <summary>
    /// Represents a transaction for ORDERWELFAREITEM table.
    /// [Created by 127.0.0.1 on January,13 2009]
    /// </summary>
    public class OrderWelfareItemDAL
    {

        public OrderWelfareItemDAL()
        {
        }

        #region Constant

        /// <summary>ORDERWELFAREITEM</summary>
        private const string tableName = "ORDERWELFAREITEM";

        #endregion

        #region Private Variables

        int _deletedRow = 0;
        string _error = "";
        string _information = "";
        bool _OnDB = false;
        string _CREATEBY = "";
        DateTime _CREATEON = new DateTime(1, 1, 1);
        double _LOID = 0;
        double _ORDERWELFARE = 0;
        double _QTY = 0;
        double _SUBDIVISION = 0;
        string _UPDATEBY = "";
        DateTime _UPDATEON = new DateTime(1, 1, 1);

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
        public string CREATEBY
        {
            get { return _CREATEBY; }
            set { _CREATEBY = value; }
        }
        public DateTime CREATEON
        {
            get { return _CREATEON; }
            set { _CREATEON = value; }
        }
        public double LOID
        {
            get { return _LOID; }
            set { _LOID = value; }
        }
        public double ORDERWELFARE
        {
            get { return _ORDERWELFARE; }
            set { _ORDERWELFARE = value; }
        }
        public double QTY
        {
            get { return _QTY; }
            set { _QTY = value; }
        }
        public double SUBDIVISION
        {
            get { return _SUBDIVISION; }
            set { _SUBDIVISION = value; }
        }
        public string UPDATEBY
        {
            get { return _UPDATEBY; }
            set { _UPDATEBY = value; }
        }
        public DateTime UPDATEON
        {
            get { return _UPDATEON; }
            set { _UPDATEON = value; }
        }

        #endregion

        #region Clear Data

        /// <summary>
        /// Initialize data.
        /// </summary>
        private void ClearData()
        {
            _CREATEBY = "";
            _CREATEON = new DateTime(1, 1, 1);
            _LOID = 0;
            _ORDERWELFARE = 0;
            _QTY = 0;
            _SUBDIVISION = 0;
            _UPDATEBY = "";
            _UPDATEON = new DateTime(1, 1, 1);
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
        /// Returns an indication whether the current data is inserted into ORDERWELFAREITEM table successfully.
        /// </summary>
        /// <param name="userID">The current user.</param>
        /// <param name="trans">The System.Data.OracleClient.OracleTransaction used by this System.Data.OracleClient.OracleCommand.</param>
        /// <returns>true if insert data successfully; otherwise, false.</returns>
        public bool InsertCurrentData(string userID, OracleTransaction trans)
        {
            _LOID = DB.GetNextID(TableName, trans);
            _CREATEBY = userID;
            _CREATEON = DateTime.Now;
            return doInsert(trans);
        }

        /// <summary>
        /// Returns an indication whether the current data is updated to ORDERWELFAREITEM table successfully.
        /// </summary>
        /// <param name="userID">The current user.</param>
        /// <param name="trans">The System.Data.OracleClient.OracleTransaction used by this System.Data.OracleClient.OracleCommand.</param>
        /// <returns>true if update data successfully; otherwise, false.</returns>
        public bool UpdateCurrentData(string userID, OracleTransaction trans)
        {
            _UPDATEBY = userID;
            _UPDATEON = DateTime.Now;
            return doUpdate("LOID = " + DB.SetDouble(_LOID) + " ", trans);
        }

        /// <summary>
        /// Returns an indication whether the current data is deleted from ORDERWELFAREITEM table successfully.
        /// </summary>
        /// <param name="trans">The System.Data.OracleClient.OracleTransaction used by this System.Data.OracleClient.OracleCommand.</param>
        /// <returns>true if delete data successfully; otherwise, false.</returns>
        public bool DeleteCurrentData(OracleTransaction trans)
        {
            return doDelete("LOID = " + DB.SetDouble(_LOID) + " ", trans);
        }

        public bool DeleteDataByCondition(string FTABLE, double LOID, OracleTransaction trans)
        {
            return doDelete("QTY = " + DB.SetString(FTABLE) + " AND LOID = " + DB.SetDouble(_LOID) + " ", trans);
        }

        /// <summary>
        /// Returns an indication whether the record of ORDERWELFAREITEM by specified LOID key is retrieved successfully.
        /// </summary>
        /// <param name="cLOID">The LOID key.</param>
        /// <param name="trans">The System.Data.OracleClient.OracleTransaction used by this System.Data.OracleClient.OracleCommand.</param>
        /// <returns>true if data is retrieved successfully; otherwise, false.</returns>
        public bool GetDataByLOID(double cLOID, OracleTransaction trans)
        {
            return doGetdata("LOID = " + DB.SetDouble(cLOID) + " ", trans);
        }

        public bool DeleteDataByORDERWELFARE(double cORDERWELFARE, OracleTransaction trans)
        {
            return doDelete("ORDERWELFARE = " + DB.SetDouble(cORDERWELFARE) + " ", trans);
        }

        public bool UpdateDataByORDERWELFARE(double cORDERWELFARE, OracleTransaction trans)
        {
            return doUpdate("ORDERWELFARE = " + DB.SetDouble(cORDERWELFARE) + " ", trans);
        }
        #endregion

        #region SQL Statements

        /// <summary>
        /// Gets the insert statement for ORDERWELFAREITEM table.
        /// </summary>
        private string sql_insert
        {
            get
            {
                string sql = "INSERT INTO " + tableName + "(CREATEBY, CREATEON, LOID, ORDERWELFARE, QTY, SUBDIVISION) ";
                sql += "VALUES (";
                sql += DB.SetString(_CREATEBY) + ", ";
                sql += DB.SetDateTime(_CREATEON) + ", ";
                sql += DB.SetDouble(_LOID) + ", ";
                sql += DB.SetDouble(_ORDERWELFARE) + ", ";
                sql += DB.SetDouble(_QTY) + ", ";
                sql += DB.SetDouble(_SUBDIVISION) + " ";
                sql += ")";
                return sql;
            }
        }

        /// <summary>
        /// Gets the update statement for ORDERWELFAREITEM table.
        /// </summary>
        private string sql_update
        {
            get
            {
                string sql = "UPDATE " + tableName + " SET ";
                sql += "ORDERWELFARE = " + DB.SetDouble(_ORDERWELFARE) + ", ";
                sql += "QTY = " + DB.SetDouble(_QTY) + ", ";
                sql += "SUBDIVISION = " + DB.SetDouble(_SUBDIVISION) + ", ";
                sql += "UPDATEBY = " + DB.SetString(_UPDATEBY) + ", ";
                sql += "UPDATEON = " + DB.SetDateTime(_UPDATEON) + " ";
                return sql;
            }
        }

        /// <summary>
        /// Gets the delete statement for ORDERWELFAREITEM table.
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
        /// Gets the select statement for ORDERWELFAREITEM table.
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
        /// Returns an indication whether the current data is inserted into ORDERWELFAREITEM table successfully.
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
        /// Returns an indication whether the current data is updated to ORDERWELFAREITEM table successfully.
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
        /// Returns an indication whether the current data is deleted from ORDERWELFAREITEM table successfully.
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
        /// Returns an indication whether the record of ORDERWELFAREITEM by specified condition is retrieved successfully.
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
                        if (!Convert.IsDBNull(zRdr["CREATEBY"])) _CREATEBY = zRdr["CREATEBY"].ToString();
                        if (!Convert.IsDBNull(zRdr["CREATEON"])) _CREATEON = Convert.ToDateTime(zRdr["CREATEON"]);
                        if (!Convert.IsDBNull(zRdr["LOID"])) _LOID = Convert.ToDouble(zRdr["LOID"]);
                        if (!Convert.IsDBNull(zRdr["ORDERWELFARE"])) _ORDERWELFARE = Convert.ToDouble(zRdr["ORDERWELFARE"]);
                        if (!Convert.IsDBNull(zRdr["QTY"])) _QTY = Convert.ToDouble(zRdr["QTY"]);
                        if (!Convert.IsDBNull(zRdr["SUBDIVISION"])) _SUBDIVISION = Convert.ToDouble(zRdr["SUBDIVISION"]);
                        if (!Convert.IsDBNull(zRdr["UPDATEBY"])) _UPDATEBY = zRdr["UPDATEBY"].ToString();
                        if (!Convert.IsDBNull(zRdr["UPDATEON"])) _UPDATEON = Convert.ToDateTime(zRdr["UPDATEON"]);
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