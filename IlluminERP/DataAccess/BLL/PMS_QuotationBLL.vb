Imports DataAccess.IDAL
Imports DataAccess.SQLServerDAL
Imports DataAccess.Model
Public Class PMS_QuotationBLL
    Dim dalFactory As EnterpriseDalFactory
    Dim iEntity As IPMS_Quotation
    Public Sub New()
        dalFactory = New EnterpriseDalFactory()

        iEntity = dalFactory.GetProduct(Of IPMS_Quotation, PMS_QuotationDAO)()
    End Sub
    Public Function GetEntityById(ByVal id As Integer) As PMS_Quotation
        Return iEntity.GetEntityById(id)
    End Function
    Public Sub DeleteEntity(ByVal Id As Integer)
        iEntity.DeleteEntity(Id)
    End Sub
    Public Function GetEntityDataSet() As DataSet
        Return iEntity.GetEntityDataSet()
    End Function
    Public Function GetEntityList() As List(Of PMS_Quotation)
        Return iEntity.GetEntityList()
    End Function
    Public Function SaveEntity(ByVal entity As PMS_Quotation) As Integer
        Return iEntity.SaveEntity(entity)
    End Function
    Public Function GetStageQuotation(ByVal stageId As Integer) As List(Of PMS_Quotation)
        Return iEntity.GetStageQuotation(stageId)
    End Function
    Public Function GetProposalQuotationList(ByVal proposalId As Integer) As List(Of PMS_Quotation)
        Return iEntity.GetProposalQuotationList(proposalId)
    End Function
    Public Function GetQuotationListByJobNumber(ByVal jobNumber As String) As List(Of PMS_Quotation)
        Return iEntity.GetQuotationListByJobNumber(jobNumber)
    End Function
    Public Function GetQuotationListByComponentId(ByVal componentId As String) As List(Of PMS_Quotation)
        Return iEntity.GetQuotationListByComponentId(componentId)
    End Function
    Public Function GetQuotationStaticTaskList(ByVal stageId As Integer, ByVal proposalId As Integer, ByVal jobNumber As String) As List(Of PMS_Quotation)
        Dim staticTaskList As New List(Of PMS_Quotation)
        Dim PMTask As PMS_Quotation = CreateStaticTask(stageId, proposalId, "Project management ", 1, jobNumber)
        staticTaskList.Add(PMTask)
        Dim DGDesignTask As PMS_Quotation = CreateStaticTask(stageId, proposalId, "DG Design", 1, jobNumber)
        staticTaskList.Add(DGDesignTask)
        Dim QNRDesignTask As PMS_Quotation = CreateStaticTask(stageId, proposalId, "QNR Design", 2, jobNumber)
        staticTaskList.Add(QNRDesignTask)
        'Traveling
        Dim AnalysisDesignTask As PMS_Quotation = CreateStaticTask(stageId, proposalId, "Analysis&Design", 50, jobNumber)
        staticTaskList.Add(AnalysisDesignTask)
        Dim ConsultingTask As PMS_Quotation = CreateStaticTask(stageId, proposalId, "Consulting", 60, jobNumber)
        staticTaskList.Add(ConsultingTask)
        Dim ReportingTask As PMS_Quotation = CreateStaticTask(stageId, proposalId, "Reporting", 60, jobNumber)
        staticTaskList.Add(ReportingTask)

        'Dim TAXTask As PMS_Quotation = CreateStaticTask(stageId, proposalId, "TAX", 60, jobNumber)
        'staticTaskList.Add(TAXTask)
        'Dim SpecialdiscountTask As PMS_Quotation = CreateStaticTask(stageId, proposalId, "Special discount", 60, jobNumber)
        'staticTaskList.Add(SpecialdiscountTask)
        Dim OthersTask As PMS_Quotation = CreateStaticTask(stageId, proposalId, "Others", 60, jobNumber)
        staticTaskList.Add(OthersTask)
        Return staticTaskList
    End Function
    
    Private Function CreateStaticTask(ByVal stageId As Integer, ByVal proposalId As Integer, ByVal TaskName As String, ByVal TaskOrder As Integer, ByVal jobNumber As String) As PMS_Quotation
        Dim task As New PMS_Quotation
        task.Id = -1
        task.TaskOrder = TaskOrder
        task.Task = TaskName
        task.componentId = -1
        task.StageId = stageId
        task.ProposalId = proposalId
        'task.QuotationType = QuotationTypeEnum.StaticTask.ToString
        task.Jobnumber = jobNumber
        Return task
    End Function
    Public Function GetInitQuotationListByMethodology(ByVal MethodologyId As String) As List(Of PMS_Quotation)
        Return iEntity.GetInitQuotationListByMethodology(MethodologyId)
    End Function
    Public Function SaveQuotationList(ByVal quotationList As List(Of PMS_Quotation)) As Boolean
        Return iEntity.SaveQuotationList(quotationList)
    End Function
    Public Function SetQuotationListStatus(ByVal list As List(Of PMS_Quotation), ByVal status As String) As Boolean
        Return iEntity.SetQuotationListStatus(list, status)
    End Function
End Class
