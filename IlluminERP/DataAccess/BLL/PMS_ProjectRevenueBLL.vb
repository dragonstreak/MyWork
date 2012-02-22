Imports DataAccess.IDAL
Imports DataAccess.SQLServerDAL
Imports DataAccess.Model
Public Class PMS_ProjectRevenueBLL
    Dim dalFactory As EnterpriseDalFactory
    Dim iEntity As IPMS_ProjectRevenue
    Public Sub New()
        dalFactory = New EnterpriseDalFactory()

        iEntity = dalFactory.GetProduct(Of IPMS_ProjectRevenue, PMS_ProjectRevenueDAO)()
    End Sub
    Public Function GetEntityById(ByVal id As Integer) As PMS_ProjectRevenue
        Return iEntity.GetEntityById(id)
    End Function
    Public Sub DeleteEntity(ByVal Id As Integer)
        iEntity.DeleteEntity(Id)
    End Sub
    Public Function GetEntityDataSet() As DataSet
        Return iEntity.GetEntityDataSet()
    End Function
    Public Function GetEntityList() As List(Of PMS_ProjectRevenue)
        Return iEntity.GetEntityList()
    End Function
    Public Function SaveEntity(ByVal entity As PMS_ProjectRevenue) As Integer
        Return iEntity.SaveEntity(entity)
    End Function
    Public Function GetProjectRevenueList(ByVal jobNumber As String, ByVal projectId As String) As List(Of PMS_ProjectRevenue)
        Return iEntity.GetProjectRevenueList(jobNumber, projectId)
    End Function
End Class
