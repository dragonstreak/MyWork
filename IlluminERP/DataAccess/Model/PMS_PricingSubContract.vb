Imports System
Namespace Model
    Public Class PMS_PricingSubContract
        Private _id As Integer
        Private _SubProId As Integer
        Private _PricingCityId As Integer
        Private _DepId As Integer
        Private _SubCity As String
        Private _SubName As String
        Private _UnitPrice As Decimal
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

        'DepId
        Public Property DepId() As String
            Get
                Return _DepId
            End Get
            Set(ByVal Value As String)
                _DepId = Value
            End Set
        End Property


        'CityId
        Public Property PricingCityId() As String
            Get
                Return _PricingCityId
            End Get
            Set(ByVal Value As String)
                _PricingCityId = Value
            End Set
        End Property


        'SubCity
        Public Property SubCity() As String
            Get
                Return _SubCity
            End Get
            Set(ByVal Value As String)
                _SubCity = Value
            End Set
        End Property


        Public Property SubName() As String
            Get
                Return _SubName
            End Get
            Set(ByVal Value As String)
                _SubName = Value
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
