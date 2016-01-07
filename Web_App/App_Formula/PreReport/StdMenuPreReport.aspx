<%@ Page Language="C#" MasterPageFile="~/Templates/Page1.master" AutoEventWireup="true" CodeFile="StdMenuPreReport.aspx.cs" Inherits="App_Formula_PreReport_StdMenuPreReport" Title="SHND : Report - Standard Menu" %>
<%@ Register Src="../../Templates/ToolBarItemCtl.ascx" TagName="ToolBarItemCtl" TagPrefix="uc1" %>
<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" Runat="Server">
    <table border="0" cellpadding="0" cellspacing="0" width="100%">
        <tr>
            <td class="headtext">รายงานเมนูมาตรฐาน
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
                            หน่วยงาน :</td>
                        <td>
                            <asp:TextBox ID="txtDivisionName" runat="server" CssClass="zTextbox-View" ReadOnly="True"
                                Width="200px"></asp:TextBox></td>
                    </tr> 
                    <tr style="height:24px">
                        <td style="width:130px; padding-right:10px" align="right">
                            ชื่อชุดเมนูมาตรฐาน :</td>
                        <td>
                            <asp:DropDownList ID="cmbStdMenu" runat="server" CssClass="zComboBox" Width="200px">
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
                            วันที่ :</td>
                        <td>
                            <asp:TextBox ID="txtMenuDateFrom" runat="server" CssClass="zTextboxR" MaxLength="2"
                                Width="50px"></asp:TextBox>
                            ถึง
                            <asp:TextBox ID="txtMenuDateTo" runat="server" CssClass="zTextboxR" MaxLength="2"
                                Width="50px"></asp:TextBox></td>
                    </tr> 
                </table> 
            </td>
        </tr>
    </table>
</asp:Content>