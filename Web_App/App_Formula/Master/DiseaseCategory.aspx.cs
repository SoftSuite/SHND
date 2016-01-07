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
using SHND.Global;
using SHND.Flow.Common;
using SHND.Data.Common.Utilities;
/// <summary>
/// FoodType Page Class
/// Version 1.0
/// =========================================================================
/// Create by: Tan
/// Create Date: 29 Dec 2008
/// -------------------------------------------------------------------------
/// Modify By: -
/// Modify From: -
/// Modify Date: -
/// -------------------------------------------------------------------------
/// Remark: -
/// Description:
///    หน้ากาารทำงานข้อมูล Disease Category 
/// Changes:
///    1.0 - สร้าง
/// -------------------------------------------------------------------------
/// =========================================================================
/// </summary>
/// 
public partial class App_Formula_Master_DiseaseCategory : System.Web.UI.Page
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
        Appz.BuildCombo(cmbUnit, "UNIT", "ABBNAME", "LOID", "ACTIVE='1'", "ABBNAME", "ไม่ระบุ", "0", false);
        pcTop.SetMainGridView(gvMain);
        pcBot.SetMainGridView(gvMain);
    }

    #region Button Click Event Handler
    protected void tbSave1Click(object sender, EventArgs e)
    {
        if (!doSave())
            zPop.Show();
        else
            ClearData();
    }
    protected void tbSave2Click(object sender, EventArgs e)
    {
        if (doSave())
            ClearData();
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
    protected void lnkName_Click(object sender, EventArgs e)
    {
        doGetDetail(((LinkButton)sender).CommandArgument);
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

    #endregion

    #region Gridview Event Handler

    protected void gvMain_RowDataBound(object sender, GridViewRowEventArgs e)
    {
        if (e.Row.RowIndex > -1)
            e.Row.Cells[2].Text = ((e.Row.RowIndex + 1) + (gvMain.PageIndex * gvMain.PageSize)).ToString();
    }

    protected void gvMain_Sorting(object sender, GridViewSortEventArgs e)
    {
        DiseaseCategoryFlow fFlow = new DiseaseCategoryFlow();
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


    #endregion

    #region Controls Management Methods
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
        this.lblAttachRemark.Visible = true;
        attSign.Visible = false;
        txhID.Text = "";
        txtName.Text = "";
        txtDescription.Text = "";
        chkRegular.Checked = true;
        chkSoft.Checked = true;
        chkMilk.Checked = false;
        chkLight.Checked = false;
        chkLiquid.Checked = true;
        chkActive.Checked = true;
        chkSpecial.Checked = true;
        chkLimit.Checked = false;
        chkCalculate.Checked = false;
        chkIncrease.Checked = false;
        chkNeed.Checked = false;
        chkAbstain.Checked = false;
        chkRequest.Checked = false;
        chkHigh.Checked = false;
        chkLow.Checked = false;
        chkNon.Checked = false;
    }

    private void ClearSearch()
    {
        // Clear searh data
        txtSearchName.Text = "";
        txtSearchDescription.Text = "";
        rbtActive.SelectedValue = "T";
    }

    private DiseaseCategoryData GetData()
    {
        DiseaseCategoryData dcData = new DiseaseCategoryData();
        dcData.LOID = Convert.ToDouble("0" + txhID.Text);
        dcData.ACTIVE = chkActive.Checked;
        dcData.ABBNAME = txtName.Text;
        dcData.DESCRIPTION = txtDescription.Text;
        dcData.ISREGULAR = chkRegular.Checked;
        dcData.ISSOFT = chkSoft.Checked;
        dcData.ISMILK = chkMilk.Checked;
        dcData.ISLIGHT = chkLight.Checked;
        dcData.ISLIQUID = chkLiquid.Checked;
        dcData.ISSPECIAL = chkSpecial.Checked;
        dcData.ISLIMIT = chkLimit.Checked;
        dcData.ISCALCULATE = chkCalculate.Checked;
        dcData.ISINCREASE = chkIncrease.Checked;
        dcData.ISNEED = chkNeed.Checked;
        dcData.ISABSTAIN = chkAbstain.Checked;
        dcData.ISREQUEST = chkRequest.Checked;
        dcData.ISHIGH = chkHigh.Checked;
        dcData.ISLOW = chkLow.Checked;
        dcData.ISNON = chkNon.Checked;
        dcData.IMGSYMBOL = txtAttachCode.Text;
        dcData.UNIT = Convert.ToDouble(cmbUnit.SelectedValue);
        return dcData;
    }

    private void SetData(DiseaseCategoryData dcData)
    {
        txhID.Text = dcData.LOID.ToString();
        chkActive.Checked = dcData.ACTIVE;
        txtName.Text = dcData.ABBNAME;
        txtDescription.Text = dcData.DESCRIPTION;
        chkRegular.Checked = dcData.ISREGULAR;
        chkSoft.Checked = dcData.ISSOFT;
        chkMilk.Checked = dcData.ISMILK;
        chkLight.Checked = dcData.ISLIGHT;
        chkLiquid.Checked = dcData.ISLIQUID;
        chkSpecial.Checked = dcData.ISSPECIAL;
        chkLimit.Checked = dcData.ISLIMIT;
        chkCalculate.Checked = dcData.ISCALCULATE;
        chkIncrease.Checked = dcData.ISINCREASE;
        chkNeed.Checked = dcData.ISNEED;
        chkAbstain.Checked = dcData.ISABSTAIN;
        chkRequest.Checked = dcData.ISREQUEST;
        chkHigh.Checked = dcData.ISHIGH;
        chkLow.Checked = dcData.ISLOW;
        chkNon.Checked = dcData.ISNON;
        cmbUnit.SelectedValue = dcData.UNIT.ToString();
        txtAttachCode.Text = dcData.IMGSYMBOL;
        attSign.UniqID = dcData.LOID.ToString();
        attSign.AllowMultiUpload = false;
        if (dcData.LOID != 0)
        {
            this.lblAttachRemark.Visible = false;
            attSign.Visible = true;
        }
    }

    #endregion

    #region Working Method

    private void doGetList()
    {
        DiseaseCategoryFlow fFlow = new DiseaseCategoryFlow();

        // ตรวจสอบเงื่อนไขการค้นหาเพื่อแสดงปุ่ม reset การค้นหา
        imbReset.Visible = (txtSearchName.Text.Trim() != "") || (txtSearchDescription.Text.Trim() != "" ) || (rbtActive.SelectedValue !="T");

        string orderStr = "";
        if (txhSortField.Text.Trim() != "")
            orderStr = " " + txhSortField.Text + " " + txhSortDir.Text;

        gvMain.DataSource = fFlow.GetMasterList(txtSearchName.Text, txtSearchDescription.Text, rbtActive.SelectedValue,"", orderStr);
        gvMain.DataBind();
        pcTop.Update();
        pcBot.Update();
    }

    private bool doGetDetail(string LOID)
    {
        DiseaseCategoryFlow fFlow = new DiseaseCategoryFlow();
        DiseaseCategoryData fData = fFlow.GetDetails(Convert.ToDouble(LOID));

        bool ret = true;

        if (fData.LOID != 0)
        {
            SetData(fData);
        }
        else
            ret = false;

        return ret;
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

 
        //if (attSign.doUpload())
        //    txtAttachCode.Text = attSign.AttachCode;

        DiseaseCategoryFlow dcFlow = new DiseaseCategoryFlow();
        bool ret = true;

        // verify uniq field
        if (!dcFlow.CheckUniqCode(txtName.Text.Trim(), txhID.Text.Trim()))
        {
            SetErrorStatus(string.Format(DataResources.MSGEI015, "ชื่อสารอาหาร", this.txtName.Text.Trim()));
            return false;
        }

        // data correct go on saving...
        if (txhID.Text.Trim() == "")
        {

            //  save new
            ret = dcFlow.InsertData(GetData(), Appz.CurrentUser);
        }
        else
        {
            // save update
            ret = dcFlow.UpdateData(GetData(), Appz.CurrentUser);
        }

        if (!ret)
            SetErrorStatus(dcFlow.ErrorMessage);
        else
            doGetList();

        return ret;
    }

    private void doDelete()
    {
        DiseaseCategoryFlow fFlow = new DiseaseCategoryFlow();
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

    private string VerifyData()
    {
        string ret = "";
        DiseaseCategoryData dcData = GetData();
        if (dcData.ABBNAME.Trim() == "")
            ret = string.Format(DataResources.MSGEI001, "ชื่อ");
        else if (dcData.DESCRIPTION == "")
            ret = string.Format(DataResources.MSGEI001, "รายละเอียดเพิ่มเติม");

        return ret;
    }

    #endregion
}
