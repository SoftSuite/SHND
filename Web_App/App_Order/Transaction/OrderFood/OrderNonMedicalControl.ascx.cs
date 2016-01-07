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

public partial class App_Order_Transaction_OrderFood_OrderNonMedicalControl : System.Web.UI.UserControl
{
    public event EventHandler SaveClick;

    protected override void OnInit(EventArgs e)
    {
        base.OnInit(e);
        string script = "";
        script = "document.getElementById('" + this.txtBreakfast.ClientID + "').className = (document.getElementById('" + this.chkBreakfast.ClientID + "').checked ? 'zTextboxR' : 'zTextboxR-View');" +
            "document.getElementById('" + this.txtBreakfast.ClientID + "').readOnly = !document.getElementById('" + this.chkBreakfast.ClientID + "').checked;" +
            "if (!document.getElementById('" + this.chkBreakfast.ClientID + "').checked) document.getElementById('" + this.txtBreakfast.ClientID + "').value = '0'; else document.getElementById('" + this.txtBreakfast.ClientID + "').value = '1';";
        this.chkBreakfast.Attributes.Add("onClick", script);
        script = "document.getElementById('" + this.txtLunch.ClientID + "').className = (document.getElementById('" + this.chkLunch.ClientID + "').checked ? 'zTextboxR' : 'zTextboxR-View');" +
            "document.getElementById('" + this.txtLunch.ClientID + "').readOnly = !document.getElementById('" + this.chkLunch.ClientID + "').checked;" +
            "if (!document.getElementById('" + this.chkLunch.ClientID + "').checked) document.getElementById('" + this.txtLunch.ClientID + "').value = '0'; else document.getElementById('" + this.txtLunch.ClientID + "').value = '1';";
        this.chkLunch.Attributes.Add("onClick", script);
        script = "document.getElementById('" + this.txtDinner.ClientID + "').className = (document.getElementById('" + this.chkDinner.ClientID + "').checked ? 'zTextboxR' : 'zTextboxR-View');" +
            "document.getElementById('" + this.txtDinner.ClientID + "').readOnly = !document.getElementById('" + this.chkDinner.ClientID + "').checked;" +
            "if (!document.getElementById('" + this.chkDinner.ClientID + "').checked) document.getElementById('" + this.txtDinner.ClientID + "').value = '0'; else document.getElementById('" + this.txtDinner.ClientID + "').value = '1';";
        this.chkDinner.Attributes.Add("onClick", script);
        script = "document.getElementById('" + this.txtAbstainOther.ClientID + "').className = (document.getElementById('" + this.chkAbstain.ClientID + "').checked ? 'zTextbox' : 'zTextbox-View');" +
            "document.getElementById('" + this.txtAbstainOther.ClientID + "').readOnly = !document.getElementById('" + this.chkAbstain.ClientID + "').checked;" +
            "if (!document.getElementById('" + this.chkAbstain.ClientID + "').checked) document.getElementById('" + this.txtAbstainOther.ClientID + "').value = '';";
        this.chkAbstain.Attributes.Add("onClick", script);
        script = "document.getElementById('" + this.txtNeedOther.ClientID + "').className = (document.getElementById('" + this.chkNeed.ClientID + "').checked ? 'zTextbox' : 'zTextbox-View');" +
            "document.getElementById('" + this.txtNeedOther.ClientID + "').readOnly = !document.getElementById('" + this.chkNeed.ClientID + "').checked;" +
            "if (!document.getElementById('" + this.chkNeed.ClientID + "').checked) document.getElementById('" + this.txtNeedOther.ClientID + "').value = '';";
        this.chkNeed.Attributes.Add("onClick", script);
        ControlUtil.SetIntTextBox(this.txtBreakfast);
        ControlUtil.SetIntTextBox(this.txtLunch);
        ControlUtil.SetIntTextBox(this.txtDinner);
        Appz.BuildCombo(this.cmbFoodType, "FOODTYPE", "NAME", "LOID", "ACTIVE='1'", "NAME", "เลือก", "0", true);
        this.imbAdd.OnClientClick = "if (!document.getElementById('" + this.chkIsAbstain.ClientID + "').checked && " +
            "!document.getElementById('" + this.chkIsNeed.ClientID + "').checked && !document.getElementById('" + this.chkIsRequst.ClientID + "').checked) " +
            "{ alert('" + string.Format(DataResources.MSGEI002, "เงื่อนไขสารอาหาร") + "'); return false; }";
    }

    protected void Page_Load(object sender, EventArgs e)
    {
        if (IsPostBack) SetCondition();
    }

    protected void ctlDiseaseCategory_SelectedIndexChanged(object sender, EventArgs e, ArrayList arrData)
    {
        InsertDiseaseCategory(arrData);
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
        this.ctlDiseaseCategory.Show(this.chkIsAbstain.Checked, this.chkIsNeed.Checked, this.chkIsRequst.Checked,"", diseaseCategoryList);
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

    private void SetStatus(string t, bool isError)
    {
        this.lbStatus.Text = t;
        this.lbStatus.ForeColor = (isError ? Constant.StatusColor.Error : Constant.StatusColor.Information);
    }

    public void Show(double admitPatientID, double loid, bool isView, bool isCopy, double foodTypeID, double ward)
    {
        this.txtIsView.Text = (isView ? "1" : "0");
        this.txtAdmitPatient.Text = admitPatientID.ToString();
        this.txtLOID.Text = loid.ToString();
        this.txtWard.Text = ward.ToString();
        if (foodTypeID != 0) this.cmbFoodType.SelectedIndex = this.cmbFoodType.Items.IndexOf(this.cmbFoodType.Items.FindByValue(foodTypeID.ToString()));
        GetDetail(loid, isCopy);
        this.popupOrder.Show();
    }

    private void SetCondition()
    {
        if (this.chkBreakfast.Enabled)
        {
            this.txtBreakfast.CssClass = (!this.chkBreakfast.Checked ? "zTextboxR-View" : "zTextboxR");
            if (this.chkBreakfast.Checked)
                this.txtBreakfast.Attributes.Remove("readonly");
            else
                this.txtBreakfast.Attributes.Add("readOnly", "readonly");
        }
        if (this.chkLunch.Enabled)
        {
            this.txtLunch.CssClass = (!this.chkLunch.Checked ? "zTextboxR-View" : "zTextboxR");
            if (this.chkLunch.Checked)
                this.txtLunch.Attributes.Remove("readonly");
            else
                this.txtLunch.Attributes.Add("readOnly", "readonly");
        }
        if (this.chkDinner.Enabled)
        {
            this.txtDinner.CssClass = (!this.chkDinner.Checked ? "zTextboxR-View" : "zTextboxR");
            if (this.chkDinner.Checked)
                this.txtDinner.Attributes.Remove("readonly");
            else
                this.txtDinner.Attributes.Add("readOnly", "readonly");
        }
        if (this.chkAbstain.Enabled)
        {
            this.txtAbstainOther.CssClass = (!this.chkAbstain.Checked ? "zTextbox-View" : "zTextbox");
            if (this.chkAbstain.Checked)
                this.txtAbstainOther.Attributes.Remove("readonly");
            else
                this.txtAbstainOther.Attributes.Add("readOnly", "readonly");
        }
        if (this.chkNeed.Enabled)
        {
            this.txtNeedOther.CssClass = (!this.chkNeed.Checked ? "zTextbox-View" : "zTextbox");
            if (this.chkNeed.Checked)
                this.txtNeedOther.Attributes.Remove("readonly");
            else
                this.txtNeedOther.Attributes.Add("readOnly", "readonly");
        }
    }

    private void SetView(bool isView)
    {
        this.chkIsFamily.Enabled = !isView;
        this.chkBreakfast.Enabled = !isView;
        this.chkLunch.Enabled = !isView;
        this.chkDinner.Enabled = !isView;
        this.txtBreakfast.CssClass = (isView ? "zTextboxR-View" : "zTextboxR");
        this.txtBreakfast.Attributes.Add("readonly", (isView ? "true" : "false"));
        this.txtLunch.CssClass = (isView ? "zTextboxR-View" : "zTextboxR");
        this.txtLunch.Attributes.Add("readonly", (isView ? "true" : "false"));
        this.txtDinner.CssClass = (isView ? "zTextboxR-View" : "zTextboxR");
        this.txtDinner.Attributes.Add("readonly", (isView ? "true" : "false"));
        this.ctlFirstDate.Enabled = !isView;
        this.chkIsAbstain.Enabled = !isView;
        this.chkIsNeed.Enabled = !isView;
        this.chkIsRequst.Enabled = !isView;
        this.imbAdd.Visible = !isView;
        this.chkAbstain.Enabled = !isView;
        this.chkNeed.Enabled = !isView;
        this.txtAbstainOther.CssClass = (isView ? "zTextbox-View" : "zTextbox");
        this.txtAbstainOther.Attributes.Add("readonly", (isView ? "readonly" : ""));
        this.txtNeedOther.CssClass = (isView ? "zTextbox-View" : "zTextbox");
        this.txtNeedOther.Attributes.Add("readonly", (isView ? "readonly" : ""));
        this.cmbVIPType.Enabled = !isView;
        this.txtRemarks.CssClass = (isView ? "zTextbox-View" : "zTextbox");
        this.txtRemarks.ReadOnly = isView;
    }

    private void SetData(OrderNonMedicalData oData, bool isCopy)
    {
        bool pageAuthorized = (this.txtIsView.Text == "0");
        this.txtAbstainOther.Text = oData.ABSTAINOTHER;
        this.txtBreakfast.Text = oData.BREAKFAST.ToString(Constant.IntFormat);
        this.txtDinner.Text = oData.DINNER.ToString(Constant.IntFormat);
        this.ctlEndDate.DateValue = oData.ENDDATE;
        this.ctlFirstDate.DateValue = oData.FIRSTDATE;
        this.cmbEndMeal.SelectedIndex = this.cmbEndMeal.Items.IndexOf(this.cmbEndMeal.Items.FindByValue(oData.ENDMEAL));
        this.cmbFirstMeal.SelectedIndex = this.cmbFirstMeal.Items.IndexOf(this.cmbFirstMeal.Items.FindByValue(oData.FIRSTMEAL));
        if (oData.LOID != 0) this.cmbFoodType.SelectedIndex = this.cmbFoodType.Items.IndexOf(this.cmbFoodType.Items.FindByValue(oData.FOODTYPE.ToString()));
        this.chkIsAbstain.Checked = oData.ISABSTAIN;
        this.chkIsFamily.Checked = oData.ISFAMILY;
        this.chkIsNeed.Checked = oData.ISNEED;
        this.chkIsRequst.Checked = oData.ISREQUEST;
        this.txtLunch.Text = oData.LUNCH.ToString(Constant.IntFormat);
        this.txtNeedOther.Text = oData.NEEDOTHER;
        this.txtRemarks.Text = oData.REMARKS;
        this.txtStatus.Text = oData.STATUS;
        this.chkBreakfast.Checked = (oData.BREAKFAST > 0);
        this.chkLunch.Checked = (oData.LUNCH > 0);
        this.chkDinner.Checked = (oData.DINNER > 0);
        this.chkAbstain.Checked = (oData.ABSTAINOTHER != "");
        this.chkNeed.Checked = (oData.NEEDOTHER != "");
        this.cmbVIPType.SelectedIndex = this.cmbVIPType.Items.IndexOf(this.cmbVIPType.Items.FindByValue(oData.VIPTYPE));
        this.ctlFirstDateRegis.DateValue = oData.FIRSTDATEREGIS;
        this.txtFirstMealRegis.Text = oData.FIRSTMEALREGIS;
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
        SetCondition();

        this.tbDiscontinue.Visible = (oData.STATUS == "RG");//(pageAuthorized && oData.LOID  != 0);
        this.tbSave.Visible = (oData.STATUS != "RG" && oData.STATUS != "DC" && pageAuthorized);
        this.tbCancel.Visible = (oData.STATUS != "RG" && oData.STATUS != "DC" && pageAuthorized);
        this.gvMain.Columns[1].Visible = (oData.STATUS != "RG" && oData.STATUS != "DC" && pageAuthorized);
        this.ctlEndDate.Enabled = pageAuthorized;
    }

    private OrderNonMedicalData GetData()
    {
        OrderNonMedicalData oData = new OrderNonMedicalData();
        oData.ABSTAINOTHER = this.txtAbstainOther.Text.Trim();
        oData.ADMITPATIENT = Convert.ToDouble("0" + this.txtAdmitPatient.Text);
        oData.BREAKFAST = Convert.ToDouble("0" + this.txtBreakfast.Text);
        oData.DINNER = Convert.ToDouble("0" + this.txtDinner.Text);
        oData.ENDDATE = this.ctlEndDate.DateValue;
        oData.ENDMEAL = this.cmbEndMeal.SelectedItem.Value;
        oData.FIRSTDATE = this.ctlFirstDate.DateValue;
        oData.FIRSTMEAL = this.cmbFirstMeal.SelectedItem.Value;
        oData.FOODTYPE = Convert.ToDouble(this.cmbFoodType.SelectedItem.Value);
        oData.ISABSTAIN = this.chkIsAbstain.Checked;
        oData.ISFAMILY = this.chkIsFamily.Checked;
        oData.ISNEED = this.chkIsNeed.Checked;
        oData.ISREQUEST = this.chkIsRequst.Checked;
        oData.LOID = Convert.ToDouble("0" + this.txtLOID.Text);
        oData.LUNCH = Convert.ToDouble("0" + this.txtLunch.Text);
        oData.NEEDOTHER = this.txtNeedOther.Text.Trim();
        oData.NURSE = Appz.LoggedOnUser.LOID;
        oData.REMARKS = this.txtRemarks.Text.Trim();
        oData.STATUS = this.txtStatus.Text.Trim();
        oData.VIPTYPE = this.cmbVIPType.SelectedItem.Value;
        oData.FIRSTDATEREGIS = this.ctlFirstDateRegis.DateValue;
        oData.FIRSTMEALREGIS = this.txtFirstMealRegis.Text;

        OrderFoodDetailItem item = new OrderFoodDetailItem();
        oData.ORDERITEMLIST = item.GetOrderItemList();
        return oData;
    }

    #endregion

    #region Working Method

    private void CheckConstraint()
    {
        bool enabled = (this.gvMain.Rows.Count == 0) && this.imbAdd.Visible;
        this.chkIsAbstain.Enabled = enabled;
        this.chkIsNeed.Enabled = enabled;
        this.chkIsRequst.Enabled = enabled;
    }

    private void InsertDiseaseCategory(ArrayList arrData)
    {
        OrderFoodDetailItem item = new OrderFoodDetailItem();
        if (item.InsertDiseaseCategory(Convert.ToDouble("0" + this.txtLOID.Text), "ORDERNONMEDICAL", arrData))
        {
            this.gvMain.DataBind();
            CheckConstraint();
            this.popupOrder.Show();
        }
    }

    private void GetDetail(double ID, bool isCopy)
    {
        OrderFoodFlow oFlow = new OrderFoodFlow();
        SetData(oFlow.GetOrderNonMedical(ID), isCopy);
    }

    private bool SaveData()
    {
        bool ret = true;
        OrderFoodFlow ftFlow = new OrderFoodFlow();
        OrderNonMedicalData oData = GetData();
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
            ret = ftFlow.InsertOrderNonMedical(oData, Appz.CurrentUser);
        else
            ret = ftFlow.UpdateOrderNonMedical(oData, Appz.CurrentUser);

        if (!ret)
        {
            SetStatus(ftFlow.ErrorMessage, true);
            this.popupOrder.Show();
        }
        else
        {
            txtLOID.Text = ftFlow.LOID.ToString();
           // GetDetail(ftFlow.LOID, false);
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
        OrderNonMedicalData oData = GetData();
        if (oData.ENDDATE.Year == 1)
        {
            SetStatus(string.Format(DataResources.MSGEI002, "วันที่สิ้นสุด"), true);
            this.popupOrder.Show();
            return false;
        }
        else if (oData.ENDMEAL == "")
        {
            SetStatus(string.Format(DataResources.MSGEI002, "มื้อที่สิ้นสุด"), true);
            this.popupOrder.Show();
            return false;
        }
        else if (oData.ENDDATE < oData.FIRSTDATEREGIS || (oData.ENDDATE == oData.FIRSTDATEREGIS & Convert.ToDouble(oData.ENDMEAL) <= Convert.ToDouble(oData.FIRSTMEALREGIS)))
        {
            SetStatus("ไม่สามารถ Discontinue การสั่งอาหารในมื้อที่ Register แล้วได้", true);
            this.popupOrder.Show();
            return false;
        }

        if (oData.LOID != 0)
            ret = ftFlow.DiscontinueOrderNonMedical(oData.LOID, Appz.CurrentUser, oData.ENDDATE,oData.ENDMEAL);

        if (!ret)
        {
            SetStatus(ftFlow.ErrorMessage, true);
            this.popupOrder.Show();
        }
        return ret;
    }

    private string ValidateData(OrderNonMedicalData oData)
    {
        string error = "";
        string isLock = "";
        int time = 0;
        OrderFoodFlow ftFlow = new OrderFoodFlow();
        isLock = ftFlow.GetIsLock(Convert.ToDouble("0" + txtWard.Text));

        if (oData.FIRSTDATE.Year == 1 || oData.FIRSTMEAL == "")
            error = string.Format(DataResources.MSGEI002, "วันที่และมื้อที่เริ่มต้น");
        else if (isLock == "Y")
        {
            CutOffTimeData cData = new CutOffTimeData();
            cData = ftFlow.GetCutOffTime("S");
            if (oData.FIRSTMEAL == "11")
                time = int.Parse(cData.BREAKFASTTIME.Replace(":", ""));
            else if (oData.FIRSTMEAL == "21")
                time = int.Parse(cData.LUNCHTIME.Replace(":", ""));
            else
                time = int.Parse(cData.DINNERTIME.Replace(":", ""));


            if (oData.FIRSTDATE < DateTime.Today)
                error = "ไม่สามารถสั่งอาหารหลังเวลา cut of time ได้";
            else if (oData.FIRSTDATE == DateTime.Today & time < int.Parse(DateTime.Now.ToString("HHmm")))
                error = "ไม่สามารถสั่งอาหารหลังเวลา cut of time ได้";
        }

        return error;
    }

    #endregion

}
