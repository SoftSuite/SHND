using System;
using System.Collections;
using System.Collections.Generic;
using System.Data;
using System.Text;

namespace SHND.Data.Tables
{
    /// <summary>
    /// Represents a MENU data.
    /// [Created by 127.0.0.1 on January,20 2009]
    /// </summary>
    public class MenuDetailData
    {
        double _BUDGETYEAR = 0;
        string _CREATEBY = "";
        DateTime _CREATEON = new DateTime(1, 1, 1);
        double _DIVISION = 0;
        string _DIVISIONNAME = "";
        DateTime _ENDDATE = new DateTime(1, 1, 1);
        double _FOODCATEGORY = 0;
        double _FOODTYPE = 0;
        double _LOID = 0;
        string _NAME = "";
        string _PHASE = "";
        DateTime _STARTDATE = new DateTime(1, 1, 1);
        string _STATUS = "";
        string _STATUSNAME = "";
        string _UPDATEBY = "";
        DateTime _UPDATEON = new DateTime(1, 1, 1);
        ArrayList _MenuDisease = new ArrayList();
        double _ITEM = 0;
        double _PORTION = 0;
        string _MEAL = "";
        ArrayList _MenuItem = new ArrayList();
        ArrayList _SelectedDay = new ArrayList();
        DateTime _DATE = new DateTime(1, 1, 1);


        public double BUDGETYEAR
        {
            get { return _BUDGETYEAR; }
            set { _BUDGETYEAR = value; }
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
        public string DIVISIONNAME
        {
            get { return _DIVISIONNAME; }
            set { _DIVISIONNAME = value; }
        }
        public DateTime ENDDATE
        {
            get { return _ENDDATE; }
            set { _ENDDATE = value; }
        }
        public double FOODCATEGORY
        {
            get { return _FOODCATEGORY; }
            set { _FOODCATEGORY = value; }
        }
        public double FOODTYPE
        {
            get { return _FOODTYPE; }
            set { _FOODTYPE = value; }
        }
        public double LOID
        {
            get { return _LOID; }
            set { _LOID = value; }
        }
        public string NAME
        {
            get { return _NAME; }
            set { _NAME = value; }
        }
        public string PHASE
        {
            get { return _PHASE; }
            set { _PHASE = value; }
        }
        public DateTime STARTDATE
        {
            get { return _STARTDATE; }
            set { _STARTDATE = value; }
        }
        public string STATUS
        {
            get { return _STATUS; }
            set { _STATUS = value; }
        }
        public string STATUSNAME
        {
            get { return _STATUSNAME; }
            set { _STATUSNAME = value; }
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
        public ArrayList MenuDisease
        {
            get { return _MenuDisease; }
            set { _MenuDisease = value; }
        }
        public double ITEM
        {
            get { return _ITEM; }
            set { _ITEM = value; }
        }
        public double PORTION
        {
            get { return _PORTION; }
            set { _PORTION = value; }
        }
        public ArrayList SelectedDay
        {
            get { return _SelectedDay; }
            set { _SelectedDay = value; }
        }
        public ArrayList MenuItem
        {
            get { return _MenuItem; }
            set { _MenuItem = value; }
        }
        public string MEAL
        {
            get { return _MEAL; }
            set { _MEAL = value; }
        }
        public DateTime DATE
        {
            get { return _DATE; }
            set { _DATE = value; }
        }
    }
}