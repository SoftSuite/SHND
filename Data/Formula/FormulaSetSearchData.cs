using System;
using System.Collections.Generic;
using System.Text;

/// <summary>
/// FoodType Data Class
/// Version 1.0
/// =========================================================================
/// Create by: Teang
/// Create Date: 5 Jan 2009
/// -------------------------------------------------------------------------
/// Modify By: 
/// Modify From: 
/// Modify Date: 
/// -------------------------------------------------------------------------
/// Remark: -
/// Description:
///    Data Object สำหรับข้อมูล FormulaSet 
/// Changes:
///    1.0 - สร้าง
/// -------------------------------------------------------------------------
/// =========================================================================
/// </summary>
/// 

namespace SHND.Data.Formula
{
    public class FormulaSetSearchData
    {
        private string _FormulaSetName = "";
        private double _FoodType = 0;
        private double _FoodCategory = 0;
        private string _IsSpecific = "";
        private string _StatusRankFrom = "";
        private string _StatusRankTo = "";
        private double _DIVISION = 0;
        private string _Active = "";

        public string FormulaSetName
        {
            get { return _FormulaSetName; }
            set { _FormulaSetName = value; }
        }
        public double FoodType
        {
            get { return _FoodType; }
            set { _FoodType = value; }
        }
        public double FoodCategory
        {
            get { return _FoodCategory; }
            set { _FoodCategory = value; }
        }
        public string IsSpecific
        {
            get { return _IsSpecific; }
            set { _IsSpecific = value; }
        }
        public string StatusRankFrom
        {
            get { return _StatusRankFrom; }
            set { _StatusRankFrom = value; }
        }
        public string StatusRankTo
        {
            get { return _StatusRankTo; }
            set { _StatusRankTo = value; }
        }
        public double DIVISION
        {
            get { return _DIVISION; }
            set { _DIVISION = value; }
        }

        public string Active
        {
            get { return _Active; }
            set { _Active = value; }
        }
    }
}
