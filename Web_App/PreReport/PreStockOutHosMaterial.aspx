<%@ Page Language="C#" MasterPageFile="~/Templates/Page1.master" AutoEventWireup="true" CodeFile="PreStockOutHosMaterial.aspx.cs" Inherits="PreReport_PreStockOutHosMaterial" Title="SHND : Report - Tool Stock out (Return to main warehouse)" %>
<%@ Register Src="../Templates/CalendarControl.ascx" TagName="CalendarControl" TagPrefix="uc2" %>
<%@ Register Src="../Templates/ToolBarItemCtl.ascx" TagName="ToolBarItemCtl" TagPrefix="uc1" %>
<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" Runat="Server">
    <table border="0" cellpadding="0" cellspacing="0" width="100%">
        <tr>
            <td class="headtext">รายงานสรุปยอดวัสดุอุปกรณ์ที่ส่งคืนคลังของโรงพยาบาล
            </td>
        </tr>
        <tr>
            <td>
                <uc1:ToolBarItemCtl ID="tbPrint" runat="server" ToobarTitle="พิมพ์รายงาน" ToolbarImage="../Images/icn_print.png"/>
            </td>
        </tr>
        <tr>
            <td>
                <hr style="size:1px" /> 
            </td>
        </tr>
        <tr>
            <td>
                <table border="0" cellspacing="0" cellpadding="0" width="600px">
                    <tr style="height:24px">
                        <td style="width:130px; padding-right:10px; height: 24px;" align="right">
                            ประเภทวัสดุ :
                        </td>
                        <td><asp:DropDownList ID="cmbMaterialClass" runat="server" CssClass="zComboBox" Width="326px">
                        </asp:DropDownList></td>
                    </tr> 
                    <tr style="height:24px">
                        <td style="width:130px; padding-right:10px; height: 24px;" align="right">
                            วัสดุอุปกรณ์ :</td>
                        <td style="height: 24px">
                            <asp:DropDownList ID="cmbMaterialMaster" runat="server" CssClass="zComboBox" Width="326px" OnSelectedIndexChanged="cmbMaterialMaster_SelectedIndexChanged" AutoPostBack="True">
                            </asp:DropDownList>&nbsp; หน่วย &nbsp;<asp:DropDownList ID="cmbUnit" runat="server" CssClass="zComboBox" Width="70px" Enabled="False">
                            </asp:DropDownList></td>
                    </tr> 
                    <tr style="height:24px">
                        <td style="width:130px; padding-right:10px; height: 24px;" align="right">
                            ข้อมูลสรุป :</td>
                        <td style="height: 24px">
                            <asp:RadioButtonList ID="rbtType" runat="server" RepeatDirection="Horizontal">
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
                            <uc2:CalendarControl ID="ctlDateFrom" runat="server" />&nbsp;<span class="zRemark">*</span>
                            &nbsp;ถึง
                            <uc2:CalendarControl ID="ctlDateTo" runat="server" />&nbsp;<span class="zRemark">*</span>
                        </td>
                    </tr> 
                   
                    <tr id="pnlMonth"  runat="server"  style="height:24px" >
                        <td style="width:130px; padding-right:10px; height: 24px;" align="right">
                            ระหว่างเดือน :</td>
                        <td style="height: 24px">
                            <asp:DropDownList ID="cmbMonthFrom" runat="server" Width="106px" CssClass="zComboBox">
                             <asp:ListItem Value="">เลือก</asp:ListItem>
                                <asp:ListItem Value="01">มกราคม</asp:ListItem>
                                <asp:ListItem Value="02">กุมภาพันธ์</asp:ListItem>
                                <asp:ListItem Value="03">มีนาคม</asp:ListItem>
                                <asp:ListItem Value="04">เมษายน</asp:ListItem>
                                <asp:ListItem Value="05">พฤษภาคม</asp:ListItem>
                                <asp:ListItem Value="06">มิถุนายน</asp:ListItem>
                                <asp:ListItem Value="07">กรกฎาคม</asp:ListItem>
                                <asp:ListItem Value="08">สิงหาคม</asp:ListItem>
                                <asp:ListItem Value="09">กันยายน</asp:ListItem>
                                <asp:ListItem Value="10">ตุลาคม</asp:ListItem>
                                <asp:ListItem Value="11">พฤศจิกายน</asp:ListItem>
                                <asp:ListItem Value="12">ธันวาคม</asp:ListItem>
                            </asp:DropDownList> ปี 
                            <asp:TextBox ID="txtMYearFrom" CssClass="zTextbox" runat="server" Width="45px" MaxLength="4"></asp:TextBox>&nbsp;<span class="zRemark">*</span>
                            &nbsp;ถึงเดือน <asp:DropDownList ID="cmbMonthTo" runat="server" Width="106px" CssClass="zComboBox">
                             <asp:ListItem Value="">เลือก</asp:ListItem>
                                <asp:ListItem Value="01">มกราคม</asp:ListItem>
                                <asp:ListItem Value="02">กุมภาพันธ์</asp:ListItem>
                                <asp:ListItem Value="03">มีนาคม</asp:ListItem>
                                <asp:ListItem Value="04">เมษายน</asp:ListItem>
                                <asp:ListItem Value="05">พฤษภาคม</asp:ListItem>
                                <asp:ListItem Value="06">มิถุนายน</asp:ListItem>
                                <asp:ListItem Value="07">กรกฎาคม</asp:ListItem>
                                <asp:ListItem Value="08">สิงหาคม</asp:ListItem>
                                <asp:ListItem Value="09">กันยายน</asp:ListItem>
                                <asp:ListItem Value="10">ตุลาคม</asp:ListItem>
                                <asp:ListItem Value="11">พฤศจิกายน</asp:ListItem>
                                <asp:ListItem Value="12">ธันวาคม</asp:ListItem>
                            </asp:DropDownList> ปี 
                            <asp:TextBox ID="txtMYearTo" CssClass="zTextbox" runat="server" Width="45px" MaxLength="4"></asp:TextBox>&nbsp;<span class="zRemark">*</span>
                        </td>
                    </tr>                    
                    <tr id="PnlYear"  runat="server"  style="height:24px">
                        <td style="width:130px; padding-right:10px; height: 24px;" align="right">
                            ระหว่างปี :</td>
                        <td style="height: 24px">
                            <asp:TextBox ID="txtYearFrom" CssClass="zTextbox" runat="server" Width="45px" MaxLength="4"></asp:TextBox>&nbsp;<span class="zRemark">*</span>
                            &nbsp;ถึง
                            <asp:TextBox ID="txtYearTo" CssClass="zTextbox" runat="server" Width="45px" MaxLength="4"></asp:TextBox>&nbsp;<span class="zRemark">*</span>
                        </td>
                    </tr> 
                </table> 
            </td>
        </tr>
    </table>
</asp:Content>