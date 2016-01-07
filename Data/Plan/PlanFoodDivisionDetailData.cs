using System;
using System.Collections;
using System.Data;

/// <summary>
/// PlanFoodDivisionDetailData Data Class
/// Version 1.0
/// =========================================================================
/// Create by: Teang
/// Create Date: 11 Feb 2009
/// -------------------------------------------------------------------------
/// Modify By: -
/// Modify From: -
/// Modify Date: -
/// -------------------------------------------------------------------------
/// Remark: -
/// Description:
///    Data Object สำหรับข้อมูลแผนประมาณการของหน่วยงาน
/// Changes:
///    1.0 - สร้าง
/// -------------------------------------------------------------------------
/// =========================================================================
/// </summary>
namespace SHND.Data.Views
{
    public class PlanFoodDivisionDetailData
    {
        double _BUDGETYEAR = 0;
        string _CODE = "";
        double _DIVISION = 0;
        string _DIVISIONNAME = "";
        DateTime _ENDDATE = new DateTime(1, 1, 1);
        bool _ISPLANFOOD = true;
        double _LOID = 0;
        double _MATERIALCLASS = 0;
        string _NAME = "";
        double _PERIODTIME = 0;
        string _PHASE = "";
        string _PHASEYEAR = "";
        DateTime _PLANDATE = new DateTime(1, 1, 1);
        string _QTCODE = "";
        string _REFPRSAP = "";
        DateTime _STARTDATE = new DateTime(1, 1, 1);
        string _STATUS = "";
        string _STATUSNAME = "";
        string _STATUSRANK = "";
        DataTable _MenuByDivision = new DataTable();
        DataTable _MaterialDivision = new DataTable();
        ArrayList _MaterialDivisionList = new ArrayList();

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
        public string PHASEYEAR
        {
            get { return _PHASEYEAR; }
            set { _PHASEYEAR = value; }
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
        public DataTable MenuByDivision
        {
            get { return _MenuByDivision; }
            set { _MenuByDivision = value; }
        }
        public DataTable MaterialDivision
        {
            get { return _MaterialDivision; }
            set { _MaterialDivision = value; }
        }
        public ArrayList MaterialDivisionList
        {
            get { return _MaterialDivisionList; }
            set { _MaterialDivisionList = value; }
        }
    }
}