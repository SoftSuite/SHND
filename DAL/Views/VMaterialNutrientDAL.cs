using System;
using System.Data;
using System.Data.OracleClient;
using DB = SHND.DAL.Utilities.OracleDB;
using SHND.Data.Common.Utilities;

namespace SHND.DAL.Views
{
    /// <summary>
    /// Represents a transaction for V_MATERIALNUTRIENT view.
    /// [Created by 127.0.0.1 on January,9 2009]
    /// </summary>
    public class VMaterialNutrientDAL
    {

        public VMaterialNutrientDAL()
        {
        }

        #region Constant

        /// <summary>V_MATERIALNUTRIENT</summary>
        private const string viewName = "V_MATERIALNUTRIENT";

        #endregion

        #region Private Variables

        string _error = "";
        string _information = "";
        bool _OnDB = false;
        double _MMLOID = 0;
        string _MMNAME = "";
        double _NUTRIENTLOID = 0;
        string _NUTRIENTNAME = "";
        double _QTY = 0;
        double _UNITLOID = 0;
        string _UNITNAME = "";

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
        public double NUTRIENTLOID
        {
            get { return _NUTRIENTLOID; }
            set { _NUTRIENTLOID = value; }
        }
        public string NUTRIENTNAME
        {
            get { return _NUTRIENTNAME; }
            set { _NUTRIENTNAME = value; }
        }
        public double QTY
        {
            get { return _QTY; }
            set { _QTY = value; }
        }
        public double UNITLOID
        {
            get { return _UNITLOID; }
            set { _UNITLOID = value; }
        }
        public string UNITNAME
        {
            get { return _UNITNAME; }
            set { _UNITNAME = value; }
        }

        #endregion

        #region Clear Data

        /// <summary>
        /// Initialize data.
        /// </summary>
        private void ClearData()
        {
            _MMLOID = 0;
            _MMNAME = "";
            _NUTRIENTLOID = 0;
            _NUTRIENTNAME = "";
            _QTY = 0;
            _UNITLOID = 0;
            _UNITNAME = "";
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
        /// Gets the select statement for V_MATERIALNUTRIENT table.
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
        /// Returns an indication whether the record of V_MATERIALNUTRIENT by specified condition is retrieved successfully.
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
                        if (!Convert.IsDBNull(zRdr["MMLOID"])) _MMLOID = Convert.ToDouble(zRdr["MMLOID"]);
                        if (!Convert.IsDBNull(zRdr["MMNAME"])) _MMNAME = zRdr["MMNAME"].ToString();
                        if (!Convert.IsDBNull(zRdr["NUTRIENTLOID"])) _NUTRIENTLOID = Convert.ToDouble(zRdr["NUTRIENTLOID"]);
                        if (!Convert.IsDBNull(zRdr["NUTRIENTNAME"])) _NUTRIENTNAME = zRdr["NUTRIENTNAME"].ToString();
                        if (!Convert.IsDBNull(zRdr["QTY"])) _QTY = Convert.ToDouble(zRdr["QTY"]);
                        if (!Convert.IsDBNull(zRdr["UNITLOID"])) _UNITLOID = Convert.ToDouble(zRdr["UNITLOID"]);
                        if (!Convert.IsDBNull(zRdr["UNITNAME"])) _UNITNAME = zRdr["UNITNAME"].ToString();
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

        #region My Method

        public DataTable GetDataListByMaterialMaster(string material_master_loid, string orderStr)
        {
            string sql = "";
            sql = "SELECT * FROM V_MATERIALNUTRIENT WHERE MMLOID = " + material_master_loid;

            if (orderStr != "")
                sql += " ORDER BY " + orderStr;

            return DB.ExecuteTable(sql);
        }

        #endregion

    }
}