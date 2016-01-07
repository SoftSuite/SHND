using System;
using System.Data;
using System.Data.OracleClient;
using DB = SHND.DAL.Utilities.OracleDB;
using SHND.Data.Common.Utilities;

namespace SHND.DAL.Views
{
    /// <summary>
    /// Represents a transaction for V_MILKCODE view.
    /// [Created by 127.0.0.1 on January,28 2009]
    /// </summary>
    public class VMilkCodeDAL
    {

        public VMilkCodeDAL()
        {
        }

        #region Constant

        /// <summary>V_MILKCODE</summary>
        private const string viewName = "V_MILKCODE";

        #endregion

        #region Private Variables

        string _error = "";
        string _information = "";
        bool _OnDB = false;
       // string _ACTIVE = "";
      //  double _BEDQTY = 0;
      //  string _CREATEBY = "";
       // double _DEFAULTFOODTYPE = 0;
        double _LOID = 0;
        string _MILKCODE = "";
        string _NAME = "";
        double _WARD = 0;

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
      /*  public string ACTIVE
        {
            get { return _ACTIVE; }
            set { _ACTIVE = value; }
        }
        public double BEDQTY
        {
            get { return _BEDQTY; }
            set { _BEDQTY = value; }
        }
        public string CREATEBY
        {
            get { return _CREATEBY; }
            set { _CREATEBY = value; }
        }
        public double DEFAULTFOODTYPE
        {
            get { return _DEFAULTFOODTYPE; }
            set { _DEFAULTFOODTYPE = value; }
        }*/
        public double LOID
        {
            get { return _LOID; }
            set { _LOID = value; }
        }
        public string MILKCODE
        {
            get { return _MILKCODE; }
            set { _MILKCODE = value; }
        }
        public string NAME
        {
            get { return _NAME; }
            set { _NAME = value; }
        }
        public double WARD
        {
            get { return _WARD; }
            set { _WARD = value; }
        }

        #endregion

        #region Clear Data

        /// <summary>
        /// Initialize data.
        /// </summary>
        private void ClearData()
        {
          //  _ACTIVE = "";
          //  _BEDQTY = 0;
          //  _CREATEBY = "";
           // _DEFAULTFOODTYPE = 0;
            _LOID = 0;
            _MILKCODE = "";
            _NAME = "";
            _WARD = 0;
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
        /// Gets the select statement for V_MILKCODE table.
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
        /// Returns an indication whether the record of V_MILKCODE by specified condition is retrieved successfully.
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
                       // if (!Convert.IsDBNull(zRdr["ACTIVE"])) _ACTIVE = zRdr["ACTIVE"].ToString();
                       // if (!Convert.IsDBNull(zRdr["BEDQTY"])) _BEDQTY = Convert.ToDouble(zRdr["BEDQTY"]);
                      //  if (!Convert.IsDBNull(zRdr["CREATEBY"])) _CREATEBY = zRdr["CREATEBY"].ToString();
                      //  if (!Convert.IsDBNull(zRdr["DEFAULTFOODTYPE"])) _DEFAULTFOODTYPE = Convert.ToDouble(zRdr["DEFAULTFOODTYPE"]);
                        if (!Convert.IsDBNull(zRdr["LOID"])) _LOID = Convert.ToDouble(zRdr["LOID"]);
                        if (!Convert.IsDBNull(zRdr["MILKCODE"])) _MILKCODE = zRdr["MILKCODE"].ToString();
                        if (!Convert.IsDBNull(zRdr["NAME"])) _NAME = zRdr["NAME"].ToString();
                        if (!Convert.IsDBNull(zRdr["WARD"])) _WARD = Convert.ToDouble(zRdr["WARD"]);
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


       

        public DataTable GetDataListByCondition(string cNAME, string orderBy, OracleTransaction trans)
        {
            //build where clause
            string whStr = "";

            if (cNAME.Trim() != "0") whStr += (whStr.Trim() == "" ? "" : " AND ") + "  WARD  = " + DB.SetString(cNAME.ToUpper()) + " ";



            return GetDataList(whStr, orderBy, trans);
        }
        public DataTable GetDataListByWard(double WARD, string orderBy, OracleTransaction trans)
        {
            string whStr = "";

            if (WARD != 0) whStr += (whStr.Trim() == "" ? "" : " AND ") + "  WARD  = " + DB.SetDouble(WARD) + " ";

            return GetDataList(whStr, orderBy, trans);
        }


        public DataTable GetDataListByStdMenu(double  cWARD, string orderBy, OracleTransaction trans)
        {
            return GetDataList("WARD = " + DB.SetDouble(cWARD) + " ", orderBy, trans);
        }

        /// <summary>
        /// Returns an indication whether the record of MILKCODE by specified LOID key is retrieved successfully.
        /// </summary>
        /// <param name="cLOID">The LOID key.</param>
        /// <param name="trans">The System.Data.OracleClient.OracleTransaction used by this System.Data.OracleClient.OracleCommand.</param>
        /// <returns>true if data is retrieved successfully; otherwise, false.</returns>
        public bool GetDataByLOID(double cLOID, OracleTransaction trans)
        {
            return doGetdata("LOID = " + DB.SetDouble(cLOID) + " ", trans);
        }

        public DataTable GetDataByWard(double cLOID,double cWARD, string orderBy, OracleTransaction trans)
        {
            return GetDataList("WARD = " + DB.SetDouble(cWARD) + " ", orderBy, trans);
        }


    }
}