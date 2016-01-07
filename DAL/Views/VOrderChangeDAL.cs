using System;
using System.Data;
using System.Data.OracleClient;
using DB = SHND.DAL.Utilities.OracleDB;
using SHND.Data.Common.Utilities;

namespace SHND.DAL.Views
{
    /// <summary>
    /// Represents a transaction for V_ORDER_CHANGE view.
    /// [Created by 127.0.0.1 on April,24 2009]
    /// </summary>
    public class VOrderChangeDAL
    {

        public VOrderChangeDAL()
        {
        }

        #region Constant

        /// <summary>V_ORDER_CHANGE</summary>
        private const string viewName = "V_ORDER_CHANGE";

        #endregion

        #region Private Variables

        string _error = "";
        string _information = "";
        bool _OnDB = false;
        string _ABSTAIN = "";
        string _ABSTAIN_NEW = "";
        double _ADMITPATIENT = 0;
        string _AGE = "";
        string _AN = "";
        string _BEDNO = "";
        string _BMI = "";
        string _CONTROL = "";
        string _CONTROL_NEW = "";
        DateTime _ENDDATE_OLD = new DateTime(1, 1, 1);
        double _FOODCATEGORYID_NEW = 0;
        double _FOODCATEGORYID_OLD = 0;
        string _FOODCATEGORYNAME = "";
        string _FOODCATEGORYNAME_NEW = "";
        double _FOODTYPEID_NEW = 0;
        double _FOODTYPEID_OLD = 0;
        string _FOODTYPENAME = "";
        string _FOODTYPENAME_NEW = "";
        double _HEIGHT = 0;
        string _HN = "";
        string _INCREASE = "";
        string _INCREASE_NEW = "";
        string _LIMIT = "";
        string _LIMIT_NEW = "";
        string _NEED = "";
        string _NEED_NEW = "";
        DateTime _ORDERDATE = new DateTime(1, 1, 1);
        DateTime _ORDERDATE_NEW = new DateTime(1, 1, 1);
        double _ORDERMEDID = 0;
        double _ORDERNONMEDID = 0;
        string _PATIENTNAME = "";
        string _QTY = "";
        string _QTY_NEW = "";
        string _REFMEDTABLE = "";
        string _REMARKS = "";
        string _REMARKS_NEW = "";
        string _ROOMNO = "";
        string _STATUS = "";
        string _STATUS_NEW = "";
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
        public string ABSTAIN_NEW
        {
            get { return _ABSTAIN_NEW; }
            set { _ABSTAIN_NEW = value; }
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
        public string CONTROL_NEW
        {
            get { return _CONTROL_NEW; }
            set { _CONTROL_NEW = value; }
        }
        public DateTime ENDDATE_OLD
        {
            get { return _ENDDATE_OLD; }
            set { _ENDDATE_OLD = value; }
        }
        public double FOODCATEGORYID_NEW
        {
            get { return _FOODCATEGORYID_NEW; }
            set { _FOODCATEGORYID_NEW = value; }
        }
        public double FOODCATEGORYID_OLD
        {
            get { return _FOODCATEGORYID_OLD; }
            set { _FOODCATEGORYID_OLD = value; }
        }
        public string FOODCATEGORYNAME
        {
            get { return _FOODCATEGORYNAME; }
            set { _FOODCATEGORYNAME = value; }
        }
        public string FOODCATEGORYNAME_NEW
        {
            get { return _FOODCATEGORYNAME_NEW; }
            set { _FOODCATEGORYNAME_NEW = value; }
        }
        public double FOODTYPEID_NEW
        {
            get { return _FOODTYPEID_NEW; }
            set { _FOODTYPEID_NEW = value; }
        }
        public double FOODTYPEID_OLD
        {
            get { return _FOODTYPEID_OLD; }
            set { _FOODTYPEID_OLD = value; }
        }
        public string FOODTYPENAME
        {
            get { return _FOODTYPENAME; }
            set { _FOODTYPENAME = value; }
        }
        public string FOODTYPENAME_NEW
        {
            get { return _FOODTYPENAME_NEW; }
            set { _FOODTYPENAME_NEW = value; }
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
        public string INCREASE_NEW
        {
            get { return _INCREASE_NEW; }
            set { _INCREASE_NEW = value; }
        }
        public string LIMIT
        {
            get { return _LIMIT; }
            set { _LIMIT = value; }
        }
        public string LIMIT_NEW
        {
            get { return _LIMIT_NEW; }
            set { _LIMIT_NEW = value; }
        }
        public string NEED
        {
            get { return _NEED; }
            set { _NEED = value; }
        }
        public string NEED_NEW
        {
            get { return _NEED_NEW; }
            set { _NEED_NEW = value; }
        }
        public DateTime ORDERDATE
        {
            get { return _ORDERDATE; }
            set { _ORDERDATE = value; }
        }
        public DateTime ORDERDATE_NEW
        {
            get { return _ORDERDATE_NEW; }
            set { _ORDERDATE_NEW = value; }
        }
        public double ORDERMEDID
        {
            get { return _ORDERMEDID; }
            set { _ORDERMEDID = value; }
        }
        public double ORDERNONMEDID
        {
            get { return _ORDERNONMEDID; }
            set { _ORDERNONMEDID = value; }
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
        public string QTY_NEW
        {
            get { return _QTY_NEW; }
            set { _QTY_NEW = value; }
        }
        public string REFMEDTABLE
        {
            get { return _REFMEDTABLE; }
            set { _REFMEDTABLE = value; }
        }
        public string REMARKS
        {
            get { return _REMARKS; }
            set { _REMARKS = value; }
        }
        public string REMARKS_NEW
        {
            get { return _REMARKS_NEW; }
            set { _REMARKS_NEW = value; }
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
        public string STATUS_NEW
        {
            get { return _STATUS_NEW; }
            set { _STATUS_NEW = value; }
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
            _ABSTAIN_NEW = "";
            _ADMITPATIENT = 0;
            _AGE = "";
            _AN = "";
            _BEDNO = "";
            _BMI = "";
            _CONTROL = "";
            _CONTROL_NEW = "";
            _ENDDATE_OLD = new DateTime(1, 1, 1);
            _FOODCATEGORYID_NEW = 0;
            _FOODCATEGORYID_OLD = 0;
            _FOODCATEGORYNAME = "";
            _FOODCATEGORYNAME_NEW = "";
            _FOODTYPEID_NEW = 0;
            _FOODTYPEID_OLD = 0;
            _FOODTYPENAME = "";
            _FOODTYPENAME_NEW = "";
            _HEIGHT = 0;
            _HN = "";
            _INCREASE = "";
            _INCREASE_NEW = "";
            _LIMIT = "";
            _LIMIT_NEW = "";
            _NEED = "";
            _NEED_NEW = "";
            _ORDERDATE = new DateTime(1, 1, 1);
            _ORDERDATE_NEW = new DateTime(1, 1, 1);
            _ORDERMEDID = 0;
            _ORDERNONMEDID = 0;
            _PATIENTNAME = "";
            _QTY = "";
            _QTY_NEW = "";
            _REFMEDTABLE = "";
            _REMARKS = "";
            _REMARKS_NEW = "";
            _ROOMNO = "";
            _STATUS = "";
            _STATUS_NEW = "";
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
            return DB.ExecuteTable(sql_select + (whereClause == "" ? "" : "WHERE " + whereClause + " ") + (orderBy == "" ? "" : "ORDER BY " + DB.SetSortString(orderBy)), trans);
        }

        #endregion

        #region SQL Statements

        /// <summary>
        /// Gets the select statement for V_ORDER_CHANGE table.
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
        /// Returns an indication whether the record of V_ORDER_CHANGE by specified condition is retrieved successfully.
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
                            if (!Convert.IsDBNull(zRdr["ABSTAIN_NEW"])) _ABSTAIN_NEW = zRdr["ABSTAIN_NEW"].ToString();
                            if (!Convert.IsDBNull(zRdr["ADMITPATIENT"])) _ADMITPATIENT = Convert.ToDouble(zRdr["ADMITPATIENT"]);
                            if (!Convert.IsDBNull(zRdr["AGE"])) _AGE = zRdr["AGE"].ToString();
                            if (!Convert.IsDBNull(zRdr["AN"])) _AN = zRdr["AN"].ToString();
                            if (!Convert.IsDBNull(zRdr["BEDNO"])) _BEDNO = zRdr["BEDNO"].ToString();
                            if (!Convert.IsDBNull(zRdr["BMI"])) _BMI = zRdr["BMI"].ToString();
                            if (!Convert.IsDBNull(zRdr["CONTROL"])) _CONTROL = zRdr["CONTROL"].ToString();
                            if (!Convert.IsDBNull(zRdr["CONTROL_NEW"])) _CONTROL_NEW = zRdr["CONTROL_NEW"].ToString();
                            if (!Convert.IsDBNull(zRdr["ENDDATE_OLD"])) _ENDDATE_OLD = Convert.ToDateTime(zRdr["ENDDATE_OLD"]);
                            if (!Convert.IsDBNull(zRdr["FOODCATEGORYID_NEW"])) _FOODCATEGORYID_NEW = Convert.ToDouble(zRdr["FOODCATEGORYID_NEW"]);
                            if (!Convert.IsDBNull(zRdr["FOODCATEGORYID_OLD"])) _FOODCATEGORYID_OLD = Convert.ToDouble(zRdr["FOODCATEGORYID_OLD"]);
                            if (!Convert.IsDBNull(zRdr["FOODCATEGORYNAME"])) _FOODCATEGORYNAME = zRdr["FOODCATEGORYNAME"].ToString();
                            if (!Convert.IsDBNull(zRdr["FOODCATEGORYNAME_NEW"])) _FOODCATEGORYNAME_NEW = zRdr["FOODCATEGORYNAME_NEW"].ToString();
                            if (!Convert.IsDBNull(zRdr["FOODTYPEID_NEW"])) _FOODTYPEID_NEW = Convert.ToDouble(zRdr["FOODTYPEID_NEW"]);
                            if (!Convert.IsDBNull(zRdr["FOODTYPEID_OLD"])) _FOODTYPEID_OLD = Convert.ToDouble(zRdr["FOODTYPEID_OLD"]);
                            if (!Convert.IsDBNull(zRdr["FOODTYPENAME"])) _FOODTYPENAME = zRdr["FOODTYPENAME"].ToString();
                            if (!Convert.IsDBNull(zRdr["FOODTYPENAME_NEW"])) _FOODTYPENAME_NEW = zRdr["FOODTYPENAME_NEW"].ToString();
                            if (!Convert.IsDBNull(zRdr["HEIGHT"])) _HEIGHT = Convert.ToDouble(zRdr["HEIGHT"]);
                            if (!Convert.IsDBNull(zRdr["HN"])) _HN = zRdr["HN"].ToString();
                            if (!Convert.IsDBNull(zRdr["INCREASE"])) _INCREASE = zRdr["INCREASE"].ToString();
                            if (!Convert.IsDBNull(zRdr["INCREASE_NEW"])) _INCREASE_NEW = zRdr["INCREASE_NEW"].ToString();
                            if (!Convert.IsDBNull(zRdr["LIMIT"])) _LIMIT = zRdr["LIMIT"].ToString();
                            if (!Convert.IsDBNull(zRdr["LIMIT_NEW"])) _LIMIT_NEW = zRdr["LIMIT_NEW"].ToString();
                            if (!Convert.IsDBNull(zRdr["NEED"])) _NEED = zRdr["NEED"].ToString();
                            if (!Convert.IsDBNull(zRdr["NEED_NEW"])) _NEED_NEW = zRdr["NEED_NEW"].ToString();
                            if (!Convert.IsDBNull(zRdr["ORDERDATE"])) _ORDERDATE = Convert.ToDateTime(zRdr["ORDERDATE"]);
                            if (!Convert.IsDBNull(zRdr["ORDERDATE_NEW"])) _ORDERDATE_NEW = Convert.ToDateTime(zRdr["ORDERDATE_NEW"]);
                            if (!Convert.IsDBNull(zRdr["ORDERMEDID"])) _ORDERMEDID = Convert.ToDouble(zRdr["ORDERMEDID"]);
                            if (!Convert.IsDBNull(zRdr["ORDERNONMEDID"])) _ORDERNONMEDID = Convert.ToDouble(zRdr["ORDERNONMEDID"]);
                            if (!Convert.IsDBNull(zRdr["PATIENTNAME"])) _PATIENTNAME = zRdr["PATIENTNAME"].ToString();
                            if (!Convert.IsDBNull(zRdr["QTY"])) _QTY = zRdr["QTY"].ToString();
                            if (!Convert.IsDBNull(zRdr["QTY_NEW"])) _QTY_NEW = zRdr["QTY_NEW"].ToString();
                            if (!Convert.IsDBNull(zRdr["REFMEDTABLE"])) _REFMEDTABLE = zRdr["REFMEDTABLE"].ToString();
                            if (!Convert.IsDBNull(zRdr["REMARKS"])) _REMARKS = zRdr["REMARKS"].ToString();
                            if (!Convert.IsDBNull(zRdr["REMARKS_NEW"])) _REMARKS_NEW = zRdr["REMARKS_NEW"].ToString();
                            if (!Convert.IsDBNull(zRdr["ROOMNO"])) _ROOMNO = zRdr["ROOMNO"].ToString();
                            if (!Convert.IsDBNull(zRdr["STATUS"])) _STATUS = zRdr["STATUS"].ToString();
                            if (!Convert.IsDBNull(zRdr["STATUS_NEW"])) _STATUS_NEW = zRdr["STATUS_NEW"].ToString();
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



        #region My Work Nang

        private string sql_orderchange
        {
            get
            {
                string sql = " SELECT DISTINCT WARD, WARDNAME, ROOMNO, BEDNO, HN, AN, VN, PATIENTNAME, AGE, WEIGHT, HEIGHT, BMI,ADMITPATIENT  ";
                  
                       sql += " FROM " + viewName + " ";
                return sql;
            }
        }

        private string sql_newCtl
        {
            get
            {
                string sql = "SELECT DISTINCT FOODTYPENAME_NEW, ABSTAIN_NEW, REMARKS_NEW, FOODCATEGORYNAME_NEW, QTY_NEW, LIMIT_NEW, NEED_NEW, STATUS_NEW,ORDERDATE_NEW ,CONTROL_NEW,INCREASE_NEW ,ADMITPATIENT, ";
                       sql += " ORDERMEDID, REFMEDTABLE, ORDERNONMEDID ";
                       sql += " FROM " + viewName + " ";
                return sql;
            }
        }

        private string sql_oldCtl
        {
            get
            {
                string sql = "SELECT DISTINCT FOODTYPENAME, ABSTAIN, REMARKS, FOODCATEGORYNAME, QTY, LIMIT, NEED, STATUS,ORDERDATE ,CONTROL,INCREASE,ADMITPATIENT , ";
                       sql += " ORDERMEDID, REFMEDTABLE, ORDERNONMEDID ";
                       sql += " FROM " + viewName + " ";
                return sql;
            }
        }

        public DataTable GetOrderChangeList(string whereClause, string orderBy, OracleTransaction trans)
        {
            return DB.ExecuteTable(sql_orderchange + (whereClause == "" ? "" : "WHERE " + whereClause + " ") + (orderBy == "" ? "" : "ORDER BY " + DB.SetSortString(orderBy)), trans);
        }

        public DataTable GetOrderChangeNewCtlList(string whereClause, string orderBy, OracleTransaction trans)
        {
            return DB.ExecuteTable(sql_newCtl + (whereClause == "" ? "" : "WHERE " + whereClause + " ") + (orderBy == "" ? "" : "ORDER BY " + DB.SetSortString(orderBy)), trans);
        }

        public DataTable GetOrderChangeOldCtlList(string whereClause, string orderBy, OracleTransaction trans)
        {
            return DB.ExecuteTable(sql_oldCtl + (whereClause == "" ? "" : "WHERE " + whereClause + " ") + (orderBy == "" ? "" : "ORDER BY " + DB.SetSortString(orderBy)), trans);
        }

        #endregion
    }
}