using System;

namespace SHND.Data.Tables
{
    /// <summary>
    /// Represents a WELFAREREALSERVICE data.
    /// [Created by 127.0.0.1 on June,22 2009]
    /// </summary>
    public class WelfareRealServiceData
    {
        double _COUPON = 0;
        string _CREATEBY = "";
        DateTime _CREATEON = new DateTime(1, 1, 1);
        double _DIVISION = 0;
        double _LOID = 0;
        DateTime _SERVICEDATE = new DateTime(1, 1, 1);
        double _TIFFIN = 0;
        string _UPDATEBY = "";
        DateTime _UPDATEON = new DateTime(1, 1, 1);
        double _GETCOUPON = 0;
        double _GETTIFFIN = 0;

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
        public double DIVISION
        {
            get { return _DIVISION; }
            set { _DIVISION = value; }
        }
        public double LOID
        {
            get { return _LOID; }
            set { _LOID = value; }
        }
        public DateTime SERVICEDATE
        {
            get { return _SERVICEDATE; }
            set { _SERVICEDATE = value; }
        }
        public double TIFFIN
        {
            get { return _TIFFIN; }
            set { _TIFFIN = value; }
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
        public double GETCOUPON
        {
            get { return _GETCOUPON; }
            set { _GETCOUPON = value; }
        }
        public double GETTIFFIN
        {
            get { return _GETTIFFIN; }
            set { _GETTIFFIN = value; }
        }
    }
}