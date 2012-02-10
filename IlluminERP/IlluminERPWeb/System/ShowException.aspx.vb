
Partial Class ShowException
    Inherits System.Web.UI.Page

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        Dim errorMessage As String = HttpUtility.HtmlDecode(Request.QueryString("error"))
        Me.lblMessage.Text = errorMessage

        If ConfigurationManager.AppSettings("ShowExceptionDetail").ToLower().Equals("true") Then
            Dim exception As Exception = Session("LastException")
            If exception IsNot Nothing Then
                Me.lblDetail.Text = String.Format("Error: {0} <br/> StackTrace: {1}", exception.Message, exception.StackTrace)
            End If
            Session("LastException") = Nothing
            Response.Cache.SetCacheability(HttpCacheability.NoCache)
        End If
    End Sub

End Class
