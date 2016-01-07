using System;
using System.Collections.Generic;
using System.Text;

namespace SHND.Data.Common
{
    public class MenuData
    {
        string _SystemID = "";
        string _GroupID = "";
        string _MenuID = "";
        string _SystemName = "";
        string _GroupName = "";
        string _MenuName = "";
        string _MenuDesc = "";

        public string SystemID
        {
            get { return _SystemID; }
            set { _SystemID = value; }
        }

        public string GroupID
        {
            get { return _GroupID; }
            set { _GroupID = value; }
        }

        public string MenuID
        {
            get { return _MenuID; }
            set { _MenuID = value; }
        }

        public string SystemName
        {
            get { return _SystemName; }
            set { _SystemName = value; }
        }

        public string GroupName
        {
            get { return _GroupName; }
            set { _GroupName = value; }
        }

        public string MenuName
        {
            get { return _MenuName; }
            set { _MenuName = value; }
        }

        public string MenuDesc
        {
            get { return _MenuDesc; }
            set { _MenuDesc = value; }
        }

    }
}
