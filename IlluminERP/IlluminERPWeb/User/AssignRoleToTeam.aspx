<%@ Page Language="VB" AutoEventWireup="false" CodeFile="AssignRoleToTeam.aspx.vb" Inherits="AssignRoleToTeam" %>
<%@ Register TagPrefix="illuminuc" TagName="DoubleListbox" Src="../Ascx/ListboxDragDrop.ascx" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
	<title></title>
     <base target="_self" />
    <link href="../css/style.css" rel="stylesheet" type="text/css" />
    <script src="../js/validation.js" type="text/javascript"></script>
    <script src="../js/operation.js" type="text/javascript"></script>
     <script type="text/javascript">
         function CloseWindow() {
             this.close();
         }
    </script>
	<telerik:RadStyleSheetManager id="RadStyleSheetManager1" runat="server" />
</head>
<body>
    <form id="form1" runat="server">
	<telerik:RadScriptManager ID="RadScriptManager1" runat="server">
		<Scripts>
			<%--Needed for JavaScript IntelliSense in VS2010--%>
			<%--For VS2008 replace RadScriptManager with ScriptManager--%>
			<asp:ScriptReference Assembly="Telerik.Web.UI" Name="Telerik.Web.UI.Common.Core.js" />
			<asp:ScriptReference Assembly="Telerik.Web.UI" Name="Telerik.Web.UI.Common.jQuery.js" />
			<asp:ScriptReference Assembly="Telerik.Web.UI" Name="Telerik.Web.UI.Common.jQueryInclude.js" />
		</Scripts>
	</telerik:RadScriptManager>
	<script type="text/javascript">
		//Put your JavaScript code here.
    </script>
	<telerik:RadAjaxManager ID="RadAjaxManager1" runat="server">
	</telerik:RadAjaxManager>
	<div class="title">
    Assign Role To Team
	</div>
    <div>
     <table class="dg" width="100%">
        <tr>
            <td width="15%">Team Name</td><td><asp:Label ID="lblTeamName" runat="server" Text=""></asp:Label></td>
            <td width="15%">Team Leader</td><td><asp:Label ID="lblTeamLeader" runat="server" Text=""></asp:Label></td>
            <td width="10%">Sector</td><td><asp:Label ID="lblSector" runat="server" Text=""></asp:Label></td>
        </tr>
     </table>
    </div>
    <div>
        <illuminuc:DoubleListbox ID="dlbRole" runat="server" DataTextField="RoleName" DataValueField="ID" />
    </div>
    <div>
        <asp:Button ID="btnSave" runat="server" Text="Save" CssClass="btnsave" />
        <input type="button" id="btnCancel" class="btncancel" onclick="javascript:CloseWindow();" value="Cancel" />
    </div>
	</form>
</body>
</html>
