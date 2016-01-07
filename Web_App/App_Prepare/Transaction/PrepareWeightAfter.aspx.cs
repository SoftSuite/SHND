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
using SHND.Global;
using SHND.Flow.Common;
using SHND.Data.Common.Utilities;
using SHND.Data.Views;

/// <summary> 
/// PrepareWeightAfter Page Class
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
///    หน้าการทำงานค้นหาข้อมูลน้ำหนักหลังเตรียม (PrepareWeightAfter)
/// Changes:
///    1.0 - สร้าง
/// -------------------------------------------------------------------------
/// =========================================================================
/// </summary>
/// 

public partial class App_Prepare_Transaction_PrepareWeightAfter : System.Web.UI.Page
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
        Appz.BuildCombo(cmbMaterialClassSearch, "MATERIALCLASS", "NAME", "LOID", "MASTERTYPE = 'FO' AND ACTIVE = '1'", "NAME", "ทั้งหมด", "0", false);
        Appz.BuildCombo(cmbMaterialClass, "MATERIALCLASS", "NAME", "LOID", "MASTERTYPE = 'FO' AND ACTIVE = '1'", "NAME", "เลือก", "0", false);
        pcTop.SetMainGridView(gvMain);
        pcBot.SetMainGridView(gvMain);
    }

    protected void ctlMaterialPrepareWeightAfterPopup_SelectedIndexChanged(object sender, EventArgs e, ArrayList arrData)
    {
        if (InsertNewDataToTmpMaterialItem(arrData))
        {
            BindGVMaterialItem();
            CheckMaterialClassDisable();
        }
    }

    protected void ctlMaterialPrepareWeightAfterPopup_Cancel(object sender, EventArgs e)
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
            this.ctlMaterialPrepareWeightAfterPopup.Show(cmbMaterialClass.SelectedItem.Value, getMaterialList());
        }
        else
        {
            SetErrorStatus(lblStatus, string.Format(DataResources.MSGEI002, "หมวดอาหารก่อนเพิ่มรายการ"));
            zPop.Show();
        }
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
                    if (mmloid == dt.Rows[i]["MMLOID"].ToString().Trim())
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
            doGetPrepareWeightAfter(txtCode.Text.Trim());
            doGetPrepareWeightAfterItemList(txtCode.Text.Trim());
            lblStatus.Text = "";
        }
        zPop.Show();
    }

    protected void tbSaveClick(object sender, EventArgs e)
    {
        if (doSave() == true)
        {
            doGetPrepareWeightAfter(txtCode.Text.Trim());
            doGetPrepareWeightAfterItemList(txtCode.Text.Trim());
        }

        zPop.Show();
    }

    protected void lnkName_Click(object sender, EventArgs e)
    {
        string code = ((LinkButton)sender).Text.Trim();
        doGetPrepareWeightAfter(code);
        doGetPrepareWeightAfterItemList(code);
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
                doGetPrepareWeightAfter(txtCode.Text.Trim());
                doGetPrepareWeightAfterItemList(txtCode.Text.Trim());
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

    protected void gvMain_RowDataBound(object sender, GridViewRowEventArgs e)
    {
        if (e.Row.RowType == DataControlRowType.DataRow)
        {
            if (e.Row.Cells[6].Text.Trim() == "FN")
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
            TextBox txtSTDWEIGHTBEFORE = (TextBox)e.Row.FindControl("txtSTDWEIGHTBEFORE");
            if (txtSTDWEIGHTBEFORE != null)
            {
                ControlUtil.SetDblTextBox(txtSTDWEIGHTBEFORE);
                txtSTDWEIGHTBEFORE.Text = GetStdWeight("BEFORE").ToString();
            }

            TextBox txtUSEWEIGHTBEFORE = (TextBox)e.Row.FindControl("txtUSEWEIGHTBEFORE");
            if (txtUSEWEIGHTBEFORE != null)
            {
                ControlUtil.SetDblTextBox(txtUSEWEIGHTBEFORE);
            }

            TextBox txtSTDWEIGHTAFTER = (TextBox)e.Row.FindControl("txtSTDWEIGHTAFTER");
            if (txtSTDWEIGHTAFTER != null)
            {
                ControlUtil.SetDblTextBox(txtSTDWEIGHTAFTER);
                txtSTDWEIGHTAFTER.Text = GetStdWeight("AFTER").ToString();
            }

            TextBox txtUSEWEIGHTAFTER = (TextBox)e.Row.FindControl("txtUSEWEIGHTAFTER");
            if (txtUSEWEIGHTAFTER != null)
            {
                ControlUtil.SetDblTextBox(txtUSEWEIGHTAFTER);
            }

            TextBox txtDIFFWEIGHT = (TextBox)e.Row.FindControl("txtDIFFWEIGHT");
            if (txtDIFFWEIGHT != null)
            {
                ControlUtil.SetDblTextBox(txtDIFFWEIGHT);
                if (txtSTDWEIGHTAFTER != null && txtUSEWEIGHTAFTER != null && txtUSEWEIGHTAFTER.Text.Trim() != "")
                {
                    double diff = Convert.ToDouble(txtSTDWEIGHTAFTER.Text.Trim()) - Convert.ToDouble(txtUSEWEIGHTAFTER.Text.Trim());
                    txtDIFFWEIGHT.Text = diff.ToString();
                }
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

    private ArrayList GetGVMaterialItemChecked()
    {
        ArrayList arrChk = new ArrayList();
        for (int i = 0; i < gvMaterialItem.Rows.Count; i++)
        {
            if (gvMaterialItem.Rows[i].Cells[1].FindControl("chkSelect") != null)
            {
                if (((CheckBox)gvMaterialItem.Rows[i].Cells[1].FindControl("chkSelect")).Checked)
                    arrChk.Add(gvMaterialItem.Rows[i].Cells[12].Text.Trim());
            }
        }

        return arrChk;
    }


    private void CreateTmpMaterialItem()
    {
        DataTable dt = new DataTable();
        DataColumn dcPILOID = new DataColumn("PILOID");
        DataColumn dcMMLOID = new DataColumn("MMLOID");
        DataColumn dcMATERIALCODE = new DataColumn("MATERIALCODE");
        DataColumn dcMATERIALNAME = new DataColumn("MATERIALNAME");
        DataColumn dcUNITLOID = new DataColumn("UNITLOID");
        DataColumn dcUNITNAME = new DataColumn("UNITNAME");
        DataColumn dcSTDWEIGHTBEFORE = new DataColumn("STDWEIGHTBEFORE");
        DataColumn dcUSEWEIGHTBEFORE = new DataColumn("USEWEIGHTBEFORE");
        DataColumn dcSTDWEIGHTAFTER = new DataColumn("STDWEIGHTAFTER");
        DataColumn dcUSEWEIGHTAFTER = new DataColumn("USEWEIGHTAFTER");
        DataColumn dcDIFFWEIGHT = new DataColumn("DIFFWEIGHT");

        dt.Columns.Add(dcPILOID);
        dt.Columns.Add(dcMMLOID);
        dt.Columns.Add(dcMATERIALCODE);
        dt.Columns.Add(dcMATERIALNAME);
        dt.Columns.Add(dcUNITLOID);
        dt.Columns.Add(dcUNITNAME);
        dt.Columns.Add(dcSTDWEIGHTBEFORE);
        dt.Columns.Add(dcUSEWEIGHTBEFORE);
        dt.Columns.Add(dcSTDWEIGHTAFTER);
        dt.Columns.Add(dcUSEWEIGHTAFTER);
        dt.Columns.Add(dcDIFFWEIGHT);

        Session["MaterialItem"] = dt;
    }

    private void CheckMaterialClassDisable()
    {
        if (gvMaterialItem.Rows.Count > 0)
            cmbMaterialClass.Enabled = false;
        else
            cmbMaterialClass.Enabled = true;
    }

    private void CheckStatus()
    {
        PrepareWeightAfterFlow pFlow = new PrepareWeightAfterFlow();
        DataTable dt = pFlow.GetPrepareWeightAfter(txtCode.Text.Trim());
        if (dt.Rows.Count > 0)
        {
            if (dt.Rows[0]["STATUS"].ToString() == "FN")
            {
                DisableControls();
            }
        }
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

    private void ClearAllData()
    {
        tbPrint.Enabled = false;
        txtCode.Text = "";
        txtPrepareDate.Text = "";
        txtStatus.Text = "";
        cmbMaterialClass.SelectedIndex = -1;
        cmbMaterialClass.Enabled = true;
        txtMaterialClass.Text = "";
        gvMaterialItem.DataSource = null;
        gvMaterialItem.DataBind();
        lblStatus.Text = "";
        CreateTmpMaterialItem();
    }

    private void DisableControls()
    {
        tbSave.Enabled = false;
        tbCancel.Enabled = false;
        tbConfirm.Enabled = false;
        cmbMaterialClass.Enabled = false;
        tbAddItem.Enabled = false;
        tbDeleteItem.Enabled = false;

        for (int i = 0; i < gvMaterialItem.Rows.Count; i++)
        {
            TextBox txtUSEWEIGHTBEFORE = (TextBox)gvMaterialItem.Rows[i].FindControl("txtUSEWEIGHTBEFORE");
            if (txtUSEWEIGHTBEFORE != null)
            {
                txtUSEWEIGHTBEFORE.ReadOnly = true;
                txtUSEWEIGHTBEFORE.CssClass = "zTextboxR-View";
            }

            TextBox txtUSEWEIGHTAFTER = (TextBox)gvMaterialItem.Rows[i].FindControl("txtUSEWEIGHTAFTER");
            if (txtUSEWEIGHTAFTER != null)
            {
                txtUSEWEIGHTAFTER.ReadOnly = true;
                txtUSEWEIGHTAFTER.CssClass = "zTextboxR-View";
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
        cmbMaterialClass.Enabled = true;
        tbAddItem.Enabled = true;
        tbDeleteItem.Enabled = true;

        for (int i = 0; i < gvMaterialItem.Rows.Count; i++)
        {
            TextBox txtUSEWEIGHBEFORE = (TextBox)gvMaterialItem.Rows[i].FindControl("txtUSEWEIGHBEFORE");
            if (txtUSEWEIGHBEFORE != null)
            {
                txtUSEWEIGHBEFORE.ReadOnly = false;
                txtUSEWEIGHBEFORE.CssClass = "zTextboxR";
            }

            TextBox txtUSEWEIGHTAFTER = (TextBox)gvMaterialItem.Rows[i].FindControl("txtUSEWEIGHTAFTER");
            if (txtUSEWEIGHTAFTER != null)
            {
                txtUSEWEIGHTAFTER.ReadOnly = false;
                txtUSEWEIGHTAFTER.CssClass = "zTextboxR";
            }

            CheckBox chkSelect = (CheckBox)gvMaterialItem.Rows[i].FindControl("chkSelect");
            if (chkSelect != null)
            {
                chkSelect.Enabled = true;
            }
        }
    }

    private void SetPrepareWeightAfterData(DataTable dt)
    {
        if (dt.Rows.Count > 0)
        {
            DateTime preparedate = Convert.ToDateTime(dt.Rows[0]["PREPAREDATE"]);
            txtPrepareDate.Text = preparedate.ToString("dd/MM/yyyy");

            if (dt.Rows[0]["STATUS"].ToString() == "WA")
                txtStatus.Text = "กำลังดำเนินการ";
            else if (dt.Rows[0]["STATUS"].ToString() == "FN")
                txtStatus.Text = "ยืนยัน";

            cmbMaterialClass.SelectedIndex = cmbMaterialClass.Items.IndexOf(cmbMaterialClass.Items.FindByValue(dt.Rows[0]["MATERIALCLASS"].ToString())); 
        } 
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
                dr["USEWEIGHTBEFORE"] = dt.Rows[i]["USEWEIGHTBEFORE"];
                dr["USEWEIGHTAFTER"] = dt.Rows[i]["USEWEIGHTAFTER"];

                dtTmpMaterialItem.Rows.Add(dr);
            }
        }

        Session["MaterialItem"] = dtTmpMaterialItem;
    }

    #endregion

    #region Working Method

    private void doGetList()
    {
        PrepareWeightAfterFlow pFlow = new PrepareWeightAfterFlow();
        string datefrom = "";
        string dateto = "";

        string orderStr = "";
        if (txhSortField.Text.Trim() != "")
            orderStr = " " + txhSortField.Text + " " + txhSortDir.Text;

        if (cldPrepareDateFrom.DateValue.Year != 1)
            datefrom = cldPrepareDateFrom.DateValue.Year.ToString() + cldPrepareDateFrom.DateValue.ToString("/MM/dd");
        if (cldPrepareDateTo.DateValue.Year != 1)
            dateto = cldPrepareDateTo.DateValue.Year.ToString() + cldPrepareDateTo.DateValue.ToString("/MM/dd");

        gvMain.DataSource = pFlow.GetPrepareWeightAfterList(txtCodeFrom.Text.Trim(), txtCodeTo.Text.Trim(), datefrom, dateto, cmbMaterialClassSearch.SelectedItem.Value, cmbStatusFrom.SelectedItem.Value, cmbStatusTo.SelectedItem.Value, orderStr);
        gvMain.DataBind();
        pcTop.Update();
        pcBot.Update();
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

    protected void CalculateDiff(object sender, EventArgs e)
    {
        TextBox txtUSEWEIGHTAFTER = (TextBox)sender;
        Calculate(Convert.ToInt32(txtUSEWEIGHTAFTER.ToolTip));
        zPop.Show();
    }

    private void Calculate(int rowindex)
    {
        TextBox txtSTDWEIGHTAFTER = (TextBox)gvMaterialItem.Rows[rowindex].FindControl("txtSTDWEIGHTAFTER");
        TextBox txtUSEWEIGHTAFTER = (TextBox)gvMaterialItem.Rows[rowindex].FindControl("txtUSEWEIGHTAFTER");
        TextBox txtDIFFWEIGHT = (TextBox)gvMaterialItem.Rows[rowindex].FindControl("txtDIFFWEIGHT");
        string material_master_loid = gvMaterialItem.Rows[rowindex].Cells[12].Text.Trim();

        if (txtSTDWEIGHTAFTER != null && txtUSEWEIGHTAFTER != null && txtUSEWEIGHTAFTER.Text.Trim() != "" && txtDIFFWEIGHT != null)
        {
            double diff = Convert.ToDouble(txtSTDWEIGHTAFTER.Text.Trim()) - Convert.ToDouble(txtUSEWEIGHTAFTER.Text.Trim());
            txtDIFFWEIGHT.Text = diff.ToString();

            UpdateTmpMaterialItem(txtUSEWEIGHTAFTER.Text.Trim(), diff, material_master_loid);
        }
    }

    private void UpdateTmpMaterialItem(string user_weight_after, double diff, string material_master_loid)
    {
        DataTable dt = (DataTable)Session["MaterialItem"];

        if (dt != null)
        {
            for (int i = 0; i < dt.Rows.Count; i++)
            {
                if (dt.Rows[i]["MMLOID"].ToString().Trim() == material_master_loid)
                {
                    dt.Rows[i]["USEWEIGHTAFTER"] = user_weight_after;
                    dt.Rows[i]["DIFFWEIGHT"] = diff.ToString();
                }
            }
        }

        Session["MaterialItem"] = dt;
    }

    protected void UpdateUseWeightBeforeToTmp(object sender, EventArgs e)
    {
        TextBox txtUSEWEIGHTBEFORE = (TextBox)sender;
        int rowindex = Convert.ToInt32(txtUSEWEIGHTBEFORE.ToolTip);
        string material_master_loid = gvMaterialItem.Rows[rowindex].Cells[12].Text.Trim();

        DataTable dt = (DataTable)Session["MaterialItem"];

        if (dt != null)
        {
            for (int i = 0; i < dt.Rows.Count; i++)
            {
                if (dt.Rows[i]["MMLOID"].ToString().Trim() == material_master_loid)
                {
                    dt.Rows[i]["USEWEIGHTBEFORE"] = txtUSEWEIGHTBEFORE.Text.Trim();
                }
            }
        }

        Session["MaterialItem"] = dt;
        zPop.Show();
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

        if (VerifyExist() == true)
        {
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

        if (cmbMaterialClass.SelectedItem.Value == "0")
            ret = string.Format(DataResources.MSGEI002, "หมวดอาหาร");

        return ret;
    }

    private bool VerifyExist()
    {
        PrepareWeightAfterFlow pFlow = new PrepareWeightAfterFlow();
        string date = "";
        bool ret = true;

        if (cmbMaterialClass.SelectedItem.Value != txtMaterialClass.Text.Trim())
        {
            if (txtCode.Text.Trim() == "")
                date = DateTime.Now.Year.ToString() + DateTime.Now.ToString("/MM/dd");
            else
            {
                DateTime tmp = Convert.ToDateTime(txtPrepareDate.Text.Trim());
                date = tmp.Year.ToString() + tmp.ToString("/MM/dd");
            }

            ret = pFlow.CheckExist(cmbMaterialClass.SelectedItem.Value, date);

            if (ret == true)
            {
                if (txtCode.Text.Trim() == "")
                    SetErrorStatus(lblStatus, "ข้อมูลน้ำหนักหลังเตรียม หมวดอาหาร : " + cmbMaterialClass.SelectedItem.Text.Trim() + " ในวันที่ " + DateTime.Now.ToString("dd/MM/yyyy") + " มีอยู่ในระบบแล้ว");
                else
                    SetErrorStatus(lblStatus, "ข้อมูลน้ำหนักหลังเตรียม หมวดอาหาร : " + cmbMaterialClass.SelectedItem.Text.Trim() + " ในวันที่ " + txtPrepareDate.Text.Trim() + " มีอยู่ในระบบแล้ว");
            }
        }
        else
        {
            ret = false;
        }

        return ret;
    }

    private bool VerifyGridView()
    {
        for (int i = 0; i < gvMaterialItem.Rows.Count; i++)
        {
            TextBox txtUSEWEIGHTBEFORE = (TextBox)gvMaterialItem.Rows[i].FindControl("txtUSEWEIGHTBEFORE");

            if (txtUSEWEIGHTBEFORE.Text.Trim() == "")
            {
                SetErrorStatus(lblStatus, string.Format(DataResources.MSGEI001, "น้ำหนักก่อนเตรียมตามการใช้จริง ในรายการที่ " + Convert.ToInt32(i + 1).ToString()));
                return false;
            }

            TextBox txtUSEWEIGHTAFTER = (TextBox)gvMaterialItem.Rows[i].FindControl("txtUSEWEIGHTAFTER");

            if (txtUSEWEIGHTAFTER.Text.Trim() == "")
            {
                SetErrorStatus(lblStatus, string.Format(DataResources.MSGEI001, "น้ำหนักหลังเตรียมตามการใช้จริง ในรายการที่ " + Convert.ToInt32(i + 1).ToString()));
                return false;
            }
        }
        return true;
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
                    if (dt.Rows[i]["MMLOID"].ToString().Trim() == gvMaterialItem.Rows[j].Cells[12].Text.Trim())
                    {
                        TextBox txtSTDWEIGHTBEFORE = (TextBox)gvMaterialItem.Rows[j].FindControl("txtSTDWEIGHTBEFORE");
                        if (txtSTDWEIGHTBEFORE != null)
                            dt.Rows[i]["STDWEIGHTBEFORE"] = txtSTDWEIGHTBEFORE.Text.Trim();

                        TextBox txtUSEWEIGHTBEFORE = (TextBox)gvMaterialItem.Rows[j].FindControl("txtUSEWEIGHTBEFORE");
                        if (txtUSEWEIGHTBEFORE != null)
                            dt.Rows[i]["USEWEIGHTBEFORE"] = txtUSEWEIGHTBEFORE.Text.Trim();

                        TextBox txtSTDWEIGHTAFTER = (TextBox)gvMaterialItem.Rows[j].FindControl("txtSTDWEIGHTAFTER");
                        if (txtSTDWEIGHTAFTER != null)
                            dt.Rows[i]["STDWEIGHTAFTER"] = txtSTDWEIGHTAFTER.Text.Trim();

                        TextBox txtUSEWEIGHTAFTER = (TextBox)gvMaterialItem.Rows[j].FindControl("txtUSEWEIGHTAFTER");
                        if (txtSTDWEIGHTAFTER != null)
                            dt.Rows[i]["USEWEIGHTAFTER"] = txtUSEWEIGHTAFTER.Text.Trim();

                        TextBox txtDIFFWEIGHT = (TextBox)gvMaterialItem.Rows[j].FindControl("txtDIFFWEIGHT");
                        if (txtSTDWEIGHTAFTER != null)
                            dt.Rows[i]["DIFFWEIGHT"] = txtDIFFWEIGHT.Text.Trim();
                    }
                }
            }
        }

        Session["MaterialItem"] = dt;
    }

    private bool doSavePrepareReturn()
    {
        PrepareWeightAfterFlow pFlow = new PrepareWeightAfterFlow();
        bool ret = true;
        DataTable dtPrepareItemData = null;

        if (Session["MaterialItem"] != null)
            dtPrepareItemData = (DataTable)Session["MaterialItem"];

        // data correct go on saving...
        if (txtCode.Text.Trim() == "")
        {
            //  save new
            ret = pFlow.InsertData(cmbMaterialClass.SelectedItem.Value, dtPrepareItemData, Appz.CurrentUser);
        }
        else
        {
            // save update
            ret = pFlow.UpdateData(txtCode.Text.Trim(), cmbMaterialClass.SelectedItem.Value, dtPrepareItemData, Appz.CurrentUser);
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

    private void doGetPrepareWeightAfter(string code)
    {
        PrepareWeightAfterFlow pFlow = new PrepareWeightAfterFlow();
        DataTable dt = pFlow.GetPrepareWeightAfter(code);
        txtCode.Text = code;
        SetPrepareWeightAfterData(dt);
        txtMaterialClass.Text = cmbMaterialClass.SelectedItem.Value;
        tbPrint.Enabled = true;
        tbPrint.ClientClick = Appz.OpenReportScript(Constant.Reports.PrepareWeightAfterReport, "paramfield1=CODE&paramvalue1=" + code, false);
    }

    private void doGetPrepareWeightAfterItemList(string code)
    {
        PrepareWeightAfterFlow fFlow = new PrepareWeightAfterFlow();
        DataTable dt = fFlow.GetPrepareWeightAfterItemList(code);
        CreateTmpMaterialItem();
        SetTmpMaterialItem(dt);
        BindGVMaterialItem();
    }

    private bool doConfirm(string code)
    {
        PrepareWeightAfterFlow pFlow = new PrepareWeightAfterFlow();

        if (pFlow.UpdatePrepareWeightAfterStatus(code, Appz.CurrentUser) == true)
        {
            SetStatus(lblStatus, "ยืนยันรายละเอียดบันทึกน้ำหนักหลังเตรียมเรียบร้อย");
            return true;
        }
        else
        {
            SetErrorStatus(lblStatus, pFlow.ErrorMessage);
            return false;
        }
    }

    private void doDelete()
    {
        PrepareWeightAfterFlow pFlow = new PrepareWeightAfterFlow();
        if (pFlow.DeletePrepareWeightAfterByLOID(GetChecked()) == true)
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

    private double GetStdWeight(string type)
    {
        PrepareWeightAfterFlow pFlow = new PrepareWeightAfterFlow();
        string date = DateTime.Now.Year.ToString() + DateTime.Now.ToString("MMdd");
        return pFlow.GetStdWeight(date, cmbMaterialClass.SelectedItem.Value, type);
    }

    #endregion
    
}
