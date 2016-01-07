using System;
using System.Collections;
using SHND.Data.Tables;

namespace SHND.Data.Views
{
    /// <summary>
    /// Represents a V_WELFARERIGHT data.
    /// [Created by 127.0.0.1 on August,11 2009]
    /// </summary>
    public class VWelfareRightData
    {
        double _LOID = 0;
        string _MONTHORDER = "";
        double _QTYDATE = 0;
        string _RIGHTMONTH = "";
        double _RIGHTYEAR = 0;
        private ArrayList _WelfareRightItem = new ArrayList();

        public double LOID
        {
            get { return _LOID; }
            set { _LOID = value; }
        }
        public string MONTHORDER
        {
            get { return _MONTHORDER; }
            set { _MONTHORDER = value; }
        }
        public double QTYDATE
        {
            get { return _QTYDATE; }
            set { _QTYDATE = value; }
        }
        public string RIGHTMONTH
        {
            get { return _RIGHTMONTH; }
            set { _RIGHTMONTH = value; }
        }
        public double RIGHTYEAR
        {
            get { return _RIGHTYEAR; }
            set { _RIGHTYEAR = value; }
        }
        public ArrayList WelfareRightItem
        {
            get { return _WelfareRightItem; }
            set { _WelfareRightItem = value; }
        }
    }
}