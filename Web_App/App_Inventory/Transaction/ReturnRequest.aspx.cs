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
using SHND.Global;
using SHND.Flow.Common;
using SHND.Flow.Inventory;
using SHND.Data.Views;
using SHND.Data.Tables;

/// <summary>
/// Supplier Page Class
/// Version 1.0
/// =========================================================================
/// Create by: Somsakoon
/// Create Date: 2 Mar 2009
/// -------------------------------------------------------------------------
/// Modify By: Nang
/// Modify From: -
/// Modify Date: 2 June 2009
/// -------------------------------------------------------------------------
/// Remark: -
/// Description:
///    หน้ากาารทำงานข้อมูล  ReturnRequest
/// Changes:
///    1.0 - สร้าง
/// -------------------------------------------------------------------------
/// =========================================================================
/// </summary>
/// 

public partial class App_Inventory_Transaction_ReturnRequest : System.Web.UI.Page
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
        Appz.BuildCombo(cmbWareHouse, "WAREHOUSE", "NAME", "LOID", "ISVIRTUAL='N' AND ACTIVE='1'", "NAME", "เลือก", "0", false);
        Appz.BuildCombo(cmbDiv, "DIVISION", "NAME", "LOID", "", "NAME", "", "0", false);
        this.ctlReturnDate.DateValue = DateTime.Now;
    }

    protected void ctlMaterialReturnRequestPopup_SelectedIndexChanged(object sender, EventArgs e, ArrayList arrData)
    {
        ReturnRequestDetailItem fsItem = new ReturnRequestDetailItem();
        if (fsItem.InsertReturnRequestItem (Convert.ToDouble(this.txhID.Text), arrData))
            BindReturnRequestItem();
    }
    private void UpdateReturnRequestItem()
    {
        ReturnRequestDetailItem item = new ReturnRequestDetailItem();
        item.UpdateReturnRequestItem(Convert.ToDouble("0" + this.txhID.Text), GetReturnRequestData());
    }

    #region ReturnRequest Toolbar

    private void BindReturnRequestItem()
    {
        this.gvMain.DataBind();
    }
    protected void tbAddDetailClick(object sender, EventArgs e)
    {
        UpdateReturnRequestItem();
        string materialList = "";
        for (int i = 0; i < this.gvMain.Rows.Count; ++i)
        {
            materialList += (materialList == "" ? "" : "") + "" + this.gvMain.Rows[i].Cells[1].Text;
        }
        this.ctlMaterialReturnrRequestPopup.Show(Convert.ToDouble(this.cmbDiv.SelectedItem.Value), Convert.ToDouble(this.cmbWareHouse.SelectedItem.Value), materialList);
    }
    protected void tdDelDetailClick(object sender, EventArgs e)
    {
        ReturnRequestDetailItem fsItem = new ReturnRequestDetailItem();
        fsItem.UpdateReturnRequestItem(Convert.ToDouble("0" + txhID.Text), GetStockInData());
        if (fsItem.DeleteReturnRequestItem(GetChecked()))
            BindReturnRequestItem();
    }

    #endregion

    

    #region Button Click Event Handler

    protected void tbSaveClick(object sender, EventArgs e)
    {
        string status = this.txtStatus.Text;
        this.txtStatus.Text = "WA";
        doSave();
            
    }
    protected void tbSendClick(object sender, EventArgs e)
    {
        string status = this.txtStatus.Text;
        this.txtStatus.Text = "CO";
        doSave();
    }
    protected void tbBackClick(object sender, EventArgs e)
    {
        Response.Redirect("ReturnRequestSearch.aspx");
    }
    protected void tbCancelClick(object sender, EventArgs e)
    {
        if (txhID.Text.Trim() == "")
            ClearData();
        else
            doGetDetail(txhID.Text);
    }

    #endregion

    #region Misc. Methods
    private ArrayList GetChecked()
    {
        ArrayList arrChk = new ArrayList();
        for (int i = 0; i < gvMain.Rows.Count; i++)
        {
            if (i > -1 && gvMain.Rows[i].Cells[1].FindControl("chkSelect") != null)
            {
                if (((CheckBox)gvMain.Rows[i].Cells[1].FindControl("chkSelect")).Checked)
                    arrChk.Add(gvMain.Rows[i].Cells[0].Text);
            }
        }

        return arrChk;
    }
    #endregion

    #region Controls Management Methods

    private void SetErrorStatus(string t)
    {
        lbStatus.Text = t;
        lbStatus.ForeColor = Constant.StatusColor.Error;
    }
    private void ClearData()
    {
        VStockInData ftData = new VStockInData();
       
        this.txhID.Text = "";
        this.txtCODE.Text = "";
        this.cmbDiv.SelectedIndex = cmbDiv.Items.IndexOf(cmbDiv.Items.FindByValue((ftData.DIVISION == 0 ? Appz.LoggedOnUser.DIVISION.ToString() : ftData.DIVISION.ToString())));
        this.cmbWareHouse.SelectedIndex = 0;
        this.ctlReturnDate.DateValue = DateTime.Now;
        this.txtStatus.Text = "WA";
        this.txtStatusRef.Text = "กำลังดำเนินการ";
    }
    private VStockInData  GetData()
    {
        VStockInData sData = new VStockInData();
        sData.LOID = Convert.ToDouble("0" + this.txhID.Text);
        sData.DIVISION = Convert.ToDouble(cmbDiv.SelectedItem.Value);
        sData.WAREHOUSE = Convert.ToDouble(cmbWareHouse.SelectedItem.Value);
        sData.STOCKINDATE = this.ctlReturnDate.DateValue;
        sData.STATUS = this.txtStatus.Text;
        sData.REMARKS = this.txtRemark.Text;
        sData.StockInList = GetStockInData();
        sData.DOCTYPE = Convert.ToDouble("0" + this.txhDocType.Text);
      
        return sData;
    }
    private ArrayList GetStockInData()
    {
        ArrayList arrData = new ArrayList();

        for (int i = 0; i < gvMain.Rows.Count; i++)
        {
            StockinItemData sData = new StockinItemData();
            
            sData.STOCKIN = Convert.ToDouble("0" + txhID.Text);
            sData.QTY = Convert.ToDouble("0" + ((TextBox)gvMain.Rows[i].Cells[7].FindControl("txtGOODQTY")).Text);
            sData.WASTEQTY = Convert.ToDouble("0" + ((TextBox)gvMain.Rows[i].Cells[8].FindControl("txtWASTEQTY")).Text);
            sData.REMARKS = ((TextBox)gvMain.Rows[i].Cells[9].FindControl("txtREMARKS")).Text;
            sData.UNIT = Convert.ToDouble("0" + gvMain.Rows[i].Cells[10].Text);
            sData.MATERIALMASTER = Convert.ToDouble("0" + gvMain.Rows[i].Cells[0].Text);
            sData.STOCKOUTQTY = Convert.ToDouble("0" + ((TextBox)gvMain.Rows[i].Cells[7].FindControl("txtGOODQTY")).Text) + Convert.ToDouble("0" + ((TextBox)gvMain.Rows[i].Cells[8].FindControl("txtWASTEQTY")).Text);

            arrData.Add(sData);

        }
        return arrData;
    }
    private ArrayList GetReturnRequestData()
    {
        ArrayList arrData = new ArrayList();

        for (int i = 0; i < gvMain.Rows.Count; i++)
        {
            VStockinItemData sData = new VStockinItemData();
            sData.STOCKOUTQTY = Convert.ToDouble("0" + ((TextBox)gvMain.Rows[i].Cells[7].FindControl("txtQTY")).Text);
            sData.QTY = Convert.ToDouble("0" + ((TextBox)gvMain.Rows[i].Cells[8].FindControl("txtGOODQTY")).Text);
            sData.UNIT = Convert.ToDouble("0" + gvMain.Rows[i].Cells[10].Text);
            sData.MATERIALMASTER = Convert.ToDouble("0" + gvMain.Rows[i].Cells[1].Text);
            sData.REMARKS = ((TextBox)gvMain.Rows[i].Cells[9].FindControl("txtREMARKS")).Text;
            arrData.Add(sData);

        }
        return arrData;
    }
    private void SetData(VStockInData ftData)
    {
       
        cmbWareHouse.SelectedIndex = cmbWareHouse.Items.IndexOf(cmbWareHouse.Items.FindByValue(ftData.WAREHOUSE.ToString()));
        ctlReturnDate .DateValue = (ftData.STOCKINDATE.Year == 1 ? DateTime.Now : ftData.STOCKINDATE);
        txtCODE.Text = ftData.CODE;
        txhID.Text = ftData.LOID.ToString();
        this.txtRemark.Text  = ftData.REMARKS;
        this.tbPrint.Visible = (ftData.LOID != 0);
        this.tbPrint.ClientClick = Appz.OpenReportScript(Constant.Reports.RepStockinReturn, Convert.ToDouble("0" + txhID.Text.Trim()), false);
        this.txtStatus.Text = ftData.STATUS;
        this.txtStatusRef.Text = ftData.STATUSNAME;
        this.cmbDiv.SelectedIndex = cmbDiv.Items.IndexOf(cmbDiv.Items.FindByValue((ftData.DIVISION == 0 ? Appz.LoggedOnUser.DIVISION.ToString() : ftData.DIVISION.ToString())));
        if (ftData.DOCTYPE == 0)
        {
            this.tbPrint.Visible = false;
            this.txtStatusRef.Text = "กำลังดำเนินการ";
            this.txhDocType.Text = "15";
        }
        else
        {
            this.txhDocType.Text = Convert.ToString(ftData.DOCTYPE);
            this.txtStatusRef.Text = ftData.STATUSNAME;
        }

        if (ftData.STATUS == "")
        {
            this.txtStatus.Text = "WA";
            this.txtStatusRef.Text = "กำลังดำเนินการ";
        }
        else
        {
            this.txtStatus.Text = ftData.STATUS;
            this.txtStatusRef.Text = ftData.STATUSNAME;

            if (ftData.STATUS == "AP" || ftData.STATUS=="CO")
            {
                this.tbCommit.Visible = false;
                this.txtStatus.Text = ftData.STATUS;
                this.txtStatusRef.Text = ftData.STATUSNAME;
                this.tbCancel.Visible = false;
                this.tbSend.Visible = false;
                this.cmbDiv.Enabled = false;
                this.cmbWareHouse.Enabled = false;
                this.tbAddDetail.Visible = false;
                this.tdDelDetail.Visible = false;
                this.txtRemark.ReadOnly = true;
                this.txtRemark.CssClass = "zTextbox-View";
                this.ctlReturnDate.Enabled = false;
                this.gvMain.Columns[1].Visible = false;
            }
        }

        ReturnRequestDetailItem item = new ReturnRequestDetailItem();
        item.ClearAllSession();
        BindReturnRequestItem ();
    }
    #endregion


    #region Working Method

    private bool doSave()
    {
        // verify uniq field
        string error = VerifyData();

        if (error != "")
        {
            SetErrorStatus(error);
            return false;
        }
        VStockInData sData = GetData();
        bool ret = true;
        ReturnRequestFlow stFlow = new ReturnRequestFlow();

        // data correct go on saving...
        if (txhID.Text.Trim() == "0")
        {

            //  save new
            ret = stFlow.InsertData(sData, Appz.CurrentUser);
        }
        else
        {
            // save update
            ret = stFlow.UpdateData(sData, Appz.CurrentUser);
        }

        if (!ret)
            SetErrorStatus(stFlow.ErrorMessage);
        else
        {
            doGetDetail(stFlow.LOID.ToString());
            error = "บันทึกข้อมูลเรียบร้อยแล้ว";
            SetErrorStatus(error);
            return true;
        }

        return ret;
    }
    private string VerifyData()
    {
        string ret = "";
        VStockInData fData = GetData();
        if (ctlReturnDate.DateValue.Year == 1)
            ret = string.Format(DataResources.MSGEI001, "วันที่คืน");
        else if (cmbWareHouse.SelectedItem.Value == "0")
            ret = string.Format(DataResources.MSGEI002, "คลังที่รับเข้า");
        else if (cmbDiv.SelectedItem.Value == "0")
            ret = string.Format(DataResources.MSGEI002, "หน่วยคืนคลัง");
        else if (txtRemark.Text.Trim() == "")
            ret = string.Format(DataResources.MSGEI001, "สาเหตุการคืน");
        

        return ret;
    }
    private bool doGetDetail(string  LOID)
    {
        ReturnRequestFlow fFlow = new ReturnRequestFlow();
        VStockInData fData = fFlow.GetDetails(Convert.ToDouble(LOID));
        bool ret = true;
        SetData(fData);
        return ret;
    }

    #endregion

    protected void gvMain_RowDataBound(object sender, GridViewRowEventArgs e)
    {
        if (e.Row.RowType == DataControlRowType.DataRow)
        {
            bool enabled = (this.txtStatus.Text == "WA" || this.txtStatus.Text == "NP");
            TextBox txtGOODQTY = (TextBox)e.Row.Cells[7].FindControl("txtGOODQTY");
            TextBox txtWASTEQTY = (TextBox)e.Row.Cells[8].FindControl("txtWASTEQTY");
            TextBox txtREMARKS = (TextBox)e.Row.Cells[9].FindControl("txtREMARKS");
            txtGOODQTY.ReadOnly = !enabled;
            txtGOODQTY.CssClass = (enabled ? "zTextboxR" : "zTextboxR-View");
            ControlUtil.SetDblTextBox4(txtGOODQTY);
            txtWASTEQTY.ReadOnly = !enabled;
            txtWASTEQTY.CssClass = (enabled ? "zTextboxR" : "zTextboxR-View");
            ControlUtil.SetDblTextBox4(txtWASTEQTY);
            txtREMARKS.ReadOnly = !enabled;
            txtREMARKS.CssClass = (enabled ? "zTextbox" : "zTextbox-View");
        }
    }
}
