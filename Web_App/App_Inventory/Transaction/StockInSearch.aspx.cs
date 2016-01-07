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
using SHND.DAL.Views;
using SHND.Data.Views;
using SHND.Flow.Inventory;
using SHND.Data.Common.Utilities;

/// <summary>
/// Supplier Page Class
/// Version 1.0
/// =========================================================================
/// Create by: Somsakoon
/// Create Date: 18 Feb 2009
/// -------------------------------------------------------------------------
/// Modify By: -
/// Modify From: -
/// Modify Date: -
/// -------------------------------------------------------------------------
/// Remark: -
/// Description:
///    หน้ากาารทำงานข้อมูล  StockInSearch  
/// Changes:
///    1.0 - สร้าง
/// -------------------------------------------------------------------------
/// =========================================================================
/// </summary>
/// 


public partial class App_Inventory_Transaction_StockInSearch : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
           doGetList();
           this.tbAdd.ClientClick = "if (document.getElementById('" + this.cmbTypeName.ClientID + "').value == '0') " +
   "{ alert('" + string.Format(DataResources.MSGEI002, "ประเภทการรับเข้า") + "'); return false; } ";
  // "else { " + Appz.OpenReportScript(Constant.Reports.MaterialBD, script, true) + "} ";
        }
    }
    protected override void OnInit(EventArgs e)
    {
        base.OnInit(e);

        Appz.BuildCombo(cmbTypeName, "DOCTYPE", "DOCNAME", "LOID", "ISSTOCKIN = 'Y' AND LOID<>FN_GETCONFIGVALUE(40)", "LOID", "เลือก", "0", false);
        Appz.BuildCombo(cmbSearchTypeName, "DOCTYPE", "DOCNAME", "LOID", "ISSTOCKIN = 'Y'", "LOID", "เลือก", "0", false);
        SetStatusCombo(cmbSearchStatusTo);
        SetStatusCombo(cmbSearcStatusFrom);
        pcTop.SetMainGridView(gvMain);
        pcBot.SetMainGridView(gvMain);
    }
    protected void SetStatusCombo(DropDownList cmbStatus)
    {
        cmbStatus.Items.Clear();
        cmbStatus.Items.Add(new ListItem("กำลังดำเนินการ", "00"));
        //cmbStatus.Items.Add(new ListItem("รออนุมัติ", "01"));
        cmbStatus.Items.Add(new ListItem("อนุมัติ", "02"));
        //cmbStatus.Items.Add(new ListItem("ไม่อนุมัติ", "03"));
        //cmbStatus.Items.Add(new ListItem("ยกเลิก", "04"));
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
        string DocType = this.gvMain.Rows[(( GridViewRow)((LinkButton)sender).Parent.Parent).RowIndex].Cells[7].Text;
        switch (DocType)
        {
            case "5":
                Response.Redirect(Constant.HomeFolder + "App_Inventory/Transaction/StockInOther.aspx?loid=" + ((LinkButton)sender).CommandArgument);
                break;
            default:
                Response.Redirect(Constant.HomeFolder + "App_Inventory/Transaction/StockIn.aspx?loid=" + ((LinkButton)sender).CommandArgument);
                break;
        }
    }

    protected void tbAddClick(object sender, EventArgs e)
    {
        string DocTypeValue = (this.cmbTypeName.SelectedItem.Value);
        switch (DocTypeValue)
        {
            case "5":
                Response.Redirect(Constant.HomeFolder + "App_Inventory/Transaction/StockInOther.aspx?Type=" + this.cmbTypeName.SelectedItem.Value);
                break;
            default:
                Response.Redirect(Constant.HomeFolder + "App_Inventory/Transaction/StockIn.aspx?Type=" + this.cmbTypeName.SelectedItem.Value);
                break;
        }
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
        txhID.Text = "";
        txtSearch.Text = "";
        txtSearchTo.Text = "";
        ctlFrom.DateValue = new DateTime();
        ctlTo.DateValue = new DateTime();
        cmbSearchStatusTo.SelectedIndex = 0;
        cmbSearcStatusFrom.SelectedIndex = 0;
        cmbTypeName.SelectedIndex = 0;
        cmbSearchTypeName.SelectedIndex = 0;
    }

    private void ClearData()
    {
        txhID.Text = "";
        txtSearch.Text = "";
        txtSearchTo.Text = "";
        ctlFrom.DateValue = new DateTime();
        ctlTo.DateValue = new DateTime();
        cmbSearchStatusTo.SelectedIndex = 0;
        cmbSearcStatusFrom.SelectedIndex = 0;
        cmbTypeName.SelectedIndex = 0;
        cmbSearchTypeName.SelectedIndex = 0;
    }

    #endregion

    #region Working Method
    private void doGetList()
    {
        StockInFlow sFlow = new StockInFlow();

        imbReset.Visible = (txtSearch.Text.Trim() != "") || (txtSearchTo.Text.Trim() != "") || (ctlFrom.DateValue.Year != 1) || (ctlTo.DateValue.Year != 1) || (cmbSearchTypeName.SelectedItem.Value != "0") || (cmbSearcStatusFrom.SelectedIndex != 0) || (cmbSearchStatusTo.SelectedIndex != 0);

        string orderStr = "";
       
        if (txhSortField.Text.Trim() != "")
            orderStr = " " + txhSortField.Text + " " + txhSortDir.Text;
        
        gvMain.DataSource = sFlow.GetMasterList(txtSearch.Text, txtSearchTo.Text, ctlFrom.DateValue, ctlTo.DateValue, cmbSearchTypeName.SelectedItem.Value, cmbSearcStatusFrom.SelectedItem.Value, cmbSearchStatusTo.SelectedItem.Value, orderStr);

        gvMain.DataBind();
        pcTop.Update();
        pcBot.Update();

    }
    private void doDelete()
    {
        StockInFlow fFlow = new StockInFlow();
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
