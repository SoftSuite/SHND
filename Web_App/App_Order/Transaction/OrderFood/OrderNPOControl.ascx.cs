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

public partial class App_Order_Transaction_OrderFood_OrderNPOControl : System.Web.UI.UserControl
{
    public event EventHandler SaveClick;

    protected override void OnInit(EventArgs e)
    {
        base.OnInit(e);
        ControlUtil.SetIntTextBox(this.txtNPOPeriod);
    }

    protected void Page_Load(object sender, EventArgs e)
    {

    }

    #region Button Click Event Handler

    protected void tbSaveClick(object sender, EventArgs e)
    {
        if (SaveData()) { if (SaveClick != null) SaveClick(sender, e); }
    }
    protected void tbCancelClick(object sender, EventArgs e)
    {
        GetDetail(Convert.ToDouble("0" + this.txtLOID.Text));
        this.popupOrder.Show();
    }
    protected void tbDiscontinueClick(object sender, EventArgs e)
    {
        if (DisContinue()) { if (SaveClick != null) SaveClick(sender, e); }
    }

    #endregion

    #region Controls Management Methods

    private void SetStatus(string t, bool isError)
    {
        this.lbStatus.Text = t;
        this.lbStatus.ForeColor = (isError ? Constant.StatusColor.Error : Constant.StatusColor.Information);
    }

    public void Show(double admitPatientID, double loid, bool isView, bool isCopy)
    {
        this.txtIsView.Text = (isView ? "1" : "0");
        this.txtAdmitPatient.Text = admitPatientID.ToString();
        this.txtLOID.Text = loid.ToString();
        if (isCopy) this.txtLOID.Text = "";
        GetDetail(loid);
        this.popupOrder.Show();
    }

    private void SetView(bool isView)
    {
        this.ctlFirstDate.Enabled = !isView;
        this.cmbFirstTime.Enabled = !isView;
        this.txtNPOPeriod.CssClass = (isView ? "zTextboxR-View" : "zTextboxR");
        this.txtNPOPeriod.ReadOnly = isView;
        this.txtRemarks.CssClass = (isView ? "zTextbox-View" : "zTextbox");
        this.txtRemarks.ReadOnly = isView;
    }

    private void SetData(OrderMedicalSetData oData)
    {
        bool pageAuthorized = (this.txtIsView.Text == "0");
        this.ctlEndDate.DateValue = oData.ENDDATE;
        this.cmbEndTime.SelectedIndex = this.cmbEndTime.Items.IndexOf(this.cmbEndTime.Items.FindByValue(oData.ENDDATE.Hour.ToString()));
        this.ctlFirstDate.DateValue = oData.FIRSTDATE;
        this.cmbFirstTime.SelectedIndex = this.cmbFirstTime.Items.IndexOf(this.cmbFirstTime.Items.FindByValue(oData.FIRSTDATE.Hour.ToString()));
        this.txtNPOPeriod.Text = oData.NPOPERIOD.ToString(Constant.IntFormat);
        this.txtRemarks.Text = oData.REMARKS;
        this.txtStatus.Text = oData.STATUS;
        if (Convert.ToDouble("0" + this.txtLOID.Text) == 0)
        {
            oData.LOID = 0;
            oData.STATUS = "";
        }
        SetView(oData.STATUS == "RG" || oData.STATUS == "DC" || !pageAuthorized);

        this.tbDiscontinue.Visible = (pageAuthorized && oData.LOID != 0);
        this.tbSave.Visible = (oData.STATUS != "RG" && oData.STATUS != "DC" && pageAuthorized);
        this.tbCancel.Visible = (oData.STATUS != "RG" && oData.STATUS != "DC" && pageAuthorized);
    }

    private OrderMedicalSetData GetData()
    {
        OrderMedicalSetData oData = new OrderMedicalSetData();
        oData.FIRSTMEAL = "00";
        oData.ADMITPATIENT = Convert.ToDouble("0" + this.txtAdmitPatient.Text);
        oData.DOCTOR = Appz.LoggedOnUser.LOID;
        oData.NPOPERIOD = Convert.ToDouble("0" + this.txtNPOPeriod.Text);
        if (this.ctlFirstDate.DateValue.Year != 1 && oData.NPOPERIOD != -1)
        {
            oData.FIRSTDATE = new DateTime(this.ctlFirstDate.DateValue.Year, this.ctlFirstDate.DateValue.Month, this.ctlFirstDate.DateValue.Day, Convert.ToInt16(this.cmbFirstTime.SelectedItem.Value), 0, 0);
            if (oData.NPOPERIOD!=0)
                oData.ENDDATE = oData.FIRSTDATE.AddHours(oData.NPOPERIOD);
        }
        oData.NPOSTART = oData.FIRSTDATE;
        oData.ISNPO = true;
        oData.LOID = Convert.ToDouble("0" + this.txtLOID.Text);
        oData.REMARKS = this.txtRemarks.Text;
        return oData;
    }

    #endregion

    #region Working Method

    private void GetDetail(double ID)
    {
        OrderFoodFlow oFlow = new OrderFoodFlow();
        SetData(oFlow.GetOrderMedicalSet(ID));
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
        return ret;
    }

    private bool DisContinue()
    {
        bool ret = true;
        OrderFoodFlow ftFlow = new OrderFoodFlow();
        OrderMedicalSetData oData = GetData();
        if (oData.LOID != 0)
            ret = ftFlow.DiscontinueOrderMedicalSet(oData.LOID, Appz.CurrentUser, oData.ENDDATE, "");

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
        if (oData.FIRSTDATE.Year == 1 || this.cmbFirstTime.SelectedItem.Value == "-1")
            error = string.Format(DataResources.MSGEI002, "วันที่และเวลาเริ่มต้น");

        return error;
    }

    #endregion

}
