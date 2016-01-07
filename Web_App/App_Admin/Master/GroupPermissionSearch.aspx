<%@ Page Language="C#" MasterPageFile="~/Templates/Page1.master" AutoEventWireup="true" CodeFile="GroupPermissionSearch.aspx.cs" Inherits="App_Admin_Master_GroupPermissionSearch" Title="SHND : Master - GroupPermissionSearch" %>
<%@ Register Src="../../Templates/BoxControl.ascx" TagName="BoxControl" TagPrefix="uc4" %>
<%@ Register Src="../../Templates/CalendarControl.ascx" TagName="CalendarControl" TagPrefix="uc3" %>
<%@ Register Src="../../Templates/PageControl.ascx" TagName="PageControl" TagPrefix="uc2" %>
<%@ Register Src="../../Templates/ToolBarItemCtl.ascx" TagName="ToolBarItemCtl" TagPrefix="uc1" %>
<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="cc1" %>


<asp:Content ID="Content3" ContentPlaceHolderID="MainContent" Runat="Server">

<table width="100%" border="0" cellpadding="0" cellspacing="0">
    <tr>
           <td class="headtext">
               ����������ҹ</td>
                    
    </tr>
    <tr>  
        <td style="width: 25778px">
                <uc1:ToolBarItemCtl ID="tbAdd" runat="server" ToobarTitle="����������" OnClick="tbAddClick"   ToolbarImage="../../Images/icn_add.png"  />
               
   </td>
        </tr>
        <tr>
            <td>
                <hr size="1" />
            </td>
        </tr>
        <tr>
            <td style="height: 15px">
            <fieldset style="padding:15px;">
            <legend style="font-weight:bold">
                ���ҡ���������ҹ
            </legend>
            
             <table cellspacing="0" cellpadding="0" border="0" width="100%">
                    <tr style="height:15px">
                        <td colspan="2">&nbsp;</td>
                    </tr>
                    
                    <tr>
                        <td style="width:120px; text-align: right; padding-right:10px">���͡����</td>
                        <td style="height: 22px"><asp:TextBox ID="txtSearch" runat="server" CssClass="zTextbox" MaxLength="50" Width="350px"></asp:TextBox>
                        &nbsp; &nbsp;<asp:ImageButton ID="imbSearch" runat="server" ImageAlign="AbsMiddle" ImageUrl="~/Images/icn_find.png"
                         OnClick="imbSearch_Click1"  />&nbsp;
                        <asp:ImageButton ID="imbReset" runat="server" ImageAlign="AbsMiddle" ImageUrl="~/Images/icn_back.png"
                         OnClick="imbReset_Click" ToolTip="�ʴ�������" Visible = "false"  />
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
                <uc2:PageControl ID="pcTop" runat="server"  Visible = "false" OnPageChange="PageChange" />
                   <asp:GridView ID="gvMain" runat="server" AllowSorting="True"  class="t_tablestyle"  EmptyDataText="<center>***��辺������***</center>"  AutoGenerateColumns="False" CssClass="t_tablestyle"   OnRowDataBound="gvMain_RowDataBound" OnSorting="gvMain_Sorting"  AllowPaging="True" PageSize="20" style="width:100%;" >
                    <Columns>
                        <asp:BoundField DataField="LOID" HeaderText="LOID">
                            <ControlStyle CssClass="zHidden" />
                            <FooterStyle CssClass="zHidden" />
                            <HeaderStyle CssClass="zHidden" />
                            <ItemStyle CssClass="zHidden" />
                        </asp:BoundField>
                         <asp:TemplateField>
                            <ItemTemplate>
                            <asp:ImageButton ID="imbDelete" runat="server" CausesValidation="true" CommandName="Delete" ImageUrl="~/Images/icn_delete.png" OnClientClick="return confirm('��ͧ���ź������ ���������?')"  CommandArgument='<%# Bind("LOID")  %>'  OnClick="tbDeleteClick" />&nbsp;
                            </ItemTemplate>
                            <HeaderStyle HorizontalAlign="Center" Width="30px" />
                            <ItemStyle HorizontalAlign="Center" Width="30px" />
                        </asp:TemplateField>
                        <asp:TemplateField HeaderText="�ӴѺ" SortExpression="DEFAULT">
                            <HeaderStyle Width="60px" />
                            <ItemStyle HorizontalAlign="Center" Width="60px" />
                        </asp:TemplateField>
                       <asp:TemplateField HeaderText="���͡����" SortExpression="DESCRIPTION">
                            <ItemTemplate>                      
                            <asp:LinkButton ID="lnkCode" runat="server" Text='<%# Bind("DESCRIPTION") %>' CommandArgument='<%# Bind("LOID")  %>' OnClick= "linkCode_Click"  ></asp:LinkButton>
                            </ItemTemplate> 
                      </asp:TemplateField>
                        <asp:BoundField  DataField="MENUCOUNT" HeaderText="�ӹǹ����" SortExpression="MENUCOUNT">
                            <HeaderStyle HorizontalAlign="Center" Width="100px" />
                            <ItemStyle HorizontalAlign="Center" Width="100px" />
                          </asp:BoundField>
                          </Columns> 
                         <HeaderStyle CssClass="t_headtext" />  
                    <AlternatingRowStyle CssClass="t_alt_bg" />
                    <PagerSettings Visible="False" />
                        </asp:GridView> <uc2:PageControl ID="pcBot" runat="server"   Visible = "false"  OnPageChange="PageChange" />
                        </td> 
                        </tr> 
         </table> 
<cc1:ModalPopupExtender ID="zPop" runat="server" TargetControlID="tbAdd$lb" PopupControlID="Panel1" BackgroundCssClass="modalBackground" DropShadow="true"></cc1:ModalPopupExtender>
    <asp:Panel ID="Panel1" runat="server" CssClass="modalPopup" style="display:none" Width="800px">
    <table cellspacing="0" cellpadding="0" border="0" width="100%">
        
        <tr>
            <td>
            <uc1:ToolBarItemCtl ID="tbSave" runat="server" ToobarTitle="�ѹ�֡" ToolbarImage="../../Images/save2.png" OnClick="tbSave1Click"   />
            <uc1:ToolBarItemCtl ID="tbSave2" runat="server" ToobarTitle="¡��ԡ������" ToolbarImage="../../Images/cancel.png"  OnClick="tbCancelClick"   />
            <uc1:ToolBarItemCtl ID="tbBack" runat="server" ToobarTitle="��Ѻ˹����¡��" ToolbarImage="../../Images/icn_back.png" OnClick="tbBackClick" />
            </td>
        </tr>
        <tr>
            <td><hr size="1" /></td>
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
                        <td style="width:169px" align="right"> ���͡����  </td>
                        <td style="width: 614px">
                             <asp:TextBox ID="txtGroup" runat="server" CssClass="zTextbox" Width="350px" MaxLength="150"></asp:TextBox>
                            <span style="color:red">*</span></td> 
                    </tr>
                 
                    <tr style="background-color:#eeeeee">
                       <td colspan="2" style="padding-top:10px; padding-bottom:15px;" >
                        <uc4:BoxControl ID="z2Menu" runat="server" DestWidth="350" SourceWidth="350"  />
                      </td>
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

