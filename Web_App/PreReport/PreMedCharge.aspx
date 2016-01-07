<%@ Page Language="C#" MasterPageFile="~/Templates/Page1.master" AutoEventWireup="true" CodeFile="PreMedCharge.aspx.cs" Inherits="PreReport_PreMedCharge" Title="SHND : Report - MedCharge" %>

<%@ Register Src="../Templates/CalendarControl.ascx" TagName="CalendarControl"
    TagPrefix="uc2" %>
<%@ Register Src="../Templates/ToolBarItemCtl.ascx" TagName="ToolBarItemCtl" TagPrefix="uc1" %>
<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" Runat="Server">
    <table border="0" cellpadding="0" cellspacing="0" width="100%">
        <tr>
            <td class="headtext">รายงานสรุปจำนวนการจ่ายอาหารทางแพทย์เป็นกระป๋อง
            </td>
        </tr>
        <tr>
            <td>
                <uc1:ToolBarItemCtl ID="tbPrint" runat="server" ToobarTitle="พิมพ์รายงาน" ToolbarImage="../Images/icn_print.png" />
            </td>
        </tr>
        <tr>
            <td>
                <hr style="size:1px" /><asp:TextBox ID="txtDivision" runat="server" Visible="false"></asp:TextBox>
            </td>
        </tr>
        <tr>
            <td>
                <table border="0" cellpadding="0" cellspacing="0" width="600">
                    <tr style="height:24px">
                        <td style="width:130px; padding-right:10px" align="right">
                            หน่วยงาน :</td>
                        <td>
                            <asp:TextBox ID="txtDivisionName" runat="server" CssClass="zTextbox-View" ReadOnly="True"
                                Width="250px"></asp:TextBox></td>
                    </tr>
                    <tr style="height:24px">
                        <td style="width:130px; padding-right:10px" align="right">
                            หอผู้ป่วย :</td>
                        <td>
                            <asp:DropDownList ID="cmbWard" runat="server" CssClass="zComboBox" Width="256px" AutoPostBack="True" OnSelectedIndexChanged="cmbWard_SelectedIndexChanged">
                            </asp:DropDownList></td>
                    </tr> 
                    <tr style="height:24px">
                        <td style="width:130px; padding-right:10px" align="right">
                            แสดงจำนวน :</td>
                        <td>
                            <asp:RadioButtonList ID="rbtQty" runat="server" RepeatDirection="Horizontal" AutoPostBack="True" OnSelectedIndexChanged="rbtQty_SelectedIndexChanged">
                                <asp:ListItem Selected="true" Value="1">แยกตามหอผู้ป่วย</asp:ListItem>
                                <asp:ListItem Value="0">สรุปรวมทั้งหมด</asp:ListItem>
                            </asp:RadioButtonList>
                            </td>
                    </tr>  
                    <tr style="height:24px">
                        <td style="width:130px; padding-right:10px" align="right">
                            ชนิดอาหาร :</td>
                        <td>
                            <asp:DropDownList ID="cmbMaterial" runat="server" CssClass="zComboBox" Width="256px">
                            </asp:DropDownList>&nbsp; หน่วย &nbsp;<asp:DropDownList ID="cmbUnit" runat="server" CssClass="zComboBox" Width="70px" Enabled="False">
                            <asp:ListItem Value="0">กระป๋อง</asp:ListItem>
                            </asp:DropDownList></td>
                    </tr> 
                    <tr style="height:24px">
                        <td style="width:130px; padding-right:10px; height: 24px;" align="right">
                            ข้อมูลสรุป :</td>
                        <td style="height: 24px">
                            <asp:RadioButtonList ID="rbtType" runat="server" RepeatDirection="Horizontal" AutoPostBack="True" OnSelectedIndexChanged="rbtType_SelectedIndexChanged">
                                <asp:ListItem Selected="true" Value="dd">รายวัน</asp:ListItem>
                                <asp:ListItem Value="mm">รายเดือน</asp:ListItem>
                                <asp:ListItem Value="yy">รายปี</asp:ListItem>
                            </asp:RadioButtonList>
                            </td>
                    </tr>
                                        <tr id="pnlDate"  runat="server" style="height:24px">
                        <td style="width:130px; padding-right:10px; height: 24px;" align="right">
                            ระหว่างวันที่ :</td>
                        <td style="height: 24px">
                            <uc2:CalendarControl ID="ctlDateFrom" runat="server" />
                            &nbsp;ถึง
                            <uc2:CalendarControl ID="ctlDateTo" runat="server" />
                        </td>
                    </tr> 
                   
                    <tr id="pnlMonth"  runat="server"  style="height:24px" visible="false">
                        <td style="width:130px; padding-right:10px; height: 24px;" align="right">
                            ระหว่างเดือน :</td>
                        <td style="height: 24px">
                            <asp:DropDownList ID="cmbMonthFrom" runat="server" Width="106px" CssClass="zComboBox">
                                <asp:ListItem Value="0">เลือก</asp:ListItem>
                                <asp:ListItem Value="1">มกราคม</asp:ListItem>
                                <asp:ListItem Value="2">กุมภาพันธ์</asp:ListItem>
                                <asp:ListItem Value="3">มีนาคม</asp:ListItem>
                                <asp:ListItem Value="4">เมษายน</asp:ListItem>
                                <asp:ListItem Value="5">พฤษภาคม</asp:ListItem>
                                <asp:ListItem Value="6">มิถุนายน</asp:ListItem>
                                <asp:ListItem Value="7">กรกฎาคม</asp:ListItem>
                                <asp:ListItem Value="8">สิงหาคม</asp:ListItem>
                                <asp:ListItem Value="9">กันยายน</asp:ListItem>
                                <asp:ListItem Value="10">ตุลาคม</asp:ListItem>
                                <asp:ListItem Value="11">พฤศจิกายน</asp:ListItem>
                                <asp:ListItem Value="12">ธันวาคม</asp:ListItem>
                            </asp:DropDownList> ปี 
                            <asp:TextBox ID="txtMYearFrom" CssClass="zTextbox" runat="server" Width="45px" MaxLength="4"></asp:TextBox>
                            &nbsp;ถึงเดือน <asp:DropDownList ID="cmbMonthTo" runat="server" Width="106px" CssClass="zComboBox">
                             <asp:ListItem Value="0">เลือก</asp:ListItem>
                                <asp:ListItem Value="1">มกราคม</asp:ListItem>
                                <asp:ListItem Value="2">กุมภาพันธ์</asp:ListItem>
                                <asp:ListItem Value="3">มีนาคม</asp:ListItem>
                                <asp:ListItem Value="4">เมษายน</asp:ListItem>
                                <asp:ListItem Value="5">พฤษภาคม</asp:ListItem>
                                <asp:ListItem Value="6">มิถุนายน</asp:ListItem>
                                <asp:ListItem Value="7">กรกฎาคม</asp:ListItem>
                                <asp:ListItem Value="8">สิงหาคม</asp:ListItem>
                                <asp:ListItem Value="9">กันยายน</asp:ListItem>
                                <asp:ListItem Value="10">ตุลาคม</asp:ListItem>
                                <asp:ListItem Value="11">พฤศจิกายน</asp:ListItem>
                                <asp:ListItem Value="12">ธันวาคม</asp:ListItem>
                            </asp:DropDownList> ปี 
                            <asp:TextBox ID="txtMYearTo" CssClass="zTextbox" runat="server" Width="45px" MaxLength="4"></asp:TextBox>              
                        </td>
                    </tr>                    
                    <tr id="PnlYear"  runat="server"  style="height:24px" visible="false">
                        <td style="width:130px; padding-right:10px; height: 24px;" align="right">
                            ระหว่างปี :</td>
                        <td style="height: 24px">
                            <asp:TextBox ID="txtYearFrom" CssClass="zTextbox" runat="server" Width="45px" MaxLength="4"></asp:TextBox>
                            &nbsp;ถึง
                            <asp:TextBox ID="txtYearTo" CssClass="zTextbox" runat="server" Width="45px" MaxLength="4"></asp:TextBox>
                        </td>
                    </tr> 
                    </table> 
            </td>
        </tr>
    </table>
</asp:Content>

