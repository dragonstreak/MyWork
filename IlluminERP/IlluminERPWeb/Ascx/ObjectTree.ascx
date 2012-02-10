<%@ Control Language="VB" AutoEventWireup="false" CodeFile="ObjectTree.ascx.vb" Inherits="Ascx_ObjectTree" %>
<style type="text/css">
    .style1
    {
        width: 100%;
    }
</style>

<telerik:RadScriptManager ID="RadScriptManager1" Runat="server">
</telerik:RadScriptManager>
<table class="style1" width ="auto">
    <tr width ="auto">
        <td>
            <telerik:RadTreeView ID="rtvSourceTree" Runat="server">
            </telerik:RadTreeView>
        </td>
        <td>
            <telerik:RadTreeView ID="rtvTarget" Runat="server">
            </telerik:RadTreeView>
        </td>
    </tr>
    <tr width ="auto">
        <td>
            
            <asp:Button ID="Button1" runat="server" Text="Save" />
            <asp:Button ID="Button2" runat="server" Text="Button" />
            <asp:Button ID="Button3" runat="server" Text="Button" />
            <asp:Button ID="Button4" runat="server" Text="Button" />
            
        </td>
    </tr>
</table>

