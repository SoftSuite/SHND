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
using SHND.Data.Tables;
using SHND.Data.Views;
using SHND.Flow.Formula;
using SHND.Global;

/// <summary>
/// FoodType Page Class
/// Version 1.0
/// =========================================================================
/// Create by: Teang
/// Create Date: 15 Jan 2009
/// -------------------------------------------------------------------------
/// Modify By: -
/// Modify From: -
/// Modify Date: -
/// -------------------------------------------------------------------------
/// Remark: -
/// Description:
///    หน้าการทำรายการข้อมูล Standard Menu
/// Changes:
///    1.0 - สร้าง
/// -------------------------------------------------------------------------
/// =========================================================================
/// </summary>
/// 
public partial class App_Formula_Transaction_StandardMenu : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            doGetDetail((Request["loid"] == null ? "0" : Request["loid"]));
        }
    }

    protected override void OnInit(EventArgs e)
    {
        base.OnInit(e);
        // set Combo source
        Appz.BuildCombo(cmbFoodType, "FOODTYPE", "NAME", "LOID", "ACTIVE='1' AND LOID<>3 AND DIVISION = " + Appz.LoggedOnUser.DIVISION.ToString(), "NAME", "เลือก", "0", false); //ตรงประเภทอาหารไม่ต้องแสดงอาหารทางสายให้อาหาร
        Appz.BuildCombo(cmbFoodCategory, "FOODCATEGORY", "NAME", "LOID", "ACTIVE='1' AND LOID NOT IN (FN_GETCONFIGVALUE(31), FN_GETCONFIGVALUE(32))", "NAME", "เลือก", "0", false);  //ชนิดอาหารให้แสดงเฉพาะที่เป็นชนิดอาหารสำรับ

        this.txtCurentTab.Text = this.tabStdMenu.ActiveTabIndex.ToString();
        this.ctlStdMenuItemBreakfast.Meal = "11";
        this.ctlStdMenuItemDinner.Meal = "31";
        this.ctlStdMenuItemLunch.Meal = "21";
    }

    protected void tabStdMenu_ActiveTabChanged(object sender, EventArgs e)
    {
        if (this.txtStatus.Text != "AP" && this.txtStatus.Text != "CO" && this.tbSave.Visible)
        {
            if (!doSave())
                this.tabStdMenu.ActiveTabIndex = Convert.ToInt32(this.txtCurentTab.Text);
        }
        else
        {
            doGetDetail("0" + this.txtLOID.Text);
        }
    }

    protected void ctlDiseaseCategoryPopup_SelectedIndexChanged(object sender, EventArgs e, ArrayList arrData)
    {
        StandardMenuDetailItem fsItem = new StandardMenuDetailItem();
        if (fsItem.InsertStdMenuDisease(Convert.ToDouble("0" + this.txtLOID.Text), arrData))
            BindStdMenuDisease();
    }

    protected void cmbFoodType_SelectedIndexChanged(object sender, EventArgs e)
    {
        this.ctlStdMenuItemBreakfast.FoodType = Convert.ToDouble("0" + this.cmbFoodType.SelectedItem.Value);
        this.ctlStdMenuItemDinner.FoodType = Convert.ToDouble("0" + this.cmbFoodType.SelectedItem.Value);
        this.ctlStdMenuItemLunch.FoodType = Convert.ToDouble("0" + this.cmbFoodType.SelectedItem.Value);
        switch (this.txtCurentTab.Text)
        {
            case "0":
                break;
            case "1":
                ctlStdMenuItemBreakfast.BindData();
                break;
            case "2":
                ctlStdMenuItemLunch.BindData();
                break;
            case "3":
                ctlStdMenuItemDinner.BindData();
                break;
        }
    }

    #region Button Click Event Handler

    #region Main Toolbar
    protected void tbSaveClick(object sender, EventArgs e)
    {
        if (this.txtStatus.Text != "AP" && this.txtStatus.Text != "CO")
            doSave();
        else
            doUpdateActive();
    }
    protected void tbCancelClick(object sender, EventArgs e)
    {
        doGetDetail("0" + this.txtLOID.Text);
    }
    protected void tbBackClick(object sender, EventArgs e)
    {
        Response.Redirect(Constant.HomeFolder + "App_Formula/Transaction/StandardMenuSearch.aspx");
    }
    protected void tbConfirmClick(object sender, EventArgs e)
    {
        string old = this.txtStatus.Text;
        this.txtStatus.Text = "CO";
        if (!doSave())
            this.txtStatus.Text = old;
    }
    protected void tbApproveClick(object sender, EventArgs e)
    {
        doApprove();
    }
    protected void tbNotApproveClick(object sender, EventArgs e)
    {
        doNotApprove();
    }
    #endregion

    #region StdMenuDisease Toolbar
    protected void tbAddStdMenuDiseaseClick(object sender, EventArgs e)
    {
        StandardMenuDetailItem fsItem = new StandardMenuDetailItem();
        this.ctlDiseaseCategoryPopup.Show("1", cmbFoodCategory.SelectedValue, fsItem.GetDiseaseCategoryList());
    }
    protected void tbDeleteStdMenuDiseaseClick(object sender, EventArgs e)
    {
        StandardMenuDetailItem fsItem = new StandardMenuDetailItem();
        if (fsItem.DeleteStdMenuDisease(GetCheckStdMenuDisease())) BindStdMenuDisease();
    }
    #endregion

    #endregion

    #region Misc. Methods

    private ArrayList GetCheckStdMenuDisease()
    {
        ArrayList arrChk = new ArrayList();
        for (int i = 0; i < gvStdMenuDisease.Rows.Count; i++)
        {
            if (i > -1 && gvStdMenuDisease.Rows[i].Cells[1].FindControl("chkSelect") != null)
            {
                GridViewRow gRow = gvStdMenuDisease.Rows[i];
                if (((CheckBox)gRow.Cells[1].FindControl("chkSelect")).Checked)
                {
                    arrChk.Add(Convert.ToDouble(gRow.Cells[0].Text));
                }
            }
        }
        return arrChk;
    }

    #endregion

    #region Controls Management Methods

    private void BindStdMenuDisease()
    {
        this.gvStdMenuDisease.DataBind();
    }

    protected void gvStdMenuDisease_RowDataBound(object sender, GridViewRowEventArgs e)
    {
        //if (e.Row.RowType == DataControlRowType.Header)
        //{
        //    ((CheckBox)e.Row.Cells[1].FindControl("chkMain")).Attributes.Add("onclick", "chkAllBox(this, '" + this.gvFormulaDisease.ClientID + "_ctl', '_chkSelect')");
        //}

        if (e.Row.RowType == DataControlRowType.DataRow)
        {
            //Check ว่า radio button radISHIGH จะ visible เป็น true หรือ false
            if (e.Row.Cells[7].Text.Trim() == "N")
            {
                RadioButton chkHigh = (RadioButton)e.Row.FindControl("chkHigh");
                if (chkHigh != null)
                    chkHigh.Visible = false;
            }

            //Check ว่า radio button radISLOW จะ visible เป็น true หรือ false
            if (e.Row.Cells[8].Text.Trim() == "N")
            {
                RadioButton chkLow = (RadioButton)e.Row.FindControl("chkLow");
                if (chkLow != null)
                    chkLow.Visible = false;
            }

            //Check ว่า radio button radISNON จะ visible เป็น true หรือ false
            if (e.Row.Cells[9].Text.Trim() == "N")
            {
                RadioButton chkNon = (RadioButton)e.Row.FindControl("chkNon");
                if (chkNon != null)
                    chkNon.Visible = false;
            }

        }
    }

    private void SetStatus(string t)
    {
        lbStatus.Text = t;
        lbStatus.ForeColor = Constant.StatusColor.Information;
    }

    private void SetErrorStatus(string t)
    {
        lbStatus.Text = t;
        lbStatus.ForeColor = Constant.StatusColor.Error;
    }

    private StdMenuDetailData GetData()
    {
        StdMenuDetailData fsData = new StdMenuDetailData();
        fsData.ACTIVE = this.chkActive.Checked;
        fsData.DIVISION = Convert.ToDouble("0" + this.txtDivision.Text);
        fsData.FOODCATEGORY= Convert.ToDouble(this.cmbFoodCategory.SelectedItem.Value);
        fsData.FOODTYPE = Convert.ToDouble(this.cmbFoodType.SelectedItem.Value);
        fsData.ISSPECIFIC = this.chkIsSpecific.Checked;
        fsData.LOID = Convert.ToDouble("0" + this.txtLOID.Text);
        fsData.NAME = this.txtName.Text.Trim();
        fsData.STATUS = this.txtStatus.Text.Trim();

        if (this.chkIsSpecific.Enabled)
        {
            switch (this.txtCurentTab.Text)
            {
                case "0":
                    StandardMenuDetailItem item = new StandardMenuDetailItem();
                    fsData.StdMenuDisease = item.GetStdMenuDiseaseData();
                    break;
                case "1":
                    //fsData.DAY = ctlStdMenuItemBreakfast.Day;
                    fsData.SelectedDay = ctlStdMenuItemBreakfast.SelectedDay;
                    fsData.MEAL = ctlStdMenuItemBreakfast.Meal;
                    fsData.StdMenuItem = ctlStdMenuItemBreakfast.SelectedData();
                    break;
                case "2":
                    //fsData.DAY = ctlStdMenuItemLunch.Day;
                    fsData.SelectedDay = ctlStdMenuItemLunch.SelectedDay;
                    fsData.MEAL = ctlStdMenuItemLunch.Meal;
                    fsData.StdMenuItem = ctlStdMenuItemLunch.SelectedData();
                    break;
                case "3":
                    //fsData.DAY = ctlStdMenuItemDinner.Day;
                    fsData.SelectedDay = ctlStdMenuItemDinner.SelectedDay;
                    fsData.MEAL = ctlStdMenuItemDinner.Meal;
                    fsData.StdMenuItem = ctlStdMenuItemDinner.SelectedData();
                    break;
            }
        }
        return fsData;
    }

    private void ViewData(bool isView)
    {
        this.txtName.ReadOnly = isView;
        this.txtName.CssClass = (isView ? "zTextbox-View" : "zTextbox");
        this.cmbFoodCategory.Enabled = !isView;
        this.cmbFoodType.Enabled = !isView;
        this.chkIsSpecific.Enabled = !isView;

        tbAddStdMenuDisease.Visible = !isView;
        tbDeleteStdMenuDisease.Visible = !isView;
        this.gvStdMenuDisease.Columns[1].Visible = !isView;

        this.ctlStdMenuItemBreakfast.Readonly = isView;
        this.ctlStdMenuItemDinner.Readonly = isView;
        this.ctlStdMenuItemLunch.Readonly = isView;
    }

    private void SetData(StdMenuDetailData fsData)
    {
        bool pageAuthorized = true;
        this.chkActive.Checked = fsData.ACTIVE;
        this.txtDivision.Text = fsData.DIVISION.ToString();
        this.txtDivisionName.Text = fsData.DIVISIONNAME;
        this.cmbFoodCategory.SelectedIndex = this.cmbFoodCategory.Items.IndexOf(this.cmbFoodCategory.Items.FindByValue(fsData.FOODCATEGORY.ToString()));
        this.cmbFoodType.SelectedIndex = this.cmbFoodType.Items.IndexOf(this.cmbFoodType.Items.FindByValue(fsData.FOODTYPE.ToString()));
        this.chkIsSpecific.Checked = fsData.ISSPECIFIC;
        this.txtLOID.Text = fsData.LOID.ToString();
        this.txtName.Text = fsData.NAME;
        this.txtStatus.Text = fsData.STATUS;
        this.txtStatusName.Text = fsData.STATUSNAME;
        if (fsData.LOID == 0)
        {
            this.txtStatus.Text = "WA";
            this.txtDivision.Text = Appz.LoggedOnUser.DIVISION.ToString();
            this.txtDivisionName.Text = Appz.LoggedOnUser.DIVISIONNAME;
        }
        this.tbPrint.ClientClick = Appz.OpenReportScript(Constant.Reports.StdMenuReport_1, fsData.LOID, true);
        this.ctlStdMenuItemBreakfast.FoodType = Convert.ToDouble("0" + this.cmbFoodType.SelectedItem.Value);
        this.ctlStdMenuItemDinner.FoodType = Convert.ToDouble("0" + this.cmbFoodType.SelectedItem.Value);
        this.ctlStdMenuItemLunch.FoodType = Convert.ToDouble("0" + this.cmbFoodType.SelectedItem.Value);
        switch (this.txtCurentTab.Text)
        {
            case "0":
                StandardMenuDetailItem item = new StandardMenuDetailItem();
                item.ClearStdMenuDisease();
                BindStdMenuDisease();
                break;
            case "1":
                ctlStdMenuItemBreakfast.StdMenu = fsData.LOID;
                ctlStdMenuItemBreakfast.Day1 = fsData.DAY0111; ctlStdMenuItemBreakfast.Day2 = fsData.DAY0211; ctlStdMenuItemBreakfast.Day3 = fsData.DAY0311;
                ctlStdMenuItemBreakfast.Day4 = fsData.DAY0411; ctlStdMenuItemBreakfast.Day5 = fsData.DAY0511; ctlStdMenuItemBreakfast.Day6 = fsData.DAY0611;
                ctlStdMenuItemBreakfast.Day7 = fsData.DAY0711; ctlStdMenuItemBreakfast.Day8 = fsData.DAY0811; ctlStdMenuItemBreakfast.Day9 = fsData.DAY0911;
                ctlStdMenuItemBreakfast.Day10 = fsData.DAY1011; ctlStdMenuItemBreakfast.Day11 = fsData.DAY1111; ctlStdMenuItemBreakfast.Day12 = fsData.DAY1211;
                ctlStdMenuItemBreakfast.Day13 = fsData.DAY1311; ctlStdMenuItemBreakfast.Day14 = fsData.DAY1411; ctlStdMenuItemBreakfast.Day15 = fsData.DAY1511;
                ctlStdMenuItemBreakfast.Day16 = fsData.DAY1611; ctlStdMenuItemBreakfast.Day17 = fsData.DAY1711; ctlStdMenuItemBreakfast.Day18 = fsData.DAY1811;
                ctlStdMenuItemBreakfast.Day19 = fsData.DAY1911; ctlStdMenuItemBreakfast.Day20 = fsData.DAY2011; ctlStdMenuItemBreakfast.Day21 = fsData.DAY2111;
                ctlStdMenuItemBreakfast.Day22 = fsData.DAY2211; ctlStdMenuItemBreakfast.Day23 = fsData.DAY2311; ctlStdMenuItemBreakfast.Day24 = fsData.DAY2411;
                ctlStdMenuItemBreakfast.Day25 = fsData.DAY2511; ctlStdMenuItemBreakfast.Day26 = fsData.DAY2611; ctlStdMenuItemBreakfast.Day27 = fsData.DAY2711;
                ctlStdMenuItemBreakfast.Day28 = fsData.DAY2811; ctlStdMenuItemBreakfast.Day29 = fsData.DAY2911; ctlStdMenuItemBreakfast.Day30 = fsData.DAY3011;
                ctlStdMenuItemBreakfast.Day31 = fsData.DAY3111;
                ctlStdMenuItemBreakfast.BindData();
                break;
            case "2":
                ctlStdMenuItemLunch.StdMenu = fsData.LOID;
                ctlStdMenuItemLunch.Day1 = fsData.DAY0121; ctlStdMenuItemLunch.Day2 = fsData.DAY0221; ctlStdMenuItemLunch.Day3 = fsData.DAY0321;
                ctlStdMenuItemLunch.Day4 = fsData.DAY0421; ctlStdMenuItemLunch.Day5 = fsData.DAY0521; ctlStdMenuItemLunch.Day6 = fsData.DAY0621;
                ctlStdMenuItemLunch.Day7 = fsData.DAY0721; ctlStdMenuItemLunch.Day8 = fsData.DAY0821; ctlStdMenuItemLunch.Day9 = fsData.DAY0921;
                ctlStdMenuItemLunch.Day10 = fsData.DAY1031; ctlStdMenuItemLunch.Day11 = fsData.DAY1121; ctlStdMenuItemLunch.Day12 = fsData.DAY1221;
                ctlStdMenuItemLunch.Day13 = fsData.DAY1321; ctlStdMenuItemLunch.Day14 = fsData.DAY1421; ctlStdMenuItemLunch.Day15 = fsData.DAY1521;
                ctlStdMenuItemLunch.Day16 = fsData.DAY1621; ctlStdMenuItemLunch.Day17 = fsData.DAY1721; ctlStdMenuItemLunch.Day18 = fsData.DAY1821;
                ctlStdMenuItemLunch.Day19 = fsData.DAY1921; ctlStdMenuItemLunch.Day20 = fsData.DAY2021; ctlStdMenuItemLunch.Day21 = fsData.DAY2121;
                ctlStdMenuItemLunch.Day22 = fsData.DAY2221; ctlStdMenuItemLunch.Day23 = fsData.DAY2321; ctlStdMenuItemLunch.Day24 = fsData.DAY2421;
                ctlStdMenuItemLunch.Day25 = fsData.DAY2521; ctlStdMenuItemLunch.Day26 = fsData.DAY2621; ctlStdMenuItemLunch.Day27 = fsData.DAY2721;
                ctlStdMenuItemLunch.Day28 = fsData.DAY2821; ctlStdMenuItemLunch.Day29 = fsData.DAY2921; ctlStdMenuItemLunch.Day30 = fsData.DAY3021;
                ctlStdMenuItemLunch.Day31 = fsData.DAY3121;
                ctlStdMenuItemLunch.BindData();
                break;
            case "3":
                ctlStdMenuItemDinner.StdMenu = fsData.LOID;
                ctlStdMenuItemDinner.Day1 = fsData.DAY0131; ctlStdMenuItemDinner.Day2 = fsData.DAY0231; ctlStdMenuItemDinner.Day3 = fsData.DAY0331;
                ctlStdMenuItemDinner.Day4 = fsData.DAY0431; ctlStdMenuItemDinner.Day5 = fsData.DAY0531; ctlStdMenuItemDinner.Day6 = fsData.DAY0631;
                ctlStdMenuItemDinner.Day7 = fsData.DAY0731; ctlStdMenuItemDinner.Day8 = fsData.DAY0831; ctlStdMenuItemDinner.Day9 = fsData.DAY0931;
                ctlStdMenuItemDinner.Day10 = fsData.DAY1031; ctlStdMenuItemDinner.Day11 = fsData.DAY1131; ctlStdMenuItemDinner.Day12 = fsData.DAY1231;
                ctlStdMenuItemDinner.Day13 = fsData.DAY1331; ctlStdMenuItemDinner.Day14 = fsData.DAY1431; ctlStdMenuItemDinner.Day15 = fsData.DAY1531;
                ctlStdMenuItemDinner.Day16 = fsData.DAY1631; ctlStdMenuItemDinner.Day17 = fsData.DAY1731; ctlStdMenuItemDinner.Day18 = fsData.DAY1831;
                ctlStdMenuItemDinner.Day19 = fsData.DAY1931; ctlStdMenuItemDinner.Day20 = fsData.DAY2031; ctlStdMenuItemDinner.Day21 = fsData.DAY2131;
                ctlStdMenuItemDinner.Day22 = fsData.DAY2231; ctlStdMenuItemDinner.Day23 = fsData.DAY2331; ctlStdMenuItemDinner.Day24 = fsData.DAY2431;
                ctlStdMenuItemDinner.Day25 = fsData.DAY2531; ctlStdMenuItemDinner.Day26 = fsData.DAY2631; ctlStdMenuItemDinner.Day27 = fsData.DAY2731;
                ctlStdMenuItemDinner.Day28 = fsData.DAY2831; ctlStdMenuItemDinner.Day29 = fsData.DAY2931; ctlStdMenuItemDinner.Day30 = fsData.DAY3031;
                ctlStdMenuItemDinner.Day31 = fsData.DAY3131;
                ctlStdMenuItemDinner.BindData();
                break;
        }

        this.tbPrint.Visible = (fsData.LOID != 0);

        if (!pageAuthorized)
        {
            ViewData(true);

            this.cmbFoodType.AutoPostBack = false;
            this.chkActive.Enabled = false;
            this.tbApprove.Visible = false;
            this.tbCancel.Visible = false;
            this.tbNotApprove.Visible = false;
            this.tbSave.Visible = false;
            this.tbConfirm.Visible = false;
        }
        else
        {
            if (fsData.STATUS == "CO" || fsData.STATUS == "AP")
            {
                ViewData(true);
                this.cmbFoodType.AutoPostBack = false;
            }
            else
                ViewData(false);
            this.cmbFoodType.Enabled = (fsData.LOID == 0);
            this.tbApprove.Visible = (fsData.STATUS == "CO");
            //this.tbCancel.Visible = (fsData.STATUS == "WA" || fsData.STATUS == "NA");
            this.tbNotApprove.Visible = (fsData.STATUS == "CO");
            //this.tbSave.Visible = (fsData.STATUS == "WA" || fsData.STATUS == "NA");
            this.tbConfirm.Visible = (fsData.STATUS == "WA" || fsData.STATUS == "NA");
            this.chkActive.Enabled = true;
        }
    }

    #endregion

    #region Working Method

    private bool doGetDetail(string LOID)
    {
        this.txtCurentTab.Text = tabStdMenu.ActiveTabIndex.ToString();
        StandardMenuFlow fFlow = new StandardMenuFlow();
        StdMenuDetailData fData = fFlow.GetDetails(Convert.ToDouble(LOID));

        bool ret = true;
        SetData(fData);
        return ret;
    }

    private bool doApprove()
    {
        StandardMenuFlow ftFlow = new StandardMenuFlow();
        bool ret = true;
        ret = ftFlow.ApproveData(Convert.ToDouble("0" + this.txtLOID.Text), Appz.CurrentUser);

        if (!ret)
            SetErrorStatus(ftFlow.ErrorMessage);
        else
        {
            doGetDetail(ftFlow.LOID.ToString());
            if (Convert.ToDouble("0" + this.txtLOID.Text) == 0)
                SetStatus(DataResources.MSGIN001);
            else
                SetStatus(DataResources.MSGIU001);
        }
        return ret;
    }

    private bool doNotApprove()
    {
        StandardMenuFlow ftFlow = new StandardMenuFlow();
        bool ret = true;
        ret = ftFlow.NotApproveData(Convert.ToDouble("0" + this.txtLOID.Text), Appz.CurrentUser);

        if (!ret)
            SetErrorStatus(ftFlow.ErrorMessage);
        else
        {
            doGetDetail(ftFlow.LOID.ToString());
            if (Convert.ToDouble("0" + this.txtLOID.Text) == 0)
                SetStatus(DataResources.MSGIN001);
            else
                SetStatus(DataResources.MSGIU001);
        }
        return ret;
    }

    private bool doUpdateActive()
    {
        StandardMenuFlow ftFlow = new StandardMenuFlow();
        bool ret = true;
        ret = ftFlow.UpdateActive(Convert.ToDouble("0" + this.txtLOID.Text), this.chkActive.Checked, Appz.CurrentUser);

        if (!ret)
            SetErrorStatus(ftFlow.ErrorMessage);
        else
        {
            doGetDetail(ftFlow.LOID.ToString());
            if (Convert.ToDouble("0" + this.txtLOID.Text) == 0)
                SetStatus(DataResources.MSGIN001);
            else
                SetStatus(DataResources.MSGIU001);
        }
        return ret;
    }

    private bool doSave()
    {
        // verify required field
        StdMenuDetailData StdMenuDetail = GetData();
        string error = VerifyData(StdMenuDetail);
        if (error != "")
        {
            SetErrorStatus(error);
            return false;
        }

        StandardMenuFlow ftFlow = new StandardMenuFlow();
        bool ret = true;

        // verify uniq field
        if (!ftFlow.CheckUniqueKey(StdMenuDetail.LOID, StdMenuDetail.NAME, StdMenuDetail.FOODTYPE, StdMenuDetail.FOODCATEGORY))
        {
            SetErrorStatus(string.Format(DataResources.MSGEI017, new string[] { "ชื่อสูตรอาหาร", StdMenuDetail.NAME, "ประเภทอาหาร", this.cmbFoodType.SelectedItem.Text, "ชนิดอาหาร", this.cmbFoodCategory.SelectedItem.Text }));
            return false;
        }

        // data correct go on saving...
        if (StdMenuDetail.LOID != 0)
            ret = ftFlow.UpdateData(StdMenuDetail, Appz.CurrentUser);
        else
            ret = ftFlow.InsertData(StdMenuDetail, Appz.CurrentUser);

        if (!ret)
            SetErrorStatus(ftFlow.ErrorMessage);
        else
        {
            doGetDetail(ftFlow.LOID.ToString());
            if (StdMenuDetail.LOID == 0)
                SetStatus(DataResources.MSGIN001);
            else
                SetStatus(DataResources.MSGIU001);
        }

        return ret;
    }

    private string VerifyData(StdMenuDetailData fData)
    {
        string ret = "";
        if (fData.NAME == "")
            ret = string.Format(DataResources.MSGEI001, "ชื่อชุดเมนู");
        else if (fData.FOODTYPE == 0)
            ret = string.Format(DataResources.MSGEI002, "ประเภทอาหาร");
        else if (fData.FOODCATEGORY == 0)
            ret = string.Format(DataResources.MSGEI002, "ชนิดอาหาร");

        return ret;
    }

    #endregion

}
