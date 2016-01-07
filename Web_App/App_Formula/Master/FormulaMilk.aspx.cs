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
/// FormulaMilk Page Class
/// Version 1.0
/// =========================================================================
/// Create by: Nang
/// Create Date: 16 Jan 2009
/// -------------------------------------------------------------------------
/// Modify By: -
/// Modify From: -
/// Modify Date: -
/// -------------------------------------------------------------------------
/// Remark: -
/// Description:
///    หน้าการทำงานข้อมูลสูตรนมผสมสำหรับเด็ก FomulaMilk
/// Changes:
///    1.0 - สร้าง
/// -------------------------------------------------------------------------
/// =========================================================================
/// </summary>

public partial class App_Formula_Master_FormulaMilk : System.Web.UI.Page
{
    private DataTable tempTable = null;
    private DataTable tempFormulaMilk = null;
    private bool flag = true;

    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            CreateTempTable();
            grvResult.PageIndex = 0;
            doGetList();
        }
        if (this.hdShowMaterialPopup.Value == "1")
            FormulaMilkPop.Show();
    }

    protected override void OnInit(EventArgs e)
    {
        base.OnInit(e);
        ControlUtil.SetNumberTextbox(txtEnergyFrom);
        ControlUtil.SetNumberTextbox(txtEnergyTo);
        ControlUtil.SetNumberTextbox(txtEnergy);
        ControlUtil.SetNumberTextbox(txtMilkCap);
        Appz.BuildCombo(cmbSearchMilkType, "MILKCATEGORY", "NAME", "LOID", "ACTIVE= '1'", "NAME", "ทั้งหมด", "0", true);
        Appz.BuildCombo(cmbMilkCatagory , "MILKCATEGORY", "NAME", "LOID", "ACTIVE= '1'", "NAME", "เลือก", "0", true);
        pcTop.SetMainGridView(grvResult);
        pcBot.SetMainGridView(grvResult);
    }

    protected void ctlMaterialMasterPopup_SelectedIndexChanged(object sender, EventArgs e, ArrayList arrData)
    {
        this.hdShowMaterialPopup.Value = "0";
        UpdateFormulamilkItem();
        if (InsertNewDataToTmpMilkItem(arrData))
            BindGVMilkItem();
    }

    protected void ctlMaterialMasterPopup_Cancel(object sender, EventArgs e)
    {
        this.hdShowMaterialPopup.Value = "0";
    }

    #region Button Click Event Handler

    #region Main Toolbar

    protected void tbAddClick(object sender, EventArgs e)
    {
        FormulaMilkPop.Show();
        cmbMilkCatagory.Enabled = true;
    }

    protected void lnkType_Click(object sender, EventArgs e)
    {
        doGetDetail(((LinkButton)sender).CommandArgument);
        FormulaMilkPop.Show();
        TabContainer1.Visible = true;
        TabContainer1.ActiveTabIndex = 0;
        txtflage.Text = "1";
        tbPrint.Visible = (txhID.Text.Trim() != "");
        cmbMilkCatagory.Enabled = false;
    }

    protected void tbAddFormulaMilkItemClick(object sender, EventArgs e)
    {
        this.hdShowMaterialPopup.Value = "1";
        this.ctlMaterialMasterPopup.Show("", getMaterialList());
        FormulaMilkPop.Show();
    }

    private string getMaterialList()
    {
        string materialList = "";
        DataTable dt = (DataTable)Session["FormulaMilk"];
        if (dt != null)
        {
            for (int i = 0; i < dt.Rows.Count; ++i)
            {
                materialList += (materialList == "" ? "" : ",") + dt.Rows[i]["MMLOID"].ToString();
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

    #endregion

    #region Inventory Toolbar

    protected void tbSave1Click(object sender, EventArgs e)
    {
        bool ret = true;
        if (doSave())
        {
            ret = doSaveFormulaMilkItem();
            if (!ret)
            {
                SetErrorStatus("เกิดข้อผิดพลาดในการแก้ไขข้อมูล");
            }
            else
            {
                ClearData();
                Session["FormulaMilk"] = null;
                doGetList();
            }
        }
        else
        {
            //SetErrorStatus("เกิดข้อผิดพลาดในการแก้ไขข้อมูล");
            FormulaMilkPop.Show();
        }
    }

    protected void tbReturnClick(object sender, EventArgs e)
    {
        if (txhID.Text.Trim() == "")
        {
            cmbMilkCatagory.Enabled = true;
            ClearData();
        }
        else
            doGetDetail(txhID.Text);

        FormulaMilkPop.Show();
    }

    protected void tbBackClick(object sender, EventArgs e)
    {
        ClearData();
        cmbMilkCatagory.Enabled = true;
    }

    protected void tbDeleteFormulaMilkItemClick(object sender, EventArgs e)
    {
        UpdateFormulamilkItem();
        doDeleteFormulaMilkItemOnGrid();
    }

    #endregion

    #region Button Popup
    //ปุ่มคำนวณ
    protected void calculator_Click(object sender, ImageClickEventArgs e)
    {
        FormulaMilkFlow fmFlow = new FormulaMilkFlow();
        if(!fmFlow.CheckUniqe(cmbMilkCatagory.SelectedValue.ToString()+txtEnergy.Text.Trim(),Convert.ToDouble((txhID.Text ==""?"0":txhID.Text.Trim()))))
        {
             SetErrorStatus("มีข้อมูลสูตรนมผงสำหรับเด็กนี้ในฐานข้อมูลแล้ว");
        }
        else
        {
            getmilk();
            DoGetDataCalculator();
            TabContainer1.Visible = true;
        }
        FormulaMilkPop.Show();
        TabContainer1.ActiveTabIndex = 0;
    }

    #endregion

    #region Button On GridviewPopup

    protected void imbEditSearch_Click(object sender, ImageClickEventArgs e)
    {
        //ctlMaterialMasterPopup.Show("2");
        //FormulaMilkPop.Show();
    }

    protected void imbNewSearch_Click(object sender, ImageClickEventArgs e)
    {
        //this.txtFormulaSetItemRow.Text = ((ImageButton)sender).CommandArgument;
        //ctlMaterialMasterPopup.Show("2");
        //FormulaMilkPop.Show();
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


            ImageButton imbCopyMain = (ImageButton)e.Row.FindControl("imbCopyMain");
            LinkButton lnkType = (LinkButton)e.Row.FindControl("lnkType");
            if (imbCopyMain != null)
                imbCopyMain.OnClientClick = "return confirm('ต้องการคัดลอกรายการข้อมูลสูตร" + ' ' + lnkType.Text + ' ' + "ใช่หรือไม่?')";

        }
    }

    protected void grvResult_SelectedIndexChanging(object sender, GridViewSelectEventArgs e)
    {
        if (e.NewSelectedIndex > -1)
        {
            txtflage.Text = "2";
            doGetDetail(grvResult.Rows[e.NewSelectedIndex].Cells[0].Text.Trim());
            FormulaMilkPop.Show();
            TabContainer1.Visible = true;
            TabContainer1.ActiveTabIndex = 0;
        }
    }

    #endregion

    #region GrvFormulaMilkItem

    protected void grvFormulaMilkItem_RowDataBound(object sender, GridViewRowEventArgs e)
    {
        if (e.Row.RowType == DataControlRowType.Header)
        {
            ((CheckBox)e.Row.Cells[1].FindControl("chkAll")).Attributes.Add("onclick", "chkAllBox(this, '" + this.grvFormulaMilkItem.ClientID + "_ctl', '_chkSelect')");
        }

        if (e.Row.RowIndex > -1)
        {
            TextBox txtQty = (TextBox)e.Row.FindControl("txtQty");
            ControlUtil.SetDblTextBox(txtQty);
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
        DataColumn dcQTY = new DataColumn("QTY");
        DataColumn dcUNITNAME = new DataColumn("UNITNAME");
        DataColumn dcUULOID = new DataColumn("UULOID");
        DataColumn dcFMLOID = new DataColumn("FMLOID");
        DataColumn dcFMILOID = new DataColumn("FMILOID");
        DataColumn dcMMLOID = new DataColumn("MMLOID");
        DataColumn dcENERGY = new DataColumn("ENERGY");

        tempTable.Columns.Add(dcMATERIALNAME);
        tempTable.Columns.Add(dcQTY);
        tempTable.Columns.Add(dcUNITNAME);
        tempTable.Columns.Add(dcUULOID);
        tempTable.Columns.Add(dcFMLOID);
        tempTable.Columns.Add(dcFMILOID);
        tempTable.Columns.Add(dcMMLOID);
        tempTable.Columns.Add(dcENERGY);
    }

    private ArrayList GetChecked()
    {
        ArrayList arrChk = new ArrayList();
        for (int i = 0; i < grvFormulaMilkItem.Rows.Count; i++)
        {
            if (i > -1 && grvFormulaMilkItem.Rows[i].Cells[0].FindControl("chkSelect") != null)
            {
                if (((CheckBox)grvFormulaMilkItem.Rows[i].Cells[1].FindControl("chkSelect")).Checked)
                    arrChk.Add(grvFormulaMilkItem.Rows[i].Cells[8].Text);
            }
        }

        return arrChk;
    }

    private double CalculateMilk()
    {
        double energy = Convert.ToDouble(txtEnergy.Text.Trim());
        double cap = Convert.ToDouble(txtMilkCap.Text.Trim());
        double menergy = Convert.ToDouble(txtMEnergy.Text.Trim());
        double nutrientRate = Convert.ToDouble(txtNutrientRate.Text.Trim());
        return (energy * cap * nutrientRate) / menergy;
    }

    #endregion

    #region Controls Management Methods

    private void ClearSearch()
    {
        this.cmbSearchMilkType.SelectedIndex = 0;
        this.txtEnergyFrom.Text = "";
        this.txtEnergyTo.Text = "";
    }

    private void UpdateFormulamilkItem()
    {
        DataTable dt = (DataTable)Session["FormulaMilk"];
        if (dt != null)
        {
            for (int i = 0; i < this.grvFormulaMilkItem.Rows.Count; ++i)
            {
                GridViewRow gRow = this.grvFormulaMilkItem.Rows[i];
                DataRow[] dRow = dt.Select("MMLOID=" + gRow.Cells[8].Text);
                if (dRow.Length == 1)
                    dRow[0]["QTY"] = Convert.ToDouble("0" + ((TextBox)gRow.Cells[4].FindControl("txtQty")).Text);
            }
        }
        Session["FormulaMilk"] = dt;
    }

    private void doDeleteFormulaMilkItemOnGrid()
    {
        ArrayList arrMMLOIDList = GetChecked();
        DataTable dt = (DataTable)Session["FormulaMilk"];

        if (arrMMLOIDList.Count > 0 && dt != null)
        {
            foreach (string mmloid in arrMMLOIDList)
            {
                for (int i = 0; i < dt.Rows.Count; i++)
                {
                    if (mmloid == dt.Rows[i]["MMLOID"].ToString())
                    {
                        DataRow dr = dt.Rows[i];
                        dt.Rows.Remove(dr);
                    }
                }
            }
        }
        Session["FormulaMilk"] = dt;
        BindGVMilkItem();
    }

    private void SetData(FormulaMilkData fmData, DataTable fmiData)
    {
        txhID.Text = fmData.LOID.ToString();
        txtEnergy.Text = fmData.ENERGY.ToString();
        txtMilkCap.Text = fmData.MILKCAPACITY.ToString();
        chkActive.Checked = (fmData.ACTIVE == "1" ? true : false);
        txtMilkCapacity.Text = fmData.MILKCAPACITY.ToString();

        this.tbPrint.ClientClick = Appz.OpenReportScript(Constant.Reports.FormulaMilkReport, Convert.ToDouble(txhID.Text.Trim()), false);
        this.tbPrint.Visible = (fmData.LOID != 0);

        cmbMilkCatagory.SelectedIndex = cmbMilkCatagory.Items.IndexOf(cmbMilkCatagory.Items.FindByValue(fmData.MILKCATEGORY.ToString()));
        CreateTempTable();
        tempTable = fmiData;
        Session["FormulaMilk"] = tempTable;
        BindGVMilkItem();
    }

    private void SetErrorStatus(string t)
    {
        lbStatus.Text = t;
        lbStatus.ForeColor = Constant.StatusColor.Error;
    }

    private void ClearData()
    {
        cmbMilkCatagory.SelectedValue = "0";
        txtMilkCap.Text = "1";
        txtEnergy.Text = "";
        grvFormulaMilkItem.DataSource = null;
        grvFormulaMilkItem.DataBind();
        grvNutrient.DataSource = null;
        grvNutrient.DataBind();
        TabContainer1.Visible = false;
        txtflage.Text = "0";
    }

    private FormulaMilkData GetData()
    {
        FormulaMilkData fmData = new FormulaMilkData();
        fmData.MILKCATEGORY = (cmbMilkCatagory.SelectedItem.Value == null ? 0 : Convert.ToDouble(cmbMilkCatagory.SelectedItem.Value.ToString()));
        fmData.ENERGY = Convert.ToDouble((txtEnergy.Text == ""?"0":txtEnergy.Text.Trim()));
        fmData.CAPACITY = Convert.ToDouble((txtMilkCap.Text ==""?"0":txtMilkCap.Text.Trim()));
        fmData.ACTIVE = (chkActive.Checked ? "1" : "0");
        fmData.NAME = (cmbMilkCatagory.SelectedItem.ToString() == ""?"":cmbMilkCatagory.SelectedItem.ToString() + txtEnergy.Text.Trim());
        fmData.LOID = Convert.ToDouble("0" + txhID.Text);
        fmData.MILKCAPACITY =(txtMilkCapacity.Text ==""?0: Convert.ToDouble(txtMilkCapacity.Text.Trim()));
        return fmData;
    }

    protected void cmbMilkCatagory_SelectedIndexChanged(object sender, EventArgs e)
    {
        FormulaMilkPop.Show();
        getmilk();
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
                FormulaMilkPop.Show();
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
                    ret = doSaveFormulaMilkItem();
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

        FormulaMilkPop.Show();
    }

    protected void getmilk()
    {
        string str = "";
        FormulaMilkFlow fmFlow = new FormulaMilkFlow();
        if (cmbMilkCatagory.SelectedItem.Value.ToString() != "0")
        {
            str = fmFlow.GetSpecificMilk(cmbMilkCatagory.SelectedItem.Value.ToString());
            txtMilkType.Text = (str == "N" ? "" : "นมเฉพาะโรค");
        }
        else
        {
            txtMilkType.Text = "";
        }

        txtMEnergy.Text = fmFlow.GetMaterialMasterEnergy(cmbMilkCatagory.SelectedItem.Value.ToString());
        txtNutrientRate.Text = fmFlow.GetNutrientRate(Convert.ToDouble(cmbMilkCatagory.SelectedItem.Value)).ToString();
    }
    #endregion

    #region Working Method

    private void doGetList()
    {
        FormulaMilkFlow fmFlow = new FormulaMilkFlow();
        string orderStr = "";
        if (txhSortField.Text.Trim() != "")
            orderStr = " " + txhSortField.Text + " " + txhSortDir.Text;

        this.imbReset.Visible = (this.cmbSearchMilkType.SelectedIndex != 0) || (this.txtEnergyFrom.Text.Trim() != "") || (this.txtEnergyTo.Text.Trim() != "");

        grvResult.DataSource = fmFlow.GetFormulaMilkSearch(txtEnergyFrom.Text.Trim(), txtEnergyTo.Text.Trim(), cmbSearchMilkType.SelectedItem.ToString(), orderStr);
        grvResult.DataBind();
        pcTop.Update();
        pcBot.Update();
    }

    private bool doGetDetail(string LOID)
    {
        bool ret = true;
        FormulaMilkFlow fmFlow = new FormulaMilkFlow();

        if (txtflage.Text.Trim() != "2")
        {
            FormulaMilkData fmData = fmFlow.GetFormulaMilkData(Convert.ToDouble(LOID));
            DataTable fmiData = fmFlow.GetFormulaMilkItemData(Convert.ToDouble(LOID));
            if (fmData.LOID != 0)
            {
                SetData(fmData, fmiData);
            }
            else
            {
                ret = false;
                txtflage.Text = "0";
            }

        }
        //Copy Data
        else if (txtflage.Text.Trim() == "2")
        {
            FormulaMilkData fmdata = fmFlow.GetFormulaMilkDataCopy(Convert.ToDouble(LOID));
            DataTable fmidata = fmFlow.GetFormulaMilkItemDataCopy(Convert.ToDouble(LOID));
            if (fmdata.LOID != 0)
            {
                SetData(fmdata, fmidata);
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
        CreateTempTable();
        tempTable.Rows.Clear();
        DataTable dt = new DataTable();
        FormulaMilkFlow fmFlow = new FormulaMilkFlow();

        dt = fmFlow.GetMaterialMaster(Convert.ToDouble(cmbMilkCatagory.SelectedItem.Value));
        if (dt.Rows.Count > 0)
        {

            for (int i = 0; i < dt.Rows.Count; i++)
            {
                DataRow dr = tempTable.Rows.Add();
                dr["MATERIALNAME"] = dt.Rows[i]["MATERIALNAME"].ToString();
                dr["QTY"] = CalculateMilk().ToString("#,##0.00");
                txtMilkCapacity.Text = dr["QTY"].ToString();
                dr["UNITNAME"] = dt.Rows[i]["UNITNAME"].ToString();
                dr["UULOID"] = dt.Rows[i]["UULOID"].ToString();
                dr["FMLOID"] = "0";
                dr["MMLOID"] = dt.Rows[i]["MMLOID"].ToString();
                double fienergy1 = fmFlow.GetFIenergy(Convert.ToDouble(dt.Rows[i]["MMLOID"].ToString()));
                dr["ENERGY"] = fienergy1.ToString("#,##0.00");
                dr["FMILOID"] = "0";
            }

            //รายการน้ำ
            DataTable dtt = fmFlow.GetWater();
            if (dtt.Rows.Count == 1)
            {
                for (int i = 0; i < dtt.Rows.Count; i++)
                {
                    DataRow ddr = tempTable.Rows.Add();
                    ddr["MATERIALNAME"] = dtt.Rows[i]["MATERIALNAME"].ToString();
                    double tmp1 = (Convert.ToDouble(txtMilkCap.Text.Trim()) * 30) - CalculateMilk();
                    ddr["QTY"] =   tmp1.ToString("#,##0.00");
                    ddr["UNITNAME"] = dtt.Rows[i]["ABBNAME"].ToString();
                    ddr["UULOID"] = dtt.Rows[i]["UULOID"].ToString();
                    ddr["FMLOID"] = (dtt.Rows[i]["FFLOID"].ToString() == "" ? dtt.Rows[i]["FFLOID"].ToString() : dtt.Rows[i]["FFLOID"].ToString());
                    ddr["MMLOID"] = dtt.Rows[i]["LOID"].ToString();
                    ddr["FMILOID"] = "";
                    double fienergy2 = fmFlow.GetFIenergy(Convert.ToDouble(dtt.Rows[i]["LOID"].ToString()));
                    ddr["ENERGY"] = fienergy2.ToString("#,##0.00");
                }
            }
        }
        else
        {
            SetErrorStatus("ไม่พบข้อมูลหน่วยกรัม");
        }

        Session["FormulaMilk"] = tempTable;
        BindGVMilkItem();
    }

    private bool doGetNutrient()
    {
        bool ret = true;
        if (txhID.Text != "")
        {
            FormulaMilkFlow fmFlow = new FormulaMilkFlow();
            DataTable dt = fmFlow.GetNutrient(Convert.ToDouble(txhID.Text.Trim()));
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
        FormulaMilkFlow fmFlow = new FormulaMilkFlow();
        if (fmFlow.DeleteFormulaMilkByLoid(Convert.ToDouble(loid)))
        {
            grvResult.PageIndex = 0;
            doGetList();
            lbStatusMain.Text = "";
        }
        else
        {
            lbStatusMain.Text = fmFlow.ErrorMessage;
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

        FormulaMilkFlow fmFlow = new FormulaMilkFlow();
        bool ret = true;
        double floid = 0;

        // verify uniq field
        if (!fmFlow.CheckUniqe(cmbMilkCatagory.SelectedItem.ToString() + txtEnergy.Text.Trim(), Convert.ToDouble(txhID.Text == "" ? "0" : txhID.Text.Trim())))
        {
            SetErrorStatus("มีชนิดนมผงนี้ในฐานข้อมูลแล้ว");
            return false;
        }


        //data correct go on saving...
        if (txtflage.Text != "1" || txhID.Text.Trim() == "")
        {
            //  save new
            floid = fmFlow.InsertFormulaMilk(GetData(), Appz.CurrentUser);
            txhID.Text = floid.ToString();
            ret = true;
        }
        else
        {
            //save update
            floid = fmFlow.UpdateFormulaMilk(GetData(), Appz.CurrentUser);
        }

        if (floid == 0)
        {
            SetErrorStatus(fmFlow.ErrorMessage);
            ret = false;
        }

        else
            doGetList();

        return ret;
    }

    private bool doSaveFormulaMilkItem()
    {
        bool ret = true;

        //verify required field
        string error = VerifyData();

        if (error != "")
        {
            SetErrorStatus(error);
            return false;
        }

        FormulaMilkFlow fmFlow = new FormulaMilkFlow();
        UpdateFormulamilkItem();
        //data correct go on saving & update...
        if (Session["FormulaMilk"] != null)
        {
            tempFormulaMilk = (DataTable)Session["FormulaMilk"];
        }

        ret = fmFlow.InsertFormulaMilkItem(Appz.CurrentUser.ToString(), tempFormulaMilk, Convert.ToDouble(txhID.Text.Trim()));

        if (!ret)
            SetErrorStatus(fmFlow.ErrorMessage);

        return ret;
    }

    private void doDeleteFormulaItemOnGrid()
    {
        ArrayList arrMMLOIDList = GetChecked();
        DataTable dt = (DataTable)Session["FormulaMilk"];

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
                        dt.Rows[i].Delete();
                    }
                }
            }
        }
        Session["FormulaMilk"] = dt;
        BindGVMilkItem();
    }

    private string VerifyData()
    {
        string ret = "";
        FormulaMilkData fmData = GetData();
        if (fmData.MILKCATEGORY == 0)
            ret = string.Format(DataResources.MSGEI002, "ชนิดนม");
        else if (fmData.ENERGY == 0)
            ret = string.Format(DataResources.MSGEI001, "พลังงานที่ต้องการ");
        else if (fmData.CAPACITY == 0)
            ret = string.Format(DataResources.MSGEI001, "ปริมาณ");

        return ret;
    }

    private bool InsertNewDataToTmpMilkItem(ArrayList arrData)
    {
        bool ret = true;
        DataTable dt = (DataTable)Session["FormulaMilk"];

        try
        {
            for (int i = 0; i < arrData.Count; i++)
            {
                VMaterialMasterData VMaterialMaster = (VMaterialMasterData)arrData[i];
                DataRow dr = dt.NewRow();
                dr["MMLOID"] = VMaterialMaster.LOID;
                dr["MATERIALNAME"] = VMaterialMaster.MATERIALNAME;
                dr["UULOID"] = VMaterialMaster.ULOID;
                dr["UNITNAME"] = VMaterialMaster.UNITNAME;
                FormulaMilkFlow fmFlow = new FormulaMilkFlow();
                double energy = fmFlow.GetFIenergy(Convert.ToDouble(VMaterialMaster.LOID.ToString()));
                dr["ENERGY"] = energy.ToString("#,##0.00");
                dt.Rows.Add(dr);
            }

            Session["FormulaMilk"] = dt;
        }
        catch (Exception ex)
        {
            ex.ToString();
            ret = false;
        }

        return ret;
    }

    private void BindGVMilkItem()
    {
        if (Session["FormulaMilk"] != null)
        {
            DataTable dt = (DataTable)Session["FormulaMilk"];
            grvFormulaMilkItem.DataSource = dt;
            grvFormulaMilkItem.DataBind();
            FormulaMilkPop.Show();
        }
    }

    #endregion

    protected void imbReset_Click(object sender, ImageClickEventArgs e)
    {
        ClearSearch();
        grvResult.PageIndex = 0;
        doGetList();
    }
}
