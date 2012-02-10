Namespace Model
    Public Class Base_BusinessUnit
        Private _id As Integer
        Private _Businessunit As String
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



        '_Businessunit
        Public Property Businessunit() As String
            Get
                Return _Businessunit
            End Get
            Set(ByVal Value As String)
                _Businessunit = Value
            End Set
        End Property
    End Class
End Namespace
