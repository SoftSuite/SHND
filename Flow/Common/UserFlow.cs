using System;
using System.Collections.Generic;
using System.Text;
using System.Security.Cryptography;
using System.Data;
using SHND.DAL.Tables;
using SHND.DAL.Functions;
using SHND.Data.Common;
using zTran = SHND.DAL.Utilities.OracleTransactionDB;

/// <summary>
/// UserFlow Class
/// Version 1.0
/// =========================================================================
/// Create by: TurBoZ
/// Create Date: 25 April 2009
/// -------------------------------------------------------------------------
/// Modify By: -
/// Modify From: -
/// Modify Date: -
/// -------------------------------------------------------------------------
/// Remark: -
/// Description:
///    Flow เกี่ยวกับ User 
/// Changes:
///    1.0 - สร้าง
/// -------------------------------------------------------------------------
/// =========================================================================
/// </summary>
/// 
namespace SHND.Flow.Common
{
    public class UserFlow
    {
        string _error = "";
        bool _pwchange = false;
        bool _active = true;



        public string ErrorMessage { get { return _error; } }
        public bool NeedPasswordChange { get { return _pwchange; } }
        public bool UserActive { get { return _active; } }

        OfficerDAL offDAL;

        public bool Login(string user, string password)
        {
            FunctionDAL fDAL = new FunctionDAL();
            int PW_FAIL_ATTEMP = 0;
            try { PW_FAIL_ATTEMP = Convert.ToInt32(fDAL.GetConfigValue("PW_FAIL_ATTEMP")); }
            catch { }

             _error = "";
            bool ret = true;
            

            if (user.Trim() == "" || password.Trim() == "")
            {
                ret = false;
                _error = "กรุณาระบุชื่อเข้าระบบ และรหัสผ่าน";
            }
            else
            {
                offDAL = new OfficerDAL();
                offDAL.GetDataByUserID(user);
                if (offDAL.OnDB)
                {
                    if (offDAL.PASSWD != GetEncrypt(password))
                    //if (offDAL.PASSWD != password)
                    {
                        ret = false;

                        _error = "รหัสผ่านไม่ถูกต้อง";
                        if (PW_FAIL_ATTEMP > 0)
                        {
                            if (offDAL.LOGINFAILEDCOUNT == PW_FAIL_ATTEMP)
                            {
                                _error = "รหัสผ่านไม่ถูกต้องเกินจำนวนครั้งที่กำหนด กรุณาติดต่อผู้ดูแลระบบ";
                                offDAL.SetActive(offDAL.LOID.ToString(), 0);
                            }
                            else
                                offDAL.IncreasePasswordCount(offDAL.LOID.ToString());
                        }

                    }
                    else
                    {
                        // ..
                        offDAL.SetLastLogin(offDAL.LOID.ToString());
                        _active = (offDAL.ACTIVE == "1");
                        _pwchange = (offDAL.FORCEPWCHANGE == "Y");

                        if (offDAL.PWEXPIREDATE.Year != 1 && offDAL.PWEXPIREDATE < DateTime.Now.Date)
                            _pwchange = true;

                        // ตรวจสอบ user Lock

                        if (!_active)
                        {
                            ret = false;
                            _error = "ชื่อเข้าระบบของท่านถูกระงับการใช้งาน กรุณาติดต่อผู้ดูแลระบบ";
                        }
                        else
                        {
                            offDAL.ResetPasswordCount(offDAL.LOID.ToString());
                            ret = true;
                        }
                    }
                }
                else
                {
                    ret = false;
                    _error = "ไม่พบชื่อผู้ใช้ในระบบ";
                }

            }
            
            return ret;

        }

        public UserData GetUserData(double userLOID)
        {
            offDAL = new OfficerDAL();
            offDAL.GetDataByLOID(userLOID, null);
            return GetUserData();
        }

        public UserData GetUserData(string UserName)
        {
            offDAL = new OfficerDAL();
            offDAL.GetDataByUserID(UserName);
            return GetUserData();
        }

        public UserData GetUserData()
        {
            UserData uData = null;
            if (offDAL != null && offDAL.OnDB )
            {
                uData = new UserData();
                uData.UID = offDAL.LOID;
                uData.Title = offDAL.TITLE;
                uData.UserID = offDAL.USERNAME;
                uData.FName = offDAL.FIRSTNAME;
                uData.LName = offDAL.LASTNAME;
                uData.Tel = offDAL.TEL;
                uData.Email = offDAL.EMAIL;
                uData.OfficerGroup = offDAL.OFFICERGROUP;
                uData.Active = (offDAL.ACTIVE == "1");
                uData.ForcePWChange = (offDAL.FORCEPWCHANGE == "Y");
                uData.LastLogon = offDAL.LASTLOGON;
                uData.LastPWChange = offDAL.LASTPWCHANGE;
                uData.EFDate = offDAL.EFDATE;
                uData.EPDate = offDAL.EPDATE;
                uData.Division = offDAL.DIVISION;
                uData.Role = GetRoleByString(offDAL.OFFICERGROUP);

                uData.AllMenu = offDAL.AllMenu;
                uData.GrantMenu = offDAL.GrantMenu;
                uData.AllGroup = offDAL.AllGroup;
                uData.GrantGroup = offDAL.GrantGroup;
                uData.AllWard = offDAL.AllWard;
                uData.GrantWard = offDAL.GrantWard;

                // get division name
                DivisionDAL divDAL = new DivisionDAL();
                divDAL.GetDataByLOID(offDAL.DIVISION, null);
                if (divDAL.OnDB) uData.DivisionName = divDAL.NAME;

                // get title name
                TitleDAL tDAL = new TitleDAL();
                if (tDAL.OnDB) uData.TitleName = tDAL.NAME;
            }

            return uData;
        }

        public bool SaveUserData(UserData uData, string UserID)
        {
            bool ret = true;

            offDAL = new OfficerDAL();
            offDAL.GetDataByLOID(uData.UID, null);
            offDAL.TITLE = uData.Title;
            offDAL.USERNAME = uData.UserID;
            offDAL.FIRSTNAME = uData.FName;
            offDAL.LASTNAME = uData.LName;
            offDAL.TEL = uData.Tel;
            offDAL.EMAIL = uData.Email;
            offDAL.OFFICERGROUP = uData.OfficerGroup;
            offDAL.ACTIVE = (uData.Active ? "1" : "0");
            offDAL.FORCEPWCHANGE = (uData.ForcePWChange ? "Y" : "N");
            offDAL.EFDATE = uData.EFDate;
            offDAL.EPDATE = uData.EPDate;
            offDAL.DIVISION = uData.Division;

            if (uData.Password != "") offDAL.PASSWD = GetEncrypt(uData.Password);

            zTran trans = new zTran();

            trans.CreateTransaction();

            string err = "";

            ZRoleDAL rDAL = new ZRoleDAL();

            // save officer
            if (offDAL.OnDB)
            {
                ret = offDAL.UpdateCurrentData(UserID, trans.Trans);
                if (!ret) err = offDAL.ErrorMessage;
            }
            else
            {
                ret = offDAL.InsertCurrentData(UserID, trans.Trans);
                if (!ret) err = offDAL.ErrorMessage;
                if (ret)
                {
                    rDAL.OFFICER = offDAL.LOID;
                    rDAL.DESCRIPTION = offDAL.USERNAME;
                    rDAL.ZLEVEL = "U";
                    ret = rDAL.InsertCurrentData(UserID, trans.Trans);
                    if (!ret) err = rDAL.ErrorMessage;
                }
            }

            rDAL = new ZRoleDAL();
            rDAL.GetDataByOfficer(offDAL.LOID, trans.Trans);

            if (!rDAL.OnDB)
            {
                rDAL.OFFICER = offDAL.LOID;
                rDAL.DESCRIPTION = offDAL.USERNAME;
                rDAL.ZLEVEL = "U";
                rDAL.InsertCurrentData(UserID, trans.Trans);
            }

            ZRoleAssignDAL raDAL = new ZRoleAssignDAL();
            raDAL.InsertRoleAssign(uData.SelectedMenu, rDAL.LOID, UserID, trans.Trans);

            ZRoleRefDAL rfDAL = new ZRoleRefDAL();
            rfDAL.InsertRoleRef(uData.SelectedGroup, rDAL.LOID, UserID, trans.Trans);

            WardResponseDAL wDAL = new WardResponseDAL();
            wDAL.InsertWardAssign(uData.SelectedWard, offDAL.LOID, UserID, trans.Trans);

            if (!ret)
            {
                _error = err;
                trans.RollbackTransaction();
            }
            else
                trans.CommitTransaction();

            return ret;
        }

        public bool ChangePassword(string user, string oPassword, string nPassword)
        {
            _error = "";
            bool ret = true;
            OfficerDAL offDAL = new OfficerDAL();
            offDAL.GetDataByUSERNAME(user, null);
            if (offDAL.OnDB)
            {
                if (offDAL.PASSWD != GetEncrypt(oPassword))
                //if (offDAL.PASSWD != oPassword)
                {
                    ret = false;
                    _error = "รหัสผ่านเดิมไม่ถูกต้อง";
                }
                else
                {
                    ret = offDAL.ChangePassword(offDAL.LOID.ToString(), GetEncrypt(nPassword));
                    _error = offDAL.ErrorMessage;
                }

            }
            else
            {
                _error = "ไม่พบชื่อผู้ใช้ที่ระบุ";
                ret = false;
            }

            return ret;
        }

        public static UserData.Roles GetRoleByString(string RoleString)
        {
            UserData.Roles ret = UserData.Roles.Guest;
            switch (RoleString.Trim())
            {
                case "A":
                    ret = UserData.Roles.Administrator;
                    break;

                case "M":
                    ret = UserData.Roles.Doctor;
                    break;

                case "N":
                    ret = UserData.Roles.Nurse;
                    break;

                case "U":
                    ret = UserData.Roles.Nutrian;
                    break;

                case "O":
                    ret = UserData.Roles.Other;
                    break;
            }

            return ret;
        }

        public static string GetRoleString(UserData.Roles UserRole)
        {
            string ret = "";
            switch (UserRole)
            {
                case UserData.Roles.Guest:
                    ret = "";
                    break;

                case UserData.Roles.Other:
                    ret = "O";
                    break;

                case UserData.Roles.Nutrian:
                    ret = "U";
                    break;

                case UserData.Roles.Nurse:
                    ret = "N";
                    break;

                case UserData.Roles.Doctor:
                    ret = "M";
                    break;

                case UserData.Roles.Administrator:
                    ret = "A";
                    break;
            }
            return ret;
        }

        public static string GetRoleName(UserData.Roles UserRole)
        {
            string ret = "";
            switch (UserRole)
            {
                case UserData.Roles.Guest:
                    ret = "ไม่มีสิทธ์";
                    break;

                case UserData.Roles.Other:
                    ret = "หน่วยงานอื่นๆ";
                    break;

                case UserData.Roles.Nutrian:
                    ret = "ฝ่ายโภชนาการ";
                    break;
 
                case UserData.Roles.Nurse:
                    ret = "พยาบาล";
                    break;

                case UserData.Roles.Doctor:
                    ret = "หมอ";
                    break;

                case UserData.Roles.Administrator:
                    ret = "ผู้ดูแลระบบ";
                    break;
            }
            return ret;
        }

        public DataTable GetOfficerList(string UserID, string FName, string LName, string DivisionLOID, string OfficerGroup, string OrderString)
        {
            OfficerDAL offDAL = new OfficerDAL();
            DataTable ret;
            _error = "";
            try
            {
                ret = offDAL.GetOfficerList(UserID, FName, LName, DivisionLOID, OfficerGroup, OrderString);
            }
            catch (Exception ex)
            {
                _error = ex.Message;
                ret = new DataTable();
            }

            return ret;
        }

        public bool DeleteUser(double LOID)
        {
            bool ret = true;

            zTran trans = new zTran();
            trans.CreateTransaction();

            OfficerDAL oDAL = new OfficerDAL();
            oDAL.GetDataByLOID(LOID, trans.Trans);

            if (oDAL.OnDB)
            {

                ZRoleDAL rDAL = new ZRoleDAL();
                rDAL.GetDataByOfficer(oDAL.LOID, trans.Trans);

                if (rDAL.OnDB)
                {
                    ZRoleAssignDAL raDAL = new ZRoleAssignDAL();

                    // DELETE ROLE ASSIGN
                    raDAL.DeleteDataByZROLE(rDAL.LOID, trans.Trans);


                    ZRoleRefDAL refDAL = new ZRoleRefDAL();
                    
                    // DELETE ROLE REF
                    refDAL.DeleteDataByZROLE(rDAL.LOID, trans.Trans);
                }

                // DELETE ROLE
                rDAL.DeleteDataByLOID(rDAL.LOID, trans.Trans);
            }

            // DELETE OFFICER
            ret = ret & oDAL.DeleteCurrentData(trans.Trans);
            if (!ret)
            {
                _error = oDAL.ErrorMessage;
                trans.RollbackTransaction();
            }
            else
                trans.CommitTransaction();

            return ret;
        }

        public DataTable GetAllRoleGroup()
        {
            ZRoleDAL rDAL = new ZRoleDAL();
            return rDAL.GetAllRoleGroup();
        }

        // Private Method
        private const string eKey = "$HNDsystem2009";
        private static byte[] IV = { 5, 10, 15, 20, 40, 60, 80, 90 };
        
        private string GetEncrypt(string zStr)
        {
            string ret = zStr;
            TripleDESCryptoServiceProvider tdsp = new TripleDESCryptoServiceProvider();
            MD5CryptoServiceProvider md5csp = new MD5CryptoServiceProvider();
            byte[] buffer = Encoding.ASCII.GetBytes(zStr);
            tdsp.Key = md5csp.ComputeHash(ASCIIEncoding.ASCII.GetBytes(eKey));
            tdsp.IV = IV;
            ret = Convert.ToBase64String(tdsp.CreateEncryptor().TransformFinalBlock(buffer, 0, buffer.Length));
            return ret;
        }

        private string GetDecrypt(string zEnStr)
        {
            string ret = zEnStr;
            TripleDESCryptoServiceProvider tdsp = new TripleDESCryptoServiceProvider();
            MD5CryptoServiceProvider md5csp = new MD5CryptoServiceProvider();
            byte[] buffer = Encoding.ASCII.GetBytes(zEnStr);
            buffer = Convert.FromBase64String(zEnStr);
            tdsp.Key = md5csp.ComputeHash(ASCIIEncoding.ASCII.GetBytes(eKey));
            tdsp.IV = IV;
            ret = Encoding.ASCII.GetString(tdsp.CreateDecryptor().TransformFinalBlock(buffer, 0, buffer.Length));
            return ret;
        }

    }
}
