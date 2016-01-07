<%@ Page Language="C#" MasterPageFile="~/Templates/Page1.master" AutoEventWireup="true" CodeFile="RegisterOrderMilk.aspx.cs" Inherits="App_Prepare_Transaction_RegisterOrderMilk" Title="SHND : Transaction - Food Order Registration" %>
<%@ Register Src="RegisterOrderPatient/OrderMilkControl.ascx" TagName="OrderMilkControl" TagPrefix="uc1" %>
<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="cc1" %>
<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" Runat="Server">
    <table border="0" cellpadding="0" cellspacing="0" width="100%">
        <tr>
            <td class="headtext">Register การสั่งนมผสมสำหรับเด็ก</td>
        </tr>
        <tr>
            <td>
                <uc1:OrderMilkControl id="OrderMilkControl1" runat="server">
                </uc1:OrderMilkControl>
            </td>
        </tr>
    </table>
</asp:Content>

