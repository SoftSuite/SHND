using System;

namespace SHND.Data.Tables
{
    /// <summary>
    /// Represents a ORDERWELFAREITEM data.
    /// [Created by 127.0.0.1 on January,13 2009]
    /// </summary>
    public class OrderWelfareItemData
    {
        string _CREATEBY = "";
        DateTime _CREATEON = new DateTime(1, 1, 1);
        double _LOID = 0;
        double _ORDERWELFARE = 0;
        double _QTY = 0;
        double _SUBDIVISION = 0;
        string _UPDATEBY = "";
        DateTime _UPDATEON = new DateTime(1, 1, 1);

        public string CREATEBY
        {
            get { return _CREATEBY; }
            set { _CREATEBY = value; }
        }
        public DateTime CREATEON
        {
            get { return _CREATEON; }
            set { _CREATEON = value; }
        }
        public double LOID
        {
            get { return _LOID; }
            set { _LOID = value; }
        }
        public double ORDERWELFARE
        {
            get { return _ORDERWELFARE; }
            set { _ORDERWELFARE = value; }
        }
        public double QTY
        {
            get { return _QTY; }
            set { _QTY = value; }
        }
        public double SUBDIVISION
        {
            get { return _SUBDIVISION; }
            set { _SUBDIVISION = value; }
        }
        public string UPDATEBY
        {
            get { return _UPDATEBY; }
            set { _UPDATEBY = value; }
        }
        public DateTime UPDATEON
        {
            get { return _UPDATEON; }
            set { _UPDATEON = value; }
        }
    }
}