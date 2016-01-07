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
using SHND.Flow.Formula;
using SHND.Data.Formula;
using SHND.Global;
using SHND.Flow.Common;
using SHND.Data.Common.Utilities;
using SHND.Flow.Inventory;
using SHND.Data.Tables;
using SHND.DAL.Views;
using SHND.DAL.Tables;
using SHND.Data.Views;
using SHND.Flow.Admin;


/// <summary>
/// Supplier Page Class
/// Version 1.0
/// =========================================================================
/// Create by: Somsakoon
/// Create Date: 2 Feb 2009
/// -------------------------------------------------------------------------
/// Modify By: -
/// Modify From: -
/// Modify Date: -
/// -------------------------------------------------------------------------
/// Remark: -
/// Description:
///    หน้ากาารทำงานข้อมูล SystemMenuSearch  
/// Changes:
///    1.0 - สร้าง
/// -------------------------------------------------------------------------
/// =========================================================================
/// </summary>
/// 
public partial class App_Admin_Master_SystemMenu : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            doGetList();
        }
    }
    protected override void OnInit(EventArgs e)
    {
        base.OnInit(e);

        Appz.BuildCombo(cmbNAME , "V_ZSYSTEM", "NAME", "LOID", "", "", "ทั้งหมด", "0", false);
        Appz.BuildCombo(cmbSysName, "V_ZSYSTEM", "NAME", "LOID", "", "", "เลือก", "0", false);
        Appz.BuildCombo(cmbGroup, "ZMENUGROUP", "GNAME", "GID", "", "SEQUENCE", "", "", false);
        Appz.BuildCombo(cmbSGroup, "ZMENUGROUP", "GNAME", "GID", "", "SEQUENCE", "ทั้งหมด", "-1", false);

        ControlUtil.SetIntTextBox(txtSequence);
        //SetMainMenu();
        
        pcTop.SetMainGridView(gvMain);
        pcBot.SetMainGridView(gvMain);
    }

    #region Button Click Event Handler

    protected void imbSearch_Click1(object sender, EventArgs e)
    {
        gvMain.PageIndex = 0;
        doGetList();
    }
    protected void tbAddClick(object sender, EventArgs e)
    {
        zPop.Show();
    }
    protected void tbSave1Click(object sender, EventArgs e)
    {
        if (!doSave())
            zPop.Show();
        else
            ClearData();
    }
    protected void linkCode_Click(object sender, EventArgs e)
    {
        doGetDetail(((LinkButton)sender).CommandArgument);
        zPop.Show();
    }
    protected void tbCancelClick(object sender, EventArgs e)
    {
        if (txhID.Text.Trim() == "")
            ClearData();
        else
            doGetDetail(txhID.Text);

        zPop.Show();
    }
    protected void imbReset_Click(object sender, ImageClickEventArgs e)
    {
        ClearSearch();
        gvMain.PageIndex = 0;
        doGetList();
    }
    #endregion

    #region Gridview Event Handler
    protected void gvMain_RowDataBound(object sender, GridViewRowEventArgs e)
    {
        if (e.Row.RowIndex > -1)
            e.Row.Cells[2].Text = ((e.Row.RowIndex + 1) + (gvMain.PageIndex * gvMain.PageSize)).ToString();
    }
    protected void gvMain_Sorting(object sender, GridViewSortEventArgs e)
    {
        SystemMenuSearchFlow sFlow = new SystemMenuSearchFlow();
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

    #region Misc. Methods


    private void doDelete(string LOID)
    {
        SystemMenuSearchFlow fFlow = new SystemMenuSearchFlow();

        if (fFlow.DeleteByLOID(Convert.ToDouble(LOID)))
        {
            gvMain.PageIndex = 0;
            doGetList();
            lbStatusMain.Text = "";
        }
        else
        {
            lbStatusMain.Text = fFlow.ErrorMessage;
            lbStatusMain.ForeColor = System.Drawing.Color.Red;
        }

    }

    #endregion

    #region Controls Management Methods

    private void SetMainMenu()
    {
        //Appz.BuildCombo(cmbMenu, "v_systemmenusearch", "MENUNAME", "LOID", "ZSYSTEM = " + this.cmbSysName.SelectedItem.Value + " ", "", "เลือก", "0", false);
    }
    private void ClearData()
    {
        cmbSysName.SelectedIndex = 0;
        txtName.Text = "";
        txtDESCRIPTION.Text = "";
        txtLink.Text = "";
        cmbGroup.SelectedIndex = 0;
        chkActive.Checked = true;
        txhID.Text = "";
        txtSequence.Text = "0";

    }
    private void ClearSearch()
    {
        cmbNAME.SelectedIndex = 0;
        cmbSGroup.SelectedIndex = 0;
        txtSearch.Text = "";
    }
    private void SetErrorStatus(string t)
    {
        lbStatus.Text = t;
        lbStatus.ForeColor = Constant.StatusColor.Error;
    }
    private VSystemMenuSearchData GetData()
    {
        VSystemMenuSearchData sData = new VSystemMenuSearchData();

        sData.LOID = Convert.ToDouble("0" + txhID.Text);//หัวข้อเมนู
        sData.ZSYSTEM = Convert.ToDouble(cmbSysName.SelectedItem.Value); // ระบบ
        sData.MENUNAME = txtName.Text;//ชื่อเมนู
        sData.DESCRIPTION = txtDESCRIPTION.Text; //รายละเอียด
        sData.LINK = txtLink.Text; // #Link
        sData.ENABLED = chkActive.Checked; //
        sData.PARENT = 0;//เมนูหลัก
        sData.MENUGROUP = Convert.ToDouble(cmbGroup.SelectedValue);
        sData.SEQUENCE = Convert.ToDouble(txtSequence.Text);
        return sData;
    }
    private void SetData(VSystemMenuSearchData ftData)
    {
        txhID.Text = ftData.LOID.ToString();
        txtLink.Text = ftData.LINK;
        txtName.Text = ftData.MENUNAME;
        chkActive.Checked = ftData.ENABLED;
        txtDESCRIPTION.Text = ftData.DESCRIPTION;
        cmbSysName.SelectedIndex = cmbSysName.Items.IndexOf(cmbSysName.Items.FindByValue(ftData.ZSYSTEM.ToString ()));
        //SetMainMenu();
        cmbGroup.SelectedIndex = cmbGroup.Items.IndexOf(cmbGroup.Items.FindByValue(ftData.MENUGROUP.ToString()));
        txtSequence.Text = ftData.SEQUENCE.ToString(Constant.IntFormat);
    }
    
    #endregion

    #region Working Method

    private void doGetList()
    {

        SystemMenuSearchFlow sFlow = new SystemMenuSearchFlow();

        imbReset.Visible = (cmbNAME.SelectedIndex != 0 || txtSearch.Text != ""); 
        pcBot.Visible = (cmbNAME.SelectedIndex != 0 || txtSearch.Text != "");
        pcTop.Visible = (cmbNAME.SelectedIndex != 0 || txtSearch.Text != "");
        string orderStr = "";
        if (txhSortField.Text.Trim() != "")
            orderStr = " " + txhSortField.Text + " " + txhSortDir.Text;
        
            gvMain.DataSource = sFlow.GetMasterList(Convert.ToDouble(cmbNAME.SelectedItem.Value), txtSearch.Text, Convert.ToDouble(cmbSGroup.SelectedValue), orderStr);
            gvMain.DataBind();
            pcTop.Update();
            pcBot.Update();
        
    }
    private bool doSave()
    {
        // verify required field
        string error = VerifyData();
        if (error != "")
        {
            SetErrorStatus(error);
            return false;
        }

        SystemMenuSearchFlow stFlow = new SystemMenuSearchFlow();
        bool ret = true;


        // data correct go on saving...
        if (txhID.Text.Trim() == "")
        {

            //  save new
            ret = stFlow.InsertData(GetData(), Appz.CurrentUser);
        }
        else
        {
            // save update
            ret = stFlow.UpdateData(GetData(), Appz.CurrentUser);
        }

        if (!ret)
            SetErrorStatus(stFlow.ErrorMessage);
        else
            doGetList();

        return ret;
    }
    private string VerifyData()
    {
        string ret = ""; 
        VSystemMenuSearchData  fData = GetData();
        if (fData.ZSYSTEM   == 0)
            ret = string.Format(DataResources.MSGEI002, "ระบบ");
        if (fData.MENUNAME.Trim() == "")
            ret = string.Format(DataResources.MSGEI001, "ชื่อเมนู");
        return ret;
    }
    private bool doGetDetail(string LOID)
    {
        SystemMenuSearchFlow sFlow = new SystemMenuSearchFlow();
        VSystemMenuSearchData  sData = sFlow.GetDetails(Convert.ToDouble(LOID));

        bool ret = true;

        if (sData.LOID != 0)
        {
            SetData(sData);
        }
        else
            ret = false;

        return ret;
    }
     #endregion

    protected void cmbSysName_SelectedIndexChanged(object sender, EventArgs e)
    {
        //SetMainMenu();
        zPop.Show();
    }
    protected void tbDeleteClick(object sender, ImageClickEventArgs e)
    {
        doDelete(Convert.ToString(((ImageButton)sender).CommandArgument));
    }
}
