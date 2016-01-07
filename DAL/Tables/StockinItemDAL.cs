using System;
using System.Data;
using System.Data.OracleClient;
using DB = SHND.DAL.Utilities.OracleDB;
using SHND.Data.Common.Utilities;

namespace SHND.DAL.Tables
{
    /// <summary>
    /// Represents a transaction for STOCKINITEM table.
    /// [Created by 127.0.0.1 on Febuary,20 2009]
    /// </summary>
    public class StockinItemDAL
    {

        public StockinItemDAL()
        {
        }

        #region Constant

        /// <summary>STOCKINITEM</summary>
        private const string tableName = "STOCKINITEM";

        #endregion

        #region Private Variables

        int _deletedRow = 0;
        string _error = "";
        string _information = "";
        bool _OnDB = false;
        string _BRAND = "";
        string _CREATEBY = "";
        DateTime _CREATEON = new DateTime(1, 1, 1);
        double _GUARANTEE = 0;
        double _LOID = 0;
        string _LOTNO = "";
        double _MATERIALMASTER = 0;
        double _PLANREMAINQTY = 0;
        double _PRICE = 0;
        double _QTY = 0;
        double _REFLOID = 0;
        string _REFTABLE = "";
        string _SAPPOCODE = "";
        DateTime _SAPPODATE = new DateTime(1, 1, 1);
        double _SAPWAREHOUSE = 0;
        double _STOCKIN = 0;
        double _UNIT = 0;
        string _UPDATEBY = "";
        DateTime _UPDATEON = new DateTime(1, 1, 1);
        double _USEQTY = 0;
        double _WASTEQTY = 0;
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
        public string BRAND
        {
            get { return _BRAND; }
            set { _BRAND = value; }
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
        public double GUARANTEE
        {
            get { return _GUARANTEE; }
            set { _GUARANTEE = value; }
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
        public double PLANREMAINQTY
        {
            get { return _PLANREMAINQTY; }
            set { _PLANREMAINQTY = value; }
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
        public double REFLOID
        {
            get { return _REFLOID; }
            set { _REFLOID = value; }
        }
        public string REFTABLE
        {
            get { return _REFTABLE; }
            set { _REFTABLE = value; }
        }
        public string SAPPOCODE
        {
            get { return _SAPPOCODE; }
            set { _SAPPOCODE = value; }
        }
        public DateTime SAPPODATE
        {
            get { return _SAPPODATE; }
            set { _SAPPODATE = value; }
        }
        public double SAPWAREHOUSE
        {
            get { return _SAPWAREHOUSE; }
            set { _SAPWAREHOUSE = value; }
        }
        public double STOCKIN
        {
            get { return _STOCKIN; }
            set { _STOCKIN = value; }
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
        public double WASTEQTY
        {
            get { return _WASTEQTY; }
            set { _WASTEQTY = value; }
        }
        public string REMARKS
        {
            get { return _REMARKS; }
            set { _REMARKS = value; }
        }
        

        #endregion

        #region Clear Data

        /// <summary>
        /// Initialize data.
        /// </summary>
        private void ClearData()
        {
            _BRAND = "";
            _CREATEBY = "";
            _CREATEON = new DateTime(1, 1, 1);
            _GUARANTEE = 0;
            _LOID = 0;
            _LOTNO = "";
            _MATERIALMASTER = 0;
            _PLANREMAINQTY = 0;
            _PRICE = 0;
            _QTY = 0;
            _REFLOID = 0;
            _REFTABLE = "";
            _SAPPOCODE = "";
            _SAPPODATE = new DateTime(1, 1, 1);
            _SAPWAREHOUSE = 0;
            _STOCKIN = 0;
            _UNIT = 0;
            _UPDATEBY = "";
            _UPDATEON = new DateTime(1, 1, 1);
            _USEQTY = 0;
            _WASTEQTY = 0;
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
        /// Returns an indication whether the current data is inserted into STOCKINITEM table successfully.
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
        /// Returns an indication whether the current data is updated to STOCKINITEM table successfully.
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
        /// Returns an indication whether the current data is deleted from STOCKINITEM table successfully.
        /// </summary>
        /// <param name="trans">The System.Data.OracleClient.OracleTransaction used by this System.Data.OracleClient.OracleCommand.</param>
        /// <returns>true if delete data successfully; otherwise, false.</returns>
        public bool DeleteCurrentData(OracleTransaction trans)
        {
            return doDelete("LOID = " + DB.SetDouble(_LOID) + " ", trans);
        }

        /// <summary>
        /// Returns an indication whether the record of STOCKINITEM by specified LOID key is retrieved successfully.
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
        /// Gets the insert statement for STOCKINITEM table.
        /// </summary>
        private string sql_insert
        {
            get
            {
                string sql = "INSERT INTO " + tableName + "(BRAND, CREATEBY, CREATEON, GUARANTEE, LOID, LOTNO, MATERIALMASTER, PLANREMAINQTY, PRICE, QTY, REFLOID, REFTABLE, SAPPOCODE, SAPPODATE, SAPWAREHOUSE, STOCKIN, UNIT, USEQTY,REMARKS, WASTEQTY) ";
                sql += "VALUES (";
                sql += DB.SetString(_BRAND) + ", ";
                sql += DB.SetString(_CREATEBY) + ", ";
                sql += DB.SetDateTime(_CREATEON) + ", ";
                sql += DB.SetDouble(_GUARANTEE) + ", ";
                sql += DB.SetDouble(_LOID) + ", ";
                sql += DB.SetString(_LOTNO) + ", ";
                sql += DB.SetDouble(_MATERIALMASTER) + ", ";
                sql += DB.SetDouble(_PLANREMAINQTY) + ", ";
                sql += (_PRICE == 0 ? "0" : DB.SetDouble(_PRICE)) + ", ";
                sql += DB.SetDouble(_QTY) + ", ";
                sql += DB.SetDouble(_REFLOID) + ", ";
                sql += DB.SetString(_REFTABLE) + ", ";
                sql += DB.SetString(_SAPPOCODE) + ", ";
                sql += DB.SetDateTime(_SAPPODATE) + ", ";
                sql += DB.SetDouble(_SAPWAREHOUSE) + ", ";
                sql += DB.SetDouble(_STOCKIN ) + ", ";
                sql += DB.SetDouble(_UNIT) + ", ";
                sql += DB.SetDouble(_USEQTY) + ", ";
                sql += DB.SetString (_REMARKS) + ", ";
                sql += DB.SetDouble(_WASTEQTY) + " ";
                sql += ")";
                return sql;
            }
        }

        /// <summary>
        /// Gets the update statement for STOCKINITEM table.
        /// </summary>
        private string sql_update
        {
            get
            {
                string sql = "UPDATE " + tableName + " SET ";
                sql += "BRAND = " + DB.SetString(_BRAND) + ", ";
                sql += "GUARANTEE = " + DB.SetDouble(_GUARANTEE) + ", ";
                sql += "LOTNO = " + DB.SetString(_LOTNO) + ", ";
                sql += "MATERIALMASTER = " + DB.SetDouble(_MATERIALMASTER) + ", ";
                sql += "PLANREMAINQTY = " + DB.SetDouble(_PLANREMAINQTY) + ", ";
                sql += "PRICE = " + (_PRICE == 0 ? "0" : DB.SetDouble(_PRICE)) + ", ";
                sql += "QTY = " + DB.SetDouble(_QTY) + ", ";
                sql += "REFLOID = " + DB.SetDouble(_REFLOID) + ", ";
                sql += "REFTABLE = " + DB.SetString(_REFTABLE) + ", ";
                sql += "SAPPOCODE = " + DB.SetString(_SAPPOCODE) + ", ";
                sql += "SAPPODATE = " + DB.SetDateTime(_SAPPODATE) + ", ";
                sql += "SAPWAREHOUSE = " + DB.SetDouble(_SAPWAREHOUSE) + ", ";
                sql += "STOCKIN = " + DB.SetDouble(_STOCKIN) + ", ";
                sql += "UNIT = " + DB.SetDouble(_UNIT) + ", ";
                sql += "UPDATEBY = " + DB.SetString(_UPDATEBY) + ", ";
                sql += "UPDATEON = " + DB.SetDateTime(_UPDATEON) + ", ";
                sql += "USEQTY = " + DB.SetDouble(_USEQTY) + ", ";
                sql += "REMARKS = " + DB.SetString (_REMARKS ) + ", ";
                sql += "WASTEQTY = " + DB.SetDouble(_WASTEQTY) + " ";
                return sql;
            }
        }

        /// <summary>
        /// Gets the delete statement for STOCKINITEM table.
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
        /// Gets the select statement for STOCKINITEM table.
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
        /// Returns an indication whether the current data is inserted into STOCKINITEM table successfully.
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
        /// Returns an indication whether the current data is updated to STOCKINITEM table successfully.
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
        /// Returns an indication whether the current data is deleted from STOCKINITEM table successfully.
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
        /// Returns an indication whether the record of STOCKINITEM by specified condition is retrieved successfully.
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
                        if (!Convert.IsDBNull(zRdr["BRAND"])) _BRAND = zRdr["BRAND"].ToString();
                        if (!Convert.IsDBNull(zRdr["CREATEBY"])) _CREATEBY = zRdr["CREATEBY"].ToString();
                        if (!Convert.IsDBNull(zRdr["CREATEON"])) _CREATEON = Convert.ToDateTime(zRdr["CREATEON"]);
                        if (!Convert.IsDBNull(zRdr["GUARANTEE"])) _GUARANTEE = Convert.ToDouble(zRdr["GUARANTEE"]);
                        if (!Convert.IsDBNull(zRdr["LOID"])) _LOID = Convert.ToDouble(zRdr["LOID"]);
                        if (!Convert.IsDBNull(zRdr["LOTNO"])) _LOTNO = zRdr["LOTNO"].ToString();
                        if (!Convert.IsDBNull(zRdr["MATERIALMASTER"])) _MATERIALMASTER = Convert.ToDouble(zRdr["MATERIALMASTER"]);
                        if (!Convert.IsDBNull(zRdr["PLANREMAINQTY"])) _PLANREMAINQTY = Convert.ToDouble(zRdr["PLANREMAINQTY"]);
                        if (!Convert.IsDBNull(zRdr["PRICE"])) _PRICE = Convert.ToDouble(zRdr["PRICE"]);
                        if (!Convert.IsDBNull(zRdr["QTY"])) _QTY = Convert.ToDouble(zRdr["QTY"]);
                        if (!Convert.IsDBNull(zRdr["REFLOID"])) _REFLOID = Convert.ToDouble(zRdr["REFLOID"]);
                        if (!Convert.IsDBNull(zRdr["REFTABLE"])) _REFTABLE = zRdr["REFTABLE"].ToString();
                        if (!Convert.IsDBNull(zRdr["SAPPOCODE"])) _SAPPOCODE = zRdr["SAPPOCODE"].ToString();
                        if (!Convert.IsDBNull(zRdr["SAPPODATE"])) _SAPPODATE = Convert.ToDateTime(zRdr["SAPPODATE"]);
                        if (!Convert.IsDBNull(zRdr["SAPWAREHOUSE"])) _SAPWAREHOUSE = Convert.ToDouble(zRdr["SAPWAREHOUSE"]);
                        if (!Convert.IsDBNull(zRdr["STOCKIN"])) _STOCKIN = Convert.ToDouble(zRdr["STOCKIN"]);
                        if (!Convert.IsDBNull(zRdr["UNIT"])) _UNIT = Convert.ToDouble(zRdr["UNIT"]);
                        if (!Convert.IsDBNull(zRdr["UPDATEBY"])) _UPDATEBY = zRdr["UPDATEBY"].ToString();
                        if (!Convert.IsDBNull(zRdr["UPDATEON"])) _UPDATEON = Convert.ToDateTime(zRdr["UPDATEON"]);
                        if (!Convert.IsDBNull(zRdr["USEQTY"])) _USEQTY = Convert.ToDouble(zRdr["USEQTY"]);
                        if (!Convert.IsDBNull(zRdr["REMARKS"])) _REMARKS = zRdr["REMARKS"].ToString();
                        if (!Convert.IsDBNull(zRdr["WASTEQTY"])) _WASTEQTY = Convert.ToDouble(zRdr["WASTEQTY"]);
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
        public bool DeleteDataBySTOCKIN(double cSTOCKIN, OracleTransaction trans)
        {
            return doDelete("STOCKIN = " + DB.SetDouble(cSTOCKIN) + " ", trans);
        }
        public bool UpdateDataBySTOCKIN(double cSTOCKIN, string userID, OracleTransaction trans)
        {
            return doUpdate("STOCKIN = " + DB.SetDouble(cSTOCKIN) + "  ", trans);
        }
    }
}