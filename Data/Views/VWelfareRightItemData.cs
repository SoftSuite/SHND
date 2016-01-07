using System;

namespace SHND.Data.Views
{
    /// <summary>
    /// Represents a V_WELFARERIGHTITEM data.
    /// [Created by 127.0.0.1 on August,11 2009]
    /// </summary>
    public class VWelfareRightItemData
    {
        double _DIVISION = 0;
        string _DIVISIONNAME = "";
        string _ISOVER = "";
        double _LOID = 0;
        double _QTY = 0;
        double _QTYRIGHT = 0;
        double _WELFARERIGHT = 0;

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
        public string ISOVER
        {
            get { return _ISOVER; }
            set { _ISOVER = value; }
        }
        public double LOID
        {
            get { return _LOID; }
            set { _LOID = value; }
        }
        public double QTY
        {
            get { return _QTY; }
            set { _QTY = value; }
        }
        public double QTYRIGHT
        {
            get { return _QTYRIGHT; }
            set { _QTYRIGHT = value; }
        }
        public double WELFARERIGHT
        {
            get { return _WELFARERIGHT; }
            set { _WELFARERIGHT = value; }
        }
    }
}