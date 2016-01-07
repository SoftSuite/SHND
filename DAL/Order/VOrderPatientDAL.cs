using System;
using System.Data;
using System.Data.OracleClient;
using DB = SHND.DAL.Utilities.OracleDB;
using SHND.Data.Common.Utilities;
using SHND.DAL.Functions;

namespace SHND.DAL.Order
{
    /// <summary>
    /// Represents a transaction for V_ORDER_PATIENT_SEARCH view.
    /// [Created by 127.0.0.1 on March,10 2009]
    /// </summary>
    public class VOrderPatientDAL
    {

        public VOrderPatientDAL()
        {
        }

        #region Private Variables

        string _error = "";
        string _information = "";
        bool _OnDB = false;
        DateTime _ADMITDATE = new DateTime(1, 1, 1);
        string _AGE = "";
        string _AN = "";
        string _BEDNO = "";
        DateTime _BIRTHDATE = new DateTime(1, 1, 1);
        string _DIAGNOSIS = "";
        string _DRUGALLERGIC = "";
        string _FOODALLERGIC = "";
        double _HEIGHT = 0;
        string _HN = "";
        double _LOID = 0;
        string _PATIENTNAME = "";
        string _PATIENTSTATUS = "";
        string _REMARK = "";
        string _ROOMNO = "";
        string _STATUSNAME = "";
        string _STATUSRANK = "";
        double _TITLE = 0;
        string _TITLENAME = "";
        string _VN = "";
        double _WARD = 0;
        string _WARDNAME = "";
        double _WEIGHT = 0;
        double _DEFAULTFOODTYPE = 0;

        #endregion

        #region Public Properties

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
        public string DIAGNOSIS
        {
            get { return _DIAGNOSIS; }
            set { _DIAGNOSIS = value; }
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
        public string PATIENTSTATUS
        {
            get { return _PATIENTSTATUS; }
            set { _PATIENTSTATUS = value; }
        }
        public string REMARK
        {
            get { return _REMARK; }
            set { _REMARK = value; }
        }
        public string ROOMNO
        {
            get { return _ROOMNO; }
            set { _ROOMNO = value; }
        }
        public string STATUSNAME
        {
            get { return _STATUSNAME; }
            set { _STATUSNAME = value; }
        }
        public string STATUSRANK
        {
            get { return _STATUSRANK; }
            set { _STATUSRANK = value; }
        }
        public double TITLE
        {
            get { return _TITLE; }
            set { _TITLE = value; }
        }
        public string TITLENAME
        {
            get { return _TITLENAME; }
            set { _TITLENAME = value; }
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
        public double DEFAULTFOODTYPE
        { 
            get { return _DEFAULTFOODTYPE; }
            set { _DEFAULTFOODTYPE = value; }
        }

        #endregion

        #region Clear Data

        /// <summary>
        /// Initialize data.
        /// </summary>
        private void ClearData()
        {
            _ADMITDATE = new DateTime(1, 1, 1);
            _AGE = "";
            _AN = "";
            _BEDNO = "";
            _BIRTHDATE = new DateTime(1, 1, 1);
            _DIAGNOSIS = "";
            _DRUGALLERGIC = "";
            _FOODALLERGIC = "";
            _HEIGHT = 0;
            _HN = "";
            _LOID = 0;
            _PATIENTNAME = "";
            _PATIENTSTATUS = "";
            _REMARK = "";
            _ROOMNO = "";
            _STATUSNAME = "";
            _STATUSRANK = "";
            _TITLE = 0;
            _TITLENAME = "";
            _VN = "";
            _WARD = 0;
            _WARDNAME = "";
            _WEIGHT = 0;
            _DEFAULTFOODTYPE = 0;
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
        public DataTable GetDataList(DateTime date, string whereClause, string orderBy, OracleTransaction trans)
        {
            return DB.ExecuteTable(sql_select(date) + (whereClause == "" ? "" : "WHERE " + whereClause + " ") + (orderBy == "" ? "" : "ORDER BY " + DB.SetSortString(orderBy)), trans);
        }

        #endregion

        #region SQL Statements

        /// <summary>
        /// Gets the select statement for V_ORDER_PATIENT_SEARCH table.
        /// </summary>
        private string sql_select(DateTime date)
        {
            string sql = "SELECT * FROM (SELECT /*+ NO_CPU_COSTING */ P.LOID, P.ADMITDATE, P.HN, P.AN, P.VN, P.TITLE, T.NAME TITLENAME, P.WARD, W.NAME WARDNAME, P.ROOMNO, P.BEDNO, P.PATIENTNAME, " +
                "P.BIRTHDATE, P.STATUS PATIENTSTATUS, PKE_PATIENT.FN_CALAGE(P.BIRTHDATE,'Y','Y',P.LOID) AGE, P.WEIGHT, P.HEIGHT, P.DIAGNOSIS, P.DRUGALLERGIC, P.FOODALLERGIC, " +
                "PKE_ORDER.FN_ORDERSTATUS(P.LOID, " + DB.SetDate() + ", 1) REMARK, PKE_ORDER.FN_ORDERSTATUS(P.LOID, " + DB.SetDate() + ") STATUSRANK, " +
                "fn_statusname(PKE_ORDER.FN_ORDERSTATUS(P.LOID, SYSDATE), 'ORDERMEDICALSET') STATUSNAME, W.DEFAULTFOODTYPE,PKE_ORDER.FN_CHKISFAMILY(P.LOID) ISRELATIVE " +
                "FROM ADMITPATIENT P LEFT JOIN TITLE T ON T.LOID = P.TITLE " +
                "INNER JOIN WARD W ON W.LOID = P.WARD) V_ORDER_PATIENT_SEARCH ";
            return sql;
        }

        #endregion

        #region Private Methods

        /// <summary>
        /// Returns an indication whether the record of V_ORDER_PATIENT_SEARCH by specified condition is retrieved successfully.
        /// </summary>
        /// <param name="whText">The condition specify the deleting record(s).</param>
        /// <param name="trans">The System.Data.OracleClient.OracleTransaction used by this System.Data.OracleClient.OracleCommand.</param>
        /// <returns>true if data is retrieved successfully; otherwise, false.</returns>
        public bool doGetdata(DateTime date, string whText, OracleTransaction trans)
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
                    zRdr = DB.ExecuteReader(sql_select(date) + tmpWhere, trans);
                    if (zRdr.Read())
                    {
                        _OnDB = true;
                        if (!Convert.IsDBNull(zRdr["ADMITDATE"])) _ADMITDATE = Convert.ToDateTime(zRdr["ADMITDATE"]);
                        if (!Convert.IsDBNull(zRdr["AGE"])) _AGE = zRdr["AGE"].ToString();
                        if (!Convert.IsDBNull(zRdr["AN"])) _AN = zRdr["AN"].ToString();
                        if (!Convert.IsDBNull(zRdr["BEDNO"])) _BEDNO = zRdr["BEDNO"].ToString();
                        if (!Convert.IsDBNull(zRdr["BIRTHDATE"])) _BIRTHDATE = Convert.ToDateTime(zRdr["BIRTHDATE"]);
                        if (!Convert.IsDBNull(zRdr["DIAGNOSIS"])) _DIAGNOSIS = zRdr["DIAGNOSIS"].ToString();
                        if (!Convert.IsDBNull(zRdr["DRUGALLERGIC"])) _DRUGALLERGIC = zRdr["DRUGALLERGIC"].ToString();
                        if (!Convert.IsDBNull(zRdr["FOODALLERGIC"])) _FOODALLERGIC = zRdr["FOODALLERGIC"].ToString();
                        if (!Convert.IsDBNull(zRdr["HEIGHT"])) _HEIGHT = Convert.ToDouble(zRdr["HEIGHT"]);
                        if (!Convert.IsDBNull(zRdr["HN"])) _HN = zRdr["HN"].ToString();
                        if (!Convert.IsDBNull(zRdr["LOID"])) _LOID = Convert.ToDouble(zRdr["LOID"]);
                        if (!Convert.IsDBNull(zRdr["PATIENTNAME"])) _PATIENTNAME = zRdr["PATIENTNAME"].ToString();
                        if (!Convert.IsDBNull(zRdr["PATIENTSTATUS"])) _PATIENTSTATUS = zRdr["PATIENTSTATUS"].ToString();
                        if (!Convert.IsDBNull(zRdr["REMARK"])) _REMARK = zRdr["REMARK"].ToString();
                        if (!Convert.IsDBNull(zRdr["ROOMNO"])) _ROOMNO = zRdr["ROOMNO"].ToString();
                        if (!Convert.IsDBNull(zRdr["STATUSNAME"])) _STATUSNAME = zRdr["STATUSNAME"].ToString();
                        if (!Convert.IsDBNull(zRdr["STATUSRANK"])) _STATUSRANK = zRdr["STATUSRANK"].ToString();
                        if (!Convert.IsDBNull(zRdr["TITLE"])) _TITLE = Convert.ToDouble(zRdr["TITLE"]);
                        if (!Convert.IsDBNull(zRdr["TITLENAME"])) _TITLENAME = zRdr["TITLENAME"].ToString();
                        if (!Convert.IsDBNull(zRdr["VN"])) _VN = zRdr["VN"].ToString();
                        if (!Convert.IsDBNull(zRdr["WARD"])) _WARD = Convert.ToDouble(zRdr["WARD"]);
                        if (!Convert.IsDBNull(zRdr["WARDNAME"])) _WARDNAME = zRdr["WARDNAME"].ToString();
                        if (!Convert.IsDBNull(zRdr["WEIGHT"])) _WEIGHT = Convert.ToDouble(zRdr["WEIGHT"]);
                        if (!Convert.IsDBNull(zRdr["DEFAULTFOODTYPE"])) _DEFAULTFOODTYPE = Convert.ToDouble(zRdr["DEFAULTFOODTYPE"]);

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

        public DataTable GetDataListByConditions(DateTime cDATE, double cWARD, string cWARDNAME, DateTime cADMITDATEFROM, DateTime cADMITDATETO, string cHN, string cAN, 
            string cPATIENTNAME, string cSTATUSRANKFROM, string cSTATUSRANKTO, string otherConditions, double officerID , string OfficerGroup, string orderBy, OracleTransaction trans)
        {
            string whText = "";
            if (OfficerGroup != "A") whText += (whText == "" ? "" : "AND ") + " WARD IN (SELECT WARD FROM WARDRESPONSE WHERE OFFICER=" + DB.SetDouble(officerID) + ") ";
            if (cWARD != 0) whText += (whText == "" ? "" : "AND ") + "WARD = " + DB.SetDouble(cWARD) + " ";
            if (cWARDNAME.Trim() != "") whText += (whText == "" ? "" : "AND ") + "WARDNAME LIKE " + DB.SetString(cWARDNAME.Trim() + "%") + " ";
            if (cADMITDATEFROM.Year != 1) whText += (whText == "" ? "" : "AND ") + "TO_DATE(ADMITDATE) >= " + DB.SetDate(cADMITDATEFROM) + " ";
            if (cADMITDATETO.Year != 1) whText += (whText == "" ? "" : "AND ") + "TO_DATE(ADMITDATE) <= " + DB.SetDate(cADMITDATETO) + " ";
            if (cHN.Trim() != "") whText += (whText == "" ? "" : "AND ") + "HN LIKE " + DB.SetString("%" + cHN.Trim() + "%") + " ";
            if (cAN.Trim() != "") whText += (whText == "" ? "" : "AND ") + "AN LIKE " + DB.SetString("%" + cAN.Trim() + "%") + " ";
            if (cPATIENTNAME.Trim() != "") whText += (whText == "" ? "" : "AND ") + "PATIENTNAME LIKE " + DB.SetString("%" + cPATIENTNAME.Trim() + "%") + " ";
            if (cSTATUSRANKFROM.Trim() != "") whText += (whText == "" ? "" : "AND ") + "STATUSRANK >= " + DB.SetString(cSTATUSRANKFROM.Trim()) + " ";
            if (cSTATUSRANKTO.Trim() != "") whText += (whText == "" ? "" : "AND ") + "STATUSRANK <= " + DB.SetString(cSTATUSRANKTO.Trim()) + " ";
            if (otherConditions.Trim() != "") whText += (whText == "" ? "" : "AND ") + otherConditions.Trim() + " ";

            return GetDataList(cDATE, whText, orderBy, trans);
        }

        public bool GetDataByLOID(DateTime date, double cLOID, OracleTransaction trans)
        {
            return doGetdata(date, "LOID = " + DB.SetDouble(cLOID), trans);
        }
        public string GetLiquidCategory()
        {
            FunctionDAL fDAL = new FunctionDAL();
            return fDAL.GetConfigValue("LIQUIDLOID");
        }
    }
}