<%@ Page Language="C#" MasterPageFile="~/Templates/Page1.master" AutoEventWireup="true" CodeFile="OrderWelfare.aspx.cs" Inherits="App_Order_Transaction_OrderWelfare" Title="SHND : Transaction - Food Order for Welfare" %>
<%@ Register Src="../../Templates/CalendarControl.ascx" TagName="CalendarControl" TagPrefix="uc3" %>
<%@ Register Src="../../Templates/PageControl.ascx" TagName="PageControl" TagPrefix="uc2" %>
<%@ Register Src="../../Templates/ToolBarItemCtl.ascx" TagName="ToolBarItemCtl" TagPrefix="uc1" %>
<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="cc1" %>

<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" Runat="Server">
    <table width="100%" border="0" cellpadding="0" cellspacing="0">
        <tr>
            <td class="headtext">
                �����������ʴԡ��</td>
        </tr>
        <tr>
             <td>
                <uc1:ToolBarItemCtl ID="tbAdd" runat="server" ToobarTitle="����������"  ToolbarImage="../../Images/icn_add.png"  OnClick ="tbAddClick" />
                <uc1:ToolBarItemCtl ID="ToolBarItemCtl1" runat="server" ToobarTitle="ź�����ŷ�����͡"  ToolbarImage="../../Images/icn_delete.png" ClientClick="return confirm('��ͧ���ź�����ŷ�����͡ ���������?')" OnClick="tbDeleteClick" />
                <uc1:ToolBarItemCtl ID="tbCommit" runat="server" ToobarTitle="͹��ѵ�"  ToolbarImage="../../Images/icn_approve.png" ClientClick="return confirm('��ͧ���͹��ѵԢ����ŷ�����͡ ���������?')" OnClick="tbCommitClick"   />
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
                    <legend style="font-weight:bold">����</legend>
                        <table cellspacing="0" cellpadding="0" border="0" width="100%">
                            <tr style="height:15px">
                                <td colspan="5"></td>
                            </tr>
                            <tr style="height:24px">
                                <td style="width:130px; text-align: right; padding-right:10px">�Ţ�����ԡ�����</td>
                                <td style="width:200px;"><asp:TextBox ID="txtSearchCodeFrom" runat="server" CssClass="zTextbox" Width="200px" MaxLength="20"></asp:TextBox></td>
                                <td style="width:30px; text-align:center;">�֧</td>
                                <td style="width:200px;"><asp:TextBox ID="txtSearchCodeTo" runat="server" CssClass="zTextbox" Width="200px" MaxLength="20"></asp:TextBox></td>
                                <td></td>
                            </tr>
                            <tr style="height:24px">
                                <td style="width:130px; text-align: right; padding-right:10px">�ѹ�����ԡ</td>
                                <td style="width:200px;">
                                    <uc3:CalendarControl ID="ctlSearchDateFrom" runat="server" /></td>
                                <td style="width:30px; text-align:center;">�֧</td>
                                <td style="width:200px;">
                                    <uc3:CalendarControl ID="ctlSearchDateTo" runat="server" /></td>
                                <td></td>
                            </tr>
                            <tr style="height:24px">
                                <td style="width:130px; text-align: right; padding-right:10px">ʶҹС����������</td>
                                <td style="width:200px;"><asp:DropDownList ID="cmbSearchStatusFrom" runat="server" Width="200px" CssClass="zComboBox"></asp:DropDownList></td>
                                <td style="width:30px; text-align:center;">�֧</td>
                                <td style="width:200px;"><asp:DropDownList ID="cmbSearchStatusTo" runat="server" Width="200px" CssClass="zComboBox"></asp:DropDownList></td>
                                <td>
                                    &nbsp;<asp:ImageButton ID="imbSearch" runat="server" ImageAlign="AbsMiddle" ImageUrl="~/Images/icn_find.png" OnClick="imbSearch_Click"/>
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
            <td  >
                <uc2:PageControl ID="pcTop" runat="server" OnPageChange="PageChange"/>
                <asp:GridView ID="gvMain" runat="server" AllowSorting="True" AutoGenerateColumns="False" CssClass="t_tablestyle" OnRowDataBound="gvMain_RowDataBound" OnSorting="gvMain_Sorting" AllowPaging="True" PageSize="20"  style="width:100%;">
                    <Columns>
                        <asp:BoundField DataField="LOID" HeaderText="LOID">
                            <ControlStyle CssClass="zHidden" />
                            <FooterStyle CssClass="zHidden" />
                            <HeaderStyle CssClass="zHidden" />
                            <ItemStyle CssClass="zHidden" />
                        </asp:BoundField>
                        
                        <asp:TemplateField>
                            <HeaderTemplate>
                                <input type="checkbox" name="chkMain" id="chkMain" onclick="chkAllBox(this, 'ctl00_MainContent_gvMain_ctl', '_chkSelect')"/>
                            </HeaderTemplate>
                            <ItemTemplate>
                                <asp:CheckBox ID="chkSelect" runat="server" Enabled='<%# Eval("STATUS").ToString() == "WA" %>' />
                            </ItemTemplate>
                            <HeaderStyle HorizontalAlign="Center" Width="30px" />
                            <ItemStyle HorizontalAlign="Center" Width="30px" />
                        </asp:TemplateField>
                        
                        <asp:TemplateField HeaderText="�ӴѺ" SortExpression="DEFAULT">
                            <HeaderStyle Width="60px" />
                            <ItemStyle HorizontalAlign="Center" Width="60px" />
                        </asp:TemplateField>
                        
                        <asp:TemplateField SortExpression="ORDERCODE" HeaderText="�Ţ����ԡ�����">
                            <ItemStyle Width="100px" HorizontalAlign="center"></ItemStyle>
                            <HeaderStyle Width="100px" HorizontalAlign="Center"></HeaderStyle>
                            <ItemTemplate>
                            <asp:LinkButton ID="lnkCode" runat="server" Text='<%# Bind("ORDERCODE") %>' CommandArgument='<%# Bind("LOID")  %>'  OnClick="linkCode_Click"></asp:LinkButton>
                            </ItemTemplate>
                        </asp:TemplateField>
        
                        <asp:BoundField HtmlEncode="False" DataFormatString="{0:dd/MM/yyyy}" DataField="ORDERDATE" SortExpression="ORDERDATE" HeaderText="�ѹ�����ԡ">
                            <ItemStyle Width="100px" HorizontalAlign="Center"></ItemStyle>
                            <HeaderStyle Width="100px" HorizontalAlign="Center"></HeaderStyle>
                        </asp:BoundField>
                        
                         <asp:BoundField DataField="NAME" SortExpression="NAME" HeaderText="˹��§ҹ">
                        </asp:BoundField>
                        
                          <asp:BoundField HtmlEncode="False" DataFormatString="{0:#,##0}" DataField="AMOUNT" SortExpression="AMOUNT" HeaderText="�ӹǹ����Ѻ��ԡ��">
                            <ItemStyle Width="100px" HorizontalAlign="Center"></ItemStyle>
                            <HeaderStyle Width="100px" HorizontalAlign="Center"></HeaderStyle>
                        </asp:BoundField>
                        
                        <asp:BoundField DataField="STATUSNAME" SortExpression="STATUSNAME" HeaderText="ʶҹС����������">
                            <ItemStyle Width="150px"></ItemStyle>
                            <HeaderStyle Width="150px" HorizontalAlign="Center"></HeaderStyle>
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
    <asp:Panel ID="Panel1" runat="server" CssClass="modalPopup" ScrollBars="Auto" style="display:none" Width="800px" Height="600">
        <table cellspacing="0" cellpadding="0" border="0" width="100%" >
            <tr>
                <td>
                    <uc1:ToolBarItemCtl ID="tbSave" runat="server" ToobarTitle="�ѹ�֡" ToolbarImage="../../Images/save2.png" OnClick = "tbSave1Click" />
                    <uc1:ToolBarItemCtl ID="tbSave2" runat="server" ToobarTitle="¡��ԡ������" ToolbarImage="../../Images/cancel.png"  OnClick ="tbSave2Click" />
                    <uc1:ToolBarItemCtl ID="tbSave3" runat="server" ToobarTitle="͹��ѵ�" ToolbarImage="../../Images/icn_approve.png" OnClick ="tbSave3Click"  />
                    <uc1:ToolBarItemCtl ID="tbSave4" runat="server" ToobarTitle="¡��ԡ" ToolbarImage="../../Images/icn_cancel.png" OnClick ="tbSave4Click" Visible="false" />
                    <uc1:ToolBarItemCtl ID="tbBack" runat="server" ToobarTitle="��Ѻ˹����¡��" ToolbarImage="../../Images/icn_back.png"  OnClick = "tbBackClick" />
                </td>
            </tr>
            <tr>
                <td>
                    <hr style="size:1px" />
                </td>
            </tr>
            <tr>
                <td style="height:15px">
                    <asp:Label ID="lbStatus" runat="server" EnableViewState="False"></asp:Label>
                    <asp:TextBox ID="txhSortField" runat="server" Visible="False" Width="15px"></asp:TextBox>
                    <asp:TextBox ID="txhSortDir" runat="server" Visible="False" Width="15px"></asp:TextBox>
                    <asp:TextBox ID="txhID" runat="server" Visible="False" Width="15px"></asp:TextBox>
                    <asp:TextBox  ID="txtStatus" runat="server" Visible="False" Width="15px"></asp:TextBox>
                </td> 
            </tr> 
            <tr>
                <td>
                    <table border="0" cellpadding="0" cellspacing="0" width="100%">
                        <tr>
                            <td style="padding:5px; border-right: 1px solid; border-top: 1px solid; border-left: 1px solid; border-bottom: 1px solid; width:400px" valign="top">
                                <table border="0" cellpadding="0" cellspacing="0" width="500">
                                    <tr style="height:24px">
                                        <td style="width:120px; text-align: right; padding-right:10px">�Ţ�����ԡ����� :
                                        </td>
                                        <td style="width:150px;"><asp:TextBox ID="txtIDReq" runat="server" CssClass="zTextbox-View" Width="125px" MaxLength="20" Readonly="True" ></asp:TextBox>
                                        </td>
                                        <td style="width:81px; text-align: right; padding-right:10px">�ѹ�����ԡ :
                                        </td>
                                        <td style="width: 150px; height: 24px"><uc3:CalendarControl ID="ctlRefDate" runat="server" Enabled="false" />
                                        </td> 
                                    </tr>
                                    <tr style="height:24px">
                                        <td style="width:120px; text-align: right; padding-right:10px">�Ţ����͡�����ҧ�ԧ :
                                        </td>
                                        <td style="width:150px;"><asp:TextBox ID="txtRef" runat="server" CssClass="zTextbox" Width="125px" MaxLength="20"></asp:TextBox> <span style="color:red">*</span>
                                        </td>
                                        <td style="width:81px; text-align: right; padding-right:10px">ŧ�ѹ��� :
                                        </td>
                                        <td style="width: 150px; height: 24px"><uc3:CalendarControl ID="CalendarControl3" runat="server" /> <span style="color:red">*</span>
                                        </td> 
                                    </tr>
                                    <tr style="height:24px">
                                        <td style="width:120px; text-align: right; padding-right:10px">
                                        ��ú�ԡ�� : </td>
                                        <td colspan="3">
                                        <asp:RadioButtonList ID="radTiffin" runat="server" RepeatDirection="Horizontal"  AutoPostBack="True" OnSelectedIndexChanged="radTiffin_SelectedIndexChanged">
                                            <asp:ListItem Value="N"  Selected="True">�ٻͧ</asp:ListItem>
                                            <asp:ListItem Value="Y">����</asp:ListItem>
                                        </asp:RadioButtonList>
                                            </td>
                                    </tr>
                                    <tr style="height:24px">
                                        <td style="width:120px; text-align: right; padding-right:10px">
                                            �������� :
                                        </td>
                                        <td colspan="3"><asp:DropDownList ID="cmbMonthFrom" runat="server" Width="70px">
                                        <asp:ListItem Value="0">���͡</asp:ListItem>
<asp:ListItem Value="1">���Ҥ�</asp:ListItem>
     <asp:ListItem Value="2">����Ҿѹ��</asp:ListItem>
     <asp:ListItem Value="3">�չҤ�</asp:ListItem>
     <asp:ListItem Value="4">����¹</asp:ListItem>
     <asp:ListItem Value="5">����Ҥ�</asp:ListItem>
     <asp:ListItem Value="6">�Զع�¹</asp:ListItem>
     <asp:ListItem Value="7">�á�Ҥ�</asp:ListItem>
     <asp:ListItem Value="8">�ԧ�Ҥ�</asp:ListItem>
     <asp:ListItem Value="9">�ѹ��¹</asp:ListItem>
     <asp:ListItem Value="10">���Ҥ�</asp:ListItem>
     <asp:ListItem Value="11">��Ȩԡ�¹</asp:ListItem>
     <asp:ListItem Value="12">�ѹ�Ҥ�</asp:ListItem>
                                        </asp:DropDownList>  �� �.�. :
                                        <asp:TextBox ID="txtYearFrom" runat="server" CssClass="zTextbox" MaxLength="4" Width="30px"></asp:TextBox> <span style="color:red">*</span>    
                                        �֧ :               
                                        <asp:DropDownList ID="cmbMonthTo" runat="server" Width="70px">
                                        <asp:ListItem Value="0">���͡</asp:ListItem>
<asp:ListItem Value="1">���Ҥ�</asp:ListItem>
     <asp:ListItem Value="2">����Ҿѹ��</asp:ListItem>
     <asp:ListItem Value="3">�չҤ�</asp:ListItem>
     <asp:ListItem Value="4">����¹</asp:ListItem>
     <asp:ListItem Value="5">����Ҥ�</asp:ListItem>
     <asp:ListItem Value="6">�Զع�¹</asp:ListItem>
     <asp:ListItem Value="7">�á�Ҥ�</asp:ListItem>
     <asp:ListItem Value="8">�ԧ�Ҥ�</asp:ListItem>
     <asp:ListItem Value="9">�ѹ��¹</asp:ListItem>
     <asp:ListItem Value="10">���Ҥ�</asp:ListItem>
     <asp:ListItem Value="11">��Ȩԡ�¹</asp:ListItem>
     <asp:ListItem Value="12">�ѹ�Ҥ�</asp:ListItem>
                                        </asp:DropDownList>  �� �.�. :
                                        <asp:TextBox ID="txtYearTo" runat="server" CssClass="zTextbox" MaxLength="4" Width="30px" ></asp:TextBox> <span style="color:red">*</span>
                                        </td> 
                                    </tr>
                                    <tr style="height:24px">
                                        <td style="width:120px; text-align: right; padding-right:10px">˹��§ҹ :
                                        </td>
                                        <td colspan="3">
                                            <asp:DropDownList ID="cmbDiv" runat="server" CssClass="zComboBox" Width="369px" AutoPostBack="True" OnSelectedIndexChanged="cmbDiv_SelectedIndexChanged"></asp:DropDownList>
                                            <span style="color: #ff0000">*</span></td>
                                    </tr>

                                </table> 
                            </td>
                            <td style="width:4px">
                                &nbsp;</td>
                            <td style="border-right: 1px solid; border-top: 1px solid; border-left: 1px solid; border-bottom: 1px solid; padding:5px" valign="top">
                                <table border="0" cellpadding="0" cellspacing="0" style="width: 265px">
                                    <tr style="height:24px;">
                                        <td style="width:110px; text-align:right; padding-right:10px;">
                                            ʶҹС���������� :</td> 
                                        <td>
                                            <asp:TextBox ID="txtStatusRef" runat="server"  Width="130px" MaxLength="20" Readonly="True" CssClass="zTextbox-View" >���ѧ���Թ���</asp:TextBox></td> 
                                    </tr>
                                    <tr>
                                        <td colspan="2"><hr style="size:1px" /></td> 
                                    </tr> 
                                    <tr style="height: 24px">
                                        <td style="padding-right: 10px; width: 110px; text-align: right">
                                            �ӹǹ�� :</td>
                                        <td>
                                            <asp:TextBox ID="txtSumOrder" runat="server"  Width="50px" Readonly="True" CssClass="zTextboxR-View" ></asp:TextBox></td>
                                    </tr>
                                    <tr style="height: 24px">
                                        <td style="padding-right: 10px; width: 110px; text-align: right">
                                            �ӹǹ�ٻͧ/���� :</td>
                                        <td>
                                            <asp:TextBox ID="txtSumOrderCu" runat="server"  Width="50px"  Readonly="True"  CssClass="zTextboxR-View" Text=""></asp:TextBox></td>
                                    </tr>
                                    <tr style="height: 24px">
                                        <td style="padding-right: 10px; width: 110px; text-align: right">
                                            <asp:Label ID="lblTiffin" runat="server" Text="�ӹǹ�Է��� : "></asp:Label></td>
                                        <td>
                                            <asp:TextBox ID="txtTiffin" runat="server"  Width="50px"  Readonly="True"  CssClass="zTextboxR-View" Text=""></asp:TextBox></td>
                                    </tr>
                                </table>
                            </td>
                        </tr>
                    </table>
                </td>
            </tr>
            <tr>
                <td style="height:15px"></td>
            </tr>
            <tr>
                <td style="font-weight:bold; font-size:9pt">˹��§ҹ����
                </td>
            </tr>
            <tr>
                <td style="height:5px"></td>
            </tr>
            <tr>
                <td style="padding-left:50px">
                    <asp:GridView ID="gvMain1" runat="server" AutoGenerateColumns="False" CssClass="t_tablestyle"  Width="400px" OnRowDataBound="gvMain1_RowDataBound">
                        <Columns>
                            <asp:BoundField DataField="LOID" HeaderText="LOID">
                                <ControlStyle CssClass="zHidden" />
                                <FooterStyle CssClass="zHidden" />
                                <HeaderStyle CssClass="zHidden" />
                                <ItemStyle CssClass="zHidden" />
                            </asp:BoundField>
                             
                            <asp:TemplateField HeaderText="�ӴѺ" >
                                <ItemTemplate>
                                    <%# Container.DataItemIndex +1 %>
                                </ItemTemplate>
                                <HeaderStyle Width="60px" />
                                <ItemStyle HorizontalAlign="Center" Width="60px" />
                            </asp:TemplateField>
                            
                            <asp:BoundField  DataField="NAME" HeaderText="˹��§ҹ����"  >
                            </asp:BoundField>
                            <asp:TemplateField HeaderText="�ӹǹ��">
                                <ItemTemplate>
                                    <asp:TextBox ID="txtOrder" runat="server" value = "0" CssClass="zTextboxR" Width="50px" MaxLength="6" Text='<%# (Convert.IsDBNull(Eval("QTY")) ? "" : Convert.ToDouble(Eval("QTY")).ToString("#,##0")) %>' onkeypress=ChkInt(this) onblur="valInt(this)" onfocus="prepareNum(this)"></asp:TextBox>
                                </ItemTemplate>
                                <ItemStyle Width="100px" HorizontalAlign="Center"/> 
                                <HeaderStyle Width="100px" HorizontalAlign="Center" /> 
                            </asp:TemplateField>
                            <asp:BoundField DataField="SUBDIVISION" HeaderText="SUBDIVISION">
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
                </td>
            </tr>
            <tr>
                <td style="height:15px"></td>
            </tr>
            <tr>
                <td style="font-weight:bold; font-size:9pt">�ӹǹ����Ѻ��ԡ�õ�����͵���ѹ
                </td>
            </tr>
            <tr>
                <td style="height:5px"></td>
            </tr>
            <tr>
                <td style="padding-left:50px">
                    <table cellpadding="0" class="t_tablestyle" cellspacing="1" border="0" width="400">
                        <tr>
                            <td style="height: 25px;" align="center" class="t_headtext"> �ѹ </td>
                            <td style="width:100px; height: 25px;" align="center" class="t_headtext"> ��� </td>
                            <td style="width:100px; height: 25px;" align="center" class="t_headtext"> ��ҧ�ѹ </td>
                            <td style="width:100px; height: 25px;" align="center" class="t_headtext"> ��� </td>
                        </tr>
                        <tr>
                            <td align="center" style="height: 24px"> �ѹ��� </td>
                            <td align="center" style="height: 24px"> 
                                <asp:TextBox ID ="MonM" runat ="server" width ="90px" value = "0" CssClass="zTextboxR"></asp:TextBox> </td>
                            <td align="center" style="height: 24px"> 
                                <asp:TextBox ID ="MonL" runat ="server" width ="90px" value = "0" CssClass="zTextboxR" ></asp:TextBox> </td>
                            <td align="center" style="height: 24px"> 
                                <asp:TextBox ID ="MonE" runat ="server" width ="90px" value = "0" CssClass="zTextboxR"></asp:TextBox> </td>
                        </tr>
                        <tr>
                            <td align="center" class="t_alt_bg" style="height: 24px"> �ѧ��� </td>
                            <td align="center" class="t_alt_bg" style="height: 24px"> 
                                <asp:TextBox ID ="TueM" runat ="server" width ="90px" value = "0" CssClass="zTextboxR" ></asp:TextBox> </td>
                            <td align="center" class="t_alt_bg" style="height: 24px"> 
                                <asp:TextBox ID ="TueL" runat ="server" width ="90px" value = "0" CssClass="zTextboxR" ></asp:TextBox> </td>
                            <td align="center" class="t_alt_bg" style="height: 24px"> 
                                <asp:TextBox ID ="TueE" runat ="server" width ="90px" value = "0" CssClass="zTextboxR"></asp:TextBox> </td>
                        </tr> 
                        <tr>
                            <td align="center" style="height: 24px"> �ظ </td>
                            <td align="center" style="height: 24px"> 
                                <asp:TextBox ID ="WenM" runat ="server" width ="90px" value = "0" CssClass="zTextboxR"></asp:TextBox> </td>
                            <td align="center" style="height: 24px"> 
                                <asp:TextBox ID ="WenL" runat ="server" width ="90px" value = "0" CssClass="zTextboxR"></asp:TextBox> </td>
                            <td align="center" style="height: 24px"> 
                                <asp:TextBox ID ="WenE" runat ="server" width ="90px" value = "0" CssClass="zTextboxR"></asp:TextBox> </td>
                        </tr> 
                        <tr>
                            <td align="center" class="t_alt_bg" style="height: 24px"> ����� </td>
                            <td align="center" class="t_alt_bg" style="height: 24px"> 
                                <asp:TextBox ID ="ThM" runat ="server" width ="90px" value = "0" CssClass="zTextboxR"></asp:TextBox> </td>
                            <td align="center" class="t_alt_bg" style="height: 24px"> 
                                <asp:TextBox ID ="ThL" runat ="server" width ="90px" value = "0" CssClass="zTextboxR" ></asp:TextBox> </td>
                            <td align="center" class="t_alt_bg" style="height: 24px"> 
                                <asp:TextBox ID ="ThE" runat ="server" width ="90px" value = "0" CssClass="zTextboxR" ></asp:TextBox> </td>
                        </tr> 
                        <tr>
                            <td align="center" style="height: 24px"> �ء��</td >
                            <td align="center" style="height: 24px"> 
                                <asp:TextBox ID ="FriM" runat ="server" width ="90px" value = "0" CssClass="zTextboxR" ></asp:TextBox> </td>
                            <td align="center" style="height: 24px"> 
                                <asp:TextBox ID ="FriL" runat ="server" width ="90px" value = "0" CssClass="zTextboxR" ></asp:TextBox> </td>
                            <td align="center" style="height: 24px"> 
                                <asp:TextBox ID ="FriE" runat ="server" width ="90px" value = "0" CssClass="zTextboxR" ></asp:TextBox> </td>
                        </tr> 
                        <tr>
                            <td style="background-color: #f5f5f5; height: 24px;" align="center"> �����</td >
                            <td style="background-color: #f5f5f5; height: 24px;" align="center"> 
                                <asp:TextBox ID ="SatM" runat ="server" width ="90px" value = "0" CssClass="zTextboxR" ></asp:TextBox> </td>
                            <td style="background-color: #f5f5f5; height: 24px;" align="center"> 
                                <asp:TextBox ID ="SatL" runat ="server" width ="90px" value = "0" CssClass="zTextboxR" ></asp:TextBox> </td>
                            <td style="background-color: #f5f5f5; height: 24px;" align="center"> 
                                <asp:TextBox ID ="SatE" runat ="server" width ="90px" value = "0" CssClass="zTextboxR" ></asp:TextBox> </td>
                        </tr> 
                        <tr>
                            <td style="background-color: #f5f5f5; height: 24px;" align="center"> �ҷԵ��</td >
                            <td style="background-color: #f5f5f5; height: 24px;" align="center"> 
                                <asp:TextBox ID ="SunM" runat ="server" width ="90px" value = "0" CssClass="zTextboxR" ></asp:TextBox> </td>
                            <td style="background-color: #f5f5f5; height: 24px;" align="center"> 
                                <asp:TextBox ID ="SunL" runat ="server" width ="90px" value = "0" CssClass="zTextboxR"></asp:TextBox> </td>
                            <td style="background-color: #f5f5f5; height: 24px;" align="center"> 
                                <asp:TextBox ID ="SunE" runat ="server" width ="90px" value = "0" CssClass="zTextboxR"></asp:TextBox> </td>
                        </tr>
                    </table>
                </td>
            </tr>
        </table>
    </asp:Panel> 
</asp:Content>


