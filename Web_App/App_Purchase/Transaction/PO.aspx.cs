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
/// Create Date: 31 March 2009
/// -------------------------------------------------------------------------
/// Modify By: -
/// Modify From: -
/// Modify Date: -
/// -------------------------------------------------------------------------
/// Remark: -
/// Description:
///    หน้ากาารทำงานข้อมูล PO
/// Changes:
///    1.0 - สร้าง
/// -------------------------------------------------------------------------
/// =========================================================================
/// </summary>
/// 

public partial class App_Purchase_Transaction_PO : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            doGetDetail((Request["loid"] == null ? "0" : Request["loid"]));
            ControlUtil.SetDblTextBox(txtTotal);
            ControlUtil.SetDblTextBox(txtRemain);
            ControlUtil.SetDblTextBox(txtTotalVat);
            ControlUtil.SetDblTextBox(txtGrandTotal);
        }
    }
    protected override void OnInit(EventArgs e)
    {
        base.OnInit(e);
    }

    #region Button Click Event Handler

    protected void imbSearch_Click(object sender, ImageClickEventArgs e)
    {
        this.ctlPOPopup.Show();
    }
    protected void tbSaveClick(object sender, EventArgs e)
    {
        doSave();
    }

    protected void linkCode_Click(object sender, EventArgs e)
    {
        int rowIndex = ((GridViewRow)((LinkButton)sender).Parent.Parent).RowIndex;
        SetSpecData(rowIndex);
    }

    protected void tbCancelClick(object sender, EventArgs e)
    {
        doGetDetail("0" + this.txtLOID.Text);
    }
    protected void tbBackClick(object sender, EventArgs e)
    {
        Response.Redirect(Constant.HomeFolder + "App_Purchase/Transaction/POSearch.aspx");
    }
    protected void tbPrintClick(object sender, EventArgs e)
    {
        this.tbPrint.ClientClick = Appz.OpenReportScript(Constant.Reports.RepPO, Convert.ToDouble("0" + txtLOID.Text), false);
    }
    protected void tbApproveClick(object sender, EventArgs e)
    {
        doApprove();
    }
    protected void tbReceiveClick(object sender, EventArgs e)
    {
        doReceive();
    }
    private void SetStatus(string t, bool isError)
    {
        this.lbStatus.Text = t;
        this.lbStatus.ForeColor = (isError ? Constant.StatusColor.Error : Constant.StatusColor.Information);
    }
    #endregion

    #region FormulaFeedItem Toolbar

    #endregion

    #region FormulaDisease Toolbar

    #endregion

    #region Gridview Event Handler

    protected void gvFormulaFeedItem_RowDataBound(object sender, GridViewRowEventArgs e)
    {
        if (e.Row.RowType == DataControlRowType.DataRow)
        {
            DropDownList cmbUnit = (DropDownList)e.Row.Cells[6].FindControl("cmbUnit");

            Appz.BuildCombo(cmbUnit, "V_MATERIALMASTER_UNIT", "UNITNAME", "UNIT", "ISFORMULA = 'Y' AND MATERIALMASTER = " + e.Row.Cells[12].Text, "", null, null, false);
            DataRow drow = (DataRow)((DataRowView)e.Row.DataItem).Row;
            cmbUnit.SelectedIndex = cmbUnit.Items.IndexOf(cmbUnit.Items.FindByValue(drow["UNIT"].ToString()));
        }
    }

    #endregion

    #region Misc. Methods

    protected void ctlPOPopup_SelectedIndexChanged(object sender, EventArgs e, VPOData selectedData)
    {
        SetMaterialMasterDetail(selectedData);
    }

    #endregion

    #region Controls Management Methods

    private void BindRepairrequestItem()
    {

    }

    private void RepairStatus(string t)
    {
        lbStatus.Text = t;
        lbStatus.ForeColor = Constant.StatusColor.Information;
    }

    private void SetErrorStatus(string t)
    {
        lbStatus.Text = t;
        lbStatus.ForeColor = Constant.StatusColor.Error;
    }

    private void SetMaterialMasterDetail(VPOData Data)
    {
        this.txtClassName.Text = Data.CLASSNAME;
        this.txtPrePO.Text = Data.PREPO.ToString();
        this.txtSupplier.Text = Data.SUPPLIER.ToString();
        this.txtSupplierCode.Text = Data.SUPPLIERCODE;
        this.txtSupplierName.Text = Data.SUPPLIERNAME;
        this.txtMaterialClass.Text = Data.MATERIALCLASS.ToString();
        this.txtPrePOCode.Text = Data.PREPOCODE;

        POFlow fFlow = new POFlow();
        gvItem.DataSource = fFlow.GetMaterialItemList(Data.PREPO,txtIsVat.Text);
        gvItem.DataBind();
        
        CalculateGrantotal();
        CalculateGranRemain();
    }

    private void SetSpecData(int rowIndex)
    {
        ClearSpec();

        GridViewRow gRow = this.gvItem.Rows[rowIndex];
        this.txtRowIndex.Text = rowIndex.ToString();
        this.lblMaterialName.Text = gRow.Cells[4].Text + " (" + gRow.Cells[5].Text + ")";
        this.txtSpec.Text = gRow.Cells[14].Text;
        this.ctlSpecPopup.Show();
    }

    private void ClearSpec()
    {
        this.txtRowIndex.Text = "";
        this.lblMaterialName.Text = "";
        this.txtSpec.Text = "";
    }

    private VPOData GetData()
    {
        VPOData pData = new VPOData();
        pData.LOID = Convert.ToDouble("0" + txtLOID.Text);
        pData.ISVAT = txtIsVat.Text;
        pData.PODATE = ctlPODate.DateValue;
        pData.PREPO = Convert.ToDouble("0" + txtPrePO.Text);
        pData.CNAME = txtContract.Text;
        pData.ADDRESS = txtAddress.Text;
        pData.TEL = txtTel.Text;
        pData.FAX = txtFax.Text;
        pData.STATUS = txtStatus.Text;
        pData.VATRATE = Convert.ToDouble("0" + txtVat.Text);
        pData.REMARKS = txtRemark.Text;
        pData.POItem = GetPOItem();

        return pData;
    }
    private ArrayList GetPOItem()
    {
        ArrayList arrData = new ArrayList();
        for (int i = 0; i < this.gvItem.Rows.Count; ++i)
        {
            POItemData POItem = new POItemData();
            POItem.PO = Convert.ToDouble("0" + this.txtLOID.Text);
            POItem.MATERIALMASTER = Convert.ToDouble("0" + this.gvItem.Rows[i].Cells[11].Text);
            POItem.UNIT = Convert.ToDouble("0" + this.gvItem.Rows[i].Cells[13].Text);
            POItem.PRICE = Convert.ToDouble("0" + this.gvItem.Rows[i].Cells[6].Text);
            POItem.QTY = Convert.ToDouble("0" + this.gvItem.Rows[i].Cells[7].Text);
            POItem.USEQTY = Convert.ToDouble("0" + this.gvItem.Rows[i].Cells[12].Text);
            POItem.PLANREMAINQTY = Convert.ToDouble("0" + this.gvItem.Rows[i].Cells[8].Text.Replace("&nbsp;", ""));
            POItem.REMARKS = ((TextBox)this.gvItem.Rows[i].Cells[10].FindControl("txtRemark")).Text;

            arrData.Add(POItem);
        }
        return arrData;
    }

    private bool doSave()
    {
        POFlow ftFlow = new POFlow();
        bool ret = true;
        string error = "";

        // verify required field
        VPOData pData = GetData();

        error = VerifyData(pData);
        if (error != "")
        {
            SetStatus(error, true);
            return false;
        }

        if (pData.LOID != 0)
            ret = ftFlow.UpdateData(pData, Appz.CurrentUser);
        else
            ret = ftFlow.InsertData(pData, Appz.CurrentUser);

        if (!ret)
            SetErrorStatus(ftFlow.ErrorMessage);
        else
        {
            doGetDetail(ftFlow.LOID.ToString());
            if (pData.LOID != 0)
                SetStatus(DataResources.MSGIU001,false);
            else
                SetStatus(DataResources.MSGIN001,false);
        }

        return ret;
    }

    private bool doApprove()
    {
        POFlow ftFlow = new POFlow();
        bool ret = true;
        string error = "";

        // verify required field
        VPOData pData = GetData();
        pData.STATUS = "AP";

        error = VerifyData(pData);
        if (error != "")
        {
            SetStatus(error, true);
            return false;
        }

        if (pData.LOID != 0)
            ret = ftFlow.UpdateData(pData, Appz.CurrentUser);
        else
            ret = ftFlow.InsertData(pData, Appz.CurrentUser);

        if (!ret)
            SetErrorStatus(ftFlow.ErrorMessage);
        else
        {
            doGetDetail(ftFlow.LOID.ToString());
            if (pData.LOID != 0)
                SetStatus(DataResources.MSGIU001, false);
            else
                SetStatus(DataResources.MSGIN001, false);
        }

        return ret;
    }

    private bool doReceive()
    {
        POFlow ftFlow = new POFlow();
        bool ret = true;
        string error = "";

        // verify required field
        VPOData pData = GetData();
        pData.STATUS = "FN";

        error = VerifyData(pData);
        if (error != "")
        {
            SetStatus(error, true);
            return false;
        }

        if (pData.LOID != 0)
            ret = ftFlow.UpdateDataStockIn(pData, Appz.CurrentUser);

        if (!ret)
            SetErrorStatus(ftFlow.ErrorMessage);
        else
        {
            doGetDetail(ftFlow.LOID.ToString());
            if (pData.LOID != 0)
                SetStatus(DataResources.MSGIU001, false);
            else
                SetStatus(DataResources.MSGIN001, false);
        }

        return ret;
    }

    private void SetData(VPOData fsData)
    {
        POFlow fFlow = new POFlow();
        txtLOID.Text = fsData.LOID.ToString();
        txtPrePO.Text = fsData.PREPO.ToString();
        txtPrePOCode.Text = fsData.PREPOCODE;
        txtClassName.Text = fsData.CLASSNAME;
        txtCode.Text = fsData.CODE;
        txtStatus.Text = fsData.STATUS;
        txtStatusName.Text = fsData.STATUSNAME;
        txtSupplier.Text = fsData.SUPPLIER.ToString();
        txtSupplierCode.Text = fsData.CONTRACTCODE;
        txtSupplierName.Text = fsData.SUPPLIERNAME;
        txtAddress.Text = fsData.ADDRESS;
        txtContract.Text = fsData.CNAME;
        txtTel.Text = fsData.TEL;
        txtFax.Text = fsData.FAX;
        txtRemark.Text = fsData.REMARKS;
        ctlPODate.DateValue = fsData.PODATE;
        txtMaterialClass.Text = fsData.MATERIALCLASS.ToString();
        txtIsVat.Text = fsData.ISVAT;
        txtVat.Text = fsData.VATRATE.ToString();
        if (fsData.LOID == 0)
        {
            this.txtStatus.Text = "WA";
            this.txtStatusName.Text = "กำลังดำเนินการ";
            this.ctlPODate.DateValue = DateTime.Now.Date;
            this.txtIsVat.Text = Request["IsVat"];

        }

        if (this.txtIsVat.Text == "Y")
        {
            this.chkVat.Checked = true;
            this.txtVat.Text = fFlow.GetVat();
        }
        else
        {
            this.chkVat.Checked = false;
        }

        gvItem.DataSource = fFlow.GetPOItemList(Convert.ToDouble("0" + fsData.LOID));
        gvItem.DataBind();

        CalculateGrantotal();
        CalculateGranRemain();

        this.tbReceive.Visible = (fsData.STATUS == "AP");
        this.tbSave.Visible = (fsData.STATUS == "WA" || fsData.STATUS == "");
        this.tbCancel.Visible = (fsData.STATUS == "WA" || fsData.STATUS == "");
        this.tbApprove.Visible = (fsData.STATUS == "WA" || fsData.STATUS == "");
    }

    #endregion

    #region Working Method


    private bool doGetDetail(string LOID)
    {
        POFlow fFlow = new POFlow();
        VPOData pData = fFlow.GetDetails(Convert.ToDouble(LOID));

        bool ret = true;
        SetData(pData);

        return ret;
    }

    private string VerifyData(VPOData fData)
    {
        string ret = "";
        if (fData.PREPO == 0)
            ret = string.Format(DataResources.MSGEI001, "ใบสั่งซื้อล่วงหน้า");

        return ret;
    }

    private void CalculateGrantotal()
    {
        double total = 0;
        double vat = 0;
        double totalvat = 0;
        foreach (GridViewRow row in gvItem.Rows)
        {
            double NetPrice = Convert.ToDouble("0" + row.Cells[9].Text);
            total += NetPrice;
        }
        vat = Convert.ToDouble("0" + txtVat.Text);        
        totalvat = ((total * 100) / (100 + vat));
        txtTotal.Text = totalvat.ToString("N2");
        txtTotalVat.Text = (total - totalvat).ToString("N2");
        txtGrandTotal.Text = total.ToString("N2");

    }

    private void CalculateGranRemain()
    {
        double total = 0;
        foreach (GridViewRow row in gvItem.Rows)
        {
            double Amount = Convert.ToDouble("0"+ row.Cells[8].Text.Replace("&nbsp;", ""));
            double price = Convert.ToDouble("0" + row.Cells[6].Text);
            total += (Amount * price);
        }
        txtRemain.Text = total.ToString("N2");
       
    }

    #endregion
}
