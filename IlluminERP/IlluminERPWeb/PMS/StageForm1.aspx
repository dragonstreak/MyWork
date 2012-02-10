<%@ Page Language="VB" AutoEventWireup="false" CodeFile="StageForm.aspx.vb" Inherits="PMS_StageForm" %>



<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
    <script src="../js/validation.js" type="text/javascript"></script>
    <script src="../js/operation.js" type="text/javascript"></script>
    <link href="../Css/CornorPanel.css" rel="stylesheet" type="text/css" />
    <link href="../Css/style.css" rel="stylesheet" type="text/css" />
    <style type="text/css">
        
        .btn
        {
            width: 25px;
            height: 25px;
        }
        
        #stageDiv
        {
            width: 180px;
            font-family :Arial ;
            font-size :9pt;
        }
        #stageDiv div
        {
            background-image: url(../Images/png/Down_blue_1.png);
            background-position: center;
            background-repeat: no-repeat;
            text-align: center;
            width: 140px;
            height: 100px;
        }
        .tableDiv
        {
            width: 140px;
            height: 100px;
            text-align: center;
            vertical-align: middle;
            position: static;
        }
        #leftDiv
        {
            height: 470px;
            position: relative;
            overflow: auto;
        }
        #hiddenBtn
        {
             visibility:hidden
            }
         .ImageColumn
         {
              background-image:url(../Images/Edit.gif);
              background-repeat:no-repeat;
              width:60px
             }
        .style1
        {
            font-family: Arial, Helvetica, sans-serif;
            font-size: small;
        }
    </style>
    <script type="text/javascript">
        function SetStageImage(index) {
            var subDiv = document.getElementById('stageDiv').getElementsByTagName("div");
            subDiv[index].style.backgroundImage = "url(../Images/png/Down_red_1.png)";
        }
        function changeStage(div, stageNumber, index,stageId) {
            var subDiv = window.document.getElementById('stageDiv').getElementsByTagName("div");
            for (var i = 0; i < subDiv.length; i++) {
                subDiv[i].style.backgroundImage = "url(../Images/png/Down_blue_1.png)";
            }
            div.style.backgroundImage = "url(../Images/png/Down_red_1.png)";
            //Refresh Stage component
            window.document.getElementById('hiddenCurrentStage').value = stageNumber;
            window.document.getElementById('hiddenCurrentStageIndex').value = index;
            window.document.getElementById('hiddenCurrentStageId').value = stageId;
            document.getElementById('btnSearchComponent').click();
        }

        function AddStage() {
            var jobNumberInTextBox = window.document.getElementById('tbJobNumber').value;
            var jobNumber = window.document.getElementById('hiddenCurrentProposal').value;
            if (jobNumber != jobNumberInTextBox) {
                alert("Proposal number on searching is not the the one displayed");
                return;
            }
            var maxStageNumber = window.document.getElementById('hiddenMaxStageId').value;
            var randomStr = getRandom()
            var addResult = window.showModalDialog("StageEdit.aspx?OperateType=New&i=" + randomStr + "&jobNumber=" + jobNumber + "&maxStageNumber=" + maxStageNumber, window, 'dialogWidth=450px;dialogHeight=250px;center:yes');
            if (addResult == 'success') {
                //refresh the grid,please take care of the control name, maybe not btnQuery.
                document.getElementById('btnQuery').click();
            }
        }

        function ModifyStage() {
            var jobNumberInTextBox = window.document.getElementById('tbJobNumber').value;
            var jobNumber = window.document.getElementById('hiddenCurrentProposal').value;
            if (jobNumber != jobNumberInTextBox) {
                alert("Proposal number on searching is not the the one displayed");
                return;
            }
            var currentStageId = window.document.getElementById('hiddenCurrentStageId').value;
            if (currentStageId == "undefined")
                return;
            if (currentStageId == "")
                return;
            var randomStr = getRandom()
            var addResult = window.showModalDialog("StageEdit.aspx?OperateType=Modify&i=" + randomStr + "&stageId=" + currentStageId + "&jobNumber=" + jobNumber, window, 'dialogWidth=450px;dialogHeight=280px;center:yes');
            if (addResult == 'success') {
                //refresh the grid,please take care of the control name, maybe not btnQuery.
                document.getElementById('btnQuery').click();
            }
        }
   
        function AddComponent(sender, eventArgs) {
            var currentStageId = window.document.getElementById('hiddenCurrentStageId').value;
            if (currentStageId == "undefined")
                return;
            if (currentStageId == "")
                return;
            var jobNumber = window.document.getElementById('hiddenCurrentProposal').value;
            window.location.href = "ComponentEdit.aspx?OperateType=Create&StageId=" + currentStageId + "&JobNumber=" + jobNumber;
            sender.set_autoPostBack(false);
        }

        function OpenQuotation(sender, eventArgs) {
            var jobNumber = window.document.getElementById('hiddenCurrentProposal').value;
            if (jobNumber == "")
                return;

            window.location.href = "ProposalQuotation.aspx?JobNumber=" + jobNumber;
            sender.set_autoPostBack(false);
        }

        function OpenTiming(sender, eventArgs) {
            var jobNumber = window.document.getElementById('hiddenCurrentProposal').value;
            if (jobNumber == "")
                return;
            window.location.href = "ProposalTiming.aspx?JobNumber=" + jobNumber;
            sender.set_autoPostBack(false);
        }
    </script>
</head>
<body>
    <form id="form1" runat="server">
    <telerik:RadScriptManager ID="RadScriptManager1" runat="server">
    </telerik:RadScriptManager>
   
    <div class="wrapper">
        <div class="sharp color1" style="width: 98%;">
            <b class="b1"></b><b class="b2"></b><b class="b3"></b><b class="b4"></b>
            <div class="content" style="height: 30px; ">
                <div style="padding: 3px">
                    <p style="text-align: center; padding-top: 0px">
                        <span class="style1">项目号：</span>
                        <telerik:RadTextBox ID="tbJobNumber" runat="server" Font-Names="Arial" 
                            Font-Size="9pt">
                        </telerik:RadTextBox>
                        <span style="vertical-align:bottom;">
    
                  <telerik:RadButton ID="btnQuery" runat="server" Text="Query"  
                    Font-Names="Arial" Font-Size="9pt" Width="120px" Skin="Hay" >
                   <Icon PrimaryIconUrl="../images/btnqry.gif" PrimaryIconLeft="10" PrimaryIconTop="4" />
                </telerik:RadButton>
                        </span>
                    
                    </p>
                </div>
            </div>
            <b class="b5"></b><b class="b6"></b><b class="b7"></b><b class="b8"></b>
        </div>
        <div class="sharp color1" style="width: 22%;">
            <b class="b1"></b><b class="b2"></b><b class="b3"></b><b class="b4"></b>
            <div class="content" style="height: 500px;  overflow:hidden ;">
                <h3 style="text-align: center">

                     
                    <img alt="Add" id="btnAddStage" runat="server" onclick="javascript:AddStage();" class="btn"
                        src="../Images/png/add_blue.png" title="Add Stage" />

                   <img alt="Modify" id="btnModifyStage" runat="server" 
                        onclick="javascript:ModifyStage();" class="btn"
                        src="../Images/png/modify.png" title="Modify Stage" />
                   <asp:ImageButton runat="server" CssClass="btn" ID="btnDeleteStage" 
                        ImageUrl="../Images/png/delete_blue.png" ToolTip="Delete Stage" />
                    <%--<img alt="Delete" id="btnDeleteStage" runat="server" onclick="javascript:DeleteStage();" class="btn"
                        src="../Images/png/folder-delete.png" />--%>
                        </h3>
                <hr align="left" size="1" style="border-style: dotted; color: Aqua;" noshade />
                <div id="leftDiv">
                    <div id="stageDiv" runat="server">
                    </div>
                </div>
            </div>
            <b class="b5"></b><b class="b6"></b><b class="b7"></b><b class="b8"></b>
        </div>
        <div class="sharp color1" style="width: 74%">
            <b class="b1"></b><b class="b2"></b><b class="b3"></b><b class="b4"></b>
            <div class="content" style="height: 500px">
                <h3 >
                      
                 <asp:Label ID="lblDescription" runat="server" Font-Bold="True" 
                        ForeColor="#CC0000" Font-Names="Arial" Font-Size="10pt"></asp:Label>
                   </h3>  
                        <hr align="left" size="1" style="border-style: dotted; color: Aqua;" noshade /> 
                <h3>
                      Components
                 </h3>
                
                <div>
                    <%--<telerik:RadAjaxPanel ID="RadAjaxPanel2" runat="server" LoadingPanelID="LoadingPanel2">--%>
                        <telerik:RadGrid ID="rgComponentList" runat="server" 
                        AutoGenerateColumns="False" GridLines="None"
                        ShowFooter ="True" ShowStatusBar="True"
                        >
                            <MasterTableView AutoGenerateColumns="false" Width="100%">
<CommandItemSettings ExportToPdfText="Export to Pdf"></CommandItemSettings>
                                <Columns>
                                    <telerik:GridHyperLinkColumn UniqueName="EditColumn" DataNavigateUrlFormatString="ComponentEdit.aspx?OperateType=Modify&id={0}&StageId={1}&JobNumber={2}" DataNavigateUrlFields="ID,StageId,Jobnumber" Text="  Edit" ItemStyle-CssClass="ImageColumn"  >
                                     
<ItemStyle CssClass="ImageColumn"></ItemStyle>
                                     
                                    </telerik:GridHyperLinkColumn>
                                    <telerik:GridBoundColumn DataField="ID" Display="False" HeaderText="ID" UniqueName="IDColumn">
                                    </telerik:GridBoundColumn>
                                    <telerik:GridBoundColumn DataField="ComponentName" HeaderText="Component Name" 
                                        UniqueName="columnComponentName">
                                        <HeaderStyle HorizontalAlign="Center" />
                                        <ItemStyle HorizontalAlign="Center" />
                                    </telerik:GridBoundColumn>
                                    <telerik:GridBoundColumn DataField="MethodologyTypaName" 
                                        HeaderText="Meth. Type">
                                    </telerik:GridBoundColumn>
                                    <telerik:GridBoundColumn DataField="MethodologyName" HeaderText="Methodology" 
                                        UniqueName="columnMethodologyName">
                                        <HeaderStyle HorizontalAlign="Center" />
                                        <ItemStyle HorizontalAlign="Center" />
                                    </telerik:GridBoundColumn>
                                    <telerik:GridBoundColumn DataField="SampleDesign" HeaderText="SampleDesign" 
                                        Visible="False">
                                    </telerik:GridBoundColumn>
                                </Columns>
                            </MasterTableView>
                        </telerik:RadGrid>
                    <%--</telerik:RadAjaxPanel>--%>
                    <telerik:RadAjaxLoadingPanel BackgroundPosition="Center" EnableSkinTransparency="true"
                        ID="RadAjaxLoadingPanel2" runat="server">
                        <asp:Image ID="Image2" runat="server" ImageUrl="../Images/loading.gif"></asp:Image>
                    </telerik:RadAjaxLoadingPanel>
                     <hr align="left" size="1" style="border-style: dotted; color: Aqua;" noshade /><br>
                    <p style="text-align:center; height:55px">
                   
                   
                    <span style="vertical-align:middle;height:inherit; margin:5px">
                     <telerik:RadButton ID="btnAddcomponent" runat="server" Text="Add Component"   OnClientClicking   ="AddComponent"  
                                Font-Names="Arial" Font-Size="9pt" Width="130px" Skin="Hay" >
                                   <Icon PrimaryIconUrl="../images/component_add.png" PrimaryIconLeft="4" PrimaryIconTop="4" />
                      </telerik:RadButton>    

                 </span>
                    
                    <span style="vertical-align:middle;height:inherit; margin:5px">   
                     <telerik:RadButton ID="btnEditQuotation" runat="server" Text="Edit Quotation"   OnClientClicking   ="OpenQuotation"  
                                Font-Names="Arial" Font-Size="9pt" Width="120px" Skin="Hay" >
                                   <Icon PrimaryIconUrl="../images/cart_edit.png" PrimaryIconLeft="4" PrimaryIconTop="4" />
                      </telerik:RadButton>                    
                    </span>

                    <span style="vertical-align:middle;height:inherit; margin:5px;">                    
                      <telerik:RadButton ID="btnEditTiming" runat="server" Text="Edit Timing"   OnClientClicking   ="OpenTiming"  
                                Font-Names="Arial" Font-Size="9pt" Width="120px" Skin="Hay" >
                                   <Icon PrimaryIconUrl="../images/calendar_edit.png" PrimaryIconLeft="4" PrimaryIconTop="4" />
                      </telerik:RadButton>   
                      </span>                     
                    </p>
                </div>
                 
            </div>
           
            <b class="b5"></b><b class="b6"></b><b class="b7"></b><b class="b8"></b>
        </div>
        <telerik:RadAjaxManager ID="RadAjaxManager1" runat="server" 
            DefaultLoadingPanelID="RadAjaxLoadingPanel2">
            <AjaxSettings>
                <telerik:AjaxSetting AjaxControlID="rgComponentList">
                    <UpdatedControls>
                        <telerik:AjaxUpdatedControl ControlID="rgComponentList" UpdatePanelHeight="" />
                        <telerik:AjaxUpdatedControl ControlID="btnSearchComponent" 
                            UpdatePanelHeight="" />
                    </UpdatedControls>
                </telerik:AjaxSetting>
                <telerik:AjaxSetting AjaxControlID="btnSearchComponent">
                    <UpdatedControls>
                        <telerik:AjaxUpdatedControl ControlID="lblDescription" 
                            UpdatePanelHeight="" />
                        <telerik:AjaxUpdatedControl ControlID="rgComponentList" UpdatePanelHeight="" />
                    </UpdatedControls>
                </telerik:AjaxSetting>
            </AjaxSettings>
        </telerik:RadAjaxManager>
    </div>
   
        <asp:Button ID="btnSearchComponent" runat="server" CssClass="hiddenBtn" />
   
    
    <asp:HiddenField ID="hiddenCurrentProposal" runat="server" />
    <asp:HiddenField ID="hiddenCurrentStage" runat="server" />
    <asp:HiddenField ID="hiddenCurrentStageId" runat="server" />
    <asp:HiddenField ID="hiddenCurrentStageIndex" runat="server" />
    <asp:HiddenField ID="hiddenMaxStageId" runat="server" />
    </form>
</body>
</html>
