using System;
using System.Data;
using System.Data.OracleClient;
using DB = SHND.DAL.Utilities.OracleDB;
using SHND.Data.Common.Utilities;

namespace SHND.DAL.Tables
{
    /// <summary>
    /// Represents a transaction for DISEASECATEGORY table.
    /// [Created by 127.0.0.1 on December,29 2008]
    /// </summary>
    public class DiseaseCategoryDAL
    {

        public DiseaseCategoryDAL()
        {
        }

        #region Constant

        /// <summary>DISEASECATEGORY</summary>
        private const string tableName = "DISEASECATEGORY";

        #endregion

        #region Private Variables

        int _deletedRow = 0;
        string _error = "";
        string _information = "";
        bool _OnDB = false;
        string _ABBNAME = "";
        string _ACTIVE = "";
        string _CREATEBY = "";
        DateTime _CREATEON = new DateTime(1, 1, 1);
        string _DESCRIPTION = "";
        string _IMGSYMBOL = "";
        string _ISABSTAIN = "";
        string _ISCALCULATE = "";
        string _ISHIGH = "";
        string _ISINCREASE = "";
        string _ISLIGHT = "";
        string _ISLIMIT = "";
        string _ISLIQUID = "";
        string _ISLOW = "";
        string _ISNEED = "";
        string _ISNON = "";
        string _ISREGULAR = "";
        string _ISREQUEST = "";
        string _ISSOFT = "";
        string _ISMILK = "";
        string _ISSPECIAL = "";
        double _LOID = 0;
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
        public string ABBNAME
        {
            get { return _ABBNAME; }
            set { _ABBNAME = value; }
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
        public string DESCRIPTION
        {
            get { return _DESCRIPTION; }
            set { _DESCRIPTION = value; }
        }
        public string IMGSYMBOL
        {
            get { return _IMGSYMBOL; }
            set { _IMGSYMBOL = value; }
        }
        public string ISABSTAIN
        {
            get { return _ISABSTAIN; }
            set { _ISABSTAIN = value; }
        }
        public string ISCALCULATE
        {
            get { return _ISCALCULATE; }
            set { _ISCALCULATE = value; }
        }
        public string ISHIGH
        {
            get { return _ISHIGH; }
            set { _ISHIGH = value; }
        }
        public string ISINCREASE
        {
            get { return _ISINCREASE; }
            set { _ISINCREASE = value; }
        }
        public string ISLIGHT
        {
            get { return _ISLIGHT; }
            set { _ISLIGHT = value; }
        }
        public string ISLIMIT
        {
            get { return _ISLIMIT; }
            set { _ISLIMIT = value; }
        }
        public string ISLIQUID
        {
            get { return _ISLIQUID; }
            set { _ISLIQUID = value; }
        }
        public string ISLOW
        {
            get { return _ISLOW; }
            set { _ISLOW = value; }
        }
        public string ISNEED
        {
            get { return _ISNEED; }
            set { _ISNEED = value; }
        }
        public string ISNON
        {
            get { return _ISNON; }
            set { _ISNON = value; }
        }
        public string ISREGULAR
        {
            get { return _ISREGULAR; }
            set { _ISREGULAR = value; }
        }
        public string ISREQUEST
        {
            get { return _ISREQUEST; }
            set { _ISREQUEST = value; }
        }
        public string ISSOFT
        {
            get { return _ISSOFT; }
            set { _ISSOFT = value; }
        }
        public string ISMILK
        {
            get { return _ISMILK; }
            set { _ISMILK = value; }
        }
        public string ISSPECIAL
        {
            get { return _ISSPECIAL; }
            set { _ISSPECIAL = value; }
        }
        public double LOID
        {
            get { return _LOID; }
            set { _LOID = value; }
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
            _ABBNAME = "";
            _ACTIVE = "";
            _CREATEBY = "";
            _CREATEON = new DateTime(1, 1, 1);
            _DESCRIPTION = "";
            _IMGSYMBOL = "";
            _ISABSTAIN = "";
            _ISCALCULATE = "";
            _ISHIGH = "";
            _ISINCREASE = "";
            _ISLIGHT = "";
            _ISLIMIT = "";
            _ISLIQUID = "";
            _ISLOW = "";
            _ISNEED = "";
            _ISNON = "";
            _ISREGULAR = "";
            _ISREQUEST = "";
            _ISSOFT = "";
            _ISMILK = "";
            _ISSPECIAL = "";
            _LOID = 0;
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
        /// Returns an indication whether the current data is inserted into DISEASECATEGORY table successfully.
        /// </summary>
        /// <param name="userID">The current user.</param>
        /// <param name="trans">The System.Data.OracleClient.OracleTransaction used by this System.Data.OracleClient.OracleCommand.</param>
        /// <returns>true if insert data successfully; otherwise, false.</returns>
        public bool InsertCurrentData(string userID, OracleTransaction trans)
        {
           // _LOID = DB.GetNextID(TableName, trans);
            _CREATEBY = userID;
            _CREATEON = DateTime.Now;
            return doInsert(trans);
        }

        /// <summary>
        /// Returns an indication whether the current data is updated to DISEASECATEGORY table successfully.
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
        /// Returns an indication whether the current data is deleted from DISEASECATEGORY table successfully.
        /// </summary>
        /// <param name="trans">The System.Data.OracleClient.OracleTransaction used by this System.Data.OracleClient.OracleCommand.</param>
        /// <returns>true if delete data successfully; otherwise, false.</returns>
        public bool DeleteCurrentData(OracleTransaction trans)
        {
            return doDelete("LOID = " + DB.SetDouble(_LOID) + " ", trans);
        }

        /// <summary>
        /// Returns an indication whether the record of DISEASECATEGORY by specified LOID key is retrieved successfully.
        /// </summary>
        /// <param name="cLOID">The LOID key.</param>
        /// <param name="trans">The System.Data.OracleClient.OracleTransaction used by this System.Data.OracleClient.OracleCommand.</param>
        /// <returns>true if data is retrieved successfully; otherwise, false.</returns>
        public bool GetDataByLOID(double cLOID, OracleTransaction trans)
        {
            return doGetdata("LOID = " + DB.SetDouble(cLOID) + " ", trans);
        }

        public DataTable GetDataListByCondition(string cName, string cDescription, string orderBy, OracleTransaction trans)
        {
            //build where clause
            string whStr = "";
            if (cName.ToString() != "") whStr += (whStr.Trim() == "" ? "" : " AND ") + " UPPER(ABBNAME) LIKE " + DB.SetString("%" + cName.ToUpper() + "%") + " ";
            if (cDescription.ToString() != "") whStr += (whStr.Trim() == "" ? "" : " AND ") + " UPPER(DESCRIPTION) LIKE " + DB.SetString("%" + cDescription.ToUpper() + "%") + " ";

            return GetDataList(whStr, orderBy, trans);
        }

        /// <summary>
        /// Returns an indication whether the record of DISEASECATEGORY by specified ABBNAME key is retrieved successfully.
        /// </summary>
        /// <param name="cABBNAME">The ABBNAME key.</param>
        /// <param name="trans">The System.Data.OracleClient.OracleTransaction used by this System.Data.OracleClient.OracleCommand.</param>
        /// <returns>true if data is retrieved successfully; otherwise, false.</returns>
        public bool GetDataByABBNAME(string cABBNAME, OracleTransaction trans)
        {
            return doGetdata("ABBNAME = " + DB.SetString(cABBNAME) + " ", trans);
        }

        public bool DeleteDataByLOID(double cLOID, OracleTransaction trans)
        {
            return doDelete(" LOID = " + DB.SetDouble(cLOID) + " ", trans);
        }
        #endregion

        #region SQL Statements

        /// <summary>
        /// Gets the insert statement for DISEASECATEGORY table.
        /// </summary>
        private string sql_insert
        {
            get
            {
                string sql = "INSERT INTO " + tableName + "(ABBNAME, ACTIVE, CREATEBY, CREATEON, DESCRIPTION, IMGSYMBOL, ISABSTAIN, ISCALCULATE, ISHIGH, ISINCREASE, ISLIGHT, ISLIMIT, ISLIQUID, ISLOW, ISNEED, ISNON, ISREGULAR, ISREQUEST, ISSOFT, ISSPECIAL, ISMILK, UNIT) "; 
                sql += "VALUES (";
                sql += DB.SetString(_ABBNAME) + ", ";
                sql += DB.SetString(_ACTIVE) + ", ";
                sql += DB.SetString(_CREATEBY) + ", ";
                sql += DB.SetDateTime(_CREATEON) + ", ";
                sql += DB.SetString(_DESCRIPTION) + ", ";
                sql += DB.SetString(_IMGSYMBOL) + ", ";
                sql += DB.SetString(_ISABSTAIN) + ", ";
                sql += DB.SetString(_ISCALCULATE) + ", ";
                sql += DB.SetString(_ISHIGH) + ", ";
                sql += DB.SetString(_ISINCREASE) + ", ";
                sql += DB.SetString(_ISLIGHT) + ", ";
                sql += DB.SetString(_ISLIMIT) + ", ";
                sql += DB.SetString(_ISLIQUID) + ", ";
                sql += DB.SetString(_ISLOW) + ", ";
                sql += DB.SetString(_ISNEED) + ", ";
                sql += DB.SetString(_ISNON) + ", ";
                sql += DB.SetString(_ISREGULAR) + ", ";
                sql += DB.SetString(_ISREQUEST) + ", ";
                sql += DB.SetString(_ISSOFT) + ", ";
                sql += DB.SetString(_ISSPECIAL) + ", ";
                sql += DB.SetString(_ISMILK) + ", ";
                sql += (_UNIT == 0 ? "NULL" : DB.SetDouble(_UNIT)) + " ";
                sql += ")";
                return sql;
            }
        }

        /// <summary>
        /// Gets the update statement for DISEASECATEGORY table.
        /// </summary>
        private string sql_update
        {
            get
            {
                string sql = "UPDATE " + tableName + " SET ";
                sql += "ABBNAME = " + DB.SetString(_ABBNAME) + ", ";
                sql += "ACTIVE = " + DB.SetString(_ACTIVE) + ", ";
                sql += "DESCRIPTION = " + DB.SetString(_DESCRIPTION) + ", ";
                sql += "IMGSYMBOL = " + DB.SetString(_IMGSYMBOL) + ", ";
                sql += "ISABSTAIN = " + DB.SetString(_ISABSTAIN) + ", ";
                sql += "ISCALCULATE = " + DB.SetString(_ISCALCULATE) + ", ";
                sql += "ISHIGH = " + DB.SetString(_ISHIGH) + ", ";
                sql += "ISINCREASE = " + DB.SetString(_ISINCREASE) + ", ";
                sql += "ISLIGHT = " + DB.SetString(_ISLIGHT) + ", ";
                sql += "ISLIMIT = " + DB.SetString(_ISLIMIT) + ", ";
                sql += "ISLIQUID = " + DB.SetString(_ISLIQUID) + ", ";
                sql += "ISLOW = " + DB.SetString(_ISLOW) + ", ";
                sql += "ISNEED = " + DB.SetString(_ISNEED) + ", ";
                sql += "ISNON = " + DB.SetString(_ISNON) + ", ";
                sql += "ISREGULAR = " + DB.SetString(_ISREGULAR) + ", ";
                sql += "ISREQUEST = " + DB.SetString(_ISREQUEST) + ", ";
                sql += "ISSOFT = " + DB.SetString(_ISSOFT) + ", ";
                sql += "ISSPECIAL = " + DB.SetString(_ISSPECIAL) + ", ";
                sql += "ISMILK = " + DB.SetString(_ISMILK) + ", ";
                sql += "UNIT = " + (_UNIT == 0 ? "NULL" : DB.SetDouble(_UNIT)) + ", ";
                sql += "UPDATEBY = " + DB.SetString(_UPDATEBY) + ", ";
                sql += "UPDATEON = " + DB.SetDateTime(_UPDATEON) + " ";
                return sql;
            }
        }

        /// <summary>
        /// Gets the delete statement for DISEASECATEGORY table.
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
        /// Gets the select statement for DISEASECATEGORY table.
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
        /// Returns an indication whether the current data is inserted into DISEASECATEGORY table successfully.
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
        /// Returns an indication whether the current data is updated to DISEASECATEGORY table successfully.
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
        /// Returns an indication whether the current data is deleted from DISEASECATEGORY table successfully.
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
        /// Returns an indication whether the record of DISEASECATEGORY by specified condition is retrieved successfully.
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
                        if (!Convert.IsDBNull(zRdr["ABBNAME"])) _ABBNAME = zRdr["ABBNAME"].ToString();
                        if (!Convert.IsDBNull(zRdr["ACTIVE"])) _ACTIVE = zRdr["ACTIVE"].ToString();
                        if (!Convert.IsDBNull(zRdr["CREATEBY"])) _CREATEBY = zRdr["CREATEBY"].ToString();
                        if (!Convert.IsDBNull(zRdr["CREATEON"])) _CREATEON = Convert.ToDateTime(zRdr["CREATEON"]);
                        if (!Convert.IsDBNull(zRdr["DESCRIPTION"])) _DESCRIPTION = zRdr["DESCRIPTION"].ToString();
                        if (!Convert.IsDBNull(zRdr["IMGSYMBOL"])) _IMGSYMBOL = zRdr["IMGSYMBOL"].ToString();
                        if (!Convert.IsDBNull(zRdr["ISABSTAIN"])) _ISABSTAIN = zRdr["ISABSTAIN"].ToString();
                        if (!Convert.IsDBNull(zRdr["ISCALCULATE"])) _ISCALCULATE = zRdr["ISCALCULATE"].ToString();
                        if (!Convert.IsDBNull(zRdr["ISHIGH"])) _ISHIGH = zRdr["ISHIGH"].ToString();
                        if (!Convert.IsDBNull(zRdr["ISINCREASE"])) _ISINCREASE = zRdr["ISINCREASE"].ToString();
                        if (!Convert.IsDBNull(zRdr["ISLIGHT"])) _ISLIGHT = zRdr["ISLIGHT"].ToString();
                        if (!Convert.IsDBNull(zRdr["ISLIMIT"])) _ISLIMIT = zRdr["ISLIMIT"].ToString();
                        if (!Convert.IsDBNull(zRdr["ISLIQUID"])) _ISLIQUID = zRdr["ISLIQUID"].ToString();
                        if (!Convert.IsDBNull(zRdr["ISLOW"])) _ISLOW = zRdr["ISLOW"].ToString();
                        if (!Convert.IsDBNull(zRdr["ISNEED"])) _ISNEED = zRdr["ISNEED"].ToString();
                        if (!Convert.IsDBNull(zRdr["ISNON"])) _ISNON = zRdr["ISNON"].ToString();
                        if (!Convert.IsDBNull(zRdr["ISREGULAR"])) _ISREGULAR = zRdr["ISREGULAR"].ToString();
                        if (!Convert.IsDBNull(zRdr["ISREQUEST"])) _ISREQUEST = zRdr["ISREQUEST"].ToString();
                        if (!Convert.IsDBNull(zRdr["ISSOFT"])) _ISSOFT = zRdr["ISSOFT"].ToString();
                        if (!Convert.IsDBNull(zRdr["ISMILK"])) _ISMILK = zRdr["ISMILK"].ToString();
                        if (!Convert.IsDBNull(zRdr["ISSPECIAL"])) _ISSPECIAL = zRdr["ISSPECIAL"].ToString();
                        if (!Convert.IsDBNull(zRdr["LOID"])) _LOID = Convert.ToDouble(zRdr["LOID"]);
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

    }
}