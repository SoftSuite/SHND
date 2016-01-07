using System;

/// <summary>
/// PlanOrderCouncilData Data Class
/// Version 1.0
/// =========================================================================
/// Create by: Teang
/// Create Date: 30 Jan 2009
/// -------------------------------------------------------------------------
/// Modify By: -
/// Modify From: -
/// Modify Date: -
/// -------------------------------------------------------------------------
/// Remark: -
/// Description:
///    Data Object สำหรับข้อมูล PLANORDERCOUNCIL
/// Changes:
///    1.0 - สร้าง
/// -------------------------------------------------------------------------
/// =========================================================================
/// </summary>
namespace SHND.Data.Views
{
    /// <summary>
    /// Represents a PLANORDERCOUNCIL data.
    /// [Created by 127.0.0.1 on Febuary,3 2009]
    /// </summary>
    public class PlanOrderCouncilData
    {
        string _CREATEBY = "";
        DateTime _CREATEON = new DateTime(1, 1, 1);
        double _DIVISION = 0;
        double _LOID = 0;
        bool _M1 = false;
        bool _M10 = false;
        bool _M11 = false;
        bool _M12 = false;
        bool _M2 = false;
        bool _M3 = false;
        bool _M4 = false;
        bool _M5 = false;
        bool _M6 = false;
        bool _M7 = false;
        bool _M8 = false;
        bool _M9 = false;
        double _OFFICER = 0;
        double _PLANORDER = 0;
        string _POSITION = "";
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
        public bool M1
        {
            get { return _M1; }
            set { _M1 = value; }
        }
        public bool M10
        {
            get { return _M10; }
            set { _M10 = value; }
        }
        public bool M11
        {
            get { return _M11; }
            set { _M11 = value; }
        }
        public bool M12
        {
            get { return _M12; }
            set { _M12 = value; }
        }
        public bool M2
        {
            get { return _M2; }
            set { _M2 = value; }
        }
        public bool M3
        {
            get { return _M3; }
            set { _M3 = value; }
        }
        public bool M4
        {
            get { return _M4; }
            set { _M4 = value; }
        }
        public bool M5
        {
            get { return _M5; }
            set { _M5 = value; }
        }
        public bool M6
        {
            get { return _M6; }
            set { _M6 = value; }
        }
        public bool M7
        {
            get { return _M7; }
            set { _M7 = value; }
        }
        public bool M8
        {
            get { return _M8; }
            set { _M8 = value; }
        }
        public bool M9
        {
            get { return _M9; }
            set { _M9 = value; }
        }
        public double OFFICER
        {
            get { return _OFFICER; }
            set { _OFFICER = value; }
        }
        public double PLANORDER
        {
            get { return _PLANORDER; }
            set { _PLANORDER = value; }
        }
        public string POSITION
        {
            get { return _POSITION; }
            set { _POSITION = value; }
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