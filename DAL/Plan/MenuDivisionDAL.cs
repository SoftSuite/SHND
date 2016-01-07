using System;
using System.Data;
using System.Data.OracleClient;
using System.Collections.Generic;
using System.Text;
using DB = SHND.DAL.Utilities.OracleDB;

namespace SHND.DAL.Plan
{
    public class MenuDivisionDAL
    {
        public DataTable GetMenuByDivisionList(double division, DateTime dateFrom, DateTime dateTo, OracleTransaction trans)
        {
            string orderBy = "M.NAME";
            string sqlSelect = "SELECT M.NAME MENUNAME, SUM(MD.PORTION) PORTION " +
                "FROM MENU M INNER JOIN MENUDATE MD ON M.LOID=MD.MENU " +
                "WHERE M.STATUS = 'AP' AND M.DIVISION = " + DB.SetDouble(division) + " " + 
                "AND TO_DATE(MD.MENUDATE) >= " + DB.SetDate(dateFrom) + " AND TO_DATE(MD.MENUDATE) <= " + DB.SetDate(dateTo) + " " +
                "GROUP BY M.NAME ";

            return DB.ExecuteTable(sqlSelect + (orderBy == "" ? "" : "ORDER BY " + DB.SetSortString(orderBy)), trans);
        }

        public DataTable CalculatedItem(double planOrderDivision, DateTime dateFrom, DateTime dateTo, OracleTransaction trans)
        {
            string orderBy = "CLASSNAME, GROUPNAME, MATERIALNAME";
            string sqlSelect = "SELECT PMD.LOID, PMD.SAPCODE, PMD.MATERIALNAME, PMD.UNITNAME, PMD.CLASSNAME, PMD.STATUS, PMD.STATUSNAME, PMD.SPEC, " +
                " NVL(CASE WHEN B.REFTYPE='FORMULASET' THEN ROUND(SUM(PKE_UNIT.FN_CONUNITPLAN(PMI.MATERIALMASTER, PMI.UNIT, B.QTY)),6) " +
	            "      WHEN B.REFTYPE='MATERIALMASTER' THEN ROUND(SUM(PKE_UNIT.FN_CONUNIT(PMI.MATERIALMASTER, B.UNIT, PMI.UNIT, B.QTY)),6) " +
                " END,0) MENUQTY, " +
                " NVL(CASE WHEN B.REFTYPE='FORMULASET' THEN ROUND(SUM(PKE_UNIT.FN_CONUNITPLAN(PMI.MATERIALMASTER, PMI.UNIT, B.QTY)),6) " +
	            "      WHEN B.REFTYPE='MATERIALMASTER' THEN ROUND(SUM(PKE_UNIT.FN_CONUNIT(PMI.MATERIALMASTER, B.UNIT, PMI.UNIT, B.QTY)),6) " +
                " END,0)  REQQTY, " +
                "PMD.GROUPNAME " +
                "FROM V_PLANFOOD_DIVISION_MATERIAL PMD INNER JOIN PLANMATERIALITEM PMI ON PMI.LOID = PMD.PLANMATERIALITEM " +
                "LEFT JOIN " +
                "( " +
                "SELECT MENU.DIVISION, NVL(MI.MATERIALMASTER, FI.MATERIALMASTER) MATERIALMASTER, " +
				" CASE WHEN MI.FORMULASET IS NOT NULL THEN (FI.WEIGHT*MD.PORTION*MI.QTY)/FS.PORTION WHEN MI.MATERIALMASTER IS NOT NULL THEN MI.QTY*MD.PORTION END QTY, " +
				" CASE WHEN MI.FORMULASET IS NOT NULL THEN FN_GETCONFIGVALUE(16) WHEN MI.MATERIALMASTER IS NOT NULL THEN MI.UNIT END UNIT, " +
				" CASE WHEN MI.FORMULASET IS NOT NULL THEN 'FORMULASET' WHEN MI.MATERIALMASTER IS NOT NULL THEN 'MATERIALMASTER' END REFTYPE " +
                "FROM MENUDATE MD INNER JOIN MENUITEM MI ON MI.MENUDATE = MD.LOID " +
                "INNER JOIN MENU ON MENU.LOID = MD.MENU " +
                "LEFT JOIN FORMULASETITEM FI ON FI.FORMULASET = MI.FORMULASET " +
                "LEFT JOIN FORMULASET FS ON FS.LOID=FI.FORMULASET " +
                "LEFT JOIN MATERIALMASTER M ON M.LOID = FI.MATERIALMASTER " +
                "WHERE MENU.STATUS = 'AP' AND TO_DATE(MD.MENUDATE) >= " + DB.SetDate(dateFrom) + " AND TO_DATE(MD.MENUDATE) <= " + DB.SetDate(dateTo) + " " +
                ") B ON B.MATERIALMASTER = PMI.MATERIALMASTER AND B.DIVISION = PMD.DIVISION " +
                "WHERE PLANORDERDIVISION = " + DB.SetDouble(planOrderDivision) + " " +
                "GROUP BY PMD.LOID, PMD.SAPCODE, PMD.MATERIALNAME, PMD.UNITNAME, PMD.CLASSNAME, PMD.STATUS, PMD.STATUSNAME, PMD.SPEC, PMD.GROUPNAME, B.REFTYPE ";

            return DB.ExecuteTable(sqlSelect + (orderBy == "" ? "" : "ORDER BY " + DB.SetSortString(orderBy)), trans);
        }
    }
}
