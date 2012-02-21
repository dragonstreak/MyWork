
Partial Class LogOut
    Inherits System.Web.UI.Page

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        Session.Clear()
        FormsAuthentication.SignOut()
        Response.Redirect("Login.aspx")
    End Sub
End Class
