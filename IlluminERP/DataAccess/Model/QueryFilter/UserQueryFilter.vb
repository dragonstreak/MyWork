Namespace Model
    Public Class UserQueryFilter
        Public Sub New()
            _name = ""
        End Sub
        Private _name As String
        Private _departmentID As Integer
        Private _positionID As Integer
        Private _cityID As Integer

        Public Property Name() As String
            Get
                Return _name
            End Get
            Set(ByVal Value As String)
                _name = Value
            End Set
        End Property
        Public Property DepartmentID() As Integer
            Get
                Return _departmentID
            End Get
            Set(ByVal Value As Integer)
                _departmentID = Value
            End Set
        End Property
        Public Property PositionID() As Integer
            Get
                Return _positionID
            End Get
            Set(ByVal Value As Integer)
                _positionID = Value
            End Set
        End Property
        Public Property CityID() As Integer
            Get
                Return _cityID
            End Get
            Set(ByVal Value As Integer)
                _cityID = Value
            End Set
        End Property



    End Class
End Namespace

