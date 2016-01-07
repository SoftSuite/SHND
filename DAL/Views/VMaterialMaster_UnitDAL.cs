using System;
using System.Data;
using System.Data.OracleClient;
using DB = SHND.DAL.Utilities.OracleDB;
using SHND.Data.Common.Utilities;

namespace SHND.DAL.Views
{
    /// <summary>
    /// Represents a transaction for V_MATERIALMASTER_UNIT view.
    /// [Created by 127.0.0.1 on January,7 2009]
    /// </summary>
    public class VMaterialMaster_UnitDAL
    {

        public VMaterialMaster_UnitDAL()
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
        double _COST = 0;
        string _ISFORMULA = "";
        string _ISMAIN = "";
        string _ISSTOCKIN = "";
        string _ISSTOCKOUT = "";
        double _MMLOID = 0;
        string _MMNAME = "";
        double _MULTIPLY = 0;
        double _PRICE = 0;
        string _THNAME = "";
        double _UNITLOID = 0;
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
        public double COST
        {
            get { return _COST; }
            set { _COST = value; }
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
        public double MMLOID
        {
            get { return _MMLOID; }
            set { _MMLOID = value; }
        }
        public string MMNAME
        {
            get { return _MMNAME; }
            set { _MMNAME = value; }
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
        public string THNAME
        {
            get { return _THNAME; }
            set { _THNAME = value; }
        }
        public double UNITLOID
        {
            get { return _UNITLOID; }
            set { _UNITLOID = value; }
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
            _COST = 0;
            _ISFORMULA = "";
            _ISMAIN = "";
            _ISSTOCKIN = "";
            _ISSTOCKOUT = "";
            _MMLOID = 0;
            _MMNAME = "";
            _MULTIPLY = 0;
            _PRICE = 0;
            _THNAME = "";
            _UNITLOID = 0;
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
                        if (!Convert.IsDBNull(zRdr["COST"])) _COST = Convert.ToDouble(zRdr["COST"]);
                        if (!Convert.IsDBNull(zRdr["ISFORMULA"])) _ISFORMULA = zRdr["ISFORMULA"].ToString();
                        if (!Convert.IsDBNull(zRdr["ISMAIN"])) _ISMAIN = zRdr["ISMAIN"].ToString();
                        if (!Convert.IsDBNull(zRdr["ISSTOCKIN"])) _ISSTOCKIN = zRdr["ISSTOCKIN"].ToString();
                        if (!Convert.IsDBNull(zRdr["ISSTOCKOUT"])) _ISSTOCKOUT = zRdr["ISSTOCKOUT"].ToString();
                        if (!Convert.IsDBNull(zRdr["MMLOID"])) _MMLOID = Convert.ToDouble(zRdr["MMLOID"]);
                        if (!Convert.IsDBNull(zRdr["MMNAME"])) _MMNAME = zRdr["MMNAME"].ToString();
                        if (!Convert.IsDBNull(zRdr["MULTIPLY"])) _MULTIPLY = Convert.ToDouble(zRdr["MULTIPLY"]);
                        if (!Convert.IsDBNull(zRdr["PRICE"])) _PRICE = Convert.ToDouble(zRdr["PRICE"]);
                        if (!Convert.IsDBNull(zRdr["THNAME"])) _THNAME = zRdr["THNAME"].ToString();
                        if (!Convert.IsDBNull(zRdr["UNITLOID"])) _UNITLOID = Convert.ToDouble(zRdr["UNITLOID"]);
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

        #region My Methods

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

        #endregion

    }
}