Namespace Model
    Public Class Base_BusinessSolution
        Private _id As Integer
        Private _BusinessSolution As String
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



        '_BusinessSolution
        Public Property BusinessSolution() As String
            Get
                Return _BusinessSolution
            End Get
            Set(ByVal Value As String)
                _BusinessSolution = Value
            End Set
        End Property
    End Class
End Namespace
