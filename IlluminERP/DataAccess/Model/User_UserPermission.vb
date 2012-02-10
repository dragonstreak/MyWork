


Namespace Model
    Public Class User_UserPermission
        Private _id As Integer
        Private _Userid As Integer
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

        'UserID
        Public Property UserID() As Integer
            Get
                Return _UserID
            End Get
            Set(ByVal Value As Integer)
                _Userid = Value
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
