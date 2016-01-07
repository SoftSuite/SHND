using System;
using System.Data;
using System.Data.OracleClient;
using DB = SHND.DAL.Utilities.OracleDB;
using SHND.Data.Common.Utilities;

namespace SHND.DAL.Views
{
    /// <summary>
    /// Represents a transaction for V_SUPPLIER view.
    /// [Created by 127.0.0.1 on January,7 2009]
    /// </summary>
    public class VSupplierDAL
    {

        public VSupplierDAL()
        {
        }

        #region Constant

        /// <summary>V_SUPPLIER</summary>
        private const string viewName = "V_SUPPLIER";

        #endregion

        #region Private Variables

        string _error = "";
        string _information = "";
        bool _OnDB = false;
        string _ACTIVE = "";
        string _ADDRESS = "";
        double _AMPHUR = 0;
        string _CODE = "";
        string _CONTACTNAME = "";
        string _EMAIL = "";
        string _FAX = "";
        double _LOID = 0;
        string _MOBILE = "";
        string _NAME = "";
        double _PROVINCE = 0;
        string _REMARKS = "";
        double _TAMBOL = 0;
        string _TEL = "";
        string _ZIPCODE = "";

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
        public string ADDRESS
        {
            get { return _ADDRESS; }
            set { _ADDRESS = value; }
        }
        public double AMPHUR
        {
            get { return _AMPHUR; }
            set { _AMPHUR = value; }
        }
        public string CODE
        {
            get { return _CODE; }
            set { _CODE = value; }
        }
        public string CONTACTNAME
        {
            get { return _CONTACTNAME; }
            set { _CONTACTNAME = value; }
        }
        public string EMAIL
        {
            get { return _EMAIL; }
            set { _EMAIL = value; }
        }
        public string FAX
        {
            get { return _FAX; }
            set { _FAX = value; }
        }
        public double LOID
        {
            get { return _LOID; }
            set { _LOID = value; }
        }
        public string MOBILE
        {
            get { return _MOBILE; }
            set { _MOBILE = value; }
        }
        public string NAME
        {
            get { return _NAME; }
            set { _NAME = value; }
        }
        public double PROVINCE
        {
            get { return _PROVINCE; }
            set { _PROVINCE = value; }
        }
        public string REMARKS
        {
            get { return _REMARKS; }
            set { _REMARKS = value; }
        }
        public double TAMBOL
        {
            get { return _TAMBOL; }
            set { _TAMBOL = value; }
        }
        public string TEL
        {
            get { return _TEL; }
            set { _TEL = value; }
        }
        public string ZIPCODE
        {
            get { return _ZIPCODE; }
            set { _ZIPCODE = value; }
        }

        #endregion

        #region Clear Data

        /// <summary>
        /// Initialize data.
        /// </summary>
        private void ClearData()
        {
            _ACTIVE = "";
            _ADDRESS = "";
            _AMPHUR = 0;
            _CODE = "";
            _CONTACTNAME = "";
            _EMAIL = "";
            _FAX = "";
            _LOID = 0;
            _MOBILE = "";
            _NAME = "";
            _PROVINCE = 0;
            _REMARKS = "";
            _TAMBOL = 0;
            _TEL = "";
            _ZIPCODE = "";
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

        public DataTable GetDataListByCondition(string cCODE, string cNAME, string cDIVISION, string orderBy, OracleTransaction trans)
        {
            //build where clause
            string whStr = "";
            if (cCODE.ToString() != "") whStr += (whStr.Trim() == "" ? "" : " AND ") + " UPPER(CODE) LIKE " + DB.SetString("%" + cCODE.ToUpper() + "%") + " ";
            if (cNAME.ToString() != "") whStr += (whStr.Trim() == "" ? "" : " AND ") + " UPPER(NAME) LIKE " + DB.SetString("%" + cNAME.ToUpper() + "%") + " ";
            if (cDIVISION.ToString() != "") whStr += (whStr.Trim() == "" ? "" : " AND ") + " DIVISION = " + DB.SetDouble(Convert.ToDouble(cDIVISION)) + " ";

            return GetDataList(whStr, orderBy, trans);
        }

        #endregion

        #region SQL Statements

        /// <summary>
        /// Gets the select statement for V_SUPPLIER table.
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
        /// Returns an indication whether the record of V_SUPPLIER by specified condition is retrieved successfully.
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
                        if (!Convert.IsDBNull(zRdr["ADDRESS"])) _ADDRESS = zRdr["ADDRESS"].ToString();
                        if (!Convert.IsDBNull(zRdr["AMPHUR"])) _AMPHUR = Convert.ToDouble(zRdr["AMPHUR"]);
                        if (!Convert.IsDBNull(zRdr["CODE"])) _CODE = zRdr["CODE"].ToString();
                        if (!Convert.IsDBNull(zRdr["CONTACTNAME"])) _CONTACTNAME = zRdr["CONTACTNAME"].ToString();
                        if (!Convert.IsDBNull(zRdr["EMAIL"])) _EMAIL = zRdr["EMAIL"].ToString();
                        if (!Convert.IsDBNull(zRdr["FAX"])) _FAX = zRdr["FAX"].ToString();
                        if (!Convert.IsDBNull(zRdr["LOID"])) _LOID = Convert.ToDouble(zRdr["LOID"]);
                        if (!Convert.IsDBNull(zRdr["MOBILE"])) _MOBILE = zRdr["MOBILE"].ToString();
                        if (!Convert.IsDBNull(zRdr["NAME"])) _NAME = zRdr["NAME"].ToString();
                        if (!Convert.IsDBNull(zRdr["PROVINCE"])) _PROVINCE = Convert.ToDouble(zRdr["PROVINCE"]);
                        if (!Convert.IsDBNull(zRdr["REMARKS"])) _REMARKS = zRdr["REMARKS"].ToString();
                        if (!Convert.IsDBNull(zRdr["TAMBOL"])) _TAMBOL = Convert.ToDouble(zRdr["TAMBOL"]);
                        if (!Convert.IsDBNull(zRdr["TEL"])) _TEL = zRdr["TEL"].ToString();
                        if (!Convert.IsDBNull(zRdr["ZIPCODE"])) _ZIPCODE = zRdr["ZIPCODE"].ToString();
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