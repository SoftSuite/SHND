<%@ Page Language="C#" MasterPageFile="~/Templates/Page1.master" AutoEventWireup="true" CodeFile="PlanOrderFoodDivisionSearch.aspx.cs" Inherits="App_Plan_Transaction_PlanOrderFoodDivisionSearch" Title="SHND : Transaction - Food Order Planning" %>
<%@ Register Src="../../Templates/PageControl.ascx" TagName="PageControl" TagPrefix="uc2" %>
<%@ Register Src="../../Templates/ToolBarItemCtl.ascx" TagName="ToolBarItemCtl" TagPrefix="uc1" %>
<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" Runat="Server">
    <table border="0" cellpadding="0" cellspacing="0" width="100%">
        <tr>
            <td class="headtext">ข้อมูลแผนประมาณการวัสดุอาหาร
            </td>
        </tr>
        <tr>
            <td style="height:15px">
            </td>
        </tr>
        <tr>
            <td>
                <fieldset style="padding:15px;">
                    <legend style="font-weight:bold">ค้นหา</legend>
                    <table border="0" cellspacing="0" cellpadding="0" width="700">
                        <tr style="height:15px">
                            <td colspan="5"></td>
                        </tr>
                        <tr style="height:24px">
                            <td style="padding-right:10px; width:130px; text-align:right">
                                ชื่อแผนประมาณการ :</td>
                            <td colspan="4">
                                <asp:TextBox ID="txtSearchPlanName" runat="server" Width="330px" CssClass="zTextbox"></asp:TextBox>
                            </td>
                        </tr>
                        <tr style="height:24px">
                            <td style="padding-right:10px; width:130px; text-align:right">
                                งวดที่ :</td>
                            <td style="width:150px">
                                <asp:TextBox ID="txtSearchPhase" runat="server" Width="50px" MaxLength="2" CssClass="zTextboxR"></asp:TextBox>
                            </td>
                            <td style="width:30px; text-align:center"></td>
                            <td style="width:150px"></td>
                            <td></td>
                        </tr>
                        <tr style="height:24px">
                            <td style="padding-right:10px; width:130px; text-align:right">
                                ปีงบประมาณ :</td>
                            <td style="width:150px">
                                <asp:TextBox ID="txtSearchBudgetYear" runat="server" Width="50px" MaxLength="4" CssClass="zTextboxR"></asp:TextBox>
                            </td>
                            <td style="width:30px; text-align:center"></td>
                            <td style="width:150px"></td>
                            <td></td>
                        </tr>
                        <tr style="height:24px">
                            <td style="padding-right:10px; width:130px; text-align:right">
                                เลขที่ใบขออนุมัติ :</td>
                            <td style="width:150px">
                                <asp:TextBox ID="txtSearchQtCode" runat="server" Width="150px" MaxLength="20" CssClass="zTextbox"></asp:TextBox>
                            </td>
                            <td style="width:30px; text-align:center"></td>
                            <td style="width:150px"></td>
                            <td></td>
                        </tr>
                        <tr style="height:24px">
                            <td style="padding-right:10px; width:130px; text-align:right">
                                รหัสใบขอซื้อ/ขอจ้าง :</td>
                            <td style="width:150px">
                                <asp:TextBox ID="txtSearchRefPRSap" runat="server" Width="150px" MaxLength="20" CssClass="zTextbox"></asp:TextBox>
                            </td>
                            <td style="width:30px; text-align:center"></td>
                            <td style="width:150px"></td>
                            <td></td>
                        </tr>
                        <tr style="height:24px">
                            <td style="padding-right:10px; width:130px; text-align:right">
                                สถานะ :</td>
                            <td style="width:150px">
                                <asp:DropDownList ID="cmbSearchStatusFrom" runat="server" CssClass="zComboBox" Width="150px">
                                </asp:DropDownList></td>
                            <td style="width:30px; text-align:center">
                                ถึง</td>
                            <td style="width:150px">
                                <asp:DropDownList ID="cmbSearchStatusTo" runat="server" CssClass="zComboBox" Width="150px">
                                </asp:DropDownList></td>
                            <td>
                                &nbsp;&nbsp;
                                <asp:ImageButton ID="imbSearch" runat="server" ImageAlign="AbsMiddle" ImageUrl="~/Images/icn_find.png" OnClick="imbSearch_Click" />&nbsp;
                                <asp:ImageButton ID="imbReset" runat="server" ImageAlign="AbsMiddle" ImageUrl="~/Images/icn_back.png" OnClick="imbReset_Click" ToolTip="แสดงทั้งหมด" />
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
                        <asp:BoundField DataField="NAME" HeaderText="NAME">
                            <ControlStyle CssClass="zHidden" />
                            <FooterStyle CssClass="zHidden" />
                            <HeaderStyle CssClass="zHidden" />
                            <ItemStyle CssClass="zHidden" />
                        </asp:BoundField>
                        <asp:TemplateField HeaderText="ลำดับ" SortExpression="DEFAULT">
                            <HeaderStyle Width="60px" />
                            <ItemStyle HorizontalAlign="Center" Width="60px" Height="20px" />
                        </asp:TemplateField>
                        <asp:TemplateField HeaderText="ชื่อแผนประมาณการ" SortExpression="NAME">
                            <ItemTemplate>
                                <asp:LinkButton ID="lnkName" runat="server" Text='<%# Bind("NAME") %>' OnClick="lnkName_Click" CommandArgument='<%# Bind("LOID")  %>'></asp:LinkButton>
                            </ItemTemplate>
                        </asp:TemplateField>
                        <asp:BoundField DataField="DIVISIONNAME" HeaderText="หน่วยงาน" SortExpression="DIVISIONNAME">
                            <HeaderStyle Width="200px" />
                            <ItemStyle HorizontalAlign="Left" Width="200px" />
                        </asp:BoundField>
                        <asp:BoundField DataField="PHASEYEAR" HeaderText="งวด/ปี" SortExpression="PHASEYEAR">
                            <HeaderStyle Width="70px" />
                            <ItemStyle HorizontalAlign="Center" Width="70px" />
                        </asp:BoundField>
                        <asp:BoundField DataField="STATUSNAME" HeaderText="สถานะ" SortExpression="STATUSNAME">
                            <HeaderStyle HorizontalAlign="Center" Width="120px" />
                            <ItemStyle Width="120px" />
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