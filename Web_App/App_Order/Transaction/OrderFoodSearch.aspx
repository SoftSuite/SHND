<%@ Page Language="C#" MasterPageFile="~/Templates/Page1.master" AutoEventWireup="true" CodeFile="OrderFoodSearch.aspx.cs" Inherits="App_Order_Transaction_OrderFoodSearch" Title="SHND : Transaction - Food Order for Patient" %>
<%@ Register Src="../../Templates/CalendarControl.ascx" TagName="CalendarControl" TagPrefix="uc3" %>
<%@ Register Src="../../Templates/PageControl.ascx" TagName="PageControl" TagPrefix="uc2" %>
<%@ Register Src="../../Templates/ToolBarItemCtl.ascx" TagName="ToolBarItemCtl" TagPrefix="uc1" %>
<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" Runat="Server">
    <table border="0" cellpadding="0" cellspacing="0" width="100%">
        <tr>
            <td class="headtext">
                สั่งอาหารผู้ป่วย</td>
        </tr>
        <tr>
            <td style="height:15px">
            </td>
        </tr>
        <tr>
            <td>
                <fieldset style="padding:15px;">
                    <legend style="font-weight:bold">ค้นหา</legend>
                    <table border="0" cellspacing="0" cellpadding="0" width="900">
                        <tr style="height:15px">
                            <td colspan="5"></td>
                        </tr>
                        <tr style="height:24px">
                            <td style="padding-right:10px; width:130px; text-align:right">
                                หอผู้ป่วย :</td>
                            <td style="width:150px">
                                <asp:DropDownList ID="cmbSearchWard" runat="server" CssClass="zComboBox" Width="156px"></asp:DropDownList>
                                <asp:DropDownList ID="cmbWardDefault" runat="server" CssClass="zComboBox" Visible="false" Width="156px"></asp:DropDownList>
                            </td>
                            <td style="width:30px; text-align:center"></td>
                            <td colspan="2">
                                <asp:TextBox ID="txtSearchWardName" runat="server" Width="100px" MaxLength="20" Visible="false" CssClass="zTextbox"></asp:TextBox>
                                 
                            </td>
                        </tr>
                        <tr style="height:24px">
                            <td style="padding-right:10px; width:130px; text-align:right">
                                วันที่ Admit :</td>
                            <td style="width:150px">
                                <uc3:CalendarControl ID="ctlSearchAdmitDateFrom" runat="server" />
                            </td>
                            <td style="width:30px; text-align:center">
                                ถึง</td>
                            <td style="width:150px">
                                <uc3:CalendarControl ID="ctlSearchAdmitDateTo" runat="server" />
                            </td>
                            <td style="width:440px"></td>
                        </tr>

                        <tr style="height:24px">
                            <td style="padding-right:10px; width:130px; text-align:right">
                                Encounter หรือ AN :</td>
                            <td style="width:150px">
                                <asp:TextBox ID="txtSearchAN" runat="server" Width="100px" MaxLength="20" CssClass="zTextbox"></asp:TextBox>
                            </td>
                            <td style="width:30px; text-align:center">
                                HN :</td>
                            <td style="width:150px">
                                <asp:TextBox ID="txtSearchHN" runat="server" Width="100px" MaxLength="20" CssClass="zTextbox"></asp:TextBox>
                            </td>
                            <td style="width:30px; text-align:center">
                                <asp:CheckBox ID="chkIsAdmit" runat="server" Text="เฉพาะผู้ป่วยที่พักรักษาใน รพ." Visible="false" />
                            </td>
                        </tr>
                        <tr style="height: 24px">
                            <td style="padding-right: 10px; width: 130px; text-align: right">
                                ชื่อผู้ป่วย :</td>
                            <td colspan="3">
                                <asp:TextBox ID="txtSearchPatientName" runat="server" CssClass="zTextbox" MaxLength="20" Width="336px"></asp:TextBox></td>
                            <td>
                            </td>
                        </tr>
                        <tr style="height:24px">
                            <td style="padding-right:10px; width:130px; text-align:right">
                                สถานะการสั่งอาหาร :</td>
                            <td style="width:150px">
                                <asp:DropDownList ID="cmbSearchStatusFrom" runat="server" CssClass="zComboBox" Width="156px">
                                </asp:DropDownList></td>
                            <td style="width:30px; text-align:center">
                                ถึง</td>
                            <td style="width:150px">
                                <asp:DropDownList ID="cmbSearchStatusTo" runat="server" CssClass="zComboBox" Width="156px">
                                </asp:DropDownList></td>
                            <td>
                                &nbsp;&nbsp;
                                <asp:ImageButton ID="imbSearch" runat="server" ImageAlign="AbsMiddle" ImageUrl="~/Images/icn_find.png" OnClick="imbSearch_Click" />&nbsp;
                                <asp:ImageButton ID="imbReset" runat="server" Visible="false" ImageAlign="AbsMiddle" ImageUrl="~/Images/icn_back.png" ToolTip="แสดงทั้งหมด" OnClick="imbReset_Click" />&nbsp;
                                <asp:ImageButton ID="imbPrint" runat="server" ImageAlign="AbsMiddle" ImageUrl="~/Images/icn_print.png" ToolTip="พิมพ์" /></td>
                        </tr>
                    </table>
                </fieldset>
            </td>
        </tr>
        <tr>
            <td style="height:20px">
                <asp:TextBox ID="txhSortField" runat="server" Visible="False" Width="15px"></asp:TextBox>
                <asp:TextBox ID="txhSortDir" runat="server" Visible="False" Width="15px"></asp:TextBox>
                <asp:Label ID="lblRed" Width="137px" runat="server" Text="สีแดง คือ ยังไม่สั่งอาหาร" BackColor="Coral" Font-Bold="True"></asp:Label>
                <asp:Label ID="lblYellow" Width="231px" runat="server" Text="สีเหลือง คือ ข้อมูลการสั่งอาหารไม่สมบูรณ์" BackColor="Gold" Font-Bold="True"></asp:Label>
                <asp:Label ID="lblGreen" Width="185px" runat="server" Text="สีเขียว คือ สั่งอาหารเรียบร้อยแล้ว" BackColor="LightGreen" Font-Bold="True"></asp:Label>
                <asp:Label ID="lblWhite" Width="168px" runat="server" Text="สีขาว คือ Register อาหารแล้ว" BackColor="White" Font-Bold="True"></asp:Label>
                <asp:Label ID="lblNpo" Width="138px" runat="server" Text="NPO คือ งดน้ำ งดอาหาร" ForeColor="Red" BackColor="LightGreen" Font-Bold="True"></asp:Label>
                </td>
        </tr>
        <tr>
            <td style="100%">
                <uc2:PageControl ID="pcTop" runat="server" OnPageChange="PageChange"/>
                <asp:GridView ID="gvMain" runat="server" AllowSorting="True" AutoGenerateColumns="False" CssClass="t_tablestyle" OnRowDataBound="gvMain_RowDataBound" 
                    OnSorting="gvMain_Sorting" AllowPaging="True" PageSize="100" Width="100%">
                    <Columns>
                        <asp:BoundField DataField="LOID" HeaderText="LOID">
                            <ControlStyle CssClass="zHidden" />
                            <FooterStyle CssClass="zHidden" />
                            <HeaderStyle CssClass="zHidden" />
                            <ItemStyle CssClass="zHidden" />
                        </asp:BoundField>
                        <asp:BoundField DataField="REMARK" >
                            <HeaderStyle Width="30px" />
                            <ItemStyle HorizontalAlign="Center" Width="30px" CssClass="zRemark" />
                        </asp:BoundField>
                        <asp:TemplateField HeaderText="ลำดับ" SortExpression="DEFAULT">
                            <HeaderStyle CssClass="zHidden" Width="50px" />
                            <ItemStyle CssClass="zHidden" HorizontalAlign="Center" Width="50px" Height="20px" />
                        </asp:TemplateField>
                        <asp:BoundField DataField="ADMITDATE" HeaderText="วันที่ Admit" SortExpression="ADMITDATE" HtmlEncode="false" DataFormatString="{0:dd/MM/yyyy}">
                            <HeaderStyle Width="110px" />
                            <ItemStyle HorizontalAlign="Center" Width="110px" />
                        </asp:BoundField>
                        <asp:BoundField DataField="WARDNAME" HeaderText="หอผู้ป่วย" SortExpression="WARDNAME">
                            <HeaderStyle Width="120px" />
                            <ItemStyle Width="120px" />
                        </asp:BoundField>
                        <asp:BoundField DataField="ROOMNO" HeaderText="ห้อง" SortExpression="ROOMNO">
                            <HeaderStyle Width="50px" />
                            <ItemStyle HorizontalAlign="center" Width="50px" />
                        </asp:BoundField>
                        <asp:BoundField DataField="BEDNO" HeaderText="เตียง" SortExpression="BEDNO">
                            <HeaderStyle Width="50px" />
                            <ItemStyle HorizontalAlign="center" Width="50px" />
                        </asp:BoundField>
                        <asp:BoundField DataField="HN" HeaderText="HN" SortExpression="HN">
                            <HeaderStyle Width="70px" />
                            <ItemStyle HorizontalAlign="center" Width="70px" />
                        </asp:BoundField>
                        <asp:TemplateField HeaderText="Encounter<br>หรือ AN" SortExpression="AN">
                            <ItemTemplate>
                                <asp:LinkButton ID="lnkAN" runat="server" Text='<%# Bind("AN") %>' OnClick="lnkAN_Click" CommandArgument='<%# Bind("LOID")  %>'></asp:LinkButton>
                            </ItemTemplate>
                            <HeaderStyle Width="70px" />
                            <ItemStyle HorizontalAlign="center" Width="70px" />
                        </asp:TemplateField>
                        <asp:TemplateField HeaderText="ชื่อผู้ป่วย" SortExpression="PATIENTNAME">
                            <ItemTemplate>
                                <%# Eval("PATIENTNAME") %>, <%# Eval("TITLENAME")%>
                            </ItemTemplate>
                        </asp:TemplateField>
                        <asp:BoundField DataField="BIRTHDATE" HeaderText="วันเดือนปีเกิด" SortExpression="BIRTHDATE" HtmlEncode="false" DataFormatString="{0:dd/MM/yyyy}">
                            <HeaderStyle Width="80px" />
                            <ItemStyle HorizontalAlign="Center" Width="80px" />
                        </asp:BoundField>
                        <asp:BoundField DataField="AGE" HeaderText="อายุ">
                            <HeaderStyle Width="50px" />
                            <ItemStyle HorizontalAlign="Center" Width="50px" />
                        </asp:BoundField>
                        <asp:BoundField DataField="STATUSNAME" HeaderText="สถานะ" SortExpression="STATUSNAME">
                            <HeaderStyle HorizontalAlign="Center" Width="100px" />
                            <ItemStyle Width="100px" />
                        </asp:BoundField>
                        <asp:BoundField DataField="ISRELATIVE" HeaderText="สั่งอาหารสำหรับญาติ">
                            <HeaderStyle Width="80px" />
                            <ItemStyle HorizontalAlign="Center" Width="80px" />
                        </asp:BoundField>
                    </Columns>
                    <HeaderStyle CssClass="t_headtext" />
                    <AlternatingRowStyle CssClass="t_alt_bg" />
                    <PagerSettings Visible="False" />
                </asp:GridView>
                <uc2:PageControl ID="pcBot" runat="server" OnPageChange="PageChange" />
            </td>
        </tr>
    </table>
</asp:Content>