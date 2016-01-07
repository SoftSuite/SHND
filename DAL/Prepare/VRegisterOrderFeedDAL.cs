using System;
using System.Data;
using System.Data.OracleClient;
using DB = SHND.DAL.Utilities.OracleDB;
using SHND.Data.Common.Utilities;

namespace SHND.DAL.Prepare
{
    /// <summary>
    /// Represents a transaction for V_TEMP_REGISTERORDERSET view.
    /// [Created by 127.0.0.1 on April,3 2009]
    /// </summary>
    public class VRegisterOrderFeedDAL
    {

        public VRegisterOrderFeedDAL()
        {
        }

        #region Constant

        /// <summary>V_ORDERFEED_WAIT_REGISTER</summary>
        private const string viewName = "V_ORDERFEED_WAIT_REGISTER";

        #endregion

        #region Private Variables

        string _error = "";
        string _information = "";
        bool _OnDB = false;
        string _ABSTAIN = "";
        double _ADMITPATIENT = 0;
        string _AGE = "";
        string _AN = "";
        string _BEDNO = "";
        DateTime _BIRTHDATE = new DateTime(1, 1, 1);
        string _BMI = "";
        string _CONTROL = "";
        string _DESCRIPTIONS = "";
        string _FEEDCATEGORY = "";
        string _FEEDCATEGORYNAME = "";
        string _FOODNAME = "";
        double _FOODTYPE = 0;
        string _FOODTYPENAME = "";
        string _FORMULAFEDDNAME = "";
        double _HEIGHT = 0;
        string _HN = "";
        string _INCREASE = "";
        string _LIMIT = "";
        string _MATERIALNAME = "";
        DateTime _MEDENDDATE = new DateTime(1, 1, 1);
        DateTime _MEDFIRSTDATE = new DateTime(1, 1, 1);
        DateTime _MEDORDERDATE = new DateTime(1, 1, 1);
        string _MEDSTATUS = "";
        string _NEED = "";
        DateTime _NONENDDATE = new DateTime(1, 1, 1);
        DateTime _NONFIRSTDATE = new DateTime(1, 1, 1);
        DateTime _NONORDERDATE = new DateTime(1, 1, 1);
        string _NONSTATUS = "";
        double _ORDERMEDICALFEED = 0;
        double _ORDERNONMEDICAL = 0;
        string _PATIENTNAME = "";
        string _QTY = "";
        string _REMARKS = "";
        string _ROOMNO = "";
        string _STATUS = "";
        string _STATUSNAME = "";
        string _VN = "";
        double _WARD = 0;
        string _WARDNAME = "";
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
        public string ABSTAIN
        {
            get { return _ABSTAIN; }
            set { _ABSTAIN = value; }
        }
        public double ADMITPATIENT
        {
            get { return _ADMITPATIENT; }
            set { _ADMITPATIENT = value; }
        }
        public string AGE
        {
            get { return _AGE; }
            set { _AGE = value; }
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
        public string BMI
        {
            get { return _BMI; }
            set { _BMI = value; }
        }
        public string CONTROL
        {
            get { return _CONTROL; }
            set { _CONTROL = value; }
        }
        public string DESCRIPTIONS
        {
            get { return _DESCRIPTIONS; }
            set { _DESCRIPTIONS = value; }
        }
        public string FEEDCATEGORY
        {
            get { return _FEEDCATEGORY; }
            set { _FEEDCATEGORY = value; }
        }
        public string FEEDCATEGORYNAME
        {
            get { return _FEEDCATEGORYNAME; }
            set { _FEEDCATEGORYNAME = value; }
        }
        public string FOODNAME
        {
            get { return _FOODNAME; }
            set { _FOODNAME = value; }
        }
        public double FOODTYPE
        {
            get { return _FOODTYPE; }
            set { _FOODTYPE = value; }
        }
        public string FOODTYPENAME
        {
            get { return _FOODTYPENAME; }
            set { _FOODTYPENAME = value; }
        }
        public string FORMULAFEDDNAME
        {
            get { return _FORMULAFEDDNAME; }
            set { _FORMULAFEDDNAME = value; }
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
        public string INCREASE
        {
            get { return _INCREASE; }
            set { _INCREASE = value; }
        }
        public string LIMIT
        {
            get { return _LIMIT; }
            set { _LIMIT = value; }
        }
        public string MATERIALNAME
        {
            get { return _MATERIALNAME; }
            set { _MATERIALNAME = value; }
        }
        public DateTime MEDENDDATE
        {
            get { return _MEDENDDATE; }
            set { _MEDENDDATE = value; }
        }
        public DateTime MEDFIRSTDATE
        {
            get { return _MEDFIRSTDATE; }
            set { _MEDFIRSTDATE = value; }
        }
        public DateTime MEDORDERDATE
        {
            get { return _MEDORDERDATE; }
            set { _MEDORDERDATE = value; }
        }
        public string MEDSTATUS
        {
            get { return _MEDSTATUS; }
            set { _MEDSTATUS = value; }
        }
        public string NEED
        {
            get { return _NEED; }
            set { _NEED = value; }
        }
        public DateTime NONENDDATE
        {
            get { return _NONENDDATE; }
            set { _NONENDDATE = value; }
        }
        public DateTime NONFIRSTDATE
        {
            get { return _NONFIRSTDATE; }
            set { _NONFIRSTDATE = value; }
        }
        public DateTime NONORDERDATE
        {
            get { return _NONORDERDATE; }
            set { _NONORDERDATE = value; }
        }
        public string NONSTATUS
        {
            get { return _NONSTATUS; }
            set { _NONSTATUS = value; }
        }
        public double ORDERMEDICALFEED
        {
            get { return _ORDERMEDICALFEED; }
            set { _ORDERMEDICALFEED = value; }
        }
        public double ORDERNONMEDICAL
        {
            get { return _ORDERNONMEDICAL; }
            set { _ORDERNONMEDICAL = value; }
        }
        public string PATIENTNAME
        {
            get { return _PATIENTNAME; }
            set { _PATIENTNAME = value; }
        }
        public string QTY
        {
            get { return _QTY; }
            set { _QTY = value; }
        }
        public string REMARKS
        {
            get { return _REMARKS; }
            set { _REMARKS = value; }
        }
        public string ROOMNO
        {
            get { return _ROOMNO; }
            set { _ROOMNO = value; }
        }
        public string STATUS
        {
            get { return _STATUS; }
            set { _STATUS = value; }
        }
        public string STATUSNAME
        {
            get { return _STATUSNAME; }
            set { _STATUSNAME = value; }
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
        public string WARDNAME
        {
            get { return _WARDNAME; }
            set { _WARDNAME = value; }
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
            _ABSTAIN = "";
            _ADMITPATIENT = 0;
            _AGE = "";
            _AN = "";
            _BEDNO = "";
            _BIRTHDATE = new DateTime(1, 1, 1);
            _BMI = "";
            _CONTROL = "";
            _DESCRIPTIONS = "";
            _FEEDCATEGORY = "";
            _FEEDCATEGORYNAME = "";
            _FOODNAME = "";
            _FOODTYPE = 0;
            _FOODTYPENAME = "";
            _FORMULAFEDDNAME = "";
            _HEIGHT = 0;
            _HN = "";
            _INCREASE = "";
            _LIMIT = "";
            _MATERIALNAME = "";
            _MEDENDDATE = new DateTime(1, 1, 1);
            _MEDFIRSTDATE = new DateTime(1, 1, 1);
            _MEDORDERDATE = new DateTime(1, 1, 1);
            _MEDSTATUS = "";
            _NEED = "";
            _NONENDDATE = new DateTime(1, 1, 1);
            _NONFIRSTDATE = new DateTime(1, 1, 1);
            _NONORDERDATE = new DateTime(1, 1, 1);
            _NONSTATUS = "";
            _ORDERMEDICALFEED = 0;
            _ORDERNONMEDICAL = 0;
            _PATIENTNAME = "";
            _QTY = "";
            _REMARKS = "";
            _ROOMNO = "";
            _STATUS = "";
            _STATUSNAME = "";
            _VN = "";
            _WARD = 0;
            _WARDNAME = "";
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
            DataTable dt = DB.ExecuteTable(sql_select + (whereClause == "" ? "" : "WHERE " + whereClause + " ") + (orderBy == "" ? "" : "ORDER BY " + DB.SetSortString(orderBy)), trans);
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

        #endregion

        #region SQL Statements

        /// <summary>
        /// Gets the select statement for V_TEMP_REGISTERORDERSET table.
        /// </summary>
        private string sql_select
        {
            get
            {
                string sql = "SELECT CASE WHEN RANK() OVER(PARTITION BY ADMITPATIENT ORDER BY PATIENTNAME, ORDERMEDICALFEED, ORDERNONMEDICAL) = 1 THEN 1 ELSE 0 END RANK, A.* FROM " + viewName + " A ";
                return sql;
            }
        }

        #endregion

        #region Private Methods

        /// <summary>
        /// Returns an indication whether the record of V_ORDERFEED_WAIT_REGISTER by specified condition is retrieved successfully.
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
                        if (!Convert.IsDBNull(zRdr["ABSTAIN"])) _ABSTAIN = zRdr["ABSTAIN"].ToString();
                        if (!Convert.IsDBNull(zRdr["ADMITPATIENT"])) _ADMITPATIENT = Convert.ToDouble(zRdr["ADMITPATIENT"]);
                        if (!Convert.IsDBNull(zRdr["AGE"])) _AGE = zRdr["AGE"].ToString();
                        if (!Convert.IsDBNull(zRdr["AN"])) _AN = zRdr["AN"].ToString();
                        if (!Convert.IsDBNull(zRdr["BEDNO"])) _BEDNO = zRdr["BEDNO"].ToString();
                        if (!Convert.IsDBNull(zRdr["BIRTHDATE"])) _BIRTHDATE = Convert.ToDateTime(zRdr["BIRTHDATE"]);
                        if (!Convert.IsDBNull(zRdr["BMI"])) _BMI = zRdr["BMI"].ToString();
                        if (!Convert.IsDBNull(zRdr["CONTROL"])) _CONTROL = zRdr["CONTROL"].ToString();
                        if (!Convert.IsDBNull(zRdr["DESCRIPTIONS"])) _DESCRIPTIONS = zRdr["DESCRIPTIONS"].ToString();
                        if (!Convert.IsDBNull(zRdr["FEEDCATEGORY"])) _FEEDCATEGORY = zRdr["FEEDCATEGORY"].ToString();
                        if (!Convert.IsDBNull(zRdr["FEEDCATEGORYNAME"])) _FEEDCATEGORYNAME = zRdr["FEEDCATEGORYNAME"].ToString();
                        if (!Convert.IsDBNull(zRdr["FOODNAME"])) _FOODNAME = zRdr["FOODNAME"].ToString();
                        if (!Convert.IsDBNull(zRdr["FOODTYPE"])) _FOODTYPE = Convert.ToDouble(zRdr["FOODTYPE"]);
                        if (!Convert.IsDBNull(zRdr["FOODTYPENAME"])) _FOODTYPENAME = zRdr["FOODTYPENAME"].ToString();
                        if (!Convert.IsDBNull(zRdr["FORMULAFEDDNAME"])) _FORMULAFEDDNAME = zRdr["FORMULAFEDDNAME"].ToString();
                        if (!Convert.IsDBNull(zRdr["HEIGHT"])) _HEIGHT = Convert.ToDouble(zRdr["HEIGHT"]);
                        if (!Convert.IsDBNull(zRdr["HN"])) _HN = zRdr["HN"].ToString();
                        if (!Convert.IsDBNull(zRdr["INCREASE"])) _INCREASE = zRdr["INCREASE"].ToString();
                        if (!Convert.IsDBNull(zRdr["LIMIT"])) _LIMIT = zRdr["LIMIT"].ToString();
                        if (!Convert.IsDBNull(zRdr["MATERIALNAME"])) _MATERIALNAME = zRdr["MATERIALNAME"].ToString();
                        if (!Convert.IsDBNull(zRdr["MEDENDDATE"])) _MEDENDDATE = Convert.ToDateTime(zRdr["MEDENDDATE"]);
                        if (!Convert.IsDBNull(zRdr["MEDFIRSTDATE"])) _MEDFIRSTDATE = Convert.ToDateTime(zRdr["MEDFIRSTDATE"]);
                        if (!Convert.IsDBNull(zRdr["MEDORDERDATE"])) _MEDORDERDATE = Convert.ToDateTime(zRdr["MEDORDERDATE"]);
                        if (!Convert.IsDBNull(zRdr["MEDSTATUS"])) _MEDSTATUS = zRdr["MEDSTATUS"].ToString();
                        if (!Convert.IsDBNull(zRdr["NEED"])) _NEED = zRdr["NEED"].ToString();
                        if (!Convert.IsDBNull(zRdr["NONENDDATE"])) _NONENDDATE = Convert.ToDateTime(zRdr["NONENDDATE"]);
                        if (!Convert.IsDBNull(zRdr["NONFIRSTDATE"])) _NONFIRSTDATE = Convert.ToDateTime(zRdr["NONFIRSTDATE"]);
                        if (!Convert.IsDBNull(zRdr["NONORDERDATE"])) _NONORDERDATE = Convert.ToDateTime(zRdr["NONORDERDATE"]);
                        if (!Convert.IsDBNull(zRdr["NONSTATUS"])) _NONSTATUS = zRdr["NONSTATUS"].ToString();
                        if (!Convert.IsDBNull(zRdr["ORDERMEDICALFEED"])) _ORDERMEDICALFEED = Convert.ToDouble(zRdr["ORDERMEDICALFEED"]);
                        if (!Convert.IsDBNull(zRdr["ORDERNONMEDICAL"])) _ORDERNONMEDICAL = Convert.ToDouble(zRdr["ORDERNONMEDICAL"]);
                        if (!Convert.IsDBNull(zRdr["PATIENTNAME"])) _PATIENTNAME = zRdr["PATIENTNAME"].ToString();
                        if (!Convert.IsDBNull(zRdr["QTY"])) _QTY = zRdr["QTY"].ToString();
                        if (!Convert.IsDBNull(zRdr["REMARKS"])) _REMARKS = zRdr["REMARKS"].ToString();
                        if (!Convert.IsDBNull(zRdr["ROOMNO"])) _ROOMNO = zRdr["ROOMNO"].ToString();
                        if (!Convert.IsDBNull(zRdr["STATUS"])) _STATUS = zRdr["STATUS"].ToString();
                        if (!Convert.IsDBNull(zRdr["STATUSNAME"])) _STATUSNAME = zRdr["STATUSNAME"].ToString();
                        if (!Convert.IsDBNull(zRdr["VN"])) _VN = zRdr["VN"].ToString();
                        if (!Convert.IsDBNull(zRdr["WARD"])) _WARD = Convert.ToDouble(zRdr["WARD"]);
                        if (!Convert.IsDBNull(zRdr["WARDNAME"])) _WARDNAME = zRdr["WARDNAME"].ToString();
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

        public DataTable GetDataListByConditions(DateTime date, double cWARD, string cFOODNAME, string cPATIENTNAME, DateTime cORDERDATEFROM, DateTime cORDERDATETO, string orderBy, OracleTransaction trans)
        {
            string whText = "STATUS = 'FN' AND ISFAMILY='N' ";
            //if (date.Year != 1) whText += (whText == "" ? "" : "AND ") +
            //    "(((TO_DATE(MEDFIRSTDATE) <= " + DB.SetDate(date) + " AND (TO_DATE(MEDENDDATE) >= " + DB.SetDate(date) + " OR MEDENDDATE IS NULL)) OR NONFIRSTDATE IS NULL) OR " +
            //    "((TO_DATE(NONFIRSTDATE) <= " + DB.SetDate(date) + " AND (TO_DATE(NONENDDATE) >= " + DB.SetDate(date) + " OR NONENDDATE IS NULL)) OR MEDFIRSTDATE IS NULL)) ";
            if (cWARD != 0) whText += (whText == "" ? "" : "AND ") + "WARD = " + DB.SetDouble(cWARD) + " ";
            if (cFOODNAME.Trim() != "") whText += (whText == "" ? "" : "AND ") + "NVL(MATERIALNAME, FORMULAFEEDNAME) = " + DB.SetString(cFOODNAME) + " ";
            if (cPATIENTNAME.Trim() != "") whText += (whText == "" ? "" : "AND ") + "PATIENTNAME LIKE " + DB.SetString("%" + cPATIENTNAME.Trim() + "%") + " ";
            if (cORDERDATEFROM.Year != 1) whText += (whText == "" ? "" : "AND ") + "(MEDORDERDATE >= " + DB.SetDateTime(cORDERDATEFROM) + " OR NONORDERDATE >=" + DB.SetDateTime(cORDERDATEFROM) + ") ";
            if (cORDERDATETO.Year != 1) whText += (whText == "" ? "" : "AND ") + "(MEDORDERDATE <= " + DB.SetDateTime(cORDERDATETO) + " OR NONORDERDATE <=" + DB.SetDateTime(cORDERDATETO) + ") ";
            return GetDataList(whText, orderBy, trans);
        }

    }
}