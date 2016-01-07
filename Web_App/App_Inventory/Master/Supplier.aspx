<%@ Page Language="C#" MasterPageFile="~/Templates/Page1.master" AutoEventWireup="true" CodeFile="Supplier.aspx.cs" Inherits="App_Inventory_Master_Default" Title="SHND : Master - Supplier" %>

<%@ Register Src="../../Templates/MenuCtl.ascx" TagName="MenuCtl" TagPrefix="uc3" %>


<%@ Register Src="../../Templates/PageControl.ascx" TagName="PageControl" TagPrefix="uc2" %>
<%@ Register Src="../../Templates/ToolBarItemCtl.ascx" TagName="ToolBarItemCtl" TagPrefix="uc1" %>
<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="cc1" %>



  <asp:Content ID="Content3" ContentPlaceHolderID="MainContent" Runat="Server">   
    <table width="100%" border="0" cellpadding="0" cellspacing="0">
    <tr>
           <td class="headtext">
               �����ź���ѷ/��ҹ���</td>
                    
    </tr>
    <tr>  
        <td style="width: 25778px">
                <uc1:ToolBarItemCtl ID="tbAdd" runat="server" ToobarTitle="����������" OnClick="tbAddClick" ToolbarImage="../../Images/icn_add.png"  />
                <uc1:ToolBarItemCtl ID="ToolBarItemCtl1" runat="server" ToobarTitle="ź�����ŷ�����͡" OnClick="tbDeleteClick" ToolbarImage="../../Images/icn_delete.png" ClientClick="return confirm('��ͧ���ź�����ŷ�����͡ ���������?')"  />
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
                        <td colspan="2">&nbsp;</td>
                    </tr>
                    <tr>
                        <td style="width:120px; text-align: right; padding-right:10px; height: 22px;">���ͺ���ѷ/��ҹ���</td>
                        <td style="height: 22px; width: 548px;"><asp:TextBox ID="txtSearch" runat="server" CssClass="zTextbox" MaxLength="50" Width="517px"></asp:TextBox></td>
                       <td> 
                        <asp:ImageButton ID="butSearch" runat="server" ImageAlign="AbsMiddle" ImageUrl="~/Images/icn_find.png"
                    OnClick="butSearch_Click1"  />&nbsp;
                <asp:ImageButton ID="imbReset" runat="server" ImageAlign="AbsMiddle" ImageUrl="~/Images/icn_back.png"
                    OnClick="imbReset_Click" ToolTip="�ʴ�������" /></td>
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
                <uc2:PageControl ID="pcTop" runat="server" OnPageChange="PageChange"/>
                <asp:GridView ID="gvMain" runat="server" AllowSorting="True" AutoGenerateColumns="False" CssClass="t_tablestyle" OnRowDataBound="gvMain_RowDataBound" OnSorting="gvMain_Sorting" AllowPaging="True" PageSize="20" style="width:100%;">
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
                        <asp:TemplateField HeaderText="����" SortExpression="CODE">
                             <HeaderStyle HorizontalAlign="Center" Width="100px" />
                            <ItemStyle HorizontalAlign="Center" Width="100px" />
                            <ItemTemplate>
                            
                                <asp:LinkButton ID="lnkCode" runat="server" Text='<%# Bind("CODE") %>' OnClick= "linkCode_Click" CommandArgument='<%# Bind("LOID")  %>'></asp:LinkButton>
                             </ItemTemplate> 
                       </asp:TemplateField>
                        <asp:BoundField  DataField="NAME" HeaderText="���ͺ���ѷ/��ҹ���" SortExpression="NAME">
                            <HeaderStyle HorizontalAlign="Center" Width="250px" />
                            <ItemStyle HorizontalAlign="Left" Width="250px" />
                          </asp:BoundField>
                          <asp:BoundField DataField="TEL" HeaderText="���Ѿ���ҹ" SortExpression="TEL">
                            <HeaderStyle HorizontalAlign="Center" Width="150px" />
                            <ItemStyle Width="150px" />
                        </asp:BoundField>
                        <asp:BoundField DataField="MOBILE" HeaderText="��Ͷ��" >
                            <HeaderStyle HorizontalAlign="Center" Width="100px" />
                            <ItemStyle Width="100px" />
                        </asp:BoundField>
                        <asp:BoundField DataField="FAX" HeaderText="Fax" >
                            <HeaderStyle HorizontalAlign="Center" Width="100px" />
                            <ItemStyle Width="100px" />
                        </asp:BoundField>
                        <asp:BoundField DataField="EMAIL" HeaderText="E-Mail" >
                            <HeaderStyle HorizontalAlign="Center" Width="200px" />
                            <ItemStyle Width="200px" />
                        </asp:BoundField>
                        <asp:BoundField DataField="ACTIVE" HeaderText="�����ҹ" >
                            <HeaderStyle HorizontalAlign="Center" Width="100px" />
                            <ItemStyle HorizontalAlign="Center" Width="100px" />
                        </asp:BoundField>
                        
                        </Columns> 
                         <HeaderStyle CssClass="t_headtext" />  
                    <AlternatingRowStyle CssClass="t_alt_bg" />
                    <PagerSettings Visible="False" />
                        </asp:GridView> <uc2:PageControl ID="pcBot" runat="server" OnPageChange="PageChange" />
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
            <uc1:ToolBarItemCtl ID="tbSave3" runat="server" ToobarTitle="¡��ԡ������" ToolbarImage="../../Images/cancel.png" OnClick="tbSave3Click"  />
            <uc1:ToolBarItemCtl ID="tbBack" runat="server" ToobarTitle="��Ѻ˹����¡��" ToolbarImage="../../Images/icn_back.png" OnClick="tbBackClick" />
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
                        <td style="height:15px; width: 614px;">
                            <asp:Label ID="lbStatus" runat="server" EnableViewState="False"></asp:Label></td>
                    </tr>
                     <tr>
                        <td style="width:150px" align="right"> ���� :</td>
                        <td style="width: 614px">
                            <asp:TextBox ID="txtCode" runat="server" CssClass="zTextbox-View" Width="175px" MaxLength="20" Readonly ></asp:TextBox> &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp;
                                &nbsp; &nbsp; &nbsp; &nbsp; &nbsp;
                            &nbsp; &nbsp; &nbsp; &nbsp; &nbsp;��ҹ :<asp:CheckBox ID="chkActive" runat="server" Checked="True" /></td>
                    </tr>
                    <tr>
                        <td style="width:150px; height: 32px;" align="right"> ���ͺ���ѷ/��ҹ��� :</td>
                        <td style="width: 614px; height: 32px">
                            <asp:TextBox ID="txtName" runat="server" CssClass="zTextbox" Width="410px" MaxLength="150"></asp:TextBox>
                            <span style="color:red">*</span></td>
                    </tr>
                    <tr>
                        <td style="width:150px" align="right"> �������:</td>
                        <td style="width: 614px">
                           <asp:TextBox ID="txtAdd" runat="server" CssClass="zTextbox" Width="410px" MaxLength="150"></asp:TextBox> <span style="color:red">*</span></td>
                    </tr>
                    <tr>
                        <td style="width:150px" align="right"> �ѧ��Ѵ:</td>
                        <td style="width: 614px">
                              <asp:DropDownList ID="cmbProvince" runat="server" CssClass="zComboBox" Width="260px" AutoPostBack="True" OnSelectedIndexChanged="cmbProvince_SelectedIndexChanged">
                            </asp:DropDownList>
                            <span style="color:red">*</span></td>
                    </tr>
                    <tr>
                        <td style="width:150px" align="right"> �����/ࢵ:</td>
                        <td style="width: 614px">
                             <asp:DropDownList ID="cmbAum" runat="server" CssClass="zComboBox" Width="260px" AutoPostBack="True" OnSelectedIndexChanged="cmbAum_SelectedIndexChanged">
                            </asp:DropDownList>
                            <span style="color:red">*</span></td>
                    </tr>
                    <tr>
                        <td style="width:150px" align="right"> �Ӻ�/�ǧ:</td>
                        <td style="width: 614px">
                            <asp:DropDownList ID="cmbTumbol" runat="server" CssClass="zComboBox" Width="260px" >
                            </asp:DropDownList>
                            </td>
                    </tr>
                    <tr>
                        <td style="width:150px" align="right"> ������ɳ���:</td>
                        <td style="width: 614px">
                           <asp:TextBox ID="txtCode1" runat="server" CssClass="zTextbox" Width="175px" MaxLength="5"></asp:TextBox></td>
                    </tr>
                    <tr>
                        <td style="width:150px" align="right"> ���Ѿ���ҹ:</td>
                        <td style="width: 614px">
                             <asp:TextBox ID="txtTel" runat="server" CssClass="zTextbox" Width="175px" MaxLength="9"></asp:TextBox> <span style="color:red">*</span></td>
                    </tr>
                    <tr>
                        <td style="width:150px" align="right"> ���Ѿ����Ͷ��:</td>
                        <td style="width: 614px">
                             <asp:TextBox ID="txtMoblie" runat="server" CssClass="zTextbox" Width="175px" MaxLength="10"></asp:TextBox> <span style="color:red">*</span></td>
                    </tr>
                    <tr>
                        <td style="width:150px" align="right"> Fax:</td>
                        <td style="width: 614px">
                           <asp:TextBox ID="txtFax" runat="server" CssClass="zTextbox" Width="175px" MaxLength="20"></asp:TextBox> </td>
                    </tr>
                    <tr>
                        <td style="width:150px" align="right"> E-mail:</td>
                        <td style="width: 614px">
                            <asp:TextBox ID="txtEmail" runat="server" CssClass="zTextbox" Width="175px" MaxLength="20"></asp:TextBox> </td>
                    </tr>
                    <tr>
                        <td style="width:150px" align="right"> ���ͼ��Դ���:</td>
                        <td style="width: 614px">
                           <asp:TextBox ID="txtUser" runat="server" CssClass="zTextbox" Width="410px" MaxLength="20"></asp:TextBox> <span style="color:red">*</span></td>
                     </tr> 
                    <tr>
                        <td style="width:150px; height: 32px;" align="right"> �����˵�:</td>
                        <td style="width: 614px; height: 32px;">
                            &nbsp;<asp:TextBox  ID="txtRemarks"  runat="server" CssClass="zTextbox" Width="410px" MaxLength="100" Height="59px" TextMode="MultiLine" ></asp:TextBox ></td>
                             
                    </tr>
                    
                </table>
                <br />
                <br />
            </td>
        </tr>
    </table>
    </asp:Panel>
         
</asp:Content>

