using System;
using System.Data;
using System.Data.OracleClient;
using DB = SHND.DAL.Utilities.OracleDB;
using SHND.Data.Common.Utilities;

namespace SHND.DAL.Views
{
    /// <summary>
    /// Represents a transaction for V_STOCKOUTITEM view.
    /// [Created by 127.0.0.1 on Febuary,12 2009]
    /// </summary>
    public class VStockoutItemDAL
    {

        public VStockoutItemDAL()
        {
        }

        #region Constant

        /// <summary>V_STOCKOUTITEM</summary>
        private const string viewName = "V_STOCKOUTITEM";

        #endregion

        #region Private Variables

        string _error = "";
        string _information = "";
        bool _OnDB = false;
        DateTime _FINISHDATE = new DateTime(1, 1, 1);
        double _FLOOR = 0;
        string _ISMENU = "";
        string _ITEMNAME = "";
        double _LOID = 0;
        string _LOTNO = "";
        double _MATERIALMASTER = 0;
        string _MATERIALNAME = "";
        double _PRICE = 0;
        double _QTY = 0;
        string _REMARKS = "";
        string _REPAIRBY = "";
        string _REPAIRREMARKS = "";
        string _REPAIRSTATUS = "";
        double _REQQTY = 0;
        string _SAPCODE = "";
        string _STATUS = "";
        double _STOCKOUT = 0;
        double _UNIT = 0;
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
        public DateTime FINISHDATE
        {
            get { return _FINISHDATE; }
            set { _FINISHDATE = value; }
        }
        public double FLOOR
        {
            get { return _FLOOR; }
            set { _FLOOR = value; }
        }
        public string ISMENU
        {
            get { return _ISMENU; }
            set { _ISMENU = value; }
        }
        public string ITEMNAME
        {
            get { return _ITEMNAME; }
            set { _ITEMNAME = value; }
        }
        public double LOID
        {
            get { return _LOID; }
            set { _LOID = value; }
        }
        public string LOTNO
        {
            get { return _LOTNO; }
            set { _LOTNO = value; }
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
        public double PRICE
        {
            get { return _PRICE; }
            set { _PRICE = value; }
        }
        public double QTY
        {
            get { return _QTY; }
            set { _QTY = value; }
        }
        public string REMARKS
        {
            get { return _REMARKS; }
            set { _REMARKS = value; }
        }
        public string REPAIRBY
        {
            get { return _REPAIRBY; }
            set { _REPAIRBY = value; }
        }
        public string REPAIRREMARKS
        {
            get { return _REPAIRREMARKS; }
            set { _REPAIRREMARKS = value; }
        }
        public string REPAIRSTATUS
        {
            get { return _REPAIRSTATUS; }
            set { _REPAIRSTATUS = value; }
        }
        public double REQQTY
        {
            get { return _REQQTY; }
            set { _REQQTY = value; }
        }
        public string SAPCODE
        {
            get { return _SAPCODE; }
            set { _SAPCODE = value; }
        }
        public string STATUS
        {
            get { return _STATUS; }
            set { _STATUS = value; }
        }
        public double STOCKOUT
        {
            get { return _STOCKOUT; }
            set { _STOCKOUT = value; }
        }
        public double UNIT
        {
            get { return _UNIT; }
            set { _UNIT = value; }
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
            _FINISHDATE = new DateTime(1, 1, 1);
            _FLOOR = 0;
            _ISMENU = "";
            _ITEMNAME = "";
            _LOID = 0;
            _LOTNO = "";
            _MATERIALMASTER = 0;
            _MATERIALNAME = "";
            _PRICE = 0;
            _QTY = 0;
            _REMARKS = "";
            _REPAIRBY = "";
            _REPAIRREMARKS = "";
            _REPAIRSTATUS = "";
            _REQQTY = 0;
            _SAPCODE = "";
            _STATUS = "";
            _STOCKOUT = 0;
            _UNIT = 0;
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

        public DataTable GetDataListByLOID(double cLOID, string orderBy, OracleTransaction trans)
        {
            return GetDataList("LOID = " + DB.SetDouble(cLOID) + " ", orderBy, trans);
        }

        public DataTable GetDataListBySTOCKOUT(double cLOID, string orderBy, OracleTransaction trans)
        {
            return GetDataList("STOCKOUT = " + DB.SetDouble(cLOID) + " ", orderBy, trans);
        }

        public DataTable GetRepairItemBlank()
        {
            string sql = "SELECT 0 LOID, 0 STOCKOUTITEM, '' REPAIRDATE, '' DESCRIPTION ";
            sql += "FROM DUAL ";
            return DB.ExecuteTable(sql);
        }
        public DataTable GetRepairItem(double RepairLOID)
        {
            string sql = "SELECT RS.LOID LOID, ROWNUM RANK , RS.REPAIRDATE REPAIRDATE, DESCRIPTION, RS.STOCKOUTITEM STOCKOUTITEM ";
            sql += "FROM  STOCKOUTITEM SI INNER JOIN REPAIRSTATUS RS ON RS.STOCKOUTITEM = SI.LOID ";
            sql += "WHERE STOCKOUT = " + RepairLOID;
            return DB.ExecuteTable(sql);
        }
        #region SQL Statements

        /// <summary>
        /// Gets the select statement for V_STOCKOUTITEM table.
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
        /// Returns an indication whether the record of V_STOCKOUTITEM by specified condition is retrieved successfully.
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
                        if (!Convert.IsDBNull(zRdr["FINISHDATE"])) _FINISHDATE = Convert.ToDateTime(zRdr["FINISHDATE"]);
                        if (!Convert.IsDBNull(zRdr["FLOOR"])) _FLOOR = Convert.ToDouble(zRdr["FLOOR"]);
                        if (!Convert.IsDBNull(zRdr["ISMENU"])) _ISMENU = zRdr["ISMENU"].ToString();
                        if (!Convert.IsDBNull(zRdr["ITEMNAME"])) _ITEMNAME = zRdr["ITEMNAME"].ToString();
                        if (!Convert.IsDBNull(zRdr["LOID"])) _LOID = Convert.ToDouble(zRdr["LOID"]);
                        if (!Convert.IsDBNull(zRdr["LOTNO"])) _LOTNO = zRdr["LOTNO"].ToString();
                        if (!Convert.IsDBNull(zRdr["MATERIALMASTER"])) _MATERIALMASTER = Convert.ToDouble(zRdr["MATERIALMASTER"]);
                        if (!Convert.IsDBNull(zRdr["MATERIALNAME"])) _MATERIALNAME = zRdr["MATERIALNAME"].ToString();
                        if (!Convert.IsDBNull(zRdr["PRICE"])) _PRICE = Convert.ToDouble(zRdr["PRICE"]);
                        if (!Convert.IsDBNull(zRdr["QTY"])) _QTY = Convert.ToDouble(zRdr["QTY"]);
                        if (!Convert.IsDBNull(zRdr["REMARKS"])) _REMARKS = zRdr["REMARKS"].ToString();
                        if (!Convert.IsDBNull(zRdr["REPAIRBY"])) _REPAIRBY = zRdr["REPAIRBY"].ToString();
                        if (!Convert.IsDBNull(zRdr["REPAIRREMARKS"])) _REPAIRREMARKS = zRdr["REPAIRREMARKS"].ToString();
                        if (!Convert.IsDBNull(zRdr["REPAIRSTATUS"])) _REPAIRSTATUS = zRdr["REPAIRSTATUS"].ToString();
                        if (!Convert.IsDBNull(zRdr["REQQTY"])) _REQQTY = Convert.ToDouble(zRdr["REQQTY"]);
                        if (!Convert.IsDBNull(zRdr["SAPCODE"])) _SAPCODE = zRdr["SAPCODE"].ToString();
                        if (!Convert.IsDBNull(zRdr["STATUS"])) _STATUS = zRdr["STATUS"].ToString();
                        if (!Convert.IsDBNull(zRdr["STOCKOUT"])) _STOCKOUT = Convert.ToDouble(zRdr["STOCKOUT"]);
                        if (!Convert.IsDBNull(zRdr["UNIT"])) _UNIT = Convert.ToDouble(zRdr["UNIT"]);
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

        #region My Work Nang

        private string sql_cutorder
        {
            get
            {
                string sql = "SELECT LOID,CODE,STOCKOUT, MATERIALNAME,UNITNAME,NVL(REQQTY,0) REQQTY , ";
                       sql += " NVL(QTY,0) QTY ,NVL(USEQTY,0) USEQTY , NVL(QTY,0) - NVL(USEQTY,0) AS RETURN,MATERIALMASTER ";
                       sql += " FROM " + viewName + " ";
                return sql;
            }
        }

        private string sql_patientcount
        {
            get
            {
                string sql = "SELECT VS.LOID,VS.CODE,VS.STOCKOUT, MATERIALNAME,UNITNAME, ";
                       sql += " NVL(QTY,0) QTY ,NVL(REQQTY,0) REQQTY , NVL(QTY,0) - NVL(USEQTY,0) AS RETURN,MATERIALMASTER,";
                       sql += " ROUND(PKE_PREPARE.FN_CUTORDERQTY(VS.MATERIALMASTER,SC.DIVISION,SC.USEDATE, SC.ISBREAKFAST,SC.ISLUNCH,SC.ISDINNER),2) AS USEQTY ";
                       sql += " FROM  V_STOCKOUTITEM VS INNER JOIN STOCKOUT SC ON SC.LOID = VS.STOCKOUT ";
                return sql;
            }
        }

        public DataTable GetCutOrderList(string whereClause, string orderBy, OracleTransaction trans)
        {
            return DB.ExecuteTable(sql_cutorder + (whereClause == "" ? "" : "WHERE " + whereClause + " ") + (orderBy == "" ? "" : "ORDER BY " + DB.SetSortString(orderBy)), trans);
        }

        public DataTable GetPatientCout(string whereClause, string orderBy, OracleTransaction trans)
        {
            return DB.ExecuteTable(sql_patientcount + (whereClause == "" ? "" : "WHERE " + whereClause + " ") + (orderBy == "" ? "" : "ORDER BY " + DB.SetSortString(orderBy)), trans);
        }


        public DataTable GetCutOrderBySTOCKOUT(double cLOID, string orderBy, OracleTransaction trans)
        {
            return GetCutOrderList("STOCKOUT = " + DB.SetDouble(cLOID) + " ", orderBy, trans);
        }


        public DataTable GetPatientCount(double cLOID, string orderBy, OracleTransaction trans)
        {
            return GetPatientCout("STOCKOUT = " + DB.SetDouble(cLOID) + " ", orderBy, trans);
        }

        #endregion

    }
}