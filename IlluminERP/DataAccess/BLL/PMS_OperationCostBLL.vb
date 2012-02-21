Imports DataAccess.IDAL
Imports DataAccess.SQLServerDAL
Imports DataAccess.Model
Public Class PMS_OperationCostBLL
    Dim dalFactory As EnterpriseDalFactory
    Dim iEntity As IPMS_OperationCost
    Public Sub New()
        dalFactory = New EnterpriseDalFactory()

        iEntity = dalFactory.GetProduct(Of IPMS_OperationCost, PMS_OperationCostDAO)()
    End Sub
    Public Function GetEntityById(ByVal id As Integer) As PMS_OperationCost
        Return iEntity.GetEntityById(id)
    End Function
    Public Sub DeleteEntity(ByVal Id As Integer)
        iEntity.DeleteEntity(Id)
    End Sub
    Public Function GetEntityDataSet() As DataSet
        Return iEntity.GetEntityDataSet()
    End Function
    Public Function GetEntityList() As List(Of PMS_OperationCost)
        Return iEntity.GetEntityList()
    End Function
    Public Function SaveEntity(ByVal entity As PMS_OperationCost) As Integer
        Return iEntity.SaveEntity(entity)
    End Function
    Public Sub SaveEntityDictionary(ByVal costDistionary As Dictionary(Of String, PMS_OperationCost))
        For Each entityPair As KeyValuePair(Of String, PMS_OperationCost) In costDistionary
            Dim entity As PMS_OperationCost = entityPair.Value
            SaveEntity(entity)
        Next
    End Sub
    Public Function GetProjectCostList(ByVal costType As String, ByVal jobNumber As String) As DataSet
        Return Nothing
    End Function
    Public Function GetComponentCostList(ByVal costType As String, ByVal componentId As Integer) As List(Of PMS_OperationCost)
        Return iEntity.GetComponentCostList(costType, componentId)
    End Function
    Public Function GetProjectAndCostDetail(ByVal costType As String, ByVal jobNumber As String) As DataSet
        Return iEntity.GetProjectAndCostDetail(costType, jobNumber)
    End Function
    ''' <summary>
    ''' This is the method to get project profit.
    ''' </summary>
    ''' <param name="JobNumber"></param>
    ''' <param name="CostType">>It will be 'Actual' only</param>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Function GetProjectProfit(ByVal JobNumber As String, ByVal CostType As String) As List(Of PMS_OperationCost)
        Return iEntity.GetProjectProfit(JobNumber, "Actual")
    End Function
End Class
