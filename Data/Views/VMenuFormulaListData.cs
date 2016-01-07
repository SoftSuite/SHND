using System;

namespace SHND.Data.Views
{
    /// <summary>
    /// Represents a V_MENU_FORMULA_LIST data.
    /// [Created by ::1 on July,9 2009]
    /// </summary>
    public class VMenuFormulaListData
    {
        string _FORMULANAME = "";
        string _GROUPNAME = "";
        string _GROUPORDER = "";
        string _GROUPTYPE = "";
        string _MEAL = "";
        string _MEALNAME = "";
        double _MENU = 0;
        DateTime _MENUDATE = new DateTime(1, 1, 1);
        string _REFTYPE = "";

        public string FORMULANAME
        {
            get { return _FORMULANAME; }
            set { _FORMULANAME = value; }
        }
        public string GROUPNAME
        {
            get { return _GROUPNAME; }
            set { _GROUPNAME = value; }
        }
        public string GROUPORDER
        {
            get { return _GROUPORDER; }
            set { _GROUPORDER = value; }
        }
        public string GROUPTYPE
        {
            get { return _GROUPTYPE; }
            set { _GROUPTYPE = value; }
        }
        public string MEAL
        {
            get { return _MEAL; }
            set { _MEAL = value; }
        }
        public string MEALNAME
        {
            get { return _MEALNAME; }
            set { _MEALNAME = value; }
        }
        public double MENU
        {
            get { return _MENU; }
            set { _MENU = value; }
        }
        public DateTime MENUDATE
        {
            get { return _MENUDATE; }
            set { _MENUDATE = value; }
        }
        public string REFTYPE
        {
            get { return _REFTYPE; }
            set { _REFTYPE = value; }
        }
    }
}