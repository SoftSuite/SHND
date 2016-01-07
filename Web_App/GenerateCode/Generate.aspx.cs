using System;
using System.Data;
using System.Configuration;
using System.Web;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Web.UI.WebControls.WebParts;
using System.Web.UI.HtmlControls;
using SHND.Flow.Utilities;
using SHND.Data.Common;
using SHND.Data.Common.Utilities;

public partial class Generate_Generate : System.Web.UI.Page
{
    OracleGenerateFlow _oracleFlow;
    SqlGenerateFlow _sqlFlow;
    GenerateConstant _const;

    private OracleGenerateFlow OracleFlow
    {
        get { if (_oracleFlow == null) { _oracleFlow = new OracleGenerateFlow(); } return _oracleFlow; }
    }

    private SqlGenerateFlow SqlFlow
    {
        get { if (_sqlFlow == null) { _sqlFlow = new SqlGenerateFlow(); } return _sqlFlow; }
    }

    private GenerateConstant Constant
    {
        get { if (_const == null) { _const = new GenerateConstant(); } return _const; }
    }

    private void SetLanguage()
    {
        this.txtServerWatermark.WatermarkText = Constant.DataSourceWaterMarkText;
        this.txtDatabaseWatermark.WatermarkText = Constant.DatabaseWaterMarkText;
        this.txtUserIDWatermark.WatermarkText = Constant.UserIDWaterMarkText;
        this.txtPasswordWatermark.WatermarkText = Constant.PasswordWaterMarkText;
        this.txtTableWatermark.WatermarkText = Constant.TableNameWaterMarkText;
        this.txtNamespaceWatermark.WatermarkText = Constant.NameSpaceWaterMarkText;
        this.txtClassWatermark.WatermarkText = Constant.ClassWaterMarkText;
        string script = "";
        script += "if (document.getElementById('" + this.txtServer.ClientID + "').value == '' || document.getElementById('" + this.txtServer.ClientID + "').value == '" + this.txtServerWatermark.WatermarkText + "') ";
        script += "{ alert('" + Constant.DataSourceRequire + "'); return false; }";
        script += "else if (document.getElementById('" + this.rdbSql.ClientID + "').checked && (document.getElementById('" + this.txtDatabase.ClientID + "').value == '' || document.getElementById('" + this.txtDatabase.ClientID + "').value == '" + this.txtDatabaseWatermark.WatermarkText + "')) ";
        script += "{ alert('" + Constant.DatabaseRequire + "'); return false; }";
        script += "else if (document.getElementById('" + this.txtUserID.ClientID + "').value == '' || document.getElementById('" + this.txtUserID.ClientID + "').value == '" + this.txtUserIDWatermark.WatermarkText + "') ";
        script += "{ alert('" + Constant.UserIDRequire + "'); return false; }";
        script += "else if (document.getElementById('" + this.txtPassword.ClientID + "').value == '' || document.getElementById('" + this.txtPassword.ClientID + "').value == '" + this.txtPasswordWatermark.WatermarkText + "') ";
        script += "{ alert('" + Constant.PasswordRequire + "'); return false; }";
        script += "else if (document.getElementById('" + this.txtTable.ClientID + "').value == '' || document.getElementById('" + this.txtTable.ClientID + "').value == '" + this.txtTableWatermark.WatermarkText + "') ";
        script += "{ alert('" + Constant.TableRequire + "'); return false; }";
        script += "else if (document.getElementById('" + this.txtClass.ClientID + "').value == '' || document.getElementById('" + this.txtClass.ClientID + "').value == '" + this.txtClassWatermark.WatermarkText + "') ";
        script += "{ alert('" + Constant.ClassRequire + "'); return false; }";
        this.btnGenerateDAL.OnClientClick = script;
        this.btnGenerateData.OnClientClick = script;
    }

    protected override void OnInit(EventArgs e)
    {
        base.OnInit(e);
        if (Context.Session != null)
        {
            if (Session.IsNewSession)
            {
                string szCookieHeader = Request.Headers["Cookie"];
                if ((null != szCookieHeader) && (szCookieHeader.IndexOf("ASP.NET_SessionId") >= 0))
                {
                    this.txtCode.Text = "session timeout";
                }
            }
        }
    }

    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            SetLanguage();
        }
    }

    private GenerateData GetData(string type)
    {
        GenerateData data = new GenerateData();
        data.DataSource = this.txtServer.Text.Trim();
        data.Database = this.txtDatabase.Text.Trim();
        data.UserID = this.txtUserID.Text.Trim();
        data.Password = this.txtPassword.Text.Trim();
        data.TableName = this.txtTable.Text.Trim();
        data.NameSpace = "SHND." + type + (this.txtNamespace.Text.Trim() == "" ? "" : ".") + this.txtNamespace.Text.Trim();
        data.ClassName = this.txtClass.Text.Trim();
        data.UserHostName = Request.UserHostName; //.Substring(0, Request.LogonUserIdentity.Name.IndexOf("\\"));
        data.ProjectName = "SHND";
        return data;
    }

    protected void btnGenerateDAL_Click(object sender, EventArgs e)
    {
        this.txtCode.Text = "";
        try
        {
            if (rdbSql.Checked)
                this.txtCode.Text = SqlFlow.GenerateDAL(GetData("DAL"));
            else
                this.txtCode.Text = OracleFlow.GenerateDAL(GetData("DAL"));
            //lblTest.Text = this.txtCode.Text.Replace("<", "&lt;").Replace(">", "&gt;").Replace("\n", "<br/>").Replace(" ", "&nbsp;");
        }
        catch (Exception ex)
        {
            this.txtCode.Text = ex.Message;
        }
    }

    protected void btnGenerateData_Click(object sender, EventArgs e)
    {
        this.txtCode.Text = "";
        try
        {
            if (rdbSql.Checked)
                this.txtCode.Text = SqlFlow.GenerateData(GetData("Data"));
            else
                this.txtCode.Text = OracleFlow.GenerateData(GetData("Data"));

            //lblTest.Text = this.txtCode.Text.Replace("<", "&lt;").Replace(">", "&gt;").Replace("\n", "<br/>").Replace(" ", "&nbsp;");
        }
        catch (Exception ex)
        {
            this.txtCode.Text = ex.Message;
        }
    }
}
