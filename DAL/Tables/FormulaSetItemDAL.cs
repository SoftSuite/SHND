using System;
using System.Data;
using System.Data.OracleClient;
using DB = SHND.DAL.Utilities.OracleDB;
using SHND.Data.Common.Utilities;

namespace SHND.DAL.Tables
{
    /// <summary>
    /// Represents a transaction for FORMULASETITEM table.
    /// [Created by 127.0.0.1 on January,5 2009]
    /// </summary>
    public class FormulaSetItemDAL
    {

        public FormulaSetItemDAL()
        {
        }

        #region Constant

        /// <summary>FORMULASETITEM</summary>
        private const string tableName = "FORMULASETITEM";

        #endregion

        #region Private Variables

        int _deletedRow = 0;
        string _error = "";
        string _information = "";
        bool _OnDB = false;
        string _CREATEBY = "";
        DateTime _CREATEON = new DateTime(1, 1, 1);
        double _ENERGY = 0;
        double _FORMULASET = 0;
        double _LOID = 0;
        double _MATERIALMASTER = 0;
        string _PREPARENAME = "";
        double _REFFORMULA = 0;
        string _UPDATEBY = "";
        DateTime _UPDATEON = new DateTime(1, 1, 1);
        double _WEIGHT = 0;
        double _WEIGHTRAW = 0;
        double _WEIGHTRIPE = 0;

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
        public double ENERGY
        {
            get { return _ENERGY; }
            set { _ENERGY = value; }
        }
        public double FORMULASET
        {
            get { return _FORMULASET; }
            set { _FORMULASET = value; }
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
        public string PREPARENAME
        {
            get { return _PREPARENAME; }
            set { _PREPARENAME = value; }
        }
        public double REFFORMULA
        {
            get { return _REFFORMULA; }
            set { _REFFORMULA = value; }
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
        public double WEIGHT
        {
            get { return _WEIGHT; }
            set { _WEIGHT = value; }
        }
        public double WEIGHTRAW
        {
            get { return _WEIGHTRAW; }
            set { _WEIGHTRAW = value; }
        }
        public double WEIGHTRIPE
        {
            get { return _WEIGHTRIPE; }
            set { _WEIGHTRIPE = value; }
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
            _ENERGY = 0;
            _FORMULASET = 0;
            _LOID = 0;
            _MATERIALMASTER = 0;
            _PREPARENAME = "";
            _REFFORMULA = 0;
            _UPDATEBY = "";
            _UPDATEON = new DateTime(1, 1, 1);
            _WEIGHT = 0;
            _WEIGHTRAW = 0;
            _WEIGHTRIPE = 0;
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
        /// Returns an indication whether the current data is inserted into FORMULASETITEM table successfully.
        /// </summary>
        /// <param name="userID">The current user.</param>
        /// <param name="trans">The System.Data.OracleClient.OracleTransaction used by this System.Data.OracleClient.OracleCommand.</param>
        /// <returns>true if insert data successfully; otherwise, false.</returns>
        public bool InsertCurrentData(string userID, OracleTransaction trans)
        {
            //_LOID = DB.GetNextID(TableName, trans);
            _CREATEBY = userID;
            _CREATEON = DateTime.Now;
            return doInsert(trans);
        }

        /// <summary>
        /// Returns an indication whether the current data is updated to FORMULASETITEM table successfully.
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
        /// Returns an indication whether the current data is deleted from FORMULASETITEM table successfully.
        /// </summary>
        /// <param name="trans">The System.Data.OracleClient.OracleTransaction used by this System.Data.OracleClient.OracleCommand.</param>
        /// <returns>true if delete data successfully; otherwise, false.</returns>
        public bool DeleteCurrentData(OracleTransaction trans)
        {
            return doDelete("LOID = " + DB.SetDouble(_LOID) + " ", trans);
        }

        /// <summary>
        /// Returns an indication whether the record of FORMULASETITEM by specified LOID key is retrieved successfully.
        /// </summary>
        /// <param name="cLOID">The LOID key.</param>
        /// <param name="trans">The System.Data.OracleClient.OracleTransaction used by this System.Data.OracleClient.OracleCommand.</param>
        /// <returns>true if data is retrieved successfully; otherwise, false.</returns>
        public bool GetDataByLOID(double cLOID, OracleTransaction trans)
        {
            return doGetdata("LOID = " + DB.SetDouble(cLOID) + " ", trans);
        }

        /// <summary>
        /// Returns an indication whether the record of FORMULASETITEM by specified MATERIALMASTER key is retrieved successfully.
        /// </summary>
        /// <param name="cMATERIALMASTER">The MATERIALMASTER key.</param>
        /// <param name="trans">The System.Data.OracleClient.OracleTransaction used by this System.Data.OracleClient.OracleCommand.</param>
        /// <returns>true if data is retrieved successfully; otherwise, false.</returns>
        public bool GetDataByMATERIALMASTER(double cMATERIALMASTER, OracleTransaction trans)
        {
            return doGetdata("MATERIALMASTER = " + DB.SetDouble(cMATERIALMASTER) + " ", trans);
        }

        public bool GetDataByUniqueKey(double cFORMULASET, double cMATERIALMASTER, double cREFFORMULA, OracleTransaction trans)
        {
            return doGetdata("FORMULASET = " + DB.SetDouble(cFORMULASET) + " AND MATERIALMASTER = " + DB.SetDouble(cMATERIALMASTER) + " AND REFFORMULA " + (cREFFORMULA != 0 ? (" = " + DB.SetDouble(cREFFORMULA)) : "IS NULL") + " ", trans);
        }

        public bool DeleteDataByFormulaSet(double cFORMULASET, OracleTransaction trans)
        {
            return doDelete("FORMULASET = " + DB.SetDouble(cFORMULASET) + " ", trans);
        }

        public bool DeleteDataByRefFormulaSet(double cFORMULASET, OracleTransaction trans)
        {
            return doDelete("FORMULASET = " + DB.SetDouble(cFORMULASET) + " AND REFFORMULA IS NOT NULL", trans);
        }

        #endregion

        #region SQL Statements

        /// <summary>
        /// Gets the insert statement for FORMULASETITEM table.
        /// </summary>
        private string sql_insert
        {
            get
            {
                string sql = "INSERT INTO " + tableName + "(CREATEBY, CREATEON, ENERGY, FORMULASET, MATERIALMASTER, PREPARENAME, REFFORMULA, WEIGHT, WEIGHTRAW, WEIGHTRIPE) ";
                sql += "VALUES (";
                sql += DB.SetString(_CREATEBY) + ", ";
                sql += DB.SetDateTime(_CREATEON) + ", ";
                sql += DB.SetDouble(_ENERGY) + ", ";
                sql += DB.SetDouble(_FORMULASET) + ", ";
                //sql += DB.SetDouble(_LOID) + ", ";
                sql += DB.SetDouble(_MATERIALMASTER) + ", ";
                sql += DB.SetString(_PREPARENAME) + ", ";
                sql += (_REFFORMULA == 0 ? "NULL" : DB.SetDouble(_REFFORMULA)) + ", ";
                sql += DB.SetDouble(_WEIGHT) + ", ";
                sql += DB.SetDouble(_WEIGHTRAW) + ", ";
                sql += DB.SetDouble(_WEIGHTRIPE) + " ";
                sql += ")";
                return sql;
            }
        }

        /// <summary>
        /// Gets the update statement for FORMULASETITEM table.
        /// </summary>
        private string sql_update
        {
            get
            {
                string sql = "UPDATE " + tableName + " SET ";
                sql += "ENERGY = " + DB.SetDouble(_ENERGY) + ", ";
                sql += "FORMULASET = " + DB.SetDouble(_FORMULASET) + ", ";
                sql += "MATERIALMASTER = " + DB.SetDouble(_MATERIALMASTER) + ", ";
                sql += "PREPARENAME = " + DB.SetString(_PREPARENAME) + ", ";
                sql += "REFFORMULA = " + (_REFFORMULA == 0 ? "NULL" : DB.SetDouble(_REFFORMULA)) + ", ";
                sql += "UPDATEBY = " + DB.SetString(_UPDATEBY) + ", ";
                sql += "UPDATEON = " + DB.SetDateTime(_UPDATEON) + ", ";
                sql += "WEIGHT = " + DB.SetDouble(_WEIGHT) + ", ";
                sql += "WEIGHTRAW = " + DB.SetDouble(_WEIGHTRAW) + ", ";
                sql += "WEIGHTRIPE = " + DB.SetDouble(_WEIGHTRIPE) + " ";
                return sql;
            }
        }

        /// <summary>
        /// Gets the delete statement for FORMULASETITEM table.
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
        /// Gets the select statement for FORMULASETITEM table.
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
        /// Returns an indication whether the current data is inserted into FORMULASETITEM table successfully.
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
        /// Returns an indication whether the current data is updated to FORMULASETITEM table successfully.
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
        /// Returns an indication whether the current data is deleted from FORMULASETITEM table successfully.
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
        /// Returns an indication whether the record of FORMULASETITEM by specified condition is retrieved successfully.
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
                        if (!Convert.IsDBNull(zRdr["ENERGY"])) _ENERGY = Convert.ToDouble(zRdr["ENERGY"]);
                        if (!Convert.IsDBNull(zRdr["FORMULASET"])) _FORMULASET = Convert.ToDouble(zRdr["FORMULASET"]);
                        if (!Convert.IsDBNull(zRdr["LOID"])) _LOID = Convert.ToDouble(zRdr["LOID"]);
                        if (!Convert.IsDBNull(zRdr["MATERIALMASTER"])) _MATERIALMASTER = Convert.ToDouble(zRdr["MATERIALMASTER"]);
                        if (!Convert.IsDBNull(zRdr["PREPARENAME"])) _PREPARENAME = zRdr["PREPARENAME"].ToString();
                        if (!Convert.IsDBNull(zRdr["REFFORMULA"])) _REFFORMULA = Convert.ToDouble(zRdr["REFFORMULA"]);
                        if (!Convert.IsDBNull(zRdr["UPDATEBY"])) _UPDATEBY = zRdr["UPDATEBY"].ToString();
                        if (!Convert.IsDBNull(zRdr["UPDATEON"])) _UPDATEON = Convert.ToDateTime(zRdr["UPDATEON"]);
                        if (!Convert.IsDBNull(zRdr["WEIGHT"])) _WEIGHT = Convert.ToDouble(zRdr["WEIGHT"]);
                        if (!Convert.IsDBNull(zRdr["WEIGHTRAW"])) _WEIGHTRAW = Convert.ToDouble(zRdr["WEIGHTRAW"]);
                        if (!Convert.IsDBNull(zRdr["WEIGHTRIPE"])) _WEIGHTRIPE = Convert.ToDouble(zRdr["WEIGHTRIPE"]);
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

        public double GetWeightPrepare(double materialMasterID, double weight)
        {
            //หาน้ำหนักดิบของวัสดุอาหารในสูตร คำนวณจากน้ำหนักเบิก
            string sql = "SELECT CASE WHEN NVL(MM.WEIGHT,0)=0 THEN 0 ELSE  ROUND((" + DB.SetDouble(weight) + " * NVL(MM.WEIGHTPREPARE,0))/NVL(MM.WEIGHT,0),2) ";
            sql += " FROM MATERIALMASTER MM ";
            sql += " WHERE MM.LOID= " + DB.SetDouble(materialMasterID);

            return Convert.ToDouble(DB.ExecuteScalar(sql));
        }

        public double GetWeightStockout(double materialMasterID, double weight)
        {
            //หาน้ำหนักเบิกของวัสดุอาหารในสูตร คำนวณจากน้ำหนักดิบหรือน้ำหนักสูตร
            string sql = "SELECT CASE WHEN NVL(MM.WEIGHTPREPARE,0)=0 THEN 0 ELSE ROUND((" + DB.SetDouble(weight) + " * NVL(MM.WEIGHT,0))/NVL(MM.WEIGHTPREPARE,0),2) END ";
            sql += " FROM MATERIALMASTER MM ";
            sql += " WHERE MM.LOID= " + DB.SetDouble(materialMasterID);

            return Convert.ToDouble(DB.ExecuteScalar(sql));
        }

        public double GetWeigntCook(double materialMasterID, double weight, double cookType)
        {
            string sql = "";
            if (cookType == Convert.ToDouble(Constant.CookType.CookTypeBO.Loid))
                sql = "SELECT NVL(WEIGHTCOOKBO,0) * " + DB.SetDouble(weight) + " FROM MATERIALMASTER WHERE LOID=" + DB.SetDouble(materialMasterID);
            else if (cookType == Convert.ToDouble(Constant.CookType.CookTypeFR.Loid))
                sql = "SELECT (NVL(WEIGHTCOOKFR,0) * " + DB.SetDouble(weight) + ") - ((NVL(OILFR,0) * " + DB.SetDouble(weight) + ") /100) FROM MATERIALMASTER WHERE LOID=" + DB.SetDouble(materialMasterID);
            else if (cookType == Convert.ToDouble(Constant.CookType.CookTypeRO.Loid))
                sql = "SELECT NVL(WEIGHTCOOKRO,0) * " + DB.SetDouble(weight) + " FROM MATERIALMASTER WHERE LOID=" + DB.SetDouble(materialMasterID);
            else if (cookType == Convert.ToDouble(Constant.CookType.CookTypeFY.Loid))
                sql = "SELECT (NVL(WEIGHTCOOKFY,0) * " + DB.SetDouble(weight) + ") - ((NVL(OILFY,0) * " + DB.SetDouble(weight) + ") /100) FROM MATERIALMASTER WHERE LOID=" + DB.SetDouble(materialMasterID);
            else if (cookType == Convert.ToDouble(Constant.CookType.CookTypeST.Loid))
                sql = "SELECT NVL(WEIGHTCOOKST,0) * " + DB.SetDouble(weight) + " FROM MATERIALMASTER WHERE LOID=" + DB.SetDouble(materialMasterID);
            else if (cookType == Convert.ToDouble(Constant.CookType.CookTypeNN.Loid))
                sql = "SELECT NVL(WEIGHTCOOKNN,0) * " + DB.SetDouble(weight) + " FROM MATERIALMASTER WHERE LOID=" + DB.SetDouble(materialMasterID);
            else if (cookType == Convert.ToDouble(Constant.CookType.CookTypePE.Loid))
                sql = "SELECT NVL(WEIGHTCOOKPE,0) * " + DB.SetDouble(weight) + " FROM MATERIALMASTER WHERE LOID=" + DB.SetDouble(materialMasterID);

            return Convert.ToDouble(DB.ExecuteScalar(sql));
        }
    }
}