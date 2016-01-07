<%@ Control Language="C#" AutoEventWireup="true" CodeFile="MenuItemControl.ascx.cs" Inherits="App_Formula_Transaction_Controls_MenuItemControl" %>
<%@ Register Src="../../../Templates/CalendarControl.ascx" TagName="CalendarControl"
    TagPrefix="uc2" %>
<%@ Register Src="MenuBoxControl2.ascx" TagName="MenuBoxControl" TagPrefix="uc1" %>
<asp:UpdatePanel ID="UpdatePanel1" runat="server">
    <ContentTemplate>
        <table border="0" cellspacing="3" cellpadding="0" width="970">
            <tr>
                <td colspan="5">
                    <table border="0" cellpadding="0" cellspacing="0" width="100%">
                        <tr>
                            <td style="width:300px; padding-left:10px">
                                <asp:Label ID="lblError" runat="server" Text="" CssClass="zRemark"></asp:Label></td>
                            <td><asp:TextBox ID="txtDayTo" runat="server" Visible="false" Width="10px"></asp:TextBox>
                            <asp:TextBox ID="txtDayFrom" runat="server" Visible="false" Width="10px"></asp:TextBox>
                                <asp:TextBox ID="txtMeal" runat="server" Visible="false" Width="10px"></asp:TextBox>
                                <asp:TextBox ID="txtMenuID" runat="server" Visible="false" Width="10px"></asp:TextBox>
                                <asp:TextBox ID="txtFoodType" runat="server" Visible="False"></asp:TextBox>
                                <asp:TextBox ID="txtFoodCategory" runat="server" Visible="False"></asp:TextBox>
                                
                            </td>                         
                        </tr> 
                    </table>
                </td>
            </tr>
            <tr style="height:24px">
                <td style="width:120px; padding-right:10px; text-align:right"></td>
                <td style="width: 570px">
                    <table border="0" cellpadding="0" cellspacing="0" width="570">
                        <tr style="height:25px">
                            <td style="width:208px" class="subheadertext" align="center">รายการอาหารในเมนู</td>
                            <td style="width:174px" class="stdmenuhead">
                            <table border="0" cellpadding="0" cellspacing="0" width="100%">
                            <tr><td>วันที่ <uc2:CalendarControl ID="ctlDate" runat="server" /></td>
                            </tr>
                            <tr><td>จำนวน <asp:TextBox ID="txtAmount" CssClass="zTextbox" Width="40" runat="server"></asp:TextBox> คน <asp:ImageButton ID="imbSearch" runat="server" ImageAlign="AbsMiddle" ImageUrl="~/Images/icn_find.png"
                                OnClick="imbSearch_Click" /></td>

                            </tr></table>
                                 </td>
                            <td align="center" style="width:208px" class="subheadertext">รายการอาหารทั้งหมด</td>
                        </tr> 
                    </table>
                </td>
                <td class="subheadertext" style="width:280px;" align="center">สารอาหารที่ได้รับ</td>
            </tr>
            <tr>
                <td style="width:120px; padding-right:10px; text-align:right; vertical-align:top;">
                    ข้าวหรืออาหารจานเดียว</td>
                <td style="width: 570px">
                    <uc1:MenuBoxControl ID="ctlMenuRice" runat="server" OnClickChanged="ctlMenuRice_ClickChanged" />
                </td>
                <td rowspan="6" style="border-right: 1px solid; padding-right: 4px; border-top: 1px solid;
                    padding-left: 4px; padding-bottom: 4px; border-left: 1px solid;
                    padding-top: 4px; border-bottom: 1px solid; background-color: #f8f8ff" valign="top">
                    <asp:GridView ID="gvMenuItemNutrient" runat="server" AutoGenerateColumns="False" CssClass="t_tablestyle" DataSourceID="MenuNutrientSource" Width="100%" >
                        <Columns>
                            <asp:TemplateField HeaderText="ลำดับ">
                                <ItemTemplate>
                                    <%# Container.DataItemIndex + 1%>
                                </ItemTemplate> 
                                <HeaderStyle Width="40px" />
                                <ItemStyle HorizontalAlign="Center" Width="40px" Height="24px" />
                            </asp:TemplateField>
                            <asp:BoundField DataField="NUTRIENTNAME" HeaderText= "สารอาหาร" ReadOnly="True">
                            </asp:BoundField>
                            <asp:TemplateField HeaderText="ปริมาณ">
                                <ItemTemplate>
                                    <asp:Label ID="lblQty" runat="server" Text='<%# Convert.ToDouble(Eval("QTY")).ToString("#,##0.00") + " " + Eval("UNITNAME") %>'></asp:Label>
                                </ItemTemplate>
                                <ItemStyle HorizontalAlign="Center" Width="110px" />
                                <HeaderStyle Width="110px" />
                            </asp:TemplateField> 
                        </Columns>
                        <HeaderStyle CssClass="t_headtext" />
                        <AlternatingRowStyle CssClass="t_alt_bg" />
                        <PagerSettings Visible="False" />
                    </asp:GridView>
                    <asp:ObjectDataSource ID="MenuNutrientSource" runat="server" SelectMethod="GetMenuNutrientList"
                        TypeName="MenuDetailItem">
                        <SelectParameters>
                            <asp:ControlParameter ControlID="txtMenuID" DefaultValue="0" Name="MenuID"
                                PropertyName="Text" Type="Double" />
                            <asp:ControlParameter ControlID="txtMeal" DefaultValue="" Name="meal" PropertyName="Text"
                                Type="String" />
                            <asp:ControlParameter ControlID="ctlDate" DefaultValue="" Name="menuDate" PropertyName="DateValue"
                                Type="DateTime" />
                        </SelectParameters>
                    </asp:ObjectDataSource>
                </td>
            </tr>
            <tr>
                <td style="width:100px; padding-right:10px; text-align:right; vertical-align:top;">
                    กับข้าว</td>
                <td style="width: 570px">
                    <uc1:MenuBoxControl ID="ctlMenuSavory" runat="server" OnClickChanged="ctlMenuSavory_ClickChanged"/></td>
            </tr>
            <tr>
                <td style="width:100px; padding-right:10px; text-align:right; vertical-align:top;">
                    ผลไม้หรือของหวาน</td>
                <td style="width: 570px">
                    <uc1:MenuBoxControl ID="ctlMenuFruits" runat="server" OnClickChanged="ctlMenuFruits_ClickChanged" /></td>
            </tr>
            <tr>
                <td style="width:100px; padding-right:10px; text-align:right; vertical-align:top;">
                    เครื่องดื่ม</td>
                <td style="width: 570px">
                    <uc1:MenuBoxControl ID="ctlMenuDrinks" runat="server" OnClickChanged="ctlMenuDrinks_ClickChanged"/></td>
            </tr>
            <tr>
                <td colspan="2"><hr style="size:1px" /></td> 
            </tr> 
            <tr style="height:24px">
                <td style="padding-right: 10px; width: 100px; text-align: right">
                    พลังงานรวม :</td>
                <td style="width: 570px">
                    <asp:TextBox ID="txtEnergy" runat="server" CssClass="zTextboxR-View" ReadOnly="true" Width="100px"></asp:TextBox>
                    kcal</td>
            </tr>
        </table>
    </ContentTemplate>

</asp:UpdatePanel>
