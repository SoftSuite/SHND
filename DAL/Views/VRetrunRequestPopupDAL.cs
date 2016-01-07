using System;
using System.Data;
using System.Data.OracleClient;
using DB = SHND.DAL.Utilities.OracleDB;
using SHND.Data.Common.Utilities;

namespace SHND.DAL.Views
{
    /// <summary>
    /// Represents a transaction for V_RETURNREQUEST_POPUP view.
    /// [Created by 127.0.0.1 on March,3 2009]
    /// </summary>
    public class VRetrunRequestPopupDAL
    {

        public VRetrunRequestPopupDAL()
        {
        }

        #region Constant

        /// <summary>V_RETURNREQUEST_POPUP</summary>
        private const string viewName = "V_RETURNREQUEST_POPUP";

        #endregion

        #region Private Variables

        string _error = "";
        string _information = "";
        bool _OnDB = false;
        double _DIVISION = 0;
        string _MATERIALCODE = "";
        double _MATERIALMASTER = 0;
        string _MATERIALNAME = "";
        double _QTY = 0;
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
        public double DIVISION
        {
            get { return _DIVISION; }
            set { _DIVISION = value; }
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
        public double QTY
        {
            get { return _QTY; }
            set { _QTY = value; }
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
            _DIVISION = 0;
            _MATERIALCODE = "";
            _MATERIALMASTER = 0;
            _MATERIALNAME = "";
            _QTY = 0;
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

        #endregion

        #region SQL Statements

        /// <summary>
        /// Gets the select statement for V_RETURNREQUEST_POPUP table.
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
        /// Returns an indication whether the record of V_RETURNREQUEST_POPUP by specified condition is retrieved successfully.
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
                            if (!Convert.IsDBNull(zRdr["DIVISION"])) _DIVISION = Convert.ToDouble(zRdr["DIVISION"]);
                            if (!Convert.IsDBNull(zRdr["MATERIALCODE"])) _MATERIALCODE = zRdr["MATERIALCODE"].ToString();
                            if (!Convert.IsDBNull(zRdr["MATERIALMASTER"])) _MATERIALMASTER = Convert.ToDouble(zRdr["MATERIALMASTER"]);
                            if (!Convert.IsDBNull(zRdr["MATERIALNAME"])) _MATERIALNAME = zRdr["MATERIALNAME"].ToString();
                            if (!Convert.IsDBNull(zRdr["QTY"])) _QTY = Convert.ToDouble(zRdr["QTY"]);
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

    


        public DataTable GetDataListByConditions(double division, double warehouse, string cMATERIALNAME, string exceptMaterialMasterList, string orderBy, OracleTransaction trans)
        {
            string whText = "QTY>0 ";

            if (division != 0) whText += (whText == "" ? "" : "AND ") + "DIVISION = " + DB.SetDouble(division) + " ";
            if (warehouse != 0) whText += (whText == "" ? "" : "AND ") + "WAREHOUSE = " + DB.SetDouble(warehouse) + " ";
            if (cMATERIALNAME.Trim() != "") whText += (whText == "" ? "" : "AND ") + "UPPER(MATERIALNAME) LIKE " + DB.SetString("%" + cMATERIALNAME.Trim().ToUpper() + "%") + " ";
            if (exceptMaterialMasterList != "") whText += (whText.Trim() == "" ? "" : " AND ") + "MATERIALMASTER NOT IN (" + exceptMaterialMasterList + ") ";
            return GetDataList(whText, orderBy, trans);
        }

        public DataTable GetDataListByDIVISION(double cDIVISION, string orderBy, OracleTransaction trans)
        {
            return GetDataList("DIVISION = " + DB.SetDouble(cDIVISION) + " ", orderBy, trans);
        }
    }
}