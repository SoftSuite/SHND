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
/// Formula Feed Detail Page Class
/// Version 1.0
/// =========================================================================
/// Create by: Tan
/// Create Date: 19 Feb 2009
/// -------------------------------------------------------------------------
/// Modify By: -
/// Modify From: -
/// Modify Date: -
/// -------------------------------------------------------------------------
/// Remark: -
/// Description:
///    หน้ากาารทำงานข้อมูล PrePO Division
/// Changes:
///    1.0 - สร้าง
/// -------------------------------------------------------------------------
/// =========================================================================
/// </summary>
/// 

public partial class App_Purchase_Transaction_PrePO : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            doGetDetail((Request["loid"] == null ? "0" : Request["loid"]));
            ControlUtil.SetDblTextBox(txtTotal);
            ControlUtil.SetDblTextBox(txtRemain);
        }
    }

    protected override void OnInit(EventArgs e)
    {
        base.OnInit(e);

        Appz.BuildCombo(cmbOrederPlan, "PLANORDER", "NAME", "LOID", "ISPLANFOOD = 'Y' AND STATUS = 'FN' ", "NAME", "เลือก", "0", false);

    }
    protected void ctlPrePOPopup_SelectedIndexChanged(object sender, EventArgs e, ArrayList arrData)
    {
        PrePODivisionItem fsItem = new PrePODivisionItem();
        if (fsItem.InsertMaterialItem(Convert.ToDouble("0" + this.txtLOID.Text), Convert.ToDouble("0" + this.cmbOrederPlan.SelectedValue), Convert.ToDouble("0" + this.txtDivision.Text), arrData))
            BindPrePOItem();
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
        Response.Redirect(Constant.HomeFolder + "App_Purchase/Transaction/PrePODivisionSearch.aspx");
    }
    //protected void tbPrintClick(object sender, EventArgs e)
    //{
    //}
    protected void tbApproveClick(object sender, EventArgs e)
    {
        doApprove();
    }

    protected void linkCode_Click(object sender, EventArgs e)
    {
        int rowIndex = ((GridViewRow)((LinkButton)sender).Parent.Parent).RowIndex;
        SetSpecData(rowIndex);
    }
    protected void lnkDelivery_Click(object sender, EventArgs e)
    {
        int rowIndex = ((GridViewRow)((LinkButton)sender).Parent.Parent).RowIndex;
        SetDeliveryData(rowIndex);
    }

    protected void imbReturn_Click(object sender, ImageClickEventArgs e)
    {
        int rowIndex = ((GridViewRow)((ImageButton)sender).Parent.Parent).RowIndex;
        ReturnMaterialDelivery(rowIndex);
    }

    protected void tbBackDetailClick(object sender, EventArgs e)
    {
        double total = 0;
        foreach (GridViewRow row in gvDetail.Rows)
        {
            Label txt = (Label)row.Cells[4].FindControl("lblDueQty");
            total += Convert.ToDouble(txt.Text);
        }
        if (total != Convert.ToDouble(lblMaterialQty.Text))
        {
            this.ctlDetailPopup.Show();
            SetErrorStatusDelivery("จำนวนรวม(" + total.ToString() + ") ไม่เท่ากับจำนวนที่สั่งซื้อ(" + lblMaterialQty.Text + ")");
        }

    }

    #endregion

    #region FormulaDisease Toolbar
    protected void tbAddPOItemClick(object sender, EventArgs e)
    {
        if (cmbOrederPlan.SelectedValue == "0" || txtMaterialClass.Text == "0")
        {
            SetErrorStatus(string.Format(DataResources.MSGEI002, "หมวดอาหาร"));
        }
        else
        {
            UpdatePrePODivisionItem();
            PrePODivisionItem fsItem = new PrePODivisionItem();
            this.ctlPrePOPopup.Show(Convert.ToDouble(cmbOrederPlan.SelectedValue), Convert.ToDouble(txtMaterialClass.Text), fsItem.getMaterialList());
        }
    }
    protected void tbDeletePOItemClick(object sender, EventArgs e)
    {
        UpdatePrePODivisionItem();
        PrePODivisionItem fsItem = new PrePODivisionItem();
        if (fsItem.DeleteMaterialItem(GetCheckedOrderParty())) BindPrePOItem();
        CalculateGrantotal();
    }
    protected void tbCalculateClick(object sender, EventArgs e)
    {
        if (cmbOrederPlan.SelectedValue == "0" || txtMaterialClass.Text == "0")
        {
            SetErrorStatus(string.Format(DataResources.MSGEI002, "หมวดอาหาร"));
        }
        else
        {
            PrePODivisionItem fsItem = new PrePODivisionItem();
            fsItem.getMaterialListMenu(Convert.ToDouble(cmbOrederPlan.SelectedValue), Convert.ToDouble(txtDivision.Text), ctlUseDate.DateValue, Convert.ToDouble(cmbMaterialClass.SelectedValue));
            BindPrePOItem();
            CalculateGrantotal();
           // CalculateGranRemain();
        }
    }
    #endregion

    #region GridView Event Handler

    protected void gvDetail_RowCommand(object sender, GridViewCommandEventArgs e)
    {
        Templates_CalendarControl ctlDate = (Templates_CalendarControl)this.gvDetail.FooterRow.Cells[3].FindControl("ctlNewDate");
        TextBox txtQty = (TextBox)this.gvDetail.FooterRow.Cells[4].FindControl("txtNewQty");

        PrePODivisionItem item = new PrePODivisionItem();

        if (e.CommandName == "Insert")
        {
            DateTime date = ctlDate.DateValue;
            double qty = Convert.ToDouble("0" + txtQty.Text);

            if (item.InsertDeliveryItem(date, qty, txtMaterialID.Text))
            {
                SetGrvItem();
            }
            else
            {
                SetErrorStatusDelivery(item.ErrorMessage);
            }
        }
        this.ctlDetailPopup.Show();
    }

    protected void gvDetail_RowUpdated(object sender, GridViewUpdatedEventArgs e)
    {
        e.ExceptionHandled = (e.Exception != null);
        if (e.ExceptionHandled)
        {
            e.KeepInEditMode = true;
            SetErrorStatusDelivery(e.Exception.InnerException.Message);
        }
    }

    protected void gvDetail_RowUpdating(object sender, GridViewUpdateEventArgs e)
    {
        Templates_CalendarControl ctlEditDate = (Templates_CalendarControl)this.gvDetail.Rows[e.RowIndex].Cells[3].FindControl("ctlEditDate");
        TextBox txtEditQty = (TextBox)this.gvDetail.Rows[e.RowIndex].Cells[4].FindControl("txtEditQty");

        e.NewValues["DUEDATE"] = ctlEditDate.DateValue;
        e.NewValues["DUEQTY"] = Convert.ToDouble("0" + txtEditQty.Text);
        e.NewValues["PrePO"] = Convert.ToDouble("0" + this.txtLOID.Text);
    }

    protected void gvDetail_RowDataBound(object sender, GridViewRowEventArgs e)
    {
        if (e.Row.RowType == DataControlRowType.DataRow)
        {
            if (e.Row.RowState == (DataControlRowState.Edit | DataControlRowState.Alternate) || e.Row.RowState == DataControlRowState.Edit)
            {
                ImageButton imbCancel = (ImageButton)e.Row.FindControl("imbCancel");

                imbCancel.OnClientClick = "return confirm('ยืนยันการยกเลิกรายการ');";
            }
            else if (e.Row.RowState == DataControlRowState.Normal || e.Row.RowState == DataControlRowState.Alternate)
            {
                ImageButton imbDelete = (ImageButton)e.Row.FindControl("imbDelete");

                imbDelete.OnClientClick = "return confirm('ยืนยันการลบรายการ');";
            }
        }
        else if (e.Row.RowType == DataControlRowType.Footer)
        {

        }
    }

    private void ReturnMaterialDelivery(int RowIndex)
    {
        //PrePODivisionItem item = new PrePODivisionItem();
        //if (item.UpdateMaterialDelivery(Convert.ToDouble("0" + this.txtLOID.Text), Convert.ToDouble("0" + this.txtMaterialID.Text), Convert.ToDouble("0" + this.gvDetail.Rows[RowIndex].Cells[1].Text)))
        //    this.gvDetail.DataBind();
    }

    protected void gvDetail_RowDeleted(object sender, GridViewDeletedEventArgs e)
    {
        if (e.ExceptionHandled)
        {
           // SetErrorStatusDelivery(e.Exception.Message);
            //Appz.ClientAlert(this, e.Exception.Message);
        }
        else
        {
            SetGrvItem();
        }
    }

    protected void grvItemNew_RowCommand(object sender, GridViewCommandEventArgs e)
    {
        Int16 rowIndex = 0;
        Templates_CalendarControl ctlDate = (Templates_CalendarControl)this.grvItemNew.Rows[rowIndex].Cells[2].FindControl("ctlDate");
        TextBox txtQty = (TextBox)this.grvItemNew.Rows[rowIndex].Cells[3].FindControl("txtQty");

        PrePODivisionItem item = new PrePODivisionItem();

        if (e.CommandName == "Insert")
        {
            DateTime date = ctlDate.DateValue;
            double qty = Convert.ToDouble("0" + txtQty.Text);

            if (item.InsertDeliveryItem(date, qty, txtMaterialID.Text))
            {
                SetGrvItem();
            }
            else
                SetErrorStatusDelivery(item.ErrorMessage);
            //Appz.ClientAlert(this, ItemObj.ErrorMessage);
        }
        this.ctlDetailPopup.Show();
    }

    protected void grvItemNew_RowDataBound(object sender, GridViewRowEventArgs e)
    {
        //if (e.Row.RowType == DataControlRowType.DataRow)
        //{
        //    if (this.txtStockoutItemLoid.Text != "0")
        //    {
        //        string tableName = "(SELECT * FROM REPAIRSTATUS WHERE STOCKOUTITEM = '" + this.txtStockoutItemLoid.Text + "')";
        //    }
        //}
    }

    protected void gvItem_RowDataBound(object sender, GridViewRowEventArgs e)
    {
        if (e.Row.RowType == DataControlRowType.DataRow)
        {
            TextBox txtOrderQty = (TextBox)e.Row.Cells[8].FindControl("txtOrderQty");
            TextBox txtNetPrice = (TextBox)e.Row.Cells[10].FindControl("txtNetPrice");

            ControlUtil.SetDblTextBox(txtOrderQty);
            ControlUtil.SetDblTextBox(txtNetPrice);
        }
    }

    private void SetGrvItem()
    {
        this.gvDetail.DataBind();
        this.grvItemNew.DataBind();

        if (gvDetail.Rows.Count > 0)
        {
            this.gvDetail.Visible = true;
            this.grvItemNew.Visible = false;
        }
        else
        {
            this.gvDetail.Visible = false;
            this.grvItemNew.Visible = true;
        }
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

    private void BindPrePOItem()
    {
        this.gvItem.DataBind();
    }

    private void BindMenu()
    {
        this.gvMenu.DataBind();
    }
    private void  BindDuedate()
    {
        SetGrvItem();
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

    private void SetDeliveryData(int rowIndex)
    {
        ClearDelivery();
        GridViewRow gRow = this.gvItem.Rows[rowIndex];
        this.txtRowIndex.Text = rowIndex.ToString();
        this.txtMaterialID.Text = gRow.Cells[17].Text;
        this.lblMaterialNameDetail.Text = gRow.Cells[5].Text + " (" + gRow.Cells[6].Text + ")";
        this.lblMaterialQty.Text = ((TextBox)gRow.Cells[9].FindControl("txtOrderQty")).Text;
        this.txtSpecView.Text = gRow.Cells[18].Text;
        SetGrvItem();
        this.ctlDetailPopup.Show();
    }
    private void ClearDelivery()
    {
        this.txtIsUpdated.Text = "";
        this.txtRowIndex.Text = "";
        this.txtMaterialID.Text = "";
        this.txtSpecView.Text = "";
        this.lblMaterialNameDetail.Text = "";
    }

    private PrePODivisionData GetData()
    {
        PrePODivisionData fsData = new PrePODivisionData();
        fsData.LOID = Convert.ToDouble(txtLOID.Text);
        fsData.DIVISION = Convert.ToDouble(txtDivision.Text);
        fsData.CODE = txtCode.Text;
        fsData.USEDATE = ctlUseDate.DateValue;
        fsData.BPODATE = ctlOrderDate.DateValue;
        fsData.PLANMATERIALCLASS = Convert.ToDouble(cmbMaterialClass.SelectedValue == "" ? "0" : cmbMaterialClass.SelectedValue);
        fsData.REMARKS = txtRemark.Text;
        fsData.STATUS = txtStatus.Text;
        fsData.PLAN = Convert.ToDouble(cmbOrederPlan.SelectedValue);

        PrePODivisionItem item = new PrePODivisionItem();
        fsData.PrePODivisionItem = GetPrePODivisionItem();
        fsData.PrePODuedate = item.GetMaterialDeliveryData();

        return fsData;
    }

    private void SetData(PrePODivisionData fsData)
    {
        txtLOID.Text = fsData.LOID.ToString();
        txtStatus.Text = fsData.STATUS;
        txtStatusName.Text = fsData.STATUSNAME;
        txtDivision.Text = fsData.DIVISION.ToString();
        txtDivisionName.Text = fsData.DIVISIONNAME;
        txtCode.Text = fsData.CODE;
        ctlOrderDate.DateValue = fsData.BPODATE;
        ctlUseDate.DateValue = fsData.USEDATE;
        txtRemark.Text = fsData.REMARKS;
        txtMaterialClass.Text = fsData.MATERIALCLASS.ToString();
        cmbOrederPlan.SelectedValue = fsData.PLAN.ToString();
        txtSupplierCode.Text = fsData.CONTACTCODE;
        txtSupplierName.Text = fsData.SUPPLIERNAME;
        //  this.tbPrint.ClientClick = Appz.OpenReportScript(Constant.Reports.FormulaFeedBDReport, fsData.LOID, false);

        if (fsData.LOID == 0)
        {
            this.txtStatus.Text = "WA";
            this.txtStatusName.Text = "กำลังดำเนินการ";
            this.txtDivision.Text = Appz.LoggedOnUser.DIVISION.ToString();
            this.txtDivisionName.Text = Appz.LoggedOnUser.DIVISIONNAME;
            this.ctlOrderDate.DateValue = DateTime.Now.Date;
            this.ctlUseDate.DateValue = DateTime.Now.AddDays(7).Date;
        }
        else
        {
            //Appz.BuildCombo(cmbMaterialClass, "MATERIALCLASS", "NAME", "LOID", "ACTIVE='1'", "NAME", "เลือก", "0", false);
            Appz.BuildCombo(cmbMaterialClass, " V_PLANMATERIALCLASS", "CLASSNAME", "LOID", "PLANORDER = " + cmbOrederPlan.SelectedValue, "CLASSNAME", "เลือก", "0", false);
            cmbMaterialClass.SelectedValue = fsData.PLANMATERIALCLASS.ToString();
        }
        if (fsData.STATUS == "AP")
        {
            tbSave.Visible = false;
            tbCancel.Visible = false;
            tbApprove.Visible = false;
            tbAddPOItem.Visible = false;
            tbDeletePOItem.Visible = false;
        }

        PrePODivisionItem fsItem = new PrePODivisionItem();
        fsItem.ClearAllSession();
        BindPrePOItem();
        BindMenu();
        CalculateGrantotal();
        CalculateGranRemain();

    }

    private ArrayList GetPrePODivisionItem()
    {
        ArrayList arrData = new ArrayList();
        for (int i = 0; i < this.gvItem.Rows.Count; ++i)
        {
            CheckBox chkVat = (CheckBox)this.gvItem.Rows[i].Cells[12].FindControl("chkVat");

            PrePOItemData OrderItem = new PrePOItemData();
            OrderItem.PREPO = Convert.ToDouble("0" + this.txtLOID.Text);
            OrderItem.MATERIALMASTER = Convert.ToDouble("0" + this.gvItem.Rows[i].Cells[15].Text);
            OrderItem.UNIT = Convert.ToDouble("0" + this.gvItem.Rows[i].Cells[16].Text);
            OrderItem.PRICE = Convert.ToDouble("0" + this.gvItem.Rows[i].Cells[7].Text);
            OrderItem.MENUQTY = Convert.ToDouble("0" + this.gvItem.Rows[i].Cells[8].Text);
            OrderItem.ORDERQTY = Convert.ToDouble("0" + ((TextBox)this.gvItem.Rows[i].Cells[9].FindControl("txtOrderQty")).Text);
            OrderItem.PLANREMAINQTY = Convert.ToDouble("0" + this.gvItem.Rows[i].Cells[10].Text);
            OrderItem.NETPRICE = Convert.ToDouble("0" + ((TextBox)this.gvItem.Rows[i].Cells[11].FindControl("txtNetPrice")).Text);
            OrderItem.REMARKS = ((TextBox)this.gvItem.Rows[i].Cells[14].FindControl("txtRemark")).Text;
            OrderItem.CODE = this.gvItem.Rows[i].Cells[17].Text.ToString();
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

    private void UpdatePrePODivisionItem()
    {
        PrePODivisionItem fsItem = new PrePODivisionItem();
        if (!fsItem.UpdateMaterialItem(Convert.ToDouble("0" + this.txtLOID.Text), GetPrePODivisionItem()))
            SetErrorStatusPOItem(DataResources.MSGEC102);
        else
            SetStatusPOItem(DataResources.MSGIU001);
    }

    private bool doGetDetail(string LOID)
    {
        PrePODivisionItemFlow fFlow = new PrePODivisionItemFlow();
        PrePODivisionData fData = fFlow.GetDetails(Convert.ToDouble(LOID));

        bool ret = true;
        SetData(fData);
        PrePODivisionItem fsItem = new PrePODivisionItem();
        fsItem.ClearAllSession();
        BindPrePOItem();
        BindMenu();
        BindDuedate();

        return ret;
    }

    private bool doSave()
    {
        //verify required field
        PrePODivisionData Order = GetData();
        string error = VerifyData(Order);
        if (error != "")
        {
            SetErrorStatus(error);
            return false;
        }

        PrePODivisionItemFlow ftFlow = new PrePODivisionItemFlow();
        bool ret = true;

        if (!ftFlow.CheckUniqueKey(Order.LOID, Order.DIVISION,Order.PLANMATERIALCLASS,Order.USEDATE))
        {
            SetErrorStatus(string.Format(DataResources.MSGEI016, new string[] { "แผนประมาณการ", this.cmbOrederPlan.SelectedItem.Text, "วันที่ใช้", Order.USEDATE.ToString(Constant.DateFormat) }));
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
        PrePODivisionData Order = GetData();
        Order.STATUS = "AP";
        string error = VerifyData(Order);
        if (error != "")
        {
            SetErrorStatus(error);
            return false;
        }
        error = VerifyAP();
        if (error != "")
        {
            SetErrorStatus(error);
            return false;
        }

        PrePODivisionItemFlow ftFlow = new PrePODivisionItemFlow();
        bool ret = true;

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

    private string VerifyData(PrePODivisionData fData)
    {
        string ret = "";
        if (fData.PLAN == 0)
            ret = string.Format(DataResources.MSGEI002, "แผนประมาณการ");
        else if (fData.PLANMATERIALCLASS == 0)
            ret = string.Format(DataResources.MSGEI002, "หมวดอาหาร");
        else if (fData.BPODATE.Year == 1)
            ret = string.Format(DataResources.MSGEI002, "วันที่สั่งซื้อ");
        else if (fData.USEDATE.Year == 1)
            ret = string.Format(DataResources.MSGEI002, "วันที่ใช้");
        else if (this.gvItem.Rows.Count == 0)
            ret = string.Format(DataResources.MSGEI001, "รายการวัสดุอาหาร");

        return ret;
    }

    private string VerifyAP()
    {
        string ret = "";
        foreach (GridViewRow row in gvItem.Rows)
        { 
            TextBox txtOrderQty = (TextBox)row.Cells[9].FindControl("txtOrderQty");
            double OrderQty = Convert.ToDouble(txtOrderQty.Text==""?"0":txtOrderQty.Text);
            if (OrderQty == 0)
            {
                ret = string.Format(DataResources.MSGEI001, "จำนวนสั่งซื้อ");
                break;
            }
        }
        return ret;
    }

    protected void txtOrderQty_TextChanged(object sender, EventArgs e)
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
        PrePODivisionItem fsItem = new PrePODivisionItem();
        ArrayList arrChk = new ArrayList();
        for (int i = 0; i < gvItem.Rows.Count; i++)
        {
            GridViewRow gRow = gvItem.Rows[i];
            arrChk.Add(Convert.ToDouble(gRow.Cells[0].Text));
        }
        if (fsItem.DeleteMaterialItem(arrChk))
            BindPrePOItem(); 
        txtTotal.Text = "0.00";
        txtRemain.Text = "0.00";
    }
    protected void cmbMaterialClass_SelectedIndexChanged(object sender, EventArgs e)
    {
        PrePODivisionItemFlow fFlow = new PrePODivisionItemFlow();
        SupplierData fData = fFlow.GetSupplier(Convert.ToDouble(cmbOrederPlan.SelectedValue), Convert.ToDouble(cmbMaterialClass.SelectedValue));
        txtSupplierCode.Text = fData.CODE;
        txtSupplierName.Text = fData.NAME;
        txtMaterialClass.Text = fData.LOID.ToString();
        PrePODivisionItem fsItem = new PrePODivisionItem();
        ArrayList arrChk = new ArrayList();
        for (int i = 0; i < gvItem.Rows.Count; i++)
        {
            GridViewRow gRow = gvItem.Rows[i];
            arrChk.Add(Convert.ToDouble(gRow.Cells[0].Text));
        }
        if (fsItem.DeleteMaterialItem(arrChk)) 
            BindPrePOItem();
        txtTotal.Text = "0.00";
        CalculateGranRemain();
    }
    protected void ctlUseDate_SelectedDateChanged(object sender, EventArgs e)
    {
        BindMenu();
    }
    #endregion

}
