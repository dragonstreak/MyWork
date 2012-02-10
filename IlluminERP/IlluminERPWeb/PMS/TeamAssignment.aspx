<%@ Page Language="VB" AutoEventWireup="false" CodeFile="TeamAssignment.aspx.vb" Inherits="PMS_TeamAssignment" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>Team Assignment</title>
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
         
    </style>
</head>
	
<body  onunload="refreshparent();" class ="bg">

    <form id="form1" runat="server">

             <telerik:RadAjaxManager ID="RadAjaxManager1" runat="server" 
                 DefaultLoadingPanelID="RadAjaxLoadingPanel1">
                 <AjaxSettings>
                     <telerik:AjaxSetting AjaxControlID="cbCompanyType">
                         <UpdatedControls>
                             <telerik:AjaxUpdatedControl ControlID="cbUserSelect" 
                                 LoadingPanelID="RadAjaxLoadingPanel1" />
                         </UpdatedControls>
                     </telerik:AjaxSetting>
                 </AjaxSettings>
             </telerik:RadAjaxManager>
             

             <telerik:RadScriptManager ID="RadScriptManager1" Runat="server">
                <Scripts>
                    <asp:ScriptReference Assembly="Telerik.Web.UI" Name="Telerik.Web.UI.Common.Core.js" />
                    <asp:ScriptReference Assembly="Telerik.Web.UI" Name="Telerik.Web.UI.Common.jQuery.js" />
                </Scripts>
             </telerik:RadScriptManager>

             
                <telerik:RadAjaxLoadingPanel BackgroundPosition="Center" EnableSkinTransparency="false"
                    ID="RadAjaxLoadingPanel1" runat="server">
                    <asp:Image ID="Image2" runat="server" ImageUrl="../Images/loading.gif"></asp:Image>
                </telerik:RadAjaxLoadingPanel>

             
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
            
             <Div id="divaddon" style=" width:550px; " runat=server >
                <table cellpadding="0" cellspacing="3" style=" float:left;" >
                    <tr>
                         <td>
                                    <a href="#" class="btn-slide" title="Advanced Search"></a></td>

                        <td>
                             Company type :</td>
                          <td>
                                <telerik:RadComboBox ID="cbCompanyType" Runat="server" AllowCustomText="True"
                                 
                                    MarkFirstMatch="True" AutoPostBack="True">
                                    <Items>
                                        <telerik:RadComboBoxItem runat="server" Selected="True" Text="Illuminera" 
                                            Value="1" />
                                        <telerik:RadComboBoxItem runat="server" Text="Broadvision" Value="2" />
                                    </Items>
<WebServiceSettings>
<ODataSettings InitialContainerName=""></ODataSettings>
</WebServiceSettings>
                                </telerik:RadComboBox></td>

                        <td>
                            &nbsp;</td>
                          <td>
                                &nbsp;</td>

                        <td>
                       
                            
                            &nbsp;</td>
                       
                    </tr>
                   
                    <tr>
                         <td>
                        
                        </td>

                        <td>
                            Team Member :
                         </td>
                          <td>
                                <telerik:RadComboBox ID="cbUserSelect" Runat="server" AllowCustomText="True"
                                    DropDownCssClass="multipleRowsColumns" DropDownWidth="400px" 
                                    MarkFirstMatch="True">
                                </telerik:RadComboBox>
                        </td>

                        <td>
                            Role:
                         </td>
                          <td>
                                <telerik:RadComboBox ID="cbRole" Runat="server" AllowCustomText="True"
                                   MarkFirstMatch="True" Width="120px">
<WebServiceSettings>
<ODataSettings InitialContainerName=""></ODataSettings>
</WebServiceSettings>
                                </telerik:RadComboBox>
                        </td>

                        <td>
                       
                            
                            <telerik:RadButton ID="btnAddon" runat="server" Skin="Hay" Text="Add" 
                                Width="80px">
                                  <Icon PrimaryIconUrl="../images/btnadd.gif" PrimaryIconLeft="4" PrimaryIconTop="4" />
                            </telerik:RadButton>
                        </td>
                       
                    </tr>
                   
                </table>
                 
                 <br />
                 <br />
                 <hr style="border:1px dashed red; height:1px; width :550px; text-align: left;">
                

                <div id="divpanel"  style=" width:550px; " runat=server   align=left >
                    
                                      
                             
                    <telerik:RadGrid ID="radGridTeamUser" runat="server" Skin="Simple" 
                        AllowPaging="True" AllowSorting="True" AutoGenerateColumns="False" 
                        GridLines="None" Width="540px" AutoGenerateDeleteColumn="True" 
                        CellSpacing="0">
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
        <telerik:GridBoundColumn DataField="Id" UniqueName="columnId" Visible="False">
        </telerik:GridBoundColumn>
        <telerik:GridBoundColumn DataField="e_name" HeaderText="E_Name" 
            UniqueName="columnename">
            <HeaderStyle HorizontalAlign="Center" Width="70px" />
            <ItemStyle HorizontalAlign="Left" />
        </telerik:GridBoundColumn>
        <telerik:GridBoundColumn DataField="c_Name" HeaderText="Cn_Name" 
            UniqueName="columncname">
            <HeaderStyle HorizontalAlign="Center" Width="50px" />
            <ItemStyle HorizontalAlign="Left" />
        </telerik:GridBoundColumn>
        <telerik:GridBoundColumn DataField="PositionId" 
            FilterControlAltText="Filter columnPositionId column" HeaderText="Position" 
            UniqueName="columnPositionId">
            <HeaderStyle HorizontalAlign="Center" Width="80px" />
        </telerik:GridBoundColumn>
        <telerik:GridBoundColumn DataField="UserType" 
            FilterControlAltText="Filter columnRole column" HeaderText="Role" 
            UniqueName="columnRole">
            <HeaderStyle HorizontalAlign="Center" Width="80px" />
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

<HeaderContextMenu CssClass="GridContextMenu GridContextMenu_Simple">
<WebServiceSettings>
<ODataSettings InitialContainerName=""></ODataSettings>
</WebServiceSettings>
</HeaderContextMenu>
                    </telerik:RadGrid>
                    
                                      
                             
                </div>
        
        </Div>
         <script type="text/javascript">

             var productcategoryCombo;


        

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

