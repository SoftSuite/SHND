using System;
using System.Data;
using System.Data.OracleClient;
using DB = SHND.DAL.Utilities.OracleDB;
using SHND.Data.Common.Utilities;

namespace SHND.DAL.Tables
{
    /// <summary>
    /// Represents a transaction for STOCKOUTITEM table.
    /// [Created by 127.0.0.1 on Febuary,12 2009]
    /// </summary>
    public class StockoutitemDAL
    {

        public StockoutitemDAL()
        {
        }

        #region Constant

        /// <summary>STOCKOUTITEM</summary>
        private const string tableName = "STOCKOUTITEM";

        #endregion

        #region Private Variables

        int _deletedRow = 0;
        string _error = "";
        string _information = "";
        bool _OnDB = false;
        string _CREATEBY = "";
        DateTime _CREATEON = new DateTime(1, 1, 1);
        DateTime _FINISHDATE = new DateTime(1, 1, 1);
        double _FLOOR = 0;
        string _ISMENU = "";
        string _ITEMNAME = "";
        double _LOID = 0;
        string _LOTNO = "";
        double _MATERIALMASTER = 0;
        double _PRICE = 0;
        double _QTY = 0;
        string _REMARKS = "";
        string _REPAIRBY = "";
        string _REPAIRREMARKS = "";
        string _REPAIRSTATUS = "";
        double _REQQTY = 0;
        string _STATUS = "";
        double _STOCKOUT = 0;
        double _UNIT = 0;
        string _UPDATEBY = "";
        DateTime _UPDATEON = new DateTime(1, 1, 1);
        double _USEQTY = 0;
        string _BRAND = "";

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
        public DateTime FINISHDATE
        {
            get { return _FINISHDATE; }
            set { _FINISHDATE = value; }
        }
        public double FLOOR
        {
            get { return _FLOOR; }
            set { _FLOOR = value; }
        }
        public string ISMENU
        {
            get { return _ISMENU; }
            set { _ISMENU = value; }
        }
        public string ITEMNAME
        {
            get { return _ITEMNAME; }
            set { _ITEMNAME = value; }
        }
        public double LOID
        {
            get { return _LOID; }
            set { _LOID = value; }
        }
        public string LOTNO
        {
            get { return _LOTNO; }
            set { _LOTNO = value; }
        }
        public double MATERIALMASTER
        {
            get { return _MATERIALMASTER; }
            set { _MATERIALMASTER = value; }
        }
        public double PRICE
        {
            get { return _PRICE; }
            set { _PRICE = value; }
        }
        public double QTY
        {
            get { return _QTY; }
            set { _QTY = value; }
        }
        public string REMARKS
        {
            get { return _REMARKS; }
            set { _REMARKS = value; }
        }
        public string REPAIRBY
        {
            get { return _REPAIRBY; }
            set { _REPAIRBY = value; }
        }
        public string REPAIRREMARKS
        {
            get { return _REPAIRREMARKS; }
            set { _REPAIRREMARKS = value; }
        }
        public string REPAIRSTATUS
        {
            get { return _REPAIRSTATUS; }
            set { _REPAIRSTATUS = value; }
        }
        public double REQQTY
        {
            get { return _REQQTY; }
            set { _REQQTY = value; }
        }
        public string STATUS
        {
            get { return _STATUS; }
            set { _STATUS = value; }
        }
        public double STOCKOUT
        {
            get { return _STOCKOUT; }
            set { _STOCKOUT = value; }
        }
        public double UNIT
        {
            get { return _UNIT; }
            set { _UNIT = value; }
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

        public double USEQTY
        {
            get { return _USEQTY; }
            set { _USEQTY = value; }
        }
        public string BRAND
        {
            get { return _BRAND; }
            set { _BRAND = value; }
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
            _FINISHDATE = new DateTime(1, 1, 1);
            _FLOOR = 0;
            _ISMENU = "";
            _ITEMNAME = "";
            _LOID = 0;
            _LOTNO = "";
            _MATERIALMASTER = 0;
            _PRICE = 0;
            _QTY = 0;
            _REMARKS = "";
            _REPAIRBY = "";
            _REPAIRREMARKS = "";
            _REPAIRSTATUS = "";
            _REQQTY = 0;
            _STATUS = "";
            _STOCKOUT = 0;
            _UNIT = 0;
            _UPDATEBY = "";
            _UPDATEON = new DateTime(1, 1, 1);
            _USEQTY = 0;
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
        /// Returns an indication whether the current data is inserted into STOCKOUTITEM table successfully.
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

        //public bool InsertSendSuppData(string userID, DataTable dt, OracleTransaction trans)
        //{
        //    bool ret = true;
        //}

        /// <summary>
        /// Returns an indication whether the current data is updated to STOCKOUTITEM table successfully.
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
        /// Returns an indication whether the current data is deleted from STOCKOUTITEM table successfully.
        /// </summary>
        /// <param name="trans">The System.Data.OracleClient.OracleTransaction used by this System.Data.OracleClient.OracleCommand.</param>
        /// <returns>true if delete data successfully; otherwise, false.</returns>
        public bool DeleteCurrentData(OracleTransaction trans)
        {
            return doDelete("LOID = " + DB.SetDouble(_LOID) + " ", trans);
        }

        /// <summary>
        /// Returns an indication whether the record of STOCKOUTITEM by specified LOID key is retrieved successfully.
        /// </summary>
        /// <param name="cLOID">The LOID key.</param>
        /// <param name="trans">The System.Data.OracleClient.OracleTransaction used by this System.Data.OracleClient.OracleCommand.</param>
        /// <returns>true if data is retrieved successfully; otherwise, false.</returns>
        public bool GetDataByLOID(double cLOID, OracleTransaction trans)
        {
            return doGetdata("LOID = " + DB.SetDouble(cLOID) + " ", trans);
        }
        /// <summary>
        /// Returns an indication whether the record of STOCKOUTITEM by specified STOCKOUT key is retrieved successfully.
        /// </summary>
        /// <param name="cLOID">The LOID key.</param>
        /// <param name="trans">The System.Data.OracleClient.OracleTransaction used by this System.Data.OracleClient.OracleCommand.</param>
        /// <returns>true if data is retrieved successfully; otherwise, false.</returns>
        public bool GetDataBySTOCKOUT(double cLOID, OracleTransaction trans)
        {
            return doGetdata("STOCKOUT = " + DB.SetDouble(cLOID) + " ", trans);
        }
        #endregion

        #region SQL Statements

        /// <summary>
        /// Gets the insert statement for STOCKOUTITEM table.
        /// </summary>
        private string sql_insert
        {
            get
            {
                string sql = "INSERT INTO " + tableName + "(CREATEBY, CREATEON, FINISHDATE, FLOOR, ISMENU, ITEMNAME, LOID, LOTNO, MATERIALMASTER, PRICE, QTY, REMARKS, REPAIRBY, REPAIRREMARKS, REPAIRSTATUS, REQQTY, STATUS, STOCKOUT, UNIT,USEQTY, BRAND) ";
                sql += "VALUES (";
                sql += DB.SetString(_CREATEBY) + ", ";
                sql += DB.SetDateTime(_CREATEON) + ", ";
                sql += DB.SetDateTime(_FINISHDATE) + ", ";
                sql += DB.SetDouble(_FLOOR) + ", ";
                sql += DB.SetString(_ISMENU) + ", ";
                sql += DB.SetString(_ITEMNAME) + ", ";
                sql += DB.SetDouble(_LOID) + ", ";
                sql += DB.SetString(_LOTNO) + ", ";
                sql += DB.SetDouble(_MATERIALMASTER) + ", ";
                sql += DB.SetDouble(_PRICE) + ", ";
                sql += DB.SetDouble(_QTY) + ", ";
                sql += DB.SetString(_REMARKS) + ", ";
                sql += DB.SetString(_REPAIRBY) + ", ";
                sql += DB.SetString(_REPAIRREMARKS) + ", ";
                sql += DB.SetString(_REPAIRSTATUS) + ", ";
                sql += DB.SetDouble(_REQQTY) + ", ";
                sql += DB.SetString(_STATUS) + ", ";
                sql += DB.SetDouble(_STOCKOUT) + ", ";
                sql += DB.SetDouble(_UNIT) + ", ";
                sql += DB.SetDouble(_USEQTY) + ", ";
                sql += DB.SetString(_BRAND) + " ";
                sql += ")";
                return sql;
            }
        }

        /// <summary>
        /// Gets the update statement for STOCKOUTITEM table.
        /// </summary>
        private string sql_update
        {
            get
            {
                string sql = "UPDATE " + tableName + " SET ";
                sql += "FINISHDATE = " + DB.SetDateTime(_FINISHDATE) + ", ";
                sql += "FLOOR = " + DB.SetDouble(_FLOOR) + ", ";
                sql += "ISMENU = " + DB.SetString(_ISMENU) + ", ";
                sql += "ITEMNAME = " + DB.SetString(_ITEMNAME) + ", ";
                sql += "LOTNO = " + DB.SetString(_LOTNO) + ", ";
                sql += "MATERIALMASTER = " + DB.SetDouble(_MATERIALMASTER) + ", ";
                sql += "PRICE = " + DB.SetDouble(_PRICE) + ", ";
                sql += "QTY = " + DB.SetDouble(_QTY) + ", ";
                sql += "REMARKS = " + DB.SetString(_REMARKS) + ", ";
                sql += "REPAIRBY = " + DB.SetString(_REPAIRBY) + ", ";
                sql += "REPAIRREMARKS = " + DB.SetString(_REPAIRREMARKS) + ", ";
                sql += "REPAIRSTATUS = " + DB.SetString(_REPAIRSTATUS) + ", ";
                sql += "REQQTY = " + DB.SetDouble(_REQQTY) + ", ";
                sql += "STATUS = " + DB.SetString(_STATUS) + ", ";
                sql += "STOCKOUT = " + DB.SetDouble(_STOCKOUT) + ", ";
                sql += "UNIT = " + DB.SetDouble(_UNIT) + ", ";
                sql += "UPDATEBY = " + DB.SetString(_UPDATEBY) + ", ";
                sql += "UPDATEON = " + DB.SetDateTime(_UPDATEON) + ", ";
                sql += "USEQTY = " + DB.SetDouble(_USEQTY) + ", ";
                sql += "BRAND = " + DB.SetString(_BRAND) + " ";
                return sql;
            }
        }

        /// <summary>
        /// Gets the delete statement for STOCKOUTITEM table.
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
        /// Gets the select statement for STOCKOUTITEM table.
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
        /// Returns an indication whether the current data is inserted into STOCKOUTITEM table successfully.
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
        /// Returns an indication whether the current data is updated to STOCKOUTITEM table successfully.
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
        /// Returns an indication whether the current data is deleted from STOCKOUTITEM table successfully.
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
        /// Returns an indication whether the record of STOCKOUTITEM by specified condition is retrieved successfully.
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
                        if (!Convert.IsDBNull(zRdr["FINISHDATE"])) _FINISHDATE = Convert.ToDateTime(zRdr["FINISHDATE"]);
                        if (!Convert.IsDBNull(zRdr["FLOOR"])) _FLOOR = Convert.ToDouble(zRdr["FLOOR"]);
                        if (!Convert.IsDBNull(zRdr["ISMENU"])) _ISMENU = zRdr["ISMENU"].ToString();
                        if (!Convert.IsDBNull(zRdr["ITEMNAME"])) _ITEMNAME = zRdr["ITEMNAME"].ToString();
                        if (!Convert.IsDBNull(zRdr["LOID"])) _LOID = Convert.ToDouble(zRdr["LOID"]);
                        if (!Convert.IsDBNull(zRdr["LOTNO"])) _LOTNO = zRdr["LOTNO"].ToString();
                        if (!Convert.IsDBNull(zRdr["MATERIALMASTER"])) _MATERIALMASTER = Convert.ToDouble(zRdr["MATERIALMASTER"]);
                        if (!Convert.IsDBNull(zRdr["PRICE"])) _PRICE = Convert.ToDouble(zRdr["PRICE"]);
                        if (!Convert.IsDBNull(zRdr["QTY"])) _QTY = Convert.ToDouble(zRdr["QTY"]);
                        if (!Convert.IsDBNull(zRdr["REMARKS"])) _REMARKS = zRdr["REMARKS"].ToString();
                        if (!Convert.IsDBNull(zRdr["REPAIRBY"])) _REPAIRBY = zRdr["REPAIRBY"].ToString();
                        if (!Convert.IsDBNull(zRdr["REPAIRREMARKS"])) _REPAIRREMARKS = zRdr["REPAIRREMARKS"].ToString();
                        if (!Convert.IsDBNull(zRdr["REPAIRSTATUS"])) _REPAIRSTATUS = zRdr["REPAIRSTATUS"].ToString();
                        if (!Convert.IsDBNull(zRdr["REQQTY"])) _REQQTY = Convert.ToDouble(zRdr["REQQTY"]);
                        if (!Convert.IsDBNull(zRdr["STATUS"])) _STATUS = zRdr["STATUS"].ToString();
                        if (!Convert.IsDBNull(zRdr["STOCKOUT"])) _STOCKOUT = Convert.ToDouble(zRdr["STOCKOUT"]);
                        if (!Convert.IsDBNull(zRdr["UNIT"])) _UNIT = Convert.ToDouble(zRdr["UNIT"]);
                        if (!Convert.IsDBNull(zRdr["UPDATEBY"])) _UPDATEBY = zRdr["UPDATEBY"].ToString();
                        if (!Convert.IsDBNull(zRdr["UPDATEON"])) _UPDATEON = Convert.ToDateTime(zRdr["UPDATEON"]);
                        if (!Convert.IsDBNull(zRdr["USEQTY"])) _USEQTY = Convert.ToDouble(zRdr["USEQTY"]);
                        if (!Convert.IsDBNull(zRdr["BRAND"])) _BRAND = zRdr["BRAND"].ToString();
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

        public bool DeleteDataByStockout(double cSTOCKOUT, string exceptLoidList, OracleTransaction trans)
        {
            return doDelete("STOCKOUT = " + DB.SetDouble(cSTOCKOUT) + " " + (exceptLoidList == "" ? "" : ("AND LOID NOT IN (" + exceptLoidList + ")")), trans);
        }

        public bool DeleteDataBySTOCKOUT(double cSTOCKOUT, OracleTransaction trans)
        {
            return doDelete("STOCKOUT = " + DB.SetDouble(cSTOCKOUT) + " ", trans);
        }

        public bool UpdateStatusByStockOut(double cSTOCKOUT, string cSTATUS, string userID, OracleTransaction trans)
        {
            bool ret = true;
            int affectedRow = 0;
            try
            {
                affectedRow = DB.ExecuteNonQuery("UPDATE " + tableName + " SET STATUS = " + DB.SetString(cSTATUS) + ", UPDATEON = SYSDATE, UPDATEBY = " + DB.SetString(userID) + " WHERE STOCKOUT = " + DB.SetDouble(cSTOCKOUT), trans);
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
            return ret;
        }


        #region My Work Nang


        public bool DeleteDataByStockOut(double soloid ,OracleTransaction trans)
        {
            return doDelete("STOCKOUT = " + soloid + " ", trans);
        }

        public DataTable GetDataByField(string whereClause, string orderBy, OracleTransaction trans)
        {
            return DB.ExecuteTable(sql_field + (whereClause == "" ? "" : "WHERE " + whereClause + " ") + (orderBy == "" ? "" : "ORDER BY " + DB.SetSortString(orderBy)), trans);
        }

        private string sql_field
        {
            get
            {
                string sql = "SELECT STOCKOUT SOLOID, SOI.LOID SOILOID, U.LOID UULOID, ";
                       sql += " U.THNAME UNAME, MM.CODE MMCODE, MM.NAME MMNAME, QTY, SOI.REMARKS, MM.LOID MMLOID ";
                       sql += " FROM STOCKOUTITEM SOI INNER JOIN MATERIALMASTER MM ON MM.LOID = SOI.MATERIALMASTER ";
                       sql += " INNER JOIN UNIT U ON SOI.UNIT = U.LOID ";
                return sql;
            }
        }

        public bool DeleteNotInLOIDList(string siloidlist, string stockout_loid, OracleTransaction trans)
        {
            string whrStr = "";
            if (siloidlist != "")
                whrStr = "STOCKOUT = " + stockout_loid + " AND LOID NOT IN (" + siloidlist + ")";
            else
                whrStr = "STOCKOUT = " + stockout_loid;

            bool ret = true;
            _deletedRow = 0;
            if (whrStr.Trim() != "")
            {
                string tmpWhere = "WHERE " + whrStr;
                try
                {
                    _deletedRow = DB.ExecuteNonQuery(sql_delete + tmpWhere, trans);
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

        #endregion
    }
}
