<%@ Control Language="C#" AutoEventWireup="true" CodeFile="CalendarControl.ascx.cs" Inherits="Templates_CalendarControl" %>
<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="cc1" %>
<asp:TextBox runat="server" ID="txtDate" CssClass="zTextbox-View" Width="100px" OnTextChanged="txtDate_TextChanged" />
<asp:ImageButton runat="Server" ID="imgCal" ImageUrl="~/Images/calendar.gif" ToolTip="Click to show calendar" ImageAlign="Absmiddle" Height="21px" />
<cc1:CalendarExtender ID="cb" runat="server" TargetControlID="txtDate"  Format="dd/MM/yyyy" PopupButtonID="imgCal" />