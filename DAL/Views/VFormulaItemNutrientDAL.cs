using System;
using System.Data;
using System.Data.OracleClient;
using DB = SHND.DAL.Utilities.OracleDB;
using SHND.Data.Common.Utilities;

namespace SHND.DAL.Views
{
    /// <summary>
    /// Represents a transaction for V_FORMULAITEM_NUTRIENT view.
    /// [Created by 127.0.0.1 on January,15 2009]
    /// </summary>
    public class VFormulaItemNutrientDAL
    {

        public VFormulaItemNutrientDAL()
        {
        }

        #region Constant

        /// <summary>V_FORMULAITEM_NUTRIENT</summary>
        private const string viewName = "V_FORMULAITEM_NUTRIENT";

        #endregion

        #region Private Variables

        string _error = "";
        string _information = "";
        bool _OnDB = false;
        double _CARBOHYDRATE = 0;
        double _ENERGY = 0;
        double _FAT = 0;
        double _MATERIALMASTER = 0;
        string _MATERIALNAME = "";
        double _PROTEIN = 0;
        double _SODIUM = 0;
        double _UNIT = 0;
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
        public double CARBOHYDRATE
        {
            get { return _CARBOHYDRATE; }
            set { _CARBOHYDRATE = value; }
        }
        public double ENERGY
        {
            get { return _ENERGY; }
            set { _ENERGY = value; }
        }
        public double FAT
        {
            get { return _FAT; }
            set { _FAT = value; }
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
        public double PROTEIN
        {
            get { return _PROTEIN; }
            set { _PROTEIN = value; }
        }
        public double SODIUM
        {
            get { return _SODIUM; }
            set { _SODIUM = value; }
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

        #endregion

        #region Clear Data

        /// <summary>
        /// Initialize data.
        /// </summary>
        private void ClearData()
        {
            _CARBOHYDRATE = 0;
            _ENERGY = 0;
            _FAT = 0;
            _MATERIALMASTER = 0;
            _MATERIALNAME = "";
            _PROTEIN = 0;
            _SODIUM = 0;
            _UNIT = 0;
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

        public DataTable GetDataListByUnit(double cMaster,double cUnit, string orderBy, OracleTransaction trans)
        {
            return GetDataList("MATERIALMASTER = " + DB.SetDouble(cMaster) + " AND UNIT = " + DB.SetDouble(cUnit), orderBy, trans);
        }

        #endregion

        #region SQL Statements

        /// <summary>
        /// Gets the select statement for V_FORMULAITEM_NUTRIENT table.
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
        /// Returns an indication whether the record of V_FORMULAITEM_NUTRIENT by specified condition is retrieved successfully.
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
                        if (!Convert.IsDBNull(zRdr["CARBOHYDRATE"])) _CARBOHYDRATE = Convert.ToDouble(zRdr["CARBOHYDRATE"]);
                        if (!Convert.IsDBNull(zRdr["ENERGY"])) _ENERGY = Convert.ToDouble(zRdr["ENERGY"]);
                        if (!Convert.IsDBNull(zRdr["FAT"])) _FAT = Convert.ToDouble(zRdr["FAT"]);
                        if (!Convert.IsDBNull(zRdr["MATERIALMASTER"])) _MATERIALMASTER = Convert.ToDouble(zRdr["MATERIALMASTER"]);
                        if (!Convert.IsDBNull(zRdr["MATERIALNAME"])) _MATERIALNAME = zRdr["MATERIALNAME"].ToString();
                        if (!Convert.IsDBNull(zRdr["PROTEIN"])) _PROTEIN = Convert.ToDouble(zRdr["PROTEIN"]);
                        if (!Convert.IsDBNull(zRdr["SODIUM"])) _SODIUM = Convert.ToDouble(zRdr["SODIUM"]);
                        if (!Convert.IsDBNull(zRdr["UNIT"])) _UNIT = Convert.ToDouble(zRdr["UNIT"]);
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

    }
}