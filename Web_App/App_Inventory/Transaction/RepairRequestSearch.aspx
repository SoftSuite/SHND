<%@ Page Language="C#" MasterPageFile="~/Templates/Page1.master" AutoEventWireup="true" CodeFile="RepairRequestSearch.aspx.cs" Inherits="App_Inventory_Transaction_RepairRequestSearch" Title="SHND : Transaction - Repair Requisition" %>
<%@ Register Src="../../Search/RepairrequestPopup.ascx" TagName="RepairrequestPopup" TagPrefix="uc3" %>
<%@ Register Src="../../Templates/CalendarControl.ascx" TagName="CalendarControl" TagPrefix="uc2" %>
<%@ Register Src="../../Templates/PageControl.ascx" TagName="PageControl" TagPrefix="uc2" %>
<%@ Register Src="../../Templates/ToolBarItemCtl.ascx" TagName="ToolBarItemCtl" TagPrefix="uc1" %>
<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="cc1" %>
<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" Runat="Server">
    <table width="100%" border="0" cellpadding="0" cellspacing="0">
        <tr>
            <td class="headtext">
                �����š���駫���</td>
        </tr>
        <tr>
            <td>
                <uc1:ToolBarItemCtl ID="tbAdd" runat="server" ToobarTitle="����������" OnClick="tbAddClick" ToolbarImage="../../Images/icn_add.png"/>
                <uc1:ToolBarItemCtl ID="tbDelete" runat="server" ToobarTitle="ź�����ŷ�����͡" OnClick="tbDeleteClick" ToolbarImage="../../Images/icn_delete.png" ClientClick="return confirm('��ͧ���ź�����ŷ�����͡ ���������?')"  />
                <uc1:ToolBarItemCtl ID="tbSent" runat="server" ToobarTitle="�觢�����" OnClick="tbSentClick" ToolbarImage="../../Images/icn_add.png" ClientClick="return confirm('��ͧ����觢����ŷ�����͡ ���������?')" />
            </td>
        </tr>
        <tr>
            <td><hr style="size:1px"/>
                <asp:Label id="lbStatus" runat="server" ForeColor="Red"></asp:Label></td>
        </tr>
        <tr>
            <td>
                <fieldset style="padding:15px;">
                    <legend style="font-weight:bold">
                        ����
                    </legend>
                
                    <table cellspacing="0" cellpadding="0" border="0" width="800">
                        <tr style="height:15px">
                            <td colspan="1" style="width: 130px">
                            </td>
                            <td colspan="1" style="width: 140px">
                            </td>
                            <td colspan="2">&nbsp;</td>
                            <td colspan="1">
                            </td>
                        </tr>
                        <tr>
                            <td style="padding-right: 10px; width: 130px; height: 24px; text-align: right">
                                �Ţ����駫��� :</td>
                            <td style="width: 140px; height: 24px;">
                                <asp:TextBox ID="txtCodeFrom" runat="server" CssClass="zTextbox" MaxLength="50"
                                    Width="125px"></asp:TextBox></td>
                            <td style="width:19px; text-align: right; padding-right:10px; height: 24px;">
                                �֧</td>
                            <td style="height: 24px; width: 160px;"><asp:TextBox ID="txtCodeTo" runat="server" CssClass="zTextbox" MaxLength="50" Width="125px"></asp:TextBox></td>
                            <td style="height: 24px">
                            </td>
                        </tr>
                        <tr>
                            <td style="padding-right: 10px; width: 130px; text-align: right">
                                �ѹ����駫��� :</td>
                            <td style="width: 140px">
                                <uc2:CalendarControl ID="ctlStartDate" runat="server" />
                            </td>
                            <td style="width:19px; text-align: right; padding-right:10px">
                                �֧</td>
                            <td style="width: 160px">
                                <uc2:CalendarControl ID="ctlEndDate" runat="server" />
                        </td>
                            <td>
                            </td>
                        </tr>
                        <tr>
                            <td style="padding-right: 10px; width: 130px; text-align: right; height: 24px;">
                                ʶҹ� :</td>
                            <td style="width: 140px; height: 24px;">
                                <asp:DropDownList ID="cmbSearchStatusFrom" runat="server" Width="131px" CssClass="zComboBox">
                                </asp:DropDownList></td>
                            <td style="padding-right: 10px; width: 19px; text-align: right; height: 24px;">
                                �֧</td>
                            <td style="width: 160px; height: 24px;">
                                <asp:DropDownList ID="cmbSearchStatusTo" runat="server" Width="131px" CssClass="zComboBox">
                                </asp:DropDownList></td>
                            <td style="height: 24px">
                                <asp:ImageButton ID="imbSearch" runat="server" ImageAlign="AbsMiddle" ImageUrl="~/Images/icn_find.png"
                        OnClick="imbSearch_Click" />
                    <asp:ImageButton ID="imbReset" runat="server" ImageAlign="AbsMiddle" ImageUrl="~/Images/icn_back.png"
                        OnClick="imbReset_Click" ToolTip="�ʴ�������" /></td>
                        </tr>
                    </table>
                </fieldset>        
            </td>
        </tr>
        <tr>
            <td style="height:15px">
                <asp:Label ID="lbStatusMain" runat="server" EnableViewState="False"></asp:Label>
                <asp:TextBox id="txhSortField" runat="server" Visible="False" Width="15px">
                </asp:TextBox>
                <asp:TextBox id="txhSortDir" runat="server" Visible="False" Width="15px">
                </asp:TextBox></td>
        </tr>
        <tr>
            <td>
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
                        <asp:TemplateField>
                            <HeaderTemplate>
                                <input type="checkbox" name="chkMain" id="chkMain" onclick="chkAllBox(this, 'ctl00_MainContent_gvMain_ctl', '_chkSelect')" />
                            </HeaderTemplate>
                            <ItemTemplate>
                                <asp:CheckBox ID="chkSelect" runat="server" Enabled='<%# Eval("STATUS").ToString() == "WA" %>'/>
                            </ItemTemplate>
                            <HeaderStyle HorizontalAlign="Center" Width="30px" />
                            <ItemStyle HorizontalAlign="Center" Width="30px" />
                        </asp:TemplateField>
                        <asp:TemplateField HeaderText="�ӴѺ" SortExpression="DEFAULT">
                            <HeaderStyle Width="60px" />
                            <ItemStyle HorizontalAlign="Center" Width="60px" />
                        </asp:TemplateField>
                        <asp:TemplateField HeaderText="�Ţ����駫���" SortExpression="CODE">
                            <ItemTemplate>
                                <asp:LinkButton ID="lnkCode" runat="server" Text='<%# Bind("CODE") %>' OnClick="lnkCode_Click" CommandArgument='<%# Bind("LOID")  %>'></asp:LinkButton>
                            </ItemTemplate>
                            <HeaderStyle HorizontalAlign="Center" Width="100px" />
                            <ItemStyle HorizontalAlign="center" Width="100px" />
                        </asp:TemplateField>
                        <asp:BoundField DataField="STOCKOUTDATE" HeaderText="�ѹ����駫���" DataFormatString="{0:dd/MM/yyyy}" HtmlEncode="False"  SortExpression="STOCKOUTDATE">
                            <HeaderStyle Width="100px" />
                            <ItemStyle Width="100px" HorizontalAlign="Center"/>
                        </asp:BoundField>
                        <asp:BoundField DataField="DIVISIONNAME" HeaderText="˹��§ҹ����駫���" SortExpression="DIVISIONNAME">
                            <HeaderStyle HorizontalAlign="Center" Width="350px" />
                            <ItemStyle Width="350px" />
                        </asp:BoundField>
                         <asp:BoundField DataField="STATUSNAME" HeaderText="ʶҹ�" SortExpression="STATUSNAME">
                            <HeaderStyle HorizontalAlign="Center" Width="100px" />
                            <ItemStyle Width="100px" />
                        </asp:BoundField>
                    </Columns>
                    <HeaderStyle CssClass="t_headtext" />
                    <AlternatingRowStyle CssClass="t_alt_bg" />
                    <PagerSettings Visible="False" />
                </asp:GridView><uc2:PageControl ID="pcBot" runat="server" OnPageChange="PageChange" />
                </td>
        </tr>
    </table>
</asp:Content>

