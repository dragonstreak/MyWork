<%@ Page Language="VB" AutoEventWireup="false" CodeFile="ProjectTimingPage.aspx.vb" Inherits="PMS_ProjectTimingPage" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml">
<head id="Head1" runat="server">
    <title></title>
    <link href="../Css/CornorPanel.css" rel="stylesheet" type="text/css" />
    <style type="text/css">
        .ModifyImage
        {
            background-image: url(../Images/png/modify.png);
            width: 10px;
            height: 10px;
        }
        .imgButton
        {
            width: 85;
            height: 43;
            padding-bottom: 3px;
        }
        .imgButton img
        {
            padding: 0;
            border: none;
            width: 35px;
            height: 35px;
        }
        #hiddenBtn
        {
            
            display:none;
             height:0px;
             width:0px;
        }
    </style>
</head>
<body>
    <form id="form1" runat="server">
    <div class="sharp color1" style="width: 97%; padding-left: 10px">
        <b class="b1"></b><b class="b2"></b><b class="b3"></b><b class="b4"></b>
        <div class="content" style="height: 48px">
            <div style="padding: 5px">
                    <p style="text-align: center; padding-top: 0px">
                        
                        <span style="vertical-align: bottom">
                        <button tabindex="1" id="btnImgExport" class="imgButton" onclick="javascript:Export()"  type="button" style="height: 43px; width: 90px;">
                                <img src="../Images/png/Excel.png" alt="" />
                                Export
                            </button>
                            <button tabindex="2"  id="btnUpdateAll" class="imgButton" onclick="javascript:UpdateAllItems(this)"  type="button" style="height: 43px; width: 90px;">
                                <img src="../Images/png/modify.png" alt="" />
                                Update
                            </button>
                            <button tabindex="2" id="btnSaveAll" disabled class="imgButton" onclick="javascript:SaveAllItems(this)"  type="button" style="height: 43px; width: 90px;">
                                <img src="../Images/png/save.png" alt="" />
                                Save
                            </button>
                            <button tabindex="3" id="btnCancelAll" disabled class="imgButton" onclick="javascript:CancelAllEditItems(this)"  type="button" style="height: 43px; width: 90px;">
                                <img src="../Images/png/go-back256.png" alt="" />
                                Cancel
                            </button>
                            <button tabindex="4" class="imgButton" onclick="javascript:CloseWindow()"  type="button" style="height: 43px; width: 90px;">
                                <img src="../Images/png/delete_blue.png" alt="" />
                                Close
                            </button>
                            
                        </span>

                          <span style="float: right; padding-right: 10px; padding-top :20px;">
                            
                          <%--<telerik:RadButton ID="btnReturn" runat="server"  Text ="Return Quotation" Font-Names="Arial" 
                            Font-Size="9pt" Width="120px" Skin="Hay" >
                             <Icon PrimaryIconUrl="../images/Return.png" PrimaryIconLeft="1" PrimaryIconTop="4" />
                        </telerik:RadButton>   --%>
                        <asp:Button ID="btnReturn" runat="server" Text="Return Quotation" Width= "120px" />

                    

                         </span>
                    </p>
                </div>
            
        </div>
        <b class="b5"></b><b class="b6"></b><b class="b7"></b><b class="b8"></b>
    </div>
    <div class="sharp color1" style="width: 97%; padding-left: 10px">
        <b class="b1"></b><b class="b2"></b><b class="b3"></b><b class="b4"></b>
        <div class="content" style="height: 500px; overflow:auto">
            <h3>
                <asp:Label ID="labelStatus" runat="server" Text="Timing"></asp:Label></h3>
            <hr align="left" size="1" style="border-style: dotted; color: Aqua;" noshade />
            <div>
                <telerik:RadScriptManager ID="RadScriptManager1" runat="server">
                    <Scripts>
                        <asp:ScriptReference Assembly="Telerik.Web.UI" Name="Telerik.Web.UI.Common.Core.js" />
                        <asp:ScriptReference Assembly="Telerik.Web.UI" Name="Telerik.Web.UI.Common.jQuery.js" />
                        <asp:ScriptReference Assembly="Telerik.Web.UI" Name="Telerik.Web.UI.Common.jQueryInclude.js" />
                        <asp:ScriptReference Path="~/Plugins/BlockUI.js" />
                    </Scripts>
                </telerik:RadScriptManager>
                <telerik:RadAjaxManager ID="RadAjaxManager1" runat="server">
                    <AjaxSettings>
                        <telerik:AjaxSetting AjaxControlID="wgdCMRTimeCost">
                            <UpdatedControls>
                                <telerik:AjaxUpdatedControl ControlID="wgdCMRTimeCost" />
                            </UpdatedControls>
                        </telerik:AjaxSetting>
                        <telerik:AjaxSetting AjaxControlID="RadGrid1">
                            <UpdatedControls>
                                <telerik:AjaxUpdatedControl ControlID="RadGrid1" />
                                <%--<telerik:AjaxUpdatedControl ControlID="Label1" />--%>
                            </UpdatedControls>
                        </telerik:AjaxSetting>
                    </AjaxSettings>
                </telerik:RadAjaxManager>
                <telerik:RadCodeBlock ID="RadCodeBlock1" runat="server">
                    <script type="text/javascript">
        <!--

                        function Export() {
                            $("#btnExport")[0].click();
                        }
                        var hasChanges, inputs, dropdowns, editedRow;
                        function CloseWindow() {
                            this.close();
                        }
                        function CancelAllEditItems(btnCancel) {
                            btnCancel.disabled = true;
                            $("#btnUpdateAll")[0].disabled = false;
                            $("#btnSaveAll")[0].disabled = true;
                            $("#btnImgExport")[0].disabled = false;
                            $find("<%= RadGrid1.MasterTableView.ClientID %>").cancelAll()
                        }
                        function SaveAllItems(btnSave) {
                            btnSave.disabled = true;
                            $("#btnUpdateAll")[0].disabled = false;
                            $("#btnCancelAll")[0].disabled = true;
                            $("#btnImgExport")[0].disabled = false;
                            $find("<%= RadGrid1.MasterTableView.ClientID %>").updateEditedItems();
                        }
                        function UpdateAllItems(btnUpdate) {
                            btnUpdate.disabled = true;
                            $("#btnSaveAll")[0].disabled = false;
                            $("#btnCancelAll")[0].disabled = false;
                            $("#btnImgExport")[0].disabled = true;
                            $find("<%= RadGrid1.MasterTableView.ClientID %>").editAllItems();
                        }

                        function GridCommand(sender, args) {
                            if (args.get_commandName() != "Edit") {
                                editedRow = null;
                            }
                        }

                        function GridCreated(sender, eventArgs) {
                            var gridElement = sender.get_element();
                            var elementsToUse = [];
                            inputs = gridElement.getElementsByTagName("input");
                            for (var i = 0; i < inputs.length; i++) {
                                var lowerType = inputs[i].type.toLowerCase();
                                if (lowerType == "hidden" || lowerType == "button") {
                                    continue;
                                }
                                var id = inputs[i].id;
                                Array.add(elementsToUse, inputs[i]);
                                inputs[i].onchange = TrackChanges;
                            }

                        }

                        function TrackChanges(e) {
                            hasChanges = true;
                        }
	    -->	
                    </script>
                </telerik:RadCodeBlock>
                
                <telerik:RadGrid ID="RadGrid1" Width="97%" ShowStatusBar="True" runat="server" AutoGenerateColumns="False"
                    ShowFooter="True" AllowMultiRowEdit="true">
                    <MasterTableView DataKeyNames="Id" EditMode="InPlace" CommandItemDisplay="None">
                        <CommandItemSettings ExportToPdfText="Export to Pdf"></CommandItemSettings>
                        <Columns>
                            <%--<telerik:GridEditCommandColumn ButtonType="ImageButton" UniqueName="EditColumn" Visible="false">
                                <HeaderStyle Width="60px" />
                            </telerik:GridEditCommandColumn>--%>
                            <telerik:GridBoundColumn   UniqueName="StageName" DataField="StageName"
                                HeaderText="StageName" ReadOnly="True" HeaderStyle-Width="10%" FooterText="Total">
                                <HeaderStyle Width="200px" />
                            </telerik:GridBoundColumn>
                            <telerik:GridBoundColumn UniqueName="ComponentColumn" DataField="ComponentName" HeaderText="Component" ReadOnly="True"
                                HeaderStyle-Width="25%">
                                <HeaderStyle Width="25%"></HeaderStyle>
                            </telerik:GridBoundColumn>
                            <telerik:GridBoundColumn UniqueName="Task" DataField="Task" HeaderText="Task" ReadOnly="True"
                                HeaderStyle-Width="25%">
                                <HeaderStyle Width="25%"></HeaderStyle>
                            </telerik:GridBoundColumn>
                            <telerik:GridDateTimeColumn UniqueName="StartDateColumn"  DataFormatString="{0:yyyy/M/d}"
                                PickerType="DatePicker" DataField="StartDate" HeaderText="StartDate" HeaderStyle-Width="10%"
                                ColumnEditorID="DateEditor" FooterText=" ">
                                <HeaderStyle Width="10%"></HeaderStyle>
                            </telerik:GridDateTimeColumn>
                            <telerik:GridDateTimeColumn UniqueName="EndDateColumn"  DataFormatString="{0:yyyy/M/d}"
                                PickerType="DatePicker" DataField="EndDate" HeaderText="EndDate" HeaderStyle-Width="10%"
                                ColumnEditorID="DateEditor" FooterText=" ">
                                <HeaderStyle Width="10%"></HeaderStyle>
                            </telerik:GridDateTimeColumn>
                             <telerik:GridBoundColumn UniqueName="WeekCount" DataField="WeekCount" HeaderText="WeekCount"
                                Aggregate="Sum" ReadOnly="true" >
                            </telerik:GridBoundColumn>
                            <telerik:GridBoundColumn UniqueName="DayCount" DataField="DayCount" Aggregate="Sum"
                                HeaderText="DayCount" ReadOnly ="true">
                            </telerik:GridBoundColumn>
                           
                        </Columns>
                    </MasterTableView>
                    <ClientSettings>
                        <ClientEvents OnGridCreated="GridCreated" OnCommand="GridCommand" />
                        <%--<Scrolling AllowScroll="True" UseStaticHeaders="True" />--%>
                        <Scrolling AllowScroll="true" ScrollHeight="400px" />
                    </ClientSettings>
                </telerik:RadGrid>
                <telerik:GridDateTimeColumnEditor ID="DateEditor" runat="server">
                </telerik:GridDateTimeColumnEditor>
            </div>
            
        </div>
        <b class="b5"></b><b class="b6"></b><b class="b7"></b><b class="b8"></b>
    </div>
    <asp:Button ID="btnExport" runat="server" CssClass="hiddenBtn" />
    </form>
</body>
</html>
