<%@ Control Language="C#" AutoEventWireup="true" CodeFile="MaterialReturnRequestPopup.ascx.cs" Inherits="Search_MaterialReturnRequestPopup" %>
<%@ Register Src="../Templates/PageControl.ascx" TagName="PageControl" TagPrefix="uc2" %>
<%@ Register Src="../Templates/ToolBarItemCtl.ascx" TagName="ToolBarItemCtl" TagPrefix="uc1" %>
<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="cc1" %>
<cc1:ModalPopupExtender ID="popupMaterialMaster"  runat="server" PopupControlID="pnlMaterialMaster" BackgroundCssClass="modalBackground" DropShadow="true" TargetControlID="btntest"></cc1:ModalPopupExtender>
<asp:Panel ID="pnlMaterialMaster" runat="server" CssClass="modalPopupSearch" style="display:none" Width="800px" Height="600px" ScrollBars="Auto">
    <table border="0" cellspacing="0" cellpadding="0" width="780px">
        <tr>
            <td class="headtext">รายการวัสดุที่คืนคลัง
            </td>
        </tr>
        <tr>
            <td><uc1:ToolBarItemCtl ID="tbBack" runat="server" ToobarTitle="กลับหน้ารายการ" ToolbarImage="../../Images/icn_back.png" OnClick="tbBackClick" />
                <asp:TextBox ID="txhSortField" runat="server" Visible="False" Width="15px"></asp:TextBox><asp:TextBox
                    ID="txhSortDir" runat="server" Visible="False" Width="15px"></asp:TextBox>
                <asp:TextBox ID="txtExistCodeList" runat="server" Visible="False" Width="15px"></asp:TextBox>
                <asp:TextBox ID="txtExistMaterialMasterList" runat="server" Visible="False" Width="15px"></asp:TextBox>
                <asp:TextBox ID="txtDocType" runat="server" Visible="False" Width="15px"></asp:TextBox>
                <asp:TextBox ID="txtDivision" runat="server" Visible="False" Width="15px"></asp:TextBox>
                <asp:TextBox ID="txtWarehouse" runat="server" Visible="False" Width="15px"></asp:TextBox>
                <asp:TextBox ID="txtType" runat="server" Visible="False" Width="15px"></asp:TextBox></td>
        </tr>
        <tr>
            <td><hr style="size:1px" />
            </td>
        </tr>
        <tr>
            <td>
                <fieldset style="padding:15px;">
                    <legend style="font-weight:bold">
                        ค้นหา
                    </legend>
                    <table border="0" cellpadding="0" cellspacing="0" width="700">
                        <tr style="height:15px">
                            <td></td>
                            <td></td>
                        </tr>
                        
                        <tr style="height:24px">
                            <td style="width:130px; padding-right:10px; text-align:right">ชื่อวัสดุ :</td>
                            <td>
                                <asp:TextBox ID="txtSearchName" runat="server" CssClass="zTextbox" MaxLength="150" Width="350px"></asp:TextBox>
                                
                                &nbsp;&nbsp;<asp:ImageButton ID="imbSearch" runat="server" ImageAlign="AbsMiddle" ImageUrl="~/Images/icn_find.png" OnClick="imbSearch_Click" />&nbsp;
                                <asp:ImageButton ID="imbReset" runat="server" ImageAlign="AbsMiddle" ImageUrl="~/Images/icn_back.png" ToolTip="แสดงทั้งหมด" OnClick="imbReset_Click" /> 
                            </td>
                        </tr>
                        <tr style="height:24px">
                            <td style="width:130px; padding-right:10px; text-align:right" visible ="false" >หน่วยงาน :</td>
                            <td>
                                <asp:DropDownList ID="cmbDivision" runat="server" CssClass="zComboBox" Width="200px" Enabled ="false" ></asp:DropDownList>
                            </td>
                        </tr>
                    </table>
                </fieldset>     
            </td>
        </tr>
        <tr>
            <td class="toolbarplace">
                <uc1:ToolBarItemCtl ID="tbAdd" runat="server" ToobarTitle="เพิ่มรายการ" ToolbarImage="../../Images/icn_add.png" OnClick="tbAddClick" />
            </td>
        </tr>
        <tr>
            <td>
                <uc2:PageControl ID="pcTop" runat="server" OnPageChange="PageChange" />
                <asp:GridView ID="gvMain" runat="server" AllowSorting="True" AutoGenerateColumns="False" CssClass="t_tablestyle" AllowPaging="True" PageSize="20" OnRowDataBound="gvMain_RowDataBound" OnSorting="gvMain_Sorting" Width="100%">
                    <Columns>
                        <asp:BoundField DataField="MATERIALMASTER" HeaderText="MATERIALMASTER">
                            <ControlStyle CssClass="zHidden" />
                            <FooterStyle CssClass="zHidden" />
                            <HeaderStyle CssClass="zHidden" />
                            <ItemStyle CssClass="zHidden" />
                        </asp:BoundField>
                        <asp:TemplateField>
                            <HeaderTemplate>
                                <asp:CheckBox ID="chkAll" runat="server" />
                            </HeaderTemplate>
                            <ItemTemplate>
                                <asp:CheckBox ID="chkSelect" runat="server" />
                            </ItemTemplate>
                            <HeaderStyle HorizontalAlign="Center" Width="30px" />
                            <ItemStyle HorizontalAlign="Center" Width="30px" />
                        </asp:TemplateField>
                        <asp:TemplateField HeaderText="ลำดับ" SortExpression="DEFAULT">
                            <HeaderStyle Width="60px" />
                            <ItemStyle HorizontalAlign="Center" Width="60px" />
                        </asp:TemplateField>
                        <asp:BoundField DataField="MATERIALCODE" HeaderText="รหัสวัสดุ" SortExpression="MATERIALCODE">
                            <HeaderStyle HorizontalAlign="Center" Width="80px" />
                            <ItemStyle Width="80px" />
                        </asp:BoundField>
                        <asp:BoundField DataField="MATERIALNAME" HeaderText="ชื่อวัสดุ" SortExpression="MATERIALNAME">
                        </asp:BoundField>
                        <asp:BoundField DataField="UNITNAME" HeaderText="หน่วยนับ" SortExpression="UNITNAME">
                            <HeaderStyle HorizontalAlign="Center" Width="80px" />
                            <ItemStyle Width="80px" />
                        </asp:BoundField>
                        <asp:BoundField DataField="QTY" HeaderText="จำนวนเบิก" SortExpression="QTY" HtmlEncode="False" DataFormatString="{0:#,##0.00}">
                            <HeaderStyle HorizontalAlign="Center" Width="100px" />
                            <ItemStyle HorizontalAlign="Right" Width="100px" />
                        </asp:BoundField>
                        <asp:BoundField DataField="UNIT" HeaderText="UNIT">
                            <ControlStyle CssClass="zHidden" />
                            <FooterStyle CssClass="zHidden" />
                            <HeaderStyle CssClass="zHidden" />
                            <ItemStyle CssClass="zHidden" />
                        </asp:BoundField>
                        <asp:BoundField DataField="DIVISION" HeaderText="DIVISION">
                            <ControlStyle CssClass="zHidden" />
                            <FooterStyle CssClass="zHidden" />
                            <HeaderStyle CssClass="zHidden" />
                            <ItemStyle CssClass="zHidden" />
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
</asp:Panel>
<asp:Button ID="btntest" runat="server" Text="test" CssClass="zHidden" />
