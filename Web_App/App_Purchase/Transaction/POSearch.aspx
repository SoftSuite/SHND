<%@ Page Language="C#" MasterPageFile="~/Templates/Page1.master" AutoEventWireup="true" CodeFile="POSearch.aspx.cs" Inherits="App_Purchase_Transaction_POSearch" Title="SHND : Transaction - Purchase Order" %>
<%@ Register Src="../../Templates/CalendarControl.ascx" TagName="CalendarControl" TagPrefix="uc3" %>
<%@ Register Src="../../Templates/PageControl.ascx" TagName="PageControl" TagPrefix="uc2" %>
<%@ Register Src="../../Templates/ToolBarItemCtl.ascx" TagName="ToolBarItemCtl" TagPrefix="uc1" %>
<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="cc1" %>
<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" Runat="Server">
    <table width="100%" border="0" cellpadding="0" cellspacing="0">
        <tr>
            <td class="headtext">
                ใบสั่งซื้อ(PO)</td>
        </tr>
        <tr>
            <td>
                <uc1:ToolBarItemCtl ID="tbAdd" runat="server" ToobarTitle="สร้างใบสั่งซื้อ VAT" ToolbarImage="../../Images/icn_add.png" Visible="false" OnClick="tbAddClick"/>
                <uc1:ToolBarItemCtl ID="tbAdd2" runat="server" ToobarTitle="สร้างใบสั่งซื้อไม่ VAT" ToolbarImage="../../Images/icn_add.png" Visible="false" OnClick="tbAdd2Click"/>

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
                            เลขที่ PO :</td>
                        <td style="width:140px;">
                            <asp:TextBox ID="txtPOCodeFrom" runat="server" CssClass="zTextbox" MaxLength="100" Width="125px"></asp:TextBox>
                        </td>
                        <td style="width:30px; text-align:center;">
                            ถึง</td>
                        <td style="width:160px;">
                            <asp:TextBox ID="txtPOCodeTo" runat="server" CssClass="zTextbox" MaxLength="100" Width="125px"></asp:TextBox></td>
                        <td>
                        </td>
                    </tr>
                     <tr style="height: 24px">
                        <td style="padding-right: 10px; width: 130px; text-align: right">
                            วันที่ PO :</td>
                        <td style="width: 140px">
                            <uc3:CalendarControl ID="ctlPODateFrom" runat="server" />
                        </td>
                        <td style="width: 30px; text-align: center">
                            ถึง</td>
                        <td style="width: 160px">
                            <uc3:CalendarControl ID="ctlPODateTo" runat="server" />
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
                    <tr style="height:24px">
                        <td style="width:130px; text-align: right; padding-right:10px">
                            เลขที่ใบสั่งซื้อล่วงหน้า :</td>
                        <td style="width:140px;">
                            <asp:TextBox ID="txtPrePOCodeFrom" runat="server" CssClass="zTextbox" MaxLength="100" Width="125px"></asp:TextBox>
                        </td>
                        <td style="width:30px; text-align:center;">
                            ถึง</td>
                        <td style="width:160px;">
                            <asp:TextBox ID="txtPrePOCodeTo" runat="server" CssClass="zTextbox" MaxLength="100" Width="125px"></asp:TextBox></td>
                        <td>
                        </td>
                    </tr>
                    <tr style="height: 24px">
                        <td style="padding-right: 10px; width: 130px; text-align: right">
                            วันที่สั่งซื้อล่วงหน้า :</td>
                        <td style="width: 140px">
                            <uc3:CalendarControl ID="ctlPrePODateFrom" runat="server" />
                        </td>
                        <td style="width: 30px; text-align: center">
                            ถึง</td>
                        <td style="width: 160px">
                            <uc3:CalendarControl ID="ctlPrePODateTo" runat="server" />
                        </td>
                        <td>
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
            <td style="width:1150px">
                <uc2:PageControl ID="pcTop" runat="server" />
                 <asp:GridView ID="gvMain" runat="server" AllowSorting="True" AutoGenerateColumns="False" CssClass="t_tablestyle" OnRowDataBound="gvMain_RowDataBound" OnSorting="gvMain_Sorting" AllowPaging="True" PageSize="20"  style="width:100%">
                    <PagerSettings Visible="False" />
                    <Columns>
<asp:BoundField DataField="LOID" HeaderText="LOID">
<ControlStyle CssClass="zHidden"></ControlStyle>

<ItemStyle CssClass="zHidden"></ItemStyle>

<HeaderStyle CssClass="zHidden"></HeaderStyle>

<FooterStyle CssClass="zHidden"></FooterStyle>
</asp:BoundField>

<asp:TemplateField SortExpression="DEFAULT" HeaderText="ลำดับ">
<ItemStyle Width="40px" HorizontalAlign="Center" Height="20px"></ItemStyle>

<HeaderStyle Width="40px"></HeaderStyle>
</asp:TemplateField>
<asp:TemplateField SortExpression="CODE" HeaderText="เลขที่ PO">
<ItemStyle Width="120px" HorizontalAlign="Center"></ItemStyle>

<HeaderStyle Width="120px" HorizontalAlign="Center"></HeaderStyle>
<ItemTemplate>
                            <asp:LinkButton ID="lnkCode" runat="server" Text='<%# Bind("CODE") %>' CommandArgument='<%# Bind("LOID")  %>'  OnClick="linkCode_Click"></asp:LinkButton>
                            
</ItemTemplate>
</asp:TemplateField>
<asp:BoundField HtmlEncode="False" DataFormatString="{0:dd/MM/yyyy}" DataField="PODATE" SortExpression="PODATE" HeaderText="วันที่ PO">
<ItemStyle Width="150px" HorizontalAlign="Center"></ItemStyle>

<HeaderStyle Width="150px" HorizontalAlign="Center"></HeaderStyle>
</asp:BoundField>
<asp:BoundField DataField="CLASSNAME" SortExpression="CLASSNAME" HeaderText="หมวดอาหาร">
<ItemStyle Width="200px"></ItemStyle>
<HeaderStyle Width="200px" HorizontalAlign="Center"></HeaderStyle>
</asp:BoundField>
<asp:BoundField DataField="SUPPLIERNAME" SortExpression="SUPPLIERNAME" HeaderText="ชื่อบริษัท/ผู้จำหน่าย"></asp:BoundField>
<asp:BoundField DataField="CONTRACTCODE" SortExpression="CONTRACTCODE" HeaderText="เลขที่สัญญา">
<ItemStyle Width="100px" HorizontalAlign="Center"></ItemStyle>
<HeaderStyle Width="100px" HorizontalAlign="Center"></HeaderStyle>
</asp:BoundField>
<asp:BoundField DataField="STATUSNAME" SortExpression="STATUSNAME" HeaderText="สถานะ">
<ItemStyle Width="150px"></ItemStyle>
<HeaderStyle Width="150px" HorizontalAlign="Center"></HeaderStyle>
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