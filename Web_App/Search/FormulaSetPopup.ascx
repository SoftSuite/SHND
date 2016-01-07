<%@ Control Language="C#" AutoEventWireup="true" CodeFile="FormulaSetPopup.ascx.cs" Inherits="Search_FormulaSetPopup" %>
<%@ Register Src="../Templates/PageControl.ascx" TagName="PageControl" TagPrefix="uc2" %>
<%@ Register Src="../Templates/ToolBarItemCtl.ascx" TagName="ToolBarItemCtl" TagPrefix="uc1" %>
<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="cc1" %>
<cc1:ModalPopupExtender ID="popupFormulaSet"  runat="server" PopupControlID="pnlFormulaSet" BackgroundCssClass="modalBackground" DropShadow="true" TargetControlID="btntest" RepositionMode="RepositionOnWindowResizeAndScroll"></cc1:ModalPopupExtender>
<asp:Panel ID="pnlFormulaSet" runat="server" CssClass="modalPopupSearch" style="display:none">
    <table border="0" cellspacing="0" cellpadding="0" width="780px">
        <tr>
            <td class="headtext">ข้อมูลสูตรอาหารสำรับ
            </td>
        </tr>
        <tr>
            <td><uc1:ToolBarItemCtl ID="tbBack" runat="server" ToobarTitle="กลับหน้ารายการ" ToolbarImage="../../Images/icn_back.png" OnClick="tbBackClick" />
                <asp:TextBox ID="txhSortField" runat="server" Visible="False" Width="15px"></asp:TextBox><asp:TextBox
                    ID="txhSortDir" runat="server" Visible="False" Width="15px"></asp:TextBox>
                <asp:TextBox ID="txtExistKeyList" runat="server" Visible="False" Width="15px"></asp:TextBox>
                <asp:TextBox ID="txtRefFormulaSetID" runat="server" Visible="False" Width="15px"></asp:TextBox></td>
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
                    <table cellspacing="0" cellpadding="0" border="0" width="600">
                        <tr style="height:15px">
                            <td colspan="3">&nbsp;</td>
                        </tr>
                        <tr style="height: 24px">
                            <td style="padding-right: 10px; width: 130px; text-align: right">
                                ประเทภอาหาร :</td>
                            <td style="width: 200px">
                                <asp:DropDownList ID="cmbSearchFoodType" runat="server" CssClass="zComboBox" Width="206px" >
                                </asp:DropDownList></td>
                            <td>
                                <asp:CheckBox ID="chkSearchIsElement" runat="server" Visible="False" /></td>
                        </tr>
                        <tr style="height: 24px">
                            <td style="padding-right: 10px; width: 130px; text-align: right">
                                ชนิดอาหาร :</td>
                            <td style="width: 200px">
                                <asp:DropDownList ID="cmbSearchFoodCategory" runat="server" CssClass="zComboBox" Width="206px" >
                                </asp:DropDownList></td>
                            <td>
                            </td>
                        </tr>
                        <tr style="height:24px">
                            <td style="width:130px; text-align: right; padding-right:10px">
                                ชื่อสูตรอาหาร :</td>
                            <td style="width:200px;">
                                <asp:TextBox ID="txtSearchName" runat="server" CssClass="zTextbox" MaxLength="100"
                                    Width="200px"></asp:TextBox></td>
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
            <td class="toolbarplace">
                <uc1:ToolBarItemCtl ID="tbAdd" runat="server" ToobarTitle="เพิ่มรายการ" ToolbarImage="../../Images/icn_add.png" OnClick="tbAddClick" />
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
                        <asp:BoundField DataField="FORMULANAME" HeaderText="ชื่อสูตรอาหาร" SortExpression="FORMULANAME">
                        </asp:BoundField>
                        <asp:BoundField DataField="FOODTYPENAME" HeaderText="ประเทภอาหาร" SortExpression="FOODTYPENAME">
                            <HeaderStyle HorizontalAlign="Center" Width="100px" />
                            <ItemStyle Width="100px" />
                        </asp:BoundField>
                        <asp:BoundField DataField="FOODCATEGORYNAME" HeaderText="ชนิดอาหาร" SortExpression="FOODCATEGORYNAME">
                            <HeaderStyle HorizontalAlign="Center" Width="100px" />
                            <ItemStyle Width="100px" />
                        </asp:BoundField>
                        <asp:BoundField DataField="PORTION" HeaderText="PORTION">
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