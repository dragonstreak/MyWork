
Namespace Model
    Public Class PMS_ProposalUserType

        Private _id As Integer
        Private _ProposalUserType As String

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


        'Sector
        Public Property ProposalUserType() As String
            Get
                Return _ProposalUserType
            End Get
            Set(ByVal Value As String)
                _ProposalUserType = Value
            End Set
        End Property


    End Class
End Namespace

