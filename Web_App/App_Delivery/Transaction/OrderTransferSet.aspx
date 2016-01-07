<%@ Page Language="C#" MasterPageFile="~/Templates/Page1.master" AutoEventWireup="true" CodeFile="OrderTransferSet.aspx.cs" Inherits="App_Delivery_Transaction_OrderTransferSet" Title="SHND : Transaction - Food Delivery" %>
<%@ Register Src="../../Templates/PageControl.ascx" TagName="PageControl" TagPrefix="uc3" %>
<%@ Register Src="../../Templates/CalendarControl.ascx" TagName="CalendarControl" TagPrefix="uc2" %>
<%@ Register Src="../../Templates/ToolBarItemCtl.ascx" TagName="ToolBarItemCtl" TagPrefix="uc1" %>
<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" Runat="Server">
    <table border="0" cellpadding="0" cellspacing="0" width="100%">
        <tr>
            <td class="headtext">�����š�èѴ����������Ѻ</td>
        </tr>
        <tr>
            <td>
                <uc1:ToolBarItemCtl ID="tbSave" runat="server" ToolbarImage="../../Images/save2.png" ToobarTitle="�ѹ�֡" OnClick="tbSaveClick" />
                <uc1:ToolBarItemCtl ID="tbPrint" runat="server" ToolbarImage="../../Images/icn_print.png" ToobarTitle="�������¡��" />
            </td>
        </tr>
        <tr>
            <td><hr style="size:1px" />
                <asp:Label ID="lbStatus" runat="server" EnableViewState="False"></asp:Label></td>
        </tr>
        <tr>
            <td>
                <fieldset style="padding:15px;">
                    <legend>����</legend>
                    <table border="0" cellpadding="0" cellspacing="0" width="900">
                        <tr>
                            <td style="height:15px" colspan="7"></td>
                        </tr> 
                        <tr style="height: 24px">
                            <td style="padding-right: 10px; width: 110px; text-align: right">
                                �ͼ����� :</td>
                            <td colspan="6">
                                <asp:DropDownList ID="cmbSearchWard" runat="server" CssClass="zComboBox" Width="200px">
                                </asp:DropDownList></td>
                        </tr>
                        <tr style="height: 24px">
                            <td style="padding-right: 10px; width: 110px; text-align: right;">
                                ����������� :</td>
                            <td colspan="6">
                                <asp:DropDownList ID="cmbSearchFoodType" runat="server" CssClass="zComboBox" Width="200px">
                                </asp:DropDownList></td>
                        </tr>
                        <tr style="height: 24px">
                            <td style="padding-right: 10px; width: 110px; text-align: right">
                                ��Դ����� :</td>
                            <td colspan="6">
                                <asp:DropDownList ID="cmbSearchFoodCategory" runat="server" CssClass="zComboBox" Width="200px">
                                </asp:DropDownList></td>
                        </tr>
                        <tr style="height: 24px">
                            <td style="padding-right: 10px; width: 110px; text-align: right">
                                ����-ʡ�� ������ :</td>
                            <td colspan="6">
                                <asp:TextBox ID="txtSearchPatientName" runat="server" CssClass="zTextbox" Width="460px"></asp:TextBox></td>
                        </tr>
                        <tr style="height: 24px">
                            <td style="padding-right: 10px; width: 110px; text-align: right">
                                HN :</td>
                            <td style="width: 140px">
                                <asp:TextBox ID="txtSearchHN" runat="server" CssClass="zTextbox" Width="100px"></asp:TextBox></td>
                            <td style="padding-right: 10px; width: 40px; text-align: right">
                                AN :</td>
                            <td style="width: 120px">
                                <asp:TextBox ID="txtSearchAN" runat="server" CssClass="zTextbox" Width="100px"></asp:TextBox></td>
                            <td align="right" style="padding-right: 10px; width: 40px">
                                VN :</td>
                            <td style="width: 120px">
                                <asp:TextBox ID="txtSearchVN" runat="server" CssClass="zTextbox" Width="100px"></asp:TextBox></td>
                            <td>
                            </td>
                        </tr>
                        <tr style="height:24px">
                            <td style="width:110px; text-align: right; padding-right:10px">
                                �ѹ���Ѵ����� :</td>
                            <td style="width:140px;">
                                <uc2:CalendarControl ID="ctlSearchPrintTime" runat="server" />
                            </td>
                            <td style="width:40px; text-align: right; padding-right:10px">
                                ���� :</td>
                            <td style="width:120px;">
                                <asp:DropDownList ID="cmbSearchMeal" runat="server" Width="106px">
                                    <asp:ListItem Value="" Text="������"></asp:ListItem> 
                                    <asp:ListItem Value="11" Text="���"></asp:ListItem> 
                                    <asp:ListItem Value="21" Text="��ҧ�ѹ"></asp:ListItem> 
                                    <asp:ListItem Value="31" Text="���"></asp:ListItem> 
                                </asp:DropDownList>
                            </td>
                            <td align="right" style="padding-right: 10px; width: 40px"></td>
                            <td style="width:120px;"></td>
                            <td>
                                <asp:ImageButton ID="imbSearch" runat="server" ImageUrl="~/Images/icn_find.png" ImageAlign="absMiddle" OnClick="imbSearch_Click" />
                                <asp:ImageButton ID="imbReset" runat="server" ImageUrl="~/Images/icn_back.png" ImageAlign="absMiddle" OnClick="imbReset_Click" />
                            </td>
                        </tr>
                    </table> 
                </fieldset> 
            </td>
        </tr>
        <tr>
            <td>
                <uc3:PageControl ID="pcTop" runat="server" OnPageChange="PageChange"  />
                <asp:GridView ID="gvMain" runat="server" AllowSorting="True" AutoGenerateColumns="False" CssClass="t_tablestyle1" CellPadding="0" 
                     OnRowDataBound="gvMain_RowDataBound" Width="100%">
                    <Columns>
                        <asp:BoundField DataField="ADMITPATIENT" HeaderText="ADMITPATIENT">
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
                                        <td style="width:170px; border-right:solid 1px #ebe9ed" align="center">�ͼ�����</td> 
                                        <td style="width:30px; border-right:solid 1px #ebe9ed" align="center">��ͧ</td> 
                                        <td style="width:30px; border-right:solid 1px #ebe9ed" align="center">��§</td> 
                                        <td style="width:70px; border-right:solid 1px #ebe9ed" align="center">HN</td> 
                                        <td style="width:70px; border-right:solid 1px #ebe9ed" align="center">AN</td> 
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
                                        <td style="width:30px; border-right:solid 1px #ebe9ed" align="center"><asp:CheckBox ID="chkSelect" runat="server" CssClass='<%# Eval("RANK").ToString() != "0" && Eval("ISTRANSFER").ToString() == "N" ? "" : "zHidden" %>'/></td> 
                                        <td style="width:170px; border-right:solid 1px #ebe9ed" align="left"><%# Eval("WARDNAME") %></td> 
                                        <td style="width:30px; border-right:solid 1px #ebe9ed" align="center"><%# Eval("ROOMNO") %></td> 
                                        <td style="width:30px; border-right:solid 1px #ebe9ed" align="center"><%# Eval("BEDNO") %></td> 
                                        <td style="width:70px; border-right:solid 1px #ebe9ed" align="center"><%# Eval("HN") %></td> 
                                        <td style="width:70px; border-right:solid 1px #ebe9ed" align="center"><%# Eval("AN") %></td> 
                                        <td style="width:250px; border-right:solid 1px #ebe9ed" align="left"><%# Eval("PATIENTNAME") %></td> 
                                        <td style="width:30px; border-right:solid 1px #ebe9ed" align="right"><%# Eval("AGE") %></td>  
                                        <td style="width:30px; border-right:solid 1px #ebe9ed" align="right"><%# Eval("WEIGHT") %></td>  
                                        <td style="width:30px; border-right:solid 1px #ebe9ed" align="right"><%# Eval("HEIGHT") %></td>  
                                        <td align="left"><%# Eval("BMI") %></td>  
                                    </tr>
                                    <tr style="height:1px">
                                        <td style="width:40px; border-right:solid 1px #ebe9ed" align="center"></td> 
                                        <td style="width:30px; border-right:solid 1px #ebe9ed" align="center"></td> 
                                        <td style="width:170px;" align="left"></td> 
                                        <td style="width:30px;" align="center"></td> 
                                        <td style="width:30px;" align="center"></td> 
                                        <td style="width:70px;" align="center"></td> 
                                        <td style="width:70px;" align="center"></td> 
                                        <td style="width:250px;" align="left"></td> 
                                        <td style="width:30px;" align="right"></td>  
                                        <td style="width:30px;" align="right"></td>  
                                        <td style="width:30px;" align="right"></td>  
                                        <td align="left"></td>  
                                    </tr>
                                    <tr style="height:20px">
                                        <td style="width:40px; border-right:solid 1px #ebe9ed" align="center"></td> 
                                        <td style="width:30px; border-right:solid 1px #ebe9ed" align="center"></td> 
                                        <td align="left" colspan="11">
                                            <table border="0" cellpadding="0" cellspacing="0" width="100%">
                                                <tr style="height:20px">
                                                    <td style="width:150px"><b>������ : </b><%# Eval("FOODTYPENAME") %></td>
                                                    <td style="width:130px"><b>��Դ : </b><%# Eval("FOODCATEGORYNAME") %></td>
                                                    <td style="width:250px"><b>�ӹǹ : </b><%# Eval("QTY") %></td>
                                                    <td><b>�ѹ-���ҷ��ѹ�֡ : </b><%# Eval("MEDORDERDATE", "{0:dd/MM/yyyy HH:mm:ss}") %></td>
                                                </tr>
                                                <tr style="height:20px" class='<%# Eval("CONTROL").ToString() == "" && Eval("LIMIT").ToString() == "" && Eval("INCREASE").ToString() =="" ? "zHidden" : ""  %>' >
                                                    <td colspan="2"><%# Eval("CONTROL").ToString() != "" ? "<b>�Ǻ��� : </b>" +  Eval("CONTROL") : "" %></td>
                                                    <td style="width:250px"> <%# Eval("LIMIT").ToString() != "" ? "<b>�ӡѴ����ҳ : </b>" + Eval("LIMIT") : "" %></td>
                                                    <td><%# Eval("INCREASE").ToString() != "" ? "<b>���������� : </b>" + Eval("INCREASE") : "" %></td>
                                                </tr>
                                                <tr style="height:20px" >
                                                    <td colspan="2"><%# Eval("ABSTAIN").ToString()!= "" ? "<b>����÷�觴 : </b>" + Eval("ABSTAIN") : "" %></td>
                                                    <td style="width:250px"><%# Eval("NEED").ToString() != "" ? "<b>�Ѻ੾�� : </b>" + Eval("NEED") : "" %></td>
                                                    <td><b>�ѹ-���ҷ�� Register : </b><%# Eval("REGISTERDATE", "{0:dd/MM/yyyy HH:mm:ss}") %></td>
                                                </tr>
                                                <tr style="height:20px">
                                                    <td colspan="2"><b>�����˵� : </b><%# Eval("REMARKS") %></td>
                                                    <td style="width:250px"><b>ʶҹ� : </b><span style="color:Red"><%# Eval("STATUS") %></span></td>
                                                    <td><b>�ѹ����� : </b><%# Eval("DELIVERYTIME","{0:dd/MM/yyyy HH:mm:ss}")%></td>
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
</asp:Content>