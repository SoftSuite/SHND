using System;

namespace SHND.Data.Tables
{
    /// <summary>
    /// Represents a PLANTOOLSDIVISION data.
    /// [Created by 127.0.0.1 on Febuary,16 2009]
    /// </summary>
    public class PlanToolsDivisionData
    {
        double _ADJQTY = 0;
        string _CREATEBY = "";
        DateTime _CREATEON = new DateTime(1, 1, 1);
        double _DIVISION = 0;
        double _LOID = 0;
        double _PLANORDERDIVISION = 0;
        double _PLANTOOLSITEM = 0;
        double _REQQTY = 0;
        string _STATUS = "";
        string _UPDATEBY = "";
        DateTime _UPDATEON = new DateTime(1, 1, 1);

        public double ADJQTY
        {
            get { return _ADJQTY; }
            set { _ADJQTY = value; }
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
        public double DIVISION
        {
            get { return _DIVISION; }
            set { _DIVISION = value; }
        }
        public double LOID
        {
            get { return _LOID; }
            set { _LOID = value; }
        }
        public double PLANORDERDIVISION
        {
            get { return _PLANORDERDIVISION; }
            set { _PLANORDERDIVISION = value; }
        }
        public double PLANTOOLSITEM
        {
            get { return _PLANTOOLSITEM; }
            set { _PLANTOOLSITEM = value; }
        }
        public double REQQTY
        {
            get { return _REQQTY; }
            set { _REQQTY = value; }
        }
        public string STATUS
        {
            get { return _STATUS; }
            set { _STATUS = value; }
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