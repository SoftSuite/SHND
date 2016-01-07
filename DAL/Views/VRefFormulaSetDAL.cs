using System;
using System.Data;
using System.Data.OracleClient;
using DB = SHND.DAL.Utilities.OracleDB;
using SHND.Data.Common.Utilities;

namespace SHND.DAL.Views
{
    /// <summary>
    /// Represents a transaction for V_REFFORMULASET view.
    /// [Created by 127.0.0.1 on January,12 2009]
    /// </summary>
    public class VRefFormulaSetDAL
    {

        public VRefFormulaSetDAL()
        {
        }

        #region Constant

        /// <summary>V_REFFORMULASET</summary>
        private const string viewName = "V_REFFORMULASET";

        #endregion

        #region Private Variables

        string _error = "";
        string _information = "";
        bool _OnDB = false;
        double _CARBOHYDRATE = 0;
        double _ENERGY = 0;
        double _FAT = 0;
        double _FORMULASET = 0;
        double _LOID = 0;
        double _MATERIALMASTER = 0;
        string _MATERIALNAME = "";
        string _PREPARENAME = "";
        double _PROTEIN = 0;
        double _REFFORMULA = 0;
        string _REFORMULASETNAME = "";
        double _SODIUM = 0;
        double _WEIGHT = 0;
        double _WEIGHTRAW = 0;
        double _WEIGHTRIPE = 0;

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
        public double FORMULASET
        {
            get { return _FORMULASET; }
            set { _FORMULASET = value; }
        }
        public double LOID
        {
            get { return _LOID; }
            set { _LOID = value; }
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
        public string PREPARENAME
        {
            get { return _PREPARENAME; }
            set { _PREPARENAME = value; }
        }
        public double PROTEIN
        {
            get { return _PROTEIN; }
            set { _PROTEIN = value; }
        }
        public double REFFORMULA
        {
            get { return _REFFORMULA; }
            set { _REFFORMULA = value; }
        }
        public string REFORMULASETNAME
        {
            get { return _REFORMULASETNAME; }
            set { _REFORMULASETNAME = value; }
        }
        public double SODIUM
        {
            get { return _SODIUM; }
            set { _SODIUM = value; }
        }
        public double WEIGHT
        {
            get { return _WEIGHT; }
            set { _WEIGHT = value; }
        }
        public double WEIGHTRAW
        {
            get { return _WEIGHTRAW; }
            set { _WEIGHTRAW = value; }
        }
        public double WEIGHTRIPE
        {
            get { return _WEIGHTRIPE; }
            set { _WEIGHTRIPE = value; }
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
            _FORMULASET = 0;
            _LOID = 0;
            _MATERIALMASTER = 0;
            _MATERIALNAME = "";
            _PREPARENAME = "";
            _PROTEIN = 0;
            _REFFORMULA = 0;
            _REFORMULASETNAME = "";
            _SODIUM = 0;
            _WEIGHT = 0;
            _WEIGHTRAW = 0;
            _WEIGHTRIPE = 0;
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
        /// Gets the select statement for V_REFFORMULASET table.
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
        /// Returns an indication whether the record of V_REFFORMULASET by specified condition is retrieved successfully.
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
                        if (!Convert.IsDBNull(zRdr["FORMULASET"])) _FORMULASET = Convert.ToDouble(zRdr["FORMULASET"]);
                        if (!Convert.IsDBNull(zRdr["LOID"])) _LOID = Convert.ToDouble(zRdr["LOID"]);
                        if (!Convert.IsDBNull(zRdr["MATERIALMASTER"])) _MATERIALMASTER = Convert.ToDouble(zRdr["MATERIALMASTER"]);
                        if (!Convert.IsDBNull(zRdr["MATERIALNAME"])) _MATERIALNAME = zRdr["MATERIALNAME"].ToString();
                        if (!Convert.IsDBNull(zRdr["PREPARENAME"])) _PREPARENAME = zRdr["PREPARENAME"].ToString();
                        if (!Convert.IsDBNull(zRdr["PROTEIN"])) _PROTEIN = Convert.ToDouble(zRdr["PROTEIN"]);
                        if (!Convert.IsDBNull(zRdr["REFFORMULA"])) _REFFORMULA = Convert.ToDouble(zRdr["REFFORMULA"]);
                        if (!Convert.IsDBNull(zRdr["REFORMULASETNAME"])) _REFORMULASETNAME = zRdr["REFORMULASETNAME"].ToString();
                        if (!Convert.IsDBNull(zRdr["SODIUM"])) _SODIUM = Convert.ToDouble(zRdr["SODIUM"]);
                        if (!Convert.IsDBNull(zRdr["WEIGHT"])) _WEIGHT = Convert.ToDouble(zRdr["WEIGHT"]);
                        if (!Convert.IsDBNull(zRdr["WEIGHTRAW"])) _WEIGHTRAW = Convert.ToDouble(zRdr["WEIGHTRAW"]);
                        if (!Convert.IsDBNull(zRdr["WEIGHTRIPE"])) _WEIGHTRIPE = Convert.ToDouble(zRdr["WEIGHTRIPE"]);
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

        public DataTable GetDistinctRefFormulaSetDataList(double cFORMULASET, OracleTransaction trans)
        {
            return DB.ExecuteTable("SELECT DISTINCT FORMULASET, REFFORMULA, REFORMULASETNAME FROM " + ViewName + " WHERE FORMULASET = " + DB.SetDouble(cFORMULASET) + " ORDER BY " + DB.SetSortString("REFORMULASETNAME"), trans);
        }

        public DataTable GetDataListByCoindition(double cFORMULASET, double cREFFORMULA, OracleTransaction trans)
        {
            return GetDataList("FORMULASET = " + DB.SetDouble(cFORMULASET) + " AND REFFORMULA = " + DB.SetDouble(cREFFORMULA) + " ", "MATERIALNAME", trans);
        }

        public DataTable GetDataListByFormulaSet(double cFORMULASET, OracleTransaction trans)
        {
            return GetDataList("FORMULASET = " + DB.SetDouble(cFORMULASET) + " ", "MATERIALNAME", trans);
        }

    }
}