using System;
using System.Data;
using System.Data.OracleClient;
using DB = SHND.DAL.Utilities.OracleDB;
using SHND.Data.Common.Utilities;

namespace SHND.DAL.Views
{
    /// <summary>
    /// Represents a transaction for V_PREPAREWEIGHTAFTERITEM view.
    /// [Created by 10.10.10.10 on May,14 2009]
    /// </summary>
    public class VPrepareWeightAfterItemDAL
    {

        public VPrepareWeightAfterItemDAL()
        {
        }

        #region Constant

        /// <summary>V_PREPAREWEIGHTAFTERITEM</summary>
        private const string viewName = "V_PREPAREWEIGHTAFTERITEM";

        #endregion

        #region Private Variables

        string _error = "";
        string _information = "";
        bool _OnDB = false;
        double _DIFFWEIGHT = 0;
        double _LOID = 0;
        string _MATERIALCODE = "";
        double _MATERIALMASTER = 0;
        string _MATERIALNAME = "";
        double _PREPAREWEIGHTAFTER = 0;
        string _PREPAREWEIGHTAFTERCODE = "";
        double _STDWEIGHTAFTER = 0;
        double _STDWEIGHTBEFORE = 0;
        double _UNITLOID = 0;
        string _UNITNAME = "";
        double _USEWEIGHTAFTER = 0;
        double _USEWEIGHTBEFORE = 0;

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
        public double DIFFWEIGHT
        {
            get { return _DIFFWEIGHT; }
            set { _DIFFWEIGHT = value; }
        }
        public double LOID
        {
            get { return _LOID; }
            set { _LOID = value; }
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
        public double PREPAREWEIGHTAFTER
        {
            get { return _PREPAREWEIGHTAFTER; }
            set { _PREPAREWEIGHTAFTER = value; }
        }
        public string PREPAREWEIGHTAFTERCODE
        {
            get { return _PREPAREWEIGHTAFTERCODE; }
            set { _PREPAREWEIGHTAFTERCODE = value; }
        }
        public double STDWEIGHTAFTER
        {
            get { return _STDWEIGHTAFTER; }
            set { _STDWEIGHTAFTER = value; }
        }
        public double STDWEIGHTBEFORE
        {
            get { return _STDWEIGHTBEFORE; }
            set { _STDWEIGHTBEFORE = value; }
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
        public double USEWEIGHTAFTER
        {
            get { return _USEWEIGHTAFTER; }
            set { _USEWEIGHTAFTER = value; }
        }
        public double USEWEIGHTBEFORE
        {
            get { return _USEWEIGHTBEFORE; }
            set { _USEWEIGHTBEFORE = value; }
        }

        #endregion

        #region Clear Data

        /// <summary>
        /// Initialize data.
        /// </summary>
        private void ClearData()
        {
            _DIFFWEIGHT = 0;
            _LOID = 0;
            _MATERIALCODE = "";
            _MATERIALMASTER = 0;
            _MATERIALNAME = "";
            _PREPAREWEIGHTAFTER = 0;
            _PREPAREWEIGHTAFTERCODE = "";
            _STDWEIGHTAFTER = 0;
            _STDWEIGHTBEFORE = 0;
            _UNITLOID = 0;
            _UNITNAME = "";
            _USEWEIGHTAFTER = 0;
            _USEWEIGHTBEFORE = 0;
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
        /// Gets the select statement for V_PREPAREWEIGHTAFTERITEM table.
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
        /// Returns an indication whether the record of V_PREPAREWEIGHTAFTERITEM by specified condition is retrieved successfully.
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
                        if (!Convert.IsDBNull(zRdr["DIFFWEIGHT"])) _DIFFWEIGHT = Convert.ToDouble(zRdr["DIFFWEIGHT"]);
                        if (!Convert.IsDBNull(zRdr["LOID"])) _LOID = Convert.ToDouble(zRdr["LOID"]);
                        if (!Convert.IsDBNull(zRdr["MATERIALCODE"])) _MATERIALCODE = zRdr["MATERIALCODE"].ToString();
                        if (!Convert.IsDBNull(zRdr["MATERIALMASTER"])) _MATERIALMASTER = Convert.ToDouble(zRdr["MATERIALMASTER"]);
                        if (!Convert.IsDBNull(zRdr["MATERIALNAME"])) _MATERIALNAME = zRdr["MATERIALNAME"].ToString();
                        if (!Convert.IsDBNull(zRdr["PREPAREWEIGHTAFTER"])) _PREPAREWEIGHTAFTER = Convert.ToDouble(zRdr["PREPAREWEIGHTAFTER"]);
                        if (!Convert.IsDBNull(zRdr["PREPAREWEIGHTAFTERCODE"])) _PREPAREWEIGHTAFTERCODE = zRdr["PREPAREWEIGHTAFTERCODE"].ToString();
                        if (!Convert.IsDBNull(zRdr["STDWEIGHTAFTER"])) _STDWEIGHTAFTER = Convert.ToDouble(zRdr["STDWEIGHTAFTER"]);
                        if (!Convert.IsDBNull(zRdr["STDWEIGHTBEFORE"])) _STDWEIGHTBEFORE = Convert.ToDouble(zRdr["STDWEIGHTBEFORE"]);
                        if (!Convert.IsDBNull(zRdr["UNITLOID"])) _UNITLOID = Convert.ToDouble(zRdr["UNITLOID"]);
                        if (!Convert.IsDBNull(zRdr["UNITNAME"])) _UNITNAME = zRdr["UNITNAME"].ToString();
                        if (!Convert.IsDBNull(zRdr["USEWEIGHTAFTER"])) _USEWEIGHTAFTER = Convert.ToDouble(zRdr["USEWEIGHTAFTER"]);
                        if (!Convert.IsDBNull(zRdr["USEWEIGHTBEFORE"])) _USEWEIGHTBEFORE = Convert.ToDouble(zRdr["USEWEIGHTBEFORE"]);
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