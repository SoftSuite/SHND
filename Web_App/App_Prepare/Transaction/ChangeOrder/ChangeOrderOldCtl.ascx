<%@ Control Language="C#" AutoEventWireup="true" CodeFile="ChangeOrderOldCtl.ascx.cs" Inherits="App_Prepare_Transaction_ChangeOrder_ChangeOrderOldCtl" %>
<asp:Repeater ID="rptChangeOrderOld" runat="server" >
            <HeaderTemplate>
                 <table border="1" cellspacing="0"  style="border-collapse: collapse; border-color:White ">
            </HeaderTemplate>
            <ItemTemplate> 
                    <tr style=" border-color:#ccccff">
                        <td rowspan="6" style="width: 35px; vertical-align:middle ;background-color:White"  >
                        OLD</td>          
                    </tr>
                    <tr style=" border-color:#ccccff">
                    <td rowspan="6" style=" width: 35px; vertical-align :middle ;    background-color:White">
                    </td>          
                    </tr>
                    <tr style=" border-color:#ccccff">
                        <td style="height: 25px; width: 210px; vertical-align :top; background-color:White " colspan="2" >
                            ประเภท&nbsp;:&nbsp;<%#Eval("FOODTYPENAME")%></td>
                        <td  style="height: 25px; width: 150px; vertical-align :top;  background-color:White ">
                            ชนิด&nbsp;:&nbsp;<%#Eval("FOODCATEGORYNAME")%></td>
                        <td  style="height: 25px; width: 200px; vertical-align :top; background-color:White " >
                            จำนวน&nbsp;:&nbsp;<%#Eval("QTY")%></td>
                        <td colspan="2" style="height: 25px; width: 300px; vertical-align :top ;  background-color:White" >
                            วัน/เวลาที่บันทึก&nbsp;:&nbsp;<%#Eval("ORDERDATE")%></td>
                    </tr>
                    <tr style=" border-color:#ccccff">
                        <td style="height: 25px; width: 210px;  vertical-align :top; background-color:White " colspan="3" >
                            ควบคุม&nbsp;:&nbsp;<%#Eval("CONTROL")%></td>
                        <td  style="height: 25px; width: 200px; vertical-align :top ; background-color:White" >
                            จำกัดปริมาณ&nbsp;:&nbsp;<%#Eval("LIMIT")%></td>
                        <td colspan="2" style="height: 25px; width: 300px; vertical-align :top ; background-color:White" >
                            อาหารเสริม&nbsp;:&nbsp;<%#Eval("INCREASE")%></td>
                    </tr>
                     <tr style=" border-color:#ccccff">
                        <td style="height: 25px; width: 210px;  vertical-align :top; background-color:White" colspan="3" >
                            อาหารที่งด&nbsp;:&nbsp;<%#Eval("ABSTAIN")%></td>
                        <td  style="height: 25px; width: 200px; vertical-align :top; background-color:White "  colspan ="3">
                            รับเฉพาะ&nbsp;:&nbsp;<%#Eval("NEED")%></td>
                    </tr>
                     <tr style=" border-color:#ccccff">
                        <td style="height: 25px; width: 210px;  vertical-align :top; background-color:White" colspan="3"  >
                            หมายเหตุ&nbsp;:&nbsp;<%#Eval("REMARKS")%></td>
                        <td  style="height: 25px; width: 200px; vertical-align :top; background-color:White " colspan="3" >
                            สถานะ&nbsp;:&nbsp;<%#Eval("STATUS")%></td>
                    </tr>

            </ItemTemplate>
            <AlternatingItemTemplate>

                    <tr >
                            <td rowspan="6" style="width: 35px; vertical-align :middle ;  text-align :center;background-color:Scrollbar" >
                            OLD</td>          
                    </tr>
                    <tr  >
                            <td rowspan="6" style="width:35px; vertical-align :middle ;  text-align :center; background-color:Scrollbar" >
                            </td>          
                    </tr>
                    <tr >
                        <td style="height: 25px; width: 210px; background-color:Scrollbar; vertical-align :top " colspan="2" >
                            ประเภท&nbsp;:&nbsp;<%#Eval("FOODTYPENAME")%></td>
                        <td  style="height: 25px; width: 150px; background-color:Scrollbar;  vertical-align :top" >
                            ชนิด&nbsp;:&nbsp;<%#Eval("FOODCATEGORYNAME")%></td>
                        <td  style="height: 25px; width: 200px; background-color:Scrollbar;  vertical-align :top" >
                            จำนวน&nbsp;:&nbsp;<%#Eval("QTY")%></td>
                        <td colspan="2" style="height: 25px; width: 300px; background-color:Scrollbar;  vertical-align :top" >
                            วัน/เวลาที่บันทึก&nbsp;:&nbsp;<%#Eval("ORDERDATE")%></td>
                    </tr>
                    <tr >
                        <td style="height: 25px; width: 210px; background-color:Scrollbar; vertical-align :top"  colspan="3" >
                            ควบคุม&nbsp;:&nbsp;<%#Eval("CONTROL")%></td>
                        <td  style="height: 25px; width: 200px; background-color:Scrollbar;  vertical-align :top" >
                            จำกัดปริมาณ&nbsp;:&nbsp;<%#Eval("LIMIT")%></td>
                        <td colspan="2" style="height: 25px; width: 300px; background-color:Scrollbar;  vertical-align :top" >
                            อาหารเสริม&nbsp;:&nbsp;<%#Eval("INCREASE")%></td>
                    </tr>
                     <tr >
                        <td style="height: 25px; width: 210px; background-color:Scrollbar; vertical-align :top" colspan="3" >
                            อาหารที่งด&nbsp;:&nbsp;<%#Eval("ABSTAIN")%></td>
                        <td  style="height: 25px; width: 200px; background-color:Scrollbar;  vertical-align :top" colspan="3" >
                            รับเฉพาะ&nbsp;:&nbsp;<%#Eval("NEED")%></td>
                    </tr>
                     <tr >
                        <td style="height: 25px; width: 210px; background-color:Scrollbar; vertical-align :top" colspan="3" >
                            หมายเหตุ&nbsp;:&nbsp;<%#Eval("REMARKS")%></td>
                        <td  style="height: 25px; width: 200px; background-color:Scrollbar;  vertical-align :top" colspan = "3" >
                            สถานะ&nbsp;:&nbsp;<%#Eval("STATUS")%></td>
                    </tr>

            </AlternatingItemTemplate>
            <FooterTemplate>
                <table>
                        <tr>
                             <td   style=" height: 25px;  width: 200px; background-color:Scrollbar;  display:none; vertical-align :top" colspan = "6" >
                             <asp:TextBox ID="txtOrderMedID" runat="server" Text = '<%# Bind("ORDERMEDID") %>' ></asp:TextBox></td>                
                        </tr>
                        <tr>
                             <td   style=" height: 25px;  width: 200px; background-color:Scrollbar;  display:none; vertical-align :top" colspan = "6" >
                             <asp:TextBox ID="txtRefMedTable" runat="server" Text = '<%# Bind("REFMEDTABLE") %>' ></asp:TextBox></td>                
                        </tr>

                        <tr>
                             <td   style=" height: 25px;  width: 200px; background-color:Scrollbar;  display:none; vertical-align :top" colspan = "6" >
                             <asp:TextBox ID="txtOrderNonMedID" runat="server" Text = '<%# Bind("ORDERNONMEDID") %>' ></asp:TextBox></td>                
                        </tr>

                </table>

            </FooterTemplate>
        </asp:Repeater>