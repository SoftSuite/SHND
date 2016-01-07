using System;
using System.Data;
using System.Data.OracleClient;
using DB = SHND.DAL.Utilities.OracleDB;
using SHND.Data.Common.Utilities;

namespace SHND.DAL.Tables
{
    /// <summary>
    /// Represents a transaction for PREPARETIME table.
    /// [Created by 127.0.0.1 on April,8 2009]
    /// </summary>
    public class PrepareTimeDAL
    {

        public PrepareTimeDAL()
        {
        }

        #region Constant

        /// <summary>PREPARETIME</summary>
        private const string tableName = "PREPARETIME";

        #endregion

        #region Private Variables

        int _deletedRow = 0;
        string _error = "";
        string _information = "";
        bool _OnDB = false;
        DateTime _CHECKTIME = new DateTime(1, 1, 1);
        string _CREATEBY = "";
        DateTime _CREATEON = new DateTime(1, 1, 1);
        string _ISTRANSFER = "";
        double _LOID = 0;
        string _PREPAREMEAL = "";
        double _REFMEDLOID = 0;
        double _REFNONMEDLOID = 0;
        string _REFTABLEMED = "";
        string _UPDATEBY = "";
        DateTime _UPDATEON = new DateTime(1, 1, 1);
        DateTime _DELIVERYTIME = new DateTime(1, 1, 1);

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
        public DateTime CHECKTIME
        {
            get { return _CHECKTIME; }
            set { _CHECKTIME = value; }
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
        public string ISTRANSFER
        {
            get { return _ISTRANSFER; }
            set { _ISTRANSFER = value; }
        }
        public double LOID
        {
            get { return _LOID; }
            set { _LOID = value; }
        }
        public string PREPAREMEAL
        {
            get { return _PREPAREMEAL; }
            set { _PREPAREMEAL = value; }
        }
        public double REFMEDLOID
        {
            get { return _REFMEDLOID; }
            set { _REFMEDLOID = value; }
        }
        public double REFNONMEDLOID
        {
            get { return _REFNONMEDLOID; }
            set { _REFNONMEDLOID = value; }
        }
        public string REFTABLEMED
        {
            get { return _REFTABLEMED; }
            set { _REFTABLEMED = value; }
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

        public DateTime DELIVERYTIME
        {
            get { return _DELIVERYTIME; }
            set { _DELIVERYTIME = value; }
        }

        #endregion

        #region Clear Data

        /// <summary>
        /// Initialize data.
        /// </summary>
        private void ClearData()
        {
            _CHECKTIME = new DateTime(1, 1, 1);
            _CREATEBY = "";
            _CREATEON = new DateTime(1, 1, 1);
            _ISTRANSFER = "";
            _LOID = 0;
            _PREPAREMEAL = "";
            _REFMEDLOID = 0;
            _REFNONMEDLOID = 0;
            _REFTABLEMED = "";
            _UPDATEBY = "";
            _UPDATEON = new DateTime(1, 1, 1);
            _DELIVERYTIME = new DateTime(1, 1, 1);
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
        /// Returns an indication whether the current data is inserted into PREPARETIME table successfully.
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
        /// Returns an indication whether the current data is updated to PREPARETIME table successfully.
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
        /// Returns an indication whether the current data is deleted from PREPARETIME table successfully.
        /// </summary>
        /// <param name="trans">The System.Data.OracleClient.OracleTransaction used by this System.Data.OracleClient.OracleCommand.</param>
        /// <returns>true if delete data successfully; otherwise, false.</returns>
        public bool DeleteCurrentData(OracleTransaction trans)
        {
            return doDelete("LOID = " + DB.SetDouble(_LOID) + " ", trans);
        }

        /// <summary>
        /// Returns an indication whether the record of PREPARETIME by specified LOID key is retrieved successfully.
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
        /// Gets the insert statement for PREPARETIME table.
        /// </summary>
        private string sql_insert
        {
            get
            {
                string sql = "INSERT INTO " + tableName + "(CHECKTIME, CREATEBY, CREATEON, ISTRANSFER, LOID, PREPAREMEAL, REFMEDLOID, REFNONMEDLOID, REFTABLEMED,DELIVERYTIME) ";
                sql += "VALUES (";
                sql += DB.SetDateTime(_CHECKTIME) + ", ";
                sql += DB.SetString(_CREATEBY) + ", ";
                sql += DB.SetDateTime(_CREATEON) + ", ";
                sql += DB.SetString(_ISTRANSFER) + ", ";
                sql += DB.SetDouble(_LOID) + ", ";
                sql += DB.SetString(_PREPAREMEAL) + ", ";
                sql += DB.SetDouble(_REFMEDLOID) + ", ";
                sql += DB.SetDouble(_REFNONMEDLOID) + ", ";
                sql += DB.SetString(_REFTABLEMED) + ", ";
                sql += DB.SetDateTime(_DELIVERYTIME) + " ";
                sql += ")";
                return sql;
            }
        }

        /// <summary>
        /// Gets the update statement for PREPARETIME table.
        /// </summary>
        private string sql_update
        {
            get
            {
                string sql = "UPDATE " + tableName + " SET ";
                sql += "CHECKTIME = " + DB.SetDateTime(_CHECKTIME) + ", ";
                sql += "ISTRANSFER = " + DB.SetString(_ISTRANSFER) + ", ";
                sql += "PREPAREMEAL = " + DB.SetString(_PREPAREMEAL) + ", ";
                sql += "REFMEDLOID = " + DB.SetDouble(_REFMEDLOID) + ", ";
                sql += "REFNONMEDLOID = " + DB.SetDouble(_REFNONMEDLOID) + ", ";
                sql += "REFTABLEMED = " + DB.SetString(_REFTABLEMED) + ", ";
                sql += "UPDATEBY = " + DB.SetString(_UPDATEBY) + ", ";
                sql += "UPDATEON = " + DB.SetDateTime(_UPDATEON) + ", ";
                sql += "DELIVERYTIME = " + DB.SetDateTime(_DELIVERYTIME) + " ";
                return sql;
            }
        }

        /// <summary>
        /// Gets the delete statement for PREPARETIME table.
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
        /// Gets the select statement for PREPARETIME table.
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
        /// Returns an indication whether the current data is inserted into PREPARETIME table successfully.
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
        /// Returns an indication whether the current data is updated to PREPARETIME table successfully.
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
        /// Returns an indication whether the current data is deleted from PREPARETIME table successfully.
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
        /// Returns an indication whether the record of PREPARETIME by specified condition is retrieved successfully.
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
                        if (!Convert.IsDBNull(zRdr["CHECKTIME"])) _CHECKTIME = Convert.ToDateTime(zRdr["CHECKTIME"]);
                        if (!Convert.IsDBNull(zRdr["CREATEBY"])) _CREATEBY = zRdr["CREATEBY"].ToString();
                        if (!Convert.IsDBNull(zRdr["CREATEON"])) _CREATEON = Convert.ToDateTime(zRdr["CREATEON"]);
                        if (!Convert.IsDBNull(zRdr["ISTRANSFER"])) _ISTRANSFER = zRdr["ISTRANSFER"].ToString();
                        if (!Convert.IsDBNull(zRdr["LOID"])) _LOID = Convert.ToDouble(zRdr["LOID"]);
                        if (!Convert.IsDBNull(zRdr["PREPAREMEAL"])) _PREPAREMEAL = zRdr["PREPAREMEAL"].ToString();
                        if (!Convert.IsDBNull(zRdr["REFMEDLOID"])) _REFMEDLOID = Convert.ToDouble(zRdr["REFMEDLOID"]);
                        if (!Convert.IsDBNull(zRdr["REFNONMEDLOID"])) _REFNONMEDLOID = Convert.ToDouble(zRdr["REFNONMEDLOID"]);
                        if (!Convert.IsDBNull(zRdr["REFTABLEMED"])) _REFTABLEMED = zRdr["REFTABLEMED"].ToString();
                        if (!Convert.IsDBNull(zRdr["UPDATEBY"])) _UPDATEBY = zRdr["UPDATEBY"].ToString();
                        if (!Convert.IsDBNull(zRdr["UPDATEON"])) _UPDATEON = Convert.ToDateTime(zRdr["UPDATEON"]);
                        if (!Convert.IsDBNull(zRdr["DELIVERYTIME"])) _DELIVERYTIME = Convert.ToDateTime(zRdr["DELIVERYTIME"]);
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

        #region My Work Nang


        public bool GetDataUniq(string str, OracleTransaction trans)
        {
            return doGetdata(str, trans);
        }

        #endregion

        public bool UpdateDeliverlyStatusByLOID(string userID, string isTransfer, string loidList, OracleTransaction trans)
        {
            bool ret = true;
            int affectedRow = 0;
            string whText = "";
            if (loidList != "") whText = "LOID IN (" + loidList + ") ";
            if (whText.Trim() != "")
            {
                string tmpWhere = "WHERE " + whText;
                try
                {
                    affectedRow = DB.ExecuteNonQuery("UPDATE " + tableName + " SET ISTRANSFER='Y', DELIVERYTIME=" + DB.SetDateTime() + ", UPDATEON=" + DB.SetDateTime() + ", UPDATEBY = " + DB.SetString(userID) + " " + tmpWhere, trans);
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
            return ret;
        }
    }
}