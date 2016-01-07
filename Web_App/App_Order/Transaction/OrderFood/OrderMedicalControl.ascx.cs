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
using SHND.Flow.Order;
using SHND.Global;
using SHND.Data.Tables;

public partial class App_Order_Transaction_OrderFood_OrderMedicalControl : System.Web.UI.UserControl
{
    public event EventHandler SaveClick;

    protected override void OnInit(EventArgs e)
    {
        base.OnInit(e);
        Appz.BuildCombo(this.cmbFoodCategory, "FOODCATEGORY", "NAME", "LOID", "ACTIVE = '1'", "NAME", "เลือก", "0", false);
        this.imbAdd.OnClientClick = "if (!document.getElementById('" + this.chkIsCalculate.ClientID + "').checked && !document.getElementById('" + this.chkIsIncrease.ClientID + "').checked && " +
            "!document.getElementById('" + this.chkIsLimit.ClientID + "').checked && !document.getElementById('" + this.chkIsSpecific.ClientID + "').checked) "+
            "{ alert('" + string.Format(DataResources.MSGEI002, "เงื่อนไขสารอาหาร") + "'); return false; }";
    }

    protected void Page_Load(object sender, EventArgs e)
    {

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
        string diseaseCategoryList= "";
        for (int i=0; i<this.gvMain.Rows.Count; ++i)
        {
            diseaseCategoryList += (diseaseCategoryList == "" ? "" : ",") + this.gvMain.Rows[i].Cells[0].Text;
        }
        this.ctlDiseaseCategory.Show(this.chkIsSpecific.Checked, this.chkIsIncrease.Checked, this.chkIsLimit.Checked, this.chkIsCalculate.Checked, cmbFoodCategory.SelectedValue, diseaseCategoryList);
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

    public void Show(double admitPatientID, double loid, bool isView, bool isCopy, double foodCategoryID, double ward)
    {
        this.txtIsView.Text = (isView ? "1" : "0");
        this.txtAdmitPatient.Text = admitPatientID.ToString();
        this.txtLOID.Text = loid.ToString();
        this.txtWard.Text = ward.ToString();
        if (foodCategoryID != 0) this.cmbFoodCategory.SelectedIndex = this.cmbFoodCategory.Items.IndexOf(this.cmbFoodCategory.Items.FindByValue(foodCategoryID.ToString()));
        GetDetail(loid, isCopy);
        this.popupOrder.Show();
    }

    private void SetView(bool isView)
    {
        this.chkBreakfast.Enabled = !isView;
        this.chkDinner.Enabled = !isView;
        this.ctlFirstDate.Enabled = !isView;
        this.cmbFirstMeal.Enabled = !isView;
        this.chkIsCalculate.Enabled = !isView;
        this.chkIsIncrease.Enabled = !isView;
        this.chkIsLimit.Enabled = !isView;
        this.chkIsSpecific.Enabled = !isView;
        this.chkLunch.Enabled = !isView;
        this.txtRemarks.CssClass = (isView ? "zTextbox-View" : "zTextbox");
        this.txtRemarks.ReadOnly = isView;
        this.imbAdd.Visible = !isView;
    }

    private void SetData(OrderMedicalSetData oData, bool isCopy)
    {
        bool pageAuthorized = (this.txtIsView.Text == "0");
        this.chkBreakfast.Checked = oData.BREAKFAST;
        this.chkDinner.Checked = oData.DINNER;
        this.ctlEndDate.DateValue = oData.ENDDATE;
        this.cmbEndMeal.SelectedIndex = this.cmbEndMeal.Items.IndexOf(this.cmbEndMeal.Items.FindByValue(oData.ENDMEAL));
        this.ctlFirstDate.DateValue = oData.FIRSTDATE;
        this.cmbFirstMeal.SelectedIndex = this.cmbFirstMeal.Items.IndexOf(this.cmbFirstMeal.Items.FindByValue(oData.FIRSTMEAL));
        if (oData.LOID != 0) this.cmbFoodCategory.SelectedIndex = this.cmbFoodCategory.Items.IndexOf(this.cmbFoodCategory.Items.FindByValue(oData.FOODCATEGORY.ToString()));
        this.chkIsCalculate.Checked = oData.ISCALCULATE;
        this.chkIsIncrease.Checked = oData.ISINCREASE;
        this.chkIsLimit.Checked = oData.ISLIMIT;
        this.chkIsSpecific.Checked = oData.ISSPECIFIC;
        this.txtStatus.Text = oData.STATUS;
        this.chkLunch.Checked = oData.LUNCH;
        this.txtRemarks.Text = oData.REMARKS;
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

        this.tbDiscontinue.Visible = (oData.STATUS == "RG");//(pageAuthorized && oData.LOID != 0);
        this.tbSave.Visible = (oData.STATUS != "RG" && oData.STATUS != "DC" && pageAuthorized);
        this.tbCancel.Visible = (oData.STATUS != "RG" && oData.STATUS != "DC" && pageAuthorized);
        this.gvMain.Columns[1].Visible = (oData.STATUS != "RG" && oData.STATUS != "DC" && pageAuthorized);
        this.ctlEndDate.Enabled = pageAuthorized;
        this.cmbEndMeal.Enabled = pageAuthorized;
    }

    private OrderMedicalSetData GetData()
    {
        OrderMedicalSetData oData = new OrderMedicalSetData();
        oData.ADMITPATIENT = Convert.ToDouble("0" + this.txtAdmitPatient.Text);
        oData.BREAKFAST = this.chkBreakfast.Checked;
        oData.DINNER = this.chkDinner.Checked;
        oData.DOCTOR = Appz.LoggedOnUser.LOID;
        oData.ENDDATE = this.ctlEndDate.DateValue;
        oData.ENDMEAL = this.cmbEndMeal.SelectedItem.Value;
        oData.FIRSTDATE = this.ctlFirstDate.DateValue;
        oData.FIRSTMEAL = this.cmbFirstMeal.SelectedItem.Value;
        oData.FOODCATEGORY = Convert.ToDouble(this.cmbFoodCategory.SelectedItem.Value);
        oData.ISSPECIFIC = this.chkIsSpecific.Checked;
        oData.ISCALCULATE = this.chkIsCalculate.Checked;
        oData.ISINCREASE = this.chkIsIncrease.Checked;
        oData.ISLIMIT = this.chkIsLimit.Checked;
        oData.ISNPO = false;
        oData.LOID = Convert.ToDouble("0" + this.txtLOID.Text);
        oData.LUNCH = this.chkLunch.Checked;
        oData.REMARKS = this.txtRemarks.Text;
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
        bool enabled = (this.gvMain.Rows.Count ==0) && this.imbAdd.Visible;
        this.chkIsCalculate.Enabled = enabled;
        this.chkIsIncrease.Enabled = enabled;
        this.chkIsLimit.Enabled = enabled;
        this.chkIsSpecific.Enabled = enabled;
    }

    private void InsertDiseaseCategory(ArrayList arrData)
    {
        OrderFoodDetailItem item = new OrderFoodDetailItem();
        if (item.InsertDiseaseCategory(Convert.ToDouble("0" + this.txtLOID.Text), "ORDERMEDICALSET", arrData))
        {
            this.gvMain.DataBind();
            CheckConstraint();
            this.popupOrder.Show();
        }
    }

    private void GetDetail(double ID, bool isCopy)
    {
        OrderFoodFlow oFlow = new OrderFoodFlow();
        SetData(oFlow.GetOrderMedicalSet(ID), isCopy);
    }

    private bool SaveData()
    {
        bool ret = true;
        OrderFoodFlow ftFlow = new OrderFoodFlow();
        OrderMedicalSetData oData = GetData();
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
            ret = ftFlow.InsertOrderMedicalSet(oData, Appz.CurrentUser);
        else
            ret = ftFlow.UpdateOrderMedicalSet(oData, Appz.CurrentUser);

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
        OrderMedicalSetData oData = GetData();
        if (oData.ENDDATE.Year == 1 || oData.ENDMEAL == "")
        {
            SetStatus(string.Format(DataResources.MSGEI002, "วันที่และมื้อที่สิ้นสุด"), true);
            this.popupOrder.Show();
            return false;
        }
        else if (oData.ENDDATE < oData.FIRSTDATEREGIS || (oData.ENDDATE == oData.FIRSTDATEREGIS & Convert.ToDouble(oData.ENDMEAL) <= Convert.ToDouble(oData.FIRSTMEALREGIS) ))
        {
            SetStatus("ไม่สามารถ Discontinue การสั่งอาหารในมื้อที่ Register แล้วได้", true);
            this.popupOrder.Show();
            return false;
        }

        if (oData.LOID != 0)
            ret = ftFlow.DiscontinueOrderMedicalSet(oData.LOID, Appz.CurrentUser, oData.ENDDATE, oData.ENDMEAL);

        if (!ret)
        {
            SetStatus(ftFlow.ErrorMessage, true);
            this.popupOrder.Show();
        }
        return ret;
    }

    private string ValidateData(OrderMedicalSetData oData)
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
                time = int.Parse(cData.LUNCHTIME.Replace(":",""));
            else
                time = int.Parse(cData.DINNERTIME.Replace(":",""));


            if (oData.FIRSTDATE < DateTime.Today)
                error = "ไม่สามารถสั่งอาหารหลังเวลา cut of time ได้";
            else if (oData.FIRSTDATE == DateTime.Today & time < int.Parse(DateTime.Now.ToString("HHmm")))
                error = "ไม่สามารถสั่งอาหารหลังเวลา cut of time ได้";
        }

        return error;
    }

    #endregion

}
