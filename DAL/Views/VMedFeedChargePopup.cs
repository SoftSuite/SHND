using System;
using System.Data;
using System.Data.OracleClient;
using DB = SHND.DAL.Utilities.OracleDB;
using SHND.Data.Common.Utilities;

namespace SHND.DAL.Views
{
    /// <summary>
    /// Represents a transaction for V_MEDFEEDCHARGE_POPUP view.
    /// [Created by 127.0.0.1 on August,18 2009]
    /// </summary>
    public class VMedFeedChargePopup
    {

        public VMedFeedChargePopup()
        {
        }

        #region Constant

        /// <summary>V_MEDFEEDCHARGE_POPUP</summary>
        private const string viewName = "V_MEDFEEDCHARGE_POPUP";

        #endregion

        #region Private Variables

        string _error = "";
        string _information = "";
        bool _OnDB = false;
        DateTime _ADMITDATE = new DateTime(1, 1, 1);
        string _AN = "";
        double _COST = 0;
        string _HN = "";
        double _LOID = 0;
        double _MATERIALMASTER = 0;
        string _MATERIALNAME = "";
        DateTime _ORDERDATE = new DateTime(1, 1, 1);
        string _PATIENTNAME = "";
        string _THNAME = "";
        double _UNIT = 0;
        double _WARD = 0;

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
        public DateTime ADMITDATE
        {
            get { return _ADMITDATE; }
            set { _ADMITDATE = value; }
        }
        public string AN
        {
            get { return _AN; }
            set { _AN = value; }
        }
        public double COST
        {
            get { return _COST; }
            set { _COST = value; }
        }
        public string HN
        {
            get { return _HN; }
            set { _HN = value; }
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
        public DateTime ORDERDATE
        {
            get { return _ORDERDATE; }
            set { _ORDERDATE = value; }
        }
        public string PATIENTNAME
        {
            get { return _PATIENTNAME; }
            set { _PATIENTNAME = value; }
        }
        public string THNAME
        {
            get { return _THNAME; }
            set { _THNAME = value; }
        }
        public double UNIT
        {
            get { return _UNIT; }
            set { _UNIT = value; }
        }
        public double WARD
        {
            get { return _WARD; }
            set { _WARD = value; }
        }

        #endregion

        #region Clear Data

        /// <summary>
        /// Initialize data.
        /// </summary>
        private void ClearData()
        {
            _ADMITDATE = new DateTime(1, 1, 1);
            _AN = "";
            _COST = 0;
            _HN = "";
            _LOID = 0;
            _MATERIALMASTER = 0;
            _MATERIALNAME = "";
            _ORDERDATE = new DateTime(1, 1, 1);
            _PATIENTNAME = "";
            _THNAME = "";
            _UNIT = 0;
            _WARD = 0;
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
        /// Gets the select statement for V_MEDFEEDCHARGE_POPUP table.
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
        /// Returns an indication whether the record of V_MEDFEEDCHARGE_POPUP by specified condition is retrieved successfully.
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
                        if (!Convert.IsDBNull(zRdr["ADMITDATE"])) _ADMITDATE = Convert.ToDateTime(zRdr["ADMITDATE"]);
                        if (!Convert.IsDBNull(zRdr["AN"])) _AN = zRdr["AN"].ToString();
                        if (!Convert.IsDBNull(zRdr["COST"])) _COST = Convert.ToDouble(zRdr["COST"]);
                        if (!Convert.IsDBNull(zRdr["HN"])) _HN = zRdr["HN"].ToString();
                        if (!Convert.IsDBNull(zRdr["LOID"])) _LOID = Convert.ToDouble(zRdr["LOID"]);
                        if (!Convert.IsDBNull(zRdr["MATERIALMASTER"])) _MATERIALMASTER = Convert.ToDouble(zRdr["MATERIALMASTER"]);
                        if (!Convert.IsDBNull(zRdr["MATERIALNAME"])) _MATERIALNAME = zRdr["MATERIALNAME"].ToString();
                        if (!Convert.IsDBNull(zRdr["ORDERDATE"])) _ORDERDATE = Convert.ToDateTime(zRdr["ORDERDATE"]);
                        if (!Convert.IsDBNull(zRdr["PATIENTNAME"])) _PATIENTNAME = zRdr["PATIENTNAME"].ToString();
                        if (!Convert.IsDBNull(zRdr["THNAME"])) _THNAME = zRdr["THNAME"].ToString();
                        if (!Convert.IsDBNull(zRdr["UNIT"])) _UNIT = Convert.ToDouble(zRdr["UNIT"]);
                        if (!Convert.IsDBNull(zRdr["WARD"])) _WARD = Convert.ToDouble(zRdr["WARD"]);
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

        #region My work 

        private string sql_rank
        {
            get
            {
                string sql = "SELECT CASE WHEN RANK() OVER(PARTITION BY ADMITDATE ORDER BY ADMITDATE,PATIENTNAME) = 1 THEN 1 ELSE 0 END RANK, ";
                sql += " NVL(A.TITLE,0) TITLESTR,A.* FROM " + viewName + " A ";
                return sql;
            }
        }

        public DataTable GetRankDataList(string whereClause, string orderBy, OracleTransaction trans)
        {
            DataTable dt = DB.ExecuteTable(sql_rank + (whereClause == "" ? "" : "WHERE " + whereClause + " ") + (orderBy == "" ? "" : "ORDER BY " + DB.SetSortString(orderBy)), trans);
            int index = 1;
            for (int i = 0; i < dt.Rows.Count; ++i)
            {
                if (Convert.ToDouble(dt.Rows[i]["RANK"]) == 1)
                {
                    dt.Rows[i]["RANK"] = index;
                    ++index;
                }
            }
            return dt;
        }

        public DataTable GetDataListByConditions(string cPATIENTNAME, string cHN, string cAN, string cAdmitDateFROM, string cAdmitDateTO, double cWARD, string exceptPateintList, string orderBy, OracleTransaction trans)
        {
            string whText = "";

            if (cWARD != 0) whText += (whText == "" ? "" : "AND ") + "WARD = " + DB.SetDouble(cWARD) + " ";
            if (cPATIENTNAME.Trim() != "") whText += (whText == "" ? "" : "AND ") + "UPPER(PATIENTNAME) LIKE UPPER(" + DB.SetString("%" + cPATIENTNAME.Trim() + "%") + ") ";
            if (cHN.Trim() != "") whText += (whText == "" ? "" : "AND ") + "HN LIKE " + DB.SetString("%" + cHN.Trim() + "%") + " ";
            if (cAN.Trim() != "") whText += (whText == "" ? "" : "AND ") + "AN LIKE " + DB.SetString("%" + cAN.Trim() + "%") + " ";

            if (cAdmitDateFROM.ToString() != "") whText += (whText == "" ? "" : "AND ") + "(TO_CHAR(ADMITDATE,'DD/MM/YYYY') >= '" + cAdmitDateFROM + "') ";
            if (cAdmitDateTO.ToString() != "") whText += (whText == "" ? "" : "AND ") + "(TO_CHAR(ADMITDATE,'DD/MM/YYYY') <= '" + cAdmitDateTO + "') ";
            if (exceptPateintList != "") whText += (whText.Trim() == "" ? "" : " AND ") + "LOID NOT IN (" + exceptPateintList + ") ";

            return GetRankDataList(whText, orderBy, trans);
        }

        #endregion
    }
}