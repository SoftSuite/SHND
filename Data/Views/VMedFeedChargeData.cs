using System;

namespace SHND.Data.Views
{
    /// <summary>
    /// Represents a V_MEDFEEDCHARGE_SEARCH data.
    /// [Created by 127.0.0.1 on May,11 2009]
    /// </summary>
    public class VMedFeedChargeData
    {
        DateTime _CHARGEDATE = new DateTime(1, 1, 1);
        string _CODE = "";
        double _LOID = 0;
        string _STATUS = "";
        string _STATUSNAME = "";
        string _STATUSRANK = "";
        double _WARD = 0;
        string _WARDNAME = "";

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
    }
}