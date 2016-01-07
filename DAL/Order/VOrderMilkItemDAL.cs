using System;
using System.Data;
using System.Data.OracleClient;
using DB = SHND.DAL.Utilities.OracleDB;
using SHND.Data.Common.Utilities;

namespace SHND.DAL.Order
{
    public class VOrderMilkItemDAL
    {
        #region Constant

        /// <summary>V_ORDERDETAIL_ITEM</summary>
        private const string viewName = "V_ORDERDETAIL_ITEM";

        #endregion

        #region Private Variables

        string _error = "";
        string _information = "";
        bool _OnDB = false;
        double _DISEASECATEGORY = 0;
        string _DISEASECATEGORYNAME = "";
        string _ISHIGH = "";
        string _ISLOW = "";
        string _ISNON = "";
        double _LOID = 0;
        double _QTY = 0;
        double _REFLOID = 0;
        string _REFTABLE = "";
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
        public double DISEASECATEGORY
        {
            get { return _DISEASECATEGORY; }
            set { _DISEASECATEGORY = value; }
        }
        public string DISEASECATEGORYNAME
        {
            get { return _DISEASECATEGORYNAME; }
            set { _DISEASECATEGORYNAME = value; }
        }
        public string ISHIGH
        {
            get { return _ISHIGH; }
            set { _ISHIGH = value; }
        }
        public string ISLOW
        {
            get { return _ISLOW; }
            set { _ISLOW = value; }
        }
        public string ISNON
        {
            get { return _ISNON; }
            set { _ISNON = value; }
        }
        public double LOID
        {
            get { return _LOID; }
            set { _LOID = value; }
        }
        public double QTY
        {
            get { return _QTY; }
            set { _QTY = value; }
        }
        public double REFLOID
        {
            get { return _REFLOID; }
            set { _REFLOID = value; }
        }
        public string REFTABLE
        {
            get { return _REFTABLE; }
            set { _REFTABLE = value; }
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
            _DISEASECATEGORY = 0;
            _DISEASECATEGORYNAME = "";
            _ISHIGH = "";
            _ISLOW = "";
            _ISNON = "";
            _LOID = 0;
            _QTY = 0;
            _REFLOID = 0;
            _REFTABLE = "";
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
        public DataTable GetDataList(double cREFLOID, string whereClause, string orderBy, OracleTransaction trans)
        {
            return DB.ExecuteTable(sql_select(cREFLOID) + (whereClause == "" ? "" : "WHERE " + whereClause + " ") + (orderBy == "" ? "" : "ORDER BY " + DB.SetSortString(orderBy)), trans);
        }

        #endregion

        #region SQL Statements

        /// <summary>
        /// Gets the select statement for V_ORDERDETAIL_ITEM table.
        /// </summary>
        private string sql_select(double cREFLOID)
        {
            string sql = "SELECT * FROM (SELECT 'ORDERMILK', M.REFLOID, D.LOID DISEASECATEGORY, D.ABBNAME DISEASECATEGORYNAME, NVL(M.QTY,0) QTY, NVL(M.UNIT, DU.LOID) UNIT, " +
                "NVL(UNIT.THNAME, DU.THNAME) || '/มื้อ' UNITNAME, NVL(M.ISHIGH, D.ISHIGH) ISHIGH, NVL(M.ISLOW, D.ISLOW) ISLOW, NVL(M.ISNON, D.ISNON) ISNON, " +
                "M.INCREASEMEAL, CASE WHEN D.ISINCREASE='Y' THEN DECODE(M.INCREASEMEAL,'00','ทุกมื้อ','11','มื้อเช้า','21','มื้อกลางวัน','31','มื้อเย็น') ELSE '' END MEALNAME ,D.ISSPIN " +
                "FROM DISEASECATEGORY D LEFT JOIN UNIT DU ON DU.LOID = D.UNIT " +
                "LEFT JOIN ORDERMEDICALITEM M ON M.DISEASECATEGORY = D.LOID AND M.REFTABLE = 'ORDERMILK' AND M.REFLOID = " + DB.SetDouble(cREFLOID) + " " +
                "LEFT JOIN UNIT ON UNIT.LOID = M.UNIT " +
                "WHERE D.ISMILK = 'Y') " + viewName + " ";
            return sql;
        }

        #endregion

        #region Private Methods

        /// <summary>
        /// Returns an indication whether the record of V_ORDERDETAIL_ITEM by specified condition is retrieved successfully.
        /// </summary>
        /// <param name="whText">The condition specify the deleting record(s).</param>
        /// <param name="trans">The System.Data.OracleClient.OracleTransaction used by this System.Data.OracleClient.OracleCommand.</param>
        /// <returns>true if data is retrieved successfully; otherwise, false.</returns>
        public bool doGetdata(double cREFLOID, string whText, OracleTransaction trans)
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
                    zRdr = DB.ExecuteReader(sql_select(cREFLOID) + tmpWhere, trans);
                    if (zRdr.Read())
                    {
                        _OnDB = true;
                        if (!Convert.IsDBNull(zRdr["DISEASECATEGORY"])) _DISEASECATEGORY = Convert.ToDouble(zRdr["DISEASECATEGORY"]);
                        if (!Convert.IsDBNull(zRdr["DISEASECATEGORYNAME"])) _DISEASECATEGORYNAME = zRdr["DISEASECATEGORYNAME"].ToString();
                        if (!Convert.IsDBNull(zRdr["ISHIGH"])) _ISHIGH = zRdr["ISHIGH"].ToString();
                        if (!Convert.IsDBNull(zRdr["ISLOW"])) _ISLOW = zRdr["ISLOW"].ToString();
                        if (!Convert.IsDBNull(zRdr["ISNON"])) _ISNON = zRdr["ISNON"].ToString();
                        if (!Convert.IsDBNull(zRdr["LOID"])) _LOID = Convert.ToDouble(zRdr["LOID"]);
                        if (!Convert.IsDBNull(zRdr["QTY"])) _QTY = Convert.ToDouble(zRdr["QTY"]);
                        if (!Convert.IsDBNull(zRdr["REFLOID"])) _REFLOID = Convert.ToDouble(zRdr["REFLOID"]);
                        if (!Convert.IsDBNull(zRdr["REFTABLE"])) _REFTABLE = zRdr["REFTABLE"].ToString();
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

        public DataTable GetDataListByConditions(double refLoid, string orderBy, OracleTransaction trans)
        {
            return GetDataList(refLoid, "", orderBy, trans);
        }
    }
}
