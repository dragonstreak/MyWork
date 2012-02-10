
Namespace Model
    Public Class User_TeamGroup

        Private _id As Integer
        Private _groupid As Integer
        Private _teamid As Integer

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

        'TeamID
        Public Property TeamId() As Integer
            Get
                Return _teamid
            End Get
            Set(ByVal Value As Integer)
                _teamid = Value
            End Set
        End Property


    End Class


End Namespace
