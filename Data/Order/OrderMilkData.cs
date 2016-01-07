using System;
using System.Collections;

namespace SHND.Data.Order
{
    /// <summary>
    /// Represents a ORDERMILK data.
    /// [Created by 127.0.0.1 on March,12 2009]
    /// </summary>
    public class OrderMilkData
    {
        double _ADMITPATIENT = 0;
        double _CAPACITYRATE = 0;
        string _CREATEBY = "";
        DateTime _CREATEON = new DateTime(1, 1, 1);
        DateTime _ENDDATE = new DateTime(1, 1, 1);
        string _ENDTIME = "";
        double _ENERGY = 0;
        double _ENERGYRATE = 0;
        DateTime _FIRSTDATE = new DateTime(1, 1, 1);
        DateTime _FIRSTDATEREGIS = new DateTime(1, 1, 1);
        string _FIRSTMEALREGIS = "";
        string _FIRSTTIME = "";
        bool _ISINCREASE = true;
        bool _ISREGISTER = false;
        bool _ISSPIN = false;
        double _LOID = 0;
        double _MEALQTY = 0;
        double _MILKCATEGORY = 0;
        double _MILKCODE = 0;
        double _ORDERBY = 0;
        DateTime _ORDERDATE = new DateTime(1, 1, 1);
        string _OWNER = "";
        string _OWNERTEXT = "";
        DateTime _REGISTERDATE = new DateTime(1, 1, 1);
        string _REMARKS = "";
        string _STATUS = "";
        bool _TIME1 = false;
        bool _TIME10 = false;
        bool _TIME11 = false;
        bool _TIME12 = false;
        bool _TIME13 = false;
        bool _TIME14 = false;
        bool _TIME15 = false;
        bool _TIME16 = false;
        bool _TIME17 = false;
        bool _TIME18 = false;
        bool _TIME19 = false;
        bool _TIME2 = false;
        bool _TIME20 = false;
        bool _TIME21 = false;
        bool _TIME22 = false;
        bool _TIME23 = false;
        bool _TIME24 = false;
        bool _TIME3 = false;
        bool _TIME4 = false;
        bool _TIME5 = false;
        bool _TIME6 = false;
        bool _TIME7 = false;
        bool _TIME8 = false;
        bool _TIME9 = false;
        string _UNREGISREASON = "";
        string _UPDATEBY = "";
        DateTime _UPDATEON = new DateTime(1, 1, 1);
        double _VOLUMN = 0;
        double _WEIGHT = 0;
        ArrayList _ORDERITEMLIST = new ArrayList();

        public double ADMITPATIENT
        {
            get { return _ADMITPATIENT; }
            set { _ADMITPATIENT = value; }
        }
        public double CAPACITYRATE
        {
            get { return _CAPACITYRATE; }
            set { _CAPACITYRATE = value; }
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
        public DateTime ENDDATE
        {
            get { return _ENDDATE; }
            set { _ENDDATE = value; }
        }
        public string ENDTIME
        {
            get { return _ENDTIME; }
            set { _ENDTIME = value; }
        }
        public double ENERGY
        {
            get { return _ENERGY; }
            set { _ENERGY = value; }
        }
        public double ENERGYRATE
        {
            get { return _ENERGYRATE; }
            set { _ENERGYRATE = value; }
        }
        public DateTime FIRSTDATE
        {
            get { return _FIRSTDATE; }
            set { _FIRSTDATE = value; }
        }
        public DateTime FIRSTDATEREGIS
        {
            get { return _FIRSTDATEREGIS; }
            set { _FIRSTDATEREGIS = value; }
        }
        public string FIRSTMEALREGIS
        {
            get { return _FIRSTMEALREGIS; }
            set { _FIRSTMEALREGIS = value; }
        }
        public string FIRSTTIME
        {
            get { return _FIRSTTIME; }
            set { _FIRSTTIME = value; }
        }
        public bool ISINCREASE
        {
            get { return _ISINCREASE; }
            set { _ISINCREASE = value; }
        }
        public bool ISREGISTER
        {
            get { return _ISREGISTER; }
            set { _ISREGISTER = value; }
        }
        public bool ISSPIN
        {
            get { return _ISSPIN; }
            set { _ISSPIN = value; }
        }
        public double LOID
        {
            get { return _LOID; }
            set { _LOID = value; }
        }
        public double MEALQTY
        {
            get { return _MEALQTY; }
            set { _MEALQTY = value; }
        }
        public double MILKCATEGORY
        {
            get { return _MILKCATEGORY; }
            set { _MILKCATEGORY = value; }
        }
        public double MILKCODE
        {
            get { return _MILKCODE; }
            set { _MILKCODE = value; }
        }
        public double ORDERBY
        {
            get { return _ORDERBY; }
            set { _ORDERBY = value; }
        }
        public DateTime ORDERDATE
        {
            get { return _ORDERDATE; }
            set { _ORDERDATE = value; }
        }
        public string OWNER
        {
            get { return _OWNER; }
            set { _OWNER = value; }
        }
        public string OWNERTEXT
        {
            get { return _OWNERTEXT; }
            set { _OWNERTEXT = value; }
        }
        public DateTime REGISTERDATE
        {
            get { return _REGISTERDATE; }
            set { _REGISTERDATE = value; }
        }
        public string REMARKS
        {
            get { return _REMARKS; }
            set { _REMARKS = value; }
        }
        public string STATUS
        {
            get { return _STATUS; }
            set { _STATUS = value; }
        }
        public bool TIME1
        {
            get { return _TIME1; }
            set { _TIME1 = value; }
        }
        public bool TIME10
        {
            get { return _TIME10; }
            set { _TIME10 = value; }
        }
        public bool TIME11
        {
            get { return _TIME11; }
            set { _TIME11 = value; }
        }
        public bool TIME12
        {
            get { return _TIME12; }
            set { _TIME12 = value; }
        }
        public bool TIME13
        {
            get { return _TIME13; }
            set { _TIME13 = value; }
        }
        public bool TIME14
        {
            get { return _TIME14; }
            set { _TIME14 = value; }
        }
        public bool TIME15
        {
            get { return _TIME15; }
            set { _TIME15 = value; }
        }
        public bool TIME16
        {
            get { return _TIME16; }
            set { _TIME16 = value; }
        }
        public bool TIME17
        {
            get { return _TIME17; }
            set { _TIME17 = value; }
        }
        public bool TIME18
        {
            get { return _TIME18; }
            set { _TIME18 = value; }
        }
        public bool TIME19
        {
            get { return _TIME19; }
            set { _TIME19 = value; }
        }
        public bool TIME2
        {
            get { return _TIME2; }
            set { _TIME2 = value; }
        }
        public bool TIME20
        {
            get { return _TIME20; }
            set { _TIME20 = value; }
        }
        public bool TIME21
        {
            get { return _TIME21; }
            set { _TIME21 = value; }
        }
        public bool TIME22
        {
            get { return _TIME22; }
            set { _TIME22 = value; }
        }
        public bool TIME23
        {
            get { return _TIME23; }
            set { _TIME23 = value; }
        }
        public bool TIME24
        {
            get { return _TIME24; }
            set { _TIME24 = value; }
        }
        public bool TIME3
        {
            get { return _TIME3; }
            set { _TIME3 = value; }
        }
        public bool TIME4
        {
            get { return _TIME4; }
            set { _TIME4 = value; }
        }
        public bool TIME5
        {
            get { return _TIME5; }
            set { _TIME5 = value; }
        }
        public bool TIME6
        {
            get { return _TIME6; }
            set { _TIME6 = value; }
        }
        public bool TIME7
        {
            get { return _TIME7; }
            set { _TIME7 = value; }
        }
        public bool TIME8
        {
            get { return _TIME8; }
            set { _TIME8 = value; }
        }
        public bool TIME9
        {
            get { return _TIME9; }
            set { _TIME9 = value; }
        }
        public string UNREGISREASON
        {
            get { return _UNREGISREASON; }
            set { _UNREGISREASON = value; }
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
        public double VOLUMN
        {
            get { return _VOLUMN; }
            set { _VOLUMN = value; }
        }
        public double WEIGHT
        {
            get { return _WEIGHT; }
            set { _WEIGHT = value; }
        }
        public ArrayList ORDERITEMLIST
        {
            get { return _ORDERITEMLIST; }
            set { _ORDERITEMLIST = value; }
        }
    }
}