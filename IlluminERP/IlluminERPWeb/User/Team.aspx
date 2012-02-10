<%@ Page Language="VB" AutoEventWireup="false" CodeFile="Team.aspx.vb" Inherits="User_Team" %>


<%@ Register TagPrefix="illuminuc" TagName="DoubleListbox" Src="../Ascx/ListboxDragDrop.ascx" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml">
<head id="Head1" runat="server">
    <title></title>
    <base target="_self">
    <link href="../css/style.css" rel="stylesheet" type="text/css" />
    <script type="text/javascript">
        function CloseWindow() {
            this.close();
        }
    </script>
</head>
<body>
    <form id="form1" runat="server">
    <table class="bg" height ="100%">
      
        <tr>
            <td>
                Team Name:
            </td>
            <td>
                <telerik:RadTextBox ID="txtTeamName" runat="server" Width ="200px">
                </telerik:RadTextBox>
            </td>
            <td>
                Leader:
            </td>
            <td>
                <asp:DropDownList ID="ddlTeamleader" runat="server" Width="200px" 
                    Font-Names="Arial" Font-Size="9pt">
                </asp:DropDownList>
            </td>
        </tr>
        <tr>
            <td>
                Parent Team:
            </td>
            <td>
                <asp:DropDownList ID="ddlParent" runat="server" Width="200px" Font-Names="Arial" Font-Size="9pt" Height="21px">
                    </asp:DropDownList>
            </td>
            <td>
                Sector:
            </td>
            <td>
                <asp:DropDownList ID="ddlSector" runat="server" Width="200px" Font-Names="Arial" Font-Size="9pt" Height="21px">
                    </asp:DropDownList>
            </td>
        </tr>
        <tr>
            <td colspan="4">
                Add User Into Team:
            </td>
        </tr>
        <tr>
            <td colspan="4">
                <div>
                     
                    <illuminuc:DoubleListbox ID="dlbUser" runat="server" />
                </div>
            </td>
        </tr>
        <tr>
            <td colspan="4" align="center">
                <asp:Button ID="btnSave" runat="server" Text="Save" class="btnsave" />
                <input type="button" name="btnCancel" value="Cancel" class="btnclose" onclick="javascript:CloseWindow();" /><asp:ScriptManager 
                    ID="ScriptManager1" runat="server">
                </asp:ScriptManager>
&nbsp;</td>
        </tr>
    </table>
    </form>
</body>
</html>
