using System;
using System.Data;
using System.Data.OracleClient;
using DB = SHND.DAL.Utilities.OracleDB;
using SHND.Data.Common.Utilities;

namespace SHND.DAL.Tables
{
    /// <summary>
    /// Represents a transaction for ORDERWELFAREDETAIL table.
    /// [Created by 127.0.0.1 on January,13 2009]
    /// </summary>
    public class orderwelfaredetailDAL
    {

        public orderwelfaredetailDAL()
        {
        }

        #region Constant

        /// <summary>ORDERWELFAREDETAIL</summary>
        private const string tableName = "ORDERWELFAREDETAIL";

        #endregion

        #region Private Variables

        int _deletedRow = 0;
        string _error = "";
        string _information = "";
        bool _OnDB = false;
        double _BD1 = 0;
        double _BD2 = 0;
        double _BD3 = 0;
        double _BD4 = 0;
        double _BD5 = 0;
        double _BD6 = 0;
        double _BD7 = 0;
        string _CREATEBY = "";
        DateTime _CREATEON = new DateTime(1, 1, 1);
        double _DD1 = 0;
        double _DD2 = 0;
        double _DD3 = 0;
        double _DD4 = 0;
        double _DD5 = 0;
        double _DD6 = 0;
        double _DD7 = 0;
        double _LD1 = 0;
        double _LD2 = 0;
        double _LD3 = 0;
        double _LD4 = 0;
        double _LD5 = 0;
        double _LD6 = 0;
        double _LD7 = 0;
        double _LOID = 0;
        double _ORDERWELFARE = 0;
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
        public double BD1
        {
            get { return _BD1; }
            set { _BD1 = value; }
        }
        public double BD2
        {
            get { return _BD2; }
            set { _BD2 = value; }
        }
        public double BD3
        {
            get { return _BD3; }
            set { _BD3 = value; }
        }
        public double BD4
        {
            get { return _BD4; }
            set { _BD4 = value; }
        }
        public double BD5
        {
            get { return _BD5; }
            set { _BD5 = value; }
        }
        public double BD6
        {
            get { return _BD6; }
            set { _BD6 = value; }
        }
        public double BD7
        {
            get { return _BD7; }
            set { _BD7 = value; }
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
        public double DD1
        {
            get { return _DD1; }
            set { _DD1 = value; }
        }
        public double DD2
        {
            get { return _DD2; }
            set { _DD2 = value; }
        }
        public double DD3
        {
            get { return _DD3; }
            set { _DD3 = value; }
        }
        public double DD4
        {
            get { return _DD4; }
            set { _DD4 = value; }
        }
        public double DD5
        {
            get { return _DD5; }
            set { _DD5 = value; }
        }
        public double DD6
        {
            get { return _DD6; }
            set { _DD6 = value; }
        }
        public double DD7
        {
            get { return _DD7; }
            set { _DD7 = value; }
        }
        public double LD1
        {
            get { return _LD1; }
            set { _LD1 = value; }
        }
        public double LD2
        {
            get { return _LD2; }
            set { _LD2 = value; }
        }
        public double LD3
        {
            get { return _LD3; }
            set { _LD3 = value; }
        }
        public double LD4
        {
            get { return _LD4; }
            set { _LD4 = value; }
        }
        public double LD5
        {
            get { return _LD5; }
            set { _LD5 = value; }
        }
        public double LD6
        {
            get { return _LD6; }
            set { _LD6 = value; }
        }
        public double LD7
        {
            get { return _LD7; }
            set { _LD7 = value; }
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
            _BD1 = 0;
            _BD2 = 0;
            _BD3 = 0;
            _BD4 = 0;
            _BD5 = 0;
            _BD6 = 0;
            _BD7 = 0;
            _CREATEBY = "";
            _CREATEON = new DateTime(1, 1, 1);
            _DD1 = 0;
            _DD2 = 0;
            _DD3 = 0;
            _DD4 = 0;
            _DD5 = 0;
            _DD6 = 0;
            _DD7 = 0;
            _LD1 = 0;
            _LD2 = 0;
            _LD3 = 0;
            _LD4 = 0;
            _LD5 = 0;
            _LD6 = 0;
            _LD7 = 0;
            _LOID = 0;
            _ORDERWELFARE = 0;
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
        /// Returns an indication whether the current data is inserted into ORDERWELFAREDETAIL table successfully.
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
        /// Returns an indication whether the current data is updated to ORDERWELFAREDETAIL table successfully.
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
        /// Returns an indication whether the current data is deleted from ORDERWELFAREDETAIL table successfully.
        /// </summary>
        /// <param name="trans">The System.Data.OracleClient.OracleTransaction used by this System.Data.OracleClient.OracleCommand.</param>
        /// <returns>true if delete data successfully; otherwise, false.</returns>
        public bool DeleteCurrentData(OracleTransaction trans)
        {
            return doDelete("LOID = " + DB.SetDouble(_LOID) + " ", trans);
        }

        /// <summary>
        /// Returns an indication whether the record of ORDERWELFAREDETAIL by specified LOID key is retrieved successfully.
        /// </summary>
        /// <param name="cLOID">The LOID key.</param>
        /// <param name="trans">The System.Data.OracleClient.OracleTransaction used by this System.Data.OracleClient.OracleCommand.</param>
        /// <returns>true if data is retrieved successfully; otherwise, false.</returns>
        public bool GetDataByLOID(double cLOID, OracleTransaction trans)
        {
            return doGetdata("LOID = " + DB.SetDouble(cLOID) + " ", trans);
        }
        public bool GetDataByORDERWELFARE(double cORDERWELFARE, OracleTransaction trans)
        {
            return doGetdata("ORDERWELFARE = " + DB.SetDouble(cORDERWELFARE) + " ", trans);
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
        /// Gets the insert statement for ORDERWELFAREDETAIL table.
        /// </summary>
        private string sql_insert
        {
            get
            {
                string sql = "INSERT INTO " + tableName + "(BD1, BD2, BD3, BD4, BD5, BD6, BD7, CREATEBY, CREATEON, DD1, DD2, DD3, DD4, DD5, DD6, DD7, LD1, LD2, LD3, LD4, LD5, LD6, LD7, LOID, ORDERWELFARE) ";
                sql += "VALUES (";
                sql += DB.SetDouble(_BD1) + ", ";
                sql += DB.SetDouble(_BD2) + ", ";
                sql += DB.SetDouble(_BD3) + ", ";
                sql += DB.SetDouble(_BD4) + ", ";
                sql += DB.SetDouble(_BD5) + ", ";
                sql += DB.SetDouble(_BD6) + ", ";
                sql += DB.SetDouble(_BD7) + ", ";
                sql += DB.SetString(_CREATEBY) + ", ";
                sql += DB.SetDateTime(_CREATEON) + ", ";
                sql += DB.SetDouble(_DD1) + ", ";
                sql += DB.SetDouble(_DD2) + ", ";
                sql += DB.SetDouble(_DD3) + ", ";
                sql += DB.SetDouble(_DD4) + ", ";
                sql += DB.SetDouble(_DD5) + ", ";
                sql += DB.SetDouble(_DD6) + ", ";
                sql += DB.SetDouble(_DD7) + ", ";
                sql += DB.SetDouble(_LD1) + ", ";
                sql += DB.SetDouble(_LD2) + ", ";
                sql += DB.SetDouble(_LD3) + ", ";
                sql += DB.SetDouble(_LD4) + ", ";
                sql += DB.SetDouble(_LD5) + ", ";
                sql += DB.SetDouble(_LD6) + ", ";
                sql += DB.SetDouble(_LD7) + ", ";
                sql += DB.SetDouble(_LOID) + ", ";
                sql += DB.SetDouble(_ORDERWELFARE) + " ";
                sql += ")";
                return sql;
            }
        }

        /// <summary>
        /// Gets the update statement for ORDERWELFAREDETAIL table.
        /// </summary>
        private string sql_update
        {
            get
            {
                string sql = "UPDATE " + tableName + " SET ";
                sql += "BD1 = " + DB.SetDouble(_BD1) + ", ";
                sql += "BD2 = " + DB.SetDouble(_BD2) + ", ";
                sql += "BD3 = " + DB.SetDouble(_BD3) + ", ";
                sql += "BD4 = " + DB.SetDouble(_BD4) + ", ";
                sql += "BD5 = " + DB.SetDouble(_BD5) + ", ";
                sql += "BD6 = " + DB.SetDouble(_BD6) + ", ";
                sql += "BD7 = " + DB.SetDouble(_BD7) + ", ";
                sql += "DD1 = " + DB.SetDouble(_DD1) + ", ";
                sql += "DD2 = " + DB.SetDouble(_DD2) + ", ";
                sql += "DD3 = " + DB.SetDouble(_DD3) + ", ";
                sql += "DD4 = " + DB.SetDouble(_DD4) + ", ";
                sql += "DD5 = " + DB.SetDouble(_DD5) + ", ";
                sql += "DD6 = " + DB.SetDouble(_DD6) + ", ";
                sql += "DD7 = " + DB.SetDouble(_DD7) + ", ";
                sql += "LD1 = " + DB.SetDouble(_LD1) + ", ";
                sql += "LD2 = " + DB.SetDouble(_LD2) + ", ";
                sql += "LD3 = " + DB.SetDouble(_LD3) + ", ";
                sql += "LD4 = " + DB.SetDouble(_LD4) + ", ";
                sql += "LD5 = " + DB.SetDouble(_LD5) + ", ";
                sql += "LD6 = " + DB.SetDouble(_LD6) + ", ";
                sql += "LD7 = " + DB.SetDouble(_LD7) + ", ";
                sql += "ORDERWELFARE = " + DB.SetDouble(_ORDERWELFARE) + ", ";
                sql += "UPDATEBY = " + DB.SetString(_UPDATEBY) + ", ";
                sql += "UPDATEON = " + DB.SetDateTime(_UPDATEON) + " ";
                return sql;
            }
        }

        /// <summary>
        /// Gets the delete statement for ORDERWELFAREDETAIL table.
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
        /// Gets the select statement for ORDERWELFAREDETAIL table.
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
        /// Returns an indication whether the current data is inserted into ORDERWELFAREDETAIL table successfully.
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
        /// Returns an indication whether the current data is updated to ORDERWELFAREDETAIL table successfully.
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
        /// Returns an indication whether the current data is deleted from ORDERWELFAREDETAIL table successfully.
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
        /// Returns an indication whether the record of ORDERWELFAREDETAIL by specified condition is retrieved successfully.
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
                        if (!Convert.IsDBNull(zRdr["BD1"])) _BD1 = Convert.ToDouble(zRdr["BD1"]);
                        if (!Convert.IsDBNull(zRdr["BD2"])) _BD2 = Convert.ToDouble(zRdr["BD2"]);
                        if (!Convert.IsDBNull(zRdr["BD3"])) _BD3 = Convert.ToDouble(zRdr["BD3"]);
                        if (!Convert.IsDBNull(zRdr["BD4"])) _BD4 = Convert.ToDouble(zRdr["BD4"]);
                        if (!Convert.IsDBNull(zRdr["BD5"])) _BD5 = Convert.ToDouble(zRdr["BD5"]);
                        if (!Convert.IsDBNull(zRdr["BD6"])) _BD6 = Convert.ToDouble(zRdr["BD6"]);
                        if (!Convert.IsDBNull(zRdr["BD7"])) _BD7 = Convert.ToDouble(zRdr["BD7"]);
                        if (!Convert.IsDBNull(zRdr["CREATEBY"])) _CREATEBY = zRdr["CREATEBY"].ToString();
                        if (!Convert.IsDBNull(zRdr["CREATEON"])) _CREATEON = Convert.ToDateTime(zRdr["CREATEON"]);
                        if (!Convert.IsDBNull(zRdr["DD1"])) _DD1 = Convert.ToDouble(zRdr["DD1"]);
                        if (!Convert.IsDBNull(zRdr["DD2"])) _DD2 = Convert.ToDouble(zRdr["DD2"]);
                        if (!Convert.IsDBNull(zRdr["DD3"])) _DD3 = Convert.ToDouble(zRdr["DD3"]);
                        if (!Convert.IsDBNull(zRdr["DD4"])) _DD4 = Convert.ToDouble(zRdr["DD4"]);
                        if (!Convert.IsDBNull(zRdr["DD5"])) _DD5 = Convert.ToDouble(zRdr["DD5"]);
                        if (!Convert.IsDBNull(zRdr["DD6"])) _DD6 = Convert.ToDouble(zRdr["DD6"]);
                        if (!Convert.IsDBNull(zRdr["DD7"])) _DD7 = Convert.ToDouble(zRdr["DD7"]);
                        if (!Convert.IsDBNull(zRdr["LD1"])) _LD1 = Convert.ToDouble(zRdr["LD1"]);
                        if (!Convert.IsDBNull(zRdr["LD2"])) _LD2 = Convert.ToDouble(zRdr["LD2"]);
                        if (!Convert.IsDBNull(zRdr["LD3"])) _LD3 = Convert.ToDouble(zRdr["LD3"]);
                        if (!Convert.IsDBNull(zRdr["LD4"])) _LD4 = Convert.ToDouble(zRdr["LD4"]);
                        if (!Convert.IsDBNull(zRdr["LD5"])) _LD5 = Convert.ToDouble(zRdr["LD5"]);
                        if (!Convert.IsDBNull(zRdr["LD6"])) _LD6 = Convert.ToDouble(zRdr["LD6"]);
                        if (!Convert.IsDBNull(zRdr["LD7"])) _LD7 = Convert.ToDouble(zRdr["LD7"]);
                        if (!Convert.IsDBNull(zRdr["LOID"])) _LOID = Convert.ToDouble(zRdr["LOID"]);
                        if (!Convert.IsDBNull(zRdr["ORDERWELFARE"])) _ORDERWELFARE = Convert.ToDouble(zRdr["ORDERWELFARE"]);
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