using System;
using System.Data;
using System.Data.OracleClient;
using DB = SHND.DAL.Utilities.OracleDB;
using SHND.Data.Common.Utilities;

namespace SHND.DAL.Views
{
    /// <summary>
    /// Represents a transaction for V_PLANFOOD_DIVISION_MATERIAL view.
    /// [Created by 127.0.0.1 on Febuary,11 2009]
    /// </summary>
    public class VPlanFoodDivisionMaterialDAL
    {

        public VPlanFoodDivisionMaterialDAL()
        {
        }

        #region Constant

        /// <summary>V_PLANFOOD_DIVISION_MATERIAL</summary>
        private const string viewName = "V_PLANFOOD_DIVISION_MATERIAL";

        #endregion

        #region Private Variables

        string _error = "";
        string _information = "";
        bool _OnDB = false;
        double _ADJQTY = 0;
        string _CLASSNAME = "";
        double _DIVISION = 0;
        string _DIVISIONNAME = "";
        double _LOID = 0;
        double _MATERIALMASTER = 0;
        string _MATERIALNAME = "";
        double _MENUQTY = 0;
        double _PLANMATERIALCLASS = 0;
        double _PLANMATERIALITEM = 0;
        double _PLANORDER = 0;
        double _PLANQTY = 0;
        double _REQQTY = 0;
        string _SAPCODE = "";
        string _SPEC = "";
        string _STATUS = "";
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
        public double LOID
        {
            get { return _LOID; }
            set { _LOID = value; }
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
        public double PLANMATERIALCLASS
        {
            get { return _PLANMATERIALCLASS; }
            set { _PLANMATERIALCLASS = value; }
        }
        public double PLANMATERIALITEM
        {
            get { return _PLANMATERIALITEM; }
            set { _PLANMATERIALITEM = value; }
        }
        public double PLANORDER
        {
            get { return _PLANORDER; }
            set { _PLANORDER = value; }
        }
        public double PLANQTY
        {
            get { return _PLANQTY; }
            set { _PLANQTY = value; }
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
        public string SPEC
        {
            get { return _SPEC; }
            set { _SPEC = value; }
        }
        public string STATUS
        {
            get { return _STATUS; }
            set { _STATUS = value; }
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
            _DIVISION = 0;
            _DIVISIONNAME = "";
            _LOID = 0;
            _MATERIALMASTER = 0;
            _MATERIALNAME = "";
            _MENUQTY = 0;
            _PLANMATERIALCLASS = 0;
            _PLANMATERIALITEM = 0;
            _PLANORDER = 0;
            _PLANQTY = 0;
            _REQQTY = 0;
            _SAPCODE = "";
            _SPEC = "";
            _STATUS = "";
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
        /// Gets the select statement for V_PLANFOOD_DIVISION_MATERIAL table.
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
        /// Returns an indication whether the record of V_PLANFOOD_DIVISION_MATERIAL by specified condition is retrieved successfully.
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
                            if (!Convert.IsDBNull(zRdr["DIVISION"])) _DIVISION = Convert.ToDouble(zRdr["DIVISION"]);
                            if (!Convert.IsDBNull(zRdr["DIVISIONNAME"])) _DIVISIONNAME = zRdr["DIVISIONNAME"].ToString();
                            if (!Convert.IsDBNull(zRdr["LOID"])) _LOID = Convert.ToDouble(zRdr["LOID"]);
                            if (!Convert.IsDBNull(zRdr["MATERIALMASTER"])) _MATERIALMASTER = Convert.ToDouble(zRdr["MATERIALMASTER"]);
                            if (!Convert.IsDBNull(zRdr["MATERIALNAME"])) _MATERIALNAME = zRdr["MATERIALNAME"].ToString();
                            if (!Convert.IsDBNull(zRdr["MENUQTY"])) _MENUQTY = Convert.ToDouble(zRdr["MENUQTY"]);
                            if (!Convert.IsDBNull(zRdr["PLANMATERIALCLASS"])) _PLANMATERIALCLASS = Convert.ToDouble(zRdr["PLANMATERIALCLASS"]);
                            if (!Convert.IsDBNull(zRdr["PLANMATERIALITEM"])) _PLANMATERIALITEM = Convert.ToDouble(zRdr["PLANMATERIALITEM"]);
                            if (!Convert.IsDBNull(zRdr["PLANORDER"])) _PLANORDER = Convert.ToDouble(zRdr["PLANORDER"]);
                            if (!Convert.IsDBNull(zRdr["PLANQTY"])) _PLANQTY = Convert.ToDouble(zRdr["PLANQTY"]);
                            if (!Convert.IsDBNull(zRdr["REQQTY"])) _REQQTY = Convert.ToDouble(zRdr["REQQTY"]);
                            if (!Convert.IsDBNull(zRdr["SAPCODE"])) _SAPCODE = zRdr["SAPCODE"].ToString();
                            if (!Convert.IsDBNull(zRdr["SPEC"])) _SPEC = zRdr["SPEC"].ToString();
                            if (!Convert.IsDBNull(zRdr["STATUS"])) _STATUS = zRdr["STATUS"].ToString();
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

        public DataTable GetDataListByMaterialItem(double cPLANMATERIALITEM, string orderBy, OracleTransaction trans)
        {
            return GetDataList("PLANMATERIALITEM = " + DB.SetDouble(cPLANMATERIALITEM), orderBy, trans);
        }

        public DataTable GetDataListByPlanOrder(double cPLANORDER, string cSTATUS, string orderBy, OracleTransaction trans)
        {
            return GetDataList("PLANORDER = " + DB.SetDouble(cPLANORDER) + " AND STATUS = " + DB.SetString(cSTATUS), orderBy, trans);
        }

        public DataTable GetDataListByPlanOrderDivision(double cPLANORDERDIVISION, string orderBy, OracleTransaction trans)
        {
            return GetDataList("PLANORDERDIVISION = " + DB.SetDouble(cPLANORDERDIVISION), orderBy, trans);
        }

        public DataTable GetDataListByPlanOrderActive(double cPLANORDER, string orderBy, OracleTransaction trans)
        {
            return GetDataList("PLANORDER = " + DB.SetDouble(cPLANORDER) + " AND STATUS NOT IN ('WA', 'CO') ", orderBy, trans);
        }
        public DataTable GetDataListByMaterial(double cPLANORDER, double cMATERIALMASTER, string orderBy, OracleTransaction trans)
        {
            return GetDataList("PLANORDER = " + DB.SetDouble(cPLANORDER) + " AND MATERIALMASTER = " + DB.SetDouble(cMATERIALMASTER) + " AND STATUS NOT IN ('WA', 'CO') ", orderBy, trans);
        }

        public DataTable GetDataListByConditions(double cPLANORDER, double cDIVISION, string orderBy, OracleTransaction trans)
        {
            return GetDataList("PLANORDER = " + DB.SetDouble(cPLANORDER) + " AND DIVISION = " + DB.SetDouble(cDIVISION), orderBy, trans);
        }
    }
}