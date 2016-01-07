using System;

namespace SHND.Data.Admin
{
    /// <summary>
    /// Represents a CUTOFFTIME data.
    /// [Created by 127.0.0.1 on July,15 2009]
    /// </summary>
    public class CutOffTimeData
    {
        string _BREAKFASTTIME = "";
        string _DINNERTIME = "";
        double _LOID = 0;
        string _LUNCHTIME = "";
        string _USEFOR = "";

        public string BREAKFASTTIME
        {
            get { return _BREAKFASTTIME; }
            set { _BREAKFASTTIME = value; }
        }
        public string DINNERTIME
        {
            get { return _DINNERTIME; }
            set { _DINNERTIME = value; }
        }
        public double LOID
        {
            get { return _LOID; }
            set { _LOID = value; }
        }
        public string LUNCHTIME
        {
            get { return _LUNCHTIME; }
            set { _LUNCHTIME = value; }
        }
        public string USEFOR
        {
            get { return _USEFOR; }
            set { _USEFOR = value; }
        }
    }
}