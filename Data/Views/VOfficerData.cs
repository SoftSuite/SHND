using System;

/// <summary>
/// VOfficerData Data Class
/// Version 1.0
/// =========================================================================
/// Create by: Teang
/// Create Date: 3 Feb 2009
/// -------------------------------------------------------------------------
/// Modify By: -
/// Modify From: -
/// Modify Date: -
/// -------------------------------------------------------------------------
/// Remark: -
/// Description:
///    Data Object สำหรับข้อมูลเจ้าหน้าที่
/// Changes:
///    1.0 - สร้าง
/// -------------------------------------------------------------------------
/// =========================================================================
/// </summary>
/// 
namespace SHND.Data.Views
{
    /// <summary>
    /// Represents a V_OFFICER data.
    /// [Created by 127.0.0.1 on Febuary,3 2009]
    /// </summary>
    public class VOfficerData
    {
        string _ACTIVE = "";
        string _ACTIVENAME = "";
        double _DIVISION = 0;
        string _DIVISIONNAME = "";
        string _EMAIL = "";
        string _FIRSTNAME = "";
        DateTime _LASTLOGON = new DateTime(1, 1, 1);
        string _LASTNAME = "";
        double _LOID = 0;
        string _OFFICERGROUP = "";
        string _OFFICERGROUPNAME = "";
        string _OFFICERNAME = "";
        string _PASSWD = "";
        string _TEL = "";
        double _TITLE = 0;
        string _USERNAME = "";

        public string ACTIVE
        {
            get { return _ACTIVE; }
            set { _ACTIVE = value; }
        }
        public string ACTIVENAME
        {
            get { return _ACTIVENAME; }
            set { _ACTIVENAME = value; }
        }
        public double DIVISION
        {
            get { return _DIVISION; }
            set { _DIVISION = value; }
        }
        public string DIVISIONNAME
        {
            get { return _DIVISIONNAME; }
            set { _DIVISIONNAME = value; }
        }
        public string EMAIL
        {
            get { return _EMAIL; }
            set { _EMAIL = value; }
        }
        public string FIRSTNAME
        {
            get { return _FIRSTNAME; }
            set { _FIRSTNAME = value; }
        }
        public DateTime LASTLOGON
        {
            get { return _LASTLOGON; }
            set { _LASTLOGON = value; }
        }
        public string LASTNAME
        {
            get { return _LASTNAME; }
            set { _LASTNAME = value; }
        }
        public double LOID
        {
            get { return _LOID; }
            set { _LOID = value; }
        }
        public string OFFICERGROUP
        {
            get { return _OFFICERGROUP; }
            set { _OFFICERGROUP = value; }
        }
        public string OFFICERGROUPNAME
        {
            get { return _OFFICERGROUPNAME; }
            set { _OFFICERGROUPNAME = value; }
        }
        public string OFFICERNAME
        {
            get { return _OFFICERNAME; }
            set { _OFFICERNAME = value; }
        }
        public string PASSWD
        {
            get { return _PASSWD; }
            set { _PASSWD = value; }
        }
        public string TEL
        {
            get { return _TEL; }
            set { _TEL = value; }
        }
        public double TITLE
        {
            get { return _TITLE; }
            set { _TITLE = value; }
        }
        public string USERNAME
        {
            get { return _USERNAME; }
            set { _USERNAME = value; }
        }
    }
}