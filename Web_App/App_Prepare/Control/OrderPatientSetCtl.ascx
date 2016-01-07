<%@ Control Language="C#" AutoEventWireup="true" CodeFile="OrderPatientSetCtl.ascx.cs" Inherits="App_Prepare_Control_OrderPatientSetCtl" %>
<asp:Repeater ID="rptOrderPatientSet" runat="server" >
            <HeaderTemplate>
                 <table border="1" cellspacing="0" bordercolor="white" style="border-collapse: collapse;">
            </HeaderTemplate>
            <ItemTemplate> 
                    <tr bordercolor="#ccccff">
                        <td align="center"  style="width: 40px; height: 23px; vertical-align :top;" bordercolor="White"  >
                        </td>
                        <td style="height: 23px; width: 210px; vertical-align :top; " bgcolor="white"  colspan="2" >
                            ������&nbsp;:&nbsp;<%#Eval("FOODTYPENAME")%></td>
                        <td  style="height: 23px; width: 150px; vertical-align :top;  " bgcolor="white">
                            ��Դ&nbsp;:&nbsp;<%#Eval("FOODCATEGORYNAME")%></td>
                        <td  style="height: 23px; width: 200px; vertical-align :top; " bgcolor="white">
                            �ӹǹ&nbsp;:&nbsp;<%#Eval("QTY")%></td>
                        <td colspan="2" style="height: 23px; width: 300px; vertical-align :top ; " bgcolor="white">
                            ���ҷ��ѹ�֡&nbsp;:&nbsp;<%#Eval("ORDERTIME")%></td>
                    </tr>
                    <tr bordercolor="#ccccff">
                        <td align="center"  style="width: 40px; height: 23px; vertical-align :top;" bordercolor="White">
                        </td>
                        <td style="height: 23px; width: 210px;  vertical-align :top; " colspan="3" bgcolor="white">
                            �Ǻ���&nbsp;:&nbsp;<%#Eval("CONTROL")%></td>
                        <td  style="height: 23px; width: 200px; vertical-align :top ; " bgcolor="white">
                            �ӡѴ����ҳ&nbsp;:&nbsp;<%#Eval("LIMIT")%></td>
                        <td colspan="2" style="height: 23px; width: 300px; vertical-align :top ; " bgcolor="white">
                            ����������&nbsp;:&nbsp;<%#Eval("INCREASE")%></td>
                    </tr>
                     <tr bordercolor="#ccccff">
                        <td align="center"  style="width: 40px; height: 23px; vertical-align :top; " bordercolor="White">
                        </td>
                        <td style="height: 23px; width: 210px;  vertical-align :top; " colspan="3" bgcolor="white">
                            ����÷�觴&nbsp;:&nbsp;<%#Eval("ABSTAIN")%></td>
                        <td  style="height: 23px; width: 200px; vertical-align :top; " bgcolor="white" colspan ="3">
                            �Ѻ੾��&nbsp;:&nbsp;<%#Eval("NEED")%></td>
                    </tr>
                     <tr bordercolor="#ccccff">
                        <td align="center"  style="width: 40px; height: 23px; vertical-align :top; " bordercolor="White">
                        </td>
                        <td style="height: 23px; width: 210px;  vertical-align :top; " colspan="3" bgcolor="white" >
                            �����˵�&nbsp;:&nbsp;<%#Eval("REMARKS")%></td>
                        <td  style="height: 23px; width: 200px; vertical-align :top; "  bgcolor="white" colspan ="3">
                            ʶҹ�&nbsp;:&nbsp;<%#Eval("STATUSNAME")%></td>
                    </tr>
                   
            </ItemTemplate>
            <AlternatingItemTemplate>
                <tr >
                        <td align="center"  style="width: 40px; height: 23px; border-bottom-color:White; border-right-color:White">
                        </td>
                        <td style="height: 23px; width: 210px; background-color:Scrollbar; vertical-align :top " colspan="2" >
                            ������&nbsp;:&nbsp;<%#Eval("FOODTYPENAME")%></td>
                        <td  style="height: 23px; width: 150px; background-color:Scrollbar;  vertical-align :top" >
                            ��Դ&nbsp;:&nbsp;<%#Eval("FOODCATEGORYNAME")%></td>
                        <td  style="height: 23px; width: 200px; background-color:Scrollbar;  vertical-align :top" >
                            �ӹǹ&nbsp;:&nbsp;<%#Eval("QTY")%></td>
                        <td colspan="2" style="height: 23px; width: 300px; background-color:Scrollbar;  vertical-align :top" >
                            ���ҷ��ѹ�֡&nbsp;:&nbsp;<%#Eval("ORDERTIME")%></td>
                    </tr>
                    <tr >
                        <td align="center"  style="width: 40px; height: 23px; border-bottom-color:White; border-right-color:White">
                        </td>
                        <td style="height: 23px; width: 210px; background-color:Scrollbar; vertical-align :top"  colspan="3" >
                            �Ǻ���&nbsp;:&nbsp;<%#Eval("CONTROL")%></td>
                        <td  style="height: 23px; width: 200px; background-color:Scrollbar;  vertical-align :top" >
                            �ӡѴ����ҳ&nbsp;:&nbsp;<%#Eval("LIMIT")%></td>
                        <td colspan="2" style="height: 23px; width: 300px; background-color:Scrollbar;  vertical-align :top" >
                            ����������&nbsp;:&nbsp;<%#Eval("INCREASE")%></td>
                    </tr>
                     <tr >
                        <td align="center"  style="width: 40px; height: 23px; border-bottom-color:White; border-right-color:White">
                        </td>
                        <td style="height: 23px; width: 210px; background-color:Scrollbar; vertical-align :top" colspan="3" >
                            ����÷�觴&nbsp;:&nbsp;<%#Eval("ABSTAIN")%></td>
                        <td  style="height: 23px; width: 200px; background-color:Scrollbar;  vertical-align :top" colspan="3" >
                            �Ѻ੾��&nbsp;:&nbsp;<%#Eval("NEED")%></td>
                    </tr>
                     <tr >
                        <td align="center"  style="width: 40px; height: 23px; vertical-align :top " >
                        </td>
                        <td style="height: 23px; width: 210px; background-color:Scrollbar; vertical-align :top" colspan="3" >
                            �����˵�&nbsp;:&nbsp;<%#Eval("REMARKS")%></td>
                        <td  style="height: 23px; width: 200px; background-color:Scrollbar;  vertical-align :top" colspan = "3" >
                            ʶҹ�&nbsp;:&nbsp;<span style="color:Red"><%# Eval("STATUSNAME") %></span></td>
                    </tr>
            </AlternatingItemTemplate>
            
            <FooterTemplate>
                </table>
            </FooterTemplate>
        </asp:Repeater>
