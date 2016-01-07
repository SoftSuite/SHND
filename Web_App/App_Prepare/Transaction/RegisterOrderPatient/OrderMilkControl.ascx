<%@ Control Language="C#" AutoEventWireup="true" CodeFile="OrderMilkControl.ascx.cs" Inherits="App_Prepare_Transaction_RegisterOrderPatient_OrderMilkControl" %>
<%@ Register Src="../../../Templates/PageControl.ascx" TagName="PageControl" TagPrefix="uc3" %>
<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="cc1" %>
<%@ Register Src="../../../Templates/ToolBarItemCtl.ascx" TagName="ToolBarItemCtl" TagPrefix="uc2" %>
<%@ Register Src="../../../Templates/CalendarControl.ascx" TagName="CalendarControl" TagPrefix="uc1" %>
<table border="0" cellpadding="0" cellspacing="0" width="100%">
    <tr>
        <tr>
            <td style="height:20px"><asp:Label ID="lbStatus" runat="server" EnableViewState="False"></asp:Label></td>
        </tr>
        <td>
            <fieldset style="padding:15px;">
                <legend style="font-weight:bold">
                    ����
                </legend>
                <table border="0" cellpadding="0" cellspacing="0" width="900px">
                    <tr>
                        <td style="height:15px" colspan="8"></td>
                    </tr> 
                    <tr style="height: 24px">
                        <td style="padding-right: 10px; width: 110px; text-align: right">
                            �ѹ����������� :</td>
                        <td colspan="7">
                            <uc1:CalendarControl ID="ctlSearchDate" runat="server" />
                            &nbsp;<span class="zRemark">*</span>
                        </td>
                    </tr>
                    <tr style="height: 24px">
                        <td style="padding-right: 10px; width: 110px; text-align: right">
                            �ͼ����� :</td>
                        <td colspan="7">
                            <asp:DropDownList ID="cmbSearchWard" runat="server" CssClass="zComboBox" Width="200px">
                            </asp:DropDownList></td>
                    </tr>
                    <tr style="height: 24px">
                        <td style="padding-right: 10px; width: 110px; text-align: right;">
                            ��Դ�������� :</td>
                        <td colspan="7">
                            <asp:DropDownList ID="cmbSearchMilkCategory" runat="server" CssClass="zComboBox" Width="200px">
                            </asp:DropDownList></td>
                    </tr>
                    <tr style="height: 24px">
                        <td style="padding-right: 10px; width: 110px; text-align: right">
                            ����-ʡ�� ������ :</td>
                        <td colspan="7">
                            <asp:TextBox ID="txtSearchPatientName" runat="server" CssClass="zTextbox" Width="340px"></asp:TextBox></td>
                    </tr>
                    <tr style="height:24px">
                        <td style="width:110px; text-align: right; padding-right:10px">
                            �ѹ���ѹ�֡ :</td>
                        <td style="width:150px;">
                            <uc1:CalendarControl ID="ctlSearchOrderDate" runat="server" />
                        </td>
                        <td style="width:50px; text-align: right; padding-right:10px">
                            ���� :</td>
                        <td style="width:50px;">
                            <asp:TextBox ID="txtSearchTimeFrom" runat="server" CssClass="zTextboxR" Width="45px"></asp:TextBox></td>
                        <td style="width:34px;" align="center">
                            �֧</td>
                        <td style="width:50px;">
                            <asp:TextBox ID="txtSearchTimeTo" runat="server" CssClass="zTextboxR" Width="45px"></asp:TextBox></td>
                        <td style="width:70px; padding-left:10px" class="zRemark">
                            (Ex 08:00)</td>
                        <td>
                            <asp:ImageButton ID="imbSearch" runat="server" ImageUrl="~/Images/icn_find.png" ImageAlign="absMiddle" OnClick="imbSearch_Click" />
                            <asp:ImageButton ID="imbReset" runat="server" ImageUrl="~/Images/icn_back.png" ImageAlign="absMiddle" OnClick="imbReset_Click" />
                        </td>
                    </tr>
                </table> 
                <cc1:MaskedEditExtender ID="mdeTimeFrom" runat="server" TargetControlID="txtSearchTimeFrom" MaskType="Time" Mask="99:99"></cc1:MaskedEditExtender>
                <cc1:MaskedEditExtender ID="mdeTimeTo" runat="server" TargetControlID="txtSearchTimeTo" MaskType="Time" Mask="99:99"></cc1:MaskedEditExtender>
            </fieldset>
        </td>
    </tr>
    <tr>
        <td class="toolbarplace" style="height: 19px">
            <uc2:ToolBarItemCtl ID="tbRegister" runat="server" ToolbarImage="../../Images/icn_approve.png" ToobarTitle="Register" OnClick="tbRegister_Click" />
        </td>
    </tr>
    <tr>
        <td>
            <uc3:PageControl ID="pcTop" runat="server" OnPageChange="PageChange"  />
            <asp:GridView ID="gvMain" runat="server" AllowSorting="True" AutoGenerateColumns="False" CssClass="t_tablestyle1" CellPadding="0" OnRowDataBound="gvMain_RowDataBound" Width="100%">
                <Columns>
                    <asp:BoundField DataField="ORDERMILK" HeaderText="ORDERMILK">
                        <ControlStyle CssClass="zHidden" />
                        <FooterStyle CssClass="zHidden" />
                        <HeaderStyle CssClass="zHidden" />
                        <ItemStyle CssClass="zHidden" />
                    </asp:BoundField>
                    <asp:TemplateField>
                        <HeaderTemplate>
                            <table border="0" cellpadding="2" cellspacing="0" width="100%">
                                <tr style="height:20px" class="t_headtext">
                                    <td style="width:40px; border-right:solid 1px #ebe9ed" align="center">�ӴѺ</td> 
                                    <td style="width:30px; border-right:solid 1px #ebe9ed" align="center"><asp:CheckBox ID="chkMain" runat="server" /></td> 
                                    <td style="width:150px; border-right:solid 1px #ebe9ed" align="center">�ͼ�����</td> 
                                    <td style="width:30px; border-right:solid 1px #ebe9ed" align="center">��ͧ</td> 
                                    <td style="width:30px; border-right:solid 1px #ebe9ed" align="center">��§</td> 
                                    <td style="width:50px; border-right:solid 1px #ebe9ed" align="center">HN</td> 
                                    <td style="width:50px; border-right:solid 1px #ebe9ed" align="center">AN</td> 
                                    <td style="width:50px; border-right:solid 1px #ebe9ed" align="center">VN</td>  
                                    <td style="width:250px; border-right:solid 1px #ebe9ed" align="center">����-ʡ��</td> 
                                    <td style="width:30px; border-right:solid 1px #ebe9ed" align="center">����</td>  
                                    <td style="width:30px; border-right:solid 1px #ebe9ed" align="center">�.�.</td>  
                                    <td style="width:30px; border-right:solid 1px #ebe9ed" align="center">�.�.</td>  
                                    <td align="center">BMI</td>  
                                </tr>
                            </table>
                        </HeaderTemplate>
                        <ItemTemplate>
                            <table border="0" cellpadding="2" cellspacing="0" width="100%">
                                <tr style="height:20px" class='<%# Eval("RANK").ToString() != "0" ? "t_alt_bg" : "zHidden" %>'>
                                    <td style="width:40px; border-right:solid 1px #ebe9ed" align="center"><%# Eval("RANK") %></td> 
                                    <td style="width:30px; border-right:solid 1px #ebe9ed" align="center">&nbsp;</td> 
                                    <td style="width:150px; border-right:solid 1px #ebe9ed" align="left"><%# Eval("WARDNAME") %></td> 
                                    <td style="width:30px; border-right:solid 1px #ebe9ed" align="center"><%# Eval("ROOMNO") %></td> 
                                    <td style="width:30px; border-right:solid 1px #ebe9ed" align="center"><%# Eval("BEDNO") %></td> 
                                    <td style="width:50px; border-right:solid 1px #ebe9ed" align="center"><%# Eval("HN") %></td> 
                                    <td style="width:50px; border-right:solid 1px #ebe9ed" align="center"><%# Eval("AN") %></td> 
                                    <td style="width:50px; border-right:solid 1px #ebe9ed" align="center"><%# Eval("VN") %></td>  
                                    <td style="width:250px; border-right:solid 1px #ebe9ed" align="left"><%# Eval("PATIENTNAME") %></td> 
                                    <td style="width:30px; border-right:solid 1px #ebe9ed" align="right"><%# Eval("AGE") %></td>  
                                    <td style="width:30px; border-right:solid 1px #ebe9ed" align="right"><%# Eval("WEIGHT") %></td>  
                                    <td style="width:30px; border-right:solid 1px #ebe9ed" align="right"><%# Eval("HEIGHT") %></td>  
                                    <td style="border-right:solid 1px #ebe9ed" align="left"><%# Eval("BMI") %></td>  
                                </tr>
                                <tr style="height:1px">
                                    <td style="width:40px; border-right:solid 1px #ebe9ed" align="center"></td> 
                                    <td style="width:30px; border-right:solid 1px #ebe9ed" align="center"></td> 
                                    <td style="width:150px;" align="left"></td> 
                                    <td style="width:30px;" align="center"></td> 
                                    <td style="width:30px;" align="center"></td> 
                                    <td style="width:50px;" align="center"></td> 
                                    <td style="width:50px;" align="center"></td> 
                                    <td style="width:50px;" align="center"></td>  
                                    <td style="width:250px;" align="left"></td> 
                                    <td style="width:30px;" align="right"></td>  
                                    <td style="width:30px;" align="right"></td>  
                                    <td style="width:30px;" align="right"></td>  
                                    <td align="left"></td>  
                                </tr>
                                <tr style="height:20px">
                                    <td style="width:40px; border-right:solid 1px #ebe9ed" align="center"></td> 
                                    <td style="width:30px; border-right:solid 1px #ebe9ed" align="center"><asp:CheckBox ID="chkSelect" runat="server" Visible='<%# Eval("STATUS").ToString() != "NA" %>'/></td> 
                                    <td align="left" colspan="11">
                                        <table border="0" cellpadding="0" cellspacing="0" width="100%">
                                            <tr style="height:24px">
                                                <td style="width:70px"><b>No. : </b><%# Eval("ORDERNO") %></td>
                                                <td style="width:180px"><b>��Դ�������� : </b><%# Eval("MILKNAME") %></td>
                                                <td style="width:100px"><b>��ѧ�ҹ : </b><%# Eval("ENERGY") %></td>
                                                <td style="width:180px"><b>�ӹǹ���� : </b><%# Eval("MEALQTY") %></td>
                                                <td style="width:80px"><b>��/���� : </b><%# Eval("VOLUMN") %></td>
                                                <td><b>�ѹ-���ҷ��ѹ�֡ : </b><%# Eval("ORDERDATE", "{0:dd/MM/yyyy HH:mm:ss}") %></td>
                                            </tr>
                                            <tr style="height:20px">
                                                <td colspan="2"><b>����� : </b><asp:DropDownList ID="cmbMilkCode" CssClass="zComboBox" runat="server" Width="100px"></asp:DropDownList></td>
                                                <td colspan="3"><b>ʶҹ� : </b><span style="color:Red"><%# Eval("STATUSNAME") %></span></td>
                                            </tr>
                                        </table>
                                    </td> 
                                </tr> 
                            </table>
                        </ItemTemplate>
                    </asp:TemplateField>
                    <asp:BoundField DataField="WARDID" HeaderText="WARDID">
                        <ControlStyle CssClass="zHidden" />
                        <FooterStyle CssClass="zHidden" />
                        <HeaderStyle CssClass="zHidden" />
                        <ItemStyle CssClass="zHidden" />
                    </asp:BoundField>
                </Columns>
                <PagerSettings Visible="False" />
            </asp:GridView>
            <uc3:PageControl ID="pcBot" runat="server"  OnPageChange="PageChange"  /> 
        </td>
    </tr>
</table>
<asp:Button ID="btnRegister" runat="server" Text="Button" CssClass="zHidden" />
<cc1:ModalPopupExtender ID="mpeRegister" runat="server" TargetControlID="btnRegister" PopupControlID="pnlRegister" BackgroundCssClass="modalBackground" DropShadow="true"></cc1:ModalPopupExtender>
<asp:Panel ID="pnlRegister" runat="server" CssClass="modalPopup" style="display:none" Width="400px">
    <table border="0" cellpadding="0" cellspacing="0" width="100%">
        <tr>
            <td class="subheadertext">�׹�ѹ��� Register</td>
        </tr>
        <tr>
            <td>
                <uc2:ToolBarItemCtl ID="tbSaveRegister" runat="server" ToolbarImage="../../Images/save2.png" ToobarTitle="�ѹ�֡" OnClick="tbSaveRegister_Click" />
                <uc2:ToolBarItemCtl ID="tbCancelRegister" runat="server" ToolbarImage="../../Images/icn_back.png" ToobarTitle="¡��ԡ" />
            </td>
        </tr>
        <tr>
            <td><hr style="size:1px" /><asp:Label ID="lbRegisterStatus" runat="server" EnableViewState="False"></asp:Label></td>
        </tr>
        <tr>
            <td>
                <table border="0" cellpadding="0" cellspacing="0" width="400">
                    <tr style="height:24px">
                        <td style="width:120px; padding-right:10px" align="right">�����á������ :</td>
                        <td>
                            <asp:DropDownList ID="cmbFirstMealRegister" runat="server" CssClass="zComboBox" Width="100px">
                                <asp:ListItem Value="">���͡</asp:ListItem>
                                <asp:ListItem Value="11">���</asp:ListItem>
                                <asp:ListItem Value="21">��ҧ�ѹ</asp:ListItem>
                                <asp:ListItem Value="31">���</asp:ListItem>
                            </asp:DropDownList>
                            <span class="zRemark">*</span></td>
                    </tr> 
                    <tr style="height:24px">
                        <td style="width:120px; padding-right:10px" align="right">�ѹ��� :</td>
                        <td>
                            <uc1:CalendarControl ID="ctlFirstDateRegister" runat="server" /><span class="zRemark">&nbsp;*</span>
                        </td>
                    </tr> 
                </table> 
            </td>
        </tr>
        <tr>
            <td style="height:24px"></td>
        </tr>
    </table>
</asp:Panel>