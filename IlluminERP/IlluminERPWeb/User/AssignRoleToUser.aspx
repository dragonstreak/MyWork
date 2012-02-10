<%@ Page Language="VB" AutoEventWireup="false" CodeFile="AssignRoleToUser.aspx.vb" Inherits="AssignRoleToUser" %>
<%@ Register TagPrefix="illuminuc" TagName="DoubleListbox" Src="../Ascx/ListboxDragDrop.ascx" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
	<title></title>
    <base target="_self" />
     <link href="../css/style.css" rel="stylesheet" type="text/css" />
    <script src="../js/validation.js" type="text/javascript"></script>
    <script src="../js/operation.js" type="text/javascript"></script>
	<telerik:RadStyleSheetManager id="RadStyleSheetManager1" runat="server" />
     <script type="text/javascript">
         function CloseWindow() {
             this.close();
         }
    </script>
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
    Assign Role To User
	</div>
    <div>
     <table class="dg" width="100%">
        <tr>
            <td width="10%">Code</td><td><asp:Label ID="lblCode" runat="server" Text=""></asp:Label></td>
            <td width="10%">E_Name</td><td><asp:Label ID="lblEName" runat="server" Text=""></asp:Label></td>
            <td width="10%">C_Name</td><td><asp:Label ID="lblCName" runat="server" Text=""></asp:Label></td>
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
