using System;
using System.Collections.Generic;
using System.Text;

namespace SHND.Data.Common.Utilities
{
    public class DataResources
    {
        public static string CultureName
        {
            get
            {
                try
                {
                    if (System.Web.HttpContext.Current.Session[Constant.CultureSessionID] == null) System.Web.HttpContext.Current.Session[Constant.CultureSessionID] = Constant.CultureName.Default;
                    return System.Web.HttpContext.Current.Session[Constant.CultureSessionID].ToString();
                }
                catch
                {
                    return Constant.CultureName.Default;
                }
            }
            set
            {
                System.Web.HttpContext.Current.Session[Constant.CultureSessionID] = value;
            }
        }

        public static string GetCultureText(string EnglishName, string ThaiName)
        {
            return (CultureName == Constant.CultureName.English ? EnglishName : ThaiName);
        }

        #region Message

        private static string GenerateMessage(string code, string message)
        {
            //return "MSG" + code + (message == "" ? "" : " :: ") + message;
            return message;
        }

        #region Error

        #region Critical Error
        /// <summary>Cannot not retrieve a System.Configuration.ConnectionStringSettingsCollection object.</summary>
        public static string MSGEC001
        {
            get { return GenerateMessage("EC001", GetCultureText("Cannot not retrieve a System.Configuration.ConnectionStringSettingsCollection object.", "��辺��ҡ���������Ͱҹ������� Configuration")); }
        }
        /// <summary>The connection does not exist.-or- The connection is not open.</summary>
        public static string MSGEC002
        {
            get { return GenerateMessage("EC002", GetCultureText("The connection does not exist.-or- The connection is not open.", "�������ö�������Ͱҹ��������")); }
        }
        /// <summary>Cannot set the connection used by the instance of the command.</summary>
        public static string MSGEC003
        {
            get { return GenerateMessage("EC003", GetCultureText("Cannot set the connection used by the instance of the command.", "�������ö��˹����������������Ѻ����觷���¡����")); }
        }
        /// <summary>The value was not a valid System.Data.CommandType.</summary>
        public static string MSGEC004
        {
            get { return GenerateMessage("EC004", GetCultureText("The value was not a valid System.Data.CommandType.", "��Ңͧ System.Data.CommandType ���١��ͧ")); }
        }
        /// <summary>The value of parameter is null.</summary>
        public static string MSGEC005
        {
            get { return GenerateMessage("EC005", GetCultureText("The value of parameter is null.", "������˹�����������")); }
        }
        /// <summary>The parameter specified is already added to this or another parameter collection.</summary>
        public static string MSGEC006
        {
            get { return GenerateMessage("EC006", GetCultureText("The parameter specified is already added to this or another parameter collection.", "�������������кث�ӡѺ���������")); }
        }
        /// <summary>No column with the {0} name was found in {1}.</summary>
        public static string MSGEC007
        {
            get { return GenerateMessage("EC007", GetCultureText("No column with the {0} name was found in {1}.", "��辺������� {0} 㹵��ҧ {1}")); }
        }
        /// <summary>The transaction has already been committed or rolled back.-or- The connection is broken.</summary>
        public static string MSGEC008
        {
            get { return GenerateMessage("EC008", GetCultureText("The transaction has already been committed or rolled back.-or- The connection is broken.", "�ա���׹�ѹ����¡��ԡ�����������ҧ����¡�� ���� ����������Ͱҹ�����ŢѴ��ͧ")); }
        }
        /// <summary>Parallel transactions are not supported.</summary>
        public static string MSGEC009
        {
            get { return GenerateMessage("EC009", GetCultureText("Parallel transactions are not supported.", "���ʹѺʹع��÷���¡�ä�袹ҹ")); }
        }
        /// <summary>Error when execute sql statement.</summary>
        public static string MSGEC010
        {
            get { return GenerateMessage("EC010", GetCultureText("Error when execute sql statement.", "�Դ�����Դ��Ҵ����ѹ����� sql")); }
        }
        /// <summary>Error when build DataReader object.</summary>
        public static string MSGEC011
        {
            get { return GenerateMessage("EC011", GetCultureText("Error when build DataReader object.", "�Դ�����Դ��Ҵ������ҧ DataReader")); }
        }
        /// <summary>Error when build DataTable object.</summary>
        public static string MSGEC012
        {
            get { return GenerateMessage("EC012", GetCultureText("Error when build DataTable object.", "�Դ�����Դ��Ҵ������ҧ DataTable")); }
        }
        /// <summary>Error in ExecuteScalar method.</summary>
        public static string MSGEC013
        {
            get { return GenerateMessage("EC013", GetCultureText("Error in ExecuteScalar method.", "�Դ�����Դ��Ҵ����ѹ����� ExecuteScalar")); }
        }
        /// <summary>{0} does not exist in database.</summary>
        public static string MSGEC014
        {
            get { return GenerateMessage("EC014", GetCultureText("{0} does not exist in database.", "��辺���ҧ������� {0} 㹰ҹ������")); }
        }
        /// <summary>Cannot download the resource as aSystem.Uri.</summary>
        public static string MSGEC015
        {
            get { return GenerateMessage("EC015", GetCultureText("Cannot download the resource as a System.Uri.", "�������ö��ǹ���Ŵ�����Ũҡ���·ҧ��")); }
        }

        /// <summary>There are errors occur while insert data.</summary>
        public static string MSGEC101
        {
            get { return GenerateMessage("EC101", GetCultureText("There are errors occur while insert data.", "�Դ�����Դ��Ҵ�����������������")); }
        }
        /// <summary>There are errors occur while update data.</summary>
        public static string MSGEC102
        {
            get { return GenerateMessage("EC102", GetCultureText("There are errors occur while update data.", "�Դ�����Դ��Ҵ��кѹ�֡��䢢�����")); }
        }
        /// <summary>There are errors occur while delete data.</summary>
        public static string MSGEC103
        {
            get { return GenerateMessage("EC103", GetCultureText("There are errors occur while delete data.", "�Դ�����Դ��Ҵ���ź������")); }
        }
        /// <summary>There are errors occur while select data.</summary>
        public static string MSGEC104
        {
            get { return GenerateMessage("EC104", GetCultureText("There are errors occur while select data.", "�Դ�����Դ��Ҵ������¡�٢�����")); }
        }
        /// <summary>There are errors occur while importing excel data.</summary>
        public static string MSGEC105
        {
            get { return GenerateMessage("EC105", GetCultureText("There are errors occur while importing excel data.", "�Դ�����Դ��Ҵ��й���Ң����� �ҡ Excel")); }
        }
        /// <summary>There are errors occur while initial process.</summary>
        public static string MSGEC106
        {
            get { return GenerateMessage("EC106", GetCultureText("There are errors occur while initial process.", "�Դ�����Դ��Ҵ㹡�á�˹����������������������кǹ���")); }
        }
        /// <summary>There are errors occur while loging in.</summary>
        public static string MSGES001
        {
            get { return GenerateMessage("ES001", GetCultureText("There are errors occur while loging in", "�Դ�����Դ��Ҵ����������к�")); }
        }
        /// <summary>There are errors occur while changing password.</summary>
        public static string MSGES002
        {
            get { return GenerateMessage("ES002", GetCultureText("There are errors occur while changing password", "�Դ�����Դ��Ҵ�������¹���ʼ�ҹ")); }
        }

        /// <summary>Database error occur {0} -> {1}</summary>
        public static string MSGEC901
        {
            get { return GenerateMessage("EC901", GetCultureText("Database error occur {0} -> {1}", "�Դ�����Դ��Ҵ㹡�õԴ��Ͱҹ������ {0} -> {1}")); }
        }
        /// <summary>Undefined error occur {0}</summary>
        public static string MSGEC902
        {
            get { return GenerateMessage("EC902", GetCultureText("Undefined error occur {0}", "�Դ�����Դ��Ҵ��з���¡�� {0}")); }
        }
        #endregion

        #region Business Error
        /// <summary>Your user name is incorrect. Please try again.</summary>
        public static string MSGEA001
        {
            get { return GenerateMessage("EA001", GetCultureText("Your user name is incorrect. Please try again.", "��������к����١��ͧ ��س��ͧ�ա����")); }
        }
        /// <summary>Your password is incorrect. Please try again.</summary>
        public static string MSGEA002
        {
            get { return GenerateMessage("EA002", GetCultureText("Your password is incorrect. Please try again.", "���ʼ�ҹ���١��ͧ ��س��ͧ�ա����")); }
        }
        /// <summary>You are not allowed entering to this system. Please contact your administrator.</summary>
        public static string MSGEA003
        {
            get { return GenerateMessage("EA003", GetCultureText("You are not allowed entering to this system. Please contact your administrator.", "�س������Է��������к���� ��سҵԴ������˹�ҷ��������к�")); }
        }
        /// <summary>You are not allowed temporarily. Please contact your administrator.</summary>
        public static string MSGEA004
        {
            get { return GenerateMessage("EA004", GetCultureText("You are not allowed temporarily. Please contact your administrator.", "�س������Է��������к�㹢�й�� ��سҵԴ������˹�ҷ��������к�")); }
        }
        /// <summary>There are no any records be deleted.</summary>
        public static string MSGED001
        {
            get { return GenerateMessage("ED001", GetCultureText("There are no any records be deleted.", "��辺��¡�÷��١ź")); }
        }
        /// <summary>Can not delete non-exist data.</summary>
        public static string MSGED002
        {
            get { return GenerateMessage("ED002", GetCultureText("Can not delete non-exist data.", "�������öź�������� ���ͧ�ҡ��辺������")); }
        }
        /// <summary>Can not delete data without conditions</summary>
        public static string MSGED003
        {
            get { return GenerateMessage("ED003", GetCultureText("Can not delete data without conditions", "�������öź�������� ���ͧ�ҡ������к����͹�")); }
        }
        /// <summary>{0} is required. (for textbox)</summary>
        public static string MSGEI001
        {
            get { return GenerateMessage("EI001", GetCultureText("{0} is required.", "��س��к� {0}")); }
        }
        /// <summary>{0} is required. (for dropdownlist, calendar, control list)</summary>
        public static string MSGEI002
        {
            get { return GenerateMessage("EI002", GetCultureText("{0} is required.", "��س����͡ {0}")); }
        }
        /// <summary>{0} must be equal to {1}.</summary>
        public static string MSGEI003
        {
            get { return GenerateMessage("EI003", GetCultureText("{0} must be equal to {1}.", "{0} ��ͧ��ҡѺ {1}")); }
        }
        /// <summary>{0} must be not equal to {1}.</summary>
        public static string MSGEI004
        {
            get { return GenerateMessage("EI004", GetCultureText("{0} must be not equal to {1}.", "{0} ��ͧ�����ҡѺ {1}")); }
        }
        /// <summary>{0} must be more than {1}.</summary>
        public static string MSGEI005
        {
            get { return GenerateMessage("EI005", GetCultureText("{0} must be more than {1}.", "{0} ��ͧ�ҡ���� {1}")); }
        }
        /// <summary>{0} must be more than or equal to {1}.</summary>
        public static string MSGEI006
        {
            get { return GenerateMessage("EI006", GetCultureText("{0} must be more than or equal to {1}.", "{0} ��ͧ�ҡ����������ҡѺ {1}")); }
        }
        /// <summary>{0} must be less than {1}.</summary>
        public static string MSGEI007
        {
            get { return GenerateMessage("EI007", GetCultureText("{0} must be less than {1}.", "{0} ��ͧ���¡��� {1}")); }
        }
        /// <summary>{0} must be less than or equal to {1}.</summary>
        public static string MSGEI008
        {
            get { return GenerateMessage("EI008", GetCultureText("{0} must be less than or equal to {1}.", "{0} ��ͧ���¡���������ҡѺ {1}")); }
        }
        /// <summary>The length of {0} must be equal to {1}.</summary>
        public static string MSGEI009
        {
            get { return GenerateMessage("EI009", GetCultureText("The length of {0} must be equal to {1}.", "{0} ��ͧ�դ������ {1} ����ѡ��")); }
        }
        /// <summary>The length of {0} must be more than {1}.</summary>
        public static string MSGEI010
        {
            get { return GenerateMessage("EI010", GetCultureText("The length of {0} must be more than {1}.", "{0} ��ͧ�դ�������ҡ���� {1} ����ѡ��")); }
        }
        /// <summary>The length of {0} must be more than or equal to {1}.</summary>
        public static string MSGEI011
        {
            get { return GenerateMessage("EI011", GetCultureText("The length of {0} must be more than or equal to {1}.", "{0} ��ͧ�դ�������ҡ����������ҡѺ {1} ����ѡ��")); }
        }
        /// <summary>The length of {0} must be less than {1}.</summary>
        public static string MSGEI012
        {
            get { return GenerateMessage("EI012", GetCultureText("The length of {0} must be less than {1}.", "{0} ��ͧ�դ�����ǹ��¡��� {1} ����ѡ��")); }
        }
        /// <summary>The length of {0} must be less than or equal to {1}.</summary>
        public static string MSGEI013
        {
            get { return GenerateMessage("EI013", GetCultureText("The length of {0} must be less than or equal to {1}.", "{0} ��ͧ�դ�����ǹ��¡���������ҡѺ {1} ����ѡ��")); }
        }
        /// <summary>{0} must be same as {1}.</summary>
        public static string MSGEI014
        {
            get { return GenerateMessage("EI014", GetCultureText("{0} must be same as {1}.", "{0} ��ͧ�ç�Ѻ {1}")); }
        }
        /// <summary>{0} = {1} has already existed in the system.</summary>
        public static string MSGEI015
        {
            get { return GenerateMessage("EI015", GetCultureText("{0} \"{1}\" has already existed in system.", "{0} \"{1}\" ��ӡѺ�����������к�")); }
        }
        /// <summary>{0} = {1} and {2} = {3} has already existed in the system}.</summary>
        public static string MSGEI016
        {
            get { return GenerateMessage("EI016", GetCultureText("{0} \"{1}\" and {2} \"{3}\" has already existed in the system", "{0} \"{1}\" ��� {2} \"{3}\" ��ӡѺ�����������к�")); }
        }
        /// <summary>{0} = {1}, {2} = {3} and {4} = {5} has already existed in the system}.</summary>
        public static string MSGEI017
        {
            get { return GenerateMessage("EI017", GetCultureText("{0} \"{1}\", {2} \"{3}\" and {4} \"{5}\" has already existed in the system", "{0} \"{1}\", {2} \"{3}\" ��� {4} \"{5}\" ��ӡѺ�����������к�")); }
        }
        /// <summary>{0} = {1}, {2} = {3}, {4} = {5} and {6} = {7} has already existed in the system}.</summary>
        public static string MSGEI018
        {
            get { return GenerateMessage("EI018", GetCultureText("{0} \"{1}\", {2} \"{3}\", {4} \"{5}\" and {6} \"{7}\" has already existed in the system", "{0} \"{1}\", {2} \"{3}\", {4} \"{5}\" ��� {6} \"{7}\" ��ӡѺ�����������к�")); }
        }
        /// <summary>There are no any records be inserted.</summary>
        public static string MSGEN001
        {
            get { return GenerateMessage("EN001", GetCultureText("There are no any records be inserted.", "��辺��¡�÷����������")); }
        }
        /// <summary>Can not insert data with duplicate key.</summary>
        public static string MSGEN002
        {
            get { return GenerateMessage("EN002", GetCultureText("Can not insert data with duplicate key.", "�������ö���������ū�ӡѺ���������")); }
        }
        /// <summary>There are no any records be updated.</summary>
        public static string MSGEU001
        {
            get { return GenerateMessage("EU001", GetCultureText("There are no any records be updated.", "��辺��¡�÷�����")); }
        }
        /// <summary>Can not update non-exist data.</summary>
        public static string MSGEU002
        {
            get { return GenerateMessage("EU002", GetCultureText("Can not update non-exist data.", "�������ö��䢢������� ���ͧ�ҡ��辺������")); }
        }
        /// <summary>Can not update single record data without primary key conditions.</summary>
        public static string MSGEU003
        {
            get { return GenerateMessage("EU003", GetCultureText("Can not update single record data without primary key conditions.", "�������ö��䢢������� ���ͧ�ҡ������кؤ�����ѡ")); }
        }
        /// <summary>There are no primary key condition for single record select statement.</summary>
        public static string MSGEV001
        {
            get { return GenerateMessage("EV001", GetCultureText("There are no primary key condition for single record select statement.", "�����Ũҡ��ä����Ҩ���ҡ���� 1 ��¡�� ��س��кؤ�����ѡ")); }
        }
        /// <summary>Data not found.</summary>
        public static string MSGEV002
        {
            get { return GenerateMessage("EV002", GetCultureText("Data not found.", "��辺�����ŵ�����͹䢷���˹�")); }
        }
        /// <summary>The search result has more one rows. Please select other primary key.</summary>
        public static string MSGEV003
        {
            get { return GenerateMessage("EV003", GetCultureText("The search result has more one rows. Please select other primary key.", "�����Ũҡ��ä������ҡ���� 1 ��¡�� ��س����͡������ѡ����")); }
        }
        #endregion

        #endregion

        #region Confirmation

        /// <summary>Are you sure you want to insert new data?</summary>
        public static string MSGCN001
        {
            get { return GenerateMessage("CN001", GetCultureText("Are you sure you want to insert new data?", "��ͧ���������¡�����������?")); }
        }
        /// <summary>Are you sure you want to delete this record?</summary>
        public static string MSGCD001
        {
            get { return GenerateMessage("CD001", GetCultureText("Are you sure you want to delete this record?", "��ͧ���ź��¡�����������?")); }
        }
        /// <summary>Are you sure you want to delete all records?</summary>
        public static string MSGCD002
        {
            get { return GenerateMessage("CD002", GetCultureText("Are you sure you want to delete all records?", "��ͧ���ź��¡�÷��������������?")); }
        }
        /// <summary>Are you sure you want to delete selected records?</summary>
        public static string MSGCD003
        {
            get { return GenerateMessage("CD003", GetCultureText("Are you sure you want to delete selected records?", "��ͧ���ź��¡�÷�����͡���������?")); }
        }
        /// <summary>Are you sure you want to delete the record {0}={1}?</summary>
        public static string MSGCD004
        {
            get { return GenerateMessage("CD004", GetCultureText("Are you sure you want to delete the record {0} \"{1}\"?", "��ͧ���ź��¡�� {0} \"{1}\" ���������?")); }
        }
        /// <summary>Are you sure you want to copy the record {0} "{1}"?</summary>
        public static string MSGCC001
        {
            get { return GenerateMessage("CC001", GetCultureText("Are you sure you want to copy the record {0} \"{1}\"?", "��ͧ��äѴ�͡��¡�� {0} \"{1}\" ���������?")); }
        }
        /// <summary>Are you sure you want to log out?</summary>
        public static string MSGCS001
        {
            get { return GenerateMessage("CS001", GetCultureText("Are you sure you want to log out?", "��ͧ����͡�ҡ�к����������?")); }
        }

        #endregion

        #region Information
        /// <summary>Inserting data is completed successfully.</summary>
        public static string MSGIN001
        {
            get { return GenerateMessage("IN001", GetCultureText("Inserting data is completed successfully.", "�������������º��������")); }
        }
        /// <summary>Updating data is completed successfully.</summary>
        public static string MSGIU001
        {
            get { return GenerateMessage("IU001", GetCultureText("Updating data is completed successfully.", "��䢢��������º��������")); }
        }
        /// <summary>Updating data is completed successfully.</summary>
        public static string MSGIR001
        {
            get { return GenerateMessage("IR001", GetCultureText("Updating data is completed successfully.", "������ͧ���º��������")); }
        }
        /// <summary>Deleting data is completed successfully.</summary>
        public static string MSGID001
        {
            get { return GenerateMessage("ID001", GetCultureText("Deleting data is completed successfully.", "ź���������º��������")); }
        }
        /// <summary>Changing password is completed successfully.</summary>
        public static string MSGIS001
        {
            get { return GenerateMessage("ID001", GetCultureText("Changing password is completed successfully.", "����¹���ʼ�ҹ���º��������")); }
        }

        #endregion

        #endregion

        #region Constant
        public static string Anonymous
        {
            get { return GetCultureText("Anonymous", "�ؤ�ŷ����"); }
        }
        public static string Cancel
        {
            get { return GetCultureText("Cancel", "¡��ԡ"); }
        }
        public static string ChangePassword
        {
            get { return GetCultureText("Change Password", "���¹���ʼ�ҹ"); }
        }
        public static string CopyRight
        {
            get { return GetCultureText("Copyright &copy; All Rights Reserved.<br>Dept. of Intellectual Property, Ministry of Commerce<br>44/100 Nonthaburi 1 Rd., Bangkrasor, Muang, Nonthaburi, Thailand 11000.", "ʧǹ�Ԣ�Է��� &copy; �� �����Ѿ���Թ�ҧ�ѭ��<br>44/100 ���������� 1 �.�ҧ����� �.���ͧ �.������� 11000"); }
        }
        public static string EditProfile
        {
            get { return GetCultureText("Edit Profile", "��䢢�������ǹ���"); }
        }
        public static string EmptyDataText
        {
            get { return GetCultureText("<center>***Data Not Found***</center>", "<center>***��辺������***</center>"); }
        }
        public static string Home
        {
            get { return GetCultureText("Home", "��Ѻ˹����ѡ"); }
        }
        public static string LogIn
        {
            get { return GetCultureText("Log In", "ŧ���������"); }
        }
        public static string LoginRequire
        {
            get { return GetCultureText("You are not logged in.", "��س�ŧ����������к�"); }
        }
        public static string OK
        {
            get { return GetCultureText("OK", "��ŧ"); }
        }
        public static string AutherizeRequire
        {
            get { return GetCultureText("You are not allowed to access this page.", "�س������Է��������ҹ���ǹ���"); }
        }
        public static string Login_OfficerCheckBox
        {
            get { return GetCultureText("For officer only", "����Ѻ���˹�ҷ��"); }
        }
        public static string Login_Password
        {
            get { return GetCultureText("Password  :&nbsp;&nbsp;", "���ʼ�ҹ  :&nbsp;&nbsp;"); }
        }
        public static string Login_UserID
        {
            get { return GetCultureText("User ID  :&nbsp;&nbsp;", "���ͼ����  :&nbsp;&nbsp;"); }
        }
        public static string LogOut
        {
            get { return GetCultureText("Log Out", "�͡�ҡ�к�"); }
        }
        public static string LoggedOut
        {
            get { return GetCultureText("You are logged out.", "�͡�ҡ�к����º��������"); }
        }
        public static string Register
        {
            get { return GetCultureText("Register", "��Ѥ���Ҫԡ"); }
        }
        public static string SearchHeader
        {
            get { return GetCultureText("Search Criteria", "����"); }
        }
        public static string Thai
        {
            get { return "��"; }
        }
        /// <summary>Please wait while processing ...</summary>
        public static string Wait
        {
            get { return GetCultureText("Please wait while processing ...", "��س����ѡ����..."); }
        }
        public static string Welcome
        {
            get { return GetCultureText("Welcome", "�Թ�յ�͹�Ѻ"); }
        }
        public static string DownloadManual
        {
            get { return GetCultureText("Download User Manual", "��ǹ���Ŵ�����͡����ҹ"); }
        }
        public static string ContactAdmin
        {
            get { return GetCultureText("Contact System Administrator", "�Դ��ͼ������к�"); }
        }
        #endregion
    }
}
