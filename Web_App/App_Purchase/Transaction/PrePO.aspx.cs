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
/// Create Date: 1 March 2009
/// -------------------------------------------------------------------------
/// Modify By: Nang
/// Modify From: 3 July 2009
/// Modify Date: เพิ่มปุ่มข้อมูลจากหน่วยงาน
/// -------------------------------------------------------------------------
/// Remark: -
/// Description:
///    หน้ากาารทำงานข้อมูล PrePO 
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
        Appz.BuildCombo(cmbDivision, "DIVISION", "NAME", "LOID", "", "NAME", "ทั้งหมด", "0", false);
        // ControlUtil.SetIntTextBox(txtTel);
        //ControlUtil.SetIntTextBox(txtQty);
        pcTop.SetMainGridView(gvDivision);
        pcBot.SetMainGridView(gvDivision);
    }
    protected void ctlPrePOPopup_SelectedIndexChanged(object sender, EventArgs e, ArrayList arrData)
    {
        PrePOItem fsItem = new PrePOItem();
        if (fsItem.InsertMaterialItem(Convert.ToDouble("0" + this.txtLOID.Text), Convert.ToDouble("0" + this.cmbOrederPlan.SelectedValue), Convert.ToDouble("0" + this.txtDivision.Text), arrData))
            BindPrePOItem();
        CalculateGranRemain();
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
        Response.Redirect(Constant.HomeFolder + "App_Purchase/Transaction/PrePOSearch.aspx");
    }
    protected void tbPrintClick(object sender, EventArgs e)
    {
        this.tbPrint.ClientClick = Appz.OpenReportScript(Constant.Reports.RepPrePO, Convert.ToDouble("0" + txtLOID.Text), false);
    }
    protected void tbPrintPOVATClick(object sender, EventArgs e)
    {
        this.tbPrintPOVAT.ClientClick = Appz.OpenReportScript(Constant.Reports.RepPO, Convert.ToDouble("0" + txtPOVAT.Text), false);
    }
    protected void tbPrintPONOVATClick(object sender, EventArgs e)
    {
        this.tbPrintPONOVAT.ClientClick = Appz.OpenReportScript(Constant.Reports.RepPO, Convert.ToDouble("0" + txtPONOVAT.Text), false);
    }
    protected void tbApproveClick(object sender, EventArgs e)
    {
        doApprove();
    }
    protected void tbFinishClick(object sender, EventArgs e)
    {
        doFinish();
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
            total = total + Convert.ToDouble(txt.Text);
        }
        if (Math.Round(total,2) != Math.Round(Convert.ToDouble(lblMaterialQty.Text),2))
        {
            this.ctlDetailPopup.Show();
            SetErrorStatusDelivery("จำนวนรวม(" + total.ToString() + ") ไม่เท่ากับจำนวนที่สั่งซื้อ(" + lblMaterialQty.Text + ")");
        }
    }

    protected void imgSearch_Click(object sender, ImageClickEventArgs e)
    {
        DoGetListDivision();
        zPop.Show();
    }

    protected void imbReset_Click(object sender, ImageClickEventArgs e)
    {
        ClearSearch();
        gvDivision.PageIndex = 0;
        DoGetListDivision();
        zPop.Show();
    }

    protected void tbDivisionClick(object sender, EventArgs e)
    {
        DoGetListDivision();
        zPop.Show();
    }

    protected void tbBackDivisionClick(object sender, EventArgs e)
    {
        cmbMClass.SelectedIndex = -1;
        cmbDivision.SelectedIndex = -1;
        txtMName.Text = "";
        gvDivision.DataSource = null;
        gvDivision.DataBind();
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
            UpdatePrePOItem();
            PrePOItem fsItem = new PrePOItem();
            this.ctlPrePOPopup.Show(Convert.ToDouble(cmbOrederPlan.SelectedValue), Convert.ToDouble(txtMaterialClass.Text), fsItem.getMaterialList());
        }
    }
    protected void tbDeletePOItemClick(object sender, EventArgs e)
    {
        PrePOItem fsItem = new PrePOItem();
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
            PrePOItem fsItem = new PrePOItem();
            fsItem.getMaterialListMenu(Convert.ToDouble(cmbOrederPlan.SelectedValue), Convert.ToDouble(cmbMaterialClass.SelectedValue), ctlUseDate.DateValue);
            BindPrePOItem();
            CalculateGrantotal();
        }
    }
    #endregion

    #region GridView Event Handler

    protected void gvDetail_RowCommand(object sender, GridViewCommandEventArgs e)
    {
        Templates_CalendarControl ctlDate = (Templates_CalendarControl)this.gvDetail.FooterRow.Cells[3].FindControl("ctlNewDate");
        TextBox txtQty = (TextBox)this.gvDetail.FooterRow.Cells[4].FindControl("txtNewQty");

        PrePOItem item = new PrePOItem();

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
        //PrePOItem item = new PrePOItem();
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

        PrePOItem item = new PrePOItem();

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

    protected void gvItem_RowDataBound(object sender, GridViewRowEventArgs e)
    {
        if (e.Row.RowType == DataControlRowType.DataRow)
        {
            LinkButton lnkDelivery = (LinkButton)e.Row.FindControl("lnkDelivery");
            TextBox txtOrderQty = (TextBox)e.Row.Cells[9].FindControl("txtOrderQty");
            TextBox txtRemark = (TextBox)e.Row.Cells[15].FindControl("txtRemark"); 
            if (e.Row.Cells[1].Text == "0")              
                lnkDelivery.Visible = false;
            if (txtStatus.Text == "AP" || txtStatus.Text == "FN")
            {
                txtOrderQty.ReadOnly = true;
                txtOrderQty.CssClass = "zTextbox-View";
                txtRemark.ReadOnly = true;
                txtRemark.CssClass = "zTextbox-View";
            }
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

    protected void gvDivision_RowDataBound(object sender, GridViewRowEventArgs e)
    {
        if (e.Row.RowIndex > -1)
            e.Row.Cells[1].Text = ((e.Row.RowIndex + 1) + (gvDivision.PageIndex * gvDivision.PageSize)).ToString();
    }

    #endregion

    #region Paging Event Handler
    protected void PageChange(object sender, EventArgs e)
    {
        gvDivision.PageIndex = ((Templates_PageControl)sender).SelectedPageIndex;
        DoGetListDivision();
        pcBot.Update();
        pcTop.Update();
        zPop.Show();
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
    private void BindDuedate()
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
        //fsData.DIVISION = Convert.ToDouble(txtDivision.Text);
        fsData.CODE = txtCode.Text;
        fsData.USEDATE = ctlUseDate.DateValue;
        fsData.BPODATE = ctlOrderDate.DateValue;
        fsData.PLANMATERIALCLASS = Convert.ToDouble(cmbMaterialClass.SelectedValue == "" ? "0" : cmbMaterialClass.SelectedValue);
        fsData.REMARKS = txtRemark.Text;
        fsData.STATUS = txtStatus.Text;
        fsData.PLAN = Convert.ToDouble(cmbOrederPlan.SelectedValue);
        fsData.CNAME = txtContract.Text;
        fsData.ADDRESS = txtAddress.Text;
        fsData.TEL = txtTel.Text;
        fsData.FAX = txtFax.Text;

        PrePOItem item = new PrePOItem();
        fsData.PrePODivisionItem = GetPrePOItem();
        fsData.PrePODuedate = item.GetMaterialDeliveryData();

        return fsData;
    }

    private void SetData(PrePODivisionData fsData)
    {
        txtLOID.Text = fsData.LOID.ToString();
        txtPOVAT.Text = fsData.POVAT.ToString();
        txtPONOVAT.Text = fsData.PONOVAT.ToString();
        txtStatus.Text = fsData.STATUS;
        txtStatusName.Text = fsData.STATUSNAME;
        txtCode.Text = fsData.CODE;
        ctlOrderDate.DateValue = fsData.BPODATE;
        ctlUseDate.DateValue = fsData.USEDATE;
        txtRemark.Text = fsData.REMARKS;
        cmbOrederPlan.SelectedValue = fsData.PLAN.ToString();
        txtMaterialClass.Text = fsData.MATERIALCLASS.ToString();
        txtSupplierCode.Text = fsData.CONTACTCODE;
        txtSupplierName.Text = fsData.SUPPLIERNAME;
        txtAddress.Text = fsData.ADDRESS;
        txtContract.Text = fsData.CNAME;
        txtTel.Text = fsData.TEL;
        txtFax.Text = fsData.FAX;
        this.tbFinish.Visible = (fsData.STATUS == "AP");
        this.tbPrintPOVAT.Visible = (fsData.STATUS == "FN");
        this.tbPrintPONOVAT.Visible = (fsData.STATUS == "FN");

        if (fsData.LOID == 0)
        {
            this.txtStatus.Text = "WA";
            this.txtStatusName.Text = "กำลังดำเนินการ";
            this.ctlOrderDate.DateValue = DateTime.Now.Date;
            this.ctlUseDate.DateValue = DateTime.Now.AddDays(7).Date;
            //this.tbFinish.Visible = false;
        }
        else
        {
            Appz.BuildCombo(cmbMaterialClass, " V_PLANMATERIALCLASS", "CLASSNAME", "LOID", "PLANORDER = " + fsData.PLAN.ToString(), "CLASSNAME", "เลือก", "0", false);
            cmbMaterialClass.SelectedValue = fsData.PLANMATERIALCLASS.ToString();
            Appz.BuildCombo(cmbMClass, "MATERIALGROUP", "NAME", "LOID", "MATERIALCLASS IN (SELECT MATERIALCLASS FROM PLANMATERIALCLASS WHERE LOID = " + cmbMaterialClass.SelectedValue + ") ", "NAME", "ทั้งหมด", "0", false);   

        }
        if (fsData.STATUS == "AP" || fsData.STATUS == "FN")
        {
            tbSave.Visible = false;
            tbCancel.Visible = false;
            tbApprove.Visible = false;
            tbCalculate.Visible = false;
            cmbOrederPlan.Enabled = false;
            cmbMaterialClass.Enabled = false;
            txtAddress.ReadOnly = true;
            txtAddress.CssClass = "zTextbox-View";
            txtContract.ReadOnly = true;
            txtContract.CssClass = "zTextbox-View";
            txtFax.ReadOnly = true;
            txtFax.CssClass = "zTextbox-View";
            txtTel.ReadOnly = true;
            txtTel.CssClass = "zTextbox-View";
            ctlUseDate.Enabled = false;
            txtRemark.ReadOnly = true;
            txtRemark.CssClass = "zTextbox-View";
        }

        this.tbPrint.ClientClick = Appz.OpenReportScript(Constant.Reports.RepPrePO, Convert.ToDouble("0" + txtLOID.Text), false);
        this.tbPrintPOVAT.ClientClick = Appz.OpenReportScript(Constant.Reports.RepPO, Convert.ToDouble("0" + txtPOVAT.Text), false);
        this.tbPrintPONOVAT.ClientClick = Appz.OpenReportScript(Constant.Reports.RepPO, Convert.ToDouble("0" + txtPONOVAT.Text), false);


        PrePOItem fsItem = new PrePOItem();
        fsItem.ClearAllSession();
        BindPrePOItem();
        BindMenu();
        CalculateGrantotal();
        CalculateGranRemain();

    }

    private ArrayList GetPrePOItem()
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
            OrderItem.PLANREMAINQTY = Convert.ToDouble((this.gvItem.Rows[i].Cells[10].Text==""?"0":this.gvItem.Rows[i].Cells[10].Text));
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

    private ArrayList GetPOItem()
    {
        ArrayList arrData = new ArrayList();
        PrePOFlow fFlow = new PrePOFlow();
        DataTable dt = fFlow.GetPOList(Convert.ToDouble("0" + this.txtLOID.Text));
        for (int i = 0; i < dt.Rows.Count; ++i)
        {
            PrePOItemData OrderItem = new PrePOItemData();
            OrderItem.PREPO = Convert.ToDouble("0" + this.txtLOID.Text);
            OrderItem.MATERIALMASTER = Convert.ToDouble("0" + dt.Rows[i]["MATERIALMASTER"].ToString());
            OrderItem.UNIT = Convert.ToDouble("0" + dt.Rows[i]["UNIT"].ToString());
            OrderItem.PRICE = Convert.ToDouble("0" + dt.Rows[i]["PRICE"].ToString());
            OrderItem.MENUQTY = 0;
            OrderItem.ORDERQTY = Convert.ToDouble("0" + dt.Rows[i]["RECEIVEQTY"].ToString());
            OrderItem.PLANREMAINQTY = Convert.ToDouble(dt.Rows[i]["PLANREMAINQTY"].ToString());
            OrderItem.NETPRICE = Convert.ToDouble("0" + dt.Rows[i]["NETPRICE"].ToString());
            OrderItem.REMARKS = dt.Rows[i]["REMARKS"].ToString();
            OrderItem.CODE = "";
            OrderItem.USEQTY = Convert.ToDouble("0" + dt.Rows[i]["USEQTY"].ToString());
            OrderItem.ISVAT = dt.Rows[i]["ISVAT"].ToString();

            arrData.Add(OrderItem);
        }
        return arrData;
    }


    private void ClearSearch()
    {
        cmbDivision.SelectedIndex = -1;
        cmbMClass.SelectedIndex = -1;
        txtMName.Text = "";
    }
    #endregion

    #region Working Method

    private void UpdatePrePOItem()
    {
        PrePOItem fsItem = new PrePOItem();
        if (!fsItem.UpdateMaterialItem(Convert.ToDouble("0" + this.txtLOID.Text), GetPrePOItem()))
            SetErrorStatusPOItem(DataResources.MSGEC102);
        else
            SetStatusPOItem(DataResources.MSGIU001);
    }

    private bool doGetDetail(string LOID)
    {
        PrePOFlow fFlow = new PrePOFlow();
        PrePODivisionData fData = fFlow.GetDetails(Convert.ToDouble(LOID));

        bool ret = true;
        SetData(fData);
        //PrePOItem fsItem = new PrePOItem();
        //fsItem.ClearAllSession();
        //BindPrePOItem();
        //BindMenu();
        //BindDuedate();

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

        PrePOFlow ftFlow = new PrePOFlow();
        bool ret = true;

        if (!ftFlow.CheckUniqueKey(Order.LOID, Order.PLANMATERIALCLASS, Order.USEDATE))
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

        PrePOFlow ftFlow = new PrePOFlow();
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

    private bool doFinish()
    {
        //verify required field
        PrePODivisionData Order = GetData();
        Order.STATUS = "FN";
        Order.PrePODivisionItem = GetPOItem();
       // string error = VerifyData(Order);
       // if (error != "")
       // {
       //     SetErrorStatus(error);
       //     return false;
       // }

        PrePOFlow ftFlow = new PrePOFlow();
        bool ret = true;

        // data correct go on saving...
        ret = ftFlow.UpdateFinishStatus(Order, Appz.CurrentUser);

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
            ret = string.Format(DataResources.MSGEI001, "วันที่ใช้");
        else if (this.gvItem.Rows.Count == 0)
            ret = string.Format(DataResources.MSGEI001, "รายการวัสดุอาหาร");
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

        txtNetPrice.Text = netprice.ToString();
        CalculateGrantotal();
    }

    private void CalculateGrantotal()
    {
        double total = 0;
        foreach (GridViewRow row in gvItem.Rows)
        {
            TextBox txtNetPrice = (TextBox)row.Cells[11].FindControl("txtNetPrice");
            total += Convert.ToDouble("0" + txtNetPrice.Text.Replace(",",""));
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
    }
    protected void cmbMaterialClass_SelectedIndexChanged(object sender, EventArgs e)
    {
        Appz.BuildCombo(cmbMClass, "MATERIALGROUP", "NAME", "LOID", "MATERIALCLASS IN (SELECT MATERIALCLASS FROM PLANMATERIALCLASS WHERE LOID = " + cmbMaterialClass.SelectedValue +") ", "NAME", "ทั้งหมด", "0", false);   
        PrePOFlow fFlow = new PrePOFlow();
        SupplierData fData = fFlow.GetSupplier(Convert.ToDouble(cmbOrederPlan.SelectedValue), Convert.ToDouble(cmbMaterialClass.SelectedValue));
        txtSupplierCode.Text = fData.CODE;
        txtSupplierName.Text = fData.NAME;
        txtMaterialClass.Text = fData.LOID.ToString();
        txtContract.Text = fData.CONTACTNAME;
        txtAddress.Text = fData.FULLADDRESS;
        txtTel.Text = fData.TEL;
        txtFax.Text = fData.FAX;

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


    private void DoGetListDivision()
    {
        imbReset.Visible = (cmbDivision.SelectedItem.Value.ToString() != "0") || (cmbMClass.SelectedItem.Value.ToString() != "0") || (txtMName.Text.Trim() != "");
        if (cmbOrederPlan.SelectedItem.Value.ToString() == "0")
        {
            SetStatusPOItem("กรุณาระบุแผนประมาณการ");
        }
        else if (cmbMaterialClass.SelectedItem.Value.ToString() == "0")
        {
            SetStatusPOItem("กรุณาระบุหมวดอาหาร");
        }
        else if (ctlUseDate.DateValue.Year.ToString() == "1")
        {
            SetStatusPOItem("กรุณาระบุวันที่ใช้");

        }
        else if (cmbOrederPlan.SelectedItem.Value.ToString() != "0" && cmbMaterialClass.SelectedItem.Value.ToString() != "0" && ctlUseDate.DateValue.Year.ToString() != "1")
        {
            PrePOFlow pFlow = new PrePOFlow();
            DataTable dt = new DataTable();
            dt = pFlow.GetDivisionDataSearch(Convert.ToDouble("0" + cmbOrederPlan.SelectedItem.Value.ToString()),
                Convert.ToDouble("0" + cmbMaterialClass.SelectedItem.Value.ToString()), 
                ctlUseDate.DateValue,Convert.ToDouble("0"+cmbDivision.SelectedItem.Value.ToString()),
                Convert.ToDouble("0"+ cmbMClass.SelectedItem.Value.ToString()),txtMName.Text.Trim());
            gvDivision.DataSource = dt;
            gvDivision.DataBind();
            pcTop.Update();
            pcBot.Update();
        }
    }
    #endregion



   
}
