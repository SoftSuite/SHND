<%@ Control Language="C#" AutoEventWireup="true" CodeFile="ChangOrderNewCtl.ascx.cs" Inherits="App_Prepare_Transaction_ChangeOrder_ChangOrderNewCtl" %>
<asp:Repeater ID="rptChangeOrderNew" runat="server" >
            <HeaderTemplate>
                 <table border="1" cellspacing="0"  style="border-collapse: collapse; border-color:White ">
            </HeaderTemplate>
            <ItemTemplate> 
                    <tr  style=" border-color:#ccccff">
                        <td rowspan="6" style="width: 35px; vertical-align:middle;  background-color:White ;"  >
                        NEW</td>          
                    </tr>
                    <tr style=" border-color:#ccccff" >
                            <td rowspan="6" style=" width: 40px; vertical-align :middle ; background-color:White;   ">
                            <asp:CheckBox ID="chkNew1" runat="server" /></td>          
                    </tr>
                    <tr style=" border-color:#ccccff">
                        <td style="height: 25px; width: 210px; vertical-align :top; background-color:White " colspan="2" >
                            ������&nbsp;:&nbsp;<%#Eval("FOODTYPENAME_NEW")%></td>
                        <td  style="height: 25px; width: 150px; vertical-align :top;  background-color:White ">
                            ��Դ&nbsp;:&nbsp;<%#Eval("FOODCATEGORYNAME_NEW")%></td>
                        <td  style="height: 25px; width: 200px; vertical-align :top; background-color:White " >
                            �ӹǹ&nbsp;:&nbsp;<%#Eval("QTY_NEW")%></td>
                        <td colspan="2" style="height: 25px; width: 300px; vertical-align :top ;  background-color:White" >
                            �ѹ/���ҷ��ѹ�֡&nbsp;:&nbsp;<%#Eval("ORDERDATE_NEW")%></td>
                    </tr>
                    <tr style=" border-color:#ccccff">
                        <td style="height: 25px; width: 210px;  vertical-align :top; background-color:White " colspan="3" >
                            �Ǻ���&nbsp;:&nbsp;<%#Eval("CONTROL_NEW")%></td>
                        <td  style="height: 25px; width: 200px; vertical-align :top ; background-color:White" >
                            �ӡѴ����ҳ&nbsp;:&nbsp;<%#Eval("LIMIT_NEW")%></td>
                        <td colspan="2" style="height: 25px; width: 300px; vertical-align :top ; background-color:White" >
                            ����������&nbsp;:&nbsp;<%#Eval("INCREASE_NEW")%></td>
                    </tr>
                     <tr style=" border-color:#ccccff">
                        <td style="height: 25px; width: 210px;  vertical-align :top; background-color:White" colspan="3" >
                            ����÷�觴&nbsp;:&nbsp;<%#Eval("ABSTAIN_NEW")%></td>
                        <td  style="height: 25px; width: 200px; vertical-align :top; background-color:White "  colspan ="3">
                            �Ѻ੾��&nbsp;:&nbsp;<%#Eval("NEED_NEW")%></td>
                    </tr>
                     <tr style=" border-color:#ccccff">
                        <td style="height: 25px; width: 210px;  vertical-align :top; background-color:White" colspan="3"  >
                            �����˵�&nbsp;:&nbsp;<%#Eval("REMARKS_NEW")%></td>
                        <td  style="height: 25px; width: 200px; vertical-align :top; background-color:White " colspan="3" >
                            ʶҹ�&nbsp;:&nbsp;<%#Eval("STATUS_NEW")%></td>
                    </tr>
                    <tr>
                         <td   style=" height: 25px;  width: 200px; background-color:Scrollbar;  display:none; vertical-align :top" colspan = "6" >
                         <asp:TextBox ID="txtOrderMedID1" runat="server" Text = '<%# Bind("ORDERMEDID") %>' ></asp:TextBox></td>                
                    </tr>
                    <tr>
                         <td   style=" height: 25px;  width: 200px; background-color:Scrollbar;  display:none; vertical-align :top" colspan = "6" >
                         <asp:TextBox ID="txtRefMedTable1" runat="server" Text = '<%# Bind("REFMEDTABLE") %>' ></asp:TextBox></td>                
                    </tr>

                    <tr>
                         <td   style=" height: 25px;  width: 200px; background-color:Scrollbar;  display:none; vertical-align :top" colspan = "6" >
                         <asp:TextBox ID="txtOrderNonMedID1" runat="server" Text = '<%# Bind("ORDERNONMEDID") %>' ></asp:TextBox></td>                
                    </tr>                
            </ItemTemplate>
            <AlternatingItemTemplate>

                    <tr >
                            <td rowspan="6" style=" width: 35px; vertical-align :middle ;  background-color:Scrollbar" >
                            NEW</td>          
                    </tr>
                    <tr  >
                            <td rowspan="6" style="width:40px; vertical-align :middle ;   background-color:Scrollbar" >
                            <asp:CheckBox ID="chkNew2" runat="server" /></td>          
                    </tr>
                    <tr >
                        <td style="height: 25px; width: 210px; background-color:Scrollbar; vertical-align :top " colspan="2" >
                            ������&nbsp;:&nbsp;<%#Eval("FOODTYPENAME_NEW")%></td>
                        <td  style="height: 25px; width: 150px; background-color:Scrollbar;  vertical-align :top" >
                            ��Դ&nbsp;:&nbsp;<%#Eval("FOODCATEGORYNAME_NEW")%></td>
                        <td  style="height: 25px; width: 200px; background-color:Scrollbar;  vertical-align :top" >
                            �ӹǹ&nbsp;:&nbsp;<%#Eval("QTY_NEW")%></td>
                        <td colspan="2" style="height: 25px; width: 300px; background-color:Scrollbar;  vertical-align :top" >
                            �ѹ/���ҷ��ѹ�֡&nbsp;:&nbsp;<%#Eval("ORDERDATE_NEW")%></td>
                    </tr>
                    <tr >
                        <td style="height: 25px; width: 210px; background-color:Scrollbar; vertical-align :top"  colspan="3" >
                            �Ǻ���&nbsp;:&nbsp;<%#Eval("CONTROL_NEW")%></td>
                        <td  style="height: 25px; width: 200px; background-color:Scrollbar;  vertical-align :top" >
                            �ӡѴ����ҳ&nbsp;:&nbsp;<%#Eval("LIMIT_NEW")%></td>
                        <td colspan="2" style="height: 25px; width: 300px; background-color:Scrollbar;  vertical-align :top" >
                            ����������&nbsp;:&nbsp;<%#Eval("INCREASE_NEW")%></td>
                    </tr>
                     <tr >
                        <td style="height: 25px; width: 210px; background-color:Scrollbar; vertical-align :top" colspan="3" >
                            ����÷�觴&nbsp;:&nbsp;<%#Eval("ABSTAIN_NEW")%></td>
                        <td  style="height: 25px; width: 200px; background-color:Scrollbar;  vertical-align :top" colspan="3" >
                            �Ѻ੾��&nbsp;:&nbsp;<%#Eval("NEED_NEW")%></td>
                    </tr>
                     <tr >
                        <td style="height: 25px; width: 210px; background-color:Scrollbar; vertical-align :top" colspan="3" >
                            �����˵�&nbsp;:&nbsp;<%#Eval("REMARKS_NEW")%></td>
                        <td  style="height: 25px; width: 200px; background-color:Scrollbar;  vertical-align :top" colspan = "3" >
                            ʶҹ�&nbsp;:&nbsp;<%#Eval("STATUS_NEW")%></td>
                    </tr>
                    <tr>
                         <td   style=" height: 25px;  width: 200px; background-color:Scrollbar;  display:none; vertical-align :top" colspan = "6" >
                         <asp:TextBox ID="txtOrderMedID2" runat="server" Text = '<%# Bind("ORDERMEDID") %>' ></asp:TextBox></td>                
                    </tr>
                    <tr>
                         <td   style=" height: 25px;  width: 200px; background-color:Scrollbar;  display:none; vertical-align :top" colspan = "6" >
                         <asp:TextBox ID="txtRefMedTable2" runat="server" Text = '<%# Bind("REFMEDTABLE") %>' ></asp:TextBox></td>                
                    </tr>

                    <tr>
                         <td   style=" height: 25px;  width: 200px; background-color:Scrollbar;  display:none; vertical-align :top" colspan = "6" >
                         <asp:TextBox ID="txtOrderNonMedID2" runat="server" Text = '<%# Bind("ORDERNONMEDID") %>' ></asp:TextBox></td>                
                    </tr>                

            </AlternatingItemTemplate>
            <FooterTemplate>
                </table>

            </FooterTemplate>
        </asp:Repeater>