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
///    หน้ากาารทำงานข้อมูล  StockInSAP 
/// Changes:
///    1.0 - สร้าง
/// -------------------------------------------------------------------------
/// =========================================================================
/// </summary>
/// 

public partial class App_Inventory_Transaction_StockInSAP : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            doGetDetail((Request["loid"] == null ? "0" : Request["loid"]));
            ctlStockInDate.DateValue = DateTime.Now;
            this.txtTypeRef.Text = "รับเข้าจากPOในSAP";
            this.txtStatusRef.Text = "กำลังดำเนินการ";
        }
    }
    protected override void OnInit(EventArgs e)
    {
        base.OnInit(e);

        Appz.BuildCombo(cmbWareHouse, "WAREHOUSE", "NAME", "LOID", "", "NAME", "", "0", false);
        Appz.BuildCombo(cmbPlan, "V_PLAN_TOOLS_SEARCH", "NAME", "LOID", "ISPLANFOOD= 'N' AND STATUS ='FN'", "NAME", "", "0", false);
        ctlStockInDate.DateValue = DateTime.Now;
        this.txtTypeRef.Text = "รับเข้าจากPOในSAP";
        this.txtStatusRef.Text = "กำลังดำเนินการ";
    }
    

    protected void ctlMaterialUnitPopup_SelectedIndexChanged(object sender, EventArgs e, ArrayList arrData)
    {
        StockInDetailItem fsItem = new StockInDetailItem();
        if (fsItem.InsertStockInItem(Convert.ToDouble (this.cmbPlan.SelectedItem.Value), Convert.ToDouble("0" + this.txhID.Text), arrData))
            BindStockInItem();
    }
    
    #region StockoutWaste Toolbar

    protected void tbAddDetailClick(object sender, EventArgs e)
    {
        this.ctlMaterialUnitPopup.Show("2", 0, 0, "", "");
    }
    protected void tdDelDetailClick(object sender, EventArgs e)
    {
        StockInDetailItem fsItem = new StockInDetailItem();
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
        if (doSave())
            ClearData();
        StockoutWasteDetailItem fsitem = new StockoutWasteDetailItem();
        fsitem.ClearAllSession();
        BindStockInItem();
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
        if (doSave())
            ClearData();
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

    private void SetErrorStatus(string t)
    {
        lbStatus.Text = t;
        lbStatus.ForeColor = Constant.StatusColor.Error;
    }
    private void ClearData()
    {
        StockInDetailItem fsitem = new StockInDetailItem();
        fsitem.ClearAllSession();
        this.txhID.Text = "";
        this.txtCODE.Text = "";
        this.cmbPlan.SelectedIndex = 0;
        this.cmbWareHouse.SelectedIndex = 0;
        this.ctlStockInDate.DateValue = DateTime.Now;
        this.txtTypeRef.Text = "รับเข้าจากPOในSAP";
        this.txtStatus.Text = "WA";
        this.txtStatusRef.Text = "กำลังดำเนินการ";
    }
    private VStockInData GetData()
    {

        VStockInData sData = new VStockInData();
        sData.LOID = Convert.ToDouble("0" + txhID.Text);
        sData.WAREHOUSE  = Convert.ToDouble(cmbWareHouse.SelectedItem.Value);
        sData.DOCTYPE = 4;
        sData.PLANORDER = Convert.ToDouble(cmbPlan.SelectedItem.Value);
        sData.STATUS = this.txtStatus.Text;
        sData.STOCKINDATE = ctlStockInDate.DateValue;
        sData.StockInList = GetStockInData(); 
       
        return sData;
    }
    private ArrayList GetStockInData()
    {
       
        ArrayList arrData = new ArrayList();

        for (int i = 0; i < gvMain.Rows.Count; i++)
        {
            StockinItemData sData = new StockinItemData();


            sData.STOCKIN = Convert.ToDouble("0" + txhID.Text);               
            sData.SAPPOCODE =  ((TextBox)gvMain.Rows[i].Cells[5].FindControl("txtSAPPOCODE")).Text;
            sData.SAPPODATE =  ((Templates_CalendarControl)gvMain.Rows[i].Cells[6].FindControl("ctlSAPPODATE")).DateValue;
            sData.USEQTY = Convert.ToDouble("0" + gvMain.Rows[i].Cells[7].Text);
            sData.QTY = Convert.ToDouble("0" + ((TextBox)gvMain.Rows[i].Cells[8].FindControl("txtQTY")).Text);
            sData.PLANREMAINQTY = Convert.ToDouble("0" + gvMain.Rows[i].Cells[9].Text);
            sData.LOTNO = ((TextBox)gvMain.Rows[i].Cells[10].FindControl("txtLOTNO")).Text;
            sData.GUARANTEE = Convert.ToDouble("0" + ((TextBox)gvMain.Rows[i].Cells[11].FindControl("txtGURANTEE")).Text);
            sData.PRICE = Convert.ToDouble("0" + gvMain.Rows[i].Cells[13].Text);
            sData.UNIT = Convert.ToDouble("0" + gvMain.Rows[i].Cells[14].Text);
            sData.MATERIALMASTER = Convert.ToDouble("0" + gvMain.Rows[i].Cells[15].Text);

            arrData.Add(sData);

        }
        return arrData;
    }
    private void SetData(VStockInData ftData)
    {
        cmbPlan.SelectedIndex = cmbPlan.Items.IndexOf(cmbPlan.Items.FindByValue(ftData.PLANORDER.ToString()));
        cmbWareHouse.SelectedIndex = cmbWareHouse.Items.IndexOf(cmbWareHouse.Items.FindByValue(ftData.WAREHOUSE.ToString()));
        ctlStockInDate.DateValue = ftData.STOCKINDATE;
        txtCODE.Text = ftData.CODE;
        this.txtTypeRef.Text = ftData.DOCNAME;
        this.txtStatusRef.Text = ftData.STATUSNAME;
        txhID.Text = ftData.LOID.ToString();
        StockInDetailItem item = new StockInDetailItem();
        item.ClearAllSession();
        BindStockInItem();
        this.tbPrint.ClientClick = Appz.OpenReportScript(Constant.Reports.StockInReport , Convert.ToDouble(txhID.Text.Trim()), false);
        this.tbPrint.Visible = (ftData.LOID != 0);
    }
    #endregion

    #region Working Method

    private bool doSave()
    {
        // verify uniq field
        string error = VerifyData();
      
        if (error != "" ) 
        {
            SetErrorStatus(error);
            return false;
        }
        VStockInData sData = GetData();
        bool ret = true;
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
        if (ctlStockInDate.DateValue.Year == 1)
            ret = string.Format(DataResources.MSGEI002, "วันที่รับ");
        else if (cmbWareHouse.SelectedItem.Value == "0")
            ret = string.Format(DataResources.MSGEI002, "คลังที่รับเข้า");
        else if (cmbPlan.SelectedItem.Value == "0")
            ret = string.Format(DataResources.MSGEI002, "แผนประมาณการ");
        
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
}
