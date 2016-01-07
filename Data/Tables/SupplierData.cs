using System;
using System.Collections.Generic;
using System.Text;

/// <summary>
/// Shop Data Class
/// Version 1.0
/// =========================================================================
/// Create by: Somsakoon
/// Create Date: 5 Jan 2009
/// -------------------------------------------------------------------------
/// Modify By: -
/// Modify From: -
/// Modify Date: -
/// -------------------------------------------------------------------------
/// Remark: -
/// Description:
///    Data Object สำหรับข้อมูล Supplier 
/// Changes:
///    1.0 - สร้าง
/// -------------------------------------------------------------------------
/// =========================================================================
/// </summary>
/// 
namespace SHND.Data.Tables
{
    public class SupplierData
    {
        bool _ACTIVE = false ;
        string _ADDRESS = "";
        double _AMPHUR = 0;
        string _CODE = "";
        string _CONTACTNAME = "";
        string _CREATEBY = "";
        DateTime _CREATEON = new DateTime(1, 1, 1);
        string _EMAIL = "";
        string _FAX = "";
        double _LOID = 0;
        string _MOBILE = "";
        string _NAME = "";
        double _PROVINCE = 0;
        string _REMARKS = "";
        string _ROAD = "";
        double _TAMBOL = 0;
        string _TEL = "";
        string _UPDATEBY = "";
        DateTime _UPDATEON = new DateTime(1, 1, 1);
        string _ZIPCODE = "";
        string _FULLADDRESS = "";

        public bool  ACTIVE
        {
            get { return _ACTIVE; }
            set { _ACTIVE = value; }
        }
        public string ADDRESS
        {
            get { return _ADDRESS; }
            set { _ADDRESS = value; }
        }
        public double AMPHUR
        {
            get { return _AMPHUR; }
            set { _AMPHUR = value; }
        }
        public string CODE
        {
            get { return _CODE; }
            set { _CODE = value; }
        }
        public string CONTACTNAME
        {
            get { return _CONTACTNAME; }
            set { _CONTACTNAME = value; }
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
        public string EMAIL
        {
            get { return _EMAIL; }
            set { _EMAIL = value; }
        }
        public string FAX
        {
            get { return _FAX; }
            set { _FAX = value; }
        }
        public double LOID
        {
            get { return _LOID; }
            set { _LOID = value; }
        }
        public string MOBILE
        {
            get { return _MOBILE; }
            set { _MOBILE = value; }
        }
        public string NAME
        {
            get { return _NAME; }
            set { _NAME = value; }
        }
        public double PROVINCE
        {
            get { return _PROVINCE; }
            set { _PROVINCE = value; }
        }
        public string REMARKS
        {
            get { return _REMARKS; }
            set { _REMARKS = value; }
        }
        public string ROAD
        {
            get { return _ROAD; }
            set { _ROAD = value; }
        }
        public double TAMBOL
        {
            get { return _TAMBOL; }
            set { _TAMBOL = value; }
        }
        public string TEL
        {
            get { return _TEL; }
            set { _TEL = value; }
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
        public string ZIPCODE
        {
            get { return _ZIPCODE; }
            set { _ZIPCODE = value; }
        }
        public string FULLADDRESS
        {
            get { return _FULLADDRESS; }
            set { _FULLADDRESS = value; }
        }
    }
}