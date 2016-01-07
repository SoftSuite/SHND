using System;
using System.Data;
using System.Data.OracleClient;
using DB = SHND.DAL.Utilities.OracleDB;
using SHND.Data.Common.Utilities;

namespace SHND.DAL.Views
{
    /// <summary>
    /// Represents a transaction for V_FORMULASET_MENU view.
    /// [Created by 127.0.0.1 on January,20 2009]
    /// </summary>
    public class VFormulaSetMenuDAL
    {

        public VFormulaSetMenuDAL()
        {
        }

        #region Constant

        /// <summary>V_FORMULASET_MENU</summary>
        private const string viewName = "V_FORMULASET_MENU";

        #endregion

        #region Private Variables

        string _error = "";
        string _information = "";
        bool _OnDB = false;
        string _CODE = "";
        double _DISEASECATEGORY = 0;
        double _ENERGY = 0;
        double _FOODCATEGORY = 0;
        double _FOODTYPE = 0;
        string _FORMULANAME = "";
        string _GROUPTYPE = "";
        string _ISSPECIFIC = "";
        double _LOID = 0;
        string _REFTYPE = "";
        string _STATUS = "";

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
        public string CODE
        {
            get { return _CODE; }
            set { _CODE = value; }
        }
        public double DISEASECATEGORY
        {
            get { return _DISEASECATEGORY; }
            set { _DISEASECATEGORY = value; }
        }
        public double ENERGY
        {
            get { return _ENERGY; }
            set { _ENERGY = value; }
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
        public string FORMULANAME
        {
            get { return _FORMULANAME; }
            set { _FORMULANAME = value; }
        }
        public string GROUPTYPE
        {
            get { return _GROUPTYPE; }
            set { _GROUPTYPE = value; }
        }
        public string ISSPECIFIC
        {
            get { return _ISSPECIFIC; }
            set { _ISSPECIFIC = value; }
        }
        public double LOID
        {
            get { return _LOID; }
            set { _LOID = value; }
        }
        public string REFTYPE
        {
            get { return _REFTYPE; }
            set { _REFTYPE = value; }
        }
        public string STATUS
        {
            get { return _STATUS; }
            set { _STATUS = value; }
        }

        #endregion

        #region Clear Data

        /// <summary>
        /// Initialize data.
        /// </summary>
        private void ClearData()
        {
            _CODE = "";
            _DISEASECATEGORY = 0;
            _ENERGY = 0;
            _FOODCATEGORY = 0;
            _FOODTYPE = 0;
            _FORMULANAME = "";
            _GROUPTYPE = "";
            _ISSPECIFIC = "";
            _LOID = 0;
            _REFTYPE = "";
            _STATUS = "";
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
        /// Gets the select statement for V_FORMULASET_MENU table.
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
        /// Returns an indication whether the record of V_FORMULASET_MENU by specified condition is retrieved successfully.
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
                            if (!Convert.IsDBNull(zRdr["CODE"])) _CODE = zRdr["CODE"].ToString();
                            if (!Convert.IsDBNull(zRdr["DISEASECATEGORY"])) _DISEASECATEGORY = Convert.ToDouble(zRdr["DISEASECATEGORY"]);
                            if (!Convert.IsDBNull(zRdr["ENERGY"])) _ENERGY = Convert.ToDouble(zRdr["ENERGY"]);
                            if (!Convert.IsDBNull(zRdr["FOODCATEGORY"])) _FOODCATEGORY = Convert.ToDouble(zRdr["FOODCATEGORY"]);
                            if (!Convert.IsDBNull(zRdr["FOODTYPE"])) _FOODTYPE = Convert.ToDouble(zRdr["FOODTYPE"]);
                            if (!Convert.IsDBNull(zRdr["FORMULANAME"])) _FORMULANAME = zRdr["FORMULANAME"].ToString();
                            if (!Convert.IsDBNull(zRdr["GROUPTYPE"])) _GROUPTYPE = zRdr["GROUPTYPE"].ToString();
                            if (!Convert.IsDBNull(zRdr["ISSPECIFIC"])) _ISSPECIFIC = zRdr["ISSPECIFIC"].ToString();
                            if (!Convert.IsDBNull(zRdr["LOID"])) _LOID = Convert.ToDouble(zRdr["LOID"]);
                            if (!Convert.IsDBNull(zRdr["REFTYPE"])) _REFTYPE = zRdr["REFTYPE"].ToString();
                            if (!Convert.IsDBNull(zRdr["STATUS"])) _STATUS = zRdr["STATUS"].ToString();
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

        public DataTable GetDataListSource(double cSTDMENU, string cMEAL, int cMENUDATE, string cGROUPTYPE, double cFOODTYPE, string orderBy, OracleTransaction trans)
        {
            return GetDataList("GROUPTYPE = " + DB.SetString(cGROUPTYPE) + " AND (FOODTYPE = " + DB.SetDouble(cFOODTYPE) + " OR FOODTYPE IS NULL) AND CODE NOT IN (SELECT CODE FROM V_STDMENUITEM " +
                "WHERE STDMENU = " + DB.SetDouble(cSTDMENU) + " AND (FOODTYPE = " + DB.SetDouble(cFOODTYPE) + " OR FOODTYPE IS NULL) " +
                "AND MEAL = " + DB.SetString(cMEAL) + " AND MENUDATE = " + DB.SetDouble(cMENUDATE) + " AND GROUPTYPE = " + DB.SetString(cGROUPTYPE) + ") " +
                "AND (NVL(DISEASECATEGORY,'#') = NVL(FN_GETMENUDISEASE(" + DB.SetDouble(cSTDMENU) + ",'STD'),'#') OR REFTYPE='MATERIALMASTER') AND ISELEMENT<>'Y'", orderBy, trans);
        }

        //public DataTable GetDataListSelected(double cSTDMENU, string cMEAL, int cMENUDATE, string cGROUPTYPE, string orderBy, OracleTransaction trans)
        //{
        //    return GetDataList("GROUPTYPE = " + DB.SetString(cGROUPTYPE) + " AND CODE IN (SELECT CODE FROM V_STDMENUITEM WHERE STDMENU = " + DB.SetDouble(cSTDMENU) +
        //        " AND MEAL = " + DB.SetString(cMEAL) + " AND MENUDATE = " + DB.SetDouble(cMENUDATE) + " AND GROUPTYPE = " + DB.SetString(cGROUPTYPE) + ") ", orderBy, trans);
        //}

        public DataTable GetDataListSourceMenu(double cMENU, string cMEAL, DateTime cMENUDATE, string cGROUPTYPE, double cFOODTYPE, double cFOODCATEGORY, string orderBy, OracleTransaction trans)
        {
            return GetDataList("GROUPTYPE = " + DB.SetString(cGROUPTYPE) + " AND (FOODTYPE = " + DB.SetDouble(cFOODTYPE) + " OR FOODTYPE IS NULL) AND (FOODCATEGORY=" + DB.SetDouble(cFOODCATEGORY) +  " OR FOODCATEGORY IS NULL ) " + 
                " AND CODE NOT IN (SELECT CODE FROM V_MENUITEM WHERE MENU = " + DB.SetDouble(cMENU) +
                " AND MEAL = " + DB.SetString(cMEAL) + " AND MENUDATE = " + DB.SetDateTime(cMENUDATE) + " AND GROUPTYPE = " + DB.SetString(cGROUPTYPE) + ") " +
                " AND (NVL(DISEASECATEGORY,'#') = NVL(FN_GETMENUDISEASE(" + DB.SetDouble(cMENU) + ",'MENU'),'#') OR REFTYPE='MATERIALMASTER') AND ISELEMENT<>'Y'", orderBy, trans);
        }

    }
}