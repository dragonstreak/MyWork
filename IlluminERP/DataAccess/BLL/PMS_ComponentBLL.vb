Imports System
Imports System.Data
Imports System.DirectoryServices
Imports System.Data.SqlClient
Imports DataAccess
Imports DataAccess.IDAL
Imports DataAccess.Model
Imports DataAccess.SQLServerDAL
Public Class PMS_ComponentBLL
    Dim dalFactory As EnterpriseDalFactory
    'Dim methodologyBLL As New PMS_MethodologyBLL
    Dim criteriaBLL As New PMS_RespondentCriteriaBLL
    Dim cityCoverageBLL As New PMS_CityCoverageBLL
    Dim quotationBLL As New PMS_QuotationBLL
    Dim timingBLL As New PMS_TimingBLL
    Dim iEntity As IPMS_Component
    Dim costingFileBLL As New PMS_ComponentCostingFileBLL

    Public Sub New()
        dalFactory = New EnterpriseDalFactory()

        iEntity = dalFactory.GetProduct(Of IPMS_Component, PMS_ComponentDAO)()
    End Sub
    Public Function GetEntityById(ByVal id As Integer) As PMS_Component
        Return iEntity.GetEntityById(id)
    End Function
    Public Sub DeleteEntity(ByVal Id As Integer)
        iEntity.DeleteEntity(Id)
    End Sub
    Public Function GetEntityDataSet() As DataSet
        Return iEntity.GetEntityDataSet()
    End Function
    Public Function GetEntityList() As List(Of PMS_Component)
        Return iEntity.GetEntityList()
    End Function
    Public Function SaveEntity(ByVal entity As PMS_Component) As Integer
        Return iEntity.SaveEntity(entity)
    End Function
    Public Function SaveComponent(ByVal entity As PMS_Component) As Integer
        Dim needSaveQuotationAndTiming As Boolean = False
        'Save Component
        If (entity.id = -1) Then
            needSaveQuotationAndTiming = True
        End If
        iEntity.SaveEntity(entity)
      
            For Each timing As PMS_Timing In entity.TimingTaskList
                timing.componentId = entity.id
                timing.Jobnumber = entity.Jobnumber
                timing.StageId = entity.StageId
            Next
            For Each quotation As PMS_Quotation In entity.QuotationTaskList
                quotation.componentId = entity.id
                quotation.Jobnumber = entity.Jobnumber
                quotation.StageId = entity.StageId
            Next

        timingBLL.SaveTimingList(entity.TimingTaskList)
        quotationBLL.SaveQuotationList(entity.QuotationTaskList)
        'Save MethodologyList
        'methodologyBLL.SaveEntity(entity.Methodology)
        'Save CriteriaList
        For Each criteria As PMS_RespondentCriteria In entity.CriteriaList
            If criteria.abstractEntityStatus = Utils.EntityStatus.UnChange Then
                Continue For
            End If
            criteria.ComponentId = entity.id
            criteriaBLL.SaveEntity(criteria)
        Next
        'Save City coverage
        For Each cityCoverage As PMS_CityCoverage In entity.CityCovergyList
            If cityCoverage.abstractEntityStatus = Utils.EntityStatus.UnChange Then
                Continue For

            End If
            cityCoverage.ComponentId = entity.id
            cityCoverageBLL.SaveEntity(cityCoverage)
        Next

    End Function
    Public Function GetComponentById(ByVal id As Integer) As PMS_Component
        Dim component As PMS_Component = iEntity.GetEntityById(id)
        'Get Methodology List
        'component.Methodology = methodologyBLL.GetComponentMethodlogy(component.id)
        'Get criteria list
        component.CriteriaList = criteriaBLL.GetComponentCriteriaList(component.id)
        'Get city coverage
        component.CityCovergyList = cityCoverageBLL.GetComponentCityCoverageList(component.id)

        'add on 2012/1/21
        'Get component costing file
        component.ComponentCostingFile = costingFileBLL.GetComponentCostingFile(component.id)
        component.TimingTaskList = timingBLL.GetTimingListByComponentId(component.id)
        For Each timing As PMS_Timing In component.TimingTaskList
            timing.Jobnumber = component.Jobnumber
            timing.componentId = component.id
            timing.StageId = component.StageId
        Next
        component.QuotationTaskList = quotationBLL.GetQuotationListByComponentId(component.id)
        For Each quotation As PMS_Quotation In component.QuotationTaskList
            quotation.Jobnumber = component.Jobnumber
            quotation.componentId = component.id
            quotation.StageId = component.StageId
        Next
        Return component
    End Function
    Public Function GetStageComponentList(ByVal stageId As Integer) As List(Of PMS_Component)
        Return iEntity.GetStageComponentList(stageId)
    End Function
End Class
