using System;

namespace SHND.Data.Views
{
    /// <summary>
    /// Represents a V_NUTRIENT data.
    /// [Created by 127.0.0.1 on Febuary,5 2009]
    /// </summary>
    public class VNutrientData
    {
        string _ACTIVE = "";
        string _CODE = "";
        double _LOID = 0;
        string _NAME = "";
        double _UNITLOID = 0;
        string _UNITNAME = "";

        public string ACTIVE
        {
            get { return _ACTIVE; }
            set { _ACTIVE = value; }
        }
        public string CODE
        {
            get { return _CODE; }
            set { _CODE = value; }
        }
        public double LOID
        {
            get { return _LOID; }
            set { _LOID = value; }
        }
        public string NAME
        {
            get { return _NAME; }
            set { _NAME = value; }
        }
        public double UNITLOID
        {
            get { return _UNITLOID; }
            set { _UNITLOID = value; }
        }
        public string UNITNAME
        {
            get { return _UNITNAME; }
            set { _UNITNAME = value; }
        }
    }
}