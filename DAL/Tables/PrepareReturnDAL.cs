using System;
using System.Data;
using System.Data.OracleClient;
using DB = SHND.DAL.Utilities.OracleDB;
using SHND.Data.Common.Utilities;

namespace SHND.DAL.Tables
{
    /// <summary>
    /// Represents a transaction for PREPARERETURN table.
    /// [Created by 10.10.10.10 on May,12 2009]
    /// </summary>
    public class PrepareReturnDAL
    {

        public PrepareReturnDAL()
        {
        }

        #region Constant

        /// <summary>PREPARERETURN</summary>
        private const string tableName = "PREPARERETURN";

        #endregion

        #region Private Variables

        int _deletedRow = 0;
        string _error = "";
        string _information = "";
        bool _OnDB = false;
        string _CODE = "";
        string _CREATEBY = "";
        DateTime _CREATEON = new DateTime(1, 1, 1);
        double _DIVISION = 0;
        double _DOCTYPE = 0;
        DateTime _INFORMDATE = new DateTime(1, 1, 1);
        double _LOID = 0;
        double _MATERIALCLASS = 0;
        string _STATUS = "";
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
        public string CODE
        {
            get { return _CODE; }
            set { _CODE = value; }
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
        public double DIVISION
        {
            get { return _DIVISION; }
            set { _DIVISION = value; }
        }
        public double DOCTYPE
        {
            get { return _DOCTYPE; }
            set { _DOCTYPE = value; }
        }
        public DateTime INFORMDATE
        {
            get { return _INFORMDATE; }
            set { _INFORMDATE = value; }
        }
        public double LOID
        {
            get { return _LOID; }
            set { _LOID = value; }
        }
        public double MATERIALCLASS
        {
            get { return _MATERIALCLASS; }
            set { _MATERIALCLASS = value; }
        }
        public string STATUS
        {
            get { return _STATUS; }
            set { _STATUS = value; }
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
            _CODE = "";
            _CREATEBY = "";
            _CREATEON = new DateTime(1, 1, 1);
            _DIVISION = 0;
            _DOCTYPE = 0;
            _INFORMDATE = new DateTime(1, 1, 1);
            _LOID = 0;
            _MATERIALCLASS = 0;
            _STATUS = "";
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
        /// Returns an indication whether the current data is inserted into PREPARERETURN table successfully.
        /// </summary>
        /// <param name="userID">The current user.</param>
        /// <param name="trans">The System.Data.OracleClient.OracleTransaction used by this System.Data.OracleClient.OracleCommand.</param>
        /// <returns>true if insert data successfully; otherwise, false.</returns>
        public bool InsertCurrentData(string userID, OracleTransaction trans)
        {
            _LOID = DB.GetNextID(TableName, trans);
            _CODE = DB.GetRunningCode("PREPARERETURN", "CODE", trans);
            _CREATEBY = userID;
            _CREATEON = DateTime.Now;
            return doInsert(trans);
        }

        /// <summary>
        /// Returns an indication whether the current data is updated to PREPARERETURN table successfully.
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
        /// Returns an indication whether the current data is deleted from PREPARERETURN table successfully.
        /// </summary>
        /// <param name="trans">The System.Data.OracleClient.OracleTransaction used by this System.Data.OracleClient.OracleCommand.</param>
        /// <returns>true if delete data successfully; otherwise, false.</returns>
        public bool DeleteCurrentData(OracleTransaction trans)
        {
            return doDelete("LOID = " + DB.SetDouble(_LOID) + " ", trans);
        }

        /// <summary>
        /// Returns an indication whether the record of PREPARERETURN by specified LOID key is retrieved successfully.
        /// </summary>
        /// <param name="cLOID">The LOID key.</param>
        /// <param name="trans">The System.Data.OracleClient.OracleTransaction used by this System.Data.OracleClient.OracleCommand.</param>
        /// <returns>true if data is retrieved successfully; otherwise, false.</returns>
        public bool GetDataByLOID(double cLOID, OracleTransaction trans)
        {
            return doGetdata("LOID = " + DB.SetDouble(cLOID) + " ", trans);
        }

        /// <summary>
        /// Returns an indication whether the record of PREPARERETURN by specified CODE key is retrieved successfully.
        /// </summary>
        /// <param name="cCODE">The CODE key.</param>
        /// <param name="trans">The System.Data.OracleClient.OracleTransaction used by this System.Data.OracleClient.OracleCommand.</param>
        /// <returns>true if data is retrieved successfully; otherwise, false.</returns>
        public bool GetDataByCODE(string cCODE, OracleTransaction trans)
        {
            return doGetdata("CODE = " + DB.SetString(cCODE) + " ", trans);
        }

        #endregion

        #region SQL Statements

        /// <summary>
        /// Gets the insert statement for PREPARERETURN table.
        /// </summary>
        private string sql_insert
        {
            get
            {
                string sql = "INSERT INTO " + tableName + "(CODE, CREATEBY, CREATEON, DIVISION, DOCTYPE, INFORMDATE, LOID, MATERIALCLASS, STATUS) ";
                sql += "VALUES (";
                sql += DB.SetString(_CODE) + ", ";
                sql += DB.SetString(_CREATEBY) + ", ";
                sql += DB.SetDateTime(_CREATEON) + ", ";
                sql += DB.SetDouble(_DIVISION) + ", ";
                sql += DB.SetDouble(_DOCTYPE) + ", ";
                sql += DB.SetDateTime(_INFORMDATE) + ", ";
                sql += DB.SetDouble(_LOID) + ", ";
                sql += DB.SetDouble(_MATERIALCLASS) + ", ";
                sql += DB.SetString(_STATUS) + " ";
                sql += ")";
                return sql;
            }
        }

        /// <summary>
        /// Gets the update statement for PREPARERETURN table.
        /// </summary>
        private string sql_update
        {
            get
            {
                string sql = "UPDATE " + tableName + " SET ";
                sql += "CODE = " + DB.SetString(_CODE) + ", ";
                sql += "DIVISION = " + DB.SetDouble(_DIVISION) + ", ";
                sql += "DOCTYPE = " + DB.SetDouble(_DOCTYPE) + ", ";
                sql += "INFORMDATE = " + DB.SetDateTime(_INFORMDATE) + ", ";
                sql += "MATERIALCLASS = " + DB.SetDouble(_MATERIALCLASS) + ", ";
                sql += "STATUS = " + DB.SetString(_STATUS) + ", ";
                sql += "UPDATEBY = " + DB.SetString(_UPDATEBY) + ", ";
                sql += "UPDATEON = " + DB.SetDateTime(_UPDATEON) + " ";
                return sql;
            }
        }

        /// <summary>
        /// Gets the delete statement for PREPARERETURN table.
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
        /// Gets the select statement for PREPARERETURN table.
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
        /// Returns an indication whether the current data is inserted into PREPARERETURN table successfully.
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
        /// Returns an indication whether the current data is updated to PREPARERETURN table successfully.
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
        /// Returns an indication whether the current data is deleted from PREPARERETURN table successfully.
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
        /// Returns an indication whether the record of PREPARERETURN by specified condition is retrieved successfully.
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
                        if (!Convert.IsDBNull(zRdr["CODE"])) _CODE = zRdr["CODE"].ToString();
                        if (!Convert.IsDBNull(zRdr["CREATEBY"])) _CREATEBY = zRdr["CREATEBY"].ToString();
                        if (!Convert.IsDBNull(zRdr["CREATEON"])) _CREATEON = Convert.ToDateTime(zRdr["CREATEON"]);
                        if (!Convert.IsDBNull(zRdr["DIVISION"])) _DIVISION = Convert.ToDouble(zRdr["DIVISION"]);
                        if (!Convert.IsDBNull(zRdr["DOCTYPE"])) _DOCTYPE = Convert.ToDouble(zRdr["DOCTYPE"]);
                        if (!Convert.IsDBNull(zRdr["INFORMDATE"])) _INFORMDATE = Convert.ToDateTime(zRdr["INFORMDATE"]);
                        if (!Convert.IsDBNull(zRdr["LOID"])) _LOID = Convert.ToDouble(zRdr["LOID"]);
                        if (!Convert.IsDBNull(zRdr["MATERIALCLASS"])) _MATERIALCLASS = Convert.ToDouble(zRdr["MATERIALCLASS"]);
                        if (!Convert.IsDBNull(zRdr["STATUS"])) _STATUS = zRdr["STATUS"].ToString();
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

        #region My Method

        public double GetStockOutQty(string division, string material, string unitloid)
        {
            string sql = "";
            sql = "SELECT PKE_STOCK.FN_CALSTOCKOUTSUM(" + division + "," + material + "," + unitloid + ",FN_GETCONFIGVALUEBYNAME('WHFOOD')) FROM DUAL";
            object tmp = DB.ExecuteScalar(sql);
            if (tmp != null)
                return Convert.ToDouble(tmp);
            else
                return 0;
        }

        #endregion
    }
}