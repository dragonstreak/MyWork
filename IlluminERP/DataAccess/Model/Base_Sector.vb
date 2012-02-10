

Namespace Model
    Public Class Base_Sector
        Private _id As Integer
        Private _BusinessUnitId As Integer
        Private _sector As String

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

        'ID
        Public Property BusinessUnitId() As Integer
            Get
                Return _BusinessUnitId
            End Get
            Set(ByVal Value As Integer)
                _BusinessUnitId = Value
            End Set
        End Property


        'Sector
        Public Property Sector() As String
            Get
                Return _sector
            End Get
            Set(ByVal Value As String)
                _sector = Value
            End Set
        End Property




    End Class
End Namespace

