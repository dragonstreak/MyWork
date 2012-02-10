
Partial Class CommonPage_TempError
    Inherits System.Web.UI.Page

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        Dim strWarningMessage As String
        Dim strLink As String
        strWarningMessage = Request.QueryString("WarningMessage")
        strWarningMessage = Replace(strWarningMessage, "'", "")
        strLink = "WarningPage.aspx?WarningMessage=" + strWarningMessage
        Response.Write("<script language=javascript>")
        Response.Write("window.parent.location='" + strLink + "';")
        Response.Write("</script>")
    End Sub
End Class
