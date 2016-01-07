using System;

/// <summary>
/// PlanMaterialClassData Data Class
/// Version 1.0
/// =========================================================================
/// Create by: Teang
/// Create Date: 12 Feb 2009
/// -------------------------------------------------------------------------
/// Modify By: -
/// Modify From: -
/// Modify Date: -
/// -------------------------------------------------------------------------
/// Remark: -
/// Description:
///    Data Object สำหรับข้อมูล PlanMaterialClass
/// Changes:
///    1.0 - สร้าง
/// -------------------------------------------------------------------------
/// =========================================================================
/// </summary>
/// 
namespace SHND.Data.Tables
{
    /// <summary>
    /// Represents a PLANMATERIALCLASS data.
    /// [Created by 127.0.0.1 on Febuary,12 2009]
    /// </summary>
    public class PlanMaterialClassData
    {
        string _CONTRACTCODE = "";
        string _CREATEBY = "";
        DateTime _CREATEON = new DateTime(1, 1, 1);
        double _LOID = 0;
        double _MATERIALCLASS = 0;
        double _PLANORDER = 0;
        string _REMARKS = "";
        double _SUPPLIER = 0;
        string _UPDATEBY = "";
        DateTime _UPDATEON = new DateTime(1, 1, 1);

        public string CONTRACTCODE
        {
            get { return _CONTRACTCODE; }
            set { _CONTRACTCODE = value; }
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
        public double MATERIALCLASS
        {
            get { return _MATERIALCLASS; }
            set { _MATERIALCLASS = value; }
        }
        public double PLANORDER
        {
            get { return _PLANORDER; }
            set { _PLANORDER = value; }
        }
        public string REMARKS
        {
            get { return _REMARKS; }
            set { _REMARKS = value; }
        }
        public double SUPPLIER
        {
            get { return _SUPPLIER; }
            set { _SUPPLIER = value; }
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