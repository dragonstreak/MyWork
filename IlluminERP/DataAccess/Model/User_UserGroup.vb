
Namespace Model
    Public Class User_UserGroup
        Private _id As Integer
        Private _userid As Integer
        Private _groupid As Integer

        Public Sub New()

        End Sub

        'ID
        Public Property ID() As Integer
            Get
                Return _id
            End Get
            Set(ByVal Value As Integer)
                _id = Value
            End Set
        End Property

        'GroupID
        Public Property GroupId() As Integer
            Get
                Return _groupid
            End Get
            Set(ByVal Value As Integer)
                _groupid = Value
            End Set
        End Property

        'UserID
        Public Property UserID() As Integer
            Get
                Return _userid
            End Get
            Set(ByVal Value As Integer)
                _userid = Value
            End Set
        End Property

    End Class
End Namespace
