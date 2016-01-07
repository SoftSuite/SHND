using System;
using System.Collections.Generic;
using System.Text;

namespace SHND.Data.Tables
{
    /// <summary>
    /// Represents a STDMENUDISEASE data.
    /// [Created by 127.0.0.1 on January,16 2009]
    /// </summary>
    public class MenuDiseaseData
    {
        string _CREATEBY = "";
        DateTime _CREATEON = new DateTime(1, 1, 1);
        double _DISEASECATEGORY = 0;
        double _LOID = 0;
        double _MENU = 0;
        string _UPDATEBY = "";
        DateTime _UPDATEON = new DateTime(1, 1, 1);
        string _ISHIGH = "";
        string _ISLOW = "";
        string _ISNON = "";


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
        public double DISEASECATEGORY
        {
            get { return _DISEASECATEGORY; }
            set { _DISEASECATEGORY = value; }
        }
        public double LOID
        {
            get { return _LOID; }
            set { _LOID = value; }
        }
        public double MENU
        {
            get { return _MENU; }
            set { _MENU = value; }
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
        public string ISHIGH
        {
            get { return _ISHIGH; }
            set { _ISHIGH = value; }
        }
        public string ISLOW
        {
            get { return _ISLOW; }
            set { _ISLOW = value; }
        }
        public string ISNON
        {
            get { return _ISNON; }
            set { _ISNON = value; }
        }
    }
}