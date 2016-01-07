using System;
using System.Data;
using System.Data.OracleClient;
using DB = SHND.DAL.Utilities.OracleDB;
using SHND.Data.Common.Utilities;

namespace SHND.DAL.Tables
{
    /// <summary>
    /// Represents a transaction for SUPPLIER table.
    /// [Created by 127.0.0.1 on January,5 2009]
    /// </summary>
    public class SupplierDAL
    {

        public SupplierDAL()
        {
        }

        #region Constant

        /// <summary>SUPPLIER</summary>
        private const string tableName = "SUPPLIER";

        #endregion

        #region Private Variables

        int _deletedRow = 0;
        string _error = "";
        string _information = "";
        bool _OnDB = false;
        string _ACTIVE = "";
        string _ADDRESS = "";
        double _AMPHUR = 0;
        string _CODE = "";
        string _CONTACTNAME = "";
        string _CREATEBY = "";
        DateTime _CREATEON = new DateTime(1, 1, 1);
        string _EMAIL = "";
        string _FAX = "";
        double _LOID = 0;
        string _MOBILE = "";
        string _NAME = "";
        double _PROVINCE = 0;
        string _REMARKS = "";
        string _ROAD = "";
        double _TAMBOL = 0;
        string _TEL = "";
        string _UPDATEBY = "";
        DateTime _UPDATEON = new DateTime(1, 1, 1);
        string _ZIPCODE = "";

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
        public string ADDRESS
        {
            get { return _ADDRESS; }
            set { _ADDRESS = value; }
        }
        public double AMPHUR
        {
            get { return _AMPHUR; }
            set { _AMPHUR = value; }
        }
        public string CODE
        {
            get { return _CODE; }
            set { _CODE = value; }
        }
        public string CONTACTNAME
        {
            get { return _CONTACTNAME; }
            set { _CONTACTNAME = value; }
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
        public string EMAIL
        {
            get { return _EMAIL; }
            set { _EMAIL = value; }
        }
        public string FAX
        {
            get { return _FAX; }
            set { _FAX = value; }
        }
        public double LOID
        {
            get { return _LOID; }
            set { _LOID = value; }
        }
        public string MOBILE
        {
            get { return _MOBILE; }
            set { _MOBILE = value; }
        }
        public string NAME
        {
            get { return _NAME; }
            set { _NAME = value; }
        }
        public double PROVINCE
        {
            get { return _PROVINCE; }
            set { _PROVINCE = value; }
        }
        public string REMARKS
        {
            get { return _REMARKS; }
            set { _REMARKS = value; }
        }
        public string ROAD
        {
            get { return _ROAD; }
            set { _ROAD = value; }
        }
        public double TAMBOL
        {
            get { return _TAMBOL; }
            set { _TAMBOL = value; }
        }
        public string TEL
        {
            get { return _TEL; }
            set { _TEL = value; }
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
        public string ZIPCODE
        {
            get { return _ZIPCODE; }
            set { _ZIPCODE = value; }
        }

        #endregion

        #region Clear Data

        /// <summary>
        /// Initialize data.
        /// </summary>
        private void ClearData()
        {
            _ACTIVE = "";
            _ADDRESS = "";
            _AMPHUR = 0;
            _CODE = "";
            _CONTACTNAME = "";
            _CREATEBY = "";
            _CREATEON = new DateTime(1, 1, 1);
            _EMAIL = "";
            _FAX = "";
            _LOID = 0;
            _MOBILE = "";
            _NAME = "";
            _PROVINCE = 0;
            _REMARKS = "";
            _ROAD = "";
            _TAMBOL = 0;
            _TEL = "";
            _UPDATEBY = "";
            _UPDATEON = new DateTime(1, 1, 1);
            _ZIPCODE = "";
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
        /// Returns an indication whether the current data is inserted into SUPPLIER table successfully.
        /// </summary>
        /// <param name="userID">The current user.</param>
        /// <param name="trans">The System.Data.OracleClient.OracleTransaction used by this System.Data.OracleClient.OracleCommand.</param>
        /// <returns>true if insert data successfully; otherwise, false.</returns>
        public bool InsertCurrentData(string userID, OracleTransaction trans)
        {
            //_LOID = DB.GetNextID(TableName, trans);
            _CODE = DB.GetRunningCode(TableName, "CODE", trans);
            _CREATEBY = userID;
            _CREATEON = DateTime.Now;
            return doInsert(trans);
        }

        /// <summary>
        /// Returns an indication whether the current data is updated to SUPPLIER table successfully.
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
        /// Returns an indication whether the current data is deleted from SUPPLIER table successfully.
        /// </summary>
        /// <param name="trans">The System.Data.OracleClient.OracleTransaction used by this System.Data.OracleClient.OracleCommand.</param>
        /// <returns>true if delete data successfully; otherwise, false.</returns>
        public bool DeleteCurrentData(OracleTransaction trans)
        {
            return doDelete("LOID = " + DB.SetDouble(_LOID) + " ", trans);
        }

        /// <summary>
        /// Returns an indication whether the record of SUPPLIER by specified LOID key is retrieved successfully.
        /// </summary>
        /// <param name="cLOID">The LOID key.</param>
        /// <param name="trans">The System.Data.OracleClient.OracleTransaction used by this System.Data.OracleClient.OracleCommand.</param>
        /// <returns>true if data is retrieved successfully; otherwise, false.</returns>
        public bool GetDataByLOID(double cLOID, OracleTransaction trans)
        {
            return doGetdata("LOID = " + DB.SetDouble(cLOID) + " ", trans);
        }

        /// <summary>
        /// Returns an indication whether the record of SUPPLIER by specified CODE key is retrieved successfully.
        /// </summary>
        /// <param name="cCODE">The CODE key.</param>
        /// <param name="trans">The System.Data.OracleClient.OracleTransaction used by this System.Data.OracleClient.OracleCommand.</param>
        /// <returns>true if data is retrieved successfully; otherwise, false.</returns>
        public bool GetDataByCODE(string cCODE, OracleTransaction trans)
        {
            return doGetdata("CODE = " + DB.SetString(cCODE) + " ", trans);
        }

        /// <summary>
        /// Returns an indication whether the record of SUPPLIER by specified NAME key is retrieved successfully.
        /// </summary>
        /// <param name="cNAME">The NAME key.</param>
        /// <param name="trans">The System.Data.OracleClient.OracleTransaction used by this System.Data.OracleClient.OracleCommand.</param>
        /// <returns>true if data is retrieved successfully; otherwise, false.</returns>
        public bool GetDataByNAME(string cNAME, OracleTransaction trans)
        {
            return doGetdata("NAME = " + DB.SetString(cNAME) + " ", trans);
        }


        public bool DeleteDataByLOID(double cLOID, OracleTransaction trans)
        {
            return doDelete(" LOID = " + DB.SetDouble(cLOID) + " ", trans);
        }

                
        #endregion



        #region SQL Statements

        /// <summary>
        /// Gets the insert statement for SUPPLIER table.
        /// </summary>
        private string sql_insert
        {
            get
            {
                string sql = "INSERT INTO " + tableName + "(ACTIVE, ADDRESS, AMPHUR, CODE, CONTACTNAME, CREATEBY, CREATEON, EMAIL, FAX, MOBILE, NAME, PROVINCE, REMARKS, ROAD, TAMBOL, TEL, ZIPCODE) ";
                sql += "VALUES (";
                sql += DB.SetString(_ACTIVE) + ", ";
                sql += DB.SetString(_ADDRESS) + ", ";
                sql += DB.SetDouble(_AMPHUR) + ", ";
                sql += DB.SetString(_CODE) + ", ";
                sql += DB.SetString(_CONTACTNAME) + ", ";
                sql += DB.SetString(_CREATEBY) + ", ";
                sql += DB.SetDateTime(_CREATEON) + ", ";
                sql += DB.SetString(_EMAIL) + ", ";
                sql += DB.SetString(_FAX) + ", ";
                //sql += DB.SetDouble(_LOID) + ", ";
                sql += DB.SetString(_MOBILE) + ", ";
                sql += DB.SetString(_NAME) + ", ";
                sql += DB.SetDouble(_PROVINCE) + ", ";
                sql += DB.SetString(_REMARKS) + ", ";
                sql += DB.SetString(_ROAD) + ", ";
                sql += DB.SetDouble(_TAMBOL) + ", ";
                sql += DB.SetString(_TEL) + ", ";
                sql += DB.SetString(_ZIPCODE) + " ";
                sql += ")";
                return sql;
            }
        }

        /// <summary>
        /// Gets the update statement for SUPPLIER table.
        /// </summary>
        private string sql_update
        {
            get
            {
                string sql = "UPDATE " + tableName + " SET ";
                sql += "ACTIVE = " + DB.SetString(_ACTIVE) + ", ";
                sql += "ADDRESS = " + DB.SetString(_ADDRESS) + ", ";
                sql += "AMPHUR = " + DB.SetDouble(_AMPHUR) + ", ";
                sql += "CODE = " + DB.SetString(_CODE) + ", ";
                sql += "CONTACTNAME = " + DB.SetString(_CONTACTNAME) + ", ";
                sql += "EMAIL = " + DB.SetString(_EMAIL) + ", ";
                sql += "FAX = " + DB.SetString(_FAX) + ", ";
                sql += "MOBILE = " + DB.SetString(_MOBILE) + ", ";
                sql += "NAME = " + DB.SetString(_NAME) + ", ";
                sql += "PROVINCE = " + DB.SetDouble(_PROVINCE) + ", ";
                sql += "REMARKS = " + DB.SetString(_REMARKS) + ", ";
                sql += "ROAD = " + DB.SetString(_ROAD) + ", ";
                sql += "TAMBOL = " + DB.SetDouble(_TAMBOL) + ", ";
                sql += "TEL = " + DB.SetString(_TEL) + ", ";
                sql += "UPDATEBY = " + DB.SetString(_UPDATEBY) + ", ";
                sql += "UPDATEON = " + DB.SetDateTime(_UPDATEON) + ", ";
                sql += "ZIPCODE = " + DB.SetString(_ZIPCODE) + " ";
                return sql;
            }
        }

        /// <summary>
        /// Gets the delete statement for SUPPLIER table.
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
        /// Gets the select statement for SUPPLIER table.
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
        /// Returns an indication whether the current data is inserted into SUPPLIER table successfully.
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
        /// Returns an indication whether the current data is updated to SUPPLIER table successfully.
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
        /// Returns an indication whether the current data is deleted from SUPPLIER table successfully.
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
        /// Returns an indication whether the record of SUPPLIER by specified condition is retrieved successfully.
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
                        if (!Convert.IsDBNull(zRdr["ADDRESS"])) _ADDRESS = zRdr["ADDRESS"].ToString();
                        if (!Convert.IsDBNull(zRdr["AMPHUR"])) _AMPHUR = Convert.ToDouble(zRdr["AMPHUR"]);
                        if (!Convert.IsDBNull(zRdr["CODE"])) _CODE = zRdr["CODE"].ToString();
                        if (!Convert.IsDBNull(zRdr["CONTACTNAME"])) _CONTACTNAME = zRdr["CONTACTNAME"].ToString();
                        if (!Convert.IsDBNull(zRdr["CREATEBY"])) _CREATEBY = zRdr["CREATEBY"].ToString();
                        if (!Convert.IsDBNull(zRdr["CREATEON"])) _CREATEON = Convert.ToDateTime(zRdr["CREATEON"]);
                        if (!Convert.IsDBNull(zRdr["EMAIL"])) _EMAIL = zRdr["EMAIL"].ToString();
                        if (!Convert.IsDBNull(zRdr["FAX"])) _FAX = zRdr["FAX"].ToString();
                        if (!Convert.IsDBNull(zRdr["LOID"])) _LOID = Convert.ToDouble(zRdr["LOID"]);
                        if (!Convert.IsDBNull(zRdr["MOBILE"])) _MOBILE = zRdr["MOBILE"].ToString();
                        if (!Convert.IsDBNull(zRdr["NAME"])) _NAME = zRdr["NAME"].ToString();
                        if (!Convert.IsDBNull(zRdr["PROVINCE"])) _PROVINCE = Convert.ToDouble(zRdr["PROVINCE"]);
                        if (!Convert.IsDBNull(zRdr["REMARKS"])) _REMARKS = zRdr["REMARKS"].ToString();
                        if (!Convert.IsDBNull(zRdr["ROAD"])) _ROAD = zRdr["ROAD"].ToString();
                        if (!Convert.IsDBNull(zRdr["TAMBOL"])) _TAMBOL = Convert.ToDouble(zRdr["TAMBOL"]);
                        if (!Convert.IsDBNull(zRdr["TEL"])) _TEL = zRdr["TEL"].ToString();
                        if (!Convert.IsDBNull(zRdr["UPDATEBY"])) _UPDATEBY = zRdr["UPDATEBY"].ToString();
                        if (!Convert.IsDBNull(zRdr["UPDATEON"])) _UPDATEON = Convert.ToDateTime(zRdr["UPDATEON"]);
                        if (!Convert.IsDBNull(zRdr["ZIPCODE"])) _ZIPCODE = zRdr["ZIPCODE"].ToString();
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