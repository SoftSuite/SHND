using System;

namespace SHND.Data.Tables
{
    /// <summary>
    /// Represents a MENUSTANDARD data.
    /// [Created by 127.0.0.1 on June,24 2009]
    /// </summary>
    public class MenuStandardData
    {
        double _BMONTH = 0;
        double _BYEAR = 0;
        double _CREATEBY = 0;
        DateTime _CREATEON = new DateTime(1, 1, 1);
        double _LOID = 0;
        double _MENU = 0;
        string _MENUSOURCE = "";
        double _MMONTH = 0;
        double _MYEAR = 0;
        double _PATIENTQTY = 0;
        string _PATIENTSOURCE = "";
        double _STDMENU = 0;
        double _UPDATEBY = 0;
        DateTime _UPDATEON = new DateTime(1, 1, 1);

        public double BMONTH
        {
            get { return _BMONTH; }
            set { _BMONTH = value; }
        }
        public double BYEAR
        {
            get { return _BYEAR; }
            set { _BYEAR = value; }
        }
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
        public double LOID
        {
            get { return _LOID; }
            set { _LOID = value; }
        }
        public double MENU
        {
            get { return _MENU; }
            set { _MENU = value; }
        }
        public string MENUSOURCE
        {
            get { return _MENUSOURCE; }
            set { _MENUSOURCE = value; }
        }
        public double MMONTH
        {
            get { return _MMONTH; }
            set { _MMONTH = value; }
        }
        public double MYEAR
        {
            get { return _MYEAR; }
            set { _MYEAR = value; }
        }
        public double PATIENTQTY
        {
            get { return _PATIENTQTY; }
            set { _PATIENTQTY = value; }
        }
        public string PATIENTSOURCE
        {
            get { return _PATIENTSOURCE; }
            set { _PATIENTSOURCE = value; }
        }
        public double STDMENU
        {
            get { return _STDMENU; }
            set { _STDMENU = value; }
        }
        public double UPDATEBY
        {
            get { return _UPDATEBY; }
            set { _UPDATEBY = value; }
        }
        public DateTime UPDATEON
        {
            get { return _UPDATEON; }
            set { _UPDATEON = value; }
        }
    }
}