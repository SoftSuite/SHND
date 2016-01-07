using System;

namespace SHND.Data.Inventory
{
    /// <summary>
    /// Represents a V_MENU_STOCKOUT data.
    /// [Created by 127.0.0.1 on Febuary,27 2009]
    /// </summary>
    public class VMenuStockOutData
    {
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
    }
}