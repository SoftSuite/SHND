using System;

namespace SHND.Data.Views
{
    /// <summary>
    /// Represents a V_PREPO_RECEIVE data.
    /// [Created by 127.0.0.1 on April,2 2009]
    /// </summary>
    public class VPrePOReceiveData
    {
        string _ISVAT = "";
        double _MATERIALMASTER = 0;
        string _MATERIALNAME = "";
        double _PLANREMAINQTY = 0;
        double _PREPO = 0;
        double _PRICE = 0;
        double _RECEIVEQTY = 0;
        string _SPEC = "";
        double _UNIT = 0;
        string _UNITNAME = "";
        double _USEDQTY = 0;

        public string ISVAT
        {
            get { return _ISVAT; }
            set { _ISVAT = value; }
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
        public double PLANREMAINQTY
        {
            get { return _PLANREMAINQTY; }
            set { _PLANREMAINQTY = value; }
        }
        public double PREPO
        {
            get { return _PREPO; }
            set { _PREPO = value; }
        }
        public double PRICE
        {
            get { return _PRICE; }
            set { _PRICE = value; }
        }
        public double RECEIVEQTY
        {
            get { return _RECEIVEQTY; }
            set { _RECEIVEQTY = value; }
        }
        public string SPEC
        {
            get { return _SPEC; }
            set { _SPEC = value; }
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
        public double USEDQTY
        {
            get { return _USEDQTY; }
            set { _USEDQTY = value; }
        }
    }
}