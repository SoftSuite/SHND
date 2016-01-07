using System;

namespace SHND.Data.Views
{
    /// <summary>
    /// Represents a V_RETURNREQUEST_POPUP data.
    /// [Created by 127.0.0.1 on March,2 2009]
    /// </summary>
    public class VRetrunRequestPopupData
    {
        double _DIVISION = 0;
        double _MATERIALMASTER = 0;
        string _MATERIALNAME = "";
        double _QTY = 0;
        double _UNIT = 0;
        string _UNITNAME = "";
        string _MATERIALCODE = "";
        double _QTYWASTE = 0;

        public double DIVISION
        {
            get { return _DIVISION; }
            set { _DIVISION = value; }
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
        public string MATERIALCODE
        {
            get { return _MATERIALCODE; }
            set { _MATERIALCODE = value; }
        }
        public double QTYWASTE
        {
            get { return _QTYWASTE; }
            set { _QTYWASTE = value; }
        }
    }
}