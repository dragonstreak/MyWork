<%@ Control Language="VB" AutoEventWireup="false" CodeFile="CostingItemControl.ascx.vb"
    Inherits="Ascx_CostingItemControl" %>
<div>
    <telerik:RadGrid ID="RadGrid1" runat="server" AutoGenerateColumns="False" CellSpacing="0"
        GridLines="None">
        <MasterTableView ShowFooter="true">
            <CommandItemSettings ExportToPdfText="Export to PDF"></CommandItemSettings>
            <Columns>
                <telerik:GridBoundColumn DataField="CostName" FilterControlAltText="Filter column column"
                    FooterText="Total" HeaderText="Estimated Cost" UniqueName="column">
                </telerik:GridBoundColumn>
                <telerik:GridBoundColumn  DataField="SampleSize" FilterControlAltText="Filter column1 column"
                    HeaderText="Sample Size" UniqueName="column1">
                </telerik:GridBoundColumn>
                <telerik:GridBoundColumn  DataField="TotalCost" FilterControlAltText="Filter column2 column"
                    HeaderText="Total Cost" UniqueName="column2">
                </telerik:GridBoundColumn>
                <telerik:GridBoundColumn  DataField=" AverageCostPerSample" FilterControlAltText="Filter column3 column"
                    HeaderText=" Average Cost per sample" UniqueName="column3">
                </telerik:GridBoundColumn>
                <telerik:GridBoundColumn DataField=" EstimateCost" FilterControlAltText="Filter column3 column"
                    HeaderText=" Estimate cost" UniqueName="EstimateCostColumn" Visible="false">
                </telerik:GridBoundColumn>
                <telerik:GridBoundColumn DataField=" CostDiff" FilterControlAltText="Filter column3 column"
                    HeaderText=" Diff" UniqueName="DiffColumn" Visible="false">
                </telerik:GridBoundColumn>
            </Columns>
            <FooterStyle Font-Bold="false" Font-Italic="false" Font-Overline="false" Font-Strikeout="false" Font-Underline="false" Wrap="true" />
        </MasterTableView>
    </telerik:RadGrid>
</div>
<br />
<div id="divEmail" runat="server" style="height: 50px; text-align: right">
    <telerik:RadButton ID="btnEmailPartner" runat="server" Text="Email to Partner" Width="120px">
        <Icon PrimaryIconUrl="~/Images/email_add.png" PrimaryIconTop="4px" PrimaryIconLeft="2px"
                PrimaryIconBottom="4px" />
    </telerik:RadButton>
    <asp:TextBox ID="txtEmailPartner" runat="server" Columns="5" Width="300"></asp:TextBox>
</div>
