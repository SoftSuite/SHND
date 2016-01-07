using System;
using System.Collections;

namespace SHND.Data.Order
{
    /// <summary>
    /// Represents a ORDERMEDICALSET data.
    /// [Created by 127.0.0.1 on March,12 2009]
    /// </summary>
    public class OrderMedicalSetData
    {
        double _ADMITPATIENT = 0;
        bool _BREAKFAST = false;
        string _CREATEBY = "";
        DateTime _CREATEON = new DateTime(1, 1, 1);
        bool _DINNER = false;
        double _DOCTOR = 0;
        DateTime _ENDDATE = new DateTime(1, 1, 1);
        string _ENDMEAL = "";
        DateTime _FIRSTDATE = new DateTime(1, 1, 1);
        DateTime _FIRSTDATEREGIS = new DateTime(1, 1, 1);
        string _FIRSTMEAL = "";
        string _FIRSTMEALREGIS = "";
        double _FOODCATEGORY = 0;
        bool _ISCALCULATE = true;
        bool _ISINCREASE = true;
        bool _ISLIMIT = true;
        bool _ISNPO = false;
        bool _ISREGISTER = false;
        bool _ISSPECIFIC = true;
        double _LOID = 0;
        bool _LUNCH = false;
        double _NPOPERIOD = 0;
        DateTime _NPOSTART = new DateTime(1, 1, 1);
        DateTime _ORDERDATE = new DateTime(1, 1, 1);
        DateTime _REGISTERDATE = new DateTime(1, 1, 1);
        string _REMARKS = "";
        string _STATUS = "";
        string _UNREGISREASON = "";
        string _UPDATEBY = "";
        DateTime _UPDATEON = new DateTime(1, 1, 1);
        ArrayList _ORDERITEMLIST = new ArrayList();

        public double ADMITPATIENT
        {
            get { return _ADMITPATIENT; }
            set { _ADMITPATIENT = value; }
        }
        public bool BREAKFAST
        {
            get { return _BREAKFAST; }
            set { _BREAKFAST = value; }
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
        public bool DINNER
        {
            get { return _DINNER; }
            set { _DINNER = value; }
        }
        public double DOCTOR
        {
            get { return _DOCTOR; }
            set { _DOCTOR = value; }
        }
        public DateTime ENDDATE
        {
            get { return _ENDDATE; }
            set { _ENDDATE = value; }
        }
        public string ENDMEAL
        {
            get { return _ENDMEAL; }
            set { _ENDMEAL = value; }
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
        public string FIRSTMEAL
        {
            get { return _FIRSTMEAL; }
            set { _FIRSTMEAL = value; }
        }
        public string FIRSTMEALREGIS
        {
            get { return _FIRSTMEALREGIS; }
            set { _FIRSTMEALREGIS = value; }
        }
        public double FOODCATEGORY
        {
            get { return _FOODCATEGORY; }
            set { _FOODCATEGORY = value; }
        }
        public bool ISCALCULATE
        {
            get { return _ISCALCULATE; }
            set { _ISCALCULATE = value; }
        }
        public bool ISINCREASE
        {
            get { return _ISINCREASE; }
            set { _ISINCREASE = value; }
        }
        public bool ISLIMIT
        {
            get { return _ISLIMIT; }
            set { _ISLIMIT = value; }
        }
        public bool ISNPO
        {
            get { return _ISNPO; }
            set { _ISNPO = value; }
        }
        public bool ISREGISTER
        {
            get { return _ISREGISTER; }
            set { _ISREGISTER = value; }
        }
        public bool ISSPECIFIC
        {
            get { return _ISSPECIFIC; }
            set { _ISSPECIFIC = value; }
        }
        public double LOID
        {
            get { return _LOID; }
            set { _LOID = value; }
        }
        public bool LUNCH
        {
            get { return _LUNCH; }
            set { _LUNCH = value; }
        }
        public double NPOPERIOD
        {
            get { return _NPOPERIOD; }
            set { _NPOPERIOD = value; }
        }
        public DateTime NPOSTART
        {
            get { return _NPOSTART; }
            set { _NPOSTART = value; }
        }
        public DateTime ORDERDATE
        {
            get { return _ORDERDATE; }
            set { _ORDERDATE = value; }
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
        public ArrayList ORDERITEMLIST
        {
            get { return _ORDERITEMLIST; }
            set { _ORDERITEMLIST = value; }
        }
    }
}