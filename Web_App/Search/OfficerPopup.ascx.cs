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
using SHND.Data.Search;
using SHND.Data.Views;
using SHND.Flow.Search;
using SHND.Global;

/// <summary>
/// OfficerPopup Page Class
/// Version 1.0
/// =========================================================================
/// Create by: Teang
/// Create Date: 3 Feb 2009
/// -------------------------------------------------------------------------
/// Modify By: -
/// Modify From: -
/// Modify Date: -
/// -------------------------------------------------------------------------
/// Remark: -
/// Description:
///    ˹�Ҥ��� ���������˹�ҷ�� (Offcer)
/// Changes:
///    1.0 - ���ҧ
/// -------------------------------------------------------------------------
/// =========================================================================
/// </summary>
/// 
public partial class Search_OfficerPopup : System.Web.UI.UserControl
{
    public delegate void SelectedIndexChangedEvent(object sender, EventArgs e, ArrayList SelectedData);
    public event SelectedIndexChangedEvent SelectedIndexChanged;

    protected void Page_Load(object sender, EventArgs e)
    {

    }

    protected override void OnInit(EventArgs e)
    {
        base.OnInit(e);
        Appz.BuildCombo(this.cmbSearchDivision, "DIVISION", "NAME", "LOID", "ACTIVE = '1'", "NAME", "������", "0", false);
        pcBot.SetMainGridView(gvMain);
        pcTop.SetMainGridView(gvMain);
    }

    #region Button Click Event Handler

    protected void tbBackClick(object sender, EventArgs e)
    {
    }

    protected void tbAddClick(object sender, EventArgs e)
    {
        if (SelectedIndexChanged != null) SelectedIndexChanged(sender, e, GetSelectedData());
    }

    protected void imbSearch_Click(object sender, ImageClickEventArgs e)
    {
        gvMain.PageIndex = 0;
        doGetList();
        popupOfficer.Show();
    }

    protected void imbReset_Click(object sender, ImageClickEventArgs e)
    {
        ClearSearch();
        gvMain.PageIndex = 0;
        doGetList();
        popupOfficer.Show();
    }

    #endregion

    #region Gridview Event Handler

    protected void gvMain_RowDataBound(object sender, GridViewRowEventArgs e)
    {
        if (e.Row.RowType == DataControlRowType.Header)
        {
            ((CheckBox)e.Row.Cells[1].FindControl("chkAll")).Attributes.Add("onclick", "chkAllBox(this, '" + this.gvMain.ClientID + "_ctl', '_chkSelect')");
        }
        else if (e.Row.RowType == DataControlRowType.DataRow)
        {
            e.Row.Cells[2].Text = ((e.Row.RowIndex + 1) + (gvMain.PageIndex * gvMain.PageSize)).ToString();
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
        popupOfficer.Show();
    }

    #endregion

    #region Paging Event Handler

    protected void PageChange(object sender, EventArgs e)
    {
        gvMain.PageIndex = ((Templates_PageControl)sender).SelectedPageIndex;
        doGetList();
        pcBot.Update();
        pcTop.Update();
        popupOfficer.Show();
    }

    #endregion

    #region Misc. Methods

    private ArrayList GetSelectedData()
    {
        ArrayList arrChk = new ArrayList();
        for (int i = 0; i < gvMain.Rows.Count; i++)
        {
            if (i > -1 && gvMain.Rows[i].Cells[0].FindControl("chkSelect") != null)
            {
                GridViewRow gRow = gvMain.Rows[i];
                if (((CheckBox)gRow.Cells[1].FindControl("chkSelect")).Checked)
                {
                    VOfficerData officer = new VOfficerData();
                    officer.ACTIVE = "";
                    officer.ACTIVENAME = "";
                    officer.DIVISION = Convert.ToDouble("0" + gRow.Cells[6].Text);
                    officer.DIVISIONNAME = gRow.Cells[4].Text;
                    officer.EMAIL = gRow.Cells[12].Text;
                    officer.FIRSTNAME = gRow.Cells[8].Text;
                    officer.LASTNAME = gRow.Cells[9].Text;
                    officer.LOID = Convert.ToDouble("0" + gRow.Cells[0].Text);
                    officer.OFFICERGROUP = gRow.Cells[10].Text;
                    officer.OFFICERGROUPNAME = gRow.Cells[5].Text;
                    officer.OFFICERNAME = gRow.Cells[3].Text;
                    officer.PASSWD = "";
                    officer.TEL = gRow.Cells[11].Text;
                    officer.TITLE = Convert.ToDouble("0" + gRow.Cells[7].Text);
                    officer.USERNAME = "";
                    arrChk.Add(officer);
                }
            }
        }
        return arrChk;
    }

    #endregion

    #region Controls Management Methods

    private void ClearSearch()
    {
        this.cmbSearchDivision.SelectedIndex = 0;
        this.txtSearchOfficerName.Text = "";
    }

    public void Show(string existKeyList)
    {
        this.txtExistKeyList.Text = existKeyList;
        ClearSearch();

        gvMain.PageIndex = 0;
        doGetList();
        popupOfficer.Show();
    }

    #endregion

    #region Working Method

    private void doGetList()
    {
        SearchFlow fFlow = new SearchFlow();

        // ��Ǩ�ͺ���͹䢡�ä��������ʴ����� reset ��ä���
        imbReset.Visible = (this.cmbSearchDivision.SelectedIndex != 0) || (txtSearchOfficerName.Text.Trim() != "");

        string orderStr = "";
        if (txhSortField.Text.Trim() != "")
            orderStr = " " + txhSortField.Text + " " + txhSortDir.Text;
        gvMain.DataSource = fFlow.GetOfficerList(this.txtSearchOfficerName.Text.Trim(), Convert.ToDouble(this.cmbSearchDivision.SelectedItem.Value), this.txtExistKeyList.Text, orderStr);
        gvMain.DataBind();
        pcBot.Update();
        pcTop.Update();
    }

    #endregion
}
