using System;

namespace SHND.Data.Views
{
    /// <summary>
    /// Represents a V_MILKCODE_SEARCH data.
    /// [Created by 127.0.0.1 on January,30 2009]
    /// </summary>
    public class VMilkCodeSearchData
    {
        double _LOID = 0;
        string _MILKCODE = "";
        string _NAME = "";

        public double LOID
        {
            get { return _LOID; }
            set { _LOID = value; }
        }
        public string MILKCODE
        {
            get { return _MILKCODE; }
            set { _MILKCODE = value; }
        }
        public string NAME
        {
            get { return _NAME; }
            set { _NAME = value; }
        }
    }
}