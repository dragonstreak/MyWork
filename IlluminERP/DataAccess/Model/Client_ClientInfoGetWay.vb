
Namespace Model
    Public Class Client_ClientInfoGetWay
        Private _Id As Integer
        Private _ClientId As Integer
        Private _WayTypeId As Integer
        Private _Description As String


        Public Sub New()
            _id = 0
            _ClientId = 0
            _WayTypeId = 0
            _Description = String.Empty

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


        'ClientId
        Public Property ClientId() As Integer
            Get
                Return _ClientId
            End Get
            Set(ByVal Value As Integer)
                _ClientId = Value
            End Set
        End Property

        'WayTypeId
        Public Property WayTypeId() As Integer
            Get
                Return _WayTypeId
            End Get
            Set(ByVal Value As Integer)
                _WayTypeId = Value
            End Set
        End Property

        'Description
        Public Property Description() As String
            Get
                Return _Description
            End Get
            Set(ByVal Value As String)
                _Description = Value
            End Set
        End Property


    End Class
End Namespace
