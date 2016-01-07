<%@ Page Language="C#" MasterPageFile="~/Templates/Page1.master" AutoEventWireup="true" CodeFile="DiseaseCategory.aspx.cs" Inherits="App_Formula_Master_DiseaseCategory"  Title="SHND : Master - Disease Category" %>
<%@ Register Src="../../Templates/AttachControl.ascx" TagName="AttachControl" TagPrefix="uc3" %>
<%@ Register Src="../../Templates/PageControl.ascx" TagName="PageControl" TagPrefix="uc2" %>
<%@ Register Src="../../Templates/ToolBarItemCtl.ascx" TagName="ToolBarItemCtl" TagPrefix="uc1" %>
<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="cc1" %>

<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" Runat="Server">
    <table width="100%" border="0" cellpadding="0" cellspacing="0">
        <tr>
            <td class="headtext">
                ����������äǺ���</td>
        </tr>
        <tr>
            <td>
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
                        <tr style="height:24px">
                            <td style="width:120px; text-align: right; padding-right:10px">
                                ���� :</td>
                            <td><asp:TextBox ID="txtSearchName" runat="server" CssClass="zTextbox" MaxLength="50" Width="200px"></asp:TextBox></td>
                        </tr>
                        <tr style="height:24px">
                            <td style="width:120px; text-align: right; padding-right:10px">
                                ��͸Ժ��������� :</td>
                            <td>
                                <asp:TextBox ID="txtSearchDescription" runat="server" CssClass="zTextbox" Width="200px"></asp:TextBox>
                            </td>
                        </tr>
                        <tr style="height:24px">
                            <td style="width:120px; text-align: right; padding-right:10px">
                               &nbsp; </td>
                            <td>
                                <table>
                                    <tr>
                                        <td>
                                            <asp:RadioButtonList ID="rbtActive" runat="server" RepeatDirection="Horizontal">
                                                <asp:ListItem Value="T" Selected="true">������</asp:ListItem>
                                                <asp:ListItem Value="1">��ҹ</asp:ListItem>
                                                <asp:ListItem Value="0">�����ҹ</asp:ListItem>
                                            </asp:RadioButtonList>
                                        </td>
                                        <td>
                                            &nbsp; &nbsp;&nbsp;&nbsp;
                                            <asp:ImageButton ID="imbSearch" runat="server" ImageAlign="AbsMiddle" ImageUrl="~/Images/icn_find.png" OnClick="imbSearch_Click" />&nbsp;
                                            <asp:ImageButton ID="imbReset" runat="server" ImageAlign="AbsMiddle" ImageUrl="~/Images/icn_back.png" OnClick="imbReset_Click" ToolTip="�ʴ�������" />
                                        </td>
                                    </tr>
                                </table>
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
                <uc2:PageControl ID="pcTop" runat="server" OnPageChange="PageChange"/>
                <asp:GridView ID="gvMain" runat="server" AllowSorting="True" AutoGenerateColumns="False" CssClass="t_tablestyle" OnRowDataBound="gvMain_RowDataBound" OnSorting="gvMain_Sorting" AllowPaging="True" PageSize="20" Width="100%">
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
                        <asp:TemplateField HeaderText="�ӴѺ" SortExpression="DEFAULT">
                            <HeaderStyle Width="60px" />
                            <ItemStyle HorizontalAlign="Center" Width="60px" />
                        </asp:TemplateField>
                        <asp:TemplateField HeaderText="����" SortExpression="ABBNAME">
                            <HeaderStyle HorizontalAlign="Center" Width="100px" />
                            <ItemStyle HorizontalAlign="Center" Width="100px" />
                            <ItemTemplate>
                                <asp:LinkButton ID="lnkName" runat="server" Text='<%# Bind("ABBNAME") %>' OnClick="lnkName_Click" CommandArgument='<%# Bind("LOID")  %>'></asp:LinkButton>
                            </ItemTemplate>
                        </asp:TemplateField>
                        <asp:BoundField DataField="DESCRIPTION" HeaderText="��͸Ժ���������" SortExpression="DESCRIPTION">
                        </asp:BoundField>
                        <asp:BoundField DataField="IMGSYMBOL" HeaderText="�ѭ�ѡɳ�" SortExpression="IMGSYMBOL" HtmlEncode="false">
                            <HeaderStyle Width="200px" />
                            <ItemStyle Width="200px" />
                        </asp:BoundField>
                        <asp:BoundField DataField="ACTIVE" HeaderText="�����ҹ" SortExpression="ACTIVE">
                            <HeaderStyle HorizontalAlign="Center" Width="100px" />
                            <ItemStyle HorizontalAlign="Center" Width="100px" />
                        </asp:BoundField>
                    </Columns>
                    <HeaderStyle CssClass="t_headtext" />
                    <AlternatingRowStyle CssClass="t_alt_bg" />
                    <PagerSettings Visible="False" />
                </asp:GridView><uc2:PageControl ID="pcBot" runat="server" OnPageChange="PageChange" />
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
            <uc1:ToolBarItemCtl ID="tbCancel" runat="server" ToobarTitle="¡��ԡ������" ToolbarImage="../../Images/cancel.png" OnClick="tbCancelClick" />
                    <uc1:ToolBarItemCtl ID="tbBack" runat="server" ToobarTitle="��Ѻ˹����¡��" ToolbarImage="../../Images/icn_back.png" OnClick="tbBackClick"/>
                </td>
            </tr>
            <tr>
                <td><hr style="size:1px" /></td>
            </tr>
            <tr>
                <td>
                    <table cellpadding="0" border="0" cellspacing="0">
                        <tr>
                            <td align="right" style="width: 120px; padding-right: 10px;">
                                <asp:TextBox ID="txhSortField" runat="server" Visible="False" Width="15px"></asp:TextBox><asp:TextBox
                                    ID="txhSortDir" runat="server" Visible="False" Width="15px"></asp:TextBox><asp:TextBox
                                        ID="txhID" runat="server" Visible="False" Width="15px"></asp:TextBox></td>
                            <td style="height:15px">
                                <asp:Label ID="lbStatus" runat="server" EnableViewState="False"></asp:Label></td>
                        </tr>
                        <tr style="height: 24px;" >
                            <td align="right" style="padding-right: 10px; width: 120px"> ���� :</td>
                            <td>
                                <asp:TextBox ID="txtName" runat="server" CssClass="zTextbox" Width="150px" MaxLength="20"></asp:TextBox>&nbsp;<span style="color:red">*</span>
                                &nbsp;&nbsp; 
                                <asp:CheckBox ID="chkActive" runat="server" Checked="True" Text="��ҹ" /></td>
                        </tr>
                        <tr style="height: 24px;">
                            <td style="width:120px; padding-right: 10px;" align="right" valign="top">
                                <table border="0" cellpadding="0" cellspacing="0" width="100">
                                    <tr><td style="height:24px">��������´������� :</td></tr> 
                                </table>
                            </td>
                            <td valign="top">
                                <asp:TextBox ID="txtDescription" runat="server" CssClass="zTextbox" Width="400px" MaxLength="50" TextMode="MultiLine" Height="50px"></asp:TextBox>&nbsp;<span style="color:red; vertical-align:top">*</span></td>
                        </tr>
                        <tr style="height: 24px;" >
                            <td align="right" style="padding-right: 10px; width: 120px"> ˹��¹Ѻ :</td>
                            <td>
                                <asp:DropDownList ID="cmbUnit" Width="100px" runat="server">
                                </asp:DropDownList>
                                &nbsp;&nbsp; </td>
                        </tr>
                        <tr style="height: 24px;">
                            <td align="right" style="width: 120px; padding-right: 10px;" valign="top">
                                <table border="0" cellpadding="0" cellspacing="0" width="100">
                                    <tr><td style="height:24px">�ѭ�ѡɳ� :</td></tr> 
                                </table>
                            </td>
                            <td>
                                <asp:Label ID="lblAttachRemark" runat="server" CssClass="zRemark" Text="�ѹ�֡�����š�͹Ṻ���"></asp:Label>
                                <uc3:AttachControl ID="attSign" runat="server" Reference1="Master" Reference2="DiseaseCategory" />
                                <asp:TextBox ID="txtAttachCode" runat="server" Visible="False" Width="15px"></asp:TextBox></td>
                        </tr>
                        <tr style="height: 24px;">
                            <td style="width:120px; padding-right: 10px;" align="right"> ������Ѻ :</td>
                            <td>
                                <asp:CheckBox ID="chkRegular" runat="server" Text="Regular" Checked="True" />
                                <asp:CheckBox ID="chkSoft" runat="server" Text="Soft" Checked="True" />
                                <asp:CheckBox ID="chkLight" runat="server" Text="Light" />
                                <asp:CheckBox ID="chkLiquid" runat="server" Text="Liquid" Checked="True" />
                                <asp:CheckBox ID="chkMilk" runat="server" Text="Milk" />
                                </td>
                        </tr>
                                            <tr style="height: 24px;">
                            <td style="width:120px; padding-right: 10px;" align="right"> �дѺ :</td>
                            <td>
                                <asp:CheckBox ID="chkHigh" runat="server" Text="High" />
                                <asp:CheckBox ID="chkLow" runat="server" Text="Low" />
                                <asp:CheckBox ID="chkNon" runat="server" Text="Non" /></td>
                        </tr>
                        <tr style="height: 24px;">
                            <td align="right" style="width: 120px; padding-right: 10px;">
                            </td>
                            <td>
                                <br />
                                    <table cellspacing="0" cellpadding="0" border="0" 
                                        style="width:400px; border-right: mediumorchid thin solid; border-top: mediumorchid thin solid; border-left: mediumorchid thin solid; border-bottom: mediumorchid thin solid;" >
                                    <tr><td class="subheadertext">��˹����͹䢡���ʴ��������˹�Ҩ�������������Ѻᾷ��</td></tr>
                                    <tr><td><asp:CheckBox ID="chkSpecial" runat="server" Text="��Դ�����੾���ä" Checked="True" /></td></tr>
                                    <tr><td><asp:CheckBox ID="chkLimit" runat="server" Text="��Դ����÷��ӡѴ����ҳ" /></td></tr>
                                    <tr><td><asp:CheckBox ID="chkCalculate" runat="server" Text="��Դ����äӹǳ��ѧ�ҹ" /></td></tr>
                                    <tr><td><asp:CheckBox ID="chkIncrease" runat="server" Text="��Դ����������" /></td></tr>
                                    </table><br />
                                    <table cellspacing="0" cellpadding="0" border="0"
                                        style="width:400px; border-right: mediumorchid thin solid; border-top: mediumorchid thin solid; border-left: mediumorchid thin solid; border-bottom: mediumorchid thin solid;" >
                                    <tr><td class="subheadertext">��˹����͹䢡���ʴ��������˹�Ҩ�������������Ѻ��Һ��</td></tr>
                                    <tr><td><asp:CheckBox ID="chkNeed" runat="server" Text="��Դ����÷������¢��Ѻ੾��" /></td></tr>
                                    <tr><td><asp:CheckBox ID="chkAbstain" runat="server" Text="��Դ����÷������������Ѻ/��" /></td></tr>
                                    <tr><td><asp:CheckBox ID="chkRequest" runat="server" Text="��Դ����÷������¢�" /></td></tr>
                                    </table>
                            </td>
                        </tr>
                    </table>
                </td>
            </tr>
        </table>
    </asp:Panel>
</asp:Content>
