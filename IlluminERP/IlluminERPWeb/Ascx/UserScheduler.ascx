<%@ Control Language="VB" AutoEventWireup="false" CodeFile="UserScheduler.ascx.vb" Inherits="Ascx_UserScheduler" %>
<telerik:RadScheduler ID="RadScheduler1" runat="server" 
    DataDescriptionField="Description" DataEndField="EndDateTime" DataKeyField="CombinedId" 
     DataStartField="StartDateTime" DataSubjectField="Subject" 
    EnableDescriptionField="True"
    >
</telerik:RadScheduler>
<telerik:RadScriptManager ID="RadScriptManager1" runat="server">
</telerik:RadScriptManager>

