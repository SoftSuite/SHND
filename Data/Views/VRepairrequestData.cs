using System;
using System.Collections.Generic;
using System.Text;

namespace SHND.Data.Views
{
    /// <summary>
    /// Represents a V_REPAIRREQUEST data.
    /// [Created by 127.0.0.1 on Febuary,12 2009]
    /// </summary>
    public class VRepairrequestData
    {
        string _LOTNO = "";
        string _MATERIALCODE = "";
        double _MATERIALGROUP = 0;
        string _MATERIALNAME = "";
        double _SRLOID = 0;
        string _UNITNAME = "";

        public string LOTNO
        {
            get { return _LOTNO; }
            set { _LOTNO = value; }
        }
        public string MATERIALCODE
        {
            get { return _MATERIALCODE; }
            set { _MATERIALCODE = value; }
        }
        public double MATERIALGROUP
        {
            get { return _MATERIALGROUP; }
            set { _MATERIALGROUP = value; }
        }
        public string MATERIALNAME
        {
            get { return _MATERIALNAME; }
            set { _MATERIALNAME = value; }
        }
        public double SRLOID
        {
            get { return _SRLOID; }
            set { _SRLOID = value; }
        }
        public string UNITNAME
        {
            get { return _UNITNAME; }
            set { _UNITNAME = value; }
        }
    }
}
