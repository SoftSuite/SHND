using System;
using System.Data;
using System.Data.OracleClient;
using DB = SHND.DAL.Utilities.OracleDB;
using SHND.Data.Common.Utilities;

namespace SHND.DAL.Views
{
    /// <summary>
    /// Represents a transaction for V_PREPODIVISION_SUM view.
    /// [Created by 127.0.0.1 on March,5 2009]
    /// </summary>
    public class VPrePODivisionSumDAL
    {

        public VPrePODivisionSumDAL()
        {
        }

        #region Constant

        /// <summary>V_PREPODIVISION_SUM</summary>
        private const string viewName = "V_PREPODIVISION_SUM";

        #endregion

        #region Private Variables

        string _error = "";
        string _information = "";
        bool _OnDB = false;
        DateTime _BPODATE = new DateTime(1, 1, 1);
        string _CLASSNAME = "";
        string _CODE = "";
        string _ISVAT = "";
        double _MATERIALCLASS = 0;
        string _MATERIALCODE = "";
        double _MATERIALMASTER = 0;
        string _MATERIALNAME = "";
        double _MENUQTY = 0;
        double _NETPRICE = 0;
        double _ORDERQTY = 0;
        string _PLANCODE = "";
        double _PLANMATERIALCLASS = 0;
        string _PLANNAME = "";
        double _PLANORDER = 0;
        double _PLANREMAINQTY = 0;
        double _PRICE = 0;
        string _REMARKS = "";
        string _SAPCODE = "";
        string _SPEC = "";
        double _UNITLOID = 0;
        string _UNITNAME = "";
        DateTime _USEDATE = new DateTime(1, 1, 1);

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
        public DateTime BPODATE
        {
            get { return _BPODATE; }
            set { _BPODATE = value; }
        }
        public string CLASSNAME
        {
            get { return _CLASSNAME; }
            set { _CLASSNAME = value; }
        }
        public string CODE
        {
            get { return _CODE; }
            set { _CODE = value; }
        }
        public string ISVAT
        {
            get { return _ISVAT; }
            set { _ISVAT = value; }
        }
        public double MATERIALCLASS
        {
            get { return _MATERIALCLASS; }
            set { _MATERIALCLASS = value; }
        }
        public string MATERIALCODE
        {
            get { return _MATERIALCODE; }
            set { _MATERIALCODE = value; }
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
        public double MENUQTY
        {
            get { return _MENUQTY; }
            set { _MENUQTY = value; }
        }
        public double NETPRICE
        {
            get { return _NETPRICE; }
            set { _NETPRICE = value; }
        }
        public double ORDERQTY
        {
            get { return _ORDERQTY; }
            set { _ORDERQTY = value; }
        }
        public string PLANCODE
        {
            get { return _PLANCODE; }
            set { _PLANCODE = value; }
        }
        public double PLANMATERIALCLASS
        {
            get { return _PLANMATERIALCLASS; }
            set { _PLANMATERIALCLASS = value; }
        }
        public string PLANNAME
        {
            get { return _PLANNAME; }
            set { _PLANNAME = value; }
        }
        public double PLANORDER
        {
            get { return _PLANORDER; }
            set { _PLANORDER = value; }
        }
        public double PLANREMAINQTY
        {
            get { return _PLANREMAINQTY; }
            set { _PLANREMAINQTY = value; }
        }
        public double PRICE
        {
            get { return _PRICE; }
            set { _PRICE = value; }
        }
        public string REMARKS
        {
            get { return _REMARKS; }
            set { _REMARKS = value; }
        }
        public string SAPCODE
        {
            get { return _SAPCODE; }
            set { _SAPCODE = value; }
        }
        public string SPEC
        {
            get { return _SPEC; }
            set { _SPEC = value; }
        }
        public double UNITLOID
        {
            get { return _UNITLOID; }
            set { _UNITLOID = value; }
        }
        public string UNITNAME
        {
            get { return _UNITNAME; }
            set { _UNITNAME = value; }
        }
        public DateTime USEDATE
        {
            get { return _USEDATE; }
            set { _USEDATE = value; }
        }

        #endregion

        #region Clear Data

        /// <summary>
        /// Initialize data.
        /// </summary>
        private void ClearData()
        {
            _BPODATE = new DateTime(1, 1, 1);
            _CLASSNAME = "";
            _CODE = "";
            _ISVAT = "";
            _MATERIALCLASS = 0;
            _MATERIALCODE = "";
            _MATERIALMASTER = 0;
            _MATERIALNAME = "";
            _MENUQTY = 0;
            _NETPRICE = 0;
            _ORDERQTY = 0;
            _PLANCODE = "";
            _PLANMATERIALCLASS = 0;
            _PLANNAME = "";
            _PLANORDER = 0;
            _PLANREMAINQTY = 0;
            _PRICE = 0;
            _REMARKS = "";
            _SAPCODE = "";
            _SPEC = "";
            _UNITLOID = 0;
            _UNITNAME = "";
            _USEDATE = new DateTime(1, 1, 1);
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

        public DataTable GetDataListByCondition(double plan, double mclass, DateTime usedate, string orderBy, OracleTransaction trans)
        {
            return GetDataList("PLANORDER = " + DB.SetDouble(plan) + " AND PLANMATERIALCLASS = " + DB.SetDouble(mclass) + " AND USEDATE = " + DB.SetDate(usedate), orderBy, trans);
        }

        #endregion

        #region SQL Statements

        /// <summary>
        /// Gets the select statement for V_PREPODIVISION_SUM table.
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
        /// Returns an indication whether the record of V_PREPODIVISION_SUM by specified condition is retrieved successfully.
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
                        if (!Convert.IsDBNull(zRdr["BPODATE"])) _BPODATE = Convert.ToDateTime(zRdr["BPODATE"]);
                        if (!Convert.IsDBNull(zRdr["CLASSNAME"])) _CLASSNAME = zRdr["CLASSNAME"].ToString();
                        if (!Convert.IsDBNull(zRdr["CODE"])) _CODE = zRdr["CODE"].ToString();
                        if (!Convert.IsDBNull(zRdr["ISVAT"])) _ISVAT = zRdr["ISVAT"].ToString();
                        if (!Convert.IsDBNull(zRdr["MATERIALCLASS"])) _MATERIALCLASS = Convert.ToDouble(zRdr["MATERIALCLASS"]);
                        if (!Convert.IsDBNull(zRdr["MATERIALCODE"])) _MATERIALCODE = zRdr["MATERIALCODE"].ToString();
                        if (!Convert.IsDBNull(zRdr["MATERIALMASTER"])) _MATERIALMASTER = Convert.ToDouble(zRdr["MATERIALMASTER"]);
                        if (!Convert.IsDBNull(zRdr["MATERIALNAME"])) _MATERIALNAME = zRdr["MATERIALNAME"].ToString();
                        if (!Convert.IsDBNull(zRdr["MENUQTY"])) _MENUQTY = Convert.ToDouble(zRdr["MENUQTY"]);
                        if (!Convert.IsDBNull(zRdr["NETPRICE"])) _NETPRICE = Convert.ToDouble(zRdr["NETPRICE"]);
                        if (!Convert.IsDBNull(zRdr["ORDERQTY"])) _ORDERQTY = Convert.ToDouble(zRdr["ORDERQTY"]);
                        if (!Convert.IsDBNull(zRdr["PLANCODE"])) _PLANCODE = zRdr["PLANCODE"].ToString();
                        if (!Convert.IsDBNull(zRdr["PLANMATERIALCLASS"])) _PLANMATERIALCLASS = Convert.ToDouble(zRdr["PLANMATERIALCLASS"]);
                        if (!Convert.IsDBNull(zRdr["PLANNAME"])) _PLANNAME = zRdr["PLANNAME"].ToString();
                        if (!Convert.IsDBNull(zRdr["PLANORDER"])) _PLANORDER = Convert.ToDouble(zRdr["PLANORDER"]);
                        if (!Convert.IsDBNull(zRdr["PLANREMAINQTY"])) _PLANREMAINQTY = Convert.ToDouble(zRdr["PLANREMAINQTY"]);
                        if (!Convert.IsDBNull(zRdr["PRICE"])) _PRICE = Convert.ToDouble(zRdr["PRICE"]);
                        if (!Convert.IsDBNull(zRdr["REMARKS"])) _REMARKS = zRdr["REMARKS"].ToString();
                        if (!Convert.IsDBNull(zRdr["SAPCODE"])) _SAPCODE = zRdr["SAPCODE"].ToString();
                        if (!Convert.IsDBNull(zRdr["SPEC"])) _SPEC = zRdr["SPEC"].ToString();
                        if (!Convert.IsDBNull(zRdr["UNITLOID"])) _UNITLOID = Convert.ToDouble(zRdr["UNITLOID"]);
                        if (!Convert.IsDBNull(zRdr["UNITNAME"])) _UNITNAME = zRdr["UNITNAME"].ToString();
                        if (!Convert.IsDBNull(zRdr["USEDATE"])) _USEDATE = Convert.ToDateTime(zRdr["USEDATE"]);
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