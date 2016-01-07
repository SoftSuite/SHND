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
using SHND.Flow.Purchase;
using SHND.Global;

/// <summary>
/// Receive Detail Page Class
/// Version 1.0
/// =========================================================================
/// Create by: Tan
/// Create Date: 12 March 2009
/// -------------------------------------------------------------------------
/// Modify By: -
/// Modify From: -
/// Modify Date: -
/// -------------------------------------------------------------------------
/// Remark: -
/// Description:
///    หน้ากาารทำงานข้อมูล Receive
/// Changes:
///    1.0 - สร้าง
/// -------------------------------------------------------------------------
/// =========================================================================
/// </summary>
/// 

public partial class App_Purchase_Transaction_Receive : System.Web.UI.Page
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

        Appz.BuildCombo(cmbOrederPlan, "PLANORDER", "NAME", "LOID", "ISPLANFOOD = 'Y' AND STATUS = 'FN' ", "NAME", "เลือก", "0", false);
    }
    protected void ctlReceivePopup_SelectedIndexChanged(object sender, EventArgs e, ArrayList arrData)
    {
        ReceiveItem fsItem = new ReceiveItem();
        if (fsItem.InsertMaterialItem(Convert.ToDouble("0" + this.txtLOID.Text), Convert.ToDouble("0" + this.cmbOrederPlan.SelectedValue), Convert.ToDouble("0" + this.txtDivision.Text), arrData))
            BindReceiveItem();
        CalculateGranRemain();
        CalculateGrantotal();
    }

    #region Button Click Event Handler

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
        Response.Redirect(Constant.HomeFolder + "App_Purchase/Transaction/ReceiveSearch.aspx");
    }
    protected void tbPrintClick(object sender, EventArgs e)
    {
        this.tbPrint.ClientClick = Appz.OpenReportScript(Constant.Reports.RepReceive, Convert.ToDouble("0" + txtLOID.Text), false);

    }
    protected void tbApproveClick(object sender, EventArgs e)
    {
        doApprove();
    }

    protected void linkCode_Click(object sender, EventArgs e)
    {
        int rowIndex = ((GridViewRow)((LinkButton)sender).Parent.Parent).RowIndex;
        SetSpecData(rowIndex);
    }

    protected void imbReturn_Click(object sender, ImageClickEventArgs e)
    {
        int rowIndex = ((GridViewRow)((ImageButton)sender).Parent.Parent).RowIndex;
        ReturnMaterialDelivery(rowIndex);
    }


    #endregion

    #region FormulaDisease Toolbar
    protected void tbAddReceiveItemClick(object sender, EventArgs e)
    {
        if (cmbOrederPlan.SelectedValue == "0" || txtMaterialClass.Text == "0")
        {
            SetErrorStatus(string.Format(DataResources.MSGEI002, "หมวดอาหาร"));
        }
        else
        {
            UpdateReceiveItem();
            ReceiveItem fsItem = new ReceiveItem();
            this.ctlReceivePopup.Show(ctlReceiveDate.DateValue, Convert.ToDouble(txtMaterialClass.Text), fsItem.getMaterialList());
        }
    }
    protected void tbDeleteReceiveItemClick(object sender, EventArgs e)
    {
        ReceiveItem fsItem = new ReceiveItem();
        if (fsItem.DeleteMaterialItem(GetCheckedOrderParty())) BindReceiveItem();
        CalculateGrantotal();
    }

    #endregion

    #region GridView Event Handler


    private void ReturnMaterialDelivery(int RowIndex)
    {
        //ReceiveItem item = new ReceiveItem();
        //if (item.UpdateMaterialDelivery(Convert.ToDouble("0" + this.txtLOID.Text), Convert.ToDouble("0" + this.txtMaterialID.Text), Convert.ToDouble("0" + this.gvDetail.Rows[RowIndex].Cells[1].Text)))
        //    this.gvDetail.DataBind();
    }


    #endregion

    #region Misc. Methods

    private ArrayList GetCheckedOrderParty()
    {
        ArrayList arrChk = new ArrayList();
        for (int i = 0; i < gvItem.Rows.Count; i++)
        {
            if (i > -1 && gvItem.Rows[i].Cells[0].FindControl("chkSelect") != null)
            {
                GridViewRow gRow = gvItem.Rows[i];
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

    private void BindReceiveItem()
    {
        this.gvItem.DataBind();
    }

    private void SetErrorStatusPOItem(string t)
    {
        lbStatusPOItem.Text = t;
        lbStatusPOItem.ForeColor = Constant.StatusColor.Error;
    }

    private void SetStatusPOItem(string t)
    {
        lbStatusPOItem.Text = t;
        lbStatusPOItem.ForeColor = Constant.StatusColor.Information;
    }

    private void SetErrorStatusDelivery(string t)
    {
        lbStatusDelivery.Text = t;
        lbStatusDelivery.ForeColor = Constant.StatusColor.Error;
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

    private void SetSpecData(int rowIndex)
    {
        ClearSpec();

        GridViewRow gRow = this.gvItem.Rows[rowIndex];
        this.txtRowIndex.Text = rowIndex.ToString();
        this.lblMaterialName.Text = gRow.Cells[5].Text + " (" + gRow.Cells[6].Text + ")";
        this.txtSpec.Text = gRow.Cells[18].Text;
        this.ctlSpecPopup.Show();
    }

    private void ClearSpec()
    {
        this.txtRowIndex.Text = "";
        this.lblMaterialName.Text = "";
        this.txtSpec.Text = "";
    }

    private ReceiveData GetData()
    {
        ReceiveData fsData = new ReceiveData();
        fsData.LOID = Convert.ToDouble(txtLOID.Text);
        fsData.PLANMATERIALCLASS = Convert.ToDouble(cmbMaterialClass.SelectedValue == "" ? "0" : cmbMaterialClass.SelectedValue);
        fsData.REMARKS = txtRemark.Text;
        fsData.STATUS = txtStatus.Text;
        fsData.RECEIVEDATE = ctlReceiveDate.DateValue;
        //fsData.PLAN = Convert.ToDouble(cmbOrederPlan.SelectedValue);

        ReceiveItem item = new ReceiveItem();
        fsData.ReceiveItem = GetReceiveItem();

        return fsData;
    }

    private void SetData(VReceiveData fsData)
    {
        txtLOID.Text = fsData.LOID.ToString();
        txtStatus.Text = fsData.STATUS;
        txtStatusName.Text = fsData.STATUSNAME;
        ctlReceiveDate.DateValue = fsData.RECEIVEDATE;
        txtRemark.Text = fsData.REMARKS;
        cmbOrederPlan.SelectedValue = fsData.PLANORDER.ToString();
        txtMaterialClass.Text = fsData.MATERIALCLASS.ToString();
        txtSupplierCode.Text = fsData.CONTRACTCODE;
        txtSupplierName.Text = fsData.SUPPLIERNAME;
        txtTel.Text = fsData.TEL;
        txtFax.Text = fsData.FAX;


        if (fsData.LOID == 0)
        {
            this.txtStatus.Text = "WA";
            this.txtStatusName.Text = "กำลังดำเนินการ";
            this.txtDivision.Text = Appz.LoggedOnUser.DIVISION.ToString();
            this.ctlReceiveDate.DateValue = DateTime.Now.Date;
            ReceiveFlow rFlow = new ReceiveFlow();
            cmbOrederPlan.SelectedValue = rFlow.GetCurrPlan(DateTime.Today).ToString();
            Appz.BuildCombo(cmbMaterialClass, " V_PLANMATERIALCLASS", "CLASSNAME", "LOID", "PLANORDER = " + cmbOrederPlan.SelectedValue, "CLASSNAME", "เลือก", "0", false);
        }
        else
        {
            Appz.BuildCombo(cmbMaterialClass, " V_PLANMATERIALCLASS", "CLASSNAME", "LOID", "PLANORDER = " + cmbOrederPlan.SelectedValue, "CLASSNAME", "เลือก", "0", false);
            cmbMaterialClass.SelectedValue = fsData.PLANMATERIALCLASS.ToString();
        }
        if (fsData.STATUS == "AP")
        {
            tbSave.Visible = false;
            tbCancel.Visible = false;
            tbApprove.Visible = false;
            tbAddReceiveItem.Visible = false;
            tbDeleteReceiveItem.Visible = false;
        }

        ReceiveItem fsItem = new ReceiveItem();
        fsItem.ClearAllSession();
        BindReceiveItem();
        CalculateGrantotal();
        CalculateGranRemain();

    }

    private ArrayList GetReceiveItem()
    {
        ArrayList arrData = new ArrayList();
        for (int i = 0; i < this.gvItem.Rows.Count; ++i)
        {
            CheckBox chkVat = (CheckBox)this.gvItem.Rows[i].Cells[13].FindControl("chkVat");

            VReceiveMaterialData OrderItem = new VReceiveMaterialData();
            //OrderItem.PREPO = Convert.ToDouble("0" + this.txtLOID.Text);
            OrderItem.MATERIALMASTER = Convert.ToDouble("0" + this.gvItem.Rows[i].Cells[15].Text);
            OrderItem.UNITLOID = Convert.ToDouble("0" + this.gvItem.Rows[i].Cells[16].Text);
            OrderItem.PRICE = Convert.ToDouble("0" + this.gvItem.Rows[i].Cells[7].Text);
            OrderItem.ORDERQTY = Convert.ToDouble("0" + this.gvItem.Rows[i].Cells[8].Text);
            OrderItem.DUEQTY = Convert.ToDouble("0" + this.gvItem.Rows[i].Cells[9].Text);
            OrderItem.RECEIVEQTY = Convert.ToDouble("0" + ((TextBox)this.gvItem.Rows[i].Cells[10].FindControl("txtReceiveQty")).Text);
            OrderItem.PLANREMAINQTY = Convert.ToDouble("0") + Convert.ToDouble(this.gvItem.Rows[i].Cells[12].Text);
            OrderItem.NETPRICE = Convert.ToDouble("0" + ((TextBox)this.gvItem.Rows[i].Cells[11].FindControl("txtNetPrice")).Text);
            OrderItem.REMARK = ((TextBox)this.gvItem.Rows[i].Cells[14].FindControl("txtRemark")).Text;
            OrderItem.CODE = this.gvItem.Rows[i].Cells[17].Text.ToString();
            OrderItem.PREPODUEDATE = Convert.ToDouble("0" + this.gvItem.Rows[i].Cells[19].Text);
            OrderItem.DUEDATE = Convert.ToDateTime(this.gvItem.Rows[i].Cells[20].Text);
            OrderItem.USEDATE = Convert.ToDateTime(this.gvItem.Rows[i].Cells[21].Text);

           // OrderItem.USEQTY = 
            if (chkVat.Checked)
                OrderItem.ISVAT = "Y";
            else
                OrderItem.ISVAT = "N";

            arrData.Add(OrderItem);
        }
        return arrData;
    }

    #endregion

    #region Working Method

    private void UpdateReceiveItem()
    {
        ReceiveItem fsItem = new ReceiveItem();
        if (!fsItem.UpdateMaterialItem(Convert.ToDouble("0" + this.txtLOID.Text), GetReceiveItem()))
            SetErrorStatusPOItem(DataResources.MSGEC102);
        else
            SetStatusPOItem(DataResources.MSGIU001);
    }

    private bool doGetDetail(string LOID)
    {
        ReceiveFlow fFlow = new ReceiveFlow();
        VReceiveData fData = fFlow.GetDetails(Convert.ToDouble(LOID));

        bool ret = true;
        SetData(fData);
        ReceiveItem fsItem = new ReceiveItem();
        fsItem.ClearAllSession();
        BindReceiveItem();

        return ret;
    }

    private bool doSave()
    {
        //verify required field
        ReceiveData Order = GetData();
        string error = VerifyData(Order);
        if (error != "")
        {
            SetErrorStatus(error);
            return false;
        }

        ReceiveFlow ftFlow = new ReceiveFlow();
        bool ret = true;

        if (!ftFlow.CheckUniqueKey(Order.LOID, Order.PLANMATERIALCLASS, Order.RECEIVEDATE))
        {
            SetErrorStatus(string.Format(DataResources.MSGEI016, new string[] { "แผนประมาณการ", this.cmbOrederPlan.SelectedItem.Text, "วันที่ตรวจรับ", Order.RECEIVEDATE.ToString("dd/MM/yyyy") }));
            return false;
        }

        // data correct go on saving...
        if (Order.LOID != 0)
            ret = ftFlow.UpdateData(Order, Appz.CurrentUser);
        else
            ret = ftFlow.InsertData(Order, Appz.CurrentUser);

        if (!ret)
            SetErrorStatus(ftFlow.ErrorMessage);
        else
        {
            doGetDetail(ftFlow.LOID.ToString());
            if (Order.LOID != 0)
                SetStatus(DataResources.MSGIU001);
            else
                SetStatus(DataResources.MSGIN001);
        }

        return ret;
    }

    private bool doApprove()
    {
        //verify required field
        ReceiveData Order = GetData();
        Order.STATUS = "AP";
        string error = VerifyData(Order);
        if (error != "")
        {
            SetErrorStatus(error);
            return false;
        }

        ReceiveFlow ftFlow = new ReceiveFlow();
        bool ret = true;

        if (!ftFlow.CheckUniqueKey(Order.LOID, Order.PLANMATERIALCLASS, Order.RECEIVEDATE))
        {
            SetErrorStatus(string.Format(DataResources.MSGEI016, new string[] { "แผนประมาณการ", this.cmbOrederPlan.SelectedItem.Text, "วันที่ตรวจรับ", Order.RECEIVEDATE.ToString("dd/MM/yyyy") }));
            return false;
        }

        // data correct go on saving...
        if (Order.LOID != 0)
            ret = ftFlow.UpdateData(Order, Appz.CurrentUser);
        else
            ret = ftFlow.InsertData(Order, Appz.CurrentUser);

        if (!ret)
            SetErrorStatus(ftFlow.ErrorMessage);
        else
        {
            doGetDetail(ftFlow.LOID.ToString());
            if (Order.LOID != 0)
                SetStatus(DataResources.MSGIU001);
            else
                SetStatus(DataResources.MSGIN001);
        }

        return ret;
    }

    private string VerifyData(ReceiveData fData)
    {
        string ret = "";
        if (cmbOrederPlan.SelectedValue == "0")
            ret = string.Format(DataResources.MSGEI002, "แผนประมาณการ");
        else if (fData.PLANMATERIALCLASS == 0)
            ret = string.Format(DataResources.MSGEI002, "หมวดอาหาร");

        return ret;
    }

    protected void txtReceiveQty_TextChanged(object sender, EventArgs e)
    {
        TextBox txt = (TextBox)sender;
        Int16 rowIndex = (Int16)((GridViewRow)txt.Parent.Parent).RowIndex;
        TextBox txtNetPrice = (TextBox)this.gvItem.Rows[rowIndex].Cells[11].FindControl("txtNetPrice");

        double qty = Convert.ToDouble(txt.Text);
        double price = Convert.ToDouble("0" + this.gvItem.Rows[rowIndex].Cells[7].Text);
        double netprice = qty * price;

        txtNetPrice.Text = netprice.ToString("N2");
        CalculateGrantotal();
    }

    protected void gvItem_RowDataBound(object sender, GridViewRowEventArgs e)
    {
        if (e.Row.RowType == DataControlRowType.DataRow)
        {
            TextBox txtReceiveQty = (TextBox)e.Row.Cells[10].FindControl("txtReceiveQty");
            TextBox txtNetPrice = (TextBox)e.Row.Cells[11].FindControl("txtNetPrice");

            ControlUtil.SetDblTextBox(txtReceiveQty);
            ControlUtil.SetDblTextBox(txtNetPrice);
        }
    }

    private void CalculateGrantotal()
    {
        double total = 0;
        foreach (GridViewRow row in gvItem.Rows)
        {
            TextBox txtNetPrice = (TextBox)row.Cells[11].FindControl("txtNetPrice");
            total += Convert.ToDouble(txtNetPrice.Text);
        }
        txtTotal.Text = total.ToString("N2");
    }

    private void CalculateGranRemain()
    {
        PrePODivisionItemFlow fFlow = new PrePODivisionItemFlow();
        double remain = 0;
        remain = fFlow.GetRemainTotal(Convert.ToDouble(cmbOrederPlan.SelectedValue), Convert.ToDouble(txtMaterialClass.Text));
        txtRemain.Text = remain.ToString("N2");
    }

    protected void cmbOrederPlan_SelectedIndexChanged(object sender, EventArgs e)
    {
        Appz.BuildCombo(cmbMaterialClass, " V_PLANMATERIALCLASS", "CLASSNAME", "LOID", "PLANORDER = " + cmbOrederPlan.SelectedValue, "CLASSNAME", "เลือก", "0", false);
        txtSupplierCode.Text = "";
        txtSupplierName.Text = "";
        ReceiveItem fsItem = new ReceiveItem();
        ArrayList arrChk = new ArrayList();
        for (int i = 0; i < gvItem.Rows.Count; i++)
        {
            GridViewRow gRow = gvItem.Rows[i];
            arrChk.Add(Convert.ToDouble(gRow.Cells[0].Text));
        }
        if (fsItem.DeleteMaterialItem(arrChk))
            BindReceiveItem();
        txtTotal.Text = "0.00";
        txtRemain.Text = "0.00";
    }
    protected void cmbMaterialClass_SelectedIndexChanged(object sender, EventArgs e)
    {
        ReceiveFlow fFlow = new ReceiveFlow();
        SupplierData fData = fFlow.GetSupplier(Convert.ToDouble(cmbOrederPlan.SelectedValue), Convert.ToDouble(cmbMaterialClass.SelectedValue));
        txtSupplierCode.Text = fData.CODE;
        txtSupplierName.Text = fData.NAME;
        txtMaterialClass.Text = fData.LOID.ToString();
        txtFax.Text = fData.FAX;
        txtTel.Text = fData.TEL;

        ReceiveItem fsItem = new ReceiveItem();
        ArrayList arrChk = new ArrayList();
        for (int i = 0; i < gvItem.Rows.Count; i++)
        {
            GridViewRow gRow = gvItem.Rows[i];
            arrChk.Add(Convert.ToDouble(gRow.Cells[0].Text));
        }
        if (fsItem.DeleteMaterialItem(arrChk))
            BindReceiveItem();
        txtTotal.Text = "0.00";
        CalculateGranRemain();
    }

    #endregion


}
