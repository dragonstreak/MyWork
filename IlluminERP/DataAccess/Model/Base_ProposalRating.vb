Namespace Model
    Public Class Base_ProposalRating
        Private _id As Integer
        Private _ProposalRating As String
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


        'ProposalRating
        Public Property ProposalRating() As String
            Get
                Return _ProposalRating
            End Get
            Set(ByVal Value As String)
                _ProposalRating = Value
            End Set
        End Property


    End Class
End Namespace

