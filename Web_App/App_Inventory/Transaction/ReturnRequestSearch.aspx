<%@ Page Language="C#" MasterPageFile="~/Templates/Page1.master" AutoEventWireup="true" CodeFile="ReturnRequestSearch.aspx.cs" Inherits="App_Inventory_Transaction_ReturnRequestSearch" Title="SHND : Transaction - Return Requisition"  %>

<%@ Register Src="../../Templates/CalendarControl.ascx" TagName="CalendarControl" TagPrefix="uc3" %>
<%@ Register Src="../../Templates/PageControl.ascx" TagName="PageControl" TagPrefix="uc2" %>
<%@ Register Src="../../Templates/ToolBarItemCtl.ascx" TagName="ToolBarItemCtl" TagPrefix="uc1" %>
<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="cc1" %>

<asp:Content ID="Content3" ContentPlaceHolderID="MainContent" Runat="Server">

    <table width="100%" border="0" cellpadding="0" cellspacing="0">
        <tr>
            <td class="headtext">
                ข้อมูลการคืนคลัง</td>
        </tr>
        <tr>
             <td>
                <uc1:ToolBarItemCtl ID="tbAdd" runat="server" ToobarTitle="เพิ่มข้อมูล"  ToolbarImage="../../Images/icn_add.png" OnClick= "tbAddClick"  />
                <uc1:ToolBarItemCtl ID="tbDel" runat="server" ToobarTitle="ลบข้อมูลที่เลือก"  ToolbarImage="../../Images/icn_delete.png" ClientClick="return confirm('ต้องการลบข้อมูลที่เลือก ใช่หรือไม่?')"  OnClick="tbDeleteClick"   />
                <uc1:ToolBarItemCtl ID="tbSend" runat="server" ToobarTitle="ส่งข้อมูล"  ToolbarImage="../../Images/icn_approve.png" ClientClick="return confirm('ต้องการส่งข้อมูลที่เลือก ใช่หรือไม่?')"  OnClick="tbSendClick"   />
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
                                <td style="width:130px; text-align: right; padding-right:10px; height: 24px;">เลขที่คืนคลัง :</td>
                                <td style="width:140px; height: 24px;"><asp:TextBox ID="txtSearch" runat="server" CssClass="zTextbox" Width="125px" MaxLength="20"></asp:TextBox></td>
                                <td style="width:30px; text-align:center; height: 24px;">ถึง</td>
                                <td style="width:160px; height: 24px;"><asp:TextBox ID="txtSearchTo" runat="server" CssClass="zTextbox" Width="125px" MaxLength="20"></asp:TextBox></td>
                                <td style="height: 24px"></td>
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
                                <td style="width:130px; text-align: right; padding-right:10px; height: 24px;">สถานะ :</td>
                                <td style="width:140px; height: 24px;"><asp:DropDownList ID="cmbSearcStatusFrom" runat="server" Width="131px" CssClass="zComboBox"></asp:DropDownList></td>
                                <td style="width:30px; text-align:center; height: 24px;">ถึง</td>
                                <td style="width:160px; height: 24px;"><asp:DropDownList ID="cmbSearchStatusTo" runat="server" Width="131px" CssClass="zComboBox"></asp:DropDownList></td>
                                <td style="height: 24px">
                                    &nbsp;<asp:ImageButton ID="imbSearch" runat="server" ImageAlign="AbsMiddle" ImageUrl="~/Images/icn_find.png" onclick = "imbSearch_Click" />
                                    &nbsp;
                                    <asp:ImageButton ID="imbReset" runat="server" ImageAlign="AbsMiddle" ImageUrl="~/Images/icn_back.png"
                                      OnClick="imbReset_Click" ToolTip="แสดงทั้งหมด" />
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
                <uc2:PageControl ID="pcTop" runat="server" OnPageChange="PageChange" />
                <asp:GridView ID="gvMain" runat="server" AllowSorting="True" AutoGenerateColumns="False" CssClass="t_tablestyle"  OnRowDataBound="gvMain_RowDataBound" 
                    OnSorting="gvMain_Sorting"   AllowPaging="True" PageSize="20"  style="width:100%;">
                    <Columns>
                        <asp:BoundField DataField="LOID" HeaderText="LOID">
                            <ControlStyle CssClass="zHidden" />
                            <FooterStyle CssClass="zHidden" />
                            <HeaderStyle CssClass="zHidden" />
                            <ItemStyle CssClass="zHidden" />
                        </asp:BoundField>
                        
                        <asp:TemplateField>
                            <HeaderTemplate>
                                <input type="checkbox" name="chkMain" id="chkMain" onclick="chkAllBox(this, 'ctl00_MainContent_gvMain_ctl', '_chkSelect')"  />
                            </HeaderTemplate>
                            <ItemTemplate>
                                <asp:CheckBox ID="chkSelect" runat="server"  Enabled='<%# Eval("STATUS").ToString() == "WA" || Eval("STATUS").ToString() == "NP" %>'   />
                            </ItemTemplate>
                            <HeaderStyle HorizontalAlign="Center" Width="30px" />
                            <ItemStyle HorizontalAlign="Center" Width="30px" />
                        </asp:TemplateField>
                        
                        <asp:TemplateField HeaderText="ลำดับ" SortExpression="DEFAULT">
                            <HeaderStyle Width="60px" />
                            <ItemStyle HorizontalAlign="Center" Width="60px" />
                        </asp:TemplateField>
                        
                        <asp:TemplateField SortExpression="CODE" HeaderText="เลขที่คืนคลัง">
                            <ItemStyle Width="130px" HorizontalAlign="center"></ItemStyle>
                            <HeaderStyle Width="130px" HorizontalAlign="Center"></HeaderStyle>
                            <ItemTemplate>
                            <asp:LinkButton ID="lnkCode" runat="server" Text='<%# Bind("CODE") %>' CommandArgument='<%# Bind("LOID")  %>' OnClick= "linkCode_Click"  ></asp:LinkButton>
                            </ItemTemplate>
                        </asp:TemplateField>
                        <asp:BoundField HtmlEncode="False" DataFormatString="{0:dd/MM/yyyy}" DataField="STOCKINDATE" SortExpression="STOCKINDATE" HeaderText="วันที่คืนคลัง">
                            <ItemStyle Width="100px" HorizontalAlign="center"></ItemStyle>
                            <HeaderStyle Width="100px" HorizontalAlign="Center"></HeaderStyle>
                        </asp:BoundField>
                        <asp:BoundField HtmlEncode="False"  DataField="DIVISIONNAME" SortExpression="DIVISIONNAME" HeaderText="หน่วยที่ส่งคืน">
                        </asp:BoundField>
                        <asp:BoundField HtmlEncode="False"  DataField="WAREHOUSENAME" SortExpression="WAREHOUSENAME" HeaderText="คลังที่รับคืน">
                        </asp:BoundField>
                        <asp:BoundField DataField="STATUSNAME" SortExpression="STATUSNAME" HeaderText="สถานะ">
                            <ItemStyle Width="100px"></ItemStyle>
                            <HeaderStyle Width="100px" HorizontalAlign="Center"></HeaderStyle>
                        </asp:BoundField>
                        
                    </Columns>
                   <HeaderStyle CssClass="t_headtext" />
                    <AlternatingRowStyle CssClass="t_alt_bg" />
                    <PagerSettings Visible="False" />
                </asp:GridView><uc2:PageControl ID="pcBot" runat="server"  OnPageChange="PageChange"  />
                </td>
        </tr>
    </table>



</asp:Content>

