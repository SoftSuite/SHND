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

/// <summary>
/// Page Control 
/// Version 1.1
/// =========================================================================
/// Create by: TurBoZ
/// Create Date: 25 Dec 2008
/// -------------------------------------------------------------------------
/// Modify By: Teang
/// Modify From: -
/// Modify Date: 5 Jan 2009
/// -------------------------------------------------------------------------
/// Remark: -
/// Description:
///    �Ѵ��á������¹˹�Ңͧ GridView 
/// Changes:
///    1.1 - �ʴ��ӹǹ��¡�ûѨ�غѹ ��� ��¡�÷����� (��¡�÷�� x - y �ҡ z ��¡��)
///    1.0 - ���ҧ
/// -------------------------------------------------------------------------
/// =========================================================================
/// </summary>
/// 

public partial class Templates_PageControl : System.Web.UI.UserControl
{
    protected void Page_Load(object sender, EventArgs e)
    {

    }

    public event EventHandler PageChange;

    public string TotalPage
    {
        get { return lblTotalPage.Text; }
        set { lblTotalPage.Text = value; }
    }

    GridView gvMain = null;

    public void SetMainGridView(GridView gv)
    {
        gvMain = gv;
    }
 
    public void Update()
    {
        if (gvMain != null)
        {
            if (gvMain.PageCount > 0)
            {
                this.Visible = true;
                int curPage = gvMain.PageIndex;
                lblTotalPage.Text = gvMain.PageCount.ToString(Constant.IntFormat);
                buildPageCombo(gvMain.PageCount);
                cmbPage.SelectedIndex = curPage;
                lnbBack.Enabled = (curPage != 0);
                lnbNext.Enabled = (curPage < gvMain.PageCount - 1);
                lblSummary.Text = "��¡�÷�� " + ((gvMain.PageIndex * gvMain.PageSize) + 1).ToString(Constant.IntFormat) + " - " + ((gvMain.PageIndex * gvMain.PageSize) + gvMain.Rows.Count).ToString(Constant.IntFormat) + " �ҡ " + ((DataTable)gvMain.DataSource).Rows.Count.ToString(Constant.IntFormat) + " ��¡��";
            }
            else
                this.Visible = false;
        }
    }

    public void Update(int curPage, int total, int pageSize, int rowCount)
    {
        int pageCount = 0;
        if (gvMain != null)
        {
            pageCount = Convert.ToInt32(Math.Ceiling(Convert.ToDecimal(total) / Convert.ToDecimal(pageSize)));
            if (pageCount > 0)
            {
                this.Visible = true;
                lblTotalPage.Text = pageCount.ToString(Constant.IntFormat);
                buildPageCombo(pageCount);
                cmbPage.SelectedIndex = curPage;
                lnbBack.Enabled = (curPage != 0);
                lnbNext.Enabled = (curPage < pageCount - 1);
                lblSummary.Text = "��¡�÷�� " + ((curPage * pageSize) + 1).ToString(Constant.IntFormat) + " - " + ((curPage * pageSize) + rowCount).ToString(Constant.IntFormat) + " �ҡ " + total.ToString(Constant.IntFormat) + " ��¡��";
            }
            else
                this.Visible = false;
        }
    }

    private void buildPageCombo(int maxPage)
    {
        cmbPage.Items.Clear();
        for (int i = 0; i < maxPage; i++)
        {
            int p = i+1;
            cmbPage.Items.Add(new ListItem(p.ToString(), p.ToString()));
        }
    }

    public int SelectedPageIndex
    {
        get { return cmbPage.SelectedIndex; }
    }
    protected void cmbPage_SelectedIndexChanged(object sender, EventArgs e)
    {
        if (PageChange != null)
            PageChange(this, e);
    }
    protected void lnbNext_Click(object sender, EventArgs e)
    {
        cmbPage.SelectedIndex = cmbPage.SelectedIndex + 1;
        if (PageChange != null)
            PageChange(this, e);
    }
    protected void lnbBack_Click(object sender, EventArgs e)
    {
        cmbPage.SelectedIndex = cmbPage.SelectedIndex - 1;
        if (PageChange != null)
            PageChange(this, e);
    }
}
