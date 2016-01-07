using System;

namespace SHND.Data.Tables
{
    /// <summary>
    /// Represents a FORMULAFEEDITEM data.
    /// [Created by 127.0.0.1 on January,6 2009]
    /// </summary>
    public class FormularFeedItemData
    {
        string _CREATEBY = "";
        DateTime _CREATEON = new DateTime(1, 1, 1);
        double _ENERGY = 0;
        double _FORMULAFEED = 0;
        double _LOID = 0;
        double _MATERIALMASTER = 0;
        double _QTY = 0;
        double _UNIT = 0;
        string _UPDATEBY = "";
        DateTime _UPDATEON = new DateTime(1, 1, 1);
        double _CARBOHYDRATE = 0;
        double _PROTEIN = 0;
        double _SODIUM = 0;
        double _FAT = 0;

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
        public double ENERGY
        {
            get { return _ENERGY; }
            set { _ENERGY = value; }
        }
        public double FORMULAFEED
        {
            get { return _FORMULAFEED; }
            set { _FORMULAFEED = value; }
        }
        public double LOID
        {
            get { return _LOID; }
            set { _LOID = value; }
        }
        public double MATERIALMASTER
        {
            get { return _MATERIALMASTER; }
            set { _MATERIALMASTER = value; }
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
        public double CARBOHYDRATE
        {
            get { return _CARBOHYDRATE; }
            set { _CARBOHYDRATE = value; }
        }
        public double FAT
        {
            get { return _FAT; }
            set { _FAT = value; }
        }
        public double PROTEIN
        {
            get { return _PROTEIN; }
            set { _PROTEIN = value; }
        }
        public double SODIUM
        {
            get { return _SODIUM; }
            set { _SODIUM = value; }
        }
    }
}