<%@ Page Language="VB" AutoEventWireup="false" CodeFile="UploadFile.aspx.vb" Inherits="UploadFile" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
    <base target="_self" />
    <link href="../css/style.css" rel="stylesheet" type="text/css" />
    <script src="../js/validation.js" type="text/javascript"></script>
    <script src="../js/operation.js" type="text/javascript"></script>
    <script language="javascript">
        function getUploadedList() {
            var i = document.getElementById("uploadedList");
            return i.value;
        }
        function copyUrl() {
            var url = document.getElementById("url").innerHTML;
            window.clipboardData.setData('text', url);
        }
        function upload() {
            // 检测文件的类型
            var f = document.getElementById("form1");
            var fileName = trim(f.imageTitle.value)

            var filePath = trim(f.File1.value);
            var extension = '';
            var num1 = filePath.length;
            var num2 = num1 - 1;
            while (num2 >= 0) {
                var ch1 = filePath.charAt(num2);

                if (ch1 == '.') {
                    if (num2 != (num1 - 1)) {
                        extension = filePath.substring(num2 + 1, num1);

                        break;
                    }
                }
                num2 = num2 - 1;
            }
            if (extension.length < 1) {
                alert('please select a file！');
                return false;
            }
            var fileType = " jpg, bmp, gif, png, jpeg, swf";
            extension = extension.toLowerCase();
            if (fileType.indexOf(extension) == -1) {
                alert('only can upload jpg, bmp, gif, png, jpeg, swf file');
                return false;
            }

            f.submit();
        }
		</script>
</head>
<body style="border:0">
    <form id="form1" runat="server">
    <div>
      <input id="uploadedList" type="hidden" value="<%=GetUploadedList()%>" name="uploadedList" />
			<table class="dg" id="Table1" width="100%">
				<tr>
					<td class="val"></td>
					<td class="dga" width="11%">file address</td>
					<td>
						<div id="url"><%=GetImageUrl()%></div>
					</td>
					<td width="11%"><input class="btncopy" onclick="javascript:copyUrl()" type="button" value="copy" /></td>
				</TR>
				<TR>
					<td class="val"></td>
					<TD class="dga">Description</TD>
					<TD><input class="text full" id="fileDescription" type="text" name="imageTitle" maxLength="50"></TD>
					<TD>&nbsp;</TD>
				</TR>
				<TR>
					<td class="val">*</td>
					<TD class="dga"></TD>
					<TD>
                        <asp:FileUpload ID="File1" runat="server" CssClass="text full" />
                    </TD>
					<TD><input class="btnupload" title="allow to upload jpg, bmp, gif, png, jpeg, swf files" onclick="javascript:upload()"
							type="button" value="upload"></TD>
				</TR>
			</table>
			<asp:label id="LabelMsg" runat="server" CssClass="red"></asp:label>
    </div>
    </form>
</body>
</html>
