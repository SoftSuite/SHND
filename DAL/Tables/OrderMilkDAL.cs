using System;
using System.Data;
using System.Data.OracleClient;
using DB = SHND.DAL.Utilities.OracleDB;
using SHND.Data.Common.Utilities;

namespace SHND.DAL.Tables
{
    /// <summary>
    /// Represents a transaction for ORDERMILK table.
    /// [Created by 127.0.0.1 on March,12 2009]
    /// </summary>
    public class OrderMilkDAL
    {

        public OrderMilkDAL()
        {
        }

        #region Constant

        /// <summary>ORDERMILK</summary>
        private const string tableName = "ORDERMILK";

        #endregion

        #region Private Variables

        int _deletedRow = 0;
        string _error = "";
        string _information = "";
        bool _OnDB = false;
        double _ADMITPATIENT = 0;
        double _CAPACITYRATE = 0;
        string _CREATEBY = "";
        DateTime _CREATEON = new DateTime(1, 1, 1);
        DateTime _ENDDATE = new DateTime(1, 1, 1);
        string _ENDTIME = "";
        double _ENERGY = 0;
        double _ENERGYRATE = 0;
        DateTime _FIRSTDATE = new DateTime(1, 1, 1);
        DateTime _FIRSTDATEREGIS = new DateTime(1, 1, 1);
        string _FIRSTMEALREGIS = "";
        string _FIRSTTIME = "";
        string _ISINCREASE = "";
        string _ISREGISTER = "";
        string _ISSPIN = "";
        double _LOID = 0;
        double _MEALQTY = 0;
        double _MILKCATEGORY = 0;
        double _MILKCODE = 0;
        double _ORDERBY = 0;
        DateTime _ORDERDATE = new DateTime(1, 1, 1);
        string _OWNER = "";
        string _OWNERTEXT = "";
        DateTime _REGISTERDATE = new DateTime(1, 1, 1);
        string _REMARKS = "";
        string _STATUS = "";
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
        string _UNREGISREASON = "";
        string _UPDATEBY = "";
        DateTime _UPDATEON = new DateTime(1, 1, 1);
        double _VOLUMN = 0;

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
        public double ADMITPATIENT
        {
            get { return _ADMITPATIENT; }
            set { _ADMITPATIENT = value; }
        }
        public double CAPACITYRATE
        {
            get { return _CAPACITYRATE; }
            set { _CAPACITYRATE = value; }
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
        public DateTime ENDDATE
        {
            get { return _ENDDATE; }
            set { _ENDDATE = value; }
        }
        public string ENDTIME
        {
            get { return _ENDTIME; }
            set { _ENDTIME = value; }
        }
        public double ENERGY
        {
            get { return _ENERGY; }
            set { _ENERGY = value; }
        }
        public double ENERGYRATE
        {
            get { return _ENERGYRATE; }
            set { _ENERGYRATE = value; }
        }
        public DateTime FIRSTDATE
        {
            get { return _FIRSTDATE; }
            set { _FIRSTDATE = value; }
        }
        public DateTime FIRSTDATEREGIS
        {
            get { return _FIRSTDATEREGIS; }
            set { _FIRSTDATEREGIS = value; }
        }
        public string FIRSTMEALREGIS
        {
            get { return _FIRSTMEALREGIS; }
            set { _FIRSTMEALREGIS = value; }
        }
        public string FIRSTTIME
        {
            get { return _FIRSTTIME; }
            set { _FIRSTTIME = value; }
        }
        public string ISINCREASE
        {
            get { return _ISINCREASE; }
            set { _ISINCREASE = value; }
        }
        public string ISREGISTER
        {
            get { return _ISREGISTER; }
            set { _ISREGISTER = value; }
        }
        public string ISSPIN
        {
            get { return _ISSPIN; }
            set { _ISSPIN = value; }
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
        public double MILKCATEGORY
        {
            get { return _MILKCATEGORY; }
            set { _MILKCATEGORY = value; }
        }
        public double MILKCODE
        {
            get { return _MILKCODE; }
            set { _MILKCODE = value; }
        }
        public double ORDERBY
        {
            get { return _ORDERBY; }
            set { _ORDERBY = value; }
        }
        public DateTime ORDERDATE
        {
            get { return _ORDERDATE; }
            set { _ORDERDATE = value; }
        }
        public string OWNER
        {
            get { return _OWNER; }
            set { _OWNER = value; }
        }
        public string OWNERTEXT
        {
            get { return _OWNERTEXT; }
            set { _OWNERTEXT = value; }
        }
        public DateTime REGISTERDATE
        {
            get { return _REGISTERDATE; }
            set { _REGISTERDATE = value; }
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
        public string UNREGISREASON
        {
            get { return _UNREGISREASON; }
            set { _UNREGISREASON = value; }
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
        public double VOLUMN
        {
            get { return _VOLUMN; }
            set { _VOLUMN = value; }
        }

        #endregion

        #region Clear Data

        /// <summary>
        /// Initialize data.
        /// </summary>
        private void ClearData()
        {
            _ADMITPATIENT = 0;
            _CAPACITYRATE = 0;
            _CREATEBY = "";
            _CREATEON = new DateTime(1, 1, 1);
            _ENDDATE = new DateTime(1, 1, 1);
            _ENDTIME = "";
            _ENERGY = 0;
            _ENERGYRATE = 0;
            _FIRSTDATE = new DateTime(1, 1, 1);
            _FIRSTDATEREGIS = new DateTime(1, 1, 1);
            _FIRSTMEALREGIS = "";
            _FIRSTTIME = "";
            _ISINCREASE = "";
            _ISREGISTER = "";
            _ISSPIN = "";
            _LOID = 0;
            _MEALQTY = 0;
            _MILKCATEGORY = 0;
            _MILKCODE = 0;
            _ORDERBY = 0;
            _ORDERDATE = new DateTime(1, 1, 1);
            _OWNER = "";
            _OWNERTEXT = "";
            _REGISTERDATE = new DateTime(1, 1, 1);
            _REMARKS = "";
            _STATUS = "";
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
            _UNREGISREASON = "";
            _UPDATEBY = "";
            _UPDATEON = new DateTime(1, 1, 1);
            _VOLUMN = 0;
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
        /// Returns an indication whether the current data is inserted into ORDERMILK table successfully.
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
        /// Returns an indication whether the current data is updated to ORDERMILK table successfully.
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
        /// Returns an indication whether the current data is deleted from ORDERMILK table successfully.
        /// </summary>
        /// <param name="trans">The System.Data.OracleClient.OracleTransaction used by this System.Data.OracleClient.OracleCommand.</param>
        /// <returns>true if delete data successfully; otherwise, false.</returns>
        public bool DeleteCurrentData(OracleTransaction trans)
        {
            return doDelete("LOID = " + DB.SetDouble(_LOID) + " ", trans);
        }

        /// <summary>
        /// Returns an indication whether the record of ORDERMILK by specified LOID key is retrieved successfully.
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
        /// Gets the insert statement for ORDERMILK table.
        /// </summary>
        private string sql_insert
        {
            get
            {
                string sql = "INSERT INTO " + tableName + "(ADMITPATIENT, CAPACITYRATE, CREATEBY, CREATEON, ENDDATE, ENDTIME, ENERGY, ENERGYRATE, FIRSTDATE, FIRSTDATEREGIS, FIRSTMEALREGIS, FIRSTTIME, ISINCREASE, ISREGISTER, ISSPIN, LOID, MEALQTY, MILKCATEGORY, MILKCODE, ORDERBY, ORDERDATE, OWNER, OWNERTEXT, REGISTERDATE, REMARKS, STATUS, TIME1, TIME10, TIME11, TIME12, TIME13, TIME14, TIME15, TIME16, TIME17, TIME18, TIME19, TIME2, TIME20, TIME21, TIME22, TIME23, TIME24, TIME3, TIME4, TIME5, TIME6, TIME7, TIME8, TIME9, UNREGISREASON, VOLUMN) ";
                sql += "VALUES (";
                sql += DB.SetDouble(_ADMITPATIENT) + ", ";
                sql += DB.SetDouble(_CAPACITYRATE) + ", ";
                sql += DB.SetString(_CREATEBY) + ", ";
                sql += DB.SetDateTime(_CREATEON) + ", ";
                sql += DB.SetDateTime(_ENDDATE) + ", ";
                sql += DB.SetString(_ENDTIME) + ", ";
                sql += DB.SetDouble(_ENERGY) + ", ";
                sql += DB.SetDouble(_ENERGYRATE) + ", ";
                sql += DB.SetDateTime(_FIRSTDATE) + ", ";
                sql += DB.SetDateTime(_FIRSTDATEREGIS) + ", ";
                sql += DB.SetString(_FIRSTMEALREGIS) + ", ";
                sql += DB.SetString(_FIRSTTIME) + ", ";
                sql += DB.SetString(_ISINCREASE) + ", ";
                sql += DB.SetString(_ISREGISTER) + ", ";
                sql += DB.SetString(_ISSPIN) + ", ";
                sql += DB.SetDouble(_LOID) + ", ";
                sql += DB.SetDouble(_MEALQTY) + ", ";
                sql += (_MILKCATEGORY == 0 ? "NULL" : DB.SetDouble(_MILKCATEGORY)) + ", ";
                sql += DB.SetDouble(_MILKCODE) + ", ";
                sql += DB.SetDouble(_ORDERBY) + ", ";
                sql += DB.SetDateTime(_ORDERDATE) + ", ";
                sql += DB.SetString(_OWNER) + ", ";
                sql += DB.SetString(_OWNERTEXT) + ", ";
                sql += DB.SetDateTime(_REGISTERDATE) + ", ";
                sql += DB.SetString(_REMARKS) + ", ";
                sql += DB.SetString(_STATUS) + ", ";
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
                sql += DB.SetString(_UNREGISREASON) + ", ";
                sql += DB.SetDouble(_VOLUMN) + " ";
                sql += ")";
                return sql;
            }
        }

        /// <summary>
        /// Gets the update statement for ORDERMILK table.
        /// </summary>
        private string sql_update
        {
            get
            {
                string sql = "UPDATE " + tableName + " SET ";
                sql += "ADMITPATIENT = " + DB.SetDouble(_ADMITPATIENT) + ", ";
                sql += "CAPACITYRATE = " + DB.SetDouble(_CAPACITYRATE) + ", ";
                sql += "ENDDATE = " + DB.SetDateTime(_ENDDATE) + ", ";
                sql += "ENDTIME = " + DB.SetString(_ENDTIME) + ", ";
                sql += "ENERGY = " + DB.SetDouble(_ENERGY) + ", ";
                sql += "ENERGYRATE = " + DB.SetDouble(_ENERGYRATE) + ", ";
                sql += "FIRSTDATE = " + DB.SetDateTime(_FIRSTDATE) + ", ";
                sql += "FIRSTDATEREGIS = " + DB.SetDateTime(_FIRSTDATEREGIS) + ", ";
                sql += "FIRSTMEALREGIS = " + DB.SetString(_FIRSTMEALREGIS) + ", ";
                sql += "FIRSTTIME = " + DB.SetString(_FIRSTTIME) + ", ";
                sql += "ISINCREASE = " + DB.SetString(_ISINCREASE) + ", ";
                sql += "ISREGISTER = " + DB.SetString(_ISREGISTER) + ", ";
                sql += "ISSPIN = " + DB.SetString(_ISSPIN) + ", ";
                sql += "MEALQTY = " + DB.SetDouble(_MEALQTY) + ", ";
                sql += "MILKCATEGORY = " + (_MILKCATEGORY == 0 ? "NULL" : DB.SetDouble(_MILKCATEGORY)) + ", ";
                sql += "MILKCODE = " + DB.SetDouble(_MILKCODE) + ", ";
                sql += "ORDERBY = " + DB.SetDouble(_ORDERBY) + ", ";
                sql += "ORDERDATE = " + DB.SetDateTime(_ORDERDATE) + ", ";
                sql += "OWNER = " + DB.SetString(_OWNER) + ", ";
                sql += "OWNERTEXT = " + DB.SetString(_OWNERTEXT) + ", ";
                sql += "REGISTERDATE = " + DB.SetDateTime(_REGISTERDATE) + ", ";
                sql += "REMARKS = " + DB.SetString(_REMARKS) + ", ";
                sql += "STATUS = " + DB.SetString(_STATUS) + ", ";
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
                sql += "UNREGISREASON = " + DB.SetString(_UNREGISREASON) + ", ";
                sql += "UPDATEBY = " + DB.SetString(_UPDATEBY) + ", ";
                sql += "UPDATEON = " + DB.SetDateTime(_UPDATEON) + ", ";
                sql += "VOLUMN = " + DB.SetDouble(_VOLUMN) + " ";
                return sql;
            }
        }

        /// <summary>
        /// Gets the delete statement for ORDERMILK table.
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
        /// Gets the select statement for ORDERMILK table.
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
        /// Returns an indication whether the current data is inserted into ORDERMILK table successfully.
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
        /// Returns an indication whether the current data is updated to ORDERMILK table successfully.
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
        /// Returns an indication whether the current data is deleted from ORDERMILK table successfully.
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
        /// Returns an indication whether the record of ORDERMILK by specified condition is retrieved successfully.
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
                        if (!Convert.IsDBNull(zRdr["ADMITPATIENT"])) _ADMITPATIENT = Convert.ToDouble(zRdr["ADMITPATIENT"]);
                        if (!Convert.IsDBNull(zRdr["CAPACITYRATE"])) _CAPACITYRATE = Convert.ToDouble(zRdr["CAPACITYRATE"]);
                        if (!Convert.IsDBNull(zRdr["CREATEBY"])) _CREATEBY = zRdr["CREATEBY"].ToString();
                        if (!Convert.IsDBNull(zRdr["CREATEON"])) _CREATEON = Convert.ToDateTime(zRdr["CREATEON"]);
                        if (!Convert.IsDBNull(zRdr["ENDDATE"])) _ENDDATE = Convert.ToDateTime(zRdr["ENDDATE"]);
                        if (!Convert.IsDBNull(zRdr["ENDTIME"])) _ENDTIME = zRdr["ENDTIME"].ToString();
                        if (!Convert.IsDBNull(zRdr["ENERGY"])) _ENERGY = Convert.ToDouble(zRdr["ENERGY"]);
                        if (!Convert.IsDBNull(zRdr["ENERGYRATE"])) _ENERGYRATE = Convert.ToDouble(zRdr["ENERGYRATE"]);
                        if (!Convert.IsDBNull(zRdr["FIRSTDATE"])) _FIRSTDATE = Convert.ToDateTime(zRdr["FIRSTDATE"]);
                        if (!Convert.IsDBNull(zRdr["FIRSTDATEREGIS"])) _FIRSTDATEREGIS = Convert.ToDateTime(zRdr["FIRSTDATEREGIS"]);
                        if (!Convert.IsDBNull(zRdr["FIRSTMEALREGIS"])) _FIRSTMEALREGIS = zRdr["FIRSTMEALREGIS"].ToString();
                        if (!Convert.IsDBNull(zRdr["FIRSTTIME"])) _FIRSTTIME = zRdr["FIRSTTIME"].ToString();
                        if (!Convert.IsDBNull(zRdr["ISINCREASE"])) _ISINCREASE = zRdr["ISINCREASE"].ToString();
                        if (!Convert.IsDBNull(zRdr["ISREGISTER"])) _ISREGISTER = zRdr["ISREGISTER"].ToString();
                        if (!Convert.IsDBNull(zRdr["ISSPIN"])) _ISSPIN = zRdr["ISSPIN"].ToString();
                        if (!Convert.IsDBNull(zRdr["LOID"])) _LOID = Convert.ToDouble(zRdr["LOID"]);
                        if (!Convert.IsDBNull(zRdr["MEALQTY"])) _MEALQTY = Convert.ToDouble(zRdr["MEALQTY"]);
                        if (!Convert.IsDBNull(zRdr["MILKCATEGORY"])) _MILKCATEGORY = Convert.ToDouble(zRdr["MILKCATEGORY"]);
                        if (!Convert.IsDBNull(zRdr["MILKCODE"])) _MILKCODE = Convert.ToDouble(zRdr["MILKCODE"]);
                        if (!Convert.IsDBNull(zRdr["ORDERBY"])) _ORDERBY = Convert.ToDouble(zRdr["ORDERBY"]);
                        if (!Convert.IsDBNull(zRdr["ORDERDATE"])) _ORDERDATE = Convert.ToDateTime(zRdr["ORDERDATE"]);
                        if (!Convert.IsDBNull(zRdr["OWNER"])) _OWNER = zRdr["OWNER"].ToString();
                        if (!Convert.IsDBNull(zRdr["OWNERTEXT"])) _OWNERTEXT = zRdr["OWNERTEXT"].ToString();
                        if (!Convert.IsDBNull(zRdr["REGISTERDATE"])) _REGISTERDATE = Convert.ToDateTime(zRdr["REGISTERDATE"]);
                        if (!Convert.IsDBNull(zRdr["REMARKS"])) _REMARKS = zRdr["REMARKS"].ToString();
                        if (!Convert.IsDBNull(zRdr["STATUS"])) _STATUS = zRdr["STATUS"].ToString();
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
                        if (!Convert.IsDBNull(zRdr["UNREGISREASON"])) _UNREGISREASON = zRdr["UNREGISREASON"].ToString();
                        if (!Convert.IsDBNull(zRdr["UPDATEBY"])) _UPDATEBY = zRdr["UPDATEBY"].ToString();
                        if (!Convert.IsDBNull(zRdr["UPDATEON"])) _UPDATEON = Convert.ToDateTime(zRdr["UPDATEON"]);
                        if (!Convert.IsDBNull(zRdr["VOLUMN"])) _VOLUMN = Convert.ToDouble(zRdr["VOLUMN"]);
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
            return doDelete("LOID = " + DB.SetDouble(cLOID), trans);
        }

        public bool Discontinue(double cADMITPATIENT, DateTime cFIRSTDATE, DateTime cENDDATE, OracleTransaction trans)
        {
            bool ret = true;
            int affectedRow = 0;
            string sql = "UPDATE " + tableName + " SET STATUS='DC', ISREGISTER = 'N' WHERE STATUS<>'DC' AND ADMITPATIENT = " + DB.SetDouble(cADMITPATIENT) + " AND (" +
                "(FIRSTDATE <=" + DB.SetDateTime(cFIRSTDATE) + " AND (ENDDATE IS NULL OR ENDDATE >=" + DB.SetDateTime(cFIRSTDATE) + ")) " +
                "OR (FIRSTDATE >=" + DB.SetDateTime(cFIRSTDATE) + ")" +
                ")";
            try
            {
                affectedRow = DB.ExecuteNonQuery(sql, trans);
                ret = (affectedRow >= 0);
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

        public bool GetDataByOrderMedId(double cLOID, OracleTransaction trans)
        {
            return doGetdata("LOID = " + DB.SetDouble(cLOID) + " ", trans);
        }

        #endregion

    }
}