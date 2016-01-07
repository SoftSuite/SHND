<%@ Page Language="C#" MasterPageFile="~/Templates/Page1.master" AutoEventWireup="true" CodeFile="RepairRequest.aspx.cs" Inherits="App_Inventory_Transaction_RepairRequest" Title="SHND : Transaction - Repair Requisition" %>

<%@ Register Src="../../Search/RepairrequestPopup.ascx" TagName="RepairrequestPopup"
    TagPrefix="uc5" %>

<%@ Register Src="../../Search/MaterialMasterPopup.ascx" TagName="MaterialMasterPopup"
    TagPrefix="uc4" %>
<%@ Register Src="../../Templates/CalendarControl.ascx" TagName="CalendarControl" TagPrefix="uc2" %>
<%@ Register Src="../../Search/DiseaseCategoryPopup.ascx" TagName="DiseaseCategoryPopup" TagPrefix="uc3" %>
<%@ Register Src="../../Templates/PageControl.ascx" TagName="PageControl" TagPrefix="uc2" %>
<%@ Register Src="../../Templates/ToolBarItemCtl.ascx" TagName="ToolBarItemCtl" TagPrefix="uc1" %>
<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="cc1" %>
<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" Runat="Server">
   
    <table width="100%" border="0" cellpadding="0" cellspacing="0">
        <tr>
            <td class="headtext">
                �����š���駫���</td>
        </tr>
        <tr>
            <td>
                <uc1:ToolBarItemCtl ID="tbSave" runat="server" ToobarTitle="�ѹ�֡" ToolbarImage="../../Images/save2.png" OnClick="tbSaveClick" />
                <uc1:ToolBarItemCtl ID="tbCancel" runat="server" ToobarTitle="¡��ԡ������" ToolbarImage="../../Images/cancel.png" OnClick="tbCancelClick" />
                <uc1:ToolBarItemCtl ID="tbSend" runat="server" OnClick="tbSendClick" ToobarTitle="�觢�����" ToolbarImage="../../Images/icn_add.png" />
                <uc1:ToolBarItemCtl ID="tbBack" runat="server" ToobarTitle="��Ѻ˹����¡��" ToolbarImage="../../Images/icn_back.png" OnClick="tbBackClick"/>
                <uc1:ToolBarItemCtl ID="tbPrint" runat="server" ToobarTitle="�����" ToolbarImage="../../Images/icn_print.png" OnClick="tbPrintClick"/>
            </td>
        </tr>
        <tr>
            <td style="height:30px" valign="top">
                <hr style="size:1px" />
                <asp:Label ID="lbStatus" runat="server" EnableViewState="False"></asp:Label>
                <asp:TextBox ID="txtLOID" runat="server" CssClass="zHidden" Width="50px"></asp:TextBox>
                <asp:TextBox ID="txtStatus" runat="server" CssClass="zHidden" Width="50px"></asp:TextBox>
                &nbsp;
                <asp:TextBox ID="txtMaterialMaster" runat="server" CssClass="zHidden" Width="50px"></asp:TextBox></td>
        </tr>
        <tr>
            <td>
                <table border="0" cellpadding="0" cellspacing="0" width="100%">
                    <tr>
                        <td style="padding:5px; border-right: 1px solid; border-top: 1px solid; border-left: 1px solid; border-bottom: 1px solid; width:670px" valign="top">
                            <table border="0" cellpadding="0" cellspacing="0" width="650">
                                <tr style="height:24px">
                                    <td style="width:120px; padding-right:10px; height: 24px;" align="right">
                                        �Ţ����觫��� :</td> 
                                    <td style="width:200px; height: 24px;">
                                        <asp:TextBox ID="txtCode" runat="server" CssClass="zTextbox-View" MaxLength="20"
                                            Width="150px" ReadOnly="True"></asp:TextBox></td>  
                                    <td style="width: 130px; padding-right: 10px; height: 24px;" align="right">
                                        �ѹ����觫��� :</td>
                                    <td style="width: 200px; height: 24px;">
                                        <uc2:CalendarControl id="ctlSentDate" runat="server">
                                        </uc2:CalendarControl></td>
                                </tr>
                                <tr style="height: 24px">
                                    <td style="padding-right: 10px; width: 120px; height: 24px;" align="right">
                                        ��ѧ :</td>
                                    <td style="width: 200px; height: 24px;">
                                        <asp:DropDownList ID="cmbWarehouse" runat="server" CssClass="zComboBox" Width="156px">
                                        </asp:DropDownList></td>
                                    <td style="width: 130px; padding-right: 10px; height: 24px;" align="right">
                                        ˹��·���駫��� :</td>
                                    <td style="width: 200px; height: 24px;">
                                        <asp:DropDownList ID="cmbDev" runat="server" CssClass="zComboBox" Width="156px">
                                        </asp:DropDownList></td>
                                </tr>
                                <tr style="height: 24px">
                                    <td style="padding-right: 10px; width: 120px; height: 24px;" align="right">
                                        ������觴�ǹ :</td>
                                    <td style="width: 200px; height: 24px;">
                                        <asp:RadioButton ID="rdbNormal" runat="server" Checked="True" Text="����" AutoPostBack="True" OnCheckedChanged="rdbNormal_CheckedChanged" />
                                        <asp:RadioButton
                                            ID="rdbSpeed" runat="server" Text="��觴�ǹ" AutoPostBack="True" OnCheckedChanged="rdbSpeed_CheckedChanged" />
                                        <asp:RadioButton ID="rdbEmergency"
                                                runat="server" Text="�ء�Թ" AutoPostBack="True" OnCheckedChanged="rdbEmergency_CheckedChanged" />
                                    </td>
                                    <td style="width: 130px; padding-right: 10px; height: 24px;" align="right">
                                        ���ͼ���駫��� :</td>
                                    <td style="width: 200px; height: 24px;">
                                        <asp:TextBox ID="txtName" runat="server" CssClass="zTextbox-View" MaxLength="20"
                                            Width="150px" ReadOnly="True"></asp:TextBox></td>
                                </tr>
                                <tr>
                                    <td colspan="4" style="height: 10px;" align="right">
                                    </td>
                                </tr>
                                <tr style="height:24px">
                                    <td style="width:120px; padding-right:10px; height: 24px;" align="right">
                                        ���� SAP :</td>
                                    <td style="height: 24px;" colspan="3">
                                        <asp:TextBox ID="txtMCode" runat="server" CssClass="zTextbox-View" MaxLength="20"
                                            Width="150px" ReadOnly="True"></asp:TextBox>
                                        <asp:ImageButton ID="imbSearch" runat="server" ImageAlign="AbsMiddle" ImageUrl="~/Images/icn_find.png"
                                            OnClick="imbSearch_Click" />
                                        <asp:TextBox ID="txtMName" runat="server" CssClass="zTextbox-View" MaxLength="20" Width="293px"></asp:TextBox></td>
                                </tr>
                                <tr style="height: 24px">
                                    <td style="padding-right: 10px; width: 120px; height: 24px;" align="right">
                                        ���ʤ���ѳ�� :</td>
                                    <td style="height: 24px;" colspan="2">
                                        <asp:TextBox ID="txtLotNo" runat="server" CssClass="zTextbox-View" MaxLength="20"
                                            Width="150px" ReadOnly="True"></asp:TextBox>�ӹǹ
                                        <asp:TextBox ID="txtNo" runat="server" CssClass="zTextboxR" MaxLength="20" Width="48px"></asp:TextBox>
                                        <asp:TextBox ID="txtUnit" runat="server" CssClass="zTextbox" MaxLength="20" Width="13px" Visible="False"></asp:TextBox>
                                        <asp:Label id="lblUnitName" runat="server" Width="50px"></asp:Label></td>
                                    <td style="width: 200px; height: 24px;">
                                        ��鹷�� &nbsp;&nbsp;
                                        <asp:TextBox id="txtFloor" runat="server" Width="35px">
                                        </asp:TextBox></td>
                                </tr>
                                <tr style="height: 24px">
                                    <td style="padding-right: 10px; width: 120px; height: 24px;" align="right">
                                        ���/������ :</td>
                                    <td style="width: 200px; height: 24px;">
                                        <asp:TextBox ID="txtBrand" runat="server" CssClass="zTextbox-View" MaxLength="200"
                                            Width="150px" ReadOnly="True"></asp:TextBox></td>
                                    <td style="width: 130px; height: 24px;">
                                    </td>
                                    <td style="width: 200px; height: 24px;">
                                    </td>
                                </tr>
                                <tr style="height: 24px">
                                    <td style="padding-right: 10px; width: 120px; height: 24px;" align="right">
                                        ��������´ :</td>
                                    <td colspan="3" style="height: 24px">
                                        <asp:TextBox ID="txtDetail" runat="server" CssClass="zTextbox" Height="59px"
                                            MaxLength="200" TextMode="MultiLine" Width="481px"></asp:TextBox></td>
                                </tr>
                                <tr style="height: 24px">
                                    <td style="padding-right: 10px; width: 120px; height: 24px;" align="right">
                                        ��ҧ����Ѻ�Դ�ͺ :</td>
                                    <td style="height: 24px;" colspan="3">
                                        <asp:TextBox ID="txtRepairBy" runat="server" CssClass="zTextbox" MaxLength="20"
                                            Width="481px"></asp:TextBox></td>
                                </tr>
                                <tr>
                                    <td style="padding-right: 10px; width: 120px;" align="right">
                                    </td>
                                    <td style="width: 200px">
                                        <asp:TextBox id="txhSortField" runat="server" Visible="False" Width="15px">
                </asp:TextBox><asp:TextBox id="txhSortDir" runat="server" Visible="False" Width="15px">
                </asp:TextBox>
                                        <asp:TextBox ID="txtMaterialLoid" runat="server" CssClass="zTextbox" MaxLength="20" Width="48px" Visible="False"></asp:TextBox></td>
                                    <td style="width: 130px">
                                    </td>
                                    <td style="width: 200px">
                                    </td>
                                </tr>
                            </table>
                        </td>
                        <td style="width:4px">
                            &nbsp;</td>
                        <td style="border-right: 1px solid; border-top: 1px solid; border-left: 1px solid; border-bottom: 1px solid; padding:5px" valign="top">
                            <table border="0" cellpadding="0" cellspacing="0" width="200">
                                <tr style="height: 24px">
                                    <td style="padding-right: 10px; width: 70px; text-align: right; height: 24px;">
                                        ʶҹ� :</td>
                                    <td style="height: 24px;">
                                        &nbsp;<asp:TextBox ID="txtStatusName" runat="server" CssClass="zTextbox-View" MaxLength="20"
                                            Width="109px" ReadOnly="True"></asp:TextBox></td>
                                </tr>
                            </table>
                        </td>
                    </tr> 
                </table> 
                <asp:GridView ID="gvMain" runat="server" AutoGenerateColumns="False" CssClass="t_tablestyle" OnRowDataBound="gvMain_RowDataBound" AllowPaging="True" 
                    PageSize="20" Width="100%">
                    <Columns>
                        <asp:BoundField DataField="LOID" HeaderText="LOID">
                            <ControlStyle CssClass="zHidden" />
                            <FooterStyle CssClass="zHidden" />
                            <HeaderStyle CssClass="zHidden" />
                            <ItemStyle CssClass="zHidden" />
                        </asp:BoundField>
                        <asp:TemplateField HeaderText="�ӴѺ" SortExpression="DEFAULT">
                            <HeaderStyle Width="60px" />
                            <ItemStyle HorizontalAlign="Center" Width="60px" Height="24px" />
                        </asp:TemplateField>
                        <asp:BoundField DataField="REPAIRDATE" HeaderText="�ѹ���" DataFormatString="{0:dd/MM/yyyy}" HtmlEncode="False" SortExpression="REPAIRDATE">
                            <HeaderStyle Width="100px" HorizontalAlign="Center"/>
                            <ItemStyle Width="100px" HorizontalAlign="Center"/>
                        </asp:BoundField>
                        <asp:BoundField DataField="DESCRIPTION" HeaderText="��������´" SortExpression="DESCRIPTION">
                        </asp:BoundField>

                    </Columns>
                    <HeaderStyle CssClass="t_headtext" />
                    <AlternatingRowStyle CssClass="t_alt_bg" />
                    <PagerSettings Visible="False" />
                </asp:GridView>
            </td>
        </tr>
        <tr>
            <td style="height:5px">
            </td>
        </tr>
        <tr>
            <td style="height:15px">
                &nbsp;<uc5:RepairrequestPopup ID="RepairrequestPopup1"  OnSelectedIndexChanged="ctlRepairrequestPopup_SelectedIndexChanged" runat="server" />
            </td>
        </tr>
    </table>
</asp:Content>
