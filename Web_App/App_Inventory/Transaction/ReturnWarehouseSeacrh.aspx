<%@ Page Language="C#" MasterPageFile="~/Templates/Page1.master" AutoEventWireup="true" CodeFile="ReturnWarehouseSeacrh.aspx.cs" Inherits="App_Inventory_Transaction_ReturnWarehouseSeacrh" Title="SHND : Transaction - Return Warehouse" %>

<%@ Register Src="../../Templates/CalendarControl.ascx" TagName="CalendarControl" TagPrefix="uc3" %>
<%@ Register Src="../../Templates/PageControl.ascx" TagName="PageControl" TagPrefix="uc2" %>

<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="cc1" %>

<asp:Content ID="Content3" ContentPlaceHolderID="MainContent" Runat="Server">

    <table width="100%" border="0" cellpadding="0" cellspacing="0">
        <tr>
            <td class="headtext">
                ข้อมูลการรับคืนวัสดุ</td>
        </tr>
        <tr>
             <td>
                
            </td>
        </tr>
        <tr>
            <td>
                <hr style="size:1px" />
                <asp:TextBox ID="txhSortField" runat="server" Visible="False" Width="15px"></asp:TextBox>
                <asp:TextBox ID="txhSortDir" runat="server" Visible="False" Width="15px"></asp:TextBox>
                <asp:TextBox ID="txhID" runat="server" Visible="False" Width="15px"></asp:TextBox>
                <asp:TextBox  ID="txtStatus" runat="server" Visible="False" Width="15px"></asp:TextBox>
            </td>
        </tr>
        <tr>
            <td style="height: 15px">
                <fieldset style="padding:15px;">
                    <legend style="font-weight:bold">ค้นหา</legend>
                        <table cellspacing="0" cellpadding="0" border="0" width="800">
                            <tr style="height:15px">
                                <td colspan="5"></td>
                            </tr>
                            <tr style="height:24px">
                                <td style="width:130px; text-align: right; padding-right:10px">เลขที่คืนคลัง :</td>
                                <td style="width:140px;"><asp:TextBox ID="txtSearch" runat="server" CssClass="zTextbox" Width="125px" MaxLength="20"></asp:TextBox></td>
                                <td style="width:30px; text-align:center;">ถึง</td>
                                <td style="width:160px;"><asp:TextBox ID="txtSearchTo" runat="server" CssClass="zTextbox" Width="125px" MaxLength="20"></asp:TextBox></td>
                                <td></td>
                            </tr>
                            <tr style="height:24px">
                                <td style="width:130px; text-align: right; padding-right:10px">วันที่คืนคลัง :</td>
                                <td style="width:140px;">
                                    <uc3:CalendarControl ID="ctlDateFrom" runat="server" /></td>
                                <td style="width:30px; text-align:center;">ถึง</td>
                                <td style="width:160px;">
                                    <uc3:CalendarControl ID="ctlDateTo" runat="server" /></td>
                                <td></td>
                            </tr>
                            <tr style="height:24px">
                                <td style="width:130px; text-align: right; padding-right:10px">คลังที่รับคืน :</td>
                                <td style="width:200px;" colspan="4"><asp:DropDownList ID="cmbWarehouse" runat="server" Width="302px" CssClass="zComboBox"></asp:DropDownList></td>
                             </tr>
                            <tr style="height:24px">
                                <td style="width:130px; text-align: right; padding-right:10px">สถานะ :</td>
                                <td style="width:140px;"><asp:DropDownList ID="cmbSearcStatusFrom" runat="server" Width="131px" CssClass="zComboBox"></asp:DropDownList></td>
                                <td style="width:30px; text-align:center;">ถึง</td>
                                <td style="width:160px;"><asp:DropDownList ID="cmbSearchStatusTo" runat="server" Width="131px" CssClass="zComboBox"></asp:DropDownList></td>
                                <td>
                                    &nbsp;<asp:ImageButton ID="imbSearch" runat="server" ImageAlign="AbsMiddle" ImageUrl="~/Images/icn_find.png"  Onclick="imbSearch_Click" />
                                    &nbsp;&nbsp;<asp:ImageButton ID="imbReset" runat="server" ImageAlign="AbsMiddle" ImageUrl="~/Images/icn_back.png"
                                      Onclick="imbReset_Click" ToolTip="แสดงทั้งหมด" />
                                </td>
                            </tr>
                        </table>
                    </fieldset>
                </td>
                </tr>
        
        <tr>
            <td style="height:15px">
                <asp:Label ID="lbStatusMain" runat="server" EnableViewState="False"></asp:Label>
            </td>
        </tr>
        
        <tr>
            <td  >
                <uc2:PageControl ID="pcTop" runat="server"  OnPageChange="PageChange" />
                <asp:GridView ID="gvMain" runat="server" AllowSorting="True" AutoGenerateColumns="False" CssClass="t_tablestyle"   OnRowDataBound="gvMain_RowDataBound" OnSorting="gvMain_Sorting"   AllowPaging="True" PageSize="20"  style="width:100%;">
                    <Columns>
                        <asp:BoundField DataField="LOID" HeaderText="LOID">
                            <ControlStyle CssClass="zHidden" />
                            <FooterStyle CssClass="zHidden" />
                            <HeaderStyle CssClass="zHidden" />
                            <ItemStyle CssClass="zHidden" />
                        </asp:BoundField> 
                        <asp:TemplateField HeaderText="ลำดับ" SortExpression="DEFAULT">
                            <HeaderStyle Width="60px" />
                            <ItemStyle HorizontalAlign="Center" Width="60px" Height="20px" />
                        </asp:TemplateField>
                        <asp:TemplateField SortExpression="CODE" HeaderText="เลขที่คืนคลัง">
                            <ItemStyle Width="120px" HorizontalAlign="center"></ItemStyle>
                            <HeaderStyle Width="120px" HorizontalAlign="Center"></HeaderStyle>
                            <ItemTemplate>
                            <asp:LinkButton ID="lnkCode" runat="server" Text='<%# Bind("CODE") %>' CommandArgument='<%# Bind("LOID")  %>' OnClick= "linkCode_Click" ></asp:LinkButton>
                            </ItemTemplate>
                        </asp:TemplateField>
                        <asp:BoundField HtmlEncode="False" DataFormatString="{0:dd/MM/yyyy}" DataField="STOCKINDATE" SortExpression="STOCKINDATE" HeaderText="วันที่คืนคลัง">
                            <ItemStyle Width="100px" HorizontalAlign="center" ></ItemStyle>
                            <HeaderStyle Width="100px" HorizontalAlign="Center"></HeaderStyle>
                        </asp:BoundField>
                        <asp:BoundField HtmlEncode="False"  DataField="DIVISIONNAME" SortExpression="DIVISIONNAME" HeaderText="หน่วยงานที่ส่งคืน">
                        </asp:BoundField>
                        <asp:BoundField DataField="WAREHOUSENAME" SortExpression="WAREHOUSENAME" HeaderText="คลังที่รับคืน">
                        </asp:BoundField>
                        <asp:BoundField DataField="STATUSNAME" SortExpression="STATUSNAME" HeaderText="สถานะ">
                            <ItemStyle Width="100px"></ItemStyle>
                            <HeaderStyle Width="100px" HorizontalAlign="Center"></HeaderStyle>
                        </asp:BoundField>
                        
                    </Columns>
                   <HeaderStyle CssClass="t_headtext" />
                    <AlternatingRowStyle CssClass="t_alt_bg" />
                    <PagerSettings Visible="False" />
                </asp:GridView><uc2:PageControl ID="pcBot" runat="server" OnPageChange="PageChange"  />
                </td>
        </tr>
    </table>



</asp:Content>
