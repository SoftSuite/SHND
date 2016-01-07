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
using SHND.Data.Views  ;
using SHND.Global;
using SHND.Flow.Common;
using SHND.Data.Common.Utilities;


/// <summary>
/// Supplier Page Class
/// Version 1.0
/// =========================================================================
/// Create by: Somsakoon
/// Create Date: 25 Mar 2009
/// -------------------------------------------------------------------------
/// Modify By: -
/// Modify From: -
/// Modify Date: -
/// -------------------------------------------------------------------------
/// Remark: -
/// Description:
///    หน้ากาารทำงานข้อมูล  FoodTypePrice  
/// Changes:
///    1.0 - สร้าง
/// -------------------------------------------------------------------------
/// =========================================================================
/// </summary>
/// 

public partial class App_Admin_Master_FoodTypePrice : System.Web.UI.Page
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
        
        Appz.BuildCombo(cmbDiv, "DIVISION", "NAME", "LOID", "ISNUTRIENT ='Y'", "", "ทั้งหมด", "0", false);
        pcTop.SetMainGridView(gvMain);
        pcBot.SetMainGridView(gvMain);
    }

    #region Button Click Event Handler

    protected void imbSearch_Click1(object sender, EventArgs e)
    {
        gvMain.PageIndex = 0;
        doGetList();
    }
    protected void tbSaveClick(object sender, EventArgs e)
    {
        if (doSave())
            ClearSearch();
    }
    protected void linkCode_Click(object sender, EventArgs e)
    {
        // doGetDetail(((LinkButton)sender).CommandArgument);

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
            e.Row.Cells[1].Text = ((e.Row.RowIndex + 1) + (gvMain.PageIndex * gvMain.PageSize)).ToString();
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



    #region Controls Management Methods

    private void ClearSearch()
    {
        cmbDiv.SelectedItem.Value = "0";
        txtFoodType.Text = "";    
    }

    public ArrayList GetFoodPriceData()
    {
        ArrayList arrData = new ArrayList();
       
            for (int i = 0; i < gvMain.Rows.Count ; ++i)
            {
                VFoodTypePriceData VFoodTypePrice = new VFoodTypePriceData();
                VFoodTypePrice.LOID = Convert.ToDouble(gvMain.Rows[i].Cells[0].Text );
                VFoodTypePrice.CODE = gvMain.Rows[i].Cells[2].ToString();
                VFoodTypePrice.NAME = gvMain.Rows[i].Cells[3].ToString();
                
                VFoodTypePrice.DIVISIONNAME = gvMain.Rows[i].Cells[3].ToString();
                VFoodTypePrice.PRICE = Convert.ToDouble(((TextBox)gvMain.Rows[i].Cells[5].FindControl("txtPrice")).Text);
                if (((RadioButton)gvMain.Rows[i].Cells[6].FindControl("radDA")).Checked)
                    VFoodTypePrice.PRICETYPE = "DA";
                else if (((RadioButton)gvMain.Rows[i].Cells[6].FindControl("radME")).Checked)
                    VFoodTypePrice.PRICETYPE = "ME";

                arrData.Add(VFoodTypePrice);
            }
      
        return arrData;
    }
    private void SetErrorStatus(string t)
    {
        lbStatus.Text = t;
        lbStatus.ForeColor = Constant.StatusColor.Error;
    }

    private VFoodTypePriceData  GetData()
    {
        VFoodTypePriceData sData = new VFoodTypePriceData();
        sData.LOID = Convert.ToDouble("0" + txhID.Text);
        return sData;
    }
    private void SetData(double division)
    {
        VFoodTypePriceData ftData = new VFoodTypePriceData();
        txhID.Text = ftData.LOID.ToString();
    }

    #endregion

    #region Working Method

    private void doGetList()
    {
        FoodTypePriceFlow sFlow = new FoodTypePriceFlow();

        imbReset.Visible = (cmbDiv.SelectedItem.Value != "0" || txtFoodType.Text.Trim() != "");

        string orderStr = "";
        if (txhSortField.Text.Trim() != "")
            orderStr = " " + txhSortField.Text + " " + txhSortDir.Text;

        gvMain.DataSource = sFlow.GetMasterList(txtFoodType.Text, cmbDiv.SelectedItem.Value, orderStr);

        gvMain.DataBind();
        pcTop.Update();
        pcBot.Update();
       
    }

    private bool doSave()
    {
        bool ret = true;
        FoodTypePriceFlow stFlow = new FoodTypePriceFlow();
        
        ret = stFlow.UpdateData(GetFoodPriceData(), Appz.CurrentUser);

        if (!ret)
            SetErrorStatus(stFlow.ErrorMessage);
        else
            doGetList();

        return ret;
    }

    #endregion

}
