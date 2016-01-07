<%@ Page Language="C#" MasterPageFile="~/Templates/Page1.master" AutoEventWireup="true" CodeFile="OrderMilkSet.aspx.cs" Inherits="App_Prepare_Transaction_OrderMilkSet" Title="SHND : Transaction - Milk Order Set" %>

<%@ Register Src="OrderMilkSet/OrderMilkSetCtl.ascx" TagName="OrderMilkSetCtl" TagPrefix="uc1" %>

<asp:Content ID="Content3" ContentPlaceHolderID="MainContent" Runat="Server">
<table border="0" cellpadding="0" cellspacing="0" width="100%">
        <tr>
            <td class="headtext">ข้อมูลการจัดเตรียมนมผงผสมสำหรับเด็ก</td>
        </tr>
        
        <tr>
            <td>
                <uc1:OrderMilkSetCtl id="OrderMilkSetCtl1" runat="server"></uc1:OrderMilkSetCtl></td>
        </tr>
    </table>
</asp:Content>

