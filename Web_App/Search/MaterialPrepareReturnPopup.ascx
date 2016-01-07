<%@ Control Language="C#" AutoEventWireup="true" CodeFile="MaterialPrepareReturnPopup.ascx.cs" Inherits="Search_MaterialPrepareReturnPopup" %>
<%@ Register Src="../Templates/PageControl.ascx" TagName="PageControl" TagPrefix="uc2" %>
<%@ Register Src="../Templates/ToolBarItemCtl.ascx" TagName="ToolBarItemCtl" TagPrefix="uc1" %>
<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="cc1" %>
<cc1:ModalPopupExtender ID="popupMaterialMaster"  runat="server" PopupControlID="pnlMaterialMaster" BackgroundCssClass="modalBackground" DropShadow="true" TargetControlID="btntest"></cc1:ModalPopupExtender>
<asp:Panel ID="pnlMaterialMaster" runat="server" CssClass="modalPopupSearch" style="display:none" Width="800px">
    <table width="100%" border="0" cellpadding="0" cellspacing="0">
        <tr>
            <td class="headtext">
                ข้อมูลวัสดุอาหาร</td>
        </tr>

    </table>
    <table width="550px" border="0" cellpadding="0" cellspacing="0">
        <tr>
            <td>
                <uc1:ToolBarItemCtl ID="tbBack" runat="server" ToobarTitle="กลับหน้ารายการ" ToolbarImage="../../Images/icn_back.png" OnClick="tbBackClick" />
                <asp:TextBox ID="txtExistKeyList" runat="server" Visible="false" Width="15px"></asp:TextBox>
            </td>
        </tr>
    </table>
    <table width="100%" border="0" cellpadding="0" cellspacing="0">
        <tr>
            <td class="t_headtext">
                &nbsp;ค้นหา
            </td>
        </tr>
    </table>
    <table border="0" cellpadding="0" cellspacing="0" style="border-right: thin solid; border-top: thin solid; border-left: thin solid; border-bottom: thin solid">
        <tr style="height:10px;">
        
        </tr>
        <tr>
            <td style="width: 40px; height:25px;">
                &nbsp;
            </td>
            <td style="width: 100px">ชื่อวัสดุ</td>
            <td>
                <asp:TextBox ID="txtName" runat="server" CssClass="zTextbox" Width="236px"></asp:TextBox>
            </td>
            <td style="width: 90px">
                &nbsp;
            </td>
        </tr>
        <tr>
            <td style="width: 40px; height:25px;">
                &nbsp;
            </td>
            <td style="width: 100px">ประเภทวัสดุ</td>
            <td>
                <asp:DropDownList ID="cmbMaterialGroup" runat="server" CssClass="zComboBox" Width="240px"></asp:DropDownList>
            </td>
            <td style="width: 90px">
                &nbsp;
            </td>
        </tr>
        <tr>
            <td style="width: 40px; height:25px;">
                &nbsp;
            </td>
            <td style="width: 100px">หมวดวัสดุ</td>
            <td>
                <asp:DropDownList ID="cmbMaterialClass" runat="server" CssClass="zComboBox" Width="240px"></asp:DropDownList>
            </td>
            <td style="width: 90px">
                &nbsp;<asp:ImageButton ID="imbSearch" runat="server" ImageUrl="~/Images/icn_find.png" OnClick="imbSearch_Click"/>
            </td>
        </tr>
        <tr style="height:15px;">
        </tr>
    </table>
    <uc1:ToolBarItemCtl ID="tbAdd" runat="server" ToobarTitle="เพิ่มรายการ" ToolbarImage="../../Images/icn_add.png" OnClick="tbAddClick" />
    <uc2:PageControl ID="pcTop" runat="server" OnPageChange="PageChange"/>
    <asp:GridView ID="gvMain" runat="server"  AutoGenerateColumns="False" CssClass="t_tablestyle"  AllowPaging="True" PageSize="20" OnRowDataBound="gvMain_RowDataBound" Width="100%">
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
            <asp:TemplateField HeaderText="ลำดับ">
                <ItemTemplate>
                    <%# Container.DataItemIndex + 1 %>
                </ItemTemplate>
                <ItemStyle HorizontalAlign = "Center" Width="60px" />
                <HeaderStyle Width="60px" HorizontalAlign="Center" />
            </asp:TemplateField>
            <asp:BoundField DataField="MATERIALCODE" HeaderText="รหัส" SortExpression="MATERIALCODE">
                <ItemStyle Width="100px" HorizontalAlign = "Center"/>
                <HeaderStyle Width="100px" />
            </asp:BoundField>
            <asp:BoundField DataField="MATERIALNAME" HeaderText="รายการ" SortExpression="MATERIALNAME">
            </asp:BoundField>
            <asp:BoundField DataField="THNAME" HeaderText="หน่วยนับ" SortExpression="UNITNAME">
                <HeaderStyle HorizontalAlign="Center" Width="80px" />
                <ItemStyle Width="80px" />
            </asp:BoundField>
            <asp:BoundField DataField="ULOID" HeaderText="ULOID">
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
</asp:Panel>
<asp:Button ID="btntest" runat="server" Text="test" CssClass="zHidden" />