using System;
using System.Data;
using System.Data.OracleClient;
using DB = SHND.DAL.Utilities.OracleDB;
using SHND.Data;
using SHND.Data.Common.Utilities;

namespace SHND.DAL.Table.Master
{
    /// <summary>
    /// Represents a transaction for CUSTOMER table.
    /// [Created by 127.0.0.1 on September,8 2008]
    /// </summary>
    public class CustomerDAL
    {

        public CustomerDAL()
        {
        }

        #region Constant

        /// <summary>CUSTOMER</summary>
        private const string tableName = "CUSTOMER";

        #endregion

        #region Private Variables

        string _error = "";
        string _information = "";
        bool _OnDB = false;
        string _ACTIVE = "";
        string _BILLADDRESS = "";
        double _BILLAMPHUR = 0;
        string _BILLEMAIL = "";
        string _BILLFAX = "";
        double _BILLPROVINCE = 0;
        string _BILLROAD = "";
        double _BILLTAMBOL = 0;
        string _BILLTEL = "";
        string _BILLZIPCODE = "";
        string _CADDRESS = "";
        double _CAMPHUR = 0;
        string _CEMAIL = "";
        string _CFAX = "";
        string _CLASTNAME = "";
        string _CMOBILE = "";
        string _CNAME = "";
        string _CODE = "";
        double _CPROVINCE = 0;
        string _CREATEBY = "";
        DateTime _CREATEON = new DateTime(1, 1, 1);
        double _CREDITAMOUNT = 0;
        double _CREDITDAY = 0;
        string _CROAD = "";
        double _CTAMBOL = 0;
        string _CTEL = "";
        double _CTITLE = 0;
        string _CUSTOMERTYPE = "";
        string _CZIPCODE = "";
        string _DELIVERTYPE = "";
        DateTime _EFDATE = new DateTime(1, 1, 1);
        DateTime _EPDATE = new DateTime(1, 1, 1);
        string _IDENTITY = "";
        string _LASTNAME = "";
        double _LOID = 0;
        double _MEMBERTYPE = 0;
        string _NAME = "";
        string _PAYMENT = "";
        string _REMARK = "";
        string _SENDADDRESS = "";
        double _SENDAMPHUR = 0;
        string _SENDEMAIL = "";
        string _SENDFAX = "";
        string _SENDPLACE = "";
        double _SENDPROVINCE = 0;
        string _SENDROAD = "";
        double _SENDTAMBOL = 0;
        string _SENDTEL = "";
        string _SENDZIPCODE = "";
        double _TITLE = 0;
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
        public string BILLADDRESS
        {
            get { return _BILLADDRESS; }
            set { _BILLADDRESS = value; }
        }
        public double BILLAMPHUR
        {
            get { return _BILLAMPHUR; }
            set { _BILLAMPHUR = value; }
        }
        public string BILLEMAIL
        {
            get { return _BILLEMAIL; }
            set { _BILLEMAIL = value; }
        }
        public string BILLFAX
        {
            get { return _BILLFAX; }
            set { _BILLFAX = value; }
        }
        public double BILLPROVINCE
        {
            get { return _BILLPROVINCE; }
            set { _BILLPROVINCE = value; }
        }
        public string BILLROAD
        {
            get { return _BILLROAD; }
            set { _BILLROAD = value; }
        }
        public double BILLTAMBOL
        {
            get { return _BILLTAMBOL; }
            set { _BILLTAMBOL = value; }
        }
        public string BILLTEL
        {
            get { return _BILLTEL; }
            set { _BILLTEL = value; }
        }
        public string BILLZIPCODE
        {
            get { return _BILLZIPCODE; }
            set { _BILLZIPCODE = value; }
        }
        public string CADDRESS
        {
            get { return _CADDRESS; }
            set { _CADDRESS = value; }
        }
        public double CAMPHUR
        {
            get { return _CAMPHUR; }
            set { _CAMPHUR = value; }
        }
        public string CEMAIL
        {
            get { return _CEMAIL; }
            set { _CEMAIL = value; }
        }
        public string CFAX
        {
            get { return _CFAX; }
            set { _CFAX = value; }
        }
        public string CLASTNAME
        {
            get { return _CLASTNAME; }
            set { _CLASTNAME = value; }
        }
        public string CMOBILE
        {
            get { return _CMOBILE; }
            set { _CMOBILE = value; }
        }
        public string CNAME
        {
            get { return _CNAME; }
            set { _CNAME = value; }
        }
        public string CODE
        {
            get { return _CODE; }
            set { _CODE = value; }
        }
        public double CPROVINCE
        {
            get { return _CPROVINCE; }
            set { _CPROVINCE = value; }
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
        public double CREDITAMOUNT
        {
            get { return _CREDITAMOUNT; }
            set { _CREDITAMOUNT = value; }
        }
        public double CREDITDAY
        {
            get { return _CREDITDAY; }
            set { _CREDITDAY = value; }
        }
        public string CROAD
        {
            get { return _CROAD; }
            set { _CROAD = value; }
        }
        public double CTAMBOL
        {
            get { return _CTAMBOL; }
            set { _CTAMBOL = value; }
        }
        public string CTEL
        {
            get { return _CTEL; }
            set { _CTEL = value; }
        }
        public double CTITLE
        {
            get { return _CTITLE; }
            set { _CTITLE = value; }
        }
        public string CUSTOMERTYPE
        {
            get { return _CUSTOMERTYPE; }
            set { _CUSTOMERTYPE = value; }
        }
        public string CZIPCODE
        {
            get { return _CZIPCODE; }
            set { _CZIPCODE = value; }
        }
        public string DELIVERTYPE
        {
            get { return _DELIVERTYPE; }
            set { _DELIVERTYPE = value; }
        }
        public DateTime EFDATE
        {
            get { return _EFDATE; }
            set { _EFDATE = value; }
        }
        public DateTime EPDATE
        {
            get { return _EPDATE; }
            set { _EPDATE = value; }
        }
        public string IDENTITY
        {
            get { return _IDENTITY; }
            set { _IDENTITY = value; }
        }
        public string LASTNAME
        {
            get { return _LASTNAME; }
            set { _LASTNAME = value; }
        }
        public double LOID
        {
            get { return _LOID; }
            set { _LOID = value; }
        }
        public double MEMBERTYPE
        {
            get { return _MEMBERTYPE; }
            set { _MEMBERTYPE = value; }
        }
        public string NAME
        {
            get { return _NAME; }
            set { _NAME = value; }
        }
        public string PAYMENT
        {
            get { return _PAYMENT; }
            set { _PAYMENT = value; }
        }
        public string REMARK
        {
            get { return _REMARK; }
            set { _REMARK = value; }
        }
        public string SENDADDRESS
        {
            get { return _SENDADDRESS; }
            set { _SENDADDRESS = value; }
        }
        public double SENDAMPHUR
        {
            get { return _SENDAMPHUR; }
            set { _SENDAMPHUR = value; }
        }
        public string SENDEMAIL
        {
            get { return _SENDEMAIL; }
            set { _SENDEMAIL = value; }
        }
        public string SENDFAX
        {
            get { return _SENDFAX; }
            set { _SENDFAX = value; }
        }
        public string SENDPLACE
        {
            get { return _SENDPLACE; }
            set { _SENDPLACE = value; }
        }
        public double SENDPROVINCE
        {
            get { return _SENDPROVINCE; }
            set { _SENDPROVINCE = value; }
        }
        public string SENDROAD
        {
            get { return _SENDROAD; }
            set { _SENDROAD = value; }
        }
        public double SENDTAMBOL
        {
            get { return _SENDTAMBOL; }
            set { _SENDTAMBOL = value; }
        }
        public string SENDTEL
        {
            get { return _SENDTEL; }
            set { _SENDTEL = value; }
        }
        public string SENDZIPCODE
        {
            get { return _SENDZIPCODE; }
            set { _SENDZIPCODE = value; }
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

        #endregion

        #region Public Methods

        /// <summary>
        /// Executes the select statement with the specified condition and return a System.Data.DataTable.
        /// </summary>
        /// <param name="whereClause">The condition for execute select statement.</param>
        /// <param name="trans">The System.Data.OracleClient.OracleTransaction used by this System.Data.OracleClient.OracleCommand.</param>
        /// <returns>The System.Data.DataTable object for specified condition.</returns>
        public DataTable GetDataList(string whereClause, OracleTransaction trans)
        {
            return DB.ExecuteTable(sql_select + (whereClause == "" ? "" : "WHERE " + whereClause));
        }

        /// <summary>
        /// Returns an indication whether the current data is inserted into CUSTOMER table successfully.
        /// </summary>
        /// <param name="userID">The current user.</param>
        /// <param name="trans">The System.Data.OracleClient.OracleTransaction used by this System.Data.OracleClient.OracleCommand.</param>
        /// <returns>true if insert data successfully; otherwise, false.</returns>
        public bool InsertCurrentData(string userID, OracleTransaction trans)
        {
            _CREATEBY = userID;
            _CREATEON = DateTime.Now;
            return doInsert(trans);
        }

        /// <summary>
        /// Returns an indication whether the current data is updated to CUSTOMER table successfully.
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
        /// Returns an indication whether the current data is deleted from CUSTOMER table successfully.
        /// </summary>
        /// <param name="trans">The System.Data.OracleClient.OracleTransaction used by this System.Data.OracleClient.OracleCommand.</param>
        /// <returns>true if delete data successfully; otherwise, false.</returns>
        public bool DeleteCurrentData(OracleTransaction trans)
        {
            return doDelete("LOID = " + DB.SetDouble(_LOID) + " ", trans);
        }

        /// <summary>
        /// Returns an indication whether the record of CUSTOMER by specified LOID key is retrieved successfully.
        /// </summary>
        /// <param name="cLOID">The LOID key.</param>
        /// <param name="trans">The System.Data.OracleClient.OracleTransaction used by this System.Data.OracleClient.OracleCommand.</param>
        /// <returns>true if data is retrieved successfully; otherwise, false.</returns>
        public bool GetDataByLOID(double cLOID, OracleTransaction trans)
        {
            return doGetdata("LOID = " + DB.SetDouble(cLOID) + " ", trans);
        }

        /// <summary>
        /// Returns an indication whether the record of CUSTOMER by specified CODE key is retrieved successfully.
        /// </summary>
        /// <param name="cCODE">The CODE key.</param>
        /// <param name="trans">The System.Data.OracleClient.OracleTransaction used by this System.Data.OracleClient.OracleCommand.</param>
        /// <returns>true if data is retrieved successfully; otherwise, false.</returns>
        public bool GetDataByCODE(string cCODE, OracleTransaction trans)
        {
            return doGetdata("CODE = " + DB.SetString(cCODE) + " ", trans);
        }

        /// <summary>
        /// Returns an indication whether the record of CUSTOMER by specified IDENTITY key is retrieved successfully.
        /// </summary>
        /// <param name="cIDENTITY">The IDENTITY key.</param>
        /// <param name="trans">The System.Data.OracleClient.OracleTransaction used by this System.Data.OracleClient.OracleCommand.</param>
        /// <returns>true if data is retrieved successfully; otherwise, false.</returns>
        public bool GetDataByIDENTITY(string cIDENTITY, OracleTransaction trans)
        {
            return doGetdata("IDENTITY = " + DB.SetString(cIDENTITY) + " ", trans);
        }

        #endregion

        #region SQL Statements

        /// <summary>
        /// Gets the insert statement for CUSTOMER table.
        /// </summary>
        private string sql_insert
        {
            get
            {
                string sql = "INSERT INTO " + tableName + "(ACTIVE, BILLADDRESS, BILLAMPHUR, BILLEMAIL, BILLFAX, BILLPROVINCE, BILLROAD, BILLTAMBOL, BILLTEL, BILLZIPCODE, CADDRESS, CAMPHUR, CEMAIL, CFAX, CLASTNAME, CMOBILE, CNAME, CODE, CPROVINCE, CREATEBY, CREATEON, CREDITAMOUNT, CREDITDAY, CROAD, CTAMBOL, CTEL, CTITLE, CUSTOMERTYPE, CZIPCODE, DELIVERTYPE, EFDATE, EPDATE, IDENTITY, LASTNAME, LOID, MEMBERTYPE, NAME, PAYMENT, REMARK, SENDADDRESS, SENDAMPHUR, SENDEMAIL, SENDFAX, SENDPLACE, SENDPROVINCE, SENDROAD, SENDTAMBOL, SENDTEL, SENDZIPCODE, TITLE) ";
                sql += "VALUES (";
                sql += DB.SetString(_ACTIVE) + ", ";
                sql += DB.SetString(_BILLADDRESS) + ", ";
                sql += DB.SetDouble(_BILLAMPHUR) + ", ";
                sql += DB.SetString(_BILLEMAIL) + ", ";
                sql += DB.SetString(_BILLFAX) + ", ";
                sql += DB.SetDouble(_BILLPROVINCE) + ", ";
                sql += DB.SetString(_BILLROAD) + ", ";
                sql += DB.SetDouble(_BILLTAMBOL) + ", ";
                sql += DB.SetString(_BILLTEL) + ", ";
                sql += DB.SetString(_BILLZIPCODE) + ", ";
                sql += DB.SetString(_CADDRESS) + ", ";
                sql += DB.SetDouble(_CAMPHUR) + ", ";
                sql += DB.SetString(_CEMAIL) + ", ";
                sql += DB.SetString(_CFAX) + ", ";
                sql += DB.SetString(_CLASTNAME) + ", ";
                sql += DB.SetString(_CMOBILE) + ", ";
                sql += DB.SetString(_CNAME) + ", ";
                sql += DB.SetString(_CODE) + ", ";
                sql += DB.SetDouble(_CPROVINCE) + ", ";
                sql += DB.SetString(_CREATEBY) + ", ";
                sql += DB.SetDateTime(_CREATEON) + ", ";
                sql += DB.SetDouble(_CREDITAMOUNT) + ", ";
                sql += DB.SetDouble(_CREDITDAY) + ", ";
                sql += DB.SetString(_CROAD) + ", ";
                sql += DB.SetDouble(_CTAMBOL) + ", ";
                sql += DB.SetString(_CTEL) + ", ";
                sql += DB.SetDouble(_CTITLE) + ", ";
                sql += DB.SetString(_CUSTOMERTYPE) + ", ";
                sql += DB.SetString(_CZIPCODE) + ", ";
                sql += DB.SetString(_DELIVERTYPE) + ", ";
                sql += DB.SetDateTime(_EFDATE) + ", ";
                sql += DB.SetDateTime(_EPDATE) + ", ";
                sql += DB.SetString(_IDENTITY) + ", ";
                sql += DB.SetString(_LASTNAME) + ", ";
                sql += DB.SetDouble(_LOID) + ", ";
                sql += DB.SetDouble(_MEMBERTYPE) + ", ";
                sql += DB.SetString(_NAME) + ", ";
                sql += DB.SetString(_PAYMENT) + ", ";
                sql += DB.SetString(_REMARK) + ", ";
                sql += DB.SetString(_SENDADDRESS) + ", ";
                sql += DB.SetDouble(_SENDAMPHUR) + ", ";
                sql += DB.SetString(_SENDEMAIL) + ", ";
                sql += DB.SetString(_SENDFAX) + ", ";
                sql += DB.SetString(_SENDPLACE) + ", ";
                sql += DB.SetDouble(_SENDPROVINCE) + ", ";
                sql += DB.SetString(_SENDROAD) + ", ";
                sql += DB.SetDouble(_SENDTAMBOL) + ", ";
                sql += DB.SetString(_SENDTEL) + ", ";
                sql += DB.SetString(_SENDZIPCODE) + ", ";
                sql += DB.SetDouble(_TITLE) + " ";
                sql += ")";
                return sql;
            }
        }

        /// <summary>
        /// Gets the update statement for CUSTOMER table.
        /// </summary>
        private string sql_update
        {
            get
            {
                string sql = "UPDATE " + tableName + " SET ";
                sql += "ACTIVE = " + DB.SetString(_ACTIVE) + ", ";
                sql += "BILLADDRESS = " + DB.SetString(_BILLADDRESS) + ", ";
                sql += "BILLAMPHUR = " + DB.SetDouble(_BILLAMPHUR) + ", ";
                sql += "BILLEMAIL = " + DB.SetString(_BILLEMAIL) + ", ";
                sql += "BILLFAX = " + DB.SetString(_BILLFAX) + ", ";
                sql += "BILLPROVINCE = " + DB.SetDouble(_BILLPROVINCE) + ", ";
                sql += "BILLROAD = " + DB.SetString(_BILLROAD) + ", ";
                sql += "BILLTAMBOL = " + DB.SetDouble(_BILLTAMBOL) + ", ";
                sql += "BILLTEL = " + DB.SetString(_BILLTEL) + ", ";
                sql += "BILLZIPCODE = " + DB.SetString(_BILLZIPCODE) + ", ";
                sql += "CADDRESS = " + DB.SetString(_CADDRESS) + ", ";
                sql += "CAMPHUR = " + DB.SetDouble(_CAMPHUR) + ", ";
                sql += "CEMAIL = " + DB.SetString(_CEMAIL) + ", ";
                sql += "CFAX = " + DB.SetString(_CFAX) + ", ";
                sql += "CLASTNAME = " + DB.SetString(_CLASTNAME) + ", ";
                sql += "CMOBILE = " + DB.SetString(_CMOBILE) + ", ";
                sql += "CNAME = " + DB.SetString(_CNAME) + ", ";
                sql += "CODE = " + DB.SetString(_CODE) + ", ";
                sql += "CPROVINCE = " + DB.SetDouble(_CPROVINCE) + ", ";
                sql += "CREDITAMOUNT = " + DB.SetDouble(_CREDITAMOUNT) + ", ";
                sql += "CREDITDAY = " + DB.SetDouble(_CREDITDAY) + ", ";
                sql += "CROAD = " + DB.SetString(_CROAD) + ", ";
                sql += "CTAMBOL = " + DB.SetDouble(_CTAMBOL) + ", ";
                sql += "CTEL = " + DB.SetString(_CTEL) + ", ";
                sql += "CTITLE = " + DB.SetDouble(_CTITLE) + ", ";
                sql += "CUSTOMERTYPE = " + DB.SetString(_CUSTOMERTYPE) + ", ";
                sql += "CZIPCODE = " + DB.SetString(_CZIPCODE) + ", ";
                sql += "DELIVERTYPE = " + DB.SetString(_DELIVERTYPE) + ", ";
                sql += "EFDATE = " + DB.SetDateTime(_EFDATE) + ", ";
                sql += "EPDATE = " + DB.SetDateTime(_EPDATE) + ", ";
                sql += "IDENTITY = " + DB.SetString(_IDENTITY) + ", ";
                sql += "LASTNAME = " + DB.SetString(_LASTNAME) + ", ";
                sql += "MEMBERTYPE = " + DB.SetDouble(_MEMBERTYPE) + ", ";
                sql += "NAME = " + DB.SetString(_NAME) + ", ";
                sql += "PAYMENT = " + DB.SetString(_PAYMENT) + ", ";
                sql += "REMARK = " + DB.SetString(_REMARK) + ", ";
                sql += "SENDADDRESS = " + DB.SetString(_SENDADDRESS) + ", ";
                sql += "SENDAMPHUR = " + DB.SetDouble(_SENDAMPHUR) + ", ";
                sql += "SENDEMAIL = " + DB.SetString(_SENDEMAIL) + ", ";
                sql += "SENDFAX = " + DB.SetString(_SENDFAX) + ", ";
                sql += "SENDPLACE = " + DB.SetString(_SENDPLACE) + ", ";
                sql += "SENDPROVINCE = " + DB.SetDouble(_SENDPROVINCE) + ", ";
                sql += "SENDROAD = " + DB.SetString(_SENDROAD) + ", ";
                sql += "SENDTAMBOL = " + DB.SetDouble(_SENDTAMBOL) + ", ";
                sql += "SENDTEL = " + DB.SetString(_SENDTEL) + ", ";
                sql += "SENDZIPCODE = " + DB.SetString(_SENDZIPCODE) + ", ";
                sql += "TITLE = " + DB.SetDouble(_TITLE) + ", ";
                sql += "UPDATEBY = " + DB.SetString(_UPDATEBY) + ", ";
                sql += "UPDATEON = " + DB.SetDateTime(_UPDATEON) + " ";
                return sql;
            }
        }

        /// <summary>
        /// Gets the delete statement for CUSTOMER table.
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
        /// Gets the select statement for CUSTOMER table.
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
        /// Returns an indication whether the current data is inserted into CUSTOMER table successfully.
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
                    if (!ret) _error = Message.Error.MSGEN001;
                    _information = Message.Information.MSGIN001;
                }
                catch (Exception ex)
                {
                    ex.ToString();
                    ret = false;
                    _error = Message.CriticalError.MSGEC101;
                }
            }
            else
            {
                ret = false;
                _error = Message.Error.MSGEN002;
            }
            return ret;
        }

        /// <summary>
        /// Returns an indication whether the current data is updated to CUSTOMER table successfully.
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
                        if (!ret) _error = Message.Error.MSGEU001;
                        _information = Message.Information.MSGIU001;
                    }
                    catch (Exception ex)
                    {
                        ex.ToString();
                        ret = false;
                        _error = Message.CriticalError.MSGEC102;
                    }
                }
                else
                {
                    ret = false;
                    _error = Message.Error.MSGEU003;
                }
            }
            else
            {
                ret = false;
                _error = Message.Error.MSGEU002;
            }
            return ret;
        }

        /// <summary>
        /// Returns an indication whether the current data is deleted from CUSTOMER table successfully.
        /// </summary>
        /// <param name="whText">The condition specify the deleting record(s).</param>
        /// <param name="trans">The System.Data.OracleClient.OracleTransaction used by this System.Data.OracleClient.OracleCommand.</param>
        /// <returns>true if delete data successfully; otherwise, false.</returns>
        public bool doDelete(string whText, OracleTransaction trans)
        {
            bool ret = true;
            int affectedRow = 0;
            if (whText.Trim() != "")
            {
                string tmpWhere = "WHERE " + whText;
                try
                {
                    affectedRow = DB.ExecuteNonQuery(sql_delete + tmpWhere, trans);
                    ret = (affectedRow > 0);
                    if (!ret) _error = Message.Error.MSGED001;
                    _information = Message.Information.MSGID001;
                }
                catch (Exception ex)
                {
                    ex.ToString();
                    ret = false;
                    _error = Message.CriticalError.MSGEC103;
                }
            }
            else
            {
                ret = false;
                _error = Message.Error.MSGED003;
            }
            return ret;
        }

        /// <summary>
        /// Returns an indication whether the record of CUSTOMER by specified condition is retrieved successfully.
        /// </summary>
        /// <param name="whText">The condition specify the deleting record(s).</param>
        /// <param name="trans">The System.Data.OracleClient.OracleTransaction used by this System.Data.OracleClient.OracleCommand.</param>
        /// <returns>true if data is retrieved successfully; otherwise, false.</returns>
        public bool doGetdata(string whText, OracleTransaction trans)
        {
            bool ret = true;
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
                        if (!zRdr.HasRows)
                        {
                            _OnDB = true;
                            if (!Convert.IsDBNull(zRdr["ACTIVE"])) _ACTIVE = zRdr["ACTIVE"].ToString();
                            if (!Convert.IsDBNull(zRdr["BILLADDRESS"])) _BILLADDRESS = zRdr["BILLADDRESS"].ToString();
                            if (!Convert.IsDBNull(zRdr["BILLAMPHUR"])) _BILLAMPHUR = Convert.ToDouble(zRdr["BILLAMPHUR"]);
                            if (!Convert.IsDBNull(zRdr["BILLEMAIL"])) _BILLEMAIL = zRdr["BILLEMAIL"].ToString();
                            if (!Convert.IsDBNull(zRdr["BILLFAX"])) _BILLFAX = zRdr["BILLFAX"].ToString();
                            if (!Convert.IsDBNull(zRdr["BILLPROVINCE"])) _BILLPROVINCE = Convert.ToDouble(zRdr["BILLPROVINCE"]);
                            if (!Convert.IsDBNull(zRdr["BILLROAD"])) _BILLROAD = zRdr["BILLROAD"].ToString();
                            if (!Convert.IsDBNull(zRdr["BILLTAMBOL"])) _BILLTAMBOL = Convert.ToDouble(zRdr["BILLTAMBOL"]);
                            if (!Convert.IsDBNull(zRdr["BILLTEL"])) _BILLTEL = zRdr["BILLTEL"].ToString();
                            if (!Convert.IsDBNull(zRdr["BILLZIPCODE"])) _BILLZIPCODE = zRdr["BILLZIPCODE"].ToString();
                            if (!Convert.IsDBNull(zRdr["CADDRESS"])) _CADDRESS = zRdr["CADDRESS"].ToString();
                            if (!Convert.IsDBNull(zRdr["CAMPHUR"])) _CAMPHUR = Convert.ToDouble(zRdr["CAMPHUR"]);
                            if (!Convert.IsDBNull(zRdr["CEMAIL"])) _CEMAIL = zRdr["CEMAIL"].ToString();
                            if (!Convert.IsDBNull(zRdr["CFAX"])) _CFAX = zRdr["CFAX"].ToString();
                            if (!Convert.IsDBNull(zRdr["CLASTNAME"])) _CLASTNAME = zRdr["CLASTNAME"].ToString();
                            if (!Convert.IsDBNull(zRdr["CMOBILE"])) _CMOBILE = zRdr["CMOBILE"].ToString();
                            if (!Convert.IsDBNull(zRdr["CNAME"])) _CNAME = zRdr["CNAME"].ToString();
                            if (!Convert.IsDBNull(zRdr["CODE"])) _CODE = zRdr["CODE"].ToString();
                            if (!Convert.IsDBNull(zRdr["CPROVINCE"])) _CPROVINCE = Convert.ToDouble(zRdr["CPROVINCE"]);
                            if (!Convert.IsDBNull(zRdr["CREATEBY"])) _CREATEBY = zRdr["CREATEBY"].ToString();
                            if (!Convert.IsDBNull(zRdr["CREATEON"])) _CREATEON = Convert.ToDateTime(zRdr["CREATEON"]);
                            if (!Convert.IsDBNull(zRdr["CREDITAMOUNT"])) _CREDITAMOUNT = Convert.ToDouble(zRdr["CREDITAMOUNT"]);
                            if (!Convert.IsDBNull(zRdr["CREDITDAY"])) _CREDITDAY = Convert.ToDouble(zRdr["CREDITDAY"]);
                            if (!Convert.IsDBNull(zRdr["CROAD"])) _CROAD = zRdr["CROAD"].ToString();
                            if (!Convert.IsDBNull(zRdr["CTAMBOL"])) _CTAMBOL = Convert.ToDouble(zRdr["CTAMBOL"]);
                            if (!Convert.IsDBNull(zRdr["CTEL"])) _CTEL = zRdr["CTEL"].ToString();
                            if (!Convert.IsDBNull(zRdr["CTITLE"])) _CTITLE = Convert.ToDouble(zRdr["CTITLE"]);
                            if (!Convert.IsDBNull(zRdr["CUSTOMERTYPE"])) _CUSTOMERTYPE = zRdr["CUSTOMERTYPE"].ToString();
                            if (!Convert.IsDBNull(zRdr["CZIPCODE"])) _CZIPCODE = zRdr["CZIPCODE"].ToString();
                            if (!Convert.IsDBNull(zRdr["DELIVERTYPE"])) _DELIVERTYPE = zRdr["DELIVERTYPE"].ToString();
                            if (!Convert.IsDBNull(zRdr["EFDATE"])) _EFDATE = Convert.ToDateTime(zRdr["EFDATE"]);
                            if (!Convert.IsDBNull(zRdr["EPDATE"])) _EPDATE = Convert.ToDateTime(zRdr["EPDATE"]);
                            if (!Convert.IsDBNull(zRdr["IDENTITY"])) _IDENTITY = zRdr["IDENTITY"].ToString();
                            if (!Convert.IsDBNull(zRdr["LASTNAME"])) _LASTNAME = zRdr["LASTNAME"].ToString();
                            if (!Convert.IsDBNull(zRdr["LOID"])) _LOID = Convert.ToDouble(zRdr["LOID"]);
                            if (!Convert.IsDBNull(zRdr["MEMBERTYPE"])) _MEMBERTYPE = Convert.ToDouble(zRdr["MEMBERTYPE"]);
                            if (!Convert.IsDBNull(zRdr["NAME"])) _NAME = zRdr["NAME"].ToString();
                            if (!Convert.IsDBNull(zRdr["PAYMENT"])) _PAYMENT = zRdr["PAYMENT"].ToString();
                            if (!Convert.IsDBNull(zRdr["REMARK"])) _REMARK = zRdr["REMARK"].ToString();
                            if (!Convert.IsDBNull(zRdr["SENDADDRESS"])) _SENDADDRESS = zRdr["SENDADDRESS"].ToString();
                            if (!Convert.IsDBNull(zRdr["SENDAMPHUR"])) _SENDAMPHUR = Convert.ToDouble(zRdr["SENDAMPHUR"]);
                            if (!Convert.IsDBNull(zRdr["SENDEMAIL"])) _SENDEMAIL = zRdr["SENDEMAIL"].ToString();
                            if (!Convert.IsDBNull(zRdr["SENDFAX"])) _SENDFAX = zRdr["SENDFAX"].ToString();
                            if (!Convert.IsDBNull(zRdr["SENDPLACE"])) _SENDPLACE = zRdr["SENDPLACE"].ToString();
                            if (!Convert.IsDBNull(zRdr["SENDPROVINCE"])) _SENDPROVINCE = Convert.ToDouble(zRdr["SENDPROVINCE"]);
                            if (!Convert.IsDBNull(zRdr["SENDROAD"])) _SENDROAD = zRdr["SENDROAD"].ToString();
                            if (!Convert.IsDBNull(zRdr["SENDTAMBOL"])) _SENDTAMBOL = Convert.ToDouble(zRdr["SENDTAMBOL"]);
                            if (!Convert.IsDBNull(zRdr["SENDTEL"])) _SENDTEL = zRdr["SENDTEL"].ToString();
                            if (!Convert.IsDBNull(zRdr["SENDZIPCODE"])) _SENDZIPCODE = zRdr["SENDZIPCODE"].ToString();
                            if (!Convert.IsDBNull(zRdr["TITLE"])) _TITLE = Convert.ToDouble(zRdr["TITLE"]);
                            if (!Convert.IsDBNull(zRdr["UPDATEBY"])) _UPDATEBY = zRdr["UPDATEBY"].ToString();
                            if (!Convert.IsDBNull(zRdr["UPDATEON"])) _UPDATEON = Convert.ToDateTime(zRdr["UPDATEON"]);
                        }
                        else
                        {
                            ret = false;
                            _error = Message.Error.MSGEV003;
                        }
                    }
                    else
                    {
                        ret = false;
                        _error = Message.Error.MSGEV002;
                    }
                    zRdr.Close();
                }
                catch (Exception ex)
                {
                    ex.ToString();
                    ret = false;
                    _error = Message.CriticalError.MSGEC104;
                    if (zRdr != null && !zRdr.IsClosed)
                        zRdr.Close();
                }
            }
            else
            {
                ret = false;
                _error = Message.Error.MSGEV001;
            }
            return ret;
        }

        #endregion

    }
}