
Partial Class CommonPage_WarningPage
    Inherits System.Web.UI.Page

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        Dim strString As String
        strString = Request.QueryString("WarningMessage")
        Me.lblWarningMessage.Text = strString
        Me.lblContact.Text = "很抱歉给您带来不便，请与系统管理员联系！"
    End Sub
End Class
