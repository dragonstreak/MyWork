<%@ Page Language="VB" AutoEventWireup="false" CodeFile="ProposalRating.aspx.vb" Inherits="PMS_ProposalRating" %>
<%@ Register TagPrefix="telerik" Namespace="Telerik.Web.UI" Assembly="Telerik.Web.UI" %>
<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>Scale Rating</title>
    <meta http-equiv="X-UA-Compatible" content="IE=EmulateIE7" />
    <base target="_self" />
    <script src="../js/operation.js" type="text/javascript"></script>
    <link href="../css/style.css" rel="stylesheet" type="text/css" />
        <script type="text/javascript">
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

                       
	    </script>

       
       
    
        <telerik:RadCodeBlock ID="RadCodeBlock1" runat="server">

        <script type="text/javascript">
            function OnClientRated(controlRating, args) {
                var tooltip = $find("<%= RadToolTip1.ClientID %>");
                tooltip.show();
            }

            function CloseToolTip1() {
                var tooltip = Telerik.Web.UI.RadToolTip.getCurrent();
                if (tooltip) {
                    tooltip.hide();
                }
            }

          
        </script>

    </telerik:RadCodeBlock>

      
        <style type="text/css">
          
            #divpanel {
              
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
         
            #form1
            {
                text-align: left;
            }
         
            </style>
</head>
	
<body  onunload="refreshparent();" class ="bg">

    <form id="form1" runat="server">
             <table cellspacing="1" cellpadding="1" class="info" >
              <tbody>
               
                <tr >
                    <td class ="title" colspan="4">
                        Proposal Information</td>
                </tr>
               
                <tr >
                    <td class ="lable">
                        <span class="red">*</span>
                        Job Number:</td>
                    <td align ="left"  >
                        <telerik:RadTextBox ID="txtJobnumber" Runat="server" 
                            Skin="Windows7" Width="200px">
                        </telerik:RadTextBox>
                    </td>
                    <td class="lable">
                        <span class="red">*</span> Job Name:</td>
                    <td >
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
                            Width="98%">
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
                
                <telerik:RadComboBox ID="cbClient" Runat="server" AllowCustomText="True" 
                    Filter="Contains" MarkFirstMatch="True" Skin="Windows7" Width="539px">
                </telerik:RadComboBox>
                
            </div>     


             
                    </td>
                </tr>
                <tr>
                    <td class="lable">
                        <span class="red">*</span>
                        Sector:</td>
                    <td    >
                        <telerik:RadComboBox ID="cbSector" Runat="server" Skin="Windows7" Width="98%" 
                            >
                        </telerik:RadComboBox>
                    </td>
                    <td class="lable">
                        <span class="red">*</span>
                        Product Category:
                    </td>
                    <td  >
                        <telerik:RadComboBox ID="cbProductCategory" Runat="server" Skin="Windows7" 
                            Width="98%" >
                         
                        </telerik:RadComboBox>
                    </td>
                </tr>
                <tr>
                    <td class="lable">
                        <span class="red">*</span>
                        Study Type:</td>
                    <td colspan="3"   >
                        <telerik:RadComboBox ID="cbStudytype" Runat="server" Skin="Windows7" 
                            Width="342px">
                        </telerik:RadComboBox>
                    </td>
                </tr>
                <tr>
                    <td  colspan="4">&nbsp;</td>
                </tr>
                <tr>
                    <td class="lable">
                        Prepared By:
                    </td>
                    <td    >
                        <telerik:RadTextBox ID="txtPrepared" Runat="server" Wrap="False" 
                            Skin="Windows7" Width="200px">
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
                    <td class="lable">
                        Project owner:</td>
                    <td    >
                        <telerik:RadComboBox ID="cbProjectOwner" Runat="server" Skin="Windows7" 
                            Width="98%">
                        </telerik:RadComboBox>
                    </td>
                    <td class="lable">
                        &nbsp;</td>
                    <td >
                        &nbsp;</td>
                </tr>
                <tr>
                   <td class="lable" style="height: 15px">
                        Brief Description of the study:
                    </td>
                    <td colspan="3"  >
                        <telerik:RadTextBox ID="txtDescription" Runat="server" 
                            TextMode="MultiLine" Skin="Windows7" Width="540px" Rows="1">
                        </telerik:RadTextBox>
                    </td>
                </tr>
                <tr>
                   <td class="lable" style="height: 15px">
                        Project Keywords:</td>
                    <td colspan="3"  >
                        <telerik:RadTextBox ID="txtKeywords" Runat="server" 
                            TextMode="MultiLine" Skin="Windows7" Width="540px" Rows="1">
                        </telerik:RadTextBox>
                    </td>
                </tr>
                </tbody>
            </table>
            <div style="text-align: left">
                
                <br />
                
            </div>     

             <telerik:RadAjaxManager ID="RadAjaxManager1" runat="server">
             </telerik:RadAjaxManager>
             

             <telerik:RadScriptManager ID="RadScriptManager1" Runat="server">
                <Scripts>
                    <asp:ScriptReference Assembly="Telerik.Web.UI" Name="Telerik.Web.UI.Common.Core.js" />
                    <asp:ScriptReference Assembly="Telerik.Web.UI" Name="Telerik.Web.UI.Common.jQuery.js" />
                </Scripts>
             </telerik:RadScriptManager>

             
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
                <table cellpadding="0" cellspacing="3" style=" float:left;" >
                        <tr>
                             <td>
                                   <a href="#" class="btn-slide" title="Advanced Search"></a>
                            </td>

                            <td style=" font-size:14px">
                                    Rate this proposal
                             </td>
           
                        </tr>
                        <tr>
                        
                            <td colspan="2">
                            
                                    <telerik:RadRating ID="radRating" Runat="server" ItemCount="10" 
                                            SelectionMode="Continuous"
                                            Precision="Exact" OnClientRated="OnClientRated"  
                                                Skin="Sitefinity">
                                    </telerik:RadRating>
                            
                             </td>      
                        </tr>

                         <tr>
                        
                            <td colspan="2">
                            
                                  <asp:Label ID="lblRating" runat="server" Text=""></asp:Label>
                              
                             </td>
                        </tr>

                        </table>
                 
                    <div id="divpanel"  style=" width:750px; " runat="server"   align="left" >
                     <hr style="border:1px dashed red; height:1px; text-align: left;">
                    
                                      
                             
                    <telerik:RadGrid ID="radGridRating" runat="server" Skin="Simple" 
                        AllowPaging="True" AllowSorting="True" AutoGenerateColumns="False" 
                        GridLines="None" Width="100%" AutoGenerateDeleteColumn="True">
                        <ClientSettings AllowColumnsReorder="True" ReorderColumnsOnClient="True">
                            <Selecting AllowRowSelect="True" />
                        </ClientSettings>
                                <MasterTableView>
                                <CommandItemSettings ExportToPdfText="Export to Pdf"></CommandItemSettings>

                                    <Columns>
                                            <telerik:GridBoundColumn DataField="Id" UniqueName="columnId" Visible="False">
                                            </telerik:GridBoundColumn>

                                            <telerik:GridBoundColumn DataField="ProId" UniqueName="columnProid" 
                                                Visible="False">
                                            </telerik:GridBoundColumn>

                                            <telerik:GridBoundColumn DataField="UserId" HeaderText="User" UniqueName="columnUserId">
                                            <HeaderStyle Width="80px" HorizontalAlign="Center" />
                                            </telerik:GridBoundColumn>

                                            <telerik:GridTemplateColumn DataField="Rating" HeaderText="Rating" 
                                                UniqueName="columnRating">
                                                <EditItemTemplate>
                                                    <asp:TextBox ID="RatingTextBox" runat="server" Text='<%# Bind("Rating") %>'></asp:TextBox>
                                                </EditItemTemplate>
                                                <ItemTemplate>
                                                    <telerik:RadRating ID="RadgridRating1" Runat="server" 
                                                        DbValue='<%# Eval("Rating") %>' ItemCount="10" ReadOnly="True" 
                                                        Skin="Sitefinity" Width="<%# 80 %>">
                                                    </telerik:RadRating>
                                                </ItemTemplate>
                                                <HeaderStyle HorizontalAlign="Center" Width="50px" />
                                                <ItemStyle HorizontalAlign="Center" Width="80px" />
                                            </telerik:GridTemplateColumn>

                                            <telerik:GridBoundColumn DataField="Comments" HeaderText="Comments" 
                                                UniqueName="columnComments">
                                                <HeaderStyle HorizontalAlign="Center" Width="280px" />
                                                <ItemStyle HorizontalAlign="Center" Width="120px" />
                                            </telerik:GridBoundColumn>

                                    </Columns>
                                </MasterTableView>
                    </telerik:RadGrid>
                    
                                      
                             
                    </div>
        </Div>
         
       

         <telerik:RadToolTip ID="RadToolTip1" runat="server" ShowEvent="FromCode" HideEvent="FromCode"
                 TargetControlID="RadRating" RelativeTo="Element" Skin="Default" Position="BottomLeft"
                 OffsetX="-15" Animation="Slide">
                        <asp:Label ID="lblInstructions" runat="server" Text="Your feedback:"></asp:Label><br />
                        <asp:TextBox ID="txtComments" runat="server" TextMode="MultiLine" 
                    Rows="5" Columns="30" Width="301px"></asp:TextBox><br />
                <asp:Button ID="btnPostComment" UseSubmitBehavior="false" runat="server" Style="margin-top: 5px;
                color: #3e570a" Text="Post" OnClick="btnPostComment_Click" />
                <asp:RegularExpressionValidator ID="RegularExpressionValidator1" runat="server" ControlToValidate="txtComments"
                Display="Dynamic" ErrorMessage="Please use plain text only" ValidationExpression="[^<]+"></asp:RegularExpressionValidator>
             </telerik:RadToolTip>











         <script type="text/javascript">

             var productcategoryCombo;


             function pageLoad() {
                 // initialize the global variables
                 // in this event all client objects 
                 // are already created and initialized 
                 // productcategoryCombo = $find("<%= cbProductCategory.ClientID %>");
             }




             function Loadproductcategory(sender, eventArgs) {
                 var item = eventArgs.get_item();
                 productcategoryCombo.set_text("Loading...");
                 productcategoryCombo.clearSelection();

                 // if a continent is selected
                 if (item.get_index() > 0) {
                     // this will fire the ItemsRequested event of the 
                     // countries combobox passing the continentID as a parameter 
                     productcategoryCombo.requestItems(item.get_value(), false);
                 }
                 else {
                     // the -Select a continent- item was chosen
                     productcategoryCombo.set_text(" ");
                     productcategoryCombo.clearItems();

                 }
             }


             function ItemsLoaded(sender, eventArgs) {
                 if (sender.get_items().get_count() > 0) {
                     // pre-select the first item
                     sender.set_text(sender.get_items().getItem(0).get_text());
                     sender.get_items().getItem(0).highlight();
                 }

                 sender.showDropDown();

             }

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

             

             function showalert(message) {

                 window.alert(message);
                 return false;
             }

           
        </script>
             <telerik:RadWindowManager ID="RadWindowManager1" runat="server">
             </telerik:RadWindowManager>

             <telerik:RadAjaxManager ID="RadAjaxManager2" runat="server">
             </telerik:RadAjaxManager>

           </form>
</body>
</html>


