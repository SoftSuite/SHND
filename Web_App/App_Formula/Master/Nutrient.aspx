<%@ Page Language="C#" MasterPageFile="~/Templates/Page1.master" AutoEventWireup="true" CodeFile="Nutrient.aspx.cs" Inherits="App_Formula_Master_Nutrient" Title="SHND : Master - Nutrient"%>

<%@ Register Src="../../Templates/CalendarControl.ascx" TagName="CalendarControl" TagPrefix="uc3" %>
<%@ Register Src="../../Templates/PageControl.ascx" TagName="PageControl" TagPrefix="uc2" %>
<%@ Register Src="../../Templates/ToolBarItemCtl.ascx" TagName="ToolBarItemCtl" TagPrefix="uc1" %>
<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="cc1" %>

<asp:Content ID="Content3" ContentPlaceHolderID="MainContent" Runat="Server">

<table width="100%" border="0" cellpadding="0" cellspacing="0">
    <tr>
           <td class="headtext">
               ��������</td>
                    
    </tr>
    <tr>  
        <td style="width: 25778px">
                <uc1:ToolBarItemCtl ID="tbAdd" runat="server" ToobarTitle="����������" OnClick="tbAddClick"  ToolbarImage="../../Images/icn_add.png"  />
                <uc1:ToolBarItemCtl ID="ToolBarItemCtl1" runat="server" ToobarTitle="ź�����ŷ�����͡" OnClick="tbDeleteClick"  ToolbarImage="../../Images/icn_delete.png" ClientClick="return confirm('��ͧ���ź�����ŷ�����͡ ���������?')"  />
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
                ����
            </legend>
            
             <table cellspacing="0" cellpadding="0" border="0" width="100%">
                    <tr style="height:15px">
                        <td colspan="2" style="height: 15px">&nbsp;</td>
                    </tr>
                 
                    <tr>
                        <td style="width:120px; text-align: right; padding-right:10px">������������ :</td>
                        <td style="height: 22px"><asp:TextBox ID="txtSearch" runat="server" CssClass="zTextbox" MaxLength="50" Width="400px"></asp:TextBox>
                        &nbsp; &nbsp;<asp:ImageButton ID="imbSearch" runat="server" ImageAlign="AbsMiddle" ImageUrl="~/Images/icn_find.png"
                          OnClick="imbSearch_Click1" />&nbsp;
                        <asp:ImageButton ID="imbReset" runat="server" ImageAlign="AbsMiddle" ImageUrl="~/Images/icn_back.png"
                          OnClick="imbReset_Click" ToolTip="�ʴ�������" />
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
                <uc2:PageControl ID="pcTop" runat="server" OnPageChange="PageChange"  />
                   <asp:GridView ID="gvMain" runat="server" AllowSorting="True" AutoGenerateColumns="False" CssClass="t_tablestyle"   OnRowDataBound="gvMain_RowDataBound" OnSorting="gvMain_Sorting"   AllowPaging="True" PageSize="20" style="width:100%;">
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
                        <asp:TemplateField HeaderText="�ӴѺ" SortExpression="DEFAULT">
                            <HeaderStyle Width="60px" />
                            <ItemStyle HorizontalAlign="Center" Width="60px" />
                        </asp:TemplateField>
                       <asp:TemplateField HeaderText="������������" SortExpression="NAME">
                            <ItemTemplate>                      
                            <asp:LinkButton ID="lnkCode" runat="server" Text='<%# Bind("NAME") %>'  CommandArgument='<%# Bind("LOID")  %>' OnClick= "linkCode_Click" ></asp:LinkButton>
                            </ItemTemplate> 
                      </asp:TemplateField>
                        <asp:BoundField  DataField="UNITNAME" HeaderText="˹��¹Ѻ" SortExpression="UNITNAME">
                            <HeaderStyle HorizontalAlign="Center" Width="100px" />
                            <ItemStyle Width="100px" />
                          </asp:BoundField>
                          <asp:BoundField DataField="ACTIVE" HeaderText="�����ҹ" SortExpression="ACTIVE">
                            <HeaderStyle HorizontalAlign="Center" Width="100px" />
                            <ItemStyle HorizontalAlign="Center" Width="100px" />
                        </asp:BoundField>
                 
                        
                        </Columns> 
                         <HeaderStyle CssClass="t_headtext" />  
                    <AlternatingRowStyle CssClass="t_alt_bg" />
                    <PagerSettings Visible="False" />
                        </asp:GridView> <uc2:PageControl ID="pcBot" runat="server"  OnPageChange="PageChange"   />
                        </td> 
                        </tr> 
         </table> 
         <cc1:ModalPopupExtender ID="zPop" runat="server" TargetControlID="tbAdd$lb" PopupControlID="Panel1" BackgroundCssClass="modalBackground" DropShadow="true"></cc1:ModalPopupExtender>
                <asp:Panel ID="Panel1" runat="server" CssClass="modalPopup" style="display:none" Width="800px">
                <table cellspacing="0" cellpadding="0" border="0" width="100%">
        
        <tr>
            <td>
            <uc1:ToolBarItemCtl ID="tbSave" runat="server" ToobarTitle="�ѹ�֡" ToolbarImage="../../Images/save2.png" OnClick="tbSave1Click" />
            <uc1:ToolBarItemCtl ID="tbSave2" runat="server" ToobarTitle="�ѹ�֡���������¡������" ToolbarImage="../../Images/icn_save_add.png" OnClick="tbSave2Click"  />
            <uc1:ToolBarItemCtl ID="tbSave3" runat="server" ToobarTitle="¡��ԡ������" ToolbarImage="../../Images/cancel.png"  OnClick="tbCancelClick"  />
            <uc1:ToolBarItemCtl ID="tbBack" runat="server" ToobarTitle="��Ѻ˹����¡��" ToolbarImage="../../Images/icn_back.png" OnClick="tbBackClick"  />
            </td>
        </tr>
        <tr>
            <td><hr style="size:1px" /></td>
        </tr>
        <tr>
            <td style="height: 198px">
                <table cellpadding="5">
                    <tr>
                        <td align="right" style="width: 120px; padding-right: 10px;">
                            <asp:TextBox ID="txhSortField" runat="server" Visible="False" Width="15px"></asp:TextBox><asp:TextBox
                                ID="txhSortDir" runat="server" Visible="False" Width="15px"></asp:TextBox><asp:TextBox
                                    ID="txhID" runat="server" Visible="False" Width="15px"></asp:TextBox></td>
                        <td style="height:15px; width: 614px;">
                            <asp:Label ID="lbStatus" runat="server" EnableViewState="False"></asp:Label>
                            </td>
                    </tr>
                     <tr>
                        <td style="width:120px; padding-right: 10px;" align="right"> ����/�������  :</td>
                        <td style="width: 614px">
                            <asp:TextBox ID="txtCode" runat="server" CssClass="zTextbox" Width="100px" MaxLength="20"  ></asp:TextBox>
                            <span style="color:red">*</span></td>
                    </tr>
                    <tr>
                        <td style="width:120px; padding-right: 10px;" align="right"> ������������ :</td>
                        <td style="width: 614px; height: 32px">
                            <asp:TextBox ID="txtName" runat="server" CssClass="zTextbox" Width="300px" MaxLength="150"></asp:TextBox>
                            <span style="color:red">*</span></td>
                    </tr>
                    
                    <tr>
                        <td style="width:120px; padding-right: 10px;" align="right"> ˹��¹Ѻ :</td>
                        <td style="width: 614px">
                              <asp:DropDownList ID="cmbUnitName" runat="server" CssClass="zComboBox" Width="200px">
                            </asp:DropDownList>
                            <span style="color:red">*</span>
                            </td>
                    </tr>
                    <tr>
                        <td style="width:120px; padding-right: 10px;" align="right">  </td>
                        <td style="width: 614px; height: 32px">
                            <asp:CheckBox ID="chkActive" runat="server" Checked="True" Text="��ҹ" /></td>
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

