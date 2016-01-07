using System;
using System.Data;
using System.Data.OracleClient;
using DB = SHND.DAL.Utilities.OracleDB;
using SHND.Data.Common.Utilities;

namespace SHND.DAL.Tables
{
    /// <summary>
    /// Represents a transaction for FORMULAFEEDITEM table.
    /// [Created by 127.0.0.1 on January,6 2009]
    /// </summary>
    public class FormularFeedItemDAL
    {

        public FormularFeedItemDAL()
        {
        }

        #region Constant

        /// <summary>FORMULAFEEDITEM</summary>
        private const string tableName = "FORMULAFEEDITEM";

        #endregion

        #region Private Variables

        int _deletedRow = 0;
        string _error = "";
        string _information = "";
        bool _OnDB = false;
        string _CREATEBY = "";
        DateTime _CREATEON = new DateTime(1, 1, 1);
        double _ENERGY = 0;
        double _FORMULAFEED = 0;
        double _LOID = 0;
        double _MATERIALMASTER = 0;
        double _QTY = 0;
        double _UNIT = 0;
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
        public double FORMULAFEED
        {
            get { return _FORMULAFEED; }
            set { _FORMULAFEED = value; }
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
        public double QTY
        {
            get { return _QTY; }
            set { _QTY = value; }
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
            _FORMULAFEED = 0;
            _LOID = 0;
            _MATERIALMASTER = 0;
            _QTY = 0;
            _UNIT = 0;
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
        /// Returns an indication whether the current data is inserted into FORMULAFEEDITEM table successfully.
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
        /// Returns an indication whether the current data is updated to FORMULAFEEDITEM table successfully.
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
        /// Returns an indication whether the current data is deleted from FORMULAFEEDITEM table successfully.
        /// </summary>
        /// <param name="trans">The System.Data.OracleClient.OracleTransaction used by this System.Data.OracleClient.OracleCommand.</param>
        /// <returns>true if delete data successfully; otherwise, false.</returns>
        public bool DeleteCurrentData(OracleTransaction trans)
        {
            return doDelete("LOID = " + DB.SetDouble(_LOID) + " ", trans);
        }

        /// <summary>
        /// Returns an indication whether the record of FORMULAFEEDITEM by specified LOID key is retrieved successfully.
        /// </summary>
        /// <param name="cLOID">The LOID key.</param>
        /// <param name="trans">The System.Data.OracleClient.OracleTransaction used by this System.Data.OracleClient.OracleCommand.</param>
        /// <returns>true if data is retrieved successfully; otherwise, false.</returns>
        public bool GetDataByLOID(double cLOID, OracleTransaction trans)
        {
            return doGetdata("LOID = " + DB.SetDouble(cLOID) + " ", trans);
        }

        /// <summary>
        /// Returns an indication whether the record of FORMULAFEEDITEM by specified MATERIALMASTER key is retrieved successfully.
        /// </summary>
        /// <param name="cMATERIALMASTER">The MATERIALMASTER key.</param>
        /// <param name="trans">The System.Data.OracleClient.OracleTransaction used by this System.Data.OracleClient.OracleCommand.</param>
        /// <returns>true if data is retrieved successfully; otherwise, false.</returns>
        public bool GetDataByMATERIALMASTER(double cMATERIALMASTER, OracleTransaction trans)
        {
            return doGetdata("MATERIALMASTER = " + DB.SetDouble(cMATERIALMASTER) + " ", trans);
        }

        public DataTable GetDataListByFormulaFeed(double cFORMULAFEED, string orderBy, OracleTransaction trans)
        {
            return GetDataList("FORMULAFEED = " + DB.SetDouble(cFORMULAFEED), orderBy, trans);
        }

       
        #endregion

        #region SQL Statements

        /// <summary>
        /// Gets the insert statement for FORMULAFEEDITEM table.
        /// </summary>
        private string sql_insert
        {
            get
            {
                string sql = "INSERT INTO " + tableName + "(CREATEBY, CREATEON, ENERGY, FORMULAFEED, LOID, MATERIALMASTER, QTY, UNIT) ";
                sql += "VALUES (";
                sql += DB.SetString(_CREATEBY) + ", ";
                sql += DB.SetDateTime(_CREATEON) + ", ";
                sql += DB.SetDouble(_ENERGY) + ", ";
                sql += DB.SetDouble(_FORMULAFEED) + ", ";
                sql += DB.SetDouble(_LOID) + ", ";
                sql += DB.SetDouble(_MATERIALMASTER) + ", ";
                sql += DB.SetDouble(_QTY) + ", ";
                sql += DB.SetDouble(_UNIT) + " ";
                sql += ")";
                return sql;
            }
        }

        /// <summary>
        /// Gets the update statement for FORMULAFEEDITEM table.
        /// </summary>
        private string sql_update
        {
            get
            {
                string sql = "UPDATE " + tableName + " SET ";
                sql += "ENERGY = " + DB.SetDouble(_ENERGY) + ", ";
                sql += "FORMULAFEED = " + DB.SetDouble(_FORMULAFEED) + ", ";
                sql += "MATERIALMASTER = " + DB.SetDouble(_MATERIALMASTER) + ", ";
                sql += "QTY = " + DB.SetDouble(_QTY) + ", ";
                sql += "UNIT = " + DB.SetDouble(_UNIT) + ", ";
                sql += "UPDATEBY = " + DB.SetString(_UPDATEBY) + ", ";
                sql += "UPDATEON = " + DB.SetDateTime(_UPDATEON) + " ";
                return sql;
            }
        }

        /// <summary>
        /// Gets the delete statement for FORMULAFEEDITEM table.
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
        /// Gets the select statement for FORMULAFEEDITEM table.
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
        /// Returns an indication whether the current data is inserted into FORMULAFEEDITEM table successfully.
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
        /// Returns an indication whether the current data is updated to FORMULAFEEDITEM table successfully.
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
        /// Returns an indication whether the current data is deleted from FORMULAFEEDITEM table successfully.
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
        /// Returns an indication whether the record of FORMULAFEEDITEM by specified condition is retrieved successfully.
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
                        if (!Convert.IsDBNull(zRdr["FORMULAFEED"])) _FORMULAFEED = Convert.ToDouble(zRdr["FORMULAFEED"]);
                        if (!Convert.IsDBNull(zRdr["LOID"])) _LOID = Convert.ToDouble(zRdr["LOID"]);
                        if (!Convert.IsDBNull(zRdr["MATERIALMASTER"])) _MATERIALMASTER = Convert.ToDouble(zRdr["MATERIALMASTER"]);
                        if (!Convert.IsDBNull(zRdr["QTY"])) _QTY = Convert.ToDouble(zRdr["QTY"]);
                        if (!Convert.IsDBNull(zRdr["UNIT"])) _UNIT = Convert.ToDouble(zRdr["UNIT"]);
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

        #region my work nang

        private string sql_selectFormulaFeed
        {
            get
            {
                string sql = "SELECT VMM.LOID, FF.LOID FFLOID, VMM.ULOID UULOID , VMM.MATERIALNAME,FI.QTY COST ";
                sql += " ,U.THNAME ABBNAME,FI.LOID FILOID  ";
                sql += " FROM FORMULAFEED FF INNER JOIN FORMULAFEEDITEM FI ON FF.LOID = FI.FORMULAFEED ";
                sql += " INNER JOIN V_MATERIALMASTER VMM ON VMM.LOID = FI.MATERIALMASTER ";
                sql += " INNER JOIN UNIT U ON U.LOID=FI.UNIT ";
                return sql;
            }
        }

        private string sql_CalFormulaFeedNew
        {
            get
            {
                string sql = "SELECT VMM.LOID, FF.LOID FFLOID, VMM.ULOID UULOID , VMM.MATERIALNAME,FN_CALENERGYWEIGHT(VMM.LOID,1)  COST ";
                sql += " ,U.THNAME ABBNAME,FI.LOID FILOID  ";
                sql += " FROM FORMULAFEED FF INNER JOIN FORMULAFEEDITEM FI ON FF.LOID = FI.FORMULAFEED ";
                sql += " INNER JOIN V_MATERIALMASTER VMM ON VMM.LOID = FI.MATERIALMASTER ";
                sql += " INNER JOIN UNIT U ON U.LOID=FI.UNIT ";
                return sql;
            }
        }

        private string sql_selectFormulaFeedCopy
        {
            get
            {
                string sql = "SELECT VMM.LOID, 0 FFLOID, VMM.ULOID UULOID , VMM.MATERIALNAME,FI.QTY COST ";
                sql += " ,VMM.UNITNAME ABBNAME,0 FILOID  ";
                sql += " FROM FORMULAFEED FF INNER JOIN FORMULAFEEDITEM FI ON FF.LOID = FI.FORMULAFEED ";
                sql += " INNER JOIN V_MATERIALMASTER VMM ON VMM.LOID = FI.MATERIALMASTER ";
                return sql;
            }
        }



        #endregion

        #region Pom Work

        public bool DeleteNotInLOIDList(string ffiloidlist, string formulafeed_loid, OracleTransaction trans)
        { 
            string whrStr = "";
            if (ffiloidlist != "")
                whrStr = "FORMULAFEED = " + formulafeed_loid + " AND LOID NOT IN (" + ffiloidlist + ")";
            else
                whrStr = "FORMULAFEED = " + formulafeed_loid;
            
            bool ret = true;
            _deletedRow = 0;
            if (whrStr.Trim() != "")
            {
                string tmpWhere = "WHERE " + whrStr;
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

        public bool DeleteFormulaFeedItem(string whrStr, OracleTransaction trans)
        {
            bool ret = true;
            _deletedRow = 0;
            if (whrStr.Trim() != "")
            {
                string tmpWhere = "WHERE " + whrStr;
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

        public DataTable GetFormulaFeedItem(string whereClause, string orderBy, OracleTransaction trans)
        {
            string sql = "SELECT F.LOID AS LOID, F.FORMULAFEED, F.MATERIALMASTER, F.QTY, F.ENERGY, F.UNIT, M.NAME AS MMNAME";
            sql += " FROM FORMULAFEEDITEM F INNER JOIN MATERIALMASTER M ON F.MATERIALMASTER = M.LOID ";

            return DB.ExecuteTable(sql + (whereClause == "" ? "" : "WHERE " + whereClause + " ") + (orderBy == "" ? "" : "ORDER BY " + DB.SetSortString(orderBy)), trans);
        }


        #endregion

        #region My Work Nang


        public bool GetDataByUniqueKey(double cFORMULAFEED, double cMATERIALMASTER, OracleTransaction trans)
        {
            return doGetdata("FORMULAFEED = " + DB.SetDouble(cFORMULAFEED) + " AND MATERIALMASTER = " + DB.SetDouble(cMATERIALMASTER) + "  ", trans);
        }

        public bool DeleteDataByLOID(String strwh, OracleTransaction trans)
        {
            return doDelete(strwh, trans);
        }

        public bool DeleteDataByFormulaFeed(double cLOID, OracleTransaction trans)
        {
            return doDelete(" FORMULAFEED = " + DB.SetDouble(cLOID) + " ", trans);
        }
        public DataTable GetDataByFormulaFeed(string whereClause, string orderBy, OracleTransaction trans)
        {
            return DB.ExecuteTable(sql_selectFormulaFeed + (whereClause == "" ? "" : "WHERE " + whereClause + " ") + (orderBy == "" ? "" : "ORDER BY " + DB.SetSortString(orderBy)), trans);
        }

        public DataTable GetCalFormulaFeedNew(string whereClause, string orderBy, OracleTransaction trans)
        {
            return DB.ExecuteTable(sql_CalFormulaFeedNew + (whereClause == "" ? "" : "WHERE " + whereClause + " ") + (orderBy == "" ? "" : "ORDER BY " + DB.SetSortString(orderBy)), trans);
        }

        public DataTable GetDataByFormulaFeedCopy(string whereClause, string orderBy, OracleTransaction trans)
        {
            return DB.ExecuteTable(sql_selectFormulaFeedCopy + (whereClause == "" ? "" : "WHERE " + whereClause + " ") + (orderBy == "" ? "" : "ORDER BY " + DB.SetSortString(orderBy)), trans);
        }

        #endregion
    }
}