Imports DataAccess.IDAL
Imports DataAccess.SQLServerDAL
Imports DataAccess.Model

Public Class PMS_MethodologyBLL
    Dim dalFactory As EnterpriseDalFactory
    Dim iEntity As IPMS_Methodology
    Public Sub New()
        dalFactory = New EnterpriseDalFactory()

        iEntity = dalFactory.GetProduct(Of IPMS_Methodology, PMS_MethodologyDAO)()
    End Sub
    Public Function GetEntityById(ByVal id As Integer) As PMS_Methodology
        Return iEntity.GetEntityById(id)
    End Function
    Public Sub DeleteEntity(ByVal Id As Integer)
        iEntity.DeleteEntity(Id)
    End Sub
    Public Function GetEntityDataSet() As DataSet
        Return iEntity.GetEntityDataSet()
    End Function
    Public Function GetEntityList() As List(Of PMS_Methodology)
        Return iEntity.GetEntityList()
    End Function
    Public Function SaveEntity(ByVal entity As PMS_Methodology) As Integer
        Return iEntity.SaveEntity(entity)
    End Function
    Public Function GetMethodologyTypeDataSet() As DataSet
        Return iEntity.GetMethodologyTypeDataSet()
    End Function
    Public Function GetComponentMethodlogy(ByVal componentId As Integer) As PMS_Methodology
        Return iEntity.GetComponentMethodlogy(componentId)
    End Function
End Class
