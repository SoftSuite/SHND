using System;

namespace SHND.Data.Views
{
    /// <summary>
    /// Represents a V_ORDERDETAIL_ITEM data.
    /// [Created by 127.0.0.1 on March,12 2009]
    /// </summary>
    public class VOrderDetailItemData
    {
        double _DISEASECATEGORY = 0;
        bool _ISHIGH = false;
        bool _ISLOW = false;
        bool _ISNON = false;
        double _QTY = 0;
        double _UNIT = 0;
        string _MEAL = "";

        public double DISEASECATEGORY
        {
            get { return _DISEASECATEGORY; }
            set { _DISEASECATEGORY = value; }
        }
        public bool ISHIGH
        {
            get { return _ISHIGH; }
            set { _ISHIGH = value; }
        }
        public bool ISLOW
        {
            get { return _ISLOW; }
            set { _ISLOW = value; }
        }
        public bool ISNON
        {
            get { return _ISNON; }
            set { _ISNON = value; }
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
        public string MEAL
        {
            get { return _MEAL; }
            set { _MEAL = value; }
        }
    }
}