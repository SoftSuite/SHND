using System;
using System.Data;
using System.Configuration;
using System.Collections;
using System.Web;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Web.UI.WebControls.WebParts;
using System.Web.UI.HtmlControls;
using SHND.Flow.Common;

/// ChangePassword Class
/// Version 1.0
/// =========================================================================
/// Create by: TurBoZ
/// Create Date: 20 May 2009
/// -------------------------------------------------------------------------
/// Modify By: -
/// Modify From: -
/// Modify Date: -
/// -------------------------------------------------------------------------
/// Remark: -
/// Description:
///    Behide Code สำหรับ หน้าเปลี่ยนรหัสผ่าน
/// Changes:
///    1.0 - สร้าง
/// -------------------------------------------------------------------------
/// =========================================================================
/// </summary>
/// 
public partial class SHNDChangePassword : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        txtUserName.Text = Page.User.Identity.Name;
    }
    protected void btnClose_Click(object sender, EventArgs e)
    {
        zPop.Hide();
        if (txtLogout.Text == "yes")
        {
            FormsAuthentication.SignOut();
            Response.Redirect(FormsAuthentication.LoginUrl + (Request["ReturnUrl"] != null && Request["ReturnUrl"] != "" ? "?ReturnUrl=" + Request["ReturnUrl"] + "" : ""));
        }
    }
    protected void btnChangePassword_Click(object sender, EventArgs e)
    {
        txtLogout.Text = "";
        lblError.Text = "";
        if (txtOPass.Text.Trim() == "" || txtNPass.Text.Trim() == "" || txtCPass.Text.Trim() == "")
        {
            lblError.Text = "กรุณากรอกข้อมูลให้ครบถ้วน";
        }
        else if (txtNPass.Text != txtCPass.Text)
        {
            lblError.Text = "ยืนยันรหัสผ่านไม่ถูกต้อง";
        }
        if (lblError.Text.Trim() == "")
        {
            UserFlow uFlow = new UserFlow();
            if (!uFlow.ChangePassword(txtUserName.Text, txtOPass.Text, txtNPass.Text))
                lblError.Text = uFlow.ErrorMessage;
            else
            {
                lblError.Text = "เปลี่ยนรหัสผ่านเรียบร้อย กรุณาเข้าระบบใหม่อีกครั้ง";
                txtLogout.Text = "yes";
            }

        }
        zPop.Show();
        tbError.Visible = true;

    }
}
