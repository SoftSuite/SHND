using System;
using System.Collections;
using System.Data;

namespace SHND.Data.Plan
{
    /// <summary>
    /// Represents a V_PLAN_TOOLS_SEARCH data.
    /// [Created by 127.0.0.1 on Febuary,16 2009]
    /// </summary>
    public class PlanToolsDetailData
    {
        double _BUDGETYEAR = 0;
        string _CODE = "";
        DateTime _ENDDATE = new DateTime(1, 1, 1);
        bool _ISPLANFOOD = false;
        double _LOID = 0;
        double _MATERIALCLASS = 0;
        string _NAME = "";
        double _PERIODTIME = 0;
        string _PHASE = "";
        DateTime _PLANDATE = new DateTime(1, 1, 1);
        string _QTCODE = "";
        string _REFPRSAP = "";
        DateTime _STARTDATE = new DateTime(1, 1, 1);
        string _STATUS = "";
        string _STATUSNAME = "";
        string _STATUSRANK = "";
        double _AdjPercent = 0;
        ArrayList _PlanToolsItem = new ArrayList();
        ArrayList _PlanToolsDivision = new ArrayList();
        DataTable _PlanToolsTable = new DataTable();

        public double BUDGETYEAR
        {
            get { return _BUDGETYEAR; }
            set { _BUDGETYEAR = value; }
        }
        public string CODE
        {
            get { return _CODE; }
            set { _CODE = value; }
        }
        public DateTime ENDDATE
        {
            get { return _ENDDATE; }
            set { _ENDDATE = value; }
        }
        public bool ISPLANFOOD
        {
            get { return _ISPLANFOOD; }
            set { _ISPLANFOOD = value; }
        }
        public double LOID
        {
            get { return _LOID; }
            set { _LOID = value; }
        }
        public double MATERIALCLASS
        {
            get { return _MATERIALCLASS; }
            set { _MATERIALCLASS = value; }
        }
        public string NAME
        {
            get { return _NAME; }
            set { _NAME = value; }
        }
        public double PERIODTIME
        {
            get { return _PERIODTIME; }
            set { _PERIODTIME = value; }
        }
        public string PHASE
        {
            get { return _PHASE; }
            set { _PHASE = value; }
        }
        public DateTime PLANDATE
        {
            get { return _PLANDATE; }
            set { _PLANDATE = value; }
        }
        public string QTCODE
        {
            get { return _QTCODE; }
            set { _QTCODE = value; }
        }
        public string REFPRSAP
        {
            get { return _REFPRSAP; }
            set { _REFPRSAP = value; }
        }
        public DateTime STARTDATE
        {
            get { return _STARTDATE; }
            set { _STARTDATE = value; }
        }
        public string STATUS
        {
            get { return _STATUS; }
            set { _STATUS = value; }
        }
        public string STATUSNAME
        {
            get { return _STATUSNAME; }
            set { _STATUSNAME = value; }
        }
        public string STATUSRANK
        {
            get { return _STATUSRANK; }
            set { _STATUSRANK = value; }
        }
        public double AdjPercent
        {
            get { return _AdjPercent; }
            set { _AdjPercent = value; }
        }
        public ArrayList PlanToolsItem
        {
            get { return _PlanToolsItem; }
            set { _PlanToolsItem = value; }
        }
        public ArrayList PlanToolsDivision
        {
            get { return _PlanToolsDivision; }
            set { _PlanToolsDivision = value; }
        }
        public DataTable PlanToolsTable
        {
            get { return _PlanToolsTable; }
            set { _PlanToolsTable = value; }
        }
    }
}