using System;

namespace SHND.Data.Views
{
    /// <summary>
    /// Represents a V_ORDER_CHANGE data.
    /// [Created by 127.0.0.1 on April,24 2009]
    /// </summary>
    public class VOrderChangeData
    {
        string _ABSTAIN = "";
        string _ABSTAIN_NEW = "";
        double _ADMITPATIENT = 0;
        string _AGE = "";
        string _AN = "";
        string _BEDNO = "";
        string _BMI = "";
        string _CONTROL = "";
        string _CONTROL_NEW = "";
        DateTime _ENDDATE_OLD = new DateTime(1, 1, 1);
        double _FOODCATEGORYID_NEW = 0;
        double _FOODCATEGORYID_OLD = 0;
        string _FOODCATEGORYNAME = "";
        string _FOODCATEGORYNAME_NEW = "";
        double _FOODTYPEID_NEW = 0;
        double _FOODTYPEID_OLD = 0;
        string _FOODTYPENAME = "";
        string _FOODTYPENAME_NEW = "";
        double _HEIGHT = 0;
        string _HN = "";
        string _INCREASE = "";
        string _INCREASE_NEW = "";
        string _LIMIT = "";
        string _LIMIT_NEW = "";
        string _NEED = "";
        string _NEED_NEW = "";
        DateTime _ORDERDATE = new DateTime(1, 1, 1);
        DateTime _ORDERDATE_NEW = new DateTime(1, 1, 1);
        double _ORDERMEDID = 0;
        double _ORDERNONMEDID = 0;
        string _PATIENTNAME = "";
        string _QTY = "";
        string _QTY_NEW = "";
        string _REFMEDTABLE = "";
        string _REMARKS = "";
        string _REMARKS_NEW = "";
        string _ROOMNO = "";
        string _STATUS = "";
        string _STATUS_NEW = "";
        string _VN = "";
        double _WARD = 0;
        string _WARDNAME = "";
        double _WEIGHT = 0;
        double _ORDERNO = 0;

        public string ABSTAIN
        {
            get { return _ABSTAIN; }
            set { _ABSTAIN = value; }
        }
        public string ABSTAIN_NEW
        {
            get { return _ABSTAIN_NEW; }
            set { _ABSTAIN_NEW = value; }
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
        public string BMI
        {
            get { return _BMI; }
            set { _BMI = value; }
        }
        public string CONTROL
        {
            get { return _CONTROL; }
            set { _CONTROL = value; }
        }
        public string CONTROL_NEW
        {
            get { return _CONTROL_NEW; }
            set { _CONTROL_NEW = value; }
        }
        public DateTime ENDDATE_OLD
        {
            get { return _ENDDATE_OLD; }
            set { _ENDDATE_OLD = value; }
        }
        public double FOODCATEGORYID_NEW
        {
            get { return _FOODCATEGORYID_NEW; }
            set { _FOODCATEGORYID_NEW = value; }
        }
        public double FOODCATEGORYID_OLD
        {
            get { return _FOODCATEGORYID_OLD; }
            set { _FOODCATEGORYID_OLD = value; }
        }
        public string FOODCATEGORYNAME
        {
            get { return _FOODCATEGORYNAME; }
            set { _FOODCATEGORYNAME = value; }
        }
        public string FOODCATEGORYNAME_NEW
        {
            get { return _FOODCATEGORYNAME_NEW; }
            set { _FOODCATEGORYNAME_NEW = value; }
        }
        public double FOODTYPEID_NEW
        {
            get { return _FOODTYPEID_NEW; }
            set { _FOODTYPEID_NEW = value; }
        }
        public double FOODTYPEID_OLD
        {
            get { return _FOODTYPEID_OLD; }
            set { _FOODTYPEID_OLD = value; }
        }
        public string FOODTYPENAME
        {
            get { return _FOODTYPENAME; }
            set { _FOODTYPENAME = value; }
        }
        public string FOODTYPENAME_NEW
        {
            get { return _FOODTYPENAME_NEW; }
            set { _FOODTYPENAME_NEW = value; }
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
        public string INCREASE
        {
            get { return _INCREASE; }
            set { _INCREASE = value; }
        }
        public string INCREASE_NEW
        {
            get { return _INCREASE_NEW; }
            set { _INCREASE_NEW = value; }
        }
        public string LIMIT
        {
            get { return _LIMIT; }
            set { _LIMIT = value; }
        }
        public string LIMIT_NEW
        {
            get { return _LIMIT_NEW; }
            set { _LIMIT_NEW = value; }
        }
        public string NEED
        {
            get { return _NEED; }
            set { _NEED = value; }
        }
        public string NEED_NEW
        {
            get { return _NEED_NEW; }
            set { _NEED_NEW = value; }
        }
        public DateTime ORDERDATE
        {
            get { return _ORDERDATE; }
            set { _ORDERDATE = value; }
        }
        public DateTime ORDERDATE_NEW
        {
            get { return _ORDERDATE_NEW; }
            set { _ORDERDATE_NEW = value; }
        }
        public double ORDERMEDID
        {
            get { return _ORDERMEDID; }
            set { _ORDERMEDID = value; }
        }
        public double ORDERNONMEDID
        {
            get { return _ORDERNONMEDID; }
            set { _ORDERNONMEDID = value; }
        }
        public string PATIENTNAME
        {
            get { return _PATIENTNAME; }
            set { _PATIENTNAME = value; }
        }
        public string QTY
        {
            get { return _QTY; }
            set { _QTY = value; }
        }
        public string QTY_NEW
        {
            get { return _QTY_NEW; }
            set { _QTY_NEW = value; }
        }
        public string REFMEDTABLE
        {
            get { return _REFMEDTABLE; }
            set { _REFMEDTABLE = value; }
        }
        public string REMARKS
        {
            get { return _REMARKS; }
            set { _REMARKS = value; }
        }
        public string REMARKS_NEW
        {
            get { return _REMARKS_NEW; }
            set { _REMARKS_NEW = value; }
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
        public string STATUS_NEW
        {
            get { return _STATUS_NEW; }
            set { _STATUS_NEW = value; }
        }
        public string VN
        {
            get { return _VN; }
            set { _VN = value; }
        }
        public double WARD
        {
            get { return _WARD; }
            set { _WARD = value; }
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

        public double ORDERNO
        {
            get { return _ORDERNO; }
            set { _ORDERNO = value; }
        }
    }
}