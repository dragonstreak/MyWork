Imports System.Data.SqlClient


Namespace Model
    Public Class System_NewsInfo

        Private _newsID As Integer
        Private _title As String
        Private _newsType As Integer
        Private _severityLevel As Integer
        Private _content As String
        Private _readRate As Integer
        Private _published As Integer
        Private _isDeleted As Integer
        Private _createdBy As Integer
        Private _createdTime As DateTime
        Private _modifiedBy As Integer
        Private _modifiedTime As DateTime
        Private _createByName As String
        Private _modifiedByName As String

        Private _fileList As List(Of Integer)

        Private _identifyIdParam As SqlParameter

        Public Sub New()
            _newsID = 0
            _title = String.Empty
            _newsType = 0
            _severityLevel = 0
            _content = String.Empty
            _readRate = 0
            _published = 0
            _isDeleted = 0
            _createdBy = 0
            _createdTime = DateTime.MinValue
            _modifiedBy = 0
            _modifiedTime = DateTime.MinValue
            _createByName = String.Empty
            _modifiedByName = String.Empty
        End Sub

        Public Property NewsID As Integer
            Get
                Return _newsID
            End Get
            Set(ByVal value As Integer)
                _newsID = value
            End Set
        End Property


        Public Property Title As String
            Get
                Return _title
            End Get
            Set(ByVal value As String)
                _title = value
            End Set
        End Property

        Public Property NewsType As Integer
            Get
                Return _newsType
            End Get
            Set(ByVal value As Integer)
                _newsType = value
            End Set
        End Property

        Public Property SeverityLevel As Integer
            Get
                Return _severityLevel
            End Get
            Set(ByVal value As Integer)
                _severityLevel = value
            End Set
        End Property

        Public Property Content As String
            Get
                Return _content
            End Get
            Set(ByVal value As String)
                _content = value
            End Set
        End Property

        Public Property ReadRate As Integer
            Get
                Return _readRate
            End Get
            Set(ByVal value As Integer)
                _readRate = value
            End Set
        End Property

        Public Property Published As Integer
            Get
                Return _published
            End Get
            Set(ByVal value As Integer)
                _published = value
            End Set
        End Property

        Public Property IsDeleted As Integer
            Get
                Return _isDeleted
            End Get
            Set(ByVal value As Integer)
                _isDeleted = value
            End Set
        End Property

        Public Property CreatedBy As Integer
            Get
                Return _createdBy
            End Get
            Set(ByVal value As Integer)
                _createdBy = value
            End Set
        End Property

        Public Property CreatedTime As DateTime
            Get
                Return _createdTime
            End Get
            Set(ByVal value As DateTime)
                _createdTime = value
            End Set
        End Property

        Public Property ModifiedBy As Integer
            Get
                Return _modifiedBy
            End Get
            Set(ByVal value As Integer)
                _modifiedBy = value
            End Set
        End Property

        Public Property ModifiedTime As DateTime
            Get
                Return _modifiedTime
            End Get
            Set(ByVal value As DateTime)
                _modifiedTime = value
            End Set
        End Property

        Public Property CreatedByName As String
            Get
                Return _createByName
            End Get
            Set(ByVal value As String)
                _createByName = value
            End Set
        End Property

        Public Property ModifiedByName As String
            Get
                Return _modifiedByName
            End Get
            Set(ByVal value As String)
                _modifiedByName = value
            End Set
        End Property

        Public Property FileList As List(Of Integer)
            Get
                Return _fileList
            End Get
            Set(ByVal value As List(Of Integer))
                _fileList = value
            End Set
        End Property

        Public ReadOnly Property SqlScript_Insert As String
            Get
                Dim script As String
                script = "Insert into [t_System_News] (Title,NewsType,SeverityLevel,Content,ReadRate,Published,IsDeleted,CreatedBy,CreatedTime,ModifiedBy,ModifiedTime) "
                script += "Values(@Title,@NewsType,@SeverityLevel,@Content,0,@Published,0,@CreatedBy,@CreatedTime,@ModifiedBy,@ModifiedTime) "
                script += vbCrLf + "Select @IdentityId = @@identity  "
                Return script
            End Get
        End Property

        Public ReadOnly Property SqlScript_Update As String
            Get
                Dim script As String
                script = "Update [t_System_News] set Title = @Title,NewsType = @NewsType,SeverityLevel=@SeverityLevel,Content=@Content,ReadRate=@ReadRate,Published=@Published,IsDeleted=@IsDeleted,ModifiedBy=@ModifiedBy,ModifiedTime=@ModifiedTime "
                script += "Where NewsID = @NewsID"
                Return script
            End Get
        End Property

        ''' <summary>
        ''' this propery can only be invoked after add a news to DB
        ''' when do the insert operation, as primary key NewsID is an identity,
        ''' So after execute insert script, we can use this property to get the NewsID
        ''' </summary>
        ''' <value></value>
        ''' <returns></returns>
        ''' <remarks></remarks>
        Public ReadOnly Property NewIdentifyId As Integer
            Get
                If _identifyIdParam Is Nothing Then
                    Return 0
                End If
                Return Integer.Parse(_identifyIdParam.Value)
            End Get
        End Property

        Public Function GetSqlParameters() As SqlParameter()
            Dim paramList As New List(Of SqlParameter)
            Dim param As SqlParameter

            _identifyIdParam = New SqlParameter("@IdentityId", SqlDbType.Int)
            _identifyIdParam.Direction = ParameterDirection.Output
            paramList.Add(_identifyIdParam)

            param = New SqlParameter("@NewsId", SqlDbType.Int)
            If NewsID > 0 Then
                param.Value = NewsID
            Else
                param.Value = DBNull.Value
            End If
            paramList.Add(param)

            param = New SqlParameter("@Title", SqlDbType.NVarChar)
            param.Value = Title
            paramList.Add(param)

            param = New SqlParameter("@NewsType", SqlDbType.Int)
            If NewsType > 0 Then
                param.Value = NewsType
            Else
                param.Value = DBNull.Value
            End If
            paramList.Add(param)

            param = New SqlParameter("@SeverityLevel", SqlDbType.Int)
            If SeverityLevel > 0 Then
                param.Value = SeverityLevel
            Else
                param.Value = DBNull.Value
            End If
            paramList.Add(param)

            param = New SqlParameter("@Content", SqlDbType.Text)
            param.Value = Content
            paramList.Add(param)

            param = New SqlParameter("@ReadRate", SqlDbType.Int)
            param.Value = ReadRate
            paramList.Add(param)

            param = New SqlParameter("@Published", SqlDbType.Int)
            param.Value = Published
            paramList.Add(param)

            param = New SqlParameter("@IsDeleted", SqlDbType.Int)
            param.Value = IsDeleted
            paramList.Add(param)

            param = New SqlParameter("@CreatedBy", SqlDbType.Int)
            If CreatedBy > 0 Then
                param.Value = CreatedBy
            Else
                param.Value = DBNull.Value
            End If
            paramList.Add(param)

            param = New SqlParameter("@CreatedTime", SqlDbType.DateTime)
            If CreatedTime <> DateTime.MinValue Then
                param.Value = CreatedTime
            Else
                param.Value = DBNull.Value
            End If
            paramList.Add(param)

            param = New SqlParameter("@ModifiedBy", SqlDbType.Int)
            If ModifiedBy > 0 Then
                param.Value = ModifiedBy
            Else
                param.Value = DBNull.Value
            End If
            paramList.Add(param)

            param = New SqlParameter("@ModifiedTime", SqlDbType.DateTime)
            If ModifiedTime <> DateTime.MinValue Then
                param.Value = ModifiedTime
            Else
                param.Value = DBNull.Value
            End If
            paramList.Add(param)

            Return paramList.ToArray()

        End Function
    End Class
End Namespace
