<%@ Page Language="C#" MasterPageFile="~/Templates/Page1.master" AutoEventWireup="true" CodeFile="PrePOSearch.aspx.cs" Inherits="App_Purchase_Transaction_PrePOSearch" Title="SHND : Transaction - Pre Purchase Order" %>
<%@ Register Src="../../Templates/CalendarControl.ascx" TagName="CalendarControl" TagPrefix="uc3" %>
<%@ Register Src="../../Templates/PageControl.ascx" TagName="PageControl" TagPrefix="uc2" %>
<%@ Register Src="../../Templates/ToolBarItemCtl.ascx" TagName="ToolBarItemCtl" TagPrefix="uc1" %>
<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="cc1" %>
<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" Runat="Server">
    <table width="100%" border="0" cellpadding="0" cellspacing="0">
        <tr>
            <td class="headtext">
                ใบสั่งซื้อล่วงหน้า</td>
        </tr>
        <tr>
            <td>
                <uc1:ToolBarItemCtl ID="tbAdd" runat="server" ToobarTitle="เพิ่มข้อมูล" ToolbarImage="../../Images/icn_add.png" OnClick="tbAddClick"/>
            </td>
        </tr>
        <tr>
            <td>
                <hr style="size:1px"/>
            </td>
        </tr>
        <tr>
            <td style="height: 15px">
            <fieldset style="padding:15px;">
            <legend style="font-weight:bold">
                ค้นหา
            </legend>
            
                <table cellspacing="0" cellpadding="0" border="0" width="800">
                    <tr style="height:15px">
                        <td colspan="5">&nbsp;</td>
                    </tr>
                    <tr style="height:24px">
                        <td style="width:130px; text-align: right; padding-right:10px">
                            เลขที่สั่งซื้อล่วงหน้า :</td>
                        <td style="width:140px;">
                            <asp:TextBox ID="txtSearchCodeFrom" runat="server" CssClass="zTextbox" MaxLength="100" Width="125px"></asp:TextBox>
                        </td>
                        <td style="width:30px; text-align:center;">
                            ถึง</td>
                        <td style="width:160px;">
                            <asp:TextBox ID="txtSearchCodeTo" runat="server" CssClass="zTextbox" MaxLength="100" Width="125px"></asp:TextBox></td>
                        <td>
                        </td>
                    </tr>
                    <tr style="height: 24px">
                        <td style="padding-right: 10px; width: 130px; text-align: right">
                            วันที่สั่งซื้อล่วงหน้า :</td>
                        <td style="width: 140px">
                            <uc3:CalendarControl ID="ctlSearchPODateFrom" runat="server" />
                        </td>
                        <td style="width: 30px; text-align: center">
                            ถึง</td>
                        <td style="width: 160px">
                            <uc3:CalendarControl ID="ctlSearchPODateTo" runat="server" />
                        </td>
                        <td>
                        </td>
                    </tr>
                    <tr style="height: 24px">
                        <td style="padding-right: 10px; width: 130px; text-align: right">
                            วันที่ใช้ :</td>
                        <td style="width: 140px">
                            <uc3:CalendarControl ID="ctlSearchUseDateFrom" runat="server" />
                        </td>
                        <td style="width: 30px; text-align: center">
                            ถึง</td>
                        <td style="width: 160px">
                            <uc3:CalendarControl ID="ctlSearchUseDateTo" runat="server" />
                        </td>
                        <td>
                        </td>
                    </tr>
                    <tr style="height: 24px">
                        <td style="padding-right: 10px; width: 130px; text-align: right">
                            หมวดอาหาร :</td>
                        <td colspan="4">
                            <asp:DropDownList ID="cmbSearchMaterialClass" runat="server" Width="302px" CssClass="zComboBox"></asp:DropDownList>
                        </td>
                    </tr>
                    <tr style="height: 24px">
                        <td style="padding-right: 10px; width: 130px; text-align: right">
                            เลขที่สัญญา :</td>
                        <td style="width: 140px">
                            <asp:TextBox ID="txtSearchContractCode" runat="server" CssClass="zTextbox" MaxLength="100" Width="125px"></asp:TextBox></td>
                        <td style="width: 30px; text-align: center">
                        </td>
                        <td style="width: 160px">
                        </td>
                        <td>
                        </td>
                    </tr>
                    <tr style="height: 24px">
                        <td style="padding-right: 10px; width: 130px; text-align: right">
                            ชื่อบริษัท/ผู้จำหน่าย :</td>
                        <td colspan="4">
                            <asp:TextBox ID="txtSearchSupplier" runat="server" CssClass="zTextbox" MaxLength="100" Width="296px"></asp:TextBox></td>
                    </tr>
                    <tr style="height: 24px">
                        <td style="padding-right: 10px; width: 130px; text-align: right">
                            แผนประมาณการ :</td>
                        <td colspan="4">
                            <asp:DropDownList ID="cmbSearchOrederPlan" runat="server" Width="302px" CssClass="zComboBox"></asp:DropDownList>
                        </td>
                    </tr>
                    <tr style="height:24px">
                        <td style="width:130px; text-align: right; padding-right:10px">
                            สถานะ :</td>
                        <td style="width:140px;">
                            <asp:DropDownList ID="cmbSearchStatusFrom" runat="server" Width="131px" CssClass="zComboBox"></asp:DropDownList>
                        </td>
                        <td style="width:30px; text-align:center;">
                            ถึง</td>
                        <td style="width:160px;"><asp:DropDownList ID="cmbSearchStatusTo" runat="server" Width="131px" CssClass="zComboBox">
                        </asp:DropDownList></td>
                        <td>
                            &nbsp;&nbsp;<asp:ImageButton ID="imbSearch" runat="server" ImageAlign="AbsMiddle" ImageUrl="~/Images/icn_find.png" OnClick="imbSearch_Click" />&nbsp;
                            <asp:ImageButton ID="imbReset" runat="server" ImageAlign="AbsMiddle" ImageUrl="~/Images/icn_back.png" ToolTip="แสดงทั้งหมด" OnClick="imbReset_Click" />
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
            <td style="width:1150px">
                <uc2:PageControl ID="pcTop" runat="server" />
                 <asp:GridView ID="gvMain" runat="server" AllowSorting="True" AutoGenerateColumns="False" CssClass="t_tablestyle" OnRowDataBound="gvMain_RowDataBound" OnSorting="gvMain_Sorting" AllowPaging="True" PageSize="20"  style="width:100%" Width="100%">
                    <PagerSettings Visible="False" />
                    <Columns>
                        <asp:BoundField DataField="LOID" HeaderText="LOID">
                            <ControlStyle CssClass="zHidden"></ControlStyle>
                            <ItemStyle CssClass="zHidden"></ItemStyle>
                            <HeaderStyle CssClass="zHidden"></HeaderStyle>
                            <FooterStyle CssClass="zHidden"></FooterStyle>
                        </asp:BoundField>

                        <asp:TemplateField SortExpression="DEFAULT" HeaderText="ลำดับ">
                            <ItemStyle Width="60px" HorizontalAlign="Center" Height="20px"></ItemStyle>
                            <HeaderStyle Width="60px"></HeaderStyle>
                        </asp:TemplateField>
                        
                        <asp:TemplateField SortExpression="CODE" HeaderText="เลขที่สั่งซื้อ">
                            <ItemStyle Width="100px" HorizontalAlign="Center"></ItemStyle>
                            <HeaderStyle Width="100px" HorizontalAlign="Center"></HeaderStyle>
                            <ItemTemplate>
                                <asp:LinkButton ID="lnkCode" runat="server" Text='<%# Bind("CODE") %>' CommandArgument='<%# Bind("LOID")  %>'  OnClick="linkCode_Click"></asp:LinkButton>
                            </ItemTemplate>
                        </asp:TemplateField>
                        
                        <asp:BoundField HtmlEncode="False" DataFormatString="{0:dd/MM/yyyy}" DataField="BPODATE" SortExpression="BPODATE" HeaderText="วันที่สั่งซื้อ">
                            <ItemStyle Width="100px" HorizontalAlign="Center"></ItemStyle>
                            <HeaderStyle Width="100px" HorizontalAlign="Center"></HeaderStyle>
                        </asp:BoundField>
                        
                        <asp:BoundField HtmlEncode="False" DataFormatString="{0:dd/MM/yyyy}" DataField="USEDATE" SortExpression="USEDATE" HeaderText="วันที่ใช้">
                            <ItemStyle Width="100px" HorizontalAlign="Center"></ItemStyle>
                            <HeaderStyle Width="100px" HorizontalAlign="Center"></HeaderStyle>
                        </asp:BoundField>
                        
                        <asp:BoundField DataField="CLASSNAME" SortExpression="CLASSNAME" HeaderText="หมวดอาหาร">
                            <ItemStyle Width="250px"></ItemStyle>
                            <HeaderStyle Width="250px" HorizontalAlign="Center"></HeaderStyle>
                        </asp:BoundField>
                        
                        <asp:BoundField DataField="SUPPLIERNAME" SortExpression="SUPPLIERNAME" HeaderText="ชื่อบริษัท/ผู้จำหน่าย"></asp:BoundField>
                        
                        <asp:BoundField DataField="CONTRACTCODE" SortExpression="CONTRACTCODE" HeaderText="เลขที่สัญญา">
                            <ItemStyle Width="80px" HorizontalAlign="Center"></ItemStyle>
                            <HeaderStyle Width="80px" HorizontalAlign="Center"></HeaderStyle>
                        </asp:BoundField>
                        
                        <asp:BoundField DataField="STATUSNAME" SortExpression="STATUSNAME" HeaderText="สถานะ">
                            <ItemStyle Width="100px"></ItemStyle>
                            <HeaderStyle Width="100px" HorizontalAlign="Center"></HeaderStyle>
                        </asp:BoundField>
                    </Columns>
                   <HeaderStyle CssClass="t_headtext" />
                    <AlternatingRowStyle CssClass="t_alt_bg" />
                </asp:GridView>
                <uc2:PageControl ID="pcBot" runat="server" />
            </td>
        </tr>
    </table>
</asp:Content>