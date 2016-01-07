using System;
using System.Data;
using System.Data.OracleClient;
using DB = SHND.DAL.Utilities.OracleDB;
using SHND.Data.Common.Utilities;
using SHND.DAL.Functions;

namespace SHND.DAL.Views
{
    /// <summary>
    /// Represents a transaction for V_DISEASECATEGORY view.
    /// [Created by 127.0.0.1 on January,13 2009]
    /// </summary>
    public class VDiseaseCategoryDAL
    {

        public VDiseaseCategoryDAL()
        {
        }

        #region Constant

        /// <summary>V_DISEASECATEGORY</summary>
        private const string viewName = "V_DISEASECATEGORY";

        #endregion

        #region Private Variables

        string _error = "";
        string _information = "";
        bool _OnDB = false;
        string _ABBNAME = "";
        string _ACTIVE = "";
        string _CREATEBY = "";
        DateTime _CREATEON = new DateTime(1, 1, 1);
        string _DESCRIPTION = "";
        string _IMGSYMBOL = "";
        string _ISABSTAIN = "";
        string _ISCALCULATE = "";
        string _ISHIGH = "";
        string _ISINCREASE = "";
        string _ISLIGHT = "";
        string _ISLIMIT = "";
        string _ISLIQUID = "";
        string _ISLOW = "";
        string _ISNEED = "";
        string _ISNON = "";
        string _ISREGULAR = "";
        string _ISREQUEST = "";
        string _ISSOFT = "";
        string _ISSPECIAL = "";
        double _LOID = 0;
        string _UPDATEBY = "";
        DateTime _UPDATEON = new DateTime(1, 1, 1);

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
        public string ABBNAME
        {
            get { return _ABBNAME; }
            set { _ABBNAME = value; }
        }
        public string ACTIVE
        {
            get { return _ACTIVE; }
            set { _ACTIVE = value; }
        }
        public string CREATEBY
        {
            get { return _CREATEBY; }
            set { _CREATEBY = value; }
        }
        public DateTime CREATEON
        {
            get { return _CREATEON; }
            set { _CREATEON = value; }
        }
        public string DESCRIPTION
        {
            get { return _DESCRIPTION; }
            set { _DESCRIPTION = value; }
        }
        public string IMGSYMBOL
        {
            get { return _IMGSYMBOL; }
            set { _IMGSYMBOL = value; }
        }
        public string ISABSTAIN
        {
            get { return _ISABSTAIN; }
            set { _ISABSTAIN = value; }
        }
        public string ISCALCULATE
        {
            get { return _ISCALCULATE; }
            set { _ISCALCULATE = value; }
        }
        public string ISHIGH
        {
            get { return _ISHIGH; }
            set { _ISHIGH = value; }
        }
        public string ISINCREASE
        {
            get { return _ISINCREASE; }
            set { _ISINCREASE = value; }
        }
        public string ISLIGHT
        {
            get { return _ISLIGHT; }
            set { _ISLIGHT = value; }
        }
        public string ISLIMIT
        {
            get { return _ISLIMIT; }
            set { _ISLIMIT = value; }
        }
        public string ISLIQUID
        {
            get { return _ISLIQUID; }
            set { _ISLIQUID = value; }
        }
        public string ISLOW
        {
            get { return _ISLOW; }
            set { _ISLOW = value; }
        }
        public string ISNEED
        {
            get { return _ISNEED; }
            set { _ISNEED = value; }
        }
        public string ISNON
        {
            get { return _ISNON; }
            set { _ISNON = value; }
        }
        public string ISREGULAR
        {
            get { return _ISREGULAR; }
            set { _ISREGULAR = value; }
        }
        public string ISREQUEST
        {
            get { return _ISREQUEST; }
            set { _ISREQUEST = value; }
        }
        public string ISSOFT
        {
            get { return _ISSOFT; }
            set { _ISSOFT = value; }
        }
        public string ISSPECIAL
        {
            get { return _ISSPECIAL; }
            set { _ISSPECIAL = value; }
        }
        public double LOID
        {
            get { return _LOID; }
            set { _LOID = value; }
        }
        public string UPDATEBY
        {
            get { return _UPDATEBY; }
            set { _UPDATEBY = value; }
        }
        public DateTime UPDATEON
        {
            get { return _UPDATEON; }
            set { _UPDATEON = value; }
        }

        #endregion

        #region Clear Data

        /// <summary>
        /// Initialize data.
        /// </summary>
        private void ClearData()
        {
            _ABBNAME = "";
            _ACTIVE = "";
            _CREATEBY = "";
            _CREATEON = new DateTime(1, 1, 1);
            _DESCRIPTION = "";
            _IMGSYMBOL = "";
            _ISABSTAIN = "";
            _ISCALCULATE = "";
            _ISHIGH = "";
            _ISINCREASE = "";
            _ISLIGHT = "";
            _ISLIMIT = "";
            _ISLIQUID = "";
            _ISLOW = "";
            _ISNEED = "";
            _ISNON = "";
            _ISREGULAR = "";
            _ISREQUEST = "";
            _ISSOFT = "";
            _ISSPECIAL = "";
            _LOID = 0;
            _UPDATEBY = "";
            _UPDATEON = new DateTime(1, 1, 1);
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
        /// Gets the select statement for V_DISEASECATEGORY table.
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
        /// Returns an indication whether the record of V_DISEASECATEGORY by specified condition is retrieved successfully.
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
                            if (!Convert.IsDBNull(zRdr["ABBNAME"])) _ABBNAME = zRdr["ABBNAME"].ToString();
                            if (!Convert.IsDBNull(zRdr["ACTIVE"])) _ACTIVE = zRdr["ACTIVE"].ToString();
                            if (!Convert.IsDBNull(zRdr["CREATEBY"])) _CREATEBY = zRdr["CREATEBY"].ToString();
                            if (!Convert.IsDBNull(zRdr["CREATEON"])) _CREATEON = Convert.ToDateTime(zRdr["CREATEON"]);
                            if (!Convert.IsDBNull(zRdr["DESCRIPTION"])) _DESCRIPTION = zRdr["DESCRIPTION"].ToString();
                            if (!Convert.IsDBNull(zRdr["IMGSYMBOL"])) _IMGSYMBOL = zRdr["IMGSYMBOL"].ToString();
                            if (!Convert.IsDBNull(zRdr["ISABSTAIN"])) _ISABSTAIN = zRdr["ISABSTAIN"].ToString();
                            if (!Convert.IsDBNull(zRdr["ISCALCULATE"])) _ISCALCULATE = zRdr["ISCALCULATE"].ToString();
                            if (!Convert.IsDBNull(zRdr["ISHIGH"])) _ISHIGH = zRdr["ISHIGH"].ToString();
                            if (!Convert.IsDBNull(zRdr["ISINCREASE"])) _ISINCREASE = zRdr["ISINCREASE"].ToString();
                            if (!Convert.IsDBNull(zRdr["ISLIGHT"])) _ISLIGHT = zRdr["ISLIGHT"].ToString();
                            if (!Convert.IsDBNull(zRdr["ISLIMIT"])) _ISLIMIT = zRdr["ISLIMIT"].ToString();
                            if (!Convert.IsDBNull(zRdr["ISLIQUID"])) _ISLIQUID = zRdr["ISLIQUID"].ToString();
                            if (!Convert.IsDBNull(zRdr["ISLOW"])) _ISLOW = zRdr["ISLOW"].ToString();
                            if (!Convert.IsDBNull(zRdr["ISNEED"])) _ISNEED = zRdr["ISNEED"].ToString();
                            if (!Convert.IsDBNull(zRdr["ISNON"])) _ISNON = zRdr["ISNON"].ToString();
                            if (!Convert.IsDBNull(zRdr["ISREGULAR"])) _ISREGULAR = zRdr["ISREGULAR"].ToString();
                            if (!Convert.IsDBNull(zRdr["ISREQUEST"])) _ISREQUEST = zRdr["ISREQUEST"].ToString();
                            if (!Convert.IsDBNull(zRdr["ISSOFT"])) _ISSOFT = zRdr["ISSOFT"].ToString();
                            if (!Convert.IsDBNull(zRdr["ISSPECIAL"])) _ISSPECIAL = zRdr["ISSPECIAL"].ToString();
                            if (!Convert.IsDBNull(zRdr["LOID"])) _LOID = Convert.ToDouble(zRdr["LOID"]);
                            if (!Convert.IsDBNull(zRdr["UPDATEBY"])) _UPDATEBY = zRdr["UPDATEBY"].ToString();
                            if (!Convert.IsDBNull(zRdr["UPDATEON"])) _UPDATEON = Convert.ToDateTime(zRdr["UPDATEON"]);
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

        public DataTable GetDataListByCondition(string cAbbName, string cDescription, string cActive, string cIsSpecial, string cIsLimit, string cIsCalculate, string cIsIncrease, string isAbstain,
            string isNeed, string isRequest, string cDiseaseCategory, string exceptKeyList, string otherCondition, string orderBy, OracleTransaction trans)
        {
            FunctionDAL getDisease = new FunctionDAL();
            //build where clause
            string whStr = "";
            if (cAbbName.Trim() != "") whStr += (whStr.Trim() == "" ? "" : " AND ") + " UPPER(ABBNAME) LIKE " + DB.SetString("%" + cAbbName.ToUpper() + "%") + " ";
            if (cDescription.Trim() != "") whStr += (whStr.Trim() == "" ? "" : " AND ") + " UPPER(DESCRIPTION) LIKE " + DB.SetString("%" + cDescription.ToUpper() + "%") + " ";
            if (cActive.Trim() != "T" && cActive.Trim() != "") whStr += (whStr.Trim() == "" ? "" : " AND ") + " ACTIVESTATUS = " + DB.SetString(cActive) + " ";
            if (cIsSpecial.Trim() != "") whStr += (whStr.Trim() == "" ? "" : " AND ") + "ISSPECIAL = " + DB.SetString(cIsSpecial) + " ";
            if (cIsLimit.Trim() != "") whStr += (whStr.Trim() == "" ? "" : " AND ") + "ISLIMIT = " + DB.SetString(cIsLimit) + " ";
            if (cIsCalculate.Trim() != "") whStr += (whStr.Trim() == "" ? "" : " AND ") + "ISCALCULATE = " + DB.SetString(cIsCalculate) + " ";
            if (cIsIncrease.Trim() != "") whStr += (whStr.Trim() == "" ? "" : " AND ") + "ISINCREASE = " + DB.SetString(cIsIncrease) + " ";
            if (isAbstain.Trim() != "") whStr += (whStr.Trim() == "" ? "" : " AND ") + "ISABSTAIN = " + DB.SetString(isAbstain) + " ";
            if (isNeed.Trim() != "") whStr += (whStr.Trim() == "" ? "" : " AND ") + "ISNEED = " + DB.SetString(isNeed) + " ";
            if (isRequest.Trim() != "") whStr += (whStr.Trim() == "" ? "" : " AND ") + "ISREQUEST = " + DB.SetString(isRequest) + " ";
            if (otherCondition.Trim() != "") whStr += (whStr.Trim() == "" ? "" : " AND ") + otherCondition + " ";
            if (exceptKeyList.Trim() != "") whStr += (whStr.Trim() == "" ? "" : " AND ") + "LOID NOT IN (" + exceptKeyList + ") ";
            
            if (cDiseaseCategory.Trim() == getDisease.GetConfigValue("REGULARLOID"))
                whStr += (whStr.Trim() == "" ? "" : " AND ") + "ISREGULAR = 'Y'";
            else if (cDiseaseCategory.Trim() == getDisease.GetConfigValue("SOFTLOID"))
                whStr += (whStr.Trim() == "" ? "" : " AND ") + "ISSOFT = 'Y'";
            else if (cDiseaseCategory.Trim() == getDisease.GetConfigValue("LIQUIDLOID"))
                whStr += (whStr.Trim() == "" ? "" : " AND ") + "ISLIQUID = 'Y'";
            else if (cDiseaseCategory.Trim() == getDisease.GetConfigValue("LIGHTLOID"))
                whStr += (whStr.Trim() == "" ? "" : " AND ") + "ISLIGHT = 'Y'";
            else if (cDiseaseCategory.Trim() == getDisease.GetConfigValue("MILKLOID"))
                whStr += (whStr.Trim() == "" ? "" : " AND ") + "ISMILK = 'Y'";

            return GetDataList(whStr, orderBy, trans);
        }

    }
}