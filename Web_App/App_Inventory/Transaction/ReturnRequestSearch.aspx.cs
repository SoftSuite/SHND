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
using SHND.DAL.Views;
using SHND.Data.Views;
using SHND.Flow.Inventory;


/// <summary>
/// Supplier Page Class
/// Version 1.0
/// =========================================================================
/// Create by: Somsakoon
/// Create Date: 2 Mar 2009
/// -------------------------------------------------------------------------
/// Modify By: -
/// Modify From: -
/// Modify Date: -
/// -------------------------------------------------------------------------
/// Remark: -
/// Description:
///    หน้ากาารทำงานข้อมูล  ReturnRequestSearch  
/// Changes:
///    1.0 - สร้าง
/// -------------------------------------------------------------------------
/// =========================================================================
/// </summary>
/// 

public partial class App_Inventory_Transaction_ReturnRequestSearch : System.Web.UI.Page
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
        SetStatusCombo(cmbSearcStatusFrom);
        SetStatusCombo(cmbSearchStatusTo);
        pcTop.SetMainGridView(gvMain);
        pcBot.SetMainGridView(gvMain);
    }
    protected void SetStatusCombo(DropDownList cmbStatus)
    {
        cmbStatus.Items.Clear();
        cmbStatus.Items.Add(new ListItem("กำลังดำเนินการ", "00"));
        cmbStatus.Items.Add(new ListItem("รออนุมัติ", "01"));
        cmbStatus.Items.Add(new ListItem("อนุมัติ", "02"));
        cmbStatus.Items.Add(new ListItem("ไม่อนุมัติ", "03"));
    }

    #region Button Click Event Handler

    protected void imbSearch_Click(object sender, EventArgs e)
    {
        gvMain.PageIndex = 0;
        doGetList();
    }
    protected void tbDeleteClick(object sender, EventArgs e)
    {
        doDelete();
    }
    protected void linkCode_Click(object sender, EventArgs e)
    {
        Response.Redirect(Constant.HomeFolder + "App_Inventory/Transaction/ReturnRequest.aspx?loid=" + ((LinkButton)sender).CommandArgument);
    }

    protected void tbAddClick(object sender, EventArgs e)
    {
        Response.Redirect(Constant.HomeFolder + "App_Inventory/Transaction/ReturnRequest.aspx");
    }
    protected void imbReset_Click(object sender, ImageClickEventArgs e)
    {
        ClearSearch();
        gvMain.PageIndex = 0;
        doGetList();
    }

    protected void tbSendClick(object sender, EventArgs e)
    {
        doSend();
    }

    # endregion

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
        txhID.Text = "";
        txtSearch.Text = "";
        txtSearchTo.Text = "";
        ctlDateFrom.DateValue = new DateTime();
        ctlDateTo.DateValue = new DateTime();
        SetStatusCombo(cmbSearcStatusFrom);
        SetStatusCombo(cmbSearchStatusTo);
    }

    private void ClearData()
    {
        txhID.Text = "";
        txtSearch.Text = "";
        txtSearchTo.Text = "";
        ctlDateFrom.DateValue = new DateTime();
        ctlDateTo.DateValue = new DateTime();
        SetStatusCombo(cmbSearcStatusFrom);
        SetStatusCombo(cmbSearchStatusTo);
    }

    #endregion


    #region Working Method

    private void doGetList()
    {
        ReturnRequestFlow sFlow = new ReturnRequestFlow();

        imbReset.Visible = (txtSearch.Text.Trim() != "" || txtSearchTo.Text.Trim() != "" || ctlDateFrom.DateValue.Year != 1 || ctlDateTo.DateValue.Year != 1 || cmbSearcStatusFrom.SelectedIndex != 0 || cmbSearchStatusTo.SelectedIndex != 0);

        string orderStr = "";
        double doctype = 15;
        if (txhSortField.Text.Trim() != "")
            orderStr = " " + txhSortField.Text + " " + txhSortDir.Text;

        gvMain.DataSource = sFlow.GetMasterList(txtSearch.Text, txtSearchTo.Text, ctlDateFrom.DateValue, ctlDateTo.DateValue,Convert.ToString (doctype) , cmbSearcStatusFrom.SelectedItem.Value, cmbSearchStatusTo.SelectedItem.Value, orderStr);

        gvMain.DataBind();
        pcTop.Update();
        pcBot.Update();

    }

    private void doDelete()
    {
        ReturnRequestFlow fFlow = new ReturnRequestFlow();
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
    private void doSend()
    {
        ReturnRequestFlow fFlow = new ReturnRequestFlow();
        if (fFlow.DoSend(GetChecked(), Appz.CurrentUser))
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
