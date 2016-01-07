<%@ Page Language="C#" MasterPageFile="~/Templates/Page1.master" AutoEventWireup="true" CodeFile="NpoOrderSet.aspx.cs" Inherits="App_Prepare_Transaction_NpoOrderSet" Title="SHND : Transaction - NPO Order" %>

<%@ Register Src="NpoOrderSet/NpoOrderSetCtl.ascx" TagName="NpoOrderSetCtl" TagPrefix="uc1" %>

<asp:Content ID="Content3" ContentPlaceHolderID="MainContent" Runat="Server">
<table border="0" cellpadding="0" cellspacing="0" width="100%">
        <tr>
            <td class="headtext">ข้อมูลการงดอาหาร</td>
        </tr>
        
        <tr>
            <td>
                <uc1:NpoOrderSetCtl ID="NpoOrderSetCtl1" runat="server" /></td>
        </tr>
    </table>
</asp:Content>