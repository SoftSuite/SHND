<%@ Page Language="C#" MasterPageFile="~/Templates/Page1.master" AutoEventWireup="true" CodeFile="SystemMenu.aspx.cs" Inherits="App_Admin_Master_SystemMenu" Title="SHND : Master - System Menu" %>
<%@ Register Src="../../Templates/CalendarControl.ascx" TagName="CalendarControl" TagPrefix="uc3" %>
<%@ Register Src="../../Templates/PageControl.ascx" TagName="PageControl" TagPrefix="uc2" %>
<%@ Register Src="../../Templates/ToolBarItemCtl.ascx" TagName="ToolBarItemCtl" TagPrefix="uc1" %>
<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="cc1" %>


<asp:Content ID="Content3" ContentPlaceHolderID="MainContent" Runat="Server">

<table width="100%" border="0" cellpadding="0" cellspacing="0">
    <tr>
           <td class="headtext">
               เมนูการใช้งาน</td>
                    
    </tr>
    <tr>  
        <td style="width: 25778px">
                <uc1:ToolBarItemCtl ID="tbAdd" runat="server" ToobarTitle="เพิ่มข้อมูล"  OnClick="tbAddClick"  ToolbarImage="../../Images/icn_add.png"  />
               
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
                        <td style="width:120px; text-align: right; padding-right:10px; height: 24px;">ระบบ :</td>
                        <td style="height: 24px"><asp:DropDownList ID="cmbNAME" runat="server" Width="356px" CssClass="zComboBox">
                </asp:DropDownList>
                    </td>
                    </tr>
                 <tr>
                     <td style="padding-right: 10px; width: 120px; height: 24px; text-align: right">
                         กลุ่ม :</td>
                     <td style="height: 24px">
                         <asp:DropDownList ID="cmbSGroup" runat="server" Width="356px" CssClass="zComboBox">
                         </asp:DropDownList></td>
                 </tr>
                    <tr>
                        <td style="width:120px; text-align: right; padding-right:10px">ชื่อเมนู :</td>
                        <td style="height: 24px"><asp:TextBox ID="txtSearch" runat="server" CssClass="zTextbox" MaxLength="50" Width="350px"></asp:TextBox>
                        &nbsp; &nbsp;<asp:ImageButton ID="imbSearch" runat="server" ImageAlign="AbsMiddle" ImageUrl="~/Images/icn_find.png"
                         OnClick="imbSearch_Click1"  />
                         &nbsp;
                        <asp:ImageButton ID="imbReset" runat="server" ImageAlign="AbsMiddle" ImageUrl="~/Images/icn_back.png"
                         OnClick="imbReset_Click"  ToolTip="แสดงทั้งหมด" Visible = "false"  />
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
            <td >
                <uc2:PageControl ID="pcTop" runat="server" OnPageChange="PageChange"  Visible = "false" />
                   <asp:GridView ID="gvMain" runat="server" AllowSorting="True"  CssClass="t_tablestyle"  AutoGenerateColumns="False" OnRowDataBound="gvMain_RowDataBound" OnSorting="gvMain_Sorting"   AllowPaging="True" PageSize="20" style="width:100%;">
                    <Columns>
                        <asp:BoundField DataField="LOID" HeaderText="LOID">
                            <ControlStyle CssClass="zHidden" />
                            <FooterStyle CssClass="zHidden" />
                            <HeaderStyle CssClass="zHidden" />
                            <ItemStyle CssClass="zHidden" />
                        </asp:BoundField>
                         <asp:TemplateField>
                            <ItemTemplate>
                            <asp:ImageButton ID="imbDelete" runat="server" CausesValidation="true" CommandName="Delete" ImageUrl="~/Images/icn_delete.png" OnClientClick="return confirm('ต้องการลบข้อมูล ใช่หรือไม่?')"  OnClick="tbDeleteClick"  CommandArgument='<%# Bind("LOID")  %>' />&nbsp;
                            </ItemTemplate>
                            <HeaderStyle HorizontalAlign="Center" Width="30px" />
                            <ItemStyle HorizontalAlign="Center" Width="30px" />
                        </asp:TemplateField>
                        <asp:TemplateField HeaderText="ลำดับ" SortExpression="DEFAULT">
                            <HeaderStyle Width="60px" />
                            <ItemStyle HorizontalAlign="Center" Width="60px" />
                        </asp:TemplateField>
                       <asp:TemplateField HeaderText="ชื่อเมนู" SortExpression="MENUNAME">
                              <HeaderStyle HorizontalAlign="Center" Width="200px" />
                            <ItemStyle Width="200px"  />
                            <ItemTemplate>                      
                            <asp:LinkButton ID="lnkCode" runat="server" Text='<%# Bind("MENUNAME") %>' CommandArgument='<%# Bind("LOID")  %>' OnClick= "linkCode_Click"  ></asp:LinkButton>
                            </ItemTemplate> 
                      </asp:TemplateField>
                        <asp:BoundField  DataField="DESCRIPTION" HeaderText="รายละเอียด" SortExpression="DESCRIPTION">
                          </asp:BoundField>
                        <asp:BoundField DataField="SYSTEMNAME" HeaderText="ระบบ" SortExpression="SYSTEMNAME">
                            <HeaderStyle Width="150px" />
                            <ItemStyle Width="150px" />
                        </asp:BoundField>
                        <asp:BoundField DataField="GROUPNAME" HeaderText="กลุ่ม" SortExpression="GROUPNAME">
                            <HeaderStyle Width="100px" />
                            <ItemStyle Width="100px" />
                        </asp:BoundField>
                        <asp:BoundField DataField="SEQUENCE" HeaderText="ลำดับแสดง">
                            <HeaderStyle Width="50px" />
                            <ItemStyle HorizontalAlign="Center" Width="50px" />
                        </asp:BoundField>
                          <asp:BoundField DataField="ENABLED" HeaderText="แสดง" SortExpression="ENABLED">
                            <HeaderStyle HorizontalAlign="Center" Width="60px" />
                            <ItemStyle HorizontalAlign="Center" Width="60px" />
                        </asp:BoundField>
                 
                        
                        </Columns> 
                         <HeaderStyle CssClass="t_headtext" />  
                    <AlternatingRowStyle CssClass="t_alt_bg" />
                    <PagerSettings Visible="False" />
                        </asp:GridView> <uc2:PageControl ID="pcBot" runat="server"  OnPageChange="PageChange" Visible = "false"   />
                        </td> 
                        </tr> 
         </table> 
<cc1:ModalPopupExtender ID="zPop" runat="server" TargetControlID="tbAdd$lb" PopupControlID="Panel1" BackgroundCssClass="modalBackground" DropShadow="true"></cc1:ModalPopupExtender>
    <asp:Panel ID="Panel1" runat="server" CssClass="modalPopup" style="display:none" Width="800px">
    <table cellspacing="0" cellpadding="0" border="0" width="100%">
        
        <tr>
            <td>
            <uc1:ToolBarItemCtl ID="tbSave" runat="server" ToobarTitle="บันทึก" ToolbarImage="../../Images/save2.png" OnClick="tbSave1Click" />
            <uc1:ToolBarItemCtl ID="tbSave2" runat="server" ToobarTitle="ยกเลิกการแก้ไข" ToolbarImage="../../Images/cancel.png"  OnClick="tbCancelClick"  />
            <uc1:ToolBarItemCtl ID="tbBack" runat="server" ToobarTitle="กลับหน้ารายการ" ToolbarImage="../../Images/icn_back.png"  />
            </td>
        </tr>
        <tr>
            <td><hr style="size:1px" /></td>
        </tr>
        <tr>
            <td style="height: 198px">
                <table cellpadding="5">
                    <tr>
                        <td align="right" style="width: 169px">
                            <asp:TextBox ID="txhSortField" runat="server" Visible="False" Width="15px"></asp:TextBox><asp:TextBox
                                ID="txhSortDir" runat="server" Visible="False" Width="15px"></asp:TextBox><asp:TextBox
                                    ID="txhID" runat="server" Visible="False" Width="15px"></asp:TextBox></td>
                        <td style="height:15px; width: 614px;">
                            <asp:Label ID="lbStatus" runat="server" EnableViewState="False"></asp:Label>
                            </td>
                    </tr>
                     <tr>
                        <td style="width:169px" align="right"> ระบบ  :&nbsp;</td>
                        <td style="width: 614px">
                             <asp:DropDownList ID="cmbSysName" runat="server" CssClass="zComboBox" Width="356px" AutoPostBack="True"  OnSelectedIndexChanged="cmbSysName_SelectedIndexChanged" >
                            </asp:DropDownList>
                            <span style="color:red">*</span></td> 
                    </tr>
                    <tr>
                        <td style="width:169px; height: 32px;" align="right"> ชื่อเมนู :</td>
                        <td style="width: 614px; height: 32px">
                            <asp:TextBox ID="txtName" runat="server" CssClass="zTextbox" Width="350px" MaxLength="150"></asp:TextBox>
                            <span style="color:red">*</span></td>
                    </tr>
                    <tr>
                        <td style="width:169px; height: 32px;" align="right"> รายละเอียด :</td>
                        <td style="width: 614px; height: 32px">
                            <asp:TextBox ID="txtDESCRIPTION" runat="server" CssClass="zTextbox" Width="350px" MaxLength="150"></asp:TextBox>
                            </td>
                    </tr>
                    <tr>
                        <td style="width:169px; height: 32px;" align="right"> Link :</td>
                        <td style="width: 614px; height: 32px">
                            <asp:TextBox ID="txtLink" runat="server" CssClass="zTextbox" Width="350px" MaxLength="150"></asp:TextBox>
                            </td>
                    </tr>
                    <tr>
                        <td style="width:169px" align="right"> กลุ่ม :</td>
                        <td style="width: 614px">
                              <asp:DropDownList ID="cmbGroup" runat="server" CssClass="zComboBox" Width="356px">
                            </asp:DropDownList>
                            </td>
                    </tr>
                    <tr>
                        <td align="right" style="width: 169px">
                            ลำดับการแสดงผล</td>
                        <td style="width: 614px">
                            <asp:TextBox ID="txtSequence" runat="server" CssClass="zTextbox" MaxLength="3" Width="50px">0</asp:TextBox></td>
                    </tr>
                    <tr>
                        <td style="width:150px; height: 32px;" align="right">  </td>
                        <td style="width: 614px; height: 32px">
                            <asp:CheckBox ID="chkActive" runat="server" Checked="True" /> ใช้งาน</td>
                    </tr>
                       
           </table>
                <br />
                <br />
                <br />
            </td>
        </tr>
    </table>
</asp:Panel>
</asp:Content>



