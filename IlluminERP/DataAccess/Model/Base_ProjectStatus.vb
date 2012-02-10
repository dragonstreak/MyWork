
Namespace Model
    Public Class Base_ProjectStatus
        Private _id As Integer
        Private _ProjctStatus As String

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



        'ProjctStatus
        Public Property ProjctStatus() As String
            Get
                Return _ProjctStatus
            End Get
            Set(ByVal Value As String)
                _ProjctStatus = Value
            End Set
        End Property
    End Class
End Namespace
