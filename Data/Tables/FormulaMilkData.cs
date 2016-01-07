using System;

namespace SHND.Data.Tables
{
    /// <summary>
    /// Represents a FORMULAMILK data.
    /// [Created by 127.0.0.1 on January,19 2009]
    /// </summary>
    public class FormulaMilkData
    {
        string _ACTIVE = "";
        string _CREATEBY = "";
        DateTime _CREATEON = new DateTime(1, 1, 1);
        double _ENERGY = 0;
        double _LOID = 0;
        double _MILKCAPACITY = 0;
        double _MILKCATEGORY = 0;
        string _NAME = "";
        string _UPDATEBY = "";
        DateTime _UPDATEON = new DateTime(1, 1, 1);
        double _CAPACITY = 0;

        public string ACTIVE
        {
            get { return _ACTIVE; }
            set { _ACTIVE = value; }
        }
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
        public double LOID
        {
            get { return _LOID; }
            set { _LOID = value; }
        }
        public double MILKCAPACITY
        {
            get { return _MILKCAPACITY; }
            set { _MILKCAPACITY = value; }
        }
        public double MILKCATEGORY
        {
            get { return _MILKCATEGORY; }
            set { _MILKCATEGORY = value; }
        }
        public string NAME
        {
            get { return _NAME; }
            set { _NAME = value; }
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

        public double CAPACITY
        {
            get { return _CAPACITY; }
            set { _CAPACITY = value; }
        }
    }
}