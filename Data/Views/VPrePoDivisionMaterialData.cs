using System;

namespace SHND.Data.Views
{
    /// <summary>
    /// Represents a V_PREPODIVISION_MATERIAL data.
    /// [Created by 127.0.0.1 on July,3 2009]
    /// </summary>
    public class VPrePoDivisionMaterialData
    {
        double _DIVISION = 0;
        string _DIVISIONNAME = "";
        string _GROUPNAME = "";
        double _MATERIALCLASS = 0;
        string _MATERIALCLASSNAME = "";
        double _MATERIALGROUP = 0;
        double _MATERIALMASTER = 0;
        string _MATERIALNAME = "";
        double _MENUQTY = 0;
        double _ORDERQTY = 0;
        double _PLANMATERIALCLASS = 0;
        double _PLANORDER = 0;
        double _UNIT = 0;
        string _UNITNAME = "";
        DateTime _USEDATE = new DateTime(1, 1, 1);

        public double DIVISION
        {
            get { return _DIVISION; }
            set { _DIVISION = value; }
        }
        public string DIVISIONNAME
        {
            get { return _DIVISIONNAME; }
            set { _DIVISIONNAME = value; }
        }
        public string GROUPNAME
        {
            get { return _GROUPNAME; }
            set { _GROUPNAME = value; }
        }
        public double MATERIALCLASS
        {
            get { return _MATERIALCLASS; }
            set { _MATERIALCLASS = value; }
        }
        public string MATERIALCLASSNAME
        {
            get { return _MATERIALCLASSNAME; }
            set { _MATERIALCLASSNAME = value; }
        }
        public double MATERIALGROUP
        {
            get { return _MATERIALGROUP; }
            set { _MATERIALGROUP = value; }
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
        public double MENUQTY
        {
            get { return _MENUQTY; }
            set { _MENUQTY = value; }
        }
        public double ORDERQTY
        {
            get { return _ORDERQTY; }
            set { _ORDERQTY = value; }
        }
        public double PLANMATERIALCLASS
        {
            get { return _PLANMATERIALCLASS; }
            set { _PLANMATERIALCLASS = value; }
        }
        public double PLANORDER
        {
            get { return _PLANORDER; }
            set { _PLANORDER = value; }
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
        public DateTime USEDATE
        {
            get { return _USEDATE; }
            set { _USEDATE = value; }
        }
    }
}