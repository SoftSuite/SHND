using System;

namespace SHND.Data.Views
{
    /// <summary>
    /// Represents a V_CUTORDER_SEARCH data.
    /// [Created by 127.0.0.1 on May,12 2009]
    /// </summary>
    public class VCutOrderSearchData
    {
        string _CODE = "";
        double _DIVISION = 0;
        string _DIVISIONNAME = "";
        string _DOCNAME = "";
        double _DOCTYPE = 0;
        double _LOID = 0;
        string _STATUS = "";
        string _STATUSNAME = "";
        DateTime _STOCKOUTDATE = new DateTime(1, 1, 1);
        DateTime _USEDATE = new DateTime(1, 1, 1);

        public string CODE
        {
            get { return _CODE; }
            set { _CODE = value; }
        }
        public double DIVISION
        {
            get { return _DIVISION; }
            set { _DIVISION = value; }
        }
        public string DIVISIONNAME
        {
            get { return _DIVISIONNAME; }
            set { _DIVISIONNAME = value; }
        }
        public string DOCNAME
        {
            get { return _DOCNAME; }
            set { _DOCNAME = value; }
        }
        public double DOCTYPE
        {
            get { return _DOCTYPE; }
            set { _DOCTYPE = value; }
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
        public DateTime STOCKOUTDATE
        {
            get { return _STOCKOUTDATE; }
            set { _STOCKOUTDATE = value; }
        }
        public DateTime USEDATE
        {
            get { return _USEDATE; }
            set { _USEDATE = value; }
        }
    }
}