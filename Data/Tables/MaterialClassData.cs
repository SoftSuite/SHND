using System;

namespace SHND.Data.Tables
{
    /// <summary>
    /// Represents a MATERIALCLASS data.
    /// [Created by 127.0.0.1 on January,22 2009]
    /// </summary>
    public class MaterialClassData
    {
        bool _ACTIVE = true;
        string _CODE = "";
        string _CREATEBY = "";
        DateTime _CREATEON = new DateTime(1, 1, 1);
        double _LOID = 0;
        string _MASTERTYPE = "";
        string _NAME = "";
        string _STOCKINTYPE = "";
        string _UPDATEBY = "";
        DateTime _UPDATEON = new DateTime(1, 1, 1);

        public bool ACTIVE
        {
            get { return _ACTIVE; }
            set { _ACTIVE = value; }
        }
        public string CODE
        {
            get { return _CODE; }
            set { _CODE = value; }
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
        public double LOID
        {
            get { return _LOID; }
            set { _LOID = value; }
        }
        public string MASTERTYPE
        {
            get { return _MASTERTYPE; }
            set { _MASTERTYPE = value; }
        }
        public string NAME
        {
            get { return _NAME; }
            set { _NAME = value; }
        }
        public string STOCKINTYPE
        {
            get { return _STOCKINTYPE; }
            set { _STOCKINTYPE = value; }
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