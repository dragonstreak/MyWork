
Namespace Model
    Public Class Base_DigitalProducts
        Private _id As Integer
        Private _DigitalProducts As String
        Private _ShortName As String

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



        'DigitalProducts
        Public Property DigitalProducts() As String
            Get
                Return _DigitalProducts
            End Get
            Set(ByVal Value As String)
                _DigitalProducts = Value
            End Set
        End Property


        'ShortName
        Public Property ShortName() As String
            Get
                Return _ShortName
            End Get
            Set(ByVal Value As String)
                _ShortName = Value
            End Set
        End Property

    End Class
End Namespace
