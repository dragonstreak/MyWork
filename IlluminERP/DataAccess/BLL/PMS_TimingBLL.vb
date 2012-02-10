Imports DataAccess.IDAL
Imports DataAccess.SQLServerDAL
Imports DataAccess.Model
Public Class PMS_TimingBLL
    Dim dalFactory As EnterpriseDalFactory
    Dim iEntity As IPMS_Timing
    Public Sub New()
        dalFactory = New EnterpriseDalFactory()

        iEntity = dalFactory.GetProduct(Of IPMS_Timing, PMS_TimingDAO)()
    End Sub
    Public Function GetEntityById(ByVal id As Integer) As PMS_Timing
        Return iEntity.GetEntityById(id)
    End Function
    Public Sub DeleteEntity(ByVal Id As Integer)
        iEntity.DeleteEntity(Id)
    End Sub
    Public Function GetEntityDataSet() As DataSet
        Return iEntity.GetEntityDataSet()
    End Function
    Public Function GetEntityList() As List(Of PMS_Timing)
        Return iEntity.GetEntityList()
    End Function
    Public Function SaveEntity(ByVal entity As PMS_Timing) As Integer
        Return iEntity.SaveEntity(entity)
    End Function
 
    Public Function GetProposalTimingList(ByVal proposalId As Integer) As List(Of PMS_Timing)
        Return iEntity.GetProposalTimingList(proposalId)
    End Function
    Public Function GetTimingListByJobNumber(ByVal jobNumber As String) As List(Of PMS_Timing)
        Return iEntity.GetTimingListByJobNumber(jobNumber)
    End Function
    Public Function GetTimingListByComponentId(ByVal componentId As String) As List(Of PMS_Timing)
        Return iEntity.GetTimingListByComponentId(componentId)
    End Function
    Public Function GetTimingStaticTaskList(ByVal stageId As Integer, ByVal proposalId As Integer, ByVal jobNumber As String) As List(Of PMS_Timing)
        Dim staticTaskList As New List(Of PMS_Timing)
        Dim DGDesignTask As PMS_Timing = CreateStaticTask(stageId, proposalId, "DG Design", 1, jobNumber)
        staticTaskList.Add(DGDesignTask)
        Dim QNRDesignTask As PMS_Timing = CreateStaticTask(stageId, proposalId, "QNR Design", 2, jobNumber)
        staticTaskList.Add(QNRDesignTask)
        'Traveling
        Dim AnalysisDesignTask As PMS_Timing = CreateStaticTask(stageId, proposalId, "Analysis&Design", 50, jobNumber)
        staticTaskList.Add(AnalysisDesignTask)
        Dim ConsultingTask As PMS_Timing = CreateStaticTask(stageId, proposalId, "Consulting", 60, jobNumber)
        staticTaskList.Add(ConsultingTask)
        Dim ReportTask As PMS_Timing = CreateStaticTask(stageId, proposalId, "Report", 60, jobNumber)
        staticTaskList.Add(ReportTask)
        Return staticTaskList
    End Function
    Private Function CreateStaticTask(ByVal stageId As Integer, ByVal proposalId As Integer, ByVal TaskName As String, ByVal TaskOrder As Integer, ByVal jobNumber As String) As PMS_Timing
        Dim task As New PMS_Timing
        task.Id = -1
        task.TaskOrder = TaskOrder
        task.Task = TaskName
        task.componentId = -1
        task.StageId = stageId
        task.ProposalId = proposalId
        task.Jobnumber = jobNumber
        'task.TaskType = QuotationTypeEnum.StaticTask.ToString
        Return task
    End Function
    Public Function GetInitTimingListByMethodology(ByVal methodologyId As String) As List(Of PMS_Timing)
        Return iEntity.GetInitTimingListByMethodology(methodologyId)
    End Function
    Public Function SaveTimingList(ByVal timingList As List(Of PMS_Timing)) As Boolean
        Return iEntity.SaveTimingList(timingList)
    End Function
    Public Function SetTimingListStatus(ByVal timingList As List(Of PMS_Timing), ByVal status As String) As Boolean
        Return iEntity.SetTimingListStatus(timingList, status)
    End Function
End Class
