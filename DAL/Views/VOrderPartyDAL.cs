using System;
using System.Data;
using System.Data.OracleClient;
using DB = SHND.DAL.Utilities.OracleDB;
using SHND.Data.Common.Utilities;

namespace SHND.DAL.Views
{
    /// <summary>
    /// Represents a transaction for V_ORDERPARTY view.
    /// [Created by 127.0.0.1 on Febuary,5 2009]
    /// </summary>
    public class VOrderPartyDAL
    {

        public VOrderPartyDAL()
        {
        }

        #region Constant

        /// <summary>V_ORDERPARTY</summary>
        private const string viewName = "V_ORDERPARTY";

        #endregion

        #region Private Variables

        string _error = "";
        string _information = "";
        bool _OnDB = false;
        string _CODE = "";
        string _CREATEBY = "";
        DateTime _CREATEON = new DateTime(1, 1, 1);
        string _DESCRIPTION = "";
        string _DIRECTORAPPROVE = "";
        string _DIRECTORCOMMENT = "";
        double _DIVISION = 0;
        string _DIVISIONNAME = "";
        double _LOID = 0;
        string _NDAPPROVE = "";
        string _NDCOMMENT = "";
        string _OLASTNAME = "";
        string _ONAME = "";
        DateTime _ORDERDATE = new DateTime(1, 1, 1);
        string _OTEL = "";
        double _OTITLE = 0;
        DateTime _PARTYDATETIME = new DateTime(1, 1, 1);
        double _PARTYTYPE = 0;
        string _PARTYTYPENAME = "";
        string _PLACE = "";
        string _REFCODE = "";
        string _STATUS = "";
        string _STATUSNAME = "";
        string _STATUSRANK = "";
        string _UPDATEBY = "";
        DateTime _UPDATEON = new DateTime(1, 1, 1);
        double _VISITORQTY = 0;

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
        public string CODE
        {
            get { return _CODE; }
            set { _CODE = value; }
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
        public string DESCRIPTION
        {
            get { return _DESCRIPTION; }
            set { _DESCRIPTION = value; }
        }
        public string DIRECTORAPPROVE
        {
            get { return _DIRECTORAPPROVE; }
            set { _DIRECTORAPPROVE = value; }
        }
        public string DIRECTORCOMMENT
        {
            get { return _DIRECTORCOMMENT; }
            set { _DIRECTORCOMMENT = value; }
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
        public double LOID
        {
            get { return _LOID; }
            set { _LOID = value; }
        }
        public string NDAPPROVE
        {
            get { return _NDAPPROVE; }
            set { _NDAPPROVE = value; }
        }
        public string NDCOMMENT
        {
            get { return _NDCOMMENT; }
            set { _NDCOMMENT = value; }
        }
        public string OLASTNAME
        {
            get { return _OLASTNAME; }
            set { _OLASTNAME = value; }
        }
        public string ONAME
        {
            get { return _ONAME; }
            set { _ONAME = value; }
        }
        public DateTime ORDERDATE
        {
            get { return _ORDERDATE; }
            set { _ORDERDATE = value; }
        }
        public string OTEL
        {
            get { return _OTEL; }
            set { _OTEL = value; }
        }
        public double OTITLE
        {
            get { return _OTITLE; }
            set { _OTITLE = value; }
        }
        public DateTime PARTYDATETIME
        {
            get { return _PARTYDATETIME; }
            set { _PARTYDATETIME = value; }
        }
        public double PARTYTYPE
        {
            get { return _PARTYTYPE; }
            set { _PARTYTYPE = value; }
        }
        public string PARTYTYPENAME
        {
            get { return _PARTYTYPENAME; }
            set { _PARTYTYPENAME = value; }
        }
        public string PLACE
        {
            get { return _PLACE; }
            set { _PLACE = value; }
        }
        public string REFCODE
        {
            get { return _REFCODE; }
            set { _REFCODE = value; }
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
        public double VISITORQTY
        {
            get { return _VISITORQTY; }
            set { _VISITORQTY = value; }
        }

        #endregion

        #region Clear Data

        /// <summary>
        /// Initialize data.
        /// </summary>
        private void ClearData()
        {
            _CODE = "";
            _CREATEBY = "";
            _CREATEON = new DateTime(1, 1, 1);
            _DESCRIPTION = "";
            _DIRECTORAPPROVE = "";
            _DIRECTORCOMMENT = "";
            _DIVISION = 0;
            _DIVISIONNAME = "";
            _LOID = 0;
            _NDAPPROVE = "";
            _NDCOMMENT = "";
            _OLASTNAME = "";
            _ONAME = "";
            _ORDERDATE = new DateTime(1, 1, 1);
            _OTEL = "";
            _OTITLE = 0;
            _PARTYDATETIME = new DateTime(1, 1, 1);
            _PARTYTYPE = 0;
            _PARTYTYPENAME = "";
            _PLACE = "";
            _REFCODE = "";
            _STATUS = "";
            _STATUSNAME = "";
            _STATUSRANK = "";
            _UPDATEBY = "";
            _UPDATEON = new DateTime(1, 1, 1);
            _VISITORQTY = 0;
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

        public bool GetDataByLOID(double cLOID, OracleTransaction trans)
        {
            return doGetdata("LOID = " + DB.SetDouble(cLOID) + " ", trans);
        }

        public DataTable GetDataListByCondition(string CodeFrom, string CodeTo, DateTime DateFrom, DateTime DateTo, string StatusFrom, string StatusTo, string orderBy, OracleTransaction trans)
        {
            //build where clause
            string whStr = "";
            if (CodeFrom.ToString() != "") whStr += (whStr.Trim() == "" ? "" : " AND ") + " UPPER(CODE) >= " + DB.SetString(CodeFrom.ToUpper()) + " ";
            if (CodeTo.ToString() != "") whStr += (whStr.Trim() == "" ? "" : " AND ") + " UPPER(CODE) <= " + DB.SetString(CodeTo.ToUpper()) + " ";
            if (DateFrom.Year > 1) whStr += (whStr.Trim() == "" ? "" : " AND ") + "  TO_DATE(PARTYDATETIME)  >=  " + DB.SetDate(DateFrom) + " ";
            if (DateTo.Year > 1) whStr += (whStr.Trim() == "" ? "" : " AND ") + "  TO_DATE(PARTYDATETIME)  <=  " + DB.SetDate(DateTo) + "  ";
            if (StatusFrom.Trim() != "")
                whStr += (whStr.Trim() == "" ? "" : " AND ") + " STATUSRANK >= " + DB.SetString(StatusFrom.ToUpper()) + " ";
            if (StatusTo.Trim() != "")
                whStr += (whStr.Trim() == "" ? "" : " AND ") + " STATUSRANK <=  " + DB.SetString(StatusTo.ToUpper()) + " ";


            return GetDataList(whStr, orderBy, trans);
        }

        public DataTable GetDataListByDirector(string CodeFrom, string CodeTo, DateTime DateFrom, DateTime DateTo, string StatusFrom, string StatusTo, string orderBy, OracleTransaction trans)
        {
            //build where clause
            string whStr = "";
            if (CodeFrom.ToString() != "") whStr += (whStr.Trim() == "" ? "" : " AND ") + " UPPER(CODE) >= " + DB.SetString("%" + CodeFrom.ToUpper() + "%") + " ";
            if (CodeTo.ToString() != "") whStr += (whStr.Trim() == "" ? "" : " AND ") + " UPPER(CODE) <= " + DB.SetString("%" + CodeTo.ToUpper() + "%") + " ";
            if (DateFrom.Year > 1) whStr += (whStr.Trim() == "" ? "" : " AND ") + "  TO_DATE(PARTYDATETIME)  >=  " + DB.SetDate(DateFrom) + " ";
            if (DateTo.Year > 1) whStr += (whStr.Trim() == "" ? "" : " AND ") + "  TO_DATE(PARTYDATETIME)  <=  " + DB.SetDate(DateTo) + "  ";

            if (StatusFrom.Trim() == "03")
                whStr += (whStr.Trim() == "" ? "" : " AND ") + " STATUSRANK > " + DB.SetString(StatusFrom.ToUpper()) + " OR STATUSRANK =  " + DB.SetString(StatusTo.ToUpper()) + " AND NDAPPROVE = 'N') ";
            else 
                whStr += (whStr.Trim() == "" ? "" : " AND ") + " STATUSRANK >= " + DB.SetString(StatusFrom.ToUpper()) + " ";

            if (StatusTo.Trim() == "03")
                whStr += (whStr.Trim() == "" ? "" : " AND ") + " (STATUSRANK <  " + DB.SetString(StatusTo.ToUpper()) + " OR STATUSRANK =  " + DB.SetString(StatusTo.ToUpper()) + " AND NDAPPROVE = 'N') ";
            else 
                whStr += (whStr.Trim() == "" ? "" : " AND ") + " STATUSRANK <=  " + DB.SetString(StatusTo.ToUpper()) + " ";


            return GetDataList(whStr, orderBy, trans);
        }

        public DataTable GetDataListByOfficer(string CodeFrom, string CodeTo, DateTime DateFrom, DateTime DateTo, string StatusFrom, string StatusTo, string orderBy, OracleTransaction trans)
        {
            //build where clause
            string whStr = "";
            if (CodeFrom.ToString() != "") whStr += (whStr.Trim() == "" ? "" : " AND ") + " UPPER(CODE) >= " + DB.SetString("%" + CodeFrom.ToUpper() + "%") + " ";
            if (CodeTo.ToString() != "") whStr += (whStr.Trim() == "" ? "" : " AND ") + " UPPER(CODE) <= " + DB.SetString("%" + CodeTo.ToUpper() + "%") + " ";
            if (DateFrom.Year > 1) whStr += (whStr.Trim() == "" ? "" : " AND ") + "  TO_DATE(PARTYDATETIME)  >=  " + DB.SetDate(DateFrom) + " ";
            if (DateTo.Year > 1) whStr += (whStr.Trim() == "" ? "" : " AND ") + "  TO_DATE(PARTYDATETIME)  <=  " + DB.SetDate(DateTo) + "  ";

            if (StatusFrom.Trim() != "")
                whStr += (whStr.Trim() == "" ? "" : " AND ") + " STATUSRANK >= " + DB.SetString(StatusFrom.ToUpper()) + " ";

            if (StatusTo.Trim() != "")
                whStr += (whStr.Trim() == "" ? "" : " AND ") + " STATUSRANK <=  " + DB.SetString(StatusTo.ToUpper()) + " ";


            return GetDataList(whStr, orderBy, trans);
        }

        #endregion

        #region SQL Statements

        /// <summary>
        /// Gets the select statement for V_ORDERPARTY table.
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
        /// Returns an indication whether the record of V_ORDERPARTY by specified condition is retrieved successfully.
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
                        if (!Convert.IsDBNull(zRdr["CODE"])) _CODE = zRdr["CODE"].ToString();
                        if (!Convert.IsDBNull(zRdr["CREATEBY"])) _CREATEBY = zRdr["CREATEBY"].ToString();
                        if (!Convert.IsDBNull(zRdr["CREATEON"])) _CREATEON = Convert.ToDateTime(zRdr["CREATEON"]);
                        if (!Convert.IsDBNull(zRdr["DESCRIPTION"])) _DESCRIPTION = zRdr["DESCRIPTION"].ToString();
                        if (!Convert.IsDBNull(zRdr["DIRECTORAPPROVE"])) _DIRECTORAPPROVE = zRdr["DIRECTORAPPROVE"].ToString();
                        if (!Convert.IsDBNull(zRdr["DIRECTORCOMMENT"])) _DIRECTORCOMMENT = zRdr["DIRECTORCOMMENT"].ToString();
                        if (!Convert.IsDBNull(zRdr["DIVISION"])) _DIVISION = Convert.ToDouble(zRdr["DIVISION"]);
                        if (!Convert.IsDBNull(zRdr["DIVISIONNAME"])) _DIVISIONNAME = zRdr["DIVISIONNAME"].ToString();
                        if (!Convert.IsDBNull(zRdr["LOID"])) _LOID = Convert.ToDouble(zRdr["LOID"]);
                        if (!Convert.IsDBNull(zRdr["NDAPPROVE"])) _NDAPPROVE = zRdr["NDAPPROVE"].ToString();
                        if (!Convert.IsDBNull(zRdr["NDCOMMENT"])) _NDCOMMENT = zRdr["NDCOMMENT"].ToString();
                        if (!Convert.IsDBNull(zRdr["OLASTNAME"])) _OLASTNAME = zRdr["OLASTNAME"].ToString();
                        if (!Convert.IsDBNull(zRdr["ONAME"])) _ONAME = zRdr["ONAME"].ToString();
                        if (!Convert.IsDBNull(zRdr["ORDERDATE"])) _ORDERDATE = Convert.ToDateTime(zRdr["ORDERDATE"]);
                        if (!Convert.IsDBNull(zRdr["OTEL"])) _OTEL = zRdr["OTEL"].ToString();
                        if (!Convert.IsDBNull(zRdr["OTITLE"])) _OTITLE = Convert.ToDouble(zRdr["OTITLE"]);
                        if (!Convert.IsDBNull(zRdr["PARTYDATETIME"])) _PARTYDATETIME = Convert.ToDateTime(zRdr["PARTYDATETIME"]);
                        if (!Convert.IsDBNull(zRdr["PARTYTYPE"])) _PARTYTYPE = Convert.ToDouble(zRdr["PARTYTYPE"]);
                        if (!Convert.IsDBNull(zRdr["PARTYTYPENAME"])) _PARTYTYPENAME = zRdr["PARTYTYPENAME"].ToString();
                        if (!Convert.IsDBNull(zRdr["PLACE"])) _PLACE = zRdr["PLACE"].ToString();
                        if (!Convert.IsDBNull(zRdr["REFCODE"])) _REFCODE = zRdr["REFCODE"].ToString();
                        if (!Convert.IsDBNull(zRdr["STATUS"])) _STATUS = zRdr["STATUS"].ToString();
                        if (!Convert.IsDBNull(zRdr["STATUSNAME"])) _STATUSNAME = zRdr["STATUSNAME"].ToString();
                        if (!Convert.IsDBNull(zRdr["STATUSRANK"])) _STATUSRANK = zRdr["STATUSRANK"].ToString();
                        if (!Convert.IsDBNull(zRdr["UPDATEBY"])) _UPDATEBY = zRdr["UPDATEBY"].ToString();
                        if (!Convert.IsDBNull(zRdr["UPDATEON"])) _UPDATEON = Convert.ToDateTime(zRdr["UPDATEON"]);
                        if (!Convert.IsDBNull(zRdr["VISITORQTY"])) _VISITORQTY = Convert.ToDouble(zRdr["VISITORQTY"]);
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