<%@ Control Language="C#" AutoEventWireup="true" CodeFile="BoxControl.ascx.cs" Inherits="Templates_BoxControl" %>
<input id="<%=lstAuth.ClientID%>_zLstSelect" type="hidden" name="<%=lstAuth.ClientID%>_zLstSelect" />
<input id="<%=lstNoAuth.ClientID%>_zLstNoSelect" type="hidden" name="<%=lstNoAuth.ClientID%>_zLstNoSelect" />
<table id="Table3" cellspacing="0" cellpadding="0" width="600px" border="0">
	<tr>
		<td>
			<table id="Table1" cellspacing="0" cellpadding="0" width="600px" border="0">
				<tr>
					<td align="center" style="height:25; width: 270px;">
						<asp:Label id="lblSource" runat="server">กลุ่มที่ไม่ถูกกำหนด</asp:Label></td>
					<td align="center"></td>
					<td align="center" style="height:25; width: 270px;">
						<asp:Label id="lblDestination" runat="server">กลุ่มที่กำหนด</asp:Label></td>
				</tr>
				<tr>
					<td align="center" style="height:15; width: 270px;"></td>
					<td align="center"></td>
					<td align="center" style="height:15; width: 270px;"></td>
				</tr>
				<tr>
					<td align="center" style="width: 270px">&nbsp;<asp:ListBox id="lstNoAuth" runat="server" Width="250px" style="height:300px"
							SelectionMode="Multiple" CssClass="zTextbox"></asp:ListBox></td>
					<td align="center">
						<table id="Table4" cellspacing="3" cellpadding="1" width="100%" border="0">
							<tr>
								<td align="center" style="height:25">
									<asp:Button id="btnAddAll" runat="server" Width="50px" CssClass="zButton" Text=">>" ToolTip="เพิ่มทั้งหมด"></asp:Button></td>
							</tr>
							<tr>
								<td align="center" style="height:25"></td>
							</tr>
							<tr>
								<td align="center" style="height:25">
									<asp:Button id="btnAddSel" runat="server" Width="50px" CssClass="zButton" Text=">" ToolTip="เพิ่มรายการที่เลือก"></asp:Button></td>
							</tr>
							<tr>
								<td align="center" style="height:25">
									<asp:Button id="btnRemSel" runat="server" Width="50px" CssClass="zButton" Text="<" ToolTip="ลบรายการที่เลือก"></asp:Button></td>
							</tr>
							<tr>
								<td align="center" style="height:25"></td>
							</tr>
							<tr>
								<td align="center" style="height:25">
									<asp:Button id="btnRemAll" runat="server" Width="50px" CssClass="zButton" Text="<<" ToolTip="ลบทั้งหมด"></asp:Button></td>
							</tr>
						</table>
					</td>
					<td align="center" style="width: 270px">
						<asp:ListBox id="lstAuth" runat="server" Width="250px" style="height:300px" SelectionMode="Multiple"
							CssClass="zTextbox"></asp:ListBox></td>
				</tr>
			</table>
		</td>
	</tr>
</table>