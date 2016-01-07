using System;
using System.Collections.Generic;
using System.Text;

/// <summary>
/// MaterialMaster Data Class
/// Version 1.0
/// =========================================================================
/// Create by: Pom
/// Create Date: 6 Jan 2008
/// -------------------------------------------------------------------------
/// Modify By: -
/// Modify From: -
/// Modify Date: -
/// -------------------------------------------------------------------------
/// Remark: -
/// Description:
///    Data Object สำหรับข้อมูล Material Master Search 
/// Changes:
///    1.0 - สร้าง
/// -------------------------------------------------------------------------
/// =========================================================================
/// </summary>
/// 


namespace SHND.Data.Tables
{
    /// <summary>
    /// Represents a MATERIALMASTER data.
    /// [Created by 127.0.0.1 on January,6 2009]
    /// </summary>
    public class MaterialMasterData
    {
        string _ACTIVE = "";
        string _ARTICLECODE = "";
        string _CODE = "";
        double _COST = 0;
        string _CREATEBY = "";
        DateTime _CREATEON = new DateTime(1, 1, 1);
        double _DIVISION = 0;
        double _ENERGY = 0;
        string _ISCOUNT = "";
        string _ISMENU = "";
        double _LOID = 0;
        double _MATERIALCLASS = 0;
        double _MATERIALGROUP = 0;
        double _MAXSTOCK = 0;
        double _MILKCATEGORY = 0;
        double _MINSTOCK = 0;
        string _NAME = "";
        string _ORDERTYPE = "";
        double _PRICE = 0;
        string _REMARKS = "";
        string _SAPCODE = "";
        double _SAPWAREHOUSE = 0;
        string _SPEC = "";
        string _STOCKOUTBREAKFAST = "";
        string _STOCKOUTDINNER = "";
        string _STOCKOUTLUNCH = "";
        double _UNIT = 0;
        string _UPDATEBY = "";
        DateTime _UPDATEON = new DateTime(1, 1, 1);
        double _WEIGHT = 0;
        double _WEIGHTCOOK = 0;
        double _WEIGHTPREPARE = 0;
        double _WEIGHTCOOKFR = 0;
        double _WEIGHTCOOKBO = 0;
        double _WEIGHTCOOKRO = 0;
        double _WEIGHTCOOKFY = 0;
        double _WEIGHTCOOKST = 0;
        double _WEIGHTCOOKNN = 0;
        double _WEIGHTCOOKPE = 0;
        double _OILFY = 0;
        double _OILFR = 0;
        double _NUTRIENTRATE = 0;


        public string ACTIVE
        {
            get { return _ACTIVE; }
            set { _ACTIVE = value; }
        }
        public string ARTICLECODE
        {
            get { return _ARTICLECODE; }
            set { _ARTICLECODE = value; }
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
        public double ENERGY
        {
            get { return _ENERGY; }
            set { _ENERGY = value; }
        }
        public string ISCOUNT
        {
            get { return _ISCOUNT; }
            set { _ISCOUNT = value; }
        }
        public string ISMENU
        {
            get { return _ISMENU; }
            set { _ISMENU = value; }
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
        public double MATERIALGROUP
        {
            get { return _MATERIALGROUP; }
            set { _MATERIALGROUP = value; }
        }
        public double MAXSTOCK
        {
            get { return _MAXSTOCK; }
            set { _MAXSTOCK = value; }
        }
        public double MILKCATEGORY
        {
            get { return _MILKCATEGORY; }
            set { _MILKCATEGORY = value; }
        }
        public double MINSTOCK
        {
            get { return _MINSTOCK; }
            set { _MINSTOCK = value; }
        }
        public string NAME
        {
            get { return _NAME; }
            set { _NAME = value; }
        }
        public string ORDERTYPE
        {
            get { return _ORDERTYPE; }
            set { _ORDERTYPE = value; }
        }
        public double PRICE
        {
            get { return _PRICE; }
            set { _PRICE = value; }
        }
        public string REMARKS
        {
            get { return _REMARKS; }
            set { _REMARKS = value; }
        }
        public string SAPCODE
        {
            get { return _SAPCODE; }
            set { _SAPCODE = value; }
        }
        public double SAPWAREHOUSE
        {
            get { return _SAPWAREHOUSE; }
            set { _SAPWAREHOUSE = value; }
        }
        public string SPEC
        {
            get { return _SPEC; }
            set { _SPEC = value; }
        }
        public string STOCKOUTBREAKFAST
        {
            get { return _STOCKOUTBREAKFAST; }
            set { _STOCKOUTBREAKFAST = value; }
        }
        public string STOCKOUTDINNER
        {
            get { return _STOCKOUTDINNER; }
            set { _STOCKOUTDINNER = value; }
        }
        public string STOCKOUTLUNCH
        {
            get { return _STOCKOUTLUNCH; }
            set { _STOCKOUTLUNCH = value; }
        }
        public double UNIT
        {
            get { return _UNIT; }
            set { _UNIT = value; }
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
        public double WEIGHT
        {
            get { return _WEIGHT; }
            set { _WEIGHT = value; }
        }
        public double WEIGHTCOOK
        {
            get { return _WEIGHTCOOK; }
            set { _WEIGHTCOOK = value; }
        }
        public double WEIGHTPREPARE
        {
            get { return _WEIGHTPREPARE; }
            set { _WEIGHTPREPARE = value; }
        }
        public double WEIGHTCOOKBO
        {
            get { return _WEIGHTCOOKBO; }
            set { _WEIGHTCOOKBO = value; }
        }
        public double WEIGHTCOOKFR
        {
            get { return _WEIGHTCOOKFR; }
            set { _WEIGHTCOOKFR = value; }
        }
        public double WEIGHTCOOKRO
        {
            get { return _WEIGHTCOOKRO; }
            set { _WEIGHTCOOKRO = value; }
        }
        public double WEIGHTCOOKFY
        {
            get { return _WEIGHTCOOKFY; }
            set { _WEIGHTCOOKFY = value; }
        }
        public double WEIGHTCOOKST
        {
            get { return _WEIGHTCOOKST; }
            set { _WEIGHTCOOKST = value; }
        }
        public double WEIGHTCOOKNN
        {
            get { return _WEIGHTCOOKNN; }
            set { _WEIGHTCOOKNN = value; }
        }
        public double WEIGHTCOOKPE
        {
            get { return _WEIGHTCOOKPE; }
            set { _WEIGHTCOOKPE = value; }
        }
        public double OILFY
        {
            get { return _OILFY; }
            set { _OILFY = value; }
        }
        public double OILFR
        {
            get { return _OILFR; }
            set { _OILFR = value; }
        }
        public double NUTRIENTRATE
        {
            get { return _NUTRIENTRATE; }
            set { _NUTRIENTRATE = value; }
        }
    }
}