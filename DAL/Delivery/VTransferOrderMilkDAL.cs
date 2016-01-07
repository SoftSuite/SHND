using System;
using System.Data;
using System.Data.OracleClient;
using DB = SHND.DAL.Utilities.OracleDB;
using SHND.Data.Common.Utilities;

namespace SHND.DAL.Delivery
{
    /// <summary>
    /// Represents a transaction for V_ORDERMILK_WAIT_TRANSFER view.
    /// [Created by 127.0.0.1 on April,21 2009]
    /// </summary>
    public class VTransferOrderMilkDAL
    {

        public VTransferOrderMilkDAL()
        {
        }

        #region Constant

        /// <summary>V_ORDERMILK_WAIT_TRANSFER</summary>
        private const string viewName = "V_ORDERMILK_WAIT_TRANSFER";

        #endregion

        #region Private Variables

        string _error = "";
        string _information = "";
        bool _OnDB = false;
        double _ADMITPATIENT = 0;
        string _AGE = "";
        string _AN = "";
        string _BEDNO = "";
        DateTime _BIRTHDATE = new DateTime(1, 1, 1);
        string _BMI = "";
        DateTime _ENDDATE = new DateTime(1, 1, 1);
        double _ENERGY = 0;
        DateTime _FIRSTDATE = new DateTime(1, 1, 1);
        double _HEIGHT = 0;
        string _HN = "";
        string _ISREGISTER = "";
        string _ISTRANSFER = "";
        double _LOID = 0;
        string _MEALNAME = "";
        string _MEALQTY = "";
        double _MILKCATEGORY = 0;
        string _MILKCODE = "";
        double _MILKCODEID = 0;
        string _MILKNAME = "";
        DateTime _ORDERDATE = new DateTime(1, 1, 1);
        double _ORDERMILK = 0;
        double _ORDERNO = 0;
        string _OWNER = "";
        string _OWNERNAME = "";
        string _OWNERTEXT = "";
        string _PATIENTNAME = "";
        string _PREPAREMEAL = "";
        double _PREPARETIME = 0;
        DateTime _PRINTTIME = new DateTime(1, 1, 1);
        DateTime _REGISTERDATE = new DateTime(1, 1, 1);
        string _ROOMNO = "";
        string _STATUS = "";
        string _STATUSNAME = "";
        string _VN = "";
        double _VOLUMN = 0;
        double _WARDID = 0;
        string _WARDNAME = "";
        double _WEIGHT = 0;
        DateTime _DELIVERYTIME = new DateTime(1, 1, 1);

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
        public double ADMITPATIENT
        {
            get { return _ADMITPATIENT; }
            set { _ADMITPATIENT = value; }
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
        public DateTime BIRTHDATE
        {
            get { return _BIRTHDATE; }
            set { _BIRTHDATE = value; }
        }
        public string BMI
        {
            get { return _BMI; }
            set { _BMI = value; }
        }
        public DateTime ENDDATE
        {
            get { return _ENDDATE; }
            set { _ENDDATE = value; }
        }
        public double ENERGY
        {
            get { return _ENERGY; }
            set { _ENERGY = value; }
        }
        public DateTime FIRSTDATE
        {
            get { return _FIRSTDATE; }
            set { _FIRSTDATE = value; }
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
        public string ISREGISTER
        {
            get { return _ISREGISTER; }
            set { _ISREGISTER = value; }
        }
        public string ISTRANSFER
        {
            get { return _ISTRANSFER; }
            set { _ISTRANSFER = value; }
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
        public string MEALQTY
        {
            get { return _MEALQTY; }
            set { _MEALQTY = value; }
        }
        public double MILKCATEGORY
        {
            get { return _MILKCATEGORY; }
            set { _MILKCATEGORY = value; }
        }
        public string MILKCODE
        {
            get { return _MILKCODE; }
            set { _MILKCODE = value; }
        }
        public double MILKCODEID
        {
            get { return _MILKCODEID; }
            set { _MILKCODEID = value; }
        }
        public string MILKNAME
        {
            get { return _MILKNAME; }
            set { _MILKNAME = value; }
        }
        public DateTime ORDERDATE
        {
            get { return _ORDERDATE; }
            set { _ORDERDATE = value; }
        }
        public double ORDERMILK
        {
            get { return _ORDERMILK; }
            set { _ORDERMILK = value; }
        }
        public double ORDERNO
        {
            get { return _ORDERNO; }
            set { _ORDERNO = value; }
        }
        public string OWNER
        {
            get { return _OWNER; }
            set { _OWNER = value; }
        }
        public string OWNERNAME
        {
            get { return _OWNERNAME; }
            set { _OWNERNAME = value; }
        }
        public string OWNERTEXT
        {
            get { return _OWNERTEXT; }
            set { _OWNERTEXT = value; }
        }
        public string PATIENTNAME
        {
            get { return _PATIENTNAME; }
            set { _PATIENTNAME = value; }
        }
        public string PREPAREMEAL
        {
            get { return _PREPAREMEAL; }
            set { _PREPAREMEAL = value; }
        }
        public double PREPARETIME
        {
            get { return _PREPARETIME; }
            set { _PREPARETIME = value; }
        }
        public DateTime PRINTTIME
        {
            get { return _PRINTTIME; }
            set { _PRINTTIME = value; }
        }
        public DateTime REGISTERDATE
        {
            get { return _REGISTERDATE; }
            set { _REGISTERDATE = value; }
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
        public string STATUSNAME
        {
            get { return _STATUSNAME; }
            set { _STATUSNAME = value; }
        }
        public string VN
        {
            get { return _VN; }
            set { _VN = value; }
        }
        public double VOLUMN
        {
            get { return _VOLUMN; }
            set { _VOLUMN = value; }
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
        public double WEIGHT
        {
            get { return _WEIGHT; }
            set { _WEIGHT = value; }
        }

        public DateTime DELIVERYTIME
        {
            get { return _DELIVERYTIME; }
            set { _DELIVERYTIME = value; }
        }

        #endregion

        #region Clear Data

        /// <summary>
        /// Initialize data.
        /// </summary>
        private void ClearData()
        {
            _ADMITPATIENT = 0;
            _AGE = "";
            _AN = "";
            _BEDNO = "";
            _BIRTHDATE = new DateTime(1, 1, 1);
            _BMI = "";
            _ENDDATE = new DateTime(1, 1, 1);
            _ENERGY = 0;
            _FIRSTDATE = new DateTime(1, 1, 1);
            _HEIGHT = 0;
            _HN = "";
            _ISREGISTER = "";
            _ISTRANSFER = "";
            _LOID = 0;
            _MEALNAME = "";
            _MEALQTY = "";
            _MILKCATEGORY = 0;
            _MILKCODE = "";
            _MILKCODEID = 0;
            _MILKNAME = "";
            _ORDERDATE = new DateTime(1, 1, 1);
            _ORDERMILK = 0;
            _ORDERNO = 0;
            _OWNER = "";
            _OWNERNAME = "";
            _OWNERTEXT = "";
            _PATIENTNAME = "";
            _PREPAREMEAL = "";
            _PREPARETIME = 0;
            _PRINTTIME = new DateTime(1, 1, 1);
            _REGISTERDATE = new DateTime(1, 1, 1);
            _ROOMNO = "";
            _STATUS = "";
            _STATUSNAME = "";
            _VN = "";
            _VOLUMN = 0;
            _WARDID = 0;
            _WARDNAME = "";
            _WEIGHT = 0;
            _DELIVERYTIME = new DateTime(1, 1, 1);
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
            DataTable dt = DB.ExecuteTable(sql_select + (whereClause == "" ? "" : "WHERE " + whereClause + " ") + (orderBy == "" ? "" : "ORDER BY " + DB.SetSortString(orderBy)), trans);
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

        #endregion

        #region SQL Statements

        /// <summary>
        /// Gets the select statement for V_ORDERMILK_WAIT_TRANSFER table.
        /// </summary>
        private string sql_select
        {
            get
            {
                string sql = "SELECT CASE WHEN RANK() OVER(PARTITION BY ADMITPATIENT ORDER BY PATIENTNAME, PREPARETIME) = 1 THEN 1 ELSE 0 END RANK, A.* FROM " + viewName + " A ";
                return sql;
            }
        }

        #endregion

        #region Private Methods

        /// <summary>
        /// Returns an indication whether the record of V_ORDERMILK_WAIT_TRANSFER by specified condition is retrieved successfully.
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
                        if (!Convert.IsDBNull(zRdr["ADMITPATIENT"])) _ADMITPATIENT = Convert.ToDouble(zRdr["ADMITPATIENT"]);
                        if (!Convert.IsDBNull(zRdr["AGE"])) _AGE = zRdr["AGE"].ToString();
                        if (!Convert.IsDBNull(zRdr["AN"])) _AN = zRdr["AN"].ToString();
                        if (!Convert.IsDBNull(zRdr["BEDNO"])) _BEDNO = zRdr["BEDNO"].ToString();
                        if (!Convert.IsDBNull(zRdr["BIRTHDATE"])) _BIRTHDATE = Convert.ToDateTime(zRdr["BIRTHDATE"]);
                        if (!Convert.IsDBNull(zRdr["BMI"])) _BMI = zRdr["BMI"].ToString();
                        if (!Convert.IsDBNull(zRdr["ENDDATE"])) _ENDDATE = Convert.ToDateTime(zRdr["ENDDATE"]);
                        if (!Convert.IsDBNull(zRdr["ENERGY"])) _ENERGY = Convert.ToDouble(zRdr["ENERGY"]);
                        if (!Convert.IsDBNull(zRdr["FIRSTDATE"])) _FIRSTDATE = Convert.ToDateTime(zRdr["FIRSTDATE"]);
                        if (!Convert.IsDBNull(zRdr["HEIGHT"])) _HEIGHT = Convert.ToDouble(zRdr["HEIGHT"]);
                        if (!Convert.IsDBNull(zRdr["HN"])) _HN = zRdr["HN"].ToString();
                        if (!Convert.IsDBNull(zRdr["ISREGISTER"])) _ISREGISTER = zRdr["ISREGISTER"].ToString();
                        if (!Convert.IsDBNull(zRdr["ISTRANSFER"])) _ISTRANSFER = zRdr["ISTRANSFER"].ToString();
                        if (!Convert.IsDBNull(zRdr["LOID"])) _LOID = Convert.ToDouble(zRdr["LOID"]);
                        if (!Convert.IsDBNull(zRdr["MEALNAME"])) _MEALNAME = zRdr["MEALNAME"].ToString();
                        if (!Convert.IsDBNull(zRdr["MEALQTY"])) _MEALQTY = zRdr["MEALQTY"].ToString();
                        if (!Convert.IsDBNull(zRdr["MILKCATEGORY"])) _MILKCATEGORY = Convert.ToDouble(zRdr["MILKCATEGORY"]);
                        if (!Convert.IsDBNull(zRdr["MILKCODE"])) _MILKCODE = zRdr["MILKCODE"].ToString();
                        if (!Convert.IsDBNull(zRdr["MILKCODEID"])) _MILKCODEID = Convert.ToDouble(zRdr["MILKCODEID"]);
                        if (!Convert.IsDBNull(zRdr["MILKNAME"])) _MILKNAME = zRdr["MILKNAME"].ToString();
                        if (!Convert.IsDBNull(zRdr["ORDERDATE"])) _ORDERDATE = Convert.ToDateTime(zRdr["ORDERDATE"]);
                        if (!Convert.IsDBNull(zRdr["ORDERMILK"])) _ORDERMILK = Convert.ToDouble(zRdr["ORDERMILK"]);
                        if (!Convert.IsDBNull(zRdr["ORDERNO"])) _ORDERNO = Convert.ToDouble(zRdr["ORDERNO"]);
                        if (!Convert.IsDBNull(zRdr["OWNER"])) _OWNER = zRdr["OWNER"].ToString();
                        if (!Convert.IsDBNull(zRdr["OWNERNAME"])) _OWNERNAME = zRdr["OWNERNAME"].ToString();
                        if (!Convert.IsDBNull(zRdr["OWNERTEXT"])) _OWNERTEXT = zRdr["OWNERTEXT"].ToString();
                        if (!Convert.IsDBNull(zRdr["PATIENTNAME"])) _PATIENTNAME = zRdr["PATIENTNAME"].ToString();
                        if (!Convert.IsDBNull(zRdr["PREPAREMEAL"])) _PREPAREMEAL = zRdr["PREPAREMEAL"].ToString();
                        if (!Convert.IsDBNull(zRdr["PREPARETIME"])) _PREPARETIME = Convert.ToDouble(zRdr["PREPARETIME"]);
                        if (!Convert.IsDBNull(zRdr["PRINTTIME"])) _PRINTTIME = Convert.ToDateTime(zRdr["PRINTTIME"]);
                        if (!Convert.IsDBNull(zRdr["REGISTERDATE"])) _REGISTERDATE = Convert.ToDateTime(zRdr["REGISTERDATE"]);
                        if (!Convert.IsDBNull(zRdr["ROOMNO"])) _ROOMNO = zRdr["ROOMNO"].ToString();
                        if (!Convert.IsDBNull(zRdr["STATUS"])) _STATUS = zRdr["STATUS"].ToString();
                        if (!Convert.IsDBNull(zRdr["STATUSNAME"])) _STATUSNAME = zRdr["STATUSNAME"].ToString();
                        if (!Convert.IsDBNull(zRdr["VN"])) _VN = zRdr["VN"].ToString();
                        if (!Convert.IsDBNull(zRdr["VOLUMN"])) _VOLUMN = Convert.ToDouble(zRdr["VOLUMN"]);
                        if (!Convert.IsDBNull(zRdr["WARDID"])) _WARDID = Convert.ToDouble(zRdr["WARDID"]);
                        if (!Convert.IsDBNull(zRdr["WARDNAME"])) _WARDNAME = zRdr["WARDNAME"].ToString();
                        if (!Convert.IsDBNull(zRdr["WEIGHT"])) _WEIGHT = Convert.ToDouble(zRdr["WEIGHT"]);
                        if (!Convert.IsDBNull(zRdr["DELIVERYTIME"])) _DELIVERYTIME = Convert.ToDateTime(zRdr["DELIVERYTIME"]);

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

        public DataTable GetDataListByConditions(double cWARD, string cMILKNAME, string cPATIENTNAME, string cHN, string cAN, string cVN, DateTime cORDERDATE, string cPREPAREMEAL, string cOWNER, string admitPatientList, string orderBy, OracleTransaction trans)
        {
            string whText = "";
            if (cWARD != 0) whText += (whText == "" ? "" : "AND ") + "WARDID = " + DB.SetDouble(cWARD) + " ";
            if (cMILKNAME.Trim() != "") whText += (whText == "" ? "" : "AND ") + "MILKNAME = " + DB.SetString(cMILKNAME) + " ";
            if (cPATIENTNAME.Trim() != "") whText += (whText == "" ? "" : "AND ") + "PATIENTNAME LIKE " + DB.SetString("%" + cPATIENTNAME + "%") + " ";
            if (cHN.Trim() != "") whText += (whText == "" ? "" : "AND ") + "HN LIKE " + DB.SetString("%" + cHN + "%") + " ";
            if (cAN.Trim() != "") whText += (whText == "" ? "" : "AND ") + "AN LIKE " + DB.SetString("%" + cAN + "%") + " ";
            if (cVN.Trim() != "") whText += (whText == "" ? "" : "AND ") + "VN LIKE " + DB.SetString("%" + cVN + "%") + " ";
            if (cORDERDATE.Year != 1) whText += (whText == "" ? "" : "AND ") + "TO_CHAR(PRINTTIME,'YYYYMMDD') = " + DB.SetDateToStringValue(cORDERDATE) + " ";
            if (cPREPAREMEAL.Trim() != "") whText += (whText == "" ? "" : "AND ") + "PREPAREMEAL = " + DB.SetString(cPREPAREMEAL) + " ";
            if (cOWNER.Trim() != "") whText += (whText == "" ? "" : "AND ") + "OWNER = " + DB.SetString(cOWNER) + " ";
            if (admitPatientList.Trim() != "") whText += (whText == "" ? "" : "AND ") + "ADMITPATIENT IN (" + admitPatientList + ") ";
            return GetDataList(whText, orderBy, trans);
        }

    }
}