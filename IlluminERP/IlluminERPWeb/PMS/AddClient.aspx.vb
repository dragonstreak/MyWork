Imports Utils.Jmail
Imports DataAccess.BLL
Imports DataAccess.Model

Partial Class PMS_AddClient
    Inherits System.Web.UI.Page
    Private jmail As New Utils.Jmail
    Private MyUserinfo As New DataAccess.Model.User_UserInfo

    Protected Sub btnEmail_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles btnEmail.Click

        If Not Session("LoginUserInfo") Is Nothing Then
            MyUserinfo = Session("LoginUserInfo")
        End If


        Dim strCCUser As String = MyUserinfo.Email
        Dim strTouser As String = "Eveline.Tan@illuminera.com"
        Dim strSubject As String = "Client Application- By " & MyUserinfo.E_Name
        If Me.txtClientCN.Text = "" And Me.txtClientEN.Text = "" Then
            Me.RadAjaxManager1.Alert("Client Name is not null")
            Exit Sub
        End If

        Dim strmessage As String

        strMessage = "  <html><head>" & _
                                " <title>客户申请" & _
                                "</title><meta http-equiv=""Content-Type"" content=""text/html; charset=gb2312"">" & _
                                "<style type=""text/css"">" & _
                                "<!--.style1 {font-family:Arial, Helvetica, sans-serif;font-size: 20px;color: #CC0000;font-weight: bold;}-->" & _
                                "<!--.style2{font-family:Arial, Helvetica, sans-serif;font-size: 14px;color: #000000;}-->" & _
                                "</style> " & _
                                "</head>" & _
                                "<body>" & _
                                " <table width=""100%"" border=""0"" cellpadding=""0""" & _
                                " cellspacing=""2"" bgcolor=""#990000""><tr><td><table width=""100%""" & _
                                " border=""0"" align=""center"" cellpadding=""6"" cellspacing=""0"" " & _
                                "bgcolor=""#FFFFFF""><tr><td height=""25"" bgcolor=""#CCCCCC"">" & _
                                "<span class=""style1"">客户申请:" & Me.txtClientEN.Text & Me.txtClientCN.Text & "</span></td></tr>" & _
                                "<tr><td height=""25"" bgcolor=""#F5F5F3""><span class=""style1"">Contact Infomation</span></td></tr>" & _
                                "<tr><td class=""style2"">First Name(CN):" & Me.txtFirstNameCN.Text & "  Last Name(CN):" & Me.txtLastNameCN.Text & "</td></tr>" & _
                                "<tr><td class=""style2"">First Name(EN):" & Me.txtFirstNameEN.Text & "  Last Name(EN):" & Me.txtLastNameEN.Text & "</td></tr>" & _
                                "<tr><td class=""style2"">JobTitle:" & Me.txtJobTitle.Text.Trim & "</td></tr>" & _
                                "<tr><td class=""style2"">Department:" & Me.txtDepartment.Text.Trim & "</td></tr>" & _
                                "<tr><td class=""style2"">Email:" & Me.txtEmail.Text.Trim & "</td></tr>" & _
                                "<tr><td class=""style2"">MobilePhone:" & Me.txtMobilePhone.Text.Trim & "</td></tr>" & _
                                "<tr><td class=""style2"">Tel-General:" & Me.txtTelGeneral.Text.Trim & "</td></tr>" & _
                                "<tr><td class=""style2"">Tel-Direct:" & Me.txtTELDirect.Text.Trim & "</td></tr>" & _
                                "<tr><td class=""style2"">Country:" & Me.txtCountry.Text.Trim & "</td></tr>" & _
                                "<tr><td class=""style2"">City:" & Me.txtCity.Text.Trim & "</td></tr>" & _
                                "<tr><td class=""style2"">Post Code:" & Me.txtPostCode.Text.Trim & "</td></tr>" & _
                                "<tr><td class=""style2"">Web Site:" & Me.txtWebSite.Text.Trim & "</td></tr>" & _
                                "<tr><td class=""style2"">Address(CN):" & Me.txtAddressCN.Text.Trim & "</td></tr>" & _
                                "<tr><td class=""style2"">Address(EN):" & Me.txtAddressEN.Text.Trim & "</td></tr>" & _
                                "</table></body></html>"

        If jmail.SendEmail(strmessage, 0, strTouser.Trim, strCCUser.Trim, strSubject) = True Then
            'Response.Write("<script language=javascript>")
            'Response.Write("alert('Your application has been submit!');window.returnValue='success';")
            'Response.Write("</script>")

            Me.RadAjaxManager1.Alert("Your application has been submit!")
        End If


    End Sub



End Class
