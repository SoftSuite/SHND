using System;

namespace SHND.Data.Tables
{
    /// <summary>
    /// Represents a MEDFEEDCHARGE data.
    /// [Created by 127.0.0.1 on May,14 2009]
    /// </summary>
    public class MedFeedChargeData
    {
        DateTime _CHARGEDATE = new DateTime(1, 1, 1);
        string _CODE = "";
        string _CREATEBY = "";
        DateTime _CREATEON = new DateTime(1, 1, 1);
        double _LOID = 0;
        string _STATUS = "";
        string _UPDATEBY = "";
        DateTime _UPDATEON = new DateTime(1, 1, 1);
        double _WARD = 0;

        public DateTime CHARGEDATE
        {
            get { return _CHARGEDATE; }
            set { _CHARGEDATE = value; }
        }
        public string CODE
        {
            get { return _CODE; }
            set { _CODE = value; }
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
        public double LOID
        {
            get { return _LOID; }
            set { _LOID = value; }
        }
        public string STATUS
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
        public double WARD
        {
            get { return _WARD; }
            set { _WARD = value; }
        }
    }
}