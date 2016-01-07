<%@ Page Language="C#" MasterPageFile="~/Templates/Page1.master" AutoEventWireup="true" CodeFile="MilkCode.aspx.cs" Inherits="App_Admin_Master_MilkCode" Title="SHND : Master - Milk Code"  %>

<%@ Register Src="../../Templates/CalendarControl.ascx" TagName="CalendarControl" TagPrefix="uc3" %>
<%@ Register Src="../../Templates/PageControl.ascx" TagName="PageControl" TagPrefix="uc2" %>
<%@ Register Src="../../Templates/ToolBarItemCtl.ascx" TagName="ToolBarItemCtl" TagPrefix="uc1" %>
<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="cc1" %>


<asp:Content ID="Content3" ContentPlaceHolderID="MainContent" Runat="Server">

    <table width="100%" border="0" cellpadding="0" cellspacing="0">
    <tr>
           <td class="headtext">
               เบอร์นม</td>
                    
    </tr>
    <tr>  
        <td style="width: 25778px">
                <uc1:ToolBarItemCtl ID="tbAdd" runat="server" ToobarTitle="เพิ่มข้อมูล" OnClick="tbAddClick"  ToolbarImage="../../Images/icn_add.png"  />
                <uc1:ToolBarItemCtl ID="ToolBarItemCtl1" runat="server" ToobarTitle="ลบข้อมูลที่เลือก"  OnClick="tbDeleteClick"   ToolbarImage="../../Images/icn_delete.png" ClientClick="return confirm('ต้องการลบข้อมูลที่เลือก ใช่หรือไม่?')"  />
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
            <legend style="font-weight:bold">ค้นหา
            </legend>
            
             <table cellspacing="0" cellpadding="0" border="0" width="100%">
                    <tr style="height:15px">
                        <td colspan="2">&nbsp;</td>
                    </tr>
                 
                    <tr>
                        <td style="width:120px; text-align: right; padding-right:10px">หอผู้ป่วย :</td>
                        <td style="height: 22px">
                        <asp:DropDownList ID="cmbName1" runat="server" CssClass="zComboBox" Width="300px" AutoPostBack="True" >
                         </asp:DropDownList>
                        &nbsp; &nbsp;<asp:ImageButton ID="imbSearch" runat="server" ImageAlign="AbsMiddle" ImageUrl="~/Images/icn_find.png"
                         OnClick="imbSearch_Click1" />&nbsp;
                        <asp:ImageButton ID="imbReset" runat="server" ImageAlign="AbsMiddle" ImageUrl="~/Images/icn_back.png"
                         OnClick="imbReset_Click"  ToolTip="แสดงทั้งหมด" />
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
                <uc2:PageControl ID="pcTop" runat="server" OnPageChange="PageChange" />
                   <asp:GridView ID="gvMain" runat="server" AllowSorting="True" AutoGenerateColumns="False" CssClass="t_tablestyle"  OnRowDataBound="gvMain_RowDataBound" OnSorting="gvMain_Sorting"   AllowPaging="True" PageSize="20" style="width:100%;">
                    <Columns>
                        <asp:BoundField DataField="LOID" HeaderText="LOID">
                            <ControlStyle CssClass="zHidden" />
                            <FooterStyle CssClass="zHidden" />
                            <HeaderStyle CssClass="zHidden" />
                            <ItemStyle CssClass="zHidden" />
                        </asp:BoundField>
                         <asp:TemplateField>
                            <HeaderTemplate >
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
                       <asp:TemplateField HeaderText="หอผู้ป่วย" SortExpression="NAME">
                            <ItemTemplate>                      
                             <asp:LinkButton ID="lnkCode" runat="server" Text='<%# Bind("NAME") %>'  OnClick= "linkCode_Click"  CommandArgument='<%# Bind("LOID")  %>'></asp:LinkButton>
                            </ItemTemplate> 
                            <HeaderStyle HorizontalAlign="Center" Width="250px" />
                            <ItemStyle Width="250px" />
                      </asp:TemplateField>
                        <asp:BoundField  DataField="MILKCODE" HeaderText="เบอร์นม" SortExpression="MILKCODE">
                          </asp:BoundField>
                                       
                        
                        </Columns> 
                         <HeaderStyle CssClass="t_headtext" />  
                    <AlternatingRowStyle CssClass="t_alt_bg" />
                    <PagerSettings Visible="False" />
                        </asp:GridView> <uc2:PageControl ID="pcBot" runat="server"  OnPageChange="PageChange"  />
                        </td> 
                        </tr> 
         </table> 

    <cc1:ModalPopupExtender ID="zPop" runat="server" TargetControlID="tbAdd$lb" PopupControlID="Panel1" BackgroundCssClass="modalBackground" DropShadow="true"></cc1:ModalPopupExtender>
    <asp:Panel ID="Panel1" runat="server" CssClass="modalPopup" style="display:none" Width="800px" Height="600px" ScrollBars="Vertical" >
    <table cellspacing="0" cellpadding="0" border="0" width="100%">
        
        <tr>
            <td>
            <uc1:ToolBarItemCtl ID="tbSave" runat="server" ToobarTitle="บันทึก" ToolbarImage="../../Images/save2.png" OnClick="tbSave1Click"   />
            <uc1:ToolBarItemCtl ID="tbSave2" runat="server" ToobarTitle="บันทึกและเพิ่มรายการใหม่" ToolbarImage="../../Images/icn_save_add.png" OnClick="tbSave2Click"  />
            <uc1:ToolBarItemCtl ID="tbSave3" runat="server" ToobarTitle="ยกเลิกการแก้ไข" ToolbarImage="../../Images/cancel.png"  OnClick="tbCancelClick"   />
            <uc1:ToolBarItemCtl ID="tbBack" runat="server" ToobarTitle="กลับหน้ารายการ" ToolbarImage="../../Images/icn_back.png"  OnClick="tbBackClick"  />
            </td>
        </tr>
        <tr>
            <td><hr style="size:1px" /></td>
        </tr>
        <tr>
             <td >
                <table cellpadding="5" >
                    <tr>
                        <td align="right" style="width: 240px" >
                            <asp:TextBox ID="txhSortField" runat="server" Visible="False" Width="15px"></asp:TextBox><asp:TextBox
                                ID="txhSortDir" runat="server" Visible="False" Width="15px"></asp:TextBox><asp:TextBox
                                    ID="txhID" runat="server" Visible="False" Width="15px"></asp:TextBox></td>
                        <td style="height:15px; width: 614px;">
                            <asp:Label ID="lbStatus" runat="server" EnableViewState="False"></asp:Label></td>
                    </tr>
                     <tr>
                        <td style="width:240px" align="right"> หอผู้ป่วย :</td>
                        <td style="width: 614px">
                          <asp:DropDownList ID="cmbName2" runat="server" CssClass="zComboBox" Width="306px" AutoPostBack="True" OnSelectedIndexChanged="cmbName2_SelectedIndexChanged" ></asp:DropDownList>
                            <span style="color:red">*</span> </td>
                    </tr>
                    <tr>
                        <td style="width:240px; height: 32px;" align="right"> เพิ่มเบอร์นม :</td>
                        <td style="width: 614px; height: 32px">
                            <asp:TextBox ID="txtName" runat="server" CssClass="zTextbox" Width="300px" MaxLength="150"></asp:TextBox>
                            <span style="color:red">*</span> &nbsp; &nbsp;  
                            <asp:ImageButton ID="imbAdd" runat="server" ImageAlign="AbsMiddle" ImageUrl="~/Images/icn_add.png"
                            OnClick="imbAdd_Click"  /></td>
                    </tr>
     
               
                 </table>
                <br />
                <br />
           </tr>
                   
         <tr>
                <td style="padding-left:250px">
                    <asp:GridView ID="gvMain1" runat="server" AutoGenerateColumns="False" CssClass="t_tablestyle"  DataSourceID="MilkCodeSource" DataKeyNames="LOID" OnRowUpdated="gvMain1_RowUpdated" OnRowUpdating="gvMain1_RowUpdating" OnRowCommand="gvMain1_RowCommand" >
                        <PagerSettings Visible="False" />
                        <Columns>
                            <asp:BoundField DataField="LOID" HeaderText="LOID">
                                <ControlStyle CssClass="zHidden"></ControlStyle>
                                <ItemStyle CssClass="zHidden"></ItemStyle>
                                <HeaderStyle CssClass="zHidden"></HeaderStyle>
                                <FooterStyle CssClass="zHidden"></FooterStyle>
                            </asp:BoundField>
                            <asp:TemplateField>
                                <EditItemTemplate>
                                    <asp:ImageButton ID="imbSave" runat="server" ImageUrl="~/Images/save2.gif"  CommandName="Update" />
                                    <asp:ImageButton ID="imbCancel" runat = "server" ImageUrl ="~/Images/icn_back.png" CommandName="Cancel" />
                                </EditItemTemplate>
                                <ItemTemplate>
                                    <asp:ImageButton ID="imbEdit" runat="server" CausesValidation="true" CommandName="Edit" ImageUrl="~/Images/icn_edit.png"  />
                                    <asp:ImageButton ID="imbDelete" runat="server" CausesValidation="true" CommandName="Delete" ImageUrl="~/Images/icn_delete.png" OnClientClick="return confirm('ต้องการลบข้อมูล ใช่หรือไม่?')" />&nbsp;
                                </ItemTemplate>
                                <ItemStyle Width="60px" HorizontalAlign="Center"></ItemStyle>
                                <HeaderStyle Width="60px" HorizontalAlign="Center"></HeaderStyle>
                                <FooterStyle Width="60px" HorizontalAlign="Center"></FooterStyle>
                            </asp:TemplateField>
                            <asp:TemplateField SortExpression="MILKCODE" HeaderText="เบอร์นม">
                                <EditItemTemplate>
                                    <asp:TextBox ID="txtMilkCode" runat="server" Text='<%# Bind("MILKCODE") %>' width="100px" CssClass="zTextbox" MaxLength="10"></asp:TextBox>
                                </EditItemTemplate>
                                <ItemTemplate>
                                    <asp:Label ID="lblMilkCode" runat="server" Text='<%# Bind("MILKCODE") %>'></asp:Label>
                                </ItemTemplate> 
                                <ItemStyle Width="105px" HorizontalAlign="left" />
                                <HeaderStyle Width="105px" />
                            </asp:TemplateField>
                        </Columns>
                        <HeaderStyle CssClass="t_headtext" />  
                        <AlternatingRowStyle CssClass="t_alt_bg" />
                    </asp:GridView>
                    <asp:ObjectDataSource ID="MilkCodeSource" runat="server" SelectMethod="GetMilkCodeDiseaseList" TypeName="MilkCodeDetailItem" DeleteMethod="DeleteMildCode" UpdateMethod="UpdateMilkCode">
                        <deleteparameters>
                            <asp:Parameter Type="Double" Name="LOID"></asp:Parameter>
                        </deleteparameters>
                        <updateparameters>
                            <asp:Parameter Type="Double" Name="LOID"></asp:Parameter>
                            <asp:Parameter Type="String" Name="milkCode"></asp:Parameter>
                        </updateparameters>
                        <SelectParameters>
                            <asp:ControlParameter PropertyName="SelectedValue" Type="Double" DefaultValue="0" Name="ward" ControlID="cmbName2"></asp:ControlParameter>
                        </SelectParameters>
                    </asp:ObjectDataSource>
                </td>
            </tr>
    </table>
    </asp:Panel>


</asp:Content>
