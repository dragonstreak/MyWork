<%@ Page Language="VB" AutoEventWireup="false" CodeFile="EstimatedCostPage.aspx.vb"
    Inherits="PMS_EstimatedCostPage" %>

<%@ Register Src="../Ascx/CostingItemControl.ascx" TagName="CostingItemControl" TagPrefix="uc1" %>
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
    <div class="sharp color1" style="width: 80%; padding-left: 10px">
        <b class="b1"></b><b class="b2"></b><b class="b3"></b><b class="b4"></b>
        <div class="content" style="height: 120px;">
            <h3>
                Costing Detail
            </h3>
            <hr align="left" size="1" style="border-style: dotted; color: Aqua;" />
            <div>
                <table style="width: 100%">
                    <tr>
                        <td style="width: 100px">
                            JobNumber:
                        </td>
                        <td style="width: 120px">
                            <asp:TextBox ID="txtJobNumber" Enabled="false" Width="98%" runat="server"></asp:TextBox>
                        </td>
                        <td style="width: 80px">
                            JobName
                        </td>
                        <td>
                            <asp:TextBox ID="txtJobName" Width="98%" runat="server" Enabled="false"></asp:TextBox>
                        </td>
                    </tr>
                    <tr>
                        <td>
                            Contract Amount
                        </td>
                        <td>
                            <asp:TextBox ID="txtContractAmount" Width="98%" runat="server" Enabled="false"></asp:TextBox>
                        </td>
                        <td>
                            Client
                        </td>
                        <td>
                            <asp:TextBox ID="txtClient" Width="98%" runat="server" Enabled="false"></asp:TextBox>
                        </td>
                    </tr>
                    <tr>
                        <td>
                            占合同金额%:
                        </td>
                        <td>
                            <asp:TextBox ID="txtAmountPercentage" Width="98%" runat="server"></asp:TextBox>
                        </td>
                    </tr>
                </table>
            </div>
        </div>
        <b class="b5"></b><b class="b6"></b><b class="b7"></b><b class="b8"></b>
    </div>
    <br />
    <div style="height: 450px; width: 80%; padding-left:10px; padding-top:10px">
        <telerik:RadScriptManager ID="RadScriptManager2" runat="server">
        </telerik:RadScriptManager>
        <telerik:RadTabStrip ID="CostTabStrip" runat="server" Width="100%" ClickSelectedTab="True"
            SelectedIndex="0" MultiPageID="CostMultiplePage">
        </telerik:RadTabStrip>
        <telerik:RadMultiPage ID="CostMultiplePage" runat="server" SelectedIndex="0" Width="100%"
            Height="100%">
        </telerik:RadMultiPage>
    </div>
    <div style="width:80%;">
    <p style="text-align: center; padding-top: 0px">
    <telerik:RadButton ID="btnEmail" runat="server" Text="Email to approve" Font-Names="Arial"
            Font-Size="9pt" Width="130px" Skin="Hay" Enabled="false">
            <Icon PrimaryIconUrl="~/Images/email_add.png" PrimaryIconTop="4px" PrimaryIconLeft="2px"
                PrimaryIconBottom="4px" />
        </telerik:RadButton>
        <telerik:RadButton ID="btnApprove" runat="server" Text="Approve to partner" Font-Names="Arial"
            Font-Size="9pt" Width="130px" Skin="Hay" Enabled="false">
            <Icon PrimaryIconUrl="~/Images/accept.png" PrimaryIconTop="4px" PrimaryIconLeft="2px"
                PrimaryIconBottom="4px" />
        </telerik:RadButton>
    </p>
        
    </div>
    <telerik:RadAjaxManager ID="RadAjaxManager1" runat="server">
    </telerik:RadAjaxManager>
    </form>
</body>
</html>
