using System;
using System.Collections;
using System.Collections.Generic;
using System.Data;
using System.Text;

/// <summary>
/// StdMenuDetailData Data Class
/// Version 1.0
/// =========================================================================
/// Create by: Teang
/// Create Date: 19 Jan 2009
/// -------------------------------------------------------------------------
/// Modify By: -
/// Modify From: -
/// Modify Date: -
/// -------------------------------------------------------------------------
/// Remark: -
/// Description:
///    Data Object สำหรับข้อมูล StdMenu
/// Changes:
///    1.0 - สร้าง
/// -------------------------------------------------------------------------
/// =========================================================================
/// </summary>
/// 
namespace SHND.Data.Formula
{
    public class StdMenuDetailData
    {
        bool _ACTIVE = true;
        double _DIVISION = 0;
        string _DIVISIONNAME = "";
        double _FOODCATEGORY = 0;
        double _FOODTYPE = 0;
        bool _ISSPECIFIC = false;
        double _LOID = 0;
        string _NAME = "";
        string _STATUS = "";
        string _STATUSNAME = "";
        string _MEAL = "";
        //int _DAY = 0;
        ArrayList _StdMenuDisease = new ArrayList();
        ArrayList _stdMenuItem = new ArrayList();
        ArrayList _SelectedDay = new ArrayList();
        double _DAY0111 = 0;
        double _DAY0121 = 0;
        double _DAY0131 = 0;
        double _DAY0211 = 0;
        double _DAY0221 = 0;
        double _DAY0231 = 0;
        double _DAY0311 = 0;
        double _DAY0321 = 0;
        double _DAY0331 = 0;
        double _DAY0411 = 0;
        double _DAY0421 = 0;
        double _DAY0431 = 0;
        double _DAY0511 = 0;
        double _DAY0521 = 0;
        double _DAY0531 = 0;
        double _DAY0611 = 0;
        double _DAY0621 = 0;
        double _DAY0631 = 0;
        double _DAY0711 = 0;
        double _DAY0721 = 0;
        double _DAY0731 = 0;
        double _DAY0811 = 0;
        double _DAY0821 = 0;
        double _DAY0831 = 0;
        double _DAY0911 = 0;
        double _DAY0921 = 0;
        double _DAY0931 = 0;
        double _DAY1011 = 0;
        double _DAY1021 = 0;
        double _DAY1031 = 0;
        double _DAY1111 = 0;
        double _DAY1121 = 0;
        double _DAY1131 = 0;
        double _DAY1211 = 0;
        double _DAY1221 = 0;
        double _DAY1231 = 0;
        double _DAY1311 = 0;
        double _DAY1321 = 0;
        double _DAY1331 = 0;
        double _DAY1411 = 0;
        double _DAY1421 = 0;
        double _DAY1431 = 0;
        double _DAY1511 = 0;
        double _DAY1521 = 0;
        double _DAY1531 = 0;
        double _DAY1611 = 0;
        double _DAY1621 = 0;
        double _DAY1631 = 0;
        double _DAY1711 = 0;
        double _DAY1721 = 0;
        double _DAY1731 = 0;
        double _DAY1811 = 0;
        double _DAY1821 = 0;
        double _DAY1831 = 0;
        double _DAY1911 = 0;
        double _DAY1921 = 0;
        double _DAY1931 = 0;
        double _DAY2011 = 0;
        double _DAY2021 = 0;
        double _DAY2031 = 0;
        double _DAY2111 = 0;
        double _DAY2121 = 0;
        double _DAY2131 = 0;
        double _DAY2211 = 0;
        double _DAY2221 = 0;
        double _DAY2231 = 0;
        double _DAY2311 = 0;
        double _DAY2321 = 0;
        double _DAY2331 = 0;
        double _DAY2411 = 0;
        double _DAY2421 = 0;
        double _DAY2431 = 0;
        double _DAY2511 = 0;
        double _DAY2521 = 0;
        double _DAY2531 = 0;
        double _DAY2611 = 0;
        double _DAY2621 = 0;
        double _DAY2631 = 0;
        double _DAY2711 = 0;
        double _DAY2721 = 0;
        double _DAY2731 = 0;
        double _DAY2811 = 0;
        double _DAY2821 = 0;
        double _DAY2831 = 0;
        double _DAY2911 = 0;
        double _DAY2921 = 0;
        double _DAY2931 = 0;
        double _DAY3011 = 0;
        double _DAY3021 = 0;
        double _DAY3031 = 0;
        double _DAY3111 = 0;
        double _DAY3121 = 0;
        double _DAY3131 = 0;


        public bool ACTIVE
        {
            get { return _ACTIVE; }
            set { _ACTIVE = value; }
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
        public bool ISSPECIFIC
        {
            get { return _ISSPECIFIC; }
            set { _ISSPECIFIC = value; }
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
        public ArrayList SelectedDay
        {
            get { return _SelectedDay; }
            set { _SelectedDay = value; }
        }
        public ArrayList StdMenuDisease
        {
            get { return _StdMenuDisease; }
            set { _StdMenuDisease = value; }
        }
        public ArrayList StdMenuItem
        {
            get { return _stdMenuItem; }
            set { _stdMenuItem = value; } 
        }
        public string MEAL
        {
            get { return _MEAL; }
            set { _MEAL = value; }
        }
        //public int DAY
        //{
        //    get { return _DAY; }
        //    set { _DAY = value; }
        //}
        public double DAY0111
        {
            get { return _DAY0111; }
            set { _DAY0111 = value; }
        }
        public double DAY0121
        {
            get { return _DAY0121; }
            set { _DAY0121 = value; }
        }
        public double DAY0131
        {
            get { return _DAY0131; }
            set { _DAY0131 = value; }
        }
        public double DAY0211
        {
            get { return _DAY0211; }
            set { _DAY0211 = value; }
        }
        public double DAY0221
        {
            get { return _DAY0221; }
            set { _DAY0221 = value; }
        }
        public double DAY0231
        {
            get { return _DAY0231; }
            set { _DAY0231 = value; }
        }
        public double DAY0311
        {
            get { return _DAY0311; }
            set { _DAY0311 = value; }
        }
        public double DAY0321
        {
            get { return _DAY0321; }
            set { _DAY0321 = value; }
        }
        public double DAY0331
        {
            get { return _DAY0331; }
            set { _DAY0331 = value; }
        }
        public double DAY0411
        {
            get { return _DAY0411; }
            set { _DAY0411 = value; }
        }
        public double DAY0421
        {
            get { return _DAY0421; }
            set { _DAY0421 = value; }
        }
        public double DAY0431
        {
            get { return _DAY0431; }
            set { _DAY0431 = value; }
        }
        public double DAY0511
        {
            get { return _DAY0511; }
            set { _DAY0511 = value; }
        }
        public double DAY0521
        {
            get { return _DAY0521; }
            set { _DAY0521 = value; }
        }
        public double DAY0531
        {
            get { return _DAY0531; }
            set { _DAY0531 = value; }
        }
        public double DAY0611
        {
            get { return _DAY0611; }
            set { _DAY0611 = value; }
        }
        public double DAY0621
        {
            get { return _DAY0621; }
            set { _DAY0621 = value; }
        }
        public double DAY0631
        {
            get { return _DAY0631; }
            set { _DAY0631 = value; }
        }
        public double DAY0711
        {
            get { return _DAY0711; }
            set { _DAY0711 = value; }
        }
        public double DAY0721
        {
            get { return _DAY0721; }
            set { _DAY0721 = value; }
        }
        public double DAY0731
        {
            get { return _DAY0731; }
            set { _DAY0731 = value; }
        }
        public double DAY0811
        {
            get { return _DAY0811; }
            set { _DAY0811 = value; }
        }
        public double DAY0821
        {
            get { return _DAY0821; }
            set { _DAY0821 = value; }
        }
        public double DAY0831
        {
            get { return _DAY0831; }
            set { _DAY0831 = value; }
        }
        public double DAY0911
        {
            get { return _DAY0911; }
            set { _DAY0911 = value; }
        }
        public double DAY0921
        {
            get { return _DAY0921; }
            set { _DAY0921 = value; }
        }
        public double DAY0931
        {
            get { return _DAY0931; }
            set { _DAY0931 = value; }
        }
        public double DAY1011
        {
            get { return _DAY1011; }
            set { _DAY1011 = value; }
        }
        public double DAY1021
        {
            get { return _DAY1021; }
            set { _DAY1021 = value; }
        }
        public double DAY1031
        {
            get { return _DAY1031; }
            set { _DAY1031 = value; }
        }
        public double DAY1111
        {
            get { return _DAY1111; }
            set { _DAY1111 = value; }
        }
        public double DAY1121
        {
            get { return _DAY1121; }
            set { _DAY1121 = value; }
        }
        public double DAY1131
        {
            get { return _DAY1131; }
            set { _DAY1131 = value; }
        }
        public double DAY1211
        {
            get { return _DAY1211; }
            set { _DAY1211 = value; }
        }
        public double DAY1221
        {
            get { return _DAY1221; }
            set { _DAY1221 = value; }
        }
        public double DAY1231
        {
            get { return _DAY1231; }
            set { _DAY1231 = value; }
        }
        public double DAY1311
        {
            get { return _DAY1311; }
            set { _DAY1311 = value; }
        }
        public double DAY1321
        {
            get { return _DAY1321; }
            set { _DAY1321 = value; }
        }
        public double DAY1331
        {
            get { return _DAY1331; }
            set { _DAY1331 = value; }
        }
        public double DAY1411
        {
            get { return _DAY1411; }
            set { _DAY1411 = value; }
        }
        public double DAY1421
        {
            get { return _DAY1421; }
            set { _DAY1421 = value; }
        }
        public double DAY1431
        {
            get { return _DAY1431; }
            set { _DAY1431 = value; }
        }
        public double DAY1511
        {
            get { return _DAY1511; }
            set { _DAY1511 = value; }
        }
        public double DAY1521
        {
            get { return _DAY1521; }
            set { _DAY1521 = value; }
        }
        public double DAY1531
        {
            get { return _DAY1531; }
            set { _DAY1531 = value; }
        }
        public double DAY1611
        {
            get { return _DAY1611; }
            set { _DAY1611 = value; }
        }
        public double DAY1621
        {
            get { return _DAY1621; }
            set { _DAY1621 = value; }
        }
        public double DAY1631
        {
            get { return _DAY1631; }
            set { _DAY1631 = value; }
        }
        public double DAY1711
        {
            get { return _DAY1711; }
            set { _DAY1711 = value; }
        }
        public double DAY1721
        {
            get { return _DAY1721; }
            set { _DAY1721 = value; }
        }
        public double DAY1731
        {
            get { return _DAY1731; }
            set { _DAY1731 = value; }
        }
        public double DAY1811
        {
            get { return _DAY1811; }
            set { _DAY1811 = value; }
        }
        public double DAY1821
        {
            get { return _DAY1821; }
            set { _DAY1821 = value; }
        }
        public double DAY1831
        {
            get { return _DAY1831; }
            set { _DAY1831 = value; }
        }
        public double DAY1911
        {
            get { return _DAY1911; }
            set { _DAY1911 = value; }
        }
        public double DAY1921
        {
            get { return _DAY1921; }
            set { _DAY1921 = value; }
        }
        public double DAY1931
        {
            get { return _DAY1931; }
            set { _DAY1931 = value; }
        }
        public double DAY2011
        {
            get { return _DAY2011; }
            set { _DAY2011 = value; }
        }
        public double DAY2021
        {
            get { return _DAY2021; }
            set { _DAY2021 = value; }
        }
        public double DAY2031
        {
            get { return _DAY2031; }
            set { _DAY2031 = value; }
        }
        public double DAY2111
        {
            get { return _DAY2111; }
            set { _DAY2111 = value; }
        }
        public double DAY2121
        {
            get { return _DAY2121; }
            set { _DAY2121 = value; }
        }
        public double DAY2131
        {
            get { return _DAY2131; }
            set { _DAY2131 = value; }
        }
        public double DAY2211
        {
            get { return _DAY2211; }
            set { _DAY2211 = value; }
        }
        public double DAY2221
        {
            get { return _DAY2221; }
            set { _DAY2221 = value; }
        }
        public double DAY2231
        {
            get { return _DAY2231; }
            set { _DAY2231 = value; }
        }
        public double DAY2311
        {
            get { return _DAY2311; }
            set { _DAY2311 = value; }
        }
        public double DAY2321
        {
            get { return _DAY2321; }
            set { _DAY2321 = value; }
        }
        public double DAY2331
        {
            get { return _DAY2331; }
            set { _DAY2331 = value; }
        }
        public double DAY2411
        {
            get { return _DAY2411; }
            set { _DAY2411 = value; }
        }
        public double DAY2421
        {
            get { return _DAY2421; }
            set { _DAY2421 = value; }
        }
        public double DAY2431
        {
            get { return _DAY2431; }
            set { _DAY2431 = value; }
        }
        public double DAY2511
        {
            get { return _DAY2511; }
            set { _DAY2511 = value; }
        }
        public double DAY2521
        {
            get { return _DAY2521; }
            set { _DAY2521 = value; }
        }
        public double DAY2531
        {
            get { return _DAY2531; }
            set { _DAY2531 = value; }
        }
        public double DAY2611
        {
            get { return _DAY2611; }
            set { _DAY2611 = value; }
        }
        public double DAY2621
        {
            get { return _DAY2621; }
            set { _DAY2621 = value; }
        }
        public double DAY2631
        {
            get { return _DAY2631; }
            set { _DAY2631 = value; }
        }
        public double DAY2711
        {
            get { return _DAY2711; }
            set { _DAY2711 = value; }
        }
        public double DAY2721
        {
            get { return _DAY2721; }
            set { _DAY2721 = value; }
        }
        public double DAY2731
        {
            get { return _DAY2731; }
            set { _DAY2731 = value; }
        }
        public double DAY2811
        {
            get { return _DAY2811; }
            set { _DAY2811 = value; }
        }
        public double DAY2821
        {
            get { return _DAY2821; }
            set { _DAY2821 = value; }
        }
        public double DAY2831
        {
            get { return _DAY2831; }
            set { _DAY2831 = value; }
        }
        public double DAY2911
        {
            get { return _DAY2911; }
            set { _DAY2911 = value; }
        }
        public double DAY2921
        {
            get { return _DAY2921; }
            set { _DAY2921 = value; }
        }
        public double DAY2931
        {
            get { return _DAY2931; }
            set { _DAY2931 = value; }
        }
        public double DAY3011
        {
            get { return _DAY3011; }
            set { _DAY3011 = value; }
        }
        public double DAY3021
        {
            get { return _DAY3021; }
            set { _DAY3021 = value; }
        }
        public double DAY3031
        {
            get { return _DAY3031; }
            set { _DAY3031 = value; }
        }
        public double DAY3111
        {
            get { return _DAY3111; }
            set { _DAY3111 = value; }
        }
        public double DAY3121
        {
            get { return _DAY3121; }
            set { _DAY3121 = value; }
        }
        public double DAY3131
        {
            get { return _DAY3131; }
            set { _DAY3131 = value; }
        }
 
    }
}
