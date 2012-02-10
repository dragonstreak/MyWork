Namespace Model
    Public Class Client_ClientInfo
        Private _id As Integer
        Private _ClientCode As String
        Private _FullName As String
        Private _E_Name As String
        Private _C_Name As String
        Private _KeyAccount As String
        Private _ClientType As Integer
        Private _Status As Integer
        Private _SortType As Integer


        Public Sub New()
            _id = 0
            _ClientCode = String.Empty
            _FullName = String.Empty
            _E_Name = String.Empty
            _C_Name = String.Empty
            _KeyAccount = String.Empty
            _ClientType = 0
            _Status = 0
            _SortType = 1
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


        '_ClientCode
        Public Property ClientCode() As String
            Get
                Return _ClientCode
            End Get
            Set(ByVal Value As String)
                _ClientCode = Value
            End Set
        End Property

        'Full Name
        Public Property FullName() As String
            Get
                Return _FullName
            End Get
            Set(ByVal Value As String)
                _FullName = Value
            End Set
        End Property

        'E_Name
        Public Property E_Name() As String
            Get
                Return _E_Name
            End Get
            Set(ByVal Value As String)
                _E_Name = Value
            End Set
        End Property

        '_C_Name
        Public Property C_Name() As String
            Get
                Return _C_Name
            End Get
            Set(ByVal Value As String)
                _C_Name = Value
            End Set
        End Property

        '_KeyAccount
        Public Property KeyAccount() As String
            Get
                Return _KeyAccount
            End Get
            Set(ByVal Value As String)
                _KeyAccount = Value
            End Set
        End Property

        'ClientTYpe
        Public Property ClientType() As Integer
            Get
                Return _ClientType
            End Get
            Set(ByVal Value As Integer)
                _ClientType = Value
            End Set
        End Property

        'Status
        Public Property Status() As Integer
            Get
                Return _Status
            End Get
            Set(ByVal Value As Integer)
                _Status = Value
            End Set
        End Property


        'SortType
        Public Property SortType() As Integer
            Get
                Return _SortType
            End Get
            Set(ByVal Value As Integer)
                _SortType = Value
            End Set
        End Property


    End Class
End Namespace

