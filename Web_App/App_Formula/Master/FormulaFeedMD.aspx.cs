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
using SHND.Flow.Formula;
using SHND.Data.Tables;
using SHND.Data.Common.Utilities;
using SHND.Global;
using SHND.Data.Views; 

/// <summary>
/// FormularFeedMD Page Class
/// Version 1.0
/// =========================================================================
/// Create by: Nang
/// Create Date: 6 Jan 2009
/// -------------------------------------------------------------------------
/// Modify By: -
/// Modify From: -
/// Modify Date: -
/// -------------------------------------------------------------------------
/// Remark: -
/// Description:
///    หน้าการทำงานข้อมูลสูตรอาหารทางการแพทย์ FomularFeedMD
/// Changes:
///    1.0 - สร้าง
/// -------------------------------------------------------------------------
/// =========================================================================
/// </summary>
/// 

public partial class App_Formula_Master_FormulaFeedMD : System.Web.UI.Page
{
    private DataTable tempTable = null;
    private DataTable tempFormulaFeedMD = null;
    private bool flag = true;

    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            CreateTempTable();
            doGetList();
        }
    }

    protected override void OnInit(EventArgs e)
    {
        base.OnInit(e);
        ControlUtil.SetDblTextBoxRealNumer(txtEnergyFrom);
        ControlUtil.SetDblTextBoxRealNumer(txtEnergyTo);
        ControlUtil.SetDblTextBoxRealNumer(txtCapFrom);
        ControlUtil.SetDblTextBoxRealNumer(txtCapTo);
        ControlUtil.SetDblTextBoxRealNumer(txtAddcap);
        ControlUtil.SetDblTextBoxRealNumer(txtAddCapRate);
        ControlUtil.SetDblTextBoxRealNumer(txtAddEnerRate);
        ControlUtil.SetDblTextBoxRealNumer(txtAddEnergy);
        Appz.BuildCombo(cmbType, "V_FORMULAFEED_MD_COMBO", "NAME", "LOID", "", "NAME", "ทั้งหมด", "0", true);
        Appz.BuildCombo(cmbFoodMDType, "V_MATERIALMASTER", "MATERIALNAME", "LOID", "MASTERTYPE = 'MD' AND ACTIVE= '1'", "MATERIALNAME", "----เลือก----", "0", true);
        pcTop.SetMainGridView(grvResult);
        pcBot.SetMainGridView(grvResult);
    }

    protected void ctlMaterialMasterPopup_SelectedIndexChanged(object sender, EventArgs e, ArrayList arrData)
    {
        if (InsertNewDataToTmpFeedItem(arrData))
            BindGVFeedItem();
    }

    protected void ctlMaterialMasterPopup_Cancel(object sender, EventArgs e)
    {
        FormulaFeedMDPop.Show();
    }

    #region Button Click Event Handler

    #region Main Toolbar

    protected void tbAddClick(object sender, EventArgs e)
    {
        FormulaFeedMDPop.Show();
        cmbFoodMDType.Enabled = true;
    }

    protected void lnkType_Click(object sender, EventArgs e)
    {
        doGetDetail(((LinkButton)sender).CommandArgument);
        FormulaFeedMDPop.Show();
        TabContainer1.Visible = true;
        TabContainer1.ActiveTabIndex = 0;
        txtflage.Text = "1";
        tbPrint.Visible = (txhID.Text.Trim() != "");
        cmbFoodMDType.Enabled = false;
    }

    protected void tbAddFormulaFeedItemClick(object sender, EventArgs e)
    {
        this.ctlMaterialMasterPopup.Show("2", getMaterialList());
        FormulaFeedMDPop.Show();
    }

    private string getMaterialList()
    {
        string materialList = "";
        DataTable dt = (DataTable)Session["FormulaFeedMD"];
        if (dt != null)
        {
            for (int i = 0; i < dt.Rows.Count; ++i)
            {
                materialList += (materialList == "" ? "" : ",") + dt.Rows[i]["LOID"].ToString();
            }
        }
        return materialList;
    }

    #endregion

    #region Button Main

    protected void imbSearch_Click(object sender, ImageClickEventArgs e)
    {
        grvResult.PageIndex = 0;
        doGetList();
    }

    protected void imbReset_Click(object sender, ImageClickEventArgs e)
    {
        ClearSearch();
        grvResult.PageIndex = 0;
        doGetList();
    }
    #endregion

    #region Inventory Toolbar

    protected void tbSave1Click(object sender, EventArgs e)
    {
        bool ret = true;
        if (doSave())
        {
            ret = doSaveFormulaFeedItem();
            if (!ret)
            {
                SetErrorStatus("เกิดข้อผิดพลาดในการแก้ไขข้อมูล");
                FormulaFeedMDPop.Show();
            }
            else
            {
                ClearData();
                Session["FormulaFeedMD"] = null;
                doGetList();
            }
        }
        else
        {
            FormulaFeedMDPop.Show();
        }
    }

    protected void tbReturnClick(object sender, EventArgs e)
    {
        if (txhID.Text.Trim() == "")
        {
            cmbFoodMDType.Enabled = true;
            ClearData();
        }
        else
            doGetDetail(txhID.Text);

        FormulaFeedMDPop.Show();
    }

    protected void tbBackClick(object sender, EventArgs e)
    {
        ClearData();
        cmbFoodMDType.Enabled = true;
    }

    protected void tbDeleteFormulaFeedItemClick(object sender, EventArgs e)
    {
        doDeleteFormulaItemOnGrid();
    }

    #endregion

    #region Button Popup
    //ปุ่มคำนวณ
    protected void calculator_Click(object sender, ImageClickEventArgs e)
    {
        FormulaFeedMDFlow ffFlow = new FormulaFeedMDFlow();
        if (!ffFlow.CheckUniqMaterial(Convert.ToDouble(cmbFoodMDType.SelectedItem.Value), Convert.ToDouble(txtAddcap.Text.Trim()), Convert.ToDouble(txtFullEnergy.Text.Trim()), Convert.ToDouble((txhID.Text == "" ? "0" : txhID.Text.Trim()))))
        {
            SetErrorStatus("มีชนิดอาหารทางการแพทย์นี้ในฐานข้อมูลแล้ว");
        }
        else
        {
            //if (Session["FormulaFeedMD"] != null)
            //{
            //    DataTable df = (DataTable)Session["FormulaFeedMD"];
            //    bool ret = ffFlow.DeleteFormulaFeedItemByLOID_Grid((txhID.Text != "" ? Convert.ToDouble(txhID.Text.Trim()) : 0));
            //    if (!ret)
            //        SetErrorStatus(ffFlow.ErrorMessage);
            //}

            DoGetDataCalculator();
            TabContainer1.Visible = true;
        }
        FormulaFeedMDPop.Show();
        TabContainer1.ActiveTabIndex = 0;
    }

    #endregion

    #region Button On GridviewPopup

    protected void imbNewSearch_Click(object sender, ImageClickEventArgs e)
    {
        this.txtFormulaSetItemRow.Text = ((ImageButton)sender).CommandArgument;
        ctlMaterialMasterPopup.Show("2");
        FormulaFeedMDPop.Show();
    }

    #endregion

    #endregion

    #region Gridview Event Handler

    #region GrvResult Event

    protected void grvResult_Sorting(object sender, GridViewSortEventArgs e)
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

    protected void grvResult_RowDeleting(object sender, GridViewDeleteEventArgs e)
    {
        if (e.RowIndex > -1)
        {
            doDelete(grvResult.Rows[e.RowIndex].Cells[0].Text.Trim());
        }
    }

    protected void grvResult_RowDataBound(object sender, GridViewRowEventArgs e)
    {
        if (e.Row.RowType == DataControlRowType.DataRow)
        {
            e.Row.Cells[2].Text = ((e.Row.RowIndex + 1) + (grvResult.PageIndex * grvResult.PageSize)).ToString();
        }

        ImageButton imbCopyMain = (ImageButton)e.Row.FindControl("imbCopyMain");
        LinkButton lnkType = (LinkButton)e.Row.FindControl("lnkType");
        if (imbCopyMain != null)
            imbCopyMain.OnClientClick = "return confirm('ต้องการคัดลอกรายการข้อมูลสูตร" + ' ' + lnkType.Text + ' ' + "ใช่หรือไม่?')";
    }

    protected void grvResult_SelectedIndexChanging(object sender, GridViewSelectEventArgs e)
    {
        if (e.NewSelectedIndex > -1)
        {
            txtflage.Text = "2";
            doGetDetail(grvResult.Rows[e.NewSelectedIndex].Cells[0].Text.Trim());
            FormulaFeedMDPop.Show();
            TabContainer1.Visible = true;
            TabContainer1.ActiveTabIndex = 0;
        }
    }

    #endregion

    #region GrvInventory Event

    protected void grvInventory_RowEditing(object sender, GridViewEditEventArgs e)
    {

        //GridView grvInventory = (GridView)sender;
        //TextBox txtEditName = (TextBox)grvInventory.Rows[e.NewEditIndex].FindControl("txtEditName");
        //ImageButton imbSearch = (ImageButton)grvInventory.Rows[e.NewEditIndex].FindControl("imbSearch");

        //grvInventory.EditIndex = e.NewEditIndex;
        //grvInventory.DataSource = Session["FormulaFeedMD"];
        //grvInventory.DataBind();
        //FormulaFeedMDPop.Show();
    }

    protected void grvInventory_RowUpdating(object sender, GridViewUpdateEventArgs e)
    {
        //GridView grvInventory = (GridView)sender;

        //tempTable = (DataTable)Session["FormulaFeedMD"];
        //TextBox lblName = (TextBox)grvInventory.Rows[e.RowIndex].FindControl("txtEditName");
        //TextBox txtEditCost = (TextBox)grvInventory.Rows[e.RowIndex].FindControl("txtEditCost");


        //for (int i = 0; i < tempTable.Rows.Count; i++)
        //{
        //    if (tempTable.Rows[i]["MATERIALNAME"].ToString() == lblName.Text.Trim())
        //    {
        //        tempTable.Rows[i]["COST"] = txtEditCost.Text.Trim();
        //        tempTable.Rows[i]["LOID"] = grvInventory.Rows[e.RowIndex].Cells[0].Text;
        //        tempTable.Rows[i]["UULOID"] = grvInventory.Rows[e.RowIndex].Cells[6].Text;
        //    }
        //}
        //Session["FormulaFeedMD"] = tempTable;
        //grvInventory.EditIndex = -1;
        //grvInventory.DataSource = tempTable;
        //grvInventory.DataBind();
        //FormulaFeedMDPop.Show();
    }

    protected void grvInventory_RowDataBound(object sender, GridViewRowEventArgs e)
    {
        if (e.Row.RowType == DataControlRowType.Header)
        {
            ((CheckBox)e.Row.Cells[1].FindControl("chkAll")).Attributes.Add("onclick", "chkAllBox(this, '" + this.grvInventory.ClientID + "_ctl', '_chkSelect')");
        }

        if (e.Row.RowIndex > -1)
        {
            e.Row.Cells[2].Text = ((e.Row.RowIndex + 1) + (grvInventory.PageIndex * grvInventory.PageSize)).ToString();

            //=== กรณีกด Edit
            TextBox txtEditCost = (TextBox)e.Row.FindControl("txtEditCost");
            if (txtEditCost != null)
                ControlUtil.SetDblTextBox(txtEditCost);
        }

        if (e.Row.RowType == DataControlRowType.Footer)
        {
            TextBox txtNewCost = (TextBox)e.Row.FindControl("txtNewCost");
            ControlUtil.SetDblTextBox(txtNewCost);
        }
    }

    protected void grvInventory_RowCancelingEdit(object sender, GridViewCancelEditEventArgs e)
    {
        grvInventory.EditIndex = -1;
        grvInventory.DataSource = Session["FormulaFeedMD"];
        grvInventory.DataBind();
        FormulaFeedMDPop.Show();
    }

    #endregion

    #region GrvNutrient Event

    protected void grvNutrient_RowDataBound(object sender, GridViewRowEventArgs e)
    {
        if (e.Row.RowIndex > -1)
        {
            e.Row.Cells[1].Text = ((e.Row.RowIndex + 1) + (grvNutrient.PageIndex * grvNutrient.PageSize)).ToString();
        }
    }

    #endregion

    #endregion

    #region Paging Event Handler
    protected void PageChange(object sender, EventArgs e)
    {
        grvResult.PageIndex = ((Templates_PageControl)sender).SelectedPageIndex;
        doGetList();
        pcBot.Update();
        pcTop.Update();
    }
    #endregion

    #region Misc. Methods

    private void CreateTempTable()
    {
        tempTable = new DataTable();
        DataColumn dcMATERIALNAME = new DataColumn("MATERIALNAME");
        DataColumn dcCOST = new DataColumn("COST");
        DataColumn dcABBNAME = new DataColumn("ABBNAME");
        DataColumn dcUULOID = new DataColumn("UULOID");
        DataColumn dcFFLOID = new DataColumn("FFLOID");
        DataColumn dcLOID = new DataColumn("LOID");
        DataColumn dcFILOID = new DataColumn("FILOID");

        tempTable.Columns.Add(dcMATERIALNAME);
        tempTable.Columns.Add(dcCOST);
        tempTable.Columns.Add(dcABBNAME);
        tempTable.Columns.Add(dcUULOID);
        tempTable.Columns.Add(dcFFLOID);
        tempTable.Columns.Add(dcLOID);
        tempTable.Columns.Add(dcFILOID);
    }

    private ArrayList GetChecked()
    {
        ArrayList arrChk = new ArrayList();
        for (int i = 0; i < grvInventory.Rows.Count; i++)
        {
            if (i > -1 && grvInventory.Rows[i].Cells[0].FindControl("chkSelect") != null)
            {
                if (((CheckBox)grvInventory.Rows[i].Cells[1].FindControl("chkSelect")).Checked)
                    arrChk.Add(grvInventory.Rows[i].Cells[0].Text);
            }
        }

        return arrChk;
    }

    #endregion

    #region Controls Management Methods

    private void SetData(FormulaFeedData ffData, DataTable fiData)
    {
        txhID.Text = ffData.LOID.ToString();
        chkActive.Checked = ffData.ACTIVE;
        txtAddcap.Text = ffData.CAPACITY.ToString();
        txtAddCapRate.Text = ffData.CAPACITYRATE.ToString();
        txtAddEnerRate.Text = ffData.ENERGYRATE.ToString();
        txtFullEnergy.Text = ffData.ENERGY.ToString();
        double fn = Convert.ToDouble(txtFullEnergy.Text.Trim());
        txtAddEnergy.Text = fn.ToString("#,##0.00");
        this.tbPrint.ClientClick = Appz.OpenReportScript(Constant.Reports.FormulaFeedMDReport, Convert.ToDouble(txhID.Text.Trim()), false);
        this.tbPrint.Visible = (ffData.LOID != 0);

        cmbFoodMDType.SelectedIndex = cmbFoodMDType.Items.IndexOf(cmbFoodMDType.Items.FindByValue(ffData.MATERIALMASTER.ToString()));
        CreateTempTable();
        tempTable = fiData;
        Session["FormulaFeedMD"] = tempTable;
        grvInventory.DataSource = tempTable;
        grvInventory.DataBind();
    }

    private void SetErrorStatus(string t)
    {
        lbStatus.Text = t;
        lbStatus.ForeColor = Constant.StatusColor.Error;
    }

    private void ClearData()
    {
        cmbFoodMDType.SelectedValue = "0";
        txtAddcap.Text = "";
        txtAddEnerRate.Text = "";
        txtAddCapRate.Text = "";
        chkActive.Checked = true;
        txtAddEnergy.Text = "";
        grvInventory.DataSource = null;
        grvInventory.DataBind();
        grvNutrient.DataSource = null;
        grvNutrient.DataBind();
        TabContainer1.Visible = false;
        txtflage.Text = "0";
    }

    private FormulaFeedData GetData()
    {
        FormulaFeedData fData = new FormulaFeedData();
        fData.MATERIALMASTER = Convert.ToDouble(cmbFoodMDType.SelectedItem.Value.ToString());
        fData.CAPACITY = Convert.ToDouble(txtAddcap.Text.Trim());
        fData.ENERGYRATE = Convert.ToDouble(txtAddEnerRate.Text.Trim());
        fData.CAPACITYRATE = Convert.ToDouble(txtAddCapRate.Text.Trim());
        fData.ACTIVE = chkActive.Checked;
        fData.LOID = Convert.ToDouble("0" + txhID.Text);
        fData.ENERGY = Convert.ToDouble(txtFullEnergy.Text.Trim());
        fData.NAME = cmbFoodMDType.SelectedItem.ToString();
        return fData;
    }

    private void CalculateEnergy()
    {
        FormulaFeedMDFlow ffFlow = new FormulaFeedMDFlow();
        double cap = (txtAddcap.Text == "" ? 0 : Convert.ToDouble(txtAddcap.Text.Trim()));
        double caprate = (txtAddCapRate.Text == "" ? 0 : Convert.ToDouble(txtAddCapRate.Text.Trim()));
        double energyrate = (txtAddEnerRate.Text == "" ? 0 : Convert.ToDouble(txtAddEnerRate.Text.Trim()));
        txtFullEnergy.Text = Convert.ToString(ffFlow.CalculateEnergy(cap, caprate, energyrate));
        double dd = Convert.ToDouble(txtFullEnergy.Text.Trim());
        txtAddEnergy.Text = dd.ToString("#,##0.00");
    }

    protected void txtAddcap_TextChanged(object sender, EventArgs e)
    {
        if (txtAddcap.Text != "" && txtAddCapRate.Text != "" && txtAddEnerRate.Text != "" && txtAddEnerRate.Text.Trim() != "0" && txtAddCapRate.Text.Trim() != "0")
        {
            CalculateEnergy();
        }
        FormulaFeedMDPop.Show();
    }

    protected void txtAddEnerRate_TextChanged(object sender, EventArgs e)
    {
        if (txtAddcap.Text != "" && txtAddCapRate.Text != "" && txtAddEnerRate.Text != "" && txtAddEnerRate.Text.Trim() != "0" && txtAddCapRate.Text.Trim() != "0")
        {
            CalculateEnergy();
        }
        FormulaFeedMDPop.Show();
    }

    protected void txtAddCapRate_TextChanged(object sender, EventArgs e)
    {
        if (txtAddcap.Text != "" && txtAddCapRate.Text != "" && txtAddEnerRate.Text != "" && txtAddEnerRate.Text.Trim() != "0" && txtAddCapRate.Text.Trim() != "0")
        {
            CalculateEnergy();
        }
        FormulaFeedMDPop.Show();
    }

    protected void TabChanged_Click(object sender, EventArgs e)
    {
        if (flag == false)
        {
            flag = true;
            bool ret = true;
            if (TabContainer1.ActiveTabIndex == 0)
            {
                doGetDetail(txhID.Text.Trim());
                FormulaFeedMDPop.Show();
                TabContainer1.Visible = true;
                TabContainer1.ActiveTabIndex = 0;
                txtflage.Text = "1";
                tbPrint.Visible = (txhID.Text.Trim() != "");
            }
            else if (TabContainer1.ActiveTabIndex == 1)
            {
                //สารอาหารที่ได้รับ
                if (doSave())
                {
                    ret = doSaveFormulaFeedItem();
                    if (!ret)
                    {
                        TabContainer1.ActiveTabIndex = 0;
                    }
                    else
                    {
                        this.tbPrint.Visible = (txhID.Text.Trim() != "");
                        txtflage.Text = "1";
                        doGetDetail(txhID.Text.Trim());
                        doGetNutrient();
                    }
                }
                else
                {
                    TabContainer1.ActiveTabIndex = 0;
                }
            }
        }
        else
            flag = false;

        FormulaFeedMDPop.Show();
    }

    private void ClearSearch()
    {
        // Clear searh data
        cmbType.SelectedIndex = 0;
        txtEnergyFrom.Text = "";
        txtEnergyTo.Text = "";
        txtCapFrom.Text = "";
        txtCapTo.Text = "";
    }

    #endregion

    #region Working Method

    private void doGetList()
    {
        FormulaFeedMDFlow fFlow = new FormulaFeedMDFlow();
        Double energyfrom = 0;
        Double energyto = 0;
        Double capfrom = 0;
        Double capto = 0;

        imbReset.Visible = (txtEnergyFrom.Text.Trim() != "") || (cmbType.SelectedIndex != 0) || (txtEnergyTo.Text.Trim() != "") || (txtCapFrom.Text.Trim() != "") || (txtCapTo.Text.Trim() != "");

        string orderStr = "";
        if (txhSortField.Text.Trim() != "")
            orderStr = " " + txhSortField.Text + " " + txhSortDir.Text;

        energyfrom = Convert.ToDouble((txtEnergyFrom.Text == "" ? "0" : txtEnergyFrom.Text.Trim()));
        energyto = Convert.ToDouble((txtEnergyTo.Text == "" ? "0" : txtEnergyTo.Text.Trim()));

        capfrom = Convert.ToDouble((txtCapFrom.Text == "" ? "0" : txtCapFrom.Text.Trim()));
        capto = Convert.ToDouble((txtCapTo.Text == "" ? "0" : txtCapTo.Text.Trim()));

        grvResult.DataSource = fFlow.GetFormulaFeedMDSearch(Convert.ToDouble(cmbType.SelectedItem.Value.ToString()), energyfrom, energyto, capfrom, capto, orderStr);
        grvResult.DataBind();
        pcTop.Update();
        pcBot.Update();
    }

    private bool doGetDetail(string LOID)
    {
        bool ret = true;
        FormulaFeedMDFlow ffFlow = new FormulaFeedMDFlow();

        if (txtflage.Text.Trim() != "2")
        {
            FormulaFeedData ffdata = ffFlow.GetFormulaFeedData(Convert.ToDouble(LOID));
            DataTable fidata = ffFlow.GetFormulaFeedItemData(Convert.ToDouble(LOID));
            if (ffdata.LOID != 0)
            {
                SetData(ffdata, fidata);
            }
            else
            {
                ret = false;
                txtflage.Text = "0";
            }

        }
        else if (txtflage.Text.Trim() == "2")
        {
            FormulaFeedData ffdata = ffFlow.GetFormulaFeedDataCopy(Convert.ToDouble(LOID));
            DataTable fidata = ffFlow.GetFormulaFeedItemDataCopy(Convert.ToDouble(LOID));
            if (ffdata.LOID != 0)
            {
                SetData(ffdata, fidata);
            }
            else
            {
                ret = false;
                txtflage.Text = "0";
            }
        }
        return ret;
    }

    private void DoGetDataCalculator()
    {
        //รายการวัตถุดิบ
        CreateTempTable();
        tempTable.Rows.Clear();
        DataTable dt = new DataTable();
        FormulaFeedMDFlow ffFlow = new FormulaFeedMDFlow();

        dt = ffFlow.CalculateInventory(Convert.ToDouble(cmbFoodMDType.SelectedItem.Value.ToString()));
        if (dt.Rows.Count > 0)
        {

            for (int i = 0; i < dt.Rows.Count; i++)
            {
                DataRow dr = tempTable.Rows.Add();
                dr["MATERIALNAME"] = dt.Rows[i]["MATERIALNAME"].ToString();
                double tmp = Convert.ToDouble(txtAddEnergy.Text.Trim()) / Convert.ToDouble(dt.Rows[i]["COST"].ToString());
                dr["COST"] = tmp.ToString("#,##0.00");
                dr["ABBNAME"] = dt.Rows[i]["ABBNAME"].ToString();
                dr["UULOID"] = dt.Rows[i]["UULOID"].ToString();
                dr["FFLOID"] = dt.Rows[i]["FFLOID"].ToString();
                dr["LOID"] = dt.Rows[i]["LOID"].ToString();
                dr["FILOID"] = dt.Rows[i]["FILOID"].ToString();
                txtCalWeight.Text = dr["COST"].ToString();
            }

            //รายการน้ำ
            DataTable dtt = ffFlow.GetWater();
            double filoid = ffFlow.getFILoid(Convert.ToDouble(cmbFoodMDType.SelectedItem.Value.ToString()));
            if (dtt.Rows.Count == 1)
            {
                for (int i = 0; i < dtt.Rows.Count; i++)
                {
                    DataRow ddr = tempTable.Rows.Add();
                    ddr["MATERIALNAME"] = dtt.Rows[i]["MATERIALNAME"].ToString();
                    double tmp1 = Convert.ToDouble(txtAddcap.Text.Trim()) - Convert.ToDouble(txtCalWeight.Text.Trim());
                    ddr["COST"] = tmp1.ToString("#,##0.00");
                    ddr["ABBNAME"] = dtt.Rows[i]["ABBNAME"].ToString();
                    ddr["UULOID"] = dtt.Rows[i]["UULOID"].ToString();
                    ddr["FFLOID"] = (dt.Rows[i]["FFLOID"].ToString() == "" ? dtt.Rows[i]["FFLOID"].ToString() : dt.Rows[i]["FFLOID"].ToString());
                    ddr["LOID"] = dtt.Rows[i]["LOID"].ToString();
                    ddr["FILOID"] = (filoid == 0 ? filoid.ToString() : dt.Rows[i]["FILOID"].ToString());
                }
            }
        }
        else
        {
            SetErrorStatus("ไม่พบข้อมูลหน่วยกรัม");
        }

        Session["FormulaFeedMD"] = tempTable;
        grvInventory.DataSource = Session["FormulaFeedMD"];
        grvInventory.DataBind();
    }

    private bool doGetNutrient()
    {
        bool ret = true;
        if (txhID.Text != "")
        {
            FormulaFeedMDFlow fFlow = new FormulaFeedMDFlow();
            DataTable dt = fFlow.GetNutrient(Convert.ToDouble(txhID.Text.Trim()));
            if (dt.Rows.Count > 0)
            {
                grvNutrient.DataSource = dt;
                grvNutrient.DataBind();
                ret = true;
            }
            else
            {
                ret = false;
            }
        }
        return ret;
    }

    private void doDelete(string loid)
    {
        FormulaFeedMDFlow ffFlow = new FormulaFeedMDFlow();
        if (ffFlow.DeleteFormulaFeedByLoid(Convert.ToDouble(loid)))
        {
            grvResult.PageIndex = 0;
            doGetList();
            lbStatusMain.Text = "";
        }
        else
        {
            lbStatusMain.Text = ffFlow.ErrorMessage;
            lbStatusMain.ForeColor = System.Drawing.Color.Red;
        }
    }

    private bool doSave()
    {
        //verify required field
        string error = VerifyData();
        if (error != "")
        {
            SetErrorStatus(error);
            return false;
        }

        FormulaFeedMDFlow ffFlow = new FormulaFeedMDFlow();
        bool ret = true;
        double floid = 0;

        // verify uniq field
        if (!ffFlow.CheckUniqMaterial(Convert.ToDouble(cmbFoodMDType.SelectedItem.Value), Convert.ToDouble(txtAddcap.Text.Trim()), Convert.ToDouble(txtFullEnergy.Text.Trim()), Convert.ToDouble(txhID.Text == "" ? "0" : txhID.Text.Trim())))
        {
            SetErrorStatus("มีสูตรอาหารทางการแพทย์ " +  cmbFoodMDType.SelectedItem.ToString()+' '+"ปริมาณ"+' '+ txtAddcap.Text.Trim()+ " ml. ในฐานข้อมูลแล้ว");
            return false;
        }


        //data correct go on saving...
        if (txtflage.Text != "1" || txhID.Text.Trim() == "")
        {
            //  save new
            floid = ffFlow.InsertDataFormulaFeed(GetData(), Appz.CurrentUser);
            txhID.Text = floid.ToString();
            ret = true;
        }

        else
        {
            //save update
            floid = ffFlow.UpdateDataFormulaFeed(GetData(), Appz.CurrentUser);
        }

        if (floid == 0)
        {
            SetErrorStatus(ffFlow.ErrorMessage);
            ret = false;
        }

        else
            doGetList();

        return ret;
    }

    private bool doSaveFormulaFeedItem()
    {
        bool ret = true;

        //verify required field
        string error = VerifyData();

        if (error != "")
        {
            SetErrorStatus(error);
            return false;
        }

        FormulaFeedMDFlow ffFlow = new FormulaFeedMDFlow();

        //data correct go on saving & update...
        if (Session["FormulaFeedMD"] != null)
        {
            DataTable dt = new DataTable();
            dt = (DataTable) Session["FormulaFeedMD"];

            for (int i = 0; i < grvInventory.Rows.Count; i++)
            {
                Label lblName = (Label)grvInventory.Rows[i].FindControl("lblName");

                if (dt.Rows[i]["MATERIALNAME"].ToString() == lblName.Text.Trim())
                {
                    TextBox txtEditCost = (TextBox)grvInventory.Rows[i].FindControl("txtEditCost");
                    dt.Rows[i]["COST"] = txtEditCost.Text.Trim();
                    dt.Rows[i]["LOID"] = grvInventory.Rows[i].Cells[0].Text;
                    dt.Rows[i]["UULOID"] = grvInventory.Rows[i].Cells[6].Text;
                }
            }
            Session["FormulaFeedMD"] = dt;
            tempFormulaFeedMD = (DataTable)Session["FormulaFeedMD"];
        }

        ret = ffFlow.InsertFormulaFeedItem(Appz.CurrentUser.ToString(), tempFormulaFeedMD, Convert.ToDouble(txhID.Text.Trim()));

        if (!ret)
            SetErrorStatus(ffFlow.ErrorMessage);


        return ret;
    }

    private void doDeleteFormulaItemOnGrid()
    {
        ArrayList arrMMLOIDList = GetChecked();
        DataTable dt = (DataTable)Session["FormulaFeedMD"];

        if (arrMMLOIDList.Count > 0 && dt != null)
        {
            foreach (string mmloid in arrMMLOIDList)
            {
                for (int i = 0; i < dt.Rows.Count; i++)
                {
                    if (mmloid == dt.Rows[i]["LOID"].ToString())
                    {
                        DataRow dr = dt.Rows[i];
                        dt.Rows.Remove(dr);
                        //dt.Rows[i].Delete();
                    }
                }
            }
        }
        Session["FormulaFeedMD"] = dt;
        BindGVFeedItem();
    }

    private string VerifyData()
    {
        string ret = "";
        bool check = true;
        FormulaFeedData fData = GetData();
        if (fData.MATERIALMASTER == 0)
            ret = string.Format(DataResources.MSGEI002, "ชนิดอาหารทางการแพทย์");
        else if (fData.CAPACITY == 0)
            ret = string.Format(DataResources.MSGEI001, "ปริมาณ");
        else if (fData.ENERGYRATE == 0)
            ret = string.Format(DataResources.MSGEI001, "อัตราส่วนพลังงาน");
        else if (fData.CAPACITYRATE == 0)
            ret = string.Format(DataResources.MSGEI001, "อัตราส่วนปริมาณ");

        if (ret == "")
        {
            foreach (GridViewRow row in grvInventory.Rows)
            {
                TextBox txt = (TextBox)row.Cells[4].FindControl("txtEditCost");
                if (txt.Text == "" || Convert.ToDouble(txt.Text) == 0)
                {
                    check = false;
                    break;
                }
            }
            if (!check)
                ret = string.Format("จำนวนในรายการวัตถุดิบต้องมากกว่า 0");
        }

        return ret;
    }

    private bool InsertNewDataToTmpFeedItem(ArrayList arrData)
    {
        bool ret = true;
        DataTable dt = (DataTable)Session["FormulaFeedMD"];

        try
        {
            for (int i = 0; i < arrData.Count; i++)
            {
                VMaterialMasterData VMaterialMaster = (VMaterialMasterData)arrData[i];
                DataRow dr = dt.NewRow();
                dr["LOID"] = VMaterialMaster.LOID;
                dr["MATERIALNAME"] = VMaterialMaster.MATERIALNAME;
                dr["UULOID"] = VMaterialMaster.ULOID;
                dr["ABBNAME"] = VMaterialMaster.UNITNAME;
                dt.Rows.Add(dr);
            }

            Session["FormulaFeedMD"] = dt;
        }
        catch (Exception ex)
        {
            ex.ToString();
            ret = false;
        }

        return ret;
    }

    private void BindGVFeedItem()
    {
        if (Session["FormulaFeedMD"] != null)
        {
            DataTable dt = (DataTable)Session["FormulaFeedMD"];
            grvInventory.DataSource = dt;
            grvInventory.DataBind();
            FormulaFeedMDPop.Show();
        }
    }

    #endregion



}
