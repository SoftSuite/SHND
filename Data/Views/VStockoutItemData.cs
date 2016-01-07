using System;

namespace SHND.Data.Views
{
    /// <summary>
    /// Represents a V_STOCKOUTITEM data.
    /// [Created by 127.0.0.1 on Febuary,12 2009]
    /// </summary>
    public class VStockoutItemData
    {
        DateTime _FINISHDATE = new DateTime(1, 1, 1);
        double _FLOOR = 0;
        string _ISMENU = "";
        string _ITEMNAME = "";
        double _LOID = 0;
        string _LOTNO = "";
        double _MATERIALMASTER = 0;
        string _MATERIALNAME = "";
        double _PRICE = 0;
        double _QTY = 0;
        string _REMARKS = "";
        string _REPAIRBY = "";
        string _REPAIRREMARKS = "";
        string _REPAIRSTATUS = "";
        double _REQQTY = 0;
        string _SAPCODE = "";
        string _STATUS = "";
        double _STOCKOUT = 0;
        double _UNIT = 0;
        string _UNITNAME = "";

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
        public string SAPCODE
        {
            get { return _SAPCODE; }
            set { _SAPCODE = value; }
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
        public string UNITNAME
        {
            get { return _UNITNAME; }
            set { _UNITNAME = value; }
        }
    }
}