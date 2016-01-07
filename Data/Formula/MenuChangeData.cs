using System;
using System.Collections;
using System.Collections.Generic;
using System.Data;
using System.Text;

/// <summary>
/// StdMenuDetailData Data Class
/// Version 1.0
/// =========================================================================
/// Create by: Tan
/// Create Date: 20 April 2009
/// -------------------------------------------------------------------------
/// Modify By: -
/// Modify From: -
/// Modify Date: -
/// -------------------------------------------------------------------------
/// Remark: -
/// Description:
///    Data Object สำหรับข้อมูลเปลี่ยน Menu
/// Changes:
///    1.0 - สร้าง
/// -------------------------------------------------------------------------
/// =========================================================================
/// </summary>
/// 
namespace SHND.Data.Formula
{
    public class MenuChangeData
    {
        string _MEAL = "";
        double _MENULOID = 0;
        double _MENUITEMLOID = 0;
        string _FOODTYPE = "";
        string _FOODCATEGORY = "";
        string _GROUPTYPE = "";
        string _MENUNAME = "";
        DateTime _MENUDATE = new DateTime();
        double _MATERIALMASTER = 0;
        string _MATERIALNAME = "";
        double _QTY = 0;
        double _UNIT = 0;
        double _MENUDATELOID = 0;

        public string MEAL
        {
            get { return _MEAL; }
            set { _MEAL = value; }
        }
        public double MENULOID
        {
            get { return _MENULOID; }
            set { _MENULOID = value; }
        }
        public double MENUITEMLOID
        {
            get { return _MENUITEMLOID; }
            set { _MENUITEMLOID = value; }
        }
        public string FOODTYPE
        {
            get { return _FOODTYPE; }
            set { _FOODTYPE = value; }
        }
        public string FOODCATEGORY
        {
            get { return _FOODCATEGORY; }
            set { _FOODCATEGORY = value; }
        }
        public string GROUPTYPE
        {
            get { return _GROUPTYPE; }
            set { _GROUPTYPE = value; }
        }
        public string MENUNAME
        {
            get { return _MENUNAME; }
            set { _MENUNAME = value; }
        }
        public DateTime MENUDATE
        {
            get { return _MENUDATE; }
            set { _MENUDATE = value; }
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
        public double QTY
        {
            get { return _QTY; }
            set { _QTY = value; }
        }
        public double UNIT
        {
            get { return _UNIT; }
            set { _UNIT = value; }
        }
        public double MENUDATELOID
        {
            get { return _MENUDATELOID; }
            set { _MENUDATELOID = value; }
        }

    }
}
