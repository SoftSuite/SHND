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



public partial class App_Inventory_Transaction_StockoutWaste : System.Web.UI.Page
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
        Appz.BuildCombo(cmbWareHouse, "WAREHOUSE", "NAME", "LOID", "ISVIRTUAL='N' AND ACTIVE = '1'", "NAME", "เลือก", "0", false);
        Appz.BuildCombo(cmbDiv, "DIVISION", "NAME", "LOID", "ISONLINEREQUEST = 'Y' AND ACTIVE = '1'", "NAME", "เลือก", "0", false);
        this.txtStatusRef.Text  = "ทำรายการ";
    }
    protected void ctlMaterialStockOutWastePopup_SelectedIndexChanged(object sender, EventArgs e, ArrayList arrData)
    {
        StockoutWasteDetailItem fsItem = new StockoutWasteDetailItem();
        if (fsItem.InsertStockoutWasteItem(Convert.ToDouble("0" + this.txhID.Text), arrData))
            BindStockoutWasteItem();
    }

    #region StockoutWaste Toolbar

    protected void tbAddDetailClick(object sender, EventArgs e)
    {
        if (cmbWareHouse.SelectedValue == "0")
        {
            SetErrorStatus(string.Format(DataResources.MSGEI002, "คลังที่จำหน่ายออก"));
        }
        else
        {
            this.ctlMaterialStockOutWastePopup.Show(Convert.ToDouble(cmbWareHouse.SelectedItem.Value),"");
        }
    }
    protected void tdDelDetailClick(object sender, EventArgs e)
    {
        StockoutWasteDetailItem fsItem = new StockoutWasteDetailItem();
        fsItem.UpdateStockInOtherItem(Convert.ToDouble("0" + this.txhID.Text), GetStockoutWasteData());
        if (fsItem.DeleteStockoutWasteItem(GetChecked())) 
        BindStockoutWasteItem();
    }
    private void BindStockoutWasteItem()
    {
        this.gvMain.DataBind();
    }

    #endregion

    #region Button Click Event Handler

    protected void tbSaveClick(object sender, EventArgs e)
    {
        this.txtStatus.Text = "WA";
        doSave();
    }
    protected void tbSendClick(object sender, EventArgs e)
    {
        this.txtStatus.Text = "SE";
        doSave();
    }
    protected void tbNotApproveClick(object sender, EventArgs e)
    {
        this.txtStatus.Text = "NP";
        doSave();
    }
    protected void tbCancelClick(object sender, EventArgs e)
    {
        if (txhID.Text.Trim() == "")
            ClearData();
        else
            doGetDetail(txhID.Text);
     }
    protected void tbCommitClick(object sender, EventArgs e)
    {
        this.txtStatus.Text = "AP";
        doSave();

        StockoutWasteDetailItem fsitem = new StockoutWasteDetailItem();
        fsitem.ClearAllSession();
        BindStockoutWasteItem();
     }

    protected void tbBackClick(object sender, EventArgs e)
    {
        Response.Redirect("StockoutWasteSearch.aspx");
    }

    #endregion

    #region Misc. Methods
    private ArrayList GetChecked()
    {
        ArrayList arrChk = new ArrayList();
        for (int i = 0; i < gvMain.Rows.Count; i++)
        {
            if (i > -1 && gvMain.Rows[i].Cells[0].FindControl("chkSelect") != null)
            {
                if (((CheckBox)gvMain.Rows[i].Cells[1].FindControl("chkSelect")).Checked)
                    arrChk.Add(gvMain.Rows[i].Cells[0].Text);
            }
        }

        return arrChk;
    }
    #endregion

    #region Controls Management Methods

    private void ClearData()
    {
      //  StockoutWasteDetailItem fsitem = new StockoutWasteDetailItem();
     //   fsitem.ClearAllSession();
        this.txhID.Text = "";
        this.txtCODE.Text = "";
        this.cmbDiv.SelectedIndex = 0;
        this.cmbWareHouse.SelectedIndex = 0;
        this.ctlStockoutDate.DateValue = DateTime.Now;
        this.txtStatusRef.Text = "ทำรายการ";
        this.txtStatus.Text  = "WA";
        this.txtReason.Text = "";
    }
    private VStockOutData GetData()
    {
       
        VStockOutData sData = new VStockOutData();
        sData.LOID = Convert.ToDouble("0" + txhID.Text);
        sData.STOCKOUTDATE = ctlStockoutDate.DateValue;
        sData.DIVISION  = Convert.ToDouble(cmbDiv.SelectedItem.Value);
        sData.STATUS = this.txtStatus.Text;
        sData.WAREHOUSE = Convert.ToDouble(cmbWareHouse.SelectedItem.Value);
        sData.REASON = txtReason.Text;
        sData.StockoutWasteList = GetStockoutWasteData();
       
        return sData;
    }
    private ArrayList GetStockoutWasteData()
    {
        ArrayList arrData = new ArrayList();
        
        for (int i = 0; i < gvMain.Rows.Count; i++)
        {
            StockoutitemData sData = new StockoutitemData();
           
            sData.STOCKOUT  = Convert.ToDouble("0" + txhID.Text);
            sData.QTY = Convert.ToDouble("0" + ((TextBox)gvMain.Rows[i].Cells[6].FindControl("txtQTY")).Text);
            sData.UNIT = Convert.ToDouble("0" + gvMain.Rows[i].Cells[8].Text);
            sData.ISMENU = "Y";
            sData.STATUS = this.txtStatus.Text;
            sData.REMARKS = ((TextBox)gvMain.Rows[i].Cells[7].FindControl("txtRemark")).Text;
            sData.REPAIRSTATUS = "Z";
            sData.MATERIALMASTER = Convert.ToDouble("0" + gvMain.Rows[i].Cells[9].Text);
           
            arrData.Add(sData);
           
        }
        return arrData;
    }
    private void SetErrorStatus(string t)
    {
        lbStatus.Text = t;
        lbStatus.ForeColor = Constant.StatusColor.Error;
    }
    private void SetStatus(string t)
    {
        lbStatus.Text = t;
        lbStatus.ForeColor = Constant.StatusColor.Information;
    }

    private void SetData(VStockOutData ftData)
    {
        cmbDiv.SelectedIndex = cmbDiv.Items.IndexOf(cmbDiv.Items.FindByValue(ftData.DIVISION.ToString()));
        cmbWareHouse.SelectedIndex = cmbWareHouse.Items.IndexOf(cmbWareHouse.Items.FindByValue(ftData.WAREHOUSE.ToString()));
        ctlStockoutDate.DateValue = (ftData.STOCKOUTDATE.Year == 1 ? DateTime.Today : ftData.STOCKOUTDATE);
        txhID.Text = ftData.LOID.ToString();
        txtCODE.Text = ftData.CODE;
        txtReason.Text = ftData.REASON;
        this.tbPrint.Visible = (ftData.LOID != 0);
        if (ftData.CODE == "0" || ftData.CODE == "" )
        {
            this.tbPrint.Visible = false;
            this.txtStatusRef.Text = "ทำรายการ";
        }
        else
        {
            this.tbPrint.Visible = true;
            this.tbPrint.ClientClick = Appz.OpenReportScript(Constant.Reports.StockoutWasteReport, Convert.ToDouble(txhID.Text.Trim()), false);
            this.txtStatusRef.Text = ftData.STATUSNAME;
            cmbDiv.Enabled  = false;
            cmbWareHouse.Enabled = false;
        }

        if (ftData.STATUS == "AP")
        {
            tbSave.Visible = false;
            tbCancel.Visible = false;
            tbSend.Visible = false;
            tbCommit.Visible = false;
            tbNotApprove.Visible = false;
            tbAddDetail.Visible = false;
            tdDelDetail.Visible = false;
            lblReason.Visible = true;
            txtReason.Visible = true;
            txtReason.ReadOnly = true;
            lblReasonStar.Visible = true;
            txtReason.CssClass = "zTextbox-View";
        }
        else if (ftData.STATUS == "SE")
        {
            tbSave.Visible = false;
            tbCancel.Visible = false;
            tbSend.Visible = false;
            tbCommit.Visible = true;
            tbNotApprove.Visible = true;
            tbAddDetail.Visible = false;
            tdDelDetail.Visible = false;
            lblReason.Visible = true;
            txtReason.Visible = true;
            txtReason.ReadOnly = false;
            lblReasonStar.Visible = true;
        }
        else if (ftData.STATUS == "NP" || ftData.STATUS== "WA" || ftData.STATUS=="")
        {
            tbSave.Visible = true;
            tbCancel.Visible = true;
            tbSend.Visible = true;
            tbCommit.Visible = false;
            tbNotApprove.Visible = false;
            lblReason.Visible = false;
            txtReason.Visible = false;
            lblReasonStar.Visible = false;
            
        }
        
        StockoutWasteDetailItem item = new StockoutWasteDetailItem();
        item.ClearAllSession();
        BindStockoutWasteItem();
       
        
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
        VStockOutData sData = GetData();
        bool ret = true;
        StockWasteFlow stFlow = new StockWasteFlow();

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
            SetStatus(error);
            return true;
        }
       
            return ret;
    }
    private string VerifyData()
    {
        string ret = "";
        bool check = true;
        VStockOutData fData = GetData();
        if (cmbDiv.SelectedItem.Value == "0")
            ret = string.Format(DataResources.MSGEI002, "หน่วยงานที่ทำเสีย");
        else if (cmbWareHouse.SelectedItem.Value == "0")
            ret = string.Format(DataResources.MSGEI002, "คลังที่จำหน่ายออก");
        else if (ctlStockoutDate.DateValue.Year == 1)
            ret = string.Format(DataResources.MSGEI002, "วันที่จำหน่าย");

        if (fData.STATUS == "AP") 
        {
            if (txtReason.Text.Trim() == "")
                ret = string.Format(DataResources.MSGEI001, "เหตุผลการจำหน่ายของเสีย");
        }

        if (ret == "")
        {
            foreach (GridViewRow row in gvMain.Rows)
            {
                TextBox txt = (TextBox)row.Cells[6].FindControl("txtQty");
                if (txt.Text == "" || Convert.ToDouble(txt.Text) == 0)
                {
                    check = false;
                    break;
                }
            }
            if (!check)
                ret = string.Format("จำนวนรายการวัสดุต้องมากกว่า 0");
        }

        return ret;
    }

    private bool doGetDetail(string LOID)
    {
       // this.txtCurentTab.Text = this.tabFormulaSet.ActiveTabIndex.ToString();
        StockWasteFlow fFlow = new StockWasteFlow();
        VStockOutData fData = fFlow.GetDetails(Convert.ToDouble(LOID));

        bool ret = true;
        SetData(fData);
        return ret;
    }

    #endregion






}
