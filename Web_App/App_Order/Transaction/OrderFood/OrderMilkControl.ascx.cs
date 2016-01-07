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

public partial class App_Order_Transaction_OrderFood_OrderMilkControl : System.Web.UI.UserControl
{
    public event EventHandler SaveClick;

    protected override void OnInit(EventArgs e)
    {
        base.OnInit(e);
        string script = "";
        script = "" +
            //"if (document.getElementById('" + this.rdoOwnerS.ClientID + "').disabled = '') {" +
            "if (document.getElementById('" + this.rdoOwnerS.ClientID + "').checked)" +
            "{ document.getElementById('" + this.cmbMilkCategory.ClientID + "').disabled = ''; document.getElementById('" + this.txtOwnerText.ClientID + "').className = 'zTextbox-View'; " +
            "document.getElementById('" + this.txtOwnerText.ClientID + "').readOnly = true; document.getElementById('" + this.txtOwnerText.ClientID + "').value = '';" +
            "} else { document.getElementById('" + this.cmbMilkCategory.ClientID + "').disabled = 'disabled'; document.getElementById('" + this.txtOwnerText.ClientID + "').className = 'zTextbox'; " +
            "document.getElementById('" + this.txtOwnerText.ClientID + "').readOnly = false; document.getElementById('" + this.cmbMilkCategory.ClientID + "').value = '0';" +
            //"}" +
            "}";
        this.rdoOwnerM.Attributes.Add("onClick", script);
        this.rdoOwnerS.Attributes.Add("onClick", script);
        ControlUtil.SetDblTextBox(this.txtEnergy);
        ControlUtil.SetDblTextBox(this.txtVolumn);
        Appz.BuildCombo(this.cmbMilkCategory, "MILKCATEGORY", "NAME", "LOID", "ACTIVE = '1'", "NAME", "เลือก", "0", true);
        Appz.BuildCombo(this.cmbMealQty, "STDTIMETABLE", "MEALQTY", "MEALQTY", "USEFOR='M'", "MEALQTY", "เลือก", "0", true);
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
            "document.getElementById('" + this.txtEnergyTotal.ClientID + "').value = parseFloat(document.getElementById('" + this.txtVolumn.ClientID + "').value)*" +
            "parseFloat(document.getElementById('" + this.txtEnergy.ClientID + "').value)*qty/30;" +
            "if (document.getElementById('" + this.txtWeight.ClientID + "').value == 0)" +
            "{ document.getElementById('" + this.txtEnergyMeal.ClientID + "').value = '0'; }" +
            "else" +
            "{ " +
            "document.getElementById('" + this.txtEnergyMeal.ClientID + "').value = parseFloat(document.getElementById('" + this.txtVolumn.ClientID + "').value)*" +
            "parseFloat(document.getElementById('" + this.txtEnergy.ClientID + "').value)*qty/(30*parseFloat(document.getElementById('" + this.txtWeight.ClientID + "').value));" +
            "valDbl(document.getElementById('" + this.txtEnergyTotal.ClientID + "'));valDbl(document.getElementById('" + this.txtEnergyMeal.ClientID + "'));} return false;";
        this.tbCalculateEnergy.ClientClick = script;
        this.imbTime.OnClientClick = "if (document.getElementById('" + this.cmbMealQty.ClientID + "').value == '0') { alert('" + string.Format(DataResources.MSGEI002, "จำนวนมื้อ") + "'); return false; }";
    }

    protected void Page_Load(object sender, EventArgs e)
    {
        if (IsPostBack) SetOwner();
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

    protected void imbTime_Click(object sender, EventArgs e)
    {
        GetStdTime();
    }
    protected void cmbMealQty_SelectedIndexChanged(object sender, EventArgs e)
    {
        if (this.cmbMealQty.SelectedItem.Value != "0")
        {
            GetStdTime();
        }
        else
        {
            this.chkTime01.Checked = false;
            this.chkTime02.Checked = false;
            this.chkTime03.Checked = false;
            this.chkTime04.Checked = false;
            this.chkTime05.Checked = false;
            this.chkTime06.Checked = false;
            this.chkTime07.Checked = false;
            this.chkTime08.Checked = false;
            this.chkTime09.Checked = false;
            this.chkTime10.Checked = false;
            this.chkTime11.Checked = false;
            this.chkTime12.Checked = false;
            this.chkTime13.Checked = false;
            this.chkTime14.Checked = false;
            this.chkTime15.Checked = false;
            this.chkTime16.Checked = false;
            this.chkTime17.Checked = false;
            this.chkTime18.Checked = false;
            this.chkTime19.Checked = false;
            this.chkTime20.Checked = false;
            this.chkTime21.Checked = false;
            this.chkTime22.Checked = false;
            this.chkTime23.Checked = false;
            this.chkTime24.Checked = false;
            this.popupOrder.Show();
        }
    }

    #endregion

    #region Gridview Event Handler

    protected void gvMain_RowDataBound(object sender, GridViewRowEventArgs e)
    {
        if (e.Row.RowType == DataControlRowType.DataRow)
        {
            TextBox txtQty = (TextBox)e.Row.Cells[3].FindControl("txtQty");
            ControlUtil.SetDblTextBox(txtQty);
            txtQty.CssClass = ((this.txtIsView.Text == "1") ? "zTextboxR-View" : "zTextboxR");
            txtQty.ReadOnly = (this.txtIsView.Text == "1");
        }
    }

    #endregion

    #region Controls Management Methods

    private void SetStatus(string t, bool isError)
    {
        this.lbStatus.Text = t;
        this.lbStatus.ForeColor = (isError ? Constant.StatusColor.Error : Constant.StatusColor.Information);
    }

    public void Show(double admitPatientID, double loid, bool isView, bool isCopy, double ward,bool IsDoctor)
    {
        this.txtIsView.Text = (isView ? "1" : "0");
        this.txtIsDoctor.Text = (IsDoctor ? "1" : "0");
        this.txtAdmitPatient.Text = admitPatientID.ToString();
        this.txtLOID.Text = loid.ToString();
        this.txtWard.Text = ward.ToString();
        if (IsDoctor)
            lblHead.Text = "อาหารที่แพทย์สั่ง";
        else
            lblHead.Text = "อาหารที่พยาบาลสั่ง";
        //SetDoctor(IsDoctor);
        GetDetail(loid, isCopy);
        
        this.popupOrder.Show();
    }

    private void SetDoctor(bool IsDoctor)
    {
        this.rdoOwnerM.Enabled = IsDoctor;
        this.rdoOwnerS.Enabled = IsDoctor;
        this.cmbMilkCategory.Enabled = IsDoctor;
        this.txtOwnerText.CssClass = (IsDoctor ? "zTextbox" : "zTextbox-View");
        this.txtOwnerText.ReadOnly = !IsDoctor;
        this.cmbMealQty.Enabled = IsDoctor;
        this.txtWeight.CssClass = (IsDoctor ? "zTextboxR" : "zTextboxR-View");
        this.txtWeight.ReadOnly = !IsDoctor;
        //this.imbTime.Visible = IsDoctor;
        this.txtEnergy.CssClass = (IsDoctor ? "zTextboxR" : "zTextboxR-View");
        this.txtEnergy.ReadOnly = !IsDoctor;
        //this.chkTime01.Enabled = IsDoctor;
        //this.chkTime02.Enabled = IsDoctor;
        //this.chkTime03.Enabled = IsDoctor;
        //this.chkTime04.Enabled = IsDoctor;
        //this.chkTime05.Enabled = IsDoctor;
        //this.chkTime06.Enabled = IsDoctor;
        //this.chkTime07.Enabled = IsDoctor;
        //this.chkTime08.Enabled = IsDoctor;
        //this.chkTime09.Enabled = IsDoctor;
        //this.chkTime10.Enabled = IsDoctor;
        //this.chkTime11.Enabled = IsDoctor;
        //this.chkTime12.Enabled = IsDoctor;
        //this.chkTime13.Enabled = IsDoctor;
        //this.chkTime14.Enabled = IsDoctor;
        //this.chkTime15.Enabled = IsDoctor;
        //this.chkTime16.Enabled = IsDoctor;
        //this.chkTime17.Enabled = IsDoctor;
        //this.chkTime18.Enabled = IsDoctor;
        //this.chkTime19.Enabled = IsDoctor;
        //this.chkTime20.Enabled = IsDoctor;
        //this.chkTime21.Enabled = IsDoctor;
        //this.chkTime22.Enabled = IsDoctor;
        //this.chkTime23.Enabled = IsDoctor;
        //this.chkTime24.Enabled = IsDoctor;
        this.txtVolumn.CssClass = (IsDoctor ? "zTextboxR" : "zTextboxR-View");
        this.txtVolumn.ReadOnly = !IsDoctor;
        //this.chkIsSpin.Enabled = IsDoctor;
        //this.ctlFirstDate.Enabled = IsDoctor;
        //this.cmbFirstTime.Enabled = IsDoctor;
        //this.txtRemarks.CssClass = (IsDoctor ? "zTextbox-View" : "zTextbox");
        //this.txtRemarks.ReadOnly = IsDoctor;
        this.tbCalculateEnergy.Enabled = IsDoctor;
        lblEnergy.Visible = IsDoctor;
        lblMeal.Visible = IsDoctor;
        lblVolumn.Visible = IsDoctor;
        lblDate.Visible = !IsDoctor;

        foreach (GridViewRow row in gvMain.Rows)
        {
            TextBox txt = (TextBox)row.Cells[3].FindControl("txtQty");
            txt.CssClass = (IsDoctor ? "zTextboxR" : "zTextboxR-View");
            txt.ReadOnly = !IsDoctor;
            if (row.Cells[9].Text == "Y" & Convert.ToDouble("0" + txt.Text) > 0)
            {
                chkIsSpin.Enabled = true;
            }

        }
    }

    private void SetView(bool isView)
    {
        this.rdoOwnerM.Enabled = !isView;
        this.rdoOwnerS.Enabled = !isView;
        this.cmbMilkCategory.Enabled = !isView;
        this.txtOwnerText.CssClass = (isView ? "zTextbox-View" : "zTextbox");
        this.txtOwnerText.ReadOnly = isView;
        this.cmbMealQty.Enabled = !isView;
        //this.imbTime.Visible = !isView;
        this.txtEnergy.CssClass = (isView ? "zTextboxR-View" : "zTextboxR");
        this.txtEnergy.ReadOnly = isView;
        this.txtWeight.CssClass = (isView ? "zTextboxR-View" : "zTextboxR");
        this.txtWeight.ReadOnly = isView;
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
        this.txtVolumn.CssClass = (isView ? "zTextboxR-View" : "zTextboxR");
        this.txtVolumn.ReadOnly = isView;
        //this.chkIsSpin.Enabled = !isView;
        this.ctlFirstDate.Enabled = !isView;
        this.cmbFirstTime.Enabled = !isView;
        this.txtRemarks.CssClass = (isView ? "zTextbox-View" : "zTextbox");
        this.txtRemarks.ReadOnly = isView;
        this.tbCalculateEnergy.Visible = !isView;
    }

    private void SetOwner()
    {
        if (this.rdoOwnerM.Enabled && this.rdoOwnerS.Enabled)
        {
            this.cmbMilkCategory.Enabled = this.rdoOwnerS.Checked;
            this.txtOwnerText.CssClass = (this.rdoOwnerS.Checked ? "zTextbox-View" : "zTextbox");
            if (this.rdoOwnerS.Checked)
                this.txtOwnerText.Attributes.Add("readonly", "readonly");
            else
                this.txtOwnerText.Attributes.Remove("readonly");
        }
    }

    private void SetData(OrderMilkData oData, bool isCopy)
    {
        this.txtEnergyTotal.Attributes.Add("readonly", "readonly");
        bool pageAuthorized = (this.txtIsView.Text == "0");
        this.ctlEndDate.DateValue = oData.ENDDATE;
        this.cmbEndTime.SelectedIndex = this.cmbEndTime.Items.IndexOf(this.cmbEndTime.Items.FindByValue(oData.ENDTIME));
        this.txtEnergy.Text = oData.ENERGY.ToString(Constant.DoubleFormat);
        this.txtEnergyTotal.Text = ((oData.VOLUMN * oData.ENERGY * oData.MEALQTY) / 30).ToString(Constant.DoubleFormat);
        this.txtEnergyMeal.Text = ((oData.VOLUMN * oData.ENERGY) / 30).ToString(Constant.DoubleFormat);
        this.ctlFirstDate.DateValue = oData.FIRSTDATE;
        this.cmbFirstTime.SelectedIndex = this.cmbFirstTime.Items.IndexOf(this.cmbFirstTime.Items.FindByValue(oData.FIRSTTIME));
        this.ctlFirstDateRegis.DateValue = oData.FIRSTDATEREGIS;
        this.txtFirstTimeRegis.Text = oData.FIRSTMEALREGIS;
        this.chkIsSpin.Checked = oData.ISSPIN;
        this.cmbMealQty.SelectedIndex = this.cmbMealQty.Items.IndexOf(this.cmbMealQty.Items.FindByValue(oData.MEALQTY.ToString()));
        this.cmbMilkCategory.SelectedIndex = this.cmbMilkCategory.Items.IndexOf(this.cmbMilkCategory.Items.FindByValue(oData.MILKCATEGORY.ToString()));
        if (oData.OWNER == "M")
        {
            this.rdoOwnerM.Checked = true;
            this.rdoOwnerS.Checked = false;
        }
        else
        {
            this.rdoOwnerM.Checked = false;
            this.rdoOwnerS.Checked = true;
        }
        this.txtOwnerText.Text = oData.OWNERTEXT;
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
        this.txtVolumn.Text = oData.VOLUMN.ToString(Constant.DoubleFormat);
        OrderFoodDetailItem item = new OrderFoodDetailItem();
        item.ClearAllSession();
        this.gvMain.DataBind();

        if (isCopy)
        {
            this.txtLOID.Text = "";
            oData.LOID = 0;
            oData.STATUS = "";
        }
        //SetDoctor(txtIsDoctor.Text == "1");
        if (oData.STATUS == "RG" || oData.STATUS == "DC" || !pageAuthorized)
            SetView(true);
        else
            SetDoctor(txtIsDoctor.Text == "1");

        SetOwner();

        this.tbDiscontinue.Visible = (oData.STATUS == "RG");//(pageAuthorized && oData.LOID != 0);
        this.tbSave.Visible = (oData.STATUS != "RG" && oData.STATUS != "DC" && pageAuthorized);
        this.tbCancel.Visible = (oData.STATUS != "RG" && oData.STATUS != "DC" && pageAuthorized);
        this.ctlEndDate.Enabled = pageAuthorized;
        this.cmbEndTime.Enabled = pageAuthorized;
    }

    private ArrayList GetOrderItemList()
    {
        ArrayList arrData = new ArrayList();
        for (int i = 0; i < this.gvMain.Rows.Count; ++i)
        {
            GridViewRow gRow = this.gvMain.Rows[i];
            VOrderDetailItemData oData = new VOrderDetailItemData();
            oData.DISEASECATEGORY = Convert.ToDouble(gRow.Cells[0].Text);
            oData.ISHIGH = (gRow.Cells[5].Text == "Y");
            oData.ISLOW = (gRow.Cells[6].Text == "Y");
            oData.ISNON = (gRow.Cells[7].Text == "Y");
            oData.QTY = Convert.ToDouble("0" + ((TextBox)gRow.Cells[3].FindControl("txtQty")).Text);
            oData.UNIT = Convert.ToDouble("0" + gRow.Cells[5].Text.Replace("&nbsp;",""));
            oData.MEAL = "00";
            arrData.Add(oData);
        }
        return arrData;
    }

    private OrderMilkData GetData()
    {
        double mealQty = 0;
        OrderMilkData oData = new OrderMilkData();
        oData.ADMITPATIENT = Convert.ToDouble("0" + this.txtAdmitPatient.Text);
        oData.ENDDATE = this.ctlEndDate.DateValue;
        oData.ENDTIME = this.cmbEndTime.SelectedItem.Value;
        oData.ENERGY = Convert.ToDouble("0" + this.txtEnergy.Text);
        oData.FIRSTDATE = this.ctlFirstDate.DateValue;
        oData.FIRSTTIME = this.cmbFirstTime.SelectedItem.Value;
        oData.FIRSTDATEREGIS = this.ctlFirstDateRegis.DateValue;
        oData.FIRSTMEALREGIS = this.txtFirstTimeRegis.Text;
        oData.ISINCREASE = true;
        oData.ISSPIN = this.chkIsSpin.Checked;
        oData.WEIGHT = Convert.ToDouble("0" + this.txtWeight.Text);
        oData.LOID = Convert.ToDouble("0" + this.txtLOID.Text);
        if (this.chkTime01.Checked) mealQty += 1;
        if (this.chkTime02.Checked) mealQty += 1;
        if (this.chkTime03.Checked) mealQty += 1;
        if (this.chkTime04.Checked) mealQty += 1;
        if (this.chkTime05.Checked) mealQty += 1;
        if (this.chkTime06.Checked) mealQty += 1;
        if (this.chkTime07.Checked) mealQty += 1;
        if (this.chkTime08.Checked) mealQty += 1;
        if (this.chkTime09.Checked) mealQty += 1;
        if (this.chkTime10.Checked) mealQty += 1;
        if (this.chkTime11.Checked) mealQty += 1;
        if (this.chkTime12.Checked) mealQty += 1;
        if (this.chkTime13.Checked) mealQty += 1;
        if (this.chkTime14.Checked) mealQty += 1;
        if (this.chkTime15.Checked) mealQty += 1;
        if (this.chkTime16.Checked) mealQty += 1;
        if (this.chkTime17.Checked) mealQty += 1;
        if (this.chkTime18.Checked) mealQty += 1;
        if (this.chkTime19.Checked) mealQty += 1;
        if (this.chkTime20.Checked) mealQty += 1;
        if (this.chkTime21.Checked) mealQty += 1;
        if (this.chkTime22.Checked) mealQty += 1;
        if (this.chkTime23.Checked) mealQty += 1;
        if (this.chkTime24.Checked) mealQty += 1;
        oData.MEALQTY = mealQty;
        oData.MILKCATEGORY = Convert.ToDouble(this.cmbMilkCategory.SelectedItem.Value);
        oData.ORDERBY = Appz.LoggedOnUser.LOID;
        if (this.rdoOwnerM.Checked)
            oData.OWNER = "M";
        else
            oData.OWNER = "S";
        oData.OWNERTEXT = this.txtOwnerText.Text.Trim();
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
        oData.VOLUMN = Convert.ToDouble("0" + this.txtVolumn.Text);

        oData.ORDERITEMLIST = GetOrderItemList();
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

    protected void txtQty_TextChanged(object sender, EventArgs e)
    {
        TextBox txt = (TextBox)sender;
        Int16 rowIndex = (Int16)((GridViewRow)txt.Parent.Parent).RowIndex;

        if (Convert.ToDouble("0" + txt.Text) > 0)
        {
            if (this.gvMain.Rows[rowIndex].Cells[9].Text == "Y")
            {
                chkIsSpin.Enabled = true;
            }
        }
        else
        {
            chkIsSpin.Enabled = false;
            chkIsSpin.Checked = false;
            foreach (GridViewRow row in gvMain.Rows)
            {
                TextBox txtQty = (TextBox)row.Cells[3].FindControl("txtQty");
                if (row.Cells[9].Text == "Y" & Convert.ToDouble("0" + txtQty.Text) > 0)
                {
                    chkIsSpin.Enabled = true;
                    chkIsSpin.Checked = true;
                }

            }
        }
        this.popupOrder.Show();
    }

    #endregion

    #region Working Method

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
        SetData(oFlow.GetOrderMilk(ID), isCopy);
    }

    private bool SaveData()
    {
        bool ret = true;
        OrderFoodFlow ftFlow = new OrderFoodFlow();
        OrderMilkData oData = GetData();
        if(txtIsDoctor.Text == "1")
            oData.STATUS = "WA";
        else
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
            ret = ftFlow.InsertOrderMilk(oData, Appz.CurrentUser);
        else
            ret = ftFlow.UpdateOrderMilk(oData, Appz.CurrentUser);

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
        OrderMilkData oData = GetData();
        string meal = "";
        meal = ftFlow.GetMeal("M", oData.ENDTIME);
        if (oData.ENDDATE.Year == 1 || oData.ENDTIME == "")
        {
            SetStatus(string.Format(DataResources.MSGEI002, "วันที่และเวลาที่สิ้นสุด"), true);
            this.popupOrder.Show();
            return false;
        }
        else if (oData.ENDDATE < oData.FIRSTDATEREGIS || (oData.ENDDATE == oData.FIRSTDATEREGIS & Convert.ToDouble(meal) <= Convert.ToDouble(oData.FIRSTMEALREGIS)))
        {
            SetStatus("ไม่สามารถ Discontinue การสั่งอาหารในมื้อที่ Register แล้วได้", true);
            this.popupOrder.Show();
            return false;
        }

        if (oData.LOID != 0)
            ret = ftFlow.DiscontinueOrderMilk(oData.LOID, Appz.CurrentUser, oData.ENDDATE, oData.ENDTIME);

        if (!ret)
        {
            SetStatus(ftFlow.ErrorMessage, true);
            this.popupOrder.Show();
        }
        return ret;
    }

    private string ValidateData(OrderMilkData oData)
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

        if (oData.OWNER == "S" && oData.MILKCATEGORY == 0)
            error = string.Format(DataResources.MSGEI002, "นมของโรงพยาบาล");
        else if (oData.OWNER == "M" && oData.OWNERTEXT == "")
            error = string.Format(DataResources.MSGEI002, "นมที่นำมาเอง");
        else if (oData.ENERGY == 0)
            error = string.Format(DataResources.MSGEI001, "พลังงาน");
        else if (!this.chkTime01.Checked && !this.chkTime02.Checked && !this.chkTime03.Checked && !this.chkTime04.Checked && !this.chkTime05.Checked && !this.chkTime06.Checked &&
           !this.chkTime07.Checked && !this.chkTime08.Checked && !this.chkTime09.Checked && !this.chkTime10.Checked && !this.chkTime11.Checked && !this.chkTime12.Checked &&
           !this.chkTime13.Checked && !this.chkTime14.Checked && !this.chkTime15.Checked && !this.chkTime16.Checked && !this.chkTime17.Checked && !this.chkTime18.Checked &&
           !this.chkTime19.Checked && !this.chkTime20.Checked && !this.chkTime21.Checked && !this.chkTime22.Checked && !this.chkTime23.Checked && !this.chkTime24.Checked)
            error = string.Format(DataResources.MSGEI002, "เวลา");
        else if (oData.VOLUMN == 0)
            error = string.Format(DataResources.MSGEI002, "ปริมาณ");
        else if (qty == 0)
            error = string.Format(DataResources.MSGEI002, "เวลา");
        else if (this.cmbMealQty.SelectedValue != qty.ToString())
            error = string.Format(DataResources.MSGEI002, "เวลาที่เลือกไม่ตรงกับจำนวนมื้อ");
        else if (txtIsDoctor.Text == "0" & (oData.FIRSTDATE.Year == 1 || oData.FIRSTTIME == ""))
            error = string.Format(DataResources.MSGEI002, "วันที่และเวลาที่เริ่มต้น");
        else if (txtIsDoctor.Text == "0" & isLock == "Y")
        {
            string cuttime = "";
            cuttime = ftFlow.GetCutOffTimeFM("M", oData.FIRSTTIME);
            time = int.Parse(cuttime.Replace(":", ""));

            if (oData.FIRSTDATE < DateTime.Today)
                error = "ไม่สามารถสั่งอาหารหลังเวลา cut of time ได้";
            else if (oData.FIRSTDATE == DateTime.Today & time < int.Parse(DateTime.Now.ToString("HHmm")))
                error = "ไม่สามารถสั่งอาหารหลังเวลา cut of time ได้";
        }
        return error;
    }

    #endregion

}
