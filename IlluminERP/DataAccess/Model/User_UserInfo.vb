Imports System

Namespace Model
    <Serializable()>
    Public Class User_UserInfo
        Private _id As Integer
        Private _code As String
        Private _c_name As String
        Private _e_name As String
        Private _email As String
        Private _password As String
        Private _pin As String
        Private _cityId As Integer
        Private _depId As Integer
        Private _teamId As Integer
        Private _LineManager As Integer
        Private _Director As Integer
        Private _Level As Integer
        Private _positionId As Integer
        Private _onduty As Integer
        Private _Companytype As Integer
        Private _remark As String
        Private _commencementDate As DateTime
        Private _workPhone As String
        Private _isProjectOwner As Integer

        Private _roleIds As List(Of Integer)
        Private _permissionIds As List(Of Integer)


        Public Sub New()
            _id = 0
            _code = String.Empty
            _c_name = String.Empty
            _e_name = String.Empty
            _email = String.Empty
            _password = String.Empty
            _pin = String.Empty
            _cityId = 0
            _depId = 0
            _teamId = 0
            _LineManager = 0
            _Director = 0
            _Level = 0
            _positionId = 0
            _onduty = 0
            _Companytype = 0
            _isProjectOwner = 0
            _workPhone = String.Empty
            _remark = String.Empty
            _commencementDate = Now.Date
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

        '���
        Public Property Code() As String
            Get
                Return _code
            End Get
            Set(ByVal Value As String)
                _code = Value
            End Set
        End Property

        '������
        Public Property C_Name() As String
            Get
                Return _c_name
            End Get
            Set(ByVal Value As String)
                _c_name = Value
            End Set
        End Property

        'Ӣ����
        Public Property E_Name() As String
            Get
                Return _e_name
            End Get
            Set(ByVal Value As String)
                _e_name = Value
            End Set
        End Property

        ' Email
        Public Property Email() As String
            Get
                Return _email
            End Get
            Set(ByVal Value As String)
                _email = Value
            End Set
        End Property

        ' ���� 
        Public Property Password() As String
            Get
                Return _password
            End Get
            Set(ByVal Value As String)
                _password = Value
            End Set
        End Property

        ' PIN Code 
        Public Property PIN() As String
            Get
                Return _pin
            End Get
            Set(ByVal Value As String)
                _pin = Value
            End Set
        End Property


        ' ���ڳ���   
        Public Property CityId() As Integer
            Get
                Return _cityId
            End Get
            Set(ByVal Value As Integer)
                _cityId = Value
            End Set
        End Property

        '����
        Public Property DepId() As Integer
            Get
                Return _depId
            End Get
            Set(ByVal Value As Integer)
                _depId = Value
            End Set
        End Property

        '�Ŷ�
        Public Property TeamId() As Integer
            Get
                Return _teamId
            End Get
            Set(ByVal Value As Integer)
                _teamId = Value
            End Set
        End Property


        'Line Manager
        Public Property LineManager() As Integer
            Get
                Return _LineManager
            End Get
            Set(ByVal Value As Integer)
                _LineManager = Value
            End Set
        End Property

        ' Line Director
        Public Property Director() As Integer
            Get
                Return _Director
            End Get
            Set(ByVal Value As Integer)
                _Director = Value
            End Set
        End Property

        '����
        Public Property Level() As Integer
            Get
                Return _Level
            End Get
            Set(ByVal Value As Integer)
                _Level = Value
            End Set
        End Property


        'ְλ
        Public Property PositionID() As Integer
            Get
                Return _positionId
            End Get
            Set(ByVal Value As Integer)
                _positionId = Value
            End Set
        End Property



        '�Ƿ���ְ
        Public Property Onduty() As Integer
            Get
                Return _onduty
            End Get
            Set(ByVal Value As Integer)
                _onduty = Value
            End Set
        End Property

        '��˾����
        Public Property CompanyType() As Integer
            Get
                Return _Companytype
            End Get
            Set(ByVal Value As Integer)
                _Companytype = Value
            End Set
        End Property


        '��ְ����
        Public Property CommencementDate() As DateTime
            Get
                Return _commencementDate
            End Get
            Set(ByVal Value As DateTime)
                _commencementDate = Value
            End Set
        End Property

        '�绰����
        Public Property WorkPhone() As String
            Get
                Return _workPhone
            End Get
            Set(ByVal Value As String)
                _workPhone = Value
            End Set
        End Property

        ' ��ע
        Public Property Remark() As String
            Get
                Return _remark
            End Get
            Set(ByVal Value As String)
                _remark = Value
            End Set
        End Property



        Public Property isProjectOwner As Integer
            Get
                Return _isProjectOwner
            End Get
            Set(ByVal value As Integer)
                _isProjectOwner = value
            End Set
        End Property



        Public Property RoleIds As List(Of Integer)
            Get
                Return _roleIds
            End Get
            Set(ByVal value As List(Of Integer))
                _roleIds = value
            End Set
        End Property

        Public Property PermissionIds As List(Of Integer)
            Get
                Return _permissionIds
            End Get
            Set(ByVal value As List(Of Integer))
                _permissionIds = value
            End Set
        End Property
    End Class
End Namespace
