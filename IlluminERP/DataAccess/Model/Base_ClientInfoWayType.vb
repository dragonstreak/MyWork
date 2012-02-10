
Namespace Model
    Public Class Base_ClientInfoWayType
        Private _id As Integer
        Private _InformationWay As String

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


        'InformationWay 信息来源
        Public Property InformationWay() As String
            Get
                Return _InformationWay
            End Get
            Set(ByVal Value As String)
                _InformationWay = Value
            End Set
        End Property
    End Class
End Namespace
