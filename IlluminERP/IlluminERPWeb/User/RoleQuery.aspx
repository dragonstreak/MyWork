<%@ Page Language="VB" MasterPageFile="~/Master/IlluminMasterPage.master" AutoEventWireup="false" CodeFile="RoleQuery.aspx.vb" Inherits="RoleQuery" %>

<asp:Content ID="ChildPageHead" ContentPlaceHolderID="head" runat="server">
	<title></title>
     <link href="../css/style.css" rel="stylesheet" type="text/css" />
      <script src="../js/validation.js" type="text/javascript"></script>
    <script src="../js/operation.js" type="text/javascript"></script>
	<telerik:RadStyleSheetManager id="RadStyleSheetManager1" runat="server" />
    <script type="text/javascript">
        //this function is used to open add user page
        var i = 0;
        //this method is used to get the random string.
        function getRandom() {
            var date = new Date();
            return Math.random() + "_" + date.getTime();
        }
        //this method is used to open add user page.
        function OpenAddRolePage() {
            var randomStr = getRandom()
            var addResult = window.showModalDialog("Role.aspx?OperateType=New&i=" + randomStr, window, 'dialogWidth=800px;dialogHeight=600px;center:yes');
            if (addResult == 'success') {
                //refresh the grid,please take care of the control name, maybe not btnQuery.
                $("input[id$='btnQuery']").click();
            }
        }
        //this method is used to open modify page.
        function OpenModifyPage(id) {
            var randomStr = getRandom()
            var addResult = window.showModalDialog("Role.aspx?OperateType=Modify&id=" + id + "&i=" + randomStr, window, 'dialogWidth=800px;dialogHeight=600px');
            if (addResult == 'success') {
                //refresh the grid,please take care of the control name, maybe not btnQuery.
                $("input[id$='btnQuery']").click();
            }
        }
    </script>
</asp:Content>

<asp:Content ID="ChildPageBody" ContentPlaceHolderID="PageContentPlaceHolder" runat="server">
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
        Role Query
	</div>
    <table width="100%" class="query" id="table1">
        <caption class="advover" onclick="adv(table1,main)">
            Query</caption>
        <tbody id="main">
            <tr>
                <td width="15%">
                    Name
                </td>
                <td width="35%">
                    <asp:TextBox ID="txtName" runat="server" CssClass="text"></asp:TextBox>
                </td>
                <td width="15%">
                    Status
                </td>
                <td width="35%">
                    <asp:DropDownList ID="ddlStatus" runat="server">
                    </asp:DropDownList>
                </td>
            </tr>
            
            <tr class="dgf">
                <td colspan="4">
                    <asp:Button ID="btnQuery" runat="server" CssClass="btnqry" Text="Query" />
                    &nbsp;<input type="reset" name="Submit2" value="Clear Condition" onclick="ClearCondition();" class="btnreset" />
                    &nbsp;<input type="button" name="btnAdd" value="Add Role" class="btnadd" onclick="javascript:OpenAddRolePage()" />
                    
                </td>
            </tr>
        </tbody>
    </table>
    <div class="queryresultgrid">

        <telerik:RadGrid ID="gridResult" runat="server" AllowPaging="True" 
            AutoGenerateColumns="False" PageSize="2" GridLines="None" 
            HorizontalAlign ="Left" CellSpacing="0"  Width ="100%" Height ="450px">
            <ClientSettings AllowColumnsReorder="True" ReorderColumnsOnClient="True">
                <Selecting AllowRowSelect="True" />
                <Scrolling AllowScroll="True" UseStaticHeaders="True" />
            </ClientSettings>
<MasterTableView PageSize="15">
<CommandItemSettings ExportToPdfText="Export to Pdf"></CommandItemSettings>

<RowIndicatorColumn>
<HeaderStyle Width="20px"></HeaderStyle>
</RowIndicatorColumn>

<ExpandCollapseColumn>
<HeaderStyle Width="20px"></HeaderStyle>
</ExpandCollapseColumn>
    <Columns>
        <telerik:GridBoundColumn DataField="RoleName" HeaderText="Name" 
            UniqueName="roleNameColumn">
             <HeaderStyle Width="200px" />
             <ItemStyle HorizontalAlign="Left" />
        </telerik:GridBoundColumn>
        <telerik:GridBoundColumn HeaderText="Status" UniqueName="statusColumn">
         <HeaderStyle Width="60px" />
          <ItemStyle HorizontalAlign="Left" />
        </telerik:GridBoundColumn>
        <telerik:GridBoundColumn DataField="Remark" HeaderText="Remark" 
            UniqueName="remarkColumn">
          <ItemStyle HorizontalAlign="Left" />
        </telerik:GridBoundColumn>
        <telerik:GridBoundColumn HeaderText="Edit" UniqueName="editColumn">
         <HeaderStyle Width="60px" />
         <ItemStyle HorizontalAlign="Left" />
        </telerik:GridBoundColumn>
         <telerik:GridBoundColumn HeaderText="ID" UniqueName="IDColumn" DataField="ID" Display="false">
        </telerik:GridBoundColumn>
    </Columns>

<EditFormSettings>
<EditColumn FilterControlAltText="Filter EditCommandColumn column"></EditColumn>
</EditFormSettings>
    <PagerStyle Mode="NumericPages" />
</MasterTableView>

<FilterMenu EnableImageSprites="False">
<WebServiceSettings>
<ODataSettings InitialContainerName=""></ODataSettings>
</WebServiceSettings>
</FilterMenu>

<HeaderContextMenu CssClass="GridContextMenu GridContextMenu_Default">
<WebServiceSettings>
<ODataSettings InitialContainerName=""></ODataSettings>
</WebServiceSettings>
</HeaderContextMenu>
        </telerik:RadGrid>

    </div>
	</form>
</asp:Content>
