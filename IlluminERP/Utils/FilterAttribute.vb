Imports System.Reflection
Imports System.Text
''' <summary>
''' This is match type for the filter condition.
''' </summary>
''' <remarks></remarks>
Public Enum MatchType
    Likes = 0
    Equals = 1
    Greater = 2
    Less = 3
    GreaterOrEqual = 4
    LessOrEqual = 5
End Enum
''' <summary>
''' This is the column type of  filter column.
''' </summary>
''' <remarks></remarks>
Public Enum ColumnType
    VarcharColumn = 0
    IntColumn = 1
    DoubleColumn = 2
    DateColumn = 3
End Enum

''' <summary>
''' This is the attribute for filter class.
''' </summary>
''' <remarks></remarks>
Public Class FilterAttribute
    Inherits Attribute
    Public FilterColumnName As String
    Public DefaultValue As String = ""
    Public MatchType As MatchType = Utils.MatchType.Equals
    Public FilterName As String
    Public TableName As String
    Public ColumnType As ColumnType

    ''' <summary>
    ''' This is the constructor for column can be empty or be filterName
    ''' </summary>
    ''' <param name="_filterColumnName">Pass the fileter column name, can use ',' to seprate more than one column.</param>
    ''' <param name="_filterName">Pass the filter name.</param>
    ''' <param name="_matchType">Pass the match type.</param>
    ''' <param name="_tableName">Pass the table name, now we don't use this parameter.</param>
    ''' <remarks></remarks>
    Public Sub New(ByVal _filterColumnName As String, ByVal _filterName As String, ByVal _tableName As String, ByVal _matchType As MatchType)
        FilterColumnName = _filterColumnName
        FilterName = _filterName

        MatchType = _matchType
        TableName = _tableName
    End Sub
    ''' <summary>
    ''' This is the constructor for column can be defaultValue or be filterName
    ''' </summary>
    ''' <param name="_filterColumnName">Pass the fileter column name, can use ',' to seprate more than one column.</param>
    ''' <param name="_filterName">Pass the filter name.</param>
    ''' <param name="_columnType">Pass the column type.</param>
    ''' <param name="_defaultValue">Pass the default value.</param>
    ''' <param name="_matchType">Pass the match type.</param>
    ''' <param name="_tableName">Pass the table name,now we don't use this parameter.</param>
    ''' <remarks></remarks>
    Public Sub New(ByVal _filterColumnName As String, ByVal _filterName As String, ByVal _tableName As String, ByVal _defaultValue As String, ByVal _columnType As ColumnType, ByVal _matchType As MatchType)
        FilterColumnName = _filterColumnName
        FilterName = _filterName
        ColumnType = _columnType
        DefaultValue = _defaultValue
        MatchType = MatchType
        TableName = _tableName
    End Sub
    
End Class

Public Class FilterManager
    Public Shared Function GetFilterCondition(Of t)(ByVal filterClass As t) As String
        Dim condition As New StringBuilder
        'loop into filterClass's fields
        For Each memberInfo As MemberInfo In filterClass.GetType().GetMembers()
            For Each attr As Attribute In Attribute.GetCustomAttributes(memberInfo)
                If attr.GetType() = GetType(FilterAttribute) Then
                    Dim filterAttribute As FilterAttribute = CType(attr, FilterAttribute)
                    Dim columnArray() As String = filterAttribute.FilterColumnName.Split(New Char() {","c})

                    condition.Append(" and (").Append(filterAttribute.FilterName).Append(" =").Append(GetColumnValue(filterAttribute.ColumnType, filterAttribute.DefaultValue))
                    For Each columnName As String In columnArray
                        condition.Append(" or ").Append(columnName).Append(GetMatchDetail(filterAttribute.MatchType, filterAttribute.ColumnType, filterAttribute.FilterName))
                    Next
                    condition.Append(")")
                End If
            Next
        Next
        Return condition.ToString()
    End Function
    ''' <summary>
    ''' This method is uese to get match detail.
    ''' </summary>
    ''' <param name="_matchType">Pass the match type.</param>
    ''' <param name="_columnType">Pass the column type.</param>
    ''' <param name="columnValue">Pass the column value.</param>
    ''' <returns>Return the match string.</returns>
    ''' <remarks></remarks>
    Private Shared Function GetMatchDetail(ByVal _matchType As MatchType, ByVal _columnType As ColumnType, ByVal columnValue As String)
        If _matchType = MatchType.Likes Then
            Return " like '%'+" + columnValue + "+'%'"
        ElseIf _matchType = MatchType.Equals Then
            Return " =" + GetColumnValue(_columnType, columnValue)
        ElseIf _matchType = MatchType.Greater Then
            Return " >" + GetColumnValue(_columnType, columnValue)
        ElseIf _matchType = MatchType.Less Then
            Return " <" + GetColumnValue(_columnType, columnValue)
        ElseIf _matchType = MatchType.GreaterOrEqual Then
            Return " >=" + GetColumnValue(_columnType, columnValue)
        ElseIf _matchType = MatchType.LessOrEqual Then
            Return " <=" + GetColumnValue(_columnType, columnValue)
        End If

        Return ""
    End Function
    ''' <summary>
    ''' This method is used to deal with the string by column type,
    ''' if column type is varchar, should add ' to the string.
    ''' else no need to treat
    ''' </summary>
    ''' <param name="_columnType">Pass the column type.</param>
    ''' <param name="columnValue">Pass the column value.</param>
    ''' <returns>Return the column value with ' or not.</returns>
    ''' <remarks></remarks>
    Private Shared Function GetColumnValue(ByVal _columnType As ColumnType, ByVal columnValue As String) As String
        If _columnType = ColumnType.VarcharColumn Then
            Return "'" + columnValue + "'"
        End If
        Return columnValue
    End Function

End Class
