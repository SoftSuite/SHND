using System;

namespace SHND.Data.Tables
{
    /// <summary>
    /// Represents a HOLIDAY data.
    /// [Created by 127.0.0.1 on January,27 2009]
    /// </summary>
    public class HolidayData
    {
        string _ACTIVE = "";
        string _CREATEBY = "";
        DateTime _CREATEON = new DateTime(1, 1, 1);
        DateTime _HOLIDAY = new DateTime(1, 1, 1);
        double _LOID = 0;
        string _NAME = "";
        string _UPDATEBY = "";
        DateTime _UPDATEON = new DateTime(1, 1, 1);

        public string ACTIVE
        {
            get { return _ACTIVE; }
            set { _ACTIVE = value; }
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
        public DateTime HOLIDAY
        {
            get { return _HOLIDAY; }
            set { _HOLIDAY = value; }
        }
        public double LOID
        {
            get { return _LOID; }
            set { _LOID = value; }
        }
        public string NAME
        {
            get { return _NAME; }
            set { _NAME = value; }
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