<%@ Page Title="" Language="VB" MasterPageFile="~/Master/IlluminMasterPage.master" AutoEventWireup="false" CodeFile="Project.aspx.vb" Inherits="PMS_Project" %>

<asp:Content ID="ChildPageHead" ContentPlaceHolderID="head" runat="server">

    <title>Proposal Management</title>
    <meta http-equiv="X-UA-Compatible" content="IE=EmulateIE7" />
    <base target="_self" />
    <script src="../js/operation.js" type="text/javascript"></script>
    <link href="../css/style.css" rel="stylesheet" type="text/css" />
       <script type="text/javascript" >
           function refresh() {
               document.getElementById("btnRefresh").click();
           }

           function refreshparent() {
               if (window.opener != null)
                   window.opener.refresh();
           }

           function CloseWindow() {
               this.close();
           }


           function onClientBeforeClose(sender, arg) {
               function callbackFunction(arg) {
                   if (arg) {
                       sender.remove_beforeClose(onClientBeforeClose);
                       sender.close();
                   }
               }
               arg.set_cancel(true);
               radconfirm("Close form : Are you sure?", callbackFunction, 300, 100, null, "Close form!");
           } 
	    </script>
    
      
        <style type="text/css">
          
            #divpanel {
                 width :640px;
                height: 100px;
                float:left;
                display: yes;
              
            }
  
            .btn-slide {
                background: url(../images/btnDN.gif) no-repeat;
                width: 18px;
                height: 18px;
                display: block;
              
            }
            .active {
                background: url(../images/btnUP.gif) no-repeat;
            }
         
                     .multipleRowsColumns .rcbItem, .multipleRowsColumns .rcbHovered
                    {
                        float: left;
                        margin: 0 1px;
                        min-height: 13px;
                        overflow: hidden;
                        padding: 2px 19px 2px 6px;
                        width: 150px;
                    }
                    html.rfdButton a.rfdSkinnedButton 
                 {
                 vertical-align: middle;
                 margin: 0 0 0 5px;
                 }
                 label
                 {
                 display: inline-block;
                 width: 200px;
                 text-align: right;
                 padding-right: 5px;
                 margin-top: 10px;
                 }
                    * html.rfdButton a.rfdSkinnedButton,
                 * html.rfdButton input.rfdDecorated
                 {
                     vertical-align: top;
                 }
    </style>


</asp:Content>

<asp:Content ID="ChildPageBody" ContentPlaceHolderID="PageContentPlaceHolder" runat="server" >	
    <form id="form1" runat="server" >
             <table cellspacing="1" cellpadding="1" class="info" >
              <tbody>
               
                <tr >
                    <td class ="title" colspan="4">
                        Project Information</td>
                </tr>
               
                <tr >
                    <td class ="lable">
                        <span class="red">*</span>
                        Job Number:</td>
                    <td align ="left" class="value"  >
                        <telerik:RadTextBox ID="txtJobnumber" Runat="server" 
                            Skin="Windows7" Width="200px" BackColor="#F0F0F0" Enabled="False">
                        </telerik:RadTextBox>
                    </td>
                    <td class="lable">
                        <span class="red">*</span> Job Name:</td>
                    <td class="value" >
                        <telerik:RadTextBox ID="txtJobName" Runat="server" Skin="Windows7" 
                            Width="200px">
                        </telerik:RadTextBox>
                    </td>
                </tr>
                <tr>
                    <td class="lable">
                        <span class="red">*</span> Business Unit:
                    </td>
                    <td align ="left"  >
                        <telerik:RadComboBox ID="cbBusinessUnit" Runat="server" Skin="Windows7" 
                            Width="200px" AutoPostBack="True">
                        </telerik:RadComboBox>
                    </td>
                    <td class="lable">
                        <span class="red">*</span>
                        Probability(%):
                    </td>
                    <td >
                        <telerik:RadNumericTextBox ID="txtProbablity" runat="server"
                            Type="Percent" MaxValue="100" MinValue="0" Skin="Windows7" Width="200px">
                            <NumberFormat AllowRounding="True" DecimalDigits="0" />
                        </telerik:RadNumericTextBox>
                    </td>
                </tr>
                <tr>
                    <td class="lable">
                        <span class="red">*</span>
                        Client:
                    </td>
                    <td colspan="3">
            <div style="text-align: left">
                
                <telerik:RadComboBox ID="cbClient" Runat="server" 
                    Filter="Contains" Skin="Windows7" Width="455px">
                </telerik:RadComboBox>
                
                <asp:Button ID="btnAddClient" runat="server" Font-Names="Arial" Font-Size="9pt" 
                    Text="New client" Width="65px" />
                
            </div>     


             
                    </td>
                </tr>
                <tr>
                    <td colspan="4" >&nbsp;</td>
                </tr>
                <tr>
                    <td class="lable">
                        <span class="red">*</span>
                        Sector:</td>
                    <td    >
                        <telerik:RadComboBox ID="cbSector" Runat="server" Skin="Windows7" Width="200px"
                       AutoPostBack="True">
                        </telerik:RadComboBox>
                    </td>
                    <td class="lable">
                        <span class="red">*</span>
                        Product Category:
                    </td>
                    <td  >
                        <telerik:RadComboBox ID="cbProductCategory" Runat="server" Skin="Windows7" 
                            Width="200px" >
                        </telerik:RadComboBox>
                    </td>
                </tr>
                <tr>
                    <td class="lable">
                        <span class="red">*</span>
                        Study Type:</td>
                    <td colspan="3"    >
                        <telerik:RadComboBox ID="cbStudytype" Runat="server" Skin="Windows7" 
                            Width="520px"   DropDownCssClass="multipleRowsColumns" 
                            DropDownWidth="400px" CheckBoxes="True" CheckedItemsTexts="DisplayAllInInput">
                        </telerik:RadComboBox>
                    </td>
                </tr>
                <tr>
                    <td class="lable">
                        Pro.Confidentiality:</td>
                    <td    >
                        <telerik:RadComboBox ID="cbConfidential" Runat="server" Skin="Windows7" 
                            Width="200px">
                            <Items>
                                <telerik:RadComboBoxItem runat="server" Selected="True" Text="Open" Value="1" />
                                <telerik:RadComboBoxItem runat="server" Text="Confidential" Value="2" />
                            </Items>
<WebServiceSettings>
<ODataSettings InitialContainerName=""></ODataSettings>
</WebServiceSettings>
                        </telerik:RadComboBox>
                    </td>
                    <td class="lable">
                        Proposal Rating:</td>
                    <td  >
                        <telerik:RadComboBox ID="cbRating" Runat="server" Skin="Windows7" 
                            Width="200px" Font-Names="Arial" Font-Size="9pt">
                            <Items>
                                <telerik:RadComboBoxItem runat="server" Selected="True" Text="decent proposal" 
                                    Value="0" />
                                <telerik:RadComboBoxItem runat="server" Text="worth reading" Value="1" />
                            </Items>
                        </telerik:RadComboBox>
                    </td>
                </tr>
                <tr>
                    <td  colspan="4">&nbsp;</td>
                </tr>
                <tr>
                    <td class="lable">
                        Project owner:</td>
                    <td    >
                        <telerik:RadComboBox ID="cbProjectOwner" Runat="server" Skin="Windows7" 
                            Width="200px">
                        </telerik:RadComboBox>
                    </td>
                    <td class="lable">
                        &nbsp;</td>
                    <td >
                        &nbsp;</td>
                </tr>
                <tr>
                    <td class="lable">
                        Prepared By:
                    </td>
                    <td    >
                        <telerik:RadTextBox ID="txtPrepared" Runat="server" Wrap="False" 
                            Skin="Windows7" Width="200px" BackColor="#F0F0F0">
                        </telerik:RadTextBox>
                    </td>
                    <td class="lable">
                        Proposal Date:
                    </td>
                    <td >
                        <telerik:RadTextBox ID="txtCreateDate" Runat="server" Wrap="False" 
                            Skin="Windows7" Width="200px">
                        </telerik:RadTextBox>
                    </td>
                </tr>
                <tr>
                    <td colspan="4">&nbsp;</td>
                </tr>
                <tr>
                   <td class="lable" style="height: 15px">
                        Brief Description of the study:
                    </td>
                    <td colspan="3"  >
                        <telerik:RadTextBox ID="txtDescription" Runat="server" 
                            TextMode="MultiLine" Skin="Windows7" Width="520px">
                        </telerik:RadTextBox>
                    </td>
                </tr>
                <tr>
                   <td class="lable" style="height: 15px">
                        Project Keywords:</td>
                    <td colspan="3"  >
                        <telerik:RadTextBox ID="txtKeywords" Runat="server" 
                            TextMode="MultiLine" Skin="Windows7" Width="520px">
                        </telerik:RadTextBox>
                    </td>
                </tr>
                <tr>
                    <td colspan="4" align="center" style =" height:28px;">

                          <div style="text-align: center ">
                        <telerik:RadButton ID="btnSave" runat="server"  Text ="Save" Font-Names="Arial" 
                            Font-Size="9pt" Width="100px" Skin="Hay" >

                             <Icon PrimaryIconUrl="../images/save.png" PrimaryIconLeft="10" PrimaryIconTop="4" />
                        </telerik:RadButton>
                        &nbsp;&nbsp;&nbsp;&nbsp;
                        <telerik:RadButton ID="btnClose" runat="server" Font-Names="Arial" 
                            Font-Size="9pt" 
                            onclientclick="javascript:CloseWindow();" Text="Close" Width="100px" 
                            Skin="Hay" Visible="False">

                            <Icon PrimaryIconUrl="../images/cancel.png" PrimaryIconLeft="10" PrimaryIconTop="4" />
                        </telerik:RadButton>
              
                        </div> 
                        </td>
                </tr>
                </tbody>
            </table>
            <div >
               <table cellspacing="1" cellpadding="1"  class="button">
                <tbody>
                    <tr>
                        <td>
                         
                            <asp:Button ID="btnDesign" runat="server" Font-Names="Arial" Font-Size="9pt" 
                                height="28px" Text="Design" width="120px" />
&nbsp;<asp:Button ID="btnQuotation" runat="server" Font-Names="Arial" Font-Size="9pt" height="28px" 
                                Text="Quotation" width="120px" />
&nbsp;<asp:Button ID="btnSchedule" runat="server" Font-Names="Arial" Font-Size="9pt" height="28px" 
                                Text="Schedule " width="120px" />
&nbsp;<asp:Button ID="btnTeamAssignment" runat="server" Font-Names="Arial" Font-Size="9pt" height="28px" 
                                Text="Team assignment" Width="120px" Visible="False" />
                                <asp:Button ID="btnStatus" runat="server" Font-Names="Arial" Font-Size="9pt" height="28px" 
                                Text="Update Project Status" Width="140px" Visible="False" />
                        </td>
                     </tr>
                     <tr>
                        <td>
                         
                            <asp:Button ID="btnUploadCost" runat="server" Font-Names="Arial" Font-Size="9pt" 
                                height="28px" Text="Upload Cost File" width="120px" />
                                &nbsp;<asp:Button ID="btnEstimateCost" runat="server" Font-Names="Arial" Font-Size="9pt" height="28px" 
                                Text="Estimate Cost" width="120px" />
                                &nbsp;<asp:Button ID="btnActualCost" runat="server" Font-Names="Arial" Font-Size="9pt" height="28px" 
                                                                Text="Actual Cost" width="120px" />
                                &nbsp;<asp:Button ID="btnCostAnalysis" runat="server" Font-Names="Arial" Font-Size="9pt" height="28px" 
                                                                Text="Cost analysis" width="120px" />
                        </td>
                     </tr>
                </tbody>
              </table>
                
            </div>     


             
             <telerik:RadWindowManager ID="RadWindowManager1" runat="server" 
                 EnableShadow="True" Skin="Telerik"  
                 Behaviors="Resize, Minimize, Close, Maximize, Move">
                 <Windows>
                   <telerik:RadWindow ID="RadWindow1" runat="server" Width="850px" Height="650px" Modal="true"    EnableShadow="true"  
                        OnClientBeforeClose   ="onClientBeforeClose">
                        
                   
                </telerik:RadWindow>

                   <telerik:RadWindow ID="RadWindow3" runat="server" Width="650px" Height="450px" Modal="true"    EnableShadow="true"  
                        OnClientBeforeClose   ="onClientBeforeClose" >
                        
                   
                </telerik:RadWindow>

                <telerik:RadWindow ID="RadWindow2" runat="server" Width="850px" Height="650px" Modal="true"
                     OnClientBeforeClose   ="onClientBeforeClose"
                   >
                </telerik:RadWindow>
                  <telerik:RadWindow ID="StageWindow" runat="server" Width="980px" Height="650px"   Modal="true"  EnableShadow="true" 
                        OnClientBeforeClose   ="onClientBeforeClose"
                   
                   > 
                        
                   
                </telerik:RadWindow>
        </Windows>
             </telerik:RadWindowManager>
             

             <telerik:RadScriptManager ID="RadScriptManager1" Runat="server">
                <Scripts>
                    <asp:ScriptReference Assembly="Telerik.Web.UI" Name="Telerik.Web.UI.Common.Core.js" />
                    <asp:ScriptReference Assembly="Telerik.Web.UI" Name="Telerik.Web.UI.Common.jQuery.js" />
                </Scripts>
             </telerik:RadScriptManager>

             
              <telerik:RadAjaxManager ID="RadAjaxManager1" runat="server" 
              >
             </telerik:RadAjaxManager>

             
              <script type="text/javascript">


                  (function ($) {
                      $(document).ready(function () {

                          $(".btn-slide").click(function () {
                              $("#panel").slideToggle("slow");
                              $(this).toggleClass("active"); return false;
                          });
                      });
                  })($telerik.$);
                </script>
            
             <Div id="divaddon" style=" width:750px; " runat=server >
                <table cellpadding="0" cellspacing="3" style=" float:left;margin:10px 5px 5px 20px;" >
                    <tr>
                         <td>
                               <a href="#" class="btn-slide" title="Advanced Search"></a>
                        </td>

                        <td style="font-family: Arial, Helvetica, sans-serif; font-size: 9pt">
                            Project add  on 
                         </td>
                          <td>
                                <telerik:RadButton ID="btnAddon" runat="server" Text="Add"    width="82px" Font-Names="Arial" Font-Size="9pt">
                                           <Icon PrimaryIconUrl="../images/btnadd.gif" PrimaryIconLeft="10" PrimaryIconTop="4" />
                                </telerik:RadButton>
                           
                        </td>

                       
                    </tr>
                   
                </table>
                 <br />
                 <br />
                <div id="divpanel"  style=" width:640px; " runat=server >
                    
                                      
                             
                    <telerik:RadGrid ID="radGridAddon" runat="server" Skin="Simple" 
                        AllowPaging="True" AllowSorting="True" AutoGenerateColumns="False" 
                        GridLines="None" Width="640px" style="margin:10px 5px 5px 20px;">
                        <ClientSettings AllowColumnsReorder="True" ReorderColumnsOnClient="True">
                            <Selecting AllowRowSelect="True" />
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
        <telerik:GridBoundColumn DataField="Id" UniqueName="column" Visible="False">
        </telerik:GridBoundColumn>
        <telerik:GridBoundColumn DataField="JobNumber" HeaderText="Job Number" 
            UniqueName="columnJobnumber">
            <HeaderStyle HorizontalAlign="Center" Width="50px" />
            <ItemStyle HorizontalAlign="Left" />
        </telerik:GridBoundColumn>
        <telerik:GridBoundColumn DataField="JobName" HeaderText="Job name" 
            UniqueName="columnjobname">
            <HeaderStyle HorizontalAlign="Center" Width="50px" />
            <ItemStyle HorizontalAlign="Left" />
        </telerik:GridBoundColumn>
        <telerik:GridBoundColumn DataField="ClientId" HeaderText="Client" 
            UniqueName="columnclientid">
            <HeaderStyle HorizontalAlign="Center" Width="200px" />
            <ItemStyle HorizontalAlign="Left" />
        </telerik:GridBoundColumn>
    </Columns>
</MasterTableView>
                    </telerik:RadGrid>
                    
                                      
                             
                </div>
        
        </Div>
         <script type="text/javascript">

             //             var productcategoryCombo;
             //           

             //             function pageLoad() {
             //                 // initialize the global variables
             //                 // in this event all client objects 
             //                 // are already created and initialized 
             //                 productcategoryCombo = $find("<%= cbProductCategory.ClientID %>");
             //                  }




             //               function Loadproductcategory(sender, eventArgs) {
             //                      var item = eventArgs.get_item();
             //                      productcategoryCombo.set_text("Loading...");
             //                      productcategoryCombo.clearSelection();

             //                      // if a continent is selected
             //                      if (item.get_index() > 0) {
             //                          // this will fire the ItemsRequested event of the 
             //                          // countries combobox passing the continentID as a parameter 
             //                          productcategoryCombo.requestItems(item.get_value(), false);
             //                      }
             //                      else {
             //                          // the -Select a continent- item was chosen
             //                          productcategoryCombo.set_text(" ");
             //                          productcategoryCombo.clearItems();

             //                      }
             //                  }


             //           function ItemsLoaded(sender, eventArgs)
             //            {    
             //                if (sender.get_items().get_count() > 0) {
             //                 // pre-select the first item
             //                    sender.set_text(sender.get_items().getItem(0).get_text());
             //                    sender.get_items().getItem(0).highlight();
             //                }

             //                sender.showDropDown();

             //            }

             function GetRadWindow() {
                 var oWindow = null;
                 if (window.radWindow) oWindow = window.radWindow;
                 else if (window.frameElement.radWindow) oWindow = window.frameElement.radWindow;
                 return oWindow;
             }



             function openWin(sproid) {
                 var oWnd = window.radopen("proposal.aspx?type=addon&sproid=" + sproid, "RadWindow2");
                 return false;
             }

             function hide() {
                 if (window.event.keyCode == 13)
                     window.event.keyCode = 0;
                 return false;
             }


             function openQuotationWin(JobNumber) {
                 var oWnd = window.radopen("ProjectQuotationPage.aspx?JobNumber=" + JobNumber, "RadWindow1");
                 var bounds = oWnd.getWindowBounds();
                 var x = bounds.x;
                 var y = bounds.y;
                 oWnd.moveTo(x, 1);
                 return false;
             }

             function openScheduleWin(JobNumber) {
                 var oWnd = window.radopen("ProjectTimingPage.aspx?JobNumber=" + JobNumber, "RadWindow1");
                 var bounds = oWnd.getWindowBounds();
                 var x = bounds.x;
                 var y = bounds.y;
                 oWnd.moveTo(x, 1);
                 return false;
             }

             function openStageComponentCostingFileWin(JobNumber) {
                 var oWnd = window.radopen("StageComponentCostingFile.aspx?JobNumber=" + JobNumber, "RadWindow1");
                 var bounds = oWnd.getWindowBounds();
                 var x = bounds.x;
                 var y = bounds.y;
                 oWnd.moveTo(x, 1);
                 return false;
             }

             function openEstimateCostWin(JobNumber) {
                 var oWnd = window.radopen("EstimatedCostPage.aspx?CostType=Estimate&JobNumber=" + JobNumber, "RadWindow1");
                 var bounds = oWnd.getWindowBounds();
                 var x = bounds.x;
                 var y = bounds.y;
                 oWnd.moveTo(x, 1);
                 return false;
             }

             function openActualCostWin(JobNumber) {
                 var oWnd = window.radopen("EstimatedCostPage.aspx?CostType=Actual&JobNumber=" + JobNumber, "RadWindow1");
                 var bounds = oWnd.getWindowBounds();
                 var x = bounds.x;
                 var y = bounds.y;
                 oWnd.moveTo(x, 1);
                 return false;
             }

             function openCostAnalysisWin(JobNumber) {
                 var oWnd = window.radopen("ProjectProfit.aspx?JobNumber=" + JobNumber, "RadWindow1");
                 var bounds = oWnd.getWindowBounds();
                 var x = bounds.x;
                 var y = bounds.y;
                 oWnd.moveTo(x, 1);
                 return false;
             }
             
             function openTeamWin(id) {
                 var oWnd = window.radopen("TeamAssignment.aspx?ProId=" + id, "RadWindow3");
                 var bounds = oWnd.getWindowBounds();
                 var x = bounds.x;
                 var y = bounds.y;
                 // oWnd.moveTo(x, 1);
                 return false;
             }

             function openUpdateStatusWin(id) {
                 var oWnd = window.radopen("UpdateStatus.aspx?ProId=" + id, "RadWindow3");
                 var bounds = oWnd.getWindowBounds();
                 var x = bounds.x;
                 var y = bounds.y;
                 // oWnd.moveTo(x, 1);
                 return false;
             }

             function openStageWin(JobNumber) {
                 var oWnd = window.radopen("StageForm.aspx?JobNumber=" + JobNumber, "StageWindow");
                 var bounds = oWnd.getWindowBounds();
                 var x = bounds.x;
                 var y = bounds.y;
                 oWnd.moveTo(x, 1);
                 return false;
             }        
            </script>

                
      
         </form>

</asp:Content>


