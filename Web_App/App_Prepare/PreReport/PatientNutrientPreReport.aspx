<%@ Page Language="C#" MasterPageFile="~/Templates/Page1.master" AutoEventWireup="true" CodeFile="PatientNutrientPreReport.aspx.cs" Inherits="App_Prepare_PreReport_PatientNutrientPreReport" Title="SHND : Report - PatientNutrient" %>

<%@ Register Src="../../Templates/CalendarControl.ascx" TagName="CalendarControl"
    TagPrefix="uc2" %>
<%@ Register Src="../../Templates/ToolBarItemCtl.ascx" TagName="ToolBarItemCtl" TagPrefix="uc1" %>
<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" Runat="Server">
    <table border="0" cellpadding="0" cellspacing="0" width="100%">
        <tr>
            <td class="headtext">รายงานสารอาหารที่ผู้ป่วยได้รับ
            </td>
        </tr>
        <tr>
            <td>
                <uc1:ToolBarItemCtl ID="tbPrint" runat="server" ToobarTitle="พิมพ์รายงาน" ToolbarImage="../../Images/icn_print.png" />

            </td>
        </tr>
        <tr>
            <td><hr style="size:1px" />
                            <asp:TextBox ID="txtDivision" runat="server" Visible="false"></asp:TextBox>
            </td>
        </tr>
        <tr>
            <td>
                <table border="0" cellpadding="0" cellspacing="0" width="500">
                                    <tr style="height:24px">
                        <td style="width:130px; padding-right:10px" align="right">
                            AN :</td>
                        <td><asp:TextBox ID="txtAN" runat="server" CssClass="zTextbox" Width="75px"></asp:TextBox>
                            </td>
                    </tr> 
                    <tr style="height:24px">
                        <td style="width:130px; padding-right:10px" align="right">
                            เมนูวันที่ :</td>
                        <td><uc2:CalendarControl ID="ctlDateFrom" runat="server" />  ถึง : <uc2:CalendarControl ID="ctlDateTo" runat="server" />
                            </td>
                    </tr> 
                    <tr style="height:24px">
                        <td style="width:130px; padding-right:10px" align="right">
                            มื้อ :</td>
                        <td>
                            <asp:DropDownList ID="cmbMeal" runat="server" CssClass="zComboBox" Width="75px" AutoPostBack="True">
                                <asp:ListItem Value="00">ทั้งหมด</asp:ListItem>
                                <asp:ListItem Value="11">เช้า</asp:ListItem>
                                <asp:ListItem Value="21">กลางวัน</asp:ListItem>
                                <asp:ListItem Value="31">เย็น</asp:ListItem>
                            </asp:DropDownList></td>
                    </tr> 

                </table> 
            </td>
        </tr>
    </table>
</asp:Content>