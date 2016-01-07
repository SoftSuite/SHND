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
using SHND.Data.Order;
using SHND.Data.Tables;
using SHND.Data.Views;
using SHND.Flow.Order;
using SHND.Global;

public partial class App_Order_Transaction_OrderFood_OrderFeedControl : System.Web.UI.UserControl
{
    public event EventHandler SaveClick;

    protected override void OnInit(EventArgs e)
    {
        base.OnInit(e);
        string script = "if (document.getElementById('" + this.cmbRate.ClientID + "').value == '1')" +
            "{" +
            "document.getElementById('" + this.txtEnergyRate.ClientID + "').value = '0.50'; document.getElementById('" + this.txtCapacityRate.ClientID + "').value = '1.00'; " +
            "} " +
            "else if (document.getElementById('" + this.cmbRate.ClientID + "').value == '2')" +
            "{" +
            "document.getElementById('" + this.txtEnergyRate.ClientID + "').value = '1.00'; document.getElementById('" + this.txtCapacityRate.ClientID + "').value = '1.00'; " +
            "} " +
            "else if (document.getElementById('" + this.cmbRate.ClientID + "').value == '3')" +
            "{" +
            "document.getElementById('" + this.txtEnergyRate.ClientID + "').value = '1.50'; document.getElementById('" + this.txtCapacityRate.ClientID + "').value = '1.00'; " +
            "} " +
            "else if (document.getElementById('" + this.cmbRate.ClientID + "').value == '4')" +
            "{" +
            "document.getElementById('" + this.txtEnergyRate.ClientID + "').value = '2.00'; document.getElementById('" + this.txtCapacityRate.ClientID + "').value = '1.00'; " +
            "} " +
            "if (document.getElementById('" + this.cmbRate.ClientID + "').value == '9')" +
            "{" +
            "document.getElementById('" + this.txtEnergyRate.ClientID + "').className = 'zTextboxR'; document.getElementById('" + this.txtCapacityRate.ClientID + "').className = 'zTextboxR';" +
            "document.getElementById('" + this.txtEnergyRate.ClientID + "').readOnly = false; document.getElementById('" + this.txtCapacityRate.ClientID + "').readOnly = false;" +
            "} " +
            "else" +
            "{" +
            "document.getElementById('" + this.txtEnergyRate.ClientID + "').className = 'zTextboxR-View'; document.getElementById('" + this.txtCapacityRate.ClientID + "').className = 'zTextboxR-View'; " +
            "document.getElementById('" + this.txtEnergyRate.ClientID + "').readOnly = true; document.getElementById('" + this.txtCapacityRate.ClientID + "').readOnly = true;" +
            "} ";
        this.cmbRate.Attributes.Add("onchange", script);
        ControlUtil.SetDblTextBox(this.txtEnergyRate);
        ControlUtil.SetDblTextBox(this.txtCapacityRate);
        ControlUtil.SetDblTextBox(this.txtEnergy);
        ControlUtil.SetDblTextBox(this.txtCapacity);
        Appz.BuildCombo(this.cmbMealQty, "STDTIMETABLE", "MEALQTY", "MEALQTY", "USEFOR='F'", "MEALQTY", "เลือก", "0", true);
        script = "var qty = 0; " +
            "qty = (document.getElementById('" + this.chkTime01.ClientID + "').checked ? 1 : 0) + (document.getElementById('" + this.chkTime02.ClientID + "').checked ? 1 : 0) + " +
            "(document.getElementById('" + this.chkTime03.ClientID + "').checked ? 1 : 0) + (document.getElementById('" + this.chkTime04.ClientID + "').checked ? 1 : 0) + " +
            "(document.getElementById('" + this.chkTime05.ClientID + "').checked ? 1 : 0) + (document.getElementById('" + this.chkTime06.ClientID + "').checked ? 1 : 0) + " +
            "(document.getElementById('" + this.chkTime07.ClientID + "').checked ? 1 : 0) + (document.getElementById('" + this.chkTime08.ClientID + "').checked ? 1 : 0) + " +
            "(document.getElementById('" + this.chkTime09.ClientID + "').checked ? 1 : 0) + (document.getElementById('" + this.chkTime10.ClientID + "').checked ? 1 : 0) + " +
            "(document.getElementById('" + this.chkTime11.ClientID + "').checked ? 1 : 0) + (document.getElementById('" + this.chkTime12.ClientID + "').checked ? 1 : 0) + " +
            "(document.getElementById('" + this.chkTime13.ClientID + "').checked ? 1 : 0) + (document.getElementById('" + this.chkTime14.ClientID + "').checked ? 1 : 0) + " +
            "(document.getElementById('" + this.chkTime15.ClientID + "').checked ? 1 : 0) + (document.getElementById('" + this.chkTime16.ClientID + "').checked ? 1 : 0) + " +
            "(document.getElementById('" + this.chkTime17.ClientID + "').checked ? 1 : 0) + (document.getElementById('" + this.chkTime18.ClientID + "').checked ? 1 : 0) + " +
            "(document.getElementById('" + this.chkTime19.ClientID + "').checked ? 1 : 0) + (document.getElementById('" + this.chkTime20.ClientID + "').checked ? 1 : 0) + " +
            "(document.getElementById('" + this.chkTime21.ClientID + "').checked ? 1 : 0) + (document.getElementById('" + this.chkTime22.ClientID + "').checked ? 1 : 0) + " +
            "(document.getElementById('" + this.chkTime23.ClientID + "').checked ? 1 : 0) + (document.getElementById('" + this.chkTime24.ClientID + "').checked ? 1 : 0);" +
            "if (parseFloat(document.getElementById('" + this.txtCapacityRate.ClientID + "').value) == 0 || qty == 0)" +
            "{ document.getElementById('" + this.txtEnergy.ClientID + "').value = '0.00';document.getElementById('" + this.txtEnergyTotal.ClientID + "').value = '0.00'; }" +
            "else" +
            "{ " +
            "document.getElementById('" + this.txtEnergy.ClientID + "').value = parseFloat(document.getElementById('" + this.txtCapacity.ClientID + "').value) * parseFloat(document.getElementById('" + this.txtEnergyRate.ClientID + "').value)/parseFloat(document.getElementById('" + this.txtCapacityRate.ClientID + "').value);" +
            "document.getElementById('" + this.txtEnergyTotal.ClientID + "').value = parseFloat(document.getElementById('" + this.txtCapacity.ClientID + "').value) * parseFloat(document.getElementById('" + this.txtEnergyRate.ClientID + "').value)*qty/parseFloat(document.getElementById('" + this.txtCapacityRate.ClientID + "').value);" +
            "valDbl(document.getElementById('" + this.txtEnergy.ClientID + "'));valDbl(document.getElementById('" + this.txtEnergyTotal.ClientID + "'));" +
            "} return false;";
        this.tbCalculateEnergy.ClientClick = script;
        this.imbTime.OnClientClick = "if (document.getElementById('" + this.cmbMealQty.ClientID + "').value == '0') { alert('" + string.Format(DataResources.MSGEI002, "จำนวนมื้อ") + "'); return false; }";
        this.imbAdd.OnClientClick = "if (!document.getElementById('" + this.chkIsIncrease.ClientID + "').checked && " +
            "!document.getElementById('" + this.chkIsLimit.ClientID + "').checked && !document.getElementById('" + this.chkIsSpecific.ClientID + "').checked) " +
            "{ alert('" + string.Format(DataResources.MSGEI002, "เงื่อนไขสารอาหาร") + "'); return false; }";
    }

    protected void Page_Load(object sender, EventArgs e)
    {
        if (IsPostBack) SetRate();
    }

    protected void ctlDiseaseCategory_SelectedIndexChanged(object sender, EventArgs e, ArrayList arrData)
    {
        InsertDiseaseCategory(arrData);
    }

    protected void cmbFeedCategory_SelectedIndexChanged(object sender, EventArgs e)
    {
        SetFormulaFeed();
        SetReqType();
    }

    #region Button Click Event Handler

    #region Main Toolbar
    protected void tbSaveClick(object sender, EventArgs e)
    {
        if (SaveData()) { if (SaveClick != null) SaveClick(sender, e); }
    }
    protected void tbCancelClick(object sender, EventArgs e)
    {
        GetDetail(Convert.ToDouble("0" + this.txtLOID.Text), false);
        this.popupOrder.Show();
    }
    protected void tbDiscontinueClick(object sender, EventArgs e)
    {
        if (DisContinue()) { if (SaveClick != null) SaveClick(sender, e); }
    }
    #endregion

    protected void imbAdd_Click(object sender, ImageClickEventArgs e)
    {
        string diseaseCategoryList = "";
        for (int i = 0; i < this.gvMain.Rows.Count; ++i)
        {
            diseaseCategoryList += (diseaseCategoryList == "" ? "" : ",") + this.gvMain.Rows[i].Cells[0].Text;
        }
        OrderFoodFlow fFlow = new OrderFoodFlow();
        this.ctlDiseaseCategory.Show(this.chkIsSpecific.Checked, this.chkIsIncrease.Checked, this.chkIsLimit.Checked, false, fFlow.GetLiquidCategory(), diseaseCategoryList);
    }

    protected void imbTime_Click(object sender, EventArgs e)
    {
        GetStdTime();
    }

    #endregion

    #region Gridview Event Handler

    protected void gvMain_RowCommand(object sender, GridViewCommandEventArgs e)
    {
        this.popupOrder.Show();
    }

    protected void gvMain_RowDeleted(object sender, GridViewDeletedEventArgs e)
    {
        this.gvMain.DataBind();
        CheckConstraint();
    }

    #endregion

    #region Controls Management Methods

    private void SetFormulaFeed()
    {
        if (this.cmbFeedCategory.SelectedItem.Value == "C")
//            Appz.BuildCombo(this.cmbFormulaFeed, "V_FORMULAFEED", "NAME", "MATERIALMASTER", "ACTIVE='1' AND FEEDCATEGORY = '" + this.cmbFeedCategory.SelectedItem.Value + "' AND MATERIALMASTER IS NOT NULL", "NAME", "เลือก", "0", false);
            Appz.BuildCombo(this.cmbFormulaFeed, "V_MATERIALFEED", "NAME", "LOID", "FEEDCATEGORY = 'C'", "NAME", "เลือก", "0", false);
        else
            Appz.BuildCombo(this.cmbFormulaFeed, "V_FORMULAFEED", "NAME", "LOID", "ACTIVE='1' AND FEEDCATEGORY = '" + this.cmbFeedCategory.SelectedItem.Value + "'", "NAME", "เลือก", "0", false);
        this.popupOrder.Show();
    }
    private void SetReqType()
    {
        if (cmbFeedCategory.SelectedItem.Value == "C")
        {
            rdoReqBag.Enabled = true;
            rdoReqCan.Enabled = true;
        }
        else
        {
            rdoReqBag.Enabled = false;
            rdoReqCan.Enabled = false;
        }
        rdoReqBag.Checked = true;
        rdoReqCan.Checked = false;
    }

    private void SetStatus(string t, bool isError)
    {
        this.lbStatus.Text = t;
        this.lbStatus.ForeColor = (isError ? Constant.StatusColor.Error : Constant.StatusColor.Information);
    }

    public void Show(double admitPatientID, double loid, bool isView, bool isCopy, double ward)
    {
        this.txtIsView.Text = (isView ? "1" : "0");
        this.txtAdmitPatient.Text = admitPatientID.ToString();
        this.txtLOID.Text = loid.ToString();
        this.txtWard.Text = ward.ToString();
        GetDetail(loid, isCopy);
        this.popupOrder.Show();
    }

    private void SetRate()
    {
        if (this.cmbRate.Enabled)
        {
            this.txtEnergyRate.CssClass = ((this.cmbRate.SelectedIndex != 4) ? "zTextboxR-View" : "zTextboxR");
            this.txtEnergyRate.Attributes.Add("readonly", ((this.cmbRate.SelectedIndex != 4) ? "readonly" : ""));
            this.txtCapacityRate.CssClass = ((this.cmbRate.SelectedIndex != 4) ? "zTextboxR-View" : "zTextboxR");
            this.txtCapacityRate.Attributes.Add("readonly", ((this.cmbRate.SelectedIndex != 4) ? "readonly" : ""));
        }
    }

    private void SetView(bool isView)
    {
        this.cmbFeedCategory.Enabled = !isView;
        this.cmbFormulaFeed.Enabled = !isView;
        this.rdoMethodM.Enabled = !isView;
        this.rdoMethodT.Enabled = !isView;
        this.cmbRate.Enabled = !isView;
        this.txtEnergyRate.CssClass = (isView ? "zTextboxR-View" : "zTextboxR");
        this.txtEnergyRate.Attributes.Add("readonly", (isView ? "readonly" : ""));
        this.txtCapacityRate.CssClass = (isView ? "zTextboxR-View" : "zTextboxR");
        this.txtCapacityRate.Attributes.Add("readonly", (isView ? "readonly" : ""));
        this.txtCapacity.CssClass = (isView ? "zTextboxR-View" : "zTextboxR");
        if (isView)
            this.txtCapacity.Attributes.Add("readonly", "readonly");
        else
            this.txtCapacity.Attributes.Remove("readonly");
        this.cmbMealQty.Enabled = !isView;
       // this.imbTime.Visible = !isView;
        this.chkTime01.Enabled = !isView;
        this.chkTime02.Enabled = !isView;
        this.chkTime03.Enabled = !isView;
        this.chkTime04.Enabled = !isView;
        this.chkTime05.Enabled = !isView;
        this.chkTime06.Enabled = !isView;
        this.chkTime07.Enabled = !isView;
        this.chkTime08.Enabled = !isView;
        this.chkTime09.Enabled = !isView;
        this.chkTime10.Enabled = !isView;
        this.chkTime11.Enabled = !isView;
        this.chkTime12.Enabled = !isView;
        this.chkTime13.Enabled = !isView;
        this.chkTime14.Enabled = !isView;
        this.chkTime15.Enabled = !isView;
        this.chkTime16.Enabled = !isView;
        this.chkTime17.Enabled = !isView;
        this.chkTime18.Enabled = !isView;
        this.chkTime19.Enabled = !isView;
        this.chkTime20.Enabled = !isView;
        this.chkTime21.Enabled = !isView;
        this.chkTime22.Enabled = !isView;
        this.chkTime23.Enabled = !isView;
        this.chkTime24.Enabled = !isView;
        this.tbCalculateEnergy.Visible = !isView;
        this.ctlFirstDate.Enabled = !isView;
        this.cmbFirstTime.Enabled = !isView;
        this.chkIsIncrease.Enabled = !isView;
        this.chkIsLimit.Enabled = !isView;
        this.chkIsSpecific.Enabled = !isView;
        this.txtRemarks.CssClass = (isView ? "zTextbox-View" : "zTextbox");
        this.txtRemarks.ReadOnly = isView;
        this.imbAdd.Visible = !isView;
    }

    private void SetData(OrderMedicalFeedData oData, bool isCopy)
    {
        this.txtEnergy.Attributes.Add("readonly", "readonly");
        bool pageAuthorized = (this.txtIsView.Text == "0");
        this.txtCapacity.Text = oData.CAPACITY.ToString(Constant.DoubleFormat);
        if (oData.LOID == 0)
        {
            oData.CAPACITYRATE = 1;
            oData.ENERGYRATE = 0.5;
        }
        this.txtCapacityRate.Text = oData.CAPACITYRATE.ToString(Constant.DoubleFormat);
        if (oData.EATMETHOD == "M")
        {
            this.rdoMethodM.Checked = true;
            this.rdoMethodT.Checked = false;
        }
        else
        {
            this.rdoMethodM.Checked = false;
            this.rdoMethodT.Checked = true;
        }
        this.ctlEndDate.DateValue = oData.ENDDATE;
        this.cmbEndTime.SelectedIndex = this.cmbEndTime.Items.IndexOf(this.cmbEndTime.Items.FindByValue(oData.ENDTIME));
        this.txtEnergy.Text = oData.ENERGY.ToString(Constant.DoubleFormat);
        this.txtEnergyRate.Text = oData.ENERGYRATE.ToString(Constant.DoubleFormat);
        this.cmbFeedCategory.SelectedIndex = this.cmbFeedCategory.Items.IndexOf(this.cmbFeedCategory.Items.FindByValue(oData.FEEDCATEGORY));
        SetFormulaFeed();
        this.ctlFirstDate.DateValue = oData.FIRSTDATE;
        this.ctlFirstDateRegis.DateValue = oData.FIRSTDATEREGIS;
        this.txtFirstTimeRegis.Text = oData.FIRSTMEALREGIS;
        this.cmbFirstTime.SelectedIndex = this.cmbFirstTime.Items.IndexOf(this.cmbFirstTime.Items.FindByValue(oData.FIRSTTIME));
        SetReqType();
        if (oData.FEEDCATEGORY == "C")
            this.cmbFormulaFeed.SelectedIndex = this.cmbFormulaFeed.Items.IndexOf(this.cmbFormulaFeed.Items.FindByValue(oData.MATERIALMASTER.ToString()));
        else
            this.cmbFormulaFeed.SelectedIndex = this.cmbFormulaFeed.Items.IndexOf(this.cmbFormulaFeed.Items.FindByValue(oData.FORMULAFEED.ToString()));

        if (oData.REQTYPE == "B")
        {
            rdoReqBag.Checked = true;
            rdoReqCan.Checked = false;
        }
        else
        {
            rdoReqBag.Checked = false;
            rdoReqCan.Checked = true;
        }

        this.chkIsIncrease.Checked = oData.ISINCREASE;
        this.chkIsLimit.Checked = oData.ISLIMIT;
        this.chkIsSpecific.Checked = oData.ISSPECIFIC;
        this.txtRemarks.Text = oData.REMARKS;
        this.txtStatus.Text = oData.STATUS;
        this.chkTime01.Checked = oData.TIME1;
        this.chkTime02.Checked = oData.TIME2;
        this.chkTime03.Checked = oData.TIME3;
        this.chkTime04.Checked = oData.TIME4;
        this.chkTime05.Checked = oData.TIME5;
        this.chkTime06.Checked = oData.TIME6;
        this.chkTime07.Checked = oData.TIME7;
        this.chkTime08.Checked = oData.TIME8;
        this.chkTime09.Checked = oData.TIME9;
        this.chkTime10.Checked = oData.TIME10;
        this.chkTime11.Checked = oData.TIME11;
        this.chkTime12.Checked = oData.TIME12;
        this.chkTime13.Checked = oData.TIME13;
        this.chkTime14.Checked = oData.TIME14;
        this.chkTime15.Checked = oData.TIME15;
        this.chkTime16.Checked = oData.TIME16;
        this.chkTime17.Checked = oData.TIME17;
        this.chkTime18.Checked = oData.TIME18;
        this.chkTime19.Checked = oData.TIME19;
        this.chkTime20.Checked = oData.TIME20;
        this.chkTime21.Checked = oData.TIME21;
        this.chkTime22.Checked = oData.TIME22;
        this.chkTime23.Checked = oData.TIME23;
        this.chkTime24.Checked = oData.TIME24;
        if (oData.ENERGYRATE == 0.5 && oData.CAPACITYRATE == 1)
            this.cmbRate.SelectedIndex = 0;
        else if (oData.ENERGYRATE == 1 && oData.CAPACITYRATE == 1)
            this.cmbRate.SelectedIndex = 1;
        else if (oData.ENERGYRATE == 1.5 && oData.CAPACITYRATE == 1)
            this.cmbRate.SelectedIndex = 2;
        else if (oData.ENERGYRATE == 2 && oData.CAPACITYRATE == 1)
            this.cmbRate.SelectedIndex = 3;

        double qty = 0;
        if (oData.TIME1) qty = qty + 1;
        if (oData.TIME2) qty = qty + 1;
        if (oData.TIME3) qty = qty + 1;
        if (oData.TIME4) qty = qty + 1;
        if (oData.TIME5) qty = qty + 1;
        if (oData.TIME6) qty = qty + 1;
        if (oData.TIME7) qty = qty + 1;
        if (oData.TIME8) qty = qty + 1;
        if (oData.TIME9) qty = qty + 1;
        if (oData.TIME10) qty = qty + 1;
        if (oData.TIME11) qty = qty + 1;
        if (oData.TIME12) qty = qty + 1;
        if (oData.TIME13) qty = qty + 1;
        if (oData.TIME14) qty = qty + 1;
        if (oData.TIME15) qty = qty + 1;
        if (oData.TIME16) qty = qty + 1;
        if (oData.TIME17) qty = qty + 1;
        if (oData.TIME18) qty = qty + 1;
        if (oData.TIME19) qty = qty + 1;
        if (oData.TIME20) qty = qty + 1;
        if (oData.TIME21) qty = qty + 1;
        if (oData.TIME22) qty = qty + 1;
        if (oData.TIME23) qty = qty + 1;
        if (oData.TIME24) qty = qty + 1;
        this.cmbMealQty.SelectedValue = qty.ToString();
        this.txtEnergyTotal.Text = (oData.ENERGY * qty).ToString(Constant.DoubleFormat);

        OrderFoodDetailItem item = new OrderFoodDetailItem();
        item.ClearAllSession();
        this.gvMain.DataBind();

        if (isCopy)
        {
            this.txtLOID.Text = "";
            oData.LOID = 0;
            oData.STATUS = "";
        }
        SetView(oData.STATUS == "RG" || oData.STATUS == "DC" || !pageAuthorized);
        CheckConstraint();
        SetRate();

        this.tbDiscontinue.Visible = (oData.STATUS == "RG");//(pageAuthorized && oData.LOID  != 0);
        this.tbSave.Visible = (oData.STATUS != "RG" && oData.STATUS != "DC" && pageAuthorized);
        this.tbCancel.Visible = (oData.STATUS != "RG" && oData.STATUS != "DC" && pageAuthorized);
        this.gvMain.Columns[1].Visible = (oData.STATUS != "RG" && oData.STATUS != "DC" && pageAuthorized);
        this.ctlEndDate.Enabled = pageAuthorized;
        this.cmbEndTime.Enabled = pageAuthorized;
    }

    private OrderMedicalFeedData GetData()
    {
        OrderMedicalFeedData oData = new OrderMedicalFeedData();
        oData.ADMITPATIENT = Convert.ToDouble("0" + this.txtAdmitPatient.Text);
        oData.CAPACITY = Convert.ToDouble("0" + this.txtCapacity.Text);
        oData.CAPACITYRATE = Convert.ToDouble("0" + this.txtCapacityRate.Text);
        oData.EATMETHOD = (rdoMethodM.Checked ? "M" : "T");
        oData.ENDDATE = this.ctlEndDate.DateValue;
        oData.ENDTIME = this.cmbEndTime.SelectedItem.Value;
        oData.ENERGYRATE = Convert.ToDouble("0" + this.txtEnergyRate.Text);
        oData.ENERGY = Convert.ToDouble("0" + this.txtEnergy.Text);
        oData.FEEDCATEGORY = this.cmbFeedCategory.SelectedItem.Value;
        oData.FIRSTDATE = this.ctlFirstDate.DateValue;
        oData.FIRSTTIME = this.cmbFirstTime.SelectedItem.Value;
        oData.FIRSTDATEREGIS = this.ctlFirstDateRegis.DateValue;
        oData.FIRSTMEALREGIS = this.txtFirstTimeRegis.Text;
        if (oData.FEEDCATEGORY == "C")
        {
            oData.MATERIALMASTER = Convert.ToDouble(this.cmbFormulaFeed.SelectedItem.Value);
            oData.REQTYPE = (rdoReqBag.Checked ? "B" : "C");
        }
        else
        {
            oData.FORMULAFEED = Convert.ToDouble(this.cmbFormulaFeed.SelectedItem.Value);
            oData.REQTYPE = "B";
        }
        oData.ISCALCULATE = false;
        oData.ISINCREASE = this.chkIsIncrease.Checked;
        oData.ISLIMIT = this.chkIsLimit.Checked;
        oData.ISSPECIFIC = this.chkIsSpecific.Checked;
        oData.LOID = Convert.ToDouble("0" + this.txtLOID.Text);
        oData.ORDERBY = Appz.LoggedOnUser.LOID;
        oData.REMARKS = this.txtRemarks.Text.Trim();
        oData.STATUS = this.txtStatus.Text.Trim();
        oData.TIME1 = this.chkTime01.Checked;
        oData.TIME2 = this.chkTime02.Checked;
        oData.TIME3 = this.chkTime03.Checked;
        oData.TIME4 = this.chkTime04.Checked;
        oData.TIME5 = this.chkTime05.Checked;
        oData.TIME6 = this.chkTime06.Checked;
        oData.TIME7 = this.chkTime07.Checked;
        oData.TIME8 = this.chkTime08.Checked;
        oData.TIME9 = this.chkTime09.Checked;
        oData.TIME10 = this.chkTime10.Checked;
        oData.TIME11 = this.chkTime11.Checked;
        oData.TIME12 = this.chkTime12.Checked;
        oData.TIME13 = this.chkTime13.Checked;
        oData.TIME14 = this.chkTime14.Checked;
        oData.TIME15 = this.chkTime15.Checked;
        oData.TIME16 = this.chkTime16.Checked;
        oData.TIME17 = this.chkTime17.Checked;
        oData.TIME18 = this.chkTime18.Checked;
        oData.TIME19 = this.chkTime19.Checked;
        oData.TIME20 = this.chkTime20.Checked;
        oData.TIME21 = this.chkTime21.Checked;
        oData.TIME22 = this.chkTime22.Checked;
        oData.TIME23 = this.chkTime23.Checked;
        oData.TIME24 = this.chkTime24.Checked;

        OrderFoodDetailItem item = new OrderFoodDetailItem();
        oData.ORDERITEMLIST = item.GetOrderItemList();
        return oData;
    }

    private void SetStdTime(StdTimeTableData sData)
    {
        this.chkTime01.Checked = sData.TIME1;
        this.chkTime02.Checked = sData.TIME2;
        this.chkTime03.Checked = sData.TIME3;
        this.chkTime04.Checked = sData.TIME4;
        this.chkTime05.Checked = sData.TIME5;
        this.chkTime06.Checked = sData.TIME6;
        this.chkTime07.Checked = sData.TIME7;
        this.chkTime08.Checked = sData.TIME8;
        this.chkTime09.Checked = sData.TIME9;
        this.chkTime10.Checked = sData.TIME10;
        this.chkTime11.Checked = sData.TIME11;
        this.chkTime12.Checked = sData.TIME12;
        this.chkTime13.Checked = sData.TIME13;
        this.chkTime14.Checked = sData.TIME14;
        this.chkTime15.Checked = sData.TIME15;
        this.chkTime16.Checked = sData.TIME16;
        this.chkTime17.Checked = sData.TIME17;
        this.chkTime18.Checked = sData.TIME18;
        this.chkTime19.Checked = sData.TIME19;
        this.chkTime20.Checked = sData.TIME20;
        this.chkTime21.Checked = sData.TIME21;
        this.chkTime22.Checked = sData.TIME22;
        this.chkTime23.Checked = sData.TIME23;
        this.chkTime24.Checked = sData.TIME24;
    }

    #endregion

    #region Working Method

    private void CheckConstraint()
    {
        bool enabled = (this.gvMain.Rows.Count == 0) && this.imbAdd.Visible;
        this.chkIsIncrease.Enabled = enabled;
        this.chkIsLimit.Enabled = enabled;
        this.chkIsSpecific.Enabled = enabled;
    }

    private void InsertDiseaseCategory(ArrayList arrData)
    {
        OrderFoodDetailItem item = new OrderFoodDetailItem();
        if (item.InsertDiseaseCategory(Convert.ToDouble("0" + this.txtLOID.Text), "ORDERMEDICALFEED", arrData))
        {
            this.gvMain.DataBind();
            CheckConstraint();
            this.popupOrder.Show();
        }
    }

    private void GetStdTime()
    {
        if (this.cmbMealQty.SelectedItem.Value != "0")
        {
            OrderFoodFlow ftFlow = new OrderFoodFlow();
            SetStdTime(ftFlow.GetStdTimeTable(Convert.ToDouble(this.cmbMealQty.SelectedItem.Value), "F"));
            this.popupOrder.Show();
        }
    }

    private void GetDetail(double ID, bool isCopy)
    {
        OrderFoodFlow oFlow = new OrderFoodFlow();
        SetData(oFlow.GetOrderMedicalFeed(ID), isCopy);
    }

    private bool SaveData()
    {
        bool ret = true;
        OrderFoodFlow ftFlow = new OrderFoodFlow();
        OrderMedicalFeedData oData = GetData();
        oData.STATUS = "FN";
        string error = ValidateData(oData);
        if (error == "") { if (ftFlow.HasNPOOrder(oData.LOID, oData.ADMITPATIENT, null)) error = ftFlow.ErrorMessage; }
        if (error != "")
        {
            SetStatus(error, true);
            this.popupOrder.Show();
            return false;
        }

        if (oData.LOID == 0)
            ret = ftFlow.InsertOrderMedicalFeed(oData, Appz.CurrentUser);
        else
            ret = ftFlow.UpdateOrderMedicalFeed(oData, Appz.CurrentUser);

        if (!ret)
        {
            SetStatus(ftFlow.ErrorMessage, true);
            this.popupOrder.Show();
        }
        else
        {
            txtLOID.Text = ftFlow.LOID.ToString();
            //GetDetail(ftFlow.LOID, false);
            if (ftFlow.CheckANWard(Convert.ToDouble(txtWard.Text), oData.ADMITPATIENT, null))
            {
                error = ftFlow.ErrorMessage;
                SetStatus(error, false);
                this.popupOrder.Show();
            }
        }
        return ret;
    }

    private bool DisContinue()
    {
        bool ret = true;
        OrderFoodFlow ftFlow = new OrderFoodFlow();
        OrderMedicalFeedData oData = GetData();
        string meal = "";

        if (oData.ENDDATE.Year == 1 || oData.ENDTIME == "")
        {
            SetStatus(string.Format(DataResources.MSGEI002, "วันที่และเวลาที่สิ้นสุด"), true);
            this.popupOrder.Show();
            return false;
        }
        else
        {
            meal = ftFlow.GetMeal("F", oData.ENDTIME);
            if (oData.ENDDATE < oData.FIRSTDATEREGIS || (oData.ENDDATE == oData.FIRSTDATEREGIS & Convert.ToDouble(meal) <= Convert.ToDouble(oData.FIRSTMEALREGIS)))
            {
                SetStatus("ไม่สามารถ Discontinue การสั่งอาหารในมื้อที่ Register แล้วได้", true);
                this.popupOrder.Show();
                return false;
            }
        }

        if (oData.LOID != 0)
            ret = ftFlow.DiscontinueOrderMedicalFeed(oData.LOID, Appz.CurrentUser, oData.ENDDATE, oData.ENDTIME);

        if (!ret)
        {
            SetStatus(ftFlow.ErrorMessage, true);
            this.popupOrder.Show();
        }
        return ret;
    }

    private string ValidateData(OrderMedicalFeedData oData)
    {
        string error = "";
        string isLock = "";
        int time = 0;
        double qty = 0;
        if (oData.TIME1) qty = qty + 1;
        if (oData.TIME2) qty = qty + 1;
        if (oData.TIME3) qty = qty + 1;
        if (oData.TIME4) qty = qty + 1;
        if (oData.TIME5) qty = qty + 1;
        if (oData.TIME6) qty = qty + 1;
        if (oData.TIME7) qty = qty + 1;
        if (oData.TIME8) qty = qty + 1;
        if (oData.TIME9) qty = qty + 1;
        if (oData.TIME10) qty = qty + 1;
        if (oData.TIME11) qty = qty + 1;
        if (oData.TIME12) qty = qty + 1;
        if (oData.TIME13) qty = qty + 1;
        if (oData.TIME14) qty = qty + 1;
        if (oData.TIME15) qty = qty + 1;
        if (oData.TIME16) qty = qty + 1;
        if (oData.TIME17) qty = qty + 1;
        if (oData.TIME18) qty = qty + 1;
        if (oData.TIME19) qty = qty + 1;
        if (oData.TIME20) qty = qty + 1;
        if (oData.TIME21) qty = qty + 1;
        if (oData.TIME22) qty = qty + 1;
        if (oData.TIME23) qty = qty + 1;
        if (oData.TIME24) qty = qty + 1;

        OrderFoodFlow ftFlow = new OrderFoodFlow();
        isLock = ftFlow.GetIsLock(Convert.ToDouble("0" + txtWard.Text));

        if (oData.FEEDCATEGORY == "C" && oData.MATERIALMASTER == 0)
            error = string.Format(DataResources.MSGEI002, "ชื่ออาหาร");
        else if (oData.CAPACITY == 0)
            error = string.Format(DataResources.MSGEI002, "ปริมาณต่อถุง");
        else if (qty == 0)
            error = string.Format(DataResources.MSGEI002, "เวลา");
        else if (this.cmbMealQty.SelectedValue != qty.ToString())
            error = string.Format(DataResources.MSGEI002, "เวลาที่เลือกไม่ตรงกับจำนวนมื้อ");
        else if (oData.FIRSTDATE.Year == 1 || oData.FIRSTTIME == "")
            error = string.Format(DataResources.MSGEI002, "วันที่และเวลาที่เริ่มต้น");

        else if (isLock == "Y")
        {
            string cuttime = "";
            cuttime = ftFlow.GetCutOffTimeFM("F", oData.FIRSTTIME);
            time = int.Parse(cuttime.Replace(":", ""));

            if (oData.FIRSTDATE < DateTime.Today)
                error = "ไม่สามารถสั่งอาหารหลังเวลา cut of time ได้";
            else if (oData.FIRSTDATE == DateTime.Today & time < int.Parse(DateTime.Now.ToString("HHmm")))
                error = "ไม่สามารถสั่งอาหารหลังเวลา cut of time ได้";
        }

        return error;
    }

    #endregion

    protected void cmbMealQty_SelectedIndexChanged(object sender, EventArgs e)
    {
        GetStdTime();
    }
}
