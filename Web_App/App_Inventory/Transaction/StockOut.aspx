<%@ Page Language="C#" MasterPageFile="~/Templates/Page1.master" AutoEventWireup="true" CodeFile="StockOut.aspx.cs" Inherits="App_Inventory_Transaction_StockOut" Title="SHND : Transaction - Stock out" %>
<%@ Register Src="../../Search/MenuStockOutPopup.ascx" TagName="MenuStockOutPopup" TagPrefix="uc4" %>
<%@ Register Src="../../Search/MaterialUnitPopup.ascx" TagName="MaterialUnitPopup" TagPrefix="uc3" %>
<%@ Register Src="../../Templates/CalendarControl.ascx" TagName="CalendarControl" TagPrefix="uc2" %>
<%@ Register Src="../../Templates/ToolBarItemCtl.ascx" TagName="ToolBarItemCtl" TagPrefix="uc1" %>
<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="cc1" %>
<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" Runat="Server">
    <table border="0" cellpadding="0" cellspacing="0" width="100%">
        <tr>
            <td class="headtext">
                �����š�è�����ʴ�</td>
        </tr>
        <tr>
            <td>
                <uc1:ToolBarItemCtl ID="tbSave" runat="server" ToobarTitle="�ѹ�֡������" ToolbarImage="../../Images/save2.png" OnClick="tbSaveClick" />
                <uc1:ToolBarItemCtl ID="tbCancel" runat="server" ToobarTitle="¡��ԡ������" ToolbarImage="../../Images/cancel.png" OnClick="tbCancelClick" />
                <uc1:ToolBarItemCtl ID="tbBack" runat="server" ToobarTitle="��Ѻ˹����¡��" ToolbarImage="../../Images/icn_back.png" OnClick="tbBackClick" />
                <uc1:ToolBarItemCtl ID="tbApprove" runat="server" ToobarTitle="͹��ѵ�" ToolbarImage="../../Images/icn_approve.png" OnClick="tbApproveClick" />
                <uc1:ToolBarItemCtl ID="tbNotApprove" runat="server" ToobarTitle="���͹��ѵ�" ToolbarImage="../../Images/icn_cancel.png" OnClick="tbNotApproveClick" />
                <uc1:ToolBarItemCtl ID="tbVoid" runat="server" ToobarTitle="¡��ԡ" ToolbarImage="../../Images/icn_delete.png" OnClick="tbVoidClick" />
                <uc1:ToolBarItemCtl ID="tbPrint" runat="server" ToobarTitle="�������ԡ" ToolbarImage="../../Images/icn_print.png"/>
            </td>
        </tr>
        <tr>
            <td style="height:30px">
                <hr style="size:1px" />
                <asp:Label ID="lbStatus" runat="server" EnableViewState="False"></asp:Label>
                <asp:TextBox ID="txtLOID" runat="server" CssClass="zHidden" Width="50px"></asp:TextBox>
                <asp:TextBox ID="txtStatus" runat="server" CssClass="zHidden" Width="50px"></asp:TextBox>
            </td>
        </tr>
        <tr>
            <td>
                <table border="0" cellpadding="0" cellspacing="0" width="100%">
                    <tr>
                        <td valign="top" style="padding:5px; border-right: 1px solid; border-top: 1px solid; border-left: 1px solid; border-bottom: 1px solid; width:600px">
                            <table border="0" cellpadding="0" cellspacing="0" width="600">
                                <tr style="height:24px">
                                    <td style="width:100px; text-align:right; padding-right:10px">
                                        �Ţ����ԡ :</td> 
                                    <td style="width:170px">
                                        <asp:TextBox ID="txtCode" runat="server" CssClass="zTextbox-View" ReadOnly="True"
                                            Width="150px"></asp:TextBox></td> 
                                    <td style="width:100px; text-align:right; padding-right:10px">
                                        �ѹ����ԡ :</td> 
                                    <td>
                                        <uc2:CalendarControl ID="ctlStockDate" runat="server" Enabled="false" />&nbsp;<span class="zRemark">*</span>
                                    </td> 
                                </tr>
                                <tr style="height:24px">
                                    <td style="width:100px; text-align:right; padding-right:10px">
                                        ˹��·���ԡ :</td> 
                                    <td style="width:170px">
                                        <asp:DropDownList ID="cmbDivision" runat="server" CssClass="zComboBox" Enabled="False"
                                            Width="156px">
                                        </asp:DropDownList></td> 
                                    <td style="width:100px; text-align:right; padding-right:10px">
                                        ��ѧ :</td> 
                                    <td>
                                        <asp:DropDownList ID="cmbWarehouse" runat="server" CssClass="zComboBox" Width="156px">
                                        </asp:DropDownList>&nbsp;<span class="zRemark">*</span></td> 
                                </tr>
                                <tr style="height:24px">
                                    <td style="width:100px; text-align:right; padding-right:10px">
                                        ����������ԡ :</td> 
                                    <td style="width:170px">
                                        <asp:DropDownList ID="cmbDocType" runat="server" CssClass="zComboBox" Width="156px" Enabled="False">
                                        </asp:DropDownList>&nbsp;<span class="zRemark">*</span></td> 
                                    <td style="width:100px; text-align:right; padding-right:10px">
                                        �ӹǹ������ :</td> 
                                    <td>
                                        <asp:TextBox ID="txtOrderQty" runat="server" CssClass="zTextboxR-View" ReadOnly="True"
                                            Width="150px"></asp:TextBox></td> 
                                </tr>
                                <tr style="height:24px">
                                    <td style="width:100px; text-align:right; padding-right:10px">
                                        �ѹ����� :</td> 
                                    <td style="width:170px">
                                        <uc2:CalendarControl ID="ctlUseDate" runat="server" Enabled="false" />&nbsp;<span class="zRemark">*</span>
                                    </td> 
                                    <td style="width:100px; text-align:right; padding-right:10px">
                                        ���ͷ���� :</td> 
                                    <td>
                                        <asp:CheckBox ID="chkIsBreakfast" runat="server" Text="���" Enabled="False" />
                                        <asp:CheckBox ID="chkIsLunch" runat="server" Text="��ҧ�ѹ" Enabled="False" />
                                        <asp:CheckBox ID="chkIsDinner" runat="server" Text="���" Enabled="False" /></td> 
                                </tr>
                            </table>
                        </td>
                        <td style="width:4px">&nbsp;
                        </td>
                        <td valign="top" style="border-right: 1px solid; border-top: 1px solid; border-left: 1px solid; border-bottom: 1px solid;">
                            <table border="0" cellpadding="0" cellspacing="0" width="100%">
                                <tr>
                                    <td style="border-bottom: 1px solid; padding:5px;">
                                        <table border="0" cellpadding="0" cellspacing="0" width="600">
                                            <tr style="height:24px">
                                                <td style="padding-right:10px; text-align:right; width:80px">
                                                    ʶҹ� :</td>
                                                <td style="width:520px">
                                                    <asp:TextBox ID="txtStatusName" runat="server" CssClass="zTextbox-View" ReadOnly="True"
                                                        Width="120px"></asp:TextBox></td>
                                            </tr>
                                        </table> 
                                    </td> 
                                </tr>
                                <tr>
                                    <td style="padding:5px">
                                        <table border="0" cellpadding="0" cellspacing="0" width="600">
                                            <tr style="height:24px">
                                                <td style="padding-right:10px; text-align:right; width:80px">
                                                    ����Թ :</td>
                                                <td style="width:520px">
                                                    <asp:TextBox ID="txtNetPrice" runat="server" CssClass="zTextboxR-View" ReadOnly="True"
                                                        Width="120px"></asp:TextBox></td>
                                            </tr>
                                        </table> 
                                    </td> 
                                </tr>
                            </table>
                        </td>
                    </tr> 
                </table>  
            </td>
        </tr>
        <tr>
            <td style="height:3px">
            </td>
        </tr>
        <tr>
            <td class="toolbarplace" style="padding:3px">
                <asp:Panel ID="pnlCalculate" runat="server">
                    <table border="0" cellpadding="0" cellspacing="0" width="500px">
                        <tr>
                            <td style="padding:2px; background-color:#ebe1eb; width:200px">&nbsp;&nbsp;
                                <asp:TextBox ID="txtDiscountOrder" runat="server" CssClass="zTextboxR" Width="50px"></asp:TextBox>
                                <asp:Label ID="Label1" runat="server" Text="% �ҡ�ӹǹ������"></asp:Label>
                                <asp:ImageButton ID="imbCalculateOrder" runat="server" ImageUrl="~/Images/icn_calculate.png" ImageAlign="AbsMiddle" ToolTip="�ӹǳ" OnClick="imbCalculateOrder_Click" />&nbsp;&nbsp;
                            </td>
                            <td style="width:3px"></td>
                            <td style="padding:2px; background-color:#ebe1eb; width:217px">&nbsp;&nbsp;
                                <asp:TextBox ID="txtDiscountFormula" runat="server" CssClass="zTextboxR" Width="50px"></asp:TextBox>
                                <asp:Label ID="Label2" runat="server" Text="% �ͧ�ӹǹ����ٵ�"></asp:Label>
                                <asp:ImageButton ID="imbCalculateFormula" runat="server" ImageUrl="~/Images/icn_calculate.png" ImageAlign="AbsMiddle" ToolTip="�ӹǳ" OnClick="imbCalculateFormula_Click" />&nbsp;&nbsp;
                            </td>
                        </tr>
                    </table>
                </asp:Panel>
            </td>
        </tr>
        <tr>
            <td>
                <asp:GridView ID="gvMain" runat="server" AutoGenerateColumns="False" CssClass="t_tablestyle" Width="100%" >
                    <Columns>
                        <asp:BoundField DataField="LOID" HeaderText="LOID">
                            <ControlStyle CssClass="zHidden" />
                            <FooterStyle CssClass="zHidden" />
                            <HeaderStyle CssClass="zHidden" />
                            <ItemStyle CssClass="zHidden" />
                        </asp:BoundField>
                        <asp:TemplateField HeaderText="�ӴѺ" SortExpression="DEFAULT">
                            <ItemTemplate>
                                <%# Container.DataItemIndex+1 %>
                            </ItemTemplate>
                            <HeaderStyle Width="60px" />
                            <ItemStyle HorizontalAlign="Center" Width="60px" />
                        </asp:TemplateField>
                        <asp:BoundField DataField="CODE" HeaderText="����" SortExpression="CODE">
                            <HeaderStyle Width="80px" />
                            <ItemStyle Width="80px" HorizontalAlign="Center" />
                        </asp:BoundField>
                        <asp:BoundField DataField="MATERIALNAME" HeaderText="��¡��" SortExpression="MATERIALNAME">
                        </asp:BoundField>
                        <asp:BoundField DataField="UNITNAME" HeaderText="˹��¹Ѻ" SortExpression="UNITNAME">
                            <HeaderStyle Width="80px" />
                            <ItemStyle Width="80px" />
                        </asp:BoundField>
                        <asp:BoundField DataField="FORMULAQTY" HeaderText="�ӹǹ����ٵ�" SortExpression="FORMULAQTY" HtmlEncode="False" DataFormatString="{0:#,##0.00}">
                            <HeaderStyle Width="90px" />
                            <ItemStyle Width="90px" HorizontalAlign="Right" />
                        </asp:BoundField>
                        <asp:BoundField DataField="PREQTY" HeaderText="�ӹǹ&lt;br&gt;�����ǧ˹��" SortExpression="PREQTY" HtmlEncode="False" DataFormatString="{0:#,##0.00}">
                            <HeaderStyle Width="90px" />
                            <ItemStyle Width="90px" HorizontalAlign="Right" />
                        </asp:BoundField>
                        <asp:BoundField DataField="LASTQTY" HeaderText="�ӹǹ&lt;br&gt;�ԡ����ش" SortExpression="LASTQTY" HtmlEncode="False" DataFormatString="{0:#,##0.00}">
                            <HeaderStyle Width="90px" />
                            <ItemStyle Width="90px" HorizontalAlign="Right" />
                        </asp:BoundField>
                        <asp:TemplateField HeaderText="�ӹǹ&lt;br&gt;����ͧ���">
                            <ItemTemplate>
                                <asp:TextBox ID="txtReqQty" runat="server" Width="85px" Text='<%# Convert.ToDouble(Eval("REQQTY")).ToString("#,##0.00") %>' 
                                    CssClass="zTextboxR-View" ReadOnly="true"></asp:TextBox> 
                            </ItemTemplate>
                            <ItemStyle Width="90px" HorizontalAlign="Right" />
                            <HeaderStyle Width="90px" />  
                        </asp:TemplateField>
                        <asp:TemplateField HeaderText="�ӹǹ&lt;br&gt;������">
                            <ItemTemplate>
                                <asp:TextBox ID="txtQty" runat="server" Width="85px" Text='<%# Convert.ToDouble(Eval("QTY")).ToString("#,##0.00") %>' 
                                    CssClass='<%# Convert.ToString(Eval("STATUSSTOCKOUT")) == "SE" ? "zTextboxR" : "zTextboxR-View" %>' 
                                    ReadOnly='<%# Convert.ToString(Eval("STATUSSTOCKOUT")) != "SE" %>'
                                    onkeypress="ChkDbl(this)" onblur="valDbl(this)" onfocus="prepareNum(this)" ></asp:TextBox> 
                            </ItemTemplate>
                            <ItemStyle Width="90px" HorizontalAlign="Right" />
                            <HeaderStyle Width="90px" />  
                        </asp:TemplateField>
                        <asp:TemplateField HeaderText="͹��ѵ�">
                            <HeaderTemplate>
                                <asp:Label ID="lbApprove" runat="server" Text="͹��ѵ�"></asp:Label><input type="checkbox" title="͹��ѵ�" name="chkMain" id="chkMain" onclick="chkAllBox(this, 'ctl00_MainContent_gvMain_ctl', '_chkApprove')" />
                            </HeaderTemplate>
                            <ItemTemplate>
                                <asp:CheckBox ID="chkApprove" runat="server" Checked='<%# Eval("STATUS").ToString() == "AP" %>' Enabled='<%# Convert.ToString(Eval("STATUSSTOCKOUT")) == "SE" %>' />
                            </ItemTemplate>
                            <ItemStyle Width="40px" HorizontalAlign="center" />
                            <HeaderStyle Width="40px" />  
                        </asp:TemplateField>
                        <asp:BoundField DataField="REMAIN" HeaderText="�ӹǹ����ѧ" SortExpression="REMAIN" HtmlEncode="False" DataFormatString="{0:#,##0.00}">
                            <HeaderStyle Width="100px" />
                            <ItemStyle Width="100px" HorizontalAlign="Right" />
                        </asp:BoundField>
                        <asp:BoundField DataField="TOTAL" HeaderText="�ӹǹ�Թ" SortExpression="TOTAL" HtmlEncode="False" DataFormatString="{0:#,##0.00}">
                            <HeaderStyle Width="100px" />
                            <ItemStyle Width="100px" HorizontalAlign="Right" />
                        </asp:BoundField>
                        <asp:BoundField DataField="ISMENU" HeaderText="M" SortExpression="ISMENU">
                            <HeaderStyle Width="30px" />
                            <ItemStyle Width="30px" HorizontalAlign="center" />
                        </asp:BoundField>
                        <asp:BoundField DataField="STATUSNAME" HeaderText="ʶҹ�" SortExpression="STATUSNAME">
                            <HeaderStyle HorizontalAlign="Center" Width="100px" />
                            <ItemStyle Width="100px" />
                        </asp:BoundField>
                        <asp:BoundField DataField="STATUS" HeaderText="STATUS">
                            <ControlStyle CssClass="zHidden" />
                            <FooterStyle CssClass="zHidden" />
                            <HeaderStyle CssClass="zHidden" />
                            <ItemStyle CssClass="zHidden" />
                        </asp:BoundField>
                        <asp:BoundField DataField="MATERIALMASTER" HeaderText="MATERIALMASTER">
                            <ControlStyle CssClass="zHidden" />
                            <FooterStyle CssClass="zHidden" />
                            <HeaderStyle CssClass="zHidden" />
                            <ItemStyle CssClass="zHidden" />
                        </asp:BoundField>
                        <asp:BoundField DataField="UNIT" HeaderText="UNIT">
                            <ControlStyle CssClass="zHidden" />
                            <FooterStyle CssClass="zHidden" />
                            <HeaderStyle CssClass="zHidden" />
                            <ItemStyle CssClass="zHidden" />
                        </asp:BoundField>
                        <asp:BoundField DataField="PRICE" HeaderText="PRICE">
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
            </td>
        </tr>
    </table>
</asp:Content>

