using System;
using System.Data;

/// <summary>
/// StdMenuItemControlData Data Class
/// Version 1.0
/// =========================================================================
/// Create by: Teang
/// Create Date: 20 Jan 2009
/// -------------------------------------------------------------------------
/// Modify By: -
/// Modify From: -
/// Modify Date: -
/// -------------------------------------------------------------------------
/// Remark: -
/// Description:
///    Data Object สำหรับข้อมูล StdMenuItemControl
/// Changes:
///    1.0 - สร้าง
/// -------------------------------------------------------------------------
/// =========================================================================
/// </summary>
/// 
namespace SHND.Data.Formula
{
    public class StdMenuItemControlData
    {
        DataTable _SelectedRice = new DataTable();
        DataTable _AllRice = new DataTable();
        DataTable _SelectedSavory = new DataTable();
        DataTable _AllSavory = new DataTable();
        DataTable _SelectedFruits = new DataTable();
        DataTable _AllFruits = new DataTable();
        DataTable _SelectedDrinks = new DataTable();
        DataTable _AllDrinks = new DataTable();
        double _ENERGY = 0;
        double _PORTION = 0;

        public double ENERGY
        {
            get { return _ENERGY; }
            set { _ENERGY = value; }
        }
        public double PORTION
        {
            get { return _PORTION; }
            set { _PORTION = value; }
        }
        public DataTable SelectedRice
        {
            get { return _SelectedRice; }
            set { _SelectedRice = value; }
        }
        public DataTable AllRice
        {
            get { return _AllRice; }
            set { _AllRice = value; }
        }
        public DataTable SelectedSavory
        {
            get { return _SelectedSavory; }
            set { _SelectedSavory = value; }
        }
        public DataTable AllSavory
        {
            get { return _AllSavory; }
            set { _AllSavory = value; }
        }
        public DataTable SelectedFruits
        {
            get { return _SelectedFruits; }
            set { _SelectedFruits = value; }
        }
        public DataTable AllFruits
        {
            get { return _AllFruits; }
            set { _AllFruits = value; }
        }
        public DataTable SelectedDrinks
        {
            get { return _SelectedDrinks; }
            set { _SelectedDrinks = value; }
        }
        public DataTable AllDrinks         
        {
            get { return _AllDrinks; }
            set { _AllDrinks = value; }
        }
    }
}
