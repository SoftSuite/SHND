<%@ Page Language="C#" MasterPageFile="~/Templates/Page1.master" AutoEventWireup="true" CodeFile="PlanOrderFoodDivision.aspx.cs" Inherits="App_Plan_Transaction_PlanOrderFoodDivision" Title="SHND : Transaction - Food Order Planning" %>
<%@ Register Src="../../Templates/CalendarControl.ascx" TagName="CalendarControl" TagPrefix="uc2" %>
<%@ Register Src="../../Templates/ToolBarItemCtl.ascx" TagName="ToolBarItemCtl" TagPrefix="uc1" %>
<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="cc1" %>
<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" Runat="Server">
    <table border="0" cellpadding="0" cellspacing="0" width="100%">
        <tr>
            <td class="headtext">ข้อมูลแผนประมาณการวัสดุอาหาร</td>
        </tr>
        <tr>
            <td>
                <uc1:ToolBarItemCtl ID="tbSave" runat="server" ToobarTitle="บันทึกข้อมูล" ToolbarImage="../../Images/save2.png" OnClick="tbSaveClick" />
                <uc1:ToolBarItemCtl ID="tbCancel" runat="server" ToobarTitle="ยกเลิกการแก้ไข" ToolbarImage="../../Images/cancel.png" OnClick="tbCancelClick" />
                <uc1:ToolBarItemCtl ID="tbBack" runat="server" ToobarTitle="กลับหน้ารายการ" ToolbarImage="../../Images/icn_back.png" OnClick="tbBackClick" />
                <uc1:ToolBarItemCtl ID="tbSend" runat="server" ToobarTitle="ส่งให้ธุรการ" ToolbarImage="../../Images/icn_approve.png" OnClick="tbSendClick" />
                <uc1:ToolBarItemCtl ID="tbCalculate" runat="server" ToobarTitle="คำนวณยอดประมาณการใช้วัสดุอาหาร" ToolbarImage="../../Images/icn_calculate.png" OnClick="tbCalculateClick" />
            </td>
        </tr>
        <tr>
            <td style="height:30px">
                <hr style="size:1px" />
                <asp:Label ID="lbStatus" runat="server" EnableViewState="False"></asp:Label>
                <asp:TextBox ID="txtStatus" runat="server" CssClass="zHidden" Width="50px"></asp:TextBox>
                <asp:TextBox ID="txtLOID" runat="server" CssClass="zHidden" Width="50px"></asp:TextBox>
            </td>
        </tr>
        <tr>
            <td>
                <table border="0" cellpadding="0" cellspacing="0" width="100%">
                    <tr>
                        <td style="padding:5px; border-right: 1px solid; border-top: 1px solid; border-left: 1px solid; border-bottom: 1px solid; width:400px" valign="top">
                            <table border="0" cellpadding="0" cellspacing="0" width="520">
                                <tr style="height:24px">
                                    <td style="width:130px; padding-right:10px; text-align:right">
                                        เลขที่แผนประมาณการ :</td>
                                    <td style="width:150px">
                                        <asp:TextBox ID="txtCode" runat="server" CssClass="zTextbox-View" ReadOnly="True" Width="100px"></asp:TextBox></td>
                                    <td style="width:90px"></td>
                                    <td></td>  
                                </tr>
                                <tr style="height: 24px">
                                    <td style="padding-right: 10px; width: 130px; height: 24px; text-align: right">
                                        ชื่อแผนประมาณการ :</td>
                                    <td colspan="3" style="height: 24px">
                                        <asp:TextBox ID="txtName" runat="server" CssClass="zTextbox-View" Width="350px" MaxLength="100" ReadOnly="true"></asp:TextBox></td>
                                </tr>
                                <tr style="height: 24px">
                                    <td style="padding-right: 10px; width: 130px; text-align: right">
                                        งวดที่ :</td>
                                    <td style="width: 150px;">
                                        <asp:TextBox ID="txtPhase" runat="server" CssClass="zTextboxR-View" Width="100px" MaxLength="2" ReadOnly="true"></asp:TextBox></td>
                                    <td style="width: 90px; padding-right: 10px; text-align: right">
                                        ปีงบประมาณ :</td>
                                    <td>
                                        <asp:TextBox ID="txtBudgetYear" runat="server" CssClass="zTextboxR-View" Width="100px" MaxLength="4" ReadOnly="true"></asp:TextBox></td>
                                </tr>
                                <tr style="height: 24px">
                                    <td style="padding-right: 10px; width: 130px; text-align: right">
                                        ช่วงเวลา :</td>
                                    <td style="width: 150px">
                                        <uc2:CalendarControl ID="ctlStartDate" runat="server" Enabled="false" />
                                    </td>
                                    <td style="width: 90px" align="center">
                                        ถึง</td>
                                    <td>
                                        <uc2:CalendarControl ID="ctlEndDate" runat="server" Enabled="false" />
                                    </td>
                                </tr>
                            </table>
                        </td>
                        <td style="width:4px">&nbsp;</td>
                        <td style="border-right: 1px solid; border-top: 1px solid; border-left: 1px solid; border-bottom: 1px solid;" valign="top">
                            <table border="0" cellpadding="0" cellspacing="0" width="100%">
                                <tr>
                                    <td style="border-bottom: 1px solid; padding-right: 5px; padding-left: 5px; padding-bottom: 5px; padding-top: 5px;">
                                        <table border="0" cellpadding="0" cellspacing="0" width="280px" >
                                            <tr style="padding:5px;">
                                                <td style="padding-right:10px; width:80px; text-align:right">สถานะ :</td>
                                                <td><asp:TextBox ID="txtStatusName" runat="server" CssClass="zTextbox-View" ReadOnly="True" Width="150px"></asp:TextBox></td>
                                            </tr> 
                                        </table>
                                    </td> 
                                </tr>
                                <tr>
                                    <td style="padding-right: 5px; padding-left: 5px; padding-bottom: 5px; padding-top: 5px">
                                        <table border="0" cellpadding="0" cellspacing="0" width="280px">
                                            <tr style="padding:5px">
                                                <td style="padding-right:10px; width:80px; text-align:right">หน่วยงาน :</td>
                                                <td><asp:TextBox ID="txtDivisionName" runat="server" CssClass="zTextbox-View" ReadOnly="True" Width="150px"></asp:TextBox></td>
                                            </tr> 
                                        </table>
                                    </td> 
                                </tr>
                            </table>
                        </td>
                    </tr> 
                </table> 
            </td>
        </tr>
        <tr>
            <td style="height:3px"></td>
        </tr>
        <tr>
            <td style="border-right: 1px solid; border-top: 1px solid; border-left: 1px solid; border-bottom: 1px solid;">
                <table border="0" cellpadding="0" cellspacing="0" width="800px">
                    <tr>
                        <td style="padding:5px">
                            <asp:GridView ID="gvMenu" runat="server" AutoGenerateColumns="False" CssClass="t_tablestyle" ShowFooter="true" Width="400px">
                                <Columns>
                                    <asp:TemplateField HeaderText="ชื่อเมนู">
                                        <ItemTemplate>
                                            <%# Eval("MENUNAME") %>
                                        </ItemTemplate>
                                        <FooterTemplate>
                                            <b>รวม</b>
                                        </FooterTemplate>
                                        <FooterStyle HorizontalAlign="center" />
                                    </asp:TemplateField>
                                    <asp:TemplateField HeaderText="จำนวนคนตามเมนู">
                                        <ItemTemplate>
                                            <%# Convert.ToDouble(Eval("PORTION")).ToString("#,##0") %>
                                        </ItemTemplate>
                                        <FooterTemplate>
                                            <b><asp:Label ID="lblTotal" runat="server" ></asp:Label></b>
                                        </FooterTemplate>
                                        <HeaderStyle Width="120px" />
                                        <ItemStyle Width="120px" HorizontalAlign="right" Height="24px"/>
                                        <FooterStyle Width="120px" HorizontalAlign="right" Height="24px"/>
                                    </asp:TemplateField>
                                </Columns>
                                <HeaderStyle CssClass="t_headtext" />
                                <AlternatingRowStyle CssClass="t_alt_bg" />
                                <FooterStyle CssClass="t_alt_bg" />
                                <PagerSettings Visible="False" />
                            </asp:GridView>
                        </td>
                    </tr> 
                </table> 
            </td>
        </tr>
        <tr>
            <td>
                <asp:GridView ID="gvMaterial" runat="server" AutoGenerateColumns="False" CssClass="t_tablestyle">
                    <Columns>
                        <asp:BoundField DataField="LOID" HeaderText="LOID">
                            <ControlStyle CssClass="zHidden" />
                            <FooterStyle CssClass="zHidden" />
                            <HeaderStyle CssClass="zHidden" />
                            <ItemStyle CssClass="zHidden" />
                        </asp:BoundField>
                        <asp:TemplateField HeaderText="ลำดับ">
                            <ItemTemplate>
                                <%# Container.DataItemIndex +1 %>
                            </ItemTemplate>
                            <HeaderStyle Width="50px" />
                            <ItemStyle HorizontalAlign="Center" Width="50px" Height="24px" />
                        </asp:TemplateField>
                        <asp:TemplateField HeaderText="รหัส SAP">
                            <ItemTemplate>
                                <asp:LinkButton ID="lnkCode" runat="server" Text='<%# Eval("SAPCODE").ToString() == "" ? "-" : Eval("SAPCODE") %>' CommandArgument='<%# Bind("LOID") %>' OnClick="lnkCode_Click"></asp:LinkButton> 
                            </ItemTemplate>
                            <ItemStyle Width="80px" HorizontalAlign="Center" />
                            <HeaderStyle Width="80px" />  
                        </asp:TemplateField>
                        <asp:BoundField DataField="MATERIALNAME" HeaderText="รายการ">
                            <ItemStyle Width="200px" />
                            <HeaderStyle Width="200px" /> 
                        </asp:BoundField>
                        <asp:BoundField DataField="UNITNAME" HeaderText="หน่วยนับ">
                            <ItemStyle Width="70px" />
                            <HeaderStyle Width="70px" /> 
                        </asp:BoundField>
                        <asp:BoundField DataField="CLASSNAME" HeaderText="หมวดหมู่วัสดุ">
                            <ItemStyle Width="150px" />
                            <HeaderStyle Width="150px" />
                        </asp:BoundField>
                        <asp:BoundField DataField="MENUQTY" HeaderText="เมนู" HtmlEncode="False" DataFormatString="{0:#,##0.00}">
                            <ItemStyle Width="80px" HorizontalAlign="Right" />
                            <HeaderStyle Width="80px" />
                        </asp:BoundField>
                        <asp:TemplateField HeaderText="ประมาณการ">
                            <ItemTemplate>
                                <asp:TextBox ID="txtReqQty" runat="server" Width="95px" Text='<%# Convert.ToDouble(Eval("REQQTY")).ToString("#,##0.00") %>' 
                                    CssClass='<%# Convert.ToString(Eval("PDSTATUS")) == "CO" ? "zTextboxR" : "zTextboxR-View" %>' 
                                    ReadOnly='<%# Convert.ToString(Eval("PDSTATUS")) != "CO" %>'
                                    onkeypress="ChkDbl(this)" onblur="valDbl(this)" onfocus="prepareNum(this)" ></asp:TextBox> 
                            </ItemTemplate>
                            <ItemStyle Width="100px" HorizontalAlign="Right" />
                            <HeaderStyle Width="100px" />  
                        </asp:TemplateField>
                        <asp:BoundField DataField="STATUSNAME" HeaderText="สถานะ">
                            <ItemStyle Width="120px"/>
                            <HeaderStyle Width="120px" />
                        </asp:BoundField>
                        <asp:BoundField DataField="SPEC" HeaderText="SPEC">
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
            </td>
        </tr>
    </table>  
    <cc1:ModalPopupExtender ID="ctlSpecPopup"  runat="server" PopupControlID="pnlSpec" BackgroundCssClass="modalBackground" DropShadow="true" TargetControlID="btnTest"></cc1:ModalPopupExtender>
    <asp:Panel ID="pnlSpec" runat="server" CssClass="modalPopup" style="display:none" >
        <table border="0" cellspacing="0" cellpadding="0" width="300px">
            <tr>
                <td class="subheadertext">
                    <asp:Label ID="lblMaterialName" runat="server" Text=""></asp:Label>
                </td>
            </tr>
            <tr>
                <td>
                    <uc1:ToolBarItemCtl ID="tbBackSpec" runat="server" ToobarTitle="กลับหน้ารายการ" ToolbarImage="../../Images/icn_back.png" />
                </td>
            </tr>
            <tr>
                <td><hr style="size:1px"/>
                </td>
            </tr>
            <tr>
                <td>
                    <asp:TextBox ID="txtSpec" runat="server" TextMode="MultiLine" Width="300px" Height="150px" MaxLength="200" CssClass="zTextbox-View" ReadOnly="true"></asp:TextBox>
                </td> 
            </tr>
        </table>
    </asp:Panel>
    <asp:Button ID="btntest" runat="server" Text="test" CssClass="zHidden" />
</asp:Content>