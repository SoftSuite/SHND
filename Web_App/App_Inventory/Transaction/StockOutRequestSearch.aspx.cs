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
using SHND.Data.Common.Utilities;
using SHND.Flow.Inventory;
using SHND.Global;

/// <summary>
/// StockOutRequestSearch Page Class
/// Version 1.0
/// =========================================================================
/// Create by: Teang
/// Create Date: 23 Feb 2009
/// -------------------------------------------------------------------------
/// Modify By: -
/// Modify From: -
/// Modify Date: -
/// -------------------------------------------------------------------------
/// Remark: -
/// Description:
///    หน้าการทำรายการข้อมูล StockOutRequest
/// Changes:
///    1.0 - สร้าง
/// -------------------------------------------------------------------------
/// =========================================================================
/// </summary>
/// 
public partial class App_Inventory_Transaction_StockOutRequestSearch : System.Web.UI.Page
{
    private void SetStatusCombo(DropDownList cmb)
    {
        cmb.Items.Clear();
        cmb.Items.Add(new ListItem("ทำรายการ", "00"));
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

        // set Combo source
        SetStatusCombo(this.cmbSearchStatusFrom);
        SetStatusCombo(this.cmbSearchStatusTo);
        pcTop.SetMainGridView(gvMain);
        pcBot.SetMainGridView(gvMain);
        ClearSearch();
        this.tbDelete.ClientClick = "return confirm('" + DataResources.MSGCD003 + "')";
        this.tbSend.ClientClick = "return confirm('ต้องการส่งข้อมูลใช่หรือไม่?')";
    }

    #region Button Click Event Handler

    protected void tbAddClick(object sender, EventArgs e)
    {
        Response.Redirect(Constant.HomeFolder + "App_Inventory/Transaction/StockOutRequest.aspx?loid=0");
    }

    protected void tbDeleteClick(object sender, EventArgs e)
    {
        doDelete();
    }

    protected void tbSendClick(object sender, EventArgs e)
    {
        doSend();
    }

    protected void lnkCode_Click(object sender, EventArgs e)
    {
        Response.Redirect(Constant.HomeFolder + "App_Inventory/Transaction/StockOutRequest.aspx?loid=" + ((LinkButton)sender).CommandArgument);
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

    #endregion

    #region Gridview Event Handler

    protected void gvMain_RowDataBound(object sender, GridViewRowEventArgs e)
    {
        if (e.Row.RowIndex > -1)
        {
            e.Row.Cells[2].Text = ((e.Row.RowIndex + 1) + (gvMain.PageIndex * gvMain.PageSize)).ToString();
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
            if (i > -1 && gvMain.Rows[i].Cells[1].FindControl("chkSelect") != null)
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
        txtSearchCodeFrom.Text = "";
        txtSearchCodeTo.Text = "";
        this.ctlUseDateFrom.DateValue = new DateTime();
        this.ctlUseDateTo.DateValue = new DateTime();
        this.cmbSearchStatusFrom.SelectedIndex = 0;
        cmbSearchStatusTo.SelectedIndex = cmbSearchStatusTo.Items.Count - 1;
    }

    #endregion

    #region Working Method

    private void doGetList()
    {
        StockOutRequestFlow fFlow = new StockOutRequestFlow();

        // ตรวจสอบเงื่อนไขการค้นหาเพื่อแสดงปุ่ม reset การค้นหา
        imbReset.Visible = (txtSearchCodeFrom.Text.Trim() != "") || (this.txtSearchCodeTo.Text.Trim() != "") || (this.ctlUseDateFrom.DateValue.Year != 1) || (this.ctlUseDateTo.DateValue.Year !=1) ||
            (this.cmbSearchStatusFrom.SelectedIndex !=0) || (this.cmbSearchStatusTo.SelectedIndex != (this.cmbSearchStatusTo.Items.Count-1));

        string orderStr = "";
        if (txhSortField.Text.Trim() != "")
            orderStr = " " + txhSortField.Text + " " + txhSortDir.Text;

        gvMain.DataSource = fFlow.GetMasterList(this.txtSearchCodeFrom.Text.Trim(), this.txtSearchCodeTo.Text.Trim(), this.ctlUseDateFrom.DateValue, this.ctlUseDateTo.DateValue, 
            this.cmbSearchStatusFrom.SelectedItem.Value, this.cmbSearchStatusTo.SelectedItem.Value, Appz.LoggedOnUser.DIVISION, orderStr);
        gvMain.DataBind();
        pcTop.Update();
        pcBot.Update();
    }

    private void doDelete()
    {
        StockOutRequestFlow fFlow = new StockOutRequestFlow();
        if (fFlow.DoDelete(GetChecked()))
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
        StockOutRequestFlow fFlow = new StockOutRequestFlow();
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
