<%@ Page Language="VB" AutoEventWireup="false" CodeFile="StageComponentCostingFile.aspx.vb" Inherits="PMS_StageComponentCostingFile" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
    <script src="../js/validation.js" type="text/javascript"></script>
    <script src="../js/operation.js" type="text/javascript"></script>
    <link href="../Css/CornorPanel.css" rel="stylesheet" type="text/css" />
    <style type="text/css">
        .queryButton
        {
            width: 30;
            height: 30;
            padding-bottom: 3px;
        }
        .queryButton img
        {
            
            padding: 0;
            border: none;
            width: 20px;
            height: 20px;
        }
        .hiddenBtn
        {
             display:none
        }
    </style>
    <script type="text/javascript">
        function QueryStage() {
            window.document.getElementById('btnSearchComponent').click();
        }
//        function RowSelected(sender, eventArgs) {
//            var grid = sender;
//            var MasterTable = grid.get_masterTableView(); var row = MasterTable.get_dataItems()[eventArgs.get_itemIndexHierarchical()];
//            var cell = MasterTable.getCellByColumnUniqueName(row, "ComponentName");
//            //here cell.innerHTML holds the value of the cell  
//        }

       
    </script>
</head>
<body>
    <form id="form1" runat="server">
    <div class="wrapper" style="display:none">
        <div class="sharp color1" style="width: 94%;">
            <b class="b1"></b><b class="b2"></b><b class="b3"></b><b class="b4"></b>
            <div class="content" style="height: 40px">
                <div style="padding: 5px">
                    <p style="text-align: center; padding-top: 0px">
                        项目号：<telerik:RadTextBox TabIndex="0" ID="txtJobNumber" runat="server">
                        </telerik:RadTextBox>
                        &nbsp;<span style="vertical-align: bottom">
                            <button tabindex="1" class="queryButton" onclick="javascript:QueryStage()"  type="button" style="height: 26px; width: 80px;">
                                <img src="../Images/png/query.png" alt="" />
                                Query
                            </button>
                        </span>
                    </p>
                </div>
            </div>
            <b class="b5"></b><b class="b6"></b><b class="b7"></b><b class="b8"></b>
        </div>
    </div>
    <div class="sharp color1" style="width: 94%; padding-left: 10px">
        <b class="b1"></b><b class="b2"></b><b class="b3"></b><b class="b4"></b>
        <div class="content" style="height: 500px; overflow:auto">
           
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
                    function ShowFileUploadPage(FileId, ComponentId, FileType) {
                        var randomStr = getRandom()
                        var OperateType = 'Modify';
                        if (FileId == "") {
                            OperateType = "New"
                        }
                        var addResult = window.showModalDialog("CostingFileUploadPage.aspx?OperateType=" + OperateType + "&i=" + randomStr + "&ComponentId=" + ComponentId + "&FileId=" + FileId + "&FileType=" + FileType, window, 'dialogWidth=450px;dialogHeight=280px;center:yes');
                        //refresh the grid,please take care of the control name, maybe not btnQuery.
                        QueryStage();
                    
                    }
                    function RowSelected(sender, eventArgs) {
                        var grid = sender;
                        var MasterTable = grid.get_masterTableView(); 
                        var row = MasterTable.get_dataItems()[eventArgs.get_itemIndexHierarchical()];
                        //var cell = MasterTable.getCellByColumnUniqueName(row, "StageName");
                        //here cell.innerHTML holds the value of the cell  
                    }

                    function SubmitFileButtonEvent(sender, e) {

                        var grid = $find("<%=RadGrid1.ClientID %>");

                        var MasterTable = grid.get_masterTableView();
                        var selectedRows = MasterTable.get_selectedItems();
                        var row = selectedRows[0];
                        var cell = MasterTable.getCellByColumnUniqueName(row, "StageName")
                        var a = "";

                        //alert(e);
                        //$("#uploadFile")[0].click();
                        //            var randomStr = getRandom()
                        //            var FileId;
                        //            var FileType;
                        //            var ComponentId;
                        //            var OperateType = 'Modify';
                        //            var addResult = window.showModalDialog("StageComponentCostingFile.aspx.aspx?OperateType=" + OperateType + "&i=" + randomStr + "&ComponentId=" + ComponentId + "&FileId=" + FileId + "&FileType=" + FileType, window, 'dialogWidth=450px;dialogHeight=280px;center:yes');
                        //            if (addResult == 'success') {
                        //                //refresh the grid,please take care of the control name, maybe not btnQuery.
                        //                QueryStage();
                        //            }
                    }
                    function submitFile(sender, e) {
                        //$("#hiddenUpload")[0].valueOf = "aaaa";
                        $("#btnSubmitFile")[0].click();

                    }
                </script>
                </telerik:RadCodeBlock>
                <telerik:RadGrid ID="RadGrid1" Width="97%" ShowStatusBar="True" GridLines="None"
                    runat="server" AutoGenerateColumns="False" ShowFooter="True" AllowMultiRowSelection="false">
                    <MasterTableView  CommandItemDisplay="None">
                        <CommandItemSettings ExportToPdfText="Export to Pdf"></CommandItemSettings>
                        <Columns>
                            <telerik:GridBoundColumn Groupable="true" UniqueName="StageName" DataField="StageName"
                                HeaderText="StageName" ReadOnly="True">
                            </telerik:GridBoundColumn>
                            <telerik:GridBoundColumn UniqueName="Component" DataField="ComponentName" HeaderText="Component"
                                ReadOnly="True" />
                            <telerik:GridBoundColumn UniqueName="EstimationFile" DataField="ShowName" HeaderText="EstimationFile"
                                ReadOnly="True" />
                                <telerik:GridBoundColumn UniqueName="ActualFle" DataField="ShowName_Actual" HeaderText="ActualFle"
                                ReadOnly="True" />
                            <telerik:GridBoundColumn DataField="CostingFileId" Display="False" HeaderText="CostingFileId" UniqueName="CostingFileIdColumn">
                            </telerik:GridBoundColumn>
                            <telerik:GridBoundColumn DataField="ComponentId" Display="False" HeaderText="ComponentId" UniqueName="ComponentIdColumn">
                            </telerik:GridBoundColumn>
                            <telerik:GridBoundColumn HeaderText="UploadEstimateFile" UniqueName = "OpenEstimateColumn">                            
                            <HeaderStyle Width="30px" />
                            </telerik:GridBoundColumn>
                            <telerik:GridBoundColumn HeaderText="UploadActualFile" UniqueName = "OpenActualColumn">
                            <HeaderStyle Width="30px" />
                            </telerik:GridBoundColumn>
                        </Columns>
                    </MasterTableView>
                    <ClientSettings>
                    <Selecting AllowRowSelect="true" />
                     <ClientEvents OnRowSelected="RowSelected" />
                    </ClientSettings>
                    <SelectedItemStyle BackColor="Fuchsia" BorderColor="Purple" BorderStyle="Dashed" BorderWidth="1px" />
                </telerik:RadGrid>
            </div>
        </div>
        <b class="b5"></b><b class="b6"></b><b class="b7"></b><b class="b8"></b>
    </div>
    <asp:Button ID="btnSearchComponent" runat="server" CssClass="hiddenBtn" />
    <asp:Button ID="btnSubmitFile" runat="server" Text="Submit" Width="0px" Height="0px" CssClass="hiddenBtn"/>
    <<asp:FileUpload ID="uploadFile" runat="server" onchange="javascript:submitFile(this)"  Width="0px" Height="0px" CssClass="hiddenBtn" />
    <asp:HiddenField ID="hiddenUpload" runat="server" />
    </form>
</body>
</html>
