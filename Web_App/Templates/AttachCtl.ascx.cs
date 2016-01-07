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
using System.IO;

public partial class Templates_AttachCtl : System.Web.UI.UserControl
{
    protected void Page_Load(object sender, EventArgs e)
    {

    }

    string _ref1 = "";
    string _ref2 = "";
    string _ID = "";
    string _error = "";
    bool _overwrite = true;
    private string attPath = ConfigurationManager.AppSettings["AttachWebURL"];
    private string attPhyPath = ConfigurationManager.AppSettings["AttachPhysical"];
    private int maxFileSize = 5 * 1024 * 1024; // 5 mb

    public string Reference1
    {
        get { return _ref1; }
        set { _ref1 = value; }
    }

    public string Reference2
    {
        get { return _ref2; }
        set { _ref2 = value; }
    }

    public string zID
    {
        get { return _ID; }
        set { _ID = value; }
    }

    public Unit Width
    {
        get { return zUpload.Width; }
        set { zUpload.Width = value; }
    }

    public string FilePhyPath
    {
        get { return attPhyPath + _ref1 + "\\" + _ref2 + "\\" + _ID + "\\"; }
    }

    public string ErrorMessage
    {
        get { return _error; }
    }

    public string AttachCode
    {
        get 
        {
            return _ref1 + "|" + _ref2 + "|" + _ID;            
        }
        set
        {
            string tmp = value;
            string[] aTmp = tmp.Split('|');
            if (aTmp.Length == 3)
            {
                _ref1 = aTmp[0];
                _ref2 = aTmp[1];
                _ID = aTmp[2];
            }
        }
    }

    int tmpSize = 0;
    string tmpName = "";

    public bool doUpload()
    {
        if (FilePhyPath.Trim() == "")
        {
            _error = "Destination folder not specified";
            return false;
        }
        try
        {
            string fileName = zUpload.FileName;

            if (!Directory.Exists(FilePhyPath)) // Check Directory Existing
            {
                Directory.CreateDirectory(FilePhyPath);
            }
            if (File.Exists(FilePhyPath + fileName)) // Check for file Existing
            {
                if (_overwrite)
                    File.Delete(FilePhyPath + fileName);
                else
                {
                    _error = "File existed.";
                    return false;
                }
            }

            if (zUpload.PostedFile.ContentLength > maxFileSize)
            {
                _error = "File too big";
                return false;
            }
            zUpload.PostedFile.SaveAs(FilePhyPath + fileName);
            tmpSize = zUpload.PostedFile.ContentLength;
            tmpName = zUpload.PostedFile.FileName;
            string[] tmp = tmpName.Split('\\');
            tmpName = tmp[tmp.Length - 1];
            _ID = tmpName;
            return true;
        }
        catch (Exception e)
        {
            _error = e.Message;
            return false;
        }
    }


}
