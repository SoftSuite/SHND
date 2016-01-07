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
/// Create Date: 3 Feb 2009
/// -------------------------------------------------------------------------
/// Modify By: -
/// Modify From: -
/// Modify Date: -
/// -------------------------------------------------------------------------
/// Remark: -
/// Description:
///    หน้ากาารทำงานข้อมูล GroupPermissionSearch  
/// Changes:
///    1.0 - สร้าง
/// -------------------------------------------------------------------------
/// =========================================================================
/// </summary>
/// 

public partial class App_Admin_Master_GroupPermissionSearch : System.Web.UI.Page
{
   
    protected void Page_Load(object sender, EventArgs e)
    {

        if (!IsPostBack)
        {
           // doGetList();
        }
    }
    protected override void OnInit(EventArgs e)
    {
        base.OnInit(e);
        pcTop.SetMainGridView(gvMain);
        pcBot.SetMainGridView(gvMain);
        doGetListBoxControl();
        
    }

    #region Button Click Event Handler
    protected void imbSearch_Click1(object sender, EventArgs e)
    {
        gvMain.PageIndex = 0;
        doGetList();
    }
    protected void imbReset_Click(object sender, ImageClickEventArgs e)
    {
        ClearSearch();
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
    protected void tbCancelClick(object sender, EventArgs e)
    {
        if (txhID.Text.Trim() == "")
            ClearData();
        else
            doGetDetail(txhID.Text);

        zPop.Show();
    }
    protected void tbBackClick(object sender, EventArgs e)
    {
        ClearData();
    }
    protected void linkCode_Click(object sender, EventArgs e)
    {
        doGetDetail(((LinkButton)sender).CommandArgument);
        zPop.Show();
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
        GroupPermissionSearchFlow fFlow = new GroupPermissionSearchFlow();

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
    private void ClearData()
    {
        txtGroup.Text = "";
        doGetListBoxControl();
        txhID.Text = "";
    }
    private void ClearSearch()
    {
        txtSearch.Text = "";

    }
    private void SetErrorStatus(string t)
    {
        lbStatus.Text = t;
        lbStatus.ForeColor = Constant.StatusColor.Error;
    }
    private ZRoleData GetData()
    {
        ZRoleData sData = new ZRoleData();
        sData.LOID = Convert.ToDouble("0" + txhID.Text);
        sData.DESCRIPTION = txtGroup.Text;
        sData.OFFICER = 0;
        sData.ZLEVEL = "G";
        sData.RoleAssign = this.z2Menu.SelectedData;
         return sData;
    }
    private void SetData(ZRoleData ftData)
    {
        txtGroup.Text = ftData.DESCRIPTION;
        txhID.Text = Convert .ToString (ftData.LOID);
        VZMenuDAL zDAL = new VZMenuDAL();
        VZMenuData VZMenu = zDAL.GetDataDetail(ftData.LOID);
        this.z2Menu.SetSource(VZMenu.RestMenu, "FULLMENUNAME", "LOID");
        this.z2Menu.SetDest(VZMenu.GrantMenu, "FULLMENUNAME", "LOID");

    }
    
     #endregion
   
    #region Working Method
    private void doGetList()
    {
        GroupPermissionSearchFlow sFlow = new GroupPermissionSearchFlow();
        
        imbReset.Visible = ( txtSearch.Text != "");
        pcBot.Visible = ( txtSearch.Text != "");
        pcTop.Visible = ( txtSearch.Text != "");

        string orderStr = "";
        if (txhSortField.Text.Trim() != "")
            orderStr = " " + txhSortField.Text + " " + txhSortDir.Text;

        gvMain.DataSource = sFlow.GetMasterList(txtSearch.Text, orderStr);
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

        GroupPermissionSearchFlow stFlow = new GroupPermissionSearchFlow();
       
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
        ZRoleData fData = GetData();
        if (fData.DESCRIPTION.Trim() == "")
            ret = string.Format(DataResources.MSGEI001, "ชื่อกลุ่ม");
        else if (fData.RoleAssign.Count   == 0)
            ret = string.Format(DataResources.MSGEI002, "เมนูที่ได้รับสิทธิ์");

        return ret;
    }
    private bool doGetDetail(string LOID)
    {
        GroupPermissionSearchFlow sFlow = new GroupPermissionSearchFlow();
        ZRoleData sData = sFlow.GetDetails(Convert.ToDouble(LOID));

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

    protected void tbDeleteClick(object sender, ImageClickEventArgs e)
    {
        doDelete(Convert.ToString(((ImageButton)sender).CommandArgument));
    }
    private void doGetListBoxControl()
    {
        VZMenuDAL zDAL = new VZMenuDAL();
        VZMenuData VZMenu = zDAL.GetData();
        this.z2Menu.SetSource(VZMenu.RestMenu, "FULLMENUNAME", "LOID");
        this.z2Menu.SetDest(VZMenu.GrantMenu, "FULLMENUNAME", "LOID");
    }
    
}
