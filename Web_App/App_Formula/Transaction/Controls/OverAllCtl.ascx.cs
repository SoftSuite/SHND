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
/// <summary>
/// FoodType Page Class
/// Version 1.0
/// =========================================================================
/// Create by: Nang
/// Create Date: 9 July 2009
/// -------------------------------------------------------------------------
/// Modify By: -
/// Modify From: -
/// Modify Date: -
/// -------------------------------------------------------------------------
/// Remark: -
/// Description:
///    หน้ากาารทำงานข้อมูล Menu Detail 
/// Changes:
///    1.0 - สร้าง
/// -------------------------------------------------------------------------
/// =========================================================================
/// </summary>
/// 

public partial class App_Formula_Transaction_Controls_OverAllCtl : System.Web.UI.UserControl
{
    public double MenuLOID;
    public event EventHandler LinkClick;

    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            //doGetList();
        }
    }

    protected override void OnInit(EventArgs e)
    {
        base.OnInit(e);

        cmbMeal.Items.Clear();
        cmbMeal.Items.Add(new ListItem("ทั้งหมด", "0"));
        cmbMeal.Items.Add(new ListItem("เช้า", "11"));
        cmbMeal.Items.Add(new ListItem("กลางวัน", "21"));
        cmbMeal.Items.Add(new ListItem("เย็น", "31"));

        cmbGroup.Items.Clear();
        cmbGroup.Items.Add(new ListItem("ทั้งหมด", "0"));
        cmbGroup.Items.Add(new ListItem("ข้าวหรืออาหารจานเดียว", "OD"));
        cmbGroup.Items.Add(new ListItem("กับข้าว", "ND"));
        cmbGroup.Items.Add(new ListItem("ผลไม้หรือของหวาน", "FR"));
        cmbGroup.Items.Add(new ListItem("เครื่องดื่ม", "BV"));

        pcTop.SetMainGridView(grvResult);
        pcBot.SetMainGridView(grvResult);
    }

    #region Button Click Event Handler
     protected void imbSearch_Click(object sender, ImageClickEventArgs e)
    {
        grvResult.PageIndex = 0;
        doGetList();
    }

    protected void imbReset_Click(object sender, ImageClickEventArgs e)
    {
        ClearSearch();
        grvResult.PageIndex = 0;
        doGetList();
    }

    protected void lnkMeal_Click(object sender, EventArgs e)
    {
        LinkButton lnk = (LinkButton)sender;
        Int16 rowIndex = (Int16)((GridViewRow)lnk.Parent.Parent).RowIndex;
        //TextBox txtCode = (TextBox)this.grvItem.Rows[rowIndex].Cells[2].FindControl("txtBarCode");
        TextBox txtCurentMeal = (TextBox)this.Parent.Parent.FindControl("txtCurentMeal");
        TextBox txtCurentDate = (TextBox)this.Parent.Parent.FindControl("txtCurentDate");
        txtCurentMeal.Text = this.grvResult.Rows[rowIndex].Cells[5].Text;
        txtCurentDate.Text = this.grvResult.Rows[rowIndex].Cells[1].Text;
         if (LinkClick != null) LinkClick(sender, e);

    }

    #endregion

    #region Gridview Event Handler

     protected void grvResult_Sorting(object sender, GridViewSortEventArgs e)
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
        grvResult.PageIndex = ((Templates_PageControl)sender).SelectedPageIndex;
        doGetList();
        pcBot.Update();
        pcTop.Update();
    }
    #endregion

    #region Misc. Methods
  

    #endregion

    #region Controls Management Methods
  

    private void ClearSearch()
    {
        // Clear searh data
        txtName.Text = "";
        cmbMeal.SelectedIndex = -1;
        cmbGroup.SelectedIndex = -1;
        ctlDateFrom.DateValue = new DateTime(1, 1, 1);
        ctlDateTo.DateValue = new DateTime(1, 1, 1);
    }

   

    #endregion

    #region Working Method

    private void doGetList()
    {
        MenuFlow mFlow = new MenuFlow();
        DataTable dt = new DataTable();

        imbReset.Visible = (cmbGroup.SelectedItem.Value != "0") || (cmbMeal.SelectedItem.Value != "0") || (txtName.Text.Trim() != "" || ctlDateFrom.DateValue.Year > 1 || ctlDateTo.DateValue.Year > 1);
        string orderStr = " MENUDATE,MEAL,GROUPORDER ";
        if (txhSortField.Text.Trim() != "")
            orderStr = " " + txhSortField.Text + " " + txhSortDir.Text;

        dt = mFlow.GetMenuFormulaList(MenuLOID, ctlDateFrom.DateValue.Date, ctlDateTo.DateValue.Date,
            Convert.ToDouble((cmbMeal.SelectedItem.Value == "" ? "0" : cmbMeal.SelectedItem.Value.ToString())),
            cmbGroup.SelectedItem.Value.ToString(), txtName.Text.Trim(),orderStr);
        grvResult.DataSource = dt;
        grvResult.DataBind();

        pcTop.Update();
        pcBot.Update();
    }

    

 

    #endregion
}
