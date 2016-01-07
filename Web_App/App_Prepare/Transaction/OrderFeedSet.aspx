<%@ Page Language="C#" MasterPageFile="~/Templates/Page1.master" AutoEventWireup="true" CodeFile="OrderFeedSet.aspx.cs" Inherits="App_Prepare_Transaction_OrderFeedSet" Title="SHND : Transaction - Feed Order Set" %>


<%@ Register Src="OrderFeedSet/OrderFeedSetCtl.ascx" TagName="OrderFeedSetCtl" TagPrefix="uc1" %>
<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="cc1" %>
<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" Runat="Server">
    <table border="0" cellpadding="0" cellspacing="0" width="100%">
        <tr>
            <td class="headtext">ข้อมูลการจัดอาหารทางสายให้อาหาร</td>
        </tr>
        
        <tr>
            <td>
                <uc1:OrderFeedSetCtl ID="OrderFeedSetCtl1" runat="server" />
            </td>
        </tr>
    </table>
</asp:Content>
