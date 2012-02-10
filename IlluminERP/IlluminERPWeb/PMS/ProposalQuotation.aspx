<%@ Page Language="VB" AutoEventWireup="false" CodeFile="ProposalQuotation.aspx.vb"
    Inherits="PMS_ProposalQuotation" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
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
        .sharp .content .quotationDiv
        {
            text-align:center; 
            height: 80px; 
            overflow:auto; 
            padding:0px; 
            margin:0px;
          
            }
        .sharp .content .quotationDiv .itemDiv
        {
            padding:0px;
             margin:0px;
        }
        #hiddenBtn
        {
            visibility: hidden;
        }
    </style>
    
</head>
<body>
    <form id="form1" runat="server" method="post">
    <telerik:RadStyleSheetManager ID="RadStyleSheetManager1" runat="server">
    </telerik:RadStyleSheetManager>
    <div class="sharp color1" style="width: 97%; padding-left: 10px">
        <b class="b1"></b><b class="b2"></b><b class="b3"></b><b class="b4"></b>
        <div class="content" style="height: 48px">
            <div style="padding: 5px">
                <p style="text-align: center; padding-top: 0px">
                    <span style="vertical-align: bottom; padding:0px">
                        <button id="btnImgExport" class="imgButton" onclick="javascript:Export()"
                            type="button" style="height: 43px; width: 90px;">
                            <img src="../Images/png/Excel.png" alt="" />
                            Export
                        </button>
                       
                   
                       <button id="btnUpdateAll" class="imgButton" onclick="javascript:UpdateAllItems(this)"
                            type="button" style="height: 43px; width: 90px;">
                            <img src="../Images/png/modify.png" alt="" />
                            Update
                        </button>
                        <button tabindex="2" id="btnSaveAll" disabled class="imgButton" onclick="javascript:SaveAllItems(this)"
                            type="button" style="height: 43px; width: 90px;">
                            <img src="../Images/png/save.png" alt="" />
                            Save
                        </button>
                        <button tabindex="3" id="btnCancelAll" disabled class="imgButton" onclick="javascript:CancelAllEditItems(this)"
                            type="button" style="height: 43px; width: 90px;">
                            <img src="../Images/png/go-back256.png" alt="" />
                            Cancel
                        </button>
                        <button tabindex="4" class="imgButton" onclick="javascript:CloseWindow()" type="button"
                            style="height: 43px; width: 90px;">
                            <img src="../Images/png/delete_blue.png" alt="" />
                            Close
                        </button>

                    </span>

                       <span style="float: right; padding-right: 10px;padding-top :20px;">
                            
                          <telerik:RadButton ID="btnReturn" runat="server"  Text ="Return Stage" Font-Names="Arial" 
                            Font-Size="9pt" Width="120px" Skin="Hay" >
                             <Icon PrimaryIconUrl="../images/Return.png" PrimaryIconLeft="1" PrimaryIconTop="4" />
                        </telerik:RadButton>   

                           <telerik:RadButton ID="btnNext" runat="server"  Text ="Go Timing" Font-Names="Arial" 
                            Font-Size="9pt" Width="100px" Skin="Hay" >
                             <Icon PrimaryIconUrl="../images/next.png" PrimaryIconLeft="1" PrimaryIconTop="4" />
                        </telerik:RadButton>   

                         </span>
                </p>
            </div>
        </div>
        <b class="b5"></b><b class="b6"></b><b class="b7"></b><b class="b8"></b>
    </div>
    <div class="sharp color1" style="width: 97%; padding-left: 10px">
        <b class="b1"></b><b class="b2"></b><b class="b3"></b><b class="b4"></b>
        <div class="content" style="height: 500px">
            <h3>
                <asp:Label ID="labelStatus" runat="server" Text="Quotation"></asp:Label></h3>
          
             
            <hr align="left" size="0" style="border-style: dotted; color: Aqua;" noshade />

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
                                <telerik:AjaxUpdatedControl ControlID="spanActuralTtal" UpdatePanelHeight="" />
                                <telerik:AjaxUpdatedControl ControlID="spanTotal" UpdatePanelHeight="" />
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
                            //$("#EditStatus")[0].value = "";
                            $find("<%= RadGrid1.MasterTableView.ClientID %>").updateEditedItems();                           
                        }
                        function UpdateAllItems(btnUpdate) {
                            btnUpdate.disabled = true;
                            $("#btnSaveAll")[0].disabled = false;
                            $("#btnCancelAll")[0].disabled = false;
                            $("#btnImgExport")[0].disabled = true;
                            //$("#EditStatus")[0].value = "Editing";
                            $find("<%= RadGrid1.MasterTableView.ClientID %>").editAllItems();
                            
                        }
                        var hasChanges, inputs, dropdowns, editedRow;

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

                                Array.add(elementsToUse, inputs[i]);
                                inputs[i].onchange = TrackChanges;
                            }

                            dropdowns = gridElement.getElementsByTagName("select");
                            for (var i = 0; i < dropdowns.length; i++) {
                                dropdowns[i].onchange = TrackChanges;
                            }

                            setTimeout(function () { if (elementsToUse[0]) elementsToUse[0].focus(); }, 100);
                        }

                        function TrackChanges(e) {
                            hasChanges = true;
                        }
	    -->	
                    </script>
                </telerik:RadCodeBlock>
                
                <telerik:RadGrid ID="RadGrid1"  ShowStatusBar="True" 
                    runat="server" AutoGenerateColumns="False" ShowFooter="True" 
                    AllowMultiRowEdit="True" GridLines="None">
                    <GroupHeaderItemStyle Font-Bold="False" Font-Italic="False" 
                        Font-Overline="False" Font-Strikeout="False" Font-Underline="False" 
                        VerticalAlign="Middle" Wrap="True" />
                    <MasterTableView DataKeyNames="Id" EditMode="InPlace" CommandItemDisplay="None">
                        <CommandItemSettings ExportToPdfText="Export to Pdf"></CommandItemSettings>
                        <Columns>
                            <%--<telerik:GridEditCommandColumn ButtonType="ImageButton" UniqueName="EditColumn" Visible="false">
                                <HeaderStyle Width="60px" />
                            </telerik:GridEditCommandColumn>--%>
                            <telerik:GridBoundColumn  UniqueName="StageName" DataField="StageName"
                                HeaderText="StageName" ReadOnly="True" FooterText="Total" HeaderStyle-Width="10%" >
                                <FooterStyle Font-Bold="False" Font-Italic="False" Font-Overline="False" 
                                    Font-Strikeout="False" Font-Underline="False" Wrap="True" />
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
                            
                            <telerik:GridNumericColumn UniqueName="Option1Fee" DataField="Option1Fee" HeaderText="Quotation"
                                ColumnEditorID="Option1FeeEditor" Aggregate="Sum" FooterText=" " DataFormatString="{0:N2}" />
                          
                            <telerik:GridNumericColumn UniqueName="ActualColumn" DataField="ActuralFee" HeaderText="Direct Cost"
                                ColumnEditorID="ActuralFeeEditor" Aggregate="Sum" FooterText=" " DataFormatString="{0:N2}" />
                        </Columns>
                        <EditItemStyle Font-Bold="False" Font-Italic="False" Font-Overline="False" 
                            Font-Strikeout="False" Font-Underline="False" HorizontalAlign="Center" 
                            VerticalAlign="Middle" Wrap="True" />
                        <FooterStyle Font-Bold="False" Font-Italic="False" Font-Overline="False" 
                            Font-Strikeout="False" Font-Underline="False" Wrap="True" />
                    </MasterTableView>
                    <ClientSettings>
                        <ClientEvents OnGridCreated="GridCreated" OnCommand="GridCommand" />
                        <Scrolling AllowScroll="true" ScrollHeight="216px" />
                    </ClientSettings>
                </telerik:RadGrid>
                <telerik:GridNumericColumnEditor ID="Option1FeeEditor" runat="server"  />
                <telerik:GridNumericColumnEditor ID="ActuralFeeEditor" runat="server"  />
            </div>
            
                    
                    
        </div>
        <b class="b5"></b><b class="b6"></b><b class="b7"></b><b class="b8"></b>
    </div>
    <asp:Button ID="btnExport" runat="server" Width="0px" Height="0px" CssClass="hiddenBtn" />
    <%--<asp:HiddenField ID="EditStatus" runat="server" />--%>
    </form>
</body>
</html>
