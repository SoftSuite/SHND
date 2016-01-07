using System;
using System.Data;
using System.Data.OracleClient;
using DB = SHND.DAL.Utilities.OracleDB;
using SHND.Data.Common.Utilities;

namespace SHND.DAL.Views
{
    /// <summary>
    /// Represents a transaction for V_REPAIRREQUEST view.
    /// [Created by 127.0.0.1 on Febuary,11 2009]
    /// </summary>
    public class VRepairrequestDAL
    {

        public VRepairrequestDAL()
        {
        }

        #region Constant

        /// <summary>V_REPAIRREQUEST</summary>
        private const string viewName = "V_REPAIRREQUEST";

        #endregion

        #region Private Variables

        string _error = "";
        string _information = "";
        bool _OnDB = false;
        string _LOTNO = "";
        string _MATERIALCODE = "";
        double _MATERIALGROUP = 0;
        string _MATERIALNAME = "";
        double _SRLOID = 0;
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
        public string LOTNO
        {
            get { return _LOTNO; }
            set { _LOTNO = value; }
        }
        public string MATERIALCODE
        {
            get { return _MATERIALCODE; }
            set { _MATERIALCODE = value; }
        }
        public double MATERIALGROUP
        {
            get { return _MATERIALGROUP; }
            set { _MATERIALGROUP = value; }
        }
        public string MATERIALNAME
        {
            get { return _MATERIALNAME; }
            set { _MATERIALNAME = value; }
        }
        public double SRLOID
        {
            get { return _SRLOID; }
            set { _SRLOID = value; }
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
            _LOTNO = "";
            _MATERIALCODE = "";
            _MATERIALGROUP = 0;
            _MATERIALNAME = "";
            _SRLOID = 0;
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
        public DataTable GetDataListByRepair(double cLOID, string orderBy, OracleTransaction trans)
        {
            return GetDataList("SRLOID = " + DB.SetDouble(cLOID), orderBy, trans);
        }
        #endregion

        #region SQL Statements

        /// <summary>
        /// Gets the select statement for V_REPAIRREQUEST table.
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
        /// Returns an indication whether the record of V_REPAIRREQUEST by specified condition is retrieved successfully.
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
                        if (!Convert.IsDBNull(zRdr["LOTNO"])) _LOTNO = zRdr["LOTNO"].ToString();
                        if (!Convert.IsDBNull(zRdr["MATERIALCODE"])) _MATERIALCODE = zRdr["MATERIALCODE"].ToString();
                        if (!Convert.IsDBNull(zRdr["MATERIALGROUP"])) _MATERIALGROUP = Convert.ToDouble(zRdr["MATERIALGROUP"]);
                        if (!Convert.IsDBNull(zRdr["MATERIALNAME"])) _MATERIALNAME = zRdr["MATERIALNAME"].ToString();
                        if (!Convert.IsDBNull(zRdr["SRLOID"])) _SRLOID = Convert.ToDouble(zRdr["SRLOID"]);
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

        public DataTable GetDataListByConditions(string cMaterialName, double cMeterailgroup, string exceptionList, string orderBy, OracleTransaction trans)
        {
            string whText = "";
            if (cMaterialName.Trim() != "") whText += (whText == "" ? "" : "AND ") + "UPPER(MATERIALNAME) LIKE " + DB.SetString("%" + cMaterialName.Trim().ToUpper() + "%") + " ";
            if (cMeterailgroup != 0) whText += (whText == "" ? "" : "AND ") + "MATERIALGROUP = " + DB.SetDouble(cMeterailgroup) + " ";
            if (exceptionList != "") whText += (whText == "" ? "" : "AND ") + "LOID NOT IN (" + exceptionList + ") ";
            return GetDataList(whText, orderBy, trans);
        }
    }
}
