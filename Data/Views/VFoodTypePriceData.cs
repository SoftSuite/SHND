using System;
using System.Collections;
using System.Data;

namespace SHND.Data.Views
{
    /// <summary>
    /// Represents a V_FOODTYPEPRICE data.
    /// [Created by 127.0.0.1 on March,27 2009]
    /// </summary>
    public class VFoodTypePriceData
    {
        string _ACTIVE = "";
        string _CODE = "";
        double _DIVISION = 0;
        string _DIVISIONNAME = "";
        double _LOID = 0;
        string _NAME = "";
        double _PRICE = 0;
        string _PRICETYPE = "";
        ArrayList _FoodTypePriceList = new ArrayList();

        public string ACTIVE
        {
            get { return _ACTIVE; }
            set { _ACTIVE = value; }
        }
        public string CODE
        {
            get { return _CODE; }
            set { _CODE = value; }
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
        public ArrayList FoodTypePriceList
        {
            get { return _FoodTypePriceList; }
            set { _FoodTypePriceList = value; }
        }
    }
}