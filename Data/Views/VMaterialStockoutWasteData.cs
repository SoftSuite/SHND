using System;

namespace SHND.Data.Views
{
    /// <summary>
    /// Represents a V_MATERIAL_STOCKOUTWASTE_POPUP data.
    /// [Created by 127.0.0.1 on May,22 2009]
    /// </summary>
    public class VMaterialStockoutWasteData
    {
        double _CLASSLOID = 0;
        double _GROUPLOID = 0;
        string _MATERIALCODE = "";
        double _MATERIALMASTER = 0;
        string _MATERIALNAME = "";
        double _PLANORDER = 0;
        double _QTY = 0;
        double _UNIT = 0;
        string _UNITNAME = "";
        double _WAREHOUSE = 0;

        public double CLASSLOID
        {
            get { return _CLASSLOID; }
            set { _CLASSLOID = value; }
        }
        public double GROUPLOID
        {
            get { return _GROUPLOID; }
            set { _GROUPLOID = value; }
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
        public double PLANORDER
        {
            get { return _PLANORDER; }
            set { _PLANORDER = value; }
        }
        public double QTY
        {
            get { return _QTY; }
            set { _QTY = value; }
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
        public double WAREHOUSE
        {
            get { return _WAREHOUSE; }
            set { _WAREHOUSE = value; }
        }
    }
}