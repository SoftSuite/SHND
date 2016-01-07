using System;
using System.Data;
using System.Data.OracleClient;
using DB = SHND.DAL.Utilities.OracleDB;
using SHND.Data.Common.Utilities;

namespace SHND.DAL.Views
{
    /// <summary>
    /// Represents a transaction for PLANORDERCOUNCIL table.
    /// [Created by 127.0.0.1 on Febuary,3 2009]
    /// </summary>
    public class PlanOrderCouncilDAL
    {

        public PlanOrderCouncilDAL()
        {
        }

        #region Constant

        /// <summary>PLANORDERCOUNCIL</summary>
        private const string tableName = "PLANORDERCOUNCIL";

        #endregion

        #region Private Variables

        int _deletedRow = 0;
        string _error = "";
        string _information = "";
        bool _OnDB = false;
        string _CREATEBY = "";
        DateTime _CREATEON = new DateTime(1, 1, 1);
        double _DIVISION = 0;
        double _LOID = 0;
        string _M1 = "";
        string _M10 = "";
        string _M11 = "";
        string _M12 = "";
        string _M2 = "";
        string _M3 = "";
        string _M4 = "";
        string _M5 = "";
        string _M6 = "";
        string _M7 = "";
        string _M8 = "";
        string _M9 = "";
        double _OFFICER = 0;
        double _PLANORDER = 0;
        string _POSITION = "";
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
        public double DIVISION
        {
            get { return _DIVISION; }
            set { _DIVISION = value; }
        }
        public double LOID
        {
            get { return _LOID; }
            set { _LOID = value; }
        }
        public string M1
        {
            get { return _M1; }
            set { _M1 = value; }
        }
        public string M10
        {
            get { return _M10; }
            set { _M10 = value; }
        }
        public string M11
        {
            get { return _M11; }
            set { _M11 = value; }
        }
        public string M12
        {
            get { return _M12; }
            set { _M12 = value; }
        }
        public string M2
        {
            get { return _M2; }
            set { _M2 = value; }
        }
        public string M3
        {
            get { return _M3; }
            set { _M3 = value; }
        }
        public string M4
        {
            get { return _M4; }
            set { _M4 = value; }
        }
        public string M5
        {
            get { return _M5; }
            set { _M5 = value; }
        }
        public string M6
        {
            get { return _M6; }
            set { _M6 = value; }
        }
        public string M7
        {
            get { return _M7; }
            set { _M7 = value; }
        }
        public string M8
        {
            get { return _M8; }
            set { _M8 = value; }
        }
        public string M9
        {
            get { return _M9; }
            set { _M9 = value; }
        }
        public double OFFICER
        {
            get { return _OFFICER; }
            set { _OFFICER = value; }
        }
        public double PLANORDER
        {
            get { return _PLANORDER; }
            set { _PLANORDER = value; }
        }
        public string POSITION
        {
            get { return _POSITION; }
            set { _POSITION = value; }
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
            _DIVISION = 0;
            _LOID = 0;
            _M1 = "";
            _M10 = "";
            _M11 = "";
            _M12 = "";
            _M2 = "";
            _M3 = "";
            _M4 = "";
            _M5 = "";
            _M6 = "";
            _M7 = "";
            _M8 = "";
            _M9 = "";
            _OFFICER = 0;
            _PLANORDER = 0;
            _POSITION = "";
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
        /// Returns an indication whether the current data is inserted into PLANORDERCOUNCIL table successfully.
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
        /// Returns an indication whether the current data is updated to PLANORDERCOUNCIL table successfully.
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
        /// Returns an indication whether the current data is deleted from PLANORDERCOUNCIL table successfully.
        /// </summary>
        /// <param name="trans">The System.Data.OracleClient.OracleTransaction used by this System.Data.OracleClient.OracleCommand.</param>
        /// <returns>true if delete data successfully; otherwise, false.</returns>
        public bool DeleteCurrentData(OracleTransaction trans)
        {
            return doDelete("LOID = " + DB.SetDouble(_LOID) + " ", trans);
        }

        /// <summary>
        /// Returns an indication whether the record of PLANORDERCOUNCIL by specified LOID key is retrieved successfully.
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
        /// Gets the insert statement for PLANORDERCOUNCIL table.
        /// </summary>
        private string sql_insert
        {
            get
            {
                string sql = "INSERT INTO " + tableName + "(CREATEBY, CREATEON, DIVISION, LOID, M1, M10, M11, M12, M2, M3, M4, M5, M6, M7, M8, M9, OFFICER, PLANORDER, POSITION) ";
                sql += "VALUES (";
                sql += DB.SetString(_CREATEBY) + ", ";
                sql += DB.SetDateTime(_CREATEON) + ", ";
                sql += DB.SetDouble(_DIVISION) + ", ";
                sql += DB.SetDouble(_LOID) + ", ";
                sql += DB.SetString(_M1) + ", ";
                sql += DB.SetString(_M10) + ", ";
                sql += DB.SetString(_M11) + ", ";
                sql += DB.SetString(_M12) + ", ";
                sql += DB.SetString(_M2) + ", ";
                sql += DB.SetString(_M3) + ", ";
                sql += DB.SetString(_M4) + ", ";
                sql += DB.SetString(_M5) + ", ";
                sql += DB.SetString(_M6) + ", ";
                sql += DB.SetString(_M7) + ", ";
                sql += DB.SetString(_M8) + ", ";
                sql += DB.SetString(_M9) + ", ";
                sql += DB.SetDouble(_OFFICER) + ", ";
                sql += DB.SetDouble(_PLANORDER) + ", ";
                sql += DB.SetString(_POSITION) + " ";
                sql += ")";
                return sql;
            }
        }

        /// <summary>
        /// Gets the update statement for PLANORDERCOUNCIL table.
        /// </summary>
        private string sql_update
        {
            get
            {
                string sql = "UPDATE " + tableName + " SET ";
                sql += "DIVISION = " + DB.SetDouble(_DIVISION) + ", ";
                sql += "M1 = " + DB.SetString(_M1) + ", ";
                sql += "M10 = " + DB.SetString(_M10) + ", ";
                sql += "M11 = " + DB.SetString(_M11) + ", ";
                sql += "M12 = " + DB.SetString(_M12) + ", ";
                sql += "M2 = " + DB.SetString(_M2) + ", ";
                sql += "M3 = " + DB.SetString(_M3) + ", ";
                sql += "M4 = " + DB.SetString(_M4) + ", ";
                sql += "M5 = " + DB.SetString(_M5) + ", ";
                sql += "M6 = " + DB.SetString(_M6) + ", ";
                sql += "M7 = " + DB.SetString(_M7) + ", ";
                sql += "M8 = " + DB.SetString(_M8) + ", ";
                sql += "M9 = " + DB.SetString(_M9) + ", ";
                sql += "OFFICER = " + DB.SetDouble(_OFFICER) + ", ";
                sql += "PLANORDER = " + DB.SetDouble(_PLANORDER) + ", ";
                sql += "POSITION = " + DB.SetString(_POSITION) + ", ";
                sql += "UPDATEBY = " + DB.SetString(_UPDATEBY) + ", ";
                sql += "UPDATEON = " + DB.SetDateTime(_UPDATEON) + " ";
                return sql;
            }
        }

        /// <summary>
        /// Gets the delete statement for PLANORDERCOUNCIL table.
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
        /// Gets the select statement for PLANORDERCOUNCIL table.
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
        /// Returns an indication whether the current data is inserted into PLANORDERCOUNCIL table successfully.
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
        /// Returns an indication whether the current data is updated to PLANORDERCOUNCIL table successfully.
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
        /// Returns an indication whether the current data is deleted from PLANORDERCOUNCIL table successfully.
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
        /// Returns an indication whether the record of PLANORDERCOUNCIL by specified condition is retrieved successfully.
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
                            if (!Convert.IsDBNull(zRdr["DIVISION"])) _DIVISION = Convert.ToDouble(zRdr["DIVISION"]);
                            if (!Convert.IsDBNull(zRdr["LOID"])) _LOID = Convert.ToDouble(zRdr["LOID"]);
                            if (!Convert.IsDBNull(zRdr["M1"])) _M1 = zRdr["M1"].ToString();
                            if (!Convert.IsDBNull(zRdr["M10"])) _M10 = zRdr["M10"].ToString();
                            if (!Convert.IsDBNull(zRdr["M11"])) _M11 = zRdr["M11"].ToString();
                            if (!Convert.IsDBNull(zRdr["M12"])) _M12 = zRdr["M12"].ToString();
                            if (!Convert.IsDBNull(zRdr["M2"])) _M2 = zRdr["M2"].ToString();
                            if (!Convert.IsDBNull(zRdr["M3"])) _M3 = zRdr["M3"].ToString();
                            if (!Convert.IsDBNull(zRdr["M4"])) _M4 = zRdr["M4"].ToString();
                            if (!Convert.IsDBNull(zRdr["M5"])) _M5 = zRdr["M5"].ToString();
                            if (!Convert.IsDBNull(zRdr["M6"])) _M6 = zRdr["M6"].ToString();
                            if (!Convert.IsDBNull(zRdr["M7"])) _M7 = zRdr["M7"].ToString();
                            if (!Convert.IsDBNull(zRdr["M8"])) _M8 = zRdr["M8"].ToString();
                            if (!Convert.IsDBNull(zRdr["M9"])) _M9 = zRdr["M9"].ToString();
                            if (!Convert.IsDBNull(zRdr["OFFICER"])) _OFFICER = Convert.ToDouble(zRdr["OFFICER"]);
                            if (!Convert.IsDBNull(zRdr["PLANORDER"])) _PLANORDER = Convert.ToDouble(zRdr["PLANORDER"]);
                            if (!Convert.IsDBNull(zRdr["POSITION"])) _POSITION = zRdr["POSITION"].ToString();
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

        public bool DeleteDataByConditions(double cPLANORDER, string exceptOfficerList, OracleTransaction trans)
        {
            return doDelete("PLANORDER = " + DB.SetDouble(cPLANORDER) + " AND OFFICER NOT IN (" + exceptOfficerList + ")", trans);
        }

        public bool GetDataByConditions(double cPLANORDER, double cOFFICER, OracleTransaction trans)
        {
            return doGetdata("PLANORDER = " + DB.SetDouble(cPLANORDER) + " AND OFFICER = " + DB.SetDouble(cOFFICER), trans);
        }

    }
}