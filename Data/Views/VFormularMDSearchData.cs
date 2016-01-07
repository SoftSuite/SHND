using System;

namespace SHND.Data.Views
{
    /// <summary>
    /// Represents a V_FORMULAFEED_MD_SEARCH data.
    /// [Created by 127.0.0.1 on January,6 2009]
    /// </summary>
    public class VFormularMDSearchData
    {
        string _ACTIVE = "";
        double _CAPACITY = 0;
        double _ENERGY = 0;
        string _FORMULANAME = "";
        double _LOID = 0;
        double _STRONG = 0;

        public string ACTIVE
        {
            get { return _ACTIVE; }
            set { _ACTIVE = value; }
        }
        public double CAPACITY
        {
            get { return _CAPACITY; }
            set { _CAPACITY = value; }
        }
        public double ENERGY
        {
            get { return _ENERGY; }
            set { _ENERGY = value; }
        }
        public string FORMULANAME
        {
            get { return _FORMULANAME; }
            set { _FORMULANAME = value; }
        }
        public double LOID
        {
            get { return _LOID; }
            set { _LOID = value; }
        }
        public double STRONG
        {
            get { return _STRONG; }
            set { _STRONG = value; }
        }
    }
}