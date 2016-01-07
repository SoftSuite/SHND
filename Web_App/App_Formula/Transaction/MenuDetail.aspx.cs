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
/// Create by: Tan
/// Create Date: 20 Jan 2009
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

public partial class App_Formula_Transaction_MenuDetail : System.Web.UI.Page
{
    private static int chkRepeat = 0;
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            //txtCurentDate.Text = txtDateFrom.Text;
            doGetDetail((Request["loid"] == null ? "0" : Request["loid"]));
        }

        ctlMenuItemBreakfast.MenuID = Convert.ToDouble(Request["loid"] == null ? "0" : Request["loid"]);
        ctlMenuItemLunch.MenuID = Convert.ToDouble(Request["loid"] == null ? "0" : Request["loid"]);
        ctlMenuItemDinner.MenuID = Convert.ToDouble(Request["loid"] == null ? "0" : Request["loid"]);
        ctlOverAll.MenuLOID = Convert.ToDouble("0" + txtLOID.Text);

    }
    protected override void OnInit(EventArgs e)
    {
        base.OnInit(e);
        // set Combo source
        Appz.BuildCombo(cmbFoodType, "FOODTYPE", "NAME", "LOID", "ACTIVE='1' AND DIVISION = " + Appz.LoggedOnUser.DIVISION, "NAME", "เลือก", "0", false); //ตรงประเภทอาหารไม่ต้องแสดงอาหารทางสายให้อาหาร
        //Appz.BuildCombo(cmbFoodType, "FOODTYPE", "NAME", "LOID", "ACTIVE='1'", "NAME", "เลือก", "0", false); //ตรงประเภทอาหารไม่ต้องแสดงอาหารทางสายให้อาหาร
        Appz.BuildCombo(cmbFoodCategory, "FOODCATEGORY", "NAME", "LOID", "ACTIVE='1' AND LOID NOT IN (FN_GETCONFIGVALUE(31), FN_GETCONFIGVALUE(32))", "NAME", "เลือก", "0", false);  //ชนิดอาหารให้แสดงเฉพาะที่เป็นชนิดอาหารสำรับ
        // Appz.BuildCombo(cmbStandard, "STDMENU", "NAME", "LOID", "ACTIVE='1'" , "NAME", "เลือก", "0", false);


        this.txtCurentTab.Text = this.tabStdMenu.ActiveTabIndex.ToString();
        this.ctlMenuItemBreakfast.Meal = "11";
        this.ctlMenuItemDinner.Meal = "31";
        this.ctlMenuItemLunch.Meal = "21";
    }

    protected void tabStdMenu_ActiveTabChanged(object sender, EventArgs e)
    {
        if (this.txtStatus.Text != "AP" && this.txtStatus.Text != "NA")
        {
            if (!doSave())
                this.tabStdMenu.ActiveTabIndex = Convert.ToInt32(this.txtCurentTab.Text);
            //  else
            //      Appz.BuildCombo(cmbStandard, "STDMENU", "NAME", "LOID", "FOODTYPE = " + cmbFoodType.SelectedValue + " AND FOODCATEGORY = " + cmbFoodCategory.SelectedValue + " AND STATUS = 'AP' AND NVL(FN_GETMENUDISEASE(LOID,'STD'),'#')=NVL(FN_GETMENUDISEASE(" + Convert.ToDouble(txtLOID.Text) + ",'MENU'),'#')", "NAME", "เลือก", "0", false);

        }

    }

    protected void ctlOverAllLinkClick(object sender, EventArgs e)
    {
        switch (this.txtCurentMeal.Text)
        {
            case "11":
                this.txtCurentTab.Text = "3";
                ctlMenuItemBreakfast.Menu = Convert.ToDouble(txtLOID.Text);
                ctlMenuItemBreakfast.FoodType = Convert.ToDouble(cmbFoodType.SelectedValue);
                ctlMenuItemBreakfast.FoodCategory = Convert.ToDouble(cmbFoodCategory.SelectedValue);
                ctlMenuItemBreakfast.BindData(Convert.ToDateTime(txtDateFrom.Text), Convert.ToDateTime(txtDateTo.Text), Convert.ToDateTime(txtCurentDate.Text == "01/01/0544" ? txtDateFrom.Text : txtCurentDate.Text));
                break;
            case "21":
                this.txtCurentTab.Text = "4";
                ctlMenuItemLunch.Menu = Convert.ToDouble(txtLOID.Text);
                ctlMenuItemLunch.FoodType = Convert.ToDouble(cmbFoodType.SelectedValue);
                ctlMenuItemLunch.FoodCategory = Convert.ToDouble(cmbFoodCategory.SelectedValue);
                ctlMenuItemLunch.BindData(Convert.ToDateTime(txtDateFrom.Text), Convert.ToDateTime(txtDateTo.Text), Convert.ToDateTime(txtCurentDate.Text == "01/01/0544" ? txtDateFrom.Text : txtCurentDate.Text));
                break;
            case "31":
                this.txtCurentTab.Text = "5";
                ctlMenuItemDinner.Menu = Convert.ToDouble(txtLOID.Text);
                ctlMenuItemDinner.FoodType = Convert.ToDouble(cmbFoodType.SelectedValue);
                ctlMenuItemDinner.FoodCategory = Convert.ToDouble(cmbFoodCategory.SelectedValue);
                ctlMenuItemDinner.BindData(Convert.ToDateTime(txtDateFrom.Text), Convert.ToDateTime(txtDateTo.Text), Convert.ToDateTime(txtCurentDate.Text == "01/01/0544" ? txtDateFrom.Text : txtCurentDate.Text));
                break;

        }
        this.tabStdMenu.ActiveTabIndex = Convert.ToInt32(this.txtCurentTab.Text);
    }

    protected void ctlDiseaseCategoryPopup_SelectedIndexChanged(object sender, EventArgs e, ArrayList arrData)
    {
        MenuDetailItem fsItem = new MenuDetailItem();
        if (fsItem.InsertMenuDisease(Convert.ToDouble("0" + this.txtLOID.Text), arrData))
            BindStdMenuDisease();
    }
    #region Gridview Event Handler
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

    protected void gvStdMenu_RowDataBound(object sender, GridViewRowEventArgs e)
    {
        if (e.Row.RowType == DataControlRowType.DataRow)
        {
            DropDownList cmbStandard = (DropDownList)e.Row.Cells[1].FindControl("cmbStandard");
            RadioButtonList rbtPortion = (RadioButtonList)e.Row.Cells[1].FindControl("rbtPortion");
            Appz.BuildCombo(cmbStandard, "STDMENU", "NAME", "LOID", "ACTIVE='1' AND FOODCATEGORY=" + Convert.ToDouble(cmbFoodCategory.SelectedValue) + " AND FOODTYPE=" + Convert.ToDouble(cmbFoodType.SelectedValue) + " AND STATUS='AP' AND NVL(FN_GETMENUDISEASE(LOID,'STD'),'#')=NVL(FN_GETMENUDISEASE(" + Convert.ToDouble(txtLOID.Text) + ",'MENU'),'#') ", "NAME", "เลือก", "0", false);
            DataRow drow = (DataRow)((DataRowView)e.Row.DataItem).Row;
            cmbStandard.SelectedIndex = cmbStandard.Items.IndexOf(cmbStandard.Items.FindByValue(drow["STDMENU"].ToString()));
            cmbStandard.Enabled = drow["MENUSOURCE"].ToString() == "S";
            if (drow["PATIENTSOURCE"].ToString() != "0")
                rbtPortion.SelectedValue = drow["PATIENTSOURCE"].ToString();
        }
    }

    #endregion

    #region Button Click Event Handler

    #region Main Toolbar
    protected void tbSaveClick(object sender, EventArgs e)
    {
        doSave();
    }
    protected void tbCancelClick(object sender, EventArgs e)
    {
        doGetDetail("0" + this.txtLOID.Text);
    }
    protected void tbBackClick(object sender, EventArgs e)
    {
        Response.Redirect(Constant.HomeFolder + "App_Formula/Transaction/MenuSearch.aspx");
    }

    protected void tbApproveClick(object sender, EventArgs e)
    {
        doApprove();
    }

    #endregion

    #region StdMenuDisease Toolbar
    protected void tbAddStdMenuDiseaseClick(object sender, EventArgs e)
    {
        MenuDetailItem fsItem = new MenuDetailItem();
        this.ctlDiseaseCategoryPopup.Show("1", cmbFoodCategory.SelectedValue, fsItem.GetDiseaseCategoryList());
    }
    protected void tbDeleteStdMenuDiseaseClick(object sender, EventArgs e)
    {
        MenuDetailItem fsItem = new MenuDetailItem();
        if (fsItem.DeleteMenuDisease(GetCheckStdMenuDisease())) BindStdMenuDisease();
    }
    #endregion

    #region StdMenuSelect Toolbar
    protected void imbCal_Click(object sender, ImageClickEventArgs e)
    {
        bool ret = true;
        ArrayList arrData = new ArrayList();
        MenuFlow ftFlow = new MenuFlow();
        string error = VerifyMenuSelect();
        if (error != "")
        {
            SetErrorStatus(error);
        }
        else
        {
            ret = ftFlow.DeleteMenuDate(Convert.ToDouble(txtLOID.Text));
            if (ret)
            {
                DateTime StartDate = new DateTime();
                DateTime EndDate = new DateTime();
                int year = 0;
                int month = 0;
                foreach (GridViewRow row in gvStdMenu.Rows)
                {
                    year = int.Parse(row.Cells[5].Text);
                    month = int.Parse(row.Cells[4].Text);
                    TextBox txtAmount = (TextBox)row.Cells[3].FindControl("txtAmount");
                    RadioButton rbtStandard = (RadioButton)row.Cells[1].FindControl("rbtStandard");
                    RadioButton rbtDialy = (RadioButton)row.Cells[1].FindControl("rbtDialy");
                    DropDownList cmbStandard = (DropDownList)row.Cells[1].FindControl("cmbStandard");
                    DropDownList cmbMonth = (DropDownList)row.Cells[1].FindControl("cmbMonth");
                    TextBox txtYear = (TextBox)row.Cells[1].FindControl("txtYear");
                    RadioButtonList rbtPortion = (RadioButtonList)row.Cells[2].FindControl("rbtPortion");
                    MenuStandardData MenuStd = new MenuStandardData();
                    MenuStd.BMONTH = Convert.ToDouble(cmbMonth.SelectedValue);
                    MenuStd.BYEAR = Convert.ToDouble(txtYear.Text == "" ? "0" : txtYear.Text);
                    MenuStd.MENU = Convert.ToDouble(txtLOID.Text);
                    if (rbtStandard.Checked)
                        MenuStd.MENUSOURCE = "S";
                    else
                        MenuStd.MENUSOURCE = "B";

                    MenuStd.MMONTH = month;
                    MenuStd.MYEAR = year;
                    MenuStd.PATIENTQTY = Convert.ToDouble(txtAmount.Text);
                    MenuStd.PATIENTSOURCE = rbtPortion.SelectedValue;
                    MenuStd.STDMENU = Convert.ToDouble(cmbStandard.SelectedValue);
                    arrData.Add(MenuStd);

                    StartDate = new DateTime(year - 543, month, 1);
                    EndDate = new DateTime(year - 543, month, 1).AddMonths(1).AddDays(-1);
                    ftFlow = new MenuFlow();

                    if (rbtStandard.Checked)
                        ret = ftFlow.CopyStandard(Convert.ToDouble(txtAmount.Text), Convert.ToDouble(txtLOID.Text), Convert.ToDouble(cmbStandard.SelectedValue), StartDate, EndDate, Appz.CurrentUser);
                    else
                        ret = ftFlow.CopyDiary(Convert.ToDouble(txtAmount.Text), Convert.ToDouble(txtLOID.Text), int.Parse(cmbMonth.SelectedValue), int.Parse(txtYear.Text) - 543, StartDate, EndDate, Appz.CurrentUser);

                    if (!ret)
                    {
                        ret = false;
                        break;
                    }
                }
            }

            if (!ret)
                SetErrorStatus(ftFlow.ErrorMessage);
            else
            {
                ret = ftFlow.InsertMenuStandard(arrData, Convert.ToDouble(txtLOID.Text), Appz.CurrentUser, null);

                SetStatus("คัดลอกข้อมูลเรียบร้อยแล้ว");
            }

        }
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

    private void BindStdMenu()
    {
        this.gvStdMenu.DataBind();
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

    private MenuDetailData GetData()
    {
        MenuDetailData fsData = new MenuDetailData();
        fsData.DIVISION = Convert.ToDouble("0" + this.txtDivision.Text);
        fsData.FOODCATEGORY = Convert.ToDouble(this.cmbFoodCategory.SelectedItem.Value);
        fsData.FOODTYPE = Convert.ToDouble(this.cmbFoodType.SelectedItem.Value);
        fsData.BUDGETYEAR = Convert.ToDouble(this.txtBudgetYear.Text);
        fsData.PHASE = this.rblPhase.SelectedValue;
        if (this.txtBudgetYear.Text.Trim() != "" && this.txtBudgetYear.Text.Trim() != "0")
        {
            fsData.STARTDATE = Convert.ToDateTime(this.txtDateFrom.Text);
            fsData.ENDDATE = Convert.ToDateTime(this.txtDateTo.Text);
        }
        fsData.STATUS = this.txtStatus.Text.Trim();

        //if (this.chkIsSpecific.Checked)
        //    fsData.ISSPECIFIC = "Y";
        //else
        //    fsData.ISSPECIFIC = "N";

        fsData.LOID = Convert.ToDouble("0" + this.txtLOID.Text);
        fsData.NAME = this.txtName.Text.Trim();

        switch (this.txtCurentTab.Text)
        {
            case "0":
                MenuDetailItem item = new MenuDetailItem();
                fsData.MenuDisease = item.GetMenuDiseaseData();
                break;
            case "3":
                //fsData.DAY = ctlStdMenuItemBreakfast.Day;
                fsData.DATE = ctlMenuItemBreakfast.Day;
                fsData.PORTION = ctlMenuItemBreakfast.Portion;
                fsData.MEAL = ctlMenuItemBreakfast.Meal;
                fsData.MenuItem = ctlMenuItemBreakfast.SelectedData();
                break;
            case "4":
                //fsData.DAY = ctlStdMenuItemLunch.Day;
                fsData.DATE = ctlMenuItemLunch.Day;
                fsData.PORTION = ctlMenuItemLunch.Portion;
                fsData.MEAL = ctlMenuItemLunch.Meal;
                fsData.MenuItem = ctlMenuItemLunch.SelectedData();
                break;
            case "5":
                //fsData.DAY = ctlStdMenuItemDinner.Day;
                fsData.DATE = ctlMenuItemDinner.Day;
                fsData.PORTION = ctlMenuItemDinner.Portion;
                fsData.MEAL = ctlMenuItemDinner.Meal;
                fsData.MenuItem = ctlMenuItemDinner.SelectedData();
                break;

        }
        return fsData;
    }

    private void SetData(MenuDetailData fsData)
    {
        this.txtDivision.Text = fsData.DIVISION.ToString();
        this.txtDivisionName.Text = fsData.DIVISIONNAME;
        this.cmbFoodCategory.SelectedIndex = this.cmbFoodCategory.Items.IndexOf(this.cmbFoodCategory.Items.FindByValue(fsData.FOODCATEGORY.ToString()));
        this.cmbFoodType.SelectedIndex = this.cmbFoodType.Items.IndexOf(this.cmbFoodType.Items.FindByValue(fsData.FOODTYPE.ToString()));
        this.txtBudgetYear.Text = fsData.BUDGETYEAR.ToString();
        this.txtDateFrom.Text = fsData.STARTDATE.ToString("dd/MM/yyyy");
        this.txtDateTo.Text = fsData.ENDDATE.ToString("dd/MM/yyyy");
        this.rblPhase.SelectedValue = fsData.PHASE;
        this.txtStatus.Text = fsData.STATUS;
        this.txtStatusName.Text = fsData.STATUSNAME;
        this.txtItem.Text = fsData.ITEM.ToString();
        this.txtYearOld.Text = fsData.BUDGETYEAR.ToString();
        this.txtPhaseOld.Text = fsData.PHASE;
        // this.txtStatusName.Text = fsData.s;

        //if (fsData.ISSPECIFIC == "Y")
        //    this.chkIsSpecific.Checked = true;
        //else
        //    this.chkIsSpecific.Checked = false;

        this.txtLOID.Text = fsData.LOID.ToString();
        this.txtName.Text = fsData.NAME;

        if (fsData.LOID == 0)
        {
            this.txtStatus.Text = "WA";
            this.txtStatusName.Text = "กำลังดำเนินการ";
            this.txtDivision.Text = Appz.LoggedOnUser.DIVISION.ToString();
            this.txtDivisionName.Text = Appz.LoggedOnUser.DIVISIONNAME;
            this.txtDateFrom.Text = "";
            this.txtDateTo.Text = "";
        }

        this.tbPrint.ClientClick = Appz.OpenReportScript(Constant.Reports.MenuReport_1, fsData.LOID, true);

        switch (this.txtCurentTab.Text)
        {
            case "0":
                MenuDetailItem item = new MenuDetailItem();
                item.ClearMenuDisease();
                BindStdMenuDisease();
                break;
            case "1":
                BindStdMenu();
                break;
            case "3":
                ctlMenuItemBreakfast.Menu = fsData.LOID;
                ctlMenuItemBreakfast.FoodType = fsData.FOODTYPE;
                ctlMenuItemBreakfast.FoodCategory = fsData.FOODCATEGORY;
                ctlMenuItemBreakfast.BindData(Convert.ToDateTime(txtDateFrom.Text), Convert.ToDateTime(txtDateTo.Text), Convert.ToDateTime(txtCurentDate.Text == "01/01/0544" ? txtDateFrom.Text : txtCurentDate.Text));
                break;
            case "4":
                ctlMenuItemLunch.Menu = fsData.LOID;
                ctlMenuItemLunch.FoodType = fsData.FOODTYPE;
                ctlMenuItemLunch.FoodCategory = fsData.FOODCATEGORY;
                ctlMenuItemLunch.BindData(Convert.ToDateTime(txtDateFrom.Text), Convert.ToDateTime(txtDateTo.Text), Convert.ToDateTime(txtCurentDate.Text == "01/01/0544" ? txtDateFrom.Text : txtCurentDate.Text));
                break;
            case "5":
                ctlMenuItemDinner.Menu = fsData.LOID;
                ctlMenuItemDinner.FoodType = fsData.FOODTYPE;
                ctlMenuItemDinner.FoodCategory = fsData.FOODCATEGORY;
                ctlMenuItemDinner.BindData(Convert.ToDateTime(txtDateFrom.Text), Convert.ToDateTime(txtDateTo.Text), Convert.ToDateTime(txtCurentDate.Text == "01/01/0544" ? txtDateFrom.Text : txtCurentDate.Text));
                break;
        }

        this.tbApprove.Visible = (fsData.STATUS == "WA" || fsData.STATUS == "");
        this.tbCancel.Visible = (fsData.STATUS == "WA" || fsData.STATUS == "");
        this.tbPrint.Visible = (fsData.LOID != 0);
        this.tbSave.Visible = (fsData.STATUS == "WA" || fsData.STATUS == "");

        if (txtStatus.Text != "WA")
        {
            this.txtName.ReadOnly = true;
            this.txtName.CssClass = "zTextbox-View";
            this.cmbFoodCategory.Enabled = false;
            this.cmbFoodType.Enabled = false;
            this.txtBudgetYear.ReadOnly = true;
            this.txtBudgetYear.CssClass = "zTextbox-View";
            this.rblPhase.Enabled = false;


            tbAddStdMenuDisease.Visible = false;
            tbDeleteStdMenuDisease.Visible = false;
            this.gvStdMenuDisease.Columns[1].Visible = false;

            this.ctlMenuItemBreakfast.Readonly = true;
            this.ctlMenuItemDinner.Readonly = true;
            this.ctlMenuItemLunch.Readonly = true;

            ctlMenuItemBreakfast.Menu = fsData.LOID;
            ctlMenuItemBreakfast.BindData(Convert.ToDateTime(txtDateFrom.Text), Convert.ToDateTime(txtDateTo.Text), Convert.ToDateTime(txtCurentDate.Text == "" ? txtDateFrom.Text : txtCurentDate.Text));
            ctlMenuItemLunch.Menu = fsData.LOID;
            ctlMenuItemLunch.BindData(Convert.ToDateTime(txtDateFrom.Text), Convert.ToDateTime(txtDateTo.Text), Convert.ToDateTime(txtCurentDate.Text == "" ? txtDateFrom.Text : txtCurentDate.Text));
            ctlMenuItemDinner.Menu = fsData.LOID;
            ctlMenuItemDinner.BindData(Convert.ToDateTime(txtDateFrom.Text), Convert.ToDateTime(txtDateTo.Text), Convert.ToDateTime(txtCurentDate.Text == "" ? txtDateFrom.Text : txtCurentDate.Text));

        }

    }

    #endregion

    #region Working Method

    private bool doGetDetail(string LOID)
    {
        MenuFlow fFlow = new MenuFlow();
        MenuDetailData fData = fFlow.GetDetails(Convert.ToDouble(LOID));

        bool ret = true;
        SetData(fData);
        return ret;
    }

    private bool doApprove()
    {
        MenuFlow ftFlow = new MenuFlow();
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

    private bool doSave()
    {
        // verify required field
        MenuDetailData MenuDetail = GetData();
        string error = VerifyData(MenuDetail);
        if (error != "")
        {
            SetErrorStatus(error);
            return false;
        }

        MenuFlow ftFlow = new MenuFlow();
        bool ret = true;

        // verify uniq field
        if (!ftFlow.CheckUniqueKey(MenuDetail.LOID, MenuDetail.NAME, MenuDetail.FOODTYPE, MenuDetail.FOODCATEGORY, MenuDetail.BUDGETYEAR, MenuDetail.PHASE))
        {
            //SetErrorStatus(string.Format(DataResources.MSGEI016, "ชื่อสูตรอาหาร", MenuDetail.NAME, "ประเภทอาหาร \"" + this.cmbFoodType.SelectedItem.Text + "\", ชนิดอาหาร \"" + this.cmbFoodCategory.SelectedItem.Text + "\""));
            SetErrorStatus(string.Format(DataResources.MSGEI017, new string[] { "ชื่อสูตรอาหาร", MenuDetail.NAME, "ประเภทอาหาร", this.cmbFoodType.SelectedItem.Text, "ชนิดอาหาร", this.cmbFoodCategory.SelectedItem.Text }));
            return false;
        }

        // data correct go on saving...
        if (MenuDetail.LOID != 0)
            ret = ftFlow.UpdateData(MenuDetail, this.txtCurentTab.Text, Appz.CurrentUser);
        else
            ret = ftFlow.InsertData(MenuDetail, Appz.CurrentUser);

        if (!ret)
            SetErrorStatus(ftFlow.ErrorMessage);
        else
        {
            this.txtCurentTab.Text = this.tabStdMenu.ActiveTabIndex.ToString();
            switch (this.txtCurentTab.Text)
            {
                case "3":
                    this.txtCurentDate.Text = ctlMenuItemBreakfast.Day.ToString("dd/MM/yyyy");
                    break;
                case "4":
                    this.txtCurentDate.Text = ctlMenuItemLunch.Day.ToString("dd/MM/yyyy");
                    break;
                case "5":
                    this.txtCurentDate.Text = ctlMenuItemDinner.Day.ToString("dd/MM/yyyy");
                    break;
            }

            doGetDetail(ftFlow.LOID.ToString());
            if (MenuDetail.LOID != 0)
                SetStatus(DataResources.MSGIU001);
            else
                SetStatus(DataResources.MSGIN001);
        }

        return ret;
    }

    private string VerifyData(MenuDetailData fData)
    {
        string ret = "";
        if (fData.NAME == "")
            ret = string.Format(DataResources.MSGEI001, "ชื่อเมนู");
        else if (fData.FOODTYPE == 0)
            ret = string.Format(DataResources.MSGEI002, "ประเภทอาหาร");
        else if (fData.FOODCATEGORY == 0)
            ret = string.Format(DataResources.MSGEI002, "ชนิดอาหาร");
        else if (txtBudgetYear.Text == "")
            ret = string.Format(DataResources.MSGEI001, "ปี");

        else if (fData.MEAL != "")
        {
            if (fData.DATE < fData.STARTDATE || fData.DATE > fData.ENDDATE)
                ret = "วันที่ไม่อยู่ในงวดที่ระบุ";
            else if (fData.PORTION == 0)
                ret = "ระบุจำนวนผู้ป่วย";
        }


        return ret;
    }

    private string VerifyMenuSelect()
    {
        string ret = "";
        foreach (GridViewRow row in gvStdMenu.Rows)
        {
            TextBox txtAmount = (TextBox)row.Cells[3].FindControl("txtAmount");
            RadioButton rbtStandard = (RadioButton)row.Cells[1].FindControl("rbtStandard");
            RadioButton rbtDialy = (RadioButton)row.Cells[1].FindControl("rbtDialy");
            DropDownList cmbStandard = (DropDownList)row.Cells[1].FindControl("cmbStandard");
            DropDownList cmbMonth = (DropDownList)row.Cells[1].FindControl("cmbMonth");
            TextBox txtYear = (TextBox)row.Cells[1].FindControl("txtYear");
            RadioButtonList rbtPortion = (RadioButtonList)row.Cells[2].FindControl("rbtPortion");


            if (!rbtStandard.Checked & !rbtDialy.Checked)
            {
                ret = string.Format(DataResources.MSGEI002, "เมนูจาก");
                break;
            }
            else if (rbtStandard.Checked & cmbStandard.SelectedValue == "0")
            {
                ret = string.Format(DataResources.MSGEI002, "เมนูมาตรฐาน");
                break;
            }
            else if (rbtDialy.Checked & (txtYear.Text == "" || cmbMonth.SelectedValue == "0"))
            {
                ret = string.Format(DataResources.MSGEI001, "เมนูประจำวันในเดือน-ปี");
                break;
            }
            else if (rbtPortion.SelectedValue == "0")
            {
                ret = string.Format(DataResources.MSGEI002, "จำนวนผู้ป่วย");
                break;
            }
            else if (txtAmount.Text == "" || txtAmount.Text == "0")
            {
                ret = string.Format(DataResources.MSGEI001, "จำนวนผู้ป่วย");
                break;
            }
        }

        return ret;
    }

    #endregion
    protected void txtBudgetYear_TextChanged(object sender, EventArgs e)
    {
        MenuDetailData fData = new MenuDetailData();
        MenuFlow fFlow = new MenuFlow();

        if (txtItem.Text == "" || txtItem.Text == "0")
        {
            if (txtBudgetYear.Text != "" || txtBudgetYear.Text != "0")
            {
                int year = int.Parse(txtBudgetYear.Text) - 1;
                if (rblPhase.SelectedValue == "1")
                {
                    txtDateFrom.Text = "1/10/" + year.ToString();
                    txtDateTo.Text = "31/3/" + txtBudgetYear.Text;
                }
                else
                {
                    txtDateFrom.Text = "1/4/" + txtBudgetYear.Text;
                    txtDateTo.Text = "30/9/" + txtBudgetYear.Text;
                }
            }
        }
        else
        {
            txtBudgetYear.Text = txtYearOld.Text;
            SetErrorStatus("มีข้อมูลอยู่");
        }
    }
    protected void rblPhase_SelectedIndexChanged(object sender, EventArgs e)
    {
        MenuDetailData fData = new MenuDetailData();
        MenuFlow fFlow = new MenuFlow();

        if (txtItem.Text == "" || txtItem.Text == "0")
        {
            if (txtBudgetYear.Text != "" || txtBudgetYear.Text != "0")
            {
                int year = int.Parse(txtBudgetYear.Text) - 1;
                if (rblPhase.SelectedValue == "1")
                {
                    txtDateFrom.Text = "1/10/" + year.ToString();
                    txtDateTo.Text = "31/3/" + txtBudgetYear.Text;
                }
                else
                {
                    txtDateFrom.Text = "1/4/" + txtBudgetYear.Text;
                    txtDateTo.Text = "30/9/" + txtBudgetYear.Text;
                }
            }
        }
        else
        {
            rblPhase.SelectedValue = txtPhaseOld.Text;
            SetErrorStatus("มีข้อมูลอยู่");
        }
    }
    protected void rbtStandard_CheckedChanged(object sender, EventArgs e)
    {
        RadioButton rbt = (RadioButton)sender;
        Int16 rowIndex = (Int16)((GridViewRow)rbt.Parent.Parent).RowIndex;
        //this.gvStdMenu.Rows[rowIndex].Cells[1].Text = (rowIndex + 1).ToString();
        DropDownList cmbStandard = (DropDownList)this.gvStdMenu.Rows[rowIndex].Cells[1].FindControl("cmbStandard");
        DropDownList cmbMonth = (DropDownList)this.gvStdMenu.Rows[rowIndex].Cells[1].FindControl("cmbMonth");
        TextBox txtYear = (TextBox)this.gvStdMenu.Rows[rowIndex].Cells[1].FindControl("txtYear");

        if (rbt.Checked)
        {
            cmbMonth.SelectedValue = "0";
            txtYear.Text = "";
            cmbStandard.Enabled = true;
            cmbMonth.Enabled = false;
            txtYear.ReadOnly = true;
            txtYear.CssClass = "zTextboxR-View";
        }
        else
        {
            cmbStandard.SelectedValue = "0";
            cmbStandard.Enabled = false;
            cmbMonth.Enabled = true;
            txtYear.ReadOnly = false;
            txtYear.CssClass = "zTextboxR";
        }
    }
    protected void rbtDialy_CheckedChanged(object sender, EventArgs e)
    {
        RadioButton rbt = (RadioButton)sender;
        Int16 rowIndex = (Int16)((GridViewRow)rbt.Parent.Parent).RowIndex;
        //this.gvStdMenu.Rows[rowIndex].Cells[1].Text = (rowIndex + 1).ToString();
        DropDownList cmbStandard = (DropDownList)this.gvStdMenu.Rows[rowIndex].Cells[1].FindControl("cmbStandard");
        DropDownList cmbMonth = (DropDownList)this.gvStdMenu.Rows[rowIndex].Cells[1].FindControl("cmbMonth");
        TextBox txtYear = (TextBox)this.gvStdMenu.Rows[rowIndex].Cells[1].FindControl("txtYear");

        if (rbt.Checked)
        {
            cmbStandard.SelectedValue = "0";
            cmbStandard.Enabled = false;
            cmbMonth.Enabled = true;
            txtYear.ReadOnly = false;
            txtYear.CssClass = "zTextboxR";
        }
        else
        {
            cmbMonth.SelectedValue = "0";
            txtYear.Text = "";
            cmbStandard.Enabled = true;
            cmbMonth.Enabled = false;
            txtYear.ReadOnly = true;
            txtYear.CssClass = "zTextboxR-View";
        }
    }

    protected void rbtPortion_SelectedIndexChanged(object sender, EventArgs e)
    {
        string start = "";
        string end = "";
        DateTime Date = new DateTime();
        RadioButtonList rbt = (RadioButtonList)sender;
        Int16 rowIndex = (Int16)((GridViewRow)rbt.Parent.Parent).RowIndex;
        TextBox txtAmount = (TextBox)this.gvStdMenu.Rows[rowIndex].Cells[3].FindControl("txtAmount");
        if (rbt.SelectedValue == "1")
        {
            Date = DateTime.Today.AddMonths(-6);
            start = Date.Year.ToString() + Date.Month.ToString("00");
            Date = DateTime.Today.AddMonths(-1);
            end = Date.Year.ToString() + Date.Month.ToString("00");
        }
        else if (rbt.SelectedValue == "2")
        {
            Date = DateTime.Today.AddMonths(-1);
            start = Date.Year.ToString() + Date.Month.ToString("00");
            Date = DateTime.Today.AddMonths(-1);
            end = Date.Year.ToString() + Date.Month.ToString("00");
        }
        else
        {
            Date = DateTime.Today.AddYears(-1);
            start = Date.Year.ToString() + Date.Month.ToString("00");
            Date = DateTime.Today.AddYears(-1);
            end = Date.Year.ToString() + Date.Month.ToString("00");
        }
        MenuFlow menu = new MenuFlow();
        double portion = 0;
        portion = menu.GetPortion(Convert.ToDouble(txtLOID.Text), start, end);
        txtAmount.Text = portion.ToString();
    }
}
