using System;
using System.Data;
using System.Data.OracleClient;
using DB = SHND.DAL.Utilities.OracleDB;
using SHND.Data.Common.Utilities;
using SHND.Data.Search;

namespace SHND.DAL.Views
{
    /// <summary>
    /// Represents a transaction for V_MATERIALMASTER view.
    /// [Created by 127.0.0.1 on January,16 2009]
    /// </summary>
    public class V_MaterialMasterDAL
    {

        public V_MaterialMasterDAL()
        {
        }

        #region Constant

        /// <summary>V_MATERIALMASTER</summary>
        private const string viewName = "V_MATERIALMASTER";

        #endregion

        #region Private Variables

        string _error = "";
        string _information = "";
        bool _OnDB = false;
        string _ACTIVE = "";
        string _ACTIVENAME = "";
        string _ARTICLECODE = "";
        double _CARBOHYDRATE = 0;
        double _CLASSLOID = 0;
        string _CLASSNAME = "";
        double _COST = 0;
        string _DIVISIONNAME = "";
        double _DIVLOID = 0;
        double _ENERGY100G = 0;
        double _ENERGYBYUNIT = 0;
        double _FAT = 0;
        double _GROUPLOID = 0;
        string _GROUPNAME = "";
        string _ISCOUNT = "";
        double _LOID = 0;
        string _MASTERTYPE = "";
        string _MASTERTYPENAME = "";
        string _MATERIALCODE = "";
        string _MATERIALNAME = "";
        double _MAXSTOCK = 0;
        double _MINSTOCK = 0;
        string _ORDERTYPE = "";
        string _ORDERTYPENAME = "";
        double _PRICE = 0;
        double _PROTEIN = 0;
        string _REMARKS = "";
        string _SAPCODE = "";
        double _SAPWAREHOUSELOID = 0;
        string _SAPWAREHOUSENAME = "";
        double _SODIUM = 0;
        string _SPEC = "";
        string _STOCKINTYPE = "";
        string _STOCKINTYPENAME = "";
        string _STOCKOUTBREAKFAST = "";
        string _STOCKOUTDINNER = "";
        string _STOCKOUTLUNCH = "";
        string _THNAME = "";
        double _ULOID = 0;
        string _UNITNAME = "";
        double _WEIGHT = 0;
        double _WEIGHTCOOK = 0;

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
        public string ARTICLECODE
        {
            get { return _ARTICLECODE; }
            set { _ARTICLECODE = value; }
        }
        public double CARBOHYDRATE
        {
            get { return _CARBOHYDRATE; }
            set { _CARBOHYDRATE = value; }
        }
        public double CLASSLOID
        {
            get { return _CLASSLOID; }
            set { _CLASSLOID = value; }
        }
        public string CLASSNAME
        {
            get { return _CLASSNAME; }
            set { _CLASSNAME = value; }
        }
        public double COST
        {
            get { return _COST; }
            set { _COST = value; }
        }
        public string DIVISIONNAME
        {
            get { return _DIVISIONNAME; }
            set { _DIVISIONNAME = value; }
        }
        public double DIVLOID
        {
            get { return _DIVLOID; }
            set { _DIVLOID = value; }
        }
        public double ENERGY100G
        {
            get { return _ENERGY100G; }
            set { _ENERGY100G = value; }
        }
        public double ENERGYBYUNIT
        {
            get { return _ENERGYBYUNIT; }
            set { _ENERGYBYUNIT = value; }
        }
        public double FAT
        {
            get { return _FAT; }
            set { _FAT = value; }
        }
        public double GROUPLOID
        {
            get { return _GROUPLOID; }
            set { _GROUPLOID = value; }
        }
        public string GROUPNAME
        {
            get { return _GROUPNAME; }
            set { _GROUPNAME = value; }
        }
        public string ISCOUNT
        {
            get { return _ISCOUNT; }
            set { _ISCOUNT = value; }
        }
        public double LOID
        {
            get { return _LOID; }
            set { _LOID = value; }
        }
        public string MASTERTYPE
        {
            get { return _MASTERTYPE; }
            set { _MASTERTYPE = value; }
        }
        public string MASTERTYPENAME
        {
            get { return _MASTERTYPENAME; }
            set { _MASTERTYPENAME = value; }
        }
        public string MATERIALCODE
        {
            get { return _MATERIALCODE; }
            set { _MATERIALCODE = value; }
        }
        public string MATERIALNAME
        {
            get { return _MATERIALNAME; }
            set { _MATERIALNAME = value; }
        }
        public double MAXSTOCK
        {
            get { return _MAXSTOCK; }
            set { _MAXSTOCK = value; }
        }
        public double MINSTOCK
        {
            get { return _MINSTOCK; }
            set { _MINSTOCK = value; }
        }
        public string ORDERTYPE
        {
            get { return _ORDERTYPE; }
            set { _ORDERTYPE = value; }
        }
        public string ORDERTYPENAME
        {
            get { return _ORDERTYPENAME; }
            set { _ORDERTYPENAME = value; }
        }
        public double PRICE
        {
            get { return _PRICE; }
            set { _PRICE = value; }
        }
        public double PROTEIN
        {
            get { return _PROTEIN; }
            set { _PROTEIN = value; }
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
        public double SAPWAREHOUSELOID
        {
            get { return _SAPWAREHOUSELOID; }
            set { _SAPWAREHOUSELOID = value; }
        }
        public string SAPWAREHOUSENAME
        {
            get { return _SAPWAREHOUSENAME; }
            set { _SAPWAREHOUSENAME = value; }
        }
        public double SODIUM
        {
            get { return _SODIUM; }
            set { _SODIUM = value; }
        }
        public string SPEC
        {
            get { return _SPEC; }
            set { _SPEC = value; }
        }
        public string STOCKINTYPE
        {
            get { return _STOCKINTYPE; }
            set { _STOCKINTYPE = value; }
        }
        public string STOCKINTYPENAME
        {
            get { return _STOCKINTYPENAME; }
            set { _STOCKINTYPENAME = value; }
        }
        public string STOCKOUTBREAKFAST
        {
            get { return _STOCKOUTBREAKFAST; }
            set { _STOCKOUTBREAKFAST = value; }
        }
        public string STOCKOUTDINNER
        {
            get { return _STOCKOUTDINNER; }
            set { _STOCKOUTDINNER = value; }
        }
        public string STOCKOUTLUNCH
        {
            get { return _STOCKOUTLUNCH; }
            set { _STOCKOUTLUNCH = value; }
        }
        public string THNAME
        {
            get { return _THNAME; }
            set { _THNAME = value; }
        }
        public double ULOID
        {
            get { return _ULOID; }
            set { _ULOID = value; }
        }
        public string UNITNAME
        {
            get { return _UNITNAME; }
            set { _UNITNAME = value; }
        }
        public double WEIGHT
        {
            get { return _WEIGHT; }
            set { _WEIGHT = value; }
        }
        public double WEIGHTCOOK
        {
            get { return _WEIGHTCOOK; }
            set { _WEIGHTCOOK = value; }
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
            _ARTICLECODE = "";
            _CARBOHYDRATE = 0;
            _CLASSLOID = 0;
            _CLASSNAME = "";
            _COST = 0;
            _DIVISIONNAME = "";
            _DIVLOID = 0;
            _ENERGY100G = 0;
            _ENERGYBYUNIT = 0;
            _FAT = 0;
            _GROUPLOID = 0;
            _GROUPNAME = "";
            _ISCOUNT = "";
            _LOID = 0;
            _MASTERTYPE = "";
            _MASTERTYPENAME = "";
            _MATERIALCODE = "";
            _MATERIALNAME = "";
            _MAXSTOCK = 0;
            _MINSTOCK = 0;
            _ORDERTYPE = "";
            _ORDERTYPENAME = "";
            _PRICE = 0;
            _PROTEIN = 0;
            _REMARKS = "";
            _SAPCODE = "";
            _SAPWAREHOUSELOID = 0;
            _SAPWAREHOUSENAME = "";
            _SODIUM = 0;
            _SPEC = "";
            _STOCKINTYPE = "";
            _STOCKINTYPENAME = "";
            _STOCKOUTBREAKFAST = "";
            _STOCKOUTDINNER = "";
            _STOCKOUTLUNCH = "";
            _THNAME = "";
            _ULOID = 0;
            _UNITNAME = "";
            _WEIGHT = 0;
            _WEIGHTCOOK = 0;
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
        /// Gets the select statement for V_MATERIALMASTER table.
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
        /// Returns an indication whether the record of V_MATERIALMASTER by specified condition is retrieved successfully.
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
                            if (!Convert.IsDBNull(zRdr["ARTICLECODE"])) _ARTICLECODE = zRdr["ARTICLECODE"].ToString();
                            if (!Convert.IsDBNull(zRdr["CARBOHYDRATE"])) _CARBOHYDRATE = Convert.ToDouble(zRdr["CARBOHYDRATE"]);
                            if (!Convert.IsDBNull(zRdr["CLASSLOID"])) _CLASSLOID = Convert.ToDouble(zRdr["CLASSLOID"]);
                            if (!Convert.IsDBNull(zRdr["CLASSNAME"])) _CLASSNAME = zRdr["CLASSNAME"].ToString();
                            if (!Convert.IsDBNull(zRdr["COST"])) _COST = Convert.ToDouble(zRdr["COST"]);
                            if (!Convert.IsDBNull(zRdr["DIVISIONNAME"])) _DIVISIONNAME = zRdr["DIVISIONNAME"].ToString();
                            if (!Convert.IsDBNull(zRdr["DIVLOID"])) _DIVLOID = Convert.ToDouble(zRdr["DIVLOID"]);
                            if (!Convert.IsDBNull(zRdr["ENERGY100G"])) _ENERGY100G = Convert.ToDouble(zRdr["ENERGY100G"]);
                            if (!Convert.IsDBNull(zRdr["ENERGYBYUNIT"])) _ENERGYBYUNIT = Convert.ToDouble(zRdr["ENERGYBYUNIT"]);
                            if (!Convert.IsDBNull(zRdr["FAT"])) _FAT = Convert.ToDouble(zRdr["FAT"]);
                            if (!Convert.IsDBNull(zRdr["GROUPLOID"])) _GROUPLOID = Convert.ToDouble(zRdr["GROUPLOID"]);
                            if (!Convert.IsDBNull(zRdr["GROUPNAME"])) _GROUPNAME = zRdr["GROUPNAME"].ToString();
                            if (!Convert.IsDBNull(zRdr["ISCOUNT"])) _ISCOUNT = zRdr["ISCOUNT"].ToString();
                            if (!Convert.IsDBNull(zRdr["LOID"])) _LOID = Convert.ToDouble(zRdr["LOID"]);
                            if (!Convert.IsDBNull(zRdr["MASTERTYPE"])) _MASTERTYPE = zRdr["MASTERTYPE"].ToString();
                            if (!Convert.IsDBNull(zRdr["MASTERTYPENAME"])) _MASTERTYPENAME = zRdr["MASTERTYPENAME"].ToString();
                            if (!Convert.IsDBNull(zRdr["MATERIALCODE"])) _MATERIALCODE = zRdr["MATERIALCODE"].ToString();
                            if (!Convert.IsDBNull(zRdr["MATERIALNAME"])) _MATERIALNAME = zRdr["MATERIALNAME"].ToString();
                            if (!Convert.IsDBNull(zRdr["MAXSTOCK"])) _MAXSTOCK = Convert.ToDouble(zRdr["MAXSTOCK"]);
                            if (!Convert.IsDBNull(zRdr["MINSTOCK"])) _MINSTOCK = Convert.ToDouble(zRdr["MINSTOCK"]);
                            if (!Convert.IsDBNull(zRdr["ORDERTYPE"])) _ORDERTYPE = zRdr["ORDERTYPE"].ToString();
                            if (!Convert.IsDBNull(zRdr["ORDERTYPENAME"])) _ORDERTYPENAME = zRdr["ORDERTYPENAME"].ToString();
                            if (!Convert.IsDBNull(zRdr["PRICE"])) _PRICE = Convert.ToDouble(zRdr["PRICE"]);
                            if (!Convert.IsDBNull(zRdr["PROTEIN"])) _PROTEIN = Convert.ToDouble(zRdr["PROTEIN"]);
                            if (!Convert.IsDBNull(zRdr["REMARKS"])) _REMARKS = zRdr["REMARKS"].ToString();
                            if (!Convert.IsDBNull(zRdr["SAPCODE"])) _SAPCODE = zRdr["SAPCODE"].ToString();
                            if (!Convert.IsDBNull(zRdr["SAPWAREHOUSELOID"])) _SAPWAREHOUSELOID = Convert.ToDouble(zRdr["SAPWAREHOUSELOID"]);
                            if (!Convert.IsDBNull(zRdr["SAPWAREHOUSENAME"])) _SAPWAREHOUSENAME = zRdr["SAPWAREHOUSENAME"].ToString();
                            if (!Convert.IsDBNull(zRdr["SODIUM"])) _SODIUM = Convert.ToDouble(zRdr["SODIUM"]);
                            if (!Convert.IsDBNull(zRdr["SPEC"])) _SPEC = zRdr["SPEC"].ToString();
                            if (!Convert.IsDBNull(zRdr["STOCKINTYPE"])) _STOCKINTYPE = zRdr["STOCKINTYPE"].ToString();
                            if (!Convert.IsDBNull(zRdr["STOCKINTYPENAME"])) _STOCKINTYPENAME = zRdr["STOCKINTYPENAME"].ToString();
                            if (!Convert.IsDBNull(zRdr["STOCKOUTBREAKFAST"])) _STOCKOUTBREAKFAST = zRdr["STOCKOUTBREAKFAST"].ToString();
                            if (!Convert.IsDBNull(zRdr["STOCKOUTDINNER"])) _STOCKOUTDINNER = zRdr["STOCKOUTDINNER"].ToString();
                            if (!Convert.IsDBNull(zRdr["STOCKOUTLUNCH"])) _STOCKOUTLUNCH = zRdr["STOCKOUTLUNCH"].ToString();
                            if (!Convert.IsDBNull(zRdr["THNAME"])) _THNAME = zRdr["THNAME"].ToString();
                            if (!Convert.IsDBNull(zRdr["ULOID"])) _ULOID = Convert.ToDouble(zRdr["ULOID"]);
                            if (!Convert.IsDBNull(zRdr["UNITNAME"])) _UNITNAME = zRdr["UNITNAME"].ToString();
                            if (!Convert.IsDBNull(zRdr["WEIGHT"])) _WEIGHT = Convert.ToDouble(zRdr["WEIGHT"]);
                            if (!Convert.IsDBNull(zRdr["WEIGHTCOOK"])) _WEIGHTCOOK = Convert.ToDouble(zRdr["WEIGHTCOOK"]);
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

        public DataTable GetDataListForExcel(double cCLASSLOID, double cGROUPLOID, string cMATERIALNAME, string cMASTERTYPE, string orderBy, OracleTransaction trans)
        {
            string query = "";
            query = "SELECT '''' || MATERIALCODE \"รหัสวัสดุ\", '''' || SAPCODE \"รหัส SAP\", MATERIALNAME \"ชื่อวัสดุ\", CLASSNAME \"หมวด\", GROUPNAME \"ประเภท\", UNITNAME \"หน่วยนับ\", COST \"ราคาทุน\", PRICE \"ราคาขาย\", SPEC \"Spec\", ACTIVENAME \"การใช้งาน\" " +
                "FROM V_MATERIALMASTER ";
            string whStr = "";
            if (cCLASSLOID != 0) whStr += (whStr.Trim() == "" ? "" : " AND ") + "CLASSLOID = " + DB.SetDouble(cCLASSLOID) + " ";
            if (cGROUPLOID != 0) whStr += (whStr.Trim() == "" ? "" : " AND ") + " GROUPLOID = " + DB.SetDouble(cGROUPLOID) + " ";
            if (cMATERIALNAME.Trim() != "") whStr += (whStr.Trim() == "" ? "" : " AND ") + "UPPER(MATERIALNAME) LIKE " + DB.SetString("%" + cMATERIALNAME.Trim() + "%") + " ";
            if (cMASTERTYPE.Trim() != "") whStr += (whStr == "" ? "" : "AND ") + "MASTERTYPE IN (" + cMASTERTYPE + ") ";
            return DB.ExecuteTable(query + " " + (whStr == "" ? "" : "WHERE " + whStr + " ") + (orderBy == "" ? "" : "ORDER BY " + DB.SetSortString(orderBy)), trans);
        }

        public DataTable GetDataListByCondition(string cNAME, string cGROUP, string orderBy, OracleTransaction trans)
        {
            //build where clause
            string whStr = " MASTERTYPE IN ('MD','MI','DO')";
            if (cNAME.ToString() != "") whStr += (whStr.Trim() == "" ? "" : " AND ") + " UPPER(MATERIALNAME) LIKE " + DB.SetString("%" + cNAME.ToUpper() + "%") + " ";
            if (cGROUP.ToString() != "") whStr += (whStr.Trim() == "" ? "" : " AND ") + " GROUPLOID = " + DB.SetDouble(Convert.ToDouble(cGROUP)) + " ";

            return GetDataList(whStr, orderBy, trans);
        }

        public DataTable GetDataListByCondition(MaterialMasterPopupData condition, string masterTypeList, string exceptKeyList, string orderBy, OracleTransaction trans)
        {
            string whStr = "";
            if (condition.Active.Trim() != "") whStr += (whStr == "" ? "" : "AND ") + "ACTIVE = " + DB.SetString(condition.Active) + " ";
            if (masterTypeList.Trim() != "") whStr += (whStr == "" ? "" : "AND ") + "MASTERTYPE IN (" + masterTypeList + ") ";
            if (condition.Code.Trim() != "") whStr += (whStr == "" ? "" : "AND ") + "UPPER(MATERIALCODE) LIKE " + DB.SetString("%" + condition.Code.ToUpper() + "%") + " ";
            if (condition.Division != 0) whStr += (whStr == "" ? "" : "AND ") + "DIVLOID = " + DB.SetDouble(condition.Division) + " ";
            if (condition.MasterType.Trim() != "") whStr += (whStr == "" ? "" : "AND ") + "MASTERTYPE = " + DB.SetString(condition.MasterType) + " ";
            if (condition.MaterialClass != 0) whStr += (whStr == "" ? "" : "AND ") + "CLASSLOID = " + DB.SetDouble(condition.MaterialClass) + " ";
            if (condition.MaterialGroup != 0) whStr += (whStr == "" ? "" : "AND ") + "GROUPLOID = " + DB.SetDouble(condition.MaterialGroup) + " ";
            if (condition.Name.Trim() != "") whStr += (whStr == "" ? "" : "AND ") + "UPPER(MATERIALNAME) LIKE " + DB.SetString("%" + condition.Name.ToUpper() + "%") + " ";
            if (exceptKeyList != "") whStr += (whStr.Trim() == "" ? "" : " AND ") + "LOID NOT IN (" + exceptKeyList + ") ";
            return GetDataList(whStr, orderBy, trans);
        }

        #region My Work Nang

        private string sql_formulaFeedMD
        {
            get
            {
                string sql = " SELECT MM.LOID ,0 FFLOID , UU.LOID UULOID, UU.THNAME ABBNAME  ,MATERIALNAME , ";
                sql += " FN_CALENERGYWEIGHT(MM.LOID,1) COST ,0 FILOID   ";
                sql += " FROM V_MATERIALMASTER MM INNER JOIN MATERIALUNIT MU ON ";
                sql += " MU.MATERIALMASTER = MM.LOID AND MU.UNIT = FN_GETCONFIGVALUE(16) ";
                sql += " INNER JOIN UNIT UU ON UU.LOID = MU.UNIT ";
                return sql;
            }
        }

        private string sql_loid
        {
            get
            {
                string sql = "SELECT LOID FROM " + viewName + " ";
                return sql;
            }
        }

        private string sql_FILoid
        {
            get
            {
                string sql = "SELECT NVL(FI.LOID,0) FILOID   ";
                sql += " FROM V_MATERIALMASTER MM INNER JOIN MATERIALUNIT MU ON ";
                sql += " MU.MATERIALMASTER = MM.LOID AND MU.UNIT = FN_GETCONFIGVALUE(16) ";
                sql += " LEFT JOIN FORMULAFEED FF ON FF.MATERIALMASTER = MM.LOID ";
                sql += " LEFT JOIN FORMULAFEEDITEM FI ON FI.FORMULAFEED = FF.LOID ";
                sql += " INNER JOIN UNIT UU ON UU.LOID = MU.UNIT ";
                return sql;
            }
        }


        public DataTable GetFormulaFeeMD(string whereClause, string orderBy, OracleTransaction trans)
        {
            return DB.ExecuteTable(sql_formulaFeedMD + (whereClause == "" ? "" : "WHERE " + whereClause + " ") + (orderBy == "" ? "" : "ORDER BY " + DB.SetSortString(orderBy)), trans);
        }

        public double GetFILoid(string whereClause, string orderBy, OracleTransaction trans)
        {
            return Convert.ToDouble(DB.ExecuteScalar(sql_FILoid + (whereClause == "" ? "" : "WHERE " + whereClause + " ") + (orderBy == "" ? "" : "ORDER BY " + DB.SetSortString(orderBy)), trans));
        }

        public DataTable GetLoidList(string whereClause, string orderBy, OracleTransaction trans)
        {
            return DB.ExecuteTable(sql_loid + (whereClause == "" ? "" : "WHERE " + whereClause + " ") + (orderBy == "" ? "" : "ORDER BY " + DB.SetSortString(orderBy)), trans);
        }


        #endregion
    }
}