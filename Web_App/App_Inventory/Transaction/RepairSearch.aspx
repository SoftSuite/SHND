<%@ Page Language="C#" MasterPageFile="~/Templates/Page1.master" AutoEventWireup="true" CodeFile="RepairSearch.aspx.cs" Inherits="App_Inventory_Transaction_RepairSearch" Title="SHND : Transaction - Repair"%>
<%@ Register Src="../../Templates/CalendarControl.ascx" TagName="CalendarControl" TagPrefix="uc2" %>
<%@ Register Src="../../Templates/PageControl.ascx" TagName="PageControl" TagPrefix="uc2" %>
<%@ Register Src="../../Templates/ToolBarItemCtl.ascx" TagName="ToolBarItemCtl" TagPrefix="uc1" %>
<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="cc1" %>

<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" Runat="Server">
    <table width="100%" border="0" cellpadding="0" cellspacing="0">
        <tr>
            <td class="headtext">
                ข้อมูลการส่งซ่อม</td>
        </tr>
        <tr>
            <td>
                <uc1:ToolBarItemCtl ID="tbAdd" runat="server" ToobarTitle="เพิ่มข้อมูล" ToolbarImage="../../Images/icn_add.png"  Visible="false" />
            </td>
        </tr>
        <tr>
            <td>
                <hr style="size:1px" />
            </td>
        </tr>
        <tr>
            <td style="height: 15px">
            <fieldset style="padding:15px;">
            <legend style="font-weight:bold">
                ค้นหา
            </legend>
            
                <table cellspacing="0" cellpadding="0" border="0" width="100%">
                    <tr style="height:15px">
                        <td colspan="1" style="width: 131px">
                        </td>
                        <td colspan="1" style="width: 140px">
                        </td>
                        <td colspan="2">&nbsp;</td>
                        <td colspan="1">
                        </td>
                    </tr>
                    <tr>
                        <td style="padding-right: 10px; width: 131px; height: 24px; text-align: right">
                            เลขที่ส่งซ่อม :</td>
                        <td style="width: 140px; height: 24px;">
                            <asp:TextBox ID="txtCodeFrom" runat="server" CssClass="zTextbox" MaxLength="50"
                                Width="125px"></asp:TextBox></td>
                        <td style="width:19px; text-align: right; padding-right:10px; height: 24px;">
                            ถึง</td>
                        <td style="height: 24px; width: 160px;"><asp:TextBox ID="txtCodeTo" runat="server" CssClass="zTextbox" MaxLength="50" Width="125px"></asp:TextBox></td>
                        <td style="height: 24px">
                        </td>
                    </tr>
                    <tr>
                        <td style="padding-right: 10px; width: 131px; text-align: right; height: 24px;">
                            วันที่ส่งซ่อม :</td>
                        <td style="width: 140px; height: 24px;">
                            <uc2:CalendarControl ID="ctlStartDate" runat="server" />
                        </td>
                        <td style="width:19px; text-align: right; padding-right:10px; height: 24px;">
                            ถึง</td>
                        <td style="width: 160px; height: 24px;">
                            <uc2:CalendarControl ID="ctlEndDate" runat="server" />
                    </td>
                        <td style="height: 24px">
                        </td>
                    </tr>
                    <tr>
                        <td style="padding-right: 10px; width: 131px; text-align: right; height: 23px;">
                            หน่วยงาน :</td>
                        <td colspan="3" style="height: 24px">
                            <asp:DropDownList id="cmbSearchDiv" runat="server" Width="300px" CssClass="zComboBox">
                            </asp:DropDownList></td>
                        <td style="height: 23px">
                        </td>
                    </tr>
                    <tr>
                        <td style="padding-right: 10px; width: 131px; text-align: right; height: 24px;">
                            สถานะ :</td>
                        <td style="width: 140px; height: 24px;">
                            <asp:DropDownList ID="cmbSearchStatusFrom" runat="server" Width="131px" CssClass="zComboBox">
                            </asp:DropDownList></td>
                        <td style="padding-right: 10px; width: 19px; text-align: right; height: 24px;">
                            ถึง</td>
                        <td style="width: 160px; height: 24px;">
                            <asp:DropDownList id="cmbSearchStatusTo" runat="server" Width="131px" CssClass="zComboBox">
                            </asp:DropDownList></td>
                        <td style="height: 24px">
                            <asp:ImageButton ID="imbSearch" runat="server" ImageAlign="AbsMiddle" ImageUrl="~/Images/icn_find.png"
                    OnClick="imbSearch_Click" />&nbsp;
                            <asp:ImageButton ID="imbReset" runat="server" ImageAlign="AbsMiddle" ImageUrl="~/Images/icn_back.png"
                    OnClick="imbReset_Click" ToolTip="แสดงทั้งหมด" /></td>
                    </tr>
                </table>

                
            </fieldset>        
            </td>
        </tr>
        <tr>
            <td style="height:15px">
                <asp:Label ID="lbStatusMain" runat="server" EnableViewState="False"></asp:Label>
                <asp:TextBox id="txhSortField" runat="server" Visible="False" Width="15px">
                </asp:TextBox><asp:TextBox id="txhSortDir" runat="server" Visible="False" Width="15px"></asp:TextBox></td>
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
                        <asp:TemplateField HeaderText="ลำดับ" SortExpression="DEFAULT">
                            <HeaderStyle Width="60px" />
                            <ItemStyle HorizontalAlign="Center" Width="60px" />
                        </asp:TemplateField>
                        <asp:TemplateField HeaderText="เลขที่ส่งซ่อม" SortExpression="CODE">
                            <ItemTemplate>
                                <asp:LinkButton ID="lnkRepair" runat="server" Text='<%# Bind("CODE") %>' OnClick="lnkRepair_Click" CommandArgument='<%# Bind("LOID")  %>'></asp:LinkButton>
                            </ItemTemplate>
                            <HeaderStyle HorizontalAlign="Center" Width="100px" />
                            <ItemStyle HorizontalAlign="Center" Width="100px" Height="24px" />
                        </asp:TemplateField>
                        <asp:BoundField DataField="STOCKOUTDATE" HeaderText="วันที่ส่งซ่อม" DataFormatString="{0:dd/MM/yyyy}" HtmlEncode="False" SortExpression="STOCKOUTDATE">
                            <HeaderStyle Width="100px" HorizontalAlign="Center"/>
                            <ItemStyle Width="100px" HorizontalAlign="Center"/>
                        </asp:BoundField>
                        <asp:BoundField DataField="DIVISIONNAME" HeaderText="หน่วยที่ส่งซ่อม" SortExpression="DIVISIONNAME">
                        </asp:BoundField>
                        <asp:BoundField DataField="PRIORITYNAME" HeaderText="ความเร่งด่วน" SortExpression="PRIORITYNAME">
                            <HeaderStyle HorizontalAlign="Center" Width="100px" />
                            <ItemStyle HorizontalAlign="Center" Width="100px" />
                        </asp:BoundField>
                         <asp:BoundField DataField="STATUSNAME" HeaderText="สถานะ" SortExpression="STATUSNAME">
                            <HeaderStyle HorizontalAlign="Center" Width="100px" />
                            <ItemStyle Width="100px" />
                        </asp:BoundField>
                        <asp:BoundField DataField="PRIORITY" HeaderText="PRIORITY">
                            <ControlStyle CssClass="zHidden" />
                            <FooterStyle CssClass="zHidden" />
                            <HeaderStyle CssClass="zHidden" />
                            <ItemStyle CssClass="zHidden" />
                        </asp:BoundField>
                    </Columns>
                    <HeaderStyle CssClass="t_headtext" />
                    <AlternatingRowStyle CssClass="t_alt_bg" />
                    <PagerSettings Visible="False" />
                </asp:GridView><uc2:PageControl ID="pcBot" runat="server" OnPageChange="PageChange" />
                </td>
        </tr>
    </table>
    <asp:Panel ID="Panel1" runat="server" CssClass="modalPopup" style="display:none" Width="800px">
    </asp:Panel>
</asp:Content>



