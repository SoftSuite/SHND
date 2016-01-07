using System;
using System.Collections;

namespace SHND.Data.Order
{
    /// <summary>
    /// Represents a ORDERNONMEDICAL data.
    /// [Created by 127.0.0.1 on March,12 2009]
    /// </summary>
    public class OrderNonMedicalData
    {
        string _ABSTAINOTHER = "";
        double _ADMITPATIENT = 0;
        double _BREAKFAST = 0;
        string _CREATEBY = "";
        DateTime _CREATEON = new DateTime(1, 1, 1);
        double _DINNER = 0;
        DateTime _ENDDATE = new DateTime(1, 1, 1);
        string _ENDMEAL = "";
        DateTime _FIRSTDATE = new DateTime(1, 1, 1);
        DateTime _FIRSTDATEREGIS = new DateTime(1, 1, 1);
        string _FIRSTMEAL = "";
        string _FIRSTMEALREGIS = "";
        double _FOODTYPE = 0;
        bool _ISABSTAIN = true;
        bool _ISFAMILY = false;
        bool _ISNEED = true;
        bool _ISREGISTER = false;
        bool _ISREQUEST = true;
        double _LOID = 0;
        double _LUNCH = 0;
        string _NEEDOTHER = "";
        double _NURSE = 0;
        DateTime _ORDERDATE = new DateTime(1, 1, 1);
        DateTime _REGISTERDATE = new DateTime(1, 1, 1);
        string _REMARKS = "";
        string _REQUESTOTHER = "";
        string _STATUS = "";
        string _UNREGISREASON = "";
        string _UPDATEBY = "";
        DateTime _UPDATEON = new DateTime(1, 1, 1);
        string _VIPTYPE = "";
        ArrayList _ORDERITEMLIST = new ArrayList();

        public string ABSTAINOTHER
        {
            get { return _ABSTAINOTHER; }
            set { _ABSTAINOTHER = value; }
        }
        public double ADMITPATIENT
        {
            get { return _ADMITPATIENT; }
            set { _ADMITPATIENT = value; }
        }
        public double BREAKFAST
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
        public double DINNER
        {
            get { return _DINNER; }
            set { _DINNER = value; }
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
        public double FOODTYPE
        {
            get { return _FOODTYPE; }
            set { _FOODTYPE = value; }
        }
        public bool ISABSTAIN
        {
            get { return _ISABSTAIN; }
            set { _ISABSTAIN = value; }
        }
        public bool ISFAMILY
        {
            get { return _ISFAMILY; }
            set { _ISFAMILY = value; }
        }
        public bool ISNEED
        {
            get { return _ISNEED; }
            set { _ISNEED = value; }
        }
        public bool ISREGISTER
        {
            get { return _ISREGISTER; }
            set { _ISREGISTER = value; }
        }
        public bool ISREQUEST
        {
            get { return _ISREQUEST; }
            set { _ISREQUEST = value; }
        }
        public double LOID
        {
            get { return _LOID; }
            set { _LOID = value; }
        }
        public double LUNCH
        {
            get { return _LUNCH; }
            set { _LUNCH = value; }
        }
        public string NEEDOTHER
        {
            get { return _NEEDOTHER; }
            set { _NEEDOTHER = value; }
        }
        public double NURSE
        {
            get { return _NURSE; }
            set { _NURSE = value; }
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
        public string REQUESTOTHER
        {
            get { return _REQUESTOTHER; }
            set { _REQUESTOTHER = value; }
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
        public string VIPTYPE
        {
            get { return _VIPTYPE; }
            set { _VIPTYPE = value; }
        }
        public ArrayList ORDERITEMLIST
        {
            get { return _ORDERITEMLIST; }
            set { _ORDERITEMLIST = value; }
        }
    }
}