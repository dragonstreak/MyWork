
Namespace Model
    Public Class Client_ClientDetailInfo
        Private _id As Integer
        Private _ClientId As Integer
        Private _FirstNameCN As String
        Private _FirstNameEN As String
        Private _LastNameCN As String
        Private _LastNameEN As String
        Private _CompanyAddressCN As String
        Private _CompanyAddressEN As String


        Private _JobTitle As String
        Private _Department As String
        Private _Email As String
        Private _MobilePhone As String
        Private _TelGeneral As String
        Private _TelDirect As String
        Private _Country As String
        Private _City As String
        Private _PostCode As String
        Private _Website As String

       

        Public Sub New()
            _id = 0
            _ClientId = 0
            _FirstNameCN = String.Empty
            _FirstNameEN = String.Empty
            _LastNameCN = String.Empty
            _LastNameEN = String.Empty
            _CompanyAddressCN = String.Empty
            _CompanyAddressEN = String.Empty
            _JobTitle = String.Empty
            _Department = String.Empty
            _Email = String.Empty
            _MobilePhone = String.Empty
            _TelGeneral = String.Empty
            _TelDirect = String.Empty
            _Country = String.Empty
            _City = String.Empty
            _PostCode = String.Empty
            _Website = String.Empty

     
        End Sub

        'Id
        Public Property Id() As Integer
            Get
                Return _id
            End Get
            Set(ByVal Value As Integer)
                _id = Value
            End Set
        End Property


        'ClientId
        Public Property ClientId() As Integer
            Get
                Return _ClientId
            End Get
            Set(ByVal Value As Integer)
                _ClientId = Value
            End Set
        End Property

        'FirstNameCN
        Public Property FirstNameCN() As String
            Get
                Return _FirstNameCN
            End Get
            Set(ByVal Value As String)
                _FirstNameCN = Value
            End Set
        End Property

        'FirstNameEN
        Public Property FirstNameEN() As String
            Get
                Return _FirstNameEN
            End Get
            Set(ByVal Value As String)
                _FirstNameEN = Value
            End Set
        End Property

        'LastNameCN
        Public Property LastNameCN() As String
            Get
                Return _LastNameCN
            End Get
            Set(ByVal Value As String)
                _LastNameCN = Value
            End Set
        End Property


        'LastNameEN
        Public Property LastNameEN() As String
            Get
                Return _LastNameEN
            End Get
            Set(ByVal Value As String)
                _LastNameEN = Value
            End Set
        End Property


        'CompanyAddressCN
        Public Property CompanyAddressCN() As String
            Get
                Return _CompanyAddressCN
            End Get
            Set(ByVal Value As String)
                _CompanyAddressCN = Value
            End Set
        End Property

        'CompanyAddressEN
        Public Property CompanyAddressEN() As String
            Get
                Return _CompanyAddressEN
            End Get
            Set(ByVal Value As String)
                _CompanyAddressEN = Value
            End Set
        End Property

        'JobTitle
        Public Property JobTitle() As String
            Get
                Return _JobTitle
            End Get
            Set(ByVal Value As String)
                _JobTitle = Value
            End Set
        End Property


        'Department
        Public Property Department() As String
            Get
                Return _Department
            End Get
            Set(ByVal Value As String)
                _Department = Value
            End Set
        End Property


        'Email
        Public Property Email() As String
            Get
                Return _Email
            End Get
            Set(ByVal Value As String)
                _Email = Value
            End Set
        End Property


        'MobilePhone
        Public Property MobilePhone() As String
            Get
                Return _MobilePhone
            End Get
            Set(ByVal Value As String)
                _MobilePhone = Value
            End Set
        End Property


        'TelDirect
        Public Property TelDirect() As String
            Get
                Return _TelDirect
            End Get
            Set(ByVal Value As String)
                _TelDirect = Value
            End Set
        End Property

        'TelGeneral
        Public Property TelGeneral() As String
            Get
                Return _TelGeneral
            End Get
            Set(ByVal Value As String)
                _TelGeneral = Value
            End Set
        End Property

      

        'Country
        Public Property Country() As String
            Get
                Return _Country
            End Get
            Set(ByVal Value As String)
                _Country = Value
            End Set
        End Property

        'City
        Public Property City() As String
            Get
                Return _City
            End Get
            Set(ByVal Value As String)
                _City = Value
            End Set
        End Property

      
        'PostCode
        Public Property PostCode() As String
            Get
                Return _PostCode
            End Get
            Set(ByVal Value As String)
                _PostCode = Value
            End Set
        End Property

   


        'Website
        Public Property Website() As String
            Get
                Return _Website
            End Get
            Set(ByVal Value As String)
                _Website = Value
            End Set
        End Property

      
     

    End Class
End Namespace
