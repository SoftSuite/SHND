<%@ Page Language="C#" MasterPageFile="~/Templates/Page1.master" AutoEventWireup="true" CodeFile="StockOutSearch.aspx.cs" Inherits="App_Inventory_Transaction_StockOutSearch" Title="SHND : Transaction - Stock out" %>

<%@ Register Src="../../Templates/CalendarControl.ascx" TagName="CalendarControl" TagPrefix="uc3" %>
<%@ Register Src="../../Templates/PageControl.ascx" TagName="PageControl" TagPrefix="uc2" %>
<%@ Register Src="../../Templates/ToolBarItemCtl.ascx" TagName="ToolBarItemCtl" TagPrefix="uc1" %>
<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="cc1" %>
<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" Runat="Server">
    <table width="100%" border="0" cellpadding="0" cellspacing="0">
        <tr>
            <td class="headtext">
                �����š�è�����ʴ�</td>
        </tr>
        <tr>
            <td style="height:24px">
            </td>
        </tr>
        <tr>
            <td style="height: 15px">
            <fieldset style="padding:15px;">
            <legend style="font-weight:bold">
                ����
            </legend>
            
                <table cellspacing="0" cellpadding="0" border="0" width="650px">
                    <tr style="height:15px">
                        <td colspan="5">&nbsp;</td>
                    </tr>
                    <tr style="height:24px">
                        <td style="width:130px; text-align: right; padding-right:10px">
                            �Ţ����ԡ :</td>
                        <td style="width:150px;">
                            <asp:TextBox ID="txtSearchCodeFrom" runat="server" CssClass="zTextbox" MaxLength="100" Width="150px"></asp:TextBox>
                        </td>
                        <td style="width:30px; text-align:center;">
                            �֧</td>
                        <td style="width:200px;">
                            <asp:TextBox ID="txtSearchCodeTo" runat="server" CssClass="zTextbox" MaxLength="100" Width="150px"></asp:TextBox></td>
                        <td>
                        </td>
                    </tr>
                    <tr style="height:24px">
                        <td style="padding-right: 10px; width: 130px; text-align: right">
                            �ѹ����� :</td>
                        <td style="width: 150px">
                            <uc3:CalendarControl ID="ctlUseDateFrom" runat="server" />
                        </td>
                        <td style="width: 30px; text-align: center">
                            �֧</td>
                        <td style="width: 200px">
                            <uc3:CalendarControl ID="ctlUseDateTo" runat="server" />
                        </td>
                        <td>
                        </td>
                    </tr>
                    <tr style="height:24px">
                        <td style="width:130px; text-align: right; padding-right:10px">
                            ʶҹ� :</td>
                        <td style="width:150px;">
                            <asp:DropDownList ID="cmbSearchStatusFrom" runat="server" Width="156px" CssClass="zComboBox"></asp:DropDownList>
                        </td>
                        <td style="width:30px; text-align:center;">
                            �֧</td>
                        <td style="width:200px;"><asp:DropDownList ID="cmbSearchStatusTo" runat="server" Width="156px" CssClass="zComboBox">
                        </asp:DropDownList></td>
                        <td>
                            &nbsp;&nbsp;<asp:ImageButton ID="imbSearch" runat="server" ImageAlign="AbsMiddle" ImageUrl="~/Images/icn_find.png"
                                OnClick="imbSearch_Click" />&nbsp;
                            <asp:ImageButton ID="imbReset" runat="server" ImageAlign="AbsMiddle" ImageUrl="~/Images/icn_back.png"
                                OnClick="imbReset_Click" ToolTip="�ʴ�������" />
                        </td>
                    </tr>
                </table>
               
            </fieldset>        
            </td>
        </tr>
        <tr>
            <td style="height:15px">
                <asp:Label ID="lbStatusMain" runat="server" EnableViewState="False"></asp:Label>
                <asp:TextBox ID="txhSortField" runat="server" Visible="False" Width="15px"></asp:TextBox><asp:TextBox
                    ID="txhSortDir" runat="server" Visible="False" Width="15px"></asp:TextBox></td>
        </tr>
        <tr>
            <td style="width:760px">
                <uc2:PageControl ID="pcTop" runat="server" OnPageChange="PageChange"/>
                <asp:GridView ID="gvMain" runat="server" AllowSorting="True" AutoGenerateColumns="False" CssClass="t_tablestyle" OnRowDataBound="gvMain_RowDataBound" 
                    OnSorting="gvMain_Sorting" AllowPaging="True" PageSize="20" Width="100%">
                    <Columns>
                        <asp:BoundField DataField="LOID" HeaderText="LOID">
                            <ControlStyle CssClass="zHidden" />
                            <FooterStyle CssClass="zHidden" />
                            <HeaderStyle CssClass="zHidden" />
                            <ItemStyle CssClass="zHidden" />
                        </asp:BoundField>
                        <asp:TemplateField HeaderText="�ӴѺ" SortExpression="DEFAULT">
                            <HeaderStyle Width="60px" />
                            <ItemStyle HorizontalAlign="Center" Width="60px" Height="24px" />
                        </asp:TemplateField>
                        <asp:TemplateField HeaderText="�Ţ����ԡ" SortExpression="CODE">
                            <ItemTemplate>
                                <asp:LinkButton ID="lnkCode" runat="server" Text='<%# Bind("CODE") %>' OnClick="lnkCode_Click" CommandArgument='<%# Bind("LOID")  %>'></asp:LinkButton>
                            </ItemTemplate>
                            <HeaderStyle Width="100px" />
                            <ItemStyle HorizontalAlign="center" Width="100px" />
                        </asp:TemplateField>
                        <asp:BoundField DataField="DIVISIONNAME" HeaderText="˹��§ҹ����ԡ" SortExpression="DIVISIONNAME">
                        </asp:BoundField>
                        <asp:BoundField DataField="STOCKOUTDATE" HeaderText="�ѹ����ԡ" SortExpression="STOCKOUTDATE" HtmlEncode="False" DataFormatString="{0:dd/MM/yyyy}">
                            <HeaderStyle Width="100px" />
                            <ItemStyle Width="100px" HorizontalAlign="center" />
                        </asp:BoundField>
                        <asp:BoundField DataField="USEDATE" HeaderText="�ѹ�����" SortExpression="USEDATE" HtmlEncode="False" DataFormatString="{0:dd/MM/yyyy}">
                            <HeaderStyle Width="100px" />
                            <ItemStyle Width="100px" HorizontalAlign="center" />
                        </asp:BoundField>
                        <asp:BoundField DataField="DOCNAME" HeaderText="����������ԡ" SortExpression="DOCNAME">
                            <HeaderStyle Width="150px" />
                            <ItemStyle Width="150px" />
                        </asp:BoundField>
                        <asp:BoundField DataField="STATUSNAME" HeaderText="ʶҹ�" SortExpression="STATUSNAME">
                            <HeaderStyle HorizontalAlign="Center" Width="100px" />
                            <ItemStyle Width="100px" />
                        </asp:BoundField>
                    </Columns>
                    <HeaderStyle CssClass="t_headtext" />
                    <AlternatingRowStyle CssClass="t_alt_bg" />
                    <PagerSettings Visible="False" />
                </asp:GridView>
                <uc2:PageControl ID="pcBot" runat="server" OnPageChange="PageChange" />
            </td>
        </tr>
    </table>
</asp:Content>

