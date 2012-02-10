Namespace Model
    Public Class Base_MBPQuestion
        Private _id As Integer
        Private _MBPQuestion As String

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



        'MBPQuestion
        Public Property MBPQuestion() As String
            Get
                Return _MBPQuestion
            End Get
            Set(ByVal Value As String)
                _MBPQuestion = Value
            End Set
        End Property
    End Class
End Namespace
