using System;
using System.Data;
using System.Data.OracleClient;
using DB = SHND.DAL.Utilities.OracleDB;
using SHND.Data.Common.Utilities;

namespace SHND.DAL.Views
{
    /// <summary>
    /// Represents a transaction for V_STDMENU_SEARCH view.
    /// [Created by 127.0.0.1 on January,19 2009]
    /// </summary>
    public class VStdMenuSearchDAL
    {

        public VStdMenuSearchDAL()
        {
        }

        #region Constant

        /// <summary>V_STDMENU_SEARCH</summary>
        private const string viewName = "V_STDMENU_SEARCH";

        #endregion

        #region Private Variables

        string _error = "";
        string _information = "";
        bool _OnDB = false;
        string _ACTIVE = "";
        string _ACTIVENAME = "";
        double _DAY0111 = 0;
        double _DAY0121 = 0;
        double _DAY0131 = 0;
        double _DAY0211 = 0;
        double _DAY0221 = 0;
        double _DAY0231 = 0;
        double _DAY0311 = 0;
        double _DAY0321 = 0;
        double _DAY0331 = 0;
        double _DAY0411 = 0;
        double _DAY0421 = 0;
        double _DAY0431 = 0;
        double _DAY0511 = 0;
        double _DAY0521 = 0;
        double _DAY0531 = 0;
        double _DAY0611 = 0;
        double _DAY0621 = 0;
        double _DAY0631 = 0;
        double _DAY0711 = 0;
        double _DAY0721 = 0;
        double _DAY0731 = 0;
        double _DAY0811 = 0;
        double _DAY0821 = 0;
        double _DAY0831 = 0;
        double _DAY0911 = 0;
        double _DAY0921 = 0;
        double _DAY0931 = 0;
        double _DAY1011 = 0;
        double _DAY1021 = 0;
        double _DAY1031 = 0;
        double _DAY1111 = 0;
        double _DAY1121 = 0;
        double _DAY1131 = 0;
        double _DAY1211 = 0;
        double _DAY1221 = 0;
        double _DAY1231 = 0;
        double _DAY1311 = 0;
        double _DAY1321 = 0;
        double _DAY1331 = 0;
        double _DAY1411 = 0;
        double _DAY1421 = 0;
        double _DAY1431 = 0;
        double _DAY1511 = 0;
        double _DAY1521 = 0;
        double _DAY1531 = 0;
        double _DAY1611 = 0;
        double _DAY1621 = 0;
        double _DAY1631 = 0;
        double _DAY1711 = 0;
        double _DAY1721 = 0;
        double _DAY1731 = 0;
        double _DAY1811 = 0;
        double _DAY1821 = 0;
        double _DAY1831 = 0;
        double _DAY1911 = 0;
        double _DAY1921 = 0;
        double _DAY1931 = 0;
        double _DAY2011 = 0;
        double _DAY2021 = 0;
        double _DAY2031 = 0;
        double _DAY2111 = 0;
        double _DAY2121 = 0;
        double _DAY2131 = 0;
        double _DAY2211 = 0;
        double _DAY2221 = 0;
        double _DAY2231 = 0;
        double _DAY2311 = 0;
        double _DAY2321 = 0;
        double _DAY2331 = 0;
        double _DAY2411 = 0;
        double _DAY2421 = 0;
        double _DAY2431 = 0;
        double _DAY2511 = 0;
        double _DAY2521 = 0;
        double _DAY2531 = 0;
        double _DAY2611 = 0;
        double _DAY2621 = 0;
        double _DAY2631 = 0;
        double _DAY2711 = 0;
        double _DAY2721 = 0;
        double _DAY2731 = 0;
        double _DAY2811 = 0;
        double _DAY2821 = 0;
        double _DAY2831 = 0;
        double _DAY2911 = 0;
        double _DAY2921 = 0;
        double _DAY2931 = 0;
        double _DAY3011 = 0;
        double _DAY3021 = 0;
        double _DAY3031 = 0;
        double _DAY3111 = 0;
        double _DAY3121 = 0;
        double _DAY3131 = 0;
        double _DIVISION = 0;
        string _DIVISIONNAME = "";
        double _FOODCATEGORY = 0;
        string _FOODCATEGORYNAME = "";
        double _FOODTYPE = 0;
        string _FOODTYPENAME = "";
        string _ISSPECIFIC = "";
        string _ISSPECIFICTYPE = "";
        double _LOID = 0;
        string _NAME = "";
        string _STATUS = "";
        string _STATUSNAME = "";
        string _STATUSRANK = "";

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
        public string ACTIVE
        {
            get { return _ACTIVE; }
            set { _ACTIVE = value; }
        }
        public string ACTIVENAME
        {
            get { return _ACTIVENAME; }
            set { _ACTIVENAME = value; }
        }
        public double DAY0111
        {
            get { return _DAY0111; }
            set { _DAY0111 = value; }
        }
        public double DAY0121
        {
            get { return _DAY0121; }
            set { _DAY0121 = value; }
        }
        public double DAY0131
        {
            get { return _DAY0131; }
            set { _DAY0131 = value; }
        }
        public double DAY0211
        {
            get { return _DAY0211; }
            set { _DAY0211 = value; }
        }
        public double DAY0221
        {
            get { return _DAY0221; }
            set { _DAY0221 = value; }
        }
        public double DAY0231
        {
            get { return _DAY0231; }
            set { _DAY0231 = value; }
        }
        public double DAY0311
        {
            get { return _DAY0311; }
            set { _DAY0311 = value; }
        }
        public double DAY0321
        {
            get { return _DAY0321; }
            set { _DAY0321 = value; }
        }
        public double DAY0331
        {
            get { return _DAY0331; }
            set { _DAY0331 = value; }
        }
        public double DAY0411
        {
            get { return _DAY0411; }
            set { _DAY0411 = value; }
        }
        public double DAY0421
        {
            get { return _DAY0421; }
            set { _DAY0421 = value; }
        }
        public double DAY0431
        {
            get { return _DAY0431; }
            set { _DAY0431 = value; }
        }
        public double DAY0511
        {
            get { return _DAY0511; }
            set { _DAY0511 = value; }
        }
        public double DAY0521
        {
            get { return _DAY0521; }
            set { _DAY0521 = value; }
        }
        public double DAY0531
        {
            get { return _DAY0531; }
            set { _DAY0531 = value; }
        }
        public double DAY0611
        {
            get { return _DAY0611; }
            set { _DAY0611 = value; }
        }
        public double DAY0621
        {
            get { return _DAY0621; }
            set { _DAY0621 = value; }
        }
        public double DAY0631
        {
            get { return _DAY0631; }
            set { _DAY0631 = value; }
        }
        public double DAY0711
        {
            get { return _DAY0711; }
            set { _DAY0711 = value; }
        }
        public double DAY0721
        {
            get { return _DAY0721; }
            set { _DAY0721 = value; }
        }
        public double DAY0731
        {
            get { return _DAY0731; }
            set { _DAY0731 = value; }
        }
        public double DAY0811
        {
            get { return _DAY0811; }
            set { _DAY0811 = value; }
        }
        public double DAY0821
        {
            get { return _DAY0821; }
            set { _DAY0821 = value; }
        }
        public double DAY0831
        {
            get { return _DAY0831; }
            set { _DAY0831 = value; }
        }
        public double DAY0911
        {
            get { return _DAY0911; }
            set { _DAY0911 = value; }
        }
        public double DAY0921
        {
            get { return _DAY0921; }
            set { _DAY0921 = value; }
        }
        public double DAY0931
        {
            get { return _DAY0931; }
            set { _DAY0931 = value; }
        }
        public double DAY1011
        {
            get { return _DAY1011; }
            set { _DAY1011 = value; }
        }
        public double DAY1021
        {
            get { return _DAY1021; }
            set { _DAY1021 = value; }
        }
        public double DAY1031
        {
            get { return _DAY1031; }
            set { _DAY1031 = value; }
        }
        public double DAY1111
        {
            get { return _DAY1111; }
            set { _DAY1111 = value; }
        }
        public double DAY1121
        {
            get { return _DAY1121; }
            set { _DAY1121 = value; }
        }
        public double DAY1131
        {
            get { return _DAY1131; }
            set { _DAY1131 = value; }
        }
        public double DAY1211
        {
            get { return _DAY1211; }
            set { _DAY1211 = value; }
        }
        public double DAY1221
        {
            get { return _DAY1221; }
            set { _DAY1221 = value; }
        }
        public double DAY1231
        {
            get { return _DAY1231; }
            set { _DAY1231 = value; }
        }
        public double DAY1311
        {
            get { return _DAY1311; }
            set { _DAY1311 = value; }
        }
        public double DAY1321
        {
            get { return _DAY1321; }
            set { _DAY1321 = value; }
        }
        public double DAY1331
        {
            get { return _DAY1331; }
            set { _DAY1331 = value; }
        }
        public double DAY1411
        {
            get { return _DAY1411; }
            set { _DAY1411 = value; }
        }
        public double DAY1421
        {
            get { return _DAY1421; }
            set { _DAY1421 = value; }
        }
        public double DAY1431
        {
            get { return _DAY1431; }
            set { _DAY1431 = value; }
        }
        public double DAY1511
        {
            get { return _DAY1511; }
            set { _DAY1511 = value; }
        }
        public double DAY1521
        {
            get { return _DAY1521; }
            set { _DAY1521 = value; }
        }
        public double DAY1531
        {
            get { return _DAY1531; }
            set { _DAY1531 = value; }
        }
        public double DAY1611
        {
            get { return _DAY1611; }
            set { _DAY1611 = value; }
        }
        public double DAY1621
        {
            get { return _DAY1621; }
            set { _DAY1621 = value; }
        }
        public double DAY1631
        {
            get { return _DAY1631; }
            set { _DAY1631 = value; }
        }
        public double DAY1711
        {
            get { return _DAY1711; }
            set { _DAY1711 = value; }
        }
        public double DAY1721
        {
            get { return _DAY1721; }
            set { _DAY1721 = value; }
        }
        public double DAY1731
        {
            get { return _DAY1731; }
            set { _DAY1731 = value; }
        }
        public double DAY1811
        {
            get { return _DAY1811; }
            set { _DAY1811 = value; }
        }
        public double DAY1821
        {
            get { return _DAY1821; }
            set { _DAY1821 = value; }
        }
        public double DAY1831
        {
            get { return _DAY1831; }
            set { _DAY1831 = value; }
        }
        public double DAY1911
        {
            get { return _DAY1911; }
            set { _DAY1911 = value; }
        }
        public double DAY1921
        {
            get { return _DAY1921; }
            set { _DAY1921 = value; }
        }
        public double DAY1931
        {
            get { return _DAY1931; }
            set { _DAY1931 = value; }
        }
        public double DAY2011
        {
            get { return _DAY2011; }
            set { _DAY2011 = value; }
        }
        public double DAY2021
        {
            get { return _DAY2021; }
            set { _DAY2021 = value; }
        }
        public double DAY2031
        {
            get { return _DAY2031; }
            set { _DAY2031 = value; }
        }
        public double DAY2111
        {
            get { return _DAY2111; }
            set { _DAY2111 = value; }
        }
        public double DAY2121
        {
            get { return _DAY2121; }
            set { _DAY2121 = value; }
        }
        public double DAY2131
        {
            get { return _DAY2131; }
            set { _DAY2131 = value; }
        }
        public double DAY2211
        {
            get { return _DAY2211; }
            set { _DAY2211 = value; }
        }
        public double DAY2221
        {
            get { return _DAY2221; }
            set { _DAY2221 = value; }
        }
        public double DAY2231
        {
            get { return _DAY2231; }
            set { _DAY2231 = value; }
        }
        public double DAY2311
        {
            get { return _DAY2311; }
            set { _DAY2311 = value; }
        }
        public double DAY2321
        {
            get { return _DAY2321; }
            set { _DAY2321 = value; }
        }
        public double DAY2331
        {
            get { return _DAY2331; }
            set { _DAY2331 = value; }
        }
        public double DAY2411
        {
            get { return _DAY2411; }
            set { _DAY2411 = value; }
        }
        public double DAY2421
        {
            get { return _DAY2421; }
            set { _DAY2421 = value; }
        }
        public double DAY2431
        {
            get { return _DAY2431; }
            set { _DAY2431 = value; }
        }
        public double DAY2511
        {
            get { return _DAY2511; }
            set { _DAY2511 = value; }
        }
        public double DAY2521
        {
            get { return _DAY2521; }
            set { _DAY2521 = value; }
        }
        public double DAY2531
        {
            get { return _DAY2531; }
            set { _DAY2531 = value; }
        }
        public double DAY2611
        {
            get { return _DAY2611; }
            set { _DAY2611 = value; }
        }
        public double DAY2621
        {
            get { return _DAY2621; }
            set { _DAY2621 = value; }
        }
        public double DAY2631
        {
            get { return _DAY2631; }
            set { _DAY2631 = value; }
        }
        public double DAY2711
        {
            get { return _DAY2711; }
            set { _DAY2711 = value; }
        }
        public double DAY2721
        {
            get { return _DAY2721; }
            set { _DAY2721 = value; }
        }
        public double DAY2731
        {
            get { return _DAY2731; }
            set { _DAY2731 = value; }
        }
        public double DAY2811
        {
            get { return _DAY2811; }
            set { _DAY2811 = value; }
        }
        public double DAY2821
        {
            get { return _DAY2821; }
            set { _DAY2821 = value; }
        }
        public double DAY2831
        {
            get { return _DAY2831; }
            set { _DAY2831 = value; }
        }
        public double DAY2911
        {
            get { return _DAY2911; }
            set { _DAY2911 = value; }
        }
        public double DAY2921
        {
            get { return _DAY2921; }
            set { _DAY2921 = value; }
        }
        public double DAY2931
        {
            get { return _DAY2931; }
            set { _DAY2931 = value; }
        }
        public double DAY3011
        {
            get { return _DAY3011; }
            set { _DAY3011 = value; }
        }
        public double DAY3021
        {
            get { return _DAY3021; }
            set { _DAY3021 = value; }
        }
        public double DAY3031
        {
            get { return _DAY3031; }
            set { _DAY3031 = value; }
        }
        public double DAY3111
        {
            get { return _DAY3111; }
            set { _DAY3111 = value; }
        }
        public double DAY3121
        {
            get { return _DAY3121; }
            set { _DAY3121 = value; }
        }
        public double DAY3131
        {
            get { return _DAY3131; }
            set { _DAY3131 = value; }
        }
        public double DIVISION
        {
            get { return _DIVISION; }
            set { _DIVISION = value; }
        }
        public string DIVISIONNAME
        {
            get { return _DIVISIONNAME; }
            set { _DIVISIONNAME = value; }
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
        public string ISSPECIFIC
        {
            get { return _ISSPECIFIC; }
            set { _ISSPECIFIC = value; }
        }
        public string ISSPECIFICTYPE
        {
            get { return _ISSPECIFICTYPE; }
            set { _ISSPECIFICTYPE = value; }
        }
        public double LOID
        {
            get { return _LOID; }
            set { _LOID = value; }
        }
        public string NAME
        {
            get { return _NAME; }
            set { _NAME = value; }
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

        #endregion

        #region Clear Data

        /// <summary>
        /// Initialize data.
        /// </summary>
        private void ClearData()
        {
            _ACTIVE = "";
            _ACTIVENAME = "";
            _DAY0111 = 0;
            _DAY0121 = 0;
            _DAY0131 = 0;
            _DAY0211 = 0;
            _DAY0221 = 0;
            _DAY0231 = 0;
            _DAY0311 = 0;
            _DAY0321 = 0;
            _DAY0331 = 0;
            _DAY0411 = 0;
            _DAY0421 = 0;
            _DAY0431 = 0;
            _DAY0511 = 0;
            _DAY0521 = 0;
            _DAY0531 = 0;
            _DAY0611 = 0;
            _DAY0621 = 0;
            _DAY0631 = 0;
            _DAY0711 = 0;
            _DAY0721 = 0;
            _DAY0731 = 0;
            _DAY0811 = 0;
            _DAY0821 = 0;
            _DAY0831 = 0;
            _DAY0911 = 0;
            _DAY0921 = 0;
            _DAY0931 = 0;
            _DAY1011 = 0;
            _DAY1021 = 0;
            _DAY1031 = 0;
            _DAY1111 = 0;
            _DAY1121 = 0;
            _DAY1131 = 0;
            _DAY1211 = 0;
            _DAY1221 = 0;
            _DAY1231 = 0;
            _DAY1311 = 0;
            _DAY1321 = 0;
            _DAY1331 = 0;
            _DAY1411 = 0;
            _DAY1421 = 0;
            _DAY1431 = 0;
            _DAY1511 = 0;
            _DAY1521 = 0;
            _DAY1531 = 0;
            _DAY1611 = 0;
            _DAY1621 = 0;
            _DAY1631 = 0;
            _DAY1711 = 0;
            _DAY1721 = 0;
            _DAY1731 = 0;
            _DAY1811 = 0;
            _DAY1821 = 0;
            _DAY1831 = 0;
            _DAY1911 = 0;
            _DAY1921 = 0;
            _DAY1931 = 0;
            _DAY2011 = 0;
            _DAY2021 = 0;
            _DAY2031 = 0;
            _DAY2111 = 0;
            _DAY2121 = 0;
            _DAY2131 = 0;
            _DAY2211 = 0;
            _DAY2221 = 0;
            _DAY2231 = 0;
            _DAY2311 = 0;
            _DAY2321 = 0;
            _DAY2331 = 0;
            _DAY2411 = 0;
            _DAY2421 = 0;
            _DAY2431 = 0;
            _DAY2511 = 0;
            _DAY2521 = 0;
            _DAY2531 = 0;
            _DAY2611 = 0;
            _DAY2621 = 0;
            _DAY2631 = 0;
            _DAY2711 = 0;
            _DAY2721 = 0;
            _DAY2731 = 0;
            _DAY2811 = 0;
            _DAY2821 = 0;
            _DAY2831 = 0;
            _DAY2911 = 0;
            _DAY2921 = 0;
            _DAY2931 = 0;
            _DAY3011 = 0;
            _DAY3021 = 0;
            _DAY3031 = 0;
            _DAY3111 = 0;
            _DAY3121 = 0;
            _DAY3131 = 0;
            _DIVISION = 0;
            _DIVISIONNAME = "";
            _FOODCATEGORY = 0;
            _FOODCATEGORYNAME = "";
            _FOODTYPE = 0;
            _FOODTYPENAME = "";
            _ISSPECIFIC = "";
            _ISSPECIFICTYPE = "";
            _LOID = 0;
            _NAME = "";
            _STATUS = "";
            _STATUSNAME = "";
            _STATUSRANK = "";
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
        /// Gets the select statement for V_STDMENU_SEARCH table.
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
        /// Returns an indication whether the record of V_STDMENU_SEARCH by specified condition is retrieved successfully.
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
                            if (!Convert.IsDBNull(zRdr["ACTIVE"])) _ACTIVE = zRdr["ACTIVE"].ToString();
                            if (!Convert.IsDBNull(zRdr["ACTIVENAME"])) _ACTIVENAME = zRdr["ACTIVENAME"].ToString();
                            if (!Convert.IsDBNull(zRdr["DAY0111"])) _DAY0111 = Convert.ToDouble(zRdr["DAY0111"]);
                            if (!Convert.IsDBNull(zRdr["DAY0121"])) _DAY0121 = Convert.ToDouble(zRdr["DAY0121"]);
                            if (!Convert.IsDBNull(zRdr["DAY0131"])) _DAY0131 = Convert.ToDouble(zRdr["DAY0131"]);
                            if (!Convert.IsDBNull(zRdr["DAY0211"])) _DAY0211 = Convert.ToDouble(zRdr["DAY0211"]);
                            if (!Convert.IsDBNull(zRdr["DAY0221"])) _DAY0221 = Convert.ToDouble(zRdr["DAY0221"]);
                            if (!Convert.IsDBNull(zRdr["DAY0231"])) _DAY0231 = Convert.ToDouble(zRdr["DAY0231"]);
                            if (!Convert.IsDBNull(zRdr["DAY0311"])) _DAY0311 = Convert.ToDouble(zRdr["DAY0311"]);
                            if (!Convert.IsDBNull(zRdr["DAY0321"])) _DAY0321 = Convert.ToDouble(zRdr["DAY0321"]);
                            if (!Convert.IsDBNull(zRdr["DAY0331"])) _DAY0331 = Convert.ToDouble(zRdr["DAY0331"]);
                            if (!Convert.IsDBNull(zRdr["DAY0411"])) _DAY0411 = Convert.ToDouble(zRdr["DAY0411"]);
                            if (!Convert.IsDBNull(zRdr["DAY0421"])) _DAY0421 = Convert.ToDouble(zRdr["DAY0421"]);
                            if (!Convert.IsDBNull(zRdr["DAY0431"])) _DAY0431 = Convert.ToDouble(zRdr["DAY0431"]);
                            if (!Convert.IsDBNull(zRdr["DAY0511"])) _DAY0511 = Convert.ToDouble(zRdr["DAY0511"]);
                            if (!Convert.IsDBNull(zRdr["DAY0521"])) _DAY0521 = Convert.ToDouble(zRdr["DAY0521"]);
                            if (!Convert.IsDBNull(zRdr["DAY0531"])) _DAY0531 = Convert.ToDouble(zRdr["DAY0531"]);
                            if (!Convert.IsDBNull(zRdr["DAY0611"])) _DAY0611 = Convert.ToDouble(zRdr["DAY0611"]);
                            if (!Convert.IsDBNull(zRdr["DAY0621"])) _DAY0621 = Convert.ToDouble(zRdr["DAY0621"]);
                            if (!Convert.IsDBNull(zRdr["DAY0631"])) _DAY0631 = Convert.ToDouble(zRdr["DAY0631"]);
                            if (!Convert.IsDBNull(zRdr["DAY0711"])) _DAY0711 = Convert.ToDouble(zRdr["DAY0711"]);
                            if (!Convert.IsDBNull(zRdr["DAY0721"])) _DAY0721 = Convert.ToDouble(zRdr["DAY0721"]);
                            if (!Convert.IsDBNull(zRdr["DAY0731"])) _DAY0731 = Convert.ToDouble(zRdr["DAY0731"]);
                            if (!Convert.IsDBNull(zRdr["DAY0811"])) _DAY0811 = Convert.ToDouble(zRdr["DAY0811"]);
                            if (!Convert.IsDBNull(zRdr["DAY0821"])) _DAY0821 = Convert.ToDouble(zRdr["DAY0821"]);
                            if (!Convert.IsDBNull(zRdr["DAY0831"])) _DAY0831 = Convert.ToDouble(zRdr["DAY0831"]);
                            if (!Convert.IsDBNull(zRdr["DAY0911"])) _DAY0911 = Convert.ToDouble(zRdr["DAY0911"]);
                            if (!Convert.IsDBNull(zRdr["DAY0921"])) _DAY0921 = Convert.ToDouble(zRdr["DAY0921"]);
                            if (!Convert.IsDBNull(zRdr["DAY0931"])) _DAY0931 = Convert.ToDouble(zRdr["DAY0931"]);
                            if (!Convert.IsDBNull(zRdr["DAY1011"])) _DAY1011 = Convert.ToDouble(zRdr["DAY1011"]);
                            if (!Convert.IsDBNull(zRdr["DAY1021"])) _DAY1021 = Convert.ToDouble(zRdr["DAY1021"]);
                            if (!Convert.IsDBNull(zRdr["DAY1031"])) _DAY1031 = Convert.ToDouble(zRdr["DAY1031"]);
                            if (!Convert.IsDBNull(zRdr["DAY1111"])) _DAY1111 = Convert.ToDouble(zRdr["DAY1111"]);
                            if (!Convert.IsDBNull(zRdr["DAY1121"])) _DAY1121 = Convert.ToDouble(zRdr["DAY1121"]);
                            if (!Convert.IsDBNull(zRdr["DAY1131"])) _DAY1131 = Convert.ToDouble(zRdr["DAY1131"]);
                            if (!Convert.IsDBNull(zRdr["DAY1211"])) _DAY1211 = Convert.ToDouble(zRdr["DAY1211"]);
                            if (!Convert.IsDBNull(zRdr["DAY1221"])) _DAY1221 = Convert.ToDouble(zRdr["DAY1221"]);
                            if (!Convert.IsDBNull(zRdr["DAY1231"])) _DAY1231 = Convert.ToDouble(zRdr["DAY1231"]);
                            if (!Convert.IsDBNull(zRdr["DAY1311"])) _DAY1311 = Convert.ToDouble(zRdr["DAY1311"]);
                            if (!Convert.IsDBNull(zRdr["DAY1321"])) _DAY1321 = Convert.ToDouble(zRdr["DAY1321"]);
                            if (!Convert.IsDBNull(zRdr["DAY1331"])) _DAY1331 = Convert.ToDouble(zRdr["DAY1331"]);
                            if (!Convert.IsDBNull(zRdr["DAY1411"])) _DAY1411 = Convert.ToDouble(zRdr["DAY1411"]);
                            if (!Convert.IsDBNull(zRdr["DAY1421"])) _DAY1421 = Convert.ToDouble(zRdr["DAY1421"]);
                            if (!Convert.IsDBNull(zRdr["DAY1431"])) _DAY1431 = Convert.ToDouble(zRdr["DAY1431"]);
                            if (!Convert.IsDBNull(zRdr["DAY1511"])) _DAY1511 = Convert.ToDouble(zRdr["DAY1511"]);
                            if (!Convert.IsDBNull(zRdr["DAY1521"])) _DAY1521 = Convert.ToDouble(zRdr["DAY1521"]);
                            if (!Convert.IsDBNull(zRdr["DAY1531"])) _DAY1531 = Convert.ToDouble(zRdr["DAY1531"]);
                            if (!Convert.IsDBNull(zRdr["DAY1611"])) _DAY1611 = Convert.ToDouble(zRdr["DAY1611"]);
                            if (!Convert.IsDBNull(zRdr["DAY1621"])) _DAY1621 = Convert.ToDouble(zRdr["DAY1621"]);
                            if (!Convert.IsDBNull(zRdr["DAY1631"])) _DAY1631 = Convert.ToDouble(zRdr["DAY1631"]);
                            if (!Convert.IsDBNull(zRdr["DAY1711"])) _DAY1711 = Convert.ToDouble(zRdr["DAY1711"]);
                            if (!Convert.IsDBNull(zRdr["DAY1721"])) _DAY1721 = Convert.ToDouble(zRdr["DAY1721"]);
                            if (!Convert.IsDBNull(zRdr["DAY1731"])) _DAY1731 = Convert.ToDouble(zRdr["DAY1731"]);
                            if (!Convert.IsDBNull(zRdr["DAY1811"])) _DAY1811 = Convert.ToDouble(zRdr["DAY1811"]);
                            if (!Convert.IsDBNull(zRdr["DAY1821"])) _DAY1821 = Convert.ToDouble(zRdr["DAY1821"]);
                            if (!Convert.IsDBNull(zRdr["DAY1831"])) _DAY1831 = Convert.ToDouble(zRdr["DAY1831"]);
                            if (!Convert.IsDBNull(zRdr["DAY1911"])) _DAY1911 = Convert.ToDouble(zRdr["DAY1911"]);
                            if (!Convert.IsDBNull(zRdr["DAY1921"])) _DAY1921 = Convert.ToDouble(zRdr["DAY1921"]);
                            if (!Convert.IsDBNull(zRdr["DAY1931"])) _DAY1931 = Convert.ToDouble(zRdr["DAY1931"]);
                            if (!Convert.IsDBNull(zRdr["DAY2011"])) _DAY2011 = Convert.ToDouble(zRdr["DAY2011"]);
                            if (!Convert.IsDBNull(zRdr["DAY2021"])) _DAY2021 = Convert.ToDouble(zRdr["DAY2021"]);
                            if (!Convert.IsDBNull(zRdr["DAY2031"])) _DAY2031 = Convert.ToDouble(zRdr["DAY2031"]);
                            if (!Convert.IsDBNull(zRdr["DAY2111"])) _DAY2111 = Convert.ToDouble(zRdr["DAY2111"]);
                            if (!Convert.IsDBNull(zRdr["DAY2121"])) _DAY2121 = Convert.ToDouble(zRdr["DAY2121"]);
                            if (!Convert.IsDBNull(zRdr["DAY2131"])) _DAY2131 = Convert.ToDouble(zRdr["DAY2131"]);
                            if (!Convert.IsDBNull(zRdr["DAY2211"])) _DAY2211 = Convert.ToDouble(zRdr["DAY2211"]);
                            if (!Convert.IsDBNull(zRdr["DAY2221"])) _DAY2221 = Convert.ToDouble(zRdr["DAY2221"]);
                            if (!Convert.IsDBNull(zRdr["DAY2231"])) _DAY2231 = Convert.ToDouble(zRdr["DAY2231"]);
                            if (!Convert.IsDBNull(zRdr["DAY2311"])) _DAY2311 = Convert.ToDouble(zRdr["DAY2311"]);
                            if (!Convert.IsDBNull(zRdr["DAY2321"])) _DAY2321 = Convert.ToDouble(zRdr["DAY2321"]);
                            if (!Convert.IsDBNull(zRdr["DAY2331"])) _DAY2331 = Convert.ToDouble(zRdr["DAY2331"]);
                            if (!Convert.IsDBNull(zRdr["DAY2411"])) _DAY2411 = Convert.ToDouble(zRdr["DAY2411"]);
                            if (!Convert.IsDBNull(zRdr["DAY2421"])) _DAY2421 = Convert.ToDouble(zRdr["DAY2421"]);
                            if (!Convert.IsDBNull(zRdr["DAY2431"])) _DAY2431 = Convert.ToDouble(zRdr["DAY2431"]);
                            if (!Convert.IsDBNull(zRdr["DAY2511"])) _DAY2511 = Convert.ToDouble(zRdr["DAY2511"]);
                            if (!Convert.IsDBNull(zRdr["DAY2521"])) _DAY2521 = Convert.ToDouble(zRdr["DAY2521"]);
                            if (!Convert.IsDBNull(zRdr["DAY2531"])) _DAY2531 = Convert.ToDouble(zRdr["DAY2531"]);
                            if (!Convert.IsDBNull(zRdr["DAY2611"])) _DAY2611 = Convert.ToDouble(zRdr["DAY2611"]);
                            if (!Convert.IsDBNull(zRdr["DAY2621"])) _DAY2621 = Convert.ToDouble(zRdr["DAY2621"]);
                            if (!Convert.IsDBNull(zRdr["DAY2631"])) _DAY2631 = Convert.ToDouble(zRdr["DAY2631"]);
                            if (!Convert.IsDBNull(zRdr["DAY2711"])) _DAY2711 = Convert.ToDouble(zRdr["DAY2711"]);
                            if (!Convert.IsDBNull(zRdr["DAY2721"])) _DAY2721 = Convert.ToDouble(zRdr["DAY2721"]);
                            if (!Convert.IsDBNull(zRdr["DAY2731"])) _DAY2731 = Convert.ToDouble(zRdr["DAY2731"]);
                            if (!Convert.IsDBNull(zRdr["DAY2811"])) _DAY2811 = Convert.ToDouble(zRdr["DAY2811"]);
                            if (!Convert.IsDBNull(zRdr["DAY2821"])) _DAY2821 = Convert.ToDouble(zRdr["DAY2821"]);
                            if (!Convert.IsDBNull(zRdr["DAY2831"])) _DAY2831 = Convert.ToDouble(zRdr["DAY2831"]);
                            if (!Convert.IsDBNull(zRdr["DAY2911"])) _DAY2911 = Convert.ToDouble(zRdr["DAY2911"]);
                            if (!Convert.IsDBNull(zRdr["DAY2921"])) _DAY2921 = Convert.ToDouble(zRdr["DAY2921"]);
                            if (!Convert.IsDBNull(zRdr["DAY2931"])) _DAY2931 = Convert.ToDouble(zRdr["DAY2931"]);
                            if (!Convert.IsDBNull(zRdr["DAY3011"])) _DAY3011 = Convert.ToDouble(zRdr["DAY3011"]);
                            if (!Convert.IsDBNull(zRdr["DAY3021"])) _DAY3021 = Convert.ToDouble(zRdr["DAY3021"]);
                            if (!Convert.IsDBNull(zRdr["DAY3031"])) _DAY3031 = Convert.ToDouble(zRdr["DAY3031"]);
                            if (!Convert.IsDBNull(zRdr["DAY3111"])) _DAY3111 = Convert.ToDouble(zRdr["DAY3111"]);
                            if (!Convert.IsDBNull(zRdr["DAY3121"])) _DAY3121 = Convert.ToDouble(zRdr["DAY3121"]);
                            if (!Convert.IsDBNull(zRdr["DAY3131"])) _DAY3131 = Convert.ToDouble(zRdr["DAY3131"]);
                            if (!Convert.IsDBNull(zRdr["DIVISION"])) _DIVISION = Convert.ToDouble(zRdr["DIVISION"]);
                            if (!Convert.IsDBNull(zRdr["DIVISIONNAME"])) _DIVISIONNAME = zRdr["DIVISIONNAME"].ToString();
                            if (!Convert.IsDBNull(zRdr["FOODCATEGORY"])) _FOODCATEGORY = Convert.ToDouble(zRdr["FOODCATEGORY"]);
                            if (!Convert.IsDBNull(zRdr["FOODCATEGORYNAME"])) _FOODCATEGORYNAME = zRdr["FOODCATEGORYNAME"].ToString();
                            if (!Convert.IsDBNull(zRdr["FOODTYPE"])) _FOODTYPE = Convert.ToDouble(zRdr["FOODTYPE"]);
                            if (!Convert.IsDBNull(zRdr["FOODTYPENAME"])) _FOODTYPENAME = zRdr["FOODTYPENAME"].ToString();
                            if (!Convert.IsDBNull(zRdr["ISSPECIFIC"])) _ISSPECIFIC = zRdr["ISSPECIFIC"].ToString();
                            if (!Convert.IsDBNull(zRdr["ISSPECIFICTYPE"])) _ISSPECIFICTYPE = zRdr["ISSPECIFICTYPE"].ToString();
                            if (!Convert.IsDBNull(zRdr["LOID"])) _LOID = Convert.ToDouble(zRdr["LOID"]);
                            if (!Convert.IsDBNull(zRdr["NAME"])) _NAME = zRdr["NAME"].ToString();
                            if (!Convert.IsDBNull(zRdr["STATUS"])) _STATUS = zRdr["STATUS"].ToString();
                            if (!Convert.IsDBNull(zRdr["STATUSNAME"])) _STATUSNAME = zRdr["STATUSNAME"].ToString();
                            if (!Convert.IsDBNull(zRdr["STATUSRANK"])) _STATUSRANK = zRdr["STATUSRANK"].ToString();
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

        public DataTable GetDataListByCondition(double cDIVISION, string cNAME, double cFOODTYPE, double cFOODCATEGORY, string cISSPECIFIC, string cSTATUSFROM, string cSTATUSTO, string orderBy, OracleTransaction trans)
        {
            string whText = "";
            if (cDIVISION != 0) whText += (whText == "" ? "" : "AND ") + "DIVISION = " + DB.SetDouble(cDIVISION) + " ";
            if (cNAME.Trim() != "") whText += (whText == "" ? "" : "AND ") + "UPPER(NAME) LIKE " + DB.SetString("%" + cNAME.ToUpper() + "%") + " ";
            if (cFOODTYPE != 0) whText += (whText == "" ? "" : "AND ") + "FOODTYPE = " + DB.SetDouble(cFOODTYPE) + " ";
            if (cFOODCATEGORY != 0) whText += (whText == "" ? "" : "AND ") + "FOODCATEGORY = " + DB.SetDouble(cFOODCATEGORY) + " ";
            if (cISSPECIFIC.Trim() != "") whText += (whText == "" ? "" : "AND ") + "ISSPECIFIC = " + DB.SetString(cISSPECIFIC) + " ";
            if (cSTATUSFROM.Trim() != "") whText += (whText == "" ? "" : "AND ") + "STATUSRANK >= " + DB.SetString(cSTATUSFROM) + " ";
            if (cSTATUSTO.Trim() != "") whText += (whText == "" ? "" : "AND ") + "STATUSRANK <= " + DB.SetString(cSTATUSTO) + " ";
            return GetDataList(whText, orderBy, trans);
        }

        public bool GetDataByLOID(double cLOID, OracleTransaction trans)
        {
            return doGetdata("LOID = " + DB.SetDouble(cLOID), trans);
        }

    }
}