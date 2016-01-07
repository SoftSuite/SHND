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
using SHND.Flow.Prepare;
using SHND.Data.Tables;
using SHND.Global;
using SHND.Flow.Common;
using SHND.Data.Common.Utilities;
using SHND.Data.Views;

/// <summary> 
/// PrepareReturn Page Class
/// Version 1.0
/// =========================================================================
/// Create by: Pom
/// Create Date: 14 Mar 2009
/// -------------------------------------------------------------------------
/// Modify By: -
/// Modify From: -
/// Modify Date: -
/// -------------------------------------------------------------------------
/// Remark: -
/// Description:
///    หน้าการทำงานการแจ้งคืนวัตถุดิบหลังการเตรียม (PrepareReturn)
/// Changes:
///    1.0 - สร้าง
/// -------------------------------------------------------------------------
/// =========================================================================
/// </summary>
/// 

public partial class App_Prepare_Transaction_PrepareReturn : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            CreateTmpMaterialItem();
            tbPrint.Enabled = false;
        }
    }

    protected override void OnInit(EventArgs e)
    {
        base.OnInit(e);
        Appz.BuildCombo(cmbDivisionSearch, "DIVISION", "NAME", "LOID", "ISNUTRIENT = 'Y' AND ACTIVE = '1'", "NAME", "ทั้งหมด", "0", false);
        Appz.BuildCombo(cmbDoctypeSearch, "DOCTYPE", "DOCNAME", "LOID", "ISSTOCKOUT = 'Y'", "DOCNAME", "ทั้งหมด", "0", false);
        Appz.BuildCombo(cmbMaterialClassSearch, "MATERIALCLASS", "NAME", "LOID", "MASTERTYPE = 'FO' AND ACTIVE = '1'", "NAME", "ทั้งหมด", "0", false);
        Appz.BuildCombo(cmbDivision, "DIVISION", "NAME", "LOID", "ISNUTRIENT = 'Y' AND ACTIVE = '1'", "NAME", "เลือก", "0", false);
        Appz.BuildCombo(cmbDoctype, "DOCTYPE", "DOCNAME", "LOID", "ISSTOCKOUT = 'Y'", "DOCNAME", "เลือก", "0", false);
        Appz.BuildCombo(cmbMaterialClass, "MATERIALCLASS", "NAME", "LOID", "MASTERTYPE = 'FO' AND ACTIVE = '1'", "NAME", "เลือก", "0", false);
        
        pcTop.SetMainGridView(gvMain);
        pcBot.SetMainGridView(gvMain);
    }

    protected void ctlMaterialPrepareReturnPopup_SelectedIndexChanged(object sender, EventArgs e, ArrayList arrData)
    {
        if (InsertNewDataToTmpMaterialItem(arrData))
        {
            BindGVMaterialItem();
            CheckMaterialClassDisable();
        }
    }

    protected void ctlMaterialPrepareReturnPopup_Cancel(object sender, EventArgs e)
    {
        zPop.Show();
    }

    #region Button Click Event Handler

    protected void imbSearch_Click(object sender, ImageClickEventArgs e)
    {
        gvMain.PageIndex = 0;
        lblStatusMain.Text = "";
        doGetList();
    }

    protected void tbAddItemClick(object sender, EventArgs e)
    {
        if (cmbMaterialClass.SelectedItem.Value != "0")
        {
            lblStatus.Text = "";
            this.ctlMaterialPrepareReturnPopup.Show(cmbMaterialClass.SelectedItem.Value, getMaterialList());
        }
        else
        {
            SetErrorStatus(lblStatus, string.Format(DataResources.MSGEI002, "หมวดอาหารก่อนเพิ่มรายการ"));
            zPop.Show();
        }
    }

    private string getMaterialList()
    {
        string materialList = "";
        DataTable dt = (DataTable)Session["MaterialItem"];
        if (dt != null)
        {
            for (int i = 0; i < dt.Rows.Count; ++i)
            {
                materialList += (materialList == "" ? "" : ",") + dt.Rows[i]["MMLOID"].ToString();
            }
        }
        return materialList;
    }

    protected void tbBackClick(object sender, EventArgs e)
    {
        ClearAllData();
        EnableControls();
        if (gvMain.Rows.Count > 0)
            doGetList();
    }

    protected void tbCancelClick(object sender, EventArgs e)
    {
        if (txtCode.Text.Trim() == "")
        {
            ClearAllData();
        }
        else
        {
            doGetPrepareReturn(txtCode.Text.Trim());
            doGetPrepareReturnItemList(txtCode.Text.Trim());
            lblStatus.Text = "";
        }
        zPop.Show();
    }

    protected void tbSaveClick(object sender, EventArgs e)
    {
        if (doSave() == true)
        {
            doGetPrepareReturn(txtCode.Text.Trim());
            doGetPrepareReturnItemList(txtCode.Text.Trim());
        }

        zPop.Show();
    }

    protected void tbDeleteItemClick(object sender, EventArgs e)
    {
        ArrayList arrMMLOIDList = GetGVMaterialItemChecked();
        DataTable dt = (DataTable)Session["MaterialItem"];

        if (arrMMLOIDList.Count > 0 && dt != null)
        {
            foreach (string mmloid in arrMMLOIDList)
            {
                for (int i = 0; i < dt.Rows.Count; i++)
                {
                    if (mmloid == dt.Rows[i]["MMLOID"].ToString())
                    {
                        dt.Rows.Remove(dt.Rows[i]);
                    }
                }
            }
        }

        Session["MaterialItem"] = dt;
        BindGVMaterialItem();
        CheckMaterialClassDisable();
        lblStatus.Text = "";
    }

    protected void lnkName_Click(object sender, EventArgs e)
    {
        string code = ((LinkButton)sender).Text.Trim();
        doGetPrepareReturn(code);
        doGetPrepareReturnItemList(code);
        CheckMaterialClassDisable();
        CheckStatus();
        zPop.Show();
    }

    protected void tbConfirmClick(object sender, EventArgs e)
    {
        if (doSave() == true)
        {
            if (doConfirm(txtCode.Text.Trim()) == true)
            {
                doGetPrepareReturn(txtCode.Text.Trim());
                doGetPrepareReturnItemList(txtCode.Text.Trim());
                DisableControls();
            }
        }

        zPop.Show();
    }

    protected void tbDeleteClick(object sender, EventArgs e)
    {
        lblStatusMain.Text = "";
        doDelete();
    }


    #endregion

    #region Gridview Event Handler

    protected void gvMain_Sorting(object sender, GridViewSortEventArgs e)
    {
        if (e.SortExpression == "DEFAULT")
        {
            txhSortDir.Text = "";
            txhSortField.Text = "";
        }
        else
        {
            if (txhSortField.Text == e.SortExpression)
                txhSortDir.Text = (txhSortDir.Text.Trim() == "" ? "DESC" : "");
            else
                txhSortField.Text = e.SortExpression;
        }
        doGetList();
    }

    #endregion

    #region Paging Event Handler

    protected void PageChange(object sender, EventArgs e)
    {
        gvMain.PageIndex = ((Templates_PageControl)sender).SelectedPageIndex;
        doGetList();
        pcBot.Update();
        pcTop.Update();
    }
    #endregion

    #region Misc. Methods

    private void CreateTmpMaterialItem()
    {
        DataTable dt = new DataTable();
        DataColumn dcPILOID = new DataColumn("PILOID");
        DataColumn dcMMLOID = new DataColumn("MMLOID");
        DataColumn dcMATERIALCODE = new DataColumn("MATERIALCODE");
        DataColumn dcMATERIALNAME = new DataColumn("MATERIALNAME");   
        DataColumn dcUNITLOID = new DataColumn("UNITLOID");
        DataColumn dcUNITNAME = new DataColumn("UNITNAME");
        DataColumn dcQTY = new DataColumn("QTY");
        DataColumn dcSTOCKOUTQTY = new DataColumn("STOCKOUTQTY");

        dt.Columns.Add(dcPILOID);
        dt.Columns.Add(dcMMLOID);
        dt.Columns.Add(dcMATERIALCODE);
        dt.Columns.Add(dcMATERIALNAME);
        dt.Columns.Add(dcUNITLOID);
        dt.Columns.Add(dcUNITNAME);
        dt.Columns.Add(dcSTOCKOUTQTY);
        dt.Columns.Add(dcQTY);
        
        Session["MaterialItem"] = dt;
    }

    #endregion

    #region Controls Management Methods

    private void SetStatus(Label lblst, string t)
    {
        lblst.Text = t;
        lblst.ForeColor = Constant.StatusColor.Information;
    }

    private void SetErrorStatus(Label lblst, string t)
    {
        lblst.Text = t;
        lblst.ForeColor = Constant.StatusColor.Error;
    }

    private bool InsertNewDataToTmpMaterialItem(ArrayList arrData)
    {
        bool ret = true;
        DataTable dt = (DataTable)Session["MaterialItem"];

        try
        {
            for (int i = 0; i < arrData.Count; i++)
            {
                VMaterialMasterData VMaterialMaster = (VMaterialMasterData)arrData[i];
                DataRow dr = dt.NewRow();
                dr["MMLOID"] = VMaterialMaster.LOID;
                dr["MATERIALCODE"] = VMaterialMaster.MATERIALCODE;
                dr["MATERIALNAME"] = VMaterialMaster.MATERIALNAME;
                dr["STOCKOUTQTY"] = GetStockOutQty(cmbDivision.SelectedItem.Value, VMaterialMaster.LOID.ToString(), VMaterialMaster.ULOID.ToString());
                dr["UNITLOID"] = VMaterialMaster.ULOID;
                dr["UNITNAME"] = VMaterialMaster.THNAME;
                dt.Rows.Add(dr);
            }

            Session["MaterialItem"] = dt;
        }
        catch (Exception ex)
        {
            ex.ToString();
            ret = false;
        }

        return ret;
    }

    private void SetTmpMaterialItem(DataTable dt)
    {
        DataTable dtTmpMaterialItem = (DataTable)Session["MaterialItem"];

        if (dt.Rows.Count > 0 && dtTmpMaterialItem != null)
        {
            for (int i = 0; i < dt.Rows.Count; i++)
            {
                DataRow dr = dtTmpMaterialItem.NewRow();
                dr["PILOID"] = dt.Rows[i]["LOID"];
                dr["MMLOID"] = dt.Rows[i]["MATERIALMASTER"];
                dr["MATERIALCODE"] = dt.Rows[i]["MATERIALCODE"];
                dr["MATERIALNAME"] = dt.Rows[i]["MATERIALNAME"];
                dr["UNITLOID"] = dt.Rows[i]["UNITLOID"];
                dr["UNITNAME"] = dt.Rows[i]["UNITNAME"];
                dr["STOCKOUTQTY"] = dt.Rows[i]["STOCKOUTQTY"];
                dr["QTY"] = dt.Rows[i]["QTY"];

                dtTmpMaterialItem.Rows.Add(dr);
            }
        }

        Session["MaterialItem"] = dtTmpMaterialItem;
    }

    private void BindGVMaterialItem()
    {
        if (Session["MaterialItem"] != null)
        {
            DataTable dt = (DataTable)Session["MaterialItem"];
            gvMaterialItem.DataSource = dt;
            gvMaterialItem.DataBind();
            zPop.Show();
        }
    }

    protected void gvMain_RowDataBound(object sender, GridViewRowEventArgs e)
    {
        if (e.Row.RowType == DataControlRowType.DataRow)
        {
            if (e.Row.Cells[8].Text.Trim() == "FN")
            {
                CheckBox chkSelect = (CheckBox)e.Row.FindControl("chkSelect");
                if (chkSelect != null)
                {
                    chkSelect.Enabled = false;
                }
            }
        }
    }

    protected void gvMaterialItem_RowDataBound(object sender, GridViewRowEventArgs e)
    {
        if (e.Row.RowType == DataControlRowType.Header)
        {
            ((CheckBox)e.Row.Cells[1].FindControl("chkAll")).Attributes.Add("onclick", "chkAllBox(this, '" + this.gvMaterialItem.ClientID + "_ctl', '_chkSelect')");
        }

        if (e.Row.RowType == DataControlRowType.DataRow)
        {
            //TextBox txtSTOCKOUTQTY = (TextBox)e.Row.FindControl("txtSTOCKOUTQTY");
            //TextBox txtMaterial = (TextBox)e.Row.FindControl("MMLOID");
            //TextBox txtUnit = (TextBox)e.Row.FindControl("UNITLOID");
            //if (txtSTOCKOUTQTY != null)
            //{
            //    ControlUtil.SetDblTextBox(txtSTOCKOUTQTY);
            //    double stockoutqty = GetStockOutQty(cmbDivision.SelectedItem.Value, txtMaterial.Text.ToString(), txtUnit.Text.ToString());
            //    txtSTOCKOUTQTY.Text = stockoutqty.ToString();
            //}

            TextBox txtQTY = (TextBox)e.Row.FindControl("txtQTY");
            if (txtQTY != null)
                ControlUtil.SetDblTextBox(txtQTY);

        }
    }

    private void CheckMaterialClassDisable()
    {
        if (gvMaterialItem.Rows.Count > 0)
            cmbMaterialClass.Enabled = false;
        else
            cmbMaterialClass.Enabled = true;
    }

    private void SetPrepareReturnData(DataTable dt)
    { 
        DateTime informdate = Convert.ToDateTime(dt.Rows[0]["INFORMDATE"]);
        txtInformDate.Text = informdate.ToString("dd/MM/yyyy");

        if (dt.Rows[0]["STATUS"].ToString() == "WA")
            txtStatus.Text = "กำลังดำเนินการ";
        else if (dt.Rows[0]["STATUS"].ToString() == "FN")
            txtStatus.Text = "ยืนยัน";

        cmbDivision.SelectedIndex = cmbDivision.Items.IndexOf(cmbDivision.Items.FindByValue(dt.Rows[0]["DIVISION"].ToString()));
        cmbMaterialClass.SelectedIndex = cmbMaterialClass.Items.IndexOf(cmbMaterialClass.Items.FindByValue(dt.Rows[0]["MATERIALCLASS"].ToString()));
        cmbDoctype.SelectedIndex = cmbDoctype.Items.IndexOf(cmbDoctype.Items.FindByValue(dt.Rows[0]["DOCTYPE"].ToString()));
    }

    private void DisableControls()
    {
        tbSave.Visible = false;
        tbCancel.Visible = false;
        tbConfirm.Visible = false;
        cmbDivision.Enabled = false;
        cmbMaterialClass.Enabled = false;
        cmbDoctype.Enabled = false;
        tbAddItem.Enabled = false;
        tbDeleteItem.Enabled = false;

        for (int i = 0; i < gvMaterialItem.Rows.Count; i++)
        {
            TextBox txtQTY = (TextBox)gvMaterialItem.Rows[i].FindControl("txtQTY");
            if (txtQTY != null)
            {
                txtQTY.ReadOnly = true;
                txtQTY.CssClass = "zTextboxR-View";
            }

            CheckBox chkSelect = (CheckBox)gvMaterialItem.Rows[i].FindControl("chkSelect");
            if (chkSelect != null)
            {
                chkSelect.Enabled = false;
            }
        }
    }

    private void EnableControls()
    {
        tbSave.Enabled = true;
        tbCancel.Enabled = true;
        tbConfirm.Enabled = true;
        cmbDivision.Enabled = true;
        cmbMaterialClass.Enabled = true;
        cmbDoctype.Enabled = true;
        tbAddItem.Enabled = true;
        tbDeleteItem.Enabled = true;

        for (int i = 0; i < gvMaterialItem.Rows.Count; i++)
        {
            TextBox txtQTY = (TextBox)gvMaterialItem.Rows[i].FindControl("txtQTY");
            if (txtQTY != null)
            {
                txtQTY.ReadOnly = false;
                txtQTY.CssClass = "zTextboxR";
            }

            CheckBox chkSelect = (CheckBox)gvMaterialItem.Rows[i].FindControl("chkSelect");
            if (chkSelect != null)
            {
                chkSelect.Enabled = true;
            }
        }
    }

    #endregion

    #region Working Method

    private void doGetList()
    {
        PrepareReturnFlow fFlow = new PrepareReturnFlow();
        string datefrom = "";
        string dateto = "";

        string orderStr = "";
        if (txhSortField.Text.Trim() != "")
            orderStr = " " + txhSortField.Text + " " + txhSortDir.Text;

        if (cldInformDateFrom.DateValue.Year != 1)
            datefrom = cldInformDateFrom.DateValue.Year.ToString() + cldInformDateFrom.DateValue.ToString("/MM/dd");
        if (cldInformDateTo.DateValue.Year != 1)
            dateto = cldInformDateTo.DateValue.Year.ToString() + cldInformDateTo.DateValue.ToString("/MM/dd");

        gvMain.DataSource = fFlow.GetPrepareReturnList(txtCodeFrom.Text.Trim(), txtCodeTo.Text.Trim(), datefrom, dateto, cmbDivisionSearch.SelectedItem.Value, cmbDoctypeSearch.SelectedItem.Value, cmbMaterialClassSearch.SelectedItem.Value, cmbStatusFrom.SelectedItem.Value, cmbStatusTo.SelectedItem.Value, orderStr);
        gvMain.DataBind();
        pcTop.Update();
        pcBot.Update();
    }

    private double GetStockOutQty(string division, string material, string unit)
    {
        PrepareReturnFlow fFlow = new PrepareReturnFlow();
        return fFlow.GetStockOutQty(division, material, unit);
    }

    private ArrayList GetGVMaterialItemChecked()
    {
        ArrayList arrChk = new ArrayList();
        for (int i = 0; i < gvMaterialItem.Rows.Count; i++)
        {
            if (gvMaterialItem.Rows[i].Cells[1].FindControl("chkSelect") != null)
            {
                if (((CheckBox)gvMaterialItem.Rows[i].Cells[1].FindControl("chkSelect")).Checked)
                    arrChk.Add(gvMaterialItem.Rows[i].Cells[9].Text.Trim());
            }
        }

        return arrChk;
    }

    private void ClearAllData()
    {
        tbPrint.Enabled = false;
        txtCode.Text = "";
        txtInformDate.Text = "";
        txtStatus.Text = "";
        cmbDivision.SelectedIndex = -1;
        cmbMaterialClass.SelectedIndex = -1;
        cmbMaterialClass.Enabled = true;
        cmbDoctype.SelectedIndex = -1;
        gvMaterialItem.DataSource = null;
        gvMaterialItem.DataBind();
        lblStatus.Text = "";
        CreateTmpMaterialItem();
    }

    private void doGetPrepareReturn(string code)
    {
        PrepareReturnFlow pFlow = new PrepareReturnFlow();
        DataTable dt = pFlow.GetPrepareReturn(code);
        txtCode.Text = code;
        SetPrepareReturnData(dt);
        tbPrint.Enabled = true;
        tbPrint.ClientClick = Appz.OpenReportScript(Constant.Reports.PrepareReturnReport, "paramfield1=CODE&paramvalue1=" + code, false);
    }

    private void doGetPrepareReturnItemList(string code)
    {
        PrepareReturnFlow fFlow = new PrepareReturnFlow();
        DataTable dt = fFlow.GetPrepareReturnItemList(code);
        CreateTmpMaterialItem();
        SetTmpMaterialItem(dt);
        BindGVMaterialItem();
    }

    private bool doSave()
    {
        // verify required field
        lblStatus.Text = "";

        string error = VerifyData();
        if (error != "")
        {
            SetErrorStatus(lblStatus, error);
            return false;
        }

        if (VerifyGridView() == false)
        {
            return false;
        }

        bool ret = true;

        UpdateTmpMaterialItem();
        ret = doSavePrepareReturn();

        return ret;
    }

    private string VerifyData()
    {
        string ret = "";

        if (cmbDivision.SelectedItem.Value == "0")
            ret = string.Format(DataResources.MSGEI002, "หน่วยที่ส่งคืน");
        else if (cmbMaterialClass.SelectedItem.Value == "0")
            ret = string.Format(DataResources.MSGEI002, "หมวดอาหาร");
        else if (cmbDoctype.SelectedItem.Value == "0")
            ret = string.Format(DataResources.MSGEI002, "ประเภทการเบิก");

        return ret;
    }

    private bool VerifyGridView()
    {
        for (int i = 0; i < gvMaterialItem.Rows.Count; i++)
        {
            TextBox txtQTY = (TextBox)gvMaterialItem.Rows[i].FindControl("txtQTY");

            if (txtQTY.Text.Trim() == "")
            {
                SetErrorStatus(lblStatus, string.Format(DataResources.MSGEI001, "จำนวนคงเหลือในรายการที่ " + Convert.ToInt32(i + 1).ToString()));
                return false;
            }
        }
        return true;
    }

    private bool doSavePrepareReturn()
    {
        PrepareReturnFlow pFlow = new PrepareReturnFlow();
        bool ret = true;
        DataTable dtPrepareItemData = null;

        if (Session["MaterialItem"] != null)
            dtPrepareItemData = (DataTable)Session["MaterialItem"];

        // data correct go on saving...
        if (txtCode.Text.Trim() == "")
        {
            //  save new
            ret = pFlow.InsertData(cmbDivision.SelectedItem.Value, cmbMaterialClass.SelectedItem.Value, cmbDoctype.SelectedItem.Value, dtPrepareItemData, Appz.CurrentUser);
        }
        else
        {
            // save update
            ret = pFlow.UpdateData(txtCode.Text.Trim(), cmbDivision.SelectedItem.Value, cmbMaterialClass.SelectedItem.Value, cmbDoctype.SelectedItem.Value, dtPrepareItemData, Appz.CurrentUser);
        }

        if (!ret)
        {
            SetErrorStatus(lblStatus, pFlow.ErrorMessage);
        }
        else
        {
            SetStatus(lblStatus, "บันทึกข้อมูลเรียบร้อย");
            txtCode.Text = pFlow.CODE.ToString();
        }

        return ret;

    }

    private void UpdateTmpMaterialItem()
    {
        DataTable dt = (DataTable)Session["MaterialItem"];

        if (dt != null)
        {
            for (int i = 0; i < dt.Rows.Count; i++)
            {
                for (int j = 0; j < gvMaterialItem.Rows.Count; j++)
                {
                    if (dt.Rows[i]["MMLOID"].ToString().Trim() == gvMaterialItem.Rows[j].Cells[9].Text.Trim())
                    {
                        TextBox txtSTOCKOUTQTY = (TextBox)gvMaterialItem.Rows[j].FindControl("txtSTOCKOUTQTY");
                        if (txtSTOCKOUTQTY != null)
                            dt.Rows[i]["STOCKOUTQTY"] = txtSTOCKOUTQTY.Text.Trim();

                        TextBox txtQTY = (TextBox)gvMaterialItem.Rows[j].FindControl("txtQTY");
                        if (txtQTY != null)
                            dt.Rows[i]["QTY"] = txtQTY.Text.Trim();
                    }
                }
            }
        }

        Session["MaterialItem"] = dt;
    }

    private bool doConfirm(string code)
    {
        PrepareReturnFlow pFlow = new PrepareReturnFlow();

        if (pFlow.UpdatePrepareReturnStatus(code, Appz.CurrentUser) == true)
        {
            SetStatus(lblStatus, "ยืนยันการแจ้งคืนหลังเตรียมเรียบร้อย");
            return true;
        }
        else
        {
            SetErrorStatus(lblStatus, pFlow.ErrorMessage);
            return false;
        }
    }

    private void CheckStatus()
    {
        PrepareReturnFlow pFlow = new PrepareReturnFlow();
        DataTable dt = pFlow.GetPrepareReturn(txtCode.Text.Trim());
        if (dt.Rows.Count > 0)
        {
            if (dt.Rows[0]["STATUS"].ToString() == "FN")
            {
                DisableControls();
            }
        }
    }

    private void doDelete()
    {
        PrepareReturnFlow pFlow = new PrepareReturnFlow();
        if (pFlow.DeletePrepareReturnByLOID(GetChecked()) == true)
        {
            doGetList();
            lblStatusMain.Text = "";
        }
        else
        {
            SetErrorStatus(lblStatusMain, pFlow.ErrorMessage);
        }
    }

    private ArrayList GetChecked()
    {
        ArrayList arrChk = new ArrayList();
        for (int i = 0; i < gvMain.Rows.Count; i++)
        {
            if (gvMain.Rows[i].FindControl("chkSelect") != null)
            {
                if (((CheckBox)gvMain.Rows[i].FindControl("chkSelect")).Checked)
                    arrChk.Add(gvMain.Rows[i].Cells[0].Text.Trim());
            }
        }

        return arrChk;
    }

    protected void UpdateTmp(object sender, EventArgs e)
    {
        TextBox txtQTY = (TextBox)sender;
        int rowindex = Convert.ToInt32(txtQTY.ToolTip);
        string material_master_loid = gvMaterialItem.Rows[rowindex].Cells[9].Text.Trim();

        DataTable dt = (DataTable)Session["MaterialItem"];

        if (dt != null)
        {
            for (int i = 0; i < dt.Rows.Count; i++)
            {
                if (dt.Rows[i]["MMLOID"].ToString().Trim() == material_master_loid)
                {
                    dt.Rows[i]["QTY"] = txtQTY.Text.Trim();
                }
            }
        }

        Session["MaterialItem"] = dt;
    }


    #endregion
}
