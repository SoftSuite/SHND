using System;

namespace SHND.Data.Tables
{
    /// <summary>
    /// Represents a STOCKCHECKITEM data.
    /// [Created by 127.0.0.1 on Febuary,12 2009]
    /// </summary>
    public class StockCheckItemData
    {
        double _COUNTQTY = 0;
        string _CREATEBY = "";
        DateTime _CREATEON = new DateTime(1, 1, 1);
        double _IMPROVEQTY = 0;
        string _ISIMPROVE = "";
        double _LOID = 0;
        string _LOTNO = "";
        double _MATERIALMASTER = 0;
        double _STOCKCHECK = 0;
        double _STOCKQTY = 0;
        string _UPDATEBY = "";
        DateTime _UPDATEON = new DateTime(1, 1, 1);

        public double COUNTQTY
        {
            get { return _COUNTQTY; }
            set { _COUNTQTY = value; }
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
        public double IMPROVEQTY
        {
            get { return _IMPROVEQTY; }
            set { _IMPROVEQTY = value; }
        }
        public string ISIMPROVE
        {
            get { return _ISIMPROVE; }
            set { _ISIMPROVE = value; }
        }
        public double LOID
        {
            get { return _LOID; }
            set { _LOID = value; }
        }
        public string LOTNO
        {
            get { return _LOTNO; }
            set { _LOTNO = value; }
        }
        public double MATERIALMASTER
        {
            get { return _MATERIALMASTER; }
            set { _MATERIALMASTER = value; }
        }
        public double STOCKCHECK
        {
            get { return _STOCKCHECK; }
            set { _STOCKCHECK = value; }
        }
        public double STOCKQTY
        {
            get { return _STOCKQTY; }
            set { _STOCKQTY = value; }
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