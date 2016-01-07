<%@ Page Language="C#" MasterPageFile="~/Templates/Page1.master" AutoEventWireup="true" CodeFile="test.aspx.cs" Inherits="test" Title="ทดสอบ" %>

<%@ Register Src="Templates/ToolBarItemCtl.ascx" TagName="ToolBarItemCtl" TagPrefix="uc1" %>
<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" Runat="Server">
    <table border = "0" cellspacing="0" cellpadding="0" width="100%" style="height:100%">
        <tr>
            <td >
                </td>
        </tr>
        <tr>
            <td class="headtext">
                Header</td>
        </tr>
        <tr>
            <td class="toolbarplace">
                <table border="0" cellpadding="0" cellspacing="0" width="100" style="display:none;"> 
                    <tr>
                        <td style="height:25px" class="toolbarbuttonhover">
                            toolbar_hover</td>
                        <td style="height:25px" class="toolbarbutton">
                            toolbar1</td>
                    </tr>
                </table>
                <table class="toolbarplace" width="100%">
                    <tr>
                        <td>
                            <uc1:ToolBarItemCtl ID="tbbSave" runat="server" ToobarTitle="บันทึกข้อมูล" ToolbarImage="Images/save2.png" OnToolbarButtonClick="SaveClick" ClientClick="alert('wooHoo')" />
                            <uc1:ToolBarItemCtl ID="tbbCancel" runat="server" ToobarTitle="ยกเลิก" ToolbarImage="Images/cancel.png" />
                            <uc1:ToolBarItemCtl ID="ToolBarItemCtl1" runat="server" />
                        </td>
                    </tr>
                </table>
            </td>
        </tr>
        <tr>
            <td style="height:25px">
                เนื้อหา
                <asp:TextBox ID="TextBox2" runat="server" CssClass="zTextbox" Width="100px">zTextbox</asp:TextBox>
                <asp:TextBox ID="TextBox3" runat="server" CssClass="zTextbox-View" Width="100px" ReadOnly="true">zTextbox-View</asp:TextBox></td>
        </tr>
        <tr>
            <td style="height: 25px">
                <asp:TextBox ID="TextBox4" runat="server" CssClass="zTextboxR" Width="100px">zTextboxR</asp:TextBox>
                <asp:TextBox ID="TextBox5" runat="server" CssClass="zTextboxR-View" Width="100px" ReadOnly="true">zTextboxR-View</asp:TextBox>
            </td>
        </tr>
        <tr>
            <td style="height:25px">
                <asp:DropDownList ID="DropDownList2" runat="server" CssClass="zComboBox" Width="106px">
                    <asp:ListItem>zComboBox</asp:ListItem>
                </asp:DropDownList>
                <asp:DropDownList ID="DropDownList1" runat="server" CssClass="zComboBox" Width="106px" Enabled="false">
                    <asp:ListItem>zComboBox</asp:ListItem>
                </asp:DropDownList></td>
        </tr>
        <tr>
            <td style="height: 25px">
                <asp:TextBox ID="TextBox1" runat="server" Width="100px"></asp:TextBox></td>
        </tr>
        <tr>
            <td style="height: 25px">
                <asp:DropDownList ID="DropDownList3" runat="server" Width="100px">
                </asp:DropDownList></td>
        </tr>
        <tr>
            <td style="height:25px">
                <asp:Button ID="Button1" runat="server" CssClass="zButton" Text="zButton" Width="80px" /></td>
        </tr>
        <tr>
            <td style="height:25px">
            </td>
        </tr>
        <tr>
            <td class="subheadertext">
                Sub Header</td>
        </tr>
        <tr>
            <td style="height:25px">
            </td>
        </tr>
        <tr>
            <td>
                <table border="0" cellpadding="0" cellspacing="0" width="600" class="searchTable">
                    <tr>
                        <td style="height:25px">
                            &nbsp;search criteria</td>
                    </tr>
                    <tr >
                        <td style="height:25px"></td>
                    </tr>
                    <tr>
                        <td style="height:25px"></td>
                    </tr>
                    <tr >
                        <td style="height:25px"></td>
                    </tr>
                </table>
            </td>
        </tr>
        <tr>
            <td style="height:25px">
            </td>
        </tr>
        <tr>
            <td>
                <table border="1" cellpadding="0" cellspacing="0" width="600" class="t_tablestyle">
                    <tr  class="t_headtext">
                        <td style="height:25px; width:200px" align="center">
                            No.</td>
                        <td style="height:25px; width:200px" align="center">
                            Code</td>
                        <td style="height:25px; width:200px" align="center">
                            Name</td>
                    </tr>
                    <tr >
                        <td style="height:25px; width:200px">
                            12123234</td>
                        <td style="height:25px; width:200px">
                            sdfasdf</td>
                        <td style="height:25px; width:200px">
                            asdfasdf</td>
                    </tr>
                    <tr  class="t_alt_bg">
                        <td style="height:25px; width:200px">
                            asdfasdf</td>
                        <td style="height:25px; width:200px">
                            asdf</td>
                        <td style="height:25px; width:200px">
                            asdfasdf</td>
                    </tr>
                    <tr >
                        <td style="height:25px; width:200px">
                            asdf</td>
                        <td style="height:25px; width:200px">
                            asdf</td>
                        <td style="height:25px; width:200px">
                            asdfasdfasdf</td>
                    </tr>
                    <tr class="t_selectstyle">
                        <td style="height:25px; width:200px">
                            sdfasdfasda</td>
                        <td style="height:25px; width:200px">
                            asdfasdf</td>
                        <td style="height:25px; width:200px">
                            asdfasdf</td>
                    </tr>
                </table>
            </td>
        </tr>
    </table>
</asp:Content>