using System;
using System.Data;
using System.Data.OracleClient;
using DB = SHND.DAL.Utilities.OracleDB;
using SHND.Data.Common.Utilities;

namespace SHND.DAL.Tables
{
    /// <summary>
    /// Represents a transaction for PLANORDER table.
    /// [Created by 127.0.0.1 on January,30 2009]
    /// </summary>
    public class PlanOrderDAL
    {

        public PlanOrderDAL()
        {
        }

        #region Constant

        /// <summary>PLANORDER</summary>
        private const string tableName = "PLANORDER";

        #endregion

        #region Private Variables

        int _deletedRow = 0;
        string _error = "";
        string _information = "";
        bool _OnDB = false;
        double _BUDGETYEAR = 0;
        string _CODE = "";
        string _CREATEBY = "";
        DateTime _CREATEON = new DateTime(1, 1, 1);
        DateTime _ENDDATE = new DateTime(1, 1, 1);
        string _ISPLANFOOD = "";
        double _LOID = 0;
        double _MATERIALCLASS = 0;
        string _NAME = "";
        double _PERIODTIME = 0;
        string _PHASE = "";
        DateTime _PLANDATE = new DateTime(1, 1, 1);
        string _QTCODE = "";
        string _REFPRSAP = "";
        DateTime _STARTDATE = new DateTime(1, 1, 1);
        string _STATUS = "";
        string _UPDATEBY = "";
        DateTime _UPDATEON = new DateTime(1,1,1);

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
        public double BUDGETYEAR
        {
            get { return _BUDGETYEAR; }
            set { _BUDGETYEAR = value; }
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
        public DateTime ENDDATE
        {
            get { return _ENDDATE; }
            set { _ENDDATE = value; }
        }
        public string ISPLANFOOD
        {
            get { return _ISPLANFOOD; }
            set { _ISPLANFOOD = value; }
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
        public string NAME
        {
            get { return _NAME; }
            set { _NAME = value; }
        }
        public double PERIODTIME
        {
            get { return _PERIODTIME; }
            set { _PERIODTIME = value; }
        }
        public string PHASE
        {
            get { return _PHASE; }
            set { _PHASE = value; }
        }
        public DateTime PLANDATE
        {
            get { return _PLANDATE; }
            set { _PLANDATE = value; }
        }
        public string QTCODE
        {
            get { return _QTCODE; }
            set { _QTCODE = value; }
        }
        public string REFPRSAP
        {
            get { return _REFPRSAP; }
            set { _REFPRSAP = value; }
        }
        public DateTime STARTDATE
        {
            get { return _STARTDATE; }
            set { _STARTDATE = value; }
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
            _BUDGETYEAR = 0;
            _CODE = "";
            _CREATEBY = "";
            _CREATEON = new DateTime(1, 1, 1);
            _ENDDATE = new DateTime(1, 1, 1);
            _ISPLANFOOD = "";
            _LOID = 0;
            _MATERIALCLASS = 0;
            _NAME = "";
            _PERIODTIME = 0;
            _PHASE = "";
            _PLANDATE = new DateTime(1, 1, 1);
            _QTCODE = "";
            _REFPRSAP = "";
            _STARTDATE = new DateTime(1, 1, 1);
            _STATUS = "";
            _UPDATEBY = "";
            _UPDATEON = new DateTime(1,1,1);
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
        /// Returns an indication whether the current data is inserted into PLANORDER table successfully.
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
        /// Returns an indication whether the current data is updated to PLANORDER table successfully.
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
        /// Returns an indication whether the current data is deleted from PLANORDER table successfully.
        /// </summary>
        /// <param name="trans">The System.Data.OracleClient.OracleTransaction used by this System.Data.OracleClient.OracleCommand.</param>
        /// <returns>true if delete data successfully; otherwise, false.</returns>
        public bool DeleteCurrentData(OracleTransaction trans)
        {
            return doDelete("LOID = " + DB.SetDouble(_LOID) + " ", trans);
        }

        /// <summary>
        /// Returns an indication whether the record of PLANORDER by specified LOID key is retrieved successfully.
        /// </summary>
        /// <param name="cLOID">The LOID key.</param>
        /// <param name="trans">The System.Data.OracleClient.OracleTransaction used by this System.Data.OracleClient.OracleCommand.</param>
        /// <returns>true if data is retrieved successfully; otherwise, false.</returns>
        public bool GetDataByLOID(double cLOID, OracleTransaction trans)
        {
            return doGetdata("LOID = " + DB.SetDouble(cLOID) + " ", trans);
        }

        /// <summary>
        /// Returns an indication whether the record of PLANORDER by specified CODE key is retrieved successfully.
        /// </summary>
        /// <param name="cCODE">The CODE key.</param>
        /// <param name="trans">The System.Data.OracleClient.OracleTransaction used by this System.Data.OracleClient.OracleCommand.</param>
        /// <returns>true if data is retrieved successfully; otherwise, false.</returns>
        public bool GetDataByCODE(string cCODE, OracleTransaction trans)
        {
            return doGetdata("CODE = " + DB.SetString(cCODE) + " ", trans);
        }

        /// <summary>
        /// Returns an indication whether the record of PLANORDER by specified QTCODE key is retrieved successfully.
        /// </summary>
        /// <param name="cQTCODE">The QTCODE key.</param>
        /// <param name="trans">The System.Data.OracleClient.OracleTransaction used by this System.Data.OracleClient.OracleCommand.</param>
        /// <returns>true if data is retrieved successfully; otherwise, false.</returns>
        public bool GetDataByQTCODE(string cQTCODE, OracleTransaction trans)
        {
            return doGetdata("QTCODE = " + DB.SetString(cQTCODE) + " ", trans);
        }
        public double GetDataByPeriod(DateTime currDate,  OracleTransaction trans)
        {
            string sql = "SELECT LOID FROM PLANORDER " +
                        " WHERE STATUS='FN' AND ISPLANFOOD = 'Y' " +
                        " AND " + DB.SetDate(currDate) + " BETWEEN STARTDATE AND ENDDATE " +
                        " AND ROWNUM=1";
            return Convert.ToDouble(DB.ExecuteScalar(sql, trans));

        }

        #endregion

        #region SQL Statements

        /// <summary>
        /// Gets the insert statement for PLANORDER table.
        /// </summary>
        private string sql_insert
        {
            get
            {
                string sql = "INSERT INTO " + tableName + "(BUDGETYEAR, CODE, CREATEBY, CREATEON, ENDDATE, ISPLANFOOD, LOID, MATERIALCLASS, NAME, PERIODTIME, PHASE, PLANDATE, QTCODE, REFPRSAP, STARTDATE, STATUS) ";
                sql += "VALUES (";
                sql += DB.SetDouble(_BUDGETYEAR) + ", ";
                sql += DB.SetString(_CODE) + ", ";
                sql += DB.SetString(_CREATEBY) + ", ";
                sql += DB.SetDateTime(_CREATEON) + ", ";
                sql += DB.SetDateTime(_ENDDATE) + ", ";
                sql += DB.SetString(_ISPLANFOOD) + ", ";
                sql += DB.SetDouble(_LOID) + ", ";
                sql += (_MATERIALCLASS == 0 ? "NULL" : DB.SetDouble(_MATERIALCLASS)) + ", ";
                sql += DB.SetString(_NAME) + ", ";
                sql += DB.SetDouble(_PERIODTIME) + ", ";
                sql += DB.SetString(_PHASE) + ", ";
                sql += DB.SetDateTime(_PLANDATE) + ", ";
                sql += DB.SetString(_QTCODE) + ", ";
                sql += DB.SetString(_REFPRSAP) + ", ";
                sql += DB.SetDateTime(_STARTDATE) + ", ";
                sql += DB.SetString(_STATUS) + " ";
                sql += ")";
                return sql;
            }
        }

        /// <summary>
        /// Gets the update statement for PLANORDER table.
        /// </summary>
        private string sql_update
        {
            get
            {
                string sql = "UPDATE " + tableName + " SET ";
                sql += "BUDGETYEAR = " + DB.SetDouble(_BUDGETYEAR) + ", ";
                sql += "CODE = " + DB.SetString(_CODE) + ", ";
                sql += "ENDDATE = " + DB.SetDateTime(_ENDDATE) + ", ";
                sql += "ISPLANFOOD = " + DB.SetString(_ISPLANFOOD) + ", ";
                sql += "MATERIALCLASS = " + (_MATERIALCLASS == 0 ? "NULL" : DB.SetDouble(_MATERIALCLASS)) + ", ";
                sql += "NAME = " + DB.SetString(_NAME) + ", ";
                sql += "PERIODTIME = " + DB.SetDouble(_PERIODTIME) + ", ";
                sql += "PHASE = " + DB.SetString(_PHASE) + ", ";
                sql += "PLANDATE = " + DB.SetDateTime(_PLANDATE) + ", ";
                sql += "QTCODE = " + DB.SetString(_QTCODE) + ", ";
                sql += "REFPRSAP = " + DB.SetString(_REFPRSAP) + ", ";
                sql += "STARTDATE = " + DB.SetDateTime(_STARTDATE) + ", ";
                sql += "STATUS = " + DB.SetString(_STATUS) + ", ";
                sql += "UPDATEBY = " + DB.SetString(_UPDATEBY) + ", ";
                sql += "UPDATEON = " + DB.SetDateTime(_UPDATEON) + " ";
                return sql;
            }
        }

        /// <summary>
        /// Gets the delete statement for PLANORDER table.
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
        /// Gets the select statement for PLANORDER table.
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
        /// Returns an indication whether the current data is inserted into PLANORDER table successfully.
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
        /// Returns an indication whether the current data is updated to PLANORDER table successfully.
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
        /// Returns an indication whether the current data is deleted from PLANORDER table successfully.
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
        /// Returns an indication whether the record of PLANORDER by specified condition is retrieved successfully.
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
                        if (!Convert.IsDBNull(zRdr["BUDGETYEAR"])) _BUDGETYEAR = Convert.ToDouble(zRdr["BUDGETYEAR"]);
                        if (!Convert.IsDBNull(zRdr["CODE"])) _CODE = zRdr["CODE"].ToString();
                        if (!Convert.IsDBNull(zRdr["CREATEBY"])) _CREATEBY = zRdr["CREATEBY"].ToString();
                        if (!Convert.IsDBNull(zRdr["CREATEON"])) _CREATEON = Convert.ToDateTime(zRdr["CREATEON"]);
                        if (!Convert.IsDBNull(zRdr["ENDDATE"])) _ENDDATE = Convert.ToDateTime(zRdr["ENDDATE"]);
                        if (!Convert.IsDBNull(zRdr["ISPLANFOOD"])) _ISPLANFOOD = zRdr["ISPLANFOOD"].ToString();
                        if (!Convert.IsDBNull(zRdr["LOID"])) _LOID = Convert.ToDouble(zRdr["LOID"]);
                        if (!Convert.IsDBNull(zRdr["MATERIALCLASS"])) _MATERIALCLASS = Convert.ToDouble(zRdr["MATERIALCLASS"]);
                        if (!Convert.IsDBNull(zRdr["NAME"])) _NAME = zRdr["NAME"].ToString();
                        if (!Convert.IsDBNull(zRdr["PERIODTIME"])) _PERIODTIME = Convert.ToDouble(zRdr["PERIODTIME"]);
                        if (!Convert.IsDBNull(zRdr["PHASE"])) _PHASE = zRdr["PHASE"].ToString();
                        if (!Convert.IsDBNull(zRdr["PLANDATE"])) _PLANDATE = Convert.ToDateTime(zRdr["PLANDATE"]);
                        if (!Convert.IsDBNull(zRdr["QTCODE"])) _QTCODE = zRdr["QTCODE"].ToString();
                        if (!Convert.IsDBNull(zRdr["REFPRSAP"])) _REFPRSAP = zRdr["REFPRSAP"].ToString();
                        if (!Convert.IsDBNull(zRdr["STARTDATE"])) _STARTDATE = Convert.ToDateTime(zRdr["STARTDATE"]);
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

        public string GetRunningCodeFood(OracleTransaction trans)
        {
            return DB.GetRunningCode(tableName, "FOODCODE", trans);
        }

        public string GetRunningCopyNameFood(string copyName, OracleTransaction trans)
        {
            return copyName + "_" + Convert.ToDouble(DB.GetRunningCode("PLANORDER", "FOODNAME", trans)).ToString();
        }

        public bool GetDataByUniqueKey(string cNAME, OracleTransaction trans)
        {
            return doGetdata("UPPER(NAME) = " + DB.SetString(cNAME.ToUpper()), trans);
        }
        public bool GetDataByUniqueDate(DateTime startDate, DateTime endDate, double planOrderID, OracleTransaction trans)
        {
            //FOR PLANFOOD ONLY
            string sqlDate = "((" + DB.SetDate(startDate) + " BETWEEN STARTDATE AND ENDDATE OR " + DB.SetDate(endDate) + " BETWEEN STARTDATE AND ENDDATE) OR " +
                            " (" + DB.SetDate(startDate) + " <= STARTDATE AND " + DB.SetDate(endDate) + " >= ENDDATE))";

            return doGetdata("ISPLANFOOD = 'Y' AND LOID <> " + DB.SetDouble(planOrderID) + " AND " + sqlDate + " ",trans);
        }
        public bool GetDataByUniqueDate(DateTime startDate, DateTime endDate, double cMaterialClass, double planOrderID, OracleTransaction trans)
        { 
            //FOR PLANTOOLS ONLY
            string sqlDate = "((" + DB.SetDate(startDate) + " BETWEEN STARTDATE AND ENDDATE OR " + DB.SetDate(endDate) + " BETWEEN STARTDATE AND ENDDATE) OR " +
                            " (" + DB.SetDate(startDate) + " <= STARTDATE AND " + DB.SetDate(endDate) + " >= ENDDATE))";

            return doGetdata("MATERIALCLASS = '" + DB.SetDouble(cMaterialClass) + "' AND ISPLANFOOD = 'N' AND LOID <> " + DB.SetDouble(planOrderID) + " AND " + sqlDate + " ", trans);
        }
    }
}