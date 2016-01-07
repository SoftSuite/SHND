using System;
using System.Data;
using System.Data.OracleClient;
using DB = SHND.DAL.Utilities.OracleDB;
using SHND.Data.Common.Utilities;

namespace SHND.DAL.Views
{
    /// <summary>
    /// Represents a transaction for V_ADMITPATIENT view.
    /// [Created by 127.0.0.1 on May,11 2009]
    /// </summary>
    public class VAdmitPatientDAL
    {

        public VAdmitPatientDAL()
        {
        }

        #region Constant

        /// <summary>V_ADMITPATIENT</summary>
        private const string viewName = "V_ADMITPATIENT";

        #endregion

        #region Private Variables

        string _error = "";
        string _information = "";
        bool _OnDB = false;
        DateTime _ADMITDATE = new DateTime(1, 1, 1);
        string _AN = "";
        string _BEDNO = "";
        DateTime _BIRTHDATE = new DateTime(1, 1, 1);
        string _CREATEBY = "";
        DateTime _CREATEON = new DateTime(1, 1, 1);
        string _DIAGNOSIS = "";
        string _DISEASE = "";
        string _DRUGALLERGIC = "";
        string _FOODALLERGIC = "";
        double _HEIGHT = 0;
        string _HN = "";
        double _LOID = 0;
        string _PATIENTNAME = "";
        string _ROOMNO = "";
        double _TITLE = 0;
        string _UPDATEBY = "";
        DateTime _UPDATEON = new DateTime(1, 1, 1);
        string _VN = "";
        double _WARD = 0;
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
        public string BEDNO
        {
            get { return _BEDNO; }
            set { _BEDNO = value; }
        }
        public DateTime BIRTHDATE
        {
            get { return _BIRTHDATE; }
            set { _BIRTHDATE = value; }
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
        public string DIAGNOSIS
        {
            get { return _DIAGNOSIS; }
            set { _DIAGNOSIS = value; }
        }
        public string DISEASE
        {
            get { return _DISEASE; }
            set { _DISEASE = value; }
        }
        public string DRUGALLERGIC
        {
            get { return _DRUGALLERGIC; }
            set { _DRUGALLERGIC = value; }
        }
        public string FOODALLERGIC
        {
            get { return _FOODALLERGIC; }
            set { _FOODALLERGIC = value; }
        }
        public double HEIGHT
        {
            get { return _HEIGHT; }
            set { _HEIGHT = value; }
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
        public string PATIENTNAME
        {
            get { return _PATIENTNAME; }
            set { _PATIENTNAME = value; }
        }
        public string ROOMNO
        {
            get { return _ROOMNO; }
            set { _ROOMNO = value; }
        }
        public double TITLE
        {
            get { return _TITLE; }
            set { _TITLE = value; }
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
        public string VN
        {
            get { return _VN; }
            set { _VN = value; }
        }
        public double WARD
        {
            get { return _WARD; }
            set { _WARD = value; }
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
            _ADMITDATE = new DateTime(1, 1, 1);
            _AN = "";
            _BEDNO = "";
            _BIRTHDATE = new DateTime(1, 1, 1);
            _CREATEBY = "";
            _CREATEON = new DateTime(1, 1, 1);
            _DIAGNOSIS = "";
            _DISEASE = "";
            _DRUGALLERGIC = "";
            _FOODALLERGIC = "";
            _HEIGHT = 0;
            _HN = "";
            _LOID = 0;
            _PATIENTNAME = "";
            _ROOMNO = "";
            _TITLE = 0;
            _UPDATEBY = "";
            _UPDATEON = new DateTime(1, 1, 1);
            _VN = "";
            _WARD = 0;
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
        /// Gets the select statement for V_ADMITPATIENT table.
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
        /// Returns an indication whether the record of V_ADMITPATIENT by specified condition is retrieved successfully.
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
                        if (!Convert.IsDBNull(zRdr["BEDNO"])) _BEDNO = zRdr["BEDNO"].ToString();
                        if (!Convert.IsDBNull(zRdr["BIRTHDATE"])) _BIRTHDATE = Convert.ToDateTime(zRdr["BIRTHDATE"]);
                        if (!Convert.IsDBNull(zRdr["CREATEBY"])) _CREATEBY = zRdr["CREATEBY"].ToString();
                        if (!Convert.IsDBNull(zRdr["CREATEON"])) _CREATEON = Convert.ToDateTime(zRdr["CREATEON"]);
                        if (!Convert.IsDBNull(zRdr["DIAGNOSIS"])) _DIAGNOSIS = zRdr["DIAGNOSIS"].ToString();
                        if (!Convert.IsDBNull(zRdr["DISEASE"])) _DISEASE = zRdr["DISEASE"].ToString();
                        if (!Convert.IsDBNull(zRdr["DRUGALLERGIC"])) _DRUGALLERGIC = zRdr["DRUGALLERGIC"].ToString();
                        if (!Convert.IsDBNull(zRdr["FOODALLERGIC"])) _FOODALLERGIC = zRdr["FOODALLERGIC"].ToString();
                        if (!Convert.IsDBNull(zRdr["HEIGHT"])) _HEIGHT = Convert.ToDouble(zRdr["HEIGHT"]);
                        if (!Convert.IsDBNull(zRdr["HN"])) _HN = zRdr["HN"].ToString();
                        if (!Convert.IsDBNull(zRdr["LOID"])) _LOID = Convert.ToDouble(zRdr["LOID"]);
                        if (!Convert.IsDBNull(zRdr["PATIENTNAME"])) _PATIENTNAME = zRdr["PATIENTNAME"].ToString();
                        if (!Convert.IsDBNull(zRdr["ROOMNO"])) _ROOMNO = zRdr["ROOMNO"].ToString();
                        if (!Convert.IsDBNull(zRdr["TITLE"])) _TITLE = Convert.ToDouble(zRdr["TITLE"]);
                        if (!Convert.IsDBNull(zRdr["UPDATEBY"])) _UPDATEBY = zRdr["UPDATEBY"].ToString();
                        if (!Convert.IsDBNull(zRdr["UPDATEON"])) _UPDATEON = Convert.ToDateTime(zRdr["UPDATEON"]);
                        if (!Convert.IsDBNull(zRdr["VN"])) _VN = zRdr["VN"].ToString();
                        if (!Convert.IsDBNull(zRdr["WARD"])) _WARD = Convert.ToDouble(zRdr["WARD"]);
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


        #region My work Nang

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