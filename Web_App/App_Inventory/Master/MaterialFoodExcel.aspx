<%@ Page Language="C#" AutoEventWireup="true" CodeFile="MaterialFoodExcel.aspx.cs" Inherits="App_Inventory_Master_MaterialFoodExcel" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml" >
<head runat="server">
    <title>SHND : Excel - Material Food</title>
</head>
<body>
    <form id="form1" runat="server">
                <asp:GridView ID="gvMain" runat="server" AutoGenerateColumns="False">
                    <Columns>
                        <asp:BoundField DataField="MATERIALCODE" HeaderText="รหัสวัสดุ">
                            <HeaderStyle HorizontalAlign="Center" Width="80px" />
                            <ItemStyle HorizontalAlign="center" Width="80px" />
                        </asp:BoundField>
                        <asp:BoundField DataField="SAPCODE" HeaderText="รหัส SAP">
                            <HeaderStyle HorizontalAlign="Center" Width="80px" />
                            <ItemStyle HorizontalAlign="center" Width="80px" />
                        </asp:BoundField>
                        <asp:BoundField DataField="MATERIALNAME" HeaderText="ชื่อวัสดุ" SortExpression="MATERIALNAME">
                            <HeaderStyle HorizontalAlign="Center" Width="200px" />
                            <ItemStyle HorizontalAlign="center" Width="200px" />
                        </asp:BoundField>
                        <asp:BoundField DataField="CLASSNAME" HeaderText="หมวด" SortExpression="CLASSNAME">
                            <HeaderStyle HorizontalAlign="Center" Width="150px" />
                            <ItemStyle Width="150px" />
                        </asp:BoundField>
                        <asp:BoundField DataField="GROUPNAME" HeaderText="ประเภท" SortExpression="GROUPNAME">
                            <HeaderStyle HorizontalAlign="Center" Width="120px" />
                            <ItemStyle Width="120px" />
                        </asp:BoundField>
                        <asp:BoundField DataField="UNITNAME" HeaderText="หน่วยนับ" >
                            <HeaderStyle HorizontalAlign="Center" Width="90px" />
                            <ItemStyle Width="90px" />
                        </asp:BoundField>
                        <asp:BoundField DataField="COST" HeaderText="ราคาทุน" HtmlEncode="False" DataFormatString="{0:##0.00}">
                            <HeaderStyle HorizontalAlign="Center" Width="90px" />
                            <ItemStyle HorizontalAlign="Right" Width="10px" />
                        </asp:BoundField>
                        <asp:BoundField DataField="PRICE" HeaderText="ราคาขาย" HtmlEncode="False" DataFormatString="{0:##0.00}">
                            <HeaderStyle HorizontalAlign="Center" Width="90px" />
                            <ItemStyle HorizontalAlign="Right" Width="100px" />
                        </asp:BoundField>
                        <asp:BoundField DataField="SPEC" HeaderText="Spec" >
                            <HeaderStyle HorizontalAlign="Center" Width="90px" />
                            <ItemStyle Width="300px" />
                        </asp:BoundField>
                        <asp:BoundField DataField="ACTIVENAME" HeaderText="การใช้งาน" >
                            <HeaderStyle HorizontalAlign="Center" Width="90px" />
                            <ItemStyle HorizontalAlign="Center" Width="90px" />
                        </asp:BoundField>
                    </Columns>
                    <PagerSettings Visible="False" />
                </asp:GridView>
    </form>
</body>
</html>
