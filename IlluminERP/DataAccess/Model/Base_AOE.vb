
Namespace Model
    Public Class Base_AOE
        Private _id As Integer
        Private _AOE As String

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

      

        'AOE
        Public Property AOE() As String
            Get
                Return _AOE
            End Get
            Set(ByVal Value As String)
                _AOE = Value
            End Set
        End Property
    End Class
End Namespace
