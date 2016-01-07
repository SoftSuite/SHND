using System;
using System.Data;
using System.Data.OracleClient;
using DB = SHND.DAL.Utilities.OracleDB;
using SHND.Data.Common.Utilities;

namespace SHND.DAL.Tables
{
    /// <summary>
    /// Represents a transaction for MATERIALMASTER table.
    /// [Created by 127.0.0.1 on January,5 2009]
    /// </summary>
    public class MaterialMasterDAL
    {

        public MaterialMasterDAL()
        {
        }

        #region Constant

        /// <summary>MATERIALMASTER</summary>
        private const string tableName = "MATERIALMASTER";

        #endregion

        #region Private Variables

        int _deletedRow = 0;
        string _error = "";
        string _information = "";
        bool _OnDB = false;
        string _ACTIVE = "";
        string _ARTICLECODE = "";
        string _CODE = "";
        double _COST = 0;
        string _CREATEBY = "";
        DateTime _CREATEON = new DateTime(1, 1, 1);
        double _DIVISION = 0;
        double _ENERGY = 0;
        string _ISCOUNT = "";
        string _ISMENU = "";
        double _LOID = 0;
        double _MATERIALCLASS = 0;
        double _MATERIALGROUP = 0;
        double _MAXSTOCK = 0;
        double _MILKCATEGORY = 0;
        double _MINSTOCK = 0;
        string _NAME = "";
        string _ORDERTYPE = "";
        double _PRICE = 0;
        string _REMARKS = "";
        string _SAPCODE = "";
        double _SAPWAREHOUSE = 0;
        string _SPEC = "";
        string _STOCKOUTBREAKFAST = "";
        string _STOCKOUTDINNER = "";
        string _STOCKOUTLUNCH = "";
        double _UNIT = 0;
        string _UPDATEBY = "";
        DateTime _UPDATEON = new DateTime(1, 1, 1);
        double _WEIGHT = 0;
        double _WEIGHTCOOK = 0;
        double _WEIGHTPREPARE = 0;
        double _WEIGHTCOOKFR = 0;
        double _WEIGHTCOOKBO = 0;
        double _WEIGHTCOOKRO = 0;
        double _WEIGHTCOOKFY = 0;
        double _WEIGHTCOOKST = 0;
        double _WEIGHTCOOKNN = 0;
        double _WEIGHTCOOKPE = 0;
        double _OILFR = 0;
        double _OILFY = 0;
        double _NUTRIENTRATE = 0;

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
        public string ARTICLECODE
        {
            get { return _ARTICLECODE; }
            set { _ARTICLECODE = value; }
        }
        public string CODE
        {
            get { return _CODE; }
            set { _CODE = value; }
        }
        public double COST
        {
            get { return _COST; }
            set { _COST = value; }
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
        public double ENERGY
        {
            get { return _ENERGY; }
            set { _ENERGY = value; }
        }
        public string ISCOUNT
        {
            get { return _ISCOUNT; }
            set { _ISCOUNT = value; }
        }
        public string ISMENU
        {
            get { return _ISMENU; }
            set { _ISMENU = value; }
        }
        public double LOID
        {
            get { return _LOID; }
            set { _LOID = value; }
        }
        public double MATERIALCLASS
        {
            get { return _MATERIALCLASS; }
            set { _MATERIALCLASS = value; }
        }
        public double MATERIALGROUP
        {
            get { return _MATERIALGROUP; }
            set { _MATERIALGROUP = value; }
        }
        public double MAXSTOCK
        {
            get { return _MAXSTOCK; }
            set { _MAXSTOCK = value; }
        }
        public double MILKCATEGORY
        {
            get { return _MILKCATEGORY; }
            set { _MILKCATEGORY = value; }
        }
        public double MINSTOCK
        {
            get { return _MINSTOCK; }
            set { _MINSTOCK = value; }
        }
        public string NAME
        {
            get { return _NAME; }
            set { _NAME = value; }
        }
        public string ORDERTYPE
        {
            get { return _ORDERTYPE; }
            set { _ORDERTYPE = value; }
        }
        public double PRICE
        {
            get { return _PRICE; }
            set { _PRICE = value; }
        }
        public string REMARKS
        {
            get { return _REMARKS; }
            set { _REMARKS = value; }
        }
        public string SAPCODE
        {
            get { return _SAPCODE; }
            set { _SAPCODE = value; }
        }
        public double SAPWAREHOUSE
        {
            get { return _SAPWAREHOUSE; }
            set { _SAPWAREHOUSE = value; }
        }
        public string SPEC
        {
            get { return _SPEC; }
            set { _SPEC = value; }
        }
        public string STOCKOUTBREAKFAST
        {
            get { return _STOCKOUTBREAKFAST; }
            set { _STOCKOUTBREAKFAST = value; }
        }
        public string STOCKOUTDINNER
        {
            get { return _STOCKOUTDINNER; }
            set { _STOCKOUTDINNER = value; }
        }
        public string STOCKOUTLUNCH
        {
            get { return _STOCKOUTLUNCH; }
            set { _STOCKOUTLUNCH = value; }
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
        public double WEIGHT
        {
            get { return _WEIGHT; }
            set { _WEIGHT = value; }
        }
        public double WEIGHTCOOK
        {
            get { return _WEIGHTCOOK; }
            set { _WEIGHTCOOK = value; }
        }
        public double WEIGHTPREPARE
        {
            get { return _WEIGHTPREPARE; }
            set { _WEIGHTPREPARE = value; }
        }
        public double WEIGHTCOOKBO
        {
            get { return _WEIGHTCOOKBO; }
            set { _WEIGHTCOOKBO = value; }
        }
        public double WEIGHTCOOKFR
        {
            get { return _WEIGHTCOOKFR; }
            set { _WEIGHTCOOKFR = value; }
        }
        public double WEIGHTCOOKRO
        {
            get { return _WEIGHTCOOKRO; }
            set { _WEIGHTCOOKRO = value; }
        }
        public double WEIGHTCOOKFY
        {
            get { return _WEIGHTCOOKFY; }
            set { _WEIGHTCOOKFY = value; }
        }
        public double WEIGHTCOOKST
        {
            get { return _WEIGHTCOOKST; }
            set { _WEIGHTCOOKST = value; }
        }
        public double WEIGHTCOOKNN
        {
            get { return _WEIGHTCOOKNN; }
            set { _WEIGHTCOOKNN = value; }
        }
        public double WEIGHTCOOKPE
        {
            get { return _WEIGHTCOOKPE; }
            set { _WEIGHTCOOKPE = value; }
        }
        public double OILFY
        {
            get { return _OILFY; }
            set { _OILFY = value; }
        }
        public double OILFR
        {
            get { return _OILFR; }
            set { _OILFR = value; }
        }
        public double NUTRIENTRATE
        {
            get { return _NUTRIENTRATE; }
            set { _NUTRIENTRATE = value; }
        }

        #endregion

        #region Clear Data

        /// <summary>
        /// Initialize data.
        /// </summary>
        private void ClearData()
        {
            _ACTIVE = "";
            _ARTICLECODE = "";
            _CODE = "";
            _COST = 0;
            _CREATEBY = "";
            _CREATEON = new DateTime(1, 1, 1);
            _DIVISION = 0;
            _ENERGY = 0;
            _ISCOUNT = "";
            _ISMENU = "";
            _LOID = 0;
            _MATERIALCLASS = 0;
            _MATERIALGROUP = 0;
            _MAXSTOCK = 0;
            _MILKCATEGORY = 0;
            _MINSTOCK = 0;
            _NAME = "";
            _ORDERTYPE = "";
            _PRICE = 0;
            _REMARKS = "";
            _SAPCODE = "";
            _SAPWAREHOUSE = 0;
            _SPEC = "";
            _STOCKOUTBREAKFAST = "";
            _STOCKOUTDINNER = "";
            _STOCKOUTLUNCH = "";
            _UNIT = 0;
            _UPDATEBY = "";
            _UPDATEON = new DateTime(1, 1, 1);
            _WEIGHT = 0;
            _WEIGHTCOOK = 0;
            _WEIGHTPREPARE = 0;
            _WEIGHTCOOKFR = 0;
            _WEIGHTCOOKBO = 0;
            _WEIGHTCOOKRO = 0;
            _WEIGHTCOOKFY = 0;
            _WEIGHTCOOKST = 0;
            _WEIGHTCOOKNN = 0;
            _WEIGHTCOOKPE = 0;
            _OILFR = 0;
            _OILFY = 0;
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
        /// Returns an indication whether the current data is inserted into MATERIALMASTER table successfully.
        /// </summary>
        /// <param name="userID">The current user.</param>
        /// <param name="trans">The System.Data.OracleClient.OracleTransaction used by this System.Data.OracleClient.OracleCommand.</param>
        /// <returns>true if insert data successfully; otherwise, false.</returns>
        public bool InsertCurrentData(string userID, OracleTransaction trans)
        {
            _LOID = DB.GetNextID(TableName, trans);
            _CODE = DB.GetRunningCode("MATERIALMASTER", "CODE", trans);
            _CREATEBY = userID;
            _CREATEON = DateTime.Now;
            return doInsert(trans);
        }

        /// <summary>
        /// Returns an indication whether the current data is updated to MATERIALMASTER table successfully.
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
        /// Returns an indication whether the current data is deleted from MATERIALMASTER table successfully.
        /// </summary>
        /// <param name="trans">The System.Data.OracleClient.OracleTransaction used by this System.Data.OracleClient.OracleCommand.</param>
        /// <returns>true if delete data successfully; otherwise, false.</returns>
        public bool DeleteCurrentData(OracleTransaction trans)
        {
            return doDelete("LOID = " + DB.SetDouble(_LOID) + " ", trans);
        }

        /// <summary>
        /// Returns an indication whether the record of MATERIALMASTER by specified LOID key is retrieved successfully.
        /// </summary>
        /// <param name="cLOID">The LOID key.</param>
        /// <param name="trans">The System.Data.OracleClient.OracleTransaction used by this System.Data.OracleClient.OracleCommand.</param>
        /// <returns>true if data is retrieved successfully; otherwise, false.</returns>
        public bool GetDataByLOID(double cLOID, OracleTransaction trans)
        {
            return doGetdata("LOID = " + DB.SetDouble(cLOID) + " ", trans);
        }

        /// <summary>
        /// Returns an indication whether the record of MATERIALMASTER by specified CODE key is retrieved successfully.
        /// </summary>
        /// <param name="cCODE">The CODE key.</param>
        /// <param name="trans">The System.Data.OracleClient.OracleTransaction used by this System.Data.OracleClient.OracleCommand.</param>
        /// <returns>true if data is retrieved successfully; otherwise, false.</returns>
        public bool GetDataByCODE(string cCODE, OracleTransaction trans)
        {
            return doGetdata("CODE = " + DB.SetString(cCODE) + " ", trans);
        }

        /// <summary>
        /// Returns an indication whether the record of MATERIALMASTER by specified NAME key is retrieved successfully.
        /// </summary>
        /// <param name="cNAME">The NAME key.</param>
        /// <param name="trans">The System.Data.OracleClient.OracleTransaction used by this System.Data.OracleClient.OracleCommand.</param>
        /// <returns>true if data is retrieved successfully; otherwise, false.</returns>
        public bool GetDataByNAME(string cNAME, OracleTransaction trans)
        {
            return doGetdata("NAME = " + DB.SetString(cNAME) + " ", trans);
        }

        /// <summary>
        /// Returns an indication whether the record of MATERIALMASTER by specified SAPCODE key is retrieved successfully.
        /// </summary>
        /// <param name="cSAPCODE">The SAPCODE key.</param>
        /// <param name="trans">The System.Data.OracleClient.OracleTransaction used by this System.Data.OracleClient.OracleCommand.</param>
        /// <returns>true if data is retrieved successfully; otherwise, false.</returns>
        public bool GetDataBySAPCODE(string cSAPCODE, OracleTransaction trans)
        {
            return doGetdata("SAPCODE = " + DB.SetString(cSAPCODE) + " ", trans);
        }

        public bool GetDataByMilk(double cMilk, OracleTransaction trans)
        {
            return doGetdata("MILKCATEGORY = " + DB.SetDouble(cMilk) + " ", trans);
        }

        public bool DeleteDataByFormulaSet(double cFORMULASET, OracleTransaction trans)
        {
            return doDelete("FORMULASET = " + DB.SetDouble(cFORMULASET) + " ", trans);
        }

        public bool DeleteDataByLOID(double cLOID, OracleTransaction trans)
        {
            return doDelete(" LOID = " + DB.SetDouble(cLOID) + " ", trans);
        }

        

        #endregion

        #region SQL Statements

        /// <summary>
        /// Gets the insert statement for MATERIALMASTER table.
        /// </summary>
        private string sql_insert
        {
            get
            {
                string sql = "INSERT INTO " + tableName + "(LOID, ACTIVE, ARTICLECODE, CODE, ";
                sql += " COST, CREATEBY, CREATEON, DIVISION, ENERGY, ISCOUNT, ISMENU, MATERIALCLASS, ";
                sql += " MATERIALGROUP, MAXSTOCK, MILKCATEGORY, MINSTOCK, NAME, ORDERTYPE, PRICE, ";
                sql += " REMARKS, SAPCODE, SAPWAREHOUSE, SPEC, STOCKOUTBREAKFAST, STOCKOUTDINNER, STOCKOUTLUNCH, ";
                sql += " UNIT, WEIGHT, WEIGHTCOOK, WEIGHTPREPARE, WEIGHTCOOKBO,WEIGHTCOOKFR, WEIGHTCOOKRO,WEIGHTCOOKFY, ";
                sql += " WEIGHTCOOKST, WEIGHTCOOKNN, WEIGHTCOOKPE, OILFY, OILFR) ";
                sql += " VALUES (";
                sql += DB.SetDouble(_LOID) + ", ";
                sql += DB.SetString(_ACTIVE) + ", ";
                sql += DB.SetString(_ARTICLECODE) + ", ";
                sql += DB.SetString(_CODE) + ", ";
                sql += DB.SetDouble(_COST) + ", ";
                sql += DB.SetString(_CREATEBY) + ", ";
                sql += DB.SetDateTime(_CREATEON) + ", ";
                sql += DB.SetDouble(_DIVISION) + ", ";
                sql += DB.SetDouble(_ENERGY) + ", ";
                sql += DB.SetString(_ISCOUNT) + ", ";
                sql += DB.SetString(_ISMENU) + ", ";
                sql += DB.SetDouble(_MATERIALCLASS) + ", ";
                sql += DB.SetDouble(_MATERIALGROUP) + ", ";
                sql += DB.SetDouble(_MAXSTOCK) + ", ";
                sql += DB.SetDouble(_MILKCATEGORY) + ", ";
                sql += DB.SetDouble(_MINSTOCK) + ", ";
                sql += DB.SetString(_NAME) + ", ";
                sql += DB.SetString(_ORDERTYPE) + ", ";
                sql += DB.SetDouble(_PRICE) + ", ";
                sql += DB.SetString(_REMARKS) + ", ";
                sql += DB.SetString(_SAPCODE) + ", ";
                sql += DB.SetDouble(_SAPWAREHOUSE) + ", ";
                sql += DB.SetString(_SPEC) + ", ";
                sql += DB.SetString(_STOCKOUTBREAKFAST) + ", ";
                sql += DB.SetString(_STOCKOUTDINNER) + ", ";
                sql += DB.SetString(_STOCKOUTLUNCH) + ", ";
                sql += DB.SetDouble(_UNIT) + ", ";
                sql += DB.SetDouble(_WEIGHT) + ", ";
                sql += DB.SetDouble(_WEIGHTCOOK) + ", ";
                sql += DB.SetDouble(_WEIGHTPREPARE) + ", ";
                sql += DB.SetDouble(_WEIGHTCOOKBO) + ", ";
                sql += DB.SetDouble(_WEIGHTCOOKFR) + ", ";
                sql += DB.SetDouble(_WEIGHTCOOKRO) + ", ";
                sql += DB.SetDouble(_WEIGHTCOOKFY) + ", ";
                sql += DB.SetDouble(_WEIGHTCOOKST) + ", ";
                sql += DB.SetDouble(_WEIGHTCOOKNN) + ", ";
                sql += DB.SetDouble(_WEIGHTCOOKPE) + ", ";
                sql += DB.SetDouble(_OILFY) + ", ";
                sql += DB.SetDouble(_OILFR) + " ";
                sql += ")";
                return sql;
            }
        }

        /// <summary>
        /// Gets the update statement for MATERIALMASTER table.
        /// </summary>
        private string sql_update
        {
            get
            {
                string sql = "UPDATE " + tableName + " SET ";
                sql += "ACTIVE = " + DB.SetString(_ACTIVE) + ", ";
                sql += "ARTICLECODE = " + DB.SetString(_ARTICLECODE) + ", ";
                sql += "CODE = " + DB.SetString(_CODE) + ", ";
                sql += "COST = " + DB.SetDouble(_COST) + ", ";
                sql += "DIVISION = " + DB.SetDouble(_DIVISION) + ", ";
                sql += "ENERGY = " + DB.SetDouble(_ENERGY) + ", ";
                sql += "ISCOUNT = " + DB.SetString(_ISCOUNT) + ", ";
                sql += "ISMENU = " + DB.SetString(_ISMENU) + ", ";
                sql += "MATERIALCLASS = " + DB.SetDouble(_MATERIALCLASS) + ", ";
                sql += "MATERIALGROUP = " + DB.SetDouble(_MATERIALGROUP) + ", ";
                sql += "MAXSTOCK = " + DB.SetDouble(_MAXSTOCK) + ", ";
                sql += "MILKCATEGORY = " + DB.SetDouble(_MILKCATEGORY) + ", ";
                sql += "MINSTOCK = " + DB.SetDouble(_MINSTOCK) + ", ";
                sql += "NAME = " + DB.SetString(_NAME) + ", ";
                sql += "ORDERTYPE = " + DB.SetString(_ORDERTYPE) + ", ";
                sql += "PRICE = " + DB.SetDouble(_PRICE) + ", ";
                sql += "REMARKS = " + DB.SetString(_REMARKS) + ", ";
                sql += "SAPCODE = " + DB.SetString(_SAPCODE) + ", ";
                sql += "SAPWAREHOUSE = " + DB.SetDouble(_SAPWAREHOUSE) + ", ";
                sql += "SPEC = " + DB.SetString(_SPEC) + ", ";
                sql += "STOCKOUTBREAKFAST = " + DB.SetString(_STOCKOUTBREAKFAST) + ", ";
                sql += "STOCKOUTDINNER = " + DB.SetString(_STOCKOUTDINNER) + ", ";
                sql += "STOCKOUTLUNCH = " + DB.SetString(_STOCKOUTLUNCH) + ", ";
                sql += "UNIT = " + DB.SetDouble(_UNIT) + ", ";
                sql += "UPDATEBY = " + DB.SetString(_UPDATEBY) + ", ";
                sql += "UPDATEON = " + DB.SetDateTime(_UPDATEON) + ", ";
                sql += "WEIGHT = " + DB.SetDouble(_WEIGHT) + ", ";
                sql += "WEIGHTCOOK = " + DB.SetDouble(_WEIGHTCOOK) + ", ";
                sql += "WEIGHTPREPARE = " + DB.SetDouble(_WEIGHTPREPARE) + ", ";
                sql += "WEIGHTCOOKBO = " + DB.SetDouble(_WEIGHTCOOKBO) + ", ";
                sql += "WEIGHTCOOKFR = " + DB.SetDouble(_WEIGHTCOOKFR) + ", ";
                sql += "WEIGHTCOOKRO = " + DB.SetDouble(_WEIGHTCOOKRO) + ", ";
                sql += "WEIGHTCOOKFY = " + DB.SetDouble(_WEIGHTCOOKFY) + ", ";
                sql += "WEIGHTCOOKST = " + DB.SetDouble(_WEIGHTCOOKST) + ", ";
                sql += "WEIGHTCOOKNN = " + DB.SetDouble(_WEIGHTCOOKNN) + ", ";
                sql += "WEIGHTCOOKPE = " + DB.SetDouble(_WEIGHTCOOKPE) + ", ";
                sql += "OILFR = " + DB.SetDouble(_OILFR) + ", ";
                sql += "OILFY = " + DB.SetDouble(_OILFY) + " ";
                return sql;
            }
        }

        /// <summary>
        /// Gets the delete statement for MATERIALMASTER table.
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
        /// Gets the select statement for MATERIALMASTER table.
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
        /// Returns an indication whether the current data is inserted into MATERIALMASTER table successfully.
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
        /// Returns an indication whether the current data is updated to MATERIALMASTER table successfully.
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

        public bool UpdateEnergy(string Loid)
        {
            bool ret = true;
            int affectedRow = 0;
            string sql = "UPDATE " + tableName + " SET ENERGY = " + DB.SetDouble(_ENERGY) + ", NUTRIENTRATE = " + DB.SetDouble(_NUTRIENTRATE) + " WHERE LOID = "+ Loid;
            affectedRow = DB.ExecuteNonQuery(sql);
            ret = (affectedRow > 0);
            if (!ret) _error = DataResources.MSGEU001;
            _information = DataResources.MSGIU001;
            return ret;
        }

        /// <summary>
        /// Returns an indication whether the current data is deleted from MATERIALMASTER table successfully.
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
        /// Returns an indication whether the record of MATERIALMASTER by specified condition is retrieved successfully.
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
                        if (!Convert.IsDBNull(zRdr["ARTICLECODE"])) _ARTICLECODE = zRdr["ARTICLECODE"].ToString();
                        if (!Convert.IsDBNull(zRdr["CODE"])) _CODE = zRdr["CODE"].ToString();
                        if (!Convert.IsDBNull(zRdr["COST"])) _COST = Convert.ToDouble(zRdr["COST"]);
                        if (!Convert.IsDBNull(zRdr["CREATEBY"])) _CREATEBY = zRdr["CREATEBY"].ToString();
                        if (!Convert.IsDBNull(zRdr["CREATEON"])) _CREATEON = Convert.ToDateTime(zRdr["CREATEON"]);
                        if (!Convert.IsDBNull(zRdr["DIVISION"])) _DIVISION = Convert.ToDouble(zRdr["DIVISION"]);
                        if (!Convert.IsDBNull(zRdr["ENERGY"])) _ENERGY = Convert.ToDouble(zRdr["ENERGY"]);
                        if (!Convert.IsDBNull(zRdr["ISCOUNT"])) _ISCOUNT = zRdr["ISCOUNT"].ToString();
                        if (!Convert.IsDBNull(zRdr["ISMENU"])) _ISMENU = zRdr["ISMENU"].ToString();
                        if (!Convert.IsDBNull(zRdr["LOID"])) _LOID = Convert.ToDouble(zRdr["LOID"]);
                        if (!Convert.IsDBNull(zRdr["MATERIALCLASS"])) _MATERIALCLASS = Convert.ToDouble(zRdr["MATERIALCLASS"]);
                        if (!Convert.IsDBNull(zRdr["MATERIALGROUP"])) _MATERIALGROUP = Convert.ToDouble(zRdr["MATERIALGROUP"]);
                        if (!Convert.IsDBNull(zRdr["MAXSTOCK"])) _MAXSTOCK = Convert.ToDouble(zRdr["MAXSTOCK"]);
                        if (!Convert.IsDBNull(zRdr["MILKCATEGORY"])) _MILKCATEGORY = Convert.ToDouble(zRdr["MILKCATEGORY"]);
                        if (!Convert.IsDBNull(zRdr["MINSTOCK"])) _MINSTOCK = Convert.ToDouble(zRdr["MINSTOCK"]);
                        if (!Convert.IsDBNull(zRdr["NAME"])) _NAME = zRdr["NAME"].ToString();
                        if (!Convert.IsDBNull(zRdr["ORDERTYPE"])) _ORDERTYPE = zRdr["ORDERTYPE"].ToString();
                        if (!Convert.IsDBNull(zRdr["PRICE"])) _PRICE = Convert.ToDouble(zRdr["PRICE"]);
                        if (!Convert.IsDBNull(zRdr["REMARKS"])) _REMARKS = zRdr["REMARKS"].ToString();
                        if (!Convert.IsDBNull(zRdr["SAPCODE"])) _SAPCODE = zRdr["SAPCODE"].ToString();
                        if (!Convert.IsDBNull(zRdr["SAPWAREHOUSE"])) _SAPWAREHOUSE = Convert.ToDouble(zRdr["SAPWAREHOUSE"]);
                        if (!Convert.IsDBNull(zRdr["SPEC"])) _SPEC = zRdr["SPEC"].ToString();
                        if (!Convert.IsDBNull(zRdr["STOCKOUTBREAKFAST"])) _STOCKOUTBREAKFAST = zRdr["STOCKOUTBREAKFAST"].ToString();
                        if (!Convert.IsDBNull(zRdr["STOCKOUTDINNER"])) _STOCKOUTDINNER = zRdr["STOCKOUTDINNER"].ToString();
                        if (!Convert.IsDBNull(zRdr["STOCKOUTLUNCH"])) _STOCKOUTLUNCH = zRdr["STOCKOUTLUNCH"].ToString();
                        if (!Convert.IsDBNull(zRdr["UNIT"])) _UNIT = Convert.ToDouble(zRdr["UNIT"]);
                        if (!Convert.IsDBNull(zRdr["UPDATEBY"])) _UPDATEBY = zRdr["UPDATEBY"].ToString();
                        if (!Convert.IsDBNull(zRdr["UPDATEON"])) _UPDATEON = Convert.ToDateTime(zRdr["UPDATEON"]);
                        if (!Convert.IsDBNull(zRdr["WEIGHT"])) _WEIGHT = Convert.ToDouble(zRdr["WEIGHT"]);
                        if (!Convert.IsDBNull(zRdr["WEIGHTCOOK"])) _WEIGHTCOOK = Convert.ToDouble(zRdr["WEIGHTCOOK"]);
                        if (!Convert.IsDBNull(zRdr["WEIGHTPREPARE"])) _WEIGHTPREPARE = Convert.ToDouble(zRdr["WEIGHTPREPARE"]);
                        if (!Convert.IsDBNull(zRdr["WEIGHTCOOKBO"])) _WEIGHTCOOKBO = Convert.ToDouble(zRdr["WEIGHTCOOKBO"]);
                        if (!Convert.IsDBNull(zRdr["WEIGHTCOOKFR"])) _WEIGHTCOOKFR = Convert.ToDouble(zRdr["WEIGHTCOOKFR"]);
                        if (!Convert.IsDBNull(zRdr["WEIGHTCOOKRO"])) _WEIGHTCOOKRO = Convert.ToDouble(zRdr["WEIGHTCOOKRO"]);
                        if (!Convert.IsDBNull(zRdr["WEIGHTCOOKFY"])) _WEIGHTCOOKFY = Convert.ToDouble(zRdr["WEIGHTCOOKFY"]);
                        if (!Convert.IsDBNull(zRdr["WEIGHTCOOKST"])) _WEIGHTCOOKST = Convert.ToDouble(zRdr["WEIGHTCOOKST"]);
                        if (!Convert.IsDBNull(zRdr["WEIGHTCOOKNN"])) _WEIGHTCOOKNN = Convert.ToDouble(zRdr["WEIGHTCOOKNN"]);
                        if (!Convert.IsDBNull(zRdr["WEIGHTCOOKPE"])) _WEIGHTCOOKPE = Convert.ToDouble(zRdr["WEIGHTCOOKPE"]);
                        if (!Convert.IsDBNull(zRdr["OILFY"])) _OILFY = Convert.ToDouble(zRdr["OILFY"]);
                        if (!Convert.IsDBNull(zRdr["OILFR"])) _OILFR = Convert.ToDouble(zRdr["OILFR"]);
                        if (!Convert.IsDBNull(zRdr["NUTRIENTRATE"])) _NUTRIENTRATE = Convert.ToDouble(zRdr["NUTRIENTRATE"]);
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

        private string sql_energy
        {
            get
            {
                string sql = "SELECT ENERGY FROM " + tableName + " ";
                return sql;
            }
        }

        private string sql_water  //Nang
        {
            get
            {
                string sql = "SELECT MATERIALMASTER.NAME MATERIALNAME,UNIT.LOID UULOID,UNIT.ABBNAME, ";
                sql += " 0 AS COST, 0 AS FFLOID, MATERIALMASTER.LOID, '' FILOID ";
                sql += " FROM MATERIALMASTER INNER JOIN UNIT ON UNIT.LOID =  MATERIALMASTER.UNIT ";
                return sql;
            }
        }

        private string sql_milk //Nang
        {
            get
            {
                string sql = "SELECT MM.LOID MMLOID, MM.NAME MATERIALNAME,UNIT.LOID UULOID, ";
                sql += " 0 AS QTY, 0 AS FMLOID, MM.LOID MMLOID, 0 FMLOID ,UNIT.ABBNAME UNITNAME ";
                sql += " FROM MATERIALMASTER MM INNER JOIN MILKCATEGORY MC ON MC.LOID =  MM.MILKCATEGORY ";
                sql += " INNER JOIN MATERIALUNIT MU ON MU.MATERIALMASTER = MM.LOID ";
                sql += " INNER JOIN UNIT ON UNIT.LOID = MU.UNIT ";
                return sql;
            }
        }

        public double GetEnergy(string material_master_loid)
        {
            string sql = "SELECT ENERGY FROM MATERIALMASTER WHERE LOID = " + material_master_loid;
            object tmp = DB.ExecuteScalar(sql);

            if (Convert.IsDBNull(tmp) == false)
            {
                return Convert.ToDouble(tmp);
            }
            else
                return 0;
        }

        public double GetEnergy100G(string material_master_loid, OracleTransaction Trans)
        {
            string sql = "SELECT FN_CALENERGYWEIGHT(" + material_master_loid + ",100) FROM DUAL";
            object tmp = DB.ExecuteScalar(sql, Trans);

            if (Convert.IsDBNull(tmp) == false)
            {
                return Convert.ToDouble(tmp);
            }
            else
                return 0;
        }

        public double GetFunctionEnergy(string material_master_loid)
        {
            string sql = "SELECT ROUND(PKE_MASTER.FN_CALMATERIALENERGY(" + int.Parse(material_master_loid) + "),4) FROM DUAL ";
            object tmp = DB.ExecuteScalar(sql);

            if (Convert.IsDBNull(tmp) == false)
            {
                return Convert.ToDouble(tmp);
            }
            else
                return 0;
        }

        public DataTable GetWater(string whereClause, string orderBy, OracleTransaction trans)//Nang
        {
            return DB.ExecuteTable(sql_water + (whereClause == "" ? "" : "WHERE " + whereClause + " ") + (orderBy == "" ? "" : "ORDER BY " + DB.SetSortString(orderBy)), trans);
        }

        public DataTable GetMaterialMilk(string whereClause, string orderBy, OracleTransaction trans)//nang
        {
            return DB.ExecuteTable(sql_milk + (whereClause == "" ? "" : "WHERE " + whereClause + " ") + (orderBy == "" ? "" : "ORDER BY " + DB.SetSortString(orderBy)), trans);
        }

        public bool DeleteMaterialMaster(string whText, OracleTransaction trans)
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

        public string GetEnergyByMilk(string whereClause, OracleTransaction trans)
        {
            if (DB.ExecuteScalar(sql_energy + (whereClause == "" ? "" : "WHERE " + whereClause + " "), trans) != null)
                return DB.ExecuteScalar(sql_energy + (whereClause == "" ? "" : "WHERE " + whereClause + " "), trans).ToString();
            else
                return "";
        }
        public double GetNutrientRate(double mloid, OracleTransaction trans)
        {
            return Convert.ToDouble(DB.ExecuteScalar("SELECT NUTRIENTRATE FROM MATERIALMASTER WHERE MILKCATEGORY = " + mloid, trans));
        }


        #endregion

    }
}