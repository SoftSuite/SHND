<%@ Control Language="C#" AutoEventWireup="true" CodeFile="ChangeorderCtl.ascx.cs" Inherits="App_Prepare_Transaction_ChangeOrder_ChangeorderCtl" %>
<%@ Register Src="ChangeOrderOldCtl.ascx" TagName="ChangeOrderOldCtl" TagPrefix="uc2" %>
<%@ Register Src="ChangOrderNewCtl.ascx" TagName="ChangOrderNewCtl" TagPrefix="uc1" %>
<table  border="1" cellspacing="0"  style="border-collapse: collapse; border-color:White ">
        <tr>
            <td>
              <uc1:ChangOrderNewCtl ID="ChangOrderNewCtl" runat="server" />
              
                <uc2:ChangeOrderOldCtl ID="ChangeOrderOldCtl" runat="server" />
            </td>
        </tr>
</table>