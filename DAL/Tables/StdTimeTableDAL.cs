using System;
using System.Data;
using System.Data.OracleClient;
using DB = SHND.DAL.Utilities.OracleDB;
using SHND.Data.Common.Utilities;

namespace SHND.DAL.Tables
{
    /// <summary>
    /// Represents a transaction for STDTIMETABLE table.
    /// [Created by 127.0.0.1 on March,16 2009]
    /// </summary>
    public class StdTimeTableDAL
    {

        public StdTimeTableDAL()
        {
        }

        #region Constant

        /// <summary>STDTIMETABLE</summary>
        private const string tableName = "STDTIMETABLE";

        #endregion

        #region Private Variables

        int _deletedRow = 0;
        string _error = "";
        string _information = "";
        bool _OnDB = false;
        double _LOID = 0;
        double _MEALQTY = 0;
        string _TIME1 = "";
        string _TIME10 = "";
        string _TIME11 = "";
        string _TIME12 = "";
        string _TIME13 = "";
        string _TIME14 = "";
        string _TIME15 = "";
        string _TIME16 = "";
        string _TIME17 = "";
        string _TIME18 = "";
        string _TIME19 = "";
        string _TIME2 = "";
        string _TIME20 = "";
        string _TIME21 = "";
        string _TIME22 = "";
        string _TIME23 = "";
        string _TIME24 = "";
        string _TIME3 = "";
        string _TIME4 = "";
        string _TIME5 = "";
        string _TIME6 = "";
        string _TIME7 = "";
        string _TIME8 = "";
        string _TIME9 = "";
        string _USEFOR = "";

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
        public double LOID
        {
            get { return _LOID; }
            set { _LOID = value; }
        }
        public double MEALQTY
        {
            get { return _MEALQTY; }
            set { _MEALQTY = value; }
        }
        public string TIME1
        {
            get { return _TIME1; }
            set { _TIME1 = value; }
        }
        public string TIME10
        {
            get { return _TIME10; }
            set { _TIME10 = value; }
        }
        public string TIME11
        {
            get { return _TIME11; }
            set { _TIME11 = value; }
        }
        public string TIME12
        {
            get { return _TIME12; }
            set { _TIME12 = value; }
        }
        public string TIME13
        {
            get { return _TIME13; }
            set { _TIME13 = value; }
        }
        public string TIME14
        {
            get { return _TIME14; }
            set { _TIME14 = value; }
        }
        public string TIME15
        {
            get { return _TIME15; }
            set { _TIME15 = value; }
        }
        public string TIME16
        {
            get { return _TIME16; }
            set { _TIME16 = value; }
        }
        public string TIME17
        {
            get { return _TIME17; }
            set { _TIME17 = value; }
        }
        public string TIME18
        {
            get { return _TIME18; }
            set { _TIME18 = value; }
        }
        public string TIME19
        {
            get { return _TIME19; }
            set { _TIME19 = value; }
        }
        public string TIME2
        {
            get { return _TIME2; }
            set { _TIME2 = value; }
        }
        public string TIME20
        {
            get { return _TIME20; }
            set { _TIME20 = value; }
        }
        public string TIME21
        {
            get { return _TIME21; }
            set { _TIME21 = value; }
        }
        public string TIME22
        {
            get { return _TIME22; }
            set { _TIME22 = value; }
        }
        public string TIME23
        {
            get { return _TIME23; }
            set { _TIME23 = value; }
        }
        public string TIME24
        {
            get { return _TIME24; }
            set { _TIME24 = value; }
        }
        public string TIME3
        {
            get { return _TIME3; }
            set { _TIME3 = value; }
        }
        public string TIME4
        {
            get { return _TIME4; }
            set { _TIME4 = value; }
        }
        public string TIME5
        {
            get { return _TIME5; }
            set { _TIME5 = value; }
        }
        public string TIME6
        {
            get { return _TIME6; }
            set { _TIME6 = value; }
        }
        public string TIME7
        {
            get { return _TIME7; }
            set { _TIME7 = value; }
        }
        public string TIME8
        {
            get { return _TIME8; }
            set { _TIME8 = value; }
        }
        public string TIME9
        {
            get { return _TIME9; }
            set { _TIME9 = value; }
        }
        public string USEFOR
        {
            get { return _USEFOR; }
            set { _USEFOR = value; }
        }

        #endregion

        #region Clear Data

        /// <summary>
        /// Initialize data.
        /// </summary>
        private void ClearData()
        {
            _LOID = 0;
            _MEALQTY = 0;
            _TIME1 = "";
            _TIME10 = "";
            _TIME11 = "";
            _TIME12 = "";
            _TIME13 = "";
            _TIME14 = "";
            _TIME15 = "";
            _TIME16 = "";
            _TIME17 = "";
            _TIME18 = "";
            _TIME19 = "";
            _TIME2 = "";
            _TIME20 = "";
            _TIME21 = "";
            _TIME22 = "";
            _TIME23 = "";
            _TIME24 = "";
            _TIME3 = "";
            _TIME4 = "";
            _TIME5 = "";
            _TIME6 = "";
            _TIME7 = "";
            _TIME8 = "";
            _TIME9 = "";
            _USEFOR = "";
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
        /// Returns an indication whether the current data is inserted into STDTIMETABLE table successfully.
        /// </summary>
        /// <param name="userID">The current user.</param>
        /// <param name="trans">The System.Data.OracleClient.OracleTransaction used by this System.Data.OracleClient.OracleCommand.</param>
        /// <returns>true if insert data successfully; otherwise, false.</returns>
        public bool InsertCurrentData(string userID, OracleTransaction trans)
        {
            _LOID = DB.GetNextID(TableName, trans);
            return doInsert(trans);
        }

        /// <summary>
        /// Returns an indication whether the current data is updated to STDTIMETABLE table successfully.
        /// </summary>
        /// <param name="userID">The current user.</param>
        /// <param name="trans">The System.Data.OracleClient.OracleTransaction used by this System.Data.OracleClient.OracleCommand.</param>
        /// <returns>true if update data successfully; otherwise, false.</returns>
        public bool UpdateCurrentData(string userID, OracleTransaction trans)
        {
            return doUpdate("LOID = " + DB.SetDouble(_LOID) + " ", trans);
        }

        /// <summary>
        /// Returns an indication whether the current data is deleted from STDTIMETABLE table successfully.
        /// </summary>
        /// <param name="trans">The System.Data.OracleClient.OracleTransaction used by this System.Data.OracleClient.OracleCommand.</param>
        /// <returns>true if delete data successfully; otherwise, false.</returns>
        public bool DeleteCurrentData(OracleTransaction trans)
        {
            return doDelete("LOID = " + DB.SetDouble(_LOID) + " ", trans);
        }

        /// <summary>
        /// Returns an indication whether the record of STDTIMETABLE by specified LOID key is retrieved successfully.
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
        /// Gets the insert statement for STDTIMETABLE table.
        /// </summary>
        private string sql_insert
        {
            get
            {
                string sql = "INSERT INTO " + tableName + "(LOID, MEALQTY, TIME1, TIME10, TIME11, TIME12, TIME13, TIME14, TIME15, TIME16, TIME17, TIME18, TIME19, TIME2, TIME20, TIME21, TIME22, TIME23, TIME24, TIME3, TIME4, TIME5, TIME6, TIME7, TIME8, TIME9, USEFOR) ";
                sql += "VALUES (";
                sql += DB.SetDouble(_LOID) + ", ";
                sql += DB.SetDouble(_MEALQTY) + ", ";
                sql += DB.SetString(_TIME1) + ", ";
                sql += DB.SetString(_TIME10) + ", ";
                sql += DB.SetString(_TIME11) + ", ";
                sql += DB.SetString(_TIME12) + ", ";
                sql += DB.SetString(_TIME13) + ", ";
                sql += DB.SetString(_TIME14) + ", ";
                sql += DB.SetString(_TIME15) + ", ";
                sql += DB.SetString(_TIME16) + ", ";
                sql += DB.SetString(_TIME17) + ", ";
                sql += DB.SetString(_TIME18) + ", ";
                sql += DB.SetString(_TIME19) + ", ";
                sql += DB.SetString(_TIME2) + ", ";
                sql += DB.SetString(_TIME20) + ", ";
                sql += DB.SetString(_TIME21) + ", ";
                sql += DB.SetString(_TIME22) + ", ";
                sql += DB.SetString(_TIME23) + ", ";
                sql += DB.SetString(_TIME24) + ", ";
                sql += DB.SetString(_TIME3) + ", ";
                sql += DB.SetString(_TIME4) + ", ";
                sql += DB.SetString(_TIME5) + ", ";
                sql += DB.SetString(_TIME6) + ", ";
                sql += DB.SetString(_TIME7) + ", ";
                sql += DB.SetString(_TIME8) + ", ";
                sql += DB.SetString(_TIME9) + ", ";
                sql += DB.SetString(_USEFOR) + " ";
                sql += ")";
                return sql;
            }
        }

        /// <summary>
        /// Gets the update statement for STDTIMETABLE table.
        /// </summary>
        private string sql_update
        {
            get
            {
                string sql = "UPDATE " + tableName + " SET ";
                sql += "MEALQTY = " + DB.SetDouble(_MEALQTY) + ", ";
                sql += "TIME1 = " + DB.SetString(_TIME1) + ", ";
                sql += "TIME10 = " + DB.SetString(_TIME10) + ", ";
                sql += "TIME11 = " + DB.SetString(_TIME11) + ", ";
                sql += "TIME12 = " + DB.SetString(_TIME12) + ", ";
                sql += "TIME13 = " + DB.SetString(_TIME13) + ", ";
                sql += "TIME14 = " + DB.SetString(_TIME14) + ", ";
                sql += "TIME15 = " + DB.SetString(_TIME15) + ", ";
                sql += "TIME16 = " + DB.SetString(_TIME16) + ", ";
                sql += "TIME17 = " + DB.SetString(_TIME17) + ", ";
                sql += "TIME18 = " + DB.SetString(_TIME18) + ", ";
                sql += "TIME19 = " + DB.SetString(_TIME19) + ", ";
                sql += "TIME2 = " + DB.SetString(_TIME2) + ", ";
                sql += "TIME20 = " + DB.SetString(_TIME20) + ", ";
                sql += "TIME21 = " + DB.SetString(_TIME21) + ", ";
                sql += "TIME22 = " + DB.SetString(_TIME22) + ", ";
                sql += "TIME23 = " + DB.SetString(_TIME23) + ", ";
                sql += "TIME24 = " + DB.SetString(_TIME24) + ", ";
                sql += "TIME3 = " + DB.SetString(_TIME3) + ", ";
                sql += "TIME4 = " + DB.SetString(_TIME4) + ", ";
                sql += "TIME5 = " + DB.SetString(_TIME5) + ", ";
                sql += "TIME6 = " + DB.SetString(_TIME6) + ", ";
                sql += "TIME7 = " + DB.SetString(_TIME7) + ", ";
                sql += "TIME8 = " + DB.SetString(_TIME8) + ", ";
                sql += "TIME9 = " + DB.SetString(_TIME9) + ", ";
                sql += "USEFOR = " + DB.SetString(_USEFOR) + " ";
                return sql;
            }
        }

        /// <summary>
        /// Gets the delete statement for STDTIMETABLE table.
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
        /// Gets the select statement for STDTIMETABLE table.
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
        /// Returns an indication whether the current data is inserted into STDTIMETABLE table successfully.
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
        /// Returns an indication whether the current data is updated to STDTIMETABLE table successfully.
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
        /// Returns an indication whether the current data is deleted from STDTIMETABLE table successfully.
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
        /// Returns an indication whether the record of STDTIMETABLE by specified condition is retrieved successfully.
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
                        if (!Convert.IsDBNull(zRdr["LOID"])) _LOID = Convert.ToDouble(zRdr["LOID"]);
                        if (!Convert.IsDBNull(zRdr["MEALQTY"])) _MEALQTY = Convert.ToDouble(zRdr["MEALQTY"]);
                        if (!Convert.IsDBNull(zRdr["TIME1"])) _TIME1 = zRdr["TIME1"].ToString();
                        if (!Convert.IsDBNull(zRdr["TIME10"])) _TIME10 = zRdr["TIME10"].ToString();
                        if (!Convert.IsDBNull(zRdr["TIME11"])) _TIME11 = zRdr["TIME11"].ToString();
                        if (!Convert.IsDBNull(zRdr["TIME12"])) _TIME12 = zRdr["TIME12"].ToString();
                        if (!Convert.IsDBNull(zRdr["TIME13"])) _TIME13 = zRdr["TIME13"].ToString();
                        if (!Convert.IsDBNull(zRdr["TIME14"])) _TIME14 = zRdr["TIME14"].ToString();
                        if (!Convert.IsDBNull(zRdr["TIME15"])) _TIME15 = zRdr["TIME15"].ToString();
                        if (!Convert.IsDBNull(zRdr["TIME16"])) _TIME16 = zRdr["TIME16"].ToString();
                        if (!Convert.IsDBNull(zRdr["TIME17"])) _TIME17 = zRdr["TIME17"].ToString();
                        if (!Convert.IsDBNull(zRdr["TIME18"])) _TIME18 = zRdr["TIME18"].ToString();
                        if (!Convert.IsDBNull(zRdr["TIME19"])) _TIME19 = zRdr["TIME19"].ToString();
                        if (!Convert.IsDBNull(zRdr["TIME2"])) _TIME2 = zRdr["TIME2"].ToString();
                        if (!Convert.IsDBNull(zRdr["TIME20"])) _TIME20 = zRdr["TIME20"].ToString();
                        if (!Convert.IsDBNull(zRdr["TIME21"])) _TIME21 = zRdr["TIME21"].ToString();
                        if (!Convert.IsDBNull(zRdr["TIME22"])) _TIME22 = zRdr["TIME22"].ToString();
                        if (!Convert.IsDBNull(zRdr["TIME23"])) _TIME23 = zRdr["TIME23"].ToString();
                        if (!Convert.IsDBNull(zRdr["TIME24"])) _TIME24 = zRdr["TIME24"].ToString();
                        if (!Convert.IsDBNull(zRdr["TIME3"])) _TIME3 = zRdr["TIME3"].ToString();
                        if (!Convert.IsDBNull(zRdr["TIME4"])) _TIME4 = zRdr["TIME4"].ToString();
                        if (!Convert.IsDBNull(zRdr["TIME5"])) _TIME5 = zRdr["TIME5"].ToString();
                        if (!Convert.IsDBNull(zRdr["TIME6"])) _TIME6 = zRdr["TIME6"].ToString();
                        if (!Convert.IsDBNull(zRdr["TIME7"])) _TIME7 = zRdr["TIME7"].ToString();
                        if (!Convert.IsDBNull(zRdr["TIME8"])) _TIME8 = zRdr["TIME8"].ToString();
                        if (!Convert.IsDBNull(zRdr["TIME9"])) _TIME9 = zRdr["TIME9"].ToString();
                        if (!Convert.IsDBNull(zRdr["USEFOR"])) _USEFOR = zRdr["USEFOR"].ToString();
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

        public bool GetDataByConditions(double cMEALQTY, string cUSEFOR, OracleTransaction trans)
        {
            return doGetdata("MEALQTY = " + DB.SetDouble(cMEALQTY) + " AND USEFOR = " + DB.SetString(cUSEFOR), trans);
        }

    }
}