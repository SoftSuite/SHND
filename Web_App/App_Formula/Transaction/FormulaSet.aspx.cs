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
/// Formula Set Detail Page Class
/// Version 1.0
/// =========================================================================
/// Create by: Teang
/// Create Date: 5 Jan 2009
/// -------------------------------------------------------------------------
/// Modify By: Nang
/// Modify From: -
/// Modify Date: 13 July 2009
/// -------------------------------------------------------------------------
/// Remark: -
/// Description:
///    หน้ากาารทำงานข้อมูล Frmula set Detail
/// Changes:
///    1.0 - สร้าง
/// -------------------------------------------------------------------------
/// =========================================================================
/// </summary>
/// 
public partial class App_Formula_Transaction_FormulaSet : System.Web.UI.Page
{
    private double totalEnergy = 0;
    private double totalWeightRipe = 0;
    private double totalServeWeightRipe = 0;

    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            CheckDivision(Convert.ToDouble((Request["loid"] == null ? "0" : Request["loid"])));
            doGetDetail((Request["loid"] == null ? "0" : Request["loid"]));
        }
        else
        {
            if (this.txtCurentTab.Text == "1")
            {
                this.ctlAttach.UniqID = this.txtLOID.Text;
            }
        }
    }

    protected override void OnInit(EventArgs e)
    {
        base.OnInit(e);
        // set Combo source
        Appz.BuildCombo(cmbFoodType, "FOODTYPE", "NAME", "LOID", "ACTIVE='1' AND LOID<>3 AND DIVISION = " + Appz.LoggedOnUser.DIVISION.ToString(), "NAME", "เลือก", "0", false); //ตรงประเภทอาหารไม่ต้องแสดงอาหารทางสายให้อาหาร
        Appz.BuildCombo(cmbFoodCategory, "FOODCATEGORY", "NAME", "LOID", "ACTIVE='1' AND LOID NOT IN (FN_GETCONFIGVALUE(31), FN_GETCONFIGVALUE(32))", "NAME", "เลือก", "0", false);  //ชนิดอาหารให้แสดงเฉพาะที่เป็นชนิดอาหารสำรับ
        Appz.BuildCombo(cmbFoodCookType, "FOODCOOKTYPE", "NAME", "LOID", "ACTIVE='1'", "NAME", "เลือก", "0", false);
        Appz.BuildCombo(cmbDishesType, "DISHESTYPE", "NAME", "LOID", "ACTIVE='1'", "NAME", "เลือก", "0", false);
        Appz.BuildCombo(cmbPackage, "V_MATERIALMASTER", "NAME", "LOID", "ACTIVE='1' AND MASTERTYPE = 'TL'", "NAME", "เลือก", "0", false);

        ControlUtil.SetIntTextBox(txtPortion);
        ControlUtil.SetDblTextBox(txtWeightFormula);
        ControlUtil.SetDblTextBox(txtWeightPortion);
        ControlUtil.SetDblTextBox(txtWeightRaw);
        ControlUtil.SetDblTextBox(txtWeightRipe);
        this.txtCurentTab.Text = this.tabFormulaSet.ActiveTabIndex.ToString();
        this.tbAddRefFormulaSet.ClientClick = "if (document.getElementById('" + this.cmbFoodType.ClientID + "').value == '0') { alert('" + string.Format(DataResources.MSGEI002, "ประเภทอาหาร") + "'); return false; } " +
            "else if (document.getElementById('" + this.cmbFoodCategory.ClientID + "').value == '0') { alert('" + string.Format(DataResources.MSGEI002, "ชนิดอาหาร") + "'); return false; } ";
    }

    protected void tabFormulaSet_ActiveTabChanged(object sender, EventArgs e)
    {
        if (this.txtStatus.Text != "AP" && this.txtStatus.Text != "NA" && this.tbSave.Visible)
        {
            if (!doSave())
                this.tabFormulaSet.ActiveTabIndex = Convert.ToInt32(this.txtCurentTab.Text);
        }
        else
        {
            doGetDetail("0" + this.txtLOID.Text);
        }
    }

    protected void ctlMaterialMasterPopup_SelectedIndexChanged(object sender, EventArgs e, ArrayList arrData)
    {
        FormulaSetDetailItem fsItem = new FormulaSetDetailItem();
        if (fsItem.InsertFormulaSetItem(Convert.ToDouble("0" + this.txtLOID.Text), arrData))
            BindFormulaSetItem();
    }

    protected void vtlFormulaSetPopup_SelectedIndexChanged(object sender, EventArgs e, ArrayList arrData)
    {
        FormulaSetDetailItem fsItem = new FormulaSetDetailItem();
        if (fsItem.InsertRefFormulaSet(Convert.ToDouble("0" + this.txtLOID.Text), Convert.ToDouble("0" + this.txtPortion.Text), arrData))
            BindRefFormulaSet();
    }

    protected void ctlDiseaseCategoryPopup_SelectedIndexChanged(object sender, EventArgs e, ArrayList arrData)
    {
        FormulaSetDetailItem fsItem = new FormulaSetDetailItem();
        fsItem.UpdateDiseaseCategory(GetFormulasetDiseaseData());
        if (fsItem.InsertFormulaDisease(Convert.ToDouble("0" + this.txtLOID.Text), arrData))
            BindFormulaDisease();
    }

    #region Button Click Event Handler

    #region Main Toolbar
    protected void tbSaveClick(object sender, EventArgs e)
    {
        if (this.txtStatus.Text == "AP")
            doSaveActive();
        else
            doSave();
    }
    protected void tbCancelClick(object sender, EventArgs e)
    {
        doGetDetail("0" + this.txtLOID.Text);
    }
    protected void tbBackClick(object sender, EventArgs e)
    {
        Response.Redirect(Constant.HomeFolder + "App_Formula/Transaction/FormulaSetSearch.aspx");
    }
    protected void tbTestClick(object sender, EventArgs e)
    {
        string old = this.txtStatus.Text;
        this.txtStatus.Text = "TE";
        if (!doSave())
            this.txtStatus.Text = old;
    }
    protected void tbApproveClick(object sender, EventArgs e)
    {
        string old = this.txtStatus.Text;
        this.txtStatus.Text = "AP";
        if (!doSave())
            this.txtStatus.Text = old;
    }
    protected void tbNotApproveClick(object sender, EventArgs e)
    {
        string old = this.txtStatus.Text;
        this.txtStatus.Text = "NA";
        if (!doSave())
            this.txtStatus.Text = old;
    }
    #endregion

    #region FormulaSetItem Toolbar
    protected void tbAddFormulaSetItemClick(object sender, EventArgs e)
    {
        UpdateFormulaSetItem();
        FormulaSetDetailItem fsItem = new FormulaSetDetailItem();
        this.ctlMaterialMasterPopup.Show("1", fsItem.getMaterialList());
    }
    protected void tbDeleteFormulaSetItemClick(object sender, EventArgs e)
    {
        UpdateFormulaSetItem();
        FormulaSetDetailItem fsItem = new FormulaSetDetailItem();
        if (fsItem.DeleteFormulaSetItem(GetCheckedFormulaSetItem())) BindFormulaSetItem();
    }
    #endregion

    #region RefFormulaSet Toolbar
    protected void tbAddRefFormulaSetClick(object sender, EventArgs e)
    {
        FormulaSetDetailItem fsItem = new FormulaSetDetailItem();
        if (Convert.ToDouble("0" + this.txtLOID.Text) > 0)
            this.ctlFormulaSetPopup.Show(Convert.ToDouble("0" + this.txtLOID.Text), Convert.ToDouble(this.cmbFoodType.SelectedItem.Value), Convert.ToDouble(this.cmbFoodCategory.SelectedItem.Value), fsItem.GetRefFormulaList());
        else if (this.gvRefFormula.Rows.Count > 0)
            this.ctlFormulaSetPopup.Show(Convert.ToDouble(this.gvRefFormula.Rows[0].Cells[3].Text), Convert.ToDouble(this.cmbFoodType.SelectedItem.Value), Convert.ToDouble(this.cmbFoodCategory.SelectedItem.Value), fsItem.GetRefFormulaList());
        else
            this.ctlFormulaSetPopup.Show(0, Convert.ToDouble(this.cmbFoodType.SelectedItem.Value), Convert.ToDouble(this.cmbFoodCategory.SelectedItem.Value), fsItem.GetRefFormulaList());
    }
    protected void tbDeleteRefFormulaSetClick(object sender, EventArgs e)
    {
        FormulaSetDetailItem fsItem = new FormulaSetDetailItem();
        if (fsItem.DeleteRefFormulaSet(GetCheckedRefFormula())) BindRefFormulaSet();
    }
    #endregion

    #region FormulaServe Toolbar

    #region Main Toolbar
    protected void lnkName_Click(object sender, EventArgs e)
    {
        DoGetFormulaServeDetail(Convert.ToInt32(((LinkButton)sender).CommandArgument));
        popupFormulaServe.Show();
        this.ctlAttach.UniqID = this.txtLOID.Text;
        this.ctlAttach.ReadOnly = (this.txtStatus.Text == "AP" || this.txtStatus.Text == "NA");
    }
    protected void tbAddFormulaServeClick(object sender, EventArgs e)
    {
        popupFormulaServe.Show();
    }
    protected void tbDeleteFormulaServeClick(object sender, EventArgs e)
    {
        FormulaSetDetailItem fsItem = new FormulaSetDetailItem();
        if (fsItem.DeleteFormulaServe(GetCheckedFormulaServe())) BindFormulaServe();
    }
    #endregion

    #region Popup Toolbar
    protected void tbAddFormulaServeDetailClick(object sender, EventArgs e)
    {
        if (!DoSaveFormulaServe())
            popupFormulaServe.Show();
        else
            ClearFormulaServeData();
    }
    protected void tbAddAndNewFormulaServeClick(object sender, EventArgs e)
    {
        if (DoSaveFormulaServe())
            ClearFormulaServeData();
        popupFormulaServe.Show();
    }
    protected void tbCancelFormulaServeClick(object sender, EventArgs e)
    {
        if (txhID.Text.Trim() == "")
            ClearFormulaServeData();
        else
            DoGetFormulaServeDetail(Convert.ToInt32("0" + txhID.Text));

        popupFormulaServe.Show();
    }
    protected void tbBackFormulaServeClick(object sender, EventArgs e)
    {
        ClearFormulaServeData();
    }
    #endregion

    #endregion

    #region FormulaDisease Toolbar
    protected void tbAddFormulaDiseaseClick(object sender, EventArgs e)
    {
        FormulaSetDetailItem fsItem = new FormulaSetDetailItem();
        this.ctlDiseaseCategoryPopup.Show("1", cmbFoodCategory.SelectedValue, fsItem.GetDiseaseCategoryList());
    }
    protected void tbDeleteFormulaDiseaseClick(object sender, EventArgs e)
    {
        FormulaSetDetailItem fsItem = new FormulaSetDetailItem();
        fsItem.UpdateDiseaseCategory(GetFormulasetDiseaseData());
        if (fsItem.DeleteFormulaDisease(GetCheckedFormulaDisease())) BindFormulaDisease();
    }
    #endregion

    #endregion

    #region Gridview Event Handler

    protected void gvFormulaSetItem_RowDataBound(object sender, GridViewRowEventArgs e)
    {
        if (e.Row.RowType == DataControlRowType.DataRow)
        {
            if(txtDivision.Text.Trim() == Appz.LoggedOnUser.DIVISION.ToString())
            {
                if (this.txtStatus.Text == "AP")
                {
                    ((TextBox)e.Row.Cells[6].FindControl("txtPrepareNameEdit")).CssClass = "zTextbox-View";
                    ((TextBox)e.Row.Cells[6].FindControl("txtPrepareNameEdit")).ReadOnly = true;
                    ((TextBox)e.Row.Cells[7].FindControl("txtWeightRawEdit")).CssClass = "zTextboxR-View";
                    ((TextBox)e.Row.Cells[7].FindControl("txtWeightRawEdit")).ReadOnly = true;
                }  
            }
            else
            {
                ((TextBox)e.Row.Cells[6].FindControl("txtPrepareNameEdit")).CssClass = "zTextbox-View";
                ((TextBox)e.Row.Cells[6].FindControl("txtPrepareNameEdit")).ReadOnly = true;
                ((TextBox)e.Row.Cells[7].FindControl("txtWeightRawEdit")).CssClass = "zTextboxR-View";
                ((TextBox)e.Row.Cells[7].FindControl("txtWeightRawEdit")).ReadOnly = true;
            }
        }
    }

    protected void gvRefFormula_RowDataBound(object sender, GridViewRowEventArgs e)
    {
        if (e.Row.RowType == DataControlRowType.DataRow)
        {
            FormulaSetDetailItem fsItem = new FormulaSetDetailItem();
            ((GridView)e.Row.Cells[2].FindControl("gvRefFormulaSetItem")).DataSource = fsItem.GetRefFormulaSetItemList(Convert.ToDouble("0" + this.txtLOID.Text), Convert.ToDouble("0" + ((TextBox)e.Row.Cells[2].FindControl("txtRefFormula")).Text));
            ((GridView)e.Row.Cells[2].FindControl("gvRefFormulaSetItem")).DataBind();
        }
    }

    protected void gvFormulaDisease_RowDataBound(object sender, GridViewRowEventArgs e)
    {
        if (e.Row.RowType == DataControlRowType.DataRow)
        {
            if (this.txtStatus.Text == "AP")
            {
                ((RadioButton)e.Row.Cells[4].FindControl("chkHigh")).Enabled = false;
                ((RadioButton)e.Row.Cells[5].FindControl("chkLow")).Enabled = false;
                ((RadioButton)e.Row.Cells[6].FindControl("chkNon")).Enabled = false;
            }
        }
    }

    #endregion

    #region Misc. Methods

    private ArrayList GetCheckedFormulaSetItem()
    {
        ArrayList arrChk = new ArrayList();
        for (int i = 0; i < gvFormulaSetItem.Rows.Count; i++)
        {
            if (i > -1 && gvFormulaSetItem.Rows[i].Cells[2].FindControl("chkSelect") != null)
            {
                GridViewRow gRow = gvFormulaSetItem.Rows[i];
                if (((CheckBox)gRow.Cells[2].FindControl("chkSelect")).Checked)
                {
                    arrChk.Add(Convert.ToDouble(gRow.Cells[0].Text));
                }
            }
        }
        return arrChk;
    }

    private ArrayList GetCheckedRefFormula()
    {
        ArrayList arrChk = new ArrayList();
        for (int i = 0; i < gvRefFormula.Rows.Count; i++)
        {
            if (i > -1 && gvRefFormula.Rows[i].Cells[1].FindControl("chkSelect") != null)
            {
                GridViewRow gRow = gvRefFormula.Rows[i];
                if (((CheckBox)gRow.Cells[1].FindControl("chkSelect")).Checked)
                {
                    arrChk.Add(Convert.ToDouble(gRow.Cells[0].Text));
                }
            }
        }
        return arrChk;
    }

    private ArrayList GetCheckedFormulaServe()
    {
        ArrayList arrChk = new ArrayList();
        for (int i = 0; i < gvFormulaServe.Rows.Count; i++)
        {
            if (i > -1 && gvFormulaServe.Rows[i].Cells[1].FindControl("chkSelect") != null)
            {
                GridViewRow gRow = gvFormulaServe.Rows[i];
                if (((CheckBox)gRow.Cells[1].FindControl("chkSelect")).Checked)
                {
                    arrChk.Add(Convert.ToDouble(gRow.Cells[0].Text));
                }
            }
        }
        return arrChk;
    }

    private ArrayList GetCheckedFormulaDisease()
    {
        ArrayList arrChk = new ArrayList();
        for (int i = 0; i < gvFormulaDisease.Rows.Count; i++)
        {
            if (i > -1 && gvFormulaDisease.Rows[i].Cells[1].FindControl("chkSelect") != null)
            {
                GridViewRow gRow = gvFormulaDisease.Rows[i];
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

    private void BindFormulaSetItem()
    {
        this.gvFormulaSetItem.DataBind();
    }

    private void BindRefFormulaSet()
    {
        this.gvRefFormula.DataBind();
    }

    private void BindFormulaServe()
    {
        this.gvFormulaServe.DataBind();
    }

    private void BindFormulaDisease()
    {
        this.gvFormulaDisease.DataBind();
    }

    private void SetErrorStatusFormulaSetItem(string t)
    {
        lbStatusFormulaSetItem.Text = t;
        lbStatusFormulaSetItem.ForeColor = Constant.StatusColor.Error;
    }

    private void SetErrorStatusRefFormulaSet(string t)
    {
        lbStatusRefFormulaSet.Text = t;
        lbStatusRefFormulaSet.ForeColor = Constant.StatusColor.Error;
    }

    #region FormulaServeStatus
    private void SetErrorStatusFormualServeMain(string t)
    {
        lbStatusFormulaServe.Text = t;
        lbStatusFormulaServe.ForeColor = Constant.StatusColor.Error;
    }
    private void SetErrorStatusFormualServeDetail(string t)
    {
        lbStatusFormulaServeDetail.Text = t;
        lbStatusFormulaServeDetail.ForeColor = Constant.StatusColor.Error;
    }
    #endregion

    private void SetErrorStatusFormulaDisease(string t)
    {
        lbStatusFormulaDisease.Text = t;
        lbStatusFormulaDisease.ForeColor = Constant.StatusColor.Error;
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

    private void ClearFormulaServeData()
    {
        this.txhID.Text = "";
        this.txtServeName.Text = "";
        this.txtWeightRaw.Text = "";
        this.txtWeightRipe.Text = "";
    }

    private ArrayList GetFormulaSetItem(bool doSaveToDatabase)
    {
        FormulaSetFlow fFlow = new FormulaSetFlow();
        ArrayList arrData = new ArrayList();
        for (int i = 0; i < this.gvFormulaSetItem.Rows.Count; ++i)
        {
            FormulaSetItemData FormulaSetItem = new FormulaSetItemData();
            FormulaSetItem.ENERGY = Convert.ToDouble("0" + this.gvFormulaSetItem.Rows[i].Cells[9].Text);
            FormulaSetItem.FORMULASET = Convert.ToDouble("0" + this.txtLOID.Text);
            FormulaSetItem.MATERIALMASTER = Convert.ToDouble("0" + this.gvFormulaSetItem.Rows[i].Cells[14].Text);
            FormulaSetItem.PREPARENAME = ((TextBox)this.gvFormulaSetItem.Rows[i].Cells[6].FindControl("txtPrepareNameEdit")).Text;
            FormulaSetItem.REFFORMULA = 0;
            FormulaSetItem.WEIGHTRAW = Convert.ToDouble("0" + ((TextBox)this.gvFormulaSetItem.Rows[i].Cells[7].FindControl("txtWeightRawEdit")).Text);
            FormulaSetItem.LOID = Convert.ToDouble("0" + this.gvFormulaSetItem.Rows[i].Cells[1].Text);
            FormulaSetItem.WEIGHT = fFlow.GetWeightStockout(FormulaSetItem.MATERIALMASTER, FormulaSetItem.WEIGHTRAW);
            FormulaSetItem.ENERGY = fFlow.CalEnergyWeight(FormulaSetItem.MATERIALMASTER, FormulaSetItem.WEIGHTRAW);

            if (Convert.ToDouble(cmbFoodCookType.SelectedValue) == 0)
            {
                FormulaSetItem.WEIGHTRIPE = 0;
            }
            else
            {
                FormulaSetItem.WEIGHTRIPE = fFlow.GetWeightCook(FormulaSetItem.MATERIALMASTER, FormulaSetItem.WEIGHTRAW, Convert.ToDouble(cmbFoodCookType.SelectedValue));

                if (doSaveToDatabase)
                {
                    double weight = Convert.ToDouble("0" + this.gvFormulaSetItem.Rows[i].Cells[15].Text);
                    FormulaSetItem.WEIGHTRIPE = 0;
                    if (weight != 0) FormulaSetItem.WEIGHTRIPE = Math.Round(fFlow.GetWeightCook(FormulaSetItem.MATERIALMASTER, FormulaSetItem.WEIGHTRAW, Convert.ToDouble(cmbFoodCookType.SelectedValue)), 2);
                }
            }
            arrData.Add(FormulaSetItem);
            totalEnergy += FormulaSetItem.ENERGY;
            totalWeightRipe += FormulaSetItem.WEIGHTRIPE;
        }
        return arrData;
    }

    private ArrayList GetFormulaSetItem()
    {
        return GetFormulaSetItem(false);
    }

    private ArrayList GetFormulaServeItem()
    {
        ArrayList arrData = new ArrayList();
        for (int i = 0; i < this.gvFormulaServe.Rows.Count; ++i)
        {
            FormulaServeData FormulaServe = new FormulaServeData();
            FormulaServe.FORMULASET = Convert.ToDouble("0" + this.txtLOID.Text);
            FormulaServe.NAME = this.gvFormulaServe.Rows[i].Cells[6].Text;
            FormulaServe.WEIGHTRIPE = Convert.ToDouble("0" + this.gvFormulaServe.Rows[i].Cells[4].Text);
            FormulaServe.WEIGHTRAW = Convert.ToDouble("0" + this.gvFormulaServe.Rows[i].Cells[5].Text);
            arrData.Add(FormulaServe);
            totalServeWeightRipe += FormulaServe.WEIGHTRIPE;
        }
        return arrData;
    }

    private void DoGetFormulaServeDetail(int rank)
    {
        GridViewRow gRow = this.gvFormulaServe.Rows[rank - 1];
        this.txhID.Text = gRow.Cells[0].Text;
        this.txtServeName.Text = ((LinkButton)gRow.Cells[3].FindControl("lnkName")).Text;
        this.txtWeightRaw.Text = gRow.Cells[5].Text;
        this.txtWeightRipe.Text = gRow.Cells[4].Text;
    }

    private FormulaSetDetailData GetData()
    {
        FormulaSetDetailData fsData = new FormulaSetDetailData();
        fsData.ACTIVE = this.chkActive.Checked;
        fsData.DISHESTYPE = Convert.ToDouble(this.cmbDishesType.SelectedItem.Value);
        fsData.ENERGY = Convert.ToDouble("0" + this.txtEnergy.Text);
        fsData.FOODCATEGORY = Convert.ToDouble(this.cmbFoodCategory.SelectedItem.Value);
        fsData.FOODCOOKTYPE = Convert.ToDouble(this.cmbFoodCookType.SelectedItem.Value);
        fsData.FOODTYPE = Convert.ToDouble(this.cmbFoodType.SelectedItem.Value);
        fsData.IMGPATH = "";
        fsData.ISELEMENT = this.chkIsElement.Checked;
        fsData.ISONEDISH = this.chkIsOneDish.Checked;
        fsData.ISSPECIFIC = this.chkIsSpecific.Checked;
        fsData.LOID = Convert.ToDouble("0" + this.txtLOID.Text);
        fsData.NAME = this.txtName.Text.Trim();
        fsData.PACKAGE = Convert.ToDouble(this.cmbPackage.SelectedItem.Value);
        fsData.PORTION = Convert.ToDouble("0" + this.txtPortion.Text);
        fsData.PREPARE = this.txtPrepare.Text.Trim();
        fsData.RECIPE = this.txtRecipe.Text.Trim();
        fsData.SERVEMETHOD = this.txtServeMethod.Text.Trim();
        fsData.STATUS = this.txtStatus.Text.Trim();
        fsData.WEIGHTFORMULA = Convert.ToDouble("0" + this.txtWeightFormula.Text);
        fsData.WEIGHTPORTION = Convert.ToDouble("0" + this.txtWeightPortion.Text);

        if (this.chkIsElement.Enabled)
        {
            FormulaSetDetailItem item = new FormulaSetDetailItem();
            switch (this.txtCurentTab.Text)
            {
                case "0":
                    fsData.FormulaSetItem = GetFormulaSetItem(true);
                    fsData.RefFormulaSet = item.GetRefFormulasetItemData();
                    fsData.ENERGY = totalEnergy + item.TotalRefEnergy;
                    fsData.WEIGHTFORMULA = Math.Round(totalWeightRipe + item.TotalRefWeightRipe, 2);
                    break;
                case "1":
                    fsData.FormulaServe = GetFormulaServeItem();
                    fsData.WEIGHTPORTION = totalServeWeightRipe;
                    break;
                case "2":
                    fsData.FormulaDisease = GetFormulasetDiseaseData();
                    break;
            }
        }
        return fsData;
    }

    public ArrayList GetFormulasetDiseaseData()
    {
        ArrayList arrData = new ArrayList();
        for (int i = 0; i < this.gvFormulaDisease.Rows.Count; ++i)
        {
            GridViewRow gRow = this.gvFormulaDisease.Rows[i];
            FormulaDiseaseData FormulaDisease = new FormulaDiseaseData();
            FormulaDisease.DISEASECATEGORY = Convert.ToDouble("0" + gRow.Cells[7].Text);
            FormulaDisease.REFTABLE = "FORMULASET";
            FormulaDisease.ISHIGH = (((RadioButton)gRow.Cells[4].FindControl("chkHigh")).Checked ? "Y" : "N");
            FormulaDisease.ISLOW = (((RadioButton)gRow.Cells[5].FindControl("chkLow")).Checked ? "Y" : "N");
            FormulaDisease.ISNON = (((RadioButton)gRow.Cells[6].FindControl("chkNon")).Checked ? "Y" : "N");
            arrData.Add(FormulaDisease);
        }
        return arrData;
    }

    private void ViewData(bool isView)
    {
        this.txtName.ReadOnly = isView;
        this.txtName.CssClass = (isView ? "zTextbox-View" : "zTextbox");
        this.cmbDishesType.Enabled = !isView;
        this.cmbFoodCategory.Enabled = !isView;
        this.cmbFoodCookType.Enabled = !isView;
        this.cmbFoodType.Enabled = !isView;
        this.cmbPackage.Enabled = !isView;
        this.txtPortion.ReadOnly = isView;
        this.txtPortion.CssClass = (isView ? "zTextboxR-View" : "zTextboxR");
        this.txtRecipe.ReadOnly = isView;
        this.txtRecipe.CssClass = (isView ? "zTextbox-View" : "zTextbox");
        this.txtServeMethod.ReadOnly = isView;
        this.txtServeMethod.CssClass = (isView ? "zTextbox-View" : "zTextbox");
        this.txtPrepare.ReadOnly = isView;
        this.txtPrepare.CssClass = (isView ? "zTextbox-View" : "zTextbox");
        this.chkIsElement.Enabled = !isView;
        this.chkIsOneDish.Enabled = !isView;
        this.chkIsSpecific.Enabled = !isView;

        tbAddFormulaSetItem.Visible = !isView;
        tbDeleteFormulaSetItem.Visible = !isView;
        this.gvFormulaSetItem.Columns[2].Visible = !isView;

        tbAddRefFormulaSet.Visible = !isView;
        tbDeleteRefFormulaSet.Visible = !isView;
        this.gvRefFormula.Columns[1].Visible = !isView;

        this.tbAddFormulaServe.Visible = !isView;
        this.tbDeleteFormulaServe.Visible = !isView;
        this.tbAddFormulaServeDetail.Visible = !isView;
        this.tbAddAndNewFormulaServe.Visible = !isView;
        this.tbCancelFormulaServe.Visible = !isView;
        this.gvFormulaServe.Columns[1].Visible = !isView;

        tbAddFormulaDisease.Visible = !isView;
        tbDeleteFormulaDisease.Visible = !isView;
        this.gvFormulaDisease.Columns[1].Visible = !isView;

        this.ctlAttach.ReadOnly = isView;
    }

    private void SetData(FormulaSetDetailData fsData)
    {
        if (fsData.STATUS == "AP") Appz.BuildCombo(cmbFoodType, "FOODTYPE", "NAME", "LOID", "", "NAME", "เลือก", "0", false);
        bool pageAuthorized = true;
        this.chkActive.Checked = fsData.ACTIVE;
        this.cmbDishesType.SelectedIndex = this.cmbDishesType.Items.IndexOf(this.cmbDishesType.Items.FindByValue(fsData.DISHESTYPE.ToString()));
        this.txtEnergy.Text = fsData.ENERGY.ToString(Constant.DoubleFormat);
        this.cmbFoodCategory.SelectedIndex = this.cmbFoodCategory.Items.IndexOf(this.cmbFoodCategory.Items.FindByValue(fsData.FOODCATEGORY.ToString()));
        this.cmbFoodCookType.SelectedIndex = this.cmbFoodCookType.Items.IndexOf(this.cmbFoodCookType.Items.FindByValue(fsData.FOODCOOKTYPE.ToString()));
        this.cmbFoodType.SelectedIndex = this.cmbFoodType.Items.IndexOf(this.cmbFoodType.Items.FindByValue(fsData.FOODTYPE.ToString()));
        this.chkIsElement.Checked = fsData.ISELEMENT;
        this.chkIsOneDish.Checked = fsData.ISONEDISH;
        this.chkIsSpecific.Checked = fsData.ISSPECIFIC;
        this.txtLOID.Text = fsData.LOID.ToString();
        this.txtName.Text = fsData.NAME;
        this.cmbPackage.SelectedIndex = this.cmbPackage.Items.IndexOf(this.cmbPackage.Items.FindByValue(fsData.PACKAGE.ToString()));
        this.txtPortion.Text = fsData.PORTION.ToString(Constant.IntFormat);
        this.txtPrepare.Text = fsData.PREPARE;
        this.txtRecipe.Text = fsData.RECIPE;
        this.txtServeMethod.Text = fsData.SERVEMETHOD;
        this.txtStatus.Text = fsData.STATUS;
        this.txtStatusName.Text = fsData.STATUSNAME;
        this.txtWeightFormula.Text = fsData.WEIGHTFORMULA.ToString(Constant.DoubleFormat);
        this.txtWeightPortion.Text = fsData.WEIGHTPORTION.ToString(Constant.DoubleFormat);
        this.ctlAttach.UniqID = fsData.LOID.ToString();

        this.tbPrint.ClientClick = Appz.OpenReportScript(Constant.Reports.FormulaSetReport, fsData.LOID, false);

        FormulaSetDetailItem fsItem = new FormulaSetDetailItem();
        switch (this.txtCurentTab.Text)
        {
            case "0":
                fsItem.ClearFormulaSetItem();
                fsItem.ClearRefFormulaSet();
                BindFormulaSetItem();
                BindRefFormulaSet();
                break;
            case "1":
                fsItem.ClearFormulaServe();
                BindFormulaServe();
                break;
            case "2":
                fsItem.ClearFormulaDisease();
                BindFormulaDisease();
                break;
            case "3":
                this.gvFormulaSetNutrient.DataBind();
                break;
            default:
                fsItem.ClearAllSession();
                BindFormulaSetItem();
                BindRefFormulaSet();
                BindFormulaServe();
                BindFormulaDisease();
                break;
        }

        this.tbPrint.Visible = (fsData.LOID != 0);
        if (!pageAuthorized)
        {
            ViewData(true);

            this.tbApprove.Visible = false;
            this.tbCancel.Visible = false;
            this.tbNotApprove.Visible = false;
            this.tbSave.Visible = false;
            this.tbTest.Visible = false;
            this.chkActive.Enabled = false;
        }
        else
        {
            if (txtDivision.Text.Trim() == Appz.LoggedOnUser.DIVISION.ToString()) //เช็คว่าใช้หน่วยงานที่สร้างรายการนี้หรือไม่
            {
                if (fsData.STATUS == "AP")
                {
                    ViewData(true);
                }
                else
                {
                    ViewData(false);
                }

                this.tbApprove.Visible = (fsData.STATUS == "TE");
                this.tbCancel.Visible = (fsData.STATUS == "WA" || fsData.STATUS == "TE" || fsData.STATUS == "AP" || fsData.STATUS == "NA");
                this.tbNotApprove.Visible = (fsData.STATUS == "TE");
                this.tbPrint.Visible = (fsData.LOID != 0);
                this.tbSave.Visible = (fsData.STATUS == "WA" || fsData.STATUS == "TE" || fsData.STATUS == "AP" || fsData.STATUS == "NA");
                this.tbTest.Visible = (fsData.STATUS == "WA" || fsData.STATUS == "NA");
                this.chkActive.Enabled = (fsData.STATUS == "WA" || fsData.STATUS == "TE" || fsData.STATUS == "AP" || fsData.STATUS == "NA");
            }
            else
            {
                ViewData(true);
                this.chkActive.Enabled = false;
                this.tbApprove.Visible = false;
                this.tbCancel.Visible = false;
                this.tbNotApprove.Visible = false;
                this.tbPrint.Visible = (fsData.LOID != 0);
                this.tbSave.Visible = false;
                this.tbTest.Visible = false;

            }
        }
    }

    #endregion

    #region Working Method

    private void UpdateFormulaSetItem()
    {
        FormulaSetDetailItem fsItem = new FormulaSetDetailItem();
        if (!fsItem.UpdateFormulaSetItem(Convert.ToDouble("0" + this.txtLOID.Text), GetFormulaSetItem()))
            SetErrorStatusFormulaSetItem(DataResources.MSGEC102);
    }

    private void UpdateRefFormulaSetItem()
    {
        FormulaSetDetailItem fsItem = new FormulaSetDetailItem();
        if (!fsItem.UpdateRefFormulaSetItem(Convert.ToDouble("0" + this.txtLOID.Text), Convert.ToDouble("0" + this.txtPortion.Text), fsItem.GetRefFormulasetItemData()))
            SetErrorStatusFormulaSetItem(DataResources.MSGEC102);
        else
            BindRefFormulaSet();
    }

    private bool DoSaveFormulaServe()
    {
        FormulaSetDetailItem fsItem = new FormulaSetDetailItem();
        bool ret = true;
        if (this.txtServeName.Text.Trim() == "")
        {
            ret = false;
            SetErrorStatusFormualServeDetail(string.Format(DataResources.MSGEI001, "ส่วนผสม"));
        }
        else if (Convert.ToDouble("0" + this.txtWeightRipe.Text) == 0)
        {
            ret = false;
            SetErrorStatusFormualServeDetail(string.Format(DataResources.MSGEI001, "น้ำหนักสุก"));
        }
        else
        {
            FormulaServeData FormulaServe = new FormulaServeData();
            FormulaServe.FORMULASET = Convert.ToDouble("0" + this.txtLOID.Text);
            FormulaServe.LOID = Convert.ToDouble("0" + txhID.Text);
            FormulaServe.NAME = this.txtServeName.Text;
            FormulaServe.WEIGHTRAW = Convert.ToDouble("0" + this.txtWeightRaw.Text);
            FormulaServe.WEIGHTRIPE = Convert.ToDouble("0" + this.txtWeightRipe.Text);

            try
            {
                if (FormulaServe.LOID != 0)
                    ret = fsItem.UpdateFormulaServe(FormulaServe);
                else
                    ret = fsItem.InsertFormulaServe(FormulaServe);
            }
            catch (Exception ex)
            {
                ret = false;
                SetErrorStatusFormualServeDetail(ex.Message);
            }
            if (ret)
                BindFormulaServe();
        }
        return ret;
    }

    private bool doGetDetail(string LOID)
    {
        this.txtCurentTab.Text = this.tabFormulaSet.ActiveTabIndex.ToString();
        FormulaSetFlow fFlow = new FormulaSetFlow();
        FormulaSetDetailData fData = fFlow.GetDetails(Convert.ToDouble(LOID));

        bool ret = true;
        SetData(fData);
       
        return ret;
    }

    private bool doSaveActive()
    {
        FormulaSetFlow ftFlow = new FormulaSetFlow();
        bool ret = true;
        ret = ftFlow.UpdateActive(Convert.ToDouble("0" + this.txtLOID.Text), chkActive.Checked, Appz.CurrentUser);

        if (!ret)
            SetErrorStatus(ftFlow.ErrorMessage);
        else
        {
            doGetDetail(ftFlow.LOID.ToString());
            SetStatus(DataResources.MSGIU001);
        }

        return ret;
    }

    private bool doSave()
    {
        UpdateRefFormulaSetItem();
        FormulaSetFlow ftFlow = new FormulaSetFlow();
        bool ret = true;

        // verify required field
        FormulaSetDetailData FormulaSetDetail = GetData();
        string error = VerifyData(FormulaSetDetail);
        if (error != "")
        {
            SetErrorStatus(error);
            return false;
        }

        // verify uniq field
        if (!ftFlow.CheckUniqueKey(FormulaSetDetail.LOID, FormulaSetDetail.NAME, FormulaSetDetail.FOODTYPE, FormulaSetDetail.FOODCATEGORY, FormulaSetDetail.PORTION))
        {
            SetErrorStatus(string.Format(DataResources.MSGEI018, new string[] { "ชื่อสูตรอาหาร", FormulaSetDetail.NAME, "ประเภทอาหาร", this.cmbFoodType.SelectedItem.Text, "ชนิดอาหาร", this.cmbFoodCategory.SelectedItem.Text, "Potion", this.txtPortion.Text }));
            return false;
        }

        // data correct go on saving...
        if (FormulaSetDetail.LOID != 0)
            ret = ftFlow.UpdateData(FormulaSetDetail, Appz.CurrentUser, this.txtCurentTab.Text);
        else
            ret = ftFlow.InsertData(FormulaSetDetail, Appz.CurrentUser, this.txtCurentTab.Text);

        if (!ret)
            SetErrorStatus(ftFlow.ErrorMessage);
        else
        {
            this.txtCurentTab.Text = this.tabFormulaSet.ActiveTabIndex.ToString();
            doGetDetail(ftFlow.LOID.ToString());
            if (FormulaSetDetail.LOID == 0)
                SetStatus(DataResources.MSGIN001);
            else
                SetStatus(DataResources.MSGIU001);
        }
        return ret;
    }

    private string VerifyData(FormulaSetDetailData fData)
    {
        string ret = "";
        if (fData.NAME == "")
            ret = string.Format(DataResources.MSGEI001, "ชื่อสูตรอาหาร");
        else if (fData.FOODTYPE == 0)
            ret = string.Format(DataResources.MSGEI002, "ประเภทอาหาร");
        else if (fData.FOODCATEGORY == 0)
            ret = string.Format(DataResources.MSGEI002, "ชนิดอาหาร");
        else if (fData.FOODCOOKTYPE == 0)
            ret = string.Format(DataResources.MSGEI002, "ประเภทการปรุง");
        else if (fData.DISHESTYPE == 0)
            ret = string.Format(DataResources.MSGEI002, "ประเภทคาวหวาน");
        else if (fData.PORTION == 0)
            ret = string.Format(DataResources.MSGEI001, "Portion");
        else if (fData.FormulaSetItem.Count == 0 && this.txtCurentTab.Text == "0")
            ret = string.Format(DataResources.MSGEI001, "วัตถุดิบในสูตรอาหาร");
        else if (this.txtCurentTab.Text == "0")
        {
            for (int i = 0; i < fData.FormulaSetItem.Count; ++i)
            {
                FormulaSetItemData FormulaSetItem = (FormulaSetItemData)fData.FormulaSetItem[i];
                if (FormulaSetItem.PREPARENAME == "")
                    ret = string.Format(DataResources.MSGEI001, "ชื่อในการเตรียม");
                else if (FormulaSetItem.WEIGHTRAW == 0)
                    ret = string.Format(DataResources.MSGEI001, "น้ำหนักสูตร");

                if (ret != "") break;
            }
        }

        return ret;
    }

    private void CheckDivision(double LOID)
    {
        FormulaSetFlow fFlow = new FormulaSetFlow();
        if (LOID.ToString() == "0")
            txtDivision.Text = Appz.LoggedOnUser.DIVISION.ToString();
        else
            txtDivision.Text = fFlow.GetDivision(LOID).ToString();
        
       
    }
    #endregion

    protected void cmbFoodType_SelectedIndexChanged(object sender, EventArgs e)
    {
        FormulaSetDetailItem fsItem = new FormulaSetDetailItem();
        fsItem.DeleteRefFormulaSet();
        BindRefFormulaSet();
    }
    protected void cmbFoodCategory_SelectedIndexChanged(object sender, EventArgs e)
    {
        FormulaSetDetailItem fsItem = new FormulaSetDetailItem();
        fsItem.DeleteRefFormulaSet();
        BindRefFormulaSet();
    }


    protected void txtPortion_TextChanged(object sender, EventArgs e)
    {
        UpdateRefFormulaSetItem();
    }
}