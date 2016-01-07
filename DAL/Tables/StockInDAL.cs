using System;
using System.Data;
using System.Data.OracleClient;
using DB = SHND.DAL.Utilities.OracleDB;
using SHND.Data.Common.Utilities;

namespace SHND.DAL.Tables
{
    /// <summary>
    /// Represents a transaction for STOCKIN table.
    /// [Created by 127.0.0.1 on Febuary,20 2009]
    /// </summary>
    public class StockInDAL
    {

        public StockInDAL()
        {
        }

        #region Constant

        /// <summary>STOCKIN</summary>
        private const string tableName = "STOCKIN";

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
        string _INVCODE = "";
        string _ISVAT = "";
        double _LOID = 0;
        double _PLANORDER = 0;
        double _PO = 0;
        string _REFCODE = "";
        string _STATUS = "";
        double _SAPWAREHOUSE = 0;
        DateTime _STOCKINDATE = new DateTime(1, 1, 1);
        string _UPDATEBY = "";
        DateTime _UPDATEON = new DateTime(1, 1, 1);
        double _WAREHOUSE = 0;
        string _REMARKS = "";

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
        public string INVCODE
        {
            get { return _INVCODE; }
            set { _INVCODE = value; }
        }
        public string ISVAT
        {
            get { return _ISVAT; }
            set { _ISVAT = value; }
        }
        public double LOID
        {
            get { return _LOID; }
            set { _LOID = value; }
        }
        public double PLANORDER
        {
            get { return _PLANORDER; }
            set { _PLANORDER = value; }
        }
        public double PO
        {
            get { return _PO; }
            set { _PO = value; }
        }
        public string REFCODE
        {
            get { return _REFCODE; }
            set { _REFCODE = value; }
        }
        public string STATUS
        {
            get { return _STATUS; }
            set { _STATUS = value; }
        }
        public DateTime STOCKINDATE
        {
            get { return _STOCKINDATE; }
            set { _STOCKINDATE = value; }
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
        public double WAREHOUSE
        {
            get { return _WAREHOUSE; }
            set { _WAREHOUSE = value; }
        }
        public double SAPWAREHOUSE
        {
            get { return _SAPWAREHOUSE; }
            set { _SAPWAREHOUSE = value; }
        }
        public string REMARKS
        {
            get { return _REMARKS ; }
            set { _REMARKS  = value; }
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
            _INVCODE = "";
            _ISVAT = "";
            _LOID = 0;
            _PLANORDER = 0;
            _PO = 0;
            _REFCODE = "";
            _STATUS = "";
            _STOCKINDATE = new DateTime(1, 1, 1);
            _UPDATEBY = "";
            _UPDATEON = new DateTime(1, 1, 1);
            _WAREHOUSE = 0;
            _SAPWAREHOUSE = 0;
            _REMARKS = "";
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
        /// Returns an indication whether the current data is inserted into STOCKIN table successfully.
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
        /// Returns an indication whether the current data is updated to STOCKIN table successfully.
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
        /// Returns an indication whether the current data is deleted from STOCKIN table successfully.
        /// </summary>
        /// <param name="trans">The System.Data.OracleClient.OracleTransaction used by this System.Data.OracleClient.OracleCommand.</param>
        /// <returns>true if delete data successfully; otherwise, false.</returns>
        public bool DeleteCurrentData(OracleTransaction trans)
        {
            return doDelete("LOID = " + DB.SetDouble(_LOID) + " ", trans);
        }

        public bool CutStock(double stockIn, OracleTransaction trans)
        {
            bool ret = true;
            try
            {
                DB.ExecuteNonQuery("CALL PKE_STOCK.SP_CUTSTOCKIN(" + stockIn.ToString() + ")", trans);
            }
            catch (Exception ex)
            {
                ret = false;
                _error = ex.Message;
            }
            return ret;
        }

        public bool CutStockReturn(double stockIn, OracleTransaction trans)
        {
            bool ret = true;
            try
            {
                DB.ExecuteNonQuery("CALL PKE_STOCK.SP_CUTSTOCKINRETURN(" + stockIn.ToString() + ")", trans);
            }
            catch (Exception ex)
            {
                ret = false;
                _error = ex.Message;
            }
            return ret;
        }

        /// <summary>
        /// Returns an indication whether the record of STOCKIN by specified LOID key is retrieved successfully.
        /// </summary>
        /// <param name="cLOID">The LOID key.</param>
        /// <param name="trans">The System.Data.OracleClient.OracleTransaction used by this System.Data.OracleClient.OracleCommand.</param>
        /// <returns>true if data is retrieved successfully; otherwise, false.</returns>
        public bool GetDataByLOID(double cLOID, OracleTransaction trans)
        {
            return doGetdata("LOID = " + DB.SetDouble(cLOID) + " ", trans);
        }

        public bool UpdateByLOID(double cLOID, string userID, OracleTransaction trans)
        {
            _UPDATEBY = userID;
            _UPDATEON = DateTime.Now;
            return doUpdate("LOID = " + DB.SetDouble(cLOID) + " ", trans);
        }


        #endregion

        #region SQL Statements

        /// <summary>
        /// Gets the insert statement for STOCKIN table.
        /// </summary>
        private string sql_insert
        {
            get  
            {
                string sql = "INSERT INTO " + tableName + "(CODE, CREATEBY, CREATEON, DIVISION, DOCTYPE, INVCODE, ISVAT, LOID, PLANORDER, PO, REFCODE, STATUS, STOCKINDATE, WAREHOUSE ,SAPWAREHOUSE,REMARKS) ";
                sql += "VALUES (";
                sql += (_CODE == "" ? "NULL" : DB.SetString(_CODE)) + ", ";
                sql += DB.SetString(_CREATEBY) + ", ";
                sql += DB.SetDateTime(_CREATEON) + ", ";
                sql += DB.SetDouble(_DIVISION) + ", ";
                sql += (_DOCTYPE  == 0 ? "NULL" : DB.SetDouble(_DOCTYPE )) + ", ";
                sql += DB.SetString(_INVCODE) + ", ";
                sql += DB.SetString(_ISVAT) + ", ";
                sql += DB.SetDouble(_LOID) + ", ";
                sql += (_PLANORDER == 0 ? "NULL" : DB.SetDouble (_PLANORDER )) + ", ";
                sql +=(_PO == 0 ? "NULL" : DB.SetDouble (_PO )) + ", ";
                sql += DB.SetString(_REFCODE) + ", ";
                sql += DB.SetString(_STATUS) + ", ";
                sql += DB.SetDateTime(_STOCKINDATE) + ", ";
                sql += (_WAREHOUSE == 0 ? "NULL" : DB.SetDouble(_WAREHOUSE)) + ", ";
                sql += (_SAPWAREHOUSE == 0 ? "NULL" : DB.SetDouble(_SAPWAREHOUSE)) + ", ";
                sql += DB.SetString(_REMARKS ) + "  ";
                sql += ")";
                return sql;
            }
        }
        
        /// <summary>
        /// Gets the update statement for STOCKIN table.
        /// </summary>
        private string sql_update
        {
            get
            {
                string sql = "UPDATE " + tableName + " SET ";
                sql += "CODE = " + (_CODE == "" ? "NULL" : DB.SetString(_CODE)) + ", ";
                sql += "DIVISION = " + DB.SetDouble(_DIVISION) + ", ";
                sql += "DOCTYPE = " + DB.SetDouble(_DOCTYPE) + ", ";
                sql += "INVCODE = " + DB.SetString(_INVCODE) + ", ";
                sql += "ISVAT = " + DB.SetString(_ISVAT) + ", ";
                sql += "PLANORDER = " + (_PLANORDER == 0 ? "NULL" : DB.SetDouble(_PLANORDER)) + ", ";
                sql += "PO = " + (_PO == 0 ? "NULL" :DB.SetDouble(_PO)) + ", ";
                sql += "REFCODE = " + DB.SetString(_REFCODE) + ", ";
                sql += "STATUS = " + DB.SetString(_STATUS) + ", ";
                sql += "STOCKINDATE = " + DB.SetDateTime(_STOCKINDATE) + ", ";
                sql += "UPDATEBY = " + DB.SetString(_UPDATEBY) + ", ";
                sql += "UPDATEON = " + DB.SetDateTime(_UPDATEON) + ", ";
                sql += "WAREHOUSE = " + (_WAREHOUSE == 0 ? "NULL" : DB.SetDouble(_WAREHOUSE)) + ", ";
                sql += "SAPWAREHOUSE = " + (_SAPWAREHOUSE == 0 ? "NULL" : DB.SetDouble(_SAPWAREHOUSE)) + ", ";
                sql += "REMARKS = " + DB.SetString(_REMARKS ) + "  ";
                return sql;
            }
        }

        /// <summary>
        /// Gets the delete statement for STOCKIN table.
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
        /// Gets the select statement for STOCKIN table.
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
        /// Returns an indication whether the current data is inserted into STOCKIN table successfully.
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
        /// Returns an indication whether the current data is updated to STOCKIN table successfully.
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
        /// Returns an indication whether the current data is deleted from STOCKIN table successfully.
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
        /// Returns an indication whether the record of STOCKIN by specified condition is retrieved successfully.
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
                        if (!Convert.IsDBNull(zRdr["INVCODE"])) _INVCODE = zRdr["INVCODE"].ToString();
                        if (!Convert.IsDBNull(zRdr["ISVAT"])) _ISVAT = zRdr["ISVAT"].ToString();
                        if (!Convert.IsDBNull(zRdr["LOID"])) _LOID = Convert.ToDouble(zRdr["LOID"]);
                        if (!Convert.IsDBNull(zRdr["PLANORDER"])) _PLANORDER = Convert.ToDouble(zRdr["PLANORDER"]);
                        if (!Convert.IsDBNull(zRdr["PO"])) _PO = Convert.ToDouble(zRdr["PO"]);
                        if (!Convert.IsDBNull(zRdr["REFCODE"])) _REFCODE = zRdr["REFCODE"].ToString();
                        if (!Convert.IsDBNull(zRdr["STATUS"])) _STATUS = zRdr["STATUS"].ToString();
                        if (!Convert.IsDBNull(zRdr["STOCKINDATE"])) _STOCKINDATE = Convert.ToDateTime(zRdr["STOCKINDATE"]);
                        if (!Convert.IsDBNull(zRdr["UPDATEBY"])) _UPDATEBY = zRdr["UPDATEBY"].ToString();
                        if (!Convert.IsDBNull(zRdr["UPDATEON"])) _UPDATEON = Convert.ToDateTime(zRdr["UPDATEON"]);
                        if (!Convert.IsDBNull(zRdr["WAREHOUSE"])) _WAREHOUSE = Convert.ToDouble(zRdr["WAREHOUSE"]);
                        if (!Convert.IsDBNull(zRdr["SAPWAREHOUSE"])) _WAREHOUSE = Convert.ToDouble(zRdr["SAPWAREHOUSE"]);
                        if (!Convert.IsDBNull(zRdr["REMARKS"])) _REMARKS  = zRdr["REMARKS"].ToString();
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
    }
}