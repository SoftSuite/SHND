using System;

namespace SHND.Data.Views
{
    /// <summary>
    /// Represents a V_ADMITPATIENT data.
    /// [Created by 127.0.0.1 on May,11 2009]
    /// </summary>
    public class VAdmitPatientData
    {
        DateTime _ADMITDATE = new DateTime(1, 1, 1);
        string _AN = "";
        string _BEDNO = "";
        DateTime _BIRTHDATE = new DateTime(1, 1, 1);
        string _CREATEBY = "";
        DateTime _CREATEON = new DateTime(1, 1, 1);
        string _DIAGNOSIS = "";
        string _DISEASE = "";
        string _DRUGALLERGIC = "";
        string _FOODALLERGIC = "";
        double _HEIGHT = 0;
        string _HN = "";
        double _LOID = 0;
        DateTime _ORDERDATE = new DateTime(1, 1, 1);
        string _PATIENTNAME = "";
        string _ROOMNO = "";
        double _TITLE = 0;
        string _UPDATEBY = "";
        DateTime _UPDATEON = new DateTime(1, 1, 1);
        string _VN = "";
        double _WARD = 0;
        double _WEIGHT = 0;
        double _COST = 0;
        double _MATERIALMASTER = 0;
        string _MATERIALNAME = "";
        double _UNIT = 0;
        string _UNITNAME = "";



        public DateTime ADMITDATE
        {
            get { return _ADMITDATE; }
            set { _ADMITDATE = value; }
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
        public double COST
        {
            get { return _COST; }
            set { _COST = value; }
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
        public string DIAGNOSIS
        {
            get { return _DIAGNOSIS; }
            set { _DIAGNOSIS = value; }
        }
        public string DISEASE
        {
            get { return _DISEASE; }
            set { _DISEASE = value; }
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
        public DateTime ORDERDATE
        {
            get { return _ORDERDATE; }
            set { _ORDERDATE = value; }
        }
        public string PATIENTNAME
        {
            get { return _PATIENTNAME; }
            set { _PATIENTNAME = value; }
        }
        public string ROOMNO
        {
            get { return _ROOMNO; }
            set { _ROOMNO = value; }
        }
        public double TITLE
        {
            get { return _TITLE; }
            set { _TITLE = value; }
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
        public double WEIGHT
        {
            get { return _WEIGHT; }
            set { _WEIGHT = value; }
        }
    }
}