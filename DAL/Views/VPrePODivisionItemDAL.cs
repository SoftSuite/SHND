using System;
using System.Data;
using System.Data.OracleClient;
using DB = SHND.DAL.Utilities.OracleDB;
using SHND.Data.Common.Utilities;
using SHND.Data.Tables;

namespace SHND.DAL.Views
{
    /// <summary>
    /// Represents a transaction for V_PREPODIVISION_ITEM view.
    /// [Created by 127.0.0.1 on Febuary,19 2009]
    /// </summary>
    public class VPrePODivisionItemDAL
    {

        public VPrePODivisionItemDAL()
        {
        }

        #region Constant

        /// <summary>V_PREPODIVISION_ITEM</summary>
        private const string viewName = "V_PREPODIVISION_ITEM";

        #endregion

        #region Private Variables

        string _error = "";
        string _information = "";
        bool _OnDB = false;
        string _GROUPNAME = "";
        string _ISVAT = "";
        string _MATERIALCODE = "";
        double _MATERIALGROUP = 0;
        double _MATERIALMASTER = 0;
        string _MATERIALNAME = "";
        double _MENUQTY = 0;
        double _NETPRICE = 0;
        double _ORDERQTY = 0;
        double _PLANREMAINQTY = 0;
        double _PRICE = 0;
        string _REMARKS = "";
        string _SAPCODE = "";
        double _UNITLOID = 0;
        string _UNITNAME = "";
        string _FULLADDRESS = "";

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
        public string GROUPNAME
        {
            get { return _GROUPNAME; }
            set { _GROUPNAME = value; }
        }
        public string ISVAT
        {
            get { return _ISVAT; }
            set { _ISVAT = value; }
        }
        public string MATERIALCODE
        {
            get { return _MATERIALCODE; }
            set { _MATERIALCODE = value; }
        }
        public double MATERIALGROUP
        {
            get { return _MATERIALGROUP; }
            set { _MATERIALGROUP = value; }
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
        public string FULLADDRESS
        {
            get { return _FULLADDRESS; }
            set { _FULLADDRESS = value; }
        }

        #endregion

        #region Clear Data

        /// <summary>
        /// Initialize data.
        /// </summary>
        private void ClearData()
        {
            _GROUPNAME = "";
            _ISVAT = "";
            _MATERIALCODE = "";
            _MATERIALGROUP = 0;
            _MATERIALMASTER = 0;
            _MATERIALNAME = "";
            _MENUQTY = 0;
            _NETPRICE = 0;
            _ORDERQTY = 0;
            _PLANREMAINQTY = 0;
            _PRICE = 0;
            _REMARKS = "";
            _SAPCODE = "";
            _UNITLOID = 0;
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

        public DataTable GetDataListByPrePO(double cPrePO, string orderBy, OracleTransaction trans)
        {
            return GetDataList("PREPODIVISION = " + DB.SetDouble(cPrePO), orderBy, trans);
        }

        #endregion

        #region SQL Statements

        /// <summary>
        /// Gets the select statement for V_PREPODIVISION_ITEM table.
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
        /// Returns an indication whether the record of V_PREPODIVISION_ITEM by specified condition is retrieved successfully.
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
                        if (!Convert.IsDBNull(zRdr["GROUPNAME"])) _GROUPNAME = zRdr["GROUPNAME"].ToString();
                        if (!Convert.IsDBNull(zRdr["ISVAT"])) _ISVAT = zRdr["ISVAT"].ToString();
                        if (!Convert.IsDBNull(zRdr["MATERIALCODE"])) _MATERIALCODE = zRdr["MATERIALCODE"].ToString();
                        if (!Convert.IsDBNull(zRdr["MATERIALGROUP"])) _MATERIALGROUP = Convert.ToDouble(zRdr["MATERIALGROUP"]);
                        if (!Convert.IsDBNull(zRdr["MATERIALMASTER"])) _MATERIALMASTER = Convert.ToDouble(zRdr["MATERIALMASTER"]);
                        if (!Convert.IsDBNull(zRdr["MATERIALNAME"])) _MATERIALNAME = zRdr["MATERIALNAME"].ToString();
                        if (!Convert.IsDBNull(zRdr["MENUQTY"])) _MENUQTY = Convert.ToDouble(zRdr["MENUQTY"]);
                        if (!Convert.IsDBNull(zRdr["NETPRICE"])) _NETPRICE = Convert.ToDouble(zRdr["NETPRICE"]);
                        if (!Convert.IsDBNull(zRdr["ORDERQTY"])) _ORDERQTY = Convert.ToDouble(zRdr["ORDERQTY"]);
                        if (!Convert.IsDBNull(zRdr["PLANREMAINQTY"])) _PLANREMAINQTY = Convert.ToDouble(zRdr["PLANREMAINQTY"]);
                        if (!Convert.IsDBNull(zRdr["PRICE"])) _PRICE = Convert.ToDouble(zRdr["PRICE"]);
                        if (!Convert.IsDBNull(zRdr["REMARKS"])) _REMARKS = zRdr["REMARKS"].ToString();
                        if (!Convert.IsDBNull(zRdr["SAPCODE"])) _SAPCODE = zRdr["SAPCODE"].ToString();
                        if (!Convert.IsDBNull(zRdr["UNITLOID"])) _UNITLOID = Convert.ToDouble(zRdr["UNITLOID"]);
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

        public SupplierData GetDataSupplier(double plan, double materialclass)
        {
            string sql = "SELECT PMC.LOID, PMC.PLANORDER,PMC.MATERIALCLASS, PMC.CONTRACTCODE,  S.NAME SUPPLIERNAME, S.CONTACTNAME, S.FULLADDRESS,S.TEL,S.FAX ";
                    sql += " FROM PLANMATERIALCLASS PMC INNER JOIN MATERIALCLASS MC ON MC.LOID = PMC.MATERIALCLASS ";
                    sql += " INNER JOIN PLANORDER P ON P.LOID = PMC.PLANORDER ";
                    sql += " LEFT JOIN V_SUPPLIER S ON S.LOID = PMC.SUPPLIER ";
                    sql += " WHERE PMC.PLANORDER='" + plan + "' AND PMC.LOID = '" + materialclass + "' ";
            //string sql = "SELECT * FROM V_PLANMATERIALCLASS WHERE PLANORDER = '" + plan + "' AND LOID = '" + materialclass + "' ";

            DataTable dt = DB.ExecuteTable(sql);
            SupplierData data = new SupplierData();
            if (dt.Rows.Count > 0)
            {
                data.CODE = dt.Rows[0]["CONTRACTCODE"].ToString();
                data.NAME = dt.Rows[0]["SUPPLIERNAME"].ToString();
                data.FULLADDRESS = dt.Rows[0]["FULLADDRESS"].ToString();
                data.CONTACTNAME = dt.Rows[0]["CONTACTNAME"].ToString();
                data.TEL = dt.Rows[0]["TEL"].ToString();
                data.FAX = dt.Rows[0]["FAX"].ToString();
                data.LOID = Convert.ToDouble(dt.Rows[0]["MATERIALCLASS"]);
            }

            return data;
        }

        public double GetRemainQty(double plan, double materialmaster, double division)
        {
            string sql = "SELECT PKE_PURCHASE.FN_CALPREPOREMAIN(" + plan + "," + materialmaster + "," + division + ") QTY  FROM DUAL";

            DataTable dt = DB.ExecuteTable(sql);
            double qty = 0;
            if (dt.Rows.Count > 0)
            {
                qty = Convert.ToDouble(dt.Rows[0]["QTY"].ToString() == "" ? "0" : dt.Rows[0]["QTY"].ToString());
            }

            return qty;
        }

        public double GetRemainTotal(double plan, double materialclass)
        {
            string sql = "SELECT PKE_PURCHASE.FN_CALPLANMONEYREMAIN(" + plan + "," + materialclass + ") QTY  FROM DUAL";

            DataTable dt = DB.ExecuteTable(sql);
            double qty = 0;
            if (dt.Rows.Count > 0)
            {
                qty = Convert.ToDouble(dt.Rows[0]["QTY"].ToString() == "" ? "0" : dt.Rows[0]["QTY"].ToString());
            }

            return qty;
        }


        #endregion

    }
}