using System;
using System.Data;
using System.Data.OracleClient;
using DB = SHND.DAL.Utilities.OracleDB;
using SHND.Data.Common.Utilities;

namespace SHND.DAL.Tables
{
    /// <summary>
    /// Represents a transaction for ADMITPATIENT table.
    /// [Created by 127.0.0.1 on August,17 2009]
    /// </summary>
    public class AdmitPatientDAL
    {

        public AdmitPatientDAL()
        {
        }

        #region Constant

        /// <summary>ADMITPATIENT</summary>
        private const string tableName = "ADMITPATIENT";

        #endregion

        #region Private Variables

        int _deletedRow = 0;
        string _error = "";
        string _information = "";
        bool _OnDB = false;
        DateTime _ADMITDATE = new DateTime(1, 1, 1);
        double _AGE = 0;
        string _AN = "";
        string _BEDNO = "";
        DateTime _BIRTHDATE = new DateTime(1, 1, 1);
        string _CREATEBY = "";
        DateTime _CREATEON = new DateTime(1, 1, 1);
        string _DIAGNOSIS = "";
        string _DISEASE = "";
        string _DRUGALLERGIC = "";
        string _FOODALLERGIC = "";
        double _HEIGHT = 0;
        string _HN = "";
        string _ISCOMPLETE = "";
        double _LOID = 0;
        string _PATIENTNAME = "";
        string _ROOMNO = "";
        string _SEX = "";
        string _STATUS = "";
        double _TITLE = 0;
        string _UPDATEBY = "";
        DateTime _UPDATEON = new DateTime(1, 1, 1);
        string _VN = "";
        double _WARD = 0;
        double _WEIGHT = 0;

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
        public DateTime ADMITDATE
        {
            get { return _ADMITDATE; }
            set { _ADMITDATE = value; }
        }
        public double AGE
        {
            get { return _AGE; }
            set { _AGE = value; }
        }
        public string AN
        {
            get { return _AN; }
            set { _AN = value; }
        }
        public string BEDNO
        {
            get { return _BEDNO; }
            set { _BEDNO = value; }
        }
        public DateTime BIRTHDATE
        {
            get { return _BIRTHDATE; }
            set { _BIRTHDATE = value; }
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
        public string DIAGNOSIS
        {
            get { return _DIAGNOSIS; }
            set { _DIAGNOSIS = value; }
        }
        public string DISEASE
        {
            get { return _DISEASE; }
            set { _DISEASE = value; }
        }
        public string DRUGALLERGIC
        {
            get { return _DRUGALLERGIC; }
            set { _DRUGALLERGIC = value; }
        }
        public string FOODALLERGIC
        {
            get { return _FOODALLERGIC; }
            set { _FOODALLERGIC = value; }
        }
        public double HEIGHT
        {
            get { return _HEIGHT; }
            set { _HEIGHT = value; }
        }
        public string HN
        {
            get { return _HN; }
            set { _HN = value; }
        }
        public string ISCOMPLETE
        {
            get { return _ISCOMPLETE; }
            set { _ISCOMPLETE = value; }
        }
        public double LOID
        {
            get { return _LOID; }
            set { _LOID = value; }
        }
        public string PATIENTNAME
        {
            get { return _PATIENTNAME; }
            set { _PATIENTNAME = value; }
        }
        public string ROOMNO
        {
            get { return _ROOMNO; }
            set { _ROOMNO = value; }
        }
        public string SEX
        {
            get { return _SEX; }
            set { _SEX = value; }
        }
        public string STATUS
        {
            get { return _STATUS; }
            set { _STATUS = value; }
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
        public string VN
        {
            get { return _VN; }
            set { _VN = value; }
        }
        public double WARD
        {
            get { return _WARD; }
            set { _WARD = value; }
        }
        public double WEIGHT
        {
            get { return _WEIGHT; }
            set { _WEIGHT = value; }
        }

        #endregion

        #region Clear Data

        /// <summary>
        /// Initialize data.
        /// </summary>
        private void ClearData()
        {
            _ADMITDATE = new DateTime(1, 1, 1);
            _AGE = 0;
            _AN = "";
            _BEDNO = "";
            _BIRTHDATE = new DateTime(1, 1, 1);
            _CREATEBY = "";
            _CREATEON = new DateTime(1, 1, 1);
            _DIAGNOSIS = "";
            _DISEASE = "";
            _DRUGALLERGIC = "";
            _FOODALLERGIC = "";
            _HEIGHT = 0;
            _HN = "";
            _ISCOMPLETE = "";
            _LOID = 0;
            _PATIENTNAME = "";
            _ROOMNO = "";
            _SEX = "";
            _STATUS = "";
            _TITLE = 0;
            _UPDATEBY = "";
            _UPDATEON = new DateTime(1, 1, 1);
            _VN = "";
            _WARD = 0;
            _WEIGHT = 0;
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
        /// Returns an indication whether the current data is inserted into ADMITPATIENT table successfully.
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
        /// Returns an indication whether the current data is updated to ADMITPATIENT table successfully.
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
        /// Returns an indication whether the current data is deleted from ADMITPATIENT table successfully.
        /// </summary>
        /// <param name="trans">The System.Data.OracleClient.OracleTransaction used by this System.Data.OracleClient.OracleCommand.</param>
        /// <returns>true if delete data successfully; otherwise, false.</returns>
        public bool DeleteCurrentData(OracleTransaction trans)
        {
            return doDelete("LOID = " + DB.SetDouble(_LOID) + " ", trans);
        }

        /// <summary>
        /// Returns an indication whether the record of ADMITPATIENT by specified LOID key is retrieved successfully.
        /// </summary>
        /// <param name="cLOID">The LOID key.</param>
        /// <param name="trans">The System.Data.OracleClient.OracleTransaction used by this System.Data.OracleClient.OracleCommand.</param>
        /// <returns>true if data is retrieved successfully; otherwise, false.</returns>
        public bool GetDataByLOID(double cLOID, OracleTransaction trans)
        {
            return doGetdata("LOID = " + DB.SetDouble(cLOID) + " ", trans);
        }

        public DataTable GetDataListByConditions(DateTime cDATE, double cWARD, string cWARDNAME, DateTime cADMITDATEFROM, DateTime cADMITDATETO, string cHN, string cAN,
    string cPATIENTNAME, string cSTATUSRANKFROM, string cSTATUSRANKTO, string otherConditions, double officerID, string OfficerGroup, string orderBy, OracleTransaction trans)
        {
            string whText = "";
            if (OfficerGroup != "A") whText += (whText == "" ? "" : "AND ") + " WARD IN (SELECT WARD FROM WARDRESPONSE WHERE OFFICER=" + DB.SetDouble(officerID) + ") ";
            if (cWARD != 0) whText += (whText == "" ? "" : "AND ") + "WARD = " + DB.SetDouble(cWARD) + " ";
            if (cWARDNAME.Trim() != "") whText += (whText == "" ? "" : "AND ") + "WARDNAME LIKE " + DB.SetString(cWARDNAME.Trim() + "%") + " ";
            if (cADMITDATEFROM.Year != 1) whText += (whText == "" ? "" : "AND ") + "TO_DATE(ADMITDATE) >= " + DB.SetDate(cADMITDATEFROM) + " ";
            if (cADMITDATETO.Year != 1) whText += (whText == "" ? "" : "AND ") + "TO_DATE(ADMITDATE) <= " + DB.SetDate(cADMITDATETO) + " ";
            if (cHN.Trim() != "") whText += (whText == "" ? "" : "AND ") + "HN LIKE " + DB.SetString("%" + cHN.Trim() + "%") + " ";
            if (cAN.Trim() != "") whText += (whText == "" ? "" : "AND ") + "AN LIKE " + DB.SetString("%" + cAN.Trim() + "%") + " ";
            if (cPATIENTNAME.Trim() != "") whText += (whText == "" ? "" : "AND ") + "PATIENTNAME LIKE " + DB.SetString("%" + cPATIENTNAME.Trim() + "%") + " ";
          //  if (cSTATUSRANKFROM.Trim() != "") whText += (whText == "" ? "" : "AND ") + "STATUSRANK >= " + DB.SetString(cSTATUSRANKFROM.Trim()) + " ";
          //  if (cSTATUSRANKTO.Trim() != "") whText += (whText == "" ? "" : "AND ") + "STATUSRANK <= " + DB.SetString(cSTATUSRANKTO.Trim()) + " ";
            if (otherConditions.Trim() != "") whText += (whText == "" ? "" : "AND ") + otherConditions.Trim() + " ";

            return GetDataList(whText, orderBy, trans);
        }

        public DataTable GetDataList(DateTime date, string whereClause, string orderBy, OracleTransaction trans)
        {
            return DB.ExecuteTable(sql_select + (whereClause == "" ? "" : "WHERE " + whereClause + " ") + (orderBy == "" ? "" : "ORDER BY " + DB.SetSortString(orderBy)), trans);
        }

        #endregion

        #region SQL Statements

        /// <summary>
        /// Gets the insert statement for ADMITPATIENT table.
        /// </summary>
        private string sql_insert
        {
            get
            {
                string sql = "INSERT INTO " + tableName + "(ADMITDATE, AGE, AN, BEDNO, BIRTHDATE, CREATEBY, CREATEON, DIAGNOSIS, DISEASE, DRUGALLERGIC, FOODALLERGIC, HEIGHT, HN, ISCOMPLETE, LOID, PATIENTNAME, ROOMNO, SEX, STATUS, TITLE, VN, WARD, WEIGHT) ";
                sql += "VALUES (";
                sql += DB.SetDateTime(_ADMITDATE) + ", ";
                sql += DB.SetDouble(_AGE) + ", ";
                sql += DB.SetString(_AN) + ", ";
                sql += DB.SetString(_BEDNO) + ", ";
                sql += DB.SetDateTime(_BIRTHDATE) + ", ";
                sql += DB.SetString(_CREATEBY) + ", ";
                sql += DB.SetDateTime(_CREATEON) + ", ";
                sql += DB.SetString(_DIAGNOSIS) + ", ";
                sql += DB.SetString(_DISEASE) + ", ";
                sql += DB.SetString(_DRUGALLERGIC) + ", ";
                sql += DB.SetString(_FOODALLERGIC) + ", ";
                sql += DB.SetDouble(_HEIGHT) + ", ";
                sql += DB.SetString(_HN) + ", ";
                sql += DB.SetString(_ISCOMPLETE) + ", ";
                sql += DB.SetDouble(_LOID) + ", ";
                sql += DB.SetString(_PATIENTNAME) + ", ";
                sql += DB.SetString(_ROOMNO) + ", ";
                sql += DB.SetString(_SEX) + ", ";
                sql += DB.SetString(_STATUS) + ", ";
                sql += DB.SetDouble(_TITLE) + ", ";
                sql += DB.SetString(_VN) + ", ";
                sql += DB.SetDouble(_WARD) + ", ";
                sql += DB.SetDouble(_WEIGHT) + " ";
                sql += ")";
                return sql;
            }
        }

        /// <summary>
        /// Gets the update statement for ADMITPATIENT table.
        /// </summary>
        private string sql_update
        {
            get
            {
                string sql = "UPDATE " + tableName + " SET ";
                sql += "ADMITDATE = " + DB.SetDateTime(_ADMITDATE) + ", ";
                sql += "AGE = " + DB.SetDouble(_AGE) + ", ";
                sql += "AN = " + DB.SetString(_AN) + ", ";
                sql += "BEDNO = " + DB.SetString(_BEDNO) + ", ";
                sql += "BIRTHDATE = " + DB.SetDateTime(_BIRTHDATE) + ", ";
                sql += "DIAGNOSIS = " + DB.SetString(_DIAGNOSIS) + ", ";
                sql += "DISEASE = " + DB.SetString(_DISEASE) + ", ";
                sql += "DRUGALLERGIC = " + DB.SetString(_DRUGALLERGIC) + ", ";
                sql += "FOODALLERGIC = " + DB.SetString(_FOODALLERGIC) + ", ";
                sql += "HEIGHT = " + DB.SetDouble(_HEIGHT) + ", ";
                sql += "HN = " + DB.SetString(_HN) + ", ";
                sql += "ISCOMPLETE = " + DB.SetString(_ISCOMPLETE) + ", ";
                sql += "PATIENTNAME = " + DB.SetString(_PATIENTNAME) + ", ";
                sql += "ROOMNO = " + DB.SetString(_ROOMNO) + ", ";
                sql += "SEX = " + DB.SetString(_SEX) + ", ";
                sql += "STATUS = " + DB.SetString(_STATUS) + ", ";
                sql += "TITLE = " + (_TITLE == 0 ? "NULL" : DB.SetDouble(_TITLE)) + ", ";
                sql += "UPDATEBY = " + DB.SetString(_UPDATEBY) + ", ";
                sql += "UPDATEON = " + DB.SetDateTime(_UPDATEON) + ", ";
                sql += "VN = " + DB.SetString(_VN) + ", ";
                sql += "WARD = " + DB.SetDouble(_WARD) + ", ";
                sql += "WEIGHT = " + DB.SetDouble(_WEIGHT) + " ";
                return sql;
            }
        }

        /// <summary>
        /// Gets the delete statement for ADMITPATIENT table.
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
        /// Gets the select statement for ADMITPATIENT table.
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
        /// Returns an indication whether the current data is inserted into ADMITPATIENT table successfully.
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
        /// Returns an indication whether the current data is updated to ADMITPATIENT table successfully.
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
        /// Returns an indication whether the current data is deleted from ADMITPATIENT table successfully.
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
        /// Returns an indication whether the record of ADMITPATIENT by specified condition is retrieved successfully.
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
                        if (!Convert.IsDBNull(zRdr["ADMITDATE"])) _ADMITDATE = Convert.ToDateTime(zRdr["ADMITDATE"]);
                        if (!Convert.IsDBNull(zRdr["AGE"])) _AGE = Convert.ToDouble(zRdr["AGE"]);
                        if (!Convert.IsDBNull(zRdr["AN"])) _AN = zRdr["AN"].ToString();
                        if (!Convert.IsDBNull(zRdr["BEDNO"])) _BEDNO = zRdr["BEDNO"].ToString();
                        if (!Convert.IsDBNull(zRdr["BIRTHDATE"])) _BIRTHDATE = Convert.ToDateTime(zRdr["BIRTHDATE"]);
                        if (!Convert.IsDBNull(zRdr["CREATEBY"])) _CREATEBY = zRdr["CREATEBY"].ToString();
                        if (!Convert.IsDBNull(zRdr["CREATEON"])) _CREATEON = Convert.ToDateTime(zRdr["CREATEON"]);
                        if (!Convert.IsDBNull(zRdr["DIAGNOSIS"])) _DIAGNOSIS = zRdr["DIAGNOSIS"].ToString();
                        if (!Convert.IsDBNull(zRdr["DISEASE"])) _DISEASE = zRdr["DISEASE"].ToString();
                        if (!Convert.IsDBNull(zRdr["DRUGALLERGIC"])) _DRUGALLERGIC = zRdr["DRUGALLERGIC"].ToString();
                        if (!Convert.IsDBNull(zRdr["FOODALLERGIC"])) _FOODALLERGIC = zRdr["FOODALLERGIC"].ToString();
                        if (!Convert.IsDBNull(zRdr["HEIGHT"])) _HEIGHT = Convert.ToDouble(zRdr["HEIGHT"]);
                        if (!Convert.IsDBNull(zRdr["HN"])) _HN = zRdr["HN"].ToString();
                        if (!Convert.IsDBNull(zRdr["ISCOMPLETE"])) _ISCOMPLETE = zRdr["ISCOMPLETE"].ToString();
                        if (!Convert.IsDBNull(zRdr["LOID"])) _LOID = Convert.ToDouble(zRdr["LOID"]);
                        if (!Convert.IsDBNull(zRdr["PATIENTNAME"])) _PATIENTNAME = zRdr["PATIENTNAME"].ToString();
                        if (!Convert.IsDBNull(zRdr["ROOMNO"])) _ROOMNO = zRdr["ROOMNO"].ToString();
                        if (!Convert.IsDBNull(zRdr["SEX"])) _SEX = zRdr["SEX"].ToString();
                        if (!Convert.IsDBNull(zRdr["STATUS"])) _STATUS = zRdr["STATUS"].ToString();
                        if (!Convert.IsDBNull(zRdr["TITLE"])) _TITLE = Convert.ToDouble(zRdr["TITLE"]);
                        if (!Convert.IsDBNull(zRdr["UPDATEBY"])) _UPDATEBY = zRdr["UPDATEBY"].ToString();
                        if (!Convert.IsDBNull(zRdr["UPDATEON"])) _UPDATEON = Convert.ToDateTime(zRdr["UPDATEON"]);
                        if (!Convert.IsDBNull(zRdr["VN"])) _VN = zRdr["VN"].ToString();
                        if (!Convert.IsDBNull(zRdr["WARD"])) _WARD = Convert.ToDouble(zRdr["WARD"]);
                        if (!Convert.IsDBNull(zRdr["WEIGHT"])) _WEIGHT = Convert.ToDouble(zRdr["WEIGHT"]);
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