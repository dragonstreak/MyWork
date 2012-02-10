Imports System
Imports System.Web.UI.Page
Imports Microsoft.VisualBasic



Public Class clsWarningHandle


    Public Shared Function GetPageError(ByVal objError As Exception) As Boolean

        Dim strWarningMessage As String
        Dim strLink As String
        strWarningMessage = objError.Message
        strLink = "..\Commonpage\TempError.aspx?WarningMessage=" + strWarningMessage
        'System.Web.HttpContext.Current.Response.Redirect(System.Web.HttpUtility.UrlDecode(strLink))
        Return True
    End Function
End Class
