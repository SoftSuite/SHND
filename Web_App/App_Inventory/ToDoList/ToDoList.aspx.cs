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
using SHND.Global;
using SHND.Data.Order;
using SHND.Data.Common.Utilities;
using SHND.Flow.Common;
using SHND.Flow.Inventory;
using SHND.DAL.Tables;
using SHND.DAL.Views;
using SHND.Data.Tables;
using SHND.Data.Views;

/// <summary>
/// Supplier Page Class
/// Version 1.0
/// =========================================================================
/// Create by: Somsakoon
/// Create Date: 10 Feb 2009
/// -------------------------------------------------------------------------
/// Modify By: -
/// Modify From: -
/// Modify Date: -
/// -------------------------------------------------------------------------
/// Remark: -
/// Description:
///    หน้ากาารทำงานข้อมูล  ToDoList  
/// Changes:
///    1.0 - สร้าง
/// -------------------------------------------------------------------------
/// =========================================================================
/// </summary>
/// 

public partial class App_Inventory_ToDoList_ToDoList : System.Web.UI.Page
{
    private void SetStatusCombo(DropDownList cmb)
    {
        cmb.Items.Clear();
        //cmb.Items.Add(new ListItem("กำลังดำเนินการ", "00"));
        cmb.Items.Add(new ListItem("รออนุมัติ", "01"));
        cmb.Items.Add(new ListItem("อนุมัติ", "02"));
        cmb.Items.Add(new ListItem("ไม่อนุมัติ", "03"));
        cmb.Items.Add(new ListItem("ยกเลิก", "04"));
    }

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

        SetStatusCombo(cmbStatusFrom);
        SetStatusCombo(cmbStatusTo);
        //SetStatusCombo(cmbStatusTo, "STOCKOUT", "STATUS", "LOID", " STATUS IN ('WA','SE','AP','NP','VO') ", "STATUS", "เลือก", "0", false);
        Appz.BuildCombo(cmbSearchWareHouse, "V_TODOLIST_MINSTOCK", "WAREHOUSENAME", "WAREHOUSE", "WAREHOUSE IS NOT NULL", "WAREHOUSENAME", "ทั้งหมด", "0", true);

       
          pcTop.SetMainGridView(gvMain);
          pcBot.SetMainGridView(gvMain);
          pcTop1.SetMainGridView(gvMinimumStock);
          pcBot1.SetMainGridView(gvMinimumStock);
          ClearSearch();
    }
    protected void tabTodolist_ActiveTabChanged(object sender, EventArgs e)
    {
        this.txtCurentTab.Text = this.tabTodolist.ActiveTabIndex.ToString();
        if (this.txtCurentTab.Text == "0")
        {
            doGetList();
        }
        else if (this.txtCurentTab.Text == "1")
        {
            doGetListMin();
        }
       
    }


    #region Button Click Event Handler

    protected void lnkCode_Click(object sender, EventArgs e)
    {
        Response.Redirect(Constant.HomeFolder + "App_Inventory/Transaction/StockOut.aspx?loid=" + ((LinkButton)sender).CommandArgument);
    }

    protected void imbSearch_Click(object sender, ImageClickEventArgs e)
    {
        gvMain.PageIndex = 0;
        doGetList();
    }
    protected void imbSearchMin_Click(object sender, ImageClickEventArgs e)
    {
        gvMinimumStock.PageIndex = 0;
        doGetListMin();
    }
    protected void imbReset_Click(object sender, ImageClickEventArgs e)
    {
        ClearSearch();
        gvMain.PageIndex = 0;
        doGetList();
    }
    protected void imbResetMin_Click(object sender, ImageClickEventArgs e)
    {
        ClearSearchMin();
        gvMinimumStock.PageIndex = 0;
        doGetListMin();
    }
    #endregion

    #region Gridview Event Handler

    protected void gvMain_RowDataBound(object sender, GridViewRowEventArgs e)
    {
        this.txtCurentTab.Text = this.tabTodolist.ActiveTabIndex.ToString();
        if (this.txtCurentTab.Text == "0")
        {
            if (e.Row.RowIndex > -1)
                e.Row.Cells[1].Text = ((e.Row.RowIndex + 1) + (gvMain.PageIndex * gvMain.PageSize)).ToString();
        }
        else if (this.txtCurentTab.Text == "1")
        {
            if (e.Row.RowIndex > -1)
                e.Row.Cells[2].Text = ((e.Row.RowIndex + 1) + (gvMinimumStock.PageIndex * gvMinimumStock.PageSize)).ToString();
        }
    }
    protected void gvMain_Sorting(object sender, GridViewSortEventArgs e)
    {
        ToDoListFlow sFlow = new ToDoListFlow();
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
        this.txtCurentTab.Text = this.tabTodolist.ActiveTabIndex.ToString();
        if (this.txtCurentTab.Text == "0")
        {
            doGetList();
        }
        else if (this.txtCurentTab.Text == "1")
        {
            doGetListMin();
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
    protected void PageChangeM(object sender, EventArgs e)
    {
        gvMinimumStock.PageIndex = ((Templates_PageControl)sender).SelectedPageIndex;
        doGetListMin();
        pcBot1.Update();
        pcTop1.Update();
    }

    #endregion

    #region Misc. Methods
    private ArrayList GetChecked()
    {
        ArrayList arrChk = new ArrayList();
        for (int i = 0; i < gvMinimumStock.Rows.Count; i++)
        {
            if (i > -1 && gvMinimumStock.Rows[i].Cells[0].FindControl("chkSelect") != null)
            {
                if (((CheckBox)gvMinimumStock.Rows[i].Cells[1].FindControl("chkSelect")).Checked)
                    arrChk.Add(gvMinimumStock.Rows[i].Cells[0].Text);
            }
        }

        return arrChk;
    }
    #endregion

    #region Controls Management Methods

    private void ClearSearch()
    {
        txtSearch.Text = "";
        txtSearch2.Text = "";
        CalendarControl1.DateValue = new DateTime();
        CalendarControl2.DateValue = new DateTime();
        cmbStatusFrom.SelectedIndex = 0;
        cmbStatusTo.SelectedIndex = cmbStatusTo.Items.Count-1;
        
    }
    private void ClearSearchMin()
    {
        cmbSearchWareHouse.SelectedIndex = 0;
        txtSearchMin.Text = "";
        
    }

    #endregion

    #region Working Method

    private void doGetList()
    {
        ToDoListFlow sFlow = new ToDoListFlow();
       

        imbReset.Visible = (txtSearch.Text.Trim() != "") || (this.txtSearch2.Text.Trim() != "") || (this.CalendarControl1.DateValue.Year != 1) || (this.CalendarControl2.DateValue.Year !=1) ||
            (this.cmbStatusFrom.SelectedIndex != 0) || (this.cmbStatusTo.SelectedIndex != (this.cmbStatusTo.Items.Count - 1));

        string orderStr = "";
        if (txhSortField.Text.Trim() != "")
            orderStr = " " + txhSortField.Text + " " + txhSortDir.Text;

        gvMain.DataSource = sFlow.GetMasterList(txtSearch.Text, txtSearch2.Text, CalendarControl1.DateValue, CalendarControl2.DateValue, cmbStatusFrom.SelectedItem.Value, cmbStatusTo.SelectedItem.Value, orderStr);
        gvMain.DataBind();
        pcTop.Update();
        pcBot.Update();

    }
    private void doGetListMin()
    {
        ToDoListFlow sFlow = new ToDoListFlow();
        imbResetMin.Visible = (txtSearchMin.Text.Trim() != "") || ( this.cmbSearchWareHouse.SelectedIndex != 0);
        string orderStr = "MATERIALNAME";
        if (txhSortField.Text.Trim() != "")
            orderStr = " " + txhSortField.Text + " " + txhSortDir.Text;

        gvMinimumStock.DataSource = sFlow.GetMasterListMin(txtSearchMin.Text, cmbSearchWareHouse.SelectedItem.Value, orderStr);

        gvMinimumStock.DataBind();
        gvMinimumStock.Columns[1].Visible = false;
        pcTop1.Update();
        pcBot1.Update();
    }
    

    #endregion

}
