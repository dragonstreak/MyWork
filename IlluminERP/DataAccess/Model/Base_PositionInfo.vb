
Namespace Model
    Public Class Base_PositionInfo
        Private _id As Integer
        Private _position As String

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


        '职位
        Public Property Position() As String
            Get
                Return _position
            End Get
            Set(ByVal Value As String)
                _position = Value
            End Set
        End Property



    End Class

End Namespace
