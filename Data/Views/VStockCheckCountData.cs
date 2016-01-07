using System;

namespace SHND.Data.Views
{
    /// <summary>
    /// Represents a V_STOCKCHECKCOUNT_SEARCH data.
    /// [Created by 127.0.0.1 on Febuary,16 2009]
    /// </summary>
    public class VStockCheckCountData
    {
        string _BATCHNO = "";
        string _CHECKDATE = "";
        double _MATERIALCLASS = 0;
        double _MATERIALMASTER = 0;
        string _REMARKS = "";
        double _SCLOID = 0;
        double _SILOID = 0;
        string _STATUS = "";
        string _STATUSNAME = "";
        string _STATUSRANK = "";
        double _WHLOID = 0;
        string _WHNAME = "";

        public string BATCHNO
        {
            get { return _BATCHNO; }
            set { _BATCHNO = value; }
        }
        public string CHECKDATE
        {
            get { return _CHECKDATE; }
            set { _CHECKDATE = value; }
        }
        public double MATERIALCLASS
        {
            get { return _MATERIALCLASS; }
            set { _MATERIALCLASS = value; }
        }
        public double MATERIALMASTER
        {
            get { return _MATERIALMASTER; }
            set { _MATERIALMASTER = value; }
        }
        public string REMARKS
        {
            get { return _REMARKS; }
            set { _REMARKS = value; }
        }
        public double SCLOID
        {
            get { return _SCLOID; }
            set { _SCLOID = value; }
        }
        public double SILOID
        {
            get { return _SILOID; }
            set { _SILOID = value; }
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
        public double WHLOID
        {
            get { return _WHLOID; }
            set { _WHLOID = value; }
        }
        public string WHNAME
        {
            get { return _WHNAME; }
            set { _WHNAME = value; }
        }
    }
}