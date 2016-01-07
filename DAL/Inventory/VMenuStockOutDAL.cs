using System;
using System.Data;
using System.Data.OracleClient;
using DB = SHND.DAL.Utilities.OracleDB;
using SHND.Data.Common.Utilities;

namespace SHND.DAL.Inventory
{
    public class VMenuStockOutDAL
    {

        #region Private Variables

        string _error = "";
        string _information = "";
        bool _OnDB = false;
        double _CLASSLOID = 0;
        string _CLASSNAME = "";
        string _CODE = "";
        double _COST = 0;
        double _DIVISION = 0;
        string _DIVISIONNAME = "";
        double _FORMULAQTY = 0;
        double _LASTQTY = 0;
        string _MASTERTYPE = "";
        string _MATERIALCODE = "";
        double _MATERIALMASTER = 0;
        string _MATERIALNAME = "";
        DateTime _MENUDATE = new DateTime(1, 1, 1);
        double _PREQTY = 0;
        double _PRICE = 0;
        double _UNIT = 0;
        string _UNITNAME = "";

        #endregion

        #region Public Properties

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
        public string CODE
        {
            get { return _CODE; }
            set { _CODE = value; }
        }
        public double COST
        {
            get { return _COST; }
            set { _COST = value; }
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
        public double FORMULAQTY
        {
            get { return _FORMULAQTY; }
            set { _FORMULAQTY = value; }
        }
        public double LASTQTY
        {
            get { return _LASTQTY; }
            set { _LASTQTY = value; }
        }
        public string MASTERTYPE
        {
            get { return _MASTERTYPE; }
            set { _MASTERTYPE = value; }
        }
        public string MATERIALCODE
        {
            get { return _MATERIALCODE; }
            set { _MATERIALCODE = value; }
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
        public DateTime MENUDATE
        {
            get { return _MENUDATE; }
            set { _MENUDATE = value; }
        }
        public double PREQTY
        {
            get { return _PREQTY; }
            set { _PREQTY = value; }
        }
        public double PRICE
        {
            get { return _PRICE; }
            set { _PRICE = value; }
        }
        public double UNIT
        {
            get { return _UNIT; }
            set { _UNIT = value; }
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
            _CLASSLOID = 0;
            _CLASSNAME = "";
            _CODE = "";
            _COST = 0;
            _DIVISION = 0;
            _DIVISIONNAME = "";
            _FORMULAQTY = 0;
            _LASTQTY = 0;
            _MASTERTYPE = "";
            _MATERIALCODE = "";
            _MATERIALMASTER = 0;
            _MATERIALNAME = "";
            _MENUDATE = new DateTime(1, 1, 1);
            _PREQTY = 0;
            _PRICE = 0;
            _UNIT = 0;
            _UNITNAME = "";
        }

        #endregion

        #region SQL Statements

        /// <summary>
        /// Gets the select statement for V_MENU_STOCKOUT table.
        /// </summary>
        private string sql_select(string whText)
        {
            //string sqlSelect = "SELECT *  FROM (SELECT M.DIVISION, MD.MENUDATE, MM.LOID || '#' || NVL(MI.UNIT,1) CODE, MM.LOID MATERIALMASTER, NVL(MI.UNIT,FN_GETCONFIGVALUE(16)) UNIT, MM.CLASSLOID, MM.MASTERTYPE, " +
            //    "MM.CLASSNAME, MM.MATERIALCODE, MM.MATERIALNAME, NVL(UNIT.THNAME, (SELECT THNAME FROM UNIT WHERE LOID=FN_GETCONFIGVALUE(16))) UNITNAME, MM.COST, MM.PRICE, D.NAME DIVISIONNAME, " +
            //    "NVL(FN_GETFORMULASTOCKOUT(M.DIVISION,MM.LOID,MD.MENUDATE,'',NVL(MI.UNIT, FN_GETCONFIGVALUE(16))),0) FORMULAQTY, " +
            //    "NVL(PKE_PURCHASE.FN_CALPREPODIVISION(M.DIVISION,MM.LOID,MD.MENUDATE,NVL(MI.UNIT,FN_GETCONFIGVALUE(16))),0) PREQTY, " +
            //    "PKE_STOCK.FN_CALLASTSTOCKOUT(M.DIVISION,MM.LOID,MD.MENUDATE,NVL(MI.UNIT,FN_GETCONFIGVALUE(16))) LASTQTY " +
            //    "FROM MENU M INNER JOIN DIVISION D ON D.LOID = M.DIVISION " +
            //    "INNER JOIN MENUDATE MD ON MD.MENU = M.LOID " +
            //    "INNER JOIN MENUITEM MI ON MI.MENUDATE = MD.LOID " +
            //    "LEFT JOIN FORMULASETITEM FI ON FI.FORMULASET = MI.FORMULASET " +
            //    "LEFT JOIN UNIT ON UNIT.LOID = MI.UNIT " +
            //    "INNER JOIN V_MATERIALMASTER MM ON MM.LOID = MI.MATERIALMASTER OR MM.LOID = FI.MATERIALMASTER " +
            //    (whText == "" ? "" : "WHERE ") + whText + " " +
            //    "GROUP BY M.DIVISION, MD.MENUDATE, MM.LOID, MI.UNIT, MM.CLASSLOID, MM.CLASSNAME, MM.MASTERTYPE, MM.MATERIALCODE, MM.MATERIALNAME, UNIT.THNAME, " +
            //    "MM.COST, MM.PRICE, D.NAME) A ";
            string sqlSelect = "SELECT * FROM (SELECT M.DIVISION, MD.MENUDATE, MM.LOID || '#' || PKE_UNIT.FN_GETSTOCKOUTUNIT(MM.LOID) CODE, MM.LOID MATERIALMASTER, PKE_UNIT.FN_GETSTOCKOUTUNIT(MM.LOID) UNIT, " +
                "MM.CLASSLOID, MM.MASTERTYPE, MM.CLASSNAME, MM.MATERIALCODE, MM.MATERIALNAME, " +
                "(SELECT THNAME FROM UNIT WHERE LOID=PKE_UNIT.FN_GETSTOCKOUTUNIT(MM.LOID)) UNITNAME, " +
                "PKE_UNIT.FN_GETUNITPRICE(MM.LOID,PKE_UNIT.FN_GETSTOCKOUTUNIT(MM.LOID)) COST, " +
                "PKE_UNIT.FN_GETUNITPRICE(MM.LOID,PKE_UNIT.FN_GETSTOCKOUTUNIT(MM.LOID),'N') PRICE, D.NAME DIVISIONNAME, " +
                "FN_GETFORMULASTOCKOUT(M.DIVISION,MM.LOID,MD.MENUDATE,'',PKE_UNIT.FN_GETSTOCKOUTUNIT(MM.LOID)) FORMULAQTY, " +
                "PKE_PURCHASE.FN_CALPREPODIVISION(M.DIVISION,MM.LOID,MD.MENUDATE,PKE_UNIT.FN_GETSTOCKOUTUNIT(MM.LOID)) PREQTY, " +
                "PKE_STOCK.FN_CALLASTSTOCKOUT(M.DIVISION,MM.LOID,MD.MENUDATE,PKE_UNIT.FN_GETSTOCKOUTUNIT(MM.LOID)) LASTQTY " +
                "FROM MENU M " +
                "INNER JOIN DIVISION D ON D.LOID = M.DIVISION " +
                "INNER JOIN MENUDATE MD ON MD.MENU = M.LOID " +
                "INNER JOIN MENUITEM MI ON MI.MENUDATE = MD.LOID " +
                "LEFT JOIN FORMULASETITEM FI ON FI.FORMULASET = MI.FORMULASET " +
                "INNER JOIN V_MATERIALMASTER MM ON MM.LOID = MI.MATERIALMASTER OR MM.LOID = FI.MATERIALMASTER " +
                (whText == "" ? "" : "WHERE ") + whText + " " +
                "GROUP BY M.DIVISION, MD.MENUDATE, MM.LOID, MM.ULOID, MM.CLASSLOID, MM.CLASSNAME, MM.MASTERTYPE, MM.MATERIALCODE, " +
                "MM.MATERIALNAME,  MM.COST, MM.PRICE, D.NAME) A ";
            return sqlSelect;
        }

        #endregion

        #region Private Methods

        /// <summary>
        /// Returns an indication whether the record of V_MENU_STOCKOUT by specified condition is retrieved successfully.
        /// </summary>
        /// <param name="whText">The condition specify the deleting record(s).</param>
        /// <param name="trans">The System.Data.OracleClient.OracleTransaction used by this System.Data.OracleClient.OracleCommand.</param>
        /// <returns>true if data is retrieved successfully; otherwise, false.</returns>
        private bool doGetdata(string whText, OracleTransaction trans)
        {
            bool ret = true;
            ClearData();
            _OnDB = false;
            if (whText.Trim() != "")
            {
                OracleDataReader zRdr = null;
                try
                {
                    zRdr = DB.ExecuteReader(sql_select(whText), trans);
                    if (zRdr.Read())
                    {
                        _OnDB = true;
                        if (!Convert.IsDBNull(zRdr["CLASSLOID"])) _CLASSLOID = Convert.ToDouble(zRdr["CLASSLOID"]);
                        if (!Convert.IsDBNull(zRdr["CLASSNAME"])) _CLASSNAME = zRdr["CLASSNAME"].ToString();
                        if (!Convert.IsDBNull(zRdr["CODE"])) _CODE = zRdr["CODE"].ToString();
                        if (!Convert.IsDBNull(zRdr["COST"])) _COST = Convert.ToDouble(zRdr["COST"]);
                        if (!Convert.IsDBNull(zRdr["DIVISION"])) _DIVISION = Convert.ToDouble(zRdr["DIVISION"]);
                        if (!Convert.IsDBNull(zRdr["DIVISIONNAME"])) _DIVISIONNAME = zRdr["DIVISIONNAME"].ToString();
                        if (!Convert.IsDBNull(zRdr["FORMULAQTY"])) _FORMULAQTY = Convert.ToDouble(zRdr["FORMULAQTY"]);
                        if (!Convert.IsDBNull(zRdr["LASTQTY"])) _LASTQTY = Convert.ToDouble(zRdr["LASTQTY"]);
                        if (!Convert.IsDBNull(zRdr["MASTERTYPE"])) _MASTERTYPE = zRdr["MASTERTYPE"].ToString();
                        if (!Convert.IsDBNull(zRdr["MATERIALCODE"])) _MATERIALCODE = zRdr["MATERIALCODE"].ToString();
                        if (!Convert.IsDBNull(zRdr["MATERIALMASTER"])) _MATERIALMASTER = Convert.ToDouble(zRdr["MATERIALMASTER"]);
                        if (!Convert.IsDBNull(zRdr["MATERIALNAME"])) _MATERIALNAME = zRdr["MATERIALNAME"].ToString();
                        if (!Convert.IsDBNull(zRdr["MENUDATE"])) _MENUDATE = Convert.ToDateTime(zRdr["MENUDATE"]);
                        if (!Convert.IsDBNull(zRdr["PREQTY"])) _PREQTY = Convert.ToDouble(zRdr["PREQTY"]);
                        if (!Convert.IsDBNull(zRdr["PRICE"])) _PRICE = Convert.ToDouble(zRdr["PRICE"]);
                        if (!Convert.IsDBNull(zRdr["UNIT"])) _UNIT = Convert.ToDouble(zRdr["UNIT"]);
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

        public DataTable GetDataListByConditions(double docType, double division, DateTime menuDate, double materialClass, string materialName, bool isBreakfast, bool isLunch, bool isDinner, string exceptCodeList, string orderBy, OracleTransaction trans)
        {
            string whText = "M.STATUS = 'AP' AND MM.ISCOUNT='Y'";
            string meal = "";
            if (docType != 0) whText += (whText == "" ? "" : "AND ") + "MM.MASTERTYPE IN (SELECT MASTERTYPE  FROM DOCTYPEMASTERTYPE WHERE DOCTYPE = " + DB.SetDouble(docType) + ") ";
            if (division != 0) whText += (whText == "" ? "" : "AND ") + "M.DIVISION = " + DB.SetDouble(division) + " ";
            if (menuDate.Year != 1) whText += (whText == "" ? "" : "AND ") + "TO_DATE(MD.MENUDATE) = " + DB.SetDate(menuDate) + " ";
            if (materialClass != 0) whText += (whText == "" ? "" : "AND ") + "MM.CLASSLOID = " + DB.SetDouble(materialClass) + " ";
            if (materialName.Trim() != "") whText += (whText == "" ? "" : "AND ") + "UPPER(MM.MATERIALNAME) LIKE " + DB.SetString("%" + materialName.Trim().ToUpper() + "%") + " ";
            if (isBreakfast || isLunch || isDinner)
            {
                if (isBreakfast) meal += (meal == "" ? "" : "OR ") + "MEAL = '11' ";
                if (isLunch) meal += (meal == "" ? "" : "OR ") + "MEAL = '21' ";
                if (isDinner) meal += (meal == "" ? "" : "OR ") + "MEAL = '31' ";
            }
            if (meal != "") whText += (whText == "" ? "" : "AND ") + "(" + meal + ") ";
            if (exceptCodeList.Trim() != "") whText += (whText == "" ? "" : "AND ") + "UPPER(MM.LOID || '#' || NVL(MI.UNIT,1)) NOT IN (" + exceptCodeList.ToUpper() + ") ";

            string sqlSelect = sql_select(whText) + (orderBy == "" ? "" : "ORDER BY " + DB.SetSortString(orderBy));
            return DB.ExecuteTable(sqlSelect, trans);
        }

        public bool GetDataByConditions(double division, DateTime menuDate, bool isBreakfast, bool isLunch, bool isDinner, double materialMaster, double unit, OracleTransaction trans)
        {
            string whText = "M.STATUS = 'AP'";
            string meal = "";
            if (division != 0) whText += (whText == "" ? "" : "AND ") + "M.DIVISION = " + DB.SetDouble(division) + " ";
            if (menuDate.Year != 1) whText += (whText == "" ? "" : "AND ") + "TO_DATE(MD.MENUDATE) = " + DB.SetDate(menuDate) + " ";
            if (materialMaster != 0) whText += (whText == "" ? "" : "AND ") + "MM.LOID = " + DB.SetDouble(materialMaster) + " ";
            if (unit != 0) whText += (whText == "" ? "" : "AND ") + "NVL(MI.UNIT,1) = " + DB.SetDouble(unit) + " ";
            if (isBreakfast || isLunch || isDinner)
            {
                if (isBreakfast) meal += (meal == "" ? "" : "OR ") + "MEAL = '11' ";
                if (isLunch) meal += (meal == "" ? "" : "OR ") + "MEAL = '21' ";
                if (isDinner) meal += (meal == "" ? "" : "OR ") + "MEAL = '31' ";
            }
            if (meal != "") whText += (whText == "" ? "" : "AND ") + "(" + meal + ") ";

            return doGetdata(whText, trans);
        }
    }
}
