Namespace Model
    Public Class PMS_PricingTimeCost
        Private _id As Integer
        Private _SubProId As Integer
        Private _CityId As Integer
        Private _DepId As Integer
        Private _PositionId As Integer
        Private _StageId As String
        Private _Rate As Decimal
        Private _Amount As Decimal
        Private _TotalCost As Decimal

        Public Sub New()

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

        'SubProId
        Public Property SubProId() As Integer
            Get
                Return _SubProId
            End Get
            Set(ByVal Value As Integer)
                _SubProId = Value
            End Set
        End Property

        'CityId
        Public Property CityId() As String
            Get
                Return _CityId
            End Get
            Set(ByVal Value As String)
                _CityId = Value
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

        'PositionId
        Public Property PositionId() As Integer
            Get
                Return _PositionId
            End Get
            Set(ByVal Value As Integer)
                _PositionId = Value
            End Set
        End Property

        'StageId
        Public Property StageId() As String
            Get
                Return _StageId
            End Get
            Set(ByVal Value As String)
                _StageId = Value
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

        'Amount
        Public Property Amount() As Decimal
            Get
                Return _Amount
            End Get
            Set(ByVal Value As Decimal)
                _Amount = Value
            End Set
        End Property

        'TotalCost
        Public Property TotalCost() As Decimal
            Get
                Return _TotalCost
            End Get
            Set(ByVal Value As Decimal)
                _TotalCost = Value
            End Set
        End Property

    End Class
End Namespace
