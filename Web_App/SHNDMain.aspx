<%@ Page Language="C#" MasterPageFile="~/Templates/Page1.master" AutoEventWireup="true" CodeFile="SHNDMain.aspx.cs" Inherits="SHNDMain" Title="Siriraj Hospital Nutrition Department System" %>

<%@ Register Src="Templates/MenuCtl.ascx" TagName="MenuCtl" TagPrefix="uc1" %>
<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" Runat="Server">
<table width="100%" cellpadding="0" cellspacing="0" border="0">
<!--
    <tr>
        <td class="headtext">
            ข่าวประกาศ</td>
    </tr>
    <tr>
        <td style="padding:10px 10px 10px 10px">
    <table width="750" border="0" cellpadding="5" cellspacing="0" style="border:solid 1px 1px 1px 1px #dddddd">
        <tr>
            <td>
            ...
            </td>
        </tr>
        <tr>
            <td>
            ..
            </td>
        </tr>
        <tr>
            <td>
            ..
            </td>
        </tr>
        <tr>
            <td>
                <hr style="height: 1px" />
                &nbsp;</td>
        </tr>
    </table>
        
        </td>
    </tr>
    <tr>
        <td style="height: 20px">
        
        </td>
    </tr>
    -->
    <tr>
        <td class="headtext">
            รายละเอียดผู้ใช้งาน</td>
    </tr>
    <tr>
        <td style="padding:10px 10px 10px 10px">
            <table width="750" border="0" cellpadding="5" cellspacing="1" style="border:solid 1px 1px 1px 1px #cccccc">
            <tr>
                <td style="width:115px" align="right">
                    <strong>
                    รหัสผู้ใช้</strong>
                </td>
                <td align="center" style="width: 20px">
                    :</td>
                <td>
                    <asp:Label ID="lblUserID" runat="server"></asp:Label></td>
            </tr>
            <tr>
                <td style="width:115px" align="right" class="t_alt_bg">
                    <strong>
                    ชื่อ</strong>
                </td>
                <td align="center" class="t_alt_bg" style="width: 20px">
                    :</td>
                <td class="t_alt_bg">
                    <asp:Label ID="lblName" runat="server"></asp:Label></td>
            </tr>
            <tr>
                <td style="width:115px" align="right">
                    <strong>
                    หน่วยงาน</strong>
                </td>
                <td align="center" style="width: 20px">
                    :</td>
                <td>
                    <asp:Label ID="lblDivision" runat="server"></asp:Label></td>
            </tr>
            <tr>
                <td style="width:115px" align="right" class="t_alt_bg">
                    <strong>
                    ระดับการใช้งาน</strong>
                </td>
                <td align="center" class="t_alt_bg" style="width: 20px">
                    :</td>
                <td class="t_alt_bg">
                    <asp:Label ID="lblLevel" runat="server"></asp:Label></td>
            </tr>
            <tr>
                <td style="width:115px" align="right">
                    <strong>
                   เข้าใช้งานล่าสุด</strong>
                </td>
                <td align="center" style="width: 20px">
                    :</td>
                <td>
                    <asp:Label ID="lblLastLogin" runat="server"></asp:Label></td>
            </tr>
                <tr>
                    <td align="right" colspan="3">
                        <hr style="height: 1px" />
                    </td>
                </tr>
            </table>
        </td>
    </tr>
    <tr>
        <td>
        </td>
    </tr>
</table>
    <br />
</asp:Content>
<asp:Content ID="Content1" runat="server" ContentPlaceHolderID="MenuContent">
    <uc1:MenuCtl ID="MenuCtl1" runat="server" MenuLOID="MAIN" />
</asp:Content>

