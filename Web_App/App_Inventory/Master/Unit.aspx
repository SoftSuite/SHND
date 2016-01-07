<%@ Page Language="C#" MasterPageFile="~/Templates/Page1.master" AutoEventWireup="true" CodeFile="Unit.aspx.cs" Inherits="App_Inventory_Master_Unit" Title="SHND : Master - Unit" %>

<%@ Register Src="../../Templates/MenuCtl.ascx" TagName="MenuCtl" TagPrefix="uc3" %>
<%@ Register Src="../../Templates/PageControl.ascx" TagName="PageControl" TagPrefix="uc2" %>
<%@ Register Src="../../Templates/ToolBarItemCtl.ascx" TagName="ToolBarItemCtl" TagPrefix="uc1" %>
<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="cc1" %>

<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" Runat="Server">
    <table width="100%" border="0" cellpadding="0" cellspacing="0">
        <tr>
            <td class="headtext">
                ข้อมูลหน่วยนับ</td>
        </tr>
    </table>
    <table width="100%" border="0" cellpadding="0" cellspacing="0">
        <tr>
            <td>
                <uc1:ToolBarItemCtl ID="tbAdd" runat="server" ToobarTitle="เพิ่มข้อมูล" OnClick="tbAddClick"   ToolbarImage="../../Images/icn_add.png"  />
                <uc1:ToolBarItemCtl ID="ToolBarItemCtl1" runat="server" ToobarTitle="ลบข้อมูลที่เลือก" ToolbarImage="../../Images/icn_delete.png"  OnClick="tbDeleteClick" ClientClick="return confirm('ต้องการลบข้อมูลที่เลือก ใช่หรือไม่?')"  />
            </td>
        </tr>
        <tr>
            <td>
                <hr style="size:1px" />
            </td>
        </tr>
        <tr>
            <td style="height: 15px">
            <fieldset style="padding:15px;">
            <legend style="font-weight:bold">
                ค้นหา
            </legend>
            
                <table cellspacing="0" cellpadding="0" border="0" width="100%">
                    <tr style="height:15px">
                        <td colspan="2">&nbsp;</td>
                    </tr>
                    <tr>
                        <td style="width:120px; text-align: right; padding-right:10px">ชื่อภาษาไทย :</td>
                        <td><asp:TextBox ID="txtSearchThai" runat="server" CssClass="zTextbox" MaxLength="50" Width="200px"></asp:TextBox>
                        
                    </tr>
                    <tr>
                        <td style="width:120px; text-align: right; padding-right:10px">ชื่อภาษาอังกฤษ :</td>
                        <td>
                            <asp:TextBox ID="txtSearchEng" runat="server" CssClass="zTextbox" MaxLength="50" Width="200px"></asp:TextBox>&nbsp; &nbsp;
                            <asp:ImageButton ID="imbSearch" runat="server" ImageAlign="AbsMiddle" ImageUrl="~/Images/icn_find.png" OnClick="imbSearch_Click" />
                            <asp:ImageButton ID="imbReset" runat="server" ImageAlign="AbsMiddle" ImageUrl="~/Images/icn_back.png" OnClick="imbReset_Click" ToolTip="แสดงทั้งหมด" />
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
            <td>
                <uc2:PageControl ID="pcTop" runat="server"  OnPageChange="PageChange" />
                <asp:GridView ID="grvResult" runat="server" AllowSorting="True" AutoGenerateColumns="False" CssClass="t_tablestyle" AllowPaging="True" PageSize="20" 
                    OnRowDataBound="grvResult_RowDataBound" OnSorting="grvResult_Sorting" Width="100%">
                    <Columns>
                        <asp:BoundField DataField="LOID" HeaderText="LOID">
                            <ControlStyle CssClass="zHidden" />
                            <FooterStyle CssClass="zHidden" />
                            <HeaderStyle CssClass="zHidden" />
                            <ItemStyle CssClass="zHidden" />
                        </asp:BoundField>
                        <asp:TemplateField>
                            <HeaderTemplate>
                                <input type="checkbox" name="chkMain" id="chkMain" onclick="chkAllBox(this, 'ctl00_MainContent_gvMain_ctl', '_chkSelect')" />
                            </HeaderTemplate>
                            <ItemTemplate>
                                <asp:CheckBox ID="chkSelect" runat="server" />
                            </ItemTemplate>
                            <HeaderStyle HorizontalAlign="Center" Width="30px" />
                            <ItemStyle HorizontalAlign="Center" Width="30px" />
                        </asp:TemplateField>
                        <asp:TemplateField HeaderText="ลำดับ" SortExpression="DEFAULT">
                            <HeaderStyle Width="60px" />
                            <ItemStyle HorizontalAlign="Center" Width="60px" />
                        </asp:TemplateField>
                         <asp:BoundField DataField="CODE" HeaderText="รหัส" SortExpression="CODE">
                            <HeaderStyle HorizontalAlign="Center" Width="100px" />
                            <ItemStyle HorizontalAlign="Center" Width="100px" />
                        </asp:BoundField>
                        
                        <asp:TemplateField HeaderText="ชื่อภาษาไทย" SortExpression="THNAME">
                            <ItemTemplate>
                                <asp:LinkButton ID="lnkNameThai" runat="server"  OnClick="lnkNameThai_Click"   Text='<%# Bind("THNAME") %>' CommandArgument='<%# Bind("LOID")  %>'></asp:LinkButton>
                            </ItemTemplate>
                        </asp:TemplateField>
                        
                        <asp:BoundField DataField="ENNAME" HeaderText="ชื่่อภาษาอังกฤษ" SortExpression="ENNAME">
                        </asp:BoundField>
                        
                        <asp:BoundField DataField="ACTIVENAME" HeaderText="การใช้งาน" SortExpression="ACTIVENAME">
                            <HeaderStyle HorizontalAlign="Center" Width="100px" />
                            <ItemStyle HorizontalAlign="Center" Width="100px" />
                        </asp:BoundField>
                    </Columns>
                    <HeaderStyle CssClass="t_headtext" />
                    <AlternatingRowStyle CssClass="t_alt_bg" />
                    <PagerSettings Visible="False" />
                </asp:GridView><uc2:PageControl ID="pcBot" runat="server"  OnPageChange="PageChange" />
                </td>
        </tr>
    </table>
    <cc1:ModalPopupExtender ID="UnitPop" runat="server" TargetControlID="tbAdd$lb" PopupControlID="Panel1" BackgroundCssClass="modalBackground" DropShadow="true"></cc1:ModalPopupExtender>
    <asp:Panel ID="Panel1" runat="server" CssClass="modalPopup" style="display:none" Width="800px">
    <table cellspacing="0" cellpadding="0" border="0" width="100%">
        <tr>
            <td>
        <uc1:ToolBarItemCtl ID="tbSave" runat="server" ToobarTitle="บันทึก" ToolbarImage="../../Images/save2.png"  OnClick="tbSave1Click" />
        <uc1:ToolBarItemCtl ID="tbSave2" runat="server" ToobarTitle="บันทึกและเพิ่มรายการใหม่" ToolbarImage="../../Images/icn_save_add.png" OnClick="tbSave2Click"  />
        <uc1:ToolBarItemCtl ID="tbReturn" runat="server" ToobarTitle="ยกเลิกการแก้ไข" ToolbarImage="../../Images/cancel.png"   OnClick="tbReturnClick"  />
        <uc1:ToolBarItemCtl ID="tbBack" runat="server" ToobarTitle="กลับหน้ารายการ" ToolbarImage="../../Images/icn_back.png"  OnClick="tbBackClick"/>
            </td>
        </tr>
        <tr>
            <td><hr style="size:1px" /></td>
        </tr>
        <tr>
            <td>
                <table cellpadding="5">
                    <tr>
                        <td align="right" style="width: 150px">
                            <asp:TextBox ID="txhSortField" runat="server" Visible="False" Width="15px"></asp:TextBox><asp:TextBox
                                ID="txhSortDir" runat="server" Visible="False" Width="15px"></asp:TextBox><asp:TextBox
                                    ID="txhID" runat="server" Visible="False" Width="15px"></asp:TextBox></td>
                        <td style="height:15px">
                            <asp:Label ID="lbStatus" runat="server" EnableViewState="False"></asp:Label></td>
                    </tr>
                    <tr>
                        <td style="width:150px" align="right"> รหัส :</td>
                        <td>
                            <asp:TextBox ID="txtCode" runat="server" CssClass="zTextbox-View" Width="150px" MaxLength="20"></asp:TextBox> <span style="color:red"></span></td>
                    </tr>
                    <tr>
                        <td style="width:150px" align="right"> ชื่อย่อ:</td>
                        <td>
                            <asp:TextBox ID="txtABB" runat="server" CssClass="zTextbox" Width="148px" MaxLength="50"></asp:TextBox><span
                                style="color: #ff0000">*</span><span style="color:red"></span></td>
                    </tr>
                    <tr>
                        <td style="width:150px" align="right"> ชื่อภาษาไทย :</td>
                        <td>
                            <asp:TextBox ID="txtThai" runat="server" CssClass="zTextbox" Width="490px" MaxLength="50"></asp:TextBox><span style="color:red">*</span></td>
                    </tr>
                    <tr>
                        <td style="width:150px" align="right"> ชื่อภาษาอังกฤษ :</td>
                        <td>
                            <asp:TextBox ID="txtEng" runat="server" CssClass="zTextbox" Width="490px" MaxLength="50"></asp:TextBox><span style="color:red"></span></td>
                    </tr>
                    <tr>
                        <td style="width:150px" align="right"> ใช้งาน :</td>
                        <td>
                            <asp:CheckBox ID="chkActive" runat="server" Checked="True" /></td>
                    </tr>
                    
                </table>
                <br />
                <br />
            </td>
        </tr>
    </table>
    </asp:Panel>
</asp:Content>


