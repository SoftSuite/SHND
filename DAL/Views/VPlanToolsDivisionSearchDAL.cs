using System;
using System.Data;
using System.Data.OracleClient;
using DB = SHND.DAL.Utilities.OracleDB;
using SHND.Data.Common.Utilities;

namespace SHND.DAL.Views
{
    /// <summary>
    /// Represents a transaction for V_PLAN_TOOLS_DIVISION_SEARCH view.
    /// [Created by 127.0.0.1 on Febuary,16 2009]
    /// </summary>
    public class VPlanToolsDivisionSearchDAL
    {

        public VPlanToolsDivisionSearchDAL()
        {
        }

        #region Constant

        /// <summary>V_PLAN_TOOLS_DIVISION_SEARCH</summary>
        private const string viewName = "V_PLAN_TOOLS_DIVISION_SEARCH";

        #endregion

        #region Private Variables

        string _error = "";
        string _information = "";
        bool _OnDB = false;
        double _BUDGETYEAR = 0;
        string _CODE = "";
        double _DIVISION = 0;
        string _DIVISIONNAME = "";
        DateTime _ENDDATE = new DateTime(1, 1, 1);
        string _ISPLANFOOD = "";
        double _LOID = 0;
        double _MATERIALCLASS = 0;
        string _NAME = "";
        double _PERIODTIME = 0;
        string _PHASE = "";
        DateTime _PLANDATE = new DateTime(1, 1, 1);
        string _QTCODE = "";
        string _REFPRSAP = "";
        DateTime _STARTDATE = new DateTime(1, 1, 1);
        string _STATUS = "";
        string _STATUSNAME = "";
        string _STATUSRANK = "";

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
        public double BUDGETYEAR
        {
            get { return _BUDGETYEAR; }
            set { _BUDGETYEAR = value; }
        }
        public string CODE
        {
            get { return _CODE; }
            set { _CODE = value; }
        }
        public double DIVISION
        {
            get { return _DIVISION; }
            set { _DIVISION = value; }
        }
        public string DIVISIONNAME
        {
            get { return _DIVISIONNAME; }
            set { _DIVISIONNAME = value; }
        }
        public DateTime ENDDATE
        {
            get { return _ENDDATE; }
            set { _ENDDATE = value; }
        }
        public string ISPLANFOOD
        {
            get { return _ISPLANFOOD; }
            set { _ISPLANFOOD = value; }
        }
        public double LOID
        {
            get { return _LOID; }
            set { _LOID = value; }
        }
        public double MATERIALCLASS
        {
            get { return _MATERIALCLASS; }
            set { _MATERIALCLASS = value; }
        }
        public string NAME
        {
            get { return _NAME; }
            set { _NAME = value; }
        }
        public double PERIODTIME
        {
            get { return _PERIODTIME; }
            set { _PERIODTIME = value; }
        }
        public string PHASE
        {
            get { return _PHASE; }
            set { _PHASE = value; }
        }
        public DateTime PLANDATE
        {
            get { return _PLANDATE; }
            set { _PLANDATE = value; }
        }
        public string QTCODE
        {
            get { return _QTCODE; }
            set { _QTCODE = value; }
        }
        public string REFPRSAP
        {
            get { return _REFPRSAP; }
            set { _REFPRSAP = value; }
        }
        public DateTime STARTDATE
        {
            get { return _STARTDATE; }
            set { _STARTDATE = value; }
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
        public string STATUSRANK
        {
            get { return _STATUSRANK; }
            set { _STATUSRANK = value; }
        }

        #endregion

        #region Clear Data

        /// <summary>
        /// Initialize data.
        /// </summary>
        private void ClearData()
        {
            _BUDGETYEAR = 0;
            _CODE = "";
            _DIVISION = 0;
            _DIVISIONNAME = "";
            _ENDDATE = new DateTime(1, 1, 1);
            _ISPLANFOOD = "";
            _LOID = 0;
            _MATERIALCLASS = 0;
            _NAME = "";
            _PERIODTIME = 0;
            _PHASE = "";
            _PLANDATE = new DateTime(1, 1, 1);
            _QTCODE = "";
            _REFPRSAP = "";
            _STARTDATE = new DateTime(1, 1, 1);
            _STATUS = "";
            _STATUSNAME = "";
            _STATUSRANK = "";
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
        /// Gets the select statement for V_PLAN_TOOLS_DIVISION_SEARCH table.
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
        /// Returns an indication whether the record of V_PLAN_TOOLS_DIVISION_SEARCH by specified condition is retrieved successfully.
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
                        if (!Convert.IsDBNull(zRdr["BUDGETYEAR"])) _BUDGETYEAR = Convert.ToDouble(zRdr["BUDGETYEAR"]);
                        if (!Convert.IsDBNull(zRdr["CODE"])) _CODE = zRdr["CODE"].ToString();
                        if (!Convert.IsDBNull(zRdr["DIVISION"])) _DIVISION = Convert.ToDouble(zRdr["DIVISION"]);
                        if (!Convert.IsDBNull(zRdr["DIVISIONNAME"])) _DIVISIONNAME = zRdr["DIVISIONNAME"].ToString();
                        if (!Convert.IsDBNull(zRdr["ENDDATE"])) _ENDDATE = Convert.ToDateTime(zRdr["ENDDATE"]);
                        if (!Convert.IsDBNull(zRdr["ISPLANFOOD"])) _ISPLANFOOD = zRdr["ISPLANFOOD"].ToString();
                        if (!Convert.IsDBNull(zRdr["LOID"])) _LOID = Convert.ToDouble(zRdr["LOID"]);
                        if (!Convert.IsDBNull(zRdr["MATERIALCLASS"])) _MATERIALCLASS = Convert.ToDouble(zRdr["MATERIALCLASS"]);
                        if (!Convert.IsDBNull(zRdr["NAME"])) _NAME = zRdr["NAME"].ToString();
                        if (!Convert.IsDBNull(zRdr["PERIODTIME"])) _PERIODTIME = Convert.ToDouble(zRdr["PERIODTIME"]);
                        if (!Convert.IsDBNull(zRdr["PHASE"])) _PHASE = zRdr["PHASE"].ToString();
                        if (!Convert.IsDBNull(zRdr["PLANDATE"])) _PLANDATE = Convert.ToDateTime(zRdr["PLANDATE"]);
                        if (!Convert.IsDBNull(zRdr["QTCODE"])) _QTCODE = zRdr["QTCODE"].ToString();
                        if (!Convert.IsDBNull(zRdr["REFPRSAP"])) _REFPRSAP = zRdr["REFPRSAP"].ToString();
                        if (!Convert.IsDBNull(zRdr["STARTDATE"])) _STARTDATE = Convert.ToDateTime(zRdr["STARTDATE"]);
                        if (!Convert.IsDBNull(zRdr["STATUS"])) _STATUS = zRdr["STATUS"].ToString();
                        if (!Convert.IsDBNull(zRdr["STATUSNAME"])) _STATUSNAME = zRdr["STATUSNAME"].ToString();
                        if (!Convert.IsDBNull(zRdr["STATUSRANK"])) _STATUSRANK = zRdr["STATUSRANK"].ToString();
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

        public bool GetDataByLOID(double cLOID, OracleTransaction trans)
        {
            return doGetdata("LOID = " + DB.SetDouble(cLOID) + " ", trans);
        }

        public DataTable GetDataListByConditions(double cDIVISION, string cNAME, double cBUDGETYEAR, string cQTCODE, string cREFPRSAP, string cSTATUSRANKFROM, string cSTATUSRANKTO, string orderBy, OracleTransaction trans)
        {
            string whText = "";
            if (cDIVISION != 0) whText += (whText == "" ? "" : "AND ") + "DIVISION = " + DB.SetDouble(cDIVISION) + " ";
            if (cNAME.Trim() != "") whText += (whText == "" ? "" : "AND ") + "UPPER(NAME) LIKE " + DB.SetString("%" + cNAME.ToUpper() + "%") + " ";
            if (cBUDGETYEAR != 0) whText += (whText == "" ? "" : "AND ") + "BUDGETYEAR = " + DB.SetDouble(cBUDGETYEAR) + " ";
            if (cQTCODE.Trim() != "") whText += (whText == "" ? "" : "AND ") + "UPPER(QTCODE) LIKE " + DB.SetString("%" + cQTCODE.ToUpper() + "%") + " ";
            if (cREFPRSAP.Trim() != "") whText += (whText == "" ? "" : "AND ") + "UPPER(REFPRSAP) LIKE " + DB.SetString("%" + cREFPRSAP.ToUpper() + "%") + " ";
            if (cSTATUSRANKFROM.Trim() != "") whText += (whText == "" ? "" : "AND ") + "STATUSRANK >= " + DB.SetString(cSTATUSRANKFROM) + " ";
            if (cSTATUSRANKTO.Trim() != "") whText += (whText == "" ? "" : "AND ") + "STATUSRANK <= " + DB.SetString(cSTATUSRANKTO) + " ";
            return GetDataList(whText, orderBy, trans);
        }
        public DataTable GetDataListByPlanOrder(double cPLANORDER, OracleTransaction trans)
        {
            return GetDataList("STATUS = 'CO' AND PLANORDER = " + DB.SetDouble(cPLANORDER) + " ", "", trans);
        }
    }
}