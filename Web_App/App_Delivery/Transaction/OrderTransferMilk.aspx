<%@ Page Language="C#" MasterPageFile="~/Templates/Page1.master" AutoEventWireup="true" CodeFile="OrderTransferMilk.aspx.cs" Inherits="App_Delivery_Transaction_OrderTransferMilk" Title="SHND : Transaction - Food Delivery" %>
<%@ Register Src="../../Templates/PageControl.ascx" TagName="PageControl" TagPrefix="uc3" %>
<%@ Register Src="../../Templates/CalendarControl.ascx" TagName="CalendarControl" TagPrefix="uc2" %>
<%@ Register Src="../../Templates/ToolBarItemCtl.ascx" TagName="ToolBarItemCtl" TagPrefix="uc1" %>
<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" Runat="Server">
    <table border="0" cellpadding="0" cellspacing="0" width="100%">
        <tr>
            <td class="headtext">
                ข้อมูลการจัดส่งนมผงสำหรับเด็ก</td>
        </tr>
        <tr>
            <td>
                <uc1:ToolBarItemCtl ID="tbSave" runat="server" ToolbarImage="../../Images/save2.png" ToobarTitle="บันทึก" OnClick="tbSaveClick" />
                <uc1:ToolBarItemCtl ID="tbPrint" runat="server" ToolbarImage="../../Images/icn_print.png" ToobarTitle="พิมพ์รายการ" />
            </td>
        </tr>
        <tr>
            <td><hr style="size:1px" />
                <asp:Label ID="lbStatus" runat="server" EnableViewState="False"></asp:Label></td>
        </tr>
        <tr>
            <td>
                <fieldset style="padding:15px;">
                    <legend>ค้นหา</legend>
                    <table border="0" cellpadding="0" cellspacing="0" width="900">
                        <tr>
                            <td style="height:15px" colspan="7"></td>
                        </tr> 
                        <tr style="height: 24px">
                            <td style="padding-right: 10px; width: 110px; text-align: right">
                                หอผู้ป่วย :</td>
                            <td colspan="6">
                                <asp:DropDownList ID="cmbSearchWard" runat="server" CssClass="zComboBox" Width="296px">
                                </asp:DropDownList></td>
                        </tr>
                        <tr style="height: 24px">
                            <td style="padding-right: 10px; width: 110px; text-align: right;">
                                ชนิดนมที่สั่ง :</td>
                            <td colspan="6">
                                <asp:DropDownList ID="cmbSearchMilkCategory" runat="server" CssClass="zComboBox" Width="296px">
                                </asp:DropDownList></td>
                        </tr>
                        <tr style="height: 24px">
                            <td style="padding-right: 10px; width: 110px; text-align: right">
                                ชื่อ-สกุล ผู้ป่วย :</td>
                            <td colspan="6">
                                <asp:TextBox ID="txtSearchPatientName" runat="server" CssClass="zTextbox" Width="290px"></asp:TextBox></td>
                        </tr>
                        <tr style="height:24px">
                            <td style="width:110px; text-align: right; padding-right:10px">
                                วันที่จัดอาหาร :</td>
                            <td style="width:140px;">
                                <uc2:CalendarControl ID="ctlSearchOrderDate" runat="server" />
                            </td>
                            <td style="width:40px; text-align: right; padding-right:10px">
                                มื้อ :</td>
                            <td style="width:120px;">
                                <asp:DropDownList ID="cmbSearchMeal" runat="server" Width="106px">
                                    <asp:ListItem Value="" Text="ทั้งหมด"></asp:ListItem> 
                                    <asp:ListItem Value="11" Text="เช้า"></asp:ListItem> 
                                    <asp:ListItem Value="21" Text="กลางวัน"></asp:ListItem> 
                                    <asp:ListItem Value="31" Text="เย็น"></asp:ListItem> 
                                </asp:DropDownList>
                            </td>
                            <td style="padding-right: 10px; width: 77px">
                                </td>
                            <td style="width:120px;"></td>
                            <td>
                                &nbsp;
                            </td>
                        </tr>
                        <tr style="height: 24px">
                            <td style="padding-right: 10px; width: 110px; text-align: right">
                                เจ้าของนม :</td>
                            <td colspan="3">
                                <asp:DropDownList ID="cmbSearchOwner" runat="server" CssClass="zComboBox" Width="296px">
                                </asp:DropDownList></td>
                            <td style="padding-right: 10px; width: 77px">
                                <asp:ImageButton ID="imbSearch" runat="server" ImageUrl="~/Images/icn_find.png" ImageAlign="absMiddle" OnClick="imbSearch_Click" />
                                <asp:ImageButton ID="imbReset" runat="server" ImageUrl="~/Images/icn_back.png" ImageAlign="absMiddle" OnClick="imbReset_Click" /></td>
                            <td style="width: 120px">
                            </td>
                            <td>
                            </td>
                        </tr>
                    </table> 
                </fieldset> 
            </td>
        </tr>
        <tr>
            <td>
                <uc3:PageControl ID="pcTop" runat="server" OnPageChange="PageChange" />
                <asp:GridView ID="gvMain" runat="server" AllowSorting="True" AutoGenerateColumns="False" CssClass="t_tablestyle1" CellPadding="0" OnRowDataBound="gvMain_RowDataBound" Width="100%">
                    <Columns>
                        <asp:BoundField DataField="ADMITPATIENT" HeaderText="ADMITPATIENT">
                            <ControlStyle CssClass="zHidden" />
                            <FooterStyle CssClass="zHidden" />
                            <HeaderStyle CssClass="zHidden" />
                            <ItemStyle CssClass="zHidden" />
                        </asp:BoundField>
                        <asp:TemplateField>
                            <HeaderTemplate>
                                <table border="0" cellpadding="2" cellspacing="0" width="100%">
                                    <tr style="height:20px" class="t_headtext">
                                        <td style="width:40px; border-right:solid 1px #ebe9ed" align="center">ลำดับ</td> 
                                        <td style="width:30px; border-right:solid 1px #ebe9ed" align="center"><asp:CheckBox ID="chkMain" runat="server" /></td> 
                                        <td style="width:170px; border-right:solid 1px #ebe9ed" align="center">หอผู้ป่วย</td> 
                                        <td style="width:30px; border-right:solid 1px #ebe9ed" align="center">ห้อง</td> 
                                        <td style="width:30px; border-right:solid 1px #ebe9ed" align="center">เตียง</td> 
                                        <td style="width:70px; border-right:solid 1px #ebe9ed" align="center">HN</td> 
                                        <td style="width:70px; border-right:solid 1px #ebe9ed" align="center">AN</td> 
                                        <td style="width:250px; border-right:solid 1px #ebe9ed" align="center">ชื่อ-สกุล</td> 
                                        <td style="width:30px; border-right:solid 1px #ebe9ed" align="center">อายุ</td>  
                                        <td style="width:30px; border-right:solid 1px #ebe9ed" align="center">น.น.</td>  
                                        <td style="width:30px; border-right:solid 1px #ebe9ed" align="center">ส.ส.</td>  
                                        <td align="center">BMI</td>  
                                    </tr>
                                </table>
                            </HeaderTemplate>
                            <ItemTemplate>
                                <table border="0" cellpadding="2" cellspacing="0" width="100%">
                                    <tr style="height:20px" class='<%# Eval("RANK").ToString() != "0" ? "t_alt_bg" : "zHidden" %>'>
                                        <td style="width:40px; border-right:solid 1px #ebe9ed" align="center"><%# Eval("RANK") %></td> 
                                        <td style="width:30px; border-right:solid 1px #ebe9ed" align="center"><asp:CheckBox ID="chkSelect" runat="server" CssClass='<%# Eval("RANK").ToString() != "0" && Eval("ISTRANSFER").ToString() == "N" ? "" : "zHidden" %>'/></td> 
                                        <td style="width:170px; border-right:solid 1px #ebe9ed" align="left"><%# Eval("WARDNAME") %></td> 
                                        <td style="width:30px; border-right:solid 1px #ebe9ed" align="center"><%# Eval("ROOMNO") %></td> 
                                        <td style="width:30px; border-right:solid 1px #ebe9ed" align="center"><%# Eval("BEDNO") %></td> 
                                        <td style="width:70px; border-right:solid 1px #ebe9ed" align="center"><%# Eval("HN") %></td> 
                                        <td style="width:70px; border-right:solid 1px #ebe9ed" align="center"><%# Eval("AN") %></td> 
                                        <td style="width:250px; border-right:solid 1px #ebe9ed" align="left"><%# Eval("PATIENTNAME") %></td> 
                                        <td style="width:30px; border-right:solid 1px #ebe9ed" align="right"><%# Eval("AGE") %></td>  
                                        <td style="width:30px; border-right:solid 1px #ebe9ed" align="right"><%# Eval("WEIGHT") %></td>  
                                        <td style="width:30px; border-right:solid 1px #ebe9ed" align="right"><%# Eval("HEIGHT") %></td>  
                                        <td align="left"><%# Eval("BMI") %></td>  
                                    </tr>
                                    <tr style="height:1px">
                                        <td style="width:40px; border-right:solid 1px #ebe9ed" align="center"></td> 
                                        <td style="width:30px; border-right:solid 1px #ebe9ed" align="center"></td> 
                                        <td style="width:120px; " align="left"></td> 
                                        <td style="width:30px;" align="center"></td> 
                                        <td style="width:30px;" align="center"></td> 
                                        <td style="width:70px;" align="center"></td> 
                                        <td style="width:70px;" align="center"></td> 
                                        <td style="width:250px;" align="left"></td> 
                                        <td style="width:30px;" align="right"></td>  
                                        <td style="width:30px;" align="right"></td>  
                                        <td style="width:30px;" align="right"></td>  
                                        <td align="left"></td>  
                                    </tr>
                                    <tr style="height:20px">
                                        <td style="width:40px; border-right:solid 1px #ebe9ed" align="center"></td> 
                                        <td style="width:30px; border-right:solid 1px #ebe9ed" align="center"></td> 
                                        <td align="left" colspan="11">
                                        <table border="0" cellpadding="0" cellspacing="0" width="100%">
                                            <tr style="height:24px">
                                                <td style="width:70px"><b>No. : </b><%# Eval("ORDERNO") %></td>
                                                <td style="width:170px"><b>ชนิดนมที่สั่ง : </b><%# Eval("MILKNAME") %></td>
                                                <td style="width:120px"><b>พลังงาน : </b><%# Eval("ENERGY") %></td>
                                                <td style="width:180px"><b>จำนวนมื้อ : </b><%# Eval("MEALQTY") %></td>
                                                <td style="width:80px"><b>นม/มื้อ : </b><%# Eval("VOLUMN") %></td>
                                                <td><b>วัน-เวลาที่สั่ง : </b><%# Eval("ORDERDATE", "{0:dd/MM/yyyy HH:mm:ss}") %></td>
                                            </tr>
                                            <tr style="height:24px">
                                                <td colspan="2"><b>เบอร์นม : </b><%# Eval("MILKCODE") %></td>
                                                <td ><b>สถานะ : </b><span style="color:Red"><%# Eval("STATUSNAME") %></span></td>
                                                <td colspan="2">&nbsp;<span style="color:Red"><%# Eval("OWNER").ToString() == "M" ? Eval("OWNERNAME") : "" %></span></td>
                                                <td ><b>วันที่ส่ง : </b><%#Eval("DELIVERYTIME", "{0:dd/MM/yyyy HH:mm:ss}") %> </td>
                                            </tr>
                                        </table>
                                        </td> 
                                    </tr> 
                                </table>
                            </ItemTemplate>
                        </asp:TemplateField>
                    </Columns>
                    <PagerSettings Visible="False" />
                </asp:GridView>
                <uc3:PageControl ID="pcBot" runat="server" OnPageChange="PageChange" /> 
            </td>
        </tr>
    </table>
</asp:Content>