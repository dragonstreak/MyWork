Imports System.Reflection
Imports System.Text
''' <summary>
''' This is the attribute for model class property mapping.
''' </summary>
''' <remarks></remarks>
Public Class ColumnMappingAttribute
    Inherits Attribute
    Private _columnName As String
    Private _columnType As ColumnType?
    Private _isIdentifyColumn As Boolean = False
    Private _columnSize As Integer

    Public Sub New(ByVal columnName As String)
        Me._columnName = columnName
    End Sub
    Public Sub New(ByVal columnName As String, ByVal columnType As ColumnType)
        Me._columnName = columnName
        Me._columnType = columnType
    End Sub
    Public Sub New(ByVal columnName As String, ByVal isIdentifyColumn As Boolean)
        Me._columnName = columnName
        Me._isIdentifyColumn = isIdentifyColumn
    End Sub
   
    ''' <summary>
    ''' This is the property for getting column name.
    ''' </summary>
    ''' <value></value>
    ''' <returns>Return column name.</returns>
    ''' <remarks></remarks>
    Public ReadOnly Property ColumnName As String
        Get
            Return Me._columnName
        End Get
    End Property
    ''' <summary>
    ''' This is the property for getting column type,column type can be null.
    ''' </summary>
    ''' <value></value>
    ''' <returns>Retury column type.</returns>
    ''' <remarks></remarks>
    Public ReadOnly Property ColumnType As ColumnType?
        Get
            Return _columnType
        End Get
    End Property
    ''' <summary>
    ''' This is the property for get the column is identity column or not.
    ''' </summary>
    ''' <value></value>
    ''' <returns>Return is identity column or not.</returns>
    ''' <remarks></remarks>
    Public ReadOnly Property IsIdentityColumn As Boolean
        Get
            Return _isIdentifyColumn
        End Get
    End Property
   
End Class
''' <summary>
''' This class provide the mapping function.
''' </summary>
''' <remarks></remarks>
Public Class ColumnMappingManage
    Private Shared Function ReaderExists(ByVal reader As IDataReader, ByVal columnName As String) As Boolean
        reader.GetSchemaTable().DefaultView.RowFilter = "ColumnName='" + columnName + "'"
        Return (reader.GetSchemaTable().DefaultView.Count > 0)
    End Function
#Region "Mapping entity"
    ''' <summary>
    ''' This method is used to mapping an entity by row.
    ''' </summary>
    ''' <typeparam name="T">Pass the entity type.</typeparam>
    ''' <param name="entityObject">Pass the entity object.</param>
    ''' <param name="entityRow">Pass the data row.</param>
    ''' <remarks></remarks>
    Public Shared Sub MappingEntityByRow(Of T As New)(ByVal entityObject As T, ByVal entityRow As DataRow)
        For Each propertyInfo As PropertyInfo In entityObject.GetType().GetProperties()
            For Each attr As Attribute In Attribute.GetCustomAttributes((propertyInfo))
                If attr.GetType() = GetType(ColumnMappingAttribute) Then

                    Dim columnMappingAttr As ColumnMappingAttribute = CType(attr, ColumnMappingAttribute)
                    If entityRow.Table.Columns.Contains(columnMappingAttr.ColumnName) = False Then
                        Exit For
                    End If
                    Dim objectValue As Object = entityRow(columnMappingAttr.ColumnName)
                    If objectValue Is Nothing Then
                        Exit For
                    End If
                    Try
                        If columnMappingAttr.ColumnType.HasValue = True Then
                            propertyInfo.SetValue(entityObject, objectValue, Nothing)
                            'in the future, we can have some complex datatype,like short date.
                        Else
                            propertyInfo.SetValue(entityObject, objectValue, Nothing)
                        End If
                    Catch ex As Exception

                    End Try


                End If
            Next
        Next
        SetEntityStatus(entityObject)
    End Sub
    ''' <summary>
    ''' This method is used to mapping entity object by datareader.
    ''' </summary>
    ''' <typeparam name="T">Pass the type of entity object.</typeparam>
    ''' <param name="entityObject">Pass the entity object.</param>
    ''' <param name="entityReader">Pass the entity reader.</param>
    ''' <remarks></remarks>
    Public Shared Sub MappingEntityByDataReader(Of T As New)(ByVal entityObject As T, ByVal entityReader As IDataReader)
        For Each propertyInfo As PropertyInfo In entityObject.GetType().GetProperties()
            For Each attr As Attribute In Attribute.GetCustomAttributes(propertyInfo)
                If attr.GetType() = GetType(ColumnMappingAttribute) Then

                    Dim columnMappingAttr As ColumnMappingAttribute = CType(attr, ColumnMappingAttribute)
                    If ReaderExists(entityReader, columnMappingAttr.ColumnName) = False Then
                        Exit For
                    End If
                    Dim objectValue As Object = entityReader(columnMappingAttr.ColumnName)
                    If objectValue Is Nothing Then
                        Exit For
                    End If
                    Try
                        If columnMappingAttr.ColumnType.HasValue = True Then
                            propertyInfo.SetValue(entityObject, objectValue, Nothing)
                            'in the future, we can have some complex datatype,like short date.
                        Else
                            'fieldInfo.SetValue(entityObject, objectValue)
                            propertyInfo.SetValue(entityObject, objectValue, Nothing)
                        End If
                    Catch ex As Exception

                    End Try


                End If
            Next
        Next
        SetEntityStatus(entityObject)
    End Sub
#End Region
#Region "Mapping entity list"
    ''' <summary>
    ''' This method is used to mapping entity list by dataset,
    ''' we can identify the table index
    ''' </summary>
    ''' <typeparam name="T">Pass the entity type.</typeparam>
    ''' <param name="entityList">Pass the entity List.</param>
    ''' <param name="entityDataSet">Pass the entity dataset.</param>
    ''' <param name="tableIndex">Pass the index of the table of the dataset,default index will be 0.</param>
    ''' <remarks></remarks>
    Public Shared Sub MappingListByDataSet(Of T As New)(ByVal entityList As List(Of T), ByVal entityDataSet As DataSet, ByVal tableIndex As Integer?)
        If entityDataSet.Tables.Count = 0 Then
            Return
        End If
        If tableIndex.HasValue = False Then
            tableIndex = 0
        End If
        If entityDataSet.Tables(tableIndex.Value) Is Nothing Then
            Return
        End If
        For Each dr As DataRow In entityDataSet.Tables(tableIndex.Value).Rows
            Dim entity As New T
            MappingEntityByRow(Of T)(entity, dr)
            entityList.Add(entity)
        Next
    End Sub
    ''' <summary>
    ''' This method is used to mapping entity list by datatable.
    ''' </summary>
    ''' <typeparam name="T">Pass the entity type.</typeparam>
    ''' <param name="entityList">Pass the entity list.</param>
    ''' <param name="entityTable">Pass the entity table.</param>
    ''' <remarks></remarks>
    Public Shared Sub MappingListByDataTable(Of T As New)(ByVal entityList As IList(Of T), ByVal entityTable As DataTable)

        For Each dr As DataRow In entityTable.Rows
            Dim entity As New T
            MappingEntityByRow(Of T)(entity, dr)
            entityList.Add(entity)
        Next
    End Sub
    ''' <summary>
    ''' This method is used to mapping entity list by datarow array
    ''' </summary>
    ''' <typeparam name="T">Pass the entity type.</typeparam>
    ''' <param name="entityList">Pass the entity list.</param>
    ''' <param name="rowArr">Pass the data row array</param>
    ''' <remarks></remarks>
    Public Shared Sub MappingListByDataRowArr(Of T As New)(ByVal entityList As IList(Of T), ByVal rowArr As DataRow())
        For Each dr As DataRow In rowArr
            Dim entity As New T
            MappingEntityByRow(Of T)(entity, dr)
            entityList.Add(entity)
        Next
    End Sub


    ''' <summary>
    ''' This method is used to mapping list by data reader.
    ''' </summary>
    ''' <typeparam name="T">Pass the type of entity object, type should has new constraint.</typeparam>
    ''' <param name="entityList">Pass the entity list.</param>
    ''' <param name="entityReader">Pass the entity reader</param>
    ''' <remarks></remarks>
    Public Shared Sub MappingListByDataReader(Of T As New)(ByVal entityList As IList(Of T), ByVal entityReader As IDataReader)
        While (entityReader.Read())
            Dim entityItem As New T
            MappingEntityByDataReader(entityItem, entityReader)
            entityList.Add(entityItem)

        End While
    End Sub
    Public Shared Sub SetEntityStatus(ByVal entity As Object)
        If TypeOf (entity) Is AbstractEntity Then
            Dim abstratyEntity As AbstractEntity = CType(entity, AbstractEntity)
            abstratyEntity.abstractEntityStatus = EntityStatus.UnChange
        End If

    End Sub
#End Region
End Class
