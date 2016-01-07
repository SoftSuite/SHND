using System;

namespace SHND.Data.Views
{
    /// <summary>
    /// Represents a V_FORMULAFEED_NUTRIENT data.
    /// [Created by 127.0.0.1 on January,8 2009]
    /// </summary>
    public class VFormulafeedNutrientData
    {
        double _ENERGY = 0;
        double _LOID = 0;
        string _NUTRIENTNAME = "";
        double _QTY = 0;
        string _UNITNAME = "";

        public double ENERGY
        {
            get { return _ENERGY; }
            set { _ENERGY = value; }
        }
        public double LOID
        {
            get { return _LOID; }
            set { _LOID = value; }
        }
        public string NUTRIENTNAME
        {
            get { return _NUTRIENTNAME; }
            set { _NUTRIENTNAME = value; }
        }
        public double QTY
        {
            get { return _QTY; }
            set { _QTY = value; }
        }
        public string UNITNAME
        {
            get { return _UNITNAME; }
            set { _UNITNAME = value; }
        }
    }
}