

Imports System
Namespace Model
    Public Class PMS_PricingCityInfo
        Private _id As Integer
        Private _PricingCity As String
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


        'PricingCity
        Public Property PricingCity() As String
            Get
                Return _PricingCity
            End Get
            Set(ByVal Value As String)
                _PricingCity = Value
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
