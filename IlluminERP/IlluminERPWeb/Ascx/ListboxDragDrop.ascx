<%@ Control Language="VB" AutoEventWireup="false" CodeFile="ListboxDragDrop.ascx.vb" Inherits="Ascx_ListboxDragDrop" %>
<div style="text-align:left;float:left">
Non-Selected<br />
<telerik:RadListBox ID="rlbUnSelected" runat="server" TransferToID="rlbSelected" EnableDragAndDrop="true"
  Width="200px" Height="300px" SelectionMode="Multiple" AllowTransfer="true">
 
</telerik:RadListBox>
</div>
<div style="float:left;width:30px"><p style="width:30px">&nbsp;</p> </div>
<div style="text-align:left;">
Selected<br />
<telerik:RadListBox ID="rlbSelected" runat="server" EnableDragAndDrop="true"
 Width="200px" Height="300px" SelectionMode="Multiple">

</telerik:RadListBox>

</div>


