<%@ Page Language="C#" MasterPageFile="~/Templates/Page1.master" AutoEventWireup="true" CodeFile="PrepareReturn.aspx.cs" Inherits="App_Prepare_Transaction_PrepareReturn" Title="SHND : Transaction - Prepare Return" %>

<%@ Register Src="../../Search/MaterialPrepareReturnPopup.ascx" TagName="MaterialPrepareReturnPopup"
    TagPrefix="uc4" %>

<%@ Register Src="../../Templates/PageControl.ascx" TagName="PageControl" TagPrefix="uc3" %>
<%@ Register Src="../../Templates/CalendarControl.ascx" TagName="CalendarControl" TagPrefix="uc2" %>
<%@ Register Src="../../Templates/ToolBarItemCtl.ascx" TagName="ToolBarItemCtl" TagPrefix="uc1" %>
<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="cc1" %>

<asp:Content ID="Content3" ContentPlaceHolderID="MainContent" Runat="Server">
    <table width="100%" border="0" cellpadding="0" cellspacing="0">
        <tr>
            <td class="headtext">
                ข้อมูลการแจ้งคืนวัตถุดิบหลังเตรียม</td>
        </tr>

    </table>
    <table width="100%" border="0" cellpadding="0" cellspacing="0">
        <tr>
            <td>
                <uc1:ToolBarItemCtl ID="tbAdd" runat="server" ToobarTitle="เพิ่มข้อมูล" ToolbarImage="../../Images/icn_add.png" />
                <uc1:ToolBarItemCtl ID="tbDelete" runat="server" ToobarTitle="ลบข้อมูลที่เลือก" ToolbarImage="../../Images/icn_delete.png" OnClick="tbDeleteClick" ClientClick="return confirm('ต้องการลบรายการที่เลือก ใช่หรือไม่?')" />
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
            <td colspan="5">
                <asp:Label ID="lblStatusMain" runat="server" ForeColor="red"></asp:Label>
            </td>
        </tr>
        <tr>
            <td style="width: 18px; height:25px;">
                &nbsp;
            </td>
            <td style="width: 100px">เลขที่แจ้งคืน</td>
            <td>
                <asp:TextBox ID="txtCodeFrom" runat="server" CssClass="zTextbox" Width="126px"></asp:TextBox>
            </td>
            <td>
                &nbsp;ถึง&nbsp;<asp:TextBox ID="txtCodeTo" runat="server" CssClass="zTextbox" Width="126px"></asp:TextBox>
            </td>
            <td style="width: 180px">&nbsp;
            </td>
        </tr>
        <tr>
            <td style="width: 18px; height:25px;">
                &nbsp;
            </td>
            <td style="width: 100px">วันที่แจ้งคืน</td>
            <td>
                <uc2:CalendarControl ID="cldInformDateFrom" runat="server" />
            </td>
            <td>
                &nbsp;ถึง&nbsp;
                <uc2:CalendarControl ID="cldInformDateTo" runat="server" />
            </td>
            <td style="width: 180px">&nbsp;
            </td>
        </tr>
        <tr>
            <td style="width: 18px; height:25px;">
                &nbsp;
            </td>
            <td >หน่วยงานที่ส่งคืน</td>
            <td colspan="2">
                <asp:DropDownList ID="cmbDivisionSearch" runat="server" Width="291px" CssClass="zComboBox"></asp:DropDownList>
            </td>
            <td style="width: 180px">&nbsp;
            </td>
        </tr>
        <tr>
            <td style="width: 18px; height:25px;">
                &nbsp;
            </td>
            <td >ประเภทการเบิก</td>
            <td colspan="2">
                <asp:DropDownList ID="cmbDoctypeSearch" runat="server" Width="291px" CssClass="zComboBox"></asp:DropDownList>
            </td>
            <td style="width: 180px">&nbsp;
            </td>
        </tr>
        <tr>
            <td style="width: 18px; height:25px;">
                &nbsp;
            </td>
            <td >หมวดอาหาร</td>
            <td colspan="2">
                <asp:DropDownList ID="cmbMaterialClassSearch" runat="server" Width="291px" CssClass="zComboBox"></asp:DropDownList>
            </td>
            <td style="width: 180px">&nbsp;
            </td>
        </tr>
        <tr>
            <td style="width: 18px; height:25px;">
                &nbsp;
            </td>
            <td style="width: 100px">สถานะ</td>
            <td>
                <asp:DropDownList ID="cmbStatusFrom" runat="server" Width="136px" CssClass="zComboBox">
                    <asp:ListItem Value="WA">กำลังดำเนินการ</asp:ListItem>
                    <asp:ListItem Value="FN">ยืนยัน</asp:ListItem>
                </asp:DropDownList>
            </td>
            <td>
                &nbsp;ถึง&nbsp;<asp:DropDownList ID="cmbStatusTo" runat="server" Width="135px" CssClass="zComboBox">
                                    <asp:ListItem Value="WA">กำลังดำเนินการ</asp:ListItem>
                                    <asp:ListItem Value="FN">ยืนยัน</asp:ListItem>
                            </asp:DropDownList>
            </td>
            <td style="width: 180px">
                &nbsp;<asp:ImageButton ID="imbSearch" runat="server" ImageUrl="~/Images/icn_find.png" OnClick="imbSearch_Click" />
            </td>
        </tr>
        <tr style="height:10px;">
        
        </tr>
    </table><br />
    <uc3:PageControl ID="pcTop" runat="server"  OnPageChange="PageChange" />
    <asp:GridView ID="gvMain" runat="server" AllowSorting="True" AutoGenerateColumns="False" CssClass="t_tablestyle" OnSorting="gvMain_Sorting"  AllowPaging="True" PageSize="20" OnRowDataBound="gvMain_RowDataBound">
        <Columns>
            <asp:BoundField DataField="LOID" HeaderText="LOID">
                <ControlStyle CssClass="zHidden" />
                <FooterStyle CssClass="zHidden" />
                <HeaderStyle CssClass="zHidden" />
                <ItemStyle CssClass="zHidden" />
            </asp:BoundField>
            <asp:TemplateField>
                <HeaderTemplate>
                    <input type="checkbox" name="chkMain" id="chkMain" onclick="chkAllBox(this, 'ctl00_MainContent_gvMain_ctl', '_chkSelect')" />
                </HeaderTemplate>
                <ItemTemplate>
                    <asp:CheckBox ID="chkSelect" runat="server" />
                </ItemTemplate>
                <HeaderStyle HorizontalAlign="Center" Width="30px" />
                <ItemStyle HorizontalAlign="Center" Width="30px" />
            </asp:TemplateField>
            <asp:TemplateField HeaderText="เลขที่แจ้งคืน" SortExpression="CODE" HeaderStyle-HorizontalAlign="Center" ItemStyle-HorizontalAlign="Center">
                <ItemTemplate>
                    <asp:LinkButton ID="lnkCode" runat="server" Text='<%# Bind("CODE") %>' OnClick="lnkName_Click"></asp:LinkButton>
                </ItemTemplate>
                <ItemStyle HorizontalAlign = "center" Width="100px" />
                <HeaderStyle Width="100px" />
            </asp:TemplateField>
            <asp:BoundField DataField="DIVISIONNAME" HeaderText="หน่วยงานที่ส่งคืน" SortExpression="DIVISIONNAME">
                <ItemStyle Width="150px" />
                <HeaderStyle Width="150px" />
            </asp:BoundField>
            <asp:BoundField DataField="INFORMDATE" HeaderText="วันที่แจ้งคืน" SortExpression="INFORMDATE" HtmlEncode="false" DataFormatString="{0:dd/MM/yyyy}">
                <HeaderStyle HorizontalAlign="Center" Width="100px" />
                <ItemStyle Width="100px" HorizontalAlign = "center"/>
            </asp:BoundField>
            <asp:BoundField DataField="DOCNAME" HeaderText="ประเภทการเบิก" SortExpression="DOCNAME">
                <HeaderStyle HorizontalAlign="Center" Width="120px" />
                <ItemStyle Width="120px" HorizontalAlign = "center"/>
            </asp:BoundField>
            <asp:BoundField DataField="CLASSNAME" HeaderText="หมวดอาหาร" SortExpression="CLASSNAME">
                <HeaderStyle HorizontalAlign="Center" Width="140px" />
                <ItemStyle Width="140px" HorizontalAlign = "center"/>
            </asp:BoundField>
            <asp:BoundField DataField="STATUSNAME" HeaderText="สถานะ" SortExpression="STATUSNAME">
                <HeaderStyle HorizontalAlign="Center" Width="90px" />
                <ItemStyle HorizontalAlign="Center" Width="90px" />
            </asp:BoundField>
            <asp:BoundField DataField="STATUS" HeaderText="STATUS">
                <ControlStyle CssClass="zHidden" />
                <FooterStyle CssClass="zHidden" />
                <HeaderStyle CssClass="zHidden" />
                <ItemStyle CssClass="zHidden" />
            </asp:BoundField>
        </Columns>
        <HeaderStyle CssClass="t_headtext" />
        <AlternatingRowStyle CssClass="t_alt_bg" />
        <PagerSettings Visible="False" />
    </asp:GridView><uc3:PageControl ID="pcBot" runat="server"  OnPageChange="PageChange" />
    <asp:TextBox ID="txhSortField" runat="server" Visible="False" Width="15px"></asp:TextBox>
    <asp:TextBox ID="txhSortDir" runat="server" Visible="False" Width="15px"></asp:TextBox>
    <asp:TextBox ID="txhID" runat="server" Visible="False" Width="15px"></asp:TextBox>&nbsp;
    
    <cc1:ModalPopupExtender ID="zPop" runat="server" TargetControlID="tbAdd$lb" PopupControlID="Panel1" BackgroundCssClass="modalBackground" DropShadow="true"></cc1:ModalPopupExtender>
    <asp:Panel ID="Panel1" runat="server" CssClass="modalPopup" style="display:none" Width="935px">
        <table cellspacing="0" cellpadding="0" border="0" width="100%">
            <tr>
                <td>
                    <uc1:ToolBarItemCtl ID="tbSave" runat="server" ToobarTitle="บันทึก" ToolbarImage="../../Images/save2.png" OnClick="tbSaveClick" />
                    <uc1:ToolBarItemCtl ID="tbCancel" runat="server" ToobarTitle="ยกเลิกการแก้ไข" ToolbarImage="../../Images/cancel.png" OnClick="tbCancelClick"  />
                    <uc1:ToolBarItemCtl ID="tbBack" runat="server" ToobarTitle="กลับหน้ารายการ" ToolbarImage="../../Images/icn_back.png" OnClick="tbBackClick" />
                    <uc1:ToolBarItemCtl ID="tbConfirm" runat="server" ToobarTitle="ยืนยัน" ToolbarImage="../../Images/icn_approve.png" ClientClick="return confirm('ต้องการยืนยันการแจ้งคืนหลังเตรียม ใช่หรือไม่?')" OnClick="tbConfirmClick" />
                    <uc1:ToolBarItemCtl ID="tbPrint" runat="server" ToobarTitle="พิมพ์" ToolbarImage="../../Images/icn_print.png" />
                </td>
            </tr>
            <tr style="height:10px;">
                
            </tr>
        </table>
        <table cellspacing="0" cellpadding="10" border="0" style="border-right: thin solid; border-top: thin solid; border-left: thin solid; border-bottom: thin solid" >
            <tr>
                <td>
                    <table cellspacing="0" cellpadding="1" border="0">
                        <tr>
                            <td colspan="6">
                                <asp:Label ID="lblStatus" runat="server" ForeColor="red"></asp:Label>
                            </td>
                        </tr>
                        <tr>
                            <td align="right" style="width: 90px; height: 25px;">
                                เลขที่แจ้งคืน&nbsp;
                            </td>
                            <td>
                                <asp:TextBox ID="txtCode" runat="server" CssClass="zTextbox-View" ReadOnly="true" Width="183px"></asp:TextBox>
                            </td>
                            <td align="right" style="width: 90px">
                                วันที่แจ้งคืน&nbsp;
                            </td>
                            <td>
                                <asp:TextBox ID="txtInformDate" runat="server" CssClass="zTextbox-View" ReadOnly="true" Width="183px"></asp:TextBox>
                            </td>
                            <td align="right" style="width: 90px">
                                สถานะ&nbsp;
                            </td>
                            <td>
                                <asp:TextBox ID="txtStatus" runat="server" CssClass="zTextbox-View" ReadOnly="true" Width="183px"></asp:TextBox>
                            </td>
                        </tr>
                        <tr>
                            <td align="right" style="width: 90px; height: 25px;">
                                หน่วยที่่ส่งคืน&nbsp;
                            </td>
                            <td>
                                <asp:DropDownList ID="cmbDivision" runat="server" CssClass="zComboBox" Width="190px"></asp:DropDownList>
                                <asp:Label ID="lblDivision" runat="server" ForeColor="red" Text="*"></asp:Label>
                            </td>
                            <td align="right" style="width: 90px">
                                หมวดอาหาร&nbsp;
                            </td>
                            <td>
                                <asp:DropDownList ID="cmbMaterialClass" runat="server" CssClass="zComboBox" Width="190px"></asp:DropDownList>
                                <asp:Label ID="Label1" runat="server" ForeColor="red" Text="*"></asp:Label>
                            </td>
                            <td align="right" style="width: 90px">
                                &nbsp;
                            </td>
                            <td>
                                &nbsp;
                            </td>
                        </tr>
                        <tr>
                            <td align="right" style="width: 90px; height: 25px;">
                                ประเภทการเบิก&nbsp;
                            </td>
                            <td>
                                <asp:DropDownList ID="cmbDoctype" runat="server" CssClass="zComboBox" Width="190px"></asp:DropDownList>
                                <asp:Label ID="Label2" runat="server" ForeColor="red" Text="*"></asp:Label>
                            </td>
                            <td align="right" style="width: 90px">
                                &nbsp;
                            </td>
                            <td>
                                &nbsp;
                            </td>
                            <td align="right" style="width: 90px">
                                &nbsp;
                            </td>
                            <td>
                                &nbsp;
                            </td>
                        </tr>
                        <tr style="height:5px">
                        </tr>
                    </table>
                </td>
            </tr>
        </table>
        <table cellspacing="0" cellpadding="0" border="0" width="100%">
            <tr style="height:10px">
            </tr>
            <tr>
                <td>
                    <uc1:ToolBarItemCtl ID="tbAddItem" runat="server" ToobarTitle="เพิ่มรายการ" ToolbarImage="../../Images/icn_add.png" OnClick="tbAddItemClick"/>
                    <uc1:ToolBarItemCtl ID="tbDeleteItem" runat="server" ToobarTitle="ลบรายการ" ToolbarImage="../../Images/icn_delete.png" ClientClick="return confirm('ต้องการลบรายการที่เลือก ใช่หรือไม่?')" OnClick="tbDeleteItemClick" />
                </td>
            </tr>
            <tr style="height:10px;">  
            </tr>
        </table>
        <asp:GridView ID="gvMaterialItem" runat="server" AutoGenerateColumns="False" CssClass="t_tablestyle"  AllowPaging="True" PageSize="20" OnRowDataBound="gvMaterialItem_RowDataBound">
        <Columns>
            <asp:BoundField DataField="PILOID" HeaderText="PILOID">
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
            <asp:TemplateField HeaderText="ลำดับ" HeaderStyle-HorizontalAlign="Center" ItemStyle-HorizontalAlign="Center">
                <ItemTemplate>
                    <%# Container.DataItemIndex + 1 %>
                </ItemTemplate>
                <ItemStyle HorizontalAlign = "center" Width="50px" />
                <HeaderStyle Width="50px" />
            </asp:TemplateField>
            <asp:BoundField DataField="MATERIALCODE" HeaderText="รหัส" SortExpression="MATERIALCODE">
                <ItemStyle Width="90px" HorizontalAlign="Center"/>
                <HeaderStyle Width="90px" HorizontalAlign="Center"/>
            </asp:BoundField>
            <asp:BoundField DataField="MATERIALNAME" HeaderText="รายการ" SortExpression="MATERIALNAME">
                <HeaderStyle HorizontalAlign="Center" Width="220px" />
                <ItemStyle Width="220px" HorizontalAlign="Left"/>
            </asp:BoundField>
            <asp:BoundField DataField="UNITNAME" HeaderText="หน่วยนับ" SortExpression="UNITNAME">
                <HeaderStyle HorizontalAlign="Center" Width="90px" />
                <ItemStyle Width="90px" HorizontalAlign = "center"/>
            </asp:BoundField>
            <asp:TemplateField HeaderText="จำนวนเบิกรวม" HeaderStyle-HorizontalAlign="Center" ItemStyle-HorizontalAlign="Center">
                <ItemTemplate>
                    <asp:TextBox ID="txtSTOCKOUTQTY" runat="server" Text='<%# Bind("STOCKOUTQTY") %>' CssClass="zTextboxR-View" ReadOnly="true" Width="52px"></asp:TextBox>
                </ItemTemplate>
                <ItemStyle HorizontalAlign = "center" Width="60px" />
                <HeaderStyle Width="60px" />
            </asp:TemplateField>
            <asp:TemplateField HeaderText="จำนวนคงเหลือ" HeaderStyle-HorizontalAlign="Center" ItemStyle-HorizontalAlign="Center">
                <ItemTemplate>
                    <asp:TextBox ID="txtQTY" runat="server" Text='<%# Bind("QTY") %>' CssClass="zTextboxR" Width="42px" OnTextChanged="UpdateTmp" ToolTip='<%# Container.DataItemIndex %>'></asp:TextBox>
                    <asp:Label ID="lblQTY" runat="server" Text="*" ForeColor="red"></asp:Label>
                </ItemTemplate>
                <ItemStyle HorizontalAlign = "center" Width="60px" />
                <HeaderStyle Width="60px" />
            </asp:TemplateField>
            <asp:BoundField DataField="UNITLOID" HeaderText="UNITLOID">
                <ControlStyle CssClass="zHidden" />
                <FooterStyle CssClass="zHidden" />
                <HeaderStyle CssClass="zHidden" />
                <ItemStyle CssClass="zHidden" />
            </asp:BoundField>
            <asp:BoundField DataField="MMLOID" HeaderText="MMLOID" ReadOnly="True">
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
    </asp:Panel>
    <uc4:MaterialPrepareReturnPopup ID="ctlMaterialPrepareReturnPopup" runat="server" OnSelectedIndexChanged="ctlMaterialPrepareReturnPopup_SelectedIndexChanged" OnCancel="ctlMaterialPrepareReturnPopup_Cancel"/>
</asp:Content>

