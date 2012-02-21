Imports DataAccess.Model

Partial Class Master_IlluminMasterPage
    Inherits System.Web.UI.MasterPage
    Private _currentUserName As String

    Public Property CurrentUserName() As String
        Get
            If _currentUserName IsNot Nothing Then
                Return _currentUserName
            ElseIf Session("LoginUserInfo") IsNot Nothing Then
                Return CType(Session("LoginUserInfo"), User_UserInfo).Code
            Else
                Return String.Empty
            End If
        End Get
        Set(ByVal value As String)
            _currentUserName = value
        End Set

    End Property


End Class

