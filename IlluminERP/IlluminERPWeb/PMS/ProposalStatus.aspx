<%@ Page Language="VB" AutoEventWireup="false" CodeFile="ProposalStatus.aspx.vb" Inherits="PMS_ProposalStatus" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>Proposal Go/No Go</title>
 <meta http-equiv="X-UA-Compatible" content="IE=EmulateIE7" />
    <base target="_self" />
    <script src="../js/operation.js" type="text/javascript"></script>
    <link href="../css/style.css" rel="stylesheet" type="text/css" />
        <script  type="text/javascript">
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
         
            .style1
            {
                font-size: large;
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
                            Skin="Windows7" Width="180px">
                        </telerik:RadTextBox>
                    </td>
                    <td class="lable">
                        <span class="red">*</span> Job Name:</td>
                    <td >
                        <telerik:RadTextBox ID="txtJobName" Runat="server" Skin="Windows7" 
                            Width="180px">
                        </telerik:RadTextBox>
                    </td>
                </tr>
                <tr>
                    <td class="lable">
                        <span class="red">*</span> Business Unit:
                    </td>
                    <td align ="left"  >
                        <telerik:RadComboBox ID="cbBusinessUnit" Runat="server" Skin="Windows7" 
                            Width="180px">
                        </telerik:RadComboBox>
                    </td>
                    <td class="lable">
                        <span class="red">*</span>
                        Probability(%):
                    </td>
                    <td >
                        <telerik:RadNumericTextBox ID="txtProbablity" runat="server"
                            Type="Percent" MaxValue="100" MinValue="0" Skin="Windows7" Width="180px">
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
                    Filter="Contains" MarkFirstMatch="True" Skin="Windows7" Width="450px">
                </telerik:RadComboBox>
                
            </div>     


             
                    </td>
                </tr>
                <tr>
                    <td class="lable">
                        <span class="red">*</span>
                        Sector:</td>
                    <td    >
                        <telerik:RadComboBox ID="cbSector" Runat="server" Skin="Windows7" Width="180px" 
                            >
                        </telerik:RadComboBox>
                    </td>
                    <td class="lable">
                        <span class="red">*</span>
                        Product Category:
                    </td>
                    <td  >
                        <telerik:RadComboBox ID="cbProductCategory" Runat="server" Skin="Windows7" 
                            Width="180px" >
                         
                        </telerik:RadComboBox>
                    </td>
                </tr>
                <tr>
                    <td class="lable">
                        <span class="red">*</span>
                        Study Type:</td>
                    <td colspan="3"   >
                        <telerik:RadComboBox ID="cbStudytype" Runat="server" Skin="Windows7" 
                            Width="450px">
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
                            Skin="Windows7" Width="180px">
                        </telerik:RadTextBox>
                    </td>
                    <td class="lable">
                        Proposal Date:
                    </td>
                    <td >
                        <telerik:RadTextBox ID="txtCreateDate" Runat="server" Wrap="False" 
                            Skin="Windows7" Width="180px">
                        </telerik:RadTextBox>
                    </td>
                </tr>
                <tr>
                    <td class="lable">
                        Project owner:</td>
                    <td    >
                        <telerik:RadComboBox ID="cbProjectOwner" Runat="server" Skin="Windows7" 
                            Width="180px">
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
                            TextMode="MultiLine" Skin="Windows7" Width="450px">
                        </telerik:RadTextBox>
                    </td>
                </tr>
                <tr>
                   <td class="lable" style="height: 15px">
                        Project Keywords:</td>
                    <td colspan="3"  >
                        <telerik:RadTextBox ID="txtKeywords" Runat="server" 
                            TextMode="MultiLine" Skin="Windows7" Width="450px">
                        </telerik:RadTextBox>
                    </td>
                </tr>
                <tr>
                   <td  style="height: 15px" colspan="4">
                        &nbsp;</td>
                </tr>
                <tr>
                   <td  style="height: 15px" colspan="4" bgcolor="#CCCCCC">
                        <span class="style1">Proposal Go/No Go:</span>
                        <asp:Label 
                            ID="lblStatus" runat="server" Font-Bold="True" Font-Names="Arial" 
                            Font-Size="12pt" ForeColor="Red"></asp:Label>
                    </td>
                </tr>
                <tr>
                   <td class="lable" style="height: 15px">
                        Status:</td>
                    <td colspan="3"  >
                              
                              <telerik:RadComboBox ID="cbProposalStatus" Runat="server" AllowCustomText="True" 
                                        MarkFirstMatch="True" Skin="Hay">
                                    </telerik:RadComboBox>
                              
                              </td>
                </tr>
                <tr>
                   <td class="lable" style="height: 15px">
                        Note:</td>
                    <td colspan="3"  >
                            
                        <telerik:RadTextBox ID="txtStatusNote" Runat="server" 
                            TextMode="MultiLine" Skin="Windows7" Width="300px" Rows="3">
                        </telerik:RadTextBox>
                              
                                </td>
                </tr>
                <tr>
                   <td  style="height: 15px; text-align: center;" colspan="4">
                              
                             
                              
                                <telerik:RadButton ID="btnOk" runat="server" Text="Submit"  width="100px" >
                                       <Icon PrimaryIconUrl="../images/save.png" PrimaryIconLeft="7" PrimaryIconTop="4" />
                                </telerik:RadButton>
                              
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
            
              
                 <br />
               
                      </Div>             

    
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

             function OnClientClose(oWnd, args) {
                 //get the transferred arguments
                 var arg = args.get_argument();
                 if (arg) {
                     var cityName = arg.cityName;
                     var seldate = arg.selDate;
                     $get("order").innerHTML = "You chose to fly to <strong>" + cityName + "</strong> on <strong>" + seldate + "</strong>";
                 }
             }

             function showalert(message) {

                 window.alert(message);
                 return false;
             }

           
        </script>


         



         </form>
</body>
</html>

