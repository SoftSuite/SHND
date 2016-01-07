using System;
using System.Collections.Generic;
using System.Text;

namespace SHND.Data.Common.Utilities
{
    public class Message
    {
        /// private static string _TC### = "";
        /// T - Error Type (E error, C confirmation, W warning I information)
        /// C - Code (C critical, N new data, U update data, D delete data, V view data, F file management, I invalid operation, A authencication)
        /// ### - 3 digits number

        private static string GenerateMessage(string code, string message)
        {
            return "MSG" + code + (message == "" ? "" : " :: ") + message;
        }

        #region Error

        #region CriticalError

        public partial class CriticalError
        {
            /// <summary>Could not retrieve a System.Configuration.ConnectionStringSettingsCollection object.</summary>
            public static string MSGEC001 { get { return GenerateMessage("EC001", "��辺��ҡ���������Ͱҹ������ 'APPCONNECTION' � Configuration"); } }
            /// <summary>The connection does not exist.-or- The connection is not open.</summary>
            public static string MSGEC002 { get { return GenerateMessage("EC002", "�������ö�������Ͱҹ��������"); } }
            /// <summary>Cannot set the connection used by the instance of the command.</summary>
            public static string MSGEC003 { get { return GenerateMessage("EC003", "�������ö��˹����������������Ѻ����觷���¡����"); } }
            /// <summary>The value was not a valid System.Data.CommandType.</summary>
            public static string MSGEC004 { get { return GenerateMessage("EC004", "��Ңͧ System.Data.CommandType ���١��ͧ"); } }
            /// <summary>The value parameter is null.</summary>
            public static string MSGEC005 { get { return GenerateMessage("EC005", "������˹�����������"); } }
            /// <summary>The parameter specified is already added to this or another parameter collection.</summary>
            public static string MSGEC006 { get { return GenerateMessage("EC006", "�������������кث�ӡѺ���������"); } }
            /// <summary>No column with the {0} name was found in {1}.</summary>
            public static string MSGEC007 { get { return GenerateMessage("EC007", "��辺������� {0} 㹵��ҧ {1}"); } }
            /// <summary>The transaction has already been committed or rolled back.-or- The connection is broken.</summary>
            public static string MSGEC008 { get { return GenerateMessage("EC008", "�ա���׹�ѹ����¡��ԡ�����������ҧ����¡�� ���� ����������Ͱҹ�����ŢѴ��ͧ"); } }
            /// <summary>Parallel transactions are not supported.</summary>
            public static string MSGEC009 { get { return GenerateMessage("EC009", "���ʹѺʹع��÷���¡�ä�袹ҹ"); } }
            /// <summary>Error when execute sql statement.</summary>
            public static string MSGEC010 { get { return GenerateMessage("EC010", "�Դ�����Դ��Ҵ����ѹ����� sql"); } }
            /// <summary>Error when build DataReader object.</summary>
            public static string MSGEC011 { get { return GenerateMessage("EC011", "�Դ�����Դ��Ҵ������ҧ DataReader"); } }
            /// <summary>Error when build DataTable object.</summary>
            public static string MSGEC012 { get { return GenerateMessage("EC012", "�Դ�����Դ��Ҵ������ҧ DataTable"); } }
            /// <summary>Error in ExecuteScalar method.</summary>
            public static string MSGEC013 { get { return GenerateMessage("EC013", "�Դ�����Դ��Ҵ����ѹ����� ExecuteScalar"); } }
            /// <summary>{0} does not exist in database.</summary>
            public static string MSGEC014 { get { return GenerateMessage("EC014", "��辺���ҧ������� {0} 㹰ҹ������"); } }

            /// <summary>There are errors occur while insert data.</summary>
            public static string MSGEC101 { get { return GenerateMessage("EC101", "�Դ�����Դ��Ҵ�����������������"); } }
            /// <summary>There are errors occur while update data.</summary>
            public static string MSGEC102 { get { return GenerateMessage("EC102", "�Դ�����Դ��Ҵ��кѹ�֡��䢢�����"); } }
            /// <summary>There are errors occur while delete data."</summary>
            public static string MSGEC103 { get { return GenerateMessage("EC103", "�Դ�����Դ��Ҵ���ź������"); } }
            /// <summary>There are errors occur while select data."</summary>
            public static string MSGEC104 { get { return GenerateMessage("EC104", "�Դ�����Դ��Ҵ������¡�٢�����"); } }

            /// <summary>Database error occur {0} -> {1}</summary>
            public static string MSGEC901 { get { return GenerateMessage("EC901", "�Դ�����Դ��Ҵ�ҡ�ҹ������ {0} -> {1}"); } }
            /// <summary>Undefined error occur {0}</summary>
            public static string MSGEC902 { get { return GenerateMessage("EC902", "�Դ�����Դ��Ҵ��з���¡�� {0}"); } }
        }

        #endregion

        #region Normal Error

        public partial class Error
        {
            /// <summary>Your user name is incorrect. Please try again.</summary>
            public static string MSGEA001 { get { return GenerateMessage("EA001", "��������к����١��ͧ ��س��ͧ�ա����"); } }
            /// <summary>Your password is incorrect. Please try again.</summary>
            public static string MSGEA002 { get { return GenerateMessage("EA002", "���ʼ�ҹ���١��ͧ ��س��ͧ�ա����"); } }
            /// <summary>You are not allowed entering to this system. Please contact your administrator.</summary>
            public static string MSGEA003 { get { return GenerateMessage("EA003", "�س������Է��������к���� ��سҵԴ������˹�ҷ��������к�"); } }
            /// <summary>You are not allowed temporarily. Please contact your administrator.</summary>
            public static string MSGEA004 { get { return GenerateMessage("EA004", "�س������Է��������к�㹢�й�� ��سҵԴ������˹�ҷ��������к�"); } }
            /// <summary>There are no any records be deleted.</summary>
            public static string MSGED001 { get { return GenerateMessage("ED001", "��辺��¡�÷��١ź"); } }
            /// <summary>Can not delete non-exist data.</summary>
            public static string MSGED002 { get { return GenerateMessage("ED002", "�������öź�������� ���ͧ�ҡ��辺������"); } }
            /// <summary>Can not delete data without conditions</summary>
            public static string MSGED003 { get { return GenerateMessage("ED003", "�������öź�������� ���ͧ�ҡ������к����͹�"); } }
            /// <summary>Please enter {0}.</summary>
            public static string MSGEI001 { get { return GenerateMessage("EI001", "��س��к� {0}"); } }
            /// <summary>Please select {0}.</summary>
            public static string MSGEI002 { get { return GenerateMessage("EI002", "��س����͡ {0}"); } }
            /// <summary>{0} must be equal to {1}.</summary>
            public static string MSGEI003 { get { return GenerateMessage("EI003", "{0} ��ͧ�դ����ҡѺ {1}"); } }
            /// <summary>{0} must be not equal to {1}.</summary>
            public static string MSGEI004 { get { return GenerateMessage("EI004", "{0} ��ͧ�դ�� �����ҡѺ {1}"); } }
            /// <summary>{0} must be more than {1}.</summary>
            public static string MSGEI005 { get { return GenerateMessage("EI005", "{0} ��ͧ�դ���ҡ���� {1}"); } }
            /// <summary>{0} must be more than or equal to {1}.</summary>
            public static string MSGEI006 { get { return GenerateMessage("EI006", "{0} ��ͧ�դ���ҡ����������ҡѺ {1}"); } }
            /// <summary>{0} must be less than {1}.</summary>
            public static string MSGEI007 { get { return GenerateMessage("EI007", "{0} ��ͧ�դ�ҹ��¡��� {1}"); } }
            /// <summary>{0} must be less than or equal to {1}.</summary>
            public static string MSGEI008 { get { return GenerateMessage("EI008", "{0} ��ͧ�դ�ҹ��¡���������ҡѺ {1}"); } }
            /// <summary>The length of {0} must be equal to {1}.</summary>
            public static string MSGEI009 { get { return GenerateMessage("EI009", "{0} ��ͧ�դ������ {1} ����ѡ��"); } }
            /// <summary>The length of {0} must be more than {1}.</summary>
            public static string MSGEI010 { get { return GenerateMessage("EI010", "{0} ��ͧ�դ�������ҡ���� {1} ����ѡ��"); } }
            /// <summary>The length of {0} must be more than or equal to {1}.</summary>
            public static string MSGEI011 { get { return GenerateMessage("EI011", "{0} ��ͧ�դ�������ҡ����������ҡѺ {1} ����ѡ��"); } }
            /// <summary>The length of {0} must be less than {1}.</summary>
            public static string MSGEI012 { get { return GenerateMessage("EI012", "{0} ��ͧ�դ�����ǹ��¡��� {1} ����ѡ��"); } }
            /// <summary>The length of {0} must be less than or equal to {1}.</summary>
            public static string MSGEI013 { get { return GenerateMessage("EI013", "{0} ��ͧ�դ�����ǹ��¡���������ҡѺ {1} ����ѡ��"); } }
            /// <summary>There are no any records be inserted.</summary>
            public static string MSGEN001 { get { return GenerateMessage("EN001", "��辺��¡�÷����������"); } }
            /// <summary>Can not insert data with duplicate key.</summary>
            public static string MSGEN002 { get { return GenerateMessage("EN002", "�������ö���������ū�ӡѺ���������"); } }
            /// <summary>There are no any records be updated.</summary>
            public static string MSGEU001 { get { return GenerateMessage("EU001", "��辺��¡�÷�����"); } }
            /// <summary>Can not update non-exist data.</summary>
            public static string MSGEU002 { get { return GenerateMessage("EU002", "�������ö��䢢������� ���ͧ�ҡ��辺������"); } }
            /// <summary>Can not update single record data without primary key conditions.</summary>
            public static string MSGEU003 { get { return GenerateMessage("EU003", "�������ö��䢢������� ���ͧ�ҡ������кؤ�����ѡ"); } }
            /// <summary>There are no primary key condition for single record select statement."</summary>
            public static string MSGEV001 { get { return GenerateMessage("EV001", "�����Ũҡ��ä����Ҩ���ҡ���� 1 ��¡�� ��س��кؤ�����ѡ"); } }
            /// <summary>Data not found.</summary>
            public static string MSGEV002 { get { return GenerateMessage("EV002", "��辺�����ŵ�����͹䢷���˹�"); } }
            /// <summary>The search result has more one rows. Please select other primary key.</summary>
            public static string MSGEV003 { get { return GenerateMessage("EV003", "�����Ũҡ��ä������ҡ���� 1 ��¡�� ��س����͡������ѡ����"); } }
        }

        #endregion

        #endregion

        #region Confirmation

        public partial class Confirmation
        {
            /// <summary>Are you sure you want to insert new data?</summary>
            public static string MSGCN001 { get { return GenerateMessage("CN001", "��ͧ���������¡�����������?"); } }
            /// <summary>Are you sure you wabt to delete this record?</summary>
            public static string MSGCD001 { get { return GenerateMessage("CD001", "��ͧ���ź��¡�����������?"); } }
            /// <summary>Are you sure you wabt to delete all records?</summary>
            public static string MSGCD002 { get { return GenerateMessage("CD002", "��ͧ���ź��¡�÷��������������?"); } }
            /// <summary>Are you sure you wabt to delete selected records?</summary>
            public static string MSGCD003 { get { return GenerateMessage("CD003", "��ͧ���ź��¡�÷�����͡���������?"); } }
            /// <summary>Are you sure you want to delete the record {0}={1}?</summary>
            public static string MSGCD004 { get { return GenerateMessage("CD004", "��ͧ���ź��¡�� {0}={1} ���������?"); } }
        }

        #endregion

        #region Information

        public partial class Information
        {
            /// <summary>Inserting data is completed successfully.</summary>
            public static string MSGIN001 { get { return GenerateMessage("IN001", "�������������º��������"); } }
            /// <summary>Updating data is completed successfully.</summary>
            public static string MSGIU001 { get { return GenerateMessage("IU001", "��䢢��������º��������"); } }
            /// <summary>Deleting data is completed successfully.</summary>
            public static string MSGID001 { get { return GenerateMessage("ID001", "ź���������º��������"); } }
        }

        #endregion

        #region Warning

        public partial class Warning
        {
        }

        #endregion

    }
}
