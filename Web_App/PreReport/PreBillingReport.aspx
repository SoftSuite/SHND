<%@ Page Language="C#" MasterPageFile="~/Templates/Page1.master" AutoEventWireup="true" CodeFile="PreBillingReport.aspx.cs" Inherits="PreReport_PreBillingReport" Title="SHND : Report - Billing" %>

<%@ Register Src="../Templates/CalendarControl.ascx" TagName="CalendarControl"
    TagPrefix="uc2" %>
<%@ Register Src="../Templates/ToolBarItemCtl.ascx" TagName="ToolBarItemCtl" TagPrefix="uc1" %>
<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" Runat="Server">
    <table border="0" cellpadding="0" cellspacing="0" width="100%">
        <tr>
            <td class="headtext">รายงานสรุปค่าใช้จ่ายสำหรับผู้ป่วย
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
                            หอผู้ป่วย :</td>
                        <td>
                            <asp:DropDownList ID="cmbWard" runat="server" CssClass="zComboBox" Width="256px">
                            </asp:DropDownList></td>
                    </tr>  
                    <tr style="height:24px">
                        <td style="width:130px; padding-right:10px" align="right">
                            AN :</td>
                        <td>
                            <asp:TextBox ID="txtAN" runat="server" Width="100px" ></asp:TextBox>&nbsp; &nbsp; HN : <asp:TextBox ID="txtHN" runat="server" Width="100px" ></asp:TextBox></td>
                    </tr> 
                    <tr style="height:24px">
                        <td style="width:130px; padding-right:10px" align="right">
                            ชื่อสกุล :</td>
                        <td>
                           <asp:TextBox ID="txtName" runat="server" Width="256px" ></asp:TextBox></td>
                    </tr> 
                   <tr style="height:24px">
                        <td style="width:130px; padding-right:10px; height: 24px;" align="right">
                            วันที่ Admit :</td>
                        <td style="height: 24px">
                            <uc2:CalendarControl ID="ctlDateFrom" runat="server" />
                            &nbsp;ถึง
                            <uc2:CalendarControl ID="ctlDateTo" runat="server" />
                        </td>
                    </tr> 

                    </table> 
            </td>
        </tr>
    </table>
</asp:Content>

