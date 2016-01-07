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
            public static string MSGEC001 { get { return GenerateMessage("EC001", "ไม่พบค่าการเชื่อมต่อฐานข้อมูล 'APPCONNECTION' ใน Configuration"); } }
            /// <summary>The connection does not exist.-or- The connection is not open.</summary>
            public static string MSGEC002 { get { return GenerateMessage("EC002", "ไม่สามารถเชื่อมต่อฐานข้อมูลได้"); } }
            /// <summary>Cannot set the connection used by the instance of the command.</summary>
            public static string MSGEC003 { get { return GenerateMessage("EC003", "ไม่สามารถกำหนดการเชื่อมต่อสำหรับคำสั่งทำรายการได้"); } }
            /// <summary>The value was not a valid System.Data.CommandType.</summary>
            public static string MSGEC004 { get { return GenerateMessage("EC004", "ค่าของ System.Data.CommandType ไม่ถูกต้อง"); } }
            /// <summary>The value parameter is null.</summary>
            public static string MSGEC005 { get { return GenerateMessage("EC005", "ไม่ได้กำหนดพารามิเตอร์"); } }
            /// <summary>The parameter specified is already added to this or another parameter collection.</summary>
            public static string MSGEC006 { get { return GenerateMessage("EC006", "พารามิเตอร์ที่ระบุซ้ำกับที่มีอยู่"); } }
            /// <summary>No column with the {0} name was found in {1}.</summary>
            public static string MSGEC007 { get { return GenerateMessage("EC007", "ไม่พบคอลัมน์ {0} ในตาราง {1}"); } }
            /// <summary>The transaction has already been committed or rolled back.-or- The connection is broken.</summary>
            public static string MSGEC008 { get { return GenerateMessage("EC008", "มีการยืนยันหรือยกเลิกข้อมูลระหว่างทำรายการ หรือ การเชื่อมต่อฐานข้อมูลขัดข้อง"); } }
            /// <summary>Parallel transactions are not supported.</summary>
            public static string MSGEC009 { get { return GenerateMessage("EC009", "ไม่สนับสนุนการทำรายการคู่ขนาน"); } }
            /// <summary>Error when execute sql statement.</summary>
            public static string MSGEC010 { get { return GenerateMessage("EC010", "เกิดความผิดพลาดขณะรันคำสั่ง sql"); } }
            /// <summary>Error when build DataReader object.</summary>
            public static string MSGEC011 { get { return GenerateMessage("EC011", "เกิดความผิดพลาดขณะสร้าง DataReader"); } }
            /// <summary>Error when build DataTable object.</summary>
            public static string MSGEC012 { get { return GenerateMessage("EC012", "เกิดความผิดพลาดขณะสร้าง DataTable"); } }
            /// <summary>Error in ExecuteScalar method.</summary>
            public static string MSGEC013 { get { return GenerateMessage("EC013", "เกิดความผิดพลาดขณะรันคำสั่ง ExecuteScalar"); } }
            /// <summary>{0} does not exist in database.</summary>
            public static string MSGEC014 { get { return GenerateMessage("EC014", "ไม่พบตารางหรือวิว {0} ในฐานข้อมูล"); } }

            /// <summary>There are errors occur while insert data.</summary>
            public static string MSGEC101 { get { return GenerateMessage("EC101", "เกิดความผิดพลาดขณะเพิ่มข้อมูลใหม่"); } }
            /// <summary>There are errors occur while update data.</summary>
            public static string MSGEC102 { get { return GenerateMessage("EC102", "เกิดความผิดพลาดขณะบันทึกแก้ไขข้อมูล"); } }
            /// <summary>There are errors occur while delete data."</summary>
            public static string MSGEC103 { get { return GenerateMessage("EC103", "เกิดความผิดพลาดขณะลบข้อมูล"); } }
            /// <summary>There are errors occur while select data."</summary>
            public static string MSGEC104 { get { return GenerateMessage("EC104", "เกิดความผิดพลาดขณะเรียกดูข้อมูล"); } }

            /// <summary>Database error occur {0} -> {1}</summary>
            public static string MSGEC901 { get { return GenerateMessage("EC901", "เกิดความผิดพลาดจากฐานข้อมูล {0} -> {1}"); } }
            /// <summary>Undefined error occur {0}</summary>
            public static string MSGEC902 { get { return GenerateMessage("EC902", "เกิดความผิดพลาดขณะทำรายการ {0}"); } }
        }

        #endregion

        #region Normal Error

        public partial class Error
        {
            /// <summary>Your user name is incorrect. Please try again.</summary>
            public static string MSGEA001 { get { return GenerateMessage("EA001", "ชื่อเข้าระบบไม่ถูกต้อง กรุณาลองอีกครั้ง"); } }
            /// <summary>Your password is incorrect. Please try again.</summary>
            public static string MSGEA002 { get { return GenerateMessage("EA002", "รหัสผ่านไม่ถูกต้อง กรุณาลองอีกครั้ง"); } }
            /// <summary>You are not allowed entering to this system. Please contact your administrator.</summary>
            public static string MSGEA003 { get { return GenerateMessage("EA003", "คุณไม่มีสิทธิเข้าใช้ระบบนี้ กรุณาติดต่อเจ้าหน้าที่ผู้ดูแลระบบ"); } }
            /// <summary>You are not allowed temporarily. Please contact your administrator.</summary>
            public static string MSGEA004 { get { return GenerateMessage("EA004", "คุณไม่มีสิทธิเข้าใช้ระบบในขณะนี้ กรุณาติดต่อเจ้าหน้าที่ผู้ดูแลระบบ"); } }
            /// <summary>There are no any records be deleted.</summary>
            public static string MSGED001 { get { return GenerateMessage("ED001", "ไม่พบรายการที่ถูกลบ"); } }
            /// <summary>Can not delete non-exist data.</summary>
            public static string MSGED002 { get { return GenerateMessage("ED002", "ไม่สามารถลบข้อมูลได้ เนื่องจากไม่พบข้อมูล"); } }
            /// <summary>Can not delete data without conditions</summary>
            public static string MSGED003 { get { return GenerateMessage("ED003", "ไม่สามารถลบข้อมูลได้ เนื่องจากไม่ได้ระบุเงื่อนไข"); } }
            /// <summary>Please enter {0}.</summary>
            public static string MSGEI001 { get { return GenerateMessage("EI001", "กรุณาระบุ {0}"); } }
            /// <summary>Please select {0}.</summary>
            public static string MSGEI002 { get { return GenerateMessage("EI002", "กรุณาเลือก {0}"); } }
            /// <summary>{0} must be equal to {1}.</summary>
            public static string MSGEI003 { get { return GenerateMessage("EI003", "{0} ต้องมีค่าเท่ากับ {1}"); } }
            /// <summary>{0} must be not equal to {1}.</summary>
            public static string MSGEI004 { get { return GenerateMessage("EI004", "{0} ต้องมีค่า ไม่เท่ากับ {1}"); } }
            /// <summary>{0} must be more than {1}.</summary>
            public static string MSGEI005 { get { return GenerateMessage("EI005", "{0} ต้องมีค่ามากกว่า {1}"); } }
            /// <summary>{0} must be more than or equal to {1}.</summary>
            public static string MSGEI006 { get { return GenerateMessage("EI006", "{0} ต้องมีค่ามากกว่าหรือเท่ากับ {1}"); } }
            /// <summary>{0} must be less than {1}.</summary>
            public static string MSGEI007 { get { return GenerateMessage("EI007", "{0} ต้องมีค่าน้อยกว่า {1}"); } }
            /// <summary>{0} must be less than or equal to {1}.</summary>
            public static string MSGEI008 { get { return GenerateMessage("EI008", "{0} ต้องมีค่าน้อยกว่าหรือเท่ากับ {1}"); } }
            /// <summary>The length of {0} must be equal to {1}.</summary>
            public static string MSGEI009 { get { return GenerateMessage("EI009", "{0} ต้องมีความยาว {1} ตัวอักษร"); } }
            /// <summary>The length of {0} must be more than {1}.</summary>
            public static string MSGEI010 { get { return GenerateMessage("EI010", "{0} ต้องมีความยาวมากกว่า {1} ตัวอักษร"); } }
            /// <summary>The length of {0} must be more than or equal to {1}.</summary>
            public static string MSGEI011 { get { return GenerateMessage("EI011", "{0} ต้องมีความยาวมากกว่าหรือเท่ากับ {1} ตัวอักษร"); } }
            /// <summary>The length of {0} must be less than {1}.</summary>
            public static string MSGEI012 { get { return GenerateMessage("EI012", "{0} ต้องมีความยาวน้อยกว่า {1} ตัวอักษร"); } }
            /// <summary>The length of {0} must be less than or equal to {1}.</summary>
            public static string MSGEI013 { get { return GenerateMessage("EI013", "{0} ต้องมีความยาวน้อยกว่าหรือเท่ากับ {1} ตัวอักษร"); } }
            /// <summary>There are no any records be inserted.</summary>
            public static string MSGEN001 { get { return GenerateMessage("EN001", "ไม่พบรายการที่เพิ่มใหม่"); } }
            /// <summary>Can not insert data with duplicate key.</summary>
            public static string MSGEN002 { get { return GenerateMessage("EN002", "ไม่สามารถเพิ่มข้อมูลซ้ำกับที่มีอยู่"); } }
            /// <summary>There are no any records be updated.</summary>
            public static string MSGEU001 { get { return GenerateMessage("EU001", "ไม่พบรายการที่แก้ไข"); } }
            /// <summary>Can not update non-exist data.</summary>
            public static string MSGEU002 { get { return GenerateMessage("EU002", "ไม่สามารถแก้ไขข้อมูลได้ เนื่องจากไม่พบข้อมูล"); } }
            /// <summary>Can not update single record data without primary key conditions.</summary>
            public static string MSGEU003 { get { return GenerateMessage("EU003", "ไม่สามารถแก้ไขข้อมูลได้ เนื่องจากไม่ได้ระบุคีย์หลัก"); } }
            /// <summary>There are no primary key condition for single record select statement."</summary>
            public static string MSGEV001 { get { return GenerateMessage("EV001", "ข้อมูลจากการค้นหาอาจมีมากกว่า 1 รายการ กรุณาระบุคีย์หลัก"); } }
            /// <summary>Data not found.</summary>
            public static string MSGEV002 { get { return GenerateMessage("EV002", "ไม่พบข้อมูลตามเงื่อนไขที่กำหนด"); } }
            /// <summary>The search result has more one rows. Please select other primary key.</summary>
            public static string MSGEV003 { get { return GenerateMessage("EV003", "ข้อมูลจากการค้นหามีมากกว่า 1 รายการ กรุณาเลือกคีย์หลักใหม่"); } }
        }

        #endregion

        #endregion

        #region Confirmation

        public partial class Confirmation
        {
            /// <summary>Are you sure you want to insert new data?</summary>
            public static string MSGCN001 { get { return GenerateMessage("CN001", "ต้องการเพิ่มรายการใช่หรือไม่?"); } }
            /// <summary>Are you sure you wabt to delete this record?</summary>
            public static string MSGCD001 { get { return GenerateMessage("CD001", "ต้องการลบรายการใช่หรือไม่?"); } }
            /// <summary>Are you sure you wabt to delete all records?</summary>
            public static string MSGCD002 { get { return GenerateMessage("CD002", "ต้องการลบรายการทั้งหมดใช่หรือไม่?"); } }
            /// <summary>Are you sure you wabt to delete selected records?</summary>
            public static string MSGCD003 { get { return GenerateMessage("CD003", "ต้องการลบรายการที่เลือกใช่หรือไม่?"); } }
            /// <summary>Are you sure you want to delete the record {0}={1}?</summary>
            public static string MSGCD004 { get { return GenerateMessage("CD004", "ต้องการลบรายการ {0}={1} ใช่หรือไม่?"); } }
        }

        #endregion

        #region Information

        public partial class Information
        {
            /// <summary>Inserting data is completed successfully.</summary>
            public static string MSGIN001 { get { return GenerateMessage("IN001", "เพิ่มข้อมูลเรียบร้อยแล้ว"); } }
            /// <summary>Updating data is completed successfully.</summary>
            public static string MSGIU001 { get { return GenerateMessage("IU001", "แก้ไขข้อมูลเรียบร้อยแล้ว"); } }
            /// <summary>Deleting data is completed successfully.</summary>
            public static string MSGID001 { get { return GenerateMessage("ID001", "ลบข้อมูลเรียบร้อยแล้ว"); } }
        }

        #endregion

        #region Warning

        public partial class Warning
        {
        }

        #endregion

    }
}
