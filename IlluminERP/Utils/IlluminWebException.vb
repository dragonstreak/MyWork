Public Class IlluminWebException
    Inherits Exception

    Public Sub New()

    End Sub

    Private _needRedirect As Boolean
    Private _redirectToUrl As String
    Private _redirectFromUrl As String

    Public Property NeedRedirect As Boolean
        Get
            Return _needRedirect
        End Get
        Set(ByVal value As Boolean)
            _needRedirect = value
        End Set
    End Property

    Public Property RedirectToUrl As String
        Get
            Return _redirectToUrl
        End Get
        Set(ByVal value As String)
            _redirectToUrl = value
        End Set
    End Property

    Public Property RedirectFromUrl As String
        Get
            Return _redirectFromUrl
        End Get
        Set(ByVal value As String)
            _redirectFromUrl = value
        End Set
    End Property

End Class


