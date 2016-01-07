using System;

namespace SHND.Data.Views
{
    /// <summary>
    /// Represents a V_ORDERSET_SLIP data.
    /// [Created by 127.0.0.1 on April,21 2009]
    /// </summary>
    public class VOrderSetSlipData
    {
        string _ABSTAIN = "";
        string _AGE = "";
        string _AN = "";
        string _BEDNO = "";
        string _BMI = "";
        string _CONTROL = "";
        double _FOODCATEGORY = 0;
        string _FOODCATEGORYNAME = "";
        double _FOODTYPE = 0;
        string _FOODTYPENAME = "";
        string _HN = "";
        string _IMGURL = "";
        string _INCREASE = "";
        string _LIMIT = "";
        double _LOID = 0;
        string _MEALNAME = "";
        string _NEED = "";
        DateTime _ORDERDATE = new DateTime(1, 1, 1);
        double _ORDERMEDICALSETID = 0;
        double _ORDERNONMEDICALID = 0;
        string _PATIENTNAME = "";
        DateTime _REGISTERDATE = new DateTime(1, 1, 1);
        string _REMARKS = "";
        string _ROOMNO = "";
        string _VN = "";
        double _WARDID = 0;
        string _WARDNAME = "";
        Byte _photo = new Byte();

        public string ABSTAIN
        {
            get { return _ABSTAIN; }
            set { _ABSTAIN = value; }
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
        public double FOODCATEGORY
        {
            get { return _FOODCATEGORY; }
            set { _FOODCATEGORY = value; }
        }
        public string FOODCATEGORYNAME
        {
            get { return _FOODCATEGORYNAME; }
            set { _FOODCATEGORYNAME = value; }
        }
        public double FOODTYPE
        {
            get { return _FOODTYPE; }
            set { _FOODTYPE = value; }
        }
        public string FOODTYPENAME
        {
            get { return _FOODTYPENAME; }
            set { _FOODTYPENAME = value; }
        }
        public string HN
        {
            get { return _HN; }
            set { _HN = value; }
        }
        public string IMGURL
        {
            get { return _IMGURL; }
            set { _IMGURL = value; }
        }
        public string INCREASE
        {
            get { return _INCREASE; }
            set { _INCREASE = value; }
        }
        public string LIMIT
        {
            get { return _LIMIT; }
            set { _LIMIT = value; }
        }
        public double LOID
        {
            get { return _LOID; }
            set { _LOID = value; }
        }
        public string MEALNAME
        {
            get { return _MEALNAME; }
            set { _MEALNAME = value; }
        }
        public string NEED
        {
            get { return _NEED; }
            set { _NEED = value; }
        }
        public DateTime ORDERDATE
        {
            get { return _ORDERDATE; }
            set { _ORDERDATE = value; }
        }
        public double ORDERMEDICALSETID
        {
            get { return _ORDERMEDICALSETID; }
            set { _ORDERMEDICALSETID = value; }
        }
        public double ORDERNONMEDICALID
        {
            get { return _ORDERNONMEDICALID; }
            set { _ORDERNONMEDICALID = value; }
        }
        public string PATIENTNAME
        {
            get { return _PATIENTNAME; }
            set { _PATIENTNAME = value; }
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
        public string ROOMNO
        {
            get { return _ROOMNO; }
            set { _ROOMNO = value; }
        }
        public string VN
        {
            get { return _VN; }
            set { _VN = value; }
        }
        public double WARDID
        {
            get { return _WARDID; }
            set { _WARDID = value; }
        }
        public string WARDNAME
        {
            get { return _WARDNAME; }
            set { _WARDNAME = value; }
        }

        public Byte PHOTO
        {
            get { return _photo; }
            set { _photo = value; }
        }
    }
}