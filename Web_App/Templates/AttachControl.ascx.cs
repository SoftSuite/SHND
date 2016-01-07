using System;
using System.Data;
using System.Configuration;
using System.Collections;
using System.IO;
using System.Web;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Web.UI.WebControls.WebParts;
using System.Web.UI.HtmlControls;

public partial class Templates_AttachControl : System.Web.UI.UserControl
{
    protected void Page_Load(object sender, EventArgs e)
    {
        BuildHtml();
    }

    // configurations ---------------
    private string attPath = ConfigurationManager.AppSettings["AttachWebURL"];
    private string attPhyPath = ConfigurationManager.AppSettings["AttachPhysical"];
    //private int maxFileSize = 5 * 1024 * 1024; // 5 mb
    // ------------------------------

    private string _error = "";
    public string ErrorMessage { get { return _error; } }

    #region Public Properties

    private bool _allowMultiUpload = true;
    private bool _allowDelete = true;
    private bool _readOnly = false;
    private bool _showIcon = false;
    private bool _enabled = true;
    private bool _overwrite = true;
    private string _ref1 = "";
    private string _ref2 = "";
    private string _uniqID = "";
    private int _height = 0;
    private string _cusError = "No Uniq ID Given.";

    public int Height
    {
        get { return _height; }
        set { _height = value; BuildHtml(); }
    }

    public bool AllowMultiUpload
    {
        get { return _allowMultiUpload; }
        set { _allowMultiUpload = value; BuildHtml(); }
    }
    public bool AllowDelete
    {
        get { return _allowDelete; }
        set { _allowDelete = value; BuildHtml(); }
    }
    public bool ReadOnly
    {
        get { return _readOnly; }
        set { _readOnly = value; BuildHtml(); }
    }
    public bool ShowIcon
    {
        get { return _showIcon; }
        set { _showIcon = value; BuildHtml(); }
    }
    public bool Enabled
    {
        get { return _enabled; }
        set { _enabled = value; BuildHtml(); }
    }
    public bool OverwriteExistFile
    {
        get { return _overwrite; }
        set { _overwrite = value; BuildHtml(); }
    }
    public int Count
    {
        get
        {
            SHND.Flow.Common.AttachFlow aFlow = new SHND.Flow.Common.AttachFlow();
            return aFlow.CountFile(_ref1, _ref2, _uniqID);
        }
    }
    public string FilePath
    {
        get { return attPath + _ref1 + "/" + _ref2 + "/" + _uniqID + "/"; }
    }
    public string FilePhyPath
    {
        get { return attPhyPath + _ref1 + "\\" + _ref2 + "\\" + _uniqID + "\\"; }
    }
    public string Reference1
    {
        get { return _ref1; }
        set { _ref1 = value; BuildHtml(); }
    }
    public string Reference2
    {
        get { return _ref2; }
        set { _ref2 = value; BuildHtml(); }
    }
    public string UniqID
    {
        get { return _uniqID; }
        set { _uniqID = value; BuildHtml(); }
    }
    public string CustomError
    {
        get { return _cusError; }
        set { _cusError = value; }
    }

    #endregion

    private void BuildHtml()
    {
        buildSession();
        string zhtm = "";

        if (_ref1.Trim() == "" || _ref2.Trim() == "")
            zhtm = "<font color='red'>Attach Control Configuration Error</font>";
        else if (_uniqID.Trim() == "")
            zhtm = _cusError;
        else
            zhtm += " <iframe src='" + Request.ApplicationPath + "/Templates/AttachPage.aspx?id=" + Server.UrlEncode(this.UniqID) + "' style='width:550px;" + (_height != 0 ? "height:" + _height.ToString("0") + "px;" : "") + "' frameborder='0'></iframe>";

        lblHtml.Text = zhtm;
    }

    private void buildSession()
    {
        string ss = "";
        string brk = "|";
        ss += _ref1 + brk;   // ref1
        ss += _ref2 + brk;   // ref2
        ss += _uniqID + brk;   // uniqid
        ss += (_enabled ? "1" : "0") + brk;   // enabled
        ss += (_readOnly ? "1" : "0") + brk;   // readonly
        ss += (_allowDelete ? "1" : "0") + brk;   // allow delete
        ss += (_allowMultiUpload ? "1" : "0") + brk;   // allow multiple upload
        ss += (_overwrite ? "1" : "0") + brk;   // overwrite
        ss += (_showIcon ? "1" : "0") + brk;   // showIcon
        Session[this.UniqID] = ss;
    }

    #region working function

    //private int tmpSize;
    //private string tmpName;



    #endregion

  
}
