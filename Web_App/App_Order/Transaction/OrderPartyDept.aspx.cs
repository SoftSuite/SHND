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
using SHND.Flow.Order;
using SHND.Data.Views;
using SHND.Global;
using SHND.Flow.Common;
using SHND.Data.Common.Utilities;

/// <summary>
/// FoodType Page Class
/// Version 1.0
/// =========================================================================
/// Create by: Tan
/// Create Date: 1 Feb 2009
/// -------------------------------------------------------------------------
/// Modify By: -
/// Modify From: -
/// Modify Date: -
/// -------------------------------------------------------------------------
/// Remark: -
/// Description:
///    หน้ากาารทำงานข้อมูล Blenderize Diet Search 
/// Changes:
///    1.0 - สร้าง
/// -------------------------------------------------------------------------
/// =========================================================================
/// </summary>
/// 

public partial class App_Order_Transaction_OrderPartyDept : System.Web.UI.Page
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
        SetStatusCombo(cmbStatusFrom);
        SetStatusCombo(cmbStatusTo);
        ClearSearch();
        pcTop.SetMainGridView(gvMain);
        pcBot.SetMainGridView(gvMain);
    }

    #region Button Click Event Handler

    protected void tbAddClick(object sender, EventArgs e)
    {
        Response.Redirect(Constant.HomeFolder + "App_Order/Transaction/OrderParty.aspx");
    }

    protected void linkCode_Click(object sender, EventArgs e)
    {
        Response.Redirect(Constant.HomeFolder + "App_Order/Transaction/OrderParty.aspx?loid=" + ((LinkButton)sender).CommandArgument);
    }

    protected void imbSearch_Click(object sender, ImageClickEventArgs e)
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

    protected void tbDeleteClick(object sender, EventArgs e)
    {
        doDelete();
    }
    protected void tbCommitClick(object sender, EventArgs e)
    {
        doCommit();
    }


    #endregion

    #region Gridview Event Handler

    protected void gvMain_RowDataBound(object sender, GridViewRowEventArgs e)
    {
        if (e.Row.RowIndex > -1)
            e.Row.Cells[2].Text = ((e.Row.RowIndex + 1) + (gvMain.PageIndex * gvMain.PageSize)).ToString();
        if (e.Row.RowType == DataControlRowType.DataRow)
        {
            DataRow drow = (DataRow)((DataRowView)e.Row.DataItem).Row;
            CheckBox chk = (CheckBox)e.Row.Cells[1].FindControl("chkSelect");
            chk.Enabled = (drow["STATUS"].ToString() != "FN");

            if (drow["STATUS"].ToString() == "WA")
                e.Row.BackColor = System.Drawing.Color.White;
            else if (drow["STATUS"].ToString() == "FN")
                e.Row.BackColor = System.Drawing.Color.Gold;
            else if ((drow["STATUS"].ToString() == "AP" & drow["DIRECTORAPPROVE"].ToString() == "Y") || (drow["STATUS"].ToString() == "RG" & drow["NDAPPROVE"].ToString() == "Y"))
                e.Row.BackColor = System.Drawing.Color.LightGreen;
            else if ((drow["STATUS"].ToString() == "AP" & drow["DIRECTORAPPROVE"].ToString() == "N") || (drow["STATUS"].ToString() == "RG" & drow["NDAPPROVE"].ToString() == "N") || drow["STATUS"].ToString() == "DC")
                e.Row.BackColor = System.Drawing.Color.Coral;

        }
    }

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
        // Clear searh data
        txtCodeFrom.Text = "";
        txtCodeTo.Text = "";
        cmbStatusFrom.SelectedValue = "00";
        cmbStatusTo.SelectedValue = "00";

    }
    private void SetStatusCombo(DropDownList cmbStatus)
    {
        cmbStatus.Items.Clear();
        cmbStatus.Items.Add(new ListItem("กำลังดำเนินการ", "00"));
        cmbStatus.Items.Add(new ListItem("เสนอเพื่อโปรดพิจารณา", "01"));
        cmbStatus.Items.Add(new ListItem("ผู้อำนวยการอนุมัติ", "02"));
        cmbStatus.Items.Add(new ListItem("ผู้อำนวยการไม่อนุมัติ", "03"));
        cmbStatus.Items.Add(new ListItem("ฝ่ายโภชนาการรับ Order", "04"));
        cmbStatus.Items.Add(new ListItem("ฝ่ายโภชนาการไม่รับ Order", "05"));
        cmbStatus.Items.Add(new ListItem("ยกเลิกการสั่งอาหาร", "06"));

    }

    #endregion

    #region Working Method

    private void doGetList()
    {
        OrderPartyFlow fFlow = new OrderPartyFlow();

        // ตรวจสอบเงื่อนไขการค้นหาเพื่อแสดงปุ่ม reset การค้นหา
        imbReset.Visible = (txtCodeFrom.Text.Trim() != "") || (txtCodeTo.Text.Trim() != "") || (ctlDateFrom.DateValue.Year != 1) || (ctlDateTo.DateValue.Year != 1) || 
            (cmbStatusFrom.SelectedItem.Value != "00") || (cmbStatusTo.SelectedItem.Value != "00");

        string orderStr = "";
        if (txhSortField.Text.Trim() != "")
            orderStr = " " + txhSortField.Text + " " + txhSortDir.Text;

        gvMain.DataSource = fFlow.GetMasterList(txtCodeFrom.Text, txtCodeTo.Text, ctlDateFrom.DateValue, ctlDateTo.DateValue, cmbStatusFrom.SelectedValue, cmbStatusTo.SelectedValue, orderStr);
        gvMain.DataBind();
        pcTop.Update();
        pcBot.Update();
    }
    private void doDelete()
    {
        OrderPartyFlow fFlow = new OrderPartyFlow();
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
    private void doCommit()
    {
        OrderPartyFlow sFlow = new OrderPartyFlow();
        if (sFlow.UpdateByLOID(Appz.CurrentUser, "FN", GetChecked()))
        {
            gvMain.PageIndex = 0;
            doGetList();
            lbStatusMain.Text = "";
        }
        else
        {
            lbStatusMain.Text = sFlow.ErrorMessage;
            lbStatusMain.ForeColor = System.Drawing.Color.Red;
        }

    }

    #endregion
}
