Namespace Model
    Public Class Base_PricingPosition
        Private _id As Integer
        Private _DepId As Integer
        Private _ShortName As String
        Private _position As String
        Private _Rate As Decimal

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

        'DepId
        Public Property DepId() As Integer
            Get
                Return _DepId
            End Get
            Set(ByVal Value As Integer)
                _DepId = Value
            End Set
        End Property



        'ְλ
        Public Property Position() As String
            Get
                Return _position
            End Get
            Set(ByVal Value As String)
                _position = Value
            End Set
        End Property

        'ShortName
        Public Property ShortName() As String
            Get
                Return _ShortName
            End Get
            Set(ByVal Value As String)
                _ShortName = Value
            End Set
        End Property

        'Rate
        Public Property Rate() As Decimal
            Get
                Return _Rate
            End Get
            Set(ByVal Value As Decimal)
                _Rate = Value
            End Set
        End Property

    End Class
End Namespace
