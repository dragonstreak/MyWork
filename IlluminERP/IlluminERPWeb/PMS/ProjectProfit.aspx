<%@ Page Language="VB" AutoEventWireup="false" CodeFile="ProjectProfit.aspx.vb" Inherits="PMS_ProjectProfit" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
    <link href="../Css/CornorPanel.css" rel="stylesheet" type="text/css" />
    <style type="text/css">
        .contentTable
        {
            width: inherit;
        }
    </style>
</head>
<body>
    <form id="form1" runat="server">
    <telerik:RadScriptManager ID="RadScriptManager1" runat="server">
        <Scripts>
            <asp:ScriptReference Assembly="Telerik.Web.UI" 
                Name="Telerik.Web.UI.Common.Core.js">
            </asp:ScriptReference>
            <asp:ScriptReference Assembly="Telerik.Web.UI" 
                Name="Telerik.Web.UI.Common.jQuery.js">
            </asp:ScriptReference>
            <asp:ScriptReference Assembly="Telerik.Web.UI" 
                Name="Telerik.Web.UI.Common.jQueryInclude.js">
            </asp:ScriptReference>
        </Scripts>
    </telerik:RadScriptManager>
    <div class="sharp color1" style="width: 80%; padding-left: 10px">
        <b class="b1"></b><b class="b2"></b><b class="b3"></b><b class="b4"></b>
        <div class="content" style="height: 30px">
            <div style="padding: 5px">
                    <p style="text-align: center; padding-top: 0px">                        
                        <span style="vertical-align: bottom">
                        <%--<asp:Button ID="btnExport" runat="server" Text="ExportToPDF" />--%>
                        <telerik:RadButton ID="btnExport" runat="server"  Text ="ExportToPDF" Font-Names="Arial" 
                            Font-Size="9pt" Width="120px" Skin="Hay"  >
                        <Icon PrimaryIconUrl="~/Images/save.png" PrimaryIconTop="4px" PrimaryIconLeft="5px" PrimaryIconBottom ="4px" />
                        </telerik:RadButton>


                        </span>
                    </p>
                </div>
        </div>
        <b class="b5"></b><b class="b6"></b><b class="b7"></b><b class="b8"></b>
    </div>   
    <div class="sharp color1" style="width: 80%; padding-left: 10px">
        <b class="b1"></b><b class="b2"></b><b class="b3"></b><b class="b4">
             </b>
        <div class="content" style="height: 500px;">
            <h3>
            Costing Analysis
            </h3>
            <hr align="left" size="1" style="border-style: dotted; color: Aqua;" noshade />
            <div>
                <table style="width: 100%">
                    <tr>
                        <td style="width: 120px">
                            Project Income Statement:
                        </td>
                        <td style="width: 100px">
                        </td>
                    </tr>
                    <tr>
                        <td>
                            Project Revenue
                        </td>
                        <td>
                         <asp:Label ID="labelProjectRevenue" runat="server"></asp:Label>
                        </td>
                    </tr>
                    <tr>
                        <td>
                            &nbsp;&nbsp;Minus:Taxation
                        </td>
                        <td>
                            <asp:Label ID="labelMinusTax" runat="server"></asp:Label>
                        </td>
                    </tr>
                    <tr>
                        <td>
                            &nbsp;&nbsp;Minus:Direct Costs
                        </td>
                        <td>
                            <asp:Label ID="labelDirectCosts" runat="server"></asp:Label>
                        </td>
                    </tr>
                    <tr>
                        <td>
                            &nbsp;&nbsp;&nbsp;&nbsp;SH-FW
                        </td>
                        <td>
                            <asp:Label ID="labelSHFW" runat="server"></asp:Label>
                        </td>
                    </tr>
                    <tr>
                        <td>
                            &nbsp;&nbsp;&nbsp;&nbsp;SH-QC
                        </td>
                        <td>
                            <asp:Label ID="labelSHQC" runat="server"></asp:Label>
                        </td>
                    </tr>
                    <tr>
                        <td>
                            &nbsp;&nbsp;&nbsp;&nbsp;SH-DP
                        </td>
                        <td>
                            <asp:Label ID="labelSHDP" runat="server"></asp:Label>
                        </td>
                    </tr>
                    <tr>
                        <td>
                            &nbsp;&nbsp;&nbsp;&nbsp;SH-Management
                        </td>
                        <td>
                            <asp:Label ID="labelSHManagement" runat="server"></asp:Label>
                        </td>
                    </tr>
                    <tr>
                        <td>
                            &nbsp;&nbsp;&nbsp;&nbsp;Subcontract-FW
                        </td>
                        <td>
                            <asp:Label ID="labelSubcontractFW" runat="server"></asp:Label>
                        </td>
                    </tr>
                    <tr>
                        <td>
                            &nbsp;&nbsp;&nbsp;&nbsp;Subcontract-QC
                        </td>
                        <td>
                            <asp:Label ID="labelSubcontractQC" runat="server"></asp:Label>
                        </td>
                    </tr>
                    <tr>
                        <td>
                            &nbsp;&nbsp;&nbsp;&nbsp;Subcontract-DP
                        </td>
                        <td>
                            <asp:Label ID="labelSubcontractDP" runat="server"></asp:Label>
                        </td>
                    </tr>
                    <tr>
                        <td>
                            &nbsp;&nbsp;Minus:Staffing
                        </td>
                        <td>
                            <asp:Label ID="labelMinusStaffing" runat="server"></asp:Label>
                        </td>
                    </tr>
                    <tr>
                        <td>
                            &nbsp;&nbsp;&nbsp;&nbsp;Illuminera analysts/consultants
                        </td>
                        <td>
                            <asp:Label ID="labelIllumineraAnalyts" runat="server"></asp:Label>
                        </td>
                    </tr>
                    <tr>
                        <td>
                            &nbsp;&nbsp;&nbsp;&nbsp;Freelancer
                        </td>
                        <td>
                            <asp:Label ID="labelFreelancer" runat="server"></asp:Label>
                        </td>
                    </tr>
                    <tr>
                        <td>
                            &nbsp;&nbsp;Minus:Others
                        </td>
                        <td>
                            <asp:Label ID="labelMinusOthers" runat="server"></asp:Label>
                        </td>
                    </tr>
                    <tr>
                        <td>
                            &nbsp;&nbsp;&nbsp;&nbsp;Travel/Accommodation
                        </td>
                        <td>
                            <asp:Label ID="labelTravel" runat="server"></asp:Label>
                        </td>
                    </tr>
                    <tr>
                        <td>
                            &nbsp;&nbsp;&nbsp;&nbsp;Other
                        </td>
                        <td>
                            <asp:Label ID="labelOther" runat="server"></asp:Label>
                        </td>
                    </tr>
                    <tr>
                        <td>
                            &nbsp;&nbsp;Minus: Management and Overhead
                        </td>
                        <td>
                            <asp:Label ID="labelMinusManagement" runat="server"></asp:Label>
                        </td>
                    </tr>
                    <tr>
                        <td>
                            Project Profit
                        </td>
                        <td>
                        <asp:Label ID="labelProjectProfit" runat="server"></asp:Label>
                        </td>
                    </tr>
                    <tr>
                        <td>
                            Project Profit Rate
                        </td>
                        <td>
                        <asp:Label ID="labelProjectProfitRate" runat="server"></asp:Label>
                        </td>
                    </tr>
                </table>
            </div>
        </div>
        <b class="b5"></b><b class="b6"></b><b class="b7"></b><b class="b8"></b>
    </div>
    </form>
</body>
</html>
