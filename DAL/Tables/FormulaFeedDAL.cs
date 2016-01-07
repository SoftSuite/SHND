using System;
using System.Data;
using System.Data.OracleClient;
using DB = SHND.DAL.Utilities.OracleDB;
using SHND.Data.Common.Utilities;

namespace SHND.DAL.Tables
{
    /// <summary>
    /// Represents a transaction for FORMULAFEED table.
    /// [Created by 127.0.0.1 on January,7 2009]
    /// </summary>
    public class FormulaFeedDAL
    {

        public FormulaFeedDAL()
        {
        }

        #region Constant

        /// <summary>FORMULAFEED</summary>
        private const string tableName = "FORMULAFEED";

        #endregion

        #region Private Variables

        int _deletedRow = 0;
        string _error = "";
        string _information = "";
        bool _OnDB = false;
        string _ACTIVE = "";
        double _CAPACITY = 0;
        double _CAPACITYRATE = 0;
        double _CARBOHYDRATE = 0;
        string _CREATEBY = "";
        DateTime _CREATEON = new DateTime(1, 1, 1);
        double _ENERGY = 0;
        double _ENERGYRATE = 0;
        double _FAT = 0;
        string _FEEDCATEGORY = "";
        double _LOID = 0;
        double _MATERIALMASTER = 0;
        string _NAME = "";
        double _PORTION = 0;
        double _PROTEIN = 0;
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
        public string ACTIVE
        {
            get { return _ACTIVE; }
            set { _ACTIVE = value; }
        }
        public double CAPACITY
        {
            get { return _CAPACITY; }
            set { _CAPACITY = value; }
        }
        public double CAPACITYRATE
        {
            get { return _CAPACITYRATE; }
            set { _CAPACITYRATE = value; }
        }
        public double CARBOHYDRATE
        {
            get { return _CARBOHYDRATE; }
            set { _CARBOHYDRATE = value; }
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
        public double FAT
        {
            get { return _FAT; }
            set { _FAT = value; }
        }
        public string FEEDCATEGORY
        {
            get { return _FEEDCATEGORY; }
            set { _FEEDCATEGORY = value; }
        }
        public double LOID
        {
            get { return _LOID; }
            set { _LOID = value; }
        }
        public double MATERIALMASTER
        {
            get { return _MATERIALMASTER; }
            set { _MATERIALMASTER = value; }
        }
        public string NAME
        {
            get { return _NAME; }
            set { _NAME = value; }
        }
        public double PORTION
        {
            get { return _PORTION; }
            set { _PORTION = value; }
        }
        public double PROTEIN
        {
            get { return _PROTEIN; }
            set { _PROTEIN = value; }
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
            _ACTIVE = "";
            _CAPACITY = 0;
            _CAPACITYRATE = 0;
            _CARBOHYDRATE = 0;
            _CREATEBY = "";
            _CREATEON = new DateTime(1, 1, 1);
            _ENERGY = 0;
            _ENERGYRATE = 0;
            _FAT = 0;
            _FEEDCATEGORY = "";
            _LOID = 0;
            _MATERIALMASTER = 0;
            _NAME = "";
            _PORTION = 0;
            _PROTEIN = 0;
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
        /// Returns an indication whether the current data is inserted into FORMULAFEED table successfully.
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
        /// Returns an indication whether the current data is updated to FORMULAFEED table successfully.
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
        /// Returns an indication whether the current data is deleted from FORMULAFEED table successfully.
        /// </summary>
        /// <param name="trans">The System.Data.OracleClient.OracleTransaction used by this System.Data.OracleClient.OracleCommand.</param>
        /// <returns>true if delete data successfully; otherwise, false.</returns>
        public bool DeleteCurrentData(OracleTransaction trans)
        {
            return doDelete("LOID = " + DB.SetDouble(_LOID) + " ", trans);
        }

        /// <summary>
        /// Returns an indication whether the record of FORMULAFEED by specified LOID key is retrieved successfully.
        /// </summary>
        /// <param name="cLOID">The LOID key.</param>
        /// <param name="trans">The System.Data.OracleClient.OracleTransaction used by this System.Data.OracleClient.OracleCommand.</param>
        /// <returns>true if data is retrieved successfully; otherwise, false.</returns>
        public bool GetDataByLOID(double cLOID, OracleTransaction trans)
        {
            return doGetdata("LOID = " + DB.SetDouble(cLOID) + " ", trans);
        }

        /// <summary>
        /// Returns an indication whether the record of FORMULAFEED by specified MATERIALMASTER key is retrieved successfully.
        /// </summary>
        /// <param name="cMATERIALMASTER">The MATERIALMASTER key.</param>
        /// <param name="trans">The System.Data.OracleClient.OracleTransaction used by this System.Data.OracleClient.OracleCommand.</param>
        /// <returns>true if data is retrieved successfully; otherwise, false.</returns>
        public bool GetDataByMATERIALMASTER(double cMATERIALMASTER, OracleTransaction trans)
        {
            return doGetdata("MATERIALMASTER = " + DB.SetDouble(cMATERIALMASTER) + " ", trans);
        }

        /// <summary>
        /// Returns an indication whether the record of FORMULAFEED by specified NAME key is retrieved successfully.
        /// </summary>
        /// <param name="cNAME">The NAME key.</param>
        /// <param name="trans">The System.Data.OracleClient.OracleTransaction used by this System.Data.OracleClient.OracleCommand.</param>
        /// <returns>true if data is retrieved successfully; otherwise, false.</returns>
        public bool GetDataByNAME(string cNAME, OracleTransaction trans)
        {
            return doGetdata("UPPER(NAME) = " + DB.SetString(cNAME.ToUpper()) + " ", trans);
        }

        public bool DeleteDataByLOID(double cLOID, OracleTransaction trans)
        {
            return doDelete(" LOID = " + DB.SetDouble(cLOID) + " ", trans);
        }


        public bool GetDataByUniq(string  wh, OracleTransaction trans)
        {
            return doGetdata(wh, trans);
        }
        #endregion

        #region SQL Statements

        /// <summary>
        /// Gets the insert statement for FORMULAFEED table.
        /// </summary>
        private string sql_insert
        {
            get
            {
                string sql = "INSERT INTO " + tableName + "(ACTIVE, CAPACITY, CAPACITYRATE, CARBOHYDRATE, CREATEBY, CREATEON, ENERGY, ENERGYRATE, FAT, FEEDCATEGORY, LOID, MATERIALMASTER, NAME, PORTION, PROTEIN) ";
                sql += "VALUES (";
                sql += DB.SetString(_ACTIVE) + ", ";
                sql += DB.SetDouble(_CAPACITY) + ", ";
                sql += DB.SetDouble(_CAPACITYRATE) + ", ";
                sql += DB.SetDouble(_CARBOHYDRATE) + ", ";
                sql += DB.SetString(_CREATEBY) + ", ";
                sql += DB.SetDateTime(_CREATEON) + ", ";
                sql += DB.SetDouble(_ENERGY) + ", ";
                sql += DB.SetDouble(_ENERGYRATE) + ", ";
                sql += DB.SetDouble(_FAT) + ", ";
                sql += DB.SetString(_FEEDCATEGORY) + ", ";
                sql += DB.SetDouble(_LOID) + ", ";
                sql += (_MATERIALMASTER == 0 ? "NULL" : DB.SetDouble(_MATERIALMASTER)) + ", ";
                sql += DB.SetString(_NAME) + ", ";
                sql += DB.SetDouble(_PORTION) + ", ";
                sql += DB.SetDouble(_PROTEIN) + " ";
                sql += ")";
                return sql;
            }
        }

        /// <summary>
        /// Gets the update statement for FORMULAFEED table.
        /// </summary>
        private string sql_update
        {
            get
            {
                string sql = "UPDATE " + tableName + " SET ";
                sql += "ACTIVE = " + DB.SetString(_ACTIVE) + ", ";
                sql += "CAPACITY = " + DB.SetDouble(_CAPACITY) + ", ";
                sql += "CAPACITYRATE = " + DB.SetDouble(_CAPACITYRATE) + ", ";
                sql += "CARBOHYDRATE = " + DB.SetDouble(_CARBOHYDRATE) + ", ";
                sql += "ENERGY = " + DB.SetDouble(_ENERGY) + ", ";
                sql += "ENERGYRATE = " + DB.SetDouble(_ENERGYRATE) + ", ";
                sql += "FAT = " + DB.SetDouble(_FAT) + ", ";
                sql += "FEEDCATEGORY = " + DB.SetString(_FEEDCATEGORY) + ", ";
                sql += "MATERIALMASTER = " + (_MATERIALMASTER == 0 ? "NULL" : DB.SetDouble(_MATERIALMASTER)) + ", ";
                sql += "NAME = " + DB.SetString(_NAME) + ", ";
                sql += "PORTION = " + DB.SetDouble(_PORTION) + ", ";
                sql += "PROTEIN = " + DB.SetDouble(_PROTEIN) + ", ";
                sql += "UPDATEBY = " + DB.SetString(_UPDATEBY) + ", ";
                sql += "UPDATEON = " + DB.SetDateTime(_UPDATEON) + " ";
                return sql;
            }
        }

        /// <summary>
        /// Gets the delete statement for FORMULAFEED table.
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
        /// Gets the select statement for FORMULAFEED table.
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
        /// Returns an indication whether the current data is inserted into FORMULAFEED table successfully.
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
        /// Returns an indication whether the current data is updated to FORMULAFEED table successfully.
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
        /// Returns an indication whether the current data is deleted from FORMULAFEED table successfully.
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
        /// Returns an indication whether the record of FORMULAFEED by specified condition is retrieved successfully.
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
                        if (!Convert.IsDBNull(zRdr["CAPACITY"])) _CAPACITY = Convert.ToDouble(zRdr["CAPACITY"]);
                        if (!Convert.IsDBNull(zRdr["CAPACITYRATE"])) _CAPACITYRATE = Convert.ToDouble(zRdr["CAPACITYRATE"]);
                        if (!Convert.IsDBNull(zRdr["CARBOHYDRATE"])) _CARBOHYDRATE = Convert.ToDouble(zRdr["CARBOHYDRATE"]);
                        if (!Convert.IsDBNull(zRdr["CREATEBY"])) _CREATEBY = zRdr["CREATEBY"].ToString();
                        if (!Convert.IsDBNull(zRdr["CREATEON"])) _CREATEON = Convert.ToDateTime(zRdr["CREATEON"]);
                        if (!Convert.IsDBNull(zRdr["ENERGY"])) _ENERGY = Convert.ToDouble(zRdr["ENERGY"]);
                        if (!Convert.IsDBNull(zRdr["ENERGYRATE"])) _ENERGYRATE = Convert.ToDouble(zRdr["ENERGYRATE"]);
                        if (!Convert.IsDBNull(zRdr["FAT"])) _FAT = Convert.ToDouble(zRdr["FAT"]);
                        if (!Convert.IsDBNull(zRdr["FEEDCATEGORY"])) _FEEDCATEGORY = zRdr["FEEDCATEGORY"].ToString();
                        if (!Convert.IsDBNull(zRdr["LOID"])) _LOID = Convert.ToDouble(zRdr["LOID"]);
                        if (!Convert.IsDBNull(zRdr["MATERIALMASTER"])) _MATERIALMASTER = Convert.ToDouble(zRdr["MATERIALMASTER"]);
                        if (!Convert.IsDBNull(zRdr["NAME"])) _NAME = zRdr["NAME"].ToString();
                        if (!Convert.IsDBNull(zRdr["PORTION"])) _PORTION = Convert.ToDouble(zRdr["PORTION"]);
                        if (!Convert.IsDBNull(zRdr["PROTEIN"])) _PROTEIN = Convert.ToDouble(zRdr["PROTEIN"]);
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

        #region My Works

        private string sql_insert_no_mm
        {
            get
            {
                //string sql = "INSERT INTO " + tableName + "(ACTIVE, CAPACITY, CAPACITYRATE, CARBOHYDRATE, CREATEBY, CREATEON, ENERGY, ENERGYRATE, FAT, FEEDCATEGORY, LOID, MATERIALMASTER, NAME, PORTION, PROTEIN) ";
                string sql = "INSERT INTO " + tableName + "(ACTIVE, CAPACITY, CAPACITYRATE, CARBOHYDRATE, CREATEBY, CREATEON, ENERGY, ENERGYRATE, FAT, FEEDCATEGORY, LOID, NAME, PORTION, PROTEIN) ";
                sql += "VALUES (";
                sql += DB.SetString(_ACTIVE) + ", ";
                sql += DB.SetDouble(_CAPACITY) + ", ";
                sql += DB.SetDouble(_CAPACITYRATE) + ", ";
                sql += DB.SetDouble(_CARBOHYDRATE) + ", ";
                sql += DB.SetString(_CREATEBY) + ", ";
                sql += DB.SetDateTime(_CREATEON) + ", ";
                sql += DB.SetDouble(_ENERGY) + ", ";
                sql += DB.SetDouble(_ENERGYRATE) + ", ";
                sql += DB.SetDouble(_FAT) + ", ";
                sql += DB.SetString(_FEEDCATEGORY) + ", ";
                sql += DB.SetDouble(_LOID) + ", ";
                //sql += DB.SetDouble(_MATERIALMASTER) + ", ";
                sql += DB.SetString(_NAME) + ", ";
                sql += DB.SetDouble(_PORTION) + ", ";
                sql += DB.SetDouble(_PROTEIN) + " ";
                sql += ")";
                return sql;
            }
        }

        private string sql_update_no_mm
        {
            get
            {
                string sql = "UPDATE " + tableName + " SET ";
                sql += "ACTIVE = " + DB.SetString(_ACTIVE) + ", ";
                sql += "CAPACITY = " + DB.SetDouble(_CAPACITY) + ", ";
                sql += "CAPACITYRATE = " + DB.SetDouble(_CAPACITYRATE) + ", ";
                sql += "CARBOHYDRATE = " + DB.SetDouble(_CARBOHYDRATE) + ", ";
                sql += "ENERGY = " + DB.SetDouble(_ENERGY) + ", ";
                sql += "ENERGYRATE = " + DB.SetDouble(_ENERGYRATE) + ", ";
                sql += "FAT = " + DB.SetDouble(_FAT) + ", ";
                sql += "FEEDCATEGORY = " + DB.SetString(_FEEDCATEGORY) + ", ";
                //sql += "MATERIALMASTER = " + DB.SetDouble(_MATERIALMASTER) + ", ";
                sql += "NAME = " + DB.SetString(_NAME) + ", ";
                sql += "PORTION = " + DB.SetDouble(_PORTION) + ", ";
                sql += "PROTEIN = " + DB.SetDouble(_PROTEIN) + ", ";
                sql += "UPDATEBY = " + DB.SetString(_UPDATEBY) + ", ";
                sql += "UPDATEON = " + DB.SetDateTime(_UPDATEON) + " ";
                return sql;
            }
        }

        public bool InsertDataNoMaterialMaster(string userID, OracleTransaction trans)
        {
            _LOID = DB.GetNextID(TableName, trans);
            _CREATEBY = userID;
            _CREATEON = DateTime.Now;
            return doInsertNoMaterialMaster(trans);
        }

        public bool doInsertNoMaterialMaster(OracleTransaction trans)
        {
            bool ret = true;
            int affectedRow = 0;
            if (!_OnDB)
            {
                try
                {
                    affectedRow = DB.ExecuteNonQuery(sql_insert_no_mm, trans);
                    ret = (affectedRow > 0);
                    if (!ret) _error = DataResources.MSGEN001;
                    _information = DataResources.MSGIN001;
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

        public bool UpdateDataNoMaterialMaster(string userID, OracleTransaction trans)
        {
            _UPDATEBY = userID;
            _UPDATEON = DateTime.Now;
            return doUpdateNoMaterialMaster("LOID = " + DB.SetDouble(_LOID) + " ", trans);
        }

        public bool doUpdateNoMaterialMaster(string whText, OracleTransaction trans)
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
                        affectedRow = DB.ExecuteNonQuery(sql_update_no_mm + tmpWhere, trans);
                        ret = (affectedRow > 0);
                        if (!ret) _error = DataResources.MSGEU001;
                        _information = DataResources.MSGIU001;
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

        public string GetRunningCopyName(string copyName, OracleTransaction trans)
        {
            return copyName + "_" + Convert.ToDouble(DB.GetRunningCode("FORMULAFEED", "NAME", trans)).ToString();
        }

        public bool DeleteFormulaFeed(string whText, OracleTransaction trans)
        {
            bool ret = true;
            _deletedRow = 0;
            if (whText.Trim() != "")
            {
                string tmpWhere = "WHERE " + whText;
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