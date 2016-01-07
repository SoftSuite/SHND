<%@ Page Language="C#" MasterPageFile="~/Templates/Page1.master" AutoEventWireup="true" CodeFile="PreMaterialUseQtyClass.aspx.cs" Inherits="PreReport_PreMaterialUseQtyClass" Title="SHND : Report - Material Use Qty Class" %>
<%@ Register Src="../Templates/CalendarControl.ascx" TagName="CalendarControl" TagPrefix="uc2" %>
<%@ Register Src="../Templates/ToolBarItemCtl.ascx" TagName="ToolBarItemCtl" TagPrefix="uc1" %>
<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" Runat="Server">
    <table border="0" cellpadding="0" cellspacing="0" width="100%">
        <tr>
            <td class="headtext">รายงานสรุปสถิติการใช้วัตถุดิบ
            </td>
        </tr>
        <tr>
            <td>
                <uc1:ToolBarItemCtl ID="tbPrint" runat="server" ToobarTitle="พิมพ์รายงาน" ToolbarImage="../Images/icn_print.png" />
            </td>
        </tr>
        <tr>
            <td><hr style="size:1px" />
                            <asp:TextBox ID="txtDivision" runat="server" Visible="false"></asp:TextBox>
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
                                Width="320px"></asp:TextBox></td>
                    </tr>  
                    <tr style="height:24px">
                        <td style="width:130px; padding-right:10px" align="right">
                            หมวดอาหาร :</td>
                        <td>
                            <asp:DropDownList ID="cmbClass" runat="server" CssClass="zComboBox" Width="326px" OnSelectedIndexChanged="cmbClass_SelectedIndexChanged">
                            </asp:DropDownList></td>
                    </tr> 
                    <tr style="height:24px">
                        <td style="width:130px; padding-right:10px" align="right">
                            ประเภท :</td>
                        <td>
                            <asp:DropDownList ID="cmbGroup" runat="server" CssClass="zComboBox" Width="326px">
                            </asp:DropDownList></td>
                    </tr> 
                    <tr style="height:24px">
                        <td style="width:130px; padding-right:10px" align="right">
                            ระหว่างวันที่ :</td>
                        <td>
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

