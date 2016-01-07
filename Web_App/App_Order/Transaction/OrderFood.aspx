<%@ Page Language="C#" MasterPageFile="~/Templates/Page1.master" AutoEventWireup="true" CodeFile="OrderFood.aspx.cs" Inherits="App_Order_Transaction_OrderFood" Title="SHND : Transaction - Food Order for Patient" %>
<%@ Register Src="OrderFood/OrderNPOControl.ascx" TagName="OrderNPOControl" TagPrefix="uc7" %>
<%@ Register Src="OrderFood/OrderNonMedicalControl.ascx" TagName="OrderNonMedicalControl" TagPrefix="uc8" %>
<%@ Register Src="OrderFood/OrderMedicalControl.ascx" TagName="OrderMedicalControl" TagPrefix="uc5" %>
<%@ Register Src="OrderFood/OrderMilkControl.ascx" TagName="OrderMilkControl" TagPrefix="uc6" %>
<%@ Register Src="OrderFood/OrderFeedControl.ascx" TagName="OrderFeedControl" TagPrefix="uc4" %>
<%@ Register Src="../../Templates/PageControl.ascx" TagName="PageControl" TagPrefix="uc3" %>
<%@ Register Src="../../Templates/CalendarControl.ascx" TagName="CalendarControl" TagPrefix="uc2" %>
<%@ Register Src="../../Templates/ToolBarItemCtl.ascx" TagName="ToolBarItemCtl" TagPrefix="uc1" %>
<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" Runat="Server">
    <table border="0" cellpadding="0" cellspacing="0" width="100%">
        <tr>
            <td class="headtext">
                สั่งอาหารผู้ป่วย</td>
        </tr>
        <tr>
            <td>
                <uc1:ToolBarItemCtl ID="tbBack" runat="server" ToobarTitle="กลับหน้ารายการ" ToolbarImage="../../Images/icn_back.png" OnClick="tbBackClick" />
            </td>
        </tr>
        <tr>
            <td style="height:30px" valign="top">
                <hr style="size:1px" />
                <asp:Label ID="lbStatus" runat="server" EnableViewState="False"></asp:Label>
                <asp:TextBox ID="txtLOID" runat="server" CssClass="zHidden" Width="50px"></asp:TextBox>
                <asp:TextBox ID="txtWard" runat="server" CssClass="zHidden" Width="50px"></asp:TextBox>
                <asp:TextBox ID="txtPatientStatus" runat="server" CssClass="zHidden" Width="50px"></asp:TextBox>
            </td>
        </tr>
        <tr>
            <td>
                <table border="0" cellpadding="0" cellspacing="0" width="100%">
                    <tr style="height: 10px">
                        <td style="padding-right: 10px; width: 115px">&nbsp;</td>
                        <td style="padding-right: 10px; width: 545px">&nbsp;</td>
                        <td style="width:4px">&nbsp;</td>
                        <td>&nbsp;</td>
                    </tr>
                    <tr>
                        <td colspan="2" style="padding:5px; border-right: 1px solid; border-top: 1px solid; border-left: 1px solid; border-bottom: 1px solid;" valign="top">
                            <table border="0" cellpadding="0" cellspacing="0" width="660">
                                <tr style="height:24px">
                                    <td style="width:115px; padding-right:10px; height: 24px;" align="right">
                                        Encounter หรือ AN :</td> 
                                    <td style="width:120px; height: 24px;">
                                        <asp:TextBox ID="txtAN" runat="server" CssClass="zTextbox-View" ReadOnly="True" Width="100px"></asp:TextBox>
                                    </td> 
                                    <td style="width:50px; padding-right:10px; height: 24px;" align="right">
                                        HN :</td>
                                    <td colspan="2" style="height: 24px">
                                        <asp:TextBox ID="txtHN" runat="server" CssClass="zTextbox-View" ReadOnly="True" Width="100px"></asp:TextBox>
                                    </td>
                                    <td align="right" style="padding-right: 10px; width: 80px">วันที่ Admit :
                                    </td>
                                    <td colspan="2">
                                        <uc2:CalendarControl ID="ctlAdmitDate" runat="server" Enabled="false" />
                                    </td>
                                </tr>
                                <tr style="height: 24px">
                                    <td align="right" style="padding-right: 10px; width: 115px">
                                        ชื่อ :</td>
                                    <td colspan="7">
                                        <asp:TextBox ID="txtPatientName" runat="server" CssClass="zTextbox-View" ReadOnly="True" Width="525px"></asp:TextBox>
                                    </td>
                                </tr>
                                <tr style="height: 24px">
                                    <td align="right" style="padding-right: 10px; width: 115px">
                                        หอผู้ป่วย :</td>
                                    <td style="width: 120px">
                                        <asp:TextBox ID="txtWardName" runat="server" CssClass="zTextbox-View" ReadOnly="True" Width="120px"></asp:TextBox>
                                    </td>
                                    <td align="right" style="padding-right: 10px; width: 50px">
                                        ห้อง :</td>
                                    <td style="width: 50px">
                                        <asp:TextBox ID="txtRoomNo" runat="server" CssClass="zTextbox-View" ReadOnly="True" Width="50px"></asp:TextBox>
                                    </td>
                                    <td align="right" style="padding-right: 10px; width: 50px">
                                        เตียง :</td>
                                    <td style="width: 80px">
                                        <asp:TextBox ID="txtBedNo" runat="server" CssClass="zTextbox-View" ReadOnly="True" Width="50px"></asp:TextBox>
                                    </td>
                                    <td align="right" style="padding-right: 10px; width: 50px">
                                    </td>
                                    <td>
                                    </td>
                                </tr>
                                <tr style="height: 24px">
                                    <td align="right" style="padding-right: 10px; width: 115px">
                                        วันเกิด :</td>
                                    <td style="width: 120px">
                                        <uc2:CalendarControl ID="ctlBirthDate" runat="server" Enabled="false" />
                                    </td>
                                    <td align="right" style="padding-right: 10px; width: 50px">
                                        อายุ :</td>
                                    <td style="width: 50px">
                                        <asp:TextBox ID="txtAge" runat="server" CssClass="zTextbox-View" ReadOnly="True" Width="50px"></asp:TextBox>
                                    </td>
                                    <td align="right" style="padding-right: 10px; width: 50px">
                                        น้ำหนัก :</td>
                                    <td style="width: 80px">
                                        <asp:TextBox ID="txtWeight" runat="server" CssClass="zTextboxR-View" ReadOnly="True" Width="50px"></asp:TextBox> กก.
                                    </td>
                                    <td align="right" style="padding-right: 10px; width: 50px">
                                        ส่วนสูง :</td>
                                    <td>
                                        <asp:TextBox ID="txtHeight" runat="server" CssClass="zTextboxR-View" ReadOnly="True" Width="50px"></asp:TextBox> ซม.
                                    </td>
                                </tr>
                                <tr style="height: 24px">
                                    <td align="right" style="padding-right: 10px; width: 115px">
                                        โรค :</td>
                                    <td colspan="7">
                                        <asp:TextBox ID="txtDiagnosis" runat="server" CssClass="zTextbox-View" ReadOnly="True" Width="525px"></asp:TextBox>
                                    </td>
                                </tr>

                            </table>
                        </td>
                        <td style="width:4px">&nbsp;</td>
                        <td style="border-right: 1px solid; border-top: 1px solid; border-left: 1px solid; border-bottom: 1px solid;" valign="top" align="left">
                            <table border="0" cellpadding="0" cellspacing="0" width="100%">
                                <tr>
                                    <td style="border-bottom: 1px solid; padding:5px;">
                                        <table border="0" cellpadding="0" cellspacing="0" width="300px">
                                            <tr style="height:24px">
                                                <td style="width:120px; padding-right:10px; text-align:right">สถานะการสั่งอาหาร :
                                                </td> 
                                                <td>
                                                    <asp:TextBox ID="txtStatusName" runat="server" CssClass="zTextbox-View" ReadOnly="True" Width="150px"></asp:TextBox>
                                                </td> 
                                            </tr>
                                        </table>
                                    </td> 
                                </tr>
                                <tr>
                                    <td style="padding:5px;">
                                        <table border="0" cellpadding="0" cellspacing="0" width="300px">
                                            <tr style="height:24px">
                                                <td style="width:120px; padding-right:10px; text-align:right">สถานะการบันทึกข้อมูล :
                                                </td> 
                                                <td>
                                                    <asp:TextBox ID="txtDataStatus" runat="server" CssClass="zTextbox-View" ReadOnly="True" Width="150px"></asp:TextBox>
                                                </td> 
                                            </tr>
                                        </table>
                                    </td> 
                                </tr>
                            </table>
                        </td>
                    </tr> 
                    <tr style="height: 24px">
                        <td align="right" style="padding-right: 10px; width: 115px">
                            การแพ้ :</td>
                        <td colspan="3">
                            <asp:Label ID="txtAllergic" runat="server" CssClass="zTextbox-View" ReadOnly="True" Width="100%"></asp:Label>
                        </td>
                    </tr>
                </table> 
            </td>
        </tr>
        <tr>
            <td style="height:3px"></td>
        </tr>
        <tr>
            <td class="toolbarplace">
                <table border="0" cellpadding="0" cellspacing="0" width="100%">
                    <tr>
                        <td style="width:600px" >
                            <asp:Panel id="pnlDoctor" runat="server">
                                สั่งอาหารโดยแพทย์  ชนิดอาหาร : <asp:DropDownList ID="cmbFoodCategory" runat="server" CssClass="zComboBox" Width="150px"></asp:DropDownList>
                                <uc1:ToolBarItemCtl ID="tbOrderDoctor" runat="server" ToobarTitle="รายละเอียด" ToolbarImage="../../Images/icn_add.png" OnClick="tbOrderDoctorClick" />
                                &nbsp;&nbsp
                            </asp:Panel> 
                        </td>
                        <td></td>
                        <td style="width:600px" >
                            <asp:Panel id="pnlNurse" runat="server">
                                สั่งอาหารโดยพยาบาล  ประเภทอาหาร : <asp:DropDownList ID="cmbFoodType" runat="server" CssClass="zComboBox" Width="150px"></asp:DropDownList>
                                <uc1:ToolBarItemCtl ID="tbOrderNurse" runat="server" ToobarTitle="รายละเอียด" ToolbarImage="../../Images/icn_add.png" OnClick="tbOrderNurseClick" /> 
                            </asp:Panel> 
                        </td>
                    </tr> 
                </table> 
            </td>
        </tr>
        <tr>
            <td style="width:650px">
                <uc3:PageControl ID="pcTop" runat="server" OnPageChange="PageChange" Visible="false"/>
                <asp:GridView ID="gvMain" runat="server" AutoGenerateColumns="False" CssClass="t_tablestyle" OnRowDataBound="gvMain_RowDataBound">
                    <Columns>
                        <asp:BoundField DataField="LOID" HeaderText="LOID">
                            <ControlStyle CssClass="zHidden" />
                            <FooterStyle CssClass="zHidden" />
                            <HeaderStyle CssClass="zHidden" />
                            <ItemStyle CssClass="zHidden" />
                        </asp:BoundField>
                        <asp:TemplateField>
                            <ItemTemplate>
                                <asp:ImageButton ID="imbDelete" runat="server" ImageUrl="~/Images/icn_delete.png" ToolTip="ลบรายการ" 
                                    CommandArgument='<%# Bind("LOID") %>' OnClick="imbDelete_Click" />
                                <asp:ImageButton ID="imbCopy" runat="server" ImageUrl="~/Images/icn_copy.png" ToolTip="คัดลอกข้อมูล" 
                                    CommandArgument='<%# Bind("LOID") %>' OnClick="imbCopy_Click" />
                            </ItemTemplate>
                            <HeaderStyle HorizontalAlign="Center" Width="60px" />
                            <ItemStyle HorizontalAlign="Center" Width="60px" />
                        </asp:TemplateField>
                        <asp:TemplateField HeaderText="ลำดับ" SortExpression="DEFAULT">
                            <HeaderStyle Width="60px" />
                            <ItemStyle HorizontalAlign="Center" Width="60px" Height="20px" />
                        </asp:TemplateField>
                        <asp:TemplateField HeaderText="วันที่เริ่ม" SortExpression="FIRSTDATE">
                            <ItemTemplate>
                                <asp:LinkButton ID="lnkDate" runat="server" Text='<%# Eval("FIRSTDATE").ToString() == "" ? "-" :Convert.ToDateTime(Eval("FIRSTDATE")).ToString("dd/MM/yyyy") %>' OnClick="lnkDate_Click" CommandArgument='<%# Bind("LOID")  %>'></asp:LinkButton>
                            </ItemTemplate>
                            <HeaderStyle Width="100px" />
                            <ItemStyle HorizontalAlign="Center" Width="100px" />
                        </asp:TemplateField>
                        <asp:BoundField DataField="CATEGORYNAME" HeaderText="รายการ" SortExpression="CATEGORYNAME">
                        </asp:BoundField>
                        <asp:BoundField DataField="STATUSNAME" HeaderText="สถานะ" SortExpression="STATUSNAME">
                            <HeaderStyle HorizontalAlign="Center" Width="100px" />
                            <ItemStyle Width="100px" />
                        </asp:BoundField>
                        <asp:BoundField DataField="WHO" HeaderText="ผู้สั่ง" SortExpression="WHO">
                            <HeaderStyle HorizontalAlign="Center" Width="100px" />
                            <ItemStyle Width="100px" />
                        </asp:BoundField>
                        <asp:BoundField DataField="REFTABLE" HeaderText="REFTABLE">
                            <ControlStyle CssClass="zHidden" />
                            <FooterStyle CssClass="zHidden" />
                            <HeaderStyle CssClass="zHidden" />
                            <ItemStyle CssClass="zHidden" />
                        </asp:BoundField>
                        <asp:BoundField DataField="ISNPO" HeaderText="ISNPO">
                            <ControlStyle CssClass="zHidden" />
                            <FooterStyle CssClass="zHidden" />
                            <HeaderStyle CssClass="zHidden" />
                            <ItemStyle CssClass="zHidden" />
                        </asp:BoundField>
                        <asp:BoundField DataField="ISDOCTORORDER" HeaderText="ISDOCTORORDER">
                            <ControlStyle CssClass="zHidden" />
                            <FooterStyle CssClass="zHidden" />
                            <HeaderStyle CssClass="zHidden" />
                            <ItemStyle CssClass="zHidden" />
                        </asp:BoundField>
                        <asp:BoundField DataField="STATUS" HeaderText="STATUS">
                            <ControlStyle CssClass="zHidden" />
                            <FooterStyle CssClass="zHidden" />
                            <HeaderStyle CssClass="zHidden" />
                            <ItemStyle CssClass="zHidden" />
                        </asp:BoundField>
                        <asp:TemplateField HeaderText="">
                            <ItemTemplate>
                                <asp:LinkButton ID="lnkNurse" runat="server" Text="เพิ่มรายละเอียด" Visible='<%# Eval("REFTABLE").ToString() =="ORDERMILK" %>' OnClick="lnkNurse_Click" CommandArgument='<%# Bind("LOID")  %>'></asp:LinkButton>
                            </ItemTemplate>
                            <HeaderStyle Width="100px" />
                            <ItemStyle HorizontalAlign="Center" Width="100px" />
                        </asp:TemplateField>
                    </Columns>
                    <HeaderStyle CssClass="t_headtext" />
                    <AlternatingRowStyle CssClass="t_alt_bg" />
                    <PagerSettings Visible="False" />
                </asp:GridView>
                <uc3:PageControl ID="pcBot" runat="server" OnPageChange="PageChange" Visible="false"/>
            </td>
        </tr>
    </table>  
    <uc4:OrderFeedControl ID="ctlOrderFeed" runat="server" OnSaveClick="ctlOrderSaveClick" />
    <uc5:OrderMedicalControl ID="ctlOrderMedical" runat="server" OnSaveClick="ctlOrderSaveClick" />
    <uc6:OrderMilkControl ID="CtlOrderMilk" runat="server" OnSaveClick="ctlOrderSaveClick" />
    <uc7:OrderNPOControl ID="CtlOrderNPO" runat="server" OnSaveClick="ctlOrderSaveClick" />
    <uc8:OrderNonMedicalControl ID="CtlOrderNonMedical" runat="server" OnSaveClick="ctlOrderSaveClick" />
</asp:Content>