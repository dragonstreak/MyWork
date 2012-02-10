Namespace Model
    Public Class Base_MethodologyInfo
        Private _id As Integer
        Private _methodologytype As Integer
        Private _methodology As String
        Private _tag As String

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


        '研究方法类别，1 定量，2 定性
        Public Property MethodologyType() As Integer
            Get
                Return _methodologytype
            End Get
            Set(ByVal Value As Integer)
                _methodologytype = Value
            End Set
        End Property

        '研究方法类别，1 定量，2 定性
        Public Property Methodology() As String
            Get
                Return _methodology
            End Get
            Set(ByVal Value As String)
                _methodology = Value
            End Set
        End Property

        Public Property Tag() As String
            Get
                Return _tag
            End Get
            Set(ByVal Value As String)
                _tag = Value
            End Set
        End Property

    End Class
End Namespace
