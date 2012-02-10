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
    
    Friend Class PMS_TimingDAO
        Inherits BaseSqlServerDAO
        Implements IPMS_Timing
        
        Public Sub New(ByVal factory As SqlServerFactory)
            MyBase.New(factory)
        End Sub
        
        Public Overridable Function SaveEntity(ByVal entity As PMS_Timing) As Integer Implements IPMS_Timing.SaveEntity
            Dim paramList As New List(Of SqlParameter)
            Dim Id_parameter = New SqlParameter("@Id", SqlDbType.Int)
            If entity.Id > 0 Then
              Id_parameter.Value = entity.Id
            Else
              Id_parameter.Value = DBNull.Value
            End If
            Dim ProposalId_parameter = New SqlParameter("@ProposalId", SqlDbType.Int)
            ProposalId_parameter.Value = entity.ProposalId
            paramList.Add(ProposalId_parameter)
            Dim StageId_parameter = New SqlParameter("@StageId", SqlDbType.Int)
            StageId_parameter.Value = entity.StageId
            paramList.Add(StageId_parameter)
            Dim componentId_parameter = New SqlParameter("@componentId", SqlDbType.Int)
            componentId_parameter.Value = entity.componentId
            paramList.Add(componentId_parameter)
            Dim CreatedBy_parameter = New SqlParameter("@CreatedBy", SqlDbType.Int)
            CreatedBy_parameter.Value = entity.CreatedBy
            paramList.Add(CreatedBy_parameter)
            Dim CreatedDate_parameter = New SqlParameter("@CreatedDate", SqlDbType.DateTime)
            
            CreatedDate_parameter.Value = entity.CreatedDate
            paramList.Add(CreatedDate_parameter)
            Dim UpdatedBy_parameter = New SqlParameter("@UpdatedBy", SqlDbType.Int)
            UpdatedBy_parameter.Value = entity.UpdatedBy
            paramList.Add(UpdatedBy_parameter)
            Dim UpdatedDate_parameter = New SqlParameter("@UpdatedDate", SqlDbType.DateTime)
            
            UpdatedDate_parameter.Value = entity.UpdatedDate
            paramList.Add(UpdatedDate_parameter)
            Dim Task_parameter As New SqlParameter("@Task", SqlDbType.NVarChar, 200)
            Task_parameter.Value = entity.Task
            paramList.Add(Task_parameter)
            Dim StartDate_parameter = New SqlParameter("@StartDate", SqlDbType.DateTime)
             
            StartDate_parameter.Value = entity.StartDate
            paramList.Add(StartDate_parameter)
            Dim EndDate_parameter = New SqlParameter("@EndDate", SqlDbType.DateTime)
             
            EndDate_parameter.Value = entity.EndDate
            paramList.Add(EndDate_parameter)
            Dim QuotationType_parameter As New SqlParameter("@TaskType", SqlDbType.NVarChar, 20)
            QuotationType_parameter.Value = entity.TaskType
            paramList.Add(QuotationType_parameter)
            Dim DayCount_parameter = New SqlParameter("@DayCount", SqlDbType.Int)
            DayCount_parameter.Value = entity.DayCount
            paramList.Add(DayCount_parameter)
            Dim WeekCount_parameter As New SqlParameter("@WeekCount", SqlDbType.NVarChar, 9)
            WeekCount_parameter.Value = entity.WeekCount
            paramList.Add(WeekCount_parameter)
            Dim TaskOrder_parameter = New SqlParameter("@TaskOrder", SqlDbType.Int)
            TaskOrder_parameter.Value = entity.TaskOrder
            paramList.Add(TaskOrder_parameter)
            Dim Jobnumber_parameter As New SqlParameter("@Jobnumber", SqlDbType.NVarChar, 50)
            Jobnumber_parameter.Value = entity.Jobnumber
            paramList.Add(Jobnumber_parameter)
            ' add status column on 2011/12/5
            Dim Status_parameter As New SqlParameter("@Status", SqlDbType.NVarChar, 10)
            Status_parameter.Value = entity.Status
            paramList.Add(Status_parameter)
            Dim sql As String = ""
            Dim identityParameter As New SqlParameter("@IdentityId", SqlDbType.Int)
            If (entity.id = -1) Then
              identityParameter.Direction = ParameterDirection.Output
              paramList.Add(identityParameter)
                sql = "insert into t_PMS_Timing(ProposalId,StageId,componentId,CreatedBy,CreatedDate,UpdatedBy,UpdatedDate,Task,StartDate,EndDate,TaskType,DayCount,WeekCount,TaskOrder,Jobnumber,Status) "
                sql += "values(@ProposalId,@StageId,@componentId,@CreatedBy,@CreatedDate,@UpdatedBy,@UpdatedDate,@Task,@StartDate,@EndDate,@TaskType,@DayCount,@WeekCount,@TaskOrder,@Jobnumber,@Status) Select @IdentityId = @@identity  "
            Else
            paramList.Add(Id_parameter)
                sql = "update t_PMS_Timing set ProposalId = @ProposalId,StageId = @StageId,componentId = @componentId,CreatedBy = @CreatedBy,CreatedDate = @CreatedDate,UpdatedBy = @UpdatedBy,UpdatedDate = @UpdatedDate,Task = @Task,StartDate = @StartDate,EndDate = @EndDate,TaskType = @TaskType,DayCount = @DayCount,WeekCount = @WeekCount,TaskOrder = @TaskOrder,Jobnumber = @Jobnumber,Status=@Status where Id =@Id"
            End If
            Dim count As Integer
            count = Me.ExecuteNonQuery(sql, paramList.ToArray())
            If (entity.Id = -1) Then
              If Not identityParameter Is Nothing Then
                  entity.Id = Integer.Parse(identityParameter.Value)
              End If
            End If
            Return count
        End Function
        
        Public Overridable Function GetEntityById(ByVal Id As Integer) As PMS_Timing Implements IPMS_Timing.GetEntityById
            Dim param As New SqlParameter("@Id", SqlDbType.Int)
            param.Value = Id
            Dim strSQL As String = "select *,'' as ComponentName from [t_PMS_Timing] where Id = @Id "
            Dim dr As SqlClient.SqlDataReader
            Try
               dr = Me.ExecuteReader(CommandType.Text, strSQL, param)
               If (dr.Read()) Then
                   Dim entity As New PMS_Timing
                   ColumnMappingManage.MappingEntityByDataReader(Of PMS_Timing)(entity, dr)
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
        
        Public Overridable Sub DeleteEntity(ByVal Id As Integer) Implements IPMS_Timing.DeleteEntity
             Dim strSql As String = "delete from t_PMS_Timing where Id= @Id
            Dim parameter As New SqlParameter
            parameter.ParameterName = "@Id"
            parameter.Value = Id
            Me.ExecuteNonQuery(strSql, parameter)
        End Sub
        
        Public Overridable Function GetEntityDataSet() As Dataset Implements IPMS_Timing.GetEntityDataSet
            Dim sql As String = "select *,'' as ComponentName from [t_PMS_Timing] "
            Dim ds As DataSet = Me.ExecuteDataSet(CommandType.Text, sql)
            Return ds
        End Function
        
        Public Overridable Function GetEntityList() As List(Of PMS_Timing) Implements IPMS_Timing.GetEntityList
            Dim strSQL As String = "select *,'' as ComponentName from [t_PMS_Timing] "
            Dim dr As SqlClient.SqlDataReader
            Try
               dr = Me.ExecuteReader(CommandType.Text, strSQL)
               Dim entityList As New List(Of PMS_Timing)
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
        Public Function GetProposalTimingList(ByVal proposalId As Integer) As List(Of PMS_Timing) Implements IPMS_Timing.GetProposalTimingList
            Dim strSQL As String = "select t_PMS_Timing.*,StageName,StageNumber,'' as ComponentName from t_PMS_Timing,t_PMS_ProposalStage where t_PMS_Timing.StageId = t_PMS_ProposalStage.Id and t_PMS_Timing.ProposalId=" + proposalId.ToString
            Dim dr As SqlClient.SqlDataReader
            Try
                dr = Me.ExecuteReader(CommandType.Text, strSQL)
                Dim entityList As New List(Of PMS_Timing)
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
        Public Function GetTimingListByJobNumber(ByVal jobNumber As String) As List(Of PMS_Timing) Implements IPMS_Timing.GetTimingListByJobNumber
            Dim strSQL As String = "select t_PMS_Timing.*,StageName,StageNumber,ComponentName from t_PMS_Timing left join t_PMS_ProposalStage on t_PMS_Timing.StageId =t_PMS_ProposalStage.Id"
            strSQL += " left join dbo.t_PMS_Component on t_PMS_Timing.componentId  = t_PMS_Component.id where  t_PMS_Timing.Status='Active' and t_PMS_Timing.Jobnumber='" + jobNumber + "' order by StageNumber,componentId"
            Dim dr As SqlClient.SqlDataReader
            Try
                dr = Me.ExecuteReader(CommandType.Text, strSQL)
                Dim entityList As New List(Of PMS_Timing)
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
        Public Function GetTimingListByComponentId(ByVal componentId As String) As List(Of PMS_Timing) Implements IPMS_Timing.GetTimingListByComponentId
            Dim strSQL As String = "select t_PMS_Timing.*,StageName,StageNumber,ComponentName from t_PMS_Timing left join t_PMS_ProposalStage on t_PMS_Timing.StageId =t_PMS_ProposalStage.Id"
            strSQL += " left join dbo.t_PMS_Component on t_PMS_Timing.componentId  = t_PMS_Component.id where  t_PMS_Timing.Status='Active' and t_PMS_Component.id='" + componentId + "' order by StageNumber,componentId"
            Dim dr As SqlClient.SqlDataReader
            Try
                dr = Me.ExecuteReader(CommandType.Text, strSQL)
                Dim entityList As New List(Of PMS_Timing)
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
        Public Function GetInitTimingListByMethodology(ByVal methodologyId As String) As List(Of PMS_Timing) Implements IPMS_Timing.GetInitTimingListByMethodology
            Dim parameter As New SqlParameter
            parameter.ParameterName = "@MethodologyId"
            parameter.Value = methodologyId
            Dim strSQL As String = "SELECT -1 as ID,0 as ProposalId,-1 as StageId,-1 as componentId,null as CreatedBy,null as CreatedDate,null as UpdatedBy,null as UpdatedDate,TaskName as Task,null as StartDate,null as EndDate,TaskType,0 as DayCount,0 as WeekCount,1 as TaskOrder,'' as Jobnumber,'Active' as Status,'' as ComponentName "
            strSQL += " from t_Base_MethodologyTask where MethodologyId=@MethodologyId  and TaskFor='Timing'"
            Dim dr As SqlClient.SqlDataReader
            Try
                dr = Me.ExecuteReader(CommandType.Text, strSQL, parameter)
                Dim entityList As New List(Of PMS_Timing)
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
        Public Overridable Function SaveTimingList(ByVal timingList As List(Of PMS_Timing)) As Boolean Implements IPMS_Timing.SaveTimingList
            Try
                For Each timing As PMS_Timing In timingList
                    If timing.Id > 0 Then
                        Continue For
                    End If
                    SaveEntity(timing)
                Next
                Return True
            Catch ex As Exception
                Return False
            End Try
        End Function
        Public Overridable Function SetTimingListStatus(ByVal timingList As List(Of PMS_Timing), ByVal status As String) As Boolean Implements IPMS_Timing.SetTimingListStatus
            Try
                Dim parameter As New SqlParameter
                parameter.ParameterName = "@Status"
                parameter.Value = status
                Dim sql As String = "update t_PMS_Timing set Status=@Status where Id in("
                For Each timing As PMS_Timing In timingList
                    If timing.Id <= 0 Then
                        Continue For
                    End If
                    sql += timing.Id.ToString() + ","
                Next
                sql = sql.Substring(0, sql.Length - 1) + ")"
                Dim count As Integer
                count = Me.ExecuteNonQuery(sql, parameter)
                Return count > 0
            Catch ex As Exception
                Return False
            End Try
        End Function
    End Class
End Namespace
