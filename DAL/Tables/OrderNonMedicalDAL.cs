using System;
using System.Data;
using System.Data.OracleClient;
using DB = SHND.DAL.Utilities.OracleDB;
using SHND.Data.Common.Utilities;

namespace SHND.DAL.Tables
{
    /// <summary>
    /// Represents a transaction for ORDERNONMEDICAL table.
    /// [Created by 127.0.0.1 on March,12 2009]
    /// </summary>
    public class OrderNonMedicalDAL
    {

        public OrderNonMedicalDAL()
        {
        }

        #region Constant

        /// <summary>ORDERNONMEDICAL</summary>
        private const string tableName = "ORDERNONMEDICAL";

        #endregion

        #region Private Variables

        int _deletedRow = 0;
        string _error = "";
        string _information = "";
        bool _OnDB = false;
        string _ABSTAINOTHER = "";
        double _ADMITPATIENT = 0;
        double _BREAKFAST = 0;
        string _CREATEBY = "";
        DateTime _CREATEON = new DateTime(1, 1, 1);
        double _DINNER = 0;
        DateTime _ENDDATE = new DateTime(1, 1, 1);
        string _ENDMEAL = "";
        DateTime _FIRSTDATE = new DateTime(1, 1, 1);
        DateTime _FIRSTDATEREGIS = new DateTime(1, 1, 1);
        string _FIRSTMEAL = "";
        string _FIRSTMEALREGIS = "";
        double _FOODTYPE = 0;
        string _ISABSTAIN = "";
        string _ISFAMILY = "";
        string _ISNEED = "";
        string _ISREGISTER = "";
        string _ISREQUEST = "";
        double _LOID = 0;
        double _LUNCH = 0;
        string _NEEDOTHER = "";
        double _NURSE = 0;
        DateTime _ORDERDATE = new DateTime(1, 1, 1);
        DateTime _REGISTERDATE = new DateTime(1, 1, 1);
        string _REMARKS = "";
        string _REQUESTOTHER = "";
        string _STATUS = "";
        string _UNREGISREASON = "";
        string _UPDATEBY = "";
        DateTime _UPDATEON = new DateTime(1, 1, 1);
        string _VIPTYPE = "";

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
        public string ABSTAINOTHER
        {
            get { return _ABSTAINOTHER; }
            set { _ABSTAINOTHER = value; }
        }
        public double ADMITPATIENT
        {
            get { return _ADMITPATIENT; }
            set { _ADMITPATIENT = value; }
        }
        public double BREAKFAST
        {
            get { return _BREAKFAST; }
            set { _BREAKFAST = value; }
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
        public double DINNER
        {
            get { return _DINNER; }
            set { _DINNER = value; }
        }
        public DateTime ENDDATE
        {
            get { return _ENDDATE; }
            set { _ENDDATE = value; }
        }
        public string ENDMEAL
        {
            get { return _ENDMEAL; }
            set { _ENDMEAL = value; }
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
        public string FIRSTMEAL
        {
            get { return _FIRSTMEAL; }
            set { _FIRSTMEAL = value; }
        }
        public string FIRSTMEALREGIS
        {
            get { return _FIRSTMEALREGIS; }
            set { _FIRSTMEALREGIS = value; }
        }
        public double FOODTYPE
        {
            get { return _FOODTYPE; }
            set { _FOODTYPE = value; }
        }
        public string ISABSTAIN
        {
            get { return _ISABSTAIN; }
            set { _ISABSTAIN = value; }
        }
        public string ISFAMILY
        {
            get { return _ISFAMILY; }
            set { _ISFAMILY = value; }
        }
        public string ISNEED
        {
            get { return _ISNEED; }
            set { _ISNEED = value; }
        }
        public string ISREGISTER
        {
            get { return _ISREGISTER; }
            set { _ISREGISTER = value; }
        }
        public string ISREQUEST
        {
            get { return _ISREQUEST; }
            set { _ISREQUEST = value; }
        }
        public double LOID
        {
            get { return _LOID; }
            set { _LOID = value; }
        }
        public double LUNCH
        {
            get { return _LUNCH; }
            set { _LUNCH = value; }
        }
        public string NEEDOTHER
        {
            get { return _NEEDOTHER; }
            set { _NEEDOTHER = value; }
        }
        public double NURSE
        {
            get { return _NURSE; }
            set { _NURSE = value; }
        }
        public DateTime ORDERDATE
        {
            get { return _ORDERDATE; }
            set { _ORDERDATE = value; }
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
        public string REQUESTOTHER
        {
            get { return _REQUESTOTHER; }
            set { _REQUESTOTHER = value; }
        }
        public string STATUS
        {
            get { return _STATUS; }
            set { _STATUS = value; }
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
        public string VIPTYPE
        {
            get { return _VIPTYPE; }
            set { _VIPTYPE = value; }
        }

        #endregion

        #region Clear Data

        /// <summary>
        /// Initialize data.
        /// </summary>
        private void ClearData()
        {
            _ABSTAINOTHER = "";
            _ADMITPATIENT = 0;
            _BREAKFAST = 0;
            _CREATEBY = "";
            _CREATEON = new DateTime(1, 1, 1);
            _DINNER = 0;
            _ENDDATE = new DateTime(1, 1, 1);
            _ENDMEAL = "";
            _FIRSTDATE = new DateTime(1, 1, 1);
            _FIRSTDATEREGIS = new DateTime(1, 1, 1);
            _FIRSTMEAL = "";
            _FIRSTMEALREGIS = "";
            _FOODTYPE = 0;
            _ISABSTAIN = "";
            _ISFAMILY = "";
            _ISNEED = "";
            _ISREGISTER = "";
            _ISREQUEST = "";
            _LOID = 0;
            _LUNCH = 0;
            _NEEDOTHER = "";
            _NURSE = 0;
            _ORDERDATE = new DateTime(1, 1, 1);
            _REGISTERDATE = new DateTime(1, 1, 1);
            _REMARKS = "";
            _REQUESTOTHER = "";
            _STATUS = "";
            _UNREGISREASON = "";
            _UPDATEBY = "";
            _UPDATEON = new DateTime(1, 1, 1);
            _VIPTYPE = "";
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
        /// Returns an indication whether the current data is inserted into ORDERNONMEDICAL table successfully.
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
        /// Returns an indication whether the current data is updated to ORDERNONMEDICAL table successfully.
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
        /// Returns an indication whether the current data is deleted from ORDERNONMEDICAL table successfully.
        /// </summary>
        /// <param name="trans">The System.Data.OracleClient.OracleTransaction used by this System.Data.OracleClient.OracleCommand.</param>
        /// <returns>true if delete data successfully; otherwise, false.</returns>
        public bool DeleteCurrentData(OracleTransaction trans)
        {
            return doDelete("LOID = " + DB.SetDouble(_LOID) + " ", trans);
        }

        /// <summary>
        /// Returns an indication whether the record of ORDERNONMEDICAL by specified LOID key is retrieved successfully.
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
        /// Gets the insert statement for ORDERNONMEDICAL table.
        /// </summary>
        private string sql_insert
        {
            get
            {
                string sql = "INSERT INTO " + tableName + "(ABSTAINOTHER, ADMITPATIENT, BREAKFAST, CREATEBY, CREATEON, DINNER, ENDDATE, ENDMEAL, FIRSTDATE, FIRSTDATEREGIS, FIRSTMEAL, FIRSTMEALREGIS, FOODTYPE, ISABSTAIN, ISFAMILY, ISNEED, ISREGISTER, ISREQUEST, LOID, LUNCH, NEEDOTHER, NURSE, ORDERDATE, REGISTERDATE, REMARKS, REQUESTOTHER, STATUS, UNREGISREASON, VIPTYPE) ";
                sql += "VALUES (";
                sql += DB.SetString(_ABSTAINOTHER) + ", ";
                sql += DB.SetDouble(_ADMITPATIENT) + ", ";
                sql += DB.SetDouble(_BREAKFAST) + ", ";
                sql += DB.SetString(_CREATEBY) + ", ";
                sql += DB.SetDateTime(_CREATEON) + ", ";
                sql += DB.SetDouble(_DINNER) + ", ";
                sql += DB.SetDateTime(_ENDDATE) + ", ";
                sql += DB.SetString(_ENDMEAL) + ", ";
                sql += DB.SetDateTime(_FIRSTDATE) + ", ";
                sql += DB.SetDateTime(_FIRSTDATEREGIS) + ", ";
                sql += DB.SetString(_FIRSTMEAL) + ", ";
                sql += DB.SetString(_FIRSTMEALREGIS) + ", ";
                sql += DB.SetDouble(_FOODTYPE) + ", ";
                sql += DB.SetString(_ISABSTAIN) + ", ";
                sql += DB.SetString(_ISFAMILY) + ", ";
                sql += DB.SetString(_ISNEED) + ", ";
                sql += DB.SetString(_ISREGISTER) + ", ";
                sql += DB.SetString(_ISREQUEST) + ", ";
                sql += DB.SetDouble(_LOID) + ", ";
                sql += DB.SetDouble(_LUNCH) + ", ";
                sql += DB.SetString(_NEEDOTHER) + ", ";
                sql += DB.SetDouble(_NURSE) + ", ";
                sql += DB.SetDateTime(_ORDERDATE) + ", ";
                sql += DB.SetDateTime(_REGISTERDATE) + ", ";
                sql += DB.SetString(_REMARKS) + ", ";
                sql += DB.SetString(_REQUESTOTHER) + ", ";
                sql += DB.SetString(_STATUS) + ", ";
                sql += DB.SetString(_UNREGISREASON) + ", ";
                sql += DB.SetString(_VIPTYPE) + " ";
                sql += ")";
                return sql;
            }
        }

        /// <summary>
        /// Gets the update statement for ORDERNONMEDICAL table.
        /// </summary>
        private string sql_update
        {
            get
            {
                string sql = "UPDATE " + tableName + " SET ";
                sql += "ABSTAINOTHER = " + DB.SetString(_ABSTAINOTHER) + ", ";
                sql += "ADMITPATIENT = " + DB.SetDouble(_ADMITPATIENT) + ", ";
                sql += "BREAKFAST = " + DB.SetDouble(_BREAKFAST) + ", ";
                sql += "DINNER = " + DB.SetDouble(_DINNER) + ", ";
                sql += "ENDDATE = " + DB.SetDateTime(_ENDDATE) + ", ";
                sql += "ENDMEAL = " + DB.SetString(_ENDMEAL) + ", ";
                sql += "FIRSTDATE = " + DB.SetDateTime(_FIRSTDATE) + ", ";
                sql += "FIRSTDATEREGIS = " + DB.SetDateTime(_FIRSTDATEREGIS) + ", ";
                sql += "FIRSTMEAL = " + DB.SetString(_FIRSTMEAL) + ", ";
                sql += "FIRSTMEALREGIS = " + DB.SetString(_FIRSTMEALREGIS) + ", ";
                sql += "FOODTYPE = " + DB.SetDouble(_FOODTYPE) + ", ";
                sql += "ISABSTAIN = " + DB.SetString(_ISABSTAIN) + ", ";
                sql += "ISFAMILY = " + DB.SetString(_ISFAMILY) + ", ";
                sql += "ISNEED = " + DB.SetString(_ISNEED) + ", ";
                sql += "ISREGISTER = " + DB.SetString(_ISREGISTER) + ", ";
                sql += "ISREQUEST = " + DB.SetString(_ISREQUEST) + ", ";
                sql += "LUNCH = " + DB.SetDouble(_LUNCH) + ", ";
                sql += "NEEDOTHER = " + DB.SetString(_NEEDOTHER) + ", ";
                sql += "NURSE = " + DB.SetDouble(_NURSE) + ", ";
                sql += "ORDERDATE = " + DB.SetDateTime(_ORDERDATE) + ", ";
                sql += "REGISTERDATE = " + DB.SetDateTime(_REGISTERDATE) + ", ";
                sql += "REMARKS = " + DB.SetString(_REMARKS) + ", ";
                sql += "REQUESTOTHER = " + DB.SetString(_REQUESTOTHER) + ", ";
                sql += "STATUS = " + DB.SetString(_STATUS) + ", ";
                sql += "UNREGISREASON = " + DB.SetString(_UNREGISREASON) + ", ";
                sql += "UPDATEBY = " + DB.SetString(_UPDATEBY) + ", ";
                sql += "UPDATEON = " + DB.SetDateTime(_UPDATEON) + ", ";
                sql += "VIPTYPE = " + DB.SetString(_VIPTYPE) + " ";
                return sql;
            }
        }

        /// <summary>
        /// Gets the delete statement for ORDERNONMEDICAL table.
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
        /// Gets the select statement for ORDERNONMEDICAL table.
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
        /// Returns an indication whether the current data is inserted into ORDERNONMEDICAL table successfully.
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
        /// Returns an indication whether the current data is updated to ORDERNONMEDICAL table successfully.
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
        /// Returns an indication whether the current data is deleted from ORDERNONMEDICAL table successfully.
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
        /// Returns an indication whether the record of ORDERNONMEDICAL by specified condition is retrieved successfully.
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
                        if (!Convert.IsDBNull(zRdr["ABSTAINOTHER"])) _ABSTAINOTHER = zRdr["ABSTAINOTHER"].ToString();
                        if (!Convert.IsDBNull(zRdr["ADMITPATIENT"])) _ADMITPATIENT = Convert.ToDouble(zRdr["ADMITPATIENT"]);
                        if (!Convert.IsDBNull(zRdr["BREAKFAST"])) _BREAKFAST = Convert.ToDouble(zRdr["BREAKFAST"]);
                        if (!Convert.IsDBNull(zRdr["CREATEBY"])) _CREATEBY = zRdr["CREATEBY"].ToString();
                        if (!Convert.IsDBNull(zRdr["CREATEON"])) _CREATEON = Convert.ToDateTime(zRdr["CREATEON"]);
                        if (!Convert.IsDBNull(zRdr["DINNER"])) _DINNER = Convert.ToDouble(zRdr["DINNER"]);
                        if (!Convert.IsDBNull(zRdr["ENDDATE"])) _ENDDATE = Convert.ToDateTime(zRdr["ENDDATE"]);
                        if (!Convert.IsDBNull(zRdr["ENDMEAL"])) _ENDMEAL = zRdr["ENDMEAL"].ToString();
                        if (!Convert.IsDBNull(zRdr["FIRSTDATE"])) _FIRSTDATE = Convert.ToDateTime(zRdr["FIRSTDATE"]);
                        if (!Convert.IsDBNull(zRdr["FIRSTDATEREGIS"])) _FIRSTDATEREGIS = Convert.ToDateTime(zRdr["FIRSTDATEREGIS"]);
                        if (!Convert.IsDBNull(zRdr["FIRSTMEAL"])) _FIRSTMEAL = zRdr["FIRSTMEAL"].ToString();
                        if (!Convert.IsDBNull(zRdr["FIRSTMEALREGIS"])) _FIRSTMEALREGIS = zRdr["FIRSTMEALREGIS"].ToString();
                        if (!Convert.IsDBNull(zRdr["FOODTYPE"])) _FOODTYPE = Convert.ToDouble(zRdr["FOODTYPE"]);
                        if (!Convert.IsDBNull(zRdr["ISABSTAIN"])) _ISABSTAIN = zRdr["ISABSTAIN"].ToString();
                        if (!Convert.IsDBNull(zRdr["ISFAMILY"])) _ISFAMILY = zRdr["ISFAMILY"].ToString();
                        if (!Convert.IsDBNull(zRdr["ISNEED"])) _ISNEED = zRdr["ISNEED"].ToString();
                        if (!Convert.IsDBNull(zRdr["ISREGISTER"])) _ISREGISTER = zRdr["ISREGISTER"].ToString();
                        if (!Convert.IsDBNull(zRdr["ISREQUEST"])) _ISREQUEST = zRdr["ISREQUEST"].ToString();
                        if (!Convert.IsDBNull(zRdr["LOID"])) _LOID = Convert.ToDouble(zRdr["LOID"]);
                        if (!Convert.IsDBNull(zRdr["LUNCH"])) _LUNCH = Convert.ToDouble(zRdr["LUNCH"]);
                        if (!Convert.IsDBNull(zRdr["NEEDOTHER"])) _NEEDOTHER = zRdr["NEEDOTHER"].ToString();
                        if (!Convert.IsDBNull(zRdr["NURSE"])) _NURSE = Convert.ToDouble(zRdr["NURSE"]);
                        if (!Convert.IsDBNull(zRdr["ORDERDATE"])) _ORDERDATE = Convert.ToDateTime(zRdr["ORDERDATE"]);
                        if (!Convert.IsDBNull(zRdr["REGISTERDATE"])) _REGISTERDATE = Convert.ToDateTime(zRdr["REGISTERDATE"]);
                        if (!Convert.IsDBNull(zRdr["REMARKS"])) _REMARKS = zRdr["REMARKS"].ToString();
                        if (!Convert.IsDBNull(zRdr["REQUESTOTHER"])) _REQUESTOTHER = zRdr["REQUESTOTHER"].ToString();
                        if (!Convert.IsDBNull(zRdr["STATUS"])) _STATUS = zRdr["STATUS"].ToString();
                        if (!Convert.IsDBNull(zRdr["UNREGISREASON"])) _UNREGISREASON = zRdr["UNREGISREASON"].ToString();
                        if (!Convert.IsDBNull(zRdr["UPDATEBY"])) _UPDATEBY = zRdr["UPDATEBY"].ToString();
                        if (!Convert.IsDBNull(zRdr["UPDATEON"])) _UPDATEON = Convert.ToDateTime(zRdr["UPDATEON"]);
                        if (!Convert.IsDBNull(zRdr["VIPTYPE"])) _VIPTYPE = zRdr["VIPTYPE"].ToString();
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
        public bool GetDataByOrderNonMed(double cLOID, OracleTransaction trans)
        {
            return doGetdata("LOID = " + DB.SetDouble(cLOID) + " ", trans);
        }

        #endregion
    }
}