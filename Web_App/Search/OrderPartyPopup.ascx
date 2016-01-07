<%@ Control Language="C#" AutoEventWireup="true" CodeFile="OrderPartyPopup.ascx.cs" Inherits="Search_OrderPartyPopup" %>
<%@ Register Src="../Templates/PageControl.ascx" TagName="PageControl" TagPrefix="uc2" %>
<%@ Register Src="../Templates/ToolBarItemCtl.ascx" TagName="ToolBarItemCtl" TagPrefix="uc1" %>
<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="cc1" %>
<cc1:ModalPopupExtender ID="popupFormulaSet"  runat="server" PopupControlID="pnlFormulaSet" BackgroundCssClass="modalBackground" DropShadow="true" TargetControlID="btntest" RepositionMode="RepositionOnWindowResizeAndScroll"></cc1:ModalPopupExtender>
<asp:Panel ID="pnlFormulaSet" runat="server" CssClass="modalPopupSearch" style="display:none">
    <table cellSpacing="0" cellPadding="0" width="780px" border="0">
        <tr>
            <td class="headtext">รายการอาหารจัดเลี้ยง</td>
        </tr>
        <tr>
            <td>
                <uc1:ToolBarItemCtl id="tbBack" onclick="tbBackClick" runat="server" ToolbarImage="../../Images/icn_back.png" ToobarTitle="กลับหน้ารายการ"></uc1:ToolBarItemCtl>
                <asp:TextBox id="txhSortField" runat="server" Width="15px" Visible="False"></asp:TextBox>
                <asp:TextBox id="txhSortDir" runat="server" Width="15px" Visible="False"></asp:TextBox>
                <asp:TextBox id="txtExistKeyList" runat="server" Width="15px" Visible="False"></asp:TextBox>
                <asp:TextBox id="txtPartyDate" runat="server" Width="15px" Visible="False"></asp:TextBox>
            </td>
        </tr>
        <tr>
            <td>
                <hr style ="size:1px"/>
            </td>
        </tr>
        <tr>
            <td>
                <fieldset style="padding-right: 15px; padding-left: 15px; padding-bottom: 15px; padding-top: 15px">
                    <legend>ค้นหา </legend>
                    <table cellSpacing="0" cellPadding="0" width="500" border="0">
                        <tr style="height: 15px">
                            <td colSpan="3">&nbsp;</td>
                        </tr>
                        <tr style="display:none">
                            <td style="padding-right: 10px; WIDTH: 130px; text-align: right; height: 24px;">ประเทภอาหาร :</td>
                            <td style="width: 210px; height: 24px;">
                                <asp:DropDownList id="cmbSearchFoodType" runat="server" CssClass="zComboBox" Width="206px"></asp:DropDownList>
                            </td>
                            <td style="height: 24px"></td>
                        </tr>
                        <tr style="height: 24px">
                            <td style="padding-right: 10px; width: 130px; text-align: right; height: 24px;">ประเภทการปรุง&nbsp;:</td>
                            <td style="width: 210px; height: 24px;">
                                <asp:DropDownList id="cmbSearchFoodCookType" runat="server" CssClass="zComboBox" Width="206px"></asp:DropDownList>
                            </td>
                            <td style="height: 24px"></td>
                        </tr>
                        <tr style="height: 24px">
                            <td style="PADDING-RIGHT: 10px; WIDTH: 130px; TEXT-ALIGN: right; height: 24px;">ชื่ออาหาร :</td>
                            <td style="width: 210px; height: 24px;">
                                <asp:TextBox id="txtSearchName" runat="server" CssClass="zTextbox" Width="200px" MaxLength="100"></asp:TextBox>
                            </td>
                            <td style="height: 24px">
                                &nbsp;&nbsp;<asp:ImageButton id="imbSearch" onclick="imbSearch_Click" runat="server" ImageUrl="~/Images/icn_find.png" ImageAlign="AbsMiddle"></asp:ImageButton>
                                &nbsp;<asp:ImageButton id="imbReset" onclick="imbReset_Click" runat="server" ImageUrl="~/Images/icn_back.png" ImageAlign="AbsMiddle" ToolTip="แสดงทั้งหมด"></asp:ImageButton>
                            </td></tr>
                        </table>
                    </fieldset>
                </td>
            </tr>
            <tr>
                <td class="toolbarplace">
                    <uc1:ToolBarItemCtl id="tbAdd" onclick="tbAddClick" runat="server" ToolbarImage="../../Images/icn_add.png" ToobarTitle="เพิ่มรายการ"></uc1:ToolBarItemCtl>
                </td>
            </tr>
            <tr>
                <td>
                    <uc2:PageControl id="pcTop" runat="server" OnPageChange="PageChange"></uc2:PageControl>
                    <asp:GridView id="gvMain" runat="server" CssClass="t_tablestyle" OnSorting="gvMain_Sorting" OnRowDataBound="gvMain_RowDataBound" PageSize="20" AllowPaging="True" AutoGenerateColumns="False" AllowSorting="True" Width="100%">
                    <Columns>
                        <asp:BoundField DataField="LOID" HeaderText="LOID">
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
                        <asp:BoundField DataField="FOODTYPENAME" HeaderText="FOODTYPENAME">
                            <ControlStyle CssClass="zHidden" />
                            <FooterStyle CssClass="zHidden" />
                            <HeaderStyle CssClass="zHidden" />
                            <ItemStyle CssClass="zHidden" />
                        </asp:BoundField>
                        <asp:BoundField DataField="FOODCOOKTYPENAME" HeaderText="ประเภทการปรุง" SortExpression="FOODCOOKTYPENAME">
                            <HeaderStyle HorizontalAlign="Center" Width="100px" />
                            <ItemStyle Width="100px" />
                        </asp:BoundField>
                        <asp:BoundField DataField="FORMULASETNAME" HeaderText="ชื่ออาหาร" SortExpression="FORMULASETNAME">
                            <HeaderStyle HorizontalAlign="Center" />
                        </asp:BoundField>
                    </Columns>
                    <HeaderStyle CssClass="t_headtext" />
                    <AlternatingRowStyle CssClass="t_alt_bg" />
                    <PagerSettings Visible="False" />
                </asp:GridView>
                <uc2:PageControl id="pcBot" runat="server" OnPageChange="PageChange"></uc2:PageControl>
            </td>
        </tr>
    </table>
</asp:Panel>
<asp:Button ID="btntest" runat="server" Text="test" CssClass="zHidden" />