using System;
using System.Data;
using System.Data.OracleClient;
using DB = SHND.DAL.Utilities.OracleDB;
using SHND.Data.Common.Utilities;

namespace SHND.DAL.Views
{
    /// <summary>
    /// Represents a transaction for V_ORDERSET_SLIP view.
    /// [Created by 127.0.0.1 on April,21 2009]
    /// </summary>
    public class VOrderSetSlipDAL
    {

        public VOrderSetSlipDAL()
        {
        }

        #region Constant

        /// <summary>V_ORDERSET_SLIP</summary>
        private const string viewName = "V_ORDERSET_SLIP";

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
        double _FOODCATEGORY = 0;
        string _FOODCATEGORYNAME = "";
        double _FOODTYPE = 0;
        string _FOODTYPENAME = "";
        string _HN = "";
        string _IMGURL = "";
        string _INCREASE = "";
        string _LIMIT = "";
        double _LOID = 0;
        string _MEALNAME = "";
        string _NEED = "";
        DateTime _ORDERDATE = new DateTime(1, 1, 1);
        double _ORDERMEDICALSETID = 0;
        double _ORDERNONMEDICALID = 0;
        string _PATIENTNAME = "";
        DateTime _REGISTERDATE = new DateTime(1, 1, 1);
        string _REMARKS = "";
        string _ROOMNO = "";
        string _VN = "";
        double _WARDID = 0;
        string _WARDNAME = "";

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
        public double FOODCATEGORY
        {
            get { return _FOODCATEGORY; }
            set { _FOODCATEGORY = value; }
        }
        public string FOODCATEGORYNAME
        {
            get { return _FOODCATEGORYNAME; }
            set { _FOODCATEGORYNAME = value; }
        }
        public double FOODTYPE
        {
            get { return _FOODTYPE; }
            set { _FOODTYPE = value; }
        }
        public string FOODTYPENAME
        {
            get { return _FOODTYPENAME; }
            set { _FOODTYPENAME = value; }
        }
        public string HN
        {
            get { return _HN; }
            set { _HN = value; }
        }
        public string IMGURL
        {
            get { return _IMGURL; }
            set { _IMGURL = value; }
        }
        public string INCREASE
        {
            get { return _INCREASE; }
            set { _INCREASE = value; }
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
        public string MEALNAME
        {
            get { return _MEALNAME; }
            set { _MEALNAME = value; }
        }
        public string NEED
        {
            get { return _NEED; }
            set { _NEED = value; }
        }
        public DateTime ORDERDATE
        {
            get { return _ORDERDATE; }
            set { _ORDERDATE = value; }
        }
        public double ORDERMEDICALSETID
        {
            get { return _ORDERMEDICALSETID; }
            set { _ORDERMEDICALSETID = value; }
        }
        public double ORDERNONMEDICALID
        {
            get { return _ORDERNONMEDICALID; }
            set { _ORDERNONMEDICALID = value; }
        }
        public string PATIENTNAME
        {
            get { return _PATIENTNAME; }
            set { _PATIENTNAME = value; }
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
        public string ROOMNO
        {
            get { return _ROOMNO; }
            set { _ROOMNO = value; }
        }
        public string VN
        {
            get { return _VN; }
            set { _VN = value; }
        }
        public double WARDID
        {
            get { return _WARDID; }
            set { _WARDID = value; }
        }
        public string WARDNAME
        {
            get { return _WARDNAME; }
            set { _WARDNAME = value; }
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
            _FOODCATEGORY = 0;
            _FOODCATEGORYNAME = "";
            _FOODTYPE = 0;
            _FOODTYPENAME = "";
            _HN = "";
            _IMGURL = "";
            _INCREASE = "";
            _LIMIT = "";
            _LOID = 0;
            _MEALNAME = "";
            _NEED = "";
            _ORDERDATE = new DateTime(1, 1, 1);
            _ORDERMEDICALSETID = 0;
            _ORDERNONMEDICALID = 0;
            _PATIENTNAME = "";
            _REGISTERDATE = new DateTime(1, 1, 1);
            _REMARKS = "";
            _ROOMNO = "";
            _VN = "";
            _WARDID = 0;
            _WARDNAME = "";
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
        /// Gets the select statement for V_ORDERSET_SLIP table.
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
        /// Returns an indication whether the record of V_ORDERSET_SLIP by specified condition is retrieved successfully.
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
                        if (!Convert.IsDBNull(zRdr["FOODCATEGORY"])) _FOODCATEGORY = Convert.ToDouble(zRdr["FOODCATEGORY"]);
                        if (!Convert.IsDBNull(zRdr["FOODCATEGORYNAME"])) _FOODCATEGORYNAME = zRdr["FOODCATEGORYNAME"].ToString();
                        if (!Convert.IsDBNull(zRdr["FOODTYPE"])) _FOODTYPE = Convert.ToDouble(zRdr["FOODTYPE"]);
                        if (!Convert.IsDBNull(zRdr["FOODTYPENAME"])) _FOODTYPENAME = zRdr["FOODTYPENAME"].ToString();
                        if (!Convert.IsDBNull(zRdr["HN"])) _HN = zRdr["HN"].ToString();
                        if (!Convert.IsDBNull(zRdr["IMGURL"])) _IMGURL = zRdr["IMGURL"].ToString();
                        if (!Convert.IsDBNull(zRdr["INCREASE"])) _INCREASE = zRdr["INCREASE"].ToString();
                        if (!Convert.IsDBNull(zRdr["LIMIT"])) _LIMIT = zRdr["LIMIT"].ToString();
                        if (!Convert.IsDBNull(zRdr["LOID"])) _LOID = Convert.ToDouble(zRdr["LOID"]);
                        if (!Convert.IsDBNull(zRdr["MEALNAME"])) _MEALNAME = zRdr["MEALNAME"].ToString();
                        if (!Convert.IsDBNull(zRdr["NEED"])) _NEED = zRdr["NEED"].ToString();
                        if (!Convert.IsDBNull(zRdr["ORDERDATE"])) _ORDERDATE = Convert.ToDateTime(zRdr["ORDERDATE"]);
                        if (!Convert.IsDBNull(zRdr["ORDERMEDICALSETID"])) _ORDERMEDICALSETID = Convert.ToDouble(zRdr["ORDERMEDICALSETID"]);
                        if (!Convert.IsDBNull(zRdr["ORDERNONMEDICALID"])) _ORDERNONMEDICALID = Convert.ToDouble(zRdr["ORDERNONMEDICALID"]);
                        if (!Convert.IsDBNull(zRdr["PATIENTNAME"])) _PATIENTNAME = zRdr["PATIENTNAME"].ToString();
                        if (!Convert.IsDBNull(zRdr["REGISTERDATE"])) _REGISTERDATE = Convert.ToDateTime(zRdr["REGISTERDATE"]);
                        if (!Convert.IsDBNull(zRdr["REMARKS"])) _REMARKS = zRdr["REMARKS"].ToString();
                        if (!Convert.IsDBNull(zRdr["ROOMNO"])) _ROOMNO = zRdr["ROOMNO"].ToString();
                        if (!Convert.IsDBNull(zRdr["VN"])) _VN = zRdr["VN"].ToString();
                        if (!Convert.IsDBNull(zRdr["WARDID"])) _WARDID = Convert.ToDouble(zRdr["WARDID"]);
                        if (!Convert.IsDBNull(zRdr["WARDNAME"])) _WARDNAME = zRdr["WARDNAME"].ToString();
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