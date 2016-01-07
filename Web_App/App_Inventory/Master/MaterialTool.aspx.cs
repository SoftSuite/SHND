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
using SHND.Flow.Inventory;
using SHND.Data.Tables;
using SHND.Global;
using SHND.Flow.Common;
using SHND.Data.Common.Utilities;
/// <summary>
/// FeedType Page Class
/// Version 1.0
/// =========================================================================
/// Create by: Tan
/// Create Date: 12 Jan 2009
/// -------------------------------------------------------------------------
/// Modify By: -
/// Modify From: -
/// Modify Date: -
/// -------------------------------------------------------------------------
/// Remark: -
/// Description:
///    หน้ากาารทำงานข้อมูล Material Tool 
/// Changes:
///    1.0 - สร้าง
/// -------------------------------------------------------------------------
/// =========================================================================
/// </summary>
/// 

public partial class App_Inventory_Master_MaterialTool : System.Web.UI.Page
{
    private DataTable tmpTableFeedUnit = null;
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            doGetList();
        }
    }

    protected override void OnInit(EventArgs e)
    {
        base.OnInit(e);
        Appz.BuildCombo(cmbSearchGroup, "V_MATERIALGROUP", "NAME", "LOID", "MASTERTYPE IN ('TL','OT')", "NAME", "ทั้งหมด", "", false);
        Appz.BuildCombo(cmbMaterialGroup1, "V_MATERIALGROUP", "NAME", "LOID", "MASTERTYPE IN ('TL','OT')", "NAME", "เลือก", "0", false);
        Appz.BuildCombo(cmbUnit1, "UNIT", "THNAME", "LOID", "ACTIVE = '1'", "", "เลือก", "0", false);
        Appz.BuildCombo(cmbDivision, "DIVISION", "NAME", "LOID", "ISSTOCKOUT = 'Y' AND ACTIVE = '1'", "", "เลือก", "0", false);
        Appz.BuildCombo(cmbSAP, "V_SAPWAREHOUSE", "NAME", "LOID", "ACTIVE = '1'", "", "ไม่ระบุ", "0", false);

        this.tbExcel.ClientClick = @"window.open('" + Constant.HomeFolder + "App_Inventory/Master/MaterialFoodExcel.aspx?type=TOOLS&materialgroup=' + " +
            "document.getElementById('" + this.cmbSearchGroup.ClientID + @"').value + '&materialname=' + escape(trim(document.getElementById('" + this.txtSearchName.ClientID + "').value)), 'excelpop', 'resizable=yes,scrollbars=yes,width=1015,height=700,status=yes'); return false;";
        
        this.tbPrint.ClientClick = Appz.OpenReportScript(Constant.Reports.MaterialToolReport, "paramfield1=material&paramvalue1=' + document.getElementById('" + this.txtSearchName.ClientID + "').value + " +
            "'&paramfield2=group&paramvalue2=0' + document.getElementById('" + this.cmbSearchGroup.ClientID + "').value + '", true);


        pcTop.SetMainGridView(gvMain);
        pcBot.SetMainGridView(gvMain);
    }

    #region Button Click Event Handler
    protected void tbSave1Click(object sender, EventArgs e)
    {
        if (TabContainer1.ActiveTabIndex == 0)
        {
            if (doSaveTabFeedDetail() == true)
            {
                doGetFeedDetail(Convert.ToDouble(txhID.Text.Trim()));
            }
        }
        else if (TabContainer1.ActiveTabIndex == 1)
        {
            if (txhID.Text.Trim() != "")
            {
                if (doSaveTabFeedUnit() == true)
                {
                    doGetFeedDetail(Convert.ToDouble(txhID.Text.Trim()));
                }
            }
        }

        zPop.Show();
    }
    protected void tbSave2Click(object sender, EventArgs e)
    {
        if (TabContainer1.ActiveTabIndex == 0)
        {
            doSaveTabFeedDetail();

        }
        else if (TabContainer1.ActiveTabIndex == 1)
        {
            if (txhID.Text.Trim() != "")
            {
                doSaveTabFeedUnit();
            }
        }

        ClearDataTabFeedDetail();
        ClearDataTabFeedUnit();
        Session["tmpTableFeedUnit"] = null;
        TabContainer1.ActiveTabIndex = 0;
        txtCurrTabIndex.Text = "0";
        zPop.Show();
    }

    protected void tbAddClick(object sender, EventArgs e)
    {
        zPop.Show();
    }

    protected void tbDeleteClick(object sender, EventArgs e)
    {
        doDelete();
    }
    protected void tbCancelClick(object sender, EventArgs e)
    {
        if (TabContainer1.ActiveTabIndex == 0)
        {
            if (txhID.Text.Trim() == "")
                ClearDataTabFeedDetail();
            else
                doGetFeedDetail(Convert.ToDouble(txhID.Text.Trim()));

            zPop.Show();
        }
        else if (TabContainer1.ActiveTabIndex == 1)
        {
            if (txhID.Text.Trim() == "")
                ClearDataTabFeedUnit();
            else
                doGetFeedDetail(Convert.ToDouble(txhID.Text.Trim()));

            zPop.Show();
        }

    }
    protected void tbBackClick(object sender, EventArgs e)
    {
        ClearDataTabFeedDetail();
        ClearDataTabFeedUnit();
        Session["tmpTableFeedUnit"] = null;
        TabContainer1.ActiveTabIndex = 0;
        txtCurrTabIndex.Text = "0";
        doGetList();
    }
    protected void lnkName_Click(object sender, EventArgs e)
    {
        doGetFeedDetail(Convert.ToDouble(((LinkButton)sender).CommandArgument));
        TabContainer1.ActiveTabIndex = 0;
        zPop.Show();
    }

    protected void imbSearch_Click(object sender, ImageClickEventArgs e)
    {
        gvMain.PageIndex = 0;
        doGetList();
    }

    protected void imbReset_Click(object sender, ImageClickEventArgs e)
    {
        ClearSearch();
        gvMain.PageIndex = 0;
        doGetList();
    }

    protected void imbSaveUnit_Click(object sender, ImageClickEventArgs e)
    {
        if (VerifyUnitAdd())
        {
            AddUnitToTempTable();
            zPop.Show();
        }
        else
        {
            zPop.Show();
        }
    }

    #endregion

    #region Gridview Event Handler

    protected void gvMain_RowDataBound(object sender, GridViewRowEventArgs e)
    {
        if (e.Row.RowIndex > -1)
            e.Row.Cells[2].Text = ((e.Row.RowIndex + 1) + (gvMain.PageIndex * gvMain.PageSize)).ToString();
    }

    protected void gvMain_Sorting(object sender, GridViewSortEventArgs e)
    {
        MaterialToolFlow fFlow = new MaterialToolFlow();
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

    protected void gvFeedUnit_RowEditing(object sender, GridViewEditEventArgs e)
    {
        gvFeedUnit.EditIndex = e.NewEditIndex;
        ReloadGVFeedUnit();
    }

    protected void gvFeedUnit_RowCancelingEdit(object sender, GridViewCancelEditEventArgs e)
    {
        gvFeedUnit.EditIndex = -1;
        ReloadGVFeedUnit();
    }

    protected void gvFeedUnit_RowDeleting(object sender, GridViewDeleteEventArgs e)
    {
        string unitloid = gvFeedUnit.Rows[e.RowIndex].Cells[19].Text.Trim();

        if (Session["tmpTableFeedUnit"] != null)
        {
            DataTable dt = (DataTable)Session["tmpTableFeedUnit"];

            for (int i = 0; i < dt.Rows.Count; i++)
            {
                if (unitloid == dt.Rows[i]["UNITLOID"].ToString())
                {
                    dt.Rows[i].Delete();
                }
            }

            Session["tmpTableFeedUnit"] = dt;
        }

        ReloadGVFeedUnit();
    }

    protected void gvFeedUnit_RowUpdating(object sender, GridViewUpdateEventArgs e)
    {
        string unitloid = gvFeedUnit.Rows[e.RowIndex].Cells[19].Text.Trim();

        if (VerifyUnitEdit(e) == false)
        {
            zPop.Show();
            return;
        }

        DropDownList cmbTHUNIT = (DropDownList)gvFeedUnit.Rows[e.RowIndex].FindControl("cmbTHUNIT");
        TextBox txtWeight = (TextBox)gvFeedUnit.Rows[e.RowIndex].FindControl("txtWeight");
        TextBox txtCost = (TextBox)gvFeedUnit.Rows[e.RowIndex].FindControl("txtCost");
        TextBox txtPrice = (TextBox)gvFeedUnit.Rows[e.RowIndex].FindControl("txtPrice");
        TextBox txtMultiply = (TextBox)gvFeedUnit.Rows[e.RowIndex].FindControl("txtMultiply");
        CheckBox chkIsStockInEdit = (CheckBox)gvFeedUnit.Rows[e.RowIndex].FindControl("chkIsStockInEdit");
        CheckBox chkIsStockOutEdit = (CheckBox)gvFeedUnit.Rows[e.RowIndex].FindControl("chkIsStockOutEdit");
        CheckBox chkIsFormulaEdit = (CheckBox)gvFeedUnit.Rows[e.RowIndex].FindControl("chkIsFormulaEdit");
        CheckBox chkActiveEdit = (CheckBox)gvFeedUnit.Rows[e.RowIndex].FindControl("chkActiveEdit");

        if (Session["tmpTableFeedUnit"] != null)
        {
            DataTable dt = (DataTable)Session["tmpTableFeedUnit"];

            for (int i = 0; i < dt.Rows.Count; i++)
            {
                if (unitloid == dt.Rows[i]["UNITLOID"].ToString())
                {
                    dt.Rows[i]["MMLOID"] = txhID.Text.Trim();
                    dt.Rows[i]["UNITLOID"] = cmbTHUNIT.SelectedItem.Value;
                    dt.Rows[i]["THNAME"] = cmbTHUNIT.SelectedItem.Text.Trim();
                    dt.Rows[i]["WEIGHT"] = txtWeight.Text.Trim();
                    dt.Rows[i]["COST"] = txtCost.Text.Trim();
                    dt.Rows[i]["PRICE"] = txtPrice.Text.Trim();
                    dt.Rows[i]["MULTIPLY"] = txtMultiply.Text.Trim();

                    if (chkIsStockInEdit.Checked)
                        dt.Rows[i]["ISSTOCKIN"] = "Y";
                    else
                        dt.Rows[i]["ISSTOCKIN"] = "N";

                    if (chkIsStockOutEdit.Checked)
                        dt.Rows[i]["ISSTOCKOUT"] = "Y";
                    else
                        dt.Rows[i]["ISSTOCKOUT"] = "N";

                    if (chkIsFormulaEdit.Checked)
                        dt.Rows[i]["ISFORMULA"] = "Y";
                    else
                        dt.Rows[i]["ISFORMULA"] = "N";

                    if (chkActiveEdit.Checked)
                        dt.Rows[i]["ACTIVE"] = "1";
                    else
                        dt.Rows[i]["ACTIVE"] = "0";
                }
            }

            gvFeedUnit.EditIndex = -1;
            Session["tmpTableFeedUnit"] = dt;
        }

        ReloadGVFeedUnit();
    }

    protected void gvFeedUnit_RowDataBound(object sender, GridViewRowEventArgs e)
    {
        //โหลดข้อมูลหน่วยนับเข้าสู่ ComboBox
        if (e.Row.RowType == DataControlRowType.Footer)
        {
            DropDownList cmbTHUNITAdd = (DropDownList)e.Row.FindControl("cmbTHUNITAdd");
            Appz.BuildCombo(cmbTHUNITAdd, "UNIT", "THNAME", "LOID", "ACTIVE = '1'", "THNAME", "เลือก", "0", false);
            TextBox txtWeightAdd = (TextBox)e.Row.FindControl("txtWeightAdd");
            TextBox txtCostAdd = (TextBox)e.Row.FindControl("txtCostAdd");
            TextBox txtPriceAdd = (TextBox)e.Row.FindControl("txtPriceAdd");
            TextBox txtMultiplyAdd = (TextBox)e.Row.FindControl("txtMultiplyAdd");

            ControlUtil.SetDblTextBoxRealNumer(txtWeightAdd);
            ControlUtil.SetDblTextBox(txtCostAdd);
            ControlUtil.SetDblTextBox(txtPriceAdd);
            ControlUtil.SetDblTextBoxRealNumer(txtMultiplyAdd);
        }

        //disbale ปุ่มลบ ถ้า row ปัจจุบันเป็นหน่วยหลัก
        if (e.Row.Cells[20].Text.Trim() == "Y")
        {
            ImageButton imbDelete = (ImageButton)e.Row.FindControl("imbDelete");
            if (imbDelete != null)
                imbDelete.Visible = false;
        }

        if (e.Row.RowType == DataControlRowType.DataRow)
        {
            //เซ็ท CheckBox ของคอลัม รับเข้า (ISSTOCKIN)
            CheckBox chkIsStockIn = (CheckBox)e.Row.FindControl("chkIsStockIn");
            if (chkIsStockIn != null)
            {
                if (e.Row.Cells[15].Text == "Y")
                    chkIsStockIn.Checked = true;
                else
                    chkIsStockIn.Checked = false;
            }

            //เซ็ท CheckBox ของคอลัม เบิกจ่าย (ISSTOCKOUT)
            CheckBox chkIsStockOut = (CheckBox)e.Row.FindControl("chkIsStockOut");
            if (chkIsStockOut != null)
            {
                if (e.Row.Cells[16].Text == "Y")
                    chkIsStockOut.Checked = true;
                else
                    chkIsStockOut.Checked = false;
            }

            //เซ็ท CheckBox ของคอลัม สร้างสูตร (ISFORMULA)
            CheckBox chkIsFormula = (CheckBox)e.Row.FindControl("chkIsFormula");
            if (chkIsFormula != null)
            {
                if (e.Row.Cells[17].Text == "Y")
                    chkIsFormula.Checked = true;
                else
                    chkIsFormula.Checked = false;
            }

            //เซ็ท CheckBox ของคอลัม ใช้งาน (ACTIVE)
            CheckBox chkActive = (CheckBox)e.Row.FindControl("chkActive");
            if (chkActive != null)
            {
                if (e.Row.Cells[18].Text == "1")
                    chkActive.Checked = true;
                else
                    chkActive.Checked = false;
            }

            //============= กรณี กดปุ่ม Edit =======================================================
            //เซ็ทค่าเข้า ComboBox ของคอลัม หน่วยนับ 
            DropDownList cmbTHUNIT = (DropDownList)e.Row.FindControl("cmbTHUNIT");
            if (cmbTHUNIT != null)
            {
                Appz.BuildCombo(cmbTHUNIT, "UNIT", "THNAME", "LOID", "ACTIVE = '1'", "THNAME", "เลือก", "0", false);
                cmbTHUNIT.SelectedIndex = cmbTHUNIT.Items.IndexOf(cmbTHUNIT.Items.FindByValue(e.Row.Cells[19].Text.Replace("&nbsp;", "").Trim()));
                if (e.Row.Cells[20].Text.Trim() == "Y")  // เช็กว่า หน่วยที่ row ปัจจุบันเป็นหน่วยหลักหรือไม่
                    cmbTHUNIT.Enabled = false;
            }

            //เซ็ทค่าใน Textbox ของคอลัม น้ำหนักต่อหน่วย (WEIGHT) ในกรณีกดปุ่ม Edit
            TextBox txtWeight = (TextBox)e.Row.FindControl("txtWeight");
            if (txtWeight != null)
            {
                ControlUtil.SetDblTextBox(txtWeight);
                txtWeight.Text = e.Row.Cells[11].Text.Replace("&nbsp;", "").Trim();
                if (e.Row.Cells[20].Text.Trim() == "Y")  // เช็กว่า หน่วยที่ row ปัจจุบันเป็นหน่วยหลักหรือไม่
                    txtWeight.Enabled = false;
            }

            //เซ็ทค่าใน Textbox ของคอลัม ราคาทุน (COST) ในกรณีกดปุ่ม Edit
            TextBox txtCost = (TextBox)e.Row.FindControl("txtCost");
            if (txtCost != null)
            {
                ControlUtil.SetDblTextBox(txtCost);
                txtCost.Text = e.Row.Cells[12].Text.Replace("&nbsp;", "").Trim();
                if (e.Row.Cells[20].Text.Trim() == "Y")  // เช็กว่า หน่วยที่ row ปัจจุบันเป็นหน่วยหลักหรือไม่
                    txtCost.Enabled = false;
            }

            //เซ็ทค่าใน Textbox ของคอลัม ราคาขาย (PRICE) ในกรณีกดปุ่ม Edit
            TextBox txtPrice = (TextBox)e.Row.FindControl("txtPrice");
            if (txtPrice != null)
            {
                ControlUtil.SetDblTextBox(txtPrice);
                txtPrice.Text = e.Row.Cells[13].Text.Replace("&nbsp;", "").Trim();
                if (e.Row.Cells[20].Text.Trim() == "Y")  // เช็กว่า หน่วยที่ row ปัจจุบันเป็นหน่วยหลักหรือไม่
                    txtPrice.Enabled = false;
            }

            //เซ็ทค่าใน Textbox ของคอลัม ตัวคูณ (MULTIPLY) ในกรณีกดปุ่ม Edit
            TextBox txtMultiply = (TextBox)e.Row.FindControl("txtMultiply");
            if (txtMultiply != null)
            {
                ControlUtil.SetDblTextBox(txtMultiply);
                txtMultiply.Text = e.Row.Cells[14].Text.Replace("&nbsp;", "").Trim();
                if (e.Row.Cells[20].Text.Trim() == "Y")  // เช็กว่า หน่วยที่ row ปัจจุบันเป็นหน่วยหลักหรือไม่
                    txtMultiply.Enabled = false;
            }

            //เซ็ท CheckBox ของคอลัม รับเข้า (ISSTOCKIN) ในกรณีกดปุ่ม Edit
            CheckBox chkIsStockInEdit = (CheckBox)e.Row.FindControl("chkIsStockInEdit");
            if (chkIsStockInEdit != null)
            {
                if (e.Row.Cells[15].Text == "Y")
                    chkIsStockInEdit.Checked = true;
                else
                    chkIsStockInEdit.Checked = false;
            }

            //เซ็ท CheckBox ของคอลัม เบิกจ่าย (ISSTOCKOUT) ในกรณีกดปุ่ม Edit
            CheckBox chkIsStockOutEdit = (CheckBox)e.Row.FindControl("chkIsStockOutEdit");
            if (chkIsStockOutEdit != null)
            {
                if (e.Row.Cells[16].Text == "Y")
                    chkIsStockOutEdit.Checked = true;
                else
                    chkIsStockOutEdit.Checked = false;
            }

            //เซ็ท CheckBox ของคอลัมสร้างสูตร (ISFORMULA) ในกรณีกดปุ่ม Edit
            CheckBox chkIsFormulaEdit = (CheckBox)e.Row.FindControl("chkIsFormulaEdit");
            if (chkIsFormulaEdit != null)
            {
                if (e.Row.Cells[17].Text == "Y")
                    chkIsFormulaEdit.Checked = true;
                else
                    chkIsFormulaEdit.Checked = false;
            }

            //เซ็ท CheckBox ของคอลัม ใช้งาน (ACTIVE) ในกรณีกดปุ่ม Edit
            CheckBox chkActiveEdit = (CheckBox)e.Row.FindControl("chkActiveEdit");
            if (chkActiveEdit != null)
            {
                if (e.Row.Cells[18].Text == "1")
                    chkActiveEdit.Checked = true;
                else
                    chkActiveEdit.Checked = false;
            }
        }
    }

    private void CreateTempTableFeedUnit()
    {
        tmpTableFeedUnit = new DataTable();
        DataColumn dcMMLOID = new DataColumn("MMLOID");
        DataColumn dcMMNAME = new DataColumn("MMNAME");
        DataColumn dcUNITLOID = new DataColumn("UNITLOID");
        DataColumn dcTHNAME = new DataColumn("THNAME");
        DataColumn dcWEIGHT = new DataColumn("WEIGHT");
        DataColumn dcCOST = new DataColumn("COST");
        DataColumn dcPRICE = new DataColumn("PRICE");
        DataColumn dcMULTIPLY = new DataColumn("MULTIPLY");
        DataColumn dcISSTOCKIN = new DataColumn("ISSTOCKIN");
        DataColumn dcISSTOCKOUT = new DataColumn("ISSTOCKOUT");
        DataColumn dcISFORMULA = new DataColumn("ISFORMULA");
        DataColumn dcACTIVE = new DataColumn("ACTIVE");
        DataColumn dcISMAIN = new DataColumn("ISMAIN");

        tmpTableFeedUnit.Columns.Add(dcMMLOID);
        tmpTableFeedUnit.Columns.Add(dcMMNAME);
        tmpTableFeedUnit.Columns.Add(dcUNITLOID);
        tmpTableFeedUnit.Columns.Add(dcTHNAME);
        tmpTableFeedUnit.Columns.Add(dcWEIGHT);
        tmpTableFeedUnit.Columns.Add(dcCOST);
        tmpTableFeedUnit.Columns.Add(dcPRICE);
        tmpTableFeedUnit.Columns.Add(dcMULTIPLY);
        tmpTableFeedUnit.Columns.Add(dcISSTOCKIN);
        tmpTableFeedUnit.Columns.Add(dcISSTOCKOUT);
        tmpTableFeedUnit.Columns.Add(dcISFORMULA);
        tmpTableFeedUnit.Columns.Add(dcACTIVE);
        tmpTableFeedUnit.Columns.Add(dcISMAIN);
    }

    private void SetTempTableFeedUnit(DataTable dt)
    {
        if (dt.Rows.Count > 0)
        {
            for (int i = 0; i < dt.Rows.Count; i++)
            {
                DataRow dr = tmpTableFeedUnit.Rows.Add();
                dr["MMLOID"] = dt.Rows[i]["MATERIALMASTER"];
                dr["MMNAME"] = dt.Rows[i]["MATERIALNAME"];
                dr["UNITLOID"] = dt.Rows[i]["UNIT"];
                dr["THNAME"] = dt.Rows[i]["UNITNAME"];
                dr["WEIGHT"] = dt.Rows[i]["WEIGHT"];
                dr["COST"] = dt.Rows[i]["COST"];
                dr["PRICE"] = dt.Rows[i]["PRICE"];
                dr["MULTIPLY"] = dt.Rows[i]["MULTIPLY"];
                dr["ISSTOCKIN"] = dt.Rows[i]["ISSTOCKIN"];
                dr["ISSTOCKOUT"] = dt.Rows[i]["ISSTOCKOUT"];
                dr["ISFORMULA"] = dt.Rows[i]["ISFORMULA"];
                dr["ACTIVE"] = dt.Rows[i]["ACTIVE"];
                dr["ISMAIN"] = dt.Rows[i]["ISMAIN"];
            }
        }
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
    private void SetStatus(string t)
    {
        lbStatusTab.Text = t;
        lbStatusTab.ForeColor = Constant.StatusColor.Information;

    }

    private void SetErrorStatus(string t)
    {
        lbStatusTab.Text = t;
        lbStatusTab.ForeColor = Constant.StatusColor.Error;
    }

    private void ClearData()
    {
        txhID.Text = "";
        txtName.Text = "";
        txtCode.Text = "";
        cmbMaterialGroup1.SelectedValue = "0";
        cmbUnit1.SelectedValue = "0";
        txtMaxStock.Text = "";
        txtMinStock.Text = "";
        txtRemarks.Text = "";
        txtCost.Text = "";
        txtSpec.Text = "";
        cmbOrderType.SelectedValue = "";
        cmbDivision.SelectedValue = "0";
        chkIsCount.Checked = true;
        chkActive.Checked = true;
        txtSAP.Text = "";
        cmbSAP.SelectedValue = "0";
    }

    private void ClearSearch()
    {
        // Clear searh data
        txtSearchName.Text = "";
        cmbSearchGroup.SelectedIndex = 0;
    }

    private void ClearDataTabFeedDetail()
    {
        lbStatusTab.Text = "";
        txhID.Text = "";
        txtName.Text = "";
        txtCode.Text = "";
        cmbMaterialGroup1.SelectedValue = "0";
        cmbUnit1.SelectedValue = "0";
        txtMaxStock.Text = "";
        txtMinStock.Text = "";
        txtRemarks.Text = "";
        txtCost.Text = "";
        txtPrice.Text = "";
        txtSpec.Text = "";
        cmbOrderType.SelectedValue = "";
        cmbDivision.SelectedValue = "0";
        chkIsCount.Checked = true;
        chkActive.Checked = true;
        txtSAP.Text = "";
        cmbSAP.SelectedValue = "0";
    }

    private void ClearDataTabFeedUnit()
    {
        lbStatusTab.Text = "";
        txtCode_FeedUnit.Text = "";
        txtName_FeedUnit.Text = "";
        txtMaterialGroup_FeedUnit.Text = "";
        txtUnit_FeedUnit.Text = "";
        gvFeedUnit.DataSource = null;
        gvFeedUnit.EditIndex = -1;
        gvFeedUnit.DataBind();
    }

    private MaterialMasterData GetData()
    {
        MaterialMasterData msData = new MaterialMasterData();
        if (chkActive.Checked)
            msData.ACTIVE = "1";
        else
            msData.ACTIVE = "0";
        msData.SAPCODE = txtSAP.Text.Trim();
        msData.SAPWAREHOUSE = Convert.ToDouble(cmbSAP.SelectedItem.Value);
        msData.NAME = txtName.Text.Trim();
        msData.MATERIALGROUP = Convert.ToDouble(cmbMaterialGroup1.SelectedItem.Value);
        msData.UNIT = Convert.ToDouble(cmbUnit1.SelectedItem.Value);
        if (txtCost.Text.Trim() != "")
            msData.COST = Convert.ToDouble(txtCost.Text.Trim());
        if (txtPrice.Text.Trim() != "")
            msData.PRICE = Convert.ToDouble(txtPrice.Text.Trim());
        if (txtWeight.Text.Trim() != "")
            msData.WEIGHT = Convert.ToDouble(txtWeight.Text.Trim());
        msData.SPEC = txtSpec.Text.Trim();
        msData.ORDERTYPE = cmbOrderType.SelectedItem.Value;
        msData.DIVISION = Convert.ToDouble(cmbDivision.SelectedItem.Value);
        if (chkIsCount.Checked)
            msData.ISCOUNT = "Y";
        else
            msData.ISCOUNT = "N";

        if (txtMinStock.Text.Trim() != "")
            msData.MINSTOCK = Convert.ToDouble(txtMinStock.Text.Trim());
        if (txtMaxStock.Text.Trim() != "")
            msData.MAXSTOCK = Convert.ToDouble(txtMaxStock.Text.Trim());

        msData.REMARKS = txtRemarks.Text.Trim();
        msData.ARTICLECODE = txtArticle.Text.Trim();
        msData.ISMENU = "N";

        return msData;
    }

    private void SetFeedDetailData(MaterialMasterData msData)
    {
        txhID.Text = msData.LOID.ToString();
        if (msData.ACTIVE == "1")
            chkActive.Checked = true;
        txtCode.Text = msData.CODE;
        txtName.Text = msData.NAME;
        cmbDivision.SelectedIndex = cmbDivision.Items.IndexOf(cmbDivision.Items.FindByValue(msData.DIVISION.ToString()));
        cmbMaterialGroup1.SelectedIndex = cmbMaterialGroup1.Items.IndexOf(cmbMaterialGroup1.Items.FindByValue(msData.MATERIALGROUP.ToString()));
        cmbUnit1.SelectedIndex = cmbUnit1.Items.IndexOf(cmbUnit1.Items.FindByValue(msData.UNIT.ToString()));
        txtCost.Text = msData.COST.ToString();
        txtPrice.Text = msData.PRICE.ToString();
        txtSpec.Text = msData.SPEC;
        txtWeight.Text = msData.WEIGHT.ToString();
        cmbOrderType.SelectedIndex = cmbOrderType.Items.IndexOf(cmbOrderType.Items.FindByValue(msData.ORDERTYPE.ToString()));
        txtMaxStock.Text = msData.MAXSTOCK.ToString();
        txtMinStock.Text = msData.MINSTOCK.ToString();
        txtRemarks.Text = msData.REMARKS;
        if (msData.ISCOUNT == "Y")
            chkIsCount.Checked = true;
        txtSAP.Text = msData.SAPCODE;
        txtArticle.Text = msData.ARTICLECODE;
        cmbSAP.SelectedIndex = cmbSAP.Items.IndexOf(cmbSAP.Items.FindByValue(msData.SAPWAREHOUSE.ToString()));
    }

    private void SetTabFeedUnit(DataTable dt)
    {
        txtCode_FeedUnit.Text = dt.Rows[0]["MATERIALCODE"].ToString();
        txtName_FeedUnit.Text = dt.Rows[0]["MATERIALNAME"].ToString();
        txtMaterialGroup_FeedUnit.Text = dt.Rows[0]["GROUPNAME"].ToString();
        txtUnit_FeedUnit.Text = dt.Rows[0]["THNAME"].ToString();
    }

    private void SetGridViewFeedUnit(DataTable dt)
    {
        gvFeedUnit.DataSource = dt;
        gvFeedUnit.DataBind();
    }


    private void SetControl()
    {
        //ControlUtil.SetDblTextBox(txtCost);
        //ControlUtil.SetDblTextBox(txtPrice);
        //ControlUtil.SetDblTextBox(txtWeight);
        //ControlUtil.SetDblTextBox(txtMinStock);
        //ControlUtil.SetDblTextBox(txtMaxStock);
    }

    private void ReloadGVFeedUnit()
    {
        if (Session["tmpTableFeedUnit"] != null)
            tmpTableFeedUnit = (DataTable)Session["tmpTableFeedUnit"];

        SetGridViewFeedUnit(tmpTableFeedUnit);
        zPop.Show();
    }

    #endregion

    #region Working Method

    private void doGetList()
    {
        MaterialToolFlow fFlow = new MaterialToolFlow();

        // ตรวจสอบเงื่อนไขการค้นหาเพื่อแสดงปุ่ม reset การค้นหา
        imbReset.Visible = (txtSearchName.Text.Trim() != "") ;

        string orderStr = "";
        if (txhSortField.Text.Trim() != "")
            orderStr = " " + txhSortField.Text + " " + txhSortDir.Text;

        gvMain.DataSource = fFlow.GetMasterList(txtSearchName.Text, cmbSearchGroup.SelectedItem.Value, orderStr);
        gvMain.DataBind();
        pcTop.Update();
        pcBot.Update();
    }
    private void doGetFeedDetail(double loid)
    {
        //ใส่ค่าใน control ต่างๆ ใน tab ที่1 (รายละเอียด)
        MaterialToolFlow msFlow = new MaterialToolFlow();
        MaterialMasterData msData = new MaterialMasterData();
        msData = msFlow.GetFeedDetailData(loid);
        SetFeedDetailData(msData);

        //ใส่ค่าใน control ต่างๆ ใน tab ที่2 (หน่วยย่อย)
        DataTable dt = msFlow.GetMaterialMasterByLOID(loid.ToString());
        if (dt.Rows.Count > 0)
            SetTabFeedUnit(dt);

        //ใส่ค่าใน gvFeedUnit ใน tab ที่2 (หน่วยย่อย)
        DataTable dtMMUnit = msFlow.GetMaterialMasterUnit(loid.ToString());
        CreateTempTableFeedUnit();
        SetTempTableFeedUnit(dtMMUnit);
        Session["tmpTableFeedUnit"] = tmpTableFeedUnit;
        SetGridViewFeedUnit(tmpTableFeedUnit);
    }

    private bool doSaveTabFeedDetail()
    {
        // verify required field
        string error = VerifyData();
        if (error != "")
        {
            SetErrorStatus(error);
            return false;
        }

        MaterialToolFlow msFlow = new MaterialToolFlow();
        bool ret = true;

        if (!msFlow.CheckUniqName(txtName.Text.Trim(), txhID.Text.Trim()))
        {
            SetErrorStatus(string.Format(DataResources.MSGEI015, "ชื่อวัสดุ", this.txtName.Text.Trim()));
            return false;
        }
        if (!msFlow.CheckUniqSapCode(txtSAP.Text.Trim(), txhID.Text.Trim()))
        {
            SetErrorStatus(string.Format(DataResources.MSGEI015, "รหัส SAP", this.txtSAP.Text.Trim()));
            return false;
        }

        // data correct go on saving...
        if (txhID.Text.Trim() == "")
        {
            //  save new
            ret = msFlow.InsertData(GetData(), Appz.CurrentUser);
        }
        else
        {
            // save update
            MaterialMasterData msData;
            msData = GetData();
            msData.LOID = Convert.ToDouble(txhID.Text.Trim());
            ret = msFlow.UpdateData(msData, Appz.CurrentUser);
        }

        if (!ret)
        {
            SetErrorStatus(msFlow.ErrorMessage);
            return ret;
        }
        else
        {
            SetStatus("บันทึกข้อมูลเรียบร้อย");
            txhID.Text = msFlow.LOID.ToString();
            return ret;
        }
    }

    private void AddUnitToTempTable()
    {
        DropDownList cmbTHUNITAdd = (DropDownList)gvFeedUnit.FooterRow.FindControl("cmbTHUNITAdd");
        TextBox txtWeightAdd = (TextBox)gvFeedUnit.FooterRow.FindControl("txtWeightAdd");
        TextBox txtCostAdd = (TextBox)gvFeedUnit.FooterRow.FindControl("txtCostAdd");
        TextBox txtPriceAdd = (TextBox)gvFeedUnit.FooterRow.FindControl("txtPriceAdd");
        TextBox txtMultiplyAdd = (TextBox)gvFeedUnit.FooterRow.FindControl("txtMultiplyAdd");
        CheckBox chkIsStockInAdd = (CheckBox)gvFeedUnit.FooterRow.FindControl("chkIsStockInAdd");
        CheckBox chkIsStockOutAdd = (CheckBox)gvFeedUnit.FooterRow.FindControl("chkIsStockOutAdd");
        CheckBox chkIsFormulaAdd = (CheckBox)gvFeedUnit.FooterRow.FindControl("chkIsFormulaAdd");
        CheckBox chkActiveAdd = (CheckBox)gvFeedUnit.FooterRow.FindControl("chkActiveAdd");

        if (Session["tmpTableFeedUnit"] != null)
        {
            DataTable dt = (DataTable)Session["tmpTableFeedUnit"];
            DataRow dr = dt.Rows.Add();

            dr["MMLOID"] = txhID.Text.Trim();
            dr["UNITLOID"] = cmbTHUNITAdd.SelectedItem.Value;
            dr["THNAME"] = cmbTHUNITAdd.SelectedItem.Text.Trim();
            dr["WEIGHT"] = txtWeightAdd.Text.Trim();
            dr["COST"] = txtCostAdd.Text.Trim();
            dr["PRICE"] = txtPriceAdd.Text.Trim();
            dr["MULTIPLY"] = txtMultiplyAdd.Text.Trim();

            if (chkIsStockInAdd.Checked)
                dr["ISSTOCKIN"] = "Y";
            else
                dr["ISSTOCKIN"] = "N";

            if (chkIsStockOutAdd.Checked)
                dr["ISSTOCKOUT"] = "Y";
            else
                dr["ISSTOCKOUT"] = "N";

            if (chkIsFormulaAdd.Checked)
                dr["ISFORMULA"] = "Y";
            else
                dr["ISFORMULA"] = "N";

            if (chkActiveAdd.Checked)
                dr["ACTIVE"] = "1";
            else
                dr["ACTIVE"] = "0";

            dr["ISMAIN"] = "N";

            Session["tmpTableFeedUnit"] = dt;
            SetGridViewFeedUnit(dt);
        }

    }

    private bool doSaveTabFeedUnit()
    {
        bool ret = true;

        if (Session["tmpTableFeedUnit"] != null)
        {
            DataTable dt = (DataTable)Session["tmpTableFeedUnit"];
            MaterialToolFlow msFlow = new MaterialToolFlow();

            if (txtCode.Text.Trim() != "")
            {
                ret = msFlow.UpdateMaterialUnit(dt, txhID.Text.Trim(), Appz.CurrentUser);
            }

            if (!ret)
            {
                SetErrorStatus(msFlow.ErrorMessage);
                ret = false;
            }
            else
            {
                SetStatus("บันทึกข้อมูลเรียบร้อย");
                ret = true;
            }
        }

        return ret;
    }

    private void doDelete()
    {
        MaterialToolFlow msFlow = new MaterialToolFlow();
        if (msFlow.DeleteByLOID(GetChecked()))
        {
            gvMain.PageIndex = 0;
            doGetList();
            lbStatusMain.Text = "";
        }
        else
        {
            lbStatusMain.Text = msFlow.ErrorMessage;
            lbStatusMain.ForeColor = System.Drawing.Color.Red;
        }
    }

    private string VerifyData()
    {
        string ret = "";

        if (txtName.Text.Trim() == "")
            ret = string.Format(DataResources.MSGEI001,"ชื่อวัสดุ");
        else if (cmbMaterialGroup1.SelectedItem.Value == "0")
            ret = string.Format(DataResources.MSGEI002, "ประเภท");
        else if (cmbUnit1.SelectedItem.Value == "0")
            ret = string.Format(DataResources.MSGEI002, "หน่วยนับ");
        else if (cmbOrderType.SelectedItem.Value == "0")
            ret = string.Format(DataResources.MSGEI002, "วิธีการรับเข้า");
        else if (cmbDivision.SelectedItem.Value == "0")
            ret = string.Format(DataResources.MSGEI002, "หน่วยงานที่ตัดจ่าย");

        return ret;
    }

    private bool VerifyUnitAdd()
    {
        DropDownList cmbTHUNITAdd = (DropDownList)gvFeedUnit.FooterRow.FindControl("cmbTHUNITAdd");
        TextBox txtWeightAdd = (TextBox)gvFeedUnit.FooterRow.FindControl("txtWeightAdd");
        TextBox txtMultiplyAdd = (TextBox)gvFeedUnit.FooterRow.FindControl("txtMultiplyAdd");

        if (cmbTHUNITAdd.SelectedItem.Value == "0")
        {
            SetErrorStatus(string.Format(DataResources.MSGEI002, "หน่วยนับ"));
            return false;
        }
        else if (txtMultiplyAdd.Text.Trim() == "" || txtMultiplyAdd.Text.Trim() == "0")
        {
            SetErrorStatus(string.Format(DataResources.MSGEI001, "ตัวคูณ"));
            return false;
        }
        else if (Convert.ToDouble(txtMultiplyAdd.Text.Trim()) == 0)
        {
            SetErrorStatus(string.Format(DataResources.MSGEI005, "ตัวคูณ", "0"));
            return false;
        }


        for (int i = 0; i < gvFeedUnit.Rows.Count; i++)
        {
            Label lbTHNAME = (Label)gvFeedUnit.Rows[i].FindControl("lbTHNAME");

            if (lbTHNAME.Text.Trim() == cmbTHUNITAdd.SelectedItem.Text.Trim())
            {
                SetErrorStatus(string.Format(DataResources.MSGEI015, "หน่วยนับ", cmbTHUNITAdd.SelectedItem.Text.Trim()));
                return false;
            }
        }

        return true;
    }

    private bool VerifyUnitEdit(GridViewUpdateEventArgs e)
    {
        DropDownList cmbTHUNIT = (DropDownList)gvFeedUnit.Rows[e.RowIndex].FindControl("cmbTHUNIT");
        TextBox txtWeight = (TextBox)gvFeedUnit.Rows[e.RowIndex].FindControl("txtWeight");
        TextBox txtMultiply = (TextBox)gvFeedUnit.Rows[e.RowIndex].FindControl("txtMultiply");

        if (cmbTHUNIT.SelectedItem.Value == "0")
        {
            SetErrorStatus(string.Format(DataResources.MSGEI002, "หน่วยนับ"));
            return false;
        }
        else if (txtMultiply.Text.Trim() == "")
        {
            SetErrorStatus(string.Format(DataResources.MSGEI001, "ตัวคูณ"));
            return false;
        }
        else if (Convert.ToDouble(txtMultiply.Text.Trim()) == 0)
        {
            SetErrorStatus(string.Format(DataResources.MSGEI005, "ตัวคูณ", "0"));
            return false;
        }

        for (int i = 0; i < gvFeedUnit.Rows.Count; i++)
        {
            if (i != e.RowIndex)
            {
                Label lbTHNAME = (Label)gvFeedUnit.Rows[i].FindControl("lbTHNAME");

                if (lbTHNAME.Text.Trim() == cmbTHUNIT.SelectedItem.Text.Trim())
                {
                    SetErrorStatus(string.Format(DataResources.MSGEI015, "หน่วยนับ", cmbTHUNIT.SelectedItem.Text.Trim()));
                    return false;
                }
            }
        }

        return true;

    }

    #endregion

    protected void TabContainer1_ActiveTabChanged(object sender, EventArgs e)
    {
        if (SavePreviousTab(txtCurrTabIndex.Text.Trim()) == true)
        {
            doGetFeedDetail(Convert.ToDouble(txhID.Text.Trim()));
            txtCurrTabIndex.Text = TabContainer1.ActiveTabIndex.ToString();
            lbStatusTab.Text = "";
        }
        else
        {
            TabContainer1.ActiveTabIndex = int.Parse(txtCurrTabIndex.Text);
        }

        zPop.Show();
    }

    private bool SavePreviousTab(string currTabIndex)
    {
        if (currTabIndex == "0")
        {
            if (doSaveTabFeedDetail() == true)
            {
                return true;
            }
            else
            {
                return false;
            }
        }
        else if (currTabIndex == "1")
        {
            if (doSaveTabFeedUnit() == true)
            {
                return true;
            }
            else
            {
                return false;
            }
        }
        else
            return false;
    }
}

