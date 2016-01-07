using System;
using System.Data;
using System.Data.OracleClient;
using DB = SHND.DAL.Utilities.OracleDB;
using SHND.Data.Common.Utilities;

namespace SHND.DAL.Tables
{
    /// <summary>
    /// Represents a transaction for OFFICER table.
    /// [Created by 127.0.0.1 on May,16 2009]
    /// </summary>
    public class OfficerDAL
    {

        public OfficerDAL()
        {
        }

        #region Constant

        /// <summary>OFFICER</summary>
        private const string tableName = "OFFICER";

        #endregion

        #region Private Variables

        int _deletedRow = 0;
        string _error = "";
        string _information = "";
        bool _OnDB = false;
        string _ACTIVE = "";
        string _CREATEBY = "";
        DateTime _CREATEON = new DateTime(1, 1, 1);
        double _DIVISION = 0;
        DateTime _EFDATE = new DateTime(1, 1, 1);
        string _EMAIL = "";
        DateTime _EPDATE = new DateTime(1, 1, 1);
        string _FIRSTNAME = "";
        string _FORCEPWCHANGE = "";
        DateTime _LASTACTIVE = new DateTime(1, 1, 1);
        DateTime _LASTLOGON = new DateTime(1, 1, 1);
        string _LASTNAME = "";
        DateTime _LASTPWCHANGE = new DateTime(1, 1, 1);
        double _LOGINFAILEDCOUNT = 0;
        double _LOID = 0;
        string _OFFICERGROUP = "";
        string _PASSWD = "";
        DateTime _PWEXPIREDATE = new DateTime(1, 1, 1);
        string _TEL = "";
        double _TITLE = 0;
        string _UPDATEBY = "";
        DateTime _UPDATEON = new DateTime(1, 1, 1);
        string _USERNAME = "";

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
        public double DIVISION
        {
            get { return _DIVISION; }
            set { _DIVISION = value; }
        }
        public DateTime EFDATE
        {
            get { return _EFDATE; }
            set { _EFDATE = value; }
        }
        public string EMAIL
        {
            get { return _EMAIL; }
            set { _EMAIL = value; }
        }
        public DateTime EPDATE
        {
            get { return _EPDATE; }
            set { _EPDATE = value; }
        }
        public string FIRSTNAME
        {
            get { return _FIRSTNAME; }
            set { _FIRSTNAME = value; }
        }
        public string FORCEPWCHANGE
        {
            get { return _FORCEPWCHANGE; }
            set { _FORCEPWCHANGE = value; }
        }
        public DateTime LASTACTIVE
        {
            get { return _LASTACTIVE; }
            set { _LASTACTIVE = value; }
        }
        public DateTime LASTLOGON
        {
            get { return _LASTLOGON; }
            set { _LASTLOGON = value; }
        }
        public string LASTNAME
        {
            get { return _LASTNAME; }
            set { _LASTNAME = value; }
        }
        public DateTime LASTPWCHANGE
        {
            get { return _LASTPWCHANGE; }
            set { _LASTPWCHANGE = value; }
        }
        public double LOGINFAILEDCOUNT
        {
            get { return _LOGINFAILEDCOUNT; }
            set { _LOGINFAILEDCOUNT = value; }
        }
        public double LOID
        {
            get { return _LOID; }
            set { _LOID = value; }
        }
        public string OFFICERGROUP
        {
            get { return _OFFICERGROUP; }
            set { _OFFICERGROUP = value; }
        }
        public string PASSWD
        {
            get { return _PASSWD; }
            set { _PASSWD = value; }
        }
        public DateTime PWEXPIREDATE
        {
            get { return _PWEXPIREDATE; }
            set { _PWEXPIREDATE = value; }
        }
        public string TEL
        {
            get { return _TEL; }
            set { _TEL = value; }
        }
        public double TITLE
        {
            get { return _TITLE; }
            set { _TITLE = value; }
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
        public string USERNAME
        {
            get { return _USERNAME; }
            set { _USERNAME = value; }
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
            _DIVISION = 0;
            _EFDATE = new DateTime(1, 1, 1);
            _EMAIL = "";
            _EPDATE = new DateTime(1, 1, 1);
            _FIRSTNAME = "";
            _FORCEPWCHANGE = "";
            _LASTACTIVE = new DateTime(1, 1, 1);
            _LASTLOGON = new DateTime(1, 1, 1);
            _LASTNAME = "";
            _LASTPWCHANGE = new DateTime(1, 1, 1);
            _LOGINFAILEDCOUNT = 0;
            _LOID = 0;
            _OFFICERGROUP = "";
            _PASSWD = "";
            _PWEXPIREDATE = new DateTime(1, 1, 1);
            _TEL = "";
            _TITLE = 0;
            _UPDATEBY = "";
            _UPDATEON = new DateTime(1, 1, 1);
            _USERNAME = "";
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
        /// Returns an indication whether the current data is inserted into OFFICER table successfully.
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
        /// Returns an indication whether the current data is updated to OFFICER table successfully.
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
        /// Returns an indication whether the current data is deleted from OFFICER table successfully.
        /// </summary>
        /// <param name="trans">The System.Data.OracleClient.OracleTransaction used by this System.Data.OracleClient.OracleCommand.</param>
        /// <returns>true if delete data successfully; otherwise, false.</returns>
        public bool DeleteCurrentData(OracleTransaction trans)
        {
            return doDelete("LOID = " + DB.SetDouble(_LOID) + " ", trans);
        }

        /// <summary>
        /// Returns an indication whether the record of OFFICER by specified LOID key is retrieved successfully.
        /// </summary>
        /// <param name="cLOID">The LOID key.</param>
        /// <param name="trans">The System.Data.OracleClient.OracleTransaction used by this System.Data.OracleClient.OracleCommand.</param>
        /// <returns>true if data is retrieved successfully; otherwise, false.</returns>
        public bool GetDataByLOID(double cLOID, OracleTransaction trans)
        {
            return doGetdata("LOID = " + DB.SetDouble(cLOID) + " ", trans);
        }

        /// <summary>
        /// Returns an indication whether the record of OFFICER by specified USERNAME key is retrieved successfully.
        /// </summary>
        /// <param name="cUSERNAME">The USERNAME key.</param>
        /// <param name="trans">The System.Data.OracleClient.OracleTransaction used by this System.Data.OracleClient.OracleCommand.</param>
        /// <returns>true if data is retrieved successfully; otherwise, false.</returns>
        public bool GetDataByUSERNAME(string cUSERNAME, OracleTransaction trans)
        {
            return doGetdata("USERNAME = " + DB.SetString(cUSERNAME) + " ", trans);
        }

        #endregion

        #region SQL Statements

        /// <summary>
        /// Gets the insert statement for OFFICER table.
        /// </summary>
        private string sql_insert
        {
            get
            {
                string sql = "INSERT INTO " + tableName + "(ACTIVE, CREATEBY, CREATEON, DIVISION, EFDATE, EMAIL, EPDATE, FIRSTNAME, FORCEPWCHANGE, LASTACTIVE, LASTLOGON, LASTNAME, LASTPWCHANGE, LOGINFAILEDCOUNT, LOID, OFFICERGROUP, PASSWD, PWEXPIREDATE, TEL, TITLE, USERNAME) ";
                sql += "VALUES (";
                sql += DB.SetString(_ACTIVE) + ", ";
                sql += DB.SetString(_CREATEBY) + ", ";
                sql += DB.SetDateTime(_CREATEON) + ", ";
                sql += DB.SetDouble(_DIVISION) + ", ";
                sql += DB.SetDateTime(_EFDATE) + ", ";
                sql += DB.SetString(_EMAIL) + ", ";
                sql += DB.SetDateTime(_EPDATE) + ", ";
                sql += DB.SetString(_FIRSTNAME) + ", ";
                sql += DB.SetString(_FORCEPWCHANGE) + ", ";
                sql += DB.SetDateTime(_LASTACTIVE) + ", ";
                sql += DB.SetDateTime(_LASTLOGON) + ", ";
                sql += DB.SetString(_LASTNAME) + ", ";
                sql += DB.SetDateTime(_LASTPWCHANGE) + ", ";
                sql += DB.SetDouble(_LOGINFAILEDCOUNT) + ", ";
                sql += DB.SetDouble(_LOID) + ", ";
                sql += DB.SetString(_OFFICERGROUP) + ", ";
                sql += DB.SetString(_PASSWD) + ", ";
                sql += DB.SetDateTime(_PWEXPIREDATE) + ", ";
                sql += DB.SetString(_TEL) + ", ";
                sql += DB.SetDouble(_TITLE) + ", ";
                sql += DB.SetString(_USERNAME) + " ";
                sql += ")";
                return sql;
            }
        }

        /// <summary>
        /// Gets the update statement for OFFICER table.
        /// </summary>
        private string sql_update
        {
            get
            {
                string sql = "UPDATE " + tableName + " SET ";
                sql += "ACTIVE = " + DB.SetString(_ACTIVE) + ", ";
                sql += "DIVISION = " + DB.SetDouble(_DIVISION) + ", ";
                sql += "EFDATE = " + DB.SetDateTime(_EFDATE) + ", ";
                sql += "EMAIL = " + DB.SetString(_EMAIL) + ", ";
                sql += "EPDATE = " + DB.SetDateTime(_EPDATE) + ", ";
                sql += "FIRSTNAME = " + DB.SetString(_FIRSTNAME) + ", ";
                sql += "FORCEPWCHANGE = " + DB.SetString(_FORCEPWCHANGE) + ", ";
                sql += "LASTACTIVE = " + DB.SetDateTime(_LASTACTIVE) + ", ";
                sql += "LASTLOGON = " + DB.SetDateTime(_LASTLOGON) + ", ";
                sql += "LASTNAME = " + DB.SetString(_LASTNAME) + ", ";
                sql += "LASTPWCHANGE = " + DB.SetDateTime(_LASTPWCHANGE) + ", ";
                sql += "LOGINFAILEDCOUNT = " + DB.SetDouble(_LOGINFAILEDCOUNT) + ", ";
                sql += "OFFICERGROUP = " + DB.SetString(_OFFICERGROUP) + ", ";
                sql += "PASSWD = " + DB.SetString(_PASSWD) + ", ";
                sql += "PWEXPIREDATE = " + DB.SetDateTime(_PWEXPIREDATE) + ", ";
                sql += "TEL = " + DB.SetString(_TEL) + ", ";
                sql += "TITLE = " + DB.SetDouble(_TITLE) + ", ";
                sql += "UPDATEBY = " + DB.SetString(_UPDATEBY) + ", ";
                sql += "UPDATEON = " + DB.SetDateTime(_UPDATEON) + ", ";
                sql += "USERNAME = " + DB.SetString(_USERNAME) + " ";
                return sql;
            }
        }

        /// <summary>
        /// Gets the delete statement for OFFICER table.
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
        /// Gets the select statement for OFFICER table.
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
        /// Returns an indication whether the current data is inserted into OFFICER table successfully.
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
        /// Returns an indication whether the current data is updated to OFFICER table successfully.
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
        /// Returns an indication whether the current data is deleted from OFFICER table successfully.
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
        /// Returns an indication whether the record of OFFICER by specified condition is retrieved successfully.
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
                        if (!Convert.IsDBNull(zRdr["DIVISION"])) _DIVISION = Convert.ToDouble(zRdr["DIVISION"]);
                        if (!Convert.IsDBNull(zRdr["EFDATE"])) _EFDATE = Convert.ToDateTime(zRdr["EFDATE"]);
                        if (!Convert.IsDBNull(zRdr["EMAIL"])) _EMAIL = zRdr["EMAIL"].ToString();
                        if (!Convert.IsDBNull(zRdr["EPDATE"])) _EPDATE = Convert.ToDateTime(zRdr["EPDATE"]);
                        if (!Convert.IsDBNull(zRdr["FIRSTNAME"])) _FIRSTNAME = zRdr["FIRSTNAME"].ToString();
                        if (!Convert.IsDBNull(zRdr["FORCEPWCHANGE"])) _FORCEPWCHANGE = zRdr["FORCEPWCHANGE"].ToString();
                        if (!Convert.IsDBNull(zRdr["LASTACTIVE"])) _LASTACTIVE = Convert.ToDateTime(zRdr["LASTACTIVE"]);
                        if (!Convert.IsDBNull(zRdr["LASTLOGON"])) _LASTLOGON = Convert.ToDateTime(zRdr["LASTLOGON"]);
                        if (!Convert.IsDBNull(zRdr["LASTNAME"])) _LASTNAME = zRdr["LASTNAME"].ToString();
                        if (!Convert.IsDBNull(zRdr["LASTPWCHANGE"])) _LASTPWCHANGE = Convert.ToDateTime(zRdr["LASTPWCHANGE"]);
                        if (!Convert.IsDBNull(zRdr["LOGINFAILEDCOUNT"])) _LOGINFAILEDCOUNT = Convert.ToDouble(zRdr["LOGINFAILEDCOUNT"]);
                        if (!Convert.IsDBNull(zRdr["LOID"])) _LOID = Convert.ToDouble(zRdr["LOID"]);
                        if (!Convert.IsDBNull(zRdr["OFFICERGROUP"])) _OFFICERGROUP = zRdr["OFFICERGROUP"].ToString();
                        if (!Convert.IsDBNull(zRdr["PASSWD"])) _PASSWD = zRdr["PASSWD"].ToString();
                        if (!Convert.IsDBNull(zRdr["PWEXPIREDATE"])) _PWEXPIREDATE = Convert.ToDateTime(zRdr["PWEXPIREDATE"]);
                        if (!Convert.IsDBNull(zRdr["TEL"])) _TEL = zRdr["TEL"].ToString();
                        if (!Convert.IsDBNull(zRdr["TITLE"])) _TITLE = Convert.ToDouble(zRdr["TITLE"]);
                        if (!Convert.IsDBNull(zRdr["UPDATEBY"])) _UPDATEBY = zRdr["UPDATEBY"].ToString();
                        if (!Convert.IsDBNull(zRdr["UPDATEON"])) _UPDATEON = Convert.ToDateTime(zRdr["UPDATEON"]);
                        if (!Convert.IsDBNull(zRdr["USERNAME"])) _USERNAME = zRdr["USERNAME"].ToString();
                    }
                    else
                    {
                        ret = false;
                        _error = DataResources.MSGEV002;
                    }
                    zRdr.Close();

                    // Get Menu Grant
                    if (_LOID != 0)
                    {
                        _AllMenu = DB.ExecuteTable(" SELECT * FROM ZMENU WHERE LOID NOT IN ( SELECT ZMENU FROM ZROLEASSIGN WHERE ZROLE = (SELECT LOID FROM ZROLE WHERE OFFICER = " + DB.SetDouble(_LOID) + ")) AND ENABLED = 'Y' ", trans);
                        _GrantMenu = DB.ExecuteTable(" SELECT * FROM ZMENU WHERE LOID IN ( SELECT ZMENU FROM ZROLEASSIGN WHERE ZROLE = (SELECT LOID FROM ZROLE WHERE OFFICER = " + DB.SetDouble(_LOID) + ")) AND ENABLED = 'Y' ", trans);
                        _AllGroup = DB.ExecuteTable("SELECT * FROM ZROLE WHERE ZLEVEL = 'G' AND LOID NOT IN ( SELECT PARENT FROM ZROLEREF WHERE ZROLE = (SELECT LOID FROM ZROLE WHERE OFFICER = " + DB.SetDouble(_LOID) + ") )", trans);
                        _GrantGroup = DB.ExecuteTable("SELECT * FROM ZROLE WHERE ZLEVEL = 'G' AND LOID IN ( SELECT PARENT FROM ZROLEREF WHERE ZROLE = (SELECT LOID FROM ZROLE WHERE OFFICER = " + DB.SetDouble(_LOID) + ") )", trans);
                        _AllWard = DB.ExecuteTable("SELECT * FROM WARD WHERE LOID NOT IN ( SELECT WARD FROM WARDRESPONSE WHERE OFFICER = " + DB.SetDouble(_LOID) + ") ORDER BY " + DB.SetSortString("NAME"), trans);
                        _GrantWard = DB.ExecuteTable("SELECT * FROM WARD WHERE LOID IN ( SELECT WARD FROM WARDRESPONSE WHERE OFFICER = " + DB.SetDouble(_LOID) + ") ORDER BY " + DB.SetSortString("NAME"), trans);
                    }
                    else
                    {
                        _AllMenu = DB.ExecuteTable("SELECT * FROM ZMENU WHERE ENABLED = 'Y' ", trans);
                        _AllGroup = DB.ExecuteTable(" SELECT * FROM ZROLE WHERE ZLEVEL = 'G' ", trans);
                        _AllWard = DB.ExecuteTable("SELECT * FROM WARD ORDER BY " + DB.SetSortString("NAME"), trans);
                    }
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


        public DataTable GetOfficerList(string UserID, string FName, string LName, string DivisionLOID, string OfficerGroup, string OrderString)
        {
            string whStr = "";
            whStr += (UserID.Trim() == "" ? "" :(whStr.Trim() == "" ? "" : " AND ") + " USERNAME LIKE " + DB.SetString("%" + UserID + "%"));
            whStr += (FName.Trim() == "" ? "" : (whStr.Trim() == "" ? "" : " AND ") + " FIRSTNAME LIKE " + DB.SetString("%" + FName + "%"));
            whStr += (LName.Trim() == "" ? "" : (whStr.Trim() == "" ? "" : " AND ") + " LASTNAME LIKE " + DB.SetString("%" + LName + "%"));
            whStr += (DivisionLOID.Trim() == "" ? "" : (whStr.Trim() == "" ? "" : " AND ") + " DIVISION = " + DivisionLOID + " ");
            whStr += (OfficerGroup.Trim() == "" ? "" : (whStr.Trim() == "" ? "" : " AND ") + " OFFICERGROUP = " + DB.SetString(OfficerGroup) + " ");

            string sqlz = " SELECT O.*, D.NAME as DIVISIONNAME, T.NAME as TITLENAME, NVL(T.NAME, '') || NVL(O.FIRSTNAME, '') || ' ' || NVL(O.LASTNAME, '') as OFFICERNAME ";
            sqlz += " FROM OFFICER O LEFT JOIN TITLE T ON O.TITLE = T.LOID LEFT JOIN DIVISION D ON O.DIVISION = D.LOID ";

            sqlz += (whStr.Trim() == "" ? "" : " WHERE " + whStr);
            sqlz += (OrderString.Trim() == "" ? "" : " ORDER BY " + OrderString);

            return DB.ExecuteTable(sqlz);

        }


        public bool GetDataByUserID(string userID)
        {
            return doGetdata(" USERNAME = " + DB.SetString(userID) + "", null);
        }

        public bool ChangePassword(string officerLOID, string EncryptedPassword)
        {
            bool ret = true;
            string sqlz = " UPDATE OFFICER SET PASSWD = " + DB.SetString(EncryptedPassword) + ", LASTPWCHANGE = sysdate, FORCEPWCHANGE = 'N', LOGINFAILEDCOUNT = '0' WHERE LOID = " + officerLOID;
            ret = ExecuteCommand(sqlz, null);
            return ret;
        }

        public bool IncreasePasswordCount(string officerLOID)
        {
            bool ret = true;
            string sqlz = " UPDATE OFFICER SET LOGINFAILEDCOUNT = NVL(LOGINFAILEDCOUNT,0) + 1 WHERE LOID = " + officerLOID;
            ret = ExecuteCommand(sqlz, null);
            return ret;
        }

        public bool ResetPasswordCount(string officerLOID)
        {
            bool ret = true;
            string sqlz = " UPDATE OFFICER SET LOGINFAILEDCOUNT = 0 WHERE LOID = " + officerLOID;
            DB.ExecuteNonQuery(sqlz);
            ret = ExecuteCommand(sqlz, null);
            return ret;
        }

        public bool SetLastLogin(string officerLOID)
        {
            bool ret = true;
            string sqlz = " UPDATE OFFICER SET LASTLOGON = sysdate WHERE LOID = " + officerLOID;
            DB.ExecuteNonQuery(sqlz);
            ret = ExecuteCommand(sqlz, null);
            return ret;
        }

        public bool SetActive(string officeLOID, int ActiveStatus)
        {
            bool ret = true;
            string sqlz = " UPDATE OFFICER SET ACTIVE = " + DB.SetDouble(ActiveStatus) + " WHERE LOID = " + officeLOID;
            DB.ExecuteNonQuery(sqlz);
            ret = ExecuteCommand(sqlz, null);
            return ret;
        }

        private bool ExecuteCommand(string sqlz, OracleTransaction zTrans)
        {
            bool ret = true;
            try
            {
                ret = (DB.ExecuteNonQuery(sqlz, zTrans) > 0);
                //ret = true;
            }
            catch (Exception ex)
            {
                _error = ex.Message;
                ret = false;
            }
            return ret;
        }

        DataTable _AllMenu;
        DataTable _GrantMenu;
        DataTable _AllGroup;
        DataTable _GrantGroup;
        DataTable _AllWard;
        DataTable _GrantWard;
        public DataTable AllMenu { get { if (_AllMenu == null) _AllMenu = new DataTable(); return _AllMenu; } }
        public DataTable GrantMenu { get { if (_GrantMenu == null) _GrantMenu = new DataTable(); return _GrantMenu; } }
        public DataTable AllGroup { get { if (_AllGroup == null) _AllGroup = new DataTable(); return _AllGroup; } }
        public DataTable GrantGroup { get { if (_GrantGroup == null) _GrantGroup = new DataTable(); return _GrantGroup; } }
        public DataTable AllWard { get { if (_AllWard == null) _AllWard = new DataTable(); return _AllWard; } }
        public DataTable GrantWard { get { if (_GrantWard == null) _GrantWard = new DataTable(); return _GrantWard; } }

    }
}