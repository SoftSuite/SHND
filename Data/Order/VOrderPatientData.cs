using System;
using System.Data;

namespace SHND.Data.Order
{
    /// <summary>
    /// Represents a V_ORDER_PATIENT_SEARCH data.
    /// [Created by 127.0.0.1 on March,10 2009]
    /// </summary>
    public class VOrderPatientData
    {
        DateTime _ADMITDATE = new DateTime(1, 1, 1);
        string _AGE = "";
        string _AN = "";
        string _BEDNO = "";
        DateTime _BIRTHDATE = new DateTime(1, 1, 1);
        string _DIAGNOSIS = "";
        string _DRUGALLERGIC = "";
        string _FOODALLERGIC = "";
        double _HEIGHT = 0;
        string _HN = "";
        double _LOID = 0;
        string _PATIENTNAME = "";
        string _PATIENTSTATUS = "";
        string _REMARK = "";
        string _ROOMNO = "";
        string _STATUSNAME = "";
        string _STATUSRANK = "";
        double _TITLE = 0;
        string _TITLENAME = "";
        string _VN = "";
        double _WARD = 0;
        string _WARDNAME = "";
        double _WEIGHT = 0;
        double _DEFAULTFOODTYPE = 0;

        public DateTime ADMITDATE
        {
            get { return _ADMITDATE; }
            set { _ADMITDATE = value; }
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
        public DateTime BIRTHDATE
        {
            get { return _BIRTHDATE; }
            set { _BIRTHDATE = value; }
        }
        public string DIAGNOSIS
        {
            get { return _DIAGNOSIS; }
            set { _DIAGNOSIS = value; }
        }
        public string DRUGALLERGIC
        {
            get { return _DRUGALLERGIC; }
            set { _DRUGALLERGIC = value; }
        }
        public string FOODALLERGIC
        {
            get { return _FOODALLERGIC; }
            set { _FOODALLERGIC = value; }
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
        public double LOID
        {
            get { return _LOID; }
            set { _LOID = value; }
        }
        public string PATIENTNAME
        {
            get { return _PATIENTNAME; }
            set { _PATIENTNAME = value; }
        }
        public string PATIENTSTATUS
        {
            get { return _PATIENTSTATUS; }
            set { _PATIENTSTATUS = value; }
        }
        public string REMARK
        {
            get { return _REMARK; }
            set { _REMARK = value; }
        }
        public string ROOMNO
        {
            get { return _ROOMNO; }
            set { _ROOMNO = value; }
        }
        public string STATUSNAME
        {
            get { return _STATUSNAME; }
            set { _STATUSNAME = value; }
        }
        public string STATUSRANK
        {
            get { return _STATUSRANK; }
            set { _STATUSRANK = value; }
        }
        public double TITLE
        {
            get { return _TITLE; }
            set { _TITLE = value; }
        }
        public string TITLENAME
        {
            get { return _TITLENAME; }
            set { _TITLENAME = value; }
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

        DataTable _ORDERDETAIL = new DataTable();

        public DataTable OrderDetail
        {
            get { return _ORDERDETAIL; }
            set { _ORDERDETAIL = value; }
        }
        public double DEFAULTFOODTYPE
        {
            get { return _DEFAULTFOODTYPE; }
            set { _DEFAULTFOODTYPE = value; }
        }
    }
}