<%@ Page Language="VB" AutoEventWireup="false" CodeFile="ComponentEdit.aspx.vb" Inherits="PMS_ComponentEdit" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
    <link href="../Css/CornorPanel.css" rel="stylesheet" type="text/css" />
 
    <style type="text/css">
        /*style of the table in div*/
        .contentTable
        {
            width: inherit;
        }
        .contentTable .textTd
        {
            width: 30px;
            padding-left: 5px;
            text-align: left;
        }
        .contentTable .controlTd
        {
            width: inherit;
            padding-left: 10px;
            padding-right: 10px;
        }
        #dvCityCoverage div
        {
            padding: 0px;
        }
        .imgButton
        {
            width: 30;
            height: 30;
            padding-bottom: 3px;
        }
        .imgButton img
        {
            margin: 0 3px -3px 0 !important;
            padding: 0;
            border: none;
            width: 20px;
            height: 20px;
        }
    </style>
    <script type="text/javascript">
        var btnAddCriteria = null;
  

        function pageLoad() {
           
        
        }

        function OpenConfirm() {
            radconfirm('<h3 style=\'color: #333399;\'>Are you sure?</h3>', confirmCallBackFn, 330, 100, null, 'RadConfirm custom title');
            return false;
        }

        function AddTimingTask(sender, eventArgs) {
            $("#btnAddTiming")[0].click();
            sender.set_autoPostBack(false);
        }

        function AddQuotationTask(sender, eventArgs) {
            $("#btnAddQuotation")[0].click();
            sender.set_autoPostBack(false);
        }

        function ChangeMethodology() {

            if (!confirm('This action will delete the existing Task. Are you sure?')) {
                //document.getElementById("cbMethdologyValue").value = window.document.getElementById('hiddenMethdology').value;
                $("#cbMethdologyValue")[0].value = $("#hiddenMethdology")[0].value;                
                return false;
            }
            else {
                $("#btnMethodologyChange")[0].click();
                //window.document.getElementById('btnMethodologyChange').click();
                //window.document.getElementById('hiddenMethdology').value = document.getElementById("cbMethdologyValue").value;
                $("#hiddenMethdology")[0].value = $("#cbMethdologyValue")[0].value;    
            }

        }
        function ChangeMethodologyType() {
            if (!confirm('This action will delete the existing Task. Are you sure?')) {
                //document.getElementById("cbMethdology").value = window.document.getElementById('hiddenMethdologyType').value;
                $("#cbMethdology")[0].value = $("#hiddenMethdologyType")[0].value;   
                return false;
            }
            else {
                $("#btnMethodologyTypeChange")[0].click();
                //window.document.getElementById('btnMethodologyTypeChange').click();
                //window.document.getElementById('hiddenMethdologyType').value = document.getElementById("cbMethdology").value;
                $("#hiddenMethdologyType")[0].value = $("#cbMethdology")[0].value;
            }

        }

        function OnKeyPress(sender, eventArgs) {
            var c = eventArgs.get_keyCode();
            if (c == 13) {
              // __doPostBack('btnAddCriteria', '');
                $("#btnAddCriteria")[0].click();
                return true;
            }
            
        } 

    </script>
</head>
<body>
    <form id="form1" runat="server"   >
    <telerik:RadScriptManager ID="RadScriptManager1" runat="server">
    <Scripts>
                      <asp:ScriptReference Assembly="Telerik.Web.UI" Name="Telerik.Web.UI.Common.Core.js" />
                      <asp:ScriptReference Assembly="Telerik.Web.UI" Name="Telerik.Web.UI.Common.jQuery.js" />
                      <asp:ScriptReference Assembly="Telerik.Web.UI" Name="Telerik.Web.UI.Common.jQueryInclude.js" />
                      <asp:ScriptReference Path="~/Plugins/BlockUI.js" />

               </Scripts>
    </telerik:RadScriptManager>
    <div class="wrapper">
        <div class="sharp color1" style="width: 98%;">
            <b class="b1"></b><b class="b2"></b><b class="b3"></b><b class="b4"></b>
            <div class="content" style="height: 30px">
                <div style="padding: 2px">
                    <p style="text-align: center">

                    <span style="vertical-align: bottom; padding:0px">
                        <asp:Label runat="server" ID="labelStage" Font-Bold="True" Font-Names="Arial"
                            Font-Size="12pt" ForeColor="#CC0000"></asp:Label>
                      
                         <telerik:RadButton ID="btnSaveComponent" runat="server"  Text ="Save Component" Font-Names="Arial" 
                            Font-Size="9pt" Width="150px" Skin="Hay" >
                             <Icon PrimaryIconUrl="../images/save.png" PrimaryIconLeft="5" PrimaryIconTop="4" />
                        </telerik:RadButton>   

                    </span> 

                       <span style="float: right; padding-right: 10px;padding-top :5px;">
                            
                          <telerik:RadButton ID="btnReturn" runat="server"  Text ="Return Stage" Font-Names="Arial" 
                            Font-Size="9pt" Width="100px" Skin="Hay" >
                             <Icon PrimaryIconUrl="../images/Return.png" PrimaryIconLeft="1" PrimaryIconTop="4" />
                        </telerik:RadButton>   

                           <telerik:RadButton ID="btnNext" runat="server"  Text ="Go Quotation" Font-Names="Arial" 
                            Font-Size="9pt" Width="100px" Skin="Hay" >
                             <Icon PrimaryIconUrl="../images/next.png" PrimaryIconLeft="1" PrimaryIconTop="4" />
                        </telerik:RadButton>   

                         </span>
                    </p>
                </div>
            </div>
            <b class="b5"></b><b class="b6"></b><b class="b7"></b><b class="b8"></b>
        </div>
        <div class="sharp color1" style="width: 19%">
            <b class="b1"></b><b class="b2"></b><b class="b3"></b><b class="b4"></b>
            <div class="content" style="height: 160px">
                <h3>
                    <telerik:RadTextBox Width="85%" ID="txtComponentName" runat="server" EmptyMessage="Input Component Name.."
                        ForeColor="#CC0000" Font-Size="9pt" Font-Bold="True">
                    </telerik:RadTextBox></h3>
                <hr align="left" size="1" style="border-style: dotted; color: Aqua;" noshade />
                <h3>
                    Project key word</h3>
                <hr align="left" size="1" style="border-style: dotted; color: Aqua;" noshade />
                <div>
                    <asp:TextBox TextMode="MultiLine" runat="server" ID="txtKeyWord" Height="50px" Width="90%"></asp:TextBox>
                </div>
            </div>
            <b class="b5"></b><b class="b6"></b><b class="b7"></b><b class="b8"></b>
        </div>

        <div class="sharp color1">
            <b class="b1"></b><b class="b2"></b><b class="b3"></b><b class="b4"></b>
            <div class="content" style="height: 160px">
                <h3>
                    Methodology
                 </h3>
                <hr align="left" size="1" style="border-style: dotted; color: Aqua;" noshade />
                <telerik:RadAjaxPanel ID="MethodologyAjaxPanel" runat="server" LoadingPanelID="LoadingPanel1">
                    <div>
                        <table  style=" float :left ;">
                            <tr>
                                <td style=" width :30px;">
                                    Meth. Type:
                                </td>
                                <td  style="width: 104px; float:left; ">
                                    <asp:DropDownList runat="server" ID="cbMethdology" 
                                        onchange = "javascript:ChangeMethodologyType()" Width="140px" >
                                    </asp:DropDownList>
                                </td>
                            </tr>
                            <tr>
                              <td style=" width :30px;">
                                    Methodology:
                                </td>
                                   <td  style="width: 104px; float:left; ">
                                    <asp:DropDownList runat="server" ID="cbMethdologyValue" 
                                        onchange = "javascript:ChangeMethodology()" Width="140px" >
                                    </asp:DropDownList>
                                </td>
                            </tr>
                        </table>
                    </div>
                </telerik:RadAjaxPanel>

                <telerik:RadAjaxLoadingPanel BackgroundPosition="Center" EnableSkinTransparency="false"
                    ID="LoadingPanel1" runat="server">
                    <asp:Image ID="Image1" runat="server" ImageUrl="../Images/loading.gif"></asp:Image>
                </telerik:RadAjaxLoadingPanel>
            </div>
            <b class="b5"></b><b class="b6"></b><b class="b7"></b><b class="b8"></b>
        </div>
        <div class="sharp color1" style="width: 45%">
            <b class="b1"></b><b class="b2"></b><b class="b3"></b><b class="b4"></b>
            <div class="content" style="height: 160px; overflow:auto">
                <h3>
                    Respondent criteria: <telerik:RadTextBox  ID="txtAddCriteria" runat="server" 
                        Font-Names="Arial" Font-Size="9pt">
                         <ClientEvents OnKeyPress="OnKeyPress" />  
                        <PasswordStrengthSettings IndicatorWidth="100px" />
                                </telerik:RadTextBox>
                             <telerik:RadButton ID="btnAddCriteria" runat="server"  Text ="Add" Font-Names="Arial" 
                            Font-Size="9pt" Width="80px" Skin="Hay"    >
                             <Icon PrimaryIconUrl="../images/btnadd.gif" PrimaryIconLeft="10" PrimaryIconTop="4" />
                        </telerik:RadButton>

                  </h3>
                <hr align="left" size="1" style="border-style: dotted; color: Aqua;" noshade />
                <div style="padding-left: 20px; padding-top: 0px;">
                    <telerik:RadListBox runat="server" ID="lbCriteria" AllowDelete="true" Height="60px"
                        Width="80%" DataTextField="Criteria" DataValueField="Criteria" AutoPostBackOnDelete="true">
                    </telerik:RadListBox>
                   
                    <table>
                        <tr>
                            <td style="width: 76%;">
                                &nbsp;</td>
                            <td style="text-align: left; padding-left: 5px">
                                &nbsp;</td>
                        </tr>
                    </table>
                </div>
            </div>
            <b class="b5"></b><b class="b6"></b><b class="b7"></b><b class="b8"></b>
        </div>


        <div class="sharp color1" style="width: 48%">
            <b class="b1"></b><b class="b2"></b><b class="b3"></b><b class="b4"></b>
            <div class="content" style="height: 280px; overflow:auto">
                <h3>
                    Timing Task: &nbsp;                           
                           <asp:TextBox ID="txtTimingName" runat="server" Font-Names="Arial" 
                        Font-Size="9pt"></asp:TextBox>
                            
                          <telerik:RadButton ID="btnAdd" runat="server"  Text ="Add" Font-Names="Arial" 
                            Font-Size="9pt" Width="80px" Skin="Hay"  OnClientClicking  ="AddTimingTask"  >
                             <Icon PrimaryIconUrl="../images/btnadd.gif" PrimaryIconLeft="10" PrimaryIconTop="4" />
                        </telerik:RadButton>

                            </h3>
                <hr align="left" size="1" style="border-style: dotted; color: Aqua;" noshade />
                <div style="padding-left: 20px; padding-top: 0px;">
                    
                    <table style="width:98%;height:100%;">
                        <tr>
                            <td style="width: 80%;" >
                                <telerik:RadGrid ID="rgTimingTask" runat="server" AutoGenerateColumns="False" 
                                    GridLines="None" CellSpacing="0">
                                    <MasterTableView AutoGenerateColumns="false" Width="100%">
                                            <CommandItemSettings ExportToPdfText="Export to PDF"></CommandItemSettings>

                                            <RowIndicatorColumn Visible="True" FilterControlAltText="Filter RowIndicator column"></RowIndicatorColumn>

                                            <ExpandCollapseColumn Visible="True" FilterControlAltText="Filter ExpandColumn column"></ExpandCollapseColumn>
                                        <Columns>
                                            <telerik:GridButtonColumn CommandName="Delete" ButtonType="ImageButton" Text="" UniqueName="AutoGeneratedDeleteColumn">
                                                <HeaderStyle Width="20px" />
                                            </telerik:GridButtonColumn>
                                            <telerik:GridBoundColumn DataField="Task" Display="True" HeaderText="Task" UniqueName="TaskColumn">
                                            </telerik:GridBoundColumn>
                                            <telerik:GridBoundColumn DataField="TaskType" Display="True" 
                                                HeaderText="TaskType" UniqueName="TaskTypeColumn">
                                            </telerik:GridBoundColumn>
                                            
                                        </Columns>

                                        <EditFormSettings>
                                        <EditColumn FilterControlAltText="Filter EditCommandColumn column"></EditColumn>
                                        </EditFormSettings>
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
                            </td>
                         
                        </tr>
                       
                    </table>
                </div>
            </div>
            <b class="b5"></b><b class="b6"></b><b class="b7"></b><b class="b8"></b>
        </div>
        <div class="sharp color1" style="width: 48%">
            <b class="b1"></b><b class="b2"></b><b class="b3"></b><b class="b4"></b>
            <div class="content" style="height: 280px; overflow:auto">
                <h3>
                    Quotation Task : <asp:TextBox ID="txtQuotationName" runat="server"></asp:TextBox>
                           
                         <telerik:RadButton ID="btnQuoAdd" runat="server"  Text ="Add" Font-Names="Arial" 
                            Font-Size="9pt" Width="80px" Skin="Hay"  OnClientClicking  ="AddQuotationTask"  >
                             <Icon PrimaryIconUrl="../images/btnadd.gif" PrimaryIconLeft="10" PrimaryIconTop="4" />
                        </telerik:RadButton>
                            </h3>
                <hr align="left" size="1" style="border-style: dotted; color: Aqua;" noshade />
                <div style="padding-left: 20px; padding-top: 0px;">
                    
                    <table style="width:98%;height:100%">
                        <tr>
                            <td style="width: 90%;" >
                                <telerik:RadGrid ID="rgQuotationTask" runat="server" 
                                    AutoGenerateColumns="False" GridLines="None" CellSpacing="0">
                                    <MasterTableView AutoGenerateColumns="false" Width="100%">
<CommandItemSettings ExportToPdfText="Export to PDF"></CommandItemSettings>

<RowIndicatorColumn Visible="True" FilterControlAltText="Filter RowIndicator column"></RowIndicatorColumn>

<ExpandCollapseColumn Visible="True" FilterControlAltText="Filter ExpandColumn column"></ExpandCollapseColumn>
                                        <Columns>
                                            <telerik:GridButtonColumn CommandName="Delete" ButtonType="ImageButton" Text="" UniqueName="AutoGeneratedDeleteColumn">
                                                <HeaderStyle Width="20px" />
                                            </telerik:GridButtonColumn>
                                            <telerik:GridBoundColumn DataField="Task" Display="True" HeaderText="Task" UniqueName="TaskColumn">
                                            </telerik:GridBoundColumn>
                                            <telerik:GridBoundColumn DataField="QuotationType" Display="True" 
                                                HeaderText="TaskType" UniqueName="TaskTypeColumn">
                                            </telerik:GridBoundColumn>
                                            
                                        </Columns>

<EditFormSettings>
<EditColumn FilterControlAltText="Filter EditCommandColumn column"></EditColumn>
</EditFormSettings>
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
                            </td>
                            <td style="text-align: left; padding-left: 5px">                           
                                &nbsp;</td>
                        </tr>
                       
                    </table>
                </div>
            </div>
            <b class="b5"></b><b class="b6"></b><b class="b7"></b><b class="b8"></b>
        </div>

        <div class="sharp color1" style="width: 98%">
            <b class="b1"></b><b class="b2"></b><b class="b3"></b><b class="b4"></b>
            <div class="content" id="dvCityCoverage">
                <h3>
                    City coverage</h3>
                <hr align="left" size="1" style="border-style: dotted; color: Aqua;" noshade />
                <telerik:RadAjaxPanel ID="RadAjaxPanel2" runat="server" LoadingPanelID="LoadingPanel2">
                    <table>
                        <tr>
                            <td>
                                <telerik:RadGrid ID="rgStageList" runat="server" AutoGenerateColumns="False" 
                                    GridLines="None" CellSpacing="0">
                                    <MasterTableView AutoGenerateColumns="false" Width="380" >
                                        <CommandItemSettings ExportToPdfText="Export to PDF" />
                                        <RowIndicatorColumn FilterControlAltText="Filter RowIndicator column" 
                                            Visible="True">
                                        </RowIndicatorColumn>
                                        <ExpandCollapseColumn FilterControlAltText="Filter ExpandColumn column" 
                                            Visible="True">
                                        </ExpandCollapseColumn>
                                        <Columns>
                                            <telerik:GridButtonColumn ButtonType="ImageButton" CommandName="Delete" Text="" 
                                                UniqueName="AutoGeneratedDeleteColumn">
                                                <HeaderStyle Width="20px" />
                                            </telerik:GridButtonColumn>
                                            <telerik:GridBoundColumn DataField="ID" Display="False" HeaderText="ID" 
                                                UniqueName="IDColumn" Visible="False">
                                            </telerik:GridBoundColumn>
                                            <telerik:GridBoundColumn DataField="Province" HeaderText="Province" 
                                                Visible="False">
                                            </telerik:GridBoundColumn>
                                            <telerik:GridBoundColumn DataField="City" HeaderText="City">
                                            </telerik:GridBoundColumn>
                                            <telerik:GridBoundColumn DataField="CitySize" HeaderText="CitySize">
                                            </telerik:GridBoundColumn>
                                            <telerik:GridBoundColumn DataField="AddedSize" HeaderText="AddedSize">
                                            </telerik:GridBoundColumn>
                                            <telerik:GridBoundColumn DataField="IncidenceRate" HeaderText="IncidenceRate">
                                            </telerik:GridBoundColumn>
                                        </Columns>
                                        <EditFormSettings>
                                            <EditColumn FilterControlAltText="Filter EditCommandColumn column">
                                            </EditColumn>
                                        </EditFormSettings>
                                    </MasterTableView>
                                    <FilterMenu EnableImageSprites="False">
                                        <WebServiceSettings>
                                            <ODataSettings InitialContainerName="">
                                            </ODataSettings>
                                        </WebServiceSettings>
                                    </FilterMenu>
                                    <HeaderContextMenu CssClass="GridContextMenu GridContextMenu_Default">
                                        <WebServiceSettings>
                                            <ODataSettings InitialContainerName="">
                                            </ODataSettings>
                                        </WebServiceSettings>
                                    </HeaderContextMenu>
                                </telerik:RadGrid>
                            </td>
                            <td>
                                <table style="width: 500px">
                                    <tr>
                                        <td>
                                            District:
                                        </td>
                                        <td>
                                            <asp:DropDownList ID="cbDistrict" runat="server" AutoPostBack="true" 
                                                Width="80px">
                                            </asp:DropDownList>
                                        </td>
                                        <td style="width: 50px; text-align: right">
                                            Province:
                                        </td>
                                        <td class="controlTd">
                                            <asp:DropDownList ID="cbProvince" runat="server" AutoPostBack="true" 
                                                Width="100px">
                                            </asp:DropDownList>
                                        </td>
                                        <td class="textTd" style="width: 40px">
                                            City:
                                        </td>
                                        <td class="controlTd">
                                            <asp:DropDownList ID="cbCity" runat="server" AutoPostBack="true" Width="80px">
                                            </asp:DropDownList>
                                        </td>
                                    </tr>
                                    <tr>
                                        <td>
                                            主样本:
                                        </td>
                                        <td>
                                            <asp:TextBox ID="txtCitySize" runat="server" Font-Names="Arial" Font-Size="9pt" 
                                                Font-Strikeout="False" Width="60px">0</asp:TextBox>
                                        </td>
                                        <td>
                                            追加样本:
                                        </td>
                                        <td>
                                            <asp:TextBox ID="txtAddedSize" runat="server" Font-Names="Arial" 
                                                Font-Size="9pt" Width="60px">0</asp:TextBox>
                                        </td>
                                        <td>
                                            预估发生率:
                                        </td>
                                        <td>
                                            <asp:TextBox ID="txtIncidenceRate" runat="server" Font-Names="Arial" 
                                                Font-Size="9pt" Width="60px">0</asp:TextBox>
                                        </td>
                                    </tr>
                                    <tr>
                                        <td colspan="6" style="text-align: center">
                                          
                                             <telerik:RadButton ID="btnAddCityCoverage" runat="server"  Text ="Add" Font-Names="Arial" 
                                                    Font-Size="9pt" Width="80px" Skin="Hay"  >
                                                     <Icon PrimaryIconUrl="../images/btnadd.gif" PrimaryIconLeft="10" PrimaryIconTop="4" />
                                             </telerik:RadButton>
                                        </td>
                                    </tr>
                                </table>
                            </td>
                        </tr>
                    </table>
                </telerik:RadAjaxPanel>
                <telerik:RadAjaxLoadingPanel BackgroundPosition="Center" EnableSkinTransparency="false"
                    ID="RadAjaxLoadingPanel2" runat="server">
                    <asp:Image ID="Image2" runat="server" ImageUrl="../Images/loading.gif"></asp:Image>
                </telerik:RadAjaxLoadingPanel>
            </div>
            <b class="b5"></b><b class="b6"></b><b class="b7"></b><b class="b8"></b>
        </div>
        <div class="sharp color1" style="width: 98%">
            <b class="b1"></b><b class="b2"></b><b class="b3"></b><b class="b4"></b>
            <div class="content" style="height: 350px">
                <h3>
                    Description</h3>
                <hr align="left" size="1" style="border-style: dotted; color: Aqua;" noshade />
                <div>
                    <telerik:RadEditor ID="reSampleSize" runat="server" Width="90%" Height="300px" ToolsFile="~/Telerik/BasicTools.xml"
                        EditModes="Design, Preview">
                        <Tools>
                            <telerik:EditorToolGroup Tag="MainToolbar">
                                <telerik:EditorTool Name="Print" ShortCut="CTRL+P" />
                                <telerik:EditorTool Name="AjaxSpellCheck" />
                                <telerik:EditorTool Name="FindAndReplace" ShortCut="CTRL+F" />
                                <telerik:EditorTool Name="SelectAll" ShortCut="CTRL+A" />
                                <telerik:EditorTool Name="Cut" />
                                <telerik:EditorTool Name="Copy" ShortCut="CTRL+C" />
                                <telerik:EditorTool Name="Paste" ShortCut="CTRL+V" />
                                <telerik:EditorTool Name="PasteStrip" />
                                <telerik:EditorSeparator />
                                <telerik:EditorTool Name="Undo" ShortCut="CTRL+Z" />
                                <telerik:EditorTool Name="Redo" ShortCut="CTRL+Y" />
                            </telerik:EditorToolGroup>
                            <telerik:EditorToolGroup Tag="InsertToolbar">
                                <telerik:EditorTool Name="ImageManager" ShortCut="CTRL+G" />
                                <telerik:EditorTool Name="DocumentManager" />
                                <telerik:EditorTool Name="FlashManager" />
                                <telerik:EditorTool Name="MediaManager" />
                                <telerik:EditorTool Name="TemplateManager" />
                                <telerik:EditorSeparator />
                                <telerik:EditorTool Name="LinkManager" ShortCut="CTRL+K" />
                                <telerik:EditorTool Name="Unlink" ShortCut="CTRL+SHIFT+K" />
                            </telerik:EditorToolGroup>
                            <telerik:EditorToolGroup>
                                <telerik:EditorTool Name="Superscript" />
                                <telerik:EditorTool Name="Subscript" />
                                <telerik:EditorTool Name="InsertParagraph" />
                                <telerik:EditorTool Name="InsertGroupbox" />
                                <telerik:EditorTool Name="InsertHorizontalRule" />
                                <telerik:EditorTool Name="InsertDate" />
                                <telerik:EditorTool Name="InsertTime" />
                                <telerik:EditorSeparator />
                                <telerik:EditorTool Name="FormatCodeBlock" />
                            </telerik:EditorToolGroup>
                            <telerik:EditorToolGroup>
                                <telerik:EditorTool Name="FormatBlock" />
                                <telerik:EditorTool Name="FontName" ShortCut="CTRL+SHIFT+F" />
                                <telerik:EditorTool Name="RealFontSize" ShortCut="CTRL+SHIFT+P" />
                            </telerik:EditorToolGroup>
                            <telerik:EditorToolGroup>
                                <telerik:EditorTool Name="AbsolutePosition" />
                                <telerik:EditorSeparator />
                                <telerik:EditorTool Name="Bold" ShortCut="CTRL+B" />
                                <telerik:EditorTool Name="Italic" ShortCut="CTRL+I" />
                                <telerik:EditorTool Name="Underline" ShortCut="CTRL+U" />
                                <telerik:EditorTool Name="StrikeThrough" />
                                <telerik:EditorSeparator />
                                <telerik:EditorTool Name="JustifyLeft" />
                                <telerik:EditorTool Name="JustifyCenter" />
                                <telerik:EditorTool Name="JustifyRight" />
                                <telerik:EditorTool Name="JustifyFull" />
                                <telerik:EditorTool Name="JustifyNone" />
                                <telerik:EditorSeparator />
                                <telerik:EditorTool Name="Indent" />
                                <telerik:EditorTool Name="Outdent" />
                                <telerik:EditorSeparator />
                                <telerik:EditorTool Name="InsertOrderedList" />
                                <telerik:EditorTool Name="InsertUnorderedList" />
                                <telerik:EditorSeparator />
                                <telerik:EditorTool Name="ToggleTableBorder" />
                                <telerik:EditorTool Name="XhtmlValidator" />
                            </telerik:EditorToolGroup>
                            <telerik:EditorToolGroup>
                                <telerik:EditorTool Name="ForeColor" />
                                <telerik:EditorTool Name="BackColor" />
                                <telerik:EditorTool Name="ApplyClass" />
                                <telerik:EditorTool Name="FormatStripper" />
                            </telerik:EditorToolGroup>
                            <telerik:EditorToolGroup Tag="DropdownToolbar">
                                <telerik:EditorTool Name="InsertSymbol" />
                                <telerik:EditorTool Name="InsertTable" />
                                <telerik:EditorTool Name="InsertFormElement" />
                                <telerik:EditorTool Name="InsertSnippet" />
                                <telerik:EditorTool Name="ImageMapDialog" />
                                <telerik:EditorTool Name="InsertCustomLink" ShortCut="CTRL+ALT+K" />
                                <telerik:EditorSeparator />
                                <telerik:EditorTool Name="ConvertToLower" />
                                <telerik:EditorTool Name="ConvertToUpper" />
                                <telerik:EditorSeparator />
                                <telerik:EditorTool Name="Zoom" />
                                <telerik:EditorTool Name="ModuleManager" />
                                <telerik:EditorTool Name="ToggleScreenMode" ShortCut="F11" />
                                <telerik:EditorTool Name="AboutDialog" />
                            </telerik:EditorToolGroup>
                        </Tools>
                        <Content>
                        </Content>
                    </telerik:RadEditor>
                </div>
            </div>
            <b class="b5"></b><b class="b6"></b><b class="b7"></b><b class="b8"></b>
        </div>
    </div>
    </div>
    <telerik:RadAjaxManager runat="server" ID="radajax">
        <AjaxSettings>
            <telerik:AjaxSetting AjaxControlID="btnAddCriteria">
                <UpdatedControls>
                    <telerik:AjaxUpdatedControl ControlID="lbCriteria" 
                        LoadingPanelID="RadAjaxLoadingPanel2" UpdatePanelHeight="" />
                </UpdatedControls>
            </telerik:AjaxSetting>
            <telerik:AjaxSetting AjaxControlID="btnAddCityCoverage">
                <UpdatedControls>
                    <telerik:AjaxUpdatedControl ControlID="rgStageList" 
                        LoadingPanelID="RadAjaxLoadingPanel2" UpdatePanelHeight="" />
                </UpdatedControls>
            </telerik:AjaxSetting>
            <telerik:AjaxSetting AjaxControlID="btnAddTiming">
                <UpdatedControls>
                    <telerik:AjaxUpdatedControl ControlID="rgTimingTask" 
                        LoadingPanelID="RadAjaxLoadingPanel2" UpdatePanelHeight="" />
                </UpdatedControls>
            </telerik:AjaxSetting>
            <telerik:AjaxSetting AjaxControlID="btnAddQuotation">
                <UpdatedControls>
                    <telerik:AjaxUpdatedControl ControlID="rgQuotationTask" 
                        LoadingPanelID="RadAjaxLoadingPanel2" UpdatePanelHeight="" />
                </UpdatedControls>
            </telerik:AjaxSetting>
            <telerik:AjaxSetting AjaxControlID="btnMethodologyChange">
                <UpdatedControls>
                    <telerik:AjaxUpdatedControl ControlID="rgTimingTask" 
                        LoadingPanelID="RadAjaxLoadingPanel2" UpdatePanelHeight="" />
                    <telerik:AjaxUpdatedControl ControlID="rgQuotationTask" 
                        LoadingPanelID="RadAjaxLoadingPanel2" UpdatePanelHeight="" />
                </UpdatedControls>
            </telerik:AjaxSetting>
            <telerik:AjaxSetting AjaxControlID="btnMethodologyTypeChange">
                <UpdatedControls>
                    <telerik:AjaxUpdatedControl ControlID="cbMethdologyValue" 
                        LoadingPanelID="RadAjaxLoadingPanel2" />
                    <telerik:AjaxUpdatedControl ControlID="rgTimingTask" 
                        LoadingPanelID="RadAjaxLoadingPanel2" />
                    <telerik:AjaxUpdatedControl ControlID="rgQuotationTask" 
                        LoadingPanelID="RadAjaxLoadingPanel2" />
                </UpdatedControls>
            </telerik:AjaxSetting>
        </AjaxSettings>
    </telerik:RadAjaxManager>
   <asp:Button ID="btnAddTiming" runat="server" CssClass="hiddenBtn" />
   <asp:Button ID="btnAddQuotation" runat="server" CssClass="hiddenBtn" />
   <asp:Button ID="btnMethodologyChange" runat="server" CssClass="hiddenBtn" />
   <asp:Button ID="btnMethodologyTypeChange" runat="server" CssClass="hiddenBtn" />   
   <asp:HiddenField ID="hiddenMethdologyType" runat="server" />
   <asp:HiddenField ID="hiddenMethdology" runat = "server" />
    </form>
</body>
</html>
