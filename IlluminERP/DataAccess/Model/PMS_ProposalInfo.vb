
Imports System

Namespace Model

    <Serializable()>
    Public Class PMS_ProposalInfo
        Private _id As Integer
        Private _JobNumber As String
        Private _JobName As String
        Private _JobIndex As String

        Private _BusinessUnitId As Integer
        Private _SectorId As Integer
        Private _ProductCategoryId As Integer
        Private _StudyTypeId As String
        Private _ClientId As Integer
        Private _ProposalRating As Integer
        Private _Isconfidential As Integer
        Private _Probability As Decimal
        Private _Status As Integer
        Private _StatusNote As String
        Private _StatusDate As DateTime
        Private _CreateDate As DateTime
        Private _UploadFilePath As String
        Private _Description As String
        Private _KeyWords As String

        Public Sub New()
            _id = 0
            _JobNumber = String.Empty
            _JobName = String.Empty
            _JobIndex = "-"
            _SectorId = 0
            _ProductCategoryId = 0
            _StudyTypeId = ""
            _Probability = 0
            _Status = 1
            _CreateDate = Now.Date
            _KeyWords = ""
            _Description = String.Empty
            _ProposalRating = 0

        End Sub

        Public Sub New(ByVal sJobNumber As String, ByVal sJobName As String, ByVal sKeywords As String, ByVal iClient As Integer,
                       ByVal iSector As Integer, ByVal sStudytype As String, ByVal iProductCategory As Integer,
                       ByVal iBusinessUnit As Integer, ByVal iStatus As Integer, ByVal iProposalRating As Integer)
            _id = 0
            _JobNumber = sJobNumber
            _JobName = sJobName
            _ClientId = iClient
            _StudyTypeId = sStudytype
            _ProductCategoryId = iProductCategory
            _BusinessUnitId = iBusinessUnit
            _Status = iStatus
            _ProposalRating = iProposalRating
            _SectorId = iSector
            _Probability = 0
            _Status = iStatus
            _CreateDate = Now.Date
            _Description = String.Empty
            _KeyWords = sKeywords

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

        'JobNumber
        Public Property JobNumber() As String
            Get
                Return _JobNumber
            End Get
            Set(ByVal Value As String)
                _JobNumber = Value
            End Set
        End Property

        'JobName
        Public Property JobName() As String
            Get
                Return _JobName
            End Get
            Set(ByVal Value As String)
                _JobName = Value
            End Set
        End Property


        'JobIndex
        Public Property JobIndex() As String
            Get
                Return _JobIndex
            End Get
            Set(ByVal Value As String)
                _JobIndex = Value
            End Set
        End Property


        'BusinessUnitId
        Public Property BusinessUnitId() As Integer
            Get
                Return _BusinessUnitId
            End Get
            Set(ByVal Value As Integer)
                _BusinessUnitId = Value
            End Set
        End Property


        'SectorId
        Public Property SectorId() As Integer
            Get
                Return _SectorId
            End Get
            Set(ByVal Value As Integer)
                _SectorId = Value
            End Set
        End Property

        '_ProductCategoryId
        Public Property ProductCategoryId() As Integer
            Get
                Return _ProductCategoryId
            End Get
            Set(ByVal Value As Integer)
                _ProductCategoryId = Value
            End Set
        End Property


        'StudyTypeId
        Public Property StudyTypeId() As String
            Get
                Return _StudyTypeId
            End Get
            Set(ByVal Value As String)
                _StudyTypeId = Value
            End Set
        End Property


        'Client
        Public Property ClientId() As Integer
            Get
                Return _ClientId
            End Get
            Set(ByVal Value As Integer)
                _ClientId = Value
            End Set
        End Property

        'ProposalRating
        Public Property ProposalRating() As Integer
            Get
                Return _ProposalRating
            End Get
            Set(ByVal Value As Integer)
                _ProposalRating = Value
            End Set
        End Property

        '_Isconfidential
        Public Property Isconfidential() As Integer
            Get
                Return _Isconfidential
            End Get
            Set(ByVal Value As Integer)
                _Isconfidential = Value
            End Set
        End Property

        '可能性
        Public Property Probability() As Decimal
            Get
                Return _Probability
            End Get
            Set(ByVal Value As Decimal)
                _Probability = Value
            End Set
        End Property

        '状态
        Public Property Status() As Integer
            Get
                Return _Status
            End Get
            Set(ByVal Value As Integer)
                _Status = Value
            End Set
        End Property


        ' 状态描述
        Public Property StatusNote() As String
            Get
                Return _StatusNote
            End Get
            Set(ByVal Value As String)
                _StatusNote = Value
            End Set
        End Property

        ' 状态设置时间
        Public Property StatusDate() As DateTime
            Get
                Return _StatusDate
            End Get
            Set(ByVal Value As DateTime)
                _StatusDate = Value
            End Set
        End Property

        '创建日期
        Public Property CreateDate() As DateTime
            Get
                Return _CreateDate
            End Get
            Set(ByVal Value As DateTime)
                _CreateDate = Value
            End Set
        End Property


        ' 上传路径
        Public Property UploadFilePath() As String
            Get
                Return _UploadFilePath
            End Get
            Set(ByVal Value As String)
                _UploadFilePath = Value
            End Set
        End Property


        ' 备注
        Public Property Description() As String
            Get
                Return _Description
            End Get
            Set(ByVal Value As String)
                _Description = Value
            End Set
        End Property


        ' 关键字
        Public Property KeyWords() As String
            Get
                Return _KeyWords
            End Get
            Set(ByVal Value As String)
                _KeyWords = Value
            End Set
        End Property


    End Class
End Namespace
