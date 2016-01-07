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
using SHND.Data;
using SHND.Global;
using SHND.Flow.Common;
using SHND.Data.Common.Utilities;
using SHND.Data.Views;
using SHND.Data.Tables;

/// <summary>
/// MedFeedCharge Page Class
/// Version 1.0
/// =========================================================================
/// Create by: Nang
/// Create Date: 7 May 2009
/// -------------------------------------------------------------------------
/// Modify By: -
/// Modify From: -
/// Modify Date: -
/// -------------------------------------------------------------------------
/// Remark: -
/// Description:
///    หน้ากาารทำงานข้อมูลใบแจ้งค่าอาหารทางแการแพทย์ MedFeedCharge 
/// Changes:
///    1.0 - สร้าง
/// -------------------------------------------------------------------------
/// =========================================================================
/// </summary>
/// 

public partial class App_Prepare_Transaction_MedFeedCharge : System.Web.UI.Page
{
    private DataTable tempTable = null;

    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            Session["MEDFEEDCHARGE"] = null;
        }
    }


    protected override void OnInit(EventArgs e)
    {
        base.OnInit(e);

        // set Combo source
        Appz.BuildCombo(cmbSearchWard, "WARD", "NAME", "LOID", "ACTIVE='1'", "NAME", "ทั้งหมด", "0", false);
        Appz.BuildCombo(cmbWard, "WARD", "NAME", "LOID", "ACTIVE='1'", "NAME", "เลือก", "0", false);
        pcTop.SetMainGridView(gvMain);
        pcBot.SetMainGridView(gvMain);
        pcTop2.SetMainGridView(grvItem);
        pcBot2.SetMainGridView(grvItem);
        pcTop.Visible = false;
        pcBot.Visible = false;
        pcBot2.Visible = false;
        pcTop2.Visible = false;
    }


    #region Button Click Event Handler

    #region Main

    protected void lnkType_Click(object sender, EventArgs e)
    {
        doGetDetail(((LinkButton)sender).CommandArgument);
        zPop.Show();
    }

    protected void imbSearch_Click(object sender, ImageClickEventArgs e)
    {
        gvMain.PageIndex = 0;
        doGetList();
    }

    protected void tbApproveMainClick(object sender, EventArgs e)
    {
        doApproveMain();
        doGetList();
    }

    protected void tbCancelMainClick(object sender, EventArgs e)
    {
        doCancelMain();
        doGetList();
    }



    #endregion

    #region Popup

    protected void tbSaveClick(object sender, EventArgs e)
    {
        if (!doSave("WA"))
            zPop.Show();
        else
            zPop.Show();
    }


    protected void tbApproveClick(object sender, EventArgs e)
    {
        if (doApprove())
        {
            doGetDetail(txhID.Text.Trim());
            doGetList();
            zPop.Show();
        }
        else
            zPop.Show();
    }

    protected void tbCancelClick(object sender, EventArgs e)
    {
        if (txhID.Text.Trim() == "")
            ClearData();
        else
            doGetDetail(txhID.Text);

        zPop.Show();
    }

    protected void tbBackClick(object sender, EventArgs e)
    {
        ClearData();
    }

    protected void tbAddMedFeedChargeItemClick(object sender, EventArgs e)
    {
        if (cmbWard.SelectedItem.Value.ToString() != "0")
        {
            this.ctlAdmitPatientPopup.Show(cmbWard.SelectedItem.Value.ToString(), getLoidList());
        }
        else
            SetErrorStatus(string.Format(DataResources.MSGEI002, "หอผู้ป่วย"));

        zPop.Show();
    }

    protected void tbDeleteMedFeedChargeItemClick(object sender, EventArgs e)
    {
        DeleteSession();
        BindGVItem();

    }

    protected void ImgTypClick(object sender, EventArgs e)
    {
        int rowIndex = 0;
        this.ctlMaterialUnitPopup.Show("", "");
        ImageButton imgtype = (ImageButton)sender;
        rowIndex = (Convert.ToInt32(imgtype.ToolTip));
        TextBox txtloid = (TextBox)grvItem.Rows[rowIndex].FindControl("LOID");
        txtLoidIndex.Text = txtloid.Text.Trim();
        zPop.Show();
    }

    #endregion

    #endregion

    #region Gridview Event Handler

    protected void gvMain_RowDataBound(object sender, GridViewRowEventArgs e)
    {
        if (e.Row.RowIndex > -1)
        {
            e.Row.Cells[1].Text = ((e.Row.RowIndex + 1) + (gvMain.PageIndex * gvMain.PageSize)).ToString();

            if (e.Row.Cells[7].Text != "WA")
            {
                CheckBox chkSelect = (CheckBox)e.Row.FindControl("chkSelect");
                if (chkSelect != null)
                {
                    chkSelect.Enabled = false;
                    chkSelect.CssClass = "zHidden";
                }
            }
        }
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


    protected void grvItem_RowDataBound(object sender, GridViewRowEventArgs e)
    {
        if (e.Row.RowIndex > -1)
            e.Row.Cells[2].Text = ((e.Row.RowIndex + 1) + (grvItem.PageIndex * grvItem.PageSize)).ToString();

        if (e.Row.RowType == DataControlRowType.DataRow)
        {
            TextBox txtQty = (TextBox)e.Row.FindControl("txtQty");
            if (txtQty != null)
                ControlUtil.SetDblTextBox(txtQty);
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

    protected void PageChange2(object sender, EventArgs e)
    {
        grvItem.PageIndex = ((Templates_PageControl)sender).SelectedPageIndex;
        doGetDetail(txhID.Text.Trim());
        pcBot2.Update();
        pcTop2.Update();
    }
    #endregion

    #region Misc. Methods

    private void CreateTempTable()
    {
        tempTable = new DataTable();
        DataColumn dcLOID = new DataColumn("LOID");
        DataColumn dcMCLOID = new DataColumn("MCLOID");
        DataColumn dcMCILOID = new DataColumn("MCILOID");
        DataColumn dcPATIENTNAME = new DataColumn("PATIENTNAME");
        DataColumn dcREQDATE = new DataColumn("REQDATE",typeof(System.DateTime));
        DataColumn dcMMLOID = new DataColumn("MMLOID");
        DataColumn dcMMNAME = new DataColumn("MMNAME",typeof(System.String));
        DataColumn dcUULOID = new DataColumn("UULOID");
        DataColumn dcUUNAME = new DataColumn("UUNAME");
        DataColumn dcQTY = new DataColumn("QTY");
        DataColumn dcPRICE = new DataColumn("PRICE");
        DataColumn dcREMARKS = new DataColumn("REMARKS");
        DataColumn dcTOTAL = new DataColumn("TOTAL");

        tempTable.Columns.Add(dcLOID);
        tempTable.Columns.Add(dcMCLOID);
        tempTable.Columns.Add(dcMCILOID);
        tempTable.Columns.Add(dcPATIENTNAME);
        tempTable.Columns.Add(dcREQDATE);
        tempTable.Columns.Add(dcMMLOID);
        tempTable.Columns.Add(dcMMNAME);
        tempTable.Columns.Add(dcUULOID);
        tempTable.Columns.Add(dcUUNAME);
        tempTable.Columns.Add(dcQTY);
        tempTable.Columns.Add(dcPRICE);
        tempTable.Columns.Add(dcREMARKS);
        tempTable.Columns.Add(dcTOTAL);
    }

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

    private ArrayList GetCheckedPop()
    {
        ArrayList arrChk = new ArrayList();
        for (int i = 0; i < grvItem.Rows.Count; i++)
        {
            if (i > -1 && grvItem.Rows[i].Cells[0].FindControl("chkSelectPop") != null)
            {
                if (((CheckBox)grvItem.Rows[i].Cells[1].FindControl("chkSelectPop")).Checked)
                {
                    TextBox txtLOID = (TextBox)grvItem.Rows[i].FindControl("LOID");
                    arrChk.Add(txtLOID.Text.Trim());
                }
                   
            }
        }

        return arrChk;
    }

    private string getLoidList()
    {
        string LoidList = "";
        DataTable dt = (DataTable)Session["MEDFEEDCHARGE"];
        if (dt != null)
        {
            for (int i = 0; i < dt.Rows.Count; ++i)
            {
                LoidList += (LoidList == "" ? "" : ",") + dt.Rows[i]["LOID"].ToString();
            }
        }
        return LoidList;
    }

    #endregion

    #region Controls Management Methods

    private void SetStatusMain(string t)
    {
        lbStatusMain.Text = t;
        lbStatusMain.ForeColor = Constant.StatusColor.Information;
    }
    private void SetStatus(string t)
    {
        lbStatus.Text = t;
        lbStatus.ForeColor = Constant.StatusColor.Information;
    }

    private void SetErrorStatus(string t)
    {
        lbStatus.Text = t;
        lbStatus.ForeColor = Constant.StatusColor.Error;
    }

    private void ClearData()
    {
        txhID.Text = "";
        cmbWard.SelectedIndex = -1;
        txtCode.Text = "";
        ctlChargeDate.DateValue = DateTime.Today.Date;
        txtStatusName.Text = "";
        txtStatusFlag.Text = "WA";
        txtWardLoid.Text = cmbWard.SelectedItem.Value.ToString();

        Session["MEDFEEDCHARGE"] = null;
        grvItem.DataSource = null;
        grvItem.DataBind();
        BlockControl();
    }

    private MedFeedChargeData  GetData(string status)
    {
        MedFeedChargeData mData = new MedFeedChargeData();
        mData.LOID = Convert.ToDouble("0" + txhID.Text);
        mData.WARD = Convert.ToDouble(cmbWard.SelectedItem.Value.ToString());
        mData.CHARGEDATE = DateTime.Today.Date;
        mData.STATUS = status.ToString();
        return mData;
    }

    private void SetData(MedFeedChargeData mdata,DataTable dt)
    {
        txhID.Text = mdata.LOID.ToString();
        txtCode.Text = mdata.CODE.ToString();
        cmbWard.SelectedIndex = cmbWard.Items.IndexOf(cmbWard.Items.FindByValue(mdata.WARD.ToString()));
        ctlChargeDate.DateValue = Convert.ToDateTime(mdata.CHARGEDATE.ToString());
        txtStatusFlag.Text = mdata.STATUS.ToString();
        txtStatusName.Text = (mdata.STATUS.ToString() == "WA"?"กำลังดำเนินการ":(mdata.STATUS.ToString() == "AP"?"อนุมัติ":"ยกเลิก"));
        txtWardLoid.Text = mdata.WARD.ToString();
        tbPrint.Visible = (txhID.Text.Trim() == "" ? false : true);
        this.tbPrint.ClientClick = Appz.OpenReportScript(Constant.Reports.MedFeedChargeReport, Convert.ToDouble(txhID.Text.Trim()), false);


        Session["MEDFEEDCHARGE"] = dt;
        grvItem.DataSource = dt;
        grvItem.DataBind();
        pcBot2.Update();
        pcTop2.Update();
        if (dt.Rows.Count > 0)
        {
            pcBot2.Visible = true;
            pcTop2.Visible = true;
        }
        else
        {
            pcBot2.Visible = false;
            pcTop2.Visible = false;
        }
        BlockControl();
        
    }

    protected void QtyCalculate(object sender, EventArgs e)
    {
        TextBox txtQty = (TextBox)sender;
        Calculate(Convert.ToInt32(txtQty.ToolTip));
        UpdateSession(Convert.ToInt32(txtQty.ToolTip));
        BindGVItem();
        zPop.Show();
    }

    private void Calculate(int rowindex)
    {
        TextBox txtQty = (TextBox)grvItem.Rows[rowindex].FindControl("txtQty");
        Label lblPrice = (Label)grvItem.Rows[rowindex].FindControl("lblPrice");
        Label lblTotal = (Label)grvItem.Rows[rowindex].FindControl("lblTotal");
        if (txtQty != null && lblPrice != null && lblTotal != null)
        {
            double qty = (txtQty.Text.Trim() ==""?0: Convert.ToDouble(txtQty.Text.Trim()));
            double price =(lblPrice.Text.Trim() ==""?0:Convert.ToDouble(lblPrice.Text.Trim()));
            double total = qty * price;
            lblTotal.Text = total.ToString("#,##0.##");
        }
    }

    protected void txtRemarksTextChange(object sender, EventArgs e)
    {
        TextBox txtRemarks = (TextBox)sender;
        UpdateSession(Convert.ToInt32(txtRemarks.ToolTip));
        BindGVItem();
    }

    private void UpdateSession(int rowindex)
    {
        DataTable dt = new DataTable();
        dt = (DataTable) Session["MEDFEEDCHARGE"];

        TextBox txtLOID = (TextBox)grvItem.Rows[rowindex].FindControl("LOID");
        TextBox txtRemarks = (TextBox)grvItem.Rows[rowindex].FindControl("txtRemarks");
        TextBox txtQty = (TextBox)grvItem.Rows[rowindex].FindControl("txtQty");
        Label lblPrice = (Label)grvItem.Rows[rowindex].FindControl("lblPrice");
        Label lblTotal = (Label)grvItem.Rows[rowindex].FindControl("lblTotal");

        if (txtLOID != null && txtRemarks != null)
        {
            for(int i=0; i<dt.Rows.Count ;++i)
            {
                if (dt.Rows[i]["LOID"].ToString() == txtLOID.Text.Trim())
                {
                    if(txtRemarks.Text.Trim() != "")
                        dt.Rows[i]["REMARKS"] = txtRemarks.Text.Trim();

                    if(txtQty.Text.Trim() != "")
                        dt.Rows[i]["QTY"] = txtQty.Text.Trim();

                    if(lblPrice.Text.Trim() != "")
                        dt.Rows[i]["PRICE"] = lblPrice.Text.Trim();

                    if (lblTotal.Text.Trim() != "")
                        dt.Rows[i]["TOTAL"] = lblTotal.Text.Trim();

                }
            }
            Session["MEDFEEDCHARGE"] = dt;
        }

    }

    private void DeleteSession()
    {
        DataTable dt = new DataTable();
        dt = (DataTable)Session["MEDFEEDCHARGE"];
        ArrayList arr = GetCheckedPop();

        if (arr.Count > 0 && dt != null)
        {
            foreach (string loid in arr)
            {
                for (int i = 0; i < dt.Rows.Count; i++)
                {
                    if (loid == dt.Rows[i]["LOID"].ToString())
                    {
                        DataRow dr = dt.Rows[i];
                        dt.Rows.Remove(dr);
                    }
                }
            }
        }
    }

    protected void ctlAdmitPatientPopup_SelectedIndexChanged(object sender, EventArgs e, ArrayList arrData)
    {
        if (InsertNewDataToTmpItem(arrData))
            BindGVItem();
        zPop.Show();
    }

    protected void ctlAdmitPatientPopup_Cancel(object sender, EventArgs e)
    {
        zPop.Show();
    }

    protected void ctlMaterialUnitPopup_SelectedIndexChanged(object sender, EventArgs e, ArrayList arrData)
    {
        if (UpdateNewDataToTmpItem(arrData))
            BindGVItem();
        zPop.Show();
    }

    protected void ctlMaterialUnitPopup_Cancel(object sender, EventArgs e)
    {
        zPop.Show();
    }


    private void BlockControl()
    {
        tbSave.Visible = (txtStatusFlag.Text.Trim() != "WA"  ? false : true);
        tbReturn.Visible = (txtStatusFlag.Text.Trim() != "WA"  ? false : true);
        tbApprove.Visible = (txtStatusFlag.Text.Trim() != "WA" ? false : true);
        tbAddMedFeedChargeItem.Visible = (txtStatusFlag.Text.Trim() != "WA" ? false : true);
        tbDeleteMedFeedChargeItem.Visible = (txtStatusFlag.Text.Trim() != "WA" ? false : true);
        cmbWard.Enabled = (txtStatusFlag.Text.Trim() != "WA" ? false : true);

        if (txtStatusFlag.Text.Trim() != "WA")
        {
            if (grvItem.Rows.Count > 0 )
            {
                for (int i = 0; i < grvItem.Rows.Count; ++i)
                {
                    TextBox txtMMName = (TextBox)grvItem.Rows[i].FindControl("txtMMName");
                    ImageButton imgType = (ImageButton)grvItem.Rows[i].FindControl("imgType");
                    CheckBox chkSelectPop = (CheckBox)grvItem.Rows[i].FindControl("chkSelectPop");
                    TextBox txtQty = (TextBox)grvItem.Rows[i].FindControl("txtQty");
                    TextBox txtRemarks = (TextBox)grvItem.Rows[i].FindControl("txtRemarks");

                    if (txtMMName != null && imgType != null && chkSelectPop != null && txtQty != null && txtRemarks != null)
                    {
                        txtMMName.CssClass = "zTextbox-View";
                        txtMMName.ReadOnly = true;
                        imgType.Enabled = false;
                        txtQty.CssClass = "zTextboxR-View";
                        txtQty.ReadOnly = true;
                        txtRemarks.CssClass = "zTextbox-View";
                        txtRemarks.ReadOnly = true;
                        chkSelectPop.Visible = false;
                        grvItem.Rows[i].Cells[4].Enabled = false;
                        grvItem.Rows[i].Cells[1].Enabled = false;
                    }
                }
            }
        }
        else
        {
            for (int i = 0; i < grvItem.Rows.Count; ++i)
            {
                TextBox txtMMName = (TextBox)grvItem.Rows[i].FindControl("txtMMName");
                ImageButton imgType = (ImageButton)grvItem.Rows[i].FindControl("imgType");
                CheckBox chkSelectPop = (CheckBox)grvItem.Rows[i].FindControl("chkSelectPop");
                TextBox txtQty = (TextBox)grvItem.Rows[i].FindControl("txtQty");
                TextBox txtRemarks = (TextBox)grvItem.Rows[i].FindControl("txtRemarks");

                if (txtMMName != null && imgType != null && chkSelectPop != null && txtQty != null && txtRemarks != null)
                {
                    txtMMName.CssClass = "zTextbox";
                    txtMMName.ReadOnly = false;
                    imgType.Enabled = true;
                    txtQty.CssClass = "zTextbox";
                    txtQty.ReadOnly = false;
                    txtRemarks.CssClass = "zTextbox";
                    txtRemarks.ReadOnly = false;
                    chkSelectPop.Visible = true;
                    grvItem.Rows[i].Cells[4].Enabled = true;
                    grvItem.Rows[i].Cells[1].Enabled = true;
                }
            }
        }
    }

    #endregion

    #region Working Method

    private void doGetList()
    {
        MedFeedChargeFlow mFlow = new MedFeedChargeFlow();
        string orderStr = "";
        if (txhSortField.Text.Trim() != "")
            orderStr = " " + txhSortField.Text + " " + txhSortDir.Text;

        gvMain.DataSource = mFlow.GetMedFeedChargeList(txtSearchCodeFrom.Text.Trim(),txtSearchCodeTo.Text.Trim(),
                            ctlChargeDateFrom.DateValue.Date,ctlChargeDateTo.DateValue.Date,Convert.ToDouble(cmbSearchWard.SelectedItem.Value),
                            cmbSearchStatusFrom.SelectedItem.Value, cmbSearchStatusTo.SelectedItem.Value, orderStr);
        gvMain.DataBind();
        pcTop.Update();
        pcBot.Update();
        pcTop.Visible = true;
        pcBot.Visible = true;
    }

    private bool doGetDetail(string LOID)
    {
        bool ret = true;

        MedFeedChargeFlow mFlow = new MedFeedChargeFlow();
        MedFeedChargeData mData = mFlow.GetMedFeedChargeData(Convert.ToDouble("0"+ LOID));
        DataTable dt = mFlow.GetMedFeedChargeItemData(Convert.ToDouble("0" + LOID));

        if (mData.LOID != 0)
        {
            SetData(mData,dt);
        }
        else
            ret = false;

        return ret;
    }

    private bool doSave(string status)
    {
        bool ret = true;
        double mloid = 0;

        // verify required field
        string error = VerifyData();
        if (error != "")
        {
            SetErrorStatus(error);
            return false;
        }

        MedFeedChargeFlow mFlow = new MedFeedChargeFlow();
        DataTable dt = new DataTable();
        dt = (DataTable)Session["MEDFEEDCHARGE"];


        // data correct go on saving...
        if (txhID.Text.Trim() == "")
        {
            //  save new
            mloid = mFlow.InsertMedFeedCharge(GetData(status), dt, Appz.CurrentUser);
        }
        else
        {
             //save update
            mloid = mFlow.UpdateMedFeedCharge(GetData(status), dt, Appz.CurrentUser);
        }

        if (mloid.ToString() == "0")
            SetErrorStatus(mFlow.ErrorMessage);
        else
        {
            SetStatus("บันทึกข้อมูลเรียบร้อยแล้ว");
            doGetDetail(mloid.ToString());
            doGetList();
        }
        return ret;
    }

    private bool doApprove()
    {
        bool ret = true;
        if (txhID.Text.Trim() == "")
        {
            ret = doSave("AP");
        }
        else
        {
            MedFeedChargeFlow mFlow = new MedFeedChargeFlow();
            ret = mFlow.ApproveMedFeedCharge(Convert.ToDouble(txhID.Text.Trim()), Appz.CurrentUser);
            if (!ret)
                SetErrorStatus(mFlow.ErrorMessage);
            else
                SetStatus("อนุมัติรายการเรียบร้อยแล้ว");
        }

        return ret;
    }

    private bool doApproveMain()
    {
        bool ret = true;
        ArrayList arr = new ArrayList();

        arr = GetChecked();
        if (arr.Count > 0)
        {
            MedFeedChargeFlow mFlow = new MedFeedChargeFlow();
            ret = mFlow.UpdateMedFeedChargeMain(arr, Appz.CurrentUser,"AP");
            if (!ret)
                SetStatusMain(mFlow.ErrorMessage);
            else
                SetStatusMain("อนุมัติรายการเรียบร้อยแล้ว");
        }
        else
        {
            SetStatusMain(string.Format(DataResources.MSGEI002, "รายการที่ต้องการ"));
        }

        return ret;
    }

    private bool doCancelMain()
    {
        bool ret = true;
        ArrayList arr = new ArrayList();

        arr = GetChecked();
        if (arr.Count > 0)
        {
            MedFeedChargeFlow mFlow = new MedFeedChargeFlow();
            ret = mFlow.UpdateMedFeedChargeMain(arr, Appz.CurrentUser,"VO");
            if (!ret)
                SetStatusMain(mFlow.ErrorMessage);
            else
                SetStatusMain("อนุมัติรายการเรียบร้อยแล้ว");
        }
        else
        {
            SetStatusMain(string.Format(DataResources.MSGEI002, "รายการที่ต้องการ"));
        }

        return ret;
    }


    private string VerifyData()
    {
        string ret = "";

        MedFeedChargeData  mData = GetData("");
        if (mData.WARD.ToString() == "0")
        {
            ret = string.Format(DataResources.MSGEI001, "หอผู้ป่วย");
            return ret;
        }
            
        DataTable dt = new DataTable();
        if (Session["MEDFEEDCHARGE"] == null)
        {
            //กรณีไม่มีข้อมูลใน gridview
            ret = string.Format(DataResources.MSGEI001, "รายการผู้ป่วยและค่าอาหารทางการแพทย์");
        }
        else
        {
            //กรณีมีข้อมูลใน gridview
            dt = (DataTable)Session["MEDFEEDCHARGE"];
            if (dt.Rows.Count == 0)
            {
                ret = string.Format(DataResources.MSGEI001, "รายการผู้ป่วยและค่าอาหารทางการแพทย์");
            }
            else
            {
                for (int i = 0; i < dt.Rows.Count; ++i)
                {
                    if (dt.Rows[i]["MMLOID"].ToString() == "")
                    {
                        ret = string.Format(DataResources.MSGEI001, "ชนิดอาหารรายการที่ " + (i + 1));
                        return ret;
                    }

                    if (dt.Rows[i]["QTY"].ToString() == "0" || dt.Rows[i]["QTY"].ToString() == "" || dt.Rows[i]["QTY"].ToString() == "0.00")
                    {
                        ret = string.Format(DataResources.MSGEI001, "จำนวนที่เบิกรายการที่ " + (i + 1));
                        return ret;
                    }
                }
            }
        }
      
        return ret;
    }

    private bool InsertNewDataToTmpItem(ArrayList arrData)
    {
        bool ret = true;
        DataTable dt = new DataTable();

        //เช็คว่าเป็น ward เดิมหรือไม่
        if (txtWardLoid.Text.Trim() == cmbWard.SelectedItem.Value.ToString())
        {
            if (Session["MEDFEEDCHARGE"] == null)
            {
                CreateTempTable();
                Session["MEDFEEDCHARGE"] = tempTable;
                dt = (DataTable)Session["MEDFEEDCHARGE"];
            }
            else
                dt = (DataTable)Session["MEDFEEDCHARGE"];
        }
        else
        {
            //สร้าง datasorce ใหม่
            CreateTempTable();
            Session["MEDFEEDCHARGE"] = tempTable;
            dt = (DataTable)Session["MEDFEEDCHARGE"];
        }
       
        try
        {
            for (int i = 0; i < arrData.Count; i++)
            {
                VAdmitPatientData vData = (VAdmitPatientData)arrData[i];
                DataRow dr = dt.NewRow();
                dr["LOID"] = vData.LOID;
                dr["PATIENTNAME"] = vData.PATIENTNAME;
                dr["REQDATE"] = DateTime.Today.Date;
                dr["QTY"] = "0";
                dr["MMNAME"] = vData.MATERIALNAME.ToString();
                dr["UUNAME"] = vData.UNITNAME.ToString();
                dr["UULOID"] = vData.UNIT.ToString();
                dr["MMLOID"] = vData.MATERIALMASTER.ToString();
                dr["PRICE"] = vData.COST.ToString("#,##0.##");
                dr["TOTAL"] = "0";

                dt.Rows.Add(dr);
            }

            Session["MEDFEEDCHARGE"] = dt;
        }
        catch (Exception ex)
        {
            ex.ToString();
            ret = false;
        }
        txtWardLoid.Text = cmbWard.SelectedItem.Value.ToString();
        return ret;
    }

    private bool UpdateNewDataToTmpItem(ArrayList arrData)
    {
        bool ret = true;
        DataTable dt = new DataTable();
        dt = (DataTable)Session["MEDFEEDCHARGE"];

        try
        {
            for (int i = 0; i < dt.Rows.Count; i++)
            {

                if (txtLoidIndex.Text.Trim() == dt.Rows[i]["LOID"].ToString())
                {
                    VMaterialMasterUnitData vData = (VMaterialMasterUnitData)arrData[0];
                   // TextBox txtmmname = (TextBox)dt.Rows[i]["MMNAME"];
                    dt.Rows[i]["MMNAME"] = vData.MATERIALNAME.ToString();
                    dt.Rows[i]["UUNAME"] = vData.UNITNAME.ToString();
                    dt.Rows[i]["UULOID"] = vData.UNIT.ToString();
                    dt.Rows[i]["MMLOID"] = vData.MATERIALMASTER.ToString();
                    dt.Rows[i]["PRICE"] = vData.PRICE.ToString("#,##0.##");
                    Double qty = (dt.Rows[i]["QTY"].ToString() == ""?0: Convert.ToDouble(dt.Rows[i]["QTY"].ToString()));
                    Double price = (dt.Rows[i]["PRICE"].ToString() == ""?0: Convert.ToDouble(dt.Rows[i]["PRICE"].ToString()));
                    Double total = qty * price;
                    dt.Rows[i]["TOTAL"] = total.ToString("#,##0.##");
                }
            }

            Session["MEDFEEDCHARGE"] = dt;
        }
        catch (Exception ex)
        {
            ex.ToString();
            ret = false;
        }
        txtWardLoid.Text = cmbWard.SelectedItem.Value.ToString();
        return ret;
    }

    private void BindGVItem()
    {
        if (Session["MEDFEEDCHARGE"] != null)
        {
            DataTable dt = (DataTable)Session["MEDFEEDCHARGE"];
            grvItem.DataSource = dt;
            grvItem.DataBind();
            pcBot2.Update();
            pcTop2.Update();
            if (dt.Rows.Count > 0)
            {
                pcBot2.Visible = true;
                pcTop2.Visible = true;
            }
            else
            {
                pcBot2.Visible = false;
                pcTop2.Visible = false;
            }
            zPop.Show();
        }
    }

    #endregion

 
}
