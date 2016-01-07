using System;

namespace SHND.Data.Views
{
    /// <summary>
    /// Represents a V_FORMULAMILK_SEARCH data.
    /// [Created by 127.0.0.1 on January,16 2009]
    /// </summary>
    public class VFormulaMilkData
    {
        string _ACTIVE = "";
        double _ENERGY = 0;
        string _FORMULANAME = "";
        double _LOID = 0;

        public string ACTIVE
        {
            get { return _ACTIVE; }
            set { _ACTIVE = value; }
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
    }
}