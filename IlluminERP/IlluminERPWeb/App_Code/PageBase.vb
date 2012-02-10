Imports Microsoft.VisualBasic

Imports DataAccess.Model

Public Class PageBase
    Inherits System.Web.UI.Page


    Protected Overrides Sub OnInit(ByVal e As System.EventArgs)
        AddHandler Me.Error, AddressOf ProcessPageError
        MyBase.OnInit(e)
    End Sub

    Protected Overridable Sub ProcessPageError(ByVal sender As Object, ByVal e As EventArgs)
        Dim pageException As Exception = Server.GetLastError()
        If pageException IsNot Nothing Then
            'Log the exception
        End If
        Session("LastException") = pageException
        RedirectToFail("Some exception occured, Please re-login or contact to administrator!")
    End Sub

    Protected Overridable Sub RedirectToFail(ByVal errorMessage As String)
        Response.Redirect(String.Format("../System/ShowException.aspx?error={0}", HttpUtility.HtmlEncode(errorMessage)))

    End Sub

    Protected ReadOnly Property CurrentLoginUser As User_UserInfo
        Get
            If Session("LoginUserInfo") Is Nothing Then
                'Response.Write("<script language=javascript>")
                'Response.Write("parent.location = 'Login.aspx';")
                'Response.Write("</script>")
                Return Nothing
            Else
                Return CType(Session("LoginUserInfo"), User_UserInfo)
            End If
        End Get
    End Property
End Class
