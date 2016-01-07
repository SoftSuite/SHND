using System;

namespace SHND.Data.Tables
{
    /// <summary>
    /// Represents a STOCKINITEM data.
    /// [Created by 127.0.0.1 on Febuary,20 2009]
    /// </summary>
    public class StockinItemData
    {
        string _BRAND = "";
        string _CREATEBY = "";
        DateTime _CREATEON = new DateTime(1, 1, 1);
        double _GUARANTEE = 0;
        double _LOID = 0;
        string _LOTNO = "";
        double _MATERIALMASTER = 0;
        double _PLANREMAINQTY = 0;
        double _PRICE = 0;
        double _QTY = 0;
        double _REFLOID = 0;
        string _REFTABLE = "";
        string _SAPPOCODE = "";
        DateTime _SAPPODATE = new DateTime(1, 1, 1);
        double _SAPWAREHOUSE = 0;
        double _STOCKIN = 0;
        double _UNIT = 0;
        string _UNITNAME = "";
        string _UPDATEBY = "";
        DateTime _UPDATEON = new DateTime(1, 1, 1);
        double _USEQTY = 0;
        double _WASTEQTY = 0;
        string _REMARKS = "";
        double _STOCKOUTQTY = 0;

        public string BRAND
        {
            get { return _BRAND; }
            set { _BRAND = value; }
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
        public double GUARANTEE
        {
            get { return _GUARANTEE; }
            set { _GUARANTEE = value; }
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
        public double PLANREMAINQTY
        {
            get { return _PLANREMAINQTY; }
            set { _PLANREMAINQTY = value; }
        }
        public double PRICE
        {
            get { return _PRICE; }
            set { _PRICE = value; }
        }
        public double QTY
        {
            get { return _QTY; }
            set { _QTY = value; }
        }
        public double REFLOID
        {
            get { return _REFLOID; }
            set { _REFLOID = value; }
        }
        public string REFTABLE
        {
            get { return _REFTABLE; }
            set { _REFTABLE = value; }
        }
        public string SAPPOCODE
        {
            get { return _SAPPOCODE; }
            set { _SAPPOCODE = value; }
        }
        public DateTime SAPPODATE
        {
            get { return _SAPPODATE; }
            set { _SAPPODATE = value; }
        }
        public double SAPWAREHOUSE
        {
            get { return _SAPWAREHOUSE; }
            set { _SAPWAREHOUSE = value; }
        }
        public double STOCKIN
        {
            get { return _STOCKIN; }
            set { _STOCKIN = value; }
        }
        public double UNIT
        {
            get { return _UNIT; }
            set { _UNIT = value; }
        }
        public string UNITNAME
        {
            get { return _UNITNAME; }
            set { _UNITNAME = value; }
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
        public double USEQTY
        {
            get { return _USEQTY; }
            set { _USEQTY = value; }
        }
        public double WASTEQTY
        {
            get { return _WASTEQTY; }
            set { _WASTEQTY = value; }
        }
        public string REMARKS
        {
            get { return _REMARKS; }
            set { _REMARKS = value; }
        }
        public double STOCKOUTQTY
        {
            get { return _STOCKOUTQTY; }
            set { _STOCKOUTQTY = value; }
        }
    }
}