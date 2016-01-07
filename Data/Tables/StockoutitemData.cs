using System;
using System.Collections.Generic;
using System.Text;

namespace SHND.Data.Tables
{
    /// <summary>
    /// Represents a STOCKOUTITEM data.
    /// [Created by 127.0.0.1 on Febuary,12 2009]
    /// </summary>
    public class StockoutitemData
    {
        double _RANK = 0;
        string _CREATEBY = "";
        DateTime _CREATEON = new DateTime(1, 1, 1);
        DateTime _FINISHDATE = new DateTime(1, 1, 1);
        double _FLOOR = 0;
        string _ISMENU = "";
        string _ITEMNAME = "";
        double _LOID = 0;
        string _LOTNO = "";
        double _MATERIALMASTER = 0;
        double _PRICE = 0;
        double _QTY = 0;
        string _REMARKS = "";
        string _REPAIRBY = "";
        string _REPAIRREMARKS = "";
        string _REPAIRSTATUS = "";
        double _REQQTY = 0;
        string _STATUS = "";
        double _STOCKOUT = 0;
        double _UNIT = 0;
        string _UPDATEBY = "";
        DateTime _UPDATEON = new DateTime(1, 1, 1);
        double _USEQTY = 0;

        public double RANK
        {
            get { return _RANK; }
            set { _RANK = value; }
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
        public DateTime FINISHDATE
        {
            get { return _FINISHDATE; }
            set { _FINISHDATE = value; }
        }
        public double FLOOR
        {
            get { return _FLOOR; }
            set { _FLOOR = value; }
        }
        public string ISMENU
        {
            get { return _ISMENU; }
            set { _ISMENU = value; }
        }
        public string ITEMNAME
        {
            get { return _ITEMNAME; }
            set { _ITEMNAME = value; }
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
        public string REPAIRBY
        {
            get { return _REPAIRBY; }
            set { _REPAIRBY = value; }
        }
        public string REPAIRREMARKS
        {
            get { return _REPAIRREMARKS; }
            set { _REPAIRREMARKS = value; }
        }
        public string REPAIRSTATUS
        {
            get { return _REPAIRSTATUS; }
            set { _REPAIRSTATUS = value; }
        }
        public double REQQTY
        {
            get { return _REQQTY; }
            set { _REQQTY = value; }
        }
        public string STATUS
        {
            get { return _STATUS; }
            set { _STATUS = value; }
        }
        public double STOCKOUT
        {
            get { return _STOCKOUT; }
            set { _STOCKOUT = value; }
        }
        public double UNIT
        {
            get { return _UNIT; }
            set { _UNIT = value; }
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
    }
}
