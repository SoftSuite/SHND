using System;

namespace SHND.Data.Tables
{
    /// <summary>
    /// Represents a MENUITEMCHANGE data.
    /// [Created by 127.0.0.1 on April,20 2009]
    /// </summary>
    public class MenuItemChangeData
    {
        double _CREATEBY = 0;
        DateTime _CREATEON = new DateTime(1, 1, 1);
        double _FORMULASET = 0;
        double _FORMULASET_NEW = 0;
        string _GROUPTYPE = "";
        double _LOID = 0;
        double _MATERIALMASTER = 0;
        double _MATERIALMASTER_NEW = 0;
        string _MEAL = "";
        double _MENUDATE = 0;
        double _QTY = 0;
        double _UNIT = 0;

        public double CREATEBY
        {
            get { return _CREATEBY; }
            set { _CREATEBY = value; }
        }
        public DateTime CREATEON
        {
            get { return _CREATEON; }
            set { _CREATEON = value; }
        }
        public double FORMULASET
        {
            get { return _FORMULASET; }
            set { _FORMULASET = value; }
        }
        public double FORMULASET_NEW
        {
            get { return _FORMULASET_NEW; }
            set { _FORMULASET_NEW = value; }
        }
        public string GROUPTYPE
        {
            get { return _GROUPTYPE; }
            set { _GROUPTYPE = value; }
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
        public double MATERIALMASTER_NEW
        {
            get { return _MATERIALMASTER_NEW; }
            set { _MATERIALMASTER_NEW = value; }
        }
        public string MEAL
        {
            get { return _MEAL; }
            set { _MEAL = value; }
        }
        public double MENUDATE
        {
            get { return _MENUDATE; }
            set { _MENUDATE = value; }
        }
        public double QTY
        {
            get { return _QTY; }
            set { _QTY = value; }
        }
        public double UNIT
        {
            get { return _UNIT; }
            set { _UNIT = value; }
        }
    }
}