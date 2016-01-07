using System;
using System.Data;
using System.Data.OracleClient;
using DB = SHND.DAL.Utilities.OracleDB;
using SHND.Data.Common.Utilities;

namespace SHND.DAL.Tables
{
    /// <summary>
    /// Represents a transaction for ORDERPARTY table.
    /// [Created by 127.0.0.1 on Febuary,4 2009]
    /// </summary>
    public class OrderPartyDAL
    {

        public OrderPartyDAL()
        {
        }

        #region Constant

        /// <summary>ORDERPARTY</summary>
        private const string tableName = "ORDERPARTY";

        #endregion

        #region Private Variables

        int _deletedRow = 0;
        string _error = "";
        string _information = "";
        bool _OnDB = false;
        string _CODE = "";
        string _CREATEBY = "";
        DateTime _CREATEON = new DateTime(1, 1, 1);
        string _DESCRIPTION = "";
        string _DIRECTORAPPROVE = "";
        string _DIRECTORCOMMENT = "";
        double _DIVISION = 0;
        double _LOID = 0;
        string _NDAPPROVE = "";
        string _NDCOMMENT = "";
        string _OLASTNAME = "";
        string _ONAME = "";
        DateTime _ORDERDATE = new DateTime(1, 1, 1);
        string _OTEL = "";
        double _OTITLE = 0;
        DateTime _PARTYDATETIME = new DateTime(1, 1, 1);
        double _PARTYTYPE = 0;
        string _PLACE = "";
        string _REFCODE = "";
        string _STATUS = "";
        string _UPDATEBY = "";
        DateTime _UPDATEON = new DateTime(1, 1, 1);
        double _VISITORQTY = 0;

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
        public string DESCRIPTION
        {
            get { return _DESCRIPTION; }
            set { _DESCRIPTION = value; }
        }
        public string DIRECTORAPPROVE
        {
            get { return _DIRECTORAPPROVE; }
            set { _DIRECTORAPPROVE = value; }
        }
        public string DIRECTORCOMMENT
        {
            get { return _DIRECTORCOMMENT; }
            set { _DIRECTORCOMMENT = value; }
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
        public string NDAPPROVE
        {
            get { return _NDAPPROVE; }
            set { _NDAPPROVE = value; }
        }
        public string NDCOMMENT
        {
            get { return _NDCOMMENT; }
            set { _NDCOMMENT = value; }
        }
        public string OLASTNAME
        {
            get { return _OLASTNAME; }
            set { _OLASTNAME = value; }
        }
        public string ONAME
        {
            get { return _ONAME; }
            set { _ONAME = value; }
        }
        public DateTime ORDERDATE
        {
            get { return _ORDERDATE; }
            set { _ORDERDATE = value; }
        }
        public string OTEL
        {
            get { return _OTEL; }
            set { _OTEL = value; }
        }
        public double OTITLE
        {
            get { return _OTITLE; }
            set { _OTITLE = value; }
        }

        public DateTime PARTYDATETIME
        {
            get { return _PARTYDATETIME; }
            set { _PARTYDATETIME = value; }
        }
        public double PARTYTYPE
        {
            get { return _PARTYTYPE; }
            set { _PARTYTYPE = value; }
        }
        public string PLACE
        {
            get { return _PLACE; }
            set { _PLACE = value; }
        }
        public string REFCODE
        {
            get { return _REFCODE; }
            set { _REFCODE = value; }
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
        public double VISITORQTY
        {
            get { return _VISITORQTY; }
            set { _VISITORQTY = value; }
        }

        #endregion

        #region Clear Data

        /// <summary>
        /// Initialize data.
        /// </summary>
        private void ClearData()
        {
            _CODE = "";
            _CREATEBY = "";
            _CREATEON = new DateTime(1, 1, 1);
            _DESCRIPTION = "";
            _DIRECTORAPPROVE = "";
            _DIRECTORCOMMENT = "";
            _DIVISION = 0;
            _LOID = 0;
            _NDAPPROVE = "";
            _NDCOMMENT = "";
            _OLASTNAME = "";
            _ONAME = "";
            _ORDERDATE = new DateTime(1, 1, 1);
            _OTEL = "";
            _OTITLE = 0;
            _PARTYDATETIME = new DateTime(1, 1, 1);
            _PARTYTYPE = 0;
            _PLACE = "";
            _REFCODE = "";
            _STATUS = "";
            _UPDATEBY = "";
            _UPDATEON = new DateTime(1, 1, 1);
            _VISITORQTY = 0;
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
        /// Returns an indication whether the current data is inserted into ORDERPARTY table successfully.
        /// </summary>
        /// <param name="userID">The current user.</param>
        /// <param name="trans">The System.Data.OracleClient.OracleTransaction used by this System.Data.OracleClient.OracleCommand.</param>
        /// <returns>true if insert data successfully; otherwise, false.</returns>
        public bool InsertCurrentData(string userID, OracleTransaction trans)
        {
            _LOID = DB.GetNextID(TableName, trans);
            _CODE = DB.GetRunningCode("ORDERPARTY", "CODE");
            _CREATEBY = userID;
            _CREATEON = DateTime.Now;
            return doInsert(trans);
        }

        /// <summary>
        /// Returns an indication whether the current data is updated to ORDERPARTY table successfully.
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
        /// Returns an indication whether the current data is deleted from ORDERPARTY table successfully.
        /// </summary>
        /// <param name="trans">The System.Data.OracleClient.OracleTransaction used by this System.Data.OracleClient.OracleCommand.</param>
        /// <returns>true if delete data successfully; otherwise, false.</returns>
        public bool DeleteCurrentData(OracleTransaction trans)
        {
            return doDelete("LOID = " + DB.SetDouble(_LOID) + " ", trans);
        }

        public bool DeleteDataByLOID(double cLOID, OracleTransaction trans)
        {
            return doDelete(" LOID = " + DB.SetDouble(cLOID) + " ", trans);
        }

        /// <summary>
        /// Returns an indication whether the record of ORDERPARTY by specified LOID key is retrieved successfully.
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
        /// Gets the insert statement for ORDERPARTY table.
        /// </summary>
        private string sql_insert
        {
            get
            {
                string sql = "INSERT INTO " + tableName + "(CODE, CREATEBY, CREATEON, DESCRIPTION, DIRECTORAPPROVE, DIRECTORCOMMENT, DIVISION, LOID, NDAPPROVE, NDCOMMENT, OLASTNAME, ONAME, ORDERDATE, OTEL, OTITLE, PARTYDATETIME, PARTYTYPE, PLACE, REFCODE, STATUS, VISITORQTY) ";
                sql += "VALUES (";
                sql += DB.SetString(_CODE) + ", ";
                sql += DB.SetString(_CREATEBY) + ", ";
                sql += DB.SetDateTime(_CREATEON) + ", ";
                sql += DB.SetString(_DESCRIPTION) + ", ";
                sql += DB.SetString(_DIRECTORAPPROVE) + ", ";
                sql += DB.SetString(_DIRECTORCOMMENT) + ", ";
                sql += DB.SetDouble(_DIVISION) + ", ";
                sql += DB.SetDouble(_LOID) + ", ";
                sql += DB.SetString(_NDAPPROVE) + ", ";
                sql += DB.SetString(_NDCOMMENT) + ", ";
                sql += DB.SetString(_OLASTNAME) + ", ";
                sql += DB.SetString(_ONAME) + ", ";
                sql += DB.SetDateTime(_ORDERDATE) + ", ";
                sql += DB.SetString(_OTEL) + ", ";
                sql += DB.SetDouble(_OTITLE) + ", ";
                sql += DB.SetDateTime(_PARTYDATETIME) + ", ";
                sql += DB.SetDouble(_PARTYTYPE) + ", ";
                sql += DB.SetString(_PLACE) + ", ";
                sql += DB.SetString(_REFCODE) + ", ";
                sql += DB.SetString(_STATUS) + ", ";
                sql += DB.SetDouble(_VISITORQTY) + " ";
                sql += ")";
                return sql;
            }
        }

        /// <summary>
        /// Gets the update statement for ORDERPARTY table.
        /// </summary>
        private string sql_update
        {
            get
            {
                string sql = "UPDATE " + tableName + " SET ";
                sql += "CODE = " + DB.SetString(_CODE) + ", ";
                sql += "DESCRIPTION = " + DB.SetString(_DESCRIPTION) + ", ";
                sql += "DIRECTORAPPROVE = " + DB.SetString(_DIRECTORAPPROVE) + ", ";
                sql += "DIRECTORCOMMENT = " + DB.SetString(_DIRECTORCOMMENT) + ", ";
                sql += "DIVISION = " + DB.SetDouble(_DIVISION) + ", ";
                sql += "NDAPPROVE = " + DB.SetString(_NDAPPROVE) + ", ";
                sql += "NDCOMMENT = " + DB.SetString(_NDCOMMENT) + ", ";
                sql += "OLASTNAME = " + DB.SetString(_OLASTNAME) + ", ";
                sql += "ONAME = " + DB.SetString(_ONAME) + ", ";
                sql += "ORDERDATE = " + DB.SetDateTime(_ORDERDATE) + ", ";
                sql += "OTEL = " + DB.SetString(_OTEL) + ", ";
                sql += "OTITLE = " + DB.SetDouble(_OTITLE) + ", ";
                sql += "PARTYDATETIME = " + DB.SetDateTime(_PARTYDATETIME) + ", ";
                sql += "PARTYTYPE = " + DB.SetDouble(_PARTYTYPE) + ", ";
                sql += "PLACE = " + DB.SetString(_PLACE) + ", ";
                sql += "REFCODE = " + DB.SetString(_REFCODE) + ", ";
                sql += "STATUS = " + DB.SetString(_STATUS) + ", ";
                sql += "UPDATEBY = " + DB.SetString(_UPDATEBY) + ", ";
                sql += "UPDATEON = " + DB.SetDateTime(_UPDATEON) + ", ";
                sql += "VISITORQTY = " + DB.SetDouble(_VISITORQTY) + " ";
                return sql;
            }
        }

        /// <summary>
        /// Gets the delete statement for ORDERPARTY table.
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
        /// Gets the select statement for ORDERPARTY table.
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
        /// Returns an indication whether the current data is inserted into ORDERPARTY table successfully.
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
        /// Returns an indication whether the current data is updated to ORDERPARTY table successfully.
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
        /// Returns an indication whether the current data is deleted from ORDERPARTY table successfully.
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
        /// Returns an indication whether the record of ORDERPARTY by specified condition is retrieved successfully.
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
                        if (!Convert.IsDBNull(zRdr["CODE"])) _CODE = zRdr["CODE"].ToString();
                        if (!Convert.IsDBNull(zRdr["CREATEBY"])) _CREATEBY = zRdr["CREATEBY"].ToString();
                        if (!Convert.IsDBNull(zRdr["CREATEON"])) _CREATEON = Convert.ToDateTime(zRdr["CREATEON"]);
                        if (!Convert.IsDBNull(zRdr["DESCRIPTION"])) _DESCRIPTION = zRdr["DESCRIPTION"].ToString();
                        if (!Convert.IsDBNull(zRdr["DIRECTORAPPROVE"])) _DIRECTORAPPROVE = zRdr["DIRECTORAPPROVE"].ToString();
                        if (!Convert.IsDBNull(zRdr["DIRECTORCOMMENT"])) _DIRECTORCOMMENT = zRdr["DIRECTORCOMMENT"].ToString();
                        if (!Convert.IsDBNull(zRdr["DIVISION"])) _DIVISION = Convert.ToDouble(zRdr["DIVISION"]);
                        if (!Convert.IsDBNull(zRdr["LOID"])) _LOID = Convert.ToDouble(zRdr["LOID"]);
                        if (!Convert.IsDBNull(zRdr["NDAPPROVE"])) _NDAPPROVE = zRdr["NDAPPROVE"].ToString();
                        if (!Convert.IsDBNull(zRdr["NDCOMMENT"])) _NDCOMMENT = zRdr["NDCOMMENT"].ToString();
                        if (!Convert.IsDBNull(zRdr["OLASTNAME"])) _OLASTNAME = zRdr["OLASTNAME"].ToString();
                        if (!Convert.IsDBNull(zRdr["ONAME"])) _ONAME = zRdr["ONAME"].ToString();
                        if (!Convert.IsDBNull(zRdr["ORDERDATE"])) _ORDERDATE = Convert.ToDateTime(zRdr["ORDERDATE"]);
                        if (!Convert.IsDBNull(zRdr["OTEL"])) _OTEL = zRdr["OTEL"].ToString();
                        if (!Convert.IsDBNull(zRdr["OTITLE"])) _OTITLE = Convert.ToDouble(zRdr["OTITLE"]);
                        if (!Convert.IsDBNull(zRdr["PARTYDATETIME"])) _PARTYDATETIME = Convert.ToDateTime(zRdr["PARTYDATETIME"]);
                        if (!Convert.IsDBNull(zRdr["PARTYTYPE"])) _PARTYTYPE = Convert.ToDouble(zRdr["PARTYTYPE"]);
                        if (!Convert.IsDBNull(zRdr["PLACE"])) _PLACE = zRdr["PLACE"].ToString();
                        if (!Convert.IsDBNull(zRdr["REFCODE"])) _REFCODE = zRdr["REFCODE"].ToString();
                        if (!Convert.IsDBNull(zRdr["STATUS"])) _STATUS = zRdr["STATUS"].ToString();
                        if (!Convert.IsDBNull(zRdr["UPDATEBY"])) _UPDATEBY = zRdr["UPDATEBY"].ToString();
                        if (!Convert.IsDBNull(zRdr["UPDATEON"])) _UPDATEON = Convert.ToDateTime(zRdr["UPDATEON"]);
                        if (!Convert.IsDBNull(zRdr["VISITORQTY"])) _VISITORQTY = Convert.ToDouble(zRdr["VISITORQTY"]);
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

        #region My Work Nang

        private string sql_statusname
        {
            get
            {
                string sql = "SELECT FN_STATUSNAME(STATUS,'ORDERPARTY') STATUSNAME ";
                sql += " FROM ORDERPARTY ";
                return sql;
            }
        }

        public string GetStatusName(double oploid)
        {
            return DB.ExecuteScalar(sql_statusname+" WHERE LOID =" + oploid).ToString();
        }


        #endregion

    }
}