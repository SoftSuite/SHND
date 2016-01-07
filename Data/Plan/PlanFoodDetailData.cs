using System;
using System.Collections;
using System.Data;

/// <summary>
/// VPlanFoodSearchData Data Class
/// Version 1.0
/// =========================================================================
/// Create by: Teang
/// Create Date: 27 Jan 2009
/// -------------------------------------------------------------------------
/// Modify By: -
/// Modify From: -
/// Modify Date: -
/// -------------------------------------------------------------------------
/// Remark: -
/// Description:
///    Data Object สำหรับข้อมูลแผนประมาณการ
/// Changes:
///    1.0 - สร้าง
/// -------------------------------------------------------------------------
/// =========================================================================
/// </summary>
namespace SHND.Data.Plan
{
    public class PlanFoodDetailData
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
        double _AdjPercent = 0;
        ArrayList _ArrMaterialItem = new ArrayList();
        ArrayList _ArrMaterialCouncil = new ArrayList();
        ArrayList _ArrMaterialDivision = new ArrayList();
        ArrayList _ArrMaterialClass = new ArrayList();
        DataTable _MaterialClassTable = new DataTable();
        DataTable _MaterialItemTable = new DataTable();

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
        public ArrayList ArrMaterialMaster
        {
            get { return _ArrMaterialItem; }
            set { _ArrMaterialItem = value; }
        }
        public ArrayList ArrMaterialCouncil
        {
            get { return _ArrMaterialCouncil; }
            set { _ArrMaterialCouncil = value; }
        }
        public double AdjPercent
        {
            get { return _AdjPercent; }
            set { _AdjPercent = value; }
        }
        public ArrayList PlanMaterialDivision
        {
            get { return _ArrMaterialDivision; }
            set { _ArrMaterialDivision = value; }
        }
        public ArrayList PlanMaterialClass
        {
            get { return _ArrMaterialClass; }
            set { _ArrMaterialClass = value; }
        }
        public DataTable PlanMaterialClassTable
        {
            get { return _MaterialClassTable; }
            set { _MaterialClassTable = value; }
        }
        public DataTable PlanMaterialItemTable
        {
            get { return _MaterialItemTable; }
            set { _MaterialItemTable = value; }
        }
    }
}
