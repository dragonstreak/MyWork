<%@ Page Language="VB" AutoEventWireup="false" CodeFile="News.aspx.vb" Inherits="News" %>
<%@ Register Assembly="CKEditor.NET" Namespace="CKEditor.NET" TagPrefix="CKEditor" %>
<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
     <base target="_self" />
    <link href="../css/style.css" rel="stylesheet" type="text/css" />
    <script src="../js/validation.js" type="text/javascript"></script>
    <script src="../js/operation.js" type="text/javascript"></script>
    <script type="text/javascript">
        function CheckInput() {
            var title = document.getElementById("txtTitle");
            if (isEmpty(trim(title.value))) {
                ShowMessage("News Title can't be empty!");
                return false;
            }
            getUploadedList();
            return true;
        }

        function CloseWindow() {
            this.close();
        }

        function getUploadedList() {
            var v = document.getElementById("uploadedList");
            v.value = uploadImage.getUploadedList();
            if (typeof (Page_ClientValidate) == 'function')
                Page_ClientValidate();

        }
    </script>
</head>
<body>
    <form id="form1" runat="server" onsubmit="return CheckInput();">
    <div>
        <div class="title">
        <asp:Label ID="lblTitle" Text="" runat="server"></asp:Label>

        </div>
        <div>
         <table class="dg">
            <tr>
                 
                <td width="12%">News Type:</td>
                <td><asp:DropDownList ID="ddlType" runat="server"></asp:DropDownList></td>
                <td width="12%">Severity Level:</td>
                <td><asp:DropDownList ID="ddlSeverityLevel" runat="server"></asp:DropDownList> </td>
                <td width="12%">Publish:</td>
                <td><asp:DropDownList ID="ddlPublish" runat="server"></asp:DropDownList> </td>
            </tr>
            <tr>
                <td width="12%"><span style="color:Red">*</span> Title:</td>
                <td colspan="5"><asp:TextBox ID="txtTitle" Text="" runat="server" CssClass="text full"></asp:TextBox></td>
                 
            </tr>

        </table>
        </div>
        <div>
         <CKEditor:CKEditorControl ID="ckeNewsContent" runat="server" Height="400"></CKEditor:CKEditorControl>
        </div>
        <div>
          <iframe id="uploadImage" width="100%" height="100" frameborder="0" src="../System/UploadFile.aspx?ReferModule=News"></iframe>
        </div>
        <div>
        <asp:Button ID="btnSave" runat="server" Text="Save" class="btnsave" />
         <input type="button" name="btnCancel" value="Cancel" class="btnclose" onclick="javascript:CloseWindow();" />
        </div>
        <input type="hidden" id="uploadedList" name="uploadedList">
    </div>
    </form>
</body>
</html>
