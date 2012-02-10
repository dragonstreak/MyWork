Imports System
Namespace Model

    Public Class PMS_Revenue
        Private _id As Integer
        Private _ProId As Integer
        Private _Revenue As Decimal
        Private _Profit As Decimal
        Private _MBP As Decimal
        Private _MBPReason As String

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

        'ProId
        Public Property ProId() As Integer
            Get
                Return _ProId
            End Get
            Set(ByVal Value As Integer)
                _ProId = Value
            End Set
        End Property

        'ProId
        Public Property Revenue() As Decimal
            Get
                Return _Revenue
            End Get
            Set(ByVal Value As Decimal)
                _Revenue = Value
            End Set
        End Property

        'Profit
        Public Property Profit() As Decimal
            Get
                Return _Profit
            End Get
            Set(ByVal Value As Decimal)
                _Profit = Value
            End Set
        End Property

        '_MBP
        Public Property MBP() As Decimal
            Get
                Return _MBP
            End Get
            Set(ByVal Value As Decimal)
                _MBP = Value
            End Set
        End Property

        '_MBPReason
        Public Property MBPReason() As String
            Get
                Return _MBPReason
            End Get
            Set(ByVal Value As String)
                _MBPReason = Value
            End Set
        End Property

    End Class
End Namespace
