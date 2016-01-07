<%@ Control Language="C#" AutoEventWireup="true" CodeFile="NpoOrderSetCtl.ascx.cs" Inherits="App_Prepare_Transaction_NpoOrderSet_NpoOrderSetCtl" %>
<%@ Register Src="../../../Templates/ToolBarItemCtl.ascx" TagName="ToolBarItemCtl"
    TagPrefix="uc2" %>

<%@ Register Src="../../../Templates/PageControl.ascx" TagName="PageControl" TagPrefix="uc3" %>
<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="cc1" %>

<%@ Register Src="../../../Templates/CalendarControl.ascx" TagName="CalendarControl" TagPrefix="uc1" %>
<table border="0" cellpadding="0" cellspacing="0" width="100%">

        <tr>
            <td style="height: 15px">
                <fieldset style="padding:15px;">
                    <legend style="font-weight:bold">
                        ���Ң�����
                    </legend>

                <table border="0" cellpadding="0" cellspacing="0" width="900px">
                    <tr>
                        <td style="height:15px" colspan="8"></td>
                    </tr> 
                    <tr style="height: 24px">
                        <td style="padding-right: 10px; width: 110px; text-align: right">
                            �ͼ����� :</td>
                        <td colspan="7">
                            <asp:DropDownList ID="cmbWard" runat="server" CssClass="zComboBox" Width="200px">
                            </asp:DropDownList></td>
                    </tr>

                    <tr style="height: 24px">
                        <td style="padding-right: 10px; width: 110px; text-align: right">
                            ����-ʡ�� ������ :</td>
                        <td colspan="7">
                            <asp:TextBox ID="txtPatientName" runat="server" CssClass="zTextbox" Width="340px"></asp:TextBox></td>
                    </tr>
                    
                    <tr style="height:24px">
                        <td style="width:110px; text-align: right; padding-right:10px">
                            �ѹ��觴����� :</td>
                        <td style="width:150px;">
                            <uc1:CalendarControl ID="ctlNpoStart" runat="server" />
                        </td>
                        <td style="width:50px; text-align: right; padding-right:10px">
                            ���� :</td>
                        <td style="width:29px;">
                            <asp:TextBox ID="txtTimeFrom" runat="server" CssClass="zTextboxR" Width="45px"></asp:TextBox></td>
                        <td style="width:34px;" align="center">
                            �֧</td>
                        <td style="width:50px;">
                            <asp:TextBox ID="txtTimeTo" runat="server" CssClass="zTextboxR" Width="45px"></asp:TextBox></td>
                        <td style="width:70px; padding-left:10px" class="zRemark" colspan="1">
                            (Ex 08:00)</td>
                        <td>
                            <asp:ImageButton ID="btnSearch" runat="server" ImageUrl="~/Images/icn_find.png" ImageAlign="absMiddle" OnClick="imbSearch_Click" />&nbsp;
                            &nbsp;<asp:ImageButton ID="imbReset" runat="server" ImageUrl="~/Images/icn_back.png" ImageAlign="absMiddle" OnClick="imbReset_Click" Visible="false" />

                        </td>
                    </tr>
                    <tr style="height: 24px">
                        <td style="padding-right: 10px; width: 110px; text-align: right">
                            ��Դ����÷����� :</td>
                        <td colspan="7">
                            <asp:DropDownList ID="cmbOrderType" runat="server" CssClass="zComboBox" Width="200px">
                                <asp:ListItem Value="" Text="������"></asp:ListItem>
                                <asp:ListItem Value="S" Text="��������Ѻ"></asp:ListItem>
                                <asp:ListItem Value="F" Text="����÷ҧ�����������"></asp:ListItem>
                                <asp:ListItem Value="M" Text="��������Ѻ��"></asp:ListItem>
                            </asp:DropDownList></td>
                    </tr>
                    
                </table> 
                <cc1:MaskedEditExtender ID="mdeTimeFrom" runat="server" TargetControlID="txtTimeFrom" MaskType="Time" Mask="99:99"></cc1:MaskedEditExtender>
                <cc1:MaskedEditExtender ID="mdeTimeTo" runat="server" TargetControlID="txtTimeTo" MaskType="Time" Mask="99:99"></cc1:MaskedEditExtender>

            </fieldset>
        </td>
    </tr>
<br />
    <tr>
        <td>
            <uc3:PageControl ID="pcTop" runat="server" OnPageChange="PageChange"  />
            <asp:GridView ID="gvMain" runat="server" AllowSorting="True" AutoGenerateColumns="False" CssClass="t_tablestyle1" CellPadding="0" Width="100%">
                <Columns>
                    <asp:BoundField DataField="LOID" HeaderText="LOID">
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
                                    <td style="width:30px; border-right:solid 1px #ebe9ed" align="center"></td> 
                                    <td style="width:120px; border-right:solid 1px #ebe9ed" align="center">�ͼ�����</td> 
                                    <td style="width:30px; border-right:solid 1px #ebe9ed" align="center">��ͧ</td> 
                                    <td style="width:30px; border-right:solid 1px #ebe9ed" align="center">��§</td> 
                                    <td style="width:60px; border-right:solid 1px #ebe9ed" align="center">HN</td> 
                                    <td style="width:50px; border-right:solid 1px #ebe9ed" align="center">AN</td> 
                                    <td style="width:60px; border-right:solid 1px #ebe9ed" align="center">VN</td>  
                                    <td style="width:250px; border-right:solid 1px #ebe9ed" align="center">����-ʡ��</td> 
                                    <td style="width:30px; border-right:solid 1px #ebe9ed" align="center">����</td>  
                                    <td style="width:30px; border-right:solid 1px #ebe9ed" align="center">�.�.</td>  
                                    <td style="width:30px; border-right:solid 1px #ebe9ed" align="center">�.�.</td>  
                                    <td  align="center">BMI</td>  
                                </tr>
                            </table>
                        </HeaderTemplate>
                        <ItemTemplate>
                            <table border="0" cellpadding="2" cellspacing="0" width="100%">
                                <tr style="height:20px" class='<%# Eval("RANK").ToString() != "0" ? "t_alt_bg" : "zHidden" %>'>
                                    <td style="width:40px; border-right:solid 1px #ebe9ed" align="center"><%# Eval("RANK") %></td> 
                                    <td style="width:30px; border-right:solid 1px #ebe9ed" align="center"></td> 
                                    <td style="width:120px; border-right:solid 1px #ebe9ed" align="left"><%# Eval("WARDNAME") %></td> 
                                    <td style="width:30px; border-right:solid 1px #ebe9ed" align="center"><%# Eval("ROOMNO") %></td> 
                                    <td style="width:30px; border-right:solid 1px #ebe9ed" align="center"><%# Eval("BEDNO") %></td> 
                                    <td style="width:60px; border-right:solid 1px #ebe9ed" align="center"><%# Eval("HN") %></td> 
                                    <td style="width:50px; border-right:solid 1px #ebe9ed" align="center"><%# Eval("AN") %></td> 
                                    <td style="width:60px; border-right:solid 1px #ebe9ed" align="center"><%# Eval("VN") %></td>  
                                    <td style="width:250px; border-right:solid 1px #ebe9ed" align="left"><%# Eval("PATIENTNAME") %></td> 
                                    <td style="width:30px; border-right:solid 1px #ebe9ed" align="right"><%# Eval("AGE") %></td>  
                                    <td style="width:30px; border-right:solid 1px #ebe9ed" align="right"><%# Eval("WEIGHT") %></td>  
                                    <td style="width:30px; border-right:solid 1px #ebe9ed" align="right"><%# Eval("HEIGHT") %></td>  
                                    <td align="left"><%# Eval("BMI") %></td>  
                                </tr>
                                <tr style="height:1px">
                                    <td style="width:40px; border-right:solid 1px #ebe9ed" align="center"></td> 
                                    <td style="width:30px; border-right:solid 1px #ebe9ed" align="center"></td> 
                                    <td style="width:120px; border-right:solid 1px #ebe9ed" align="left"></td> 
                                    <td style="width:30px; border-right:solid 1px #ebe9ed" align="center"></td> 
                                    <td style="width:30px; border-right:solid 1px #ebe9ed" align="center"></td> 
                                    <td style="width:60px; border-right:solid 1px #ebe9ed" align="center"></td> 
                                    <td style="width:50px; border-right:solid 1px #ebe9ed" align="center"></td> 
                                    <td style="width:60px; border-right:solid 1px #ebe9ed" align="center"></td>  
                                    <td style="width:250px; border-right:solid 1px #ebe9ed" align="left"></td> 
                                    <td style="width:30px; border-right:solid 1px #ebe9ed" align="right"></td>  
                                    <td style="width:30px; border-right:solid 1px #ebe9ed" align="right"></td>  
                                    <td style="width:30px; border-right:solid 1px #ebe9ed" align="right"></td>  
                                    <td align="left"></td>  
                                </tr>
                                <tr style="height:20px">
                                    <td style="width:40px;" align="center"></td> 
                                    <td style="width:30px;" align="center"></td> 
                                    <td align="left" colspan="11">
                                        <table border="0" cellpadding="0" cellspacing="0" width="100%">
                                            <tr style="height:20px">
                                                <td style="width:220px"><b>������ : </b><%# Eval("FOODTYPENAME")%></td>
                                                <td style="width:120px"><b>��Դ : </b><%# Eval("FOODCATEGORYNAME")%></td>
                                                <td style="width:150px"><b>�ӹǹ : </b><%# Eval("QTY")%></td>
                                                <td style="width:250px"><b>�ѹ ���ҷ��ѹ�֡ : </b><%# Eval("ORDERDATE")%></td>
                                                <td></td>
                                            </tr>

                                            <tr style="height:20px">
                                                 <td colspan="2" style="width:340px"><b>�Ǻ��� : </b><%# Eval("CONTROL")%></td>
                                                <td style="width:150px"><b>�ӡѴ����ҳ : </b><%# Eval("LIMIT")%></td>
                                                <td style="width:250px"><b>���������� : </b><%# Eval("INCREASE")%></td>
                                                <td></td>
                                            </tr>
                                            <tr style="height:20px">
                                                 <td colspan="2" style="width:340px"><b>����÷�觴 : </b><%# Eval("ABSTAIN")%></td>
                                                <td colspan="2" style="width:400px"><b>�Ѻ੾�� : </b><%# Eval("NEED")%></td>
                                                <td></td>
                                            </tr>
                                              <tr style="height:20px">
                                                 <td colspan="2" style="width:340px"><b>�����˵� : </b><%# Eval("REMARKS")%></td>
                                                <td colspan="2" style="width:400px"><b>ʶҹ� : </b><%# Eval("STATUSNAME")%></td>
                                                <td></td>
                                            </tr>
                                        </table>
                                    </td> 
                                </tr> 
                            </table>
                        </ItemTemplate>
                    </asp:TemplateField>
                </Columns>
                <PagerSettings Visible="False" />
            </asp:GridView>
            <uc3:PageControl ID="pcBot" runat="server"  OnPageChange="PageChange"  /> 
        </td>
    </tr>
</table>