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
using SHND.Data.Formula;
using SHND.Flow.Formula;
using SHND.Global;

/// <summary>
/// FoodType Page Class
/// Version 1.0
/// =========================================================================
/// Create by: Teang
/// Create Date: 5 Jan 2009
/// -------------------------------------------------------------------------
/// Modify By: Nang
/// Modify From: เพิ่มค้นหาหน่วยงาน
/// Modify Date: 13 July 2009
/// -------------------------------------------------------------------------
/// Remark: -
/// Description:
///    หน้ากาารทำงานข้อมูล Formula set 
/// Changes:
///    1.0 - สร้าง
/// -------------------------------------------------------------------------
/// =========================================================================
/// </summary>
/// 
public partial class App_Formula_Transaction_FormulaSetSearch : System.Web.UI.Page
{
    private void SetStatusCombo(DropDownList cmb)
    {
        cmb.Items.Clear();
        cmb.Items.Add(new ListItem("กำลังดำเนินการ", "00"));
        cmb.Items.Add(new ListItem("ทดลอง", "01"));
        cmb.Items.Add(new ListItem("อนุมัติ", "02"));
        cmb.Items.Add(new ListItem("ไม่อนุมัติ", "03"));
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
        Appz.BuildCombo(cmbSearchFoodCategory, "FOODCATEGORY", "NAME", "LOID", "ACTIVE='1' AND LOID NOT IN (FN_GETCONFIGVALUE(31), FN_GETCONFIGVALUE(32))", "NAME", "เลือก", "0", false);  //ชนิดอาหารให้แสดงเฉพาะที่เป็นชนิดอาหารสำรับ
        Appz.BuildCombo(cmbDivision, "DIVISION", "NAME", "LOID", "ACTIVE='1' AND ISFORMULA='Y'","NAME", "เลือก", "0", false);
        cmbDivision.SelectedValue = Appz.LoggedOnUser.DIVISION.ToString();
        Appz.BuildCombo(cmbSearchFoodType, "FOODTYPE", "NAME", "LOID", "ACTIVE='1' AND LOID<>3 AND DIVISION='" + cmbDivision.SelectedItem.Value + "' ", "NAME", "เลือก", "0", false); //ตรงประเภทอาหารไม่ต้องแสดงอาหารทางสายให้อาหาร
        txtDivision.Text = Appz.LoggedOnUser.DIVISION.ToString();

        SetStatusCombo(cmbSearchStatusFrom);
        SetStatusCombo(cmbSearchStatusTo);
        pcTop.SetMainGridView(gvMain);
        pcBot.SetMainGridView(gvMain);
        ClearSearch();
    }

    #region Button Click Event Handler

    protected void tbAddClick(object sender, EventArgs e)
    {
        Response.Redirect(Constant.HomeFolder + "App_Formula/Transaction/FormulaSet.aspx?loid=0");
    }

    protected void lnkFormulaSet_Click(object sender, EventArgs e)
    {
        Response.Redirect(Constant.HomeFolder + "App_Formula/Transaction/FormulaSet.aspx?loid=" + ((LinkButton)sender).CommandArgument);
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
        doCopy(Convert.ToDouble(((ImageButton)sender).CommandArgument));
    }

    #endregion

    #region Gridview Event Handler

    protected void gvMain_RowDataBound(object sender, GridViewRowEventArgs e)
    {
        if (e.Row.RowIndex > -1)
        {
            e.Row.Cells[3].Text = ((e.Row.RowIndex + 1) + (gvMain.PageIndex * gvMain.PageSize)).ToString();
            ((ImageButton)e.Row.Cells[2].FindControl("imbDelete")).OnClientClick = "return confirm('" + string.Format(DataResources.MSGCD004, "ข้อมูลสูตรอาหารสำรับ", e.Row.Cells[1].Text) + "')";
            ((ImageButton)e.Row.Cells[2].FindControl("imbCopy")).OnClientClick = "return confirm('" + string.Format(DataResources.MSGCC001, "ข้อมูลสูตรอาหารสำรับ", e.Row.Cells[1].Text) + "')";
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

    #region Controls Management Methods

    private void ClearSearch()
    {
        // Clear searh data
        txtSearchName.Text = "";
        cmbSearchFoodType.SelectedIndex = 0;
        cmbSearchFoodCategory.SelectedIndex = 0;
        rdbAll.Checked = true;
        rdbNormal.Checked = false;
        rdbSpecific.Checked = false;
        cmbSearchStatusFrom.SelectedIndex = 0;
        cmbSearchStatusTo.SelectedIndex = cmbSearchStatusTo.Items.Count-1;
        chkActive.Checked = true;
    }

    #endregion

    #region Working Method

    private void doGetList()
    {
        FormulaSetFlow fFlow = new FormulaSetFlow();
        FormulaSetSearchData condition = new FormulaSetSearchData();
       //condition.DIVISION = Appz.LoggedOnUser.DIVISION;
        condition.DIVISION = Convert.ToDouble(cmbDivision.SelectedItem.Value);
        condition.FoodCategory = Convert.ToDouble(cmbSearchFoodCategory.SelectedItem.Value);
        condition.FoodType = Convert.ToDouble(cmbSearchFoodType.SelectedItem.Value);
        condition.FormulaSetName = this.txtSearchName.Text.Trim();
        if (rdbNormal.Checked)
            condition.IsSpecific = "N";
        else if (rdbSpecific.Checked)
            condition.IsSpecific = "Y";
        condition.StatusRankFrom = cmbSearchStatusFrom.SelectedItem.Value;
        condition.StatusRankTo = cmbSearchStatusTo.SelectedItem.Value;
        condition.Active = chkActive.Checked ? "1" : "0";

        // ตรวจสอบเงื่อนไขการค้นหาเพื่อแสดงปุ่ม reset การค้นหา
        imbReset.Visible = (txtSearchName.Text.Trim() != "") || (cmbSearchFoodCategory.SelectedIndex != 0) || (cmbSearchFoodType.SelectedIndex != 0) || (!rdbAll.Checked) || (cmbSearchStatusFrom.SelectedIndex != 0) || (cmbSearchStatusTo.SelectedIndex != cmbSearchStatusTo.Items.Count - 1) || !chkActive.Checked;

        string orderStr = "";
        if (txhSortField.Text.Trim() != "")
            orderStr = " " + txhSortField.Text + " " + txhSortDir.Text;

        gvMain.DataSource = fFlow.GetMasterList(condition, orderStr);
        gvMain.DataBind();
        pcTop.Update();
        pcBot.Update();
    }

    private void doCopy(double refFormulaSet)
    {
        FormulaSetFlow FormulaSet = new FormulaSetFlow();
        if (FormulaSet.CopyData(refFormulaSet,Appz.LoggedOnUser.DIVISION, Appz.CurrentUser))
        {
            Response.Redirect(Constant.HomeFolder + "App_Formula/Transaction/FormulaSet.aspx?loid=" + FormulaSet.LOID.ToString());
        }
        else
        {
            this.lbStatusMain.Text = FormulaSet.ErrorMessage;
            this.lbStatusMain.ForeColor = Constant.StatusColor.Error;
        }
    }

    private void doDelete(double LOID)
    {
        FormulaSetFlow fFlow = new FormulaSetFlow();
        if (fFlow.DeleteByLOID(LOID))
        {
            gvMain.PageIndex = 0;
            doGetList();
            lbStatusMain.Text = "";
        }
        else
        {
            lbStatusMain.Text = fFlow.ErrorMessage;
            lbStatusMain.ForeColor = Constant.StatusColor.Error;
        }

    }

    #endregion

    protected void cmbDivision_SelectedIndexChanged(object sender, EventArgs e)
    {
        Appz.BuildCombo(cmbSearchFoodType, "FOODTYPE", "NAME", "LOID", "ACTIVE='1' AND LOID<>3 AND DIVISION='" + cmbDivision.SelectedValue + "' ", "NAME", "เลือก", "0", false); //ตรงประเภทอาหารไม่ต้องแสดงอาหารทางสายให้อาหาร
    }
}
