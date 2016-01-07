using System;
using System.Data;
using System.Data.OracleClient;
using DB = SHND.DAL.Utilities.OracleDB;
using SHND.Data.Common.Utilities;

namespace SHND.DAL.Tables
{
    /// <summary>
    /// Represents a transaction for STOCKOUT table.
    /// [Created by 127.0.0.1 on Febuary,10 2009]
    /// </summary>
    public class StockOutDAL
    {

        public StockOutDAL()
        {
        }

        #region Constant

        /// <summary>STOCKOUT</summary>
        private const string tableName = "STOCKOUT";

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
        string _ISBREAKFAST = "";
        string _ISDINNER = "";
        string _ISLUNCH = "";
        double _LOID = 0;
        double _ORDERQTY = 0;
        double _PRIORITY = 0;
        string _REMARKS = "";
        string _STATUS = "";
        DateTime _STOCKOUTDATE = new DateTime(1, 1, 1);
        double _SUPPLIER = 0;
        string _UPDATEBY = "";
        DateTime _UPDATEON = new DateTime(1, 1, 1);
        DateTime _USEDATE = new DateTime(1, 1, 1);
        double _WAREHOUSE = 0;
        double _PLANORDER = 0;
        string _REASON = "";

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
        public string ISBREAKFAST
        {
            get { return _ISBREAKFAST; }
            set { _ISBREAKFAST = value; }
        }
        public string ISDINNER
        {
            get { return _ISDINNER; }
            set { _ISDINNER = value; }
        }
        public string ISLUNCH
        {
            get { return _ISLUNCH; }
            set { _ISLUNCH = value; }
        }
        public double LOID
        {
            get { return _LOID; }
            set { _LOID = value; }
        }
        public double ORDERQTY
        {
            get { return _ORDERQTY; }
            set { _ORDERQTY = value; }
        }
        public double PRIORITY
        {
            get { return _PRIORITY; }
            set { _PRIORITY = value; }
        }
        public string REMARKS
        {
            get { return _REMARKS; }
            set { _REMARKS = value; }
        }
        public string STATUS
        {
            get { return _STATUS; }
            set { _STATUS = value; }
        }
        public DateTime STOCKOUTDATE
        {
            get { return _STOCKOUTDATE; }
            set { _STOCKOUTDATE = value; }
        }
        public double SUPPLIER
        {
            get { return _SUPPLIER; }
            set { _SUPPLIER = value; }
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
        public DateTime USEDATE
        {
            get { return _USEDATE; }
            set { _USEDATE = value; }
        }
        public double WAREHOUSE
        {
            get { return _WAREHOUSE; }
            set { _WAREHOUSE = value; }
        }
        public double PLANORDER
        {
            get { return _PLANORDER; }
            set { _PLANORDER = value; }
        }
        public string REASON
        {
            get { return _REASON; }
            set { _REASON = value; }
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
            _ISBREAKFAST = "";
            _ISDINNER = "";
            _ISLUNCH = "";
            _LOID = 0;
            _ORDERQTY = 0;
            _PRIORITY = 0;
            _REMARKS = "";
            _STATUS = "";
            _STOCKOUTDATE = new DateTime(1, 1, 1);
            _SUPPLIER = 0;
            _UPDATEBY = "";
            _UPDATEON = new DateTime(1, 1, 1);
            _USEDATE = new DateTime(1, 1, 1);
            _WAREHOUSE = 0;
            _REASON = "";
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
        /// Returns an indication whether the current data is inserted into STOCKOUT table successfully.
        /// </summary>
        /// <param name="userID">The current user.</param>
        /// <param name="trans">The System.Data.OracleClient.OracleTransaction used by this System.Data.OracleClient.OracleCommand.</param>
        /// <returns>true if insert data successfully; otherwise, false.</returns>
        public bool InsertCurrentData(string userID, OracleTransaction trans)
        {
            _LOID = DB.GetNextID(TableName, trans);
            _CODE = DB.GetRunningCode(TableName, _DOCTYPE.ToString(), trans);
            _CREATEBY = userID;
            _CREATEON = DateTime.Now;
            return doInsert(trans);
        }

        /// <summary>
        /// Returns an indication whether the current data is updated to STOCKOUT table successfully.
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
        /// Returns an indication whether the current data is deleted from STOCKOUT table successfully.
        /// </summary>
        /// <param name="trans">The System.Data.OracleClient.OracleTransaction used by this System.Data.OracleClient.OracleCommand.</param>
        /// <returns>true if delete data successfully; otherwise, false.</returns>
        public bool DeleteCurrentData(OracleTransaction trans)
        {
            return doDelete("LOID = " + DB.SetDouble(_LOID) + " ", trans);
        }

        public bool CutStock(double stockOut, OracleTransaction trans)
        {
            bool ret = true;
            try
            {
                DB.ExecuteNonQuery("CALL PKE_STOCK.SP_CUTSTOCKOUT(" + stockOut.ToString() + ")", trans);
            }
            catch (Exception ex)
            {
                ret = false;
                _error = ex.Message;
            }
            return ret;
        }

        public bool CutStockOutReturn(double stockOut, OracleTransaction trans)
        {
            bool ret = true;
            try
            {
                DB.ExecuteNonQuery("CALL PKE_STOCK.SP_CUTSTOCKOUTRETURN(" + stockOut.ToString() + ")", trans);
            }
            catch(Exception ex)
            {
                ret = false;
                _error = ex.Message;
            }
            return ret;
        }
        public bool CutStockPrepare(double stockOut, OracleTransaction trans)
        {
            bool ret = true;
            try
            {
                DB.ExecuteNonQuery("CALL PKE_STOCK.SP_CUTSTOCKPREPARE(" + stockOut.ToString() +  ")",trans);
            }
            catch (Exception ex)
            {
                ret = false;
                _error = ex.Message;
            }
            return ret;
        }
        public bool CutStockRepair(double stockOut, OracleTransaction trans)
        {
            bool ret = true;
            try
            {
                DB.ExecuteNonQuery("CALL PKE_STOCK.SP_CUTSTOCKREPAIR(" + stockOut.ToString() + ")", trans);
            }
            catch (Exception ex)
            {
                ret = false;
                _error = ex.Message;
            }
            return ret;
        }

        /// <summary>
        /// Returns an indication whether the record of STOCKOUT by specified LOID key is retrieved successfully.
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
        /// Gets the insert statement for STOCKOUT table.
        /// </summary>
        private string sql_insert
        {
            get
            {
                string sql = "INSERT INTO " + tableName + "(CODE, CREATEBY, CREATEON, DIVISION, DOCTYPE, ISBREAKFAST, ISDINNER, ISLUNCH, LOID, ORDERQTY, PRIORITY, REMARKS, STATUS, STOCKOUTDATE, SUPPLIER, USEDATE, WAREHOUSE, PLANORDER, REASON) ";
                sql += "VALUES (";
                sql += DB.SetString(_CODE) + ", ";
                sql += DB.SetString(_CREATEBY) + ", ";
                sql += DB.SetDateTime(_CREATEON) + ", ";
                sql += DB.SetDouble(_DIVISION) + ", ";
                sql += DB.SetDouble(_DOCTYPE) + ", ";
                sql += DB.SetString(_ISBREAKFAST) + ", ";
                sql += DB.SetString(_ISDINNER) + ", ";
                sql += DB.SetString(_ISLUNCH) + ", ";
                sql += DB.SetDouble(_LOID) + ", ";
                sql += DB.SetDouble(_ORDERQTY) + ", ";
                sql += DB.SetDouble(_PRIORITY) + ", ";
                sql += DB.SetString(_REMARKS) + ", ";
                sql += DB.SetString(_STATUS) + ", ";
                sql += DB.SetDateTime(_STOCKOUTDATE) + ", ";
                sql += (_SUPPLIER == 0 ? "NULL" : DB.SetDouble(_SUPPLIER)) + ", ";
                sql += DB.SetDateTime(_USEDATE) + ", ";
                sql += DB.SetDouble(_WAREHOUSE) + ", ";
                sql += DB.SetDouble(_PLANORDER) + ", ";
                sql += DB.SetString(_REASON) + " )";
                return sql;
            }
        }

        /// <summary>
        /// Gets the update statement for STOCKOUT table.
        /// </summary>
        private string sql_update
        {
            get
            {
                string sql = "UPDATE " + tableName + " SET ";
                sql += "CODE = " + DB.SetString(_CODE) + ", ";
                sql += "DIVISION = " + DB.SetDouble(_DIVISION) + ", ";
                sql += "DOCTYPE = " + DB.SetDouble(_DOCTYPE) + ", ";
                sql += "ISBREAKFAST = " + DB.SetString(_ISBREAKFAST) + ", ";
                sql += "ISDINNER = " + DB.SetString(_ISDINNER) + ", ";
                sql += "ISLUNCH = " + DB.SetString(_ISLUNCH) + ", ";
                sql += "ORDERQTY = " + DB.SetDouble(_ORDERQTY) + ", ";
                sql += "PRIORITY = " + DB.SetDouble(_PRIORITY) + ", ";
                sql += "REMARKS = " + DB.SetString(_REMARKS) + ", ";
                sql += "STATUS = " + DB.SetString(_STATUS) + ", ";
                sql += "STOCKOUTDATE = " + DB.SetDateTime(_STOCKOUTDATE) + ", ";
                sql += "SUPPLIER = " + (_SUPPLIER == 0 ? "NULL" : DB.SetDouble(_SUPPLIER)) + ", ";
                sql += "UPDATEBY = " + DB.SetString(_UPDATEBY) + ", ";
                sql += "UPDATEON = " + DB.SetDateTime(_UPDATEON) + ", ";
                sql += "USEDATE = " + DB.SetDateTime(_USEDATE) + ", ";
                sql += "WAREHOUSE = " + DB.SetDouble(_WAREHOUSE) + ", ";
                sql += "PLANORDER = " + DB.SetDouble(_PLANORDER) + ", ";
                sql += "REASON = " + DB.SetString(_REASON) + " ";
                return sql;
            }
        }

        /// <summary>
        /// Gets the delete statement for STOCKOUT table.
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
        /// Gets the select statement for STOCKOUT table.
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
        /// Returns an indication whether the current data is inserted into STOCKOUT table successfully.
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
        /// Returns an indication whether the current data is updated to STOCKOUT table successfully.
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
        /// Returns an indication whether the current data is deleted from STOCKOUT table successfully.
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
        /// Returns an indication whether the record of STOCKOUT by specified condition is retrieved successfully.
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
                        if (!Convert.IsDBNull(zRdr["ISBREAKFAST"])) _ISBREAKFAST = zRdr["ISBREAKFAST"].ToString();
                        if (!Convert.IsDBNull(zRdr["ISDINNER"])) _ISDINNER = zRdr["ISDINNER"].ToString();
                        if (!Convert.IsDBNull(zRdr["ISLUNCH"])) _ISLUNCH = zRdr["ISLUNCH"].ToString();
                        if (!Convert.IsDBNull(zRdr["LOID"])) _LOID = Convert.ToDouble(zRdr["LOID"]);
                        if (!Convert.IsDBNull(zRdr["ORDERQTY"])) _ORDERQTY = Convert.ToDouble(zRdr["ORDERQTY"]);
                        if (!Convert.IsDBNull(zRdr["PRIORITY"])) _PRIORITY = Convert.ToDouble(zRdr["PRIORITY"]);
                        if (!Convert.IsDBNull(zRdr["REMARKS"])) _REMARKS = zRdr["REMARKS"].ToString();
                        if (!Convert.IsDBNull(zRdr["STATUS"])) _STATUS = zRdr["STATUS"].ToString();
                        if (!Convert.IsDBNull(zRdr["STOCKOUTDATE"])) _STOCKOUTDATE = Convert.ToDateTime(zRdr["STOCKOUTDATE"]);
                        if (!Convert.IsDBNull(zRdr["SUPPLIER"])) _SUPPLIER = Convert.ToDouble(zRdr["SUPPLIER"]);
                        if (!Convert.IsDBNull(zRdr["UPDATEBY"])) _UPDATEBY = zRdr["UPDATEBY"].ToString();
                        if (!Convert.IsDBNull(zRdr["UPDATEON"])) _UPDATEON = Convert.ToDateTime(zRdr["UPDATEON"]);
                        if (!Convert.IsDBNull(zRdr["USEDATE"])) _USEDATE = Convert.ToDateTime(zRdr["USEDATE"]);
                        if (!Convert.IsDBNull(zRdr["WAREHOUSE"])) _WAREHOUSE = Convert.ToDouble(zRdr["WAREHOUSE"]);
                        if (!Convert.IsDBNull(zRdr["PLANORDER"])) _PLANORDER = Convert.ToDouble(zRdr["PLANORDER"]);
                        if (!Convert.IsDBNull(zRdr["REASON"])) _REASON = zRdr["REASON"].ToString();
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


        public bool DeleteDataByLOID(double cLOID, OracleTransaction trans)
        {
            return doDelete(" LOID = " + DB.SetDouble(cLOID) + " ", trans);
        }
        public bool SentDataByLOID(double cLOID, OracleTransaction trans)
        {
            return doUpdate(" LOID = " + DB.SetDouble(cLOID) + " )" , trans);
        }
        public DataTable GetStockItem(double StockLOID)
        {
            string sql = "SELECT * FROM STOCKOUT S INNER JOIN STOCKOUTITEM SI ON S.LOID = SI.STOCKOUT ";
            sql += "WHERE SI.STOCKOUT = " + StockLOID;
            return DB.ExecuteTable(sql);
        }


        #region My Work Nang


        private string sql_status
        {
            get
            {
                string sql = "SELECT STATUS FROM " + tableName + " ";
                return sql;
            }
        }

        public string GetStatus(string wh)
        {
            return DB.ExecuteScalar(sql_status + (wh == "" ? "" : "WHERE " + wh)).ToString();
        }
        #endregion
    }
}