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
/// Formula Feed Detail Page Class
/// Version 1.0
/// =========================================================================
/// Create by: Tan
/// Create Date: 13 Jan 2009
/// -------------------------------------------------------------------------
/// Modify By: -
/// Modify From: -
/// Modify Date: -
/// -------------------------------------------------------------------------
/// Remark: -
/// Description:
///    หน้ากาารทำงานข้อมูล Blenderize Diet Detail
/// Changes:
///    1.0 - สร้าง
/// -------------------------------------------------------------------------
/// =========================================================================
/// </summary>
/// 

public partial class App_Formula_Master_BlenderizeDietDetail : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            if (Request["loid"] != null)
            {
                doGetDetail((Request["loid"] == null ? "0" : Request["loid"]), "");
            }
            else
            {
                BlenderizeItem fsItem = new BlenderizeItem();
                fsItem.ClearBlenderizeItem();
            }
        }
    }
    protected override void OnInit(EventArgs e)
    {
        base.OnInit(e);

        // Feed Combo source
        //Appz.BuildCombo(cmbFeedType, "FeedTYPE", "NAME", "LOID", "ACTIVE='1'", "NAME", "เลือก", "0", false);
        //Appz.BuildCombo(cmbFeedCategory, "FeedCATEGORY", "NAME", "LOID", "ACTIVE='1'", "NAME", "เลือก", "0", false);
        //Appz.BuildCombo(cmbFeedCookType, "FeedCOOKTYPE", "NAME", "LOID", "ACTIVE='1'", "NAME", "เลือก", "0", false);
        //Appz.BuildCombo(cmbDishesType, "DISHESTYPE", "NAME", "LOID", "ACTIVE='1'", "NAME", "เลือก", "0", false);
        //Appz.BuildCombo(cmbPackage, "V_MATERIALMASTER", "NAME", "LOID", "ACTIVE='1' AND MASTERTYPE = 'TL'", "NAME", "เลือก", "0", false);

        ControlUtil.SetDblTextBox(txtCapacity);
        ControlUtil.SetDblTextBox(txtEnergy);
        ControlUtil.SetDblTextBox(txtCapacityRate);
        ControlUtil.SetDblTextBox(txtCarbohydrate);
        ControlUtil.SetDblTextBox(txtEnergyRate);
        ControlUtil.SetDblTextBox(txtFat);
        ControlUtil.SetDblTextBox(txtProtein);
        this.txtCurentTab.Text = this.tabFormulaFeed.ActiveTabIndex.ToString();
        this.tbDeleteFormulaFeedItem.ClientClick = "return confirm('" + DataResources.MSGCD003 + "')";
    }

    protected void tabFormulaFeed_ActiveTabChanged(object sender, EventArgs e)
    {
            if (!doSave(this.txtCurentTab.Text))
                this.tabFormulaFeed.ActiveTabIndex = Convert.ToInt32(this.txtCurentTab.Text);
    }

    protected void ctlMaterialMasterPopup_SelectedIndexChanged(object sender, EventArgs e, ArrayList arrData)
    {
        BlenderizeItem fsItem = new BlenderizeItem();
        if (fsItem.InsertFormulaFeedItem(Convert.ToDouble("0" + this.txtLOID.Text), arrData))
            BindFormulaFeedItem();
    }

    protected void ctlDiseaseCategoryPopup_SelectedIndexChanged(object sender, EventArgs e, ArrayList arrData)
    {
        BlenderizeItem fsItem = new BlenderizeItem();
        if (fsItem.InsertFormulaDisease(Convert.ToDouble("0" + this.txtLOID.Text), arrData))
            BindFormulaDisease();
    }

    #region Button Click Event Handler

    protected void tbSaveClick(object sender, EventArgs e)
    {
        doSave(this.txtCurentTab.Text);
    }
    protected void tbCancelClick(object sender, EventArgs e)
    {
        doGetDetail("0" + this.txtLOID.Text, "");
    }
    protected void tbBackClick(object sender, EventArgs e)
    {
        Response.Redirect(Constant.HomeFolder + "App_Formula/Master/BlenderizeDietSearch.aspx");
    }
    protected void tbPrintClick(object sender, EventArgs e)
    {
    }

    #endregion

    #region FormulaFeedItem Toolbar
    protected void tbAddFormulaFeedItemClick(object sender, EventArgs e)
    {
        UpdateFormulaFeedItem();
        BlenderizeItem fsItem = new BlenderizeItem();
        this.ctlMaterialMasterPopup.Show("1", fsItem.getMaterialList());
    }
    protected void tbDeleteFormulaFeedItemClick(object sender, EventArgs e)
    {
        UpdateFormulaFeedItem();
        BlenderizeItem fsItem = new BlenderizeItem();
        if (fsItem.DeleteFormulaFeedItem(GetCheckedFormulaFeedItem())) BindFormulaFeedItem();
    }
        #endregion

    #region FormulaDisease Toolbar
    protected void tbAddFormulaDiseaseClick(object sender, EventArgs e)
    {
        BlenderizeItem fsItem = new BlenderizeItem();
        BlenderizeDietFlow fFlow = new BlenderizeDietFlow();
        this.ctlDiseaseCategoryPopup.Show("1",fFlow.GetLiquidCategory(), fsItem.GetDiseaseCategoryList());
    }
    protected void tbDeleteFormulaDiseaseClick(object sender, EventArgs e)
    {
        BlenderizeItem fsItem = new BlenderizeItem();
        if (fsItem.DeleteFormulaDisease(GetCheckedFormulaDisease())) BindFormulaDisease();
    }
    #endregion

    #region Gridview Event Handler

    protected void gvFormulaFeedItem_RowDataBound(object sender, GridViewRowEventArgs e)
    {
        if (e.Row.RowType == DataControlRowType.DataRow)
        {
            DropDownList cmbUnit = (DropDownList)e.Row.Cells[6].FindControl("cmbUnit");

            Appz.BuildCombo(cmbUnit, "V_MATERIALMASTER_UNIT", "UNITNAME", "UNIT", "ISFORMULA = 'Y' AND MATERIALMASTER = " + e.Row.Cells[12].Text,"",null,null,false);
            DataRow drow = (DataRow)((DataRowView)e.Row.DataItem).Row;
            cmbUnit.SelectedIndex = cmbUnit.Items.IndexOf(cmbUnit.Items.FindByValue(drow["UNIT"].ToString()));
        }
    }
    protected void gvFormulaDisease_RowDataBound(object sender, GridViewRowEventArgs e)
    {
        //if (e.Row.RowType == DataControlRowType.Header)
        //{
        //    ((CheckBox)e.Row.Cells[1].FindControl("chkMain")).Attributes.Add("onclick", "chkAllBox(this, '" + this.gvFormulaDisease.ClientID + "_ctl', '_chkSelect')");
        //}

        if (e.Row.RowType == DataControlRowType.DataRow)
        {
            //Check ว่า radio button radISHIGH จะ visible เป็น true หรือ false
            if (e.Row.Cells[8].Text.Trim() == "N")
            {
                RadioButton chkHigh = (RadioButton)e.Row.FindControl("chkHigh");
                if (chkHigh != null)
                    chkHigh.Visible = false;
            }

            //Check ว่า radio button radISLOW จะ visible เป็น true หรือ false
            if (e.Row.Cells[9].Text.Trim() == "N")
            {
                RadioButton chkLow = (RadioButton)e.Row.FindControl("chkLow");
                if (chkLow != null)
                    chkLow.Visible = false;
            }

            //Check ว่า radio button radISNON จะ visible เป็น true หรือ false
            if (e.Row.Cells[10].Text.Trim() == "N")
            {
                RadioButton chkNon = (RadioButton)e.Row.FindControl("chkNon");
                if (chkNon != null)
                    chkNon.Visible = false;
            }

        }
    }
    protected void cmbUnit_SelectedIndexChanged(object sender, EventArgs e)
    {
        DropDownList cmb = (DropDownList)sender;
        Int16 rowIndex = (Int16)((GridViewRow)cmb.Parent.Parent).RowIndex;
        //this.grvItem.Rows[rowIndex].Cells[1].Text = (rowIndex + 1).ToString();
        TextBox txtQty = (TextBox)this.gvFormulaFeedItem.Rows[rowIndex].Cells[5].FindControl("txtQty");

        BlenderizeDietFlow ffFlow = new BlenderizeDietFlow();
        DataTable dt = ffFlow.GetEnergyByUnitList(Convert.ToDouble(this.gvFormulaFeedItem.Rows[rowIndex].Cells[12].Text), Convert.ToDouble(cmb.SelectedItem.Value));
        
        double qty = Convert.ToDouble(txtQty.Text);
        double energy = Convert.ToDouble(dt.Rows[0]["ENERGY"].ToString());
        double carbohydrate = Convert.ToDouble(dt.Rows[0]["CARBOHYDRATE"].ToString());
        double fat = Convert.ToDouble(dt.Rows[0]["FAT"].ToString());
        double protein = Convert.ToDouble(dt.Rows[0]["PROTEIN"].ToString());
        double sodium = Convert.ToDouble(dt.Rows[0]["SODIUM"].ToString());
        this.gvFormulaFeedItem.Rows[rowIndex].Cells[7].Text = String.Format("{0:N2}", (qty * energy));
        this.gvFormulaFeedItem.Rows[rowIndex].Cells[8].Text = String.Format("{0:N2}", (qty * carbohydrate));
        this.gvFormulaFeedItem.Rows[rowIndex].Cells[9].Text = String.Format("{0:N2}", (qty * protein));
        this.gvFormulaFeedItem.Rows[rowIndex].Cells[10].Text = String.Format("{0:N2}", (qty * fat));
        this.gvFormulaFeedItem.Rows[rowIndex].Cells[11].Text = String.Format("{0:N2}", (qty * sodium));
    }

    protected void txtQty_TextChanged(object sender, EventArgs e)
    {
        TextBox txt = (TextBox)sender;
        Int16 rowIndex = (Int16)((GridViewRow)txt.Parent.Parent).RowIndex;
        DropDownList cmbUnit = (DropDownList)this.gvFormulaFeedItem.Rows[rowIndex].Cells[6].FindControl("cmbUnit");
        
        BlenderizeDietFlow ffFlow = new BlenderizeDietFlow();
        DataTable dt = ffFlow.GetEnergyByUnitList(Convert.ToDouble(this.gvFormulaFeedItem.Rows[rowIndex].Cells[12].Text), Convert.ToDouble(cmbUnit.SelectedItem.Value));

        double qty = Convert.ToDouble(txt.Text);
        double energy = Convert.ToDouble(dt.Rows[0]["ENERGY"].ToString());
        double carbohydrate = Convert.ToDouble(dt.Rows[0]["CARBOHYDRATE"].ToString());
        double fat = Convert.ToDouble(dt.Rows[0]["FAT"].ToString());
        double protein = Convert.ToDouble(dt.Rows[0]["PROTEIN"].ToString());
        double sodium = Convert.ToDouble(dt.Rows[0]["SODIUM"].ToString());
        double phosphorus = Convert.ToDouble(dt.Rows[0]["PHOSPHORUS"].ToString());
        double potassium = Convert.ToDouble(dt.Rows[0]["POTASSIUM"].ToString());
        double calcium = Convert.ToDouble(dt.Rows[0]["CALCIUM"].ToString());
        this.gvFormulaFeedItem.Rows[rowIndex].Cells[7].Text = String.Format("{0:N2}", (qty * energy));
        this.gvFormulaFeedItem.Rows[rowIndex].Cells[8].Text = String.Format("{0:N2}", (qty * carbohydrate));
        this.gvFormulaFeedItem.Rows[rowIndex].Cells[9].Text = String.Format("{0:N2}", (qty * protein));
        this.gvFormulaFeedItem.Rows[rowIndex].Cells[10].Text = String.Format("{0:N2}", (qty * fat));
        this.gvFormulaFeedItem.Rows[rowIndex].Cells[11].Text = String.Format("{0:N2}", (qty * sodium));
        this.gvFormulaFeedItem.Rows[rowIndex].Cells[14].Text = String.Format("{0:N2}", (qty * phosphorus));
        this.gvFormulaFeedItem.Rows[rowIndex].Cells[15].Text = String.Format("{0:N2}", (qty * potassium));
        this.gvFormulaFeedItem.Rows[rowIndex].Cells[16].Text = String.Format("{0:N2}", (qty * calcium));

    }

    #endregion

    #region Misc. Methods

    private ArrayList GetCheckedFormulaFeedItem()
    {
        ArrayList arrChk = new ArrayList();
        for (int i = 0; i < gvFormulaFeedItem.Rows.Count; i++)
        {
            if (i > -1 && gvFormulaFeedItem.Rows[i].Cells[0].FindControl("chkSelect") != null)
            {
                GridViewRow gRow = gvFormulaFeedItem.Rows[i];
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
            if (i > -1 && gvFormulaDisease.Rows[i].Cells[0].FindControl("chkSelect") != null)
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

    private void BindFormulaFeedItem()
    {
        this.gvFormulaFeedItem.DataBind();
    }

    private void BindFormulaDisease()
    {
        this.gvFormulaDisease.DataBind();
    }

    private void SetErrorStatusFormulaFeedItem(string t)
    {
        lbStatusFormulaFeedItem.Text = t;
        lbStatusFormulaFeedItem.ForeColor = Constant.StatusColor.Error;
    }

    private void SetErrorStatusFormulaDisease(string t)
    {
        lbStatusFormulaDisease.Text = t;
        lbStatusFormulaDisease.ForeColor = Constant.StatusColor.Error;
    }

    private void FeedStatusFormulaFeedItem(string t)
    {
        lbStatusFormulaFeedItem.Text = t;
        lbStatusFormulaFeedItem.ForeColor = Constant.StatusColor.Information;
    }

    private void FeedStatus(string t)
    {
        lbStatus.Text = t;
        lbStatus.ForeColor = Constant.StatusColor.Information;
    }

    private void SetErrorStatus(string t)
    {
        lbStatus.Text = t;
        lbStatus.ForeColor = Constant.StatusColor.Error;
    }

    private ArrayList GetFormulaFeedItem()
    {
        ArrayList arrData = new ArrayList();
        for (int i = 0; i < this.gvFormulaFeedItem.Rows.Count; ++i)
        {
            FormularFeedItemData FormulaFeedItem = new FormularFeedItemData();
            FormulaFeedItem.ENERGY = Convert.ToDouble("0" + this.gvFormulaFeedItem.Rows[i].Cells[7].Text);
            FormulaFeedItem.FORMULAFEED = Convert.ToDouble("0" + this.txtLOID.Text);
            FormulaFeedItem.MATERIALMASTER = Convert.ToDouble("0" + this.gvFormulaFeedItem.Rows[i].Cells[12].Text);
            FormulaFeedItem.UNIT = Convert.ToDouble("0" + ((DropDownList)this.gvFormulaFeedItem.Rows[i].Cells[6].FindControl("cmbUnit")).SelectedValue);
            FormulaFeedItem.QTY = Convert.ToDouble("0" + ((TextBox)this.gvFormulaFeedItem.Rows[i].Cells[5].FindControl("txtQty")).Text);
            FormulaFeedItem.LOID = Convert.ToDouble("0" + this.gvFormulaFeedItem.Rows[i].Cells[1].Text);
            FormulaFeedItem.CARBOHYDRATE = Convert.ToDouble("0" + this.gvFormulaFeedItem.Rows[i].Cells[8].Text);
            FormulaFeedItem.PROTEIN = Convert.ToDouble("0" + this.gvFormulaFeedItem.Rows[i].Cells[9].Text);
            FormulaFeedItem.FAT = Convert.ToDouble("0" + this.gvFormulaFeedItem.Rows[i].Cells[10].Text);
            FormulaFeedItem.SODIUM = Convert.ToDouble("0" + this.gvFormulaFeedItem.Rows[i].Cells[11].Text);

            arrData.Add(FormulaFeedItem);
        }
        return arrData;
    }

    private ArrayList GetFormulaDiseaseItem()
    {
        ArrayList arrData = new ArrayList();
        for (int i = 0; i < this.gvFormulaDisease.Rows.Count; ++i)
        {
            RadioButton chkHigh = (RadioButton)this.gvFormulaDisease.Rows[i].Cells[4].FindControl("chkHigh");
            RadioButton chkLow = (RadioButton)this.gvFormulaDisease.Rows[i].Cells[5].FindControl("chkLow");
            RadioButton chkNon = (RadioButton)this.gvFormulaDisease.Rows[i].Cells[6].FindControl("chkNon");
            FormulaDiseaseData FormulaDisease = new FormulaDiseaseData();
            FormulaDisease.DISEASECATEGORY = Convert.ToDouble("0" + this.gvFormulaDisease.Rows[i].Cells[7].Text);
            FormulaDisease.REFLOID = Convert.ToDouble("0" + txtLOID.Text);
            FormulaDisease.REFTABLE = "FORMULAFEED";
            if (chkHigh.Checked)
                FormulaDisease.ISHIGH = "Y";
            else
                FormulaDisease.ISHIGH = "N";
            if (chkLow.Checked)
                FormulaDisease.ISLOW = "Y";
            else
                FormulaDisease.ISLOW = "N";
            if (chkNon.Checked)
                FormulaDisease.ISNON = "Y";
            else
                FormulaDisease.ISNON = "N";

            arrData.Add(FormulaDisease);
        }
        return arrData;
    }

    private FormulaFeedData GetData()
    {
        FormulaFeedData fsData = new FormulaFeedData();
        fsData.ACTIVE = this.chkActive.Checked;
        fsData.FEEDCATEGORY = "B";
        fsData.NAME = this.txtName.Text.Trim();
        fsData.CAPACITY = Convert.ToDouble("0" + this.txtCapacity.Text);
        fsData.CAPACITYRATE = Convert.ToDouble("0" + this.txtCapacityRate.Text);
        fsData.ENERGYRATE = Convert.ToDouble("0" + this.txtEnergyRate.Text);
        fsData.ENERGY = Convert.ToDouble("0" + this.txtEnergy.Text);//(fsData.CAPACITY * fsData.ENERGYRATE) / fsData.CAPACITYRATE;
        fsData.CARBOHYDRATE = Convert.ToDouble("0" + this.txtCarbohydrate.Text);
        fsData.PROTEIN = Convert.ToDouble("0" + this.txtProtein.Text);
        fsData.FAT = Convert.ToDouble("0" + this.txtFat.Text);
        fsData.LOID = Convert.ToDouble("0" + this.txtLOID.Text);

        BlenderizeItem item = new BlenderizeItem();
        switch (this.txtCurentTab.Text)
        {
            case "0":
                fsData.FormulaFeedItem = GetFormulaFeedItem();
                break;
            case "1":
                fsData.FormulaDisease = GetFormulaDiseaseItem();
                break;
        }
        return fsData;
    }

    private void SetData(FormulaFeedData fsData)
    {
        this.chkActive.Checked = fsData.ACTIVE;
        this.txtName.Text = fsData.NAME;
        this.txtLOID.Text = fsData.LOID.ToString();
        this.txtEnergy.Text = fsData.ENERGY.ToString(Constant.IntFormat);
        this.txtFeedCategory.Text = "Blenderize diet";
        this.txtCapacity.Text = fsData.CAPACITY.ToString(Constant.IntFormat);
        this.txtCapacityRate.Text = fsData.CAPACITYRATE.ToString(Constant.DoubleFormat);
        this.txtEnergyRate.Text = fsData.ENERGYRATE.ToString(Constant.DoubleFormat);
        this.txtCarbohydrate.Text = fsData.CARBOHYDRATE.ToString(Constant.IntFormat);
        this.txtProtein.Text = fsData.PROTEIN.ToString(Constant.IntFormat);
        this.txtFat.Text = fsData.FAT.ToString(Constant.IntFormat);

        this.tbPrint.ClientClick = Appz.OpenReportScript(Constant.Reports.FormularFeedBDReport, fsData.LOID, false);

        BlenderizeItem fsItem = new BlenderizeItem();
        switch (this.txtCurentTab.Text)
        {
            case "0":
                fsItem.ClearBlenderizeItem();
                BindFormulaFeedItem();
                break;
            case "1":
                fsItem.ClearFormulaDisease();
                BindFormulaDisease();
                break;
            case "2":
                this.gvFormulaFeedNutrient.DataBind();
                break;
            default:
                fsItem.ClearAllSession();
                BindFormulaFeedItem();
                break;
        }

    }

    #endregion

    #region Working Method

    private void UpdateFormulaFeedItem()
    {
        BlenderizeItem fsItem = new BlenderizeItem();
        if (!fsItem.UpdateFormulaFeedItem(Convert.ToDouble("0" + this.txtLOID.Text), GetFormulaFeedItem()))
            SetErrorStatusFormulaFeedItem(DataResources.MSGEC102);
        else
            FeedStatusFormulaFeedItem(DataResources.MSGIU001);
    }

    private bool doGetDetail(string LOID, string CurrentTabIndex)
    {
        BlenderizeDietFlow fFlow = new BlenderizeDietFlow();
        FormulaFeedData fData = fFlow.GetDetails(Convert.ToDouble(LOID));

        bool ret = true;
        SetData(fData);
        BlenderizeItem fsItem = new BlenderizeItem();
        switch (CurrentTabIndex)
        {
            case "0":
                fsItem.ClearBlenderizeItem();
               // fsItem.ClearRefFormulaFeed();
                BindFormulaFeedItem();
              //  BindRefFormulaFeed();
                break;
            case "1":
                //fsItem.ClearFormulaDisease();
                //BindFormulaDisease();
                break;
            case "3":
                //this.gvFormulaFeedNutrient.DataBind();
                break;
            default:
                fsItem.ClearAllSession();
                BindFormulaFeedItem();
                //BindRefFormulaFeed();
                //BindFormulaServe();
                //BindFormulaDisease();
                break;
        }

        return ret;
    }

    private bool doSave(string currentTabIndex)
    {
        // verify required field
        FormulaFeedData FormulaFeedDetail = GetData();
        string error = VerifyData(FormulaFeedDetail);
        if (error != "")
        {
            SetErrorStatus(error);
            return false;
        }

        BlenderizeDietFlow ftFlow = new BlenderizeDietFlow();
        bool ret = true;

        // verify uniq field
        if (!ftFlow.CheckUniqueKey(FormulaFeedDetail.LOID, FormulaFeedDetail.NAME))
        {
            SetErrorStatus(string.Format(DataResources.MSGEI015, "ชื่อสูตร", FormulaFeedDetail.NAME));
            return false;
        }

        // data correct go on saving...
        if (FormulaFeedDetail.LOID != 0)
            ret = ftFlow.UpdateData(FormulaFeedDetail, Appz.CurrentUser, currentTabIndex);
        else
            ret = ftFlow.InsertData(FormulaFeedDetail, Appz.CurrentUser, currentTabIndex);

        if (!ret)
            SetErrorStatus(ftFlow.ErrorMessage);
        else
        {
            this.txtCurentTab.Text = this.tabFormulaFeed.ActiveTabIndex.ToString();
            doGetDetail(ftFlow.LOID.ToString(), this.txtCurentTab.Text);
            if (FormulaFeedDetail.LOID != 0)
                FeedStatus(DataResources.MSGIU001);
            else
                FeedStatus(DataResources.MSGIN001);
        }

        return ret;
    }

    private string VerifyData(FormulaFeedData fData)
    {
        string ret = "";
        bool check = true;
        if (fData.NAME == "")
            ret = string.Format(DataResources.MSGEI001, "ชื่อสูตรอาหาร");
        else if (fData.CAPACITY == 0)
            ret = string.Format(DataResources.MSGEI001, "ปริมาณ");
        else if (fData.ENERGYRATE == 0 || fData.CAPACITYRATE == 0)
            ret = string.Format(DataResources.MSGEI001, "อัตราส่วน");
        else if (fData.FormulaFeedItem.Count == 0 && this.txtCurentTab.Text == "0")
            ret = string.Format(DataResources.MSGEI001, "วัตถุดิบในสูตรอาหาร");

        if (ret == "" & txtCurentTab.Text == "0")
        {
            foreach (GridViewRow row in gvFormulaFeedItem.Rows)
            {
                TextBox txt = (TextBox)row.Cells[5].FindControl("txtQty");
                if (txt.Text == "" || Convert.ToDouble(txt.Text) == 0)
                {
                    check = false;
                    break;
                }
            }
            if (!check)
                ret = string.Format("จำนวนในรายการวัตถุดิบต้องมากกว่า 0");
        }

        return ret;
    }

    #endregion
    protected void txtCapacity_TextChanged(object sender, EventArgs e)
    {
        if (txtCapacity.Text != "" && txtEnergyRate.Text != "" && txtCapacityRate.Text != "" && txtEnergyRate.Text.Trim() != "0" && txtCapacityRate.Text.Trim() != "0")
        {
            CalculateEnergy();
        }
        else
            txtEnergy.Text = "0";
    }
    protected void txtEnergyRate_TextChanged(object sender, EventArgs e)
    {
        if (txtCapacity.Text != "" && txtEnergyRate.Text != "" && txtCapacityRate.Text != "" && txtEnergyRate.Text.Trim() != "0" && txtCapacityRate.Text.Trim() != "0")
        {
            CalculateEnergy();
        }
        else
            txtEnergy.Text = "0";
    }
    protected void txtCapacityRate_TextChanged(object sender, EventArgs e)
    {
        if (txtCapacity.Text != "" && txtEnergyRate.Text != "" && txtCapacityRate.Text != "" && txtEnergyRate.Text.Trim() != "0" && txtCapacityRate.Text.Trim() != "0")
        {
            CalculateEnergy();
        }
        else
            txtEnergy.Text = "0";
    }

    private void CalculateEnergy()
    {
        double cap = (txtCapacity.Text == "" ? 0 : Convert.ToDouble(txtCapacity.Text.Trim()));
        double caprate = Convert.ToDouble(txtCapacityRate.Text.Trim());
        double energyrate = Convert.ToDouble(txtEnergyRate.Text.Trim());
        double energy = (cap * energyrate) / caprate;
        txtEnergy.Text = energy.ToString("#,##0.00");
    }
}
