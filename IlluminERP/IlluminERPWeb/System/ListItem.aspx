<%@ Page Language="VB" AutoEventWireup="false" CodeFile="ListItem.aspx.vb" Inherits="ListItem" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
	<title></title>
    <base target="_self" />
	<telerik:RadStyleSheetManager id="RadStyleSheetManager1" runat="server" />
    <link href="../css/style.css" rel="stylesheet" type="text/css"/>
    <script src="../js/validation.js" type="text/javascript"></script>
    <script src="../js/operation.js" type="text/javascript"></script>
    <script type="text/javascript">
        function CheckInput() {
            var name = document.getElementById("txtName");
            if (isEmpty(trim(name.value))) {
                ShowMessage("Category name can't be empty!");
                return false;
            }
            return true;
        }
        function CancelOperation() {
            window.returnValue = 'cancel';
            window.close();
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
	<div>
        <div class="Title">
        <asp:Label ID="lblTitle" Text="" runat="server"></asp:Label>
        </div>
        <div>
         <table class="dg">
             <tr>
                <td class="dga" width="12%"><font color="#ff3300">*</font>Name </td>
                <td width="38%"><asp:TextBox ID="txtName" runat="server" CssClass="text"></asp:TextBox></td>
                <td class="dga" width="12%">Type</td>
                <td><asp:DropDownList ID="ddlType" runat="server" AutoPostBack="True"></asp:DropDownList></td>
            </tr>
            <tr>
                <td class="dga">
                Parent
                </td>
                <td colspan=3>
                    <asp:DropDownList ID="ddlParent" runat="server"></asp:DropDownList>
                </td>
            </tr>
         </table>
        </div>
        <div>
            <asp:Button ID="btnSave" CssClass="btnsave" runat="server" Text="Save" /> <input type="button" id="btnCancel" value="Cancel" onclick="CancelOperation();" class="btncancel" />
        </div>
	</div>
	</form>
</body>
</html>
