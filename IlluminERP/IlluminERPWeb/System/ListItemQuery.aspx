<%@ Page Language="VB" AutoEventWireup="false" CodeFile="ListItemQuery.aspx.vb" Inherits="ListItemQuery" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
	<title></title>
	<telerik:RadStyleSheetManager id="RadStyleSheetManager1" runat="server" />
    <link href="../css/style.css" rel="stylesheet" type="text/css"/>
    <script src="../js/validation.js" type="text/javascript"></script>
    <script src="../js/operation.js" type="text/javascript"></script>
    <script type="text/javascript">
        //this function is used to open add user page
        var i = 0;
        //this method is used to get the random string.
        function getRandom() {
            var date = new Date();
            return Math.random() + "_" + date.getTime();
        }
        //this method is used to open add page.
        function OpenAddPage() {
            var randomStr = getRandom()
            var addResult = window.showModalDialog("ListItem.aspx?OperateType=New&i=" + randomStr, window, 'dialogWidth=800px;dialogHeight=600px;center:yes');
            if (addResult == 'success') {
                //refresh the grid,please take care of the control name, maybe not btnQuery.
                $("input[id$='btnQuery']").click();
            }
        }
        //this method is used to open modify page.
        function OpenModifyPage(id) {
            var randomStr = getRandom()
            var addResult = window.showModalDialog("ListItem.aspx?OperateType=Modify&id=" + id + "&i=" + randomStr, window, 'dialogWidth=800px;dialogHeight=600px');
            if (addResult == 'success') {
                //refresh the grid,please take care of the control name, maybe not btnQuery.
                $("input[id$='btnQuery']").click();
            }
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
        <div class="title">Common Category Query</div>
        <table width="100%" class="query" id="table1">
        <caption class="advover" onclick="adv(table1,main)">
            Query</caption>
        <tbody id="main">
            <tr>
                <td width="15%">
                    Name
                </td>
                <td width="35%">
                    <asp:TextBox ID="txtNameQry" runat="server" CssClass="text"></asp:TextBox>
                </td>
                <td width="15%">
                    Type
                </td>
                <td width="35%">
                    <asp:DropDownList ID="ddlTypeQry" runat="server">
                    </asp:DropDownList>
                </td>
            </tr>
            
            <tr class="dgf">
                <td colspan="4">
                    <asp:Button ID="btnQuery" runat="server" CssClass="btnqry" Text="Query" />
                    &nbsp;<input type="reset" Id="btnClear" value="Clear Condition" onclick="ClearCondition();" class="btnreset" />
                    &nbsp;<input type="button" name="btnAdd" value="Add Category" class="btnadd" onclick="javascript:OpenAddPage()" />
                    
                </td>
            </tr>
        </tbody>
    </table>

    <div class="queryresultgrid">

        <telerik:RadGrid ID="gridResult" runat="server" AllowPaging="True" 
            AutoGenerateColumns="False" PageSize="2" GridLines="None" HorizontalAlign ="Left" >
            <ClientSettings AllowColumnsReorder="True" ReorderColumnsOnClient="True">
                <Selecting AllowRowSelect="True" />
                <Scrolling AllowScroll="True" UseStaticHeaders="True" />
                
            </ClientSettings>

            <MasterTableView>
            <CommandItemSettings ExportToPdfText="Export to Pdf"></CommandItemSettings>

            <RowIndicatorColumn>
            <HeaderStyle Width="20px"></HeaderStyle>
            </RowIndicatorColumn>

            <ExpandCollapseColumn>
            <HeaderStyle Width="20px"></HeaderStyle>
            </ExpandCollapseColumn>
                <Columns>
                    <telerik:GridBoundColumn DataField="ContentText" HeaderText="Name" 
                        UniqueName="categoryNameColumn">
                         <HeaderStyle Width="220px" />
                         <ItemStyle HorizontalAlign="Left" />
                    </telerik:GridBoundColumn>
                    <telerik:GridBoundColumn HeaderText="Type" UniqueName="typeColumn">
                     <HeaderStyle Width="120px" />
                      <ItemStyle HorizontalAlign="Left" />
                    </telerik:GridBoundColumn>
                    <telerik:GridBoundColumn HeaderText="Parent" 
                        UniqueName="parentColumn">
                      <ItemStyle HorizontalAlign="Left" />
                    </telerik:GridBoundColumn>
                    <telerik:GridBoundColumn HeaderText="Edit" UniqueName="editColumn">
                     <HeaderStyle Width="60px" />
                     <ItemStyle HorizontalAlign="Left" />
                    </telerik:GridBoundColumn>
                     <telerik:GridBoundColumn HeaderText="ID" UniqueName="IDColumn" DataField="ListItemID" Display="false">
                    </telerik:GridBoundColumn>
                </Columns>
            </MasterTableView>
        </telerik:RadGrid>
        </div>
	</div>

	</form>
</body>
</html>
