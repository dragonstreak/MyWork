
Namespace Model
    Public Class User_GroupRole
        Private _id As Integer
        Private _roleid As Integer
        Private _groupid As Integer

        Public Sub New()
            _id = 0
            _roleid = 0
            _groupid = 0
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

        'RoleID
        Public Property RoleId() As Integer
            Get
                Return _roleid
            End Get
            Set(ByVal Value As Integer)
                _roleid = Value
            End Set
        End Property

    End Class
End Namespace
