using System;
using System.Collections;
using SHND.Data.Tables;

namespace SHND.Data.Tables
{
    /// <summary>
    /// Represents a FORMULAFEED data.
    /// [Created by 127.0.0.1 on January,7 2009]
    /// </summary>
    public class FormulaFeedData
    {
        bool _ACTIVE = false ;
        double _CAPACITY = 0;
        double _CAPACITYRATE = 0;
        double _CARBOHYDRATE = 0;
        string _CREATEBY = "";
        DateTime _CREATEON = new DateTime(1, 1, 1);
        double _ENERGY = 0;
        double _ENERGYRATE = 0;
        double _FAT = 0;
        string _FEEDCATEGORY = "";
        double _LOID = 0;
        double _MATERIALMASTER = 0;
        string _NAME = "";
        double _PORTION = 0;
        double _PROTEIN = 0;
        string _UPDATEBY = "";
        DateTime _UPDATEON = new DateTime(1, 1, 1);
        private ArrayList _FormulaFeedItem = new ArrayList();
        private ArrayList _FormulaDisease = new ArrayList();

        public bool ACTIVE
        {
            get { return _ACTIVE; }
            set { _ACTIVE = value; }
        }
        public double CAPACITY
        {
            get { return _CAPACITY; }
            set { _CAPACITY = value; }
        }
        public double CAPACITYRATE
        {
            get { return _CAPACITYRATE; }
            set { _CAPACITYRATE = value; }
        }
        public double CARBOHYDRATE
        {
            get { return _CARBOHYDRATE; }
            set { _CARBOHYDRATE = value; }
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
        public double ENERGY
        {
            get { return _ENERGY; }
            set { _ENERGY = value; }
        }
        public double ENERGYRATE
        {
            get { return _ENERGYRATE; }
            set { _ENERGYRATE = value; }
        }
        public double FAT
        {
            get { return _FAT; }
            set { _FAT = value; }
        }
        public string FEEDCATEGORY
        {
            get { return _FEEDCATEGORY; }
            set { _FEEDCATEGORY = value; }
        }
        public double LOID
        {
            get { return _LOID; }
            set { _LOID = value; }
        }
        public double MATERIALMASTER
        {
            get { return _MATERIALMASTER; }
            set { _MATERIALMASTER = value; }
        }
        public string NAME
        {
            get { return _NAME; }
            set { _NAME = value; }
        }
        public double PORTION
        {
            get { return _PORTION; }
            set { _PORTION = value; }
        }
        public double PROTEIN
        {
            get { return _PROTEIN; }
            set { _PROTEIN = value; }
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
        public ArrayList FormulaFeedItem
        {
            get { return _FormulaFeedItem; }
            set { _FormulaFeedItem = value; }
        }
        public ArrayList FormulaDisease
        {
            get { return _FormulaDisease; }
            set { _FormulaDisease = value; }
        }
    }
}