<%@ Page Language="VB" MasterPageFile="~/Master/IlluminMasterPage.master" AutoEventWireup="false" CodeFile="TempTestForm.aspx.vb" Inherits="TempTestForm" %>

<asp:Content ID="Content1" ContentPlaceHolderID="headJS" Runat="Server">
    <title>User Query</title>
    <link href="../css/style.css" rel="stylesheet" type="text/css"/>
    <script src="../js/validation.js" type="text/javascript"></script>
    <script src="../js/operation.js" type="text/javascript"></script>
	<telerik:RadStyleSheetManager id="RadStyleSheetManager1" runat="server" />
    <script type="text/javascript">
        //this function is used to open add user page
        var i = 0;
        function OpenAddProposalPage() {
            i++;
            var addResult = window.showModalDialog("Proposal.aspx?OperateType=New&i=" + i, window, "dialogWidth=800px;dialogHeight=600px;status=no;help=no;scroll=no");
            if (addResult == 'success') {
                //refresh the grid,please take care of the control name, maybe not btnQuery.
                $("input[id$='btnQuery']").click();
            }
        }
        function OpenModifyPage(id) {
            i++;
            var addResult = window.showModalDialog("Proposal.aspx?OperateType=Modify&Proid=" + id + "&i=" + i, window, 'dialogWidth=850px;dialogHeight=650px');
            if (addResult == 'success') {
                //refresh the grid,please take care of the control name, maybe not btnQuery.

                $("input[id$='btnQuery']").click();
            }
        }
    </script>
     <style type="text/css">
               .multipleRowsColumns .rcbItem, .multipleRowsColumns .rcbHovered
                    {
                        float: left;
                        margin: 0 1px;
                        min-height: 13px;
                        overflow: hidden;
                        padding: 2px 19px 2px 6px;
                        width: 150px;
                    }
     </style>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="head" Runat="Server">
</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="PageContentPlaceHolder" Runat="Server">
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

	</div>
	<p>
        <telerik:RadTextBox ID="RadTextBox1" Runat="server">
        </telerik:RadTextBox>
    </p>
	</form>
</asp:Content>
