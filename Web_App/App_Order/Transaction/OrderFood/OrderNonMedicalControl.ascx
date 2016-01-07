<%@ Control Language="C#" AutoEventWireup="true" CodeFile="OrderNonMedicalControl.ascx.cs" Inherits="App_Order_Transaction_OrderFood_OrderNonMedicalControl" %>
<%@ Register Src="../../../Search/DiseaseCategoryPopup_Meal.ascx" TagName="DiseaseCategoryPopup" TagPrefix="uc3" %>
<%@ Register Src="../../../Templates/CalendarControl.ascx" TagName="CalendarControl" TagPrefix="uc2" %>
<%@ Register Src="../../../Templates/ToolBarItemCtl.ascx" TagName="ToolBarItemCtl" TagPrefix="uc1" %>
<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="cc1" %>
<cc1:ModalPopupExtender ID="popupOrder"  runat="server" PopupControlID="pnlOrder" BackgroundCssClass="modalBackground" DropShadow="true" TargetControlID="btntest" ></cc1:ModalPopupExtender>
<asp:Panel ID="pnlOrder" runat="server" CssClass="modalPopupSearch" style="display:none;">
    <table border="0" cellspacing="0" cellpadding="0" width="100%" >
        <tr>
            <td class="headtext">อาหารที่พยาบาลสั่ง
            </td>
        </tr>
        <tr>
            <td>
                <uc1:ToolBarItemCtl ID="tbSave" runat="server" ToobarTitle="บันทึก" ToolbarImage="../../Images/save2.png" OnClick="tbSaveClick" />
                <uc1:ToolBarItemCtl ID="tbCancel" runat="server" ToobarTitle="ยกเลิกการแก้ไข" ToolbarImage="../../Images/cancel.png" OnClick="tbCancelClick" />
                <uc1:ToolBarItemCtl ID="tbBack" runat="server" ToobarTitle="กลับหน้ารายการ" ToolbarImage="../../Images/icn_back.png" />
                <uc1:ToolBarItemCtl ID="tbDiscontinue" runat="server" ToobarTitle="Discontinue" ToolbarImage="../../Images/icn_cancel.png" OnClick="tbDiscontinueClick" />
            </td>
        </tr>
        <tr>
            <td style="height:30px;" valign="top">
                <hr style="size:1px" />
                <asp:Label ID="lbStatus" runat="server" EnableViewState="False"></asp:Label>
                <asp:TextBox ID="txtLOID" runat="server" CssClass="zHidden" Width="50px"></asp:TextBox>
                <asp:TextBox ID="txtWard" runat="server" CssClass="zHidden" Width="50px"></asp:TextBox>
                <asp:TextBox ID="txtStatus" runat="server" CssClass="zHidden" Width="50px"></asp:TextBox>
                <asp:TextBox ID="txtAdmitPatient" runat="server" CssClass="zHidden" Width="50px"></asp:TextBox>
                <asp:TextBox ID="txtIsView" runat="server" CssClass="zHidden" Width="50px"></asp:TextBox>
            </td>
        </tr>
        <tr>
            <td>
                <table border="0" cellpadding="0" cellspacing="0" width="700">
                    <tr style="height:24px">
                        <td style="width:150px; padding-right:10px" align="right">
                            ประเภทอาหาร :
                        </td>
                        <td colspan="3" style="width: 550px">
                            <asp:DropDownList ID="cmbFoodType" runat="server" CssClass="zComboBox" Enabled="False" Width="150px"></asp:DropDownList>
                            &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp;
                            <asp:CheckBox ID="chkIsFamily" runat="server" Text="อาหารญาติ" /></td>
                    </tr> 
                    <tr style="height:24px">
                        <td style="width:150px; padding-right:10px" align="right">
                            มื้อ :
                        </td>
                        <td colspan="3" style="width: 550px">
                            <asp:CheckBox ID="chkBreakfast" runat="server" Text="เช้า" />
                            <asp:TextBox ID="txtBreakfast" runat="server" CssClass="zTextboxR" Width="30px" MaxLength="2"></asp:TextBox>
                            &nbsp; &nbsp; &nbsp; &nbsp; &nbsp;<asp:CheckBox ID="chkLunch" runat="server" Text="กลางวัน" />
                            <asp:TextBox ID="txtLunch" runat="server" CssClass="zTextboxR" Width="30px" MaxLength="2"></asp:TextBox>
                            &nbsp; &nbsp; &nbsp; &nbsp;&nbsp;
                            <asp:CheckBox ID="chkDinner" runat="server" Text="เย็น" />
                            <asp:TextBox ID="txtDinner" runat="server" CssClass="zTextboxR" Width="30px" MaxLength="2"></asp:TextBox></td>
                    </tr> 
                    <tr style="height:24px">
                        <td style="width:150px; padding-right:10px" align="right">เริ่ม :
                        </td>
                        <td colspan="3" style="width: 550px">
                            <uc2:CalendarControl ID="ctlFirstDate" runat="server" /><uc2:CalendarControl ID="ctlFirstDateRegis" Visible="false" runat="server" />&nbsp;มื้อ
                            <asp:DropDownList ID="cmbFirstMeal" runat="server" CssClass="zComboBox" Width="80px">
                                <asp:ListItem Text="" Value=""></asp:ListItem>
                                <asp:ListItem Text="เช้า" Value="11"></asp:ListItem>
                                <asp:ListItem Text="กลางวัน" Value="21"></asp:ListItem>
                                <asp:ListItem Text="เย็น" Value="31"></asp:ListItem>
                            </asp:DropDownList><asp:TextBox ID="txtFirstMealRegis" runat="server" CssClass="zHidden" Width="50px"></asp:TextBox>
                            &nbsp;<span class="zRemark">*</span>&nbsp;
                        </td>
                    </tr> 
                    <tr style="height:24px">
                        <td style="width:150px; padding-right:10px" align="right">ถึง :
                        </td>
                        <td colspan="3" style="width: 550px">
                            <uc2:CalendarControl ID="ctlEndDate" runat="server" />&nbsp;มื้อ
                            <asp:DropDownList ID="cmbEndMeal" runat="server" CssClass="zComboBox" Width="80px">
                                <asp:ListItem Text="" Value=""></asp:ListItem>
                                <asp:ListItem Text="เช้า" Value="11"></asp:ListItem>
                                <asp:ListItem Text="กลางวัน" Value="21"></asp:ListItem>
                                <asp:ListItem Text="เย็น" Value="31"></asp:ListItem>
                            </asp:DropDownList>
                        </td>
                    </tr>
                    <tr style="height: 3px">
                        <td align="right" style="padding-right: 10px; width: 150px">
                        </td>
                        <td colspan="3" style="width: 550px">
                        </td>
                    </tr>
                    <tr>
                        <td align="right" style="padding-right: 10px; width: 150px">
                        </td>
                        <td colspan="3" style="width: 550px">
                            <table border="0" cellpadding="0" cellspacing="0" width="506px">
                                <tr>
                                    <td style="padding:5px; border-right: 1px solid; border-top: 1px solid; border-left: 1px solid; border-bottom: 1px solid;">
                                        <table border="0" cellpadding="0" cellspacing="0" width="100%" >
                                            <tr>
                                                <td class="toolbarplace">
                                                    <asp:CheckBox ID="chkIsAbstain" runat="server" Text="อาหารที่งด" />
                                                    <asp:CheckBox ID="chkIsNeed" runat="server" Text="อาหารที่รับเฉพาะ" />
                                                    <asp:CheckBox ID="chkIsRequst" runat="server" Text="อาหารที่ขอ" />
                                                    <asp:ImageButton ID="imbAdd" runat="server" ImageAlign="AbsMiddle" ImageUrl="~/Images/icn_find.png" OnClick="imbAdd_Click" />
                                                </td>
                                            </tr> 
                                            <tr>
                                                <td>
                                                    <asp:GridView ID="gvMain" runat="server" AutoGenerateColumns="False" CssClass="t_tablestyle" DataKeyNames="DISEASECATEGORY" DataSourceID="DiseaseCategorySource" OnRowCommand="gvMain_RowCommand" OnRowDeleted="gvMain_RowDeleted" >
                                                        <Columns>
                                                            <asp:BoundField DataField="DISEASECATEGORY" HeaderText="DISEASECATEGORY">
                                                                <ControlStyle CssClass="zHidden" />
                                                                <FooterStyle CssClass="zHidden" />
                                                                <HeaderStyle CssClass="zHidden" />
                                                                <ItemStyle CssClass="zHidden" />
                                                            </asp:BoundField>
                                                            <asp:TemplateField>
                                                                <ItemTemplate>
                                                                    <asp:ImageButton ID="imbDelete" runat="server" ImageUrl="~/Images/icn_delete.png" ToolTip="ลบรายการ" CommandName="Delete" />
                                                                </ItemTemplate>
                                                                <HeaderStyle HorizontalAlign="Center" Width="30px" />
                                                                <ItemStyle HorizontalAlign="Center" Width="30px" />
                                                            </asp:TemplateField>
                                                            <asp:TemplateField HeaderText="ลำดับ" SortExpression="DEFAULT">
                                                                <ItemTemplate>
                                                                    <%# Container.DataItemIndex+1 %>
                                                                </ItemTemplate> 
                                                                <HeaderStyle Width="50px" />
                                                                <ItemStyle HorizontalAlign="Center" Width="50px" Height="20px" />
                                                            </asp:TemplateField>
                                                            <asp:BoundField DataField="DISEASECATEGORYNAME" HeaderText="สารอาหารที่ควบคุม" SortExpression="DISEASECATEGORYNAME">
                                                            </asp:BoundField>
                                                            <asp:BoundField DataField="QTY" HeaderText="ปริมาณ" SortExpression="QTY"  HtmlEncode="False" DataFormatString="{0:#,##0.00}">
                                                                <HeaderStyle Width="80px" />
                                                                <ItemStyle HorizontalAlign="Right" Width="80px" />
                                                            </asp:BoundField>
                                                            <asp:BoundField DataField="UNITNAME" HeaderText="หน่วย" SortExpression="UNITNAME">
                                                                <HeaderStyle Width="80px" />
                                                                <ItemStyle Width="80px" />
                                                            </asp:BoundField>
                                                            <asp:BoundField DataField="MEALNAME" HeaderText="อาหารเสริมมื้อ" SortExpression="MEALNAME">
                                                                <HeaderStyle CssClass="zHidden" Width="60px" />
                                                                <ItemStyle CssClass="zHidden" Width="60px" />
                                                            </asp:BoundField>  
                                                        </Columns>
                                                        <HeaderStyle CssClass="t_headtext" />
                                                        <AlternatingRowStyle CssClass="t_alt_bg" />
                                                        <PagerSettings Visible="False" />
                                                    </asp:GridView>
                                                    <asp:ObjectDataSource ID="DiseaseCategorySource" runat="server" DeleteMethod="DeleteDiseaseCategory"
                                                        SelectMethod="GetDiseaseCategoryList" TypeName="OrderFoodDetailItem">
                                                        <DeleteParameters>
                                                            <asp:Parameter Name="DISEASECATEGORY" Type="Double" />
                                                        </DeleteParameters>
                                                        <SelectParameters>
                                                            <asp:ControlParameter ControlID="txtLOID" DefaultValue="0" Name="refLOID" PropertyName="Text"
                                                                Type="Double" />
                                                            <asp:Parameter DefaultValue="ORDERNONMEDICAL" Name="refTable" Type="String" />
                                                        </SelectParameters>
                                                    </asp:ObjectDataSource>
                                                </td>
                                            </tr> 
                                        </table>
                                    </td> 
                                </tr>
                            </table>
                        </td>
                    </tr>
                    <tr style="height: 3px">
                        <td align="right" style="padding-right: 10px; width: 150px">
                        </td>
                        <td colspan="3" style="width: 550px">
                        </td>
                    </tr>
                    <tr style="height:24px">
                        <td style="width: 150px">
                            <asp:CheckBox ID="chkAbstain" runat="server" Text="อาหารที่งด อื่นๆ" />
                        </td>
                        <td colspan="3" style="width: 550px">
                            <asp:TextBox ID="txtAbstainOther" runat="server" CssClass="zTextbox" Width="500px" MaxLength="200"></asp:TextBox>
                        </td>
                    </tr>
                    <tr style="height:24px">
                        <td style="width: 150px; height: 24px;">
                            <asp:CheckBox ID="chkNeed" runat="server" Text="อาหารที่ขอรับเฉพาะ อื่นๆ" />
                        </td>
                        <td colspan="3" style="height: 24px; width: 550px;">
                            <asp:TextBox ID="txtNeedOther" runat="server" CssClass="zTextbox" Width="500px" MaxLength="200"></asp:TextBox>
                        </td>
                    </tr>
                    <tr style="height: 24px">
                        <td align="right" style="padding-right: 10px; width: 150px">
                            ระดับผู้ป่วย :
                        </td>
                        <td colspan="3" style="width: 550px">
                            <asp:DropDownList ID="cmbVIPType" runat="server" CssClass="zComboBox" Width="150px">
                                <asp:ListItem Value="0" Text="ไม่ระบุ"></asp:ListItem>
                                <asp:ListItem Value="1" Text="VIP"></asp:ListItem>
                                <asp:ListItem Value="2" Text="Super VIP"></asp:ListItem>
                            </asp:DropDownList></td>
                    </tr>
                    <tr>
                        <td align="right" style="padding-right: 10px; width: 150px"valign="top">
                            <table border="0" cellpadding="0" cellspacing="0" width="100px">
                                <tr style="height:24px">
                                    <td align="right">หมายเหตุ :</td> 
                                </tr>
                            </table>
                        </td>
                        <td colspan="3" style="width: 550px">
                            <asp:TextBox ID="txtRemarks" runat="server" CssClass="zTextbox" Width="500px" TextMode="multiline" Height="60px" MaxLength="200"></asp:TextBox>
                        </td>
                    </tr>
                </table> 
            </td>
        </tr>
    </table>
</asp:Panel>
<asp:Button ID="btntest" runat="server" Text="test" CssClass="zHidden" />
<uc3:DiseaseCategoryPopup ID="ctlDiseaseCategory" runat="server" OnSelectedIndexChanged="ctlDiseaseCategory_SelectedIndexChanged" />