using System;
using System.Data;
using System.Data.OracleClient;
using DB = SHND.DAL.Utilities.OracleDB;
using SHND.Data.Common.Utilities;

namespace SHND.DAL.Views
{
    /// <summary>
    /// Represents a transaction for V_MATERIALMASTER_UNIT view.
    /// [Created by 127.0.0.1 on Febuary,19 2009]
    /// </summary>
    public class VMaterialMasterUnitDAL
    {

        public VMaterialMasterUnitDAL()
        {
        }

        #region Constant

        /// <summary>V_MATERIALMASTER_UNIT</summary>
        private const string viewName = "V_MATERIALMASTER_UNIT";

        #endregion

        #region Private Variables

        string _error = "";
        string _information = "";
        bool _OnDB = false;
        string _ACTIVE = "";
        double _CLASSLOID = 0;
        string _CLASSNAME = "";
        string _CODE = "";
        double _COST = 0;
        double _GROUPLOID = 0;
        string _GROUPNAME = "";
        string _ISFORMULA = "";
        string _ISMAIN = "";
        string _ISSTOCKIN = "";
        string _ISSTOCKOUT = "";
        double _LOID = 0;
        string _MASTERTYPE = "";
        string _MASTERTYPENAME = "";
        string _MATERIALCODE = "";
        double _MATERIALMASTER = 0;
        string _MATERIALNAME = "";
        double _MULTIPLY = 0;
        double _PRICE = 0;
        string _SAPCODE = "";
        string _SPEC = "";
        double _UNIT = 0;
        string _UNITNAME = "";
        double _WEIGHT = 0;

        #endregion

        #region Public Properties

        public string ViewName
        {
            get { return viewName; }
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
        public double CLASSLOID
        {
            get { return _CLASSLOID; }
            set { _CLASSLOID = value; }
        }
        public string CLASSNAME
        {
            get { return _CLASSNAME; }
            set { _CLASSNAME = value; }
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
        public double GROUPLOID
        {
            get { return _GROUPLOID; }
            set { _GROUPLOID = value; }
        }
        public string GROUPNAME
        {
            get { return _GROUPNAME; }
            set { _GROUPNAME = value; }
        }
        public string ISFORMULA
        {
            get { return _ISFORMULA; }
            set { _ISFORMULA = value; }
        }
        public string ISMAIN
        {
            get { return _ISMAIN; }
            set { _ISMAIN = value; }
        }
        public string ISSTOCKIN
        {
            get { return _ISSTOCKIN; }
            set { _ISSTOCKIN = value; }
        }
        public string ISSTOCKOUT
        {
            get { return _ISSTOCKOUT; }
            set { _ISSTOCKOUT = value; }
        }
        public double LOID
        {
            get { return _LOID; }
            set { _LOID = value; }
        }
        public string MASTERTYPE
        {
            get { return _MASTERTYPE; }
            set { _MASTERTYPE = value; }
        }
        public string MASTERTYPENAME
        {
            get { return _MASTERTYPENAME; }
            set { _MASTERTYPENAME = value; }
        }
        public string MATERIALCODE
        {
            get { return _MATERIALCODE; }
            set { _MATERIALCODE = value; }
        }
        public double MATERIALMASTER
        {
            get { return _MATERIALMASTER; }
            set { _MATERIALMASTER = value; }
        }
        public string MATERIALNAME
        {
            get { return _MATERIALNAME; }
            set { _MATERIALNAME = value; }
        }
        public double MULTIPLY
        {
            get { return _MULTIPLY; }
            set { _MULTIPLY = value; }
        }
        public double PRICE
        {
            get { return _PRICE; }
            set { _PRICE = value; }
        }
        public string SAPCODE
        {
            get { return _SAPCODE; }
            set { _SAPCODE = value; }
        }
        public string SPEC
        {
            get { return _SPEC; }
            set { _SPEC = value; }
        }
        public double UNIT
        {
            get { return _UNIT; }
            set { _UNIT = value; }
        }
        public string UNITNAME
        {
            get { return _UNITNAME; }
            set { _UNITNAME = value; }
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
            _ACTIVE = "";
            _CLASSLOID = 0;
            _CLASSNAME = "";
            _CODE = "";
            _COST = 0;
            _GROUPLOID = 0;
            _GROUPNAME = "";
            _ISFORMULA = "";
            _ISMAIN = "";
            _ISSTOCKIN = "";
            _ISSTOCKOUT = "";
            _LOID = 0;
            _MASTERTYPE = "";
            _MASTERTYPENAME = "";
            _MATERIALCODE = "";
            _MATERIALMASTER = 0;
            _MATERIALNAME = "";
            _MULTIPLY = 0;
            _PRICE = 0;
            _SAPCODE = "";
            _SPEC = "";
            _UNIT = 0;
            _UNITNAME = "";
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

        #endregion

        #region SQL Statements

        /// <summary>
        /// Gets the select statement for V_MATERIALMASTER_UNIT table.
        /// </summary>
        private string sql_select
        {
            get
            {
                string sql = "SELECT * FROM " + viewName + " ";
                return sql;
            }
        }

        #endregion

        #region Private Methods

        /// <summary>
        /// Returns an indication whether the record of V_MATERIALMASTER_UNIT by specified condition is retrieved successfully.
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
                        if (!Convert.IsDBNull(zRdr["CLASSLOID"])) _CLASSLOID = Convert.ToDouble(zRdr["CLASSLOID"]);
                        if (!Convert.IsDBNull(zRdr["CLASSNAME"])) _CLASSNAME = zRdr["CLASSNAME"].ToString();
                        if (!Convert.IsDBNull(zRdr["CODE"])) _CODE = zRdr["CODE"].ToString();
                        if (!Convert.IsDBNull(zRdr["COST"])) _COST = Convert.ToDouble(zRdr["COST"]);
                        if (!Convert.IsDBNull(zRdr["GROUPLOID"])) _GROUPLOID = Convert.ToDouble(zRdr["GROUPLOID"]);
                        if (!Convert.IsDBNull(zRdr["GROUPNAME"])) _GROUPNAME = zRdr["GROUPNAME"].ToString();
                        if (!Convert.IsDBNull(zRdr["ISFORMULA"])) _ISFORMULA = zRdr["ISFORMULA"].ToString();
                        if (!Convert.IsDBNull(zRdr["ISMAIN"])) _ISMAIN = zRdr["ISMAIN"].ToString();
                        if (!Convert.IsDBNull(zRdr["ISSTOCKIN"])) _ISSTOCKIN = zRdr["ISSTOCKIN"].ToString();
                        if (!Convert.IsDBNull(zRdr["ISSTOCKOUT"])) _ISSTOCKOUT = zRdr["ISSTOCKOUT"].ToString();
                        if (!Convert.IsDBNull(zRdr["LOID"])) _LOID = Convert.ToDouble(zRdr["LOID"]);
                        if (!Convert.IsDBNull(zRdr["MASTERTYPE"])) _MASTERTYPE = zRdr["MASTERTYPE"].ToString();
                        if (!Convert.IsDBNull(zRdr["MASTERTYPENAME"])) _MASTERTYPENAME = zRdr["MASTERTYPENAME"].ToString();
                        if (!Convert.IsDBNull(zRdr["MATERIALCODE"])) _MATERIALCODE = zRdr["MATERIALCODE"].ToString();
                        if (!Convert.IsDBNull(zRdr["MATERIALMASTER"])) _MATERIALMASTER = Convert.ToDouble(zRdr["MATERIALMASTER"]);
                        if (!Convert.IsDBNull(zRdr["MATERIALNAME"])) _MATERIALNAME = zRdr["MATERIALNAME"].ToString();
                        if (!Convert.IsDBNull(zRdr["MULTIPLY"])) _MULTIPLY = Convert.ToDouble(zRdr["MULTIPLY"]);
                        if (!Convert.IsDBNull(zRdr["PRICE"])) _PRICE = Convert.ToDouble(zRdr["PRICE"]);
                        if (!Convert.IsDBNull(zRdr["SAPCODE"])) _SAPCODE = zRdr["SAPCODE"].ToString();
                        if (!Convert.IsDBNull(zRdr["SPEC"])) _SPEC = zRdr["SPEC"].ToString();
                        if (!Convert.IsDBNull(zRdr["UNIT"])) _UNIT = Convert.ToDouble(zRdr["UNIT"]);
                        if (!Convert.IsDBNull(zRdr["UNITNAME"])) _UNITNAME = zRdr["UNITNAME"].ToString();
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

        public DataTable GetDataListByMaterialMaster(string material_master_loid)
        {
            //string sql = "SELECT * FROM (";
            //sql += " SELECT MMLOID, MMNAME, UNITLOID, THNAME, WEIGHT, COST, PRICE, MULTIPLY, ISSTOCKIN, ISSTOCKOUT, ISFORMULA, ACTIVE, '1' RANK from v_materialmaster_unit t where mmloid = " + material_master_loid + " AND THNAME = '" + main_unit + "'";
            //sql += " UNION ";
            //sql += " SELECT MMLOID, MMNAME, UNITLOID, THNAME, WEIGHT, COST, PRICE, MULTIPLY, ISSTOCKIN, ISSTOCKOUT, ISFORMULA, ACTIVE, '2' RANK from v_materialmaster_unit t where mmloid = " + material_master_loid + " AND THNAME NOT IN ('" + main_unit + "')";
            //sql += " ) ORDER BY RANK, THNAME";

            string sql = "";
            sql = "SELECT * FROM V_MATERIALMASTER_UNIT WHERE MATERIALMASTER = " + material_master_loid;
            sql += " ORDER BY ISMAIN DESC, MULTIPLY ASC, UNITNAME ASC";

            return DB.ExecuteTable(sql);
        }

        public DataTable GetDataListByConditions(double cDOCTYPE, double cCLASSLOID, string cMATERIALNAME, string cISSTOCKIN, string exceptMaterialMasterList, string exceptCodeList, string otherCoditions, string orderBy, OracleTransaction trans)
        {
            string whText = "ACTIVE = '1' ";
            if (cDOCTYPE != 0) whText += (whText == "" ? "" : "AND ") + "MASTERTYPE IN (SELECT MASTERTYPE FROM DOCTYPEMASTERTYPE WHERE DOCTYPE = " + DB.SetDouble(cDOCTYPE) + ") ";
            if (cCLASSLOID != 0) whText += (whText == "" ? "" : "AND ") + "CLASSLOID = " + DB.SetDouble(cCLASSLOID) + " ";
            if (cMATERIALNAME.Trim() != "") whText += (whText == "" ? "" : "AND ") + "UPPER(MATERIALNAME) LIKE " + DB.SetString("%" + cMATERIALNAME.Trim().ToUpper() + "%") + " ";
            if (cISSTOCKIN.Trim() != "") whText += (whText == "" ? "" : "AND ") + "ISSTOCKIN = " + DB.SetString(cISSTOCKIN) + " ";
            if (exceptMaterialMasterList != "") whText += (whText.Trim() == "" ? "" : " AND ") + "MATERIALMASTER NOT IN (" + exceptMaterialMasterList + ") ";
            if (exceptCodeList != "") whText += (whText.Trim() == "" ? "" : " AND ") + "UPPER(CODE) NOT IN (" + exceptCodeList.ToUpper() + ") ";
            if (otherCoditions.Trim() != "") whText += (whText == "" ? "" : "AND ") + otherCoditions + " ";
            return GetDataList(whText, orderBy, trans);
        }


        #region My Work Nang

        public DataTable GetMedFeedListByCondition(string cMMNAME, string exceptMaterialMasterList,string orderBy, OracleTransaction trans)
        {
            string whText = "MASTERTYPE = 'MD' AND UNIT = FN_GETCONFIGVALUE(23) ";
            if (cMMNAME.Trim() != "") whText += (whText == "" ? "" : "AND ") + "UPPER(MATERIALNAME) LIKE " + DB.SetString("%" + cMMNAME.Trim().ToUpper() + "%") + " ";
            //if (exceptMaterialMasterList != "") whText += (whText.Trim() == "" ? "" : " AND ") + "MATERIALMASTER NOT IN (" + exceptMaterialMasterList + ") ";
            return GetDataList(whText, orderBy, trans);
        }

        #endregion

    }
}