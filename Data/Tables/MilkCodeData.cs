using System;

namespace SHND.Data.Tables
{
    /// <summary>
    /// Represents a MILKCODE data.
    /// [Created by 127.0.0.1 on January,28 2009]
    /// </summary>
    public class MilkCodeData
    {
        string _CREATEBY = "";
        DateTime _CREATEON = new DateTime(1, 1, 1);
        double _LOID = 0;
        string _MILKCODE = "";
        string _UPDATEBY = "";
        DateTime _UPDATEON = new DateTime(1, 1, 1);
        double _WARD = 0;

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
        public string MILKCODE
        {
            get { return _MILKCODE; }
            set { _MILKCODE = value; }
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