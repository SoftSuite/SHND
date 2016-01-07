<%@ Control Language="C#" AutoEventWireup="true" CodeFile="StdMenuItemControl.ascx.cs" Inherits="App_Formula_Transaction_Controls_StdMenuItemControl" %>
<%@ Register Src="MenuBoxControl.ascx" TagName="MenuBoxControl" TagPrefix="uc1" %>
<asp:UpdatePanel ID="UpdatePanel1" runat="server">
    <ContentTemplate>
        <table border="0" cellspacing="3" cellpadding="0" width="970">
            <tr>
                <td colspan="5">
                    <table border="0" cellpadding="0" cellspacing="0" width="100%">
                        <tr class="stdmenuhead">
                            <td style="width:50px; padding-left:10px">วันที่</td>
                            <td><asp:TextBox ID="txtCurrentDay" runat="server" Visible="false" Width="10px"></asp:TextBox>
                                <asp:TextBox ID="txtMeal" runat="server" Visible="false" Width="10px"></asp:TextBox>
                                <asp:TextBox ID="txtStdMenuID" runat="server" Visible="false" Width="10px"></asp:TextBox>
                                <asp:TextBox ID="txtFoodType" runat="server" Visible="False"></asp:TextBox>
                            </td>
                            <td align="right">
                                <asp:LinkButton ID="lnkDay1" runat="server" CssClass="datetable" OnClick="lnkDay1_Click" EnableViewState="false">1</asp:LinkButton>
                                <asp:LinkButton ID="lnkDay2" runat="server" CssClass="datetable" OnClick="lnkDay2_Click" EnableViewState="false">2</asp:LinkButton>
                                <asp:LinkButton ID="lnkDay3" runat="server" CssClass="datetable" OnClick="lnkDay3_Click" EnableViewState="false">3</asp:LinkButton>
                                <asp:LinkButton ID="lnkDay4" runat="server" CssClass="datetable" OnClick="lnkDay4_Click" EnableViewState="false">4</asp:LinkButton>
                                <asp:LinkButton ID="lnkDay5" runat="server" CssClass="datetable" OnClick="lnkDay5_Click" EnableViewState="false">5</asp:LinkButton>
                                <asp:LinkButton ID="lnkDay6" runat="server" CssClass="datetable" OnClick="lnkDay6_Click" EnableViewState="false">6</asp:LinkButton>
                                <asp:LinkButton ID="lnkDay7" runat="server" CssClass="datetable" OnClick="lnkDay7_Click" EnableViewState="false">7</asp:LinkButton>
                                <asp:LinkButton ID="lnkDay8" runat="server" CssClass="datetable" OnClick="lnkDay8_Click" EnableViewState="false">8</asp:LinkButton>
                                <asp:LinkButton ID="lnkDay9" runat="server" CssClass="datetable" OnClick="lnkDay9_Click" EnableViewState="false">9</asp:LinkButton>
                                <asp:LinkButton ID="lnkDay10" runat="server" CssClass="datetable" OnClick="lnkDay10_Click" EnableViewState="false">10</asp:LinkButton>
                                <asp:LinkButton ID="lnkDay11" runat="server" CssClass="datetable" OnClick="lnkDay11_Click" EnableViewState="false">11</asp:LinkButton>
                                <asp:LinkButton ID="lnkDay12" runat="server" CssClass="datetable" OnClick="lnkDay12_Click" EnableViewState="false">12</asp:LinkButton>
                                <asp:LinkButton ID="lnkDay13" runat="server" CssClass="datetable" OnClick="lnkDay13_Click" EnableViewState="false">13</asp:LinkButton>
                                <asp:LinkButton ID="lnkDay14" runat="server" CssClass="datetable" OnClick="lnkDay14_Click" EnableViewState="false">14</asp:LinkButton>
                                <asp:LinkButton ID="lnkDay15" runat="server" CssClass="datetable" OnClick="lnkDay15_Click" EnableViewState="false">15</asp:LinkButton>
                                <asp:LinkButton ID="lnkDay16" runat="server" CssClass="datetable" OnClick="lnkDay16_Click" EnableViewState="false">16</asp:LinkButton>
                                <asp:LinkButton ID="lnkDay17" runat="server" CssClass="datetable" OnClick="lnkDay17_Click" EnableViewState="false">17</asp:LinkButton>
                                <asp:LinkButton ID="lnkDay18" runat="server" CssClass="datetable" OnClick="lnkDay18_Click" EnableViewState="false">18</asp:LinkButton>
                                <asp:LinkButton ID="lnkDay19" runat="server" CssClass="datetable" OnClick="lnkDay19_Click" EnableViewState="false">19</asp:LinkButton>
                                <asp:LinkButton ID="lnkDay20" runat="server" CssClass="datetable" OnClick="lnkDay20_Click" EnableViewState="false">20</asp:LinkButton>
                                <asp:LinkButton ID="lnkDay21" runat="server" CssClass="datetable" OnClick="lnkDay21_Click" EnableViewState="false">21</asp:LinkButton>
                                <asp:LinkButton ID="lnkDay22" runat="server" CssClass="datetable" OnClick="lnkDay22_Click" EnableViewState="false">22</asp:LinkButton>
                                <asp:LinkButton ID="lnkDay23" runat="server" CssClass="datetable" OnClick="lnkDay23_Click" EnableViewState="false">23</asp:LinkButton>
                                <asp:LinkButton ID="lnkDay24" runat="server" CssClass="datetable" OnClick="lnkDay24_Click" EnableViewState="false">24</asp:LinkButton>
                                <asp:LinkButton ID="lnkDay25" runat="server" CssClass="datetable" OnClick="lnkDay25_Click" EnableViewState="false">25</asp:LinkButton>
                                <asp:LinkButton ID="lnkDay26" runat="server" CssClass="datetable" OnClick="lnkDay26_Click" EnableViewState="false">26</asp:LinkButton>
                                <asp:LinkButton ID="lnkDay27" runat="server" CssClass="datetable" OnClick="lnkDay27_Click" EnableViewState="false">27</asp:LinkButton>
                                <asp:LinkButton ID="lnkDay28" runat="server" CssClass="datetable" OnClick="lnkDay28_Click" EnableViewState="false">28</asp:LinkButton>
                                <asp:LinkButton ID="lnkDay29" runat="server" CssClass="datetable" OnClick="lnkDay29_Click" EnableViewState="false">29</asp:LinkButton>
                                <asp:LinkButton ID="lnkDay30" runat="server" CssClass="datetable" OnClick="lnkDay30_Click" EnableViewState="false">30</asp:LinkButton>
                                <asp:LinkButton ID="lnkDay31" runat="server" CssClass="datetable" OnClick="lnkDay31_Click" EnableViewState="false">31</asp:LinkButton>
                            </td> 
                        </tr> 
                        <tr class="stdmenuhead">
                            <td style="width:50px; padding-left:10px">คัดลอก</td>
                            <td align="right">
                                <asp:CheckBox ID="chkAll" runat="server" CssClass="checktable" Visible="false" />
                            </td>
                            <td align="right">
                                <asp:CheckBox ID="chkDay1" runat="server" CssClass="checktable" />
                                <asp:CheckBox ID="chkDay2" runat="server" CssClass="checktable" />
                                <asp:CheckBox ID="chkDay3" runat="server" CssClass="checktable" />
                                <asp:CheckBox ID="chkDay4" runat="server" CssClass="checktable" />
                                <asp:CheckBox ID="chkDay5" runat="server" CssClass="checktable" />
                                <asp:CheckBox ID="chkDay6" runat="server" CssClass="checktable" />
                                <asp:CheckBox ID="chkDay7" runat="server" CssClass="checktable" />
                                <asp:CheckBox ID="chkDay8" runat="server" CssClass="checktable" />
                                <asp:CheckBox ID="chkDay9" runat="server" CssClass="checktable" />
                                <asp:CheckBox ID="chkDay10" runat="server" CssClass="checktable" />
                                <asp:CheckBox ID="chkDay11" runat="server" CssClass="checktable" />
                                <asp:CheckBox ID="chkDay12" runat="server" CssClass="checktable" />
                                <asp:CheckBox ID="chkDay13" runat="server" CssClass="checktable" />
                                <asp:CheckBox ID="chkDay14" runat="server" CssClass="checktable" />
                                <asp:CheckBox ID="chkDay15" runat="server" CssClass="checktable" />
                                <asp:CheckBox ID="chkDay16" runat="server" CssClass="checktable" />
                                <asp:CheckBox ID="chkDay17" runat="server" CssClass="checktable" />
                                <asp:CheckBox ID="chkDay18" runat="server" CssClass="checktable" />
                                <asp:CheckBox ID="chkDay19" runat="server" CssClass="checktable" />
                                <asp:CheckBox ID="chkDay20" runat="server" CssClass="checktable" />
                                <asp:CheckBox ID="chkDay21" runat="server" CssClass="checktable" />
                                <asp:CheckBox ID="chkDay22" runat="server" CssClass="checktable" />
                                <asp:CheckBox ID="chkDay23" runat="server" CssClass="checktable" />
                                <asp:CheckBox ID="chkDay24" runat="server" CssClass="checktable" />
                                <asp:CheckBox ID="chkDay25" runat="server" CssClass="checktable" />
                                <asp:CheckBox ID="chkDay26" runat="server" CssClass="checktable" />
                                <asp:CheckBox ID="chkDay27" runat="server" CssClass="checktable" />
                                <asp:CheckBox ID="chkDay28" runat="server" CssClass="checktable" />
                                <asp:CheckBox ID="chkDay29" runat="server" CssClass="checktable" />
                                <asp:CheckBox ID="chkDay30" runat="server" CssClass="checktable" />
                                <asp:CheckBox ID="chkDay31" runat="server" CssClass="checktable" />
                            </td>
                        </tr> 
                        <tr>
                            <td></td> 
                            <td></td> 
                            <td>
                                <asp:TextBox ID="txtDay1" runat="server" Visible="false" Width="10px"></asp:TextBox>
                                <asp:TextBox ID="txtDay2" runat="server" Visible="false" Width="10px"></asp:TextBox>
                                <asp:TextBox ID="txtDay3" runat="server" Visible="false" Width="10px"></asp:TextBox>
                                <asp:TextBox ID="txtDay4" runat="server" Visible="false" Width="10px"></asp:TextBox>
                                <asp:TextBox ID="txtDay5" runat="server" Visible="false" Width="10px"></asp:TextBox>
                                <asp:TextBox ID="txtDay6" runat="server" Visible="false" Width="10px"></asp:TextBox>
                                <asp:TextBox ID="txtDay7" runat="server" Visible="false" Width="10px"></asp:TextBox>
                                <asp:TextBox ID="txtDay8" runat="server" Visible="false" Width="10px"></asp:TextBox>
                                <asp:TextBox ID="txtDay9" runat="server" Visible="false" Width="10px"></asp:TextBox>
                                <asp:TextBox ID="txtDay10" runat="server" Visible="false" Width="10px"></asp:TextBox>
                                <asp:TextBox ID="txtDay11" runat="server" Visible="false" Width="10px"></asp:TextBox>
                                <asp:TextBox ID="txtDay12" runat="server" Visible="false" Width="10px"></asp:TextBox>
                                <asp:TextBox ID="txtDay13" runat="server" Visible="false" Width="10px"></asp:TextBox>
                                <asp:TextBox ID="txtDay14" runat="server" Visible="false" Width="10px"></asp:TextBox>
                                <asp:TextBox ID="txtDay15" runat="server" Visible="false" Width="10px"></asp:TextBox>
                                <asp:TextBox ID="txtDay16" runat="server" Visible="false" Width="10px"></asp:TextBox>
                                <asp:TextBox ID="txtDay17" runat="server" Visible="false" Width="10px"></asp:TextBox>
                                <asp:TextBox ID="txtDay18" runat="server" Visible="false" Width="10px"></asp:TextBox>
                                <asp:TextBox ID="txtDay19" runat="server" Visible="false" Width="10px"></asp:TextBox>
                                <asp:TextBox ID="txtDay20" runat="server" Visible="false" Width="10px"></asp:TextBox>
                                <asp:TextBox ID="txtDay21" runat="server" Visible="false" Width="10px"></asp:TextBox>
                                <asp:TextBox ID="txtDay22" runat="server" Visible="false" Width="10px"></asp:TextBox>
                                <asp:TextBox ID="txtDay23" runat="server" Visible="false" Width="10px"></asp:TextBox>
                                <asp:TextBox ID="txtDay24" runat="server" Visible="false" Width="10px"></asp:TextBox>
                                <asp:TextBox ID="txtDay25" runat="server" Visible="false" Width="10px"></asp:TextBox>
                                <asp:TextBox ID="txtDay26" runat="server" Visible="false" Width="10px"></asp:TextBox>
                                <asp:TextBox ID="txtDay27" runat="server" Visible="false" Width="10px"></asp:TextBox>
                                <asp:TextBox ID="txtDay28" runat="server" Visible="false" Width="10px"></asp:TextBox>
                                <asp:TextBox ID="txtDay29" runat="server" Visible="false" Width="10px"></asp:TextBox>
                                <asp:TextBox ID="txtDay30" runat="server" Visible="false" Width="10px"></asp:TextBox>
                                <asp:TextBox ID="txtDay31" runat="server" Visible="false" Width="10px"></asp:TextBox>
                            </td> 
                        </tr> 
                    </table>
                </td>
            </tr>
            <tr style="height:24px">
                <td style="width:120px; padding-right:10px; text-align:right"></td>
                <td style="width: 500px">
                    <table border="0" cellpadding="0" cellspacing="0" width="500">
                        <tr style="height:25px">
                            <td style="width:208px" class="subheadertext" align="center">รายการอาหารในเมนู</td>
                            <td style="width:84px"></td>
                            <td align="center" style="width:208px" class="subheadertext">รายการอาหารทั้งหมด</td>
                        </tr> 
                    </table>
                </td>
                <td class="subheadertext" style="width:280px;" align="center">สารอาหารที่ได้รับ</td>
            </tr>
            <tr>
                <td style="width:150px; padding-right:10px; text-align:right; vertical-align:top;">
                    ข้าวหรืออาหารจานเดียว</td>
                <td style="width: 500px">
                    <uc1:MenuBoxControl ID="ctlMenuRice" runat="server" />
                </td>
                <td rowspan="6" style="border-right: 1px solid; padding-right: 4px; border-top: 1px solid;
                    padding-left: 4px; padding-bottom: 4px; border-left: 1px solid;
                    padding-top: 4px; border-bottom: 1px solid; background-color: #f8f8ff" valign="top">
                    <asp:GridView ID="gvStdMenuItemNutrient" runat="server" AutoGenerateColumns="False" CssClass="t_tablestyle" DataSourceID="StdMenuNutrientSource" Width="100%" >
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
                                <ItemStyle HorizontalAlign="Center" Width="120px" />
                                <HeaderStyle Width="120px" />
                            </asp:TemplateField> 
                        </Columns>
                        <HeaderStyle CssClass="t_headtext" />
                        <AlternatingRowStyle CssClass="t_alt_bg" />
                        <PagerSettings Visible="False" />
                    </asp:GridView>
                    <asp:ObjectDataSource ID="StdMenuNutrientSource" runat="server" SelectMethod="GeStdMenuNutrientList"
                        TypeName="StandardMenuDetailItem">
                        <SelectParameters>
                            <asp:ControlParameter ControlID="txtStdMenuID" DefaultValue="0" Name="stdMenuID"
                                PropertyName="Text" Type="Double" />
                            <asp:ControlParameter ControlID="txtMeal" DefaultValue="" Name="meal" PropertyName="Text"
                                Type="String" />
                            <asp:ControlParameter ControlID="txtCurrentDay" DefaultValue="" Name="menuDate" PropertyName="Text"
                                Type="Double" />
                        </SelectParameters>
                    </asp:ObjectDataSource>
                </td>
            </tr>
            <tr>
                <td style="width:150px; padding-right:10px; text-align:right; vertical-align:top;">
                    กับข้าว</td>
                <td style="width: 500px">
                    <uc1:MenuBoxControl ID="ctlMenuSavory" runat="server" /></td>
            </tr>
            <tr>
                <td style="width:150px; padding-right:10px; text-align:right; vertical-align:top;">
                    ผลไม้หรือของหวาน</td>
                <td style="width: 500px">
                    <uc1:MenuBoxControl ID="ctlMenuFruits" runat="server" /></td>
            </tr>
            <tr>
                <td style="width:150px; padding-right:10px; text-align:right; vertical-align:top;">
                    เครื่องดื่ม</td>
                <td style="width: 500px">
                    <uc1:MenuBoxControl ID="ctlMenuDrinks" runat="server" /></td>
            </tr>
            <tr>
                <td colspan="2"><hr style="size:1px" /></td> 
            </tr> 
            <tr style="height:24px">
                <td style="padding-right: 10px; width: 150px; text-align: right">
                    พลังงานรวม :</td>
                <td style="width: 500px">
                    <asp:TextBox ID="txtEnergy" runat="server" CssClass="zTextboxR-View" ReadOnly="true" Width="100px"></asp:TextBox>
                    kcal</td>
            </tr>
        </table>
    </ContentTemplate>
    <Triggers>
        <asp:AsyncPostBackTrigger ControlID="lnkDay1" EventName="Click" />
        <asp:AsyncPostBackTrigger ControlID="lnkDay2" EventName="Click" />
        <asp:AsyncPostBackTrigger ControlID="lnkDay3" EventName="Click" />
        <asp:AsyncPostBackTrigger ControlID="lnkDay4" EventName="Click" />
        <asp:AsyncPostBackTrigger ControlID="lnkDay5" EventName="Click" />
        <asp:AsyncPostBackTrigger ControlID="lnkDay6" EventName="Click" />
        <asp:AsyncPostBackTrigger ControlID="lnkDay7" EventName="Click" />
        <asp:AsyncPostBackTrigger ControlID="lnkDay8" EventName="Click" />
        <asp:AsyncPostBackTrigger ControlID="lnkDay9" EventName="Click" />
        <asp:AsyncPostBackTrigger ControlID="lnkDay10" EventName="Click" />
        <asp:AsyncPostBackTrigger ControlID="lnkDay11" EventName="Click" />
        <asp:AsyncPostBackTrigger ControlID="lnkDay12" EventName="Click" />
        <asp:AsyncPostBackTrigger ControlID="lnkDay13" EventName="Click" />
        <asp:AsyncPostBackTrigger ControlID="lnkDay14" EventName="Click" />
        <asp:AsyncPostBackTrigger ControlID="lnkDay15" EventName="Click" />
        <asp:AsyncPostBackTrigger ControlID="lnkDay16" EventName="Click" />
        <asp:AsyncPostBackTrigger ControlID="lnkDay17" EventName="Click" />
        <asp:AsyncPostBackTrigger ControlID="lnkDay18" EventName="Click" />
        <asp:AsyncPostBackTrigger ControlID="lnkDay19" EventName="Click" />
        <asp:AsyncPostBackTrigger ControlID="lnkDay20" EventName="Click" />
        <asp:AsyncPostBackTrigger ControlID="lnkDay21" EventName="Click" />
        <asp:AsyncPostBackTrigger ControlID="lnkDay22" EventName="Click" />
        <asp:AsyncPostBackTrigger ControlID="lnkDay23" EventName="Click" />
        <asp:AsyncPostBackTrigger ControlID="lnkDay24" EventName="Click" />
        <asp:AsyncPostBackTrigger ControlID="lnkDay25" EventName="Click" />
        <asp:AsyncPostBackTrigger ControlID="lnkDay26" EventName="Click" />
        <asp:AsyncPostBackTrigger ControlID="lnkDay27" EventName="Click" />
        <asp:AsyncPostBackTrigger ControlID="lnkDay28" EventName="Click" />
        <asp:AsyncPostBackTrigger ControlID="lnkDay29" EventName="Click" />
        <asp:AsyncPostBackTrigger ControlID="lnkDay30" EventName="Click" />
        <asp:AsyncPostBackTrigger ControlID="lnkDay31" EventName="Click" />
    </Triggers>
</asp:UpdatePanel>
