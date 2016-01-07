<%@ Page Language="C#" MasterPageFile="~/Templates/Page1.master" AutoEventWireup="true" CodeFile="OrderFoodSearch.aspx.cs" Inherits="App_Order_Transaction_OrderFoodSearch" Title="SHND : Transaction - Food Order for Patient" %>
<%@ Register Src="../../Templates/CalendarControl.ascx" TagName="CalendarControl" TagPrefix="uc3" %>
<%@ Register Src="../../Templates/PageControl.ascx" TagName="PageControl" TagPrefix="uc2" %>
<%@ Register Src="../../Templates/ToolBarItemCtl.ascx" TagName="ToolBarItemCtl" TagPrefix="uc1" %>
<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" Runat="Server">
    <table border="0" cellpadding="0" cellspacing="0" width="100%">
        <tr>
            <td class="headtext">
                �������ü�����</td>
        </tr>
        <tr>
            <td style="height:15px">
            </td>
        </tr>
        <tr>
            <td>
                <fieldset style="padding:15px;">
                    <legend style="font-weight:bold">����</legend>
                    <table border="0" cellspacing="0" cellpadding="0" width="900">
                        <tr style="height:15px">
                            <td colspan="5"></td>
                        </tr>
                        <tr style="height:24px">
                            <td style="padding-right:10px; width:130px; text-align:right">
                                �ͼ����� :</td>
                            <td style="width:150px">
                                <asp:DropDownList ID="cmbSearchWard" runat="server" CssClass="zComboBox" Width="156px"></asp:DropDownList>
                                <asp:DropDownList ID="cmbWardDefault" runat="server" CssClass="zComboBox" Visible="false" Width="156px"></asp:DropDownList>
                            </td>
                            <td style="width:30px; text-align:center"></td>
                            <td colspan="2">
                                <asp:TextBox ID="txtSearchWardName" runat="server" Width="100px" MaxLength="20" Visible="false" CssClass="zTextbox"></asp:TextBox>
                                 
                            </td>
                        </tr>
                        <tr style="height:24px">
                            <td style="padding-right:10px; width:130px; text-align:right">
                                �ѹ��� Admit :</td>
                            <td style="width:150px">
                                <uc3:CalendarControl ID="ctlSearchAdmitDateFrom" runat="server" />
                            </td>
                            <td style="width:30px; text-align:center">
                                �֧</td>
                            <td style="width:150px">
                                <uc3:CalendarControl ID="ctlSearchAdmitDateTo" runat="server" />
                            </td>
                            <td style="width:440px"></td>
                        </tr>

                        <tr style="height:24px">
                            <td style="padding-right:10px; width:130px; text-align:right">
                                Encounter ���� AN :</td>
                            <td style="width:150px">
                                <asp:TextBox ID="txtSearchAN" runat="server" Width="100px" MaxLength="20" CssClass="zTextbox"></asp:TextBox>
                            </td>
                            <td style="width:30px; text-align:center">
                                HN :</td>
                            <td style="width:150px">
                                <asp:TextBox ID="txtSearchHN" runat="server" Width="100px" MaxLength="20" CssClass="zTextbox"></asp:TextBox>
                            </td>
                            <td style="width:30px; text-align:center">
                                <asp:CheckBox ID="chkIsAdmit" runat="server" Text="੾�м����·��ѡ�ѡ��� þ." Visible="false" />
                            </td>
                        </tr>
                        <tr style="height: 24px">
                            <td style="padding-right: 10px; width: 130px; text-align: right">
                                ���ͼ����� :</td>
                            <td colspan="3">
                                <asp:TextBox ID="txtSearchPatientName" runat="server" CssClass="zTextbox" MaxLength="20" Width="336px"></asp:TextBox></td>
                            <td>
                            </td>
                        </tr>
                        <tr style="height:24px">
                            <td style="padding-right:10px; width:130px; text-align:right">
                                ʶҹС���������� :</td>
                            <td style="width:150px">
                                <asp:DropDownList ID="cmbSearchStatusFrom" runat="server" CssClass="zComboBox" Width="156px">
                                </asp:DropDownList></td>
                            <td style="width:30px; text-align:center">
                                �֧</td>
                            <td style="width:150px">
                                <asp:DropDownList ID="cmbSearchStatusTo" runat="server" CssClass="zComboBox" Width="156px">
                                </asp:DropDownList></td>
                            <td>
                                &nbsp;&nbsp;
                                <asp:ImageButton ID="imbSearch" runat="server" ImageAlign="AbsMiddle" ImageUrl="~/Images/icn_find.png" OnClick="imbSearch_Click" />&nbsp;
                                <asp:ImageButton ID="imbReset" runat="server" Visible="false" ImageAlign="AbsMiddle" ImageUrl="~/Images/icn_back.png" ToolTip="�ʴ�������" OnClick="imbReset_Click" />&nbsp;
                                <asp:ImageButton ID="imbPrint" runat="server" ImageAlign="AbsMiddle" ImageUrl="~/Images/icn_print.png" ToolTip="�����" /></td>
                        </tr>
                    </table>
                </fieldset>
            </td>
        </tr>
        <tr>
            <td style="height:20px">
                <asp:TextBox ID="txhSortField" runat="server" Visible="False" Width="15px"></asp:TextBox>
                <asp:TextBox ID="txhSortDir" runat="server" Visible="False" Width="15px"></asp:TextBox>
                <asp:Label ID="lblRed" Width="137px" runat="server" Text="��ᴧ ��� �ѧ�����������" BackColor="Coral" Font-Bold="True"></asp:Label>
                <asp:Label ID="lblYellow" Width="231px" runat="server" Text="������ͧ ��� �����š�����������������ó�" BackColor="Gold" Font-Bold="True"></asp:Label>
                <asp:Label ID="lblGreen" Width="185px" runat="server" Text="������ ��� �����������º��������" BackColor="LightGreen" Font-Bold="True"></asp:Label>
                <asp:Label ID="lblWhite" Width="168px" runat="server" Text="�բ�� ��� Register ���������" BackColor="White" Font-Bold="True"></asp:Label>
                <asp:Label ID="lblNpo" Width="138px" runat="server" Text="NPO ��� ����� �������" ForeColor="Red" BackColor="LightGreen" Font-Bold="True"></asp:Label>
                </td>
        </tr>
        <tr>
            <td style="100%">
                <uc2:PageControl ID="pcTop" runat="server" OnPageChange="PageChange"/>
                <asp:GridView ID="gvMain" runat="server" AllowSorting="True" AutoGenerateColumns="False" CssClass="t_tablestyle" OnRowDataBound="gvMain_RowDataBound" 
                    OnSorting="gvMain_Sorting" AllowPaging="True" PageSize="100" Width="100%">
                    <Columns>
                        <asp:BoundField DataField="LOID" HeaderText="LOID">
                            <ControlStyle CssClass="zHidden" />
                            <FooterStyle CssClass="zHidden" />
                            <HeaderStyle CssClass="zHidden" />
                            <ItemStyle CssClass="zHidden" />
                        </asp:BoundField>
                        <asp:BoundField DataField="REMARK" >
                            <HeaderStyle Width="30px" />
                            <ItemStyle HorizontalAlign="Center" Width="30px" CssClass="zRemark" />
                        </asp:BoundField>
                        <asp:TemplateField HeaderText="�ӴѺ" SortExpression="DEFAULT">
                            <HeaderStyle CssClass="zHidden" Width="50px" />
                            <ItemStyle CssClass="zHidden" HorizontalAlign="Center" Width="50px" Height="20px" />
                        </asp:TemplateField>
                        <asp:BoundField DataField="ADMITDATE" HeaderText="�ѹ��� Admit" SortExpression="ADMITDATE" HtmlEncode="false" DataFormatString="{0:dd/MM/yyyy}">
                            <HeaderStyle Width="110px" />
                            <ItemStyle HorizontalAlign="Center" Width="110px" />
                        </asp:BoundField>
                        <asp:BoundField DataField="WARDNAME" HeaderText="�ͼ�����" SortExpression="WARDNAME">
                            <HeaderStyle Width="120px" />
                            <ItemStyle Width="120px" />
                        </asp:BoundField>
                        <asp:BoundField DataField="ROOMNO" HeaderText="��ͧ" SortExpression="ROOMNO">
                            <HeaderStyle Width="50px" />
                            <ItemStyle HorizontalAlign="center" Width="50px" />
                        </asp:BoundField>
                        <asp:BoundField DataField="BEDNO" HeaderText="��§" SortExpression="BEDNO">
                            <HeaderStyle Width="50px" />
                            <ItemStyle HorizontalAlign="center" Width="50px" />
                        </asp:BoundField>
                        <asp:BoundField DataField="HN" HeaderText="HN" SortExpression="HN">
                            <HeaderStyle Width="70px" />
                            <ItemStyle HorizontalAlign="center" Width="70px" />
                        </asp:BoundField>
                        <asp:TemplateField HeaderText="Encounter<br>���� AN" SortExpression="AN">
                            <ItemTemplate>
                                <asp:LinkButton ID="lnkAN" runat="server" Text='<%# Bind("AN") %>' OnClick="lnkAN_Click" CommandArgument='<%# Bind("LOID")  %>'></asp:LinkButton>
                            </ItemTemplate>
                            <HeaderStyle Width="70px" />
                            <ItemStyle HorizontalAlign="center" Width="70px" />
                        </asp:TemplateField>
                        <asp:TemplateField HeaderText="���ͼ�����" SortExpression="PATIENTNAME">
                            <ItemTemplate>
                                <%# Eval("PATIENTNAME") %>, <%# Eval("TITLENAME")%>
                            </ItemTemplate>
                        </asp:TemplateField>
                        <asp:BoundField DataField="BIRTHDATE" HeaderText="�ѹ��͹���Դ" SortExpression="BIRTHDATE" HtmlEncode="false" DataFormatString="{0:dd/MM/yyyy}">
                            <HeaderStyle Width="80px" />
                            <ItemStyle HorizontalAlign="Center" Width="80px" />
                        </asp:BoundField>
                        <asp:BoundField DataField="AGE" HeaderText="����">
                            <HeaderStyle Width="50px" />
                            <ItemStyle HorizontalAlign="Center" Width="50px" />
                        </asp:BoundField>
                        <asp:BoundField DataField="STATUSNAME" HeaderText="ʶҹ�" SortExpression="STATUSNAME">
                            <HeaderStyle HorizontalAlign="Center" Width="100px" />
                            <ItemStyle Width="100px" />
                        </asp:BoundField>
                        <asp:BoundField DataField="ISRELATIVE" HeaderText="������������Ѻ�ҵ�">
                            <HeaderStyle Width="80px" />
                            <ItemStyle HorizontalAlign="Center" Width="80px" />
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
</asp:Content>