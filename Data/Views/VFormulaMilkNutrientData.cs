using System;

namespace SHND.Data.Views
{
    /// <summary>
    /// Represents a V_FORMULAMILK_NUTRIENT data.
    /// [Created by 127.0.0.1 on Febuary,2 2009]
    /// </summary>
    public class VFormulaMilkNutrientData
    {
        double _LOID = 0;
        string _NUTRIENTNAME = "";
        double _QTY = 0;
        string _UNITNAME = "";

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