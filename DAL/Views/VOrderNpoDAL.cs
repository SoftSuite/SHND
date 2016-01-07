using System;
using System.Data;
using System.Data.OracleClient;
using DB = SHND.DAL.Utilities.OracleDB;
using SHND.Data.Common.Utilities;
using SHND.Data.Views;
using System.Collections;

namespace SHND.DAL.Views
{
    /// <summary>
    /// Represents a transaction for V_ORDER_NPO view.
    /// [Created by 127.0.0.1 on March,31 2009]
    /// </summary>
    public class VOrderNpoDAL
    {

        public VOrderNpoDAL()
        {
        }

        #region Constant

        /// <summary>V_ORDER_NPO</summary>
        private const string viewName = "V_ORDER_NPO";

        #endregion

        #region Private Variables

        string _error = "";
        string _information = "";
        bool _OnDB = false;
        string _ABSTAIN = "";
        string _AGE = "";
        string _AN = "";
        string _BEDNO = "";
        string _BMI = "";
        string _CONTROL = "";
        string _FEEDNAME = "";
        string _FOODCATEGORYNAME = "";
        string _FOODTYPENAME = "";
        double _HEIGHT = 0;
        string _HN = "";
        string _INCREASE = "";
        string _ISNPO = "";
        string _ISREGISTER = "";
        string _LIMIT = "";
        double _LOID = 0;
        string _MILKNAME = "";
        string _NEED = "";
        DateTime _NPOSTART = new DateTime(1, 1, 1);
        string _NPOTIME = "";
        DateTime _ORDERDATE = new DateTime(1, 1, 1);
        string _PATIENTNAME = "";
        string _QTY = "";
        string _REMARKS = "";
        string _ROOMNO = "";
        string _STATUS = "";
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
        public string FEEDNAME
        {
            get { return _FEEDNAME; }
            set { _FEEDNAME = value; }
        }
        public string FOODCATEGORYNAME
        {
            get { return _FOODCATEGORYNAME; }
            set { _FOODCATEGORYNAME = value; }
        }
        public string FOODTYPENAME
        {
            get { return _FOODTYPENAME; }
            set { _FOODTYPENAME = value; }
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
        public string LIMIT
        {
            get { return _LIMIT; }
            set { _LIMIT = value; }
        }
        public double LOID
        {
            get { return _LOID; }
            set { _LOID = value; }
        }
        public string MILKNAME
        {
            get { return _MILKNAME; }
            set { _MILKNAME = value; }
        }
        public string NEED
        {
            get { return _NEED; }
            set { _NEED = value; }
        }
        public DateTime NPOSTART
        {
            get { return _NPOSTART; }
            set { _NPOSTART = value; }
        }
        public string NPOTIME
        {
            get { return _NPOTIME; }
            set { _NPOTIME = value; }
        }
        public DateTime ORDERDATE
        {
            get { return _ORDERDATE; }
            set { _ORDERDATE = value; }
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
        public string REMARKS
        {
            get { return _REMARKS; }
            set { _REMARKS = value; }
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
            _AGE = "";
            _AN = "";
            _BEDNO = "";
            _BMI = "";
            _CONTROL = "";
            _FEEDNAME = "";
            _FOODCATEGORYNAME = "";
            _FOODTYPENAME = "";
            _HEIGHT = 0;
            _HN = "";
            _INCREASE = "";
            _ISNPO = "";
            _ISREGISTER = "";
            _LIMIT = "";
            _LOID = 0;
            _MILKNAME = "";
            _NEED = "";
            _NPOSTART = new DateTime(1, 1, 1);
            _NPOTIME = "";
            _ORDERDATE = new DateTime(1, 1, 1);
            _PATIENTNAME = "";
            _QTY = "";
            _REMARKS = "";
            _ROOMNO = "";
            _STATUS = "";
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
        /// Gets the select statement for V_ORDER_NPO table.
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
        /// Returns an indication whether the record of V_ORDER_NPO by specified condition is retrieved successfully.
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
                        if (!Convert.IsDBNull(zRdr["AGE"])) _AGE = zRdr["AGE"].ToString();
                        if (!Convert.IsDBNull(zRdr["AN"])) _AN = zRdr["AN"].ToString();
                        if (!Convert.IsDBNull(zRdr["BEDNO"])) _BEDNO = zRdr["BEDNO"].ToString();
                        if (!Convert.IsDBNull(zRdr["BMI"])) _BMI = zRdr["BMI"].ToString();
                        if (!Convert.IsDBNull(zRdr["CONTROL"])) _CONTROL = zRdr["CONTROL"].ToString();
                        if (!Convert.IsDBNull(zRdr["FEEDNAME"])) _FEEDNAME = zRdr["FEEDNAME"].ToString();
                        if (!Convert.IsDBNull(zRdr["FOODCATEGORYNAME"])) _FOODCATEGORYNAME = zRdr["FOODCATEGORYNAME"].ToString();
                        if (!Convert.IsDBNull(zRdr["FOODTYPENAME"])) _FOODTYPENAME = zRdr["FOODTYPENAME"].ToString();
                        if (!Convert.IsDBNull(zRdr["HEIGHT"])) _HEIGHT = Convert.ToDouble(zRdr["HEIGHT"]);
                        if (!Convert.IsDBNull(zRdr["HN"])) _HN = zRdr["HN"].ToString();
                        if (!Convert.IsDBNull(zRdr["INCREASE"])) _INCREASE = zRdr["INCREASE"].ToString();
                        if (!Convert.IsDBNull(zRdr["ISNPO"])) _ISNPO = zRdr["ISNPO"].ToString();
                        if (!Convert.IsDBNull(zRdr["ISREGISTER"])) _ISREGISTER = zRdr["ISREGISTER"].ToString();
                        if (!Convert.IsDBNull(zRdr["LIMIT"])) _LIMIT = zRdr["LIMIT"].ToString();
                        if (!Convert.IsDBNull(zRdr["LOID"])) _LOID = Convert.ToDouble(zRdr["LOID"]);
                        if (!Convert.IsDBNull(zRdr["MILKNAME"])) _MILKNAME = zRdr["MILKNAME"].ToString();
                        if (!Convert.IsDBNull(zRdr["NEED"])) _NEED = zRdr["NEED"].ToString();
                        if (!Convert.IsDBNull(zRdr["NPOSTART"])) _NPOSTART = Convert.ToDateTime(zRdr["NPOSTART"]);
                        if (!Convert.IsDBNull(zRdr["NPOTIME"])) _NPOTIME = zRdr["NPOTIME"].ToString();
                        if (!Convert.IsDBNull(zRdr["ORDERDATE"])) _ORDERDATE = Convert.ToDateTime(zRdr["ORDERDATE"]);
                        if (!Convert.IsDBNull(zRdr["PATIENTNAME"])) _PATIENTNAME = zRdr["PATIENTNAME"].ToString();
                        if (!Convert.IsDBNull(zRdr["QTY"])) _QTY = zRdr["QTY"].ToString();
                        if (!Convert.IsDBNull(zRdr["REMARKS"])) _REMARKS = zRdr["REMARKS"].ToString();
                        if (!Convert.IsDBNull(zRdr["ROOMNO"])) _ROOMNO = zRdr["ROOMNO"].ToString();
                        if (!Convert.IsDBNull(zRdr["STATUS"])) _STATUS = zRdr["STATUS"].ToString();
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



        #region My work Nang

        private string sql_rank
        {
            get
            {
                string sql = "SELECT CASE WHEN RANK() OVER(PARTITION BY PATIENTNAME ORDER BY PATIENTNAME, WARD) = 1 THEN 1 ELSE 0 END RANK,CASE WHEN A.STATUS = 'FN' THEN 'งดอาหาร' END STATUSNAME, A.* FROM " + viewName + " A ";
                return sql;
            }
        }

        public DataTable GetRankDataList(string whereClause, string orderBy, OracleTransaction trans)
        {
            DataTable dt = DB.ExecuteTable(sql_rank + (whereClause == "" ? "" : "WHERE " + whereClause + " ") + (orderBy == "" ? "" : "ORDER BY " + DB.SetSortString(orderBy)), trans);
            int index = 1;
            for (int i = 0; i < dt.Rows.Count; ++i)
            {
                if (Convert.ToDouble(dt.Rows[i]["RANK"]) == 1)
                {
                    dt.Rows[i]["RANK"] = index;
                    ++index;
                }
            }
            return dt;
        }

        public DataTable GetDataListByConditions(double cWARD, string cPATIENTNAME, DateTime cORDERDATEFROM, DateTime cORDERDATETO , string ORDERTYPE,string orderBy, OracleTransaction trans)
        {
            string whText = " ISNPO = 'Y' AND STATUS = 'FN' AND ISREGISTER = 'N' ";

            if (cWARD != 0) whText += (whText == "" ? "" : "AND ") + "WARDID = " + DB.SetDouble(cWARD) + " ";
            if (cPATIENTNAME.Trim() != "") whText += (whText == "" ? "" : "AND ") + "UPPER(PATIENTNAME) LIKE UPPER(" + DB.SetString("%" + cPATIENTNAME.Trim() + "%") + ") ";
            if (ORDERTYPE.Trim() != "") whText += (whText == "" ? "" : "AND ") + "UPPER(ORDERTYPE) = UPPER(" + DB.SetString(ORDERTYPE.Trim()) + ") ";
            if (cORDERDATEFROM.Year != 1) whText += (whText == "" ? "" : "AND ") + "(NPOSTART >= " + DB.SetDateTime(cORDERDATEFROM) + " OR ORDERDATE >=" + DB.SetDateTime(cORDERDATEFROM) + ") ";
            if (cORDERDATETO.Year != 1) whText += (whText == "" ? "" : "AND ") + "(NPOSTART <= " + DB.SetDateTime(cORDERDATETO) + " OR ORDERDATE <=" + DB.SetDateTime(cORDERDATETO) + ") ";

            return GetRankDataList(whText, orderBy, trans);
        }

        #endregion
    }
}