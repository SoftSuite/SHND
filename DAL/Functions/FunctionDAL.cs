using System;
using System.Collections.Generic;
using System.Data.OracleClient;
using System.Text;
using DB = SHND.DAL.Utilities.OracleDB;

namespace SHND.DAL.Functions
{
    public class FunctionDAL
    {
        public double CalEnergyWeight(double materialMasterID, double weight, OracleTransaction trans)
        {
            return Convert.ToDouble(DB.ExecuteScalar("SELECT FN_CALENERGYWEIGHT(" + DB.SetDouble(materialMasterID) + ", " + DB.SetDouble(weight) + ") FROM DUAL", trans));
        }
        public double CalplantoolsQTY(double PlanID, double MaterialMaster,double Division, OracleTransaction trans)
        {
            return Convert.ToDouble(DB.ExecuteScalar("SELECT PKE_PLAN.FN_CALPLANTOOLSQTY (" + DB.SetDouble(PlanID) + "," + DB.SetDouble(MaterialMaster) + "," + DB.SetDouble(Division) + ") FROM DUAL ", trans));
        }
        public double CalPlanFoodQTY(double PlanID, double MaterialMaster, OracleTransaction trans)
        {
            return Convert.ToDouble(DB.ExecuteScalar("SELECT PKE_PLAN.FN_CALPLANQTY (" + DB.SetDouble(PlanID) + "," + DB.SetDouble(MaterialMaster) + ") FROM DUAL ", trans));
        }
        public double GetFormulaStockOut(double division, double materialMaster, DateTime useDate, string meal, double unitTo, OracleTransaction trans)
        {
            return Convert.ToDouble(DB.ExecuteScalar("SELECT FN_GETFORMULASTOCKOUT (" + DB.SetDouble(division) + "," + DB.SetDouble(materialMaster) + "," + DB.SetDate(useDate) + "," + DB.SetString(meal) + "," + DB.SetDouble(unitTo) + ") FROM DUAL ", trans));
        }
        public double CalPrePODivision(double division, double materialMaster, DateTime useDate, double unitTo, OracleTransaction trans)
        {
            return Convert.ToDouble(DB.ExecuteScalar("SELECT PKE_PURCHASE.FN_CALPREPODIVISION (" + DB.SetDouble(division) + "," + DB.SetDouble(materialMaster) + "," + DB.SetDate(useDate) + "," + DB.SetDouble(unitTo) + ") FROM DUAL ", trans));
        }
        public double CalPatentQtyStockOut(double division, DateTime menuDate, bool isBreakfast, bool isLunch, bool isDinner, OracleTransaction trans)
        {
            return Convert.ToDouble(DB.ExecuteScalar("SELECT PKE_PATIENT.FN_CALPATIENTQTYSTOCKOUT (" + DB.SetDouble(division) + "," + DB.SetDate(menuDate) + "," + (isBreakfast ? "1" : "0") + "," + (isLunch ? "1" : "0") + "," + (isDinner ? "1" : "0") + ") FROM DUAL ", trans));
        }
        public double CalLastStockOut(double division, double materialMaster, DateTime useDate, double unit, OracleTransaction trans)
        {
            return Convert.ToDouble(DB.ExecuteScalar("SELECT PKE_STOCK.FN_CALLASTSTOCKOUT (" + DB.SetDouble(division) + "," + DB.SetDouble(materialMaster) + "," + DB.SetDate(useDate) + "," + DB.SetDouble(unit) + ") FROM DUAL ", trans));
        }
        public string GetConfigValue(double ID)
        {
            return DB.ExecuteScalar("SELECT FN_GETCONFIGVALUE(" + DB.SetDouble(ID) + ") FROM DUAL").ToString();
        }
        public string GetConfigValue(string ConfigName)
        {
            return DB.ExecuteScalar("SELECT FN_GETCONFIGVALUEBYNAME(" + DB.SetString(ConfigName) + ") FROM DUAL").ToString();
        }
        public double CalPlanToolsStockin(double planID, double materialmaster, double unitTo, OracleTransaction trans)
        {
            return Convert.ToDouble(DB.ExecuteScalar("SELECT PKE_PLAN.FN_CALPLANTOOLSTOCKIN(" + DB.SetDouble(planID) + "," + DB.SetDouble(materialmaster) + "," + DB.SetDouble(unitTo) + ") FROM DUAL ", trans));
        }
        public double GetWelfareRightQty(DateTime vDate, double vDivision, string isTiffin, OracleTransaction trans)
        {
            return Convert.ToDouble(DB.ExecuteScalar("SELECT PKE_PREPARE.FN_GETWELFARERIGHTQTY(" + DB.SetDate(vDate) + "," + DB.SetDouble(vDivision) + "," + DB.SetString(isTiffin) + ") FROM DUAL ", trans));
        }
    }
}
