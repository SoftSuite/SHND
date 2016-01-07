<%@ Page Language="C#" MasterPageFile="~/Templates/Page1.master" AutoEventWireup="true" CodeFile="Officer.aspx.cs" Inherits="App_Admin_Master_Officer" Title="SHND - Officer" %>
<%@ Register Src="../../Templates/BoxControl.ascx" TagName="BoxControl" TagPrefix="uc4" %>
<%@ Register Src="../../Templates/CalendarControl.ascx" TagName="CalendarControl" TagPrefix="uc3" %>
<%@ Register Src="../../Templates/PageControl.ascx" TagName="PageControl" TagPrefix="uc2" %>
<%@ Register Src="../../Templates/ToolBarItemCtl.ascx" TagName="ToolBarItemCtl" TagPrefix="uc1" %>
<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="cc1" %>
<%@ Register Src="../../Search/WardPopup.ascx" TagName="WardPopup" TagPrefix="uc3" %>


<asp:Content ID="Content3" ContentPlaceHolderID="MainContent" Runat="Server">

<table width="100%" border="0" cellpadding="0" cellspacing="0">
    <tr>
           <td class="headtext">
               ���������Է�������ҹ</td>
                    
    </tr>
    <tr>  
        <td style="width: 25778px">
                <uc1:ToolBarItemCtl ID="tbAdd" runat="server" ToobarTitle="����������" OnClick="tbAddClick"   ToolbarImage="../../Images/icn_add.png"  />
            &nbsp;
               
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
            
             <table cellspacing="0" cellpadding="3" border="0" width="100%">
                    <tr style="height:15px">
                        <td colspan="2">&nbsp;</td>
                    </tr>
                 <tr>
                     <td style="padding-right: 10px; width: 120px; text-align: right">
                         ��������к� :</td>
                     <td style="height: 22px">
                         <asp:TextBox ID="txtSUserID" runat="server" CssClass="zTextbox" MaxLength="100" Width="150px"></asp:TextBox></td>
                 </tr>
                 <tr>
                     <td style="padding-right: 10px; width: 120px; text-align: right">
                         ���ͼ���� :</td>
                     <td style="height: 22px">
                         <asp:TextBox ID="txtSFName" runat="server" CssClass="zTextbox" MaxLength="100" Width="150px"></asp:TextBox></td>
                 </tr>
                 <tr>
                     <td style="padding-right: 10px; width: 120px; text-align: right">
                         ���ʡ�� :</td>
                     <td style="height: 22px">
                         <asp:TextBox ID="txtSLName" runat="server" CssClass="zTextbox" MaxLength="100" Width="150px"></asp:TextBox></td>
                 </tr>
                 <tr>
                     <td style="padding-right: 10px; width: 120px; text-align: right">
                         ˹��§ҹ :</td>
                     <td style="height: 22px">
                        <asp:DropDownList ID="cmbSDivision" runat="server" CssClass="zComboBox" Width="280px">
                        </asp:DropDownList></td>
                 </tr>
                    
                    <tr>
                        <td style="width:120px; text-align: right; padding-right:10px">
                            �дѺ�����ҹ :</td>
                        <td style="height: 22px">
                        <asp:DropDownList ID="cmbSGroup" runat="server" CssClass="zComboBox" Width="150px">
                            <asp:ListItem Value="">������</asp:ListItem>
                            <asp:ListItem Value="O">˹��§ҹ����</asp:ListItem>
                            <asp:ListItem Value="U">��������ҡ��</asp:ListItem>
                            <asp:ListItem Value="N">��Һ��</asp:ListItem>
                            <asp:ListItem Value="M">���</asp:ListItem>
                            <asp:ListItem Value="A">�������к�</asp:ListItem>
                        </asp:DropDownList>
                            &nbsp;
                        &nbsp; &nbsp;&nbsp;
                            <asp:ImageButton ID="imbSearch" runat="server" ImageAlign="AbsMiddle" ImageUrl="~/Images/icn_find.png"
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
                   <asp:GridView ID="gvMain" runat="server" AllowSorting="True" AutoGenerateColumns="False" CssClass="t_tablestyle"   OnRowDataBound="gvMain_RowDataBound" OnSorting="gvMain_Sorting"  AllowPaging="True" PageSize="20" style="width:100%;" OnRowDeleting="gvMain_RowDeleting" >
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
                       <asp:TemplateField HeaderText="��������к�" SortExpression="USERNAME">
                            <ItemTemplate>                      
                            <asp:LinkButton ID="lnkCode" runat="server" Text='<%# Bind("USERNAME") %>' CommandArgument='<%# Bind("LOID")  %>' OnClick= "linkCode_Click"  ></asp:LinkButton>
                            </ItemTemplate> 
                           <HeaderStyle Width="150px" />
                           <ItemStyle Width="150px" />
                      </asp:TemplateField>
                        <asp:BoundField  DataField="OFFICERNAME" HeaderText="���ͼ����" SortExpression="OFFICERNAME">
                            <HeaderStyle HorizontalAlign="Center" />
                          </asp:BoundField>
                        <asp:BoundField DataField="DIVISIONNAME" HeaderText="˹��§ҹ" SortExpression="DIVISION">
                            <HeaderStyle Width="150px" />
                            <ItemStyle Width="150px" />
                        </asp:BoundField>
                        <asp:BoundField HeaderText="�дѺ�����ҹ" SortExpression="OFFICERGROUP" DataField="OFFICERGROUP">
                            <HeaderStyle Width="130px" />
                            <ItemStyle Width="130px" />
                        </asp:BoundField>
                        <asp:BoundField DataField="LASTLOGON" DataFormatString="{0:d MMM yyyy [HH:mm]}" HeaderText="�ѹ�����ҹ����ش"
                            HtmlEncode="False" SortExpression="LASTLOGON">
                            <HeaderStyle Width="120px" />
                            <ItemStyle Width="120px" />
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
    <asp:Panel ID="Panel1" runat="server" CssClass="modalPopup" style="display:none" Width="800px" Height="600px" ScrollBars="Auto">
    <table cellspacing="0" cellpadding="0" border="0" width="100%">
        
        <tr>
            <td>
            <uc1:ToolBarItemCtl ID="tbSave" runat="server" ToobarTitle="�ѹ�֡" ToolbarImage="../../Images/save2.png" OnClick="tbSaveClick"   />
            <uc1:ToolBarItemCtl ID="tbCancel" runat="server" ToobarTitle="¡��ԡ������" ToolbarImage="../../Images/cancel.png"  OnClick="tbCancelClick"   />
            <uc1:ToolBarItemCtl ID="tbBack" runat="server" ToobarTitle="��Ѻ˹����¡��" ToolbarImage="../../Images/icn_back.png" OnClick="tbBackClick" />
            </td>
        </tr>
        <tr>
            <td><hr style="size:1px" /></td>
        </tr>
        <tr>
            <td>
            <table width="90%" align="center" cellpadding="5" cellspacing="0" border="0">
                <tr>
                    <td align="right" style="width: 150px; height: 15px">
                        <asp:TextBox ID="txhID" runat="server" Visible="False" Width="15px"></asp:TextBox>
                        <asp:TextBox ID="txhSortDir" runat="server" Visible="False" Width="15px"></asp:TextBox>
                        <asp:TextBox ID="txhSortField" runat="server" Visible="False" Width="15px"></asp:TextBox></td>
                    <td style="height: 15px">
                        <asp:Label ID="lbStatus" runat="server" EnableViewState="False"></asp:Label></td>
                </tr>
                <tr>
                    <td style="width:150px; height: 15px;" align="right">
                        ���ͼ���� :</td>
                    <td style="height: 15px">
                        <asp:DropDownList ID="cmbTitle" runat="server" CssClass="zComboBox" Width="100px">
                        </asp:DropDownList>&nbsp;
                        <asp:TextBox ID="txtFName" runat="server" CssClass="zTextbox" MaxLength="100" Width="150px"></asp:TextBox>
                        <asp:TextBox ID="txtLName" runat="server" CssClass="zTextbox" MaxLength="100" Width="150px"></asp:TextBox>
                        <span style="color: #ff0000">*</span></td>
                </tr>
                <tr>
                    <td align="right" style="width: 150px; height: 15px">
                        ˹��§ҹ :</td>
                    <td style="height: 15px"><asp:DropDownList ID="cmbDivision" runat="server" CssClass="zComboBox" Width="280px">
                    </asp:DropDownList>
                        <span style="color: #ff0000">*</span></td>
                </tr>
                <tr>
                    <td align="right" style="width: 150px; height: 15px">
                        ������ :</td>
                    <td style="height: 15px">
                        <asp:TextBox ID="txtPhone" runat="server" CssClass="zTextbox" Width="200px" MaxLength="50"></asp:TextBox></td>
                </tr>
                <tr>
                    <td align="right" style="width: 150px; height: 15px">
                        E-Mail :</td>
                    <td style="height: 15px">
                        <asp:TextBox ID="txtEMail" runat="server" CssClass="zTextbox" Width="200px" MaxLength="100"></asp:TextBox></td>
                </tr>
                <tr>
                    <td align="right" style="width: 150px; height: 15px">
                    </td>
                    <td style="height: 15px">
                    </td>
                </tr>
                <tr>
                    <td align="right" style="width: 150px; height: 15px">
                        �������к� :</td>
                    <td style="height: 15px">
                        <asp:TextBox ID="txtUserName" runat="server" CssClass="zTextbox" Width="150px" MaxLength="30"></asp:TextBox>
                        <span style="color: #ff0000">*</span></td>
                </tr>
                <tr>
                    <td align="right" style="width: 150px; height: 15px">
                        ���ʼ�ҹ :</td>
                    <td style="height: 15px">
                        <asp:TextBox ID="txtPasswd" runat="server" CssClass="zTextbox" Width="150px" MaxLength="20" TextMode="Password"></asp:TextBox>
                        <asp:Label ID="lblPasswordNeed" runat="server" ForeColor="Red" Text="*"></asp:Label></td>
                </tr>
                <tr>
                    <td align="right" style="width: 150px; height: 15px">
                        �дѺ�����ҹ :</td>
                    <td style="height: 15px"><asp:DropDownList ID="cmbUserGroup" runat="server" CssClass="zComboBox" Width="150px" AutoPostBack="True" OnSelectedIndexChanged="cmbUserGroup_SelectedIndexChanged">
                        <asp:ListItem>���͡</asp:ListItem>
                        <asp:ListItem Value="O">˹��§ҹ����</asp:ListItem>
                        <asp:ListItem Value="U">��������ҡ��</asp:ListItem>
                        <asp:ListItem Value="N">��Һ��</asp:ListItem>
                        <asp:ListItem Value="M">���</asp:ListItem>
                        <asp:ListItem Value="A">�������к�</asp:ListItem>
                    </asp:DropDownList>
                        <span style="color: #ff0000">*</span></td>
                </tr>
                <tr>
                    <td align="right" style="width: 150px; height: 15px">
                        </td>
                    <td style="height: 15px">
                    </td>
                </tr>
                <tr>
                    <td align="right" style="width: 150px; height: 15px">
                        �ѹ������������ҹ :</td>
                    <td style="height: 15px">
                        <uc3:CalendarControl ID="dtpEFDate" runat="server" />
                        &nbsp; <span style="color: #ff0000">*</span></td>
                </tr>
                <tr>
                    <td align="right" style="width: 150px; height: 15px">
                        �ѹ�������ش�����ҹ :</td>
                    <td style="height: 15px">
                        <uc3:CalendarControl ID="dtpEPDate" runat="server" />
                    </td>
                </tr>
                <tr>
                    <td align="right" style="width: 150px; height: 15px">
                        �ЧѺ�����ҹ :</td>
                    <td style="height: 15px">
                        <asp:CheckBox ID="chkDisable" runat="server" Text="�������ЧѺ�����ҹ�ͧ�����" /></td>
                </tr>
                <tr>
                    <td align="right" style="width: 150px; height: 15px">
                        �ѹ�������к�����ش :</td>
                    <td style="height: 15px">
                        <asp:TextBox ID="txtLastLogon" runat="server" CssClass="zTextbox-View" Width="150px"></asp:TextBox></td>
                </tr>
                <tr>
                    <td align="right" style="width: 150px; height: 15px">
                        �ѹ�������¹���ʼ�ҹ����ش :</td>
                    <td style="height: 15px">
                        <asp:TextBox ID="txtLastChangePW" runat="server" CssClass="zTextbox-View" Width="150px"></asp:TextBox>
                        &nbsp;
                        <asp:CheckBox ID="chkForceChangePw" runat="server" Checked="True" Text="�ѧ�Ѻ�������¹���ʼ�ҹ���������к����駵���" /></td>
                </tr>
            </table>
            </td>
        </tr>
        <tr>
            <td>
                <hr style="size:1px" />
                &nbsp;</td>
        </tr>
        <tr>
            <td style="padding-right: 20px; padding-left: 20px; padding-bottom: 20px; padding-top: 20px">
                <cc1:TabContainer ID="tabRole" runat="server" ActiveTabIndex="0">
                    <cc1:TabPanel ID="TabPanel1" runat="server" HeaderText="TabPanel1">
                        <ContentTemplate>
                            <br />
                            <strong>��˹���������´������ͧ����<br />
                            </strong>
                            <br />
                            <table cellpadding="5" align="center">
                                <tr style="background-color:#eeeeee">
                                    <td colspan="2" style="padding-top:10px; padding-bottom:15px;" align="center">
                                        <uc4:BoxControl ID="z2Group" runat="server" txtDestHead="�����������Է���" txtSourceHead="�����������"  />
                                    </td>
                                </tr>
                            </table>
                        </ContentTemplate>
                        <HeaderTemplate>
                            ��˹����������
                        </HeaderTemplate>
                    </cc1:TabPanel>
                    <cc1:TabPanel ID="TabPanel2" runat="server" HeaderText="TabPanel2">
                        <ContentTemplate>
                            <br />
                            <strong>��˹���������´�Է���㹡��������<br />
                                <br />
                            </strong>
                            <table cellpadding="5" align="center">
                                <tr style="background-color:#eeeeee">
                                   <td colspan="2" style="padding-top:10px; padding-bottom:15px;" align="center">
                                    <uc4:BoxControl ID="z2Menu" runat="server" txtDestHead="���ٷ�����Է���" txtSourceHead="���ٷ�����"  />
                                  </td>
                                </tr>
                            </table>
                        </ContentTemplate>
                        <HeaderTemplate>
                            ��˹���������´�Է���㹡��������
                        </HeaderTemplate>
                    </cc1:TabPanel>
                    <cc1:TabPanel ID="tabWard" runat="server" HeaderText="TabPanel2">
                        <ContentTemplate>
                            <br />
                            <strong>��˹��ͼ����·���Ѻ�Դ�ͺ<br />
                                <br />
                            </strong>
                            <table Width="100%">
                                <tr>
                                    <td class="toolbarplace">
                                        <uc1:ToolBarItemCtl ID="tbAddWard" runat="server" ToobarTitle="�����ͼ�����" ToolbarImage="../../Images/icn_add.png" OnClick="tbAddWardClick" />
                                        <uc1:ToolBarItemCtl ID="tbDeleteWard" runat="server" ToobarTitle="ź�ͼ�����" ToolbarImage="../../Images/icn_delete.png" OnClick="tbDeleteWardClick" />
                                    </td>
                                </tr></table>
                            <table cellpadding="5" align="center">

                                <tr style="background-color:#eeeeee">
                                   <td colspan="2" style="padding-top:10px; padding-bottom:15px;" align="center">
                                    <asp:GridView ID="gvward" runat="server" AutoGenerateColumns="False" CssClass="t_tablestyle" DataSourceID="WardSource" 
                                            DataKeyNames="WARD" Width="100%">
                                            <Columns>
                                                <asp:BoundField DataField="WARD" HeaderText="WARD">
                                                    <ControlStyle CssClass="zHidden" />
                                                    <FooterStyle CssClass="zHidden" />
                                                    <HeaderStyle CssClass="zHidden" />
                                                    <ItemStyle CssClass="zHidden" />
                                                </asp:BoundField>
                                                <asp:TemplateField>
                                                    <HeaderTemplate>
                                                        <input type="checkbox" name="chkMain" id="chkMain" onclick="chkAllBox(this, 'ctl00_MainContent_tabRole_tabWard_gvWard_ctl', '_chkSelect')" />
                                                    </HeaderTemplate>
                                                    <ItemTemplate>
                                                        <asp:CheckBox ID="chkSelect" runat="server"/>
                                                    </ItemTemplate>
                                                    <HeaderStyle HorizontalAlign="Center" Width="30px" />
                                                    <ItemStyle HorizontalAlign="Center" Width="30px" VerticalAlign="Top" />
                                                </asp:TemplateField>
                                                <asp:TemplateField HeaderText="�ӴѺ">
                                                    <ItemTemplate>
                                                        <%# Container.DataItemIndex +1 %>
                                                    </ItemTemplate>
                                                    <HeaderStyle CssClass="zHidden"  Width="50px" />
                                                    <ItemStyle CssClass="zHidden" HorizontalAlign="Center" Width="50px" Height="24px" />
                                                </asp:TemplateField>
                                                <asp:BoundField DataField="WARDNAME" HeaderText="�ͼ�����">
                                                    <ItemStyle HorizontalAlign="Left" />
                                                </asp:BoundField>
                                                <asp:TemplateField HeaderText="�ӴѺ">
                                                    <ItemTemplate>
                                                        <asp:TextBox ID="txtorder" runat="server" Width="95px" Text='<%# Eval("PRIORITY").ToString() %>' 
                                                            CssClass="zTextboxR"></asp:TextBox> 
                                                    </ItemTemplate>
                                                    <ItemStyle Width="100px" HorizontalAlign="Right" />
                                                    <HeaderStyle Width="100px" />  
                                                </asp:TemplateField>
                                                <asp:TemplateField HeaderText="����������">
                                                    <ItemTemplate>
                                                        <asp:CheckBox ID="chkDefault" runat="server" Checked='<%# Convert.ToString(Eval("ISDEFAULT")) == "1" %>' onclick="javascript:SelectCheckboxes(this);"  />
                                                    </ItemTemplate>
                                                    <ItemStyle Width="80px" HorizontalAlign="Center" />
                                                    <HeaderStyle Width="80px" />  
                                                </asp:TemplateField>
                                                <asp:TemplateField HeaderText="��ҹ">
                                                    <ItemTemplate>
                                                        <asp:CheckBox ID="chkActive" runat="server" Checked='<%# Convert.ToString(Eval("ACTIVE")) == "1" %>' />
                                                    </ItemTemplate>
                                                    <ItemStyle Width="80px" HorizontalAlign="Center" />
                                                    <HeaderStyle Width="80px" />  
                                                </asp:TemplateField>
                                            </Columns>
                                            <HeaderStyle CssClass="t_headtext" />
                                            <AlternatingRowStyle CssClass="t_alt_bg" />
                                            <PagerSettings Visible="False" />
                                        </asp:GridView>
                                        <asp:ObjectDataSource ID="WardSource" runat="server" SelectMethod="GetWardList" TypeName="WardDetailItem">
                                            <SelectParameters>
                                                <asp:ControlParameter ControlID="txhID" DefaultValue="0" Name="officer" PropertyName="Text"
                                                    Type="Double" />
                                            </SelectParameters>
                                        </asp:ObjectDataSource>
                                  </td>
                                </tr>
                            </table>
                        </ContentTemplate>
                        <HeaderTemplate>
                            ��˹��ͼ����·���Ѻ�Դ�ͺ
                        </HeaderTemplate>
                    </cc1:TabPanel>
                </cc1:TabContainer>
        </tr>
        <tr>
            <td align="center">
            </td>
        </tr>
    </table>
   <uc3:WardPopup id="ctlWardPopup" runat="server" OnSelectedIndexChanged="ctlWardPopup_SelectedIndexChanged" OnCancel="ctlWardPopup_Cancel">
    </uc3:WardPopup>

</asp:Panel>
 <script language="javascript" type="text/javascript">
function SelectCheckboxes(e)
{
    if(e.checked)
   {
	    elm=document.aspnetForm.elements;
	    for(i=0;i<elm.length;i++)
	    if(elm[i].type=="checkbox"&& elm[i].id!=e.id)
	    {
			if(elm[i].id.indexOf("chkDefault") >= 0)
				elm[i].checked=false;
		}
   }
}
</script>
</asp:Content>

