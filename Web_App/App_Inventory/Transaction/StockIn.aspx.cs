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
/// Create Date: 18 Feb 2009
/// -------------------------------------------------------------------------
/// Modify By: -
/// Modify From: -
/// Modify Date: -
/// -------------------------------------------------------------------------
/// Remark: -
/// Description:
///    หน้ากาารทำงานข้อมูล  StockInSAP & StockInRequest
/// Changes:
///    1.0 - สร้าง
/// -------------------------------------------------------------------------
/// =========================================================================
/// </summary>
/// 

public partial class App_Inventory_Transaction_StockIn : System.Web.UI.Page
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
        Appz.BuildCombo(cmbWareHouse, "WAREHOUSE", "NAME", "LOID", "ISVIRTUAL='N' AND ACTIVE='1' ", "NAME", "เลือก", "0", false);
        Appz.BuildCombo(cmbWareHouseOrder, "WAREHOUSE", "NAME", "LOID", "ISVIRTUAL='N' AND ACTIVE='1'", "NAME", "เลือก", "0", false);

        this.ctlStockInDate.DateValue = DateTime.Now;
    }

    protected void ctlMaterialStockinToolsPopup_SelectedIndexChanged(object sender, EventArgs e, ArrayList arrData)
    {
       StockInDetailItem fsItem = new StockInDetailItem();
       if (fsItem.InsertStockInItem(Convert.ToDouble(this.cmbPlan.SelectedItem.Value), Convert.ToDouble("0" + this.txhID.Text), arrData))
       BindStockInItem();    
    }

    protected void ctlMaterialStockinFoodPopup_SelectedIndexChanged(object sender, EventArgs e, ArrayList arrData)
    {
        StockInDetailItem fsItem = new StockInDetailItem();
        if (fsItem.InsertStockInFoodItem(Convert.ToDouble(this.cmbPlan.SelectedItem.Value), Convert.ToDouble("0" + this.txhID.Text), arrData))
            BindStockInItem();
    }

    protected void cmbPlan_SelectedIndexChanged(object sender, EventArgs e)
    {
        if (txhDocType.Text == Constant.DocType.StockInPO.Loid)
        {
            Appz.BuildCombo(cmbMaterialClass, "V_PLANMATERIALCLASS", "CLASSNAME", "MATERIALCLASS", "PLANORDER = " + cmbPlan.SelectedValue, "CLASSNAME", "เลือก", "0", false);
        }
        StockInDetailItem sItem = new StockInDetailItem();
        sItem.ClearData();
        this.gvMain.DataBind();
    }
    
    protected void cmbMaterialClass_SelectedIndexChanged(object sender, EventArgs e)
    {
        StockInDetailItem sItem = new StockInDetailItem();
        sItem.ClearData();
        this.gvMain.DataBind();
    }

    #region StockoutWaste Toolbar

    protected void tbAddDetailClick(object sender, EventArgs e)
    {
        StockInDetailItem sItem = new StockInDetailItem();
        if (txhDocType.Text == Constant.DocType.StockInPO.Loid)
        {
            if (cmbPlan.SelectedValue == "0")
            {
                SetErrorStatus(string.Format(DataResources.MSGEI002, "แผนประมาณการ"));
                return;
            }
            if (cmbMaterialClass.SelectedValue == "0")
            {
                SetErrorStatus(string.Format(DataResources.MSGEI002, "หมวดอาหาร"));
                return;
            }
            this.ctlMaterialStockInFoodPopup.Show(cmbPlan.SelectedValue, cmbMaterialClass.SelectedValue, sItem.GetMaeralMasterList());
        }
        else
        {
            if (cmbPlan.SelectedValue == "0")
            {
                SetErrorStatus(string.Format(DataResources.MSGEI002, "แผนประมาณการ"));
                return;
            }
            this.ctlMaterialStockinToolsPopup.Show(cmbPlan.SelectedValue, sItem.GetMaeralMasterList());
        }
    }
    protected void tdDelDetailClick(object sender, EventArgs e)
    {
        StockInDetailItem fsItem = new StockInDetailItem();
        fsItem.UpdateStockInItem(Convert.ToDouble("0" + this.txhID.Text), GetStockInData());
        if (fsItem.DeleteStockInItem(GetChecked()))
            BindStockInItem();
    }
    private void BindStockInItem()
    {
        this.gvMain.DataBind();
    }

    #endregion

    #region Button Click Event Handler

    protected void tbSaveClick(object sender, EventArgs e)
    {
        string status = this.txtStatus.Text;
        this.txtStatus.Text = "WA";
        doSave();
    }

    protected void tbBackClick(object sender, EventArgs e)
    {
        Response.Redirect("StockInSearch.aspx");
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
        string status = this.txtStatus.Text;
        this.txtStatus.Text = "AP";
        doSave();
            
        StockInDetailItem fsitem = new StockInDetailItem();
        fsitem.ClearAllSession();
        BindStockInItem();
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
    private void SetStatus(string t) {
        lbStatus.Text = t;
        lbStatus.ForeColor = Constant.StatusColor.Information;
    }
    private void ClearData()
    {
      //  StockInDetailItem fsitem = new StockInDetailItem();
       // fsitem.ClearAllSession();
        this.txhID.Text = "";
        this.txtCODE.Text = "";
        this.cmbPlan.SelectedIndex = 0;
        this.cmbWareHouse.SelectedIndex = 0;
        this.ctlStockInDate.DateValue = DateTime.Now;
        if (this.txhDocType.Text == Constant.DocType.StockInPoSAP.Loid)
        {
            this.txtTypeRef.Text = Constant.DocType.StockInPoSAP.Name;
            this.txhDocType.Text = "";
        }
        else if (this.txhDocType.Text == Constant.DocType.StockInHospital.Loid)
        {
            this.txtTypeRef.Text = Constant.DocType.StockInHospital.Name;
            this.txhDocType.Text = "";
        }
        this.txtStatus.Text = "WA";
        this.txtStatusRef.Text = "กำลังดำเนินการ";
    }
    private VStockInData GetData()
    {
        VStockInData sData = new VStockInData();
        sData.LOID = Convert.ToDouble("0" + txhID.Text);
        sData.WAREHOUSE  = Convert.ToDouble(cmbWareHouse.SelectedItem.Value);
        sData.DOCTYPE = Convert.ToDouble("0" + this.txhDocType.Text);
        sData.PLANORDER = Convert.ToDouble(cmbPlan.SelectedItem.Value);
        sData.STATUS = this.txtStatus.Text;
        sData.STOCKINDATE = ctlStockInDate.DateValue;
        sData.StockInList = GetStockInData();
        sData.SAPWAREHOUSE = Convert.ToDouble(cmbWareHouseOrder.SelectedItem.Value);
       
        return sData;
    }
    private ArrayList GetStockInData()
    {
        ArrayList arrData = new ArrayList();

        for (int i = 0; i < gvMain.Rows.Count; i++)
        {
            StockinItemData sData = new StockinItemData();
            sData.STOCKIN = Convert.ToDouble("0" + txhID.Text);
            sData.SAPPOCODE = ((TextBox)gvMain.Rows[i].Cells[6].FindControl("txtSAPPOCODE")).Text;
            sData.SAPPODATE = ((Templates_CalendarControl)gvMain.Rows[i].Cells[7].FindControl("ctlSAPPODATE")).DateValue;
            sData.USEQTY = Convert.ToDouble("0" + gvMain.Rows[i].Cells[8].Text);
            sData.QTY = Convert.ToDouble("0" + ((TextBox)gvMain.Rows[i].Cells[9].FindControl("txtQTY")).Text);
            sData.PLANREMAINQTY = Convert.ToDouble(gvMain.Rows[i].Cells[10].Text == "" ? "0" : gvMain.Rows[i].Cells[10].Text);
            sData.LOTNO = ((TextBox)gvMain.Rows[i].Cells[11].FindControl("txtLOTNO")).Text;
            sData.GUARANTEE = Convert.ToDouble("0" + ((TextBox)gvMain.Rows[i].Cells[12].FindControl("txtGURANTEE")).Text);
            sData.PRICE = Convert.ToDouble("0" + gvMain.Rows[i].Cells[13].Text);
            sData.UNIT = Convert.ToDouble("0" + gvMain.Rows[i].Cells[14].Text);
            sData.MATERIALMASTER = Convert.ToDouble("0" + gvMain.Rows[i].Cells[15].Text);
           
            arrData.Add(sData);

        }
        return arrData;
    }
    private void SetData(VStockInData ftData)
    {
        string docType = (Request["Type"] == null ? Convert.ToString(ftData.DOCLOID) : Request["Type"]);
        txhDocType.Text = docType;

        if (docType == Constant.DocType.StockInPO.Loid)
        {
            Appz.BuildCombo(cmbPlan, "V_PLAN_FOOD_SEARCH", "NAME", "LOID", "ISPLANFOOD= 'Y' AND STATUS ='FN'", "NAME", "เลือก", "0", false);
        }
        else
        {
            Appz.BuildCombo(cmbPlan, "V_PLAN_TOOLS_SEARCH", "NAME", "LOID", "ISPLANFOOD= 'N' AND STATUS ='FN'", "NAME", "เลือก", "0", false);
        }

        cmbPlan.SelectedIndex = cmbPlan.Items.IndexOf(cmbPlan.Items.FindByValue(ftData.PLANORDER.ToString()));
        cmbWareHouse.SelectedIndex = cmbWareHouse.Items.IndexOf(cmbWareHouse.Items.FindByValue(ftData.WAREHOUSE.ToString()));
        cmbWareHouseOrder.SelectedIndex = cmbWareHouseOrder.Items.IndexOf(cmbWareHouseOrder.Items.FindByValue(ftData.SAPWAREHOUSE.ToString()));
        ctlStockInDate.DateValue = (ftData.STOCKINDATE.Year == 1 ? DateTime.Now : ftData.STOCKINDATE);
        txtCODE.Text = ftData.CODE;
        txhID.Text = ftData.LOID.ToString();
        this.tbPrint.Visible = (ftData.LOID != 0);

        switch (docType)
        {
            case Constant.DocType.StockInPO.Loid:
                this.txtTypeRef.Text = Constant.DocType.StockInPO.Name;
                this.cmbWareHouseOrder.Visible = false;
                this.lbChk.Visible = false;
                this.lbOrder.Visible = false;
                this.lblMaterialClass.Visible = true;
                this.cmbMaterialClass.Visible = true;
                this.lblChkMaterialClass.Visible = true;
                Appz.BuildCombo(cmbMaterialClass, " V_PLANMATERIALCLASS", "CLASSNAME", "MATERIALCLASS", "PLANORDER = " + cmbPlan.SelectedValue, "CLASSNAME", "เลือก", "0", false);
                cmbMaterialClass.SelectedValue = ftData.MATERIALCLASS.ToString();
                break;

            case Constant.DocType.StockInPoSAP.Loid:
                this.tbPrint.ClientClick = Appz.OpenReportScript(Constant.Reports.StockInReport, Convert.ToDouble(txhID.Text.Trim()), false);
                this.txtTypeRef.Text = Constant.DocType.StockInPoSAP.Name;
                this.cmbWareHouseOrder.Visible  = false;
                this.lbChk.Visible = false;
                this.lbOrder.Visible = false;
                break;

            default:
                this.tbPrint.Visible = false;
                this.txtTypeRef.Text = Constant.DocType.StockInHospital.Name;
                break;
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

            if (ftData.STATUS == "AP")
            {
                this.tbCommit.Visible = false;
                this.tbAddDetail.Visible = false;
                this.tdDelDetail.Visible = false;
                this.tbCancel.Visible = false;
                this.tbSave.Visible = false;
                this.txtStatus.Text = ftData.STATUS;
                this.txtStatusRef.Text = ftData.STATUSNAME;
            }
        }
        StockInDetailItem item = new StockInDetailItem();
        item.ClearAllSession();
        BindStockInItem();
        bool enable = (this.txtStatus.Text == "WA");

        this.cmbWareHouse.Enabled = enable;
        this.cmbWareHouseOrder.Enabled = enable;
        this.cmbPlan.Enabled = enable;
        this.cmbMaterialClass.Enabled = enable;
        this.gvMain.Columns[1].Visible = enable;
    }

    #endregion

    #region Working Method

    private bool doSave()
    {
        // verify uniq field
        bool ret = true;
        string error = VerifyData();

        if (error != "")
        {
            SetErrorStatus(error);
            ret = false;
        }
        else
        {
            VStockInData sData = GetData();
            StockInFlow stFlow = new StockInFlow();

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
                doGetDetail(Convert.ToString(stFlow.LOID));
                error = "บันทึกข้อมูลเรียบร้อยแล้ว";
                SetStatus(error);
                ret = true;
            }
        }
        return ret;
    }
    private string VerifyData()
    {
        string ret = "";
        VStockInData fData = GetData();
        if (fData.DOCTYPE == Convert.ToDouble(Constant.DocType.StockInPO.Loid))
        {
            if (cmbMaterialClass.SelectedValue == "0")
                ret = string.Format(DataResources.MSGEI002, "หมวดอาหาร");
        }
        else if (fData.DOCTYPE == Convert.ToDouble(Constant.DocType.StockInHospital.Loid))
        {
            if (cmbWareHouseOrder.SelectedItem.Value == "0")
                ret = string.Format(DataResources.MSGEI002, "คลังที่จ่าย");
        }

        if (cmbPlan.SelectedItem.Value == "0")
            ret = string.Format(DataResources.MSGEI002, "แผนประมาณการ");

        if (cmbWareHouse.SelectedItem.Value == "0")
            ret = string.Format(DataResources.MSGEI002, "คลังที่รับเข้า");
        
        if (ctlStockInDate.DateValue.Year == 1)
            ret = string.Format(DataResources.MSGEI002, "วันที่รับ");
  
        return ret;
    }
    private bool doGetDetail(string LOID)
    {

        StockInFlow fFlow = new StockInFlow();
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
            bool enable = (this.txtStatus.Text == "WA");
            TextBox txtSAPPOCODE = (TextBox)e.Row.Cells[6].FindControl("txtSAPPOCODE");
            Templates_CalendarControl ctlSAPPODATE = (Templates_CalendarControl)e.Row.Cells[7].FindControl("ctlSAPPODATE");
            TextBox txtQTY = (TextBox)e.Row.Cells[9].FindControl("txtQTY");
            TextBox txtLOTNO = (TextBox)e.Row.Cells[11].FindControl("txtLOTNO");
            TextBox txtGURANTEE = (TextBox)e.Row.Cells[12].FindControl("txtGURANTEE");

            txtSAPPOCODE.ReadOnly = !enable;
            txtSAPPOCODE.CssClass = (enable ? "zTextbox" : "zTextbox-View");
            ctlSAPPODATE.Enabled = enable;
            txtQTY.ReadOnly = !enable;
            txtQTY.CssClass = (enable ? "zTextboxR" : "zTextboxR-View");
            txtLOTNO.ReadOnly = !enable;
            txtLOTNO.CssClass = (enable ? "zTextbox" : "zTextbox-View");
            txtGURANTEE.ReadOnly = !enable;
            txtGURANTEE.CssClass = (enable ? "zTextboxR" : "zTextboxR-View");
        }
    }
}
