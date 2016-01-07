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
using SHND.Data.Formula;
using SHND.Global;
using SHND.Flow.Common;
using SHND.Data.Common.Utilities;
using SHND.Flow.Inventory;
using SHND.Data.Tables;
using SHND.DAL.Views;
using SHND.DAL.Tables;
using SHND.Data.Views;

/// <summary>
/// Supplier Page Class
/// Version 1.0
/// =========================================================================
/// Create by: Somsakoon
/// Create Date: 28 Jan 2009
/// -------------------------------------------------------------------------
/// Modify By: -
/// Modify From: -
/// Modify Date: -
/// -------------------------------------------------------------------------
/// Remark: -
/// Description:
///    หน้ากาารทำงานข้อมูล MilkCode  
/// Changes:
///    1.0 - สร้าง
/// -------------------------------------------------------------------------
/// =========================================================================
/// </summary>
/// 

public partial class App_Admin_Master_MilkCode : System.Web.UI.Page
{
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

        Appz.BuildCombo(cmbName1, "V_WARD_SEARCH", "NAME", "LOID", "ACTIVE ='1'", "NAME", "เลือก", "0", false);
        SetWARDList();
        pcTop.SetMainGridView(gvMain);
        pcBot.SetMainGridView(gvMain);
    }

    #region Button Click Event Handler

    protected void imbSearch_Click1(object sender, EventArgs e)
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
    protected void tbAddClick(object sender, EventArgs e)
    {
        zPop.Show();
    }
    protected void tbDeleteClick(object sender, EventArgs e)
    {
        doDelete();
    }
    protected void tbSave1Click(object sender, EventArgs e)
    {
        if (!doSave())
            zPop.Show();
        else
            ClearData();
    }
    protected void imbAdd_Click(object sender, EventArgs e)
    {
        // verify required field
        string error = VerifyData();
        
        if (error != "")
        {
            SetErrorStatus(error);
           // return false;
        }
        else
        {
            MilkCodeDetailItem fsItem = new MilkCodeDetailItem();
            if (fsItem.InsertMilkCodeDisease((Convert.ToDouble(cmbName2.SelectedItem.Value)), txtName.Text))
            {  
                BindStdMilkCodeDisease();
            }
             else 
            {
                SetErrorStatus(fsItem.ErrorMessage);
            }
        }
        ClearTextAdd();
        zPop.Show();
    }
    protected void tbCancelClick(object sender, EventArgs e)
    {
       doGetListWard();
        zPop.Show();
    }
    protected void linkCode_Click(object sender, EventArgs e)
    {
        doGetDetail(((LinkButton)sender).CommandArgument);
        zPop.Show();
    }
    protected void tbBackClick(object sender, EventArgs e)
    {
        ClearData();
    }
   protected void tbSave2Click(object sender, EventArgs e)
    {
        if (!doSave())
            zPop.Show();
        else
            ClearData();
        zPop.Show();
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
        SupplierFlow sFlow = new SupplierFlow();
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
    //private void doDelete()
    //{
    //    HolidayFlow fFlow = new HolidayFlow();
    //    if (fFlow.DeleteByLOID(GetChecked()))
    //    {
    //        gvMain.PageIndex = 0;
    //        doGetList();
    //        lbStatusMain.Text = "";
    //    }
    //    else
    //    {
    //        lbStatusMain.Text = fFlow.ErrorMessage;
    //        lbStatusMain.ForeColor = System.Drawing.Color.Red;
    //    }

    //}

    #endregion

    #region Controls Management Methods

    private void SetWARD()
    {
        Appz.BuildCombo(this.cmbName2,"V_WARD_SEARCH","NAME","LOID","ACTIVE = '1'","", "เลือก", "0", false);
    }
    private void SetWARDList()
    {
        Appz.BuildCombo(cmbName2, "V_WARD_SEARCH", "NAME", "LOID", "ACTIVE ='1'AND LOID  NOT IN (SELECT WARD FROM MILKCODE)  ", "NAME", "เลือก", "0", false);
    }
    private void BindStdMilkCodeDisease()
    {
        this.gvMain1.DataBind();
    }
    private void ClearData()
    {
        MilkCodeDetailItem item = new MilkCodeDetailItem();
        item.ClearAllSession();

        txhID.Text = "";
        txtName.Text = "";
        //cmbName2.SelectedIndex = 0;
        SetWARDList();
        cmbName2.Enabled = true;
        BindStdMilkCodeDisease();

    }
    private void ClearTextAdd()
    {
        txtName.Text = ""; 
    }
    private void ClearSearch()
    {
        cmbName1.SelectedIndex = 0;
    }
    private void SetErrorStatus(string t)
    {
        lbStatus.Text = t;
        lbStatus.ForeColor = Constant.StatusColor.Error;
    }
    private void  SetAlertStatus(string A)
    {
        lbStatus.Text = A;
        lbStatus.ForeColor = Constant.StatusColor.Error;
    }
    private VMilkCodeData  GetData()
    {
        VMilkCodeData sData = new VMilkCodeData();
      
        MilkCodeDetailItem fsItem = new MilkCodeDetailItem();
       
        
        sData.MilkCodeList = fsItem.GetMilkCodeDiseaseData();
        return sData;
    }
    private void SetData(double ward)
    {
        
        SetWARD();
        cmbName2.SelectedIndex = cmbName2.Items.IndexOf(cmbName2.Items.FindByValue(ward.ToString()));
        cmbName2.Enabled = false;
        txtName.Text = "";
        MilkCodeDetailItem item = new MilkCodeDetailItem();
        item.ClearAllSession();
        BindStdMilkCodeDisease();
    }
    

    #endregion

    #region Working Method

    private void doGetList()
    {

        MilkCodeFlow sFlow = new MilkCodeFlow();

        imbReset.Visible = (cmbName1 .SelectedIndex  != 0 );

        string orderStr = "";
        if (txhSortField.Text.Trim() != "")
            orderStr = " " + txhSortField.Text + " " + txhSortDir.Text;

        gvMain.DataSource = sFlow.GetMasterList(Convert.ToDouble(cmbName1.SelectedItem.Value), orderStr);
        gvMain.DataBind();
        pcTop.Update();
        pcBot.Update();

    }
    private void doGetListWard()
    {
        MilkCodeDetailItem item = new MilkCodeDetailItem();
        item.ClearAllSession();
        BindStdMilkCodeDisease();
    }
    private bool doSave()
    {
        bool ret = true;
        MilkCodeFlow stFlow = new MilkCodeFlow();
        MilkCodeDetailItem item = new MilkCodeDetailItem();
        ArrayList arrData = item.GetMilkCodeDiseaseData();
        if (arrData.Count == 0)
        {
            SetErrorStatus(string.Format(DataResources.MSGEI002, "เบอร์นม"));
            zPop.Show();
            return false;
        }
        else
        {
            // verify uniq field


            ret = stFlow.InsertData(Convert.ToDouble("0" + this.cmbName2.SelectedItem.Value), arrData, Appz.CurrentUser);
        }
       

        if (!ret)
            SetErrorStatus(stFlow.ErrorMessage);
        else
            doGetList();

        return ret;
    }
    private string VerifyData()
    {
        string ret = "";
        VMilkCodeData  fData = GetData();

        if (cmbName2.SelectedItem.Value == "0")
            ret = string.Format(DataResources.MSGEI002, "หอผู้ป่วย");
        else if (txtName.Text == "")
            ret = string.Format(DataResources.MSGEI001, "เบอร์นม");
        else if (!this.CheckUniqCode(this.txtName.Text.Trim(), txhID.Text.Trim()))
            ret = string.Format(DataResources.MSGEI015, "เบอร์นม", this.txtName.Text.Trim());
      
        return ret;
    }
    public bool CheckUniqCode(string cMILKOCDE, string cLOID)
    {
        MilkCodeDAL fDAL = new MilkCodeDAL();
        fDAL.GetDataByMILKCODE(cMILKOCDE, null);
        return !fDAL.OnDB || (cLOID == fDAL.LOID.ToString());
    }
    private void doDelete()
    {
        MilkCodeFlow fFlow = new MilkCodeFlow();
        //if (fFlow.DeleteByLOID(GetChecked()))
        if (fFlow.DeleteByWARD(GetChecked()))
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
    private bool doGetDetail(string LOID)
    {
       bool ret = true;
        SetData(Convert.ToDouble(LOID));
        return ret;
    }

   #endregion

    protected void cmbName2_SelectedIndexChanged(object sender, EventArgs e)
    {
        //doGetListWard();
        zPop.Show();
    }
    protected void gvMain1_RowUpdating(object sender, GridViewUpdateEventArgs e)
    {
        e.NewValues["MILKCODE"] = ((TextBox)this.gvMain1.Rows[e.RowIndex].Cells[2].FindControl("txtMilkCode")).Text.Trim();
    }
    protected void gvMain1_RowUpdated(object sender, GridViewUpdatedEventArgs e)
    {
        e.ExceptionHandled = (e.Exception != null);
        if (e.ExceptionHandled)
        {
            e.KeepInEditMode = true;
           // Appz.ClientAlert(this, e.Exception.InnerException.Message);
            SetAlertStatus(e.Exception.InnerException.Message);
        }
    }
    protected void gvMain1_RowCommand(object sender, GridViewCommandEventArgs e)
    {
        zPop.Show();
    }
}
