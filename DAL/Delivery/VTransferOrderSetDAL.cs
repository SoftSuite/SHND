using System;
using System.Data;
using System.Data.OracleClient;
using DB = SHND.DAL.Utilities.OracleDB;
using SHND.Data.Common.Utilities;

namespace SHND.DAL.Delivery
{
    /// <summary>
    /// Represents a transaction for V_ORDERSET_WAIT_TRANSFER view.
    /// [Created by 127.0.0.1 on April,16 2009]
    /// </summary>
    public class VTransferOrderSetDAL
    {

        public VTransferOrderSetDAL() { }

        #region Constant

        /// <summary>V_ORDERSET_WAIT_TRANSFER</summary>
        private const string viewName = "V_ORDERSET_WAIT_TRANSFER";

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
        double _BREAKFAST = 0;
        string _CONTROL = "";
        double _DINNER = 0;
        string _DISEASE = "";
        double _EGG = 0;
        double _FOODCATEGORY = 0;
        string _FOODCATEGORYNAME = "";
        double _FOODTYPE = 0;
        string _FOODTYPENAME = "";
        double _HEIGHT = 0;
        string _HN = "";
        string _INCREASE = "";
        double _INTERFOOD = 0;
        string _ISCALCULATE = "";
        string _ISINCREASE = "";
        string _ISLIMIT = "";
        string _ISNPO = "";
        string _ISREGISTER = "";
        string _ISSPECIFIC = "";
        string _ISTRANSFER = "";
        double _LIGHT = 0;
        string _LIMIT = "";
        double _LOID = 0;
        double _LUNCH = 0;
        DateTime _MEDENDDATE = new DateTime(1, 1, 1);
        DateTime _MEDFIRSTDATE = new DateTime(1, 1, 1);
        string _MEDISREGISTER = "";
        DateTime _MEDORDERDATE = new DateTime(1, 1, 1);
        string _MEDSTATUS = "";
        string _NEED = "";
        DateTime _NONENDDATE = new DateTime(1, 1, 1);
        DateTime _NONFIRSTDATE = new DateTime(1, 1, 1);
        string _NONISREGISTER = "";
        DateTime _NONORDERDATE = new DateTime(1, 1, 1);
        string _NONSTATUS = "";
        DateTime _ORDERDATE = new DateTime(1, 1, 1);
        double _ORDERMEDICALSET = 0;
        double _ORDERMEDICALSETID = 0;
        double _ORDERNONMEDICAL = 0;
        double _ORDERNONMEDICALID = 0;
        string _ORDERTIME = "";
        string _PATIENTNAME = "";
        string _PREPAREMEAL = "";
        double _PREPARETIME = 0;
        DateTime _PRINTTIME = new DateTime(1, 1, 1);
        string _QTY = "";
        DateTime _REGISTERDATE = new DateTime(1, 1, 1);
        string _REGISTERTIME = "";
        double _REGULAR = 0;
        string _REMARKS = "";
        string _ROOMNO = "";
        double _SOFT = 0;
        double _SPECIFIC = 0;
        string _STATUS = "";
        string _VN = "";
        double _WARD = 0;
        double _WARDID = 0;
        string _WARDNAME = "";
        double _WEIGHT = 0;
        DateTime _DELIVERYTIME = new DateTime(1, 1, 1);

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
        public double BREAKFAST
        {
            get { return _BREAKFAST; }
            set { _BREAKFAST = value; }
        }
        public string CONTROL
        {
            get { return _CONTROL; }
            set { _CONTROL = value; }
        }
        public double DINNER
        {
            get { return _DINNER; }
            set { _DINNER = value; }
        }
        public string DISEASE
        {
            get { return _DISEASE; }
            set { _DISEASE = value; }
        }
        public double EGG
        {
            get { return _EGG; }
            set { _EGG = value; }
        }
        public double FOODCATEGORY
        {
            get { return _FOODCATEGORY; }
            set { _FOODCATEGORY = value; }
        }
        public string FOODCATEGORYNAME
        {
            get { return _FOODCATEGORYNAME; }
            set { _FOODCATEGORYNAME = value; }
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
        public double INTERFOOD
        {
            get { return _INTERFOOD; }
            set { _INTERFOOD = value; }
        }
        public string ISCALCULATE
        {
            get { return _ISCALCULATE; }
            set { _ISCALCULATE = value; }
        }
        public string ISINCREASE
        {
            get { return _ISINCREASE; }
            set { _ISINCREASE = value; }
        }
        public string ISLIMIT
        {
            get { return _ISLIMIT; }
            set { _ISLIMIT = value; }
        }
        public string ISNPO
        {
            get { return _ISNPO; }
            set { _ISNPO = value; }
        }
        public string ISREGISTER
        {
            get { return _ISREGISTER; }
            set { _ISREGISTER = value; }
        }
        public string ISSPECIFIC
        {
            get { return _ISSPECIFIC; }
            set { _ISSPECIFIC = value; }
        }
        public string ISTRANSFER
        {
            get { return _ISTRANSFER; }
            set { _ISTRANSFER = value; }
        }
        public double LIGHT
        {
            get { return _LIGHT; }
            set { _LIGHT = value; }
        }
        public string LIMIT
        {
            get { return _LIMIT; }
            set { _LIMIT = value; }
        }
        public double LOID
        {
            get { return _LOID; }
            set { _LOID = value; }
        }
        public double LUNCH
        {
            get { return _LUNCH; }
            set { _LUNCH = value; }
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
        public string MEDISREGISTER
        {
            get { return _MEDISREGISTER; }
            set { _MEDISREGISTER = value; }
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
        public string NONISREGISTER
        {
            get { return _NONISREGISTER; }
            set { _NONISREGISTER = value; }
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
        public DateTime ORDERDATE
        {
            get { return _ORDERDATE; }
            set { _ORDERDATE = value; }
        }
        public double ORDERMEDICALSET
        {
            get { return _ORDERMEDICALSET; }
            set { _ORDERMEDICALSET = value; }
        }
        public double ORDERMEDICALSETID
        {
            get { return _ORDERMEDICALSETID; }
            set { _ORDERMEDICALSETID = value; }
        }
        public double ORDERNONMEDICAL
        {
            get { return _ORDERNONMEDICAL; }
            set { _ORDERNONMEDICAL = value; }
        }
        public double ORDERNONMEDICALID
        {
            get { return _ORDERNONMEDICALID; }
            set { _ORDERNONMEDICALID = value; }
        }
        public string ORDERTIME
        {
            get { return _ORDERTIME; }
            set { _ORDERTIME = value; }
        }
        public string PATIENTNAME
        {
            get { return _PATIENTNAME; }
            set { _PATIENTNAME = value; }
        }
        public string PREPAREMEAL
        {
            get { return _PREPAREMEAL; }
            set { _PREPAREMEAL = value; }
        }
        public double PREPARETIME
        {
            get { return _PREPARETIME; }
            set { _PREPARETIME = value; }
        }
        public DateTime PRINTTIME
        {
            get { return _PRINTTIME; }
            set { _PRINTTIME = value; }
        }
        public string QTY
        {
            get { return _QTY; }
            set { _QTY = value; }
        }
        public DateTime REGISTERDATE
        {
            get { return _REGISTERDATE; }
            set { _REGISTERDATE = value; }
        }
        public string REGISTERTIME
        {
            get { return _REGISTERTIME; }
            set { _REGISTERTIME = value; }
        }
        public double REGULAR
        {
            get { return _REGULAR; }
            set { _REGULAR = value; }
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
        public double SOFT
        {
            get { return _SOFT; }
            set { _SOFT = value; }
        }
        public double SPECIFIC
        {
            get { return _SPECIFIC; }
            set { _SPECIFIC = value; }
        }
        public string STATUS
        {
            get { return _STATUS; }
            set { _STATUS = value; }
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
        public double WARDID
        {
            get { return _WARDID; }
            set { _WARDID = value; }
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
        public DateTime DELIVERYTIME
        {
            get { return _DELIVERYTIME; }
            set {_DELIVERYTIME = value;}
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
            _BREAKFAST = 0;
            _CONTROL = "";
            _DINNER = 0;
            _DISEASE = "";
            _EGG = 0;
            _FOODCATEGORY = 0;
            _FOODCATEGORYNAME = "";
            _FOODTYPE = 0;
            _FOODTYPENAME = "";
            _HEIGHT = 0;
            _HN = "";
            _INCREASE = "";
            _INTERFOOD = 0;
            _ISCALCULATE = "";
            _ISINCREASE = "";
            _ISLIMIT = "";
            _ISNPO = "";
            _ISREGISTER = "";
            _ISSPECIFIC = "";
            _ISTRANSFER = "";
            _LIGHT = 0;
            _LIMIT = "";
            _LOID = 0;
            _LUNCH = 0;
            _MEDENDDATE = new DateTime(1, 1, 1);
            _MEDFIRSTDATE = new DateTime(1, 1, 1);
            _MEDISREGISTER = "";
            _MEDORDERDATE = new DateTime(1, 1, 1);
            _MEDSTATUS = "";
            _NEED = "";
            _NONENDDATE = new DateTime(1, 1, 1);
            _NONFIRSTDATE = new DateTime(1, 1, 1);
            _NONISREGISTER = "";
            _NONORDERDATE = new DateTime(1, 1, 1);
            _NONSTATUS = "";
            _ORDERDATE = new DateTime(1, 1, 1);
            _ORDERMEDICALSET = 0;
            _ORDERMEDICALSETID = 0;
            _ORDERNONMEDICAL = 0;
            _ORDERNONMEDICALID = 0;
            _ORDERTIME = "";
            _PATIENTNAME = "";
            _PREPAREMEAL = "";
            _PREPARETIME = 0;
            _PRINTTIME = new DateTime(1, 1, 1);
            _QTY = "";
            _REGISTERDATE = new DateTime(1, 1, 1);
            _REGISTERTIME = "";
            _REGULAR = 0;
            _REMARKS = "";
            _ROOMNO = "";
            _SOFT = 0;
            _SPECIFIC = 0;
            _STATUS = "";
            _VN = "";
            _WARD = 0;
            _WARDID = 0;
            _WARDNAME = "";
            _WEIGHT = 0;
            _DELIVERYTIME = new DateTime(1, 1, 1);
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
        /// Gets the select statement for V_ORDERSET_WAIT_TRANSFER table.
        /// </summary>
        private string sql_select
        {
            get
            {
                string sql = "SELECT CASE WHEN RANK() OVER(PARTITION BY ADMITPATIENT ORDER BY PATIENTNAME, PREPARETIME) = 1 THEN 1 ELSE 0 END RANK, A.* FROM " + viewName + " A ";
                return sql;
            }
        }

        #endregion

        #region Private Methods

        /// <summary>
        /// Returns an indication whether the record of V_ORDERSET_WAIT_TRANSFER by specified condition is retrieved successfully.
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
                        if (!Convert.IsDBNull(zRdr["BREAKFAST"])) _BREAKFAST = Convert.ToDouble(zRdr["BREAKFAST"]);
                        if (!Convert.IsDBNull(zRdr["CONTROL"])) _CONTROL = zRdr["CONTROL"].ToString();
                        if (!Convert.IsDBNull(zRdr["DINNER"])) _DINNER = Convert.ToDouble(zRdr["DINNER"]);
                        if (!Convert.IsDBNull(zRdr["DISEASE"])) _DISEASE = zRdr["DISEASE"].ToString();
                        if (!Convert.IsDBNull(zRdr["EGG"])) _EGG = Convert.ToDouble(zRdr["EGG"]);
                        if (!Convert.IsDBNull(zRdr["FOODCATEGORY"])) _FOODCATEGORY = Convert.ToDouble(zRdr["FOODCATEGORY"]);
                        if (!Convert.IsDBNull(zRdr["FOODCATEGORYNAME"])) _FOODCATEGORYNAME = zRdr["FOODCATEGORYNAME"].ToString();
                        if (!Convert.IsDBNull(zRdr["FOODTYPE"])) _FOODTYPE = Convert.ToDouble(zRdr["FOODTYPE"]);
                        if (!Convert.IsDBNull(zRdr["FOODTYPENAME"])) _FOODTYPENAME = zRdr["FOODTYPENAME"].ToString();
                        if (!Convert.IsDBNull(zRdr["HEIGHT"])) _HEIGHT = Convert.ToDouble(zRdr["HEIGHT"]);
                        if (!Convert.IsDBNull(zRdr["HN"])) _HN = zRdr["HN"].ToString();
                        if (!Convert.IsDBNull(zRdr["INCREASE"])) _INCREASE = zRdr["INCREASE"].ToString();
                        if (!Convert.IsDBNull(zRdr["INTERFOOD"])) _INTERFOOD = Convert.ToDouble(zRdr["INTERFOOD"]);
                        if (!Convert.IsDBNull(zRdr["ISCALCULATE"])) _ISCALCULATE = zRdr["ISCALCULATE"].ToString();
                        if (!Convert.IsDBNull(zRdr["ISINCREASE"])) _ISINCREASE = zRdr["ISINCREASE"].ToString();
                        if (!Convert.IsDBNull(zRdr["ISLIMIT"])) _ISLIMIT = zRdr["ISLIMIT"].ToString();
                        if (!Convert.IsDBNull(zRdr["ISNPO"])) _ISNPO = zRdr["ISNPO"].ToString();
                        if (!Convert.IsDBNull(zRdr["ISREGISTER"])) _ISREGISTER = zRdr["ISREGISTER"].ToString();
                        if (!Convert.IsDBNull(zRdr["ISSPECIFIC"])) _ISSPECIFIC = zRdr["ISSPECIFIC"].ToString();
                        if (!Convert.IsDBNull(zRdr["ISTRANSFER"])) _ISTRANSFER = zRdr["ISTRANSFER"].ToString();
                        if (!Convert.IsDBNull(zRdr["LIGHT"])) _LIGHT = Convert.ToDouble(zRdr["LIGHT"]);
                        if (!Convert.IsDBNull(zRdr["LIMIT"])) _LIMIT = zRdr["LIMIT"].ToString();
                        if (!Convert.IsDBNull(zRdr["LOID"])) _LOID = Convert.ToDouble(zRdr["LOID"]);
                        if (!Convert.IsDBNull(zRdr["LUNCH"])) _LUNCH = Convert.ToDouble(zRdr["LUNCH"]);
                        if (!Convert.IsDBNull(zRdr["MEDENDDATE"])) _MEDENDDATE = Convert.ToDateTime(zRdr["MEDENDDATE"]);
                        if (!Convert.IsDBNull(zRdr["MEDFIRSTDATE"])) _MEDFIRSTDATE = Convert.ToDateTime(zRdr["MEDFIRSTDATE"]);
                        if (!Convert.IsDBNull(zRdr["MEDISREGISTER"])) _MEDISREGISTER = zRdr["MEDISREGISTER"].ToString();
                        if (!Convert.IsDBNull(zRdr["MEDORDERDATE"])) _MEDORDERDATE = Convert.ToDateTime(zRdr["MEDORDERDATE"]);
                        if (!Convert.IsDBNull(zRdr["MEDSTATUS"])) _MEDSTATUS = zRdr["MEDSTATUS"].ToString();
                        if (!Convert.IsDBNull(zRdr["NEED"])) _NEED = zRdr["NEED"].ToString();
                        if (!Convert.IsDBNull(zRdr["NONENDDATE"])) _NONENDDATE = Convert.ToDateTime(zRdr["NONENDDATE"]);
                        if (!Convert.IsDBNull(zRdr["NONFIRSTDATE"])) _NONFIRSTDATE = Convert.ToDateTime(zRdr["NONFIRSTDATE"]);
                        if (!Convert.IsDBNull(zRdr["NONISREGISTER"])) _NONISREGISTER = zRdr["NONISREGISTER"].ToString();
                        if (!Convert.IsDBNull(zRdr["NONORDERDATE"])) _NONORDERDATE = Convert.ToDateTime(zRdr["NONORDERDATE"]);
                        if (!Convert.IsDBNull(zRdr["NONSTATUS"])) _NONSTATUS = zRdr["NONSTATUS"].ToString();
                        if (!Convert.IsDBNull(zRdr["ORDERDATE"])) _ORDERDATE = Convert.ToDateTime(zRdr["ORDERDATE"]);
                        if (!Convert.IsDBNull(zRdr["ORDERMEDICALSET"])) _ORDERMEDICALSET = Convert.ToDouble(zRdr["ORDERMEDICALSET"]);
                        if (!Convert.IsDBNull(zRdr["ORDERMEDICALSETID"])) _ORDERMEDICALSETID = Convert.ToDouble(zRdr["ORDERMEDICALSETID"]);
                        if (!Convert.IsDBNull(zRdr["ORDERNONMEDICAL"])) _ORDERNONMEDICAL = Convert.ToDouble(zRdr["ORDERNONMEDICAL"]);
                        if (!Convert.IsDBNull(zRdr["ORDERNONMEDICALID"])) _ORDERNONMEDICALID = Convert.ToDouble(zRdr["ORDERNONMEDICALID"]);
                        if (!Convert.IsDBNull(zRdr["ORDERTIME"])) _ORDERTIME = zRdr["ORDERTIME"].ToString();
                        if (!Convert.IsDBNull(zRdr["PATIENTNAME"])) _PATIENTNAME = zRdr["PATIENTNAME"].ToString();
                        if (!Convert.IsDBNull(zRdr["PREPAREMEAL"])) _PREPAREMEAL = zRdr["PREPAREMEAL"].ToString();
                        if (!Convert.IsDBNull(zRdr["PREPARETIME"])) _PREPARETIME = Convert.ToDouble(zRdr["PREPARETIME"]);
                        if (!Convert.IsDBNull(zRdr["PRINTTIME"])) _PRINTTIME = Convert.ToDateTime(zRdr["PRINTTIME"]);
                        if (!Convert.IsDBNull(zRdr["QTY"])) _QTY = zRdr["QTY"].ToString();
                        if (!Convert.IsDBNull(zRdr["REGISTERDATE"])) _REGISTERDATE = Convert.ToDateTime(zRdr["REGISTERDATE"]);
                        if (!Convert.IsDBNull(zRdr["REGISTERTIME"])) _REGISTERTIME = zRdr["REGISTERTIME"].ToString();
                        if (!Convert.IsDBNull(zRdr["REGULAR"])) _REGULAR = Convert.ToDouble(zRdr["REGULAR"]);
                        if (!Convert.IsDBNull(zRdr["REMARKS"])) _REMARKS = zRdr["REMARKS"].ToString();
                        if (!Convert.IsDBNull(zRdr["ROOMNO"])) _ROOMNO = zRdr["ROOMNO"].ToString();
                        if (!Convert.IsDBNull(zRdr["SOFT"])) _SOFT = Convert.ToDouble(zRdr["SOFT"]);
                        if (!Convert.IsDBNull(zRdr["SPECIFIC"])) _SPECIFIC = Convert.ToDouble(zRdr["SPECIFIC"]);
                        if (!Convert.IsDBNull(zRdr["STATUS"])) _STATUS = zRdr["STATUS"].ToString();
                        if (!Convert.IsDBNull(zRdr["VN"])) _VN = zRdr["VN"].ToString();
                        if (!Convert.IsDBNull(zRdr["WARD"])) _WARD = Convert.ToDouble(zRdr["WARD"]);
                        if (!Convert.IsDBNull(zRdr["WARDID"])) _WARDID = Convert.ToDouble(zRdr["WARDID"]);
                        if (!Convert.IsDBNull(zRdr["WARDNAME"])) _WARDNAME = zRdr["WARDNAME"].ToString();
                        if (!Convert.IsDBNull(zRdr["WEIGHT"])) _WEIGHT = Convert.ToDouble(zRdr["WEIGHT"]);
                        if (!Convert.IsDBNull(zRdr["DELIVERYTIME"])) _DELIVERYTIME = Convert.ToDateTime(zRdr["DELIVERYTIME"]);

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

        public DataTable GetDataListByConditions(double cWARD, double cFOODTYPE, double cFOODCATEGORY, string cPATIENTNAME, string cHN, string cAN, string cVN, DateTime cPRINTTIME, string cPREPAREMEAL, string admitPatientList, string orderBy, OracleTransaction trans)
        {
            string whText = "";
            if (cWARD != 0) whText += (whText == "" ? "" : "AND ") + "WARD = " + DB.SetDouble(cWARD) + " ";
            if (cFOODTYPE != 0) whText += (whText == "" ? "" : "AND ") + "FOODTYPE = " + DB.SetDouble(cFOODTYPE) + " ";
            if (cFOODCATEGORY != 0) whText += (whText == "" ? "" : "AND ") + "FOODCATEGORY = " + DB.SetDouble(cFOODCATEGORY) + " ";
            if (cPATIENTNAME.Trim() != "") whText += (whText == "" ? "" : "AND ") + "PATIENTNAME LIKE " + DB.SetString("%" + cPATIENTNAME + "%") + " ";
            if (cHN.Trim() != "") whText += (whText == "" ? "" : "AND ") + "HN LIKE " + DB.SetString("%" + cHN + "%") + " ";
            if (cAN.Trim() != "") whText += (whText == "" ? "" : "AND ") + "AN LIKE " + DB.SetString("%" + cAN + "%") + " ";
            if (cVN.Trim() != "") whText += (whText == "" ? "" : "AND ") + "VN LIKE " + DB.SetString("%" + cVN + "%") + " ";
            if (cPRINTTIME.Year != 1) whText += (whText == "" ? "" : "AND ") + "TO_DATE(PRINTTIME) = " + DB.SetDate(cPRINTTIME) + " ";
            if (cPREPAREMEAL.Trim() != "") whText += (whText == "" ? "" : "AND ") + "PREPAREMEAL = " + DB.SetString(cPREPAREMEAL) + " ";
            if (admitPatientList.Trim() != "") whText += (whText == "" ? "" : "AND ") + "ADMITPATIENT IN (" + admitPatientList + ") ";
            return GetDataList(whText, orderBy, trans);
        }

    }
}
