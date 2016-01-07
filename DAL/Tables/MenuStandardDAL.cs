using System;
using System.Data;
using System.Data.OracleClient;
using DB = SHND.DAL.Utilities.OracleDB;
using SHND.Data.Common.Utilities;

namespace SHND.DAL.Tables
{
    /// <summary>
    /// Represents a transaction for MENUSTANDARD table.
    /// [Created by 127.0.0.1 on June,24 2009]
    /// </summary>
    public class MenuStandardDAL
    {

        public MenuStandardDAL()
        {
        }

        #region Constant

        /// <summary>MENUSTANDARD</summary>
        private const string tableName = "MENUSTANDARD";

        #endregion

        #region Private Variables

        int _deletedRow = 0;
        string _error = "";
        string _information = "";
        bool _OnDB = false;
        double _BMONTH = 0;
        double _BYEAR = 0;
        string _CREATEBY = "";
        DateTime _CREATEON = new DateTime(1, 1, 1);
        double _LOID = 0;
        double _MENU = 0;
        string _MENUSOURCE = "";
        double _MMONTH = 0;
        double _MYEAR = 0;
        double _PATIENTQTY = 0;
        string _PATIENTSOURCE = "";
        double _STDMENU = 0;
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
        public double BMONTH
        {
            get { return _BMONTH; }
            set { _BMONTH = value; }
        }
        public double BYEAR
        {
            get { return _BYEAR; }
            set { _BYEAR = value; }
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
        public double MENU
        {
            get { return _MENU; }
            set { _MENU = value; }
        }
        public string MENUSOURCE
        {
            get { return _MENUSOURCE; }
            set { _MENUSOURCE = value; }
        }
        public double MMONTH
        {
            get { return _MMONTH; }
            set { _MMONTH = value; }
        }
        public double MYEAR
        {
            get { return _MYEAR; }
            set { _MYEAR = value; }
        }
        public double PATIENTQTY
        {
            get { return _PATIENTQTY; }
            set { _PATIENTQTY = value; }
        }
        public string PATIENTSOURCE
        {
            get { return _PATIENTSOURCE; }
            set { _PATIENTSOURCE = value; }
        }
        public double STDMENU
        {
            get { return _STDMENU; }
            set { _STDMENU = value; }
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
            _BMONTH = 0;
            _BYEAR = 0;
            _CREATEBY = "";
            _CREATEON = new DateTime(1, 1, 1);
            _LOID = 0;
            _MENU = 0;
            _MENUSOURCE = "";
            _MMONTH = 0;
            _MYEAR = 0;
            _PATIENTQTY = 0;
            _PATIENTSOURCE = "";
            _STDMENU = 0;
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

        public bool DeleteDataByMenu(double cMENU, OracleTransaction trans)
        {
            return doDelete("MENU = " + DB.SetDouble(cMENU) + " ", trans);
        }

        /// <summary>
        /// Returns an indication whether the current data is inserted into MENUSTANDARD table successfully.
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
        /// Returns an indication whether the current data is updated to MENUSTANDARD table successfully.
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
        /// Returns an indication whether the current data is deleted from MENUSTANDARD table successfully.
        /// </summary>
        /// <param name="trans">The System.Data.OracleClient.OracleTransaction used by this System.Data.OracleClient.OracleCommand.</param>
        /// <returns>true if delete data successfully; otherwise, false.</returns>
        public bool DeleteCurrentData(OracleTransaction trans)
        {
            return doDelete("LOID = " + DB.SetDouble(_LOID) + " ", trans);
        }

        /// <summary>
        /// Returns an indication whether the record of MENUSTANDARD by specified LOID key is retrieved successfully.
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
        /// Gets the insert statement for MENUSTANDARD table.
        /// </summary>
        private string sql_insert
        {
            get
            {
                string sql = "INSERT INTO " + tableName + "(BMONTH, BYEAR, CREATEBY, CREATEON, LOID, MENU, MENUSOURCE, MMONTH, MYEAR, PATIENTQTY, PATIENTSOURCE, STDMENU) ";
                sql += "VALUES (";
                sql += DB.SetDouble(_BMONTH) + ", ";
                sql += DB.SetDouble(_BYEAR) + ", ";
                sql += DB.SetString(_CREATEBY) + ", ";
                sql += DB.SetDateTime(_CREATEON) + ", ";
                sql += DB.SetDouble(_LOID) + ", ";
                sql += DB.SetDouble(_MENU) + ", ";
                sql += DB.SetString(_MENUSOURCE) + ", ";
                sql += DB.SetDouble(_MMONTH) + ", ";
                sql += DB.SetDouble(_MYEAR) + ", ";
                sql += DB.SetDouble(_PATIENTQTY) + ", ";
                sql += DB.SetString(_PATIENTSOURCE) + ", ";
                sql += (_STDMENU == 0 ? "NULL" : DB.SetDouble(_STDMENU)) + " ";
                sql += ")";
                return sql;
            }
        }

        /// <summary>
        /// Gets the update statement for MENUSTANDARD table.
        /// </summary>
        private string sql_update
        {
            get
            {
                string sql = "UPDATE " + tableName + " SET ";
                sql += "BMONTH = " + DB.SetDouble(_BMONTH) + ", ";
                sql += "BYEAR = " + DB.SetDouble(_BYEAR) + ", ";
                sql += "MENU = " + DB.SetDouble(_MENU) + ", ";
                sql += "MENUSOURCE = " + DB.SetString(_MENUSOURCE) + ", ";
                sql += "MMONTH = " + DB.SetDouble(_MMONTH) + ", ";
                sql += "MYEAR = " + DB.SetDouble(_MYEAR) + ", ";
                sql += "PATIENTQTY = " + DB.SetDouble(_PATIENTQTY) + ", ";
                sql += "PATIENTSOURCE = " + DB.SetString(_PATIENTSOURCE) + ", ";
                sql += "STDMENU = " + DB.SetDouble(_STDMENU) + ", ";
                sql += "UPDATEBY = " + DB.SetString(_UPDATEBY) + ", ";
                sql += "UPDATEON = " + DB.SetDateTime(_UPDATEON) + " ";
                return sql;
            }
        }

        /// <summary>
        /// Gets the delete statement for MENUSTANDARD table.
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
        /// Gets the select statement for MENUSTANDARD table.
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
        /// Returns an indication whether the current data is inserted into MENUSTANDARD table successfully.
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
                    if (!ret)
                        _error = DataResources.MSGEN001;
                    else
                        _OnDB = true;
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
        /// Returns an indication whether the current data is updated to MENUSTANDARD table successfully.
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
        /// Returns an indication whether the current data is deleted from MENUSTANDARD table successfully.
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
        /// Returns an indication whether the record of MENUSTANDARD by specified condition is retrieved successfully.
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
                        if (!Convert.IsDBNull(zRdr["BMONTH"])) _BMONTH = Convert.ToDouble(zRdr["BMONTH"]);
                        if (!Convert.IsDBNull(zRdr["BYEAR"])) _BYEAR = Convert.ToDouble(zRdr["BYEAR"]);
                        if (!Convert.IsDBNull(zRdr["CREATEBY"])) _CREATEBY = zRdr["CREATEBY"].ToString();
                        if (!Convert.IsDBNull(zRdr["CREATEON"])) _CREATEON = Convert.ToDateTime(zRdr["CREATEON"]);
                        if (!Convert.IsDBNull(zRdr["LOID"])) _LOID = Convert.ToDouble(zRdr["LOID"]);
                        if (!Convert.IsDBNull(zRdr["MENU"])) _MENU = Convert.ToDouble(zRdr["MENU"]);
                        if (!Convert.IsDBNull(zRdr["MENUSOURCE"])) _MENUSOURCE = zRdr["MENUSOURCE"].ToString();
                        if (!Convert.IsDBNull(zRdr["MMONTH"])) _MMONTH = Convert.ToDouble(zRdr["MMONTH"]);
                        if (!Convert.IsDBNull(zRdr["MYEAR"])) _MYEAR = Convert.ToDouble(zRdr["MYEAR"]);
                        if (!Convert.IsDBNull(zRdr["PATIENTQTY"])) _PATIENTQTY = Convert.ToDouble(zRdr["PATIENTQTY"]);
                        if (!Convert.IsDBNull(zRdr["PATIENTSOURCE"])) _PATIENTSOURCE = zRdr["PATIENTSOURCE"].ToString();
                        if (!Convert.IsDBNull(zRdr["STDMENU"])) _STDMENU = Convert.ToDouble(zRdr["STDMENU"]);
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