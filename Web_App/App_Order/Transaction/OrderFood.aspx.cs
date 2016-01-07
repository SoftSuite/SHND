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
using SHND.Data.Order;
using SHND.Global;
using SHND.Flow.Order;

/// <summary>
/// OrderFood Page Class
/// Version 1.0
/// =========================================================================
/// Create by: Teang
/// Create Date: 10 Mar 2009
/// -------------------------------------------------------------------------
/// Modify By: -
/// Modify From: -
/// Modify Date: -
/// -------------------------------------------------------------------------
/// Remark: -
/// Description:
///    หน้าการทำรายการข้อมูล OrderFood
/// Changes:
///    1.0 - สร้าง
/// -------------------------------------------------------------------------
/// =========================================================================
/// </summary>
/// 
public partial class App_Order_Transaction_OrderFood : System.Web.UI.Page
{
    protected override void OnInit(EventArgs e)
    {
        base.OnInit(e);
        Appz.BuildCombo(this.cmbFoodCategory, "FOODCATEGORY", "NAME", "LOID", "ACTIVE = '1' AND LOID IN (1, 43, 82, 21, 51, 52,126)", "NAME", "เลือก", "0", false);
        this.cmbFoodCategory.Items.Add(new ListItem("NPO", "-1"));
        Appz.BuildCombo(this.cmbFoodType, "FOODTYPE", "NAME", "LOID", "ISNURSE = 'Y' AND ACTIVE = '1'", "NAME", "เลือก", "0", false);
        this.tbOrderDoctor.ClientClick = "if (document.getElementById('" + this.cmbFoodCategory.ClientID + "').value == '0') {alert('" + string.Format(DataResources.MSGEI002, "ชนิดอาหาร") + "'); return false; }";
        this.tbOrderNurse.ClientClick = "if (document.getElementById('" + this.cmbFoodType.ClientID + "').value == '0') {alert('" + string.Format(DataResources.MSGEI002, "ประเภทอาหาร") + "'); return false; }";
        pcTop.SetMainGridView(gvMain);
        pcBot.SetMainGridView(gvMain);
    }

    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            doGetDetail((Request["loid"] == null ? "0" : Request["loid"]));
        }
    }

    #region Button Click Event Handler

    #region Main Toolbar
    protected void tbBackClick(object sender, EventArgs e)
    {
        Response.Redirect(Constant.HomeFolder + "App_Order/Transaction/OrderFoodSearch.aspx");
    }
    #endregion

    protected void tbOrderDoctorClick(object sender, EventArgs e)
    {
        ShowPopup(true);
    }

    protected void tbOrderNurseClick(object sender, EventArgs e)
    {
        ShowPopup(false);
    }

    protected void ctlOrderSaveClick(object sender, EventArgs e)
    {
        doGetDetail((Request["loid"] == null ? "0" : Request["loid"]));
    }

    protected void lnkDate_Click(object sender, EventArgs e)
    {
        ShowPopup(((GridViewRow)((LinkButton)sender).Parent.Parent).RowIndex,true);
    }
    protected void lnkNurse_Click(object sender, EventArgs e)
    {
        ShowPopup(((GridViewRow)((LinkButton)sender).Parent.Parent).RowIndex,false);
    }

    protected void imbDelete_Click(object sender, ImageClickEventArgs e)
    {
        DeleteData(((GridViewRow)((ImageButton)sender).Parent.Parent).RowIndex);
    }

    protected void imbCopy_Click(object sender, ImageClickEventArgs e)
    {
        CopyData(((GridViewRow)((ImageButton)sender).Parent.Parent).RowIndex);
    }

    #endregion

    #region Gridview Event Handler

    protected void gvMain_RowDataBound(object sender, GridViewRowEventArgs e)
    {
        if (e.Row.RowIndex > -1)
        {
            e.Row.Cells[2].Text = ((e.Row.RowIndex + 1) + (gvMain.PageIndex * gvMain.PageSize)).ToString();
            string status = e.Row.Cells[10].Text;
            ((ImageButton)e.Row.Cells[1].FindControl("imbDelete")).OnClientClick = "return confirm('" + string.Format(DataResources.MSGCD004, "รายการ", e.Row.Cells[4].Text) + "');";
            ((ImageButton)e.Row.Cells[1].FindControl("imbCopy")).OnClientClick = "return confirm('" + string.Format(DataResources.MSGCC001, "รายการ", e.Row.Cells[4].Text) + "');";
            if (e.Row.Cells[9].Text == "Y")
            {
                ((ImageButton)e.Row.Cells[1].FindControl("imbDelete")).Visible = this.pnlDoctor.Visible && (status == "DC" || status == "WA" || status == "FN");
                ((ImageButton)e.Row.Cells[1].FindControl("imbCopy")).Visible = this.pnlDoctor.Visible && status == "DC";
            }
            else
            {
                ((ImageButton)e.Row.Cells[1].FindControl("imbDelete")).Visible = this.pnlNurse.Visible && (status == "DC" || status == "WA" || status == "FN");
                ((ImageButton)e.Row.Cells[1].FindControl("imbCopy")).Visible = this.pnlNurse.Visible && status == "DC";
            }
        }
    }

    #endregion

    #region Paging Event Handler
    protected void PageChange(object sender, EventArgs e)
    {
        gvMain.PageIndex = ((Templates_PageControl)sender).SelectedPageIndex;
        doGetDetail((Request["loid"] == null ? "0" : Request["loid"]));
        pcBot.Update();
        pcTop.Update();
    }
    #endregion

    #region Controls Management Methods

    private void SetStatus(string t, bool isError)
    {
        this.lbStatus.Text = t;
        this.lbStatus.ForeColor = (isError ? Constant.StatusColor.Error : Constant.StatusColor.Information);
    }

    private void SetData(VOrderPatientData pData)
    {
        bool isDoctor = true;
        bool isNurse = true;
        bool pageAuthorized = (isDoctor || isNurse);

        this.txtLOID.Text = pData.LOID.ToString();
        this.txtPatientStatus.Text = pData.PATIENTSTATUS;
        this.txtAge.Text = pData.AGE;
        this.txtAllergic.Text = pData.DRUGALLERGIC.Replace("<BR>","") + ", " + pData.FOODALLERGIC.Replace("<BR>","");
        this.txtAN.Text = pData.AN;
        this.txtBedNo.Text = pData.BEDNO;
        if (pData.STATUSRANK == "02" || pData.REMARK == "NPO" || pData.REMARK == "")
            this.txtDataStatus.Text = "สมบูรณ์";
        else
            this.txtDataStatus.Text = "ไม่สมบูรณ์";
        this.txtDiagnosis.Text = pData.DIAGNOSIS;
        this.txtHeight.Text = pData.HEIGHT.ToString();
        this.txtHN.Text = pData.HN;
        this.txtPatientName.Text = pData.PATIENTNAME + ", " + pData.TITLENAME;
        this.txtRoomNo.Text = pData.ROOMNO;
        this.txtStatusName.Text = pData.STATUSNAME;
        this.txtWard.Text = pData.WARD.ToString();
        this.txtWardName.Text = pData.WARDNAME;
        this.txtWeight.Text = pData.WEIGHT.ToString(Constant.IntFormat);
        this.ctlAdmitDate.DateValue = pData.ADMITDATE;
        this.ctlBirthDate.DateValue = pData.BIRTHDATE;
        this.cmbFoodType.SelectedValue = pData.DEFAULTFOODTYPE.ToString();
        
        this.pnlDoctor.Visible = isDoctor && pageAuthorized && pData.PATIENTSTATUS != "DG";
        this.pnlNurse.Visible = isNurse && pageAuthorized && pData.PATIENTSTATUS != "DG";
        this.gvMain.DataSource = pData.OrderDetail;
        this.gvMain.DataBind();
        //pcTop.Update();
        //pcBot.Update();

        this.gvMain.Columns[1].Visible = (pageAuthorized && pData.PATIENTSTATUS != "DG");
    }

    #endregion

    #region Working Method

    private void ShowPopup(bool isDoctorOrder)
    {
        double admitPatientID = Convert.ToDouble("0" + this.txtLOID.Text);
        if (isDoctorOrder)
        {
            switch (this.cmbFoodCategory.SelectedItem.Value)
            {
                case "-1":
                    for (int i = 0; i < gvMain.Rows.Count; ++i)
                    {
                        if (gvMain.Rows[i].Cells[10].Text.ToString() == "RG")
                        {
                            SetStatus("ไม่สามารถงดอาหารได้", true);
                            return;
                        }
                    }
                    CtlOrderNPO.Show(admitPatientID, 0, !pnlDoctor.Visible, false);
                    break;
                case "1":
                case "43":
                case "82":
                    ctlOrderMedical.Show(admitPatientID, 0, !pnlDoctor.Visible, false, Convert.ToDouble(this.cmbFoodCategory.SelectedItem.Value),Convert.ToDouble("0" + txtWard.Text));
                    break;
                case "21":
                case "51":
                    ctlOrderFeed.Show(admitPatientID, 0, !pnlDoctor.Visible, false, Convert.ToDouble("0" + txtWard.Text));
                    break;
                case "52":
                    CtlOrderMilk.Show(admitPatientID, 0, !pnlDoctor.Visible, false, Convert.ToDouble("0" + txtWard.Text), isDoctorOrder);
                    break;
            }
        }
        else
            CtlOrderNonMedical.Show(admitPatientID, 0, !pnlNurse.Visible, false, Convert.ToDouble(this.cmbFoodType.SelectedItem.Value), Convert.ToDouble("0" + txtWard.Text));
    }

    private void ShowPopup(int rowIndex,bool isDoctor)
    {
        double admitPatientID = Convert.ToDouble("0" + this.txtLOID.Text);
        double loid = Convert.ToDouble(this.gvMain.Rows[rowIndex].Cells[0].Text);
        switch (this.gvMain.Rows[rowIndex].Cells[7].Text)
        {
            case "ORDERMEDICALSET":
                if (this.gvMain.Rows[rowIndex].Cells[8].Text == "Y")
                    CtlOrderNPO.Show(admitPatientID, loid, !pnlDoctor.Visible, false);
                else
                    ctlOrderMedical.Show(admitPatientID, loid, !pnlDoctor.Visible, false, 0,Convert.ToDouble("0" + txtWard.Text));
                break;
            case "ORDERMEDICALFEED":
                ctlOrderFeed.Show(admitPatientID, loid, !pnlDoctor.Visible, false, Convert.ToDouble("0" + txtWard.Text));
                break;
            case "ORDERMILK":
                CtlOrderMilk.Show(admitPatientID, loid, !pnlDoctor.Visible, false, Convert.ToDouble("0" + txtWard.Text), isDoctor);
                break;
            case "ORDERNONMEDICAL":
                CtlOrderNonMedical.Show(admitPatientID, loid, !pnlNurse.Visible, false, 0, Convert.ToDouble("0" + txtWard.Text));
                break;
        }
    }

    private bool doGetDetail(string LOID)
    {
        OrderFoodFlow fFlow = new OrderFoodFlow();
        VOrderPatientData fData = fFlow.GetDetail(Convert.ToDouble(LOID));

        bool ret = true;
        SetData(fData);
        return ret;
    }

    private void DeleteData(int rowIndex)
    {
        bool ret = true;
        OrderFoodFlow ftFlow = new OrderFoodFlow();
        double loid = Convert.ToDouble(this.gvMain.Rows[rowIndex].Cells[0].Text);
        switch (this.gvMain.Rows[rowIndex].Cells[7].Text)
        {
            case "ORDERMEDICALSET":
                ret = ftFlow.DeleteOrderMedicalSet(loid);
                break;
            case "ORDERMEDICALFEED":
                ret = ftFlow.DeleteOrderMedicalFeed(loid);
                break;
            case "ORDERMILK":
                ret = ftFlow.DeleteOrderMilk(loid);
                break;
            case "ORDERNONMEDICAL":
                ret = ftFlow.DeleteOrderNonMedical(loid);
                break;
        }

        if (!ret)
            SetStatus(ftFlow.ErrorMessage, true);
        else
            doGetDetail(this.txtLOID.Text);
    }

    private void CopyData(int rowIndex)
    {
        //bool ret = true;
        OrderFoodFlow ftFlow = new OrderFoodFlow();
        double admitPatientID = Convert.ToDouble("0" + this.txtLOID.Text);
        double loid = Convert.ToDouble(this.gvMain.Rows[rowIndex].Cells[0].Text);
        switch (this.gvMain.Rows[rowIndex].Cells[7].Text)
        {
            case "ORDERMEDICALSET":
                if (this.gvMain.Rows[rowIndex].Cells[8].Text == "Y")
                    CtlOrderNPO.Show(admitPatientID, loid, !pnlDoctor.Visible, true);
                else
                    ctlOrderMedical.Show(admitPatientID, loid, !pnlDoctor.Visible, true, 0, Convert.ToDouble("0" + txtWard.Text));
                break;
            case "ORDERMEDICALFEED":
                ctlOrderFeed.Show(admitPatientID, loid, !pnlDoctor.Visible, true, Convert.ToDouble("0" + txtWard.Text));
                break;
            case "ORDERMILK":
                CtlOrderMilk.Show(admitPatientID, loid, !pnlDoctor.Visible, true, Convert.ToDouble("0" + txtWard.Text),true);
                break;
            case "ORDERNONMEDICAL":
                CtlOrderNonMedical.Show(admitPatientID, loid, !pnlNurse.Visible, true, 0, Convert.ToDouble("0" + txtWard.Text));
                break;
        }
    }

    #endregion

}
