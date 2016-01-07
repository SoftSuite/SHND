<%@ Page Language="C#" AutoEventWireup="true" CodeFile="AttachPage.aspx.cs" Inherits="Templates_AttachPage" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml" >
<head id="Head1" runat="server">
    <title>Untitled Page</title>
    <link rel="Stylesheet" type="text/css" href="BaseStyle.css" />
</head>
<body style="background-color:White; margin:0px">
    <form id="form1" runat="server">
    <div>
            <asp:Panel ID="pnlMain" runat="server">
                <table border="0" cellpadding="0" cellspacing="0" width="500">
                    <tr>
                        <td>
                            <table id="Table1" border="0" cellpadding="1" cellspacing="2" width="500">
                                <asp:Repeater ID="rptAttach" runat="server">
                                    <ItemTemplate>
                                        <tr>
                                            <td style="height: 23px; background-color: #EEEEEE">
                                                &nbsp; <a href='<%=Request.ApplicationPath%>/Templates/GetAttachFile.aspx?id=<%# DataBinder.Eval(Container.DataItem, "ID") %>'
                                                    target="_blank">
                                                    <%# DataBinder.Eval(Container.DataItem, "FILENAME")%>
                                                </a>
                                            </td>
                                            <td align="right" style="height: 23px; width: 120px; background-color: #EEEEEE;">
                                                
                                                <%# showSize(DataBinder.Eval(Container.DataItem, "FILESIZE"))%>&nbsp;
                                            </td>
                                            <td align="center" style="height: 23px; width: 60px; background-color: #EEEEEE;<%=(_readOnly || !_allowDelete ? "display:none;":"")%>" <%=(!_enabled?"disabled='disabled'":"") %>>
                                                <input class="zButton" name="zDeleteJa" onclick="if ( confirm('µÈÕß°“√≈∫‰ø≈Ï  <%# DataBinder.Eval(Container.DataItem, "FILENAME") %> À√◊Õ‰¡Ë ?') ) { document.getElementById('val<%=ControlID%>').value = '<%# DataBinder.Eval(Container.DataItem, "ID") %>'; document.getElementById('act<%=ControlID%>').value = '<%=ControlID%>'; } else { return false; }"
                                                    type="submit" value="delete" <%=(!_enabled?"disabled='disabled'":"") %>>
                                            </td>
                                        </tr>
                                    </ItemTemplate>
                                </asp:Repeater>
                            </table>
                        </td>
                    </tr>
                    <tr>
                        <td>
                            <asp:Label ID="lblError" runat="server" CssClass="zHighlight" EnableViewState="False"></asp:Label>
                        </td>
                    </tr>
                    <tr>
                        <td>
                        <asp:Panel ID="pnlUpload" runat="server" Width="100%">
                           <table border="0" cellpadding="0" cellspacing="0">
                                <tr>
                                    <td style="width: 110px">
                                        <input id="att<%=ControlID%>" class="zButton" onclick="ToggleVisible('zAtt<%=ControlID%>');if (document.getElementById('zAtt<%=ControlID%>').style.display!='none')document.getElementById('<%=btnUpload.ClientID%>').focus()"
                                            type="button" value="·π∫‰ø≈Ï" <%=(!_enabled?"disabled='disabled'":"") %> />
                                    </td>
                                    <td>
                                        <asp:Label ID="lblTitle" runat="server"></asp:Label>&nbsp;
                                    </td>
                                </tr>
                            </table>
                            <table id="zAtt<%=ControlID%>" border="0" cellpadding="0" cellspacing="0" style="display: none;
                                width: 500px; background-color: #dddddd">
                                <tr>
                                    <td align="center" colspan="2" style="padding-right: 3px; padding-left: 3px; padding-bottom: 3px;
                                        padding-top: 3px; height: 35px">
                                        <triggers>
</triggers>
                                        <asp:POSTBACKTRIGGER ControlID="btnUpload"></asp:POSTBACKTRIGGER><asp:FileUpload ID="zUpload" runat="server" Width="355px" />&nbsp;
                                        <asp:Button ID="btnUpload" runat="server" CssClass="zButton" OnClick="btnUpload_Click"
                                            Text="Upload" Width="80px" />&nbsp;
                                        <input class="zButton" onclick="ToggleVisible('zAtt<%=ControlID%>', 0)" style="width: 70px"
                                            type="button" value=" Cancel " />
                                    </td>
                                </tr>
                            </table>
                            <asp:Label ID="lblFocus" runat="server" Height="0px" Width="0px"></asp:Label>
                            </asp:Panel>
                        </td>
                    </tr>
                </table>
            </asp:Panel>
    
    <input id="val<%=ControlID%>" name="val<%=ControlID%>" type="hidden" />
    <input id="act<%=ControlID%>" name="act<%=ControlID%>" type="hidden" />
    </div>
    </form>
</body>
</html>