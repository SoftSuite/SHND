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
using SHND.Data.Views;
using SHND.Global;
using SHND.Flow.Common;
using SHND.Data.Common.Utilities;

/// <summary>
/// FoodType Page Class
/// Version 1.0
/// =========================================================================
/// Create by: Tan
/// Create Date: 9 Jan 2009
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
public partial class App_Formula_Master_BlenderizeDietSearch : System.Web.UI.Page
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
        pcTop.SetMainGridView(gvMain);
        pcBot.SetMainGridView(gvMain);
        ControlUtil.SetDblTextBoxRealNumer(this.txtCapFrom);
        ControlUtil.SetDblTextBoxRealNumer(this.txtCapTo);
        ControlUtil.SetDblTextBoxRealNumer(this.txtEnFrom);
        ControlUtil.SetDblTextBoxRealNumer(this.txtEnTo);
    }

    #region Button Click Event Handler

    protected void tbAddClick(object sender, EventArgs e)
    {
        Response.Redirect(Constant.HomeFolder + "App_Formula/Master/BlenderizeDietDetail.aspx");
    }

    protected void lnkFood_Click(object sender, EventArgs e)
    {
        Response.Redirect(Constant.HomeFolder + "App_Formula/Master/BlenderizeDietDetail.aspx?loid=" + ((LinkButton)sender).CommandArgument);
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

    protected void imbDelete_Click(object sender, ImageClickEventArgs e)
    {
        doDelete(Convert.ToDouble(((ImageButton)sender).CommandArgument));
    }

    protected void imbCopy_Click(object sender, ImageClickEventArgs e)
    {
        BlenderizeDietFlow FormulaFeed = new BlenderizeDietFlow();
        if (FormulaFeed.CopyData(Convert.ToDouble(((ImageButton)sender).CommandArgument), Appz.CurrentUser))
        {
            //this.lbStatusMain.Text = "";
            Response.Redirect(Constant.HomeFolder + "App_Formula/Master/BlenderizeDietDetail.aspx?loid=" + FormulaFeed.LOID.ToString());
        }
        else
        {
            this.lbStatusMain.Text = FormulaFeed.ErrorMessage;
            this.lbStatusMain.ForeColor = Constant.StatusColor.Error;
        }
    }

    #endregion

    #region Gridview Event Handler

    protected void gvMain_RowDataBound(object sender, GridViewRowEventArgs e)
    {
        if (e.Row.RowIndex > -1)
            e.Row.Cells[2].Text = ((e.Row.RowIndex + 1) + (gvMain.PageIndex * gvMain.PageSize)).ToString();
        if (e.Row.RowType == DataControlRowType.DataRow)
        {
            if (e.Row.RowState == DataControlRowState.Normal || e.Row.RowState == DataControlRowState.Alternate)
            {
                LinkButton lnkFood = (LinkButton)e.Row.FindControl("lnkFood");
                ImageButton imbDelete = (ImageButton)e.Row.FindControl("imbDelete");
                imbDelete.OnClientClick = "return confirm('ต้องการลบข้อมูลที่เลือกใช่หรือไม่');";
                ImageButton imbCopy = (ImageButton)e.Row.FindControl("imbCopy");
                imbCopy.OnClientClick = "return confirm('ต้องการคัดลอกรายการข้อมูลสูตร " + lnkFood.Text + " ใช่หรือไม่');";
            }
        }
    }

    protected void gvMain_Sorting(object sender, GridViewSortEventArgs e)
    {
        FoodTypeFlow fFlow = new FoodTypeFlow();
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
        txtSearchName.Text = "";
        txtCapFrom.Text = "";
        txtCapTo.Text = "";
        txtEnFrom.Text = "";
        txtEnTo.Text = "";
    }

    #endregion

    #region Working Method

    private void doGetList()
    {
        BlenderizeDietFlow fFlow = new BlenderizeDietFlow();

        // ตรวจสอบเงื่อนไขการค้นหาเพื่อแสดงปุ่ม reset การค้นหา
        imbReset.Visible = (txtSearchName.Text.Trim() != "") || (txtCapFrom.Text.Trim() != "") || (txtCapTo.Text.Trim() != "") || (txtEnFrom.Text.Trim() != "") || (txtEnTo.Text.Trim() != "");

        string orderStr = "";
        if (txhSortField.Text.Trim() != "")
            orderStr = " " + txhSortField.Text + " " + txhSortDir.Text;

        gvMain.DataSource = fFlow.GetMasterList(txtSearchName.Text, txtCapFrom.Text, txtCapTo.Text, txtEnFrom.Text, txtEnTo.Text, orderStr);
        gvMain.DataBind();
        pcTop.Update();
        pcBot.Update();
    }
    private void doDelete(double LOID)
    {
        BlenderizeDietFlow fFlow = new BlenderizeDietFlow();
        if (fFlow.DeleteByLOID(LOID))
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
