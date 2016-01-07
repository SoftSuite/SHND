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
using SHND.Flow.Admin;

/// <summary>
/// Supplier Page Class
/// Version 1.0
/// =========================================================================
/// Create by: Somsakoon
/// Create Date: 30 Jan 2009
/// -------------------------------------------------------------------------
/// Modify By: -
/// Modify From: -
/// Modify Date: -
/// -------------------------------------------------------------------------
/// Remark: -
/// Description:
///    หน้ากาารทำงานข้อมูล  Ward  
/// Changes:
///    1.0 - สร้าง
/// -------------------------------------------------------------------------
/// =========================================================================
/// </summary>
/// 


public partial class App_Admin_Master_Ward : System.Web.UI.Page
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
        ControlUtil.SetIntTextBox(this.txtBED);
        Appz.BuildCombo(cmbFOODName, "FOODTYPE", "NAME", "LOID", "ISNURSE = 'Y' AND ACTIVE = '1'", "NAME", "ไม่ระบุ", "0", false);
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

    protected void tbBackClick(object sender, EventArgs e)
    {
        ClearData();
    }
    protected void tbCancelClick(object sender, EventArgs e)
    {
        if (txhID.Text.Trim() == "")
            ClearData();
        else
            doGetDetail(txhID.Text);

        zPop.Show();
    }
    protected void linkCode_Click(object sender, EventArgs e)
    {
        doGetDetail(((LinkButton)sender).CommandArgument);
        zPop.Show();
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
    private void doDelete()
    {
        WardFlow fFlow = new WardFlow();
        if (fFlow.DeleteByLOID(GetChecked()))
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

    #endregion

    #region Controls Management Methods

    private void ClearData()
    {
        txhID.Text = "";
        txtCode.Text = "";
        txtName.Text = "";
        txtABBName.Text = "";
        txtBED.Text = "";
        cmbFOODName.SelectedIndex = 0;
        chkActive.Checked = true;
        
    }

    private void ClearSearch()
    {
        txtSearch.Text = "";
    }

    private void SetErrorStatus(string t)
    {
        lbStatus.Text = t;
        lbStatus.ForeColor = Constant.StatusColor.Error;
    }
    private WardData  GetData()
    {
        WardData sData = new WardData();

        sData.LOID = Convert.ToDouble("0" + txhID.Text);
        sData.CODE = txtCode.Text;
        sData.NAME = txtName.Text;
        sData.ABBNAME = txtABBName.Text;
        sData.BEDQTY = Convert.ToDouble( "0" + txtBED.Text);
        sData.DEFAULTFOODTYPE = Convert.ToDouble(cmbFOODName.SelectedItem.Value);
        sData.ACTIVE = chkActive.Checked;
        sData.ISLOCKCUTOFFTIME = chkIsLockCutOffTime.Checked;
        sData.SAPCODE = txtSAP.Text;
        return sData;

    }
    #endregion

    #region Working Method
    private void doGetList()
    {
        WardFlow sFlow = new WardFlow();

        imbReset.Visible = (txtSearch.Text.Trim() != "");

        string orderStr = "";
        if (txhSortField.Text.Trim() != "")
            orderStr = " " + txhSortField.Text + " " + txhSortDir.Text;

        gvMain.DataSource = sFlow.GetMasterList(txtSearch.Text, orderStr);

        gvMain.DataBind();
        pcTop.Update();
        pcBot.Update();

    }
    private void SetData(WardData ftData)
    {
        txhID.Text = ftData.LOID.ToString();
        txtCode.Text = ftData.CODE;
        txtName.Text = ftData.NAME;
        txtABBName.Text = ftData.ABBNAME;
        txtBED.Text = Convert.ToString(ftData.BEDQTY);
        cmbFOODName.SelectedIndex = cmbFOODName.Items.IndexOf(cmbFOODName.Items.FindByValue(ftData.DEFAULTFOODTYPE.ToString()));
        chkActive.Checked = ftData.ACTIVE;
        chkIsLockCutOffTime.Checked = ftData.ISLOCKCUTOFFTIME;
        txtSAP.Text = ftData.SAPCODE;
    }     
   


    private bool doSave()
    {
        // verify required field
        string error = VerifyData();
        if (error != "")
        {
            SetErrorStatus(error);
            return false;
        }

        WardFlow  stFlow = new WardFlow();
        bool ret = true;

        // verify uniq field

        if (!stFlow.CheckUniqCode(txtCode.Text.Trim(), txhID.Text.Trim()))
        {
            SetErrorStatus(string.Format(DataResources.MSGEI015, "รหัสหอผู้ป่วย", this.txtCode.Text.Trim()));
            return false;
        }
         else if (!stFlow.CheckUniqName(txtName.Text.Trim(), txhID.Text.Trim()))
        {
            SetErrorStatus(string.Format(DataResources.MSGEI015, "ชื่อหอผู้ป่วย", this.txtName.Text.Trim()));
            return false;
        }
         else if (!stFlow.CheckUniqABBName(txtABBName.Text.Trim(), txhID.Text.Trim()))
        {
            SetErrorStatus(string.Format(DataResources.MSGEI015, "ชื่อย่อ", this.txtABBName.Text.Trim()));
            return false;
        }

        // data correct go on saving...
        if (txhID.Text.Trim() == "")
        {

            //  save new
            ret = stFlow.InsertData(GetData(), Appz.CurrentUser);
        }
        else
        {
            // save update
            ret = stFlow.UpdateData(GetData(), Appz.CurrentUser);
        }

        if (!ret)
            SetErrorStatus(stFlow.ErrorMessage);
        else
            doGetList();

        return ret;
    }

    private bool doGetDetail(string LOID)
    {
        WardFlow sFlow = new WardFlow();
        WardData sData = sFlow.GetDetails(Convert.ToDouble(LOID));

        bool ret = true;

        if (sData.LOID != 0)
        {
            SetData(sData);
        }
        else
            ret = false;

        return ret;
    }

    private string VerifyData()
    {
        string ret = "";
        WardData    fData = GetData();
        if (fData.CODE.Trim() == "")
            ret = string.Format(DataResources.MSGEI001, "รหัสหอผู้ป่วย");
        else if (fData.NAME.Trim() == "")
            ret = string.Format(DataResources.MSGEI001, "ชื่อหอผู้ป่วย");
        else if (fData.ABBNAME.Trim() == "")
            ret = string.Format(DataResources.MSGEI001, "ชื่อย่อ");
       
        return ret;
    }

    #endregion
}