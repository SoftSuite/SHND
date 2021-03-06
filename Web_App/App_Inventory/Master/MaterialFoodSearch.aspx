<%@ Page Language="C#" MasterPageFile="~/Templates/Page1.master" AutoEventWireup="true" CodeFile="MaterialFoodSearch.aspx.cs" Inherits="App_Inventory_Master_MaterialFoodSearch" Title="SHND : Master - Material Food" %>

<%@ Register Src="../../Templates/PageControl.ascx" TagName="PageControl" TagPrefix="uc2" %>
<%@ Register Src="../../Templates/ToolBarItemCtl.ascx" TagName="ToolBarItemCtl" TagPrefix="uc1" %>
<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="cc1" %>

<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" Runat="Server">
    <table width="100%" border="0" cellpadding="0" cellspacing="0">
        <tr>
            <td class="headtext">��������ʴ������</td>
        </tr>
        <tr>
            <td>
                <uc1:ToolBarItemCtl ID="tbAdd" runat="server" ToobarTitle="����������" OnClick="tbAddClick" ToolbarImage="../../Images/icn_add.png"  />
                <uc1:ToolBarItemCtl ID="ToolBarItemCtl1" runat="server" ToobarTitle="ź�����ŷ�����͡" OnClick="tbDeleteClick" ToolbarImage="../../Images/icn_delete.png" ClientClick="return confirm('��ͧ���ź�����ŷ�����͡ ���������?')"  />
                <uc1:ToolBarItemCtl ID="tbPrint" runat="server" ToobarTitle="�����" OnClick="tbPrintClick" ToolbarImage="../../Images/icn_print.png"  />
                <uc1:ToolBarItemCtl ID="tbExcel" runat="server" ToobarTitle="Export to Excel" ToolbarImage="../../Images/icn_excel.png"  />
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
            
                <table cellspacing="0" cellpadding="0" border="0" width="900" >
                    <tr style="height:15px">
                        <td colspan="2">&nbsp;</td>
                    </tr>
                    <tr>
                        <td style="width:120px; text-align: right; padding-right:10px; height: 24px;">��Ǵ����� :</td>
                        <td style="height: 24px"><asp:DropDownList ID="cmbMaterialClass" runat="server" Width="277px" AutoPostBack="True" OnSelectedIndexChanged="cmbMaterialClass_SelectedIndexChanged" CssClass="zComboBox">
                            </asp:DropDownList>
                    </td></tr>
                    <tr>
                        <td style="width:120px; text-align: right; padding-right:10px; height: 24px;">���������� :</td>
                        <td style="height: 24px"><asp:DropDownList ID="cmbMaterialGroup" runat="server" Width="277px" CssClass="zComboBox">
                            </asp:DropDownList>
                    </td></tr>
                    <tr>
                        <td style="width:120px; text-align: right; padding-right:10px; height: 24px;">������ʴ������ :</td>
                        <td style="height: 24px"><asp:TextBox ID="txtSearchName" runat="server" CssClass="zTextbox" MaxLength="50" Width="271px"></asp:TextBox>
                            &nbsp; &nbsp;<asp:ImageButton ID="imbSearch" runat="server" ImageAlign="AbsMiddle" ImageUrl="~/Images/icn_find.png"
                            OnClick="imbSearch_Click" />&nbsp;
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
            <td style="width:1000px">
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
                            <HeaderStyle HorizontalAlign="Center" Width="20px" />
                            <ItemStyle HorizontalAlign="Center" Width="20px" />
                        </asp:TemplateField>
                        <asp:TemplateField HeaderText="�ӴѺ" SortExpression="DEFAULT">
                            <HeaderStyle Width="40px" />
                            <ItemStyle HorizontalAlign="Center" Width="40px" />
                        </asp:TemplateField>
                        <asp:TemplateField HeaderText="���� SAP" SortExpression="SAPCODE">
                            <ItemTemplate>
                                <asp:LinkButton ID="lnkCode" runat="server" Text='<%# Bind("SAPCODE") %>' OnClick="lnkCode_Click" CommandArgument='<%# Bind("LOID")  %>'></asp:LinkButton>
                            </ItemTemplate>
                            <ItemStyle HorizontalAlign = "Center" Width="70px" />
                            <HeaderStyle Width="70px" HorizontalAlign="Center" />
                        </asp:TemplateField>
                        <asp:BoundField DataField="MATERIALNAME" HeaderText="��¡��" SortExpression="MATERIALNAME">
                        </asp:BoundField>
                        <asp:BoundField DataField="CLASSNAME" HeaderText="��Ǵ�����" SortExpression="CLASSNAME">
                            <HeaderStyle HorizontalAlign="Center" Width="150px" />
                            <ItemStyle Width="150px" />
                        </asp:BoundField>
                        <asp:BoundField DataField="GROUPNAME" HeaderText="�����������" SortExpression="GROUPNAME">
                            <HeaderStyle HorizontalAlign="Center" Width="100px" />
                            <ItemStyle Width="100px" />
                        </asp:BoundField>
                        <asp:BoundField DataField="THNAME" HeaderText="˹��¹Ѻ" >
                            <HeaderStyle HorizontalAlign="Center" Width="60px" />
                            <ItemStyle Width="60px" />
                        </asp:BoundField>
                        <asp:BoundField DataField="ACTIVENAME" HeaderText="�����ҹ" >
                            <HeaderStyle HorizontalAlign="Center" Width="70px" />
                            <ItemStyle HorizontalAlign="Center" Width="70px" />
                        </asp:BoundField>
                        <asp:BoundField DataField="ENERGY100G" HeaderText="��ѧ�ҹ/100g" HtmlEncode="False" DataFormatString="{0:#,##0.00}" >
                            <HeaderStyle HorizontalAlign="Center"  Width="100px" />
                            <ItemStyle HorizontalAlign="Right"  Width="100px" />
                        </asp:BoundField>
                        <asp:BoundField DataField="MNQTY" HeaderText="�ӹǹ��������" >
                            <HeaderStyle Width="70px" />
                            <ItemStyle Width="70px" HorizontalAlign="Right" />
                        </asp:BoundField>
                        <asp:BoundField DataField="DIFFQTY" HeaderText="�������äú��ǹ" >
                            <HeaderStyle Width="100px" />
                            <ItemStyle Width="100px" HorizontalAlign="Center"/>
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
    <asp:Panel ID="Panel1" runat="server" CssClass="modalPopup" style="display:none" Width="800px"   >
        <asp:TextBox ID="txhSortField" runat="server" Visible="False" Width="15px"></asp:TextBox>
        <asp:TextBox ID="txhSortDir" runat="server" Visible="False" Width="15px"></asp:TextBox>
        <asp:TextBox ID="txhID" runat="server" Visible="False" Width="15px"></asp:TextBox>&nbsp;
        <asp:TextBox ID="txtPrevTabIndex" runat="server" Width="32px" Visible="false">0</asp:TextBox>
    
    <table cellspacing="0" cellpadding="0" border="0" width="100%">
        <tr>
            <td>
                <uc1:ToolBarItemCtl ID="tbSave" runat="server" ToobarTitle="�ѹ�֡" ToolbarImage="../../Images/save2.png" OnClick="tbSaveClick" />
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
                
            </td>
        </tr>
    </table>
    <cc1:TabContainer ID="TabContainer1" runat="server" ActiveTabIndex="0" OnActiveTabChanged="TabContainer1_ActiveTabChanged" AutoPostBack="True" Height="600px"  ScrollBars="Vertical" >
        <cc1:TabPanel ID="tabFoodDetail" runat="server" HeaderText="��������´" >
            <ContentTemplate>
                <table cellspacing="0" cellpadding="1" border="0" >
                    <tr>
                        <td style="width: 125px">
                        </td>
                        <td><asp:Label ID="lbStatusTab1" runat="server" EnableViewState="False"></asp:Label>
                        </td>
                        <td>
                            &nbsp;
                        </td>
                    </tr>
                    <tr>
                        <td style="width: 125px">������ʴ�
                        </td>
                        <td>
                            <asp:TextBox ID="txtCode" runat="server" Width="123px" CssClass="zTextbox-View" ReadOnly="True" ></asp:TextBox>&nbsp;
                            <asp:TextBox ID="txtLOID" runat="server" Width="36px" Visible="False"></asp:TextBox>&nbsp;&nbsp;
                            <asp:CheckBox ID="chkActive" runat="server" Text="��ҹ" Checked="True" ></asp:CheckBox>
                        </td>
                        <td>
                            <table cellspacing="0" cellpadding="2" border="0" style="border-right: mediumorchid thin solid; border-top: mediumorchid thin solid; border-left: mediumorchid thin solid; border-bottom: mediumorchid thin solid;" >
                                <tr>
                                    <td style="width: 90px">&nbsp;&nbsp;���� SAP</td>
                                    <td><asp:TextBox ID="txtSAP" runat="server" CssClass="zTextbox" ></asp:TextBox>&nbsp;&nbsp;&nbsp;</td>
                                </tr>
                            </table>
                        </td>
                    </tr>
                    <tr>
                        <td style="width: 125px">������ʴ������
                        </td>
                        <td><asp:TextBox ID="txtName" runat="server" Width="300px" CssClass="zTextbox" ></asp:TextBox>
                            <asp:Label id="lbl1" runat="server" Text="*" ForeColor="Red"></asp:Label>
                        </td>
                        <td>
                        </td>
                    </tr>
                    <tr>
                        <td style="width: 125px">������Ǵ�����
                        </td>
                        <td><asp:DropDownList ID="cmbMaterialClass1" runat="server" Width="305px" CssClass="zComboBox" AutoPostBack="True" OnSelectedIndexChanged="cmbMaterialClass1_SelectedIndexChanged"></asp:DropDownList>
                            <asp:Label id="Label1" runat="server" Text="*" ForeColor="Red"></asp:Label>
                        </td>
                        <td>
                        </td>
                    </tr>
                    <tr>
                        <td style="width: 125px">���ͻ����������
                        </td>
                        <td><asp:DropDownList ID="cmbMaterialGroup1" runat="server" Width="305px" CssClass="zComboBox"></asp:DropDownList>
                            <asp:Label id="Label2" runat="server" Text="*" ForeColor="Red"></asp:Label>
                        </td>
                        <td>
                        </td>
                    </tr>
                    <tr>
                        <td style="width: 125px">˹��¹Ѻ
                        </td>
                        <td><asp:DropDownList ID="cmbUnit1" runat="server" Width="305px" CssClass="zComboBox"></asp:DropDownList>
                            <asp:Label id="Label3" runat="server" Text="*" ForeColor="Red"></asp:Label>
                        </td>
                        <td>
                        </td>
                    </tr>
                    <tr>
                        <td valign="top" >���˹ѡ�Ժ���˹��� </td>
                        <td colspan="2" >
                            <table cellspacing="0" cellpadding="0" border="0">
                                <tr>
                                    <td style="width: 100px">��͹�����(����)</td>
                                    <td><asp:TextBox ID="txtWeight" runat="server" Width="106px" CssClass="zTextboxR" ></asp:TextBox></td>
                                    <td style="width:120px" align="right" >��ѧ�����(����)</td>
                                    <td>&nbsp;&nbsp;&nbsp;<asp:TextBox ID="txtWeightPrepare" runat="server" Width="106px" CssClass="zTextboxR" ></asp:TextBox></td>
                                </tr>
                            </table>
                        </td>
                    </tr>
                    <tr style="height:10px;">
                    </tr>
                    <tr>
                        <td valign="top" >
                            ��Ǥٳ���˹ѡ�ء
                        </td>
                        <td colspan="2">
                            <table cellspacing="0" cellpadding="0" border="0">
                                <tr>
                                    <td style="width: 100px">�������ᡧ</td>
                                    <td><asp:TextBox ID="txtWeightCookBO" runat="server" Width="106px" CssClass="zTextboxR" Text="1"></asp:TextBox></td>
                                    <td style="width: 120px" align="right" >�Ѵ</td>
                                    <td>&nbsp;&nbsp;&nbsp;<asp:TextBox ID="txtWeightCookFY" runat="server" Width="106px" CssClass="zTextboxR" Text="1" ></asp:TextBox></td>
                                </tr>
                                <tr>
                                    <td >��ҧ</td>
                                    <td><asp:TextBox ID="txtWeightCookRO" runat="server" Width="106px" CssClass="zTextboxR" Text="1" ></asp:TextBox></td>
                                    <td align="right">�ʹ</td>
                                    <td>&nbsp;&nbsp;&nbsp;<asp:TextBox ID="txtWeightCookFR" runat="server" Width="106px" CssClass="zTextboxR" Text="1" ></asp:TextBox></td>
                                </tr>
                                <tr>
                                    <td >���</td>
                                    <td><asp:TextBox ID="txtWeightCookNN" runat="server" Width="106px" CssClass="zTextboxR" Text="1" ></asp:TextBox></td>
                                    <td align="right">���</td>
                                    <td>&nbsp;&nbsp;&nbsp;<asp:TextBox ID="txtWeightCookST" runat="server" Width="106px" CssClass="zTextboxR" Text="1" ></asp:TextBox></td>
                                </tr>
                                <tr>
                                    <td >ͺ</td>
                                    <td><asp:TextBox ID="txtWeightCookPE" runat="server" Width="106px" CssClass="zTextboxR" Text="1" ></asp:TextBox></td>
                                    <td align="right">&nbsp;</td>
                                    <td>&nbsp;&nbsp;&nbsp;</td>
                                </tr>
                            </table>
                        </td>
                    </tr>
                    <tr style="height:10px;">
                    </tr>
                    <tr style="height:10px;">
                        <td colspan="3" >����ҳ����ѹ(����) ���Դ��������ǹ����Ѻ��зҹ�� 100 ����
                        </td>
                    </tr>
                    <tr>
                        <td style="width: 125px">&nbsp;
                        </td>
                        <td colspan="2">
                            <table cellspacing="0" cellpadding="0" border="0">
                                <tr>
                                    <td style="width: 100px">�Ѵ</td>
                                    <td><asp:TextBox ID="txtOilFY" runat="server" Width="106px" CssClass="zTextboxR" ></asp:TextBox></td>
                                    <td style="width: 120px" align="right" >�ʹ</td>
                                    <td>&nbsp;&nbsp;&nbsp;<asp:TextBox ID="txtOilFR" runat="server" Width="106px" CssClass="zTextboxR" ></asp:TextBox></td>
                                </tr>
                            </table>
                        </td>
                    </tr>

                    <tr style="height:10px;">
                    </tr>
                    <tr>
                        <td style="width: 125px">�Ҥҵ��˹���
                        </td>
                        <td colspan="2">
                            <table cellspacing="0" cellpadding="0" border="0">
                                <tr>
                                    <td style="width: 100px">�Ҥҷع</td>
                                    <td><asp:TextBox ID="txtCost" runat="server" Width="106px" CssClass="zTextboxR" ></asp:TextBox></td>
                                    <td style="width: 120px" align="right" >�ҤҢ��</td>
                                    <td>&nbsp;&nbsp;&nbsp;<asp:TextBox ID="txtPrice" runat="server" Width="106px" CssClass="zTextboxR" ></asp:TextBox></td>
                                </tr>
                            </table>
                        </td>
                    </tr>
                    <tr>
                        <td style="width: 125px" valign="top">Spec
                        </td>
                        <td><asp:TextBox ID="txtSpec" runat="server" Width="296px" Rows="3" TextMode="MultiLine" CssClass="zTextbox" ></asp:TextBox>
                            <asp:Label id="Label6" runat="server" Text="*" ForeColor="Red"></asp:Label>
                        </td>
                        <td>
                        </td>
                    </tr>
                    <tr>
                        <td style="width: 125px">�Ըա���Ѻ���
                        </td>
                        <td><asp:DropDownList ID="cmbOrderType" runat="server" Width="199px" CssClass="zComboBox"></asp:DropDownList>
                            <asp:Label id="Label4" runat="server" Text="*" ForeColor="Red"></asp:Label>
                        </td>
                        <td>
                        </td>
                    </tr>
                    <tr>
                        <td style="width: 125px">˹��§ҹ���Ѵ����
                        </td>
                        <td><asp:DropDownList ID="cmbDivision" runat="server" Width="199px" CssClass="zComboBox"></asp:DropDownList>
                            <asp:Label id="Label5" runat="server" Text="*" ForeColor="Red"></asp:Label>
                        </td>
                        <td>
                        </td>
                    </tr>
                    <tr style="height:10px;">
                    </tr>
                    <tr>
                        <td style="width: 125px" valign="top">�������ʴ�
                        </td>
                        <td>
                            <table cellspacing="0" cellpadding="0" border="0" >
                                <tr>
                                    <td style="width: 80px">
                                        ���
                                    </td>
                                    <td style="width: 101px">
                                        <asp:RadioButton ID="radMorningAdvance" GroupName="Morning" runat="server" Text="��ǧ˹��" Checked="True" />
                                    </td>
                                    <td>
                                        <asp:RadioButton ID="radMorningDay" GroupName="Morning" runat="server" Text="�ç�ѹ" />
                                    </td>
                                </tr>
                                <tr>
                                    <td style="width: 80px">
                                        ��ҧ�ѹ
                                    </td>
                                    <td style="width: 101px"> 
                                        <asp:RadioButton ID="radNoonAdvance" GroupName="Noon" runat="server" Text="��ǧ˹��" Checked="True" />
                                    </td>
                                    <td>
                                        <asp:RadioButton ID="radNoonDay" GroupName="Noon" runat="server" Text="�ç�ѹ" />
                                    </td>
                                </tr>
                                <tr>
                                    <td style="width: 80px">
                                        ���
                                    </td>
                                    <td style="width: 101px">
                                        <asp:RadioButton ID="radEveningAdvance" GroupName="Evening" runat="server" Text="��ǧ˹��" />
                                    </td>
                                    <td>
                                        <asp:RadioButton ID="radEveningDay" GroupName="Evening" runat="server" Text="�ç�ѹ" Checked="True" />
                                    </td>
                                </tr>
                            </table>
                        </td>
                        <td>
                        </td>
                    </tr>
                    <tr>
                        <td style="width: 125px">&nbsp;
                        </td>
                        <td><asp:CheckBox ID="chkIsCount" runat="server" Text="�Ѻʵ�͡" ></asp:CheckBox>
                            <asp:CheckBox ID="chkIsMenu" runat="server" Text="�ʴ������" /></td>
                        <td>
                        </td>
                    </tr>
                    <tr style="height:10px;">
                    </tr>
                    <tr>
                        <td style="width: 125px">�Ǻ�������ҳ
                        </td>
                        <td colspan="2" >
                            <table cellspacing="0" cellpadding="0" border="0">
                                <tr>
                                    <td style="width: 100px">����ش</td>
                                    <td><asp:TextBox ID="txtMinStock" runat="server" Width="106px" CssClass="zTextboxR" ></asp:TextBox></td>
                                    <td style="width: 120px" align="right" >�٧�ش</td>
                                    <td>&nbsp;&nbsp;&nbsp;<asp:TextBox ID="txtMaxStock" runat="server" Width="106px" CssClass="zTextboxR" ></asp:TextBox></td>
                                </tr>
                            </table>
                        </td>
                    </tr>
                    <tr>
                        <td style="width: 125px" valign="top">�����˵�
                        </td>
                        <td><asp:TextBox ID="txtRemarks" runat="server" Width="296px" Rows="3" TextMode="MultiLine" CssClass="zTextbox" ></asp:TextBox>
                        </td>
                        <td>
                        </td>
                    </tr>
                    <tr style="height:3px;">
                    </tr>
                </table>
            </ContentTemplate>
        </cc1:TabPanel>
        <cc1:TabPanel ID="tabFoodUnit" runat="server" HeaderText="˹�������">
            <ContentTemplate>
                <table cellspacing="0" cellpadding="1" border="0" >
                    <tr>
                        <td style="width: 100px">
                        </td>
                        <td><asp:Label ID="lbStatusTab2" runat="server" EnableViewState="False"></asp:Label>
                        </td>
                    </tr>
                    <tr>
                        <td style="width: 100px">������ʴ�
                        </td>
                        <td><asp:TextBox ID="txtCode_FoodUnit" runat="server" Width="123px" CssClass="zTextbox-View" ReadOnly="True" ></asp:TextBox>&nbsp;&nbsp;&nbsp;
                        </td>
                    </tr>
                    <tr>
                        <td style="width: 100px">������ʴ������
                        </td>
                        <td><asp:TextBox ID="txtName_FoodUnit" runat="server" Width="296px" CssClass="zTextbox-View" ReadOnly="True" ></asp:TextBox>
                    </tr>
                    <tr>
                        <td style="width: 100px">��Ǵ�����
                        </td>
                        <td><asp:TextBox ID="txtMaterialClass_FoodUnit" runat="server" Width="260px" CssClass="zTextbox-View" ReadOnly="True" ></asp:TextBox>
                    </tr>
                    <tr>
                        <td style="width: 100px">�����������
                        </td>
                        <td><asp:TextBox ID="txtMaterialGroup_FoodUnit" runat="server" Width="260px" CssClass="zTextbox-View" ReadOnly="True" ></asp:TextBox>
                    </tr>
                    <tr>
                        <td style="width: 100px">˹�����ѡ
                        </td>
                        <td><asp:TextBox ID="txtUnit_FoodUnit" runat="server" Width="260px" CssClass="zTextbox-View" ReadOnly="True" ></asp:TextBox>
                    </tr>
                </table><br />
                <table cellspacing="0" cellpadding="0" border="0" width="100%">
                    <tr>
                        <td class="t_headtext" style="height: 25px">
                            &nbsp;˹�������
                        </td>
                    </tr>
                </table>
                <asp:GridView ID="gvFoodUnit" runat="server" AllowSorting="True" ShowFooter="True" AutoGenerateColumns="False" CssClass="t_tablestyle" OnRowDataBound="gvFoodUnit_RowDataBound" OnRowEditing="gvFoodUnit_RowEditing" OnRowCancelingEdit="gvFoodUnit_RowCancelingEdit" OnRowDeleting="gvFoodUnit_RowDeleting" OnRowUpdating="gvFoodUnit_RowUpdating"   >
                    <Columns>
                        <asp:BoundField DataField="MMLOID" HeaderText="MMLOID">
                            <ControlStyle CssClass="zHidden" />
                            <FooterStyle CssClass="zHidden" />
                            <HeaderStyle CssClass="zHidden" />
                            <ItemStyle CssClass="zHidden" />
                        </asp:BoundField>
                        <asp:TemplateField ShowHeader="False">
                                <EditItemTemplate>
                                    <asp:ImageButton ID="imbSave" runat="server" CausesValidation="true" CommandName="Update" ImageUrl="~/Images/save2.png" />&nbsp;
                                    <asp:ImageButton ID="imbCancel" runat="server" CausesValidation="False" CommandName="Cancel" ImageUrl="~/Images/cancel.png"/>
                                </EditItemTemplate>
                                <ItemTemplate>
                                    <asp:ImageButton ID="imbEdit" runat="server" CausesValidation="true" CommandName="Edit" ImageUrl="~/Images/icn_edit.png" />&nbsp;
                                    <asp:ImageButton ID="imbDelete" runat="server" CausesValidation="true" CommandName="Delete" ImageUrl="~/Images/icn_delete.png" OnClientClick="return confirm('��ͧ���ź������ ���������?')"/>
                                </ItemTemplate>
                                <FooterTemplate>
                                    <asp:ImageButton ID="imbSaveUnit" runat="server" ImageUrl="~/Images/save2.png" OnClick="imbSaveUnit_Click" />
                                </FooterTemplate>
                            <HeaderStyle Width="60px" />
                            <ItemStyle HorizontalAlign="Center" Width="60px" />
                            <FooterStyle HorizontalAlign="Center" />
                        </asp:TemplateField>
                        <asp:TemplateField HeaderText="˹��¹Ѻ">
                            <ItemTemplate>
                                <asp:Label ID="lbTHNAME" runat="server" Text='<%# Bind("THNAME") %>'></asp:Label>
                            </ItemTemplate>
                            <EditItemTemplate>
                                <asp:DropDownList ID="cmbTHUNIT" runat="server" CssClass="zComboBox" Width="105px"></asp:DropDownList>
                                <asp:Label ID="lblTHUNITAdd1" runat="server" Text="*" ForeColor="red"></asp:Label>
                            </EditItemTemplate>
                            <FooterTemplate>
                                <asp:DropDownList ID="cmbTHUNITAdd" runat="server" CssClass="zComboBox" Width="105px" />
                                <asp:Label ID="lblTHUNITAdd" runat="server" Text="*" ForeColor="red"></asp:Label>
                            </FooterTemplate>
                            <FooterStyle HorizontalAlign="Center" />
                            <HeaderStyle HorizontalAlign="Center" Width="120px" />
                            <ItemStyle HorizontalAlign="Left" Width="120px" />
                        </asp:TemplateField>
                        <asp:TemplateField HeaderText="���˹ѡ���˹���(g)">
                            <ItemTemplate>
                                <asp:Label ID="lblWeight" runat="server" Text='<%# Bind("WEIGHT") %>'></asp:Label>
                            </ItemTemplate>
                            <EditItemTemplate>
                                <asp:TextBox ID="txtWeight" runat="server" CssClass="zTextboxR" Width="70px"></asp:TextBox>
                                <asp:Label ID="lblWeightAdd1" runat="server" Text="*" ForeColor="red"></asp:Label>
                            </EditItemTemplate>
                            <FooterTemplate>
                                <asp:TextBox ID="txtWeightAdd" runat="server" CssClass="zTextboxR" Width="70px" />
                                <asp:Label ID="lblWeightAdd" runat="server" Text="*" ForeColor="red"></asp:Label>
                            </FooterTemplate>
                            <FooterStyle HorizontalAlign="Center" />
                            <HeaderStyle HorizontalAlign="Center" Width="90px" />
                            <ItemStyle HorizontalAlign="Right" Width="90px" />
                        </asp:TemplateField>
                        <asp:TemplateField HeaderText="�Ҥҷع">
                            <ItemTemplate>
                                <asp:Label ID="lblCost" runat="server" Text='<%# Bind("COST") %>'></asp:Label>
                            </ItemTemplate>
                            <EditItemTemplate>
                                <asp:TextBox ID="txtCost" runat="server" CssClass="zTextboxR"  Width="70px"></asp:TextBox>
                            </EditItemTemplate>
                            <FooterTemplate>
                                <asp:TextBox ID="txtCostAdd" runat="server" CssClass="zTextboxR" Width="70px" />
                            </FooterTemplate>
                            <FooterStyle HorizontalAlign="Center" />
                            <HeaderStyle HorizontalAlign="Center" Width="80px" />
                            <ItemStyle HorizontalAlign="Right" Width="80px" />
                        </asp:TemplateField>
                        <asp:TemplateField HeaderText="�ҤҢ��">
                            <ItemTemplate>
                                <asp:Label ID="lblPrice" runat="server" Text='<%# Bind("PRICE") %>'></asp:Label>
                            </ItemTemplate>
                            <EditItemTemplate>
                                <asp:TextBox ID="txtPrice" runat="server" CssClass="zTextboxR"  Width="70px"></asp:TextBox>
                            </EditItemTemplate>
                            <FooterTemplate>
                                <asp:TextBox ID="txtPriceAdd" runat="server" CssClass="zTextboxR" Width="70px" />
                            </FooterTemplate>
                            <FooterStyle HorizontalAlign="Center" />
                            <HeaderStyle HorizontalAlign="Center" Width="80px" />
                            <ItemStyle HorizontalAlign="Right" Width="80px" />
                        </asp:TemplateField>
                        <asp:TemplateField HeaderText="��Ǥٳ">
                            <ItemTemplate>
                                <asp:Label ID="lblMultiply" runat="server" Text='<%# Bind("MULTIPLY") %>'></asp:Label>
                            </ItemTemplate>
                            <EditItemTemplate>
                                <asp:TextBox ID="txtMultiply" runat="server" CssClass="zTextboxR"  Width="60px"></asp:TextBox>
                                <asp:Label ID="lblMultiplyAdd1" runat="server" Text="*" ForeColor="red"></asp:Label>
                            </EditItemTemplate>
                            <FooterTemplate>
                                <asp:TextBox ID="txtMultiplyAdd" runat="server" CssClass="zTextboxR" Width="60px" />
                                <asp:Label ID="lblMultiplyAdd" runat="server" Text="*" ForeColor="red"></asp:Label>
                            </FooterTemplate>
                            <FooterStyle HorizontalAlign="Center" />
                            <HeaderStyle HorizontalAlign="Center" Width="80px" />
                            <ItemStyle HorizontalAlign="Right" Width="80px" />
                        </asp:TemplateField>
                        <asp:TemplateField HeaderText="�Ѻ���">
                            <ItemTemplate>
                                <asp:CheckBox ID="chkIsStockIn" runat="server" Enabled="false"></asp:CheckBox>
                            </ItemTemplate>
                            <EditItemTemplate>
                                <asp:CheckBox ID="chkIsStockInEdit" runat="server" ></asp:CheckBox>
                            </EditItemTemplate>
                            <FooterTemplate>
                                <asp:CheckBox ID="chkIsStockInAdd" runat="server" />
                            </FooterTemplate>
                            <FooterStyle HorizontalAlign="Center" />
                            <HeaderStyle HorizontalAlign="Center" Width="60px" />
                            <ItemStyle HorizontalAlign="Center" Width="60px" />
                        </asp:TemplateField>
                        <asp:TemplateField HeaderText="�ԡ����">
                            <ItemTemplate>
                                <asp:CheckBox ID="chkIsStockOut" runat="server" Enabled="false"></asp:CheckBox>
                            </ItemTemplate>
                            <EditItemTemplate>
                                <asp:CheckBox ID="chkIsStockOutEdit" runat="server" ></asp:CheckBox>
                            </EditItemTemplate>
                            <FooterTemplate>
                                <asp:CheckBox ID="chkIsStockOutAdd" runat="server"  />
                            </FooterTemplate>
                            <FooterStyle HorizontalAlign="Center" />
                            <HeaderStyle HorizontalAlign="Center" Width="60px" />
                            <ItemStyle HorizontalAlign="Center" Width="60px" />
                        </asp:TemplateField>
                        <asp:TemplateField HeaderText="���ҧ�ٵ�">
                            <ItemTemplate>
                                <asp:CheckBox ID="chkIsFormula" runat="server" Enabled="false"></asp:CheckBox>
                            </ItemTemplate>
                            <EditItemTemplate>
                                <asp:CheckBox ID="chkIsFormulaEdit" runat="server" ></asp:CheckBox>
                            </EditItemTemplate>
                            <FooterTemplate>
                                <asp:CheckBox ID="chkIsFormulaAdd" runat="server"  />
                            </FooterTemplate>
                            <FooterStyle HorizontalAlign="Center" />
                            <HeaderStyle HorizontalAlign="Center" Width="60px" />
                            <ItemStyle HorizontalAlign="Center" Width="60px" />
                        </asp:TemplateField>
                        <asp:TemplateField HeaderText="��ҹ">
                            <ItemTemplate>
                                <asp:CheckBox ID="chkActive" runat="server" Enabled="false"></asp:CheckBox>
                            </ItemTemplate>
                            <EditItemTemplate>
                                <asp:CheckBox ID="chkActiveEdit" runat="server" ></asp:CheckBox>
                            </EditItemTemplate>
                            <FooterTemplate>
                                <asp:CheckBox ID="chkActiveAdd" runat="server" Checked="true"  />
                            </FooterTemplate>
                            <FooterStyle HorizontalAlign="Center" />
                            <HeaderStyle HorizontalAlign="Center" Width="60px" />
                            <ItemStyle HorizontalAlign="Center" Width="60px" />
                        </asp:TemplateField>
                        <asp:BoundField DataField="WEIGHT" HeaderText="WEIGHT" ReadOnly="True">
                            <ControlStyle CssClass="zHidden" />
                            <FooterStyle CssClass="zHidden" />
                            <HeaderStyle CssClass="zHidden" />
                            <ItemStyle CssClass="zHidden" />
                        </asp:BoundField>
                        <asp:BoundField DataField="COST" HeaderText="COST" ReadOnly="True">
                            <ControlStyle CssClass="zHidden" />
                            <FooterStyle CssClass="zHidden" />
                            <HeaderStyle CssClass="zHidden" />
                            <ItemStyle CssClass="zHidden" />
                        </asp:BoundField>
                        <asp:BoundField DataField="PRICE" HeaderText="PRICE" ReadOnly="True">
                            <ControlStyle CssClass="zHidden" />
                            <FooterStyle CssClass="zHidden" />
                            <HeaderStyle CssClass="zHidden" />
                            <ItemStyle CssClass="zHidden" />
                        </asp:BoundField>
                        <asp:BoundField DataField="MULTIPLY" HeaderText="MULTIPLY" ReadOnly="True">
                            <ControlStyle CssClass="zHidden" />
                            <FooterStyle CssClass="zHidden" />
                            <HeaderStyle CssClass="zHidden" />
                            <ItemStyle CssClass="zHidden" />
                        </asp:BoundField>
                        <asp:BoundField DataField="ISSTOCKIN" HeaderText="ISSTOCKIN" ReadOnly="True">
                            <ControlStyle CssClass="zHidden" />
                            <FooterStyle CssClass="zHidden" />
                            <HeaderStyle CssClass="zHidden" />
                            <ItemStyle CssClass="zHidden" />
                        </asp:BoundField>
                        <asp:BoundField DataField="ISSTOCKOUT" HeaderText="ISSTOCKOUT" ReadOnly="True">
                            <ControlStyle CssClass="zHidden" />
                            <FooterStyle CssClass="zHidden" />
                            <HeaderStyle CssClass="zHidden" />
                            <ItemStyle CssClass="zHidden" />
                        </asp:BoundField>
                        <asp:BoundField DataField="ISFORMULA" HeaderText="ISFORMULA" ReadOnly="True">
                            <ControlStyle CssClass="zHidden" />
                            <FooterStyle CssClass="zHidden" />
                            <HeaderStyle CssClass="zHidden" />
                            <ItemStyle CssClass="zHidden" />
                        </asp:BoundField>
                        <asp:BoundField DataField="ACTIVE" HeaderText="ACTIVE" ReadOnly="True">
                            <ControlStyle CssClass="zHidden" />
                            <FooterStyle CssClass="zHidden" />
                            <HeaderStyle CssClass="zHidden" />
                            <ItemStyle CssClass="zHidden" />
                        </asp:BoundField>
                        <asp:BoundField DataField="UNITLOID" HeaderText="UNITLOID" ReadOnly="True">
                            <ControlStyle CssClass="zHidden" />
                            <FooterStyle CssClass="zHidden" />
                            <HeaderStyle CssClass="zHidden" />
                            <ItemStyle CssClass="zHidden" />
                        </asp:BoundField>
                        <asp:BoundField DataField="ISMAIN" HeaderText="ISMAIN" ReadOnly="True">
                            <ControlStyle CssClass="zHidden" />
                            <FooterStyle CssClass="zHidden" />
                            <HeaderStyle CssClass="zHidden" />
                            <ItemStyle CssClass="zHidden" />
                        </asp:BoundField>
                    </Columns>
                    <HeaderStyle CssClass="t_headtext" />
                    <AlternatingRowStyle CssClass="t_alt_bg" />
                    <PagerSettings Visible="False" />
                </asp:GridView>
                &nbsp;
            </ContentTemplate>
        </cc1:TabPanel>
        <cc1:TabPanel ID="tabFoodNutrient" runat="server" HeaderText="��������">
            <ContentTemplate>
                <table cellspacing="0" cellpadding="0" border="0" >
                    <tr>
                        <td style="width: 100px">
                        </td>
                        <td><asp:Label ID="lbStatusTab3" runat="server" EnableViewState="False"></asp:Label>
                        </td>
                    </tr>
                    <tr>
                        <td style="width: 127px">
                            &nbsp;&nbsp;���� SAP
                        </td>
                        <td>
                            <asp:TextBox ID="txtMSap" runat="server" Width="100px" CssClass="zTextbox-View"></asp:TextBox>&nbsp;&nbsp;
                        </td>
                        <td>
                        </td>
                    </tr>
                                        <tr>
                        <td style="width: 127px">
                            &nbsp;&nbsp;������ʴ������
                        </td>
                        <td>
                            <asp:TextBox ID="txtMName" runat="server" Width="200px" CssClass="zTextbox-View"></asp:TextBox>&nbsp;&nbsp;
                        </td>
                        <td>
                        </td>
                    </tr>
                                        <tr>
                        <td style="width: 127px">
                            &nbsp;&nbsp;�����������
                        </td>
                        <td>
                            <asp:TextBox ID="txtMType" runat="server" Width="200px" CssClass="zTextbox-View"></asp:TextBox>&nbsp;&nbsp;
                        </td>
                        <td>
                        </td>
                    </tr>
                                        <tr>
                        <td style="width: 127px">
                            &nbsp;&nbsp;˹�����ѡ
                        </td>
                        <td>
                            <asp:TextBox ID="txtMUnit" runat="server" Width="100px" CssClass="zTextbox-View"></asp:TextBox>&nbsp;&nbsp;
                        </td>
                        <td>
                        </td>
                    </tr>                    
                    <tr>
                        <td colspan="2">
                            &nbsp;&nbsp;���˹ѡ����Ѻ��ӹǳ��ѧ�ҹ�����������
                        </td>
                        <td>
                        </td>
                    </tr> 
                    <tr>
                        <td style="width: 127px">
                            &nbsp;&nbsp;
                        </td>
                        <td>
                            <asp:TextBox ID="txtMWeight" runat="server" Width="100px" CssClass="zTextboxR"></asp:TextBox>&nbsp;&nbsp;����
                        </td>
                        <td>
                        </td>
                    </tr>                   
                    <tr>
                        <td style="width: 127px">
                            &nbsp;&nbsp;��ѧ�ҹ������Ѻ
                        </td>
                        <td>
                            <asp:TextBox ID="txtKcal" runat="server" Width="100px" CssClass="zTextboxR-View"></asp:TextBox>&nbsp;&nbsp;Kcal 
                        </td>
                        <td>
                            <asp:TextBox ID="txhSortFieldTabNutrient" runat="server" Visible="False" Width="15px"></asp:TextBox>
                            <asp:TextBox ID="txhSortDirTabNutrient" runat="server" Visible="False" Width="15px"></asp:TextBox>
                        </td>
                    </tr>
                </table><br />
                <table cellspacing="0" cellpadding="0" border="0" width="100%">
                    <tr>
                        <td class="t_headtext" style="height: 25px">
                            &nbsp;�������÷�����Ѻ
                        </td>
                    </tr>
                </table>
                <asp:GridView ID="gvFoodNutrient" runat="server" AllowSorting="True" ShowFooter="True" AutoGenerateColumns="False" CssClass="t_tablestyle" OnSorting="gvFoodNutrient_Sorting" OnRowDataBound="gvFoodNutrient_RowDataBound" OnRowDeleting="gvFoodNutrient_RowDeleting" OnRowCancelingEdit="gvFoodNutrient_RowCancelingEdit" OnRowEditing="gvFoodNutrient_RowEditing" OnRowUpdating="gvFoodNutrient_RowUpdating">
                    <Columns>
                        <asp:BoundField DataField="NUTRIENTLOID" HeaderText="NUTRIENTLOID">
                            <ControlStyle CssClass="zHidden" />
                            <FooterStyle CssClass="zHidden" />
                            <HeaderStyle CssClass="zHidden" />
                            <ItemStyle CssClass="zHidden" />
                        </asp:BoundField>
                        <asp:TemplateField ShowHeader="False">
                                <EditItemTemplate>
                                    <asp:ImageButton ID="imbgvFoodNutrientSave" runat="server" CausesValidation="true" CommandName="Update" ImageUrl="~/Images/save2.png" />&nbsp;
                                    <asp:ImageButton ID="imbgvFoodNutrientCancel" runat="server" CausesValidation="False" CommandName="Cancel" ImageUrl="~/Images/cancel.png"/>
                                </EditItemTemplate>
                                <ItemTemplate>
                                    <asp:ImageButton ID="imbgvFoodNutrientEdit" runat="server" CausesValidation="true" CommandName="Edit" ImageUrl="~/Images/icn_edit.png" />&nbsp;
                                    <asp:ImageButton ID="imbgvFoodNutrientDelete" runat="server" CausesValidation="true" CommandName="Delete" ImageUrl="~/Images/icn_delete.png" OnClientClick="return confirm('��ͧ���ź������ ���������?')"/>
                                </ItemTemplate>
                                <FooterTemplate>
                                    <asp:ImageButton ID="imbgvFoodNutrientAdd" runat="server" ImageUrl="~/Images/save2.png" OnClick="imbgvFoodNutrientAdd_Click" />
                                </FooterTemplate>
                            <HeaderStyle Width="60px" />
                            <ItemStyle HorizontalAlign="Center" Width="60px" />
                            <FooterStyle HorizontalAlign="Center" />
                        </asp:TemplateField>
                        <asp:TemplateField HeaderText="�ӴѺ">
                            <ItemTemplate>
                                <%# Container.DataItemIndex + 1 %>
                            </ItemTemplate> 
                            <EditItemTemplate>
                                <%# Container.DataItemIndex + 1 %>
                            </EditItemTemplate> 
                            <HeaderStyle HorizontalAlign="Center" Width="50px" />
                            <ItemStyle HorizontalAlign="Center" Width="50px" />
                        </asp:TemplateField>
                        <asp:TemplateField HeaderText="��������" SortExpression="NUTRIENTNAME">
                            <ItemTemplate>
                                <asp:Label ID="lblNUTRIENTNAME" runat="server" Text='<%# Bind("NUTRIENTNAME") %>'></asp:Label>
                            </ItemTemplate>
                            <EditItemTemplate>
                                <asp:DropDownList ID="cmbNUTRIENTNAMEEdit" runat="server" CssClass="zComboBox" Width="165px"></asp:DropDownList>
                                <asp:Label ID="lblNUTRIENTNAMEAdd1" runat="server" Text="*" ForeColor="red"></asp:Label>
                            </EditItemTemplate>
                            <FooterTemplate>
                                <asp:DropDownList ID="cmbNUTRIENTNAMEAdd" runat="server" CssClass="zComboBox" Width="165px" />
                                <asp:Label ID="lblNUTRIENTNAMEAdd" runat="server" Text="*" ForeColor="red"></asp:Label>
                            </FooterTemplate>
                            <FooterStyle HorizontalAlign="Center" />
                            <HeaderStyle HorizontalAlign="Center" Width="180px" />
                            <ItemStyle HorizontalAlign="Left" Width="180px" />
                        </asp:TemplateField>
                        <asp:TemplateField HeaderText="����ҳ">
                            <ItemTemplate>
                                <asp:Label ID="lblQTY" runat="server" Text='<%# Bind("QTY") %>'></asp:Label>
                            </ItemTemplate>
                            <EditItemTemplate>
                                <asp:TextBox ID="txtQTYEdit" runat="server" CssClass="zTextboxR"  Width="100px"></asp:TextBox>
                                <asp:Label ID="lblQTYAdd1" runat="server" Text="*" ForeColor="red"></asp:Label>
                            </EditItemTemplate>
                            <FooterTemplate>
                                <asp:TextBox ID="txtQTYAdd" runat="server" CssClass="zTextboxR" Width="100px" />
                                <asp:Label ID="lblQTYAdd" runat="server" Text="*" ForeColor="red"></asp:Label>
                            </FooterTemplate>
                            <FooterStyle HorizontalAlign="Center" />
                            <HeaderStyle HorizontalAlign="Center" Width="120px" />
                            <ItemStyle HorizontalAlign="Right" Width="120px" />
                        </asp:TemplateField>
                        <asp:BoundField DataField="UNITNAME" HeaderText="˹��¹Ѻ" ReadOnly="True" HeaderStyle-Width="120px" ItemStyle-Width="120px">      
                        </asp:BoundField>
                        <asp:BoundField DataField="NUTRIENTLOID" HeaderText="NUTRIENTLOID" ReadOnly="True" >
                            <ControlStyle CssClass="zHidden" />
                            <FooterStyle CssClass="zHidden" />
                            <HeaderStyle CssClass="zHidden" />
                            <ItemStyle CssClass="zHidden" />
                        </asp:BoundField>
                        <asp:BoundField DataField="QTY" HeaderText="QTY" ReadOnly="True">
                            <ControlStyle CssClass="zHidden" />
                            <FooterStyle CssClass="zHidden" />
                            <HeaderStyle CssClass="zHidden" />
                            <ItemStyle CssClass="zHidden" />
                        </asp:BoundField>
                    </Columns>
                    <HeaderStyle CssClass="t_headtext" />
                    <AlternatingRowStyle CssClass="t_alt_bg" />
                    <PagerSettings Visible="False" />
                </asp:GridView>
            </ContentTemplate>
        </cc1:TabPanel>
        <cc1:TabPanel ID="tabSeason" runat="server" HeaderText="Ĵ١��">
            <ContentTemplate>
                <table cellspacing="0" cellpadding="0" border="0">
                    <tr>
                        <td style="width: 100px">
                        </td>
                        <td><asp:Label ID="lbStatusTab4" runat="server" EnableViewState="False"></asp:Label>
                        </td>
                    </tr>
                </table>
                <table cellspacing="0" cellpadding="0" border="1" style="border-collapse: collapse">
                    <tr>
                        <td class="t_headtext" align="center" style="width: 40px">
                            <asp:CheckBox ID="chkAll" runat="server" Checked="true" />
                        </td>
                        <td class="t_headtext" style="height: 25px; width: 145px;" align="center">
                            &nbsp;��͹����ը�˹���
                        </td>
                    </tr>
                    <tr>
                        <td align="center" style="width: 40px">
                            <asp:CheckBox ID="chkM1" runat="server" Checked="true" />
                        </td>
                        <td style="height: 25px; width: 145px;" align="center">
                            &nbsp;���Ҥ�
                        </td>
                    </tr>
                    <tr>
                        <td class="t_alt_bg" align="center" style="width: 40px">
                            <asp:CheckBox ID="chkM2" runat="server" Checked="true" />
                        </td>
                        <td style="height: 25px; width: 145px;" class="t_alt_bg" align="center">
                            &nbsp;����Ҿѹ��
                        </td>
                    </tr>
                    <tr>
                        <td align="center" style="width: 40px">
                            <asp:CheckBox ID="chkM3" runat="server" Checked="true" />
                        </td>
                        <td style="height: 25px; width: 145px;" align="center">
                            &nbsp;�չҤ�
                        </td>
                    </tr>
                    <tr>
                        <td class="t_alt_bg" align="center" style="width: 40px">
                            <asp:CheckBox ID="chkM4" runat="server" Checked="true" />
                        </td>
                        <td style="height: 25px; width: 145px;" class="t_alt_bg" align="center">
                            &nbsp;����¹
                        </td>
                    </tr>
                    <tr>
                        <td align="center" style="width: 40px">
                            <asp:CheckBox ID="chkM5" runat="server" Checked="true" />
                        </td>
                        <td style="height: 25px; width: 145px;" align="center">
                            &nbsp;����Ҥ�
                        </td>
                    </tr>
                    <tr>
                        <td class="t_alt_bg" align="center" style="width: 40px">
                            <asp:CheckBox ID="chkM6" runat="server" Checked="true" />
                        </td>
                        <td style="height: 25px; width: 145px;" class="t_alt_bg" align="center">
                            &nbsp;�Զع�¹
                        </td>
                    </tr>
                    <tr>
                        <td align="center" style="width: 40px">
                            <asp:CheckBox ID="chkM7" runat="server" Checked="true" />
                        </td>
                        <td style="height: 25px; width: 145px;" align="center">
                            &nbsp;�á�Ҥ�
                        </td>
                    </tr>
                    <tr>
                        <td class="t_alt_bg" align="center" style="width: 40px">
                            <asp:CheckBox ID="chkM8" runat="server" Checked="true" />
                        </td>
                        <td style="height: 25px; width: 145px;" class="t_alt_bg" align="center"> 
                            &nbsp;�ԧ�Ҥ�
                        </td>
                    </tr>
                    <tr>
                        <td align="center" style="width: 40px">
                            <asp:CheckBox ID="chkM9" runat="server" Checked="true" />
                        </td>
                        <td style="height: 25px; width: 145px;" align="center">
                            &nbsp;�ѹ��¹
                        </td>
                    </tr>
                    <tr>
                        <td class="t_alt_bg" align="center" style="width: 40px">
                            <asp:CheckBox ID="chkM10" runat="server" Checked="true" />
                        </td>
                        <td style="height: 25px; width: 145px;" class="t_alt_bg" align="center">
                            &nbsp;���Ҥ�
                        </td>
                    </tr>
                    <tr>
                        <td align="center" style="width: 40px">
                            <asp:CheckBox ID="chkM11" runat="server" Checked="true" />
                        </td>
                        <td style="height: 25px; width: 145px;" align="center">
                            &nbsp;��Ȩԡ�¹
                        </td>
                    </tr>
                    <tr>
                        <td class="t_alt_bg" align="center" style="width: 40px">
                            <asp:CheckBox ID="chkM12" runat="server" Checked="true" />
                        </td>
                        <td style="height: 25px; width: 145px;" class="t_alt_bg" align="center">
                            &nbsp;�ѹ�Ҥ�
                        </td>
                    </tr>
                </table>
            </ContentTemplate>
        </cc1:TabPanel>
    </cc1:TabContainer>
    </asp:Panel>
</asp:Content>
