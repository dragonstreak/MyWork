'------------------------------------------------------------------------------
' <auto-generated>
'     This code was generated by a tool.
'     Runtime Version:4.0.30319.225
'
'     Changes to this file may cause incorrect behavior and will be lost if
'     the code is regenerated.
' </auto-generated>
'------------------------------------------------------------------------------

Option Strict Off
Option Explicit On

Imports DataAccess.Components
Imports DataAccess.IDAL
Imports DataAccess.Model
Imports Microsoft.ApplicationBlocks.Data
Imports System
Imports System.Data
Imports System.Data.SqlClient
Imports System.Text
Imports Utils

Namespace SQLServerDAL
    
    Friend Class PMS_RespondentCriteriaDAO
        Inherits BaseSqlServerDAO
        Implements IPMS_RespondentCriteria
        
        Public Sub New(ByVal factory As SqlServerFactory)
            MyBase.New(factory)
        End Sub
        
        Public Overridable Function SaveEntity(ByVal entity As PMS_RespondentCriteria) As Integer Implements IPMS_RespondentCriteria.SaveEntity
            Dim paramList As New List(Of SqlParameter)
            Dim id_parameter = New SqlParameter("@id", SqlDbType.Int)
            If entity.id > 0 Then
              id_parameter.Value = entity.id
            Else
              id_parameter.Value = DBNull.Value
            End If
            Dim ComponentId_parameter = New SqlParameter("@ComponentId", SqlDbType.Int)
            ComponentId_parameter.Value = entity.ComponentId
            paramList.Add(ComponentId_parameter)
            Dim Criteria_parameter As New SqlParameter("@Criteria", SqlDbType.NVarChar, 500)
            Criteria_parameter.Value = entity.Criteria
            paramList.Add(Criteria_parameter)
            Dim sql As String = ""
            Dim identityParameter As New SqlParameter("@IdentityId", SqlDbType.Int)
            If (entity.id = -1) Then
              identityParameter.Direction = ParameterDirection.Output
              paramList.Add(identityParameter)
                sql = "insert into t_PMS_RespondentCriteria(ComponentId,Criteria) "
               sql += "values(@ComponentId,@Criteria) Select @IdentityId = @@identity  "
            Else
            paramList.Add(id_parameter)
                  sql = "update t_PMS_RespondentCriteria set ComponentId = @ComponentId,Criteria = @Criteria where id =@id
            End If
            Dim count As Integer
            count = Me.ExecuteNonQuery(sql, paramList.ToArray())
            If (entity.id = -1) Then
              If Not identityParameter Is Nothing Then
                  entity.id = Integer.Parse(identityParameter.Value)
              End If
            End If
            Return count
        End Function
        
        Public Overridable Function GetEntityById(ByVal Id As Integer) As PMS_RespondentCriteria Implements IPMS_RespondentCriteria.GetEntityById
            Dim param As New SqlParameter("@id", SqlDbType.Int)
            param.Value = Id
            Dim strSQL As String = "select * from [t_PMS_RespondentCriteria] where id = @id "
            Dim dr As SqlClient.SqlDataReader
            Try
               dr = Me.ExecuteReader(CommandType.Text, strSQL, param)
               If (dr.Read()) Then
                   Dim entity As New PMS_RespondentCriteria
                   ColumnMappingManage.MappingEntityByDataReader(Of PMS_RespondentCriteria)(entity, dr)
                   Return entity
               Else
                   Return Nothing
               End If
            Catch ex As Exception
               Return Nothing
            Finally
               If (Not dr.IsClosed) Then
                   dr.Close()
               End If
            End Try
        End Function
        
        Public Overridable Sub DeleteEntity(ByVal id As Integer) Implements IPMS_RespondentCriteria.DeleteEntity
             Dim strSql As String = "delete from t_PMS_RespondentCriteria where id= @id
            Dim parameter As New SqlParameter
            parameter.ParameterName = "@id"
            parameter.Value = id
            Me.ExecuteNonQuery(strSql, parameter)
        End Sub
        
        Public Overridable Function GetEntityDataSet() As Dataset Implements IPMS_RespondentCriteria.GetEntityDataSet
            Dim sql As String = "select * from [t_PMS_RespondentCriteria] "
            Dim ds As DataSet = Me.ExecuteDataSet(CommandType.Text, sql)
            Return ds
        End Function
        
        Public Overridable Function GetEntityList() As List(Of PMS_RespondentCriteria) Implements IPMS_RespondentCriteria.GetEntityList
            Dim strSQL As String = "select * from [t_PMS_RespondentCriteria] "
            Dim dr As SqlClient.SqlDataReader
            Try
               dr = Me.ExecuteReader(CommandType.Text, strSQL)
               Dim entityList As New List(Of PMS_RespondentCriteria)
               ColumnMappingManage.MappingListByDataReader(entityList, dr)
               Return entityList
            Catch ex As Exception
               Return Nothing
            Finally
               If (Not dr.IsClosed) Then
                   dr.Close()
               End If
            End Try
        End Function
        Public Overridable Function GetComponentCriteriaList(ByVal componentId As Integer) As List(Of PMS_RespondentCriteria) Implements IPMS_RespondentCriteria.GetComponentCriteriaList
            Dim strSQL As String = "select * from [t_PMS_RespondentCriteria] where componentId = " + componentId.ToString()
            Dim dr As SqlClient.SqlDataReader
            Try
                dr = Me.ExecuteReader(CommandType.Text, strSQL)
                Dim entityList As New List(Of PMS_RespondentCriteria)
                ColumnMappingManage.MappingListByDataReader(entityList, dr)
                Return entityList
            Catch ex As Exception
                Return Nothing
            Finally
                If (Not dr.IsClosed) Then
                    dr.Close()
                End If
            End Try
        End Function

    End Class
End Namespace
