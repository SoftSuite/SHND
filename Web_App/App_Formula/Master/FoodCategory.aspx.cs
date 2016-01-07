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
using SHND.Global;
using SHND.Flow.Formula;
using SHND.Data.Tables;
using SHND.Flow.Common;
using SHND.Data.Common.Utilities;

/// <summary>
/// FoodCategory Page Class
/// Version 1.0
/// =========================================================================
/// Create by: Nang
/// Create Date: 26 Dec 2008
/// -------------------------------------------------------------------------
/// Modify By: -
/// Modify From: -
/// Modify Date: -
/// -------------------------------------------------------------------------
/// Remark: -
/// Description:
///    หน้าการทำงานข้อมูล Food Category 
/// Changes:
///    1.0 - สร้าง
/// -------------------------------------------------------------------------
/// =========================================================================
/// </summary>
/// 

public partial class App_Formula_Master_FoodCategory : System.Web.UI.Page
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
        pcTop.SetMainGridView(grvResult);
        pcBot.SetMainGridView(grvResult);
       
    }

    #region Button Click Event Handler

    protected void tbSave1Click(object sender, EventArgs e)
    {
        if (!doSave())
            FoodCategoryPop.Show();
        else
        {
            ClearData();
        }
    }

    protected void imbSearch_Click(object sender, ImageClickEventArgs e)
    {
        grvResult.PageIndex = 0;
        doGetList();
    }
    protected void imbReset_Click(object sender, ImageClickEventArgs e)
    {
        ClearSearch();
        grvResult.PageIndex = 0;
        doGetList();
    }
    protected void tbSave2Click(object sender, EventArgs e)
    {
        if (doSave())
            ClearData();
        FoodCategoryPop.Show();
    }

    protected void lnkFood_Click(object sender, EventArgs e)
    {
        doGetDetail(((LinkButton)sender).CommandArgument);
        FoodCategoryPop.Show();
    }

    protected void tbAddClick(object sender, EventArgs e)
    {
        FoodCategoryPop.Show();
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

        FoodCategoryPop.Show();
    }

    protected void tbBackClick(object sender, EventArgs e)
    {
        ClearData();
    }

    #endregion


    #region Gridview Event Handler

    protected void grvResult_Sorting(object sender, GridViewSortEventArgs e)
    {
       // FoodCategoryFlow fFlow = new FoodCategoryFlow();
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

    protected void grvResult_RowDataBound(object sender, GridViewRowEventArgs e)
    {
        if (e.Row.RowIndex > -1)
            e.Row.Cells[2].Text = ((e.Row.RowIndex + 1) + (grvResult.PageIndex * grvResult.PageSize)).ToString();
    }
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
    private ArrayList GetChecked()
    {
        ArrayList arrChk = new ArrayList();
        for (int i = 0; i < grvResult.Rows.Count; i++)
        {
            if (i > -1 && grvResult.Rows[i].Cells[0].FindControl("chkSelect") != null)
            {
                if (((CheckBox)grvResult.Rows[i].Cells[1].FindControl("chkSelect")).Checked)
                    arrChk.Add(grvResult.Rows[i].Cells[0].Text);
            }
        }

        return arrChk;
    }


    #endregion

    #region Controls Management Methods

    private void SetData(FoodCategoryData ftData)
    {
        txhID.Text = ftData.LOID.ToString();
        chkActive.Checked = ftData.ACTIVE;
        txtCode.Text = ftData.CODE;
        txtName.Text = ftData.NAME;
    }

    private void SetErrorStatus(string t)
    {
        lbStatus.Text = t;
        lbStatus.ForeColor = Constant.StatusColor.Error;
    }
    private void ClearSearch()
    {
        txtSearchName.Text = "";
    }
    private void ClearData()
    {
        txhID.Text = "";
        txtName.Text = "";
        txtCode.Text = "";
        chkActive.Checked = true;
    }

    private FoodCategoryData GetData()
    {
        FoodCategoryData ftData = new FoodCategoryData();
        ftData.LOID = Convert.ToDouble("0" + txhID.Text);
        ftData.ACTIVE = chkActive.Checked;
        ftData.CODE = txtCode.Text;
        ftData.NAME = txtName.Text;
        return ftData;
    }

    #endregion

    #region Working Method

    private void doGetList()
    {
        FoodCategoryFlow fFlow = new FoodCategoryFlow();

        // ตรวจสอบเงื่อนไขการค้นหาเพื่อแสดงปุ่ม reset การค้นหา
        imbReset.Visible = (txtSearchName.Text.Trim() != "");

        string orderStr = "";
        if (txhSortField.Text.Trim() != "")
            orderStr = " " + txhSortField.Text + " " + txhSortDir.Text;

        grvResult.DataSource = fFlow.GetCategorySearch(txtSearchName.Text.Trim(),orderStr );
        grvResult.DataBind();
        pcTop.Update();
        pcBot.Update();
    }

    private bool doGetDetail(string LOID)
    {
        FoodCategoryFlow fFlow = new FoodCategoryFlow();
        FoodCategoryData fData = fFlow.GetDetails(Convert.ToDouble(LOID));

        bool ret = true;

        if (fData.LOID != 0)
        {
            SetData(fData);
        }
        else
            ret = false;

        return ret;
    }

    private void doDelete()
    {
        FoodCategoryFlow fFlow = new FoodCategoryFlow();
        if (fFlow.DeleteByLOID(GetChecked()))
        {
            grvResult.PageIndex = 0;
            doGetList();
            lbStatusMain.Text = "";
        }
        else
        {
            lbStatusMain.Text = fFlow.ErrorMessage;
            lbStatusMain.ForeColor = System.Drawing.Color.Red;
        }
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

        FoodCategoryFlow ftFlow = new FoodCategoryFlow();
        bool ret = true;

        // verify uniq field
        if (!ftFlow.CheckUniqCode(txtCode.Text.Trim(), txhID.Text.Trim()))
        {
            SetErrorStatus(string.Format(DataResources.MSGEI015, "รหัสชนิดอาหาร", this.txtCode.Text.Trim()));
            return false;
        }

        if (!ftFlow.CheckUniqName(txtName.Text.Trim(), txhID.Text.Trim()))
        {
            SetErrorStatus(string.Format(DataResources.MSGEI015, "ชื่อชนิดอาหาร", this.txtName.Text.Trim()));
            return false;
        }

        // data correct go on saving...
        if (txhID.Text.Trim() == "")
        {
            //  save new
            ret = ftFlow.InsertData(GetData(), Appz.CurrentUser);
        }
        else
        {
            // save update
            ret = ftFlow.UpdateData(GetData(), Appz.CurrentUser);
        }

        if (!ret)
            SetErrorStatus(ftFlow.ErrorMessage);

        else
        {
           
            doGetList();
        }
            
        return ret;
    }

    private string VerifyData()
    {
        string ret = "";
        FoodCategoryData fData = GetData();
       if (fData.NAME.Trim() == "")
        ret = string.Format(DataResources.MSGEI001, "ชื่อชนิดอาหาร");

        return ret;
    }

    #endregion


  
}
