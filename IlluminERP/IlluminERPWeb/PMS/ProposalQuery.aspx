<%@ Page Language="VB"  MasterPageFile="~/Master/IlluminMasterPage.master" AutoEventWireup="false" CodeFile="ProposalQuery.aspx.vb" Inherits="ProposalQuery" %>

<asp:Content ID="ChildPageHead" ContentPlaceHolderID="head" runat="server">
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
	<telerik:RadWindowManager ID="RadWindowManager1" runat="server" >
          <Windows>
                 <telerik:RadWindow ID="RadWindow1" runat="server" Width="750px" Height="600px" Modal="true"    EnableShadow="true"  >
                        
                   
                </telerik:RadWindow>

                <telerik:RadWindow ID="StageWindow" runat="server" Width="1024px" Height="700px" Modal="true"    EnableShadow="true"> 
                        
                   
                </telerik:RadWindow>
        </Windows>
    </telerik:RadWindowManager>
	<telerik:RadAjaxLoadingPanel ID="RadAjaxLoadingPanel1" Runat="server" 
        Skin="Office2007">
    </telerik:RadAjaxLoadingPanel>
	<script type="text/javascript">
	    //Put your JavaScript code here.
    </script>
	<telerik:RadAjaxManager ID="RadAjaxManager1" runat="server" 
        DefaultLoadingPanelID="RadAjaxLoadingPanel1">
        <AjaxSettings>
            <telerik:AjaxSetting AjaxControlID="cbBusinessUnit">
                <UpdatedControls>
                    <telerik:AjaxUpdatedControl ControlID="cbSector" 
                        LoadingPanelID="RadAjaxLoadingPanel1" />
                </UpdatedControls>
            </telerik:AjaxSetting>
            <telerik:AjaxSetting AjaxControlID="cbSector">
                <UpdatedControls>
                    <telerik:AjaxUpdatedControl ControlID="cbProductCategory" 
                        LoadingPanelID="RadAjaxLoadingPanel1" />
                </UpdatedControls>
            </telerik:AjaxSetting>
        </AjaxSettings>
      
	</telerik:RadAjaxManager>

    <div class="title">
        Proposal&nbsp; Search</div>
    <table width="100%" class="query" id="table1">
		<caption class="advover" onclick="adv(table1,main)">Search Options</caption>
		<tbody id="main">
		<tr>
			<td  align =left class="searchlable" >Job Number:</td>
			<td align =left class="searchvalue" >
                <telerik:RadTextBox ID="txtJobNumber" Runat="server" Width="98%" 
                    Skin="Windows7">
                </telerik:RadTextBox>
            </td>
			<td align =left class="searchlable">Job Name:</td>
			<td align=left class="searchvalue" >
                <telerik:RadTextBox ID="txtJobName" Runat="server" Width="98%" Skin="Windows7">
                </telerik:RadTextBox>
            </td>

            <td align =left class="searchlable">Business Unit:</td>
			<td align=left class="searchvalue" >
                        <telerik:RadComboBox ID="cbBusinessUnit" Runat="server" Skin="Windows7" 
                            Width="98%" AutoPostBack="True">
                        </telerik:RadComboBox>
            </td>

		</tr>
        <tr>
			<td align =left class="searchlable" >Sector:</td>
			<td align =left>
                        <telerik:RadComboBox ID="cbSector" Runat="server" Width="98%" 
                                 Skin="Windows7" AutoPostBack="True">
                        
                        </telerik:RadComboBox>
            </td>
			<td align =left class="searchlable" >Pro. Category:</td>
			<td align =left>
                        <telerik:RadComboBox ID="cbProductCategory" Runat="server" Skin="Windows7" 
                            Width="98%"  DropDownWidth="300px"
                                CheckBoxes ="true">
                        </telerik:RadComboBox>
                    </td>
            <td align =left class="searchlable" >Study Type:</td>
			<td align =left>
                        <telerik:RadComboBox ID="cbStudytype" Runat="server" Skin="Windows7" 
                         DropDownCssClass="multipleRowsColumns" DropDownWidth="400px"
                                     CheckBoxes ="true"
                            Width="98%">
                        </telerik:RadComboBox>
            </td>
		</tr>
          <tr>

			<td align =left class="searchlable" >Pro. Rating:</td>
			<td align =left>
                        <telerik:RadComboBox ID="cbRating" Runat="server" Skin="Windows7" 
                            Width="98%" Font-Names="Arial" Font-Size="9pt">
                            <Items>
                                <telerik:RadComboBoxItem runat="server" Selected="True" Text="decent proposal" 
                                    Value="0" />
                                <telerik:RadComboBoxItem runat="server" Text="worth reading" Value="1" />
                            </Items>
                        </telerik:RadComboBox>
                    </td>
			<td align =left class="searchlable" >Status:</td>
			<td align =left>
                        <telerik:RadComboBox ID="cbStatus" Runat="server" Skin="Windows7" 
                            Width="98%" Font-Names="Arial" Font-Size="9pt">
                            <Items>
                                <telerik:RadComboBoxItem runat="server" Selected="True" Text="decent proposal" 
                                    Value="0" Owner="cbStatus" />
                                <telerik:RadComboBoxItem runat="server" Text="worth reading" Value="1" 
                                    Owner="cbStatus" />
                            </Items>
                        </telerik:RadComboBox>
                    </td>
            <td align =left class="searchlable" >Team Member:</td>
			<td align =left>
                        &nbsp;</td>
		</tr>
        <tr>
			<td align = left  class="searchlable" >Client:</td>
			<td colspan="5" align =left>
                <telerik:RadComboBox ID="cbClient" Runat="server" Skin="Windows7" Width="400px" 
                    MarkFirstMatch="True">
                </telerik:RadComboBox>

  
        <tr>
			<td align =left class="searchlable" >Key Words:</td>
			<td colspan="5" align =left>
                <telerik:RadTextBox ID="txtKeywords" Runat="server" Width="400px" 
                    Skin="Windows7">
                </telerik:RadTextBox>
            </td>
		
		</tr>
		<tr class="dgf" >
			<td colspan="6" >
                <telerik:RadButton ID="btnMyProposal" runat="server" Skin="Hay" 
                    Text="My Proposal" Font-Names="Arial" Font-Size="9pt" Width="120px">
                     <Icon PrimaryIconUrl="../images/myproposal.png" PrimaryIconLeft="4" PrimaryIconTop="4" />
                </telerik:RadButton>

                <telerik:RadButton ID="btnQuery" runat="server" Text="Query"  
                    Font-Names="Arial" Font-Size="9pt" Width="100px" Skin="Hay" >
                   <Icon PrimaryIconUrl="../images/btnqry.gif" PrimaryIconLeft="10" PrimaryIconTop="4" />
                </telerik:RadButton>
                <telerik:RadButton ID="btnReset" runat="server" Text="Clear Condition" Font-Names="Arial" 

                    Font-Size="9pt"  Width="130px" Skin="Hay">
                       <Icon PrimaryIconUrl="../images/btnreset.gif" PrimaryIconLeft="2" PrimaryIconTop="4" />
                </telerik:RadButton>
              
            &nbsp;<asp:Button ID="btnAdd" runat="server" Text="Add Proposal" Visible="false" 
                   OnClientClick="javascript:OpenAddProposalPage()" 
                    Font-Names="Arial" Font-Size="9pt" Height="28px" Width="100px" />
</td>
		</tr>
		</tbody>
	</table>

    <div class="queryresultgrid" >
    
        <telerik:RadGrid ID="gridResult" runat="server" 
            AllowPaging="True" AllowSorting="True" AutoGenerateColumns="False" 
            GridLines="None" Width="800px" Height="375px" 
            Skin="Simple" CellSpacing="0"  >
          <ClientSettings>
                    <Selecting AllowRowSelect="True" />
                    <Scrolling AllowScroll="True" UseStaticHeaders="True" SaveScrollPosition="true" FrozenColumnsCount="3">
                    </Scrolling>
                    <Resizing AllowColumnResize="True" />
                </ClientSettings>
<MasterTableView PageSize="15">
<CommandItemSettings ExportToPdfText="Export to Pdf"></CommandItemSettings>

<RowIndicatorColumn Visible="True" FilterControlAltText="Filter RowIndicator column"></RowIndicatorColumn>

<ExpandCollapseColumn Visible="True" FilterControlAltText="Filter ExpandColumn column"></ExpandCollapseColumn>

    <Columns>
        <telerik:GridBoundColumn DataField="ID" HeaderText="ID" 
            UniqueName="columnID" AllowFiltering="False" Resizable="False" 
            Visible="False">
            <HeaderStyle Width="2px" />
        </telerik:GridBoundColumn>
        <telerik:GridBoundColumn UniqueName="columnGo" Visible="False">
            <HeaderStyle HorizontalAlign="Center" Width="80px" />
            <ItemStyle Font-Bold="False" Font-Italic="False" Font-Overline="False" 
                Font-Strikeout="False" Font-Underline="False" HorizontalAlign="Center" 
                Wrap="True" ForeColor="Navy" />
        </telerik:GridBoundColumn>
        <telerik:GridBoundColumn HeaderText="Scale Rating" UniqueName="columnRating" 
            Visible="False">
            <HeaderStyle HorizontalAlign="Center" Width="30px" />
            <ItemStyle Font-Bold="False" Font-Italic="False" Font-Overline="False" 
                Font-Strikeout="False" Font-Underline="False" HorizontalAlign="Center" 
                Wrap="True" />
        </telerik:GridBoundColumn>
        <telerik:GridBoundColumn HeaderText="Team Assignment" 
            UniqueName="columnTeamAssignment" Visible="False">
            <HeaderStyle HorizontalAlign="Center" Width="30px" />
            <ItemStyle Font-Bold="False" Font-Italic="False" Font-Overline="False" 
                Font-Strikeout="False" Font-Underline="False" HorizontalAlign="Center" 
                Wrap="True" />
        </telerik:GridBoundColumn>
        <telerik:GridBoundColumn HeaderText="Timing" 
            UniqueName="columnTiming"  Visible="False" AllowFiltering="False" Resizable="False" >
            <HeaderStyle HorizontalAlign="Center" Width="30px" />
            <ItemStyle Font-Bold="False" Font-Italic="False" Font-Overline="False" 
                Font-Strikeout="False" Font-Underline="False" HorizontalAlign="Center" 
                Wrap="True" />
        </telerik:GridBoundColumn>
        <telerik:GridBoundColumn HeaderText="Quotation" 
            UniqueName="columnQuotation"  Visible="False" AllowFiltering="False" Resizable="False" >
            <HeaderStyle HorizontalAlign="Center" Width="30px" />
            <ItemStyle Font-Bold="False" Font-Italic="False" Font-Overline="False" 
                Font-Strikeout="False" Font-Underline="False" HorizontalAlign="Center" 
                Wrap="True" />
        </telerik:GridBoundColumn>
        <telerik:GridBoundColumn HeaderText="Stage" 
            UniqueName="columnStage"  Visible="False" AllowFiltering="False" Resizable="False" >
            <HeaderStyle HorizontalAlign="Center" Width="30px" />
            <ItemStyle Font-Bold="False" Font-Italic="False" Font-Overline="False" 
                Font-Strikeout="False" Font-Underline="False" HorizontalAlign="Center" 
                Wrap="True" />
        </telerik:GridBoundColumn>
        <telerik:GridBoundColumn UniqueName="columnEdit" 
            Visible="False" AllowFiltering="False" Resizable="False" >
            <HeaderStyle Width="50px" HorizontalAlign="Center" />
            <ItemStyle HorizontalAlign="Center" />
        </telerik:GridBoundColumn>
        <telerik:GridBoundColumn DataField="JobNumber" HeaderText="Job Num." 
            UniqueName="columnJobNumber" AllowFiltering="False" Resizable="False" 
            >
            <HeaderStyle Width="80px" HorizontalAlign="Center" Wrap="False"/>
            <ItemStyle HorizontalAlign="Left" Wrap="False" />
        </telerik:GridBoundColumn>
        <telerik:GridBoundColumn DataField="JobName" HeaderText="Job Name" 
            UniqueName="columnJobName" AllowFiltering="False" Resizable="False" 
            >
            <HeaderStyle Width="80px" HorizontalAlign="Center" Wrap="False" />
            <ItemStyle HorizontalAlign="Left" Wrap="False" />
        </telerik:GridBoundColumn>
        <telerik:GridBoundColumn DataField="ClientId" HeaderText="Client" 
            UniqueName="columnClientID" AllowFiltering="False" 
            >
            <HeaderStyle Width="250px" HorizontalAlign="Center" />
            <ItemStyle HorizontalAlign="Left" Wrap="False" />
        </telerik:GridBoundColumn>
        <telerik:GridBoundColumn DataField="SectorID" HeaderText="Sector" 
            UniqueName="columnSectorID" AllowFiltering="False" Resizable="False" 
            >
            <HeaderStyle Width="180px" HorizontalAlign="Center" />
            <ItemStyle HorizontalAlign="Left" Wrap="False" />
        </telerik:GridBoundColumn>
        <telerik:GridBoundColumn DataField="ProductCategoryId" 
            HeaderText="Product Category" UniqueName="columnProductCategoryId" 
            AllowFiltering="False" Resizable="False" >
            <HeaderStyle Width="180px" HorizontalAlign="Center" />
            <ItemStyle HorizontalAlign="Left" Wrap="False" />
        </telerik:GridBoundColumn>
        <telerik:GridBoundColumn AllowFiltering="False" DataField="StudyTypeId" 
            HeaderText="Study Type" Resizable="False" UniqueName="columnStudyType">
            <HeaderStyle HorizontalAlign="Center" Width="300px" />
            <ItemStyle HorizontalAlign="Left" Wrap="False" />
        </telerik:GridBoundColumn>
        <telerik:GridBoundColumn DataField="Status" HeaderText="Status" 
            UniqueName="columnStatus" AllowFiltering="False" Resizable="False" 
            >
            <HeaderStyle Width="80px" HorizontalAlign="Center" />
            <ItemStyle HorizontalAlign="Center" />
        </telerik:GridBoundColumn>
    </Columns>

<EditFormSettings>
<EditColumn FilterControlAltText="Filter EditCommandColumn column"></EditColumn>
</EditFormSettings>

    <PagerStyle AlwaysVisible="True" Mode="NumericPages" />
</MasterTableView>
            <PagerStyle AlwaysVisible="True" Mode="NumericPages" />

<FilterMenu EnableImageSprites="False">
<WebServiceSettings>
<ODataSettings InitialContainerName=""></ODataSettings>
</WebServiceSettings>
</FilterMenu>

<HeaderContextMenu CssClass="GridContextMenu GridContextMenu_Simple">
<WebServiceSettings>
<ODataSettings InitialContainerName=""></ODataSettings>
</WebServiceSettings>
</HeaderContextMenu>
        </telerik:RadGrid>
    
    </div>
        <script type ="text/javascript" >

            function GetRadWindow() {
                var oWindow = null;
                if (window.radWindow) oWindow = window.radWindow;
                else if (window.frameElement.radWindow) oWindow = window.frameElement.radWindow;
                return oWindow;
            }
            function openWin(url) {
                var oWnd = window.radopen(url, "RadWindow1");
                var bounds = oWnd.getWindowBounds();
                var x = bounds.x;
                var y = bounds.y;
                oWnd.moveTo(x, 5);
                return  false;
            }

            function openStageWin(url) {
                var oWnd = window.radopen(url, "StageWindow");
                var bounds = oWnd.getWindowBounds();
                var x = bounds.x;
                var y = bounds.y;
                oWnd.moveTo(x, 5);
                return false;
            }
        </script>

	</form>
</asp:Content>
