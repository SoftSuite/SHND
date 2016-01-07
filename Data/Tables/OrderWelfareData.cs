using System;

namespace SHND.Data.Tables
{
    /// <summary>
    /// Represents a ORDERWELFARE data.
    /// [Created by 127.0.0.1 on January,9 2009]
    /// </summary>
    public class OrderWelfareData
    {
        double _COUPON = 0;
        string _CREATEBY = "";
        DateTime _CREATEON = new DateTime(1, 1, 1);
        string _DESCRIPTION = "";
        double _DIVISION = 0;
        DateTime _FINISHDATE = new DateTime(1, 1, 1);
        double _LOID = 0;
        string _ORDERCODE = "";
        DateTime _ORDERDATE = new DateTime(1, 1, 1);
        string _REFCODE = "";
        DateTime _REFDATE = new DateTime(1, 1, 1);
        DateTime _STARTDATE = new DateTime(1, 1, 1);
        string  _STATUS = "";
        string _UPDATEBY = "";
        DateTime _UPDATEON = new DateTime(1, 1, 1);

        public double COUPON
        {
            get { return _COUPON; }
            set { _COUPON = value; }
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
        public string DESCRIPTION
        {
            get { return _DESCRIPTION; }
            set { _DESCRIPTION = value; }
        }
        public double DIVISION
        {
            get { return _DIVISION; }
            set { _DIVISION = value; }
        }
        public DateTime FINISHDATE
        {
            get { return _FINISHDATE; }
            set { _FINISHDATE = value; }
        }
        public double LOID
        {
            get { return _LOID; }
            set { _LOID = value; }
        }
        public string ORDERCODE
        {
            get { return _ORDERCODE; }
            set { _ORDERCODE = value; }
        }
        public DateTime ORDERDATE
        {
            get { return _ORDERDATE; }
            set { _ORDERDATE = value; }
        }
        public string REFCODE
        {
            get { return _REFCODE; }
            set { _REFCODE = value; }
        }
        public DateTime REFDATE
        {
            get { return _REFDATE; }
            set { _REFDATE = value; }
        }
        public DateTime STARTDATE
        {
            get { return _STARTDATE; }
            set { _STARTDATE = value; }
        }
        public string  STATUS
        {
            get { return _STATUS; }
            set { _STATUS = value; }
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
    }
}