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
using SHND.Global;
using SHND.Flow.Common;
using SHND.Data.Common.Utilities;
using SHND.Flow.Inventory;
using SHND.DAL.Views;
using SHND.Data.Views;

/// <summary>
/// Supplier Page Class
/// Version 1.0
/// =========================================================================
/// Create by: Somsakoon
/// Create Date: 12 Feb 2009
/// -------------------------------------------------------------------------
/// Modify By: -
/// Modify From: -
/// Modify Date: -
/// -------------------------------------------------------------------------
/// Remark: -
/// Description:
///    หน้ากาารทำงานข้อมูล  StockoutWasteSearch  
/// Changes:
///    1.0 - สร้าง
/// -------------------------------------------------------------------------
/// =========================================================================
/// </summary>
/// 

public partial class App_Inventory_Transaction_StockoutWasteSearch : System.Web.UI.Page
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
      

        Appz.BuildCombo(cmbSearcWarehouse, "WAREHOUSE", "NAME", "LOID", "ACTIVE = '1'", "NAME", "ทั้งหมด", "0", false);
       
        SetStatusCombo(cmbSearcStatusFrom);
        SetStatusCombo(cmbSearchStatusTo);
        pcTop.SetMainGridView(gvMain);
        pcBot.SetMainGridView(gvMain);
    }
    protected void SetStatusCombo(DropDownList cmbStatus)
    {
        cmbStatus.Items.Clear();
        cmbStatus.Items.Add(new ListItem("ทำรายการ", "00"));
        cmbStatus.Items.Add(new ListItem("รออนุมัติ", "01"));
        cmbStatus.Items.Add(new ListItem("อนุมัติ", "02"));
        cmbStatus.Items.Add(new ListItem("ไม่อนุมัติ", "03"));
        //cmbStatus.Items.Add(new ListItem("ยกเลิก", "04"));
    }
    #region Button Click Event Handler

    protected void linkCode_Click(object sender, EventArgs e)
    {
        Response.Redirect(Constant.HomeFolder + "App_Inventory/Transaction/StockoutWaste.aspx?loid=" + ((LinkButton)sender).CommandArgument);
    }
    protected void tbAddClick(object sender, EventArgs e)
    {
        Response.Redirect(Constant.HomeFolder + "App_Inventory/Transaction/StockoutWaste.aspx");
    }
    protected void imbSearch_Click(object sender, EventArgs e)
    {
        gvMain.PageIndex = 0;
        doGetList();
    }
    protected void tbDeleteClick(object sender, EventArgs e)
    {
        doDelete();
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
        SupplierFlow sFlow = new SupplierFlow();
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

    private ArrayList GetChecked()
    {
        ArrayList arrChk = new ArrayList();
        for (int i = 0; i < gvMain.Rows.Count; i++)
        {
            if (i > -1 && gvMain.Rows[i].Cells[0].FindControl("chkSelect") != null)
            {
                if (((CheckBox)gvMain.Rows[i].Cells[1].FindControl("chkSelect")).Checked)
                    arrChk.Add(gvMain.Rows[i].Cells[0].Text);
            }
        }

        return arrChk;
    }

    #endregion

    #region Controls Management Methods

    private void ClearSearch()
    {
        this.txtSearch.Text = "";
        this.txtSearchTo.Text = "";
        this.CalendarControl1.DateValue = new DateTime();
        this.CalendarControl2.DateValue = new DateTime();
        SetStatusCombo(cmbSearcStatusFrom);
        SetStatusCombo(cmbSearchStatusTo);
        this.cmbSearcWarehouse.SelectedIndex = 0;
    }
    
     #endregion

    #region Working Method
    private void doGetList()
    {
        StockWasteSearchFlow sFlow = new StockWasteSearchFlow();

        imbReset.Visible = (txtSearch.Text.Trim() != "" || txtSearchTo.Text.Trim() != "" || CalendarControl1.DateValue.Year > 1 || CalendarControl2.DateValue.Year > 1 || cmbSearcWarehouse.SelectedItem.Value != "0" || cmbSearcStatusFrom.SelectedItem.Value != "00"|| cmbSearchStatusTo .SelectedItem .Value != "00");

        string orderStr = "";
        double doctype = 1;
        
        if (txhSortField.Text.Trim() != "")
            orderStr = " " + txhSortField.Text + " " + txhSortDir.Text;

        gvMain.DataSource = sFlow.GetMasterList(txtSearch.Text, txtSearchTo.Text, CalendarControl1.DateValue, CalendarControl2.DateValue, Convert.ToDouble(cmbSearcWarehouse.SelectedItem.Value), cmbSearcStatusFrom.SelectedItem.Value, cmbSearchStatusTo.SelectedItem.Value, doctype , orderStr);

        gvMain.DataBind();
        pcTop.Update();
        pcBot.Update();
        

    }
    private void doDelete()
    {
        StockWasteSearchFlow fFlow = new StockWasteSearchFlow();
        if (fFlow.DeleteByLOID(GetChecked()))
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










}
