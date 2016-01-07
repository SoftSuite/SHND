using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Text;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;

namespace WebControls
{
    [DefaultProperty("Text")]
    [ToolboxData("<{0}:SystemMenu runat=server></{0}:SystemMenu>")]
    public class SystemMenu : WebControl
    {
        [Bindable(true)]
        [Category("Appearance")]
        [DefaultValue("")]
        [Localizable(true)]
        public string Text
        {
            get
            {
                String s = (String)ViewState["Text"];
                return ((s == null) ? String.Empty : s);
            }

            set
            {
                ViewState["Text"] = value;
                
            }
        }

        string sysFoot = "</tbody>";
        string grpFoot = "</table></td></tr>";

        protected override void RenderContents(HtmlTextWriter output)
        {
           

            #region OldCode
            /*
            string sysID = "";
            string grpID = "";
            bool TBOpen = false;
            bool TBSubOpen = false;
            string zNL = "\r\n";


            string zHtml;
            zHtml = "<table width='170' align='center' cellspacing='1' cellpadding='1' border='0'>" + zNL;
            // Menu Header
            zHtml += "<tr><td align='center' style='height:25px;color:#CCFFCC' bgcolor='#006611'> MENU </td></tr>" + zNL;

            MenuFlow mFlow = new MenuFlow();
 
            DataTable zDt;

            try
            {
                zDt = mFlow.GetMenuData(Authz.CurrentUserInfo.UserID);
            }
            catch
            {
                zDt = new DataTable();
            }

            for (int i = 0; i < zDt.Rows.Count; i++)
            {
                DataRow dRow = zDt.Rows[i];

                // SYSTEM
                if (dRow["SYSLOID"].ToString() != sysID)
                {
                    if (TBSubOpen) { zHtml += grpFoot + zNL; TBSubOpen = false; }
                    grpID = "";
                    // create HeadMenu
                    if (dRow["SYSLOID"].ToString() != "100")
                    {
                        sysID = dRow["SYSLOID"].ToString();
                        string subID = "z_sub_" + sysID + "";

                        if (TBOpen)
                        {
                            zHtml += sysFoot + zNL;
                            TBOpen = false;
                        }


                        zHtml += "<tr><td style='height:23px;color:#000000;cursor:hand;border=1px black thin;' bgcolor='#99DDBB' onClick='toggleMenu(\"" + subID + "\");' align='center'> <b>" + dRow["SYSNAME"].ToString() + "</b> </td></tr>" + zNL;
                        TBOpen = true;
                        zHtml += "<tbody id='" + subID + "' style='display:none'>" + zNL;
                        
                    }
                }

                // MENU GROUP
                if (dRow["MENUGROUP"].ToString() != grpID)
                {
                    if (dRow["MENUGROUP"].ToString() != "0")
                    {
                        grpID = dRow["MENUGROUP"].ToString();
                        string subGID = "z_sub_" + sysID + "_" + grpID + "";

                        if (TBSubOpen)
                        {
                            zHtml += grpFoot + zNL;
                            TBSubOpen = false;
                        }

                        zHtml += "<tr><td style='height:23px;color:#000066;cursor:hand;' bgcolor='#CCFFEE' onClick='toggleMenu(\"" + subGID + "\");'>&nbsp;> " + dRow["GROUPNAME"].ToString() + "</td></tr>" + zNL;
                        TBSubOpen = true;
                        zHtml += "<tr id='" + subGID + "' style='display:none'><td>" + zNL;
                        zHtml += "<table width='100%' cellspacing='2' cellpadding='0' border='0'>" + zNL;
                        //zHtml += "<tbody id='" + subGID + "' style='display:none'>" + zNL;



                    }
                }


                // create Item
                string sLink = dRow["SYSLINK"].ToString();
                string mLink = dRow["LINK"].ToString();
                string mImg = dRow["IMAGE"].ToString();
                string mName = dRow["MENUNAME"].ToString();

                string finalLink = sLink;
                if (sLink.IndexOf("{SERVER") > -1)
                {
                    finalLink = "http://" +  System.Web.HttpContext.Current.Request.Url.Host;
                    int pos1 = sLink.IndexOf("{");
                    int pos2 = sLink.IndexOf(":");
                    int pos3 = sLink.IndexOf("}");
                    if (System.Web.HttpContext.Current.Request.Url.Port != 80)
                    {
                          finalLink += sLink.Substring(pos2, pos3 - pos2);
                    }

                    finalLink += sLink.Substring(pos3 + 1);
                }


                zHtml += "<tr><td style='height:23px;color:#0000FF' bgcolor='#EEFFF8'> &nbsp;&nbsp; - <a href='" + (mLink.Trim() == "" ? "#" : finalLink + mLink) + "'>" + (mName.Trim() == "" ? "[NONAME]" : mName) + "</a></td></tr>" + zNL;
                

            }
            // Menu Footer


            if (TBSubOpen) zHtml += grpFoot + zNL;
            if (TBOpen) zHtml += sysFoot + zNL;
            // LOGOUT
            zHtml += "<tr><td style='height:23px;color:#000066;cursor:hand;color:red;' bgcolor='#CCFFEE' >&nbsp;- <a id=\"ctl00_ChgPassword\" href=\"/Web_Admin/PasswordChange.aspx\" style=\"text-decoration:none;color:red\" >����¹���ʼ�ҹ</a> </td></tr>" + zNL;
            zHtml += "<tr><td style='height:23px;color:#0000FF;cursor:hand;color:red;' bgcolor='#EEFFCC' >&nbsp;- <a id=\"ctl00_LoginStatusZ\" href=\"javascript:__doPostBack('ctl00$LoginStatus1$ctl00','')\" style=\"text-decoration:none;color:red\" >Logout</a> </td></tr>" + zNL;
            zHtml += "</table>" + zNL;


            //// Menu Item
            //zHtml += "<tr><td style='height:23px;color:#0000FF' bgcolor='#CCFFEE'>&nbsp;- TEST </td></tr>";
            //zHtml += "<tr><td style='height:23px;color:#0000FF;cursor:hand;' bgcolor='#CCFFEE' onClick='toggleMenu(\"z_sub_01\");'>&nbsp;- TEST </td></tr>";

            //// SubMenu 
            //zHtml += "<tbody id='z_sub_01' style='display:none'>";

            //zHtml += "<tr><td style='height:23px;color:#0000FF' bgcolor='#EEFFF8'> &nbsp;&nbsp; > TEST </td></tr>";
            //zHtml += "<tr><td style='height:23px;color:#0000FF' bgcolor='#EEFFF8'> &nbsp;&nbsp; > TEST </td></tr>";
           
            //zHtml += "</tbody>";


            //zHtml += "<tr><td style='height:23px;color:#0000FF;cursor:hand;' bgcolor='#CCFFEE' onClick='toggleMenu(\"z_sub_01\");'>&nbsp;- TEST </td></tr>";

            */
            #endregion
            string zHtml = @"
                                <asp:UpdatePanel ID=""UpdateMenu"" runat=""server"">
                                    <ContentTemplate>
                                        <asp:ContentPlaceHolder ID=""MenuContent"" runat=""server"">
                                            <table border=""0"" cellpadding=""0"" cellspacing=""0"" width=""100%"">
                                                <tr>
                                                    <td>
                                                        <asp:Panel ID=""pnlHeaderMenu1"" runat=""server"" CssClass=""collapsePanelHeader"" Height=""25px"" width=""100%"">
                                                            <table border=""0"" cellpadding=""0"" cellspacing=""0"" width=""100%"">
                                                                <tr style=""cursor:pointer;"">
                                                                    <td valign=""middle"" style=""width:100%; padding-left:5px"">
                                                                            MENU1
                                                                    </td>
                                                                    <td align=""left""><asp:Image ID=""imgMenu1"" runat=""server"" /></td>
                                                                </tr>
                                                            </table>
                                                        </asp:Panel>
                                                        <asp:Panel ID=""pnlMenu1"" runat=""server"" CssClass=""collapsePanel"" Height=""0"" width=""100%"">
                                                            <table width=""100%"" border=""0"" cellpadding=""3"" cellspacing=""0"">
                                                                <tr>
                                                                    <td style=""height:5px""></td>
                                                                </tr>
                                                                <tr>
                                                                    <td>ITEM 1</td>
                                                                </tr>
                                                                <tr>
                                                                    <td>ITEM 2</td>
                                                                </tr>
                                                                <tr>
                                                                    <td>ITEM 3</td>
                                                                </tr>
                                                                <tr>
                                                                    <td>ITEM 4</td>
                                                                </tr>
                                                                <tr>
                                                                    <td style=""height:5px""></td>
                                                                </tr>
                                                            </table>
                                                        </asp:Panel>
                                                        <cc1:CollapsiblePanelExtender ID=""cpeMenu1"" runat=""Server""
                                                            TargetControlID=""pnlMenu1""
                                                            ExpandControlID=""pnlHeaderMenu1""
                                                            CollapseControlID=""pnlHeaderMenu1"" 
                                                            Collapsed=""True""
                                                            ImageControlID=""imgMenu1""    
                                                            ExpandedImage=""../images/menuup.png""
                                                            CollapsedImage=""../images/menudown.png""
                                                            SuppressPostBack=""true""/>
                                                    </td>
                                                </tr>
                                                <tr>
                                                    <td style=""height:7px"">
                                                    </td>
                                                </tr>
                                                <tr>
                                                    <td>
                                                        <asp:Panel ID=""pnlHeaderMenu2"" runat=""server"" CssClass=""collapsePanelHeader"" Height=""25px"" width=""100%"">
                                                            <table border=""0"" cellpadding=""0"" cellspacing=""0"" width=""100%"">
                                                                <tr style=""cursor:pointer;"">
                                                                    <td valign=""middle"" style=""width:100%; padding-left:5px"">
                                                                            MENU2
                                                                    </td>
                                                                    <td align=""left""><asp:Image ID=""imgMenu2"" runat=""server"" /></td>
                                                                </tr>
                                                            </table>
                                                        </asp:Panel>
                                                        <asp:Panel ID=""pnlMenu2"" runat=""server"" CssClass=""collapsePanel"" Height=""0"" width=""100%"">
                                                            <table width=""100%"" border=""0"" cellpadding=""3"" cellspacing=""0"">
                                                                <tr>
                                                                    <td style=""height:5px""></td>
                                                                </tr>
                                                                <tr>
                                                                    <td>ITEM 1</td>
                                                                </tr>
                                                                <tr>
                                                                    <td>ITEM 2</td>
                                                                </tr>
                                                                <tr>
                                                                    <td>ITEM 3</td>
                                                                </tr>
                                                                <tr>
                                                                    <td>ITEM 4</td>
                                                                </tr>
                                                                <tr>
                                                                    <td style=""height:5px""></td>
                                                                </tr>
                                                            </table>
                                                        </asp:Panel>
                                                        <cc1:CollapsiblePanelExtender ID=""cpeMenu2"" runat=""Server""
                                                            TargetControlID=""pnlMenu2""
                                                            ExpandControlID=""pnlHeaderMenu2""
                                                            CollapseControlID=""pnlHeaderMenu2"" 
                                                            Collapsed=""True""
                                                            ImageControlID=""imgMenu2""    
                                                            ExpandedImage=""../images/menuup.png""
                                                            CollapsedImage=""../images/menudown.png""
                                                            SuppressPostBack=""true""/>
                                                    </td>
                                                </tr>
                                            </table>
                                        </asp:ContentPlaceHolder>
                                    </ContentTemplate> 
                                </asp:UpdatePanel> 

";
            output.Write(zHtml);
        }

        protected override void OnPreRender(EventArgs e)
        {
            string zScript = "";
            zScript += " <script language='JavaScript'> \r\n";
            zScript += "     function toggleMenu(mID) { \r\n";
            zScript += "        mnu = document.getElementById(mID); \r\n";
            zScript += "        mnu.style.display = (mnu.style.display == 'none' ? '' : 'none');\r\n";
            zScript += "     }\r\n";
            zScript += " </script>";

            Page.ClientScript.RegisterStartupScript(this.GetType(), "MenuScript", zScript);
        }
 
    }
}
