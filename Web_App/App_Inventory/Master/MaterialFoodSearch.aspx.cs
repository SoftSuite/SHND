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
/// MaterialFoodSearch Page Class
/// Version 1.0
/// =========================================================================
/// Create by: Pom
/// Create Date: 5 Jan 2009
/// -------------------------------------------------------------------------
/// Modify By: Teang
/// Modify From: 
///    - เพิ่มคอลัมน์ ลำดับ ใน gridview
/// Modify Date: 28 May 2009
/// -------------------------------------------------------------------------
/// Remark: -
/// Description:
///    หน้ากาารทำงานข้อมูล Material Food Search
/// Changes:
///    1.0 - สร้าง
/// -------------------------------------------------------------------------
/// =========================================================================
/// </summary>
/// 

public partial class App_Inventory_Master_MaterialFoodSearch : System.Web.UI.Page
{
    private DataTable tmpTableFoodUnit = null;
    private DataTable tmpTableFoodNutrient = null;
    private bool tabFlag = false;

    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            doGetList();
            TabContainer1.ActiveTabIndex = 0;
            CheckHead();
        }
    }

    protected override void OnInit(EventArgs e)
    {
        base.OnInit(e);

        // set Combo source
        Appz.BuildCombo(cmbMaterialClass, "MATERIALCLASS", "NAME", "LOID", "MASTERTYPE = 'FO' AND ACTIVE = '1'", "NAME", "ทั้งหมด", "0", false);
        Appz.BuildCombo(cmbMaterialClass1, "MATERIALCLASS", "NAME", "LOID", "MASTERTYPE = 'FO' AND ACTIVE = '1'", "NAME", "เลือก", "0", false);
        Appz.BuildCombo(cmbUnit1, "UNIT", "THNAME", "LOID", "ACTIVE = '1'", "THNAME", "เลือก", "0", false);
        Appz.BuildCombo(cmbOrderType, "V_ORDERTYPE", "ORDERTYPE", "ABB", "", "ORDERTYPE", "เลือก", "0", false);
        Appz.BuildCombo(cmbDivision, "DIVISION", "NAME", "LOID", "ACTIVE = '1' AND ISSTOCKOUT = 'Y'", "NAME", "เลือก", "0", false);
        SetComboMaterialGroup();
        SetComboMaterialGroup1();
        SetControl();
        SetScript();
        pcTop.SetMainGridView(gvMain);
        pcBot.SetMainGridView(gvMain);
        this.tbExcel.ClientClick = @"window.open('" + Constant.HomeFolder + "App_Inventory/Master/MaterialFoodExcel.aspx?type=FOOD&materialclass=' + document.getElementById('" + this.cmbMaterialClass.ClientID + @"').value + '&materialgroup=' + " +
            "document.getElementById('" + this.cmbMaterialGroup.ClientID + @"').value + '&materialname=' + escape(trim(document.getElementById('" + this.txtSearchName.ClientID + "').value)), 'excelpop', 'resizable=yes,scrollbars=yes,width=1015,height=700,status=yes'); return false;";
        
        this.tbPrint.ClientClick = Appz.OpenReportScript(Constant.Reports.MaterialFoodReport, "paramfield1=material&paramvalue1=' + document.getElementById('" + this.txtSearchName.ClientID + "').value + " +
            "'&paramfield2=group&paramvalue2=' + document.getElementById('" + this.cmbMaterialGroup.ClientID + "').value + " +
            "'&paramfield3=class&paramvalue3=' + document.getElementById('" + this.cmbMaterialClass.ClientID + "').value + '", true);
    }

    private void SetScript()
    {
        string scripthead = "if(document.getElementById('" + chkAll.ClientID + @"').checked)
                         {document.getElementById('" + chkM1.ClientID + @"').checked = true;
                          document.getElementById('" + chkM2.ClientID + @"').checked = true;
                          document.getElementById('" + chkM3.ClientID + @"').checked = true;
                          document.getElementById('" + chkM4.ClientID + @"').checked = true;
                          document.getElementById('" + chkM5.ClientID + @"').checked = true;
                          document.getElementById('" + chkM6.ClientID + @"').checked = true;
                          document.getElementById('" + chkM7.ClientID + @"').checked = true;
                          document.getElementById('" + chkM8.ClientID + @"').checked = true;
                          document.getElementById('" + chkM9.ClientID + @"').checked = true;
                          document.getElementById('" + chkM10.ClientID + @"').checked = true;
                          document.getElementById('" + chkM11.ClientID + @"').checked = true;
                          document.getElementById('" + chkM12.ClientID + @"').checked = true;
                          }
                         if(document.getElementById('" + chkAll.ClientID + @"').checked == false)
                         {document.getElementById('" + chkM1.ClientID + @"').checked = false;
                          document.getElementById('" + chkM2.ClientID + @"').checked = false;
                          document.getElementById('" + chkM3.ClientID + @"').checked = false;
                          document.getElementById('" + chkM4.ClientID + @"').checked = false;
                          document.getElementById('" + chkM5.ClientID + @"').checked = false;
                          document.getElementById('" + chkM6.ClientID + @"').checked = false;
                          document.getElementById('" + chkM7.ClientID + @"').checked = false;
                          document.getElementById('" + chkM8.ClientID + @"').checked = false;
                          document.getElementById('" + chkM9.ClientID + @"').checked = false;
                          document.getElementById('" + chkM10.ClientID + @"').checked = false;
                          document.getElementById('" + chkM11.ClientID + @"').checked = false;
                          document.getElementById('" + chkM12.ClientID + @"').checked = false;
                          }";

        string scriptitem = "if(document.getElementById('" + chkM1.ClientID + @"').checked
                                && document.getElementById('" + chkM2.ClientID + @"').checked
                                && document.getElementById('" + chkM3.ClientID + @"').checked
                                && document.getElementById('" + chkM4.ClientID + @"').checked
                                && document.getElementById('" + chkM5.ClientID + @"').checked
                                && document.getElementById('" + chkM6.ClientID + @"').checked
                                && document.getElementById('" + chkM7.ClientID + @"').checked
                                && document.getElementById('" + chkM8.ClientID + @"').checked
                                && document.getElementById('" + chkM9.ClientID + @"').checked
                                && document.getElementById('" + chkM10.ClientID + @"').checked
                                && document.getElementById('" + chkM11.ClientID + @"').checked
                                && document.getElementById('" + chkM12.ClientID + @"').checked)
                             {
                                document.getElementById('" + chkAll.ClientID + @"').checked = true;
                             }
                             else
                             {
                                document.getElementById('" + chkAll.ClientID + @"').checked = false;
                             }";

        chkAll.Attributes.Add("onclick", scripthead);
        chkM1.Attributes.Add("onclick", scriptitem);
        chkM2.Attributes.Add("onclick", scriptitem);
        chkM3.Attributes.Add("onclick", scriptitem);
        chkM4.Attributes.Add("onclick", scriptitem);
        chkM5.Attributes.Add("onclick", scriptitem);
        chkM6.Attributes.Add("onclick", scriptitem);
        chkM7.Attributes.Add("onclick", scriptitem);
        chkM8.Attributes.Add("onclick", scriptitem);
        chkM9.Attributes.Add("onclick", scriptitem);
        chkM10.Attributes.Add("onclick", scriptitem);
        chkM11.Attributes.Add("onclick", scriptitem);
        chkM12.Attributes.Add("onclick", scriptitem);
    }

    #region Button Click Event Handler
    protected void tbSaveClick(object sender, EventArgs e)
    {
        if (TabContainer1.ActiveTabIndex == 0)
        {
            if (doSaveTabFoodDetail() == true)
            {
                zPop.Show();
                doGetFoodDetail(Convert.ToDouble(txtLOID.Text.Trim()));
            }
            else
                zPop.Show();
        }
        else if (TabContainer1.ActiveTabIndex == 1)
        {
            if (txtLOID.Text.Trim() != "")
            {
                if (doSaveTabFoodUnit() == true)
                {
                    zPop.Show();
                    doGetFoodDetail(Convert.ToDouble(txtLOID.Text.Trim()));
                }
                else
                    zPop.Show();
            }
            else
                zPop.Show();

        }
        else if (TabContainer1.ActiveTabIndex == 2)
        {
            if (txtLOID.Text.Trim() != "")
            {
                if (doSaveTabFoodNutrient() == true)
                {
                    zPop.Show();
                    doGetFoodDetail(Convert.ToDouble(txtLOID.Text.Trim()));
                }
                else
                    zPop.Show();
            }
            else
                zPop.Show();
        }
        else if (TabContainer1.ActiveTabIndex == 3)
        {
            if (txtLOID.Text.Trim() != "")
            {
                if (doSaveTabFoodSeason() == true)
                {
                    zPop.Show();
                    doGetFoodDetail(Convert.ToDouble(txtLOID.Text.Trim()));
                }
                else
                    zPop.Show();
            }
            else
                zPop.Show();
        }
    }
    protected void tbSave2Click(object sender, EventArgs e)
    {
        if (TabContainer1.ActiveTabIndex == 0)
        {
            if (doSaveTabFoodDetail())
            {
                ClearDataAllTabs();
            }
            else
                zPop.Show();
        }
        else if (TabContainer1.ActiveTabIndex == 1)
        {
            if (txtLOID.Text.Trim() != "")
            {
                if (doSaveTabFoodUnit())
                {
                    ClearDataAllTabs();
                }
                else
                    zPop.Show();
            }
            else
                zPop.Show();

        }
        else if (TabContainer1.ActiveTabIndex == 2)
        {
            if (txtLOID.Text.Trim() != "")
            {
                if (doSaveTabFoodNutrient())
                {
                    ClearDataAllTabs();
                }
                else
                    zPop.Show();
            }
            else
                zPop.Show();

        }
        else if (TabContainer1.ActiveTabIndex == 3)
        {
            if (txtLOID.Text.Trim() != "")
            {
                if (doSaveTabFoodSeason())
                {
                    ClearDataAllTabs();
                }
                else
                    zPop.Show();
            }
            else
                zPop.Show();
        }
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
            if (txtLOID.Text.Trim() == "")
                ClearDataTabFoodDetail();
            else
                doGetFoodDetail(Convert.ToDouble(txtLOID.Text.Trim()));

            zPop.Show();
        }
        else if (TabContainer1.ActiveTabIndex == 1)
        {
            if (txtLOID.Text.Trim() == "")
                ClearDataTabFoodUnit();
            else
                doGetFoodDetail(Convert.ToDouble(txtLOID.Text.Trim()));

            zPop.Show();
        }
        else if (TabContainer1.ActiveTabIndex == 2)
        {
            if (txtLOID.Text.Trim() == "")
                ClearDataTabFoodNutrient();
            else
                doGetFoodDetail(Convert.ToDouble(txtLOID.Text.Trim()));

            zPop.Show();
        }
        else if (TabContainer1.ActiveTabIndex == 3)
        {
            if (txtLOID.Text.Trim() == "")
            {
                CheckAllASeason();
                CheckHead();
            }
            else
                doGetFoodDetail(Convert.ToDouble(txtLOID.Text.Trim()));

            zPop.Show();
        }

    }
    protected void tbBackClick(object sender, EventArgs e)
    {
        ClearDataTabFoodDetail();
        ClearDataTabFoodUnit();
        ClearDataTabFoodNutrient();
        CheckAllASeason();
        CheckHead();
        Session["tmpTableFoodUnit"] = null;
        Session["tmpTableFoodNutrient"] = null;
        TabContainer1.ActiveTabIndex = 0;
        txtPrevTabIndex.Text = "0";
        doGetList();
    }
    protected void lnkCode_Click(object sender, EventArgs e)
    {
        doGetFoodDetail(Convert.ToDouble(((LinkButton)sender).CommandArgument));
        TabContainer1.ActiveTabIndex = 0;
        txtPrevTabIndex.Text = "0";
        zPop.Show();
    }

    protected void imbSearch_Click(object sender, ImageClickEventArgs e)
    {
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

    protected void imbgvFoodNutrientAdd_Click(object sender, ImageClickEventArgs e)
    {
        if (VerifyNutrientAdd())
        {
            AddNutrientToTempTable();
            zPop.Show();
        }
        else
        {
            zPop.Show();
        }
    }

    protected void imbReset_Click(object sender, ImageClickEventArgs e)
    {
        this.cmbMaterialClass.SelectedIndex = 0;
        this.cmbMaterialGroup.SelectedIndex = 0;
        this.txtSearchName.Text = "";
        gvMain.PageIndex = 0;
        doGetList();
    }

    protected void tbPrintClick(object sender, EventArgs e)
    {

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

    protected void gvFoodUnit_RowEditing(object sender, GridViewEditEventArgs e)
    {
        gvFoodUnit.EditIndex = e.NewEditIndex;
        ReloadGVFoodUnit();
    }

    protected void gvFoodUnit_RowCancelingEdit(object sender, GridViewCancelEditEventArgs e)
    {
        gvFoodUnit.EditIndex = -1;
        ReloadGVFoodUnit();
    }

    protected void gvFoodUnit_RowDeleting(object sender, GridViewDeleteEventArgs e)
    {
        string unitloid = gvFoodUnit.Rows[e.RowIndex].Cells[19].Text.Trim();

        if (Session["tmpTableFoodUnit"] != null)
        {
            DataTable dt = (DataTable)Session["tmpTableFoodUnit"];

            for (int i = 0; i < dt.Rows.Count; i++)
            {
                if (unitloid == dt.Rows[i]["UNITLOID"].ToString())
                {
                    dt.Rows[i].Delete();
                }
            }

            Session["tmpTableFoodUnit"] = dt;
        }

        ReloadGVFoodUnit();
    }

    protected void gvFoodUnit_RowUpdating(object sender, GridViewUpdateEventArgs e)
    {
        string unitloid = gvFoodUnit.Rows[e.RowIndex].Cells[19].Text.Trim();

        if (VerifyUnitEdit(e) == false)
        {
            zPop.Show();
            return;
        }

        DropDownList cmbTHUNIT = (DropDownList)gvFoodUnit.Rows[e.RowIndex].FindControl("cmbTHUNIT");
        TextBox txtWeight = (TextBox)gvFoodUnit.Rows[e.RowIndex].FindControl("txtWeight");
        TextBox txtCost = (TextBox)gvFoodUnit.Rows[e.RowIndex].FindControl("txtCost");
        TextBox txtPrice = (TextBox)gvFoodUnit.Rows[e.RowIndex].FindControl("txtPrice");
        TextBox txtMultiply = (TextBox)gvFoodUnit.Rows[e.RowIndex].FindControl("txtMultiply");
        CheckBox chkIsStockInEdit = (CheckBox)gvFoodUnit.Rows[e.RowIndex].FindControl("chkIsStockInEdit");
        CheckBox chkIsStockOutEdit = (CheckBox)gvFoodUnit.Rows[e.RowIndex].FindControl("chkIsStockOutEdit");
        CheckBox chkIsFormulaEdit = (CheckBox)gvFoodUnit.Rows[e.RowIndex].FindControl("chkIsFormulaEdit");
        CheckBox chkActiveEdit = (CheckBox)gvFoodUnit.Rows[e.RowIndex].FindControl("chkActiveEdit");

        if (Session["tmpTableFoodUnit"] != null)
        {
            DataTable dt = (DataTable)Session["tmpTableFoodUnit"];

            for (int i = 0; i < dt.Rows.Count; i++)
            {
                if (unitloid == dt.Rows[i]["UNITLOID"].ToString())
                {
                    dt.Rows[i]["MMLOID"] = txtLOID.Text.Trim();
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

            gvFoodUnit.EditIndex = -1;
            Session["tmpTableFoodUnit"] = dt;
        }

        ReloadGVFoodUnit();
    }

    protected void gvFoodUnit_RowDataBound(object sender, GridViewRowEventArgs e)
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
                ControlUtil.SetDblTextBoxRealNumer(txtWeight);
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
                ControlUtil.SetDblTextBoxRealNumer(txtMultiply);
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

    protected void gvFoodNutrient_Sorting(object sender, GridViewSortEventArgs e)
    {
        if (e.SortExpression == "DEFAULT")
        {
            txhSortDirTabNutrient.Text = "";
            txhSortFieldTabNutrient.Text = "";
        }
        else
        {
            if (txhSortFieldTabNutrient.Text == e.SortExpression)
                txhSortDirTabNutrient.Text = (txhSortDirTabNutrient.Text.Trim() == "" ? "DESC" : "");
            else
                txhSortFieldTabNutrient.Text = e.SortExpression;
        }
        doGetFoodNutrientList();
    }
    private string GetgvFoodNutrient()
    {
        string ntID = "0";
        if (Session["tmpTableFoodNutrient"] != null)
        {
            DataTable dt = (DataTable)Session["tmpTableFoodNutrient"];
            for (int i = 0; i < dt.Rows.Count; ++i)
            {
                ntID +=  dt.Rows[i]["NUTRIENTLOID"].ToString();
                if (i+1<dt.Rows.Count)
                     ntID += ", ";
            }
        }
        return ntID;
    }

    protected void gvFoodNutrient_RowDataBound(object sender, GridViewRowEventArgs e)
    {
        //โหลดข้อมูลหน่วยนับเข้าสู่ Control ใน Footer
        if (e.Row.RowType == DataControlRowType.Footer)
        {
            DropDownList cmbNUTRIENTNAMEAdd = (DropDownList)e.Row.FindControl("cmbNUTRIENTNAMEAdd");
            Appz.BuildCombo(cmbNUTRIENTNAMEAdd, "NUTRIENT", "NAME", "LOID", "ACTIVE = '1' AND LOID NOT IN (" + GetgvFoodNutrient() + ")", "NAME", "เลือก", "0", false);
            TextBox txtQTYAdd = (TextBox)e.Row.FindControl("txtQTYAdd");

            ControlUtil.SetDblTextBoxRealNumer(txtQTYAdd);
        }

        if (e.Row.RowType == DataControlRowType.DataRow)
        {
            // เช็กถ้ายังไม่มีข้อมูลใน gv ให้ซ่อน row ที่สร้างขึ้นมาหลอกๆ
            if (e.Row.Cells[0].Text.Trim() == "0")
            {
                e.Row.Visible = false;
            }

            //============= กรณี กดปุ่ม Edit =======================================================
            //เซ็ทค่าเข้า ComboBox ของคอลัม สารอาหาร
            DropDownList cmbNUTRIENTNAMEEdit = (DropDownList)e.Row.FindControl("cmbNUTRIENTNAMEEdit");
            if (cmbNUTRIENTNAMEEdit != null)
            {
                Appz.BuildCombo(cmbNUTRIENTNAMEEdit, "NUTRIENT", "NAME", "LOID", "ACTIVE = '1'", "NAME", "เลือก", "0", false);
                cmbNUTRIENTNAMEEdit.SelectedIndex = cmbNUTRIENTNAMEEdit.Items.IndexOf(cmbNUTRIENTNAMEEdit.Items.FindByValue(e.Row.Cells[6].Text.Replace("&nbsp;", "").Trim()));
            }

            //เซ็ทค่าใน Textbox ของคอลัม ปริมาณ (QTY) ในกรณีกดปุ่ม Edit
            TextBox txtQTYEdit = (TextBox)e.Row.FindControl("txtQTYEdit");
            if (txtQTYEdit != null)
            {
                ControlUtil.SetDblTextBoxRealNumer(txtQTYEdit);
                txtQTYEdit.Text = e.Row.Cells[7].Text.Replace("&nbsp;", "").Trim();
            }

        }
    }

    protected void gvFoodNutrient_RowDeleting(object sender, GridViewDeleteEventArgs e)
    {
        string nutrientloid = gvFoodNutrient.Rows[e.RowIndex].Cells[0].Text.Trim();

        if (Session["tmpTableFoodNutrient"] != null)
        {
            DataTable dt = (DataTable)Session["tmpTableFoodNutrient"];

            for (int i = 0; i < dt.Rows.Count; i++)
            {
                if (nutrientloid == dt.Rows[i]["NUTRIENTLOID"].ToString())
                {
                    dt.Rows[i].Delete();
                }
            }

            Session["tmpTableFoodNutrient"] = dt;
        }

        ReloadGVFoodNutrient();
    }

    protected void gvFoodNutrient_RowEditing(object sender, GridViewEditEventArgs e)
    {
        gvFoodNutrient.EditIndex = e.NewEditIndex;
        ReloadGVFoodNutrient();
    }

    protected void gvFoodNutrient_RowCancelingEdit(object sender, GridViewCancelEditEventArgs e)
    {
        gvFoodNutrient.EditIndex = -1;
        ReloadGVFoodNutrient();
    }

    protected void gvFoodNutrient_RowUpdating(object sender, GridViewUpdateEventArgs e)
    {
        string nutrientloid = gvFoodNutrient.Rows[e.RowIndex].Cells[6].Text.Trim();

        if (VerifyNutrientEdit(e) == false)
        {
            zPop.Show();
            return;
        }

        DropDownList cmbNUTRIENTNAMEEdit = (DropDownList)gvFoodNutrient.Rows[e.RowIndex].FindControl("cmbNUTRIENTNAMEEdit");
        TextBox txtQTYEdit = (TextBox)gvFoodNutrient.Rows[e.RowIndex].FindControl("txtQTYEdit");

        if (Session["tmpTableFoodNutrient"] != null)
        {
            DataTable dt = (DataTable)Session["tmpTableFoodNutrient"];

            for (int i = 0; i < dt.Rows.Count; i++)
            {
                if (nutrientloid == dt.Rows[i]["NUTRIENTLOID"].ToString())
                {
                    dt.Rows[i]["MMLOID"] = txtLOID.Text.Trim();
                    dt.Rows[i]["NUTRIENTLOID"] = cmbNUTRIENTNAMEEdit.SelectedItem.Value;
                    dt.Rows[i]["NUTRIENTNAME"] = cmbNUTRIENTNAMEEdit.SelectedItem.Text.Trim();
                    dt.Rows[i]["QTY"] = txtQTYEdit.Text.Trim();
                }
            }

            gvFoodNutrient.EditIndex = -1;
            Session["tmpTableFoodNutrient"] = dt;
        }

        ReloadGVFoodNutrient();
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

    private void SetComboMaterialGroup()
    {
        string whr = "ACTIVE = '1' AND MATERIALCLASS = " + cmbMaterialClass.SelectedItem.Value;
        Appz.BuildCombo(cmbMaterialGroup, "MATERIALGROUP", "NAME", "LOID", whr, "NAME", "ทั้งหมด", "0", false);
    }

    private void SetComboMaterialGroup1()
    {
        string whr = "ACTIVE = '1' AND MATERIALCLASS = " + cmbMaterialClass1.SelectedItem.Value;
        Appz.BuildCombo(cmbMaterialGroup1, "MATERIALGROUP", "NAME", "LOID", whr, "NAME", "เลือก", "0", false);
    }

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

    private void CreateTempTableFoodUnit()
    {
        tmpTableFoodUnit = new DataTable();
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

        tmpTableFoodUnit.Columns.Add(dcMMLOID);
        tmpTableFoodUnit.Columns.Add(dcMMNAME);
        tmpTableFoodUnit.Columns.Add(dcUNITLOID);
        tmpTableFoodUnit.Columns.Add(dcTHNAME);
        tmpTableFoodUnit.Columns.Add(dcWEIGHT);
        tmpTableFoodUnit.Columns.Add(dcCOST);
        tmpTableFoodUnit.Columns.Add(dcPRICE);
        tmpTableFoodUnit.Columns.Add(dcMULTIPLY);
        tmpTableFoodUnit.Columns.Add(dcISSTOCKIN);
        tmpTableFoodUnit.Columns.Add(dcISSTOCKOUT);
        tmpTableFoodUnit.Columns.Add(dcISFORMULA);
        tmpTableFoodUnit.Columns.Add(dcACTIVE);
        tmpTableFoodUnit.Columns.Add(dcISMAIN);
    }

    private void SetTempTableFoodUnit(DataTable dt)
    {
        if (dt.Rows.Count > 0)
        {
            for (int i = 0; i < dt.Rows.Count; i++)
            {
                DataRow dr = tmpTableFoodUnit.Rows.Add();
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

    private void CreateTempTableFoodNutrient()
    {
        tmpTableFoodNutrient = new DataTable();
        DataColumn dcMMLOID = new DataColumn("MMLOID");
        DataColumn dcMMNAME = new DataColumn("MMNAME");
        DataColumn dcNUTRIENTLOID = new DataColumn("NUTRIENTLOID");
        DataColumn dcNUTRIENTNAME = new DataColumn("NUTRIENTNAME");
        DataColumn dcQTY = new DataColumn("QTY");
        DataColumn dcUNITLOID = new DataColumn("UNITLOID");
        DataColumn dcUNITNAME = new DataColumn("UNITNAME");

        tmpTableFoodNutrient.Columns.Add(dcMMLOID);
        tmpTableFoodNutrient.Columns.Add(dcMMNAME);
        tmpTableFoodNutrient.Columns.Add(dcNUTRIENTLOID);
        tmpTableFoodNutrient.Columns.Add(dcNUTRIENTNAME);
        tmpTableFoodNutrient.Columns.Add(dcQTY);
        tmpTableFoodNutrient.Columns.Add(dcUNITLOID);
        tmpTableFoodNutrient.Columns.Add(dcUNITNAME);
    }

    private void SetTempTableFoodNutrient(DataTable dt)
    {
        if (dt.Rows.Count > 0)
        {
            for (int i = 0; i < dt.Rows.Count; i++)
            {
                DataRow dr = tmpTableFoodNutrient.Rows.Add();
                dr["MMLOID"] = dt.Rows[i]["MMLOID"];
                dr["MMNAME"] = dt.Rows[i]["MMNAME"];
                dr["NUTRIENTLOID"] = dt.Rows[i]["NUTRIENTLOID"];
                dr["NUTRIENTNAME"] = dt.Rows[i]["NUTRIENTNAME"];
                dr["QTY"] = dt.Rows[i]["QTY"];
                dr["UNITLOID"] = dt.Rows[i]["UNITLOID"];
                dr["UNITNAME"] = dt.Rows[i]["UNITNAME"];
            }
        }
    }

    private bool VerifyUnitAdd()
    {
        DropDownList cmbTHUNITAdd = (DropDownList)gvFoodUnit.FooterRow.FindControl("cmbTHUNITAdd");
        TextBox txtWeightAdd = (TextBox)gvFoodUnit.FooterRow.FindControl("txtWeightAdd");
        TextBox txtMultiplyAdd = (TextBox)gvFoodUnit.FooterRow.FindControl("txtMultiplyAdd");

        if (cmbTHUNITAdd.SelectedItem.Value == "0")
        {
            SetErrorStatus(string.Format(DataResources.MSGEI002, "หน่วยนับ"), 1);
            return false;
        }
        else if (txtWeightAdd.Text.Trim() == "")
        {
            SetErrorStatus(string.Format(DataResources.MSGEI001, "น้ำหนักต่อหน่วย(g)"), 1);
            return false;
        }
        else if (Convert.ToDouble(txtWeightAdd.Text.Trim()) == 0)
        {
            SetErrorStatus(string.Format(DataResources.MSGEI005, "น้ำหนักต่อหน่วย(g)", "0"), 1);
            return false;
        }
        else if (txtMultiplyAdd.Text.Trim() == "" || txtMultiplyAdd.Text.Trim() == "0")
        {
            SetErrorStatus(string.Format(DataResources.MSGEI001, "ตัวคูณ"), 1);
            return false;
        }
        else if (Convert.ToDouble(txtMultiplyAdd.Text.Trim()) == 0)
        {
            SetErrorStatus(string.Format(DataResources.MSGEI005, "ตัวคูณ", "0"), 1);
            return false;
        }


        for (int i = 0; i < gvFoodUnit.Rows.Count; i++)
        {
            Label lbTHNAME = (Label)gvFoodUnit.Rows[i].FindControl("lbTHNAME");

            if (lbTHNAME.Text.Trim() == cmbTHUNITAdd.SelectedItem.Text.Trim())
            {
                SetErrorStatus(string.Format(DataResources.MSGEI015, "หน่วยนับ", cmbTHUNITAdd.SelectedItem.Text.Trim()), 1);
                return false;
            }
        }

        return true;
    }

    private bool VerifyUnitEdit(GridViewUpdateEventArgs e)
    {
        DropDownList cmbTHUNIT = (DropDownList)gvFoodUnit.Rows[e.RowIndex].FindControl("cmbTHUNIT");
        TextBox txtWeight = (TextBox)gvFoodUnit.Rows[e.RowIndex].FindControl("txtWeight");
        TextBox txtMultiply = (TextBox)gvFoodUnit.Rows[e.RowIndex].FindControl("txtMultiply");

        // เช็กข้อมูลก่อนการ update เฉพาะ row ที่ไม่ได้เป็นหน่วยหลัก
        if (gvFoodUnit.Rows[e.RowIndex].Cells[20].Text.Trim() == "N")
        {
            if (cmbTHUNIT.SelectedItem.Value == "0")
            {
                SetErrorStatus(string.Format(DataResources.MSGEI002, "หน่วยนับ"), 1);
                return false;
            }
            else if (txtWeight.Text.Trim() == "")
            {
                SetErrorStatus(string.Format(DataResources.MSGEI001, "น้ำหนักต่อหน่วย(g)"), 1);
                return false;
            }
            else if (Convert.ToDouble(txtWeight.Text.Trim()) == 0)
            {
                SetErrorStatus(string.Format(DataResources.MSGEI005, "น้ำหนักต่อหน่วย(g)", "0"), 1);
                return false;
            }
            else if (txtMultiply.Text.Trim() == "")
            {
                SetErrorStatus(string.Format(DataResources.MSGEI001, "ตัวคูณ"), 1);
                return false;
            }
            else if (Convert.ToDouble(txtMultiply.Text.Trim()) == 0)
            {
                SetErrorStatus(string.Format(DataResources.MSGEI005, "ตัวคูณ", "0"), 1);
                return false;
            }

            for (int i = 0; i < gvFoodUnit.Rows.Count; i++)
            {
                if (i != e.RowIndex)
                {
                    Label lbTHNAME = (Label)gvFoodUnit.Rows[i].FindControl("lbTHNAME");

                    if (lbTHNAME.Text.Trim() == cmbTHUNIT.SelectedItem.Text.Trim())
                    {
                        SetErrorStatus(string.Format(DataResources.MSGEI015, "หน่วยนับ", cmbTHUNIT.SelectedItem.Text.Trim()), 1);
                        return false;
                    }
                }
            }
        }

        return true;

    }

    private bool VerifyNutrientAdd()
    {
        DropDownList cmbNUTRIENTNAMEAdd = (DropDownList)gvFoodNutrient.FooterRow.FindControl("cmbNUTRIENTNAMEAdd");
        TextBox txtQTYAdd = (TextBox)gvFoodNutrient.FooterRow.FindControl("txtQTYAdd");

        if (cmbNUTRIENTNAMEAdd.SelectedItem.Value == "0")
        {
            SetErrorStatus(string.Format(DataResources.MSGEI002, "สารอาหาร"), 2);
            return false;
        }
        else if (txtQTYAdd.Text.Trim() == "")
        {
            SetErrorStatus(string.Format(DataResources.MSGEI001, "ปริมาณ"), 2);
            return false;
        }
        else if (Convert.ToDouble(txtQTYAdd.Text.Trim()) < 0)
        {
            SetErrorStatus(string.Format(DataResources.MSGEI005, "ปริมาณ", "0"), 2);
            return false;
        }

        for (int i = 0; i < gvFoodNutrient.Rows.Count; i++)
        {
            Label lblNUTRIENTNAME = (Label)gvFoodNutrient.Rows[i].FindControl("lblNUTRIENTNAME");

            if (lblNUTRIENTNAME.Text.Trim() == cmbNUTRIENTNAMEAdd.SelectedItem.Text.Trim())
            {
                SetErrorStatus(string.Format(DataResources.MSGEI015, "สารอาหาร", cmbNUTRIENTNAMEAdd.SelectedItem.Text.Trim()), 2);
                return false;
            }
        }

        return true;
    }

    private bool VerifyNutrientEdit(GridViewUpdateEventArgs e)
    {
        DropDownList cmbNUTRIENTNAMEEdit = (DropDownList)gvFoodNutrient.Rows[e.RowIndex].FindControl("cmbNUTRIENTNAMEEdit");
        TextBox txtQTYEdit = (TextBox)gvFoodNutrient.Rows[e.RowIndex].FindControl("txtQTYEdit");

        if (cmbNUTRIENTNAMEEdit.SelectedItem.Value == "0")
        {
            SetErrorStatus(string.Format(DataResources.MSGEI002, "สารอาหาร"), 2);
            return false;
        }
        else if (txtQTYEdit.Text.Trim() == "")
        {
            SetErrorStatus(string.Format(DataResources.MSGEI001, "ปริมาณ"), 2);
            return false;
        }
        else if (Convert.ToDouble(txtQTYEdit.Text.Trim()) < 0)
        {
            SetErrorStatus(string.Format(DataResources.MSGEI005, "ปริมาณ", "0"), 2);
            return false;
        }

        for (int i = 0; i < gvFoodNutrient.Rows.Count; i++)
        {
            if (i != e.RowIndex)
            {
                Label lblNUTRIENTNAME = (Label)gvFoodNutrient.Rows[i].FindControl("lblNUTRIENTNAME");

                if (lblNUTRIENTNAME.Text.Trim() == cmbNUTRIENTNAMEEdit.SelectedItem.Text.Trim())
                {
                    SetErrorStatus(string.Format(DataResources.MSGEI015, "สารอาหาร", cmbNUTRIENTNAMEEdit.SelectedItem.Text.Trim()), 2);
                    return false;
                }
            }
        }

        return true;
    }


    #endregion

    #region Controls Management Methods

    private void SetStatus(string t, int tabindex)
    {
        if (tabindex == 0)
        {
            lbStatusTab1.Text = t;
            lbStatusTab1.ForeColor = Constant.StatusColor.Information;
        }
        else if (tabindex == 1)
        {
            lbStatusTab2.Text = t;
            lbStatusTab2.ForeColor = Constant.StatusColor.Information;
        }
        else if (tabindex == 2)
        {
            lbStatusTab3.Text = t;
            lbStatusTab3.ForeColor = Constant.StatusColor.Information;
        }
        else if (tabindex == 3)
        {
            lbStatusTab4.Text = t;
            lbStatusTab4.ForeColor = Constant.StatusColor.Information;
        }
    }

    private void SetErrorStatus(string t, int tabindex)
    {
        if (tabindex == 0)
        {
            lbStatusTab1.Text = t;
            lbStatusTab1.ForeColor = Constant.StatusColor.Error;
        }
        else if (tabindex == 1)
        {
            lbStatusTab2.Text = t;
            lbStatusTab2.ForeColor = Constant.StatusColor.Error;
        }
        else if (tabindex == 2)
        {
            lbStatusTab3.Text = t;
            lbStatusTab3.ForeColor = Constant.StatusColor.Error;
        }
        else if (tabindex == 3)
        {
            lbStatusTab4.Text = t;
            lbStatusTab4.ForeColor = Constant.StatusColor.Error;
        }
    }

    private MaterialMasterData GetData()
    {
        MaterialMasterData msData = new MaterialMasterData();
        if (chkActive.Checked)
            msData.ACTIVE = "1";
        else
            msData.ACTIVE = "0";
        msData.SAPCODE = txtSAP.Text.Trim();
        msData.NAME = txtName.Text.Trim();
        msData.MATERIALCLASS = Convert.ToDouble(cmbMaterialClass1.SelectedItem.Value);
        msData.MATERIALGROUP = Convert.ToDouble(cmbMaterialGroup1.SelectedItem.Value);
        msData.UNIT = Convert.ToDouble(cmbUnit1.SelectedItem.Value);

        if (txtWeight.Text.Trim() != "")
            msData.WEIGHT = Convert.ToDouble(txtWeight.Text.Trim());
        if (txtWeightPrepare.Text.Trim() != "")
            msData.WEIGHTPREPARE = Convert.ToDouble(txtWeightPrepare.Text.Trim());
        if (txtWeightCookBO.Text.Trim() != "")
            msData.WEIGHTCOOKBO = Convert.ToDouble(txtWeightCookBO.Text.Trim());
        if (txtWeightCookFR.Text.Trim() != "")
            msData.WEIGHTCOOKFR = Convert.ToDouble(txtWeightCookFR.Text.Trim());
        if (txtWeightCookRO.Text.Trim() != "")
            msData.WEIGHTCOOKRO = Convert.ToDouble(txtWeightCookRO.Text.Trim());
        if (txtWeightCookFY.Text.Trim() != "")
            msData.WEIGHTCOOKFY = Convert.ToDouble(txtWeightCookFY.Text.Trim());
        if (txtWeightCookST.Text.Trim() != "")
            msData.WEIGHTCOOKST = Convert.ToDouble(txtWeightCookST.Text.Trim());
        if (txtWeightCookNN.Text.Trim() != "")
            msData.WEIGHTCOOKNN = Convert.ToDouble(txtWeightCookNN.Text.Trim());
        if (txtWeightCookPE.Text.Trim() != "")
            msData.WEIGHTCOOKPE = Convert.ToDouble(txtWeightCookPE.Text.Trim());
        if (txtOilFR.Text.Trim() != "")
            msData.OILFR = Convert.ToDouble(txtOilFR.Text.Trim());
        if (txtOilFY.Text.Trim() != "")
            msData.OILFY = Convert.ToDouble(txtOilFY.Text.Trim());
        if (txtCost.Text.Trim() != "")
            msData.COST = Convert.ToDouble(txtCost.Text.Trim());
        if (txtPrice.Text.Trim() != "")
            msData.PRICE = Convert.ToDouble(txtPrice.Text.Trim());

        msData.SPEC = txtSpec.Text.Trim();
        msData.ORDERTYPE = cmbOrderType.SelectedItem.Value;
        msData.DIVISION = Convert.ToDouble(cmbDivision.SelectedItem.Value);

        if (radMorningAdvance.Checked)
            msData.STOCKOUTBREAKFAST = "0";
        else if (radMorningDay.Checked)
            msData.STOCKOUTBREAKFAST = "1";

        if (radNoonAdvance.Checked)
            msData.STOCKOUTLUNCH = "0";
        else if (radNoonDay.Checked)
            msData.STOCKOUTLUNCH = "1";

        if (radEveningAdvance.Checked)
            msData.STOCKOUTDINNER = "0";
        else if (radEveningDay.Checked)
            msData.STOCKOUTDINNER = "1";

        if (chkIsCount.Checked)
            msData.ISCOUNT = "Y";
        else
            msData.ISCOUNT = "N";
        msData.ISMENU = (chkIsMenu.Checked ? "Y" : "N");

        if (txtMinStock.Text.Trim() != "")
            msData.MINSTOCK = Convert.ToDouble(txtMinStock.Text.Trim());
        if (txtMaxStock.Text.Trim() != "")
            msData.MAXSTOCK = Convert.ToDouble(txtMaxStock.Text.Trim());

        msData.REMARKS = txtRemarks.Text.Trim();

        return msData;
    }

    private void SetFoodDetailData(MaterialMasterData msData)
    {
        txtLOID.Text = msData.LOID.ToString();
        txtCode.Text = msData.CODE;

        if (msData.ACTIVE == "1")
            chkActive.Checked = true;
        else
            chkActive.Checked = false;

        txtSAP.Text = msData.SAPCODE;
        txtMSap.Text = msData.SAPCODE;
        txtName.Text = msData.NAME;
        txtMName.Text = msData.NAME;
        txtMWeight.Text = msData.NUTRIENTRATE.ToString();
        cmbMaterialClass1.SelectedIndex = cmbMaterialClass1.Items.IndexOf(cmbMaterialClass1.Items.FindByValue(msData.MATERIALCLASS.ToString()));
        SetComboMaterialGroup1();
        cmbMaterialGroup1.SelectedIndex = cmbMaterialGroup1.Items.IndexOf(cmbMaterialGroup1.Items.FindByValue(msData.MATERIALGROUP.ToString()));
        txtMType.Text = cmbMaterialGroup1.SelectedItem.Text;
        cmbUnit1.SelectedIndex = cmbUnit1.Items.IndexOf(cmbUnit1.Items.FindByValue(msData.UNIT.ToString()));
        txtMUnit.Text = cmbUnit1.SelectedItem.Text;
        txtCost.Text = msData.COST.ToString();
        txtPrice.Text = msData.PRICE.ToString();
        txtWeight.Text = msData.WEIGHT.ToString();
        txtWeightPrepare.Text = msData.WEIGHTPREPARE.ToString();
        txtWeightCookBO.Text = msData.WEIGHTCOOKBO.ToString();
        txtWeightCookFR.Text = msData.WEIGHTCOOKFR.ToString();
        txtWeightCookFY.Text = msData.WEIGHTCOOKFY.ToString();
        txtWeightCookRO.Text = msData.WEIGHTCOOKRO.ToString();
        txtWeightCookST.Text = msData.WEIGHTCOOKST.ToString();
        txtWeightCookNN.Text = msData.WEIGHTCOOKNN.ToString();
        txtWeightCookPE.Text = msData.WEIGHTCOOKPE.ToString();
        txtOilFR.Text = msData.OILFR.ToString();
        txtOilFY.Text = msData.OILFY.ToString();
        txtSpec.Text = msData.SPEC;
        cmbOrderType.SelectedIndex = cmbOrderType.Items.IndexOf(cmbOrderType.Items.FindByValue(msData.ORDERTYPE));
        cmbDivision.SelectedIndex = cmbDivision.Items.IndexOf(cmbDivision.Items.FindByValue(msData.DIVISION.ToString()));
        if (msData.STOCKOUTBREAKFAST == "0")
        {
            radMorningAdvance.Checked = true;
            radMorningDay.Checked = false;
        }
        else if (msData.STOCKOUTBREAKFAST == "1")
        {
            radMorningAdvance.Checked = false;
            radMorningDay.Checked = true;
        }

        if (msData.STOCKOUTLUNCH == "0")
        {
            radNoonAdvance.Checked = true;
            radNoonDay.Checked = false;
        }
        else if (msData.STOCKOUTLUNCH == "1")
        {
            radNoonAdvance.Checked = false;
            radNoonDay.Checked = true;
        }

        if (msData.STOCKOUTDINNER == "0")
        {
            radEveningAdvance.Checked = true;
            radEveningDay.Checked = false;
        }
        else if (msData.STOCKOUTDINNER == "1")
        {
            radEveningAdvance.Checked = false;
            radEveningDay.Checked = true;
        }

        if (msData.ISCOUNT == "Y")
            chkIsCount.Checked = true;
        else
            chkIsCount.Checked = false;

        chkIsMenu.Checked = (msData.ISMENU == "Y");

        txtMinStock.Text = msData.MINSTOCK.ToString();
        txtMaxStock.Text = msData.MAXSTOCK.ToString();
        txtRemarks.Text = msData.REMARKS;
    }

    private void SetTabFoodUnit(DataTable dt)
    {
        txtCode_FoodUnit.Text = dt.Rows[0]["MATERIALCODE"].ToString();
        txtName_FoodUnit.Text = dt.Rows[0]["MATERIALNAME"].ToString();
        txtMaterialClass_FoodUnit.Text = dt.Rows[0]["CLASSNAME"].ToString();
        txtMaterialGroup_FoodUnit.Text = dt.Rows[0]["GROUPNAME"].ToString();
        txtUnit_FoodUnit.Text = dt.Rows[0]["THNAME"].ToString();
    }

    private void SetGridViewFoodUnit(DataTable dt)
    {
        gvFoodUnit.DataSource = dt;
        gvFoodUnit.DataBind();
    }

    private void SetGridViewFoodNutrient(DataTable dt)
    {
        gvFoodNutrient.DataSource = dt;
        gvFoodNutrient.DataBind();

        if (gvFoodNutrient.Rows.Count == 0)
        {
            DataTable tmp = new DataTable();
            DataColumn dcMMLOID = new DataColumn("MMLOID");
            DataColumn dcMMNAME = new DataColumn("MMNAME");
            DataColumn dcNUTRIENTLOID = new DataColumn("NUTRIENTLOID");
            DataColumn dcNUTRIENTNAME = new DataColumn("NUTRIENTNAME");
            DataColumn dcQTY = new DataColumn("QTY");
            DataColumn dcUNITLOID = new DataColumn("UNITLOID");
            DataColumn dcUNITNAME = new DataColumn("UNITNAME");

            tmp.Columns.Add(dcMMLOID);
            tmp.Columns.Add(dcMMNAME);
            tmp.Columns.Add(dcNUTRIENTLOID);
            tmp.Columns.Add(dcNUTRIENTNAME);
            tmp.Columns.Add(dcQTY);
            tmp.Columns.Add(dcUNITLOID);
            tmp.Columns.Add(dcUNITNAME);

            DataRow dr = tmp.Rows.Add();
            dr["NUTRIENTLOID"] = 0;

            gvFoodNutrient.DataSource = tmp;
            gvFoodNutrient.DataBind();
        }
    }

    private void ClearDataAllTabs()
    {
        ClearDataTabFoodDetail();
        ClearDataTabFoodUnit();
        ClearDataTabFoodNutrient();
        CheckAllASeason();
        CheckHead();
        Session["tmpTableFoodUnit"] = null;
        Session["tmpTableFoodNutrient"] = null;
        TabContainer1.ActiveTabIndex = 0;
        txtPrevTabIndex.Text = "0";
        zPop.Show();
    }

    private void ClearDataTabFoodDetail()
    {
        lbStatusTab1.Text = "";
        txtCode.Text = "";
        txtLOID.Text = "";
        txtSAP.Text = "";
        chkActive.Checked = true;
        txtName.Text = "";
        Appz.BuildCombo(cmbMaterialClass1, "MATERIALCLASS", "NAME", "LOID", "MASTERTYPE = 'FO' AND ACTIVE = '1'", "NAME", "เลือก", "0", false);
        SetComboMaterialGroup1();
        cmbUnit1.SelectedIndex = -1;
        txtCost.Text = "";
        txtPrice.Text = "";
        txtWeight.Text = "";
        txtWeightPrepare.Text = "";
        txtWeightCookBO.Text = "";
        txtWeightCookFR.Text = "";
        txtWeightCookFY.Text = "";
        txtWeightCookNN.Text = "";
        txtWeightCookPE.Text = "";
        txtWeightCookRO.Text = "";
        txtWeightCookST.Text = "";
        txtOilFR.Text = "";
        txtOilFY.Text = "";
        txtSpec.Text = "";
        cmbOrderType.SelectedIndex = -1;
        cmbDivision.SelectedIndex = -1;
        radMorningAdvance.Checked = true;
        radMorningDay.Checked = false;
        radNoonAdvance.Checked = true;
        radNoonDay.Checked = false;
        radEveningAdvance.Checked = false;
        radEveningDay.Checked = true;
        chkIsCount.Checked = false;
        chkIsMenu.Checked = false;
        txtMinStock.Text = "";
        txtMaxStock.Text = "";
        txtRemarks.Text = "";
    }

    private void ClearDataTabFoodUnit()
    {
        lbStatusTab2.Text = "";
        txtCode_FoodUnit.Text = "";
        txtName_FoodUnit.Text = "";
        txtMaterialClass_FoodUnit.Text = "";
        txtMaterialGroup_FoodUnit.Text = "";
        txtUnit_FoodUnit.Text = "";
        gvFoodUnit.DataSource = null;
        gvFoodUnit.EditIndex = -1;
        gvFoodUnit.DataBind();
    }

    private void ClearDataTabFoodNutrient()
    {
        lbStatusTab3.Text = "";
        txtKcal.Text = "";
        gvFoodNutrient.DataSource = null;
        gvFoodNutrient.EditIndex = -1;
        gvFoodNutrient.DataBind();
    }

    private void CheckAllASeason()
    {
        chkM1.Checked = true;
        chkM2.Checked = true;
        chkM3.Checked = true;
        chkM4.Checked = true;
        chkM5.Checked = true;
        chkM6.Checked = true;
        chkM7.Checked = true;
        chkM8.Checked = true;
        chkM9.Checked = true;
        chkM10.Checked = true;
        chkM11.Checked = true;
        chkM12.Checked = true;
    }

    private void UncheckALLSeason()
    {
        chkM1.Checked = false;
        chkM2.Checked = false;
        chkM3.Checked = false;
        chkM4.Checked = false;
        chkM5.Checked = false;
        chkM6.Checked = false;
        chkM7.Checked = false;
        chkM8.Checked = false;
        chkM9.Checked = false;
        chkM10.Checked = false;
        chkM11.Checked = false;
        chkM12.Checked = false;
    }

    protected void cmbMaterialClass_SelectedIndexChanged(object sender, EventArgs e)
    {
        SetComboMaterialGroup();
    }

    protected void cmbMaterialClass1_SelectedIndexChanged(object sender, EventArgs e)
    {
        SetComboMaterialGroup1();
        zPop.Show();
    }

    private void SetControl()
    {
        ControlUtil.SetDblTextBox(txtCost);
        ControlUtil.SetDblTextBox(txtPrice);
        ControlUtil.SetDblTextBoxRealNumer(txtWeight);
        ControlUtil.SetDblTextBoxRealNumer(txtWeightPrepare);
        ControlUtil.SetDblTextBoxRealNumer(txtWeightCookBO);
        ControlUtil.SetDblTextBoxRealNumer(txtWeightCookFY);
        ControlUtil.SetDblTextBoxRealNumer(txtWeightCookRO);
        ControlUtil.SetDblTextBoxRealNumer(txtWeightCookFR);
        ControlUtil.SetDblTextBoxRealNumer(txtWeightCookST);
        ControlUtil.SetDblTextBoxRealNumer(txtWeightCookNN);
        ControlUtil.SetDblTextBoxRealNumer(txtWeightCookPE);
        ControlUtil.SetDblTextBoxRealNumer(txtOilFR);
        ControlUtil.SetDblTextBoxRealNumer(txtOilFY);
        ControlUtil.SetDblTextBoxRealNumer(txtMinStock);
        ControlUtil.SetDblTextBoxRealNumer(txtMaxStock);
        //ControlUtil.SetDblTextBoxRealNumer(txtWeightCook);
        
    }


    private void ReloadGVFoodUnit()
    {
        if (Session["tmpTableFoodUnit"] != null)
            tmpTableFoodUnit = (DataTable)Session["tmpTableFoodUnit"];

        SetGridViewFoodUnit(tmpTableFoodUnit);
        zPop.Show();
    }

    private void ReloadGVFoodNutrient()
    {
        if (Session["tmpTableFoodNutrient"] != null)
            tmpTableFoodNutrient = (DataTable)Session["tmpTableFoodNutrient"];

        SetGridViewFoodNutrient(tmpTableFoodNutrient);
        zPop.Show();
    }

    protected void TabContainer1_ActiveTabChanged(object sender, EventArgs e)
    {
        // จะเกิดการทำงานใน method นี้ สองครั้งเมื่อกดเปลี่ยน Tab, ครั้งแรกคือการ Postback ของ Tab ปัจจุบัน ครั้งที่สองคือ Postback ของ Tab ใหม่
        // จะเกิดการทำงานใน method นี้ ครั้งเดียว ถ้ากดที่ Tab ปัจจุบัน (ไม่ได้เปลี่ยน Tab)

        // กำหนดาค่า เริ่มต้น tabFlag = false
        // บังคับให้ทำงานในรอบที่สอง
        if (tabFlag == true)
        {
            if (SavePreviousTab(txtPrevTabIndex.Text.Trim()) == true)
            {
                txtPrevTabIndex.Text = TabContainer1.ActiveTabIndex.ToString();
                lbStatusTab1.Text = "";
                lbStatusTab2.Text = "";
                lbStatusTab3.Text = "";
                lbStatusTab4.Text = "";
                gvFoodUnit.EditIndex = -1;
                gvFoodNutrient.EditIndex = -1;
                doGetFoodDetail(Convert.ToDouble(txtLOID.Text.Trim()));
            }
            else
            {
                TabContainer1.ActiveTabIndex = Convert.ToInt32(txtPrevTabIndex.Text.Trim());
            }
        }
        else
            tabFlag = true; // รอบแรกจะเข้า else เพราะ ค่าของ tabFlag ตอนเริ่ม = false

        zPop.Show();
    }

    private bool SavePreviousTab(string prevTabIndex)
    {
        if (prevTabIndex == "0")
        {
            if (doSaveTabFoodDetail() == true)
                return true;
            else
                return false;
        }
        else if (prevTabIndex == "1")
        {
            if (doSaveTabFoodUnit() == true)
                return true;
            else
                return false;
        }
        else if (prevTabIndex == "2")
        {
            if (doSaveTabFoodNutrient() == true)
                return true;
            else
                return false;
        }
        else if (prevTabIndex == "3")
        {
            if (doSaveTabFoodSeason() == true)
                return true;
            else
                return false;
        }
        else
            return false;
    }

    private void CheckHead()
    {
        if (chkM1.Checked && chkM2.Checked && chkM3.Checked && chkM4.Checked && chkM5.Checked && chkM6.Checked && chkM7.Checked && chkM8.Checked && chkM9.Checked && chkM10.Checked && chkM11.Checked && chkM12.Checked)
            chkAll.Checked = true;
        else
            chkAll.Checked = false;
    }

    private void CheckAllControl()
    {
        if (chkAll.Checked)
        {
            CheckAllASeason();
        }
        else
        {
            UncheckALLSeason();
        }
    }

    #endregion

    #region Working Method


    private void doGetList()
    {
        MaterialFoodSearchFlow fFlow = new MaterialFoodSearchFlow();

        this.imbReset.Visible = (this.cmbMaterialClass.SelectedIndex != 0) || (this.cmbMaterialGroup.SelectedIndex != 0) || (this.txtSearchName.Text.Trim() != ""); 
        string orderStr = "";
        if (txhSortField.Text.Trim() != "")
            orderStr = " " + txhSortField.Text + " " + txhSortDir.Text;

        gvMain.DataSource = fFlow.GetMaterialMasterList(cmbMaterialClass.SelectedItem.Value, cmbMaterialGroup.SelectedItem.Value, txtSearchName.Text.Trim(), orderStr);
        gvMain.DataBind();
        pcTop.Update();
        pcBot.Update();
    }

    private void doGetFoodNutrientList()
    {
        MaterialFoodSearchFlow fFlow = new MaterialFoodSearchFlow();

        string orderStr = "";
        if (txhSortFieldTabNutrient.Text.Trim() != "")
            orderStr = " " + txhSortFieldTabNutrient.Text + " " + txhSortDirTabNutrient.Text;

        DataTable dt = fFlow.GetMaterialNutrient(txtLOID.Text.Trim(), orderStr);
        Session["tmpTableFoodNutrient"] = dt;
        SetGridViewFoodNutrient(dt);
        zPop.Show();
    }

    private void doGetFoodDetail(double loid)
    {
        //ใส่ค่าใน control ต่างๆ ใน tab ที่1 (รายละเอียด)
        MaterialFoodSearchFlow msFlow = new MaterialFoodSearchFlow();
        MaterialMasterData msData = new MaterialMasterData();
        msData = msFlow.GetFoodDetailData(loid);
        SetFoodDetailData(msData);

        //ใส่ค่าใน control ต่างๆ ใน tab ที่2 (หน่วยย่อย)
        DataTable dt = msFlow.GetMaterialMasterByLOID(loid.ToString());
        if (dt.Rows.Count > 0)
            SetTabFoodUnit(dt);

        //ใส่ค่าใน gvFoodUnit ใน tab ที่2 (หน่วยย่อย)
        DataTable dtMMUnit = msFlow.GetMaterialMasterUnit(loid.ToString());
        CreateTempTableFoodUnit();
        SetTempTableFoodUnit(dtMMUnit);
        Session["tmpTableFoodUnit"] = tmpTableFoodUnit;
        SetGridViewFoodUnit(tmpTableFoodUnit);

        //ใส่ค่า Kcal ใน tab3
        double energy = msFlow.GetEnergy(loid.ToString());
        txtKcal.Text = energy.ToString("#,##0.############");
        //ใส่ค่าใน gvFoodNutrient ใน tab ที่3 (สารอาหาร)
        DataTable dtFoodNutrient = msFlow.GetMaterialNutrient(loid.ToString(), "");
        CreateTempTableFoodNutrient();
        SetTempTableFoodNutrient(dtFoodNutrient);
        Session["tmpTableFoodNutrient"] = tmpTableFoodNutrient;
        SetGridViewFoodNutrient(tmpTableFoodNutrient);

        //ใส่ค่าใน Control ใน tab ที่4
        DataTable dtSeason = msFlow.GetMaterialSeason(loid.ToString());
        if (dtSeason.Rows.Count > 0)
        {
            if (dtSeason.Rows[0]["M1"].ToString() == "Y")
                chkM1.Checked = true;
            else
                chkM1.Checked = false;

            if (dtSeason.Rows[0]["M2"].ToString() == "Y")
                chkM2.Checked = true;
            else
                chkM2.Checked = false;

            if (dtSeason.Rows[0]["M3"].ToString() == "Y")
                chkM3.Checked = true;
            else
                chkM3.Checked = false;

            if (dtSeason.Rows[0]["M4"].ToString() == "Y")
                chkM4.Checked = true;
            else
                chkM4.Checked = false;

            if (dtSeason.Rows[0]["M5"].ToString() == "Y")
                chkM5.Checked = true;
            else
                chkM5.Checked = false;

            if (dtSeason.Rows[0]["M6"].ToString() == "Y")
                chkM6.Checked = true;
            else
                chkM6.Checked = false;

            if (dtSeason.Rows[0]["M7"].ToString() == "Y")
                chkM7.Checked = true;
            else
                chkM7.Checked = false;

            if (dtSeason.Rows[0]["M8"].ToString() == "Y")
                chkM8.Checked = true;
            else
                chkM8.Checked = false;

            if (dtSeason.Rows[0]["M9"].ToString() == "Y")
                chkM9.Checked = true;
            else
                chkM9.Checked = false;

            if (dtSeason.Rows[0]["M10"].ToString() == "Y")
                chkM10.Checked = true;
            else
                chkM10.Checked = false;

            if (dtSeason.Rows[0]["M11"].ToString() == "Y")
                chkM11.Checked = true;
            else
                chkM11.Checked = false;

            if (dtSeason.Rows[0]["M12"].ToString() == "Y")
                chkM12.Checked = true;
            else
                chkM12.Checked = false;
        }
        else
        {
            CheckAllASeason();
        }

        CheckHead();
    }

    private bool doSaveTabFoodDetail()
    {
        // verify required field
        string error = VerifyData();
        if (error != "")
        {
            SetErrorStatus(error, 0);
            return false;
        }

        MaterialFoodSearchFlow msFlow = new MaterialFoodSearchFlow();
        bool ret = true;

        // data correct go on saving...
        if (txtCode.Text.Trim() == "")
        {
            //  save new
            if (CheckNameExist() == true)
            {
                SetErrorStatus("มีชื่อวัสดุอาหาร " + txtName.Text.Trim() + " ในระบบแล้ว", 0);
                return false;
            }
            else
            {
                ret = msFlow.InsertData(GetData(), Appz.CurrentUser);
            }          
        }
        else
        {
            // save update
            MaterialMasterData msData;
            msData = GetData();
            msData.LOID = Convert.ToDouble(txtLOID.Text.Trim());
            ret = msFlow.UpdateData(msData, Appz.CurrentUser);
        }

        if (!ret)
        {
            SetErrorStatus(msFlow.ErrorMessage, 0);
        }
        else
        {
            SetStatus("บันทึกข้อมูลเรียบร้อย", 0);
            txtLOID.Text = msFlow.LOID.ToString();
        }
        return ret;
    }

    private void doDelete()
    {
        MaterialFoodSearchFlow msFlow = new MaterialFoodSearchFlow();
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
            ret = string.Format(DataResources.MSGEI001, "ชื่อวัสดุอาหาร");
        else if (cmbMaterialClass1.SelectedItem.Value == "0")
            ret = string.Format(DataResources.MSGEI002, "หมวดอาหาร");
        else if (cmbMaterialGroup1.SelectedItem.Value == "0")
            ret = string.Format(DataResources.MSGEI002, "ประเภทอาหาร");
        else if (cmbUnit1.SelectedItem.Value == "0")
            ret = string.Format(DataResources.MSGEI002, "หน่วยนับ");
        else if (txtSpec.Text.Trim() == "")
            ret = string.Format(DataResources.MSGEI001, "Spec");
        else if (cmbOrderType.SelectedItem.Value == "0")
            ret = string.Format(DataResources.MSGEI002, "วิธีการรับเข้า");
        else if (cmbDivision.SelectedItem.Value == "0")
            ret = string.Format(DataResources.MSGEI002, "หน่วยงานที่ตัดจ่าย");
        else if (TabContainer1.ActiveTabIndex == 2)
        {
            if (txtMWeight.Text.Trim() == "")
                ret = string.Format(DataResources.MSGEI001, "น้ำหนักสำหรับใช้คำนวณพลังงานและสารอาหาร");
            if (txtMWeight.Text.Trim() == "0")
                ret = string.Format(DataResources.MSGEI004, "น้ำหนักสำหรับใช้คำนวณพลังงานและสารอาหาร", "0");
        }

        return ret;
    }

    private bool CheckNameExist()
    {
        MaterialFoodSearchFlow msFlow = new MaterialFoodSearchFlow();
        return msFlow.CheckNameExist(txtName.Text.Trim());
    }

    private void AddUnitToTempTable()
    {
        DropDownList cmbTHUNITAdd = (DropDownList)gvFoodUnit.FooterRow.FindControl("cmbTHUNITAdd");
        TextBox txtWeightAdd = (TextBox)gvFoodUnit.FooterRow.FindControl("txtWeightAdd");
        TextBox txtCostAdd = (TextBox)gvFoodUnit.FooterRow.FindControl("txtCostAdd");
        TextBox txtPriceAdd = (TextBox)gvFoodUnit.FooterRow.FindControl("txtPriceAdd");
        TextBox txtMultiplyAdd = (TextBox)gvFoodUnit.FooterRow.FindControl("txtMultiplyAdd");
        CheckBox chkIsStockInAdd = (CheckBox)gvFoodUnit.FooterRow.FindControl("chkIsStockInAdd");
        CheckBox chkIsStockOutAdd = (CheckBox)gvFoodUnit.FooterRow.FindControl("chkIsStockOutAdd");
        CheckBox chkIsFormulaAdd = (CheckBox)gvFoodUnit.FooterRow.FindControl("chkIsFormulaAdd");
        CheckBox chkActiveAdd = (CheckBox)gvFoodUnit.FooterRow.FindControl("chkActiveAdd");

        if (Session["tmpTableFoodUnit"] != null)
        {
            DataTable dt = (DataTable)Session["tmpTableFoodUnit"];
            DataRow dr = dt.Rows.Add();

            dr["MMLOID"] = txtLOID.Text.Trim();
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

            Session["tmpTableFoodUnit"] = dt;
            SetGridViewFoodUnit(dt);
        }

    }

    private void AddNutrientToTempTable()
    {
        DropDownList cmbNUTRIENTNAMEAdd = (DropDownList)gvFoodNutrient.FooterRow.FindControl("cmbNUTRIENTNAMEAdd");
        TextBox txtQTYAdd = (TextBox)gvFoodNutrient.FooterRow.FindControl("txtQTYAdd");

        if (Session["tmpTableFoodNutrient"] != null)
        {
            DataTable dt = (DataTable)Session["tmpTableFoodNutrient"];
            DataRow dr = dt.Rows.Add();

            dr["MMLOID"] = txtLOID.Text.Trim();
            dr["NUTRIENTLOID"] = cmbNUTRIENTNAMEAdd.SelectedItem.Value;
            dr["NUTRIENTNAME"] = cmbNUTRIENTNAMEAdd.SelectedItem.Text.Trim();
            dr["QTY"] = txtQTYAdd.Text.Trim();

            MaterialFoodSearchFlow msFlow = new MaterialFoodSearchFlow();
            dr["UNITNAME"] = msFlow.GetUnitNameByNutrientLOID(cmbNUTRIENTNAMEAdd.SelectedItem.Value);

            Session["tmpTableFoodNutrient"] = dt;
            SetGridViewFoodNutrient(dt);
        }
    }

    private bool doSaveTabFoodUnit()
    {
        bool ret = true;

        if (Session["tmpTableFoodUnit"] != null)
        {
            DataTable dt = (DataTable)Session["tmpTableFoodUnit"];
            MaterialFoodSearchFlow msFlow = new MaterialFoodSearchFlow();

            if (txtCode.Text.Trim() != "")
            {
                ret = msFlow.UpdateMaterialUnit(dt, txtLOID.Text.Trim(), Appz.CurrentUser);
            }

            if (!ret)
            {
                SetErrorStatus(msFlow.ErrorMessage, 1);
            }
            else
            {
                SetStatus("บันทึกข้อมูลเรียบร้อย", 1);
            }
            return ret;

        }
        else
            return false;


    }

    private bool doSaveTabFoodNutrient()
    {
        string error = VerifyData();
        bool ret = true;

        if (Session["tmpTableFoodNutrient"] != null)
        {
            DataTable dt = (DataTable)Session["tmpTableFoodNutrient"];
            MaterialFoodSearchFlow msFlow = new MaterialFoodSearchFlow();

            if (txtCode.Text.Trim() != "")
            {
                ret = msFlow.UpdateMaterialNutrient(dt, txtLOID.Text.Trim(), Appz.CurrentUser);
            }

            if (!ret)
            {
                SetErrorStatus(msFlow.ErrorMessage, 2);
            }
            else
            {
                if (msFlow.UpdateEnergy(txtLOID.Text.Trim(), Convert.ToDouble(txtMWeight.Text.Trim())))
                {
                    SetStatus("บันทึกข้อมูลเรียบร้อย", 2);
                    ret = true;
                }
            }
            return ret;
        }
        else
            return false;
    }

    private bool doSaveTabFoodSeason()
    {
        bool ret = true;
        MaterialSeasonData msData = new MaterialSeasonData();
        MaterialFoodSearchFlow msFlow = new MaterialFoodSearchFlow();

        if (txtCode.Text.Trim() == "")
        {
            return false;
        }

        msData.MATERIALMASTER = Convert.ToDouble(txtLOID.Text.Trim());

        if (chkM1.Checked)
            msData.M1 = "Y";
        else
            msData.M1 = "N";

        if (chkM2.Checked)
            msData.M2 = "Y";
        else
            msData.M2 = "N";

        if (chkM3.Checked)
            msData.M3 = "Y";
        else
            msData.M3 = "N";

        if (chkM4.Checked)
            msData.M4 = "Y";
        else
            msData.M4 = "N";

        if (chkM5.Checked)
            msData.M5 = "Y";
        else
            msData.M5 = "N";

        if (chkM6.Checked)
            msData.M6 = "Y";
        else
            msData.M6 = "N";

        if (chkM7.Checked)
            msData.M7 = "Y";
        else
            msData.M7 = "N";

        if (chkM8.Checked)
            msData.M8 = "Y";
        else
            msData.M8 = "N";

        if (chkM9.Checked)
            msData.M9 = "Y";
        else
            msData.M9 = "N";

        if (chkM10.Checked)
            msData.M10 = "Y";
        else
            msData.M10 = "N";

        if (chkM11.Checked)
            msData.M11 = "Y";
        else
            msData.M11 = "N";

        if (chkM12.Checked)
            msData.M12 = "Y";
        else
            msData.M12 = "N";

        if (txtCode.Text.Trim() != "")
        {
            ret = msFlow.UpdateMaterialSeason(msData, Appz.CurrentUser);
        }

        if (!ret)
        {
            SetErrorStatus(msFlow.ErrorMessage, 3);
            ret = false;
        }
        else
        {
            SetStatus("บันทึกข้อมูลเรียบร้อย", 3);
            ret = true;
        }

        return ret;
    }



    #endregion




}
