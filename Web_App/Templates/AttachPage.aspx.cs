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
using SHND.Flow.Common;
using SHND.Global;

public partial class Templates_AttachPage : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        writeScript();
        if (Request["id"] != null && Request["id"].ToString().Trim() != "" && Session[Request["id"]] != null)
        {
            ControlID = Request["id"];
            string param = Session[ControlID].ToString();
            string[] p = param.Split('|');

            if (p.Length < 9)
            {
                pnlMain.Visible = false;
                Response.Write("Error");
            }
            else
            {
                _ref1 = p[0];
                _ref2 = p[1];
                _uniqID = p[2];
                _enabled = (p[3] == "1");
                _readOnly = (p[4] == "1");
                _allowDelete = (p[5] == "1");
                _allowMultiUpload = (p[6] == "1");
                _overwrite = (p[7] == "1");
                _showIcon = (p[8] == "1");
            }

            // check if delete button click;
            if (Request["val" + ControlID] != null)
            {
                double dId = 0;
                try
                {
                    dId = Convert.ToDouble(Request["val" + ControlID]);
                }
                catch { }

                if (dId != 0)
                    DeleteFile(dId);
            }

            SetControl();

            // retrieve data
            if (_ref1.Trim() != "" && _ref2.Trim() != "" && _uniqID.Trim() != "")
            {
                pnlMain.Visible = true;
                RefreshTable();
            }
            else
            {
                pnlMain.Visible = false;
            }
        }
        else
        {
            pnlMain.Visible = false;
            Response.Write("Error");
        }
    }

    private void SetControl()
    {
        pnlUpload.Visible = !_readOnly;
        AttachFlow aFlow = new AttachFlow();
        if (aFlow.CountFile(_ref1, _ref2, _uniqID) >= 1 && !_allowMultiUpload)
        {
            pnlUpload.Visible = false;
        }
    }

    private void RefreshTable()
    {
        AttachFlow aFlow = new AttachFlow();
        DataTable zDt = aFlow.getFileList(_ref1, _ref2, _uniqID);
        rptAttach.DataSource = zDt;
        rptAttach.DataBind();
    }

    private void DeleteFile(double id)
    {
        AttachFlow aFlow = new AttachFlow();
        string f = attPhyPath + aFlow.GetFilePath(id);

        if (File.Exists(f))
            File.Delete(f);

        if (!aFlow.DeleteAttachFile(id))
            ScriptManager.RegisterStartupScript(this.Page, typeof(UpdatePanel), "AlertMsg", "alert('" + aFlow.ErrorMessage.Replace("'", "\"").Replace("\n", "") + "');", true);
    }

    string _error = "";

    // configurations ---------------
    private string attPath = ConfigurationManager.AppSettings["AttachWebURL"];
    private string attPhyPath = ConfigurationManager.AppSettings["AttachPhysical"];
    private int maxFileSize = 5 * 1024 * 1024; // 5 mb
    // ------------------------------

    protected string ControlID = "";

    protected bool _allowMultiUpload = true;
    protected bool _allowDelete = true;
    protected bool _readOnly = false;
    protected bool _showIcon = false;
    protected bool _enabled = true;
    protected bool _overwrite = true;
    protected string _ref1 = "";
    protected string _ref2 = "";
    protected string _uniqID = "";

    public string FilePath
    {
        get { return attPath + _ref1 + "/" + _ref2 + "/" + _uniqID + "/"; }
    }
    public string FilePhyPath
    {
        get { return attPhyPath + _ref1 + "\\" + _ref2 + "\\" + _uniqID + "\\"; }
    }

    #region Working Function
    private bool doUpload()
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
            return true;
        }
        catch (Exception e)
        {
            _error = e.Message;
            return false;
        }
    }

    protected static string GetNumericDateTime(object dt)
    {
        DateTime zz = (DateTime)dt;
        return zz.ToString("dd/MM/") + zz.Year + zz.ToString(" [HH:mm]");
    }

    protected static string showSize(object sz)
    {
        string ret = "";

        double s = Convert.ToDouble(sz);
        if (s >= 1024000)
        {
            s = s / (1024 * 1024);
            ret = s.ToString("#,##0.00") + " MB";
        }
        else if (s >= 1000)
        {
            s = s / 1024;
            ret = s.ToString("#,##0.00") + " KB";
        }
        else
            ret = s.ToString("#,##0") + " B";

        return ret;
    }

    private void writeScript()
    {
        string script = @"
<script language='JavaScript'>
function ToggleVisible(objName, status)
{
    obj = document.getElementById(objName);
    if (status == null) {
        if (obj.style.display == 'none')
            obj.style.display = 'block';
        else
            obj.style.display = 'none';		
    }
    else
    {
        if (status == 1)
            obj.style.display = 'block';
        else
            obj.style.display = 'none';
    }
}
</script>
";
        Page.ClientScript.RegisterStartupScript(this.GetType(), "AttSetVisible", script);
    }
    #endregion

    private int tmpSize;
    private string tmpName;

    protected void btnUpload_Click(object sender, EventArgs e)
    {
        if (zUpload.HasFile)
        {
            if (!doUpload())
                ScriptManager.RegisterStartupScript(this.Page, typeof(UpdatePanel), "AlertMsg", "alert('" + _error.Replace("'", "\"").Replace("\n", "") + "');", true);
            else
            {
                AttachFlow aFlow = new AttachFlow();
                aFlow.DeleteAttachFile(_ref1, _ref2, _uniqID, tmpName);
                if (!aFlow.InsertAttachFile(_ref1, _ref2, _uniqID, tmpName, tmpSize, "", "SYSTEM"))
                    ScriptManager.RegisterStartupScript(this.Page, typeof(UpdatePanel), "AlertMsg", "alert('" + aFlow.ErrorMessage.Replace("'", "\"").Replace("\n", "") + "');", true);
                else
                {
                    SetControl();
                    RefreshTable();
                }
            }
        }
        else lblError.Text = "! - Please specify file";
    }
}
