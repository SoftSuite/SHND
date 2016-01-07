<%@ Control Language="C#" AutoEventWireup="true" CodeFile="MenuBoxControlMenu.ascx.cs" Inherits="App_Formula_Transaction_Controls_MenuBoxControlMenu" %>
<%@ Register Src="../../../Templates/ToolBarItemCtl.ascx" TagName="ToolBarItemCtl" TagPrefix="uc1" %>
<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="cc1" %>

<asp:Button ID="btntest" runat="server" Text="test" CssClass="zHidden" /> 
<asp:UpdatePanel ID="UpdatePanel1" runat="server">
    <ContentTemplate>
        <table border="0" cellpadding="0" cellspacing="0" width="570px">
            <tr>
                <td style="padding-right: 4px; padding-left: 4px; padding-bottom: 4px; width: 200px;
                    padding-top: 4px; background-color: #f8f8ff; text-align: right">
                    <asp:ListBox ID="lstSelect" runat="server" CssClass="zTextbox" Height="80px" Width="200px">
                    </asp:ListBox>
                    <asp:Button ID="btnShowSelect" runat="server" CssClass="zButton" Text="สูตร" Width="50px" OnClick="btnShowSelect_Click" />
                </td>
                <td align="center" style="width: 174px" valign="top">
                    <br />
                    <br />
                    <asp:Button ID="btnAdd" runat="server" CssClass="zButton" Text="<" Width="30px" />
                    <br />
                    <asp:Button ID="btnRemove" runat="server" CssClass="zButton" Text=">" Width="30px" />
                </td>
                <td style="padding-right: 4px; padding-left: 4px; padding-bottom: 4px; width: 200px;
                    padding-top: 4px; background-color: #f8f8ff; text-align: right">
                    <asp:ListBox ID="lstAll" runat="server" CssClass="zTextbox" Height="80px" Width="200px"></asp:ListBox>
                    <asp:Label ID="lblQty" runat="server" Text="จำนวน :"></asp:Label>
                    <asp:TextBox ID="txtQty" runat="server" CssClass="zTextboxR" Width="50px" Text="0"></asp:TextBox>
                    <asp:DropDownList ID="cmbUnit" runat="server" CssClass="zHidden" Width="50px"></asp:DropDownList>
                    <asp:Button ID="btnShowAll" runat="server" CssClass="zButton" Text="สูตร" Width="50px" OnClick="btnShowAll_Click" />
                </td>
            </tr>
        </table>
        <input id="<%=lstSelect.ClientID%>_zLstSelect" name="<%=lstSelect.ClientID%>_zLstSelect"
            type="hidden" /><input id="<%=lstAll.ClientID%>_zLstNoSelect" name="<%=lstAll.ClientID%>_zLstNoSelect"
                type="hidden" />

        <asp:Panel ID="pnlFormulaSet" runat="server" CssClass="modalPopup" style="display:none" Width="800px" ScrollBars="Auto">
            <table border="0" cellspacing="0" cellpadding="0" width="100%">
                <tr>
                    <td><uc1:ToolBarItemCtl ID="tbBack" runat="server" ToobarTitle="กลับหน้ารายการ" ToolbarImage="../../Images/icn_back.png" />
                    </td>
                </tr>
                <tr>
                    <td><hr size="1" />
                    </td>
                </tr>
                <tr>
                    <td>
                        <asp:Label ID="lblFormulaSetName" runat="server" Font-Bold="True" Font-Size="10pt" EnableViewState="False"></asp:Label></td>
                </tr>
                <tr>
                    <td style="height:15px">
                    </td>
                </tr>
                <tr>
                    <td>
                        <asp:GridView ID="gvFormulaSetItem" runat="server" AutoGenerateColumns="False" CssClass="t_tablestyle" Width="1100px" EnableViewState="false">
                            <Columns>
                                <asp:TemplateField HeaderText="ลำดับ">
                                    <ItemTemplate>
                                        <%# Container.DataItemIndex + 1%>
                                    </ItemTemplate> 
                                    <HeaderStyle Width="60px" />
                                    <ItemStyle HorizontalAlign="Center" Width="60px" Height="24px" />
                                </asp:TemplateField> 
                                <asp:BoundField DataField="MATERIALNAME" HeaderText="ส่วนผสม">
                                </asp:BoundField>
                                <asp:BoundField DataField="WEIGHT" HeaderText="น้ำหนักเบิก" HtmlEncode="False" DataFormatString="{0:#,##0.00}" ReadOnly="True">
                                    <ItemStyle HorizontalAlign="Right" Width="80px" />
                                    <HeaderStyle HorizontalAlign="Center" Width="80px" />
                                </asp:BoundField>
                                <asp:BoundField DataField="PREPARENAME" HeaderText="ชื่อในการเตรียม">
                                    <ItemStyle Width="150px" />
                                    <HeaderStyle HorizontalAlign="Center" Width="150px" />
                                </asp:BoundField>
                                <asp:BoundField DataField="WEIGHTRAW" HeaderText="น้ำหนักดิบ (g)" HtmlEncode="False" DataFormatString="{0:#,##0.00}" ReadOnly="True">
                                    <ItemStyle HorizontalAlign="Right" Width="80px" />
                                    <HeaderStyle HorizontalAlign="Center" Width="80px" />
                                </asp:BoundField>
                                <asp:BoundField DataField="WEIGHTRIPE" HeaderText="น้ำหนักสุก (g)" HtmlEncode="False" DataFormatString="{0:#,##0.00}" ReadOnly="True">
                                    <ItemStyle HorizontalAlign="Right" Width="80px" />
                                    <HeaderStyle HorizontalAlign="Center" Width="80px" />
                                </asp:BoundField>
                                <asp:BoundField DataField="ENERGY" HeaderText="พลังงาน (kcal)" InsertVisible="False" HtmlEncode="False" DataFormatString="{0:#,##0.00}" ReadOnly="True">
                                    <ItemStyle HorizontalAlign="Right" Width="90px" />
                                    <HeaderStyle HorizontalAlign="Center" Width="90px" />
                                    <FooterStyle HorizontalAlign="Right" Width="90px"/>
                                </asp:BoundField>
                                <asp:BoundField DataField="CARBOHYDRATE" HeaderText="คาร์โบไฮเดรต (g)" InsertVisible="False" HtmlEncode="False" DataFormatString="{0:#,##0.00}" ReadOnly="True">
                                    <ItemStyle HorizontalAlign="Right" Width="100px" />
                                    <HeaderStyle HorizontalAlign="Center" Width="100px" />
                                    <FooterStyle HorizontalAlign="Right" Width="100px" />
                                </asp:BoundField>
                                <asp:BoundField DataField="PROTEIN" HeaderText="โปรตีน (g)" InsertVisible="False" HtmlEncode="False" DataFormatString="{0:#,##0.00}" ReadOnly="True">
                                    <ItemStyle HorizontalAlign="Right" Width="80px" />
                                    <HeaderStyle HorizontalAlign="Center" Width="80px" />
                                    <FooterStyle HorizontalAlign="Right" Width="80px" />
                                </asp:BoundField>
                                <asp:BoundField DataField="FAT" HeaderText="ไขมัน (g)" InsertVisible="False" HtmlEncode="False" DataFormatString="{0:#,##0.00}" ReadOnly="True">
                                    <ItemStyle HorizontalAlign="Right" Width="80px" />
                                    <HeaderStyle HorizontalAlign="Center" Width="80px" />
                                    <FooterStyle HorizontalAlign="Right" Width="80px" />
                                </asp:BoundField>
                                <asp:BoundField DataField="SODIUM" HeaderText="โซเดียม (mg)" InsertVisible="False" HtmlEncode="False" DataFormatString="{0:#,##0.00}" ReadOnly="True">
                                    <ItemStyle HorizontalAlign="Right" Width="80px" />
                                    <HeaderStyle HorizontalAlign="Center" Width="80px" />
                                    <FooterStyle HorizontalAlign="Right" Width="80px" />
                                </asp:BoundField>
                            </Columns> 
                            <HeaderStyle CssClass="t_headtext" />
                            <AlternatingRowStyle CssClass="t_alt_bg" />
                            <PagerSettings Visible="False" />
                         </asp:GridView>
                    </td>
                </tr>
            </table>
        </asp:Panel>
    </ContentTemplate>
    <Triggers>
        <asp:AsyncPostBackTrigger ControlID="btnShowAll" EventName="Click" />
        <asp:AsyncPostBackTrigger ControlID="btnShowSelect" EventName="Click" />
    </Triggers>
</asp:UpdatePanel> 
        <cc1:ModalPopupExtender ID="popupFormulaSet"  runat="server" PopupControlID="pnlFormulaSet" BackgroundCssClass="modalBackground" DropShadow="true" TargetControlID="btntest"></cc1:ModalPopupExtender>