using System;
using System.Data;
using System.Data.OracleClient;
using DB = SHND.DAL.Utilities.OracleDB;
using SHND.Data.Common.Utilities;

namespace SHND.DAL.Tables
{
    /// <summary>
    /// Represents a transaction for V_ORDERWELFARE view.
    /// [Created by 127.0.0.1 on January,14 2009]
    /// </summary>
    public class VOrderWelfareDAL
    {

        public VOrderWelfareDAL()
        {
        }

        #region Constant

        /// <summary>V_ORDERWELFARE</summary>
        private const string viewName = "V_ORDERWELFARE";

        #endregion

        #region Private Variables

        string _error = "";
        string _information = "";
        bool _OnDB = false;
        double _BD1 = 0;
        double _BD2 = 0;
        double _BD3 = 0;
        double _BD4 = 0;
        double _BD5 = 0;
        double _BD6 = 0;
        double _BD7 = 0;
        double _COUPON = 0;
        string _CREATEBY = "";
        double _DD1 = 0;
        double _DD2 = 0;
        double _DD3 = 0;
        double _DD4 = 0;
        double _DD5 = 0;
        double _DD6 = 0;
        double _DD7 = 0;
        double _DIVISION = 0;
        DateTime _FINISHDATE = new DateTime(1, 1, 1);
        string _ISSUBDIVISION = "";
        double _LD1 = 0;
        double _LD2 = 0;
        double _LD3 = 0;
        double _LD4 = 0;
        double _LD5 = 0;
        double _LD6 = 0;
        double _LD7 = 0;
        double _LOID = 0;
        double _MAINDIVISION = 0;
        string _NAME = "";
        string _ORDERCODE = "";
        DateTime _ORDERDATE = new DateTime(1, 1, 1);
        double _SUMQTY = 0;
        string _REFCODE = "";
        DateTime _REFDATE = new DateTime(1, 1, 1);
        DateTime _STARTDATE = new DateTime(1, 1, 1);
        string _STATUS = "";
        string _STATUSNAME = "";
        string _STATUSRANK = "";
        double _AMOUNT = 0;
        string _ISTIFFIN = "";

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
        public double BD1
        {
            get { return _BD1; }
            set { _BD1 = value; }
        }
        public double BD2
        {
            get { return _BD2; }
            set { _BD2 = value; }
        }
        public double BD3
        {
            get { return _BD3; }
            set { _BD3 = value; }
        }
        public double BD4
        {
            get { return _BD4; }
            set { _BD4 = value; }
        }
        public double BD5
        {
            get { return _BD5; }
            set { _BD5 = value; }
        }
        public double BD6
        {
            get { return _BD6; }
            set { _BD6 = value; }
        }
        public double BD7
        {
            get { return _BD7; }
            set { _BD7 = value; }
        }
        public double COUPON
        {
            get { return _COUPON; }
            set { _COUPON = value; }
        }
        public string CREATEBY
        {
            get { return _CREATEBY; }
            set { _CREATEBY = value; }
        }
        public double DD1
        {
            get { return _DD1; }
            set { _DD1 = value; }
        }
        public double DD2
        {
            get { return _DD2; }
            set { _DD2 = value; }
        }
        public double DD3
        {
            get { return _DD3; }
            set { _DD3 = value; }
        }
        public double DD4
        {
            get { return _DD4; }
            set { _DD4 = value; }
        }
        public double DD5
        {
            get { return _DD5; }
            set { _DD5 = value; }
        }
        public double DD6
        {
            get { return _DD6; }
            set { _DD6 = value; }
        }
        public double DD7
        {
            get { return _DD7; }
            set { _DD7 = value; }
        }
        public double DIVISION
        {
            get { return _DIVISION; }
            set { _DIVISION = value; }
        }
        public DateTime FINISHDATE
        {
            get { return _FINISHDATE; }
            set { _FINISHDATE = value; }
        }
        public string ISSUBDIVISION
        {
            get { return _ISSUBDIVISION; }
            set { _ISSUBDIVISION = value; }
        }
        public double LD1
        {
            get { return _LD1; }
            set { _LD1 = value; }
        }
        public double LD2
        {
            get { return _LD2; }
            set { _LD2 = value; }
        }
        public double LD3
        {
            get { return _LD3; }
            set { _LD3 = value; }
        }
        public double LD4
        {
            get { return _LD4; }
            set { _LD4 = value; }
        }
        public double LD5
        {
            get { return _LD5; }
            set { _LD5 = value; }
        }
        public double LD6
        {
            get { return _LD6; }
            set { _LD6 = value; }
        }
        public double LD7
        {
            get { return _LD7; }
            set { _LD7 = value; }
        }
        public double LOID
        {
            get { return _LOID; }
            set { _LOID = value; }
        }
        public double MAINDIVISION
        {
            get { return _MAINDIVISION; }
            set { _MAINDIVISION = value; }
        }
        public string NAME
        {
            get { return _NAME; }
            set { _NAME = value; }
        }
        public string ORDERCODE
        {
            get { return _ORDERCODE; }
            set { _ORDERCODE = value; }
        }
        public DateTime ORDERDATE
        {
            get { return _ORDERDATE; }
            set { _ORDERDATE = value; }
        }
        public double SUMQTY
        {
            get { return _SUMQTY; }
            set { _SUMQTY = value; }
        }
        public string REFCODE
        {
            get { return _REFCODE; }
            set { _REFCODE = value; }
        }
        public DateTime REFDATE
        {
            get { return _REFDATE; }
            set { _REFDATE = value; }
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
        public double AMOUNT
        {
            get { return _AMOUNT; }
            set { _AMOUNT = value; }
        }
        public string ISTIFFIN
        {
            get { return _ISTIFFIN; }
            set { _ISTIFFIN = value; }
        }

        #endregion

        #region Clear Data

        /// <summary>
        /// Initialize data.
        /// </summary>
        private void ClearData()
        {
            _BD1 = 0;
            _BD2 = 0;
            _BD3 = 0;
            _BD4 = 0;
            _BD5 = 0;
            _BD6 = 0;
            _BD7 = 0;
            _COUPON = 0;
            _CREATEBY = "";
            _DD1 = 0;
            _DD2 = 0;
            _DD3 = 0;
            _DD4 = 0;
            _DD5 = 0;
            _DD6 = 0;
            _DD7 = 0;
            _DIVISION = 0;
            _FINISHDATE = new DateTime(1, 1, 1);
            _ISSUBDIVISION = "";
            _LD1 = 0;
            _LD2 = 0;
            _LD3 = 0;
            _LD4 = 0;
            _LD5 = 0;
            _LD6 = 0;
            _LD7 = 0;
            _LOID = 0;
            _MAINDIVISION = 0;
            _NAME = "";
            _ORDERCODE = "";
            _ORDERDATE = new DateTime(1, 1, 1);
            _SUMQTY = 0;
            _REFCODE = "";
            _REFDATE = new DateTime(1, 1, 1);
            _STARTDATE = new DateTime(1, 1, 1);
            _STATUS = "";
            _STATUSNAME = "";
            _STATUSRANK = "";
            _ISTIFFIN = "";
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

        /// <summary>
        /// Returns an indication whether the record of ORDERWELFARE by specified LOID key is retrieved successfully.
        /// </summary>
        /// <param name="cLOID">The LOID key.</param>
        /// <param name="trans">The System.Data.OracleClient.OracleTransaction used by this System.Data.OracleClient.OracleCommand.</param>
        /// <returns>true if data is retrieved successfully; otherwise, false.</returns>
        public bool GetDataByLOID(double cLOID, OracleTransaction trans)
        {
            return doGetdata("LOID = " + DB.SetDouble(cLOID) + " ", trans);
        }

        #endregion

        #region SQL Statements

        /// <summary>
        /// Gets the select statement for V_ORDERWELFARE table.
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
        /// Returns an indication whether the record of V_ORDERWELFARE by specified condition is retrieved successfully.
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
                            if (!Convert.IsDBNull(zRdr["BD1"])) _BD1 = Convert.ToDouble(zRdr["BD1"]);
                            if (!Convert.IsDBNull(zRdr["BD2"])) _BD2 = Convert.ToDouble(zRdr["BD2"]);
                            if (!Convert.IsDBNull(zRdr["BD3"])) _BD3 = Convert.ToDouble(zRdr["BD3"]);
                            if (!Convert.IsDBNull(zRdr["BD4"])) _BD4 = Convert.ToDouble(zRdr["BD4"]);
                            if (!Convert.IsDBNull(zRdr["BD5"])) _BD5 = Convert.ToDouble(zRdr["BD5"]);
                            if (!Convert.IsDBNull(zRdr["BD6"])) _BD6 = Convert.ToDouble(zRdr["BD6"]);
                            if (!Convert.IsDBNull(zRdr["BD7"])) _BD7 = Convert.ToDouble(zRdr["BD7"]);
                            if (!Convert.IsDBNull(zRdr["COUPON"])) _COUPON = Convert.ToDouble(zRdr["COUPON"]);
                            if (!Convert.IsDBNull(zRdr["CREATEBY"])) _CREATEBY = zRdr["CREATEBY"].ToString();
                            if (!Convert.IsDBNull(zRdr["DD1"])) _DD1 = Convert.ToDouble(zRdr["DD1"]);
                            if (!Convert.IsDBNull(zRdr["DD2"])) _DD2 = Convert.ToDouble(zRdr["DD2"]);
                            if (!Convert.IsDBNull(zRdr["DD3"])) _DD3 = Convert.ToDouble(zRdr["DD3"]);
                            if (!Convert.IsDBNull(zRdr["DD4"])) _DD4 = Convert.ToDouble(zRdr["DD4"]);
                            if (!Convert.IsDBNull(zRdr["DD5"])) _DD5 = Convert.ToDouble(zRdr["DD5"]);
                            if (!Convert.IsDBNull(zRdr["DD6"])) _DD6 = Convert.ToDouble(zRdr["DD6"]);
                            if (!Convert.IsDBNull(zRdr["DD7"])) _DD7 = Convert.ToDouble(zRdr["DD7"]);
                            if (!Convert.IsDBNull(zRdr["DIVISION"])) _DIVISION = Convert.ToDouble(zRdr["DIVISION"]);
                            if (!Convert.IsDBNull(zRdr["FINISHDATE"])) _FINISHDATE = Convert.ToDateTime(zRdr["FINISHDATE"]);
                            if (!Convert.IsDBNull(zRdr["ISSUBDIVISION"])) _ISSUBDIVISION = zRdr["ISSUBDIVISION"].ToString();
                            if (!Convert.IsDBNull(zRdr["LD1"])) _LD1 = Convert.ToDouble(zRdr["LD1"]);
                            if (!Convert.IsDBNull(zRdr["LD2"])) _LD2 = Convert.ToDouble(zRdr["LD2"]);
                            if (!Convert.IsDBNull(zRdr["LD3"])) _LD3 = Convert.ToDouble(zRdr["LD3"]);
                            if (!Convert.IsDBNull(zRdr["LD4"])) _LD4 = Convert.ToDouble(zRdr["LD4"]);
                            if (!Convert.IsDBNull(zRdr["LD5"])) _LD5 = Convert.ToDouble(zRdr["LD5"]);
                            if (!Convert.IsDBNull(zRdr["LD6"])) _LD6 = Convert.ToDouble(zRdr["LD6"]);
                            if (!Convert.IsDBNull(zRdr["LD7"])) _LD7 = Convert.ToDouble(zRdr["LD7"]);
                            if (!Convert.IsDBNull(zRdr["LOID"])) _LOID = Convert.ToDouble(zRdr["LOID"]);
                            if (!Convert.IsDBNull(zRdr["SUMQTY"])) _SUMQTY = Convert.ToDouble(zRdr["SUMQTY"]);
                            if (!Convert.IsDBNull(zRdr["MAINDIVISION"])) _MAINDIVISION = Convert.ToDouble(zRdr["MAINDIVISION"]);
                            if (!Convert.IsDBNull(zRdr["NAME"])) _NAME = zRdr["NAME"].ToString();
                            if (!Convert.IsDBNull(zRdr["ORDERCODE"])) _ORDERCODE = zRdr["ORDERCODE"].ToString();
                            if (!Convert.IsDBNull(zRdr["ORDERDATE"])) _ORDERDATE = Convert.ToDateTime(zRdr["ORDERDATE"]);
                            if (!Convert.IsDBNull(zRdr["REFCODE"])) _REFCODE = zRdr["REFCODE"].ToString();
                            if (!Convert.IsDBNull(zRdr["REFDATE"])) _REFDATE = Convert.ToDateTime(zRdr["REFDATE"]);
                            if (!Convert.IsDBNull(zRdr["STARTDATE"])) _STARTDATE = Convert.ToDateTime(zRdr["STARTDATE"]);
                            if (!Convert.IsDBNull(zRdr["STATUS"])) _STATUS = zRdr["STATUS"].ToString();
                            if (!Convert.IsDBNull(zRdr["STATUSNAME"])) _STATUSNAME = zRdr["STATUSNAME"].ToString();
                            if (!Convert.IsDBNull(zRdr["STATUSRANK"])) _STATUSRANK = zRdr["STATUSRANK"].ToString();
                            if (!Convert.IsDBNull(zRdr["AMOUNT"])) _AMOUNT = Convert.ToDouble(zRdr["AMOUNT"]);
                            if (!Convert.IsDBNull(zRdr["ISTIFFIN"])) _ISTIFFIN = zRdr["ISTIFFIN"].ToString();

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

        public DataTable GetDataListByCondition(string cCODE, string cCODET, DateTime cDATE, DateTime cDATET, string cSTATUS, string cSTATUST, string orderBy, OracleTransaction trans)
        {
            //build where clause
            string whStr = "";

            if (cCODE.Trim() != "") whStr += (whStr.Trim() == "" ? "" : " AND ") + " UPPER(ORDERCODE)  >=   " + DB.SetString(cCODE.ToUpper()) + " ";
            if (cCODET.Trim() != "") whStr += (whStr.Trim() == "" ? "" : " AND ") + " UPPER(ORDERCODE)  <=  " + DB.SetString(cCODET.ToUpper()) + " ";
            //if (cCODE.Trim() != "" && cCODET.ToString() == "") whStr += (whStr.Trim() == "" ? "" : " AND ") + " ORDERCODE  <=   " + DB.SetString(cCODE.ToUpper()) + " ";

            if (cDATE.Year > 1) whStr += (whStr.Trim() == "" ? "" : " AND ") + "  TO_DATE(ORDERDATE)  >=  " + DB.SetDate(cDATE) + " ";
            if (cDATET.Year > 1) whStr += (whStr.Trim() == "" ? "" : " AND ") + "  TO_DATE(ORDERDATE)  <=  " + DB.SetDate(cDATET) + "  "; 

            if (cSTATUS.Trim() != "" && cSTATUS.ToString() != "0") whStr += (whStr.Trim() == "" ? "" : " AND ") + " STATUSRANK >= " + DB.SetString(cSTATUS.ToUpper()) + " ";
            if (cSTATUST.Trim() != "" && cSTATUST.ToString() != "0") whStr += (whStr.Trim() == "" ? "" : " AND ") + " STATUSRANK <=  " + DB.SetString(cSTATUST.ToUpper()) + " ";
            

            return GetDataList(whStr, orderBy, trans);
        }

        public double GetTiffin(double division, double monthfrom, double yearfrom, double monthto, double yearto)
        {
            string sql = "SELECT PKE_ORDER.FN_CALWELFARERIGHTQTY (" +division + "," + monthfrom + "," + yearfrom + "," + monthto + "," + yearto + ") CNT FROM DUAL" ;

            DataTable dt = DB.ExecuteTable(sql);
            double tiffin = 0;
            tiffin = Convert.ToDouble(dt.Rows[0]["CNT"]);
            return tiffin;
        }
        public string GetTiffinOver(double division, double monthfrom, double yearfrom, double monthto, double yearto)
        {
            string sql = "SELECT PKE_ORDER.FN_GETWELFAREOVER (" + division + "," + monthfrom + "," + yearfrom + "," + monthto + "," + yearto + ") CNT FROM DUAL";

            DataTable dt = DB.ExecuteTable(sql);
            string tiffin = "";
            tiffin = dt.Rows[0]["CNT"].ToString();
            return tiffin;
        }
    }
}