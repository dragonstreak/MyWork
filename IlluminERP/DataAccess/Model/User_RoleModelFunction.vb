
Namespace Model
    Public Class User_RoleModelFunction
        Private _id As Integer
        Private _roleid As Integer
        Private _modelfunctionid As Integer
        Private _isPermission As Integer

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

        'Model Function ID
        Public Property ModelFunctionID() As Integer
            Get
                Return _modelfunctionid
            End Get
            Set(ByVal Value As Integer)
                _modelfunctionid = Value
            End Set
        End Property

        'RoleID
        Public Property RoleID() As Integer
            Get
                Return _roleid
            End Get
            Set(ByVal Value As Integer)
                _roleid = Value
            End Set
        End Property


        'IS Permission
        Public Property IsPermission() As Integer
            Get
                Return _isPermission
            End Get
            Set(ByVal Value As Integer)
                _isPermission = Value
            End Set
        End Property


    End Class
End Namespace
