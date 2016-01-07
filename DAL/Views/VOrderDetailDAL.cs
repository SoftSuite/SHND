using System;
using System.Data;
using System.Data.OracleClient;
using DB = SHND.DAL.Utilities.OracleDB;
using SHND.Data.Common.Utilities;

namespace SHND.DAL.Views
{
    /// <summary>
    /// Represents a transaction for V_ORDERDETAIL view.
    /// [Created by 127.0.0.1 on March,10 2009]
    /// </summary>
    public class VOrderDetailDAL
    {
        string _ward = "";
        public string ward { get { return _ward; } }

        public VOrderDetailDAL()
        {
        }

        #region Constant

        /// <summary>V_ORDERDETAIL</summary>
        private const string viewName = "V_ORDERDETAIL";

        #endregion

        #region Private Variables

        string _error = "";
        string _information = "";
        bool _OnDB = false;
        string _ABSTAINOTHER = "";
        double _ADMITPATIENT = 0;
        double _BREAKFAST = 0;
        double _CAPACITY = 0;
        double _CAPACITYRATE = 0;
        string _CATEGORYNAME = "";
        string _CREATEBY = "";
        DateTime _CREATEON = new DateTime(1, 1, 1);
        double _DINNER = 0;
        double _DOCTOR = 0;
        string _EATMETHOD = "";
        DateTime _ENDDATE = new DateTime(1, 1, 1);
        string _ENDMEAL = "";
        string _ENDTIME = "";
        double _ENERGY = 0;
        double _ENERGYRATE = 0;
        string _FEEDCATEGORY = "";
        DateTime _FIRSTDATE = new DateTime(1, 1, 1);
        DateTime _FIRSTDATEREGIS = new DateTime(1, 1, 1);
        string _FIRSTMEAL = "";
        string _FIRSTMEALREGIS = "";
        string _FIRSTTIME = "";
        double _FOODCATEGORY = 0;
        double _FOODTYPE = 0;
        double _FORMULAFEED = 0;
        string _ISABSTAIN = "";
        string _ISCALCULATE = "";
        string _ISDOCTORORDER = "";
        string _ISFAMILY = "";
        string _ISINCREASE = "";
        string _ISNEED = "";
        string _ISNPO = "";
        string _ISREGISTER = "";
        string _ISREQUEST = "";
        string _ISSPECIFIC = "";
        string _ISSPIN = "";
        double _LOID = 0;
        double _LUNCH = 0;
        double _MATERIALMASTER = 0;
        double _MEALQTY = 0;
        double _MILKCATEGORY = 0;
        string _NEEDOTHER = "";
        double _NURSE = 0;
        double _ORDERBY = 0;
        DateTime _ORDERDATE = new DateTime(1, 1, 1);
        string _REFTABLE = "";
        string _OWNER = "";
        string _OWNERTEXT = "";
        DateTime _REGISTERDATE = new DateTime(1, 1, 1);
        string _REMARKS = "";
        string _REQUESTOTHER = "";
        string _STATUS = "";
        string _STATUSNAME = "";
        string _STATUSRANK = "";
        string _TIME1 = "";
        string _TIME10 = "";
        string _TIME11 = "";
        string _TIME12 = "";
        string _TIME13 = "";
        string _TIME14 = "";
        string _TIME15 = "";
        string _TIME16 = "";
        string _TIME17 = "";
        string _TIME18 = "";
        string _TIME19 = "";
        string _TIME2 = "";
        string _TIME20 = "";
        string _TIME21 = "";
        string _TIME22 = "";
        string _TIME23 = "";
        string _TIME24 = "";
        string _TIME3 = "";
        string _TIME4 = "";
        string _TIME5 = "";
        string _TIME6 = "";
        string _TIME7 = "";
        string _TIME8 = "";
        string _TIME9 = "";
        string _UNREGISREASON = "";
        string _UPDATEBY = "";
        DateTime _UPDATEON = new DateTime(1, 1, 1);
        string _VIPTYPE = "";
        double _VOLUMN = 0;
        string _WHO = "";

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
        public string ABSTAINOTHER
        {
            get { return _ABSTAINOTHER; }
            set { _ABSTAINOTHER = value; }
        }
        public double ADMITPATIENT
        {
            get { return _ADMITPATIENT; }
            set { _ADMITPATIENT = value; }
        }
        public double BREAKFAST
        {
            get { return _BREAKFAST; }
            set { _BREAKFAST = value; }
        }
        public double CAPACITY
        {
            get { return _CAPACITY; }
            set { _CAPACITY = value; }
        }
        public double CAPACITYRATE
        {
            get { return _CAPACITYRATE; }
            set { _CAPACITYRATE = value; }
        }
        public string CATEGORYNAME
        {
            get { return _CATEGORYNAME; }
            set { _CATEGORYNAME = value; }
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
        public double DINNER
        {
            get { return _DINNER; }
            set { _DINNER = value; }
        }
        public double DOCTOR
        {
            get { return _DOCTOR; }
            set { _DOCTOR = value; }
        }
        public string EATMETHOD
        {
            get { return _EATMETHOD; }
            set { _EATMETHOD = value; }
        }
        public DateTime ENDDATE
        {
            get { return _ENDDATE; }
            set { _ENDDATE = value; }
        }
        public string ENDMEAL
        {
            get { return _ENDMEAL; }
            set { _ENDMEAL = value; }
        }
        public string ENDTIME
        {
            get { return _ENDTIME; }
            set { _ENDTIME = value; }
        }
        public double ENERGY
        {
            get { return _ENERGY; }
            set { _ENERGY = value; }
        }
        public double ENERGYRATE
        {
            get { return _ENERGYRATE; }
            set { _ENERGYRATE = value; }
        }
        public string FEEDCATEGORY
        {
            get { return _FEEDCATEGORY; }
            set { _FEEDCATEGORY = value; }
        }
        public DateTime FIRSTDATE
        {
            get { return _FIRSTDATE; }
            set { _FIRSTDATE = value; }
        }
        public DateTime FIRSTDATEREGIS
        {
            get { return _FIRSTDATEREGIS; }
            set { _FIRSTDATEREGIS = value; }
        }
        public string FIRSTMEAL
        {
            get { return _FIRSTMEAL; }
            set { _FIRSTMEAL = value; }
        }
        public string FIRSTMEALREGIS
        {
            get { return _FIRSTMEALREGIS; }
            set { _FIRSTMEALREGIS = value; }
        }
        public string FIRSTTIME
        {
            get { return _FIRSTTIME; }
            set { _FIRSTTIME = value; }
        }
        public double FOODCATEGORY
        {
            get { return _FOODCATEGORY; }
            set { _FOODCATEGORY = value; }
        }
        public double FOODTYPE
        {
            get { return _FOODTYPE; }
            set { _FOODTYPE = value; }
        }
        public double FORMULAFEED
        {
            get { return _FORMULAFEED; }
            set { _FORMULAFEED = value; }
        }
        public string ISABSTAIN
        {
            get { return _ISABSTAIN; }
            set { _ISABSTAIN = value; }
        }
        public string ISCALCULATE
        {
            get { return _ISCALCULATE; }
            set { _ISCALCULATE = value; }
        }
        public string ISDOCTORORDER
        {
            get { return _ISDOCTORORDER; }
            set { _ISDOCTORORDER = value; }
        }
        public string ISFAMILY
        {
            get { return _ISFAMILY; }
            set { _ISFAMILY = value; }
        }
        public string ISINCREASE
        {
            get { return _ISINCREASE; }
            set { _ISINCREASE = value; }
        }
        public string ISNEED
        {
            get { return _ISNEED; }
            set { _ISNEED = value; }
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
        public string ISREQUEST
        {
            get { return _ISREQUEST; }
            set { _ISREQUEST = value; }
        }
        public string ISSPECIFIC
        {
            get { return _ISSPECIFIC; }
            set { _ISSPECIFIC = value; }
        }
        public string ISSPIN
        {
            get { return _ISSPIN; }
            set { _ISSPIN = value; }
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
        public double MATERIALMASTER
        {
            get { return _MATERIALMASTER; }
            set { _MATERIALMASTER = value; }
        }
        public double MEALQTY
        {
            get { return _MEALQTY; }
            set { _MEALQTY = value; }
        }
        public double MILKCATEGORY
        {
            get { return _MILKCATEGORY; }
            set { _MILKCATEGORY = value; }
        }
        public string NEEDOTHER
        {
            get { return _NEEDOTHER; }
            set { _NEEDOTHER = value; }
        }
        public double NURSE
        {
            get { return _NURSE; }
            set { _NURSE = value; }
        }
        public double ORDERBY
        {
            get { return _ORDERBY; }
            set { _ORDERBY = value; }
        }
        public DateTime ORDERDATE
        {
            get { return _ORDERDATE; }
            set { _ORDERDATE = value; }
        }
        public string REFTABLE
        {
            get { return _REFTABLE; }
            set { _REFTABLE = value; }
        }
        public string OWNER
        {
            get { return _OWNER; }
            set { _OWNER = value; }
        }
        public string OWNERTEXT
        {
            get { return _OWNERTEXT; }
            set { _OWNERTEXT = value; }
        }
        public DateTime REGISTERDATE
        {
            get { return _REGISTERDATE; }
            set { _REGISTERDATE = value; }
        }
        public string REMARKS
        {
            get { return _REMARKS; }
            set { _REMARKS = value; }
        }
        public string REQUESTOTHER
        {
            get { return _REQUESTOTHER; }
            set { _REQUESTOTHER = value; }
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
        public string TIME1
        {
            get { return _TIME1; }
            set { _TIME1 = value; }
        }
        public string TIME10
        {
            get { return _TIME10; }
            set { _TIME10 = value; }
        }
        public string TIME11
        {
            get { return _TIME11; }
            set { _TIME11 = value; }
        }
        public string TIME12
        {
            get { return _TIME12; }
            set { _TIME12 = value; }
        }
        public string TIME13
        {
            get { return _TIME13; }
            set { _TIME13 = value; }
        }
        public string TIME14
        {
            get { return _TIME14; }
            set { _TIME14 = value; }
        }
        public string TIME15
        {
            get { return _TIME15; }
            set { _TIME15 = value; }
        }
        public string TIME16
        {
            get { return _TIME16; }
            set { _TIME16 = value; }
        }
        public string TIME17
        {
            get { return _TIME17; }
            set { _TIME17 = value; }
        }
        public string TIME18
        {
            get { return _TIME18; }
            set { _TIME18 = value; }
        }
        public string TIME19
        {
            get { return _TIME19; }
            set { _TIME19 = value; }
        }
        public string TIME2
        {
            get { return _TIME2; }
            set { _TIME2 = value; }
        }
        public string TIME20
        {
            get { return _TIME20; }
            set { _TIME20 = value; }
        }
        public string TIME21
        {
            get { return _TIME21; }
            set { _TIME21 = value; }
        }
        public string TIME22
        {
            get { return _TIME22; }
            set { _TIME22 = value; }
        }
        public string TIME23
        {
            get { return _TIME23; }
            set { _TIME23 = value; }
        }
        public string TIME24
        {
            get { return _TIME24; }
            set { _TIME24 = value; }
        }
        public string TIME3
        {
            get { return _TIME3; }
            set { _TIME3 = value; }
        }
        public string TIME4
        {
            get { return _TIME4; }
            set { _TIME4 = value; }
        }
        public string TIME5
        {
            get { return _TIME5; }
            set { _TIME5 = value; }
        }
        public string TIME6
        {
            get { return _TIME6; }
            set { _TIME6 = value; }
        }
        public string TIME7
        {
            get { return _TIME7; }
            set { _TIME7 = value; }
        }
        public string TIME8
        {
            get { return _TIME8; }
            set { _TIME8 = value; }
        }
        public string TIME9
        {
            get { return _TIME9; }
            set { _TIME9 = value; }
        }
        public string UNREGISREASON
        {
            get { return _UNREGISREASON; }
            set { _UNREGISREASON = value; }
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
        public string VIPTYPE
        {
            get { return _VIPTYPE; }
            set { _VIPTYPE = value; }
        }
        public double VOLUMN
        {
            get { return _VOLUMN; }
            set { _VOLUMN = value; }
        }
        public string WHO
        {
            get { return _WHO; }
            set { _WHO = value; }
        }

        #endregion

        #region Clear Data

        /// <summary>
        /// Initialize data.
        /// </summary>
        private void ClearData()
        {
            _ABSTAINOTHER = "";
            _ADMITPATIENT = 0;
            _BREAKFAST = 0;
            _CAPACITY = 0;
            _CAPACITYRATE = 0;
            _CATEGORYNAME = "";
            _CREATEBY = "";
            _CREATEON = new DateTime(1, 1, 1);
            _DINNER = 0;
            _DOCTOR = 0;
            _EATMETHOD = "";
            _ENDDATE = new DateTime(1, 1, 1);
            _ENDMEAL = "";
            _ENDTIME = "";
            _ENERGY = 0;
            _ENERGYRATE = 0;
            _FEEDCATEGORY = "";
            _FIRSTDATE = new DateTime(1, 1, 1);
            _FIRSTDATEREGIS = new DateTime(1, 1, 1);
            _FIRSTMEAL = "";
            _FIRSTMEALREGIS = "";
            _FIRSTTIME = "";
            _FOODCATEGORY = 0;
            _FOODTYPE = 0;
            _FORMULAFEED = 0;
            _ISABSTAIN = "";
            _ISCALCULATE = "";
            _ISDOCTORORDER = "";
            _ISFAMILY = "";
            _ISINCREASE = "";
            _ISNEED = "";
            _ISNPO = "";
            _ISREGISTER = "";
            _ISREQUEST = "";
            _ISSPECIFIC = "";
            _ISSPIN = "";
            _LOID = 0;
            _LUNCH = 0;
            _MATERIALMASTER = 0;
            _MEALQTY = 0;
            _MILKCATEGORY = 0;
            _NEEDOTHER = "";
            _NURSE = 0;
            _ORDERBY = 0;
            _ORDERDATE = new DateTime(1, 1, 1);
            _REFTABLE = "";
            _OWNER = "";
            _OWNERTEXT = "";
            _REGISTERDATE = new DateTime(1, 1, 1);
            _REMARKS = "";
            _REQUESTOTHER = "";
            _STATUS = "";
            _STATUSNAME = "";
            _STATUSRANK = "";
            _TIME1 = "";
            _TIME10 = "";
            _TIME11 = "";
            _TIME12 = "";
            _TIME13 = "";
            _TIME14 = "";
            _TIME15 = "";
            _TIME16 = "";
            _TIME17 = "";
            _TIME18 = "";
            _TIME19 = "";
            _TIME2 = "";
            _TIME20 = "";
            _TIME21 = "";
            _TIME22 = "";
            _TIME23 = "";
            _TIME24 = "";
            _TIME3 = "";
            _TIME4 = "";
            _TIME5 = "";
            _TIME6 = "";
            _TIME7 = "";
            _TIME8 = "";
            _TIME9 = "";
            _UNREGISREASON = "";
            _UPDATEBY = "";
            _UPDATEON = new DateTime(1, 1, 1);
            _VIPTYPE = "";
            _VOLUMN = 0;
            _WHO = "";
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
        /// Gets the select statement for V_ORDERDETAIL table.
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
        /// Returns an indication whether the record of V_ORDERDETAIL by specified condition is retrieved successfully.
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
                        if (!Convert.IsDBNull(zRdr["ABSTAINOTHER"])) _ABSTAINOTHER = zRdr["ABSTAINOTHER"].ToString();
                        if (!Convert.IsDBNull(zRdr["ADMITPATIENT"])) _ADMITPATIENT = Convert.ToDouble(zRdr["ADMITPATIENT"]);
                        if (!Convert.IsDBNull(zRdr["BREAKFAST"])) _BREAKFAST = Convert.ToDouble(zRdr["BREAKFAST"]);
                        if (!Convert.IsDBNull(zRdr["CAPACITY"])) _CAPACITY = Convert.ToDouble(zRdr["CAPACITY"]);
                        if (!Convert.IsDBNull(zRdr["CAPACITYRATE"])) _CAPACITYRATE = Convert.ToDouble(zRdr["CAPACITYRATE"]);
                        if (!Convert.IsDBNull(zRdr["CATEGORYNAME"])) _CATEGORYNAME = zRdr["CATEGORYNAME"].ToString();
                        if (!Convert.IsDBNull(zRdr["CREATEBY"])) _CREATEBY = zRdr["CREATEBY"].ToString();
                        if (!Convert.IsDBNull(zRdr["CREATEON"])) _CREATEON = Convert.ToDateTime(zRdr["CREATEON"]);
                        if (!Convert.IsDBNull(zRdr["DINNER"])) _DINNER = Convert.ToDouble(zRdr["DINNER"]);
                        if (!Convert.IsDBNull(zRdr["DOCTOR"])) _DOCTOR = Convert.ToDouble(zRdr["DOCTOR"]);
                        if (!Convert.IsDBNull(zRdr["EATMETHOD"])) _EATMETHOD = zRdr["EATMETHOD"].ToString();
                        if (!Convert.IsDBNull(zRdr["ENDDATE"])) _ENDDATE = Convert.ToDateTime(zRdr["ENDDATE"]);
                        if (!Convert.IsDBNull(zRdr["ENDMEAL"])) _ENDMEAL = zRdr["ENDMEAL"].ToString();
                        if (!Convert.IsDBNull(zRdr["ENDTIME"])) _ENDTIME = zRdr["ENDTIME"].ToString();
                        if (!Convert.IsDBNull(zRdr["ENERGY"])) _ENERGY = Convert.ToDouble(zRdr["ENERGY"]);
                        if (!Convert.IsDBNull(zRdr["ENERGYRATE"])) _ENERGYRATE = Convert.ToDouble(zRdr["ENERGYRATE"]);
                        if (!Convert.IsDBNull(zRdr["FEEDCATEGORY"])) _FEEDCATEGORY = zRdr["FEEDCATEGORY"].ToString();
                        if (!Convert.IsDBNull(zRdr["FIRSTDATE"])) _FIRSTDATE = Convert.ToDateTime(zRdr["FIRSTDATE"]);
                        if (!Convert.IsDBNull(zRdr["FIRSTDATEREGIS"])) _FIRSTDATEREGIS = Convert.ToDateTime(zRdr["FIRSTDATEREGIS"]);
                        if (!Convert.IsDBNull(zRdr["FIRSTMEAL"])) _FIRSTMEAL = zRdr["FIRSTMEAL"].ToString();
                        if (!Convert.IsDBNull(zRdr["FIRSTMEALREGIS"])) _FIRSTMEALREGIS = zRdr["FIRSTMEALREGIS"].ToString();
                        if (!Convert.IsDBNull(zRdr["FIRSTTIME"])) _FIRSTTIME = zRdr["FIRSTTIME"].ToString();
                        if (!Convert.IsDBNull(zRdr["FOODCATEGORY"])) _FOODCATEGORY = Convert.ToDouble(zRdr["FOODCATEGORY"]);
                        if (!Convert.IsDBNull(zRdr["FOODTYPE"])) _FOODTYPE = Convert.ToDouble(zRdr["FOODTYPE"]);
                        if (!Convert.IsDBNull(zRdr["FORMULAFEED"])) _FORMULAFEED = Convert.ToDouble(zRdr["FORMULAFEED"]);
                        if (!Convert.IsDBNull(zRdr["ISABSTAIN"])) _ISABSTAIN = zRdr["ISABSTAIN"].ToString();
                        if (!Convert.IsDBNull(zRdr["ISCALCULATE"])) _ISCALCULATE = zRdr["ISCALCULATE"].ToString();
                        if (!Convert.IsDBNull(zRdr["ISDOCTORORDER"])) _ISDOCTORORDER = zRdr["ISDOCTORORDER"].ToString();
                        if (!Convert.IsDBNull(zRdr["ISFAMILY"])) _ISFAMILY = zRdr["ISFAMILY"].ToString();
                        if (!Convert.IsDBNull(zRdr["ISINCREASE"])) _ISINCREASE = zRdr["ISINCREASE"].ToString();
                        if (!Convert.IsDBNull(zRdr["ISNEED"])) _ISNEED = zRdr["ISNEED"].ToString();
                        if (!Convert.IsDBNull(zRdr["ISNPO"])) _ISNPO = zRdr["ISNPO"].ToString();
                        if (!Convert.IsDBNull(zRdr["ISREGISTER"])) _ISREGISTER = zRdr["ISREGISTER"].ToString();
                        if (!Convert.IsDBNull(zRdr["ISREQUEST"])) _ISREQUEST = zRdr["ISREQUEST"].ToString();
                        if (!Convert.IsDBNull(zRdr["ISSPECIFIC"])) _ISSPECIFIC = zRdr["ISSPECIFIC"].ToString();
                        if (!Convert.IsDBNull(zRdr["ISSPIN"])) _ISSPIN = zRdr["ISSPIN"].ToString();
                        if (!Convert.IsDBNull(zRdr["LOID"])) _LOID = Convert.ToDouble(zRdr["LOID"]);
                        if (!Convert.IsDBNull(zRdr["LUNCH"])) _LUNCH = Convert.ToDouble(zRdr["LUNCH"]);
                        if (!Convert.IsDBNull(zRdr["MATERIALMASTER"])) _MATERIALMASTER = Convert.ToDouble(zRdr["MATERIALMASTER"]);
                        if (!Convert.IsDBNull(zRdr["MEALQTY"])) _MEALQTY = Convert.ToDouble(zRdr["MEALQTY"]);
                        if (!Convert.IsDBNull(zRdr["MILKCATEGORY"])) _MILKCATEGORY = Convert.ToDouble(zRdr["MILKCATEGORY"]);
                        if (!Convert.IsDBNull(zRdr["NEEDOTHER"])) _NEEDOTHER = zRdr["NEEDOTHER"].ToString();
                        if (!Convert.IsDBNull(zRdr["NURSE"])) _NURSE = Convert.ToDouble(zRdr["NURSE"]);
                        if (!Convert.IsDBNull(zRdr["ORDERBY"])) _ORDERBY = Convert.ToDouble(zRdr["ORDERBY"]);
                        if (!Convert.IsDBNull(zRdr["ORDERDATE"])) _ORDERDATE = Convert.ToDateTime(zRdr["ORDERDATE"]);
                        if (!Convert.IsDBNull(zRdr["REFTABLE"])) _REFTABLE = zRdr["REFTABLE"].ToString();
                        if (!Convert.IsDBNull(zRdr["OWNER"])) _OWNER = zRdr["OWNER"].ToString();
                        if (!Convert.IsDBNull(zRdr["OWNERTEXT"])) _OWNERTEXT = zRdr["OWNERTEXT"].ToString();
                        if (!Convert.IsDBNull(zRdr["REGISTERDATE"])) _REGISTERDATE = Convert.ToDateTime(zRdr["REGISTERDATE"]);
                        if (!Convert.IsDBNull(zRdr["REMARKS"])) _REMARKS = zRdr["REMARKS"].ToString();
                        if (!Convert.IsDBNull(zRdr["REQUESTOTHER"])) _REQUESTOTHER = zRdr["REQUESTOTHER"].ToString();
                        if (!Convert.IsDBNull(zRdr["STATUS"])) _STATUS = zRdr["STATUS"].ToString();
                        if (!Convert.IsDBNull(zRdr["STATUSNAME"])) _STATUSNAME = zRdr["STATUSNAME"].ToString();
                        if (!Convert.IsDBNull(zRdr["STATUSRANK"])) _STATUSRANK = zRdr["STATUSRANK"].ToString();
                        if (!Convert.IsDBNull(zRdr["TIME1"])) _TIME1 = zRdr["TIME1"].ToString();
                        if (!Convert.IsDBNull(zRdr["TIME10"])) _TIME10 = zRdr["TIME10"].ToString();
                        if (!Convert.IsDBNull(zRdr["TIME11"])) _TIME11 = zRdr["TIME11"].ToString();
                        if (!Convert.IsDBNull(zRdr["TIME12"])) _TIME12 = zRdr["TIME12"].ToString();
                        if (!Convert.IsDBNull(zRdr["TIME13"])) _TIME13 = zRdr["TIME13"].ToString();
                        if (!Convert.IsDBNull(zRdr["TIME14"])) _TIME14 = zRdr["TIME14"].ToString();
                        if (!Convert.IsDBNull(zRdr["TIME15"])) _TIME15 = zRdr["TIME15"].ToString();
                        if (!Convert.IsDBNull(zRdr["TIME16"])) _TIME16 = zRdr["TIME16"].ToString();
                        if (!Convert.IsDBNull(zRdr["TIME17"])) _TIME17 = zRdr["TIME17"].ToString();
                        if (!Convert.IsDBNull(zRdr["TIME18"])) _TIME18 = zRdr["TIME18"].ToString();
                        if (!Convert.IsDBNull(zRdr["TIME19"])) _TIME19 = zRdr["TIME19"].ToString();
                        if (!Convert.IsDBNull(zRdr["TIME2"])) _TIME2 = zRdr["TIME2"].ToString();
                        if (!Convert.IsDBNull(zRdr["TIME20"])) _TIME20 = zRdr["TIME20"].ToString();
                        if (!Convert.IsDBNull(zRdr["TIME21"])) _TIME21 = zRdr["TIME21"].ToString();
                        if (!Convert.IsDBNull(zRdr["TIME22"])) _TIME22 = zRdr["TIME22"].ToString();
                        if (!Convert.IsDBNull(zRdr["TIME23"])) _TIME23 = zRdr["TIME23"].ToString();
                        if (!Convert.IsDBNull(zRdr["TIME24"])) _TIME24 = zRdr["TIME24"].ToString();
                        if (!Convert.IsDBNull(zRdr["TIME3"])) _TIME3 = zRdr["TIME3"].ToString();
                        if (!Convert.IsDBNull(zRdr["TIME4"])) _TIME4 = zRdr["TIME4"].ToString();
                        if (!Convert.IsDBNull(zRdr["TIME5"])) _TIME5 = zRdr["TIME5"].ToString();
                        if (!Convert.IsDBNull(zRdr["TIME6"])) _TIME6 = zRdr["TIME6"].ToString();
                        if (!Convert.IsDBNull(zRdr["TIME7"])) _TIME7 = zRdr["TIME7"].ToString();
                        if (!Convert.IsDBNull(zRdr["TIME8"])) _TIME8 = zRdr["TIME8"].ToString();
                        if (!Convert.IsDBNull(zRdr["TIME9"])) _TIME9 = zRdr["TIME9"].ToString();
                        if (!Convert.IsDBNull(zRdr["UNREGISREASON"])) _UNREGISREASON = zRdr["UNREGISREASON"].ToString();
                        if (!Convert.IsDBNull(zRdr["UPDATEBY"])) _UPDATEBY = zRdr["UPDATEBY"].ToString();
                        if (!Convert.IsDBNull(zRdr["UPDATEON"])) _UPDATEON = Convert.ToDateTime(zRdr["UPDATEON"]);
                        if (!Convert.IsDBNull(zRdr["VIPTYPE"])) _VIPTYPE = zRdr["VIPTYPE"].ToString();
                        if (!Convert.IsDBNull(zRdr["VOLUMN"])) _VOLUMN = Convert.ToDouble(zRdr["VOLUMN"]);
                        if (!Convert.IsDBNull(zRdr["WHO"])) _WHO = zRdr["WHO"].ToString();
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

        public DataTable GetDataListByConditions(double cADMITPATIENT, string orderBy, OracleTransaction trans)
        {
            return GetDataList("ADMITPATIENT = " + DB.SetDouble(cADMITPATIENT) + " AND STATUS <> 'DC' ", orderBy, trans);
        }
        public bool CheckANWard(double cWARD, double cADMITPATIENT, OracleTransaction trans)
        {
            double total = 0;
            string sql = "SELECT WARDNAME FROM " + viewName + " WHERE STATUS IN ('FN','RG') AND WARD <> " + DB.SetDouble(cWARD) + " AND AN IN (SELECT DISTINCT AN FROM " + viewName + " WHERE ADMITPATIENT = " + DB.SetDouble(cADMITPATIENT) + ") ";
            DataTable dt = DB.ExecuteTable(sql);
            total = dt.Rows.Count;
            if (total > 0)
            { 
            _ward = dt.Rows[0]["WARDNAME"].ToString();
            return true;
            }
            else
                return false;
        }
    }
}