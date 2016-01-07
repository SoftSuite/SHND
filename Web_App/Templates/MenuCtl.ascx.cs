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
using SHND.Flow.Common;
using SHND.Data.Common;
using SHND.Data.Common.Utilities;
using SHND.Global;

public partial class Templates_MenuCtl : System.Web.UI.UserControl
{
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            MenuFlow mFlow = new MenuFlow();
            string url = Request.Url.AbsolutePath;
            url = url.Substring(url.LastIndexOf("/"));
            MenuData mData = mFlow.GetMenuDataByFileName(url);
            if (_lv1show == "") _lv1show = mData.SystemID;
            if (_lv2show == "") _lv2show = mData.GroupID;
            if (_lv3show == "") _lv3show = mData.MenuID;
            BuildMenu();            
        }

    }

    string _lv1show = "";
    string _lv2show = "";
    string _lv3show = "";

    public string SystemID { set { _lv1show = value;} }
    public string MenuGroup { set { _lv2show = value;} }
    public string MenuLOID { set { _lv3show = value;} }

    private void BuildMenu()
    {
        //string l0i = "";
        string l1i = "";
        string l2i = "";


        int l1run = 1;
        int l2run = 0;
        int l3run = 0;
        int l4run = 0;
        int l5run = 0;

        lblMenuOutput.Text = @"
        
<script type=""text/javascript"">
<!--
stBM(2,""tree6ed7"",[0,"""","""",""" + Request.ApplicationPath + @"/images/blank.gif"",0,""left"",""default"",""hand"",1,0,-1,-1,-1,""none"",0,""#0066CC"",""#663399"","""",""no-repeat"",1,""" + Request.ApplicationPath + @"/images/button_01.gif"",""" + Request.ApplicationPath + @"/images/button_02.gif"",10,10,0,""line_def0.gif"",""line_def1.gif"",""line_def2.gif"",""line_def3.gif"",1,0,5,3,""left"",0,0]);
stBS(""p0"",[0,0]);
stIT(""p0i0"",[""ข้อมูลผู้ใช้"",""" + Request.ApplicationPath + @"/SHNDMain.aspx"",""_self"","""","""","""","""",0,0,""bold 9pt 'Tahoma'"",""" + (_lv3show == "MAIN" ? "#FFFF00" : "#FFFFFF") + @""",""none"",""transparent"",""" + Request.ApplicationPath + @"/images/bg_01.gif"",""repeat-x"",""bold 9pt 'Tahoma'"",""#000000"",""none"",""transparent"",""" + Request.ApplicationPath + @"/images/bg_01.gif"",""repeat-x"",""bold 9pt 'Tahoma'"",""#FFFFFF"",""none"",""transparent"",""" + Request.ApplicationPath + @"/images/bg_01.gif"",""repeat-x"",""bold 9pt 'Tahoma'"",""#000000"",""none"",""transparent"",""" + Request.ApplicationPath + @"/images/bg_01.gif"",""repeat-x"",1,0,""left"",""middle"",180,21]);
stIT(""p0i1"",[""เปลี่ยนรหัสผ่าน"",""" + Request.ApplicationPath + @"/SHNDChangePassword.aspx"",,,,,,,,," + (_lv3show == "PW" ? "\"#FFFF00\"" : "\"#FFFFFF\"") + ",,,,,,,,,,,,,,,,,,,,,,,,,,,0],\"p0i0\");";


        LoggedOnUserData uData = Appz.LoggedOnUser;

        MenuFlow mFlow = new MenuFlow();

        DataTable zDt;
        if (uData.UserRole == UserData.Roles.Administrator)
            zDt = mFlow.GetAllMenu();
        else
            zDt = mFlow.GetMenuByUserLOID(uData.LOID);

        string mS = "";
        string mG = "";

        bool MSSub = false;
        bool MGSub = false;

        for (int i = 0; i < zDt.Rows.Count; i++)
        {
            string menuName = zDt.Rows[i]["MENUNAME"].ToString();
            string menuLink = makeLink(zDt.Rows[i]["LINK"].ToString());
            string sysName = zDt.Rows[i]["SYSTEMNAME"].ToString();
            string grpName = zDt.Rows[i]["GNAME"].ToString();
            string sysID = zDt.Rows[i]["ZSYSTEM"].ToString();
            string grpID = zDt.Rows[i]["MENUGROUP"].ToString();
            string mnuID = zDt.Rows[i]["LOID"].ToString();

            bool sysExpand = (sysID == _lv1show);
            bool grpExpand = (sysID == _lv1show && grpID == _lv2show);
            bool itemHighligh = (_lv3show == mnuID);

            if (sysID != mS.ToString())
            {

                // CREATE SYSTEM MENU
                mS = sysID;

                if (MGSub)
                {
                    lblMenuOutput.Text += "stES();\n";
                    MGSub = false;
                }
                if (MSSub)
                    lblMenuOutput.Text += "stES();\n";

                l1run += 1;
                l2run = (l2run > l3run ? l2run + 1 : l3run + 1);
                l4run = 0;
                l5run = 0;
                lblMenuOutput.Text += "stIT(\"p0i" + l1run.ToString() + "\",[\"" + sysName + "\",\"#\",,,,,,,,,\"#FFFFFF\"],\"p0i1\");\n";
                MSSub = true;
                lblMenuOutput.Text += "stBS(\"p" + l2run.ToString() + "\",[," + (sysExpand ? "1" : "0") + "],\"p0\");\n";
                mG = "0";


            }

            if (grpID != mG)
            {
                // CREATE SUB MENU 1
                mG = grpID;

                if (MGSub)
                    lblMenuOutput.Text += "stES();\n";

                l3run = (l2run > l3run ? l2run + 1 : l3run + 1);

                if (l1i == "")
                {
                    lblMenuOutput.Text += "stIT(\"p" + l2run.ToString() + "i" + l4run.ToString() + "\",[\"" + grpName + "\",\"#\",,,,,,,,,\"#FFFFFF\",,,\"\",\"no-repeat\",,\"#FFFFFF\",\"underline\",,\"\",\"no-repeat\",,,,,\"\",\"no-repeat\",,\"#FFFFFF\",\"underline\",,\"\",\"no-repeat\",,,,,,17],\"p0i1\");";
                    l1i = "p" + l2run.ToString() + "i" + l4run.ToString() + "";
                }
                else
                    lblMenuOutput.Text += "stIT(\"p" + l2run.ToString() + "i" + l4run.ToString() + "\",[\"" + grpName + "\",\"#\",,,,,,,,,\"#FFFFFF\"],\"" + l1i + "\");\n";

                lblMenuOutput.Text += "stBS(\"p" + l3run.ToString() + "\",[," + (grpExpand ? "1" : "0") + "],\"p0\");\n";
                MGSub = true;
                l4run += 1;
                l5run = 0;
            }

            // CREATE ITEM;
            if (mG == "0")
            {
                lblMenuOutput.Text += "stIT(\"p" + l2run.ToString() + "i" + l4run.ToString() + "\",[\"" + menuName + "\",\"" + menuLink + "\",,,,,,,,," + (itemHighligh ? "\"#FFFF00\"" : "\"#FFFFFF\"") + "],\"" + l1i + "\");\n";
                l4run += 1;
            }
            else
            {
                if (l2i == "")
                {
                    lblMenuOutput.Text += "stIT(\"p" + l3run.ToString() + "i" + l5run.ToString() + "\",[\"- " + menuName + "\",\"" + menuLink + "\",,,,,,,,\"9pt 'Tahoma'\"," + (itemHighligh ? "\"#FFFF00\"" : "\"#FFFFFF\"") + ",,\"#1F2C3A\",,,\"9pt 'Tahoma'\",,,\"#1F2C3A\",,,\"9pt 'Tahoma'\",,,\"#1F2C3A\",,,\"9pt 'Tahoma'\",,,\"#1F2C3A\",,,,,,,,15],\"" + l1i + "\");";
                    l2i = "p" + l3run.ToString() + "i" + l5run.ToString() + "";
                }
                else
                {
                    lblMenuOutput.Text += "stIT(\"p3i1\",[\"- " + menuName + "\",\"" + menuLink + "\",,,,,,,,," + (itemHighligh ? "\"#FFFF00\"" : "\"#FFFFFF\"") + "],\"" + l2i + "\");";
                }
                l5run += 1;
            }

        }
        if (MGSub) lblMenuOutput.Text += "stES();\n"; // close last menugroup
        if (MSSub) lblMenuOutput.Text += "stES();\n"; // close last zsystem
        l1run += 1;
        lblMenuOutput.Text += @"
stIT(""" + "p0i" + l1run.ToString() + @""",[""ออกจากระบบ"",""" + Request.ApplicationPath + @"/SHNDLogin.aspx?logout=yes"",,,,,,,,,""#FF5555"",,,,,,,,,,,,,,,,,,,,,,,,,,,0],""p0i0"");
stES();
stEM();
//-->
</script>
";

        /*
        stIT(""p0i2"",[""PURCHASE"",""#""],""p0i1"");
        stBS(""p1"",[,1],""p0"");
        stIT(""p1i0"",[""Shopping Cart"",,,,,,,,,,,,,"""",""no-repeat"",,""#FFFFFF"",""underline"",,"""",""no-repeat"",,,,,"""",""no-repeat"",,""#FFFFFF"",""underline"",,"""",""no-repeat"",,,,,,17],""p0i1"");
        stIT(""p1i1"",[""Bundle Deals"",""#"",,,,,,,,,""#FFFF00""],""p1i0"");
        stIT(""p1i2"",[""Discount Programs""],""p1i0"");
        stIT(""p1i3"",[""Back-up CD Service"",,,,,,,,,,,,,,,,,,,,,,,,,,,,,,,,,,,,,,0],""p1i0"");
        stES();
        stIT(""p0i3"",[""PRODUCTS"",""#""],""p0i1"");
        stBS(""p2"",[,0],""p1"");
        stIT(""p2i0"",[""DHTML Software"",""#""],""p1i0"");
        stBS(""p3"",[],""p0"");
        stIT(""p3i0"",[""- Sothink Tree Menu"",,,,,,,,,""9pt 'Tahoma'"",,,""#1F2C3A"",,,""9pt 'Tahoma'"",,,""#1F2C3A"",,,""9pt 'Tahoma'"",,,""#1F2C3A"",,,""9pt 'Tahoma'"",,,""#1F2C3A"",,,,,,,,15],""p1i0"");
        stIT(""p3i1"",[""- Sothink DHTML Menu""],""p3i0"");
        stIT(""p3i2"",[""- Sothink Menu Templates""],""p3i0"");
        stES();
        stIT(""p2i1"",[""Flash Software"",""#""],""p1i0"");
        stBS(""p4"",[],""p0"");
        stIT(""p4i0"",[""- Sothink SWF Decompiler""],""p3i0"");
        stIT(""p4i1"",[""- Sothink SWF Quicker""],""p3i0"");
        stIT(""p4i2"",[""- Sothink Glanda""],""p3i0"");
        stIT(""p4i3"",[""- SWF to Video Converter""],""p3i0"");
        stIT(""p4i4"",[""- Video Encoder for Adobe Flash""],""p3i0"");
        stES();
        stIT(""p2i2"",[""DVD Video Tool"",""#""],""p1i3"");
        stBS(""p5"",[],""p0"");
        stIT(""p5i0"",[""- ipod Video Converter""],""p3i0"");
        stIT(""p5i1"",[""- DVD Ripper""],""p3i0"");
        stIT(""p5i2"",[""- DVD EZWorkshop""],""p3i0"");
        stIT(""p5i3"",[""- DVD to ipod Converter""],""p3i0"");
        stES();
        stES();
        stIT(""p0i4"",[""SUPPORT"",""#""],""p0i1"");
        stIT(""p0i5"",[""COMMUNITY"",""#""],""p0i1"");
                ";
        */
    }

    private string makeLink(string rawLink)
    {
        string ret;
        ret = rawLink.Replace("/SHND/", "").Replace("/Web_App/", "").Replace("/shnd/", "");
        ret = Request.ApplicationPath + "/" + ret;
        ret = ret.Replace("//", "/");
        return ret;
    }
}
