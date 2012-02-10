Namespace Model
    Public Class PMS_PricingDirectCostInfo
        Private _id As Integer
        Private _SubProId As Integer
        Private _DepId As Integer
        Private _CityId As Integer
        Private _CostCategoryId As Integer
        Private _UnitPrice As Decimal
        Private _Quantity As Decimal
        Private _TotalCost As Decimal
        Private _Description As String

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

        'DepId
        Public Property DepId() As Integer
            Get
                Return _DepId
            End Get
            Set(ByVal Value As Integer)
                _DepId = Value
            End Set
        End Property

        'CityId
        Public Property CityId() As Integer
            Get
                Return _CityId
            End Get
            Set(ByVal Value As Integer)
                _CityId = Value
            End Set
        End Property

        'CostCategoryId
        Public Property CostCategoryId() As Integer
            Get
                Return _CostCategoryId
            End Get
            Set(ByVal Value As Integer)
                _CostCategoryId = Value
            End Set
        End Property

        'UnitPrice
        Public Property UnitPrice() As Decimal
            Get
                Return _UnitPrice
            End Get
            Set(ByVal Value As Decimal)
                _UnitPrice = Value
            End Set
        End Property

        'Quantity
        Public Property Quantity() As Decimal
            Get
                Return _Quantity
            End Get
            Set(ByVal Value As Decimal)
                _Quantity = Value
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

        'Description
        Public Property Description() As String
            Get
                Return _Description
            End Get
            Set(ByVal Value As String)
                _Description = Value
            End Set
        End Property
    End Class
End Namespace
