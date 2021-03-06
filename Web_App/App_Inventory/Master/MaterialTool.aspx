<%@ Page Language="C#"  MasterPageFile="~/Templates/Page1.master" AutoEventWireup="true" CodeFile="MaterialTool.aspx.cs" Inherits="App_Inventory_Master_MaterialTool"  Title="SHND : Master - Material Tool" %>

<%@ Register Src="../../Templates/PageControl.ascx" TagName="PageControl" TagPrefix="uc2" %>
<%@ Register Src="../../Templates/ToolBarItemCtl.ascx" TagName="ToolBarItemCtl" TagPrefix="uc1" %>
<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="cc1" %>

<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" Runat="Server">
    <script language="JavaScript" type="text/javascript">
        function TabContainer_ActiveTabChanged(sender, e)
        {
            __doPostBack('<%= TabContainer1.ClientID %>', sender.get_activeTab().get_headerText());
        }
    </script>
    <table width="100%" border="0" cellpadding="0" cellspacing="0">
                        <tr>
            <td class="headtext">
                ��������ʴ��ػ�ó�</td>
        </tr>
        <tr>
            <td>
            <uc1:ToolBarItemCtl ID="tbAdd" runat="server" ToobarTitle="����������" OnClick="tbAddClick" ToolbarImage="../../Images/icn_add.png"  />
                <uc1:ToolBarItemCtl ID="ToolBarItemCtl1" runat="server" ToobarTitle="ź�����ŷ�����͡" OnClick="tbDeleteClick" ToolbarImage="../../Images/icn_delete.png" ClientClick="return confirm('��ͧ���ź�����ŷ�����͡ ���������?')"  />
                <uc1:ToolBarItemCtl ID="tbPrint" runat="server" ToobarTitle="�����" ToolbarImage="../../Images/icn_print.png"  />
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
                
                    <table cellspacing="0" cellpadding="0" border="0" width="100%">
                        <tr style="height:15px">
                            <td colspan="2">&nbsp;</td>
                        </tr>
                        <tr>
                            <td style="width:120px; text-align: right; padding-right:10px">
                                ������ :</td>
                            <td>
                                <asp:DropDownList ID="cmbSearchGroup" runat="server" Width="205px">
                                </asp:DropDownList></td>
                        </tr>
                        <tr>
                            <td style="width:120px; text-align: right; padding-right:10px">
                                ������ʴ� :</td>
                            <td>
                                <asp:TextBox ID="txtSearchName" runat="server" CssClass="zTextbox" Width="200px"></asp:TextBox>
                                &nbsp; &nbsp;<asp:ImageButton ID="imbSearch" runat="server" ImageAlign="AbsMiddle" ImageUrl="~/Images/icn_find.png" OnClick="imbSearch_Click" />&nbsp;
                                <asp:ImageButton ID="imbReset" runat="server" ImageAlign="AbsMiddle" ImageUrl="~/Images/icn_back.png" OnClick="imbReset_Click" ToolTip="�ʴ�������" />
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
                <asp:GridView ID="gvMain" runat="server" AllowSorting="True" AutoGenerateColumns="False" CssClass="t_tablestyle" OnRowDataBound="gvMain_RowDataBound" 
                    OnSorting="gvMain_Sorting" AllowPaging="True" PageSize="20" Width="100%">
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
                        <asp:TemplateField HeaderText="���� SAP" SortExpression="SAPCODE">
                            <HeaderStyle HorizontalAlign="Center" Width="80px" />
                            <ItemStyle HorizontalAlign="Center" Width="80px" />
                            <ItemTemplate>
                                <asp:LinkButton ID="lnkName" runat="server" Text='<%# Bind("SAPCODE") %>' OnClick="lnkName_Click" CommandArgument='<%# Bind("LOID")  %>'></asp:LinkButton>
                            </ItemTemplate>
                        </asp:TemplateField>
                        <asp:BoundField DataField="MATERIALNAME" HeaderText="��¡��" SortExpression="MATERIALNAME">
                            <HeaderStyle Width="200px" />
                            <ItemStyle Width="200px" />
                        </asp:BoundField>
                        <asp:BoundField DataField="GROUPNAME" HeaderText="������" SortExpression="GROUPNAME">
                            <HeaderStyle HorizontalAlign="Center" Width="80px" />
                            <ItemStyle Width="80px" />
                        </asp:BoundField>
                        <asp:BoundField DataField="UNITNAME" HeaderText="˹��¹Ѻ" SortExpression="UNITNAME">
                            <HeaderStyle HorizontalAlign="Center" Width="80px" />
                            <ItemStyle Width="80px" />
                        </asp:BoundField>
                        <asp:BoundField DataField="ACTIVENAME" HeaderText="�����ҹ" SortExpression="ACTIVENAME">
                            <HeaderStyle HorizontalAlign="Center" Width="100px" />
                            <ItemStyle HorizontalAlign="Center" Width="100px" />
                        </asp:BoundField>
                        <asp:BoundField DataField="REMARKS" HeaderText="�����˵�" SortExpression="REMARKS">
                        </asp:BoundField>
                    </Columns>
                    <HeaderStyle CssClass="t_headtext" />
                    <AlternatingRowStyle CssClass="t_alt_bg" />
                    <PagerSettings Visible="False" />
                </asp:GridView>
                <uc2:PageControl ID="pcBot" runat="server" OnPageChange="PageChange" />
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
        <tr style="height:30px">
            <td>
                <hr style="size:1px" />
                <asp:Label ID="lbStatusTab" runat="server" EnableViewState="False"></asp:Label>
                <asp:TextBox ID="txhSortField" runat="server" Visible="False" Width="15px"></asp:TextBox>
                <asp:TextBox ID="txhSortDir" runat="server" Visible="False" Width="15px"></asp:TextBox>
                <asp:TextBox ID="txhID" runat="server" Visible="False" Width="15px"></asp:TextBox>
                <asp:TextBox ID="txtCurrTabIndex" Visible="False" runat="server" Width="32px">0</asp:TextBox>
            </td>
        </tr>
    </table>
    <cc1:TabContainer ID="TabContainer1" runat="server" ActiveTabIndex="0" OnActiveTabChanged="TabContainer1_ActiveTabChanged" AutoPostBack="true">
        <cc1:TabPanel ID="tabFeedDetail" runat="server" HeaderText="��������´">
            <ContentTemplate>
                <table border="0" cellspacing="0" cellpadding="0" width="100%">
                    <tr>
                        <td colspan="2"><asp:Label ID="lbStatusTab1" runat="server" EnableViewState="False"></asp:Label>
                        </td>
                    </tr> 
                    <tr>
                        <td>
                            <table border="0" cellpadding="0" cellspacing="0" width="500px">
                                <tr style="height:24px">
                                    <td style="padding-right:10px; text-align:right; width:140px">������ʴ� :
                                    </td> 
                                    <td>
                                        <asp:TextBox ID="txtCode" runat="server" Width="100px" Enabled="false" CssClass="zTextbox-View" ></asp:TextBox> 
                                    </td> 
                                </tr>
                                <tr style="height:24px">
                                    <td style="padding-right:10px; text-align:right; width:140px">
                                    </td> 
                                    <td>
                                        <asp:CheckBox ID="chkActive" runat="server" Text="��ҹ" Checked="true" ></asp:CheckBox>
                                    </td> 
                                </tr>
                                <tr style="height:24px">
                                    <td style="padding-right:10px; text-align:right; width:140px">������ʴ� :
                                    </td> 
                                    <td>
                                        <asp:TextBox ID="txtName" runat="server" Width="300px" CssClass="zTextbox" ></asp:TextBox>&nbsp;<span class="zRemark">*</span>
                                    </td> 
                                </tr>
                                <tr style="height:24px">
                                    <td style="padding-right:10px; text-align:right; width:140px">������ :
                                    </td> 
                                    <td>
                                        <asp:DropDownList ID="cmbMaterialGroup1" runat="server" Width="306px" CssClass="zComboBox" ></asp:DropDownList>&nbsp;<span class="zRemark">*</span>
                                    </td> 
                                </tr>
                                <tr style="height:24px">
                                    <td style="padding-right:10px; text-align:right; width:140px">˹��¹Ѻ :
                                    </td> 
                                    <td>
                                        <asp:DropDownList ID="cmbUnit1" runat="server" Width="106px" CssClass="zComboBox"></asp:DropDownList>&nbsp;<span class="zRemark">*</span>
                                    </td> 
                                </tr>
                                <tr style="height:24px">
                                    <td style="padding-right:10px; text-align:right; width:140px">���˹ѡ(����)���˹��� :
                                    </td> 
                                    <td>
                                        <asp:TextBox ID="txtWeight" runat="server" Width="100px" CssClass="zTextboxR" ></asp:TextBox> 
                                    </td> 
                                </tr>
                                <tr style="height:24px">
                                    <td style="padding-right:10px; text-align:right; width:140px">�Ҥҷع :
                                    </td> 
                                    <td>
                                        <asp:TextBox ID="txtCost" runat="server" Width="100px" CssClass="zTextboxR" ></asp:TextBox> 
                                    </td> 
                                </tr>
                                <tr style="height:24px">
                                    <td style="padding-right:10px; text-align:right; width:140px">�ҤҢ�� :
                                    </td> 
                                    <td>
                                        <asp:TextBox ID="txtPrice" runat="server" Width="100px" CssClass="zTextboxR" ></asp:TextBox> 
                                    </td> 
                                </tr>
                                <tr style="height:24px">
                                    <td style="padding-right:10px; text-align:right; width:140px; vertical-align:top">
                                        <table border="0" cellpadding="0" cellspacing="0" width="100px">
                                            <tr><td style="height:24px">Spec :</td></tr>
                                        </table>
                                    </td> 
                                    <td>
                                        <asp:TextBox ID="txtSpec" runat="server" Width="300px" Rows="4" TextMode="MultiLine" CssClass="zTextbox" ></asp:TextBox>
                                    </td> 
                                </tr>
                                <tr style="height:24px">
                                    <td style="padding-right:10px; text-align:right; width:140px">�Ըա���Ѻ��� :
                                    </td> 
                                    <td>
                                        <asp:DropDownList ID="cmbOrderType" runat="server" Width="306px" CssClass="zComboBox">
                                            <asp:ListItem Value="">���͡</asp:ListItem>
                                            <asp:ListItem Value="PO">��觫���</asp:ListItem>
                                            <asp:ListItem Value="RQ">�ԡ�ҡ��ѧ�ç��Һ��</asp:ListItem>
                                            <asp:ListItem Value="SA">�Ѻ�ҡ�к� SAP</asp:ListItem>
                                            <asp:ListItem Value="OT">�Ѻ�¡ó�����</asp:ListItem>
                                        </asp:DropDownList>&nbsp;<span class="zRemark">*</span>
                                    </td> 
                                </tr>
                                <tr style="height:24px">
                                    <td style="padding-right:10px; text-align:right; width:140px">˹��§ҹ���Ѵ���� :
                                    </td> 
                                    <td>
                                        <asp:DropDownList ID="cmbDivision" runat="server" Width="306px" CssClass="zComboBox"></asp:DropDownList>&nbsp;<span class="zRemark">*</span>
                                    </td> 
                                </tr>
                                <tr style="height:24px">
                                    <td style="padding-right:10px; text-align:right; width:140px">
                                    </td> 
                                    <td>
                                        <asp:CheckBox ID="chkIsCount" runat="server" Text="�Ѻʵ�͡" Checked="true" ></asp:CheckBox> 
                                    </td> 
                                </tr>
                                <tr style="height:24px">
                                    <td style="padding-right:10px; text-align:right; width:140px">����ҳ����ش :
                                    </td> 
                                    <td>
                                        <asp:TextBox ID="txtMinStock" runat="server" Width="100px" CssClass="zTextboxR" ></asp:TextBox> 
                                    </td> 
                                </tr>
                                <tr style="height:24px">
                                    <td style="padding-right:10px; text-align:right; width:140px">����ҳ�٧�ش :
                                    </td> 
                                    <td>
                                        <asp:TextBox ID="txtMaxStock" runat="server" Width="100px" CssClass="zTextboxR" ></asp:TextBox> 
                                    </td> 
                                </tr>
                                <tr style="height:24px">
                                    <td style="padding-right:10px; text-align:right; width:140px" valign="top">
                                        <table border="0" cellpadding="0" cellspacing="0" width="100px">
                                            <tr><td style="height:24px">�����˵� :</td></tr>
                                        </table>
                                    </td> 
                                    <td>
                                        <asp:TextBox ID="txtRemarks" runat="server" Width="300px" Rows="4" TextMode="MultiLine" CssClass="zTextbox" ></asp:TextBox> 
                                    </td> 
                                </tr>
                            </table>
                        </td>
                        <td valign="top">
                            <table border="0" cellpadding="0" cellspacing="0">
                                <tr>
                                    <td style="padding:10px; border-right: mediumorchid thin solid; border-top: mediumorchid thin solid; border-left: mediumorchid thin solid; border-bottom: mediumorchid thin solid;">
                                        <table cellspacing="0" cellpadding="0" border="0"  >
                                            <tr style="height:24px">
                                                <td style="width: 80px; padding-right:10px" align="right">���� SAP :</td>
                                                <td><asp:TextBox ID="txtSAP" runat="server" CssClass="zTextbox" Width="120px"></asp:TextBox></td>
                                            </tr>
                                            <tr style="height:24px">
                                                <td style="width: 80px; padding-right:10px" align="right">���ʤ���ѳ�� :</td>
                                                <td><asp:TextBox ID="txtArticle" runat="server" CssClass="zTextbox" Width="120px"></asp:TextBox></td>
                                            </tr>
                                            <tr style="height:24px">
                                                <td style="width: 80px; padding-right:10px" align="right">��ѧ SAP :</td>
                                                <td>
                                                    <asp:DropDownList ID="cmbSAP" CssClass="zComboBox" runat="server" Width="126px">
                                                    </asp:DropDownList></td>
                                            </tr>
                                        </table>
                                    </td> 
                                </tr>
                            </table>
                        </td>
                    </tr> 
                </table> 
            </ContentTemplate>
        </cc1:TabPanel>
        <cc1:TabPanel ID="tabFeedUnit" runat="server" HeaderText="˹�������">
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
                        <td><asp:TextBox ID="txtCode_FeedUnit" runat="server" Width="123px" CssClass="zTextbox-View" ReadOnly="True" ></asp:TextBox>&nbsp;&nbsp;&nbsp;
                        </td>
                    </tr>
                    <tr>
                        <td style="width: 100px">������ʴ��ػ�ó�
                        </td>
                        <td><asp:TextBox ID="txtName_FeedUnit" runat="server" Width="296px" CssClass="zTextbox-View" ReadOnly="True" ></asp:TextBox>
                    </tr>
                    <tr>
                        <td style="width: 100px">��������ʴ�
                        </td>
                        <td><asp:TextBox ID="txtMaterialGroup_FeedUnit" runat="server" Width="260px" CssClass="zTextbox-View" ReadOnly="True" ></asp:TextBox>
                    </tr>
                    <tr>
                        <td style="width: 100px">˹�����ѡ
                        </td>
                        <td><asp:TextBox ID="txtUnit_FeedUnit" runat="server" Width="260px" CssClass="zTextbox-View" ReadOnly="True" ></asp:TextBox>
                    </tr>
                </table><br />
                <table cellspacing="0" cellpadding="0" border="0" width="100%">
                    <tr>
                        <td class="t_headtext">
                            ˹�������
                        </td>
                    </tr>
                </table>
          <asp:GridView ID="gvFeedUnit" runat="server" AllowSorting="True" ShowFooter="True" AutoGenerateColumns="False" CssClass="t_tablestyle" OnRowDataBound="gvFeedUnit_RowDataBound" OnRowEditing="gvFeedUnit_RowEditing" OnRowCancelingEdit="gvFeedUnit_RowCancelingEdit" OnRowDeleting="gvFeedUnit_RowDeleting" OnRowUpdating="gvFeedUnit_RowUpdating"   >
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
                            </EditItemTemplate>
                            <FooterTemplate>
                                <asp:TextBox ID="txtWeightAdd" runat="server" CssClass="zTextboxR" Width="70px" />
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
                                <asp:CheckBox ID="chkIsStockInAdd" runat="server"  />
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

    </cc1:TabContainer>
    </asp:Panel>
</asp:Content>

