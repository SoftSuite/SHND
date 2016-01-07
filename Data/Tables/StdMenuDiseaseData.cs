using System;

/// <summary>
/// FORMULASERVE Data Class
/// Version 1.0
/// =========================================================================
/// Create by: Teang
/// Create Date: 16 Jan 2009
/// -------------------------------------------------------------------------
/// Modify By: -
/// Modify From: -
/// Modify Date: -
/// -------------------------------------------------------------------------
/// Remark: -
/// Description:
///    Data Object สำหรับข้อมูล StdMenuDisease
/// Changes:
///    1.0 - สร้าง
/// -------------------------------------------------------------------------
/// =========================================================================
/// </summary>
/// 
namespace SHND.Data.Tables
{
    /// <summary>
    /// Represents a STDMENUDISEASE data.
    /// [Created by 127.0.0.1 on January,16 2009]
    /// </summary>
    public class StdMenuDiseaseData
    {
        string _CREATEBY = "";
        DateTime _CREATEON = new DateTime(1, 1, 1);
        double _DISEASECATEGORY = 0;
        double _LOID = 0;
        double _STDMENU = 0;
        string _UPDATEBY = "";
        DateTime _UPDATEON = new DateTime(1, 1, 1);
        bool _ISHIGH = false;
        bool _ISLOW = false;
        bool _ISNON = false;

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
        public double STDMENU
        {
            get { return _STDMENU; }
            set { _STDMENU = value; }
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
        public bool ISHIGH
        {
            get { return _ISHIGH; }
            set { _ISHIGH = value; }
        }
        public bool ISLOW
        {
            get { return _ISLOW; }
            set { _ISLOW = value; }
        }
        public bool ISNON
        {
            get { return _ISNON; }
            set { _ISNON = value; }
        }
    }
}