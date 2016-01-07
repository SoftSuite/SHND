<%@ Page Language="C#" MasterPageFile="~/Templates/Page1.master" AutoEventWireup="true" CodeFile="PrePrepareSet.aspx.cs" Inherits="PreReport_PrePrepareSet" Title="SHND : PrepareSet " %>
<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="cc1" %>
<%@ Register Src="../Templates/CalendarControl.ascx" TagName="CalendarControl"
    TagPrefix="uc2" %>
<%@ Register Src="../Templates/ToolBarItemCtl.ascx" TagName="ToolBarItemCtl" TagPrefix="uc1" %>
<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" Runat="Server">
    <table border="0" cellpadding="0" cellspacing="0" width="100%">
        <tr>
            <td class="headtext">รายงานเมนูอาหาร
            </td>
        </tr>
        <tr>
            <td>
                <uc1:ToolBarItemCtl ID="tbPrint" runat="server" ToobarTitle="พิมพ์รายงาน" ToolbarImage="../Images/icn_print.png" />
            </td>
        </tr>
        <tr>
            <td><hr style="size:1px" />
                            
            </td>
        </tr>
        <tr>
            <td>
                <table border="0" cellpadding="0" cellspacing="0" width="600">
                   <tr style="height:24px">
                        <td style="width:130px; padding-right:10px" align="right">
                            หน่วยงาน :</td>
                        <td><asp:DropDownList ID="cmbDivision" runat="server" CssClass="zComboBox" Width="200px" AutoPostback="true" OnSelectedIndexChanged="cmbDivision_SelectedIndexChanged">
                            </asp:DropDownList>
                            </td>
                    </tr> 

                    <tr style="height:24px">
                        <td style="width:130px; padding-right:10px" align="right">
                            เมนูอาหารวันที่ :</td>
                        <td>
                            <uc2:CalendarControl ID="ctlDate" runat="server" />  &nbsp; &nbsp; มื้อ :
                            <asp:DropDownList ID="cmbMeal" runat="server" CssClass="zComboBox" Width="75px">
                                <asp:ListItem Value="00">ทั้งหมด</asp:ListItem>
                                <asp:ListItem Value="11">เช้า</asp:ListItem>
                                <asp:ListItem Value="21">กลางวัน</asp:ListItem>
                                <asp:ListItem Value="31">เย็น</asp:ListItem>
                            </asp:DropDownList>
                        </td>
                    </tr> 
                    <tr style="height:24px">
                        <td style="width:130px; padding-right:10px" align="right">
                            เวลาเตรียม :</td>
                        <td>
                            <asp:TextBox ID="txtTimeFrom" CssClass="zTextbox" runat="server" Width="50px" ></asp:TextBox>
                            &nbsp;ถึง
                            <asp:TextBox ID="txtTimeTo" CssClass="zTextbox" runat="server" Width="50px" ></asp:TextBox>&nbsp; [Ex.08:00]
                        </td>
                    </tr>
                                         <tr style="height:24px">
                        <td style="width:130px; padding-right:10px" align="right">
                            ชื่อชุดเมนู :</td>
                        <td>
                            <asp:DropDownList ID="cmbMenu" runat="server" CssClass="zComboBox" Width="200px">
                            </asp:DropDownList></td>
                    </tr>
                                        <tr style="height:24px">
                        <td style="width:130px; padding-right:10px" align="right">
                            ประเภทอาหาร :</td>
                        <td>
                            <asp:DropDownList ID="cmbFoodType" runat="server" CssClass="zComboBox" Width="200px">
                            </asp:DropDownList></td>
                    </tr>  
                                                            <tr style="height:24px">
                        <td style="width:130px; padding-right:10px" align="right">
                            ชนิดอาหาร :</td>
                        <td>
                            <asp:DropDownList ID="cmbFoodCategory" runat="server" CssClass="zComboBox" Width="200px">
                            </asp:DropDownList></td>
                    </tr>
                     <tr style="height:24px">
                        <td style="width:130px; padding-right:10px" align="right">
                            ประเภทวัสดุอาหาร :</td>
                        <td>
                            <asp:DropDownList ID="cmbMaterialGroup" runat="server" CssClass="zComboBox" Width="200px">
                            </asp:DropDownList></td>
                    </tr>
                    </table> 
                <cc1:MaskedEditExtender ID="mdeTimeFrom" runat="server" TargetControlID="txtTimeFrom" MaskType="Time" Mask="99:99"></cc1:MaskedEditExtender>
                <cc1:MaskedEditExtender ID="mdeTimeTo" runat="server" TargetControlID="txtTimeTo" MaskType="Time" Mask="99:99"></cc1:MaskedEditExtender>
            
                             
            </td>
        </tr>
    </table>
</asp:Content>

