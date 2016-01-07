<%@ Page Language="C#" MasterPageFile="~/Templates/Page1.master" AutoEventWireup="true" CodeFile="RegisterOrderFeed.aspx.cs" Inherits="App_Prepare_Transaction_RegisterOrderFeed" Title="SHND : Transaction - Food Order Registration" %>
<%@ Register Src="RegisterOrderPatient/OrderFeedControl.ascx" TagName="OrderFeedControl" TagPrefix="uc1" %>
<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="cc1" %>
<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" Runat="Server">
    <script language="JavaScript" type="text/javascript">
    </script>
    <table border="0" cellpadding="0" cellspacing="0" width="100%">
        <tr>
            <td class="headtext">Register การสั่งอาหารทางสายให้อาหาร</td>
        </tr>
        <tr>
            <td style="height:20px"></td>
        </tr>
        <tr>
            <td>
                <cc1:TabContainer ID="tabRegister" runat="server" ActiveTabIndex="0" AutoPostBack="True" OnActiveTabChanged="tabRegister_ActiveTabChanged">
                    <cc1:TabPanel ID="tabWaitRegister" runat="server" HeaderText="รายการที่สามารถ Register ได้">
                        <ContentTemplate>
                            <uc1:OrderFeedControl ID="ctlOrderSetReg" runat="server" RegisterVisible="true" UnRegisterVisible="false"/>
                        </ContentTemplate>
                    </cc1:TabPanel>
                    <cc1:TabPanel ID="tabUnRegister" runat="server" HeaderText="รายการที่&lt;u&gt;&lt;b&gt;ไม่&lt;/b&gt;&lt;/u&gt;สามารถ Register ได้">
                        <ContentTemplate>
                            <uc1:OrderFeedControl ID="ctlOrderSetUnReg" runat="server" RegisterVisible="false" UnRegisterVisible="true"/>
                        </ContentTemplate>
                    </cc1:TabPanel>
                </cc1:TabContainer>
            </td>
        </tr>
    </table>
</asp:Content>