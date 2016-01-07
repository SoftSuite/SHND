using System;
using System.Data;
using System.Data.OracleClient;
using DB = SHND.DAL.Utilities.OracleDB;
using SHND.Data.Common.Utilities;

namespace SHND.DAL.Views
{
    /// <summary>
    /// Represents a transaction for V_TODOLIST_PLAN_REMAIN view.
    /// [Created by 127.0.0.1 on Febuary,17 2009]
    /// </summary>
    public class VToDoListPlanRemainDAL
    {

        public VToDoListPlanRemainDAL()
        {
        }

        #region Constant

        /// <summary>V_TODOLIST_PLAN_REMAIN</summary>
        private const string viewName = "V_TODOLIST_PLAN_REMAIN";

        #endregion

        #region Private Variables

        string _error = "";
        string _information = "";
        bool _OnDB = false;
        double _ADJQTY = 0;
        string _CLASSNAME = "";
        double _MATERIALCLASS = 0;
        double _MATERIALMASTER = 0;
        string _MATERIALNAME = "";
        double _NETPRICE = 0;
        double _PLANORDER = 0;
        double _PRICE = 0;
        double _REMAINPERCENT = 0;
        double _REMAINQTY = 0;
        string _SAPCODE = "";
        string _SPEC = "";
        string _UNITNAME = "";

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
        public double ADJQTY
        {
            get { return _ADJQTY; }
            set { _ADJQTY = value; }
        }
        public string CLASSNAME
        {
            get { return _CLASSNAME; }
            set { _CLASSNAME = value; }
        }
        public double MATERIALCLASS
        {
            get { return _MATERIALCLASS; }
            set { _MATERIALCLASS = value; }
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
        public double NETPRICE
        {
            get { return _NETPRICE; }
            set { _NETPRICE = value; }
        }
        public double PLANORDER
        {
            get { return _PLANORDER; }
            set { _PLANORDER = value; }
        }
        public double PRICE
        {
            get { return _PRICE; }
            set { _PRICE = value; }
        }
        public double REMAINPERCENT
        {
            get { return _REMAINPERCENT; }
            set { _REMAINPERCENT = value; }
        }
        public double REMAINQTY
        {
            get { return _REMAINQTY; }
            set { _REMAINQTY = value; }
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
        public string UNITNAME
        {
            get { return _UNITNAME; }
            set { _UNITNAME = value; }
        }

        #endregion

        #region Clear Data

        /// <summary>
        /// Initialize data.
        /// </summary>
        private void ClearData()
        {
            _ADJQTY = 0;
            _CLASSNAME = "";
            _MATERIALCLASS = 0;
            _MATERIALMASTER = 0;
            _MATERIALNAME = "";
            _NETPRICE = 0;
            _PLANORDER = 0;
            _PRICE = 0;
            _REMAINPERCENT = 0;
            _REMAINQTY = 0;
            _SAPCODE = "";
            _SPEC = "";
            _UNITNAME = "";
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
        /// Gets the select statement for V_TODOLIST_PLAN_REMAIN table.
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
        /// Returns an indication whether the record of V_TODOLIST_PLAN_REMAIN by specified condition is retrieved successfully.
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
                            if (!Convert.IsDBNull(zRdr["ADJQTY"])) _ADJQTY = Convert.ToDouble(zRdr["ADJQTY"]);
                            if (!Convert.IsDBNull(zRdr["CLASSNAME"])) _CLASSNAME = zRdr["CLASSNAME"].ToString();
                            if (!Convert.IsDBNull(zRdr["MATERIALCLASS"])) _MATERIALCLASS = Convert.ToDouble(zRdr["MATERIALCLASS"]);
                            if (!Convert.IsDBNull(zRdr["MATERIALMASTER"])) _MATERIALMASTER = Convert.ToDouble(zRdr["MATERIALMASTER"]);
                            if (!Convert.IsDBNull(zRdr["MATERIALNAME"])) _MATERIALNAME = zRdr["MATERIALNAME"].ToString();
                            if (!Convert.IsDBNull(zRdr["NETPRICE"])) _NETPRICE = Convert.ToDouble(zRdr["NETPRICE"]);
                            if (!Convert.IsDBNull(zRdr["PLANORDER"])) _PLANORDER = Convert.ToDouble(zRdr["PLANORDER"]);
                            if (!Convert.IsDBNull(zRdr["PRICE"])) _PRICE = Convert.ToDouble(zRdr["PRICE"]);
                            if (!Convert.IsDBNull(zRdr["REMAINPERCENT"])) _REMAINPERCENT = Convert.ToDouble(zRdr["REMAINPERCENT"]);
                            if (!Convert.IsDBNull(zRdr["REMAINQTY"])) _REMAINQTY = Convert.ToDouble(zRdr["REMAINQTY"]);
                            if (!Convert.IsDBNull(zRdr["SAPCODE"])) _SAPCODE = zRdr["SAPCODE"].ToString();
                            if (!Convert.IsDBNull(zRdr["SPEC"])) _SPEC = zRdr["SPEC"].ToString();
                            if (!Convert.IsDBNull(zRdr["UNITNAME"])) _UNITNAME = zRdr["UNITNAME"].ToString();
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

        public DataTable GetDataListByConditions(double cPLANORDER, double cMATERIALCLASS, string cMATERIALNAME, string cOPERATOR, double cREMAINPERCENT, string orderBy, OracleTransaction trans)
        {
            string whText = "";
            if (cPLANORDER != 0) whText += (whText == "" ? "" : "AND ") + "PLANORDER = " + DB.SetDouble(cPLANORDER) + " ";
            if (cMATERIALCLASS != 0) whText += (whText == "" ? "" : "AND ") + "MATERIALCLASS = " + DB.SetDouble(cMATERIALCLASS) + " ";
            if (cMATERIALNAME.Trim() != "") whText += (whText == "" ? "" : "AND ") + "UPPER(MATERIALNAME) LIKE " + DB.SetString("%" + cMATERIALNAME.Trim().ToUpper() + "%") + " ";
            if (cOPERATOR.Trim() != "")
            {
                whText += (whText == "" ? "" : "AND ") + "REMAINPERCENT " + cOPERATOR + " " + DB.SetDouble(cREMAINPERCENT) + " ";
            }
            return GetDataList(whText, orderBy, trans);
        }
    }
}