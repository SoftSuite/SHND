<%@ Page Language="C#" MasterPageFile="~/Templates/Page1.master" AutoEventWireup="true" CodeFile="PreStockoutMaterial.aspx.cs" Inherits="PreReport_PreStockoutMaterial" Title="SHND : Pre Stockout Material" %>

<%@ Register Src="../Templates/CalendarControl.ascx" TagName="CalendarControl" TagPrefix="uc2" %>

<%@ Register Src="../Templates/ToolBarItemCtl.ascx" TagName="ToolBarItemCtl" TagPrefix="uc1" %>
<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="cc1" %>

<asp:Content ID="Content3" ContentPlaceHolderID="MainContent" Runat="Server">
<table width="810px" border="0" cellpadding="0" cellspacing="0">
        <tr>
            <td class="headtext">
                &nbsp;รายงานสรุปยอดวัสดุอาหารที่จ่ายออก
            </td>
        </tr>
    </table>
    <table width="100%" border="0" cellpadding="0" cellspacing="0">
        <tr>
            <td>
                <uc1:ToolBarItemCtl ID="tbPrint" runat="server" ToobarTitle="พิมพ์รายงาน" ToolbarImage="../Images/icn_print.png" OnClick="tbPrintClick"/>
                
            </td>
        </tr>
        
    </table>
    <table border="0" cellpadding="0" cellspacing="0" style="border-right: thin solid; border-top: thin solid; border-left: thin solid; border-bottom: thin solid; width: 591px;">
                <tr>
                    <td colspan="5" class="t_headtext">
                        &nbsp;กำหนดเงื่อนไข
                    </td>
                </tr>
                 <tr style="height:10px;">
                </tr>
                <tr>
                    <td style="height:15px">
                        <asp:Label ID="lbStatusMain" runat="server" EnableViewState="False"></asp:Label>
                    </td>
                </tr>
                <tr style="height:10px;">
                </tr>
                <tr style="height:23px">
                    <td style="width:130px; padding-right:10px" align="right">
                        หน่วยงาน :</td>
                    <td colspan="3"  style="height: 23px"><asp:DropDownList ID="cmbDivision" runat="server" CssClass="zComboBox" Width="380px">
                        </asp:DropDownList>
                        </td>
                </tr> 
                <tr style="height:24px">
                    <td style="width:130px; padding-right:10px" align="right">
                        หมวดอาหาร :</td>
                    <td colspan="3"  style="height: 23px">
                        <asp:DropDownList ID="cmbMaterialClass" runat="server" CssClass="zComboBox" Width="380px" OnSelectedIndexChanged="cmbMaterialClass_SelectIndexChange" AutoPostBack="true">
                        </asp:DropDownList>
                        </td>
                </tr> 
                 <tr style="height:24px">
                    <td style="width:130px; padding-right:10px" align="right">
                        วัสดุอาหาร :</td>
                    <td colspan="3" style="height: 23px"><asp:DropDownList ID="cmbMaterialMaster" runat="server" CssClass="zComboBox" Width="220px">
                        </asp:DropDownList>
                        &nbsp;&nbsp; &nbsp;หน่วย :&nbsp;<asp:DropDownList ID="cmbUnit" runat="server" CssClass="zComboBox" Width="100px">
                        </asp:DropDownList>
                        </td>
                </tr> 
                 <tr style="height:24px">
                    <td style="width:130px; padding-right:10px" align="right">
                        ข้อมูลสรุป :</td>
                    <td colspan="3"  style="height: 23px">
                        <asp:RadioButton ID="rdDay" runat="server" GroupName="A" Text="รายวัน" ValidationGroup="GroupReport" Checked="true" />
                        &nbsp;&nbsp;
                        <asp:RadioButton ID="rdMonth" runat="server" GroupName="A" Text="รายเดือน" ValidationGroup="GroupReport" />
                        &nbsp;&nbsp;
                        <asp:RadioButton ID="rdYear" runat="server" GroupName="A" Text="รายปี" ValidationGroup="GroupReport" />
                    </td>
                </tr> 
                <tr id="trDay" runat="server">
                   <td style="width:130px; padding-right:10px; height:23px" align="right">
                        ระหว่างวันที่ :</td>
                    <td colspan="3"  style="height: 23px"><uc2:CalendarControl ID="ctlDateFrom" runat="server" />
                        &nbsp;&nbsp;&nbsp;&nbsp;ถึง : 
                        <uc2:CalendarControl ID="ctlDateTo" runat="server" />
                     </td>
                </tr>
                <tr id="trMonth" style="display:none;" runat="server" >
                   <td style="width:130px; padding-right:10px; height:23px" align="right">
                        ระหว่างเดือน :</td>
                    <td  style="height: 23px">
                        <asp:DropDownList ID="cmbMonthFrom" runat="server" CssClass="zComboBox" Width="100px"  >
                            <asp:ListItem Value="01">ทั้งหมด</asp:ListItem>
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
                        </asp:DropDownList>
                        &nbsp;&nbsp;&nbsp;&nbsp;ปี : 
                        <asp:TextBox ID="txtMYearFrom" runat="server" Width="40px" CssClass="zTextbox" MaxLength="4"></asp:TextBox>
                    </td>
                    <td  style="height: 23px">
                         ถึงเดือน : 
                        <asp:DropDownList ID="cmbMonthTo" runat="server" CssClass="zComboBox" Width="100px" >
                            <asp:ListItem Value="12">ทั้งหมด</asp:ListItem>
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
                        </asp:DropDownList>
                        &nbsp;&nbsp;&nbsp;&nbsp;ปี :
                        <asp:TextBox ID="txtMYearTo" runat="server" Width="40px" CssClass="zTextbox"  MaxLength="4"></asp:TextBox>
                        
                     </td> 
                </tr >
                 <tr id="trYear" style="display:none;" runat="server">
                   <td style="width:130px; padding-right:10px; height:23px" align="right">
                        ระหว่างปี :</td>
                    <td colspan="3"  style="height: 23px">
                        <asp:TextBox ID="txtYearFrom" runat="server" Width="40px" CssClass="zTextbox" MaxLength="4"></asp:TextBox>
                        &nbsp;&nbsp;ถึง : 
                        <asp:TextBox ID="txtYearTo" runat="server" Width="40px" CssClass="zTextbox" MaxLength="4"></asp:TextBox>
                        
                     </td>
                </tr>
                <tr style="height:15px;"></tr>
         </table>
</asp:Content>

