<%@ Control Language="C#" AutoEventWireup="true" CodeFile="POPopup.ascx.cs" Inherits="Search_POPopup" %>
<%@ Register Src="../Templates/CalendarControl.ascx" TagName="CalendarControl" TagPrefix="uc3" %>
<%@ Register Src="../Templates/PageControl.ascx" TagName="PageControl" TagPrefix="uc2" %>
<%@ Register Src="../Templates/ToolBarItemCtl.ascx" TagName="ToolBarItemCtl" TagPrefix="uc1" %>
<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="cc1" %>
<cc1:ModalPopupExtender ID="popupPO"  runat="server" PopupControlID="pnlOfficer" BackgroundCssClass="modalBackground" DropShadow="true" TargetControlID="btntest"></cc1:ModalPopupExtender>
<asp:Panel ID="pnlOfficer" runat="server" CssClass="modalPopupSearch" style="display:none" >
    <table border="0" cellspacing="0" cellpadding="0" width="100%">
        <tr>
            <td class="headtext">
                ค้นหาใบสั่งซื้อล่วงหน้าที่ตรวจรับแล้ว</td>
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
                    <table border="0" cellpadding="0" cellspacing="0" width="500">
                        <tr style="height:15px">
                            <td colspan="4"></td>
                        </tr>
                        <tr style="height: 24px">
                            <td style="padding-right: 10px; width: 130px; text-align: right">
                                เลขที่สั่งซื้อล่วงหน้า:</td>
                            <td style="width: 150px;">
                                <asp:TextBox ID="txtCodeFrom" CssClass="zTextbox" Width="100" runat="server"></asp:TextBox>
                                </td>
                                <td>ถึง</td>
                                <td><asp:TextBox ID="txtCodeTo" CssClass="zTextbox" Width="100" runat="server"></asp:TextBox></td>
                        </tr>
                        <tr style="height: 24px">
                            <td style="padding-right: 10px; width: 130px; text-align: right">
                                วันที่สั่งซื้อล่วงหน้า:</td>
                            <td style="width: 150px;">
                                <uc3:CalendarControl ID="ctlDateFrom" runat="server" /> 
                                </td>
                                <td>ถึง</td>
                                <td><uc3:CalendarControl ID="ctlDateTo" runat="server" /> </td>
                        </tr>
                        <tr style="height: 24px">
                            <td style="padding-right: 10px; width: 130px; text-align: right">
                                วันที่ใช้:</td>
                            <td style="width: 150px;">
                                <uc3:CalendarControl ID="ctlUsedateFrom" runat="server" /> 
                                </td>
                                <td>ถึง</td>
                                <td><uc3:CalendarControl ID="ctlUsedateTo" runat="server" />  </td>
                        </tr>
                        <tr style="height:24px">
                            <td style="width:130px; padding-right:10px; text-align:right">
                                หมวดอาหาร:</td>
                            <td colspan="3">
                                <asp:DropDownList ID="cmbMaterialClass" runat="server" CssClass="zComboBox" Width="300px"></asp:DropDownList> 
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
                <asp:GridView ID="gvMain" runat="server" AllowSorting="True" AutoGenerateColumns="False" CssClass="t_tablestyle" AllowPaging="True" PageSize="20" OnRowDataBound="gvMain_RowDataBound" OnSorting="gvMain_Sorting">
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
                        <asp:BoundField DataField="CODE" HeaderText="เลขที่" SortExpression="CODE">
                            <ItemStyle Width="100px" HorizontalAlign="Center"/>
                            <HeaderStyle HorizontalAlign="Center" />
                        </asp:BoundField>
                        <asp:BoundField HtmlEncode="False" DataFormatString="{0:dd/MM/yyyy}" DataField="USEDATE" HeaderText="วันที่ใช้" SortExpression="USEDATE">
                            <ItemStyle Width="100px" HorizontalAlign="Center"/>
                            <HeaderStyle HorizontalAlign="Center" />
                        </asp:BoundField>
                        <asp:BoundField DataField="CLASSNAME" HeaderText="หมวดอาหาร" SortExpression="CLASSNAME">
                        </asp:BoundField>
                        <asp:BoundField DataField="MATERIALCLASS" HeaderText="MATERIALCLASS">
                            <ControlStyle CssClass="zHidden" />
                            <FooterStyle CssClass="zHidden" />
                            <HeaderStyle CssClass="zHidden" />
                            <ItemStyle CssClass="zHidden" />
                        </asp:BoundField>
                        <asp:BoundField DataField="SUPPLIER" HeaderText="SUPPLIER">
                            <ControlStyle CssClass="zHidden" />
                            <FooterStyle CssClass="zHidden" />
                            <HeaderStyle CssClass="zHidden" />
                            <ItemStyle CssClass="zHidden" />
                        </asp:BoundField>
                        <asp:BoundField DataField="SUPPLIERCODE" HeaderText="SUPPLIERCODE">
                            <ControlStyle CssClass="zHidden" />
                            <FooterStyle CssClass="zHidden" />
                            <HeaderStyle CssClass="zHidden" />
                            <ItemStyle CssClass="zHidden" />
                        </asp:BoundField>
                        <asp:BoundField DataField="SUPPLIERNAME" HeaderText="SUPPLIERNAME">
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