<%@ Control Language="C#" AutoEventWireup="true" CodeFile="RepairrequestPopup.ascx.cs" Inherits="Search_RepairrequestPopup" %>
<%@ Register Src="../Templates/PageControl.ascx" TagName="PageControl" TagPrefix="uc2" %>
<%@ Register Src="../Templates/ToolBarItemCtl.ascx" TagName="ToolBarItemCtl" TagPrefix="uc1" %>
<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="cc1" %>
<cc1:ModalPopupExtender ID="popupRepairrequest"  runat="server" PopupControlID="pnlOfficer" BackgroundCssClass="modalBackground" DropShadow="true" TargetControlID="btntest"></cc1:ModalPopupExtender>
<asp:Panel ID="pnlOfficer" runat="server" CssClass="modalPopupSearch" style="display:none" >
    <table border="0" cellspacing="0" cellpadding="0" width="100%">
        <tr>
            <td class="headtext">รายการวัสดุ
            </td>
        </tr>
        <tr>
            <td><uc1:ToolBarItemCtl ID="tbBack" runat="server" ToobarTitle="กลับหน้ารายการ" ToolbarImage="../../Images/icn_back.png" OnClick="tbBackClick" />
                <asp:TextBox ID="txhSortField" runat="server" Visible="False" Width="15px"></asp:TextBox><asp:TextBox
                    ID="txhSortDir" runat="server" Visible="False" Width="15px"></asp:TextBox>
                <asp:TextBox ID="txtExistKeyList" runat="server" Visible="False" Width="15px"></asp:TextBox></td>
        </tr>
        <tr>
            <td><hr style="size:1px"/>
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
                        <tr style="height: 24px">
                            <td style="padding-right: 10px; width: 130px; text-align: right">
                                คลังสินค้า :</td>
                            <td>
                                <asp:DropDownList ID="cmbWarehouse" runat="server" CssClass="zComboBox" Width="206px">
                                </asp:DropDownList></td>
                        </tr>
                        <tr style="height:24px">
                            <td style="width:130px; padding-right:10px; text-align:right">
                                ประเภท &nbsp;:</td>
                            <td>
                                <asp:DropDownList ID="cmbSearchMaterial" runat="server" CssClass="zComboBox" Width="206px"></asp:DropDownList>
                            </td>
                        </tr>
                        <tr style="height:24px">
                            <td style="width:130px; padding-right:10px; text-align:right">
                                ชื่อวัสดุ :</td>
                            <td>
                                <asp:TextBox ID="txtSearchMaterialName" runat="server" CssClass="zTextbox" MaxLength="100" Width="200px"></asp:TextBox>
                                
                                &nbsp;&nbsp;<asp:ImageButton ID="imbSearch" runat="server" ImageAlign="AbsMiddle" ImageUrl="~/Images/icn_find.png" OnClick="imbSearch_Click" />&nbsp;
                                <asp:ImageButton ID="imbReset" runat="server" ImageAlign="AbsMiddle" ImageUrl="~/Images/icn_back.png" ToolTip="แสดงทั้งหมด" OnClick="imbReset_Click" /> 
                            </td>
                        </tr>
                    </table>
                </fieldset>     
            </td>
        </tr>
        <tr>
            <td>
                <uc2:PageControl ID="pcTop" runat="server" OnPageChange="PageChange" />
                <asp:GridView ID="gvMain" runat="server" AllowSorting="True" AutoGenerateColumns="False" CssClass="t_tablestyle" AllowPaging="True" PageSize="20" 
                    OnRowDataBound="gvMain_RowDataBound" OnSorting="gvMain_Sorting" Width="100%">
                    <Columns>
                        <asp:BoundField DataField="LOID" HeaderText="LOID">
                            <ControlStyle CssClass="zHidden" />
                            <FooterStyle CssClass="zHidden" />
                            <HeaderStyle CssClass="zHidden" />
                            <ItemStyle CssClass="zHidden" />
                        </asp:BoundField>
                        <asp:TemplateField>
                            <ItemTemplate>
                                <asp:ImageButton ID="imbSelect" runat="server" ImageUrl="~/Images/icn_add.png" OnClick="imbSelect_Click"
                                    ToolTip="เลือกรายการ" />
                            </ItemTemplate>
                            <HeaderStyle HorizontalAlign="Center" Width="30px" />
                            <ItemStyle HorizontalAlign="Center" Width="30px" />
                        </asp:TemplateField>
                        <asp:TemplateField HeaderText="ลำดับ" SortExpression="DEFAULT">
                            <HeaderStyle Width="60px" />
                            <ItemStyle HorizontalAlign="Center" Width="60px" />
                        </asp:TemplateField>
                        <asp:BoundField DataField="SAPCODE" HeaderText="รหัส SAP" SortExpression="SAPCODE">
                            <ItemStyle Width="100px" HorizontalAlign="Center"/>
                            <HeaderStyle HorizontalAlign="Center" Width="100px"/>
                        </asp:BoundField>
                        <asp:BoundField DataField="LOTNO" HeaderText="รหัสครุภัณฑ์" SortExpression="LOTNO" NullDisplayText="">
                            <ItemStyle Width="100px" HorizontalAlign="Center"/>
                            <HeaderStyle HorizontalAlign="Center" Width="100px" />
                        </asp:BoundField>
                        <asp:BoundField DataField="MATERIALNAME" HeaderText="รายการ" SortExpression="MATERIALNAME">
                        </asp:BoundField>
                         <asp:BoundField DataField="UNITNAME" HeaderText="หน่วยนับ" SortExpression="UNITNAME">
                            <HeaderStyle HorizontalAlign="Center" Width="100px" />
                            <ItemStyle Width="100px" />
                        </asp:BoundField>
                        <asp:BoundField DataField="BRAND" HeaderText="BRAND" NullDisplayText="">
                            <ControlStyle CssClass="zHidden" />
                            <FooterStyle CssClass="zHidden" />
                            <HeaderStyle CssClass="zHidden" />
                            <ItemStyle CssClass="zHidden" />
                        </asp:BoundField>
                        <asp:BoundField DataField="MATERIALMASTER" HeaderText="MATERIALMASTER">
                            <ControlStyle CssClass="zHidden" />
                            <FooterStyle CssClass="zHidden" />
                            <HeaderStyle CssClass="zHidden" />
                            <ItemStyle CssClass="zHidden" />
                        </asp:BoundField>
                        <asp:BoundField DataField="UNIT" HeaderText="UNIT">
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