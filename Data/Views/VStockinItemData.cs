using System;

namespace SHND.Data.Views
{
    /// <summary>
    /// Represents a V_STOCKINITEM data.
    /// [Created by 127.0.0.1 on March,3 2009]
    /// </summary>
    public class VStockinItemData
    {
        string _BRAND = "";
        double _GUARANTEE = 0;
        double _LOID = 0;
        string _LOTNO = "";
        string _MATERIALCODE = "";
        double _MATERIALMASTER = 0;
        string _MATERIALNAME = "";
        double _PRICE = 0;
        double _QTY = 0;
        string _REMARKS = "";
        string _SAPPOCODE = "";
        DateTime _SAPPODATE = new DateTime(1, 1, 1);
        double _SAPWAREHOUSE = 0;
        double _STOCKIN = 0;
        double _UNIT = 0;
        string _UNITNAME = "";
        string _WARECODE = "";
        string _WARENAME = "";
        double _WASTEQTY = 0;
        double _STOCKOUTQTY = 0;

        public string BRAND
        {
            get { return _BRAND; }
            set { _BRAND = value; }
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
        public string MATERIALCODE
        {
            get { return _MATERIALCODE; }
            set { _MATERIALCODE = value; }
        }
        public double MATERIALMASTER
        {
            get { return _MATERIALMASTER; }
            set { _MATERIALMASTER = value; }
        }
        public string MATERIALNAME
        {
            get { return _MATERIALNAME; }
            set { _MATERIALNAME = value; }
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
        public string REMARKS
        {
            get { return _REMARKS; }
            set { _REMARKS = value; }
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
        public string WARECODE
        {
            get { return _WARECODE; }
            set { _WARECODE = value; }
        }
        public string WARENAME
        {
            get { return _WARENAME; }
            set { _WARENAME = value; }
        }
        public double WASTEQTY
        {
            get { return _WASTEQTY; }
            set { _WASTEQTY = value; }
        }
        public double STOCKOUTQTY
        {
            get { return _STOCKOUTQTY; }
            set { _STOCKOUTQTY = value; }
        }
    }
}