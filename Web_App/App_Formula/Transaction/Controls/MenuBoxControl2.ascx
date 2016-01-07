<%@ Control Language="C#" AutoEventWireup="true" CodeFile="MenuBoxControl2.ascx.cs" Inherits="App_Formula_Transaction_Controls_MenuBoxControl2" %>
<%@ Register Src="../../../Templates/ToolBarItemCtl.ascx" TagName="ToolBarItemCtl" TagPrefix="uc1" %>
<%@ Register Src="../../../Templates/CalendarControl.ascx" TagName="CalendarControl"
    TagPrefix="uc2" %>
<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="cc1" %>

<asp:Button ID="btntest" runat="server" Text="test" CssClass="zHidden" /> 
<asp:Button ID="btntest2" runat="server" Text="test" CssClass="zHidden" /> 
<asp:UpdatePanel ID="UpdatePanel1" runat="server">
    <ContentTemplate>
        <table border="0" cellpadding="0" cellspacing="0" width="570">
            <tr>
                <td style="padding-right: 4px; padding-left: 4px; padding-bottom: 4px; width: 200px;
                    padding-top: 4px; background-color: #f8f8ff; text-align: right">
                    <asp:ListBox ID="lstSelect" runat="server" CssClass="zTextbox" Height="80px" Width="200px">
                    </asp:ListBox>
                    <asp:DropDownList ID="cmbUnitSelect" runat="server" Visible="false" CssClass="zComboBox" Width="70px"></asp:DropDownList>
                    <asp:Button ID="btnChange" runat="server" CssClass="zHidden" Text="เปลี่ยนเมนู" Width="70px" OnClick="btnChange_Click" />
                    <asp:Button ID="btnShowSelect" runat="server" CssClass="zButton" Text="สูตร" Width="50px" OnClick="btnShowSelect_Click" />
                </td>
                <td align="center" style="width: 170px" valign="top">
                    <br />
                    <br />
                    <asp:Button ID="btnAdd" runat="server" CssClass="zButton" Text="<" Width="30px" />
                    <br />
                    <asp:Button ID="btnRemove" runat="server" CssClass="zButton" Text=">" Width="30px" />
                </td>
                <td style="padding-right: 4px; padding-left: 4px; padding-bottom: 4px; width: 200px;
                    padding-top: 4px; background-color: #f8f8ff; text-align: right">
                    <asp:ListBox ID="lstAll" runat="server" CssClass="zTextbox" Height="80px" Width="200px" OnSelectedIndexChanged="lstAll_SelectedIndexChanged" AutoPostBack="True" ></asp:ListBox>
                    <asp:Label ID="lblQty" runat="server" Text="จำนวน :"></asp:Label>
                    <asp:TextBox ID="txtQty" runat="server" CssClass="zTextboxR" Width="30px" Text="0"></asp:TextBox>
                    <asp:DropDownList ID="cmbUnit" runat="server" CssClass="zComboBox" Width="70px"></asp:DropDownList>
                    <asp:Button ID="btnShowAll" runat="server" CssClass="zButton" Text="สูตร" Width="50px" OnClick="btnShowAll_Click" />
                </td>
            </tr>
        </table>
        <input id="<%=lstSelect.ClientID%>_zLstSelect" name="<%=lstSelect.ClientID%>_zLstSelect"
            type="hidden" /><input id="<%=lstAll.ClientID%>_zLstNoSelect" name="<%=lstAll.ClientID%>_zLstNoSelect"
                type="hidden" />

        <asp:Panel ID="pnlFormulaSet" runat="server" CssClass="modalPopup" Width="800px" ScrollBars="horizontal">
            <table border="0" cellspacing="0" cellpadding="0" width="100%">
                <tr>
                    <td><uc1:ToolBarItemCtl ID="tbBack" runat="server" ToobarTitle="กลับหน้ารายการ" ToolbarImage="../../Images/icn_back.png" />
                    </td>
                </tr>
                <tr>
                    <td><hr style="size:1px" />
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
        
                <asp:Panel ID="pnlChange" runat="server" CssClass="modalPopup" Width="800px" ScrollBars="horizontal">
            <table border="0" cellspacing="0" cellpadding="0" width="100%">
                <tr>
                    <td><uc1:ToolBarItemCtl ID="ToolBarItemCtl2" runat="server" ToobarTitle="บันทึก" ToolbarImage="../../Images/icn_save_add.png" OnClick="tbSaveClick" />
                    <uc1:ToolBarItemCtl ID="ToolBarItemCtl1" runat="server" ToobarTitle="ยกเลิก" ToolbarImage="../../Images/icn_cancel.png" />
                    </td>
                </tr>
                <tr>
                    <td><hr style="size:1px" />
                    </td>
                </tr>
                <tr>
                    <td>
                        <asp:Label ID="lblErr" runat="server" ForeColor="red" Font-Bold="True" Font-Size="10pt" EnableViewState="False"></asp:Label></td>
                </tr>
                <tr>
                    <td style="height:15px">
                    </td>
                </tr>
                <tr>
                    <td>
                       <table>
                       <tr>
                       <td>ชื่อเมนู</td>
                       <td>
                       <asp:TextBox ID="txtRef" CssClass="zHidden" Width="10" runat="server"></asp:TextBox>
                       <asp:TextBox ID="txtMenuItem" CssClass="zHidden" Width="10" runat="server"></asp:TextBox>
                       <asp:TextBox ID="txtMenu" CssClass="zHidden" Width="10" runat="server"></asp:TextBox>
                           <asp:TextBox ID="txtMenuName" CssClass="zTextbox-View" ReadOnly="true" Width="100" runat="server"></asp:TextBox></td>
                       </tr>
                       <tr>
                       <td>ชนิดอาหาร</td>
                       <td>
                           <asp:TextBox ID="txtType" CssClass="zTextbox-View" ReadOnly="true" Width="100" runat="server"></asp:TextBox></td>
                       </tr>
                       <tr>
                       <td>ประเภทอาหาร</td>
                       <td>
                           <asp:TextBox ID="txtCatgory" CssClass="zTextbox-View" ReadOnly="true" Width="100" runat="server"></asp:TextBox></td>
                       </tr>
                       <tr>
                       <td>วันที่</td>
                       <td>
                       <asp:TextBox ID="txtDateLoid" CssClass="zHidden" Width="10" runat="server"></asp:TextBox>
                           <uc2:CalendarControl ID="ctlDate" runat="server" />  มื้อ   <asp:TextBox ID="txtMealName" CssClass="zTextbox-View" ReadOnly="true" Width="50" runat="server"></asp:TextBox><asp:TextBox ID="txtMeal" CssClass="zHidden" Width="50" runat="server"></asp:TextBox></td>
                       </tr>
                       <tr>
                       <td>ประเภทรายการ</td>
                       <td>
                           <asp:TextBox ID="txtGroupName" CssClass="zTextbox-View" ReadOnly="true" Width="100" runat="server"></asp:TextBox><asp:TextBox ID="txtgroup" CssClass="zHidden" Width="10" runat="server"></asp:TextBox></td>
                       </tr>

                       <tr>
                       <td>เมนูเดิม</td>
                       <td>
                       <asp:TextBox ID="txtMaterial" CssClass="zHidden" Width="10" runat="server"></asp:TextBox>
                           <asp:TextBox ID="txtOldMenu" CssClass="zTextbox-View" ReadOnly="true" Width="100" runat="server"></asp:TextBox></td>
                       </tr>
                       <tr>
                       <td>เมนูใหม่</td>
                       <td>
                           <asp:TextBox ID="txtNewRef" CssClass="zHidden" Width="10" runat="server"></asp:TextBox>
                           <asp:DropDownList ID="cmbMenu" runat="server" OnSelectedIndexChanged="cmbMenu_SelectedIndexChanged" AutoPostBack="true" >
                           </asp:DropDownList></td>
                       </tr>
                       <tr>
                       <td>จำนวน</td>
                       <td>
                           <asp:TextBox ID="txtMenuQty" CssClass="zTextbox-View" ReadOnly="true" Width="100" runat="server"></asp:TextBox>
                           <asp:TextBox ID="txtUnit" CssClass="zHidden" Width="10" runat="server"></asp:TextBox></td>
                       </tr>
                       </table> 
                    </td>
                </tr>
            </table>
        </asp:Panel>
    </ContentTemplate>
    <Triggers>
        <asp:AsyncPostBackTrigger ControlID="btnShowAll" EventName="Click" />
        <asp:AsyncPostBackTrigger ControlID="btnShowSelect" EventName="Click" />
        <asp:AsyncPostBackTrigger ControlID="btnChange" EventName="Click" />
    </Triggers>
</asp:UpdatePanel> 
        <cc1:ModalPopupExtender ID="popupFormulaSet"  runat="server" PopupControlID="pnlFormulaSet" BackgroundCssClass="modalBackground" DropShadow="true" TargetControlID="btntest"></cc1:ModalPopupExtender>
        <cc1:ModalPopupExtender ID="popupChange"  runat="server" PopupControlID="pnlChange" BackgroundCssClass="modalBackground" DropShadow="true" TargetControlID="btntest2"></cc1:ModalPopupExtender>
