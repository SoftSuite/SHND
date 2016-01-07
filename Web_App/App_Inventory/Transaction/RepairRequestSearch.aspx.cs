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
using SHND.Flow.Inventory;
using SHND.Data;
using SHND.Data.Tables;
using SHND.Data.Inventory;
using SHND.Global;
using SHND.Flow.Common;
using SHND.Data.Common.Utilities;
/// <summary>
/// RepairRequest Page Class
/// Version 1.0
/// =========================================================================
/// Create by: Pro
/// Create Date: 10 FEB 2009
/// -------------------------------------------------------------------------
/// Modify By: -
/// Modify From: -
/// Modify Date: -
/// -------------------------------------------------------------------------
/// Remark: -
/// Description:
///    หน้ากาารทำงาน RepairRequest
/// Changes:
///    1.0 - สร้าง
/// -------------------------------------------------------------------------
/// =========================================================================
/// </summary>
/// 

public partial class App_Inventory_Transaction_RepairRequestSearch : System.Web.UI.Page
{
    private void SetStatusCombo(DropDownList cmb)
    {
        cmb.Items.Clear();
        cmb.Items.Add(new ListItem("ทำรายการ", "00"));
        cmb.Items.Add(new ListItem("รอส่งซ่อม", "01"));
        cmb.Items.Add(new ListItem("ส่งซ่อมแล้ว", "02"));
        cmb.Items.Add(new ListItem("เสร็จสิ้น", "04"));
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
    }

    #region Controls Management Methods
    
    private void ClearSearch()
    {
        // Clear searh data
        this.txtCodeFrom.Text = "";
        this.txtCodeTo.Text = "";
        ctlStartDate.DateValue = new DateTime();
        ctlEndDate.DateValue = new DateTime();
        cmbSearchStatusFrom.SelectedIndex = 0;
        cmbSearchStatusTo.SelectedIndex = 0;
    }
    private void ClearData()
    {
       
    }
    private RepairRequestData GetData()
    {
        RepairRequestData ftData = new RepairRequestData();
        return ftData;
    }
    #endregion

    #region Button Click Event Handler

    protected void tbAddClick(object sender, EventArgs e)
    {
        Response.Redirect(Constant.HomeFolder + "App_Inventory/Transaction/RepairRequest.aspx");
    }
    protected void tbDeleteClick(object sender, EventArgs e)
    {
        doDelete();
    }
    protected void tbSentClick(object sender, EventArgs e)
    {
        RepairRequestFlow FlowObj = new RepairRequestFlow();
        //doSent();
        if (FlowObj.UpdateStatus(GetChecked(), "SE", Appz.CurrentUser))
        {
            doGetList();
        }
        else
            SetStatus(FlowObj.ErrorMessage, true);
    }
    protected void lnkCode_Click(object sender, EventArgs e)
    {
        //doGetDetail(((LinkButton)sender).CommandArgument);
        Response.Redirect(Constant.HomeFolder + "App_Inventory/Transaction/RepairRequest.aspx?loid=" +((LinkButton)sender).CommandArgument);
       
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
    #region Paging Event Handler
    protected void PageChange(object sender, EventArgs e)
    {
        gvMain.PageIndex = ((Templates_PageControl)sender).SelectedPageIndex;
        doGetList();
        pcBot.Update();
        pcTop.Update();
    }
     #endregion


    #region Gridview Event Handler

    protected void gvMain_RowDataBound(object sender, GridViewRowEventArgs e)
    {
        if (e.Row.RowIndex > -1)
            e.Row.Cells[2].Text = ((e.Row.RowIndex + 1) + (gvMain.PageIndex * gvMain.PageSize)).ToString();
        else if (e.Row.RowType == DataControlRowType.DataRow)
        {
            DataRow drow = (DataRow)((DataRowView)e.Row.DataItem).Row;
            CheckBox chk = (CheckBox)e.Row.Cells[1].FindControl("chkSelect");
            chk.Enabled = (drow["STATUS"].ToString() != "SE");
        }
    }
    private void SetStatus(string t, bool isError)
    {
        this.lbStatus.Text = t;
        this.lbStatus.ForeColor = (isError ? Constant.StatusColor.Error : Constant.StatusColor.Information);
    }
    protected void gvMain_Sorting(object sender, GridViewSortEventArgs e)
    {
        RepairRequestFlow fFlow = new RepairRequestFlow();
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

    #region Working Method
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
    private void doGetList()
    {
        RepairRequestFlow fFlow = new RepairRequestFlow();

        // ตรวจสอบเงื่อนไขการค้นหาเพื่อแสดงปุ่ม reset การค้นหา
        imbReset.Visible = (this.txtCodeFrom.Text.Trim() != "") || (this.txtCodeTo.Text.Trim() != "") || ctlStartDate.DateValue.Year != 1 || ctlEndDate.DateValue.Year != 1 ||
            (this.cmbSearchStatusFrom.SelectedIndex != 0) || (this.cmbSearchStatusTo.SelectedIndex != this.cmbSearchStatusTo.Items.Count - 1);


        string orderStr = "";
        if (txhSortField.Text.Trim() != "")
            orderStr = " " + txhSortField.Text + " " + txhSortDir.Text;



        gvMain.DataSource = fFlow.GetMasterRepairList(txtCodeFrom.Text, txtCodeTo.Text, ctlStartDate.DateValue, ctlEndDate.DateValue, this.cmbSearchStatusFrom.SelectedItem.Value, this.cmbSearchStatusTo.SelectedItem.Value, Appz.LoggedOnUser.DIVISION.ToString(), orderStr);
        gvMain.DataBind();
        pcTop.Update();
        pcBot.Update();
    }

    private void doDelete()
    {
        RepairRequestFlow fFlow = new RepairRequestFlow();
        if (fFlow.DeleteByLOID(GetChecked()))
        {
            gvMain.PageIndex = 0;
            doGetList();
            lbStatusMain.Text = "";
        }
        else
        {
            //lbStatusMain.Text = fFlow.ErrorMessage;
            //lbStatusMain.ForeColor = System.Drawing.Color.Red;
            SetStatus(fFlow.ErrorMessage, true);
        }

    }

    #endregion

}
