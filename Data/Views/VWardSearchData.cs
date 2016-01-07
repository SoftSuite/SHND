using System;

namespace SHND.Data.Views
{
    /// <summary>
    /// Represents a V_WARD_SEARCH data.
    /// [Created by 127.0.0.1 on January,28 2009]
    /// </summary>
    public class VWardSearchData
    {
        string _ACTIVE = "";
        double _BEDQTY = 0;
        string _CREATEBY = "";
        DateTime _CREATEON = new DateTime(1, 1, 1);
        double _DEFAULTFOODTYPE = 0;
        double _LOID = 0;
        string _NAME = "";
        string _UPDATEBY = "";
        DateTime _UPDATEON = new DateTime(1, 1, 1);
        string _WARDTYPE = "";
       


        public string ACTIVE
        {
            get { return _ACTIVE; }
            set { _ACTIVE = value; }
        }
        public double BEDQTY
        {
            get { return _BEDQTY; }
            set { _BEDQTY = value; }
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
        public double DEFAULTFOODTYPE
        {
            get { return _DEFAULTFOODTYPE; }
            set { _DEFAULTFOODTYPE = value; }
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
        public string WARDTYPE
        {
            get { return _WARDTYPE; }
            set { _WARDTYPE = value; }
        }
        
    }
}