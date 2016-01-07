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
using SHND.Flow.Common;

public partial class Templates_GetAttachFile : System.Web.UI.Page
{
    private string attPhyPath = ConfigurationManager.AppSettings["AttachPhysical"];

    protected void Page_Load(object sender, EventArgs e)
    {
        if (Request["id"] != null && Request["id"].Trim() != "")
        {
            double id = 0;
            try
            {
                id = Convert.ToDouble(Request["id"]);
            }
            catch { }


            if (id != 0)
            {

                AttachFlow aFlow = new AttachFlow();
                string f = attPhyPath + aFlow.GetFilePath(id);
                if (File.Exists(f))
                {
                    string[] tmp = f.Split('\\');
                    string fn = tmp[tmp.Length - 1];
                    Response.Clear();
                    Response.AppendHeader("content-disposition", "inline; filename=" + fn.Replace(" ", "_"));
                    Response.ContentType = MimeType(f);
                    FileInfo fi = new FileInfo(f);
                    Response.WriteFile(f, 0, fi.Length);
                    Response.End();
                    //Response.Write(f);
                }
                else
                {


                    // file not exists
                    Response.Write("Error! - File not exists!");
                }
            }
            else
            {
                // Invalid ID
                Response.Write("Error! - Invalid ID");
            }

        }
        else
        {
            // no ID
            Response.Write("Error! - No ID Given");
        }
    }

    private string MimeType(string Filename)
    {
        string mime = "application/octetstream";
        string ext = System.IO.Path.GetExtension(Filename).ToLower();
        Microsoft.Win32.RegistryKey rk = Microsoft.Win32.Registry.ClassesRoot.OpenSubKey(ext);
        if (rk != null && rk.GetValue("Content Type") != null)
            mime = rk.GetValue("Content Type").ToString();
        return mime;
    } 
}
