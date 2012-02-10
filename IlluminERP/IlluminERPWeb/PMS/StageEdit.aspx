<%@ Page Language="VB" AutoEventWireup="false" CodeFile="StageEdit.aspx.vb" Inherits="PMS_StageEdit" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
    <base target="_self" />
    <link href="../Css/CornorPanel.css" rel="stylesheet" type="text/css" />
    <style type="text/css">
        .style1
        {
            width: 40px;
            height: 40px;
        }
    </style>
    <script type="text/javascript">
        function CloseWindow() {
            this.close();
        }

        function CloseWindow1(sender, eventArgs) {
           window.close ();
            sender.set_autoPostBack(false);
        }
    </script>
</head>
<body>
    <form id="form1" runat="server">
    <telerik:RadScriptManager ID="RadScriptManager1" runat="server">
    </telerik:RadScriptManager>
    <div class="sharp color1" style="width:406px; padding-left:10px">
            <b class="b1"></b><b class="b2"></b><b class="b3"></b><b class="b4"></b>
            <div class="content"  style="height:220px; width: 400px;" >
                <h3>
                    <asp:Label ID="labelStatus" runat="server" Text="Add Stage" Font-Names="Arial" 
                        Font-Size="10pt"></asp:Label></h3>
                    <hr align="left" size="1" style="border-style: dotted; color: Aqua;" noshade />
                <div>
                    <table>
                        <tr>
                            <td>
                                Stage Number:
                            </td>
                            <td>
                                <telerik:RadTextBox ID="tbStageNumber" runat="server" Width="125px" 
                                    Font-Names="Arial" Font-Size="9pt">
                                </telerik:RadTextBox>
                            </td>
                        </tr>
                        <tr>
                            <td>
                                Stage Name:
                            </td>
                            <td>
                                <telerik:RadTextBox ID="tbStageName" runat="server" Font-Names="Arial" 
                                    Font-Size="9pt">
                                </telerik:RadTextBox>
                            </td>
                        </tr>
                        
                        <tr>
                            <td>
                                Description:</td>
                            <td>
                                <telerik:RadTextBox ID="tbDescription" runat="server" MaxLength="100" Rows="3" 
                                    TextMode="MultiLine" Width="200px" Font-Names="Arial" Font-Size="9pt">
                                </telerik:RadTextBox>
                            </td>
                        </tr>
                        
                    </table>
                   </br>
                    <p style="text-align:right;">
                       
                    <telerik:RadButton ID="btnSave" runat="server" Text="Save"  
                            Font-Names="Arial" Font-Size="9pt" Width="80px" Skin="Hay" >
                           <Icon PrimaryIconUrl="../images/Save.Png" PrimaryIconLeft="10" PrimaryIconTop="4" />
                    </telerik:RadButton>

                        <span>
                       <%-- <asp:ImageButton ImageUrl="../Images/png/add_blue.png" ImageAlign="Middle"  CssClass ="style1" runat="server" ID="btnSave" />--%>
                       <%-- <asp:ImageButton ImageUrl="../Images/png/delete_blue.png" ImageAlign="Middle"  CssClass ="style1" runat="server" ID="ImageButton1" OnClientClick="javascript:CloseWindow();" />--%>
                         <telerik:RadButton ID="btnClose" runat="server" Text="Close"  
                                Font-Names="Arial" Font-Size="9pt" Width="80px" Skin="Hay"  OnClientClicked ="CloseWindow1" >
                               <Icon PrimaryIconUrl="../images/cancel.Png" PrimaryIconLeft="10" PrimaryIconTop="4"   />
                        </telerik:RadButton>
                        
                        <%--<img id="Img1" alt="Close" runat="server" class="style1" src="../Images/png/delete_blue.png"
                        onclick="javascript:CloseWindow();" />--%>
                        </span>
                    </p>
                    <%--<span style="padding-top:10px">
                    <asp:ImageButton ImageUrl="../Images/png/add_blue.png" ImageAlign="Middle"  CssClass ="style1" runat="server" ID="btnSave" />
                    <img id="Img1" alt="Close" runat="server" class="style1" src="../Images/png/delete_blue.png"
                        onclick="javascript:CloseWindow();" />
                    </span>--%>
                </div>
            </div>
            <b class="b5"></b><b class="b6"></b><b class="b7"></b><b class="b8"></b>
        </div>
    </form>
    </body>
</html>
