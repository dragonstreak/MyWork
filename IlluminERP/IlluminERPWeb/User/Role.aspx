<%@ Page Language="VB" AutoEventWireup="false" CodeFile="Role.aspx.vb" Inherits="Role" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
	<title>Add Role</title>
    <base target="_self" />
    <link href="../css/style.css" rel="stylesheet" type="text/css"/>
    <script src="../js/validation.js" type="text/javascript"></script>
    <script src="../js/operation.js" type="text/javascript"></script>
	<telerik:RadStyleSheetManager id="RadStyleSheetManager1" runat="server" />
    <script type="text/javascript">
        function CheckInput() {
            var name = document.getElementById("txtName");
            if(isEmpty(trim(name.value)))
            {
                ShowMessage("Role name can't be empty!");
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
    <form id="form1" runat="server" onsubmit="return CheckInput();">
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
    <asp:Label ID="lblTitle" Text="Add Role" runat="server"></asp:Label>
	</div>
    <div>
    <table class="dg" width="100%">
        <tr>
            <td width="12%"><font color="#ff3300">*</font>Name </td>
            <td width="38%"><asp:TextBox ID="txtName" runat="server" CssClass="text"></asp:TextBox></td>
            <td width="12%">Status</td>
            <td><asp:DropDownList ID="ddlStatus" runat="server"></asp:DropDownList></td>
        </tr>
        <tr>
            <td>Remark</td>
            <td colspan="3"><asp:TextBox ID="txtRemark" runat="server" CssClass="text" Width="100%" TextMode="MultiLine" MaxLength="100"></asp:TextBox></td>
        </tr>
    </table>
    </div>
    <div>
        <asp:Button ID="btnSave" runat="server" Text="Save" CssClass="btnsave" /> <input type="button" id="btnCancel" value="Cancel" onclick="CancelOperation();" class="btncancel" />
    </div>
    <div class="radtree">
        Permissions
    </div>
    <div class="radtree">
        
        <telerik:RadTreeView ID="treePermission" Runat="server"  CheckBoxes="true" CheckChildNodes="true" TriStateCheckBoxes="true">
         <ExpandAnimation Type="OutQuart" Duration="1000" />
         <CollapseAnimation Type="OutQuint" Duration="1000" />

        </telerik:RadTreeView>
     
    </div>
	</form>
</body>
</html>
