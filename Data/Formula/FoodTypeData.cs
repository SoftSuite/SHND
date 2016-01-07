using System;
using System.Collections.Generic;
using System.Text;

/// <summary>
/// FoodType Data Class
/// Version 1.0
/// =========================================================================
/// Create by: TurBoZ
/// Create Date: 22 Dec 2008
/// -------------------------------------------------------------------------
/// Modify By: -
/// Modify From: -
/// Modify Date: -
/// -------------------------------------------------------------------------
/// Remark: -
/// Description:
///    Data Object สำหรับข้อมูล FoodType 
/// Changes:
///    1.0 - สร้าง
/// -------------------------------------------------------------------------
/// =========================================================================
/// </summary>
/// 

namespace SHND.Data.Formula
{
    public class FoodTypeData
    {

        double _LOID = 0;
        string _CODE = "";
        string _NAME = "";
        double _DIVISION = 0;
        bool _ACTIVE = false;
        double _PRICE = 0;
        string _PRICETYPE = "";
        bool _ISNURSE = false;


        public double LOID
        {
            get { return _LOID; }
            set { _LOID = value; }
        }

        public string CODE
        {
            get { return _CODE; }
            set { _CODE = value; }
        }

        public string NAME
        {
            get { return _NAME; }
            set { _NAME = value; }
        }

        public double DIVISION
        {
            get { return _DIVISION; }
            set { _DIVISION = value; }
        }

        public bool ACTIVE
        {
            get { return _ACTIVE; }
            set { _ACTIVE = value; }
        }
        public double PRICE
        {
            get { return _PRICE; }
            set { _PRICE = value; }

        }

        public string PRICETYPE
        {
            get { return _PRICETYPE; }
            set { _PRICETYPE = value; }
        }

        public bool ISNURSE
        {
            get { return _ISNURSE; }
            set { _ISNURSE = value; }
        }

    }

}
