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
using SHND.Data.Views;
using SHND.Global;
using SHND.Flow.Common;
using SHND.Data.Common.Utilities;

/// <summary>
/// FoemulaFeedLDSearch Page Class
/// Version 1.0
/// =========================================================================
/// Create by: Pom
/// Create Date: 13 Jan 2009
/// -------------------------------------------------------------------------
/// Modify By: -
/// Modify From: -
/// Modify Date: -
/// -------------------------------------------------------------------------
/// Remark: -
/// Description:
///    หน้ากาารทำงานข้อมูล FormulaFeedLDSearch
/// Changes:
///    1.0 - สร้าง
/// -------------------------------------------------------------------------
/// =========================================================================
/// </summary>
/// 

public partial class App_Formula_Master_FormulaFeedLDSearch : System.Web.UI.Page
{
    private bool tabFlag = false;

    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            CreateTmpFeedItem();
            CreateTmpDisease();
            TabContainer1.ActiveTabIndex = 0;
            gvMain.PageIndex = 0;
            doGetList();
        }
    }

    protected override void OnInit(EventArgs e)
    {
        base.OnInit(e);

        pcTop.SetMainGridView(gvMain);
        pcBot.SetMainGridView(gvMain);
        ControlUtil.SetDblTextBox(txtEnergyFrom);
        ControlUtil.SetDblTextBox(txtEnergyTo);
        ControlUtil.SetDblTextBox(txtCapacityFrom);
        ControlUtil.SetDblTextBox(txtCapacityTo);
        ControlUtil.SetDblTextBoxRealNumer(txtCapacity);
        ControlUtil.SetIntTextBox(txtPortion);
    }

    protected void ctlMaterialMasterPopup_SelectedIndexChanged(object sender, EventArgs e, ArrayList arrData)
    {
        if (InsertNewDataToTmpFeedItem(arrData))
            BindGVFeedItem();
    }

    protected void ctlMaterialMasterPopup_Cancel(object sender, EventArgs e)
    {
        zPop.Show();
    }

    protected void ctlDiseaseCategoryPopup_SelectedIndexChanged(object sender, EventArgs e, ArrayList arrData)
    {
        if (InsertNewDataToTmpFormulaDisease(arrData))
            BindGVFormulaDisease();
    }

    #region Button Click Event Handler

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

    protected void tbSaveClick(object sender, EventArgs e)
    {
        if (doSave(TabContainer1.ActiveTabIndex) == true)
        {
            double ffloid = Convert.ToDouble(txtFormulaFeedLOID.Text.Trim());

            if (TabContainer1.ActiveTabIndex == 0)
            {              
                doGetFormulaFeed(ffloid);
                doGetFormulaFeedItem(ffloid);
                doGetFormulaNutrient(ffloid);
            }
            else if (TabContainer1.ActiveTabIndex == 1)
            {
                doGetFormulaFeed(ffloid);
                doGetFormulaDisease(ffloid);
                doGetFormulaNutrient(ffloid);
            }
            else if (TabContainer1.ActiveTabIndex == 2)
            {
                doGetFormulaFeed(ffloid);
            }
             
            zPop.Show();
        }
        else
            zPop.Show();
    }

    protected void tbSave2Click(object sender, EventArgs e)
    {
        if (doSave(TabContainer1.ActiveTabIndex) == true)
        {
            ClearAllTabs();
            zPop.Show();
        }
        else
            zPop.Show();
         
    }

    protected void tbCancelClick(object sender, EventArgs e)
    {
        if (TabContainer1.ActiveTabIndex == 0)
        {
            if (txtFormulaFeedLOID.Text.Trim() == "")
            {
                ClearTabFormulaFeedItem();
            }
            else
            {
                double ffloid = Convert.ToDouble(txtFormulaFeedLOID.Text.Trim());
                doGetFormulaFeed(ffloid);
                doGetFormulaFeedItem(ffloid);
                doGetFormulaNutrient(ffloid);
                lblStatus.Text = "";
                lbStatusFeedItem.Text = "";
            } 
        }
        else if (TabContainer1.ActiveTabIndex == 1)
        {
            if (txtFormulaFeedLOID.Text.Trim() == "")
            {
                ClearTabFormulaDisease();
            }
            else
            {
                double ffloid = Convert.ToDouble(txtFormulaFeedLOID.Text.Trim());
                doGetFormulaFeed(ffloid);
                doGetFormulaDisease(ffloid);
                doGetFormulaNutrient(ffloid);
                lblStatus.Text = "";
                lbStatusFeedItem.Text = "";
            }
        }
        else if (TabContainer1.ActiveTabIndex == 2)
        {
            if (txtFormulaFeedLOID.Text.Trim() == "")
            {
                ClearTabFormulaNutrient();
            }
            else
            {
                double ffloid = Convert.ToDouble(txtFormulaFeedLOID.Text.Trim());
                doGetFormulaFeed(ffloid);
                doGetFormulaNutrient(ffloid);
                lblStatus.Text = "";
                lbStatusFeedItem.Text = "";
            }
        }

        zPop.Show();
    }

    protected void tbBackClick(object sender, EventArgs e)
    {
        ClearAllTabs();
        TabContainer1.ActiveTabIndex = 0;
        txtPrevTabIndex.Text = "0";
        doGetList();
    }

    protected void imbNameAddClick(object sender, EventArgs e)
    { 
        
    }

    protected void lnkName_Click(object sender, EventArgs e)
    {
        double ffloid = Convert.ToDouble(((LinkButton)sender).CommandArgument);
        doGetAllTab(ffloid);
        TabContainer1.ActiveTabIndex = 0;
        txtPrevTabIndex.Text = "0";
        zPop.Show();
    }

    protected void tbAddFormulaFeedItemClick(object sender, EventArgs e)
    {
        this.ctlMaterialMasterPopup.Show("", getMaterialList());
        lblStatus.Text = "";
        lbStatusFeedItem.Text = "";
    }

    protected void tbAddFormulaDiseaseClick(object sender, EventArgs e)
    {
        FormulaFeedLDFlow fFlow = new FormulaFeedLDFlow();
        this.ctlDiseaseCategoryPopup.Show("1",fFlow.getLiquidCategory(), getDiseaseList());
        lblStatus.Text = "";
        lbStatusFeedItem.Text = "";
    }

    private string getMaterialList()
    {
        string materialList = "";
        DataTable dt = (DataTable)Session["FormulaFeedItem"];
        if (dt != null)
        {
            for (int i = 0; i < dt.Rows.Count; ++i)
            {
                materialList += (materialList == "" ? "" : ",") + dt.Rows[i]["MMLOID"].ToString();
            }
        }
        return materialList;
    }

    private string getDiseaseList()
    {
        string diseaseList = "";
        DataTable dt = (DataTable)Session["FormulaDisease"];
        if (dt != null)
        {
            for (int i = 0; i < dt.Rows.Count; ++i)
            {
                diseaseList += (diseaseList == "" ? "" : ",") + dt.Rows[i]["DCLOID"].ToString();
            }
        }
        return diseaseList;
    }

    protected void tbDeleteFormulaFeedItemClick(object sender, EventArgs e)
    {
        ArrayList arrMMLOIDList = GetGVFeedLDItemChecked();
        DataTable dt = (DataTable)Session["FormulaFeedItem"];

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

        Session["FormulaFeedItem"] = dt;
        BindGVFeedItem();
        UpdateTotalEnergy();
        lblStatus.Text = "";
        lbStatusFeedItem.Text = "";
    }

    protected void tbDeleteFormulaDiseaseClick(object sender, EventArgs e)
    {
        ArrayList arrDCLOIDList = GetGVLDDiseaseChecked();
        DataTable dt = (DataTable)Session["FormulaDisease"];

        if (arrDCLOIDList.Count > 0 && dt != null)
        {
            foreach (string dcloid in arrDCLOIDList)
            {
                for (int i = 0; i < dt.Rows.Count; i++)
                {
                    if (dcloid == dt.Rows[i]["DCLOID"].ToString())
                    {
                        dt.Rows.Remove(dt.Rows[i]);
                    }
                }
            }
        }

        Session["FormulaDisease"] = dt;
        BindGVFormulaDisease();
        lblStatus.Text = "";
        lbStatusFeedItem.Text = "";
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

    protected void gvMain_SelectedIndexChanging(object sender, GridViewSelectEventArgs e)
    {
        string ffloid = gvMain.Rows[e.NewSelectedIndex].Cells[0].Text.Trim();

        doCopyFormulaFeed(ffloid);
        doCopyFormulaFeedItem(ffloid);
        doCopyFormulaDisease(ffloid);

        TabContainer1.ActiveTabIndex = 0;
        txtPrevTabIndex.Text = "0";
        zPop.Show();
    }

    protected void gvMain_RowDeleting(object sender, GridViewDeleteEventArgs e)
    {
        doDelete(e.RowIndex);
    }

    protected void gvFeedLDItem_Sorting(object sender, GridViewSortEventArgs e)
    {
        if (e.SortExpression == "DEFAULT")
        {
            txhSortDirGVFeedLDItem.Text = "";
            txhSortFieldGVFeedLDItem.Text = "";
        }
        else
        {
            if (txhSortFieldGVFeedLDItem.Text == e.SortExpression)
                txhSortDirGVFeedLDItem.Text = (txhSortDirGVFeedLDItem.Text.Trim() == "" ? "DESC" : "");
            else
                txhSortFieldGVFeedLDItem.Text = e.SortExpression;
        }

        FormulaFeedLDFlow fFlow = new FormulaFeedLDFlow();
        if (txtFormulaFeedLOID.Text != "")
        {
            string orderStr = "";
            if (txhSortFieldGVFeedLDItem.Text.Trim() != "")
                orderStr = " " + txhSortFieldGVFeedLDItem.Text + " " + txhSortDirGVFeedLDItem.Text;

            DataTable dtFormulaFeedItem = fFlow.GetFormulaFeedItemList(txtFormulaFeedLOID.Text.Trim(), orderStr);
            CreateTmpFeedItem();
            SetTempFormulaFeedItem(dtFormulaFeedItem);
            BindGVFeedItem();
            CalCulateAfterBind();
        }
        zPop.Show();
    }

    protected void gvLDNutrient_Sorting(object sender, GridViewSortEventArgs e)
    {
        if (txtFormulaFeedLOID.Text.Trim() != "")
        {
            if (e.SortExpression == "DEFAULT")
            {
                txhSortDirNutrient.Text = "";
                txhSortFieldNutrient.Text = "";
            }
            else
            {
                if (txhSortFieldNutrient.Text == e.SortExpression)
                    txhSortDirNutrient.Text = (txhSortDirNutrient.Text.Trim() == "" ? "DESC" : "");
                else
                    txhSortFieldNutrient.Text = e.SortExpression;
            }

            doGetFormulaNutrient(Convert.ToDouble(txtFormulaFeedLOID.Text.Trim()));
        }
    }

    protected void gvFeedLDItem_RowDataBound(object sender, GridViewRowEventArgs e)
    {
        if (e.Row.RowType == DataControlRowType.Header)
        {
            ((CheckBox)e.Row.Cells[1].FindControl("chkAll")).Attributes.Add("onclick", "chkAllBox(this, '" + this.gvFeedLDItem.ClientID + "_ctl', '_chkSelect')");
        }

        if (e.Row.RowType == DataControlRowType.DataRow)
        {
            TextBox txtQTYAdd = (TextBox)e.Row.FindControl("txtQTYAdd");
            if (txtQTYAdd != null)
                ControlUtil.SetDblTextBoxRealNumer(txtQTYAdd);

            //add unit เข้าคอมโบ โดยเลือกที่ ISFORMULA = "Y" ของ MaterialMaster loid ที่ส่งเข้าไป
            DropDownList cmbUnitAdd = (DropDownList)e.Row.FindControl("cmbUnitAdd");
            if (cmbUnitAdd != null)
            {
                string mmloid = e.Row.Cells[11].Text.Trim();
                string whrStr = "ACTIVE = 1 AND ISFORMULA = 'Y' AND MATERIALMASTER = " + mmloid;
                Appz.BuildCombo(cmbUnitAdd, "V_MATERIALMASTER_UNIT", "UNITNAME", "UNIT", whrStr, "UNITNAME", "เลือก", "0", false);

                //Set ค่าให้ Combo หลังจาก BindData
                DataTable dt = (DataTable)Session["FormulaFeedItem"];
                if (dt != null)
                {
                    for (int i = 0; i < dt.Rows.Count; i++)
                    {
                        if (dt.Rows[i]["MMLOID"].ToString().Trim() == mmloid)
                        {
                            string value = dt.Rows[i]["UNITLOID"].ToString();
                            cmbUnitAdd.SelectedIndex = cmbUnitAdd.Items.IndexOf(cmbUnitAdd.Items.FindByValue(value));
                        }
                    }
                }
            }
        }
    }

    protected void gvLDDisease_RowDataBound(object sender, GridViewRowEventArgs e)
    {
        if (e.Row.RowType == DataControlRowType.Header)
        {
            ((CheckBox)e.Row.Cells[1].FindControl("chkAll")).Attributes.Add("onclick", "chkAllBox(this, '" + this.gvLDDisease.ClientID + "_ctl', '_chkSelect')");
        }

        if (e.Row.RowType == DataControlRowType.DataRow)
        { 
            //Check ว่า radio button radISHIGH จะ visible เป็น true หรือ false
            if (e.Row.Cells[8].Text.Trim() == "N")
            {
                RadioButton radISHIGH = (RadioButton)e.Row.FindControl("radISHIGH");
                if (radISHIGH != null)
                    radISHIGH.Visible = false;
            }

            //Check ว่า radio button radISLOW จะ visible เป็น true หรือ false
            if (e.Row.Cells[9].Text.Trim() == "N")
            {
                RadioButton radISLOW = (RadioButton)e.Row.FindControl("radISLOW");
                if (radISLOW != null)
                    radISLOW.Visible = false;
            }

            //Check ว่า radio button radISNON จะ visible เป็น true หรือ false
            if (e.Row.Cells[10].Text.Trim() == "N")
            {
                RadioButton radISNON = (RadioButton)e.Row.FindControl("radISNON");
                if (radISNON != null)
                    radISNON.Visible = false;
            }

        }
    }

    protected void gvLDNutrient_RowDataBound(object sender, GridViewRowEventArgs e)
    {
        if (e.Row.RowType == DataControlRowType.DataRow)
        {
            Label lblQTY = (Label)e.Row.FindControl("lblQTY");
            if (lblQTY != null)
            {
                double tmp = 0;
                if (e.Row.Cells[4].Text.Trim() != "")
                    tmp = Convert.ToDouble(e.Row.Cells[4].Text.Trim());

                lblQTY.Text = tmp.ToString("#,##0.##########") + " " + e.Row.Cells[5].Text.Trim();
            }
        }
    }
    protected void gvMain_RowDataBound(object sender, GridViewRowEventArgs e)
    {
        if (e.Row.RowType == DataControlRowType.DataRow)
        {
            if (e.Row.RowState == DataControlRowState.Normal || e.Row.RowState == DataControlRowState.Alternate)
            {
                LinkButton lnkName = (LinkButton)e.Row.FindControl("lnkName");
                ImageButton imbCopy = (ImageButton)e.Row.FindControl("imbCopy");
                imbCopy.OnClientClick = "return confirm('ต้องการคัดลอกรายการข้อมูลสูตร " + lnkName.Text + " ใช่หรือไม่');";
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

    private void CreateTmpFeedItem()
    {
        DataTable dt = new DataTable();
        DataColumn dcFFILOID = new DataColumn("FFILOID");
        DataColumn dcFORMULAFEEDLOID = new DataColumn("FORMULAFEEDLOID");
        DataColumn dcMMLOID = new DataColumn("MMLOID");
        DataColumn dcMMNAME = new DataColumn("MMNAME");
        DataColumn dcQTY = new DataColumn("QTY");
        DataColumn dcUNITLOID = new DataColumn("UNITLOID");
        DataColumn dcUNITNAME = new DataColumn("UNITNAME");
        DataColumn dcENERGY = new DataColumn("ENERGY");
        DataColumn dcCARBOHYDRATE = new DataColumn("CARBOHYDRATE");
        DataColumn dcPROTEIN = new DataColumn("PROTEIN");
        DataColumn dcFAT = new DataColumn("FAT");
        DataColumn dcSODIUM = new DataColumn("SODIUM");
        DataColumn dcPHOSPHORUS = new DataColumn("PHOSPHORUS");
        DataColumn dcPOTASSIUM = new DataColumn("POTASSIUM");
        DataColumn dcCALCIUM = new DataColumn("CALCIUM");

        dt.Columns.Add(dcFFILOID);
        dt.Columns.Add(dcFORMULAFEEDLOID);
        dt.Columns.Add(dcMMLOID);
        dt.Columns.Add(dcMMNAME);
        dt.Columns.Add(dcQTY);
        dt.Columns.Add(dcUNITLOID);
        dt.Columns.Add(dcUNITNAME);
        dt.Columns.Add(dcENERGY);
        dt.Columns.Add(dcCARBOHYDRATE);
        dt.Columns.Add(dcPROTEIN);
        dt.Columns.Add(dcFAT);
        dt.Columns.Add(dcSODIUM);
        dt.Columns.Add(dcPHOSPHORUS);
        dt.Columns.Add(dcPOTASSIUM);
        dt.Columns.Add(dcCALCIUM);
        
        Session["FormulaFeedItem"] = dt;
    }

    private void CreateTmpDisease()
    {
        // FD = FORMULADISEASE, DC = DISEASECATEGORY
        DataTable dt = new DataTable();
        DataColumn dcFDLOID = new DataColumn("FDLOID");
        DataColumn dcDCLOID = new DataColumn("DCLOID");
        DataColumn dcDCNAME = new DataColumn("DCNAME");
        DataColumn dcDCISHIGHVISIBLE = new DataColumn("DCISHIGHVISIBLE");
        DataColumn dcDCISLOWVISIBLE = new DataColumn("DCISLOWVISIBLE");
        DataColumn dcDCISNONVISIBLE = new DataColumn("DCISNONVISIBLE");
        DataColumn dcFDISHIGH = new DataColumn("FDISHIGH");
        DataColumn dcFDISLOW = new DataColumn("FDISLOW");
        DataColumn dcFDISNON = new DataColumn("FDISNON");
        DataColumn dcFDREFTABLE = new DataColumn("FDREFTABLE");
        DataColumn dcFDREFLOID = new DataColumn("FDREFLOID");

        dt.Columns.Add(dcFDLOID);
        dt.Columns.Add(dcDCLOID);
        dt.Columns.Add(dcDCNAME);
        dt.Columns.Add(dcDCISHIGHVISIBLE);
        dt.Columns.Add(dcDCISLOWVISIBLE);
        dt.Columns.Add(dcDCISNONVISIBLE);
        dt.Columns.Add(dcFDISHIGH);
        dt.Columns.Add(dcFDISLOW);
        dt.Columns.Add(dcFDISNON);
        dt.Columns.Add(dcFDREFTABLE);
        dt.Columns.Add(dcFDREFLOID);

        Session["FormulaDisease"] = dt;
    }

    private ArrayList GetGVFeedLDItemChecked()
    {
        ArrayList arrChk = new ArrayList();
        for (int i = 0; i < gvFeedLDItem.Rows.Count; i++)
        {
            if (gvFeedLDItem.Rows[i].Cells[1].FindControl("chkSelect") != null)
            {
                if (((CheckBox)gvFeedLDItem.Rows[i].Cells[1].FindControl("chkSelect")).Checked)
                    arrChk.Add(gvFeedLDItem.Rows[i].Cells[11].Text.Trim());
            }
        }

        return arrChk;
    }

    private ArrayList GetGVLDDiseaseChecked()
    {
        ArrayList arrChk = new ArrayList();
        for (int i = 0; i < gvLDDisease.Rows.Count; i++)
        {
            if (gvLDDisease.Rows[i].Cells[1].FindControl("chkSelect") != null)
            {
                if (((CheckBox)gvLDDisease.Rows[i].Cells[1].FindControl("chkSelect")).Checked)
                    arrChk.Add(gvLDDisease.Rows[i].Cells[7].Text.Trim());
            }
        }

        return arrChk;
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

    private FormulaFeedData GetData()
    {
        FormulaFeedData ffData = new FormulaFeedData();
        ffData.NAME = txtName.Text.Trim();
        ffData.FEEDCATEGORY = "L";
        if (txtCapacity.Text.Trim() != "")
            ffData.CAPACITY = Convert.ToDouble(txtCapacity.Text.Trim());
        if (txtEnergy.Text.Trim() != "")
            ffData.ENERGY = Convert.ToDouble(txtEnergy.Text.Trim());
        if (txtPortion.Text.Trim() != "")
            ffData.PORTION = Convert.ToDouble(txtPortion.Text.Trim());
        ffData.ACTIVE = (chkActive.Checked ? true : false);

        return ffData;
    }

    private void SetData(DataTable dt)
    {
        txtFormulaFeedLOID.Text = dt.Rows[0]["LOID"].ToString();
        txtName.Text = dt.Rows[0]["NAME"].ToString();
        txtFeedCategory.Text = "Liquid Diet";
        txtCapacity.Text = dt.Rows[0]["CAPACITY"].ToString();
        txtEnergy.Text = dt.Rows[0]["ENERGY"].ToString();
        txtPortion.Text = dt.Rows[0]["PORTION"].ToString();
        chkActive.Checked = (dt.Rows[0]["ACTIVE"].ToString() == "1" ? true : false);
    }

    private void ClearSearch()
    {
        // Clear searh data
        txtNameSearch.Text = "";
        txtEnergyFrom.Text = "";
        txtEnergyTo.Text = "";
        txtCapacityFrom.Text = "";
        txtCapacityTo.Text = "";
    }


    private void ClearTabFormulaFeedItem()
    {
        lblStatus.Text = "";
        lbStatusFeedItem.Text = "";
        txtFormulaFeedLOID.Text = "";
        txtName.Text = "";
        txtCapacity.Text = "";
        txtEnergy.Text = "";
        txtPortion.Text = "";
        chkActive.Checked = true;
        gvFeedLDItem.DataSource = null;
        gvFeedLDItem.DataBind();
        CreateTmpFeedItem();
    }

    private void ClearTabFormulaDisease()
    {
        gvLDDisease.DataSource = null;
        gvLDDisease.DataBind();
        CreateTmpDisease();
    }

    private void ClearTabFormulaNutrient()
    {
        gvLDNutrient.DataSource = null;
        gvLDNutrient.DataBind();
    }

    private void ClearAllTabs()
    {
        ClearTabFormulaFeedItem();
        ClearTabFormulaDisease();
        ClearTabFormulaNutrient();
        txhSortDirGVFeedLDItem.Text = "";
        txhSortFieldGVFeedLDItem.Text = "";
        txhSortDirNutrient.Text = "";
        txhSortFieldNutrient.Text = "";
        TabContainer1.ActiveTabIndex = 0;
        txtPrevTabIndex.Text = "0";      
    }

    private bool InsertNewDataToTmpFeedItem(ArrayList arrData)
    {
        bool ret = true;
        DataTable dt = (DataTable)Session["FormulaFeedItem"];

        try
        {
            for (int i = 0; i < arrData.Count; i++)
            {
                VMaterialMasterData VMaterialMaster = (VMaterialMasterData)arrData[i];
                DataRow dr = dt.NewRow();
                dr["MMLOID"] = VMaterialMaster.LOID;
                dr["MMNAME"] = VMaterialMaster.MATERIALNAME;
                dt.Rows.Add(dr);
            }

            Session["FormulaFeedItem"] = dt;
        }
        catch(Exception ex)
        {
            ex.ToString();
            ret = false;
        }

        return ret;       
    }

    private bool InsertNewDataToTmpFormulaDisease(ArrayList arrData)
    {
        bool ret = true;
        FormulaFeedLDFlow fFlow = new FormulaFeedLDFlow();
        DataTable dt = (DataTable)Session["FormulaDisease"];

        try
        {
            for (int i = 0; i < arrData.Count; i++)
            {
                VDiseaseCategoryData VDiseaseCategory = (VDiseaseCategoryData)arrData[i];
                DataTable dtDC = fFlow.GetDiseaseCategoryByLOID(VDiseaseCategory.LOID.ToString());
                DataRow dr = dt.NewRow();
                dr["FDLOID"] = "";
                dr["DCLOID"] = VDiseaseCategory.LOID;
                dr["DCNAME"] = VDiseaseCategory.ABBNAME;
                dr["DCISHIGHVISIBLE"] = (dtDC.Rows[0]["ISHIGH"] != null ? dtDC.Rows[0]["ISHIGH"].ToString() : "");
                dr["DCISLOWVISIBLE"] = (dtDC.Rows[0]["ISLOW"] != null ? dtDC.Rows[0]["ISLOW"].ToString() : "");
                dr["DCISNONVISIBLE"] = (dtDC.Rows[0]["ISNON"] != null ? dtDC.Rows[0]["ISNON"].ToString() : "");
                dr["FDISHIGH"] = VDiseaseCategory.ISHIGH;
                dr["FDISLOW"] = VDiseaseCategory.ISLOW;
                dr["FDISNON"] = VDiseaseCategory.ISNON;
                dt.Rows.Add(dr);
            }

            Session["FormulaDisease"] = dt;
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
        if (Session["FormulaFeedItem"] != null)
        {
            DataTable dt = (DataTable)Session["FormulaFeedItem"];
            gvFeedLDItem.DataSource = dt;
            gvFeedLDItem.DataBind();
            zPop.Show();
        }
    }

    private void BindGVFormulaDisease()
    {
        if (Session["FormulaDisease"] != null)
        {
            DataTable dt = (DataTable)Session["FormulaDisease"];
            gvLDDisease.DataSource = dt;
            gvLDDisease.DataBind();
            zPop.Show();
        }
    }

    private void BindGVFormulaNutrient(DataTable dt)
    {
        gvLDNutrient.DataSource = dt;
        gvLDNutrient.DataBind();
        zPop.Show();
    }

    private void SetTempFormulaFeedItem(DataTable dt)
    {
        DataTable tmpFeedItem = (DataTable)Session["FormulaFeedItem"];
        FormulaFeedLDFlow fFlow = new FormulaFeedLDFlow();

        if (dt.Rows.Count > 0 && tmpFeedItem != null)
        {
            for (int i = 0; i < dt.Rows.Count; i++)
            {
                DataRow dr = tmpFeedItem.NewRow();
                dr["FFILOID"] = dt.Rows[i]["LOID"];
                dr["FORMULAFEEDLOID"] = dt.Rows[i]["FORMULAFEED"];
                dr["MMLOID"] = dt.Rows[i]["MATERIALMASTER"];
                dr["MMNAME"] = fFlow.GetMaterialMasterName(dt.Rows[i]["MATERIALMASTER"].ToString());
                dr["QTY"] = dt.Rows[i]["QTY"];
                dr["UNITLOID"] = dt.Rows[i]["UNIT"];
                dr["ENERGY"] = dt.Rows[i]["ENERGY"];

                tmpFeedItem.Rows.Add(dr);
            }
        }

        Session["FormulaFeedItem"] = tmpFeedItem;
    }

    private void SetTempFormulaDisease(DataTable dt)
    {
        DataTable tmpDisease = (DataTable)Session["FormulaDisease"];
        FormulaFeedLDFlow fFlow = new FormulaFeedLDFlow();

        if (dt.Rows.Count > 0 && tmpDisease != null)
        {
            for (int i = 0; i < dt.Rows.Count; i++)
            {
                DataTable dtDC = fFlow.GetDiseaseCategoryByLOID(dt.Rows[i]["DISEASECATEGORY"].ToString());

                DataRow dr = tmpDisease.NewRow();
                dr["FDLOID"] = dt.Rows[i]["LOID"];
                dr["DCLOID"] = dt.Rows[i]["DISEASECATEGORY"];
                dr["DCNAME"] = dt.Rows[i]["NAME"];
                dr["DCISHIGHVISIBLE"] = (dtDC.Rows[0]["ISHIGH"] != null ? dtDC.Rows[0]["ISHIGH"].ToString() : "");
                dr["DCISLOWVISIBLE"] = (dtDC.Rows[0]["ISLOW"] != null ? dtDC.Rows[0]["ISLOW"].ToString() : "");
                dr["DCISNONVISIBLE"] = (dtDC.Rows[0]["ISNON"] != null ? dtDC.Rows[0]["ISNON"].ToString() : "");
                dr["FDISHIGH"] = dt.Rows[i]["ISHIGH"];
                dr["FDISLOW"] = dt.Rows[i]["ISLOW"];
                dr["FDISNON"] = dt.Rows[i]["ISNON"];
                dr["FDREFTABLE"] = dt.Rows[i]["REFTABLE"];
                dr["FDREFLOID"] = dt.Rows[i]["REFLOID"];

                tmpDisease.Rows.Add(dr);
            }
        }

        Session["FormulaDisease"] = tmpDisease;
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
                double ffloid = Convert.ToDouble(txtFormulaFeedLOID.Text.Trim());

                if (txtPrevTabIndex.Text.Trim() == "0")
                {
                    doGetFormulaFeed(ffloid);
                    doGetFormulaFeedItem(ffloid);
                    doGetFormulaNutrient(ffloid);
                }
                else if (txtPrevTabIndex.Text.Trim() == "1")
                {
                    doGetFormulaFeed(ffloid);
                    doGetFormulaDisease(ffloid);
                    doGetFormulaNutrient(ffloid);
                }
                else if (txtPrevTabIndex.Text.Trim() == "2")
                {
                    doGetFormulaFeed(ffloid);
                    doGetFormulaNutrient(ffloid);
                }

                txtPrevTabIndex.Text = TabContainer1.ActiveTabIndex.ToString();
                lblStatus.Text = "";
                lbStatusFeedItem.Text = "";
                gvFeedLDItem.EditIndex = -1;
                gvLDDisease.EditIndex = -1;
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
        if (doSave(Convert.ToInt32(prevTabIndex)) == true)
            return true;
        else
            return false;
    }

    #endregion


    #region Working Method

    private void doDelete(int rowindex)
    {
        FormulaFeedLDFlow fFlow = new FormulaFeedLDFlow();
        string ffloid = gvMain.Rows[rowindex].Cells[0].Text.Trim();

        if (fFlow.DeleteByFormulaFeedLOID(ffloid))
        {
            gvMain.PageIndex = 0;
            doGetList();
            lbStatusMain.Text = "";
        }
        else
        {
            lbStatusMain.Text = fFlow.ErrorMessage;
            lbStatusMain.ForeColor = System.Drawing.Color.Red;
        }
    }

    private void doCopyFormulaFeed(string ffloid)
    {
        //ใส่ค่าใน control FormulaFeed
        FormulaFeedLDFlow fFlow = new FormulaFeedLDFlow();
        DataTable dt = fFlow.GetFormulaFeedData(Convert.ToDouble(ffloid));
        SetData(dt);
        txtFormulaFeedLOID.Text = "";       //clear FormulaFeedLOID เพื่อให้ข้อมูลอยู่ในสภาพ เหมือนการเพิ่มข้อมูลใหม่ ไม่ใช่การอัพเดท
    }

    private void doCopyFormulaFeedItem(string ffloid)
    {
        //Tab1 ใส่ค่าใน gvFeedLDItem ใหม่ 
        FormulaFeedLDFlow fFlow = new FormulaFeedLDFlow();
        DataTable dtFormulaFeedItem = fFlow.GetFormulaFeedItemList(ffloid.ToString(), "LOID");
        CreateTmpFeedItem();
        SetTempFormulaFeedItem(dtFormulaFeedItem);

        //clear FormulaFeedItemLOID เพื่อให้ข้อมูลอยู่ในสภาพ เหมือนการเพิ่มข้อมูลใหม่ ไม่ใช่การอัพเดท
        DataTable tmp = (DataTable)Session["FormulaFeedItem"];
        for (int i = 0; i < tmp.Rows.Count; i++)
        {
            tmp.Rows[i]["FFILOID"] = "";
        }
        Session["FormulaFeedItem"] = tmp;

        BindGVFeedItem();
        CalCulateAfterBind();
    }

    private void doCopyFormulaDisease(string ffloid)
    {
        //Tab2 ใส่ค่าใน gvLDDisease ใหม่
        FormulaFeedLDFlow fFlow = new FormulaFeedLDFlow();
        DataTable dtFormulaDisease = fFlow.GetFormulaDiseaseList(ffloid.ToString(), "FORMULAFEED", "LOID");
        CreateTmpDisease();
        SetTempFormulaDisease(dtFormulaDisease);

        //clear FormulaDiseaseLOID เพื่อให้ข้อมูลอยู่ในสภาพ เหมือนการเพิ่มข้อมูลใหม่ ไม่ใช่การอัพเดท
        DataTable tmp = (DataTable)Session["FormulaDisease"];
        for (int i = 0; i < tmp.Rows.Count; i++)
        {
            tmp.Rows[i]["FDLOID"] = "";
        }
        Session["FormulaDisease"] = tmp;
        
        BindGVFormulaDisease();
    }

    private void doGetList()
    {
        FormulaFeedLDFlow fFlow = new FormulaFeedLDFlow();

        imbReset.Visible = (txtNameSearch.Text.Trim() != "") || (txtEnergyFrom.Text.Trim() != "") || (txtEnergyTo.Text.Trim() != "") || (txtCapacityFrom.Text.Trim() != "") || (txtCapacityTo.Text.Trim() != "");

        string orderStr = "";
        if (txhSortField.Text.Trim() != "")
            orderStr = " " + txhSortField.Text + " " + txhSortDir.Text;

        double energyfrom = 0;
        double energyto = 0;
        double capacityfrom = 0;
        double capacityto = 0;

        if (txtEnergyFrom.Text.Trim() != "")
            energyfrom = Convert.ToDouble(txtEnergyFrom.Text.Trim());
        if (txtEnergyTo.Text.Trim() != "")
            energyto = Convert.ToDouble(txtEnergyTo.Text.Trim());
        if (txtCapacityFrom.Text.Trim() != "")
            capacityfrom = Convert.ToDouble(txtCapacityFrom.Text.Trim());
        if (txtCapacityTo.Text.Trim() != "")
            capacityto = Convert.ToDouble(txtCapacityTo.Text.Trim());

        gvMain.DataSource = fFlow.GetFormulaFeedLDList(txtNameSearch.Text.Trim(), energyfrom, energyto, capacityfrom, capacityto, orderStr);
        gvMain.DataBind();
        pcTop.Update();
        pcBot.Update();
    }

    private void doGetAllTab(double ffloid)
    {
        doGetFormulaFeed(ffloid);
        doGetFormulaFeedItem(ffloid);
        doGetFormulaDisease(ffloid);
        doGetFormulaNutrient(ffloid);
    }

    private void doGetFormulaFeed(double ffloid)
    {
        //ใส่ค่าใน control FormulaFeed
        FormulaFeedLDFlow fFlow = new FormulaFeedLDFlow();
        DataTable dt = fFlow.GetFormulaFeedData(ffloid);
        SetData(dt);
    }

    private void doGetFormulaFeedItem(double ffloid)
    {
        //ใส่ค่าใน gvFeedLDItem ใหม่
        FormulaFeedLDFlow fFlow = new FormulaFeedLDFlow();
        DataTable dtFormulaFeedItem = fFlow.GetFormulaFeedItemList(ffloid.ToString(), "LOID");
        CreateTmpFeedItem();
        SetTempFormulaFeedItem(dtFormulaFeedItem);
        BindGVFeedItem();
        CalCulateAfterBind();
    }

    private void doGetFormulaDisease(double ffloid)
    {
        //ใส่ค่าใน gvLDDisease ใหม่
        FormulaFeedLDFlow fFlow = new FormulaFeedLDFlow();
        DataTable dtFormulaDisease = fFlow.GetFormulaDiseaseList(ffloid.ToString(), "FORMULAFEED", "LOID");
        CreateTmpDisease();
        SetTempFormulaDisease(dtFormulaDisease);
        BindGVFormulaDisease();
    }

    private void doGetFormulaNutrient(double ffloid)
    {
        //ใส่ค่าใน gvLDNutrient ใหม่
        FormulaFeedLDFlow fFlow = new FormulaFeedLDFlow();

        string orderStr = "";
        if (txhSortFieldNutrient.Text.Trim() != "")
            orderStr = " " + txhSortFieldNutrient.Text + " " + txhSortDirNutrient.Text;

        if (orderStr.Trim() == "")
            orderStr = "LOID";

        DataTable dt = fFlow.GetFormulaNutrientList(ffloid.ToString(), orderStr);
        BindGVFormulaNutrient(dt);
    }

    private void CalCulateAfterBind()
    {
        for (int i = 0; i < gvFeedLDItem.Rows.Count; i++)
        {
            Calculate(i);
        }
    }

    private bool doSave(int tabIndex)
    {
        // verify required field
        lblStatus.Text = "";
        lbStatusFeedItem.Text = "";

        string error = VerifyData();
        if (error != "")
        {
            SetErrorStatus(lblStatus, error);
            return false;
        }

        if (tabIndex == 0)
        {
            if (VerifyGridView() == false)
            {
                return false;
            }
        }
        
        bool ret = true;

        if (tabIndex == 0)
            ret = doSaveTabFeedItem();
        else if (tabIndex == 1)
            ret = doSaveTabDisease();
        else if (tabIndex == 2)
            ret = doSaveTabNutrient();
               
        return ret;
    }

    private bool doSaveTabFeedItem()
    { 
        FormulaFeedLDFlow fFlow = new FormulaFeedLDFlow();
        bool ret = true;
        DataTable dtfiData = null;

        if (Session["FormulaFeedItem"] != null)
            dtfiData = (DataTable)Session["FormulaFeedItem"];

        // data correct go on saving...
        if (txtFormulaFeedLOID.Text.Trim() == "")
        {
            //  save new
            ret = fFlow.InsertData(GetData(), dtfiData, Appz.CurrentUser);
        }
        else
        {
            // save update
            FormulaFeedData ffData = GetData();
            ffData.LOID = Convert.ToDouble(txtFormulaFeedLOID.Text.Trim());
            ret = fFlow.UpdateData(ffData, dtfiData, Appz.CurrentUser);
        }

        if (!ret)
        {
            SetErrorStatus(lblStatus, fFlow.ErrorMessage);
        }
        else
        {
            SetStatus(lblStatus, "บันทึกข้อมูลเรียบร้อย");
            txtFormulaFeedLOID.Text = fFlow.LOID.ToString();
        }

        return ret;

    }

    private bool doSaveTabDisease()
    {
        FormulaFeedLDFlow fFlow = new FormulaFeedLDFlow();
        bool ret = true;
        DataTable dt = null;

        if (Session["FormulaDisease"] != null)
            dt = (DataTable)Session["FormulaDisease"];

        // data correct go on saving...
        if (txtFormulaFeedLOID.Text.Trim() == "")
        {
            //  save new
            ret = fFlow.InsertDataTabDisease(GetData(), dt, Appz.CurrentUser);
        }
        else
        {
            // save update
            FormulaFeedData ffData = GetData();
            ffData.LOID = Convert.ToDouble(txtFormulaFeedLOID.Text.Trim());
            ret = fFlow.UpdateDataTabDisease(ffData, dt, Appz.CurrentUser);
        }

        if (!ret)
        {
            SetErrorStatus(lblStatus, fFlow.ErrorMessage);
        }
        else
        {
            SetStatus(lblStatus, "บันทึกข้อมูลเรียบร้อย");
            txtFormulaFeedLOID.Text = fFlow.LOID.ToString();
        }

        return ret;
    }

    private bool doSaveTabNutrient()
    {
        FormulaFeedLDFlow fFlow = new FormulaFeedLDFlow();
        bool ret = true;
        DataTable dt = null;

        // data correct go on saving...
        if (txtFormulaFeedLOID.Text.Trim() == "")
        {
            //  save new
            ret = fFlow.InsertData(GetData(), dt, Appz.CurrentUser);
        }
        else
        {
            // save update
            FormulaFeedData ffData = GetData();
            ffData.LOID = Convert.ToDouble(txtFormulaFeedLOID.Text.Trim());
            ret = fFlow.UpdateData(ffData, dt, Appz.CurrentUser);
        }

        if (!ret)
        {
            SetErrorStatus(lblStatus, fFlow.ErrorMessage);
        }
        else
        {
            SetStatus(lblStatus, "บันทึกข้อมูลเรียบร้อย");
            txtFormulaFeedLOID.Text = fFlow.LOID.ToString();
        }

        return ret;
    }


    private string VerifyData()
    {
        string ret = "";

        if (txtName.Text.Trim() == "")
            ret = string.Format(DataResources.MSGEI001, "ชื่อสูตร");
        else if (txtCapacity.Text.Trim() == "")
            ret = string.Format(DataResources.MSGEI001, "ปริมาณ");
        else if (txtPortion.Text.Trim() == "")
            ret = string.Format(DataResources.MSGEI001, "Portion");

        return ret;
    }

    private bool VerifyGridView()
    {
        for (int i = 0; i < gvFeedLDItem.Rows.Count; i++)
        {
            TextBox txtQTYAdd = (TextBox)gvFeedLDItem.Rows[i].FindControl("txtQTYAdd");
            DropDownList cmbUnitAdd = (DropDownList)gvFeedLDItem.Rows[i].FindControl("cmbUnitAdd");

            if (txtQTYAdd.Text.Trim() == "")
            {
                SetErrorStatus(lbStatusFeedItem, string.Format(DataResources.MSGEI001, " จำนวนในรายการที่ " + Convert.ToInt32(i + 1).ToString()));
                return false;
            }
            else if (cmbUnitAdd.SelectedItem.Value == "0")
            {
                SetErrorStatus(lbStatusFeedItem, string.Format(DataResources.MSGEI002, "หน่วยนับในรายการที่ " + Convert.ToInt32(i + 1).ToString()));
                return false;
            }
        }
        return true;
    }

    protected void QTYCalculate(object sender, EventArgs e)
    {
        TextBox txtQTYAdd = (TextBox)sender;
        Calculate(Convert.ToInt32(txtQTYAdd.ToolTip));
    }


    protected void UnitCalculate(object sender, EventArgs e)
    {
        DropDownList cmbUnitAdd = (DropDownList)sender;
        Calculate(Convert.ToInt32(cmbUnitAdd.ToolTip));
    }


    private void Calculate(int rowindex)
    {
        //double result = 0;
        TextBox txtQTYAdd = (TextBox)gvFeedLDItem.Rows[rowindex].FindControl("txtQTYAdd");
        DropDownList cmbUnitAdd = (DropDownList)gvFeedLDItem.Rows[rowindex].FindControl("cmbUnitAdd");
        string material_master_loid = gvFeedLDItem.Rows[rowindex].Cells[11].Text.Trim();

        if (txtQTYAdd != null && cmbUnitAdd != null)
        {
            if (txtQTYAdd.Text.Trim() != "")
            {
                try
                {
                    doCalculate(rowindex, Convert.ToDouble(txtQTYAdd.Text.Trim()), material_master_loid, cmbUnitAdd.SelectedItem.Value);
                }
                catch (Exception ex)
                {
                    SetErrorStatus(lbStatusFeedItem, ex.Message);
                }
            }
            else
            {
                Label lblEnergy = (Label)gvFeedLDItem.Rows[rowindex].FindControl("lblEnergy");
                Label lblCARBOHYDRATE = (Label)gvFeedLDItem.Rows[rowindex].FindControl("lblCARBOHYDRATE");
                Label lblPROTEIN = (Label)gvFeedLDItem.Rows[rowindex].FindControl("lblPROTEIN");
                Label lblFAT = (Label)gvFeedLDItem.Rows[rowindex].FindControl("lblFAT");
                Label lblSODIUM = (Label)gvFeedLDItem.Rows[rowindex].FindControl("lblSODIUM");
                Label lblPhosphorus = (Label)gvFeedLDItem.Rows[rowindex].FindControl("lblPhosphorus");
                Label lblPotassium = (Label)gvFeedLDItem.Rows[rowindex].FindControl("lblPotassium");
                Label lblCalcium = (Label)gvFeedLDItem.Rows[rowindex].FindControl("lblCalcium");
                lblEnergy.Text = "";
                lblCARBOHYDRATE.Text = "";
                lblPROTEIN.Text = "";
                lblFAT.Text = "";
                lblSODIUM.Text = "";
                lblPhosphorus.Text = "";
                lblPotassium.Text = "";
                lblCalcium.Text = "";
            }

            SetTmpFeedItem(material_master_loid, rowindex);
            UpdateTotalEnergy();
        }

        zPop.Show();
    }

    private void doCalculate(int rowindex, double QTY, string material_master_loid, string unitloid)
    {
        FormulaFeedLDFlow fFlow = new FormulaFeedLDFlow();
        DataTable dt = fFlow.GetFormulaFeedItemNutrient(material_master_loid, unitloid);

        Label lblEnergy = (Label)gvFeedLDItem.Rows[rowindex].FindControl("lblEnergy");
        Label lblCARBOHYDRATE = (Label)gvFeedLDItem.Rows[rowindex].FindControl("lblCARBOHYDRATE");
        Label lblPROTEIN = (Label)gvFeedLDItem.Rows[rowindex].FindControl("lblPROTEIN");
        Label lblFAT = (Label)gvFeedLDItem.Rows[rowindex].FindControl("lblFAT");
        Label lblSODIUM = (Label)gvFeedLDItem.Rows[rowindex].FindControl("lblSODIUM");
        Label lblPhosphorus = (Label)gvFeedLDItem.Rows[rowindex].FindControl("lblPhosphorus");
        Label lblPotassium = (Label)gvFeedLDItem.Rows[rowindex].FindControl("lblPotassium");
        Label lblCalcium = (Label)gvFeedLDItem.Rows[rowindex].FindControl("lblCalcium");

        if (dt.Rows.Count > 0)
        {
            double energy = QTY * Convert.ToDouble(dt.Rows[0]["ENERGY"]);
            double carbohydrate = QTY * Convert.ToDouble(dt.Rows[0]["CARBOHYDRATE"]);
            double protein = QTY * Convert.ToDouble(dt.Rows[0]["PROTEIN"]);
            double fat = QTY * Convert.ToDouble(dt.Rows[0]["FAT"]);
            double sodium = QTY * Convert.ToDouble(dt.Rows[0]["SODIUM"]);
            double phosphorus = QTY * Convert.ToDouble(dt.Rows[0]["PHOSPHORUS"]);
            double potassium = QTY * Convert.ToDouble(dt.Rows[0]["POTASSIUM"]);
            double calcium = QTY * Convert.ToDouble(dt.Rows[0]["CALCIUM"]);

            lblEnergy.Text = energy.ToString("#,##0.####");
            lblCARBOHYDRATE.Text = carbohydrate.ToString("#,##0.####");
            lblPROTEIN.Text = protein.ToString("#,##0.####");
            lblFAT.Text = fat.ToString("#,##0.####");
            lblSODIUM.Text = sodium.ToString("#,##0.####");
            lblPhosphorus.Text = phosphorus.ToString("#,##0.####");
            lblPotassium.Text = potassium.ToString("#,##0.####");
            lblCalcium.Text = calcium.ToString("#,##0.####");
        }
        else
        {
            lblEnergy.Text = "";
            lblCARBOHYDRATE.Text = "";
            lblPROTEIN.Text = "";
            lblFAT.Text = "";
            lblSODIUM.Text = "";
            lblPhosphorus.Text = "";
            lblPotassium.Text = "";
            lblCalcium.Text = "";
        }
    }

    private void SetTmpFeedItem(string material_master_loid, int rowindex)
    {
        TextBox txtQTYAdd = (TextBox)gvFeedLDItem.Rows[rowindex].FindControl("txtQTYAdd");
        DropDownList cmbUnitAdd = (DropDownList)gvFeedLDItem.Rows[rowindex].FindControl("cmbUnitAdd");
        Label lblEnergy = (Label)gvFeedLDItem.Rows[rowindex].FindControl("lblEnergy");
        Label lblCARBOHYDRATE = (Label)gvFeedLDItem.Rows[rowindex].FindControl("lblCARBOHYDRATE");
        Label lblPROTEIN = (Label)gvFeedLDItem.Rows[rowindex].FindControl("lblPROTEIN");
        Label lblFAT = (Label)gvFeedLDItem.Rows[rowindex].FindControl("lblFAT");
        Label lblSODIUM = (Label)gvFeedLDItem.Rows[rowindex].FindControl("lblSODIUM");
        Label lblPhosphorus = (Label)gvFeedLDItem.Rows[rowindex].FindControl("lblPhosphorus");
        Label lblPotassium = (Label)gvFeedLDItem.Rows[rowindex].FindControl("lblPotassium");
        Label lblCalcium = (Label)gvFeedLDItem.Rows[rowindex].FindControl("lblCalcium");

        DataTable dt = (DataTable)Session["FormulaFeedItem"];

        if (dt != null)
        {
            for (int i = 0; i < dt.Rows.Count; i++)
            {
                if (dt.Rows[i]["MMLOID"].ToString().Trim() == material_master_loid)
                {
                    dt.Rows[i]["QTY"] = txtQTYAdd.Text.Trim();
                    dt.Rows[i]["UNITLOID"] = cmbUnitAdd.SelectedItem.Value;
                    dt.Rows[i]["UNITNAME"] = cmbUnitAdd.SelectedItem.Text.Trim();
                    dt.Rows[i]["ENERGY"] = lblEnergy.Text.Trim();
                    dt.Rows[i]["CARBOHYDRATE"] = lblCARBOHYDRATE.Text.Trim();
                    dt.Rows[i]["PROTEIN"] = lblPROTEIN.Text.Trim();
                    dt.Rows[i]["FAT"] = lblFAT.Text.Trim();
                    dt.Rows[i]["SODIUM"] = lblSODIUM.Text.Trim();
                    dt.Rows[i]["PHOSPHORUS"] = lblPhosphorus.Text.Trim();
                    dt.Rows[i]["POTASSIUM"] = lblPotassium.Text.Trim();
                    dt.Rows[i]["CALCIUM"] = lblCalcium.Text.Trim();
                }
            }
        }

        Session["FormulaFeedItem"] = dt;
    }

    private void UpdateTotalEnergy()
    {
        double total = 0;
        for (int i = 0; i < gvFeedLDItem.Rows.Count; i++)
        {
            Label lblEnergy = (Label)gvFeedLDItem.Rows[i].FindControl("lblEnergy");
            if (lblEnergy != null)
            {
                if (lblEnergy.Text.Trim() != "")
                {
                    total += Convert.ToDouble(lblEnergy.Text.Trim());
                }
            }
        }

        txtEnergy.Text = total.ToString("#,##0.######");
    }

    protected void UpdateTmpDisease(object sender, EventArgs e)
    {
        RadioButton radtmp = (RadioButton)sender;
        int rowindex = Convert.ToInt32(radtmp.ToolTip);
        string dcloid = gvLDDisease.Rows[rowindex].Cells[7].Text.Trim();
        string ishigh = "";
        string islow = "";
        string isnon = "";

        RadioButton radISHIGH = (RadioButton)gvLDDisease.Rows[rowindex].FindControl("radISHIGH");
        RadioButton radISLOW = (RadioButton)gvLDDisease.Rows[rowindex].FindControl("radISLOW");
        RadioButton radISNON = (RadioButton)gvLDDisease.Rows[rowindex].FindControl("radISNON");
        if (radISHIGH != null)
            ishigh = (radISHIGH.Checked ? "Y" : "N");
        if (radISLOW != null)
            islow = (radISLOW.Checked ? "Y" : "N");
        if (radISNON != null)
            isnon = (radISNON.Checked ? "Y" : "N");

        DataTable dt = (DataTable)Session["FormulaDisease"];
        if (dt != null)
        {
            for (int i = 0; i < dt.Rows.Count; i++)
            {
                if (dt.Rows[i]["DCLOID"].ToString().Trim() == dcloid)
                {
                    dt.Rows[i]["FDISHIGH"] = ishigh;
                    dt.Rows[i]["FDISLOW"] = islow;
                    dt.Rows[i]["FDISNON"] = isnon;
                }
            }
        }

        Session["FormulaDisease"] = dt;
        zPop.Show();
    }

    #endregion


    
}
