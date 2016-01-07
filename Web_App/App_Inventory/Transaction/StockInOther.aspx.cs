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
/// Create Date: 25 Feb 2009
/// -------------------------------------------------------------------------
/// Modify By: -
/// Modify From: -
/// Modify Date: -
/// -------------------------------------------------------------------------
/// Remark: -
/// Description:
///    หน้ากาารทำงานข้อมูล  StockInOther
/// Changes:
///    1.0 - สร้าง
/// -------------------------------------------------------------------------
/// =========================================================================
/// </summary>
/// 

public partial class App_Inventory_Transaction_StockInOther : System.Web.UI.Page
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
        this.ctlStockInDate.DateValue = DateTime.Now;
    }

    protected void ctlMaterialUnitPopup_SelectedIndexChanged(object sender, EventArgs e, ArrayList arrData)
    {
        StockInOtherDetailItem fsItem = new StockInOtherDetailItem();
        if (fsItem.InsertStockInOtherItem(Convert.ToDouble("0" + this.txhID.Text), arrData))
            BindStockInOtherItem();
    }

    #region StockoutWaste Toolbar

    protected void tbAddDetailClick(object sender, EventArgs e)
    {
        StockInOtherDetailItem fsItem = new StockInOtherDetailItem();
        fsItem.UpdateStockInOtherItem(Convert.ToDouble("0" + this.txhID.Text), GetStockInData());
        this.ctlMaterialUnitPopup.Show("", 0, 0, fsItem.GetMaterialMasterList(), "");
    }
    protected void tdDelDetailClick(object sender, EventArgs e)
    {
        StockInOtherDetailItem fsItem = new StockInOtherDetailItem();
        fsItem.UpdateStockInOtherItem(Convert.ToDouble("0" + this.txhID.Text), GetStockInData());
        if (fsItem.DeleteStockInOtherItem(GetChecked()))
            BindStockInOtherItem();
        
    }
    private void BindStockInOtherItem()
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
    private void SetStatus(string t)
    {
        lbStatus.Text = t;
        lbStatus.ForeColor = Constant.StatusColor.Information;
    }
    private void ClearData()
    {
        this.txhID.Text = "";
        this.txtCODE.Text = "";
        this.cmbWareHouse.SelectedIndex = 0;
        this.ctlStockInDate.DateValue = DateTime.Now;
        this.txtTypeRef.Text = "รับเข้ากรณีอื่นๆ";
        this.txtStatus.Text = "WA";
        this.txtStatusRef.Text = "กำลังดำเนินการ";
        this.txtRemark.Text = "";
        this.txhDocType.Text  = "";
    }
    private VStockInData GetData()
    {
        VStockInData sData = new VStockInData();
        sData.LOID = Convert.ToDouble("0" + txhID.Text);
        sData.WAREHOUSE = Convert.ToDouble(cmbWareHouse.SelectedItem.Value);
        sData.DOCTYPE = Convert.ToDouble("0" + this.txhDocType.Text);
        sData.STATUS = this.txtStatus.Text;
        sData.REMARKS = this.txtRemark.Text;
        sData.STOCKINDATE = DateTime.Now;
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
            sData.QTY = Convert.ToDouble("0" + ((TextBox)gvMain.Rows[i].Cells[6].FindControl("txtQTY")).Text);
            sData.LOTNO = ((TextBox)gvMain.Rows[i].Cells[7].FindControl("txtLOTNO")).Text;
            sData.GUARANTEE = Convert.ToDouble("0" + ((TextBox)gvMain.Rows[i].Cells[8].FindControl("txtGURANTEE")).Text);
            sData.BRAND = ((TextBox)gvMain.Rows[i].Cells[9].FindControl("txtBRAND")).Text;
            sData.PRICE = Convert.ToDouble("0" + gvMain.Rows[i].Cells[10].Text);
            sData.UNIT = Convert.ToDouble("0" + gvMain.Rows[i].Cells[11].Text);
            sData.MATERIALMASTER = Convert.ToDouble("0" + gvMain.Rows[i].Cells[12].Text);

            arrData.Add(sData);

        }
        return arrData;
    }
    private void SetData(VStockInData ftData)
    {
       
        cmbWareHouse.SelectedIndex = cmbWareHouse.Items.IndexOf(cmbWareHouse.Items.FindByValue(ftData.WAREHOUSE.ToString()));
        ctlStockInDate.DateValue = (ftData.STOCKINDATE.Year == 1 ? DateTime.Now : ftData.STOCKINDATE);
        txtCODE.Text = ftData.CODE;
        txhID.Text = ftData.LOID.ToString();
        txtRemark.Text = ftData.REMARKS;
        this.tbPrint.Visible = (ftData.LOID != 0);
        
        if (ftData.DOCLOID == 0)
        {
            this.tbPrint.Visible = false;
            this.txtTypeRef.Text = "รับเข้ากรณีอื่นๆ";
            this.txhDocType.Text = "5";
        }
        else
        {
           this.txhDocType.Text = Convert.ToString(ftData.DOCLOID);
           this.txtTypeRef.Text = ftData.DOCNAME;
        }
        if (ftData.STATUS == "")
        {
            this.txtStatus.Text = "WA";
            this.txtStatusRef.Text = "กำลังดำเนินการ";
        }
        else
        {
            if (ftData.STATUS == "AP")
            {
                this.tbCommit.Visible = false;
                this.tbSave.Visible = false;
                this.tbAddDetail.Visible = false;
                this.tdDelDetail.Visible = false;
                this.txtStatus.Text = ftData.STATUS;
                this.txtStatusRef.Text = ftData.STATUSNAME;
            }
            else
            {
                this.txtStatus.Text = ftData.STATUS;
                this.txtStatusRef.Text = ftData.STATUSNAME;
            }
        }
        StockInOtherDetailItem item = new StockInOtherDetailItem();
        item.ClearAllSession();
        BindStockInOtherItem ();
    }
    #endregion

    #region Working Method

    private bool doSave()
    {
        // verify uniq field
        string error = VerifyData();
        bool ret = true;

        if (error != "")
        {
            SetErrorStatus(error);
            ret = false;
        }
        else
        {
            VStockInData sData = GetData();
            StockInOtherFlow stFlow = new StockInOtherFlow();

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
                SetStatus(error);
                doGetDetail(Convert.ToString(stFlow.LOID));
                ret = true;
            }
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
        else if (this.txtRemark .Text =="")
            ret = string.Format(DataResources.MSGEI001, "หมายเหตุ");

        return ret;
    }
    private bool doGetDetail(string LOID)
    {
        StockInOtherFlow fFlow = new StockInOtherFlow();
        VStockInData fData = fFlow.GetDetails(Convert.ToDouble(LOID));

        bool ret = true;
        SetData(fData);
        return ret;
    }

     #endregion

}
