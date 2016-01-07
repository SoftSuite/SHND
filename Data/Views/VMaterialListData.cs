using System;

/// <summary>
/// VMaterialListData Data Class
/// Version 1.0
/// =========================================================================
/// Create by: Teang
/// Create Date: 18 Jan 2009
/// -------------------------------------------------------------------------
/// Modify By: -
/// Modify From: -
/// Modify Date: -
/// -------------------------------------------------------------------------
/// Remark: -
/// Description:
///    Data Object สำหรับข้อมูลวัสดุอาหาร
/// Changes:
///    1.0 - สร้าง
/// -------------------------------------------------------------------------
/// =========================================================================
/// </summary>
/// 
namespace SHND.Data.Views
{
    /// <summary>
    /// Represents a V_MATERIAL_LIST data.
    /// [Created by 127.0.0.1 on January,28 2009]
    /// </summary>
    public class VMaterialListData_
    {
        double _CLASSLOID = 0;
        string _CLASSNAME = "";
        string _CODE = "";
        double _COST = 0;
        double _GROUPLOID = 0;
        string _GROUPNAME = "";
        double _LOID = 0;
        string _MATERIALNAME = "";
        string _SAPCODE = "";
        string _SPEC = "";
        double _UNIT = 0;
        string _UNITNAME = "";

        public double CLASSLOID
        {
            get { return _CLASSLOID; }
            set { _CLASSLOID = value; }
        }
        public string CLASSNAME
        {
            get { return _CLASSNAME; }
            set { _CLASSNAME = value; }
        }
        public string CODE
        {
            get { return _CODE; }
            set { _CODE = value; }
        }
        public double COST
        {
            get { return _COST; }
            set { _COST = value; }
        }
        public double GROUPLOID
        {
            get { return _GROUPLOID; }
            set { _GROUPLOID = value; }
        }
        public string GROUPNAME
        {
            get { return _GROUPNAME; }
            set { _GROUPNAME = value; }
        }
        public double LOID
        {
            get { return _LOID; }
            set { _LOID = value; }
        }
        public string MATERIALNAME
        {
            get { return _MATERIALNAME; }
            set { _MATERIALNAME = value; }
        }
        public string SAPCODE
        {
            get { return _SAPCODE; }
            set { _SAPCODE = value; }
        }
        public string SPEC
        {
            get { return _SPEC; }
            set { _SPEC = value; }
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
    }
}