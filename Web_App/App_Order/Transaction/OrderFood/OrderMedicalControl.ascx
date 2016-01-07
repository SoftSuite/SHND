<%@ Control Language="C#" AutoEventWireup="true" CodeFile="OrderMedicalControl.ascx.cs" Inherits="App_Order_Transaction_OrderFood_OrderMedicalControl" %>
<%@ Register Src="../../../Search/DiseaseCategoryPopup_Meal.ascx" TagName="DiseaseCategoryPopup" TagPrefix="uc3" %>
<%@ Register Src="../../../Templates/CalendarControl.ascx" TagName="CalendarControl" TagPrefix="uc2" %>
<%@ Register Src="../../../Templates/ToolBarItemCtl.ascx" TagName="ToolBarItemCtl" TagPrefix="uc1" %>
<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="cc1" %>
<cc1:ModalPopupExtender ID="popupOrder"  runat="server" PopupControlID="pnlOrder" BackgroundCssClass="modalBackground" DropShadow="true" TargetControlID="btntest" ></cc1:ModalPopupExtender>
<asp:Panel ID="pnlOrder" runat="server" CssClass="modalPopupSearch" style="display:none">
    <table border="0" cellspacing="0" cellpadding="0" width="100%" >
        <tr>
            <td class="headtext">อาหารที่แพทย์สั่ง
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
                <asp:TextBox ID="txtIsView" runat="server" CssClass="zHidden" Width="50px"></asp:TextBox></td>
        </tr>
        <tr>
            <td>
                <table border="0" cellpadding="0" cellspacing="0" width="700">
                    <tr style="height:24px">
                        <td style="width:150px; padding-right:10px" align="right">ชนิดอาหาร :
                        </td>
                        <td style="width: 550px">
                            <asp:DropDownList ID="cmbFoodCategory" runat="server" CssClass="zComboBox" Enabled="False" Width="150px"></asp:DropDownList>
                            &nbsp;<span class="zRemark">*</span>
                        </td>
                    </tr> 
                    <tr style="height:24px">
                        <td style="width:150px; padding-right:10px" align="right">
                            มื้อ :
                        </td>
                        <td style="width: 550px">
                            <asp:CheckBox ID="chkBreakfast" runat="server" Text="เช้า" />
                            <asp:CheckBox ID="chkLunch" runat="server" Text="กลางวัน" />
                            <asp:CheckBox ID="chkDinner" runat="server" Text="เย็น" /></td>
                    </tr> 
                    <tr style="height:24px">
                        <td style="width:150px; padding-right:10px" align="right">เริ่ม :
                        </td>
                        <td style="width: 550px">
                            <uc2:CalendarControl ID="ctlFirstDate" runat="server" /><uc2:CalendarControl ID="ctlFirstDateRegis" Visible="false" runat="server" />
                            &nbsp;มื้อ&nbsp;
                            <asp:DropDownList ID="cmbFirstMeal" runat="server" CssClass="zComboBox" Width="80px">
                                <asp:ListItem Text="" Value=""></asp:ListItem>
                                <asp:ListItem Text="เช้า" Value="11"></asp:ListItem>
                                <asp:ListItem Text="กลางวัน" Value="21"></asp:ListItem>
                                <asp:ListItem Text="เย็น" Value="31"></asp:ListItem>
                            </asp:DropDownList><asp:TextBox ID="txtFirstMealRegis" runat="server" CssClass="zHidden" Width="50px"></asp:TextBox>
                            &nbsp;<span class="zRemark">*</span>
                        </td>
                    </tr> 
                    <tr style="height:24px">
                        <td style="width:150px; padding-right:10px" align="right">ถึง :
                        </td>
                        <td style="width: 550px">
                            <uc2:CalendarControl ID="ctlEndDate" runat="server" />
                            &nbsp;มื้อ&nbsp;
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
                        <td style="width: 550px">
                        </td>
                    </tr>
                    <tr>
                        <td align="right" style="padding-right: 10px; width: 150px">
                        </td>
                        <td style="width: 550px">
                            <table border="0" cellpadding="0" cellspacing="0" width="506px">
                                <tr>
                                    <td style="padding:5px; border-right: 1px solid; border-top: 1px solid; border-left: 1px solid; border-bottom: 1px solid;">
                                        <table border="0" cellpadding="0" cellspacing="0" width="100%" >
                                            <tr>
                                                <td class="toolbarplace">
                                                    <asp:CheckBox ID="chkIsSpecific" runat="server" Text="เฉพาะโรค" />
                                                    <asp:CheckBox ID="chkIsCalculate" runat="server" Text="อาหารคำนวณแคลอรี่" />
                                                    <asp:CheckBox ID="chkIsLimit" runat="server" Text="อาหารจำกัดปริมาณ" />
                                                    <asp:CheckBox ID="chkIsIncrease" runat="server" Text="อาหารเสริม" />
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
                                                            <asp:TemplateField HeaderText="High">
                                                                <ItemTemplate>
                                                                    <asp:RadioButton ID="chkHigh" runat="server" GroupName="CategoryName" Visible='<%# Eval("ISHIGH").ToString() =="Y"  %>' Checked='<%# Eval("ISHIGH").ToString() =="Y" %>'  />
                                                                </ItemTemplate>
                                                                <HeaderStyle Width="40px" />
                                                                <ItemStyle HorizontalAlign="Center" Width="40px" />
                                                            </asp:TemplateField>
                                                            <asp:TemplateField HeaderText="Low">
                                                                <ItemTemplate>
                                                                    <asp:RadioButton ID="chkLow" runat="server" GroupName="CategoryName" Visible='<%# Eval("ISLOW").ToString() =="Y" %>' Checked='<%# Eval("ISLOW").ToString() =="Y" %>' />
                                                                </ItemTemplate>
                                                                <HeaderStyle Width="40px" />
                                                                <ItemStyle HorizontalAlign="Center" Width="40px" />
                                                            </asp:TemplateField>
                                                            <asp:TemplateField HeaderText="None">
                                                                <ItemTemplate>
                                                                    <asp:RadioButton ID="chkNon" runat="server" GroupName="CategoryName" Visible='<%# Eval("ISNON").ToString() =="Y" %>'  Checked='<%# Eval("ISNON").ToString() =="Y" %>' />
                                                                </ItemTemplate>
                                                                <HeaderStyle Width="40px" />
                                                                <ItemStyle HorizontalAlign="Center" Width="40px" />
                                                            </asp:TemplateField>
                                                            <asp:BoundField DataField="QTY" HeaderText="ปริมาณ" SortExpression="QTY"  HtmlEncode="False" DataFormatString="{0:#,##0.00}">
                                                                <HeaderStyle Width="60px" />
                                                                <ItemStyle HorizontalAlign="Right" Width="60px" />
                                                            </asp:BoundField>
                                                            <asp:BoundField DataField="UNITNAME" HeaderText="หน่วย" SortExpression="UNITNAME">
                                                                <HeaderStyle Width="60px" />
                                                                <ItemStyle Width="60px" />
                                                            </asp:BoundField>
                                                            <asp:BoundField DataField="MEALNAME" HeaderText="อาหารเสริมมื้อ" SortExpression="MEALNAME">
                                                                <HeaderStyle Width="60px" />
                                                                <ItemStyle Width="60px" />
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
                                                            <asp:Parameter DefaultValue="ORDERMEDICALSET" Name="refTable" Type="String" />
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
                        <td style="width: 550px">
                        </td>
                    </tr>
                    <tr>
                        <td align="right" style="padding-right: 10px; width: 150px"valign="top">
                            <table border="0" cellpadding="0" cellspacing="0" width="100px">
                                <tr style="height:24px">
                                    <td align="right">หมายเหตุ :</td> 
                                </tr>
                            </table>
                        </td>
                        <td style="width: 550px">
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
