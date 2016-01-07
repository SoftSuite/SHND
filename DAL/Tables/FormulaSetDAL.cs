using System;
using System.Data;
using System.Data.OracleClient;
using DB = SHND.DAL.Utilities.OracleDB;
using SHND.Data.Common.Utilities;

namespace SHND.DAL.Tables
{
    /// <summary>
    /// Represents a transaction for FORMULASET table.
    /// [Created by 127.0.0.1 on January,5 2009]
    /// </summary>
    public class FormulaSetDAL
    {

        public FormulaSetDAL()
        {
        }

        #region Constant

        /// <summary>FORMULASET</summary>
        private const string tableName = "FORMULASET";

        #endregion

        #region Private Variables

        int _deletedRow = 0;
        string _error = "";
        string _information = "";
        bool _OnDB = false;
        string _ACTIVE = "";
        string _CREATEBY = "";
        DateTime _CREATEON = new DateTime(1, 1, 1);
        double _DISHESTYPE = 0;
        double _ENERGY = 0;
        double _FOODCATEGORY = 0;
        double _FOODCOOKTYPE = 0;
        double _FOODTYPE = 0;
        string _IMGPATH = "";
        string _ISELEMENT = "";
        string _ISONEDISH = "";
        string _ISSPECIFIC = "";
        double _LOID = 0;
        string _NAME = "";
        double _PACKAGE = 0;
        double _PORTION = 0;
        string _PREPARE = "";
        string _RECIPE = "";
        string _SERVEMETHOD = "";
        string _STATUS = "";
        string _UPDATEBY = "";
        DateTime _UPDATEON = new DateTime(1, 1, 1);
        double _WEIGHTFORMULA = 0;
        double _WEIGHTPORTION = 0;

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
        public string ACTIVE
        {
            get { return _ACTIVE; }
            set { _ACTIVE = value; }
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
        public double DISHESTYPE
        {
            get { return _DISHESTYPE; }
            set { _DISHESTYPE = value; }
        }
        public double ENERGY
        {
            get { return _ENERGY; }
            set { _ENERGY = value; }
        }
        public double FOODCATEGORY
        {
            get { return _FOODCATEGORY; }
            set { _FOODCATEGORY = value; }
        }
        public double FOODCOOKTYPE
        {
            get { return _FOODCOOKTYPE; }
            set { _FOODCOOKTYPE = value; }
        }
        public double FOODTYPE
        {
            get { return _FOODTYPE; }
            set { _FOODTYPE = value; }
        }
        public string IMGPATH
        {
            get { return _IMGPATH; }
            set { _IMGPATH = value; }
        }
        public string ISELEMENT
        {
            get { return _ISELEMENT; }
            set { _ISELEMENT = value; }
        }
        public string ISONEDISH
        {
            get { return _ISONEDISH; }
            set { _ISONEDISH = value; }
        }
        public string ISSPECIFIC
        {
            get { return _ISSPECIFIC; }
            set { _ISSPECIFIC = value; }
        }
        public double LOID
        {
            get { return _LOID; }
            set { _LOID = value; }
        }
        public string NAME
        {
            get { return _NAME; }
            set { _NAME = value; }
        }
        public double PACKAGE
        {
            get { return _PACKAGE; }
            set { _PACKAGE = value; }
        }
        public double PORTION
        {
            get { return _PORTION; }
            set { _PORTION = value; }
        }
        public string PREPARE
        {
            get { return _PREPARE; }
            set { _PREPARE = value; }
        }
        public string RECIPE
        {
            get { return _RECIPE; }
            set { _RECIPE = value; }
        }
        public string SERVEMETHOD
        {
            get { return _SERVEMETHOD; }
            set { _SERVEMETHOD = value; }
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
        public double WEIGHTFORMULA
        {
            get { return _WEIGHTFORMULA; }
            set { _WEIGHTFORMULA = value; }
        }
        public double WEIGHTPORTION
        {
            get { return _WEIGHTPORTION; }
            set { _WEIGHTPORTION = value; }
        }

        #endregion

        #region Clear Data

        /// <summary>
        /// Initialize data.
        /// </summary>
        private void ClearData()
        {
            _ACTIVE = "";
            _CREATEBY = "";
            _CREATEON = new DateTime(1, 1, 1);
            _DISHESTYPE = 0;
            _ENERGY = 0;
            _FOODCATEGORY = 0;
            _FOODCOOKTYPE = 0;
            _FOODTYPE = 0;
            _IMGPATH = "";
            _ISELEMENT = "";
            _ISONEDISH = "";
            _ISSPECIFIC = "";
            _LOID = 0;
            _NAME = "";
            _PACKAGE = 0;
            _PORTION = 0;
            _PREPARE = "";
            _RECIPE = "";
            _SERVEMETHOD = "";
            _STATUS = "";
            _UPDATEBY = "";
            _UPDATEON = new DateTime(1, 1, 1);
            _WEIGHTFORMULA = 0;
            _WEIGHTPORTION = 0;
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
        /// Returns an indication whether the current data is inserted into FORMULASET table successfully.
        /// </summary>
        /// <param name="userID">The current user.</param>
        /// <param name="trans">The System.Data.OracleClient.OracleTransaction used by this System.Data.OracleClient.OracleCommand.</param>
        /// <returns>true if insert data successfully; otherwise, false.</returns>
        public bool InsertCurrentData(string userID, OracleTransaction trans)
        {
            _LOID = DB.GetNextID(TableName, trans);
            //_NAME = "สูตรอาหาร_" + Convert.ToDouble(DB.GetRunningCode(TableName, "NAME", trans)).ToString();
            _CREATEBY = userID;
            _CREATEON = DateTime.Now;
            return doInsert(trans);
        }

        /// <summary>
        /// Returns an indication whether the current data is updated to FORMULASET table successfully.
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
        /// Returns an indication whether the current data is deleted from FORMULASET table successfully.
        /// </summary>
        /// <param name="trans">The System.Data.OracleClient.OracleTransaction used by this System.Data.OracleClient.OracleCommand.</param>
        /// <returns>true if delete data successfully; otherwise, false.</returns>
        public bool DeleteCurrentData(OracleTransaction trans)
        {
            return doDelete("LOID = " + DB.SetDouble(_LOID) + " ", trans);
        }

        /// <summary>
        /// Returns an indication whether the record of FORMULASET by specified LOID key is retrieved successfully.
        /// </summary>
        /// <param name="cLOID">The LOID key.</param>
        /// <param name="trans">The System.Data.OracleClient.OracleTransaction used by this System.Data.OracleClient.OracleCommand.</param>
        /// <returns>true if data is retrieved successfully; otherwise, false.</returns>
        public bool GetDataByLOID(double cLOID, OracleTransaction trans)
        {
            return doGetdata("LOID = " + DB.SetDouble(cLOID) + " ", trans);
        }

        /// <summary>
        /// Returns an indication whether the record of FORMULASET by specified NAME key is retrieved successfully.
        /// </summary>
        /// <param name="cLOID">The Name key.</param>
        /// <param name="trans">The System.Data.OracleClient.OracleTransaction used by this System.Data.OracleClient.OracleCommand.</param>
        /// <returns>true if data is retrieved successfully; otherwise, false.</returns>
        public bool GetDataByName(string cName, OracleTransaction trans)
        {
            return doGetdata("UPPER(NAME) = " + DB.SetString(cName.ToUpper()) + " ", trans);
        }

        public bool DeleteDataByLOID(double cLOID, OracleTransaction trans)
        {
            return doDelete("LOID = " + DB.SetDouble(cLOID) + " ", trans);
        }

        public bool GetDataByUniqueKey(string cNAME, double cFOODTYPE, double cFOODCATEGORY, double cPORTION, OracleTransaction trans)
        {
            return doGetdata("UPPER(NAME) = " + DB.SetString(cNAME.ToUpper()) + " AND FOODTYPE = " + DB.SetDouble(cFOODTYPE) + " AND FOODCATEGORY = " + DB.SetDouble(cFOODCATEGORY) + " AND PORTION = " + DB.SetDouble(cPORTION), trans);
        }

        #endregion

        #region SQL Statements

        /// <summary>
        /// Gets the insert statement for FORMULASET table.
        /// </summary>
        private string sql_insert
        {
            get
            {
                string sql = "INSERT INTO " + tableName + "(ACTIVE, CREATEBY, CREATEON, DISHESTYPE, ENERGY, FOODCATEGORY, FOODCOOKTYPE, FOODTYPE, IMGPATH, ISELEMENT, ISONEDISH, ISSPECIFIC, LOID, NAME, PACKAGE, PORTION, PREPARE, RECIPE, SERVEMETHOD, STATUS, WEIGHTFORMULA, WEIGHTPORTION) ";
                sql += "VALUES (";
                sql += DB.SetString(_ACTIVE) + ", ";
                sql += DB.SetString(_CREATEBY) + ", ";
                sql += DB.SetDateTime(_CREATEON) + ", ";
                sql += (_DISHESTYPE == 0 ? "NULL" : DB.SetDouble(_DISHESTYPE)) + ", ";
                sql += DB.SetDouble(_ENERGY) + ", ";
                sql += DB.SetDouble(_FOODCATEGORY) + ", ";
                sql += (_FOODCOOKTYPE == 0 ? "NULL" : DB.SetDouble(_FOODCOOKTYPE)) + ", ";
                sql += DB.SetDouble(_FOODTYPE) + ", ";
                sql += DB.SetString(_IMGPATH) + ", ";
                sql += DB.SetString(_ISELEMENT) + ", ";
                sql += DB.SetString(_ISONEDISH) + ", ";
                sql += DB.SetString(_ISSPECIFIC) + ", ";
                sql += DB.SetDouble(_LOID) + ", ";
                sql += DB.SetString(_NAME) + ", ";
                sql += (_PACKAGE == 0 ? "NULL" : DB.SetDouble(_PACKAGE)) + ", ";
                sql += DB.SetDouble(_PORTION) + ", ";
                sql += DB.SetString(_PREPARE) + ", ";
                sql += DB.SetString(_RECIPE) + ", ";
                sql += DB.SetString(_SERVEMETHOD) + ", ";
                sql += DB.SetString(_STATUS) + ", ";
                sql += DB.SetDouble(_WEIGHTFORMULA) + ", ";
                sql += DB.SetDouble(_WEIGHTPORTION) + " ";
                sql += ")";
                return sql;
            }
        }

        /// <summary>
        /// Gets the update statement for FORMULASET table.
        /// </summary>
        private string sql_update
        {
            get
            {
                string sql = "UPDATE " + tableName + " SET ";
                sql += "ACTIVE = " + DB.SetString(_ACTIVE) + ", ";
                sql += "DISHESTYPE = " + (_DISHESTYPE == 0 ? "NULL" : DB.SetDouble(_DISHESTYPE)) + ", ";
                sql += "ENERGY = " + DB.SetDouble(_ENERGY) + ", ";
                sql += "FOODCATEGORY = " + DB.SetDouble(_FOODCATEGORY) + ", ";
                sql += "FOODCOOKTYPE = " + (_FOODCOOKTYPE == 0 ? "NULL" : DB.SetDouble(_FOODCOOKTYPE)) + ", ";
                sql += "FOODTYPE = " + DB.SetDouble(_FOODTYPE) + ", ";
                sql += "IMGPATH = " + DB.SetString(_IMGPATH) + ", ";
                sql += "ISELEMENT = " + DB.SetString(_ISELEMENT) + ", ";
                sql += "ISONEDISH = " + DB.SetString(_ISONEDISH) + ", ";
                sql += "ISSPECIFIC = " + DB.SetString(_ISSPECIFIC) + ", ";
                sql += "NAME = " + DB.SetString(_NAME) + ", ";
                sql += "PACKAGE = " + (_PACKAGE == 0 ? "NULL" : DB.SetDouble(_PACKAGE)) + ", ";
                sql += "PORTION = " + DB.SetDouble(_PORTION) + ", ";
                sql += "PREPARE = " + DB.SetString(_PREPARE) + ", ";
                sql += "RECIPE = " + DB.SetString(_RECIPE) + ", ";
                sql += "SERVEMETHOD = " + DB.SetString(_SERVEMETHOD) + ", ";
                sql += "STATUS = " + DB.SetString(_STATUS) + ", ";
                sql += "UPDATEBY = " + DB.SetString(_UPDATEBY) + ", ";
                sql += "UPDATEON = " + DB.SetDateTime(_UPDATEON) + ", ";
                sql += "WEIGHTFORMULA = " + DB.SetDouble(_WEIGHTFORMULA) + ", ";
                sql += "WEIGHTPORTION = " + DB.SetDouble(_WEIGHTPORTION) + " ";
                return sql;
            }
        }

        /// <summary>
        /// Gets the delete statement for FORMULASET table.
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
        /// Gets the select statement for FORMULASET table.
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
        /// Returns an indication whether the current data is inserted into FORMULASET table successfully.
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
        /// Returns an indication whether the current data is updated to FORMULASET table successfully.
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
        /// Returns an indication whether the current data is deleted from FORMULASET table successfully.
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
        /// Returns an indication whether the record of FORMULASET by specified condition is retrieved successfully.
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
                        if (!Convert.IsDBNull(zRdr["ACTIVE"])) _ACTIVE = zRdr["ACTIVE"].ToString();
                        if (!Convert.IsDBNull(zRdr["CREATEBY"])) _CREATEBY = zRdr["CREATEBY"].ToString();
                        if (!Convert.IsDBNull(zRdr["CREATEON"])) _CREATEON = Convert.ToDateTime(zRdr["CREATEON"]);
                        if (!Convert.IsDBNull(zRdr["DISHESTYPE"])) _DISHESTYPE = Convert.ToDouble(zRdr["DISHESTYPE"]);
                        if (!Convert.IsDBNull(zRdr["ENERGY"])) _ENERGY = Convert.ToDouble(zRdr["ENERGY"]);
                        if (!Convert.IsDBNull(zRdr["FOODCATEGORY"])) _FOODCATEGORY = Convert.ToDouble(zRdr["FOODCATEGORY"]);
                        if (!Convert.IsDBNull(zRdr["FOODCOOKTYPE"])) _FOODCOOKTYPE = Convert.ToDouble(zRdr["FOODCOOKTYPE"]);
                        if (!Convert.IsDBNull(zRdr["FOODTYPE"])) _FOODTYPE = Convert.ToDouble(zRdr["FOODTYPE"]);
                        if (!Convert.IsDBNull(zRdr["IMGPATH"])) _IMGPATH = zRdr["IMGPATH"].ToString();
                        if (!Convert.IsDBNull(zRdr["ISELEMENT"])) _ISELEMENT = zRdr["ISELEMENT"].ToString();
                        if (!Convert.IsDBNull(zRdr["ISONEDISH"])) _ISONEDISH = zRdr["ISONEDISH"].ToString();
                        if (!Convert.IsDBNull(zRdr["ISSPECIFIC"])) _ISSPECIFIC = zRdr["ISSPECIFIC"].ToString();
                        if (!Convert.IsDBNull(zRdr["LOID"])) _LOID = Convert.ToDouble(zRdr["LOID"]);
                        if (!Convert.IsDBNull(zRdr["NAME"])) _NAME = zRdr["NAME"].ToString();
                        if (!Convert.IsDBNull(zRdr["PACKAGE"])) _PACKAGE = Convert.ToDouble(zRdr["PACKAGE"]);
                        if (!Convert.IsDBNull(zRdr["PORTION"])) _PORTION = Convert.ToDouble(zRdr["PORTION"]);
                        if (!Convert.IsDBNull(zRdr["PREPARE"])) _PREPARE = zRdr["PREPARE"].ToString();
                        if (!Convert.IsDBNull(zRdr["RECIPE"])) _RECIPE = zRdr["RECIPE"].ToString();
                        if (!Convert.IsDBNull(zRdr["SERVEMETHOD"])) _SERVEMETHOD = zRdr["SERVEMETHOD"].ToString();
                        if (!Convert.IsDBNull(zRdr["STATUS"])) _STATUS = zRdr["STATUS"].ToString();
                        if (!Convert.IsDBNull(zRdr["UPDATEBY"])) _UPDATEBY = zRdr["UPDATEBY"].ToString();
                        if (!Convert.IsDBNull(zRdr["UPDATEON"])) _UPDATEON = Convert.ToDateTime(zRdr["UPDATEON"]);
                        if (!Convert.IsDBNull(zRdr["WEIGHTFORMULA"])) _WEIGHTFORMULA = Convert.ToDouble(zRdr["WEIGHTFORMULA"]);
                        if (!Convert.IsDBNull(zRdr["WEIGHTPORTION"])) _WEIGHTPORTION = Convert.ToDouble(zRdr["WEIGHTPORTION"]);
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

        public string GetRunningCopyName(string copyName, OracleTransaction trans)
        {
            return copyName + "_" + Convert.ToDouble(DB.GetRunningCode("FORMULASET", "NAME", trans)).ToString();
        }

    }
}