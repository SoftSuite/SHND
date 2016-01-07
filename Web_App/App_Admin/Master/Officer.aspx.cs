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
using SHND.Flow.Admin;
using SHND.Flow.Common;
using SHND.Data.Common;
using SHND.Data.Views;
using SHND.Global;
using SHND.Data.Common.Utilities;

/// <summary>
/// Officer Page Class
/// Version 1.0
/// =========================================================================
/// Create by: TurBoZ
/// Create Date: 26 May 2009
/// -------------------------------------------------------------------------
/// Modify By: -
/// Modify From: -
/// Modify Date: -
/// -------------------------------------------------------------------------
/// Remark: -
/// Description:
///    หน้ากาารทำงานข้อมูล Officer
/// Changes:
///    1.0 - สร้าง
/// -------------------------------------------------------------------------
/// =========================================================================
/// </summary>
/// 
public partial class App_Admin_Master_Officer : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            doGetList();
            ClearData();
            
        }
    }

    protected override void OnInit(EventArgs e)
    {
        base.OnInit(e);
        Appz.BuildCombo(cmbDivision, "V_DIVISION_SEARCH", "NAME", "LOID", "ACTIVE='1'", "NAME", "เลือก", "0", false);
        Appz.BuildCombo(cmbSDivision, "V_DIVISION_SEARCH", "NAME", "LOID", "ACTIVE='1'", "NAME", "ทั้งหมด", "", false);
        Appz.BuildCombo(cmbTitle, "TITLE", "NAME", "LOID", "ACTIVE='1'", "", "เลือก", "0", false);
        pcTop.SetMainGridView(gvMain);
        pcBot.SetMainGridView(gvMain);

    }

    #region Button Click Event Handler
    protected void tbAddClick(object sender, EventArgs e)
    {

    }
    protected void tbSaveClick(object sender, EventArgs e)
    {
        if (doSaveData())
        {
            doGetList();
            ClearData();
            zPop.Hide();
        }
        else
        {
            zPop.Show();
        }

    }
    protected void tbCancelClick(object sender, EventArgs e)
    {

    }
    protected void tbBackClick(object sender, EventArgs e)
    {
        ClearData();
    }
    protected void imbSearch_Click1(object sender, ImageClickEventArgs e)
    {
        doGetList();
    }
    protected void imbReset_Click(object sender, ImageClickEventArgs e)
    {
        ClearSearch();
        doGetList();
    }
    protected void tbDeleteClick(object sender, EventArgs e)
    {

    }
    protected void linkCode_Click(object sender, EventArgs e)
    {
        doGetDetail(((LinkButton)sender).CommandArgument);
        zPop.Show();
    }

    #endregion

    #region GridView Event Handler
    protected void gvMain_Sorting(object sender, GridViewSortEventArgs e)
    {
        if (e.SortExpression == "DEFAULT")
        {
            txhSortDir.Text = "";
            txhSortField.Text = "";
        }
        else
        {
            if (txhSortField.Text == e.SortExpression)
                txhSortDir.Text = (txhSortDir.Text.Trim() == "" ? "DESC" : "");
            else
                txhSortField.Text = e.SortExpression;
        }
        doGetList();
    }
    protected void gvMain_RowDataBound(object sender, GridViewRowEventArgs e)
    {
        if (e.Row.RowIndex > -1)
        {
            e.Row.Cells[2].Text = ((e.Row.RowIndex + 1) + (gvMain.PageIndex * gvMain.PageSize)).ToString();
            e.Row.Cells[6].Text = UserFlow.GetRoleName( UserFlow.GetRoleByString(e.Row.Cells[6].Text));
        }
    }
    #endregion

    #region Paging Event Handler

    protected void PageChange(object sender, EventArgs e)
    {
        gvMain.PageIndex = ((Templates_PageControl)sender).SelectedPageIndex;
        doGetList();
        pcBot.Update();
        pcTop.Update();
    }

    #endregion

    #region Controls Management Method

    private void SetStatus(string t)
    {
        lbStatus.Text = t;
        lbStatus.ForeColor = Constant.StatusColor.Information;
    }

    private void SetErrorStatus(string t)
    {
        lbStatus.Text = t;
        lbStatus.ForeColor = Constant.StatusColor.Error;
    }

    private void ClearData()
    {
        cmbTitle.SelectedIndex = 0;
        txhID.Text = "";
        txtFName.Text = "";
        txtLName.Text = "";
        cmbTitle.SelectedIndex = 0;
        txtPhone.Text = "";
        txtEMail.Text = "";
        txtUserName.Text = "";
        cmbDivision.SelectedIndex = 0;
        cmbUserGroup.SelectedIndex = 0;
        chkDisable.Checked = false;
        chkForceChangePw.Checked = true;
        dtpEFDate.DateValue = DateTime.Now.Date;
        dtpEPDate.DateValue = new DateTime();
        txtLastLogon.Text = "";
        txtLastChangePW.Text = "";
        lblPasswordNeed.Visible = true;
        WardDetailItem fsItem = new WardDetailItem();
        fsItem.ClearWard();

        MenuFlow mFlow = new MenuFlow();
        z2Menu.SetSource(mFlow.GetAllMenu(), "MENUNAME", "LOID");
        z2Menu.SetDest(new DataTable());
        UserFlow uFlow = new UserFlow();
        z2Group.SetSource(uFlow.GetAllRoleGroup(), "DESCRIPTION", "LOID");
        z2Group.SetDest(new DataTable());
        WardFlow wFlow = new WardFlow();
      //  z2Ward.SetSource(wFlow.GetMasterList("", "NAME"), "NAME", "LOID");
      //  z2Ward.SetDest(new DataTable());
    }

    private void ClearSearch()
    {
        txtSUserID.Text = "";
        txtSFName.Text = "";
        txtSLName.Text = "";
        cmbSDivision.SelectedIndex = 0;
        cmbSGroup.SelectedIndex = 0;
        tabRole.Visible = true;
    }

    private UserData GetData()
    {
        UserData ret = new UserData();
        ret.UID = Convert.ToDouble("0" + txhID.Text);
        ret.Title = Convert.ToDouble(cmbTitle.SelectedValue);
        ret.FName = txtFName.Text;
        ret.LName = txtLName.Text;
        ret.Tel = txtPhone.Text;
        ret.Email = txtEMail.Text;
        ret.UserID = txtUserName.Text;
        ret.Password = txtPasswd.Text;
        ret.ForcePWChange = (chkForceChangePw.Checked);
        ret.OfficerGroup = cmbUserGroup.SelectedValue;
        ret.Division = Convert.ToDouble(cmbDivision.SelectedValue);
        ret.Active = (!chkDisable.Checked);
        ret.EFDate = dtpEFDate.DateValue;
        ret.EPDate = dtpEPDate.DateValue;
        if (ret.OfficerGroup != "A") ret.SelectedMenu = z2Menu.SelectedData;
        if (ret.OfficerGroup != "A") ret.SelectedGroup = z2Group.SelectedData;
        ret.SelectedWard = GetWard();
       // if (ret.OfficerGroup == "M" || ret.OfficerGroup == "N") ret.SelectedWard = z2Ward.SelectedData;
        return ret;
    }

    private void SetData(UserData uData)
    {
        txhID.Text = uData.UID.ToString();
        cmbTitle.SelectedIndex = cmbTitle.Items.IndexOf(cmbTitle.Items.FindByValue(uData.Title.ToString()));
        txtFName.Text = uData.FName;
        txtLName.Text = uData.LName;
        txtPhone.Text = uData.Tel;
        txtEMail.Text = uData.Email;
        txtUserName.Text = uData.UserID;
        cmbDivision.SelectedIndex = cmbDivision.Items.IndexOf(cmbDivision.Items.FindByValue(uData.Division.ToString()));
        cmbUserGroup.SelectedIndex = cmbUserGroup.Items.IndexOf(cmbUserGroup.Items.FindByValue(uData.OfficerGroup));
        chkDisable.Checked = (!uData.Active);
        chkForceChangePw.Checked = (uData.ForcePWChange);
        dtpEFDate.DateValue = uData.EFDate;
        dtpEPDate.DateValue = uData.EPDate;
        txtLastChangePW.Text = (uData.LastPWChange.Year == 1 ? "-" : uData.LastPWChange.ToString("d MMM yyyy [HH:mm]"));
        txtLastLogon.Text = (uData.LastLogon.Year == 1 ? "-" : uData.LastLogon.ToString("d MMM yyyy [HH:mm]"));
        tabRole.Visible = (cmbUserGroup.SelectedValue != "A");
        this.tabWard.Visible = (cmbUserGroup.SelectedValue == "M" || cmbUserGroup.SelectedValue == "N");
        z2Menu.SetSource(uData.AllMenu, "MENUNAME", "LOID");
        z2Menu.SetDest(uData.GrantMenu, "MENUNAME", "LOID");
        z2Group.SetSource(uData.AllGroup, "DESCRIPTION", "LOID");
        z2Group.SetDest(uData.GrantGroup, "DESCRIPTION", "LOID");
       // z2Ward.SetSource(uData.AllWard, "NAME", "LOID");
       // z2Ward.SetDest(uData.GrantWard, "NAME", "LOID");
        lblPasswordNeed.Visible = (txhID.Text.Trim() == "");
        gvward.DataBind();

     }

    #endregion

     #region Ward Toolbar
     protected void tbAddWardClick(object sender, EventArgs e)
     {
         UpdateWard();
         WardDetailItem fsItem = new WardDetailItem();
         this.ctlWardPopup.Show(fsItem.getWardExist());
         zPop.Show();
     }
     protected void tbDeleteWardClick(object sender, EventArgs e)
     {
         UpdateWard();
         WardDetailItem fsItem = new WardDetailItem();
         if (fsItem.DeleteWard(GetCheckedWard())) 
             gvward.DataBind(); 
         zPop.Show();
     }
     #endregion

    protected void ctlWardPopup_SelectedIndexChanged(object sender, EventArgs e, ArrayList arrData)
    {
        WardDetailItem fsItem = new WardDetailItem();
        if (fsItem.InsertWard(Convert.ToDouble("0" + this.txhID.Text), arrData))
            gvward.DataBind();

        zPop.Show();
    }

    protected void ctlWardPopup_Cancel(object sender, EventArgs e)
    {
        zPop.Show();
    }

    private void UpdateWard()
    {
        WardDetailItem fsItem = new WardDetailItem();
        if (!fsItem.UpdateWard(Convert.ToDouble("0" + this.txhID.Text), GetWard()))
            SetErrorStatusWard(DataResources.MSGEC102);
        else
            SetStatusWard(DataResources.MSGIU001);
    }
    private ArrayList GetWard()
    {
        ArrayList arrData = new ArrayList();
        for (int i = 0; i < this.gvward.Rows.Count; ++i)
        {
            CheckBox chkDefault = (CheckBox)this.gvward.Rows[i].Cells[5].FindControl("chkDefault");
            CheckBox chkActive = (CheckBox)this.gvward.Rows[i].Cells[6].FindControl("chkActive");

            VWardResponseData WardItem = new VWardResponseData();
            WardItem.WARD = Convert.ToDouble("0" + this.gvward.Rows[i].Cells[0].Text);
            WardItem.OFFICER = Convert.ToDouble("0" + this.txhID.Text);
            WardItem.WARDNAME = this.gvward.Rows[i].Cells[3].Text;
            WardItem.ACTIVE = chkActive.Checked ? "1" : "0";
            WardItem.ISDEFAULT = chkDefault.Checked ? "1" : "0";
            WardItem.PRIORITY = Convert.ToDouble("0" + ((TextBox)this.gvward.Rows[i].Cells[4].FindControl("txtorder")).Text);
            arrData.Add(WardItem);
        }
        return arrData;
    }

    private ArrayList GetCheckedWard()
    {
        ArrayList arrChk = new ArrayList();
        for (int i = 0; i < gvward.Rows.Count; i++)
        {
            if (i > -1 && gvward.Rows[i].Cells[0].FindControl("chkSelect") != null)
            {
                GridViewRow gRow = gvward.Rows[i];
                if (((CheckBox)gRow.Cells[1].FindControl("chkSelect")).Checked)
                {
                    arrChk.Add(Convert.ToDouble(gRow.Cells[0].Text));
                }
            }
        }
        return arrChk;
    }
    private void SetErrorStatusWard(string t)
    {
        lbStatus.Text = t;
        lbStatus.ForeColor = Constant.StatusColor.Error;
    }
    private void SetStatusWard(string t)
    {
        lbStatus.Text = t;
        lbStatus.ForeColor = Constant.StatusColor.Information;
    }

    private bool doDelete(string LOID)
    {
        bool ret = true;

        double zLOID = 0;
        try { zLOID = Convert.ToDouble(LOID); }
        catch { }

        UserFlow uFlow = new UserFlow();
        ret = uFlow.DeleteUser(zLOID);
        return ret;
    }

    private bool doGetList()
    {
        UserFlow uFlow = new UserFlow();

        imbReset.Visible = (txtSUserID.Text.Trim() != "" || txtSFName.Text.Trim() != "" || txtSLName.Text.Trim() != "" || cmbSDivision.SelectedValue.Trim() != "" || cmbSGroup.SelectedValue.Trim() != "");

        string orderStr = "";
        if (txhSortField.Text.Trim() != "")
            orderStr = " " + txhSortField.Text + " " + txhSortDir.Text;

        gvMain.DataSource = uFlow.GetOfficerList(txtSUserID.Text, txtSFName.Text, txtSLName.Text, cmbSDivision.SelectedValue, cmbSGroup.SelectedValue, orderStr);
        gvMain.DataBind();

        pcTop.Update();
        pcBot.Update();

        return (uFlow.ErrorMessage == "");


    }

    private void doGetDetail(string UserLOID)
    {
        UserFlow uFlow = new UserFlow();

        double loid = 0;
        try { loid = Convert.ToDouble(UserLOID); }
        catch { }

        UserData uData = uFlow.GetUserData(loid);
        SetData(uData);
           
    }

    private bool doSaveData()
    {
        string err = VerifyData();
        if (err != "")
        {
            SetErrorStatus(err);
            return false;
        }

        UserFlow uFlow = new UserFlow();
        if (!uFlow.SaveUserData(GetData(), Appz.CurrentUser))
        {
            SetErrorStatus(uFlow.ErrorMessage);
            return false;
        }
        else
            return true;

    }

    private string VerifyData()
    {
        string ret = "";
        bool check = true;
        if (cmbTitle.SelectedIndex == 0)
        {
            ret = string.Format(DataResources.MSGEI002, "คำนำหน้า");
        }
        else if (txtFName.Text.Trim() == "")
        {
            ret = string.Format(DataResources.MSGEI001, "ชื่อจริง");
        }
        else if (txtLName.Text.Trim() == "")
        {
            ret = string.Format(DataResources.MSGEI001, "นามสกุล");
        }
        else if (cmbDivision.SelectedIndex == 0)
        {
            ret = string.Format(DataResources.MSGEI002, "หน่วยงาน");
        }
        else if (txtUserName.Text.Trim() == "")
        {
            ret = string.Format(DataResources.MSGEI001, "ชื่อเข้าระบบ");
        }
        else if (cmbUserGroup.SelectedIndex == 0)
        {
            ret = string.Format(DataResources.MSGEI002, "ระดับการใช้งาน");
        }
        else if (dtpEFDate.DateValue.Year == 1)
        {
            ret = string.Format(DataResources.MSGEI002, "วันที่เริ่มต้นใช้งาน");
        }
        else if (txtPasswd.Text == "" && txhID.Text.Trim() == "")
        {
            ret = string.Format(DataResources.MSGEI001, "รหัสผ่าน");
        }

        foreach (GridViewRow grow in gvward.Rows)
        {
            CheckBox chkDefault = (CheckBox)grow.Cells[5].FindControl("chkDefault");
            if (chkDefault.Checked)
            {
                ret = "";
                break;
            }
            else
            {
                ret = "กรุณาเลือก default หอผู้ป่วย";
            }
        }

        return ret;
    }

    protected void cmbUserGroup_SelectedIndexChanged(object sender, EventArgs e)
    {
        tabRole.Visible = (cmbUserGroup.SelectedValue != "A");
        this.tabWard.Visible = (cmbUserGroup.SelectedItem.Value == "M" || cmbUserGroup.SelectedItem.Value == "N");
        txtPasswd.Text = txtPasswd.Text;
        zPop.Show();
    }
    protected void gvMain_RowDeleting(object sender, GridViewDeleteEventArgs e)
    {
        doDelete(gvMain.Rows[e.RowIndex].Cells[0].Text);
        doGetList();
    }
}
