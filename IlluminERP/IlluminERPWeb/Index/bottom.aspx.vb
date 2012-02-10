Imports DataAccess.Model
Partial Class Index_bottom
    Inherits System.Web.UI.Page


    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        If Not IsPostBack Then
            If Not Session("LoginUserInfo") Is Nothing Then
                Dim MyUserInfo As New User_UserInfo
                MyUserInfo = Session("LoginUserInfo")
                Me.lblUserName.Text = MyUserInfo.C_Name & "," & MyUserInfo.E_Name
            End If
        End If
    End Sub
End Class
