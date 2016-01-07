<%@ Page Language="C#" MasterPageFile="~/Templates/Page1.master" AutoEventWireup="true" CodeFile="CutOrder.aspx.cs" Inherits="App_Prepare_Transaction_CutOrder" Title="SHND : Transaction - Cut Order" %>

<%@ Register Src="../../Templates/CalendarControl.ascx" TagName="CalendarControl"
    TagPrefix="uc3" %>

<%@ Register Src="../../Templates/PageControl.ascx" TagName="PageControl" TagPrefix="uc2" %>
<%@ Register Src="../../Templates/ToolBarItemCtl.ascx" TagName="ToolBarItemCtl" TagPrefix="uc1" %>
<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="cc1" %>

<asp:Content ID="Content3" ContentPlaceHolderID="MainContent" Runat="Server">
 <table width="100%" border="0" cellpadding="0" cellspacing="0">
        <tr>
            <td class="headtext">
                �Ѵ�ʹ��͹�����</td>
        </tr>
        <tr class ="zHidden">
            <td>
                <uc1:ToolBarItemCtl ID="tbAdd" runat="server"  ToobarTitle ="����������" ToolbarImage="../../Images/icn_add.png" />

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

                    <table cellspacing="0" cellpadding="0" border="0" width="600px">
                        <tr style="height:15px">
                            <td colspan="4">&nbsp;</td>
                        </tr>
                        <tr style="height:24px">
                            <td style="width:120px; text-align: right; padding-right:10px">�Ţ����ԡ :</td>
                            <td style="width: 150px"><asp:TextBox ID="txtSearchCodeFrom" runat="server" CssClass="zTextbox" MaxLength="50" Width="100px"></asp:TextBox>
                            </td>   
                            <td style="width:50px;" align="center">�֧</td>
                            <td style="width: 451px"><asp:TextBox ID="txtSearchCodeTo" runat="server" CssClass="zTextbox" MaxLength="50" Width="100px"></asp:TextBox>
                            </td>                 
                        </tr>
                         <tr style="height:24px">
                            <td style="width:120px; text-align: right; padding-right:10px">�ѹ����� :</td>
                            <td style="width: 150px">
                                <uc3:CalendarControl ID="ctlUseDateFrom" runat="server" />
                            </td>   
                            <td style="width:50px;" align="center">�֧</td>
                            <td style="width: 451px">
                                <uc3:CalendarControl ID="ctlUseDateTo" runat="server" />
                            </td>                 
                        </tr>
                        <tr>
                            <td style="width:110px; text-align: right; padding-right:10px; height: 24px;">˹��·���ԡ :</td>
                            <td colspan="3" style="height: 24px"><asp:DropDownList runat ="server" ID="cmbSearchDivision" CssClass="zCombo" Width ="280px" ></asp:DropDownList> </td>
                            
                        </tr>
                        <tr style="height:24px">
                            <td style="width:120px; text-align: right; padding-right:10px">ʶҹ� :</td>
                            <td style="width: 150px">
                                <asp:DropDownList ID="cmbSearchStatusFrom" runat="server" CssClass ="zComboBox" Width="107px">
                                    <asp:ListItem Value="AP">͹��ѵ�</asp:ListItem>
                                    <asp:ListItem Value="FN">�������</asp:ListItem>
                                </asp:DropDownList>
                               
                            </td>   
                            <td style="width:50px;" align="center">�֧</td>
                            <td style="width: 451px">
                                  <asp:DropDownList ID="cmbSearchStatusTo" runat="server" CssClass ="zComboBox" Width="108px">
                                    <asp:ListItem Value="AP">͹��ѵ�</asp:ListItem>
                                    <asp:ListItem Value="FN">�������</asp:ListItem>
                                </asp:DropDownList>
                                &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
                                <asp:ImageButton ID="imbSearch" runat="server" ImageAlign="AbsMiddle" ImageUrl="~/Images/icn_find.png" OnClick="imbSearch_Click"
                                 />
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
                <uc2:PageControl ID="pcTop" runat="server"  OnPageChange="PageChange"  />
                <asp:GridView ID="gvMain" runat="server" AllowSorting="True" AutoGenerateColumns="False" CssClass="t_tablestyle" PageSize="20" AllowPaging="True" OnSorting="gvMain_Sorting" >
                    <Columns>
                        <asp:BoundField DataField="LOID" HeaderText="LOID">
                            <ControlStyle CssClass="zHidden" />
                            <FooterStyle CssClass="zHidden" />
                            <HeaderStyle CssClass="zHidden" />
                            <ItemStyle CssClass="zHidden" />
                        </asp:BoundField>

                          <asp:TemplateField HeaderText="�Ţ����ԡ" SortExpression="CODE">
                            <ItemTemplate>
                                <asp:LinkButton ID="lnkType" runat="server"   OnClick="lnkType_Click"  Text='<%# Bind("CODE") %>' CommandArgument='<%# Bind("LOID")  %>'></asp:LinkButton>
                            </ItemTemplate>
                            <HeaderStyle HorizontalAlign="Center" Width="120px" />
                            <ItemStyle HorizontalAlign="Left" Width="120px" />
                        </asp:TemplateField>
                        <asp:BoundField DataField="DIVISIONNAME" HeaderText="����������ԡ" SortExpression="DIVISIONNAME" HtmlEncode="False" >
                            <HeaderStyle HorizontalAlign="Center" Width="120px" />
                            <ItemStyle HorizontalAlign="Left" Width="120px" />
                        </asp:BoundField>
                        <asp:BoundField DataField="STOCKOUTDATE" HeaderText="�ѹ����ԡ" SortExpression="STOCKOUTDATE" HtmlEncode="False"   DataFormatString="{0:dd/MM/yyyy}"  >
                            <HeaderStyle HorizontalAlign="Center" Width="80px" />
                            <ItemStyle HorizontalAlign="Center" Width="80px" />
                        </asp:BoundField>
                        <asp:BoundField DataField="USEDATE" HeaderText="�ѹ�����" SortExpression="USEDATE" HtmlEncode="False"   DataFormatString="{0:dd/MM/yyyy}"  >
                            <HeaderStyle HorizontalAlign="Center" Width="80px" />
                            <ItemStyle HorizontalAlign="Center" Width="80px" />
                        </asp:BoundField>
                        <asp:BoundField DataField="DOCNAME" HeaderText="����������ԡ" SortExpression="DOCNAME" HtmlEncode="False" >
                            <HeaderStyle HorizontalAlign="Center" Width="120px" />
                            <ItemStyle HorizontalAlign="Left" Width="120px" />
                        </asp:BoundField>
                        
                        <asp:BoundField DataField="STATUSNAME" HeaderText="ʶҹ�" SortExpression="STATUSNAME">
                            <HeaderStyle HorizontalAlign="Center" Width="100px" />
                            <ItemStyle HorizontalAlign="Center" Width="100px" />
                        </asp:BoundField>
                    </Columns>
                    <HeaderStyle CssClass="t_headtext" />
                    <AlternatingRowStyle CssClass="t_alt_bg" />
                    <PagerSettings Visible="False" />
                </asp:GridView><uc2:PageControl ID="pcBot" runat="server" OnPageChange="PageChange"   />
                </td>
        </tr>
    </table>
    <cc1:ModalPopupExtender ID="zPop" runat="server" TargetControlID="tbAdd$lb" PopupControlID="pnlCharge" BackgroundCssClass="modalBackground" DropShadow="true"></cc1:ModalPopupExtender>
    <asp:Panel ID="pnlCharge" runat="server" CssClass="modalPopup" style="display:none" Width="900px">
    <table cellspacing="0" cellpadding="0" border="0" width="100%">
        <tr>
            <td class="subheadertext">
                �Ѵ�ʹ��͹�����</td> 
        </tr>
         <tr>
            <td>
                <hr style="size:1px" />
            </td>
       </tr>
        <tr>
            <td style="height: 20px">
                <uc1:ToolBarItemCtl ID="tbSave" runat="server" ToobarTitle="�ѹ�֡" ToolbarImage="../../Images/save2.png" OnClick="tbSaveClick" />
                <uc1:ToolBarItemCtl ID="tbReturn" runat="server" ToobarTitle="¡��ԡ������" ToolbarImage="../../Images/cancel.png" OnClick="tbReturnClick"  />
                <uc1:ToolBarItemCtl ID="tbApprove" runat="server" ToobarTitle="�������" ToolbarImage="../../Images/icn_approve.png" OnClick ="tbApproveClick"  />
                <uc1:ToolBarItemCtl ID="tbPrint" runat ="server" ToolbarImage="../../Images/icn_print.png" ToobarTitle ="�����" />
                <uc1:ToolBarItemCtl ID="tbBack" runat="server" ToobarTitle="��Ѻ˹����¡��" ToolbarImage="../../Images/icn_back.png"  />
            </td>
        </tr>
        <tr>
            <td>
            </td>
        </tr>
        <tr>
            <td>
                <table cellpadding="5">
                    <tr>
                        <td align="right" style="width: 107px; height: 3px;" colspan="2"> 
                            <asp:TextBox ID="txhID" runat="server" Width="1px" Height="9px" Visible="False"></asp:TextBox>
                            <asp:TextBox ID="txhSortField" runat="server" Visible="False" Width="15px"></asp:TextBox>
                            <asp:TextBox ID="txtStatusFlag" runat="server" Visible="False" Width="15px"></asp:TextBox>
                            <asp:TextBox ID="txhSortDir" runat="server" Visible="False" Width="1px" Height="2px"></asp:TextBox></td>
                        <td style="height:3px; width: 712px;">
                            <asp:Label ID="lbStatus" runat="server" EnableViewState="False"></asp:Label></td>
                    </tr>
                 </table>
            </td>
         </tr>
         <tr>
            <td>
                 <table>
                    <tr>
                        <td style="width: 637px">
                       <fieldset style="padding:15px; ">
                            <table border="0" cellpadding="0" cellspacing="0" style="height :65px; width: 609px;">
                                <tr>
                                    <td align="right" style="width: 108px; height:23px">�Ţ����ԡ :&nbsp;</td>
                                    <td  style="width: 195px">
                                        <asp:TextBox id="txtCode" runat="server" CssClass ="zTextbox-View" ReadOnly="true"></asp:TextBox>
                                    </td>
                                    <td align="right" style="width: 81px; height: 23px">�ѹ����ԡ :&nbsp;</td>
                                    <td style="width: 244px; height: 23px">
                                        <uc3:CalendarControl ID="ctlStockoutDate" runat="server" Enabled ="false" />
                                    </td>
                                </tr>
                                <tr>
                                    <td  align="right" style="width: 108px; height: 23px">˹��·���ԡ :&nbsp;</td>
                                    <td  style="width: 195px; height: 23px">
                                        <asp:DropDownList ID="cmbDivision" runat="server" Enabled="false" CssClass="zComboBox" Width="188px"></asp:DropDownList>
                                    </td>
                                    <td  align="right" style="width: 81px; height: 23px">��ѧ :&nbsp;</td>
                                    <td  style="width: 244px; height: 23px">
                                        <asp:DropDownList ID="cmbWareHouse" runat="server" Enabled="false" CssClass="zComboBox" Width="230px"></asp:DropDownList>
                                    </td>
                                </tr>
                                <tr>
                                    <td align="right" style="width: 108px; height: 23px">����������ԡ :&nbsp;</td>
                                    <td  style="width: 195px; height: 23px">
                                       <asp:DropDownList ID="cmbDoctype" runat="server" Enabled ="false" CssClass="zComboBox" Width="188px"></asp:DropDownList>
                                    </td>
                                    <td align="right" style="width: 81px; height: 23px">�ӹǹ������ :&nbsp;</td>
                                    <td  style="width: 150px; height: 23px">
                                        <asp:TextBox ID="txtOrderQty" runat="server" CssClass="zTextboxR-View" ReadOnly="true" Width="100px" ></asp:TextBox>
                                    </td>
                                </tr>
                                <tr>
                                    <td align="right" style="width: 108px; height: 23px">�ѹ����� :&nbsp;</td>
                                    <td  style="width: 195px; height: 23px">
                                        <uc3:CalendarControl ID="ctlUseDate" runat="server" Enabled="false" />
                                    </td>
                                    <td align="right" style="width: 81px; height: 23px">���ͷ���� :&nbsp;</td>
                                    <td  style="width: 244px; height: 23px">
                                        <asp:CheckBox ID="chkBP" runat="server" Enabled="false" Width="70px" Text="���" />
                                        <asp:CheckBox ID="chkLunch" runat="server" Enabled="false" Width="70px" Text="��ҧ�ѹ" />
                                        <asp:CheckBox ID="chkDinner" runat="server" Enabled="false" Width="70px" Text="���" />
                                    </td>
                                </tr>
                            </table>
                       </fieldset>
                       </td>
                        <td>
                            <fieldset style="padding:15px; width:160px; height:90px ">
                            <table  border="0" cellpadding="0" cellspacing="0">
                                <tr>
                                    <td  style="width:96px; height: 23px" align="right"> ʶҹ� : &nbsp;</td>
                                    <td >
                                        <asp:TextBox ID="txtStatusName" runat="server" CssClass="zTextbox-View" ReadOnly ="true" Width="100px"></asp:TextBox>
                                    </td>
                                </tr> 
                                                        
                            </table>
                            </fieldset> 
                        </td>
                    </tr>
                 </table>
         </td>
    </tr>
    </table>
    <br />
    <table>
        <tr>
            <td align ="right" style="width:800px">
                <asp:ImageButton ID="imgCalculate" runat="server"  ImageAlign="AbsMiddle" ImageUrl="~/Images/icn_calculate.png"  OnClick ="imgCalculateClick"  />
                <asp:Label ID="label10" runat="server" Text="�ӹǳ�ҡ�ӹǹ������ � �Ѩ�غѹ"></asp:Label>
            </td>
        </tr>
    </table>
     <uc2:PageControl ID="pcTop2" runat="server"  OnPageChange="PageChange2"  />
    <asp:GridView ID="grvItem" runat="server" AllowSorting="True" AutoGenerateColumns="False" CssClass="t_tablestyle"  AllowPaging="True" OnRowDataBound="grvItem_RowDataBound">
        <Columns>
            <asp:BoundField DataField="LOID" HeaderText="LOID" ReadOnly ="True" >
                <ControlStyle CssClass="zHidden" />
                <FooterStyle CssClass="zHidden" />
                <HeaderStyle CssClass="zHidden" />
                <ItemStyle CssClass="zHidden" />
            </asp:BoundField> 
            
            <asp:TemplateField HeaderText="�ӴѺ" >
                <HeaderStyle HorizontalAlign="Center" Width="60px" />
                <ItemStyle HorizontalAlign="Center" Width="60px" />
            </asp:TemplateField>
            <asp:TemplateField HeaderText="����" >
                <ItemTemplate>
                   <asp:Label ID="lblCode"  runat="server" Text='<%# Bind("CODE") %>' Width="90px"></asp:Label>
                </ItemTemplate>
                <HeaderStyle HorizontalAlign="Center" Width="100px" />
                <ItemStyle Width="100px"  />
            </asp:TemplateField>
            
            <asp:TemplateField HeaderText="��¡��" >
                <ItemTemplate>
                   <asp:Label ID="lblMaterialName"  runat="server" Text='<%# Bind("MATERIALNAME") %>' Width="170px"></asp:Label>
                </ItemTemplate>
                <HeaderStyle HorizontalAlign="Center" Width="180px" />
                <ItemStyle HorizontalAlign ="Left" Width="180px"  />
            </asp:TemplateField>
            
            <asp:TemplateField HeaderText="˹��¹Ѻ" >
                <ItemTemplate>
                    <asp:Label ID="lbltUnitName" runat="server" Text='<%# Bind("UNITNAME") %>' Width="90px"></asp:Label>
                </ItemTemplate>
                <HeaderStyle HorizontalAlign="Center" Width="100px" />
                <ItemStyle  HorizontalAlign ="Left" Width="100px"  />

            </asp:TemplateField>
            <asp:TemplateField HeaderText="�ӹǹ�ԡ">
                <ItemTemplate >
                    <asp:Label ID="lblReqQty" runat="server" Text ='<%# Bind("REQQTY")%>'   Width="75px" ></asp:Label>
                </ItemTemplate>
                <HeaderStyle HorizontalAlign="Center" Width="80px" />
                <ItemStyle HorizontalAlign ="Right" Width ="80px" />
            </asp:TemplateField>
            <asp:TemplateField HeaderText="�ӹǹ������" >
                <ItemTemplate >
                    <asp:Label ID="lblQty" runat="server"  Text='<%#Bind("QTY") %>'  Width="75px"  ></asp:Label>
                </ItemTemplate>
                <HeaderStyle HorizontalAlign="Center" Width="100px" />
                <ItemStyle HorizontalAlign="Right" Width="100px" />
            </asp:TemplateField>
            
            <asp:TemplateField HeaderText="�ӹǹ����ͧ��" >
                <ItemTemplate>
                   <asp:TextBox ID="txtUseQty" runat="server" Text='<%#Bind("USEQTY") %>' Width="80px" OnTextChanged="UseQtyCalculate" AutoPostBack="true" ToolTip='<%# Container.DataItemIndex %>'  ></asp:TextBox>
                </ItemTemplate>
                <HeaderStyle HorizontalAlign="Center" Width="90px" />
                <ItemStyle HorizontalAlign="Center" Width="90px" />
            </asp:TemplateField>
            
            <asp:TemplateField HeaderText="�ӹǹ�׹��ѧ" >
                <ItemTemplate >
                    <asp:Label ID="lblReturn" runat="server" Text='<%#Bind("RETURN") %>'  Width="90px" ></asp:Label>
                </ItemTemplate>
                <HeaderStyle HorizontalAlign="Center" Width="100px" />
                <ItemStyle HorizontalAlign="Right" Width="90px" />
            </asp:TemplateField>
                
            <asp:BoundField DataField="STOCKOUT" HeaderText="STOCKOUT" ReadOnly = "True" >
                <ControlStyle CssClass="zHidden" />
                <FooterStyle CssClass="zHidden" />
                <HeaderStyle CssClass="zHidden" />
                <ItemStyle CssClass="zHidden" />
            </asp:BoundField>
            <asp:BoundField DataField="MATERIALMASTER" HeaderText="MATERIALMASTER" ReadOnly = "True" >
                <ControlStyle CssClass="zHidden" />
                <FooterStyle CssClass="zHidden" />
                <HeaderStyle CssClass="zHidden" />
                <ItemStyle CssClass="zHidden" />
            </asp:BoundField>
        </Columns>
        <HeaderStyle CssClass="t_headtext" />
        <AlternatingRowStyle CssClass="t_alt_bg" />
        <PagerSettings Visible="False" />
    </asp:GridView><uc2:PageControl ID="pcBot2" runat="server" OnPageChange="PageChange2"   />
    <br />
    <table>
        <tr>
            <td>
                <asp:Label ID="lable1" runat="server" Text="�����˵� :" ForeColor="red" Width="600px"></asp:Label>
            </td>
        </tr>
        <tr>
            <td>
                <asp:Label ID="Label6" runat="server" Text="�ӹǹ����ٵ� ��� �ӹǹ���ӹǳ�Ҩҡ���� � ���ҷ��˹��§ҹ�ԡ" ForeColor="green" Width="600px"></asp:Label>
            </td>
        </tr>
        <tr>
            <td>
                <asp:Label ID="Label2" runat="server" Text="�ӹǹ���� ��� �ӹǹ����ѧ�����͡" ForeColor="green" Width="600px"></asp:Label>
            </td>
        </tr>
        <tr>
            <td>
                <asp:Label ID="Label5" runat="server" Text="�ӹǹ����ͧ�� ��� �ӹǹ���˹����������ͧ�����" ForeColor="green" Width="600px"></asp:Label>
            </td>
        </tr>
        <tr>
            <td>
                <asp:Label ID="Label8" runat="server" Text="�ӹǹ�׹��ѧ ��� �ӹǹ����-�ӹǹ����ͧ�� �ӹǹ�С�Ѻ�׹��Ҥ�ѧ���ѵ��ѵ�" ForeColor="green" Width="600px"></asp:Label>
            </td>
        </tr>
    </table>
    </asp:Panel>
</asp:Content>

