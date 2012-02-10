Imports System
Namespace Model
    Public Class PMS_PricingSampleCityInfo
        Private _id As Integer
        Private _ParentId As Integer
        Private _SubJobNumber As String
        Private _CityName_CN As String
        Private _CityName_EN As String
        Private _Type As Integer

        Public Sub New()

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

        'ParentId
        Public Property ParentId() As Integer
            Get
                Return _ParentId
            End Get
            Set(ByVal Value As Integer)
                _ParentId = Value
            End Set
        End Property

        '_SubJobNumber
        Public Property SubJobNumber() As String
            Get
                Return _SubJobNumber
            End Get
            Set(ByVal Value As String)
                _SubJobNumber = Value
            End Set
        End Property

        'CityName_CN
        Public Property CityName_CN() As String
            Get
                Return _CityName_CN
            End Get
            Set(ByVal Value As String)
                _CityName_CN = Value
            End Set
        End Property

        'CityName_EN
        Public Property CityName_EN() As String
            Get
                Return _CityName_EN
            End Get
            Set(ByVal Value As String)
                _CityName_EN = Value
            End Set
        End Property

        'Type
        Public Property Type() As Integer
            Get
                Return _Type
            End Get
            Set(ByVal Value As Integer)
                _Type = Value
            End Set
        End Property
    End Class
End Namespace
