using System;
using System.Collections.Generic;
using System.Text;
using System.Collections;
using System.Data;

namespace SHND.Data.Common
{

    [Serializable]
    public class UserData
    {
        double _UID = 0; // LOID
        double _TITLE = 0;
        string _UserID = "";
        string _Password = "";
        string _FName = "";
        string _LName = "";
        string _Tel = "";
        string _Email = "";
        string _OfficerGroup = "";
        string _DivisionName = "";
        string _TitleName = "";
        bool _Active = true;
        bool _ForcePWChange = false;
        double _Division = 0;
        DateTime _LastLogon = new DateTime();
        DateTime _LastPWChange = new DateTime();
        DateTime _EFDate = new DateTime();
        DateTime _EPDate = new DateTime();
        DataTable _AllMenu;
        DataTable _GrantMenu;
        DataTable _AllGroup;
        DataTable _GrantGroup;
        DataTable _AllWard;
        DataTable _GrantWard;
        ArrayList _SelectedMenu;
        ArrayList _SelectedGroup;
        ArrayList _SelectedWard;

        Roles  _Role = Roles.Guest;

        public double UID
        {
            get { return _UID; }
            set { _UID = value; }
        }

        public double Title
        {
            get { return _TITLE; }
            set { _TITLE = value; }
        }

        public string UserID
        {
            get { return _UserID; }
            set { _UserID = value; }
        }

        public string Password
        {
            get { return _Password; }
            set { _Password = value; }
        }

        public Roles Role
        {
            get { return _Role; }
            set { _Role = value; }
        }

        public string Name
        {
            get { return _FName + " " + _LName; }
        }

        public string FName
        {
            get { return _FName; }
            set { _FName = value; }
        }

        public string LName
        {
            get { return _LName; }
            set { _LName = value; }
        }

        public string Tel
        {
            get { return _Tel; }
            set { _Tel = value; }
        }

        public string Email
        {
            get { return _Email; }
            set { _Email = value; }
        }

        public string DivisionName
        {
            get { return _DivisionName; }
            set { _DivisionName = value; }
        }

        public string TitleName
        {
            get { return _TitleName; }
            set { _TitleName = value; }
        }

        public bool Active
        {
            get { return _Active; }
            set { _Active = value; }
        }

        public bool ForcePWChange
        {
            get { return _ForcePWChange; }
            set { _ForcePWChange = value; }
        }

        public string OfficerGroup
        {
            get { return _OfficerGroup; }
            set { _OfficerGroup = value; }
        }

        public double Division
        {
            get { return _Division; }
            set { _Division = value; }
        }

        public DateTime LastLogon
        {
            get { return _LastLogon; }
            set { _LastLogon = value; }
        }

        public DateTime LastPWChange
        {
            get { return _LastPWChange; }
            set { _LastPWChange = value; }
        }

        public DateTime EFDate
        {
            get { return _EFDate; }
            set { _EFDate = value; }
        }

        public DateTime EPDate
        {
            get { return _EPDate; }
            set { _EPDate = value; }
        }

        public Roles UserRole
        {
            get { return _Role; }
            set { _Role = value; }
        }

        public DataTable AllMenu
        {
            get { if (_AllMenu == null) _AllMenu = new DataTable(); return _AllMenu; }
            set { _AllMenu = value; }
        }

        public DataTable GrantMenu
        {
            get { if (_GrantMenu == null) _GrantMenu = new DataTable(); return _GrantMenu; }
            set { _GrantMenu = value; }
        }

        public DataTable AllGroup
        {
            get { if (_AllGroup == null) _AllGroup = new DataTable(); return _AllGroup; }
            set { _AllGroup = value; }
        }

        public DataTable GrantGroup
        {
            get { if (_GrantGroup == null) _GrantGroup = new DataTable(); return _GrantGroup; }
            set { _GrantGroup = value; }
        }

        public DataTable AllWard
        {
            get { if (_AllWard == null) _AllWard = new DataTable(); return _AllWard; }
            set { _AllWard = value; }
        }

        public DataTable GrantWard
        {
            get { if (_GrantWard == null) _GrantWard = new DataTable(); return _GrantWard; }
            set { _GrantWard = value; }
        }

        public ArrayList SelectedMenu
        {
            get { if (_SelectedMenu == null) _SelectedMenu = new ArrayList(); return _SelectedMenu; }
            set { _SelectedMenu = value; }
        }

        public ArrayList SelectedGroup
        {
            get { if (_SelectedGroup == null) _SelectedGroup = new ArrayList(); return _SelectedGroup; }
            set { _SelectedGroup = value; }
        }

        public ArrayList SelectedWard
        {
            get { if (_SelectedWard == null) _SelectedWard = new ArrayList(); return _SelectedWard; }
            set { _SelectedWard = value; }
        }

        public enum Roles
        {
            Administrator,
            Doctor,
            Nurse,
            Nutrian,
            Other,
            Guest
        }
    }
}
