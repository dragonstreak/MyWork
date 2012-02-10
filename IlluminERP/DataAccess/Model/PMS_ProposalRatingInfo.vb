Imports System

Namespace Model
    Public Class PMS_ProposalRatingInfo
        Private _id As Integer
        Private _ProId As Integer
        Private _UserId As Integer
        Private _Rating As Decimal
        Private _Comments As String
        Public Sub New()
            _id = 0
            _ProId = 0
            _UserId = 0
            _Rating = 0
            _Comments = ""

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


        'UserId
        Public Property UserId() As Integer
            Get
                Return _UserId
            End Get
            Set(ByVal Value As Integer)
                _UserId = Value
            End Set
        End Property

        'Rating
        Public Property Rating() As Decimal
            Get
                Return _Rating
            End Get
            Set(ByVal Value As Decimal)
                _Rating = Value
            End Set
        End Property


        'Comments
        Public Property Comments() As String
            Get
                Return _Comments
            End Get
            Set(ByVal Value As String)
                _Comments = Value
            End Set
        End Property
    End Class
End Namespace

