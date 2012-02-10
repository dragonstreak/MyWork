'------------------------------------------------------------------------------
' <auto-generated>
'     This code was generated by a tool.
'     Runtime Version:4.0.30319.1
'
'     Changes to this file may cause incorrect behavior and will be lost if
'     the code is regenerated.
' </auto-generated>
'------------------------------------------------------------------------------

Option Strict Off
Option Explicit On

Imports System
Imports System.Data.SqlClient

Namespace Model
    
    <System.SerializableAttribute()>  _
    Public Class Base_ListItem
        
        Private _ListItemID As Integer
        
        Private _Type As Integer
        
        Private _ContentText As String
        
        Private _ParentID As Integer
        
        Private _IsDeleted As Integer

        Private _identifyIdParam As SqlParameter
        
        Public Sub New()
            _ListItemID = 0
            _Type = 0
            _ContentText = Nothing
            _ParentID = 0
            _IsDeleted = 0

        End Sub
        
        'This is the property of ListItemID
        Public Property ListItemID() As Integer
            Get
                Return Me._ListItemID
            End Get
            Set
                Me._ListItemID = value
            End Set
        End Property
        
        'This is the property of Type
        Public Property Type() As Integer
            Get
                Return Me._Type
            End Get
            Set
                Me._Type = value
            End Set
        End Property
        
        'This is the property of ContentText
        Public Property ContentText() As String
            Get
                Return Me._ContentText
            End Get
            Set
                Me._ContentText = value
            End Set
        End Property
        
        'This is the property of ParentID
        Public Property ParentID() As Integer
            Get
                Return Me._ParentID
            End Get
            Set
                Me._ParentID = value
            End Set
        End Property
        
        'This is the property of IsDeleted
        Public Property IsDeleted() As Integer
            Get
                Return Me._IsDeleted
            End Get
            Set
                Me._IsDeleted = value
            End Set
        End Property

        Public ReadOnly Property SqlScript_Insert As String
            Get
                Dim script As String
                script = "Insert into t_Base_ListItem([Type],ContentText,ParentID,IsDeleted) "
                script += "Values(@Type,@ContentText,@ParentID,@IsDeleted) "
                script += vbCrLf + "Select @IdentityId = @@identity  "
                Return script
            End Get
        End Property

        Public ReadOnly Property SqlScript_Update As String
            Get
                Dim script As String
                script = "Update t_Base_ListItem set ContentText = @ContentText, [Type]=@Type, ParentID = @ParentID, IsDeleted = @IsDeleted "
                script += "Where ListItemID = @ListItemID"
                Return script
            End Get
        End Property

        ''' <summary>
        ''' this propery can only be invoked after add a ListItem to DB
        ''' when do the insert operation, as primary key ListItemID is an identity,
        ''' So after execute insert script, we can use this property to get the ListItemID
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

            param = New SqlParameter("@ListItemID", SqlDbType.Int)
            If ListItemID > 0 Then
                param.Value = ListItemID
            Else
                param.Value = DBNull.Value
            End If
            paramList.Add(param)

            param = New SqlParameter("@Type", SqlDbType.Int)
            param.Value = Type
            paramList.Add(param)

            param = New SqlParameter("@ContentText", SqlDbType.NVarChar)
            If ContentText IsNot Nothing Then
                param.Value = ContentText
            Else
                param.Value = DBNull.Value
            End If
            paramList.Add(param)

            param = New SqlParameter("@ParentID", SqlDbType.Int)
            If ParentID > 0 Then
                param.Value = ParentID
            Else
                param.Value = DBNull.Value
            End If
            paramList.Add(param)

            param = New SqlParameter("@IsDeleted", SqlDbType.Int)
            param.Value = IsDeleted
            paramList.Add(param)

            Return paramList.ToArray()

        End Function
    End Class
End Namespace
