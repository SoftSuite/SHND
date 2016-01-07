using System;

namespace SHND.Data.Views
{
    /// <summary>
    /// Represents a V_HOLIDAY data.
    /// [Created by 127.0.0.1 on January,27 2009]
    /// </summary>
    public class VHolidayData
    {
        bool _ACTIVE = false;
        DateTime _HOLIDAY = new DateTime(1, 1, 1);
        double _LOID = 0;
        string _NAME = "";

        public bool ACTIVE
        {
            get { return _ACTIVE; }
            set { _ACTIVE = value; }
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
    }
}