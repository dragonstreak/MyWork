
Namespace Model

    Public Class PMS_ProjectContractInfo
        Private _id As Integer
        Private _ProjectId As Integer
        Private _ContractDate As DateTime
        Private _Amount As Decimal
        Private _AdditionalAmount As Decimal
        Private _Contact As String
        Private _Telephone As String
        Private _Memo As String
        Private _CreateUser As Integer
        Private _CreateDate As DateTime



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


        'ProjectId
        Public Property ProjectId() As Integer
            Get
                Return _ProjectId
            End Get
            Set(ByVal Value As Integer)
                _ProjectId = Value
            End Set
        End Property


        'ContractDate
        Public Property ContractDate() As DateTime
            Get
                Return _ContractDate
            End Get
            Set(ByVal Value As DateTime)
                _ContractDate = Value
            End Set
        End Property

        'Amount
        Public Property Amount() As Decimal
            Get
                Return _Amount
            End Get
            Set(ByVal Value As Decimal)
                _Amount = Value
            End Set
        End Property


        'AdditionalAmount
        Public Property AdditionalAmount() As Decimal
            Get
                Return _AdditionalAmount
            End Get
            Set(ByVal Value As Decimal)
                _AdditionalAmount = Value
            End Set
        End Property

        'Memo
        Public Property Memo() As String
            Get
                Return _Memo
            End Get
            Set(ByVal Value As String)
                _Memo = Value
            End Set
        End Property


        'Contact
        Public Property Contact() As String
            Get
                Return _Contact
            End Get
            Set(ByVal Value As String)
                _Contact = Value
            End Set
        End Property


        'Telephone
        Public Property Telephone() As String
            Get
                Return _Telephone
            End Get
            Set(ByVal Value As String)
                _Telephone = Value
            End Set
        End Property


        'CreateUser
        Public Property CreateUser() As Integer
            Get
                Return _CreateUser
            End Get
            Set(ByVal Value As Integer)
                _CreateUser = Value
            End Set
        End Property


        'CreateDate
        Public Property CreateDate() As DateTime
            Get
                Return _CreateDate
            End Get
            Set(ByVal Value As DateTime)
                _CreateDate = Value
            End Set
        End Property
    End Class

End Namespace

