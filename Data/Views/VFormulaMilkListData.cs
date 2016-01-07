using System;

namespace SHND.Data.Views
{
    /// <summary>
    /// Represents a V_FORMULAMILK_LIST data.
    /// [Created by 127.0.0.1 on Febuary,2 2009]
    /// </summary>
    public class VFormulaMilkListData
    {
        double _ENERGY = 0;
        double _FMILOID = 0;
        double _FMLOID = 0;
        string _MATERIALNAME = "";
        double _MMLOID = 0;
        double _QTY = 0;
        string _UNITNAME = "";
        double _UULOID = 0;

        public double ENERGY
        {
            get { return _ENERGY; }
            set { _ENERGY = value; }
        }
        public double FMILOID
        {
            get { return _FMILOID; }
            set { _FMILOID = value; }
        }
        public double FMLOID
        {
            get { return _FMLOID; }
            set { _FMLOID = value; }
        }
        public string MATERIALNAME
        {
            get { return _MATERIALNAME; }
            set { _MATERIALNAME = value; }
        }
        public double MMLOID
        {
            get { return _MMLOID; }
            set { _MMLOID = value; }
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
        public double UULOID
        {
            get { return _UULOID; }
            set { _UULOID = value; }
        }
    }
}